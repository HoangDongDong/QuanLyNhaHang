using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonDonViTinh : No1Form
    {
        public ChonDonViTinh()
        {
            InitializeComponent();
            
            // Wire events
            this.lstData.MouseDoubleClick += new MouseEventHandler(lstData_MouseDoubleClick);
            this.lstData.SelectedIndexChanged += new EventHandler(lstData_SelectedIndexChanged);
        }

        private void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Implement logic here
        }

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implement logic here
        }
    }
}
