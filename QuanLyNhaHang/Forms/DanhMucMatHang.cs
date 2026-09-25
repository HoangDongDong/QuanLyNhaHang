using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using DbMapping;
using No1Lib.Db;
using No1Lib.Sys;
using No1Run;
using SysConfig = No1Lib.Sys.Config;

namespace QuanLyNhaHang.Forms
{
    public partial class DanhMucMatHang : Form
    {
        private TreeGridMg _mg;
        private Label _lblKhoiTao;
        private Label _lblKhoiTaoBoi;
        private Label _lblSuaDoiGanNhat;
        private Label _lblSuaDoiBoi;

        public DanhMucMatHang()
        {
            this.Text = "Danh mục mặt hàng";
            this.Size = new Size(1100, 680);
            this.StartPosition = FormStartPosition.CenterParent;

            InitializeForm();
        }

        private void InitializeForm()
        {
            try
            {
                TDONHANG0Ae.EnsureNo1LibInitialized();
            }
            catch { }

            try
            {
                Database db = SysConfig.Db;
                if (db == null)
                {
                    db = new Database("localhost", "SYSDBA", "masterkey", Program.CurrentDatabasePath ?? @"d:\QuanLyNhaHang\Database\DEMO.FDB");
                    db.ReConnect();
                    SysConfig.Db = db;
                    DbConfig.Database = db;
                    DbConfig.UserID = "admin";
                    DbConfig.UserName = "Administrator";
                    DbConfig.IsAdmin = true;
                    SystemConfig.Db = db;
                    try { DbMapping.BaseSystemConfig.Refresh(); } catch { }
                    TDONHANG0Ae.EnsureNo1LibInitialized();
                }

                STABLEDESCRow tableRow = null;
                SMENURow menuRow = null;

                try
                {
                    DataTable dtTable = db.GetTable("SELECT * FROM STABLEDESC WHERE NAME='DMATHANG'");
                    if (dtTable != null && dtTable.Rows.Count > 0)
                    {
                        tableRow = new STABLEDESCRow(dtTable.Rows[0]);
                    }

                    DataTable dtMenu = db.GetTable("SELECT * FROM SMENU WHERE ID='f3784a00-a86f-44d6-86b8-01187cc1a5e2' OR NAME LIKE '%mặt hàng%'");
                    if (dtMenu != null && dtMenu.Rows.Count > 0)
                    {
                        menuRow = new SMENURow(dtMenu.Rows[0]);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("DanhMucMatHang fetch metadata error: " + ex.Message);
                }

                if (tableRow != null)
                {
                    // Pass loai = -1 so TreeGridMg doesn't filter on nonexistent LOAI column
                    // SFORMID and SFUNCTIONID must be non-null ("") because TreeGridMg checks .Length
                    _mg = new TreeGridMg(tableRow, "", -1, null, null, null, "", "", "", menuRow);
                    _mg.Dock = DockStyle.Fill;
                    this.Controls.Add(_mg);

                    CustomizeTreeGrid();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DanhMucMatHang InitializeForm error: " + ex.ToString());
            }
        }

        private void CustomizeTreeGrid()
        {
            if (_mg == null) return;

            try
            {
                // Tab labels
                if (_mg.pageFolder != null)
                {
                    _mg.pageFolder.Text = "Nhóm mặt hàng";
                }
                if (_mg.pageItem != null)
                {
                    _mg.pageItem.Text = "Mặt hàng";
                }

                // Grid columns configuration
                if (_mg.grMain != null && _mg.grMain.GridView != null)
                {
                    DataGridView grid = _mg.grMain.GridView;

                    // Ensure Vietnamese headers
                    SetColumnInfo(grid, "colNAME", "Tên mặt hàng", 0, 180, true);
                    SetColumnInfo(grid, "colDNHOMMATHANGID", "Nhóm mặt hàng", 1, 130, true);
                    SetColumnInfo(grid, "colDLOAIMATHANGID", "Loại mặt hàng", 2, 120, true);
                    SetColumnInfo(grid, "colDDONVITINHID", "Đơn vị tính", 3, 75, true);
                    SetColumnInfo(grid, "colGIABAN", "Giá bán", 4, 85, true, "#,##0");
                    SetColumnInfo(grid, "colGIANHAP", "Giá nhập", 5, 85, true, "#,##0");
                    SetColumnInfo(grid, "colCODE", "Mã hàng", 6, 80, true);
                    SetColumnInfo(grid, "colTAMKHOA", "Tạm khóa", 7, 70, true);
                    SetColumnInfo(grid, "colGIATHEOTHOIGIA", "Giá theo thời giá", 8, 95, true);

                    // Hide unused columns
                    string[] hiddenCols = new string[] {
                        "colNOTE", "colTONTOITHIEU", "colTONTOIDA", "colANH", "colHOAHONG",
                        "colGIAVON", "colDDOITACKYGUIID", "colMACDINHGIAMGIA", "colMACDINHGIAMTIEN"
                    };
                    foreach (string hCol in hiddenCols)
                    {
                        if (grid.Columns.Contains(hCol))
                        {
                            grid.Columns[hCol].Visible = false;
                        }
                    }

                    // Format 3-digit row numbering on row headers (001, 002, ...)
                    grid.RowHeadersVisible = true;
                    grid.RowHeadersWidth = 42;
                    grid.RowPostPaint += Grid_RowPostPaint;

                    // Selection changed to update info tab
                    grid.SelectionChanged += Grid_SelectionChanged;
                }

                // Category tree node selection filter
                if (_mg.tvMain != null)
                {
                    _mg.tvMain.OnFocusedNodeChanged += TvMain_OnFocusedNodeChanged;
                }

                // Clean bottom tabRef to show only 'Thông tin' and 'Khu vực'
                if (_mg.tabRef != null)
                {
                    for (int i = _mg.tabRef.Pages.Count - 1; i >= 0; i--)
                    {
                        KryptonPage page = _mg.tabRef.Pages[i];
                        if (page.Name != "pageThongTin" &&
                            page.Text.IndexOf("khu vực", StringComparison.OrdinalIgnoreCase) < 0 &&
                            page.Text.IndexOf("khu vuc", StringComparison.OrdinalIgnoreCase) < 0)
                        {
                            _mg.tabRef.Pages.RemoveAt(i);
                        }
                        else
                        {
                            if (page.Text.IndexOf("khu vực", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                page.Text.IndexOf("khu vuc", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                page.Text = "Khu vực";
                            }
                            else if (page.Name == "pageThongTin")
                            {
                                page.Text = "Thông tin";
                            }
                        }
                    }
                }

                // Find info labels inside pageThongTin
                if (_mg.pageThongTin != null)
                {
                    foreach (Control c in _mg.pageThongTin.Controls)
                    {
                        if (c is Label lbl)
                        {
                            if (lbl.Name == "lblKhoiTao") _lblKhoiTao = lbl;
                            else if (lbl.Name == "lblKhoiTaoBoi") _lblKhoiTaoBoi = lbl;
                            else if (lbl.Name == "lblSuaDoiGanNhat") _lblSuaDoiGanNhat = lbl;
                            else if (lbl.Name == "lblSuaDoiBoi") _lblSuaDoiBoi = lbl;
                        }
                    }
                }

                // Search box hook
                if (_mg.tsbItemToolbar != null)
                {
                    foreach (ToolStripItem item in _mg.tsbItemToolbar.Items)
                    {
                        if (item is ToolStripTextBox txt && _mg.grMain != null)
                        {
                            txt.TextChanged += (s, ev) =>
                            {
                                try
                                {
                                    string kw = txt.Text.Trim().Replace("'", "''");
                                    if (string.IsNullOrEmpty(kw))
                                    {
                                        _mg.grMain.LoadData("");
                                    }
                                    else
                                    {
                                        _mg.grMain.LoadData("(UPPER(NAME) LIKE '%" + kw.ToUpper() + "%' OR UPPER(CODE) LIKE '%" + kw.ToUpper() + "%')");
                                    }
                                }
                                catch { }
                            };
                            break;
                        }
                    }

                    if (_mg.tsbItemToolbar.Items.ContainsKey("In mã vạch"))
                    {
                        _mg.tsbItemToolbar.Items["In mã vạch"].Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DanhMucMatHang CustomizeTreeGrid error: " + ex.Message);
            }
        }

        private void SetColumnInfo(DataGridView grid, string colName, string headerText, int displayIdx, int width, bool visible, string format = null)
        {
            if (grid.Columns.Contains(colName))
            {
                DataGridViewColumn c = grid.Columns[colName];
                c.HeaderText = headerText;
                c.DisplayIndex = displayIdx;
                c.Width = width;
                c.Visible = visible;
                if (!string.IsNullOrEmpty(format))
                {
                    c.DefaultCellStyle.Format = format;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void Grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                DataGridView grid = sender as DataGridView;
                if (grid == null) return;

                string rowNumber = (e.RowIndex + 1).ToString("000");
                using (SolidBrush brush = new SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor))
                {
                    e.Graphics.DrawString(rowNumber, grid.Font, brush, e.RowBounds.Location.X + 8, e.RowBounds.Location.Y + 4);
                }
            }
            catch { }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridView grid = sender as DataGridView;
                if (grid == null || grid.CurrentRow == null) return;

                if (grid.CurrentRow.DataBoundItem is DataRowView drv)
                {
                    DataRow row = drv.Row;
                    if (row != null)
                    {
                        string timeCreated = row.Table.Columns.Contains("TIMECREATED") && !row.IsNull("TIMECREATED")
                            ? Convert.ToDateTime(row["TIMECREATED"]).ToString("dd/MM/yyyy HH:mm tt")
                            : "Chưa có";
                        string timeModified = row.Table.Columns.Contains("TIMEMODIFIED") && !row.IsNull("TIMEMODIFIED")
                            ? Convert.ToDateTime(row["TIMEMODIFIED"]).ToString("dd/MM/yyyy HH:mm tt")
                            : "Chưa có";

                        string userCreated = "Administrator";
                        string userModified = "Administrator";

                        if (_lblKhoiTao != null) _lblKhoiTao.Text = "Khởi tạo: " + timeCreated;
                        if (_lblKhoiTaoBoi != null) _lblKhoiTaoBoi.Text = "Khởi tạo bởi: " + userCreated;
                        if (_lblSuaDoiGanNhat != null) _lblSuaDoiGanNhat.Text = "Sửa đổi gần nhất: " + timeModified;
                        if (_lblSuaDoiBoi != null) _lblSuaDoiBoi.Text = "Sửa đổi bởi: " + userModified;
                    }
                }
            }
            catch { }
        }

        private void TvMain_OnFocusedNodeChanged(TreeNode node, DataRow r, string id, TreeItemType type)
        {
            try
            {
                if (_mg == null || _mg.grMain == null) return;

                if (string.IsNullOrEmpty(id) || id.Equals("ALL", StringComparison.OrdinalIgnoreCase))
                {
                    _mg.grMain.LoadData("");
                    return;
                }

                if (id.Equals("TRASH", StringComparison.OrdinalIgnoreCase) || (node != null && node.Text.IndexOf("thùng rác", StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    _mg.grMain.LoadData("STATUS = 0");
                    return;
                }

                if (type == TreeItemType.Custom || id.Equals("UNSET", StringComparison.OrdinalIgnoreCase) || (node != null && node.Text.IndexOf("chưa thiết lập", StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    _mg.grMain.LoadData("(DNHOMMATHANGID IS NULL OR DNHOMMATHANGID = '') AND (STATUS <> 0 OR STATUS IS NULL)");
                    return;
                }

                // Collect category ID and any child category IDs
                List<string> catIds = new List<string>();
                if (!string.IsNullOrEmpty(id))
                {
                    catIds.Add(id);
                }

                if (node != null && node.Nodes != null && node.Nodes.Count > 0)
                {
                    CollectChildCategoryIds(node, catIds);
                }

                if (catIds.Count == 1)
                {
                    _mg.grMain.LoadData("DNHOMMATHANGID = '" + catIds[0] + "' AND (STATUS <> 0 OR STATUS IS NULL)");
                }
                else if (catIds.Count > 1)
                {
                    string idList = string.Join("','", catIds.ToArray());
                    _mg.grMain.LoadData("DNHOMMATHANGID IN ('" + idList + "') AND (STATUS <> 0 OR STATUS IS NULL)");
                }
                else
                {
                    _mg.grMain.LoadData("");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TvMain_OnFocusedNodeChanged error: " + ex.Message);
            }
        }

        private void CollectChildCategoryIds(TreeNode parentNode, List<string> ids)
        {
            if (parentNode == null || _mg == null || _mg.tvMain == null) return;

            foreach (TreeNode child in parentNode.Nodes)
            {
                DataRow dr = _mg.tvMain.GetDataRow(child);
                if (dr != null && dr.Table.Columns.Contains("ID") && !dr.IsNull("ID"))
                {
                    string childId = dr["ID"].ToString().Trim();
                    if (!string.IsNullOrEmpty(childId) && !ids.Contains(childId))
                    {
                        ids.Add(childId);
                    }
                }
                CollectChildCategoryIds(child, ids);
            }
        }
    }
}
