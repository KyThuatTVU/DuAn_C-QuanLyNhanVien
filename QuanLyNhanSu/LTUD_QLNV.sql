-- 0. Xóa các bảng theo thứ tự phụ thuộc
DROP TABLE IF EXISTS KhenThuong;
DROP TABLE IF EXISTS Luong;
DROP TABLE IF EXISTS ChamCong;
DROP TABLE IF EXISTS NhanVien;
DROP TABLE IF EXISTS ChucVu;
DROP TABLE IF EXISTS PhongBan;

-- 1. Tạo CSDL nếu chưa có
CREATE DATABASE LTUD_QLNV;
GO
USE LTUD_QLNV;
GO

-- 2. Phòng ban
CREATE TABLE PhongBan (
    MaPB INT PRIMARY KEY IDENTITY(1,1),
    TenPB NVARCHAR(100)
);

-- 3. Chức vụ
CREATE TABLE ChucVu (
    MaCV INT PRIMARY KEY IDENTITY(1,1),
    TenCV NVARCHAR(100),
    HeSoLuong DECIMAL(5,2)
);

-- 4. Nhân viên (thêm cột HinhAnh)
CREATE TABLE NhanVien (
    MaNV INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100),
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    DiaChi NVARCHAR(200),
    SDT VARCHAR(15),
    Email VARCHAR(100),
    HinhAnh NVARCHAR(255),   -- <— đây mới chính là nhánh đường lưu ảnh  
    MaPB INT,
    MaCV INT,
    FOREIGN KEY (MaPB) REFERENCES PhongBan(MaPB),
    FOREIGN KEY (MaCV) REFERENCES ChucVu(MaCV)
);

