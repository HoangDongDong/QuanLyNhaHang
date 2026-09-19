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

namespace QuanLyNhaHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCustomUI();
        }

        public string LoggedInUser { get; private set; } = "admin";

        private void InitializeCustomUI()
        {
            // Hide extra title label because Banner image already contains text
            lblBannerTitle.Visible = false;

            // Load resources
            string bannerPng = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "banner.png");
            string bannerJpg = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "banner.jpg");
            string logo1Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo1.png");
            string logoJpgPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo.jpg");

            if (System.IO.File.Exists(bannerPng))
            {
                picBanner.Image = Image.FromFile(bannerPng);
            }
            else if (System.IO.File.Exists(bannerJpg))
            {
                picBanner.Image = Image.FromFile(bannerJpg);
            }

            if (System.IO.File.Exists(logo1Path))
            {
                picLogo.Image = Image.FromFile(logo1Path);
            }
            else if (System.IO.File.Exists(logoJpgPath))
            {
                picLogo.Image = Image.FromFile(logoJpgPath);
            }

            lblDbValue.Text = Program.CurrentDatabase;

            // Events
            this.Shown += (s, e) =>
            {
                txtUsername.Focus();
                txtUsername.SelectAll();
            };

            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                Application.Exit();
            };

            lblDbTitle.Click += (s, e) => OpenDatabaseForm();
            lblDbValue.Click += (s, e) => OpenDatabaseForm();

            btnLogin.Click += (s, e) => PerformLogin();

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PerformLogin();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    Application.Exit();
                }
            };

            // Custom border rendering for buttons
            btnLogin.Paint += (s, e) => DrawButtonBorder(btnLogin, e.Graphics, Color.FromArgb(0, 120, 215));
            btnCancel.Paint += (s, e) => DrawButtonBorder(btnCancel, e.Graphics, Color.FromArgb(180, 180, 180));
        }

        private void OpenDatabaseForm()
        {
            using (FormDatabase frmDb = new FormDatabase())
            {
                if (frmDb.ShowDialog(this) == DialogResult.OK)
                {
                    lblDbValue.Text = frmDb.SelectedDbName;
                    Program.CurrentDatabase = frmDb.SelectedDbName;
                    Program.CurrentDatabasePath = frmDb.SelectedDbPath;
                }
            }
        }

        private void PerformLogin()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            try
            {
                string connStr = DbFormService.GetConnectionString(Program.CurrentDatabasePath);
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string sql = @"
                        SELECT u.ID, u.USERNAME, u.PASSWORD, u.NAME, u.ISADMIN, g.NAME AS GROUPNAME
                        FROM SUSER u
                        LEFT JOIN SGROUPUSER g ON u.SGROUPUSERID = g.ID
                        WHERE LOWER(u.USERNAME) = LOWER(@username)";

                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Tài khoản không tồn tại trong hệ thống!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtUsername.Focus();
                                return;
                            }

                            string dbPass = reader["PASSWORD"] != DBNull.Value ? reader["PASSWORD"].ToString() : "";
                            if (dbPass != password)
                            {
                                MessageBox.Show("Mật khẩu không chính xác!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.Focus();
                                txtPassword.SelectAll();
                                return;
                            }

                            // Login Success
                            LoggedInUser = reader["USERNAME"].ToString();
                            Program.CurrentUser = LoggedInUser;
                            Program.CurrentUserId = reader["ID"] != DBNull.Value ? reader["ID"].ToString() : "";
                            Program.CurrentUserGroup = reader["GROUPNAME"] != DBNull.Value ? reader["GROUPNAME"].ToString() : "Nhân viên";
                            Program.IsAdmin = (username.ToLower() == "admin") ||
                                              (reader["ISADMIN"] != DBNull.Value && (reader["ISADMIN"].ToString() == "1" || reader["ISADMIN"].ToString() == "30"));
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Fallback for offline / empty DB without SUSER table configured yet
                if (username.ToLower() == "admin")
                {
                    LoggedInUser = username;
                    Program.CurrentUser = username;
                    Program.CurrentUserGroup = "Administrator";
                    Program.IsAdmin = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DrawButtonBorder(Button btn, Graphics g, Color borderColor)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(borderColor, 1.5f))
            {
                Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                g.DrawRectangle(pen, rect);
            }
        }
    }
}
