using System;
using System.Data;
using System.Windows.Forms;
using No1Lib.Sys;
using No1Lib.Db;
using No1Lib.Utils;
using QuanLyNhaHang.Forms;

namespace No1Run
{
    public delegate void SelectBanTuTabRequestHandler(string db, string dk, bool empty);
    public delegate void OnLockTableRequestHandler(object sender);
    public delegate void OnKhuVucControlCreatedHandler(KhuVucControl lst);

    public class TableLocker
    {
        public string DBANID { get; set; }
        public TableLocker(string dbanId, object callback) { this.DBANID = dbanId; }
        public void Lock() { }
        public void UnLockAndStop() { }
    }

    public enum LoaiDo
    {
        DoAn = 0,
        DoUong = 1,
        DichVu = 2,
        DoKhac = 3,
        NguyenLieu = 4
    }

    public enum LoaiMatHang
    {
        None = 0,
        DichVu = 1,
        MatHangKiemVatTu = 2,
        MatHangMo = 3,
        DinhLuong = 4,
        DichVuTheoGio = 5,
        Combo = 6,
        ComboMo = 7
    }

    public enum CachTinhGiaGio
    {
        THEOGIO = 0,
        THEOBANGGIA = 1,
        THEOKHUVUC = 2
    }

    public enum CachChonGioTinhGia
    {
        GioThanhToan = 0,
        GioBatDau = 1
    }

    public enum CachChonKhachHang
    {
        ChuotVaBanPhim = 0,
        SuDungTheTu = 1
    }

    public enum ChonBanMode
    {
        All = 0,
        Empty = 1,
        Busy = 2
    }

    public enum ChuyenGopBanMode
    {
        None = 0,
        ChuyenBan = 1,
        GopBan = 2,
        ChuyenMatHang = 3
    }

    public enum GiaMatHang
    {
        None = 0,
        GIABAN = 1,
        GIABAN2 = 2,
        GIABAN3 = 3,
        GIABAN4 = 4,
        HIENTHILUACHON = 5
    }

    public class LuuVetInfo
    {
        public DateTime Gio { get; set; }
        public DateTime Ngay { get; set; }
        public string Note { get; set; }
        public int PhanLoai { get; set; }
        public string SoDonHang { get; set; }
        public string TaiKhoan { get; set; }
        public string TenBan { get; set; }
        public string ThietBi { get; set; }
        public string TenHang { get; set; }
        public string ChucNang { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }

    public class TDATHANGRow
    {
        public DataRow Row { get; set; }
        public string ID { get { return Row != null && Row.Table.Columns.Contains("ID") ? Row["ID"].ToString() : ""; } set { this["ID"] = value; } }
        public bool IsNull => Row == null;
        public int DATHANHTOAN { get { return ConvertTo.Int(this["DATHANHTOAN"]); } set { this["DATHANHTOAN"] = value; } }
        public string DBANID { get { return ConvertTo.String(this["DBANID"]); } set { this["DBANID"] = value; } }
        public string DKHACHHANGID { get { return ConvertTo.String(this["DKHACHHANGID"]); } set { this["DKHACHHANGID"] = value; } }
        public DateTime INTAMTINHLUC { get { return ConvertTo.Date(this["INTAMTINHLUC"]); } set { this["INTAMTINHLUC"] = value; } }
        public int SOLANINTAMTINH { get { return ConvertTo.Int(this["SOLANINTAMTINH"]); } set { this["SOLANINTAMTINH"] = value; } }
        public int TUTHAYDOIGIO { get { return ConvertTo.Int(this["TUTHAYDOIGIO"]); } set { this["TUTHAYDOIGIO"] = value; } }

