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
    /// Form: Thống kê mặt hàng bán (ID: 67500401-1f1e-4c18-a0fc-f487c43f4b0c)
    /// </summary>
    public partial class FormThongkemathangban : Form
    {
        public string SFormId { get; } = "67500401-1f1e-4c18-a0fc-f487c43f4b0c";
        public string SFormTitle { get; } = "Thống kê mặt hàng bán";

        public FormThongkemathangban()
        {
            InitializeComponent();
        }



        		public void lueCuaHang_OnEditValueChanged(object sender, object value)
                    LoadData();


        		public void lueCuaHang_CustomLoadData(object sender, CustomLoadDataArgs e)
                    if (!DbConfig.IsAdmin)
                        e.Where += " AND ID IN (SELECT DCUAHANGID FROM TNGUOIDUNGTHEOCUAHANG WHERE SUSERID = '" + DbConfig.UserID + "')";


        		public void tvNhom_CustomLoadData(object sender, CustomLoadDataArgs e)
                    if (e.Where.Length > 0) e.Where += " AND ";
                    e.Where += "COALESCE(DLOAIDOID, '') <> '" + ((int)LoaiDo.NguyenLieu).ToString() + "'";


        		public void rdCachTinh_OnEditValueChanged(object sender, object value)
        			LoadData();                     


        		public void grDichVu_SelectionChanged(object sender, EventArgs e)
                    LoadDichVuChiTiet();

                private void LoadDichVuChiTiet()
                    if (grDichVu.SelectedRows.Count == 0)
                        grChiTiet.DataSource = null;
                    else
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
                            if (!DbConfig.IsAdmin)
                                sql += " WHERE EXISTS(SELECT * FROM TNGUOIDUNGTHEOCUAHANG WHERE TNGUOIDUNGTHEOCUAHANG.DCUAHANGID = TDONHANG.DCUAHANGID AND SUSERID = '" + DbConfig.UserID + "')";
                            else
                                sql += " WHERE DCUAHANGID = '" + lueCuaHang.StringValue + "'";

                        cmd.CommandText = sql;
                        cmd.Parameters.Add("@FromDate", FbDbType.Date).Value = FilterDateRange1.TuNgay;
                        cmd.Parameters.Add("@ToDate", FbDbType.Date).Value = FilterDateRange1.DenNgay;

                        DataTable dt = Config.Db.GetTable(cmd);
                        dt.Columns.Add("THOIGIAN", typeof(string));
                        dt.Columns.Add("THANHTIEN", typeof(decimal));
                        foreach (DataRow r in dt.Rows)
                            DateTime tuGio = ConvertTo.Date(r["TUGIO"]);
                            DateTime denGio = ConvertTo.Date(r["DENGIO"]);

                            TimeSpan ts = denGio - tuGio;
                            r["THOIGIAN"] =
                                            (ts.Days > 0 ? (ts.Days.ToString() + " ngày ") : "") +
                                            (ts.Hours > 0 ? (ts.Hours.ToString() + " giờ ") : "") +
                                            ((ts.Minutes > 0 || (ts.Hours == 0 || ts.Days == 0)) ? (ts.Minutes.ToString() + " phút ") : "");
                            decimal giaNhap = ConvertTo.Decimal(r["GIANHAP"]);
                            r["THANHTIEN"] = 1000 * Math.Round((giaNhap * (decimal)ts.TotalHours) / 1000, 0);

                        grChiTiet.DataSource = dt;


        		public void grChiTiet_MouseDoubleClick(object sender, MouseEventArgs e)
                    tsbDieuChinh.PerformClick();


        		public void grChiTiet_SelectionChanged(object sender, EventArgs e)
                    tsbDieuChinh.Enabled = grChiTiet.SelectedRows.Count > 0;


        		public void tsbDieuChinh_Click(object sender, EventArgs e)
                    DataRow r = grChiTiet.SelectedRow;
                    if (r == null)
                        Msg.ShowWarning("Mời bạn chọn một dòng dữ liệu trước");
                        return;
                    else
                        //kiểm tra quyền
                        if (!DbUtils.CanLogin(Functions.DieuChinhGioTinhLuongDichVuTheoGio)) return;

                        TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(r["ID"].ToString());
                        TDONHANGRow dhRow = new TDONHANGRow(ctRow.TDONHANGID);
                        string DMATHANGID = grDichVu.SelectedID;

                        DatGioChoMatHang form = (DatGioChoMatHang)Config.CreateForm(Forms.DatGioChoMatHang);
                        form.SetData(new DMATHANGRow(DMATHANGID), ctRow, dhRow.BATDAU, dhRow.KETTHUC);
                        form.dtBATDAU.Enabled = false;
                        form.dtKETTHUC.Enabled = false;
                        if (form.No1Form1.ShowDialog() == DialogResult.OK)
                            //cập nhật lại từ giờ, đến giờ
                            TDONHANGCHITIETRow upRow = new TDONHANGCHITIETRow(ctRow.ID);
                            upRow.GIOTINHLUONG = form.GioTinhLuong;
                            upRow.Update();

                            LoadDichVuTongHop();
                            //tải dịch vụ chi tiết
                            foreach (DataGridViewRow row in grDichVu.Rows)
                                if ((row.DataBoundItem as DataRowView).Row["ID"].ToString() == DMATHANGID)
                                    grDichVu.ClearSelection();
                                    row.Selected = true;
                                    if (!row.Displayed)
                                        grDichVu.FirstDisplayedScrollingRowIndex = row.Index;
                                    break;
        #endregion
    }
}