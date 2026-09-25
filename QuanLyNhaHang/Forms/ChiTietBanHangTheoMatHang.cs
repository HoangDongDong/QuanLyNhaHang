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

        public Form form => this;

        public void SetData(DateTime tuNgay, DateTime denNgay, string dMatHangId, decimal donGia, decimal giaVon, decimal tiLeGiamGia)
        {
        }

        private void grMain_CustomLoadData(object sender, No1Lib.Sys.CustomLoadDataArgs e)
        {
        }
    }
}



