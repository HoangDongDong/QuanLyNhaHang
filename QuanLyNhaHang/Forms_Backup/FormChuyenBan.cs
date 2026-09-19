using ComponentFactory.Krypton.Navigator;
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
    /// Form: Chuyển bàn (ID: 0001db41-ae50-40e5-bb70-4ac3233e0d6d)
    /// </summary>
    public partial class FormChuyenban : Form
    {
        public string SFormId { get; } = "0001db41-ae50-40e5-bb70-4ac3233e0d6d";
        public string SFormTitle { get; } = "Chuyển bàn";

        public FormChuyenban()
        {
            InitializeComponent();
        }

    }
}