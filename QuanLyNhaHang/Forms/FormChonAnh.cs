using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonAnh : No1Form
    {
        public ChonAnh()
        {
            InitializeComponent();
            
            // Wire events
            this.btnSelect.Click += new EventHandler(btnSelect_Click);
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnRemove.Click += new EventHandler(btnRemove_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Implement logic here
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Implement logic here
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Implement logic here
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Implement logic here
        }
    }
}
