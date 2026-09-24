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
    public partial class SuDungDichVu : No1Lib.Sys.No1UserControl, IRefreshable
    {
        public Control No1UserControl1 { get { return this; } }

        public SuDungDichVu()
        {
            InitializeComponent();
        }

        public void No1UserControl1_OnInit(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Thông tin đơn hàng đang chọn
        /// </summary>
        internal TDONHANG0Ae donHang;

        /// <summary>
        /// Sự kiện chọn bàn yêu cầu từ đơn hàng
        /// </summary>        
        void donHang_SelectBanTuTabRequest(string DBANID, string DKHUVUCID, bool BanTrong)
        {
            if (!SelectBanTuTab(tabKhuVuc, DBANID, DKHUVUCID, BanTrong))
            {
                SelectBanTuTab(tabKhuVuc2, DBANID, DKHUVUCID, BanTrong);
            }
        }

        /// <summary>
        /// Chọn bàn từ danh mục bàn khu vực
        /// </summary>
        /// <param name="tab">Khu vực trên hay dưới</param>
        /// <param name="DBANID">ID của bàn</param>
        /// <param name="DKHUVUCID">ID của khu vực</param>
        /// <param name="Empty">Bàn chọn ở trạng thái trống hay không?</param>
        /// <returns></returns>
        private bool SelectBanTuTab(KryptonNavigator tab, string DBANID, string DKHUVUCID, bool Empty)
        {
            foreach (KryptonPage page in tab.Pages)
            {
                if (page.Controls.Count == 0) continue;
                Control c = page.Controls[0];
                if (c.Tag is KhuVucControl)
                {
                    KhuVucControl kv = (KhuVucControl)(c.Tag);
                    if (kv.ID == DKHUVUCID)
                    {
                        tab.SelectedPage = page;
                        if (kv.SelectTable(DBANID))
                        {
                            if (Empty)
                            {
                                if (SystemConfig.BatBuocNhapNhanVienBanHang == 30)
                                {
                                    //hiển thị chọn nhân viên
                                    TreeSelect form = new TreeSelect(Tables.DNHANVIEN.ToString(), "Chọn nhân viên");
                                    if (form.ShowDialog() == DialogResult.OK)
                                    {
                                        donHang.btnBatDau.PerformClick();
                                        donHang.lueDNHANVIENXUATID.EditValue = form.CategoryID;
                                    }
                                }
                                else
                                {
                                    if (Msg.ShowYesNo(string.Format("Bạn có muốn thực hiện mở {0} không?", Shared.GetTenPhongBan(true))) == DialogResult.Yes)
                                    {
                                        donHang.btnBatDau.PerformClick();
                                    }
                                }
                            }

                            donHang.txtTimKiem.SelectAllEx();
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Refresh lại trạng thái phòng khi đơn hàng yêu cầu
        /// </summary>        
        void donHang_OnRefreshTrangThaiRequest(object sender, EventArgs e)
        {
            RefreshTrangThaiBan();
        }

        /// <summary>
        /// Tải lại danh sách khu vực
        /// </summary>
        private void LoadDanhSachKhuVuc()
        {
            LoadKhuVuc(tabKhuVuc, 0, AddKhuVuc);
            LoadKhuVuc(tabKhuVuc2, 1, AddKhuVuc);
            if (tabKhuVuc2.Pages.Count == 0)
            {
                splitKhuVuc.Panel2Collapsed = true;
            }
            else
            {
                splitKhuVuc.Panel2Collapsed = false;
            }

            Reload("");
        }

        private void AddKhuVuc(KhuVucControl lst)
        {
            lst.OnThayDoiBan += new KhuVucControl.OnThayDoiBanExHandler(lst_OnThayDoiBan);
            lst.OnForceThayDoiBan += new KhuVucControl.OnThayDoiBanHandler(lst_OnForceThayDoiBan);
            lst.OnNgatGioRequest += new KhuVucControl.OnThayDoiBanHandler(lst_OnNgatGioRequest);
            lst.OnRequireStart += new KhuVucControl.OnThayDoiBanHandler(lst_OnRequireStart);
            lst.OnRequireStartByBooking += new KhuVucControl.OnThayDoiBanHandler(lst_OnRequireStartByBooking);
            lst.OnChuyenBanRequest += new KhuVucControl.OnThayDoiBanHandler(lst_OnChuyenBanRequest);
            lst.OnThanhToanRequire += new EventHandler(lst_OnThanhToanRequire);
            lst.OnGopBanRequest += new KhuVucControl.OnThayDoiBanHandler(lst_OnGopBanRequest);
        }

        void lst_OnRequireStartByBooking(KhuVucControl control, string banID)
        {
            //show cua so chon dat hang
            donHang.MoBanTuDatPhong(banID);
        }

        void lst_OnGopBanRequest(KhuVucControl control, string banID)
        {
            donHang.ChuyenBan(banID, ChuyenGopBanMode.GopBan);
        }

        void lst_OnChuyenBanRequest(KhuVucControl control, string banID)
        {
            donHang.ChuyenBan(banID, ChuyenGopBanMode.ChuyenBan);
        }

        void lst_OnThanhToanRequire(object sender, EventArgs e)
        {
            donHang.btnThanhToan.PerformClick();
        }

        internal static void LoadKhuVuc(KryptonNavigator nav, int index, OnKhuVucControlCreatedHandler callBack)
        {
            List<KryptonPage> lstClear = new List<KryptonPage>();
            foreach (KryptonPage p in nav.Pages) lstClear.Add(p);
            nav.Pages.Clear();
            foreach (KryptonPage p in lstClear) p.Dispose();

            string sql = @"SELECT ID, NAME, DGIAMATHANGID, 
                                (SELECT ANH FROM DBIEUTUONG WHERE ID = DBIEUTUONGID) AS BIEUTUONG 
                                FROM DKHUVUC WHERE STATUS = 30 AND COALESCE(TABHIENTHI, 0) = " + index.ToString();
            if (!DbConfig.IsAdmin && SystemConfig.PhanQuyenTruyCapTheoKhuVuc == 30)
            {
                sql += "AND ID IN (SELECT DKHUVUCID FROM DTKTHEOKHUVUC WHERE SUSERID = '" + DbConfig.UserID + "')";
            }
                         
            sql += " ORDER BY SORTORDER";
            DataTable dtKhuVuc = Config.Db.GetTable(sql);
            KhuVucControl firstControl = null;
            foreach (DataRow row in dtKhuVuc.Rows)
            {
                DKHUVUCRow r = new DKHUVUCRow(row);
                KryptonPage page = new KryptonPage(r.NAME);                
                nav.Pages.Add(page);
                //mỗi tab sẽ add 1 listview
                KhuVucControl lst = (KhuVucControl) Config.CreateForm(Forms.KhuVucControl);
                lst.Init();
                lst.SetData(r);
                if (firstControl == null)
                {
                    firstControl = lst;
                }

                if (callBack != null) callBack(lst);
                lst.No1UserControl1.Dock = DockStyle.Fill;
                page.Controls.Add(lst.No1UserControl1);
            }

            if (firstControl != null)
                firstControl.RefreshData();

            if (nav.Pages.Count > 0) nav.SelectedIndex = 0;
            nav.Refresh();
        }

        void lst_OnNgatGioRequest(KhuVucControl control, string DBANID)
        {
            if (Msg.ShowYesNo("Bạn có muốn ngắt giờ hóa đơn đang chọn không?") == DialogResult.Yes)
            {
                if (Shared.UngDung == UngDung.KARAOKE)
                {                    
                    TDONHANGRow hoaDon = new TDONHANGRow(donHang.ID);

                    //tách riêng thông tin cũ
                    TDONHANGGIORow row = new TDONHANGGIORow();
                    row.TDONHANGID = hoaDon.ID;
                    row.DBANGGIAID = hoaDon.DBANGGIAID;
                    row.DBANID = hoaDon.DBANID;
                    row.TUGIO = hoaDon.BATDAUPHONGCUOI;
                    row.CACHTINHGIA = hoaDon.CACHTINHGIA;
                    DateTime denGio = Config.Db.DbDateTime;
                    row.DENGIO = denGio;
                    row.DONGIA = hoaDon.DONGIA;
                    row.THANHTIEN = Shared.TinhGia((CachTinhGiaGio)hoaDon.CACHTINHGIA,
                        hoaDon.DBANGGIAID, hoaDon.DONGIA, hoaDon.BATDAUPHONGCUOI, denGio,
                        hoaDon.BATDAU, hoaDon.PHUTKHUYENMAI, hoaDon.TILEKHUYENMAIPHUTDAU, null, hoaDon.TIENMOBAN);
                    row.Update();

                    TDONHANGRow upRow = new TDONHANGRow(donHang.ID);
                    upRow.TUTHAYDOIGIO = 0;
                    upRow.BATDAUPHONGCUOI = denGio;
                    if (hoaDon.KETTHUC < denGio)
                    {
                        upRow.KETTHUC = denGio;
                    }
                    upRow.Update();

                    //đổi bảng giá
                    Reload(donHang.ID);
                }
                else
                {
                    
                    TDONHANGRow row = new TDONHANGRow(mapper.ID);
                    string GUID = row.NHOMGUID;
                    TDONHANGRow uRow = new TDONHANGRow(mapper.ID);

                    if (GUID.Length == 0)
                    {
                        GUID = Guid.NewGuid().ToString();
                        uRow.NHOMGUID = GUID;
                    }

                    uRow.USERTHANHTOANID = DbConfig.UserID;
                    uRow.Update();
                    //tạo mới hóa đơn

                    DateTime ngay = Shared.GetNgayGiaoDich(Config.Db);

                    TDONHANGRow newRow = new TDONHANGRow();
                    newRow.DBANID = DBANID;
                    newRow.NGAY = ngay;
                    newRow.BATDAU = Config.Db.DbDateTime;
                    newRow.DATHANHTOAN = 0;
                    newRow.NHOMGUID = GUID;

                    int So;
                    newRow.NAME = TDONHANG0Ae.TaoSoHoaDon(Config.Db, DbConfig.UserID, ngay, out So);
                    newRow.TIENHANG = 0;
                    newRow.SOHD = So;
                    newRow.TIENGIO = 0;
                    newRow.TILEGIAMGIA = 0;
                    newRow.TIENGIAMGIA = 0;
                    newRow.TONGCONG = 0;
                    newRow.NHOMGUID = GUID;
                    newRow.Update();

                    Reload(newRow.ID);
                }
            }
        }        

        void lst_OnForceThayDoiBan(KhuVucControl control, string banID)
        {
            LoadByTable(control, true);
        }

        string lst_OnThayDoiBan(KhuVucControl control, string banID)
        {
            //tải dữ liệu chi tiết
            LoadByTable(control, false);

            return donHang.btnThanhToan.Enabled ? donHang.ID : "";
        }

        void lst_OnRequireStart(KhuVucControl control, string banID)
        {
            donHang.MoHoaDon();
        }


		public void tabKhuVuc_SelectedPageChanged(object sender, EventArgs e)
		{
            KryptonNavigator nav = sender as KryptonNavigator;
            KhuVucControl control = null;
            if (nav.SelectedPage != null)
            {
                control = nav.SelectedPage.Controls.Count > 0 ? (nav.SelectedPage.Controls[0].Tag as KhuVucControl) : null;
            }

            if (control != null)
            {
                control.RefreshData();
                LoadByTable(control, false);
            }
		}

        void donHang_OnLockTableRequest(string DBANID)
        {
            if (locker == null)
            {
                locker = new TableLocker(DBANID, null);
            }
            else
            {
                locker.DBANID = DBANID;
            }
            locker.Lock();
        }

        internal static TableLocker locker;
        private KhuVucControl lastActiveKhuVuc;
        /// <summary>
        /// Tải thông tin đơn hàng của bàn đang chọn trên khu vực
        /// </summary>
        /// <param name="control">Khu vực đang lựa chọn</param>        
        /// <param name="forceReloadDonHang">Bắt buộc tải lại đơn hàng sau khi thực hiện</param>
        private void LoadByTable(KhuVucControl control, bool forceReloadDonHang)
        {
            string DBANID = control.BanID;            

            lastActiveKhuVuc = control;
            if (SystemConfig.HeThongChayNhieuMayTram == 30)
            {   
                //TEST UPDATE:
                if (DBANID == donHang.DBANID || DBANID.Length == 0) return;
                if (locker != null) locker.UnLockAndStop();

                //kiểm tra xem có bị lock không?
                string TaiKhoanGiu = "";
                if (!BanDangBiGiu(DBANID, ref TaiKhoanGiu))
                {
                    string TDONHANGID = TDONHANG0Ae.GetHoaDonTrenBan(DBANID);

                    if (TDONHANGID.Length > 0)
                    {
                        donHang_OnLockTableRequest(DBANID);

                        //TEST UPDATE:
                        if (TDONHANGID.Length == 0 || TDONHANGID != mapper.ID)
                            Reload(TDONHANGID);
                    }
                    else
                    {
                        Reload("");
                    }
                }
                else
                {
                    control.ClearSelection();

                    Msg.ShowWarning(Shared.GetTenPhongBan(false).ToUpper() + " NÀY ĐANG ĐƯỢC THAO TÁC BỞI: " + TaiKhoanGiu);

                    control.ClearSelection();
                }
            }
            else
            {
                //lấy hóa đơn đang trên bàn                
                string TDONHANGID = TDONHANG0Ae.GetHoaDonTrenBan(DBANID);
                //TEST UPDATE:
                if (TDONHANGID.Length == 0 || TDONHANGID != donHang.ID || forceReloadDonHang)
                    Reload(TDONHANGID);
            }

            if (control != null)
            {
                donHang.SetGiaTheoKhuVuc(control.GiaMatHang);
            }
        }

        internal static bool BanDangBiGiu(string DBANID, ref string TaiKhoanGiu)
        {
            string sql = string.Format(@"SELECT TAIKHOANGIU, TDONHANGID FROM DBAN WHERE ID = '{0}' 
AND GIULUC > DATEADD(-120 SECOND TO CURRENT_TIMESTAMP) AND GIULUC <= CURRENT_TIMESTAMP", DBANID);
            DBANRow banRow = new DBANRow(Config.Db.GetFirstRow(sql));
            if (banRow.TAIKHOANGIU.Length == 0)
            {
                return false;
            }
            TaiKhoanGiu = banRow.TAIKHOANGIU;
            return true;
        }

        /// <summary>
        /// Tải thông tin đơn hàng lên giao diện
        /// </summary>
        /// <param name="TDONHANGID">ID đơn hàng</param>
        private void Reload(string TDONHANGID)
        {
            mapper.ID = TDONHANGID;
            donHang.ThucHienInCheBien(true);
            donHang.Reload(TDONHANGID, lastActiveKhuVuc == null ? "" : lastActiveKhuVuc.BanID);
        }
        
        /// <summary>
        /// Tải lại trạng thái bàn trên giao diện
        /// </summary>
        private void RefreshTrangThaiBan()
        {
            ResetAutoRefreshTimer();

            Form f = tabKhuVuc.FindForm();
            if (f != null ) f.Cursor = Cursors.WaitCursor;

            RefreshTab(tabKhuVuc);
            RefreshTab(tabKhuVuc2);

            if (f != null ) f.Cursor = Cursors.Default;
        }

        private void RefreshTab(KryptonNavigator tab)
        {
            if (tab.SelectedPage == null) return;
            if (tab.SelectedPage.Controls.Count == 0) return;
            KhuVucControl value = tab.SelectedPage.Controls[0].Tag as KhuVucControl;
            if (value == null) return;
            value.RefreshData();
        }

        private void ResetAutoRefreshTimer()
        {
            if (SystemConfig.HeThongChayNhieuMayTram == 30)
            {
                tmrAutoRefresh.Enabled = false;
                tmrAutoRefresh.Enabled = true;
            }
        }


		public void No1UserControl1_KeyDownEx(object sender, KeyEventArgs e)
		{
            donHang.mapper_OnKeyDown(sender, e);
		}


		public void No1UserControl1_OnAddedToTab(object sender, EventArgs e)
		{
            //khởi tạo hóa đơn bên tay phải
            if (donHang == null)
            {
                try
                {
                    donHang = Config.CreateForm(Forms.TDONHANG0Ae) as TDONHANG0Ae;
                }
                catch { }
                if (donHang == null)
                {
                    donHang = new TDONHANG0Ae();
                }
            }
            donHang.Mode = HoaDonMode.SuDungDichVu;
            donHang.OnAfterThanhToan += new EventHandler(donHang_OnAfterThanhToan);
            donHang.OnLockTableRequest += new TDONHANG0Ae.OnLockTableRequestHandler(donHang_OnLockTableRequest);
            donHang.OnRefreshTrangThaiRequest += new EventHandler(donHang_OnRefreshTrangThaiRequest);
            donHang.SelectBanTuTabRequest += new SelectBanTuTabRequestHandler(donHang_SelectBanTuTabRequest);
            donHang.OnNoteChanged += new TDONHANG0Ae.OnNoteChangedHandler(donHang_OnNoteChanged);
            donHang.mapper_OnLoad(null, EventArgs.Empty);
            donHang.No1UserControl1.Dock = DockStyle.Fill;
            splitMain.Panel2.Controls.Add(donHang.No1UserControl1);

            //lưu lại vị trí
            RestoreSplitLayout();

            splitMain.SplitterMoved += splitMain_SplitterMoved;
            splitKhuVuc.SplitterMoved += splitMain_SplitterMoved;
            donHang.splitHoaDon.SplitterMoved += splitMain_SplitterMoved;

            //tải danh sách khu vực lên tab trên và tab dưới
            LoadDanhSachKhuVuc();

            //thiết lập tự động refresh
            ResetAutoRefreshTimer();
		}

        void donHang_OnAfterThanhToan(object sender, EventArgs e)
        {
            if (locker != null) locker.UnLockAndStop();
        }        

        void splitMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SaveSplitLayout();
        }

        string iniFile = Application.StartupPath + "\\Data\\app.dat";
        private void SaveSplitLayout()
        {
            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            IniFile.WriteString(iniFile, "LAYOUT", "splitMain" + ScreenWidth.ToString(), splitMain.SplitterDistance.ToString());
            IniFile.WriteString(iniFile, "LAYOUT", "splitKhuVuc" + ScreenWidth.ToString(), splitKhuVuc.SplitterDistance.ToString());
            IniFile.WriteString(iniFile, "LAYOUT", "splitHoaDon" + ScreenWidth.ToString(), donHang.splitHoaDon.SplitterDistance.ToString());
        }

        private void RestoreSplitLayout()
        {
            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            string main = IniFile.GetString(iniFile, "LAYOUT", "splitMain" + ScreenWidth.ToString(), "");
            if (main.Length > 0)
            {
                int distance = ConvertTo.Int(main);
                if (distance > 10 && distance < 1000)
                {
                    splitMain.SplitterDistance = distance;
                }
            }

            main = IniFile.GetString(iniFile, "LAYOUT", "splitKhuVuc" + ScreenWidth.ToString(), "");
            if (main.Length > 0)
            {
                int distance = ConvertTo.Int(main);
                if (distance > 10 && distance < 1000)
                {
                    splitKhuVuc.SplitterDistance = distance;
                }
            }

            main = IniFile.GetString(iniFile, "LAYOUT", "splitHoaDon" + ScreenWidth.ToString(), "");
            if (main.Length > 0)
            {
                int distance = ConvertTo.Int(main);
                if (distance > 10 && distance < 1000)
                {
                    donHang.splitHoaDon.SplitterDistance = distance;
                }
            }
        }

        void donHang_OnNoteChanged(string DBANID, string Note)
        {
            UpdateNote(tabKhuVuc, DBANID, Note);
            UpdateNote(tabKhuVuc2, DBANID, Note);
        }

        private void UpdateNote(KryptonNavigator tab, string DBANID, string Note)
        {
            if (tab.SelectedPage != null && tab.SelectedPage.Controls.Count > 0)
            {
                if ((tab.SelectedPage.Controls[0].Tag as KhuVucControl).BanID == DBANID)
                {
                    (tab.SelectedPage.Controls[0].Tag as KhuVucControl).SetNote(Note);
                }
            }
        }


		public void tmrAutoRefresh_Tick(object sender, EventArgs e)
		{
            if (tabKhuVuc.SelectedPage != null && tabKhuVuc.SelectedPage.Controls.Count > 0)
            {
                (tabKhuVuc.SelectedPage.Controls[0].Tag as KhuVucControl).RefreshStatus();
            }

            if (tabKhuVuc2.SelectedPage != null && tabKhuVuc2.SelectedPage.Controls.Count > 0)
            {
                (tabKhuVuc2.SelectedPage.Controls[0].Tag as KhuVucControl).RefreshStatus();
            }
		}

        #region IRefreshable Members

        int lastRefresh = Environment.TickCount;
        public new void DoRefresh()
        {
            //TODO: kiểm tra xem có sự thay đổi về:
            //1. Danh sách bàn, khu vưc
            if (Config.NeedRefresh(Tables.DBAN, lastRefresh) || Config.NeedRefresh(Tables.DKHUVUC, lastRefresh))
            {
                LoadDanhSachKhuVuc();
            }

            //2. Mặt hàng
            if (Config.NeedRefresh(Tables.DMATHANG, lastRefresh))
            {
                donHang.grMatHang.LoadData();
            }

            //3. Nhóm mặt hàng
            (donHang.tvCat as IRefreshable)?.DoRefresh();
            //4. Hóa đơn                        

            lastRefresh = Environment.TickCount;            
        }

        #endregion


		public void No1UserControl1_OnTabClosing(object sender, CancelEventArgs e)
		{
            donHang.ThucHienInCheBien(true);
            if (locker != null) locker.UnLockAndStop();
            donHang.Close();
            donHang = null;
		}
    }
}
