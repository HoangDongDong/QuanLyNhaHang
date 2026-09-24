using System;

namespace QuanLyNhaHang.Services
{
    /// <summary>
    /// Bridge class that maps original No1Lib.Sys.SystemConfig property names
    /// to GlobalConfig values loaded from SCONFIG table.
    /// 
    /// Convention: SCONFIG.STATUS = 30 means active.
    /// Values stored as INTVALUE = 30 typically mean "enabled/yes".
    /// </summary>
    public static class SystemConfig
    {
        // ═══════════════════════════════════════════════════════
        // GIAO DIỆN DỊCH VỤ (Service UI)
        // ═══════════════════════════════════════════════════════

        /// <summary>
        /// Kích thước hiển thị trên giao diện dịch vụ
        /// 0=Mặc định(64px), 1=Nhỏ(48px), 2=Rất nhỏ(32px), 3=Siêu nhỏ(24px)
        /// </summary>
        public static int KichThuocHienThiOGiaoDienDichVu
            => GlobalConfig.GetInt("KichThuocHienThiOGiaoDienDichVu", 0);

        /// <summary>
        /// Hiển thị ghi chú trên giao diện bàn (30 = có, khác = không)
        /// </summary>
        public static int HienThiGhiChuTrenGiaoDienBan
            => GlobalConfig.GetInt("HienThiGhiChuTrenGiaoDienBan", 0);

        /// <summary>
        /// Tên hiển thị cho phòng/bàn (mặc định = "bàn")
        /// </summary>
        public static string TenPhongBan
            => GlobalConfig.Get("TenPhongBan", "bàn");

        // ═══════════════════════════════════════════════════════
        // BÁN HÀNG / ORDER
        // ═══════════════════════════════════════════════════════

        /// <summary>
        /// Bắt buộc nhập nhân viên bán hàng khi mở bàn (30 = bắt buộc)
        /// </summary>
        public static int BatBuocNhapNhanVienBanHang
            => GlobalConfig.GetInt("BatBuocNhapNhanVienBanHang", 0);

        /// <summary>
        /// Có tính tiền theo giờ không (30 = có)
        /// </summary>
        public static bool CoTienGio
            => GlobalConfig.GetInt("CoTienGio", 0) == 30;

        /// <summary>
        /// Có chức năng ngắt giờ không (30 = có)
        /// </summary>
        public static bool CoNgatGio
            => GlobalConfig.GetInt("CoNgatGio", 0) == 30;

        /// <summary>
        /// Số lượng chi tiết hóa đơn tối đa hiển thị
        /// </summary>
        public static int SoLuongChiTietHoaDon
            => GlobalConfig.GetInt("SoLuongChiTietHoaDon", 50);

        /// <summary>
        /// Có cho phép sửa đơn giá khi bán không (30 = có)
        /// </summary>
        public static bool ChoPhepSuaDonGia
            => GlobalConfig.GetInt("ChoPhepSuaDonGia", 0) == 30;

        /// <summary>
        /// Có cho phép chiết khấu không (30 = có)
        /// </summary>
        public static bool ChoPhepChietKhau
            => GlobalConfig.GetInt("ChoPhepChietKhau", 0) == 30;

        /// <summary>
        /// Tự động in hóa đơn sau khi thanh toán (30 = có)
        /// </summary>
        public static bool TuDongInHoaDon
            => GlobalConfig.GetInt("TuDongInHoaDon", 0) == 30;

        /// <summary>
        /// Nhập lý do khi hủy hóa đơn (30 = có)
        /// </summary>
        public static int NhapLyDoKhiHuyHoaDon
            => GlobalConfig.GetInt("NhapLyDoKhiHuyHoaDon", 30);

        /// <summary>
        /// Thời gian cho phép hủy bill (phút)
        /// </summary>
        public static int ThoiGianChoPhepHuyBill
            => GlobalConfig.GetInt("ThoiGianChoPhepHuyBill", 60);

        /// <summary>
        /// Giá bán lẻ USD (30 = 2 số lẻ, khác = 0 số lẻ)
        /// </summary>
        public static int GiaBanLeUsd
            => GlobalConfig.GetInt("GiaBanLeUsd", 0);

