namespace No1Run
{
    partial class ThongKeDoanhThu
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
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dtNgay = new No1Lib.Sys.FilterDateRange();
            this.Label1 = new System.Windows.Forms.Label();
            this.lueCuaHang = new No1Lib.Sys.No1LookupEdit();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.KryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.grMain = new No1Lib.Sys.GridMapper();
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblTienHang = new System.Windows.Forms.Label();
            this.lblTienGio = new System.Windows.Forms.Label();
            this.lblGiamGiaTienHang = new System.Windows.Forms.Label();
            this.lblGiamGiaTienGio = new System.Windows.Forms.Label();
            this.Label33 = new System.Windows.Forms.Label();
            this.lblPhiDichVu = new System.Windows.Forms.Label();
            this.lblThue = new System.Windows.Forms.Label();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.lblTienHangVal = new System.Windows.Forms.Label();
            this.lblTienGioVal = new System.Windows.Forms.Label();
            this.lblGiamGiaTiengHangVal = new System.Windows.Forms.Label();
            this.lblGiamGiaTienGioVal = new System.Windows.Forms.Label();
            this.lblTongGiamGiaVal = new System.Windows.Forms.Label();
            this.lblPhiDichVuVal = new System.Windows.Forms.Label();
            this.lblThueVal = new System.Windows.Forms.Label();
            this.lblTongCongVal = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.lblCong = new System.Windows.Forms.Label();
            this.lblTienMatVal = new System.Windows.Forms.Label();
            this.lblTienTheVal = new System.Windows.Forms.Label();
            this.lblChuyenKhoanVal = new System.Windows.Forms.Label();
            this.lblTruTichLuyVal = new System.Windows.Forms.Label();
            this.lblTheTraTruocVal = new System.Windows.Forms.Label();
            this.lblVoucher = new System.Windows.Forms.Label();
            this.lblCongNoVal = new System.Windows.Forms.Label();
            this.lblThuVal = new System.Windows.Forms.Label();
            this.lblChiVal = new System.Windows.Forms.Label();
            this.lblCongVal = new System.Windows.Forms.Label();
            this.grDetail = new No1Lib.Sys.GridMapper();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).BeginInit();
            this.KryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).BeginInit();
            this.KryptonSplitContainer1.Panel2.SuspendLayout();
            this.KryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            this.KryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.btnIn);
            this.KryptonPanel1.Controls.Add(this.btnRefresh);
            this.KryptonPanel1.Controls.Add(this.lueCuaHang);
            this.KryptonPanel1.Controls.Add(this.Label1);
            this.KryptonPanel1.Controls.Add(this.dtNgay);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(1024, 31);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // dtNgay
            // 
            this.dtNgay.BackColor = System.Drawing.Color.Transparent;
            this.dtNgay.EditValue = null;
            this.dtNgay.Location = new System.Drawing.Point(3, 3);
            this.dtNgay.LockEvent = false;
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(271, 24);
            this.dtNgay.TabIndex = 1;
            this.dtNgay.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.dtNgay_OnEditValueChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(281, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Cửa hàng:";
            // 
            // lueCuaHang
            // 
            this.lueCuaHang.BackColor = System.Drawing.Color.White;
            this.lueCuaHang.Location = new System.Drawing.Point(343, 5);
            this.lueCuaHang.Name = "lueCuaHang";
            this.lueCuaHang.Size = new System.Drawing.Size(150, 21);
            this.lueCuaHang.TabIndex = 6;
            this.lueCuaHang.CustomLoadData += new No1Lib.Sys.CustomLoadDataHandler(this.lueCuaHang_CustomLoadData);
            this.lueCuaHang.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.lueCuaHang_OnEditValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(511, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh (F5)";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(628, 3);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(99, 23);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "In báo cáo";
            this.btnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 31);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            // 
            // KryptonSplitContainer1.Panel1
            // 
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.grMain);
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.KryptonPanel2);
            // 
            // KryptonSplitContainer1.Panel2
            // 
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.grDetail);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(1024, 512);
            this.KryptonSplitContainer1.SplitterDistance = 606;
            this.KryptonSplitContainer1.TabIndex = 1;
            // 
            // grMain
            // 
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.FontSize = 0F;
            this.grMain.GUID = "2723e0ca-3598-4583-b817-6da1c4fe5bf8";
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.ReadOnly = true;
            this.grMain.ShowAddButton = false;
            this.grMain.ShowToolbar = false;
            this.grMain.Size = new System.Drawing.Size(606, 270);
            this.grMain.ViewConfig = System.Convert.FromBase64String(VIEWCONFIG_MAIN);
            this.grMain.TabIndex = 0;
            this.grMain.CustomLoadData += new No1Lib.Sys.CustomLoadDataHandler(this.grMain_CustomLoadData);
            // 
            // KryptonPanel2
            // 
            this.KryptonPanel2.Controls.Add(this.lblVoucher);
            this.KryptonPanel2.Controls.Add(this.Label35);
            this.KryptonPanel2.Controls.Add(this.lblCongVal);
            this.KryptonPanel2.Controls.Add(this.lblCong);
            this.KryptonPanel2.Controls.Add(this.lblTongGiamGiaVal);
            this.KryptonPanel2.Controls.Add(this.Label33);
            this.KryptonPanel2.Controls.Add(this.lblTongCongVal);
            this.KryptonPanel2.Controls.Add(this.lblThueVal);
            this.KryptonPanel2.Controls.Add(this.lblPhiDichVuVal);
            this.KryptonPanel2.Controls.Add(this.lblGiamGiaTienGioVal);
            this.KryptonPanel2.Controls.Add(this.lblGiamGiaTiengHangVal);
            this.KryptonPanel2.Controls.Add(this.lblTienGioVal);
            this.KryptonPanel2.Controls.Add(this.lblChiVal);
            this.KryptonPanel2.Controls.Add(this.Label25);
            this.KryptonPanel2.Controls.Add(this.lblThuVal);
            this.KryptonPanel2.Controls.Add(this.Label23);
            this.KryptonPanel2.Controls.Add(this.lblCongNoVal);
            this.KryptonPanel2.Controls.Add(this.Label21);
            this.KryptonPanel2.Controls.Add(this.lblTheTraTruocVal);
            this.KryptonPanel2.Controls.Add(this.Label19);
            this.KryptonPanel2.Controls.Add(this.lblTruTichLuyVal);
            this.KryptonPanel2.Controls.Add(this.Label17);
            this.KryptonPanel2.Controls.Add(this.lblChuyenKhoanVal);
            this.KryptonPanel2.Controls.Add(this.Label15);
            this.KryptonPanel2.Controls.Add(this.lblTienTheVal);
            this.KryptonPanel2.Controls.Add(this.Label13);
            this.KryptonPanel2.Controls.Add(this.lblTienMatVal);
            this.KryptonPanel2.Controls.Add(this.Label11);
            this.KryptonPanel2.Controls.Add(this.lblTienHangVal);
            this.KryptonPanel2.Controls.Add(this.lblTongCong);
            this.KryptonPanel2.Controls.Add(this.lblThue);
            this.KryptonPanel2.Controls.Add(this.lblPhiDichVu);
            this.KryptonPanel2.Controls.Add(this.lblGiamGiaTienGio);
            this.KryptonPanel2.Controls.Add(this.lblGiamGiaTienHang);
            this.KryptonPanel2.Controls.Add(this.lblTienGio);
            this.KryptonPanel2.Controls.Add(this.lblTienHang);
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 270);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Size = new System.Drawing.Size(606, 242);
            this.KryptonPanel2.TabIndex = 1;
            // 
            // lblTienHang
            // 
            this.lblTienHang.AutoSize = true;
            this.lblTienHang.BackColor = System.Drawing.Color.Transparent;
            this.lblTienHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienHang.Location = new System.Drawing.Point(8, 6);
            this.lblTienHang.Name = "lblTienHang";
            this.lblTienHang.Size = new System.Drawing.Size(84, 15);
            this.lblTienHang.TabIndex = 0;
            this.lblTienHang.Text = "TIỀN HÀNG:";
            // 
            // lblTienGio
            // 
            this.lblTienGio.AutoSize = true;
            this.lblTienGio.BackColor = System.Drawing.Color.Transparent;
            this.lblTienGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienGio.Location = new System.Drawing.Point(8, 27);
            this.lblTienGio.Name = "lblTienGio";
            this.lblTienGio.Size = new System.Drawing.Size(70, 15);
            this.lblTienGio.TabIndex = 1;
            this.lblTienGio.Text = "TIỀN GIỜ:";
            // 
            // lblGiamGiaTienHang
            // 
            this.lblGiamGiaTienHang.AutoSize = true;
            this.lblGiamGiaTienHang.BackColor = System.Drawing.Color.Transparent;
            this.lblGiamGiaTienHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblGiamGiaTienHang.Location = new System.Drawing.Point(8, 50);
            this.lblGiamGiaTienHang.Name = "lblGiamGiaTienHang";
            this.lblGiamGiaTienHang.Size = new System.Drawing.Size(148, 15);
            this.lblGiamGiaTienHang.TabIndex = 2;
            this.lblGiamGiaTienHang.Text = "GIẢM GIÁ TIỀN HÀNG:";
            // 
            // lblGiamGiaTienGio
            // 
            this.lblGiamGiaTienGio.AutoSize = true;
            this.lblGiamGiaTienGio.BackColor = System.Drawing.Color.Transparent;
            this.lblGiamGiaTienGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblGiamGiaTienGio.Location = new System.Drawing.Point(8, 74);
            this.lblGiamGiaTienGio.Name = "lblGiamGiaTienGio";
            this.lblGiamGiaTienGio.Size = new System.Drawing.Size(134, 15);
            this.lblGiamGiaTienGio.TabIndex = 3;
            this.lblGiamGiaTienGio.Text = "GIẢM GIÁ TIỀN GIỜ:";
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.BackColor = System.Drawing.Color.Transparent;
            this.Label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label33.Location = new System.Drawing.Point(8, 99);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(113, 15);
            this.Label33.TabIndex = 30;
            this.Label33.Text = "TỔNG GIẢM GIÁ:";
            // 
            // lblPhiDichVu
            // 
            this.lblPhiDichVu.AutoSize = true;
            this.lblPhiDichVu.BackColor = System.Drawing.Color.Transparent;
            this.lblPhiDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhiDichVu.Location = new System.Drawing.Point(8, 123);
            this.lblPhiDichVu.Name = "lblPhiDichVu";
            this.lblPhiDichVu.Size = new System.Drawing.Size(93, 15);
            this.lblPhiDichVu.TabIndex = 4;
            this.lblPhiDichVu.Text = "PHÍ DỊCH VỤ:";
            // 
            // lblThue
            // 
            this.lblThue.AutoSize = true;
            this.lblThue.BackColor = System.Drawing.Color.Transparent;
            this.lblThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblThue.Location = new System.Drawing.Point(8, 147);
            this.lblThue.Name = "lblThue";
            this.lblThue.Size = new System.Drawing.Size(48, 15);
            this.lblThue.TabIndex = 5;
            this.lblThue.Text = "THUẾ:";
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.BackColor = System.Drawing.Color.Transparent;
            this.lblTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongCong.Location = new System.Drawing.Point(8, 171);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(133, 15);
            this.lblTongCong.TabIndex = 6;
            this.lblTongCong.Text = "TỔNG DOANH THU:";
            // 
            // lblTienHangVal
            // 
            this.lblTienHangVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTienHangVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienHangVal.Location = new System.Drawing.Point(175, 6);
            this.lblTienHangVal.Name = "lblTienHangVal";
            this.lblTienHangVal.Size = new System.Drawing.Size(100, 16);
            this.lblTienHangVal.TabIndex = 7;
            this.lblTienHangVal.Text = "0";
            this.lblTienHangVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTienGioVal
            // 
            this.lblTienGioVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTienGioVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienGioVal.Location = new System.Drawing.Point(175, 27);
            this.lblTienGioVal.Name = "lblTienGioVal";
            this.lblTienGioVal.Size = new System.Drawing.Size(100, 16);
            this.lblTienGioVal.TabIndex = 24;
            this.lblTienGioVal.Text = "0";
            this.lblTienGioVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGiamGiaTiengHangVal
            // 
            this.lblGiamGiaTiengHangVal.BackColor = System.Drawing.Color.Transparent;
            this.lblGiamGiaTiengHangVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblGiamGiaTiengHangVal.Location = new System.Drawing.Point(175, 50);
            this.lblGiamGiaTiengHangVal.Name = "lblGiamGiaTiengHangVal";
            this.lblGiamGiaTiengHangVal.Size = new System.Drawing.Size(100, 16);
            this.lblGiamGiaTiengHangVal.TabIndex = 25;
            this.lblGiamGiaTiengHangVal.Text = "0";
            this.lblGiamGiaTiengHangVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGiamGiaTienGioVal
            // 
            this.lblGiamGiaTienGioVal.BackColor = System.Drawing.Color.Transparent;
            this.lblGiamGiaTienGioVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblGiamGiaTienGioVal.Location = new System.Drawing.Point(175, 75);
            this.lblGiamGiaTienGioVal.Name = "lblGiamGiaTienGioVal";
            this.lblGiamGiaTienGioVal.Size = new System.Drawing.Size(100, 16);
            this.lblGiamGiaTienGioVal.TabIndex = 26;
            this.lblGiamGiaTienGioVal.Text = "0";
            this.lblGiamGiaTienGioVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTongGiamGiaVal
            // 
            this.lblTongGiamGiaVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTongGiamGiaVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongGiamGiaVal.Location = new System.Drawing.Point(175, 98);
            this.lblTongGiamGiaVal.Name = "lblTongGiamGiaVal";
            this.lblTongGiamGiaVal.Size = new System.Drawing.Size(100, 16);
            this.lblTongGiamGiaVal.TabIndex = 31;
            this.lblTongGiamGiaVal.Text = "0";
            this.lblTongGiamGiaVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPhiDichVuVal
            // 
            this.lblPhiDichVuVal.BackColor = System.Drawing.Color.Transparent;
            this.lblPhiDichVuVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhiDichVuVal.Location = new System.Drawing.Point(175, 123);
            this.lblPhiDichVuVal.Name = "lblPhiDichVuVal";
            this.lblPhiDichVuVal.Size = new System.Drawing.Size(100, 16);
            this.lblPhiDichVuVal.TabIndex = 27;
            this.lblPhiDichVuVal.Text = "0";
            this.lblPhiDichVuVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThueVal
            // 
            this.lblThueVal.BackColor = System.Drawing.Color.Transparent;
            this.lblThueVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblThueVal.Location = new System.Drawing.Point(175, 147);
            this.lblThueVal.Name = "lblThueVal";
            this.lblThueVal.Size = new System.Drawing.Size(100, 16);
            this.lblThueVal.TabIndex = 28;
            this.lblThueVal.Text = "0";
            this.lblThueVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTongCongVal
            // 
            this.lblTongCongVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTongCongVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongCongVal.Location = new System.Drawing.Point(175, 171);
            this.lblTongCongVal.Name = "lblTongCongVal";
            this.lblTongCongVal.Size = new System.Drawing.Size(100, 16);
            this.lblTongCongVal.TabIndex = 29;
            this.lblTongCongVal.Text = "0";
            this.lblTongCongVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label11.Location = new System.Drawing.Point(344, 6);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(74, 15);
            this.Label11.TabIndex = 8;
            this.Label11.Text = "TIỀN MẶT:";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label13.Location = new System.Drawing.Point(344, 27);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(73, 15);
            this.Label13.TabIndex = 10;
            this.Label13.Text = "TIỀN THẺ:";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.BackColor = System.Drawing.Color.Transparent;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label15.Location = new System.Drawing.Point(344, 50);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(118, 15);
            this.Label15.TabIndex = 12;
            this.Label15.Text = "CHUYỂN KHOẢN:";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label17.Location = new System.Drawing.Point(344, 74);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(104, 15);
            this.Label17.TabIndex = 14;
            this.Label17.Text = "TRỪ TÍCH LŨY:";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.BackColor = System.Drawing.Color.Transparent;
            this.Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label19.Location = new System.Drawing.Point(344, 99);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(119, 15);
            this.Label19.TabIndex = 16;
            this.Label19.Text = "THẺ TRẢ TRƯỚC:";
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.BackColor = System.Drawing.Color.Transparent;
            this.Label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label35.Location = new System.Drawing.Point(343, 124);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(77, 15);
            this.Label35.TabIndex = 36;
            this.Label35.Text = "VOUCHER:";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label21.Location = new System.Drawing.Point(344, 147);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(74, 15);
            this.Label21.TabIndex = 18;
            this.Label21.Text = "CÔNG NỢ:";
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.BackColor = System.Drawing.Color.Transparent;
            this.Label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label23.Location = new System.Drawing.Point(344, 171);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(79, 15);
            this.Label23.TabIndex = 20;
            this.Label23.Text = "THU KHÁC:";
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.BackColor = System.Drawing.Color.Transparent;
            this.Label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label25.Location = new System.Drawing.Point(344, 193);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(74, 15);
            this.Label25.TabIndex = 22;
            this.Label25.Text = "CHI KHÁC:";
            // 
            // lblCong
            // 
            this.lblCong.AutoSize = true;
            this.lblCong.BackColor = System.Drawing.Color.Transparent;
            this.lblCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCong.Location = new System.Drawing.Point(4, 219);
            this.lblCong.Name = "lblCong";
            this.lblCong.Size = new System.Drawing.Size(445, 15);
            this.lblCong.TabIndex = 32;
            this.lblCong.Text = "TỔNG THỰC THU (TIỀN MẶT + THẺ + CHUYỂN KHOẢN + THU - CHI):";
            // 
            // lblTienMatVal
            // 
            this.lblTienMatVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTienMatVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienMatVal.Location = new System.Drawing.Point(490, 6);
            this.lblTienMatVal.Name = "lblTienMatVal";
            this.lblTienMatVal.Size = new System.Drawing.Size(100, 16);
            this.lblTienMatVal.TabIndex = 9;
            this.lblTienMatVal.Text = "0";
            this.lblTienMatVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTienTheVal
            // 
            this.lblTienTheVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTienTheVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienTheVal.Location = new System.Drawing.Point(490, 27);
            this.lblTienTheVal.Name = "lblTienTheVal";
            this.lblTienTheVal.Size = new System.Drawing.Size(100, 16);
            this.lblTienTheVal.TabIndex = 11;
            this.lblTienTheVal.Text = "0";
            this.lblTienTheVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblChuyenKhoanVal
            // 
            this.lblChuyenKhoanVal.BackColor = System.Drawing.Color.Transparent;
            this.lblChuyenKhoanVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblChuyenKhoanVal.Location = new System.Drawing.Point(490, 50);
            this.lblChuyenKhoanVal.Name = "lblChuyenKhoanVal";
            this.lblChuyenKhoanVal.Size = new System.Drawing.Size(100, 16);
            this.lblChuyenKhoanVal.TabIndex = 13;
            this.lblChuyenKhoanVal.Text = "0";
            this.lblChuyenKhoanVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTruTichLuyVal
            // 
            this.lblTruTichLuyVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTruTichLuyVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTruTichLuyVal.Location = new System.Drawing.Point(490, 74);
            this.lblTruTichLuyVal.Name = "lblTruTichLuyVal";
            this.lblTruTichLuyVal.Size = new System.Drawing.Size(100, 16);
            this.lblTruTichLuyVal.TabIndex = 15;
            this.lblTruTichLuyVal.Text = "0";
            this.lblTruTichLuyVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTheTraTruocVal
            // 
            this.lblTheTraTruocVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTheTraTruocVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTheTraTruocVal.Location = new System.Drawing.Point(490, 99);
            this.lblTheTraTruocVal.Name = "lblTheTraTruocVal";
            this.lblTheTraTruocVal.Size = new System.Drawing.Size(100, 16);
            this.lblTheTraTruocVal.TabIndex = 17;
            this.lblTheTraTruocVal.Text = "0";
            this.lblTheTraTruocVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVoucher
            // 
            this.lblVoucher.BackColor = System.Drawing.Color.Transparent;
            this.lblVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblVoucher.Location = new System.Drawing.Point(489, 124);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(100, 16);
            this.lblVoucher.TabIndex = 37;
            this.lblVoucher.Text = "0";
            this.lblVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCongNoVal
            // 
            this.lblCongNoVal.BackColor = System.Drawing.Color.Transparent;
            this.lblCongNoVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCongNoVal.Location = new System.Drawing.Point(490, 147);
            this.lblCongNoVal.Name = "lblCongNoVal";
            this.lblCongNoVal.Size = new System.Drawing.Size(100, 16);
            this.lblCongNoVal.TabIndex = 19;
            this.lblCongNoVal.Text = "0";
            this.lblCongNoVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThuVal
            // 
            this.lblThuVal.BackColor = System.Drawing.Color.Transparent;
            this.lblThuVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblThuVal.Location = new System.Drawing.Point(490, 171);
            this.lblThuVal.Name = "lblThuVal";
            this.lblThuVal.Size = new System.Drawing.Size(100, 16);
            this.lblThuVal.TabIndex = 21;
            this.lblThuVal.Text = "0";
            this.lblThuVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblChiVal
            // 
            this.lblChiVal.BackColor = System.Drawing.Color.Transparent;
            this.lblChiVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblChiVal.Location = new System.Drawing.Point(490, 193);
            this.lblChiVal.Name = "lblChiVal";
            this.lblChiVal.Size = new System.Drawing.Size(100, 16);
            this.lblChiVal.TabIndex = 23;
            this.lblChiVal.Text = "0";
            this.lblChiVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCongVal
            // 
            this.lblCongVal.BackColor = System.Drawing.Color.Transparent;
            this.lblCongVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCongVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCongVal.Location = new System.Drawing.Point(490, 218);
            this.lblCongVal.Name = "lblCongVal";
            this.lblCongVal.Size = new System.Drawing.Size(100, 16);
            this.lblCongVal.TabIndex = 33;
            this.lblCongVal.Text = "0";
            this.lblCongVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grDetail
            // 
            this.grDetail.AllowEmpty = true;
            this.grDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetail.FontSize = 0F;
            this.grDetail.GUID = "fee19fa3-a4ca-4c48-a9e7-0fd8929c503b";
            this.grDetail.Location = new System.Drawing.Point(0, 0);
            this.grDetail.Name = "grDetail";
            this.grDetail.ReadOnly = true;
            this.grDetail.ShowAddButton = false;
            this.grDetail.ShowToolbar = false;
            this.grDetail.Size = new System.Drawing.Size(413, 512);
            this.grDetail.ViewConfig = System.Convert.FromBase64String(VIEWCONFIG_DETAIL);
            this.grDetail.TabIndex = 1;
            this.grDetail.CustomLoadData += new No1Lib.Sys.CustomLoadDataHandler(this.grDetail_CustomLoadData);
            // 
            // ThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.KryptonPanel1);
            this.Name = "ThongKeDoanhThu";
            this.Size = new System.Drawing.Size(1024, 543);
            this.Load += new System.EventHandler(this.No1UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).EndInit();
            this.KryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).EndInit();
            this.KryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).EndInit();
            this.KryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            this.KryptonPanel2.ResumeLayout(false);
            this.KryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public No1Lib.Sys.FilterDateRange dtNgay;
        public System.Windows.Forms.Label Label1;
        public No1Lib.Sys.No1LookupEdit lueCuaHang;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnIn;
        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer KryptonSplitContainer1;
        public No1Lib.Sys.GridMapper grMain;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        public System.Windows.Forms.Label lblTienHang;
        public System.Windows.Forms.Label lblTienGio;
        public System.Windows.Forms.Label lblGiamGiaTienHang;
        public System.Windows.Forms.Label lblGiamGiaTienGio;
        public System.Windows.Forms.Label Label33;
        public System.Windows.Forms.Label lblPhiDichVu;
        public System.Windows.Forms.Label lblThue;
        public System.Windows.Forms.Label lblTongCong;
        public System.Windows.Forms.Label lblTienHangVal;
        public System.Windows.Forms.Label lblTienGioVal;
        public System.Windows.Forms.Label lblGiamGiaTiengHangVal;
        public System.Windows.Forms.Label lblGiamGiaTienGioVal;
        public System.Windows.Forms.Label lblTongGiamGiaVal;
        public System.Windows.Forms.Label lblPhiDichVuVal;
        public System.Windows.Forms.Label lblThueVal;
        public System.Windows.Forms.Label lblTongCongVal;
        public System.Windows.Forms.Label Label11;
        public System.Windows.Forms.Label Label13;
        public System.Windows.Forms.Label Label15;
        public System.Windows.Forms.Label Label17;
        public System.Windows.Forms.Label Label19;
        public System.Windows.Forms.Label Label35;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label23;
        public System.Windows.Forms.Label Label25;
        public System.Windows.Forms.Label lblCong;
        public System.Windows.Forms.Label lblTienMatVal;
        public System.Windows.Forms.Label lblTienTheVal;
        public System.Windows.Forms.Label lblChuyenKhoanVal;
        public System.Windows.Forms.Label lblTruTichLuyVal;
        public System.Windows.Forms.Label lblTheTraTruocVal;
        public System.Windows.Forms.Label lblVoucher;
        public System.Windows.Forms.Label lblCongNoVal;
        public System.Windows.Forms.Label lblThuVal;
        public System.Windows.Forms.Label lblChiVal;
        public System.Windows.Forms.Label lblCongVal;
        public No1Lib.Sys.GridMapper grDetail;

        #region Grid ViewConfigs
        public const string VIEWCONFIG_MAIN = "PERvY3VtZW50RWxlbWVudD4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+Y2Q2ODJiOTMtNmQyZi00Mjc0LWEyMzItMDkyZDhkMjM5YjBiPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjA2NzUyZDQ5LWY2OWUtNDAzNC1iYWRjLTQ1Y2FhZThlN2MwMTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5hNGNjODYyMS02YWVmLTQ4MTMtYjk2ZS04ZDEwMDU2MzMyZmQ8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04+QkVUV0VFTiBARnJvbURhdGUgQU5EIEBUb0RhdGU8L0NPTkRJVElPTj4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MGM2M2FkMjQtM2Y1Yi00NjRlLTg5MDgtYTAxNDM5ODI5ZTM1PC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YTM2NTk0ZjMtNDNmMC00OTg2LThmMzUtOWI2ZWVmYWYyMWJiPC9DT0xJRD4NCiAgICA8VEFCTEVJRD41ZmNjNTcxYS02NjJkLTQ5NTMtYTgzZi02MDA0YzczMmY0Mzk8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPktow6FjaCBow6BuZzwvQ0FQVElPTj4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPjBjNjNhZDI0LTNmNWItNDY0ZS04OTA4LWEwMTQzOTgyOWUzNTwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YjJmMDhhNWItZjA2Zi00YjgyLTkxYjMtNjcxNzE1MGQyMTA2PC9DT0xJRD4NCiAgICA8VEFCTEVJRD41ZmNjNTcxYS02NjJkLTQ5NTMtYTgzZi02MDA0YzczMmY0Mzk8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICAgIDxQQVJFTlRJRD4wYzYzYWQyNC0zZjViLTQ2NGUtODkwOC1hMDE0Mzk4MjllMzU8L1BBUkVOVElEPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmNjYmM2NTM4LTJmOWQtNGJlMC05Mjc2LTEzOWYxOWY2ZjA0NDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NWZjYzU3MWEtNjYyZC00OTUzLWE4M2YtNjAwNGM3MzJmNDM5PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgICA8UEFSRU5USUQ+MGM2M2FkMjQtM2Y1Yi00NjRlLTg5MDgtYTAxNDM5ODI5ZTM1PC9QQVJFTlRJRD4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4yZGI0OTQzZS0xYjRlLTQxYjItODFmMS0zNTEwYjA3YjNhMTg8L0NPTElEPg0KICAgIDxUQUJMRUlEPjVmY2M1NzFhLTY2MmQtNDk1My1hODNmLTYwMDRjNzMyZjQzOTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPjBjNjNhZDI0LTNmNWItNDY0ZS04OTA4LWEwMTQzOTgyOWUzNTwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+ZmFsc2U8L0NIRUNLRUQ+DQogICAgPENPTElEPjJmNDEwZjE3LTBhN2MtNGVkZi05Y2U3LTg1YjlhN2JmOWI1ZDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTj49MDwvQ09ORElUSU9OPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5iNzU4OTQxYi02MmIxLTQ0YTgtOTk0Mi1lYmEyMDgyNjM0YWU8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+ZGU3NzA4Y2MtMjE4Yi00MzY5LWI2M2EtYTUxNTZiMDNjMWYwPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjAxNTI5ZTYwLTJkY2YtNDA1ZS04OGY1LTFjYjNhNDIxNDRkMjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD40YTE2OWNkMy0zY2ZiLTRkMjgtYTBjNi1mMmQ0OTAzZTVmNjU8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YmNkODQ0M2EtMzQzNi00Nzg1LThiMWUtNmJiNWM1ZWM1YmQyPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjE5YTMzYWY0LTYyNGMtNGU0OS04OThiLWY3ZjNkZDUwM2UzNjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD50cnVlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjc0NGU2ZjJhLTE0ODItNDAwZS04YTU5LWUxNTE5YTg4YTc3ZDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+ZTVmNTkzN2EtOWE1ZC00OGNjLWJlYWYtNGZjZDQ4ZDg0YWFmPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5OaMOibiB2acOqbjwvQ0FQVElPTj4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPjE5YTMzYWY0LTYyNGMtNGU0OS04OThiLWY3ZjNkZDUwM2UzNjwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MDUyNGExNzMtMGRlZS00Y2FkLTkyOTMtNjVkYmQ0NjY2ZGJjPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmFkMTAxMGJhLTRiNTEtNDIxZS05ZWFlLTE1N2ZlNGM2MTI5ZTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUPkFTQzwvU09SVD4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmM1YTY5OGYzLTg4ZjYtNDRmNS05MzdhLTc4NTEwNmM4NGRiMTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4yYjEwMDQzNS0xMGEzLTQ0MTEtOTBkOS0wMWE4NGZmNTI3MjM8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YmMzNjRmYjctOWY5Mi00YjVhLWFhODctYjdmYjgxZGRhNGZjPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+NTNjZThmMWMtZTRiOC00ZDYwLWE4NGItMTg4MWMyMzhhNmE1PC9DT0xJRD4NCiAgICA8VEFCTEVJRD4xOGFmNzA4OS1hMDQyLTQxYWEtYTc1Zi1jYTkxOTE4YTcxODg8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPlRoYW5oIHRvw6FuIGLhu59pPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgICA8UEFSRU5USUQ+YmMzNjRmYjctOWY5Mi00YjVhLWFhODctYjdmYjgxZGRhNGZjPC9QQVJFTlRJRD4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD45MmJjNTFhYi02MzYwLTQwYWYtODllNS04YTdkMTExZjNkNDY8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+dHJ1ZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD44ZDdjNTllNi1jMTJiLTQ0ZjMtYmM1Yy00M2VjNzMyNmRkZmU8L0NPTElEPg0KICAgIDxUQUJMRUlEPjc4MGE5ZGFmLWIyYjctNDE3Yy04ZmYzLTIxNzAwZmFiNjk5MDwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+U+G7kSBwaGnhur91IMSR4bq3dCBow6BuZzwvQ0FQVElPTj4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPjkyYmM1MWFiLTYzNjAtNDBhZi04OWU1LThhN2QxMTFmM2Q0NjwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+ZmFsc2U8L0NIRUNLRUQ+DQogICAgPENPTElEPjFjMjRiMTliLTkwZmYtNGZlNi1hNzA5LTc5Yzk0Y2EyNmQ2NTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTj49MzA8L0NPTkRJVElPTj4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MzkyYzU2YjQtZTBkMi00NGM1LWIwZGYtMjI3ZDViZTc1NzNkPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjcwMzMzZDMyLWRiMTctNDQzMS05NzkzLTllMWZmYmNmMDM3MTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD40YWNkNzk3ZS0wYjRhLTQxMzMtODhhYi02YzEzNTRlYTA2ZDc8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+dHJ1ZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5iYjAwYzQ1Yy05YjViLTQwOTMtOTBjZi05NTExOGNmYzI1OTE8L0NPTElEPg0KICAgIDxUQUJMRUlEPmMxZmUyMjljLTdiNTUtNGM1Yy1hYmFjLTQyYzljMDU5YzczYjwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+TcOjIHRo4bq7IHRy4bqjIHRyxrDhu5tjPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgICA8UEFSRU5USUQ+NGFjZDc5N2UtMGI0YS00MTMzLTg4YWItNmMxMzU0ZWEwNmQ3PC9QQVJFTlRJRD4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5kNDhkMWQ0Yi0zZTlmLTRhMDMtOGU3NS02YTZlY2I1ZTMzNGQ8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+NGUxMTFmYzctNTA1MS00Y2VkLTlmZTQtNjQ1MmI2NWY3ZTM5PC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjdkYzkxZDRjLWZhMzItNGI0MC1hOTBjLTQwZGIxNzIyMzViYTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD45ZmNkMzhhOC02Y2Q1LTQzNjMtOGY3NC1iOGYxNWUyZGY1YjA8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MjU2MWJkYzYtNTYzZC00NGMxLTg5MDUtM2M5ODI1NjNlMDVkPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MDRjY2UwMzktMTI4Ni00NDlkLWFmOTItYTBkOGJiNzQyNWJiPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5mMjI4ODM0NS0wMzFhLTRlMWItYTc2ZC0zYjJlNTM3Njc0YTY8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPkLDoG48L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICAgIDxQQVJFTlRJRD4yNTYxYmRjNi01NjNkLTQ0YzEtODkwNS0zYzk4MjU2M2UwNWQ8L1BBUkVOVElEPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjNlNzY3MmVhLTJkNDMtNGYyZC04NDEyLWIyZTZjYWM1NTA4NDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5HaeG7nSB2w6BvPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD44ZTRmNzA0Mi00NzlmLTQzY2MtYTljMy1lNTllMzRiYzljZTQ8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+R2nhu50gcmE8L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjg4YTY0YTkyLTkyZmQtNDNjOC04ZWRjLTkwNTQ0YmRiZDI1ZTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5hMTIyYTYxYy1kODk4LTRjYjUtYjUyNS03MzA3YzAwODU1OWE8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+M2E4OWJmNGMtMTgwOS00OTA4LTk4Y2EtMjdjNzc3ZDgyYjVmPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjdhZTUwYWVlLTE4N2QtNDZjZS04NjUxLWJkYTU4MDg1YzE3NzwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD43YzYwN2RmZC02NjY0LTQyYTctYmJiNS1kYmJiODBlMjc2OTM8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+NWY2YWJmNzUtNzliMS00ZmE5LTk2NjctNDczMjYyNDQ0NGVjPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjM0ZTRiZGY4LTI4ZGItNGI4YS1iYmZlLTUxN2FjNDNlNDc0ODwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD41N2YzM2RlMy0zNTc4LTQ3OWUtODhmNi1jOTYyODBlZTYyYzM8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+Q8OybiBu4bujPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5mN2M5ZGYzNy1jMjQ4LTQ1MGQtYWRhNC02NjIyYzlhMDJlYjQ8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+VGnhu4FuIGjDoG5nPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5lZWIwOTJhMi0xNDJmLTRjNmEtOGJjZi1kZGExYThjYWMxZmM8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+R2nhuqNtIG3hurd0IGjDoG5nPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KPC9Eb2N1bWVudEVsZW1lbnQ+";
        public const string VIEWCONFIG_DETAIL = "PERvY3VtZW50RWxlbWVudD4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MjRiNWQyOWYtZWI5Ni00MzI5LThlMWEtODZjNThkNjM4NjI2PC9DT0xJRD4NCiAgICA8VEFCTEVJRD5hNzBhZWMwNi1mNjUzLTQxYWYtODliNS1iMzQ5NDNhNDllMGM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjcwYzk1ZDAyLWU3YzEtNGNkOC1iYWFlLTIwZDEyZDdjOTRiNzwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+YTcwYWVjMDYtZjY1My00MWFmLTg5YjUtYjM0OTQzYTQ5ZTBjPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD50cnVlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjdiNzkzMTYyLTgyMTktNDZlMy1hNDcxLTg2ZGE4MzNmYTc2MjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+YTRhMTYyMTYtYWVlOS00ZGQzLTlmOTItYzFlNGQ4NWMwNmEyPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgICA8UEFSRU5USUQ+NzBjOTVkMDItZTdjMS00Y2Q4LWJhYWUtMjBkMTJkN2M5NGI3PC9QQVJFTlRJRD4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD41YWU0MDIyNy1mMDZmLTQ5ZjMtYmEwYS0wYjhkN2RjZjJkYjg8L0NPTElEPg0KICAgIDxUQUJMRUlEPmE0YTE2MjE2LWFlZTktNGRkMy05ZjkyLWMxZTRkODVjMDZhMjwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPjcwYzk1ZDAyLWU3YzEtNGNkOC1iYWFlLTIwZDEyZDdjOTRiNzwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+Njc2Y2VhNTctOTM2YS00ZWI1LWJjZDUtOWQ5NDFkYTVhOTMxPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5hNGExNjIxNi1hZWU5LTRkZDMtOWY5Mi1jMWU0ZDg1YzA2YTI8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICAgIDxQQVJFTlRJRD43MGM5NWQwMi1lN2MxLTRjZDgtYmFhZS0yMGQxMmQ3Yzk0Yjc8L1BBUkVOVElEPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjgxNDZjZWQ5LWQ0OTYtNGU0Ni04ZjJkLWFmMDQyNTZlNTU1MjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+YTcwYWVjMDYtZjY1My00MWFmLTg5YjUtYjM0OTQzYTQ5ZTBjPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPnRydWU8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmEyMTBkYzViLWVjYTYtNDhkNy05YWJjLTkyMDU2YmIxZjFmNTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+YTcwYWVjMDYtZjY1My00MWFmLTg5YjUtYjM0OTQzYTQ5ZTBjPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5DSyU8L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjU2OTYyYWE0LWZkYWUtNGIxNC04NGZmLTYyNzdhNTk1ZWZlMjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+YTcwYWVjMDYtZjY1My00MWFmLTg5YjUtYjM0OTQzYTQ5ZTBjPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPnRydWU8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjk1YjQ3MjQ3LTE1ZTgtNDA0ZS04YTdiLWEzMWM2NWJiMTRlNzwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+YTcwYWVjMDYtZjY1My00MWFmLTg5YjUtYjM0OTQzYTQ5ZTBjPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4xOTY2OTlhNy1jMjVkLTRjM2MtOTUwMi1lMzMyMzU5ZDAyZmM8L0NPTElEPg0KICAgIDxUQUJMRUlEPmE3MGFlYzA2LWY2NTMtNDFhZi04OWI1LWIzNDk0M2E0OWUwYzwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+dHJ1ZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5kYjUyZDIxYi0wYWE1LTRjZWYtOWQ1Ny1kNmYwOWZlMDk1OGU8L0NPTElEPg0KICAgIDxUQUJMRUlEPmU2NjUwM2FiLWNkZTctNGU5ZC1hM2ZmLWJlNjM1MDZkMTI4MzwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+xJBWVDwvQ0FQVElPTj4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPjE5NjY5OWE3LWMyNWQtNGMzYy05NTAyLWUzMzIzNTlkMDJmYzwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+OGZmMzU3NTYtNjNmNy00MmQ5LWE3MzEtMDQ4YTRiMzhlNTZlPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5hNzBhZWMwNi1mNjUzLTQxYWYtODliNS1iMzQ5NDNhNDllMGM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPlMubMaw4bujbmc8L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFPkNPQUxFU0NFKFNMWFVBVENIVUFRVVlET0ksIDApLUNPQUxFU0NFKFNMTkhBUENIVUFRVVlET0ksIDApPC9SRVBMQUNFPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5mNTE1OTY0ZC00ZmQwLTRhNjMtYmQ5NS1lY2RlNDBiNDJjZjA8L0NPTElEPg0KICAgIDxUQUJMRUlEPmE3MGFlYzA2LWY2NTMtNDFhZi04OWI1LWIzNDk0M2E0OWUwYzwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+TeG6t3QgaMOgbmc8L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQo8L0RvY3VtZW50RWxlbWVudD4=";
        #endregion
    }
}
