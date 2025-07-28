using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class QuanTri : Form
    {
        private string loggedInUsername;

        // Constructor mặc định cũng phải khởi tạo giao diện
        public QuanTri()
        {
            InitializeComponent();
        }

        // Constructor chính thức nhận username
        public QuanTri(string username) : this()  // ": this()" để gọi luôn constructor mặc định
        {
            this.loggedInUsername = username;

            // Cập nhật label khi form đã khởi tạo xong
            var lblUserInfo = this.Controls.Find("label5", true).FirstOrDefault() as Label;
            if (lblUserInfo != null)
            {
                lblUserInfo.Text = $"Xin chào: {this.loggedInUsername}";
            }
        }

        private void QuanTri_Load(object sender, EventArgs e)
        {
            // Nếu cần khởi động thêm gì khi load form thì thêm ở đây
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                this.Hide();
                new DangNhap().Show();
            }
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            new PhongBan().Show();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            new ChamCong().Show();
        }
    }
}
