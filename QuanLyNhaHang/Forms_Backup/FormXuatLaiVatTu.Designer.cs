namespace QuanLyNhaHang
{
    partial class FormXuatlaivattu
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
            this.dtNgay = new System.Windows.Forms.Control();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.prMain = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(307, 223);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(12, 67);
            this.dtNgay.Size = new System.Drawing.Size(288, 24);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.TabIndex = 0;
            // lblMatKhau
            // 
            this.lblMatKhau.Location = new System.Drawing.Point(12, 104);
            this.lblMatKhau.Size = new System.Drawing.Size(55, 13);
            this.lblMatKhau.Text = "Mật khẩu:";
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.TabIndex = 1;
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(83, 101);
            this.txtMatKhau.Size = new System.Drawing.Size(174, 20);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.TabIndex = 2;
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(12, 9);
            this.lblNote.Size = new System.Drawing.Size(288, 46);
            this.lblNote.Text = "Chức năng xuất lại định lượng sử dụng khi bạn thiết lập định lượng sau và muốn xuất lại định lượng của các phiếu cũ theo cấu hình định lượng mới.";
            this.lblNote.Name = "lblNote";
            this.lblNote.TabIndex = 3;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(207, 183);
            this.btnCancel.Size = new System.Drawing.Size(88, 28);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(113, 182);
            this.btnThucHien.Size = new System.Drawing.Size(88, 28);
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.TabIndex = 5;
            // prMain
            // 
            this.prMain.Location = new System.Drawing.Point(83, 127);
            this.prMain.Size = new System.Drawing.Size(174, 14);
            this.prMain.Name = "prMain";
            this.prMain.TabIndex = 6;
            // 
            // FormXuatlaivattu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 223);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.prMain);
            this.Name = "FormXuatlaivattu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất lại vật tư";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Control dtNgay;
        public System.Windows.Forms.Label lblMatKhau;
        public System.Windows.Forms.TextBox txtMatKhau;
        public System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnThucHien;
        public System.Windows.Forms.Control prMain;
    }
}