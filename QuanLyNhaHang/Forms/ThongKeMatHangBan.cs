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
using ChiTietBanHangTheoMatHang = QuanLyNhaHang.Forms.ChiTietBanHangTheoMatHang;

namespace No1Run
{
    public partial class ThongKeMatHangBan : No1Lib.Sys.No1UserControl, IRefreshable
    {
        public No1Lib.Sys.No1UserControl No1UserControl1 => this;

        public ThongKeMatHangBan()
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

        public void btnRefresh_Click(Object sender, EventArgs e)
        {
            LoadData();
        }

        decimal tongTienBan;
        decimal tongTienNhap;
        decimal tongGiamGia;
        decimal tongLai;
        decimal thucLai;
        int lastRefresh;
        private void LoadData()
        {
            lastRefresh = Environment.TickCount;
            EnsureViewConfigs();
            grDetail.LoadData();
            DataTable dt = grDetail.DataSource;
            tongTienBan = 0;
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    decimal thanhTien = ConvertTo.Decimal(r["THANHTIEN"]);
                    decimal lai = thanhTien - ConvertTo.Decimal(r["THANHTIENNHAP"]);
                    tongTienBan += ConvertTo.Decimal(r["SLXUATCHUAQUYDOI"]) * ConvertTo.Decimal(r["DONGIA"]);
                    r["LAI"] = lai;
                    r["TILELAI"] = thanhTien == 0 ? 0 : 100 * lai / thanhTien;
                }
            }
            //tính tổng tiền bán            
            lblTongTienBan.Text = tongTienBan.ToString("n0");
            //tính tổng tiền nhập
            tongTienNhap = grDetail.CalcSum("THANHTIENNHAP");
            lblTongTienNhap.Text = tongTienNhap.ToString("n0");
            //tính tổng tiền giảm giá trên đơn hàng
            string sql = @"SELECT SUM(TIENGIAMGIATONG + GIAMGIAMATHANG) AS TIENGIAMGIA, SUM(TIENGIO) AS TIENGIO,
                            SUM(TIENTHUE) AS TIENTHUE, SUM(PHIDICHVU) AS PHIDICHVU
                            FROM TDONHANG WHERE LOAI = 0 AND DATHANHTOAN = 30 AND NGAY BETWEEN @FromDate AND @ToDate";
            if (lueCuaHang.StringValue.Length > 0)
            {
                if (!DbConfig.IsAdmin)
                {
                    sql += " AND EXISTS(SELECT * FROM TNGUOIDUNGTHEOCUAHANG WHERE TNGUOIDUNGTHEOCUAHANG.DCUAHANGID = TDONHANG.DCUAHANGID AND SUSERID = '" + DbConfig.UserID + "')";
                }
                else
                {
                    sql += " AND DCUAHANGID = '" + lueCuaHang.StringValue + "'";
                }
            }

            FbCommand cmd = Config.Db.GetCommand(sql);
            cmd.Parameters.Add("@FromDate", FbDbType.Date).Value = FilterDateRange1.TuNgay;
            cmd.Parameters.Add("@ToDate", FbDbType.Date).Value = FilterDateRange1.DenNgay;

            TDONHANGRow tongRow = new TDONHANGRow(Config.Db.GetFirstRow(cmd));
            tongGiamGia = tongRow.TIENGIAMGIA;

            lblThueVal.Text = tongRow.TIENTHUE.ToString("n0");
            lblPhiDichVuVal.Text = tongRow.PHIDICHVU.ToString("n0");
            lblTienGioVal.Text = tongRow.TIENGIO.ToString("n0");

            lblGiamGia.Text = tongGiamGia.ToString("n0");
            tongLai = tongTienBan - tongTienNhap;
            lblTongLai.Text = tongLai.ToString("n0");
            thucLai = tongLai - tongGiamGia + tongRow.TIENTHUE + tongRow.PHIDICHVU + tongRow.TIENGIO;
            lblThucLai.Text = thucLai.ToString("n0");

            if (!xemGiaNhap)
            {
                HideColumn("GIAVON");
                HideColumn("THANHTIENNHAP");
                HideColumn("THANHTIEN");
                HideColumn("LAI");
                HideColumn("TILELAI");
                pnlBottom.Visible = false;
                btnIn.Visible = false;
            }

