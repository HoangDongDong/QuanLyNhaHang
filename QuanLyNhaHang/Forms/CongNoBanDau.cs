using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class CongNoBanDau : No1Form
    {
        public CongNoBanDau()
        {
            InitializeComponent();
            this.Load += new EventHandler(form_Load);
            this.OnInit += new EventHandler(form_OnInit);
            
            this.dtNgay.OnEditValueChanged += new EventHandler(dtNgay_OnEditValueChanged);
            this.txtLoc.TextChanged += new EventHandler(txtLoc_TextChanged);
            this.tsbImport.Click += new EventHandler(tsbImport_Click);
            this.tsbFileMau.Click += new EventHandler(tsbFileMau_Click);
            this.btnOK.Click += new EventHandler(btnOK_Click);
        }

        private void form_Load(object sender, EventArgs e)
        {
        }

        private void form_OnInit(object sender, EventArgs e)
        {
        }

        private void dtNgay_OnEditValueChanged(object sender, EventArgs e)
        {
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
        }

        private void tsbFileMau_Click(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
        }
    }
}
