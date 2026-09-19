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
    /// Form: Chọn ảnh (ID: 84d04ccb-eea9-45b1-8213-487be2f4f7a4)
    /// </summary>
    public partial class FormChonanh : Form
    {
        public string SFormId { get; } = "84d04ccb-eea9-45b1-8213-487be2f4f7a4";
        public string SFormTitle { get; } = "Chọn ảnh";

        public FormChonanh()
        {
            InitializeComponent();
        }

    }
}