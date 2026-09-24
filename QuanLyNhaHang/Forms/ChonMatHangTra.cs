using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonMatHangTra : No1Form
    {
        public ChonMatHangTra()
        {
            InitializeComponent();
            
            this.txtSoHoaDon.KeyDown += new KeyEventHandler(txtSoHoaDon_KeyDown);
            this.btnLoc.Click += new EventHandler(btnLoc_Click);
            this.txtTim.TextChanged += new EventHandler(txtTim_TextChanged);
            this.btnOK.Click += new EventHandler(btnOK_Click);
            
            // Xử lý các custom event nếu có trên GridMapper / No1TreeTable
            this.tblNhom.OnFocusedNodeChanged += tblNhom_OnFocusedNodeChanged;
            this.tblNhom.OnCustomNode += tblNhom_OnCustomNode;
            this.grDonHang.CustomLoadData += grDonHang_CustomLoadData;
        }

        private void txtSoHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
        }

        private void tblNhom_OnFocusedNodeChanged(object sender, EventArgs e)
        {
        }

        private void tblNhom_OnCustomNode(object sender, EventArgs e)
        {
        }

        private void grDonHang_CustomLoadData(object sender, No1Lib.Sys.CustomLoadDataArgs e)
        {
        }
    }
}

