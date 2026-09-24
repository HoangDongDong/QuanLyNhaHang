namespace QuanLyNhaHang.Forms
{
    partial class DanhLaiMaHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMaNhom = new System.Windows.Forms.Button();
            this.txtMatKhau = new No1Lib.Sys.No1TextBox();
            this.prDetail = new System.Windows.Forms.ProgressBar();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.prMain = new System.Windows.Forms.ProgressBar();
            this.chkMaNhom = new No1Lib.Sys.No1CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grMain = new No1Lib.Sys.MiscDataGridView();
            this.colNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.grMain);
            this.KryptonPanel1.Controls.Add(this.btnMaNhom);
            this.KryptonPanel1.Controls.Add(this.txtMatKhau);
            this.KryptonPanel1.Controls.Add(this.prDetail);
            this.KryptonPanel1.Controls.Add(this.lblTrangThai);
            this.KryptonPanel1.Controls.Add(this.prMain);
            this.KryptonPanel1.Controls.Add(this.chkMaNhom);
            this.KryptonPanel1.Controls.Add(this.label2);
            this.KryptonPanel1.Controls.Add(this.btnOK);
            this.KryptonPanel1.Controls.Add(this.btnCancel);
            this.KryptonPanel1.Controls.Add(this.label1);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(472, 410);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hệ thống sẽ đánh lại toàn bộ mã hàng sắp xếp theo tên hàng dựa vào cấu hình mã nhóm hàng của bạn.";
            // 
            // btnMaNhom
            // 
            this.btnMaNhom.Location = new System.Drawing.Point(150, 39);
            this.btnMaNhom.Name = "btnMaNhom";
            this.btnMaNhom.Size = new System.Drawing.Size(153, 25);
            this.btnMaNhom.TabIndex = 21;
            this.btnMaNhom.Text = "Tự động phân mã nhóm";
            this.btnMaNhom.UseVisualStyleBackColor = true;
            this.btnMaNhom.Click += new System.EventHandler(this.btnMaNhom_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(366, 41);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(100, 20);
            this.txtMatKhau.TabIndex = 16;
            // 
            // prDetail
            // 
            this.prDetail.Location = new System.Drawing.Point(3, 334);
            this.prDetail.Name = "prDetail";
            this.prDetail.Size = new System.Drawing.Size(463, 17);
            this.prDetail.TabIndex = 22;
            this.prDetail.Visible = false;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.lblTrangThai.Location = new System.Drawing.Point(3, 374);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(249, 28);
            this.lblTrangThai.TabIndex = 20;
            this.lblTrangThai.Text = "Chuẩn bị thực hiện...";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrangThai.Visible = false;
            // 
            // prMain
            // 
            this.prMain.Location = new System.Drawing.Point(3, 353);
            this.prMain.Name = "prMain";
            this.prMain.Size = new System.Drawing.Size(463, 16);
            this.prMain.TabIndex = 19;
            this.prMain.Visible = false;
            // 
            // chkMaNhom
            // 
            this.chkMaNhom.AutoSize = true;
            this.chkMaNhom.BackColor = System.Drawing.Color.Transparent;
            this.chkMaNhom.Location = new System.Drawing.Point(12, 44);
            this.chkMaNhom.Name = "chkMaNhom";
            this.chkMaNhom.Size = new System.Drawing.Size(115, 17);
            this.chkMaNhom.TabIndex = 18;
            this.chkMaNhom.Text = "Cập nhật mã nhóm";
            this.chkMaNhom.UseVisualStyleBackColor = false;
            this.chkMaNhom.CheckedChanged += new System.EventHandler(this.chkMaNhom_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(309, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mật khẩu";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(310, 375);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "Thực hiện";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(391, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grMain
            // 
            this.grMain.AllowUserToAddRows = false;
            this.grMain.AllowUserToDeleteRows = false;
            this.grMain.AllowUserToOrderColumns = true;
            this.grMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.grMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grMain.BackgroundColor = System.Drawing.Color.White;
            this.grMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNhom,
            this.colMa});
            this.grMain.GUID = "c1ee429b-f8cf-4459-838c-77fe2cf328cb";
            this.grMain.Location = new System.Drawing.Point(3, 67);
            this.grMain.Name = "grMain";
            this.grMain.ReadOnly = true;
            this.grMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMain.Size = new System.Drawing.Size(463, 261);
            this.grMain.TabIndex = 23;
            this.grMain.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grMain_CellFormatting);
            // 
            // colNhom
            // 
            this.colNhom.DataPropertyName = "NHOM";
            this.colNhom.FillWeight = 150F;
            this.colNhom.HeaderText = "Nhóm hàng";
            this.colNhom.Name = "colNhom";
            this.colNhom.ReadOnly = true;
            // 
            // colMa
            // 
            this.colMa.DataPropertyName = "MA";
            this.colMa.HeaderText = "Đánh mã";
            this.colMa.Name = "colMa";
            this.colMa.ReadOnly = true;
            // 
            // DanhLaiMaHang
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(472, 410);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DanhLaiMaHang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐÁNH LẠI MÃ HÀNG";
            this.Load += new System.EventHandler(this.DanhLaiMaHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.ResumeLayout(false);
        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnMaNhom;
        public No1Lib.Sys.No1TextBox txtMatKhau;
        public System.Windows.Forms.ProgressBar prDetail;
        public System.Windows.Forms.Label lblTrangThai;
        public System.Windows.Forms.ProgressBar prMain;
        public No1Lib.Sys.No1CheckBox chkMaNhom;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public No1Lib.Sys.MiscDataGridView grMain;
        public System.Windows.Forms.DataGridViewTextBoxColumn colNhom;
        public System.Windows.Forms.DataGridViewTextBoxColumn colMa;
    }
}
