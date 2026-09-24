using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class NhapLyDo : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;

        public NhapLyDo()
        {
            InitializeComponent();
        }

        public void txtLyDo_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtLyDo.Text.Trim().Length > 0;
        }
    }
}

namespace No1Run
{
    public class NhapLyDo : QuanLyNhaHang.Forms.NhapLyDo
    {
    }
}
