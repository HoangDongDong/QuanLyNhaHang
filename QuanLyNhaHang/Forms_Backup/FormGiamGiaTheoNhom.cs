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
    /// Form: Giảm giá theo nhóm (ID: db13cbad-8ba5-4d23-8f8a-5128a14e5d03)
    /// </summary>
    public partial class FormGiamgiatheonhom : Form
    {
        public string SFormId { get; } = "db13cbad-8ba5-4d23-8f8a-5128a14e5d03";
        public string SFormTitle { get; } = "Giảm giá theo nhóm";

        public FormGiamgiatheonhom()
        {
            InitializeComponent();
        }

    }
}