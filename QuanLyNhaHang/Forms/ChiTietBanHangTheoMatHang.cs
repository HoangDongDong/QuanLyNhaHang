using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChiTietBanHangTheoMatHang : No1Form
    {
        public ChiTietBanHangTheoMatHang()
        {
            InitializeComponent();
            this.grMain.CustomLoadData += grMain_CustomLoadData;
        }

        private void grMain_CustomLoadData(object sender, No1Lib.Sys.CustomLoadDataArgs e)
        {
            // Custom load data cho grMain
        }
    }
}



