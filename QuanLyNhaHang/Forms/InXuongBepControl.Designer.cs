namespace No1Run
{
    partial class InXuongBepControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.grMain = new No1Lib.Sys.MiscDataGridView();
            this.colNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new No1Lib.Sys.NumericDataGridViewColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lblCaption);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 35);
            this.panel3.TabIndex = 5;
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(14, 10);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(410, 13);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "Máy in:";
            // 
            // grMain
            // 
            this.grMain.AllowUserToAddRows = false;
            this.grMain.AllowUserToDeleteRows = false;
            this.grMain.AllowUserToOrderColumns = true;
            this.grMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.grMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grMain.BackgroundColor = System.Drawing.Color.White;
            this.grMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNam,
            this.colDVT,
            this.colGhiChu,
            this.colSoLuong});
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.GUID = "5e2d3f0e-099e-493b-903d-f0c9cb99eea7";
            this.grMain.Location = new System.Drawing.Point(0, 35);
            this.grMain.Name = "grMain";
            this.grMain.ReadOnly = true;
            this.grMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMain.ShowCellToolTips = false;
            this.grMain.Size = new System.Drawing.Size(520, 441);
            this.grMain.TabIndex = 6;
            // 
            // colNam
            // 
            this.colNam.DataPropertyName = "TENHANG";
            this.colNam.HeaderText = "Tên hàng";
            this.colNam.Name = "colNam";
            this.colNam.ReadOnly = true;
            this.colNam.Width = 200;
            // 
            // colDVT
            // 
            this.colDVT.DataPropertyName = "DVT";
            this.colDVT.HeaderText = "ĐVT";
            this.colDVT.Name = "colDVT";
            this.colDVT.ReadOnly = true;
            this.colDVT.Width = 80;
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "NOTE";
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SOLUONG";
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // InXuongBepControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.panel3);
            this.Name = "InXuongBepControl";
            this.Size = new System.Drawing.Size(520, 476);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label lblCaption;
        public No1Lib.Sys.MiscDataGridView grMain;
        public System.Windows.Forms.DataGridViewTextBoxColumn colNam;
        public System.Windows.Forms.DataGridViewTextBoxColumn colDVT;
        public System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        public No1Lib.Sys.NumericDataGridViewColumn colSoLuong;
    }
}
