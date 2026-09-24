using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonBan : No1Form
    {
        public ChonBan()
        {
            InitializeComponent();
            this.grMain.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(grMain_CellMouseDoubleClick);
            this.grMain.SelectionChanged += new EventHandler(grMain_SelectionChanged);
        }

        private void grMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Xử lý sự kiện click đúp
        }

        private void grMain_SelectionChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện thay đổi dòng
        }
    }
}
