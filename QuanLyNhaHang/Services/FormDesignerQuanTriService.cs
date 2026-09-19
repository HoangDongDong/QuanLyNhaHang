using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace QuanLyNhaHang.Services
{
    public class FormDesignerQuanTriService
    {
        public class ColumnConfigItem
        {
            public string ColumnId { get; set; }
            public string Caption { get; set; }
            public bool IsUse { get; set; }
            public string AutoReport { get; set; }
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

            // 1. Top Action ToolBar
            ToolStrip tsAction = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(4, 2, 4, 2) };
            ToolStripButton btnSave = new ToolStripButton("💾 Cập nhật (Ctrl + S)");
            ToolStripButton btnSelectAll = new ToolStripButton("☑️ Chọn hết");
            ToolStripButton btnDeselectAll = new ToolStripButton("☐ Không chọn");

            tsAction.Items.AddRange(new ToolStripItem[] { btnSave, new ToolStripSeparator(), btnSelectAll, btnDeselectAll });

            // 2. Sub TabControl (Thiết lập | Code)
            TabControl tcSub = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };
            TabPage tabDesign = new TabPage("Thiết lập");
            TabPage tabCode = new TabPage("Code");

            tcSub.TabPages.Add(tabDesign);
            tcSub.TabPages.Add(tabCode);

            // --- TAB THIẾT LẬP (MASTER-DETAIL GRID MAPPING) ---
            SplitContainer splitGrid = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 260
            };

            // Master Grid (STT | Cột dữ liệu | Tiêu đề | Sử dụng | Báo cáo)
            DataGridView dgvMaster = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                RowHeadersWidth = 35
            };

            DataGridViewTextBoxColumn colNum = new DataGridViewTextBoxColumn { HeaderText = "STT", Width = 45, ReadOnly = true };
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn { HeaderText = "Cột dữ liệu", ReadOnly = true };
            DataGridViewTextBoxColumn colTitle = new DataGridViewTextBoxColumn { HeaderText = "Tiêu đề" };
            DataGridViewCheckBoxColumn colUse = new DataGridViewCheckBoxColumn { HeaderText = "Sử dụng", Width = 65 };
            DataGridViewComboBoxColumn colReport = new DataGridViewComboBoxColumn { HeaderText = "Báo cáo", Width = 140 };
            colReport.Items.AddRange(new object[] { "", "SHOW", "SHOW_SUM", "SHOW_ON_DETAIL" });

            dgvMaster.Columns.AddRange(new DataGridViewColumn[] { colNum, colName, colTitle, colUse, colReport });

            // Load Master Grid columns dynamically from SCOLUMN table & AELAYOUT XML
            LoadMasterColumnsFromDb(model, dgvMaster);

            btnSelectAll.Click += (s, e) =>
            {
                foreach (DataGridViewRow row in dgvMaster.Rows) row.Cells[3].Value = true;
            };

            btnDeselectAll.Click += (s, e) =>
            {
                foreach (DataGridViewRow row in dgvMaster.Rows) row.Cells[3].Value = false;
            };

            splitGrid.Panel1.Controls.Add(dgvMaster);

            // Sub-grid Panel (Detail Sub-grids dynamically loaded from STABLEDESC & SCOLUMN)
            Panel pnlDetail = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(235, 238, 245) };
            ToolStrip tsSubSelect = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(4, 2, 4, 2) };
            ToolStripButton btnSubSelectAll = new ToolStripButton("☑️ Chọn hết");
            ToolStripButton btnSubDeselectAll = new ToolStripButton("☐ Không chọn");
            tsSubSelect.Items.AddRange(new ToolStripItem[] { btnSubSelectAll, btnSubDeselectAll });

            TabControl tcDetail = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };

            // Dynamic Detail Sub-grids loaded from Firebird CSDL
            LoadDetailSubGridsFromDb(model, tcDetail);

            btnSubSelectAll.Click += (s, e) =>
            {
                if (tcDetail.SelectedTab != null)
                {
                    foreach (Control c in tcDetail.SelectedTab.Controls)
                    {
                        if (c is DataGridView dgv)
                        {
                            foreach (DataGridViewRow row in dgv.Rows) row.Cells[3].Value = true;
                        }
                    }
                }
            };

            btnSubDeselectAll.Click += (s, e) =>
            {
                if (tcDetail.SelectedTab != null)
                {
                    foreach (Control c in tcDetail.SelectedTab.Controls)
                    {
                        if (c is DataGridView dgv)
                        {
                            foreach (DataGridViewRow row in dgv.Rows) row.Cells[3].Value = false;
                        }
                    }
                }
            };

            pnlDetail.Controls.Add(tcDetail);
            pnlDetail.Controls.Add(tsSubSelect);

            splitGrid.Panel2.Controls.Add(pnlDetail);

            tabDesign.Controls.Add(splitGrid);

            // --- TAB CODE (C# HANDLER CLASS) ---
            FastColoredTextBoxNS.FastColoredTextBox txtCodeEditor = new FastColoredTextBoxNS.FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Language = FastColoredTextBoxNS.Language.CSharp,
                Font = new Font("Consolas", 10F),
                Text = !string.IsNullOrWhiteSpace(model.Code) ? model.Code : GenerateDefaultQuanTriHandlerCode(model)
            };

            tabCode.Controls.Add(txtCodeEditor);

            btnSave.Click += (s, e) =>
            {
                model.Code = txtCodeEditor.Text;
                model.AeLayout = BuildQuanTriAeLayoutXml(dgvMaster, tcDetail);
                DbFormService.SaveFormCode(model.Id, model.Code, model.ServerCode, model.ClientCode, model.AeLayout, model.Name);
                MessageBox.Show($"Đã cập nhật cấu trúc Form Quản trị [{model.Name}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            Panel pnlMain = new Panel { Dock = DockStyle.Fill };
            pnlMain.Controls.Add(tcSub);
            pnlMain.Controls.Add(tsAction);

            tab.Controls.Add(pnlMain);
            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;
        }

        public static string GenerateDefaultQuanTriHandlerCode(FormModel model)
        {
            string className = !string.IsNullOrWhiteSpace(model.ClassName)
                ? model.ClassName
                : (!string.IsNullOrWhiteSpace(model.Name) ? System.Text.RegularExpressions.Regex.Replace(model.Name, @"[^\w]", "") + "MgHandler" : "QuanTriMgHandler");

            return $@"using System;
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
{{
    public class {className} : ICustomManagementSupport
    {{
        public void SetCustomManagement(TreeGridMg treeGrid)
        {{
            treeGrid.grMain.CustomLoadData += new CustomLoadDataHandler(grMain_CustomLoadData);
        }}

        void grMain_CustomLoadData(object sender, CustomLoadDataArgs e)
        {{
            e.Where += "" AND (LATAMUNG = 0 OR LATAMUNG IS NULL)"";
        }}
    }}
}}
";
        }

        private static void LoadMasterColumnsFromDb(FormModel model, DataGridView dgvMaster)
        {
            dgvMaster.Rows.Clear();
            Dictionary<string, ColumnConfigItem> xmlConfig = ParseAeLayoutXml(model.AeLayout, 0);

            if (!string.IsNullOrEmpty(model.STableDescId))
            {
                try
                {
                    using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                    {
                        conn.Open();
                        string sql = @"
                            SELECT ID, NAME, CAPTION, AUTOREPORT 
                            FROM SCOLUMN 
                            WHERE UPPER(TRIM(STABLEDESCID)) = UPPER(TRIM(@TableId))
                            ORDER BY NAME";

                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@TableId", model.STableDescId);
                            using (FbDataReader rdr = cmd.ExecuteReader())
                            {
                                int stt = 1;
                                while (rdr.Read())
                                {
                                    string scolId = rdr["ID"]?.ToString().Trim();
                                    string colName = rdr["NAME"]?.ToString().Trim();
                                    string caption = rdr["CAPTION"] != DBNull.Value ? rdr["CAPTION"]?.ToString().Trim() : colName;
                                    string autoReport = rdr["AUTOREPORT"] != DBNull.Value ? rdr["AUTOREPORT"]?.ToString().Trim() : "";

                                    bool isUse = stt <= 6 || (colName != null && (colName.Contains("TIEN") || colName.Contains("SO_PHIEU") || colName.Contains("NOTE")));
                                    if (string.IsNullOrEmpty(autoReport) && colName != null && (colName.Contains("TIEN") || colName.Contains("TONG") || colName.Contains("SO_TIEN")))
                                    {
                                        autoReport = "SHOW_SUM";
                                    }
                                    else if (string.IsNullOrEmpty(autoReport) && isUse)
                                    {
                                        autoReport = "SHOW";
                                    }

                                    if (xmlConfig != null && xmlConfig.TryGetValue(scolId, out var cfg))
                                    {
                                        if (!string.IsNullOrEmpty(cfg.Caption)) caption = cfg.Caption;
                                        isUse = cfg.IsUse;
                                        if (!string.IsNullOrEmpty(cfg.AutoReport)) autoReport = cfg.AutoReport;
                                    }

                                    int rowIndex = dgvMaster.Rows.Add(stt.ToString("D2"), colName, caption, isUse, autoReport);
                                    dgvMaster.Rows[rowIndex].Tag = scolId;
                                    stt++;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi nạp SCOLUMN từ CSDL: " + ex.Message);
                }
            }
        }

        private static void LoadDetailSubGridsFromDb(FormModel model, TabControl tcDetail)
        {
            tcDetail.TabPages.Clear();
            if (string.IsNullOrEmpty(model.STableDescId)) return;

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sqlSub = @"
                        SELECT ID, NAME, DESCRIPTION 
                        FROM STABLEDESC 
                        WHERE UPPER(TRIM(MASTERTABLEID)) = UPPER(TRIM(@TableId))
                        ORDER BY NAME";

                    List<Tuple<string, string, string>> subTables = new List<Tuple<string, string, string>>();
                    using (FbCommand cmd = new FbCommand(sqlSub, conn))
                    {
                        cmd.Parameters.AddWithValue("@TableId", model.STableDescId);
                        using (FbDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                subTables.Add(new Tuple<string, string, string>(
                                    rdr["ID"]?.ToString().Trim(),
                                    rdr["NAME"]?.ToString().Trim(),
                                    rdr["DESCRIPTION"] != DBNull.Value ? rdr["DESCRIPTION"]?.ToString().Trim() : rdr["NAME"]?.ToString().Trim()
                                ));
                            }
                        }
                    }

                    int dataBlockIndex = 1;
                    foreach (var sub in subTables)
                    {
                        string subId = sub.Item1;
                        string subName = sub.Item2;
                        string subDesc = sub.Item3;

                        TabPage tabDetail = new TabPage(subDesc);

                        Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 32, BackColor = Color.White };
                        Label lblName = new Label { Text = "Tên:", Location = new Point(10, 8), AutoSize = true, Font = new Font("Segoe UI", 9F) };
                        TextBox txtName = new TextBox { Text = subDesc, Location = new Point(45, 5), Width = 220, Font = new Font("Segoe UI", 9F) };
                        txtName.Tag = subId;
                        pnlHeader.Controls.Add(lblName);
                        pnlHeader.Controls.Add(txtName);

                        DataGridView dgvDetail = new DataGridView
                        {
                            Dock = DockStyle.Fill,
                            BackgroundColor = Color.White,
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                            AllowUserToAddRows = false,
                            RowHeadersWidth = 35
                        };

                        DataGridViewTextBoxColumn cDNum = new DataGridViewTextBoxColumn { HeaderText = "STT", Width = 45, ReadOnly = true };
                        DataGridViewTextBoxColumn cDName = new DataGridViewTextBoxColumn { HeaderText = "Cột dữ liệu", ReadOnly = true };
                        DataGridViewTextBoxColumn cDTitle = new DataGridViewTextBoxColumn { HeaderText = "Tiêu đề" };
                        DataGridViewCheckBoxColumn cDUse = new DataGridViewCheckBoxColumn { HeaderText = "Sử dụng", Width = 65 };
                        DataGridViewComboBoxColumn cDReport = new DataGridViewComboBoxColumn { HeaderText = "Báo cáo", Width = 140 };
                        cDReport.Items.AddRange(new object[] { "", "SHOW", "SHOW_SUM", "SHOW_ON_DETAIL" });

                        dgvDetail.Columns.AddRange(new DataGridViewColumn[] { cDNum, cDName, cDTitle, cDUse, cDReport });

                        Dictionary<string, ColumnConfigItem> xmlConfig = ParseAeLayoutXml(model.AeLayout, dataBlockIndex);

                        string sqlCols = @"
                            SELECT ID, NAME, CAPTION, AUTOREPORT 
                            FROM SCOLUMN 
                            WHERE UPPER(TRIM(STABLEDESCID)) = UPPER(TRIM(@SubTableId))
                            ORDER BY NAME";

                        using (FbCommand cmdCol = new FbCommand(sqlCols, conn))
                        {
                            cmdCol.Parameters.AddWithValue("@SubTableId", subId);
                            using (FbDataReader rdrCol = cmdCol.ExecuteReader())
                            {
                                int stt = 1;
                                while (rdrCol.Read())
                                {
                                    string scolId = rdrCol["ID"]?.ToString().Trim();
                                    string colName = rdrCol["NAME"]?.ToString().Trim();
                                    string caption = rdrCol["CAPTION"] != DBNull.Value ? rdrCol["CAPTION"]?.ToString().Trim() : colName;
                                    string autoReport = rdrCol["AUTOREPORT"] != DBNull.Value ? rdrCol["AUTOREPORT"]?.ToString().Trim() : "";

                                    bool isUse = stt <= 6 || (colName != null && (colName.Contains("SO_LUONG") || colName.Contains("TIEN") || colName.Contains("NOTE")));
                                    if (string.IsNullOrEmpty(autoReport) && colName != null && (colName.Contains("SO_LUONG") || colName.Contains("TIEN") || colName.Contains("DON_GIA")))
                                    {
                                        autoReport = "SHOW_SUM";
                                    }
                                    else if (string.IsNullOrEmpty(autoReport) && isUse)
                                    {
                                        autoReport = "SHOW";
                                    }

                                    if (xmlConfig != null && xmlConfig.TryGetValue(scolId, out var cfg))
                                    {
                                        if (!string.IsNullOrEmpty(cfg.Caption)) caption = cfg.Caption;
                                        isUse = cfg.IsUse;
                                        if (!string.IsNullOrEmpty(cfg.AutoReport)) autoReport = cfg.AutoReport;
                                    }

                                    int rowIndex = dgvDetail.Rows.Add(stt.ToString("D2"), colName, caption, isUse, autoReport);
                                    dgvDetail.Rows[rowIndex].Tag = scolId;
                                    stt++;
                                }
                            }
                        }

                        tabDetail.Controls.Add(dgvDetail);
                        tabDetail.Controls.Add(pnlHeader);
                        tcDetail.TabPages.Add(tabDetail);

                        dataBlockIndex++;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi nạp bảng chi tiết từ CSDL: " + ex.Message);
            }
        }

        private static Dictionary<string, ColumnConfigItem> ParseAeLayoutXml(string xmlString, int blockIndex)
        {
            if (string.IsNullOrWhiteSpace(xmlString)) return null;
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(xmlString);

                var dataNodes = doc.SelectNodes("//DocumentElement/Data/DATA");
                if (dataNodes != null && blockIndex < dataNodes.Count)
                {
                    string b64 = dataNodes[blockIndex].InnerText;
                    if (!string.IsNullOrWhiteSpace(b64))
                    {
                        byte[] bytes = Convert.FromBase64String(b64);
                        string innerXml = Encoding.UTF8.GetString(bytes);

                        System.Xml.XmlDocument innerDoc = new System.Xml.XmlDocument();
                        innerDoc.LoadXml(innerXml);

                        Dictionary<string, ColumnConfigItem> result = new Dictionary<string, ColumnConfigItem>(StringComparer.OrdinalIgnoreCase);
                        var itemNodes = innerDoc.SelectNodes("//DocumentElement/Data");
                        if (itemNodes != null)
                        {
                            foreach (System.Xml.XmlNode n in itemNodes)
                            {
                                string colId = n["SCOLUMNID"]?.InnerText;
                                if (string.IsNullOrEmpty(colId)) continue;

                                string useStr = n["USE"]?.InnerText;
                                bool isUse = (useStr == "1" || useStr == "30");
                                string caption = n["CAPTION"]?.InnerText ?? n["TITLE"]?.InnerText;
                                string autoReport = n["AUTOREPORT"]?.InnerText ?? "";

                                result[colId] = new ColumnConfigItem
                                {
                                    ColumnId = colId,
                                    Caption = caption,
                                    IsUse = isUse,
                                    AutoReport = autoReport
                                };
                            }
                        }
                        return result;
                    }
                }
            }
            catch { }
            return null;
        }

        public static string BuildQuanTriAeLayoutXml(DataGridView dgvMaster, TabControl tcDetail)
        {
            try
            {
                StringBuilder outerSb = new StringBuilder();
                outerSb.AppendLine("<DocumentElement>");

                // Master grid block -> index 0
                string masterInnerXml = BuildInnerXmlFromGrid(dgvMaster);
                string masterB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(masterInnerXml));
                outerSb.AppendLine("  <Data>");
                outerSb.AppendLine($"    <DATA>{masterB64}</DATA>");
                outerSb.AppendLine("  </Data>");

                // Detail grid blocks -> index 1, 2, ...
                foreach (TabPage tab in tcDetail.TabPages)
                {
                    foreach (Control c in tab.Controls)
                    {
                        if (c is DataGridView dgvDetail)
                        {
                            string detailInnerXml = BuildInnerXmlFromGrid(dgvDetail);
                            string detailB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(detailInnerXml));
                            outerSb.AppendLine("  <Data>");
                            outerSb.AppendLine($"    <DATA>{detailB64}</DATA>");
                            outerSb.AppendLine("  </Data>");
                        }
                    }
                }

                outerSb.AppendLine("</DocumentElement>");
                return outerSb.ToString();
            }
            catch
            {
                return "";
            }
        }

        private static string BuildInnerXmlFromGrid(DataGridView dgv)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<DocumentElement>");
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string colId = row.Tag?.ToString();
                string colName = row.Cells[1].Value?.ToString();
                string title = row.Cells[2].Value?.ToString();
                bool isUse = Convert.ToBoolean(row.Cells[3].Value ?? false);
                string autoReport = row.Cells[4].Value?.ToString() ?? "";

                sb.AppendLine("  <Data>");
                if (!string.IsNullOrEmpty(colId)) sb.AppendLine($"    <SCOLUMNID>{colId}</SCOLUMNID>");
                sb.AppendLine($"    <USE>{(isUse ? 30 : 0)}</USE>");
                if (!string.IsNullOrEmpty(title) && title != colName) sb.AppendLine($"    <CAPTION>{title}</CAPTION>");
                if (!string.IsNullOrEmpty(autoReport)) sb.AppendLine($"    <AUTOREPORT>{autoReport}</AUTOREPORT>");
                if (!string.IsNullOrEmpty(colName)) sb.AppendLine($"    <NAME>{colName}</NAME>");
                sb.AppendLine("  </Data>");
            }
            sb.AppendLine("</DocumentElement>");
            return sb.ToString();
        }
    }
}
