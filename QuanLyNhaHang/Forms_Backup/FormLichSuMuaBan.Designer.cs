namespace QuanLyNhaHang
{
    partial class FormLichsumuaban
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.colNgay = new System.Windows.Forms.Control();
            this.colGio = new System.Windows.Forms.TextBox();
            this.colKhachHang = new System.Windows.Forms.TextBox();
            this.colDonGia = new System.Windows.Forms.DataGridView();
            this.Label2147483646 = new System.Windows.Forms.Label();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(526, 440);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(3, 59);
            this.grMain.Size = new System.Drawing.Size(518, 344);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 1;
            this.grMain.ReadOnly = true;
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(446, 407);
            this.btnThoat.Size = new System.Drawing.Size(75, 28);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.TabIndex = 2;
            // lblTenHang
            // 
            this.lblTenHang.Location = new System.Drawing.Point(3, 7);
            this.lblTenHang.Size = new System.Drawing.Size(518, 23);
            this.lblTenHang.Text = "Tên mặt hàng:";
            this.lblTenHang.Name = "lblTenHang";
            this.lblTenHang.TabIndex = 2;
            // colNgay
            // 
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            // colGio
            // 
            this.colGio.Name = "colGio";
            this.colGio.ReadOnly = true;
            // colKhachHang
            // 
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.ReadOnly = true;
            // colDonGia
            // 
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // Label2147483646
            // 
            this.Label2147483646.Location = new System.Drawing.Point(3, 36);
            this.Label2147483646.Size = new System.Drawing.Size(62, 13);
            this.Label2147483646.Text = "Lọc dữ liệu:";
            this.Label2147483646.Name = "Label2147483646";
            this.Label2147483646.TabIndex = 3;
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(71, 33);
            this.txtLoc.Size = new System.Drawing.Size(100, 20);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.TabIndex = 0;
            // 
            // FormLichsumuaban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 440);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblTenHang);
            this.Controls.Add(this.colNgay);
            this.Controls.Add(this.colGio);
            this.Controls.Add(this.colKhachHang);
            this.Controls.Add(this.colDonGia);
            this.Controls.Add(this.Label2147483646);
            this.Controls.Add(this.txtLoc);
            this.Name = "FormLichsumuaban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử mua bán";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Label lblTenHang;
        public System.Windows.Forms.Control colNgay;
        public System.Windows.Forms.TextBox colGio;
        public System.Windows.Forms.TextBox colKhachHang;
        public System.Windows.Forms.DataGridView colDonGia;
        public System.Windows.Forms.Label Label2147483646;
        public System.Windows.Forms.TextBox txtLoc;
    }
}