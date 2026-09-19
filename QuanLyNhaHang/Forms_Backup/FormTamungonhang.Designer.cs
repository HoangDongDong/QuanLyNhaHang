namespace QuanLyNhaHang
{
    partial class FormTamungonhang
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
            this.toolTamUng = new System.Windows.Forms.Control();
            this.grTamUng = new System.Windows.Forms.Control();
            this.tsbThem = new System.Windows.Forms.Button();
            this.tsbSua = new System.Windows.Forms.Button();
            this.tsbXoa = new System.Windows.Forms.Button();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 300);
            this.KryptonPanel1.Size = new System.Drawing.Size(574, 37);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(485, 5);
            this.btnThoat.Size = new System.Drawing.Size(86, 29);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.TabIndex = 1;
            // toolTamUng
            // 
            this.toolTamUng.Location = new System.Drawing.Point(0, 29);
            this.toolTamUng.Size = new System.Drawing.Size(574, 25);
            this.toolTamUng.Text = "ToolStrip2";
            this.toolTamUng.Name = "toolTamUng";
            this.toolTamUng.TabIndex = 24;
            // grTamUng
            // 
            this.grTamUng.Location = new System.Drawing.Point(0, 54);
            this.grTamUng.Size = new System.Drawing.Size(574, 246);
            this.grTamUng.Name = "grTamUng";
            this.grTamUng.TabIndex = 25;
            // tsbThem
            // 
            this.tsbThem.Size = new System.Drawing.Size(106, 22);
            this.tsbThem.Text = "Thêm tạm ứng";
            this.tsbThem.Name = "tsbThem";
            // tsbSua
            // 
            this.tsbSua.Size = new System.Drawing.Size(46, 22);
            this.tsbSua.Text = "Sửa";
            this.tsbSua.Name = "tsbSua";
            // tsbXoa
            // 
            this.tsbXoa.Size = new System.Drawing.Size(47, 22);
            this.tsbXoa.Text = "Xóa";
            this.tsbXoa.Name = "tsbXoa";
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel2.Size = new System.Drawing.Size(574, 29);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 27;
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Size = new System.Drawing.Size(574, 29);
            this.lblTitle.Text = "BÀN TẠM ỨNG:";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 27;
            // 
            // FormTamungonhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 337);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.toolTamUng);
            this.Controls.Add(this.grTamUng);
            this.Controls.Add(this.tsbThem);
            this.Controls.Add(this.tsbSua);
            this.Controls.Add(this.tsbXoa);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormTamungonhang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạm ứng đơn hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Control toolTamUng;
        public System.Windows.Forms.Control grTamUng;
        public System.Windows.Forms.Button tsbThem;
        public System.Windows.Forms.Button tsbSua;
        public System.Windows.Forms.Button tsbXoa;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.Label lblTitle;
    }
}