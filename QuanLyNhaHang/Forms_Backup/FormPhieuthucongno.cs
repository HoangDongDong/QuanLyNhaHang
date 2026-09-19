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
    /// Form: Phiếu thu công nợ (ID: f34aa294-898a-4674-8a92-54d07994d159)
    /// </summary>
    public partial class FormPhieuthucongno : Form
    {
        public string SFormId { get; } = "f34aa294-898a-4674-8a92-54d07994d159";
        public string SFormTitle { get; } = "Phiếu thu công nợ";

        public FormPhieuthucongno()
        {
            InitializeComponent();
        }

    }
}