namespace QuanLyNhaHang.Forms
{
    partial class ChonLoaiGia
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

        private void InitializeComponent()
        {
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnDonGia = new System.Windows.Forms.Button();
            this.btnDonGia2 = new System.Windows.Forms.Button();
            this.btnDonGia3 = new System.Windows.Forms.Button();
            this.btnDonGia4 = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.chkApDungTatCa = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            
            // KryptonPanel1
            this.KryptonPanel1.Controls.Add(this.btnDonGia);
            this.KryptonPanel1.Controls.Add(this.btnDonGia2);
            this.KryptonPanel1.Controls.Add(this.btnDonGia3);
            this.KryptonPanel1.Controls.Add(this.btnDonGia4);
            this.KryptonPanel1.Controls.Add(this.btnHuyBo);
            this.KryptonPanel1.Controls.Add(this.chkApDungTatCa);
            this.KryptonPanel1.Controls.Add(this.label1);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(324, 261);
            this.KryptonPanel1.TabIndex = 0;
            
            // btnDonGia
            this.btnDonGia.Location = new System.Drawing.Point(12, 12);
            this.btnDonGia.Name = "btnDonGia";
            this.btnDonGia.Size = new System.Drawing.Size(300, 32);
            this.btnDonGia.TabIndex = 6;
            this.btnDonGia.Tag = "1";
            this.btnDonGia.Text = "Giá bán";
            this.btnDonGia.UseVisualStyleBackColor = true;
            this.btnDonGia.Click += new System.EventHandler(this.btnDonGia_Click);
            
            // btnDonGia2
            this.btnDonGia2.Location = new System.Drawing.Point(12, 50);
            this.btnDonGia2.Name = "btnDonGia2";
            this.btnDonGia2.Size = new System.Drawing.Size(300, 32);
            this.btnDonGia2.TabIndex = 7;
            this.btnDonGia.Tag = "2";
            this.btnDonGia2.Text = "Giá bán 2";
            this.btnDonGia2.UseVisualStyleBackColor = true;
            this.btnDonGia2.Click += new System.EventHandler(this.btnDonGia_Click);
            
            // btnDonGia3
            this.btnDonGia3.Location = new System.Drawing.Point(12, 88);
            this.btnDonGia3.Name = "btnDonGia3";
            this.btnDonGia3.Size = new System.Drawing.Size(300, 32);
            this.btnDonGia3.TabIndex = 8;
            this.btnDonGia.Tag = "3";
            this.btnDonGia3.Text = "Giá bán 3";
            this.btnDonGia3.UseVisualStyleBackColor = true;
            this.btnDonGia3.Click += new System.EventHandler(this.btnDonGia_Click);
            
            // btnDonGia4
            this.btnDonGia4.Location = new System.Drawing.Point(12, 126);
            this.btnDonGia4.Name = "btnDonGia4";
            this.btnDonGia4.Size = new System.Drawing.Size(300, 32);
            this.btnDonGia4.TabIndex = 9;
            this.btnDonGia4.Tag = "4";
            this.btnDonGia4.Text = "Giá bán 4";
            this.btnDonGia4.UseVisualStyleBackColor = true;
            this.btnDonGia4.Click += new System.EventHandler(this.btnDonGia_Click);
            
            // btnHuyBo
            this.btnHuyBo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuyBo.Location = new System.Drawing.Point(12, 164);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(300, 32);
            this.btnHuyBo.TabIndex = 11;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            
            // chkApDungTatCa
            this.chkApDungTatCa.AutoSize = true;
            this.chkApDungTatCa.BackColor = System.Drawing.Color.Transparent;
            this.chkApDungTatCa.Location = new System.Drawing.Point(13, 203);
            this.chkApDungTatCa.Name = "chkApDungTatCa";
            this.chkApDungTatCa.Size = new System.Drawing.Size(213, 17);
            this.chkApDungTatCa.TabIndex = 12;
            this.chkApDungTatCa.Text = "Áp dụng cho tất cả mặt hàng trong đơn";
            this.chkApDungTatCa.UseVisualStyleBackColor = false;
            
            // label1
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "(Để kích hoạt các giá 2, 3, 4 bạn vào menu 'Quản trị | Cấu hình toàn hệ thống', tab 'Giá mặt hàng'";
            
            // ChonLoaiGia
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuyBo;
            this.ClientSize = new System.Drawing.Size(324, 261);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChonLoaiGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn loại giá bán";
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Button btnDonGia;
        public System.Windows.Forms.Button btnDonGia2;
        public System.Windows.Forms.Button btnDonGia3;
        public System.Windows.Forms.Button btnDonGia4;
        public System.Windows.Forms.Button btnHuyBo;
        public System.Windows.Forms.CheckBox chkApDungTatCa;
        public System.Windows.Forms.Label label1;
    }
}

