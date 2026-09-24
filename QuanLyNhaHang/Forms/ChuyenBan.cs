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
using ComponentFactory.Krypton.Navigator;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Forms;
using KhuVucControl = QuanLyNhaHang.Forms.KhuVucControl;
using Tables = QuanLyNhaHang.Forms.Tables;
using Forms = QuanLyNhaHang.Forms.Forms;

namespace No1Run
{
    public partial class ChuyenBan : No1Form
    {
        public No1Form No1Form1 => this;
        string DKHUVUCID = "";
        string TDONHANGID = "";
        ChuyenGopBanMode chuyenGopMode;
        public decimal SoLuongChuyen { get; set; } = -1;
        private string DBANID = "";

        public ChuyenBan()
        {
            InitializeComponent();
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.tabKhuVuc.SelectedPageChanged += new EventHandler(tabKhuVuc_SelectedPageChanged);
            this.tabKhuVuc2.SelectedPageChanged += new EventHandler(tabKhuVuc_SelectedPageChanged);
        }

        public void SetData(string TDONHANGID, ChuyenGopBanMode chuyenGopMode)
        {
            this.TDONHANGID = TDONHANGID ?? "";
            this.chuyenGopMode = chuyenGopMode;

            try
            {
                SuDungDichVu.LoadKhuVuc(tabKhuVuc, 0, AddKhuVuc);
                SuDungDichVu.LoadKhuVuc(tabKhuVuc2, 1, AddKhuVuc);
                if (tabKhuVuc2.Pages.Count == 0)
                {
                    splitKhuVuc.Panel2Collapsed = true;
                }
                else
                {
                    splitKhuVuc.Panel2Collapsed = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadKhuVuc error: " + ex.Message);
            }

            if (chuyenGopMode == ChuyenGopBanMode.ChuyenMatHang)
            {
                lblTenBan.Text = "";
                lblTitle.Text = "Chuyển mặt hàng";
                this.Text = "Chuyển mặt hàng";
            }
            else if (chuyenGopMode == ChuyenGopBanMode.ChuyenBan)
            {
                lblTitle.Text = "Chuyển " + Shared.GetTenPhongBan(true);
                this.Text = lblTitle.Text;
            }
            else if (chuyenGopMode == ChuyenGopBanMode.GopBan)
            {
                lblTitle.Text = "Gộp " + Shared.GetTenPhongBan(true);
                this.Text = lblTitle.Text;
            }

            // Hiển thị tên bàn nguồn
            try
            {
                string banId = Config.Db.GetFirstFieldString("SELECT DBANID FROM TDONHANG WHERE ID = '" + this.TDONHANGID + "'");
                if (!string.IsNullOrEmpty(banId))
                {
                    string tenBan = Config.Db.GetFirstFieldString("SELECT NAME FROM DBAN WHERE ID = '" + banId + "'");
                    if (!string.IsNullOrEmpty(tenBan))
                    {
                        lblTenBan.Text = tenBan;
                    }
                }
            }
            catch { }
        }

        private void AddKhuVuc(KhuVucControl lst)
        {
            if (lst == null) return;
            lst.SetChuyenBan();
            if (lst.lst != null)
            {
                lst.lst.SelectedIndexChanged += new EventHandler(lst_SelectedIndexChanged);
                lst.lst.MouseClick += new MouseEventHandler(lst_MouseClick);
                lst.lst.MouseDoubleClick += new MouseEventHandler(lst_MouseDoubleClick);
            }
        }

        void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            BanItem itm = (lv != null && lv.SelectedItems.Count > 0 ? lv.SelectedItems[0] as BanItem : null) ?? (lv != null ? lv.FocusedItem as BanItem : null);
            if (itm == null)
            {
                DBANID = "";
            }
            else
            {
                DBANID = itm.ID ?? "";
            }

            btnOK.Enabled = DBANID.Length > 0;
        }

        void lst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectItem(sender, e);
            if (btnOK.Enabled) btnOK.PerformClick();
        }

        void lst_MouseClick(object sender, MouseEventArgs e)
        {
            SelectItem(sender, e);
        }

