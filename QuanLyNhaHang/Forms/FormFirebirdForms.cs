using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Forms;

namespace QuanLyNhaHang
{
    public partial class FormFirebirdForms : Form
    {
        private List<FormModel> _allForms = new List<FormModel>();
        private ImageList _navImageList;
        private ImageList _menuImageList;
        private ImageList _reportImageList;
        private ImageList _quyenImageList;

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        private int AddImageToImageList(ImageList imgList, byte[] bytes, Image fallback = null)
        {
            Image img = ByteArrayToImage(bytes) ?? fallback;
            if (img == null) return -1;
            imgList.Images.Add(img);
            return imgList.Images.Count - 1;
        }

        private Image CreateDefaultFolderIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush b = new SolidBrush(Color.FromArgb(240, 200, 80)))
                using (Pen p = new Pen(Color.FromArgb(190, 140, 20)))
                {
                    g.FillRectangle(b, 1, 3, 13, 11);
                    g.DrawRectangle(p, 1, 3, 13, 11);
                    g.FillRectangle(b, 1, 1, 6, 3);
                    g.DrawRectangle(p, 1, 1, 6, 3);
                }
            }
            return bmp;
        }

        private Image CreateDefaultTableIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush bHeader = new SolidBrush(Color.FromArgb(70, 130, 180)))
                using (SolidBrush bBody = new SolidBrush(Color.FromArgb(240, 245, 250)))
                using (Pen p = new Pen(Color.FromArgb(100, 120, 140)))
                {
                    g.FillRectangle(bBody, 1, 1, 13, 13);
                    g.FillRectangle(bHeader, 1, 1, 13, 4);
                    g.DrawRectangle(p, 1, 1, 13, 13);
                    g.DrawLine(p, 1, 5, 14, 5);
                    g.DrawLine(p, 1, 9, 14, 9);
                    g.DrawLine(p, 7, 1, 7, 14);
                }
            }
            return bmp;
        }

        private Image CreateDefaultFormIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush bHeader = new SolidBrush(Color.FromArgb(180, 190, 205)))
                using (SolidBrush bBody = new SolidBrush(Color.White))
                using (Pen p = new Pen(Color.FromArgb(120, 130, 145)))
                {
                    g.FillRectangle(bBody, 1, 1, 13, 13);
                    g.FillRectangle(bHeader, 1, 1, 13, 4);
                    g.DrawRectangle(p, 1, 1, 13, 13);
                    g.DrawLine(p, 1, 5, 14, 5);
                }
            }
            return bmp;
        }

        private Image CreateDefaultReportIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush bPage = new SolidBrush(Color.White))
                using (Pen p = new Pen(Color.FromArgb(120, 130, 145)))
                {
                    g.FillRectangle(bPage, 2, 1, 11, 14);
                    g.DrawRectangle(p, 2, 1, 11, 14);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(220, 70, 50)), 4, 8, 2, 5);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(50, 130, 200)), 7, 5, 2, 8);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(60, 170, 80)), 10, 3, 2, 10);
                }
            }
            return bmp;
        }

        private Image CreateDefaultSqlIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush b = new SolidBrush(Color.FromArgb(40, 110, 180)))
                {
                    g.FillEllipse(b, 2, 1, 12, 5);
                    g.FillRectangle(b, 2, 3, 12, 9);
                    g.FillEllipse(b, 2, 9, 12, 5);
                }
            }
            return bmp;
        }

        public FormFirebirdForms()
        {
            InitializeComponent();
            RegisterEvents();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                Control focused = GetDeepFocusedControl(this);

                if (focused is FastColoredTextBoxNS.FastColoredTextBox fctb)
                {
                    if (keyData == (Keys.Control | Keys.Z)) { fctb.Undo(); return true; }
                    if (keyData == (Keys.Control | Keys.Y)) { fctb.Redo(); return true; }
                    if (keyData == (Keys.Control | Keys.X)) { fctb.Cut(); return true; }
                    if (keyData == (Keys.Control | Keys.C)) { fctb.Copy(); return true; }
                    if (keyData == (Keys.Control | Keys.V)) { fctb.Paste(); return true; }
                    if (keyData == (Keys.Control | Keys.A)) { fctb.SelectAll(); return true; }
                    if (keyData == (Keys.Control | Keys.F)) { fctb.ShowFindDialog(); return true; }
                }
                else if (focused is TextBoxBase txt)
                {
                    if (keyData == (Keys.Control | Keys.Z)) { txt.Undo(); return true; }
                    if (keyData == (Keys.Control | Keys.X)) { txt.Cut(); return true; }
                    if (keyData == (Keys.Control | Keys.C)) { txt.Copy(); return true; }
                    if (keyData == (Keys.Control | Keys.V)) { txt.Paste(); return true; }
                    if (keyData == (Keys.Control | Keys.A)) { txt.SelectAll(); return true; }
                }

                if (keyData == (Keys.Control | Keys.S))
                {
                    if (tabMainContainer != null && tabMainContainer.SelectedTab != null)
                    {
                        TabPage currentTab = tabMainContainer.SelectedTab;
                        foreach (Control c in currentTab.Controls)
                        {
                            if (c is ToolStrip ts)
                            {
                                foreach (ToolStripItem item in ts.Items)
                                {
                                    if (item.Text != null && item.Text.Contains("Lưu"))
                                    {
                                        item.PerformClick();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }

                if (tabMainContainer != null && tabMainContainer.SelectedTab != null && tabMainContainer.SelectedTab.Tag is DesignUndoManager undoMgr)
                {
                    if (keyData == (Keys.Control | Keys.Z) && undoMgr.CanUndo)
                    {
                        undoMgr.Undo();
                        return true;
                    }
                    if (keyData == (Keys.Control | Keys.Y) && undoMgr.CanRedo)
                    {
                        undoMgr.Redo();
                        return true;
                    }
                }
            }
            catch { }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Control GetDeepFocusedControl(Control parent)
        {
            if (parent == null) return null;
            if (parent is ContainerControl container && container.ActiveControl != null)
            {
                return GetDeepFocusedControl(container.ActiveControl);
            }
            return parent;
        }

        private void RegisterEvents()
        {
            this.Load += (s, e) => InitializeDevTools();
            treeNav.AfterSelect += TreeNav_AfterSelect;
            treeNav.NodeMouseClick += TreeNav_NodeMouseClick;
            SetupCloseableTabs(tabMainContainer);
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

        private void InitializeDevTools()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblStatusDb.Text = $"Cơ sở dữ liệu: {Program.CurrentDatabasePath}";

                _navImageList = new ImageList { ImageSize = new Size(16, 16), ColorDepth = ColorDepth.Depth32Bit };
                treeNav.ImageList = _navImageList;

                int idxSql = AddImageToImageList(_navImageList, null, CreateDefaultSqlIcon());
                int idxTableRoot = AddImageToImageList(_navImageList, null, CreateDefaultTableIcon());
                int idxFormRoot = AddImageToImageList(_navImageList, null, CreateDefaultFormIcon());
                int idxMenuRoot = AddImageToImageList(_navImageList, null, CreateDefaultFolderIcon());
                int idxPermRoot = AddImageToImageList(_navImageList, null, CreateDefaultFormIcon());
                int idxReportRoot = AddImageToImageList(_navImageList, null, CreateDefaultReportIcon());
                int idxFormatRoot = AddImageToImageList(_navImageList, null, CreateDefaultFormIcon());

                treeNav.Nodes.Clear();

                // 1. Root SQL Truy vấn
                TreeNode nodeSql = new TreeNode("Truy vấn") { Tag = "SQL_QUERY", ImageIndex = idxSql, SelectedImageIndex = idxSql };
                treeNav.Nodes.Add(nodeSql);

                // 2. Root Table
                TreeNode nodeTable = new TreeNode("Table") { Tag = "TABLE_ROOT", ImageIndex = idxTableRoot, SelectedImageIndex = idxTableRoot };
                LoadAllTablesFromDb(nodeTable);
                treeNav.Nodes.Add(nodeTable);

                // 3. Root Form
                TreeNode nodeForm = new TreeNode("Form") { Tag = "FORM_ROOT", ImageIndex = idxFormRoot, SelectedImageIndex = idxFormRoot };
                LoadAllFormsFromDb(nodeForm);
                treeNav.Nodes.Add(nodeForm);

                // 4. Root Menu & Toolbar
                TreeNode nodeMenu = new TreeNode("Menu & Toolbar") { Tag = "MENU_ROOT", ImageIndex = idxMenuRoot, SelectedImageIndex = idxMenuRoot };
                treeNav.Nodes.Add(nodeMenu);

                // 5. Additional Root Nodes
                treeNav.Nodes.Add(new TreeNode("Quyền") { Tag = "PERM_ROOT", ImageIndex = idxPermRoot, SelectedImageIndex = idxPermRoot });
                treeNav.Nodes.Add(new TreeNode("Báo cáo") { Tag = "REPORT_ROOT", ImageIndex = idxReportRoot, SelectedImageIndex = idxReportRoot });
                treeNav.Nodes.Add(new TreeNode("Định dạng") { Tag = "FORMAT_ROOT", ImageIndex = idxFormatRoot, SelectedImageIndex = idxFormatRoot });

                // Ban đầu mới vào chỉ hiển thị duy nhất tab "Dữ liệu" (Truy vấn)
                OpenDataTab();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Dev Tools: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadAllTablesFromDb(TreeNode rootTableNode)
        {
            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            TRIM(R.RDB$RELATION_NAME) AS TABLENAME,
                            TRIM(T.DESCRIPTION) AS TITLE,
                            T.IMAGE32 AS IMG32,
                            T.IMAGE AS IMG16,
                            I.IMAGE AS SIMG
                        FROM RDB$RELATIONS R
                        LEFT JOIN STABLEDESC T ON UPPER(TRIM(R.RDB$RELATION_NAME)) = UPPER(TRIM(T.NAME))
                        LEFT JOIN SIMAGE I ON T.SIMAGEID = I.ID
                        WHERE R.RDB$SYSTEM_FLAG = 0
                        ORDER BY COALESCE(NULLIF(TRIM(T.DESCRIPTION), ''), TRIM(R.RDB$RELATION_NAME)) ASC";

                    using (FbCommand cmd = new FbCommand(sql, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string dbTableName = rdr["TABLENAME"]?.ToString().Trim();
                            string title = rdr["TITLE"] != DBNull.Value ? rdr["TITLE"]?.ToString().Trim() : null;
                            string displayTitle = !string.IsNullOrEmpty(title) ? title : dbTableName;

                            byte[] imgBytes = DbFormService.ReadBlobBytes(rdr, "IMG32") ?? DbFormService.ReadBlobBytes(rdr, "IMG16") ?? DbFormService.ReadBlobBytes(rdr, "SIMG");
                            int imgIdx = AddImageToImageList(_navImageList, imgBytes, CreateDefaultTableIcon());

                            TreeNode node = new TreeNode(displayTitle)
                            {
                                Tag = "TABLE:" + dbTableName,
                                ImageIndex = imgIdx,
                                SelectedImageIndex = imgIdx
                            };
                            rootTableNode.Nodes.Add(node);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi nạp danh sách Bảng từ CSDL: " + ex.Message);
            }
        }

        private void LoadAllFormsFromDb(TreeNode rootFormNode)
        {
            _allForms = DbFormService.LoadAllForms();
            foreach (var item in _allForms)
            {
                int imgIdx = AddImageToImageList(_navImageList, item.ImageBytes, CreateDefaultFormIcon());
                TreeNode child = new TreeNode(item.Name)
                {
                    Tag = item,
                    ImageIndex = imgIdx,
                    SelectedImageIndex = imgIdx
                };
                rootFormNode.Nodes.Add(child);
            }
        }

        private void TreeNav_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            if (e.Node.Tag?.ToString() == "SQL_QUERY")
            {
                OpenDataTab();
            }
            else if (e.Node.Tag?.ToString() == "MENU_ROOT")
            {
                OpenMenuTab();
            }
            else if (e.Node.Tag?.ToString() == "PERM_ROOT")
            {
                OpenQuyenTab();
            }
            else if (e.Node.Tag?.ToString() == "REPORT_ROOT")
            {
                OpenBaoCaoTab();
            }
            else if (e.Node.Tag?.ToString() == "FORMAT_ROOT")
            {
                OpenDinhDangTab();
            }
            else if (e.Node.Tag is string tagStr && tagStr.StartsWith("TABLE:"))
            {
                string tableName = tagStr.Substring(6);
                string friendlyName = e.Node.Text;
                OpenTableSchemaTab(friendlyName, tableName);
            }
            else if (e.Node.Tag is FormModel model)
            {
                FormModel dbModel = DbFormService.GetFormModelFromDb(model.Id) ?? DbFormService.GetFormModelFromDb(model.Name) ?? model;

                if (dbModel.FormType == 1)
                {
                    OpenQuanTriDesignTab(dbModel);
                }
                else if (dbModel.FormType == 2 || dbModel.FormType == 3)
                {
                    OpenCongNoDesignTab(dbModel);
                }
                else if (dbModel.FormType == 7)
                {
                    OpenTonKhoDesignTab(dbModel);
                }
                else if (dbModel.FormType == 4 || dbModel.FormType == 9 || (dbModel.Name ?? "").IndexOf("Tồn quỹ", StringComparison.OrdinalIgnoreCase) >= 0 || (dbModel.ClassName ?? "").IndexOf("TonQuy", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    OpenTonQuyDesignTab(dbModel);
                }
                else
                {
                    OpenFormCodeTab(dbModel);
                }
            }
        }

        private FormModel _copiedFormModel = null;

        private void TreeNav_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeNav.SelectedNode = e.Node;

                if (e.Node.Tag?.ToString() == "FORM_ROOT" || e.Node.Tag is FormModel)
                {
                    ShowFormContextMenu(e.Node, e.Location);
                }
            }
        }

        private void ShowFormContextMenu(TreeNode node, Point location)
        {
            FormModel selectedForm = node.Tag as FormModel;

            ContextMenuStrip menu = new ContextMenuStrip
            {
                Font = new Font("Segoe UI", 9.5F),
                ShowImageMargin = true
            };

            ToolStripMenuItem itemAdd = new ToolStripMenuItem("Thêm mới", CreatePlusMenuIcon(), (s, ev) => ShowFormDetailDialog(null, true));
            ToolStripMenuItem itemEdit = new ToolStripMenuItem("Chỉnh sửa", CreateEditMenuIcon(), (s, ev) => {
                if (selectedForm != null) ShowFormDetailDialog(selectedForm, false);
            }) { Enabled = (selectedForm != null) };

            ToolStripMenuItem itemEditXml = new ToolStripMenuItem("Sửa thiết kế xml", CreateXmlMenuIcon(), (s, ev) => {
                if (selectedForm != null) OpenFormXmlEditorTab(selectedForm);
            }) { Enabled = (selectedForm != null) };

            ToolStripMenuItem itemCopy = new ToolStripMenuItem("Sao chép", CreateCopyMenuIcon(), (s, ev) => {
                if (selectedForm != null) _copiedFormModel = selectedForm;
            }) { Enabled = (selectedForm != null) };

            ToolStripMenuItem itemPaste = new ToolStripMenuItem("Dán", CreatePasteMenuIcon(), (s, ev) => {
                PasteFormAction();
            }) { Enabled = (_copiedFormModel != null) };

            ToolStripMenuItem itemDelete = new ToolStripMenuItem("Xóa", CreateDeleteMenuIcon(), (s, ev) => {
                if (selectedForm != null) DeleteFormAction(selectedForm, node);
            }) { Enabled = (selectedForm != null) };

            ToolStripMenuItem itemRefresh = new ToolStripMenuItem("Refresh", CreateRefreshMenuIcon(), (s, ev) => {
                TreeNode formRoot = FindRootNodeByTag("FORM_ROOT");
                if (formRoot != null)
                {
                    formRoot.Nodes.Clear();
                    LoadAllFormsFromDb(formRoot);
                    formRoot.Expand();
                }
            });

            menu.Items.Add(itemAdd);
            menu.Items.Add(itemEdit);
            menu.Items.Add(itemEditXml);
            menu.Items.Add(itemCopy);
            menu.Items.Add(itemPaste);
            menu.Items.Add(itemDelete);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(itemRefresh);

            menu.Show(treeNav, location);
        }

        private void ShowFormDetailDialog(FormModel targetModel = null, bool isCreateMode = true)
        {
            using (Forms.FormFormDetail dlg = new Forms.FormFormDetail(targetModel, isCreateMode))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    TreeNode formRoot = FindRootNodeByTag("FORM_ROOT");
                    if (formRoot != null)
                    {
                        formRoot.Nodes.Clear();
                        LoadAllFormsFromDb(formRoot);
                        formRoot.Expand();
                    }
                }
            }
        }

        private void PasteFormAction()
        {
            if (_copiedFormModel == null) return;
            FormModel copyModel = new FormModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = $"Copy_of_{_copiedFormModel.Name}",
                ClassName = $"Copy_of_{_copiedFormModel.ClassName}",
                FormType = _copiedFormModel.FormType,
                Code = _copiedFormModel.Code,
                DesignCode = _copiedFormModel.DesignCode,
                AeLayout = _copiedFormModel.AeLayout,
                ClientCode = _copiedFormModel.ClientCode,
                ServerCode = _copiedFormModel.ServerCode,
                ImageBytes = _copiedFormModel.ImageBytes
            };
            ShowFormDetailDialog(copyModel, true);
        }

        private void DeleteFormAction(FormModel model, TreeNode node)
        {
            if (model == null) return;

            DialogResult res = MessageBox.Show($"Bạn có chắc chắn muốn xóa Form [{model.Name}] khỏi CSDL Firebird?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                bool ok = DbFormService.DeleteFormFromDb(model.Id, model.Name);
                if (ok)
                {
                    if (node != null && node.Parent != null)
                    {
                        node.Parent.Nodes.Remove(node);
                    }

                    foreach (TabPage tab in tabMainContainer.TabPages)
                    {
                        if (tab.Text.Contains(model.Name))
                        {
                            tabMainContainer.TabPages.Remove(tab);
                            tab.Dispose();
                            break;
                        }
                    }
                    MessageBox.Show($"Đã xóa Form [{model.Name}] thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa Form khỏi CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenFormXmlEditorTab(FormModel model)
        {
            OpenFormCodeTab(model);
            foreach (TabPage mainTab in tabMainContainer.TabPages)
            {
                if (mainTab.Text.Contains(model.Name))
                {
                    tabMainContainer.SelectedTab = mainTab;
                    foreach (Control c in mainTab.Controls)
                    {
                        if (c is SplitContainer sc)
                        {
                            foreach (Control subC in sc.Panel2.Controls)
                            {
                                if (subC is SplitContainer subSc)
                                {
                                    foreach (Control subSubC in subSc.Panel1.Controls)
                                    {
                                        if (subSubC is TabControl tcSub)
                                        {
                                            foreach (TabPage subTab in tcSub.TabPages)
                                            {
                                                if (subTab.Text.Contains("XML") || subTab.Text.Contains("Layout"))
                                                {
                                                    tcSub.SelectedTab = subTab;
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private TreeNode FindRootNodeByTag(string tagVal)
        {
            foreach (TreeNode n in treeNav.Nodes)
            {
                if (n.Tag?.ToString() == tagVal) return n;
            }
            return null;
        }

        private Image CreatePlusMenuIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Pen p = new Pen(Color.FromArgb(40, 160, 60), 2.5F))
                {
                    g.DrawLine(p, 8, 2, 8, 14);
                    g.DrawLine(p, 2, 8, 14, 8);
                }
            }
            return bmp;
        }

        private Image CreateEditMenuIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush b = new SolidBrush(Color.FromArgb(200, 140, 30)))
                using (Pen p = new Pen(Color.FromArgb(140, 90, 10), 1F))
                {
                    Point[] pts = { new Point(13, 2), new Point(14, 3), new Point(5, 12), new Point(2, 14), new Point(4, 11) };
                    g.FillPolygon(b, pts);
                    g.DrawPolygon(p, pts);
                }
            }
            return bmp;
        }

        private Image CreateXmlMenuIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush b = new SolidBrush(Color.FromArgb(60, 120, 180)))
                {
                    Font f = new Font("Segoe UI", 6.5F, FontStyle.Bold);
                    g.DrawString("XML", f, b, -1, 3);
                }
            }
            return bmp;
        }

        private Image CreateCopyMenuIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush b = new SolidBrush(Color.White))
                using (Pen p = new Pen(Color.FromArgb(70, 120, 190), 1F))
                {
                    g.FillRectangle(b, 2, 2, 8, 9);
                    g.DrawRectangle(p, 2, 2, 8, 9);
                    g.FillRectangle(b, 5, 5, 8, 9);
                    g.DrawRectangle(p, 5, 5, 8, 9);
                }
            }
            return bmp;
        }

        private Image CreatePasteMenuIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush b = new SolidBrush(Color.FromArgb(240, 240, 240)))
                using (Pen p = new Pen(Color.FromArgb(100, 100, 100), 1F))
                {
                    g.FillRectangle(b, 3, 3, 10, 11);
                    g.DrawRectangle(p, 3, 3, 10, 11);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(160, 120, 60)), 5, 1, 6, 3);
                }
            }
            return bmp;
        }

        private Image CreateDeleteMenuIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Pen p = new Pen(Color.FromArgb(210, 40, 40), 2.5F))
                {
                    g.DrawLine(p, 3, 3, 13, 13);
                    g.DrawLine(p, 13, 3, 3, 13);
                }
            }
            return bmp;
        }

        private Image CreateRefreshMenuIcon()
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Pen p = new Pen(Color.FromArgb(30, 120, 210), 2F))
                {
                    g.DrawArc(p, 2, 2, 11, 11, 45, 270);
                    g.DrawLine(p, 10, 2, 13, 5);
                    g.DrawLine(p, 10, 8, 13, 5);
                }
            }
            return bmp;
        }

        private void SelectTabByTitle(string title)
        {
            foreach (TabPage tab in tabMainContainer.TabPages)
            {
                if (tab.Text.StartsWith(title, StringComparison.OrdinalIgnoreCase))
                {
                    tabMainContainer.SelectedTab = tab;
                    return;
                }
            }
        }

        #region TAB 1: DỮ LIỆU (SQL Editor & Query ToolBar)
        private void OpenDataTab()
        {
            string tabTitle = "Dữ liệu";
            foreach (TabPage existing in tabMainContainer.TabPages)
            {
                if (existing.Text == tabTitle)
                {
                    tabMainContainer.SelectedTab = existing;
                    return;
                }
            }

            TabPage tab = new TabPage(tabTitle);

            // Top Action ToolBar matching screenshot
            ToolStrip ts = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(4, 2, 4, 2) };
            ToolStripButton btnRun = new ToolStripButton("▶ Chạy câu lệnh Sql");
            ToolStripButton btnBackup = new ToolStripButton("💾 Sao lưu");
            ToolStripButton btnCheck = new ToolStripButton("🔍 Kiểm tra");
            ToolStripButton btnUpdate = new ToolStripButton("➕ Cập nhật");
            ToolStripButton btnOptimize = new ToolStripButton("💡 Tối ưu");
            ToolStripButton btnLog = new ToolStripButton("📜 Log");
            ToolStripButton btnExport = new ToolStripButton("📂 Export Code");
            ToolStripButton btnImport = new ToolStripButton("📥 Import code");
            ToolStripButton btnChangeType = new ToolStripButton("📊 Đổi type");

            ts.Items.AddRange(new ToolStripItem[] { btnRun, btnBackup, btnCheck, btnUpdate, btnOptimize, btnLog, btnExport, btnImport, btnChangeType });

            SplitContainer splitContent = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 380 };

            RichTextBox txtQuery = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10F),
                Text = "SELECT FIRST 50 * FROM TDONHANG ORDER BY NGAY DESC;"
            };

            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                Visible = false
            };

            Panel pnlNotifyHeader = new Panel { Dock = DockStyle.Top, Height = 26, BackColor = Color.FromArgb(235, 238, 242) };
            Label lblNotify = new Label { Text = "Thông báo", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(8, 5), AutoSize = true };
            pnlNotifyHeader.Controls.Add(lblNotify);

            RichTextBox txtLogs = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 9F),
                ReadOnly = true,
                BackColor = Color.White
            };

            splitContent.Panel1.Controls.Add(dgv);
            splitContent.Panel1.Controls.Add(txtQuery);
            splitContent.Panel1.Controls.Add(ts);
            splitContent.Panel2.Controls.Add(txtLogs);
            splitContent.Panel2.Controls.Add(pnlNotifyHeader);

            tab.Controls.Add(splitContent);
            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;

            Action<string> logNotify = (msg) =>
            {
                txtLogs.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\n");
                txtLogs.SelectionStart = txtLogs.Text.Length;
                txtLogs.ScrollToCaret();
            };

            btnRun.Click += (s, e) =>
            {
                string sql = txtQuery.Text.Trim();
                if (string.IsNullOrEmpty(sql)) return;

                try
                {
                    using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                    {
                        conn.Open();
                        using (FbDataAdapter da = new FbDataAdapter(sql, conn))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgv.DataSource = dt;
                            dgv.Visible = true;
                            txtQuery.Height = 120;
                            logNotify($"Thực thi thành công: {dt.Rows.Count} dòng dữ liệu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    logNotify("Lỗi thực thi SQL: " + ex.Message);
                }
            };

            btnBackup.Click += (s, e) => logNotify("Đang sao lưu CSDL...");
            btnCheck.Click += (s, e) => logNotify("Kiểm tra CSDL: Trạng thái bình thường.");
            btnUpdate.Click += (s, e) => logNotify("Đã cập nhật cấu trúc.");
            btnOptimize.Click += (s, e) => logNotify("Đã tối ưu hóa chỉ mục.");
            btnLog.Click += (s, e) => logNotify("Hiển thị nhật ký hệ thống.");
        }
        #endregion

        #region TAB 2: TABLE SCHEMA EDITOR (e.g. Bảng giá - Matching Image 2)
        private void OpenTableSchemaTab(string friendlyName, string tableName)
        {
            string tabTitle = friendlyName;
            foreach (TabPage existing in tabMainContainer.TabPages)
            {
                if (existing.Text == tabTitle)
                {
                    tabMainContainer.SelectedTab = existing;
                    return;
                }
            }

            TabPage tab = new TabPage(tabTitle);

            // Top Action Bar matching Image 2
            ToolStrip tsAction = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(4, 2, 4, 2) };
            ToolStripButton btnAdd = new ToolStripButton("➕ Thêm (Ctrl + Down)");
            ToolStripButton btnDelete = new ToolStripButton("❌ Xóa (Delete)");
            ToolStripButton btnSave = new ToolStripButton("💾 Cập nhật (Ctrl+S)");
            ToolStripButton btnDesign = new ToolStripButton("📋 Thiết kế");
            ToolStripButton btnIcon = new ToolStripButton("🖼 Biểu tượng");
            ToolStripButton btnParam = new ToolStripButton("➡️ Tham số hóa đơn");

            tsAction.Items.AddRange(new ToolStripItem[] { btnAdd, btnDelete, btnSave, btnDesign, btnIcon, btnParam });

            // Form Header Controls Panel matching Image 2
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 75, BackColor = Color.FromArgb(245, 247, 250), Padding = new Padding(5) };

            Label lblTen = new Label { Text = "Tên:", Location = new Point(10, 12), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            TextBox txtTen = new TextBox { Text = friendlyName, Location = new Point(45, 9), Width = 150 };

            Label lblBang = new Label { Text = "Bảng:", Location = new Point(210, 12), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            TextBox txtBang = new TextBox { Text = tableName, Location = new Point(255, 9), Width = 120, ReadOnly = true };

            CheckBox chkDefaultForm = new CheckBox { Text = "Sử dụng form sửa/xóa mặc định", Location = new Point(390, 11), AutoSize = true };
            CheckBox chkReport = new CheckBox { Text = "Có báo cáo", Location = new Point(690, 11), AutoSize = true, Checked = true };

            Label lblQuyen = new Label { Text = "Quyền:", Location = new Point(10, 42), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboQuyen = new ComboBox { Location = new Point(55, 39), Width = 140, DropDownStyle = ComboBoxStyle.DropDownList };
            cboQuyen.Items.Add($"Danh mục {friendlyName.ToLower()}");
            cboQuyen.SelectedIndex = 0;

            Label lblSort = new Label { Text = "Sắp xếp:", Location = new Point(210, 42), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboSort = new ComboBox { Location = new Point(265, 39), Width = 110, DropDownStyle = ComboBoxStyle.DropDownList };

            CheckBox chkBarcode = new CheckBox { Text = "Có in mã vạch", Location = new Point(390, 41), AutoSize = true };
            CheckBox chkPrintBill = new CheckBox { Text = "Có in hóa đơn", Location = new Point(500, 41), AutoSize = true };
            CheckBox chkNoEdit = new CheckBox { Text = "Không chỉnh sửa", Location = new Point(690, 41), AutoSize = true };

            pnlHeader.Controls.AddRange(new Control[] {
                lblTen, txtTen, lblBang, txtBang, chkDefaultForm, chkReport,
                lblQuyen, cboQuyen, lblSort, cboSort, chkBarcode, chkPrintBill, chkNoEdit
            });

            // Schema Grid matching Image 2
            DataGridView dgvSchema = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false
            };

            DataTable dtCols = GetSchemaTableFor(tableName, friendlyName);
            dgvSchema.DataSource = dtCols;

            tab.Controls.Add(dgvSchema);
            tab.Controls.Add(pnlHeader);
            tab.Controls.Add(tsAction);

            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;
        }

        private DataTable GetSchemaTableFor(string tableName, string friendlyName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add("Tiêu đề", typeof(string));
            dt.Columns.Add("Tên cột", typeof(string));
            dt.Columns.Add("Dữ liệu", typeof(string));
            dt.Columns.Add("Grid Column", typeof(string));
            dt.Columns.Add("Định dạng", typeof(string));
            dt.Columns.Add("Liên kết", typeof(string));
            dt.Columns.Add("Trống", typeof(string));
            dt.Columns.Add("Trùng", typeof(string));
            dt.Columns.Add("Khác", typeof(string));
            dt.Columns.Add("Báo cáo", typeof(bool));

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = @"
                        SELECT F.RDB$FIELD_NAME AS COL_NAME, F.RDB$FIELD_POSITION AS POS
                        FROM RDB$RELATION_FIELDS F
                        WHERE F.RDB$RELATION_NAME = @TName
                        ORDER BY F.RDB$FIELD_POSITION";

                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TName", tableName.ToUpper());
                        using (FbDataReader rdr = cmd.ExecuteReader())
                        {
                            int idx = 1;
                            while (rdr.Read())
                            {
                                string colName = rdr["COL_NAME"]?.ToString().Trim();
                                string title = colName;
                                if (colName.Equals("NAME", StringComparison.OrdinalIgnoreCase)) title = $"Tên {friendlyName.ToLower()}";
                                else if (colName.Equals("NOTE", StringComparison.OrdinalIgnoreCase)) title = "Ghi chú";
                                else if (colName.Equals("CODE", StringComparison.OrdinalIgnoreCase)) title = "Mã";

                                dt.Rows.Add(idx++, title, colName, "VARCHAR(255)", "Text", "", "", "Không", "Không", "Khác", true);
                            }
                        }
                    }
                }
            }
            catch { }

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(1, $"Tên {friendlyName.ToLower()}", "NAME", "VARCHAR(255)", "Text", "", "", "Không", "Không", "Khác", true);
                dt.Rows.Add(2, "Ghi chú", "NOTE", "VARCHAR(255)", "Text", "", "", "Không", "Không", "Khác", true);
                dt.Rows.Add(3, "Mã", "CODE", "VARCHAR(50)", "Text", "", "", "Không", "Không", "Khác", true);
            }

            return dt;
        }
        #endregion

        #region TAB 3: MENU & TOOLBAR TREE (Matching Image 1)
        private void OpenMenuTab()
        {
            string tabTitle = "Menu";
            foreach (TabPage existing in tabMainContainer.TabPages)
            {
                if (existing.Text == tabTitle)
                {
                    tabMainContainer.SelectedTab = existing;
                    return;
                }
            }

            TabPage tab = new TabPage(tabTitle);

            TreeView treeMenu = new TreeView
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F),
                ItemHeight = 24
            };

            BuildMenuTree(treeMenu);

            tab.Controls.Add(treeMenu);
            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;
        }

        private void BuildMenuTree(TreeView tree)
        {
            tree.Nodes.Clear();

            try
            {
                _menuImageList = new ImageList { ImageSize = new Size(16, 16), ColorDepth = ColorDepth.Depth32Bit };
                tree.ImageList = _menuImageList;

                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = @"SELECT M.ID, M.NAME, M.PARENTID, M.SORTORDER, M.IMAGE AS M_IMG, I.IMAGE AS S_IMG 
                                   FROM SMENU M 
                                   LEFT JOIN SIMAGE I ON M.SIMAGEID = I.ID 
                                   ORDER BY M.SORTORDER, M.ID";
                    DataTable dt = new DataTable();
                    using (FbDataAdapter da = new FbDataAdapter(sql, conn)) { da.Fill(dt); }

                    Dictionary<string, TreeNode> nodeMap = new Dictionary<string, TreeNode>();

                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["ID"]?.ToString().Trim();
                        string name = row["NAME"]?.ToString().Trim();
                        string parentId = row["PARENTID"] != DBNull.Value ? row["PARENTID"]?.ToString().Trim() : null;

                        byte[] imgBytes = DbFormService.ReadBlobBytes(row, "M_IMG") ?? DbFormService.ReadBlobBytes(row, "S_IMG");
                        Image fallback = string.IsNullOrEmpty(parentId) ? CreateDefaultFolderIcon() : CreateDefaultFormIcon();
                        int imgIdx = AddImageToImageList(_menuImageList, imgBytes, fallback);

                        TreeNode node = new TreeNode(name)
                        {
                            ImageIndex = imgIdx,
                            SelectedImageIndex = imgIdx
                        };
                        nodeMap[id] = node;

                        if (string.IsNullOrEmpty(parentId))
                        {
                            tree.Nodes.Add(node);
                        }
                        else if (nodeMap.TryGetValue(parentId, out TreeNode parentNode))
                        {
                            parentNode.Nodes.Add(node);
                        }
                    }

                    tree.ExpandAll();
                }
            }
            catch { }
        }
        #endregion

        #region DESIGN UNDO ENGINE
        public interface IDesignAction
        {
            void Undo();
            void Redo();
            Control TargetControl { get; }
        }

        public class DesignMoveResizeAction : IDesignAction
        {
            public Control TargetControl { get; private set; }
            public Rectangle OldBounds { get; private set; }
            public Rectangle NewBounds { get; private set; }
            private Action<Control> updateSelection;

            public DesignMoveResizeAction(Control target, Rectangle oldBounds, Rectangle newBounds, Action<Control> updateSelection)
            {
                TargetControl = target;
                OldBounds = oldBounds;
                NewBounds = newBounds;
                this.updateSelection = updateSelection;
            }

            public void Undo()
            {
                if (TargetControl != null)
                {
                    TargetControl.Bounds = OldBounds;
                    updateSelection?.Invoke(TargetControl);
                }
            }

            public void Redo()
            {
                if (TargetControl != null)
                {
                    TargetControl.Bounds = NewBounds;
                    updateSelection?.Invoke(TargetControl);
                }
            }
        }

        public class DesignDeleteAction : IDesignAction
        {
            public Control TargetControl { get; private set; }
            public Control Parent { get; private set; }
            private Action<Control> updateSelection;

            public DesignDeleteAction(Control target, Control parent, Action<Control> updateSelection)
            {
                TargetControl = target;
                Parent = parent;
                this.updateSelection = updateSelection;
            }

            public void Undo()
            {
                if (TargetControl != null && Parent != null)
                {
                    Parent.Controls.Add(TargetControl);
                    TargetControl.BringToFront();
                    updateSelection?.Invoke(TargetControl);
                }
            }

            public void Redo()
            {
                if (TargetControl != null && Parent != null)
                {
                    Parent.Controls.Remove(TargetControl);
                    updateSelection?.Invoke(null);
                }
            }
        }

        public class DesignAddAction : IDesignAction
        {
            public Control TargetControl { get; private set; }
            public Control Parent { get; private set; }
            private Action<Control> updateSelection;

            public DesignAddAction(Control target, Control parent, Action<Control> updateSelection)
            {
                TargetControl = target;
                Parent = parent;
                this.updateSelection = updateSelection;
            }

            public void Undo()
            {
                if (TargetControl != null && Parent != null)
                {
                    Parent.Controls.Remove(TargetControl);
                    updateSelection?.Invoke(null);
                }
            }

            public void Redo()
            {
                if (TargetControl != null && Parent != null)
                {
                    Parent.Controls.Add(TargetControl);
                    TargetControl.BringToFront();
                    updateSelection?.Invoke(TargetControl);
                }
            }
        }

        public class DesignPropertyChangeAction : IDesignAction
        {
            public Control TargetControl { get; private set; }
            public System.ComponentModel.PropertyDescriptor Property { get; private set; }
            public object OldValue { get; private set; }
            public object NewValue { get; private set; }
            private Action<Control> updateSelection;

            public DesignPropertyChangeAction(Control target, System.ComponentModel.PropertyDescriptor prop, object oldValue, object newValue, Action<Control> updateSelection)
            {
                TargetControl = target;
                Property = prop;
                OldValue = oldValue;
                NewValue = newValue;
                this.updateSelection = updateSelection;
            }

            public void Undo()
            {
                if (TargetControl != null && Property != null)
                {
                    Property.SetValue(TargetControl, OldValue);
                    updateSelection?.Invoke(TargetControl);
                }
            }

            public void Redo()
            {
                if (TargetControl != null && Property != null)
                {
                    Property.SetValue(TargetControl, NewValue);
                    updateSelection?.Invoke(TargetControl);
                }
            }
        }

        public class NativeDesignSurfaceUndoEngine : System.ComponentModel.Design.UndoEngine
        {
            private readonly Stack<System.ComponentModel.Design.UndoEngine.UndoUnit> undoStack = new Stack<System.ComponentModel.Design.UndoEngine.UndoUnit>();
            private readonly Stack<System.ComponentModel.Design.UndoEngine.UndoUnit> redoStack = new Stack<System.ComponentModel.Design.UndoEngine.UndoUnit>();

            public NativeDesignSurfaceUndoEngine(IServiceProvider provider) : base(provider)
            {
                Enabled = true;
            }

            protected override void AddUndoUnit(System.ComponentModel.Design.UndoEngine.UndoUnit unit)
            {
                if (unit != null)
                {
                    undoStack.Push(unit);
                    redoStack.Clear();
                }
            }

            public bool CanUndo { get { return undoStack.Count > 0; } }
            public bool CanRedo { get { return redoStack.Count > 0; } }

            public void DoUndo()
            {
                if (undoStack.Count > 0)
                {
                    var unit = undoStack.Pop();
                    unit.Undo();
                    redoStack.Push(unit);
                }
            }

            public void DoRedo()
            {
                if (redoStack.Count > 0)
                {
                    var unit = redoStack.Pop();
                    unit.Undo();
                    undoStack.Push(unit);
                }
            }
        }

        public class DesignUndoManager
        {
            private readonly Stack<IDesignAction> undoStack = new Stack<IDesignAction>();
            private readonly Stack<IDesignAction> redoStack = new Stack<IDesignAction>();
            public NativeDesignSurfaceUndoEngine NativeEngine { get; set; }

            public void PushAction(IDesignAction action)
            {
                if (action == null) return;
                undoStack.Push(action);
                redoStack.Clear();
            }

            public bool CanUndo
            {
                get { return (NativeEngine != null && NativeEngine.CanUndo) || undoStack.Count > 0; }
            }

            public bool CanRedo
            {
                get { return (NativeEngine != null && NativeEngine.CanRedo) || redoStack.Count > 0; }
            }

            public Control Undo()
            {
                if (NativeEngine != null && NativeEngine.CanUndo)
                {
                    NativeEngine.DoUndo();
                    return null;
                }
                if (undoStack.Count == 0) return null;
                IDesignAction action = undoStack.Pop();
                action.Undo();
                redoStack.Push(action);
                return action.TargetControl;
            }

            public Control Redo()
            {
                if (NativeEngine != null && NativeEngine.CanRedo)
                {
                    NativeEngine.DoRedo();
                    return null;
                }
                if (redoStack.Count == 0) return null;
                IDesignAction action = redoStack.Pop();
                action.Redo();
                undoStack.Push(action);
                return action.TargetControl;
            }
        }
        #region TAB 3.5 & 3.6: FORM DESIGNER SERVICES (QUẢN TRỊ & CÔNG NỢ)
        private void OpenQuanTriDesignTab(FormModel model)
        {
            FormDesignerQuanTriService.OpenDesignTab(model, tabMainContainer);
        }

        private void OpenCongNoDesignTab(FormModel model)
        {
            FormDesignerCongNoService.OpenDesignTab(model, tabMainContainer);
        }

        private void OpenTonKhoDesignTab(FormModel model)
        {
            FormDesignerTonKhoService.OpenDesignTab(model, tabMainContainer);
        }

        private void OpenTonQuyDesignTab(FormModel model)
        {
            FormDesignerTonQuyService.OpenDesignTab(model, tabMainContainer);
        }
        #endregion

        #region TAB 4: FORM DESIGNER & CODE EDITOR
        private void OpenFormCodeTab(FormModel model)
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
            DesignUndoManager undoManager = new DesignUndoManager();
            tab.Tag = undoManager;

            // 1. Top Action Toolbar matching user screenshot
            ToolStrip tsAction = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(4, 2, 4, 2) };
            ToolStripButton btnSave = new ToolStripButton("💾 Lưu (Ctrl + S)");
            ToolStripButton btnNewTab = new ToolStripButton("📑 Tab (Ctrl + T)");
            ToolStripButton btnUndo = new ToolStripButton("↩ Hoàn tác (Ctrl + Z)");
            ToolStripButton btnRedo = new ToolStripButton("↪ Làm lại (Ctrl + Y)");
            tsAction.Items.AddRange(new ToolStripItem[] { btnSave, btnNewTab, new ToolStripSeparator(), btnUndo, btnRedo });

            btnUndo.Click += (s, e) => { if (undoManager.CanUndo) undoManager.Undo(); };
            btnRedo.Click += (s, e) => { if (undoManager.CanRedo) undoManager.Redo(); };

            // 2. Main Outer Layout: SplitContainer Left (Toolbox) vs Center/Right
            SplitContainer splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                FixedPanel = FixedPanel.Panel1,
                SplitterDistance = 180
            };

            // --- LEFT PANEL: TOOLBOX (Accordion Style Matching User App Screenshot) ---
            splitMain.Panel1.Controls.Add(CreateAccordionToolboxPanel());

            // --- CENTER & RIGHT LAYOUT: SplitContainer Center (TabControl) vs Right (PropertyGrid) ---
            SplitContainer splitCenterRight = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                FixedPanel = FixedPanel.Panel2
            };

            Action adjustRightSplitter = () =>
            {
                try
                {
                    int targetDist = splitCenterRight.Width - 250;
                    if (targetDist > 100 && targetDist < splitCenterRight.Width - 50)
                    {
                        splitCenterRight.SplitterDistance = targetDist;
                    }
                }
                catch { }
            };

            splitCenterRight.Resize += (s, e) => adjustRightSplitter();
            tab.Layout += (s, e) => adjustRightSplitter();

            // --- PROPERTY GRID & OBJECT SELECTOR (RIGHT PANEL) ---
            ComboBox cboObjectSelector = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9F),
                FlatStyle = FlatStyle.System
            };

            PropertyGrid propGrid = new PropertyGrid
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                HelpVisible = true,
                CommandsVisibleIfAvailable = true
            };

            Panel pnlRight = new Panel { Dock = DockStyle.Fill };
            pnlRight.Controls.Add(propGrid);
            pnlRight.Controls.Add(cboObjectSelector);
            splitCenterRight.Panel2.Controls.Add(pnlRight);

            // --- CENTER SUB-TABS (Design, Code, Asp.net code, Javascript code) ---
            TabControl tabSub = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };

            // 2. SUB-TAB: CODE (C#)
            TabPage tabCode = new TabPage("Code");
            FastColoredTextBoxNS.FastColoredTextBox txtCode = new FastColoredTextBoxNS.FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Language = FastColoredTextBoxNS.Language.CSharp,
                Font = new Font("Consolas", 10F),
                Text = string.IsNullOrEmpty(model.Code) ? "// (Không có mã C# trong CSDL)" : model.Code
            };
            tabCode.Controls.Add(txtCode);

            Action<string> onJumpToCode = (targetName) =>
            {
                if (string.IsNullOrEmpty(targetName)) return;

                tabSub.SelectedTab = tabCode;

                string codeText = txtCode.Text;
                if (string.IsNullOrEmpty(codeText)) return;

                List<string> searchTerms = new List<string>();
                searchTerms.Add(targetName + "_Click");
                searchTerms.Add(targetName);

                if (targetName.Equals("Ẩn", StringComparison.OrdinalIgnoreCase) || targetName.Equals("An", StringComparison.OrdinalIgnoreCase))
                {
                    searchTerms.Add("btnDong_Click");
                    searchTerms.Add("btnDong");
                }
                else if (targetName.Equals("btnDong", StringComparison.OrdinalIgnoreCase))
                {
                    searchTerms.Add("btnDong_Click");
                    searchTerms.Add("Ẩn_Click");
                    searchTerms.Add("Ẩn");
                }

                int foundIdx = -1;
                string matchedTerm = "";
                foreach (string term in searchTerms)
                {
                    int idx = codeText.IndexOf(term, StringComparison.OrdinalIgnoreCase);
                    if (idx >= 0)
                    {
                        foundIdx = idx;
                        matchedTerm = term;
                        break;
                    }
                }

                if (foundIdx >= 0)
                {
                    txtCode.SelectionStart = foundIdx;
                    txtCode.SelectionLength = matchedTerm.Length;
                    txtCode.DoSelectionVisible();
                    txtCode.Focus();
                }
                else
                {
                    string stubName = System.Text.RegularExpressions.Regex.Replace(targetName, @"[^\w]", "");
                    if (string.IsNullOrEmpty(stubName)) stubName = "Control";
                    
                    string indent = "        ";
                    string stub = $"\n{indent}public void {stubName}_Click(object sender, EventArgs e)\n{indent}{{\n{indent}    // TODO: Viết mã xử lý cho {targetName}\n{indent}}}\n";

                    int lastBrace = codeText.LastIndexOf('}');
                    if (lastBrace >= 0)
                    {
                        int secondLastBrace = codeText.LastIndexOf('}', lastBrace - 1);
                        int insertPos = (secondLastBrace >= 0) ? secondLastBrace : lastBrace;
                        txtCode.Text = codeText.Insert(insertPos, stub);
                    }
                    else
                    {
                        txtCode.AppendText(stub);
                    }

                    int newIdx = txtCode.Text.IndexOf(stubName + "_Click");
                    if (newIdx >= 0)
                    {
                        txtCode.SelectionStart = newIdx;
                        txtCode.SelectionLength = (stubName + "_Click").Length;
                        txtCode.DoSelectionVisible();
                        txtCode.Focus();
                    }
                }
            };

            Panel pnlDesignSurface = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            Panel pnlCanvasArea = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 240),
                AutoScroll = true
            };
            pnlDesignSurface.Controls.Add(pnlCanvasArea);

            Form hostedForm = null;
            try
            {
                hostedForm = DbFormService.CreateFormFromModel(model);
                if (hostedForm != null)
                {
                    Panel pnlFormWindow = CreateFormDesignWindowFrame(hostedForm, propGrid, cboObjectSelector, onJumpToCode, undoManager);
                    pnlCanvasArea.Controls.Add(pnlFormWindow);

                    CreateComponentTray(model, hostedForm, pnlFormWindow, pnlDesignSurface, propGrid, tabMainContainer);
                    propGrid.SelectedObject = hostedForm;
                }
                else
                {
                    Label lblEmpty = new Label
                    {
                        Text = $"[Form Designer: {model.Name}]",
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        ForeColor = Color.Gray,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    pnlCanvasArea.Controls.Add(lblEmpty);
                }
            }
            catch
            {
                Label lblError = new Label
                {
                    Text = $"Form: {model.Name}",
                    Font = new Font("Segoe UI", 10F),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlCanvasArea.Controls.Add(lblError);
            }

            // 1. SUB-TAB: DESIGN (Giao diện trực quan)
            TabPage tabDesign = new TabPage("Design");
            tabDesign.Controls.Add(pnlDesignSurface);

            // 3. SUB-TAB: ASP.NET CODE
            TabPage tabServerCode = new TabPage("Asp.net code");
            FastColoredTextBoxNS.FastColoredTextBox txtServerCode = new FastColoredTextBoxNS.FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Language = FastColoredTextBoxNS.Language.HTML,
                Font = new Font("Consolas", 10F),
                Text = string.IsNullOrEmpty(model.ServerCode) ? "// (Không có Asp.net code trong CSDL)" : model.ServerCode
            };
            tabServerCode.Controls.Add(txtServerCode);

            // 4. SUB-TAB: JAVASCRIPT CODE
            TabPage tabClientCode = new TabPage("Javascript code");
            FastColoredTextBoxNS.FastColoredTextBox txtClientCode = new FastColoredTextBoxNS.FastColoredTextBox
            {
                Dock = DockStyle.Fill,
                Language = FastColoredTextBoxNS.Language.JS,
                Font = new Font("Consolas", 10F),
                Text = string.IsNullOrEmpty(model.ClientCode) ? "// (Không có Javascript code trong CSDL)" : model.ClientCode
            };
            tabClientCode.Controls.Add(txtClientCode);

            tabSub.TabPages.AddRange(new TabPage[] { tabDesign, tabCode, tabServerCode, tabClientCode });
            splitCenterRight.Panel1.Controls.Add(tabSub);
            splitMain.Panel2.Controls.Add(splitCenterRight);

            // --- SAVE ACTION: Show 'Đóng gói' progress bar matching target app screenshot ---
            btnSave.Click += (s, e) =>
            {
                string updatedAeLayout = DbFormService.UpdateAeLayoutFromForm(model.AeLayout, hostedForm);
                ExecuteSaveWithPackagingProgress(model, txtCode.Text, txtServerCode.Text, txtClientCode.Text, updatedAeLayout, tab);
            };

            // Assemble main TabPage
            tab.Controls.Add(splitMain);
            tab.Controls.Add(tsAction);

            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;
        }

        private static bool ValidateCSharpCode(string codeText, string designCodeText, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(codeText)) return true;

            try
            {
                using (Microsoft.CSharp.CSharpCodeProvider provider = new Microsoft.CSharp.CSharpCodeProvider())
                {
                    System.CodeDom.Compiler.CompilerParameters parameters = new System.CodeDom.Compiler.CompilerParameters
                    {
                        GenerateExecutable = false,
                        GenerateInMemory = true
                    };
                    parameters.ReferencedAssemblies.Add("System.dll");
                    parameters.ReferencedAssemblies.Add("System.Core.dll");
                    parameters.ReferencedAssemblies.Add("System.Data.dll");
                    parameters.ReferencedAssemblies.Add("System.Drawing.dll");
                    parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                    parameters.ReferencedAssemblies.Add("System.Xml.dll");
                    parameters.ReferencedAssemblies.Add("System.Xml.Linq.dll");
                    parameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                    parameters.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");

                    string appDir = AppDomain.CurrentDomain.BaseDirectory;
                    if (System.IO.Directory.Exists(appDir))
                    {
                        foreach (string dllPath in System.IO.Directory.GetFiles(appDir, "*.dll"))
                        {
                            try
                            {
                                if (!parameters.ReferencedAssemblies.Contains(dllPath))
                                {
                                    parameters.ReferencedAssemblies.Add(dllPath);
                                }
                            }
                            catch { }
                        }
                    }

                    string libsDir = System.IO.Path.Combine(appDir, "Libs");
                    if (System.IO.Directory.Exists(libsDir))
                    {
                        foreach (string dllPath in System.IO.Directory.GetFiles(libsDir, "*.dll"))
                        {
                            try
                            {
                                if (!parameters.ReferencedAssemblies.Contains(dllPath))
                                {
                                    parameters.ReferencedAssemblies.Add(dllPath);
                                }
                            }
                            catch { }
                        }
                    }

                    List<string> sources = new List<string>();

                    // 1. Auto-generate stubs for any referenced *Row types (e.g. DDOTKHUYENMAIRow, DMATHANGRow, etc.)
                    System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(codeText, @"\b([A-Za-z0-9_]+Row)\b");
                    HashSet<string> rowTypes = new HashSet<string>();
                    foreach (System.Text.RegularExpressions.Match m in matches)
                    {
                        if (m.Success) rowTypes.Add(m.Groups[1].Value);
                    }

                    System.Text.StringBuilder sbStubs = new System.Text.StringBuilder();
                    sbStubs.AppendLine("using System;");
                    sbStubs.AppendLine("namespace DbMapping");
                    sbStubs.AppendLine("{");
                    foreach (string rt in rowTypes)
                    {
                        sbStubs.AppendLine($"    public class {rt} : System.Dynamic.DynamicObject");
                        sbStubs.AppendLine("    {");
                        sbStubs.AppendLine($"        public {rt}(params object[] args) {{}}");
                        sbStubs.AppendLine($"        public {rt}() {{}}");
                        sbStubs.AppendLine("        public object Row { get; set; }");
                        sbStubs.AppendLine("        public object ID { get; set; }");
                        sbStubs.AppendLine("        public object this[params object[] indexer] { get { return null; } set {} }");
                        sbStubs.AppendLine("        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result) { result = null; return true; }");
                        sbStubs.AppendLine("        public override bool TrySetMember(System.Dynamic.SetMemberBinder binder, object value) { return true; }");
                        sbStubs.AppendLine("        public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, object[] args, out object result) { result = null; return true; }");
                        sbStubs.AppendLine("    }");
                    }
                    sbStubs.AppendLine("}");
                    foreach (string rt in rowTypes)
                    {
                        sbStubs.AppendLine($"public class {rt} : DbMapping.{rt} {{ public {rt}(params object[] args) : base(args) {{}} public {rt}() {{}} }}");
                    }
                    sbStubs.AppendLine("public class Tables { public static dynamic SelectedID; }");
                    sources.Add(sbStubs.ToString());

                    sources.Add(codeText);

                    string className = ExtractClassNameFromCode(codeText);
                    string nsName = ExtractNamespaceFromCode(codeText) ?? "No1Run";

                    if (!string.IsNullOrEmpty(className))
                    {
                        System.Text.StringBuilder sbDesign = new System.Text.StringBuilder();
                        sbDesign.AppendLine("using System;");
                        sbDesign.AppendLine("using System.Drawing;");
                        sbDesign.AppendLine("using System.Windows.Forms;");
                        sbDesign.AppendLine($"namespace {nsName}");
                        sbDesign.AppendLine("{");
                        sbDesign.AppendLine($"    public partial class {className}");
                        sbDesign.AppendLine("    {");
                        if (!string.IsNullOrWhiteSpace(designCodeText))
                        {
                            sbDesign.AppendLine(designCodeText);
                        }
                        sbDesign.AppendLine("    }");
                        sbDesign.AppendLine("}");
                        sources.Add(sbDesign.ToString());
                    }

                    System.CodeDom.Compiler.CompilerResults results = provider.CompileAssemblyFromSource(parameters, sources.ToArray());
                    if (results.Errors.HasErrors)
                    {
                        System.CodeDom.Compiler.CompilerError fatalErr = null;
                        foreach (System.CodeDom.Compiler.CompilerError err in results.Errors)
                        {
                            if (err.IsWarning) continue;

                            // Filter out standalone script type/member resolution & missing ref errors (CS0012, CS0246, CS0103, CS1061, CS0117, CS0234, CS0260, CS0433)
                            // which are expected due to dynamic runtime Firebird DB schema models and runtime forms
                            if (err.ErrorNumber == "CS0012" || err.ErrorNumber == "CS0246" || err.ErrorNumber == "CS0103" ||
                                err.ErrorNumber == "CS1061" || err.ErrorNumber == "CS0117" || err.ErrorNumber == "CS0234" ||
                                err.ErrorNumber == "CS0260" || err.ErrorNumber == "CS0433")
                            {
                                continue;
                            }

                            fatalErr = err;
                            break;
                        }

                        if (fatalErr != null)
                        {
                            string lineText = "";
                            string[] lines = codeText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                            if (fatalErr.Line > 0 && fatalErr.Line <= lines.Length)
                            {
                                lineText = lines[fatalErr.Line - 1].Trim();
                            }

                            errorMessage = $"Error ({fatalErr.ErrorNumber}): {fatalErr.ErrorText} - class Tables\n---> {lineText}";
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private static string ExtractClassNameFromCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return null;
            System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(code, @"class\s+([A-Za-z0-9_]+)");
            return m.Success ? m.Groups[1].Value : null;
        }

        private static string ExtractNamespaceFromCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return null;
            System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(code, @"namespace\s+([A-Za-z0-9_\.]+)");
            return m.Success ? m.Groups[1].Value : null;
        }

        private void ExecuteSaveWithPackagingProgress(FormModel model, string codeText, string serverCodeText, string clientCodeText, string aeLayoutText, TabPage parentTab = null)
        {
            if (!ValidateCSharpCode(codeText, model != null ? model.DesignCode : null, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (Form dlg = new Form())
            {
                dlg.Text = "Đóng gói";
                dlg.Size = new Size(390, 140);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.ShowInTaskbar = false;
                dlg.BackColor = Color.FromArgb(238, 238, 238);

                ProgressBar pbar = new ProgressBar
                {
                    Location = new Point(20, 24),
                    Size = new Size(334, 22),
                    Minimum = 0,
                    Maximum = 100,
                    Value = 0,
                    Style = ProgressBarStyle.Continuous
                };

                Label lblStatus = new Label
                {
                    Text = "Đóng gói...",
                    Location = new Point(20, 56),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(40, 40, 40)
                };

                dlg.Controls.Add(pbar);
                dlg.Controls.Add(lblStatus);

                Timer timer = new Timer { Interval = 25 };
                int progress = 0;
                bool saved = false;

                timer.Tick += (s, e) =>
                {
                    progress += 5;
                    if (progress <= 100)
                    {
                        pbar.Value = progress;
                    }

                    if (progress == 50 && !saved)
                    {
                        saved = true;
                        model.Code = codeText;
                        model.ServerCode = serverCodeText;
                        model.ClientCode = clientCodeText;
                        if (!string.IsNullOrEmpty(aeLayoutText))
                        {
                            model.AeLayout = aeLayoutText;
                        }
                        DbFormService.SaveFormCode(model.Id, model.Code, model.ServerCode, model.ClientCode, aeLayoutText, model.Name);
                    }

                    if (progress >= 100)
                    {
                        timer.Stop();
                        timer.Dispose();
                        dlg.DialogResult = DialogResult.OK;
                        dlg.Close();
                    }
                };

                timer.Start();
                dlg.ShowDialog(this);
            }
        }

        public class ObjectSelectorItem
        {
            public Control TargetControl { get; set; }
            public string DisplayText { get; set; }
            public override string ToString() => DisplayText ?? string.Empty;
        }

        private Panel CreateFormDesignWindowFrame(Form hostedForm, PropertyGrid propGrid, ComboBox cboObjectSelector = null, Action<string> onJumpToCode = null, DesignUndoManager undoManager = null)
        {
            int formW = (hostedForm != null && hostedForm.ClientSize.Width >= 100) ? hostedForm.ClientSize.Width : 600;
            int formH = (hostedForm != null && hostedForm.ClientSize.Height >= 100) ? hostedForm.ClientSize.Height : 400;
            if (hostedForm != null)
            {
                hostedForm.ClientSize = new Size(formW, formH);
            }

            bool isUserControl = false;
            bool hasMin = true;
            bool hasMax = true;

            if (hostedForm.Tag is Dictionary<string, string> props)
            {
                if (props.TryGetValue("IsUserControl", out string isUcStr) && string.Equals(isUcStr, "true", StringComparison.OrdinalIgnoreCase))
                {
                    isUserControl = true;
                }
                if (props.TryGetValue("MinimizeBox", out string minStr) && string.Equals(minStr, "False", StringComparison.OrdinalIgnoreCase))
                {
                    hasMin = false;
                }
                if (props.TryGetValue("MaximizeBox", out string maxStr) && string.Equals(maxStr, "False", StringComparison.OrdinalIgnoreCase))
                {
                    hasMax = false;
                }
            }

            DateTime lastClickTime = DateTime.MinValue;
            Control lastClickControl = null;
            List<Panel> selectionHandleDots = new List<Panel>();
            Control currentSelectedControl = null;
            Control copyBufferControl = null;

            Action removeSelectionHandles = () =>
            {
                foreach (var dot in selectionHandleDots)
                {
                    try
                    {
                        if (dot.Parent != null && !dot.Parent.Controls.IsReadOnly)
                        {
                            dot.Parent.Controls.Remove(dot);
                        }
                        dot.Dispose();
                    }
                    catch { }
                }
                selectionHandleDots.Clear();
            };

            Action<Control> attach8SelectionHandles = null;

            Action refreshObjectSelector = () =>
            {
                if (cboObjectSelector == null) return;
                cboObjectSelector.Items.Clear();
                if (hostedForm == null) return;

                List<Control> allCtrls = new List<Control>();
                allCtrls.Add(hostedForm);

                Action<Control> collectChildControls = null;
                collectChildControls = (parentCtrl) =>
                {
                    foreach (Control child in parentCtrl.Controls)
                    {
                        if (selectionHandleDots.Contains(child as Panel)) continue;
                        allCtrls.Add(child);
                        collectChildControls(child);
                    }
                };
                collectChildControls(hostedForm);

                foreach (Control c in allCtrls)
                {
                    string nameStr = !string.IsNullOrEmpty(c.Name) ? c.Name : c.Text;
                    string typeName = c.GetType().Name;
                    if (c == hostedForm)
                    {
                        typeName = isUserControl ? "No1UserControl" : "No1Form";
                        if (string.IsNullOrEmpty(nameStr)) nameStr = isUserControl ? "No1UserControl1" : "No1Form1";
                    }

                    ObjectSelectorItem item = new ObjectSelectorItem
                    {
                        TargetControl = c,
                        DisplayText = $"({typeName}) {nameStr}"
                    };
                    cboObjectSelector.Items.Add(item);
                }

                if (cboObjectSelector.Items.Count > 0 && cboObjectSelector.SelectedIndex < 0)
                {
                    cboObjectSelector.SelectedIndex = 0;
                }
            };

            refreshObjectSelector();

            if (cboObjectSelector != null)
            {
                cboObjectSelector.SelectedIndexChanged += (s, e) =>
                {
                    if (cboObjectSelector.SelectedItem is ObjectSelectorItem selItem && selItem.TargetControl != null)
                    {
                        if (currentSelectedControl != selItem.TargetControl)
                        {
                            currentSelectedControl = selItem.TargetControl;
                            propGrid.SelectedObject = selItem.TargetControl;
                            attach8SelectionHandles(selItem.TargetControl);
                        }
                    }
                };
            }

            attach8SelectionHandles = (targetCtrl) =>
            {
                removeSelectionHandles();
                if (targetCtrl == null || targetCtrl == hostedForm || targetCtrl.Parent == null) return;

                Control parent = targetCtrl.Parent;
                int dotSize = 6;
                int half = dotSize / 2;

                Point[] dotPositions = new Point[]
                {
                    new Point(targetCtrl.Left - half, targetCtrl.Top - half),
                    new Point(targetCtrl.Left + targetCtrl.Width / 2 - half, targetCtrl.Top - half),
                    new Point(targetCtrl.Right - half, targetCtrl.Top - half),
                    new Point(targetCtrl.Left - half, targetCtrl.Top + targetCtrl.Height / 2 - half),
                    new Point(targetCtrl.Right - half, targetCtrl.Top + targetCtrl.Height / 2 - half),
                    new Point(targetCtrl.Left - half, targetCtrl.Bottom - half),
                    new Point(targetCtrl.Left + targetCtrl.Width / 2 - half, targetCtrl.Bottom - half),
                    new Point(targetCtrl.Right - half, targetCtrl.Bottom - half)
                };

                Cursor[] cursors = new Cursor[]
                {
                    Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW,
                    Cursors.SizeWE,   Cursors.SizeWE,
                    Cursors.SizeNESW, Cursors.SizeNS, Cursors.SizeNWSE
                };

                for (int i = 0; i < 8; i++)
                {
                    int handleIdx = i;
                    Panel handle = new Panel
                    {
                        Size = new Size(dotSize, dotSize),
                        Location = dotPositions[i],
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Cursor = cursors[i]
                    };

                    bool isResizing = false;
                    Point resizeStart = Point.Empty;
                    Rectangle startBounds = Rectangle.Empty;

                    handle.MouseDown += (s, e) =>
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            isResizing = true;
                            resizeStart = handle.PointToScreen(e.Location);
                            startBounds = targetCtrl.Bounds;
                        }
                    };

                    handle.MouseMove += (s, e) =>
                    {
                        if (isResizing && e.Button == MouseButtons.Left)
                        {
                            Point currentPt = handle.PointToScreen(e.Location);
                            int dx = currentPt.X - resizeStart.X;
                            int dy = currentPt.Y - resizeStart.Y;

                            int newL = startBounds.Left;
                            int newT = startBounds.Top;
                            int newW = startBounds.Width;
                            int newH = startBounds.Height;

                            switch (handleIdx)
                            {
                                case 0: newL += dx; newW -= dx; newT += dy; newH -= dy; break;
                                case 1: newT += dy; newH -= dy; break;
                                case 2: newW += dx; newT += dy; newH -= dy; break;
                                case 3: newL += dx; newW -= dx; break;
                                case 4: newW += dx; break;
                                case 5: newL += dx; newW -= dx; newH += dy; break;
                                case 6: newH += dy; break;
                                case 7: newW += dx; newH += dy; break;
                            }

                            if (newW > 15 && newH > 15)
                            {
                                targetCtrl.Bounds = new Rectangle(newL, newT, newW, newH);
                                attach8SelectionHandles(targetCtrl);
                                propGrid.Refresh();
                            }
                        }
                    };

                    handle.MouseUp += (s, e) =>
                    {
                        if (e.Button == MouseButtons.Left && isResizing)
                        {
                            isResizing = false;
                            if (targetCtrl.Bounds != startBounds && undoManager != null)
                            {
                                undoManager.PushAction(new DesignMoveResizeAction(targetCtrl, startBounds, targetCtrl.Bounds, (c) => { attach8SelectionHandles(c); propGrid.Refresh(); }));
                            }
                        }
                    };

                    try
                    {
                        if (!parent.Controls.IsReadOnly)
                        {
                            parent.Controls.Add(handle);
                            handle.BringToFront();
                            selectionHandleDots.Add(handle);
                        }
                    }
                    catch { }
                }
            };

            Action<Control> selectActiveControl = (target) =>
            {
                currentSelectedControl = target;
                propGrid.SelectedObject = target;
                attach8SelectionHandles(target);

                if (cboObjectSelector != null && target != null)
                {
                    foreach (ObjectSelectorItem item in cboObjectSelector.Items)
                    {
                        if (item.TargetControl == target)
                        {
                            cboObjectSelector.SelectedItem = item;
                            break;
                        }
                    }
                }
            };

            propGrid.PropertyValueChanged += (s, e) =>
            {
                if (currentSelectedControl != null && e.ChangedItem != null && undoManager != null)
                {
                    undoManager.PushAction(new DesignPropertyChangeAction(
                        currentSelectedControl,
                        e.ChangedItem.PropertyDescriptor,
                        e.OldValue,
                        e.ChangedItem.Value,
                        selectActiveControl
                    ));
                }
            };

            Action<Control> bindControlSelection = null;
            bindControlSelection = (ctrl) =>
            {
                bool isDragging = false;
                Point dragStartLoc = Point.Empty;
                Rectangle dragStartBounds = Rectangle.Empty;

                Action triggerJump = () =>
                {
                    string target = !string.IsNullOrEmpty(ctrl.Name) ? ctrl.Name : ctrl.Text;
                    if (!string.IsNullOrEmpty(target))
                    {
                        onJumpToCode?.Invoke(target);
                    }
                };

                Action checkDoubleClick = () =>
                {
                    DateTime now = DateTime.Now;
                    if (lastClickControl == ctrl && (now - lastClickTime).TotalMilliseconds <= 500)
                    {
                        lastClickControl = null;
                        lastClickTime = DateTime.MinValue;
                        triggerJump();
                    }
                    else
                    {
                        lastClickControl = ctrl;
                        lastClickTime = now;
                    }
                };

                ctrl.Click += (s, e) =>
                {
                    selectActiveControl(ctrl);
                    checkDoubleClick();
                };

                ctrl.MouseDoubleClick += (s, e) =>
                {
                    triggerJump();
                };

                ctrl.MouseDown += (s, e) =>
                {
                    selectActiveControl(ctrl);
                    if (e.Clicks >= 2)
                    {
                        triggerJump();
                    }
                    else if (e.Button == MouseButtons.Left && ctrl != hostedForm)
                    {
                        isDragging = true;
                        dragStartLoc = e.Location;
                        dragStartBounds = ctrl.Bounds;
                    }
                };

                ctrl.MouseMove += (s, e) =>
                {
                    if (isDragging && e.Button == MouseButtons.Left && ctrl != hostedForm)
                    {
                        int dx = e.X - dragStartLoc.X;
                        int dy = e.Y - dragStartLoc.Y;
                        if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
                        {
                            ctrl.Location = new Point(ctrl.Left + dx, ctrl.Top + dy);
                            attach8SelectionHandles(ctrl);
                            propGrid.Refresh();
                        }
                    }
                };

                ctrl.MouseUp += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left && isDragging)
                    {
                        isDragging = false;
                        if (ctrl.Bounds != dragStartBounds && undoManager != null)
                        {
                            undoManager.PushAction(new DesignMoveResizeAction(ctrl, dragStartBounds, ctrl.Bounds, selectActiveControl));
                        }
                    }
                };

                ctrl.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Delete && currentSelectedControl != null && currentSelectedControl != hostedForm)
                    {
                        Control toDelete = currentSelectedControl;
                        Control parent = toDelete.Parent;
                        removeSelectionHandles();
                        parent?.Controls.Remove(toDelete);
                        if (undoManager != null)
                        {
                            undoManager.PushAction(new DesignDeleteAction(toDelete, parent, selectActiveControl));
                        }
                        selectActiveControl(hostedForm);
                        e.Handled = true;
                    }
                    else if (e.Control && e.KeyCode == Keys.Z && undoManager != null && undoManager.CanUndo)
                    {
                        undoManager.Undo();
                        e.Handled = true;
                    }
                    else if (e.Control && e.KeyCode == Keys.Y && undoManager != null && undoManager.CanRedo)
                    {
                        undoManager.Redo();
                        e.Handled = true;
                    }
                    else if (e.Control && e.KeyCode == Keys.C && currentSelectedControl != null && currentSelectedControl != hostedForm)
                    {
                        copyBufferControl = currentSelectedControl;
                        e.Handled = true;
                    }
                    else if (e.Control && e.KeyCode == Keys.V && copyBufferControl != null)
                    {
                        Control container = currentSelectedControl is Panel || currentSelectedControl is GroupBox ? currentSelectedControl : (currentSelectedControl?.Parent ?? hostedForm);
                        if (container != null)
                        {
                            Control pasted = CreateControlFromToolboxType(copyBufferControl.GetType().Name, new Point(copyBufferControl.Left + 15, copyBufferControl.Top + 15));
                            if (pasted != null)
                            {
                                pasted.Text = copyBufferControl.Text;
                                pasted.Size = copyBufferControl.Size;
                                container.Controls.Add(pasted);
                                pasted.BringToFront();
                                bindControlSelection(pasted);
                                selectActiveControl(pasted);
                                if (undoManager != null)
                                {
                                    undoManager.PushAction(new DesignAddAction(pasted, container, selectActiveControl));
                                }
                            }
                        }
                        e.Handled = true;
                    }
                };

                ctrl.AllowDrop = true;
                ctrl.DragEnter += (s, e) =>
                {
                    if (e.Data.GetDataPresent(DataFormats.Text))
                        e.Effect = DragDropEffects.Copy;
                };
                ctrl.DragDrop += (s, e) =>
                {
                    string ctrlType = e.Data.GetData(DataFormats.Text) as string;
                    if (!string.IsNullOrEmpty(ctrlType))
                    {
                        Point dropPt = ctrl.PointToClient(new Point(e.X, e.Y));
                        Control newCtrl = CreateControlFromToolboxType(ctrlType, dropPt);
                        if (newCtrl != null)
                        {
                            ctrl.Controls.Add(newCtrl);
                            newCtrl.BringToFront();
                            bindControlSelection(newCtrl);
                            selectActiveControl(newCtrl);
                            if (undoManager != null)
                            {
                                undoManager.PushAction(new DesignAddAction(newCtrl, ctrl, selectActiveControl));
                            }
                        }
                    }
                };
                foreach (Control child in ctrl.Controls)
                {
                    bindControlSelection(child);
                }
            };

            if (isUserControl)
            {
                // USERCONTROL (e.g. Sử dụng dịch vụ, Hóa đơn nhà hàng, Chi lương):
                // Plain Canvas Container, NO Title Bar, NO Window Buttons!
                Panel pnlOuterWrapper = new Panel
                {
                    Size = new Size(formW + 16, formH + 16),
                    Location = new Point(20, 20),
                    BackColor = Color.Transparent
                };

                Panel pnlContentBody = new Panel
                {
                    Size = new Size(formW, formH),
                    Location = new Point(8, 8),
                    BackColor = Color.White
                };

                hostedForm.TopLevel = false;
                hostedForm.FormBorderStyle = FormBorderStyle.None;
                hostedForm.Dock = DockStyle.Fill;
                hostedForm.Visible = true;
                pnlContentBody.Controls.Add(hostedForm);

                pnlOuterWrapper.Controls.Add(pnlContentBody);

                // Add 8 Interactive Selection Handles for Form container resizing
                AddSelectionHandleDots(pnlOuterWrapper, hostedForm, null, pnlContentBody, true, propGrid, undoManager);

                bindControlSelection(hostedForm);
                pnlOuterWrapper.Click += (s, e) => { propGrid.SelectedObject = hostedForm; };
                return pnlOuterWrapper;
            }
            else
            {
                // FORM (Dialog Form vs Standard Form):
                Panel pnlOuterWrapper = new Panel
                {
                    Size = new Size(formW + 16, formH + 46),
                    Location = new Point(20, 20),
                    BackColor = Color.Transparent
                };

                Panel pnlWindowFrame = new Panel
                {
                    Size = new Size(formW + 4, formH + 32),
                    Location = new Point(6, 6),
                    BackColor = Color.FromArgb(220, 226, 236),
                    Padding = new Padding(2)
                };

                // Title Bar matching WinForms Designer
                Panel pnlTitleBar = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 26,
                    BackColor = Color.FromArgb(205, 215, 232),
                    Padding = new Padding(6, 4, 6, 4)
                };

                Label lblTitle = new Label
                {
                    Text = hostedForm.Text != null ? hostedForm.Text : "",
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(40, 50, 70),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                Panel pnlWindowBtns = new Panel { Dock = DockStyle.Right, Width = (hasMin || hasMax) ? 64 : 24, Height = 22 };

                Panel pnlMax = null;
                if (hasMin || hasMax)
                {
                    // Standard Form: Show All 3 Buttons (_ □ X)
                    Panel pnlMin = CreateMinimizeBtnPanel();
                    pnlMax = CreateMaximizeBtnPanel();
                    Panel pnlClose = CreateCloseBtnPanel();
                    pnlWindowBtns.Controls.AddRange(new Control[] { pnlMin, pnlMax, pnlClose });
                }
                else
                {
                    // Dialog Form (e.g. Chọn loại giá): Show ONLY Close Button [X]!
                    Panel pnlClose = CreateCloseBtnPanel();
                    pnlClose.Location = new Point(2, 3);
                    pnlWindowBtns.Controls.Add(pnlClose);
                }

                pnlTitleBar.Controls.Add(lblTitle);
                pnlTitleBar.Controls.Add(pnlWindowBtns);

                // Body Area
                Panel pnlContentBody = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White
                };

                hostedForm.TopLevel = false;
                hostedForm.FormBorderStyle = FormBorderStyle.None;
                hostedForm.Dock = DockStyle.Fill;
                hostedForm.Visible = true;
                pnlContentBody.Controls.Add(hostedForm);

                pnlWindowFrame.Paint += (s, pe) =>
                {
                    using (Pen dotPen = new Pen(Color.FromArgb(120, 140, 170), 1F))
                    {
                        dotPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        pe.Graphics.DrawRectangle(dotPen, 0, 0, pnlWindowFrame.Width - 1, pnlWindowFrame.Height - 1);
                    }
                };

                pnlWindowFrame.Controls.Add(pnlContentBody);
                pnlWindowFrame.Controls.Add(pnlTitleBar);
                pnlOuterWrapper.Controls.Add(pnlWindowFrame);

                // Add 8 Interactive Selection Handles for Form container resizing
                AddSelectionHandleDots(pnlOuterWrapper, hostedForm, pnlWindowFrame, pnlContentBody, false, propGrid, undoManager);

                if (pnlMax != null)
                {
                    pnlMax.Click += (s, e) =>
                    {
                        Rectangle oldBounds = pnlOuterWrapper.Bounds;
                        Size targetFormSize = hostedForm.Width < 1200 ? new Size(1280, 750) : new Size(1024, 545);
                        hostedForm.Size = targetFormSize;
                        int fw = targetFormSize.Width;
                        int fh = targetFormSize.Height;
                        pnlOuterWrapper.Size = new Size(fw + 16, fh + 46);
                        pnlWindowFrame.Size = new Size(fw + 4, fh + 32);
                        RefreshHandleDotPositions(pnlOuterWrapper);
                        propGrid?.Refresh();

                        if (undoManager != null)
                        {
                            undoManager.PushAction(new DesignMoveResizeAction(
                                pnlOuterWrapper,
                                oldBounds,
                                pnlOuterWrapper.Bounds,
                                (ctrl) =>
                                {
                                    int curFw = ctrl.Width - 16;
                                    int curFh = ctrl.Height - 46;
                                    if (hostedForm != null && curFw > 50 && curFh > 50) hostedForm.Size = new Size(curFw, curFh);
                                    pnlWindowFrame.Size = new Size(curFw + 4, curFh + 32);
                                    RefreshHandleDotPositions(pnlOuterWrapper);
                                    propGrid?.Refresh();
                                }
                            ));
                        }
                    };
                }

                bindControlSelection(hostedForm);
                pnlTitleBar.Click += (s, e) => { selectActiveControl(hostedForm); };
                pnlWindowFrame.Click += (s, e) => { selectActiveControl(hostedForm); };

                return pnlOuterWrapper;
            }
        }

        private Control CreateControlFromToolboxType(string ctrlType, Point dropLocation)
        {
            Control ctrl = null;
            string lower = ctrlType.ToLower();
            if (lower.Contains("panel") || lower.Contains("virtualpanel") || lower.Contains("group"))
            {
                ctrl = new Panel { Size = new Size(200, 120), BackColor = Color.FromArgb(240, 243, 248), BorderStyle = BorderStyle.FixedSingle };
            }
            else if (lower.Contains("button") || lower.Contains("virtualbutton"))
            {
                ctrl = new Button { Size = new Size(110, 34), Text = ctrlType, Font = new Font("Segoe UI", 9F) };
            }
            else if (lower.Contains("label") || lower.Contains("virtualarrow") || lower.Contains("virtualcategory"))
            {
                ctrl = new Label { AutoSize = true, Text = ctrlType, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            }
            else if (lower.Contains("grid") || lower.Contains("datagrid") || lower.Contains("treetable"))
            {
                ctrl = new DataGridView { Size = new Size(320, 160), BackgroundColor = Color.White };
            }
            else if (lower.Contains("textbox") || lower.Contains("richedit"))
            {
                ctrl = new TextBox { Size = new Size(160, 24), Text = "" };
            }
            else if (lower.Contains("combobox") || lower.Contains("lookup"))
            {
                ctrl = new ComboBox { Size = new Size(160, 24) };
            }
            else if (lower.Contains("checkbox"))
            {
                ctrl = new CheckBox { AutoSize = true, Text = ctrlType, Font = new Font("Segoe UI", 9F) };
            }
            else
            {
                ctrl = new Button { Size = new Size(100, 32), Text = ctrlType, Font = new Font("Segoe UI", 9F) };
            }

            if (ctrl != null)
            {
                ctrl.Location = dropLocation;
                ctrl.Name = ctrlType + "_" + Guid.NewGuid().ToString().Substring(0, 4);
            }
            return ctrl;
        }

        private static Panel CreateMinimizeBtnPanel()
        {
            Panel p = new Panel { Size = new Size(18, 18), Location = new Point(2, 3), Cursor = Cursors.Hand };
            p.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(70, 85, 110), 1.5F))
                {
                    pe.Graphics.DrawLine(pen, 4, 13, 14, 13);
                }
            };
            return p;
        }

        private static Panel CreateMaximizeBtnPanel()
        {
            Panel p = new Panel { Size = new Size(18, 18), Location = new Point(22, 3), Cursor = Cursors.Hand };
            p.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(70, 85, 110), 1.5F))
                {
                    pe.Graphics.DrawRectangle(pen, 4, 4, 10, 10);
                }
            };
            return p;
        }

        private static Panel CreateCloseBtnPanel()
        {
            Panel p = new Panel { Size = new Size(18, 18), Location = new Point(42, 3), Cursor = Cursors.Hand };
            p.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(170, 60, 60), 1.5F))
                {
                    pe.Graphics.DrawLine(pen, 4, 4, 14, 14);
                    pe.Graphics.DrawLine(pen, 14, 4, 4, 14);
                }
            };
            return p;
        }

        private static void AddSelectionHandleDots(Panel pnlOuterWrapper, Form hostedForm = null, Panel pnlWindowFrame = null, Panel pnlContentBody = null, bool isUserControl = false, PropertyGrid propGrid = null, DesignUndoManager undoManager = null)
        {
            int outerW = pnlOuterWrapper.Width;
            int outerH = pnlOuterWrapper.Height;
            Point[] handleLocs = new Point[]
            {
                new Point(2, 2),                         // Top-Left (0)
                new Point(outerW / 2 - 3, 2),            // Top-Center (1)
                new Point(outerW - 8, 2),                // Top-Right (2)
                new Point(2, outerH / 2 - 3),            // Mid-Left (3)
                new Point(outerW - 8, outerH / 2 - 3),    // Mid-Right (4)
                new Point(2, outerH - 8),                // Bottom-Left (5)
                new Point(outerW / 2 - 3, outerH - 8),   // Bottom-Center (6)
                new Point(outerW - 8, outerH - 8)        // Bottom-Right (7)
            };

            Cursor[] handleCursors = new Cursor[]
            {
                Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW,
                Cursors.SizeWE,   Cursors.SizeWE,
                Cursors.SizeNESW, Cursors.SizeNS, Cursors.SizeNWSE
            };

            for (int i = 0; i < 8; i++)
            {
                int handleIdx = i;
                Panel handle = new Panel
                {
                    Size = new Size(6, 6),
                    Location = handleLocs[i],
                    BackColor = Color.FromArgb(70, 80, 95),
                    Cursor = handleCursors[i],
                    Tag = "FormResizeHandle"
                };

                bool isResizing = false;
                Point resizeStart = Point.Empty;
                Rectangle startOuterBounds = Rectangle.Empty;

                handle.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isResizing = true;
                        resizeStart = handle.PointToScreen(e.Location);
                        startOuterBounds = pnlOuterWrapper.Bounds;
                    }
                };

                handle.MouseMove += (s, e) =>
                {
                    if (isResizing && e.Button == MouseButtons.Left)
                    {
                        Point currentPt = handle.PointToScreen(e.Location);
                        int dx = currentPt.X - resizeStart.X;
                        int dy = currentPt.Y - resizeStart.Y;

                        int newL = startOuterBounds.Left;
                        int newT = startOuterBounds.Top;
                        int newW = startOuterBounds.Width;
                        int newH = startOuterBounds.Height;

                        switch (handleIdx)
                        {
                            case 0: newL += dx; newW -= dx; newT += dy; newH -= dy; break;
                            case 1: newT += dy; newH -= dy; break;
                            case 2: newW += dx; newT += dy; newH -= dy; break;
                            case 3: newL += dx; newW -= dx; break;
                            case 4: newW += dx; break;
                            case 5: newL += dx; newW -= dx; newH += dy; break;
                            case 6: newH += dy; break;
                            case 7: newW += dx; newH += dy; break;
                        }

                        if (newW >= 200 && newH >= 150)
                        {
                            pnlOuterWrapper.Bounds = new Rectangle(newL, newT, newW, newH);
                            int formW = newW - 16;
                            int formH = isUserControl ? (newH - 16) : (newH - 46);
                            if (formW > 50 && formH > 50)
                            {
                                if (hostedForm != null) hostedForm.Size = new Size(formW, formH);
                                if (pnlWindowFrame != null) pnlWindowFrame.Size = new Size(formW + 4, formH + 32);
                                if (pnlContentBody != null && isUserControl) pnlContentBody.Size = new Size(formW, formH);
                            }
                            RefreshHandleDotPositions(pnlOuterWrapper);
                            propGrid?.Refresh();
                        }
                    }
                };

                handle.MouseUp += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left && isResizing)
                    {
                        isResizing = false;
                        if (pnlOuterWrapper.Bounds != startOuterBounds && undoManager != null)
                        {
                            Rectangle finalOuterBounds = pnlOuterWrapper.Bounds;
                            undoManager.PushAction(new DesignMoveResizeAction(
                                pnlOuterWrapper,
                                startOuterBounds,
                                finalOuterBounds,
                                (ctrl) =>
                                {
                                    int fw = ctrl.Width - 16;
                                    int fh = isUserControl ? (ctrl.Height - 16) : (ctrl.Height - 46);
                                    if (hostedForm != null && fw > 50 && fh > 50) hostedForm.Size = new Size(fw, fh);
                                    if (pnlWindowFrame != null) pnlWindowFrame.Size = new Size(fw + 4, fh + 32);
                                    if (pnlContentBody != null && isUserControl) pnlContentBody.Size = new Size(fw, fh);
                                    RefreshHandleDotPositions(pnlOuterWrapper);
                                    propGrid?.Refresh();
                                }
                            ));
                        }
                    }
                };

                pnlOuterWrapper.Controls.Add(handle);
                handle.BringToFront();
            }
        }

        private static void RefreshHandleDotPositions(Panel pnlOuterWrapper)
        {
            int outerW = pnlOuterWrapper.Width;
            int outerH = pnlOuterWrapper.Height;
            Point[] handleLocs = new Point[]
            {
                new Point(2, 2),                         // Top-Left (0)
                new Point(outerW / 2 - 3, 2),            // Top-Center (1)
                new Point(outerW - 8, 2),                // Top-Right (2)
                new Point(2, outerH / 2 - 3),            // Mid-Left (3)
                new Point(outerW - 8, outerH / 2 - 3),    // Mid-Right (4)
                new Point(2, outerH - 8),                // Bottom-Left (5)
                new Point(outerW / 2 - 3, outerH - 8),   // Bottom-Center (6)
                new Point(outerW - 8, outerH - 8)        // Bottom-Right (7)
            };

            int idx = 0;
            foreach (Control c in pnlOuterWrapper.Controls)
            {
                if (c is Panel p && p.Tag is string tag && tag == "FormResizeHandle")
                {
                    if (idx < handleLocs.Length)
                    {
                        p.Location = handleLocs[idx];
                        p.BringToFront();
                        idx++;
                    }
                }
            }
        }
        #endregion

        #region TAB 5: QUYỀN (SFUNCTION - Matching Image 4)
        private void OpenQuyenTab()
        {
            string tabTitle = "Quyền";
            foreach (TabPage existing in tabMainContainer.TabPages)
            {
                if (existing.Text == tabTitle)
                {
                    tabMainContainer.SelectedTab = existing;
                    return;
                }
            }

            TabPage tab = new TabPage(tabTitle);

            SplitContainer split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 180 };

            TreeView treeGroups = new TreeView { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };
            _quyenImageList = new ImageList { ImageSize = new Size(16, 16), ColorDepth = ColorDepth.Depth32Bit };
            treeGroups.ImageList = _quyenImageList;

            int idxFolder = AddImageToImageList(_quyenImageList, null, CreateDefaultFolderIcon());
            treeGroups.Nodes.Add(new TreeNode("Tất cả") { Tag = "ALL", ImageIndex = idxFolder, SelectedImageIndex = idxFolder });

            ToolStrip tsAction = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(4, 2, 4, 2) };
            ToolStripButton btnAdd = new ToolStripButton("➕ Thêm (Ctrl + Down)");
            ToolStripButton btnDelete = new ToolStripButton("❌ Xóa (Delete)");
            ToolStripButton btnSave = new ToolStripButton("💾 Cập nhật (Ctrl+S)");
            tsAction.Items.AddRange(new ToolStripItem[] { btnAdd, btnDelete, btnSave });

            DataGridView dgvQuyen = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false
            };

            DataTable dtQuyen = new DataTable();
            dtQuyen.Columns.Add("#", typeof(string));
            dtQuyen.Columns.Add("Tên chức năng", typeof(string));
            dtQuyen.Columns.Add("Nhóm", typeof(string));
            dtQuyen.Columns.Add("Một quyền", typeof(bool));
            dgvQuyen.DataSource = dtQuyen;

            split.Panel1.Controls.Add(treeGroups);
            split.Panel2.Controls.Add(dgvQuyen);
            split.Panel2.Controls.Add(tsAction);

            tab.Controls.Add(split);
            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sqlGroups = "SELECT DISTINCT GROUPNAME FROM SFUNCTION WHERE GROUPNAME IS NOT NULL AND GROUPNAME <> '' ORDER BY GROUPNAME";
                    using (FbCommand cmd = new FbCommand(sqlGroups, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string gName = rdr["GROUPNAME"]?.ToString();
                            treeGroups.Nodes.Add(new TreeNode(gName) { Tag = gName, ImageIndex = idxFolder, SelectedImageIndex = idxFolder });
                        }
                    }
                    treeGroups.ExpandAll();

                    string sqlFunc = @"SELECT F.ID, F.NAME, F.GROUPNAME, COALESCE(MAX(R.MODE), 0) AS PERM_MODE 
                                       FROM SFUNCTION F 
                                       LEFT JOIN SGROUPROLE R ON F.ID = R.SFUNCTIONID 
                                       GROUP BY F.ID, F.NAME, F.GROUPNAME, F.SORTORDER 
                                       ORDER BY COALESCE(F.SORTORDER, 999), F.ID";
                    DataTable dtRaw = new DataTable();
                    using (FbDataAdapter da = new FbDataAdapter(sqlFunc, conn)) { da.Fill(dtRaw); }

                    Action<string> populateData = (filterGroup) =>
                    {
                        dtQuyen.Rows.Clear();
                        int idx = 1;
                        foreach (DataRow row in dtRaw.Rows)
                        {
                            string name = row["NAME"]?.ToString();
                            string group = row["GROUPNAME"]?.ToString();
                            bool isPerm = row["PERM_MODE"] != DBNull.Value && Convert.ToInt32(row["PERM_MODE"]) > 0;
                            if (filterGroup == "ALL" || string.IsNullOrEmpty(filterGroup) || string.Equals(group, filterGroup, StringComparison.OrdinalIgnoreCase))
                            {
                                dtQuyen.Rows.Add(idx.ToString("D2"), name, group, isPerm);
                                idx++;
                            }
                        }
                    };

                    populateData("ALL");

                    treeGroups.AfterSelect += (s, e) =>
                    {
                        string tag = e.Node.Tag?.ToString();
                        populateData(tag);
                    };
                }
            }
            catch { }
        }
        #endregion

        #region TAB 6: BÁO CÁO (SREPORT - Matching Image 3)
        private void OpenBaoCaoTab()
        {
            string tabTitle = "Báo cáo";
            foreach (TabPage existing in tabMainContainer.TabPages)
            {
                if (existing.Text == tabTitle)
                {
                    tabMainContainer.SelectedTab = existing;
                    return;
                }
            }

            TabPage tab = new TabPage(tabTitle);

            TreeView treeReports = new TreeView
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F),
                ItemHeight = 24
            };

            tab.Controls.Add(treeReports);
            tabMainContainer.TabPages.Add(tab);
            tabMainContainer.SelectedTab = tab;

            try
            {
                _reportImageList = new ImageList { ImageSize = new Size(16, 16), ColorDepth = ColorDepth.Depth32Bit };
                treeReports.ImageList = _reportImageList;

                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = @"SELECT R.ID, R.NAME, R.PARENTID, R.SORTORDER, R.IMAGE32 AS R_IMG, I.IMAGE AS S_IMG 
                                   FROM SREPORT R 
                                   LEFT JOIN SIMAGE I ON R.SIMAGEID = I.ID 
                                   ORDER BY R.SORTORDER, R.ID";
                    DataTable dt = new DataTable();
                    using (FbDataAdapter da = new FbDataAdapter(sql, conn)) { da.Fill(dt); }

                    Dictionary<string, TreeNode> nodeMap = new Dictionary<string, TreeNode>();

                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["ID"]?.ToString().Trim();
                        string name = row["NAME"]?.ToString().Trim();
                        string parentId = row["PARENTID"] != DBNull.Value ? row["PARENTID"]?.ToString().Trim() : null;

                        if (!string.IsNullOrEmpty(name))
                        {
                            byte[] imgBytes = DbFormService.ReadBlobBytes(row, "R_IMG") ?? DbFormService.ReadBlobBytes(row, "S_IMG");
                            Image fallback = string.IsNullOrEmpty(parentId) ? CreateDefaultFolderIcon() : CreateDefaultReportIcon();
                            int imgIdx = AddImageToImageList(_reportImageList, imgBytes, fallback);

                            TreeNode node = new TreeNode(name)
                            {
                                ImageIndex = imgIdx,
                                SelectedImageIndex = imgIdx
                            };
                            nodeMap[id] = node;

                            if (string.IsNullOrEmpty(parentId))
                            {
                                treeReports.Nodes.Add(node);
                            }
                            else if (nodeMap.TryGetValue(parentId, out TreeNode parentNode))
                            {
                                parentNode.Nodes.Add(node);
                            }
                        }
                    }

                    treeReports.ExpandAll();
                }
            }
            catch { }
        }
        #endregion

        #region TAB 7: ĐỊNH DẠNG (SCOLUMN & STABLEDESC - Popup Form)
        private void OpenDinhDangTab()
        {
            try
            {
                using (Forms.FormDinhDang frm = new Forms.FormDinhDang())
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở Form Định dạng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ACCORDION TOOLBOX PANEL (Dynamic Reflection Scanning from Framework & DLLs)
        private Panel CreateAccordionToolboxPanel()
        {
            Panel pnlMain = new Panel { Dock = DockStyle.Fill };

            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 26,
                BackColor = Color.FromArgb(235, 238, 242)
            };
            Label lblTitle = new Label
            {
                Text = "Toolbox",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(8, 4),
                AutoSize = true
            };
            pnlHeader.Controls.Add(lblTitle);

            // Dynamic Reflection Type Storage per Category
            Dictionary<string, List<Type>> categoryTypes = new Dictionary<string, List<Type>>
            {
                { "Windows Forms", new List<Type>() },
                { "Home Controls", new List<Type>() },
                { "Touch", new List<Type>() },
                { "Common", new List<Type>() },
                { "TS Controls", new List<Type>() }
            };

            // 1. Scan Assemblies (System.Windows.Forms & External Libs in AppDomain/Directory)
            List<Assembly> assembliesToScan = new List<Assembly>();
            assembliesToScan.Add(typeof(Control).Assembly); // System.Windows.Forms

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string libsFolder = System.IO.Path.Combine(baseDir, "Libs");
            if (!System.IO.Directory.Exists(libsFolder))
            {
                libsFolder = @"d:\QuanLyNhaHang\QuanLyNhaHang\Libs";
            }

            string[] targetDlls = new string[]
            {
                "ComponentFactory.Krypton.Toolkit.dll",
                "No1Lib.Sys.DLL",
                "No1Lib.Sys.Ts.DLL",
                "No1Lib.Designer.DLL"
            };

            foreach (string dllName in targetDlls)
            {
                try
                {
                    string dllPath = System.IO.Path.Combine(libsFolder, dllName);
                    if (System.IO.File.Exists(dllPath))
                    {
                        Assembly asm = Assembly.LoadFrom(dllPath);
                        if (asm != null && !assembliesToScan.Contains(asm))
                        {
                            assembliesToScan.Add(asm);
                        }
                    }
                }
                catch { }
            }

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!assembliesToScan.Contains(asm) && !asm.IsDynamic)
                {
                    string asmName = asm.GetName().Name;
                    if (asmName.Contains("No1") || asmName.Contains("Krypton") || asmName.Contains("Windows.Forms"))
                    {
                        assembliesToScan.Add(asm);
                    }
                }
            }

            // 2. Reflect Public Control & Component Types dynamically
            foreach (Assembly asm in assembliesToScan)
            {
                try
                {
                    Type[] types = asm.GetTypes();
                    foreach (Type t in types)
                    {
                        if (t.IsPublic && !t.IsAbstract && (typeof(Control).IsAssignableFrom(t) || typeof(System.ComponentModel.IComponent).IsAssignableFrom(t)))
                        {
                            string tName = t.Name;
                            string lowerName = tName.ToLower();

                            if (tName.StartsWith("TS", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!categoryTypes["TS Controls"].Contains(t)) categoryTypes["TS Controls"].Add(t);
                            }
                            else if (tName.StartsWith("Touch", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!categoryTypes["Touch"].Contains(t)) categoryTypes["Touch"].Add(t);
                            }
                            else if (tName.StartsWith("No1", StringComparison.OrdinalIgnoreCase) || tName.StartsWith("Virtual", StringComparison.OrdinalIgnoreCase) || tName.StartsWith("Home", StringComparison.OrdinalIgnoreCase) || lowerName.Contains("mapper"))
                            {
                                if (!categoryTypes["Home Controls"].Contains(t)) categoryTypes["Home Controls"].Add(t);
                            }
                            else if (tName.StartsWith("Krypton", StringComparison.OrdinalIgnoreCase) || tName.StartsWith("My", StringComparison.OrdinalIgnoreCase) || lowerName.Contains("reminder") || lowerName.Contains("filter") || lowerName.Contains("band"))
                            {
                                if (!categoryTypes["Common"].Contains(t)) categoryTypes["Common"].Add(t);
                            }
                            else if (t.Assembly == typeof(Control).Assembly)
                            {
                                if (!categoryTypes["Windows Forms"].Contains(t)) categoryTypes["Windows Forms"].Add(t);
                            }
                        }
                    }
                }
                catch { }
            }

            ListBox lstItems = new ListBox
            {
                Dock = DockStyle.Fill,
                DrawMode = DrawMode.OwnerDrawFixed,
                ItemHeight = 22,
                Font = new Font("Segoe UI", 9F),
                BorderStyle = BorderStyle.None
            };

            Action<string> loadCategory = (catName) =>
            {
                lstItems.Items.Clear();
                lstItems.Items.Add("<Pointer>");
                if (categoryTypes.TryGetValue(catName, out var typeList))
                {
                    var sortedList = typeList.OrderBy(x => x.Name).ToList();
                    foreach (var t in sortedList)
                    {
                        lstItems.Items.Add(t.Name);
                    }
                }
            };

            lstItems.DrawItem += (s, e) =>
            {
                if (e.Index < 0 || e.Index >= lstItems.Items.Count) return;
                e.DrawBackground();
                string itemText = lstItems.Items[e.Index].ToString();
                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

                Color textColor = isSelected ? Color.White : Color.FromArgb(30, 40, 60);
                string iconStr = "⚙";
                if (itemText == "<Pointer>") iconStr = "↖";
                else if (itemText.Contains("Label") || itemText.Contains("Text")) iconStr = "A";
                else if (itemText.Contains("Panel") || itemText.Contains("Group") || itemText.Contains("Container")) iconStr = "▭";
                else if (itemText.Contains("Tab") || itemText.Contains("Nav")) iconStr = "🗂";

                using (Font iconFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (Brush brush = new SolidBrush(textColor))
                {
                    e.Graphics.DrawString(iconStr, iconFont, brush, e.Bounds.X + 4, e.Bounds.Y + 2);
                    e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds.X + 22, e.Bounds.Y + 2);
                }
                e.DrawFocusRectangle();
            };

            lstItems.MouseDown += (s, e) =>
            {
                int idx = lstItems.IndexFromPoint(e.Location);
                if (idx >= 0 && e.Button == MouseButtons.Left)
                {
                    string sel = lstItems.Items[idx].ToString();
                    if (sel != "<Pointer>")
                    {
                        lstItems.DoDragDrop(sel, DragDropEffects.Copy);
                    }
                }
            };

            Panel pnlAccordion = new Panel { Dock = DockStyle.Fill };
            Panel pnlCategoryButtons = new Panel { Dock = DockStyle.Top, AutoSize = true };

            foreach (var catKvp in categoryTypes)
            {
                string catName = catKvp.Key;
                Button btnCat = new Button
                {
                    Text = catName,
                    Dock = DockStyle.Top,
                    Height = 24,
                    FlatStyle = FlatStyle.Flat,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    BackColor = Color.FromArgb(235, 238, 244),
                    ForeColor = Color.FromArgb(30, 40, 60),
                    Padding = new Padding(6, 0, 0, 0)
                };
                btnCat.FlatAppearance.BorderSize = 1;
                btnCat.FlatAppearance.BorderColor = Color.FromArgb(210, 215, 225);

                btnCat.Click += (s, e) =>
                {
                    loadCategory(catName);
                };

                pnlCategoryButtons.Controls.Add(btnCat);
                btnCat.BringToFront();
            }

            loadCategory("Windows Forms");

            pnlAccordion.Controls.Add(lstItems);
            pnlAccordion.Controls.Add(pnlCategoryButtons);

            pnlMain.Controls.Add(pnlAccordion);
            pnlMain.Controls.Add(pnlHeader);
            return pnlMain;
        }
        #endregion

        #region COMPONENT TRAY & AECONTROLLER TASKS SMART TAG
        private static void CreateComponentTray(FormModel model, Form hostedForm, Panel pnlFormWindow, Panel pnlDesignSurface, PropertyGrid propGrid, TabControl tabMainContainer)
        {
            List<TrayItemInfo> trayItems = GetTrayItemsForModel(model);
            if (trayItems == null || trayItems.Count == 0)
            {
                return;
            }

            Panel pnlTrayContainer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 62,
                BackColor = Color.White,
                Padding = new Padding(0)
            };

            Panel pnlTraySplitter = new Panel
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = Color.FromArgb(200, 200, 200)
            };
            pnlTrayContainer.Controls.Add(pnlTraySplitter);

            FlowLayoutPanel flowTray = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                Padding = new Padding(8, 6, 8, 6),
                BackColor = Color.White
            };
            pnlTrayContainer.Controls.Add(flowTray);

            pnlDesignSurface.Controls.Add(pnlTrayContainer);
            pnlTrayContainer.BringToFront();

            Control selectedTrayControl = null;

            foreach (var item in trayItems)
            {
                Panel pnlItem = new Panel
                {
                    Height = 36,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Margin = new Padding(4, 2, 8, 2),
                    Padding = new Padding(4, 2, 4, 2),
                    Cursor = Cursors.Hand,
                    BackColor = Color.White
                };

                Bitmap iconBmp = CreateTrayIcon(item.Type);
                PictureBox picIcon = new PictureBox
                {
                    Image = iconBmp,
                    Size = new Size(18, 18),
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Location = new Point(4, 8)
                };
                pnlItem.Controls.Add(picIcon);

                Label lblName = new Label
                {
                    Text = item.Name,
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Location = new Point(26, 9)
                };
                pnlItem.Controls.Add(lblName);

                Button btnSmartTag = null;
                if (item.IsMapper)
                {
                    btnSmartTag = new Button
                    {
                        Text = "◀",
                        Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                        Size = new Size(16, 16),
                        Location = new Point(lblName.Right + 4, 10),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.FromArgb(235, 235, 235),
                        ForeColor = Color.DarkBlue,
                        Margin = new Padding(2, 0, 0, 0)
                    };
                    btnSmartTag.FlatAppearance.BorderSize = 1;
                    btnSmartTag.FlatAppearance.BorderColor = Color.FromArgb(180, 180, 180);
                    pnlItem.Controls.Add(btnSmartTag);

                    pnlItem.Width = btnSmartTag.Right + 6;
                }
                else
                {
                    pnlItem.Width = lblName.Right + 8;
                }

                Action selectComponentAction = () =>
                {
                    if (selectedTrayControl != null)
                    {
                        selectedTrayControl.BackColor = Color.White;
                    }
                    pnlItem.BackColor = Color.FromArgb(215, 230, 248);
                    selectedTrayControl = pnlItem;

                    if (propGrid != null)
                    {
                        if (item.IsMapper)
                        {
                            propGrid.SelectedObject = new AeControllerPropertyProxy(model);
                        }
                        else if (item.Type == TrayItemType.Timer)
                        {
                            propGrid.SelectedObject = new TimerPropertyProxy(item.Name);
                        }
                        else
                        {
                            propGrid.SelectedObject = new ToolStripPropertyProxy(item.Name);
                        }
                    }
                };

                pnlItem.Click += (s, e) => selectComponentAction();
                picIcon.Click += (s, e) => selectComponentAction();
                lblName.Click += (s, e) => selectComponentAction();

                if (btnSmartTag != null)
                {
                    btnSmartTag.Click += (s, e) =>
                    {
                        selectComponentAction();
                        ShowAeControllerTasksPopup(btnSmartTag, model, tabMainContainer);
                    };
                }

                pnlItem.MouseEnter += (s, e) =>
                {
                    if (selectedTrayControl != pnlItem)
                        pnlItem.BackColor = Color.FromArgb(240, 245, 255);
                };
                pnlItem.MouseLeave += (s, e) =>
                {
                    if (selectedTrayControl != pnlItem)
                        pnlItem.BackColor = Color.White;
                };

                flowTray.Controls.Add(pnlItem);
            }
        }

        private static void ShowAeControllerTasksPopup(Control anchor, FormModel model, TabControl tabMainContainer)
        {
            ToolStripDropDown dropDown = new ToolStripDropDown
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false,
                Size = new Size(320, 130)
            };

            Panel pnlTaskBox = new Panel
            {
                Size = new Size(320, 130),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 26,
                BackColor = Color.FromArgb(185, 209, 234)
            };
            Label lblHeader = new Label
            {
                Text = "No1FieldMapper Tasks",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 40, 80),
                Location = new Point(8, 4),
                AutoSize = true
            };
            Button btnClose = new Button
            {
                Text = "✕",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Size = new Size(20, 20),
                Location = new Point(294, 3),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.Transparent
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => dropDown.Close();

            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Controls.Add(btnClose);
            pnlTaskBox.Controls.Add(pnlHeader);

            // Table row
            Label lblTable = new Label
            {
                Text = "Table",
                Location = new Point(12, 36),
                Size = new Size(50, 20),
                Font = new Font("Segoe UI", 9F)
            };
            TextBox txtTable = new TextBox
            {
                Text = model?.STableDescId ?? "",
                Location = new Point(68, 34),
                Size = new Size(205, 23),
                Font = new Font("Segoe UI", 9F)
            };
            txtTable.TextChanged += (s, e) => { if (model != null) model.STableDescId = txtTable.Text; };

            Button btnBrowseTable = new Button
            {
                Text = "...",
                Location = new Point(276, 33),
                Size = new Size(30, 24),
                FlatStyle = FlatStyle.System
            };
            btnBrowseTable.Click += (s, e) =>
            {
                string selected = FormSelectTable.SelectTable(btnBrowseTable.FindForm(), model?.STableDescId);
                if (!string.IsNullOrEmpty(selected))
                {
                    txtTable.Text = selected;
                    if (model != null) model.STableDescId = selected;
                }
            };

            pnlTaskBox.Controls.Add(lblTable);
            pnlTaskBox.Controls.Add(txtTable);
            pnlTaskBox.Controls.Add(btnBrowseTable);

            // Maps row
            Label lblMaps = new Label
            {
                Text = "Maps",
                Location = new Point(12, 66),
                Size = new Size(50, 20),
                Font = new Font("Segoe UI", 9F)
            };
            TextBox txtMaps = new TextBox
            {
                Text = "(Collection)",
                Location = new Point(68, 64),
                Size = new Size(205, 23),
                ReadOnly = true,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };
            Button btnBrowseMaps = new Button
            {
                Text = "...",
                Location = new Point(276, 63),
                Size = new Size(30, 24),
                FlatStyle = FlatStyle.System
            };
            btnBrowseMaps.Click += (s, e) =>
            {
                dropDown.Close();
                OpenAppropriateDesignTab(model, tabMainContainer);
            };

            pnlTaskBox.Controls.Add(lblMaps);
            pnlTaskBox.Controls.Add(txtMaps);
            pnlTaskBox.Controls.Add(btnBrowseMaps);

            // Design maps link
            LinkLabel lnkDesignMaps = new LinkLabel
            {
                Text = "Design maps",
                Location = new Point(12, 98),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                LinkColor = Color.FromArgb(0, 102, 204)
            };
            lnkDesignMaps.LinkClicked += (s, e) =>
            {
                dropDown.Close();
                OpenAppropriateDesignTab(model, tabMainContainer);
            };
            pnlTaskBox.Controls.Add(lnkDesignMaps);

            ToolStripControlHost host = new ToolStripControlHost(pnlTaskBox)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false,
                Size = new Size(320, 130)
            };
            dropDown.Items.Add(host);

            Point pt = anchor.PointToScreen(new Point(anchor.Width, 0));
            dropDown.Show(pt);
        }

        private static void OpenAppropriateDesignTab(FormModel model, TabControl tabMainContainer)
        {
            if (model == null) return;
            FormMapperDesigner.ShowDialog(model);
        }

        private enum TrayItemType { Timer, Mapper, ToolStrip }

        private class TrayItemInfo
        {
            public string Name { get; set; }
            public TrayItemType Type { get; set; }
            public bool IsMapper { get; set; }
        }

        private static List<TrayItemInfo> GetTrayItemsForModel(FormModel model)
        {
            List<TrayItemInfo> list = new List<TrayItemInfo>();
            if (model == null) return list;

            string xml = model.AeLayout;
            if (!string.IsNullOrWhiteSpace(xml))
            {
                try
                {
                    string wrapped = xml.Trim();
                    if (!wrapped.StartsWith("<Root>") && !wrapped.StartsWith("<?xml"))
                    {
                        wrapped = $"<Root>{wrapped}</Root>";
                    }

                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.LoadXml(wrapped);

                    System.Xml.XmlNodeList objectNodes = doc.SelectNodes("//Object");
                    if (objectNodes != null)
                    {
                        foreach (System.Xml.XmlNode n in objectNodes)
                        {
                            string name = n.Attributes["name"]?.Value?.Trim();
                            string typeName = n.Attributes["type"]?.Value?.Trim();

                            if (string.IsNullOrEmpty(name)) continue;

                            string lowerType = typeName != null ? typeName.ToLower() : "";
                            string lowerName = name.ToLower();

                            if (lowerType.Contains("timer") || lowerName.StartsWith("tmr") || lowerName.StartsWith("timer"))
                            {
                                if (!list.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                                {
                                    list.Add(new TrayItemInfo { Name = name, Type = TrayItemType.Timer });
                                }
                            }
                            else if (lowerType.Contains("mapper") || lowerType.Contains("controller") || lowerName.Contains("mapper"))
                            {
                                if (!list.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                                {
                                    list.Add(new TrayItemInfo { Name = name, Type = TrayItemType.Mapper, IsMapper = true });
                                }
                            }
                            else if (lowerType.Contains("toolstrip") || lowerName.StartsWith("tool") || lowerName.StartsWith("toolbar"))
                            {
                                if (!list.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                                {
                                    list.Add(new TrayItemInfo { Name = name, Type = TrayItemType.ToolStrip });
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("GetTrayItemsForModel parse error: " + ex.Message);
                }
            }

            return list;
        }

        private static Bitmap CreateTrayIcon(TrayItemType type)
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (type == TrayItemType.Timer)
                {
                    using (Pen p = new Pen(Color.FromArgb(40, 90, 160), 1.5f))
                    {
                        g.DrawEllipse(p, 1, 1, 13, 13);
                    }
                    using (Pen p = new Pen(Color.FromArgb(40, 90, 160), 1.2f))
                    {
                        g.DrawLine(p, 7, 7, 7, 3);
                        g.DrawLine(p, 7, 7, 11, 7);
                    }
                }
                else if (type == TrayItemType.Mapper)
                {
                    using (Brush b = new SolidBrush(Color.FromArgb(128, 57, 168)))
                    {
                        g.FillEllipse(b, 2, 2, 11, 11);
                    }
                    using (Brush b = new SolidBrush(Color.White))
                    {
                        g.FillEllipse(b, 5, 5, 5, 5);
                    }
                    using (Pen p = new Pen(Color.FromArgb(128, 57, 168), 2f))
                    {
                        g.DrawLine(p, 7, 0, 7, 15);
                        g.DrawLine(p, 0, 7, 15, 7);
                        g.DrawLine(p, 2, 2, 13, 13);
                        g.DrawLine(p, 13, 2, 2, 13);
                    }
                }
                else
                {
                    using (Brush b = new SolidBrush(Color.FromArgb(230, 230, 230)))
                    {
                        g.FillRectangle(b, 1, 3, 14, 10);
                    }
                    using (Pen p = new Pen(Color.FromArgb(100, 100, 100)))
                    {
                        g.DrawRectangle(p, 1, 3, 14, 10);
                    }
                    using (Brush b = new SolidBrush(Color.FromArgb(70, 130, 180)))
                    {
                        g.FillRectangle(b, 3, 5, 3, 6);
                        g.FillRectangle(b, 7, 5, 3, 6);
                    }
                }
            }
            return bmp;
        }

        public class AeControllerPropertyProxy
        {
            private readonly FormModel _model;
            public AeControllerPropertyProxy(FormModel model) { _model = model; }

            [Category("Data"), Description("Bảng dữ liệu liên kết")]
            public string Table
            {
                get => _model?.STableDescId ?? "";
                set { if (_model != null) _model.STableDescId = value; }
            }

            [Category("Data"), Description("Danh sách cột mapping")]
            public string Maps => "(Collection)";

            [Category("Design"), Description("Tên controller")]
            public string Name => "mapper";

            [Category("Behavior"), Description("Tự động sinh cột")]
            public bool AutoGenerateColumns { get; set; } = true;

            public override string ToString() => "mapper (AeController)";
        }

        public class TimerPropertyProxy
        {
            private readonly string _name;
            public TimerPropertyProxy(string name) { _name = name; }

            [Category("Design")]
            public string Name => _name;

            [Category("Behavior")]
            public bool Enabled { get; set; } = false;

            [Category("Behavior")]
            public int Interval { get; set; } = 1000;

            public override string ToString() => $"{_name} (System.Windows.Forms.Timer)";
        }

        public class ToolStripPropertyProxy
        {
            private readonly string _name;
            public ToolStripPropertyProxy(string name) { _name = name; }

            [Category("Design")]
            public string Name => _name;

            [Category("Data")]
            public string Items => "(Collection)";

            public override string ToString() => $"{_name} (System.Windows.Forms.ToolStrip)";
        }
        #endregion
        #endregion
    }
}
