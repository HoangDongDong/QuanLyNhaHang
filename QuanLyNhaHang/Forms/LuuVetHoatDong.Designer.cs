﻿namespace No1Run
{
    partial class LuuVetHoatDong
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
            this.KryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.KryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.KryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grHoaDon = new No1Lib.Sys.MiscDataGridView();
            this.colHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtSoHoaDon = new No1Lib.Sys.No1TextBox();
            this.Label2147483645 = new System.Windows.Forms.Label();
            this.dtNgay = new No1Lib.Sys.FilterDateRange();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.KryptonNavigator2 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.KryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grMain = new No1Lib.Sys.GridMapper();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lueNhanVien = new No1Lib.Sys.No1LookupEdit();
            this.lblLoc = new System.Windows.Forms.Label();
            this.txtLoc = new No1Lib.Sys.No1TextBox();
            this.btnXoaLuuVet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).BeginInit();
            this.KryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).BeginInit();
            this.KryptonSplitContainer1.Panel2.SuspendLayout();
            this.KryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonNavigator1)).BeginInit();
            this.KryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPage1)).BeginInit();
            this.KryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            this.KryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonNavigator2)).BeginInit();
            this.KryptonNavigator2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPage2)).BeginInit();
            this.KryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            // 
            // KryptonSplitContainer1.Panel1
            // 
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.KryptonNavigator1);
            // 
            // KryptonSplitContainer1.Panel2
            // 
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.KryptonNavigator2);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(1024, 542);
            this.KryptonSplitContainer1.SplitterDistance = 344;
            this.KryptonSplitContainer1.TabIndex = 2;
            // 
            // KryptonNavigator1
            // 
            this.KryptonNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.KryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.KryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.KryptonNavigator1.Name = "KryptonNavigator1";
            this.KryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.KryptonPage1});
            this.KryptonNavigator1.SelectedIndex = 0;
            this.KryptonNavigator1.Size = new System.Drawing.Size(344, 542);
            this.KryptonNavigator1.TabIndex = 1;
            this.KryptonNavigator1.Text = "KryptonNavigator1";
            // 
            // KryptonPage1
            // 
            this.KryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.KryptonPage1.Controls.Add(this.grHoaDon);
            this.KryptonPage1.Controls.Add(this.KryptonPanel2);
            this.KryptonPage1.Flags = 65534;
            this.KryptonPage1.LastVisibleSet = true;
            this.KryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.KryptonPage1.Name = "KryptonPage1";
            this.KryptonPage1.Size = new System.Drawing.Size(342, 515);
            this.KryptonPage1.Text = "HÓA ĐƠN";
            this.KryptonPage1.ToolTipTitle = "Page ToolTip";
            this.KryptonPage1.UniqueName = "6511CCF028984D8C5BA3EBD537881DFF";
            // 
            // grHoaDon
            // 
            this.grHoaDon.AllowUserToAddRows = false;
            this.grHoaDon.AllowUserToDeleteRows = false;
            this.grHoaDon.AllowUserToOrderColumns = true;
            this.grHoaDon.AllowUserToResizeRows = false;
            this.grHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.grHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grHoaDon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHoaDon,
            this.colBan,
            this.colTrangThai});
            this.grHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grHoaDon.GUID = "299695d9-4ab3-442f-8807-56e4ded73042";
            this.grHoaDon.Location = new System.Drawing.Point(0, 57);
            this.grHoaDon.Name = "grHoaDon";
            this.grHoaDon.ReadOnly = true;
            this.grHoaDon.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grHoaDon.ShowCellToolTips = false;
            this.grHoaDon.Size = new System.Drawing.Size(342, 458);
            this.grHoaDon.TabIndex = 0;
            this.grHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grHoaDon_CellFormatting);
            this.grHoaDon.SelectionChanged += new System.EventHandler(this.grHoaDon_SelectionChanged);
            // 
            // colHoaDon
            // 
            this.colHoaDon.DataPropertyName = "NAME";
            this.colHoaDon.HeaderText = "Hóa đơn";
            this.colHoaDon.Name = "colHoaDon";
            this.colHoaDon.ReadOnly = true;
            this.colHoaDon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBan
            // 
            this.colBan.DataPropertyName = "BAN";
            this.colBan.HeaderText = "Bàn";
            this.colBan.Name = "colBan";
            this.colBan.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TRANGTHAI";
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTrangThai.Width = 150;
            // 
            // KryptonPanel2
            // 
            this.KryptonPanel2.Controls.Add(this.txtSoHoaDon);
            this.KryptonPanel2.Controls.Add(this.Label2147483645);
            this.KryptonPanel2.Controls.Add(this.dtNgay);
            this.KryptonPanel2.Controls.Add(this.btnRefresh);
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Size = new System.Drawing.Size(342, 57);
            this.KryptonPanel2.TabIndex = 2;
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.EnterKeyNextControl = false;
            this.txtSoHoaDon.Location = new System.Drawing.Point(54, 29);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(88, 20);
            this.txtSoHoaDon.TabIndex = 22;
            this.txtSoHoaDon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoHoaDon_KeyDown);
            // 
            // Label2147483645
            // 
            this.Label2147483645.AutoSize = true;
            this.Label2147483645.BackColor = System.Drawing.Color.Transparent;
            this.Label2147483645.Location = new System.Drawing.Point(6, 32);
            this.Label2147483645.Name = "Label2147483645";
            this.Label2147483645.Size = new System.Drawing.Size(42, 13);
            this.Label2147483645.TabIndex = 21;
            this.Label2147483645.Text = "Số HĐ:";
            // 
            // dtNgay
            // 
            this.dtNgay.BackColor = System.Drawing.Color.Transparent;
            this.dtNgay.Location = new System.Drawing.Point(24, 3);
            this.dtNgay.LockEvent = false;
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(271, 24);
            this.dtNgay.TabIndex = 1;
            this.dtNgay.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.dtNgay_OnEditValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(180, 27);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Tải dữ liệu";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // KryptonNavigator2
            // 
            this.KryptonNavigator2.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.KryptonNavigator2.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.KryptonNavigator2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonNavigator2.Location = new System.Drawing.Point(0, 0);
            this.KryptonNavigator2.Name = "KryptonNavigator2";
            this.KryptonNavigator2.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.KryptonPage2});
            this.KryptonNavigator2.SelectedIndex = 0;
            this.KryptonNavigator2.Size = new System.Drawing.Size(675, 542);
            this.KryptonNavigator2.TabIndex = 2;
            this.KryptonNavigator2.Text = "KryptonNavigator2";
            // 
            // KryptonPage2
            // 
            this.KryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.KryptonPage2.Controls.Add(this.grMain);
            this.KryptonPage2.Controls.Add(this.KryptonPanel1);
            this.KryptonPage2.Controls.Add(this.btnXoaLuuVet);
            this.KryptonPage2.Flags = 65534;
            this.KryptonPage2.LastVisibleSet = true;
            this.KryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.KryptonPage2.Name = "KryptonPage2";
            this.KryptonPage2.Size = new System.Drawing.Size(673, 515);
            this.KryptonPage2.Text = "CHI TIẾT THAO TÁC";
            this.KryptonPage2.ToolTipTitle = "Page ToolTip";
            this.KryptonPage2.UniqueName = "40B9E8C6DD49472F108EC36FB7E50835";
            // 
            // grMain
            // 
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.FontSize = 0F;
            this.grMain.GUID = "ef70c436-a6cc-48b2-adbd-82ef0fae441a";
            this.grMain.Location = new System.Drawing.Point(0, 32);
            this.grMain.Name = "grMain";
            this.grMain.ReadOnly = true;
            this.grMain.ShowAddButton = false;
            this.grMain.ShowToolbar = false;
            this.grMain.Size = new System.Drawing.Size(673, 483);
            this.grMain.TabIndex = 1;
            this.grMain.ViewConfig = System.Convert.FromBase64String(VIEWCONFIG_MAIN);
            this.grMain.CustomLoadData += new No1Lib.Sys.CustomLoadDataHandler(this.grMain_CustomLoadData);
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.label2);
            this.KryptonPanel1.Controls.Add(this.lueNhanVien);
            this.KryptonPanel1.Controls.Add(this.lblLoc);
            this.KryptonPanel1.Controls.Add(this.txtLoc);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(673, 32);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tài khoản:";
            // 
            // lueNhanVien
            // 
            this.lueNhanVien.BackColor = System.Drawing.Color.White;
            this.lueNhanVien.Location = new System.Drawing.Point(74, 5);
            this.lueNhanVien.Name = "lueNhanVien";
            this.lueNhanVien.ShowManagementMenuItem = false;
            this.lueNhanVien.Size = new System.Drawing.Size(114, 21);
            this.lueNhanVien.TabIndex = 15;
            this.lueNhanVien.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.lueNhanVien_OnEditValueChanged);
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblLoc.Location = new System.Drawing.Point(193, 8);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(62, 13);
            this.lblLoc.TabIndex = 19;
            this.lblLoc.Text = "Lọc dữ liệu:";
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(261, 5);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(95, 20);
            this.txtLoc.TabIndex = 20;
            this.txtLoc.TextChanged += new System.EventHandler(this.txtLoc_TextChanged);
            // 
            // btnXoaLuuVet
            // 
            this.btnXoaLuuVet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaLuuVet.Location = new System.Drawing.Point(381, 244);
            this.btnXoaLuuVet.Name = "btnXoaLuuVet";
            this.btnXoaLuuVet.Size = new System.Drawing.Size(98, 23);
            this.btnXoaLuuVet.TabIndex = 16;
            this.btnXoaLuuVet.Text = "Xóa lưu vết";
            this.btnXoaLuuVet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaLuuVet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaLuuVet.UseVisualStyleBackColor = true;
            this.btnXoaLuuVet.Visible = false;
            this.btnXoaLuuVet.Click += new System.EventHandler(this.btnXoaLuuVet_Click);
            // 
            // LuuVetHoatDong
            // 
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Name = "LuuVetHoatDong";
            this.Size = new System.Drawing.Size(1024, 542);
            this.Load += new System.EventHandler(this.No1UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).EndInit();
            this.KryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).EndInit();
            this.KryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).EndInit();
            this.KryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonNavigator1)).EndInit();
            this.KryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPage1)).EndInit();
            this.KryptonPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            this.KryptonPanel2.ResumeLayout(false);
            this.KryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonNavigator2)).EndInit();
            this.KryptonNavigator2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPage2)).EndInit();
            this.KryptonPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer KryptonSplitContainer1;
        public ComponentFactory.Krypton.Navigator.KryptonNavigator KryptonNavigator1;
        public ComponentFactory.Krypton.Navigator.KryptonPage KryptonPage1;
        public No1Lib.Sys.MiscDataGridView grHoaDon;
        public System.Windows.Forms.DataGridViewTextBoxColumn colHoaDon;
        public System.Windows.Forms.DataGridViewTextBoxColumn colBan;
        public System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        public No1Lib.Sys.No1TextBox txtSoHoaDon;
        public System.Windows.Forms.Label Label2147483645;
        public No1Lib.Sys.FilterDateRange dtNgay;
        public System.Windows.Forms.Button btnRefresh;
        public ComponentFactory.Krypton.Navigator.KryptonNavigator KryptonNavigator2;
        public ComponentFactory.Krypton.Navigator.KryptonPage KryptonPage2;
        public No1Lib.Sys.GridMapper grMain;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Label label2;
        public No1Lib.Sys.No1LookupEdit lueNhanVien;
        public System.Windows.Forms.Label lblLoc;
        public No1Lib.Sys.No1TextBox txtLoc;
        public System.Windows.Forms.Button btnXoaLuuVet;

        public const string VIEWCONFIG_MAIN = @"PERvY3VtZW50RWxlbWVudD4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YWM1MWNhYzUtN2M3MS00MDQxLTg0ZDUtYTk0MjQyNmFhNTdhPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43OTAxMmRjMS1jMWM1LTQ3MjMtYjg5OS0xZDQ0OTc1MzJiZjc8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPk7hu5lpIGR1bmc8L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjA3MWZkYzczLTRjOTItNDg3ZS04MDFmLTE0MjU1YmQxMjJmODwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzkwMTJkYzEtYzFjNS00NzIzLWI4OTktMWQ0NDk3NTMyYmY3PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD42MmVkODlhMS01Y2Y2LTQ5ZmItYWZiYS00ZjczNzhjNGU0YWQ8L0NPTElEPg0KICAgIDxUQUJMRUlEPjc5MDEyZGMxLWMxYzUtNDcyMy1iODk5LTFkNDQ5NzUzMmJmNzwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+ODliODgwMGEtYjUyZC00NTQ2LThjYzQtMDBjYzZmZDRhYWM3PC9DT0xJRD4NCiAgICA8VEFCTEVJRD43OTAxMmRjMS1jMWM1LTQ3MjMtYjg5OS0xZDQ0OTc1MzJiZjc8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmRhZWFiOTAyLTE1NTctNGM2Mi04ZTkyLTc4ZTI3NWY4OTgyMDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzkwMTJkYzEtYzFjNS00NzIzLWI4OTktMWQ0NDk3NTMyYmY3PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD41OWU4ZDVkNy1mOThkLTQyNmItYmEyOS03NjM3ZjU1YjQxMGM8L0NPTElEPg0KICAgIDxUQUJMRUlEPjc5MDEyZGMxLWMxYzUtNDcyMy1iODk5LTFkNDQ5NzUzMmJmNzwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+OTRjNWYzZWMtMzBhNC00MjdhLWI4NDMtNWU5OGFjYTg5MzE3PC9DT0xJRD4NCiAgICA8VEFCTEVJRD43OTAxMmRjMS1jMWM1LTQ3MjMtYjg5OS0xZDQ0OTc1MzJiZjc8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MDY5MzQ4OWMtZGRjMi00ZDI2LWI3YWUtNzM5YWZlMGI4NWYyPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43OTAxMmRjMS1jMWM1LTQ3MjMtYjg5OS0xZDQ0OTc1MzJiZjc8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjQwMjJiODNiLTI4NTUtNGRjNS04NTkwLTZjZDllMDAyNWU5YTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzkwMTJkYzEtYzFjNS00NzIzLWI4OTktMWQ0NDk3NTMyYmY3PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KPC9Eb2N1bWVudEVsZW1lbnQ+";
    }
}