        /// <summary>
        /// Có thanh toán qua thẻ không (30 = có)
        /// </summary>
        public static int CoThanhToanThe
            => GlobalConfig.GetInt("CoThanhToanThe", 30);

        /// <summary>
        /// Có thanh toán chuyển khoản không (30 = có)
        /// </summary>
        public static int CoThanhToanChuyenKhoan
            => GlobalConfig.GetInt("CoThanhToanChuyenKhoan", 30);

        /// <summary>
        /// Có thanh toán voucher không (30 = có)
        /// </summary>
        public static int CoThanhToanVoucher
            => GlobalConfig.GetInt("CoThanhToanVoucher", 30);

        /// <summary>
        /// Sử dụng thẻ trả trước để thanh toán (30 = có)
        /// </summary>
        public static int SuDungTheTraTruoc
            => GlobalConfig.GetInt("SuDungTheTraTruoc", 30);

        /// <summary>
        /// Sử dụng điểm tích lũy để thanh toán (30 = có)
        /// </summary>
        public static int SuDungDiemTichLuyDeThanhToan
            => GlobalConfig.GetInt("SuDungDiemTichLuyDeThanhToan", 30);

        /// <summary>
        /// Cho phép in tạm tính (30 = có)
        /// </summary>
        public static int ChoPhepInTamTinh
            => GlobalConfig.GetInt("ChoPhepInTamTinh", 30);

        /// <summary>
        /// Lựa chọn voucher từ danh sách (30 = có)
        /// </summary>
        public static int LuaChonVoucherTuDanhSach
            => GlobalConfig.GetInt("LuaChonVoucherTuDanhSach", 0);

        /// <summary>
        /// Cho phép khách nợ (30 = có)
        /// </summary>
        public static int ChoPhepKhachNo
            => GlobalConfig.GetInt("ChoPhepKhachNo", 30);

        // ═══════════════════════════════════════════════════════
        // IN ẤN / PRINTING
        // ═══════════════════════════════════════════════════════

        /// <summary>
        /// Mẫu hóa đơn (tên template report)
        /// </summary>
        public static string MauHoaDon
            => GlobalConfig.Get("MauHoaDon", "");

        /// <summary>
        /// Mẫu in chế biến
        /// </summary>
        public static string MauInCheBien
            => GlobalConfig.Get("MauInCheBien", "");

        /// <summary>
        /// Mẫu in chuyển bàn
        /// </summary>
        public static string MauInChuyenBan
            => GlobalConfig.Get("MauInChuyenBan", "");

        /// <summary>
        /// In thông báo khi chuyển bàn (30 = có, 0 = không)
        /// </summary>
        public static int InThongBaoKhiChuyenBan
            => GlobalConfig.GetInt("InThongBaoKhiChuyenBan", 0);

        // ═══════════════════════════════════════════════════════
        // THÔNG TIN CỬA HÀNG
        // ═══════════════════════════════════════════════════════

        /// <summary>
        /// Tên cửa hàng / nhà hàng
        /// </summary>
        public static string TenCuaHang
            => GlobalConfig.Get("TenCuaHang", "");

        /// <summary>
        /// Địa chỉ cửa hàng
        /// </summary>
        public static string DiaChi
            => GlobalConfig.Get("DiaChi", "");

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public static string DienThoai
            => GlobalConfig.Get("DienThoai", "");

        // ═══════════════════════════════════════════════════════
        // TỒN KHO
        // ═══════════════════════════════════════════════════════

        /// <summary>
        /// Cho phép tồn kho âm (30 = cho phép)
        /// </summary>
        public static bool ChoPhepTonKhoAm
            => GlobalConfig.GetInt("ChoPhepTonKhoAm", 0) == 30;

        /// <summary>
        /// Tự động cập nhật giá nhập hàng (30 = có)
        /// </summary>
        public static bool TuDongCapNhatGiaNhap
            => GlobalConfig.GetInt("TuDongCapNhatGiaNhap", 0) == 30;

        // ═══════════════════════════════════════════════════════
        // HELPER METHODS
        // ═══════════════════════════════════════════════════════

