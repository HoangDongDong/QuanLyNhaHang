using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class FormBackup : Form
    {
        public FormBackup()
        {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            btnClose.Click += (s, e) => this.Close();

            btnBrowse.Click += (s, e) => BrowseBackupFile();

            btnExecute.Click += (s, e) => PerformBackup();

            btnBrowse.Paint += (s, e) => DrawFolderIconOnButton(btnBrowse, e.Graphics);
            picIcon.Paint += (s, e) => DrawDbBackupIcon(picIcon, e.Graphics);

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
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save As";
                sfd.Filter = "Database backup file (*.gbk)|*.gbk|Firebird Database (*.fdb)|*.fdb|All Files (*.*)|*.*";
                sfd.InitialDirectory = @"d:\QuanLyNhaHang\Database";
                sfd.FileName = "";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    txtBackupPath.Text = sfd.FileName;
                }
            }
        }

        private void PerformBackup()
        {
            string targetPath = txtBackupPath.Text.Trim();
            if (string.IsNullOrEmpty(targetPath))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn sao lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sourceDbPath = Program.CurrentDatabasePath;
            if (string.IsNullOrEmpty(sourceDbPath) || !File.Exists(sourceDbPath))
            {
                sourceDbPath = @"d:\QuanLyNhaHang\Database\DEMO.FDB";
            }

            if (!File.Exists(sourceDbPath))
            {
                MessageBox.Show($"Không tìm thấy cơ sở dữ liệu hiện tại tại:\n{sourceDbPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string targetDir = Path.GetDirectoryName(targetPath);
                if (!string.IsNullOrEmpty(targetDir) && !Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                File.Copy(sourceDbPath, targetPath, true);
                MessageBox.Show($"Sao lưu cơ sở dữ liệu thành công tại:\n{targetPath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình sao lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DrawDbBackupIcon(PictureBox pic, Graphics g)
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

            // Draw floppy disk overlay icon on bottom right
            using (SolidBrush diskBrush = new SolidBrush(Color.FromArgb(0, 100, 200)))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            using (Pen diskPen = new Pen(Color.FromArgb(0, 70, 150), 1f))
            {
                Rectangle diskRect = new Rectangle(18, 18, 20, 20);
                g.FillRectangle(diskBrush, diskRect);
                g.DrawRectangle(diskPen, diskRect);

                // Metal slider
                g.FillRectangle(whiteBrush, 22, 19, 12, 6);
                // Label
                g.FillRectangle(whiteBrush, 21, 28, 14, 8);
            }
        }
    }
}
