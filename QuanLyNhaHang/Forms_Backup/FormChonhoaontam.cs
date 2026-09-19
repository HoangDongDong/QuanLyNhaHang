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
    /// Form: Chọn hóa đơn tạm (ID: 7032b2eb-8397-4a00-8ccb-b73bb1e9542b)
    /// </summary>
    public partial class FormChonhoaontam : Form
    {
        public string SFormId { get; } = "7032b2eb-8397-4a00-8ccb-b73bb1e9542b";
        public string SFormTitle { get; } = "Chọn hóa đơn tạm";

        public FormChonhoaontam()
        {
            InitializeComponent();
        }

    }
}