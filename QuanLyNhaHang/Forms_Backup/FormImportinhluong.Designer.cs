namespace QuanLyNhaHang
{
    partial class FormImportinhluong
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prMain = new System.Windows.Forms.Control();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.tvMain = new System.Windows.Forms.Control();
            this.colMatHang = new System.Windows.Forms.TextBox();
            this.colDonViTinh2 = new System.Windows.Forms.TextBox();
            this.colNguyenLieu = new System.Windows.Forms.TextBox();
            this.colDonViTinh = new System.Windows.Forms.TextBox();
            this.colSoLuong = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 463);
            this.KryptonPanel1.Size = new System.Drawing.Size(902, 41);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(701, 3);
            this.btnOK.Size = new System.Drawing.Size(96, 33);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(803, 3);
            this.btnHuyBo.Size = new System.Drawing.Size(96, 33);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.TabIndex = 4;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(902, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 6;
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabIndex = 2;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.Text = "Cập nhật định lượng từ excel";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // prMain
            // 
            this.prMain.Location = new System.Drawing.Point(12, 9);
            this.prMain.Size = new System.Drawing.Size(367, 23);
            this.prMain.Name = "prMain";
            this.prMain.TabIndex = 7;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Size = new System.Drawing.Size(620, 424);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 7;
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 39);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(902, 424);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 8;
            // tvMain
            // 
            this.tvMain.Location = new System.Drawing.Point(0, 0);
            this.tvMain.Size = new System.Drawing.Size(277, 424);
            this.tvMain.Name = "tvMain";
            this.tvMain.TabIndex = 8;
            this.tvMain.ReadOnly = true;
            // colMatHang
            // 
            this.colMatHang.Name = "colMatHang";
            this.colMatHang.ReadOnly = true;
            // colDonViTinh2
            // 
            this.colDonViTinh2.Name = "colDonViTinh2";
            this.colDonViTinh2.ReadOnly = true;
            // colNguyenLieu
            // 
            this.colNguyenLieu.Name = "colNguyenLieu";
            this.colNguyenLieu.ReadOnly = true;
            // colDonViTinh
            // 
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            // colSoLuong
            // 
            this.colSoLuong.Name = "colSoLuong";
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(391, 9);
            this.lblStatus.Size = new System.Drawing.Size(304, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TabIndex = 8;
            // 
            // FormImportinhluong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 504);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prMain);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.tvMain);
            this.Controls.Add(this.colMatHang);
            this.Controls.Add(this.colDonViTinh2);
            this.Controls.Add(this.colNguyenLieu);
            this.Controls.Add(this.colDonViTinh);
            this.Controls.Add(this.colSoLuong);
            this.Controls.Add(this.lblStatus);
            this.Name = "FormImportinhluong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import định lượng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnHuyBo;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Control prMain;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Control tvMain;
        public System.Windows.Forms.TextBox colMatHang;
        public System.Windows.Forms.TextBox colDonViTinh2;
        public System.Windows.Forms.TextBox colNguyenLieu;
        public System.Windows.Forms.TextBox colDonViTinh;
        public System.Windows.Forms.DataGridView colSoLuong;
        public System.Windows.Forms.Label lblStatus;
    }
}