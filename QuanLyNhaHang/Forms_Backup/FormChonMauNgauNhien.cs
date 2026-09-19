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
    /// Form: Chọn màu ngẫu nhiên (ID: 0e4ad047-da26-47fe-9ae1-406471da1bbe)
    /// </summary>
    public partial class FormChonmaungaunhien : Form
    {
        public string SFormId { get; } = "0e4ad047-da26-47fe-9ae1-406471da1bbe";
        public string SFormTitle { get; } = "Chọn màu ngẫu nhiên";

        public FormChonmaungaunhien()
        {
            InitializeComponent();
        }

    }
}