namespace No1Run
{
    partial class ThongKe
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lueSUSER = new No1Lib.Sys.No1LookupEdit();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblTruTichLuy = new System.Windows.Forms.Label();
            this.LabelTruTichLuy = new System.Windows.Forms.Label();
            this.lblTheTraTruoc = new System.Windows.Forms.Label();
            this.LabelTheTraTruoc = new System.Windows.Forms.Label();
            this.lblVoucher = new System.Windows.Forms.Label();
            this.LabelVoucher = new System.Windows.Forms.Label();
            this.lblGTTong = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblTheATM = new System.Windows.Forms.Label();
            this.LabelTheATM = new System.Windows.Forms.Label();
            this.lblGTChuyenKhoan = new System.Windows.Forms.Label();
            this.lblTienThe = new System.Windows.Forms.Label();
            this.lblGTConNo = new System.Windows.Forms.Label();
            this.lblCongNo = new System.Windows.Forms.Label();
            this.lblGTThuChi = new System.Windows.Forms.Label();
            this.lblThuChi = new System.Windows.Forms.Label();
            this.lblGTTienMat = new System.Windows.Forms.Label();
            this.lblTienMat = new System.Windows.Forms.Label();
            this.dtNgay = new No1Lib.Sys.No1DatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tabMain = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pageDonHang = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grHoaDon = new No1Lib.Sys.GridMapper();
            this.pageMatHang = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grMatHang = new No1Lib.Sys.GridMapper();
            this.pageThuChi = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grThuChi = new No1Lib.Sys.GridMapper();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            this.KryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageDonHang)).BeginInit();
            this.pageDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageMatHang)).BeginInit();
            this.pageMatHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageThuChi)).BeginInit();
            this.pageThuChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblNgay);
            this.panel1.Controls.Add(this.lueSUSER);
            this.panel1.Controls.Add(this.lblTaiKhoan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 39);
            this.panel1.TabIndex = 2;
            // 
            // lblNgay
            // 
            this.lblNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay.Location = new System.Drawing.Point(668, 7);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(227, 20);
            this.lblNgay.TabIndex = 11;
            this.lblNgay.Text = "Ngày:";
            this.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lueSUSER
            // 
            this.lueSUSER.BackColor = System.Drawing.Color.White;
            this.lueSUSER.Location = new System.Drawing.Point(313, 8);
            this.lueSUSER.Name = "lueSUSER";
            this.lueSUSER.ShowManagementMenuItem = false;
            this.lueSUSER.Size = new System.Drawing.Size(191, 21);
            this.lueSUSER.TabIndex = 12;
            this.lueSUSER.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.lueSUSER_OnEditValueChanged);
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.lblTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaiKhoan.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTaiKhoan.Location = new System.Drawing.Point(215, 7);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(92, 20);
            this.lblTaiKhoan.TabIndex = 10;
            this.lblTaiKhoan.Text = "Tài khoản:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thống kê ca làm việc";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // KryptonPanel2
            // 
            this.KryptonPanel2.Controls.Add(this.lblTruTichLuy);
            this.KryptonPanel2.Controls.Add(this.LabelTruTichLuy);
            this.KryptonPanel2.Controls.Add(this.lblTheTraTruoc);
            this.KryptonPanel2.Controls.Add(this.LabelTheTraTruoc);
            this.KryptonPanel2.Controls.Add(this.lblVoucher);
            this.KryptonPanel2.Controls.Add(this.LabelVoucher);
            this.KryptonPanel2.Controls.Add(this.lblGTTong);
            this.KryptonPanel2.Controls.Add(this.lblTong);
            this.KryptonPanel2.Controls.Add(this.lblTheATM);
            this.KryptonPanel2.Controls.Add(this.LabelTheATM);
            this.KryptonPanel2.Controls.Add(this.lblGTChuyenKhoan);
            this.KryptonPanel2.Controls.Add(this.lblTienThe);
            this.KryptonPanel2.Controls.Add(this.lblGTConNo);
            this.KryptonPanel2.Controls.Add(this.lblCongNo);
            this.KryptonPanel2.Controls.Add(this.lblGTThuChi);
            this.KryptonPanel2.Controls.Add(this.lblThuChi);
            this.KryptonPanel2.Controls.Add(this.lblGTTienMat);
            this.KryptonPanel2.Controls.Add(this.lblTienMat);
            this.KryptonPanel2.Controls.Add(this.dtNgay);
            this.KryptonPanel2.Controls.Add(this.label2);
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 39);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Size = new System.Drawing.Size(905, 87);
            this.KryptonPanel2.TabIndex = 3;
            // 
            // lblTruTichLuy
            // 
            this.lblTruTichLuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblTruTichLuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTruTichLuy.Location = new System.Drawing.Point(636, 59);
            this.lblTruTichLuy.Name = "lblTruTichLuy";
            this.lblTruTichLuy.Size = new System.Drawing.Size(126, 20);
            this.lblTruTichLuy.TabIndex = 38;
            this.lblTruTichLuy.Text = "0";
            this.lblTruTichLuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelTruTichLuy
            // 
            this.LabelTruTichLuy.AutoSize = true;
            this.LabelTruTichLuy.BackColor = System.Drawing.Color.Transparent;
            this.LabelTruTichLuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTruTichLuy.Location = new System.Drawing.Point(524, 59);
            this.LabelTruTichLuy.Name = "LabelTruTichLuy";
            this.LabelTruTichLuy.Size = new System.Drawing.Size(101, 20);
            this.LabelTruTichLuy.TabIndex = 37;
            this.LabelTruTichLuy.Text = "Trừ tích lũy:";
            // 
            // lblTheTraTruoc
            // 
            this.lblTheTraTruoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblTheTraTruoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheTraTruoc.Location = new System.Drawing.Point(636, 33);
            this.lblTheTraTruoc.Name = "lblTheTraTruoc";
            this.lblTheTraTruoc.Size = new System.Drawing.Size(126, 20);
            this.lblTheTraTruoc.TabIndex = 36;
            this.lblTheTraTruoc.Text = "0";
            this.lblTheTraTruoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelTheTraTruoc
            // 
            this.LabelTheTraTruoc.AutoSize = true;
            this.LabelTheTraTruoc.BackColor = System.Drawing.Color.Transparent;
            this.LabelTheTraTruoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTheTraTruoc.Location = new System.Drawing.Point(524, 33);
            this.LabelTheTraTruoc.Name = "LabelTheTraTruoc";
            this.LabelTheTraTruoc.Size = new System.Drawing.Size(61, 20);
            this.LabelTheTraTruoc.TabIndex = 35;
            this.LabelTheTraTruoc.Text = "Thẻ tt:";
            // 
            // lblVoucher
            // 
            this.lblVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucher.Location = new System.Drawing.Point(636, 8);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(126, 20);
            this.lblVoucher.TabIndex = 34;
            this.lblVoucher.Text = "0";
            this.lblVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVoucher
            // 
            this.LabelVoucher.AutoSize = true;
            this.LabelVoucher.BackColor = System.Drawing.Color.Transparent;
            this.LabelVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVoucher.Location = new System.Drawing.Point(524, 8);
            this.LabelVoucher.Name = "LabelVoucher";
            this.LabelVoucher.Size = new System.Drawing.Size(81, 20);
            this.LabelVoucher.TabIndex = 33;
            this.LabelVoucher.Text = "Voucher:";
            // 
            // lblGTTong
            // 
            this.lblGTTong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblGTTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGTTong.Location = new System.Drawing.Point(378, 59);
            this.lblGTTong.Name = "lblGTTong";
            this.lblGTTong.Size = new System.Drawing.Size(126, 20);
            this.lblGTTong.TabIndex = 29;
            this.lblGTTong.Text = "0";
            this.lblGTTong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.BackColor = System.Drawing.Color.Transparent;
            this.lblTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTong.Location = new System.Drawing.Point(244, 59);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(54, 20);
            this.lblTong.TabIndex = 25;
            this.lblTong.Text = "Tổng:";
            // 
            // lblTheATM
            // 
            this.lblTheATM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblTheATM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheATM.Location = new System.Drawing.Point(378, 33);
            this.lblTheATM.Name = "lblTheATM";
            this.lblTheATM.Size = new System.Drawing.Size(126, 20);
            this.lblTheATM.TabIndex = 32;
            this.lblTheATM.Text = "0";
            this.lblTheATM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelTheATM
            // 
            this.LabelTheATM.AutoSize = true;
            this.LabelTheATM.BackColor = System.Drawing.Color.Transparent;
            this.LabelTheATM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTheATM.Location = new System.Drawing.Point(244, 33);
            this.LabelTheATM.Name = "LabelTheATM";
            this.LabelTheATM.Size = new System.Drawing.Size(85, 20);
            this.LabelTheATM.TabIndex = 31;
            this.LabelTheATM.Text = "Thẻ ATM:";
            // 
            // lblGTChuyenKhoan
            // 
            this.lblGTChuyenKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblGTChuyenKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGTChuyenKhoan.Location = new System.Drawing.Point(378, 8);
            this.lblGTChuyenKhoan.Name = "lblGTChuyenKhoan";
            this.lblGTChuyenKhoan.Size = new System.Drawing.Size(126, 20);
            this.lblGTChuyenKhoan.TabIndex = 28;
            this.lblGTChuyenKhoan.Text = "0";
            this.lblGTChuyenKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTienThe
            // 
            this.lblTienThe.AutoSize = true;
            this.lblTienThe.BackColor = System.Drawing.Color.Transparent;
            this.lblTienThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienThe.Location = new System.Drawing.Point(244, 8);
            this.lblTienThe.Name = "lblTienThe";
            this.lblTienThe.Size = new System.Drawing.Size(128, 20);
            this.lblTienThe.TabIndex = 26;
            this.lblTienThe.Text = "Chuyển khoản:";
            // 
            // lblGTConNo
            // 
            this.lblGTConNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblGTConNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGTConNo.Location = new System.Drawing.Point(98, 59);
            this.lblGTConNo.Name = "lblGTConNo";
            this.lblGTConNo.Size = new System.Drawing.Size(126, 20);
            this.lblGTConNo.TabIndex = 30;
            this.lblGTConNo.Text = "0";
            this.lblGTConNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCongNo
            // 
            this.lblCongNo.AutoSize = true;
            this.lblCongNo.BackColor = System.Drawing.Color.Transparent;
            this.lblCongNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCongNo.Location = new System.Drawing.Point(9, 59);
            this.lblCongNo.Name = "lblCongNo";
            this.lblCongNo.Size = new System.Drawing.Size(81, 20);
            this.lblCongNo.TabIndex = 22;
            this.lblCongNo.Text = "Công nợ:";
            // 
            // lblGTThuChi
            // 
            this.lblGTThuChi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblGTThuChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGTThuChi.Location = new System.Drawing.Point(98, 33);
            this.lblGTThuChi.Name = "lblGTThuChi";
            this.lblGTThuChi.Size = new System.Drawing.Size(126, 20);
            this.lblGTThuChi.TabIndex = 40;
            this.lblGTThuChi.Text = "0";
            this.lblGTThuChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThuChi
            // 
            this.lblThuChi.AutoSize = true;
            this.lblThuChi.BackColor = System.Drawing.Color.Transparent;
            this.lblThuChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuChi.Location = new System.Drawing.Point(9, 33);
            this.lblThuChi.Name = "lblThuChi";
            this.lblThuChi.Size = new System.Drawing.Size(72, 20);
            this.lblThuChi.TabIndex = 39;
            this.lblThuChi.Text = "Thu chi:";
            // 
            // lblGTTienMat
            // 
            this.lblGTTienMat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblGTTienMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGTTienMat.Location = new System.Drawing.Point(98, 6);
            this.lblGTTienMat.Name = "lblGTTienMat";
            this.lblGTTienMat.Size = new System.Drawing.Size(126, 20);
            this.lblGTTienMat.TabIndex = 27;
            this.lblGTTienMat.Text = "0";
            this.lblGTTienMat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTienMat
            // 
            this.lblTienMat.AutoSize = true;
            this.lblTienMat.BackColor = System.Drawing.Color.Transparent;
            this.lblTienMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienMat.Location = new System.Drawing.Point(9, 8);
            this.lblTienMat.Name = "lblTienMat";
            this.lblTienMat.Size = new System.Drawing.Size(83, 20);
            this.lblTienMat.TabIndex = 21;
            this.lblTienMat.Text = "Tiền mặt:";
            // 
            // dtNgay
            // 
            this.dtNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgay.Location = new System.Drawing.Point(804, 33);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(91, 20);
            this.dtNgay.TabIndex = 23;
            this.dtNgay.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.dtNgay_OnEditValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(768, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Chọn ngày xem:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabMain
            // 
            this.tabMain.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.tabMain.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 126);
            this.tabMain.Name = "tabMain";
            this.tabMain.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pageDonHang,
            this.pageMatHang,
            this.pageThuChi});
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(905, 366);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "KryptonNavigator1";
            // 
            // pageDonHang
            // 
            this.pageDonHang.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageDonHang.Controls.Add(this.grHoaDon);
            this.pageDonHang.Flags = 65534;
            this.pageDonHang.LastVisibleSet = true;
            this.pageDonHang.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageDonHang.Name = "pageDonHang";
            this.pageDonHang.Size = new System.Drawing.Size(903, 339);
            this.pageDonHang.Text = "Các hóa đơn đã thu tiền";
            this.pageDonHang.ToolTipTitle = "Page ToolTip";
            this.pageDonHang.UniqueName = "11516C2639DB46F533AD656E2C7E9B87";
            // 
            // grHoaDon
            // 
            this.grHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grHoaDon.FontSize = 0F;
            this.grHoaDon.GUID = "4db27caf-41ca-4d9a-b438-111d03955e4d";
            this.grHoaDon.Location = new System.Drawing.Point(0, 0);
            this.grHoaDon.Name = "grHoaDon";
            this.grHoaDon.ReadOnly = true;
            this.grHoaDon.ShowToolbar = false;
            this.grHoaDon.Size = new System.Drawing.Size(903, 339);
            this.grHoaDon.TabIndex = 0;
            this.grHoaDon.CustomLoadData += new No1Lib.Sys.CustomLoadDataHandler(this.grHoaDon_CustomLoadData);
            // 
            // pageMatHang
            // 
            this.pageMatHang.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageMatHang.Controls.Add(this.grMatHang);
            this.pageMatHang.Flags = 65534;
            this.pageMatHang.LastVisibleSet = true;
            this.pageMatHang.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageMatHang.Name = "pageMatHang";
            this.pageMatHang.Size = new System.Drawing.Size(903, 339);
            this.pageMatHang.Text = "Mặt hàng đã bán";
            this.pageMatHang.ToolTipTitle = "Page ToolTip";
            this.pageMatHang.UniqueName = "0A9B26BB24264E544FA427EC6E86F00E";
            // 
            // grMatHang
            // 
            this.grMatHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMatHang.FontSize = 0F;
            this.grMatHang.GUID = "b5963f05-4ca3-4562-b866-e35548fbe91a";
            this.grMatHang.Location = new System.Drawing.Point(0, 0);
            this.grMatHang.Name = "grMatHang";
            this.grMatHang.ReadOnly = true;
            this.grMatHang.ShowAddButton = false;
            this.grMatHang.ShowToolbar = false;
            this.grMatHang.Size = new System.Drawing.Size(903, 339);
            this.grMatHang.TabIndex = 0;
            this.grMatHang.CustomLoadData += new No1Lib.Sys.CustomLoadDataHandler(this.grMatHang_CustomLoadData);
            // 
            // pageThuChi
            // 
            this.pageThuChi.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageThuChi.Controls.Add(this.grThuChi);
            this.pageThuChi.Flags = 65534;
            this.pageThuChi.LastVisibleSet = true;
            this.pageThuChi.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageThuChi.Name = "pageThuChi";
            this.pageThuChi.Size = new System.Drawing.Size(903, 339);
            this.pageThuChi.Text = "Thu chi";
            this.pageThuChi.ToolTipTitle = "Page ToolTip";
            this.pageThuChi.UniqueName = "13089E9BD3FF4B74BBA8FE0DA6997BD6";
            // 
            // grThuChi
            // 
            this.grThuChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grThuChi.FontSize = 0F;
            this.grThuChi.GUID = "39b04be5-2cb2-4483-8d89-26515aa41e85";
            this.grThuChi.Location = new System.Drawing.Point(0, 0);
            this.grThuChi.Name = "grThuChi";
            this.grThuChi.ReadOnly = true;
            this.grThuChi.ShowToolbar = false;
            this.grThuChi.Size = new System.Drawing.Size(903, 339);
            this.grThuChi.TabIndex = 0;
            this.grThuChi.CustomLoadData += new No1Lib.Sys.CustomLoadDataHandler(this.grThuChi_CustomLoadData);
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.btnCancel);
            this.KryptonPanel1.Controls.Add(this.btnInBaoCao);
            this.KryptonPanel1.Controls.Add(this.btnOpen);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 492);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(905, 37);
            this.KryptonPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(824, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInBaoCao.Location = new System.Drawing.Point(179, 3);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(131, 30);
            this.btnInBaoCao.TabIndex = 18;
            this.btnInBaoCao.Text = "In báo cáo kết ca";
            this.btnInBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInBaoCao.UseVisualStyleBackColor = true;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(3, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(170, 30);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Xem đơn hàng đang chọn";
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // ThongKe
            // 
            this.AcceptButton = this.btnOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(905, 529);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ";
            this.Load += new System.EventHandler(this.form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            this.KryptonPanel2.ResumeLayout(false);
            this.KryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageDonHang)).EndInit();
            this.pageDonHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageMatHang)).EndInit();
            this.pageMatHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageThuChi)).EndInit();
            this.pageThuChi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTaiKhoan;
        public No1Lib.Sys.No1LookupEdit lueSUSER;
        public System.Windows.Forms.Label lblNgay;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        public System.Windows.Forms.Label label2;
        public No1Lib.Sys.No1DatePicker dtNgay;
        public System.Windows.Forms.Label lblTienMat;
        public System.Windows.Forms.Label lblGTTienMat;
        public System.Windows.Forms.Label lblThuChi;
        public System.Windows.Forms.Label lblGTThuChi;
        public System.Windows.Forms.Label lblCongNo;
        public System.Windows.Forms.Label lblGTConNo;
        public System.Windows.Forms.Label lblTienThe;
        public System.Windows.Forms.Label lblGTChuyenKhoan;
        public System.Windows.Forms.Label LabelTheATM;
        public System.Windows.Forms.Label lblTheATM;
        public System.Windows.Forms.Label lblTong;
        public System.Windows.Forms.Label lblGTTong;
        public System.Windows.Forms.Label LabelVoucher;
        public System.Windows.Forms.Label lblVoucher;
        public System.Windows.Forms.Label LabelTheTraTruoc;
        public System.Windows.Forms.Label lblTheTraTruoc;
        public System.Windows.Forms.Label LabelTruTichLuy;
        public System.Windows.Forms.Label lblTruTichLuy;
        public ComponentFactory.Krypton.Navigator.KryptonNavigator tabMain;
        public ComponentFactory.Krypton.Navigator.KryptonPage pageDonHang;
        public No1Lib.Sys.GridMapper grHoaDon;
        public ComponentFactory.Krypton.Navigator.KryptonPage pageMatHang;
        public No1Lib.Sys.GridMapper grMatHang;
        public ComponentFactory.Krypton.Navigator.KryptonPage pageThuChi;
        public No1Lib.Sys.GridMapper grThuChi;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Button btnOpen;
        public System.Windows.Forms.Button btnInBaoCao;
        public System.Windows.Forms.Button btnCancel;
    }
}
