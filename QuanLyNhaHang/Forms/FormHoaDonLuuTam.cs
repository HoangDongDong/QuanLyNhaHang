using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class FormHoaDonLuuTam : No1Form
    {
        public FormHoaDonLuuTam()
        {
            InitializeComponent();
            
            // Wire events
            this.Load += form_Load;
            this.txtLoc.TextChanged += txtLoc_TextChanged;
            this.grDetail.CustomLoadData += grDetail_CustomLoadData;
        }

        private void form_Load(object sender, EventArgs e)
        {
            // Implement logic here
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            // Implement logic here
        }

        private void grDetail_CustomLoadData(object sender, No1Lib.Sys.CustomLoadDataArgs e)
        {
            // Implement logic here
        }
    }
}



