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
    public partial class GiamGiaTheoNhom : No1Form
    {
        public No1Form No1Form1 => this;

        public GiamGiaTheoNhom()
        {
            InitializeComponent();
        }

        public decimal GiamDoAn
        {
            get { return numDoAn.Value; }
            set { numDoAn.Value = value; }
        }

        public decimal GiamDoUong
        {
            get { return numDoUong.Value; }
            set { numDoUong.Value = value; }
        }

        public decimal GiamDoKhac
        {
            get { return numDoKhac.Value; }
            set { numDoKhac.Value = value; }
        }

        public decimal GiamDichVu
        {
            get { return numDichVu.Value; }
            set { numDichVu.Value = value; }
        }

        public void SetData(decimal doAn, decimal doUong, decimal doKhac, decimal dichVu)
        {
            numDoAn.Value = doAn;
            numDoUong.Value = doUong;
            numDoKhac.Value = doKhac;
            numDichVu.Value = dichVu;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void num_Enter(object sender, EventArgs e)
        {
            if (sender is NumericUpDown num)
            {
                num.Select(0, num.Text.Length);
            }
        }
    }
}
