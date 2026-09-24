using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class FormThemTuExcel : No1Form
    {
        public FormThemTuExcel()
        {
            InitializeComponent();
            
            // Wire events
            this.btnTuDongChon.Click += new EventHandler(btnTuDongChon_Click);
            this.btnOK.Click += new EventHandler(btnOK_Click);
        }

        private void btnTuDongChon_Click(object sender, EventArgs e)
        {
            // Implement logic here
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Implement logic here
        }
    }
}
