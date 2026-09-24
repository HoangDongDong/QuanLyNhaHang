namespace QuanLyNhaHang.Forms
{
    partial class CongNoBanDau
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
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.grMain = new No1Lib.Sys.MiscDataGridView();
            this.colMaKhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new No1Lib.Sys.NumericDataGridViewColumn();
            this.KryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtLoc = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.tsbFileMau = new System.Windows.Forms.ToolStripButton();
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dtNgay = new No1Lib.Sys.No1DatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel3)).BeginInit();
            this.KryptonPanel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            this.KryptonPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            
            // KryptonPanel1
            this.KryptonPanel1.Controls.Add(this.grMain);
            this.KryptonPanel1.Controls.Add(this.KryptonPanel3);
            this.KryptonPanel1.Controls.Add(this.toolStrip1);
            this.KryptonPanel1.Controls.Add(this.KryptonPanel2);
            this.KryptonPanel1.Controls.Add(this.panel1);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(734, 495);
            this.KryptonPanel1.TabIndex = 0;
            
            // grMain
            this.grMain.AllowUserToAddRows = false;
            this.grMain.AllowUserToDeleteRows = false;
            this.grMain.AllowUserToOrderColumns = true;
            this.grMain.AllowUserToResizeRows = false;
            this.grMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grMain.BackgroundColor = System.Drawing.Color.White;
            this.grMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaKhach,
            this.colTenKhach,
            this.colDiaChi,
            this.colDienThoai,
            this.colDonGia});
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.GUID = new System.Guid("190bbb2a-9d20-40c1-93f7-35a33785d6c1");
            this.grMain.Location = new System.Drawing.Point(0, 95);
            this.grMain.Name = "grMain";
            this.grMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMain.Size = new System.Drawing.Size(734, 364);
            this.grMain.TabIndex = 16;
            
            // colMaKhach
            this.colMaKhach.DataPropertyName = "CODE";
            this.colMaKhach.HeaderText = "Mã khách";
            this.colMaKhach.Name = "colMaKhach";
            this.colMaKhach.ReadOnly = true;
            
            // colTenKhach
            this.colTenKhach.DataPropertyName = "NAME";
            this.colTenKhach.FillWeight = 200F;
            this.colTenKhach.HeaderText = "Tên khách";
            this.colTenKhach.Name = "colTenKhach";
            this.colTenKhach.ReadOnly = true;
            
            // colDiaChi
            this.colDiaChi.DataPropertyName = "DIACHI";
            this.colDiaChi.FillWeight = 200F;
            this.colDiaChi.HeaderText = "Địa chỉ";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.ReadOnly = true;
            
            // colDienThoai
            this.colDienThoai.DataPropertyName = "DIENTHOAI";
            this.colDienThoai.HeaderText = "Điện thoại";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.ReadOnly = true;
            
            // colDonGia
            this.colDonGia.AllowNegative = false;
            this.colDonGia.DataPropertyName = "SOTIEN";
            this.colDonGia.DecimalLength = 2;
            System.Windows.Forms.DataGridViewCellStyle cellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellStyle1.Format = "N2";
            this.colDonGia.DefaultCellStyle = cellStyle1;
            this.colDonGia.HeaderText = "Số tiền";
            this.colDonGia.Name = "colDonGia";
            
            // KryptonPanel3
            this.KryptonPanel3.Controls.Add(this.btnCancel);
            this.KryptonPanel3.Controls.Add(this.btnOK);
            this.KryptonPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel3.Location = new System.Drawing.Point(0, 459);
            this.KryptonPanel3.Name = "KryptonPanel3";
            this.KryptonPanel3.Size = new System.Drawing.Size(734, 36);
            this.KryptonPanel3.TabIndex = 18;
            
            // btnCancel
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(656, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            
            // btnOK
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(575, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Ghi dữ liệu";
            this.btnOK.UseVisualStyleBackColor = true;
            
            // toolStrip1
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtLoc,
            this.toolStripSeparator1,
            this.tsbImport,
            this.tsbFileMau});
            this.toolStrip1.Location = new System.Drawing.Point(0, 70);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            
            // toolStripLabel1
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel1.Text = "Lọc (F3)";
            
            // txtLoc
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(100, 25);
            
            // toolStripSeparator1
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            
            // tsbImport
            try {
                this.tsbImport.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAHBSURBVDhPldM7S8NQGAbg82scHFwCUmurKFSNFxKlalWsSL1RUYpCi9pgLFUhCEa0HQpWiggOOoiTo/+kS+93nBzKa75Tk0HFauAlkO89T5ITwtjnkUql4kbQJnGz/+2cTCbRbDZ/DXWM/IwkEgm+OJ/PI5fL8WSzWWQyGR6alUolUM/IdyQWi/FSoVDgyFeIZgQRQl0jLWTzaQx/CQHpdNpCdF2HkThbfxDR7qDOT/ujaRqY784FRT/BwvEyBsIDljUanYAt1AspOA7qfH01AqPRKNjidWvR1csFJs6G4Ny1Q9xzoTsooE+18xl1isUiD0EUAhRFAZu5dFh3jb2eY+lkHv0bDowpQ/z6O95AHdo8igkREAqFwGTNZgHiqQjlOYI5fQkO1YnV2zVE7lVQp1KpoFwuWxABgUAATFQFDvTvOSGEBdgPexB+PMBich7CVmtGnWq1yhETIsDv94MNBruwsrsGeV+CqLkwogxjWnVj5yaAySMJs8oUqFOr1ThiQgT4fD4wx3Znu68I6tTrdY6YEAFerxfMtt6Bv6TRaHDEhAjweDywfiq3282fpN0PZc6pS2ssQJKkuCzL+E9ozQecpccwnU8LVQAAAABJRU5ErkJggg==")));
            } catch { }
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(106, 22);
            this.tsbImport.Text = "Import từ excel";
            
            // tsbFileMau
            try {
                this.tsbFileMau.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIcSURBVDhPlZHfS1NhHMbPbfkHGF3lZXrRjaSj6IdGEDboogUS3ixYtVjEYrQ21mpYdlV6lRdREUF6t9vWmg1pzemaGyNRYbjS4RQm07Pfc0/vc2ov2pU78HDe8/I8n/O871dR/j3XXC69we02tSJmmnnlqtN5Ey0+zEjAFYfjVkMALswB/bMNnJ+p41y4hjOhCk5NF6ELquiZ2sbJQB7d/i3Qy4wEXLbZzPVGQwM8z0EDDG/U4FmvwL32F+BYycOe2tIA9DIjAZes1juV3V3Z4MYPFcPxDXhi63DPrcEV+Q1nOA3H9xXYv6VALzMScNFisZTqddngaWITVfHdVDCRkGt/NAp6mZGAfrP5rlqr4eWXCD74/HgX+Ynw4iJCCwuYTiYRXV7G1Pw8ArEYCKCXGQk4azLdy1cqeOv1arN48ymAdDaLgtij2KC5JoBeZpTOgYHrnXr9Q+rVxASoVRFkdW8wiK/xuNZgdmlpX4NcuYzTRqNVOdbX9+j/8XNEZVGRUsWf8qWS1oBvig02xbtnaOi+0q7TGdt7ez3UyPg4qHQmg1K1ikmfT/srG8yI+9h7B9liEd2DgzZ5BycMhgeZQgGPx8bQEDN+9v4jkqkUcmKPYoPmmg3oZUYCjuv1jlVVheX1JOwvRjH6ObRvCgTsbUAvMxIgjvIkK877a2fnQKKXGQk41NFxu62ra6QVMSMBYnFY6IjQ0QOK3rY/QYV7YsxgIUQAAAAASUVORK5CYII=")));
            } catch { }
            this.tsbFileMau.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileMau.Name = "tsbFileMau";
            this.tsbFileMau.Size = new System.Drawing.Size(106, 22);
            this.tsbFileMau.Text = "Export file mẫu";
            
            // KryptonPanel2
            this.KryptonPanel2.Controls.Add(this.dtNgay);
            this.KryptonPanel2.Controls.Add(this.label2);
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 39);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Size = new System.Drawing.Size(734, 31);
            this.KryptonPanel2.TabIndex = 15;
            
            // dtNgay
            this.dtNgay.DateTime = new System.DateTime(0);
            this.dtNgay.EditValue = null;
            this.dtNgay.Location = new System.Drawing.Point(118, 6);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(91, 20);
            this.dtNgay.TabIndex = 1;
            
            // label2
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày chốt công nợ:";
            
            // panel1
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 39);
            this.panel1.TabIndex = 14;
            
            // pictureBox1
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            try {
                this.pictureBox1.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(System.Convert.FromBase64String("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")));
            } catch { }
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cập nhật thông tin công nợ ban đầu khi sử dụng phần mềm";
            
            // CongNoBanDau
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 495);
            this.Controls.Add(this.KryptonPanel1);
            this.Name = "CongNoBanDau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CÔNG NỢ BAN ĐẦU";
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel3)).EndInit();
            this.KryptonPanel3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            this.KryptonPanel2.ResumeLayout(false);
            this.KryptonPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public No1Lib.Sys.MiscDataGridView grMain;
        public System.Windows.Forms.DataGridViewTextBoxColumn colMaKhach;
        public System.Windows.Forms.DataGridViewTextBoxColumn colTenKhach;
        public System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
        public System.Windows.Forms.DataGridViewTextBoxColumn colDienThoai;
        public No1Lib.Sys.NumericDataGridViewColumn colDonGia;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel3;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ToolStripTextBox txtLoc;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tsbImport;
        public System.Windows.Forms.ToolStripButton tsbFileMau;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        public No1Lib.Sys.No1DatePicker dtNgay;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
    }
}


