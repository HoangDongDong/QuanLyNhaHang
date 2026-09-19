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
    /// Form: Chọn ngày giao dịch (ID: 46069963-bc33-477d-b1e4-def17b1858fc)
    /// </summary>
    public partial class FormChonngaygiaodich : Form
    {
        public string SFormId { get; } = "46069963-bc33-477d-b1e4-def17b1858fc";
        public string SFormTitle { get; } = "Chọn ngày giao dịch";

        public FormChonngaygiaodich()
        {
            InitializeComponent();
        }

    }
}