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
    /// Form: Tạm ứng đơn hàng (ID: 064236d2-8fcc-415b-80cb-420e69f19c0c)
    /// </summary>
    public partial class FormTamungonhang : Form
    {
        public string SFormId { get; } = "064236d2-8fcc-415b-80cb-420e69f19c0c";
        public string SFormTitle { get; } = "Tạm ứng đơn hàng";

        public FormTamungonhang()
        {
            InitializeComponent();
        }

    }
}