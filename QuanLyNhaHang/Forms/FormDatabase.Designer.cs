namespace QuanLyNhaHang
{
    partial class FormDatabase
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.rdoNewDb = new System.Windows.Forms.RadioButton();
            this.rdoOpenDb = new System.Windows.Forms.RadioButton();
            this.lblOpenFile = new System.Windows.Forms.LinkLabel();
            this.lblEdit = new System.Windows.Forms.LinkLabel();
            this.lblDelete = new System.Windows.Forms.LinkLabel();
            this.lstDatabases = new System.Windows.Forms.ListView();
            this.colDbName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDbPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkDontShowAgain = new System.Windows.Forms.CheckBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(347, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tạo dữ liệu mới hoặc mở dữ liệu đã có";
            // 
            // rdoNewDb
            // 
            this.rdoNewDb.AutoSize = true;
            this.rdoNewDb.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNewDb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rdoNewDb.Location = new System.Drawing.Point(22, 58);
            this.rdoNewDb.Name = "rdoNewDb";
            this.rdoNewDb.Size = new System.Drawing.Size(434, 21);
            this.rdoNewDb.TabIndex = 1;
            this.rdoNewDb.Text = "Tạo dữ liệu trắng (khi bạn muốn tạo dữ liệu để sử dụng cho riêng bạn)";
            this.rdoNewDb.UseVisualStyleBackColor = true;
            // 
            // rdoOpenDb
            // 
            this.rdoOpenDb.AutoSize = true;
            this.rdoOpenDb.Checked = true;
            this.rdoOpenDb.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoOpenDb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rdoOpenDb.Location = new System.Drawing.Point(22, 88);
            this.rdoOpenDb.Name = "rdoOpenDb";
            this.rdoOpenDb.Size = new System.Drawing.Size(358, 21);
            this.rdoOpenDb.TabIndex = 2;
            this.rdoOpenDb.TabStop = true;
            this.rdoOpenDb.Text = "Mở lại dữ liệu demo hoặc dữ liệu đã mở (nháy đúp để chọn)";
            this.rdoOpenDb.UseVisualStyleBackColor = true;
            // 
            // lblOpenFile
            // 
            this.lblOpenFile.AutoSize = true;
            this.lblOpenFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenFile.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblOpenFile.Location = new System.Drawing.Point(440, 91);
            this.lblOpenFile.Name = "lblOpenFile";
            this.lblOpenFile.Size = new System.Drawing.Size(56, 15);
            this.lblOpenFile.TabIndex = 3;
            this.lblOpenFile.TabStop = true;
            this.lblOpenFile.Text = "📁 Mở file";
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblEdit.Location = new System.Drawing.Point(510, 91);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(37, 15);
            this.lblEdit.TabIndex = 4;
            this.lblEdit.TabStop = true;
            this.lblEdit.Text = "✏️ Sửa";
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.LinkColor = System.Drawing.Color.Red;
            this.lblDelete.Location = new System.Drawing.Point(560, 91);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(39, 15);
            this.lblDelete.TabIndex = 5;
            this.lblDelete.TabStop = true;
            this.lblDelete.Text = "❌ Xóa";
            // 
            // lstDatabases
            // 
            this.lstDatabases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDbName,
            this.colDbPath});
            this.lstDatabases.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDatabases.FullRowSelect = true;
            this.lstDatabases.GridLines = true;
            this.lstDatabases.HideSelection = false;
            this.lstDatabases.Location = new System.Drawing.Point(44, 118);
            this.lstDatabases.MultiSelect = false;
            this.lstDatabases.Name = "lstDatabases";
            this.lstDatabases.Size = new System.Drawing.Size(555, 230);
            this.lstDatabases.TabIndex = 6;
            this.lstDatabases.UseCompatibleStateImageBehavior = false;
            this.lstDatabases.View = System.Windows.Forms.View.Details;
            // 
            // colDbName
            // 
            this.colDbName.Text = "Tên CSDL";
            this.colDbName.Width = 140;
            // 
            // colDbPath
            // 
            this.colDbPath.Text = "Đường dẫn";
            this.colDbPath.Width = 410;
            // 
            // chkDontShowAgain
            // 
            this.chkDontShowAgain.AutoSize = true;
            this.chkDontShowAgain.Checked = true;
            this.chkDontShowAgain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDontShowAgain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDontShowAgain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chkDontShowAgain.Location = new System.Drawing.Point(22, 368);
            this.chkDontShowAgain.Name = "chkDontShowAgain";
            this.chkDontShowAgain.Size = new System.Drawing.Size(142, 19);
            this.chkDontShowAgain.TabIndex = 7;
            this.chkDontShowAgain.Text = "Không hiển thị lần sau";
            this.chkDontShowAgain.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.White;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Location = new System.Drawing.Point(432, 362);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(82, 28);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(520, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(624, 404);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.chkDontShowAgain);
            this.Controls.Add(this.lstDatabases);
            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblEdit);
            this.Controls.Add(this.lblOpenFile);
            this.Controls.Add(this.rdoOpenDb);
            this.Controls.Add(this.rdoNewDb);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dữ liệu chương trình";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdoNewDb;
        private System.Windows.Forms.RadioButton rdoOpenDb;
        private System.Windows.Forms.LinkLabel lblOpenFile;
        private System.Windows.Forms.LinkLabel lblEdit;
        private System.Windows.Forms.LinkLabel lblDelete;
        private System.Windows.Forms.ListView lstDatabases;
        private System.Windows.Forms.ColumnHeader colDbName;
        private System.Windows.Forms.ColumnHeader colDbPath;
        private System.Windows.Forms.CheckBox chkDontShowAgain;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
    }
}
