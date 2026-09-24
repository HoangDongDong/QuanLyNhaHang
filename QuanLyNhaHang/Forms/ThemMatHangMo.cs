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
using QuanLyNhaHang.Forms;

namespace No1Run
{
    public partial class ThemMatHangMo : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;

        public ThemMatHangMo()
        {
            InitializeComponent();
        }

        DMATHANGRow row;
        public void SetData(DMATHANGRow row)
        {
            this.row = row;
            txtName.Text = row != null ? row.NAME : "";
            lueDVT.LoadData(Tables.DDONVITINH);
            spPrice.Value = row != null ? row.GIABAN : 0;
            spPrice.DecimalPlaces = 0;
        }
        
        public void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length == 0 || (row != null && txtName.Text == row.NAME))
            {
                Msg.ShowWarning("Mời bạn nhập tên mặt hàng!");
                spPrice.SelectAllEx();
                return;
            }

            if (spPrice.Value < 0)
            {
                Msg.ShowWarning("Mời bạn nhập đơn giá");
                spPrice.SelectAllEx();
                return;
            }

            if (lueDVT.StringValue.Length == 0)
            {
                Msg.ShowWarning("Mời bạn nhập đơn vị tính!");
                lueDVT.Select();
                lueDVT.showDropDown();
                return;
            }

            No1Form1.DialogResult = DialogResult.OK;
        }

        public string DDONVITINHID
        {
            get { return lueDVT.StringValue; }
        }

        public string TenMatHang
        {
            get { return txtName.Text; }
        }

        public decimal DonGia
        {
            get { return spPrice.Value; }
        }
    }
}
