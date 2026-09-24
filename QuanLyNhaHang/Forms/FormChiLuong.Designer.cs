namespace QuanLyNhaHang.Forms
{
    partial class ChiLuong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPhieuChi = new System.Windows.Forms.ToolStripButton();
            this.grChiLuong = new No1Lib.Sys.MiscDataGridView();
            this.colNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienLuong = new No1Lib.Sys.NumericDataGridViewColumn();
            this.colDaNhan = new No1Lib.Sys.NumericDataGridViewColumn();
            this.colSoPhieuChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grChiLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 38);
            this.panel1.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(41, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Chi tiết chi lương tháng";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPhieuChi});
            this.toolStrip1.Location = new System.Drawing.Point(0, 38);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(562, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPhieuChi
            // 
            this.tsbPhieuChi.Enabled = false;
            this.tsbPhieuChi.Name = "tsbPhieuChi";
            this.tsbPhieuChi.Size = new System.Drawing.Size(117, 22);
            this.tsbPhieuChi.Text = "Tạo phiếu chi lương";
            // 
            // grChiLuong
            // 
            this.grChiLuong.AllowUserToAddRows = false;
            this.grChiLuong.AllowUserToDeleteRows = false;
            this.grChiLuong.AllowUserToOrderColumns = true;
            this.grChiLuong.AllowUserToResizeRows = false;
            this.grChiLuong.BackgroundColor = System.Drawing.Color.White;
            this.grChiLuong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grChiLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grChiLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNhanVien,
            this.colTienLuong,
            this.colDaNhan,
            this.colSoPhieuChi});
            this.grChiLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grChiLuong.Location = new System.Drawing.Point(0, 63);
            this.grChiLuong.Name = "grChiLuong";
            this.grChiLuong.ReadOnly = true;
            this.grChiLuong.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grChiLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grChiLuong.Size = new System.Drawing.Size(562, 349);
            this.grChiLuong.TabIndex = 12;
            // 
            // colNhanVien
            // 
            this.colNhanVien.DataPropertyName = "NHANVIEN";
            this.colNhanVien.HeaderText = "Nhân viên";
            this.colNhanVien.Name = "colNhanVien";
            this.colNhanVien.ReadOnly = true;
            this.colNhanVien.Width = 200;
            // 
            // colTienLuong
            // 
            this.colTienLuong.DataPropertyName = "THUCNHAN";
            this.colTienLuong.HeaderText = "Tiền lương";
            this.colTienLuong.Name = "colTienLuong";
            this.colTienLuong.ReadOnly = true;
            // 
            // colDaNhan
            // 
            this.colDaNhan.DataPropertyName = "SOTIEN";
            this.colDaNhan.HeaderText = "Đã nhận";
            this.colDaNhan.Name = "colDaNhan";
            this.colDaNhan.ReadOnly = true;
            // 
            // colSoPhieuChi
            // 
            this.colSoPhieuChi.DataPropertyName = "NAME";
            this.colSoPhieuChi.HeaderText = "Số phiếu chi";
            this.colSoPhieuChi.Name = "colSoPhieuChi";
            this.colSoPhieuChi.ReadOnly = true;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 412);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(562, 42);
            this.kryptonPanel1.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(475, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormChiLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(562, 454);
            this.Controls.Add(this.grChiLuong);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChiLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHI LƯƠNG";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grChiLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tsbPhieuChi;
        public No1Lib.Sys.MiscDataGridView grChiLuong;
        public System.Windows.Forms.DataGridViewTextBoxColumn colNhanVien;
        public No1Lib.Sys.NumericDataGridViewColumn colTienLuong;
        public No1Lib.Sys.NumericDataGridViewColumn colDaNhan;
        public System.Windows.Forms.DataGridViewTextBoxColumn colSoPhieuChi;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        public System.Windows.Forms.Button btnCancel;
    }
}


