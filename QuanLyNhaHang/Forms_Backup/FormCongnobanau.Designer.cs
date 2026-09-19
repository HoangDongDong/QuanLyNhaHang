namespace QuanLyNhaHang
{
    partial class FormCongnobanau
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
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.colMaKhach = new System.Windows.Forms.TextBox();
            this.colTenKhach = new System.Windows.Forms.TextBox();
            this.colDiaChi = new System.Windows.Forms.TextBox();
            this.colDienThoai = new System.Windows.Forms.TextBox();
            this.colDonGia = new System.Windows.Forms.DataGridView();
            this.toolStripLabel1 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.Control();
            this.toolStrip1 = new System.Windows.Forms.Control();
            this.tsbImport = new System.Windows.Forms.Button();
            this.tsbFileMau = new System.Windows.Forms.Button();
            this.dtNgay = new System.Windows.Forms.Control();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.KryptonPanel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(734, 495);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // txtLoc
            // 
            this.txtLoc.Size = new System.Drawing.Size(100, 25);
            this.txtLoc.Name = "txtLoc";
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 95);
            this.grMain.Size = new System.Drawing.Size(734, 364);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 16;
            // colMaKhach
            // 
            this.colMaKhach.Name = "colMaKhach";
            this.colMaKhach.ReadOnly = true;
            // colTenKhach
            // 
            this.colTenKhach.Name = "colTenKhach";
            this.colTenKhach.ReadOnly = true;
            // colDiaChi
            // 
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.ReadOnly = true;
            // colDienThoai
            // 
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.ReadOnly = true;
            // colDonGia
            // 
            this.colDonGia.Name = "colDonGia";
            // toolStripLabel1
            // 
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel1.Text = "Lọc (F3)";
            this.toolStripLabel1.Name = "toolStripLabel1";
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 70);
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.TabIndex = 17;
            // tsbImport
            // 
            this.tsbImport.Size = new System.Drawing.Size(106, 22);
            this.tsbImport.Text = "Import từ excel";
            this.tsbImport.Name = "tsbImport";
            // tsbFileMau
            // 
            this.tsbFileMau.Size = new System.Drawing.Size(106, 22);
            this.tsbFileMau.Text = "Export file mẫu";
            this.tsbFileMau.Name = "tsbFileMau";
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(118, 6);
            this.dtNgay.Size = new System.Drawing.Size(91, 20);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.TabIndex = 1;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 39);
            this.KryptonPanel2.Size = new System.Drawing.Size(734, 31);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 15;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.Text = "Ngày chốt công nợ:";
            this.label2.Name = "label2";
            this.label2.TabIndex = 0;
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabIndex = 3;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(734, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 14;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(42, 12);
            this.label1.Size = new System.Drawing.Size(344, 13);
            this.label1.Text = "Cập nhật thông tin công nợ ban đầu khi sử dụng phần mềm";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(575, 3);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Ghi dữ liệu";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(656, 3);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            // KryptonPanel3
            // 
            this.KryptonPanel3.Location = new System.Drawing.Point(0, 459);
            this.KryptonPanel3.Size = new System.Drawing.Size(734, 36);
            this.KryptonPanel3.Name = "KryptonPanel3";
            this.KryptonPanel3.TabIndex = 18;
            // 
            // FormCongnobanau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 495);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.colMaKhach);
            this.Controls.Add(this.colTenKhach);
            this.Controls.Add(this.colDiaChi);
            this.Controls.Add(this.colDienThoai);
            this.Controls.Add(this.colDonGia);
            this.Controls.Add(this.toolStripLabel1);
            this.Controls.Add(this.toolStripSeparator1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tsbImport);
            this.Controls.Add(this.tsbFileMau);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.KryptonPanel3);
            this.Name = "FormCongnobanau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công nợ ban đầu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.TextBox txtLoc;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.TextBox colMaKhach;
        public System.Windows.Forms.TextBox colTenKhach;
        public System.Windows.Forms.TextBox colDiaChi;
        public System.Windows.Forms.TextBox colDienThoai;
        public System.Windows.Forms.DataGridView colDonGia;
        public System.Windows.Forms.Label toolStripLabel1;
        public System.Windows.Forms.Control toolStripSeparator1;
        public System.Windows.Forms.Control toolStrip1;
        public System.Windows.Forms.Button tsbImport;
        public System.Windows.Forms.Button tsbFileMau;
        public System.Windows.Forms.Control dtNgay;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Panel KryptonPanel3;
    }
}