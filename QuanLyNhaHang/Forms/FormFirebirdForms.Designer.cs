namespace QuanLyNhaHang
{
    partial class FormFirebirdForms
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.treeNav = new System.Windows.Forms.TreeView();
            this.tabMainContainer = new System.Windows.Forms.TabControl();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.lblStatusServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusDb = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.statusStripBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.treeNav);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tabMainContainer);
            this.splitMain.Size = new System.Drawing.Size(1240, 683);
            this.splitMain.SplitterDistance = 220;
            this.splitMain.TabIndex = 0;
            // 
            // treeNav
            // 
            this.treeNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeNav.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeNav.ItemHeight = 22;
            this.treeNav.Location = new System.Drawing.Point(0, 0);
            this.treeNav.Name = "treeNav";
            this.treeNav.Size = new System.Drawing.Size(220, 683);
            this.treeNav.TabIndex = 0;
            // 
            // tabMainContainer
            // 
            this.tabMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainContainer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMainContainer.Location = new System.Drawing.Point(0, 0);
            this.tabMainContainer.Name = "tabMainContainer";
            this.tabMainContainer.SelectedIndex = 0;
            this.tabMainContainer.Size = new System.Drawing.Size(1016, 683);
            this.tabMainContainer.TabIndex = 0;
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusServer,
            this.lblStatusDb});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 683);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(1240, 22);
            this.statusStripBottom.TabIndex = 1;
            // 
            // lblStatusServer
            // 
            this.lblStatusServer.Name = "lblStatusServer";
            this.lblStatusServer.Size = new System.Drawing.Size(113, 17);
            this.lblStatusServer.Text = "Máy chủ: localhost  |";
            // 
            // lblStatusDb
            // 
            this.lblStatusDb.Name = "lblStatusDb";
            this.lblStatusDb.Size = new System.Drawing.Size(262, 17);
            this.lblStatusDb.Text = "Cơ sở dữ liệu: d:\\QuanLyNhaHang\\Database\\DEMO.FDB";
            // 
            // FormFirebirdForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 705);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statusStripBottom);
            this.Name = "FormFirebirdForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CÔNG CỤ NHÀ PHÁT TRIỂN";
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TreeView treeNav;
        private System.Windows.Forms.TabControl tabMainContainer;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusServer;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusDb;
    }
}
