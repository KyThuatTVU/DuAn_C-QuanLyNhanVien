-- Tạo database
CREATE DATABASE LTUD_QLNS;
GO
USE LTUD_QLNS;
GO

-- Tạo/điều chỉnh bảng dangnhap
IF OBJECT_ID('dbo.dangnhap','U') IS NOT NULL
BEGIN
    DROP TABLE dbo.dangnhap;
END
GO

CREATE TABLE dangnhap (
    Taikhoan VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(50) NOT NULL,
    quyen INT
);
GO

-- Chèn dữ liệu có kiểm tra trùng
IF NOT EXISTS (SELECT 1 FROM dangnhap WHERE Taikhoan = 'Nguyen Huynh Ky Thuat')
    INSERT INTO dangnhap VALUES ('Nguyen Huynh Ky Thuat','123456',1);

IF NOT EXISTS (SELECT 1 FROM dangnhap WHERE Taikhoan = 'khac')
    INSERT INTO dangnhap VALUES ('khac','1234',2);
GO

-- Kiểm tra
SELECT * FROM dangnhap;
