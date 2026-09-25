namespace No1Run
{
    partial class TamUngDonHang
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTamUng = new System.Windows.Forms.ToolStrip();
            this.tsbThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLamMoi = new System.Windows.Forms.ToolStripButton();
            this.dgvTamUng = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNGAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDIENGIAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTHU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.toolTamUng.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamUng)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(684, 42);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(684, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÀN TẠM ỨNG: ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolTamUng
            // 
            this.toolTamUng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.toolTamUng.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.toolTamUng.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolTamUng.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbThem,
            this.toolStripSeparator1,
            this.tsbSua,
            this.toolStripSeparator2,
            this.tsbXoa,
            this.toolStripSeparator3,
            this.tsbLamMoi});
            this.toolTamUng.Location = new System.Drawing.Point(0, 42);
            this.toolTamUng.Name = "toolTamUng";
            this.toolTamUng.Padding = new System.Windows.Forms.Padding(8, 3, 1, 3);
            this.toolTamUng.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolTamUng.Size = new System.Drawing.Size(684, 31);
            this.toolTamUng.TabIndex = 1;
            // 
            // tsbThem
            // 
            this.tsbThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.tsbThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.tsbThem.Name = "tsbThem";
            this.tsbThem.Size = new System.Drawing.Size(117, 22);
            this.tsbThem.Text = "+ Thêm tạm ứng";
            this.tsbThem.Click += new System.EventHandler(this.tsbThem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSua
            // 
            this.tsbSua.Enabled = false;
            this.tsbSua.Name = "tsbSua";
            this.tsbSua.Size = new System.Drawing.Size(67, 22);
            this.tsbSua.Text = "Sửa phiếu";
            this.tsbSua.Click += new System.EventHandler(this.tsbSua_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbXoa
            // 
            this.tsbXoa.Enabled = false;
            this.tsbXoa.ForeColor = System.Drawing.Color.Firebrick;
            this.tsbXoa.Name = "tsbXoa";
            this.tsbXoa.Size = new System.Drawing.Size(67, 22);
            this.tsbXoa.Text = "Xóa phiếu";
            this.tsbXoa.Click += new System.EventHandler(this.tsbXoa_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbLamMoi
            // 
            this.tsbLamMoi.Name = "tsbLamMoi";
            this.tsbLamMoi.Size = new System.Drawing.Size(59, 22);
            this.tsbLamMoi.Text = "Làm mới";
            this.tsbLamMoi.Click += new System.EventHandler(this.tsbLamMoi_Click);
            // 
            // dgvTamUng
            // 
            this.dgvTamUng.AllowUserToAddRows = false;
            this.dgvTamUng.AllowUserToDeleteRows = false;
            this.dgvTamUng.AllowUserToResizeRows = false;
            this.dgvTamUng.BackgroundColor = System.Drawing.Color.White;
            this.dgvTamUng.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTamUng.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTamUng.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTamUng.ColumnHeadersHeight = 34;
            this.dgvTamUng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTamUng.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colNAME,
            this.colNGAY,
            this.colDIENGIAI,
            this.colTHU,
            this.colID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTamUng.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTamUng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTamUng.EnableHeadersVisualStyles = false;
            this.dgvTamUng.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvTamUng.Location = new System.Drawing.Point(0, 73);
            this.dgvTamUng.MultiSelect = false;
            this.dgvTamUng.Name = "dgvTamUng";
            this.dgvTamUng.ReadOnly = true;
            this.dgvTamUng.RowHeadersVisible = false;
            this.dgvTamUng.RowTemplate.Height = 30;
            this.dgvTamUng.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTamUng.Size = new System.Drawing.Size(684, 277);
            this.dgvTamUng.TabIndex = 2;
            this.dgvTamUng.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTamUng_CellDoubleClick);
            this.dgvTamUng.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTamUng_KeyDown);
            this.dgvTamUng.SelectionChanged += new System.EventHandler(this.dgvTamUng_SelectionChanged);
            // 
            // colSTT
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSTT.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 45;
            // 
            // colNAME
            // 
            this.colNAME.HeaderText = "Số phiếu";
            this.colNAME.Name = "colNAME";
            this.colNAME.ReadOnly = true;
            this.colNAME.Width = 115;
            // 
            // colNGAY
            // 
            this.colNGAY.HeaderText = "Ngày giờ";
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.ReadOnly = true;
            this.colNGAY.Width = 135;
            // 
            // colDIENGIAI
            // 
            this.colDIENGIAI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDIENGIAI.HeaderText = "Diễn giải";
            this.colDIENGIAI.Name = "colDIENGIAI";
            this.colDIENGIAI.ReadOnly = true;
            // 
            // colTHU
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.colTHU.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTHU.HeaderText = "Số tiền tạm ứng";
            this.colTHU.Name = "colTHU";
            this.colTHU.ReadOnly = true;
            this.colTHU.Width = 145;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlFooter.Controls.Add(this.btnThoat);
            this.pnlFooter.Controls.Add(this.lblTongTien);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 350);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(684, 50);
            this.pnlFooter.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnThoat.Location = new System.Drawing.Point(578, 9);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(94, 32);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát (ESC)";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTongTien.Location = new System.Drawing.Point(12, 14);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(175, 20);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "Tổng tạm ứng: 0 đ";
            // 
            // TamUngDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 400);
            this.Controls.Add(this.dgvTamUng);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.toolTamUng);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 360);
            this.Name = "TamUngDonHang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạm ứng đơn hàng";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TamUngDonHang_KeyDown);
            this.pnlHeader.ResumeLayout(false);
            this.toolTamUng.ResumeLayout(false);
            this.toolTamUng.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamUng)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.ToolStrip toolTamUng;
        public System.Windows.Forms.ToolStripButton tsbThem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tsbSua;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton tsbXoa;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton tsbLamMoi;
        public System.Windows.Forms.DataGridView dgvTamUng;
        public System.Windows.Forms.Panel pnlFooter;
        public System.Windows.Forms.Label lblTongTien;
        public System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNGAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDIENGIAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTHU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
    }
}
