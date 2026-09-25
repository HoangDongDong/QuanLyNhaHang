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
    public partial class ThongKeDoanhThu : No1Lib.Sys.No1UserControl, IRefreshable
    {
        public No1Lib.Sys.No1UserControl No1UserControl1 { get { return this; } }

        public ThongKeDoanhThu()
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

        public void btnRefresh_Click(Object sender, EventArgs e)
        {
            LoadData();
        }

        int lastRefresh;
        public void LoadData()
        {
            lastRefresh = Environment.TickCount;
            EnsureViewConfigs();
            grMain.LoadData();

            // tÃ­nh toÃ¡n cÃ¡c giÃ¡ trá»‹ tá»•ng cá»™ng
            decimal tienHang = grMain.CalcSum("TIENHANGCHUAGIAM");
            decimal tienGio = grMain.CalcSum("TIENGIO");
            decimal giamGiaHang = grMain.CalcSum("TIENGIAMGIA") + grMain.CalcSum("GIAMGIAMATHANG");
            decimal giamGiaGio = grMain.CalcSum("TIENGIAMGIAGIO");
            decimal tongGiamGia = giamGiaHang + giamGiaGio;
            decimal phiDichVu = grMain.CalcSum("PHIDICHVU");
            decimal thue = grMain.CalcSum("TIENTHUE");
            decimal tongCong = grMain.CalcSum("TONGCONG");

            decimal tienMat = grMain.CalcSum("TIENMAT");
            decimal voucher = grMain.CalcSum("VOUCHER");
            decimal tienThe = grMain.CalcSum("THE");
            decimal chuyenKhoan = grMain.CalcSum("CHUYENKHOAN");
            decimal truTichLuy = grMain.CalcSum("TRUTICHLUY");
            decimal theTraTruoc = grMain.CalcSum("THETRATRUOC");
            decimal congNo = grMain.CalcSum("CONGNO");

            decimal thu = 0;
            decimal chi = 0;
            try
            {
                FbCommand cmd = Config.Db.GetCommand("SELECT SUM(COALESCE(THU, 0)) AS THU, SUM(COALESCE(CHI, 0)) AS CHI FROM TTHUCHI WHERE NGAY BETWEEN @FromDate AND @ToDate");
                cmd.Parameters.Add("@FromDate", FbDbType.TimeStamp).Value = dtNgay.TuNgay;
                cmd.Parameters.Add("@ToDate", FbDbType.TimeStamp).Value = dtNgay.DenNgay;

                DataRow r = Config.Db.GetFirstRow(cmd);
                if (r != null)
                {
                    thu = ConvertTo.Decimal(r["THU"]);
                    chi = ConvertTo.Decimal(r["CHI"]);
                }
            }
            catch { }

            lblTienHangVal.Text = tienHang.ToString("n0");
            lblTienGioVal.Text = tienGio.ToString("n0");
            lblGiamGiaTiengHangVal.Text = "-" + giamGiaHang.ToString("n0");
            lblGiamGiaTienGioVal.Text = "-" + giamGiaGio.ToString("n0");

            lblTongGiamGiaVal.Text = "-" + tongGiamGia.ToString("n0");
            lblPhiDichVuVal.Text = phiDichVu.ToString("n0");
            lblThueVal.Text = thue.ToString("n0");
            lblTongCongVal.Text = tongCong.ToString("n0");            

            lblVoucher.Text = voucher.ToString("n0");
            lblTienMatVal.Text = tienMat.ToString("n0");
            lblTienTheVal.Text = tienThe.ToString("n0");
            lblChuyenKhoanVal.Text = chuyenKhoan.ToString("n0");
            lblTruTichLuyVal.Text = truTichLuy.ToString("n0");
            lblTheTraTruocVal.Text = theTraTruoc.ToString("n0");
            lblCongNoVal.Text = congNo.ToString("n0");

            lblThuVal.Text = thu.ToString("n0");
            lblChiVal.Text = chi.ToString("n0");
            lblCongVal.Text = (tienMat + tienThe + chuyenKhoan + thu - chi).ToString("n0");

            try
            {
                if (grMain.GridView != null)
                {
                    QuanLyBanHangNhaHang.FormatTimeColumn(grMain.GridView, "BATDAU");
                    QuanLyBanHangNhaHang.FormatTimeColumn(grMain.GridView, "KETTHUC");
                }
            }
            catch { }
        }

        public void btnIn_Click(Object sender, EventArgs e)
        {
            Config.PrintInvoice(null, Forms.ThongKeDoanhThu, "", true, true, new CustomReportHandler(delegate(DataSet ds, Dictionary<string, object> dic)
            {
                grMain.CopyToDataSet(ds);
                dic.Add("TuNgay", dtNgay.TuNgay);
                dic.Add("DenNgay", dtNgay.DenNgay);
            }));
        }

        public void dtNgay_OnEditValueChanged(Object sender, Object value)
        {
            LoadData();
        }

        public void No1UserControl1_Load(Object sender, EventArgs e)
        {
            try
            {
                TDONHANG0Ae.EnsureNo1LibInitialized();
            }
            catch { }

            EnsureViewConfigs();

            dtNgay.LockEvent = true;
            DateTime date = (Config.Db != null && Config.Db.DbDate != DateTime.MinValue) ? Config.Db.DbDate : DateTime.Today;
            dtNgay.FromDate = date;
            dtNgay.ToDate = date;
            dtNgay.LockEvent = false;

            try
            {
                grDetail.LoadData();
            }
            catch { }

            if (grMain.GridView != null)
            {
                grMain.GridView.SelectionChanged -= new EventHandler(GridView_SelectionChanged);
                grMain.GridView.SelectionChanged += new EventHandler(GridView_SelectionChanged);
            }

            try
            {
                lueCuaHang.LoadData(Tables.DCUAHANG);
            }
            catch (Exception exLue)
            {
                System.Diagnostics.Debug.WriteLine("Error loading lueCuaHang: " + exLue.Message);
            }

            LoadData();
        }

        void GridView_SelectionChanged(object sender, EventArgs e)
        {
            grDetail.LoadData();
        }

        public void grDetail_CustomLoadData(Object sender, CustomLoadDataArgs e)
        {
            if (grMain.SelectedID.Length == 0)
            {
                e.Where += "0 = 1";
                return;
            }
            else
            {
                if (e.Where.Length > 0) e.Where += " AND ";
                e.Where += "TDONHANGID = '" + grMain.SelectedID + "'";
            }

            if (e.Where.Length > 0) e.Where += " AND (COALESCE(XUATVATTU, 0) = 0) AND ";
            e.Where += String.Format("COALESCE(DLOAIMATHANGID, '0') <> '{0}' AND COALESCE(COMBOPARENTID, '') = ''", (int)LoaiMatHang.NguyenLieu);
        }

        public void grMain_CustomLoadData(Object sender, CustomLoadDataArgs e)
        {
            e.Command.Parameters.Add("@FromDate", FbDbType.Date).Value = dtNgay.TuNgay;
            e.Command.Parameters.Add("@ToDate", FbDbType.Date).Value = dtNgay.DenNgay;

            if (lueCuaHang.StringValue.Length == 0)
            {
                if (!DbConfig.IsAdmin)
                {
                    e.Where += " AND EXISTS(SELECT * FROM TNGUOIDUNGTHEOCUAHANG WHERE TNGUOIDUNGTHEOCUAHANG.DCUAHANGID = TDONHANG.DCUAHANGID AND SUSERID = '" + DbConfig.UserID + "')";
                }
            }
            else
            {
                e.Where += " AND DCUAHANGID = '" + lueCuaHang.StringValue + "'";
            }
            
            e.OrderBy = "NGAY, GIOTHANHTOAN";
        }

        public void lueCuaHang_OnEditValueChanged(object sender, object value)
        {
            LoadData();
        }

        public void lueCuaHang_CustomLoadData(object sender, CustomLoadDataArgs e)
        {
            if (!DbConfig.IsAdmin)
            {
                e.Where += " AND ID IN (SELECT DCUAHANGID FROM TNGUOIDUNGTHEOCUAHANG WHERE SUSERID = '" + DbConfig.UserID + "')";
            }
        }

        #region IRefreshable Members

        public new void DoRefresh()
        {
            if (Config.NeedRefresh(Tables.TDONHANG, lastRefresh) || Config.NeedRefresh(Tables.TTHUCHI, lastRefresh))
            {
                LoadData();
            }
        }

        #endregion
    }
}

namespace QuanLyNhaHang.Forms
{
    public class ThongKeDoanhThu : No1Run.ThongKeDoanhThu
    {
    }
}