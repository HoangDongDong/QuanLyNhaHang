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
    /// Form: Sửa dòng hóa đơn (ID: b45cf663-17c2-4b00-ad6d-4c3896d67590)
    /// </summary>
    public partial class FormSuadonghoaon : Form
    {
        public string SFormId { get; } = "b45cf663-17c2-4b00-ad6d-4c3896d67590";
        public string SFormTitle { get; } = "Sửa dòng hóa đơn";

        public FormSuadonghoaon()
        {
            InitializeComponent();
        }

    }
}