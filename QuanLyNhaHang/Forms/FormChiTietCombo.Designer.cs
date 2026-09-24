namespace QuanLyNhaHang.Forms
{
    partial class ChiTietCombo
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
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblItem = new System.Windows.Forms.Label();
            this.grChiTiet = new No1Lib.Sys.MiscDataGridView();
            this.colMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new No1Lib.Sys.NumericDataGridViewColumn();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            this.KryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KryptonPanel2
            // 
            this.KryptonPanel2.Controls.Add(this.lblItem);
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Size = new System.Drawing.Size(511, 62);
            this.KryptonPanel2.TabIndex = 22;
            // 
            // lblItem
            // 
            this.lblItem.BackColor = System.Drawing.Color.Transparent;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.Navy;
            this.lblItem.Location = new System.Drawing.Point(9, 6);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(494, 50);
            this.lblItem.TabIndex = 21;
            this.lblItem.Text = "Mặt hàng: ";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grChiTiet
            // 
            this.grChiTiet.AllowUserToAddRows = false;
            this.grChiTiet.AllowUserToDeleteRows = false;
            this.grChiTiet.AllowUserToOrderColumns = true;
            this.grChiTiet.AllowUserToResizeRows = false;
            this.grChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.grChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grChiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatHang,
            this.colSoLuong});
            this.grChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grChiTiet.Location = new System.Drawing.Point(0, 62);
            this.grChiTiet.Name = "grChiTiet";
            this.grChiTiet.ReadOnly = true;
            this.grChiTiet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grChiTiet.ShowCellToolTips = false;
            this.grChiTiet.Size = new System.Drawing.Size(511, 289);
            this.grChiTiet.TabIndex = 0;
            // 
            // colMatHang
            // 
            this.colMatHang.DataPropertyName = "TENHANG";
            this.colMatHang.HeaderText = "Mặt hàng";
            this.colMatHang.Name = "colMatHang";
            this.colMatHang.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "COMBOSL";
            this.colSoLuong.DecimalLength = 2;
            this.colSoLuong.FillWeight = 30F;
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.btnCancel);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 351);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(511, 47);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(424, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormChiTietCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(511, 398);
            this.Controls.Add(this.grChiTiet);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.KryptonPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChiTietCombo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết combo";
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            this.KryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        public System.Windows.Forms.Label lblItem;
        public No1Lib.Sys.MiscDataGridView grChiTiet;
        public System.Windows.Forms.DataGridViewTextBoxColumn colMatHang;
        public No1Lib.Sys.NumericDataGridViewColumn colSoLuong;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Button btnCancel;
    }
}


