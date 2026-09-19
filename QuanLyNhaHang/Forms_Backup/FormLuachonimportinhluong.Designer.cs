namespace QuanLyNhaHang
{
    partial class FormLuachonimportinhluong
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
            this.btnChonFile = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnXuatFileMau = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(375, 227);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 113);
            this.btnChonFile.Size = new System.Drawing.Size(350, 29);
            this.btnChonFile.Text = "Chọn file excel";
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.TabIndex = 0;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(13, 13);
            this.Label1.Size = new System.Drawing.Size(350, 87);
            this.Label1.Text = "Chức năng này cho phép bạn cập nhật nhanh định lượng từ excel mà không cần làm từng món một.

Lưu ý: Sau khi cập nhật định lượng, các mặt hàng sẽ được tự động chuyển qua loại mặt hàng pha chế.
Không sử dụng chức năng này cho mặt hàng combo.";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 1;
            // btnXuatFileMau
            // 
            this.btnXuatFileMau.Location = new System.Drawing.Point(12, 148);
            this.btnXuatFileMau.Size = new System.Drawing.Size(350, 29);
            this.btnXuatFileMau.Text = "Xuất file mẫu";
            this.btnXuatFileMau.Name = "btnXuatFileMau";
            this.btnXuatFileMau.TabIndex = 2;
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(12, 183);
            this.btnHuyBo.Size = new System.Drawing.Size(350, 29);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.TabIndex = 3;
            // 
            // FormLuachonimportinhluong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 227);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnXuatFileMau);
            this.Controls.Add(this.btnHuyBo);
            this.Name = "FormLuachonimportinhluong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lựa chọn import định lượng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnChonFile;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Button btnXuatFileMau;
        public System.Windows.Forms.Button btnHuyBo;
    }
}