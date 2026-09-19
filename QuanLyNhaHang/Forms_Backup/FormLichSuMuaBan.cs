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
    /// Form: Lịch sử mua bán (ID: 7c40b8f7-7eb8-4e20-bfbc-d87fbb70547d)
    /// </summary>
    public partial class FormLichsumuaban : Form
    {
        public string SFormId { get; } = "7c40b8f7-7eb8-4e20-bfbc-d87fbb70547d";
        public string SFormTitle { get; } = "Lịch sử mua bán";

        public FormLichsumuaban()
        {
            InitializeComponent();
        }

    }
}