            if (Shared.UngDung == UngDung.KARAOKE)
            {
                //tổng hợp chi phí mặt hàng theo giờ
                LoadDichVuTongHop();

                ToolStrip1.Visible = DbUtils.CanView(Functions.DieuChinhGioTinhLuongDichVuTheoGio);
            }
        }

        private void LoadDichVuTongHop()
        {
            string sql = @"SELECT DMATHANG.ID, DMATHANG.NAME, 
SUM(CASE WHEN TUGIO IS NULL THEN 0 ELSE 1 END) AS SOLAN,
COALESCE(
SUM(
1000 * ROUND(GIANHAP * 24 * (CASE WHEN DENGIO IS NULL THEN KETTHUC ELSE DENGIO END - CASE WHEN GIOTINHLUONG IS NULL THEN TUGIO ELSE GIOTINHLUONG END) / 1000)), 0)
AS TONGCONG
FROM TDONHANG INNER JOIN TDONHANGCHITIET ON TDONHANG.ID = TDONHANGCHITIET.TDONHANGID
AND NGAY BETWEEN @FromDate AND @ToDate
AND DATHANHTOAN = 30
RIGHT JOIN DMATHANG ON TDONHANGCHITIET.DMATHANGID = DMATHANG.ID
WHERE DMATHANG.DLOAIMATHANGID = '7'";

            if (lueCuaHang.StringValue.Length > 0)
            {
                if (!DbConfig.IsAdmin)
                {
                    sql += " AND EXISTS(SELECT * FROM TNGUOIDUNGTHEOCUAHANG WHERE TNGUOIDUNGTHEOCUAHANG.DCUAHANGID = TDONHANG.DCUAHANGID AND SUSERID = '" + DbConfig.UserID + "')";
                }
                else
                {
                    sql += " AND DCUAHANGID = '" + lueCuaHang.StringValue + "'";
                }
            }

            sql += " GROUP BY DMATHANG.ID, DMATHANG.NAME";

            FbCommand cmd = Config.Db.GetCommand(sql);
            cmd.Parameters.Add("@FromDate", FbDbType.Date).Value = FilterDateRange1.TuNgay;
            cmd.Parameters.Add("@ToDate", FbDbType.Date).Value = FilterDateRange1.DenNgay;            
            DataTable dt = Config.Db.GetTable(cmd);
            grDichVu.DataSource = dt;
            grDichVu.Sort(colTongSo, ListSortDirection.Descending);
            decimal tongCong = 0;
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows) tongCong += ConvertTo.Decimal(r["TONGCONG"]);
            }
            lblTong.Text = "TỔNG CỘNG: " + tongCong.ToString("###,###.##");
        }

        public void btnIn_Click(Object sender, EventArgs e)
        {
            Config.PrintInvoice(null, Forms.ThongKeMatHangBan, "", true, true, new CustomReportHandler(delegate(DataSet ds, Dictionary<string, object> dic)
            {
                grDetail.CopyToDataSet(ds);
                dic.Add("TuNgay", FilterDateRange1.TuNgay);
                dic.Add("DenNgay", FilterDateRange1.DenNgay);

                dic.Add("TongTienBan", tongTienBan);
                dic.Add("TongTienNhap", tongTienNhap);
                dic.Add("TongGiamGia", tongGiamGia);
                dic.Add("TongLai", tongLai);
                dic.Add("ThucLai", thucLai);
            }));
        }

        public void FilterDateRange1_OnEditValueChanged(Object sender, Object value)
        {
            LoadData();
        }
         
        public void grDetail_CustomLoadData(Object sender, CustomLoadDataArgs e)
        {
            e.Command.Parameters.Add("@FromDate", FbDbType.Date).Value = FilterDateRange1.TuNgay;
            e.Command.Parameters.Add("@ToDate", FbDbType.Date).Value = FilterDateRange1.DenNgay;
            e.Select += ", DNHOMMATHANGID, DMATHANGID, (SELECT NAME FROM DNHOMMATHANG WHERE ID = DNHOMMATHANGID) AS NHOMHANG";
            e.GroupBy += ", DNHOMMATHANGID, DMATHANGID";

            if (rdCachTinh.SelectedIndex == 1)
            {
                e.Select = e.Select.Replace("TDONHANGCHITIET.GIAVON", "DMATHANG.GIANHAP");
                e.GroupBy = e.GroupBy.Replace("TDONHANGCHITIET.GIAVON", "DMATHANG.GIANHAP");
            }

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

            if (Shared.SapXepTheoMa())
            {
                e.OrderBy = "DMATHANG.CODE";
            }
            else
            {
                e.OrderBy = "TDONHANGCHITIET.TENHANG";
            }

            if (e.Where.Length > 0) e.Where += " AND ";
            e.Where += String.Format("COALESCE(DLOAIMATHANGID, '') <> '{0}'", (int)LoaiMatHang.NguyenLieu);

            if (e.Where.Length > 0) e.Where += " AND ";
            e.Where += "COALESCE(XUATVATTU, 0) = 0 AND COALESCE(COMBOPARENTID, '') = ''";
        }

        public void No1UserControl1_KeyDownEx(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) btnRefresh.PerformClick();
        }

        bool xemGiaNhap;
        public void No1UserControl1_Load(Object sender, EventArgs e)
        {
            xemGiaNhap = DbUtils.CanView(Functions.XemGiaNhap);

            //chỉ hiển thị mặt hàng dịch vụ theo giờ nếu là karaoke
            if (Shared.UngDung != UngDung.KARAOKE)
            {
                tabMatHang.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.Panel;                            
            }

            FilterDateRange1.LockEvent = true;
            DateTime date = Config.Db.DbDate;
            FilterDateRange1.FromDate = date;
            FilterDateRange1.ToDate = date;
            FilterDateRange1.LockEvent = false;
            grDetail.GridView.OnCustomFilter += new MiscDataGridView.OnCustomFilterHandler(GridView_OnCustomFilter);
            grDetail.GridView.CellDoubleClick += new DataGridViewCellEventHandler(GridView_CellDoubleClick);
            lueCuaHang.LoadData(Tables.DCUAHANG);
            LoadData();
        }

        private void HideColumn(string colName)
        {
            DataGridViewColumn c = grDetail.GridView.Columns[colName];
            if (c != null) c.Visible = false;
        }

        void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //hien thi chi tiet
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                ChiTietBanHangTheoMatHang form = (ChiTietBanHangTheoMatHang)Config.CreateForm(Forms.ChiTietBanHangTheoMatHang);
                DataRow row = grDetail.GridView.SelectedRow;
                if (form != null && row != null)
                {
                    form.SetData(FilterDateRange1.TuNgay, FilterDateRange1.DenNgay, row["DMATHANGID"].ToString(), ConvertTo.Decimal(row["DONGIA"]), ConvertTo.Decimal(row["GIAVON"]), ConvertTo.Decimal(row["TILEGIAMGIA"]));
                    form.form.ShowDialog();
                }
            }
        }

        void GridView_OnCustomFilter(ref string filter)
        {
            if (tvNhom.SelectedID.Length > 0) 
            {
                if (filter.Length > 0) filter += " AND ";
                filter += "DNHOMMATHANGID = '" + tvNhom.SelectedID + "'";
            }
        }

        public void tvNhom_OnFocusedNodeChanged(TreeNode node, DataRow r, String ID, TreeItemType type)
        {
            grDetail.GridView.Filter = "";
        }

        public void tvNhom_OnCustomNode()
        {
            tvNhom.AddAllNode();
        }

        #region IRefreshable Members

        public new void DoRefresh()
        {
            if (Config.NeedRefresh(Tables.TDONHANG, lastRefresh))
            {
                LoadData();
            }
        }

        #endregion

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

        public void tvNhom_CustomLoadData(object sender, CustomLoadDataArgs e)
        {
            if (e.Where.Length > 0) e.Where += " AND ";
            e.Where += "COALESCE(DLOAIDOID, '') <> '" + ((int)LoaiDo.NguyenLieu).ToString() + "'";
        }

        public void rdCachTinh_OnEditValueChanged(object sender, object value)
        {
            LoadData();                     
        }

        public void grDichVu_SelectionChanged(object sender, EventArgs e)
        {
            LoadDichVuChiTiet();
        }

        private void LoadDichVuChiTiet()
        {
            if (grDichVu.SelectedRows.Count == 0)
            {
                grChiTiet.DataSource = null;
            }
            else
            {
                colTuGio.Format = "dd/MM/yyyy HH:mm";
                colDenGio.Format = "dd/MM/yyyy HH:mm";

                FbCommand cmd = Config.Db.GetCommand("");
                string sql = @"SELECT TDONHANGCHITIET.ID, TDONHANG.NAME, GIANHAP, 
(SELECT NAME FROM DBAN WHERE ID = DBANID) AS PHONG,
CASE WHEN GIOTINHLUONG IS NULL THEN TUGIO ELSE GIOTINHLUONG END AS TUGIO,
CASE WHEN DENGIO IS NULL THEN KETTHUC ELSE DENGIO END AS DENGIO
FROM TDONHANG INNER JOIN TDONHANGCHITIET ON TDONHANG.ID = TDONHANGCHITIET.TDONHANGID
AND NGAY BETWEEN @FromDate AND @ToDate
AND DATHANHTOAN = 30
AND TDONHANGCHITIET.DMATHANGID = '" + grDichVu.SelectedID + "' INNER JOIN DMATHANG ON TDONHANGCHITIET.DMATHANGID = DMATHANG.ID";

                if (lueCuaHang.StringValue.Length > 0)
                {
                    if (!DbConfig.IsAdmin)
                    {
                        sql += " WHERE EXISTS(SELECT * FROM TNGUOIDUNGTHEOCUAHANG WHERE TNGUOIDUNGTHEOCUAHANG.DCUAHANGID = TDONHANG.DCUAHANGID AND SUSERID = '" + DbConfig.UserID + "')";
                    }
                    else
                    {
                        sql += " WHERE DCUAHANGID = '" + lueCuaHang.StringValue + "'";
                    }
                }

                cmd.CommandText = sql;
                cmd.Parameters.Add("@FromDate", FbDbType.Date).Value = FilterDateRange1.TuNgay;
                cmd.Parameters.Add("@ToDate", FbDbType.Date).Value = FilterDateRange1.DenNgay;

                DataTable dt = Config.Db.GetTable(cmd);
                if (dt != null)
                {
                    dt.Columns.Add("THOIGIAN", typeof(string));
                    dt.Columns.Add("THANHTIEN", typeof(decimal));
                    foreach (DataRow r in dt.Rows)
                    {
                        DateTime tuGio = ConvertTo.Date(r["TUGIO"]);
                        DateTime denGio = ConvertTo.Date(r["DENGIO"]);

                        TimeSpan ts = denGio - tuGio;
                        r["THOIGIAN"] =
                                        (ts.Days > 0 ? (ts.Days.ToString() + " ngày ") : "") +
                                        (ts.Hours > 0 ? (ts.Hours.ToString() + " giờ ") : "") +
                                        ((ts.Minutes > 0 || (ts.Hours == 0 || ts.Days == 0)) ? (ts.Minutes.ToString() + " phút ") : "");
                        decimal giaNhap = ConvertTo.Decimal(r["GIANHAP"]);
                        r["THANHTIEN"] = 1000 * Math.Round((giaNhap * (decimal)ts.TotalHours) / 1000, 0);
                    }
                }

                grChiTiet.DataSource = dt;
            }
        }

        public void grChiTiet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsbDieuChinh.PerformClick();
        }

        public void grChiTiet_SelectionChanged(object sender, EventArgs e)
        {
            tsbDieuChinh.Enabled = grChiTiet.SelectedRows.Count > 0;
        }

        public void tsbDieuChinh_Click(object sender, EventArgs e)
        {
            DataRow r = grChiTiet.SelectedRow;
            if (r == null)
            {
                Msg.ShowWarning("Mời bạn chọn một dòng dữ liệu trước");
                return;
            }
            else
            {
                //kiểm tra quyền
                if (!DbUtils.CanLogin(Functions.DieuChinhGioTinhLuongDichVuTheoGio)) return;

                TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(r["ID"].ToString());
                TDONHANGRow dhRow = new TDONHANGRow(ctRow.TDONHANGID);
                string DMATHANGID = grDichVu.SelectedID;

                DatGioChoMatHang form = (DatGioChoMatHang)Config.CreateForm(Forms.DatGioChoMatHang);
                if (form != null)
                {
                    form.SetData(new DMATHANGRow(DMATHANGID), ctRow, dhRow.BATDAU, dhRow.KETTHUC);
                    form.dtBATDAU.Enabled = false;
                    form.dtKETTHUC.Enabled = false;
                    if (form.No1Form1.ShowDialog() == DialogResult.OK)
                    {
                        //cập nhật lại từ giờ, đến giờ
                        TDONHANGCHITIETRow upRow = new TDONHANGCHITIETRow(ctRow.ID);
                        upRow.GIOTINHLUONG = form.GioTinhLuong;
                        upRow.Update();

                        LoadDichVuTongHop();
                        //tải dịch vụ chi tiết
                        foreach (DataGridViewRow row in grDichVu.Rows)
                        {
                            if ((row.DataBoundItem as DataRowView).Row["ID"].ToString() == DMATHANGID)
                            {
                                grDichVu.ClearSelection();
                                row.Selected = true;
                                if (!row.Displayed)
                                    grDichVu.FirstDisplayedScrollingRowIndex = row.Index;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}

namespace QuanLyNhaHang.Forms
{
    public class ThongKeMatHangBan : No1Run.ThongKeMatHangBan
    {
    }
}