        /// <summary>
        /// Get tên phòng/bàn (trả về "bàn" hoặc tên tùy chỉnh).
        /// Matches Shared.GetTenPhongBan() from original code.
        /// </summary>
        /// <param name="lowercase">Nếu true trả về chữ thường</param>
        public static string GetTenPhongBan(bool lowercase = false)
        {
            string name = TenPhongBan;
            if (string.IsNullOrEmpty(name)) name = "bàn";
            return lowercase ? name.ToLower() : name;
        }

        /// <summary>
        /// Kích thước button bàn (pixel width) tùy theo cấu hình
        /// </summary>
        public static int GetTableButtonWidth()
        {
            switch (KichThuocHienThiOGiaoDienDichVu)
            {
                case 1: return 80;   // Nhỏ
                case 2: return 64;   // Rất nhỏ
                case 3: return 48;   // Siêu nhỏ
                default: return 100; // Mặc định
            }
        }

        /// <summary>
        /// Kích thước button bàn (pixel height)
        /// </summary>
        public static int GetTableButtonHeight()
        {
            switch (KichThuocHienThiOGiaoDienDichVu)
            {
                case 1: return 60;
                case 2: return 48;
                case 3: return 36;
                default: return 80;
            }
        }

        /// <summary>
        /// Check if a config is "active" (value = 30 in No1 convention)
        /// </summary>
        public static bool IsActive(string configKey)
        {
            return GlobalConfig.GetInt(configKey, 0) == 30;
        }

        /// <summary>
        /// Get any config value by key (raw string)
        /// </summary>
        public static string GetValue(string key, string defaultValue = "")
        {
            return GlobalConfig.Get(key, defaultValue);
        }

        /// <summary>
        /// Get any config value by key (as integer)
        /// </summary>
        public static int GetIntValue(string key, int defaultValue = 0)
        {
            return GlobalConfig.GetInt(key, defaultValue);
        }

        // ═══════════════════════════════════════════════════════
        // IN BẾP / PHA CHẾ / CHẾ BIẾN
        // ═══════════════════════════════════════════════════════

        public static int InDoAn => GlobalConfig.GetInt("InDoAn", 30);
        public static int InDoUong => GlobalConfig.GetInt("InDoUong", 30);
        public static int InDoKhac => GlobalConfig.GetInt("InDoKhac", 30);
        public static int InDichVu => GlobalConfig.GetInt("InDichVu", 30);
        public static int InRiengDoAnUong => GlobalConfig.GetInt("InRiengDoAnUong", 0);
        public static int InPhaCheTheoKhuVuc => GlobalConfig.GetInt("InPhaCheTheoKhuVuc", 0);
        public static int LuuVetInCheBien => GlobalConfig.GetInt("LuuVetInCheBien", 0);
        public static int SoLienInCheBien => GlobalConfig.GetInt("SoLienInCheBien", 1);
        public static int InMoiDoRa1To => GlobalConfig.GetInt("InMoiDoRa1To", 0);
        public static int InThem1LienTaiQuay => GlobalConfig.GetInt("InThem1LienTaiQuay", 0);

