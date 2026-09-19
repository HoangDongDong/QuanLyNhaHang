namespace QuanLyNhaHang
{
    partial class FormHangtonhethandung
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.tvMain = new System.Windows.Forms.Control();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.colMaHang = new System.Windows.Forms.TextBox();
            this.colTenHang = new System.Windows.Forms.TextBox();
            this.colDvt = new System.Windows.Forms.TextBox();
            this.colSoLuong = new System.Windows.Forms.DataGridView();
            this.colHanSuDung = new System.Windows.Forms.Control();
            this.colSoNgay = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(845, 477);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(766, 444);
            this.btnThoat.Size = new System.Drawing.Size(75, 30);
            this.btnThoat.Text = "ĐÓNG";
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.TabIndex = 2;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Size = new System.Drawing.Size(665, 406);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 1;
            this.grMain.ReadOnly = true;
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(3, 32);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(838, 406);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 1;
            // tvMain
            // 
            this.tvMain.Location = new System.Drawing.Point(0, 0);
            this.tvMain.Size = new System.Drawing.Size(168, 406);
            this.tvMain.Name = "tvMain";
            this.tvMain.TabIndex = 0;
            this.tvMain.ReadOnly = false;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(4, 9);
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.Text = "Lọc dữ liệu";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 3;
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(74, 6);
            this.txtLoc.Size = new System.Drawing.Size(97, 20);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.TabIndex = 0;
            // colMaHang
            // 
            this.colMaHang.Name = "colMaHang";
            this.colMaHang.ReadOnly = true;
            // colTenHang
            // 
            this.colTenHang.Name = "colTenHang";
            this.colTenHang.ReadOnly = true;
            // colDvt
            // 
            this.colDvt.Name = "colDvt";
            this.colDvt.ReadOnly = true;
            // colSoLuong
            // 
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // colHanSuDung
            // 
            this.colHanSuDung.Name = "colHanSuDung";
            this.colHanSuDung.ReadOnly = true;
            // colSoNgay
            // 
            this.colSoNgay.Name = "colSoNgay";
            this.colSoNgay.ReadOnly = true;
            // 
            // FormHangtonhethandung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 477);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.tvMain);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.colMaHang);
            this.Controls.Add(this.colTenHang);
            this.Controls.Add(this.colDvt);
            this.Controls.Add(this.colSoLuong);
            this.Controls.Add(this.colHanSuDung);
            this.Controls.Add(this.colSoNgay);
            this.Name = "FormHangtonhethandung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hàng tồn hết hạn dùng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Control tvMain;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox txtLoc;
        public System.Windows.Forms.TextBox colMaHang;
        public System.Windows.Forms.TextBox colTenHang;
        public System.Windows.Forms.TextBox colDvt;
        public System.Windows.Forms.DataGridView colSoLuong;
        public System.Windows.Forms.Control colHanSuDung;
        public System.Windows.Forms.DataGridView colSoNgay;
    }
}