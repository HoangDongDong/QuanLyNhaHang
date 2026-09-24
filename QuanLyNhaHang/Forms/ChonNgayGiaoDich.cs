using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonNgayGiaoDich : No1Form
    {
        public ChonNgayGiaoDich()
        {
            InitializeComponent();
            this.Load += new EventHandler(No1Form1_Load);
            this.btnOK.Click += new EventHandler(btnOK_Click);
        }

        private void No1Form1_Load(object sender, EventArgs e)
        {
            // Form load
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Nút OK
        }
    }
}
