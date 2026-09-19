using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace QuanLyNhaHang.Services
{
    public class FormDesignerCongNoService
    {
        public class TreeRowInfo
        {
            public int Level { get; set; } = 0; // 0=Root Table, 1=Field/FK, 2=Sub Field
            public bool IsParent { get; set; } = false;
            public bool IsExpanded { get; set; } = false;
            public bool IsChecked { get; set; } = false;
            public string NodeText { get; set; } = "";
            public string NodeType { get; set; } = "FIELD"; // ROOT, FIELD, FK_FIELD, SUB_FIELD
            public string ScolId { get; set; } = "";
            public string TableId { get; set; } = "";
            public string RefTableId { get; set; } = "";
            public string RawColName { get; set; } = "";
            public int RowIndex { get; set; } = -1;
            public List<int> ChildRowIndices { get; set; } = new List<int>();
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
            tsAction.Items.Add(btnSave);

            // 2. Header Panel with Form parameters
            bool isTheoHoaDon = (model.Loai == 2 || model.FormType == 3);
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = isTheoHoaDon ? 35 : 95, BackColor = Color.FromArgb(235, 238, 245), Padding = new Padding(6) };

            Label lblTable = new Label { Text = "Bảng thanh toán", Location = new Point(10, 8), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboPaymentTable = new ComboBox { Location = new Point(115, 5), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };
            cboPaymentTable.Items.Clear();
            var dbTableNames = LoadAllTableNamesFromDb();
            if (dbTableNames.Count > 0)
            {
                cboPaymentTable.Items.AddRange(dbTableNames.ToArray());
            }
            else
            {
                cboPaymentTable.Items.AddRange(new object[] { "TTHUCHI", "TDONHANG", "TBANGLUONG" });
            }

            if (!string.IsNullOrEmpty(model.STableDescId))
            {
                string currentTable = GetTableNameById(model.STableDescId);
                cboPaymentTable.SelectedItem = currentTable;
            }
            else
            {
                cboPaymentTable.SelectedItem = null;
                cboPaymentTable.SelectedIndex = -1;
            }

            Label lblLoai = new Label { Text = "Loại:", Location = new Point(280, 8), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            TextBox txtLoai = new TextBox { Text = model.Loai.ToString(), Location = new Point(315, 5), Width = 40, Font = new Font("Segoe UI", 9F) };
            Label lblNoteLoai = new Label { Name = "lblNoteLoai", Text = "(Bảng thanh toán thông thường là bảng thu chi)", Location = new Point(365, 8), AutoSize = true, ForeColor = Color.DimGray, Font = new Font("Segoe UI", 8.5F), Visible = !isTheoHoaDon };

            string defaultClassName = (!string.IsNullOrWhiteSpace(model.ClassName) && model.ClassName.EndsWith("Handler"))
                ? model.ClassName
                : ((model.Loai == 1) ? "CongNo1Handler" : "CongNo0Handler");

            Label lblClass = new Label { Name = "lblClass", Text = "Lớp:", Location = new Point(620, 8), AutoSize = true, Font = new Font("Segoe UI", 9F), Visible = !isTheoHoaDon };
            TextBox txtClassName = new TextBox
            {
                Name = "txtClassName",
                Text = defaultClassName,
                Location = new Point(655, 5),
                Width = 140,
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(255, 255, 208),
                Visible = !isTheoHoaDon
            };

            Label lblDesc1 = new Label { Name = "lblDesc1", Text = "Bảng gốc: Bảng đơn hàng - Bảng tạo ra công nợ", Location = new Point(10, 32), AutoSize = true, Font = new Font("Segoe UI", 8.5F, FontStyle.Italic), Visible = !isTheoHoaDon };
            Label lblDesc2 = new Label { Name = "lblDesc2", Text = "Dữ liệu tổng hợp: Là dữ liệu để tổng hợp nên công nợ hiện tại, ví dụ: Mua (tăng nợ), Thanh toán (giảm nợ), Trừ hoa hồng (giảm nợ)...", Location = new Point(10, 50), AutoSize = true, Font = new Font("Segoe UI", 8.5F, FontStyle.Italic), Visible = !isTheoHoaDon };
            Label lblDesc3 = new Label { Name = "lblDesc3", Text = "(Lưu ý: Ở dữ liệu tổng hợp, các cột cần phải sắp xếp đúng thứ tự ở các view con để có thể tổng hợp - join giữa các bảng)", Location = new Point(40, 68), AutoSize = true, ForeColor = Color.DarkRed, Font = new Font("Segoe UI", 8.5F, FontStyle.Italic), Visible = !isTheoHoaDon };

            pnlHeader.Controls.AddRange(new Control[] { lblTable, cboPaymentTable, lblLoai, txtLoai, lblNoteLoai, lblClass, txtClassName, lblDesc1, lblDesc2, lblDesc3 });

            // 3. Main Designer TabControl
            TabControl tcSub = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };
            TabPage tabTongHop = new TabPage("Dữ liệu tổng hợp");
            TabPage tabCode = new TabPage("Code");

            DataGridView dgvDoiTacNo = null;
            DataGridView dgvDonHang = null;

            UpdateHeaderAndTabs(model, pnlHeader, tcSub, tabTongHop, tabCode, ref dgvDoiTacNo, ref dgvDonHang);

            cboPaymentTable.SelectedIndexChanged += (s, e) =>
            {
                string selName = cboPaymentTable.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selName))
                {
                    string tid = GetTableIdByName(selName);
                    if (!string.IsNullOrEmpty(tid))
                    {
                        model.STableDescId = tid;
                        UpdateHeaderAndTabs(model, pnlHeader, tcSub, tabTongHop, tabCode, ref dgvDoiTacNo, ref dgvDonHang);
                    }
                }
            };

            txtLoai.TextChanged += (s, e) =>
            {
                if (int.TryParse(txtLoai.Text, out int newLoai))
                {
                    model.Loai = newLoai;
                    UpdateHeaderAndTabs(model, pnlHeader, tcSub, tabTongHop, tabCode, ref dgvDoiTacNo, ref dgvDonHang);
                }
            };

            // --- TAB 2: DỮ LIỆU TỔNG HỢP (MATCHING ORIGINAL APP STYLING) ---
            Panel pnlTongHop = new Panel { Dock = DockStyle.Fill };
            ToolStrip tsTongHop = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(4, 2, 4, 2) };
            ToolStripButton btnAddTH = new ToolStripButton("➕ Thêm");
            ToolStripButton btnEditTH = new ToolStripButton("✏️ Sửa");
            ToolStripButton btnDelTH = new ToolStripButton("❌ Xóa");
            ToolStripButton btnSumTH = new ToolStripButton("☑️ Chọn cột tổng");
            ToolStripButton btnLinkTH = new ToolStripButton("☑️ Chọn cột liên kết");

            tsTongHop.Items.AddRange(new ToolStripItem[] { btnAddTH, btnEditTH, btnDelTH, new ToolStripSeparator(), btnSumTH, btnLinkTH });

            DataGridView dgvTongHop = new DataGridView
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

            dgvTongHop.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 251);
            dgvTongHop.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            DataGridViewTextBoxColumn colTHTable = new DataGridViewTextBoxColumn { HeaderText = "Bảng dữ liệu", Width = 150 };
            DataGridViewTextBoxColumn colTHSum = new DataGridViewTextBoxColumn { HeaderText = "Cột tổng" };
            DataGridViewTextBoxColumn colTHLink = new DataGridViewTextBoxColumn { HeaderText = "Cột liên kết", Width = 150 };
            DataGridViewTextBoxColumn colTHCond = new DataGridViewTextBoxColumn { HeaderText = "Điều kiện" };

            dgvTongHop.Columns.AddRange(new DataGridViewColumn[] { colTHTable, colTHSum, colTHLink, colTHCond });

            // Custom Cell Painting for Row 0 Highlights (Amber/Orange for Bảng dữ liệu, Vivid Blue for Cột tổng/Liên kết)
            dgvTongHop.CellPainting += (s, e) =>
            {
                if (e.RowIndex == 0 && e.ColumnIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground & ~DataGridViewPaintParts.Background);

                    Graphics g = e.Graphics;
                    Rectangle rect = e.CellBounds;

                    if (e.ColumnIndex == 0) // Bảng dữ liệu (TDONHANG)
                    {
                        using (Brush b = new SolidBrush(Color.FromArgb(196, 118, 60)))
                        {
                            g.FillRectangle(b, rect);
                        }
                        TextRenderer.DrawText(g, e.Value?.ToString() ?? "", new Font("Segoe UI", 9F, FontStyle.Bold), new Point(rect.Left + 6, rect.Top + 4), Color.White);
                        g.DrawRectangle(Pens.LightGray, rect);
                        e.Handled = true;
                    }
                    else if (e.ColumnIndex == 1 || e.ColumnIndex == 2) // Cột tổng & Cột liên kết
                    {
                        using (Brush b = new SolidBrush(Color.FromArgb(0, 114, 198)))
                        {
                            g.FillRectangle(b, rect);
                        }
                        TextRenderer.DrawText(g, e.Value?.ToString() ?? "", new Font("Segoe UI", 9F), new Point(rect.Left + 6, rect.Top + 4), Color.White);
                        g.DrawRectangle(Pens.LightGray, rect);
                        e.Handled = true;
                    }
                }
            };

            LoadCongNoTongHopFromDb(model, dgvTongHop);

            btnAddTH.Click += (s, e) =>
            {
                ShowCongNoTongHopRowDialog(tabMainContainer.FindForm(), dgvTongHop, false);
            };
            btnEditTH.Click += (s, e) =>
            {
                ShowCongNoTongHopRowDialog(tabMainContainer.FindForm(), dgvTongHop, true);
            };
            dgvTongHop.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    ShowCongNoTongHopRowDialog(tabMainContainer.FindForm(), dgvTongHop, true);
                }
            };
            btnDelTH.Click += (s, e) => { if (dgvTongHop.SelectedRows.Count > 0) dgvTongHop.Rows.RemoveAt(dgvTongHop.SelectedRows[0].Index); };

            pnlTongHop.Controls.Add(dgvTongHop);
            pnlTongHop.Controls.Add(tsTongHop);
            tabTongHop.Controls.Add(pnlTongHop);

            defaultClassName = (!string.IsNullOrWhiteSpace(model.ClassName) && model.ClassName.EndsWith("Handler"))
                ? model.ClassName
                : ((model.Loai == 1) ? "CongNo1Handler" : "CongNo0Handler");

            string initialCode = (!string.IsNullOrWhiteSpace(model.Code) && model.Code.Contains("ICongNoSupport"))
                ? model.Code
                : GenerateDefaultCongNoHandlerCode(defaultClassName);

            FastColoredTextBoxNS.FastColoredTextBox txtCodeEditor = new FastColoredTextBoxNS.FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Language = FastColoredTextBoxNS.Language.CSharp,
                Font = new Font("Consolas", 10F),
                Text = initialCode
            };

            tabCode.Controls.Add(txtCodeEditor);

            // --- SAVE ACTION ---
            btnSave.Click += (s, e) =>
            {
                List<DataGridView> masterGrids = new List<DataGridView>();
                if (dgvDoiTacNo != null) masterGrids.Add(dgvDoiTacNo);
                if (dgvDonHang != null) masterGrids.Add(dgvDonHang);
                model.AeLayout = BuildCongNoAeLayoutXml(masterGrids, dgvTongHop);
                int.TryParse(txtLoai.Text, out int loaiVal);
                model.Loai = loaiVal;

                DbFormService.SaveFormCode(model.Id, model.Code, model.ServerCode, model.ClientCode, model.AeLayout, model.Name, model.ClassName, loaiVal);
                MessageBox.Show($"Đã cập nhật cấu trúc Form Công nợ [{model.Name}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            Panel pnlMainContainer = new Panel { Dock = DockStyle.Fill };
            pnlMainContainer.Controls.Add(tcSub);
            pnlMainContainer.Controls.Add(pnlHeader);
            pnlMainContainer.Controls.Add(tsAction);

            tab.Controls.Add(pnlMainContainer);
            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;
        }

        private static bool IsLastVisibleChild(DataGridView dgv, int rowIndex, int level)
        {
            for (int i = rowIndex + 1; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow nextRow = dgv.Rows[i];
                if (!nextRow.Visible) continue;

                if (nextRow.Tag is TreeRowInfo nextNode)
                {
                    if (nextNode.Level < level) return true;
                    if (nextNode.Level == level) return false;
                }
            }
            return true;
        }

        private static bool AncestorHasMoreChildren(DataGridView dgv, int rowIndex, int ancestorLevel)
        {
            for (int i = rowIndex + 1; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow nextRow = dgv.Rows[i];
                if (!nextRow.Visible) continue;

                if (nextRow.Tag is TreeRowInfo nextNode)
                {
                    if (nextNode.Level < ancestorLevel) return false;
                    if (nextNode.Level == ancestorLevel) return true;
                }
            }
            return false;
        }

        public static void AttachTreeGridEvents(DataGridView dgv)
        {
            dgv.CellPainting += (s, e) =>
            {
                // Custom Paint for Column 0 (Dữ liệu)
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    if (row.Tag is TreeRowInfo node)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                        Graphics g = e.Graphics;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                        int indentWidth = 16;
                        int xStart = e.CellBounds.Left + (node.Level * indentWidth) + 6;
                        int yMid = e.CellBounds.Top + (e.CellBounds.Height / 2);

                        // 1. Continuous Connector Dotted Lines
                        if (node.Level > 0)
                        {
                            using (Pen linePen = new Pen(Color.FromArgb(160, 170, 185), 1f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
                            {
                                // Draw continuing lines for all active ancestor levels
                                for (int lvl = 1; lvl < node.Level; lvl++)
                                {
                                    if (AncestorHasMoreChildren(dgv, e.RowIndex, lvl))
                                    {
                                        int ancX = e.CellBounds.Left + ((lvl - 1) * indentWidth) + 11;
                                        g.DrawLine(linePen, ancX, e.CellBounds.Top, ancX, e.CellBounds.Bottom);
                                    }
                                }

                                // Draw current node branch line (T-shape or L-corner)
                                int branchX = e.CellBounds.Left + ((node.Level - 1) * indentWidth) + 11;
                                bool isLast = IsLastVisibleChild(dgv, e.RowIndex, node.Level);

                                int yBottom = isLast ? yMid : e.CellBounds.Bottom;
                                g.DrawLine(linePen, branchX, e.CellBounds.Top, branchX, yBottom);
                                g.DrawLine(linePen, branchX, yMid, xStart - 3, yMid);
                            }
                        }

                        int curX = xStart;

                        // 2. Control Box: Expander [+] / [-] if parent, OR blank spacing if field
                        if (node.IsParent)
                        {
                            Rectangle boxRect = new Rectangle(curX, yMid - 4, 9, 9);
                            g.FillRectangle(Brushes.White, boxRect);
                            g.DrawRectangle(Pens.Gray, boxRect);

                            g.DrawLine(Pens.Black, boxRect.Left + 2, yMid, boxRect.Right - 2, yMid);
                            if (!node.IsExpanded)
                            {
                                g.DrawLine(Pens.Black, boxRect.Left + 4, boxRect.Top + 2, boxRect.Left + 4, boxRect.Bottom - 2);
                            }
                            curX += 14;
                        }
                        else
                        {
                            curX += 14; // Leave exact same space so checkboxes align vertically!
                        }

                        // 3. Checkbox [☐] / [☑] (Drawn on ALL rows)
                        Rectangle chkRect = new Rectangle(curX - 1, yMid - 6, 12, 12);
                        if (node.IsChecked)
                        {
                            using (Brush bgBrush = new SolidBrush(Color.FromArgb(0, 120, 215)))
                            {
                                g.FillRectangle(bgBrush, chkRect);
                            }
                            g.DrawRectangle(Pens.DarkBlue, chkRect);

                            using (Pen chkPen = new Pen(Color.White, 1.8f))
                            {
                                g.DrawLine(chkPen, chkRect.Left + 2.5f, yMid, chkRect.Left + 5f, chkRect.Bottom - 3f);
                                g.DrawLine(chkPen, chkRect.Left + 5f, chkRect.Bottom - 3f, chkRect.Right - 2.5f, chkRect.Top + 3f);
                            }
                        }
                        else
                        {
                            g.FillRectangle(Brushes.White, chkRect);
                            g.DrawRectangle(Pens.Gray, chkRect);
                        }
                        curX += 15;

                        // 4. Icon Drawing
                        if (node.NodeType == "ROOT")
                        {
                            DrawTableIcon(g, curX, yMid - 6);
                            curX += 18;
                        }
                        else
                        {
                            DrawColumnIcon(g, curX, yMid - 6);
                            curX += 16;
                        }

                        // 5. Text Drawing
                        Font font = (node.NodeType == "ROOT")
                            ? new Font("Segoe UI", 9F, FontStyle.Bold)
                            : new Font("Segoe UI", 9F, FontStyle.Regular);

                        Color textColor = (node.NodeType == "SUB_FIELD") ? Color.FromArgb(70, 80, 95) : Color.Black;

                        TextRenderer.DrawText(g, node.NodeText, font, new Point(curX, yMid - 8), textColor);

                        e.Handled = true;
                    }
                }

                // Hide Checkboxes in "Bắt buộc" (Col 8) & "Không tạo cột" (Col 9) for ROOT & FK_FIELD rows
                if ((e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    if (row.Tag is TreeRowInfo node && node.IsParent)
                    {
                        e.PaintBackground(e.CellBounds, true);
                        e.Handled = true;
                    }
                }
            };

            dgv.CellMouseClick += (s, e) =>
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    if (row.Tag is TreeRowInfo node)
                    {
                        int indentWidth = 16;
                        int relativeX = e.X;
                        int curX = node.Level * indentWidth + 6;

                        if (node.IsParent)
                        {
                            // Expander box click
                            if (relativeX >= curX - 2 && relativeX <= curX + 14)
                            {
                                node.IsExpanded = !node.IsExpanded;
                                ToggleChildRowsVisibility(dgv, row, node.IsExpanded);
                                dgv.InvalidateRow(e.RowIndex);
                                return;
                            }
                            curX += 14;
                        }
                        else
                        {
                            curX += 14;
                        }

                        // Checkbox click
                        if (relativeX >= curX - 2 && relativeX <= curX + 16)
                        {
                            node.IsChecked = !node.IsChecked;
                            dgv.InvalidateRow(e.RowIndex);
                            return;
                        }
                    }
                }
            };
        }

        private static void ToggleChildRowsVisibility(DataGridView dgv, DataGridViewRow parentRow, bool visible)
        {
            if (parentRow.Tag is TreeRowInfo parentNode)
            {
                foreach (int childIdx in parentNode.ChildRowIndices)
                {
                    if (childIdx >= 0 && childIdx < dgv.Rows.Count)
                    {
                        DataGridViewRow childRow = dgv.Rows[childIdx];
                        childRow.Visible = visible;

                        if (childRow.Tag is TreeRowInfo childNode && childNode.IsParent)
                        {
                            bool subVisible = visible && childNode.IsExpanded;
                            ToggleChildRowsVisibility(dgv, childRow, subVisible);
                        }
                    }
                }
            }
        }

        private static void DrawTableIcon(Graphics g, int x, int y)
        {
            using (Brush bHeader = new SolidBrush(Color.FromArgb(0, 102, 180)))
            using (Brush bBody = new SolidBrush(Color.White))
            using (Pen pBorder = new Pen(Color.FromArgb(50, 80, 120)))
            using (Pen pGrid = new Pen(Color.FromArgb(180, 200, 220)))
            {
                g.FillRectangle(bBody, x, y, 14, 12);
                g.FillRectangle(bHeader, x, y, 14, 4);
                g.DrawRectangle(pBorder, x, y, 14, 12);
                g.DrawLine(pGrid, x, y + 8, x + 14, y + 8);
                g.DrawLine(pGrid, x + 7, y + 4, x + 7, y + 12);
            }
        }

        private static void DrawColumnIcon(Graphics g, int x, int y)
        {
            using (Brush bHeader = new SolidBrush(Color.FromArgb(217, 120, 30)))
            using (Brush bBody = new SolidBrush(Color.White))
            using (Pen pBorder = new Pen(Color.FromArgb(160, 90, 20)))
            using (Pen pGrid = new Pen(Color.FromArgb(240, 200, 160)))
            {
                g.FillRectangle(bBody, x, y, 12, 12);
                g.FillRectangle(bHeader, x, y, 12, 4);
                g.DrawRectangle(pBorder, x, y, 12, 12);
                g.DrawLine(pGrid, x, y + 8, x + 12, y + 8);
                g.DrawLine(pGrid, x + 6, y + 4, x + 6, y + 12);
            }
        }

        public static string GetTableNameById(string tableId)
        {
            if (string.IsNullOrEmpty(tableId)) return "TTHUCHI";
            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    using (FbCommand cmd = new FbCommand("SELECT TRIM(NAME) FROM STABLEDESC WHERE ID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", tableId);
                        object val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value) return val.ToString();
                    }
                }
            }
            catch { }
            return "TTHUCHI";
        }

        public static string GetTableIdByName(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) return null;
            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    using (FbCommand cmd = new FbCommand("SELECT TRIM(ID) FROM STABLEDESC WHERE UPPER(TRIM(NAME)) = UPPER(TRIM(@name))", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", tableName);
                        object val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value) return val.ToString();
                    }
                }
            }
            catch { }
            return null;
        }

        private static string ResolveRefTableId(FbConnection conn, string rawColName, string existingRefId)
        {
            if (!string.IsNullOrEmpty(existingRefId)) return existingRefId;
            if (string.IsNullOrEmpty(rawColName)) return null;

            string colUpper = rawColName.Trim().ToUpper();
            if (colUpper.EndsWith("ID") && colUpper.Length > 2)
            {
                string strippedName = colUpper.Substring(0, colUpper.Length - 2);
                try
                {
                    using (FbCommand cmd = new FbCommand("SELECT TRIM(ID) FROM STABLEDESC WHERE UPPER(TRIM(NAME)) = UPPER(TRIM(@name))", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", strippedName);
                        object val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            return val.ToString().Trim();
                        }
                    }
                }
                catch { }
            }
            return null;
        }

        public static string GenerateDefaultCongNoHandlerCode(string className)
        {
            if (string.IsNullOrWhiteSpace(className)) className = "CongNo0Handler";
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
    public class {className} : ICongNoSupport
    {{
    }}
}}
";
        }

        public static Dictionary<string, bool> ParseCheckedFromAeLayout(string aeLayoutXml)
        {
            Dictionary<string, bool> checkedDict = new Dictionary<string, bool>();
            if (string.IsNullOrWhiteSpace(aeLayoutXml)) return checkedDict;

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

                            if (!string.IsNullOrEmpty(colId)) checkedDict[colId] = isChecked;
                            if (!string.IsNullOrEmpty(caption)) checkedDict[caption] = isChecked;
                        }
                    }
                }
            }
            catch { }
            return checkedDict;
        }

        private static DataGridView CreateTreeGrid()
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

            DataGridViewTextBoxColumn colGocData = new DataGridViewTextBoxColumn { HeaderText = "Dữ liệu", ReadOnly = true, Width = 340, MinimumWidth = 300 };
            DataGridViewTextBoxColumn colGocTitle = new DataGridViewTextBoxColumn { HeaderText = "Tiêu đề" };
            DataGridViewCheckBoxColumn colGocSum = new DataGridViewCheckBoxColumn { HeaderText = "Tổng cộng", Width = 70 };
            DataGridViewTextBoxColumn colGocSort = new DataGridViewTextBoxColumn { HeaderText = "Sắp xếp", Width = 70 };
            DataGridViewTextBoxColumn colGocParam = new DataGridViewTextBoxColumn { HeaderText = "Tham số", Width = 70 };
            DataGridViewTextBoxColumn colGocCond = new DataGridViewTextBoxColumn { HeaderText = "Điều kiện", Width = 90 };
            DataGridViewTextBoxColumn colGocReplace = new DataGridViewTextBoxColumn { HeaderText = "Thay thế", Width = 90 };
            DataGridViewTextBoxColumn colGocAlias = new DataGridViewTextBoxColumn { HeaderText = "Alias", Width = 70 };
            DataGridViewCheckBoxColumn colGocReq = new DataGridViewCheckBoxColumn { HeaderText = "Bắt buộc", Width = 70 };
            DataGridViewCheckBoxColumn colGocNoCol = new DataGridViewCheckBoxColumn { HeaderText = "Không tạo cột", Width = 90 };

            dgv.Columns.AddRange(new DataGridViewColumn[] { colGocData, colGocTitle, colGocSum, colGocSort, colGocParam, colGocCond, colGocReplace, colGocAlias, colGocReq, colGocNoCol });
            AttachTreeGridEvents(dgv);
            return dgv;
        }

        private static void UpdateHeaderAndTabs(FormModel model, Panel pnlHeader, TabControl tcSub, TabPage tabTongHop, TabPage tabCode, ref DataGridView dgvDoiTacNo, ref DataGridView dgvDonHang)
        {
            bool isTheoHoaDon = (model.Loai == 2 || model.FormType == 3);
            pnlHeader.Height = isTheoHoaDon ? 35 : 95;

            foreach (Control c in pnlHeader.Controls)
            {
                if (c.Name == "lblNoteLoai" || c.Name == "lblClass" || c.Name == "txtClassName" ||
                    c.Name == "lblDesc1" || c.Name == "lblDesc2" || c.Name == "lblDesc3")
                {
                    c.Visible = !isTheoHoaDon;
                }
            }

            tcSub.TabPages.Clear();
            Dictionary<string, bool> checkedMap = ParseCheckedFromAeLayout(model.AeLayout);

            if (isTheoHoaDon)
            {
                // CÔNG NỢ THEO HÓA ĐƠN: Chỉ có 2 tab Đối tác nợ & Đơn hàng (Không có Dữ liệu tổng hợp, Không có Code)
                TabPage tabDoiTac = new TabPage((model.Loai == 1) ? "Nhà cung cấp" : "Đối tác nợ");
                TabPage tabOrder = new TabPage("Đơn hàng");

                dgvDoiTacNo = CreateTreeGrid();
                dgvDonHang = CreateTreeGrid();

                tabDoiTac.Controls.Add(dgvDoiTacNo);
                tabOrder.Controls.Add(dgvDonHang);

                tcSub.TabPages.Add(tabDoiTac);
                tcSub.TabPages.Add(tabOrder);

                if (!string.IsNullOrEmpty(model.AeLayout))
                {
                    string doiTacTable = (model.Loai == 1) ? "DNHACUNGCAP" : "DKHACHHANG";
                    LoadTableTreeGridFromDb(doiTacTable, dgvDoiTacNo, checkedMap);
                    LoadTableTreeGridFromDb("TDONHANG", dgvDonHang, checkedMap);
                }
                else
                {
                    dgvDoiTacNo.Rows.Clear();
                    dgvDonHang.Rows.Clear();
                }
            }
            else
            {
                // CÔNG NỢ TRỪ ĐUÔI: Có 3 tab Bảng gốc, Dữ liệu tổng hợp, Code
                TabPage tabBangGoc = new TabPage("Bảng gốc");
                dgvDoiTacNo = CreateTreeGrid();
                dgvDonHang = null;
                tabBangGoc.Controls.Add(dgvDoiTacNo);

                tcSub.TabPages.Add(tabBangGoc);

                if (!string.IsNullOrEmpty(model.AeLayout))
                {
                    string targetTable = !string.IsNullOrEmpty(model.STableDescId)
                        ? GetTableNameById(model.STableDescId)
                        : ((model.Loai == 1) ? "DNHACUNGCAP" : "DKHACHHANG");

                    LoadTableTreeGridFromDb(targetTable, dgvDoiTacNo, checkedMap);
                }
                else
                {
                    dgvDoiTacNo.Rows.Clear();
                }

                tcSub.TabPages.Add(tabTongHop);
                tcSub.TabPages.Add(tabCode);
            }
        }

        private static void LoadTableTreeGridFromDb(string tableName, DataGridView dgv, Dictionary<string, bool> checkedMap)
        {
            dgv.Rows.Clear();
            if (string.IsNullOrEmpty(tableName)) return;

            string targetTableId = null;
            string targetTableDesc = null;

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    using (FbCommand cmd = new FbCommand("SELECT ID, DESCRIPTION FROM STABLEDESC WHERE UPPER(TRIM(NAME)) = UPPER(TRIM(@name))", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", tableName);
                        using (FbDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                targetTableId = rdr["ID"]?.ToString()?.Trim();
                                targetTableDesc = rdr["DESCRIPTION"] != DBNull.Value ? rdr["DESCRIPTION"]?.ToString()?.Trim() : tableName;
                            }
                        }
                    }
                }
            }
            catch { }

            if (string.IsNullOrEmpty(targetTableId)) return;
            if (string.IsNullOrEmpty(targetTableDesc)) targetTableDesc = tableName;

            TreeRowInfo rootNode = new TreeRowInfo
            {
                Level = 0,
                IsParent = true,
                IsExpanded = true,
                IsChecked = false,
                NodeText = targetTableDesc,
                NodeType = "ROOT",
                TableId = targetTableId
            };

            int rootIdx = dgv.Rows.Add(targetTableDesc, "", false, "", "", "", "", "", false, false);
            DataGridViewRow rootRow = dgv.Rows[rootIdx];
            rootNode.RowIndex = rootIdx;
            rootRow.Tag = rootNode;
            rootRow.DefaultCellStyle.BackColor = Color.FromArgb(240, 243, 248);

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = @"
                        SELECT ID, NAME, CAPTION, REFTABLEID 
                        FROM SCOLUMN 
                        WHERE UPPER(TRIM(STABLEDESCID)) = UPPER(TRIM(@TableId))";

                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TableId", targetTableId);
                        using (FbDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                string scolId = rdr["ID"]?.ToString()?.Trim();
                                string rawColName = rdr["NAME"]?.ToString()?.Trim();
                                string colName = rawColName?.ToUpper();
                                string caption = rdr["CAPTION"] != DBNull.Value ? rdr["CAPTION"]?.ToString()?.Trim() : rawColName;
                                string refTableId = rdr["REFTABLEID"] != DBNull.Value ? rdr["REFTABLEID"]?.ToString()?.Trim() : null;

                                refTableId = ResolveRefTableId(conn, rawColName, refTableId);
                                bool isFk = !string.IsNullOrEmpty(refTableId);
                                bool isReq = colName == "NAME" || colName == "SOPHIEU";

                                bool isChecked = false;
                                if (checkedMap.TryGetValue(scolId, out bool c1)) isChecked = c1;
                                else if (checkedMap.TryGetValue(caption, out bool c2)) isChecked = c2;
                                else isChecked = colName == "NAME" || colName == "SOPHIEU";

                                TreeRowInfo colNode = new TreeRowInfo
                                {
                                    Level = 1,
                                    IsParent = isFk,
                                    IsExpanded = false,
                                    IsChecked = isChecked,
                                    NodeText = caption,
                                    NodeType = isFk ? "FK_FIELD" : "FIELD",
                                    ScolId = scolId,
                                    RefTableId = refTableId
                                };

                                int colIdx = dgv.Rows.Add(caption, "", false, "", "", "", "", "", isReq, false);
                                DataGridViewRow colRow = dgv.Rows[colIdx];
                                colNode.RowIndex = colIdx;
                                colRow.Tag = colNode;
                                rootNode.ChildRowIndices.Add(colIdx);

                                if (isFk)
                                {
                                    LoadRefSubFieldsFromDb(conn, refTableId, dgv, colNode, checkedMap, 2);
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private static void LoadRefSubFieldsFromDb(FbConnection conn, string refTableId, DataGridView dgv, TreeRowInfo parentColNode, Dictionary<string, bool> checkedMap, int currentLevel)
        {
            try
            {
                string sqlSub = @"
                    SELECT ID, NAME, CAPTION, REFTABLEID 
                    FROM SCOLUMN 
                    WHERE UPPER(TRIM(STABLEDESCID)) = UPPER(TRIM(@RefId))";

                using (FbCommand cmdSub = new FbCommand(sqlSub, conn))
                {
                    cmdSub.Parameters.AddWithValue("@RefId", refTableId);
                    using (FbDataReader rdrSub = cmdSub.ExecuteReader())
                    {
                        while (rdrSub.Read())
                        {
                            string scolId = rdrSub["ID"]?.ToString().Trim();
                            string rawColName = rdrSub["NAME"]?.ToString().Trim();
                            string caption = rdrSub["CAPTION"] != DBNull.Value ? rdrSub["CAPTION"]?.ToString().Trim() : rawColName;
                            string subRefTableId = rdrSub["REFTABLEID"] != DBNull.Value ? rdrSub["REFTABLEID"]?.ToString().Trim() : null;

                            subRefTableId = ResolveRefTableId(conn, rawColName, subRefTableId);
                            bool isSubFk = !string.IsNullOrEmpty(subRefTableId);

                            bool isChecked = false;
                            if (checkedMap.TryGetValue(scolId, out bool c1)) isChecked = c1;
                            else if (checkedMap.TryGetValue(caption, out bool c2)) isChecked = c2;

                            TreeRowInfo subNode = new TreeRowInfo
                            {
                                Level = currentLevel,
                                IsParent = isSubFk,
                                IsExpanded = false,
                                IsChecked = isChecked,
                                NodeText = caption,
                                NodeType = isSubFk ? "FK_FIELD" : "SUB_FIELD",
                                ScolId = scolId,
                                RefTableId = subRefTableId
                            };

                            int subIdx = dgv.Rows.Add(caption, "", false, "", "", "", "", "", false, false);
                            DataGridViewRow subRow = dgv.Rows[subIdx];
                            subNode.RowIndex = subIdx;
                            subRow.Tag = subNode;
                            bool parentVisible = parentColNode.RowIndex >= 0 && parentColNode.RowIndex < dgv.Rows.Count && dgv.Rows[parentColNode.RowIndex].Visible;
                            subRow.Visible = parentColNode.IsExpanded && parentVisible;

                            parentColNode.ChildRowIndices.Add(subIdx);

                            if (isSubFk && currentLevel < 4)
                            {
                                LoadRefSubFieldsFromDb(conn, subRefTableId, dgv, subNode, checkedMap, currentLevel + 1);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private static void LoadCongNoTongHopFromDb(FormModel model, DataGridView dgv)
        {
            dgv.Rows.Clear();
            string dbAeLayout = model.AeLayout;

            if (string.IsNullOrWhiteSpace(dbAeLayout))
            {
                try
                {
                    using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                    {
                        conn.Open();
                        string sql = "SELECT AELAYOUT FROM SFORM WHERE UPPER(TRIM(ID)) = UPPER(TRIM(@id)) OR UPPER(TRIM(NAME)) = UPPER(TRIM(@name))";
                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", model.Id ?? "");
                            cmd.Parameters.AddWithValue("@name", model.Name ?? "");
                            object val = cmd.ExecuteScalar();
                            if (val != null && val != DBNull.Value)
                            {
                                dbAeLayout = val.ToString();
                            }
                        }
                    }
                }
                catch { }
            }

            if (!string.IsNullOrWhiteSpace(dbAeLayout))
            {
                try
                {
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.LoadXml(dbAeLayout);
                    var dataNodes = doc.SelectNodes("//DocumentElement/Data");
                    if (dataNodes != null)
                    {
                        foreach (System.Xml.XmlNode n in dataNodes)
                        {
                            string table = n["TABLE"]?.InnerText ?? n["table"]?.InnerText;
                            string field = n["FIELD"]?.InnerText ?? n["field"]?.InnerText;
                            string linkCol = n["LINKCOL"]?.InnerText ?? n["linkcol"]?.InnerText;
                            string cond = n["CONDITION"]?.InnerText ?? n["condition"]?.InnerText ?? "";

                            if (!string.IsNullOrEmpty(table))
                            {
                                dgv.Rows.Add(table, field, linkCol, cond);
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private static string BuildCongNoAeLayoutXml(List<DataGridView> masterGrids, DataGridView dgvTongHop)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<DocumentElement>");

                StringBuilder masterSb = new StringBuilder();
                masterSb.AppendLine("<DocumentElement>");

                if (masterGrids != null)
                {
                    foreach (var dgv in masterGrids)
                    {
                        if (dgv == null) continue;
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.Tag is TreeRowInfo node)
                            {
                                if (node.NodeType == "ROOT") continue;

                                string scolId = node.ScolId;
                                string caption = row.Cells[1].Value?.ToString() ?? node.NodeText;
                                bool sum = Convert.ToBoolean(row.Cells[2].Value ?? false);
                                string sort = row.Cells[3].Value?.ToString() ?? "";
                                string param = row.Cells[4].Value?.ToString() ?? "";
                                string cond = row.Cells[5].Value?.ToString() ?? "";
                                string replace = row.Cells[6].Value?.ToString() ?? "";
                                string alias = row.Cells[7].Value?.ToString() ?? "";
                                bool req = Convert.ToBoolean(row.Cells[8].Value ?? false);
                                bool nocol = Convert.ToBoolean(row.Cells[9].Value ?? false);

                                masterSb.AppendLine("  <Data>");
                                masterSb.AppendLine($"    <CHECKED>{(node.IsChecked ? "true" : "false")}</CHECKED>");
                                if (!string.IsNullOrEmpty(scolId)) masterSb.AppendLine($"    <COLID>{scolId}</COLID>");
                                masterSb.AppendLine($"    <CAPTION>{caption}</CAPTION>");
                                masterSb.AppendLine($"    <TOTAL>{(sum ? "true" : "")}</TOTAL>");
                                masterSb.AppendLine($"    <SORT>{sort}</SORT>");
                                masterSb.AppendLine($"    <CONDITION>{cond}</CONDITION>");
                                masterSb.AppendLine($"    <NOTEMPTY>{(req ? "true" : "false")}</NOTEMPTY>");
                                masterSb.AppendLine($"    <KHONGTAOCOT>{(nocol ? "true" : "false")}</KHONGTAOCOT>");
                                masterSb.AppendLine($"    <REPLACE>{replace}</REPLACE>");
                                masterSb.AppendLine($"    <ALIAS>{alias}</ALIAS>");
                                masterSb.AppendLine("  </Data>");
                            }
                        }
                    }
                }
                masterSb.AppendLine("</DocumentElement>");
                string masterB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(masterSb.ToString()));

                sb.AppendLine("  <Data>");
                sb.AppendLine($"    <MASTER>{masterB64}</MASTER>");
                sb.AppendLine("  </Data>");

                foreach (DataGridViewRow row in dgvTongHop.Rows)
                {
                    string table = row.Cells[0].Value?.ToString() ?? "";
                    string field = row.Cells[1].Value?.ToString() ?? "";
                    string linkCol = row.Cells[2].Value?.ToString() ?? "";
                    string cond = row.Cells[3].Value?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(table))
                    {
                        sb.AppendLine("  <Data>");
                        sb.AppendLine($"    <TABLE>{table}</TABLE>");
                        sb.AppendLine($"    <FIELD>{field}</FIELD>");
                        sb.AppendLine($"    <LINKCOL>{linkCol}</LINKCOL>");
                        if (!string.IsNullOrEmpty(cond)) sb.AppendLine($"    <CONDITION>{cond}</CONDITION>");
                        sb.AppendLine("  </Data>");
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

        public static List<string> LoadAllTableNamesFromDb()
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

        private static void ShowCongNoTongHopRowDialog(Form parentForm, DataGridView dgv, bool isEdit)
        {
            DataGridViewRow selRow = (isEdit && dgv.SelectedRows.Count > 0) ? dgv.SelectedRows[0] : null;
            if (isEdit && selRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (Form dlg = new Form())
            {
                dlg.Text = isEdit ? "Sửa dữ liệu tổng hợp" : "Thêm dữ liệu tổng hợp";
                dlg.Size = new Size(520, 260);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.Font = new Font("Segoe UI", 9F);

                Label lblTable = new Label { Text = "Bảng dữ liệu:", Location = new Point(20, 20), AutoSize = true };
                ComboBox cboTable = new ComboBox { Location = new Point(130, 17), Width = 340, DropDownStyle = ComboBoxStyle.DropDown };
                cboTable.Items.AddRange(LoadAllTableNamesFromDb().ToArray());
                if (selRow != null) cboTable.Text = selRow.Cells[0].Value?.ToString() ?? "";

                Label lblSum = new Label { Text = "Cột tổng:", Location = new Point(20, 55), AutoSize = true };
                TextBox txtSum = new TextBox { Location = new Point(130, 52), Width = 340 };
                if (selRow != null) txtSum.Text = selRow.Cells[1].Value?.ToString() ?? "";

                Label lblLink = new Label { Text = "Cột liên kết:", Location = new Point(20, 90), AutoSize = true };
                TextBox txtLink = new TextBox { Location = new Point(130, 87), Width = 340 };
                if (selRow != null) txtLink.Text = selRow.Cells[2].Value?.ToString() ?? "";

                Label lblCond = new Label { Text = "Điều kiện:", Location = new Point(20, 125), AutoSize = true };
                TextBox txtCond = new TextBox { Location = new Point(130, 122), Width = 340 };
                if (selRow != null) txtCond.Text = selRow.Cells[3].Value?.ToString() ?? "";

                Button btnOK = new Button { Text = "Đồng ý", DialogResult = DialogResult.OK, Location = new Point(280, 170), Width = 90, Height = 30 };
                Button btnCancel = new Button { Text = "Hủy bỏ", DialogResult = DialogResult.Cancel, Location = new Point(380, 170), Width = 90, Height = 30 };

                dlg.Controls.AddRange(new Control[] { lblTable, cboTable, lblSum, txtSum, lblLink, txtLink, lblCond, txtCond, btnOK, btnCancel });
                dlg.AcceptButton = btnOK;
                dlg.CancelButton = btnCancel;

                if (dlg.ShowDialog(parentForm) == DialogResult.OK)
                {
                    string t = cboTable.Text.Trim();
                    string s = txtSum.Text.Trim();
                    string l = txtLink.Text.Trim();
                    string c = txtCond.Text.Trim();

                    if (isEdit && selRow != null)
                    {
                        selRow.Cells[0].Value = t;
                        selRow.Cells[1].Value = s;
                        selRow.Cells[2].Value = l;
                        selRow.Cells[3].Value = c;
                    }
                    else
                    {
                        dgv.Rows.Add(t, s, l, c);
                    }
                }
            }
        }
    }
}
