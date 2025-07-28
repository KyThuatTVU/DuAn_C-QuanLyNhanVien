using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhanSu
{
    public partial class DangNhap : Form
    {
        private string connectionString = @"Server=LAPTOP-33ML5D4P\SQLEXPRESS;Database=LTUD_QLNS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public DangNhap()
        {
            InitializeComponent();

            if (this.Controls.Find("txtPassword", true).FirstOrDefault() is TextBox pwdBox)
            {
                pwdBox.PasswordChar = '*';
            }

            if (this.Controls.Find("btnDangNhap", true).FirstOrDefault() == null)
            {
                MessageBox.Show("Nút Đăng nhập (btnLogin) không được tìm thấy!", "Lỗi Giao Diện", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.Controls.Find("txtUsername", true).FirstOrDefault() == null || this.Controls.Find("txtPassword", true).FirstOrDefault() == null)
            {
                MessageBox.Show("Textbox Tên đăng nhập hoặc Mật khẩu không được tìm thấy!", "Lỗi Giao Diện", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDatabaseName(string connString)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connString);
                return builder.InitialCatalog;
            }
            catch
            {
                return "[Không xác định]";
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TextBox txtUsername = this.Controls.Find("txtUsername", true).FirstOrDefault() as TextBox;
            TextBox txtPassword = this.Controls.Find("txtPassword", true).FirstOrDefault() as TextBox;

            if (txtUsername == null || txtPassword == null)
            {
                MessageBox.Show("Không tìm thấy ô nhập liệu tên đăng nhập hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = txtUsername.Text.Trim(); // Get username here
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // It's better practice to select both username and quyen if login is successful
                    // Although just selecting quyen works for the current logic
                    string query = "SELECT quyen FROM dangnhap WHERE Taikhoan = @Username AND MatKhau = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username); // Use the variable
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int quyen = Convert.ToInt32(result);

                            if (quyen == 1) // Admin login
                            {
                                MessageBox.Show($"Đăng nhập thành công với quyền Admin!\nXin chào {username}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // *** MODIFICATION HERE ***
                                // Create QuanTri form, passing the logged-in username
                                QuanTri quanTriForm = new QuanTri(username);
                                quanTriForm.Show();

                                // Ẩn form đăng nhập
                                this.Hide();
                            }
                            else if (quyen == 2) // User login
                            {
                                MessageBox.Show($"Đăng nhập thành công với quyền User!\nXin chào {username}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Add logic here if you need to open a different form for Users
                                // For now, maybe just close the login form or keep it open
                                // Application.Exit(); // Or this.Close(); Or open a User form
                            }
                            else
                            {
                                MessageBox.Show("Quyền người dùng không xác định.", "Lỗi Quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtUsername.Focus();
                            txtUsername.SelectAll();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi CSDL hoặc Kết nối: {ex.Message}\n\nVui lòng kiểm tra:\n1. Chuỗi kết nối.\n2. SQL Server đang chạy.\n3. Quyền truy cập vào Database '{GetDatabaseName(connectionString)}'.", "Lỗi Kết Nối/CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi không mong muốn: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


    }
}