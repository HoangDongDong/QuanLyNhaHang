namespace QuanLyNhaHang
{
    partial class FormLogin
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
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.lblDbTitle = new System.Windows.Forms.LinkLabel();
            this.lblDbName = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSeparator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picBanner
            // 
            this.picBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBanner.ImageLocation = @"d:\QuanLyNhaHang\QuanLyNhaHang\Resources\banner.jpg";
            this.picBanner.Location = new System.Drawing.Point(0, 0);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(430, 95);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBanner.TabIndex = 0;
            this.picBanner.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.ImageLocation = @"d:\QuanLyNhaHang\QuanLyNhaHang\Resources\logo.jpg";
            this.picLogo.Location = new System.Drawing.Point(20, 115);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(135, 125);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(89, 17);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Người dùng:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(230, 122);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(180, 24);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "admin";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(135, 160);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 17);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(230, 157);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(180, 24);
            this.txtPassword.TabIndex = 5;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Checked = true;
            this.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemember.Location = new System.Drawing.Point(230, 192);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(122, 19);
            this.chkRemember.TabIndex = 6;
            this.chkRemember.Text = "Ghi nhớ mật khẩu";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.Checked = true;
            this.chkAutoLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoLogin.Location = new System.Drawing.Point(230, 218);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(125, 19);
            this.chkAutoLogin.TabIndex = 7;
            this.chkAutoLogin.Text = "Tự động đăng nhập";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            // 
            // lblDbTitle
            // 
            this.lblDbTitle.AutoSize = true;
            this.lblDbTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbTitle.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(204)))));
            this.lblDbTitle.Location = new System.Drawing.Point(20, 252);
            this.lblDbTitle.Name = "lblDbTitle";
            this.lblDbTitle.Size = new System.Drawing.Size(79, 15);
            this.lblDbTitle.TabIndex = 8;
            this.lblDbTitle.TabStop = true;
            this.lblDbTitle.Text = "Cơ sở dữ liệu:";
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbName.ForeColor = System.Drawing.Color.Black;
            this.lblDbName.Location = new System.Drawing.Point(105, 252);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(43, 15);
            this.lblDbName.TabIndex = 9;
            this.lblDbName.Text = "DEMO";
            // 
            // lblSeparator
            // 
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator.Location = new System.Drawing.Point(20, 278);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(390, 2);
            this.lblSeparator.TabIndex = 10;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(250, 292);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 28);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(335, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(430, 332);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.lblDbName);
            this.Controls.Add(this.lblDbTitle);
            this.Controls.Add(this.chkAutoLogin);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.CheckBox chkAutoLogin;
        private System.Windows.Forms.LinkLabel lblDbTitle;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
    }
}
