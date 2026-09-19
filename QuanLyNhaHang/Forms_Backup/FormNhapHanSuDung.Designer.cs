namespace QuanLyNhaHang
{
    partial class FormNhaphansudung
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
            this.lblSanPham = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChapNhan = new System.Windows.Forms.Button();
            this.dtHanDung = new System.Windows.Forms.Control();
            this.Label2147483646 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(425, 195);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // lblSanPham
            // 
            this.lblSanPham.Location = new System.Drawing.Point(12, 9);
            this.lblSanPham.Size = new System.Drawing.Size(401, 60);
            this.lblSanPham.Text = "SẢN PHẨM:";
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.TabIndex = 3;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(338, 156);
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 2;
            // btnChapNhan
            // 
            this.btnChapNhan.Location = new System.Drawing.Point(257, 156);
            this.btnChapNhan.Size = new System.Drawing.Size(75, 28);
            this.btnChapNhan.Text = "Chấp nhận";
            this.btnChapNhan.Name = "btnChapNhan";
            this.btnChapNhan.TabIndex = 1;
            // dtHanDung
            // 
            this.dtHanDung.Location = new System.Drawing.Point(200, 83);
            this.dtHanDung.Size = new System.Drawing.Size(132, 26);
            this.dtHanDung.Name = "dtHanDung";
            this.dtHanDung.TabIndex = 0;
            // Label2147483646
            // 
            this.Label2147483646.Location = new System.Drawing.Point(86, 85);
            this.Label2147483646.Size = new System.Drawing.Size(108, 24);
            this.Label2147483646.Text = "Han dùng:";
            this.Label2147483646.Name = "Label2147483646";
            this.Label2147483646.TabIndex = 4;
            // 
            // FormNhaphansudung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 195);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.lblSanPham);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChapNhan);
            this.Controls.Add(this.dtHanDung);
            this.Controls.Add(this.Label2147483646);
            this.Name = "FormNhaphansudung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hạn sử dụng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Label lblSanPham;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnChapNhan;
        public System.Windows.Forms.Control dtHanDung;
        public System.Windows.Forms.Label Label2147483646;
    }
}