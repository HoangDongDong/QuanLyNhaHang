namespace QuanLyNhaHang
{
    partial class FormNhapsoluong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.spSoLuong = new System.Windows.Forms.NumericUpDown();
            this.numCK = new System.Windows.Forms.NumericUpDown();
            this.spSLChan = new System.Windows.Forms.NumericUpDown();
            this.lblDVTLe = new System.Windows.Forms.Label();
            this.lblDVTChan = new System.Windows.Forms.Label();
            this.grKichThuoc = new System.Windows.Forms.DataGridView();
            this.colKichThuoc = new System.Windows.Forms.TextBox();
            this.colTon = new System.Windows.Forms.DataGridView();
            this.txtKichThuoc = new System.Windows.Forms.TextBox();
            this.lblKichThuoc = new System.Windows.Forms.Label();
            this.grHanSuDung = new System.Windows.Forms.DataGridView();
            this.colHanSuDung = new System.Windows.Forms.Control();
            this.colTon2 = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(400, 443);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(400, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 8;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.Text = "Nhập số lượng cho mặt hàng";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 186);
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.Text = "CK (%):";
            this.label3.Name = "label3";
            this.label3.TabIndex = 20;
            // lblDonGia
            // 
            this.lblDonGia.Location = new System.Drawing.Point(12, 100);
            this.lblDonGia.Size = new System.Drawing.Size(376, 30);
            this.lblDonGia.Text = "Đơn giá:";
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.TabIndex = 19;
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(12, 47);
            this.lblItem.Size = new System.Drawing.Size(376, 50);
            this.lblItem.Text = "Mặt hàng:";
            this.lblItem.Name = "lblItem";
            this.lblItem.TabIndex = 18;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 150);
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.Text = "Số lượng:";
            this.label2.Name = "label2";
            this.label2.TabIndex = 17;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(192, 401);
            this.btnOK.Size = new System.Drawing.Size(115, 30);
            this.btnOK.Text = "Ghi dữ liệu";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 5;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(313, 401);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 6;
            // spSoLuong
            // 
            this.spSoLuong.Location = new System.Drawing.Point(116, 148);
            this.spSoLuong.Size = new System.Drawing.Size(69, 26);
            this.spSoLuong.Name = "spSoLuong";
            this.spSoLuong.TabIndex = 0;
            // numCK
            // 
            this.numCK.Location = new System.Drawing.Point(116, 184);
            this.numCK.Size = new System.Drawing.Size(69, 26);
            this.numCK.Name = "numCK";
            this.numCK.TabIndex = 2;
            // spSLChan
            // 
            this.spSLChan.Location = new System.Drawing.Point(268, 148);
            this.spSLChan.Size = new System.Drawing.Size(69, 26);
            this.spSLChan.Name = "spSLChan";
            this.spSLChan.TabIndex = 1;
            // lblDVTLe
            // 
            this.lblDVTLe.Location = new System.Drawing.Point(191, 150);
            this.lblDVTLe.Size = new System.Drawing.Size(50, 20);
            this.lblDVTLe.Text = "thùng";
            this.lblDVTLe.Name = "lblDVTLe";
            this.lblDVTLe.TabIndex = 22;
            // lblDVTChan
            // 
            this.lblDVTChan.Location = new System.Drawing.Point(343, 150);
            this.lblDVTChan.Size = new System.Drawing.Size(36, 20);
            this.lblDVTChan.Text = "hộp";
            this.lblDVTChan.Name = "lblDVTChan";
            this.lblDVTChan.TabIndex = 23;
            // grKichThuoc
            // 
            this.grKichThuoc.Location = new System.Drawing.Point(20, 216);
            this.grKichThuoc.Size = new System.Drawing.Size(368, 177);
            this.grKichThuoc.Name = "grKichThuoc";
            this.grKichThuoc.TabIndex = 4;
            this.grKichThuoc.ReadOnly = true;
            // colKichThuoc
            // 
            this.colKichThuoc.Name = "colKichThuoc";
            this.colKichThuoc.ReadOnly = true;
            // colTon
            // 
            this.colTon.Name = "colTon";
            this.colTon.ReadOnly = true;
            // txtKichThuoc
            // 
            this.txtKichThuoc.Location = new System.Drawing.Point(268, 184);
            this.txtKichThuoc.Size = new System.Drawing.Size(69, 26);
            this.txtKichThuoc.Name = "txtKichThuoc";
            this.txtKichThuoc.TabIndex = 3;
            // lblKichThuoc
            // 
            this.lblKichThuoc.Location = new System.Drawing.Point(192, 186);
            this.lblKichThuoc.Size = new System.Drawing.Size(67, 20);
            this.lblKichThuoc.Text = "K.thước:";
            this.lblKichThuoc.Name = "lblKichThuoc";
            this.lblKichThuoc.TabIndex = 28;
            // grHanSuDung
            // 
            this.grHanSuDung.Location = new System.Drawing.Point(20, 216);
            this.grHanSuDung.Size = new System.Drawing.Size(368, 179);
            this.grHanSuDung.Name = "grHanSuDung";
            this.grHanSuDung.TabIndex = 29;
            this.grHanSuDung.ReadOnly = true;
            // colHanSuDung
            // 
            this.colHanSuDung.Name = "colHanSuDung";
            this.colHanSuDung.ReadOnly = true;
            // colTon2
            // 
            this.colTon2.Name = "colTon2";
            this.colTon2.ReadOnly = true;
            // 
            // FormNhapsoluong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 443);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.spSoLuong);
            this.Controls.Add(this.numCK);
            this.Controls.Add(this.spSLChan);
            this.Controls.Add(this.lblDVTLe);
            this.Controls.Add(this.lblDVTChan);
            this.Controls.Add(this.grKichThuoc);
            this.Controls.Add(this.colKichThuoc);
            this.Controls.Add(this.colTon);
            this.Controls.Add(this.txtKichThuoc);
            this.Controls.Add(this.lblKichThuoc);
            this.Controls.Add(this.grHanSuDung);
            this.Controls.Add(this.colHanSuDung);
            this.Controls.Add(this.colTon2);
            this.Name = "FormNhapsoluong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập số lượng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblDonGia;
        public System.Windows.Forms.Label lblItem;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.NumericUpDown spSoLuong;
        public System.Windows.Forms.NumericUpDown numCK;
        public System.Windows.Forms.NumericUpDown spSLChan;
        public System.Windows.Forms.Label lblDVTLe;
        public System.Windows.Forms.Label lblDVTChan;
        public System.Windows.Forms.DataGridView grKichThuoc;
        public System.Windows.Forms.TextBox colKichThuoc;
        public System.Windows.Forms.DataGridView colTon;
        public System.Windows.Forms.TextBox txtKichThuoc;
        public System.Windows.Forms.Label lblKichThuoc;
        public System.Windows.Forms.DataGridView grHanSuDung;
        public System.Windows.Forms.Control colHanSuDung;
        public System.Windows.Forms.DataGridView colTon2;
    }
}