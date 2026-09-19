using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class FormRestore : Form
    {
        public FormRestore()
        {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            btnClose.Click += (s, e) => this.Close();

            btnBrowseBackup.Click += (s, e) => BrowseBackupFile();
            btnBrowseRestore.Click += (s, e) => BrowseRestoreFile();

            btnExecute.Click += (s, e) => PerformRestore();

            btnBrowseBackup.Paint += (s, e) => DrawFolderIconOnButton(btnBrowseBackup, e.Graphics);
            btnBrowseRestore.Paint += (s, e) => DrawFolderIconOnButton(btnBrowseRestore, e.Graphics);
            picIcon.Paint += (s, e) => DrawDbRestoreIcon(picIcon, e.Graphics);

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            };
        }

        private void BrowseBackupFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file sao lưu";
                ofd.Filter = "Database backup file (*.gbk)|*.gbk|Firebird Database (*.fdb)|*.fdb|All Files (*.*)|*.*";
                ofd.InitialDirectory = @"d:\QuanLyNhaHang\Database";

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    txtBackupFile.Text = ofd.FileName;
                }
            }
        }

        private void BrowseRestoreFile()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save As";
                sfd.Filter = "Firebird Database (*.fdb)|*.fdb|Database backup file (*.gbk)|*.gbk|All Files (*.*)|*.*";
                sfd.InitialDirectory = @"d:\QuanLyNhaHang\Database";
                sfd.FileName = "";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    txtRestoreFile.Text = sfd.FileName;
                }
            }
        }

        private void PerformRestore()
        {
            string backupPath = txtBackupFile.Text.Trim();
            string restorePath = txtRestoreFile.Text.Trim();

            if (string.IsNullOrEmpty(backupPath) || string.IsNullOrEmpty(restorePath))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ File sao lưu và File khôi phục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(backupPath))
            {
                MessageBox.Show($"Không tìm thấy tệp sao lưu tại:\n{backupPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string targetDir = Path.GetDirectoryName(restorePath);
                if (!string.IsNullOrEmpty(targetDir) && !Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                File.Copy(backupPath, restorePath, true);

                string dbName = Path.GetFileNameWithoutExtension(restorePath);
                Program.CurrentDatabase = dbName;
                Program.CurrentDatabasePath = restorePath;
                Services.DbFormService.DefaultDbPath = restorePath;

                SaveDatabaseHistory(dbName, restorePath);

                MessageBox.Show($"Khôi phục cơ sở dữ liệu thành công tại:\n{restorePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình khôi phục cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDatabaseHistory(string dbName, string dbPath)
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "databases.config");
                List<string> lines = new List<string>();
                if (File.Exists(configPath))
                {
                    lines.AddRange(File.ReadAllLines(configPath, Encoding.UTF8));
                }

                string newEntry = $"{dbName}|{dbPath}";
                if (!lines.Contains(newEntry))
                {
                    lines.Add(newEntry);
                    File.WriteAllLines(configPath, lines.ToArray(), Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi lưu lịch sử khôi phục CSDL: " + ex.Message);
            }
        }

        private void DrawFolderIconOnButton(Button btn, Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int x = (btn.Width - 18) / 2;
            int y = (btn.Height - 16) / 2;

            // Draw yellow folder
            using (SolidBrush folderBrush = new SolidBrush(Color.FromArgb(255, 210, 80)))
            using (Pen folderPen = new Pen(Color.FromArgb(200, 150, 20), 1f))
            {
                // Folder tab
                GraphicsPath tabPath = new GraphicsPath();
                tabPath.AddRectangle(new Rectangle(x, y, 7, 4));
                g.FillPath(folderBrush, tabPath);
                g.DrawPath(folderPen, tabPath);

                // Folder body
                Rectangle bodyRect = new Rectangle(x, y + 3, 18, 12);
                g.FillRectangle(folderBrush, bodyRect);
                g.DrawRectangle(folderPen, bodyRect);
            }
        }

        private void DrawDbRestoreIcon(PictureBox pic, Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw database cylinder stack
            using (SolidBrush dbBrush = new SolidBrush(Color.FromArgb(200, 215, 230)))
            using (Pen dbPen = new Pen(Color.FromArgb(100, 130, 160), 1.5f))
            {
                // Top cylinder
                g.FillEllipse(dbBrush, 4, 4, 26, 10);
                g.DrawEllipse(dbPen, 4, 4, 26, 10);

                // Middle cylinder
                g.FillRectangle(dbBrush, 4, 9, 26, 12);
                g.DrawLine(dbPen, 4, 9, 4, 21);
                g.DrawLine(dbPen, 30, 9, 30, 21);
                g.FillEllipse(dbBrush, 4, 16, 26, 10);
                g.DrawArc(dbPen, 4, 16, 26, 10, 0, 180);

                // Bottom cylinder
                g.FillRectangle(dbBrush, 4, 21, 26, 12);
                g.DrawLine(dbPen, 4, 21, 4, 33);
                g.DrawLine(dbPen, 30, 21, 30, 33);
                g.FillEllipse(dbBrush, 4, 28, 26, 10);
                g.DrawArc(dbPen, 4, 28, 26, 10, 0, 180);
            }

            // Draw lightning bolt overlay (gold yellow lightning)
            Point[] lightning = new Point[]
            {
                new Point(24, 14),
                new Point(18, 26),
                new Point(23, 26),
                new Point(20, 36),
                new Point(32, 22),
                new Point(26, 22)
            };

            using (SolidBrush boltBrush = new SolidBrush(Color.FromArgb(255, 200, 40)))
            using (Pen boltPen = new Pen(Color.FromArgb(200, 140, 0), 1f))
            {
                g.FillPolygon(boltBrush, lightning);
                g.DrawPolygon(boltPen, lightning);
            }
        }
    }
}
