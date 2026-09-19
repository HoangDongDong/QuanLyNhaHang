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
    /// Form: Chọn phòng (ID: f98efabe-ee37-49db-9e9d-c35c4475224d)
    /// </summary>
    public partial class FormChonphong : Form
    {
        public string SFormId { get; } = "f98efabe-ee37-49db-9e9d-c35c4475224d";
        public string SFormTitle { get; } = "Chọn phòng";

        public FormChonphong()
        {
            InitializeComponent();
        }

    }
}