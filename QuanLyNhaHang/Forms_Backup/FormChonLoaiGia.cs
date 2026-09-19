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
    /// Form: Chọn loại giá (ID: 550dbae3-a1f9-4b2b-9d59-78c6e56e4f25)
    /// </summary>
    public partial class FormChonloaigia : Form
    {
        public string SFormId { get; } = "550dbae3-a1f9-4b2b-9d59-78c6e56e4f25";
        public string SFormTitle { get; } = "Chọn loại giá";

        public FormChonloaigia()
        {
            InitializeComponent();
        }

    }
}