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
    /// Form: Cảnh báo khuyến mại (ID: 9bd94faa-b0a3-4d6e-b96c-c92186d3ae82)
    /// </summary>
    public partial class FormCanhbaokhuyenmai : Form
    {
        public string SFormId { get; } = "9bd94faa-b0a3-4d6e-b96c-c92186d3ae82";
        public string SFormTitle { get; } = "Cảnh báo khuyến mại";

        public FormCanhbaokhuyenmai()
        {
            InitializeComponent();
        }

    }
}