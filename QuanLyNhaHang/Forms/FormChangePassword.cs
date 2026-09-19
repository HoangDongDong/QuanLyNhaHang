using System;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
            InitializeCustomUI();
        }

        private void InitializeCustomUI()
        {
            lblHeaderTitle.Text = $"Đổi mật khẩu cho tài khoản: {Program.CurrentUser}";

            this.Shown += (s, e) =>
            {
                txtOldPass.Focus();
                txtOldPass.SelectAll();
            };

            btnExit.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            btnSave.Click += (s, e) => PerformSavePassword();

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PerformSavePassword();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            };

            btnSave.Paint += (s, e) => DrawButtonBorder(btnSave, e.Graphics, Color.FromArgb(0, 120, 215));
            btnExit.Paint += (s, e) => DrawButtonBorder(btnExit, e.Graphics, Color.FromArgb(180, 180, 180));
        }

        private void PerformSavePassword()
        {
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            try
            {
                string connStr = DbFormService.GetConnectionString(Program.CurrentDatabasePath);
                string dbPass = "";

                // 1. Verify old password against Firebird SUSER
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT PASSWORD FROM SUSER WHERE LOWER(USERNAME) = LOWER(@username)";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", Program.CurrentUser);
                        object obj = cmd.ExecuteScalar();
                        dbPass = obj != null && obj != DBNull.Value ? obj.ToString() : "";
                    }
                }

                if (oldPass != dbPass)
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOldPass.Focus();
                    txtOldPass.SelectAll();
                    return;
                }

                // 2. Verify new password matches confirmation
                if (newPass != confirmPass)
                {
                    MessageBox.Show("Mật khẩu mới và Nhập lại mật khẩu không khớp nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPass.Focus();
                    txtConfirmPass.SelectAll();
                    return;
                }

                // 3. Check for empty new password (matching user screenshot alert)
                if (string.IsNullOrEmpty(newPass))
                {
                    DialogResult confirm = MessageBox.Show(
                        "Mật khẩu mới của bạn để trống, chúng tôi khuyên bạn không nên dùng mật khẩu này\nBạn có muốn tiếp tục không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirm == DialogResult.No)
                    {
                        txtNewPass.Focus();
                        return;
                    }
                }

                // 4. Update SUSER in Firebird DB
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string sql = "UPDATE SUSER SET PASSWORD = @newPass WHERE LOWER(USERNAME) = LOWER(@username)";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@newPass", newPass);
                        cmd.Parameters.AddWithValue("@username", Program.CurrentUser);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật mật khẩu vào cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
