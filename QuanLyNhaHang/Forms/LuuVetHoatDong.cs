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
using QuanLyNhaHang.Forms;
using Forms = QuanLyNhaHang.Forms.Forms;
using Tables = QuanLyNhaHang.Forms.Tables;
using Functions = QuanLyNhaHang.Forms.Functions;
using Menus = QuanLyNhaHang.Forms.Menus;
using Shared = QuanLyNhaHang.Forms.Shared;
using SystemConfig = QuanLyNhaHang.Services.SystemConfig;
using Config = No1Run.Config;

namespace No1Run
{
    public partial class LuuVetHoatDong : No1Lib.Sys.No1UserControl, ITestingSupport, IRefreshable
    {
        public No1Lib.Sys.No1UserControl No1UserControl1 { get { return this; } }
        private bool _isAddedToTab = false;

        public LuuVetHoatDong()
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
                if (grMain != null && (grMain.ViewConfig == null || grMain.ViewConfig.Length == 0))
                {
                    ((System.ComponentModel.ISupportInitialize)(grMain)).BeginInit();
                    grMain.ViewConfig = Convert.FromBase64String(VIEWCONFIG_MAIN);
                    ((System.ComponentModel.ISupportInitialize)(grMain)).EndInit();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureViewConfigs error: " + ex.Message);
            }
        }

        public void btnRefresh_Click(Object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {            
            //lấy ra danh sách các hóa đơn và danh sách hóa đơn hủy
            string sql = @"SELECT * FROM (
SELECT ID, 
CASE WHEN COALESCE(DATHANHTOAN, 0) = 30 THEN 0 ELSE 2 END AS LOAI, 
NAME, 
CASE WHEN DATHANHTOAN = 30 THEN 'Kết thúc' ELSE 'Đang sử dụng' END AS TRANGTHAI,
(SELECT NAME FROM DBAN WHERE ID = DBANID) AS BAN
FROM TDONHANG
WHERE ((NGAY BETWEEN @FromDate AND @ToDate @ORDONHANG) AND LOAI = 0)
UNION ALL
SELECT TDONHANGID, 1 AS LOAI, NAME, LYDOHUY,
BAN
FROM TDONHANGHUY
WHERE (NGAY BETWEEN @FromDate AND @ToDate @ORDONHANG)) A ORDER BY A.NAME";

            if (txtSoHoaDon != null && txtSoHoaDon.Text.Length > 0)
            {
                sql = sql.Replace("@ORDONHANG", "OR NAME = '" + txtSoHoaDon.Text.Replace("'", "''") + "'");
            }
            else
            {
                sql = sql.Replace("@ORDONHANG", "");
            }

            FbCommand cmd = Config.Db.GetCommand(sql);
            cmd.Parameters.Add("@FromDate", FbDbType.TimeStamp).Value = dtNgay.TuNgay;
            cmd.Parameters.Add("@ToDate", FbDbType.TimeStamp).Value = dtNgay.DenNgay;
            DataTable dt = Config.Db.GetTable(cmd);
            grHoaDon.DataSource = dt;
        }

        public void No1UserControl1_Load(Object sender, EventArgs e)
        {
            if (!_isAddedToTab)
            {
                No1UserControl1_OnAddedToTab(sender, e);
            }

            if (SystemConfig.KichHoatLuuVetHoatDong == 0)
            {
                Msg.ShowWarning("Chức năng lưu vết hoạt động hiện không được kích hoạt" + Environment.NewLine +
                    "Bạn có thể kích hoạt trong menu 'Quản trị | Cấu hình toàn hệ thống'");
            }
        }

        void GridView_OnCustomFilter(ref string filter)
        {
            string ID = grHoaDon.SelectedID;
            if (ID != null && ID.Length > 0)
            {
                if (filter.Length > 0) filter += " AND ";
                filter += "TDONHANGID = '" + ID + "'";
            }
        }

