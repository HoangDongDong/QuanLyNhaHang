namespace QuanLyNhaHang
{
    partial class FormMathangkhuyenmai
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
            this.grMain = new System.Windows.Forms.DataGridView();
            this.lblChuongTrinhKM = new System.Windows.Forms.Label();
            this.colMaHang = new System.Windows.Forms.TextBox();
            this.colTenHang = new System.Windows.Forms.TextBox();
            this.colDVT = new System.Windows.Forms.TextBox();
            this.colSoLuong = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkKhongHienThi = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(563, 296);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(3, 21);
            this.grMain.Size = new System.Drawing.Size(558, 242);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 0;
            this.grMain.ReadOnly = true;
            // lblChuongTrinhKM
            // 
            this.lblChuongTrinhKM.Location = new System.Drawing.Point(3, 5);
            this.lblChuongTrinhKM.Size = new System.Drawing.Size(164, 13);
            this.lblChuongTrinhKM.Text = "CHƯƠNG TRÌNH KHUYẾN MẠI:";
            this.lblChuongTrinhKM.Name = "lblChuongTrinhKM";
            this.lblChuongTrinhKM.TabIndex = 1;
            // colMaHang
            // 
            this.colMaHang.Name = "colMaHang";
            this.colMaHang.ReadOnly = true;
            // colTenHang
            // 
            this.colTenHang.Name = "colTenHang";
            this.colTenHang.ReadOnly = true;
            // colDVT
            // 
            this.colDVT.Name = "colDVT";
            this.colDVT.ReadOnly = true;
            // colSoLuong
            // 
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(404, 266);
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.Text = "Tiếp tục";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 2;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(485, 266);
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 3;
            // chkKhongHienThi
            // 
            this.chkKhongHienThi.Location = new System.Drawing.Point(13, 270);
            this.chkKhongHienThi.Size = new System.Drawing.Size(131, 17);
            this.chkKhongHienThi.Text = "Không hiển thị lần sau";
            this.chkKhongHienThi.Name = "chkKhongHienThi";
            this.chkKhongHienThi.TabIndex = 4;
            // 
            // FormMathangkhuyenmai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 296);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.lblChuongTrinhKM);
            this.Controls.Add(this.colMaHang);
            this.Controls.Add(this.colTenHang);
            this.Controls.Add(this.colDVT);
            this.Controls.Add(this.colSoLuong);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkKhongHienThi);
            this.Name = "FormMathangkhuyenmai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mặt hàng khuyến mại";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Label lblChuongTrinhKM;
        public System.Windows.Forms.TextBox colMaHang;
        public System.Windows.Forms.TextBox colTenHang;
        public System.Windows.Forms.TextBox colDVT;
        public System.Windows.Forms.DataGridView colSoLuong;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.CheckBox chkKhongHienThi;
    }
}