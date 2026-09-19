using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Lấy dữ liệu từ máy (ID: eb0bcf1f-1120-4312-b5f1-4899ec735f38)
    /// </summary>
    public partial class FormLaydulieutumay : Form
    {
        public string SFormId { get; } = "eb0bcf1f-1120-4312-b5f1-4899ec735f38";
        public string SFormTitle { get; } = "Lấy dữ liệu từ máy";

        public FormLaydulieutumay()
        {
            InitializeComponent();
        }

    }
}