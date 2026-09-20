using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using FirebirdSql.Data.FirebirdClient;

namespace QuanLyNhaHang.Services
{
    public class FormModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public int FormType { get; set; }
        public int Loai { get; set; }
        public string STableDescId { get; set; }
        public string SFunctionId { get; set; }
        public string BillCode { get; set; }
        public string Noun { get; set; }
        public string Verb { get; set; }
        public string Code { get; set; }
        public string DesignCode { get; set; }
        public string AeLayout { get; set; }
        public string ClientCode { get; set; }
        public string ServerCode { get; set; }
        public string Note { get; set; }
        public byte[] ImageBytes { get; set; }
    }


    public static class DbFormService
    {
        public static string DefaultDbPath = @"d:\QuanLyNhaHang\Database\DEMO.FDB";

        public static string GetConnectionString(string dbPath = null)
        {
            if (string.IsNullOrEmpty(dbPath))
                dbPath = Program.CurrentDatabasePath;
            if (string.IsNullOrEmpty(dbPath))
                dbPath = DefaultDbPath;

            FbConnectionStringBuilder builder = new FbConnectionStringBuilder
            {
                UserID = "SYSDBA",
                Password = "masterkey",
                Database = dbPath,
                DataSource = "localhost",
                Port = 3050,
                Dialect = 3,
                Charset = "NONE",
                ServerType = FbServerType.Default
            };

            return builder.ConnectionString;
        }

        public static Form CreateFormByName(string formName)
        {
            try
            {
                FormModel model = GetFormModelFromDb(formName);

                // 1. Prioritize XML layout from SFORM.AELAYOUT if present in DB
                if (model != null && !string.IsNullOrEmpty(model.AeLayout))
                {
                    Form xmlForm = ParseAeLayoutToForm(model.AeLayout, model.Name);
                    if (xmlForm != null)
                    {
                        return xmlForm;
                    }
                }

                // 2. Specific Fallbacks if AELAYOUT is empty/NULL in DB
                if (string.Equals(formName, "Sử dụng dịch vụ", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "SuDungDichVu", StringComparison.OrdinalIgnoreCase) ||
                    (model != null && string.Equals(model.ClassName, "SuDungDichVu", StringComparison.OrdinalIgnoreCase)))
                {
                    return CreateDynamicSuDungDichVuForm(model);
                }

                if (string.Equals(formName, "Chuyển hoá đơn", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "Chuyển hóa đơn", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "ChuyenHoaDon", StringComparison.OrdinalIgnoreCase))
                {
                    return CreateChuyenHoaDonForm();
                }

                if (string.Equals(formName, "Chọn máy in", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "ChonMayIn", StringComparison.OrdinalIgnoreCase))
                {
                    return CreateChonMayInForm();
                }

                if (string.Equals(formName, "Chuyển bàn", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "ChuyenBan", StringComparison.OrdinalIgnoreCase))
                {
                    return CreateChuyenBanForm();
                }

                if (string.Equals(formName, "Quản lý bán hàng", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "QuanLyBanHang", StringComparison.OrdinalIgnoreCase) ||
                    (!string.IsNullOrEmpty(formName) && (
                        formName.IndexOf("bán hàng", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        formName.IndexOf("đặt hàng", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        formName.IndexOf("order", StringComparison.OrdinalIgnoreCase) >= 0
                    )) ||
                    (model != null && (
                        string.Equals(model.ClassName, "QuanLyBanHang", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(model.ClassName, "KiemSoatOrder", StringComparison.OrdinalIgnoreCase)
                    )))
                {
                    return CreateDynamicQuanLyBanHangForm(model ?? new FormModel { Name = formName });
                }

                // 3. Fallback based on FormType
                if (model != null && model.FormType == 1) // Quản trị / Danh mục
                {
                    return CreateDefaultDynamicDataForm(formName, model);
                }

                // Default Blank Form for Custom Form (6) or Thêm sửa (0)
                return new Form
                {
                    Text = formName,
                    Size = new Size(800, 500),
                    BackColor = Color.FromArgb(198, 215, 235),
                    StartPosition = FormStartPosition.CenterParent
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi nạp form động [{formName}]: {ex.Message}");
                return new Form
                {
                    Text = formName,
                    Size = new Size(800, 500),
                    BackColor = Color.FromArgb(198, 215, 235),
                    StartPosition = FormStartPosition.CenterParent
                };
            }
        }

        public static FormModel GetFormModelFromDb(string formName)
        {
            string connStr = GetConnectionString();
            try
            {
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT ID, NAME, CLASSNAME, FORMTYPE, LOAI, STABLEDESCID, SFUNCTIONID, NOTEMPLATE, NOTE,
                                            CODE, DESIGNCODE, AELAYOUT, CLIENTCODE, SERVERCODE, IMAGE32 
                                     FROM SFORM 
                                     WHERE LOWER(NAME) = LOWER(@Name) OR LOWER(CLASSNAME) = LOWER(@Name) OR ID = @Name";

                    using (FbCommand cmd = new FbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", formName);
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new FormModel
                                {
                                    Id = reader["ID"]?.ToString(),
                                    Name = reader["NAME"]?.ToString(),
                                    ClassName = reader["CLASSNAME"]?.ToString(),
                                    FormType = reader["FORMTYPE"] != DBNull.Value ? Convert.ToInt32(reader["FORMTYPE"]) : 0,
                                    Loai = reader["LOAI"] != DBNull.Value ? Convert.ToInt32(reader["LOAI"]) : 0,
                                    STableDescId = reader["STABLEDESCID"]?.ToString(),
                                    SFunctionId = reader["SFUNCTIONID"]?.ToString(),
                                    BillCode = reader["NOTEMPLATE"]?.ToString(),
                                    Note = reader["NOTE"]?.ToString(),
                                    Code = ReadBlobString(reader, "CODE"),
                                    DesignCode = ReadBlobString(reader, "DESIGNCODE"),
                                    AeLayout = ReadBlobString(reader, "AELAYOUT"),
                                    ClientCode = ReadBlobString(reader, "CLIENTCODE"),
                                    ServerCode = ReadBlobString(reader, "SERVERCODE"),
                                    ImageBytes = ReadBlobBytes(reader, "IMAGE32")
                                };
                            }
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        private static Form CreateDynamicSuDungDichVuForm(FormModel model)
        {
            Form form = new Form
            {
                Text = model != null && !string.IsNullOrEmpty(model.Name) ? model.Name : "Sử dụng dịch vụ",
                Size = new Size(1024, 545),
                BackColor = System.Drawing.Color.White,
                WindowState = FormWindowState.Normal
            };

            // Dynamic 3-panel container matching SFORM layout
            SplitContainer splitMain = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 350 };
            SplitContainer splitKhuVuc = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 360 };
            TabControl tabKhuVuc = new TabControl { Dock = DockStyle.Fill, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            TabControl tabKhuVuc2 = new TabControl { Dock = DockStyle.Fill, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };

            splitKhuVuc.Panel1.Controls.Add(tabKhuVuc);
            splitKhuVuc.Panel2.Controls.Add(tabKhuVuc2);
            splitMain.Panel1.Controls.Add(splitKhuVuc);

            // Right Order & Food Menu Panel
            SplitContainer splitCenterRight = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 580 };
            SplitContainer splitCenter = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 550 };

            Panel pnlOrderHeader = new Panel { Dock = DockStyle.Top, Height = 100, BackColor = System.Drawing.Color.FromArgb(240, 243, 248) };
            Label lblActiveTable = new Label { Text = "Chưa chọn bàn", Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold), Location = new System.Drawing.Point(10, 10), AutoSize = true };
            Label lblStartTime = new Label { Text = "Chưa bắt đầu", Font = new System.Drawing.Font("Segoe UI", 9F), ForeColor = System.Drawing.Color.Gray, Location = new System.Drawing.Point(120, 13), AutoSize = true };
            Button btnStart = new Button { Text = "Bắt đầu", Location = new System.Drawing.Point(240, 8), Size = new System.Drawing.Size(75, 26), Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };

            pnlOrderHeader.Controls.Add(lblActiveTable);
            pnlOrderHeader.Controls.Add(lblStartTime);
            pnlOrderHeader.Controls.Add(btnStart);

            DataGridView dgvOrder = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = System.Drawing.Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            DataTable dtOrder = new DataTable();
            dtOrder.Columns.Add("Tên hàng", typeof(string));
            dtOrder.Columns.Add("ĐVT", typeof(string));
            dtOrder.Columns.Add("SL", typeof(decimal));
            dtOrder.Columns.Add("Đ giá", typeof(decimal));
            dtOrder.Columns.Add("CK%", typeof(decimal));
            dtOrder.Columns.Add("T tiền", typeof(decimal));
            dtOrder.Columns.Add("Ghi chú", typeof(string));
            dgvOrder.DataSource = dtOrder;

            Panel pnlSummary = new Panel { Dock = DockStyle.Fill, BackColor = System.Drawing.Color.FromArgb(242, 244, 248) };
            Label lblTotalText = new Label { Text = "Tổng cộng:", Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold), Location = new System.Drawing.Point(100, 60), AutoSize = true };
            Label lblTotalVal = new Label { Text = "0", Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.Red, Location = new System.Drawing.Point(220, 55), AutoSize = true };
            Button btnPay = new Button { Text = "Thanh toán (F11)", Anchor = AnchorStyles.Top | AnchorStyles.Right, Location = new System.Drawing.Point(480, 50), Size = new System.Drawing.Size(90, 40), Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };

            pnlSummary.Controls.Add(lblTotalText);
            pnlSummary.Controls.Add(lblTotalVal);
            pnlSummary.Controls.Add(btnPay);

            splitCenter.Panel1.Controls.Add(dgvOrder);
            splitCenter.Panel1.Controls.Add(pnlOrderHeader);
            splitCenter.Panel2.Controls.Add(pnlSummary);
            splitCenterRight.Panel1.Controls.Add(splitCenter);

            // Food Categories Tree + Food Grid Panel
            Panel pnlRight = new Panel { Dock = DockStyle.Fill };
            TreeView treeNhom = new TreeView { Dock = DockStyle.Top, Height = 250, Font = new System.Drawing.Font("Segoe UI", 9F) };
            DataGridView dgvFood = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false, ReadOnly = true };

            pnlRight.Controls.Add(dgvFood);
            pnlRight.Controls.Add(treeNhom);
            splitCenterRight.Panel2.Controls.Add(pnlRight);
            splitMain.Panel2.Controls.Add(splitCenterRight);

            form.Controls.Add(splitMain);

            // Load Data from Firebird SQL Tables dynamically
            LoadDynamicKhuVucAndBan(tabKhuVuc, tabKhuVuc2, splitKhuVuc, lblActiveTable, lblStartTime, btnStart, dtOrder, lblTotalVal, dgvOrder);
            LoadDynamicNhomAndThucDon(treeNhom, dgvFood, dtOrder, lblTotalVal);

            return form;
        }

        private static void LoadDynamicKhuVucAndBan(TabControl tab1, TabControl tab2, SplitContainer splitKv, Label lblActiveTable, Label lblStartTime, Button btnStart, DataTable dtOrder, Label lblTotalVal, DataGridView dgvOrder)
        {
            try
            {
                tab1.TabPages.Clear();
                tab2.TabPages.Clear();

                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sqlKv = "SELECT ID, NAME, COALESCE(TABHIENTHI, 0) AS TABIDX FROM DKHUVUC WHERE STATUS = 30 ORDER BY SORTORDER, NAME";
                    DataTable dtKv = new DataTable();
                    using (FbDataAdapter da = new FbDataAdapter(sqlKv, conn)) { da.Fill(dtKv); }

                    foreach (DataRow r in dtKv.Rows)
                    {
                        string id = r["ID"]?.ToString();
                        string name = r["NAME"]?.ToString();
                        int tabIdx = r["TABIDX"] != DBNull.Value ? Convert.ToInt32(r["TABIDX"]) : 0;

                        TabPage page = new TabPage(name) { Name = id, Tag = id };
                        FlowLayoutPanel pnlCards = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = System.Drawing.Color.FromArgb(245, 246, 248), Padding = new Padding(6) };
                        page.Controls.Add(pnlCards);

                        if (tabIdx == 1) tab2.TabPages.Add(page);
                        else tab1.TabPages.Add(page);

                        LoadTableCardsForPage(id, pnlCards, lblActiveTable, lblStartTime, btnStart, dtOrder, lblTotalVal, dgvOrder);
                    }

                    if (tab2.TabPages.Count == 0) splitKv.Panel2Collapsed = true;
                    else splitKv.Panel2Collapsed = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi LoadDynamicKhuVucAndBan: " + ex.Message);
            }
        }

        private static void LoadTableCardsForPage(string kvId, FlowLayoutPanel pnlContainer, Label lblActiveTable, Label lblStartTime, Button btnStart, DataTable dtOrder, Label lblTotalVal, DataGridView dgvOrder)
        {
            pnlContainer.Controls.Clear();
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sql = @"
                        SELECT B.ID, B.NAME, B.TDONHANGID, H.BATDAU
                        FROM DBAN B
                        LEFT JOIN TDONHANG H ON B.TDONHANGID = H.ID AND H.DATHANHTOAN = 0
                        WHERE B.DKHUVUCID = @KvID
                        ORDER BY B.NAME";

                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@KvID", kvId);
                        using (FbDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                string banId = rdr["ID"]?.ToString();
                                string banName = rdr["NAME"]?.ToString();
                                string orderId = rdr["TDONHANGID"] != DBNull.Value ? rdr["TDONHANGID"]?.ToString() : null;
                                DateTime? batDau = rdr["BATDAU"] != DBNull.Value ? Convert.ToDateTime(rdr["BATDAU"]) : (DateTime?)null;

                                bool inUse = !string.IsNullOrEmpty(orderId);

                                Panel card = new Panel
                                {
                                    Size = new System.Drawing.Size(95, 95),
                                    Margin = new Padding(6),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    BackColor = System.Drawing.Color.White,
                                    Cursor = Cursors.Hand
                                };

                                if (inUse && batDau.HasValue)
                                {
                                    TimeSpan diff = DateTime.Now - batDau.Value;
                                    Label lblBadge = new Label { Text = $"{(int)diff.TotalHours}h {diff.Minutes}'", BackColor = System.Drawing.Color.Red, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold), Size = new System.Drawing.Size(50, 16), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
                                    card.Controls.Add(lblBadge);
                                }

                                Label lblName = new Label { Text = banName, Dock = DockStyle.Bottom, Height = 26, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), ForeColor = inUse ? System.Drawing.Color.DarkRed : System.Drawing.Color.Black };
                                card.Controls.Add(lblName);

                                card.Click += (s, e) =>
                                {
                                    lblActiveTable.Text = banName;
                                    lblStartTime.Text = batDau.HasValue ? batDau.Value.ToString("HH:mm dd/MM") : "Chưa bắt đầu";
                                    btnStart.Enabled = !inUse;
                                    LoadOrderDetailsForTable(orderId, dtOrder, lblTotalVal);
                                };
                                lblName.Click += (s, e) => card.PerformClick();

                                pnlContainer.Controls.Add(card);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi LoadTableCardsForPage: " + ex.Message);
            }
        }

        private static void PerformClick(this Control ctrl)
        {
            // Helper extension for invoking click
        }

        private static void LoadOrderDetailsForTable(string orderId, DataTable dtOrder, Label lblTotalVal)
        {
            dtOrder.Clear();
            decimal sum = 0m;
            if (!string.IsNullOrEmpty(orderId))
            {
                try
                {
                    using (FbConnection conn = new FbConnection(GetConnectionString()))
                    {
                        conn.Open();
                        string sql = @"
                            SELECT M.NAME AS TENHANG, D.NAME AS DVT, C.SLXUAT AS SOLUONG, C.DONGIA, COALESCE(C.TILEGIAMGIA, 0) AS CHIECKHAU, C.THANHTIEN
                            FROM TDONHANGCHITIET C
                            INNER JOIN DMATHANG M ON C.DMATHANGID = M.ID
                            LEFT JOIN DDONVITINH D ON M.DDONVITINHID = D.ID
                            WHERE C.TDONHANGID = @OrderID";

                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", orderId);
                            using (FbDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    string ten = rdr["TENHANG"]?.ToString();
                                    string dvt = rdr["DVT"] != DBNull.Value ? rdr["DVT"]?.ToString() : "";
                                    decimal sl = rdr["SOLUONG"] != DBNull.Value ? Convert.ToDecimal(rdr["SOLUONG"]) : 1m;
                                    decimal gia = rdr["DONGIA"] != DBNull.Value ? Convert.ToDecimal(rdr["DONGIA"]) : 0m;
                                    decimal ck = rdr["CHIECKHAU"] != DBNull.Value ? Convert.ToDecimal(rdr["CHIECKHAU"]) : 0m;
                                    decimal tt = rdr["THANHTIEN"] != DBNull.Value ? Convert.ToDecimal(rdr["THANHTIEN"]) : (sl * gia) - ck;
                                    sum += tt;

                                    dtOrder.Rows.Add(ten, dvt, sl, gia, ck, tt, "");
                                }
                            }
                        }
                    }
                }
                catch { }
            }
            lblTotalVal.Text = sum.ToString("#,##0");
        }

        private static void LoadDynamicNhomAndThucDon(TreeView treeNhom, DataGridView dgvFood, DataTable dtOrder, Label lblTotalVal)
        {
            try
            {
                treeNhom.Nodes.Clear();
                TreeNode root = new TreeNode("Tất cả") { Tag = "ALL" };
                treeNhom.Nodes.Add(root);

                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sqlNhom = "SELECT ID, NAME FROM DNHOMMATHANG WHERE STATUS = 30 ORDER BY SORTORDER, NAME";
                    using (FbCommand cmd = new FbCommand(sqlNhom, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            root.Nodes.Add(new TreeNode(rdr["NAME"]?.ToString()) { Tag = rdr["ID"]?.ToString() });
                        }
                    }
                    root.Expand();

                    string sqlMon = @"
                        SELECT M.ID, M.NAME AS TENHANG, D.NAME AS DVT, M.GIABAN, M.CODE AS MAHANG, M.DNHOMMATHANGID
                        FROM DMATHANG M
                        LEFT JOIN DDONVITINH D ON M.DDONVITINHID = D.ID
                        WHERE M.STATUS = 30
                        ORDER BY M.SORTORDER, M.NAME";

                    DataTable dtFood = new DataTable();
                    using (FbDataAdapter da = new FbDataAdapter(sqlMon, conn)) { da.Fill(dtFood); }

                    dgvFood.DataSource = dtFood;
                    if (dgvFood.Columns.Contains("ID")) dgvFood.Columns["ID"].Visible = false;
                    if (dgvFood.Columns.Contains("DNHOMMATHANGID")) dgvFood.Columns["DNHOMMATHANGID"].Visible = false;
                    if (dgvFood.Columns.Contains("TENHANG")) dgvFood.Columns["TENHANG"].HeaderText = "Tên hàng";
                    if (dgvFood.Columns.Contains("DVT")) dgvFood.Columns["DVT"].HeaderText = "ĐVT";
                    if (dgvFood.Columns.Contains("GIABAN")) { dgvFood.Columns["GIABAN"].HeaderText = "Giá bán"; dgvFood.Columns["GIABAN"].DefaultCellStyle.Format = "#,##0"; }
                    if (dgvFood.Columns.Contains("MAHANG")) dgvFood.Columns["MAHANG"].HeaderText = "Mã hàng";

                    treeNhom.AfterSelect += (s, e) =>
                    {
                        string tag = e.Node.Tag?.ToString();
                        if (tag == "ALL" || string.IsNullOrEmpty(tag)) dgvFood.DataSource = dtFood;
                        else
                        {
                            DataView dv = new DataView(dtFood) { RowFilter = $"DNHOMMATHANGID = '{tag}'" };
                            dgvFood.DataSource = dv;
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi LoadDynamicNhomAndThucDon: " + ex.Message);
            }
        }

        private static Form CreateDynamicQuanLyBanHangForm(FormModel model)
        {
            Form form = new Form
            {
                Text = model != null && !string.IsNullOrEmpty(model.Name) ? model.Name : "Quản lý bán hàng",
                Size = new Size(1024, 545),
                BackColor = System.Drawing.Color.White,
                WindowState = FormWindowState.Normal
            };

            SplitContainer splitMain = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 650 };

            // Left Invoices Panel
            Panel pnlLeftTop = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = System.Drawing.Color.FromArgb(240, 243, 248) };
            Label lblFrom = new Label { Text = "Từ:", Location = new System.Drawing.Point(10, 10), AutoSize = true };
            DateTimePicker dtFrom = new DateTimePicker { Location = new System.Drawing.Point(40, 7), Format = DateTimePickerFormat.Short, Width = 100, Value = new DateTime(2016, 1, 1) };
            Label lblTo = new Label { Text = "Đến:", Location = new System.Drawing.Point(150, 10), AutoSize = true };
            DateTimePicker dtTo = new DateTimePicker { Location = new System.Drawing.Point(185, 7), Format = DateTimePickerFormat.Short, Width = 100 };
            Button btnReload = new Button { Text = "Tải dữ liệu", Location = new System.Drawing.Point(300, 6), Size = new System.Drawing.Size(90, 26) };

            pnlLeftTop.Controls.Add(lblFrom);
            pnlLeftTop.Controls.Add(dtFrom);
            pnlLeftTop.Controls.Add(lblTo);
            pnlLeftTop.Controls.Add(dtTo);
            pnlLeftTop.Controls.Add(btnReload);

            DataGridView dgvBills = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = System.Drawing.Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            splitMain.Panel1.Controls.Add(dgvBills);
            splitMain.Panel1.Controls.Add(pnlLeftTop);

            // Right Invoice Details Panel
            Panel pnlRightHeader = new Panel { Dock = DockStyle.Top, Height = 90, BackColor = System.Drawing.Color.FromArgb(240, 243, 248) };
            Label lblBanTitle = new Label { Text = "Bàn --", Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold), Location = new System.Drawing.Point(10, 10), AutoSize = true };
            Label lblSoPhieu = new Label { Text = "Số phiếu:", Location = new System.Drawing.Point(10, 40), AutoSize = true };
            TextBox txtSoPhieu = new TextBox { Location = new System.Drawing.Point(80, 37), Width = 120, ReadOnly = true };

            pnlRightHeader.Controls.Add(lblBanTitle);
            pnlRightHeader.Controls.Add(lblSoPhieu);
            pnlRightHeader.Controls.Add(txtSoPhieu);

            DataGridView dgvBillDetails = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = System.Drawing.Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            DataTable dtDetails = new DataTable();
            dtDetails.Columns.Add("Tên hàng", typeof(string));
            dtDetails.Columns.Add("ĐVT", typeof(string));
            dtDetails.Columns.Add("SL", typeof(decimal));
            dtDetails.Columns.Add("Đ giá", typeof(decimal));
            dtDetails.Columns.Add("CK%", typeof(decimal));
            dtDetails.Columns.Add("T tiền", typeof(decimal));
            dgvBillDetails.DataSource = dtDetails;

            Panel pnlRightMain = new Panel { Dock = DockStyle.Fill };
            pnlRightMain.Controls.Add(dgvBillDetails);
            pnlRightMain.Controls.Add(pnlRightHeader);

            splitMain.Panel2.Controls.Add(pnlRightMain);
            form.Controls.Add(splitMain);

            // Fetch Sales Bills dynamically from Firebird TDONHANG
            Action loadData = () =>
            {
                try
                {
                    using (FbConnection conn = new FbConnection(GetConnectionString()))
                    {
                        conn.Open();
                        string sql = @"
                            SELECT H.SOHD AS SOHD_VAL, H.ID, H.NAME AS SOHD_TEXT, H.NGAY, B.NAME AS BAN_NAME, H.BATDAU, H.KETTHUC, H.TONGCONG, H.TIENGIAMGIA, H.TILEGIAMGIA, H.TIENHANG
                            FROM TDONHANG H
                            LEFT JOIN DBAN B ON H.DBANID = B.ID
                            WHERE H.NGAY BETWEEN @FromDate AND @ToDate
                            ORDER BY H.NGAY DESC, H.SOHD DESC";

                        DataTable dtBills = new DataTable();
                        using (FbDataAdapter da = new FbDataAdapter(sql, conn))
                        {
                            da.SelectCommand.Parameters.AddWithValue("@FromDate", dtFrom.Value.Date);
                            da.SelectCommand.Parameters.AddWithValue("@ToDate", dtTo.Value.Date);
                            da.Fill(dtBills);
                        }

                        dgvBills.DataSource = dtBills;
                        if (dgvBills.Columns.Contains("ID")) dgvBills.Columns["ID"].Visible = false;
                        if (dgvBills.Columns.Contains("SOHD_VAL")) dgvBills.Columns["SOHD_VAL"].HeaderText = "Số phiếu";
                        if (dgvBills.Columns.Contains("SOHD_TEXT")) dgvBills.Columns["SOHD_TEXT"].Visible = false;
                        if (dgvBills.Columns.Contains("NGAY")) dgvBills.Columns["NGAY"].HeaderText = "Ngày";
                        if (dgvBills.Columns.Contains("BAN_NAME")) dgvBills.Columns["BAN_NAME"].HeaderText = "Bàn";
                        if (dgvBills.Columns.Contains("BATDAU")) dgvBills.Columns["BATDAU"].HeaderText = "Bắt đầu";
                        if (dgvBills.Columns.Contains("KETTHUC")) dgvBills.Columns["KETTHUC"].HeaderText = "Kết thúc";
                        if (dgvBills.Columns.Contains("TONGCONG")) { dgvBills.Columns["TONGCONG"].HeaderText = "Tổng cộng"; dgvBills.Columns["TONGCONG"].DefaultCellStyle.Format = "#,##0"; }
                    }
                }
                catch { }
            };

            btnReload.Click += (s, e) => loadData();
            form.Load += (s, e) => loadData();

            dgvBills.SelectionChanged += (s, e) =>
            {
                if (dgvBills.CurrentRow != null && dgvBills.CurrentRow.DataBoundItem is DataRowView drv)
                {
                    string orderId = drv["ID"]?.ToString();
                    lblBanTitle.Text = drv["BAN_NAME"] != DBNull.Value ? drv["BAN_NAME"]?.ToString() : "Bàn --";
                    txtSoPhieu.Text = drv["SOHD_VAL"] != DBNull.Value ? drv["SOHD_VAL"]?.ToString() : "";

                    LoadOrderDetailsForTable(orderId, dtDetails, new Label());
                }
            };

            return form;
        }

        private static Form CreateChuyenHoaDonForm()
        {
            Form f = new Form
            {
                Text = "Chuyển hóa đơn",
                Size = new Size(620, 420),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(245, 247, 250)
            };

            Panel pnlTop = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = Color.FromArgb(235, 240, 248), Padding = new Padding(10) };
            Label lblSource = new Label { Text = "Hóa đơn nguồn:", Location = new Point(12, 16), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            ComboBox cboSource = new ComboBox { Location = new Point(120, 13), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            
            Label lblTarget = new Label { Text = "Chuyển sang bàn:", Location = new Point(315, 16), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            ComboBox cboTarget = new ComboBox { Location = new Point(430, 13), Width = 160, DropDownStyle = ComboBoxStyle.DropDownList };

            Button btnExecute = new Button { Text = "🔄 Thực hiện chuyển hóa đơn", Location = new Point(120, 45), Size = new Size(200, 28), Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.FromArgb(40, 120, 200), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnCancel = new Button { Text = "❌ Hủy bỏ", Location = new Point(330, 45), Size = new Size(100, 28), Font = new Font("Segoe UI", 9F) };

            pnlTop.Controls.AddRange(new Control[] { lblSource, cboSource, lblTarget, cboTarget, btnExecute, btnCancel });

            DataGridView dgv = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = Color.White, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, ReadOnly = true, AllowUserToAddRows = false };
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã món", typeof(string));
            dt.Columns.Add("Tên mặt hàng", typeof(string));
            dt.Columns.Add("ĐVT", typeof(string));
            dt.Columns.Add("Số lượng", typeof(decimal));
            dt.Columns.Add("Đơn giá", typeof(decimal));
            dt.Columns.Add("Thành tiền", typeof(decimal));
            dgv.DataSource = dt;

            f.Controls.Add(dgv);
            f.Controls.Add(pnlTop);
            return f;
        }

        private static Form CreateChonMayInForm()
        {
            Form f = new Form
            {
                Text = "Chọn máy in",
                Size = new Size(520, 320),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White
            };

            Panel pnlMain = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            Label lblHeader = new Label { Text = "CẤU HÌNH MÁY IN HỆ THỐNG", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 50, 120), Location = new Point(20, 15), AutoSize = true };

            Label lblReceipt = new Label { Text = "Máy in hóa đơn (Bill Printer):", Location = new Point(20, 55), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboReceipt = new ComboBox { Location = new Point(210, 52), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
            cboReceipt.Items.AddRange(new object[] { "Default Printer", "POS-80 Series", "Xprinter XP-N160I", "Microsoft Print to PDF" });
            cboReceipt.SelectedIndex = 0;

            Label lblKitchen = new Label { Text = "Máy in bếp / chế biến:", Location = new Point(20, 95), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboKitchen = new ComboBox { Location = new Point(210, 92), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
            cboKitchen.Items.AddRange(new object[] { "(Không sử dụng)", "Kitchen Printer 1", "POS-80 Series" });
            cboKitchen.SelectedIndex = 0;

            Label lblCopies = new Label { Text = "Số liên in hóa đơn:", Location = new Point(20, 135), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            NumericUpDown numCopies = new NumericUpDown { Location = new Point(210, 132), Width = 80, Value = 1, Minimum = 1, Maximum = 10 };

            CheckBox chkAuto = new CheckBox { Text = "Tự động in sau khi xác nhận thanh toán", Location = new Point(210, 168), AutoSize = true, Checked = true, Font = new Font("Segoe UI", 9F) };

            Button btnTest = new Button { Text = "🖨️ In thử", Location = new Point(140, 215), Size = new Size(100, 30), Font = new Font("Segoe UI", 9F) };
            Button btnSave = new Button { Text = "💾 Lưu cấu hình", Location = new Point(250, 215), Size = new Size(120, 30), Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.FromArgb(40, 120, 200), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnClose = new Button { Text = "❌ Đóng", Location = new Point(380, 215), Size = new Size(90, 30), Font = new Font("Segoe UI", 9F) };

            pnlMain.Controls.AddRange(new Control[] { lblHeader, lblReceipt, cboReceipt, lblKitchen, cboKitchen, lblCopies, numCopies, chkAuto, btnTest, btnSave, btnClose });
            f.Controls.Add(pnlMain);
            return f;
        }

        private static Form CreateChuyenBanForm()
        {
            Form f = new Form
            {
                Text = "Chuyển bàn",
                Size = new Size(480, 260),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White
            };

            Panel pnlMain = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            Label lblHeader = new Label { Text = "CHUYỂN BÀN KHÁCH DÙNG DỊCH VỤ", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 50, 120), Location = new Point(20, 15), AutoSize = true };

            Label lblFrom = new Label { Text = "Từ bàn:", Location = new Point(20, 60), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboFrom = new ComboBox { Location = new Point(90, 57), Width = 140, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblTo = new Label { Text = "Sang bàn:", Location = new Point(250, 60), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboTo = new ComboBox { Location = new Point(320, 57), Width = 140, DropDownStyle = ComboBoxStyle.DropDownList };

            Button btnExec = new Button { Text = "🔄 Thực hiện chuyển bàn", Location = new Point(120, 140), Size = new Size(180, 32), Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.FromArgb(40, 120, 200), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnCancel = new Button { Text = "❌ Hủy bỏ", Location = new Point(310, 140), Size = new Size(90, 32), Font = new Font("Segoe UI", 9F) };

            pnlMain.Controls.AddRange(new Control[] { lblHeader, lblFrom, cboFrom, lblTo, cboTo, btnExec, btnCancel });
            f.Controls.Add(pnlMain);
            return f;
        }

        private static Form CreateDefaultDynamicDataForm(string formName, FormModel model)
        {
            Form f = new Form
            {
                Text = formName,
                Size = new System.Drawing.Size(950, 600),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
            };

            // Top Action Toolbar matching Image 2
            ToolStrip tsAction = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(6, 4, 6, 4) };

            ToolStripLabel lblFrom = new ToolStripLabel(" Từ ngày: ");
            ToolStripControlHost hostFrom = new ToolStripControlHost(new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 100, Value = DateTime.Now.AddDays(-30) });
            ToolStripLabel lblTo = new ToolStripLabel(" Đến ngày: ");
            ToolStripControlHost hostTo = new ToolStripControlHost(new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 100, Value = DateTime.Now });

            ToolStripLabel lblSearch = new ToolStripLabel("  Tìm kiếm: ");
            ToolStripControlHost hostSearch = new ToolStripControlHost(new TextBox { Width = 140 });

            ToolStripButton btnFilter = new ToolStripButton("🔍 Lọc");
            ToolStripButton btnAdd = new ToolStripButton("➕ Thêm mới");
            ToolStripButton btnEdit = new ToolStripButton("✏️ Sửa");
            ToolStripButton btnDelete = new ToolStripButton("❌ Xóa");
            ToolStripButton btnExport = new ToolStripButton("📊 Xuất Excel");
            ToolStripButton btnReload = new ToolStripButton("🔄 Nạp lại");

            tsAction.Items.AddRange(new ToolStripItem[] {
                lblFrom, hostFrom, lblTo, hostTo, lblSearch, hostSearch, btnFilter, new ToolStripSeparator(),
                btnAdd, btnEdit, btnDelete, new ToolStripSeparator(), btnExport, btnReload
            });

            // Main Data Grid
            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Bottom Status / Totals Bar
            StatusStrip ss = new StatusStrip();
            ToolStripStatusLabel lblCount = new ToolStripStatusLabel { Text = "Tổng số bản ghi: 0 | Tổng giá trị: 0 VNĐ" };
            ss.Items.Add(lblCount);

            f.Controls.Add(dgv);
            f.Controls.Add(tsAction);
            f.Controls.Add(ss);

            Action loadData = () =>
            {
                try
                {
                    DataTable dt = QueryRichTableData(formName);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dgv.DataSource = dt;
                        lblCount.Text = $"Tổng số bản ghi: {dt.Rows.Count:N0}";

                        // Format numbers
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (col.ValueType == typeof(decimal) || col.ValueType == typeof(double) || col.ValueType == typeof(int) || col.ValueType == typeof(long))
                            {
                                if (col.Name.IndexOf("tiền", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    col.Name.IndexOf("nợ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    col.Name.IndexOf("giá", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    col.Name.IndexOf("cộng", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    col.DefaultCellStyle.Format = "#,#00";
                                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                }
                            }
                        }
                    }
                }
                catch { }
            };

            btnFilter.Click += (s, e) => loadData();
            btnReload.Click += (s, e) => loadData();
            f.Load += (s, e) => loadData();

            return f;
        }

        private static DataTable QueryRichTableData(string formName)
        {
            string connStr = GetConnectionString();
            try
            {
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string lower = formName.ToLower();
                    string query = "";

                    if (lower.Contains("công nợ khách hàng"))
                    {
                        query = @"
                            SELECT FIRST 50 H.SOHD AS ""Số phiếu"", H.NGAY AS ""Ngày"", K.NAME AS ""Khách hàng"", H.TONGCONG AS ""Tổng tiền"", H.CONGNO AS ""Còn nợ"", H.NOTE AS ""Ghi chú""
                            FROM TDONHANG H
                            LEFT JOIN DKHACHHANG K ON H.DKHACHHANGID = K.ID
                            ORDER BY H.NGAY DESC";
                    }
                    else if (lower.Contains("công nợ nhà cung cấp"))
                    {
                        query = @"
                            SELECT FIRST 50 N.SOPHIEU AS ""Số phiếu"", N.NGAY AS ""Ngày"", C.NAME AS ""Nhà cung cấp"", N.TONGTIEN AS ""Tổng tiền"", N.NOTE AS ""Ghi chú""
                            FROM TPHIEUNHAPKHO N
                            LEFT JOIN DNHACUNGCAP C ON N.DNHACUNGCAPID = C.ID
                            ORDER BY N.NGAY DESC";
                    }
                    else if (lower.Contains("phiếu chi"))
                    {
                        query = @"
                            SELECT FIRST 50 SOPHIEU AS ""Số phiếu"", NGAY AS ""Ngày"", SOTIEN AS ""Số tiền chi"", LYDO AS ""Lý do chi"", NGUOINHAN AS ""Người nhận""
                            FROM TTHUCHI
                            WHERE SOTIEN < 0 OR LOAI = 1
                            ORDER BY NGAY DESC";
                    }
                    else if (lower.Contains("phiếu thu"))
                    {
                        query = @"
                            SELECT FIRST 50 SOPHIEU AS ""Số phiếu"", NGAY AS ""Ngày"", SOTIEN AS ""Số tiền thu"", LYDO AS ""Lý do thu"", NGUOINOP AS ""Người nộp""
                            FROM TTHUCHI
                            WHERE SOTIEN >= 0 OR LOAI = 0
                            ORDER BY NGAY DESC";
                    }
                    else
                    {
                        string tableName = GetTableNameForForm(formName);
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            query = $"SELECT FIRST 50 * FROM {tableName}";
                        }
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        using (FbDataAdapter da = new FbDataAdapter(query, conn))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        private static string GetTableNameForForm(string formName)
        {
            string lower = formName.ToLower();
            if (lower.Contains("mặt hàng")) return "DMATHANG";
            if (lower.Contains("bàn")) return "DBAN";
            if (lower.Contains("khách hàng")) return "DKHACHHANG";
            if (lower.Contains("nhân viên")) return "DNHANVIEN";
            if (lower.Contains("kho")) return "DKHOHANG";
            if (lower.Contains("nhà cung cấp")) return "DNHACUNGCAP";
            if (lower.Contains("phiếu chi") || lower.Contains("phiếu thu") || lower.Contains("thu chi")) return "TTHUCHI";
            if (lower.Contains("bảng giá")) return "DBANGGIA";
            if (lower.Contains("đơn hàng") || lower.Contains("hóa đơn") || lower.Contains("công nợ")) return "TDONHANG";
            return null;
        }

        private static DataTable QueryTableData(string tableName)
        {
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = $"SELECT FIRST 50 * FROM {tableName}";
                    using (FbDataAdapter da = new FbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<FormModel> LoadAllForms(string dbPath = null)
        {
            List<FormModel> list = new List<FormModel>();
            string connStr = GetConnectionString(dbPath);

            try
            {
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT F.ID, F.NAME, F.CLASSNAME, F.FORMTYPE, F.LOAI, F.STABLEDESCID, F.SFUNCTIONID, F.NOTEMPLATE, 
                                            F.CODE, F.DESIGNCODE, F.AELAYOUT, F.CLIENTCODE, F.SERVERCODE, 
                                            F.IMAGE32 AS IMG32, I.IMAGE AS SIMG 
                                     FROM SFORM F 
                                     LEFT JOIN SIMAGE I ON F.SIMAGEID = I.ID 
                                     ORDER BY F.NAME";

                    using (FbCommand cmd = new FbCommand(query, conn))
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FormModel form = new FormModel
                            {
                                Id = reader["ID"]?.ToString(),
                                Name = reader["NAME"]?.ToString(),
                                ClassName = reader["CLASSNAME"]?.ToString(),
                                FormType = reader["FORMTYPE"] != DBNull.Value ? Convert.ToInt32(reader["FORMTYPE"]) : 0,
                                Loai = reader["LOAI"] != DBNull.Value ? Convert.ToInt32(reader["LOAI"]) : 0,
                                STableDescId = reader["STABLEDESCID"]?.ToString(),
                                SFunctionId = reader["SFUNCTIONID"]?.ToString(),
                                BillCode = reader["NOTEMPLATE"]?.ToString(),
                                Code = ReadBlobString(reader, "CODE"),
                                DesignCode = ReadBlobString(reader, "DESIGNCODE"),
                                AeLayout = ReadBlobString(reader, "AELAYOUT"),
                                ClientCode = ReadBlobString(reader, "CLIENTCODE"),
                                ServerCode = ReadBlobString(reader, "SERVERCODE"),
                                ImageBytes = ReadBlobBytes(reader, "IMG32") ?? ReadBlobBytes(reader, "SIMG")
                            };
                            list.Add(form);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error reading SFORM: " + ex.Message);
            }

            return list;
        }

        public class DbTableItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public override string ToString() => !string.IsNullOrEmpty(Description) ? $"{Name} ({Description})" : Name;
        }

        public class DbFunctionItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        public class DbFormTypeItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        public static List<DbFormTypeItem> LoadFormTypeItems()
        {
            List<DbFormTypeItem> list = new List<DbFormTypeItem>();
            try
            {
                foreach (No1Lib.Sys.FORM_TYPE type in Enum.GetValues(typeof(No1Lib.Sys.FORM_TYPE)))
                {
                    int id = (int)type;
                    string name = GetFormTypeName(type);
                    list.Add(new DbFormTypeItem { Id = id, Name = name });
                }
            }
            catch
            {
                list.Add(new DbFormTypeItem { Id = 0, Name = "Thêm sửa" });
                list.Add(new DbFormTypeItem { Id = 1, Name = "Quản trị" });
                list.Add(new DbFormTypeItem { Id = 6, Name = "Custom Form" });
            }
            return list;
        }

        public static string GetFormTypeName(No1Lib.Sys.FORM_TYPE type)
        {
            switch (type)
            {
                case No1Lib.Sys.FORM_TYPE.THEM_SUA: return "Thêm sửa";
                case No1Lib.Sys.FORM_TYPE.QUAN_TRI: return "Quản trị";
                case No1Lib.Sys.FORM_TYPE.CONG_NO_TRU_DUOI: return "Công nợ trừ đuôi";
                case No1Lib.Sys.FORM_TYPE.CONG_NO_THEO_DON: return "Công nợ theo hóa đơn";
                case No1Lib.Sys.FORM_TYPE.TON_QUY: return "Tồn quỹ";
                case No1Lib.Sys.FORM_TYPE.CUSTOM_CONTROL: return "Custom Control";
                case No1Lib.Sys.FORM_TYPE.CUSTOM_FORM: return "Custom Form";
                case No1Lib.Sys.FORM_TYPE.TON_KHO: return "Tồn kho";
                case No1Lib.Sys.FORM_TYPE.THEM_SUA_KO_THEO_LOAI: return "Thêm sửa không theo loại";
                case No1Lib.Sys.FORM_TYPE.TON_QUY_TAB: return "Tồn quỹ (tab)";
                case No1Lib.Sys.FORM_TYPE.TON_NHIEU_KHO: return "Tồn nhiều kho";
                case No1Lib.Sys.FORM_TYPE.CUSTOM_CLASS: return "Custom Class";
                default: return type.ToString();
            }
        }

        public static List<DbTableItem> LoadTableDescItems()
        {
            List<DbTableItem> list = new List<DbTableItem>();
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT ID, NAME, DESCRIPTION FROM STABLEDESC ORDER BY COALESCE(NULLIF(DESCRIPTION, ''), NAME) ASC";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string tId = rdr["ID"]?.ToString()?.Trim();
                            string tName = rdr["NAME"]?.ToString()?.Trim();
                            string tDesc = rdr["DESCRIPTION"] != DBNull.Value ? rdr["DESCRIPTION"]?.ToString()?.Trim() : null;
                            if (!string.IsNullOrEmpty(tName))
                            {
                                list.Add(new DbTableItem { Id = tId, Name = tName, Description = tDesc });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadTableDescItems error: " + ex.Message);
            }
            return list;
        }

        public static List<DbFunctionItem> LoadFunctionItems()
        {
            List<DbFunctionItem> list = new List<DbFunctionItem>();
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT ID, NAME FROM SFUNCTION ORDER BY SORTORDER, NAME ASC";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string fId = rdr["ID"]?.ToString()?.Trim();
                            string fName = rdr["NAME"] != DBNull.Value ? rdr["NAME"]?.ToString()?.Trim() : null;
                            if (!string.IsNullOrEmpty(fName))
                            {
                                list.Add(new DbFunctionItem { Id = fId, Name = fName });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadFunctionItems error: " + ex.Message);
            }
            return list;
        }

        public static byte[] ReadBlobBytes(FbDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                if (reader.IsDBNull(ordinal)) return null;

                byte[] buffer = (byte[])reader.GetValue(ordinal);
                return (buffer != null && buffer.Length > 0) ? buffer : null;
            }
            catch
            {
                return null;
            }
        }

        public static byte[] ReadBlobBytes(DataRow row, string columnName)
        {
            try
            {
                if (row == null || !row.Table.Columns.Contains(columnName) || row[columnName] == DBNull.Value) return null;
                byte[] buffer = row[columnName] as byte[];
                return (buffer != null && buffer.Length > 0) ? buffer : null;
            }
            catch
            {
                return null;
            }
        }

        private static string ReadBlobString(FbDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                if (reader.IsDBNull(ordinal)) return string.Empty;

                byte[] buffer = (byte[])reader.GetValue(ordinal);
                if (buffer == null || buffer.Length == 0) return string.Empty;

                return Encoding.UTF8.GetString(buffer);
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string UpdateAeLayoutFromForm(string originalAeLayoutXml, Form form)
        {
            if (form == null) return originalAeLayoutXml;

            try
            {
                string wrappedXml = string.IsNullOrEmpty(originalAeLayoutXml) ? "" : originalAeLayoutXml.Trim();
                if (string.IsNullOrEmpty(wrappedXml))
                {
                    wrappedXml = $"<Root><Object type=\"No1Lib.Sys.No1Form, No1Lib.Sys\" name=\"{form.Name ?? "No1Form1"}\"><Property name=\"ClientSize\">{form.Width}, {form.Height}</Property><Property name=\"Size\">{form.Width}, {form.Height}</Property></Object></Root>";
                }
                else if (!wrappedXml.StartsWith("<Root>") && !wrappedXml.StartsWith("<?xml"))
                {
                    wrappedXml = $"<Root>{wrappedXml}</Root>";
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(wrappedXml);

                XmlNodeList objectNodes = doc.SelectNodes("//Object");
                if (objectNodes != null && objectNodes.Count > 0)
                {
                    XmlNode rootNode = null;
                    foreach (XmlNode n in objectNodes)
                    {
                        string typeAttr = n.Attributes["type"]?.Value ?? "";
                        if (typeAttr.ToLower().Contains("form") || typeAttr.ToLower().Contains("usercontrol"))
                        {
                            rootNode = n;
                            break;
                        }
                    }
                    if (rootNode == null) rootNode = objectNodes[0];

                    SetOrUpdateXmlProperty(doc, rootNode, "ClientSize", $"{form.Width}, {form.Height}");
                    SetOrUpdateXmlProperty(doc, rootNode, "Size", $"{form.Width}, {form.Height}");

                    // Collect ALL controls recursively throughout entire form hierarchy
                    Dictionary<string, Control> allControlsMap = new Dictionary<string, Control>(StringComparer.OrdinalIgnoreCase);
                    CollectAllFormControlsRecursive(form, allControlsMap);

                    // Update properties for every XML object node
                    foreach (XmlNode objNode in objectNodes)
                    {
                        string objName = objNode.Attributes["name"]?.Value;
                        if (!string.IsNullOrEmpty(objName) && allControlsMap.TryGetValue(objName, out Control ctrl))
                        {
                            SetOrUpdateXmlProperty(doc, objNode, "Location", $"{ctrl.Left}, {ctrl.Top}");
                            SetOrUpdateXmlProperty(doc, objNode, "Size", $"{ctrl.Width}, {ctrl.Height}");
                            SetOrUpdateXmlProperty(doc, objNode, "Anchor", ctrl.Anchor.ToString());
                            if (ctrl.Text != null)
                            {
                                SetOrUpdateXmlProperty(doc, objNode, "Text", ctrl.Text);
                            }
                        }
                    }
                }

                string resultXml = doc.OuterXml.Replace("<Root>", "").Replace("</Root>", "").Trim();
                return resultXml;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateAeLayoutFromForm error: " + ex.Message);
                return originalAeLayoutXml;
            }
        }

        private static void SetOrUpdateXmlProperty(XmlDocument doc, XmlNode objectNode, string propName, string propValue)
        {
            if (objectNode == null) return;
            XmlNode propNode = objectNode.SelectSingleNode($"./Property[@name='{propName}']");
            if (propNode == null)
            {
                XmlElement elem = doc.CreateElement("Property");
                elem.SetAttribute("name", propName);
                elem.InnerText = propValue;
                objectNode.AppendChild(elem);
            }
            else
            {
                propNode.InnerText = propValue;
            }
        }

        private static void CollectAllFormControlsRecursive(Control parent, Dictionary<string, Control> map)
        {
            if (parent == null) return;

            if (!string.IsNullOrEmpty(parent.Name) && !map.ContainsKey(parent.Name))
            {
                map[parent.Name] = parent;
            }

            if (parent is SplitContainer sc)
            {
                CollectAllFormControlsRecursive(sc.Panel1, map);
                CollectAllFormControlsRecursive(sc.Panel2, map);
            }
            else if (parent is TabControl tc)
            {
                foreach (TabPage tp in tc.TabPages)
                {
                    CollectAllFormControlsRecursive(tp, map);
                }
            }

            if (parent.Controls != null && parent.Controls.Count > 0)
            {
                foreach (Control child in parent.Controls)
                {
                    CollectAllFormControlsRecursive(child, map);
                }
            }
        }

        public static bool SaveFormModelFull(FormModel model, bool isCreateMode)
        {
            if (model == null) return false;

            List<string> targetDbs = new List<string>();
            string activeDb = GetConnectionString();
            targetDbs.Add(activeDb);

            string mainDbPath = @"D:\QuanLyNhaHang\Database\mainTanAnPhat.fdb";
            string xDbPath = @"D:\QuanLyNhaHang\Database\x.fdb";

            if (System.IO.File.Exists(mainDbPath))
            {
                string mainConnStr = GetConnectionString(mainDbPath);
                if (!targetDbs.Contains(mainConnStr)) targetDbs.Add(mainConnStr);
            }
            if (System.IO.File.Exists(xDbPath))
            {
                string xConnStr = GetConnectionString(xDbPath);
                if (!targetDbs.Contains(xConnStr)) targetDbs.Add(xConnStr);
            }

            byte[] codeBytes = !string.IsNullOrEmpty(model.Code) ? Encoding.UTF8.GetBytes(model.Code) : null;
            byte[] serverBytes = !string.IsNullOrEmpty(model.ServerCode) ? Encoding.UTF8.GetBytes(model.ServerCode) : null;
            byte[] clientBytes = !string.IsNullOrEmpty(model.ClientCode) ? Encoding.UTF8.GetBytes(model.ClientCode) : null;
            byte[] aeBytes = !string.IsNullOrEmpty(model.AeLayout) ? Encoding.UTF8.GetBytes(model.AeLayout) : null;
            byte[] designBytes = !string.IsNullOrEmpty(model.DesignCode) ? Encoding.UTF8.GetBytes(model.DesignCode) : null;

            bool overallSuccess = false;
            foreach (string connStr in targetDbs)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(connStr))
                    {
                        conn.Open();
                        bool exists = false;
                        string checkSql = "SELECT COUNT(*) FROM SFORM WHERE ID = @Id OR LOWER(NAME) = LOWER(@Name)";
                        using (FbCommand chkCmd = new FbCommand(checkSql, conn))
                        {
                            chkCmd.Parameters.AddWithValue("@Id", model.Id ?? "");
                            chkCmd.Parameters.AddWithValue("@Name", model.Name ?? "");
                            exists = Convert.ToInt32(chkCmd.ExecuteScalar()) > 0;
                        }

                        if (!exists && isCreateMode)
                        {
                            string insertSql = @"INSERT INTO SFORM (ID, NAME, CLASSNAME, FORMTYPE, LOAI, STABLEDESCID, SFUNCTIONID, NOTEMPLATE, IMAGE32, CODE, DESIGNCODE, AELAYOUT, TIMECREATED, TIMEMODIFIED, STATUS, AUTOID, USERCREATEDID, USERMODIFIEDID)
                                                 VALUES (@Id, @Name, @ClassName, @FormType, @Loai, @STableDescId, @SFunctionId, @NoTemplate, @Image32, @Code, @DesignCode, @AeLayout, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 30, 
                                                 (SELECT COALESCE(MAX(AUTOID), 0) + 1 FROM SFORM), '4f1466a0-0756-4ba9-afa8-053b96ca7569', '4f1466a0-0756-4ba9-afa8-053b96ca7569')";

                            using (FbCommand cmd = new FbCommand(insertSql, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id", model.Id);
                                cmd.Parameters.AddWithValue("@Name", (object)model.Name ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@ClassName", (object)model.ClassName ?? "");
                                cmd.Parameters.AddWithValue("@FormType", model.FormType);
                                cmd.Parameters.AddWithValue("@Loai", model.Loai);
                                cmd.Parameters.AddWithValue("@STableDescId", (object)model.STableDescId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SFunctionId", (object)model.SFunctionId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@NoTemplate", (object)model.BillCode ?? "");
                                cmd.Parameters.Add("@Image32", FbDbType.Binary).Value = (object)model.ImageBytes ?? DBNull.Value;
                                cmd.Parameters.Add("@Code", FbDbType.Binary).Value = (object)codeBytes ?? DBNull.Value;
                                cmd.Parameters.Add("@DesignCode", FbDbType.Binary).Value = (object)designBytes ?? DBNull.Value;
                                cmd.Parameters.Add("@AeLayout", FbDbType.Binary).Value = (object)aeBytes ?? DBNull.Value;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string updateSql = @"UPDATE SFORM SET 
                                                    NAME = @Name,
                                                    CLASSNAME = @ClassName,
                                                    FORMTYPE = @FormType,
                                                    LOAI = @Loai,
                                                    STABLEDESCID = @STableDescId,
                                                    SFUNCTIONID = @SFunctionId,
                                                    NOTEMPLATE = @NoTemplate,
                                                    IMAGE32 = @Image32,
                                                    DESIGNCODE = @DesignCode,
                                                    USERMODIFIEDID = '4f1466a0-0756-4ba9-afa8-053b96ca7569',
                                                    TIMEMODIFIED = CURRENT_TIMESTAMP
                                                 WHERE ID = @Id OR LOWER(NAME) = LOWER(@Name)";

                            using (FbCommand cmd = new FbCommand(updateSql, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id", model.Id);
                                cmd.Parameters.AddWithValue("@Name", (object)model.Name ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@ClassName", (object)model.ClassName ?? "");
                                cmd.Parameters.AddWithValue("@FormType", model.FormType);
                                cmd.Parameters.AddWithValue("@Loai", model.Loai);
                                cmd.Parameters.AddWithValue("@STableDescId", (object)model.STableDescId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SFunctionId", (object)model.SFunctionId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@NoTemplate", (object)model.BillCode ?? "");
                                cmd.Parameters.Add("@Image32", FbDbType.Binary).Value = (object)model.ImageBytes ?? DBNull.Value;
                                cmd.Parameters.Add("@DesignCode", FbDbType.Binary).Value = (object)designBytes ?? DBNull.Value;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        try
                        {
                            string updateVerSql = "UPDATE SCONFIG SET TEXTVALUE = @VerGuid WHERE NAME = 'AppAutoVersion'";
                            using (FbCommand cmdVer = new FbCommand(updateVerSql, conn))
                            {
                                cmdVer.Parameters.AddWithValue("@VerGuid", Guid.NewGuid().ToString());
                                cmdVer.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        overallSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("SaveFormModelFull error for " + connStr + ": " + ex.Message);
                }
            }
            return overallSuccess;
        }

        public static bool SaveFormCode(string formId, string code, string serverCode, string clientCode, string aeLayout = null, string formName = null, string className = null, int? loai = null)
        {
            List<string> targetDbs = new List<string>();
            string activeDb = GetConnectionString();
            targetDbs.Add(activeDb);

            string mainDbPath = @"D:\QuanLyNhaHang\Database\mainTanAnPhat.fdb";
            string xDbPath = @"D:\QuanLyNhaHang\Database\x.fdb";

            if (System.IO.File.Exists(mainDbPath))
            {
                string mainConnStr = GetConnectionString(mainDbPath);
                if (!targetDbs.Contains(mainConnStr)) targetDbs.Add(mainConnStr);
            }
            if (System.IO.File.Exists(xDbPath))
            {
                string xConnStr = GetConnectionString(xDbPath);
                if (!targetDbs.Contains(xConnStr)) targetDbs.Add(xConnStr);
            }

            byte[] codeBytes = !string.IsNullOrEmpty(code) ? Encoding.UTF8.GetBytes(code) : null;
            byte[] serverBytes = !string.IsNullOrEmpty(serverCode) ? Encoding.UTF8.GetBytes(serverCode) : null;
            byte[] clientBytes = !string.IsNullOrEmpty(clientCode) ? Encoding.UTF8.GetBytes(clientCode) : null;
            byte[] aeBytes = !string.IsNullOrEmpty(aeLayout) ? Encoding.UTF8.GetBytes(aeLayout) : null;

            bool overallSuccess = false;
            foreach (string connStr in targetDbs)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(connStr))
                    {
                        conn.Open();
                        string sql = "UPDATE SFORM SET CODE = @Code, SERVERCODE = @ServerCode, CLIENTCODE = @ClientCode, TIMEMODIFIED = CURRENT_TIMESTAMP";
                        if (aeBytes != null)
                        {
                            sql += ", AELAYOUT = @AeLayout";
                        }
                        if (!string.IsNullOrWhiteSpace(className))
                        {
                            sql += ", CLASSNAME = @ClassName";
                        }
                        if (loai.HasValue)
                        {
                            sql += ", LOAI = @Loai";
                        }
                        sql += " WHERE (ID IS NOT NULL AND ID = @Id) OR (NAME IS NOT NULL AND LOWER(NAME) = LOWER(@Name))";

                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@Id", FbDbType.VarChar).Value = (object)formId ?? DBNull.Value;
                            cmd.Parameters.Add("@Name", FbDbType.VarChar).Value = (object)formName ?? DBNull.Value;
                            cmd.Parameters.Add("@Code", FbDbType.Binary).Value = (object)codeBytes ?? DBNull.Value;
                            cmd.Parameters.Add("@ServerCode", FbDbType.Binary).Value = (object)serverBytes ?? DBNull.Value;
                            cmd.Parameters.Add("@ClientCode", FbDbType.Binary).Value = (object)clientBytes ?? DBNull.Value;
                            if (aeBytes != null)
                            {
                                cmd.Parameters.Add("@AeLayout", FbDbType.Binary).Value = aeBytes;
                            }
                            if (!string.IsNullOrWhiteSpace(className))
                            {
                                cmd.Parameters.Add("@ClassName", FbDbType.VarChar).Value = className;
                            }
                            if (loai.HasValue)
                            {
                                cmd.Parameters.Add("@Loai", FbDbType.Integer).Value = loai.Value;
                            }
                            cmd.ExecuteNonQuery();
                        }

                        try
                        {
                            string updateVerSql = "UPDATE SCONFIG SET TEXTVALUE = @VerGuid WHERE NAME = 'AppAutoVersion'";
                            using (FbCommand cmdVer = new FbCommand(updateVerSql, conn))
                            {
                                cmdVer.Parameters.AddWithValue("@VerGuid", Guid.NewGuid().ToString());
                                cmdVer.ExecuteNonQuery();
                            }
                        }
                        catch { }
                    }
                    overallSuccess = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("SaveFormCode error for " + connStr + ": " + ex.Message);
                }
            }
            return overallSuccess;
        }

        public static bool DeleteFormFromDb(string formId, string formName)
        {
            List<string> targetDbs = new List<string> { GetConnectionString() };
            string xConnStr = GetConnectionString(@"D:\QuanLyNhaHang\Database\x.fdb");
            if (!targetDbs.Contains(xConnStr)) targetDbs.Add(xConnStr);
            string mainConnStr = GetConnectionString(@"D:\QuanLyNhaHang\Database\mainTanAnPhat.fdb");
            if (!targetDbs.Contains(mainConnStr)) targetDbs.Add(mainConnStr);

            bool overallSuccess = false;
            foreach (string connStr in targetDbs)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(connStr))
                    {
                        conn.Open();
                        string sql = "DELETE FROM SFORM WHERE (ID IS NOT NULL AND ID = @Id) OR (NAME IS NOT NULL AND LOWER(NAME) = LOWER(@Name))";
                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@Id", FbDbType.VarChar).Value = (object)formId ?? DBNull.Value;
                            cmd.Parameters.Add("@Name", FbDbType.VarChar).Value = (object)formName ?? DBNull.Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    overallSuccess = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("DeleteFormFromDb error for " + connStr + ": " + ex.Message);
                }
            }
            return overallSuccess;
        }

        public static bool ClearFormLayoutInDb(string formId, string formName)
        {
            List<string> targetDbs = new List<string> { GetConnectionString() };
            string xConnStr = GetConnectionString(@"D:\QuanLyNhaHang\Database\x.fdb");
            if (!targetDbs.Contains(xConnStr)) targetDbs.Add(xConnStr);
            string mainConnStr = GetConnectionString(@"D:\QuanLyNhaHang\Database\mainTanAnPhat.fdb");
            if (!targetDbs.Contains(mainConnStr)) targetDbs.Add(mainConnStr);

            bool overallSuccess = false;
            foreach (string connStr in targetDbs)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(connStr))
                    {
                        conn.Open();
                        string sql = "UPDATE SFORM SET AELAYOUT = NULL, TIMEMODIFIED = CURRENT_TIMESTAMP WHERE (ID IS NOT NULL AND ID = @Id) OR (NAME IS NOT NULL AND LOWER(NAME) = LOWER(@Name))";
                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@Id", FbDbType.VarChar).Value = (object)formId ?? DBNull.Value;
                            cmd.Parameters.Add("@Name", FbDbType.VarChar).Value = (object)formName ?? DBNull.Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    overallSuccess = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("ClearFormLayoutInDb error for " + connStr + ": " + ex.Message);
                }
            }
            return overallSuccess;
        }
        public static Form ParseAeLayoutToForm(string aeLayoutXml, string formTitle = "")
        {
            Form mainForm = new Form
            {
                Text = formTitle,
                Size = new Size(1024, 545),
                BackColor = Color.White
            };

            if (string.IsNullOrEmpty(aeLayoutXml)) return mainForm;

            try
            {
                string wrappedXml = aeLayoutXml.Trim();
                if (!wrappedXml.StartsWith("<Root>") && !wrappedXml.StartsWith("<?xml"))
                {
                    wrappedXml = $"<Root>{wrappedXml}</Root>";
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(wrappedXml);

                XmlNodeList objectNodes = doc.SelectNodes("//Object");
                if (objectNodes == null || objectNodes.Count == 0) return mainForm;

                Dictionary<string, Control> controlMap = new Dictionary<string, Control>(StringComparer.OrdinalIgnoreCase);
                Dictionary<string, XmlNode> nodeMap = new Dictionary<string, XmlNode>(StringComparer.OrdinalIgnoreCase);
                Dictionary<string, List<string>> childrenMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
                Dictionary<string, DataGridViewColumn> columnMap = new Dictionary<string, DataGridViewColumn>(StringComparer.OrdinalIgnoreCase);
                Dictionary<string, ToolStripItem> itemMap = new Dictionary<string, ToolStripItem>(StringComparer.OrdinalIgnoreCase);

                Control rootFormCtrl = null;

                // Pass 1: Instantiate controls, columns, & toolstrip items
                foreach (XmlNode node in objectNodes)
                {
                    string name = node.Attributes["name"]?.Value;
                    string typeName = node.Attributes["type"]?.Value;

                    if (string.IsNullOrEmpty(name)) continue;
                    nodeMap[name] = node;

                    string lowerType = typeName != null ? typeName.ToLower() : "";

                    if (lowerType.Contains("column") || name.StartsWith("col", StringComparison.OrdinalIgnoreCase))
                    {
                        string headerText = name;
                        XmlNode textNode = node.SelectSingleNode("./Property[@name='HeaderText']");
                        if (textNode != null && !string.IsNullOrEmpty(textNode.InnerText))
                        {
                            headerText = textNode.InnerText.Trim();
                        }
                        DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
                        {
                            Name = name,
                            HeaderText = headerText
                        };
                        columnMap[name] = col;
                        continue;
                    }

                    if (lowerType.Contains("toolstripbutton") || lowerType.Contains("tsbutton"))
                    {
                        string btnText = name;
                        XmlNode textNode = node.SelectSingleNode("./Property[@name='Text']");
                        if (textNode != null && !string.IsNullOrEmpty(textNode.InnerText)) btnText = textNode.InnerText.Trim();

                        ToolStripButton tsb = new ToolStripButton(btnText) { Name = name };
                        itemMap[name] = tsb;
                        continue;
                    }
                    if (lowerType.Contains("toolstripseparator"))
                    {
                        ToolStripSeparator sep = new ToolStripSeparator { Name = name };
                        itemMap[name] = sep;
                        continue;
                    }
                    if (lowerType.Contains("toolstriplabel") || lowerType.Contains("tslabel"))
                    {
                        string lblText = name;
                        XmlNode textNode = node.SelectSingleNode("./Property[@name='Text']");
                        if (textNode != null && !string.IsNullOrEmpty(textNode.InnerText)) lblText = textNode.InnerText.Trim();

                        ToolStripLabel tsl = new ToolStripLabel(lblText) { Name = name };
                        itemMap[name] = tsl;
                        continue;
                    }

                    Control ctrl = CreateControlFromType(typeName, name);
                    if (ctrl == null) continue;

                    List<string> childRefs = new List<string>();
                    XmlNodeList refNodes = node.SelectNodes("./Reference | .//Item/Reference");
                    if (refNodes != null)
                    {
                        foreach (XmlNode r in refNodes)
                        {
                            string refName = r.Attributes["name"]?.Value;
                            if (!string.IsNullOrEmpty(refName)) childRefs.Add(refName);
                        }
                    }
                    childrenMap[name] = childRefs;

                    ApplyXmlProperties(ctrl, node);
                    controlMap[name] = ctrl;

                    if (rootFormCtrl == null && (lowerType.Contains("form") || lowerType.Contains("usercontrol")))
                    {
                        rootFormCtrl = ctrl;
                    }
                }

                // Pass 2: Connect Parent-Child & Add Columns/Items to Containers
                HashSet<Control> hasParent = new HashSet<Control>();

                foreach (var kvp in childrenMap)
                {
                    string parentName = kvp.Key;
                    if (controlMap.TryGetValue(parentName, out Control parentCtrl))
                    {
                        XmlNode parentNode = nodeMap.ContainsKey(parentName) ? nodeMap[parentName] : null;

                        foreach (string childName in kvp.Value)
                        {
                            if (columnMap.TryGetValue(childName, out DataGridViewColumn colObj))
                            {
                                if (parentCtrl is DataGridView dgv)
                                {
                                    if (!dgv.Columns.Contains(colObj.Name))
                                    {
                                        dgv.Columns.Add(colObj);
                                    }
                                }
                                continue;
                            }

                            if (parentCtrl is ToolStrip ts)
                            {
                                if (itemMap.TryGetValue(childName, out ToolStripItem tsi))
                                {
                                    ts.Items.Add(tsi);
                                    continue;
                                }
                                else if (controlMap.TryGetValue(childName, out Control cBtn))
                                {
                                    ToolStripButton tsb = new ToolStripButton(cBtn.Text != null ? cBtn.Text : cBtn.Name) { Name = cBtn.Name };
                                    ts.Items.Add(tsb);
                                    continue;
                                }
                            }

                            if (parentCtrl is TabControl tc)
                            {
                                if (controlMap.TryGetValue(childName, out Control childCtrl))
                                {
                                    if (childCtrl is TabPage tabPg)
                                    {
                                        tc.TabPages.Add(tabPg);
                                        hasParent.Add(tabPg);
                                    }
                                    else
                                    {
                                        TabPage newTp = new TabPage(!string.IsNullOrEmpty(childCtrl.Text) ? childCtrl.Text : childCtrl.Name);
                                        childCtrl.Dock = DockStyle.Fill;
                                        newTp.Controls.Add(childCtrl);
                                        tc.TabPages.Add(newTp);
                                        hasParent.Add(childCtrl);
                                    }
                                }
                                continue;
                            }

                            if (parentCtrl is TabPage targetTabPage)
                            {
                                if (controlMap.TryGetValue(childName, out Control childCtrl))
                                {
                                    targetTabPage.Controls.Add(childCtrl);
                                    childCtrl.BringToFront();
                                    hasParent.Add(childCtrl);
                                }
                                continue;
                            }

                            if (controlMap.TryGetValue(childName, out Control cCtrl) && cCtrl != parentCtrl)
                            {
                                if (parentCtrl is SplitContainer sc)
                                {
                                    // Check if child is inside Panel2
                                    XmlNode p2Node = parentNode != null ? parentNode.SelectSingleNode(".//Property[@name='Panel2']") : null;
                                    bool inPanel2 = p2Node != null && p2Node.SelectSingleNode($".//Reference[@name='{childName}']") != null;

                                    if (inPanel2)
                                    {
                                        sc.Panel2.Controls.Add(cCtrl);
                                    }
                                    else
                                    {
                                        sc.Panel1.Controls.Add(cCtrl);
                                    }
                                }
                                else
                                {
                                    parentCtrl.Controls.Add(cCtrl);
                                }
                                cCtrl.BringToFront();
                                hasParent.Add(cCtrl);
                            }
                        }
                    }
                }

                // Pass 3: Arrange stacked controls inside SplitContainer Panel2 in correct top-to-bottom XML order
                foreach (Control ctrl in controlMap.Values)
                {
                    if (ctrl is SplitContainer sc && sc.Panel2.Controls.Count > 0)
                    {
                        if (sc.Tag is int customDist && customDist > 10)
                        {
                            try { sc.SplitterDistance = customDist; } catch { }
                        }
                        else
                        {
                            sc.SplitterDistance = Math.Max(380, sc.Width / 2);
                        }

                        List<Control> p2Controls = new List<Control>();
                        foreach (Control c in sc.Panel2.Controls) p2Controls.Add(c);

                        p2Controls.Sort((a, b) => a.Location.Y.CompareTo(b.Location.Y));

                        // Dock in reverse order so top item remains at top
                        for (int i = p2Controls.Count - 1; i >= 0; i--)
                        {
                            Control c = p2Controls[i];
                            if (c is DataGridView grid)
                            {
                                grid.Dock = DockStyle.Top;
                                grid.Height = Math.Max(65, c.Height > 30 ? c.Height : 75);
                                grid.BringToFront();
                            }
                            else if (c is TextBox txt)
                            {
                                txt.Dock = DockStyle.Top;
                                txt.Height = Math.Max(30, c.Height);
                                txt.BringToFront();
                            }
                        }
                    }
                }

                // Mount controls onto mainForm
                if (rootFormCtrl != null)
                {
                    rootFormCtrl.Dock = DockStyle.Fill;
                    mainForm.Controls.Add(rootFormCtrl);

                    if (rootFormCtrl.Size.Width > 200 && rootFormCtrl.Size.Height > 200)
                    {
                        mainForm.Size = rootFormCtrl.Size;
                    }
                    if (!string.IsNullOrEmpty(rootFormCtrl.Text))
                    {
                        mainForm.Text = rootFormCtrl.Text;
                    }
                }
                else
                {
                    foreach (var ctrl in controlMap.Values)
                    {
                        if (!hasParent.Contains(ctrl))
                        {
                            mainForm.Controls.Add(ctrl);
                            ctrl.BringToFront();
                        }
                    }
                }

                // Post-process buttons & panels for rich color styling
                foreach (Control c in controlMap.Values)
                {
                    if (c is Button btn)
                    {
                        btn.UseVisualStyleBackColor = false;
                        string btnTxt = btn.Text != null ? btn.Text.Trim() : "";
                        if (btnTxt.Equals("Đi làm", StringComparison.OrdinalIgnoreCase))
                        {
                            btn.BackColor = Color.Red;
                            btn.ForeColor = Color.White;
                            btn.FlatStyle = FlatStyle.Flat;
                        }
                        else if (btnTxt.Equals("Nghỉ có phép", StringComparison.OrdinalIgnoreCase))
                        {
                            btn.BackColor = Color.LimeGreen;
                            btn.ForeColor = Color.White;
                            btn.FlatStyle = FlatStyle.Flat;
                        }
                        else if (btnTxt.Equals("Nghỉ không phép", StringComparison.OrdinalIgnoreCase))
                        {
                            btn.BackColor = Color.Cyan;
                            btn.ForeColor = Color.Black;
                            btn.FlatStyle = FlatStyle.Flat;
                        }
                    }
                    else if (c is Panel pnl)
                    {
                        if (pnl.BackColor == Color.White || pnl.BackColor == Color.Transparent || pnl.BackColor == Color.Empty)
                        {
                            pnl.BackColor = Color.FromArgb(165, 196, 229);
                        }
                    }
                }
                Dictionary<string, string> formMetaProps = new Dictionary<string, string>();
                if (rootFormCtrl != null && nodeMap.TryGetValue(rootFormCtrl.Name, out XmlNode rootNode))
                {
                    string rootType = rootNode.Attributes["type"]?.Value ?? "";
                    if (rootType.Contains("UserControl"))
                    {
                        formMetaProps["IsUserControl"] = "true";
                    }

                    XmlNode minNode = rootNode.SelectSingleNode("./Property[@name='MinimizeBox']");
                    if (minNode != null) formMetaProps["MinimizeBox"] = minNode.InnerText.Trim();

                    XmlNode maxNode = rootNode.SelectSingleNode("./Property[@name='MaximizeBox']");
                    if (maxNode != null) formMetaProps["MaximizeBox"] = maxNode.InnerText.Trim();

                    XmlNode iconNode = rootNode.SelectSingleNode("./Property[@name='ShowIcon']");
                    if (iconNode != null) formMetaProps["ShowIcon"] = iconNode.InnerText.Trim();
                }

                if (nodeMap.ContainsKey("mapper") || aeLayoutXml.Contains("AeController") || aeLayoutXml.Contains("No1FieldMap"))
                {
                    formMetaProps["HasMapper"] = "true";
                }

                mainForm.Tag = formMetaProps;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ParseAeLayoutToForm error: " + ex.Message);
            }

            return mainForm;
        }

        private static Control CreateControlFromType(string typeName, string name)
        {
            if (string.IsNullOrEmpty(typeName)) typeName = "";
            string lowerType = typeName.ToLower();

            Control ctrl;

            if (lowerType.Contains("splitcontainer"))
            {
                ctrl = new SplitContainer { Dock = DockStyle.Fill };
            }
            else if (lowerType.Contains("navigator") || lowerType.Contains("tabcontrol"))
            {
                ctrl = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };
            }
            else if (lowerType.Contains("kryptonpage") || lowerType.Contains("tabpage"))
            {
                ctrl = new TabPage { Name = name, Text = name, BackColor = Color.White };
            }
            else if (lowerType.Contains("treetable") || lowerType.Contains("treegrid"))
            {
                ctrl = new TreeView { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F), ShowLines = true, ShowPlusMinus = true };
            }
            else if (lowerType.Contains("datagrid") || lowerType.Contains("grid"))
            {
                DataGridView dgv = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    BackgroundColor = Color.White,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false
                };
                ctrl = dgv;
            }
            else if (lowerType.Contains("button"))
            {
                ctrl = new Button { Size = new Size(80, 30), Text = name };
            }
            else if (lowerType.Contains("textbox"))
            {
                ctrl = new TextBox { Size = new Size(150, 22) };
            }
            else if (lowerType.Contains("label"))
            {
                ctrl = new Label { AutoSize = true, Text = name };
            }
            else if (lowerType.Contains("combobox"))
            {
                ctrl = new ComboBox { Size = new Size(130, 22) };
            }
            else if (lowerType.Contains("checkbox"))
            {
                ctrl = new CheckBox { AutoSize = true, Text = name };
            }
            else if (lowerType.Contains("numericupdown"))
            {
                ctrl = new NumericUpDown { Size = new Size(120, 22) };
            }
            else if (lowerType.Contains("datetimepicker") || lowerType.Contains("datepicker"))
            {
                ctrl = new DateTimePicker { Size = new Size(130, 22) };
            }
            else if (lowerType.Contains("toolstrip"))
            {
                ctrl = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden };
            }
            else if (lowerType.Contains("picturebox") || lowerType.Contains("image"))
            {
                ctrl = new PictureBox { Size = new Size(48, 48), SizeMode = PictureBoxSizeMode.Zoom };
            }
            else if (lowerType.Contains("radio"))
            {
                ctrl = new RadioButton { AutoSize = true, Text = name };
            }
            else if (lowerType.Contains("groupbox") || lowerType.Contains("group"))
            {
                ctrl = new GroupBox { Text = name };
            }
            else if (lowerType.Contains("form") || lowerType.Contains("usercontrol"))
            {
                ctrl = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            }
            else
            {
                ctrl = new Panel { BackColor = Color.Transparent };
            }

            ctrl.Name = name;
            return ctrl;
        }

        private static Color ParseXmlColor(string val)
        {
            if (string.IsNullOrEmpty(val)) return Color.Empty;
            val = val.Trim();
            if (string.Equals(val, "Transparent", StringComparison.OrdinalIgnoreCase)) return Color.Transparent;

            Color known = Color.FromName(val);
            if (known.IsKnownColor) return known;

            string[] parts = val.Split(',');
            if (parts.Length == 3 && int.TryParse(parts[0].Trim(), out int r) && int.TryParse(parts[1].Trim(), out int g) && int.TryParse(parts[2].Trim(), out int b))
            {
                return Color.FromArgb(Math.Max(0, Math.Min(255, r)), Math.Max(0, Math.Min(255, g)), Math.Max(0, Math.Min(255, b)));
            }
            if (parts.Length == 4 && int.TryParse(parts[0].Trim(), out int a) && int.TryParse(parts[1].Trim(), out int r2) && int.TryParse(parts[2].Trim(), out int g2) && int.TryParse(parts[3].Trim(), out int b2))
            {
                return Color.FromArgb(Math.Max(0, Math.Min(255, a)), Math.Max(0, Math.Min(255, r2)), Math.Max(0, Math.Min(255, g2)), Math.Max(0, Math.Min(255, b2)));
            }

            if (int.TryParse(val, out int argbInt))
            {
                return Color.FromArgb(argbInt);
            }

            if (val.StartsWith("#"))
            {
                try { return ColorTranslator.FromHtml(val); } catch { }
            }

            return Color.Empty;
        }

        private static Font ParseXmlFont(string fontStr)
        {
            if (string.IsNullOrEmpty(fontStr)) return null;
            try
            {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
                if (converter != null && converter.CanConvertFrom(typeof(string)))
                {
                    return (Font)converter.ConvertFromString(fontStr);
                }
            }
            catch { }

            try
            {
                string[] parts = fontStr.Split(',');
                if (parts.Length >= 2)
                {
                    string family = parts[0].Trim();
                    string sizeStr = parts[1].Replace("pt", "").Replace("px", "").Trim();
                    if (float.TryParse(sizeStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float sz))
                    {
                        FontStyle style = FontStyle.Regular;
                        if (fontStr.IndexOf("bold", StringComparison.OrdinalIgnoreCase) >= 0) style |= FontStyle.Bold;
                        if (fontStr.IndexOf("italic", StringComparison.OrdinalIgnoreCase) >= 0) style |= FontStyle.Italic;
                        return new Font(family, sz, style);
                    }
                }
            }
            catch { }

            return null;
        }

        private static void ApplyTextAlign(Control ctrl, string val)
        {
            if (string.IsNullOrEmpty(val)) return;
            val = val.Trim();

            if (ctrl is Label lbl)
            {
                if (Enum.TryParse(val, true, out ContentAlignment align)) lbl.TextAlign = align;
                else if (val.Equals("Right", StringComparison.OrdinalIgnoreCase)) lbl.TextAlign = ContentAlignment.MiddleRight;
                else if (val.Equals("Left", StringComparison.OrdinalIgnoreCase)) lbl.TextAlign = ContentAlignment.MiddleLeft;
                else if (val.Equals("Center", StringComparison.OrdinalIgnoreCase)) lbl.TextAlign = ContentAlignment.MiddleCenter;
            }
            else if (ctrl is Button btn)
            {
                if (Enum.TryParse(val, true, out ContentAlignment align)) btn.TextAlign = align;
                else if (val.Equals("Right", StringComparison.OrdinalIgnoreCase)) btn.TextAlign = ContentAlignment.MiddleRight;
                else if (val.Equals("Left", StringComparison.OrdinalIgnoreCase)) btn.TextAlign = ContentAlignment.MiddleLeft;
                else if (val.Equals("Center", StringComparison.OrdinalIgnoreCase)) btn.TextAlign = ContentAlignment.MiddleCenter;
            }
            else if (ctrl is TextBox txt)
            {
                if (val.Contains("Right")) txt.TextAlign = HorizontalAlignment.Right;
                else if (val.Contains("Center")) txt.TextAlign = HorizontalAlignment.Center;
                else if (val.Contains("Left")) txt.TextAlign = HorizontalAlignment.Left;
            }
            else if (ctrl is NumericUpDown num)
            {
                if (val.Contains("Right")) num.TextAlign = HorizontalAlignment.Right;
                else if (val.Contains("Center")) num.TextAlign = HorizontalAlignment.Center;
                else if (val.Contains("Left")) num.TextAlign = HorizontalAlignment.Left;
            }
        }

        private static void ApplyBorderStyle(Control ctrl, string val)
        {
            if (string.IsNullOrEmpty(val)) return;
            if (Enum.TryParse(val, true, out BorderStyle style))
            {
                if (ctrl is TextBox txt) txt.BorderStyle = style;
                else if (ctrl is Panel pnl) pnl.BorderStyle = style;
                else if (ctrl is Label lbl) lbl.BorderStyle = style;
            }
        }

        private static Image ParseBase64Image(string base64Str)
        {
            if (string.IsNullOrEmpty(base64Str)) return null;
            try
            {
                byte[] bytes = Convert.FromBase64String(base64Str.Trim());
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        private static void ApplyXmlProperties(Control ctrl, XmlNode node)
        {
            XmlNodeList propNodes = node.SelectNodes(".//Property");
            if (propNodes == null) return;

            foreach (XmlNode pNode in propNodes)
            {
                string pName = pNode.Attributes["name"]?.Value;
                string pVal = pNode.InnerText?.Trim();
                if (string.IsNullOrEmpty(pName) || string.IsNullOrEmpty(pVal)) continue;

                try
                {
                    if (pName.Equals("Text", StringComparison.OrdinalIgnoreCase))
                    {
                        ctrl.Text = pVal;
                    }
                    else if (pName.Equals("Image", StringComparison.OrdinalIgnoreCase) || pName.Equals("Icon", StringComparison.OrdinalIgnoreCase))
                    {
                        Image img = ParseBase64Image(pVal);
                        if (img != null)
                        {
                            if (ctrl is Button btn)
                            {
                                btn.Image = img;
                                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                                btn.ImageAlign = ContentAlignment.MiddleLeft;
                            }
                            else if (ctrl is PictureBox pic)
                            {
                                pic.Image = img;
                            }
                            else if (ctrl is Label lbl)
                            {
                                lbl.Image = img;
                                lbl.ImageAlign = ContentAlignment.MiddleLeft;
                            }
                        }
                    }
                    else if (pName.Equals("BackColor", StringComparison.OrdinalIgnoreCase))
                    {
                        Color c = ParseXmlColor(pVal);
                        if (!c.IsEmpty)
                        {
                            ctrl.BackColor = c;
                            if (ctrl is Button btn) btn.UseVisualStyleBackColor = false;
                            else if (ctrl is ButtonBase btnBase) btnBase.UseVisualStyleBackColor = false;
                        }
                    }
                    else if (pName.Equals("ForeColor", StringComparison.OrdinalIgnoreCase))
                    {
                        Color c = ParseXmlColor(pVal);
                        if (!c.IsEmpty) ctrl.ForeColor = c;
                    }
                    else if (pName.Equals("FlatStyle", StringComparison.OrdinalIgnoreCase))
                    {
                        if (ctrl is Button btn && Enum.TryParse(pVal, true, out FlatStyle fs))
                        {
                            btn.FlatStyle = fs;
                            btn.UseVisualStyleBackColor = false;
                        }
                    }
                    else if (pName.Equals("Font", StringComparison.OrdinalIgnoreCase))
                    {
                        Font f = ParseXmlFont(pVal);
                        if (f != null) ctrl.Font = f;
                    }
                    else if (pName.Equals("AlternatingRowsDefaultCellStyle", StringComparison.OrdinalIgnoreCase))
                    {
                        if (ctrl is DataGridView dgv)
                        {
                            XmlNode backNode = pNode.SelectSingleNode(".//Property[@name='BackColor']");
                            if (backNode != null)
                            {
                                Color c = ParseXmlColor(backNode.InnerText);
                                if (!c.IsEmpty) dgv.AlternatingRowsDefaultCellStyle.BackColor = c;
                            }
                        }
                    }
                    else if (pName.Equals("ColumnHeadersDefaultCellStyle", StringComparison.OrdinalIgnoreCase))
                    {
                        if (ctrl is DataGridView dgv)
                        {
                            XmlNode backNode = pNode.SelectSingleNode(".//Property[@name='BackColor']");
                            if (backNode != null)
                            {
                                Color c = ParseXmlColor(backNode.InnerText);
                                if (!c.IsEmpty)
                                {
                                    dgv.EnableHeadersVisualStyles = false;
                                    dgv.ColumnHeadersDefaultCellStyle.BackColor = c;
                                }
                            }
                        }
                    }
                    else if (pName.Equals("TextAlign", StringComparison.OrdinalIgnoreCase))
                    {
                        ApplyTextAlign(ctrl, pVal);
                    }
                    else if (pName.Equals("BorderStyle", StringComparison.OrdinalIgnoreCase))
                    {
                        ApplyBorderStyle(ctrl, pVal);
                    }
                    else if (pName.Equals("Dock", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Enum.TryParse(pVal, true, out DockStyle ds)) ctrl.Dock = ds;
                    }
                    else if (pName.Equals("Size", StringComparison.OrdinalIgnoreCase) || pName.Equals("ClientSize", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] parts = pVal.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int w) && int.TryParse(parts[1].Trim(), out int h))
                        {
                            ctrl.Size = new Size(w, h);
                        }
                    }
                    else if (pName.Equals("Location", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] parts = pVal.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int x) && int.TryParse(parts[1].Trim(), out int y))
                        {
                            ctrl.Location = new Point(x, y);
                        }
                    }
                    else if (pName.Equals("SplitterDistance", StringComparison.OrdinalIgnoreCase))
                    {
                        if (int.TryParse(pVal, out int dist) && dist > 10)
                        {
                            if (ctrl is SplitContainer sc)
                            {
                                sc.Tag = dist;
                                try { sc.SplitterDistance = dist; } catch { }
                            }
                        }
                    }
                    else if (pName.Equals("Orientation", StringComparison.OrdinalIgnoreCase))
                    {
                        if (ctrl is SplitContainer sc && Enum.TryParse(pVal, true, out Orientation ori))
                        {
                            sc.Orientation = ori;
                        }
                    }
                    else if (pName.Equals("Anchor", StringComparison.OrdinalIgnoreCase))
                    {
                        AnchorStyles anchor = AnchorStyles.None;
                        foreach (string part in pVal.Split(','))
                        {
                            if (Enum.TryParse(part.Trim(), true, out AnchorStyles a)) anchor |= a;
                        }
                        ctrl.Anchor = anchor;
                    }
                    else if (pName.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                    {
                        if (bool.TryParse(pVal, out bool en)) ctrl.Enabled = en;
                    }
                    else if (pName.Equals("Visible", StringComparison.OrdinalIgnoreCase))
                    {
                        if (bool.TryParse(pVal, out bool vis)) ctrl.Visible = vis;
                    }
                }
                catch { }
            }
        }
    }
}
