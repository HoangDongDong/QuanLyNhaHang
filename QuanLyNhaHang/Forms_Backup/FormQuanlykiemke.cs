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
    /// Form: Quản lý kiểm kê (ID: 34540d67-d2cf-4765-a0a4-8351c93ca9ef)
    /// </summary>
    public partial class FormQuanlykiemke : Form
    {
        public string SFormId { get; } = "34540d67-d2cf-4765-a0a4-8351c93ca9ef";
        public string SFormTitle { get; } = "Quản lý kiểm kê";

        public FormQuanlykiemke()
        {
            InitializeComponent();
        }

    }
}