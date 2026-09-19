namespace QuanLyNhaHang
{
    partial class FormDichvumaytinhbang
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
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.TabControl1 = new System.Windows.Forms.Control();
            this.TabPage1 = new System.Windows.Forms.Control();
            this.grServer = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.grPrinter = new System.Windows.Forms.GroupBox();
            this.btnGhiThongTin = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.grSetup = new System.Windows.Forms.DataGridView();
            this.notify = new System.Windows.Forms.Control();
            this.mnuTray = new System.Windows.Forms.Control();
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem = new System.Windows.Forms.Control();
            this.toolStripSeparator1 = new System.Windows.Forms.Control();
            this.thoátKhỏiHệThốngToolStripMenuItem = new System.Windows.Forms.Control();
            this.Timer1 = new System.Windows.Forms.Control();
            this.colKhuVuc = new System.Windows.Forms.TextBox();
            this.colLoaiDo = new System.Windows.Forms.TextBox();
            this.colMayIn = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(487, 458);
            this.No1UserControl1.Name = "No1UserControl1";
            // chkAutoStart
            // 
            this.chkAutoStart.Location = new System.Drawing.Point(80, 293);
            this.chkAutoStart.Size = new System.Drawing.Size(192, 17);
            this.chkAutoStart.Text = "Tự động khởi động cùng Windows";
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.TabIndex = 1;
            // TabControl1
            // 
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Size = new System.Drawing.Size(487, 421);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.TabIndex = 1;
            // TabPage1
            // 
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Size = new System.Drawing.Size(479, 395);
            this.TabPage1.Text = "Thông tin cấu hình";
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.TabIndex = 0;
            // grServer
            // 
            this.grServer.Location = new System.Drawing.Point(6, 6);
            this.grServer.Size = new System.Drawing.Size(467, 71);
            this.grServer.Text = "Cơ sở dữ liệu";
            this.grServer.Name = "grServer";
            this.grServer.TabIndex = 12;
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(123, 45);
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.Text = "Máy chủ:";
            this.label4.Name = "label4";
            this.label4.TabIndex = 11;
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(180, 42);
            this.textBox1.Size = new System.Drawing.Size(281, 20);
            this.textBox1.Text = "localhost";
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 12;
            this.textBox1.ReadOnly = true;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.Text = "Cổng:";
            this.label1.Name = "label1";
            this.label1.TabIndex = 0;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.Text = "Dữ liệu:";
            this.label2.Name = "label2";
            this.label2.TabIndex = 2;
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(74, 42);
            this.txtPort.Size = new System.Drawing.Size(43, 20);
            this.txtPort.Text = "6868";
            this.txtPort.Name = "txtPort";
            this.txtPort.TabIndex = 1;
            this.txtPort.ReadOnly = true;
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(74, 16);
            this.txtDatabase.Size = new System.Drawing.Size(387, 20);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.TabIndex = 3;
            this.txtDatabase.ReadOnly = true;
            // grPrinter
            // 
            this.grPrinter.Location = new System.Drawing.Point(6, 83);
            this.grPrinter.Size = new System.Drawing.Size(467, 204);
            this.grPrinter.Text = "Máy in";
            this.grPrinter.Name = "grPrinter";
            this.grPrinter.TabIndex = 13;
            // btnGhiThongTin
            // 
            this.btnGhiThongTin.Location = new System.Drawing.Point(362, 175);
            this.btnGhiThongTin.Size = new System.Drawing.Size(99, 23);
            this.btnGhiThongTin.Text = "Ghi thông tin";
            this.btnGhiThongTin.Name = "btnGhiThongTin";
            this.btnGhiThongTin.TabIndex = 13;
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(80, 316);
            this.txtIP.Size = new System.Drawing.Size(393, 72);
            this.txtIP.Name = "txtIP";
            this.txtIP.TabIndex = 22;
            this.txtIP.ReadOnly = true;
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 316);
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.Text = "IP:";
            this.label5.Name = "label5";
            this.label5.TabIndex = 21;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 421);
            this.panel1.Size = new System.Drawing.Size(487, 37);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 2;
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(399, 5);
            this.btnDong.Size = new System.Drawing.Size(78, 27);
            this.btnDong.Text = "Ẩn";
            this.btnDong.Name = "btnDong";
            this.btnDong.TabIndex = 11;
            // grSetup
            // 
            this.grSetup.Location = new System.Drawing.Point(3, 19);
            this.grSetup.Size = new System.Drawing.Size(458, 150);
            this.grSetup.Name = "grSetup";
            this.grSetup.TabIndex = 14;
            // notify
            // 
            this.notify.Text = "Phần mềm quản lý in chế biến";
            this.notify.Name = "notify";
            // mnuTray
            // 
            this.mnuTray.Size = new System.Drawing.Size(208, 54);
            this.mnuTray.Name = "mnuTray";
            // hiểnThịCửaSổCấuHìnhToolStripMenuItem
            // 
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem.Text = "Hiển thị cửa sổ cấu hình";
            this.hiểnThịCửaSổCấuHìnhToolStripMenuItem.Name = "hiểnThịCửaSổCấuHìnhToolStripMenuItem";
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // thoátKhỏiHệThốngToolStripMenuItem
            // 
            this.thoátKhỏiHệThốngToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.thoátKhỏiHệThốngToolStripMenuItem.Text = "Thoát khỏi hệ thống";
            this.thoátKhỏiHệThốngToolStripMenuItem.Name = "thoátKhỏiHệThốngToolStripMenuItem";
            // Timer1
            // 
            this.Timer1.Name = "Timer1";
            // colKhuVuc
            // 
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;
            // colLoaiDo
            // 
            this.colLoaiDo.Name = "colLoaiDo";
            this.colLoaiDo.ReadOnly = true;
            // colMayIn
            // 
            this.colMayIn.Name = "colMayIn";
            // 
            // FormDichvumaytinhbang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.TabPage1);
            this.Controls.Add(this.grServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.grPrinter);
            this.Controls.Add(this.btnGhiThongTin);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.grSetup);
            this.Controls.Add(this.notify);
            this.Controls.Add(this.mnuTray);
            this.Controls.Add(this.hiểnThịCửaSổCấuHìnhToolStripMenuItem);
            this.Controls.Add(this.toolStripSeparator1);
            this.Controls.Add(this.thoátKhỏiHệThốngToolStripMenuItem);
            this.Controls.Add(this.Timer1);
            this.Controls.Add(this.colKhuVuc);
            this.Controls.Add(this.colLoaiDo);
            this.Controls.Add(this.colMayIn);
            this.Name = "FormDichvumaytinhbang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dịch vụ máy tính bảng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.CheckBox chkAutoStart;
        public System.Windows.Forms.Control TabControl1;
        public System.Windows.Forms.Control TabPage1;
        public System.Windows.Forms.GroupBox grServer;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtPort;
        public System.Windows.Forms.TextBox txtDatabase;
        public System.Windows.Forms.GroupBox grPrinter;
        public System.Windows.Forms.Button btnGhiThongTin;
        public System.Windows.Forms.TextBox txtIP;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnDong;
        public System.Windows.Forms.DataGridView grSetup;
        public System.Windows.Forms.Control notify;
        public System.Windows.Forms.Control mnuTray;
        public System.Windows.Forms.Control hiểnThịCửaSổCấuHìnhToolStripMenuItem;
        public System.Windows.Forms.Control toolStripSeparator1;
        public System.Windows.Forms.Control thoátKhỏiHệThốngToolStripMenuItem;
        public System.Windows.Forms.Control Timer1;
        public System.Windows.Forms.TextBox colKhuVuc;
        public System.Windows.Forms.TextBox colLoaiDo;
        public System.Windows.Forms.ComboBox colMayIn;
    }
}