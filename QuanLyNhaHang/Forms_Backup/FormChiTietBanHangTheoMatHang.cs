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
    /// Form: Chi tiết bán hàng theo mặt hàng (ID: 5645abce-8395-4c94-ac64-f2e0e55007d8)
    /// </summary>
    public partial class FormChitietbanhangtheomathang : Form
    {
        public string SFormId { get; } = "5645abce-8395-4c94-ac64-f2e0e55007d8";
        public string SFormTitle { get; } = "Chi tiết bán hàng theo mặt hàng";

        public FormChitietbanhangtheomathang()
        {
            InitializeComponent();
        }

    }
}