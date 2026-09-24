namespace No1Run
{
    partial class TraDo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.Label1 = new System.Windows.Forms.Label();
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grTraLai = new No1Lib.Sys.MiscDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new No1Lib.Sys.NumericDataGridViewColumn();
            this.colTiLeGiam = new No1Lib.Sys.NumericDataGridViewColumn();
            this.Column2 = new No1Lib.Sys.NumericDataGridViewColumn();
            this.colTRALAI = new No1Lib.Sys.NumericDataGridViewColumn();
            this.colSLSUDUNG = new No1Lib.Sys.NumericDataGridViewColumn();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            this.KryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grTraLai)).BeginInit();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.Label1);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(619, 41);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(619, 41);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "KIỂM TRA && NHẬP SỐ HÀNG TRẢ LẠI";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KryptonPanel2
            // 
            this.KryptonPanel2.Controls.Add(this.btnCancel);
            this.KryptonPanel2.Controls.Add(this.btnOk);
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 456);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Size = new System.Drawing.Size(619, 42);
            this.KryptonPanel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(529, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(443, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 26);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Thực hiện";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grTraLai
            // 
            this.grTraLai.AllowUserToAddRows = false;
            this.grTraLai.AllowUserToDeleteRows = false;
            this.grTraLai.AllowUserToOrderColumns = true;
            this.grTraLai.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.grTraLai.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grTraLai.BackgroundColor = System.Drawing.Color.White;
            this.grTraLai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grTraLai.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grTraLai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grTraLai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.colDonGia,
            this.colTiLeGiam,
            this.Column2,
            this.colTRALAI,
            this.colSLSUDUNG});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grTraLai.DefaultCellStyle = dataGridViewCellStyle2;
            this.grTraLai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grTraLai.GUID = "428ee980-e447-4749-9bf5-0534188723c8";
            this.grTraLai.Location = new System.Drawing.Point(0, 41);
            this.grTraLai.Name = "grTraLai";
            this.grTraLai.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grTraLai.RowTemplate.Height = 25;
            this.grTraLai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grTraLai.ShowCellToolTips = false;
            this.grTraLai.Size = new System.Drawing.Size(619, 415);
            this.grTraLai.TabIndex = 3;
            this.grTraLai.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grTraLai_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "TENHANG";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "Mặt hàng";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DONGIA";
            this.colDonGia.DecimalLength = 2;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "N2";
            this.colDonGia.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            this.colDonGia.Width = 75;
            // 
            // colTiLeGiam
            // 
            this.colTiLeGiam.DataPropertyName = "TILEGIAMGIA";
            this.colTiLeGiam.DecimalLength = 2;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Format = "N2";
            this.colTiLeGiam.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTiLeGiam.HeaderText = "CK%";
            this.colTiLeGiam.Name = "colTiLeGiam";
            this.colTiLeGiam.ReadOnly = true;
            this.colTiLeGiam.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "SLORDER";
            this.Column2.DecimalLength = 2;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Format = "N2";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column2.HeaderText = "SL gọi";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 75;
            // 
            // colTRALAI
            // 
            this.colTRALAI.DataPropertyName = "SLTRALAI";
            this.colTRALAI.DecimalLength = 2;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.colTRALAI.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTRALAI.HeaderText = "SL trả";
            this.colTRALAI.Name = "colTRALAI";
            this.colTRALAI.Width = 75;
            // 
            // colSLSUDUNG
            // 
            this.colSLSUDUNG.DataPropertyName = "SLSUDUNG";
            this.colSLSUDUNG.DecimalLength = 2;
            this.colSLSUDUNG.DefaultCellStyle = dataGridViewCellStyle7;
            this.colSLSUDUNG.HeaderText = "SL sử dụng";
            this.colSLSUDUNG.Name = "colSLSUDUNG";
            this.colSLSUDUNG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSLSUDUNG.Width = 75;
            // 
            // TraDo
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(619, 498);
            this.Controls.Add(this.grTraLai);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TraDo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm đồ";
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            this.KryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grTraLai)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Label Label1;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOk;
        public No1Lib.Sys.MiscDataGridView grTraLai;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public No1Lib.Sys.NumericDataGridViewColumn colDonGia;
        public No1Lib.Sys.NumericDataGridViewColumn colTiLeGiam;
        public No1Lib.Sys.NumericDataGridViewColumn Column2;
        public No1Lib.Sys.NumericDataGridViewColumn colTRALAI;
        public No1Lib.Sys.NumericDataGridViewColumn colSLSUDUNG;
    }
}
