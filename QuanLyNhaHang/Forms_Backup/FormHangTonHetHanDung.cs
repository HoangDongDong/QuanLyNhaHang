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
    /// Form: Hàng tồn hết hạn dùng (ID: 2e86e78a-519f-4237-9716-a9c112441fb9)
    /// </summary>
    public partial class FormHangtonhethandung : Form
    {
        public string SFormId { get; } = "2e86e78a-519f-4237-9716-a9c112441fb9";
        public string SFormTitle { get; } = "Hàng tồn hết hạn dùng";

        public FormHangtonhethandung()
        {
            InitializeComponent();
        }

    }
}