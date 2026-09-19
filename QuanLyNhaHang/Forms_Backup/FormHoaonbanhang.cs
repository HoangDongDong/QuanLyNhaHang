using DbMapping;
using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Hóa đơn bán hàng (ID: 5f029a5b-8ec2-4229-bd1d-03fed9569db2)
    /// </summary>
    public partial class FormHoaonbanhang : Form
    {
        public string SFormId { get; } = "5f029a5b-8ec2-4229-bd1d-03fed9569db2";
        public string SFormTitle { get; } = "Hóa đơn bán hàng";

        public FormHoaonbanhang()
        {
            InitializeComponent();
        }



        		public void grMua_OnRowCalculate(Object sender, DataRow r, String fieldName)
        			//tính toán lại số lượng quy đổi
                    decimal quyDoi = 1;
                    if (suDung2DVT)
                        string DMATHANGID = r["DMATHANGID"].ToString();
                        DMATHANGRow mhRow = new DMATHANGRow(DMATHANGID);                
                        if (TonKhoHandler.Has2DonViTinh(mhRow) && r["DDONVITINHID"].ToString() != mhRow.DDONVITINHID)
                            quyDoi = mhRow.QUYDOI;
                    r["SLXUAT"] = quyDoi * ConvertTo.Decimal(r["SLXUATCHUAQUYDOI"]);
                    if (fieldName == "TILEGIAMGIA")
                        r["GIAMTHEOTIEN"] = 0;
                    else if (fieldName == "TIENGIAMGIA")
                        r["GIAMTHEOTIEN"] = 30;

                    if (ConvertTo.Int(r["GIAMTHEOTIEN"]) == 30)
                        decimal soLuong = ConvertTo.Decimal(r["SLXUATCHUAQUYDOI"]);
                        decimal donGia = ConvertTo.Decimal(r["DONGIA"]);
                        decimal tienGiam = ConvertTo.Decimal(r["TIENGIAMGIA"]);
                        r["TILEGIAMGIA"] = donGia * soLuong == 0 ? 0 : Math.Round(tienGiam * 100 / (donGia * soLuong), 2);
                        r["THANHTIEN"] = soLuong * donGia - tienGiam;
                    else
                        decimal thanhTien = ConvertTo.Decimal(r["SLXUATCHUAQUYDOI"]) * ConvertTo.Decimal(r["DONGIA"]);
                        r["TIENGIAMGIA"] = thanhTien * ConvertTo.Decimal(r["TILEGIAMGIA"]) / 100;
                        r["THANHTIEN"] = thanhTien * (1 - ConvertTo.Decimal(r["TILEGIAMGIA"]) / 100);


        		public void btnMoDatHang_Click(Object sender, EventArgs e)
                    if (grMua.RowCount + grTraLai.RowCount == 0)
                        string filter = "NOT EXISTS (SELECT * FROM TDONHANG WHERE TDATHANGID = TDATHANG.ID)";
                        STABLEDESCRow row = Config.GetTableDesc(Tables.TDATHANG);
                        TimKiem form = new TimKiem(row, filter);
                        if (form.ShowDialog() == DialogResult.OK)
                            //them vao mat hang
                            TDATHANGRow dhRow = new TDATHANGRow(form.SelectedID);
                            mapper[TDONHANGInfo.TDATHANGID].Value = form.SelectedID;
                            if (dhRow.DKHACHHANGID.Length > 0)
                                lueDKHACHHANGID.EditValue = dhRow.DKHACHHANGID;
                            //lay danh sach mat hang va dua vao hoa don

                            string sql = "SELECT * FROM TDATHANGCHITIET WHERE TDATHANGID = '" + form.SelectedID + "'";
                            DataTable dt = Config.Db.GetTable(sql);                    
                            foreach (DataRow r in dt.Rows)
                                TDATHANGCHITIETRow ctRow = new TDATHANGCHITIETRow(r);
                                DMATHANGRow mhRow = new DMATHANGRow(ctRow.DMATHANGID);
                                decimal quyDoi = mhRow.DDONVITINHID == ctRow.DDONVITINHID ? 1 : mhRow.QUYDOI;
                                DoAddItemToGrid(ctRow.DMATHANGID, mhRow.CODE, mhRow.NAME, mhRow.MASANCO, ctRow.DDONVITINHID.Length == 0 ? "" : new DDONVITINHRow(ctRow.DDONVITINHID).NAME, ctRow.DDONVITINHID, ctRow.SOLUONG, quyDoi, ctRow.TILEGIAMGIA, ctRow.DONGIA);
                            numTILEGIAMGIA.LockEvent = true;
                            numTIENGIAMGIA.LockEvent = true;
                            numTILEGIAMGIA.Value = dhRow.TILEGIAMGIA;
                            numTIENGIAMGIA.Value = dhRow.TIENGIAMGIA;
                            mapper[TDONHANGInfo.GIAMTHEOTIEN].Value = dhRow.GIAMTHEOTIEN;
                            numTILEGIAMGIA.LockEvent = false;
                            numTIENGIAMGIA.LockEvent = false;
                            mapper.RaiseOnCalculation();
                    else
                        Msg.ShowWarning("Mời bạn tạo mới hóa đơn trước");


        		public void btnTangSl1_Click(Object sender, EventArgs e)
                    foreach (DataGridViewRow r in grMua.GridView.SelectedRows)
                        DataRow row = (r.DataBoundItem as DataRowView).Row;
                        TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(row);
                        ctRow.SLXUATCHUAQUYDOI = ctRow.SLXUATCHUAQUYDOI + 1;
                        grMua.CalculateRow(ctRow.Row);
                        Track("Tăng số lượng '" + ctRow["DMATHANG_NAME"].ToString() + "' lên 1 ");

                    mapper.RaiseOnCalculation();

                    txtMaVach.Select();
                    txtMaVach.SelectAll();


        		public void btnGiamSl1_Click(Object sender, EventArgs e)
                    foreach (DataGridViewRow r in grMua.GridView.SelectedRows)
                        DataRow row = (r.DataBoundItem as DataRowView).Row;
                        TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(row);
                        ctRow.SLXUATCHUAQUYDOI = Math.Max(1, ctRow.SLXUATCHUAQUYDOI - 1);
                        grMua.CalculateRow(ctRow.Row);
                        Track("Giảm số lượng '" + ctRow["DMATHANG_NAME"].ToString() + "' đi 1 ");

                    mapper.RaiseOnCalculation();

                    txtMaVach.Select();
                    txtMaVach.SelectAll();

                #region ITestingSupport Members

                public void DoAutoTest()
                    Random rand = new Random();
                    int numRow = rand.Next(3, 7);
                    //them mat hang vao hoa don
                    for (int i = 0; i < numRow; i++)
                        numSL.Value = rand.Next(1, 10);
                        grMatHang.SelectRandomPos();
                        btnThem.PerformClick();
                    //thanh toan
                    btnThanhToan.PerformClick();

                    //hien thi thong ke
                    btnThongKe.PerformClick();

                    //kiem thu he thong
                    UiUtils.CloseActiveTab();

                #endregion


        		public void lueDKHOXUATID_CustomLoadData(object sender, CustomLoadDataArgs e)
                    if (!DbConfig.IsAdmin)
                        e.Where += " AND DCUAHANGID IN (SELECT DCUAHANGID FROM TNGUOIDUNGTHEOCUAHANG WHERE SUSERID = '" + DbConfig.UserID + "')";


        		public void lueDKHOXUATID_OnEditValueChanged(object sender, object value)
                    if (lueDKHOXUATID.StringValue.Length > 0)
                        mapper[TDONHANGInfo.DCUAHANGID].Value = new DKHOHANGRow(lueDKHOXUATID.StringValue).DCUAHANGID;


        		public void grMua_OnColumnInit(DataGridViewColumn col, SCOLUMNRow row)
                    if (SystemConfig.SuDungCanDienTu == 30)
                        if (row.NAME == "SLXUATCHUAQUYDOI")
                            (col as NumericDataGridViewColumn).DecimalLength = 3;


        		public void grMatHang_CustomLoadData(object sender, CustomLoadDataArgs e)
                    if (SystemConfig.SapXepThuTuTheo == 0)
                        e.OrderBy = "CODE";
                    else
                        e.OrderBy = "NAME";

                    //loại bỏ các sản phẩm là vật tư
                    if (e.Where.Length > 0) e.Where += " AND ";
                    e.Where += String.Format("COALESCE(LOAIDINHLUONG, 0) <> {0}", (int)LoaiMatHang.NguyenLieu);
        #endregion
    }
}