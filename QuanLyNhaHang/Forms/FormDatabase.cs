using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class FormDatabase : Form
    {
        public string SelectedDbName { get; private set; } = "DEMO";

        private string selectedDbPath = @"d:\QuanLyNhaHang\Database\DEMO.FDB";
        public string SelectedDbPath => selectedDbPath;

        public FormDatabase()
        {
            InitializeComponent();
            LoadInitialData();
            RegisterEvents();
        }

        private static readonly string ConfigFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "databases.config");

        private bool isInitializing = false;

        private void LoadInitialData()
        {
            isInitializing = true;
            lstDatabases.Items.Clear();

            try
            {
                if (System.IO.File.Exists(ConfigFilePath))
                {
                    string[] lines = System.IO.File.ReadAllLines(ConfigFilePath, Encoding.UTF8);
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split('|');
                        if (parts.Length >= 2)
                        {
                            string name = parts[0].Trim();
                            string fullPath = parts[1].Trim();

                            if (System.IO.Directory.Exists(fullPath) || (!fullPath.EndsWith(".fdb", StringComparison.OrdinalIgnoreCase) && !fullPath.EndsWith(".gdb", StringComparison.OrdinalIgnoreCase)))
                            {
                                fullPath = System.IO.Path.Combine(fullPath, name + ".FDB");
                            }

                            string dir = System.IO.Path.GetDirectoryName(fullPath);

                            ListViewItem lvi = new ListViewItem(name);
                            lvi.SubItems.Add(dir);
                            lvi.Tag = fullPath;
                            lstDatabases.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi đọc lịch sử CSDL: " + ex.Message);
            }

            rdoOpenDb.Checked = true;
            rdoNewDb.Checked = false;
            lstDatabases.Enabled = true;

            if (lstDatabases.Items.Count > 0)
            {
                bool selected = false;
                foreach (ListViewItem item in lstDatabases.Items)
                {
                    string itemPath = item.Tag != null ? item.Tag.ToString() : "";
                    if (itemPath.Equals(Program.CurrentDatabasePath, StringComparison.OrdinalIgnoreCase) ||
                        item.Text.Equals(Program.CurrentDatabase, StringComparison.OrdinalIgnoreCase))
                    {
                        item.Selected = true;
                        selected = true;
                        break;
                    }
                }

                if (!selected)
                {
                    lstDatabases.Items[0].Selected = true;
                }
            }

            isInitializing = false;
        }

        private void SaveDatabaseHistory()
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (ListViewItem item in lstDatabases.Items)
                {
                    string name = item.Text;
                    string fullPath = item.Tag != null ? item.Tag.ToString() : System.IO.Path.Combine(item.SubItems[1].Text, name + ".FDB");
                    lines.Add($"{name}|{fullPath}");
                }
                System.IO.File.WriteAllLines(ConfigFilePath, lines.ToArray(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi lưu lịch sử CSDL: " + ex.Message);
            }
        }

        private void RegisterEvents()
        {
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            btnSelect.Click += (s, e) => SelectCurrentItem();

            lstDatabases.DoubleClick += (s, e) => SelectCurrentItem();

            lblOpenFile.Click += (s, e) => BrowseAndAddDatabaseFile();
            lblEdit.Click += (s, e) => OpenConnectDbForm();
            lblDelete.Click += (s, e) => DeleteSelectedItem();

            rdoNewDb.Click += (s, e) =>
            {
                if (rdoNewDb.Checked)
                {
                    lstDatabases.Enabled = false;
                    CreateBlankDatabaseFromTemplate();
                }
            };

            rdoNewDb.CheckedChanged += (s, e) =>
            {
                if (!isInitializing && rdoNewDb.Checked)
                {
                    lstDatabases.Enabled = false;
                    CreateBlankDatabaseFromTemplate();
                }
            };

            rdoOpenDb.CheckedChanged += (s, e) =>
            {
                if (rdoOpenDb.Checked)
                {
                    lstDatabases.Enabled = true;
                }
            };
        }

        private void BrowseAndAddDatabaseFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file cơ sở dữ liệu Firebird";
                ofd.Filter = "Firebird Database (*.fdb;*.gdb)|*.fdb;*.gdb|All Files (*.*)|*.*";
                ofd.InitialDirectory = @"d:\QuanLyNhaHang\Database";

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    string dbName = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                    string dbDir = System.IO.Path.GetDirectoryName(ofd.FileName);

                    ListViewItem lvi = new ListViewItem(dbName);
                    lvi.SubItems.Add(dbDir);
                    lvi.Tag = ofd.FileName;
                    lstDatabases.Items.Add(lvi);
                    lvi.Selected = true;

                    rdoOpenDb.Checked = true;
                    selectedDbPath = ofd.FileName;
                    SelectedDbName = dbName;

                    SaveDatabaseHistory();
                }
            }
        }

        private void DeleteSelectedItem()
        {
            if (lstDatabases.SelectedItems.Count > 0)
            {
                lstDatabases.Items.Remove(lstDatabases.SelectedItems[0]);
                SaveDatabaseHistory();

                if (lstDatabases.Items.Count == 0)
                {
                    rdoNewDb.Checked = true;
                    rdoOpenDb.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng dữ liệu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OpenConnectDbForm()
        {
            using (FormConnectDb frmConnect = new FormConnectDb())
            {
                if (frmConnect.ShowDialog(this) == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frmConnect.DatabasePath))
                    {
                        SelectedDbName = System.IO.Path.GetFileNameWithoutExtension(frmConnect.DatabasePath);
                        selectedDbPath = frmConnect.DatabasePath;

                        ListViewItem lvi = new ListViewItem(SelectedDbName);
                        lvi.SubItems.Add(System.IO.Path.GetDirectoryName(selectedDbPath));
                        lvi.Tag = selectedDbPath;
                        lstDatabases.Items.Add(lvi);
                        lvi.Selected = true;

                        SaveDatabaseHistory();
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void SelectCurrentItem()
        {
            if (rdoNewDb.Checked)
            {
                // Create blank database by copying TEMPLATE.FDB
                CreateBlankDatabaseFromTemplate();
                return;
            }

            if (lstDatabases.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lstDatabases.SelectedItems[0];
                SelectedDbName = lvi.Text.Trim();
                string path = lvi.Tag != null ? lvi.Tag.ToString() : (lvi.SubItems.Count > 1 ? lvi.SubItems[1].Text : "");

                if (System.IO.Directory.Exists(path) || (!path.EndsWith(".fdb", StringComparison.OrdinalIgnoreCase) && !path.EndsWith(".gdb", StringComparison.OrdinalIgnoreCase)))
                {
                    selectedDbPath = System.IO.Path.Combine(path, SelectedDbName + ".FDB");
                }
                else
                {
                    selectedDbPath = path;
                }

                lvi.Tag = selectedDbPath;

                Program.CurrentDatabase = SelectedDbName;
                Program.CurrentDatabasePath = selectedDbPath;
                Services.DbFormService.DefaultDbPath = selectedDbPath;

                SaveDatabaseHistoryWithSelectedFirst(SelectedDbName, selectedDbPath);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cơ sở dữ liệu hoặc bấm 'Mở file' để chọn dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveDatabaseHistoryWithSelectedFirst(string currentName, string currentPath)
        {
            try
            {
                List<string> lines = new List<string>();
                lines.Add($"{currentName}|{currentPath}");

                foreach (ListViewItem item in lstDatabases.Items)
                {
                    string name = item.Text.Trim();
                    string fullPath = item.Tag != null ? item.Tag.ToString() : System.IO.Path.Combine(item.SubItems[1].Text, name + ".FDB");
                    string entry = $"{name}|{fullPath}";
                    if (!lines.Contains(entry))
                    {
                        lines.Add(entry);
                    }
                }

                System.IO.File.WriteAllLines(ConfigFilePath, lines.ToArray(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi lưu lịch sử CSDL: " + ex.Message);
            }
        }

        private void CreateBlankDatabaseFromTemplate()
        {
            string templatePath = @"d:\QuanLyNhaHang\Database\TEMPLATE.FDB";
            if (!System.IO.File.Exists(templatePath))
            {
                MessageBox.Show($"Không tìm thấy file mẫu template tại: {templatePath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdoOpenDb.Checked = true;
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Tạo dữ liệu trắng mới (Sao chép từ TEMPLATE.FDB)";
                sfd.Filter = "Firebird Database (*.fdb)|*.fdb";
                sfd.InitialDirectory = @"d:\QuanLyNhaHang\Database";
                sfd.FileName = "";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.Copy(templatePath, sfd.FileName, true);

                        string dbName = System.IO.Path.GetFileNameWithoutExtension(sfd.FileName);
                        string dbDir = System.IO.Path.GetDirectoryName(sfd.FileName);
                        selectedDbPath = sfd.FileName;
                        SelectedDbName = dbName;

                        Program.CurrentDatabase = SelectedDbName;
                        Program.CurrentDatabasePath = selectedDbPath;
                        Services.DbFormService.DefaultDbPath = selectedDbPath;

                        // Add new DB entry directly into the list view as requested by user
                        ListViewItem lvi = new ListViewItem(dbName);
                        lvi.SubItems.Add(dbDir);
                        lvi.Tag = sfd.FileName;
                        lstDatabases.Items.Add(lvi);
                        lvi.Selected = true;

                        // Switch radio button back to 'Mở lại dữ liệu'
                        rdoOpenDb.Checked = true;

                        // Save updated database list persistently
                        SaveDatabaseHistory();

                        MessageBox.Show($"Đã tạo cơ sở dữ liệu trắng mới thành công tại:\n{sfd.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tạo cơ sở dữ liệu trắng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rdoOpenDb.Checked = true;
                    }
                }
                else
                {
                    // If user cancels SaveFileDialog, revert to rdoOpenDb
                    rdoOpenDb.Checked = true;
                }
            }
        }
    }
}
