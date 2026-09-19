namespace QuanLyNhaHang
{
    partial class FormRestore
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
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblNotice = new System.Windows.Forms.Label();
            this.lblBackupFile = new System.Windows.Forms.Label();
            this.txtBackupFile = new System.Windows.Forms.TextBox();
            this.btnBrowseBackup = new System.Windows.Forms.Button();
            this.lblRestoreFile = new System.Windows.Forms.Label();
            this.txtRestoreFile = new System.Windows.Forms.TextBox();
            this.btnBrowseRestore = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(20, 16);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(42, 42);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.Black;
            this.lblHeaderTitle.Location = new System.Drawing.Point(70, 24);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(161, 20);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Khôi phục cơ sở dữ liệu";
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.ForeColor = System.Drawing.Color.Red;
            this.lblNotice.Location = new System.Drawing.Point(30, 70);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(304, 15);
            this.lblNotice.TabIndex = 2;
            this.lblNotice.Text = "Chú ý: Bạn chỉ có thể khôi phục khi ứng dụng chạy trên máy chủ";
            // 
            // lblBackupFile
            // 
            this.lblBackupFile.AutoSize = true;
            this.lblBackupFile.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupFile.Location = new System.Drawing.Point(30, 102);
            this.lblBackupFile.Name = "lblBackupFile";
            this.lblBackupFile.Size = new System.Drawing.Size(77, 17);
            this.lblBackupFile.TabIndex = 3;
            this.lblBackupFile.Text = "File sao lưu:";
            // 
            // txtBackupFile
            // 
            this.txtBackupFile.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupFile.Location = new System.Drawing.Point(120, 99);
            this.txtBackupFile.Name = "txtBackupFile";
            this.txtBackupFile.Size = new System.Drawing.Size(265, 24);
            this.txtBackupFile.TabIndex = 4;
            // 
            // btnBrowseBackup
            // 
            this.btnBrowseBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseBackup.Location = new System.Drawing.Point(391, 97);
            this.btnBrowseBackup.Name = "btnBrowseBackup";
            this.btnBrowseBackup.Size = new System.Drawing.Size(32, 27);
            this.btnBrowseBackup.TabIndex = 5;
            this.btnBrowseBackup.UseVisualStyleBackColor = true;
            // 
            // lblRestoreFile
            // 
            this.lblRestoreFile.AutoSize = true;
            this.lblRestoreFile.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestoreFile.Location = new System.Drawing.Point(30, 137);
            this.lblRestoreFile.Name = "lblRestoreFile";
            this.lblRestoreFile.Size = new System.Drawing.Size(87, 17);
            this.lblRestoreFile.TabIndex = 6;
            this.lblRestoreFile.Text = "File khôi phục:";
            // 
            // txtRestoreFile
            // 
            this.txtRestoreFile.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestoreFile.Location = new System.Drawing.Point(120, 134);
            this.txtRestoreFile.Name = "txtRestoreFile";
            this.txtRestoreFile.Size = new System.Drawing.Size(265, 24);
            this.txtRestoreFile.TabIndex = 7;
            // 
            // btnBrowseRestore
            // 
            this.btnBrowseRestore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseRestore.Location = new System.Drawing.Point(391, 132);
            this.btnBrowseRestore.Name = "btnBrowseRestore";
            this.btnBrowseRestore.Size = new System.Drawing.Size(32, 27);
            this.btnBrowseRestore.TabIndex = 8;
            this.btnBrowseRestore.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(232, 185);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(90, 28);
            this.btnExecute.TabIndex = 9;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(335, 185);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 28);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FormRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(450, 230);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnBrowseRestore);
            this.Controls.Add(this.txtRestoreFile);
            this.Controls.Add(this.lblRestoreFile);
            this.Controls.Add(this.btnBrowseBackup);
            this.Controls.Add(this.txtBackupFile);
            this.Controls.Add(this.lblBackupFile);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Khôi phục CSDL";
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Label lblBackupFile;
        private System.Windows.Forms.TextBox txtBackupFile;
        private System.Windows.Forms.Button btnBrowseBackup;
        private System.Windows.Forms.Label lblRestoreFile;
        private System.Windows.Forms.TextBox txtRestoreFile;
        private System.Windows.Forms.Button btnBrowseRestore;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnClose;
    }
}
