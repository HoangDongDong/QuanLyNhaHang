namespace QuanLyNhaHang
{
    partial class FormChiluong
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.Control();
            this.tsbPhieuChi = new System.Windows.Forms.Button();
            this.kryptonPanel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grChiLuong = new System.Windows.Forms.DataGridView();
            this.colNhanVien = new System.Windows.Forms.TextBox();
            this.colTienLuong = new System.Windows.Forms.DataGridView();
            this.colDaNhan = new System.Windows.Forms.DataGridView();
            this.colSoPhieuChi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(562, 38);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 6;
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(41, 12);
            this.lblTitle.Size = new System.Drawing.Size(139, 13);
            this.lblTitle.Text = "Chi tiết chi lương tháng";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 4;
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabIndex = 3;
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 38);
            this.toolStrip1.Size = new System.Drawing.Size(562, 25);
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.TabIndex = 10;
            // tsbPhieuChi
            // 
            this.tsbPhieuChi.Size = new System.Drawing.Size(117, 22);
            this.tsbPhieuChi.Text = "Tạo phiếu chi lương";
            this.tsbPhieuChi.Name = "tsbPhieuChi";
            // kryptonPanel1
            // 
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 412);
            this.kryptonPanel1.Size = new System.Drawing.Size(562, 42);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.TabIndex = 11;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(475, 6);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 9;
            // grChiLuong
            // 
            this.grChiLuong.Location = new System.Drawing.Point(0, 63);
            this.grChiLuong.Size = new System.Drawing.Size(562, 349);
            this.grChiLuong.Name = "grChiLuong";
            this.grChiLuong.TabIndex = 12;
            this.grChiLuong.ReadOnly = true;
            // colNhanVien
            // 
            this.colNhanVien.Name = "colNhanVien";
            this.colNhanVien.ReadOnly = true;
            // colTienLuong
            // 
            this.colTienLuong.Name = "colTienLuong";
            this.colTienLuong.ReadOnly = true;
            // colDaNhan
            // 
            this.colDaNhan.Name = "colDaNhan";
            this.colDaNhan.ReadOnly = true;
            // colSoPhieuChi
            // 
            this.colSoPhieuChi.Name = "colSoPhieuChi";
            this.colSoPhieuChi.ReadOnly = true;
            // 
            // FormChiluong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 454);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tsbPhieuChi);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grChiLuong);
            this.Controls.Add(this.colNhanVien);
            this.Controls.Add(this.colTienLuong);
            this.Controls.Add(this.colDaNhan);
            this.Controls.Add(this.colSoPhieuChi);
            this.Name = "FormChiluong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi lương";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Control toolStrip1;
        public System.Windows.Forms.Button tsbPhieuChi;
        public System.Windows.Forms.Panel kryptonPanel1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.DataGridView grChiLuong;
        public System.Windows.Forms.TextBox colNhanVien;
        public System.Windows.Forms.DataGridView colTienLuong;
        public System.Windows.Forms.DataGridView colDaNhan;
        public System.Windows.Forms.TextBox colSoPhieuChi;
    }
}