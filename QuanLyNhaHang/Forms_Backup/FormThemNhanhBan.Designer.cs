namespace QuanLyNhaHang
{
    partial class FormThemnhanhban
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
            this.grMain = new System.Windows.Forms.DataGridView();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblChieuDai = new System.Windows.Forms.Label();
            this.numChieuDai = new System.Windows.Forms.NumericUpDown();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.colKhuVuc = new System.Windows.Forms.TextBox();
            this.colTuSo = new System.Windows.Forms.DataGridView();
            this.colBanDenSo = new System.Windows.Forms.DataGridView();
            this.colBatDauBang = new System.Windows.Forms.TextBox();
            this.colDuLieu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(479, 394);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(3, 153);
            this.grMain.Size = new System.Drawing.Size(470, 147);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 0;
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(12, 9);
            this.lblGhiChu.Size = new System.Drawing.Size(454, 130);
            this.lblGhiChu.Text = "Chức năng này cho phép bạn thêm nhiều bàn vào hệ thống một lúc
Để sử dụng, bạn thêm mới khu vực trước, sau đó truy cập vào chức năng này:
+ Nhập từ số, đến số và tiền tố bắt đầu bằng.
Ví dụ
      Tầng 1: Từ 1 đến 9, bắt đầu bằng B
      Tầng 2: Từ 10 đến 29, bắt đầu bằng B
      Tầng 3: Từ 29 đến 99 bắt đầu bằng B
Chiều dài vùng số = 2

Hệ thống sẽ sinh các bàn: B01-B09 cho tầng 1, B10 đến B29 cho tầng 2, B29-B99 cho tầng 3";
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.TabIndex = 1;
            // lblChieuDai
            // 
            this.lblChieuDai.Location = new System.Drawing.Point(13, 308);
            this.lblChieuDai.Size = new System.Drawing.Size(95, 13);
            this.lblChieuDai.Text = "Chiều dài vùng số:";
            this.lblChieuDai.Name = "lblChieuDai";
            this.lblChieuDai.TabIndex = 2;
            // numChieuDai
            // 
            this.numChieuDai.Location = new System.Drawing.Point(119, 305);
            this.numChieuDai.Size = new System.Drawing.Size(55, 20);
            this.numChieuDai.Name = "numChieuDai";
            this.numChieuDai.TabIndex = 3;
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(398, 350);
            this.btnThoat.Size = new System.Drawing.Size(75, 32);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.TabIndex = 8;
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(317, 350);
            this.btnThucHien.Size = new System.Drawing.Size(75, 32);
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.TabIndex = 9;
            // colKhuVuc
            // 
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;
            // colTuSo
            // 
            this.colTuSo.Name = "colTuSo";
            // colBanDenSo
            // 
            this.colBanDenSo.Name = "colBanDenSo";
            // colBatDauBang
            // 
            this.colBatDauBang.Name = "colBatDauBang";
            // colDuLieu
            // 
            this.colDuLieu.Name = "colDuLieu";
            this.colDuLieu.ReadOnly = true;
            // 
            // FormThemnhanhban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 394);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblChieuDai);
            this.Controls.Add(this.numChieuDai);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.colKhuVuc);
            this.Controls.Add(this.colTuSo);
            this.Controls.Add(this.colBanDenSo);
            this.Controls.Add(this.colBatDauBang);
            this.Controls.Add(this.colDuLieu);
            this.Name = "FormThemnhanhban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nhanh bàn";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Label lblGhiChu;
        public System.Windows.Forms.Label lblChieuDai;
        public System.Windows.Forms.NumericUpDown numChieuDai;
        public System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Button btnThucHien;
        public System.Windows.Forms.TextBox colKhuVuc;
        public System.Windows.Forms.DataGridView colTuSo;
        public System.Windows.Forms.DataGridView colBanDenSo;
        public System.Windows.Forms.TextBox colBatDauBang;
        public System.Windows.Forms.TextBox colDuLieu;
    }
}