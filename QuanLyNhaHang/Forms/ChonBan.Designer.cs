namespace QuanLyNhaHang.Forms
{
    partial class ChonBan
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTim = new No1Lib.Sys.No1TextBox();
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grMain = new No1Lib.Sys.MiscDataGridView();
            this.colBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.img = new System.Windows.Forms.ImageList(this.components);
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            this.KryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.SuspendLayout();
            
            // KryptonPanel1
            this.KryptonPanel1.Controls.Add(this.txtTim);
            this.KryptonPanel1.Controls.Add(this.label1);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(565, 40);
            this.KryptonPanel1.TabIndex = 0;
            
            // label1
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tìm:";
            
            // txtTim
            this.txtTim.Location = new System.Drawing.Point(44, 10);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(253, 20);
            this.txtTim.TabIndex = 14;
            
            // KryptonPanel2
            this.KryptonPanel2.Controls.Add(this.btnOK);
            this.KryptonPanel2.Controls.Add(this.btnCancel);
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 469);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Size = new System.Drawing.Size(565, 36);
            this.KryptonPanel2.TabIndex = 17;
            
            // btnOK
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(406, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "Chọn";
            this.btnOK.UseVisualStyleBackColor = true;
            
            // btnCancel
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(487, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            
            // grMain
            this.grMain.AllowUserToAddRows = false;
            this.grMain.AllowUserToDeleteRows = false;
            this.grMain.AllowUserToOrderColumns = true;
            this.grMain.AllowUserToResizeRows = false;
            System.Windows.Forms.DataGridViewCellStyle alternatingRowsStyle = new System.Windows.Forms.DataGridViewCellStyle();
            alternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(229, 247, 252);
            this.grMain.AlternatingRowsDefaultCellStyle = alternatingRowsStyle;
            this.grMain.BackgroundColor = System.Drawing.Color.White;
            this.grMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBan,
            this.colKhuVuc});
            this.grMain.DeleteButton = null;
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.EditButton = null;
            this.grMain.GUID = "9f367874-9cf2-4829-b1b7-d3aea7913c4d";
            this.grMain.Location = new System.Drawing.Point(0, 40);
            this.grMain.Name = "grMain";
            this.grMain.ReadOnly = true;
            this.grMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grMain.SearchTextBox = this.txtTim;
            this.grMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMain.ShowCellToolTips = false;
            this.grMain.Size = new System.Drawing.Size(565, 429);
            this.grMain.TabIndex = 16;
            
            // colBan
            this.colBan.DataPropertyName = "BAN";
            this.colBan.HeaderText = "Bàn";
            this.colBan.Name = "colBan";
            this.colBan.ReadOnly = true;
            
            // colKhuVuc
            this.colKhuVuc.DataPropertyName = "KHUVUC";
            this.colKhuVuc.HeaderText = "Khu vực";
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;

            // img
            this.img.TransparentColor = System.Drawing.Color.Transparent;

            // ChonBan
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(565, 505);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChonBan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn bàn";
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            this.KryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.ResumeLayout(false);
        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public No1Lib.Sys.MiscDataGridView grMain;
        public System.Windows.Forms.Label label1;
        public No1Lib.Sys.No1TextBox txtTim;
        public System.Windows.Forms.DataGridViewTextBoxColumn colBan;
        public System.Windows.Forms.DataGridViewTextBoxColumn colKhuVuc;
        public System.Windows.Forms.ImageList img;
    }
}

