using System;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Forms;
namespace QuanLyNhaHang
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            InitializeCustomUI();
            RegisterEvents();
        }

        private void InitializeCustomUI()
        {
            // Build Main Top MenuBar
            BuildMainMenus();

            // Build Quick Access ToolBar
            BuildQuickToolBar();
        }

        private void RegisterEvents()
        {
            SetupCloseableTabs(tabMain);

            this.Load += (s, e) =>
            {
                lblUser.Text = $"Tài khoản: {Program.CurrentUser} ({Program.CurrentUserGroup})";
                lblDbInfo.Text = $"CSDL: {Program.CurrentDatabase}";
                
                // Load default welcome or SuDungDichVu form inside MDI container
                OpenFormByName("Sử dụng dịch vụ");
            };

            this.FormClosing += FormMain_FormClosing;
        }

        private void SetupCloseableTabs(TabControl tabControl)
        {
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Padding = new Point(18, 4);

            tabControl.DrawItem += (sender, e) =>
            {
                try
                {
                    TabControl tc = (TabControl)sender;
                    if (e.Index < 0 || e.Index >= tc.TabPages.Count) return;

                    TabPage tabPage = tc.TabPages[e.Index];
                    Rectangle tabRect = tc.GetTabRect(e.Index);

                    bool isSelected = (tc.SelectedIndex == e.Index);

                    Color bgColor = isSelected ? Color.White : Color.FromArgb(240, 240, 240);
                    using (Brush bgBrush = new SolidBrush(bgColor))
                    {
                        e.Graphics.FillRectangle(bgBrush, tabRect);
                    }

                    string title = tabPage.Text;
                    Color textColor = isSelected ? Color.Black : Color.FromArgb(80, 80, 80);
                    Font font = isSelected ? new Font(tc.Font, FontStyle.Bold) : tc.Font;

                    Rectangle textRect = new Rectangle(tabRect.X + 6, tabRect.Y + 2, tabRect.Width - 26, tabRect.Height - 4);
                    TextRenderer.DrawText(e.Graphics, title, font, textRect, textColor,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                    Rectangle closeRect = new Rectangle(tabRect.Right - 18, tabRect.Top + 6, 12, 12);
                    Color xColor = isSelected ? Color.DarkRed : Color.Gray;

                    using (Pen p = new Pen(xColor, 2F))
                    {
                        e.Graphics.DrawLine(p, closeRect.X + 2, closeRect.Y + 2, closeRect.Right - 2, closeRect.Bottom - 2);
                        e.Graphics.DrawLine(p, closeRect.Right - 2, closeRect.Y + 2, closeRect.X + 2, closeRect.Bottom - 2);
                    }
                }
                catch { }
            };

            tabControl.MouseDown += (sender, e) =>
            {
                try
                {
                    TabControl tc = (TabControl)sender;
                    for (int i = 0; i < tc.TabPages.Count; i++)
                    {
                        Rectangle tabRect = tc.GetTabRect(i);
                        Rectangle closeRect = new Rectangle(tabRect.Right - 22, tabRect.Top + 2, 20, 20);

                        if (closeRect.Contains(e.Location))
                        {
                            TabPage pageToRemove = tc.TabPages[i];
                            tc.TabPages.RemoveAt(i);
                            pageToRemove.Dispose();
                            break;
                        }
                    }
                }
                catch { }
            };
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BuildMainMenus()
        {
            menuStripMain.Items.Clear();

            // 1. Root Menu HỆ THỐNG
            ToolStripMenuItem menuHeThong = new ToolStripMenuItem("HỆ THỐNG");
            ToolStripMenuItem menuCoSoDuLieu = new ToolStripMenuItem("Cơ sở dữ liệu...");
            menuCoSoDuLieu.DropDownItems.Add("Tạo mới cơ sở dữ liệu", null, (s, e) => CreateNewDatabaseDirectly());
            menuCoSoDuLieu.DropDownItems.Add("Sao lưu cơ sở dữ liệu", null, (s, e) => BackupDatabase());
            menuCoSoDuLieu.DropDownItems.Add("Phục hồi cơ sở dữ liệu", null, (s, e) => RestoreDatabase());

            menuHeThong.DropDownItems.Add(menuCoSoDuLieu);
            menuHeThong.DropDownItems.Add(new ToolStripSeparator());
            menuHeThong.DropDownItems.Add("Đổi mật khẩu đăng nhập", null, (s, e) => ChangePassword());
            menuHeThong.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem itemLogout = new ToolStripMenuItem("Đăng xuất khỏi hệ thống", null, (s, e) => LogoutSystem());
            itemLogout.ShortcutKeys = Keys.Control | Keys.Shift | Keys.L;

            ToolStripMenuItem itemExit = new ToolStripMenuItem("Thoát khỏi hệ thống", null, (s, e) => this.Close());
            itemExit.ShortcutKeys = Keys.Control | Keys.Q;

            menuHeThong.DropDownItems.Add(itemLogout);
            menuHeThong.DropDownItems.Add(itemExit);

            menuStripMain.Items.Add(menuHeThong);

            // 2. Load dynamic menus exclusively from Firebird database table SMENU
            TryLoadMenusFromDatabase();
        }

        private bool TryLoadMenusFromDatabase()
        {
            string connStr = DbFormService.GetConnectionString(Program.CurrentDatabasePath);
            if (string.IsNullOrEmpty(connStr)) return false;

            try
            {
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            M.ID, 
                            M.NAME, 
                            M.PARENTID, 
                            M.SORTORDER, 
                            M.SFORMID, 
                            M.IMAGE AS MENU_IMAGE, 
                            F.IMAGE32 
                        FROM SMENU M
                        LEFT JOIN SFORM F ON M.SFORMID = F.ID
                        ORDER BY M.SORTORDER, M.ID";

                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            List<MenuItemInfo> menuList = new List<MenuItemInfo>();
                            while (reader.Read())
                            {
                                string id = reader["ID"]?.ToString().Trim();
                                string name = reader["NAME"]?.ToString().Trim();
                                string parentId = reader["PARENTID"] != DBNull.Value ? reader["PARENTID"]?.ToString().Trim() : null;
                                string sortOrder = reader["SORTORDER"]?.ToString().Trim();
                                object menuImage = reader["MENU_IMAGE"] != DBNull.Value ? reader["MENU_IMAGE"] : null;
                                string image32 = reader["IMAGE32"] != DBNull.Value ? reader["IMAGE32"]?.ToString().Trim() : null;

                                if (!string.IsNullOrEmpty(name))
                                {
                                    menuList.Add(new MenuItemInfo
                                    {
                                        Id = id,
                                        Name = name,
                                        ParentId = parentId,
                                        SortOrder = sortOrder,
                                        MenuImage = menuImage,
                                        Image32 = image32
                                    });
                                }
                            }

                            if (menuList.Count == 0) return false;

                            menuList = menuList.OrderBy(m => m.SortOrder ?? "").ThenBy(m => m.Name).ToList();
                            Dictionary<string, ToolStripMenuItem> itemMap = new Dictionary<string, ToolStripMenuItem>();

                            // First pass: Create non-separator ToolStripMenuItems
                            foreach (var m in menuList)
                            {
                                if (IsSeparator(m.Name)) continue;
                                ToolStripMenuItem item = new ToolStripMenuItem(m.Name);
                                item.Image = GetIconForMenuItem(m.Name, m.MenuImage, m.Image32);
                                ApplyShortcutKeys(item);
                                itemMap[m.Id] = item;
                            }

                            // Second pass: Build parent-child tree
                            foreach (var m in menuList)
                            {
                                if (string.IsNullOrEmpty(m.ParentId))
                                {
                                    if (itemMap.TryGetValue(m.Id, out ToolStripMenuItem rootMenu))
                                    {
                                        if (rootMenu.Text.Contains("QUẢN TRỊ"))
                                        {
                                            ToolStripMenuItem devItem = new ToolStripMenuItem("Công cụ nhà phát triển", null, (s, e) => OpenDevTools());
                                            devItem.Image = GetIconForMenuItem("Công cụ nhà phát triển", null, null);
                                            rootMenu.DropDownItems.Add(devItem);

                                            ToolStripMenuItem userPermItem = new ToolStripMenuItem("Người dùng và phân quyền", null, (s, e) => { using(var f = new FormUserManagement()) f.ShowDialog(); });
                                            userPermItem.Image = GetIconForMenuItem("Người dùng và phân quyền", null, null);

                                             ToolStripMenuItem sysConfigItem = new ToolStripMenuItem("Cấu hình toàn hệ thống", null, (s, e) => OpenSystemConfigForm());
                                             sysConfigItem.Image = GetIconForMenuItem("Cấu hình toàn hệ thống", null, null);

                                            rootMenu.DropDownItems.Add(userPermItem);
                                            rootMenu.DropDownItems.Add(sysConfigItem);
                                            rootMenu.DropDownItems.Add(new ToolStripSeparator());
                                        }

                                        menuStripMain.Items.Add(rootMenu);
                                    }
                                }
                                else
                                {
                                    if (itemMap.TryGetValue(m.ParentId, out ToolStripMenuItem parentMenu))
                                    {
                                        if (IsSeparator(m.Name))
                                        {
                                            parentMenu.DropDownItems.Add(new ToolStripSeparator());
                                        }
                                        else if (itemMap.TryGetValue(m.Id, out ToolStripMenuItem childMenu))
                                        {
                                            string formTitle = childMenu.Text;
                                            childMenu.Click += (s, e) => {
                                                if (formTitle == "Người dùng và phân quyền" || formTitle == "Tài khoản người dùng") {
                                                    using (var f = new FormUserManagement()) f.ShowDialog();
                                                } else {
                                                    OpenFormByName(formTitle);
                                                }
                                            };
                                            parentMenu.DropDownItems.Add(childMenu);
                                        }
                                    }
                                }
                            }

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi load menu từ CSDL: " + ex.Message);
                return false;
            }
        }

        private Image GetImageFromDbObject(object dbVal)
        {
            if (dbVal == null || dbVal == DBNull.Value) return null;

            try
            {
                if (dbVal is byte[] bytes && bytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        Image rawImg = Image.FromStream(ms);
                        return new Bitmap(rawImg, new Size(16, 16));
                    }
                }
                else if (dbVal is string strVal && !string.IsNullOrWhiteSpace(strVal))
                {
                    byte[] strBytes = Convert.FromBase64String(strVal.Trim());
                    using (MemoryStream ms = new MemoryStream(strBytes))
                    {
                        Image rawImg = Image.FromStream(ms);
                        return new Bitmap(rawImg, new Size(16, 16));
                    }
                }
            }
            catch { }

            return null;
        }

        private Image GetIconForMenuItem(string menuName, object menuImageObj, string image32Base64)
        {
            return GetImageFromDbObject(menuImageObj) ?? GetImageFromDbObject(image32Base64);
        }

        private void ApplyShortcutKeys(ToolStripMenuItem item)
        {
            string title = item.Text;
            if (title.Equals("Danh mục mặt hàng", StringComparison.OrdinalIgnoreCase))
            {
                item.ShortcutKeys = Keys.Control | Keys.M;
            }
            else if (title.Equals("Sử dụng dịch vụ", StringComparison.OrdinalIgnoreCase))
            {
                item.ShortcutKeys = Keys.Control | Keys.H;
            }
            else if (title.Equals("Quản lý bán hàng", StringComparison.OrdinalIgnoreCase))
            {
                item.ShortcutKeys = Keys.Control | Keys.Q;
            }
            else if (title.Equals("Thống kê doanh thu", StringComparison.OrdinalIgnoreCase))
            {
                item.ShortcutKeys = Keys.Control | Keys.T;
            }
            else if (title.Equals("Thống kê mặt hàng bán", StringComparison.OrdinalIgnoreCase))
            {
                item.ShortcutKeys = Keys.Control | Keys.L;
            }
        }

        private bool IsSeparator(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return true;
            string t = text.Trim();
            return t.All(c => c == '_' || c == '-');
        }

        private void EnsureDefaultReportAndHelpMenus()
        {
            bool hasBaoCao = false;
            bool hasTroGiup = false;

            foreach (ToolStripItem item in menuStripMain.Items)
            {
                if (item.Text != null && item.Text.Contains("BÁO CÁO")) hasBaoCao = true;
                if (item.Text != null && item.Text.Contains("TRỢ GIÚP")) hasTroGiup = true;
            }

            if (!hasBaoCao)
            {
                ToolStripMenuItem menuBaoCao = new ToolStripMenuItem("BÁO CÁO");
                menuBaoCao.DropDownItems.Add(new ToolStripMenuItem("Báo cáo bán hàng theo giờ", GetIconForMenuItem("Báo cáo", null, null), (s, e) => OpenFormByName("Báo cáo bán hàng theo giờ")));
                menuBaoCao.DropDownItems.Add(new ToolStripMenuItem("Báo cáo bán hàng theo nhân viên", GetIconForMenuItem("Báo cáo", null, null), (s, e) => OpenFormByName("Báo cáo bán hàng theo nhân viên")));
                menuBaoCao.DropDownItems.Add(new ToolStripMenuItem("Báo cáo 20 mặt hàng bán chạy nhất", GetIconForMenuItem("Báo cáo", null, null), (s, e) => OpenFormByName("Báo cáo 20 mặt hàng bán chạy nhất")));
                menuStripMain.Items.Add(menuBaoCao);
            }

            if (!hasTroGiup)
            {
                ToolStripMenuItem menuTroGiup = new ToolStripMenuItem("TRỢ GIÚP");
                menuTroGiup.DropDownItems.Add(new ToolStripMenuItem("Hướng dẫn sử dụng", GetIconForMenuItem("Hướng dẫn", null, null), (s, e) => OpenFormByName("Hướng dẫn sử dụng")));
                menuTroGiup.DropDownItems.Add(new ToolStripMenuItem("Giới thiệu phần mềm", GetIconForMenuItem("Giới thiệu", null, null), (s, e) => OpenFormByName("Giới thiệu phần mềm")));
                menuStripMain.Items.Add(menuTroGiup);
            }
        }

        private void BuildFallbackMenus()
        {
            ToolStripMenuItem menuHoatDong = new ToolStripMenuItem("HOẠT ĐỘNG");
            menuHoatDong.DropDownItems.Add(new ToolStripMenuItem("Danh mục bàn khu vực", GetIconForMenuItem("Danh mục bàn khu vực", null, null), (s, e) => OpenFormByName("Danh mục bàn khu vực")));
            menuHoatDong.DropDownItems.Add(new ToolStripMenuItem("Danh mục mặt hàng", GetIconForMenuItem("Danh mục mặt hàng", null, null), (s, e) => OpenFormByName("Danh mục mặt hàng")));
            menuHoatDong.DropDownItems.Add(new ToolStripMenuItem("Sử dụng dịch vụ", GetIconForMenuItem("Sử dụng dịch vụ", null, null), (s, e) => OpenFormByName("Sử dụng dịch vụ")));
            menuHoatDong.DropDownItems.Add(new ToolStripMenuItem("Quản lý bán hàng", GetIconForMenuItem("Quản lý bán hàng", null, null), (s, e) => OpenFormByName("Quản lý bán hàng")));
            menuStripMain.Items.Add(menuHoatDong);
        }

        private class MenuItemInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string ParentId { get; set; }
            public string SortOrder { get; set; }
            public object MenuImage { get; set; }
            public string Image32 { get; set; }
        }

        private void OpenDatabaseForm()
        {
            using (FormDatabase frmDb = new FormDatabase())
            {
                if (frmDb.ShowDialog(this) == DialogResult.OK)
                {
                    lblDbInfo.Text = $"CSDL: {Program.CurrentDatabase}";
                    BuildMainMenus();
                    BuildQuickToolBar();
                }
            }
        }

        private void CreateNewDatabaseDirectly()
        {
            string templatePath = @"d:\QuanLyNhaHang\Database\TEMPLATE.FDB";
            if (!System.IO.File.Exists(templatePath))
            {
                MessageBox.Show($"Không tìm thấy file mẫu template tại:\n{templatePath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save As";
                sfd.Filter = "Firebird Database (*.fdb)|*.fdb|All Files (*.*)|*.*";
                sfd.InitialDirectory = @"d:\QuanLyNhaHang\Database";
                sfd.FileName = "";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.Copy(templatePath, sfd.FileName, true);

                        string dbName = System.IO.Path.GetFileNameWithoutExtension(sfd.FileName);
                        Program.CurrentDatabase = dbName;
                        Program.CurrentDatabasePath = sfd.FileName;
                        Services.DbFormService.DefaultDbPath = sfd.FileName;
                        lblDbInfo.Text = $"CSDL: {dbName}";

                        SaveDatabaseHistory(dbName, sfd.FileName);

                        BuildMainMenus();
                        BuildQuickToolBar();

                        MessageBox.Show($"Đã tạo cơ sở dữ liệu mới thành công tại:\n{sfd.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tạo cơ sở dữ liệu mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveDatabaseHistory(string dbName, string dbPath)
        {
            try
            {
                string configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "databases.config");
                System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();
                if (System.IO.File.Exists(configPath))
                {
                    lines.AddRange(System.IO.File.ReadAllLines(configPath, System.Text.Encoding.UTF8));
                }

                string newEntry = $"{dbName}|{dbPath}";
                if (!lines.Contains(newEntry))
                {
                    lines.Add(newEntry);
                    System.IO.File.WriteAllLines(configPath, lines.ToArray(), System.Text.Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi lưu lịch sử CSDL: " + ex.Message);
            }
        }

        private void BackupDatabase()
        {
            using (FormBackup frmBackup = new FormBackup())
            {
                frmBackup.ShowDialog(this);
            }
        }

        private void RestoreDatabase()
        {
            using (FormRestore frmRestore = new FormRestore())
            {
                if (frmRestore.ShowDialog(this) == DialogResult.OK)
                {
                    lblDbInfo.Text = $"CSDL: {Program.CurrentDatabase}";
                    BuildMainMenus();
                    BuildQuickToolBar();
                }
            }
        }

        private void ChangePassword()
        {
            using (FormChangePassword frmChangePass = new FormChangePassword())
            {
                frmChangePass.ShowDialog(this);
            }
        }

        private void LogoutSystem()
        {
            DialogResult res = MessageBox.Show("Bạn có muốn đăng xuất khỏi hệ thống không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                using (Form1 loginForm = new Form1())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        lblUser.Text = $"Tài khoản: {Program.CurrentUser} ({Program.CurrentUserGroup})";
                        lblDbInfo.Text = $"CSDL: {Program.CurrentDatabase}";
                        this.Show();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void BuildQuickToolBar()
        {
            toolStripQuick.Items.Clear();

            TryLoadQuickToolBarFromDatabase();

            toolStripQuick.Items.Add(new ToolStripSeparator());

            ToolStripButton btnExit = new ToolStripButton("Thoát");
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExit.ForeColor = Color.Red;
            btnExit.Click += (s, e) => this.Close();
            toolStripQuick.Items.Add(btnExit);
        }

        private bool TryLoadQuickToolBarFromDatabase()
        {
            string connStr = DbFormService.GetConnectionString(Program.CurrentDatabasePath);
            if (string.IsNullOrEmpty(connStr)) return false;

            try
            {
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            M.ID, 
                            M.NAME, 
                            M.TOOLBARINDEX, 
                            M.SFORMID, 
                            M.IMAGE AS MENU_IMAGE, 
                            F.NAME AS FORM_NAME, 
                            F.IMAGE32 
                        FROM SMENU M
                        LEFT JOIN SFORM F ON M.SFORMID = F.ID
                        WHERE M.TOOLBAR IS NOT NULL AND M.TOOLBAR <> '0'
                        ORDER BY M.TOOLBARINDEX ASC, M.ID ASC";

                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            List<QuickToolBarItemInfo> tbItems = new List<QuickToolBarItemInfo>();
                            while (reader.Read())
                            {
                                string id = reader["ID"]?.ToString().Trim();
                                string name = reader["NAME"]?.ToString().Trim();
                                string tbIdxStr = reader["TOOLBARINDEX"]?.ToString().Trim();
                                string formName = reader["FORM_NAME"] != DBNull.Value ? reader["FORM_NAME"]?.ToString().Trim() : null;
                                object menuImage = reader["MENU_IMAGE"] != DBNull.Value ? reader["MENU_IMAGE"] : null;
                                string image32 = reader["IMAGE32"] != DBNull.Value ? reader["IMAGE32"]?.ToString().Trim() : null;

                                int sortIndex = 999;
                                if (!string.IsNullOrEmpty(tbIdxStr) && int.TryParse(tbIdxStr, out int parsedIndex))
                                {
                                    sortIndex = parsedIndex;
                                }

                                if (!string.IsNullOrEmpty(name))
                                {
                                    tbItems.Add(new QuickToolBarItemInfo
                                    {
                                        Id = id,
                                        Name = name,
                                        SortIndex = sortIndex,
                                        FormName = formName,
                                        MenuImage = menuImage,
                                        Image32 = image32
                                    });
                                }
                            }

                            if (tbItems.Count == 0) return false;

                            tbItems = tbItems.OrderBy(x => x.SortIndex).ThenBy(x => x.Name).ToList();

                            foreach (var item in tbItems)
                            {
                                if (IsSeparator(item.Name))
                                {
                                    toolStripQuick.Items.Add(new ToolStripSeparator());
                                }
                                else
                                {
                                    ToolStripButton btn = new ToolStripButton(item.Name);
                                    btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                                    Image btnImg = GetImageFromDbObject(item.MenuImage) ?? GetImageFromDbObject(item.Image32);
                                    if (btnImg != null)
                                    {
                                        btn.Image = btnImg;
                                        btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                                    }

                                    string targetForm = !string.IsNullOrEmpty(item.FormName) ? item.FormName : item.Name;
                                    btn.Click += (s, e) => OpenFormByName(targetForm);

                                    toolStripQuick.Items.Add(btn);
                                }
                            }

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi load QuickToolBar từ CSDL: " + ex.Message);
                return false;
            }
        }

        private class QuickToolBarItemInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int SortIndex { get; set; }
            public string FormName { get; set; }
            public object MenuImage { get; set; }
            public string Image32 { get; set; }
        }

        private void OpenFormByName(string formName)
        {
            try
            {
                bool isServiceForm = !string.IsNullOrEmpty(formName) &&
                    (formName.IndexOf("dịch vụ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("SuDungDichVu", StringComparison.OrdinalIgnoreCase) >= 0);

                bool isMatHang = !string.IsNullOrEmpty(formName) &&
                    (string.Equals(formName, "DMATHANG", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "DanhMucMatHang", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "f3784a00-a86f-44d6-86b8-01187cc1a5e2", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "a4a16216-aee9-4dd3-9f92-c1e4d85c06a2", StringComparison.OrdinalIgnoreCase) ||
                     formName.IndexOf("danh mục mặt hàng", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("danh muc mat hang", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("nhóm mặt hàng", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("nhom mat hang", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("m?t h", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("m?c m", StringComparison.OrdinalIgnoreCase) >= 0);

                bool isBanKhuVuc = !string.IsNullOrEmpty(formName) &&
                    (string.Equals(formName, "DBAN", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "DKHUVUC", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "DanhMucBanKhuVuc", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "DanhMucKhuVuc", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "756598f2-e672-4c0f-b6a8-d7d514feb5be", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "f2288345-031a-4e1b-a76d-3b2e537674a6", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "9e2afcb8-7f63-4123-b0f7-c32cc187dd65", StringComparison.OrdinalIgnoreCase) ||
                     formName.IndexOf("bàn khu vực", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("ban khu vuc", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("bàn, khu vực", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("danh mục bàn", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("danh mục khu vực", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("danh muc ban", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("danh muc khu vuc", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     formName.IndexOf("b?n khu", StringComparison.OrdinalIgnoreCase) >= 0);

                bool isKhachHang = !string.IsNullOrEmpty(formName) &&
                    (string.Equals(formName, "DKHACHHANG", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "DNHOMKHACHHANG", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "DanhMucKhachHang", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "f5093034-07a8-41a3-8561-7864cbab2d2e", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "5fcc571a-662d-4953-a83f-6004c732f439", StringComparison.OrdinalIgnoreCase) ||
                     (!string.IsNullOrEmpty(formName) &&
                      formName.IndexOf("thân thiết", StringComparison.OrdinalIgnoreCase) < 0 &&
                      formName.IndexOf("than thiet", StringComparison.OrdinalIgnoreCase) < 0 && (
                          formName.IndexOf("danh mục khách hàng", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("danh muc khach hang", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("nhóm khách hàng", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("nhom khach hang", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("khách hàng", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("khach hang", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("khch hng", StringComparison.OrdinalIgnoreCase) >= 0
                      )));

                bool isKhuyenMai = !string.IsNullOrEmpty(formName) &&
                    (string.Equals(formName, "DDOTKHUYENMAI", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "DLOAIHINHKHUYENMAI", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "DanhMucDotKhuyenMai", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "e1bfaa55-e880-4835-94e4-b98443ded684", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(formName, "1732f45e-07ab-46ff-9489-66273cdb8eda", StringComparison.OrdinalIgnoreCase) ||
                     (!string.IsNullOrEmpty(formName) &&
                      formName.IndexOf("cảnh báo", StringComparison.OrdinalIgnoreCase) < 0 &&
                      formName.IndexOf("canh bao", StringComparison.OrdinalIgnoreCase) < 0 && (
                          formName.IndexOf("đợt khuyến mại", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("dot khuyen mai", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("danh mục đợt khuyến mại", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("danh muc dot khuyen mai", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("khuyến mại", StringComparison.OrdinalIgnoreCase) >= 0 ||
                          formName.IndexOf("khuyen mai", StringComparison.OrdinalIgnoreCase) >= 0
                      )));

                string displayTitle = isServiceForm ? "Sử dụng dịch vụ" : (isMatHang ? "Danh mục mặt hàng" : (isBanKhuVuc ? "Danh mục bàn khu vực" : (isKhachHang ? "Danh mục khách hàng" : (isKhuyenMai ? "Danh mục đợt khuyến mại" : formName))));

                // If tab is already open in tabMain, remove old tab so fresh stitched form is loaded
                for (int i = tabMain.TabPages.Count - 1; i >= 0; i--)
                {
                    TabPage page = tabMain.TabPages[i];
                    if (string.Equals(page.Text, displayTitle, StringComparison.OrdinalIgnoreCase) ||
                        (page.Tag != null && string.Equals(page.Tag.ToString(), displayTitle, StringComparison.OrdinalIgnoreCase)))
                    {
                        tabMain.TabPages.RemoveAt(i);
                    }
                }

                // Create new tab page and load form from DB / Service
                Form targetForm = DbFormService.CreateFormByName(formName);
                if (targetForm != null)
                {
                    if (targetForm is No1Lib.Sys.TreeDataMg)
                    {
                        using (targetForm)
                        {
                            targetForm.StartPosition = FormStartPosition.CenterParent;
                            targetForm.ShowDialog(this);
                        }
                        return;
                    }

                    TabPage newPage = new TabPage(displayTitle) { Tag = displayTitle };
                    targetForm.TopLevel = false;
                    targetForm.FormBorderStyle = FormBorderStyle.None;
                    targetForm.Dock = DockStyle.Fill;
                    targetForm.Tag = displayTitle;
                    targetForm.Text = displayTitle;

                    newPage.Controls.Add(targetForm);
                    tabMain.TabPages.Add(newPage);
                    tabMain.SelectedTab = newPage;
                    targetForm.Show();
                }
                else
                {
                    MessageBox.Show($"Đang mở chức năng: [{displayTitle}]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form [{formName}]: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenDevTools()
        {
            FormFirebirdForms devForm = new FormFirebirdForms();
            devForm.ShowDialog(this);
        }

        private void OpenSystemConfigForm()
        {
            using (FormSystemConfig cfgForm = new FormSystemConfig())
            {
                cfgForm.ShowDialog(this);
            }
        }
    }
}
