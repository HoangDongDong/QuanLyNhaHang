using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Cấu hình máy in theo khu vực (ID: f4386e38-72e2-4b6f-bc0a-a06640cda8c5)
    /// </summary>
    public partial class FormCauhinhmayintheokhuvuc : Form
    {
        public string SFormId { get; } = "f4386e38-72e2-4b6f-bc0a-a06640cda8c5";
        public string SFormTitle { get; } = "Cấu hình máy in theo khu vực";

        public FormCauhinhmayintheokhuvuc()
        {
            InitializeComponent();
        }

    }
}