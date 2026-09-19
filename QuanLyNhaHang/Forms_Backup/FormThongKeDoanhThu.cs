using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Thống kê doanh thu (ID: d913c8d9-4395-476c-9612-8ca7f35b6268)
    /// </summary>
    public partial class FormThongkedoanhthu : Form
    {
        public string SFormId { get; } = "d913c8d9-4395-476c-9612-8ca7f35b6268";
        public string SFormTitle { get; } = "Thống kê doanh thu";

        public FormThongkedoanhthu()
        {
            InitializeComponent();
        }



        		public void lueCuaHang_OnEditValueChanged(object sender, object value)
                    LoadData();


        		public void lueCuaHang_CustomLoadData(object sender, CustomLoadDataArgs e)
                    if (!DbConfig.IsAdmin)
                        e.Where += " AND ID IN (SELECT DCUAHANGID FROM TNGUOIDUNGTHEOCUAHANG WHERE SUSERID = '" + DbConfig.UserID + "')";
        #endregion
    }
}