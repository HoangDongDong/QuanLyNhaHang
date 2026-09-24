namespace No1Run
{
    partial class SuDungDichVu : No1Lib.Sys.No1UserControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.splitKhuVuc = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.tabKhuVuc = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabKhuVuc2 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.mapper = new No1Lib.Sys.No1FieldMapper();
            this.tmrAutoRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).BeginInit();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc.Panel1)).BeginInit();
            this.splitKhuVuc.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc.Panel2)).BeginInit();
            this.splitKhuVuc.Panel2.SuspendLayout();
            this.splitKhuVuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabKhuVuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabKhuVuc2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitKhuVuc);
            this.splitMain.Size = new System.Drawing.Size(1024, 545);
            this.splitMain.SplitterDistance = 301;
            this.splitMain.TabIndex = 0;
            // 
            // splitKhuVuc
            // 
            this.splitKhuVuc.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.splitKhuVuc.Name = "splitKhuVuc";
            this.splitKhuVuc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitKhuVuc.Panel1
            // 
            this.splitKhuVuc.Panel1.Controls.Add(this.tabKhuVuc);
            // 
            // splitKhuVuc.Panel2
            // 
            this.splitKhuVuc.Panel2.Controls.Add(this.tabKhuVuc2);
            this.splitKhuVuc.Size = new System.Drawing.Size(301, 545);
            this.splitKhuVuc.SplitterDistance = 268;
            this.splitKhuVuc.TabIndex = 0;
            // 
            // tabKhuVuc
            // 
            this.tabKhuVuc.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.tabKhuVuc.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.Size = new System.Drawing.Size(301, 268);
            this.tabKhuVuc.TabIndex = 0;
            this.tabKhuVuc.Text = "KryptonNavigator1";
            this.tabKhuVuc.SelectedPageChanged += new System.EventHandler(this.tabKhuVuc_SelectedPageChanged);
            // 
            // tabKhuVuc2
            // 
            this.tabKhuVuc2.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.tabKhuVuc2.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabKhuVuc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabKhuVuc2.Location = new System.Drawing.Point(0, 0);
            this.tabKhuVuc2.Name = "tabKhuVuc2";
            this.tabKhuVuc2.Size = new System.Drawing.Size(301, 272);
            this.tabKhuVuc2.TabIndex = 0;
            this.tabKhuVuc2.Text = "KryptonNavigator2147483646";
            this.tabKhuVuc2.SelectedPageChanged += new System.EventHandler(this.tabKhuVuc_SelectedPageChanged);
            // 
            // mapper
            // 
            this.mapper.ID = "";
            // 
            // tmrAutoRefresh
            // 
            this.tmrAutoRefresh.Interval = 30000;
            this.tmrAutoRefresh.Tick += new System.EventHandler(this.tmrAutoRefresh_Tick);
            // 
            // SuDungDichVu
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitMain);
            this.Name = "SuDungDichVu";
            this.Size = new System.Drawing.Size(1024, 545);
            this.OnTabClosing += new System.ComponentModel.CancelEventHandler(this.No1UserControl1_OnTabClosing);
            this.KeyDownEx += new System.Windows.Forms.KeyEventHandler(this.No1UserControl1_KeyDownEx);
            this.OnAddedToTab += new System.EventHandler(this.No1UserControl1_OnAddedToTab);
            this.OnInit += new System.EventHandler(this.No1UserControl1_OnInit);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc.Panel1)).EndInit();
            this.splitKhuVuc.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc.Panel2)).EndInit();
            this.splitKhuVuc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc)).EndInit();
            this.splitKhuVuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabKhuVuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabKhuVuc2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitMain;
        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitKhuVuc;
        public ComponentFactory.Krypton.Navigator.KryptonNavigator tabKhuVuc;
        public ComponentFactory.Krypton.Navigator.KryptonNavigator tabKhuVuc2;
        public No1Lib.Sys.No1FieldMapper mapper;
        public System.Windows.Forms.Timer tmrAutoRefresh;
    }
}
