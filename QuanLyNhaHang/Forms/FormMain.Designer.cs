namespace QuanLyNhaHang
{
    partial class FormMain
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripQuick = new System.Windows.Forms.ToolStrip();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.lblCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblInputType = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.statusStripBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.menuStripMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1280, 28);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // toolStripQuick
            // 
            this.toolStripQuick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.toolStripQuick.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripQuick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripQuick.Location = new System.Drawing.Point(0, 28);
            this.toolStripQuick.Name = "toolStripQuick";
            this.toolStripQuick.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.toolStripQuick.Size = new System.Drawing.Size(1280, 31);
            this.toolStripQuick.TabIndex = 1;
            this.toolStripQuick.Text = "toolStripQuick";
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.statusStripBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCopyright,
            this.lblDbInfo,
            this.lblUser,
            this.lblInputType});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 693);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(1280, 26);
            this.statusStripBottom.TabIndex = 2;
            this.statusStripBottom.Text = "statusStripBottom";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(149, 21);
            this.lblCopyright.Text = "Đăng ký bản quyền: TTS TEST";
            // 
            // lblDbInfo
            // 
            this.lblDbInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbInfo.Margin = new System.Windows.Forms.Padding(500, 3, 0, 2);
            this.lblDbInfo.Name = "lblDbInfo";
            this.lblDbInfo.Size = new System.Drawing.Size(117, 21);
            this.lblDbInfo.Text = "CSDL: DEMO.FDB";
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(107, 21);
            this.lblUser.Text = "Tài khoản: Admin";
            // 
            // lblInputType
            // 
            this.lblInputType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputType.Name = "lblInputType";
            this.lblInputType.Size = new System.Drawing.Size(114, 21);
            this.lblInputType.Text = "Gõ tiếng Việt Telex";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1280, 634);
            this.tabMain.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.tabMain);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 59);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1280, 634);
            this.panelContainer.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1280, 719);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.statusStripBottom);
            this.Controls.Add(this.toolStripQuick);
            this.Controls.Add(this.menuStripMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHẦN MỀM QUẢN LÝ BAR, NHÀ HÀNG v6.0 TÂN AN PHÁT - HOTLINE: 0967041111";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStrip toolStripQuick;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel lblCopyright;
        private System.Windows.Forms.ToolStripStatusLabel lblDbInfo;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblInputType;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TabControl tabMain;
    }
}
