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
    /// Form: Theo dõi đặt phòng (ID: 11f4bf28-9dd4-4a22-8c5c-e912a637576a)
    /// </summary>
    public partial class FormTheodoiatphong : Form
    {
        public string SFormId { get; } = "11f4bf28-9dd4-4a22-8c5c-e912a637576a";
        public string SFormTitle { get; } = "Theo dõi đặt phòng";

        public FormTheodoiatphong()
        {
            InitializeComponent();
        }

    }
}