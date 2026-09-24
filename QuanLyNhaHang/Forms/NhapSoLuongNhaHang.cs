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

namespace QuanLyNhaHang.Forms
{
    public partial class NhapSoLuongNhaHang : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;

        internal decimal MaxValue = decimal.MaxValue;

        public NhapSoLuongNhaHang()
        {
            InitializeComponent();
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            if (MaxValue != decimal.MaxValue)
            {
                // bat buoc lon hon hoac bang, chi su dung cho chuyen mot phan mat hang
                if (SoLuong >= MaxValue)
                {
                    Msg.ShowWarning("Số lượng không được phép lớn hơn hoặc bằng " + MaxValue.ToString());
                    return;
                }
            }
            if (SoLuong <= 0)
            {
                Msg.ShowWarning("Mời bạn nhập số lượng");
                spSoLuong.Select();
                spSoLuong.Select(0, spSoLuong.Text.Length);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        public decimal SoLuong
        {
            get
            {
                return spSoLuong.Value;
            }
        }
    }
}

namespace No1Run
{
    public class NhapSoLuongNhaHang : QuanLyNhaHang.Forms.NhapSoLuongNhaHang
    {
    }
}
