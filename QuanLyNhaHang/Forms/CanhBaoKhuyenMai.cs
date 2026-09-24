using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class CanhBaoKhuyenMai : No1Form
    {
        public CanhBaoKhuyenMai()
        {
            InitializeComponent();
            this.Load += new EventHandler(No1Form1_Load);
            this.grMain.SelectionChanged += new EventHandler(grMain_SelectionChanged);
        }

        private void No1Form1_Load(object sender, EventArgs e)
        {
            // Tải danh sách chương trình khuyến mại
        }

        private void grMain_SelectionChanged(object sender, EventArgs e)
        {
            // Tải chi tiết chương trình khi chọn lưới
        }
    }
}


