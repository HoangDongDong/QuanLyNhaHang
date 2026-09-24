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
    public partial class DatGiamGia : No1Lib.Sys.No1Form
    {
        public DatGiamGia()
        {
            InitializeComponent();
        }

        public No1Lib.Sys.No1Form No1Form1 => this;

        internal void SetData(decimal DonGia)
        {
            numGiaGoc.Value = DonGia;
            numTiLe.Maximum = 100;
            numTiLe.Minimum = 0;
            numTien.Maximum = numGiaGoc.Value;
            numTien.Minimum = 0;
            numGiaSauGiam.Value = DonGia;
        }

        internal void SetData(decimal DonGia, string TenHang)
        {
            SetData(DonGia);
            lblItem.Text = "Mặt hàng: " + TenHang;
        }

        internal decimal TiLeGiam
        {
            get
            {
                return numTiLe.Value;
            }
        }

        internal decimal TienGiam
        {
            get
            {
                return numTien.Value;
            }
        }

        internal decimal GiaSauGiam
        {
            get
            {
                return numGiaSauGiam.Value;
            }
        }

        public void numTiLe_OnEditValueChanged(object sender, object value)
        {
            if (numTiLe.Focused)
            {
                numTien.Value = Math.Round(numGiaGoc.Value * numTiLe.Value / 100, 0);
            }

            numGiaSauGiam.Value = numGiaGoc.Value - numTien.Value;
            btnOK.Enabled = true;
        }

        public void numTien_OnEditValueChanged(object sender, object value)
        {
            if (numTien.Focused)
            {
                numTiLe.Value = (numGiaGoc.Value == 0 ? 0 : Math.Round(numTien.Value * 100 / numGiaGoc.Value, 2));
            }

            numGiaSauGiam.Value = numGiaGoc.Value - numTien.Value;
            btnOK.Enabled = true;
        }
    }
}
