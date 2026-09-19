namespace QuanLyNhaHang
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.lblBannerTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkRememberPassword = new System.Windows.Forms.CheckBox();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.lblDbTitle = new System.Windows.Forms.Label();
            this.lblDbValue = new System.Windows.Forms.Label();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picBanner
            // 
            this.picBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBanner.Location = new System.Drawing.Point(0, 0);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(475, 88);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBanner.TabIndex = 0;
            this.picBanner.TabStop = false;
            // 
            // lblBannerTitle
            // 
            this.lblBannerTitle.AutoSize = true;
            this.lblBannerTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBannerTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBannerTitle.ForeColor = System.Drawing.Color.White;
            this.lblBannerTitle.Location = new System.Drawing.Point(14, 28);
            this.lblBannerTitle.Name = "lblBannerTitle";
            this.lblBannerTitle.Size = new System.Drawing.Size(306, 25);
            this.lblBannerTitle.TabIndex = 1;
            this.lblBannerTitle.Text = "PHẦN MỀM QUẢN LÝ NHÀ HÀNG";
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(22, 98);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(125, 80);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(158, 114);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(87, 17);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Người dùng:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(173, 146);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 17);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(248, 111);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(196, 24);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Text = "admin";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(248, 143);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(196, 24);
            this.txtPassword.TabIndex = 6;
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.AutoSize = true;
            this.chkRememberPassword.Checked = true;
            this.chkRememberPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRememberPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRememberPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.chkRememberPassword.Location = new System.Drawing.Point(248, 175);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(123, 19);
            this.chkRememberPassword.TabIndex = 7;
            this.chkRememberPassword.Text = "Ghi nhớ mật khẩu";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.Checked = true;
            this.chkAutoLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.chkAutoLogin.Location = new System.Drawing.Point(248, 198);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(126, 19);
            this.chkAutoLogin.TabIndex = 8;
            this.chkAutoLogin.Text = "Tự động đăng nhập";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            // 
            // lblDbTitle
            // 
            this.lblDbTitle.AutoSize = true;
            this.lblDbTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDbTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.lblDbTitle.Location = new System.Drawing.Point(20, 195);
            this.lblDbTitle.Name = "lblDbTitle";
            this.lblDbTitle.Size = new System.Drawing.Size(78, 15);
            this.lblDbTitle.TabIndex = 9;
            this.lblDbTitle.Text = "Cơ sở dữ liệu:";
            // 
            // lblDbValue
            // 
            this.lblDbValue.AutoSize = true;
            this.lblDbValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDbValue.Location = new System.Drawing.Point(104, 195);
            this.lblDbValue.Name = "lblDbValue";
            this.lblDbValue.Size = new System.Drawing.Size(42, 15);
            this.lblDbValue.TabIndex = 10;
            this.lblDbValue.Text = "DEMO";
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(205)))), ((int)(((byte)(235)))));
            this.pnlSeparator.Location = new System.Drawing.Point(21, 230);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(432, 1);
            this.pnlSeparator.TabIndex = 11;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(268, 246);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 28);
            this.btnLogin.TabIndex = 12;
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
            this.btnCancel.Location = new System.Drawing.Point(358, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(475, 290);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.lblDbValue);
            this.Controls.Add(this.lblDbTitle);
            this.Controls.Add(this.chkAutoLogin);
            this.Controls.Add(this.chkRememberPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblBannerTitle);
            this.Controls.Add(this.picBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.Label lblBannerTitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.CheckBox chkAutoLogin;
        private System.Windows.Forms.Label lblDbTitle;
        private System.Windows.Forms.Label lblDbValue;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;

    }
}