        public TDATHANGRow() { }
        public TDATHANGRow(DataRow r) { this.Row = r; }
        public TDATHANGRow(string id)
        {
            try { this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM TDATHANG WHERE ID = '{0}'", id)); } catch { }
        }
        public object this[string col]
        {
            get { return Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value; }
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public class DNHOMMATHANGRow
    {
        public DataRow Row { get; set; }
        public decimal TILEGIAMDOAN { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMDOAN") ? ConvertTo.Decimal(Row["TILEGIAMDOAN"]) : 0; } set { this["TILEGIAMDOAN"] = value; } }
        public decimal TILEGIAMDOUONG { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMDOUONG") ? ConvertTo.Decimal(Row["TILEGIAMDOUONG"]) : 0; } set { this["TILEGIAMDOUONG"] = value; } }
        public decimal TILEGIAMDOKHAC { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMDOKHAC") ? ConvertTo.Decimal(Row["TILEGIAMDOKHAC"]) : 0; } set { this["TILEGIAMDOKHAC"] = value; } }
        public decimal TILEGIAMDICHVU { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMDICHVU") ? ConvertTo.Decimal(Row["TILEGIAMDICHVU"]) : 0; } set { this["TILEGIAMDICHVU"] = value; } }
        public DNHOMMATHANGRow() { }
        public DNHOMMATHANGRow(DataRow r) { this.Row = r; }
        public DNHOMMATHANGRow(string id)
        {
            try { this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM DNHOMMATHANG WHERE ID = '{0}'", id)); } catch { }
        }
        public object this[string col]
        {
            get { return Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value; }
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public class TDONHANGCHITIETRow
    {
        public DataRow Row { get; set; }
        public string ID { get { return Row != null && Row.Table.Columns.Contains("ID") ? Row["ID"].ToString() : ""; } set { this["ID"] = value; } }
        public decimal DONGIA { get { return ConvertTo.Decimal(this["DONGIA"]); } set { this["DONGIA"] = value; } }
        public decimal SLXUAT { get { return ConvertTo.Decimal(this["SLXUAT"]); } set { this["SLXUAT"] = value; } }
        public decimal SLXUATCHUAQUYDOI { get { return ConvertTo.Decimal(this["SLXUATCHUAQUYDOI"]); } set { this["SLXUATCHUAQUYDOI"] = value; } }
        public decimal SOLUONG { get { return ConvertTo.Decimal(this["SOLUONG"]); } set { this["SOLUONG"] = value; } }
        public decimal THANHTIEN { get { return ConvertTo.Decimal(this["THANHTIEN"]); } set { this["THANHTIEN"] = value; } }
        public decimal TILEGIAMGIA { get { return ConvertTo.Decimal(this["TILEGIAMGIA"]); } set { this["TILEGIAMGIA"] = value; } }
        public decimal TIENGIAMGIA { get { return ConvertTo.Decimal(this["TIENGIAMGIA"]); } set { this["TIENGIAMGIA"] = value; } }
        public string DMATHANGID { get { return ConvertTo.String(this["DMATHANGID"]); } set { this["DMATHANGID"] = value; } }
        public string DDONVITINHID { get { return ConvertTo.String(this["DDONVITINHID"]); } set { this["DDONVITINHID"] = value; } }
        public string TDONHANGID { get { return ConvertTo.String(this["TDONHANGID"]); } set { this["TDONHANGID"] = value; } }
        public string TENHANG { get { return ConvertTo.String(this["TENHANG"]); } set { this["TENHANG"] = value; } }
        public string NOTE { get { return ConvertTo.String(this["NOTE"]); } set { this["NOTE"] = value; } }
        public string COMBOID { get { return ConvertTo.String(this["COMBOID"]); } set { this["COMBOID"] = value; } }
        public string COMBOPARENTID { get { return ConvertTo.String(this["COMBOPARENTID"]); } set { this["COMBOPARENTID"] = value; } }
        public decimal COMBOSL { get { return ConvertTo.Decimal(this["COMBOSL"]); } set { this["COMBOSL"] = value; } }
        public int XUATVATTU { get { return ConvertTo.Int(this["XUATVATTU"]); } set { this["XUATVATTU"] = value; } }
        public int SOTT { get { return ConvertTo.Int(this["SOTT"]); } set { this["SOTT"] = value; } }
        public decimal GIAVON { get { return ConvertTo.Decimal(this["GIAVON"]); } set { this["GIAVON"] = value; } }
        public int GIAMTHEOTIEN { get { return ConvertTo.Int(this["GIAMTHEOTIEN"]); } set { this["GIAMTHEOTIEN"] = value; } }
        public string DNHANVIEN1ID { get { return ConvertTo.String(this["DNHANVIEN1ID"]); } set { this["DNHANVIEN1ID"] = value; } }
        public string DKHOXUATID { get { return ConvertTo.String(this["DKHOXUATID"]); } set { this["DKHOXUATID"] = value; } }
        public DateTime TUGIO { get { return ConvertTo.Date(this["TUGIO"]); } set { this["TUGIO"] = value; } }
        public DateTime DENGIO { get { return ConvertTo.Date(this["DENGIO"]); } set { this["DENGIO"] = value; } }
        public DateTime GIOTINHLUONG { get { return ConvertTo.Date(this["GIOTINHLUONG"]); } set { this["GIOTINHLUONG"] = value; } }

        public decimal CONGNO { get { return ConvertTo.Decimal(this["CONGNO"]); } set { this["CONGNO"] = value; } }
        public decimal CONLAI { get { return ConvertTo.Decimal(this["CONLAI"]); } set { this["CONLAI"] = value; } }
        public decimal CONNO { get { return ConvertTo.Decimal(this["CONNO"]); } set { this["CONNO"] = value; } }
        public int DATHANHTOAN { get { return ConvertTo.Int(this["DATHANHTOAN"]); } set { this["DATHANHTOAN"] = value; } }
        public decimal DATTRUOC { get { return ConvertTo.Decimal(this["DATTRUOC"]); } set { this["DATTRUOC"] = value; } }
        public string DBANGGIAID { get { return ConvertTo.String(this["DBANGGIAID"]); } set { this["DBANGGIAID"] = value; } }
        public string DBANID { get { return ConvertTo.String(this["DBANID"]); } set { this["DBANID"] = value; } }
        public string DCUAHANGID { get { return ConvertTo.String(this["DCUAHANGID"]); } set { this["DCUAHANGID"] = value; } }
        public decimal DIEM { get { return ConvertTo.Decimal(this["DIEM"]); } set { this["DIEM"] = value; } }
        public decimal DIEMGIAM { get { return ConvertTo.Decimal(this["DIEMGIAM"]); } set { this["DIEMGIAM"] = value; } }
        public string DKHACHHANGID { get { return ConvertTo.String(this["DKHACHHANGID"]); } set { this["DKHACHHANGID"] = value; } }
        public string DKHOHANGID { get { return ConvertTo.String(this["DKHOHANGID"]); } set { this["DKHOHANGID"] = value; } }
        public string DNHOMKHACHHANGID { get { return ConvertTo.String(this["DNHOMKHACHHANGID"]); } set { this["DNHOMKHACHHANGID"] = value; } }
        public string DTAIKHOANNGANHANGID { get { return ConvertTo.String(this["DTAIKHOANNGANHANGID"]); } set { this["DTAIKHOANNGANHANGID"] = value; } }
        public string DTHETRATRUOCID { get { return ConvertTo.String(this["DTHETRATRUOCID"]); } set { this["DTHETRATRUOCID"] = value; } }
        public string DVOUCHERID { get { return ConvertTo.String(this["DVOUCHERID"]); } set { this["DVOUCHERID"] = value; } }
        public decimal KHACHDUA { get { return ConvertTo.Decimal(this["KHACHDUA"]); } set { this["KHACHDUA"] = value; } }
        public int LANINHOADON { get { return ConvertTo.Int(this["LANINHOADON"]); } set { this["LANINHOADON"] = value; } }
        public int LOAI { get { return ConvertTo.Int(this["LOAI"]); } set { this["LOAI"] = value; } }
        public int LOAITHANHTOAN { get { return ConvertTo.Int(this["LOAITHANHTOAN"]); } set { this["LOAITHANHTOAN"] = value; } }
        public string NAME { get { return ConvertTo.String(this["NAME"]); } set { this["NAME"] = value; } }
        public DateTime NGAY { get { return ConvertTo.Date(this["NGAY"]); } set { this["NGAY"] = value; } }
        public DateTime BATDAU { get { return ConvertTo.Date(this["BATDAU"]); } set { this["BATDAU"] = value; } }
        public decimal NOCU { get { return ConvertTo.Decimal(this["NOCU"]); } set { this["NOCU"] = value; } }
        public string PASSWIFI { get { return ConvertTo.String(this["PASSWIFI"]); } set { this["PASSWIFI"] = value; } }
        public int PHANLOAI { get { return ConvertTo.Int(this["PHANLOAI"]); } set { this["PHANLOAI"] = value; } }
        public decimal PHIDICHVU { get { return ConvertTo.Decimal(this["PHIDICHVU"]); } set { this["PHIDICHVU"] = value; } }
        public int PHUTKHUYENMAI { get { return ConvertTo.Int(this["PHUTKHUYENMAI"]); } set { this["PHUTKHUYENMAI"] = value; } }
        public string SODONHANG { get { return ConvertTo.String(this["SODONHANG"]); } set { this["SODONHANG"] = value; } }
        public string SOHD { get { return ConvertTo.String(this["SOHD"]); } set { this["SOHD"] = value; } }
        public int SOKHACH { get { return ConvertTo.Int(this["SOKHACH"]); } set { this["SOKHACH"] = value; } }
        public int SOLANINTAMTINH { get { return ConvertTo.Int(this["SOLANINTAMTINH"]); } set { this["SOLANINTAMTINH"] = value; } }
        public string TAIKHOAN { get { return ConvertTo.String(this["TAIKHOAN"]); } set { this["TAIKHOAN"] = value; } }
        public string TDATHANGID { get { return ConvertTo.String(this["TDATHANGID"]); } set { this["TDATHANGID"] = value; } }
        public decimal THE { get { return ConvertTo.Decimal(this["THE"]); } set { this["THE"] = value; } }
        public decimal THETRATRUOC { get { return ConvertTo.Decimal(this["THETRATRUOC"]); } set { this["THETRATRUOC"] = value; } }
        public string THIETBI { get { return ConvertTo.String(this["THIETBI"]); } set { this["THIETBI"] = value; } }
        public decimal TIENGIAMGIAGIO { get { return ConvertTo.Decimal(this["TIENGIAMGIAGIO"]); } set { this["TIENGIAMGIAGIO"] = value; } }
        public decimal TIENGIAMGIATONG { get { return ConvertTo.Decimal(this["TIENGIAMGIATONG"]); } set { this["TIENGIAMGIATONG"] = value; } }
        public decimal TIENGIO { get { return ConvertTo.Decimal(this["TIENGIO"]); } set { this["TIENGIO"] = value; } }
        public decimal TIENHANG { get { return ConvertTo.Decimal(this["TIENHANG"]); } set { this["TIENHANG"] = value; } }
        public decimal TIENMAT { get { return ConvertTo.Decimal(this["TIENMAT"]); } set { this["TIENMAT"] = value; } }
        public decimal TIENMOBAN { get { return ConvertTo.Decimal(this["TIENMOBAN"]); } set { this["TIENMOBAN"] = value; } }
        public decimal TIENTHANHTOAN { get { return ConvertTo.Decimal(this["TIENTHANHTOAN"]); } set { this["TIENTHANHTOAN"] = value; } }
        public decimal TIENTHUE { get { return ConvertTo.Decimal(this["TIENTHUE"]); } set { this["TIENTHUE"] = value; } }
        public decimal TILEGIAMGIAGIO { get { return ConvertTo.Decimal(this["TILEGIAMGIAGIO"]); } set { this["TILEGIAMGIAGIO"] = value; } }
        public decimal TILEGIAMGIATONG { get { return ConvertTo.Decimal(this["TILEGIAMGIATONG"]); } set { this["TILEGIAMGIATONG"] = value; } }
        public decimal TILEKHUYENMAIPHUTDAU { get { return ConvertTo.Decimal(this["TILEKHUYENMAIPHUTDAU"]); } set { this["TILEKHUYENMAIPHUTDAU"] = value; } }
        public decimal TILEPHIDICHVU { get { return ConvertTo.Decimal(this["TILEPHIDICHVU"]); } set { this["TILEPHIDICHVU"] = value; } }
        public decimal TILETHUE { get { return ConvertTo.Decimal(this["TILETHUE"]); } set { this["TILETHUE"] = value; } }
        public decimal TONGCONG { get { return ConvertTo.Decimal(this["TONGCONG"]); } set { this["TONGCONG"] = value; } }
        public decimal TRALAI { get { return ConvertTo.Decimal(this["TRALAI"]); } set { this["TRALAI"] = value; } }
        public decimal TRUTICHLUY { get { return ConvertTo.Decimal(this["TRUTICHLUY"]); } set { this["TRUTICHLUY"] = value; } }
        public string USERTHANHTOANID { get { return ConvertTo.String(this["USERTHANHTOANID"]); } set { this["USERTHANHTOANID"] = value; } }
        public decimal VOUCHER { get { return ConvertTo.Decimal(this["VOUCHER"]); } set { this["VOUCHER"] = value; } }
        public decimal CHUYENKHOAN { get { return ConvertTo.Decimal(this["CHUYENKHOAN"]); } set { this["CHUYENKHOAN"] = value; } }
        public string CHUCNANG { get { return ConvertTo.String(this["CHUCNANG"]); } set { this["CHUCNANG"] = value; } }
        public DateTime BATDAUPHONGCUOI { get { return ConvertTo.Date(this["BATDAUPHONGCUOI"]); } set { this["BATDAUPHONGCUOI"] = value; } }
        public string BAN { get { return ConvertTo.String(this["BAN"]); } set { this["BAN"] = value; } }

        public TDONHANGCHITIETRow() { }
        public TDONHANGCHITIETRow(DataRow r) { this.Row = r; }
        public TDONHANGCHITIETRow(string id)
        {
            try { this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM TDONHANGCHITIET WHERE ID = '{0}'", id)); } catch { }
        }
        public object this[string col]
        {
            get { return Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value; }
            set
            {
                if (Row != null)
                {
                    if (Row.Table != null && !Row.Table.Columns.Contains(col))
                    {
                        Row.Table.Columns.Add(col, typeof(object));
                    }
                    if (Row.Table != null && Row.Table.Columns.Contains(col))
                    {
                        Row[col] = value ?? DBNull.Value;
                    }
                }
            }
        }
        public void Update()
        {
            try
            {
                if (Row != null)
                {
                    Config.Db.UpdateDataRow(Row, "TDONHANGCHITIET");
                }
            }
            catch { }
        }
    }

    // ═══════════════════════════════════════════════════════
    // POS AUXILIARY FORM BRIDGES
    // ═══════════════════════════════════════════════════════
    public class ChiTietCombo : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public void SetData(TDONHANGCHITIETRow row) { }
    }

    public class ChonBan : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public string DBANID { get; set; } = "";
        public string DKHUVUCID { get; set; } = "";
        public bool LaBanTrong { get; set; }
        public void SetData(ChonBanMode mode) { }
    }

    public class ChonKhachHangQuaThe : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form form => this;
        public string DKHACHHANGID { get; set; } = "";
    }

    public class ChonLoaiGia : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form form => this;
        public int LoaiGia { get; set; }
        public void SetMatHang(DMATHANGRow spRow) { }
    }

    public class DatGioChoMatHang : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public DateTime GioTinhLuong { get; set; }
        public void SetData(DMATHANGRow mhRow, TDONHANGCHITIETRow ctRow, DateTime batDau, DateTime ketThuc) { }
    }

    public class DatSoLuong : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public NumericUpDown spSoLuong { get; set; } = new NumericUpDown();
        public void SetData(decimal soLuong, string tenHang) { }
    }

    public class NhapMatKhauGiamDo : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
    }

    public class TamUngDonHang : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public void LoadData(string tdonhangId, string tdathangId, string tenBan) { }
    }

    public class ThayDoiGioVao : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public DateTime DateTime { get; set; }
        public void SetData(bool isGioRa, DateTime dt) { }
    }

    public class TimKiemDatTruoc : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public string TDATHANGID { get; set; } = "";
        public void SetData(string banId) { }
    }

