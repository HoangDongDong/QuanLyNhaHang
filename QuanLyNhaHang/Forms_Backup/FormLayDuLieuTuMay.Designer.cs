namespace QuanLyNhaHang
{
    partial class FormLaydulieutumay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.KryptonPanel1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.prMain = new System.Windows.Forms.Control();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.chkXoaDuLieuCu = new System.Windows.Forms.CheckBox();
            this.chkXoaSauKhiThucHien = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.tvMain = new System.Windows.Forms.Control();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.Control();
            this.colNhanVien = new System.Windows.Forms.TextBox();
            this.colGioVao = new System.Windows.Forms.Control();
            this.colGioRa = new System.Windows.Forms.Control();
            this.colSoLanQuet = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 42);
            this.KryptonPanel1.Size = new System.Drawing.Size(796, 39);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(796, 42);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 7;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(532, 25);
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.Text = "Giờ ra: giờ xác nhận cuối cùng";
            this.label2.Name = "label2";
            this.label2.TabIndex = 6;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(532, 7);
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.Text = "Giờ vào: giờ xác nhận đầu tiên";
            this.label1.Name = "label1";
            this.label1.TabIndex = 5;
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(44, 15);
            this.lblTitle.Size = new System.Drawing.Size(176, 13);
            this.lblTitle.Text = "Lấy dữ liệu từ máy chấm công";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 4;
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Size = new System.Drawing.Size(32, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabIndex = 3;
            // prMain
            // 
            this.prMain.Location = new System.Drawing.Point(344, 10);
            this.prMain.Size = new System.Drawing.Size(449, 17);
            this.prMain.Name = "prMain";
            this.prMain.TabIndex = 15;
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.Text = "IP Máy chấm công:";
            this.label3.Name = "label3";
            this.label3.TabIndex = 17;
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(114, 9);
            this.txtIP.Size = new System.Drawing.Size(88, 20);
            this.txtIP.Text = "192.168.1.201";
            this.txtIP.Name = "txtIP";
            this.txtIP.TabIndex = 16;
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(208, 3);
            this.btnThucHien.Size = new System.Drawing.Size(130, 30);
            this.btnThucHien.Text = "Thực hiện lấy dữ liệu";
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.TabIndex = 14;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 429);
            this.KryptonPanel2.Size = new System.Drawing.Size(796, 63);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 8;
            // chkXoaDuLieuCu
            // 
            this.chkXoaDuLieuCu.Location = new System.Drawing.Point(9, 12);
            this.chkXoaDuLieuCu.Size = new System.Drawing.Size(305, 17);
            this.chkXoaDuLieuCu.Text = "Xóa dữ liệu vào ra đã thực hiện các lần trước ở bảng lương";
            this.chkXoaDuLieuCu.Name = "chkXoaDuLieuCu";
            this.chkXoaDuLieuCu.TabIndex = 16;
            // chkXoaSauKhiThucHien
            // 
            this.chkXoaSauKhiThucHien.Location = new System.Drawing.Point(9, 35);
            this.chkXoaSauKhiThucHien.Size = new System.Drawing.Size(262, 17);
            this.chkXoaSauKhiThucHien.Text = "Xóa dữ liệu trên máy chấm công sau khi thực hiện";
            this.chkXoaSauKhiThucHien.Name = "chkXoaSauKhiThucHien";
            this.chkXoaSauKhiThucHien.TabIndex = 15;
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(628, 21);
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 13;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(709, 21);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 14;
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 81);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(796, 348);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 9;
            // tvMain
            // 
            this.tvMain.Location = new System.Drawing.Point(0, 0);
            this.tvMain.Size = new System.Drawing.Size(231, 348);
            this.tvMain.Name = "tvMain";
            this.tvMain.TabIndex = 0;
            this.tvMain.ReadOnly = false;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Size = new System.Drawing.Size(560, 348);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 0;
            this.grMain.ReadOnly = true;
            // colNgay
            // 
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            // colNhanVien
            // 
            this.colNhanVien.Name = "colNhanVien";
            this.colNhanVien.ReadOnly = true;
            // colGioVao
            // 
            this.colGioVao.Name = "colGioVao";
            this.colGioVao.ReadOnly = true;
            // colGioRa
            // 
            this.colGioRa.Name = "colGioRa";
            this.colGioRa.ReadOnly = true;
            // colSoLanQuet
            // 
            this.colSoLanQuet.Name = "colSoLanQuet";
            this.colSoLanQuet.ReadOnly = true;
            // 
            // FormLaydulieutumay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 492);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.prMain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.chkXoaDuLieuCu);
            this.Controls.Add(this.chkXoaSauKhiThucHien);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.tvMain);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.colNgay);
            this.Controls.Add(this.colNhanVien);
            this.Controls.Add(this.colGioVao);
            this.Controls.Add(this.colGioRa);
            this.Controls.Add(this.colSoLanQuet);
            this.Name = "FormLaydulieutumay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lấy dữ liệu từ máy";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Control prMain;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtIP;
        public System.Windows.Forms.Button btnThucHien;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.CheckBox chkXoaDuLieuCu;
        public System.Windows.Forms.CheckBox chkXoaSauKhiThucHien;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Control tvMain;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Control colNgay;
        public System.Windows.Forms.TextBox colNhanVien;
        public System.Windows.Forms.Control colGioVao;
        public System.Windows.Forms.Control colGioRa;
        public System.Windows.Forms.DataGridView colSoLanQuet;
    }
}