using DbMapping;
using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Quản lý bán hàng (ID: e91d6463-ce5b-4d5d-87da-1b99f44adf39)
    /// </summary>
    public partial class FormQuanlybanhang : Form
    {
        public string SFormId { get; } = "e91d6463-ce5b-4d5d-87da-1b99f44adf39";
        public string SFormTitle { get; } = "Quản lý bán hàng";

        public FormQuanlybanhang()
        {
            InitializeComponent();
        }



        		public void btnBillHuy_Click(Object sender, EventArgs e)
                    //DanhSachBillHuy form = (DanhSachBillHuy)Config.CreateForm(Forms.DanhSachBillHuy);
                    //form.form.ShowDialog();


        		public void grMua_OnRowCalculate(Object sender, DataRow r, String fieldName)
                    decimal quyDoi = 1;
                    //tính toán lại số lượng quy đổi
                    if (suDung2DVT && fieldName == "SLXUATCHUAQUYDOI")
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


        		public void lueCuaHang_OnEditValueChanged(object sender, object value)
                    LoadData();


        		public void lueCuaHang_CustomLoadData(object sender, CustomLoadDataArgs e)
                    if (!DbConfig.IsAdmin)
                        e.Where += " AND ID IN (SELECT DCUAHANGID FROM TNGUOIDUNGTHEOCUAHANG WHERE SUSERID = '" + DbConfig.UserID + "')";


        		public void Timer1_Tick(object sender, EventArgs e)
                    Timer1.Enabled = false; 
                    string ID = grMain.SelectedID;
                    if (ID.Length == 0)
                        KryptonSplitContainer1.Panel2.Enabled = false;
                    else
                        KryptonSplitContainer1.Panel2.Enabled = true;
                        ReLoad(ID);


        		public void txtLoc_TextChanged(object sender, EventArgs e)
                    grMain.GridView.Filter = txtLoc.Text;


        		public void numTIENTHANHTOAN_OnEditValueChanged(object sender, object value)
        			//khi thay đổi tiền thanh toán, chỉ 1 nội dung được thay đổi theo, các nội dung khác về 0            
                    No1NumericUpDown[] array = new No1NumericUpDown[] { numTHETRATRUOC, numTIENMAT, numTHE, numVOUCHER, numTRUTICHLUY, numCHUYENKHOAN };
                    foreach (No1NumericUpDown num in array)
                        num.LockEvent = true;

                    paymentControl.EditValue = numTIENTHANHTOAN.Value;
                    foreach (No1NumericUpDown num in array)
                        if (num != paymentControl) num.Value = 0;

                    foreach (No1NumericUpDown num in array)
                        num.LockEvent = false;


        		public void numTIENMAT_OnEditValueChanged(object sender, object value)
        			//khi thay đổi giá trị, cập nhật lại tiền thanh toán
                    numTIENTHANHTOAN.LockEvent = true;
                    numTIENTHANHTOAN.Value = numTIENMAT.Value + numTHE.Value + numCHUYENKHOAN.Value + numVOUCHER.Value + numTRUTICHLUY.Value + numTHETRATRUOC.Value;
                    numTIENTHANHTOAN.LockEvent = false;

                internal static void Track(string ChucNang, LoaiLuuVet PhanLoai, string NoiDung, string TDONHANGID, string Ban)
                    if (SystemConfig.KichHoatLuuVetHoatDong == 30)
                        DateTime gio = Config.Db.DbDateTime;
                        TLUUVETRow row = new TLUUVETRow();
                        row.GIO = gio;
                        row.CHUCNANG = ChucNang;
                        row.SODONHANG = TDONHANGID;
                        row.NGAY = gio.Date;
                        row.PHANLOAI = (int)PhanLoai;
                        row.TAIKHOAN = DbConfig.UserName;
                        row.BAN = Ban;
                        row.NOTE = NoiDung;
                        row.CHUCNANG = No1System.TouchMode ? "POS cảm ứng" : "Sử dụng dịch vụ";
                        row.THIETBI = Environment.MachineName;
                        row.Update();
        #endregion
    }
}