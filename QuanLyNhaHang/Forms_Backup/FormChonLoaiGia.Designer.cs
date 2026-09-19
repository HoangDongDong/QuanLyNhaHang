namespace QuanLyNhaHang
{
    partial class FormChonloaigia
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
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDonGia4 = new System.Windows.Forms.Button();
            this.btnDonGia3 = new System.Windows.Forms.Button();
            this.btnDonGia2 = new System.Windows.Forms.Button();
            this.btnDonGia = new System.Windows.Forms.Button();
            this.chkApDungTatCa = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(324, 261);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(12, 164);
            this.btnHuyBo.Size = new System.Drawing.Size(300, 32);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.TabIndex = 11;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 223);
            this.label1.Size = new System.Drawing.Size(300, 30);
            this.label1.Text = "(Để kích hoạt các giá 2, 3, 4 bạn vào menu 'Quản trị | Cấu hình toàn hệ thống', tab 'Giá mặt hàng'";
            this.label1.Name = "label1";
            this.label1.TabIndex = 10;
            // btnDonGia4
            // 
            this.btnDonGia4.Location = new System.Drawing.Point(12, 126);
            this.btnDonGia4.Size = new System.Drawing.Size(300, 32);
            this.btnDonGia4.Text = "Giá bán 4";
            this.btnDonGia4.Name = "btnDonGia4";
            this.btnDonGia4.TabIndex = 9;
            // btnDonGia3
            // 
            this.btnDonGia3.Location = new System.Drawing.Point(12, 88);
            this.btnDonGia3.Size = new System.Drawing.Size(300, 32);
            this.btnDonGia3.Text = "Giá bán 3";
            this.btnDonGia3.Name = "btnDonGia3";
            this.btnDonGia3.TabIndex = 8;
            // btnDonGia2
            // 
            this.btnDonGia2.Location = new System.Drawing.Point(12, 50);
            this.btnDonGia2.Size = new System.Drawing.Size(300, 32);
            this.btnDonGia2.Text = "Giá bán 2";
            this.btnDonGia2.Name = "btnDonGia2";
            this.btnDonGia2.TabIndex = 7;
            // btnDonGia
            // 
            this.btnDonGia.Location = new System.Drawing.Point(12, 12);
            this.btnDonGia.Size = new System.Drawing.Size(300, 32);
            this.btnDonGia.Text = "Giá bán";
            this.btnDonGia.Name = "btnDonGia";
            this.btnDonGia.TabIndex = 6;
            // chkApDungTatCa
            // 
            this.chkApDungTatCa.Location = new System.Drawing.Point(13, 203);
            this.chkApDungTatCa.Size = new System.Drawing.Size(213, 17);
            this.chkApDungTatCa.Text = "Áp dụng cho tất cả mặt hàng trong đơn";
            this.chkApDungTatCa.Name = "chkApDungTatCa";
            this.chkApDungTatCa.TabIndex = 12;
            // 
            // FormChonloaigia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 261);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDonGia4);
            this.Controls.Add(this.btnDonGia3);
            this.Controls.Add(this.btnDonGia2);
            this.Controls.Add(this.btnDonGia);
            this.Controls.Add(this.chkApDungTatCa);
            this.Name = "FormChonloaigia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn loại giá";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnHuyBo;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnDonGia4;
        public System.Windows.Forms.Button btnDonGia3;
        public System.Windows.Forms.Button btnDonGia2;
        public System.Windows.Forms.Button btnDonGia;
        public System.Windows.Forms.CheckBox chkApDungTatCa;
    }
}