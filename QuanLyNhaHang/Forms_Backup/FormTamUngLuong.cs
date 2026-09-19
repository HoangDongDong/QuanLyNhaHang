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
    /// Form: Tạm ứng lương (ID: b0e7f8d4-9ff0-4052-92f3-224fdd300683)
    /// </summary>
    public partial class FormTamungluong : Form
    {
        public string SFormId { get; } = "b0e7f8d4-9ff0-4052-92f3-224fdd300683";
        public string SFormTitle { get; } = "Tạm ứng lương";

        public FormTamungluong()
        {
            InitializeComponent();
        }

    }
}