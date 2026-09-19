using ComponentFactory.Krypton.Navigator;
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
    /// Form: Sử dụng dịch vụ (ID: 141ca9a1-6819-49e2-b8a6-c1ac806ef0a9)
    /// </summary>
    public partial class FormSudungdichvu : Form
    {
        public string SFormId { get; } = "141ca9a1-6819-49e2-b8a6-c1ac806ef0a9";
        public string SFormTitle { get; } = "Sử dụng dịch vụ";

        public FormSudungdichvu()
        {
            InitializeComponent();
        }



        		public void No1UserControl1_OnTabClosing(object sender, CancelEventArgs e)
                    donHang.ThucHienInCheBien(true);
                    if (locker != null) locker.UnLockAndStop();
                    donHang.Close();
                    donHang = null;
        #endregion
    }
}