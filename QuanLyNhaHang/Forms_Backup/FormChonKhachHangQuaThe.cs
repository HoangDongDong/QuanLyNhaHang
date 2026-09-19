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
    /// Form: Chọn khách hàng qua thẻ (ID: b980430b-54d2-4446-a793-42b3621e2edd)
    /// </summary>
    public partial class FormChonkhachhangquathe : Form
    {
        public string SFormId { get; } = "b980430b-54d2-4446-a793-42b3621e2edd";
        public string SFormTitle { get; } = "Chọn khách hàng qua thẻ";

        public FormChonkhachhangquathe()
        {
            InitializeComponent();
        }

    }
}