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
    /// Form: Nhập số lượng nhà hàng (ID: d84739f1-cd1b-4f07-b9a5-03a89876d97e)
    /// </summary>
    public partial class FormNhapsoluongnhahang : Form
    {
        public string SFormId { get; } = "d84739f1-cd1b-4f07-b9a5-03a89876d97e";
        public string SFormTitle { get; } = "Nhập số lượng nhà hàng";

        public FormNhapsoluongnhahang()
        {
            InitializeComponent();
        }

    }
}