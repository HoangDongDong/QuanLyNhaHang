namespace No1Run
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.KryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.grMain = new No1Lib.Sys.No1DataGrid();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtLoc = new No1Lib.Sys.No1TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblLoc = new System.Windows.Forms.Label();
            this.dtNgay = new No1Lib.Sys.FilterDateRange();
            this.grDetail = new No1Lib.Sys.GridMapper();
            this.FilterManager1 = new No1Lib.Sys.FilterManager();

            No1Lib.Sys.No1GridColumn colNAME = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colNOTE = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colNGAY = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colKHACHHANG = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colNHANVEN = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTHUNGAN = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colGIOHUY = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colNGAYHUY = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colDOITRA = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colDATHANHTOAN = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colGIOTHANHTOAN = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTRALAI = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTIENHANG = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTILETHUE = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTIENTHUE = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTILEGIAMGIA = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTIENGIAMGIA = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colPHIVANCHUYEN = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTHANHTOANBOI = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colLYDOHUY = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTIENGIO = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colPHIDICHVU = new No1Lib.Sys.No1GridColumn();

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
            // DanhSachBillHuy
            // 
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(678, 514);
            this.Name = "DanhSachBillHuy";
            this.Controls.Add(this.KryptonSplitContainer1);
            this.OnInit += new System.EventHandler(this.No1UserControl1_OnInit);
            this.Load += new System.EventHandler(this.form_Load);
            // 
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(678, 514);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 2;
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.grMain);
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.KryptonPanel1);
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.grDetail);
            this.KryptonSplitContainer1.SplitterDistance = 263;
            // 
            // colNAME
            // 
            colNAME.DataField = "NAME";
            colNAME.Caption = "Số phiếu";
            colNAME.AllowEmpty = false;
            colNAME.AllowHidden = false;
            colNAME.ShowOnQuickAddAsMultiValue = true;
            colNAME.AllowDuplicate = false;
            // 
            // colNOTE
            // 
            colNOTE.DataField = "NOTE";
            colNOTE.Caption = "Ghi chú";
            // 
            // colNGAY
            // 
            colNGAY.ColumnType = No1Lib.Sys.GridColumnType.DateTime;
            colNGAY.DataField = "NGAY";
            colNGAY.Caption = "Ngày";
            // 
            // colKHACHHANG
            // 
            colKHACHHANG.DataField = "KHACHHANG";
            colKHACHHANG.Caption = "Khách hàng";
            // 
            // colNHANVEN
            // 
            colNHANVEN.DataField = "NHANVEN";
            colNHANVEN.Caption = "Nhân viên";
            // 
            // colTHUNGAN
            // 
            colTHUNGAN.DataField = "THUNGAN";
            colTHUNGAN.Caption = "Thu ngân hủy";
            // 
            // colGIOHUY
            // 
            colGIOHUY.ColumnType = No1Lib.Sys.GridColumnType.DateTime;
            colGIOHUY.DataField = "GIOHUY";
            colGIOHUY.Caption = "Giờ hủy";
            // 
            // colNGAYHUY
            // 
            colNGAYHUY.ColumnType = No1Lib.Sys.GridColumnType.DateTime;
            colNGAYHUY.DataField = "NGAYHUY";
            colNGAYHUY.Caption = "Ngày hủy";
            // 
            // colDOITRA
            // 
            colDOITRA.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colDOITRA.DataField = "DOITRA";
            colDOITRA.Caption = "Đổi trả";
            // 
            // colDATHANHTOAN
            // 
            colDATHANHTOAN.ColumnType = No1Lib.Sys.GridColumnType.CheckBox;
            colDATHANHTOAN.DataField = "DATHANHTOAN";
            colDATHANHTOAN.Caption = "Đã thanh toán";
            // 
            // colGIOTHANHTOAN
            // 
            colGIOTHANHTOAN.ColumnType = No1Lib.Sys.GridColumnType.DateTime;
            colGIOTHANHTOAN.DataField = "GIOTHANHTOAN";
            colGIOTHANHTOAN.Caption = "Giờ thanh toán";
            // 
            // colTRALAI
            // 
            colTRALAI.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colTRALAI.DataField = "TRALAI";
            colTRALAI.Caption = "Trả lại";
            // 
            // colTIENHANG
            // 
            colTIENHANG.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colTIENHANG.DataField = "TIENHANG";
            colTIENHANG.Caption = "Tiền hàng";
            // 
            // colTILETHUE
            // 
            colTILETHUE.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colTILETHUE.DataField = "TILETHUE";
            colTILETHUE.Caption = "Tỉ lệ thuế";
            // 
            // colTIENTHUE
            // 
            colTIENTHUE.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colTIENTHUE.DataField = "TIENTHUE";
            colTIENTHUE.Caption = "Tiền thuế";
            // 
            // colTILEGIAMGIA
            // 
            colTILEGIAMGIA.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colTILEGIAMGIA.DataField = "TILEGIAMGIA";
            colTILEGIAMGIA.Caption = "Tỉ lệ giảm giá (%)";
            // 
            // colTIENGIAMGIA
            // 
            colTIENGIAMGIA.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colTIENGIAMGIA.DataField = "TIENGIAMGIA";
            colTIENGIAMGIA.Caption = "Tiền giảm giá";
            // 
            // colPHIVANCHUYEN
            // 
            colPHIVANCHUYEN.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colPHIVANCHUYEN.DataField = "PHIVANCHUYEN";
            colPHIVANCHUYEN.Caption = "Phí vận chuyển";
            // 
            // colTHANHTOANBOI
            // 
            colTHANHTOANBOI.DataField = "THANHTOANBOI";
            colTHANHTOANBOI.Caption = "Thanh toán bởi";
            // 
            // colLYDOHUY
            // 
            colLYDOHUY.DataField = "LYDOHUY";
            colLYDOHUY.Caption = "Lý do hủy";
            // 
            // colTIENGIO
            // 
            colTIENGIO.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colTIENGIO.DataField = "TIENGIO";
            colTIENGIO.Caption = "Tiền giờ";
            // 
            // colPHIDICHVU
            // 
            colPHIDICHVU.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colPHIDICHVU.DataField = "PHIDICHVU";
            colPHIDICHVU.Caption = "Phí dịch vụ";
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
            this.grMain.Columns.AddRange(new No1Lib.Sys.No1GridColumn[] {
                colNAME, colNOTE, colNGAY, colKHACHHANG, colNHANVEN, colTHUNGAN,
                colGIOHUY, colNGAYHUY, colDOITRA, colDATHANHTOAN, colGIOTHANHTOAN,
                colTRALAI, colTIENHANG, colTILETHUE, colTIENTHUE, colTILEGIAMGIA,
                colTIENGIAMGIA, colPHIVANCHUYEN, colTHANHTOANBOI, colLYDOHUY,
                colTIENGIO, colPHIDICHVU
            });
            this.grMain.OnFocusedRowChanged += this.grMain_OnFocusedRowChanged;
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.txtLoc);
            this.KryptonPanel1.Controls.Add(this.btnRefresh);
            this.KryptonPanel1.Controls.Add(this.lblLoc);
            this.KryptonPanel1.Controls.Add(this.dtNgay);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(678, 29);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // dtNgay
            // 
            this.dtNgay.BackColor = System.Drawing.Color.Transparent;
            this.dtNgay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgay.Location = new System.Drawing.Point(5, 3);
            this.dtNgay.LockEvent = false;
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(271, 24);
            this.dtNgay.TabIndex = 0;
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoc.Location = new System.Drawing.Point(287, 7);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(25, 13);
            this.lblLoc.TabIndex = 1;
            this.lblLoc.Text = "Lọc";
            // 
            // txtLoc
            // 
            this.txtLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoc.Location = new System.Drawing.Point(319, 4);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(100, 21);
            this.txtLoc.TabIndex = 3;
            this.txtLoc.TextChanged += new System.EventHandler(this.txtLoc_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(425, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grDetail
            // 
            this.grDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetail.FontSize = 0F;
            this.grDetail.GUID = "bb78e739-cabc-48b7-8470-60f4fc18af55";
            this.grDetail.Location = new System.Drawing.Point(0, 0);
            this.grDetail.Name = "grDetail";
            this.grDetail.ReadOnly = true;
            this.grDetail.ShowAddButton = false;
            this.grDetail.ShowToolbar = false;
            this.grDetail.Size = new System.Drawing.Size(678, 246);
            this.grDetail.TabIndex = 0;
            this.grDetail.ViewConfig = System.Convert.FromBase64String(VIEWCONFIG_DETAIL);
            this.grDetail.CustomLoadData += new No1Lib.Sys.CustomLoadDataHandler(this.grDetail_CustomLoadData);
            // 
            // FilterManager1
            // 
            No1Lib.Sys.FilterMap filterMap1 = new No1Lib.Sys.FilterMap();
            filterMap1.Control = this.dtNgay;
            filterMap1.Field = "NGAYHUY";
            this.FilterManager1.Maps.Add(filterMap1);
            this.FilterManager1.DataGrid = this.grMain;
            this.FilterManager1.AutoLoad = false;
            this.FilterManager1.AfterFiltered += new System.EventHandler(this.FilterManager1_AfterFiltered);

            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).EndInit();
            this.KryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).EndInit();
            this.KryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).EndInit();
            this.KryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterManager1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer KryptonSplitContainer1;
        public No1Lib.Sys.No1DataGrid grMain;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public No1Lib.Sys.FilterDateRange dtNgay;
        public No1Lib.Sys.GridMapper grDetail;
        public No1Lib.Sys.FilterManager FilterManager1;
        public System.Windows.Forms.Label lblLoc;
        public System.Windows.Forms.Button btnRefresh;
        public No1Lib.Sys.No1TextBox txtLoc;

        public const string VIEWCONFIG_DETAIL = @"PERvY3VtZW50RWxlbWVudD4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+ZmUzZmY4ZjEtMTQ3OS00YTM0LWIzZGMtYjI5ZTU0Y2JkZjllPC9DT0xJRD4NCiAgICA8VEFCTEVJRD45ZGZhYmYzOC0yMDJlLTQzNWQtYTg3YS0zM2U1NTFmZDJlNGQ8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjdiYWIxMTYwLTM2YzAtNDIxOS05ZTBhLTU5ODRhYTg2YTk5ZDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+OWRmYWJmMzgtMjAyZS00MzVkLWE4N2EtMzNlNTUxZmQyZTRkPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD45ZDg3NjQwMC1mNWYxLTRlM2UtOTU2NC03YzA0MTBkN2Q3NDU8L0NPTElEPg0KICAgIDxUQUJMRUlEPjlkZmFiZjM4LTIwMmUtNDM1ZC1hODdhLTMzZTU1MWZkMmU0ZDwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+YTUzNTUzMTAtYTA5My00Mjk1LWIxOTItMDM1YjdiOTFhNjlmPC9DT0xJRD4NCiAgICA8VEFCTEVJRD45ZGZhYmYzOC0yMDJlLTQzNWQtYTg3YS0zM2U1NTFmZDJlNGQ8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjI0M2ZjYWFhLTA1YjQtNDc0NS1hMDE1LTU3OWI4ZTlhYzExZjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+OWRmYWJmMzgtMjAyZS00MzVkLWE4N2EtMzNlNTUxZmQyZTRkPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD40ZDcxMjE1Yy00OTgwLTQyYmItOTkwZC02M2E2OWExNjRhNTA8L0NPTElEPg0KICAgIDxUQUJMRUlEPjlkZmFiZjM4LTIwMmUtNDM1ZC1hODdhLTMzZTU1MWZkMmU0ZDwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+NWQ2ZTg4MDItYmI1NS00ODZmLTlhZmItMmY0ZjliNDM5Mjc2PC9DT0xJRD4NCiAgICA8VEFCTEVJRD45ZGZhYmYzOC0yMDJlLTQzNWQtYTg3YS0zM2U1NTFmZDJlNGQ8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQo8L0RvY3VtZW50RWxlbWVudD4=";
    }
}