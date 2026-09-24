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
using System.Drawing.Printing;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Forms;

namespace No1Run
{
    public partial class InXuongBepControl : No1Lib.Sys.No1UserControl
    {
        public InXuongBepControl()
        {
            InitializeComponent();
        }

        public UserControl No1UserControl1 => this;

        private string tenMayIn = "";
        public string TenMayIn
        {
            get
            {
                return tenMayIn;
            }
            set
            {
                tenMayIn = value;
                if (lblCaption != null) lblCaption.Text = "Máy in: " + tenMayIn;
            }
        }

        public delegate void TrackCallBackHandler(string NoiDung);
        public event TrackCallBackHandler TrackRequest;

        public string TenBan;
        public string TenKhuVuc;

        public string LoaiDo;
        public string SoHoaDon = "";

        public string TDONHANGID;  
        public string NguoiIn = string.Empty;

        public void DoPrint()
        {
            if (lblCaption != null) lblCaption.Text = "Đang in...";

            if (DbMapping.SystemConfig.Db == null && Config.Db != null)
            {
                DbMapping.SystemConfig.Db = Config.Db;
            }
            if (DbMapping.BaseSystemConfig.AllConfigs == null && DbMapping.SystemConfig.Db != null)
            {
                try { DbMapping.BaseSystemConfig.Refresh(); } catch { }
            }

            // Lấy lần in số theo máy in
            LaySoLanIn();

            int soLanIn = Math.Min(5, Math.Max(1, SystemConfig.SoLienInCheBien));

            string MauIn = SystemConfig.MauInCheBien;

            Track("--Loại đồ '" + LoaiDo + "', máy in: " + tenMayIn + ", số liên: " + soLanIn.ToString() + ", lần số: " + LanSo.ToString());
            if (SystemConfig.InMoiDoRa1To == 30)
            {                
                DataTable data = dt;
                if (data != null)
                {
                    for (int i = 0; i < soLanIn; i++)
                    {
                        for (int r = 0; r < data.Rows.Count; r++)
                        {
                            Config.PrintInvoice(null, Forms.InCheBien, MauIn, "", MauIn.Length == 0,
                                new CustomReportHandler(delegate (DataSet ds, Dictionary<string, object> dic)
                                {
                                    DataTable dtData = data.Clone();
                                    dtData.ImportRow(data.Rows[r]);
                                    dtData.TableName = "DataSet";
                                    ds.Tables.Add(dtData);
                                    
                                    if (dic != null)
                                    {
                                        if (!string.IsNullOrEmpty(NguoiIn))
                                            dic["In bởi"] = NguoiIn;

                                        dic["TÊN BÀN"] = TenBan ?? "";
                                        dic["KHU VỰC"] = TenKhuVuc ?? "";
                                        dic["SỐ HĐ"] = SoHoaDon ?? "";
                                        dic["LẦN IN"] = LanSo.ToString();
                                    }
                                })
                                , tenMayIn, soLanIn);
                        }
                    }
                }
            }
            else
            {                
                PrintConfig config = new PrintConfig();
                config.MayIn = tenMayIn;
                config.OnCustomReport = new CustomReportHandler(CustomReportParam);
                config.SoLanIn = soLanIn;
                config.SREPORTTEMPLATEID = MauIn;
                config.ShowPreview = MauIn.Length == 0;
                config.ShowSelectTemplate = MauIn.Length == 0;
                config.SFORMID = Forms.InCheBien;
                Config.PrintInvoice(config);
            }

            if (SystemConfig.InThem1LienTaiQuay == 30)
            {                
                string printerName = new PrinterSettings().PrinterName;
                Track("--In 1 liên tại quầy: " + printerName);
                Config.PrintInvoice(null, Forms.InCheBien, MauIn, "", false, new CustomReportHandler(CustomReportParam), printerName);
            }

            if (lblCaption != null) lblCaption.Text = "In xong";

            // In xong sẽ cập nhật lại số lượng đã in            
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    string TenHang = r["TENHANG"] != null ? r["TENHANG"].ToString() : "";
                    decimal SoLuong = ConvertTo.Decimal(r["SOLUONG"]);
                    string GhiChu = r.Table.Columns.Contains("NOTE") && r["NOTE"] != null ? r["NOTE"].ToString() : "";
                    string dvtId = r.Table.Columns.Contains("DDONVITINHID") && r["DDONVITINHID"] != null ? r["DDONVITINHID"].ToString() : "";
                    string loaiDoId = r.Table.Columns.Contains("DLOAIDOID") && r["DLOAIDOID"] != null ? r["DLOAIDOID"].ToString() : "";
                    LuuInCheBien(TDONHANGID, TenHang, SoLuong, GhiChu, dvtId, loaiDoId, LanSo);
                    Track(string.Format("    Mặt hàng: {0}, Số lượng: {1}", TenHang, SoLuong) + (GhiChu.Length > 0 ? (", Ghi chú: " + GhiChu) : ""));
                }
            }

