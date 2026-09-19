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
    /// Form: Xác nhận thanh toán (ID: 96f6da47-1d5f-48b3-bf07-35bfbece457a)
    /// </summary>
    public partial class FormXacnhanthanhtoan : Form
    {
        public string SFormId { get; } = "96f6da47-1d5f-48b3-bf07-35bfbece457a";
        public string SFormTitle { get; } = "Xác nhận thanh toán";

        public FormXacnhanthanhtoan()
        {
            InitializeComponent();
        }

    }
}