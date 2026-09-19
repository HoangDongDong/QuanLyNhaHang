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
    /// Form: Trả đồ (ID: 2b21d0a9-d69b-4d0b-a926-2848ef10a3aa)
    /// </summary>
    public partial class FormTrao : Form
    {
        public string SFormId { get; } = "2b21d0a9-d69b-4d0b-a926-2848ef10a3aa";
        public string SFormTitle { get; } = "Trả đồ";

        public FormTrao()
        {
            InitializeComponent();
        }

    }
}