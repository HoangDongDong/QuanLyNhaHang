using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace QuanLyNhaHang.Services
{
    public class FormDesignerTonKhoService
    {
        public class ColConfig
        {
            public bool Checked { get; set; }
            public string Caption { get; set; }
            public string Condition { get; set; }
            public string Formula { get; set; }
            public string Sort { get; set; }
            public string Order { get; set; }
            public string Replace { get; set; }
        }

        public static void OpenDesignTab(FormModel model, TabControl tabMainContainer)
        {
            string tabTitle = $"Thiết kế - {model.Name}";
            foreach (TabPage existing in tabMainContainer.TabPages)
            {
                if (existing.Text == tabTitle)
                {
                    tabMainContainer.SelectedTab = existing;
                    return;
                }
            }

            TabPage tab = new TabPage(tabTitle);

            // 1. Top Action Toolbar
            ToolStrip tsAction = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(4, 2, 4, 2) };
            ToolStripButton btnSave = new ToolStripButton("💾 Cập nhật (Ctrl + S)");
            ToolStripButton btnAdd = new ToolStripButton("➕ Thêm");
            ToolStripButton btnEdit = new ToolStripButton("✏️ Sửa");
            ToolStripButton btnDelete = new ToolStripButton("❌ Xóa");
            ToolStripButton btnRefresh = new ToolStripButton("🔄 Cập nhật");

            tsAction.Items.AddRange(new ToolStripItem[] { btnSave, new ToolStripSeparator(), btnAdd, btnEdit, btnDelete, btnRefresh });

            // 2. Top Parameters Panel
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 85,
                BackColor = Color.FromArgb(235, 238, 242)
            };

            Label lblKho = new Label { Text = "Bảng kho:", Location = new Point(10, 8), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboKhoTable = new ComboBox { Location = new Point(80, 5), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };
            cboKhoTable.Items.Clear();
            var dbTableNames = LoadAllTableNamesFromDb();
            if (dbTableNames.Count > 0)
            {
                cboKhoTable.Items.AddRange(dbTableNames.ToArray());
            }

            Label lblNote = new Label
            {
                Text = "(Chú ý: Sử dụng @DKHOID và @MASTERID làm tham số trong việc lọc dữ liệu, các cột cần phải sắp xếp đúng thứ tự ở các view con để có thể tổng hợp - join giữa các bảng)",
                Location = new Point(10, 32),
                AutoSize = true,
                ForeColor = Color.DarkRed,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic)
            };

            Label lblCotNgay = new Label { Text = "Cột ngày:", Location = new Point(10, 56), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            TextBox txtCotNgay = new TextBox { Location = new Point(68, 53), Width = 110, Font = new Font("Segoe UI", 8.5F) };

            Label lblCotSlNhap = new Label { Text = "Cột sl nhập:", Location = new Point(185, 56), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            TextBox txtCotSlNhap = new TextBox { Location = new Point(255, 53), Width = 90, Font = new Font("Segoe UI", 8.5F) };

            Label lblCotSlXuat = new Label { Text = "Cột sl xuất:", Location = new Point(355, 56), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            TextBox txtCotSlXuat = new TextBox { Location = new Point(425, 53), Width = 90, Font = new Font("Segoe UI", 8.5F) };

            Label lblCotGiaBan = new Label { Text = "Cột giá bán:", Location = new Point(525, 56), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            TextBox txtCotGiaBan = new TextBox { Location = new Point(595, 53), Width = 90, Font = new Font("Segoe UI", 8.5F) };

            Label lblCotGiaVon = new Label { Text = "Cột giá vốn:", Location = new Point(695, 56), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            TextBox txtCotGiaVon = new TextBox { Location = new Point(765, 53), Width = 90, Font = new Font("Segoe UI", 8.5F) };

            pnlHeader.Controls.AddRange(new Control[] {
                lblKho, cboKhoTable, lblNote,
                lblCotNgay, txtCotNgay,
                lblCotSlNhap, txtCotSlNhap,
                lblCotSlXuat, txtCotSlXuat,
                lblCotGiaBan, txtCotGiaBan,
                lblCotGiaVon, txtCotGiaVon
            });

            // 3. Main Sub TabControl
            TabControl tcSub = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };
            TabPage tabMatHang = new TabPage("Mặt hàng");
            TabPage tabChiTiet = new TabPage("Chi tiết nhập - xuất");
            TabPage tabCode = new TabPage("Code");
            TabPage tabAspCode = new TabPage("Asp Code");
            TabPage tabJsCode = new TabPage("Js Code");

            // --- TAB 1 & 2: DATA GRIDS ---
            DataGridView dgvMatHang = CreateTonKhoTreeGrid();
            tabMatHang.Controls.Add(dgvMatHang);

            DataGridView dgvChiTiet = CreateTonKhoDetailGrid();
            tabChiTiet.Controls.Add(dgvChiTiet);

            // Determine if form has saved layout configuration
            bool hasSavedLayout = HasValidMasterLayout(model.AeLayout);

            if (hasSavedLayout)
            {
                int dkIdx = cboKhoTable.Items.IndexOf("DKHOHANG");
                if (dkIdx >= 0) cboKhoTable.SelectedIndex = dkIdx;

                txtCotNgay.Text = "'DONHANG_NGAY'";
                txtCotSlNhap.Text = "SLNHAP";
                txtCotSlXuat.Text = "SLXUAT";
                txtCotGiaBan.Text = "GIABAN";
                txtCotGiaVon.Text = "GIAVON";

                Dictionary<string, ColConfig> masterConfigMap = ParseMasterConfigLayout(model.AeLayout);
                LoadTonKhoTableTreeGridFromDb("DMATHANG", dgvMatHang, masterConfigMap, "Mặt hàng");
                LoadTonKhoDetailTableFromDb(dgvChiTiet);
            }
            else
            {
                // BRAND NEW / UNCONFIGURED FORM: EVERYTHING IS 100% BLANK!
                cboKhoTable.SelectedIndex = -1;
                txtCotNgay.Text = "";
                txtCotSlNhap.Text = "";
                txtCotSlXuat.Text = "";
                txtCotGiaBan.Text = "";
                txtCotGiaVon.Text = "";

                dgvMatHang.Rows.Clear();
                dgvChiTiet.Rows.Clear();
            }

            // Selection Event: When user selects a table from "Bảng kho:" dropdown
            cboKhoTable.SelectedIndexChanged += (s, e) =>
            {
                if (cboKhoTable.SelectedIndex >= 0)
                {
                    if (string.IsNullOrWhiteSpace(txtCotNgay.Text)) txtCotNgay.Text = "'DONHANG_NGAY'";
                    if (string.IsNullOrWhiteSpace(txtCotSlNhap.Text)) txtCotSlNhap.Text = "SLNHAP";
                    if (string.IsNullOrWhiteSpace(txtCotSlXuat.Text)) txtCotSlXuat.Text = "SLXUAT";
                    if (string.IsNullOrWhiteSpace(txtCotGiaBan.Text)) txtCotGiaBan.Text = "GIABAN";
                    if (string.IsNullOrWhiteSpace(txtCotGiaVon.Text)) txtCotGiaVon.Text = "GIAVON";

                    Dictionary<string, ColConfig> masterConfigMap = ParseMasterConfigLayout(model.AeLayout);
                    LoadTonKhoTableTreeGridFromDb("DMATHANG", dgvMatHang, masterConfigMap, "Mặt hàng");
                    LoadTonKhoDetailTableFromDb(dgvChiTiet);
                }
            };

            // --- CODE EDITORS ---
            string initialCode = (!string.IsNullOrWhiteSpace(model.Code) && model.Code.Contains("ITonKhoSupport"))
                ? model.Code
                : GenerateDefaultTonKhoHandlerCode(model.Name);

            FastColoredTextBoxNS.FastColoredTextBox txtCodeEditor = new FastColoredTextBoxNS.FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Language = FastColoredTextBoxNS.Language.CSharp,
                Font = new Font("Consolas", 10F),
                Text = initialCode
            };
            tabCode.Controls.Add(txtCodeEditor);

            string initialAspCode = (!string.IsNullOrWhiteSpace(model.ServerCode))
                ? model.ServerCode
                : GenerateDefaultTonKhoAspCode();

            FastColoredTextBoxNS.FastColoredTextBox txtAspCodeEditor = new FastColoredTextBoxNS.FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Language = FastColoredTextBoxNS.Language.CSharp,
                Font = new Font("Consolas", 10F),
                Text = initialAspCode
            };
            tabAspCode.Controls.Add(txtAspCodeEditor);

            FastColoredTextBoxNS.FastColoredTextBox txtJsCodeEditor = new FastColoredTextBoxNS.FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Language = FastColoredTextBoxNS.Language.JS,
                Font = new Font("Consolas", 10F),
                Text = string.IsNullOrEmpty(model.ClientCode) ? "" : model.ClientCode
            };
            tabJsCode.Controls.Add(txtJsCodeEditor);

            tcSub.TabPages.AddRange(new TabPage[] { tabMatHang, tabChiTiet, tabCode, tabAspCode, tabJsCode });

            // Save Action
            btnSave.Click += (s, e) =>
            {
                model.AeLayout = BuildTonKhoAeLayoutXml(dgvMatHang, dgvChiTiet);
                model.Code = txtCodeEditor.Text;
                model.ServerCode = txtAspCodeEditor.Text;
                model.ClientCode = txtJsCodeEditor.Text;

                DbFormService.SaveFormCode(model.Id, model.Code, model.ServerCode, model.ClientCode, model.AeLayout, model.Name);
                MessageBox.Show($"Đã cập nhật cấu trúc Form Tồn kho [{model.Name}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btnRefresh.Click += (s, e) =>
            {
                if (cboKhoTable.SelectedIndex >= 0)
                {
                    Dictionary<string, ColConfig> masterConfigMap = ParseMasterConfigLayout(model.AeLayout);
                    LoadTonKhoTableTreeGridFromDb("DMATHANG", dgvMatHang, masterConfigMap, "Mặt hàng");
                    LoadTonKhoDetailTableFromDb(dgvChiTiet);
                }
            };

            Panel pnlContainer = new Panel { Dock = DockStyle.Fill };
            pnlContainer.Controls.Add(tcSub);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Controls.Add(tsAction);

            tab.Controls.Add(pnlContainer);
            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;
        }

        private static bool HasValidMasterLayout(string aeLayoutXml)
        {
            if (string.IsNullOrWhiteSpace(aeLayoutXml)) return false;
            return aeLayoutXml.Contains("<MASTER>") || aeLayoutXml.Contains("<COLID>") || aeLayoutXml.Contains("<CHECKED>");
        }

        public static DataGridView CreateTonKhoTreeGrid()
        {
            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                RowHeadersWidth = 25,
                RowTemplate = { Height = 22 },
                GridColor = Color.FromArgb(235, 238, 242),
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                EnableHeadersVisualStyles = false
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 251);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn { HeaderText = "Dữ liệu", ReadOnly = true, Width = 320, MinimumWidth = 280 };
            DataGridViewTextBoxColumn colTitle = new DataGridViewTextBoxColumn { HeaderText = "Tiêu đề" };
            DataGridViewTextBoxColumn colSort = new DataGridViewTextBoxColumn { HeaderText = "Sắp xếp", Width = 65 };
            DataGridViewTextBoxColumn colParam = new DataGridViewTextBoxColumn { HeaderText = "Tham số", Width = 65 };
            DataGridViewTextBoxColumn colCond = new DataGridViewTextBoxColumn { HeaderText = "Điều kiện", Width = 90 };
            DataGridViewTextBoxColumn colFormula = new DataGridViewTextBoxColumn { HeaderText = "Công thức", Width = 90 };
            DataGridViewCheckBoxColumn colHide = new DataGridViewCheckBoxColumn { HeaderText = "Ẩn", Width = 50 };
            DataGridViewCheckBoxColumn colNoEdit = new DataGridViewCheckBoxColumn { HeaderText = "Ko sửa", Width = 55 };
            DataGridViewTextBoxColumn colReplace = new DataGridViewTextBoxColumn { HeaderText = "Thay thế", Width = 80 };
            DataGridViewTextBoxColumn colOrder = new DataGridViewTextBoxColumn { HeaderText = "Thứ tự", Width = 55 };
            DataGridViewTextBoxColumn colAlias = new DataGridViewTextBoxColumn { HeaderText = "Alias", Width = 65 };
            DataGridViewCheckBoxColumn colReq = new DataGridViewCheckBoxColumn { HeaderText = "Bắt buộc", Width = 65 };
            DataGridViewCheckBoxColumn colNoCol = new DataGridViewCheckBoxColumn { HeaderText = "Không tạo...", Width = 80 };

            dgv.Columns.AddRange(new DataGridViewColumn[] {
                colData, colTitle, colSort, colParam, colCond, colFormula,
                colHide, colNoEdit, colReplace, colOrder, colAlias, colReq, colNoCol
            });

            FormDesignerCongNoService.AttachTreeGridEvents(dgv);

            // Yellow Highlight Painting for "Thay thế" (Col 8) & "Thứ tự" (Col 9) to match Image 1
            dgv.CellPainting += (s, e) =>
            {
                if ((e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background);
                    using (Brush yellowBrush = new SolidBrush(Color.FromArgb(255, 255, 208)))
                    {
                        e.Graphics.FillRectangle(yellowBrush, e.CellBounds);
                    }
                    e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.Border);
                    e.Handled = true;
                }
            };

            return dgv;
        }

        public static DataGridView CreateTonKhoDetailGrid()
        {
            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                RowHeadersWidth = 25,
                RowTemplate = { Height = 22 },
                GridColor = Color.FromArgb(235, 238, 242),
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                EnableHeadersVisualStyles = false
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 251);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            DataGridViewTextBoxColumn colTable = new DataGridViewTextBoxColumn { HeaderText = "Bảng dữ liệu", Width = 200 };
            dgv.Columns.Add(colTable);

            // Custom Cell Painting for Row 0: Orange/Amber background matching Image 3!
            dgv.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground & ~DataGridViewPaintParts.Background);

                    Graphics g = e.Graphics;
                    Rectangle rect = e.CellBounds;

                    using (Brush b = new SolidBrush(Color.FromArgb(196, 118, 60)))
                    {
                        g.FillRectangle(b, rect);
                    }
                    TextRenderer.DrawText(g, e.Value?.ToString() ?? "", new Font("Segoe UI", 9F, FontStyle.Bold), new Point(rect.Left + 6, rect.Top + 4), Color.White);
                    g.DrawRectangle(Pens.LightGray, rect);
                    e.Handled = true;
                }
            };

            return dgv;
        }

        private static void LoadTonKhoDetailTableFromDb(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Rows.Add("TDONHANGCHITIET");
        }

        private static Dictionary<string, ColConfig> ParseMasterConfigLayout(string aeLayoutXml)
        {
            Dictionary<string, ColConfig> configDict = new Dictionary<string, ColConfig>();
            if (string.IsNullOrWhiteSpace(aeLayoutXml)) return configDict;

            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(aeLayoutXml);
                var masterNode = doc.SelectSingleNode("//DocumentElement/Data/MASTER");
                if (masterNode != null && !string.IsNullOrWhiteSpace(masterNode.InnerText))
                {
                    byte[] bytes = Convert.FromBase64String(masterNode.InnerText);
                    string innerXml = Encoding.UTF8.GetString(bytes);
                    System.Xml.XmlDocument masterDoc = new System.Xml.XmlDocument();
                    masterDoc.LoadXml(innerXml);
                    var dataNodes = masterDoc.SelectNodes("//DocumentElement/Data");
                    if (dataNodes != null)
                    {
                        foreach (System.Xml.XmlNode n in dataNodes)
                        {
                            string colId = n["COLID"]?.InnerText?.Trim() ?? n["colid"]?.InnerText?.Trim();
                            string caption = n["CAPTION"]?.InnerText?.Trim() ?? n["caption"]?.InnerText?.Trim();
                            string chkVal = n["CHECKED"]?.InnerText?.Trim()?.ToLower() ?? n["checked"]?.InnerText?.Trim()?.ToLower();
                            bool isChecked = chkVal == "true" || chkVal == "1";
                            string cond = n["CONDITION"]?.InnerText?.Trim();
                            string formula = n["FORMULA"]?.InnerText?.Trim();

                            ColConfig cfg = new ColConfig
                            {
                                Checked = isChecked,
                                Caption = caption,
                                Condition = cond,
                                Formula = formula
                            };

                            if (!string.IsNullOrEmpty(colId)) configDict[colId] = cfg;
                            if (!string.IsNullOrEmpty(caption)) configDict[caption] = cfg;
                        }
                    }
                }
            }
            catch { }
            return configDict;
        }

        private static void LoadTonKhoTableTreeGridFromDb(string tableName, DataGridView dgv, Dictionary<string, ColConfig> configMap, string customRootTitle = null)
        {
            dgv.Rows.Clear();
            if (string.IsNullOrEmpty(tableName)) return;

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT ID, DESCRIPTION FROM STABLEDESC WHERE UPPER(TRIM(NAME)) = UPPER(TRIM(@name))";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", tableName);
                        using (FbDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                string tableId = rdr[0]?.ToString()?.Trim();
                                string desc = rdr[1]?.ToString()?.Trim();

                                string rootText = !string.IsNullOrEmpty(customRootTitle)
                                    ? customRootTitle
                                    : (!string.IsNullOrEmpty(desc) ? desc : tableName);

                                FormDesignerCongNoService.TreeRowInfo rootNode = new FormDesignerCongNoService.TreeRowInfo
                                {
                                    NodeType = "ROOT",
                                    Level = 0,
                                    IsParent = true,
                                    IsExpanded = true,
                                    ScolId = null,
                                    NodeText = rootText,
                                    RefTableId = tableId,
                                    RawColName = tableName,
                                    IsChecked = false
                                };

                                int rootIdx = dgv.Rows.Add(rootText, "", "", "", "", "", false, false, "", "", "", false, false);
                                dgv.Rows[rootIdx].Tag = rootNode;
                                dgv.Rows[rootIdx].Cells[0].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                                List<int> childIndices = new List<int>();
                                LoadTonKhoChildColumns(conn, tableId, dgv, configMap, 1, childIndices);
                                rootNode.ChildRowIndices = childIndices;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private static void LoadTonKhoChildColumns(FbConnection conn, string parentTableId, DataGridView dgv, Dictionary<string, ColConfig> configMap, int level, List<int> parentChildIndices)
        {
            if (string.IsNullOrEmpty(parentTableId)) return;

            string sql = "SELECT ID, CAPTION, NAME, REFTABLEID FROM SCOLUMN WHERE UPPER(TRIM(STABLEDESCID)) = UPPER(TRIM(@tid)) ORDER BY NAME ASC";
            using (FbCommand cmd = new FbCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tid", parentTableId);
                using (FbDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(rdr);

                    foreach (DataRow row in dt.Rows)
                    {
                        string colId = row["ID"]?.ToString()?.Trim();
                        string caption = row["CAPTION"]?.ToString()?.Trim();
                        string name = row["NAME"]?.ToString()?.Trim();
                        string refTableId = row["REFTABLEID"]?.ToString()?.Trim();

                        string dispText = !string.IsNullOrEmpty(caption) ? caption : name;

                        ColConfig cfg = null;
                        if (configMap != null)
                        {
                            if (configMap.ContainsKey(colId)) cfg = configMap[colId];
                            else if (configMap.ContainsKey(name)) cfg = configMap[name];
                            else if (configMap.ContainsKey(dispText)) cfg = configMap[dispText];
                        }

                        bool isChecked = false;
                        string titleVal = "";
                        string condVal = "";

                        if (cfg != null)
                        {
                            isChecked = cfg.Checked;
                            titleVal = cfg.Caption ?? "";
                            condVal = cfg.Condition ?? "";
                        }
                        else
                        {
                            // Smart Defaults when table is selected
                            if (level == 1)
                            {
                                if (name == "GHICHU") { isChecked = true; titleVal = "Tồn 2 dvt"; }
                                else if (name == "NAME") { isChecked = true; titleVal = "Mặt hàng"; }
                                else if (name == "MASANCO") { condVal = "(DMATHANG.ST)"; }
                                else if (name == "LOAIMATHANG") { condVal = "(DMATHANG.DL)"; }
                            }
                            else if (level == 2)
                            {
                                if (name == "NAME")
                                {
                                    isChecked = true;
                                    if (dispText.Contains("đơn vị tính") || parentTableId.Contains("DONVITINH")) titleVal = "ĐVT";
                                    else if (dispText.Contains("hãng sản xuất") || parentTableId.Contains("HANGSANXUAT")) titleVal = "Hãng sx";
                                    else titleVal = dispText;
                                }
                            }
                        }

                        bool isParent = !string.IsNullOrEmpty(refTableId);
                        string nodeType = (level == 1) ? (isParent ? "FK_FIELD" : "FIELD") : "SUB_FIELD";

                        FormDesignerCongNoService.TreeRowInfo childNode = new FormDesignerCongNoService.TreeRowInfo
                        {
                            NodeType = nodeType,
                            Level = level,
                            IsParent = isParent,
                            IsExpanded = isParent,
                            ScolId = colId,
                            NodeText = dispText,
                            RefTableId = refTableId,
                            RawColName = name,
                            IsChecked = isChecked
                        };

                        int idx = dgv.Rows.Add(dispText, titleVal, "", "", condVal, "", false, false, "", "", "", false, false);
                        dgv.Rows[idx].Tag = childNode;
                        parentChildIndices.Add(idx);

                        if (isParent)
                        {
                            List<int> subChildIndices = new List<int>();
                            LoadTonKhoChildColumns(conn, refTableId, dgv, configMap, level + 1, subChildIndices);
                            childNode.ChildRowIndices = subChildIndices;
                        }
                    }
                }
            }
        }

        private static List<string> LoadAllTableNamesFromDb()
        {
            List<string> list = new List<string>();
            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT TRIM(NAME) FROM STABLEDESC ORDER BY TRIM(NAME) ASC";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string name = rdr[0]?.ToString()?.Trim();
                            if (!string.IsNullOrEmpty(name) && !list.Contains(name))
                            {
                                list.Add(name);
                            }
                        }
                    }
                }
            }
            catch { }
            return list;
        }

        public static string GenerateDefaultTonKhoHandlerCode(string formName)
        {
            return @"using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using No1Lib.Sys;
using No1Lib.Db;
using No1Lib.Utils;
using FirebirdSql.Data.FirebirdClient;
using System.ComponentModel;
using System.Collections.Generic;

namespace No1Run
{
    public class TonKhoHandler : ITonKhoSupport
    {
        public void SetTonKho(TonKho tonKho)
        {
        }
    }
}
";
        }

        public static string GenerateDefaultTonKhoAspCode()
        {
            return @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirebirdSql.Data.FirebirdClient;
using System.Collections.Generic;
using No1Lib.Web;
using System.Web.Services;

namespace No1Run
{
    public class TonKhoHandler : ITonKhoSupport
    {
        public override void SetTonKho(TonKho tonKho)
        {
        }
    }
}
";
        }

        private static string BuildTonKhoAeLayoutXml(DataGridView dgvMatHang, DataGridView dgvChiTiet)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<DocumentElement>");

                StringBuilder masterSb = new StringBuilder();
                masterSb.AppendLine("<DocumentElement>");

                if (dgvMatHang != null)
                {
                    foreach (DataGridViewRow row in dgvMatHang.Rows)
                    {
                        if (row.Tag is FormDesignerCongNoService.TreeRowInfo node)
                        {
                            if (node.NodeType == "ROOT") continue;

                            string scolId = node.ScolId;
                            string caption = row.Cells[1].Value?.ToString() ?? node.NodeText;
                            string sort = row.Cells[2].Value?.ToString() ?? "";
                            string param = row.Cells[3].Value?.ToString() ?? "";
                            string cond = row.Cells[4].Value?.ToString() ?? "";
                            string formula = row.Cells[5].Value?.ToString() ?? "";
                            bool hide = Convert.ToBoolean(row.Cells[6].Value ?? false);
                            bool noedit = Convert.ToBoolean(row.Cells[7].Value ?? false);
                            string replace = row.Cells[8].Value?.ToString() ?? "";
                            string order = row.Cells[9].Value?.ToString() ?? "";
                            string alias = row.Cells[10].Value?.ToString() ?? "";
                            bool req = Convert.ToBoolean(row.Cells[11].Value ?? false);
                            bool nocol = Convert.ToBoolean(row.Cells[12].Value ?? false);

                            masterSb.AppendLine("  <Data>");
                            masterSb.AppendLine($"    <CHECKED>{(node.IsChecked ? "true" : "false")}</CHECKED>");
                            if (!string.IsNullOrEmpty(scolId)) masterSb.AppendLine($"    <COLID>{scolId}</COLID>");
                            masterSb.AppendLine($"    <CAPTION>{caption}</CAPTION>");
                            masterSb.AppendLine($"    <SORT>{sort}</SORT>");
                            masterSb.AppendLine($"    <PARAM>{param}</PARAM>");
                            masterSb.AppendLine($"    <CONDITION>{cond}</CONDITION>");
                            masterSb.AppendLine($"    <FORMULA>{formula}</FORMULA>");
                            masterSb.AppendLine($"    <HIDE>{(hide ? "true" : "false")}</HIDE>");
                            masterSb.AppendLine($"    <NOEDIT>{(noedit ? "true" : "false")}</NOEDIT>");
                            masterSb.AppendLine($"    <REPLACE>{replace}</REPLACE>");
                            masterSb.AppendLine($"    <ORDER>{order}</ORDER>");
                            masterSb.AppendLine($"    <ALIAS>{alias}</ALIAS>");
                            masterSb.AppendLine($"    <NOTEMPTY>{(req ? "true" : "false")}</NOTEMPTY>");
                            masterSb.AppendLine($"    <KHONGTAOCOT>{(nocol ? "true" : "false")}</KHONGTAOCOT>");
                            masterSb.AppendLine("  </Data>");
                        }
                    }
                }
                masterSb.AppendLine("</DocumentElement>");
                string masterB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(masterSb.ToString()));

                sb.AppendLine("  <Data>");
                sb.AppendLine($"    <MASTER>{masterB64}</MASTER>");
                sb.AppendLine("  </Data>");

                if (dgvChiTiet != null)
                {
                    foreach (DataGridViewRow row in dgvChiTiet.Rows)
                    {
                        string table = row.Cells[0].Value?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(table))
                        {
                            sb.AppendLine("  <Data>");
                            sb.AppendLine($"    <DETAIL>{table}</DETAIL>");
                            sb.AppendLine("  </Data>");
                        }
                    }
                }

                sb.AppendLine("</DocumentElement>");
                return sb.ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
