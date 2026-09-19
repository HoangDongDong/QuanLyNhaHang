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
    /// Form: Phân tích kiểm kê (ID: a78b7fda-eadd-4ae9-bbb6-3db794fa4710)
    /// </summary>
    public partial class FormPhantichkiemke : Form
    {
        public string SFormId { get; } = "a78b7fda-eadd-4ae9-bbb6-3db794fa4710";
        public string SFormTitle { get; } = "Phân tích kiểm kê";

        public FormPhantichkiemke()
        {
            InitializeComponent();
        }

    }
}