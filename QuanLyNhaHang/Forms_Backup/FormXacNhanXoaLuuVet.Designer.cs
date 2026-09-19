namespace QuanLyNhaHang
{
    partial class FormXacnhanxoaluuvet
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
            this.btnChapNhan = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(340, 115);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(233, 75);
            this.btnHuyBo.Size = new System.Drawing.Size(95, 28);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.TabIndex = 2;
            // btnChapNhan
            // 
            this.btnChapNhan.Location = new System.Drawing.Point(132, 75);
            this.btnChapNhan.Size = new System.Drawing.Size(95, 28);
            this.btnChapNhan.Text = "Chấp nhận";
            this.btnChapNhan.Name = "btnChapNhan";
            this.btnChapNhan.TabIndex = 1;
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(94, 12);
            this.txtMatKhau.Size = new System.Drawing.Size(207, 20);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.TabIndex = 0;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(20, 15);
            this.Label1.Size = new System.Drawing.Size(52, 13);
            this.Label1.Text = "Mật khẩu";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 3;
            // 
            // FormXacnhanxoaluuvet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 115);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnChapNhan);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.Label1);
            this.Name = "FormXacnhanxoaluuvet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận xóa lưu vết";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnHuyBo;
        public System.Windows.Forms.Button btnChapNhan;
        public System.Windows.Forms.TextBox txtMatKhau;
        public System.Windows.Forms.Label Label1;
    }
}