namespace QuanLyNhaHang
{
    partial class FormNhapmatkhaugiamo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(367, 189);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(367, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 7;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Size = new System.Drawing.Size(326, 13);
            this.label2.Text = "BẠN KHÔNG CÓ QUYỀN THỰC HIỆN CHỨC NĂNG NÀY";
            this.label2.Name = "label2";
            this.label2.TabIndex = 1;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 57);
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.Text = "Mời bạn nhập mật khẩu để tiếp tục";
            this.label1.Name = "label1";
            this.label1.TabIndex = 14;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(192, 147);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 12;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(273, 147);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 13;
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(28, 73);
            this.txtPass.Size = new System.Drawing.Size(312, 20);
            this.txtPass.Name = "txtPass";
            this.txtPass.TabIndex = 11;
            // 
            // FormNhapmatkhaugiamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 189);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPass);
            this.Name = "FormNhapmatkhaugiamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập mật khẩu giảm đồ";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtPass;
    }
}