-- 5. Chấm công
CREATE TABLE ChamCong (
    MaCC INT PRIMARY KEY IDENTITY(1,1),
    MaNV INT,
    Ngay DATE,
    TrangThai NVARCHAR(20),
    GhiChu NVARCHAR(200),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- 6. Lương
CREATE TABLE Luong (
    MaLuong INT PRIMARY KEY IDENTITY(1,1),
    MaNV INT,
    Thang INT,
    Nam INT,
    SoNgayCong INT,
    LuongCoBan DECIMAL(10,2),
    TongLuong AS (LuongCoBan * SoNgayCong),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- 7. Khen thưởng
CREATE TABLE KhenThuong (
    MaKT INT PRIMARY KEY IDENTITY(1,1),
    MaNV INT,
    Ngay DATE,
    LyDo NVARCHAR(255),
    SoTien DECIMAL(10,2),
    GhiChu NVARCHAR(255),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);


-- Dữ liệu Phòng ban
INSERT INTO PhongBan (TenPB) VALUES 
(N'Hành chính'), 
(N'Kỹ thuật'), 
(N'Kế toán'), 
(N'Nhân sự'),
(N'Bán hàng'),
(N'Marketing');

-- Dữ liệu Chức vụ
INSERT INTO ChucVu (TenCV, HeSoLuong) VALUES 
(N'Nhân viên', 1.00),
(N'Trưởng nhóm', 1.30),
(N'Trưởng phòng', 1.50),
(N'Phó giám đốc', 1.80),
(N'Giám đốc', 2.00);

-- Dữ liệu Nhân viên
INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, DiaChi, SDT, Email, HinhAnh, MaPB, MaCV) VALUES 
(N'Nguyễn Văn A', N'Nam', '1990-01-15', N'Hà Nội', '0909123456', 'a@gmail.com', N'/images/nva.jpg', 1, 1),
(N'Lê Thị B', N'Nữ', '1992-03-12', N'Hồ Chí Minh', '0912345678', 'b@gmail.com', N'/images/ltb.jpg', 2, 2),
(N'Trần Văn C', N'Nam', '1988-05-20', N'Đà Nẵng', '0903344556', 'c@gmail.com', N'/images/tvc.jpg', 3, 3),
(N'Phạm Thị D', N'Nữ', '1995-07-08', N'Bình Dương', '0922334455', 'd@gmail.com', N'/images/ptd.jpg', 4, 1),
(N'Hồ Văn E', N'Nam', '1985-10-30', N'Cần Thơ', '0933445566', 'e@gmail.com', N'/images/hve.jpg', 5, 2),
(N'Võ Thị F', N'Nữ', '1993-12-01', N'Đà Lạt', '0944556677', 'f@gmail.com', N'/images/vtf.jpg', 6, 1),
(N'Nguyễn Minh G', N'Nam', '1989-09-18', N'Huế', '0955667788', 'g@gmail.com', N'/images/nmg.jpg', 1, 3),
(N'Lý Thị H', N'Nữ', '1991-06-25', N'Hà Tĩnh', '0966778899', 'h@gmail.com', N'/images/lth.jpg', 2, 4),
(N'Tô Văn I', N'Nam', '1994-11-11', N'Hải Phòng', '0977889900', 'i@gmail.com', N'/images/tvi.jpg', 3, 1),
(N'Cao Thị J', N'Nữ', '1996-08-22', N'Quảng Ninh', '0988990011', 'j@gmail.com', N'/images/ctj.jpg', 4, 2);


-- Chấm công tháng 4 và 5 (2025) cho vài nhân viên
INSERT INTO ChamCong (MaNV, Ngay, TrangThai, GhiChu) VALUES
(1, '2025-04-01', N'Có mặt', N''),
(1, '2025-04-02', N'Có mặt', N''),
(1, '2025-04-03', N'Nghỉ phép', N'Lý do cá nhân'),
(2, '2025-04-01', N'Có mặt', N''),
(2, '2025-04-02', N'Vắng', N'Không lý do'),
(2, '2025-04-03', N'Có mặt', N''),
(3, '2025-05-01', N'Có mặt', N''),
(3, '2025-05-02', N'Có mặt', N''),
(4, '2025-05-01', N'Nghỉ phép', N'Có đơn'),
(4, '2025-05-02', N'Có mặt', N''),
(5, '2025-05-01', N'Vắng', N'Không báo trước'),
(5, '2025-05-02', N'Có mặt', N''),
(6, '2025-05-01', N'Có mặt', N''),
(6, '2025-05-02', N'Có mặt', N'');

-- Lương tháng 4 và 5 cho 3 nhân viên
INSERT INTO Luong (MaNV, Thang, Nam, SoNgayCong, LuongCoBan) VALUES
(1, 4, 2025, 20, 5000000),
(1, 5, 2025, 22, 5000000),
(2, 4, 2025, 18, 5000000),
(2, 5, 2025, 20, 5000000),
(3, 4, 2025, 21, 6000000),
(3, 5, 2025, 23, 6000000);

-- Khen thưởng các nhân viên
INSERT INTO KhenThuong (MaNV, Ngay, LyDo, SoTien, GhiChu) VALUES
(1, '2025-04-30', N'Hoàn thành xuất sắc công việc tháng 4', 1000000, N'Thưởng nóng'),
(2, '2025-04-30', N'Thái độ làm việc tốt', 500000, N''),
(3, '2025-05-01', N'Tham gia dự án ABC thành công', 1500000, N''),
(4, '2025-05-01', N'Làm việc vượt chỉ tiêu', 700000, N''),
(5, '2025-05-01', N'Hỗ trợ phòng khác hiệu quả', 500000, N'Được đề xuất bởi trưởng phòng');

-- 1. Danh sách phòng ban
SELECT * FROM PhongBan;

-- 2. Danh sách chức vụ
SELECT * FROM ChucVu;

-- 3. Danh sách nhân viên
SELECT * FROM NhanVien;

-- 4. Danh sách chấm công
SELECT * FROM ChamCong;

-- 5. Danh sách lương
SELECT * FROM Luong;

-- 6. Danh sách khen thưởng
SELECT * FROM KhenThuong;
