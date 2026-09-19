namespace QuanLyNhaHang
{
    partial class FormTrutichluy
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
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.numDiem = new System.Windows.Forms.NumericUpDown();
            this.numGiaTri = new System.Windows.Forms.NumericUpDown();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(384, 219);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(174, 163);
            this.btnOK.Size = new System.Drawing.Size(96, 33);
            this.btnOK.Text = "Sử dụng";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(276, 163);
            this.btnHuyBo.Size = new System.Drawing.Size(96, 33);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.TabIndex = 4;
            // lblKhachHang
            // 
            this.lblKhachHang.Location = new System.Drawing.Point(12, 9);
            this.lblKhachHang.Size = new System.Drawing.Size(360, 54);
            this.lblKhachHang.Text = "KHÁCH HÀNG";
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.TabIndex = 5;
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(12, 72);
            this.Label2.Size = new System.Drawing.Size(140, 20);
            this.Label2.Text = "ĐIỂM TÍCH LŨY";
            this.Label2.Name = "Label2";
            this.Label2.TabIndex = 6;
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(12, 119);
            this.Label3.Size = new System.Drawing.Size(155, 20);
            this.Label3.Text = "QUY ĐỔI GIÁ TRỊ";
            this.Label3.Name = "Label3";
            this.Label3.TabIndex = 7;
            // numDiem
            // 
            this.numDiem.Location = new System.Drawing.Point(229, 66);
            this.numDiem.Size = new System.Drawing.Size(143, 31);
            this.numDiem.Name = "numDiem";
            this.numDiem.TabIndex = 8;
            this.numDiem.ReadOnly = true;
            // numGiaTri
            // 
            this.numGiaTri.Location = new System.Drawing.Point(229, 113);
            this.numGiaTri.Size = new System.Drawing.Size(143, 31);
            this.numGiaTri.Name = "numGiaTri";
            this.numGiaTri.TabIndex = 9;
            this.numGiaTri.ReadOnly = true;
            // 
            // FormTrutichluy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 219);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.lblKhachHang);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.numDiem);
            this.Controls.Add(this.numGiaTri);
            this.Name = "FormTrutichluy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trừ tích lũy";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnHuyBo;
        public System.Windows.Forms.Label lblKhachHang;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.NumericUpDown numDiem;
        public System.Windows.Forms.NumericUpDown numGiaTri;
    }
}