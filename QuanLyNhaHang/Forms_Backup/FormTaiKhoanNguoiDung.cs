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
    /// Form: Tài khoản người dùng (ID: c21d52e6-ef72-472d-a392-c7433272d26d)
    /// </summary>
    public partial class FormTaikhoannguoidung : Form
    {
        public string SFormId { get; } = "c21d52e6-ef72-472d-a392-c7433272d26d";
        public string SFormTitle { get; } = "Tài khoản người dùng";

        public FormTaikhoannguoidung()
        {
            InitializeComponent();
        }

    }
}