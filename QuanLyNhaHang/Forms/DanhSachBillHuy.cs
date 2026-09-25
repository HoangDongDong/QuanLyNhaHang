using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using No1Lib.Sys;
using No1Lib.Db;
using No1Lib.Utils;
using FirebirdSql.Data.FirebirdClient;
using System.ComponentModel;
using System.Collections.Generic;

namespace No1Run
{
    public partial class DanhSachBillHuy : No1Lib.Sys.No1UserControl, ITestingSupport, IRefreshable
    {
        public No1Lib.Sys.No1UserControl No1UserControl1 { get { return this; } }

        public DanhSachBillHuy()
        {
            try
            {
                TDONHANG0Ae.EnsureNo1LibInitialized();
            }
            catch { }

            InitializeComponent();
            EnsureViewConfigs();
        }

        private void EnsureViewConfigs()
        {
            try
            {
                if (grDetail != null && (grDetail.ViewConfig == null || grDetail.ViewConfig.Length == 0))
                {
                    ((System.ComponentModel.ISupportInitialize)(grDetail)).BeginInit();
                    grDetail.ViewConfig = Convert.FromBase64String(VIEWCONFIG_DETAIL);
                    ((System.ComponentModel.ISupportInitialize)(grDetail)).EndInit();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureViewConfigs error: " + ex.Message);
            }
        }

        public void LoadData()
        {
            try
            {
                grMain.LoadData("");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DanhSachBillHuy LoadData error: " + ex.Message);
            }
        }

        public void grMain_OnFocusedRowChanged(bool CanRemove, bool canAdd, bool CanEdit)
        {
            grDetail.LoadData();
        }

        public void grDetail_CustomLoadData(object sender, CustomLoadDataArgs e)
        {
            e.Where = "TDONHANGHUYID = '" + grMain.SelectedID + "'";
        }

        public void form_Load(object sender, EventArgs e)
        {
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            grMain.LoadData("");
        }

        public void txtLoc_TextChanged(object sender, EventArgs e)
        {
            if (grDetail != null && grDetail.GridView != null)
            {
                grDetail.GridView.Filter = txtLoc.Text;
            }
        }

        public void FilterManager1_AfterFiltered(object sender, EventArgs e)
        {
        }

        public void No1UserControl1_OnInit(object sender, EventArgs e)
        {
            grMain.LoadData("");

            CalendarColumn col = grMain.GridView.Columns["colGIOHUY"] as CalendarColumn;
            if (col != null) col.Format = "HH:mm";

            col = grMain.GridView.Columns["colGIOTHANHTOAN"] as CalendarColumn;
            if (col != null) col.Format = "dd/MM HH:mm";
        }

        #region ITestingSupport Members

        public new void DoAutoTest()
        {
            LoadData();
            SystemTesting.SetLog("OK", false);
        }

        #endregion

        #region IRefreshable Members

        public new void DoRefresh()
        {
            grMain.LoadData("");
        }

        #endregion
    }
}

namespace QuanLyNhaHang.Forms
{
    public class DanhSachBillHuy : No1Run.DanhSachBillHuy
    {
    }
}
