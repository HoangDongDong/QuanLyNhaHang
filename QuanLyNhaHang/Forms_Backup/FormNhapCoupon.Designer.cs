namespace QuanLyNhaHang
{
    partial class FormNhapcoupon
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
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(382, 141);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(263, 95);
            this.btnHuyBo.Size = new System.Drawing.Size(96, 33);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.TabIndex = 2;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(161, 95);
            this.btnOK.Size = new System.Drawing.Size(96, 33);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 13);
            this.Label1.Size = new System.Drawing.Size(79, 13);
            this.Label1.Text = "MÃ VOUCHER";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 2;
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(43, 44);
            this.txtMa.Size = new System.Drawing.Size(304, 26);
            this.txtMa.Name = "txtMa";
            this.txtMa.TabIndex = 0;
            // 
            // FormNhapcoupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 141);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtMa);
            this.Name = "FormNhapcoupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập coupon";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnHuyBo;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox txtMa;
    }
}