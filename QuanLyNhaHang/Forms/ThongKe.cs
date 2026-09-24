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

namespace No1Run
{
    public partial class ThongKe : No1Lib.Sys.No1Form
    {
        public No1Form form => this;

        string SUSERID = "";
        private DateTime ngayLoc;

        decimal tongDoanhSo;
        decimal tienMat;
        decimal chuyenKhoan;
        decimal tienThe;
        decimal voucher;
        decimal theTraTruoc;
        decimal truTichLuy;
        decimal tongThu;
        decimal tongChi;
        decimal thanhToan;
        decimal tienNo;

        public ThongKe()
        {
            InitializeComponent();
            LoadImages();
        }

        private void LoadImages()
        {
            try
            {
                pictureBox1.Image = ImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAABkpJREFUWEe1lglQ1FUcx7dIy7JrOqwsbZoac4bKUUTMM3JSRyk109LiKA2vYjI8EGRid/+7642AOCjDocLKFQjknWgsIHIIy6EIiyzHLpewgIsJu/v6/pZd2yHAXSZ35jPv/3/H7/fZ93//9388xhhvIPh84SjgzudzpwR8rhIwgYBjQgFXJhSIEsByTiCy6+nR8QZisLj96wdMHsAXeolEEpaUlHxfLi9tUaubqpGklKivV9UUFclb4+ISekRCMYOEe/+gJDQsgYAA4VgkDz5yJFynUjVW6fWGfIPBUAKKELAB1OL6OihGW0F1dY0yNOSwnhOK9nFC8Shz0mEJBAQIpgvxj678JevU6/X1CHYX9IBeC+7j+p6Jv1F29Pb21p0/d+EuBEIxI2NJYrgCx+TyshaDgTUjSDcwAPpR0i7QCposoH4toB1j1DJZtgYCocMS+C1AIExOPtWBQLUIcMeUmJIqQeVDqDI9GsWJ4zH3IOFl0wwg+WhOJDF0dnZlIFCZadrbUV6zgXz0LVc1qLPFnIRBwo5mwhp4EFiP1d6q0+n3YkAuoGd8AZy1FcTYj1nogsAia5JTHxK4XFJanolVvR4V6SAPxA4Db8TwkmVmlUIg3BYBjUbTEYZXaxUGHQc+IMQGDqLvJuCCGG4Kxe0UCMitFhByYgOmLgADlpqSu6BcDjYAf8ABkQV0T/iCH03jaAwE2IqWltZDEKA3xLo1IBCK9BDYgQFfgGXgS5PACpQrwdfADXgA2vVcTfXUTqLUfwn4nMY3N7fss0kAa0DT3q4RWiSlhKvBd6ZklJSSmzFLUDv1o/4kQyJfVVTcCrPpEUAgs6hYfsyU8FvTv/wB5VqwDtDipMdhhu6pntqpHwnRuG/wCFwvZ1w5C4FIXr8f2gd8JMbXUHoyvhQLaCM6rTEFp+ufwS9gM/jVArqnemqnfiRD49wRY1NURHQtvYa2CDwvEu/qwWMQI8hPpuDeKLcDWht+gBajGbqnemqnfiRDb8E6ZY3yIDYiA21EVgvQ1NBWHB+fKMcU0sqm4JSMD2i1S8AuC+ie6qmd+u1oblTtLcyTZUaER7SJBNw22optEiAJfA1jcnPzUnFNrxwl2QcCQTCw3BfonuqpXdKhuRNSXJiTe+nPi4bwsFCd/1aPwIWC3RM+2BXxnKUE5RiIB5UQmInPsT4vP/80Oh4Ch8FREAEiQZSppHuqp/bgivLigssZl/Spp1JYo6qG+R2L6Z0RLO1xOHDiLiRczRIPFeibBaEjDiSRaWnp17VabRzqpIDKBJBoKumeturj7W3tsSdjpXWBe0W9ZSXZLOjcefZpWCKT3G5j/JtNBkh0kcRgyal+sCOZv0Sy+356+h8lNTXKi1pt9xl0Nn6cOjs7TysUiou/J6XcwILT7fT199mwZlm05/79Pc5h8WxnmYrtqGpnftUdzLdcrZt6MMYoMTs0imfGUmjQ7RIH0tEWh1KlxaH0psWhdCSm2G7cKk+nOYdP6lzPZDHPPAVzK6hlHsVq5l2pYb5lKrOEh00Cg512B6qf6Hdg/MchUu3C2FS2ODWTLc28xZZfq2Wri5uYV2Ub8ylX66cFxdJMGCWsnQEeZgBwPPz7PgQcD8dyIDKCE3EfQhHPXhzu7RgUq3WOTmHzU2VssaySueTVsRXX1WxjRRvbXqrWo50k6AP2QGKoR2CTAA6lPATfPDVYCokkNi8ti82XVbEFuUq2pEDFPCGx7UbjfyT+VwHsgEYJB0jMjUxkzqnZzFmmYM5XlWxRQQNbexMS5c16p2Dpg5mw6ps91GtkbrNc5WaJOVFJbHZaDpuVdZs5ZzWw+flq5najjW2FxKQ9UZ3oN/KRCJAMSUzBTMyOSGAz0q4ypywlc7pazz4pbGLuFRrm2DcLYx6ZgKXELDwOp9Qc5pBZzabkNDCXQrXhw92RNAN2QwpY7OWP4bo/j6POEvoCPtGPEfbckS1TgqTamdHJzDE9lzlk3DLMjL14D28NZxw/5Db5b1JKRMFHgCfBU+AZ8Cygj86L4CXwKhgD3gBvgnHg7QlbxNzkwBPdk4Pjuu1FR+ve99mzB/WvGWNYIUD/jBKPMiWkZK+A18Fb4B3wHpgIPgIOYBqYDuaCeWDB0+PfXfnCJKfvcf0ZmAPswcv/AL5l4k1PvRnYAAAAAElFTkSuQmCC");
                btnInBaoCao.Image = ImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAACDElEQVQ4T5VS2U4iURTk0f8kyOY7m2zyBYBsyhoNioAEAsQECARk3xdRNH6BAQkGCYSkZs6ddONEZiZzk+pO+nTVPVXnCAAIOESjUUQiEYTDYR6hUAjX19cMV1dXCAaDP3/fcXgyfSQyne12i81mg/V6jdVqheVyiY+PD1a7vLzcLyAUCg/oZjoc8fPzk5EXiwXm8zmrXVxc7BcoFAq4ublhP329lSPPZjNWCwQCSCaTvAhvIZ/PM590vt76/v6O6XSKt7c3VvP5fEgkEr8LHB0dIZfLsZD+dbxeL2KxGCQSCRMREPn5+RkmkwknJycwGo08DAYD9Ho9g06ng1arxfHxMUO5XIZYLAYTeHp6wuPjIx4eHjAcDjEYDNDr9dDpdNBut9FsNlGv11GtVlGpVHB/f49isbgTGI/HGI1GjNjv99Htdhmx1Wqh0WigVqsxokajQalUglqtBoV+eHgIgVwux93dHdLNFKpFEuYQorH48zr7e0taMFoxDQlbrFooUQiEQQymYyNhkAJEzweD9xuN87Pz3F2dgaXywWn0wmHwwG73Q6bzYbT09OdgN/v/xYSBUUtU7sElUoFpVLJw2q1/hKgUUilUpYw55USJq8UFHmlHaExZ7NZZDIZKBQKRmZjpAeBWn59fcXLywsmkwmbzJ/CNZvN3zfxb17JL7VssVhA5L0CXCf/+/4BR3cS859koH4AAAAASUVORK5CYII=");
                btnOpen.Image = ImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAG4SURBVDhPpZNZLwNhGIXdYf6LrVpVKraE1JpqKTU6pdbSuKHtdNVhCI1lXIql9khssQaRuFRLhd8g/oTq8XUSTVChcfFdnvOe93nPlwQg6T/vX+Lo4IQNdCs1Qt1ChfcjdUIGDcvVguXQhJ49BiqhmE0oQX2gSug7aMP0Iwf+2gHjhg6FI7nOPyXQLlUK5n0jJh988D940brZiCJegTyPNCVmYL5gSrtO6Y6vF9EsVgrRyBMhL8ZDHnFyAScPK9zZKbEVzOeMsvOEfmGvLGC26/s/TAgsoXvXgPF7N8buXWDWG6D05YRzXRJRLBr0nBnKOo+bn0eDLCZDQ9BvqMMEVr96XuXv2qExeucCf8uiZU2L/CFZWO7MiolFg44jfappvwnWy17MPI2ADzpgPjDCcmTCcNAO7tYOelWDPK/0LcfxWRxbgd7SUGQyLMcmcc+xOyd8N1b4glboV+qisCIyNvPT5G89ILAo9ZwK7dvN4G5s8FwPoCmgBoEVkdkz4oq/9UA1W0KVTxWRyFrolmpBYEWktvQfxXGLRO5LFQzLQWC9ZlvTk3/7aHGLRGBRksG0X8UJVfmnJO++oqk8e7s/KAAAAABJRU5ErkJggg==");
                btnCancel.Image = ImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAACFElEQVQ4T6WTT0iTcRjHn3D65nJbr+2dZo3Ci0KE6EC9rpNEl52yS4HFhKyItJIKCwnBlVYUFh0a2b95yYJRHdYunYJJZBZEeogxhJAuecnSt88zt5cF0WWDz37P832e5/v7A6/Yti3lUNawbpw3SIjIlEgXZArcfII2CXfhHjwE+nZRH4JnEHUMtAiZ3wMD9nJf39pMe3tO8/slBg9ERhNVVe/QXz8S2QsbHIM4jRBlp8zbjo7ct54eO9vdvTIdCHziBKEprzeebm5eoJ6kb4duiEH+9Pk/NdBj3qF5QiQGmZlw+PvnSGT1ZVNTNt3SkkV7jlm99v7PQK7TMIbROCap1tYfqVBo5XZ19Ry5XANdlb9OcAmhyLCINcIjJRoaFpONjT/HDWM27vd/HausnKUmF2CwgHOFonCewpDIjceWlUsHg6sxw5i7KHIY7ektt3ue9cW5fxmcRFROi/ROeDzzmbo6e9Lny51FYkh06AzGMZfrI+tIP/mp0kc8RnKc1z3Bvd9b1q83prlMnMTUVGM9oQ6gDcMresM641whSgJX4253bqG21h6sqPjQy0NG0Iu/ToKj632XYfSIiMsxqKdwiN2/mObadE3NEvGVrSXDpWHbem9/l0ibY4C2ncLBA5jsF0kFRPag7QRC8YEHNoMF24IinbtF9pUaeCn4QTdWdFAHNsFGMAqr5tprwhbHoJzP+Q95lHpGrVHH8wAAAABJRU5ErkJggg==");
            }
            catch { }
        }

