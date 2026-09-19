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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCustomUI();
        }

        private void InitializeCustomUI()
        {
            // Hide extra title label because Banner.png already contains the text "PHẦN MỀM QUẢN LÝ NHÀ HÀNG"
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

            // Events
            this.Shown += (s, e) =>
            {
                txtUsername.Focus();
                txtUsername.SelectAll();
            };

            btnCancel.Click += (s, e) => this.Close();

            lblDbTitle.Click += (s, e) =>
            {
                using (FormDatabase frmDb = new FormDatabase())
                {
                    if (frmDb.ShowDialog(this) == DialogResult.OK)
                    {
                        lblDbValue.Text = frmDb.SelectedDbName;
                    }
                }
            };

            btnLogin.Click += (s, e) =>
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Custom border rendering for buttons to match modern Windows UI rounded buttons
            btnLogin.Paint += (s, e) => DrawButtonBorder(btnLogin, e.Graphics, Color.FromArgb(0, 120, 215));
            btnCancel.Paint += (s, e) => DrawButtonBorder(btnCancel, e.Graphics, Color.FromArgb(180, 180, 180));
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
