namespace QuanLyNhaHang
{
    partial class FormNhapthetratruoc
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
            this.txtMa = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(384, 145);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(56, 46);
            this.txtMa.Size = new System.Drawing.Size(304, 26);
            this.txtMa.Name = "txtMa";
            this.txtMa.TabIndex = 0;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(25, 20);
            this.Label1.Size = new System.Drawing.Size(48, 13);
            this.Label1.Text = "MÃ THẺ";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 6;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(162, 97);
            this.btnOK.Size = new System.Drawing.Size(96, 33);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(264, 97);
            this.btnHuyBo.Size = new System.Drawing.Size(96, 33);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.TabIndex = 2;
            // 
            // FormNhapthetratruoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 145);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHuyBo);
            this.Name = "FormNhapthetratruoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thẻ trả trước";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.TextBox txtMa;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnHuyBo;
    }
}