        void GridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataRow r = (grMain.GridView.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                LoaiLuuVet loai = (LoaiLuuVet)ConvertTo.Int(r["PHANLOAI"]);
                if (loai == LoaiLuuVet.HuyBill)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(grMain.GridView.Font, FontStyle.Bold);
                }
                else if (loai == LoaiLuuVet.ChuyenBan)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else if (loai == LoaiLuuVet.GopBan)
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(grMain.GridView.Font, FontStyle.Bold);
                }
                else if (loai == LoaiLuuVet.XoaMon || loai == LoaiLuuVet.GiamMon || loai == LoaiLuuVet.DoiGiaBan || loai == LoaiLuuVet.DatGiamGiaMatHang)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            catch
            {
            }
        }

        public void grMain_CustomLoadData(Object sender, CustomLoadDataArgs e)
        {            
            if (lueNhanVien != null && lueNhanVien.StringValue != null && lueNhanVien.StringValue.Length > 0)
            {
                if (e.Where.Length > 0) e.Where += " AND ";
                e.Where += "TAIKHOAN = @TAIKHOAN";
                e.Command.Parameters.Add("@TAIKHOAN", FbDbType.VarChar).Value = lueNhanVien.DisplayText;
            }
            
            e.Select = e.Select.Replace("TLUUVET.SODONHANG", "COALESCE((SELECT NAME FROM TDONHANG WHERE ID = TLUUVET.SODONHANG), (SELECT NAME FROM TDONHANGHUY WHERE TDONHANGID = TLUUVET.SODONHANG))");
            e.Select += ", TLUUVET.SODONHANG AS TDONHANGID";
            if (grHoaDon == null || string.IsNullOrEmpty(grHoaDon.SelectedID))
            {
                e.Where = "0 = 1";
            }
            else
            {
                e.And("TLUUVET.SODONHANG='" + grHoaDon.SelectedID + "'");
            }
            e.OrderBy = "CAST(NGAY AS DATE), GIO";
        }

        public void btnXoaLuuVet_Click(Object sender, EventArgs e)
        {
            ThucHienXoaLuuVet();
        }

        private void ThucHienXoaLuuVet()
        {
            XacNhanXoaLuuVet form = (XacNhanXoaLuuVet)Config.CreateForm(Forms.XacNhanXoaLuuVet);
            if (form != null && form.No1Form1.ShowDialog() == DialogResult.OK)
            {
                Config.Db.ExecSql("DELETE FROM TLUUVET");
                LoadData();
            }
        }

        #region ITestingSupport Members

        public new void DoAutoTest()
        {
            lueNhanVien.InputRandomData();             
            LoadData();
            ThucHienXoaLuuVet();           
            SystemTesting.SetLog("OK", false);
            UiUtils.CloseActiveTab();
        }

        #endregion

        #region IRefreshable Members

        public new void DoRefresh()
        {
            LoadData();
        }

        #endregion

        public void txtLoc_TextChanged(object sender, EventArgs e)
        {
            if (grMain != null && grMain.GridView != null)
                grMain.GridView.Filter = txtLoc.Text;
        }

        public void grHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (grMain != null)
                grMain.LoadData();
        }

        public void grHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataRow r = (grHoaDon.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                int loai = ConvertTo.Int(r["LOAI"]);
                if (loai == 1)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (loai == 2)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
            }
            catch
            {
            }
        }

        public void dtNgay_OnEditValueChanged(object sender, object value)
        {            
            LoadData();
        }

        public void lueNhanVien_OnEditValueChanged(object sender, object value)
        {
            LoadData();
        }

        public void No1UserControl1_OnAddedToTab(object sender, EventArgs e)
        {
            if (_isAddedToTab) return;
            _isAddedToTab = true;

            DateTime today = Config.Db.DbDate;           
            dtNgay.FromDate = today;
            dtNgay.ToDate = today;
            lueNhanVien.LoadData(Tables.SUSER);
            btnXoaLuuVet.Visible = DbConfig.IsAdmin && (Control.ModifierKeys == (Keys.Shift | Keys.Control));
            grMain.GridView.CellFormatting += new DataGridViewCellFormattingEventHandler(GridView_CellFormatting);
            grMain.GridView.OnCustomFilter += new MiscDataGridView.OnCustomFilterHandler(GridView_OnCustomFilter);
            LoadData();

            grMain.LoadData();
            if (grMain.GridView.Columns["GIO"] is CalendarColumn colGio)
            {
                colGio.Format = "HH:mm:ss";
            }

            try
            {
                if (grMain.GridView.Columns.Contains("NGAY")) grMain.GridView.Columns["NGAY"].DisplayIndex = 0;
                if (grMain.GridView.Columns.Contains("GIO")) grMain.GridView.Columns["GIO"].DisplayIndex = 1;
                if (grMain.GridView.Columns.Contains("SODONHANG")) grMain.GridView.Columns["SODONHANG"].DisplayIndex = 2;
                if (grMain.GridView.Columns.Contains("NOTE"))
                {
                    grMain.GridView.Columns["NOTE"].DisplayIndex = 3;
                    grMain.GridView.Columns["NOTE"].Width = 240;
                }
                if (grMain.GridView.Columns.Contains("TAIKHOAN")) grMain.GridView.Columns["TAIKHOAN"].DisplayIndex = 4;
                if (grMain.GridView.Columns.Contains("THIETBI")) grMain.GridView.Columns["THIETBI"].DisplayIndex = 5;
                if (grMain.GridView.Columns.Contains("BAN")) grMain.GridView.Columns["BAN"].DisplayIndex = 6;
                if (grMain.GridView.Columns.Contains("CHUCNANG")) grMain.GridView.Columns["CHUCNANG"].Visible = false;
            }
            catch { }

            foreach (DataGridViewColumn col in grMain.GridView.Columns) col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void txtSoHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnRefresh.PerformClick();
        }
    }
}

namespace QuanLyNhaHang.Forms
{
    public class LuuVetHoatDong : No1Run.LuuVetHoatDong
    {
    }
}
