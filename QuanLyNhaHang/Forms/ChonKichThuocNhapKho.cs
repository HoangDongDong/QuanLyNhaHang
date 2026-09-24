using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonKichThuocNhapKho : No1Form
    {
        public ChonKichThuocNhapKho()
        {
            InitializeComponent();
            this.grKichThuoc.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(grKichThuoc_CellMouseDoubleClick);
            this.btnOK.Click += new EventHandler(btnOK_Click);
        }

        private void grKichThuoc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Xử lý sự kiện double click
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện OK
        }
    }
}
