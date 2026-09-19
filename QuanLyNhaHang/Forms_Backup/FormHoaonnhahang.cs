using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Hóa đơn nhà hàng (ID: f3f7bb77-f4ba-4111-9066-014f52be79a0)
    /// </summary>
    public partial class FormHoaonnhahang : Form
    {
        public string SFormId { get; } = "f3f7bb77-f4ba-4111-9066-014f52be79a0";
        public string SFormTitle { get; } = "Hóa đơn nhà hàng";

        public FormHoaonnhahang()
        {
            InitializeComponent();
        }

    }
}