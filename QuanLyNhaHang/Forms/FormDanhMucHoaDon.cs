using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class FormDanhMucHoaDon : No1Form
    {
        public FormDanhMucHoaDon()
        {
            InitializeComponent();
            
            // Wire events
            this.grMain.CustomLoadData += grMain_CustomLoadData;
        }

        private void grMain_CustomLoadData(object sender, No1Lib.Sys.CustomLoadDataArgs e)
        {
            // Implement logic here
        }
    }
}