        // ═══════════════════════════════════════════════════════
        // BÁN HÀNG / HÓA ĐƠN NHÀ HÀNG (TDONHANG0Ae)
        // ═══════════════════════════════════════════════════════
        public static int BanHangDungDauDocMaVach => GlobalConfig.GetInt("BanHangDungDauDocMaVach", 0);
        public static int BatBuocInKhiThanhToan => GlobalConfig.GetInt("BatBuocInKhiThanhToan", 0);
        public static int BatChucNangKiemSoatOrder => GlobalConfig.GetInt("BatChucNangKiemSoatOrder", 0);
        public static int BaudRate => GlobalConfig.GetInt("BaudRate", 9600);
        public static int CachChonGioTinhGia => GlobalConfig.GetInt("CachChonGioTinhGia", 0);
        public static int CachChonKhachHang => GlobalConfig.GetInt("CachChonKhachHang", 0);
        public static int CachLamTronDichVuTheoGio => GlobalConfig.GetInt("CachLamTronDichVuTheoGio", 0);
        public static int CachTinhDiem => GlobalConfig.GetInt("CachTinhDiem", 0);
        public static int ChoPhepDoiGioRaVeSau => GlobalConfig.GetInt("ChoPhepDoiGioRaVeSau", 0);
        public static int ChoPhepDoiGioTrenBill => GlobalConfig.GetInt("ChoPhepDoiGioTrenBill", 30);
        public static int ChoPhepDoiGioVaoVeTruoc => GlobalConfig.GetInt("ChoPhepDoiGioVaoVeTruoc", 0);
        public static int ChoPhepDungNhieuBangGiaTrenBill => GlobalConfig.GetInt("ChoPhepDungNhieuBangGiaTrenBill", 0);
        public static int ChoPhepNhapGiamGia => GlobalConfig.GetInt("ChoPhepNhapGiamGia", 30);
        public static int ChoPhepThayDoiNgayTrenHoaDon => GlobalConfig.GetInt("ChoPhepThayDoiNgayTrenHoaDon", 0);
        public static int CoCayHienThiGia => GlobalConfig.GetInt("CoCayHienThiGia", 0);
        public static int CoPhiDichVu => GlobalConfig.GetInt("CoPhiDichVu", 0);
        public static int CoThueSuat => GlobalConfig.GetInt("CoThueSuat", 0);
        public static string CongCom => GlobalConfig.Get("CongCom", "COM1");
        public static string CongSuDung => GlobalConfig.Get("CongSuDung", "COM1");
        public static int Databit => GlobalConfig.GetInt("Databit", 8);
        public static int DoDai => GlobalConfig.GetInt("DoDai", 0);
        public static decimal DoanhSoTuongUngVoi1Diem => Convert.ToDecimal(GlobalConfig.GetInt("DoanhSoTuongUngVoi1Diem", 10000));
        public static int DungThoiGianKhiInTamTinh => GlobalConfig.GetInt("DungThoiGianKhiInTamTinh", 0);
        public static int GiuNguyenGiaoDienNhuThietKe => GlobalConfig.GetInt("GiuNguyenGiaoDienNhuThietKe", 0);
        public static int GopChungGiamGiaTienGioVaTienHangLamMot => GlobalConfig.GetInt("GopChungGiamGiaTienGioVaTienHangLamMot", 0);
        public static int HeThongChayNhieuMayTram => GlobalConfig.GetInt("HeThongChayNhieuMayTram", 0);
        public static int PhanQuyenTruyCapTheoKhuVuc => GlobalConfig.GetInt("PhanQuyenTruyCapTheoKhuVuc", 0);
        public static int HienThi3NhomOGiaoDienBanHang => GlobalConfig.GetInt("HienThi3NhomOGiaoDienBanHang", 0);
        public static int HienThiCuaSoNhapSoLuongKhiQuetMaVach => GlobalConfig.GetInt("HienThiCuaSoNhapSoLuongKhiQuetMaVach", 0);
        public static int HienThiTruocKhiIn => GlobalConfig.GetInt("HienThiTruocKhiIn", 0);
        public static int InChiTietTheoTungKhoangGio => GlobalConfig.GetInt("InChiTietTheoTungKhoangGio", 0);
        public static int InHoaDonCongGopMatHang => GlobalConfig.GetInt("InHoaDonCongGopMatHang", 0);
        public static int InHoaDonTheoKhuVuc => GlobalConfig.GetInt("InHoaDonTheoKhuVuc", 0);
        public static int InMatKhauWifiTrenBill => GlobalConfig.GetInt("InMatKhauWifiTrenBill", 0);
        public static int KhongDuocGiamDoSauKhiInPhaChe => GlobalConfig.GetInt("KhongDuocGiamDoSauKhiInPhaChe", 0);
        public static int KichHoatChucNangKiemDo => GlobalConfig.GetInt("KichHoatChucNangKiemDo", 0);
        public static int KichHoatKhuyenMaiTuDong => GlobalConfig.GetInt("KichHoatKhuyenMaiTuDong", 0);
        public static int KichHoatLuuVetHoatDong => GlobalConfig.GetInt("KichHoatLuuVetHoatDong", 0);
        public static int KichHoatSuDungCanDienTu => GlobalConfig.GetInt("KichHoatSuDungCanDienTu", 0);
        public static int LamTronMatHangDichVuTheoGio => GlobalConfig.GetInt("LamTronMatHangDichVuTheoGio", 0);
        public static int LamTronTien => GlobalConfig.GetInt("LamTronTien", 0);
        public static int LuaChonMauKhiIn => GlobalConfig.GetInt("LuaChonMauKhiIn", 0);
        public static decimal MacDinhGiamGia => Convert.ToDecimal(GlobalConfig.GetInt("MacDinhGiamGia", 0));
        public static decimal MacDinhGiamGiaTienGio => Convert.ToDecimal(GlobalConfig.GetInt("MacDinhGiamGiaTienGio", 0));
        public static decimal MacDinhPhiDichVu => Convert.ToDecimal(GlobalConfig.GetInt("MacDinhPhiDichVu", 0));
        public static decimal MacDinhThueSuat => Convert.ToDecimal(GlobalConfig.GetInt("MacDinhThueSuat", 0));
        public static int NhapLyDoKhiXoaMon => GlobalConfig.GetInt("NhapLyDoKhiXoaMon", 0);
        public static int NhapMatKhauGiamDo => GlobalConfig.GetInt("NhapMatKhauGiamDo", 0);
        public static int NhapMotMatHangNhieuLanTrongPhieu => GlobalConfig.GetInt("NhapMotMatHangNhieuLanTrongPhieu", 0);
        public static int Parity => GlobalConfig.GetInt("Parity", 0);
        public static decimal QuyDoi1DiemSangTien => Convert.ToDecimal(GlobalConfig.GetInt("QuyDoi1DiemSangTien", 1000));
        public static int SoLanIn => GlobalConfig.GetInt("SoLanIn", 1);
        public static int SoLanInTamTinhToiDa => GlobalConfig.GetInt("SoLanInTamTinhToiDa", 5);
        public static int SoLanInToiDa => GlobalConfig.GetInt("SoLanInToiDa", 5);
        public static int SoPhutToiDaChoPhepDung => GlobalConfig.GetInt("SoPhutToiDaChoPhepDung", 0);
        public static int StopBits => GlobalConfig.GetInt("StopBits", 1);
        public static int SuDungChucNangInXuongBep => GlobalConfig.GetInt("SuDungChucNangInXuongBep", 30);
        public static int SuDungChucNangTamUngTrongDonHang => GlobalConfig.GetInt("SuDungChucNangTamUngTrongDonHang", 0);
        public static int SuDungGia2 => GlobalConfig.GetInt("SuDungGia2", 0);
        public static int SuDungGia3 => GlobalConfig.GetInt("SuDungGia3", 0);
        public static int SuDungGia4 => GlobalConfig.GetInt("SuDungGia4", 0);
        public static int SuDungGiaTheoGio => GlobalConfig.GetInt("SuDungGiaTheoGio", 0);
        public static int SuDungMatHangMacDinh => GlobalConfig.GetInt("SuDungMatHangMacDinh", 0);
        public static int ThoiGianTuDongIn => GlobalConfig.GetInt("ThoiGianTuDongIn", 0);
        public static int Timeout => GlobalConfig.GetInt("Timeout", 1000);
        public static int ToiUuDungBanPhim => GlobalConfig.GetInt("ToiUuDungBanPhim", 0);
        public static int TuDongDoiGioRaVeSau => GlobalConfig.GetInt("TuDongDoiGioRaVeSau", 0);
        public static int TuDongDoiGioVaoVeTruoc => GlobalConfig.GetInt("TuDongDoiGioVaoVeTruoc", 0);
        public static int TuDongInPhaCheSauKhiGoiMon => GlobalConfig.GetInt("TuDongInPhaCheSauKhiGoiMon", 0);
        public static int TuDongNangCapThanhVienKhiDatHanMuc => GlobalConfig.GetInt("TuDongNangCapThanhVienKhiDatHanMuc", 0);
        public static int ViTri => GlobalConfig.GetInt("ViTri", 0);
        public static int SoHoaDonQuayVong => GlobalConfig.GetInt("SoHoaDonQuayVong", 0);
    }
}
