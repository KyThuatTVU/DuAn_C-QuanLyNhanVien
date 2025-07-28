// ChamCong.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // Add this
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class ChamCong : Form
    {
        private bool isAdding = false; // Flag to track if we are adding or editing
        private int? currentMaCC = null; // To store the MaCC of the selected row for editing/deleting

        public ChamCong()
        {
            InitializeComponent();

            // --- Initialization Code ---
            LoadDataGridView();
            LoadEmployeeComboBox();
            LoadStatusComboBox();
            SetupDataGridView();
            ConfigureInitialUIState();

            // --- Event Wiring ---
            dtLuoi.SelectionChanged += dtLuoi_SelectionChanged;
            cbHoTenNhanVien.SelectedIndexChanged += cbHoTenNhanVien_SelectedIndexChanged;
            this.Load += ChamCong_Load;
            btnThongKe.Click += btnThongKe_Click; // Wire up the event handler for ThongKe button
        }

        private void ChamCong_Load(object sender, EventArgs e)
        {
            txtChamCong.ReadOnly = true;
            ClearInputFields();
            SetDefaultButtonStates();
            btnThongKe.Enabled = false; // Disable ThongKe button initially
        }


        // --- Data Loading Methods ---

        private void LoadDataGridView()
        {
            try
            {
                string sql = "SELECT MaCC, cc.MaNV, nv.HoTen, Ngay, TrangThai, GhiChu " +
                             "FROM ChamCong cc INNER JOIN [LTUD_QLNV].dbo.NhanVien nv ON cc.MaNV = nv.MaNV " +
                             "ORDER BY Ngay DESC, nv.HoTen";

                DataTable dt = DatabaseConnection.GetData(sql);
                dtLuoi.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu chấm công: {ex.Message}\n\nKiểm tra lại kết nối và quyền truy cập vào bảng NhanVien trong database LTUD_QLNV.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployeeComboBox()
        {
            try
            {
                string sql = "SELECT MaNV, HoTen FROM [LTUD_QLNV].dbo.NhanVien ORDER BY HoTen";
                DataTable dt = DatabaseConnection.GetData(sql);
                DataRow dr = dt.NewRow();
                dr["MaNV"] = DBNull.Value;
                dr["HoTen"] = "-- Chọn nhân viên --";
                dt.Rows.InsertAt(dr, 0);
                cbHoTenNhanVien.DataSource = dt;
                cbHoTenNhanVien.DisplayMember = "HoTen";
                cbHoTenNhanVien.ValueMember = "MaNV";
                cbHoTenNhanVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách nhân viên: {ex.Message}\n\nKiểm tra lại kết nối và quyền truy cập vào bảng NhanVien trong database LTUD_QLNV.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatusComboBox()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("-- Chọn trạng thái --");
            cbTrangThai.Items.Add("Có mặt");
            cbTrangThai.Items.Add("Nghỉ phép");
            cbTrangThai.Items.Add("Vắng");
            cbTrangThai.SelectedIndex = 0;
        }

        // --- UI Configuration ---

        private void SetupDataGridView()
        {
            dtLuoi.AutoGenerateColumns = false;
            dtLuoi.AllowUserToAddRows = false;
            dtLuoi.AllowUserToDeleteRows = false;
            dtLuoi.ReadOnly = true;
            dtLuoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtLuoi.MultiSelect = false;
            SetupDataGridViewColumns();
        }

        private void SetupDataGridViewColumns()
        {
            dtLuoi.Columns.Clear();
            dtLuoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaCCCol",
                HeaderText = "Mã CC",
                DataPropertyName = "MaCC",
                Visible = true,
                Width = 60
            });
            dtLuoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaNVCol",
                HeaderText = "Mã NV",
                DataPropertyName = "MaNV",
                Width = 60,
                Visible = false
            });
            dtLuoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTenCol",
                HeaderText = "Họ Tên",
                DataPropertyName = "HoTen",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dtLuoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayCol",
                HeaderText = "Ngày Làm",
                DataPropertyName = "Ngay",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });
            dtLuoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrangThaiCol",
                HeaderText = "Trạng Thái",
                DataPropertyName = "TrangThai",
                Width = 90
            });
            dtLuoi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GhiChuCol",
                HeaderText = "Ghi Chú",
                DataPropertyName = "GhiChu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void ConfigureInitialUIState()
        {
            SetInputFieldsEnabled(false);
            SetDefaultButtonStates();
        }

        private void SetInputFieldsEnabled(bool enabled)
        {
            cbHoTenNhanVien.Enabled = enabled;
            dtNgayLam.Enabled = enabled;
            cbTrangThai.Enabled = enabled;
            txtGhiChu.Enabled = enabled;
        }

        private void SetDefaultButtonStates()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = dtLuoi.SelectedRows.Count > 0;
            btnXoa.Enabled = dtLuoi.SelectedRows.Count > 0;
            btnLuu.Enabled = false;
            btnCapNhat.Enabled = true;
            btnTimKiem.Enabled = true;
            txtTimKiem.Enabled = true;
            btnThoat.Enabled = true;
            btnThongKe.Enabled = dtLuoi.SelectedRows.Count > 0; // Enable ThongKe if a row is selected

            SetInputFieldsEnabled(false);
        }

        private void SetAddingMode()
        {
            isAdding = true;
            currentMaCC = null;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnCapNhat.Enabled = true;
            btnThongKe.Enabled = false; // Disable ThongKe during add mode
            SetInputFieldsEnabled(true);
            ClearInputFields();
            cbHoTenNhanVien.Focus();
        }

        private void SetEditingMode()
        {
            isAdding = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnCapNhat.Enabled = true;
            btnThongKe.Enabled = false; // Disable ThongKe during edit mode
            SetInputFieldsEnabled(true);
        }

        private void ClearInputFields()
        {
            txtChamCong.Clear();
            cbHoTenNhanVien.SelectedIndex = 0;
            dtNgayLam.Value = DateTime.Now;
            cbTrangThai.SelectedIndex = 0;
            txtGhiChu.Clear();
            dtLuoi.ClearSelection();
            currentMaCC = null;
        }

        // --- Event Handlers ---

        private void dtLuoi_SelectionChanged(object sender, EventArgs e)
        {
            if (dtLuoi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtLuoi.SelectedRows[0];
                object maCCValue = selectedRow.Cells["MaCCCol"].Value;
                currentMaCC = (maCCValue != DBNull.Value && maCCValue != null) ? Convert.ToInt32(maCCValue) : (int?)null;
                object maNvValue = selectedRow.Cells["MaNVCol"].Value;
                object ngayValue = selectedRow.Cells["NgayCol"].Value;
                object trangThaiValue = selectedRow.Cells["TrangThaiCol"].Value;
                object ghiChuValue = selectedRow.Cells["GhiChuCol"].Value;

                txtChamCong.Text = (maNvValue != DBNull.Value && maNvValue != null) ? maNvValue.ToString() : string.Empty;
                if (maNvValue != DBNull.Value && maNvValue != null) cbHoTenNhanVien.SelectedValue = maNvValue;
                else cbHoTenNhanVien.SelectedIndex = 0;

                dtNgayLam.Value = (ngayValue != DBNull.Value && ngayValue != null) ? Convert.ToDateTime(ngayValue) : DateTime.Now;
                string selectedStatus = (trangThaiValue != DBNull.Value && trangThaiValue != null) ? trangThaiValue.ToString() : null;
                if (selectedStatus != null && cbTrangThai.Items.Contains(selectedStatus)) cbTrangThai.SelectedItem = selectedStatus;
                else cbTrangThai.SelectedIndex = 0;
                txtGhiChu.Text = (ghiChuValue != DBNull.Value && ghiChuValue != null) ? ghiChuValue.ToString() : string.Empty;

                if (!btnLuu.Enabled) // Only update button states if not in edit/add mode
                {
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThongKe.Enabled = true; // Enable ThongKe when a row is selected
                }
            }
            else
            {
                if (!btnLuu.Enabled) // Only clear and update if not in edit/add mode
                {
                    ClearInputFields();
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThongKe.Enabled = false; // Disable ThongKe if no row is selected
                }
            }
        }

        private void cbHoTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHoTenNhanVien.SelectedIndex > 0 && cbHoTenNhanVien.SelectedValue != null && cbHoTenNhanVien.SelectedValue != DBNull.Value)
            {
                txtChamCong.Text = cbHoTenNhanVien.SelectedValue.ToString();
            }
            else
            {
                txtChamCong.Clear();
            }
        }

        // --- Button Click Methods ---

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetAddingMode();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtLuoi.SelectedRows.Count == 0 || currentMaCC == null)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi chấm công để xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa bản ghi chấm công này (Mã CC: {currentMaCC.Value}) không?",
                                                 "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string sql = "DELETE FROM ChamCong WHERE MaCC = @MaCC";
                SqlParameter[] parameters = { new SqlParameter("@MaCC", SqlDbType.Int) { Value = currentMaCC.Value } };
                try
                {
                    int result = DatabaseConnection.ExecuteNonQuery(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa bản ghi chấm công thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView(); ClearInputFields(); SetDefaultButtonStates();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi chấm công để xóa hoặc xóa thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadDataGridView(); ClearInputFields(); SetDefaultButtonStates();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa chấm công: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtLuoi.SelectedRows.Count == 0 || currentMaCC == null)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi chấm công để sửa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SetEditingMode();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbHoTenNhanVien.SelectedIndex <= 0 || cbHoTenNhanVien.SelectedValue == null || cbHoTenNhanVien.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); cbHoTenNhanVien.Focus(); return;
            }
            int maNV = Convert.ToInt32(cbHoTenNhanVien.SelectedValue);
            if (cbTrangThai.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); cbTrangThai.Focus(); return;
            }
            DateTime ngayLam = dtNgayLam.Value;
            string trangThai = cbTrangThai.SelectedItem.ToString();
            string ghiChu = txtGhiChu.Text.Trim();
            string sql;
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaNV", SqlDbType.Int) { Value = maNV },
                new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngayLam.Date },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = trangThai },
                new SqlParameter("@GhiChu", SqlDbType.NVarChar, 200) { Value = string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu }
            };
            if (isAdding)
            {
                sql = "INSERT INTO ChamCong (MaNV, Ngay, TrangThai, GhiChu) VALUES (@MaNV, @Ngay, @TrangThai, @GhiChu)";
            }
            else
            {
                if (currentMaCC == null)
                {
                    MessageBox.Show("Lỗi: Không xác định được bản ghi cần cập nhật.", "Lỗi Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetDefaultButtonStates(); ClearInputFields(); LoadDataGridView(); return;
                }
                sql = "UPDATE ChamCong SET MaNV = @MaNV, Ngay = @Ngay, TrangThai = @TrangThai, GhiChu = @GhiChu WHERE MaCC = @MaCC";
                parameters.Add(new SqlParameter("@MaCC", SqlDbType.Int) { Value = currentMaCC.Value });
            }
            try
            {
                int result = DatabaseConnection.ExecuteNonQuery(sql, parameters.ToArray());
                if (result > 0)
                {
                    MessageBox.Show(isAdding ? "Thêm chấm công thành công!" : "Cập nhật chấm công thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView(); ClearInputFields(); SetDefaultButtonStates();
                }
                else
                {
                    MessageBox.Show(isAdding ? "Thêm chấm công không thành công." : "Không tìm thấy bản ghi để cập nhật hoặc cập nhật không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SetDefaultButtonStates();
                    if (isAdding) SetAddingMode(); else SetEditingMode();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu khi lưu: {sqlEx.Message}\nSố lỗi: {sqlEx.Number}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetDefaultButtonStates();
                if (isAdding) SetAddingMode(); else SetEditingMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi không mong muốn khi lưu: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetDefaultButtonStates();
                if (isAdding) SetAddingMode(); else SetEditingMode();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
            ClearInputFields();
            SetDefaultButtonStates();
            txtTimKiem.Clear();
            MessageBox.Show("Dữ liệu đã được làm mới.", "Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();
            string baseSql = "SELECT MaCC, cc.MaNV, nv.HoTen, Ngay, TrangThai, GhiChu " +
                            "FROM ChamCong cc INNER JOIN [LTUD_QLNV].dbo.NhanVien nv ON cc.MaNV = nv.MaNV ";
            string sql;
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                sql = baseSql + " ORDER BY Ngay DESC, nv.HoTen";
            }
            else
            {
                sql = baseSql + "WHERE nv.HoTen LIKE @SearchTerm OR CAST(cc.MaNV AS VARCHAR(10)) = @ExactMatch ORDER BY Ngay DESC, nv.HoTen";
                parameters.Add(new SqlParameter("@SearchTerm", SqlDbType.NVarChar) { Value = "%" + searchTerm + "%" });
                parameters.Add(new SqlParameter("@ExactMatch", SqlDbType.VarChar) { Value = searchTerm });
            }
            DataTable dt = DatabaseConnection.GetData(sql, parameters.ToArray());
            dtLuoi.DataSource = dt;
            ClearInputFields();
            SetDefaultButtonStates();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (btnLuu.Enabled)
            {
                DialogResult confirmation = MessageBox.Show("Bạn có thay đổi chưa lưu. Bạn có muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.No) return;
            }
            this.Hide();
            QuanTri ql = new QuanTri();
            ql.Show();
        }

        // *** MODIFIED ThongKe button action ***
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtLuoi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách để xem thống kê.", "Chưa Chọn Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dtLuoi.SelectedRows[0];
            object maNvValue = selectedRow.Cells["MaNVCol"].Value;
            object hoTenValue = selectedRow.Cells["HoTenCol"].Value; // Get employee name for display

            if (maNvValue == DBNull.Value || maNvValue == null)
            {
                MessageBox.Show("Không thể xác định Mã Nhân Viên của dòng đã chọn.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maNV = Convert.ToInt32(maNvValue);
            string hoTenNV = hoTenValue?.ToString() ?? "Không rõ"; // Handle null HoTen

            try
            {
                // Query to count working days (TrangThai = 'Có mặt')
                string sql = "SELECT COUNT(*) FROM ChamCong WHERE MaNV = @MaNV AND TrangThai = N'Có mặt'";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaNV", SqlDbType.Int) { Value = maNV }
                };

                // Assuming DatabaseConnection has an ExecuteScalar method
                object result = DatabaseConnection.ExecuteScalar(sql, parameters);

                int soNgayLam = 0;
                if (result != null && result != DBNull.Value)
                {
                    soNgayLam = Convert.ToInt32(result);
                }

                MessageBox.Show($"Nhân viên: {hoTenNV} (Mã NV: {maNV})\nĐã làm việc: {soNgayLam} ngày.",
                                "Thống Kê Ngày Làm Việc", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu thống kê: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}