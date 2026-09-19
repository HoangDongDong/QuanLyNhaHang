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
    /// Form: Chọn đơn vị tính (ID: 2fadd182-98ae-4935-a814-a88600aaf367)
    /// </summary>
    public partial class FormChononvitinh : Form
    {
        public string SFormId { get; } = "2fadd182-98ae-4935-a814-a88600aaf367";
        public string SFormTitle { get; } = "Chọn đơn vị tính";

        public FormChononvitinh()
        {
            InitializeComponent();
        }

    }
}