namespace No1Run
{
    partial class ChuyenBan
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
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.splitKhuVuc = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.tabKhuVuc = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabKhuVuc2 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc.Panel1)).BeginInit();
            this.splitKhuVuc.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc.Panel2)).BeginInit();
            this.splitKhuVuc.Panel2.SuspendLayout();
            this.splitKhuVuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabKhuVuc)).BeginInit();
            this.tabKhuVuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabKhuVuc2)).BeginInit();
            this.tabKhuVuc2.SuspendLayout();
            this.SuspendLayout();
            
            // KryptonPanel1
            this.KryptonPanel1.Controls.Add(this.btnOK);
            this.KryptonPanel1.Controls.Add(this.btnCancel);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 567);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(755, 37);
            this.KryptonPanel1.TabIndex = 0;
            
            // btnOK
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(579, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 28);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Thực hiện";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            
            // btnCancel
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(673, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            
            // panel1
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTenBan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 39);
            this.panel1.TabIndex = 5;
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(46, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(88, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Chuyển phòng";
            
            // pictureBox1
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            try {
                this.pictureBox1.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAQASURBVFhHvVZbTFRXFPWD3C8J4QO++s9Hf2k0Rh3mQUOamDQW4yOxVCSkqU2amrS1NVpelcT3o2nT2BhEqaio7bTcGUpFqSIgGuU5aPAVfDszVNM26dfqXts7I9y5o8PAeJM1s2efddfa58y5+9w5c9K/DHdtEIRIGOnLpHen4aoOwD/wQMH4dRah5ubQI7xVf1bB+HUVoeaB4cdYsPUc3DvOKxgzl+ki1Dw48gQLt5+Hd1cXivdcUDBmjmOZKsLw1rWh/VoUrt3d8O3tgW9PD96Wb4Ixcxwjh9zZ3hM5rq+OnqFwscBTE8TOjtvPCxEwZo5j5JArBeSkt7+d78qW9JsCl6CkqDqIYCgC376LCsbMcczikMt7Zu3KsgTz5LtAN2IojOJv+xSMrf++QMbJoTnvSfsyPFzOGtPvIJRPs7bRCEq+u6xgbBWQb3PMoga1prMnjEVfm/h97Cnc8r86LKUWYI5G8c4PVxSMkxSQTQ1qUTOVIozFVSZ+GY7g5FB8Wbmkky8tgJwl+/sVjJMUkMc8tcih9suKMFxC8IdkZvsH0DIQxoJNrSpcNAn8zfyJwTDePTCoYPwyLrWoSW16OBWh5i1DUSxtGMZ7DUOo7xhH89UwmvsdIHmOlx4cVqTCpSa16WEvwvDIidY8EEVpYwgrDo9ipWD5oRCWye/SxpEEMM/xlU3CFaTEFU1q04Ne9IytRC5/NPVPYNVP17H6SGZBD3pZBeRyc/FjnqcmgDUtt1F27AbKjo7p95rjNyV3KwEfSH61cN63wJg5Jy41pmiKB73oaXnry8QbgkW+2gAqfr6D8pabWHvyFrzVprRXttipKKpqxY+XIvECGDPnxKUGtahJbXrQy/KMv8hMKaLSfxeV/nH4xFiIbK/eSShxywy+74ugjLMTMGbOiUsNalEzmXnsGX9RhIitCzzSGckg2ys7XAwFNNvXG0H5CVktAWOrgAQuNajle15gwsztvTpeRPE3cqptOPKnEBIaEc1290ZRcWpcwdgqwN6K80Sjk1qpmNtXolASTqdaPjfRju4JfOi/p2BsbSx7AXqKGnNz59v/c/vMnVaC57nTqaYFbBPTj367r2CcpIDYKUqtGb05Z/lqTb9X+oWnxsTizb+iviuKj82HCsbMcYwccsVwRsexfUWyuZu3XfoXW7qfoa5rAhvPhvFJ22MFY+Y4Ro719MzqCwmXsNBd3YrPO59h/R9RfNoexnoLGkuOY+SQK5jVV7L40+ERg43n/sYXZ/7CZ6ejCsbMcWw6u/1VGzHpI0qjTRf+wZedTxWMM22e0Kzc0nqrev9TMM7kzJOuBFvrq9rrdJc5VX5sT/BEI3iYzeg5T9V4Mo+GPMqJtM3/BxeNL1fUpJAWAAAAAElFTkSuQmCC")));
            } catch { }
            
            // lblTenBan
            this.lblTenBan.AutoSize = true;
            this.lblTenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTenBan.Location = new System.Drawing.Point(144, 9);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(124, 20);
            this.lblTenBan.TabIndex = 3;
            this.lblTenBan.Text = "Chuyển phòng";
            
            // splitKhuVuc
            this.splitKhuVuc.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitKhuVuc.Location = new System.Drawing.Point(0, 39);
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
            this.splitKhuVuc.Size = new System.Drawing.Size(755, 528);
            this.splitKhuVuc.SplitterDistance = 255;
            this.splitKhuVuc.TabIndex = 6;
            
            // tabKhuVuc
            this.tabKhuVuc.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.tabKhuVuc.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.Size = new System.Drawing.Size(755, 255);
            this.tabKhuVuc.TabIndex = 0;
            this.tabKhuVuc.Text = "KryptonNavigator1";
            
            // tabKhuVuc2
            this.tabKhuVuc2.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.tabKhuVuc2.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabKhuVuc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabKhuVuc2.Location = new System.Drawing.Point(0, 0);
            this.tabKhuVuc2.Name = "tabKhuVuc2";
            this.tabKhuVuc2.Size = new System.Drawing.Size(755, 268);
            this.tabKhuVuc2.TabIndex = 0;
            this.tabKhuVuc2.Text = "KryptonNavigator2147483646";
            
            // ChuyenBan
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(755, 604);
            this.Controls.Add(this.splitKhuVuc);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.KryptonPanel1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển bàn";
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc.Panel1)).EndInit();
            this.splitKhuVuc.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc.Panel2)).EndInit();
            this.splitKhuVuc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitKhuVuc)).EndInit();
            this.splitKhuVuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabKhuVuc)).EndInit();
            this.tabKhuVuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabKhuVuc2)).EndInit();
            this.tabKhuVuc2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblTenBan;
        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitKhuVuc;
        public ComponentFactory.Krypton.Navigator.KryptonNavigator tabKhuVuc;
        public ComponentFactory.Krypton.Navigator.KryptonNavigator tabKhuVuc2;
    }
}

