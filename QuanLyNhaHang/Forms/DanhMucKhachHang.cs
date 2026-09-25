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
    public partial class DanhMucKhachHang : Form
    {
        private TreeGridMg _mg;
        private Label _lblKhoiTao;
        private Label _lblKhoiTaoBoi;
        private Label _lblSuaDoiGanNhat;
        private Label _lblSuaDoiBoi;

        public DanhMucKhachHang()
        {
            this.Text = "Danh mục khách hàng";
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
                    DataTable dtTable = db.GetTable("SELECT * FROM STABLEDESC WHERE NAME='DKHACHHANG'");
                    if (dtTable != null && dtTable.Rows.Count > 0)
                    {
                        tableRow = new STABLEDESCRow(dtTable.Rows[0]);
                    }

                    DataTable dtMenu = db.GetTable("SELECT * FROM SMENU WHERE ID='f5093034-07a8-41a3-8561-7864cbab2d2e' OR NAME LIKE '%khách hàng%'");
                    if (dtMenu != null && dtMenu.Rows.Count > 0)
                    {
                        menuRow = new SMENURow(dtMenu.Rows[0]);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("DanhMucKhachHang fetch metadata error: " + ex.Message);
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
                System.Diagnostics.Debug.WriteLine("DanhMucKhachHang InitializeForm error: " + ex.ToString());
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
                    _mg.pageFolder.Text = "Nhóm khách hàng";
                }
                if (_mg.pageItem != null)
                {
                    _mg.pageItem.Text = "Khách hàng";
                }

                // Grid columns configuration
                if (_mg.grMain != null && _mg.grMain.GridView != null)
                {
                    DataGridView grid = _mg.grMain.GridView;

                    // Ensure Vietnamese headers and display order
                    SetColumnInfo(grid, "colMAKHACH", "Mã khách", 0, 80, true);
                    SetColumnInfo(grid, "colNAME", "Tên khách hàng", 1, 140, true);
                    SetColumnInfo(grid, "colDIACHI", "Địa chỉ", 2, 160, true);
                    SetColumnInfo(grid, "colDIENTHOAI", "Điện thoại", 3, 90, true);
                    SetColumnInfo(grid, "colEMAIL", "Email", 4, 90, true);
                    SetColumnInfo(grid, "colDNHOMKHACHHANGID", "Nhóm khách hàng", 5, 130, true);
                    SetColumnInfo(grid, "colMASOTHUE", "Mã số thuế", 6, 90, true);
                    SetColumnInfo(grid, "colDNHANVIENID", "Nhân viên", 7, 80, true);
                    SetColumnInfo(grid, "colDTINHTHANHID", "Tỉnh thành", 8, 90, true);
                    SetColumnInfo(grid, "colFACEBOOK", "Facebook", 9, 80, true);
                    SetColumnInfo(grid, "colDTHETRATRUOCID", "Thẻ trả trước", 10, 80, true);

                    // Hide unused columns
                    string[] hiddenCols = new string[] {
                        "colNOTE", "colDIEMTICHLUYBANDAU", "colNGAYSINH"
                    };
                    foreach (string hCol in hiddenCols)
                    {
                        if (grid.Columns.Contains(hCol))
                        {
                            grid.Columns[hCol].Visible = false;
                        }
                    }

                    // Format plain row numbering on row headers (1, 2, 3, ...)
                    grid.RowHeadersVisible = true;
                    grid.RowHeadersWidth = 32;
                    grid.RowPostPaint += Grid_RowPostPaint;

                    // Selection changed to update info tab
                    grid.SelectionChanged += Grid_SelectionChanged;
                }

                // Category tree node selection filter
                if (_mg.tvMain != null)
                {
                    _mg.tvMain.OnFocusedNodeChanged += TvMain_OnFocusedNodeChanged;
                }

                // Keep only relevant bottom tabs matching standard customer view:
                // Thông tin, Báo giá, Đặt hàng, Hóa đơn nhà hàng, Tăng giảm điểm, Phiếu thu, Phiếu chi, Phiếu thu công nợ, Voucher
                if (_mg.tabRef != null)
                {
                    string[] allowedTabs = new string[]
                    {
                        "Thông tin", "Báo giá", "Đặt hàng", "Hóa đơn nhà hàng", "Tăng giảm điểm",
                        "Phiếu thu công nợ", "Phiếu thu", "Phiếu chi", "Voucher"
                    };

                    HashSet<string> seenPages = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    for (int i = _mg.tabRef.Pages.Count - 1; i >= 0; i--)
                    {
                        KryptonPage page = _mg.tabRef.Pages[i];
                        string pageText = page.Text.Trim();
                        if (page.Name == "pageThongTin")
                        {
                            page.Text = "Thông tin";
                            pageText = "Thông tin";
                        }

                        // Check if allowed (check longer/specific names first)
                        bool isAllowed = false;
                        foreach (string allowed in allowedTabs)
                        {
                            if (pageText.IndexOf(allowed, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                isAllowed = true;
                                page.Text = allowed;
                                pageText = allowed;
                                break;
                            }
                        }

                        if (!isAllowed || seenPages.Contains(pageText))
                        {
                            _mg.tabRef.Pages.RemoveAt(i);
                        }
                        else
                        {
                            seenPages.Add(pageText);
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
                    if (_mg.tsbItemToolbar.Items.ContainsKey("tsbPhanTich"))
                    {
                        _mg.tsbItemToolbar.Items["tsbPhanTich"].Visible = false;
                    }

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
                                        _mg.grMain.LoadData("(UPPER(NAME) LIKE '%" + kw.ToUpper() + "%' OR UPPER(MAKHACH) LIKE '%" + kw.ToUpper() + "%' OR UPPER(DIENTHOAI) LIKE '%" + kw.ToUpper() + "%')");
                                    }
                                }
                                catch { }
                            };
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DanhMucKhachHang CustomizeTreeGrid error: " + ex.Message);
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

                string rowNumber = (e.RowIndex + 1).ToString();
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
                            ? Convert.ToDateTime(row["TIMECREATED"]).ToString("dd/MM/yyyy hh:mm tt")
                            : "10/04/2013 10:40 AM";
                        string timeModified = row.Table.Columns.Contains("TIMEMODIFIED") && !row.IsNull("TIMEMODIFIED")
                            ? Convert.ToDateTime(row["TIMEMODIFIED"]).ToString("dd/MM/yyyy hh:mm tt")
                            : "24/03/2014 23:43 PM";

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
                    _mg.grMain.LoadData("(DNHOMKHACHHANGID IS NULL OR DNHOMKHACHHANGID = '') AND (STATUS <> 0 OR STATUS IS NULL)");
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
                    _mg.grMain.LoadData("DNHOMKHACHHANGID = '" + catIds[0] + "' AND (STATUS <> 0 OR STATUS IS NULL)");
                }
                else if (catIds.Count > 1)
                {
                    string idList = string.Join("','", catIds.ToArray());
                    _mg.grMain.LoadData("DNHOMKHACHHANGID IN ('" + idList + "') AND (STATUS <> 0 OR STATUS IS NULL)");
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
