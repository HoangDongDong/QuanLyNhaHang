using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonHoaDonTam : No1Form
    {
        public ChonHoaDonTam()
        {
            InitializeComponent();
            this.Load += form_Load;
            this.grDetail.CustomLoadData += grDetail_CustomLoadData;
            this.txtLoc.TextChanged += txtLoc_TextChanged;
        }

        private void form_Load(object sender, EventArgs e)
        {
            // Xử lý khi load form
        }

        private void grDetail_CustomLoadData(object sender, No1Lib.Sys.CustomLoadDataArgs e)
        {
            // Xử lý load data chi tiết
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            // Xử lý lọc dữ liệu
        }
    }
}



