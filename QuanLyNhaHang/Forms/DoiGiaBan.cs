using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using No1Lib.Sys;
using No1Lib.Db;
using No1Lib.Utils;
using FirebirdSql.Data.FirebirdClient;
using System.ComponentModel;
using System.Collections.Generic;

namespace No1Run
{
    public partial class DoiGiaBan : No1Lib.Sys.No1Form
    {
        public DoiGiaBan()
        {
            InitializeComponent();
        }

        public No1Lib.Sys.No1Form No1Form1 => this;
        public decimal DonGia => numDonGia.Value;

        internal void SetData(decimal DonGia, string TenHang)
        {
            numDonGia.Value = DonGia;
            numDonGia.OnEditValueChanged += new No1ControlChangedHandler(numDonGia_OnEditValueChanged);
            lblItem.Text = "Mặt hàng: " + TenHang;
            btnOK.Enabled = numDonGia.Value >= 0;
        }

        void numDonGia_OnEditValueChanged(object sender, object value)
        {
            btnOK.Enabled = numDonGia.Value >= 0;
        }
    }
}
