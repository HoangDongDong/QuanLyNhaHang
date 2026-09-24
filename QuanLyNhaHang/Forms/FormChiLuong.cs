using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChiLuong : No1Form
    {
        public ChiLuong()
        {
            InitializeComponent();
            
            // Wire events
            this.tsbPhieuChi.Click += new EventHandler(tsbPhieuChi_Click);
            this.grChiLuong.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(grChiLuong_CellMouseDoubleClick);
            this.grChiLuong.SelectionChanged += new EventHandler(grChiLuong_SelectionChanged);
        }

        private void tsbPhieuChi_Click(object sender, EventArgs e)
        {
            // Implement logic here
        }

        private void grChiLuong_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Implement logic here
        }

        private void grChiLuong_SelectionChanged(object sender, EventArgs e)
        {
            // Implement logic here
        }
    }
}