    public static class TDONHANGInfo
    {
        public const string BATDAU = "BATDAU";
        public const string KETTHUC = "KETTHUC";
        public const string CACHTINHGIA = "CACHTINHGIA";
        public const string DBANID = "DBANID";
        public const string DONGIA = "DONGIA";
        public const string GIAMGIAGIOTHEOTIEN = "GIAMGIAGIOTHEOTIEN";
        public const string GIAMGIAMATHANG = "GIAMGIAMATHANG";
        public const string GIAMTHEOTIEN = "GIAMTHEOTIEN";
        public const string GIAMTONGTHEOTIEN = "GIAMTONGTHEOTIEN";
        public const string NAME = "NAME";
        public const string NHOMGUID = "NHOMGUID";
        public const string PHIDICHVUTHEOTIEN = "PHIDICHVUTHEOTIEN";
        public const string PHUTKHUYENMAI = "PHUTKHUYENMAI";
        public const string TDATHANGID = "TDATHANGID";
        public const string TIENHANGCHUAGIAM = "TIENHANGCHUAGIAM";
        public const string TIENMOBAN = "TIENMOBAN";
        public const string TILEKHUYENMAIPHUTDAU = "TILEKHUYENMAIPHUTDAU";
        public const string TUTHAYDOIGIO = "TUTHAYDOIGIO";
    }