        private void SelectItem(object sender, MouseEventArgs e)
        {
            ListView lst = sender as ListView;
            if (lst == null) return;
            BanItem itm = lst.GetItemAt(e.X, e.Y) as BanItem;
            if (itm == null)
            {
                DBANID = "";
            }
            else
            {
                DBANID = itm.ID ?? "";
            }

            btnOK.Enabled = DBANID.Length > 0;
        }

        internal static void GetCachTinh(DBANRow banRow, out decimal donGia, out string DBANGGIAID)
        {
            CachTinhGiaGio cachTinh1 = (CachTinhGiaGio)banRow.CACHTINHGIO;
            DBANGGIAID = "";
            donGia = 0;
            switch (cachTinh1)
            {
                case CachTinhGiaGio.THEOKHUVUC:
                    DKHUVUCRow kvOld = new DKHUVUCRow(banRow.DKHUVUCID);
                    cachTinh1 = (CachTinhGiaGio)kvOld.CACHTINHGIO;
                    if (cachTinh1 == CachTinhGiaGio.THEOBANGGIA)
                    {
                        DBANGGIAID = kvOld.DBANGGIAID;
                    }
                    else
                    {
                        donGia = kvOld.DONGIA;
                    }
                    break;
                case CachTinhGiaGio.THEOBANGGIA:
                    DBANGGIAID = banRow.DBANGGIAID;
                    break;
                case CachTinhGiaGio.THEOGIO:
                    donGia = banRow.DONGIA;
                    break;
            }
        }

        internal static bool CungCachTinhGio(DBANRow banOld, DBANRow banNew)
        {
            string DBANGGIAOldID, DBANGGIANewID;
            decimal donGiaOld, donGiaNew;
            GetCachTinh(banOld, out donGiaOld, out DBANGGIAOldID);
            GetCachTinh(banNew, out donGiaNew, out DBANGGIANewID);
            return (donGiaOld == donGiaNew && DBANGGIAOldID == DBANGGIANewID);
        }

        public static bool ChuyenGopBan(string TDONHANGID, string DBANID)
        {
            //kiểm tra đơn hàng cũ đã thanh toán chưa
            TDONHANGRow dhRow = new TDONHANGRow(TDONHANGID);
            if (dhRow.SOLANINTAMTINH > 0)
            {
                Msg.ShowWarning("Bàn này đã in tạm tính, không thể thay đổi");
                return false;
            }

            //bỏ qua nếu thanh toán rồi
            if (dhRow.DATHANHTOAN != 0)
            {
                Msg.ShowWarning("Bàn này đã thanh toán, không thể thay đổi");
                return false;
            }
            //kiểm tra xem bàn đang gộp có trùng với bàn đang có sẵn trên bill không?
            if (dhRow.DBANID == DBANID)
            {
                Msg.ShowWarning(string.Format("Mời bạn chọn {0} khác", Shared.GetTenPhongBan(true)));
                return false;
            }

            //lấy đơn hàng trên bàn mới
            string TDONHANGMOIID = GetDonHangIDByBanID(DBANID);
            //kiểm tra xem có trùng với đơn hàng cũ không?
            if (TDONHANGMOIID == TDONHANGID)
            {
                Msg.ShowWarning(string.Format("Mời bạn chọn {0} khác!", Shared.GetTenPhongBan(true)));
                return false;
            }

            //kiểm tra bàn này có bị giữ không?
            if (SystemConfig.HeThongChayNhieuMayTram == 30)
            {
                string TaiKhoanGiu = "";
                if (SuDungDichVu.BanDangBiGiu(DBANID, ref TaiKhoanGiu))
                {
                    Msg.ShowWarning(string.Format("{2} {0} đang bị giữ bởi {1}", new DBANRow(DBANID).NAME, TaiKhoanGiu, Shared.GetTenPhongBan(false)));
                    return false;
                }
            }

            if (TDONHANGMOIID.Length == 0)
            {
                if (!DbUtils.CanLogin(Functions.ChuyenBan)) return false;
                return ThucHienChuyenBan(dhRow, DBANID);
            }
            else
            {
                if (!DbUtils.CanLogin(Functions.GopBan)) return false;
                return ThucHienGopBan(dhRow, new TDONHANGRow(TDONHANGMOIID));
            }
        }

