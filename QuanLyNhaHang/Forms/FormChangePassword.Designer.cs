namespace QuanLyNhaHang
{
    partial class FormChangePassword
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
            this.picLockIcon = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblOldPass = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLockIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picLockIcon
            // 
            this.picLockIcon.Location = new System.Drawing.Point(24, 18);
            this.picLockIcon.Name = "picLockIcon";
            this.picLockIcon.Size = new System.Drawing.Size(40, 40);
            this.picLockIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLockIcon.TabIndex = 0;
            this.picLockIcon.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.Black;
            this.lblHeaderTitle.Location = new System.Drawing.Point(74, 26);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(202, 19);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Đổi mật khẩu cho tài khoản: Admin";
            // 
            // lblInstruction
            // 
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInstruction.Location = new System.Drawing.Point(24, 70);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(400, 38);
            this.lblInstruction.TabIndex = 2;
            this.lblInstruction.Text = "Để thay đổi mật khẩu, mời bạn nhập mật khẩu cũ, điền mật khẩu mới và nhắc lại mật khẩu mới một lần nữa";
            // 
            // lblOldPass
            // 
            this.lblOldPass.AutoSize = true;
            this.lblOldPass.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPass.Location = new System.Drawing.Point(60, 128);
            this.lblOldPass.Name = "lblOldPass";
            this.lblOldPass.Size = new System.Drawing.Size(83, 17);
            this.lblOldPass.TabIndex = 3;
            this.lblOldPass.Text = "Mật khẩu cũ:";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPass.Location = new System.Drawing.Point(52, 162);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(91, 17);
            this.lblNewPass.TabIndex = 4;
            this.lblNewPass.Text = "Mật khẩu mới:";
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPass.Location = new System.Drawing.Point(82, 196);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(61, 17);
            this.lblConfirmPass.TabIndex = 5;
            this.lblConfirmPass.Text = "Nhập lại:";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass.Location = new System.Drawing.Point(150, 125);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(260, 24);
            this.txtOldPass.TabIndex = 6;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(150, 159);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(260, 24);
            this.txtNewPass.TabIndex = 7;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass.Location = new System.Drawing.Point(150, 193);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(260, 24);
            this.txtConfirmPass.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(230, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Ghi dữ liệu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(326, 245);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 28);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // FormChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(445, 290);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.lblOldPass);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.picLockIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.picLockIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLockIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
    }
}
