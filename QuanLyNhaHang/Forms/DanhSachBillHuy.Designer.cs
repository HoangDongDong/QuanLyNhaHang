namespace QuanLyNhaHang.Forms
{
    partial class DanhSachBillHuy
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
            this.KryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.grMain = new No1Lib.Sys.No1DataGrid();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dtNgay = new No1Lib.Sys.FilterDateRange();
            this.grDetail = new No1Lib.Sys.GridMapper();
            this.FilterManager1 = new No1Lib.Sys.FilterManager();
            this.lblLoc = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtLoc = new No1Lib.Sys.No1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).BeginInit();
            this.KryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).BeginInit();
            this.KryptonSplitContainer1.Panel2.SuspendLayout();
            this.KryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // this
            // 
            this.Size = new System.Drawing.Size(678, 514);
            this.Name = "DanhSachBillHuy";
            this.Controls.Add(this.KryptonSplitContainer1);
            this.OnInit += this.DanhSachBillHuy_OnInit;
            // 
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(678, 514);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 2;
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.grDetail);
            this.KryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.grMain);
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.KryptonPanel1);
            this.KryptonSplitContainer1.SplitterDistance = 263;
            // 
            // grMain
            // 
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.ReadOnly = true;
            this.grMain.Size = new System.Drawing.Size(678, 234);
            this.grMain.AutoLoad = false;
            this.grMain.Location = new System.Drawing.Point(0, 29);
            this.grMain.AllowAdding = true;
            this.grMain.AllowDeleting = true;
            this.grMain.GUID = "19ba3aa7-c9e7-45fa-ba04-2e6392a7a523";
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 1;
            this.grMain.Table = "TDONHANGHUY";
            this.grMain.OnFocusedRowChanged += this.grMain_OnFocusedRowChanged;
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel1.Size = new System.Drawing.Size(678, 29);
            this.KryptonPanel1.TabIndex = 0;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Controls.Add(this.txtLoc);
            this.KryptonPanel1.Controls.Add(this.btnRefresh);
            this.KryptonPanel1.Controls.Add(this.lblLoc);
            this.KryptonPanel1.Controls.Add(this.dtNgay);
            // 
            // dtNgay
            // 
            this.dtNgay.Size = new System.Drawing.Size(271, 24);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.BackColor = System.Drawing.Color.Transparent;
            this.dtNgay.Location = new System.Drawing.Point(5, 3);
            this.dtNgay.TabIndex = 0;
            this.dtNgay.LockEvent = false;
            // 
            // grDetail
            // 
            this.grDetail.GUID = "bb78e739-cabc-48b7-8470-60f4fc18af55";
            this.grDetail.Size = new System.Drawing.Size(678, 246);
            this.grDetail.FontSize = 0F;
            this.grDetail.ReadOnly = true;
            this.grDetail.Name = "grDetail";
            this.grDetail.Location = new System.Drawing.Point(0, 0);
            this.grDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetail.ShowToolbar = false;
            this.grDetail.TabIndex = 0;
            this.grDetail.ShowAddButton = false;
            this.grDetail.CustomLoadData += this.grDetail_CustomLoadData;
            // 
            // FilterManager1
            // 
            this.FilterManager1.DataGrid = this.grMain;
            this.FilterManager1.AutoLoad = false;
            this.FilterManager1.AfterFiltered += this.FilterManager1_AfterFiltered;
            // 
            // lblLoc
            // 
            this.lblLoc.TabIndex = 1;
            this.lblLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblLoc.AutoSize = true;
            this.lblLoc.Size = new System.Drawing.Size(25, 13);
            this.lblLoc.Text = "Lọc";
            this.lblLoc.Location = new System.Drawing.Point(287, 7);
            this.lblLoc.Name = "lblLoc";
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(425, 3);
            this.btnRefresh.Click += this.btnRefresh_Click;
            // 
            // txtLoc
            // 
            this.txtLoc.Size = new System.Drawing.Size(100, 20);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Location = new System.Drawing.Point(319, 4);
            this.txtLoc.TabIndex = 3;
            this.txtLoc.TextChanged += this.txtLoc_TextChanged;
            ((System.ComponentModel.ISupportInitialize)(this.FilterManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).EndInit();
            this.KryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).EndInit();
            this.KryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).EndInit();
            this.KryptonSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer KryptonSplitContainer1;
        public No1Lib.Sys.No1DataGrid grMain;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public No1Lib.Sys.FilterDateRange dtNgay;
        public No1Lib.Sys.GridMapper grDetail;
        public No1Lib.Sys.FilterManager FilterManager1;
        public System.Windows.Forms.Label lblLoc;
        public System.Windows.Forms.Button btnRefresh;
        public No1Lib.Sys.No1TextBox txtLoc;
    }
}