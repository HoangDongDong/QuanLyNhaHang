using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class CauHinhMayInTheoKhuVuc : No1Form
    {
        public CauHinhMayInTheoKhuVuc()
        {
            InitializeComponent();
            
            // Wire events
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.Load += new EventHandler(No1Form1_OnInit);
        }

        private void No1Form1_OnInit(object sender, EventArgs e)
        {
            // Implement initialization logic here
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Implement logic here
        }
    }
}
