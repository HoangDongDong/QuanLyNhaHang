using System;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang
{
    public partial class FormLogin : Form
    {
        public string LoggedInUser { get; private set; } = "admin";
        public string SelectedDatabase { get; private set; } = "DEMO";

        public FormLogin()
        {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            btnLogin.Click += (s, e) => PerformLogin();
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                Application.Exit();
            };

            lblDbTitle.Click += (s, e) => OpenDatabaseForm();
            lblDbName.Click += (s, e) => OpenDatabaseForm();

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
        }

        private void OpenDatabaseForm()
        {
            using (FormDatabase dbForm = new FormDatabase())
            {
                if (dbForm.ShowDialog(this) == DialogResult.OK)
                {
                    SelectedDatabase = dbForm.SelectedDbName;
                    lblDbName.Text = SelectedDatabase;
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
                        SELECT u.ID, u.USERNAME, u.PASSWORD, u.NAME, u.ISADMIN, u.SGROUPUSERID, g.NAME AS GROUPNAME
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
                            Program.CurrentUserGroupId = reader["SGROUPUSERID"] != DBNull.Value ? reader["SGROUPUSERID"].ToString() : "";
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
    }
}
