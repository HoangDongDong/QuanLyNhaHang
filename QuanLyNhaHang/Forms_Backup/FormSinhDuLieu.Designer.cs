namespace QuanLyNhaHang
{
    partial class FormSinhdulieu
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
            this.No1UserControl1 = new System.Windows.Forms.Control();
            this.KryptonPanel1 = new System.Windows.Forms.Panel();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.prMain = new System.Windows.Forms.Control();
            this.dtNgay = new System.Windows.Forms.Control();
            this.Label1 = new System.Windows.Forms.Label();
            this.numSoHoaDon = new System.Windows.Forms.NumericUpDown();
            this.numSoPhieuChi = new System.Windows.Forms.NumericUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.numSoPhieuNhapXuat = new System.Windows.Forms.NumericUpDown();
            this.Label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(400, 181);
            this.No1UserControl1.Name = "No1UserControl1";
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(400, 181);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(5, 114);
            this.btnThucHien.Size = new System.Drawing.Size(99, 30);
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.TabIndex = 0;
            // prMain
            // 
            this.prMain.Location = new System.Drawing.Point(5, 150);
            this.prMain.Size = new System.Drawing.Size(271, 23);
            this.prMain.Name = "prMain";
            this.prMain.TabIndex = 1;
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(3, 3);
            this.dtNgay.Size = new System.Drawing.Size(271, 24);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.TabIndex = 2;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(5, 34);
            this.Label1.Size = new System.Drawing.Size(97, 13);
            this.Label1.Text = "Số hóa đơn / ngày";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 3;
            // numSoHoaDon
            // 
            this.numSoHoaDon.Location = new System.Drawing.Point(154, 32);
            this.numSoHoaDon.Size = new System.Drawing.Size(120, 20);
            this.numSoHoaDon.Name = "numSoHoaDon";
            this.numSoHoaDon.TabIndex = 4;
            // numSoPhieuChi
            // 
            this.numSoPhieuChi.Location = new System.Drawing.Point(155, 58);
            this.numSoPhieuChi.Size = new System.Drawing.Size(120, 20);
            this.numSoPhieuChi.Name = "numSoPhieuChi";
            this.numSoPhieuChi.TabIndex = 6;
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(5, 61);
            this.Label2.Size = new System.Drawing.Size(87, 13);
            this.Label2.Text = "Số phiếu thu, chi";
            this.Label2.Name = "Label2";
            this.Label2.TabIndex = 5;
            // numSoPhieuNhapXuat
            // 
            this.numSoPhieuNhapXuat.Location = new System.Drawing.Point(155, 84);
            this.numSoPhieuNhapXuat.Size = new System.Drawing.Size(120, 20);
            this.numSoPhieuNhapXuat.Name = "numSoPhieuNhapXuat";
            this.numSoPhieuNhapXuat.TabIndex = 8;
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(5, 87);
            this.Label3.Size = new System.Drawing.Size(102, 13);
            this.Label3.Text = "Số phiếu nhập, xuất";
            this.Label3.Name = "Label3";
            this.Label3.TabIndex = 7;
            // 
            // FormSinhdulieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.prMain);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.numSoHoaDon);
            this.Controls.Add(this.numSoPhieuChi);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.numSoPhieuNhapXuat);
            this.Controls.Add(this.Label3);
            this.Name = "FormSinhdulieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sinh dữ liệu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnThucHien;
        public System.Windows.Forms.Control prMain;
        public System.Windows.Forms.Control dtNgay;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.NumericUpDown numSoHoaDon;
        public System.Windows.Forms.NumericUpDown numSoPhieuChi;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.NumericUpDown numSoPhieuNhapXuat;
        public System.Windows.Forms.Label Label3;
    }
}