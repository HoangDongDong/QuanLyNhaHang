namespace QuanLyNhaHang
{
    partial class FormBackup
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
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(147, 20);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Sao lưu cơ sở dữ liệu";
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.ForeColor = System.Drawing.Color.Red;
            this.lblNotice.Location = new System.Drawing.Point(30, 75);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(290, 15);
            this.lblNotice.TabIndex = 2;
            this.lblNotice.Text = "Chú ý: Bạn chỉ có thể sao lưu khi ứng dụng chạy trên máy chủ";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(30, 112);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(73, 17);
            this.lblTarget.TabIndex = 3;
            this.lblTarget.Text = "Sao lưu tới:";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupPath.Location = new System.Drawing.Point(108, 109);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(280, 24);
            this.txtBackupPath.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(393, 107);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(32, 27);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(232, 168);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(90, 28);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(335, 168);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(450, 215);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sao lưu CSDL";
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnClose;
    }
}
