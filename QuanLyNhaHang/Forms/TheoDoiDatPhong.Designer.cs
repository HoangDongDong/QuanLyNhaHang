namespace No1Run
{
    partial class TheoDoiDatPhong
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblSelectedArea = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.dtNgay = new No1Lib.Sys.No1DatePicker();
            this.btnChia4 = new System.Windows.Forms.Button();
            this.btnChia2 = new System.Windows.Forms.Button();
            this.btnNhan2 = new System.Windows.Forms.Button();
            this.btnNhan4 = new System.Windows.Forms.Button();
            this.lueLoaiPhong = new No1Lib.Sys.No1LookupEdit();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.mnuPopUp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TạoĐặtPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MởĐặtPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XóaĐặtPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NhậpSốNgàyXemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NgàyToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.NgàyToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.NgàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NgàyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NgàyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ThángNàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThángTrướcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThángSauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XuấtExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            this.mnuPopUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.lblLeft);
            this.Panel1.Controls.Add(this.lblRight);
            this.Panel1.Controls.Add(this.lblSelectedArea);
            this.Panel1.Controls.Add(this.grMain);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(681, 544);
            this.Panel1.TabIndex = 1;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.dtNgay);
            this.Panel2.Controls.Add(this.btnNhan4);
            this.Panel2.Controls.Add(this.lueLoaiPhong);
            this.Panel2.Controls.Add(this.btnNhan2);
            this.Panel2.Controls.Add(this.btnChia4);
            this.Panel2.Controls.Add(this.btnChia2);
            this.Panel2.Location = new System.Drawing.Point(1, 1);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(199, 44);
            this.Panel2.TabIndex = 11;
            // 
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(1, 0);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(95, 20);
            this.dtNgay.TabIndex = 5;
            this.dtNgay.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.dtNgay_OnEditValueChanged);
            // 
            // btnChia4
            // 
            this.btnChia4.Location = new System.Drawing.Point(95, -1);
            this.btnChia4.Name = "btnChia4";
            this.btnChia4.Size = new System.Drawing.Size(27, 23);
            this.btnChia4.TabIndex = 7;
            this.btnChia4.Text = "/4";
            this.btnChia4.UseVisualStyleBackColor = true;
            this.btnChia4.Click += new System.EventHandler(this.btnChia4_Click);
            // 
            // btnChia2
            // 
            this.btnChia2.Location = new System.Drawing.Point(121, -1);
            this.btnChia2.Name = "btnChia2";
            this.btnChia2.Size = new System.Drawing.Size(27, 23);
            this.btnChia2.TabIndex = 8;
            this.btnChia2.Text = "/2";
            this.btnChia2.UseVisualStyleBackColor = true;
            this.btnChia2.Click += new System.EventHandler(this.btnChia2_Click);
            // 
            // btnNhan2
            // 
            this.btnNhan2.Location = new System.Drawing.Point(147, -1);
            this.btnNhan2.Name = "btnNhan2";
            this.btnNhan2.Size = new System.Drawing.Size(27, 23);
            this.btnNhan2.TabIndex = 9;
            this.btnNhan2.Text = "2x";
            this.btnNhan2.UseVisualStyleBackColor = true;
            this.btnNhan2.Click += new System.EventHandler(this.btnNhan2_Click);
            // 
            // btnNhan4
            // 
            this.btnNhan4.Location = new System.Drawing.Point(173, -1);
            this.btnNhan4.Name = "btnNhan4";
            this.btnNhan4.Size = new System.Drawing.Size(27, 23);
            this.btnNhan4.TabIndex = 10;
            this.btnNhan4.Text = "4x";
            this.btnNhan4.UseVisualStyleBackColor = true;
            this.btnNhan4.Click += new System.EventHandler(this.btnNhan4_Click);
            // 
            // lueLoaiPhong
            // 
            this.lueLoaiPhong.BackColor = System.Drawing.Color.White;
            this.lueLoaiPhong.Location = new System.Drawing.Point(1, 23);
            this.lueLoaiPhong.Name = "lueLoaiPhong";
            this.lueLoaiPhong.Size = new System.Drawing.Size(198, 21);
            this.lueLoaiPhong.TabIndex = 4;
            this.lueLoaiPhong.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.lueLoaiPhong_OnEditValueChanged);
            // 
            // lblSelectedArea
            // 
            this.lblSelectedArea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSelectedArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedArea.ContextMenuStrip = this.mnuPopUp;
            this.lblSelectedArea.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblSelectedArea.Location = new System.Drawing.Point(126, 80);
            this.lblSelectedArea.Name = "lblSelectedArea";
            this.lblSelectedArea.Size = new System.Drawing.Size(202, 36);
            this.lblSelectedArea.TabIndex = 1;
            this.lblSelectedArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectedArea.Visible = false;
            this.lblSelectedArea.DoubleClick += new System.EventHandler(this.lblSelectedArea_DoubleClick);
            this.lblSelectedArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblSelectedArea_MouseDown);
            this.lblSelectedArea.MouseEnter += new System.EventHandler(this.lblSelectedArea_MouseEnter);
            this.lblSelectedArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSelectedArea_MouseMove);
            this.lblSelectedArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblSelectedArea_MouseUp);
            // 
            // lblRight
            // 
            this.lblRight.BackColor = System.Drawing.Color.Black;
            this.lblRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.lblRight.Location = new System.Drawing.Point(323, 93);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(8, 8);
            this.lblRight.TabIndex = 2;
            this.lblRight.Visible = false;
            this.lblRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblRight_MouseDown);
            this.lblRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblRight_MouseMove);
            this.lblRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblSelectedArea_MouseUp);
            // 
            // lblLeft
            // 
            this.lblLeft.BackColor = System.Drawing.Color.Black;
            this.lblLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.lblLeft.Location = new System.Drawing.Point(122, 95);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(8, 8);
            this.lblLeft.TabIndex = 3;
            this.lblLeft.Visible = false;
            this.lblLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblLeft_MouseDown);
            this.lblLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblLeft_MouseMove);
            this.lblLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblSelectedArea_MouseUp);
            // 
            // grMain
            // 
            this.grMain.AllowUserToAddRows = false;
            this.grMain.AllowUserToDeleteRows = false;
            this.grMain.AllowUserToOrderColumns = true;
            this.grMain.AllowUserToResizeColumns = false;
            this.grMain.AllowUserToResizeRows = false;
            this.grMain.BackgroundColor = System.Drawing.Color.White;
            this.grMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMain.ColumnHeadersVisible = false;
            this.grMain.ContextMenuStrip = this.mnuPopUp;
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.RowHeadersVisible = false;
            this.grMain.Size = new System.Drawing.Size(681, 544);
            this.grMain.TabIndex = 0;
            this.grMain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.grMain_Scroll);
            this.grMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grMain_MouseDown);
            // 
            // mnuPopUp
            // 
            this.mnuPopUp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mnuPopUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TạoĐặtPhòngToolStripMenuItem,
            this.MởĐặtPhòngToolStripMenuItem,
            this.XóaĐặtPhòngToolStripMenuItem,
            this.ToolStripSeparator1,
            this.NhậpSốNgàyXemToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.XuấtExcelToolStripMenuItem});
            this.mnuPopUp.Name = "mnuPopUp";
            this.mnuPopUp.Size = new System.Drawing.Size(197, 142);
            this.mnuPopUp.Opening += new System.ComponentModel.CancelEventHandler(this.mnuPopUp_Opening);
            // 
            // TạoĐặtPhòngToolStripMenuItem
            // 
            this.TạoĐặtPhòngToolStripMenuItem.Name = "TạoĐặtPhòngToolStripMenuItem";
            this.TạoĐặtPhòngToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.TạoĐặtPhòngToolStripMenuItem.Text = "Tạo đặt phòng (Insert)";
            this.TạoĐặtPhòngToolStripMenuItem.Click += new System.EventHandler(this.TạoĐặtPhòngToolStripMenuItem_Click);
            // 
            // MởĐặtPhòngToolStripMenuItem
            // 
            this.MởĐặtPhòngToolStripMenuItem.Name = "MởĐặtPhòngToolStripMenuItem";
            this.MởĐặtPhòngToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.MởĐặtPhòngToolStripMenuItem.Text = "Sửa đặt phòng (F4)";
            this.MởĐặtPhòngToolStripMenuItem.Click += new System.EventHandler(this.MởĐặtPhòngToolStripMenuItem_Click);
            // 
            // XóaĐặtPhòngToolStripMenuItem
            // 
            this.XóaĐặtPhòngToolStripMenuItem.Name = "XóaĐặtPhòngToolStripMenuItem";
            this.XóaĐặtPhòngToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.XóaĐặtPhòngToolStripMenuItem.Text = "Xóa đặt phòng (Delete)";
            this.XóaĐặtPhòngToolStripMenuItem.Click += new System.EventHandler(this.XóaĐặtPhòngToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // NhậpSốNgàyXemToolStripMenuItem
            // 
            this.NhậpSốNgàyXemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NgàyToolStripMenuItem3,
            this.NgàyToolStripMenuItem4,
            this.NgàyToolStripMenuItem,
            this.NgàyToolStripMenuItem1,
            this.NgàyToolStripMenuItem2,
            this.ToolStripSeparator2,
            this.ThángNàyToolStripMenuItem,
            this.ThángTrướcToolStripMenuItem,
            this.ThángSauToolStripMenuItem});
            this.NhậpSốNgàyXemToolStripMenuItem.Name = "NhậpSốNgàyXemToolStripMenuItem";
            this.NhậpSốNgàyXemToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.NhậpSốNgàyXemToolStripMenuItem.Text = "Số ngày xem";
            // 
            // NgàyToolStripMenuItem3
            // 
            this.NgàyToolStripMenuItem3.Name = "NgàyToolStripMenuItem3";
            this.NgàyToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.NgàyToolStripMenuItem3.Text = "7 ngày";
            this.NgàyToolStripMenuItem3.Click += new System.EventHandler(this.NgàyToolStripMenuItem3_Click);
            // 
            // NgàyToolStripMenuItem4
            // 
            this.NgàyToolStripMenuItem4.Name = "NgàyToolStripMenuItem4";
            this.NgàyToolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.NgàyToolStripMenuItem4.Text = "15 ngày";
            this.NgàyToolStripMenuItem4.Click += new System.EventHandler(this.NgàyToolStripMenuItem4_Click);
            // 
            // NgàyToolStripMenuItem
            // 
            this.NgàyToolStripMenuItem.Name = "NgàyToolStripMenuItem";
            this.NgàyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.NgàyToolStripMenuItem.Text = "30 ngày";
            this.NgàyToolStripMenuItem.Click += new System.EventHandler(this.NgàyToolStripMenuItem_Click);
            // 
            // NgàyToolStripMenuItem1
            // 
            this.NgàyToolStripMenuItem1.Name = "NgàyToolStripMenuItem1";
            this.NgàyToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.NgàyToolStripMenuItem1.Text = "60 ngày";
            this.NgàyToolStripMenuItem1.Click += new System.EventHandler(this.NgàyToolStripMenuItem1_Click);
            // 
            // NgàyToolStripMenuItem2
            // 
            this.NgàyToolStripMenuItem2.Name = "NgàyToolStripMenuItem2";
            this.NgàyToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.NgàyToolStripMenuItem2.Text = "90 ngày";
            this.NgàyToolStripMenuItem2.Click += new System.EventHandler(this.NgàyToolStripMenuItem2_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // ThángNàyToolStripMenuItem
            // 
            this.ThángNàyToolStripMenuItem.Name = "ThángNàyToolStripMenuItem";
            this.ThángNàyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ThángNàyToolStripMenuItem.Text = "Tháng này";
            this.ThángNàyToolStripMenuItem.Click += new System.EventHandler(this.ThángNàyToolStripMenuItem_Click);
            // 
            // ThángTrướcToolStripMenuItem
            // 
            this.ThángTrướcToolStripMenuItem.Name = "ThángTrướcToolStripMenuItem";
            this.ThángTrướcToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ThángTrướcToolStripMenuItem.Text = "Tháng trước";
            this.ThángTrướcToolStripMenuItem.Click += new System.EventHandler(this.ThángTrướcToolStripMenuItem_Click);
            // 
            // ThángSauToolStripMenuItem
            // 
            this.ThángSauToolStripMenuItem.Name = "ThángSauToolStripMenuItem";
            this.ThángSauToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ThángSauToolStripMenuItem.Text = "Tháng sau";
            this.ThángSauToolStripMenuItem.Click += new System.EventHandler(this.ThángSauToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.RefreshToolStripMenuItem.Text = "Refresh (F5)";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // XuấtExcelToolStripMenuItem
            // 
            this.XuấtExcelToolStripMenuItem.Name = "XuấtExcelToolStripMenuItem";
            this.XuấtExcelToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.XuấtExcelToolStripMenuItem.Text = "Xuất excel";
            this.XuấtExcelToolStripMenuItem.Click += new System.EventHandler(this.XuấtExcelToolStripMenuItem_Click);
            // 
            // TheoDoiDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.Controls.Add(this.Panel1);
            this.Name = "TheoDoiDatPhong";
            this.Size = new System.Drawing.Size(681, 544);
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            this.mnuPopUp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.Panel Panel1;
        public System.Windows.Forms.Panel Panel2;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Label lblSelectedArea;
        public System.Windows.Forms.Label lblLeft;
        public System.Windows.Forms.Label lblRight;
        public No1Lib.Sys.No1DatePicker dtNgay;
        public No1Lib.Sys.No1LookupEdit lueLoaiPhong;
        public System.Windows.Forms.Button btnChia4;
        public System.Windows.Forms.Button btnChia2;
        public System.Windows.Forms.Button btnNhan2;
        public System.Windows.Forms.Button btnNhan4;
        public System.Windows.Forms.ContextMenuStrip mnuPopUp;
        public System.Windows.Forms.ToolStripMenuItem TạoĐặtPhòngToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem MởĐặtPhòngToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem XóaĐặtPhòngToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem NhậpSốNgàyXemToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem NgàyToolStripMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem NgàyToolStripMenuItem4;
        public System.Windows.Forms.ToolStripMenuItem NgàyToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem NgàyToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem NgàyToolStripMenuItem2;
        public System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem ThángNàyToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ThángTrướcToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ThángSauToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem XuấtExcelToolStripMenuItem;
    }
}