            Track("--In chế biến hoàn thành: " + tenMayIn);
        }

        private void Track(string NoiDung)
        {
            if (TrackRequest != null) TrackRequest(NoiDung);
        }

        public static void LuuInCheBien(string TDONHANGID, string TenHang, decimal SoLuong, string Note, string DDONVITINHID, string DLOAIDOID, int LanSo)
        {
            TINCHEBIENRow row = new TINCHEBIENRow();
            row.DDONVITINHID = DDONVITINHID;
            row.DLOAIDOID = DLOAIDOID;
            row.LANSO = LanSo;
            row.NOTE = Note;
            row.SOLUONG = SoLuong;
            row.TDONHANGID = TDONHANGID;
            row.TENHANG = TenHang;
            row.Update();                        
        }

        int LanSo;
        private void CustomReportParam(DataSet ds, Dictionary<string, object> dic)
        {            
            if (dic != null)
            {
                dic["TÊN BÀN"] = TenBan ?? "";
                dic["KHU VỰC"] = TenKhuVuc ?? "";
                dic["SỐ HĐ"] = SoHoaDon ?? "";
                dic["LẦN IN"] = LanSo.ToString();            
                
                if (!string.IsNullOrEmpty(NguoiIn))
                    dic["In bởi"] = NguoiIn;
            }
            
            if (dt != null)
            {
                dt.TableName = "DataSet";
                if (dt.DataSet != null) dt.DataSet.Tables.Remove(dt);
                ds.Tables.Add(dt);
            }
        }

        private void LaySoLanIn()
        {
            try
            {
                string sql = "SELECT ID, SOLANIN FROM TSOINCHEBIEN WHERE NGAY = @NGAY AND MAYIN = @MAYIN";
                FbCommand cmd = Config.Db.GetCommand(sql);
                cmd.Parameters.Add("@NGAY", FbDbType.TimeStamp).Value = Shared.GetNgayGiaoDich(Config.Db);
                cmd.Parameters.Add("@MAYIN", LoaiDo ?? "");
                DataRow r = Config.Db.GetFirstRow(cmd);
                if (r == null)
                {
                    TSOINCHEBIENRow row = new TSOINCHEBIENRow();
                    row.NGAY = Shared.GetNgayGiaoDich(Config.Db);
                    row.MAYIN = LoaiDo;
                    row.NAME = !string.IsNullOrEmpty(LoaiDo) ? LoaiDo : "In chế biến";
                    row.SOLANIN = 1;
                    row.Update();
                    LanSo = 1;
                }
                else
                {
                    sql = "UPDATE TSOINCHEBIEN SET SOLANIN = SOLANIN + 1, TIMEMODIFIED = CURRENT_TIMESTAMP WHERE ID = '{0}'";
                    sql = string.Format(sql, r["ID"].ToString());
                    Config.Db.ExecSql(sql);
                    LanSo = ConvertTo.Int(r["SOLANIN"]) + 1;
                }
            }
            catch
            {
                LanSo = 1;
            }
        }

        private DataTable dt;
        public DataTable DataSource
        {
            get
            {
                return dt;
            }
            set
            {
                dt = value;
                if (grMain != null) grMain.DataSource = value;                
            }
        }        
    }

    public class TINCHEBIENRow
    {
        public string ID { get; set; }
        public string DDONVITINHID { get; set; }
        public string DLOAIDOID { get; set; }
        public int LANSO { get; set; }
        public string NOTE { get; set; }
        public decimal SOLUONG { get; set; }
        public string TDONHANGID { get; set; }
        public string TENHANG { get; set; }

        public TINCHEBIENRow() { }
        public TINCHEBIENRow(DataRow r)
        {
            if (r != null)
            {
                ID = r.Table.Columns.Contains("ID") ? r["ID"]?.ToString() ?? "" : "";
                TDONHANGID = r.Table.Columns.Contains("TDONHANGID") ? r["TDONHANGID"]?.ToString() ?? "" : "";
                TENHANG = r.Table.Columns.Contains("TENHANG") ? r["TENHANG"]?.ToString() ?? "" : "";
                SOLUONG = r.Table.Columns.Contains("SOLUONG") ? ConvertTo.Decimal(r["SOLUONG"]) : 0;
                NOTE = r.Table.Columns.Contains("NOTE") ? r["NOTE"]?.ToString() ?? "" : "";
                DDONVITINHID = r.Table.Columns.Contains("DDONVITINHID") ? r["DDONVITINHID"]?.ToString() ?? "" : "";
                DLOAIDOID = r.Table.Columns.Contains("DLOAIDOID") ? r["DLOAIDOID"]?.ToString() ?? "" : "";
                LANSO = r.Table.Columns.Contains("LANSO") ? ConvertTo.Int(r["LANSO"]) : 0;
            }
        }

        public void Update()
        {
            try
            {
                string userId = !string.IsNullOrEmpty(DbConfig.UserID)
                    ? DbConfig.UserID
                    : (!string.IsNullOrEmpty(QuanLyNhaHang.Program.CurrentUserId) ? QuanLyNhaHang.Program.CurrentUserId : "4f1466a0-0756-4ba9-afa8-053b96ca7569");

                string sql = @"INSERT INTO TINCHEBIEN (ID, TDONHANGID, TENHANG, SOLUONG, NOTE, DDONVITINHID, DLOAIDOID, LANSO, TIMECREATED, STATUS, USERCREATEDID) 
                    VALUES (@ID, @TDONHANGID, @TENHANG, @SOLUONG, @NOTE, @DDONVITINHID, @DLOAIDOID, @LANSO, CURRENT_TIMESTAMP, 30, @USERCREATEDID)";
                var cmd = Config.Db.GetCommand(sql);
                cmd.Parameters.Add("@ID", FbDbType.VarChar).Value = string.IsNullOrEmpty(ID) ? Guid.NewGuid().ToString() : ID;
                cmd.Parameters.Add("@TDONHANGID", FbDbType.VarChar).Value = TDONHANGID ?? "";
                cmd.Parameters.Add("@TENHANG", FbDbType.VarChar).Value = TENHANG ?? "";
                cmd.Parameters.Add("@SOLUONG", FbDbType.Decimal).Value = SOLUONG;
                cmd.Parameters.Add("@NOTE", FbDbType.VarChar).Value = NOTE ?? "";
                cmd.Parameters.Add("@DDONVITINHID", FbDbType.VarChar).Value = DDONVITINHID ?? "";
                cmd.Parameters.Add("@DLOAIDOID", FbDbType.VarChar).Value = DLOAIDOID ?? "";
                cmd.Parameters.Add("@LANSO", FbDbType.Integer).Value = LANSO;
                cmd.Parameters.Add("@USERCREATEDID", FbDbType.VarChar).Value = userId;
                Config.Db.ExecSql(cmd);
            }
            catch (Exception ex)
            {
                Msg.ShowError("Lỗi lưu in chế biến: " + ex.Message);
            }
        }
    }

    public class TSOINCHEBIENRow
    {
        public string ID { get; set; }
        public DateTime NGAY { get; set; }
        public string MAYIN { get; set; }
        public string NAME { get; set; }
        public int SOLANIN { get; set; }

        public void Update()
        {
            try
            {
                string userId = !string.IsNullOrEmpty(DbConfig.UserID)
                    ? DbConfig.UserID
                    : (!string.IsNullOrEmpty(QuanLyNhaHang.Program.CurrentUserId) ? QuanLyNhaHang.Program.CurrentUserId : "4f1466a0-0756-4ba9-afa8-053b96ca7569");

                string sql = @"INSERT INTO TSOINCHEBIEN (ID, NGAY, MAYIN, NAME, SOLANIN, TIMECREATED, STATUS, USERCREATEDID) 
                    VALUES (@ID, @NGAY, @MAYIN, @NAME, @SOLANIN, CURRENT_TIMESTAMP, 30, @USERCREATEDID)";
                var cmd = Config.Db.GetCommand(sql);
                cmd.Parameters.Add("@ID", FbDbType.VarChar).Value = string.IsNullOrEmpty(ID) ? Guid.NewGuid().ToString() : ID;
                cmd.Parameters.Add("@NGAY", FbDbType.TimeStamp).Value = NGAY;
                cmd.Parameters.Add("@MAYIN", FbDbType.VarChar).Value = MAYIN ?? "";
                cmd.Parameters.Add("@NAME", FbDbType.VarChar).Value = string.IsNullOrEmpty(NAME) ? (MAYIN ?? "In chế biến") : NAME;
                cmd.Parameters.Add("@SOLANIN", FbDbType.Integer).Value = SOLANIN;
                cmd.Parameters.Add("@USERCREATEDID", FbDbType.VarChar).Value = userId;
                Config.Db.ExecSql(cmd);
            }
            catch (Exception ex)
            {
                Msg.ShowError("Lỗi lưu số lần in: " + ex.Message);
            }
        }
    }
}
