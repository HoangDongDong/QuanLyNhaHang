namespace QuanLyNhaHang
{
    partial class FormPhantichkiemke
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
            this.btnDong = new System.Windows.Forms.Button();
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.tvNhom = new System.Windows.Forms.Control();
            this.grMatHang = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(591, 457);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(504, 416);
            this.btnDong.Size = new System.Drawing.Size(75, 29);
            this.btnDong.Text = "Đóng";
            this.btnDong.Name = "btnDong";
            this.btnDong.TabIndex = 0;
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(585, 407);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 1;
            // tvNhom
            // 
            this.tvNhom.Location = new System.Drawing.Point(0, 0);
            this.tvNhom.Size = new System.Drawing.Size(195, 407);
            this.tvNhom.Name = "tvNhom";
            this.tvNhom.TabIndex = 0;
            this.tvNhom.ReadOnly = true;
            // grMatHang
            // 
            this.grMatHang.Location = new System.Drawing.Point(0, 0);
            this.grMatHang.Size = new System.Drawing.Size(385, 407);
            this.grMatHang.Name = "grMatHang";
            this.grMatHang.TabIndex = 0;
            // 
            // FormPhantichkiemke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 457);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.tvNhom);
            this.Controls.Add(this.grMatHang);
            this.Name = "FormPhantichkiemke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân tích kiểm kê";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnDong;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Control tvNhom;
        public System.Windows.Forms.Control grMatHang;
    }
}