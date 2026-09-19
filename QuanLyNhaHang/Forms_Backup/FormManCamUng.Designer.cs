namespace QuanLyNhaHang
{
    partial class FormMancamung
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
            this.No1UserControl1 = new System.Windows.Forms.Control();
            this.TSLabel1 = new System.Windows.Forms.Label();
            this.grKhuVuc = new System.Windows.Forms.Control();
            this.grNhom = new System.Windows.Forms.Control();
            this.TSLabel2 = new System.Windows.Forms.Label();
            this.TSLabel3 = new System.Windows.Forms.Label();
            this.grMatHang = new System.Windows.Forms.Control();
            this.btnThietKe = new System.Windows.Forms.Button();
            this.btnMauNgauNhien = new System.Windows.Forms.Button();
            this.ptImage = new System.Windows.Forms.Control();
            this.cboMau = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(1038, 653);
            this.No1UserControl1.Name = "No1UserControl1";
            // TSLabel1
            // 
            this.TSLabel1.Location = new System.Drawing.Point(6, 9);
            this.TSLabel1.Size = new System.Drawing.Size(171, 23);
            this.TSLabel1.Text = "KHU VỰC";
            this.TSLabel1.Name = "TSLabel1";
            this.TSLabel1.TabIndex = 0;
            // grKhuVuc
            // 
            this.grKhuVuc.Location = new System.Drawing.Point(6, 35);
            this.grKhuVuc.Size = new System.Drawing.Size(171, 615);
            this.grKhuVuc.Name = "grKhuVuc";
            this.grKhuVuc.TabIndex = 1;
            // grNhom
            // 
            this.grNhom.Location = new System.Drawing.Point(185, 35);
            this.grNhom.Size = new System.Drawing.Size(171, 615);
            this.grNhom.Name = "grNhom";
            this.grNhom.TabIndex = 3;
            // TSLabel2
            // 
            this.TSLabel2.Location = new System.Drawing.Point(185, 9);
            this.TSLabel2.Size = new System.Drawing.Size(171, 23);
            this.TSLabel2.Text = "NHÓM HÀNG";
            this.TSLabel2.Name = "TSLabel2";
            this.TSLabel2.TabIndex = 2;
            // TSLabel3
            // 
            this.TSLabel3.Location = new System.Drawing.Point(367, 9);
            this.TSLabel3.Size = new System.Drawing.Size(462, 23);
            this.TSLabel3.Text = "MẶT HÀNG";
            this.TSLabel3.Name = "TSLabel3";
            this.TSLabel3.TabIndex = 4;
            // grMatHang
            // 
            this.grMatHang.Location = new System.Drawing.Point(367, 35);
            this.grMatHang.Size = new System.Drawing.Size(462, 615);
            this.grMatHang.Name = "grMatHang";
            this.grMatHang.TabIndex = 5;
            // btnThietKe
            // 
            this.btnThietKe.Location = new System.Drawing.Point(835, 224);
            this.btnThietKe.Size = new System.Drawing.Size(200, 36);
            this.btnThietKe.Text = "THIẾT KẾ VỊ TRÍ";
            this.btnThietKe.Name = "btnThietKe";
            this.btnThietKe.TabIndex = 6;
            // btnMauNgauNhien
            // 
            this.btnMauNgauNhien.Location = new System.Drawing.Point(835, 266);
            this.btnMauNgauNhien.Size = new System.Drawing.Size(202, 55);
            this.btnMauNgauNhien.Text = "THIẾT LẬP MÀU NHANH";
            this.btnMauNgauNhien.Name = "btnMauNgauNhien";
            this.btnMauNgauNhien.TabIndex = 7;
            // ptImage
            // 
            this.ptImage.Location = new System.Drawing.Point(835, 9);
            this.ptImage.Size = new System.Drawing.Size(200, 167);
            this.ptImage.Name = "ptImage";
            this.ptImage.TabIndex = 21;
            // cboMau
            // 
            this.cboMau.Location = new System.Drawing.Point(835, 185);
            this.cboMau.Size = new System.Drawing.Size(200, 32);
            this.cboMau.Text = "Màu sắc";
            this.cboMau.Name = "cboMau";
            this.cboMau.TabIndex = 22;
            // 
            // FormMancamung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.TSLabel1);
            this.Controls.Add(this.grKhuVuc);
            this.Controls.Add(this.grNhom);
            this.Controls.Add(this.TSLabel2);
            this.Controls.Add(this.TSLabel3);
            this.Controls.Add(this.grMatHang);
            this.Controls.Add(this.btnThietKe);
            this.Controls.Add(this.btnMauNgauNhien);
            this.Controls.Add(this.ptImage);
            this.Controls.Add(this.cboMau);
            this.Name = "FormMancamung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Màn cảm ứng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.Label TSLabel1;
        public System.Windows.Forms.Control grKhuVuc;
        public System.Windows.Forms.Control grNhom;
        public System.Windows.Forms.Label TSLabel2;
        public System.Windows.Forms.Label TSLabel3;
        public System.Windows.Forms.Control grMatHang;
        public System.Windows.Forms.Button btnThietKe;
        public System.Windows.Forms.Button btnMauNgauNhien;
        public System.Windows.Forms.Control ptImage;
        public System.Windows.Forms.Control cboMau;
    }
}