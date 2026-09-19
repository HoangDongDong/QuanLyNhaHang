using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Phiếu kiểm kê (ID: 93d9d7d4-dc0d-4fb4-a3e8-ee5d4f808346)
    /// </summary>
    public partial class FormPhieukiemke : Form
    {
        public string SFormId { get; } = "93d9d7d4-dc0d-4fb4-a3e8-ee5d4f808346";
        public string SFormTitle { get; } = "Phiếu kiểm kê";

        public FormPhieukiemke()
        {
            InitializeComponent();
        }

    }
}