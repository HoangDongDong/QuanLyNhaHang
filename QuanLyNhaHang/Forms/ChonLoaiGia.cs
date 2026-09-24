using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonLoaiGia : No1Form
    {
        public ChonLoaiGia()
        {
            InitializeComponent();
            this.Load += new EventHandler(form_Load);
        }

        private void form_Load(object sender, EventArgs e)
        {
            // Xử lý form load
        }

        private void btnDonGia_Click(object sender, EventArgs e)
        {
            // Xử lý khi click vào nút chọn giá
        }

        protected void form_OnAutoTest(object sender, EventArgs e)
        {
            // Hàm test
        }
    }
}
