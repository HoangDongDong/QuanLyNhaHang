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
                        ((System.ComponentModel.ISupportInitialize)(this.grHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grThuChi)).BeginInit();
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
                        this.grHoaDon.ViewConfig = System.Convert.FromBase64String(VIEWCONFIG_HOADON);
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
                        this.grMatHang.ViewConfig = System.Convert.FromBase64String(VIEWCONFIG_MATHANG);
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
                        this.grThuChi.ViewConfig = System.Convert.FromBase64String(VIEWCONFIG_THUCHI);
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
                        ((System.ComponentModel.ISupportInitialize)(this.grHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grThuChi)).EndInit();
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

        #region Grid ViewConfigs
        private const string VIEWCONFIG_HOADON = "PERvY3VtZW50RWxlbWVudD4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+Y2Q2ODJiOTMtNmQyZi00Mjc0LWEyMzItMDkyZDhkMjM5YjBiPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjA2NzUyZDQ5LWY2OWUtNDAzNC1iYWRjLTQ1Y2FhZThlN2MwMTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUPkRFU0M8L1NPUlQ+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5hNGNjODYyMS02YWVmLTQ4MTMtYjk2ZS04ZDEwMDU2MzMyZmQ8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MGM2M2FkMjQtM2Y1Yi00NjRlLTg5MDgtYTAxNDM5ODI5ZTM1PC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YTM2NTk0ZjMtNDNmMC00OTg2LThmMzUtOWI2ZWVmYWYyMWJiPC9DT0xJRD4NCiAgICA8VEFCTEVJRD41ZmNjNTcxYS02NjJkLTQ5NTMtYTgzZi02MDA0YzczMmY0Mzk8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPktow6FjaCBow6BuZzwvQ0FQVElPTj4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPjBjNjNhZDI0LTNmNWItNDY0ZS04OTA4LWEwMTQzOTgyOWUzNTwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+Y2NiYzY1MzgtMmY5ZC00YmUwLTkyNzYtMTM5ZjE5ZjZmMDQ0PC9DT0xJRD4NCiAgICA8VEFCTEVJRD41ZmNjNTcxYS02NjJkLTQ5NTMtYTgzZi02MDA0YzczMmY0Mzk8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICAgIDxQQVJFTlRJRD4wYzYzYWQyNC0zZjViLTQ2NGUtODkwOC1hMDE0Mzk4MjllMzU8L1BBUkVOVElEPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjJkYjQ5NDNlLTFiNGUtNDFiMi04MWYxLTM1MTBiMDdiM2ExODwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NWZjYzU3MWEtNjYyZC00OTUzLWE4M2YtNjAwNGM3MzJmNDM5PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgICA8UEFSRU5USUQ+MGM2M2FkMjQtM2Y1Yi00NjRlLTg5MDgtYTAxNDM5ODI5ZTM1PC9QQVJFTlRJRD4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD5mYWxzZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MmY0MTBmMTctMGE3Yy00ZWRmLTljZTctODViOWE3YmY5YjVkPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OPj0wPC9DT05ESVRJT04+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmI3NTg5NDFiLTYyYjEtNDRhOC05OTQyLWViYTIwODI2MzRhZTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5mZjMzMGI2Yi0yN2JkLTRkNzUtOGUwZC0wOWZlNjQ4NzU4ZWE8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+ZGU3NzA4Y2MtMjE4Yi00MzY5LWI2M2EtYTUxNTZiMDNjMWYwPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjAxNTI5ZTYwLTJkY2YtNDA1ZS04OGY1LTFjYjNhNDIxNDRkMjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD40YTE2OWNkMy0zY2ZiLTRkMjgtYTBjNi1mMmQ0OTAzZTVmNjU8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YmNkODQ0M2EtMzQzNi00Nzg1LThiMWUtNmJiNWM1ZWM1YmQyPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmQ0NjBiOGM1LWYzZDMtNDU1Ni1hOWFlLWUwNzBkMDVhOTI3ODwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5hZDEwMTBiYS00YjUxLTQyMWUtOWVhZS0xNTdmZTRjNjEyOWU8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YzVhNjk4ZjMtODhmNi00NGY1LTkzN2EtNzg1MTA2Yzg0ZGIxPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjJiMTAwNDM1LTEwYTMtNDQxMS05MGQ5LTAxYTg0ZmY1MjcyMzwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4yZDFiMmY0OC02ZDIwLTQ5N2YtYjgxMS1hN2U3OWRkZjQzMzM8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+VGhhbmggdG/DoW48L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjkzNGExMzNhLTBkZDgtNDZlZS1iYmUzLTgwYmE1Yjg5MGJiMjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD50cnVlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPmZhbHNlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4xYzI0YjE5Yi05MGZmLTRmZTYtYTcwOS03OWM5NGNhMjZkNjU8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04+PTMwPC9DT05ESVRJT04+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjE2N2E0OWEwLWUyMTYtNDIxMC05NzJjLTA3N2MzYTE4NTcxYzwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4zOTJjNTZiNC1lMGQyLTQ0YzUtYjBkZi0yMjdkNWJlNzU3M2Q8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YzU1ZTg1Y2MtYzUzZi00MWFlLTlkODUtYzgwZTc3OTgwYTE3PC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YTkxMDQ4MjQtMWQ1My00Y2ZiLWE5NTQtMjMzMDFkODhjYTJmPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5jZjkzODNkNi0xMWM4LTQ2NmItOTVjMy0zZjRiM2IwMmVlZTE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPk5nw6JuIGjDoG5nPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgICA8UEFSRU5USUQ+YzU1ZTg1Y2MtYzUzZi00MWFlLTlkODUtYzgwZTc3OTgwYTE3PC9QQVJFTlRJRD4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD43MDMzM2QzMi1kYjE3LTQ0MzEtOTc5My05ZTFmZmJjZjAzNzE8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+ZDQ4ZDFkNGItM2U5Zi00YTAzLThlNzUtNmE2ZWNiNWUzMzRkPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjRlMTExZmM3LTUwNTEtNGNlZC05ZmU0LTY0NTJiNjVmN2UzOTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD43ZGM5MWQ0Yy1mYTMyLTRiNDAtYTkwYy00MGRiMTcyMjM1YmE8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+OWZjZDM4YTgtNmNkNS00MzYzLThmNzQtYjhmMTVlMmRmNWIwPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjI1NjFiZGM2LTU2M2QtNDRjMS04OTA1LTNjOTgyNTYzZTA1ZDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD50cnVlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjA0Y2NlMDM5LTEyODYtNDQ5ZC1hZjkyLWEwZDhiYjc0MjViYjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+ZjIyODgzNDUtMDMxYS00ZTFiLWE3NmQtM2IyZTUzNzY3NGE2PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5Cw6BuPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgICA8UEFSRU5USUQ+MjU2MWJkYzYtNTYzZC00NGMxLTg5MDUtM2M5ODI1NjNlMDVkPC9QQVJFTlRJRD4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4zZTc2NzJlYS0yZDQzLTRmMmQtODQxMi1iMmU2Y2FjNTUwODQ8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+OGU0ZjcwNDItNDc5Zi00M2NjLWE5YzMtZTU5ZTM0YmM5Y2U0PC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjU3ZjMzZGUzLTM1NzgtNDc5ZS04OGY2LWM5NjI4MGVlNjJjMzwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5Dw7JuIG7hu6M8L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQo8L0RvY3VtZW50RWxlbWVudD4=";
        private const string VIEWCONFIG_MATHANG = "PERvY3VtZW50RWxlbWVudD4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YWQzYjVmMGYtZjQ2My00ZjhhLWE2OGUtODY4YTAwYmRlNGMyPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5hNzBhZWMwNi1mNjUzLTQxYWYtODliNS1iMzQ5NDNhNDllMGM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MmY0MTBmMTctMGE3Yy00ZWRmLTljZTctODViOWE3YmY5YjVkPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OPj0wPC9DT05ESVRJT04+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPmFkM2I1ZjBmLWY0NjMtNGY4YS1hNjhlLTg2OGEwMGJkZTRjMjwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+ZmFsc2U8L0NIRUNLRUQ+DQogICAgPENPTElEPjFjMjRiMTliLTkwZmYtNGZlNi1hNzA5LTc5Yzk0Y2EyNmQ2NTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTj49MzA8L0NPTkRJVElPTj4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPmFkM2I1ZjBmLWY0NjMtNGY4YS1hNjhlLTg2OGEwMGJkZTRjMjwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+NzBjOTVkMDItZTdjMS00Y2Q4LWJhYWUtMjBkMTJkN2M5NGI3PC9DT0xJRD4NCiAgICA8VEFCTEVJRD5hNzBhZWMwNi1mNjUzLTQxYWYtODliNS1iMzQ5NDNhNDllMGM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+N2I3OTMxNjItODIxOS00NmUzLWE0NzEtODZkYTgzM2ZhNzYyPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5hNGExNjIxNi1hZWU5LTRkZDMtOWY5Mi1jMWU0ZDg1YzA2YTI8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICAgIDxQQVJFTlRJRD43MGM5NWQwMi1lN2MxLTRjZDgtYmFhZS0yMGQxMmQ3Yzk0Yjc8L1BBUkVOVElEPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjY3NmNlYTU3LTkzNmEtNGViNS1iY2Q1LTlkOTQxZGE1YTkzMTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+YTRhMTYyMTYtYWVlOS00ZGQzLTlmOTItYzFlNGQ4NWMwNmEyPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgICA8UEFSRU5USUQ+NzBjOTVkMDItZTdjMS00Y2Q4LWJhYWUtMjBkMTJkN2M5NGI3PC9QQVJFTlRJRD4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5hMjEwZGM1Yi1lY2E2LTQ4ZDctOWFiYy05MjA1NmJiMWYxZjU8L0NPTElEPg0KICAgIDxUQUJMRUlEPmE3MGFlYzA2LWY2NTMtNDFhZi04OWI1LWIzNDk0M2E0OWUwYzwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+NTY5NjJhYTQtZmRhZS00YjE0LTg0ZmYtNjI3N2E1OTVlZmUyPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5hNzBhZWMwNi1mNjUzLTQxYWYtODliNS1iMzQ5NDNhNDllMGM8L1RBQkxFSUQ+DQogICAgPFRPVEFMPlNVTTwvVE9UQUw+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjk1YjQ3MjQ3LTE1ZTgtNDA0ZS04YTdiLWEzMWM2NWJiMTRlNzwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+YTcwYWVjMDYtZjY1My00MWFmLTg5YjUtYjM0OTQzYTQ5ZTBjPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD41NWIzY2M3YS0yNmUwLTRhODktOTQyYi0zZDgzMDQyZjIwN2M8L0NPTElEPg0KICAgIDxUQUJMRUlEPmE3MGFlYzA2LWY2NTMtNDFhZi04OWI1LWIzNDk0M2E0OWUwYzwvVEFCTEVJRD4NCiAgICA8VE9UQUw+U1VNPC9UT1RBTD4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+U+G7kSBsxrDhu6NuZzwvQ0FQVElPTj4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MTk2Njk5YTctYzI1ZC00YzNjLTk1MDItZTMzMjM1OWQwMmZjPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5hNzBhZWMwNi1mNjUzLTQxYWYtODliNS1iMzQ5NDNhNDllMGM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPnRydWU8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+ZGI1MmQyMWItMGFhNS00Y2VmLTlkNTctZDZmMDlmZTA5NThlPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5lNjY1MDNhYi1jZGU3LTRlOWQtYTNmZi1iZTYzNTA2ZDEyODM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPsSQVlQ8L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICAgIDxQQVJFTlRJRD4xOTY2OTlhNy1jMjVkLTRjM2MtOTUwMi1lMzMyMzU5ZDAyZmM8L1BBUkVOVElEPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPmZhbHNlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD42MmNiZGUxNy1hYjViLTRmYjYtYmY1NC1hYmFlNTUxOTE0NDE8L0NPTElEPg0KICAgIDxUQUJMRUlEPmE3MGFlYzA2LWY2NTMtNDFhZi04OWI1LWIzNDk0M2E0OWUwYzwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04+KENPQUxFU0NFKFhVQVRWQVRUVSwgMCkgPSAwIEFORCBDT0FMRVNDRShDT01CT1BBUkVOVElELCAnJykgPSAnJyk8L0NPTkRJVElPTj4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+ZjUxNTk2NGQtNGZkMC00YTYzLWJkOTUtZWNkZTQwYjQyY2YwPC9DT0xJRD4NCiAgICA8VEFCTEVJRD5hNzBhZWMwNi1mNjUzLTQxYWYtODliNS1iMzQ5NDNhNDllMGM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQo8L0RvY3VtZW50RWxlbWVudD4=";
        private const string VIEWCONFIG_THUCHI = "PERvY3VtZW50RWxlbWVudD4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+NWU1Y2EwMDAtYzIwZS00MTg0LTgyMDktODFmNTMzNWZmODZlPC9DT0xJRD4NCiAgICA8VEFCTEVJRD45NzIxNjkyMy03NTQzLTQxNzgtYjEyNy03NTg3NjQwZjI2ZWM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjE5YjMxYWUwLTZiNGItNDIyZC05ZDUyLTMzZmVjMTBhM2ZlODwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+OTcyMTY5MjMtNzU0My00MTc4LWIxMjctNzU4NzY0MGYyNmVjPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5jYzcwMjY5NS1hYWI1LTQ3ZDMtYmFjYi00YmQxMGFjYjkyMjU8L0NPTElEPg0KICAgIDxUQUJMRUlEPjk3MjE2OTIzLTc1NDMtNDE3OC1iMTI3LTc1ODc2NDBmMjZlYzwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+NTYwYTg3NzItYzhhZC00ODkzLWFjOGMtNDVhNTEwNzllNDhmPC9DT0xJRD4NCiAgICA8VEFCTEVJRD45NzIxNjkyMy03NTQzLTQxNzgtYjEyNy03NTg3NjQwZjI2ZWM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPlRodTwvQ0FQVElPTj4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+ODdmYzgyNWUtMjQ3MC00YTlkLWI4M2ItZTE2NWZhZDRhYTMxPC9DT0xJRD4NCiAgICA8VEFCTEVJRD45NzIxNjkyMy03NTQzLTQxNzgtYjEyNy03NTg3NjQwZjI2ZWM8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OPkNoaTwvQ0FQVElPTj4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCjwvRG9jdW1lbnRFbGVtZW50Pg==";
        #endregion
    }
}
