using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonPhong : No1Form
    {
        public ChonPhong()
        {
            InitializeComponent();
            
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.grMain.CellMouseClick += new DataGridViewCellMouseEventHandler(grMain_CellMouseClick);
            this.grMain.CellFormatting += new DataGridViewCellFormattingEventHandler(grMain_CellFormatting);
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Implement logic here
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Implement logic here
        }

        private void grMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Implement logic here
        }
    }
}
