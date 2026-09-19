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
    /// Form: Chọn mặt hàng trả (ID: 5d3ab70f-e533-4142-b6d3-d2b25b0e9487)
    /// </summary>
    public partial class FormChonmathangtra : Form
    {
        public string SFormId { get; } = "5d3ab70f-e533-4142-b6d3-d2b25b0e9487";
        public string SFormTitle { get; } = "Chọn mặt hàng trả";

        public FormChonmathangtra()
        {
            InitializeComponent();
        }

    }
}