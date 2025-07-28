namespace QuanLyNhanSu
{
    partial class PhongBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhongBan));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttenPhong = new System.Windows.Forms.TextBox();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtLuoi = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.imageList6 = new System.Windows.Forms.ImageList(this.components);
            this.btnXoa = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnLuu = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.btnSua = new System.Windows.Forms.Button();
            this.imageList4 = new System.Windows.Forms.ImageList(this.components);
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.imageList5 = new System.Windows.Forms.ImageList(this.components);
            this.btnThem = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList7 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtLuoi)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(473, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ PHÒNG BAN ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttenPhong);
            this.groupBox1.Controls.Add(this.txtMaPhong);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 170);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txttenPhong
            // 
            this.txttenPhong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenPhong.Location = new System.Drawing.Point(142, 109);
            this.txttenPhong.Name = "txttenPhong";
            this.txttenPhong.Size = new System.Drawing.Size(347, 34);
            this.txttenPhong.TabIndex = 3;
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhong.Location = new System.Drawing.Point(142, 43);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(347, 34);
            this.txtMaPhong.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên Phòng ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Phòng ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Controls.Add(this.dtLuoi);
            this.groupBox2.Location = new System.Drawing.Point(339, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 271);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dtLuoi
            // 
            this.dtLuoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtLuoi.Location = new System.Drawing.Point(18, 14);
            this.dtLuoi.Name = "dtLuoi";
            this.dtLuoi.RowHeadersWidth = 51;
            this.dtLuoi.RowTemplate.Height = 24;
            this.dtLuoi.Size = new System.Drawing.Size(605, 245);
            this.dtLuoi.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTimKiem);
            this.groupBox3.Controls.Add(this.btnTimKiem);
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.btnCapNhat);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Location = new System.Drawing.Point(507, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(813, 170);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(6, 130);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(245, 34);
            this.txtTimKiem.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.ImageKey = "timkiem.jpg";
            this.btnTimKiem.ImageList = this.imageList6;
            this.btnTimKiem.Location = new System.Drawing.Point(282, 114);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(159, 50);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm ";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // imageList6
            // 
            this.imageList6.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList6.ImageStream")));
            this.imageList6.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList6.Images.SetKeyName(0, "chamcong.jpg");
            this.imageList6.Images.SetKeyName(1, "them.jpg");
            this.imageList6.Images.SetKeyName(2, "them.jpg");
            this.imageList6.Images.SetKeyName(3, "tim kiem.jpg");
            this.imageList6.Images.SetKeyName(4, "timkiem.jpg");
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.ImageKey = "dl.png";
            this.btnXoa.ImageList = this.imageList2;
            this.btnXoa.Location = new System.Drawing.Point(161, 27);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(155, 45);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "chamcong.jpg");
            this.imageList2.Images.SetKeyName(1, "them.jpg");
            this.imageList2.Images.SetKeyName(2, "them.jpg");
            this.imageList2.Images.SetKeyName(3, "dl.png");
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.ImageKey = "luu.jpg";
            this.btnLuu.ImageList = this.imageList3;
            this.btnLuu.Location = new System.Drawing.Point(480, 27);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(155, 45);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "chamcong.jpg");
            this.imageList3.Images.SetKeyName(1, "them.jpg");
            this.imageList3.Images.SetKeyName(2, "them.jpg");
            this.imageList3.Images.SetKeyName(3, "luu.jpg");
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.ImageKey = "sua.jpg";
            this.btnSua.ImageList = this.imageList4;
            this.btnSua.Location = new System.Drawing.Point(319, 27);
            this.btnSua.Name = "btnSua";
            this.btnSua.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSua.Size = new System.Drawing.Size(155, 45);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "chamcong.jpg");
            this.imageList4.Images.SetKeyName(1, "them.jpg");
            this.imageList4.Images.SetKeyName(2, "them.jpg");
            this.imageList4.Images.SetKeyName(3, "sua.jpg");
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhat.ImageKey = "capnhat.jpg";
            this.btnCapNhat.ImageList = this.imageList5;
            this.btnCapNhat.Location = new System.Drawing.Point(641, 27);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(166, 45);
            this.btnCapNhat.TabIndex = 1;
            this.btnCapNhat.Text = "Cập nhật ";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // imageList5
            // 
            this.imageList5.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList5.ImageStream")));
            this.imageList5.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList5.Images.SetKeyName(0, "chamcong.jpg");
            this.imageList5.Images.SetKeyName(1, "them.jpg");
            this.imageList5.Images.SetKeyName(2, "them.jpg");
            this.imageList5.Images.SetKeyName(3, "capnhat.jpg");
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.ImageKey = "them.jpg";
            this.btnThem.ImageList = this.imageList1;
            this.btnThem.Location = new System.Drawing.Point(0, 27);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(155, 45);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "chamcong.jpg");
            this.imageList1.Images.SetKeyName(1, "them.jpg");
            this.imageList1.Images.SetKeyName(2, "them.jpg");
            // 
            // imageList7
            // 
            this.imageList7.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList7.ImageStream")));
            this.imageList7.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList7.Images.SetKeyName(0, "chamcong.jpg");
            this.imageList7.Images.SetKeyName(1, "them.jpg");
            this.imageList7.Images.SetKeyName(2, "them.jpg");
            this.imageList7.Images.SetKeyName(3, "tim kiem.jpg");
            this.imageList7.Images.SetKeyName(4, "timkiem.jpg");
            this.imageList7.Images.SetKeyName(5, "home.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyNhanSu.Properties.Resources.phongban1;
            this.pictureBox1.Location = new System.Drawing.Point(1211, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.ImageKey = "home.png";
            this.btnThoat.ImageList = this.imageList7;
            this.btnThoat.Location = new System.Drawing.Point(1120, 514);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(200, 45);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Về trang chủ ";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // PhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1332, 571);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "PhongBan";
            this.Text = "PhongBan";
            this.Load += new System.EventHandler(this.PhongBan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtLuoi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttenPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ImageList imageList4;
        private System.Windows.Forms.ImageList imageList5;
        private System.Windows.Forms.ImageList imageList6;
        private System.Windows.Forms.DataGridView dtLuoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ImageList imageList7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}