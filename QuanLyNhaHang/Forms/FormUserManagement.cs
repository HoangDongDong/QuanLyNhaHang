using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.Forms
{
    public partial class FormUserManagement : Form
    {
        private class UserItem { public string Id { get; set; } public string Username { get; set; } public string GroupId { get; set; } }
        private class FunctionItem { public string Id { get; set; } public string GroupName { get; set; } public string Name { get; set; } public bool IsViewOnly { get; set; } }
        private class ReportItem { public string Id { get; set; } public string Name { get; set; } public int ItemType { get; set; } public string ParentId { get; set; } }

        private List<UserItem> _allUsers = new List<UserItem>();
        private List<FunctionItem> _allFunctions = new List<FunctionItem>();
        private List<ReportItem> _allReports = new List<ReportItem>();
        
        // Dictionaries for permissions: key = functionId/reportId
        private Dictionary<string, int> _funcRoles = new Dictionary<string, int>();
        private Dictionary<string, int> _reportRoles = new Dictionary<string, int>();

        private ImageList _imageList;
        
        // UI Controls
        private TabControl tabControlPermission;
        private TabPage tabUsage;
        private TabPage tabReport;
        private SplitContainer splitUsage;
        private TreeView tvFunctions;
        private DataGridView dgvFunctions;
        private SplitContainer splitReport;
        private TreeView tvReports;
        private DataGridView dgvReports;
        
        private string _currentGroupId = "";
        private bool _isUpdatingGrid = false;

        public FormUserManagement()
        {
            InitializeComponent();
            SetupImageList();
            InitPermissionUI();
            InitContextMenu();
            tvGroups.AfterSelect += TvGroups_AfterSelect;
            this.Load += FormUserManagement_Load;
            
            btnGroupAdd.Click += BtnGroupAdd_Click;
            btnGroupEdit.Click += BtnGroupEdit_Click;
            btnGroupDelete.Click += BtnGroupDelete_Click;
            
            btnUserAdd.Click += BtnUserAdd_Click;
            btnUserEdit.Click += BtnUserEdit_Click;
        }

        private void BtnUserAdd_Click(object sender, EventArgs e)
        {
            bool success = QuanLyNhaHang.Services.DbFormService.ShowDynamicDataEntryForm("TaiKhoanNguoiDung", "SUSER");
            if (success)
            {
                LoadDataFromDatabase();
            }
        }

        private void BtnUserEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string userId = dgvUsers.SelectedRows[0].Tag as string;
            if (!string.IsNullOrEmpty(userId))
            {
                bool success = QuanLyNhaHang.Services.DbFormService.ShowDynamicDataEntryForm("TaiKhoanNguoiDung", "SUSER", userId);
                if (success)
                {
                    LoadDataFromDatabase();
                }
            }
        }
        
        private ContextMenuStrip _ctxTree;

        private void InitContextMenu()
        {
            _ctxTree = new ContextMenuStrip();
            _ctxTree.Font = new Font("Segoe UI", 9F);
            
            ToolStripMenuItem mnuAdd = new ToolStripMenuItem("Thêm mới");
            mnuAdd.Image = CreateEmojiIcon("➕", Color.Green);
            ToolStripMenuItem mnuAddGroup = new ToolStripMenuItem("Thêm nhóm người dùng", CreateEmojiIcon("➕", Color.Green), BtnGroupAdd_Click);
            ToolStripMenuItem mnuAddQuick = new ToolStripMenuItem("Thêm nhanh");
            mnuAddQuick.Click += (s, e) => 
            {
                using (var f = new FormQuickAddGroup())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataFromDatabase();
                    }
                }
            };
            ToolStripMenuItem mnuAddSep = new ToolStripMenuItem("Thêm phân cách");
            mnuAddSep.Click += BtnGroupAddSep_Click;
            ToolStripMenuItem mnuAddFolder = new ToolStripMenuItem("Thêm thư mục", CreateEmojiIcon("📁", Color.Goldenrod));
            mnuAdd.DropDownItems.AddRange(new ToolStripItem[] { mnuAddGroup, mnuAddQuick, new ToolStripSeparator(), mnuAddSep, mnuAddFolder });
            
            ToolStripMenuItem mnuAddChild = new ToolStripMenuItem("Thêm con");
            ToolStripMenuItem mnuEdit = new ToolStripMenuItem("Chỉnh sửa", CreateEmojiIcon("✏️", Color.Goldenrod), BtnGroupEdit_Click);
            
            ToolStripMenuItem mnuSort = new ToolStripMenuItem("Sắp xếp theo");
            ToolStripMenuItem mnuSortName = new ToolStripMenuItem("Tên");
            ToolStripMenuItem mnuSortCustom = new ToolStripMenuItem("Thứ tự tùy chọn") { Checked = true };
            mnuSort.DropDownItems.AddRange(new ToolStripItem[] { mnuSortName, mnuSortCustom });
            
            ToolStripMenuItem mnuRefresh = new ToolStripMenuItem("Refresh", CreateEmojiIcon("🔄", Color.Green), (s, e) => LoadDataFromDatabase());
            ToolStripMenuItem mnuCopy = new ToolStripMenuItem("Sao chép", CreateEmojiIcon("📄", Color.Blue));
            
            ToolStripMenuItem mnuExpand = new ToolStripMenuItem("Mở rộng", null, (s, e) => { tvGroups.ExpandAll(); tvFunctions.ExpandAll(); tvReports.ExpandAll(); });
            ToolStripMenuItem mnuCollapse = new ToolStripMenuItem("Thu gọn", null, (s, e) => { tvGroups.CollapseAll(); tvFunctions.CollapseAll(); tvReports.CollapseAll(); });
            
            ToolStripMenuItem mnuDelete = new ToolStripMenuItem("Xóa", CreateEmojiIcon("❌", Color.Red), BtnGroupDelete_Click);
            ToolStripMenuItem mnuRename = new ToolStripMenuItem("Đổi tên", null, (s, e) => {
                if (tvGroups.SelectedNode != null && tvGroups.SelectedNode.Tag as string != "ALL" && !tvGroups.SelectedNode.Text.StartsWith("---"))
                {
                    tvGroups.SelectedNode.BeginEdit();
                }
            });
            ToolStripMenuItem mnuRecycle = new ToolStripMenuItem("Thùng rác");
            ToolStripMenuItem mnuIcon = new ToolStripMenuItem("Biểu tượng");
            ToolStripMenuItem mnuProps = new ToolStripMenuItem("Thuộc tính");

            _ctxTree.Items.AddRange(new ToolStripItem[] {
                mnuAdd, mnuAddChild, mnuEdit, mnuSort, mnuRefresh,
                new ToolStripSeparator(), mnuCopy,
                new ToolStripSeparator(), mnuExpand, mnuCollapse,
                new ToolStripSeparator(), mnuDelete, mnuRename, mnuRecycle,
                new ToolStripSeparator(), mnuIcon, mnuProps
            });

            tvGroups.ContextMenuStrip = _ctxTree;
            tvGroups.NodeMouseClick += Tv_NodeMouseClick;
            tvGroups.LabelEdit = true;
            tvGroups.AfterLabelEdit += TvGroups_AfterLabelEdit;
        }

        private void TvGroups_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) return;
            string newName = e.Label.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                e.CancelEdit = true;
                return;
            }

            if (e.Node.Tag as string == "ALL" || e.Node.Text.StartsWith("---"))
            {
                e.CancelEdit = true;
                return;
            }

            string groupId = e.Node.Tag.ToString();
            
            try
            {
                using (var conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new FbCommand("UPDATE SGROUPUSER SET NAME = @name WHERE ID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", newName);
                        cmd.Parameters.AddWithValue("@id", groupId);
                        cmd.ExecuteNonQuery();
                    }
                }
                // FormUserManagement logic here
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi tên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
            }
        }

        private void Tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TreeView)sender).SelectedNode = e.Node;
            }
        }

        private Image CreateEmojiIcon(string emoji, Color color)
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Font font = new Font("Segoe UI Emoji", 10))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawString(emoji, font, brush, -2, -2);
                }
            }
            return bmp;
        }

        private void InitPermissionUI()
        {
            tabControlPermission = new TabControl { Dock = DockStyle.Fill };
            tabUsage = new TabPage("Quyền sử dụng");
            tabReport = new TabPage("Quyền xem báo cáo");
            tabControlPermission.TabPages.Add(tabUsage);
            tabControlPermission.TabPages.Add(tabReport);
            
            // Usage Tab
            splitUsage = new SplitContainer { Dock = DockStyle.Fill, FixedPanel = FixedPanel.Panel1, SplitterDistance = 180 };
            tvFunctions = new TreeView { Dock = DockStyle.Fill, ImageList = _imageList };
            tvFunctions.Font = new Font(tvFunctions.Font.FontFamily, 7.75f);
            tvFunctions.AfterSelect += TvFunctions_AfterSelect;
            tvFunctions.ContextMenuStrip = _ctxTree;
            tvFunctions.NodeMouseClick += Tv_NodeMouseClick;
            
            Panel pnlUsageTop = new Panel { Dock = DockStyle.Top, Height = 30 };
            CheckBox chkUsageLockAll = new CheckBox { Text = "Khóa tất cả", Dock = DockStyle.Right, Width = 100 };
            CheckBox chkUsageAllowAll = new CheckBox { Text = "Cho phép tất cả", Dock = DockStyle.Right, Width = 120 };
            pnlUsageTop.Controls.Add(chkUsageLockAll);
            pnlUsageTop.Controls.Add(chkUsageAllowAll);
            
            dgvFunctions = new DataGridView { Dock = DockStyle.Fill, AllowUserToAddRows = false, RowHeadersVisible = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToDeleteRows = false, BackgroundColor = Color.White, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            dgvFunctions.DefaultCellStyle.SelectionBackColor = Color.Peru;
            dgvFunctions.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFunctions.Columns.Add("Id", "Id"); dgvFunctions.Columns["Id"].Visible = false;
            dgvFunctions.Columns.Add("ChucNang", "Chức năng"); dgvFunctions.Columns["ChucNang"].ReadOnly = true; dgvFunctions.Columns["ChucNang"].MinimumWidth = 220;
            dgvFunctions.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Khoa", HeaderText = "Khóa", Width = 50, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvFunctions.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Xem", HeaderText = "Xem", Width = 50, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvFunctions.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Them", HeaderText = "Thêm", Width = 50, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvFunctions.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Sua", HeaderText = "Sửa", Width = 50, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvFunctions.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Xoa", HeaderText = "Xóa", Width = 50, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvFunctions.Columns.Add(new DataGridViewCheckBoxColumn { Name = "TatCa", HeaderText = "Tất cả", Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvFunctions.CellValueChanged += DgvFunctions_CellValueChanged;
            dgvFunctions.CurrentCellDirtyStateChanged += (s, e) => { if (dgvFunctions.IsCurrentCellDirty) dgvFunctions.CommitEdit(DataGridViewDataErrorContexts.Commit); };
            
            chkUsageLockAll.CheckedChanged += (s, e) => { if (chkUsageLockAll.Checked) { chkUsageAllowAll.Checked = false; SetAllGridCheckboxes(dgvFunctions, "Khoa", true); } };
            chkUsageAllowAll.CheckedChanged += (s, e) => { if (chkUsageAllowAll.Checked) { chkUsageLockAll.Checked = false; SetAllGridCheckboxes(dgvFunctions, "TatCa", true); } };

            splitUsage.Panel1.Controls.Add(tvFunctions);
            splitUsage.Panel2.Controls.Add(dgvFunctions);
            splitUsage.Panel2.Controls.Add(pnlUsageTop);
            tabUsage.Controls.Add(splitUsage);
            
            // Report Tab
            splitReport = new SplitContainer { Dock = DockStyle.Fill, FixedPanel = FixedPanel.Panel1, SplitterDistance = 160 };
            tvReports = new TreeView { Dock = DockStyle.Fill, ImageList = _imageList };
            tvReports.Font = new Font(tvReports.Font.FontFamily, 7.75f);
            tvReports.AfterSelect += TvReports_AfterSelect;
            tvReports.ContextMenuStrip = _ctxTree;
            tvReports.NodeMouseClick += Tv_NodeMouseClick;
            
            Panel pnlReportTop = new Panel { Dock = DockStyle.Top, Height = 30 };
            CheckBox chkReportLockAll = new CheckBox { Text = "Khóa tất cả", Dock = DockStyle.Right, Width = 100 };
            CheckBox chkReportAllowAll = new CheckBox { Text = "Cho phép tất cả", Dock = DockStyle.Right, Width = 120 };
            pnlReportTop.Controls.Add(chkReportLockAll);
            pnlReportTop.Controls.Add(chkReportAllowAll);
            
            dgvReports = new DataGridView { Dock = DockStyle.Fill, AllowUserToAddRows = false, RowHeadersVisible = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, AllowUserToDeleteRows = false, BackgroundColor = Color.White, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            dgvReports.DefaultCellStyle.SelectionBackColor = Color.Peru;
            dgvReports.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvReports.Columns.Add("Id", "Id"); dgvReports.Columns["Id"].Visible = false;
            dgvReports.Columns.Add("BaoCao", "Báo cáo"); dgvReports.Columns["BaoCao"].ReadOnly = true; dgvReports.Columns["BaoCao"].MinimumWidth = 220;
            dgvReports.Columns.Add(new DataGridViewCheckBoxColumn { Name = "KhongXem", HeaderText = "Không được xem", Width = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvReports.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Xem", HeaderText = "Được phép xem", Width = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvReports.CellValueChanged += DgvReports_CellValueChanged;
            dgvReports.CurrentCellDirtyStateChanged += (s, e) => { if (dgvReports.IsCurrentCellDirty) dgvReports.CommitEdit(DataGridViewDataErrorContexts.Commit); };
            
            chkReportLockAll.CheckedChanged += (s, e) => { if (chkReportLockAll.Checked) { chkReportAllowAll.Checked = false; SetAllGridCheckboxes(dgvReports, "KhongXem", true); } };
            chkReportAllowAll.CheckedChanged += (s, e) => { if (chkReportAllowAll.Checked) { chkReportLockAll.Checked = false; SetAllGridCheckboxes(dgvReports, "Xem", true); } };
            
            splitReport.Panel1.Controls.Add(tvReports);
            splitReport.Panel2.Controls.Add(dgvReports);
            splitReport.Panel2.Controls.Add(pnlReportTop);
            tabReport.Controls.Add(splitReport);
            
            // Layout changes
            pnlRight.Controls.Remove(lblPermissionHint);
            pnlRight.Controls.Add(tabControlPermission);
            tabControlPermission.Visible = false;
            
            // Align columns
            foreach (DataGridViewColumn col in dgvFunctions.Columns)
            {
                if (col.Name != "ChucNang" && col.Name != "Id")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            foreach (DataGridViewColumn col in dgvReports.Columns)
            {
                if (col.Name != "BaoCao" && col.Name != "Id")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void SetAllGridCheckboxes(DataGridView dgv, string colName, bool value)
        {
            if (_currentGroupId == "ALL" || string.IsNullOrEmpty(_currentGroupId)) return;
            foreach(DataGridViewRow row in dgv.Rows)
            {
                row.Cells[colName].Value = value;
            }
        }

        private void SetupImageList()
        {
            _imageList = new ImageList();
            _imageList.ImageSize = new Size(16, 16);
            _imageList.ColorDepth = ColorDepth.Depth32Bit;
            tvGroups.ImageList = _imageList;
        }

        private Bitmap GetIconForGroup(string groupName)
        {
            string emoji = "📁";
            string lowerName = groupName.ToLower();
            if (lowerName.Contains("tất cả")) emoji = "🌐";
            else if (lowerName.Contains("thu ngân")) emoji = "⭐";
            else if (lowerName.Contains("thủ kho")) emoji = "📋";
            else if (lowerName.Contains("kế toán")) emoji = "🧾";
            else if (lowerName.Contains("quản lý")) emoji = "🧑‍💼";
            else if (lowerName.Contains("phục vụ")) emoji = "💁";
            else emoji = "📂";

            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                
                if (emoji == "📂" || emoji == "📁")
                {
                    // Draw orange folder
                    g.FillRectangle(Brushes.DarkOrange, 1, 3, 6, 3);
                    g.DrawRectangle(Pens.Chocolate, 1, 3, 6, 3);
                    g.FillRectangle(Brushes.Orange, 1, 5, 14, 9);
                    g.DrawRectangle(Pens.Chocolate, 1, 5, 14, 9);
                }
                else
                {
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    using (Font font = new Font("Segoe UI Emoji", 10))
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        g.DrawString(emoji, font, brush, -2, 0);
                    }
                }
            }
            return bmp;
        }

        private void FormUserManagement_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            LoadMetadata();
        }

        private void LoadMetadata()
        {
            try
            {
                string connStr = DbFormService.GetConnectionString();
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    // Load SFUNCTION
                    _allFunctions.Clear();
                    string sqlFunc = "SELECT ID, GROUPNAME, NAME, NOTE FROM SFUNCTION ORDER BY GROUPNAME, NAME";
                    using (FbCommand cmd = new FbCommand(sqlFunc, conn))
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            _allFunctions.Add(new FunctionItem {
                                Id = reader["ID"].ToString(),
                                GroupName = reader["GROUPNAME"]?.ToString() ?? "Khác",
                                Name = reader["NAME"]?.ToString() ?? "",
                                IsViewOnly = reader["NOTE"]?.ToString() == "View"
                            });
                        }
                    }

                    // Load SREPORT
                    _allReports.Clear();
                    string sqlRep = "SELECT ID, NAME, ITEMTYPE, PARENTID FROM SREPORT ORDER BY SORTORDER, NAME";
                    using (FbCommand cmd = new FbCommand(sqlRep, conn))
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            _allReports.Add(new ReportItem {
                                Id = reader["ID"].ToString(),
                                Name = reader["NAME"]?.ToString() ?? "",
                                ItemType = reader["ITEMTYPE"] != DBNull.Value ? Convert.ToInt32(reader["ITEMTYPE"]) : 0,
                                ParentId = reader["PARENTID"]?.ToString() ?? ""
                            });
                        }
                    }

                    BuildFunctionTree();
                    BuildReportTree();
                }
            }
            catch { }
        }

        private void BuildFunctionTree()
        {
            tvFunctions.Nodes.Clear();
            if(!_imageList.Images.ContainsKey("TatCaFunc")) _imageList.Images.Add("TatCaFunc", GetIconForGroup("Tất cả"));
            if(!_imageList.Images.ContainsKey("Folder")) _imageList.Images.Add("Folder", GetIconForGroup("Folder"));
            
            TreeNode root = new TreeNode("Tất cả") { ImageKey = "TatCaFunc", SelectedImageKey = "TatCaFunc", Tag = "ALL" };
            
            var groups = _allFunctions.Select(f => f.GroupName).Distinct().OrderBy(g => g).ToList();
            foreach(var g in groups)
            {
                TreeNode n = new TreeNode(g) { ImageKey = "Folder", SelectedImageKey = "Folder", Tag = g };
                root.Nodes.Add(n);
            }
            tvFunctions.Nodes.Add(root);
            tvFunctions.ExpandAll();
        }

        private void BuildReportTree()
        {
            tvReports.Nodes.Clear();
            TreeNode root = new TreeNode("Tất cả") { ImageKey = "TatCaFunc", SelectedImageKey = "TatCaFunc", Tag = "ALL" };
            
            // Build dictionary of folders
            var folders = _allReports.Where(r => r.ItemType == 1).ToList();
            Dictionary<string, TreeNode> nodeDict = new Dictionary<string, TreeNode>();
            
            // Create root folders (ParentId empty)
            foreach(var f in folders.Where(x => string.IsNullOrEmpty(x.ParentId)))
            {
                TreeNode n = new TreeNode(f.Name) { ImageKey = "Folder", SelectedImageKey = "Folder", Tag = f.Id };
                nodeDict[f.Id] = n;
                root.Nodes.Add(n);
            }

            // Create sub folders (1 level deep usually)
            foreach(var f in folders.Where(x => !string.IsNullOrEmpty(x.ParentId)))
            {
                if(nodeDict.ContainsKey(f.ParentId))
                {
                    TreeNode n = new TreeNode(f.Name) { ImageKey = "Folder", SelectedImageKey = "Folder", Tag = f.Id };
                    nodeDict[f.Id] = n;
                    nodeDict[f.ParentId].Nodes.Add(n);
                }
            }

            tvReports.Nodes.Add(root);
            tvReports.ExpandAll();
        }

        private void LoadDataFromDatabase()
        {
            tvGroups.Nodes.Clear();
            _allUsers.Clear();
            _imageList.Images.Clear();

            string allName = "Tất cả";
            _imageList.Images.Add(allName, GetIconForGroup(allName));

            TreeNode root = new TreeNode(allName) { ImageKey = allName, SelectedImageKey = allName, Tag = "ALL" };

            try
            {
                string connStr = DbFormService.GetConnectionString();
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string sqlGroups = "SELECT G.ID, G.NAME, I.IMAGE, G.SORTORDER, G.ITEMTYPE FROM SGROUPUSER G LEFT JOIN SIMAGE I ON G.SIMAGEID = I.ID ORDER BY G.SORTORDER, G.NAME";
                    using (FbCommand cmd = new FbCommand(sqlGroups, conn))
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["ID"].ToString();
                            string name = reader["NAME"].ToString();
                            if (!_imageList.Images.ContainsKey(id))
                            {
                                if (reader["IMAGE"] != DBNull.Value)
                                {
                                    byte[] imgBytes = (byte[])reader["IMAGE"];
                                    using (var ms = new System.IO.MemoryStream(imgBytes))
                                    {
                                        _imageList.Images.Add(id, Image.FromStream(ms));
                                    }
                                }
                                else
                                {
                                    _imageList.Images.Add(id, GetIconForGroup(name));
                                }
                            }
                            string displayName = name == "-" ? new string('-', 30) : name;
                            TreeNode node = new TreeNode(displayName) { Tag = id, ImageKey = id, SelectedImageKey = id };
                            root.Nodes.Add(node);
                        }
                    }

                    tvGroups.Nodes.Add(root);
                    tvGroups.ExpandAll();

                    string sqlUsers = "SELECT ID, USERNAME, SGROUPUSERID FROM SUSER WHERE LOWER(USERNAME) != 'admin'";
                    using (FbCommand cmd = new FbCommand(sqlUsers, conn))
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _allUsers.Add(new UserItem
                            {
                                Id = reader["ID"].ToString(),
                                Username = reader["USERNAME"].ToString(),
                                GroupId = reader["SGROUPUSERID"]?.ToString() ?? ""
                            });
                        }
                    }
                    tvGroups.SelectedNode = root;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TvGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dgvUsers.Rows.Clear();
            if (e.Node == null) return;
            
            _currentGroupId = e.Node.Tag as string;
            
            var filteredUsers = _allUsers;
            if (_currentGroupId != "ALL") filteredUsers = _allUsers.Where(u => u.GroupId == _currentGroupId).ToList();

            int stt = 1;
            foreach (var u in filteredUsers)
            {
                int rIdx = dgvUsers.Rows.Add(stt++, u.Username);
                dgvUsers.Rows[rIdx].Tag = u.Id;
            }
            if(dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Rows[0].DefaultCellStyle.BackColor = Color.Orange;
                dgvUsers.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            }

            if (_currentGroupId == "ALL")
            {
                tabControlPermission.Visible = false;
                lblPermissionHint.Visible = true;
                if(!pnlRight.Controls.Contains(lblPermissionHint)) pnlRight.Controls.Add(lblPermissionHint);
            }
            else
            {
                if(pnlRight.Controls.Contains(lblPermissionHint)) pnlRight.Controls.Remove(lblPermissionHint);
                tabControlPermission.Visible = true;
                LoadRolesForGroup(_currentGroupId);
                
                if (tvFunctions.Nodes.Count > 0)
                {
                    tvFunctions.SelectedNode = tvFunctions.Nodes[0];
                }
                
                if (tvReports.Nodes.Count > 0)
                {
                    tvReports.SelectedNode = tvReports.Nodes[0];
                }
                
                PopulateFunctionGrid();
                PopulateReportGrid();
            }
        }

        private void LoadRolesForGroup(string groupId)
        {
            _funcRoles.Clear();
            _reportRoles.Clear();
            try
            {
                string connStr = DbFormService.GetConnectionString();
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string sqlFunc = "SELECT SFUNCTIONID, MODE FROM SGROUPROLE WHERE SGROUPUSERID = @g";
                    using(FbCommand cmd = new FbCommand(sqlFunc, conn))
                    {
                        cmd.Parameters.AddWithValue("@g", groupId);
                        using(FbDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read()) _funcRoles[reader["SFUNCTIONID"].ToString()] = Convert.ToInt32(reader["MODE"]);
                        }
                    }
                    string sqlRep = "SELECT SREPORTID, MODE FROM SREPORTROLE WHERE SGROUPUSERID = @g";
                    using(FbCommand cmd = new FbCommand(sqlRep, conn))
                    {
                        cmd.Parameters.AddWithValue("@g", groupId);
                        using(FbDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read()) _reportRoles[reader["SREPORTID"].ToString()] = Convert.ToInt32(reader["MODE"]);
                        }
                    }
                }
            }
            catch {}
        }

        private void TvFunctions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PopulateFunctionGrid();
        }

        private void PopulateFunctionGrid()
        {
            if (tvFunctions.SelectedNode == null) return;
            string groupFilter = tvFunctions.SelectedNode.Tag as string;
            
            _isUpdatingGrid = true;
            dgvFunctions.Rows.Clear();
            
            var list = _allFunctions.AsEnumerable();
            if (groupFilter != "ALL") list = list.Where(f => f.GroupName == groupFilter);
            list = list.OrderBy(f => f.Name);
            
            foreach(var f in list)
            {
                int mode = _funcRoles.ContainsKey(f.Id) ? _funcRoles[f.Id] : 0;
                bool view = (mode & 16) == 16;
                bool add = (mode & 64) == 64;
                bool edit = (mode & 32) == 32;
                bool del = (mode & 128) == 128;
                bool locked = mode == 0;
                bool all = view && add && edit && del;

                int rowIndex = dgvFunctions.Rows.Add(f.Id, f.Name, locked, view, add, edit, del, all);
                
                if (f.IsViewOnly)
                {
                    dgvFunctions.Rows[rowIndex].Cells["Them"] = new DataGridViewTextBoxCell { Value = "" };
                    dgvFunctions.Rows[rowIndex].Cells["Them"].ReadOnly = true;
                    
                    dgvFunctions.Rows[rowIndex].Cells["Sua"] = new DataGridViewTextBoxCell { Value = "" };
                    dgvFunctions.Rows[rowIndex].Cells["Sua"].ReadOnly = true;
                    
                    dgvFunctions.Rows[rowIndex].Cells["Xoa"] = new DataGridViewTextBoxCell { Value = "" };
                    dgvFunctions.Rows[rowIndex].Cells["Xoa"].ReadOnly = true;
                    
                    dgvFunctions.Rows[rowIndex].Cells["TatCa"] = new DataGridViewTextBoxCell { Value = "" };
                    dgvFunctions.Rows[rowIndex].Cells["TatCa"].ReadOnly = true;
                }
            }
            _isUpdatingGrid = false;
        }

        private void DgvFunctions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_isUpdatingGrid || e.RowIndex < 0 || _currentGroupId == "ALL") return;
            
            var row = dgvFunctions.Rows[e.RowIndex];
            string colName = dgvFunctions.Columns[e.ColumnIndex].Name;
            
            if (row.Cells[e.ColumnIndex] is DataGridViewTextBoxCell) return;
            
            _isUpdatingGrid = true;
            bool val = false;
            try { val = Convert.ToBoolean(row.Cells[e.ColumnIndex].Value); } catch { }
            
            bool isViewOnly = row.Cells["Them"] is DataGridViewTextBoxCell;
            
            if (colName == "Khoa" && val)
            {
                row.Cells["Xem"].Value = false;
                if (!isViewOnly)
                {
                    row.Cells["Them"].Value = false; row.Cells["Sua"].Value = false;
                    row.Cells["Xoa"].Value = false; row.Cells["TatCa"].Value = false;
                }
            }
            else if (colName == "TatCa" && val && !isViewOnly)
            {
                row.Cells["Khoa"].Value = false;
                row.Cells["Xem"].Value = true; row.Cells["Them"].Value = true;
                row.Cells["Sua"].Value = true; row.Cells["Xoa"].Value = true;
            }
            else if (val)
            {
                row.Cells["Khoa"].Value = false;
                if (!isViewOnly)
                {
                    bool v = Convert.ToBoolean(row.Cells["Xem"].Value);
                    bool a = Convert.ToBoolean(row.Cells["Them"].Value);
                    bool s = Convert.ToBoolean(row.Cells["Sua"].Value);
                    bool x = Convert.ToBoolean(row.Cells["Xoa"].Value);
                    if (v && a && s && x) row.Cells["TatCa"].Value = true;
                }
            }
            else if (!val && colName != "Khoa")
            {
                if (!isViewOnly) row.Cells["TatCa"].Value = false;
                
                bool v = Convert.ToBoolean(row.Cells["Xem"].Value);
                if (isViewOnly)
                {
                    if (!v) row.Cells["Khoa"].Value = true;
                }
                else
                {
                    bool a = Convert.ToBoolean(row.Cells["Them"].Value);
                    bool s = Convert.ToBoolean(row.Cells["Sua"].Value);
                    bool x = Convert.ToBoolean(row.Cells["Xoa"].Value);
                    if (!v && !a && !s && !x) row.Cells["Khoa"].Value = true;
                }
            }

            int newMode = 0;
            if (!Convert.ToBoolean(row.Cells["Khoa"].Value))
            {
                if (Convert.ToBoolean(row.Cells["Xem"].Value)) newMode += 16;
                if (!isViewOnly && Convert.ToBoolean(row.Cells["Them"].Value)) newMode += 64;
                if (!isViewOnly && Convert.ToBoolean(row.Cells["Sua"].Value)) newMode += 32;
                if (!isViewOnly && Convert.ToBoolean(row.Cells["Xoa"].Value)) newMode += 128;
            }

            string funcId = row.Cells["Id"].Value.ToString();
            _funcRoles[funcId] = newMode;
            SaveRoleToDb("SGROUPROLE", "SFUNCTIONID", funcId, newMode);

            _isUpdatingGrid = false;
        }

        private void TvReports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PopulateReportGrid();
        }

        private void PopulateReportGrid()
        {
            if (tvReports.SelectedNode == null) return;
            string parentId = tvReports.SelectedNode.Tag as string;
            
            _isUpdatingGrid = true;
            dgvReports.Rows.Clear();
            
            var list = _allReports.Where(r => r.ItemType == 0); // only reports
            
            if (parentId != "ALL")
            {
                // Find all reports under this folder or its subfolders
                var folderIds = new HashSet<string> { parentId };
                // Add direct subfolders
                foreach(var f in _allReports.Where(x => x.ItemType == 1 && x.ParentId == parentId)) folderIds.Add(f.Id);
                
                list = list.Where(r => folderIds.Contains(r.ParentId));
            }
            
            list = list.OrderBy(r => r.Name);
            
            foreach(var r in list)
            {
                int mode = _reportRoles.ContainsKey(r.Id) ? _reportRoles[r.Id] : 0;
                bool view = mode > 0;
                dgvReports.Rows.Add(r.Id, r.Name, !view, view);
            }
            _isUpdatingGrid = false;
        }

        private void DgvReports_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_isUpdatingGrid || e.RowIndex < 0 || _currentGroupId == "ALL") return;
            
            _isUpdatingGrid = true;
            var row = dgvReports.Rows[e.RowIndex];
            string colName = dgvReports.Columns[e.ColumnIndex].Name;
            
            bool val = Convert.ToBoolean(row.Cells[e.ColumnIndex].Value);
            
            if (colName == "KhongXem" && val) row.Cells["Xem"].Value = false;
            else if (colName == "Xem" && val) row.Cells["KhongXem"].Value = false;
            
            int newMode = Convert.ToBoolean(row.Cells["Xem"].Value) ? 30 : 0;
            string repId = row.Cells["Id"].Value.ToString();
            _reportRoles[repId] = newMode;
            SaveRoleToDb("SREPORTROLE", "SREPORTID", repId, newMode);
            
            _isUpdatingGrid = false;
        }

        private void SaveRoleToDb(string tableName, string idColName, string itemId, int mode)
        {
            try
            {
                string connStr = DbFormService.GetConnectionString();
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string chkSql = $"SELECT COUNT(*) FROM {tableName} WHERE SGROUPUSERID=@g AND {idColName}=@id";
                    using(FbCommand cmd = new FbCommand(chkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@g", _currentGroupId);
                        cmd.Parameters.AddWithValue("@id", itemId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            if (mode == 0)
                            {
                                string delSql = $"DELETE FROM {tableName} WHERE SGROUPUSERID=@g AND {idColName}=@id";
                                using(FbCommand dcmd = new FbCommand(delSql, conn)){ dcmd.Parameters.AddWithValue("@g", _currentGroupId); dcmd.Parameters.AddWithValue("@id", itemId); dcmd.ExecuteNonQuery(); }
                            }
                            else
                            {
                                string upSql = $"UPDATE {tableName} SET MODE=@m WHERE SGROUPUSERID=@g AND {idColName}=@id";
                                using(FbCommand ucmd = new FbCommand(upSql, conn)){ ucmd.Parameters.AddWithValue("@m", mode); ucmd.Parameters.AddWithValue("@g", _currentGroupId); ucmd.Parameters.AddWithValue("@id", itemId); ucmd.ExecuteNonQuery(); }
                            }
                        }
                        else if (mode > 0)
                        {
                            string insSql = $"INSERT INTO {tableName} (ID, SGROUPUSERID, {idColName}, MODE) VALUES (@newId, @g, @id, @m)";
                            using(FbCommand icmd = new FbCommand(insSql, conn)){ icmd.Parameters.AddWithValue("@newId", Guid.NewGuid().ToString()); icmd.Parameters.AddWithValue("@g", _currentGroupId); icmd.Parameters.AddWithValue("@id", itemId); icmd.Parameters.AddWithValue("@m", mode); icmd.ExecuteNonQuery(); }
                        }
                    }
                }
            }
            catch(Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGroupAddSep_Click(object sender, EventArgs e)
        {
            if (tvGroups.SelectedNode == null || tvGroups.SelectedNode.Tag as string == "ALL")
            {
                MessageBox.Show("Vui lòng chọn một nhóm để thêm phân cách lên trên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedId = tvGroups.SelectedNode.Tag.ToString();
            string userId = string.IsNullOrEmpty(Program.CurrentUserId) ? Guid.Empty.ToString() : Program.CurrentUserId;
            string newSepId = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    List<string> ids = new List<string>();
                    
                    string sqlFetch = "SELECT ID FROM SGROUPUSER ORDER BY SORTORDER, NAME";
                    using (FbCommand cmd = new FbCommand(sqlFetch, conn))
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ids.Add(reader["ID"].ToString());
                        }
                    }

                    int idx = ids.IndexOf(selectedId);
                    if (idx == -1) idx = 0;
                    ids.Insert(idx, newSepId);

                    using (FbTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlUpdate = "UPDATE SGROUPUSER SET SORTORDER = @sort WHERE ID = @id";
                            string sqlInsert = "INSERT INTO SGROUPUSER (ID, NAME, STATUS, ITEMTYPE, SORTORDER, USERCREATEDID) VALUES (@id, '-', 30, 2, @sort, @uid)";
                            
                            for (int i = 0; i < ids.Count; i++)
                            {
                                string id = ids[i];
                                string sortOrder = $"ZZZ{i + 1:D3}";
                                
                                if (id == newSepId)
                                {
                                    using (FbCommand cmd = new FbCommand(sqlInsert, conn, trans))
                                    {
                                        cmd.Parameters.AddWithValue("@id", id);
                                        cmd.Parameters.AddWithValue("@sort", sortOrder);
                                        cmd.Parameters.AddWithValue("@uid", userId);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    using (FbCommand cmd = new FbCommand(sqlUpdate, conn, trans))
                                    {
                                        cmd.Parameters.AddWithValue("@id", id);
                                        cmd.Parameters.AddWithValue("@sort", sortOrder);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            trans.Commit();
                            LoadDataFromDatabase();
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm phân cách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGroupAdd_Click(object sender, EventArgs e)
        {
            FormGroupUser frm = new FormGroupUser();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataFromDatabase();
            }
        }

        private void BtnGroupEdit_Click(object sender, EventArgs e)
        {
            if (tvGroups.SelectedNode == null || tvGroups.SelectedNode.Tag as string == "ALL")
            {
                MessageBox.Show("Vui lòng chọn một nhóm người dùng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string groupId = tvGroups.SelectedNode.Tag.ToString();
            FormGroupUser frm = new FormGroupUser(groupId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataFromDatabase();
            }
        }

        private void BtnGroupDelete_Click(object sender, EventArgs e)
        {
            if (tvGroups.SelectedNode == null || tvGroups.SelectedNode.Tag as string == "ALL")
            {
                MessageBox.Show("Vui lòng chọn một nhóm người dùng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string groupId = tvGroups.SelectedNode.Tag.ToString();
            string groupName = tvGroups.SelectedNode.Text;

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhóm người dùng '{groupName}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                    {
                        conn.Open();
                        
                        using (FbCommand cmd = new FbCommand("DELETE FROM SGROUPROLE WHERE SGROUPUSERID = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", groupId);
                            cmd.ExecuteNonQuery();
                        }

                        using (FbCommand cmd = new FbCommand("DELETE FROM SREPORTROLE WHERE SGROUPUSERID = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", groupId);
                            cmd.ExecuteNonQuery();
                        }

                        using (FbCommand cmd = new FbCommand("DELETE FROM SGROUPUSER WHERE ID = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", groupId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Đã xóa nhóm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataFromDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}




