using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class PhongBan : Form
    {
        private bool isAdding = false;
        private bool isEditing = false;

        public PhongBan()
        {
            InitializeComponent();
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            LoadData();
            SetInitialButtonStates();
            dtLuoi.SelectionChanged += dtLuoi_SelectionChanged;
            dtLuoi.CellClick += dtLuoi_CellClick;
        }

        private void LoadData()
        {
            string sql = "SELECT MaPB AS [Mã PB], TenPB AS [Tên Phòng Ban] FROM PhongBan";
            DataTable dt = DatabaseConnection.GetData(sql);
            dtLuoi.DataSource = dt;
            dtLuoi.Columns["Mã PB"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtLuoi.Columns["Tên Phòng Ban"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtLuoi.ClearSelection();
            ClearInputFields();
            SetInitialButtonStates();
            txtMaPhong.ReadOnly = true;
            txttenPhong.ReadOnly = true;
        }

        private void dtLuoi_SelectionChanged(object sender, EventArgs e)
        {
            HandleGridSelection();
        }

        private void dtLuoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                HandleGridSelection();
            }
        }

        private void HandleGridSelection()
        {
            if (dtLuoi.SelectedRows.Count > 0 && !isAdding && !isEditing)
            {
                DataGridViewRow selectedRow = dtLuoi.SelectedRows[0];
                txtMaPhong.Text = selectedRow.Cells["Mã PB"].Value?.ToString() ?? "";
                txttenPhong.Text = selectedRow.Cells["Tên Phòng Ban"].Value?.ToString() ?? "";
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnCapNhat.Enabled = true;
                txtMaPhong.ReadOnly = true;
                txttenPhong.ReadOnly = true;
            }
            else if (dtLuoi.SelectedRows.Count == 0 && !isAdding && !isEditing)
            {
                ClearInputFields();
                SetInitialButtonStates();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;
            ClearInputFields();
            SetEditingState(true);
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnCapNhat.Enabled = true;
            btnTimKiem.Enabled = false;
            txtMaPhong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn một phòng ban để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng ban này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string sql = "DELETE FROM PhongBan WHERE MaPB = @MaPB";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaPB", SqlDbType.VarChar) { Value = txtMaPhong.Text }
                };

                int result = DatabaseConnection.ExecuteNonQuery(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else if (result == 0)
                {
                    MessageBox.Show("Không tìm thấy phòng ban để xóa hoặc không có gì thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                SetInitialButtonStates();
                ClearInputFields();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn một phòng ban để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            isEditing = true;
            SetEditingState(false);
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnCapNhat.Enabled = true;
            btnTimKiem.Enabled = false;
            txttenPhong.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // --- Kiểm tra dữ liệu đầu vào cơ bản ---
            // BỎ KIỂM TRA MaPhong KHI THÊM (vì DB tự tạo)
            // if (string.IsNullOrWhiteSpace(txtMaPhong.Text) && isAdding)
            // {
            //     MessageBox.Show("Mã phòng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     txtMaPhong.Focus(); // Đặt focus vào ô Mã phòng
            //     return; // Dừng thực thi
            // }

            // Tên phòng luôn bắt buộc
            if (string.IsNullOrWhiteSpace(txttenPhong.Text))
            {
                MessageBox.Show("Tên phòng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenPhong.Focus(); // Đặt focus vào ô Tên phòng
                return; // Dừng thực thi
            }

            string sql; // Chuỗi SQL sẽ được xây dựng
            SqlParameter[] parameters; // Mảng tham số SQL

            if (isAdding) // --- Trường hợp THÊM MỚI ---
            {
                // BỎ KIỂM TRA TRÙNG MaPB KHI THÊM
                // string checkSql = "SELECT COUNT(*) FROM PhongBan WHERE MaPB = @MaPB";
                // SqlParameter[] checkParams = { new SqlParameter("@MaPB", SqlDbType.VarChar) { Value = txtMaPhong.Text } };
                // DataTable checkTable = DatabaseConnection.GetData(checkSql, checkParams);
                // if (checkTable != null && checkTable.Rows.Count > 0 && Convert.ToInt32(checkTable.Rows[0][0]) > 0)
                // {
                //     MessageBox.Show("Mã phòng ban đã tồn tại. Vui lòng nhập mã khác.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //     txtMaPhong.Focus();
                //     return; // Dừng lại không thêm
                // }

                // *** SỬA ĐỔI CÂU LỆNH INSERT: Chỉ chèn TenPB ***
                sql = "INSERT INTO PhongBan (TenPB) VALUES (@TenPB)";
                // *** SỬA ĐỔI THAM SỐ: Chỉ cần TenPB ***
                parameters = new SqlParameter[] {
                    new SqlParameter("@TenPB", SqlDbType.NVarChar) { Value = txttenPhong.Text }
                };
            }
            else if (isEditing) // --- Trường hợp SỬA --- (Phần này giữ nguyên)
            {
                // Xây dựng câu lệnh UPDATE
                sql = "UPDATE PhongBan SET TenPB = @TenPB WHERE MaPB = @MaPB";
                // Tạo mảng tham số cho UPDATE
                parameters = new SqlParameter[] {
                    new SqlParameter("@TenPB", SqlDbType.NVarChar) { Value = txttenPhong.Text },
                    new SqlParameter("@MaPB", SqlDbType.VarChar) { Value = txtMaPhong.Text } // MaPB ở đây là để xác định WHERE, không phải để chèn
                };
            }
            else // Trường hợp không xác định (không nên xảy ra nếu quản lý trạng thái tốt)
            {
                MessageBox.Show("Trạng thái không xác định. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực thi lệnh INSERT hoặc UPDATE
            int result = DatabaseConnection.ExecuteNonQuery(sql, parameters);

            if (result > 0) // Nếu có hàng bị ảnh hưởng (thêm/sửa thành công)
            {
                // Hiển thị thông báo thành công tương ứng
                MessageBox.Show(isAdding ? "Thêm phòng ban thành công!" : "Cập nhật phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại dữ liệu để hiển thị thay đổi (bao gồm MaPB mới được tạo)
                isAdding = false; // Đặt lại cờ trạng thái
                isEditing = false;
                SetInitialButtonStates(); // Đặt lại trạng thái các nút
            }
            else if (result == 0 && isEditing) // Nếu đang sửa mà không có hàng nào được cập nhật
            {
                MessageBox.Show("Không tìm thấy phòng ban để cập nhật hoặc dữ liệu không thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            isAdding = false;
            isEditing = false;
            txtTimKiem.Clear();
            LoadData();
            MessageBox.Show("Đã làm mới dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập tên phòng ban cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                return;
            }

            string sql = "SELECT MaPB AS [Mã PB], TenPB AS [Tên Phòng Ban] FROM PhongBan WHERE TenPB LIKE N'%' + @TenPB + '%'";
            SqlParameter[] parameters = {
                new SqlParameter("@TenPB", SqlDbType.NVarChar) { Value = searchTerm }
            };

            DataTable dt = DatabaseConnection.GetData(sql, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                dtLuoi.DataSource = dt;
                dtLuoi.ClearSelection();
                ClearInputFields();
                SetInitialButtonStates();
                MessageBox.Show($"Tìm thấy {dt.Rows.Count} kết quả.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng ban nào phù hợp.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtLuoi.DataSource = null;
            }

            isAdding = false;
            isEditing = false;
        }

        private void ClearInputFields()
        {
            txtMaPhong.Clear();
            txttenPhong.Clear();
        }

        private void SetInitialButtonStates()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnCapNhat.Enabled = true;
            btnTimKiem.Enabled = true;
            txtMaPhong.ReadOnly = true;
            txttenPhong.ReadOnly = true;
            isAdding = false;
            isEditing = false;
            dtLuoi.ClearSelection();
        }

        private void SetEditingState(bool isAddingMode)
        {
            txtMaPhong.ReadOnly = !isAddingMode;
            txttenPhong.ReadOnly = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            QuanTri ql = new QuanTri(); 
            ql.Show(); 
        }

    }
}

