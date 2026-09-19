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
    /// Form: Chọn bàn (ID: c52e7ec2-2309-45ed-b24b-cb339ffbceb0)
    /// </summary>
    public partial class FormChonban : Form
    {
        public string SFormId { get; } = "c52e7ec2-2309-45ed-b24b-cb339ffbceb0";
        public string SFormTitle { get; } = "Chọn bàn";

        public FormChonban()
        {
            InitializeComponent();
        }

    }
}