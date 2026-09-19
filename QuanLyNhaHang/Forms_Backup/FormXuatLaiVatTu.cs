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
    /// Form: Xuất lại vật tư (ID: fca03f03-2a25-485a-82d3-73e576bf5697)
    /// </summary>
    public partial class FormXuatlaivattu : Form
    {
        public string SFormId { get; } = "fca03f03-2a25-485a-82d3-73e576bf5697";
        public string SFormTitle { get; } = "Xuất lại vật tư";

        public FormXuatlaivattu()
        {
            InitializeComponent();
        }

    }
}