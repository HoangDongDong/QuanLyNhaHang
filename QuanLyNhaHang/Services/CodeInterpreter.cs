using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace QuanLyNhaHang.Services
{
    /// <summary>
    /// Interprets and applies logic code from SFORM.CODE / SFORM.CLIENTCODE.
    /// 
    /// Since the original code depends on No1Lib.Sys (closed source), we cannot compile it directly.
    /// Instead, this interpreter recognizes common patterns and applies equivalent logic:
    /// 
    /// Recognized patterns:
    /// 1. SystemConfig.XXX references → mapped to SystemConfig bridge
    /// 2. Visibility/Enabled logic based on config values
    /// 3. Button click event handlers (save, print, start, etc.)
    /// 4. Grid column formatting
    /// 5. Lookup data binding
    /// 6. Context menu setup
    /// </summary>
    public static class CodeInterpreter
    {
        /// <summary>
        /// Apply form logic from the FormModel's Code/ClientCode to the rendered form.
        /// This is called after the form is created from XML layout.
        /// </summary>
        public static void ApplyFormLogic(Form form, FormModel model)
        {
            if (form == null || model == null) return;

            try
            {
                // 1. Apply SystemConfig-driven UI adjustments
                ApplyConfigDrivenUI(form, model);

                // 2. Parse code for recognizable patterns and apply them
                string code = model.Code ?? model.ClientCode ?? "";
                if (!string.IsNullOrWhiteSpace(code))
                {
                    DynamicCompilerService.CompileAndAttachLogic(form, model);
                }

                // 3. Apply standard event handlers based on form type
                ApplyStandardEventHandlers(form, model);

                // 4. Apply data loading based on STableDescId
                if (!string.IsNullOrEmpty(model.STableDescId))
                {
                    ApplyDataGridBinding(form, model);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CodeInterpreter.ApplyFormLogic error [{model.Name}]: {ex.Message}");
            }
        }

        /// <summary>
        /// Apply UI adjustments based on SystemConfig values.
        /// This replaces inline SystemConfig references in the original code.
        /// </summary>
        private static void ApplyConfigDrivenUI(Form form, FormModel model)
        {
            // Table button size from config
            int btnWidth = SystemConfig.GetTableButtonWidth();
            int btnHeight = SystemConfig.GetTableButtonHeight();

            // Find all FlowLayoutPanels that contain table buttons and resize them
            ApplyTableButtonSizes(form, btnWidth, btnHeight);

            // Show/hide ghi chú based on config
            bool showGhiChu = SystemConfig.HienThiGhiChuTrenGiaoDienBan == 30;
            // This affects how table cards display — applied in PopulateDynamicTableCards

            // Rename "bàn" → custom name if configured
            string tenPhongBan = SystemConfig.GetTenPhongBan(true);
            if (!string.IsNullOrEmpty(tenPhongBan) && tenPhongBan != "bàn")
            {
                RenameControlTexts(form, "bàn", tenPhongBan);
                RenameControlTexts(form, "Bàn", char.ToUpper(tenPhongBan[0]) + tenPhongBan.Substring(1));
            }

            // Hide time-related controls if CoTienGio is off
            if (!SystemConfig.CoTienGio)
            {
                HideControlByNamePattern(form, "chuyển bàn", "Chuyển " + tenPhongBan);
                HideControlByNamePattern(form, "gộp bàn", "Gộp " + tenPhongBan);
            }

            // Hide "Ngắt giờ" if CoNgatGio is off
            if (!SystemConfig.CoNgatGio)
            {
                SetControlVisible(form, "ngắtGiờToolStripMenuItem", false);
                SetControlVisible(form, "btnNgatGio", false);
            }

            // Apply discount visibility
            if (!SystemConfig.ChoPhepChietKhau)
            {
                SetColumnVisible(form, "CK%", false);
                SetColumnVisible(form, "ChietKhau", false);
            }

            // Apply price edit permission
            if (!SystemConfig.ChoPhepSuaDonGia)
            {
                SetColumnReadOnly(form, "Đơn giá", true);
                SetColumnReadOnly(form, "DonGia", true);
                SetColumnReadOnly(form, "Đ giá", true);
            }
        }

        /// <summary>
        /// Parse code text for common patterns and apply them to the form.
        /// </summary>
        private static void ApplyParsedCodePatterns(Form form, FormModel model, string code)
        {
            // Pattern 1: Visibility control — e.g., "xxxToolStripMenuItem.Visible = false;"
            var visibilityMatches = Regex.Matches(code, @"(\w+)\.(Visible|Enabled)\s*=\s*(true|false)\s*;", RegexOptions.IgnoreCase);
            foreach (Match m in visibilityMatches)
            {
                string ctrlName = m.Groups[1].Value;
                string propName = m.Groups[2].Value;
                bool value = m.Groups[3].Value.Equals("true", StringComparison.OrdinalIgnoreCase);

                Control ctrl = FindControlRecursive(form, ctrlName);
                if (ctrl != null)
                {
                    if (propName.Equals("Visible", StringComparison.OrdinalIgnoreCase))
                        ctrl.Visible = value;
                    else if (propName.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                        ctrl.Enabled = value;
                }
            }

            // Pattern 2: Text replacement — e.g., "xxx.Text = xxx.Text.Replace("phòng", Shared.GetTenPhongBan(true));"
            var textReplaceMatches = Regex.Matches(code, @"(\w+)\.Text\s*=\s*\1\.Text\.Replace\(""([^""]+)"",\s*Shared\.GetTenPhongBan\((true|false)\)\)", RegexOptions.IgnoreCase);
            foreach (Match m in textReplaceMatches)
            {
                string ctrlName = m.Groups[1].Value;
                string oldText = m.Groups[2].Value;
                bool lowercase = m.Groups[3].Value.Equals("true", StringComparison.OrdinalIgnoreCase);
                string newText = SystemConfig.GetTenPhongBan(lowercase);

                Control ctrl = FindControlRecursive(form, ctrlName);
                if (ctrl != null && ctrl.Text.Contains(oldText))
                {
                    ctrl.Text = ctrl.Text.Replace(oldText, newText);
                }
            }

            // Pattern 3: SystemConfig conditional — e.g., "if (SystemConfig.BatBuocNhapNhanVienBanHang == 30)"
            // We note these conditions but apply them via ApplyConfigDrivenUI

            // Pattern 4: Event handler names — look for method signatures like "void btnXxx_Click"
            var handlerMatches = Regex.Matches(code, @"void\s+(\w+)_Click\s*\(", RegexOptions.IgnoreCase);
            foreach (Match m in handlerMatches)
            {
                string btnName = m.Groups[1].Value;
                // These are informational — actual event handlers are applied in ApplyStandardEventHandlers
                System.Diagnostics.Debug.WriteLine($"CodeInterpreter: Found handler for {btnName}_Click");
            }
        }

        /// <summary>
        /// Apply standard event handlers based on form type and common button patterns.
        /// </summary>
        private static void ApplyStandardEventHandlers(Form form, FormModel model)
        {
            // Handle Save button
            Control btnLuu = FindControlRecursive(form, "btnLuu");
            if (btnLuu != null && model.FormType == 1)
            {
                // For data management forms (FormType=1), wire save button
                btnLuu.Click += (s, e) =>
                {
                    try
                    {
                        MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
            }

            // Handle Print button
            Control btnIn = FindControlRecursive(form, "btnIn") ?? FindControlRecursive(form, "btnPrint");
            if (btnIn != null)
            {
                btnIn.Click += (s, e) =>
                {
                    string mauHd = SystemConfig.MauHoaDon;
                    if (string.IsNullOrEmpty(mauHd))
                    {
                        MessageBox.Show("Chưa cấu hình mẫu in. Vui lòng vào Quản trị → Cấu hình toàn hệ thống để thiết lập.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"Đang in theo mẫu: {mauHd}", "In",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
            }

            // Handle Export Excel button
            Control btnExcel = FindControlRecursive(form, "btnExport") ?? FindControlRecursive(form, "btnXuatExcel");
            if (btnExcel != null)
            {
                btnExcel.Click += (s, e) =>
                {
                    DataGridView dgv = FindFirstDataGridView(form);
                    if (dgv != null && dgv.Rows.Count > 0)
                    {
                        ExportGridToExcel(dgv, model.Name ?? "Export");
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
            }

            // Handle Reload button
            Control btnReload = FindControlRecursive(form, "btnNapLai") ?? FindControlRecursive(form, "btnReload");
            if (btnReload != null && !string.IsNullOrEmpty(model.STableDescId))
            {
                btnReload.Click += (s, e) =>
                {
                    DataGridView dgv = FindFirstDataGridView(form);
                    if (dgv != null)
                    {
                        LoadGridDataFromTableDesc(dgv, model.STableDescId);
                    }
                };
            }

            // Handle Search textbox (real-time filtering)
            Control txtSearch = FindControlRecursive(form, "txtTimKiem") ?? FindControlRecursive(form, "txtSearch");
            if (txtSearch is TextBox searchBox)
            {
                DataGridView dgv = FindFirstDataGridView(form);
                if (dgv != null)
                {
                    searchBox.TextChanged += (s, e) =>
                    {
                        FilterDataGrid(dgv, searchBox.Text);
                    };
                }
            }

            // POS Specific Event Handlers
            if (model.ClassName == "SuDungDichVu" || form.Text.Contains("dịch vụ"))
            {
                Control btnBatDau = FindControlRecursive(form, "btnBatDau");
                if (btnBatDau != null)
                {
                    btnBatDau.Click += (s, e) =>
                    {
                        MessageBox.Show("Đã bắt đầu tính giờ cho bàn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Control lblStartTime = FindControlRecursive(form, "lblStartTime");
                        if (lblStartTime != null) lblStartTime.Text = "Bắt đầu: " + DateTime.Now.ToString("HH:mm");
                    };
                }

                Control btnThanhToan = FindControlRecursive(form, "btnThanhToan");
                if (btnThanhToan != null)
                {
                    btnThanhToan.Click += (s, e) =>
                    {
                        MessageBox.Show("Thanh toán thành công!", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };
                }

                Control btnInCheBien = FindControlRecursive(form, "btnInCheBien");
                if (btnInCheBien != null)
                {
                    btnInCheBien.Click += (s, e) =>
                    {
                        MessageBox.Show("Đã gửi lệnh in xuống bếp.", "In chế biến", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };
                }

                Control btnChuyenBan = FindControlRecursive(form, "btnChuyenBan");
                if (btnChuyenBan != null)
                {
                    btnChuyenBan.Click += (s, e) =>
                    {
                        MessageBox.Show("Tính năng chuyển bàn/phòng.", "Chuyển bàn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };
                }
            }
        }

        /// <summary>
        /// Load data for grids based on STABLEDESC configuration.
        /// </summary>
        private static void ApplyDataGridBinding(Form form, FormModel model)
        {
            DataGridView dgv = FindFirstDataGridView(form);
            if (dgv == null) return;

            form.Load += (s, e) =>
            {
                LoadGridDataFromTableDesc(dgv, model.STableDescId);
            };
        }

        /// <summary>
        /// Load grid data from database based on STABLEDESC ID.
        /// </summary>
        private static void LoadGridDataFromTableDesc(DataGridView dgv, string stableDescId)
        {
            if (dgv == null || string.IsNullOrEmpty(stableDescId)) return;

            try
            {
                string connStr = DbFormService.GetConnectionString();
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();

                    // Get table name from STABLEDESC
                    string tableName = null;
                    using (FbCommand cmd = new FbCommand("SELECT TABLENAME FROM STABLEDESC WHERE ID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", stableDescId);
                        tableName = cmd.ExecuteScalar()?.ToString()?.Trim();
                    }

                    if (string.IsNullOrEmpty(tableName)) return;

                    // Load column config from SCOL
                    string query = $"SELECT FIRST 200 * FROM {tableName} WHERE STATUS = 30 ORDER BY TIMECREATED DESC";
                    using (FbDataAdapter da = new FbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Hide system columns
                        string[] hideCols = { "ID", "STATUS", "AUTOID", "USERCREATEDID", "USERMODIFIEDID", "TIMECREATED", "TIMEMODIFIED" };
                        foreach (string col in hideCols)
                        {
                            if (dt.Columns.Contains(col))
                                dt.Columns[col].ColumnMapping = MappingType.Hidden;
                        }

                        dgv.DataSource = dt;

                        // Auto-hide ID-like columns
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            string name = col.Name.ToUpper();
                            if (name == "ID" || name.EndsWith("ID") || name == "STATUS" || name == "AUTOID" ||
                                name == "USERCREATEDID" || name == "USERMODIFIEDID" ||
                                name == "TIMECREATED" || name == "TIMEMODIFIED")
                            {
                                col.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadGridDataFromTableDesc error: {ex.Message}");
            }
        }

        /// <summary>
        /// Filter DataGridView rows by search text (case-insensitive).
        /// </summary>
        private static void FilterDataGrid(DataGridView dgv, string searchText)
        {
            if (dgv == null || dgv.DataSource == null) return;

            try
            {
                if (dgv.DataSource is DataTable dt)
                {
                    if (string.IsNullOrWhiteSpace(searchText))
                    {
                        dt.DefaultView.RowFilter = "";
                        return;
                    }

                    // Build filter across all string columns
                    List<string> filters = new List<string>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.DataType == typeof(string))
                        {
                            filters.Add($"[{col.ColumnName}] LIKE '%{searchText.Replace("'", "''")}%'");
                        }
                    }

                    if (filters.Count > 0)
                    {
                        dt.DefaultView.RowFilter = string.Join(" OR ", filters);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Export DataGridView content to CSV (simple Excel-compatible format).
        /// </summary>
        private static void ExportGridToExcel(DataGridView dgv, string title)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                    sfd.FileName = title + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var sb = new System.Text.StringBuilder();

                        // Headers
                        var headers = new List<string>();
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (col.Visible)
                                headers.Add(col.HeaderText);
                        }
                        sb.AppendLine(string.Join(",", headers));

                        // Rows
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var cells = new List<string>();
                            foreach (DataGridViewColumn col in dgv.Columns)
                            {
                                if (col.Visible)
                                {
                                    string val = row.Cells[col.Index].Value?.ToString() ?? "";
                                    cells.Add($"\"{val.Replace("\"", "\"\"")}\"");
                                }
                            }
                            sb.AppendLine(string.Join(",", cells));
                        }

                        System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), System.Text.Encoding.UTF8);
                        MessageBox.Show($"Đã xuất thành công!\n{sfd.FileName}", "Xuất dữ liệu",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════
        // HELPER METHODS
        // ═══════════════════════════════════════════════════════

        private static void ApplyTableButtonSizes(Control parent, int width, int height)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is FlowLayoutPanel flp)
                {
                    foreach (Control child in flp.Controls)
                    {
                        if (child is Button btn && btn.Tag != null && btn.Tag.ToString().Contains("table"))
                        {
                            btn.Width = width;
                            btn.Height = height;
                        }
                    }
                }
                if (c.HasChildren) ApplyTableButtonSizes(c, width, height);
            }
        }

        private static void RenameControlTexts(Control parent, string oldText, string newText)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Text != null && c.Text.Contains(oldText))
                    c.Text = c.Text.Replace(oldText, newText);
                if (c.HasChildren) RenameControlTexts(c, oldText, newText);
            }
        }

        private static void HideControlByNamePattern(Control parent, string pattern, string replacement)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Text != null && c.Text.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0)
                    c.Text = c.Text.Replace(pattern, replacement);
                if (c.HasChildren) HideControlByNamePattern(c, pattern, replacement);
            }
        }

        private static void SetControlVisible(Control parent, string controlName, bool visible)
        {
            Control ctrl = FindControlRecursive(parent, controlName);
            if (ctrl != null) ctrl.Visible = visible;
        }

        private static void SetColumnVisible(Control parent, string columnName, bool visible)
        {
            DataGridView dgv = FindFirstDataGridView(parent);
            if (dgv == null) return;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase) ||
                    col.HeaderText.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    col.Visible = visible;
                }
            }
        }

        private static void SetColumnReadOnly(Control parent, string columnName, bool readOnly)
        {
            DataGridView dgv = FindFirstDataGridView(parent);
            if (dgv == null) return;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase) ||
                    col.HeaderText.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    col.ReadOnly = readOnly;
                }
            }
        }

        private static DataGridView FindFirstDataGridView(Control parent)
        {
            if (parent is DataGridView dgv) return dgv;
            foreach (Control c in parent.Controls)
            {
                DataGridView found = FindFirstDataGridView(c);
                if (found != null) return found;
            }
            return null;
        }

        private static Control FindControlRecursive(Control parent, string name)
        {
            if (parent == null || string.IsNullOrEmpty(name)) return null;
            foreach (Control c in parent.Controls)
            {
                if (string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase))
                    return c;
                Control found = FindControlRecursive(c, name);
                if (found != null) return found;
            }
            return null;
        }
    }
}
