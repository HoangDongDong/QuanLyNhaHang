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
    /// Form: Chọn máy in (ID: fb0cc7b1-c404-4ad5-811b-a0c3aa4a9f7c)
    /// </summary>
    public partial class FormChonmayin : Form
    {
        public string SFormId { get; } = "fb0cc7b1-c404-4ad5-811b-a0c3aa4a9f7c";
        public string SFormTitle { get; } = "Chọn máy in";

        public FormChonmayin()
        {
            InitializeComponent();
        }

    }
}