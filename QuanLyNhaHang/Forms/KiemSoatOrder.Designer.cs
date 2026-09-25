namespace No1Run
{
    partial class KiemSoatOrder
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
            System.Windows.Forms.DataGridViewCellStyle alternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.KryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.grMain = new No1Lib.Sys.DataSearch();
            this.KryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.grTonTai = new No1Lib.Sys.MiscDataGridView();
            this.colThongKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grThieu = new No1Lib.Sys.MiscDataGridView();
            this.colOrderThieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnTai = new System.Windows.Forms.Button();
            this.dtNgay = new No1Lib.Sys.FilterDateRange();
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblTongOrder = new System.Windows.Forms.Label();
            this.lblTrung = new System.Windows.Forms.Label();
            this.lblLonNhat = new System.Windows.Forms.Label();
            this.lblNhoNhat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).BeginInit();
            this.KryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).BeginInit();
            this.KryptonSplitContainer1.Panel2.SuspendLayout();
            this.KryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2.Panel1)).BeginInit();
            this.KryptonSplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2.Panel2)).BeginInit();
            this.KryptonSplitContainer2.Panel2.SuspendLayout();
            this.KryptonSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grTonTai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grThieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            this.KryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 34);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            // 
            // KryptonSplitContainer1.Panel1
            // 
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.grMain);
            // 
            // KryptonSplitContainer1.Panel2
            // 
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.KryptonSplitContainer2);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(746, 471);
            this.KryptonSplitContainer1.SplitterDistance = 522;
            this.KryptonSplitContainer1.TabIndex = 2;
            // 
            // grMain
            // 
            this.grMain.AllowSameItem = "";
            this.grMain.AllowUserToAddRows = false;
            this.grMain.AllowUserToDeleteRows = false;
            this.grMain.AllowUserToOrderColumns = true;
            this.grMain.AllowUserToResizeRows = false;
            this.grMain.AlternatingRowsDefaultCellStyle = alternatingRowsDefaultCellStyle;
            this.grMain.BackgroundColor = System.Drawing.Color.White;
            this.grMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.GUID = "23565e65-e25e-4866-ade1-aba2e2d99b0f";
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.ReadOnly = true;
            this.grMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMain.ShowCellToolTips = false;
            this.grMain.Size = new System.Drawing.Size(522, 471);
            this.grMain.TabIndex = 0;
            this.grMain.ViewConfig = System.Convert.FromBase64String(VIEWCONFIG_MAIN);
            this.grMain.CustomLoadData += new No1Lib.Sys.CustomLoadDataHandler(this.grMain_CustomLoadData);
            // 
            // KryptonSplitContainer2
            // 
            this.KryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.KryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer2.Name = "KryptonSplitContainer2";
            this.KryptonSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // KryptonSplitContainer2.Panel1
            // 
            this.KryptonSplitContainer2.Panel1.Controls.Add(this.grTonTai);
            // 
            // KryptonSplitContainer2.Panel2
            // 
            this.KryptonSplitContainer2.Panel2.Controls.Add(this.grThieu);
            this.KryptonSplitContainer2.Size = new System.Drawing.Size(219, 471);
            this.KryptonSplitContainer2.SplitterDistance = 217;
            this.KryptonSplitContainer2.TabIndex = 0;
            // 
            // grTonTai
            // 
            this.grTonTai.AllowUserToAddRows = false;
            this.grTonTai.AllowUserToDeleteRows = false;
            this.grTonTai.AllowUserToOrderColumns = true;
            this.grTonTai.AllowUserToResizeRows = false;
            alternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.grTonTai.AlternatingRowsDefaultCellStyle = alternatingRowsDefaultCellStyle;
            this.grTonTai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grTonTai.BackgroundColor = System.Drawing.Color.White;
            this.grTonTai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grTonTai.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grTonTai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grTonTai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colThongKe});
            this.grTonTai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grTonTai.Location = new System.Drawing.Point(0, 0);
            this.grTonTai.Name = "grTonTai";
            this.grTonTai.ReadOnly = true;
            this.grTonTai.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grTonTai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grTonTai.ShowCellToolTips = false;
            this.grTonTai.Size = new System.Drawing.Size(219, 217);
            this.grTonTai.TabIndex = 0;
            // 
            // colThongKe
            // 
            this.colThongKe.DataPropertyName = "THONGKE";
            this.colThongKe.HeaderText = "Order tồn tại";
            this.colThongKe.Name = "colThongKe";
            this.colThongKe.ReadOnly = true;
            // 
            // grThieu
            // 
            this.grThieu.AllowUserToAddRows = false;
            this.grThieu.AllowUserToDeleteRows = false;
            this.grThieu.AllowUserToOrderColumns = true;
            this.grThieu.AllowUserToResizeRows = false;
            alternatingRowsDefaultCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.grThieu.AlternatingRowsDefaultCellStyle = alternatingRowsDefaultCellStyle2;
            this.grThieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grThieu.BackgroundColor = System.Drawing.Color.White;
            this.grThieu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grThieu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grThieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grThieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderThieu});
            this.grThieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grThieu.Location = new System.Drawing.Point(0, 0);
            this.grThieu.Name = "grThieu";
            this.grThieu.ReadOnly = true;
            this.grThieu.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grThieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grThieu.ShowCellToolTips = false;
            this.grThieu.Size = new System.Drawing.Size(219, 249);
            this.grThieu.TabIndex = 0;
            // 
            // colOrderThieu
            // 
            this.colOrderThieu.DataPropertyName = "THONGKE";
            this.colOrderThieu.HeaderText = "Order lỗi hoặc thiếu";
            this.colOrderThieu.Name = "colOrderThieu";
            this.colOrderThieu.ReadOnly = true;
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.dtNgay);
            this.KryptonPanel1.Controls.Add(this.btnTai);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(746, 34);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // btnTai
            // 
            this.btnTai.Location = new System.Drawing.Point(282, 4);
            this.btnTai.Name = "btnTai";
            this.btnTai.Size = new System.Drawing.Size(81, 26);
            this.btnTai.TabIndex = 1;
            this.btnTai.Text = "Tải dữ liệu";
            this.btnTai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTai.UseVisualStyleBackColor = true;
            this.btnTai.Click += new System.EventHandler(this.btnTai_Click);
            // 
            // dtNgay
            // 
            this.dtNgay.BackColor = System.Drawing.Color.Transparent;
            this.dtNgay.EditValue = null;
            this.dtNgay.Location = new System.Drawing.Point(5, 4);
            this.dtNgay.LockEvent = false;
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(271, 24);
            this.dtNgay.TabIndex = 2;
            this.dtNgay.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.dtNgay_OnEditValueChanged);
            // 
            // KryptonPanel2
            // 
            this.KryptonPanel2.Controls.Add(this.lblTongOrder);
            this.KryptonPanel2.Controls.Add(this.lblTrung);
            this.KryptonPanel2.Controls.Add(this.lblLonNhat);
            this.KryptonPanel2.Controls.Add(this.lblNhoNhat);
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 505);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Size = new System.Drawing.Size(746, 33);
            this.KryptonPanel2.TabIndex = 1;
            // 
            // lblTongOrder
            // 
            this.lblTongOrder.AutoSize = true;
            this.lblTongOrder.BackColor = System.Drawing.Color.Transparent;
            this.lblTongOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTongOrder.Location = new System.Drawing.Point(519, 10);
            this.lblTongOrder.Name = "lblTongOrder";
            this.lblTongOrder.Size = new System.Drawing.Size(86, 13);
            this.lblTongOrder.TabIndex = 10;
            this.lblTongOrder.Text = "Tổng số order";
            // 
            // lblTrung
            // 
            this.lblTrung.AutoSize = true;
            this.lblTrung.BackColor = System.Drawing.Color.Transparent;
            this.lblTrung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTrung.Location = new System.Drawing.Point(360, 10);
            this.lblTrung.Name = "lblTrung";
            this.lblTrung.Size = new System.Drawing.Size(92, 13);
            this.lblTrung.TabIndex = 9;
            this.lblTrung.Text = "Số order trùng:";
            // 
            // lblLonNhat
            // 
            this.lblLonNhat.AutoSize = true;
            this.lblLonNhat.BackColor = System.Drawing.Color.Transparent;
            this.lblLonNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLonNhat.Location = new System.Drawing.Point(189, 10);
            this.lblLonNhat.Name = "lblLonNhat";
            this.lblLonNhat.Size = new System.Drawing.Size(109, 13);
            this.lblLonNhat.TabIndex = 8;
            this.lblLonNhat.Text = "Số order lớn nhất:";
            // 
            // lblNhoNhat
            // 
            this.lblNhoNhat.AutoSize = true;
            this.lblNhoNhat.BackColor = System.Drawing.Color.Transparent;
            this.lblNhoNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNhoNhat.Location = new System.Drawing.Point(5, 10);
            this.lblNhoNhat.Name = "lblNhoNhat";
            this.lblNhoNhat.Size = new System.Drawing.Size(113, 13);
            this.lblNhoNhat.TabIndex = 7;
            this.lblNhoNhat.Text = "Số order nhỏ nhất:";
            // 
            // KiemSoatOrder
            // 
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.KryptonPanel1);
            this.Name = "No1UserControl1";
            this.Size = new System.Drawing.Size(746, 538);
            this.Load += new System.EventHandler(this.No1UserControl1_OnInit);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).EndInit();
            this.KryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).EndInit();
            this.KryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).EndInit();
            this.KryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2.Panel1)).EndInit();
            this.KryptonSplitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2.Panel2)).EndInit();
            this.KryptonSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2)).EndInit();
            this.KryptonSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grTonTai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grThieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            this.KryptonPanel2.ResumeLayout(false);
            this.KryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer KryptonSplitContainer1;
        public No1Lib.Sys.DataSearch grMain;
        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer KryptonSplitContainer2;
        public No1Lib.Sys.MiscDataGridView grTonTai;
        public System.Windows.Forms.DataGridViewTextBoxColumn colThongKe;
        public No1Lib.Sys.MiscDataGridView grThieu;
        public System.Windows.Forms.DataGridViewTextBoxColumn colOrderThieu;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Button btnTai;
        public No1Lib.Sys.FilterDateRange dtNgay;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        public System.Windows.Forms.Label lblTongOrder;
        public System.Windows.Forms.Label lblTrung;
        public System.Windows.Forms.Label lblLonNhat;
        public System.Windows.Forms.Label lblNhoNhat;

        public const string VIEWCONFIG_MAIN = @"PERvY3VtZW50RWxlbWVudD4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MDY3NTJkNDktZjY5ZS00MDM0LWJhZGMtNDVjYWFlOGU3YzAxPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmE0Y2M4NjIxLTZhZWYtNDgxMy1iOTZlLThkMTAwNTYzMzJmZDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD5mYWxzZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MmY0MTBmMTctMGE3Yy00ZWRmLTljZTctODViOWE3YmY5YjVkPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OPj0wPC9DT05ESVRJT04+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjE5YTMzYWY0LTYyNGMtNGU0OS04OThiLWY3ZjNkZDUwM2UzNjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD50cnVlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjc0NGU2ZjJhLTE0ODItNDAwZS04YTU5LWUxNTE5YTg4YTc3ZDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+ZTVmNTkzN2EtOWE1ZC00OGNjLWJlYWYtNGZjZDQ4ZDg0YWFmPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5OaMOibiB2acOqbjwvQ0FQVElPTj4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogICAgPFBBUkVOVElEPjE5YTMzYWY0LTYyNGMtNGU0OS04OThiLWY3ZjNkZDUwM2UzNjwvUEFSRU5USUQ+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YWQxMDEwYmEtNGI1MS00MjFlLTllYWUtMTU3ZmU0YzYxMjllPC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmJjMzY0ZmI3LTlmOTItNGI1YS1hYTg3LWI3ZmI4MWRkYTRmYzwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD50cnVlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjUzY2U4ZjFjLWU0YjgtNGQ2MC1hODRiLTE4ODFjMjM4YTZhNTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+MThhZjcwODktYTA0Mi00MWFhLWE3NWYtY2E5MTkxOGE3MTg4PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5UaHUgbmfDom48L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICAgIDxQQVJFTlRJRD5iYzM2NGZiNy05ZjkyLTRiNWEtYWE4Ny1iN2ZiODFkZGE0ZmM8L1BBUkVOVElEPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPmZhbHNlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4xYzI0YjE5Yi05MGZmLTRmZTYtYTcwOS03OWM5NGNhMjZkNjU8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04+PTMwPC9DT05ESVRJT04+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjI1NjFiZGM2LTU2M2QtNDRjMS04OTA1LTNjOTgyNTYzZTA1ZDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD50cnVlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjA0Y2NlMDM5LTEyODYtNDQ5ZC1hZjkyLWEwZDhiYjc0MjViYjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+ZjIyODgzNDUtMDMxYS00ZTFiLWE3NmQtM2IyZTUzNzY3NGE2PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5Cw6BuPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgICA8UEFSRU5USUQ+MjU2MWJkYzYtNTYzZC00NGMxLTg5MDUtM2M5ODI1NjNlMDVkPC9QQVJFTlRJRD4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4zZTc2NzJlYS0yZDQzLTRmMmQtODQxMi1iMmU2Y2FjNTUwODQ8L0NPTElEPg0KICAgIDxUQUJMRUlEPjcyMWRlODg1LTJmN2QtNDliMS1iOTgzLWE1MzEyYzU2MGRkYTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+OGU0ZjcwNDItNDc5Zi00M2NjLWE5YzMtZTU5ZTM0YmM5Y2U0PC9DT0xJRD4NCiAgICA8VEFCTEVJRD43MjFkZTg4NS0yZjdkLTQ5YjEtYjk4My1hNTMxMmM1NjBkZGE8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjk1OTYxNGE5LWIyZWYtNDllMC04YmZiLTdlMTBjOTI0MTk4ZTwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NzIxZGU4ODUtMmY3ZC00OWIxLWI5ODMtYTUzMTJjNTYwZGRhPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KPC9Eb2N1bWVudEVsZW1lbnQ+";
    }
}
