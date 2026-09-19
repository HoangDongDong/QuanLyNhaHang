namespace QuanLyNhaHang
{
    partial class FormSudungdichvu
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
            this.splitMain = new System.Windows.Forms.Control();
            this.splitKhuVuc = new System.Windows.Forms.Control();
            this.tabKhuVuc = new System.Windows.Forms.Control();
            this.tabKhuVuc2 = new System.Windows.Forms.Control();
            this.mapper = new System.Windows.Forms.Control();
            this.tmrAutoRefresh = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(1024, 545);
            this.No1UserControl1.Name = "No1UserControl1";
            // splitMain
            // 
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Size = new System.Drawing.Size(1024, 545);
            this.splitMain.Name = "splitMain";
            this.splitMain.TabIndex = 0;
            // splitKhuVuc
            // 
            this.splitKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.splitKhuVuc.Size = new System.Drawing.Size(301, 545);
            this.splitKhuVuc.Name = "splitKhuVuc";
            this.splitKhuVuc.TabIndex = 0;
            // tabKhuVuc
            // 
            this.tabKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.tabKhuVuc.Size = new System.Drawing.Size(301, 268);
            this.tabKhuVuc.Text = "KryptonNavigator1";
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.TabIndex = 0;
            // tabKhuVuc2
            // 
            this.tabKhuVuc2.Location = new System.Drawing.Point(0, 0);
            this.tabKhuVuc2.Size = new System.Drawing.Size(301, 272);
            this.tabKhuVuc2.Text = "KryptonNavigator2147483646";
            this.tabKhuVuc2.Name = "tabKhuVuc2";
            this.tabKhuVuc2.TabIndex = 0;
            // mapper
            // 
            this.mapper.Name = "mapper";
            // tmrAutoRefresh
            // 
            this.tmrAutoRefresh.Name = "tmrAutoRefresh";
            // 
            // FormSudungdichvu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.splitKhuVuc);
            this.Controls.Add(this.tabKhuVuc);
            this.Controls.Add(this.tabKhuVuc2);
            this.Controls.Add(this.mapper);
            this.Controls.Add(this.tmrAutoRefresh);
            this.Name = "FormSudungdichvu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sử dụng dịch vụ";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.Control splitMain;
        public System.Windows.Forms.Control splitKhuVuc;
        public System.Windows.Forms.Control tabKhuVuc;
        public System.Windows.Forms.Control tabKhuVuc2;
        public System.Windows.Forms.Control mapper;
        public System.Windows.Forms.Control tmrAutoRefresh;
    }
}