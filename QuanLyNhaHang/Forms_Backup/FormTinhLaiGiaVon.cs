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
    /// Form: Tính lại giá vốn (ID: 12ab9341-cd0f-4303-b99f-007824433fb5)
    /// </summary>
    public partial class FormTinhlaigiavon : Form
    {
        public string SFormId { get; } = "12ab9341-cd0f-4303-b99f-007824433fb5";
        public string SFormTitle { get; } = "Tính lại giá vốn";

        public FormTinhlaigiavon()
        {
            InitializeComponent();
        }

    }
}