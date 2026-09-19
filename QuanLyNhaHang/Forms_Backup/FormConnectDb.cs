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
    public partial class FormConnectDb : Form
    {
        public string DatabasePath => txtDatabase.Text;

        public FormConnectDb()
        {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            this.Shown += (s, e) =>
            {
                txtAccount.Focus();
                txtAccount.SelectAll();
            };

            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            btnAccept.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            // Custom border rendering for buttons
            btnAccept.Paint += (s, e) => DrawButtonBorder(btnAccept, e.Graphics, Color.FromArgb(0, 120, 215));
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
