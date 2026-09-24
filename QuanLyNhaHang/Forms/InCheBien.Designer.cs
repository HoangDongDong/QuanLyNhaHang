namespace No1Run
{
    partial class InCheBien
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
            this.tabMain = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pageChuaCaiDat = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grSetup = new No1Lib.Sys.MiscDataGridView();
            this.colKhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMayIn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Label2147483646 = new System.Windows.Forms.Label();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnLuuThongTin = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThietLap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageChuaCaiDat)).BeginInit();
            this.pageChuaCaiDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.tabMain.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 39);
            this.tabMain.Name = "tabMain";
            this.tabMain.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pageChuaCaiDat});
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(491, 422);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "KryptonNavigator1";
            // 
            // pageChuaCaiDat
            // 
            this.pageChuaCaiDat.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageChuaCaiDat.Controls.Add(this.grSetup);
            this.pageChuaCaiDat.Controls.Add(this.Label2147483646);
            this.pageChuaCaiDat.Flags = 65534;
            this.pageChuaCaiDat.LastVisibleSet = true;
            this.pageChuaCaiDat.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageChuaCaiDat.Name = "pageChuaCaiDat";
            this.pageChuaCaiDat.Size = new System.Drawing.Size(489, 395);
            this.pageChuaCaiDat.Text = "Cài đặt máy in";
            this.pageChuaCaiDat.ToolTipTitle = "Page ToolTip";
            this.pageChuaCaiDat.UniqueName = "5BD1ACFC03A54F0EFE927E550654AE7B";
            // 
            // grSetup
            // 
            this.grSetup.AllowUserToAddRows = false;
            this.grSetup.AllowUserToDeleteRows = false;
            this.grSetup.AllowUserToOrderColumns = true;
            this.grSetup.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.grSetup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grSetup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grSetup.BackgroundColor = System.Drawing.Color.White;
            this.grSetup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grSetup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grSetup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKhuVuc,
            this.colLoaiDo,
            this.colMayIn});
            this.grSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grSetup.GUID = "20a36f51-9ea2-4650-b7bb-bdfaed7a4bcd";
            this.grSetup.Location = new System.Drawing.Point(0, 47);
            this.grSetup.Name = "grSetup";
            this.grSetup.RowHeadersVisible = false;
            this.grSetup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grSetup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grSetup.ShowCellToolTips = false;
            this.grSetup.Size = new System.Drawing.Size(489, 348);
            this.grSetup.TabIndex = 0;
            this.grSetup.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grSetup_CellFormatting);
            this.grSetup.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grSetup_DataError);
            // 
            // colKhuVuc
            // 
            this.colKhuVuc.DataPropertyName = "KHUVUC";
            this.colKhuVuc.HeaderText = "Khu vực";
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;
            // 
            // colLoaiDo
            // 
            this.colLoaiDo.DataPropertyName = "LOAIDO";
            this.colLoaiDo.HeaderText = "Loại đồ";
            this.colLoaiDo.Name = "colLoaiDo";
            this.colLoaiDo.ReadOnly = true;
            // 
            // colMayIn
            // 
            this.colMayIn.DataPropertyName = "MAYIN";
            this.colMayIn.FillWeight = 250F;
            this.colMayIn.HeaderText = "Máy in";
            this.colMayIn.Name = "colMayIn";
            // 
            // Label2147483646
            // 
            this.Label2147483646.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Label2147483646.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2147483646.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Label2147483646.ForeColor = System.Drawing.Color.Red;
            this.Label2147483646.Location = new System.Drawing.Point(0, 0);
            this.Label2147483646.Name = "Label2147483646";
            this.Label2147483646.Size = new System.Drawing.Size(489, 47);
            this.Label2147483646.TabIndex = 1;
            this.Label2147483646.Text = "Bạn thiết lập máy in bằng cách chọn máy in với loại đồ tương ứng.\r\nVui lòng thiết lập lại máy in pha chế sau đó click \"Lưu thông tin\"";
            this.Label2147483646.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.btnHuyBo);
            this.KryptonPanel1.Controls.Add(this.btnLuuThongTin);
            this.KryptonPanel1.Controls.Add(this.btnIn);
            this.KryptonPanel1.Controls.Add(this.btnThoat);
            this.KryptonPanel1.Controls.Add(this.btnThietLap);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 461);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(491, 36);
            this.KryptonPanel1.TabIndex = 1;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnHuyBo.Location = new System.Drawing.Point(104, 3);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(71, 30);
            this.btnHuyBo.TabIndex = 1;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Visible = false;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnLuuThongTin
            // 
            this.btnLuuThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLuuThongTin.Location = new System.Drawing.Point(8, 3);
            this.btnLuuThongTin.Name = "btnLuuThongTin";
            this.btnLuuThongTin.Size = new System.Drawing.Size(90, 30);
            this.btnLuuThongTin.TabIndex = 0;
            this.btnLuuThongTin.Text = "Lưu thông tin";
            this.btnLuuThongTin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuThongTin.UseVisualStyleBackColor = true;
            this.btnLuuThongTin.Visible = false;
            this.btnLuuThongTin.Click += new System.EventHandler(this.btnLuuThongTin_Click);
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnIn.Location = new System.Drawing.Point(286, 3);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(119, 30);
            this.btnIn.TabIndex = 2;
            this.btnIn.Text = "Thực hiện in";
            this.btnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(411, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 30);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnThietLap
            // 
            this.btnThietLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnThietLap.Location = new System.Drawing.Point(8, 3);
            this.btnThietLap.Name = "btnThietLap";
            this.btnThietLap.Size = new System.Drawing.Size(119, 30);
            this.btnThietLap.TabIndex = 10;
            this.btnThietLap.Text = "Thiết lập máy in";
            this.btnThietLap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThietLap.UseVisualStyleBackColor = true;
            this.btnThietLap.Visible = false;
            this.btnThietLap.Click += new System.EventHandler(this.btnThietLap_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 39);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(8, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(46, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IN CÁC MÓN ĂN/ĐỒ UỐNG XUỐNG BẾP / RA QUẦY BAR ĐỂ CHẾ BIẾN";
            // 
            // InCheBien
            // 
            this.AcceptButton = this.btnIn;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(491, 497);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InCheBien";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In chế biến";
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageChuaCaiDat)).EndInit();
            this.pageChuaCaiDat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grSetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        public ComponentFactory.Krypton.Navigator.KryptonNavigator tabMain;
        public ComponentFactory.Krypton.Navigator.KryptonPage pageChuaCaiDat;
        public No1Lib.Sys.MiscDataGridView grSetup;
        public System.Windows.Forms.DataGridViewTextBoxColumn colKhuVuc;
        public System.Windows.Forms.DataGridViewTextBoxColumn colLoaiDo;
        public System.Windows.Forms.DataGridViewComboBoxColumn colMayIn;
        public System.Windows.Forms.Label Label2147483646;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Button btnHuyBo;
        public System.Windows.Forms.Button btnLuuThongTin;
        public System.Windows.Forms.Button btnIn;
        public System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Button btnThietLap;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label label2;
    }
}
