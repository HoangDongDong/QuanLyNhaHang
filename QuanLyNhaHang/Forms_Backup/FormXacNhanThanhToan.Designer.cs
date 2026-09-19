namespace QuanLyNhaHang
{
    partial class FormXacnhanthanhtoan
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
            this.KryptonPanel1 = new System.Windows.Forms.Panel();
            this.numTraLai = new System.Windows.Forms.NumericUpDown();
            this.numTongTien = new System.Windows.Forms.NumericUpDown();
            this.numKhachDua = new System.Windows.Forms.NumericUpDown();
            this.lblTraLai = new System.Windows.Forms.Label();
            this.lblKhachDua = new System.Windows.Forms.Label();
            this.btnDongBillKhongIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.ptImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInThuBill = new System.Windows.Forms.Button();
            this.chkKhachNo = new System.Windows.Forms.CheckBox();
            this.numNoCu = new System.Windows.Forms.NumericUpDown();
            this.lblNoCu = new System.Windows.Forms.Label();
            this.numTienHoaDon = new System.Windows.Forms.NumericUpDown();
            this.lblTienHoaDon = new System.Windows.Forms.Label();
            this.numDatTruoc = new System.Windows.Forms.NumericUpDown();
            this.lblDatTruoc = new System.Windows.Forms.Label();
            this.numCoupon = new System.Windows.Forms.NumericUpDown();
            this.lblCoupon = new System.Windows.Forms.Label();
            this.lueDTAIKHOAN = new System.Windows.Forms.Control();
            this.numTheTraTruoc = new System.Windows.Forms.NumericUpDown();
            this.lblTheTraTruoc = new System.Windows.Forms.Label();
            this.numTichLuy = new System.Windows.Forms.NumericUpDown();
            this.lblTruTichLuy = new System.Windows.Forms.Label();
            this.numATM = new System.Windows.Forms.NumericUpDown();
            this.lblTheATM = new System.Windows.Forms.Label();
            this.numChuyenKhoan = new System.Windows.Forms.NumericUpDown();
            this.lblChuyenKhoan = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.lblBan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(512, 623);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // numTraLai
            // 
            this.numTraLai.Location = new System.Drawing.Point(281, 445);
            this.numTraLai.Size = new System.Drawing.Size(219, 31);
            this.numTraLai.Name = "numTraLai";
            this.numTraLai.TabIndex = 11;
            this.numTraLai.ReadOnly = true;
            // numTongTien
            // 
            this.numTongTien.Location = new System.Drawing.Point(281, 159);
            this.numTongTien.Size = new System.Drawing.Size(219, 31);
            this.numTongTien.Name = "numTongTien";
            this.numTongTien.TabIndex = 12;
            this.numTongTien.ReadOnly = true;
            // numKhachDua
            // 
            this.numKhachDua.Location = new System.Drawing.Point(281, 196);
            this.numKhachDua.Size = new System.Drawing.Size(219, 31);
            this.numKhachDua.Name = "numKhachDua";
            this.numKhachDua.TabIndex = 0;
            // lblTraLai
            // 
            this.lblTraLai.Location = new System.Drawing.Point(88, 447);
            this.lblTraLai.Size = new System.Drawing.Size(78, 25);
            this.lblTraLai.Text = "Trả lại:";
            this.lblTraLai.Name = "lblTraLai";
            this.lblTraLai.TabIndex = 29;
            // lblKhachDua
            // 
            this.lblKhachDua.Location = new System.Drawing.Point(88, 197);
            this.lblKhachDua.Size = new System.Drawing.Size(121, 25);
            this.lblKhachDua.Text = "Khách đưa:";
            this.lblKhachDua.Name = "lblKhachDua";
            this.lblKhachDua.TabIndex = 28;
            // btnDongBillKhongIn
            // 
            this.btnDongBillKhongIn.Location = new System.Drawing.Point(336, 539);
            this.btnDongBillKhongIn.Size = new System.Drawing.Size(165, 33);
            this.btnDongBillKhongIn.Text = "Đóng bill không in (F9)";
            this.btnDongBillKhongIn.Name = "btnDongBillKhongIn";
            this.btnDongBillKhongIn.TabIndex = 6;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 491);
            this.label2.Size = new System.Drawing.Size(302, 96);
            this.label2.Text = "- Bạn chọn \"Đóng bill và in\" để xác nhận thanh toán, in hóa đơn và đóng bill.

		- Bạn chọn \"Đóng bill không in\" để xác nhận thanh toán, KHÔNG in hóa đơn và đóng bill (tiết kiệm giấy).

	- Bạn chọn \"Hủy bỏ\" để thoát khỏi cửa sổ.";
            this.label2.Name = "label2";
            this.label2.TabIndex = 27;
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(336, 578);
            this.btnHuyBo.Size = new System.Drawing.Size(165, 33);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.TabIndex = 7;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(336, 487);
            this.btnOK.Size = new System.Drawing.Size(165, 33);
            this.btnOK.Text = "Đóng bill và in";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 5;
            // lblTongTien
            // 
            this.lblTongTien.Location = new System.Drawing.Point(88, 161);
            this.lblTongTien.Size = new System.Drawing.Size(141, 25);
            this.lblTongTien.Text = "TỔNG TIỀN:";
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.TabIndex = 26;
            // ptImage
            // 
            this.ptImage.Location = new System.Drawing.Point(12, 65);
            this.ptImage.Size = new System.Drawing.Size(64, 64);
            this.ptImage.Name = "ptImage";
            this.ptImage.TabIndex = 25;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(512, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 8;
            // btnInThuBill
            // 
            this.btnInThuBill.Location = new System.Drawing.Point(336, 2);
            this.btnInThuBill.Size = new System.Drawing.Size(164, 33);
            this.btnInThuBill.Text = "In tạm tính (F8)";
            this.btnInThuBill.Name = "btnInThuBill";
            this.btnInThuBill.TabIndex = 0;
            // chkKhachNo
            // 
            this.chkKhachNo.Location = new System.Drawing.Point(12, 592);
            this.chkKhachNo.Size = new System.Drawing.Size(99, 17);
            this.chkKhachNo.Text = "Khách hàng nợ";
            this.chkKhachNo.Name = "chkKhachNo";
            this.chkKhachNo.TabIndex = 5;
            // numNoCu
            // 
            this.numNoCu.Location = new System.Drawing.Point(281, 85);
            this.numNoCu.Size = new System.Drawing.Size(219, 31);
            this.numNoCu.Name = "numNoCu";
            this.numNoCu.TabIndex = 10;
            this.numNoCu.ReadOnly = true;
            // lblNoCu
            // 
            this.lblNoCu.Location = new System.Drawing.Point(88, 87);
            this.lblNoCu.Size = new System.Drawing.Size(74, 25);
            this.lblNoCu.Text = "Nợ cũ:";
            this.lblNoCu.Name = "lblNoCu";
            this.lblNoCu.TabIndex = 36;
            // numTienHoaDon
            // 
            this.numTienHoaDon.Location = new System.Drawing.Point(281, 122);
            this.numTienHoaDon.Size = new System.Drawing.Size(219, 31);
            this.numTienHoaDon.Name = "numTienHoaDon";
            this.numTienHoaDon.TabIndex = 11;
            this.numTienHoaDon.ReadOnly = true;
            // lblTienHoaDon
            // 
            this.lblTienHoaDon.Location = new System.Drawing.Point(88, 124);
            this.lblTienHoaDon.Size = new System.Drawing.Size(124, 24);
            this.lblTienHoaDon.Text = "Tiền hóa đơn";
            this.lblTienHoaDon.Name = "lblTienHoaDon";
            this.lblTienHoaDon.TabIndex = 34;
            // numDatTruoc
            // 
            this.numDatTruoc.Location = new System.Drawing.Point(281, 48);
            this.numDatTruoc.Size = new System.Drawing.Size(219, 31);
            this.numDatTruoc.Name = "numDatTruoc";
            this.numDatTruoc.TabIndex = 9;
            this.numDatTruoc.ReadOnly = true;
            // lblDatTruoc
            // 
            this.lblDatTruoc.Location = new System.Drawing.Point(88, 50);
            this.lblDatTruoc.Size = new System.Drawing.Size(105, 25);
            this.lblDatTruoc.Text = "Đặt trước:";
            this.lblDatTruoc.Name = "lblDatTruoc";
            this.lblDatTruoc.TabIndex = 38;
            // numCoupon
            // 
            this.numCoupon.Location = new System.Drawing.Point(281, 334);
            this.numCoupon.Size = new System.Drawing.Size(218, 31);
            this.numCoupon.Name = "numCoupon";
            this.numCoupon.TabIndex = 4;
            // lblCoupon
            // 
            this.lblCoupon.Location = new System.Drawing.Point(88, 335);
            this.lblCoupon.Size = new System.Drawing.Size(98, 25);
            this.lblCoupon.Text = "Voucher:";
            this.lblCoupon.Name = "lblCoupon";
            this.lblCoupon.TabIndex = 40;
            // lueDTAIKHOAN
            // 
            this.lueDTAIKHOAN.Location = new System.Drawing.Point(281, 307);
            this.lueDTAIKHOAN.Size = new System.Drawing.Size(217, 21);
            this.lueDTAIKHOAN.Name = "lueDTAIKHOAN";
            this.lueDTAIKHOAN.TabIndex = 3;
            // numTheTraTruoc
            // 
            this.numTheTraTruoc.Location = new System.Drawing.Point(281, 371);
            this.numTheTraTruoc.Size = new System.Drawing.Size(218, 31);
            this.numTheTraTruoc.Name = "numTheTraTruoc";
            this.numTheTraTruoc.TabIndex = 13;
            this.numTheTraTruoc.ReadOnly = true;
            // lblTheTraTruoc
            // 
            this.lblTheTraTruoc.Location = new System.Drawing.Point(88, 372);
            this.lblTheTraTruoc.Size = new System.Drawing.Size(140, 25);
            this.lblTheTraTruoc.Text = "Thẻ trả trước:";
            this.lblTheTraTruoc.Name = "lblTheTraTruoc";
            this.lblTheTraTruoc.TabIndex = 43;
            // numTichLuy
            // 
            this.numTichLuy.Location = new System.Drawing.Point(281, 408);
            this.numTichLuy.Size = new System.Drawing.Size(218, 31);
            this.numTichLuy.Name = "numTichLuy";
            this.numTichLuy.TabIndex = 14;
            this.numTichLuy.ReadOnly = true;
            // lblTruTichLuy
            // 
            this.lblTruTichLuy.Location = new System.Drawing.Point(88, 409);
            this.lblTruTichLuy.Size = new System.Drawing.Size(124, 25);
            this.lblTruTichLuy.Text = "Trừ tích lũy:";
            this.lblTruTichLuy.Name = "lblTruTichLuy";
            this.lblTruTichLuy.TabIndex = 45;
            // numATM
            // 
            this.numATM.Location = new System.Drawing.Point(281, 233);
            this.numATM.Size = new System.Drawing.Size(219, 31);
            this.numATM.Name = "numATM";
            this.numATM.TabIndex = 1;
            // lblTheATM
            // 
            this.lblTheATM.Location = new System.Drawing.Point(88, 234);
            this.lblTheATM.Size = new System.Drawing.Size(160, 25);
            this.lblTheATM.Text = "Thẻ ATM, Visa:";
            this.lblTheATM.Name = "lblTheATM";
            this.lblTheATM.TabIndex = 47;
            // numChuyenKhoan
            // 
            this.numChuyenKhoan.Location = new System.Drawing.Point(281, 270);
            this.numChuyenKhoan.Size = new System.Drawing.Size(218, 31);
            this.numChuyenKhoan.Name = "numChuyenKhoan";
            this.numChuyenKhoan.TabIndex = 2;
            // lblChuyenKhoan
            // 
            this.lblChuyenKhoan.Location = new System.Drawing.Point(87, 271);
            this.lblChuyenKhoan.Size = new System.Drawing.Size(157, 25);
            this.lblChuyenKhoan.Text = "Chuyển khoản:";
            this.lblChuyenKhoan.Name = "lblChuyenKhoan";
            this.lblChuyenKhoan.TabIndex = 49;
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.Location = new System.Drawing.Point(189, 311);
            this.lblTaiKhoan.Size = new System.Drawing.Size(77, 16);
            this.lblTaiKhoan.Text = "Tài khoản";
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.TabIndex = 50;
            // lblBan
            // 
            this.lblBan.Location = new System.Drawing.Point(11, 6);
            this.lblBan.Size = new System.Drawing.Size(98, 25);
            this.lblBan.Text = "BÀN: 15";
            this.lblBan.Name = "lblBan";
            this.lblBan.TabIndex = 51;
            // 
            // FormXacnhanthanhtoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 623);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.numTraLai);
            this.Controls.Add(this.numTongTien);
            this.Controls.Add(this.numKhachDua);
            this.Controls.Add(this.lblTraLai);
            this.Controls.Add(this.lblKhachDua);
            this.Controls.Add(this.btnDongBillKhongIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.ptImage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnInThuBill);
            this.Controls.Add(this.chkKhachNo);
            this.Controls.Add(this.numNoCu);
            this.Controls.Add(this.lblNoCu);
            this.Controls.Add(this.numTienHoaDon);
            this.Controls.Add(this.lblTienHoaDon);
            this.Controls.Add(this.numDatTruoc);
            this.Controls.Add(this.lblDatTruoc);
            this.Controls.Add(this.numCoupon);
            this.Controls.Add(this.lblCoupon);
            this.Controls.Add(this.lueDTAIKHOAN);
            this.Controls.Add(this.numTheTraTruoc);
            this.Controls.Add(this.lblTheTraTruoc);
            this.Controls.Add(this.numTichLuy);
            this.Controls.Add(this.lblTruTichLuy);
            this.Controls.Add(this.numATM);
            this.Controls.Add(this.lblTheATM);
            this.Controls.Add(this.numChuyenKhoan);
            this.Controls.Add(this.lblChuyenKhoan);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.lblBan);
            this.Name = "FormXacnhanthanhtoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận thanh toán";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.NumericUpDown numTraLai;
        public System.Windows.Forms.NumericUpDown numTongTien;
        public System.Windows.Forms.NumericUpDown numKhachDua;
        public System.Windows.Forms.Label lblTraLai;
        public System.Windows.Forms.Label lblKhachDua;
        public System.Windows.Forms.Button btnDongBillKhongIn;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnHuyBo;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label lblTongTien;
        public System.Windows.Forms.PictureBox ptImage;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnInThuBill;
        public System.Windows.Forms.CheckBox chkKhachNo;
        public System.Windows.Forms.NumericUpDown numNoCu;
        public System.Windows.Forms.Label lblNoCu;
        public System.Windows.Forms.NumericUpDown numTienHoaDon;
        public System.Windows.Forms.Label lblTienHoaDon;
        public System.Windows.Forms.NumericUpDown numDatTruoc;
        public System.Windows.Forms.Label lblDatTruoc;
        public System.Windows.Forms.NumericUpDown numCoupon;
        public System.Windows.Forms.Label lblCoupon;
        public System.Windows.Forms.Control lueDTAIKHOAN;
        public System.Windows.Forms.NumericUpDown numTheTraTruoc;
        public System.Windows.Forms.Label lblTheTraTruoc;
        public System.Windows.Forms.NumericUpDown numTichLuy;
        public System.Windows.Forms.Label lblTruTichLuy;
        public System.Windows.Forms.NumericUpDown numATM;
        public System.Windows.Forms.Label lblTheATM;
        public System.Windows.Forms.NumericUpDown numChuyenKhoan;
        public System.Windows.Forms.Label lblChuyenKhoan;
        public System.Windows.Forms.Label lblTaiKhoan;
        public System.Windows.Forms.Label lblBan;
    }
}