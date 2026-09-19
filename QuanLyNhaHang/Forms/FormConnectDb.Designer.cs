namespace QuanLyNhaHang
{
    partial class FormConnectDb
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
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.rdoFirebird = new System.Windows.Forms.RadioButton();
            this.rdoSqlServer = new System.Windows.Forms.RadioButton();
            this.rdoFile = new System.Windows.Forms.RadioButton();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnSelectServer = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(16, 12);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(65, 50);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.Black;
            this.lblHeaderTitle.Location = new System.Drawing.Point(88, 25);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(332, 21);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Thêm mới/sửa thông tin kết nối cơ sở dữ liệu";
            // 
            // rdoFirebird
            // 
            this.rdoFirebird.AutoSize = true;
            this.rdoFirebird.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFirebird.Location = new System.Drawing.Point(18, 80);
            this.rdoFirebird.Name = "rdoFirebird";
            this.rdoFirebird.Size = new System.Drawing.Size(155, 19);
            this.rdoFirebird.TabIndex = 2;
            this.rdoFirebird.Text = "Kết nối tới máy chủ Firebird";
            this.rdoFirebird.UseVisualStyleBackColor = true;
            // 
            // rdoSqlServer
            // 
            this.rdoSqlServer.AutoSize = true;
            this.rdoSqlServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSqlServer.Location = new System.Drawing.Point(18, 108);
            this.rdoSqlServer.Name = "rdoSqlServer";
            this.rdoSqlServer.Size = new System.Drawing.Size(170, 19);
            this.rdoSqlServer.TabIndex = 3;
            this.rdoSqlServer.Text = "Kết nối tới máy chủ SQL Server";
            this.rdoSqlServer.UseVisualStyleBackColor = true;
            // 
            // rdoFile
            // 
            this.rdoFile.AutoSize = true;
            this.rdoFile.Checked = true;
            this.rdoFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFile.Location = new System.Drawing.Point(18, 136);
            this.rdoFile.Name = "rdoFile";
            this.rdoFile.Size = new System.Drawing.Size(99, 19);
            this.rdoFile.TabIndex = 4;
            this.rdoFile.TabStop = true;
            this.rdoFile.Text = "Kết nối tới file";
            this.rdoFile.UseVisualStyleBackColor = true;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.Location = new System.Drawing.Point(202, 82);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(55, 15);
            this.lblServer.TabIndex = 5;
            this.lblServer.Text = "Máy chủ:";
            // 
            // txtServer
            // 
            this.txtServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.Location = new System.Drawing.Point(260, 79);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(130, 23);
            this.txtServer.TabIndex = 6;
            // 
            // btnSelectServer
            // 
            this.btnSelectServer.BackColor = System.Drawing.Color.White;
            this.btnSelectServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectServer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnSelectServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectServer.Location = new System.Drawing.Point(395, 77);
            this.btnSelectServer.Name = "btnSelectServer";
            this.btnSelectServer.Size = new System.Drawing.Size(46, 25);
            this.btnSelectServer.TabIndex = 7;
            this.btnSelectServer.Text = "Chọn";
            this.btnSelectServer.UseVisualStyleBackColor = false;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(197, 110);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(60, 15);
            this.lblAccount.TabIndex = 8;
            this.lblAccount.Text = "Tài khoản:";
            // 
            // txtAccount
            // 
            this.txtAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount.Location = new System.Drawing.Point(260, 107);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(130, 23);
            this.txtAccount.TabIndex = 9;
            this.txtAccount.Text = "SYSDBA";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.White;
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(395, 107);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(46, 52);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.UseVisualStyleBackColor = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(197, 138);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(260, 136);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(130, 23);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.Text = "masterkey";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabase.Location = new System.Drawing.Point(179, 168);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(78, 15);
            this.lblDatabase.TabIndex = 13;
            this.lblDatabase.Text = "Cơ sở dữ liệu:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.Location = new System.Drawing.Point(260, 165);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(181, 23);
            this.txtDatabase.TabIndex = 14;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Maroon;
            this.lblNote.Location = new System.Drawing.Point(152, 195);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(289, 15);
            this.lblNote.TabIndex = 15;
            this.lblNote.Text = "(Đường dẫn tới cơ sở dữ liệu không được chứa ký tự có dấu)";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.White;
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.Black;
            this.btnAccept.Location = new System.Drawing.Point(276, 222);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(80, 28);
            this.btnAccept.TabIndex = 16;
            this.btnAccept.Text = "Chấp nhận";
            this.btnAccept.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(362, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 28);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormConnectDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(460, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.btnSelectServer);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.rdoFile);
            this.Controls.Add(this.rdoSqlServer);
            this.Controls.Add(this.rdoFirebird);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnectDb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kết nối cơ sở dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.RadioButton rdoFirebird;
        private System.Windows.Forms.RadioButton rdoSqlServer;
        private System.Windows.Forms.RadioButton rdoFile;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnSelectServer;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}
