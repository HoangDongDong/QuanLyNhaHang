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
    /// Form: Tìm kiếm mặt hàng (ID: c114dd49-02ea-4f7f-8b5a-7f4353eab5dc)
    /// </summary>
    public partial class FormTimkiemmathang : Form
    {
        public string SFormId { get; } = "c114dd49-02ea-4f7f-8b5a-7f4353eab5dc";
        public string SFormTitle { get; } = "Tìm kiếm mặt hàng";

        public FormTimkiemmathang()
        {
            InitializeComponent();
        }

    }
}