namespace QuanLyNhaHang
{
    partial class FormDanhsachbillhuy
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
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.grMain = new System.Windows.Forms.Control();
            this.KryptonPanel1 = new System.Windows.Forms.Panel();
            this.dtNgay = new System.Windows.Forms.Control();
            this.grDetail = new System.Windows.Forms.Control();
            this.FilterManager1 = new System.Windows.Forms.Control();
            this.lblLoc = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(678, 514);
            this.No1UserControl1.Name = "No1UserControl1";
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(678, 514);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 2;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 29);
            this.grMain.Size = new System.Drawing.Size(678, 234);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 1;
            this.grMain.ReadOnly = true;
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(678, 29);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(5, 3);
            this.dtNgay.Size = new System.Drawing.Size(271, 24);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.TabIndex = 0;
            // grDetail
            // 
            this.grDetail.Location = new System.Drawing.Point(0, 0);
            this.grDetail.Size = new System.Drawing.Size(678, 246);
            this.grDetail.Name = "grDetail";
            this.grDetail.TabIndex = 0;
            this.grDetail.ReadOnly = true;
            // FilterManager1
            // 
            this.FilterManager1.Name = "FilterManager1";
            // lblLoc
            // 
            this.lblLoc.Location = new System.Drawing.Point(287, 7);
            this.lblLoc.Size = new System.Drawing.Size(25, 13);
            this.lblLoc.Text = "Lọc";
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.TabIndex = 1;
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(425, 3);
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 2;
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(319, 4);
            this.txtLoc.Size = new System.Drawing.Size(100, 20);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.TabIndex = 3;
            // 
            // FormDanhsachbillhuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.grDetail);
            this.Controls.Add(this.FilterManager1);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtLoc);
            this.Name = "FormDanhsachbillhuy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách bill hủy";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Control grMain;
        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Control dtNgay;
        public System.Windows.Forms.Control grDetail;
        public System.Windows.Forms.Control FilterManager1;
        public System.Windows.Forms.Label lblLoc;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.TextBox txtLoc;
    }
}