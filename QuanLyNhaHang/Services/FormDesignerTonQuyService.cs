using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using FastColoredTextBoxNS;
using QuanLyNhaHang.Forms;

namespace QuanLyNhaHang.Services
{
    public class FormDesignerTonQuyService
    {
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

            // 1. Top Action ToolBar (➕ Thêm, ✏️ Sửa, ❌ Xóa, 💾 Cập nhật)
            ToolStrip tsAction = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(4, 2, 4, 2) };
            ToolStripButton btnAdd = new ToolStripButton("➕ Thêm");
            ToolStripButton btnEdit = new ToolStripButton("✏️ Sửa");
            ToolStripButton btnDelete = new ToolStripButton("❌ Xóa");
            ToolStripButton btnSave = new ToolStripButton("💾 Cập nhật");

            tsAction.Items.AddRange(new ToolStripItem[] { btnAdd, btnEdit, btnDelete, new ToolStripSeparator(), btnSave });

            // 2. Top Header Panel (Lưu ý & Cột ngày/thu/chi)
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 62,
                BackColor = Color.FromArgb(235, 238, 242),
                Padding = new Padding(8, 6, 8, 6)
            };

            Label lblNote = new Label
            {
                Text = "(Lưu ý: các cột cần phải sắp xếp đúng thứ tự ở các view con để có thể tổng hợp - join giữa các bảng)",
                Location = new Point(8, 6),
                AutoSize = true,
                ForeColor = Color.DarkRed,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic)
            };

            Label lblCotNgay = new Label { Text = "Cột ngày:", Location = new Point(8, 32), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            TextBox txtCotNgay = new TextBox { Text = "NGAY", Location = new Point(68, 29), Width = 90, Font = new Font("Segoe UI", 8.5F) };

            Label lblCotThu = new Label { Text = "Cột thu:", Location = new Point(175, 32), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            TextBox txtCotThu = new TextBox { Text = "THU", Location = new Point(230, 29), Width = 90, Font = new Font("Segoe UI", 8.5F) };

            Label lblCotChi = new Label { Text = "Cột chi:", Location = new Point(335, 32), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            TextBox txtCotChi = new TextBox { Text = "CHI", Location = new Point(390, 29), Width = 90, Font = new Font("Segoe UI", 8.5F) };

            pnlHeader.Controls.AddRange(new Control[] {
                lblNote,
                lblCotNgay, txtCotNgay,
                lblCotThu, txtCotThu,
                lblCotChi, txtCotChi
            });

            // Parse existing values from SFORM NOTE column (e.g. "NGAY|THU|CHI|") or XML if present
            ParseTonQuyHeaderNote(model.Note, txtCotNgay, txtCotThu, txtCotChi);

            // 3. Main Sub-TabControl (Dữ liệu | Code)
            TabControl tcSub = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };
            TabPage tabData = new TabPage("Dữ liệu");
            TabPage tabCode = new TabPage("Code");

            tcSub.TabPages.Add(tabData);
            tcSub.TabPages.Add(tabCode);

            // --- TAB 1: DỮ LIỆU ---
            // DataGrid displaying single column "Bảng dữ liệu" with row numbers 1, 2...
            DataGridView dgvData = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                GridColor = Color.FromArgb(220, 224, 230),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersWidth = 35,
                MultiSelect = false
            };
            dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 90, 40);
            dgvData.DefaultCellStyle.SelectionForeColor = Color.White;

            DataGridViewTextBoxColumn colTableName = new DataGridViewTextBoxColumn
            {
                HeaderText = "Bảng dữ liệu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            dgvData.Columns.Add(colTableName);

            // Row numbers painting
            dgvData.RowPostPaint += (s, e) =>
            {
                using (SolidBrush b = new SolidBrush(dgvData.RowHeadersDefaultCellStyle.ForeColor))
                {
                    e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                        dgvData.Font, b,
                        e.RowBounds.Location.X + 10,
                        e.RowBounds.Location.Y + 4);
                }
            };

            // Parse existing tables from AeLayout XML
            List<Tuple<string, string>> tablesList = ParseTonQuyTablesXml(model.AeLayout);
            if (tablesList.Count > 0)
            {
                foreach (var item in tablesList)
                {
                    int rIdx = dgvData.Rows.Add(item.Item1);
                    dgvData.Rows[rIdx].Tag = item.Item2;
                }
            }
            else
            {
                // Default fallback tables if brand new form
                dgvData.Rows.Add("TTHUCHI");
                dgvData.Rows.Add("TDONHANG");
            }

            tabData.Controls.Add(dgvData);

            // Toolbar Events
            btnAdd.Click += (s, e) =>
            {
                string selectedTable = FormSelectTable.SelectTable(tsAction.FindForm(), "");
                if (!string.IsNullOrWhiteSpace(selectedTable))
                {
                    dgvData.Rows.Add(selectedTable);
                }
            };

            btnEdit.Click += (s, e) =>
            {
                if (dgvData.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvData.SelectedRows[0];
                    string curTable = row.Cells[0].Value?.ToString() ?? "";
                    string selectedTable = FormSelectTable.SelectTable(tsAction.FindForm(), curTable);
                    if (!string.IsNullOrWhiteSpace(selectedTable))
                    {
                        row.Cells[0].Value = selectedTable;
                    }
                }
            };

            btnDelete.Click += (s, e) =>
            {
                if (dgvData.SelectedRows.Count > 0)
                {
                    dgvData.Rows.RemoveAt(dgvData.SelectedRows[0].Index);
                }
            };

            // --- TAB 2: CODE (C# Handler Code Editor) ---
            FastColoredTextBox txtCode = new FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Language = Language.CSharp,
                Font = new Font("Consolas", 10F),
                ShowLineNumbers = true,
                Text = string.IsNullOrWhiteSpace(model.Code) ? GetDefaultTonQuyCode(model.Name) : model.Code
            };
            tabCode.Controls.Add(txtCode);

            // Assemble main layout
            tab.Controls.Add(tcSub);
            tab.Controls.Add(pnlHeader);
            tab.Controls.Add(tsAction);

            // Save Action with Packaging Progress Bar
            btnSave.Click += (s, e) =>
            {
                string updatedAeLayout = BuildTonQuyTablesXml(dgvData);
                string updatedNote = $"{txtCotNgay.Text.Trim()}|{txtCotThu.Text.Trim()}|{txtCotChi.Text.Trim()}|";
                model.Note = updatedNote;
                ExecuteSaveWithPackagingProgress(model, txtCode.Text, "", "", updatedAeLayout, tab);
            };

            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;
        }

        private static void ParseTonQuyHeaderNote(string note, TextBox txtNgay, TextBox txtThu, TextBox txtChi)
        {
            if (string.IsNullOrWhiteSpace(note)) return;
            string[] parts = note.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 1 && !string.IsNullOrWhiteSpace(parts[0])) txtNgay.Text = parts[0].Trim();
            if (parts.Length >= 2 && !string.IsNullOrWhiteSpace(parts[1])) txtThu.Text = parts[1].Trim();
            if (parts.Length >= 3 && !string.IsNullOrWhiteSpace(parts[2])) txtChi.Text = parts[2].Trim();
        }

        private static List<Tuple<string, string>> ParseTonQuyTablesXml(string xml)
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            if (string.IsNullOrWhiteSpace(xml)) return result;

            try
            {
                XmlDocument doc = new XmlDocument();
                string wrapped = xml.Trim();
                if (!wrapped.StartsWith("<DocumentElement>") && !wrapped.StartsWith("<Root>") && !wrapped.StartsWith("<?xml"))
                {
                    wrapped = $"<DocumentElement>{wrapped}</DocumentElement>";
                }
                doc.LoadXml(wrapped);

                XmlNodeList dataNodes = doc.SelectNodes("//Data");
                foreach (XmlNode node in dataNodes)
                {
                    XmlNode tNode = node.SelectSingleNode("TABLE");
                    if (tNode != null && !string.IsNullOrWhiteSpace(tNode.InnerText))
                    {
                        string tableName = tNode.InnerText.Trim();
                        XmlNode cNode = node.SelectSingleNode("CONFIG");
                        string configVal = cNode != null ? cNode.InnerText : "";
                        result.Add(new Tuple<string, string>(tableName, configVal));
                    }
                }
            }
            catch { }

            return result;
        }

        private static string BuildTonQuyTablesXml(DataGridView dgvData)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("DocumentElement");
                doc.AppendChild(root);

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.IsNewRow) continue;
                    string tableName = row.Cells[0].Value?.ToString()?.Trim();
                    if (string.IsNullOrEmpty(tableName)) continue;

                    XmlElement dataNode = doc.CreateElement("Data");

                    XmlElement tableNode = doc.CreateElement("TABLE");
                    tableNode.InnerText = tableName;
                    dataNode.AppendChild(tableNode);

                    string configVal = row.Tag?.ToString() ?? "";
                    XmlElement configNode = doc.CreateElement("CONFIG");
                    configNode.InnerText = configVal;
                    dataNode.AppendChild(configNode);

                    root.AppendChild(dataNode);
                }

                return doc.OuterXml;
            }
            catch
            {
                return "";
            }
        }

        private static void ExecuteSaveWithPackagingProgress(FormModel model, string codeText, string serverCodeText, string clientCodeText, string aeLayoutXml, TabPage parentTab)
        {
            Form progressForm = new Form
            {
                Text = "Đóng gói",
                Size = new Size(380, 130),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ControlBox = false,
                TopMost = true
            };

            Label lblProgress = new Label
            {
                Text = "Đang đóng gói dữ liệu...",
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F)
            };

            ProgressBar progressBar = new ProgressBar
            {
                Location = new Point(20, 42),
                Width = 325,
                Height = 22,
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30
            };

            progressForm.Controls.Add(lblProgress);
            progressForm.Controls.Add(progressBar);
            progressForm.Show();

            Timer tmr = new Timer { Interval = 600 };
            tmr.Tick += (ts, te) =>
            {
                tmr.Stop();
                tmr.Dispose();
                progressForm.Close();

                bool success = DbFormService.SaveFormCode(model.Id, codeText, "", "", aeLayoutXml, model.Name);
                if (success)
                {
                    model.Code = codeText;
                    model.AeLayout = aeLayoutXml;
                    MessageBox.Show("Cập nhật form Tồn quỹ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi khi lưu form Tồn quỹ vào CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            tmr.Start();
        }

        private static string GetDefaultTonQuyCode(string formName)
        {
            return @"// Code handler cho Tồn quỹ
if (whereDonHang.Length > 0) whereDonHang += "" AND "";
whereDonHang += ""COALESCE(TIENMAT, 0) <> 0"";

selectField = ""COALESCE(TIENMAT, 0)"";

else if (tv.SelectedNode == quetTheNode)
{
    if (whereThuChi.Length > 0) whereThuChi += "" AND "";
    whereThuChi += ""0 = 1"";

    if (whereDonHang.Length > 0) whereDonHang += "" AND "";
    whereDonHang += ""COALESCE(THE, 0) <> 0"";

    selectField = ""COALESCE(THE, 0)"";
}
else if (tv.SelectedNode == nganHangNode)
{
    if (whereThuChi.Length > 0) whereThuChi += "" AND "";
    whereThuChi += ""CHUYENKHOAN = 30"";

    if (whereDonHang.Length > 0) whereDonHang += "" AND "";
    whereDonHang += ""COALESCE(CHUYENKHOAN, 0) <> 0"";

    selectField = ""COALESCE(CHUYENKHOAN, 0)"";
}
else
{
    if (whereThuChi.Length > 0) whereThuChi += "" AND "";
    whereThuChi += ""CHUYENKHOAN = 30 AND DTAIKHOANNGANHANGID = '"" + tv.SelectedNode.Name + ""'"";

    if (whereDonHang.Length > 0) whereDonHang += "" AND "";
    whereDonHang += ""DTAIKHOANNGANHANGID = '"" + tv.SelectedNode.Name + ""'"";

    selectField = ""COALESCE(CHUYENKHOAN, 0)"";
}
";
        }
    }
}
