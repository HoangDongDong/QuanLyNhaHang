namespace QuanLyNhaHang
{
    partial class FormTamungluong
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
            this.KryptonPanel1 = new System.Windows.Forms.Panel();
            this.grMain = new System.Windows.Forms.Control();
            this.dtFilter = new System.Windows.Forms.Control();
            this.FilterManager1 = new System.Windows.Forms.Control();
            this.ToolStrip1 = new System.Windows.Forms.Control();
            this.tsbTaoMoi = new System.Windows.Forms.Button();
            this.tsbChinhSua = new System.Windows.Forms.Button();
            this.tsbXoa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(660, 508);
            this.No1UserControl1.Name = "No1UserControl1";
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(660, 31);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 56);
            this.grMain.Size = new System.Drawing.Size(660, 452);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 1;
            // dtFilter
            // 
            this.dtFilter.Location = new System.Drawing.Point(3, 4);
            this.dtFilter.Size = new System.Drawing.Size(271, 24);
            this.dtFilter.Name = "dtFilter";
            this.dtFilter.TabIndex = 0;
            // FilterManager1
            // 
            this.FilterManager1.Name = "FilterManager1";
            // ToolStrip1
            // 
            this.ToolStrip1.Location = new System.Drawing.Point(0, 31);
            this.ToolStrip1.Size = new System.Drawing.Size(660, 25);
            this.ToolStrip1.Text = "ToolStrip1";
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.TabIndex = 2;
            // tsbTaoMoi
            // 
            this.tsbTaoMoi.Size = new System.Drawing.Size(71, 22);
            this.tsbTaoMoi.Text = "Tạo mới";
            this.tsbTaoMoi.Name = "tsbTaoMoi";
            // tsbChinhSua
            // 
            this.tsbChinhSua.Size = new System.Drawing.Size(80, 22);
            this.tsbChinhSua.Text = "Chỉnh sửa";
            this.tsbChinhSua.Name = "tsbChinhSua";
            // tsbXoa
            // 
            this.tsbXoa.Size = new System.Drawing.Size(47, 22);
            this.tsbXoa.Text = "Xóa";
            this.tsbXoa.Name = "tsbXoa";
            // 
            // FormTamungluong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.dtFilter);
            this.Controls.Add(this.FilterManager1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.tsbTaoMoi);
            this.Controls.Add(this.tsbChinhSua);
            this.Controls.Add(this.tsbXoa);
            this.Name = "FormTamungluong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạm ứng lương";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Control grMain;
        public System.Windows.Forms.Control dtFilter;
        public System.Windows.Forms.Control FilterManager1;
        public System.Windows.Forms.Control ToolStrip1;
        public System.Windows.Forms.Button tsbTaoMoi;
        public System.Windows.Forms.Button tsbChinhSua;
        public System.Windows.Forms.Button tsbXoa;
    }
}