namespace No1Run
{
    partial class KhachHangThanThiet
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
            this.KryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.tvNhom = new No1Lib.Sys.No1TreeTable();
            this.KryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.grKhachHang = new No1Lib.Sys.GridMapper();
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtTim = new No1Lib.Sys.No1TextBox();
            this.tabDetail = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pageTangDiem = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grTangDiem = new No1Lib.Sys.No1DataGrid();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbThem = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSua = new System.Windows.Forms.ToolStripButton();
            this.tsbXoa = new System.Windows.Forms.ToolStripButton();
            this.pageDiemTheoHoaDon = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.grHoaDon = new No1Lib.Sys.No1DataGrid();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);

            No1Lib.Sys.No1GridColumn colTangDiem_NAME = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTangDiem_NOTE = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTangDiem_NGAY = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTangDiem_DIEMTANG = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTangDiem_DIEMGIAM = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colTangDiem_LYDO = new No1Lib.Sys.No1GridColumn();

            No1Lib.Sys.No1GridColumn colHoaDon_DIEM = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colHoaDon_NAME = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colHoaDon_NGAY = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colHoaDon_TONGCONG = new No1Lib.Sys.No1GridColumn();
            No1Lib.Sys.No1GridColumn colHoaDon_DIEMGIAM = new No1Lib.Sys.No1GridColumn();

            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).BeginInit();
            this.KryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).BeginInit();
            this.KryptonSplitContainer1.Panel2.SuspendLayout();
            this.KryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2.Panel1)).BeginInit();
            this.KryptonSplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2.Panel2)).BeginInit();
            this.KryptonSplitContainer2.Panel2.SuspendLayout();
            this.KryptonSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabDetail)).BeginInit();
            this.tabDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageTangDiem)).BeginInit();
            this.pageTangDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grTangDiem)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageDiemTheoHoaDon)).BeginInit();
            this.pageDiemTheoHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // KhachHangThanThiet
            // 
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(711, 524);
            this.Name = "KhachHangThanThiet";
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Load += new System.EventHandler(this.No1UserControl1_Load);
            this.KeyDownEx += new System.Windows.Forms.KeyEventHandler(this.No1UserControl1_KeyDownEx);
            // 
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(711, 524);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 0;
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.tvNhom);
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.KryptonSplitContainer2);
            this.KryptonSplitContainer1.SplitterDistance = 222;
            // 
            // tvNhom
            // 
            this.tvNhom.Table = "DNHOMKHACHHANG";
            this.tvNhom.Size = new System.Drawing.Size(222, 524);
            this.tvNhom.Name = "tvNhom";
            this.tvNhom.ReadOnly = false;
            this.tvNhom.AutoLoad = true;
            this.tvNhom.TabIndex = 0;
            this.tvNhom.Location = new System.Drawing.Point(0, 0);
            this.tvNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNhom.OnFocusedNodeChanged += this.tvNhom_OnFocusedNodeChanged;
            this.tvNhom.OnCustomNode += this.tvNhom_OnCustomNode;
            // 
            // KryptonSplitContainer2
            // 
            this.KryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.KryptonSplitContainer2.Size = new System.Drawing.Size(484, 524);
            this.KryptonSplitContainer2.Name = "KryptonSplitContainer2";
            this.KryptonSplitContainer2.TabIndex = 1;
            this.KryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.KryptonSplitContainer2.Panel1.Controls.Add(this.grKhachHang);
            this.KryptonSplitContainer2.Panel1.Controls.Add(this.KryptonPanel1);
            this.KryptonSplitContainer2.Panel2.Controls.Add(this.tabDetail);
            this.KryptonSplitContainer2.SplitterDistance = 350;
            // 
            // grKhachHang
            // 
            this.grKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grKhachHang.FontSize = 0F;
            this.grKhachHang.GUID = "7188d1e7-5ed7-44ad-8f17-4ec3f786ef79";
            this.grKhachHang.Location = new System.Drawing.Point(0, 26);
            this.grKhachHang.Name = "grKhachHang";
            this.grKhachHang.ReadOnly = true;
            this.grKhachHang.ShowAddButton = false;
            this.grKhachHang.ShowToolbar = false;
            this.grKhachHang.Size = new System.Drawing.Size(484, 324);
            this.grKhachHang.TabIndex = 0;
            this.grKhachHang.ViewConfig = System.Convert.FromBase64String(VIEWCONFIG_KHACHHANG);
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.btnRefresh);
            this.KryptonPanel1.Controls.Add(this.Label1);
            this.KryptonPanel1.Controls.Add(this.txtTim);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(484, 26);
            this.KryptonPanel1.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(3, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(49, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Lọc (F3):";
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(58, 3);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(100, 21);
            this.txtTim.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(164, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabDetail
            // 
            this.tabDetail.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.tabDetail.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetail.Enabled = false;
            this.tabDetail.Location = new System.Drawing.Point(0, 0);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
                this.pageTangDiem,
                this.pageDiemTheoHoaDon
            });
            this.tabDetail.SelectedIndex = 0;
            this.tabDetail.Size = new System.Drawing.Size(484, 169);
            this.tabDetail.TabIndex = 0;
            this.tabDetail.Text = "KryptonNavigator1";
            // 
            // pageTangDiem
            // 
            this.pageTangDiem.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageTangDiem.Controls.Add(this.grTangDiem);
            this.pageTangDiem.Controls.Add(this.ToolStrip1);
            this.pageTangDiem.Flags = 65534;
            this.pageTangDiem.LastVisibleSet = true;
            this.pageTangDiem.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageTangDiem.Name = "pageTangDiem";
            this.pageTangDiem.Size = new System.Drawing.Size(482, 142);
            this.pageTangDiem.Text = "Tặng điểm - tặng quà";
            this.pageTangDiem.ToolTipTitle = "Page ToolTip";
            this.pageTangDiem.UniqueName = "A740072D823340E5CC98B3EFDE18A59D";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsbThem,
                this.ToolStripSeparator1,
                this.tsbSua,
                this.tsbXoa
            });
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(482, 25);
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tsbThem
            // 
            this.tsbThem.Image = LoadImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAFYSURBVDhPtZG7L4NhFMaPSzpI0Y9Wqm1CigjVRNOJusQl4lbqliAiahMTu81i6GIQ32AhdY+FmOseHAmDpDYjf8XjvF9Ck6Ya3+Akv+SX877Pkzd5if5t9h06HTrYQLnp2bNz9HMZcx9LIHHTeYrbefJ9AQrl5gu2NR55m0ckGQWJmy/Y0rjvZRq9z1Mg8ewFuk2nTbmURtfjODruR5HpjFTmZzZsHH6dRTdPQIU6H8aMYPPlAJou+tF2O4zWmyG0XIcRuho0nCSTKlgvZvXU9ruIgQqoYP1pCJUHAQN3vAGuHR88cT+8R0GQZFIFsUKdYlZOx3Pih+vYh0xnpDJZZ83KzvM6lJ3VgsTN/8Kqle2JGpQmqkHi5gtWCrjkqQoae0Hi5gsWLawlvVCQ+F8K8uWSW2gUgtSTs0szuWygXO2IAkKFYMlUmCvLIsEpuH6hXPY2Ie+74AvGtKxvWfujRgAAAABJRU5ErkJggg==");
            this.tsbThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbThem.Name = "tsbThem";
            this.tsbThem.Size = new System.Drawing.Size(82, 22);
            this.tsbThem.Text = "Thêm mới";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSua
            // 
            this.tsbSua.Enabled = false;
            this.tsbSua.Image = LoadImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAFWSURBVDhPY2CgJ5jJwMA/m4Hh/EIGhv/LGBjmk2T3zJkz+ScBNd+ss/v/f3fo/5M2ov/XEmsIWPO06eeXdxX9/7/O4//3HKH//1vk/q8DuoSgK2CaDx059r9/0pT/C9M9//8sFv1/z5X1/xqgi/AaMDONgX96gdL5vv7u/7v27vt/7MSp/8VlFf+7g63/LwdqXgUME5wGgDWnMpw/ONPk/6GlQf9LSwv+z5g1539zW8d/H9/A8y4uocRpvrTW7f+BaQb/F1Rp/I+JCiNP87p6yf+98Sz/k9yFSLcZpjnbjeF8mguRfoY5m2jNoJCckcwQv65Z6/+tPclgP5OkGWTApASG82fWpf5/eWXy/yPz3MB+JuhsWBwaGhrKJ/iogjUfXZX6f2KeCvGaQYZEBnv2p6Wl/Y9wV/1f5M1wPs+VIR5vgKGnnmA/l/+5uRn/27t6CKdtNM0AE4HaRdDCVfMAAAAASUVORK5CYII=");
            this.tsbSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSua.Name = "tsbSua";
            this.tsbSua.Size = new System.Drawing.Size(46, 22);
            this.tsbSua.Text = "Sửa";
            // 
            // tsbXoa
            // 
            this.tsbXoa.Enabled = false;
            this.tsbXoa.Image = LoadImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAHISURBVDhPzZJBSJNhHMafZuwbG3013dtsa9RpCjtMG4OuEyGRXaNbwZKiJC+uuilEiU4ZjLY6pK2V5uqQM0aK2C6dio8itU7uEGMMIrrYpaV+Pi9M2HCNHf3gx/v++T/P837v//uAQ/O8AvrmAU2SBh7We7GXgIe6EZJ5DVyr0TyncTsc1kuDg7sf/f6irKsFL4CJeaPxyyzwfg7o14EjNQHPmDhDkzT/DIX0QjBYXhDi+xPAl1bVZK6zM/8UyE4DZ/47tkcUJ4AIV+1TIPBb6+3dWeroKKx4vYU4sEjam5r5FIOiDMl2d2+9dbvLj02mjaaMUvQAECQz63CUskL8jSrK2ozN9iNiMKw1FTICxFJCFHMu105EUTZYXyVv4mbzJtd3DUPCwPUEhZrdrqdUtXgXuL1v4CY23tLyjZqxuiE3Od0h3vurEP8+WCx/uM/eAKzV4lvAPbJMAgdCBoCppNlczLe26ncMhnWaffVO4t9zn0yMAkdr+ld4+merdXfBaPzF/WSju7I/fAE4V6053QVcvsSQi8CqHehh8yw5SY6TY+QEEcTpBM57gGB1gMrCRk5VkEZpsBATUSqrrKVWzqat4RdptrkHZrd+3YaAZ3YAAAAASUVORK5CYII=");
            this.tsbXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbXoa.Name = "tsbXoa";
            this.tsbXoa.Size = new System.Drawing.Size(47, 22);
            this.tsbXoa.Text = "Xóa";
            // 
            // colTangDiem_NAME
            // 
            colTangDiem_NAME.DataField = "NAME";
            colTangDiem_NAME.Caption = "Số phiếu";
            colTangDiem_NAME.AllowEmpty = false;
            colTangDiem_NAME.AllowHidden = false;
            colTangDiem_NAME.ShowOnQuickAddAsMultiValue = true;
            colTangDiem_NAME.AllowDuplicate = false;
            // 
            // colTangDiem_NOTE
            // 
            colTangDiem_NOTE.DataField = "NOTE";
            colTangDiem_NOTE.Caption = "Ghi chú";
            // 
            // colTangDiem_NGAY
            // 
            colTangDiem_NGAY.ColumnType = No1Lib.Sys.GridColumnType.DateTime;
            colTangDiem_NGAY.DataField = "NGAY";
            colTangDiem_NGAY.Caption = "Ngày";
            // 
            // colTangDiem_DIEMTANG
            // 
            colTangDiem_DIEMTANG.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colTangDiem_DIEMTANG.DataField = "DIEMTANG";
            colTangDiem_DIEMTANG.Caption = "Điểm tăng";
            // 
            // colTangDiem_DIEMGIAM
            // 
            colTangDiem_DIEMGIAM.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colTangDiem_DIEMGIAM.DataField = "DIEMGIAM";
            colTangDiem_DIEMGIAM.Caption = "Điểm giảm";
            // 
            // colTangDiem_LYDO
            // 
            colTangDiem_LYDO.DataField = "LYDO";
            colTangDiem_LYDO.Caption = "Lý do";
            // 
            // grTangDiem
            // 
            this.grTangDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grTangDiem.Size = new System.Drawing.Size(482, 117);
            this.grTangDiem.AutoLoad = false;
            this.grTangDiem.ShowSetValue = false;
            this.grTangDiem.Location = new System.Drawing.Point(0, 25);
            this.grTangDiem.AllowAdding = true;
            this.grTangDiem.AllowDeleting = true;
            this.grTangDiem.RealDelete = true;
            this.grTangDiem.GUID = "8f0024c5-31c1-4de0-a1d1-cd0daf116c9a";
            this.grTangDiem.Name = "grTangDiem";
            this.grTangDiem.TabIndex = 0;
            this.grTangDiem.Table = "TTANGGIAMDIEM";
            this.grTangDiem.AddButton = this.tsbThem;
            this.grTangDiem.EditButton = this.tsbSua;
            this.grTangDiem.DeleteButton = this.tsbXoa;
            this.grTangDiem.Columns.AddRange(new No1Lib.Sys.No1GridColumn[] {
                colTangDiem_NAME,
                colTangDiem_NOTE,
                colTangDiem_NGAY,
                colTangDiem_DIEMTANG,
                colTangDiem_DIEMGIAM,
                colTangDiem_LYDO
            });
            this.grTangDiem.CustomLoadData += this.grTangDiem_CustomLoadData;
            this.grTangDiem.AfterCreatedEditForm += this.grTangDiem_AfterCreatedEditForm;
            // 
            // pageDiemTheoHoaDon
            // 
            this.pageDiemTheoHoaDon.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageDiemTheoHoaDon.Controls.Add(this.grHoaDon);
            this.pageDiemTheoHoaDon.Flags = 65534;
            this.pageDiemTheoHoaDon.LastVisibleSet = true;
            this.pageDiemTheoHoaDon.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageDiemTheoHoaDon.Name = "pageDiemTheoHoaDon";
            this.pageDiemTheoHoaDon.Size = new System.Drawing.Size(482, 142);
            this.pageDiemTheoHoaDon.Text = "Điểm theo hóa đơn";
            this.pageDiemTheoHoaDon.ToolTipTitle = "Page ToolTip";
            this.pageDiemTheoHoaDon.UniqueName = "8F1B10C44F7F4757BAA4B57DBA9D1DE4";
            // 
            // colHoaDon_DIEM
            // 
            colHoaDon_DIEM.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colHoaDon_DIEM.DataField = "DIEM";
            colHoaDon_DIEM.Caption = "Điểm";
            // 
            // colHoaDon_NAME
            // 
            colHoaDon_NAME.DataField = "NAME";
            colHoaDon_NAME.Caption = "Số phiếu";
            colHoaDon_NAME.AllowEmpty = false;
            colHoaDon_NAME.AllowHidden = false;
            colHoaDon_NAME.ShowOnQuickAddAsMultiValue = true;
            colHoaDon_NAME.AllowDuplicate = false;
            // 
            // colHoaDon_NGAY
            // 
            colHoaDon_NGAY.ColumnType = No1Lib.Sys.GridColumnType.DateTime;
            colHoaDon_NGAY.DataField = "NGAY";
            colHoaDon_NGAY.Caption = "Ngày";
            // 
            // colHoaDon_TONGCONG
            // 
            colHoaDon_TONGCONG.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colHoaDon_TONGCONG.DataField = "TONGCONG";
            colHoaDon_TONGCONG.Caption = "Tổng cộng";
            // 
            // colHoaDon_DIEMGIAM
            // 
            colHoaDon_DIEMGIAM.ColumnType = No1Lib.Sys.GridColumnType.NumericUpDown;
            colHoaDon_DIEMGIAM.DataField = "DIEMGIAM";
            colHoaDon_DIEMGIAM.Caption = "Điểm sử dụng";
            // 
            // grHoaDon
            // 
            this.grHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grHoaDon.ReadOnly = true;
            this.grHoaDon.Size = new System.Drawing.Size(482, 142);
            this.grHoaDon.AutoLoad = false;
            this.grHoaDon.Location = new System.Drawing.Point(0, 0);
            this.grHoaDon.AllowAdding = true;
            this.grHoaDon.AllowDeleting = true;
            this.grHoaDon.GUID = "a6836c07-edc1-467f-a60d-6ca09bbe8aae";
            this.grHoaDon.Name = "grHoaDon";
            this.grHoaDon.TabIndex = 0;
            this.grHoaDon.Table = "TDONHANG";
            this.grHoaDon.Columns.AddRange(new No1Lib.Sys.No1GridColumn[] {
                colHoaDon_DIEM,
                colHoaDon_NAME,
                colHoaDon_NGAY,
                colHoaDon_TONGCONG,
                colHoaDon_DIEMGIAM
            });
            this.grHoaDon.CustomLoadData += this.grHoaDon_CustomLoadData;
            // 
            // Timer1
            // 
            this.Timer1.Interval = 200;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);

            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).EndInit();
            this.KryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).EndInit();
            this.KryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).EndInit();
            this.KryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2.Panel1)).EndInit();
            this.KryptonSplitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2.Panel2)).EndInit();
            this.KryptonSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer2)).EndInit();
            this.KryptonSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabDetail)).EndInit();
            this.tabDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageTangDiem)).EndInit();
            this.pageTangDiem.ResumeLayout(false);
            this.pageTangDiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grTangDiem)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageDiemTheoHoaDon)).EndInit();
            this.pageDiemTheoHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grHoaDon)).EndInit();
            this.ResumeLayout(false);
        }

        private static System.Drawing.Image LoadImageFromBase64(string b64)
        {
            try
            {
                byte[] bytes = System.Convert.FromBase64String(b64);
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    return new System.Drawing.Bitmap(ms);
                }
            }
            catch { return null; }
        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer KryptonSplitContainer1;
        public No1Lib.Sys.No1TreeTable tvNhom;
        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer KryptonSplitContainer2;
        public No1Lib.Sys.GridMapper grKhachHang;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Label Label1;
        public No1Lib.Sys.No1TextBox txtTim;
        public ComponentFactory.Krypton.Navigator.KryptonNavigator tabDetail;
        public ComponentFactory.Krypton.Navigator.KryptonPage pageTangDiem;
        public No1Lib.Sys.No1DataGrid grTangDiem;
        public System.Windows.Forms.ToolStrip ToolStrip1;
        public System.Windows.Forms.ToolStripButton tsbThem;
        public System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tsbSua;
        public System.Windows.Forms.ToolStripButton tsbXoa;
        public ComponentFactory.Krypton.Navigator.KryptonPage pageDiemTheoHoaDon;
        public No1Lib.Sys.No1DataGrid grHoaDon;
        public System.Windows.Forms.Timer Timer1;

        public const string VIEWCONFIG_KHACHHANG = @"PERvY3VtZW50RWxlbWVudD4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+MmVkMTcwMTAtNjdlNS00OWE0LWE5M2MtOTk0Y2FhZThlOWU1PC9DT0xJRD4NCiAgICA8VEFCTEVJRD41ZmNjNTcxYS02NjJkLTQ5NTMtYTgzZi02MDA0YzczMmY0Mzk8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmEzNjU5NGYzLTQzZjAtNDk4Ni04ZjM1LTliNmVlZmFmMjFiYjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NWZjYzU3MWEtNjYyZC00OTUzLWE4M2YtNjAwNGM3MzJmNDM5PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUPkFTQzwvU09SVD4NCiAgICA8Q09ORElUSU9OIC8+DQogICAgPE5PVEVNUFRZPmZhbHNlPC9OT1RFTVBUWT4NCiAgICA8Tk9URFVQTElDQVRFPmZhbHNlPC9OT1REVVBMSUNBVEU+DQogICAgPEZPUk1VTEEgLz4NCiAgICA8UEFSQU1JRCAvPg0KICAgIDxDQVBUSU9OIC8+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPjI3ZGYwMjAzLTQ3MjYtNDQyZi05Y2NlLWQ5NWNjMTljNzA0NDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NWZjYzU3MWEtNjYyZC00OTUzLWE4M2YtNjAwNGM3MzJmNDM5PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD50cnVlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmI5NzA1YjYwLWU2MGQtNDQ3Yi04NjlkLWExMWExYWY1Yjk2NjwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NThhZWI3MTctMDViNC00NDg1LTgzNDctYmE4MWQ3OTJjZGEwPC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD50cnVlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFIC8+DQogICAgPEFMSUFTIC8+DQogICAgPENVU1RPTUZJRUxEPkZhbHNlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRSAvPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICAgIDxQQVJFTlRJRD4yN2RmMDIwMy00NzI2LTQ0MmYtOWNjZS1kOTVjYzE5YzcwNDQ8L1BBUkVOVElEPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEPmNjYmM2NTM4LTJmOWQtNGJlMC05Mjc2LTEzOWYxOWY2ZjA0NDwvQ09MSUQ+DQogICAgPFRBQkxFSUQ+NWZjYzU3MWEtNjYyZC00OTUzLWE4M2YtNjAwNGM3MzJmNDM5PC9UQUJMRUlEPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD4yZGI0OTQzZS0xYjRlLTQxYjItODFmMS0zNTEwYjA3YjNhMTg8L0NPTElEPg0KICAgIDxUQUJMRUlEPjVmY2M1NzFhLTY2MmQtNDk1My1hODNmLTYwMDRjNzMyZjQzOTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQ+N2E4NTdhMzQtYWNmMC00YjlkLTk0YzEtMzJmNzgzNmVkYmIyPC9DT0xJRD4NCiAgICA8VEFCTEVJRD41ZmNjNTcxYS02NjJkLTQ5NTMtYTgzZi02MDA0YzczMmY0Mzk8L1RBQkxFSUQ+DQogICAgPFRPVEFMIC8+DQogICAgPFNPUlQgLz4NCiAgICA8Q09ORElUSU9OPihES0hBQ0hIQU5HLlNUQVRVUyA9IDMwKTwvQ09ORElUSU9OPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTiAvPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRSAvPg0KICAgIDxBTElBUyAvPg0KICAgIDxDVVNUT01GSUVMRD5GYWxzZTwvQ1VTVE9NRklFTEQ+DQogICAgPENVU1RPTUNPTFRZUEUgLz4NCiAgICA8U0VMRUNUT1JERVIgLz4NCiAgPC9EYXRhPg0KICA8RGF0YT4NCiAgICA8Q0hFQ0tFRD50cnVlPC9DSEVDS0VEPg0KICAgIDxDT0xJRD5lZjcwMzNkYy0zZTRhLTQzODYtYTRkNC1mMzQ2MGJlYmZmZDM8L0NPTElEPg0KICAgIDxUQUJMRUlEPjVmY2M1NzFhLTY2MmQtNDk1My1hODNmLTYwMDRjNzMyZjQzOTwvVEFCTEVJRD4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04gLz4NCiAgICA8S0hPTkdUQU9DT1Q+ZmFsc2U8L0tIT05HVEFPQ09UPg0KICAgIDxSRUFET05MWT5mYWxzZTwvUkVBRE9OTFk+DQogICAgPFJFUExBQ0UgLz4NCiAgICA8QUxJQVMgLz4NCiAgICA8Q1VTVE9NRklFTEQ+RmFsc2U8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFIC8+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQgLz4NCiAgICA8VEFCTEVJRCAvPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5Eb2FuaCBz4buRPC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRT4oU0VMRUNUIENPQUxFU0NFKFNVTShUT05HQ09ORyksIDApIEZST00gVERPTkhBTkcgV0hFUkUgREFUSEFOSFRPQU4gPSAzMCBBTkQgTE9BSSA9IDAgQU5EIERLSEFDSEhBTkdJRD1ES0hBQ0hIQU5HLklEKTwvUkVQTEFDRT4NCiAgICA8QUxJQVM+RE9BTkhTTzwvQUxJQVM+DQogICAgPENVU1RPTUZJRUxEPlRydWU8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFPkludGVnZXI8L0NVU1RPTUNPTFRZUEU+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCiAgPERhdGE+DQogICAgPENIRUNLRUQ+dHJ1ZTwvQ0hFQ0tFRD4NCiAgICA8Q09MSUQgLz4NCiAgICA8VEFCTEVJRCAvPg0KICAgIDxUT1RBTCAvPg0KICAgIDxTT1JUIC8+DQogICAgPENPTkRJVElPTiAvPg0KICAgIDxOT1RFTVBUWT5mYWxzZTwvTk9URU1QVFk+DQogICAgPE5PVERVUExJQ0FURT5mYWxzZTwvTk9URFVQTElDQVRFPg0KICAgIDxGT1JNVUxBIC8+DQogICAgPFBBUkFNSUQgLz4NCiAgICA8Q0FQVElPTj5T4buRIGjDs2EgxJHGoW48L0NBUFRJT04+DQogICAgPEtIT05HVEFPQ09UPmZhbHNlPC9LSE9OR1RBT0NPVD4NCiAgICA8UkVBRE9OTFk+ZmFsc2U8L1JFQURPTkxZPg0KICAgIDxSRVBMQUNFPihTRUxFQ1QgQ09VTlQoKikgRlJPTSBURE9OSEFORyBXSEVSRSBEQVRIQU5IVE9BTiA9IDMwIEFORCBMT0FJID0gMCBBTkQgREtIQUNISEFOR0lEPURLSEFDSEhBTkcuSUQpPC9SRVBMQUNFPg0KICAgIDxBTElBUz5TT0RPTkhBTkc8L0FMSUFTPg0KICAgIDxDVVNUT01GSUVMRD5UcnVlPC9DVVNUT01GSUVMRD4NCiAgICA8Q1VTVE9NQ09MVFlQRT5JbnRlZ2VyPC9DVVNUT01DT0xUWVBFPg0KICAgIDxTRUxFQ1RPUkRFUiAvPg0KICA8L0RhdGE+DQogIDxEYXRhPg0KICAgIDxDSEVDS0VEPnRydWU8L0NIRUNLRUQ+DQogICAgPENPTElEIC8+DQogICAgPFRBQkxFSUQgLz4NCiAgICA8VE9UQUwgLz4NCiAgICA8U09SVCAvPg0KICAgIDxDT05ESVRJT04gLz4NCiAgICA8Tk9URU1QVFk+ZmFsc2U8L05PVEVNUFRZPg0KICAgIDxOT1REVVBMSUNBVEU+ZmFsc2U8L05PVERVUExJQ0FURT4NCiAgICA8Rk9STVVMQSAvPg0KICAgIDxQQVJBTUlEIC8+DQogICAgPENBUFRJT04+xJBp4buDbSB0w61jaCBsxal5PC9DQVBUSU9OPg0KICAgIDxLSE9OR1RBT0NPVD5mYWxzZTwvS0hPTkdUQU9DT1Q+DQogICAgPFJFQURPTkxZPmZhbHNlPC9SRUFET05MWT4NCiAgICA8UkVQTEFDRT5DT0FMRVNDRShESUVNVElDSExVWUJBTkRBVSwgMCkgKyAoU0VMRUNUIENPQUxFU0NFKENBU0UgV0hFTiBAQ0FDSFRJTkggPSAxIFRIRU4gU1VNKENPQUxFU0NFKERJRU0sIDApIC0gQ09BTEVTQ0UoRElFTUdJQU0sIDApKSBFTFNFIFNVTShUT05HQ09ORykgLyBDQVNUKEBESUVNIEFTIERFQ0lNQUwoMTgsIDIpKSAtIFNVTShDT0FMRVNDRShESUVNR0lBTSwgMCkpIEVORCwgMCkgRlJPTSBURE9OSEFORyBXSEVSRSBEQVRIQU5IVE9BTiA9IDMwIEFORCBMT0FJID0gMCBBTkQgREtIQUNISEFOR0lEPURLSEFDSEhBTkcuSUQpICsgKFNFTEVDVCBDT0FMRVNDRShTVU0oRElFTVRBTkctRElFTUdJQU0pLDApIEZST00gVFRBTkdHSUFNRElFTSBXSEVSRSBES0hBQ0hIQU5HSUQgPSBES0hBQ0hIQU5HLklEKTwvUkVQTEFDRT4NCiAgICA8QUxJQVM+RElFTTwvQUxJQVM+DQogICAgPENVU1RPTUZJRUxEPlRydWU8L0NVU1RPTUZJRUxEPg0KICAgIDxDVVNUT01DT0xUWVBFPkludGVnZXI8L0NVU1RPTUNPTFRZUEU+DQogICAgPFNFTEVDVE9SREVSIC8+DQogIDwvRGF0YT4NCjwvRG9jdW1lbnRFbGVtZW50Pg==";
    }
}