        private static Image ImageFromBase64(string base64)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64);
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    return new Bitmap(ms);
                }
            }
            catch { return null; }
        }

        public void form_Load(Object sender, EventArgs e)
        {
            SUSERID = DbConfig.UserID;
            if (DbUtils.CanView(Functions.XemThongKeCuaCacCaiKhoanKhac) || DbUtils.CanView(Functions.XemThongKeCuaCacTaiKhoanKhac))
            {
                lueSUSER.Visible = true;
                lueSUSER.LoadData(Tables.SUSER);
                lueSUSER.LockEvent = true;
                lueSUSER.EditValue = SUSERID;
                lueSUSER.LockEvent = false;
            }
            else
            {
                lueSUSER.Visible = false;
                lblTaiKhoan.Text = "Tài khoản: " + DbConfig.UserName;
            }
            DateTime dbDate = DateTime.Today;
            try
            {
                if (Config.Db != null)
                    dbDate = Config.Db.DbDate;
            }
            catch
            {
                dbDate = DateTime.Today;
            }
            dtNgay.DateTime = dbDate;
            grHoaDon.GridView.SelectionChanged += new EventHandler(GridView_SelectionChanged);
            grHoaDon.GridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(GridView_CellMouseDoubleClick);
            grHoaDon.GridView.KeyDown += new KeyEventHandler(GridView_KeyDown);
            tabMain.SelectedPage = pageDonHang;

            LoadData(dtNgay.DateTime);
            grHoaDon.Select();

            if (!DbUtils.CanView(Functions.ThongKeTrongSuDungDichVu))
            {
                KryptonPanel2.Visible = false;
                pageThuChi.Visible = false;
                pageMatHang.Visible = false;
                btnInBaoCao.Visible = false;
            }
        }

        void GridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnOpen.PerformClick();
            }
        }

        void GridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                btnOpen.PerformClick();
            }
        }

        void GridView_SelectionChanged(object sender, EventArgs e)
        {
            btnOpen.Enabled = grHoaDon.GridView.SelectedRows.Count > 0;
        }

        public void dtNgay_OnEditValueChanged(Object sender, Object value)
        {
            LoadData(dtNgay.DateTime);
        }

        public string SelectedID
        {
            get { return grHoaDon.SelectedID; }
        }

        private decimal SafeCalcSum(GridMapper gm, string field, string filter = "")
        {
            if (gm == null) return 0;
            try
            {
                return gm.CalcSum(field, filter ?? "");
            }
            catch
            {
                try
                {
                    DataTable dt = gm.GridView != null ? gm.GridView.DataSource as DataTable : null;
                    if (dt != null && dt.Columns.Contains(field) && dt.Rows.Count > 0)
                    {
                        object sum = dt.Compute("SUM(" + field + ")", filter ?? "");
                        if (sum != null && sum != DBNull.Value)
                        {
                            return ConvertTo.Decimal(sum);
                        }
                    }
                }
                catch { }
            }
            return 0;
        }

        private void LoadData(DateTime Ngay)
        {
            lblNgay.Text = "Ngày: " + Ngay.ToString("dd/MM/yyyy");
            ngayLoc = Ngay;
            //tính tổng doanh thu trên account
            grHoaDon.LoadData();
            grMatHang.LoadData();
            grThuChi.LoadData();

            tongDoanhSo = SafeCalcSum(grHoaDon, "TONGCONG");
            tienMat = SafeCalcSum(grHoaDon, "TIENMAT", "");
            chuyenKhoan = SafeCalcSum(grHoaDon, "CHUYENKHOAN", "");
            tienThe = SafeCalcSum(grHoaDon, "THE", "");
            voucher = SafeCalcSum(grHoaDon, "VOUCHER", "");
            theTraTruoc = SafeCalcSum(grHoaDon, "THETRATRUOC", "");
            truTichLuy = SafeCalcSum(grHoaDon, "TRUTICHLUY", "");
            tongThu = SafeCalcSum(grThuChi, "THU", "");
            tongChi = SafeCalcSum(grThuChi, "CHI", "");
            tienNo = SafeCalcSum(grHoaDon, "CONGNO", "");

            thanhToan = SafeCalcSum(grHoaDon, "TIENTHANHTOAN", "");

            lblGTConNo.Text = tienNo.ToString("n0");
            lblGTTienMat.Text = tienMat.ToString("n0");
            lblGTChuyenKhoan.Text = chuyenKhoan.ToString("n0");
            lblTheATM.Text = tienThe.ToString("n0");

            lblVoucher.Text = voucher.ToString("n0");
            lblTheTraTruoc.Text = theTraTruoc.ToString("n0");
            lblTruTichLuy.Text = truTichLuy.ToString("n0");

            lblGTThuChi.Text = (tongThu - tongChi).ToString("n0");

            tongDoanhSo = tienMat + tienThe + chuyenKhoan + tongThu - tongChi;

            lblGTTong.Text = tongDoanhSo.ToString("n0");

            SetTimeFormat(grHoaDon, TDONHANGInfo.BATDAU);
            SetTimeFormat(grHoaDon, TDONHANGInfo.KETTHUC);
        }

        internal void SetTimeFormat(GridMapper grHoaDon, string field)
        {
            CalendarColumn col = grHoaDon.GetColumnByField(field) as CalendarColumn;
            if (col == null) return;
            col.Format = "HH:mm";
        }

        public void grHoaDon_CustomLoadData(Object sender, CustomLoadDataArgs e)
        {
            if (string.IsNullOrEmpty(e.Where))
                e.Where += " TDONHANG.NGAY = @NGAY";
            else if (e.Where.TrimEnd().EndsWith("AND", StringComparison.OrdinalIgnoreCase))
                e.Where += " TDONHANG.NGAY = @NGAY";
            else
                e.Where += " AND TDONHANG.NGAY = @NGAY";

            if (!string.IsNullOrEmpty(SUSERID))
            {
                e.Where += " AND USERTHANHTOANID = '" + SUSERID + "'";
            }
            e.Command.Parameters.Add("@NGAY", FbDbType.Date).Value = ngayLoc;

            if (!DbUtils.CanView(Functions.ThongKeTrongSuDungDichVu))
            {
                if (!string.IsNullOrEmpty(e.Select))
                {
                    e.Select = e.Select.Replace("TDONHANG.TONGCONG", "0");
                    e.Select = e.Select.Replace("TDONHANG.TIENHANG", "0");
                    e.Select = e.Select.Replace("TDONHANG.KHACHDUA", "0");
                    e.Select = e.Select.Replace("TDONHANG.TRALAI", "0");
                    e.Select = e.Select.Replace("TDONHANG.TIENTHANHTOAN", "0");

                    e.Select = e.Select.Replace("TDONHANG.VOUCHER", "0");
                    e.Select = e.Select.Replace("TDONHANG.THETRATRUOC", "0");
                    e.Select = e.Select.Replace("TDONHANG.TRUTICHLUY", "0");
                    e.Select = e.Select.Replace("TDONHANG.TIENMAT", "0");
                    e.Select = e.Select.Replace("TDONHANG.CHUYENKHOAN", "0");
                    e.Select = e.Select.Replace("TDONHANG.THE", "0");
                    e.Select = e.Select.Replace("TDONHANG.CONGNO", "0");
                }
            }
        }

        public void grMatHang_CustomLoadData(Object sender, CustomLoadDataArgs e)
        {
            if (string.IsNullOrEmpty(e.Where))
                e.Where += " TDONHANG.NGAY = @NGAY";
            else if (e.Where.TrimEnd().EndsWith("AND", StringComparison.OrdinalIgnoreCase))
                e.Where += " TDONHANG.NGAY = @NGAY";
            else
                e.Where += " AND TDONHANG.NGAY = @NGAY";

            if (!string.IsNullOrEmpty(SUSERID))
            {
                e.Where += " AND USERTHANHTOANID = '" + SUSERID + "'";
            }
            e.Command.Parameters.Add("@NGAY", FbDbType.Date).Value = ngayLoc;
        }

        public void grHoaDon_grMain_SelectionChanged(Object sender, EventArgs e)
        {
            btnOpen.Enabled = grHoaDon.GridView.SelectedRows.Count > 0;
        }

        public void btnInBaoCao_Click(Object sender, EventArgs e)
        {
            Config.PrintInvoice(null, Forms.ThongKe, "", true, true, new CustomReportHandler(delegate(DataSet ds, Dictionary<string, object> dic)
            {
                grHoaDon.CopyToDataSet(ds);
                grMatHang.CopyToDataSet(ds);
                grThuChi.CopyToDataSet(ds);

                dic["Ngày"] = ngayLoc;
                dic["Tiền mặt"] = tienMat;
                dic["Trừ tích lũy"] = truTichLuy;
                dic["Chuyển khoản"] = chuyenKhoan;
                dic["Tiền thẻ"] = tienThe;
                dic["Voucher"] = voucher;
                dic["Thẻ trả trước"] = theTraTruoc;
                dic["Tổng thu"] = tongThu;
                dic["Tổng chi"] = tongChi;
                dic["Thanh toán"] = thanhToan;
                dic["Tiền nợ"] = tienNo;
                dic["Tổng cộng"] = tongDoanhSo;
            }));
        }

        public void grThuChi_CustomLoadData(object sender, CustomLoadDataArgs e)
        {
            if (string.IsNullOrEmpty(e.Where))
                e.Where += " NGAY = @NGAY";
            else if (e.Where.TrimEnd().EndsWith("AND", StringComparison.OrdinalIgnoreCase))
                e.Where += " NGAY = @NGAY";
            else
                e.Where += " AND NGAY = @NGAY";

            if (!string.IsNullOrEmpty(SUSERID))
            {
                e.Where += " AND USERCREATEDID = '" + SUSERID + "'";
            }
            e.Command.Parameters.Add("@NGAY", FbDbType.Date).Value = ngayLoc;
        }

        public void lueSUSER_OnEditValueChanged(object sender, object value)
        {
            SUSERID = lueSUSER.StringValue;
            LoadData(dtNgay.DateTime);
        }
    }
}
