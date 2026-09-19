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
    /// Form: Đặt giờ cho mặt hàng (ID: 38005bd2-327a-401d-88f9-46a1a219c0af)
    /// </summary>
    public partial class Formatgiochomathang : Form
    {
        public string SFormId { get; } = "38005bd2-327a-401d-88f9-46a1a219c0af";
        public string SFormTitle { get; } = "Đặt giờ cho mặt hàng";

        public Formatgiochomathang()
        {
            InitializeComponent();
        }

    }
}