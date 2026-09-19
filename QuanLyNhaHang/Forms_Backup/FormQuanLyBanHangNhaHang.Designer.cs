namespace QuanLyNhaHang
{
    partial class FormQuanlybanhangnhahang
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
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.dtNgay = new System.Windows.Forms.Control();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grMain = new System.Windows.Forms.Control();
            this.tmrLoad = new System.Windows.Forms.Control();
            this.btnHuyPhieu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(1024, 466);
            this.No1UserControl1.Name = "No1UserControl1";
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(1024, 31);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 31);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(1024, 435);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 1;
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(3, 4);
            this.dtNgay.Size = new System.Drawing.Size(271, 24);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.TabIndex = 0;
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(281, 4);
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.Text = "Tải dữ liệu";
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 1;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Size = new System.Drawing.Size(261, 435);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 0;
            this.grMain.ReadOnly = true;
            // tmrLoad
            // 
            this.tmrLoad.Name = "tmrLoad";
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.Location = new System.Drawing.Point(931, 4);
            this.btnHuyPhieu.Size = new System.Drawing.Size(90, 23);
            this.btnHuyPhieu.Text = "Hủy phiếu";
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.TabIndex = 2;
            // 
            // FormQuanlybanhangnhahang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.tmrLoad);
            this.Controls.Add(this.btnHuyPhieu);
            this.Name = "FormQuanlybanhangnhahang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán hàng nhà hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Control dtNgay;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Control grMain;
        public System.Windows.Forms.Control tmrLoad;
        public System.Windows.Forms.Button btnHuyPhieu;
    }
}