namespace QuanLyNhaHang.Forms
{
    partial class FormUserManagement
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.tvGroups = new System.Windows.Forms.TreeView();
            this.tsGroups = new System.Windows.Forms.ToolStrip();
            this.btnGroupAdd = new System.Windows.Forms.ToolStripButton();
            this.btnGroupEdit = new System.Windows.Forms.ToolStripButton();
            this.btnGroupDelete = new System.Windows.Forms.ToolStripButton();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlNote = new System.Windows.Forms.Panel();
            this.lblNote = new System.Windows.Forms.Label();
            this.tsUsers = new System.Windows.Forms.ToolStrip();
            this.btnUserAdd = new System.Windows.Forms.ToolStripButton();
            this.btnUserEdit = new System.Windows.Forms.ToolStripButton();
            this.btnUserDelete = new System.Windows.Forms.ToolStripButton();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblPermissionHint = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            this.tsGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tsUsers.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblNote);
            this.pnlBottom.Controls.Add(this.btnExit);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 591);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1179, 55);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(1063, 12);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 31);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerLeft);
            this.splitContainerMain.Panel1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.pnlRight);
            this.splitContainerMain.Panel2.Padding = new System.Windows.Forms.Padding(0, 6, 7, 6);
            this.splitContainerMain.Size = new System.Drawing.Size(1179, 591);
            this.splitContainerMain.SplitterDistance = 426;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 1;
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeft.Location = new System.Drawing.Point(7, 6);
            this.splitContainerLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerLeft.Name = "splitContainerLeft";
            this.splitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.Controls.Add(this.tvGroups);
            this.splitContainerLeft.Panel1.Controls.Add(this.tsGroups);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.dgvUsers);
            this.splitContainerLeft.Panel2.Controls.Add(this.pnlNote);
            this.splitContainerLeft.Panel2.Controls.Add(this.tsUsers);
            this.splitContainerLeft.Size = new System.Drawing.Size(412, 579);
            this.splitContainerLeft.SplitterDistance = 271;
            this.splitContainerLeft.SplitterWidth = 5;
            this.splitContainerLeft.TabIndex = 0;
            // 
            // tvGroups
            // 
            this.tvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGroups.Location = new System.Drawing.Point(0, 27);
            this.tvGroups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tvGroups.Name = "tvGroups";
            this.tvGroups.Size = new System.Drawing.Size(412, 244);
            this.tvGroups.TabIndex = 1;
            // 
            // tsGroups
            // 
            this.tsGroups.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGroupAdd,
            this.btnGroupEdit,
            this.btnGroupDelete});
            this.tsGroups.Location = new System.Drawing.Point(0, 0);
            this.tsGroups.Name = "tsGroups";
            this.tsGroups.Size = new System.Drawing.Size(412, 27);
            this.tsGroups.TabIndex = 0;
            this.tsGroups.Text = "toolStrip1";
            // 
            // btnGroupAdd
            // 
            this.btnGroupAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGroupAdd.Name = "btnGroupAdd";
            this.btnGroupAdd.Size = new System.Drawing.Size(117, 24);
            this.btnGroupAdd.Text = "➕ Thêm nhóm";
            // 
            // btnGroupEdit
            // 
            this.btnGroupEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGroupEdit.Name = "btnGroupEdit";
            this.btnGroupEdit.Size = new System.Drawing.Size(63, 24);
            this.btnGroupEdit.Text = "✏️ Sửa";
            // 
            // btnGroupDelete
            // 
            this.btnGroupDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGroupDelete.Name = "btnGroupDelete";
            this.btnGroupDelete.Size = new System.Drawing.Size(64, 24);
            this.btnGroupDelete.Text = "❌ Xóa";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colAccount});
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 27);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(412, 266);
            this.dgvUsers.TabIndex = 1;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "";
            this.colSTT.MinimumWidth = 6;
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 30;
            // 
            // colAccount
            // 
            this.colAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAccount.HeaderText = "Tài khoản";
            this.colAccount.MinimumWidth = 6;
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            // 
            // pnlNote
            // 
            this.pnlNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNote.Location = new System.Drawing.Point(0, 293);
            this.pnlNote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlNote.Name = "pnlNote";
            this.pnlNote.Size = new System.Drawing.Size(412, 10);
            this.pnlNote.TabIndex = 2;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(13, 12);
            this.lblNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(453, 17);
            this.lblNote.TabIndex = 0;
            this.lblNote.Text = "Chú ý: Tài khoản hệ thống Admin không được hiển thị trong danh sách";
            // 
            // tsUsers
            // 
            this.tsUsers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUserAdd,
            this.btnUserEdit,
            this.btnUserDelete});
            this.tsUsers.Location = new System.Drawing.Point(0, 0);
            this.tsUsers.Name = "tsUsers";
            this.tsUsers.Size = new System.Drawing.Size(412, 27);
            this.tsUsers.TabIndex = 0;
            this.tsUsers.Text = "toolStrip2";
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(140, 24);
            this.btnUserAdd.Text = "➕ Thêm tài khoản";
            // 
            // btnUserEdit
            // 
            this.btnUserEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserEdit.Name = "btnUserEdit";
            this.btnUserEdit.Size = new System.Drawing.Size(63, 24);
            this.btnUserEdit.Text = "✏️ Sửa";
            // 
            // btnUserDelete
            // 
            this.btnUserDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserDelete.Name = "btnUserDelete";
            this.btnUserDelete.Size = new System.Drawing.Size(64, 24);
            this.btnUserDelete.Text = "❌ Xóa";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.lblPermissionHint);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 6);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(741, 579);
            this.pnlRight.TabIndex = 0;
            // 
            // lblPermissionHint
            // 
            this.lblPermissionHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPermissionHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermissionHint.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPermissionHint.Location = new System.Drawing.Point(0, 0);
            this.lblPermissionHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPermissionHint.Name = "lblPermissionHint";
            this.lblPermissionHint.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.lblPermissionHint.Size = new System.Drawing.Size(739, 577);
            this.lblPermissionHint.TabIndex = 0;
            this.lblPermissionHint.Text = "MỜI BẠN CHỌN NHÓM NGƯỜI DÙNG BÊN PHÍA TRÁI ĐỂ PHÂN QUYỀN";
            this.lblPermissionHint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 646);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.pnlBottom);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản người sử dụng và phân quyền";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel1.PerformLayout();
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            this.splitContainerLeft.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            this.tsGroups.ResumeLayout(false);
            this.tsGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tsUsers.ResumeLayout(false);
            this.tsUsers.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.TreeView tvGroups;
        private System.Windows.Forms.ToolStrip tsGroups;
        private System.Windows.Forms.ToolStripButton btnGroupAdd;
        private System.Windows.Forms.ToolStripButton btnGroupEdit;
        private System.Windows.Forms.ToolStripButton btnGroupDelete;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.ToolStrip tsUsers;
        private System.Windows.Forms.ToolStripButton btnUserAdd;
        private System.Windows.Forms.ToolStripButton btnUserEdit;
        private System.Windows.Forms.ToolStripButton btnUserDelete;
        private System.Windows.Forms.Panel pnlNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblPermissionHint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
    }
}