        private static bool ThucHienGopBan(TDONHANGRow tuDonHang, TDONHANGRow denDonHang)
        {
            if (denDonHang.SOLANINTAMTINH > 0)
            {
                Msg.ShowWarning("Không thể gộp bàn vì bàn đã in tạm tính");
                return false;
            }

            string denBan = new DBANRow(denDonHang.DBANID).NAME;
            string tuBan = new DBANRow(tuDonHang.DBANID).NAME;

            //kiểm tra xem phòng mới gộp có tiền giờ không?
            if (tuDonHang.TIENGIO > 0)
            {
                Msg.ShowWarning("Không thể gộp '" + denBan + "' với '" + tuBan + "' vì '" + tuBan + "' có tiền giờ '" + tuDonHang.TIENGIO.ToString("n0") + "'");
                return false;
            }

            //kiểm tra bàn cũ có từ đặt hàng không?
            if (tuDonHang.TDATHANGID.Length > 0)
            {
                string oldName = new DBANRow(tuDonHang.DBANID).NAME;
                Msg.ShowWarning(string.Format("Hóa đơn ở {1} '{0}' là hóa đơn tạo từ đặt hàng, không thể gộp", oldName, Shared.GetTenPhongBan(true)));
                return false;
            }

            //kiểm tra phải cùng giảm giá, dịch vụ
            if (denDonHang.TILEGIAMGIA != tuDonHang.TILEGIAMGIA || denDonHang.TILEGIAMGIAGIO != tuDonHang.TILEGIAMGIAGIO)
            {
                Msg.ShowWarning(string.Format("Tỉ lệ giảm giá trên 2 {0} là khác nhau, không thể gộp với {0} này", Shared.GetTenPhongBan(true)));
                return false;
            }

            string msg = "Bạn có chắc chắn muốn gộp {2} '{0}' và {2} '{1}' không?" + Environment.NewLine +
                         "Sau khi gộp, chỉ còn hóa đơn trên {2} '{1}', các mặt hàng sẽ được chuyển sang {2} này.";
            msg = string.Format(msg, tuBan, denBan, Shared.GetTenPhongBan(true));

            if (Msg.ShowYesNo(msg) != DialogResult.Yes)
            {
                return false;
            }

            try
            {
                CapNhatGia(tuDonHang.ID, denDonHang.DBANID);

                if (Shared.CoTienGio || tuDonHang.TIENGIO != 0)
                {
                    TDONHANGGIORow row = new TDONHANGGIORow();
                    row.TDONHANGID = denDonHang.ID;
                    row.DBANGGIAID = tuDonHang.DBANGGIAID;
                    row.DBANID = tuDonHang.DBANID;
                    row.TUGIO = tuDonHang.BATDAUPHONGCUOI;
                    row.CACHTINHGIA = tuDonHang.CACHTINHGIA;
                    DateTime denGio = Config.Db.DbDateTime;
                    row.DENGIO = denGio;
                    row.DONGIA = tuDonHang.DONGIA;
                    row.THANHTIEN = Shared.TinhGia((CachTinhGiaGio)tuDonHang.CACHTINHGIA, tuDonHang.DBANGGIAID, tuDonHang.DONGIA,
                        tuDonHang.BATDAU, denGio, tuDonHang.BATDAU, 0, 0, null, tuDonHang.TIENMOBAN);
                    row.Update();
                }

                // Chuyển toàn bộ món từ tuDonHang sang denDonHang
                Config.Db.ExecSql("UPDATE TDONHANGCHITIET SET TDONHANGID = '" + denDonHang.ID + "' WHERE TDONHANGID = '" + tuDonHang.ID + "'");
                Config.Db.ExecSql("UPDATE TINCHEBIEN SET TDONHANGID = '" + denDonHang.ID + "' WHERE TDONHANGID = '" + tuDonHang.ID + "'");
                Config.Db.ExecSql("UPDATE TDONHANGGIO SET TDONHANGID = '" + denDonHang.ID + "' WHERE TDONHANGID = '" + tuDonHang.ID + "'");

                // Giải phóng bàn cũ
                Config.Db.ExecSql("UPDATE DBAN SET TDONHANGID = NULL WHERE ID = '" + tuDonHang.DBANID + "'");

                // Xóa đơn hàng cũ
                tuDonHang.Delete();

                // Tính toán lại tổng tiền cho đơn hàng mới
                decimal tongTienMoi = Config.Db.GetFirstFieldDec("SELECT SUM(THANHTIEN) FROM TDONHANGCHITIET WHERE TDONHANGID = '" + denDonHang.ID + "'");
                Config.Db.ExecSql(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    "UPDATE TDONHANG SET TIENHANG = {0}, TONGCONG = {0} WHERE ID = '{1}'", tongTienMoi, denDonHang.ID));

                // Lưu vết
                QuanLyBanHang.Track("Gộp " + Shared.GetTenPhongBan(true), LoaiLuuVet.GopBan, "Gộp vào hóa đơn " + denDonHang.NAME, tuDonHang.ID, tuBan);
                QuanLyBanHang.Track("Gộp " + Shared.GetTenPhongBan(true), LoaiLuuVet.GopBan, "Gộp từ hóa đơn " + tuDonHang.NAME, denDonHang.ID, denBan);
                QuanLyBanHang.LuuBillHuy(Config.Db, DbConfig.UserID, tuDonHang, "Gộp vào hóa đơn " + denDonHang.NAME);

                // Tắt đèn bàn chuyển đi nếu có
                Shared.TatDen(tuDonHang.DBANID);

                return true;
            }
            catch (Exception ex)
            {
                Msg.ShowError("Lỗi gộp bàn: " + ex.Message);
                return false;
            }
        }

        private static bool ThucHienChuyenBan(TDONHANGRow donHang, string DBANID)
        {
            string TuBan = Config.Db.GetFirstFieldString(Tables.DBAN, DBANInfo.NAME, donHang.DBANID);
            string DenBan = Config.Db.GetFirstFieldString(Tables.DBAN, DBANInfo.NAME, DBANID);

            string msg = "Bạn có muốn chuyển hóa đơn từ {2} '{0}' sang {2} '{1}' không?";
            msg = string.Format(msg, TuBan, DenBan, Shared.GetTenPhongBan(true));
            if (Msg.ShowYesNo(msg) != DialogResult.Yes)
            {
                return false;
            }

            try
            {
                TDONHANGRow upRow = new TDONHANGRow(donHang.ID);
                if (Shared.CoTienGio || donHang.TIENGIO != 0)
                {
                    TDONHANGGIORow row = new TDONHANGGIORow();
                    row.TDONHANGID = donHang.ID;
                    row.DBANGGIAID = donHang.DBANGGIAID;
                    row.DBANID = donHang.DBANID;
                    row.TUGIO = donHang.BATDAUPHONGCUOI;
                    row.CACHTINHGIA = donHang.CACHTINHGIA;
                    DateTime denGio = Config.Db.DbDateTime;
                    row.DENGIO = denGio;
                    row.DONGIA = donHang.DONGIA;
                    row.THANHTIEN = Shared.TinhGia((CachTinhGiaGio)donHang.CACHTINHGIA,
                        donHang.DBANGGIAID, donHang.DONGIA, donHang.BATDAUPHONGCUOI, denGio,
                        donHang.BATDAU, donHang.PHUTKHUYENMAI, donHang.TILEKHUYENMAIPHUTDAU, null, donHang.TIENMOBAN);
                    row.Update();

                    upRow.TUTHAYDOIGIO = 0;
                    upRow.BATDAUPHONGCUOI = denGio;
                    if (donHang.KETTHUC < denGio)
                    {
                        upRow.KETTHUC = denGio;
                    }
                }

                CapNhatGia(donHang.ID, DBANID);

                // Cập nhật thông tin bàn
                if (Shared.CoTienGio)
                {
                    string DBANGGIAID = "";
                    decimal DonGia = 0;
                    CachTinhGiaGio cachTinh = CachTinhGiaGio.THEOGIO;
                    decimal TienMoBan = 0;

                    TDONHANG0Ae.LayBangGiaTheoBan(DBANID, ref DBANGGIAID, ref DonGia, ref cachTinh, ref TienMoBan);
                    upRow.CACHTINHGIA = (int)cachTinh;
                    upRow.DBANGGIAID = DBANGGIAID;
                    upRow.DONGIA = DonGia;
                    upRow.TIENMOBAN = Math.Max(TienMoBan, donHang.TIENMOBAN);
                }
                upRow.DBANID = DBANID;
                upRow.Update();

                // Cập nhật liên kết bàn trong DB
                Config.Db.ExecSql(string.Format("UPDATE DBAN SET TDONHANGID = NULL WHERE ID = '{0}'", donHang.DBANID));
                Config.Db.ExecSql(string.Format("UPDATE DBAN SET TDONHANGID = '{0}' WHERE ID = '{1}'", donHang.ID, DBANID));

                // Lưu vết
                QuanLyBanHang.Track("Chuyển " + Shared.GetTenPhongBan(true), LoaiLuuVet.ChuyenBan, string.Format("Chuyển {2} từ '{0}' sang '{1}'", TuBan, DenBan, Shared.GetTenPhongBan(true)), donHang.ID, TuBan);

                // In phiếu chuyển bàn nếu có
                if (SystemConfig.SuDungChucNangInXuongBep == 30 && SystemConfig.InThongBaoKhiChuyenBan == 30)
                {
                    try { InPhieuChuyenBan(donHang.ID, donHang.DBANID, TuBan, DenBan); } catch { }
                }

                // Bật, tắt đèn nếu có sử dụng
                Shared.TatDen(donHang.DBANID);
                Shared.BatDen(DBANID);

                return true;
            }
            catch (Exception ex)
            {
                Msg.ShowError("Lỗi chuyển bàn: " + ex.Message);
                return false;
            }
        }

        private static void InPhieuChuyenBan(string TDONHANGID, string DBANID, string TuBan, string DenBan)
        {
            string sql = "SELECT DISTINCT DLOAIDOID FROM TINCHEBIEN WHERE TDONHANGID = '{0}'";
            sql = string.Format(sql, TDONHANGID);
            DataTable dt = Config.Db.GetTable(sql);
            if (dt == null) return;

            string DTUKHUVUCID = Config.Db.GetFirstFieldString(Tables.DBAN, DBANInfo.NAME, DBANID);
            string mayInBep, mayInBar, mayInKhac, mayInDichVu;
            InCheBien.LayMayInTheoCauHinh(DTUKHUVUCID, out mayInBep, out mayInBar, out mayInKhac, out mayInDichVu);
            List<string> lstPrinted = new List<string>();
            if (SystemConfig.InDoAn == 30 && mayInBep.Length > 0)
            {
                if (ThucHienInPhieuChuyenBan(LoaiDo.DoAn, dt, mayInBep, TuBan, DenBan))
                {
                    lstPrinted.Add(mayInBep);
                }
            }
            if (SystemConfig.InDoUong == 30 && mayInBar.Length > 0)
            {
                if (!lstPrinted.Contains(mayInBar))
                {
                    if (ThucHienInPhieuChuyenBan(LoaiDo.DoUong, dt, mayInBar, TuBan, DenBan))
                    {
                        lstPrinted.Add(mayInBar);
                    }
                }
            }

            if (SystemConfig.InDoKhac == 30 && mayInKhac.Length > 0)
            {
                if (!lstPrinted.Contains(mayInKhac))
                {
                    if (ThucHienInPhieuChuyenBan(LoaiDo.DoKhac, dt, mayInKhac, TuBan, DenBan))
                    {
                        lstPrinted.Add(mayInKhac);
                    }
                }
            }

            if (SystemConfig.InDichVu == 30 && mayInDichVu.Length > 0)
            {
                if (!lstPrinted.Contains(mayInDichVu))
                {
                    if (ThucHienInPhieuChuyenBan(LoaiDo.DichVu, dt, mayInDichVu, TuBan, DenBan))
                    {
                        lstPrinted.Add(mayInDichVu);
                    }
                }
            }
        }

        private static bool ThucHienInPhieuChuyenBan(LoaiDo loaiDo, DataTable dt, string MayIn, string TuBan, string DenBan)
        {
            if (dt == null) return false;
            if (dt.Select("DLOAIDOID='" + ((int)loaiDo).ToString() + "'").Length > 0)
            {
                string MauIn = SystemConfig.MauInChuyenBan;
                PrintConfig config = new PrintConfig();
                config.SFORMID = Forms.ChuyenBan;
                config.OnCustomReport = new CustomReportHandler(delegate(DataSet ds, Dictionary<string, object> dic)
                {
                    dic.Add("TỪ BÀN", TuBan);
                    dic.Add("ĐẾN BÀN", DenBan);
                });
                config.SREPORTTEMPLATEID = MauIn;
                config.MayIn = MayIn;
                config.ShowPreview = false;
                config.ShowSelectTemplate = MauIn.Length == 0;

                Config.PrintInvoice(config);
                return true;
            }
            return false;
        }

        private bool BanDangMo(string DBANID)
        {
            return new DBANRow(DBANID).TDONHANGID.Length > 0;
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            if (DBANID.Length == 0)
            {
                Msg.ShowWarning(string.Format("Mời bạn chọn {0} để thực hiện {1} {0}!", Shared.GetTenPhongBan(true), (chuyenGopMode == ChuyenGopBanMode.GopBan) ? "gộp" : "chuyển"));
            }
            else
            {
                if (BanDangMo(DBANID))
                {
                    if (chuyenGopMode == ChuyenGopBanMode.ChuyenMatHang)
                    {
                        if (Msg.ShowYesNo("Bạn có muốn chuyển mặt hàng " + (SoLuongChuyen > 0 ? ("với số lượng " + SoLuongChuyen.ToString() + " ") : "") + "sang hóa đơn đang chọn không?") == DialogResult.Yes)
                        {
                            ChuyenMatHang(DBANID, TDONHANGID, SoLuongChuyen);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (chuyenGopMode != ChuyenGopBanMode.GopBan)
                    {
                        Msg.ShowWarning(string.Format("{1} này đang sử dụng, mời bạn chọn {0} khác ({0} trống) để chuyển!", Shared.GetTenPhongBan(true), Shared.GetTenPhongBan(false)));
                        return;
                    }
                    else
                    {
                        if (ChuyenGopBan(TDONHANGID, DBANID))
                            this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    if (chuyenGopMode == ChuyenGopBanMode.GopBan || chuyenGopMode == ChuyenGopBanMode.ChuyenMatHang)
                    {
                        Msg.ShowWarning(string.Format("{0} này không sử dụng, mời bạn chọn {1} khác ({1} đang có khách) để gộp!", Shared.GetTenPhongBan(false), Shared.GetTenPhongBan(true)));
                        return;
                    }

                    if (ChuyenGopBan(TDONHANGID, DBANID))
                        this.DialogResult = DialogResult.OK;
                }
            }
        }

        public static void ChuyenMatHang(string DBANID, string TDONHANGCHITIETID, decimal SoLuongChuyen)
        {
            string TDONHANGCHUYENID = GetDonHangIDByBanID(DBANID);
            TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(TDONHANGCHITIETID);
            decimal ChenhLechInCheBien = GetChenhLechInCheBienChuyenDo(Config.Db, ctRow.DMATHANGID, ctRow.TENHANG, SoLuongChuyen < 0 ? ctRow.SLXUATCHUAQUYDOI : SoLuongChuyen, ctRow.TDONHANGID);
            if (SoLuongChuyen >= 0 && SoLuongChuyen < ctRow.SLXUATCHUAQUYDOI)
            {
                ctRow.SLXUATCHUAQUYDOI = ctRow.SLXUATCHUAQUYDOI - SoLuongChuyen;
                TDONHANG0Ae.UpdateThanhTien(ctRow);
                ctRow.Update();
                //tao moi dong nua ben hoa don moi mat hang
                TDONHANGCHITIETRow newRow = new TDONHANGCHITIETRow();
                newRow.ID = Guid.NewGuid().ToString();
                newRow.TDONHANGID = TDONHANGCHUYENID;
                newRow.DMATHANGID = ctRow.DMATHANGID;
                newRow.SLXUAT = SoLuongChuyen;
                newRow.SLXUATCHUAQUYDOI = SoLuongChuyen;
                newRow.DONGIA = ctRow.DONGIA;
                newRow.DDONVITINHID = ctRow.DDONVITINHID;
                newRow.NOTE = ctRow.NOTE;
                newRow.GIAVON = ctRow.GIAVON;
                newRow.COMBOID = Guid.NewGuid().ToString();
                newRow.TENHANG = ctRow.TENHANG;
                newRow.TILEGIAMGIA = ctRow.TILEGIAMGIA;
                TDONHANG0Ae.UpdateThanhTien(newRow);
                newRow.Update();
            }
            else
            {
                Config.Db.ExecSql("UPDATE TDONHANGCHITIET SET TDONHANGID = '" + TDONHANGCHUYENID + "' WHERE ID = '" + TDONHANGCHITIETID + "'");
                if (!string.IsNullOrEmpty(ctRow.COMBOID))
                {
                    Config.Db.ExecSql("UPDATE TDONHANGCHITIET SET TDONHANGID = '" + TDONHANGCHUYENID + "' WHERE COMBOPARENTID = '" + ctRow.COMBOID + "'");
                }
            }

            if (ChenhLechInCheBien != 0)
            {
                string sqlLanCuoi = "SELECT * FROM TINCHEBIEN WHERE TENHANG = '{0}' AND TDONHANGID = '{1}' AND NOTE = '{2}'";
                sqlLanCuoi = string.Format(sqlLanCuoi, ctRow.TENHANG.Replace("'", "''"), ctRow.TDONHANGID, (ctRow.NOTE ?? "").Replace("'", "''"));

                DataRow rLanCuoi = Config.Db.GetFirstRow(sqlLanCuoi);
                if (rLanCuoi != null)
                {
                    TINCHEBIENRow inRow = new TINCHEBIENRow(rLanCuoi);
                    InXuongBepControl.LuuInCheBien(ctRow.TDONHANGID, inRow.TENHANG,
                        -ChenhLechInCheBien,
                        inRow.NOTE,
                        inRow.DDONVITINHID,
                        inRow.DLOAIDOID,
                        inRow.LANSO);

                    InXuongBepControl.LuuInCheBien(TDONHANGCHUYENID, inRow.TENHANG,
                        ChenhLechInCheBien,
                        inRow.NOTE,
                        inRow.DDONVITINHID,
                        inRow.DLOAIDOID,
                        inRow.LANSO);
                }
            }

            string TuHoaDon = Config.Db.GetFirstFieldString(Tables.TDONHANG, TDONHANGInfo.NAME, ctRow.TDONHANGID);
            string DenHoaDon = Config.Db.GetFirstFieldString(Tables.TDONHANG, TDONHANGInfo.NAME, TDONHANGCHUYENID);

            decimal slThucTe = SoLuongChuyen < 0 ? ctRow.SLXUATCHUAQUYDOI : SoLuongChuyen;

            QuanLyBanHang.Track("Chuyển mặt hàng", LoaiLuuVet.ChuyenMatHang, "Chuyển " + slThucTe.ToString("n0") + " '" + ctRow.TENHANG + "' sang hóa đơn " + DenHoaDon, ctRow.TDONHANGID, QuanLyBanHang.GetTenBanTuHoaDon(ctRow.TDONHANGID));
            QuanLyBanHang.Track("Chuyển mặt hàng", LoaiLuuVet.ChuyenMatHang, "Nhận " + slThucTe.ToString("n0") + " '" + ctRow.TENHANG + "' từ hóa đơn " + TuHoaDon, TDONHANGCHUYENID, QuanLyBanHang.GetTenBanTuHoaDon(TDONHANGCHUYENID));
        }

        public static decimal GetChenhLechInCheBienChuyenDo(Database Db, string DMATHANGID, string TenHang, decimal SoLuongChuyen, string TDONHANGID)
        {
            if (SystemConfig.SuDungChucNangInXuongBep != 30) return 0;
            string sql = "SELECT DLOAIDOID FROM DNHOMMATHANG WHERE ID = (SELECT DNHOMMATHANGID FROM DMATHANG WHERE ID = '{0}')";
            sql = string.Format(sql, DMATHANGID);
            string DLOAIDOID = Db.GetFirstFieldString(sql);
            LoaiDo loai = (LoaiDo)ConvertTo.Int(DLOAIDOID);
            int value = 0;
            switch (loai)
            {
                case LoaiDo.DichVu:
                    value = SystemConfig.InDichVu;
                    break;
                case LoaiDo.DoAn:
                    value = SystemConfig.InDoAn;
                    break;
                case LoaiDo.DoUong:
                    value = SystemConfig.InDoUong;
                    break;
                case LoaiDo.DoKhac:
                    value = SystemConfig.InDoKhac;
                    break;
            }

            if (value == 0) return 0;
            decimal daIn = GetSoLuongDaIn(Db, TenHang, TDONHANGID);
            decimal soLuong = GetSoLuongSauGiam(Db, TenHang, SoLuongChuyen, TDONHANGID);
            if (soLuong >= daIn)
            {
                return 0;
            }

            return daIn - soLuong;
        }

        public static decimal GetSoLuongSauGiam(Database Db, string TenHang, decimal SoLuongChuyen, string TDONHANGID)
        {
            string sql = "SELECT SUM(SLXUATCHUAQUYDOI) FROM TDONHANGCHITIET WHERE TENHANG = '" + TenHang.Replace("'", "''") + "' AND TDONHANGID = '" + TDONHANGID + "'";
            FbCommand cmd = Db.GetCommand(sql);
            return ConvertTo.Decimal(Db.GetFirstField(cmd)) - SoLuongChuyen;
        }

        public static decimal GetSoLuongDaIn(Database Db, string TenHang, string TDONHANGID)
        {
            string sql = "SELECT SUM(SOLUONG) FROM TINCHEBIEN WHERE TENHANG = '" + TenHang.Replace("'", "''") + "' AND TDONHANGID = '" + TDONHANGID + "'";
            FbCommand cmd = Db.GetCommand(sql);
            return ConvertTo.Decimal(Db.GetFirstField(cmd));
        }

        internal static string GetDonHangIDByBanID(string BanID)
        {
            string sql = "SELECT FIRST 1 ID FROM TDONHANG WHERE DBANID = '" + BanID + "' AND STATUS = 30 AND DATHANHTOAN = 0 AND USERTHANHTOANID IS NULL";
            object val = Config.Db.GetFirstField(sql);
            return (val == null || val.ToString().Length == 0 ? "" : val.ToString());
        }

        private static void CapNhatGia(string TDONHANGID, string DBANMOIID)
        {
            try
            {
                GiaMatHang giaSuDung = (GiaMatHang)Config.Db.GetFirstFieldInt("SELECT DGIAMATHANGID FROM DKHUVUC WHERE ID = (SELECT DKHUVUCID FROM DBAN WHERE ID = '" + DBANMOIID + "')");
                string donGiaField = "GIABAN";
                if (giaSuDung == GiaMatHang.GIABAN2) donGiaField = "GIABAN2";
                else if (giaSuDung == GiaMatHang.GIABAN3) donGiaField = "GIABAN3";
                else if (giaSuDung == GiaMatHang.GIABAN4) donGiaField = "GIABAN4";

                DataTable dtItems = Config.Db.GetTable("SELECT ID, TILEGIAMGIA, GIAMTHEOTIEN, TIENGIAMGIA, SLXUATCHUAQUYDOI, DONGIA, (SELECT " + donGiaField + " FROM DMATHANG WHERE ID = DMATHANGID) AS DONGIAMOI FROM TDONHANGCHITIET WHERE TDONHANGID = '" + TDONHANGID + "' AND COALESCE(COMBOPARENTID, '') = ''");
                if (dtItems != null)
                {
                    foreach (DataRow rItem in dtItems.Rows)
                    {
                        decimal giaMoi = ConvertTo.Decimal(rItem["DONGIAMOI"]);
                        decimal giaCu = ConvertTo.Decimal(rItem["DONGIA"]);
                        if (giaMoi > 0 && giaCu != giaMoi)
                        {
                            string ctId = rItem["ID"]?.ToString() ?? "";
                            decimal sl = ConvertTo.Decimal(rItem["SLXUATCHUAQUYDOI"]);
                            decimal tileGiam = ConvertTo.Decimal(rItem["TILEGIAMGIA"]);
                            decimal thanhTien = sl * giaMoi * (1 - tileGiam / 100m);
                            Config.Db.ExecSql(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                "UPDATE TDONHANGCHITIET SET DONGIA = {0}, THANHTIEN = {1} WHERE ID = '{2}'",
                                giaMoi, thanhTien, ctId));
                        }
                    }
                }
            }
            catch { }
        }

        public void tabKhuVuc_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                KryptonNavigator nav = sender as KryptonNavigator;
                KhuVucControl control = null;
                if (nav?.SelectedPage != null)
                {
                    control = nav.SelectedPage.Controls.Count > 0 ? (nav.SelectedPage.Controls[0].Tag as KhuVucControl ?? nav.SelectedPage.Controls[0] as KhuVucControl) : null;
                }

                if (control != null)
                {
                    control.RefreshData();
                }
            }
            catch { }
        }
    }
}
