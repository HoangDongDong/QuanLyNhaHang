namespace QuanLyNhaHang.Forms
{
    partial class DichVuMayTinhBang
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.grPrinter = new System.Windows.Forms.GroupBox();
            this.grSetup = new No1Lib.Sys.MiscDataGridView();
            this.colKhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMayIn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnGhiThongTin = new System.Windows.Forms.Button();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grServer = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.thoátKhỏiHệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.grPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grSetup)).BeginInit();
            this.grServer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mnuTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(487, 421);
            this.TabControl1.TabIndex = 1;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.txtIP);
            this.TabPage1.Controls.Add(this.grPrinter);
            this.TabPage1.Controls.Add(this.chkAutoStart);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.grServer);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(479, 395);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Thông tin cấu hình";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // txtIP
            // 
            this.txtIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIP.Location = new System.Drawing.Point(80, 316);
            this.txtIP.Multiline = true;
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIP.Size = new System.Drawing.Size(393, 72);
            this.txtIP.TabIndex = 22;
            // 
            // grPrinter
            // 
            this.grPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grPrinter.Controls.Add(this.grSetup);
            this.grPrinter.Controls.Add(this.btnGhiThongTin);
            this.grPrinter.Location = new System.Drawing.Point(6, 83);
            this.grPrinter.Name = "grPrinter";
            this.grPrinter.Size = new System.Drawing.Size(467, 204);
            this.grPrinter.TabIndex = 13;
            this.grPrinter.TabStop = false;
            this.grPrinter.Text = "Máy in";
            // 
            // grSetup
            // 
            this.grSetup.AllowUserToAddRows = false;
            this.grSetup.AllowUserToDeleteRows = false;
            this.grSetup.AllowUserToOrderColumns = true;
            this.grSetup.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.grSetup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grSetup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grSetup.BackgroundColor = System.Drawing.Color.White;
            this.grSetup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grSetup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grSetup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKhuVuc,
            this.colLoaiDo,
            this.colMayIn});
            this.grSetup.GUID = "20b36f51-9ea2-4650-b7bb-bdfaed7a4bcd";
            this.grSetup.Location = new System.Drawing.Point(3, 19);
            this.grSetup.Name = "grSetup";
            this.grSetup.RowHeadersVisible = false;
            this.grSetup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grSetup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grSetup.ShowCellToolTips = false;
            this.grSetup.Size = new System.Drawing.Size(458, 150);
            this.grSetup.TabIndex = 14;
            // 
            // colKhuVuc
            // 
            this.colKhuVuc.DataPropertyName = "KHUVUC";
            this.colKhuVuc.HeaderText = "Khu vực";
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;
            // 
            // colLoaiDo
            // 
            this.colLoaiDo.DataPropertyName = "LOAIDO";
            this.colLoaiDo.HeaderText = "Loại đồ";
            this.colLoaiDo.Name = "colLoaiDo";
            this.colLoaiDo.ReadOnly = true;
            // 
            // colMayIn
            // 
            this.colMayIn.DataPropertyName = "MAYIN";
            this.colMayIn.FillWeight = 200F;
            this.colMayIn.HeaderText = "Máy in";
            this.colMayIn.Name = "colMayIn";
            // 
            // btnGhiThongTin
            // 
            this.btnGhiThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhiThongTin.Location = new System.Drawing.Point(362, 175);
            this.btnGhiThongTin.Name = "btnGhiThongTin";
            this.btnGhiThongTin.Size = new System.Drawing.Size(99, 23);
            this.btnGhiThongTin.TabIndex = 13;
            this.btnGhiThongTin.Text = "Ghi thông tin";
            this.btnGhiThongTin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGhiThongTin.UseVisualStyleBackColor = true;
            this.btnGhiThongTin.Click += new System.EventHandler(this.btnGhiThongTin_Click);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.BackColor = System.Drawing.Color.Transparent;
            this.chkAutoStart.Location = new System.Drawing.Point(80, 293);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(192, 17);
            this.chkAutoStart.TabIndex = 1;
            this.chkAutoStart.Text = "Tự động khởi động cùng Windows";
            this.chkAutoStart.UseVisualStyleBackColor = false;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "IP:";
            // 
            // grServer
            // 
            this.grServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grServer.Controls.Add(this.label4);
            this.grServer.Controls.Add(this.textBox1);
            this.grServer.Controls.Add(this.label1);
            this.grServer.Controls.Add(this.label2);
            this.grServer.Controls.Add(this.txtPort);
            this.grServer.Controls.Add(this.txtDatabase);
            this.grServer.Location = new System.Drawing.Point(6, 6);
            this.grServer.Name = "grServer";
            this.grServer.Size = new System.Drawing.Size(467, 71);
            this.grServer.TabIndex = 12;
            this.grServer.TabStop = false;
            this.grServer.Text = "Cơ sở dữ liệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Máy chủ:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(180, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(281, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "localhost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cổng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dữ liệu:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(74, 42);
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(43, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "6868";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.Location = new System.Drawing.Point(74, 16);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.ReadOnly = true;
            this.txtDatabase.Size = new System.Drawing.Size(387, 20);
            this.txtDatabase.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 421);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 37);
            this.panel1.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(399, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(78, 27);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "Ẩn";
            this.btnDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // notify
            // 
            this.notify.ContextMenuStrip = this.mnuTray;
            this.notify.Text = "Phần mềm quản lý in chế biến";
            this.notify.Visible = true;
            this.notify.DoubleClick += new System.EventHandler(this.notify_Click);
            // 
            // mnuTray
            // 
            this.mnuTray.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mnuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem,
            this.toolStripSeparator1,
            this.thoátKhỏiHệThốngToolStripMenuItem});
            this.mnuTray.Name = "mnuTray";
            this.mnuTray.Size = new System.Drawing.Size(208, 54);
            // 
            // hiểnThịCửaSổCấuHìnhToolStripMenuItem
            // 
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem.Name = "hiểnThịCửaSổCấuHìnhToolStripMenuItem";
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem.Text = "Hiển thị cửa sổ cấu hình";
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem.Click += new System.EventHandler(this.hiểnThịCửaSổCấuHìnhToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // thoátKhỏiHệThốngToolStripMenuItem
            // 
            this.thoátKhỏiHệThốngToolStripMenuItem.Name = "thoátKhỏiHệThốngToolStripMenuItem";
            this.thoátKhỏiHệThốngToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.thoátKhỏiHệThốngToolStripMenuItem.Text = "Thoát khỏi hệ thống";
            this.thoátKhỏiHệThốngToolStripMenuItem.Click += new System.EventHandler(this.thoátKhỏiHệThốngToolStripMenuItem_Click);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // DichVuMayTinhBang
            // 
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "DichVuMayTinhBang";
            this.Size = new System.Drawing.Size(487, 458);
            this.OnInit += new System.EventHandler(this.DichVuMayTinhBang_OnInit);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.grPrinter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grSetup)).EndInit();
            this.grServer.ResumeLayout(false);
            this.grServer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.mnuTray.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public System.Windows.Forms.TabControl TabControl1;
        public System.Windows.Forms.TabPage TabPage1;
        public System.Windows.Forms.TextBox txtIP;
        public System.Windows.Forms.GroupBox grPrinter;
        public No1Lib.Sys.MiscDataGridView grSetup;
        public System.Windows.Forms.DataGridViewTextBoxColumn colKhuVuc;
        public System.Windows.Forms.DataGridViewTextBoxColumn colLoaiDo;
        public System.Windows.Forms.DataGridViewComboBoxColumn colMayIn;
        public System.Windows.Forms.Button btnGhiThongTin;
        public System.Windows.Forms.CheckBox chkAutoStart;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.GroupBox grServer;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtPort;
        public System.Windows.Forms.TextBox txtDatabase;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnDong;
        public System.Windows.Forms.NotifyIcon notify;
        public System.Windows.Forms.ContextMenuStrip mnuTray;
        public System.Windows.Forms.ToolStripMenuItem hiểnThịCửaSổCấuHìnhToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem thoátKhỏiHệThốngToolStripMenuItem;
        public System.Windows.Forms.Timer Timer1;
    }
}
