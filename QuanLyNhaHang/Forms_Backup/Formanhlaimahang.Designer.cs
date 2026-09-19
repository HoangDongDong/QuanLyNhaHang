namespace QuanLyNhaHang
{
    partial class Formanhlaimahang
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMaNhom = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.prDetail = new System.Windows.Forms.Control();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.prMain = new System.Windows.Forms.Control();
            this.chkMaNhom = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.colNhom = new System.Windows.Forms.TextBox();
            this.colMa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(472, 410);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Size = new System.Drawing.Size(406, 30);
            this.label1.Text = "Hệ thống sẽ đánh lại toàn bộ mã hàng sắp xếp theo tên hàng dựa vào cấu hình mã nhóm hàng của bạn.";
            this.label1.Name = "label1";
            this.label1.TabIndex = 8;
            // btnMaNhom
            // 
            this.btnMaNhom.Location = new System.Drawing.Point(150, 39);
            this.btnMaNhom.Size = new System.Drawing.Size(153, 25);
            this.btnMaNhom.Text = "Tự động phân mã nhóm";
            this.btnMaNhom.Name = "btnMaNhom";
            this.btnMaNhom.TabIndex = 21;
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(366, 41);
            this.txtMatKhau.Size = new System.Drawing.Size(100, 20);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.TabIndex = 16;
            // prDetail
            // 
            this.prDetail.Location = new System.Drawing.Point(3, 334);
            this.prDetail.Size = new System.Drawing.Size(463, 17);
            this.prDetail.Name = "prDetail";
            this.prDetail.TabIndex = 22;
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(3, 374);
            this.lblTrangThai.Size = new System.Drawing.Size(249, 28);
            this.lblTrangThai.Text = "Chuẩn bị thực hiện...";
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.TabIndex = 20;
            // prMain
            // 
            this.prMain.Location = new System.Drawing.Point(3, 353);
            this.prMain.Size = new System.Drawing.Size(463, 16);
            this.prMain.Name = "prMain";
            this.prMain.TabIndex = 19;
            // chkMaNhom
            // 
            this.chkMaNhom.Location = new System.Drawing.Point(12, 44);
            this.chkMaNhom.Size = new System.Drawing.Size(115, 17);
            this.chkMaNhom.Text = "Cập nhật mã nhóm";
            this.chkMaNhom.Name = "chkMaNhom";
            this.chkMaNhom.TabIndex = 18;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(309, 45);
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.Text = "Mật khẩu";
            this.label2.Name = "label2";
            this.label2.TabIndex = 17;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(310, 375);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Thực hiện";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 14;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(391, 375);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 15;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(3, 67);
            this.grMain.Size = new System.Drawing.Size(463, 261);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 23;
            this.grMain.ReadOnly = true;
            // colNhom
            // 
            this.colNhom.Name = "colNhom";
            this.colNhom.ReadOnly = true;
            // colMa
            // 
            this.colMa.Name = "colMa";
            this.colMa.ReadOnly = true;
            // 
            // Formanhlaimahang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 410);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMaNhom);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.prDetail);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.prMain);
            this.Controls.Add(this.chkMaNhom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.colNhom);
            this.Controls.Add(this.colMa);
            this.Name = "Formanhlaimahang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đánh lại mã hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnMaNhom;
        public System.Windows.Forms.TextBox txtMatKhau;
        public System.Windows.Forms.Control prDetail;
        public System.Windows.Forms.Label lblTrangThai;
        public System.Windows.Forms.Control prMain;
        public System.Windows.Forms.CheckBox chkMaNhom;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.TextBox colNhom;
        public System.Windows.Forms.TextBox colMa;
    }
}