    public static class DDONVITINHInfo
    {
        public const string NAME = "NAME";
    }

    public static class LOAIHINHKHUYENMAI
    {
        public const string GIAMGIATONGBILL = "1";
        public const string GIAMGIATHEOSANPHAM = "2";
        public const string GIAMGIATHEONHOM = "3";
        public const string MATHANGDONGGIA = "4";
        public const string MUA1TANG1 = "e5d39bb6-41a4-43ff-bc4d-e170ae4aeba2";
    }

    public class DDOTKHUYENMAIRow
    {
        public DataRow Row { get; set; }
        public decimal TILEGIAMGIA { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMGIA") ? ConvertTo.Decimal(Row["TILEGIAMGIA"]) : 0; } set { this["TILEGIAMGIA"] = value; } }
        public decimal TILEGIAMGIATONG { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMGIATONG") ? ConvertTo.Decimal(Row["TILEGIAMGIATONG"]) : 0; } set { this["TILEGIAMGIATONG"] = value; } }
        public decimal TILEGIAMGIATIENGIO { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMGIATIENGIO") ? ConvertTo.Decimal(Row["TILEGIAMGIATIENGIO"]) : 0; } set { this["TILEGIAMGIATIENGIO"] = value; } }
        public int KHUYENMAIGIOHAT { get { return Row != null && Row.Table.Columns.Contains("KHUYENMAIGIOHAT") ? ConvertTo.Int(Row["KHUYENMAIGIOHAT"]) : 0; } set { this["KHUYENMAIGIOHAT"] = value; } }
        public decimal TILEGIAMGIAGIODAU { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMGIAGIODAU") ? ConvertTo.Decimal(Row["TILEGIAMGIAGIODAU"]) : 0; } set { this["TILEGIAMGIAGIODAU"] = value; } }
        public DDOTKHUYENMAIRow() { }
        public DDOTKHUYENMAIRow(DataRow r) { this.Row = r; }
        public object this[string col]
        {
            get { return Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value; }
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public class DNHOMKHACHHANGRow
    {
        public DataRow Row { get; set; }
        public string ID { get { return Row != null && Row.Table.Columns.Contains("ID") ? Row["ID"].ToString() : ""; } set { this["ID"] = value; } }
        public string NAME { get { return Row != null && Row.Table.Columns.Contains("NAME") ? Row["NAME"].ToString() : ""; } set { this["NAME"] = value; } }
        public decimal DIEMTICHLUY { get { return Row != null && Row.Table.Columns.Contains("DIEMTICHLUY") ? ConvertTo.Decimal(Row["DIEMTICHLUY"]) : 0; } set { this["DIEMTICHLUY"] = value; } }
        public decimal TILEGIAMDOAN { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMDOAN") ? ConvertTo.Decimal(Row["TILEGIAMDOAN"]) : 0; } set { this["TILEGIAMDOAN"] = value; } }
        public decimal TILEGIAMDOUONG { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMDOUONG") ? ConvertTo.Decimal(Row["TILEGIAMDOUONG"]) : 0; } set { this["TILEGIAMDOUONG"] = value; } }
        public decimal TILEGIAMDOKHAC { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMDOKHAC") ? ConvertTo.Decimal(Row["TILEGIAMDOKHAC"]) : 0; } set { this["TILEGIAMDOKHAC"] = value; } }
        public decimal TILEGIAMDICHVU { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMDICHVU") ? ConvertTo.Decimal(Row["TILEGIAMDICHVU"]) : 0; } set { this["TILEGIAMDICHVU"] = value; } }
        public decimal TILEGIAMGIA { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMGIA") ? ConvertTo.Decimal(Row["TILEGIAMGIA"]) : 0; } set { this["TILEGIAMGIA"] = value; } }
        public decimal TILEGIAMGIATIENHANG { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMGIATIENHANG") ? ConvertTo.Decimal(Row["TILEGIAMGIATIENHANG"]) : 0; } set { this["TILEGIAMGIATIENHANG"] = value; } }
        public decimal TILEGIAMGIATIENGIO { get { return Row != null && Row.Table.Columns.Contains("TILEGIAMGIATIENGIO") ? ConvertTo.Decimal(Row["TILEGIAMGIATIENGIO"]) : 0; } set { this["TILEGIAMGIATIENGIO"] = value; } }
        public DNHOMKHACHHANGRow() { }
        public DNHOMKHACHHANGRow(DataRow r) { this.Row = r; }
        public DNHOMKHACHHANGRow(string id)
        {
            try { this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM DNHOMKHACHHANG WHERE ID = '{0}'", id)); } catch { }
        }
        public object this[string col]
        {
            get { return Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value; }
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public class ChiTietTinhGiaGio
    {
        public string Ban { get; set; }
        public int SoNgay { get; set; }
        public int SoGio { get; set; }
        public int SoPhut { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public object TuGio { get; set; }
        public object DenGio { get; set; }
    }

    public class TDONHANGGIORow
    {
        public DataRow Row { get; set; }
        public TDONHANGGIORow()
        {
            try
            {
                DataTable dt = Config.Db.GetTable("SELECT FIRST 0 * FROM TDONHANGGIO");
                this.Row = dt.NewRow();
                this.Row["ID"] = Guid.NewGuid().ToString();
                dt.Rows.Add(this.Row);
            }
            catch
            {
                DataTable dt = new DataTable();
                this.Row = dt.NewRow();
            }
        }
        public TDONHANGGIORow(DataRow r) { this.Row = r; }
        public string ID { get { return this["ID"]?.ToString() ?? ""; } set { this["ID"] = value; } }
        public string TDONHANGID { get { return this["TDONHANGID"]?.ToString() ?? ""; } set { this["TDONHANGID"] = value; } }
        public string DBANID { get { return this["DBANID"]?.ToString() ?? ""; } set { this["DBANID"] = value; } }
        public int CACHTINHGIA { get { return ConvertTo.Int(this["CACHTINHGIA"]); } set { this["CACHTINHGIA"] = value; } }
        public string DBANGGIAID { get { return this["DBANGGIAID"]?.ToString() ?? ""; } set { this["DBANGGIAID"] = value; } }
        public decimal DONGIA { get { return ConvertTo.Decimal(this["DONGIA"]); } set { this["DONGIA"] = value; } }
        public decimal THANHTIEN { get { return ConvertTo.Decimal(this["THANHTIEN"]); } set { this["THANHTIEN"] = value; } }
        public DateTime TUGIO { get { return ConvertTo.Date(this["TUGIO"]); } set { this["TUGIO"] = value; } }
        public DateTime DENGIO { get { return ConvertTo.Date(this["DENGIO"]); } set { this["DENGIO"] = value; } }
        public string NOTE { get { return this["NOTE"]?.ToString() ?? ""; } set { this["NOTE"] = value; } }
        public void Update(Database db = null)
        {
            try
            {
                if (Row != null && Row.Table != null)
                {
                    (db ?? Config.Db).UpdateDataRow(this.Row, "TDONHANGGIO");
                }
            }
            catch { }
        }
        public object this[string col]
        {
            get { return Row != null && Row.Table != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value; }
            set
            {
                if (Row != null)
                {
                    if (Row.Table != null && !Row.Table.Columns.Contains(col))
                        Row.Table.Columns.Add(col, typeof(object));
                    if (Row.Table != null && Row.Table.Columns.Contains(col))
                        Row[col] = value ?? DBNull.Value;
                }
            }
        }
    }

    public class DummyLookup
    {
        public object EditValue { get; set; }
    }
    public class DummySpin
    {
        public decimal Value { get; set; }
    }

    public class TTHUCHI1Ae
    {
        public TextBox txtDIENGIAI = new TextBox();
        public CheckBox chkKHONGTHAYDOICONGNO = new CheckBox();
        public DummyLookup lueDKHACHHANGID = new DummyLookup();
        public DummySpin numCHI = new DummySpin();
    }

    public class TLUUVETRow
    {
        public DataRow Row { get; set; }
        public DateTime GIO { get { return Row != null && Row.Table.Columns.Contains("GIO") ? ConvertTo.Date(Row["GIO"]) : DateTime.MinValue; } set { this["GIO"] = value; } }
        public int PHANLOAI { get { return Row != null && Row.Table.Columns.Contains("PHANLOAI") ? ConvertTo.Int(Row["PHANLOAI"]) : 0; } set { this["PHANLOAI"] = value; } }
        public string BAN { get { return Row != null && Row.Table.Columns.Contains("BAN") ? Row["BAN"].ToString() : ""; } set { this["BAN"] = value; } }
        public string SODONHANG { get { return Row != null && Row.Table.Columns.Contains("SODONHANG") ? Row["SODONHANG"].ToString() : ""; } set { this["SODONHANG"] = value; } }
        public string TAIKHOAN { get { return Row != null && Row.Table.Columns.Contains("TAIKHOAN") ? Row["TAIKHOAN"].ToString() : ""; } set { this["TAIKHOAN"] = value; } }
        public string THIETBI { get { return Row != null && Row.Table.Columns.Contains("THIETBI") ? Row["THIETBI"].ToString() : ""; } set { this["THIETBI"] = value; } }
        public DateTime NGAY { get { return Row != null && Row.Table.Columns.Contains("NGAY") ? ConvertTo.Date(Row["NGAY"]) : DateTime.MinValue; } set { this["NGAY"] = value; } }
        public string NOTE { get { return Row != null && Row.Table.Columns.Contains("NOTE") ? Row["NOTE"].ToString() : ""; } set { this["NOTE"] = value; } }
        public string CHUCNANG { get { return Row != null && Row.Table.Columns.Contains("CHUCNANG") ? Row["CHUCNANG"].ToString() : ""; } set { this["CHUCNANG"] = value; } }
        public decimal SOLUONG { get { return Row != null && Row.Table.Columns.Contains("SOLUONG") ? ConvertTo.Decimal(Row["SOLUONG"]) : 0; } set { this["SOLUONG"] = value; } }
        public decimal DONGIA { get { return Row != null && Row.Table.Columns.Contains("DONGIA") ? ConvertTo.Decimal(Row["DONGIA"]) : 0; } set { this["DONGIA"] = value; } }
        public string TENHANG { get { return Row != null && Row.Table.Columns.Contains("TENHANG") ? Row["TENHANG"].ToString() : ""; } set { this["TENHANG"] = value; } }
        public decimal THANHTIEN { get { return Row != null && Row.Table.Columns.Contains("THANHTIEN") ? ConvertTo.Decimal(Row["THANHTIEN"]) : 0; } set { this["THANHTIEN"] = value; } }
        public TLUUVETRow() { }
        public TLUUVETRow(DataRow r) { this.Row = r; }
        public void Update(Database db = null) { try { (db ?? Config.Db).UpdateDataRow(this.Row, "TLUUVET"); } catch { } }
        public object this[string col]
        {
            get { return Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value; }
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public class TSOHOADONRow
    {
        public DataRow Row { get; set; }
        public DateTime NGAY { get { return Row != null && Row.Table.Columns.Contains("NGAY") ? ConvertTo.Date(Row["NGAY"]) : DateTime.MinValue; } set { this["NGAY"] = value; } }
        public int SO { get { return Row != null && Row.Table.Columns.Contains("SO") ? ConvertTo.Int(Row["SO"]) : 0; } set { this["SO"] = value; } }
        public string NAME { get { return Row != null && Row.Table.Columns.Contains("NAME") ? Row["NAME"].ToString() : ""; } set { this["NAME"] = value; } }
        public TSOHOADONRow() { }
        public TSOHOADONRow(DataRow r) { this.Row = r; }
        public TSOHOADONRow(string id)
        {
            try
            {
                this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM TSOHOADON WHERE ID = '{0}'", id));
            }
            catch { }
        }
        public void Update(Database db = null, string userId = null) { try { (db ?? Config.Db).UpdateDataRow(this.Row, "TSOHOADON"); } catch { } }
        public object this[string col]
        {
            get { return Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value; }
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public enum InTheoKhuVuc
    {
        InTaiQuay = 0,
        InTheoKhuVuc = 1,
        InTamTinhTheoKhuVucInHoaDonTaiQuay = 2,
        InMotLienTaiQuayMotLienTheoKhuVuc = 3
    }

    public enum SoHoaDonQuayVong
    {
        KhongQuayVong = 0,
        Ngay = 1,
        Thang = 2,
        Nam = 3
    }

    public enum NgayGiaoDichMode
    {
        TheoNgayHienTai = 0,
        TheoNgayMoBan = 1
    }

    public enum UngDung
    {
        NhaHang = 0,
        Karaoke = 1,
        Billiards = 2,
        Cafe = 3,
        SPA = 4,
        KARAOKE = 1,
        NHAHANG = 0
    }

    public class Config : No1Lib.Sys.Config
    {
        public new static object CreateForm(string formId)
        {
            if (formId == Forms.TDONHANG0Ae || formId == "f3f7bb77-f4ba-4111-9066-014f52be79a0")
                return new TDONHANG0Ae();
            if (formId == Forms.KhuVucControl || formId == "f842ff6f-80e3-46ab-bf04-7dda627513d1")
                return new KhuVucControl();
            if (formId == Forms.SuDungDichVu || formId == "141ca9a1-6819-49e2-b8a6-c1ac806ef0a9")
                return new SuDungDichVu();
            try
            {
                object result = No1Lib.Sys.Config.CreateForm(formId);
                if (result != null) return result;
            }
            catch { }

            if (formId == Forms.XacNhanThanhToan) return new XacNhanThanhToan();
            if (formId == Forms.InCheBien) return new InCheBien();
            if (formId == Forms.DoiGiaBan) return new DoiGiaBan();
            if (formId == Forms.DatGhiChu) return new DatGhiChu();
            if (formId == Forms.DatGiamGia) return new DatGiamGia();
            if (formId == Forms.ThemMatHangMo) return new ThemMatHangMo();
            if (formId == Forms.TraDo) return new TraDo();
            if (formId == Forms.NhapLyDo) return new NhapLyDo();
            if (formId == Forms.NhapSoLuongNhaHang) return new NhapSoLuongNhaHang();
            if (formId == Forms.ChuyenBan || formId == "fa056d74-4455-6677-8899-aabbccddeeff") return new ChuyenBan();
            if (formId == Forms.GiamGiaTheoNhom || formId == "cd3890a7-7788-99aa-bbcc-ddeeff001122" || formId == "db13cbad-8ba5-4d23-8f8a-5128a14e5d03") return new GiamGiaTheoNhom();
            if (formId == Forms.ThongKe || formId == "017234eb-bbcc-ddee-ff00-112233445566" || formId == "1f516fe7-3b71-4cbf-a3e8-61ad116bfa79") return new ThongKe();
            return null;
        }
    }

    public static class DBANInfo
    {
        public const string NAME = "NAME";
    }

    public static class TDONHANGCHITIETInfo
    {
        public const string DONGIA = "DONGIA";
        public const string THANHTIEN = "THANHTIEN";
    }

    public static class HoaDonBanHang
    {
        public static decimal GetNoCu(string dKhachHangId, string tDonHangId) { return 0; }
        public static decimal GetDiemTichLuyTrenHoaDon(string dKhachHangId) { return 0; }
    }
}

namespace No1Lib.Db
{
    public static class DatabaseExtensions
    {
        public static int UpdateDataRow(this Database db, System.Data.DataRow row, string tableName = null)
        {
            if (row == null || db == null) return 0;
            try
            {
                if (string.IsNullOrEmpty(tableName) || tableName.Equals("Table", StringComparison.OrdinalIgnoreCase))
                {
                    if (row.Table != null)
                    {
                        if (row.Table.Columns.Contains("DATHANHTOAN") && row.Table.Columns.Contains("TIENHANG")) tableName = "TDONHANG";
                        else if (row.Table.Columns.Contains("DLOAIPHONGID") || row.Table.Columns.Contains("DKHUVUCID")) tableName = "DBAN";
                        else if (row.Table.Columns.Contains("DNHOMKHACHHANGID")) tableName = "DKHACHHANG";
                        else if (row.Table.Columns.Contains("SLXUAT") && row.Table.Columns.Contains("TDONHANGID")) tableName = "TDONHANGCHITIET";
                        else if (row.Table.Columns.Contains("DMATHANGID") && row.Table.Columns.Contains("GIA")) tableName = "DBANGGIACHITIET";
                        else if (row.Table.Columns.Contains("DLOAIMATHANGID")) tableName = "DMATHANG";
                        else if (row.Table.Columns.Contains("PHANLOAI") && row.Table.Columns.Contains("TAIKHOAN")) tableName = "TLUUVET";
                        else if (row.Table.Columns.Contains("TUGIO") && row.Table.Columns.Contains("DENGIO")) tableName = "TDONHANGGIO";
                        else if (!string.IsNullOrEmpty(row.Table.TableName) && !row.Table.TableName.Equals("Table", StringComparison.OrdinalIgnoreCase)) tableName = row.Table.TableName;
                    }
                }
                if (string.IsNullOrEmpty(tableName)) return 0;

                string id = (row.Table != null && row.Table.Columns.Contains("ID")) ? (row["ID"]?.ToString() ?? "") : "";
                if (string.IsNullOrEmpty(id))
                {
                    id = Guid.NewGuid().ToString();
                    if (row.Table != null && row.Table.Columns.Contains("ID")) row["ID"] = id;
                }

                int count = db.GetFirstFieldInt(string.Format("SELECT COUNT(*) FROM {0} WHERE ID = '{1}'", tableName, id.Replace("'", "''")));
                if (count > 0)
                {
                    var sb = new System.Text.StringBuilder();
                    sb.AppendFormat("UPDATE {0} SET ", tableName);
                    var cmd = db.GetCommand("");
                    bool first = true;
                    foreach (System.Data.DataColumn col in row.Table.Columns)
                    {
                        if (col.ColumnName.Equals("ID", StringComparison.OrdinalIgnoreCase)) continue;
                        if (!first) sb.Append(", ");
                        first = false;
                        sb.AppendFormat("{0} = @{0}", col.ColumnName);
                        AddTypedParam(cmd, "@" + col.ColumnName, row[col]);
                    }
                    sb.AppendFormat(" WHERE ID = '{0}'", id.Replace("'", "''"));
                    cmd.CommandText = sb.ToString();
                    db.ExecSql(cmd);
                    return 1;
                }
                else
                {
                    var sbCols = new System.Text.StringBuilder();
                    var sbVals = new System.Text.StringBuilder();
                    var cmd = db.GetCommand("");
                    bool first = true;
                    foreach (System.Data.DataColumn col in row.Table.Columns)
                    {
                        if (!first) { sbCols.Append(", "); sbVals.Append(", "); }
                        first = false;
                        sbCols.Append(col.ColumnName);
                        sbVals.Append("@" + col.ColumnName);
                        AddTypedParam(cmd, "@" + col.ColumnName, row[col]);
                    }
                    cmd.CommandText = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, sbCols.ToString(), sbVals.ToString());
                    db.ExecSql(cmd);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateDataRow error: " + ex.Message);
                return 0;
            }
        }

        private static void AddTypedParam(FirebirdSql.Data.FirebirdClient.FbCommand cmd, string paramName, object val)
        {
            if (val == null || val == DBNull.Value)
            {
                cmd.Parameters.Add(paramName, FirebirdSql.Data.FirebirdClient.FbDbType.VarChar).Value = DBNull.Value;
            }
            else if (val is DateTime dt)
            {
                cmd.Parameters.Add(paramName, FirebirdSql.Data.FirebirdClient.FbDbType.TimeStamp).Value = dt;
            }
            else if (val is int || val is short || val is byte)
            {
                cmd.Parameters.Add(paramName, FirebirdSql.Data.FirebirdClient.FbDbType.Integer).Value = Convert.ToInt32(val);
            }
            else if (val is long)
            {
                cmd.Parameters.Add(paramName, FirebirdSql.Data.FirebirdClient.FbDbType.BigInt).Value = Convert.ToInt64(val);
            }
            else if (val is decimal || val is double || val is float)
            {
                cmd.Parameters.Add(paramName, FirebirdSql.Data.FirebirdClient.FbDbType.Decimal).Value = Convert.ToDecimal(val);
            }
            else if (val is byte[] bArr)
            {
                cmd.Parameters.Add(paramName, FirebirdSql.Data.FirebirdClient.FbDbType.Binary).Value = bArr;
            }
            else if (val is bool b)
            {
                cmd.Parameters.Add(paramName, FirebirdSql.Data.FirebirdClient.FbDbType.SmallInt).Value = b ? 1 : 0;
            }
            else
            {
                cmd.Parameters.Add(paramName, FirebirdSql.Data.FirebirdClient.FbDbType.VarChar).Value = val.ToString();
            }
        }
    }
}
