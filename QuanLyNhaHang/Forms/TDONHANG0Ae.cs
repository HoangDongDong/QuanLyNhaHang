
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Forms;
using DbMapping;
using SystemConfig = QuanLyNhaHang.Services.SystemConfig;
using Tables = QuanLyNhaHang.Forms.Tables;
using Functions = QuanLyNhaHang.Forms.Functions;
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
using System.Net.Sockets;
using System.Net;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using System.IO;

namespace No1Run
{
    public partial class TDONHANG0Ae
    {
        public static void EnsureNo1LibInitialized()
        {
            try
            {
                if (DbMapping.SystemConfig.Db == null && Config.Db != null)
                {
                    DbMapping.SystemConfig.Db = Config.Db;
                }
                if (DbMapping.BaseSystemConfig.AllConfigs == null && DbMapping.SystemConfig.Db != null)
                {
                    try { DbMapping.BaseSystemConfig.Refresh(); } catch { }
                }

                if (Config.GetTableDesc("DKHACHHANG") != null) return;
                var configType = typeof(No1Lib.Sys.Config);
                var m = configType.Module.ResolveMethod(100669902);
                if (m != null)
                {
                    m.Invoke(null, null);
                }
            }
            catch
            {
                try
                {
                    var configType = typeof(No1Lib.Sys.Config);
                    foreach (var m in configType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static))
                    {
                        if (m.DeclaringType == configType && m.GetParameters().Length == 0 && m.ReturnType == typeof(void))
                        {
                            try
                            {
                                m.Invoke(null, null);
                                if (Config.GetTableDesc("DKHACHHANG") != null) break;
                            }
                            catch { }
                        }
                    }
                }
                catch { }
            }
        }

        public TDONHANG0Ae()
        {
            InitializeComponent();
            EnsureNo1LibInitialized();
            InitMapper();
        }

        private void InitMapper()
        {
            // Bỏ hoàn toàn cơ chế ánh xạ No1FieldMap của No1Lib.
            // Dữ liệu đọc/ghi trực tiếp bằng ADO.NET SQL thuần, không còn lỗi ngầm hay phụ thuộc cấu hình ảo.
        }

        private int _giamTheoTien = 0;
        private int _giamGiaGioTheoTien = 0;
        private int _giamTongTheoTien = 0;
        private int _phiDichVuTheoTien = 0;
        private bool _isLoading = false;

        private DataTable DetailTable
        {
            get
            {
                return grDetail?.GridView?.DataSource as DataTable;
            }
        }

        private DataTable GioHatTable
        {
            get
            {
                return grGioHat?.GridView?.DataSource as DataTable;
            }
        }

        private decimal SafeCalcSum(GridMapper gm, string colName)
        {
            if (gm == null) return 0;
            try
            {
                DataTable dt = gm.GridView?.DataSource as DataTable;
                if (dt != null && dt.Columns.Contains(colName) && dt.Rows.Count > 0)
                {
                    object sum = dt.Compute("SUM(" + colName + ")", "");
                    if (sum != null && sum != DBNull.Value)
                    {
                        return ConvertTo.Decimal(sum);
                    }
                }
            }
            catch { }
            return 0;
        }

        private void SafeCalculateAllRows()
        {
            DataTable dt = DetailTable;
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r == null || r.RowState == DataRowState.Deleted) continue;
                    SafeCalculateRow(r);
                }
            }
            try
            {
                grDetail?.Refresh();
            }
            catch { }
        }

        private void SafeCalculateRow(DataRow r, int rowIndex = -1)
        {
            if (r == null) return;
            try
            {
                decimal sl = 0;
                if (r.Table.Columns.Contains("SLXUATCHUAQUYDOI") && r["SLXUATCHUAQUYDOI"] != DBNull.Value)
                    decimal.TryParse(r["SLXUATCHUAQUYDOI"].ToString(), out sl);
                else if (r.Table.Columns.Contains("SOLUONG") && r["SOLUONG"] != DBNull.Value)
                    decimal.TryParse(r["SOLUONG"].ToString(), out sl);

                decimal gia = 0;
                if (r.Table.Columns.Contains("DONGIA") && r["DONGIA"] != DBNull.Value)
                    decimal.TryParse(r["DONGIA"].ToString(), out gia);

                decimal ck = 0;
                if (r.Table.Columns.Contains("TILEGIAMGIA") && r["TILEGIAMGIA"] != DBNull.Value)
                    decimal.TryParse(r["TILEGIAMGIA"].ToString(), out ck);

                decimal tien = sl * gia;
                if (ck > 0)
                {
                    tien = tien - (tien * ck / 100m);
                }
                if (r.Table.Columns.Contains("THANHTIEN"))
                {
                    r["THANHTIEN"] = tien;
                }
            }
            catch { }
            try
            {
                if (rowIndex >= 0)
                    grDetail?.CalculateRow(r, rowIndex);
                else
                    grDetail?.CalculateRow(r);
            }
            catch { }
        }

        private decimal GetDonHangDecimal(string fieldName, decimal defaultValue = 0)
        {
            if (_currentDonHangRow != null && _currentDonHangRow.Row != null && _currentDonHangRow.Row.Table.Columns.Contains(fieldName))
            {
                object val = _currentDonHangRow.Row[fieldName];
                if (val != null && val != DBNull.Value && decimal.TryParse(val.ToString(), out decimal res))
                    return res;
            }
            return defaultValue;
        }

        private int GetDonHangInt(string fieldName, int defaultValue = 0)
        {
            if (_currentDonHangRow != null && _currentDonHangRow.Row != null && _currentDonHangRow.Row.Table.Columns.Contains(fieldName))
            {
                object val = _currentDonHangRow.Row[fieldName];
                if (val != null && val != DBNull.Value && int.TryParse(val.ToString(), out int res))
                    return res;
            }
            return defaultValue;
        }

        private DateTime GetDonHangDateTime(string fieldName, DateTime? defaultVal = null)
        {
            if (_currentDonHangRow != null && _currentDonHangRow.Row != null && _currentDonHangRow.Row.Table.Columns.Contains(fieldName))
            {
                object val = _currentDonHangRow.Row[fieldName];
                if (val != null && val != DBNull.Value && DateTime.TryParse(val.ToString(), out DateTime res))
                    return res;
            }
            return defaultVal ?? DateTime.Now;
        }

        private string GetDonHangString(string fieldName, string defaultValue = "")
        {
            if (_currentDonHangRow != null && _currentDonHangRow.Row != null && _currentDonHangRow.Row.Table.Columns.Contains(fieldName))
            {
                object val = _currentDonHangRow.Row[fieldName];
                if (val != null && val != DBNull.Value)
                    return val.ToString();
            }
            return defaultValue;
        }

        private void SetDonHangField(string fieldName, object value)
        {
            if (_currentDonHangRow != null && _currentDonHangRow.Row != null && _currentDonHangRow.Row.Table.Columns.Contains(fieldName))
            {
                _currentDonHangRow.Row[fieldName] = value ?? DBNull.Value;
            }
            if (!string.IsNullOrEmpty(_currentDonHangID))
            {
                try
                {
                    string valSql = (value == null || value == DBNull.Value) ? "NULL" : ("'" + value.ToString().Replace("'", "''") + "'");
                    if (value is DateTime dtVal) valSql = "'" + dtVal.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    Config.Db.ExecSql(string.Format("UPDATE TDONHANG SET {0} = {1} WHERE ID = '{2}'", fieldName, valSql, _currentDonHangID));
                }
                catch { }
            }
        }

        public Control No1UserControl1 { get { return this; } }

        public void mapper_AfterFillData(object sender, EventArgs e)
        {
        }
        
        /// <summary>
        /// ID bàn đang chọn
        /// </summary>
        public string DBANID = "";    
        /// <summary>
        /// Tùy chọn cho phép thay đổi giờ trên bill hay không
        /// </summary>
        private bool ChoPhepThayDoiGio;

        /// <summary>
        /// Tùy chọn có sử dụng cân điện tử hay không?
        /// </summary>
        private bool CoDungCanDienTu;

        /// <summary>
        /// Tùy chọn có tối ưu bàn phím hay không?
        /// </summary>
        private bool ToiUuBanPhim;
        /// <summary>
        /// Tùy chọn có bật chức năng lưu vết không
        /// </summary>
        private bool CoLuuVet = false;
        /// <summary>
        /// Giá trị làm tròn tiền tới bao nhiêu
        /// </summary>
        private int LamTronTien;

        /// <summary>
        /// Biến lưu thông tin tải lần đầu tiên
        /// </summary>
        private bool TaiLanDau = true;

        /// <summary>
        /// Tùy chọn có tự động in pha chế hay không?
        /// </summary>
        private bool TuDongInPhaChe = false;

        /// <summary>
        /// Thời gian tự động in pha chế
        /// </summary>
        private int SoGiayTuDongInPhaChe = 0;

        /// <summary>
        /// Có cây hiển thị giá hay không
        /// </summary>
        bool coManHienThi = false;

        bool hienThi3Nhom = false;
        /// <summary>
        /// Cổng sử dụng cho cây hiển thị giá
        /// </summary>
        private string congSuDung = "";
        /// <summary>
        /// Có làm tròn mặt hàng dịch vụ không?
        /// </summary>
        private int lamTronMatHangDichVu;
        private CachLamTron cachLamTronMatHangDichVu;

        enum CachLamTron
        {
            LamTronXuong = 0,
            LamTronGiua = 1,
            LamTronLen = 2
        }

        private string _currentDonHangID = "";
        private TDONHANGRow _currentDonHangRow = null;

        /// <summary>
        /// ID của đơn hàng đang mở
        /// </summary>
        public string ID
        {
            get { return !string.IsNullOrEmpty(_currentDonHangID) ? _currentDonHangID : (mapper != null ? mapper.ID : ""); }
            set { _currentDonHangID = value; try { if (mapper != null) mapper.ID = value; } catch { } }
        }

        private HoaDonMode mode = HoaDonMode.SuDungDichVu;
        public HoaDonMode Mode
        {
            get { return mode; }
            set 
            {                
                if (value == HoaDonMode.QuanLyBanHang)
                {
                    btnChuyenBan.Visible = false;
                    btnGopBan.Visible = false;
                    btnThongKe.Visible = false;
                    btnThanhToan.Top = btnThongKe.Top - 4;
                }
                else if (value == HoaDonMode.DieuChinhHoaDon)
                {
                    btnChuyenBan.Visible = false;
                    btnGopBan.Visible = false;
                    btnThongKe.Visible = false;
                    btnThanhToan.Top = btnThongKe.Top - 4;                    
                    pnlTongCong.Enabled = false;
                    btnGiam.Visible = false;
                    btnXoa.Visible = false;
                    tsbDoiGiaBan.Visible = false;
                    tsbGiam1.Visible = false;
                    tsbNote.Visible = false;
                    tsbCK.Visible = false;
                    ToolStripSeparator1.Visible = false;
                    btnTheoNhom.Visible = false;
                    tsbDatSoLuong.Visible = false;
                    txtNOTE.Enabled = false;

                    if (DbUtils.CanView(Functions.ThayDoiKhachHangTrongDieuChinhHoaDon))
                    {
                        foreach (Control c in pnlHeader.Controls)
                        {
                            c.Enabled = c == lueDKHACHHANGID;
                        }
                    }
                    else
                    {
                        pnlHeader.Enabled = false;
                    }
                }
                else
                {
                    tmrAutoUpdateTime.Enabled = Shared.CoTienGio;
                }                

                mode = value;
            }
        }

        /// <summary>
        /// thông số làm tròn khối lượng cân
        /// </summary>
        int iRounding = 3;
        /// <summary>
        /// điểm bắt đầu tính khối lượng dựa trên dữ liệu cân đẩy vào
        /// </summary>
        int gPos;
        /// <summary>
        /// độ dài vùng khối lượng dựa trên dữ liệu cân đẩy vào tính từ điểm bắt đầu
        /// </summary>
        int gLen;

        /// <summary>
        /// Thực hiện khi form load
        /// </summary>        
        public void mapper_OnLoad(object sender, EventArgs e)
        {
            ChoPhepThayDoiGio = SystemConfig.ChoPhepDoiGioTrenBill == 30 || mode == HoaDonMode.QuanLyBanHang;
            CoLuuVet = SystemConfig.KichHoatLuuVetHoatDong == 30;            
            LamTronTien = SystemConfig.LamTronTien;
            TuDongInPhaChe = SystemConfig.TuDongInPhaCheSauKhiGoiMon == 30 && mode == HoaDonMode.SuDungDichVu;
            SoGiayTuDongInPhaChe = SystemConfig.ThoiGianTuDongIn;
            coManHienThi = SystemConfig.CoCayHienThiGia == 30;
            hienThi3Nhom = SystemConfig.HienThi3NhomOGiaoDienBanHang == 30;
            CoDungCanDienTu = SystemConfig.KichHoatSuDungCanDienTu == 30;
            btnTamUng.Visible = SystemConfig.SuDungChucNangTamUngTrongDonHang == 30;
            if (coManHienThi) congSuDung = SystemConfig.CongSuDung;

            lamTronMatHangDichVu = SystemConfig.LamTronMatHangDichVuTheoGio;
            cachLamTronMatHangDichVu = (CachLamTron)SystemConfig.CachLamTronDichVuTheoGio;

            btnChuyenBan.Text = btnChuyenBan.Text.Replace("phòng", Shared.GetTenPhongBan(true));
            btnGopBan.Text = btnGopBan.Text.Replace("phòng", Shared.GetTenPhongBan(true));

            if (!ChoPhepThayDoiGio)
            {
                btnDoiGioRa.Visible = SystemConfig.ChoPhepDoiGioRaVeSau == 30;
                btnDoiGioVao.Visible = SystemConfig.ChoPhepDoiGioVaoVeTruoc == 30;
            }

            if (hienThi3Nhom)
            {
                tvCat.Visible = false;
                //tạo tab
                TabControl tab = new TabControl();
                splitMatHang.Panel1.Controls.Add(tab);
                tab.Dock = DockStyle.Fill;
                tab.BringToFront();
                AddTab(tab, "Đồ ăn", LoaiDo.DoAn);
                AddTab(tab, "Đồ uống", LoaiDo.DoUong);
                AddTab(tab, "Dịch vụ", LoaiDo.DichVu);
                AddTab(tab, "Đồ khác", LoaiDo.DoKhac);
                tab.SelectedIndexChanged += new EventHandler(tab_SelectedIndexChanged);
            }
            else
            {
                tvCat.Visible = true;
            }

            if (CoDungCanDienTu)
            {
                lblCan.Visible = true;
                numCan.Visible = true;

                gPos = SystemConfig.ViTri;
                gLen = SystemConfig.DoDai;

                OpenComport();
            }

            AddEvent();

            grDetail.GridView.GridColor = Color.White;
            grMatHang.GridColor = Color.White;

            //thiết lập vị trí theo cấu hình
            SetupViTriTongCong();
            grMatHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

            btnInCheBien.Visible = (SystemConfig.SuDungChucNangInXuongBep == 30 || SystemConfig.SuDungChucNangInXuongBep == 1) && mode == HoaDonMode.SuDungDichVu;
            SetupToiUuBanPhim();

            grDetail.GridView.OnContextMenuShowing += new EventHandler(grDetail_OnContextMenuShowing);
            grDetail.GridView.CellFormatting += new DataGridViewCellFormattingEventHandler(GridView_CellFormatting);
            grDetail.GridView.MultiSelect = false;

            SetupGrids();
            LoadMatHangGrid();
            LoadNhomMatHangTree();
            try
            {
                txtTimKiem.TextChanged -= TxtTimKiem_TextChanged;
                txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            }
            catch { }


            dtBATDAUPHONGCUOI.BackColor = SystemColors.Window;

            //Kiểm tra quyền xem đơn giá - nhân viên chạy bàn
            bool xemDonGia = DbUtils.CanView(Functions.XemDonGiaTrongHoaDonBanHang);
            if (!xemDonGia)
            {
                tabTongCong.Visible = false;
                pnlNhieuBill.Visible = false;
                btnGopBan.Visible = false;
                btnChuyenBan.Visible = false;
                btnThanhToan.Visible = false;
                lueDBANGGIAID.Visible = false;
                btnTheoNhom.Visible = false;
                grMatHang.HideColumn("GIABAN");
                prAutoPrint.Dock = DockStyle.Bottom;
                tabTongCong.Parent.Controls.Add(prAutoPrint);
                prAutoPrint.BringToFront();
            }
            
            //Nếu kích hoạt chức năng trả đồ thêm âm
            bool coKiemDo = SystemConfig.KichHoatChucNangKiemDo == 30 && mode == HoaDonMode.SuDungDichVu;

            //tsbTang1.Visible = !coKiemDo;
            bool khongKiemDo = !coKiemDo && mode == HoaDonMode.SuDungDichVu;

            tsbGiam1.Visible = khongKiemDo || mode == HoaDonMode.QuanLyBanHang;
            tsbDatSoLuong.Visible = khongKiemDo || mode == HoaDonMode.QuanLyBanHang;
            btnXoa.Visible = khongKiemDo || mode == HoaDonMode.QuanLyBanHang;
            btnGiam.Visible = khongKiemDo || mode == HoaDonMode.QuanLyBanHang;
            tsbKiemDo.Visible = coKiemDo || mode == HoaDonMode.DieuChinhHoaDon;

            if (mode == HoaDonMode.DieuChinhHoaDon)
            {
                tsbKiemDo.Text = "Trả đồ";
            }

            CachChonKhachHang cachChon = mode == HoaDonMode.SuDungDichVu ? (CachChonKhachHang)SystemConfig.CachChonKhachHang : CachChonKhachHang.ChuotVaBanPhim;
            lueDKHACHHANGID.ReadOnly = cachChon != CachChonKhachHang.ChuotVaBanPhim;
            btnSearch.Visible = cachChon == CachChonKhachHang.SuDungTheTu;
            if (btnSearch.Visible) btnSearch.BringToFront();
            btnSearch.Click += new EventHandler(btnSearch_Click);
        }

        No1TreeTable filterTv;
        void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterTv = (sender as TabControl).SelectedTab.Controls[0] as No1TreeTable;
            grMatHang.Filter = grMatHang.Filter;
        }

        private void AddTab(TabControl tab, string title, LoaiDo loaiDo)
        {
            TabPage page = new TabPage(title);
            No1TreeTable tv = new No1TreeTable();
            tv.Dock = DockStyle.Fill;
            tv.Table = Tables.DNHOMMATHANG;
            tv.CustomLoadData += new CustomLoadDataHandler(delegate(object sender, CustomLoadDataArgs e)
            {
                e.And("DLOAIDOID = '" + ((int)loaiDo).ToString() + "'");
            });
            tv.ShowAllNode = true;
            tv.ReadOnly = true;
            tv.OnFocusedNodeChanged += new No1TreeTable.OnFocusedNodeChangedHandler(tv_OnFocusedNodeChanged);
            page.Controls.Add(tv);
            tv.LoadData();
            tab.Controls.Add(page);
        }

        string SelectedNhomID = "";
        void tv_OnFocusedNodeChanged(TreeNode node, DataRow r, string ID, TreeItemType type)
        {
            txtTimKiem.Text = "";
            SelectedNhomID = ID;
            filterTv = null;
            grMatHang.Filter = grMatHang.Filter;
        }        

        private static SerialPort comport;
        BackgroundWorker bw;
        private void OpenComport()
        {
            try
            {
                if (comport != null)
                {
                    return;
                }
                else
                {
                    string com = SystemConfig.CongCom;

                    if (com.Length == 0)
                    {
                        Msg.ShowWarning("Bạn chưa thiết lập kết nối tới cân điện tử" + Environment.NewLine +
                            "Bạn vui lòng thiết lập trong 'Quản trị | Cấu hình toàn hệ thống'");
                    }
                    else
                    {
                        comport = new SerialPort();
                        comport.NewLine = "\r";

                        int baudRate = SystemConfig.BaudRate;
                        int dataBit = SystemConfig.Databit;
                        int timeOut = SystemConfig.Timeout;
                        int parity = SystemConfig.Parity;
                        int stopBit = SystemConfig.StopBits;

                        comport.BaudRate = baudRate == 0 ? 1200 : (baudRate == 1 ? 2400 : (baudRate == 2 ? 4800 : 9600));
                        comport.ReceivedBytesThreshold = 1;
                        comport.DataBits = dataBit;
                        comport.StopBits = (StopBits)stopBit;
                        comport.Parity = (Parity)parity;
                        comport.PortName = com;
                        comport.ReadTimeout = timeOut;
                        //comport.DataReceived += port_DataReceived;
                        comport.Open();
                        bw = new BackgroundWorker();
                        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                        bw.RunWorkerAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                comport = null;
                Msg.ShowWarning("Không thể kết nối tới cân: " + Environment.NewLine + ex.Message);
            }
        }

        bool closed = false;
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closed)
            {
                try
                {
                    string data = "";
                    data = comport.ReadLine();
                    //File.AppendAllText(file, DateTime.Now.ToString("HH:mm:ss") + " - " + data + Environment.NewLine);
                    decimal strTotalWeight = parsingdata(data);
                    numCan.Invoke(new MethodInvoker(delegate
                    {
                        decimal val = Math.Round(strTotalWeight / (decimal)1000, 3);
                        numCan.Value = val;                        
                    }));
                }
                catch (Exception ex)
                {                    
                }
            }
        }

        private decimal parsingdata(string sData)
        {
            try
            {
                string strResult = "";
                double dWeight = 0.0;
                //if (sData.Contains("g") || sData.Contains("G"))
                {
                    strResult = sData.Substring(gPos, gLen).Trim();
                    dWeight = Math.Round(double.Parse(strResult), iRounding);
                    return (decimal)dWeight;
                }

                if ((iRounding == 0) || (iRounding == 2) || (iRounding == 1))
                {
                    dWeight = Math.Round(double.Parse(strResult), iRounding);
                }
                else if (iRounding == 3)
                {
                    dWeight = Math.Round((double)(double.Parse(strResult) / (double)10), 0) * 10;
                }
                else if (iRounding == 4)
                {
                    //dWeight = 100 * decimal.Parse(strResult) * Share.HSCan / 100);
                    dWeight = Math.Round((double)(double.Parse(strResult) / (double)100), 0) * 100;
                }
                else
                {
                    double sTMP = double.Parse(strResult);
                    if ((sTMP % Math.Truncate(sTMP)) < 0.5)
                    {
                        dWeight = Math.Truncate(sTMP) + 0.5;
                    }
                    else
                    {
                        dWeight = Math.Truncate(sTMP) + 1.0;
                    }
                }
                return (decimal)dWeight;
            }
            catch (Exception ex)
            {
                //File.AppendAllText(Application.StartupPath + "\\Data\\log.txt", DateTime.Now.ToString("HH:mm:ss") + "-" + ex.Message + Environment.NewLine);
                return 0;
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            ChonKhachHangQuaThe form = (ChonKhachHangQuaThe)Config.CreateForm(Forms.ChonKhachHangQuaThe);
            if (form.form.ShowDialog() == DialogResult.OK)
            {
                lueDKHACHHANGID.EditValue = form.DKHACHHANGID;
                CapNhatGiamGia(lueDKHACHHANGID.StringValue);
            }
        }
        
        /// <summary>
        /// Bôi màu cho các mặt hàng
        /// </summary>        
        void GridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || grDetail?.GridView == null || e.RowIndex >= grDetail.GridView.Rows.Count) return;
                var view = grDetail.GridView.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (view == null) return;
                DataRow r = view.Row;
                if (r == null || r.RowState == DataRowState.Detached || r.RowState == DataRowState.Deleted) return;

                string loai = r.Table.Columns.Contains("DMATHANG_DLOAIMATHANGID") ? (r["DMATHANG_DLOAIMATHANGID"]?.ToString() ?? "") : "";                        
                if (loai == "4")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (loai == "5")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    string DMATHANGID = r.Table.Columns.Contains("DMATHANGID") ? (r["DMATHANGID"]?.ToString() ?? "") : "";
                    if (DMATHANGID == "KM")
                    {
                        e.CellStyle.BackColor = Color.LightYellow;
                    }
                }
            }
            catch { }
        }

        ToolStripMenuItem mnuChuyenMotPhanSangHoaDonKhac;
        ToolStripMenuItem mnuChuyenTatCaSangHoaDonKhac;
        void grDetail_OnContextMenuShowing(object sender, EventArgs e)
        {
            if (mnuChuyenMotPhanSangHoaDonKhac == null)
            {
                mnuChuyenMotPhanSangHoaDonKhac = new ToolStripMenuItem("Chuyển một phần sang hóa đơn khác");
                string sql = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAABYlBMVEUAAABVVVVmZmZGRkZDQ0M/Rk0+S1I5TFkpYo8nX48mYJIkY5Meaagda6gfaageaascb7Acbq8aarAbbLEbbbEYbrQZb7MSdsgQdssPeMoQes0ReMcRecwLfdsLf94LgN4LgN8Lgd8Lgd8MfNsMfdgMfdoMftgAjv8Aj/8AkP8Akf8Akv8Ak/8AlP8Alf8Alv8Al/8AmP8Amf8Amv8AnP8Bjv0Bj/sBj/0BkPwBkf0BkvsBkvwBkv0Bk/sBk/0CkfkCkfoClPoClfkCmPkCmPoCmvoCm/kCnPoCnfkIg+gIheoIh+oIh+wLgt8Mgd4MlO4Nlu0QetIRetEWj9wWkdsejd0ij9xjns1kn81rocluosp1pcZ2pcZ2psh4pcZ5p8d6qMl+qch+qsh/rMh/rsiCq8mCrcmCrsmCr8mCsMmJs8uMtcylvdHY2dzY2t3h4eL7+/z8/P39/f39/f7+/v7+/v+ivn+FAAAAJ3RSTlMAAwUSEyQlKD5AQkWFioqPrK2vsbGys+Lk5+fp6ff4+Pn5+v7+/v6ofSUDAAAA0ElEQVQYGQXBu07DQBRF0X3uHSI7BgKEVCAEKA1VREPH/zd8ADRROh5BdgSOX8QzrCUAzJwxRgABFMXkUS9D0wACZvNMIqX2+xccZs+1u9tDPKw+e5xiUXtwv7madu8+HIJNF5nLLej8fox5F2xydyJJZnaxfK0s+NPlkSSRkubLsjQEAAAkS65yMfZ910VZ+lp/7EMc1oVcdnwdt5tdH0Nst7W7KYvlptx3yfkbV2VKaZdtqtu3BgGnZ7kBsalqEECeTwr7GdoOEAAyTzEmgH+w31iNKcifOQAAAABJRU5ErkJggg==";
                Image img = UiUtils.GetImageFromBase64(sql);
                mnuChuyenMotPhanSangHoaDonKhac.Image = img;
                mnuChuyenMotPhanSangHoaDonKhac.Click += new EventHandler(mnuChuyenMotPhanSangHoaDonKhac_Click);                
                mnuChuyenTatCaSangHoaDonKhac = new ToolStripMenuItem("Chuyển tất cả sang hóa đơn khác");
                mnuChuyenTatCaSangHoaDonKhac.Image = img;
                mnuChuyenTatCaSangHoaDonKhac.Click += new EventHandler(mnuChuyenTatCaSangHoaDonKhac_Click);
                grDetail.GridView.ContextMenuStripEx.Items.Insert(0, mnuChuyenTatCaSangHoaDonKhac);
                grDetail.GridView.ContextMenuStripEx.Items.Insert(0, mnuChuyenMotPhanSangHoaDonKhac);
            }

            bool coTheChuyen = CoTheChuyenMatHang();

            mnuChuyenMotPhanSangHoaDonKhac.Enabled = coTheChuyen;
            mnuChuyenTatCaSangHoaDonKhac.Enabled = coTheChuyen;
        }

        private bool CoTheChuyenMatHang()
        {
            if (grDetail.GridView.SelectedRows.Count == 0 || !btnThanhToan.Enabled) return false;
            if (mode != HoaDonMode.SuDungDichVu) return false;
            DataRow r = grDetail.GridView.SelectedRow;
            string DMATHANGID = r["DMATHANGID"].ToString();
            DMATHANGRow mhRow = new DMATHANGRow(DMATHANGID);
            LoaiMatHang loai = (LoaiMatHang)ConvertTo.Int(mhRow.DLOAIMATHANGID);
            return loai == LoaiMatHang.DichVu || loai == LoaiMatHang.MatHangKiemVatTu ||
                loai == LoaiMatHang.MatHangMo || loai == LoaiMatHang.DinhLuong;
        }

        /// <summary>
        /// Chuyển tất cả sang hóa đơn khác
        /// </summary>
        void mnuChuyenTatCaSangHoaDonKhac_Click(object sender, EventArgs e)
        {
            if (!DbUtils.CanLogin(Functions.ChuyenMatHangSangHoaDonKhac)) return;
            if (DaThanhToan(true)) return;

            if (!DuocPhepGiamDo()) return;
            if (KiemTraDaInTamTinh())
            {
                Msg.ShowWarning("Không thể chuyển hóa đơn vì phiếu đã in tạm tính");
                return;
            }

            TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(grDetail.GridView.SelectedRow);
            //nếu combo thì không cho chuyển
            if (IsCombo(row))
            {
                Msg.ShowWarning("Không thể phép thực hiện chức năng này với mặt hàng combo");
                return;
            }

            string ID = grDetail.SelectedID;

            No1Run.ChuyenBan form = (No1Run.ChuyenBan)Config.CreateForm(Forms.ChuyenBan);
            form.SetData(ID, ChuyenGopBanMode.ChuyenMatHang);
            if (form.No1Form1.ShowDialog() == DialogResult.OK)
            {
                Reload(mapper.ID, "");
            }
        }

        /// <summary>
        /// Chuyển một phần sang hóa đơn khác
        /// </summary>        
        void mnuChuyenMotPhanSangHoaDonKhac_Click(object sender, EventArgs e)
        {
            if (!DbUtils.CanLogin(Functions.ChuyenMatHangSangHoaDonKhac)) return;
            if (!DuocPhepGiamDo()) return;
            if (KiemTraDaInTamTinh())
            {
                Msg.ShowWarning("Không thể chuyển hóa đơn vì phiếu đã in tạm tính");
                return;
            }

            if (DaThanhToan(true)) return;

            TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(grDetail.GridView.SelectedRow);            
            //nếu combo thì không cho chuyển
            if (IsCombo(row))
            {
                Msg.ShowWarning("Không thể phép thực hiện chức năng này với mặt hàng combo");
                return;
            }

            //nhap so luong se chuyen
            NhapSoLuongNhaHang frmNhapSl = (NhapSoLuongNhaHang)Config.CreateForm(Forms.NhapSoLuongNhaHang);
            frmNhapSl.MaxValue = row.SLXUATCHUAQUYDOI;
            frmNhapSl.lblItem.Text = frmNhapSl.lblItem.Text + row.TENHANG;
            frmNhapSl.No1Form1.Text = "NHẬP SỐ LƯỢNG CHUYỂN";
            if (frmNhapSl.No1Form1.ShowDialog() != DialogResult.OK) return;

            decimal soLuong = frmNhapSl.SoLuong;
            No1Run.ChuyenBan form = (No1Run.ChuyenBan)Config.CreateForm(Forms.ChuyenBan);
            form.SetData(row.ID, ChuyenGopBanMode.ChuyenMatHang);
            form.SoLuongChuyen = soLuong;
            if (form.No1Form1.ShowDialog() == DialogResult.OK)
            {
                Reload(mapper.ID, "");
            }
        }        

        public event OnLockTableRequestHandler OnLockTableRequest;

        public delegate void OnLockTableRequestHandler(string DBANID);
        public delegate void OnNoteChangedHandler(string DBANID, string Note);
        /// <summary>
        /// Đăng ký các sự kiện
        /// </summary>
        private void AddEvent()
        {
            grMatHang.KeyDown += new KeyEventHandler(grMatHang_KeyDown);
            grMatHang.SelectionChanged += new EventHandler(grMatHang_SelectionChanged);
            grMatHang.CellMouseDown += new DataGridViewCellMouseEventHandler(grMatHang_CellMouseDown);
            grMatHang.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(grMatHang_CellMouseDoubleClick);
            grDetail.GridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(grDetail_CellMouseDoubleClick);
            grDetail.GridView.SelectionChanged += new EventHandler(grDetail_SelectionChanged);
            tvCat.tvMain.Enter += new EventHandler(tvMain_Enter);
            tvCat.tvMain.LabelEdit = false;

            // Các nút thao tác ở thanh giữa (pnlButton)
            btnThem.Click -= btnThem_Click;
            btnThem.Click += btnThem_Click;

            btnGiam.Click -= btnGiam_Click;
            btnGiam.Click += btnGiam_Click;

            btnXoa.Click -= btnXoa_Click;
            btnXoa.Click += btnXoa_Click;

            btnChuyenBan.Click -= btnChuyenBan_Click;
            btnChuyenBan.Click += btnChuyenBan_Click;

            btnGopBan.Click -= btnGopBan_Click;
            btnGopBan.Click += btnGopBan_Click;

            btnThanhToan.Click -= btnThanhToan_Click;
            btnThanhToan.Click += btnThanhToan_Click;

            btnThongKe.Click -= btnThongKe_Click;
            btnThongKe.Click += btnThongKe_Click;

            btnTheoNhom.Click -= btnTheoNhom_Click;
            btnTheoNhom.Click += btnTheoNhom_Click;

            btnBatDau.Click -= btnBatDau_Click;
            btnBatDau.Click += btnBatDau_Click;

            btnInLaiBill.Click -= btnInLaiBill_Click;
            btnInLaiBill.Click += btnInLaiBill_Click;

            btnInCheBien.Click -= btnInCheBien_Click;
            btnInCheBien.Click += btnInCheBien_Click;

            btnDoiGioVao.Click -= btnDoiGioVao_Click;
            btnDoiGioVao.Click += btnDoiGioVao_Click;

            btnDoiGioRa.Click -= btnDoiGioRa_Click;
            btnDoiGioRa.Click += btnDoiGioRa_Click;

            btnTamUng.Click -= btnTamUng_Click;
            btnTamUng.Click += btnTamUng_Click;

            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            // Các nút trên thanh công cụ của hóa đơn chi tiết (toolDetail)
            tsbTang1.Click -= tsbTang1_Click;
            tsbTang1.Click += tsbTang1_Click;

            tsbGiam1.Click -= tsbGiam1_Click;
            tsbGiam1.Click += tsbGiam1_Click;

            tsbDatSoLuong.Click -= tsbDatSoLuong_Click;
            tsbDatSoLuong.Click += tsbDatSoLuong_Click;

            tsbDoiGiaBan.Click -= tsbDoiGiaBan_Click;
            tsbDoiGiaBan.Click += tsbDoiGiaBan_Click;

            tsbNote.Click -= tsbNote_Click;
            tsbNote.Click += tsbNote_Click;

            tsbCK.Click -= tsbCK_Click;
            tsbCK.Click += tsbCK_Click;

            tsbKiemDo.Click -= tsbTraLai_Click;
            tsbKiemDo.Click += tsbTraLai_Click;

            // Các nút trên thanh công cụ giờ và nhân viên
            tsbDieuChinhGio.Click -= tsbDieuChinhGio_Click;
            tsbDieuChinhGio.Click += tsbDieuChinhGio_Click;

            tsbRefresh.Click -= tsbRefresh_Click;
            tsbRefresh.Click += tsbRefresh_Click;

            tsbVaoPhong.Click -= tsbVaoPhong_Click;
            tsbVaoPhong.Click += tsbVaoPhong_Click;

            // EditValue changed events
            lueDKHACHHANGID.OnEditValueChanged -= lueDKHACHHANGID_OnEditValueChanged;
            lueDKHACHHANGID.OnEditValueChanged += lueDKHACHHANGID_OnEditValueChanged;

            dtBATDAUPHONGCUOI.OnEditValueChanged -= dtBATDAUPHONGCUOI_OnEditValueChanged;
            dtBATDAUPHONGCUOI.OnEditValueChanged += dtBATDAUPHONGCUOI_OnEditValueChanged;

            dtKETTHUC.OnEditValueChanged -= dtBATDAUPHONGCUOI_OnEditValueChanged;
            dtKETTHUC.OnEditValueChanged += dtBATDAUPHONGCUOI_OnEditValueChanged;

            numTIENGIAMGIA.OnEditValueChanged -= numTIENGIAMGIA_OnEditValueChanged;
            numTIENGIAMGIA.OnEditValueChanged += numTIENGIAMGIA_OnEditValueChanged;

            numTILEGIAMGIA.OnEditValueChanged -= numTILEGIAMGIA_OnEditValueChanged;
            numTILEGIAMGIA.OnEditValueChanged += numTILEGIAMGIA_OnEditValueChanged;

            numTILEGIAMGIAGIO.OnEditValueChanged -= numTILEGIAMGIAGIO_OnEditValueChanged;
            numTILEGIAMGIAGIO.OnEditValueChanged += numTILEGIAMGIAGIO_OnEditValueChanged;

            numTIENGIAMGIAGIO.OnEditValueChanged -= numTIENGIAMGIAGIO_OnEditValueChanged;
            numTIENGIAMGIAGIO.OnEditValueChanged += numTIENGIAMGIAGIO_OnEditValueChanged;

            numPHIDICHVU.OnEditValueChanged -= numPHIDICHVU_OnEditValueChanged;
            numPHIDICHVU.OnEditValueChanged += numPHIDICHVU_OnEditValueChanged;

            numTILEPHIDICHVU.OnEditValueChanged -= numTILEPHIDICHVU_OnEditValueChanged;
            numTILEPHIDICHVU.OnEditValueChanged += numTILEPHIDICHVU_OnEditValueChanged;

            numTILEGIAMGIATONG.OnEditValueChanged -= numTILEGIAMGIATONG_OnEditValueChanged;
            numTILEGIAMGIATONG.OnEditValueChanged += numTILEGIAMGIATONG_OnEditValueChanged;

            numTIENGIAMGIATONG.OnEditValueChanged -= numTIENGIAMGIATONG_OnEditValueChanged;
            numTIENGIAMGIATONG.OnEditValueChanged += numTIENGIAMGIATONG_OnEditValueChanged;

            txtNOTE.TextChanged -= txtNOTE_TextChanged;
            txtNOTE.TextChanged += txtNOTE_TextChanged;

            tabTongCong.SelectedPageChanged -= tabTongCong_SelectedPageChanged;
            tabTongCong.SelectedPageChanged += tabTongCong_SelectedPageChanged;

            numSoLuong.KeyDown -= numSoLuong_KeyDown;
            numSoLuong.KeyDown += numSoLuong_KeyDown;

            tmrAutoPrint.Tick -= tmrAutoPrint_Tick;
            tmrAutoPrint.Tick += tmrAutoPrint_Tick;

            tmrAutoUpdateTime.Tick -= tmrAutoUpdateTime_Tick;
            tmrAutoUpdateTime.Tick += tmrAutoUpdateTime_Tick;

            if (mapper != null)
            {
                mapper.OnCalculation -= mapper_OnCalculation;
                mapper.OnCalculation += mapper_OnCalculation;
            }
        }

        bool needResetFilterOnEnter = false;
        void tvMain_Enter(object sender, EventArgs e)
        {
            if (needResetFilterOnEnter)
            {
                if (txtTimKiem.Text.Length > 0) txtTimKiem.Text = "";
                else grMatHang.Filter = txtTimKiem.Text;
            }
            needResetFilterOnEnter = false;
        }

        private bool GopChungChietKhauLamMot;
        /// <summary>
        /// Thiết lập vị trí vùng tổng cộng 
        /// </summary>
        private void SetupViTriTongCong()
        {
            GopChungChietKhauLamMot = SystemConfig.GopChungGiamGiaTienGioVaTienHangLamMot == 30;
            if (SystemConfig.GiuNguyenGiaoDienNhuThietKe == 0)
            {
                List<ArrangeItem> lst = new List<ArrangeItem>();
                lst.Add(new ArrangeItem(SystemConfig.BatBuocNhapNhanVienBanHang == 30, lblDNHANVIENXUATID, lueDNHANVIENXUATID));
                lst.Add(new ArrangeItem(SystemConfig.BatChucNangKiemSoatOrder == 30, lblSOORDER, txtSOORDER, lblSoOrderHint));

                pnlHeader.Height = UiUtils.ArrangeControl(lst, lueDNHANVIENXUATID.Top - lueDKHACHHANGID.Bottom, lueDNHANVIENXUATID.Top);

                //thiết lập vùng phía dưới
                lst = new List<ArrangeItem>();
                lst.Add(new ArrangeItem(true, lblTIENHANG, numTIENHANG));
                lst.Add(new ArrangeItem(Shared.CoTienGio, lblTIENGIO, numTIENGIO));

                lst.Add(new ArrangeItem(!GopChungChietKhauLamMot, lblTILEGIAMGIA, numTILEGIAMGIA, lblTIENGIAMGIA, numTIENGIAMGIA));
                lst.Add(new ArrangeItem(Shared.CoTienGio && !GopChungChietKhauLamMot, lblTILEGIAMGIAGIO, lblTienGiamGiaGio, numTILEGIAMGIAGIO, numTIENGIAMGIAGIO));
                lst.Add(new ArrangeItem(GopChungChietKhauLamMot, lblTILEGIAMGIATONG, numTILEGIAMGIATONG, lblTIENGIAMGIATONG, numTIENGIAMGIATONG));
                lst.Add(new ArrangeItem(SystemConfig.CoPhiDichVu == 30, lblTILEPHIDICHVU, numTILEPHIDICHVU, lblPHIDICHVU, numPHIDICHVU));
                lst.Add(new ArrangeItem(SystemConfig.CoThueSuat == 30, lblTILETHUE, numTILETHUE, lblTIENTHUE, numTIENTHUE));
                lst.Add(new ArrangeItem(true, lblTONGCONG, numTONGCONG));

                int h = UiUtils.ArrangeControl(lst, numTIENGIO.Top - numTIENHANG.Bottom, lblTIENHANG.Top);
                tabTongCong.Height = h;
            }
            else
            {
                lblTILEGIAMGIA.Visible = numTILEGIAMGIA.Visible = lblTIENGIAMGIA.Visible = numTIENGIAMGIA.Visible = !GopChungChietKhauLamMot;
                lblTILEGIAMGIAGIO.Visible = lblTienGiamGiaGio.Visible = numTILEGIAMGIAGIO.Visible = numTIENGIAMGIAGIO.Visible = Shared.CoTienGio && !GopChungChietKhauLamMot;
                lblTILEGIAMGIATONG.Visible = numTILEGIAMGIATONG.Visible = lblTIENGIAMGIATONG.Visible = numTIENGIAMGIATONG.Visible = GopChungChietKhauLamMot;
            }
        }

        /// <summary>
        /// Thiết lập hiển thị các control theo tùy chọn tối ưu sử dụng bàn phím
        /// </summary>
        private void SetupToiUuBanPhim()
        {
            ToiUuBanPhim = SystemConfig.ToiUuDungBanPhim == 30;

            if (!ToiUuBanPhim)
            {
                lblComboSl.Visible = true;
                cboSoLuong.Visible = true;
                numSoLuong.Visible = false;
                lblSoLuong.Visible = false;
                txtTimKiem.Width = pnlTim.Width - txtTimKiem.Left - 5;
                txtTimKiem.EnterKeyNextControl = false;
            }
        }

        /// <summary>
        /// Kiểm tra xem hóa đơn đã thanh toán chưa
        /// </summary>
        /// <param name="TDONHANGID">ID của hóa đơn</param>
        /// <returns>True nếu đã thanh toán</returns>
        public static bool IsDaThanhToan(string TDONHANGID)
        {
            return Config.Db.GetFirstFieldInt("SELECT DATHANHTOAN FROM TDONHANG WHERE ID = '" + TDONHANGID + "'") == 30;
        }

        private void SetupGrids()
        {
            try
            {
                // Setup grMatHang columns
                if (grMatHang != null && grMatHang.Columns.Count == 0)
                {
                    grMatHang.AutoGenerateColumns = false;
                    grMatHang.Columns.Clear();

                    var colName = new DataGridViewTextBoxColumn
                    {
                        Name = "NAME",
                        DataPropertyName = "NAME",
                        HeaderText = "Tên hàng",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    var colDvt = new DataGridViewTextBoxColumn
                    {
                        Name = "DVT_NAME",
                        DataPropertyName = "DVT_NAME",
                        HeaderText = "ĐVT",
                        Width = 45
                    };
                    colDvt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    var colGia = new DataGridViewTextBoxColumn
                    {
                        Name = "GIABAN",
                        DataPropertyName = "GIABAN",
                        HeaderText = "Giá bán",
                        Width = 75
                    };
                    colGia.DefaultCellStyle.Format = "N0";
                    colGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    var colCode = new DataGridViewTextBoxColumn
                    {
                        Name = "CODE",
                        DataPropertyName = "CODE",
                        HeaderText = "Mã hàng",
                        Width = 65
                    };

                    var colId = new DataGridViewTextBoxColumn
                    {
                        Name = "ID",
                        DataPropertyName = "ID",
                        Visible = false
                    };
                    var colNhom = new DataGridViewTextBoxColumn
                    {
                        Name = "DNHOMMATHANGID",
                        DataPropertyName = "DNHOMMATHANGID",
                        Visible = false
                    };

                    grMatHang.Columns.AddRange(new DataGridViewColumn[] { colName, colDvt, colGia, colCode, colId, colNhom });
                    grMatHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grMatHang.MultiSelect = false;
                    grMatHang.ReadOnly = true;
                    grMatHang.AllowUserToAddRows = false;
                    grMatHang.RowHeadersVisible = false;
                }

                // Setup grDetail inner grid columns
                var gridDetail = grDetail?.GridView;
                if (gridDetail != null && gridDetail.Columns.Count == 0)
                {
                    gridDetail.AutoGenerateColumns = false;
                    gridDetail.Columns.Clear();

                    var colStt = new DataGridViewTextBoxColumn
                    {
                        Name = "SOTT",
                        DataPropertyName = "SOTT",
                        HeaderText = "STT",
                        Width = 35
                    };
                    colStt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    var colTenHang = new DataGridViewTextBoxColumn
                    {
                        Name = "MATHANG",
                        DataPropertyName = "MATHANG",
                        HeaderText = "Tên hàng",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };

                    var colDvt = new DataGridViewTextBoxColumn
                    {
                        Name = "DVT",
                        DataPropertyName = "DVT",
                        HeaderText = "ĐVT",
                        Width = 45
                    };
                    colDvt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    var colSl = new DataGridViewTextBoxColumn
                    {
                        Name = "SOLUONG",
                        DataPropertyName = "SOLUONG",
                        HeaderText = "SL",
                        Width = 45
                    };
                    colSl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colSl.DefaultCellStyle.Format = "N0";

                    var colGia = new DataGridViewTextBoxColumn
                    {
                        Name = "DONGIA",
                        DataPropertyName = "DONGIA",
                        HeaderText = "Đ giá",
                        Width = 75
                    };
                    colGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colGia.DefaultCellStyle.Format = "N0";

                    var colGiam = new DataGridViewTextBoxColumn
                    {
                        Name = "TILEGIAMGIA",
                        DataPropertyName = "TILEGIAMGIA",
                        HeaderText = "CK%",
                        Width = 45
                    };
                    colGiam.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colGiam.DefaultCellStyle.Format = "N0";

                    var colThanhTien = new DataGridViewTextBoxColumn
                    {
                        Name = "THANHTIEN",
                        DataPropertyName = "THANHTIEN",
                        HeaderText = "T tiền",
                        Width = 85
                    };
                    colThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    colThanhTien.DefaultCellStyle.Format = "N0";

                    var colNote = new DataGridViewTextBoxColumn
                    {
                        Name = "NOTE",
                        DataPropertyName = "NOTE",
                        HeaderText = "Ghi chú",
                        Width = 80
                    };

                    var colInCheBien = new DataGridViewCheckBoxColumn
                    {
                        Name = "INCHEBIEN",
                        DataPropertyName = "INCHEBIEN_BOOL",
                        HeaderText = "Bếp",
                        Width = 40,
                        TrueValue = true,
                        FalseValue = false
                    };

                    var colId = new DataGridViewTextBoxColumn
                    {
                        Name = "ID",
                        DataPropertyName = "ID",
                        Visible = false
                    };

                    var colMhId = new DataGridViewTextBoxColumn
                    {
                        Name = "DMATHANGID",
                        DataPropertyName = "DMATHANGID",
                        Visible = false
                    };

                    var colSlChuaQuyDoi = new DataGridViewTextBoxColumn
                    {
                        Name = "SLXUATCHUAQUYDOI",
                        DataPropertyName = "SLXUATCHUAQUYDOI",
                        Visible = false
                    };

                    gridDetail.Columns.AddRange(new DataGridViewColumn[] {
                        colStt, colTenHang, colDvt, colSl, colGia, colGiam, colThanhTien, colNote, colInCheBien, colId, colMhId, colSlChuaQuyDoi
                    });
                    gridDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    gridDetail.MultiSelect = false;
                    gridDetail.ReadOnly = true;
                    gridDetail.AllowUserToAddRows = false;
                    gridDetail.RowHeadersVisible = false;
                }

                if (gridDetail != null)
                {
                    gridDetail.DataError -= GridDetail_DataError;
                    gridDetail.DataError += GridDetail_DataError;
                    foreach (DataGridViewColumn col in gridDetail.Columns)
                    {
                        if (col is DataGridViewCheckBoxColumn chk)
                        {
                            chk.TrueValue = true;
                            chk.FalseValue = false;
                        }
                    }
                }
                if (grMatHang != null)
                {
                    grMatHang.DataError -= GrMatHang_DataError;
                    grMatHang.DataError += GrMatHang_DataError;
                }
                if (grGioHat?.GridView != null)
                {
                    grGioHat.GridView.DataError -= GridDetail_DataError;
                    grGioHat.GridView.DataError += GridDetail_DataError;
                }

                try
                {
                    EnsureNo1LibInitialized();
                    lueDKHACHHANGID.LoadData("DKHACHHANG");
                    lueDKHACHHANGID.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("LoadData DKHACHHANG error: " + ex.Message);
                }

                try
                {
                    lueDNHANVIENXUATID.LoadData("DNHANVIEN");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("LoadData DNHANVIEN error: " + ex.Message);
                }

                if (cboSoLuong != null && cboSoLuong.Items.Count == 0)
                {
                    for (int i = 1; i <= 50; i++) cboSoLuong.Items.Add(i.ToString());
                    cboSoLuong.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SetupGrids error: " + ex.Message);
            }
        }

        private void GridDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void GrMatHang_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void LoadMatHangGrid()
        {
            try
            {
                string sqlMH = @"
                SELECT 
                    M.ID, 
                    M.CODE, 
                    M.NAME, 
                    COALESCE(D.NAME, '') AS DVT_NAME, 
                    COALESCE(M.GIABAN, 0) AS GIABAN, 
                    M.GIABAN2, 
                    M.GIABAN3, 
                    M.GIABAN4, 
                    M.DNHOMMATHANGID, 
                    M.DDONVITINHID 
                FROM DMATHANG M 
                LEFT JOIN DDONVITINH D ON M.DDONVITINHID = D.ID
                WHERE (M.STATUS = 1 OR M.STATUS = 30 OR M.STATUS IS NULL OR M.TAMKHOA = 0 OR M.TAMKHOA IS NULL)
                ORDER BY M.NAME";
                DataTable dtMH = Config.Db.GetTable(sqlMH);
                if (grMatHang != null)
                {
                    grMatHang.AutoGenerateColumns = false;
                    grMatHang.DataSource = dtMH;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadMatHangGrid error: " + ex.Message);
            }
        }

        private void LoadNhomMatHangTree()
        {
            try
            {
                if (tvCat != null)
                {
                    tvCat.ShowAllNode = true;
                    tvCat.Table = "DNHOMMATHANG";
                    tvCat.CustomLoadData -= tvCat_CustomLoadData;
                    tvCat.CustomLoadData += tvCat_CustomLoadData;
                    tvCat.OnFocusedNodeChanged -= tvCat_OnFocusedNodeChanged;
                    tvCat.OnFocusedNodeChanged += tvCat_OnFocusedNodeChanged;

                    tvCat.LoadData();

                    if (tvCat.tvMain != null)
                    {
                        tvCat.tvMain.AfterSelect -= TvMain_AfterSelect;
                        tvCat.tvMain.AfterSelect += TvMain_AfterSelect;
                        tvCat.tvMain.NodeMouseClick -= TvMain_NodeMouseClick;
                        tvCat.tvMain.NodeMouseClick += TvMain_NodeMouseClick;
                        tvCat.tvMain.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadNhomMatHangTree error: " + ex.Message);
            }
        }

        private string GetNodeId(TreeNode node)
        {
            if (node == null) return "";
            string id = "";
            try
            {
                if (tvCat != null) id = tvCat.GetID(node) ?? "";
            }
            catch { }

            if (string.IsNullOrEmpty(id))
            {
                if (node.Tag is string s) id = s;
                else if (node.Tag is DataRow r && r.Table.Columns.Contains("ID")) id = r["ID"]?.ToString() ?? "";
            }
            return id;
        }

        private void CollectNodeGroupIds(TreeNode node, List<string> groupIds)
        {
            if (node == null) return;
            string id = GetNodeId(node);
            if (!string.IsNullOrEmpty(id) && !groupIds.Contains(id))
            {
                groupIds.Add(id);
            }
            if (node.Nodes != null)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    CollectNodeGroupIds(child, groupIds);
                }
            }
        }

        private void ApplyMatHangFilter()
        {
            try
            {
                DataTable dt = grMatHang?.DataSource as DataTable;
                if (dt == null) return;

                List<string> filterParts = new List<string>();

                TreeNode selNode = tvCat?.tvMain?.SelectedNode;
                if (selNode != null && selNode.Text != "Tất cả")
                {
                    List<string> groupIds = new List<string>();
                    CollectNodeGroupIds(selNode, groupIds);
                    if (groupIds.Count == 1)
                    {
                        filterParts.Add(string.Format("DNHOMMATHANGID = '{0}'", groupIds[0]));
                    }
                    else if (groupIds.Count > 1)
                    {
                        filterParts.Add(string.Format("DNHOMMATHANGID IN ('{0}')", string.Join("','", groupIds)));
                    }
                }

                string kw = txtTimKiem?.Text?.Trim().Replace("'", "''") ?? "";
                if (!string.IsNullOrEmpty(kw))
                {
                    filterParts.Add(string.Format("(CODE LIKE '%{0}%' OR NAME LIKE '%{0}%')", kw));
                }

                dt.DefaultView.RowFilter = filterParts.Count > 0 ? string.Join(" AND ", filterParts) : "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ApplyMatHangFilter error: " + ex.Message);
            }
        }

        private void TvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ApplyMatHangFilter();
        }

        private void TvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null && tvCat?.tvMain != null)
            {
                tvCat.tvMain.SelectedNode = e.Node;
            }
            ApplyMatHangFilter();
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ApplyMatHangFilter();
        }

        private void LoadDetailGrid(string donHangId)
        {
            if (string.IsNullOrEmpty(donHangId))
            {
                if (grDetail?.GridView != null) grDetail.GridView.DataSource = null;
                return;
            }

            try
            {
                string sqlDetail = @"
                SELECT 
                    CT.ID, 
                    CT.DMATHANGID, 
                    COALESCE(NULLIF(TRIM(CT.TENHANG), ''), M.NAME, '') AS MATHANG,
                    COALESCE(NULLIF(TRIM(CT.TENHANG), ''), M.NAME, '') AS TENHANG,
                    COALESCE(NULLIF(TRIM(D.NAME), ''), D2.NAME, '') AS DVT,
                    COALESCE(NULLIF(TRIM(D.NAME), ''), D2.NAME, '') AS DDONVITINH_NAME,
                    COALESCE(NULLIF(TRIM(CT.DDONVITINHID), ''), M.DDONVITINHID, '') AS DDONVITINHID,
                    CASE 
                        WHEN COALESCE(CT.SLXUATCHUAQUYDOI, 0) > 0 THEN CT.SLXUATCHUAQUYDOI
                        WHEN COALESCE(CT.SLXUAT, 0) > 0 THEN CT.SLXUAT
                        ELSE 1 
                    END AS SOLUONG,
                    CASE 
                        WHEN COALESCE(CT.SLXUATCHUAQUYDOI, 0) > 0 THEN CT.SLXUATCHUAQUYDOI
                        WHEN COALESCE(CT.SLXUAT, 0) > 0 THEN CT.SLXUAT
                        ELSE 1 
                    END AS SLXUATCHUAQUYDOI,
                    COALESCE(CT.DONGIA, 0) AS DONGIA, 
                    COALESCE(CT.THANHTIEN, 0) AS THANHTIEN, 
                    COALESCE(CT.TILEGIAMGIA, 0) AS TILEGIAMGIA, 
                    COALESCE(CT.TIENGIAMGIA, 0) AS TIENGIAMGIA, 
                    CT.NOTE, 
                    COALESCE(CT.DTRANGTHAICHEBIENID, '0') AS DTRANGTHAICHEBIENID_RAW,
                    CT.XUATVATTU,
                    CT.GIAVON,
                    CT.TDONHANGID,
                    CT.DKHOHANGID,
                    CT.COMBOID,
                    CT.COMBOPARENTID,
                    CT.COMBOSL,
                    COALESCE(M.DLOAIMATHANGID, '0') AS DMATHANG_DLOAIMATHANGID,
                    CASE 
                        WHEN COALESCE(CT.SLXUAT, 0) > 0 THEN CT.SLXUAT
                        WHEN COALESCE(CT.SLXUATCHUAQUYDOI, 0) > 0 THEN CT.SLXUATCHUAQUYDOI
                        ELSE 1 
                    END AS SLXUAT,
                    CASE WHEN COALESCE(M.DLOAIMATHANGID, '0') = '7' THEN 30 ELSE 0 END AS THEOGIO
                FROM TDONHANGCHITIET CT
                LEFT JOIN DMATHANG M ON TRIM(CT.DMATHANGID) = TRIM(M.ID)
                LEFT JOIN DDONVITINH D ON TRIM(CT.DDONVITINHID) = TRIM(D.ID)
                LEFT JOIN DDONVITINH D2 ON TRIM(M.DDONVITINHID) = TRIM(D2.ID)
                WHERE CT.TDONHANGID = '" + donHangId + @"' 
                ORDER BY CT.TIMECREATED, CT.ID";

                DataTable dtDetail = Config.Db.GetTable(sqlDetail);
                if (dtDetail != null)
                {
                    if (!dtDetail.Columns.Contains("SOTT"))
                    {
                        dtDetail.Columns.Add("SOTT", typeof(int));
                    }
                    if (!dtDetail.Columns.Contains("INCHEBIEN"))
                    {
                        dtDetail.Columns.Add("INCHEBIEN", typeof(bool));
                    }
                    if (!dtDetail.Columns.Contains("INCHEBIEN_BOOL"))
                    {
                        dtDetail.Columns.Add("INCHEBIEN_BOOL", typeof(bool));
                    }
                    if (!dtDetail.Columns.Contains("TENHANG"))
                    {
                        dtDetail.Columns.Add("TENHANG", typeof(string));
                    }
                    if (!dtDetail.Columns.Contains("MATHANG"))
                    {
                        dtDetail.Columns.Add("MATHANG", typeof(string));
                    }
                    if (!dtDetail.Columns.Contains("DVT"))
                    {
                        dtDetail.Columns.Add("DVT", typeof(string));
                    }
                    if (!dtDetail.Columns.Contains("DDONVITINHID"))
                    {
                        dtDetail.Columns.Add("DDONVITINHID", typeof(string));
                    }
                    if (!dtDetail.Columns.Contains("DDONVITINH_NAME"))
                    {
                        dtDetail.Columns.Add("DDONVITINH_NAME", typeof(string));
                    }

                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        dtDetail.Rows[i]["SOTT"] = i + 1;
                        string val = dtDetail.Rows[i]["DTRANGTHAICHEBIENID_RAW"]?.ToString() ?? "";
                        bool isCheBien = (val == "1" || val == "30" || val.Equals("true", StringComparison.OrdinalIgnoreCase));
                        dtDetail.Rows[i]["INCHEBIEN"] = isCheBien;
                        dtDetail.Rows[i]["INCHEBIEN_BOOL"] = isCheBien;

                        string mh = dtDetail.Rows[i]["MATHANG"]?.ToString() ?? "";
                        string dvt = dtDetail.Rows[i]["DVT"]?.ToString() ?? "";
                        string mhId = dtDetail.Rows[i]["DMATHANGID"]?.ToString() ?? "";
                        string ctId = dtDetail.Rows[i]["ID"]?.ToString() ?? "";

                        // Fallback nạp tên mặt hàng và đơn vị tính nếu bị thiếu
                        if (string.IsNullOrEmpty(mh) && !string.IsNullOrEmpty(mhId))
                        {
                            try
                            {
                                DataRow rM = Config.Db.GetFirstRow("SELECT NAME, DDONVITINHID FROM DMATHANG WHERE ID = '" + mhId.Trim() + "'");
                                if (rM != null)
                                {
                                    mh = rM["NAME"]?.ToString() ?? "";
                                    dtDetail.Rows[i]["MATHANG"] = mh;
                                    dtDetail.Rows[i]["TENHANG"] = mh;
                                    string dvtId = rM["DDONVITINHID"]?.ToString() ?? "";
                                    if (!string.IsNullOrEmpty(dvtId))
                                    {
                                        dvt = Config.Db.GetFirstFieldString("SELECT NAME FROM DDONVITINH WHERE ID = '" + dvtId.Trim() + "'");
                                        dtDetail.Rows[i]["DVT"] = dvt;
                                        dtDetail.Rows[i]["DDONVITINH_NAME"] = dvt;
                                        dtDetail.Rows[i]["DDONVITINHID"] = dvtId;
                                    }
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            dtDetail.Rows[i]["TENHANG"] = mh;
                        }

                        // Sửa bền vững trong cơ sở dữ liệu nếu dòng chi tiết bị rỗng TENHANG
                        if (!string.IsNullOrEmpty(mh) && !string.IsNullOrEmpty(ctId))
                        {
                            try
                            {
                                string dvtId = dtDetail.Rows[i]["DDONVITINHID"]?.ToString() ?? "";
                                Config.Db.ExecSql(string.Format("UPDATE TDONHANGCHITIET SET TENHANG = '{0}', DDONVITINHID = '{1}' WHERE ID = '{2}' AND (TENHANG IS NULL OR TRIM(TENHANG) = '')",
                                    mh.Replace("'", "''"), dvtId.Replace("'", "''"), ctId));
                            }
                            catch { }
                        }

                        // Đảm bảo số lượng và thành tiền hợp lệ
                        decimal sl = ConvertTo.Decimal(dtDetail.Rows[i]["SLXUATCHUAQUYDOI"]);
                        if (sl <= 0)
                        {
                            sl = ConvertTo.Decimal(dtDetail.Rows[i]["SLXUAT"]);
                            if (sl <= 0) sl = 1;
                            dtDetail.Rows[i]["SLXUATCHUAQUYDOI"] = sl;
                            dtDetail.Rows[i]["SOLUONG"] = sl;
                            dtDetail.Rows[i]["SLXUAT"] = sl;
                        }
                        decimal gia = ConvertTo.Decimal(dtDetail.Rows[i]["DONGIA"]);
                        decimal ck = ConvertTo.Decimal(dtDetail.Rows[i]["TILEGIAMGIA"]);
                        decimal tt = ConvertTo.Decimal(dtDetail.Rows[i]["THANHTIEN"]);
                        decimal calcTT = sl * gia * (1 - ck / 100m);
                        if (tt == 0 && gia > 0)
                        {
                            dtDetail.Rows[i]["THANHTIEN"] = calcTT;
                        }
                    }
                }

                if (grDetail?.GridView != null)
                {
                    grDetail.GridView.DataError -= GridDetail_DataError;
                    grDetail.GridView.DataError += GridDetail_DataError;
                    foreach (DataGridViewColumn col in grDetail.GridView.Columns)
                    {
                        if (col is DataGridViewCheckBoxColumn chk)
                        {
                            chk.TrueValue = true;
                            chk.FalseValue = false;
                        }
                    }
                    grDetail.GridView.AutoGenerateColumns = false;
                    grDetail.GridView.DataSource = dtDetail;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadDetailGrid error: " + ex.Message);
            }
        }

        public void SaveChiTietDirect(TDONHANGCHITIETRow item)
        {
            try
            {
                if (item == null) return;
                if (string.IsNullOrEmpty(item.ID))
                    item.ID = Guid.NewGuid().ToString();
                if (string.IsNullOrEmpty(item.TDONHANGID))
                    item.TDONHANGID = this.ID;

                // Đảm bảo TENHANG và DDONVITINHID luôn có dữ liệu đầy đủ
                string tenHang = item.TENHANG ?? "";
                if (string.IsNullOrEmpty(tenHang.Trim()) && item.Row != null && item.Row.Table != null && item.Row.Table.Columns.Contains("MATHANG"))
                {
                    tenHang = item.Row["MATHANG"]?.ToString() ?? "";
                }
                string dvtId = item.DDONVITINHID ?? "";
                if ((string.IsNullOrEmpty(tenHang.Trim()) || string.IsNullOrEmpty(dvtId.Trim())) && !string.IsNullOrEmpty(item.DMATHANGID))
                {
                    try
                    {
                        DataRow rM = Config.Db.GetFirstRow("SELECT NAME, DDONVITINHID FROM DMATHANG WHERE ID = '" + item.DMATHANGID.Trim() + "'");
                        if (rM != null)
                        {
                            if (string.IsNullOrEmpty(tenHang.Trim())) tenHang = rM["NAME"]?.ToString() ?? "";
                            if (string.IsNullOrEmpty(dvtId.Trim())) dvtId = rM["DDONVITINHID"]?.ToString() ?? "";
                        }
                    }
                    catch { }
                }
                item.TENHANG = tenHang;
                item["MATHANG"] = tenHang;
                item.DDONVITINHID = dvtId;

                string userId = !string.IsNullOrEmpty(DbConfig.UserID) ? DbConfig.UserID : (!string.IsNullOrEmpty(DbConfig.UserName) ? DbConfig.UserName : "admin");

                decimal slXuat = item.SLXUAT > 0 ? item.SLXUAT : (item.SLXUATCHUAQUYDOI > 0 ? item.SLXUATCHUAQUYDOI : 1);
                decimal slChua = item.SLXUATCHUAQUYDOI > 0 ? item.SLXUATCHUAQUYDOI : slXuat;
                decimal thanhTien = item.THANHTIEN > 0 ? item.THANHTIEN : (slChua * item.DONGIA * (1 - item.TILEGIAMGIA / 100m));
                item.SLXUAT = slXuat;
                item.SLXUATCHUAQUYDOI = slChua;
                item.SOLUONG = slChua;
                item.THANHTIEN = thanhTien;

                string checkSql = "SELECT COUNT(*) FROM TDONHANGCHITIET WHERE ID = '" + item.ID + "'";
                int count = Config.Db.GetFirstFieldInt(checkSql);
                if (count > 0)
                {
                    string updateSql = string.Format(System.Globalization.CultureInfo.InvariantCulture, @"UPDATE TDONHANGCHITIET SET 
                        DMATHANGID = '{0}',
                        TENHANG = '{1}',
                        DDONVITINHID = '{2}',
                        SLXUAT = {3},
                        SLXUATCHUAQUYDOI = {4},
                        DONGIA = {5},
                        THANHTIEN = {6},
                        TILEGIAMGIA = {7},
                        TIENGIAMGIA = {8},
                        NOTE = '{9}',
                        USERMODIFIEDID = '{10}',
                        TIMEMODIFIED = CURRENT_TIMESTAMP
                        WHERE ID = '{11}'",
                        item.DMATHANGID ?? "",
                        (tenHang ?? "").Replace("'", "''"),
                        dvtId ?? "",
                        slXuat,
                        slChua,
                        item.DONGIA,
                        thanhTien,
                        item.TILEGIAMGIA,
                        item.TIENGIAMGIA,
                        (item.NOTE ?? "").Replace("'", "''"),
                        userId,
                        item.ID);
                    Config.Db.ExecSql(updateSql);
                }
                else
                {
                    string insertSql = string.Format(System.Globalization.CultureInfo.InvariantCulture, @"INSERT INTO TDONHANGCHITIET 
                        (ID, TDONHANGID, DMATHANGID, TENHANG, DDONVITINHID, SLXUAT, SLXUATCHUAQUYDOI, DONGIA, THANHTIEN, TILEGIAMGIA, TIENGIAMGIA, NOTE, XUATVATTU, GIAVON, DKHOHANGID, STATUS, USERCREATEDID, TIMECREATED)
                        VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, {8}, {9}, {10}, '{11}', {12}, {13}, '{14}', 30, '{15}', CURRENT_TIMESTAMP)",
                        item.ID,
                        item.TDONHANGID,
                        item.DMATHANGID ?? "",
                        (tenHang ?? "").Replace("'", "''"),
                        dvtId ?? "",
                        slXuat,
                        slChua,
                        item.DONGIA,
                        thanhTien,
                        item.TILEGIAMGIA,
                        item.TIENGIAMGIA,
                        (item.NOTE ?? "").Replace("'", "''"),
                        item.XUATVATTU,
                        item.GIAVON,
                        item.DKHOHANGID ?? "",
                        userId);
                    Config.Db.ExecSql(insertSql);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SaveChiTietDirect error: " + ex.Message);
            }
        }

        public void DeleteChiTietDirect(string ctId)
        {
            try
            {
                if (!string.IsNullOrEmpty(ctId))
                {
                    Config.Db.ExecSql("DELETE FROM TDONHANGCHITIET WHERE ID = '" + ctId + "'");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DeleteChiTietDirect error: " + ex.Message);
            }
        }

        public void SaveDonHangTotals()
        {
            try
            {
                if (string.IsNullOrEmpty(this.ID)) return;
                string sql = string.Format(System.Globalization.CultureInfo.InvariantCulture, @"UPDATE TDONHANG SET 
                    TIENHANG = {0},
                    TIENGIO = {1},
                    TILEGIAMGIA = {2},
                    TIENGIAMGIA = {3},
                    TILEGIAMGIAGIO = {4},
                    TIENGIAMGIAGIO = {5},
                    TILEPHIDICHVU = {6},
                    PHIDICHVU = {7},
                    TILETHUE = {8},
                    TIENTHUE = {9},
                    TILEGIAMGIATONG = {10},
                    TIENGIAMGIATONG = {11},
                    TONGCONG = {12}
                    WHERE ID = '{13}'",
                    numTIENHANG.Value,
                    numTIENGIO.Value,
                    numTILEGIAMGIA.Value,
                    numTIENGIAMGIA.Value,
                    numTILEGIAMGIAGIO.Value,
                    numTIENGIAMGIAGIO.Value,
                    numTILEPHIDICHVU.Value,
                    numPHIDICHVU.Value,
                    numTILETHUE.Value,
                    numTIENTHUE.Value,
                    numTILEGIAMGIATONG.Value,
                    numTIENGIAMGIATONG.Value,
                    numTONGCONG.Value,
                    this.ID);
                Config.Db.ExecSql(sql);

                // Luôn cập nhật liên kết bàn với hóa đơn nếu đang chọn bàn
                if (!string.IsNullOrEmpty(DBANID) && !string.IsNullOrEmpty(this.ID))
                {
                    Config.Db.ExecSql(string.Format("UPDATE DBAN SET TDONHANGID = '{0}' WHERE ID = '{1}'", this.ID, DBANID));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SaveDonHangTotals error: " + ex.Message);
            }
        }

        internal static void EnsureDonHangSaved(TDONHANGRow row)
        {
            try
            {
                if (row == null || string.IsNullOrEmpty(row.ID)) return;
                int count = Config.Db.GetFirstFieldInt("SELECT COUNT(*) FROM TDONHANG WHERE ID = '" + row.ID + "'");
                if (count == 0)
                {
                    string userId = !string.IsNullOrEmpty(DbConfig.UserID) ? DbConfig.UserID : (!string.IsNullOrEmpty(DbConfig.UserName) ? DbConfig.UserName : "admin");
                    string sql = string.Format(System.Globalization.CultureInfo.InvariantCulture, @"INSERT INTO TDONHANG 
                    (ID, NAME, NGAY, BATDAU, BATDAUPHONGCUOI, DBANID, DCUAHANGID, SOKHACH, DONGIA, CACHTINHGIA, DBANGGIAID, SOHD, LOAI, TIENMOBAN, DATHANHTOAN, TONGCONG, TIENHANG, TIENGIO, TIENGIAMGIA, TILEGIAMGIA, TILEGIAMGIAGIO, TILEPHIDICHVU, TILETHUE, TILEGIAMGIATONG, TDATHANGID, DKHACHHANGID, STATUS, USERCREATEDID, TIMECREATED)
                    VALUES ('{0}', '{1}', @NGAY, @BATDAU, @BATDAUPHONGCUOI, '{2}', '{3}', {4}, {5}, {6}, '{7}', {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, '{21}', '{22}', 2, '{23}', CURRENT_TIMESTAMP)",
                    row.ID,
                    (row.NAME ?? "").Replace("'", "''"),
                    row.DBANID ?? "",
                    row.DCUAHANGID ?? "",
                    row.SOKHACH,
                    row.DONGIA,
                    row.CACHTINHGIA,
                    row.DBANGGIAID ?? "",
                    row.SOHD,
                    row.LOAI,
                    row.TIENMOBAN,
                    row.DATHANHTOAN,
                    row.TONGCONG,
                    row.TIENHANG,
                    row.TIENGIO,
                    row.TIENGIAMGIA,
                    row.TILEGIAMGIA,
                    row.TILEGIAMGIAGIO,
                    row.TILEPHIDICHVU,
                    row.TILETHUE,
                    row.TILEGIAMGIATONG,
                    row.TDATHANGID ?? "",
                    row.DKHACHHANGID ?? "",
                    userId);

                    var cmd = Config.Db.GetCommand(sql);
                    cmd.Parameters.Add("@NGAY", FbDbType.Date).Value = row.NGAY;
                    cmd.Parameters.Add("@BATDAU", FbDbType.TimeStamp).Value = row.BATDAU;
                    cmd.Parameters.Add("@BATDAUPHONGCUOI", FbDbType.TimeStamp).Value = row.BATDAUPHONGCUOI;
                    Config.Db.ExecSql(cmd);
                }

                // Update DBAN to link TDONHANGID
                if (!string.IsNullOrEmpty(row.DBANID))
                {
                    Config.Db.ExecSql(string.Format("UPDATE DBAN SET TDONHANGID = '{0}' WHERE ID = '{1}'", row.ID, row.DBANID));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureDonHangSaved error: " + ex.Message);
            }
        }

        /// <summary>
        /// Tải thông tin của đơn hàng lên giao diện
        /// </summary>
        /// <param name="ID">ID của hóa đơn</param>
        /// <param name="BanID">ID của bàn đang chọn trên giao diện, sử dụng cho trường hợp chưa có hóa đơn</param>
        internal void Reload(string ID, string BanID)
        {                        
            _isLoading = true;
            try
            {
                this.ID = ID ?? "";

                // Đảm bảo cấu hình cột cho lưới hóa đơn và danh mục mặt hàng
                SetupGrids();

            // Trường hợp tải lần đầu thì ẩn/hiện cột từ giờ đến giờ
            if (TaiLanDau)
            {
                try
                {
                    HideShowColumn("TUGIO");
                    HideShowColumn("DENGIO");
                    TaiLanDau = false;

                    if (SystemConfig.KichHoatSuDungCanDienTu == 30 && grDetail?.GridView?.Columns["SLXUATCHUAQUYDOI"] is NumericDataGridViewColumn col)
                    {
                        col.DecimalLength = 3;
                        numCan.DecimalPlaces = 3;
                    }
                }
                catch { }
            }

            bool daThanhToan = true;
            if (string.IsNullOrEmpty(ID)) // Bàn chưa có hóa đơn
            {
                _currentDonHangRow = null;
                _giamTheoTien = 0;
                _giamGiaGioTheoTien = 0;
                _giamTongTheoTien = 0;
                _phiDichVuTheoTien = 0;

                txtNAME.Text = "";
                txtSOORDER.Text = "";
                txtNOTE.Text = "";
                dtBATDAUPHONGCUOI.EditValue = null;
                dtKETTHUC.EditValue = null;
                numTIENHANG.Value = 0;
                numTIENGIO.Value = 0;
                numTONGCONG.Value = 0;
                numTILEGIAMGIA.Value = 0;
                numTIENGIAMGIA.Value = 0;
                numTILEGIAMGIAGIO.Value = 0;
                numTIENGIAMGIAGIO.Value = 0;
                numTILEPHIDICHVU.Value = 0;
                numPHIDICHVU.Value = 0;
                numTILETHUE.Value = 0;
                numTIENTHUE.Value = 0;
                numTILEGIAMGIATONG.Value = 0;
                numTIENGIAMGIATONG.Value = 0;
                numSOKHACH.Value = 1;

                if (grDetail.GridView != null) grDetail.GridView.DataSource = null;

                btnBatDau.Enabled = true;
                DBANID = BanID ?? "";
                lblBan.Text = !string.IsNullOrEmpty(DBANID) ? Config.Db.GetFirstFieldString(Tables.DBAN, DBANInfo.NAME, DBANID) : "";
                pnlNhieuBill.Visible = false;                
            }
            else // Bàn có hóa đơn
            {
                DataRow rDonHang = null;
                try { rDonHang = Config.Db.GetFirstRow("SELECT * FROM TDONHANG WHERE ID = '" + ID + "'"); } catch { }
                if (rDonHang != null)
                {
                    _currentDonHangRow = new TDONHANGRow(rDonHang);
                    txtNAME.Text = rDonHang["NAME"]?.ToString() ?? "";
                    txtSOORDER.Text = rDonHang["SOORDER"]?.ToString() ?? "";
                    txtNOTE.Text = rDonHang["NOTE"]?.ToString() ?? "";
                    if (rDonHang["NGAY"] != DBNull.Value) dtNGAY.EditValue = Convert.ToDateTime(rDonHang["NGAY"]);
                    if (rDonHang["BATDAUPHONGCUOI"] != DBNull.Value) dtBATDAUPHONGCUOI.EditValue = Convert.ToDateTime(rDonHang["BATDAUPHONGCUOI"]);
                    if (rDonHang["KETTHUC"] != DBNull.Value) dtKETTHUC.EditValue = Convert.ToDateTime(rDonHang["KETTHUC"]);
                    if (rDonHang["DNHANVIENXUATID"] != DBNull.Value) lueDNHANVIENXUATID.EditValue = rDonHang["DNHANVIENXUATID"].ToString();
                    if (rDonHang["DKHACHHANGID"] != DBNull.Value) lueDKHACHHANGID.EditValue = rDonHang["DKHACHHANGID"].ToString();
                    if (rDonHang["DBANGGIAID"] != DBNull.Value) lueDBANGGIAID.EditValue = rDonHang["DBANGGIAID"].ToString();

                    numSOKHACH.Value = rDonHang["SOKHACH"] != DBNull.Value ? Convert.ToDecimal(rDonHang["SOKHACH"]) : 1;
                    numTIENHANG.Value = rDonHang["TIENHANG"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TIENHANG"]) : 0;
                    numTIENGIO.Value = rDonHang["TIENGIO"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TIENGIO"]) : 0;
                    numTILEGIAMGIA.Value = rDonHang["TILEGIAMGIA"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TILEGIAMGIA"]) : 0;
                    numTIENGIAMGIA.Value = rDonHang["TIENGIAMGIA"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TIENGIAMGIA"]) : 0;
                    numTILEGIAMGIAGIO.Value = rDonHang["TILEGIAMGIAGIO"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TILEGIAMGIAGIO"]) : 0;
                    numTIENGIAMGIAGIO.Value = rDonHang["TIENGIAMGIAGIO"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TIENGIAMGIAGIO"]) : 0;
                    numTILEPHIDICHVU.Value = rDonHang["TILEPHIDICHVU"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TILEPHIDICHVU"]) : 0;
                    numPHIDICHVU.Value = rDonHang["PHIDICHVU"] != DBNull.Value ? Convert.ToDecimal(rDonHang["PHIDICHVU"]) : 0;
                    numTILETHUE.Value = rDonHang["TILETHUE"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TILETHUE"]) : 0;
                    numTIENTHUE.Value = rDonHang["TIENTHUE"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TIENTHUE"]) : 0;
                    numTILEGIAMGIATONG.Value = rDonHang["TILEGIAMGIATONG"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TILEGIAMGIATONG"]) : 0;
                    numTIENGIAMGIATONG.Value = rDonHang["TIENGIAMGIATONG"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TIENGIAMGIATONG"]) : 0;
                    numTONGCONG.Value = rDonHang["TONGCONG"] != DBNull.Value ? Convert.ToDecimal(rDonHang["TONGCONG"]) : 0;

                    _giamTheoTien = rDonHang["GIAMTHEOTIEN"] != DBNull.Value ? Convert.ToInt32(rDonHang["GIAMTHEOTIEN"]) : 0;
                    _giamGiaGioTheoTien = rDonHang["GIAMGIAGIOTHEOTIEN"] != DBNull.Value ? Convert.ToInt32(rDonHang["GIAMGIAGIOTHEOTIEN"]) : 0;
                    _giamTongTheoTien = rDonHang["GIAMTONGTHEOTIEN"] != DBNull.Value ? Convert.ToInt32(rDonHang["GIAMTONGTHEOTIEN"]) : 0;
                    _phiDichVuTheoTien = rDonHang["PHIDICHVUTHEOTIEN"] != DBNull.Value ? Convert.ToInt32(rDonHang["PHIDICHVUTHEOTIEN"]) : 0;

                    DBANID = rDonHang["DBANID"]?.ToString() ?? BanID;
                }
                else
                {
                    DBANID = BanID;
                }

                daThanhToan = mode == HoaDonMode.SuDungDichVu ? IsDaThanhToan(ID) : false;
                btnBatDau.Enabled = dtBATDAUPHONGCUOI.EditValue == null;
                lblBan.Text = Config.Db.GetFirstFieldString(Tables.DBAN, DBANInfo.NAME, DBANID);
                
                string GUID = (rDonHang != null && rDonHang.Table.Columns.Contains("NHOMGUID") && rDonHang["NHOMGUID"] != DBNull.Value) 
                    ? rDonHang["NHOMGUID"].ToString() : "";
                pnlNhieuBill.Visible = GUID.Length > 0;
                //tải thông tin các bill khác lên
                if (GUID.Length > 0)
                {
                    string sql = "SELECT SUM(TONGCONG) FROM TDONHANG WHERE NHOMGUID = '" + GUID + "' AND ID <> '" + ID + "'";                    
                    BILLKHAC.Value = Config.Db.GetFirstFieldDec(sql);
                }
                else
                {
                    BILLKHAC.Value = 0;
                }

                // Tải chi tiết đơn hàng lên lưới
                LoadDetailGrid(ID);

                // Tính toán lại tổng tiền từ chi tiết đơn hàng nếu có món
                if (DetailTable != null && DetailTable.Rows.Count > 0)
                {
                    mapper_OnCalculation(null, EventArgs.Empty);
                    SaveDonHangTotals();
                }

                //tính toán lại ghi chú
                DataTable dtGioHat = GioHatTable;
                if (dtGioHat != null)
                {
                    foreach (DataRow r in dtGioHat.Rows)
                    {
                        if (r.RowState == DataRowState.Deleted) continue;

                        TDONHANGGIORow row = new TDONHANGGIORow(r);
                        if (row.CACHTINHGIA == (int)CachTinhGiaGio.THEOBANGGIA)
                        {
                            row.NOTE = r["DBANGGIA_NAME"].ToString();
                        }
                        else
                        {
                            row.NOTE = row.DONGIA.ToString("n0") + " (/giờ)";
                        }
                    }
                }

                if (Shared.CoTienGio && SystemConfig.ChoPhepDungNhieuBangGiaTrenBill == 30)
                {
                    int cachTinhVal = (rDonHang != null && rDonHang.Table.Columns.Contains("CACHTINHGIA") && rDonHang["CACHTINHGIA"] != DBNull.Value)
                        ? ConvertTo.Int(rDonHang["CACHTINHGIA"]) : 0;
                    CachTinhGiaGio cachTinh = (CachTinhGiaGio)cachTinhVal;
                    pnlBangGia.Visible = cachTinh == CachTinhGiaGio.THEOBANGGIA;
                    lueDBANGGIAID.LoadData(Tables.DBANGGIA);
                }
            }

            bool thayDoiGiamGiaTongBill = DbUtils.CanView(Functions.ThayDoiGiamGiaTongHoaDon);
            bool thayDoiPhiDichVu = DbUtils.CanView(Functions.ThayDoiPhiDichVu);

            tabTongCong.SelectedIndex = 0;
            TIENPHAITRA.Value = BILLKHAC.Value + numTONGCONG.Value;

            bool hasBan = DBANID.Length > 0;
            bool enable = !daThanhToan && hasBan;            
            lueDNHANVIENXUATID.Enabled = enable;
            numSOKHACH.Enabled = enable;
            txtSOORDER.Enabled = enable;
            txtNOTE.Enabled = enable;
            btnDoiGioRa.Enabled = enable;
            btnDoiGioVao.Enabled = enable;            
            numTILETHUE.Enabled = enable;
            tsbKiemDo.Enabled = enable;
            btnBatDau.Enabled = btnBatDau.Enabled && hasBan;
            
            btnThanhToan.Enabled = enable;
            btnTheoNhom.Enabled = enable;
            //giờ bắt đầu chỉ có thể thay đổi khi cho phép thay đổi giờ và có chọn hóa đơn
            //đồng thời chưa có chuyển phòng

            dtBATDAUPHONGCUOI.Enabled = ChoPhepThayDoiGio && enable && (GioHatTable?.Rows.Count ?? 0) == 0;
            dtKETTHUC.Enabled = ChoPhepThayDoiGio && enable;
            btnInCheBien.Visible = (SystemConfig.SuDungChucNangInXuongBep == 30 || SystemConfig.SuDungChucNangInXuongBep == 1) && mode == HoaDonMode.SuDungDichVu;
            btnInCheBien.Enabled = btnThanhToan.Enabled && btnInCheBien.Visible;
            btnThem.Enabled = !daThanhToan && grMatHang.SelectedRows.Count > 0 && hasBan;
            btnGiam.Enabled = !daThanhToan && grMatHang.SelectedRows.Count > 0 && hasBan;
            btnXoa.Enabled = !daThanhToan && grDetail.SelectedID.Length > 0 && hasBan;
            btnInLaiBill.Visible = (daThanhToan && ID.Length > 0 && hasBan) || mode == HoaDonMode.QuanLyBanHang;
            lueDBANGGIAID.Enabled = !daThanhToan && ID.Length > 0 && hasBan;

            bool coGiamGia = enable && SystemConfig.ChoPhepNhapGiamGia == 30;
            numTILEGIAMGIA.Enabled = coGiamGia && thayDoiGiamGiaTongBill;
            numTIENGIAMGIA.Enabled = coGiamGia && thayDoiGiamGiaTongBill;
            numTILEGIAMGIAGIO.Enabled = coGiamGia && thayDoiGiamGiaTongBill;
            numTIENGIAMGIAGIO.Enabled = coGiamGia && thayDoiGiamGiaTongBill;
            numTILEGIAMGIATONG.Enabled = coGiamGia && thayDoiGiamGiaTongBill;
            numTIENGIAMGIATONG.Enabled = coGiamGia && thayDoiGiamGiaTongBill;

            lueDKHACHHANGID.Enabled = !btnSearch.Visible && ID.Length > 0 && !daThanhToan;
            btnSearch.Enabled = btnSearch.Visible && ID.Length > 0 && !daThanhToan;
            txtNAME.Enabled = enable;
            dtNGAY.Enabled = enable && SystemConfig.ChoPhepThayDoiNgayTrenHoaDon == 30;
            numPHIDICHVU.Enabled = enable && thayDoiPhiDichVu;
            numTILEPHIDICHVU.Enabled = enable && thayDoiPhiDichVu;
            btnChuyenBan.Enabled = enable;
            btnGopBan.Enabled = enable;
            toolDetail.Enabled = ID.Length > 0 && hasBan;
            btnTamUng.Enabled = enable;

            SetDetailButtonEnable(enable);

            tabMain.NavigatorMode = (GioHatTable?.Rows.Count ?? 0) == 0 ? ComponentFactory.Krypton.Navigator.NavigatorMode.Panel : ComponentFactory.Krypton.Navigator.NavigatorMode.BarTabGroup;
            if ((GioHatTable?.Rows.Count ?? 0) == 0) tabMain.SelectedPage = pageHoaDon;

            if (!daThanhToan && mode == HoaDonMode.SuDungDichVu)
                UpdateGio();            

            //nếu mở hóa đơn cũ thì đưa con trỏ vào ô tìm kiếm
            if (ID.Length > 0)
            {
                txtTimKiem.SelectAllEx();
            }

            if (!DbUtils.CanView(Functions.XemDonGiaTrongHoaDonBanHang))
            {
                grDetail.HideColumn(TDONHANGCHITIETInfo.DONGIA.ToString());
                grDetail.HideColumn(TDONHANGCHITIETInfo.THANHTIEN.ToString());

                grGioHat.HideColumn("THANHTIEN");
            }

            if (mode != HoaDonMode.SuDungDichVu)
            {
                if (lstLuuVet != null) lstLuuVet.Clear();
                lstLuuVet = new List<LuuVetInfo>();
            }
            }
            finally
            {
                _isLoading = false;
            }
        }

        /// <summary>
        /// Lấy ra danh sách khuyến mại đang sử dụng
        /// </summary>
        /// <param name="DLOAIHINHKHUYENMAIID"></param>
        /// <returns></returns>
        private static DataTable GetKhuyenMaiDangSuDung(Database Db, DateTime thoiGian, string DLOAIHINHKHUYENMAIID)
        {
            if (SystemConfig.KichHoatKhuyenMaiTuDong == 0) return new DataTable();
            //lấy ra khuyến mại đang áp dụng 
            string sql = "SELECT * FROM DDOTKHUYENMAI WHERE CAST(@TIME AS DATE) BETWEEN TUNGAY AND DENNGAY AND CAST(@TIME AS TIME) BETWEEN CAST(TUGIO AS TIME) AND CAST(DENGIO AS TIME) AND STATUS = 30 AND COALESCE(NGUNGAPDUNG, 0) = 0 AND DLOAIHINHKHUYENMAIID = '" + DLOAIHINHKHUYENMAIID + "'";
            FbCommand cmd = Db.GetCommand(sql);
            cmd.Parameters.Add("@TIME", FbDbType.TimeStamp).Value = thoiGian;
            DataTable dt = Db.GetTable(cmd);
            return dt;
        }

        /// <summary>
        /// Ẩn cột trên giao diện
        /// </summary>
        /// <param name="colName"></param>
        private void HideShowColumn(string colName)
        {
            DataGridViewColumn col = grDetail.GridView.Columns[colName];
            if (col != null) col.Visible = Shared.CoTienGio;
        }

        //cập nhật tiền giờ
        private void UpdateGio()
        {
            if (mapper.ID.Length == 0) return;
            //chỉ lấy ra các cột cần lấy để tối ưu            
            string sql = string.Format("SELECT SOLANINTAMTINH, INTAMTINHLUC, DATHANHTOAN, TUTHAYDOIGIO FROM TDONHANG WHERE ID = '{0}'", mapper.ID);
            TDONHANGRow dhRow = new TDONHANGRow(Config.Db.GetFirstRow(sql));
            if (dhRow.IsNull) return;

            if (SystemConfig.DungThoiGianKhiInTamTinh == 30 && dhRow.SOLANINTAMTINH > 0)
            {                
                DateTime now = Config.Db.DbDateTime;
                TimeSpan ts = now - dhRow.INTAMTINHLUC;
                //nếu chưa quá số phút dừng thì bỏ qua
                if (ts.TotalMinutes < SystemConfig.SoPhutToiDaChoPhepDung)
                {
                    return;
                }
            }
           
            //trước khi cập nhật kiểm tra đã thanh toán thì bỏ qua
            if (dhRow.DATHANHTOAN == 30)
            {
                RefreshTrangThaiBan();
                return;
            }

            //trường hợp không chọn tiền giờ mới thiết lập giờ thành giờ hiện tại
            if (dhRow.TUTHAYDOIGIO != 30)
            {
                DateTime now = Config.Db.DbDateTime.AddMinutes(SystemConfig.TuDongDoiGioRaVeSau);
                if (now > dtKETTHUC.DateTime)
                {
                    dtKETTHUC.EditValue = now;                    
                }
            }

            //sau khi cập nhật lưu lại thông tin
            UpdateTongThoiGian();            
        }

        /// <summary>
        /// Cập nhật thời gian kết thúc bằng thời gian hiện tại nếu chưa thay đổi giờ thủ công
        /// </summary>
        private void UpdateTongThoiGian()
        {
            //trường hợp có chọn giờ bắt đầu và giờ kết thúc
            if (!dtBATDAUPHONGCUOI.IsEmpty && !dtKETTHUC.IsEmpty)
            {
                DateTime batDau = dtBATDAUPHONGCUOI.DateTime;
                DateTime ketThuc = dtKETTHUC.DateTime;

                if (ketThuc < batDau) ketThuc = ketThuc.AddDays(1);

                //tính thời gian giữa bắt đầu và kết thúc
                TimeSpan sp = ketThuc - batDau;
                string str;
                if (sp.Hours != 0 || sp.Days != 0)
                    str = ((int)sp.TotalHours).ToString("n0") + " giờ " + sp.Minutes.ToString() + " phút";
                else
                    str = sp.Minutes.ToString() + " phút";

                //hiển thị tổng thời gian
                lblTongGio.Text = str;

                int soPhutKhuyenMai = GetDonHangInt("PHUTKHUYENMAI", 0);
                decimal tiLeKhuyenMai = GetDonHangDecimal("TILEKHUYENMAIPHUTDAU", 0);
                DateTime batDauBill = GetDonHangDateTime("BATDAU", batDau);

                //tính tiền giờ
                decimal val = Shared.TinhGia((CachTinhGiaGio)GetDonHangInt("CACHTINHGIA", 0),
                                        lueDBANGGIAID.StringValue,
                                        GetDonHangDecimal("DONGIA", 0),
                                        batDau, ketThuc, batDauBill, soPhutKhuyenMai, tiLeKhuyenMai, null, GetDonHangDecimal("TIENMOBAN", 0));

                //tính toán các mặt hàng có tiền giờ
                DataTable dt = DetailTable;
                if (dt != null)
                foreach (DataRow r in dt.Rows)
                {
                    if (r.RowState == DataRowState.Deleted) continue;
                    if (ConvertTo.Int(r["THEOGIO"]) == 30)
                    {
                        TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(r);

                        DateTime bd = (ctRow.DENGIO.Year == 1 ? dtKETTHUC.DateTime : ctRow.DENGIO);
                        DateTime kt = ctRow.TUGIO;

                        sp = new DateTime(bd.Year, bd.Month, bd.Day, bd.Hour, bd.Minute, 0) - new DateTime(kt.Year, kt.Month, kt.Day, kt.Hour, kt.Minute, 0);

                        decimal soLuong = Math.Max(0, Math.Round(Math.Max(0, (decimal)sp.TotalHours), 2));
                        if (lamTronMatHangDichVu > 0)
                        {
                            //ví dụ số phút làm tròn = 15
                            //làm tròn xuống: từ 0 -> 14: về 0, từ 15 -> 29 về 15
                            //làm tròn lên: từ 0 -> 15: về 15, từ 16 -> 30 về 30
                            //làm tròn giữa: từ 0 -> 7: về 15, từ 8 -> 22: về 15, từ 22 -> 37: về 30
                            decimal soPhut = (int) sp.TotalMinutes;

                            decimal heSo = soPhut / lamTronMatHangDichVu;
                            switch (cachLamTronMatHangDichVu)
                            {
                                case CachLamTron.LamTronXuong:
                                    heSo = Math.Floor(heSo);
                                    break;
                                case CachLamTron.LamTronLen:
                                    heSo = Math.Ceiling(heSo);
                                    break;
                                case CachLamTron.LamTronGiua:
                                    heSo = Math.Round(heSo, 0, MidpointRounding.AwayFromZero);
                                    break;
                            }

                            soLuong = Math.Round((heSo * lamTronMatHangDichVu) / 60M, 2);
                        }
                        ctRow.SLXUATCHUAQUYDOI = soLuong;
                        SafeCalculateRow(ctRow.Row);
                    }
                }

                //làm tròn tiền giờ thành 1000
                decimal gia = Math.Max(0, 1000 * Math.Round(val / 1000, 0, MidpointRounding.AwayFromZero));
                if (gia != numTIENGIO.Value)
                {                    
                    numTIENGIOPHONGCUOI.Value = gia;                         
                }
            }
            else
            {
                lblTongGio.Text = "________";
            }
        }

        /// <summary>
        /// Thực hiện mở hóa đơn trên bàn đang chọn
        /// </summary>
        internal void MoHoaDon()
        {
            if (btnBatDau.Enabled) btnBatDau.PerformClick();
            else if (btnThanhToan.Enabled) btnThanhToan.PerformClick();
        }

        //Thiết lập giá hiển thị trên danh sách mặt hàng theo khu vực đang chọn bên giao diện bàn
        internal void SetGiaTheoKhuVuc(GiaMatHang giaMatHang)
        {
            var col = grMatHang.Columns["GIABAN"];
            if (col == null) 
            {
                // Fallback: search by DataPropertyName starting with GIABAN
                foreach (System.Windows.Forms.DataGridViewColumn c in grMatHang.Columns)
                {
                    if (c.DataPropertyName != null && c.DataPropertyName.StartsWith("GIABAN"))
                    {
                        col = c;
                        break;
                    }
                }
            }

            if (col != null)
            {
                if (giaMatHang == GiaMatHang.GIABAN2 || giaMatHang == GiaMatHang.GIABAN3 || giaMatHang == GiaMatHang.GIABAN4)
                {
                    col.DataPropertyName = "GIABAN" + ((int)giaMatHang).ToString();
                }
                else
                {
                    col.DataPropertyName = "GIABAN";
                }
            }
        }

        //xử lý khi mở bàn
        public void btnBatDau_Click(object sender, EventArgs e)
        {
            //kiểm tra xem có bàn nào đang chọn không?
            if (DBANID == null || DBANID.Length == 0)
            {
                Msg.ShowWarning(string.Format("Mời bạn chọn {0} trước khi thực hiện mở {0}!", Shared.GetTenPhongBan(true)));
                return;
            }

            //kiểm tra xem có phải là phiên bản free không?
            if (No1System.IsTrial)
            {
                string sql = "SELECT COUNT(DISTINCT NGAY) FROM TDONHANG WHERE LOAI = 0";
                int count = ConvertTo.Int(Config.Db.GetFirstField(sql));
                if (count >= 30)
                {
                    Msg.ShowWarning("Phiên bản dùng thử không cho phép bạn sử dụng dữ liệu nhiều!");
                    return;
                }
            }

            //kiểm tra xem bàn có người giữ không?
            if (SystemConfig.HeThongChayNhieuMayTram == 30)
            {
                string TaiKhoanGiu = "";
                if (SuDungDichVu.BanDangBiGiu(DBANID, ref TaiKhoanGiu))
                {
                    Msg.ShowWarning(string.Format("{2} {0} đang bị giữ bởi {1}", new DBANRow(DBANID).NAME, TaiKhoanGiu, Shared.GetTenPhongBan(false)));
                    return;
                }
            }

            //tiến hành mở hóa đơn thông thường
            TaoMoiHoaDon(null);

            //tạo xong thì giữ bàn
            if (OnLockTableRequest != null) OnLockTableRequest(DBANID);
        }        

        /// <summary>
        /// Lấy hóa đơn đang mở trên bàn nếu có
        /// </summary>
        /// <param name="DBANID">ID của bàn</param>
        /// <returns>Trả về ID của hóa đơn</returns>
        public static string GetHoaDonTrenBan(string DBANID)
        {
            if (string.IsNullOrEmpty(DBANID)) return "";
            string sql = string.Format(@"SELECT DH.ID 
                FROM DBAN B 
                INNER JOIN TDONHANG DH ON B.TDONHANGID = DH.ID 
                WHERE B.ID = '{0}' AND COALESCE(DH.DATHANHTOAN, 0) = 0 AND COALESCE(DH.STATUS, 0) <> 40", DBANID);
            string id = Config.Db.GetFirstFieldString(sql);
            if (string.IsNullOrEmpty(id))
            {
                // If DBAN still points to an old/paid/cancelled bill, clean it up
                string rawId = Config.Db.GetFirstFieldString("SELECT TDONHANGID FROM DBAN WHERE ID = '" + DBANID + "'");
                if (!string.IsNullOrEmpty(rawId))
                {
                    Config.Db.ExecSql(string.Format("UPDATE DBAN SET TDONHANGID = NULL WHERE ID = '{0}'", DBANID));
                }
                return "";
            }
            return id;
        }

        /// <summary>
        /// Tạo mới hóa đơn
        /// </summary>
        /// <param name="dhRow">Thông tin đặt hàng nếu tạo hóa đơn từ đặt hàng</param>
        private void TaoMoiHoaDon(TDATHANGRow dhRow)
        {
            //kiểm tra nếu chưa chọn bàn thì không thực hiện gì
            if (DBANID.Length == 0)
            {
                return;
            }

            //kiểm tra xem bàn đang có hóa đơn không?
            string TDONHANGID = GetHoaDonTrenBan(DBANID);
            if (TDONHANGID.Length > 0)
            {
                Msg.ShowWarning(string.Format("{0} này đang có khách", Shared.GetTenPhongBan(false)));
                RefreshTrangThaiBan();
                return;
            }

            //Thêm hàng mặc định hoặc các mặt hàng đã đặt vào hóa đơn
            DataTable dtMatHangTheoBan = null;
            if (dhRow != null)
            {
                string sql = string.Format(@"SELECT SOLUONG, DONGIA, TILEGIAMGIA, DLOAIMATHANGID,
DMATHANGID FROM TDATHANGCHITIET INNER JOIN DMATHANG ON TDATHANGCHITIET.DMATHANGID = DMATHANG.ID 
WHERE TDATHANGID = '{0}'", dhRow.ID);
                dtMatHangTheoBan = Config.Db.GetTable(sql);
            }
            else if (SystemConfig.SuDungMatHangMacDinh == 30)
            {
                string sql = string.Format(@"SELECT SOLUONG, DMATHANGID, DLOAIMATHANGID
FROM DMATHANGMACDINH INNER JOIN DMATHANG ON DMATHANGMACDINH.DMATHANGID = DMATHANG.ID
WHERE DKHUVUCID = (SELECT DKHUVUCID FROM DBAN WHERE ID = '{0}')", DBANID);
                dtMatHangTheoBan = Config.Db.GetTable(sql);
            }

            TDONHANGID = TaoHoaDonTrang(DBANID, dhRow);
            Reload(TDONHANGID, DBANID);

            //lưu vết thời gian mở hóa đơn
            Track(LoaiLuuVet.MoBan, string.Format("Mở hóa đơn trên {0} '{1}'", Shared.GetTenPhongBan(true), lblBan.Text), 0, 0, 0, "");

            //thêm mặt hàng mặc định hoặc mặt hàng đặt trước nếu có
            if (dtMatHangTheoBan != null)
            {
                DKHUVUCRow kvRow = new DKHUVUCRow(new DBANRow(DBANID).DKHUVUCID);

                foreach (DataRow r in dtMatHangTheoBan.Rows)
                {
                    DMATHANGRow spRow = new DMATHANGRow(r["DMATHANGID"].ToString());
                    if (spRow.IsNull) continue;
                    if (dhRow == null || dhRow.DBANID != DBANID)
                    {
                        GiaMatHang GiaSuDung = (GiaMatHang) ConvertTo.Int(kvRow.DGIAMATHANGID);
                        LayGiaMatHangTheoGio(Config.Db, kvRow, ref GiaSuDung);
                        //kiểm tra xem có giá theo giờ không?                        
                        if (GiaSuDung == GiaMatHang.GIABAN2) spRow.GIABAN = spRow.GIABAN2;
                        else if (GiaSuDung == GiaMatHang.GIABAN3) spRow.GIABAN = spRow.GIABAN3;
                        else if (GiaSuDung == GiaMatHang.GIABAN4) spRow.GIABAN = spRow.GIABAN4;
                    }
                    else
                    {
                        spRow.GIABAN = ConvertTo.Decimal(r["DONGIA"]);
                    }

                    DoAddItemToGrid(spRow, ConvertTo.Decimal(r["SOLUONG"]), true);
                }

                if (dtMatHangTheoBan.Rows.Count > 0)
                {
                    StartAutoPrintTimer();
                }
            }

            //tải lại trạng thái bàn
            RefreshTrangThaiBan();            
            //chọn ô tìm kiếm
            txtTimKiem.SelectAllEx();

            //Bật đèn nếu có sử dụng tùy chọn này
            Shared.BatDen(DBANID);
        }
        
        /// <summary>
        /// Tạo hóa đơn trắng
        /// </summary>
        /// <param name="dhRow">Đơn hàng đặt trước nếu có</param>
        /// <returns></returns>
        internal static string TaoHoaDonTrang(string DBANID, TDATHANGRow dhRow)
        {
            //tạo mới đơn hàng
            TDONHANGRow row = new TDONHANGRow();
            //row.NGAY = Config.Db.DbDate;
            DateTime ngay = Shared.GetNgayGiaoDich(Config.Db);
            row.NGAY = ngay;

            DateTime now = Config.Db.DbDateTime;
            now = now.AddMinutes(- SystemConfig.TuDongDoiGioVaoVeTruoc);
            now = now.AddSeconds(-now.Second).AddMilliseconds(-now.Millisecond);

            row.BATDAU = now;
            row.BATDAUPHONGCUOI = now;
            row.DBANID = DBANID;

            string DBANGGIAID = "";
            decimal DonGia = 0;
            CachTinhGiaGio cachTinh = CachTinhGiaGio.THEOGIO;
            decimal TienMoBan = 0;

            //cập nhật cách tính giờ theo khu vực
            if (Shared.CoTienGio)
            {
                LayBangGiaTheoBan(DBANID, ref DBANGGIAID, ref DonGia, ref cachTinh, ref TienMoBan);                
            }

            row.TIENMOBAN = TienMoBan;
            row.DATHANHTOAN = 0;
            row.TONGCONG = 0;
            row.DCUAHANGID = Shared.DCUAHANGID;
            row.SOKHACH = 1;
            row.DONGIA = DonGia;
            row.CACHTINHGIA = (int)cachTinh;            
            row.DBANGGIAID = DBANGGIAID;
            int So;
            row.NAME = TaoSoHoaDon(Config.Db, DbConfig.UserID, ngay, out So);
            row.LOAI = 0;
            row.SOHD = So;            

            row.TIENGIAMGIA = 0;

            decimal giamGiaTienHang = 0;
            decimal giamGiaTienGio = 0;
            decimal giamGiaTong = 0;
            int soPhutKm = 0;
            decimal tiLeKmPhutDau = 0;
            GetTiLeGiamTheoKM(Config.Db, now, out giamGiaTienHang, out giamGiaTienGio, out giamGiaTong, out soPhutKm, out tiLeKmPhutDau);

            row.PHUTKHUYENMAI = soPhutKm;
            row.TILEKHUYENMAIPHUTDAU = tiLeKmPhutDau;
            row.TILEGIAMGIA = giamGiaTienHang;
            row.TILEPHIDICHVU = SystemConfig.CoPhiDichVu == 30 ? SystemConfig.MacDinhPhiDichVu : 0;
            row.TILETHUE = SystemConfig.CoThueSuat == 30 ? SystemConfig.MacDinhThueSuat : 0;
            row.TILEGIAMGIAGIO = giamGiaTienGio;
            row.TILEGIAMGIATONG = giamGiaTong;
            row.TIENHANG = 0;
            row.TIENGIO = 0;
            if (dhRow != null)
            {
                row.TDATHANGID = dhRow.ID;
                if (dhRow.DKHACHHANGID.Length > 0) row.DKHACHHANGID = dhRow.DKHACHHANGID;
            }

            row.Update();            
            EnsureDonHangSaved(row);
            if (!string.IsNullOrEmpty(row.DBANID) && !string.IsNullOrEmpty(row.ID))
            {
                Config.Db.ExecSql(string.Format("UPDATE DBAN SET TDONHANGID = '{0}' WHERE ID = '{1}'", row.ID, row.DBANID));
            }
            return row.ID;
        }

        internal static void LayBangGiaTheoBan(string DBANID, ref string DBANGGIAID, ref decimal DonGia, ref CachTinhGiaGio cachTinh, ref decimal TienMoBan)
        {
            DBANRow banRow = new DBANRow(DBANID);
            cachTinh = (CachTinhGiaGio)banRow.CACHTINHGIO;
            //lấy thông tin cách tính từ khu vực nếu thiết lập bàn phòng theo khu vực
            if (cachTinh == CachTinhGiaGio.THEOKHUVUC)
            {
                DKHUVUCRow kvRow = new DKHUVUCRow(banRow.DKHUVUCID);
                cachTinh = (CachTinhGiaGio)kvRow.CACHTINHGIO;
                if (cachTinh == CachTinhGiaGio.THEOBANGGIA)
                {
                    DBANGGIAID = kvRow.DBANGGIAID;
                }
                else
                {
                    DonGia = kvRow.DONGIA;
                }
            }
            else if (cachTinh == CachTinhGiaGio.THEOBANGGIA)
            {
                DBANGGIAID = banRow.DBANGGIAID;
            }
            else
            {
                DonGia = banRow.DONGIA;
            }

            TienMoBan = banRow.TIENMOBAN;
        }

        private bool DoAddItemToGridWithoutTrack(DMATHANGRow spRow, decimal SoLuong, bool Auto, out decimal ThanhTien, out string TenHang)
        {
            ThanhTien = 0;
            TenHang = spRow.NAME;
            if (spRow.TAMKHOA == 30)
            {
                Msg.ShowWarning("Mặt hàng này tạm khóa, không thể sử dụng");
                return false;
            }

            if (string.IsNullOrEmpty(this.ID) && !string.IsNullOrEmpty(DBANID))
            {
                this.ID = TaoHoaDonTrang(DBANID, null);
                Reload(this.ID, DBANID);
            }

            bool isNew = SoLuong < 0;

            LoaiMatHang loai = (LoaiMatHang)ConvertTo.Int(spRow.DLOAIMATHANGID);
            bool laMatHangMo = loai == LoaiMatHang.MatHangMo;

            WriteToCustomerDisplay(spRow.NAME, SoLuong.ToString() + "x" + spRow.GIABAN.ToString("n0") + "=" + (SoLuong * spRow.GIABAN).ToString("n0"));

            decimal tiLeGiam = 0;
            if (SystemConfig.KichHoatKhuyenMaiTuDong == 30)
            {
                tiLeGiam = GetKhuyenMaiTheoMatHang(Config.Db.DbDateTime, spRow);
            }

            DataTable dt = DetailTable;
            //kiểm tra xem có tồn tại không
            if (!isNew && !laMatHangMo && SystemConfig.NhapMotMatHangNhieuLanTrongPhieu == 0 && loai != LoaiMatHang.DichVuTheoGio && dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow r = dt.Rows[i];
                    if (r == null || r.RowState == DataRowState.Deleted) continue;
                    TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(r);
                    if (row.DMATHANGID == spRow.ID && row.TILEGIAMGIA == tiLeGiam && (row.NOTE ?? "").Length == 0)
                    {
                        if (spRow.GIATHEOTHOIGIA == 30 || row.DONGIA == spRow.GIABAN)
                        {
                            //tăng số lượng lên
                            row.SLXUATCHUAQUYDOI = row.SLXUATCHUAQUYDOI + SoLuong;
                            row.SOLUONG = row.SLXUATCHUAQUYDOI;
                            if (string.IsNullOrEmpty(row.TENHANG)) row.TENHANG = spRow.NAME;
                            if (string.IsNullOrEmpty(row.DDONVITINHID)) row.DDONVITINHID = spRow.DDONVITINHID;
                            //cập nhật lại thành tiền
                            SafeCalculateRow(row.Row);
                            ThanhTien = row.THANHTIEN;
                            CapNhatCombo(row);
                            SaveChiTietDirect(row);
                            SaveDonHangTotals();
                            try
                            {
                                if (grDetail?.GridView != null && i < grDetail.GridView.Rows.Count)
                                {
                                    grDetail.GridView.ClearSelection();
                                    grDetail.GridView.Rows[i].Selected = true;
                                    grDetail.GridView.Refresh();
                                }
                            }
                            catch
                            {
                            }
                            return true;
                        }
                    }
                }
            }

            //trường hợp mặt hàng mở
            if (laMatHangMo)
            {
                //hiển thị cửa sổ nhập liệu
                ThemMatHangMo form = (ThemMatHangMo)Config.CreateForm(Forms.ThemMatHangMo);
                //đưa thông tin tên hàng
                form.SetData(spRow);
                //hiển thị
                if (form.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    //đặt lại tên hàng và giá bán của mặt hàng mở
                    spRow.DDONVITINHID = form.DDONVITINHID;
                    spRow.NAME = form.TenMatHang;
                    TenHang = spRow.NAME;
                    spRow.GIABAN = form.DonGia;
                }
                else return false;
            }
            //trường hợp không phải mặt hàng mở mà giá theo thời giá
            else if (spRow.GIATHEOTHOIGIA == 30)
            {
                //hiển thị để nhập đơn giá
                DoiGiaBan frmNhapDonGia = (DoiGiaBan)Config.CreateForm(Forms.DoiGiaBan);
                frmNhapDonGia.SetData(spRow.GIABAN, spRow.NAME);
                if (frmNhapDonGia.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    spRow.GIABAN = frmNhapDonGia.numDonGia.Value;
                }
                else
                {
                    return false;
                }
            }

            //chọn nhân viên theo từng dòng mặt hàng
            string DNHANVIENID = "";
            if (Shared.UngDung == UngDung.SPA)
            {
                TreeSelect frmNhanVien = new TreeSelect(Tables.DNHANVIEN.ToString(), "Chọn nhân viên");
                if (frmNhanVien.ShowDialog() != DialogResult.OK) return false;
                DNHANVIENID = frmNhanVien.CategoryID;
            }

            //nếu chưa có mặt hàng nào thì thêm mới vào lưới
            ThanhTien = AddItemToGridDirect(spRow, SoLuong, spRow.GIABAN, tiLeGiam, DNHANVIENID, spRow.DDONVITINHID);

            return true;
        }

        private decimal AddItemToGridDirect(DMATHANGRow spRow, decimal soLuong, decimal donGia, decimal tiLeGiam, string DNHANVIENID, string DDONVITINHID)
        {
            if (string.IsNullOrEmpty(this.ID) && !string.IsNullOrEmpty(DBANID))
            {
                this.ID = TaoHoaDonTrang(DBANID, null);
                Reload(this.ID, DBANID);
            }

            DataTable dt = DetailTable;
            if (dt == null)
            {
                LoadDetailGrid(this.ID);
                dt = DetailTable;
            }

            TDONHANGCHITIETRow newRow = new TDONHANGCHITIETRow(dt.NewRow());
            newRow.ID = Guid.NewGuid().ToString();
            newRow.TDONHANGID = this.ID;
            newRow.DMATHANGID = spRow.ID;
            LoaiMatHang loai = (LoaiMatHang)ConvertTo.Int(spRow.DLOAIMATHANGID);
            //tính đơn giá theo khu vực
            newRow.DNHANVIEN1ID = DNHANVIENID;
            if (spRow.DLOAIMATHANGID == ((int)LoaiMatHang.DichVuTheoGio).ToString())
            {
                DateTime gio = Config.Db.DbDateTime;
                newRow.TUGIO = gio;
                newRow.GIOTINHLUONG = gio;
            }

            newRow.DONGIA = donGia;
            newRow["DMATHANG_DLOAIMATHANGID"] = spRow.DLOAIMATHANGID;
            newRow["DDONVITINH_NAME"] = Config.Db.GetFirstFieldString(Tables.DDONVITINH, DDONVITINHInfo.NAME, DDONVITINHID);
            newRow["DVT"] = newRow["DDONVITINH_NAME"];
            newRow.DDONVITINHID = DDONVITINHID;
            newRow["THEOGIO"] = (loai == LoaiMatHang.DichVuTheoGio) ? 30 : 0;
            newRow.TENHANG = spRow.NAME;
            newRow["MATHANG"] = spRow.NAME;
            newRow.SLXUATCHUAQUYDOI = soLuong;
            newRow.SOLUONG = soLuong;
            newRow.SLXUAT = soLuong;
            newRow.GIAVON = spRow.GIAVON;
            string ComboID = Guid.NewGuid().ToString();
            newRow.COMBOID = ComboID;

            string DKHOHANGID = GetKhoHang(DBANID);
            newRow.DKHOHANGID = DKHOHANGID;

            newRow.TILEGIAMGIA = tiLeGiam;
            newRow.THANHTIEN = soLuong * donGia * (1 - tiLeGiam / 100);
            newRow.SOTT = dt != null ? dt.Rows.Count + 1 : 1;
            SafeCalculateRow(newRow.Row);
            dt.Rows.Add(newRow.Row);
            SaveChiTietDirect(newRow);
            mapper.RaiseOnCalculation();
            SaveDonHangTotals();

            //thêm combo chi tiết vào đơn hàng nếu có
            if (IsCombo(loai))
            {
                string sql = @"SELECT DVATTUID, SOLUONG, NAME, DMATHANG.DDONVITINHID, DMATHANG.GIAVON FROM DDINHLUONG INNER JOIN DMATHANG ON DDINHLUONG.DVATTUID = DMATHANG.ID WHERE DMATHANGID = '" + spRow.ID + "'";

                DataTable dtCombo = Config.Db.GetTable(sql);
                foreach (DataRow rCombo in dtCombo.Rows)
                {
                    TDONHANGCHITIETRow ctComboRow = new TDONHANGCHITIETRow();
                    ctComboRow.DMATHANGID = rCombo["DVATTUID"].ToString();
                    ctComboRow.DONGIA = 0;
                    ctComboRow.GIAVON = 0;
                    decimal comboSL = ConvertTo.Decimal(rCombo["SOLUONG"]);
                    ctComboRow.COMBOSL = comboSL;
                    ctComboRow.SLXUATCHUAQUYDOI = soLuong * comboSL;
                    ctComboRow.SLXUAT = soLuong * comboSL;
                    ctComboRow.TILEGIAMGIA = tiLeGiam; 
                    ctComboRow.DKHOHANGID = DKHOHANGID;
                    ctComboRow.TDONHANGID = this.ID;
                    ctComboRow.DDONVITINHID = rCombo["DDONVITINHID"].ToString();
                    ctComboRow.COMBOID = Guid.NewGuid().ToString();
                    ctComboRow.NOTE = "";
                    ctComboRow.COMBOPARENTID = ComboID;
                    ctComboRow.TENHANG = rCombo["NAME"].ToString();
                    SaveChiTietDirect(ctComboRow);
                }
            }

            try
            {
                tabMain.SelectedIndex = 0;

                if (grDetail?.GridView != null && grDetail.GridView.Rows.Count > 0)
                {
                    grDetail.GridView.ClearSelection();
                    grDetail.GridView.Rows[grDetail.GridView.Rows.Count - 1].Selected = true;
                    grDetail.Refresh();
                    grDetail.GridView.FirstDisplayedScrollingRowIndex = grDetail.GridView.Rows.Count - 1;
                }
            }
            catch
            {
            }

            return newRow.THANHTIEN;
        }

        /// <summary>
        /// Thêm mặt hàng vào hóa đơn
        /// </summary>
        /// <param name="spRow">Mặt hàng sẽ được thêm</param>
        /// <param name="SoLuong">Số lượng thêm</param>
        private void DoAddItemToGrid(DMATHANGRow spRow, decimal SoLuong, bool Auto)
        {
            decimal ThanhTien;
            string TenHang;
            if (DoAddItemToGridWithoutTrack(spRow, SoLuong, Auto, out ThanhTien, out TenHang))
            {
                Track(LoaiLuuVet.ThemMon, (Auto ? "Tự động thêm" : "Thêm") + " '" + spRow.NAME + "' vào bill, số lượng: " + SoLuong.ToString(), SoLuong, spRow.GIABAN, ThanhTien, TenHang);
            }
        }

        internal static string GetKhoHang(string DBANID)
        {
            return Config.Db.GetFirstFieldString("SELECT DKHOHANGID FROM DKHUVUC WHERE ID = (SELECT DKHUVUCID FROM DBAN WHERE ID = '" + DBANID + "')");
        }

        /// <summary>
        /// Kiểm tra loại mặt hàng có phải là combo hay không
        /// </summary>
        /// <param name="loai"></param>
        /// <returns></returns>
        internal static bool IsCombo(LoaiMatHang loai)
        {
            return loai == LoaiMatHang.Combo || loai == LoaiMatHang.ComboMo;
        } 

        /// <summary>
        /// Kiểm tra dòng đơn hàng có chứa mặt hàng combo hay không
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        internal static bool IsCombo(TDONHANGCHITIETRow row)
        {
            if (row == null || row.Row == null) return false;
            object val = row.Row.Table.Columns.Contains("DMATHANG_DLOAIMATHANGID") ? row["DMATHANG_DLOAIMATHANGID"] : null;
            LoaiMatHang loai = (LoaiMatHang)ConvertTo.Int(val);
            return IsCombo(loai);
        }

        /// <summary>
        /// Cập nhật các mặt hàng con của combo
        /// </summary>
        /// <param name="row"></param>
        internal static void CapNhatCombo(TDONHANGCHITIETRow row)
        {            
            if (IsCombo(row))
            {
                string sql = "UPDATE TDONHANGCHITIET SET SLXUATCHUAQUYDOI = COMBOSL * @SOLUONG, SLXUAT = COMBOSL * @SOLUONG WHERE COMBOPARENTID = '{0}'";
                sql = string.Format(sql, row.COMBOID);
                FbCommand cmd = Config.Db.GetCommand(sql);
                cmd.Parameters.Add("@SOLUONG", FbDbType.Decimal).Value = row.SLXUATCHUAQUYDOI;
                Config.Db.ExecSql(cmd);
            }
        }

        public static decimal GetTiLeKhuyenMaiTheoMatHang(DateTime now, string DMATHANGID)
        {
            decimal chietKhau = 0;
            DataTable dtKm = GetKhuyenMaiDangSuDung(Config.Db, now, LOAIHINHKHUYENMAI.GIAMGIATHEOSANPHAM);
            if (dtKm.Rows.Count > 0)
            {
                string where = GetWhere(dtKm);
                //kiem tra xem san pham co trong chi tiet khong
                chietKhau = Config.Db.GetFirstFieldDec("SELECT MAX(TILEGIAMGIA) FROM DDOTKHUYENMAICHITIET WHERE DMATHANGID = '" + DMATHANGID + "' AND " + where);
            }

            dtKm = GetKhuyenMaiDangSuDung(Config.Db, now, LOAIHINHKHUYENMAI.GIAMGIATHEONHOM);
            if (dtKm.Rows.Count > 0)
            {
                string where = GetWhere(dtKm);
                decimal val = Config.Db.GetFirstFieldDec("SELECT MAX(TILEGIAMGIA) FROM DDOTKHUYENMAICHITIET WHERE DNHOMMATHANGID = (SELECT DNHOMMATHANGID FROM DMATHANG WHERE ID = '" + DMATHANGID + "') AND " + where);
                if (val > chietKhau)
                    chietKhau = val;
            }

            return chietKhau;
        }

        internal static decimal GetKhuyenMaiTheoMatHang(DateTime now, DMATHANGRow spRow)
        {
            decimal chietKhau = GetTiLeKhuyenMaiTheoMatHang(now, spRow.ID);

            DataTable dtKm = GetKhuyenMaiDangSuDung(Config.Db, now, LOAIHINHKHUYENMAI.MATHANGDONGGIA);
            if (dtKm.Rows.Count > 0)
            {
                string where = GetWhere(dtKm);
                decimal val = Config.Db.GetFirstFieldDec("SELECT MIN(GIABAN) FROM DDOTKHUYENMAICHITIET WHERE DMATHANGID = '" + spRow.ID + "' AND " + where);
                if (val > 0) spRow.GIABAN = val;
            }

            return chietKhau;
        }

        private static string GetWhere(DataTable dtKm)
        {
            string where = "";
            foreach (DataRow r in dtKm.Rows)
            {
                if (where.Length > 0) where += " OR ";
                where += "DDOTKHUYENMAIID = '" + r["ID"].ToString() + "'";
            }
            return "(" + where + ")";
        }

        /// <summary>
        /// Lưu vết hoạt động
        /// </summary>
        /// <param name="NoiDung">Nội dung lưu vết</param>
        public void Track(LoaiLuuVet PhanLoai, string NoiDung, decimal SoLuong, decimal DonGia, decimal ThanhTien, string TenHang)
        {
            //nếu không kích hoạt chức năng lưu vết thì bỏ qua
            if (!CoLuuVet) return;
            string TenBan = lblBan.Text;
            if (TenBan.Length == 0)
            {
                string sql = "SELECT DBAN.NAME FROM TDONHANG INNER JOIN DBAN ON TDONHANG.DBANID = DBAN.ID WHERE TDONHANG.ID = '" + mapper.ID + "'";
                TenBan = Config.Db.GetFirstFieldString(sql);
            }

            DateTime gio = Config.Db.DbDateTime;
            if (mode == HoaDonMode.SuDungDichVu)
            {                
                TLUUVETRow row = new TLUUVETRow();
                row.GIO = gio;
                row.PHANLOAI = (int)PhanLoai;                

                row.BAN = TenBan;
                row.SODONHANG = mapper.ID;
                row.TAIKHOAN = DbConfig.UserName;
                row.THIETBI = Environment.MachineName;
                row.NGAY = gio.Date;
                row.NOTE = NoiDung;
                row.SOLUONG = SoLuong;
                row.TENHANG = TenHang;
                row.DONGIA = DonGia;
                row.THANHTIEN = ThanhTien;
                row.CHUCNANG = GetChucNang();
                row.Update();
            }
            else
            {
                if (lstLuuVet == null) lstLuuVet = new List<LuuVetInfo>();
                LuuVetInfo item = new LuuVetInfo();
                item.Gio = gio;
                item.Ngay = gio.Date;
                item.Note = NoiDung;
                item.PhanLoai = (int)PhanLoai;
                item.SoDonHang = mapper.ID;
                item.TaiKhoan = DbConfig.UserName;
                item.TenBan = TenBan;
                item.ThietBi = Environment.MachineName;
                item.TenHang = TenHang;
                item.ChucNang = GetChucNang();
                item.SoLuong = SoLuong;
                item.DonGia = DonGia;
                item.ThanhTien = ThanhTien;

                lstLuuVet.Add(item);
            }
        }

        private string GetChucNang()
        {
            return mode == HoaDonMode.SuDungDichVu ? "Sử dụng dịch vụ" : (mode == HoaDonMode.DieuChinhHoaDon ? "Điều chỉnh hóa đơn" : "Quản lý bán hàng");
        }

        List<LuuVetInfo> lstLuuVet;        

        /// <summary>
        /// Tạo số hóa đơn mới
        /// </summary>
        /// <param name="ngay">Ngày hóa đơn</param>
        /// <param name="So">Số hóa đơn ở dạng int</param>
        /// <returns></returns>
        public static string TaoSoHoaDon(Database Db, string UserId, DateTime ngay, out int So)
        {
            So = 1;
            try
            {
                //lấy ra số hóa đơn lớn nhất
                string sql = "SELECT ID, SO FROM TSOHOADON WHERE NGAY = @NGAY";
                DateTime val = ngay;
                switch (Shared.SoHDQuayVong)
                {
                    case SoHoaDonQuayVong.Thang:
                        val = ngay.AddDays(1 - ngay.Day);
                        break;
                    case SoHoaDonQuayVong.Nam:
                        val = new DateTime(ngay.Year, 1, 1);
                        break;
                    case SoHoaDonQuayVong.KhongQuayVong:
                        val = new DateTime(2000, 1, 1);
                        break;
                }
                FbCommand cmd = Db.GetCommand(sql);
                cmd.Parameters.Add("@NGAY", FbDbType.TimeStamp).Value = val;

                DataRow rSoHd = Db.GetFirstRow(cmd);
                So = 1;
                TSOHOADONRow soHdRow;
                if (rSoHd == null)
                {
                    cmd = Db.GetCommand("");

                    soHdRow = new TSOHOADONRow();
                    //lấy max số trong bảng hóa đơn                
                    switch (Shared.SoHDQuayVong)
                    {
                        case SoHoaDonQuayVong.Ngay:
                            sql = "SELECT MAX(SOHD) FROM TDONHANG WHERE LOAI = 0 AND NGAY = @NGAY";
                            cmd.Parameters.Add("@NGAY", FbDbType.TimeStamp).Value = ngay;
                            soHdRow.NGAY = ngay;
                            break;
                        case SoHoaDonQuayVong.Thang:
                            sql = "SELECT MAX(SOHD) FROM TDONHANG WHERE LOAI = 0 AND NGAY BETWEEN @TUNGAY AND @DENNGAY";
                            DateTime dauThang = ngay.AddDays(1 - ngay.Day);
                            soHdRow.NGAY = dauThang;
                            cmd.Parameters.Add("@TUNGAY", FbDbType.TimeStamp).Value = dauThang;
                            cmd.Parameters.Add("@DENNGAY", FbDbType.TimeStamp).Value = dauThang.AddMonths(1).AddDays(-1);
                            break;
                        case SoHoaDonQuayVong.Nam:
                            sql = "SELECT MAX(SOHD) FROM TDONHANG WHERE LOAI = 0 AND NGAY BETWEEN @TUNGAY AND @DENNGAY";
                            DateTime dauNam = new DateTime(ngay.Year, 1, 1);
                            cmd.Parameters.Add("@TUNGAY", FbDbType.TimeStamp).Value = dauNam;
                            cmd.Parameters.Add("@DENNGAY", FbDbType.TimeStamp).Value = dauNam.AddYears(1).AddDays(-1);
                            soHdRow.NGAY = dauNam;
                            break;
                        case SoHoaDonQuayVong.KhongQuayVong:
                            sql = "SELECT MAX(SOHD) FROM TDONHANG WHERE LOAI = 0";
                            soHdRow.NGAY = val;
                            break;
                    }

                    cmd.CommandText = sql;
                    So = Db.GetFirstFieldInt(cmd);
                }
                else
                {
                    So = ConvertTo.Int(rSoHd["SO"]);
                    //soHdRow = new TSOHOADONRow(Db.GetFirstRow(Tables.TSOHOADON, "ID='" + rSoHd["ID"].ToString() + "'"));
                    soHdRow = new TSOHOADONRow(rSoHd["ID"].ToString());
                }

                //Số mới sẽ lớn hơn số cũ 1 đơn vị
                So++;
                soHdRow.SO = So;
                soHdRow.NAME = "";
                soHdRow.Update(Db, UserId);

                switch (Shared.SoHDQuayVong)
                {
                    case SoHoaDonQuayVong.Ngay:
                        return ngay.ToString("ddMM") + So.ToString("0000");
                    case SoHoaDonQuayVong.Thang:
                        return ngay.ToString("MMyy") + So.ToString("00000");
                    case SoHoaDonQuayVong.Nam:
                        return ngay.ToString("yy") + So.ToString("000000");
                    default:
                        return So.ToString("0000000");
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public event EventHandler OnAfterThanhToan;
        public event EventHandler OnRefreshTrangThaiRequest;
        /// <summary>
        /// Yêu cầu giao diện cập nhật lại trạng thái bàn
        /// </summary>
        private void RefreshTrangThaiBan()
        {
            if (OnRefreshTrangThaiRequest != null) OnRefreshTrangThaiRequest(this, EventArgs.Empty);
        }
        
        /// <summary>
        /// Cập nhật lại toolbar khi thay đổi chọn món trong danh sách hóa đơn
        /// </summary>        
        void grDetail_SelectionChanged(object sender, EventArgs e)
        {            
            SetDetailButtonEnable(btnThanhToan.Enabled);
        }

        private void SetDetailButtonEnable(bool chuaThanhToan)
        {
            bool selected = grDetail.GridView.SelectedRows.Count > 0 && chuaThanhToan;
            if (selected)
            {
                selected = grDetail.GridView.SelectedRow["DMATHANGID"].ToString() != "KM";
            }
            tsbTang1.Enabled = selected;
            btnGiam.Enabled = selected;
            tsbGiam1.Enabled = selected;
            tsbDatSoLuong.Enabled = selected;
            tsbDoiGiaBan.Enabled = selected;
            btnXoa.Enabled = selected;
            tsbNote.Enabled = selected;
            tsbCK.Enabled = selected;
        }

        /// <summary>
        /// Xử lý khi nháy đúp chuột vào danh sách hóa đơn
        /// </summary>        
        void grDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex >= 0)
            {
                string colName = grDetail.GridView.Columns[e.ColumnIndex].DataPropertyName;                
                //nháy đúp vào cột đơn giá
                if (colName == "DONGIA")
                {
                    tsbDoiGiaBan.PerformClick();
                }
                //nháy đúp vào cột tỉ lệ giảm giá
                else if (colName == "TILEGIAMGIA")
                {
                    tsbCK.PerformClick();
                }
                //nháy đúp vào cột số lương
                else if (colName == "SLXUATCHUAQUYDOI" || colName == "SOLUONG")
                {
                    tsbDatSoLuong.PerformClick();
                }
                //nháy đúp vào cột ghi chú
                else if (colName == "NOTE")
                {
                    tsbNote.PerformClick();
                }
                //nháy đúp vào cột từ giờ, đến giờ
                else if (colName == "TUGIO" || colName == "DENGIO")
                {
                    tsbDatSoLuong_Click(null, null);
                }
                else
                {
                    //kiểm tra xem có phải combo không?
                    TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(grDetail.GridView.SelectedRow);
                    if (IsCombo(row))
                    {
                        ChiTietCombo form = (ChiTietCombo)Config.CreateForm(Forms.ChiTietCombo);
                        form.SetData(row);
                        form.No1Form1.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// Chọn mặt hàng ở vị trí click chuột
        /// </summary>        
        void grMatHang_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    grMatHang.ClearSelection();
                    grMatHang.Rows[e.RowIndex].Selected = true;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Thêm mặt hàng khi nháy đúp chuột
        /// </summary>        
        void grMatHang_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (grMatHang.Rows.Count > e.RowIndex)
            {
                grMatHang.ClearSelection();
                grMatHang.Rows[e.RowIndex].Selected = true;
            }

            if (DaThanhToan(true)) return;

            if (string.IsNullOrEmpty(DBANID))
            {
                Msg.ShowWarning(string.Format("Mời bạn chọn {0} trước khi thêm món!", Shared.GetTenPhongBan(true)));
                return;
            }

            // Nếu bàn chưa bắt đầu, tự động mở bàn
            if (string.IsNullOrEmpty(this.ID))
            {
                this.ID = TaoHoaDonTrang(DBANID, null);
                Reload(this.ID, DBANID);
            }

            btnThem.PerformClick();
        }

        /// <summary>
        /// Thay đổi trạng thái các nút khi chọn mặt hàng
        /// </summary>        
        void grMatHang_SelectionChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = btnThanhToan.Enabled && grMatHang.SelectedRows.Count > 0;
            btnGiam.Enabled = btnThanhToan.Enabled && grMatHang.SelectedRows.Count > 0;
        }

        void grMatHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grMatHang.SelectedRows.Count > 0)
                {
                    btnThem.PerformClick();
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Tính toán trên từng dòng dữ liệu
        /// </summary>        
		public void grDetail_OnRowCalculate(object sender, DataRow r, string fieldName)
		{
            TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(r);
            UpdateThanhTien(row);
		}

        /// <summary>
        /// Tính toán lại giá trị từng dòng
        /// </summary>
        /// <param name="row">Dòng cần tính toán</param>
        internal static void UpdateThanhTien(TDONHANGCHITIETRow row)
        {
            row.SLXUAT = row.SLXUATCHUAQUYDOI;
            //nếu giảm trực tiếp theo tiền
            if (row.GIAMTHEOTIEN == 30)
            {
                row.THANHTIEN = row.DONGIA * row.SLXUATCHUAQUYDOI - row.TIENGIAMGIA;
            }
            else //ngược lại tính thành tiền theo tỉ lệ giảm giá
            {
                row.THANHTIEN = row.DONGIA * row.SLXUATCHUAQUYDOI * (1 - row.TILEGIAMGIA / 100);
                row.TIENGIAMGIA = row.DONGIA * row.SLXUATCHUAQUYDOI - row.THANHTIEN;
            }            
        }

        /// <summary>
        /// Tính toán tổng bill
        /// </summary>        
		public void mapper_OnCalculation(object sender, EventArgs e)
		{
            if (string.IsNullOrEmpty(this.ID)) return;
            TrackByControl(sender);

            decimal tongThanhTien = 0;
            decimal tongChuaGiam = 0;
            DataTable dtDetailTable = DetailTable;
            if (dtDetailTable != null)
            {
                foreach (DataRow row in dtDetailTable.Rows)
                {
                    if (row == null || row.RowState == DataRowState.Deleted) continue;
                    decimal soLuong = ConvertTo.Decimal(row["SLXUATCHUAQUYDOI"]);
                    if (soLuong <= 0) soLuong = ConvertTo.Decimal(row["SOLUONG"]);
                    if (soLuong <= 0) soLuong = ConvertTo.Decimal(row["SLXUAT"]);
                    if (soLuong <= 0) soLuong = 1;
                    decimal donGia = ConvertTo.Decimal(row["DONGIA"]);
                    decimal tiLeGiam = row.Table.Columns.Contains("TILEGIAMGIA") ? ConvertTo.Decimal(row["TILEGIAMGIA"]) : 0;
                    decimal tienGiam = row.Table.Columns.Contains("TIENGIAMGIA") ? ConvertTo.Decimal(row["TIENGIAMGIA"]) : 0;
                    decimal tienChuaGiamRow = soLuong * donGia;

                    decimal thanhTien;
                    if (row.Table.Columns.Contains("THANHTIEN") && row["THANHTIEN"] != DBNull.Value && (tiLeGiam > 0 || tienGiam > 0 || ConvertTo.Decimal(row["THANHTIEN"]) > 0))
                    {
                        thanhTien = ConvertTo.Decimal(row["THANHTIEN"]);
                    }
                    else
                    {
                        thanhTien = tienChuaGiamRow - (tienChuaGiamRow * tiLeGiam / 100m) - tienGiam;
                        if (thanhTien < 0) thanhTien = 0;
                        if (row.Table.Columns.Contains("THANHTIEN"))
                            row["THANHTIEN"] = thanhTien;
                    }

                    tongThanhTien += thanhTien;
                    tongChuaGiam += tienChuaGiamRow;
                }
            }

            tongChuaGiam = LamTron(tongChuaGiam, LamTronTien);
            tongThanhTien = LamTron(tongThanhTien, LamTronTien);
            numTIENHANG.Value = tongThanhTien;
            SetDonHangField("TIENHANGCHUAGIAM", tongChuaGiam);
            SetDonHangField("GIAMGIAMATHANG", (tongChuaGiam - tongThanhTien));
            numTIENGIO.Value = numTIENGIOPHONGCUOI.Value + SafeCalcSum(grGioHat, "THANHTIEN");

            decimal TienHangSauGiam;
            if (GopChungChietKhauLamMot) //Giảm giá tiền hàng & tiền giờ gộp chung
            {
                //Tính tổng tiền hàng & tiền giờ trước giảm giá
                decimal Tong = (numTIENGIO.Value + numTIENHANG.Value);
                if (_giamTongTheoTien == 30)
                {
                    //Nếu là giảm trên tổng gộp & giảm theo tiền thì chia ngược lại để lấy %
                    decimal val = Tong == 0 ? 0M : Math.Round(numTIENGIAMGIATONG.Value * 100 / Tong, 2, MidpointRounding.AwayFromZero);                    
                    numTILEGIAMGIATONG.Value = val;

                    //Tính tỉ lệ giảm giá tiền hàng
                    numTILEGIAMGIA.Value = val;
                    //Tính tiền giảm giá hàng
                    if (numTIENGIO.Value == 0)
                        numTIENGIAMGIA.Value = numTIENGIAMGIATONG.Value;
                    else
                        numTIENGIAMGIA.Value = LamTron(numTIENHANG.Value * numTIENGIAMGIATONG.Value / numTIENGIO.Value, LamTronTien);

                    //Tính tỉ lệ giảm giá giờ
                    numTILEGIAMGIAGIO.Value = val;
                    //Tính tiền giảm giá giờ
                    numTIENGIAMGIAGIO.Value = numTIENGIAMGIATONG.Value - numTIENGIAMGIA.Value;
                }
                else //Nếu là giảm giá theo tỉ lệ
                {
                    //Tính lại tiền giảm giá tổng
                    numTIENGIAMGIATONG.Value = LamTron(numTILEGIAMGIATONG.Value * Tong / 100, LamTronTien);

                    //Tỉ lệ giảm giá tiền hàng & giờ phải theo tỉ lệ giảm giá tổng
                    numTILEGIAMGIA.Value = numTILEGIAMGIATONG.Value;
                    numTIENGIAMGIA.Value = LamTron(numTIENHANG.Value * numTILEGIAMGIA.Value / 100, LamTronTien);

                    //Tính tỉ lệ giảm giá giờ
                    numTILEGIAMGIAGIO.Value = numTILEGIAMGIATONG.Value;
                    numTIENGIAMGIAGIO.Value = numTIENGIAMGIATONG.Value - numTIENGIAMGIA.Value;
                }

                TienHangSauGiam = numTIENHANG.Value + numTIENGIO.Value - numTIENGIAMGIATONG.Value;
            }
            else //Giảm giá tiền hàng & tiền giờ riêng
            {
                //Tính giảm giá tiền hàng
                decimal Tong = numTIENHANG.Value;
                if (_giamTheoTien == 30)
                {
                    numTILEGIAMGIA.Value = Tong == 0 ? 0M : Math.Round(numTIENGIAMGIA.Value * 100 / Tong, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    numTIENGIAMGIA.Value = LamTron(numTILEGIAMGIA.Value * Tong / 100, LamTronTien);
                }

                //Tình giảm giá tiền giờ
                Tong = numTIENGIO.Value;
                if (_giamGiaGioTheoTien == 30)
                {
                    numTILEGIAMGIAGIO.Value = Tong == 0 ? 0M : Math.Round(numTIENGIAMGIAGIO.Value * 100 / Tong, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    numTIENGIAMGIAGIO.Value = LamTron(numTILEGIAMGIAGIO.Value * Tong / 100, LamTronTien);
                }

                TienHangSauGiam = numTIENHANG.Value + numTIENGIO.Value - numTIENGIAMGIA.Value - numTIENGIAMGIAGIO.Value;

                //Tính gộp ra giảm giá tổng
                if (numTIENHANG.Value + numTIENGIO.Value > 0)
                {
                    numTILEGIAMGIATONG.Value = (1 - TienHangSauGiam / (numTIENHANG.Value + numTIENGIO.Value)) * 100;
                    numTIENGIAMGIATONG.Value = numTIENGIAMGIATONG.Value - TienHangSauGiam;
                }
                else
                {
                    numTILEGIAMGIATONG.Value = 0;
                    numTIENGIAMGIATONG.Value = 0;
                }
            }

            //Tính phí dịch vụ
            if (_phiDichVuTheoTien == 30)
            {
                numTILEPHIDICHVU.Value = TienHangSauGiam == 0 ? 0M : Math.Round(numPHIDICHVU.Value * 100 / TienHangSauGiam, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                numPHIDICHVU.Value = LamTron(numTILEPHIDICHVU.Value * TienHangSauGiam / 100, LamTronTien);
            }

            TienHangSauGiam += numPHIDICHVU.Value;

            //Tính thuế
            numTIENTHUE.Value = LamTron(TienHangSauGiam * numTILETHUE.Value / 100, LamTronTien);
            decimal TongCong = TienHangSauGiam + numTIENTHUE.Value;

            numTONGCONG.Value = LamTron(TongCong, LamTronTien);
            TIENPHAITRA.Value = numTONGCONG.Value + BILLKHAC.Value;

            //chỉ cập nhật luôn ở giao diện sử dụng dịch vụ
            if (!string.IsNullOrEmpty(this.ID) && mode == HoaDonMode.SuDungDichVu)
            {                
                //Kiểm tra đã thanh toán chưa
                if (!DaThanhToan(true))
                {
                    try { mapper.Update(); } catch { }
                    SaveDonHangTotals();
                }
            }
		}

        internal static decimal LamTron(decimal TongCong, int LamTronTien)
        {
            if (LamTronTien <= 0) return TongCong;
            return LamTronTien * Math.Round(TongCong / LamTronTien, 0, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Lưu vết theo control thay đổi
        /// </summary>
        /// <param name="sender">Control phát sinh sự thay đổi</param>
        private void TrackByControl(object sender)
        {
            Control control = sender as Control;
            if (control == null) return;
            if (!control.Focused && control != lueDKHACHHANGID && !(control is No1DatePicker)) return;
            if (control == numSOKHACH)
            {
                Track(LoaiLuuVet.Khac, "Đổi số khách " + numSOKHACH.Value.ToString("n0"), 0, 0, 0, "");
            }
            else if (control == numTILEGIAMGIA)
            {
                Track(LoaiLuuVet.Khac, "Đặt tỉ lệ giảm giá " + numTILEGIAMGIA.Value.ToString("n2"), 0, 0, 0, "");
            }
            else if (control == numTIENGIAMGIA)
            {
                Track(LoaiLuuVet.Khac, "Đặt tiền giảm giá " + numTIENGIAMGIA.Value.ToString("n0"), 0, 0, 0, "");
            }
            else if (control == numTILEGIAMGIAGIO)
            {
                Track(LoaiLuuVet.Khac, "Đặt tỉ lệ giảm giá giờ" + numTILEGIAMGIA.Value.ToString("n2"), 0, 0, 0, "");
            }
            else if (control == numTIENGIAMGIAGIO)
            {
                Track(LoaiLuuVet.Khac, "Đặt tiền giảm giá giờ" + numTIENGIAMGIAGIO.Value.ToString("n0"), 0, 0, 0, "");
            }
            else if (control == numTILETHUE)
            {
                Track(LoaiLuuVet.Khac, "Đặt tỉ lệ thuế" + numTILETHUE.Value.ToString("n2"), 0, 0, 0, "");
            }
            else if (control == numTILEPHIDICHVU)
            {
                Track(LoaiLuuVet.Khac, "Đặt tỉ lệ phí dịch vụ" + numTILEPHIDICHVU.Value.ToString("n2"), 0, 0, 0, "");
            }
            else if (control == numPHIDICHVU)
            {
                Track(LoaiLuuVet.Khac, "Đặt phí dịch vụ" + numPHIDICHVU.Value.ToString("n0"), 0, 0, 0, "");
            }
            else if (control == numTILEGIAMGIATONG)
            {
                Track(LoaiLuuVet.Khac, "Đặt tỉ lệ giảm giá tổng" + numTILEGIAMGIATONG.Value.ToString("n2"), 0, 0, 0, "");
            }
            else if (control == numTIENGIAMGIATONG)
            {
                Track(LoaiLuuVet.Khac, "Đặt tiền giảm giá tổng" + numTIENGIAMGIATONG.Value.ToString("n0"), 0, 0, 0, "");
            }
            else if (control == txtNOTE)
            {
                Track(LoaiLuuVet.Khac, "Đặt ghi chú '" + txtNOTE.Text + "'", 0, 0, 0, "");
            }
            else if (control == lueDKHACHHANGID)
            {
                Track(LoaiLuuVet.Khac, "Đặt khách hàng '" + lueDKHACHHANGID.DisplayText + "'", 0, 0, 0, "");
            }
            else if (control == lueDNHANVIENXUATID)
            {
                Track(LoaiLuuVet.Khac, "Đặt nhân viên '" + lueDNHANVIENXUATID.DisplayText + "'", 0, 0, 0, "");
            }
            else if (control == dtBATDAUPHONGCUOI)
            {
                Track(LoaiLuuVet.Khac, "Đổi giờ vào '" + dtBATDAUPHONGCUOI.DateTime.ToString("dd/MM/yyyy HH:mm") + "'", 0, 0, 0, "");
            }
            else if (control == dtKETTHUC)
            {
                Track(LoaiLuuVet.Khac, "Đổi giờ ra '" + dtKETTHUC.DateTime.ToString("dd/MM/yyyy HH:mm") + "'", 0, 0, 0, "");
            }
        }

        /// <summary>
        /// Hiển thị cửa sổ để chọn bàn
        /// </summary>
        /// <param name="mode"></param>
        private void ShowChonBan(ChonBanMode mode)
        {
            //tạo form hiển thị
            ChonBan form = (ChonBan)Config.CreateForm(Forms.ChonBan);
            form.SetData(mode);
            if (form.No1Form1.ShowDialog() == DialogResult.OK)
            {
                string DBANID = form.DBANID;
                string DKHUVUCID = form.DKHUVUCID;
                if (SelectBanTuTabRequest != null) SelectBanTuTabRequest(DBANID, DKHUVUCID, form.LaBanTrong);                
            }            
        }

        /// <summary>
        /// Lấy số lượng lựa chọn theo combobox hay nhập liệu trực tiếp
        /// </summary>
        /// <returns></returns>
        private decimal getSoLuong()
        {
            decimal val = 1;
            if (numSoLuong != null && numSoLuong.Visible)
            {
                val = numSoLuong.Value;
            }
            else if (cboSoLuong != null)
            {
                if (!decimal.TryParse(cboSoLuong.Text, out val) || val <= 0)
                    val = 1;
            }
            if (val <= 0) val = 1;
            return val;
        }

        public event SelectBanTuTabRequestHandler SelectBanTuTabRequest;

        /// <summary>
        /// Xử lý shortcut
        /// </summary>        
		public void mapper_OnKeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.F10)
            {
                btnInCheBien.PerformClick();
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnThanhToan.PerformClick();
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (lueDKHACHHANGID.Enabled)
                    lueDKHACHHANGID.Select();
                else if (btnSearch.Visible && btnSearch.Enabled)
                    btnSearch.PerformClick();
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnThongKe.PerformClick();
            }
            else if (e.KeyCode == Keys.F5)
            {
                ShowChonBan(ChonBanMode.Empty);
            }
            else if (e.KeyCode == Keys.F6)
            {
                ShowChonBan(ChonBanMode.Busy);
            }
            else if (e.KeyCode == Keys.F7)
            {
                ShowChonBan(ChonBanMode.All);
            }
            else if (e.KeyCode == Keys.F3)
            {
                txtTimKiem.SelectAllEx();
            }
            else if (e.KeyCode == Keys.F2)
            {
                tsbNote.PerformClick();
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnInLaiBill.PerformClick();
            }
            else if (e.KeyCode == Keys.F4 && btnThanhToan.Enabled && !e.Alt)
            {
                TreeSelect form = new TreeSelect(Tables.DNHANVIEN.ToString(), "Chọn nhân viên");
                if (form.ShowDialog() == DialogResult.OK)
                {
                    lueDNHANVIENXUATID.EditValue = form.CategoryID;
                }
            }
		}

        /// <summary>
        /// Kiểm tra xem có quyền giảm đồ không
        /// </summary>
        /// <returns></returns>
        private bool DuocPhepGiamDo()
        {
            if (SystemConfig.NhapMatKhauGiamDo == 30)
            {                
                //input admin's password
                NhapMatKhauGiamDo form = (NhapMatKhauGiamDo)Config.CreateForm(Forms.NhapMatKhauGiamDo);
                if (form.No1Form1.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }                
                return true;
            }
            return true;
        }

        /// <summary>
        /// Xử lý khi click +
        /// </summary>        
		public void tsbTang1_Click(object sender, EventArgs e)
		{
            //nếu đã thanh toàn thì bỏ qua
            if (DaThanhToan(true)) return;

            foreach (DataGridViewRow r in grDetail.GridView.SelectedRows)
            {
                DataRow row = (r.DataBoundItem as DataRowView).Row;
                if (ConvertTo.Int(row["THEOGIO"]) == 30)
                {
                    Msg.ShowWarning("Mặt hàng dịch vụ theo giờ không thể thay đổi số lượng bằng chức năng này");
                    return;
                }
                TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(row);
                ctRow.SLXUATCHUAQUYDOI = ctRow.SLXUATCHUAQUYDOI + 1;                
                SafeCalculateRow(ctRow.Row, -1);                
                Track(LoaiLuuVet.TangMon, "Tăng số lượng '" + ctRow.TENHANG + "' lên 1 ", ctRow.SLXUATCHUAQUYDOI, ctRow.DONGIA, ctRow.THANHTIEN, ctRow.TENHANG);

                CapNhatCombo(ctRow);
                SaveChiTietDirect(ctRow);
            }

            mapper_OnCalculation(this, EventArgs.Empty);
            SaveDonHangTotals();
            StartAutoPrintTimer();
		}

        /// <summary>
        /// Kiểm tra xem đã thanh toán chưa, nếu đã thanh toán hiển thị thông báo
        /// </summary>
        /// <param name="showMessage">Có hiển thị thông báo khi không được phép sửa hay không?</param>
        /// <returns></returns>
        private bool DaThanhToan(bool showMessage)
        {
            bool val = mode == HoaDonMode.SuDungDichVu && IsDaThanhToan(mapper.ID);
            if (val && showMessage)
            {
                Msg.ShowWarning("Hóa đơn này đã thanh toán, không thể thay đổi");
            }
            return val;
        }

        /// <summary>
        /// Kiểm tra hóa đơn đã in tạm tính chưa
        /// </summary>
        /// <returns></returns>
        private bool KiemTraDaInTamTinh()
        {
            if (mode != HoaDonMode.SuDungDichVu) return false;

            if (DbUtils.CanView(Functions.DuocGiamDoSauKhiInTamTinh)) return false;            
            string sql = string.Format("SELECT SOLANINTAMTINH FROM TDONHANG WHERE ID = '{0}'", mapper.ID);            
            return Config.Db.GetFirstFieldInt(sql) > 0;
        }

        /// <summary>
        /// Thực hiện khi giảm số lượng 1
        /// </summary>        
		public void tsbGiam1_Click(object sender, EventArgs e)
		{
            //kiểm tra xem có được phép giảm đồ không
            if (!DuocPhepGiamDo()) return;
            //kiểm tra xem đã thanh toán chưa, nếu thanh toán rồi thì không cho phép thay đổi
            if (DaThanhToan(true)) return;
            //kiểm tra xem đã in tạm tính chưa nếu in rồi thì không cho phép thay đổi
            if (KiemTraDaInTamTinh())
            {
                Msg.ShowWarning("Không thể giảm vì phiếu đã in tạm tính");
                return;
            }
            
            foreach (DataGridViewRow r in grDetail.GridView.SelectedRows)
            {
                //không thay đổi với các mặt hàng thay đổi theo giờ
                DataRow row = (r.DataBoundItem as DataRowView).Row;
                if (ConvertTo.Int(row["THEOGIO"]) == 30)
                {
                    Msg.ShowWarning("Mặt hàng dịch vụ theo giờ không thể thay đổi số lượng bằng chức năng này");                    
                    return;
                }

                TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(row);
                //kiểm tra số lượng hàng đã in pha chế
                if (KhongDuocXoaSauKhiInPhaChe())
                {
                    decimal soLuongSau = Math.Max(GetSoLuongSauGiam(ctRow, 1, DetailTable), 1);
                    //kiểm tra đã in xuống bếp chưa
                    decimal daIn = GetSoLuongDaIn(ctRow, mapper.ID);
                    if (daIn > soLuongSau)
                    {
                        Msg.ShowWarning("Bạn đã in xuống bếp số lượng " + daIn.ToString() + ". Không thể giảm.");
                        return;
                    }
                }

                ctRow.SLXUATCHUAQUYDOI = Math.Max(ctRow.SLXUATCHUAQUYDOI - 1, 1);
                ctRow.SOLUONG = ctRow.SLXUATCHUAQUYDOI;
                ctRow.SLXUAT = ctRow.SLXUATCHUAQUYDOI;
                SafeCalculateRow(ctRow.Row, -1);
                Track(LoaiLuuVet.GiamMon, "Giảm số lượng '" + ctRow.TENHANG + "' đi 1 ", ctRow.SLXUATCHUAQUYDOI, ctRow.DONGIA, ctRow.THANHTIEN, ctRow.TENHANG);

                //cập nhật lại các mặt hàng con với các mặt hàng combo
                CapNhatCombo(ctRow);
                SaveChiTietDirect(ctRow);
            }
            mapper_OnCalculation(this, EventArgs.Empty);
            SaveDonHangTotals();
            StartAutoPrintTimer();
		}

        private bool KhongDuocXoaSauKhiInPhaChe()
        {
            return mode == HoaDonMode.SuDungDichVu && (SystemConfig.KhongDuocGiamDoSauKhiInPhaChe == 30 || !DbUtils.CanView(Functions.XoaGiamMonSauKhiInCheBien));
        }

        /// <summary>
        /// Lấy tổng số lượng đã in của một dòng mặt hàng
        /// </summary>
        /// <param name="TDONHANGCHITIETID"></param>
        /// <returns>Số lượng đã in</returns>
        internal static decimal GetSoLuongDaIn(TDONHANGCHITIETRow ctRow, string TDONHANGID)
        {
            //nếu là combo lấy ra tất cả các mặt hàng con
            if (IsCombo(ctRow))
            {
                string sql = "SELECT DISTINCT TENHANG FROM TDONHANGCHITIET WHERE COMBOPARENTID = '" + ctRow.COMBOID + "'";
                DataTable dtCombo = Config.Db.GetTable(sql);
                if (dtCombo.Rows.Count > 0)
                {
                    FbCommand cmd = Config.Db.GetCommand("");
                    string where = "";
                    int i =0;
                    foreach (DataRow r in dtCombo.Rows)
                    {
                        if (where.Length > 0) where += " OR ";
                        where += "TENHANG = @p" + i.ToString();
                        cmd.Parameters.Add("@p" + i.ToString(), FbDbType.VarChar).Value = r["TENHANG"].ToString();
                        i++;
                    }
                    sql = "SELECT SUM(SOLUONG) FROM TINCHEBIEN WHERE (" + where + ") AND TDONHANGID = '" + TDONHANGID + "'";
                    cmd.CommandText = sql;                    
                    return ConvertTo.Decimal(Config.Db.GetFirstField(cmd));
                }
                return 0;
            }
            else
            {
                string sql = "SELECT SUM(SOLUONG) FROM TINCHEBIEN WHERE TENHANG = '" +  ctRow.TENHANG.Replace("'", "''") + "' AND TDONHANGID = '" + TDONHANGID + "'";
                FbCommand cmd = Config.Db.GetCommand(sql);                
                return ConvertTo.Decimal(Config.Db.GetFirstField(cmd));
            }
        }


        /// <summary>
        /// Đặt số lượng cho mặt hàng trực tiếp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public void tsbDatSoLuong_Click(object sender, EventArgs e)
		{
            //bỏ qua nếu không chọn dòng nào
            if (grDetail.GridView.SelectedRows.Count == 0) return;
            //bỏ qua nếu hóa đơn đã thanh toán
            if (DaThanhToan(true)) return;
            
            //kiểm tra đã in tạm tính hay chưa?
            if (KiemTraDaInTamTinh())
            {
                Msg.ShowWarning("Phiếu đã in tạm tính, mời bạn sử dụng chức năng thêm hoặc click nút dấu '+' phía bên trái");
                return;
            }

            TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(grDetail.GridView.SelectedRow);
            //với mặt hàng dịch vụ theo giờ, hiển thị cửa sổ cho chọn từ giờ, đến giờ
            if (ConvertTo.Int(row["THEOGIO"]) == 30)
            {
                DataRow r = grDetail.GridView.SelectedRow;
                if (r == null) return;
                string ID = r["DMATHANGID"].ToString();
                DMATHANGRow mhRow = new DMATHANGRow(ID);
                if (ConvertTo.Int(mhRow.DLOAIMATHANGID) == (int)LoaiMatHang.DichVuTheoGio)
                {
                    TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(r);
                    DatGioChoMatHang form = (DatGioChoMatHang)Config.CreateForm(Forms.DatGioChoMatHang);
                    form.SetData(mhRow, ctRow, GetDonHangDateTime("BATDAU", dtKETTHUC.DateTime), dtKETTHUC.DateTime);
                    if (form.No1Form1.ShowDialog() == DialogResult.OK)
                    {
                        //cập nhật lại từ giờ, đến giờ
                        TDONHANGCHITIETRow upRow = new TDONHANGCHITIETRow(ctRow.ID);
                        upRow.DENGIO = form.KetThuc;
                        upRow.TUGIO = form.BatDau;
                        upRow.GIOTINHLUONG = form.GioTinhLuong;

                        Track(LoaiLuuVet.DatSoLuong, "Đặt thời gian '" + row.TENHANG + "', Từ giờ: " + row.TUGIO.ToString("dd/MM/yyy HH:mm") + ", Đến giờ:" + row.DENGIO.ToString("dd/MM/yyyy HH:mm"), ctRow.SLXUATCHUAQUYDOI, ctRow.DONGIA, ctRow.THANHTIEN, ctRow.TENHANG);

                        upRow.Update();
                        ctRow.DENGIO = form.KetThuc;
                        ctRow.TUGIO = form.BatDau;
                        ctRow.GIOTINHLUONG = form.GioTinhLuong;
                        UpdateTongThoiGian();
                    }
                }
                else
                {
                    Msg.ShowWarning("Mặt hàng/Dịch vụ '" + mhRow.NAME + "' không theo giờ");
                }
            }
            else
            {
                //với các mặt hàng thông thường, hiển thị cửa sổ để nhập số lượng
                DatSoLuong form = (DatSoLuong)Config.CreateForm(Forms.DatSoLuong);
                form.SetData(row.SLXUATCHUAQUYDOI, row.TENHANG);
                if (form.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    if (row.SLXUATCHUAQUYDOI > form.spSoLuong.Value)
                    {
                        //kiểm tra xem có được phép giảm đồ hay không?
                        if (!DuocPhepGiamDo()) return;

                        if (SystemConfig.KhongDuocGiamDoSauKhiInPhaChe == 30 || !DbUtils.CanView(Functions.XoaGiamMonSauKhiInCheBien))
                        {
                            //kiểm tra xem đã in chế biến chưa?
                            decimal soLuongSau = GetSoLuongSauGiam(row, row.SLXUATCHUAQUYDOI - form.spSoLuong.Value, DetailTable);
                            //kiểm tra đã in xuống bếp chưa
                            decimal daIn = GetSoLuongDaIn(row, mapper.ID);
                            if (daIn > soLuongSau)
                            {
                                Msg.ShowWarning("Bạn đã in xuống bếp số lượng " + daIn.ToString() + ". Không thể giảm.");
                                return;
                            }
                        }
                    }

                    decimal slCu = row.SLXUATCHUAQUYDOI;

                    row.SLXUATCHUAQUYDOI = form.spSoLuong.Value;
                    row.SOLUONG = row.SLXUATCHUAQUYDOI;
                    row.SLXUAT = row.SLXUATCHUAQUYDOI;
                    SafeCalculateRow(row.Row);                    
                    Track(slCu > row.SLXUATCHUAQUYDOI ? LoaiLuuVet.GiamMon : LoaiLuuVet.TangMon, "Đặt số lượng '" + row.TENHANG + "' từ  " + slCu + " thành : " + row.SLXUATCHUAQUYDOI, Math.Abs(slCu - row.SLXUATCHUAQUYDOI), row.DONGIA, row.THANHTIEN, row.TENHANG);
                    //với mặt hàng combo
                    CapNhatCombo(row);
                    SaveChiTietDirect(row);
                    mapper_OnCalculation(this, EventArgs.Empty);
                    SaveDonHangTotals();
                    StartAutoPrintTimer();
                }
            }
		}


		public void tsbDoiGiaBan_Click(object sender, EventArgs e)
		{
            //if (LaNhanVienChayBan()) return;
            if (DaThanhToan(true)) return;
            if (grDetail.GridView.SelectedRows.Count == 0) return;

            //kiểm tra quyền
            if (!DbUtils.CanLogin(Functions.SuaDonGia)) return;

            TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(grDetail.GridView.SelectedRow);
            DoiGiaBan form = (DoiGiaBan)Config.CreateForm(Forms.DoiGiaBan);
            form.SetData(row.DONGIA, row.TENHANG);
            if (form.No1Form1.ShowDialog() == DialogResult.OK)
            {
                row.DONGIA = form.numDonGia.Value;
                SafeCalculateRow(row.Row);                
                Track(LoaiLuuVet.DoiGiaBan, "Đổi giá bán '" + row.TENHANG + "', giá: " + row.DONGIA.ToString("n0"), row.SLXUATCHUAQUYDOI, row.DONGIA, row.THANHTIEN, row.TENHANG);
                SaveChiTietDirect(row);
                mapper_OnCalculation(this, EventArgs.Empty);
                SaveDonHangTotals();
            }
		}


		public void tsbNote_Click(object sender, EventArgs e)
		{
            if (DaThanhToan(true)) return;
            if (grDetail.GridView.SelectedRows.Count == 0) return;
            TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(grDetail.GridView.SelectedRow);
            DatGhiChu form = (DatGhiChu)Config.CreateForm(Forms.DatGhiChu);
            form.SetData(row.NOTE);
            if (form.No1Form1.ShowDialog() == DialogResult.OK)
            {
                row.NOTE = form.txtNote.Text;
                SaveChiTietDirect(row);
                mapper_OnCalculation(this, EventArgs.Empty);
                SaveDonHangTotals();
            }
		}


		public void tsbCK_Click(object sender, EventArgs e)
		{
            //if (LaNhanVienChayBan()) return;
            if (DaThanhToan(true)) return;
            if (!DbUtils.CanLogin(Functions.GiamGiaMatHang)) return;
            if (grDetail.GridView.SelectedRows.Count == 0) return;
            
            //if (!ValidRights()) return;
            TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(grDetail.GridView.SelectedRow);
            DatGiamGia form = (DatGiamGia)Config.CreateForm(Forms.DatGiamGia);
            form.SetData(row.DONGIA);
            if (form.No1Form1.ShowDialog() == DialogResult.OK)
            {
                row.TILEGIAMGIA = form.TiLeGiam;
                SafeCalculateRow(row.Row);                   
                Track(LoaiLuuVet.DatGiamGiaMatHang, "Đặt giảm giá '" + row.TENHANG + "', số lượng: " + row.SLXUATCHUAQUYDOI.ToString(), row.SLXUATCHUAQUYDOI, row.DONGIA, row.THANHTIEN, row.TENHANG);
                SaveChiTietDirect(row);
                mapper_OnCalculation(this, EventArgs.Empty);
                SaveDonHangTotals();
            }
		}

		public void btnThongKe_Click(object sender, EventArgs e)
		{
            if (DbUtils.CanView(Functions.ThongKeTrongSuDungDichVu) || DbUtils.CanView(Functions.InLaiBill))
            {
                //if (LaNhanVienChayBan()) return;
                ThucHienInCheBien(true);

                //hiển thị form thống kê các giao dịch đã bán trong ngày
                ThongKe form = (ThongKe)Config.CreateForm(Forms.ThongKe);
                if (form.form.ShowDialog() == DialogResult.OK)
                {
                    Reload(form.SelectedID, "");
                }
            }
            else
            {
                UiUtils.ShowNoRightsToAccess();
            }
		}

        private bool thanhToanShowing = false;
		public void btnThanhToan_Click(object sender, EventArgs e)
		{
            if (DaThanhToan(true)) return;

            string tDonHangID = mapper.ID;
            if (grDetail.RowCount == 0 && numTIENGIO.Value == 0)
            {
                Msg.ShowWarning("Mời bạn thêm mặt hàng vào phiếu");
                return;
            }

            bool needReload = false;
            if (mode == HoaDonMode.SuDungDichVu)
            {
                needReload = SystemConfig.HeThongChayNhieuMayTram == 30;
                if (!needReload || SystemConfig.KichHoatKhuyenMaiTuDong == 30)
                {
                    bool val = KiemTraKhuyenMaiMuaMotTangMot(mapper, dtKETTHUC.DateTime.Date);
                    if (!needReload) needReload = val;
                }                               
            }
            else if (mode == HoaDonMode.QuanLyBanHang)
            {
                //kiểm tra quyền có thể thay đổi không?
                if (!DbUtils.CanEdit(Functions.QuanLyBanHang))
                {
                    return;
                }
            }

            if (needReload)
            {
                Reload(tDonHangID, DBANID);
            }

            if (lueDNHANVIENXUATID.Visible && lueDNHANVIENXUATID.StringValue.Length == 0)
            {
                Msg.ShowWarning("Mời bạn chọn nhân viên trước");
                lueDNHANVIENXUATID.Select();
                lueDNHANVIENXUATID.showDropDown();                
                return;
            }

            //tính tiền tổng phòng
            if (mode == HoaDonMode.SuDungDichVu) UpdateGio();

            if (!IsValid(txtSOORDER.Text, DetailTable != null ? DetailTable.Rows.Count : 0))
            {
                txtSOORDER.Select();
                return;
            }

            decimal daDat = GetDatTruoc(mapper);
            decimal tienTraLai = 0;

            //trường hợp có sử dụng giá khu vực theo giờ và tính giờ theo giờ thanh toán
            if (SystemConfig.SuDungGiaTheoGio == 30 && SystemConfig.CachChonGioTinhGia == (int)CachChonGioTinhGia.GioThanhToan)
            {
                //cập nhật lại giá theo giờ sử dụng
                UpdateGiaTheoGio();
            }

            //kiem tra tong tien de chac chan khong bi sai
            SafeCalculateAllRows();

            DateTime gioThanhToan = Config.Db.DbDateTime;
            DateTime ngayGiaoDich = Shared.GetNgayGiaoDich(Config.Db);
            //chuyển ngày hóa đơn nếu ở trong sử dụng dịch vụ
            if (mode == HoaDonMode.SuDungDichVu)
            {
                if (ngayGiaoDich != dtNGAY.DateTime && Shared.NgayGiaoDich != NgayGiaoDichMode.TheoNgayMoBan)
                {
                    Msg.ShowWarning("Bạn đang thanh toán hóa đơn còn mở từ ngày cũ '" + dtNGAY.DateTime.ToString("dd/MM/yyyy") + "'" + Environment.NewLine +
                                    "Hệ thống sẽ chuyển hóa đơn này sang ngày hiện tại '" + ngayGiaoDich.ToString("dd/MM/yyyy"));
                }
            }

            decimal noCu = 0;
            string DKHACHHANGID = lueDKHACHHANGID.StringValue;
            if (DKHACHHANGID.Length > 0)
            {
                noCu = HoaDonBanHang.GetNoCu(DKHACHHANGID, mapper.ID);
            }            

            ThucHienInCheBien(true);

            KiemTraInMatKhauWifi();

            XacNhanThanhToan form = (XacNhanThanhToan)Config.CreateForm(Forms.XacNhanThanhToan);
            string tenBan = Shared.GetTenPhongBan(false).ToUpper() + ": " + lblBan.Text;
            if (tenBan.Length > 20) tenBan = tenBan.Substring(0, 20);
            form.lblBan.Text = tenBan;
            WriteToCustomerDisplay("THANH TOAN", numTONGCONG.Value.ToString("n0"));            

            form.SetData(mode, TIENPHAITRA.Value, daDat, noCu, lueDKHACHHANGID.StringValue, mapper.ID);
            if (mode == HoaDonMode.SuDungDichVu && SystemConfig.BatBuocInKhiThanhToan == 30)
            {
                form.btnDongBillKhongIn.Enabled = false;
            }
            thanhToanShowing = true;
            DialogResult ret = form.form.ShowDialog();
            thanhToanShowing = false;
            if (ret == DialogResult.OK || ret == DialogResult.Retry)
            {
                if (dtKETTHUC.EditValue == null)
                {
                    //UpdateGio(false);
                    mapper.RaiseOnCalculation();                    
                }
                else if (mapper.ID.Length > 0 && mode == HoaDonMode.SuDungDichVu)
                {
                    TDONHANGRow dhRow = new TDONHANGRow(mapper.ID);
                    if (dhRow.DATHANHTOAN == 30)
                    {
                        Msg.ShowWarning("Hóa đơn này đã thanh toán");
                        return;
                    }
                }

                string GUID = GetDonHangString("NHOMGUID", "");

                string DKHOID = GetKhoHang(DBANID);
                Config.Db.ExecSql("DELETE FROM TDONHANGCHITIET WHERE TDONHANGID = '" + mapper.ID + "' AND XUATVATTU = 30");                

                //xóa vật tư cũ nếu có
                if (mode != HoaDonMode.SuDungDichVu)
                {
                    mapper.Update();
                }

                XuatVatTu(mapper.ID, DKHOID);

                //đóng phòng
                //đóng phòng
                if (GUID.Length > 0)
                {
                    SaveGroupPaymentDirect(GUID, form, gioThanhToan, ngayGiaoDich);
                }
                else
                {
                    TDONHANGRow row = new TDONHANGRow(tDonHangID);                                

                    if (Shared.NgayGiaoDich != NgayGiaoDichMode.TheoNgayMoBan && mode == HoaDonMode.SuDungDichVu)
                        row.NGAY = ngayGiaoDich;

                    row.TRALAI = form.TraLai < 0 ? 0 : form.TraLai;
                    tienTraLai = form.TienThanhToan < 0 ? -form.TienThanhToan : 0;

                    row.TIENTHANHTOAN = Math.Max(form.TienThanhToan, 0);
                    row.CONLAI = Math.Max(0, numTONGCONG.Value - form.TienThanhToan);
                    row.THETRATRUOC = form.TheTraTruoc;
                    row.TRUTICHLUY = form.TruTichLuy;

                    row.PASSWIFI = GetPasswordWifi();

                    if (form.TheTraTruoc > 0) row.DTHETRATRUOCID = form.DTHETRATRUOCID;
                    else row.DTHETRATRUOCID = "";
                    row.DATTRUOC = daDat;
                    row.CONGNO = form.TienNo;
                    row.TIENMAT = form.TraLai < 0 ? form.TraLai : form.TienMat;
                    row.CHUYENKHOAN = form.ChuyenKhoan;
                    row.SOTT = GetSoTT(dtNGAY.DateTime);
                    row.THE = form.TienThe;
                    if (form.TruTichLuy != 0)
                    {
                        decimal quyDoi = SystemConfig.QuyDoi1DiemSangTien;
                        if (quyDoi != 0)
                        {
                            row.DIEMGIAM = form.TruTichLuy / quyDoi;
                        }
                    }
                    row.KHACHDUA = form.KhachDua;
                    row.NOCU = noCu;

                    row.DTAIKHOANNGANHANGID = form.lueDTAIKHOAN.StringValue;
                    row.VOUCHER = form.Voucher;
                    if (form.DVOUCHERID.Length > 0) row.DVOUCHERID = form.DVOUCHERID;
                    else row.DVOUCHERID = "";

                    row.LOAITHANHTOAN = form.LoaiThanhToan;                    
                    decimal diemQuyDoi = Math.Max(SystemConfig.DoanhSoTuongUngVoi1Diem, 1);
                    row.DIEM = (int)(numTONGCONG.Value / diemQuyDoi);

                    //đóng hóa đơn
                    if (mode == HoaDonMode.SuDungDichVu)
                    {
                        row.USERTHANHTOANID = DbConfig.UserID;
                        row.GIOTHANHTOAN = gioThanhToan;
                    }
                    row.DATHANHTOAN = 30;
                    row.CONNO = form.KhachDua < numTONGCONG.Value ? 30 : 0;
                    row.Update();

                    // DIRECT PERSISTENCE TO FIREBIRD DATABASE
                    SavePaymentDirect(tDonHangID, form, mode, numTONGCONG.Value, daDat, noCu, gioThanhToan, ngayGiaoDich);
                }

                //in hóa đơn
                if (ret == DialogResult.OK)
                {
                    PrintInvoice(tDonHangID, false, mode != HoaDonMode.SuDungDichVu);  
                    string billFile = ExportBillToFile(tDonHangID, false);
                    if (!string.IsNullOrEmpty(billFile))
                    {
                        Msg.ShowInfo("Thanh toán thành công!\nHóa đơn đã được lưu và xuất ra file:\n" + billFile);
                    }
                }
                else if (ret == DialogResult.Retry)
                {
                    Msg.ShowInfo("Đã thanh toán và đóng hóa đơn thành công!");
                }
                Track(LoaiLuuVet.DongBan, "Đóng hóa đơn (" + (ret == DialogResult.OK ? "Có in" : "Không in") + "), số phiếu:" + txtNAME.Text + ", ngày: " + dtNGAY.DateTime.ToString("dd/MM/yyyy"), 0, 0, TIENPHAITRA.Value, "");

                //tạo phiếu trả lại khách nếu là đặt hàng
                if (tienTraLai > 0)
                {
                    TraLaiKhach(tienTraLai);
                }

                if (mode == HoaDonMode.SuDungDichVu)
                {
                    if (lueDKHACHHANGID.StringValue.Length > 0 && SystemConfig.TuDongNangCapThanhVienKhiDatHanMuc == 30)
                    {
                        //tính lại doanh số và tăng thành viên nếu có
                        decimal diemTichLuy = 0;
                        string sql = @"SELECT COALESCE(DIEMTICHLUYBANDAU,0) + 
(SELECT COALESCE(CASE WHEN @CACHTINH = 1 THEN SUM(DIEM) ELSE SUM(TONGCONG) / CAST(@DIEM AS DECIMAL(18, 2)) END, 0) FROM TDONHANG WHERE DATHANHTOAN = 30 AND LOAI = 0 AND DKHACHHANGID=DKHACHHANG.ID) + 
(SELECT COALESCE(SUM(DIEMTANG-DIEMGIAM),0) FROM TTANGGIAMDIEM WHERE DKHACHHANGID = DKHACHHANG.ID) FROM DKHACHHANG WHERE ID = '" + lueDKHACHHANGID.StringValue + "'";
                        FbCommand cmd = Config.Db.GetCommand(sql);
                        cmd.Parameters.Add("@CACHTINH", FbDbType.Integer).Value = SystemConfig.CachTinhDiem;
                        cmd.Parameters.Add("@DIEM", FbDbType.Integer).Value = Math.Max(SystemConfig.DoanhSoTuongUngVoi1Diem, 1);

                        diemTichLuy = Config.Db.GetFirstFieldDec(cmd);
                        cmd = Config.Db.GetCommand("SELECT * FROM DNHOMKHACHHANG WHERE DIEMTICHLUY <= @DIEMTICHLUY AND DIEMTICHLUY > 0 ORDER BY DIEMTICHLUY DESC");
                        cmd.Parameters.Add("@DIEMTICHLUY", FbDbType.Decimal).Value = diemTichLuy;
                        DataRow rNhom = Config.Db.GetFirstRow(cmd);
                        if (rNhom != null)
                        {
                            DNHOMKHACHHANGRow nhomRow = new DNHOMKHACHHANGRow(rNhom);
                            DKHACHHANGRow khRow = new DKHACHHANGRow(lueDKHACHHANGID.StringValue);
                            if (nhomRow.ID != khRow.DNHOMKHACHHANGID)
                            {
                                DKHACHHANGRow upRow = new DKHACHHANGRow(lueDKHACHHANGID.StringValue);
                                upRow.DNHOMKHACHHANGID = nhomRow.ID;
                                upRow.Update();
                                Msg.ShowInfo("Khách hàng đã được chuyển sang nhóm '" + nhomRow.NAME + "' vì đạt tới số điểm '" + nhomRow.DIEMTICHLUY.ToString("N0") + "'");
                            }
                        }
                    }

                    Config.SetLastUpdate(Tables.TDONHANG);

                    // Clear table link in DBAN
                    if (!string.IsNullOrEmpty(DBANID))
                    {
                        Config.Db.ExecSql(string.Format("UPDATE DBAN SET TDONHANGID = NULL WHERE ID = '{0}'", DBANID));
                    }

                    //tạo mới phòng
                    Reload("", DBANID);
                    //refresh lại phòng
                    RefreshTrangThaiBan();

                    //Tắt thiết bị đèn nếu có sử dụng
                    if (mode == HoaDonMode.SuDungDichVu) Shared.TatDen(DBANID);

                    //Xóa chi tiết in chế biến
                    Config.Db.ExecSql("DELETE FROM TINCHEBIEN WHERE TDONHANGID='" + mapper.ID + "'");
                }
                else
                {
                    CapNhatLuuVet();
                    if (ret != DialogResult.OK) Msg.ShowInfo("Đã cập nhật hóa đơn thành công");
                }

                if (OnAfterThanhToan != null) OnAfterThanhToan(this, EventArgs.Empty);
            }            
            //in thử
            else if (ret == DialogResult.Ignore)
            {
                Track(LoaiLuuVet.InBill, "In tạm tính, bill " + txtNAME.Text + ", ngày: " + dtNGAY.DateTime.ToString("dd/MM/yyyy") + ", Tổng tiền: " + TIENPHAITRA.Value.ToString("n0"), 0, 0, TIENPHAITRA.Value, "");
                PrintInvoice(tDonHangID, true, false);
                string tamTinhFile = ExportBillToFile(tDonHangID, true);
                if (!string.IsNullOrEmpty(tamTinhFile))
                {
                    Msg.ShowInfo("Đã xuất phiếu tạm tính ra file:\n" + tamTinhFile);
                }
                RefreshTrangThaiBan();
            }
		}

        private static void SavePaymentDirect(string tDonHangID, XacNhanThanhToan form, HoaDonMode mode, decimal tongCong, decimal daDat, decimal noCu, DateTime gioThanhToan, DateTime ngayGiaoDich)
        {
            try
            {
                decimal tienThanhToan = Math.Max(form.TienThanhToan, 0);
                decimal conLai = Math.Max(0, tongCong - form.TienThanhToan);
                decimal tienTraLai = form.TraLai < 0 ? 0 : form.TraLai;
                decimal tienMat = form.TraLai < 0 ? form.TraLai : form.TienMat;
                decimal diemQuyDoi = Math.Max(SystemConfig.DoanhSoTuongUngVoi1Diem, 1);
                int diem = (int)(tongCong / diemQuyDoi);
                decimal diemGiam = 0;
                if (form.TruTichLuy != 0)
                {
                    decimal quyDoi = SystemConfig.QuyDoi1DiemSangTien;
                    if (quyDoi != 0) diemGiam = form.TruTichLuy / quyDoi;
                }
                string passWifi = GetPasswordWifi();
                string dTheTraTruocID = form.TheTraTruoc > 0 ? form.DTHETRATRUOCID : "";
                string dVoucherID = form.DVOUCHERID.Length > 0 ? form.DVOUCHERID : "";
                string userId = !string.IsNullOrEmpty(DbConfig.UserID) ? DbConfig.UserID : (!string.IsNullOrEmpty(DbConfig.UserName) ? DbConfig.UserName : "admin");
                int conno = form.KhachDua < tongCong ? 30 : 0;
                int sott = GetSoTT(ngayGiaoDich);

                string sql = @"UPDATE TDONHANG SET 
                    DATHANHTOAN = 30,
                    STATUS = 30,
                    TIENTHANHTOAN = @TIENTHANHTOAN,
                    CONLAI = @CONLAI,
                    THETRATRUOC = @THETRATRUOC,
                    TRUTICHLUY = @TRUTICHLUY,
                    PASSWIFI = @PASSWIFI,
                    DTHETRATRUOCID = @DTHETRATRUOCID,
                    DATTRUOC = @DATTRUOC,
                    CONGNO = @CONGNO,
                    TIENMAT = @TIENMAT,
                    CHUYENKHOAN = @CHUYENKHOAN,
                    SOTT = @SOTT,
                    THE = @THE,
                    DIEMGIAM = @DIEMGIAM,
                    KHACHDUA = @KHACHDUA,
                    TRALAI = @TRALAI,
                    NOCU = @NOCU,
                    DTAIKHOANNGANHANGID = @DTAIKHOANNGANHANGID,
                    VOUCHER = @VOUCHER,
                    DVOUCHERID = @DVOUCHERID,
                    LOAITHANHTOAN = @LOAITHANHTOAN,
                    DIEM = @DIEM,
                    USERTHANHTOANID = @USERTHANHTOANID,
                    GIOTHANHTOAN = @GIOTHANHTOAN,
                    CONNO = @CONNO" +
                    ((Shared.NgayGiaoDich != NgayGiaoDichMode.TheoNgayMoBan && mode == HoaDonMode.SuDungDichVu) ? ", NGAY = @NGAY" : "") +
                    " WHERE ID = @ID";

                FbCommand cmd = Config.Db.GetCommand(sql);
                cmd.Parameters.Add("@TIENTHANHTOAN", FbDbType.Decimal).Value = tienThanhToan;
                cmd.Parameters.Add("@CONLAI", FbDbType.Decimal).Value = conLai;
                cmd.Parameters.Add("@THETRATRUOC", FbDbType.Decimal).Value = form.TheTraTruoc;
                cmd.Parameters.Add("@TRUTICHLUY", FbDbType.Decimal).Value = form.TruTichLuy;
                cmd.Parameters.Add("@PASSWIFI", FbDbType.VarChar).Value = passWifi ?? "";
                cmd.Parameters.Add("@DTHETRATRUOCID", FbDbType.VarChar).Value = dTheTraTruocID ?? "";
                cmd.Parameters.Add("@DATTRUOC", FbDbType.Decimal).Value = daDat;
                cmd.Parameters.Add("@CONGNO", FbDbType.Decimal).Value = form.TienNo;
                cmd.Parameters.Add("@TIENMAT", FbDbType.Decimal).Value = tienMat;
                cmd.Parameters.Add("@CHUYENKHOAN", FbDbType.Decimal).Value = form.ChuyenKhoan;
                cmd.Parameters.Add("@SOTT", FbDbType.Integer).Value = sott;
                cmd.Parameters.Add("@THE", FbDbType.Decimal).Value = form.TienThe;
                cmd.Parameters.Add("@DIEMGIAM", FbDbType.Decimal).Value = diemGiam;
                cmd.Parameters.Add("@KHACHDUA", FbDbType.Decimal).Value = form.KhachDua;
                cmd.Parameters.Add("@TRALAI", FbDbType.Decimal).Value = tienTraLai;
                cmd.Parameters.Add("@NOCU", FbDbType.Decimal).Value = noCu;
                cmd.Parameters.Add("@DTAIKHOANNGANHANGID", FbDbType.VarChar).Value = form.lueDTAIKHOAN?.StringValue ?? "";
                cmd.Parameters.Add("@VOUCHER", FbDbType.Decimal).Value = form.Voucher;
                cmd.Parameters.Add("@DVOUCHERID", FbDbType.VarChar).Value = dVoucherID ?? "";
                cmd.Parameters.Add("@LOAITHANHTOAN", FbDbType.Integer).Value = form.LoaiThanhToan;
                cmd.Parameters.Add("@DIEM", FbDbType.Decimal).Value = diem;
                cmd.Parameters.Add("@USERTHANHTOANID", FbDbType.VarChar).Value = userId;
                cmd.Parameters.Add("@GIOTHANHTOAN", FbDbType.TimeStamp).Value = gioThanhToan;
                cmd.Parameters.Add("@CONNO", FbDbType.Integer).Value = conno;
                if (Shared.NgayGiaoDich != NgayGiaoDichMode.TheoNgayMoBan && mode == HoaDonMode.SuDungDichVu)
                {
                    cmd.Parameters.Add("@NGAY", FbDbType.Date).Value = ngayGiaoDich;
                }
                cmd.Parameters.Add("@ID", FbDbType.VarChar).Value = tDonHangID;

                Config.Db.ExecSql(cmd);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SavePaymentDirect error: " + ex.Message);
            }
        }

        private static void SaveGroupPaymentDirect(string guid, XacNhanThanhToan form, DateTime gioThanhToan, DateTime ngayGiaoDich)
        {
            try
            {
                DataTable dtNhom = Config.Db.GetTable("SELECT ID, TONGCONG, TDATHANGID, (SELECT SOTIEN FROM TTHUCHI WHERE TTHUCHI.TDATHANGID = TDONHANG.TDATHANGID) AS DATTRUOC FROM TDONHANG WHERE NHOMGUID = '" + guid + "'");
                decimal tienThanhToan = form.TienThanhToan;
                string userId = !string.IsNullOrEmpty(DbConfig.UserID) ? DbConfig.UserID : (!string.IsNullOrEmpty(DbConfig.UserName) ? DbConfig.UserName : "admin");

                foreach (DataRow r in dtNhom.Rows)
                {
                    string id = r["ID"].ToString();
                    decimal tongCong = ConvertTo.Decimal(r["TONGCONG"]);
                    decimal datTruoc = ConvertTo.Decimal(r["DATTRUOC"]);
                    tienThanhToan += datTruoc;
                    decimal tienDonHang = Math.Min(tienThanhToan, Math.Max(0, tongCong - datTruoc));
                    tienThanhToan -= tongCong;

                    string sql = @"UPDATE TDONHANG SET 
                        DATHANHTOAN = 30,
                        STATUS = 30,
                        USERTHANHTOANID = @USERID,
                        NHOMGUID = @NHOMGUID,
                        GIOTHANHTOAN = @GIOTHANHTOAN,
                        NGAY = @NGAY,
                        LOAITHANHTOAN = @LOAI,
                        TRALAI = @TRALAI,
                        KHACHDUA = @KHACHDUA,
                        TIENTHANHTOAN = @TIENTHANHTOAN
                        WHERE ID = @ID";

                    FbCommand cmd = Config.Db.GetCommand(sql);
                    cmd.Parameters.Add("@USERID", FbDbType.VarChar).Value = userId;
                    cmd.Parameters.Add("@NHOMGUID", FbDbType.VarChar).Value = guid;
                    cmd.Parameters.Add("@GIOTHANHTOAN", FbDbType.TimeStamp).Value = gioThanhToan;
                    cmd.Parameters.Add("@NGAY", FbDbType.Date).Value = ngayGiaoDich;
                    cmd.Parameters.Add("@LOAI", FbDbType.Integer).Value = form.LoaiThanhToan;
                    cmd.Parameters.Add("@TRALAI", FbDbType.Decimal).Value = form.TraLai;
                    cmd.Parameters.Add("@KHACHDUA", FbDbType.Decimal).Value = form.KhachDua;
                    cmd.Parameters.Add("@TIENTHANHTOAN", FbDbType.Decimal).Value = tienDonHang;
                    cmd.Parameters.Add("@ID", FbDbType.VarChar).Value = id;

                    Config.Db.ExecSql(cmd);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SaveGroupPaymentDirect error: " + ex.Message);
            }
        }

        public static string ExportBillToFile(string tDonHangID, bool isTamTinh)
        {
            try
            {
                if (string.IsNullOrEmpty(tDonHangID)) return null;

                DataRow rDonHang = Config.Db.GetFirstRow(string.Format(@"
                    SELECT DH.*, 
                           B.NAME AS TENBAN, 
                           KV.NAME AS TENKHUVUC,
                           KH.NAME AS TENKHACHHANG, KH.DIENTHOAI AS DIENTHOAIKH, KH.DIACHI AS DIACHIKH
                    FROM TDONHANG DH
                    LEFT JOIN DBAN B ON DH.DBANID = B.ID
                    LEFT JOIN DKHUVUC KV ON B.DKHUVUCID = KV.ID
                    LEFT JOIN DKHACHHANG KH ON DH.DKHACHHANGID = KH.ID
                    WHERE DH.ID = '{0}'", tDonHangID));

                if (rDonHang == null) return null;

                DataRow rStore = Config.Db.GetFirstRow("SELECT FIRST 1 * FROM DCUAHANG");
                string tenCuaHang = rStore != null && rStore.Table.Columns.Contains("NAME") ? rStore["NAME"].ToString() : "NHÀ HÀNG";
                string diaChiCuaHang = rStore != null && rStore.Table.Columns.Contains("DIACHI") ? rStore["DIACHI"].ToString() : "";
                string sdtCuaHang = rStore != null && rStore.Table.Columns.Contains("DIENTHOAI") ? rStore["DIENTHOAI"].ToString() : "";

                DataTable dtItems = Config.Db.GetTable(string.Format(@"
                    SELECT CT.*, COALESCE(CT.TENHANG, MH.NAME) AS TENHANG_DISPLAY, DVT.NAME AS DVT
                    FROM TDONHANGCHITIET CT
                    LEFT JOIN DMATHANG MH ON CT.DMATHANGID = MH.ID
                    LEFT JOIN DDONVITINH DVT ON CT.DDONVITINHID = DVT.ID
                    WHERE CT.TDONHANGID = '{0}' AND COALESCE(CT.XUATVATTU, 0) = 0
                    ORDER BY CT.TIMECREATED", tDonHangID));

                string soHD = rDonHang["NAME"]?.ToString() ?? "0000000";
                string tenBan = rDonHang["TENBAN"]?.ToString() ?? "";
                string tenKhuVuc = rDonHang["TENKHUVUC"]?.ToString() ?? "";
                string thuNgan = rDonHang["USERTHANHTOANID"]?.ToString() ?? DbConfig.UserName ?? "admin";
                DateTime batDau = ConvertTo.Date(rDonHang["BATDAU"]);
                DateTime gioThanhToan = ConvertTo.Date(rDonHang["GIOTHANHTOAN"]);
                if (gioThanhToan == DateTime.MinValue) gioThanhToan = DateTime.Now;

                decimal tongTien = ConvertTo.Decimal(rDonHang["TONGCONG"]);
                decimal tienHang = ConvertTo.Decimal(rDonHang["TIENHANG"]);
                decimal tienGiamGia = ConvertTo.Decimal(rDonHang["TIENGIAMGIA"]) + ConvertTo.Decimal(rDonHang["TIENGIAMGIATONG"]);
                decimal tienThue = ConvertTo.Decimal(rDonHang["TIENTHUE"]);
                decimal phiDichVu = ConvertTo.Decimal(rDonHang["PHIDICHVU"]);
                decimal tienGio = ConvertTo.Decimal(rDonHang["TIENGIO"]);
                decimal khachDua = ConvertTo.Decimal(rDonHang["KHACHDUA"]);
                decimal traLai = ConvertTo.Decimal(rDonHang["TRALAI"]);
                decimal tienMat = ConvertTo.Decimal(rDonHang["TIENMAT"]);
                decimal chuyenKhoan = ConvertTo.Decimal(rDonHang["CHUYENKHOAN"]);
                decimal the = ConvertTo.Decimal(rDonHang["THE"]);
                string passWifi = rDonHang["PASSWIFI"]?.ToString() ?? "";

                string title = isTamTinh ? "PHIẾU TẠM TÍNH" : "HÓA ĐƠN THANH TOÁN";

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string outDir = Path.Combine(baseDir, "HoaDon");
                if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

                string safeName = soHD.Replace("/", "_").Replace("\\", "_");
                string fileName = string.Format("{0}_{1}_{2:yyyyMMdd_HHmmss}.html", isTamTinh ? "PhieuTamTinh" : "HoaDon", safeName, DateTime.Now);
                string filePath = Path.Combine(outDir, fileName);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<!DOCTYPE html>");
                sb.AppendLine("<html lang='vi'>");
                sb.AppendLine("<head>");
                sb.AppendLine("<meta charset='utf-8'>");
                sb.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
                sb.AppendLine(string.Format("<title>{0} - {1}</title>", title, soHD));
                sb.AppendLine("<style>");
                sb.AppendLine("@page { size: auto; margin: 5mm; }");
                sb.AppendLine("body { font-family: 'Segoe UI', Tahoma, Arial, sans-serif; background-color: #f0f2f5; margin: 0; padding: 20px; color: #111; }");
                sb.AppendLine(".receipt-card { max-width: 380px; margin: 0 auto; background: #fff; padding: 24px; border-radius: 8px; box-shadow: 0 4px 15px rgba(0,0,0,0.1); border: 1px solid #e0e0e0; }");
                sb.AppendLine(".no-print { display: flex; justify-content: space-between; margin-bottom: 15px; }");
                sb.AppendLine(".btn { padding: 8px 16px; border: none; border-radius: 4px; font-weight: bold; cursor: pointer; font-size: 14px; }");
                sb.AppendLine(".btn-print { background: #007bff; color: #fff; }");
                sb.AppendLine(".btn-close { background: #6c757d; color: #fff; }");
                sb.AppendLine(".btn:hover { opacity: 0.9; }");
                sb.AppendLine(".store-name { text-align: center; font-size: 20px; font-weight: bold; text-transform: uppercase; margin-bottom: 4px; }");
                sb.AppendLine(".store-info { text-align: center; font-size: 13px; color: #555; margin-bottom: 2px; }");
                sb.AppendLine(".divider { border-top: 1px dashed #777; margin: 12px 0; }");
                sb.AppendLine(".divider-double { border-top: 2px solid #333; margin: 12px 0; }");
                sb.AppendLine(".bill-title { text-align: center; font-size: 18px; font-weight: bold; text-transform: uppercase; margin: 10px 0; letter-spacing: 1px; color: #111; }");
                sb.AppendLine(".info-grid { font-size: 13px; line-height: 1.6; }");
                sb.AppendLine(".info-row { display: flex; justify-content: space-between; }");
                sb.AppendLine(".item-table { width: 100%; border-collapse: collapse; font-size: 13px; margin: 10px 0; }");
                sb.AppendLine(".item-table th { border-bottom: 1px solid #333; padding: 6px 2px; text-align: left; }");
                sb.AppendLine(".item-table td { padding: 6px 2px; vertical-align: top; }");
                sb.AppendLine(".text-right { text-align: right; }");
                sb.AppendLine(".text-center { text-align: center; }");
                sb.AppendLine(".summary-row { display: flex; justify-content: space-between; font-size: 13px; margin: 4px 0; }");
                sb.AppendLine(".total-row { display: flex; justify-content: space-between; font-size: 17px; font-weight: bold; margin: 8px 0; color: #d9230f; }");
                sb.AppendLine(".footer-text { text-align: center; font-size: 12px; color: #666; margin-top: 15px; font-style: italic; }");
                sb.AppendLine("@media print {");
                sb.AppendLine("  body { background: #fff; padding: 0; }");
                sb.AppendLine("  .receipt-card { box-shadow: none; border: none; max-width: 100%; padding: 5px; }");
                sb.AppendLine("  .no-print { display: none !important; }");
                sb.AppendLine("}");
                sb.AppendLine("</style>");
                sb.AppendLine("</head>");
                sb.AppendLine("<body>");
                sb.AppendLine("<div class='receipt-card'>");
                sb.AppendLine("<div class='no-print'>");
                sb.AppendLine("  <button class='btn btn-print' onclick='window.print();'>🖨️ In Hóa Đơn</button>");
                sb.AppendLine("  <button class='btn btn-close' onclick='window.close();'>Đóng</button>");
                sb.AppendLine("</div>");

                sb.AppendLine(string.Format("<div class='store-name'>{0}</div>", WebUtility.HtmlEncode(tenCuaHang)));
                if (!string.IsNullOrEmpty(diaChiCuaHang))
                    sb.AppendLine(string.Format("<div class='store-info'>{0}</div>", WebUtility.HtmlEncode(diaChiCuaHang)));
                if (!string.IsNullOrEmpty(sdtCuaHang))
                    sb.AppendLine(string.Format("<div class='store-info'>Điện thoại: {0}</div>", WebUtility.HtmlEncode(sdtCuaHang)));

                sb.AppendLine("<div class='divider'></div>");
                sb.AppendLine(string.Format("<div class='bill-title'>{0}</div>", title));

                sb.AppendLine("<div class='info-grid'>");
                sb.AppendLine(string.Format("<div class='info-row'><span>Số HĐ: <b>{0}</b></span><span>Bàn: <b>{1}</b></span></div>", soHD, WebUtility.HtmlEncode(string.IsNullOrEmpty(tenBan) ? "Mang về" : (tenBan + (string.IsNullOrEmpty(tenKhuVuc) ? "" : " - " + tenKhuVuc)))));
                sb.AppendLine(string.Format("<div class='info-row'><span>Thu ngân: {0}</span><span>Ngày: {1:dd/MM/yyyy}</span></div>", thuNgan, gioThanhToan));
                sb.AppendLine(string.Format("<div class='info-row'><span>Giờ vào: {0:HH:mm}</span><span>Giờ ra: {1:HH:mm}</span></div>", batDau, gioThanhToan));
                sb.AppendLine("</div>");

                sb.AppendLine("<div class='divider'></div>");
                sb.AppendLine("<table class='item-table'>");
                sb.AppendLine("<thead><tr>");
                sb.AppendLine("<th style='width:45%;'>Món</th>");
                sb.AppendLine("<th class='text-center' style='width:15%;'>SL</th>");
                sb.AppendLine("<th class='text-right' style='width:20%;'>Đ.Giá</th>");
                sb.AppendLine("<th class='text-right' style='width:20%;'>T.Tiền</th>");
                sb.AppendLine("</tr></thead>");
                sb.AppendLine("<tbody>");

                int idx = 1;
                foreach (DataRow item in dtItems.Rows)
                {
                    string tenMon = (item.Table.Columns.Contains("TENHANG_DISPLAY") ? item["TENHANG_DISPLAY"]?.ToString() : null) ?? item["TENHANG"]?.ToString() ?? "";
                    decimal sl = ConvertTo.Decimal(item["SLXUAT"]);
                    decimal donGia = ConvertTo.Decimal(item["DONGIA"]);
                    decimal thanhTien = ConvertTo.Decimal(item["THANHTIEN"]);

                    sb.AppendLine("<tr>");
                    sb.AppendLine(string.Format("<td>{0}. {1}</td>", idx++, WebUtility.HtmlEncode(tenMon)));
                    sb.AppendLine(string.Format("<td class='text-center'>{0:0.##}</td>", sl));
                    sb.AppendLine(string.Format("<td class='text-right'>{0:N0}</td>", donGia));
                    sb.AppendLine(string.Format("<td class='text-right'><b>{0:N0}</b></td>", thanhTien));
                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");

                sb.AppendLine("<div class='divider'></div>");
                sb.AppendLine(string.Format("<div class='summary-row'><span>Tiền hàng:</span><span>{0:N0} đ</span></div>", tienHang));

                if (tienGio > 0)
                    sb.AppendLine(string.Format("<div class='summary-row'><span>Tiền giờ:</span><span>{0:N0} đ</span></div>", tienGio));

                if (tienGiamGia > 0)
                    sb.AppendLine(string.Format("<div class='summary-row'><span>Giảm giá:</span><span>-{0:N0} đ</span></div>", tienGiamGia));

                if (phiDichVu > 0)
                    sb.AppendLine(string.Format("<div class='summary-row'><span>Phí dịch vụ:</span><span>{0:N0} đ</span></div>", phiDichVu));

                if (tienThue > 0)
                    sb.AppendLine(string.Format("<div class='summary-row'><span>Thuế VAT:</span><span>{0:N0} đ</span></div>", tienThue));

                sb.AppendLine("<div class='divider-double'></div>");
                sb.AppendLine(string.Format("<div class='total-row'><span>TỔNG CỘNG:</span><span>{0:N0} đ</span></div>", tongTien));

                if (!isTamTinh)
                {
                    if (khachDua > 0)
                        sb.AppendLine(string.Format("<div class='summary-row'><span>Tiền khách đưa:</span><span>{0:N0} đ</span></div>", khachDua));
                    if (traLai > 0)
                        sb.AppendLine(string.Format("<div class='summary-row'><span>Tiền trả lại:</span><span>{0:N0} đ</span></div>", traLai));

                    string hinhThuc = "";
                    if (tienMat > 0) hinhThuc += "Tiền mặt ";
                    if (chuyenKhoan > 0) hinhThuc += "Chuyển khoản ";
                    if (the > 0) hinhThuc += "Thẻ ATM ";
                    if (string.IsNullOrEmpty(hinhThuc)) hinhThuc = "Tiền mặt";
                    sb.AppendLine(string.Format("<div class='summary-row'><span>Hình thức TT:</span><span>{0}</span></div>", hinhThuc.Trim()));
                }

                if (!string.IsNullOrEmpty(passWifi))
                {
                    sb.AppendLine("<div class='divider'></div>");
                    sb.AppendLine(string.Format("<div class='text-center' style='font-size:12px;'>Mật khẩu Wifi: <b>{0}</b></div>", WebUtility.HtmlEncode(passWifi)));
                }

                sb.AppendLine("<div class='footer-text'>");
                sb.AppendLine("<div>Cảm ơn Quý Khách - Hẹn Gặp Lại!</div>");
                sb.AppendLine("<div style='font-size:10px; margin-top:4px;'>Phần mềm Quản Lý Nhà Hàng</div>");
                sb.AppendLine("</div>");

                sb.AppendLine("</div>");
                sb.AppendLine("</body>");
                sb.AppendLine("</html>");

                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);

                // Also copy to D:\QuanLyNhaHang\HoaDon if folder exists or can be created
                try
                {
                    string workspaceDir = @"D:\QuanLyNhaHang\HoaDon";
                    if (!Directory.Exists(workspaceDir)) Directory.CreateDirectory(workspaceDir);
                    string wsFilePath = Path.Combine(workspaceDir, fileName);
                    File.Copy(filePath, wsFilePath, true);
                }
                catch { }

                // Auto launch bill file in default browser
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
                }
                catch { }

                return filePath;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ExportBillToFile error: " + ex.Message);
                return null;
            }
        }

        public static string GetPasswordWifi()
        {
            if (SystemConfig.InMatKhauWifiTrenBill == 30)
            {
                string sql = "SELECT FIRST 1 ID, NAME FROM DMATKHAUWIFI";
                DataRow row = Config.Db.GetFirstRow(sql);
                if (row != null)
                {
                    string ID = row["ID"].ToString();
                    Config.Db.ExecSql("DELETE FROM DMATKHAUWIFI WHERE ID = '" + ID + "'");
                    return row["NAME"].ToString();
                }
            }
            return "";
        }

        public static void KiemTraInMatKhauWifi()
        {
            if (SystemConfig.InMatKhauWifiTrenBill == 30)
            {
                string sql = "SELECT COUNT(*) FROM DMATKHAUWIFI WHERE STATUS = 30";
                int dem = Config.Db.GetFirstFieldInt(sql);
                if (dem <= 0)
                {
                    Msg.ShowWarning("Không còn password wifi nào có thể sử dụng. Vui lòng bổ sung");
                }
            }
        }

        /// <summary>
        /// Tính toán lượng vật tư của mặt hàng được chọn và đẩy về danh sách
        /// </summary>
        /// <param name="r"></param>
        /// <param name="dtVatTu"></param>
        private static void InsertVatTu(DataRow[] rows, DataTable dtVatTu)
        {
            if (rows.Length == 0) return;

            FbCommand cmd = Config.Db.GetCommand("");
            string caseWhen = "";
            string where = "";
            int i = 0;
            foreach (DataRow r in rows)
            {
                string DMATHANGID = "@p" + i.ToString();
                string SoLuong = "@q" + i.ToString();

                if (where.Length > 0) where += " OR ";
                where += "DMATHANGID = " + DMATHANGID;

                caseWhen += " WHEN DMATHANGID = " + DMATHANGID + " THEN " + SoLuong;

                cmd.Parameters.Add(DMATHANGID, FbDbType.VarChar).Value = r["DVATTUID"].ToString();
                cmd.Parameters.Add(SoLuong, FbDbType.Decimal).Value = ConvertTo.Decimal(r["SOLUONG"]);

                i++;
            }

            string sql = @"SELECT DVATTUID, GIAVON, DLOAIMATHANGID, DDONVITINHID, NAME AS TENHANG, 
SUM(SOLUONG * CASE {0} ELSE 0 END) AS SOLUONG
FROM DDINHLUONG INNER JOIN DMATHANG ON DDINHLUONG.DVATTUID = DMATHANG.ID
WHERE {1}
GROUP BY DVATTUID, GIAVON, DLOAIMATHANGID, DDONVITINHID, NAME";
            sql = string.Format(sql, caseWhen, where);
            cmd.CommandText = sql;
            DataTable dt = Config.Db.GetTable(cmd);
            foreach (DataRow r in dt.Rows)
            {
                //kiểm tra xem đã có trong danh sách cũ chưa?
                DataRow[] rCheck = dtVatTu.Select("DVATTUID='" + r["DVATTUID"].ToString() + "'");
                if (rCheck.Length == 0)
                {
                    dtVatTu.ImportRow(r);
                }
                else
                {
                    DataRow oldRow = rCheck[0];
                    oldRow["SOLUONG"] = ConvertTo.Decimal(oldRow["SOLUONG"]) + ConvertTo.Decimal(r["SOLUONG"]);
                }
            }
        }

        public static bool KiemTraKhuyenMaiMuaMotTangMot(No1FieldMapper mapper, DateTime ketThuc)
        {
            //kiểm tra xem có khuyến mại mua 1 tặng một nào không?
            string sql = @"SELECT COUNT(*) FROM DDOTKHUYENMAI WHERE COALESCE(NGUNGAPDUNG, 0) = 0 AND STATUS = 30 AND DLOAIHINHKHUYENMAIID = '{0}'
AND (@TUNGAY BETWEEN TUNGAY AND DENNGAY OR @DENNGAY BETWEEN TUNGAY AND DENNGAY)";
            FbCommand cmd = Config.Db.GetCommand(string.Format(sql, LOAIHINHKHUYENMAI.MUA1TANG1));
            DateTime dtBatDau = (mapper != null && mapper[TDONHANGInfo.BATDAU] != null && mapper[TDONHANGInfo.BATDAU].Value != null) ? mapper[TDONHANGInfo.BATDAU].ToDateTime().Date : DateTime.Today;
            cmd.Parameters.Add("@TUNGAY", dtBatDau);
            cmd.Parameters.Add("@DENNGAY", ketThuc);
            int cnt = Config.Db.GetFirstFieldInt(cmd);
            if (cnt > 0)
            {                
                //xóa các mặt hàng tự động
                sql = string.Format("DELETE FROM TDONHANGCHITIET WHERE DMATHANGID = 'KM' AND TDONHANGID = '{0}'", mapper.ID);
                Config.Db.ExecSql(sql);

                sql = string.Format(@"SELECT TIMECREATED, DMATHANGID, SLXUATCHUAQUYDOI FROM TDONHANGCHITIET WHERE TDONHANGID = '{0}'", mapper.ID);
                DataTable dtHoaDon = Config.Db.GetTable(sql);

                //tính toán các mặt hàng khuyến mại mua 1 tặng cùng mặt hàng
                sql = string.Format(@"SELECT TENHANG, DDOTKHUYENMAI.DENGIO, DONGIA, TDONHANGCHITIET.DMATHANGID, DDONVITINHID, TDONHANGCHITIET.TILEGIAMGIA, 
SUM(SLXUATCHUAQUYDOI) AS SLXUATCHUAQUYDOI, SOLUONGMUA, SOLUONGTANG FROM TDONHANGCHITIET
INNER JOIN DDOTKHUYENMAICHITIET ON TDONHANGCHITIET.DMATHANGID = DDOTKHUYENMAICHITIET.DMATHANGID
AND TDONHANGCHITIET.DMATHANGID <> 'KM' AND TDONHANGID = '{0}'
INNER JOIN DDOTKHUYENMAI ON DDOTKHUYENMAICHITIET.DDOTKHUYENMAIID = DDOTKHUYENMAI.ID
AND DLOAIHINHKHUYENMAIID = 'e5d39bb6-41a4-43ff-bc4d-e170ae4aeba2'
AND CAST(TDONHANGCHITIET.TIMECREATED AS DATE) BETWEEN TUNGAY AND DENNGAY
AND (CAST(TDONHANGCHITIET.TIMECREATED AS TIME) BETWEEN CAST(DDOTKHUYENMAI.TUGIO AS TIME) AND CAST(DDOTKHUYENMAI.DENGIO AS TIME))
AND DDOTKHUYENMAICHITIET.DMATHANGID = DMATHANGTANGID
GROUP BY TENHANG, DONGIA, DDONVITINHID, DDOTKHUYENMAI.DENGIO, TDONHANGCHITIET.DMATHANGID, TDONHANGCHITIET.TILEGIAMGIA, SOLUONGMUA, SOLUONGTANG", mapper.ID);

                //thêm vào hóa đơn
                DataTable dt = Config.Db.GetTable(sql);
                foreach (DataRow r in dt.Rows)
                {
                    TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(r);

                    DateTime denGio = ConvertTo.Date(r["DENGIO"]);

                    //lấy ra số lượng đã bán trong khoảng thời gian
                    decimal SoLuong = ctRow.SLXUATCHUAQUYDOI;

                    //trừ đi số lượng trả lại sau khoảng thời gian
                    SoLuong += GetSoLuongTra(ctRow.DMATHANGID, dtHoaDon, denGio);

                    //tính toán xem có được tặng không?                    
                    decimal SoLuongMua = ConvertTo.Decimal(r["SOLUONGMUA"]);
                    decimal SoLuongTang = ConvertTo.Decimal(r["SOLUONGTANG"]);

                    int slTang = (int)(SoLuongTang * (int)(SoLuong / (SoLuongMua + SoLuongTang)));
                    //trường hợp đặc biệt 
                    //mua 3 tặng 2, mua 4 được tặng 1
                    //              mua 14 tặng 5
                    int tiLe = (int)((SoLuong - slTang) / SoLuongMua);
                    int slTangKhaDung = (int)(SoLuong - tiLe * SoLuongMua);
                    if (slTangKhaDung < tiLe * SoLuongTang)
                    {
                        slTang = slTangKhaDung;
                    }

                    if (slTang <= 0) continue;
                    //trừ số lượng
                    TDONHANGCHITIETRow upRow = new TDONHANGCHITIETRow();
                    upRow.DDONVITINHID = ctRow.DDONVITINHID;
                    upRow.DMATHANGID = "KM";
                    upRow.TENHANG = ctRow.TENHANG + " (Khuyến mại)";
                    upRow.SLXUATCHUAQUYDOI = slTang;
                    upRow.DONGIA = - ctRow.DONGIA;
                    upRow.TILEGIAMGIA = ctRow.TILEGIAMGIA;
                    upRow.THANHTIEN = - slTang * ctRow.DONGIA * (1 - ctRow.TILEGIAMGIA / 100);
                    upRow.TDONHANGID = mapper.ID;
                    upRow.COMBOID = Guid.NewGuid().ToString();
                    upRow.Update();
                }

                //tính mua 1 tặng 1 hàng khác
                sql = string.Format(@"SELECT
SUM(SLXUATCHUAQUYDOI) AS SOLUONG, SOLUONGTANG, SOLUONGMUA, TDONHANGCHITIET.DMATHANGID, DDOTKHUYENMAI.DENGIO, DMATHANGTANGID FROM TDONHANGCHITIET
INNER JOIN DDOTKHUYENMAICHITIET ON TDONHANGCHITIET.DMATHANGID = DDOTKHUYENMAICHITIET.DMATHANGID
AND TDONHANGCHITIET.DMATHANGID <> 'KM' AND TDONHANGID = '{0}'
INNER JOIN DDOTKHUYENMAI ON DDOTKHUYENMAICHITIET.DDOTKHUYENMAIID = DDOTKHUYENMAI.ID
AND DLOAIHINHKHUYENMAIID = 'e5d39bb6-41a4-43ff-bc4d-e170ae4aeba2'
AND CAST(TDONHANGCHITIET.TIMECREATED AS DATE) BETWEEN TUNGAY AND DENNGAY
AND (CAST(TDONHANGCHITIET.TIMECREATED AS TIME) BETWEEN CAST(DDOTKHUYENMAI.TUGIO AS TIME) AND CAST(DDOTKHUYENMAI.DENGIO AS TIME))
AND DDOTKHUYENMAICHITIET.DMATHANGID <> DMATHANGTANGID
GROUP BY DMATHANGTANGID, DDOTKHUYENMAI.DENGIO, TDONHANGCHITIET.DMATHANGID, SOLUONGTANG, SOLUONGMUA", mapper.ID);
                dt = Config.Db.GetTable(sql);
                if (dt.Rows.Count > 0)
                {
                    sql = string.Format(@"SELECT DMATHANGID, 
SUM(SLXUATCHUAQUYDOI) AS SLXUATCHUAQUYDOI, TENHANG, DDONVITINHID,
DONGIA, TILEGIAMGIA FROM TDONHANGCHITIET WHERE TDONHANGID = '{0}'
GROUP BY DMATHANGID, DONGIA, TILEGIAMGIA, TENHANG, DDONVITINHID
HAVING SUM(SLXUATCHUAQUYDOI) > 0", mapper.ID);
                    DataTable dtChiTiet = Config.Db.GetTable(sql);

                    foreach (DataRow r in dt.Rows)
                    {
                        decimal SoLuong = (int)ConvertTo.Decimal(r["SOLUONG"]);                        
                        DateTime denGio = ConvertTo.Date(r["DENGIO"]);
                        //trừ đi số lượng trả lại sau khoảng thời gian
                        SoLuong += GetSoLuongTra(r["DMATHANGID"].ToString(), dtHoaDon, denGio);

                        if (SoLuong <= 0) continue;

                        decimal SoLuongMua = ConvertTo.Decimal(r["SOLUONGMUA"]);
                        decimal SoLuongTang = ConvertTo.Decimal(r["SOLUONGTANG"]);

                        SoLuong = (int)(SoLuong * SoLuongTang / SoLuongMua);

                        if (SoLuong <= 0) continue;

                        //kiểm tra xem có trong danh sách mặt hàng không?
                        DataRow[] rows = dtChiTiet.Select("DMATHANGID = '" + r["DMATHANGTANGID"].ToString() + "'");
                        if (rows.Length > 0)
                        {
                            TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(rows[0]);
                            decimal slXuat = Math.Min(SoLuong, ctRow.SLXUATCHUAQUYDOI);

                            TDONHANGCHITIETRow upRow = new TDONHANGCHITIETRow();
                            upRow.DDONVITINHID = ctRow.DDONVITINHID;
                            upRow.DMATHANGID = "KM";
                            upRow.TENHANG = ctRow.TENHANG + " (Khuyến mại)";
                            upRow.SLXUATCHUAQUYDOI = SoLuong;
                            upRow.DONGIA = -ctRow.DONGIA;
                            upRow.TILEGIAMGIA = ctRow.TILEGIAMGIA;
                            upRow.THANHTIEN = -SoLuong * ctRow.DONGIA * (1 - ctRow.TILEGIAMGIA / 100);
                            upRow.TDONHANGID = mapper.ID;
                            upRow.Update();
                        }
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static decimal GetSoLuongTra(string DMATHANGID, DataTable dtHoaDon, DateTime denGio)
        {
            decimal SoLuong = 0;
            foreach (DataRow r in dtHoaDon.Rows)
            {
                if (r["DMATHANGID"].ToString() == DMATHANGID)
                {
                    DateTime gioThem = ConvertTo.Date(r["TIMECREATED"]);
                    if (gioThem > denGio)
                    {
                        SoLuong += ConvertTo.Decimal(r["SLXUATCHUAQUYDOI"]);
                    }
                }
            }

            return Math.Min(SoLuong, 0);            
        }

        private void CapNhatLuuVet()
        {
            foreach (LuuVetInfo item in lstLuuVet)
            {
                TLUUVETRow row = new TLUUVETRow();
                row.GIO = item.Gio;
                row.PHANLOAI = item.PhanLoai;

                row.BAN = item.TenBan;
                row.SODONHANG = item.SoDonHang;
                row.TAIKHOAN = item.TaiKhoan;
                row.THIETBI = item.ThietBi;
                row.NGAY = item.Ngay;
                row.NOTE = item.Note;
                row.CHUCNANG = item.ChucNang;
                row.SOLUONG = item.SoLuong;
                row.DONGIA = item.DonGia;
                row.TENHANG = item.TenHang;
                row.THANHTIEN = item.ThanhTien;
                row.Update();
            }

            lstLuuVet.Clear();
        }

        internal static int GetSoTT(DateTime ngay)
        {
            FbCommand cmd = Config.Db.GetCommand("SELECT MAX(SOTT) FROM TDONHANG WHERE LOAI = 0 AND DATHANHTOAN = 30 AND NGAY = @NGAY");
            cmd.Parameters.Add("@NGAY", FbDbType.TimeStamp).Value = ngay;
            return Config.Db.GetFirstFieldInt(cmd) + 1;
        }

        private static bool inTamTinh;
        internal static void PrintInvoice(string TDONHANGID, bool preView, bool rePrint)
        {
            string thongBao = "";
            if (!Shared.DuLieuHoaDonOk(Config.Db, TDONHANGID, false, ref thongBao))
            {
                return;
            }

            inTamTinh = preView;
            try
            {
                TDONHANGRow row = new TDONHANGRow(Config.Db.GetFirstRow(Tables.TDONHANG, "ID='" + TDONHANGID + "'"));
                string DBANID = row.DBANID;
                TDONHANGRow upRow = new TDONHANGRow(Config.Db.GetFirstRow(Tables.TDONHANG, "ID='" + TDONHANGID + "'"));
                if (preView)
                {
                    int SoLanInTamTinhToiDa = SystemConfig.SoLanInTamTinhToiDa;
                    if (SoLanInTamTinhToiDa > 0 && row.SOLANINTAMTINH >= SoLanInTamTinhToiDa)
                    {
                        Msg.ShowWarning("Chỉ cho phép in tạm tính tối đa " + SoLanInTamTinhToiDa.ToString() + " lần");
                        return;
                    }
                    upRow.SOLANINTAMTINH = row.SOLANINTAMTINH + 1;
                    upRow.INTAMTINHLUC = Config.Db.DbDateTime;
                }
                else
                {
                    int SoLanToiDa = SystemConfig.SoLanInToiDa;
                    if (SoLanToiDa > 0 && row.LANINHOADON >= SoLanToiDa)
                    {
                        Msg.ShowWarning("Chỉ cho phép in tối đa " + SoLanToiDa.ToString() + " lần");
                        return;
                    }
                    upRow.LANINHOADON = row.LANINHOADON + 1;
                }
                upRow.Update();

                bool showPreview = SystemConfig.HienThiTruocKhiIn == 30;
                bool chonMau = SystemConfig.LuaChonMauKhiIn == 30;
                //nếu bấm Control & Shift thì hiển thị
                if (!chonMau && (Control.ModifierKeys == (Keys.Control | Keys.Shift)))
                {
                    chonMau = true;
                }

                int soLan = showPreview ? 1 : Math.Max(1, Math.Min(5, SystemConfig.SoLanIn));

                //string mauHoaDon = Config.Db.GetFirstFieldString("SELECT STEMPLATEID FROM DCUAHANG WHERE ID = (SELECT DCUAHANGID FROM DKHOHANG WHERE ID = '" + row.DKHOXUATID + "')");
                string mauHoaDon = Config.Db.GetFirstFieldString("SELECT STEMPLATEID FROM DKHUVUC WHERE ID = (SELECT DKHUVUCID FROM DBAN WHERE ID = '" + DBANID + "')");
                if (mauHoaDon.Length == 0) mauHoaDon = SystemConfig.MauHoaDon;

                InTheoKhuVuc cachIn = (InTheoKhuVuc)SystemConfig.InHoaDonTheoKhuVuc;

                string MayIn = GetMayInMacDinh();

                if (cachIn == InTheoKhuVuc.InTheoKhuVuc)
                {
                    MayIn = GetMayInTheoKhuVuc(DBANID);
                }
                else if (cachIn == InTheoKhuVuc.InTamTinhTheoKhuVucInHoaDonTaiQuay && preView)
                {
                    MayIn = GetMayInTheoKhuVuc(DBANID);
                }

                PrintConfig config = new PrintConfig();
                config.TableRow = Config.GetTableDesc(Tables.TDONHANG);
                config.SFORMID = Forms.HoaDonBanHang;
                config.ShowPreview = showPreview;
                config.MayIn = MayIn;
                config.RecordID = TDONHANGID;
                config.SREPORTTEMPLATEID = mauHoaDon;
                config.ShowSelectTemplate = chonMau;
                config.SoLanIn = soLan;
                config.OnCustomReport = delegate(DataSet ds, Dictionary<string, object> dic)
                    {
                        bool GopChungChietKhauLamMot = SystemConfig.GopChungGiamGiaTienGioVaTienHangLamMot == 30;

                        decimal NoCu = ConvertTo.Decimal(dic["NOCU"]);
                        decimal TongCong = ConvertTo.Decimal(dic["TONGCONG"]);
                        decimal ThanhToan = ConvertTo.Decimal(dic["TIENTHANHTOAN"]);
                        decimal traLaiCoc = 0;
                        if (row.DATTRUOC > 0)
                        {
                            decimal TongKhachDua = row.VOUCHER + row.DATTRUOC + row.CHUYENKHOAN + row.THE + row.THETRATRUOC + row.TRUTICHLUY;
                            //trả lại tiền cọc không bao gồm trả lại tiền voucher
                            if (row.VOUCHER > TongCong) traLaiCoc = row.DATTRUOC;
                            else traLaiCoc = Math.Max(0, TongKhachDua - TongCong);
                        }
                        dic.Add("Trả lại tiền cọc dư", traLaiCoc);
                        dic.Add("Nợ mới", preView ? 0 : TongCong + NoCu - ThanhToan);
                        dic.Add("Đặt trước", row.DATTRUOC);
                        dic.Add("Tạm tính", preView ? 30 : 0);
                        dic.Add("Hiện giảm tổng", GopChungChietKhauLamMot && row.TIENGIAMGIATONG > 0);
                        dic.Add("Hiện giảm mặt hàng", !GopChungChietKhauLamMot && row.TIENGIAMGIA > 0);
                        dic.Add("Hiện giảm giờ", !GopChungChietKhauLamMot && row.TIENGIAMGIAGIO > 0);
                        dic.Add("Hiện tiền hàng",
                            row.TIENGIAMGIA == 0 && row.TIENGIO == 0 && row.TIENGIAMGIAGIO == 0
                            && row.TIENGIAMGIATONG == 0 && row.PHIDICHVU == 0 && row.TIENTHUE == 0 ? 0 : 30);
                        dic.Add("Tiêu đề", preView ? "PHIẾU TẠM TÍNH" : "HÓA ĐƠN BÁN HÀNG");

                        //string TenBan = dic["DBAN_NAME"].ToString();
                        //if (!TenBan.ToLower().Contains(Shared.GetTenPhongBan(true)))
                        //{
                        //    TenBan = Shared.GetTenPhongBan(false) + " " + TenBan.Trim();
                        //    dic["DBAN_NAME"] = TenBan;
                        //}

                        dic.Add("Điểm tích lũy", HoaDonBanHang.GetDiemTichLuyTrenHoaDon(row.DKHACHHANGID));

                        ThemDonGiaGio(ds, row);

                        DataTable dt = ds.Tables[0];
                        
                        if (dt.Columns["SOLUONGSTR"] == null)
                            dt.Columns.Add("SOLUONGSTR", typeof(string));

                        foreach (DataRow r in dt.Rows)
                        {
                            string DLOAIMATHANGID = r["DMATHANG_DLOAIMATHANGID"].ToString();
                            decimal soLuong = ConvertTo.Decimal(r["SLXUAT"]);
                            string dvt = r["DDONVITINH_NAME"].ToString();
                            if (DLOAIMATHANGID == "7")
                            {
                                int soGio = (int)soLuong;
                                int soPhut = (int)((soLuong - soGio) * 60);
                                r["SOLUONGSTR"] = (soGio > 0 ? (soGio.ToString() + "h ") : "") + soPhut + "'";
                            }
                            else
                            {
                                r["SOLUONGSTR"] = soLuong.ToString("###,###.##") + " " + dvt;
                            }
                        }                        

                        DataTable dtChild = dt.Copy();
                        for (int i = dtChild.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dtChild.Rows[i]["COMBOPARENTID"].ToString().Length == 0) dtChild.Rows.RemoveAt(i);
                        }
                        dtChild.AcceptChanges();
                        dtChild.TableName = "ComboChild";
                        ds.Tables.Add(dtChild);

                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dt.Rows[i]["COMBOPARENTID"].ToString().Length > 0) dt.Rows.RemoveAt(i);
                        }
                        dt.AcceptChanges();

                        DataRelation relation = new DataRelation("Combo", dt.Columns["COMBOID"], dtChild.Columns["COMBOPARENTID"]);
                        ds.Relations.Add(dt.Columns["COMBOID"], dtChild.Columns["COMBOPARENTID"]);

                        if (SystemConfig.InHoaDonCongGopMatHang == 30)
                        {
                            //tạo thêm 1 bảng nữa phục vụ cộng gộp
                            string sql = @"SELECT TENHANG, (SELECT NAME FROM DDONVITINH WHERE ID = TDONHANGCHITIET.DDONVITINHID) AS DVT, 
SUM(COALESCE(SLXUAT, 0) - COALESCE(SLNHAP, 0)) AS SOLUONG,
DONGIA,
SUM(THANHTIEN) AS THANHTIEN
FROM TDONHANGCHITIET INNER JOIN DMATHANG ON TDONHANGCHITIET.DMATHANGID = DMATHANG.ID 
WHERE TDONHANGID = '{0}'
AND COALESCE(XUATVATTU, 0) = 0
GROUP BY TENHANG, TDONHANGCHITIET.DDONVITINHID, DONGIA";
                            DataTable dtInCongGop = Config.Db.GetTable(string.Format(sql, TDONHANGID));
                            dtInCongGop.TableName = "InCongGop";
                            ds.Tables.Add(dtInCongGop);
                        }
                    };

                Config.PrintInvoice(config);

                if (cachIn == InTheoKhuVuc.InMotLienTaiQuayMotLienTheoKhuVuc && !rePrint)
                {
                    config.MayIn = GetMayInTheoKhuVuc(DBANID);
                    Config.PrintInvoice(config);
                }
            }
            catch (Exception ex)
            {
                if (Msg.ShowYesNo("Không thể in hóa đơn, mời bạn kiểm tra lại máy in trước khi thực hiện" + Environment.NewLine + "Chọn YES để xem chi tiết lỗi") == DialogResult.Yes)
                {
                    Msg.ShowWarning(ex.Message);
                }
            }
        }

        internal static string PrintInvoiceTablet(Database Db, string UserId, string TDONHANGID, bool LaInTamTinh)
        {
            try
            {
                string thongBao = "";
                if (!Shared.DuLieuHoaDonOk(Db, TDONHANGID, true, ref thongBao))
                {
                    return thongBao;
                }

                SUSERRow sr = new SUSERRow(Db.GetFirstRow(Tables.SUSER, "ID='" + UserId + "'"));
                
                inTamTinh = LaInTamTinh;
                TDONHANGRow row = new TDONHANGRow(Db.GetFirstRow(Tables.TDONHANG, "ID='" + TDONHANGID + "'"));
                string DBANID = row.DBANID;
                TDONHANGRow upRow = new TDONHANGRow(Db.GetFirstRow(Tables.TDONHANG, "ID='" + TDONHANGID + "'"));
                if (inTamTinh)
                {
                    int SoLanInTamTinhToiDa = SystemConfig.SoLanInTamTinhToiDa;
                    if (SoLanInTamTinhToiDa > 0 && row.SOLANINTAMTINH >= SoLanInTamTinhToiDa)
                    {
                        return "Chỉ cho phép in tạm tính tối đa " + SoLanInTamTinhToiDa.ToString() + " lần";
                    }

                    upRow.SOLANINTAMTINH = row.SOLANINTAMTINH + 1;
                    upRow.INTAMTINHLUC = Db.DbDateTime;
                }
                else
                {
                    int SoLanToiDa = SystemConfig.SoLanInToiDa;
                    if (SoLanToiDa > 0 && row.LANINHOADON >= SoLanToiDa)
                    {
                        return "Chỉ cho phép in tối đa " + SoLanToiDa.ToString() + " lần";                        
                    }
                    upRow.LANINHOADON = row.LANINHOADON + 1;
                }                

                upRow.Update(Db, UserId);

                int soLan = Math.Max(1, Math.Min(5, SystemConfig.SoLanIn));
                string mauHoaDon = Db.GetFirstFieldString("SELECT STEMPLATEID FROM DKHUVUC WHERE ID = (SELECT DKHUVUCID FROM DBAN WHERE ID = '" + row.DBANID + "')");
                if (mauHoaDon.Length == 0) mauHoaDon = SystemConfig.MauHoaDon;

                InTheoKhuVuc cachIn = (InTheoKhuVuc)SystemConfig.InHoaDonTheoKhuVuc;

                string MayIn = GetMayInMacDinh();

                if (cachIn == InTheoKhuVuc.InTheoKhuVuc)
                {
                    MayIn = GetMayInTheoKhuVuc(DBANID);
                }
                else if (cachIn == InTheoKhuVuc.InTamTinhTheoKhuVucInHoaDonTaiQuay)
                {
                    MayIn = GetMayInTheoKhuVuc(DBANID);
                }

                FastReport.Utils.Config.WebMode = true;
                PrintConfig config = new PrintConfig();                
                config.TableRow = Config.GetTableDesc(Tables.TDONHANG);
                config.SFORMID = Forms.HoaDonBanHang;
                config.ShowPreview = false;
                config.MayIn = MayIn;
                config.RecordID = TDONHANGID;
                config.SREPORTTEMPLATEID = mauHoaDon;
                config.ShowSelectTemplate = false;
                config.SoLanIn = soLan;
                config.OnCustomReport = delegate(DataSet ds, Dictionary<string, object> dic)
                    {
                        bool GopChungChietKhauLamMot = SystemConfig.GopChungGiamGiaTienGioVaTienHangLamMot == 30;

                        decimal NoCu = ConvertTo.Decimal(dic["NOCU"]);
                        decimal TongCong = ConvertTo.Decimal(dic["TONGCONG"]);
                        decimal ThanhToan = ConvertTo.Decimal(dic["TIENTHANHTOAN"]);
                        decimal traLaiCoc = 0;
                        if (row.DATTRUOC > 0)
                        {
                            decimal TongKhachDua = row.VOUCHER + row.DATTRUOC + row.CHUYENKHOAN + row.THE + row.THETRATRUOC + row.TRUTICHLUY;
                            //trả lại tiền cọc không bao gồm trả lại tiền voucher
                            if (row.VOUCHER > TongCong) traLaiCoc = row.DATTRUOC;
                            else traLaiCoc = Math.Max(0, TongKhachDua - TongCong);
                        }
                        dic.Add("Trả lại tiền cọc dư", traLaiCoc);
                        dic.Add("Nợ mới", LaInTamTinh ? 0 : TongCong + NoCu - ThanhToan);
                        dic.Add("Đặt trước", row.DATTRUOC);
                        dic.Add("Tạm tính", LaInTamTinh ? 30 : 0);
                        dic.Add("Hiện giảm tổng", GopChungChietKhauLamMot && row.TIENGIAMGIATONG > 0);
                        dic.Add("Hiện giảm mặt hàng", !GopChungChietKhauLamMot && row.TIENGIAMGIA > 0);
                        dic.Add("Hiện giảm giờ", !GopChungChietKhauLamMot && row.TIENGIAMGIAGIO > 0);
                        dic.Add("Hiện tiền hàng",
                            row.TIENGIAMGIA == 0 && row.TIENGIO == 0 && row.TIENGIAMGIAGIO == 0
                            && row.TIENGIAMGIATONG == 0 && row.PHIDICHVU == 0 && row.TIENTHUE == 0 ? 0 : 30);
                        dic.Add("Tiêu đề", LaInTamTinh ? "PHIẾU TẠM TÍNH" : "HÓA ĐƠN BÁN HÀNG");

                        string TenBan = dic["DBAN_NAME"].ToString();
                        if (!TenBan.ToLower().Contains(Shared.GetTenPhongBan(true)))
                        {
                            TenBan = Shared.GetTenPhongBan(false) + " " + TenBan.Trim();
                            dic["DBAN_NAME"] = TenBan;
                        }

                        if (dic.ContainsKey("In bởi")) dic["In bởi"] = sr.NAME;
                        
                        dic.Add("Điểm tích lũy", HoaDonBanHang.GetDiemTichLuyTrenHoaDon(row.DKHACHHANGID));

                        ThemDonGiaGio(ds, row);

                        DataTable dt = ds.Tables[0];
                        DataTable dtChild = dt.Copy();
                        for (int i = dtChild.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dtChild.Rows[i]["COMBOPARENTID"].ToString().Length == 0) dtChild.Rows.RemoveAt(i);
                        }
                        dtChild.AcceptChanges();
                        dtChild.TableName = "ComboChild";
                        ds.Tables.Add(dtChild);

                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dt.Rows[i]["COMBOPARENTID"].ToString().Length > 0) dt.Rows.RemoveAt(i);
                        }
                        dt.AcceptChanges();

                        DataRelation relation = new DataRelation("Combo", dt.Columns["COMBOID"], dtChild.Columns["COMBOPARENTID"]);
                        ds.Relations.Add(dt.Columns["COMBOID"], dtChild.Columns["COMBOPARENTID"]);
                    };

                Config.PrintInvoice(config);

                if (cachIn == InTheoKhuVuc.InMotLienTaiQuayMotLienTheoKhuVuc)
                {
                    config.MayIn = GetMayInTheoKhuVuc(DBANID);
                    Config.PrintInvoice(config);
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static void ThemDonGiaGio(DataSet ds, TDONHANGRow row)
        {
            string sql = @"SELECT DONGIA, 
(SELECT NAME FROM DBANGGIA WHERE ID = DBANGGIAID) AS BANGGIA, DBANGGIAID, TUGIO, DENGIO, THANHTIEN,
(SELECT NAME FROM DBAN WHERE ID = DBANID) AS BAN, CACHTINHGIA FROM TDONHANGGIO WHERE TDONHANGID = '{0}'
UNION ALL
SELECT DONGIA, 
(SELECT NAME FROM DBANGGIA WHERE ID = DBANGGIAID) AS BANGGIA, DBANGGIAID, BATDAUPHONGCUOI, KETTHUC, TIENGIOPHONGCUOI,
(SELECT NAME FROM DBAN WHERE ID = DBANID) AS BAN, CACHTINHGIA FROM TDONHANG WHERE ID = '{0}'";

            sql = string.Format(sql, row.ID);
            DataTable dt = Config.Db.GetTable(sql);
            dt.Columns.Add("THOIGIAN", typeof(string));
            dt.Columns.Add("SONGAY", typeof(int));
            dt.Columns.Add("SOGIO", typeof(int));
            dt.Columns.Add("SOPHUT", typeof(int));
            dt.Columns.Add("DIENGIAI", typeof(string));

            int phutKm = row.PHUTKHUYENMAI;
            decimal tiLeKm = row.TILEKHUYENMAIPHUTDAU;
            //đưa thêm thông số ngày giờ, bảng giá vào
            if (SystemConfig.InChiTietTheoTungKhoangGio == 30)
            {
                DateTime gioBatDauBill = row.BATDAU;
                //nếu in chi tiết theo từng khoảng giờ
                DataTable dtNew = dt.Clone();
                List<ChiTietTinhGiaGio> lst = new List<ChiTietTinhGiaGio>();
                foreach (DataRow r in dt.Rows)
                {
                    TDONHANGGIORow rGio = new TDONHANGGIORow(r);
                    CachTinhGiaGio cachTinh = (CachTinhGiaGio)rGio.CACHTINHGIA;                    
                    Shared.TinhGia(cachTinh, rGio.DBANGGIAID, rGio.DONGIA, rGio.TUGIO, rGio.DENGIO, gioBatDauBill, phutKm, tiLeKm, lst, 0);
                    foreach (ChiTietTinhGiaGio item in lst)
                    {
                        if (item.Ban == null) item.Ban = rGio["BAN"].ToString();
                    }
                }

                foreach (ChiTietTinhGiaGio item in lst)
                {
                    DataRow r = dtNew.NewRow();
                    r["SONGAY"] = item.SoNgay;
                    r["SOGIO"] = item.SoGio;
                    r["SOPHUT"] = item.SoPhut;
                    r["DONGIA"] = item.DonGia;
                    r["THANHTIEN"] = Math.Round(item.ThanhTien / 1000, 0) * 1000;
                    r["BAN"] = item.Ban;
                    r["TUGIO"] = item.TuGio;
                    r["DENGIO"] = item.DenGio;
                    r["THOIGIAN"] = (item.SoNgay > 0 ? item.SoNgay.ToString() + "ngày " : "") + (item.SoGio > 0 ? (item.SoGio.ToString() + "h ") : "") + item.SoPhut.ToString() + "'";
                    dtNew.Rows.Add(r);
                }

                dtNew.TableName = "ChiTietGio";
                ds.Tables.Add(dtNew);

            }
            else
            {                
                foreach (DataRow r in dt.Rows)
                {
                    TDONHANGGIORow rGio = new TDONHANGGIORow(r);
                    DateTime tuGio = rGio.TUGIO;
                    DateTime denGio = rGio.DENGIO;
                    TimeSpan ts = denGio - tuGio;
                    int day = (int)ts.TotalDays;
                    int hour = (int)ts.Hours;
                    int minute = (int)ts.Minutes;
                    r["SOGIO"] = hour;
                    r["SONGAY"] = day;
                    r["SOPHUT"] = minute;
                    r["THOIGIAN"] = (day > 0 ? day.ToString() + "ngày " : "") + (hour > 0 ? (hour.ToString() + "h ") : "") + minute.ToString() + "'";
                    if (rGio.CACHTINHGIA == (int)CachTinhGiaGio.THEOBANGGIA)
                    {
                        r["DIENGIAI"] = r["BANGGIA"].ToString();
                    }
                    else
                    {
                        r["DIENGIAI"] = rGio.DONGIA.ToString("n0") + " (/giờ)";
                    }
                }
                dt.TableName = "ChiTietGio";
                ds.Tables.Add(dt);
            }
        }

        private static string GetMayInTheoKhuVuc(string DBANID)
        {
            string sql = string.Format("SELECT DKHUVUCID FROM DBAN WHERE ID = '{0}'", DBANID);
            string DKHUVUCID = Config.Db.GetFirstFieldString(sql);
            string iniPath = Path.Combine(Application.StartupPath, "Data\\app.dat");
            string printerName = IniFile.GetString(iniPath, "INKHUVUC", DKHUVUCID);
            return printerName;
        }

        private static string GetMayInMacDinh()
        {
            try
            {
                return new PrinterSettings().PrinterName;
            }
            catch
            {
            }
            return "";
        }

        internal static bool IsValid(string soOrder, int rowCount)
        {
            if (SystemConfig.BatChucNangKiemSoatOrder == 30 && rowCount > 0)
            {
                if (soOrder.Trim().Length == 0)
                {
                    Msg.ShowWarning("Mời bạn nhập số order");                    
                    return false;
                }

                string[] codes = soOrder.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string code in codes)
                {
                    int result;
                    if (!int.TryParse(code, out result))
                    {
                        Msg.ShowWarning("Mời bạn nhập đúng định dạng số order, ví dụ: 12, 16, 17,19");                        
                        return false;
                    }
                }
                if (codes.Length == 0)
                {
                    Msg.ShowWarning("Mời bạn nhập số order");                    
                    return false;
                }
            }
            return true;
        }

        private void TraLaiKhach(decimal tienTraLai)
        {
 	        //tạo hiếu chi
            DynamicAeForm form = (DynamicAeForm) Config.CreateAeForm(Tables.TTHUCHI, 1, "");
            form.ReLoad("");
            TTHUCHI1Ae code = form.CodeRunner as TTHUCHI1Ae;
            code.txtDIENGIAI.Text = "Trả lại tiền đặt trước hóa đơn số " + txtNAME.Text;
            code.chkKHONGTHAYDOICONGNO.Checked = true;
            if (lueDKHACHHANGID.StringValue.Length > 0)
            {
                code.lueDKHACHHANGID.EditValue = lueDKHACHHANGID.StringValue;
            }
            code.numCHI.Value = tienTraLai;
            form.ShowDialog();
        }

        private void UpdateGiaTheoGio()
        {
            //chỉ cập nhật trường hợp sử dụng dịch vụ
            if (mode != HoaDonMode.SuDungDichVu) return;

            DBANRow banRow = new DBANRow(DBANID);
            DKHUVUCRow kvRow = new DKHUVUCRow(banRow.DKHUVUCID);
            GiaMatHang giaSuDung = (GiaMatHang)ConvertTo.Int(kvRow.DGIAMATHANGID);

            DateTime now = Config.Db.DbDateTime;
            now = new DateTime(2000, 1, 1, now.Hour, now.Minute, 0);
            DateTime tuGio = kvRow.TUGIO;
            DateTime denGio = kvRow.DENGIO;

            tuGio = new DateTime(2000, 1, 1, tuGio.Hour, tuGio.Minute, 0);
            denGio = new DateTime(2000, 1, 1, denGio.Hour, denGio.Minute, 0);

            if (IsTimeInRange(tuGio, denGio, now))
            {
                giaSuDung = (GiaMatHang)ConvertTo.Int(kvRow.DGIATHEOGIOID);
                //cập nhật lại giá
                DataTable dt = DetailTable;
                if (dt != null)
                foreach (DataRow r in dt.Rows)
                {
                    if (r.RowState == DataRowState.Deleted) continue;

                    string DMATHANGID = r["DMATHANGID"].ToString();
                    //bỏ qua combo
                    if (r["COMBOPARENTID"].ToString().Length > 0) continue;
                    //mặt hàng khuyến mại tự động
                    if (DMATHANGID == "KM") continue;

                    DMATHANGRow spRow = new DMATHANGRow(DMATHANGID);
                    if (ConvertTo.Int(spRow.DLOAIMATHANGID) != (int)LoaiMatHang.MatHangMo)
                    {
                        TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(r);
                        if (giaSuDung == GiaMatHang.GIABAN)
                        {
                            //không làm gì vì chọn giá 1
                            ctRow.DONGIA = spRow.GIABAN;
                        }
                        else if (giaSuDung == GiaMatHang.GIABAN2)
                        {
                            //chọn đơn giá 2
                            ctRow.DONGIA = spRow.GIABAN2;
                        }
                        else if (giaSuDung == GiaMatHang.GIABAN3)
                        {
                            ctRow.DONGIA = spRow.GIABAN3;
                        }
                        else if (giaSuDung == GiaMatHang.GIABAN4)
                        {
                            ctRow.DONGIA = spRow.GIABAN4;
                        }

                        SafeCalculateRow(ctRow.Row);
                    }
                }
            }
        }

        internal static decimal GetDatTruoc(No1FieldMapper mapper)
        {
            decimal daDat = 0;
            string DNHOMID = (mapper != null && mapper[TDONHANGInfo.NHOMGUID] != null) ? mapper[TDONHANGInfo.NHOMGUID].ToStringValue() : "";
            if (DNHOMID.Length == 0)
            {
                string tDatHangID = (mapper != null && mapper[TDONHANGInfo.TDATHANGID] != null) ? mapper[TDONHANGInfo.TDATHANGID].ToStringValue() : "";
                if (SystemConfig.SuDungChucNangTamUngTrongDonHang == 0 && tDatHangID.Length == 0) return 0;

                string sql = "SELECT SUM(THU) FROM TTHUCHI WHERE TDONHANGID = '" + mapper.ID + "'";                                
                if (tDatHangID.Length > 0) sql += " OR TDATHANGID = '" + tDatHangID + "'";

                daDat = Config.Db.GetFirstFieldDec(sql);
            }
            else
            {
                string sql = "SELECT SUM(THU) FROM TDONHANG INNER JOIN TTHUCHI ON (TDONHANG.TDATHANGID = TTHUCHI.TDATHANGID OR TDONHANG.ID = TTHUCHI.TDONHANGID) AND NHOMGUID = '" + DNHOMID + "'";
                daDat = Config.Db.GetFirstFieldDec(sql);
            }
            return daDat;
        }

		public void btnInLaiBill_Click(object sender, EventArgs e)
		{         
            PrintInvoice(mapper.ID, false, true);
            Track(LoaiLuuVet.InBill, "In lại bill số " + txtNAME.Text + ", ngày: " + dtNGAY.DateTime.ToString("dd/MM/yyyy"), 0, 0, TIENPHAITRA.Value, "");
		}


		public void btnInCheBien_Click(object sender, EventArgs e)
        {
            ThucHienInCheBien(false);
		}

        public void ThucHienInCheBien(bool TuDongIn)
        {
            if (TuDongIn)
            {
                //nếu không kích hoạt thì không thực hiện
                if (!TuDongInPhaChe || !prAutoPrint.Visible) return;
                StopAutoPrint();
            }

            InCheBien form = (InCheBien)Config.CreateForm(Forms.InCheBien);

            string sql = "SELECT NAME, DKHUVUCID, (SELECT NAME FROM DKHUVUC WHERE ID = DKHUVUCID) AS KHUVUC FROM DBAN WHERE ID = '" + DBANID + "'";
            DataRow rBan = Config.Db.GetFirstRow(sql);

            form.SetData(mapper.ID, this, rBan["DKHUVUCID"].ToString(), rBan["NAME"].ToString(), rBan["KHUVUC"].ToString(), TuDongIn, txtNAME.Text);
            if (!form.NoItemToPrint)
            {
                if (TuDongIn)
                {
                    form.ThucHienInTuDong();
                }
                else
                {
                    form.No1Form1.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Hàm dừng tự động in chế biến
        /// </summary>
        private void StopAutoPrint()
        {
            tmrAutoPrint.Enabled = false;
            prAutoPrint.Visible = false;
        }

		public void btnTheoNhom_Click(object sender, EventArgs e)
		{            
            if (DaThanhToan(true)) return;
            if (!DbUtils.CanLogin(Functions.GiamGiaMatHang)) return;
            if (numTIENGIAMGIA.Enabled)
            {
                GiamGiaTheoNhom form = (GiamGiaTheoNhom)Config.CreateForm(Forms.GiamGiaTheoNhom);
                if (form.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    string message = "Bạn có muốn đặt giảm giá đồ ăn: {0}%, đồ uống: {1}%, dịch vụ: {3}%, đồ khác: {2}% không không?";
                    message = string.Format(message, form.GiamDoAn, form.GiamDoUong, form.GiamDoKhac, form.GiamDichVu);
                    if (Msg.ShowYesNo(message) == DialogResult.Yes)
                    {
                        SetGiamGiaTheoNhom(form.GiamDoAn, form.GiamDoUong, form.GiamDoKhac, form.GiamDichVu);
                        mapper.RaiseOnCalculation();
                    }
                }
            }
		}

        private void SetGiamGiaTheoNhom(decimal doAn, decimal doUong, decimal doKhac, decimal dichVu)
        {
            DataTable dt = (grDetail?.GridView?.DataSource as DataTable) ?? (grDetail?.DataSource as DataTable);
            if (dt == null || dt.Rows.Count == 0) return;

            foreach (DataRow r in dt.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                string mathangId = r.Table.Columns.Contains("DMATHANGID") ? r["DMATHANGID"]?.ToString() : "";
                if (string.IsNullOrEmpty(mathangId)) continue;

                string sql = "SELECT DMATHANG.TIMECREATED, DNHOMMATHANG.DLOAIDOID FROM DMATHANG LEFT JOIN DNHOMMATHANG ON DNHOMMATHANG.ID = DMATHANG.DNHOMMATHANGID WHERE DMATHANG.ID = '{0}'";
                sql = string.Format(sql, mathangId);
                DataRow rChiTiet = Config.Db.GetFirstRow(sql);

                int dLoaiDo = -1;
                if (rChiTiet != null && rChiTiet["DLOAIDOID"] != DBNull.Value && !string.IsNullOrEmpty(rChiTiet["DLOAIDOID"].ToString()))
                {
                    dLoaiDo = ConvertTo.Int(rChiTiet["DLOAIDOID"].ToString());
                }

                TDONHANGCHITIETRow row = new TDONHANGCHITIETRow(r);
                decimal tiLeGiam = 0;
                switch (dLoaiDo)
                {
                    case (int)LoaiDo.DoAn: // 0
                        tiLeGiam = doAn;
                        break;
                    case (int)LoaiDo.DoUong: // 1
                        tiLeGiam = doUong;
                        break;
                    case (int)LoaiDo.DichVu: // 2
                        tiLeGiam = dichVu;
                        break;
                    case (int)LoaiDo.DoKhac: // 3
                    case (int)LoaiDo.NguyenLieu: // 4
                    default:
                        tiLeGiam = doKhac;
                        break;
                }

                if (SystemConfig.KichHoatKhuyenMaiTuDong == 30)
                {
                    DateTime tc = (rChiTiet != null && rChiTiet["TIMECREATED"] != DBNull.Value)
                        ? ConvertTo.Date(rChiTiet["TIMECREATED"])
                        : DateTime.Now;
                    decimal value = GetTiLeKhuyenMaiTheoMatHang(tc, row.DMATHANGID);
                    tiLeGiam = Math.Max(value, tiLeGiam);
                }

                row.TILEGIAMGIA = tiLeGiam;
                SafeCalculateRow(row.Row, -1);
                SaveChiTietDirect(row);
            }
            mapper_OnCalculation(this, EventArgs.Empty);
            SaveDonHangTotals();
            try { grDetail?.GridView?.Refresh(); } catch { }
        }


		public void btnXoa_Click(object sender, EventArgs e)
		{
            if (grDetail?.GridView == null || grDetail.GridView.SelectedRows.Count == 0 || grDetail.GridView.SelectedRow == null)
            {
                Msg.ShowWarning("Mời bạn chọn mặt hàng trong hóa đơn để xóa");
                return;
            }
            if (!DuocPhepGiamDo()) return;
            if (DaThanhToan(true)) return;

            if (KhongDuocXoaSauKhiInPhaChe())
            {
                TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(grDetail.GridView.SelectedRow);
                decimal soLuongIn = GetSoLuongDaIn(ctRow, mapper.ID);
                decimal soLuongSau = GetSoLuongSauGiam(ctRow, ctRow.SLXUATCHUAQUYDOI, DetailTable);
                if (soLuongIn > soLuongSau)
                {
                    Msg.ShowWarning("Không được xóa sau khi in xuống bếp!");
                    return;
                }
            }

            if (SystemConfig.NhapMatKhauGiamDo == 0 && KiemTraDaInTamTinh())
            {
                Msg.ShowWarning("Không thể xóa vì phiếu đã in tạm tính");
                return;
            }

            string LyDo = "";
            if (CoLuuVet && SystemConfig.NhapLyDoKhiXoaMon == 30)
            {
                NhapLyDo form = (NhapLyDo)Config.CreateForm(Forms.NhapLyDo);
                if (form.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    LyDo = form.txtLyDo.Text;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (Msg.ShowYesNo("Bạn có muốn xóa mặt hàng đang chọn ra khỏi hóa đơn không?") != DialogResult.Yes)
                {
                    return;
                }
            }                       

            if (CoLuuVet)
            {
                foreach (DataGridViewRow r in grDetail.GridView.SelectedRows)
                {
                    var drv = r.DataBoundItem as DataRowView;
                    if (drv == null) continue;
                    DataRow row = drv.Row;
                    TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(row);
                    Track(LoaiLuuVet.XoaMon, "Xóa mặt hàng '" + ctRow.TENHANG + "' Số lượng '" + ctRow.SLXUATCHUAQUYDOI.ToString() + "' " + LyDo, ctRow.SLXUATCHUAQUYDOI, ctRow.DONGIA, ctRow.THANHTIEN, ctRow.TENHANG);
                }
            }

            //xóa combo nếu có
            foreach (DataGridViewRow r in grDetail.GridView.SelectedRows)
            {
                var drv = r.DataBoundItem as DataRowView;
                if (drv == null) continue;
                DataRow row = drv.Row;
                TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow(row);
                if (IsCombo(ctRow))
                {
                    Config.Db.ExecSql("DELETE FROM TDONHANGCHITIET WHERE COMBOPARENTID = '" + ctRow.COMBOID + "'");
                }
                DeleteChiTietDirect(ctRow.ID);
            }
            grDetail.GridView.DeleteSelectedRows();
            mapper.RaiseOnCalculation();
            SaveDonHangTotals();

            StartAutoPrintTimer();
		}


		public void btnGiam_Click(object sender, EventArgs e)
		{
            if (grDetail.GridView.SelectedRows.Count == 0)
            {
                Msg.ShowWarning("Mời bạn chọn mặt hàng trong hóa đơn để giảm số lượng");
            }
            else
            {
                if (DaThanhToan(true)) return;
                if (!DuocPhepGiamDo()) return;
                if (KiemTraDaInTamTinh())
                {
                    Msg.ShowWarning("Không thể giảm vì phiếu đã in tạm tính");
                    return;
                }
                DataGridViewRow row = grDetail.GridView.SelectedRows[0];
                TDONHANGCHITIETRow ctRow = new TDONHANGCHITIETRow((row.DataBoundItem as DataRowView).Row);
                if (ConvertTo.Int(ctRow["THEOGIO"]) == 30) return;

                decimal val = 0;

                if (SystemConfig.HienThiCuaSoNhapSoLuongKhiQuetMaVach == 30)
                {
                    NhapSoLuongNhaHang frmNhapSl = (NhapSoLuongNhaHang)Config.CreateForm(Forms.NhapSoLuongNhaHang);
                    frmNhapSl.MaxValue = ctRow.SLXUATCHUAQUYDOI;
                    frmNhapSl.lblItem.Text = frmNhapSl.lblItem.Text + ctRow.TENHANG;
                    frmNhapSl.No1Form1.Text = "NHẬP SỐ LƯỢNG GIẢM";
                    if (frmNhapSl.No1Form1.ShowDialog() != DialogResult.OK) return;
                    val = frmNhapSl.SoLuong;
                }
                else
                {
                    val = getSoLuong();
                }

                if (ctRow.SLXUATCHUAQUYDOI <= val)
                {
                    btnXoa.PerformClick();
                    return;
                }
                                
                if (ctRow.SLXUATCHUAQUYDOI >= val + 1)
                {
                    if (KhongDuocXoaSauKhiInPhaChe())
                    {
                        decimal soLuongSau = GetSoLuongSauGiam(ctRow, val, DetailTable);
                        //tính số lượng sau 

                        //kiểm tra đã in xuống bếp chưa
                        decimal daIn = GetSoLuongDaIn(ctRow, mapper.ID);
                        if (daIn > soLuongSau)
                        {
                            Msg.ShowWarning("Bạn đã in xuống bếp số lượng " + daIn.ToString() + ". Không thể giảm.");
                            return;
                        }
                    }

                    ctRow.SLXUATCHUAQUYDOI = ctRow.SLXUATCHUAQUYDOI - val;
                    ctRow.SOLUONG = ctRow.SLXUATCHUAQUYDOI;
                    SafeCalculateRow(ctRow.Row);                    

                    CapNhatCombo(ctRow);
                    SaveChiTietDirect(ctRow);
                    mapper.RaiseOnCalculation();
                    SaveDonHangTotals();

                    cboSoLuong.SelectedIndex = 0;
                    Track(LoaiLuuVet.GiamMon, "Giảm '" + ctRow.TENHANG + "', số lượng: " + val.ToString(), val, ctRow.DONGIA, val * ctRow.THANHTIEN / ctRow.SLXUATCHUAQUYDOI, ctRow.TENHANG);

                    StartAutoPrintTimer();
                }
                else
                {
                    Msg.ShowWarning("Không thể giảm '" + val.ToString() + "' vì số lượng hiện tại chỉ có '" + ctRow.SLXUATCHUAQUYDOI.ToString() + "'");
                }
            }
		}

        public static decimal GetSoLuongSauGiam(TDONHANGCHITIETRow row, decimal soLuongGiam, DataTable dtDetail)
        {
            if (dtDetail == null) return 0;
            decimal soLuong = 0;            
            if (IsCombo(row))
            {
                foreach (DataRow r in dtDetail.Rows)
                {
                    if (r.RowState == DataRowState.Deleted) continue;

                    if (r["COMBOPARENTID"].ToString() == row.COMBOID)
                    {
                        //giảm số lượng theo combo
                        soLuong += ConvertTo.Decimal(r["SLXUATCHUAQUYDOI"]) - soLuongGiam * ConvertTo.Decimal(r["SLXUATCHUAQUYDOI"]) / row.SLXUATCHUAQUYDOI;
                    }
                }                
            }
            else
            {
                foreach (DataRow r in dtDetail.Rows)
                {
                    if (r.RowState == DataRowState.Deleted) continue;

                    if (r["TENHANG"].ToString() == row.TENHANG)
                    {
                        soLuong += ConvertTo.Decimal(r["SLXUATCHUAQUYDOI"]);
                    }
                }

                soLuong = soLuong - soLuongGiam;
            }

            return soLuong;
        }


		public void btnThem_Click(object sender, EventArgs e)
		{
            if (DaThanhToan(true)) return;
            decimal val = getSoLuong();
            if (grMatHang.SelectedRows.Count == 0)
            {
                Msg.ShowWarning("Mời bạn chọn mặt hàng trước!");
                return;
            }

            if (val > 0)
            {                
                string DMATHANGID = (grMatHang.SelectedRows[0].DataBoundItem as DataRowView).Row["ID"].ToString();

                DMATHANGRow spRow = new DMATHANGRow(DMATHANGID);
                if (spRow.IsNull)
                {
                    Msg.ShowWarning("Mặt hàng này đã bị xóa ra khỏi danh mục");
                    return;
                }
                if (SystemConfig.SuDungGia2 == 30 || SystemConfig.SuDungGia3 == 30 || SystemConfig.SuDungGia4 == 30)
                {
                    //kiểm tra xem lấy giá nào
                    DBANRow banRow = new DBANRow(DBANID);
                    DKHUVUCRow kvRow = new DKHUVUCRow(banRow.DKHUVUCID);
                    GiaMatHang giaSuDung = (GiaMatHang) ConvertTo.Int(kvRow.DGIAMATHANGID);

                    //kích hoạt giá theo khu vực và chọn giờ theo giờ gọi đồ
                    LayGiaMatHangTheoGio(Config.Db, kvRow, ref giaSuDung);

                    if (giaSuDung == GiaMatHang.HIENTHILUACHON && spRow.GIATHEOTHOIGIA == 0 && spRow.DLOAIMATHANGID != ((int)LoaiMatHang.MatHangMo).ToString())
                    {
                        ChonLoaiGia form = (ChonLoaiGia)Config.CreateForm(Forms.ChonLoaiGia);
                        form.SetMatHang(spRow);
                        if (form.form.ShowDialog() != DialogResult.OK) return;
                        giaSuDung = (GiaMatHang) form.LoaiGia;
                    }

                    if (giaSuDung == GiaMatHang.GIABAN2)
                    {
                        //chọn đơn giá 2
                        spRow.GIABAN = spRow.GIABAN2;
                    }
                    else if (giaSuDung == GiaMatHang.GIABAN3)
                    {
                        spRow.GIABAN = spRow.GIABAN3;
                    }
                    else if (giaSuDung == GiaMatHang.GIABAN4)
                    {
                        spRow.GIABAN = spRow.GIABAN4;
                    }                    
                }

                LoaiMatHang loai = GetLoaiMathang(spRow);
                if (CoDungCanDienTu && spRow.THEOCAN == 30)
                {                    
                    val = numCan.Value;
                    if (val <= 0)
                    {
                        Msg.ShowWarning("Mời bạn đặt đồ lên cân");
                        return;
                    }
                }
                else if (SystemConfig.HienThiCuaSoNhapSoLuongKhiQuetMaVach == 30 && loai != LoaiMatHang.DichVuTheoGio)
                {
                    NhapSoLuongNhaHang form = (NhapSoLuongNhaHang)Config.CreateForm(Forms.NhapSoLuongNhaHang);
                    form.lblItem.Text = form.lblItem.Text + spRow.NAME;
                    if (form.No1Form1.ShowDialog() == DialogResult.OK)
                    {
                        val = form.SoLuong;
                    }
                    else return;
                }

                if (loai == LoaiMatHang.DichVuTheoGio) val = GetSoLuongTheoGio();

                DoAddItemToGrid(spRow, val, false);
                SetKhuyenMai();

                StartAutoPrintTimer();

                numSoLuong.Value = 1;
                cboSoLuong.SelectedIndex = 0;
                txtTimKiem.SelectAllEx();
            }
            else
            {
                Msg.ShowWarning("Mời bạn nhập số lượng!");
            }
		}

        internal static void LayGiaMatHangTheoGio(Database db, DKHUVUCRow kvRow, ref GiaMatHang giaSuDung)
        {
            if (SystemConfig.SuDungGiaTheoGio == 30 && SystemConfig.CachChonGioTinhGia == 0)
            {
                DateTime now = db.DbDateTime;
                now = new DateTime(2000, 1, 1, now.Hour, now.Minute, 0);
                DateTime tuGio = kvRow.TUGIO;
                DateTime denGio = kvRow.DENGIO;

                tuGio = new DateTime(2000, 1, 1, tuGio.Hour, tuGio.Minute, 0);
                denGio = new DateTime(2000, 1, 1, denGio.Hour, denGio.Minute, 0);

                if (IsTimeInRange(tuGio, denGio, now))
                {
                    GiaMatHang giaTheoGio = (GiaMatHang)ConvertTo.Int(kvRow.DGIATHEOGIOID);
                    if (giaTheoGio != GiaMatHang.HIENTHILUACHON)
                        giaSuDung = (GiaMatHang)ConvertTo.Int(kvRow.DGIATHEOGIOID);
                }
            }
        }

        private int SoGiay = 0;
        /// <summary>
        /// Hàm thiết lập lại chế độ tự động in pha chế
        /// </summary>
        private void StartAutoPrintTimer()
        {
            if (SystemConfig.SuDungChucNangInXuongBep == 0 || !TuDongInPhaChe)
            {
                return;
            }
            if (SoGiayTuDongInPhaChe == 0)
            {
                ThucHienInCheBien(true);
            }
            else
            {
                SoGiay = SoGiayTuDongInPhaChe;
                tmrAutoPrint.Enabled = true;
                prAutoPrint.Value = 100;
                prAutoPrint.Visible = true;
            }
        }        

        private void SetKhuyenMai()
        {

        }

        private LoaiMatHang GetLoaiMathang(DMATHANGRow spRow)
        {
            return (LoaiMatHang)ConvertTo.Int(spRow.DLOAIMATHANGID);
        }

        public static bool IsTimeInRange(DateTime tuGio, DateTime denGio, DateTime now)
        {
            if (tuGio < denGio) return tuGio <= now && now <= denGio;
            else
            {
                return tuGio <= now || denGio >= now;
            }
        }


        private decimal GetSoLuongTheoGio()
        {
            if (dtKETTHUC.EditValue == null) return 0;
            //DateTime batDau = dtBATDAU.DateTime;
            DateTime batDau = Config.Db.DbDateTime;
            DateTime ketThuc = dtKETTHUC.DateTime;
            if (ketThuc < batDau) return 0;
            TimeSpan ts = ketThuc - batDau;
            return Math.Round((decimal)ts.TotalHours, 2);
        }

        public void ChuyenBan(string TDONHANGID, ChuyenGopBanMode chuyenGopMode)
        {
            string ID = TDONHANGID;
            if (ID.Length == 0)
            {
                Msg.ShowWarning("Dữ liệu đã thay đổi!");
            }
            else
            {
                if (DaThanhToan(true)) return;

                //nếu chưa in phải in trước khi chuyển bàn
                ThucHienInCheBien(true);                

                No1Run.ChuyenBan form = (No1Run.ChuyenBan) Config.CreateForm(Forms.ChuyenBan);
                form.SetData(ID, chuyenGopMode);
                if (form.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    RefreshTrangThaiBan();
                    Reload("", DBANID);
                }
            }
        }

		public void btnGopBan_Click(object sender, EventArgs e)
		{
            ChuyenBan(mapper.ID, ChuyenGopBanMode.GopBan);
		}


		public void btnChuyenBan_Click(object sender, EventArgs e)
		{
            ChuyenBan(mapper.ID, ChuyenGopBanMode.ChuyenBan);
		}


		public void btnDoiGioVao_Click(object sender, EventArgs e)
		{
            if (!IsDaThanhToan(mapper.ID))
            {
                ThayDoiGioVao form = (ThayDoiGioVao)Config.CreateForm(Forms.ThayDoiGioVao);
                form.SetData(false, ConvertTo.Date(new TDONHANGRow(mapper.ID)["TIMECREATED"]));
                if (form.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    dtBATDAUPHONGCUOI.DateTime = form.DateTime;
                    SetDonHangField("BATDAU", form.DateTime);
                    Track(LoaiLuuVet.Khac, "Đổi giờ vào " + form.DateTime.ToString("dd/MM/yyyy HH:mm"), 0, 0, 0, "");
                    UpdateGio();
                }
            }
            else
            {
                Msg.ShowWarning("Hóa đơn này đã thanh toán");
                RefreshTrangThaiBan();
            }
		}       

		public void btnDoiGioRa_Click(object sender, EventArgs e)
		{
            if (!IsDaThanhToan(mapper.ID))
            {
                DateTime gioRa = new TDONHANGRow(mapper.ID).KETTHUC;
                if (gioRa < Config.Db.DbDateTime) gioRa = Config.Db.DbDateTime;
                ThayDoiGioVao form = (ThayDoiGioVao)Config.CreateForm(Forms.ThayDoiGioVao);
                form.SetData(true, gioRa);
                if (form.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    dtKETTHUC.DateTime = form.DateTime;                   
                    Track(LoaiLuuVet.Khac, "Đổi giờ ra " + form.DateTime.ToString("dd/MM/yyyy HH:mm"), 0, 0, 0, "");
                    UpdateTongThoiGian();
                }
            }
            else
            {
                Msg.ShowWarning("Hóa đơn này đã thanh toán");
            }
		}

        public void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            needResetFilterOnEnter = true;
            if (e.KeyCode == Keys.Enter)
            {
                if (!ToiUuBanPhim || SystemConfig.HienThiCuaSoNhapSoLuongKhiQuetMaVach == 30)
                {
                    if (SystemConfig.BanHangDungDauDocMaVach == 30 && grMatHang.Filter != txtTimKiem.Text)
                        grMatHang.Filter = txtTimKiem.Text;
                    btnThem.PerformClick();
                }
                else
                {
                    numSoLuong.Select();
                    numSoLuong.Select(0, numSoLuong.Text.Length);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtTimKiem.Text = "";
            }
        }

        public void grMatHang_OnCustomFilter(ref String filter)
        {
            if (!txtTimKiem.Focused)
            {
                if (filterTv != null)
                {
                    string where = "";
                    foreach (TreeNode node in filterTv.tvMain.Nodes)
                    {
                        string ID = filterTv.GetID(node);
                        if (ID.Length == 0) continue;
                        if (where.Length > 0) where += " OR ";
                        where += "DNHOMMATHANGID = '" + ID + "'";
                    }
                    if (where.Length == 0) where = "0=1";
                    if (filter.Length > 0) filter += " AND ";
                    filter += "(" + where + ")";
                }
                else
                {
                    string ID = tvCat.Visible ? tvCat.SelectedID : SelectedNhomID;
                    if (ID.Length > 0)
                    {
                        if (filter.Length > 0) filter += " AND ";
                        filter += "DNHOMMATHANGID = '" + ID + "'";
                    }
                }
            }
        }


		public void numSoLuong_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                btnThem.PerformClick();
            }
		}
        
		public void tvCat_OnFocusedNodeChanged(TreeNode node, DataRow r, string ID, TreeItemType type)
		{            
            ApplyMatHangFilter();
		}


		public void numTILEGIAMGIA_OnEditValueChanged(object sender, object value)
		{
            if (numTILEGIAMGIA.Focused)
            {
                _giamTheoTien = 0;
                SetDonHangField("GIAMTHEOTIEN", 0);
            }
		}


		public void numTIENGIAMGIA_OnEditValueChanged(object sender, object value)
		{
            if (numTIENGIAMGIA.Focused)
            {
                _giamTheoTien = 30;
                SetDonHangField("GIAMTHEOTIEN", 30);
            }
		}


		public void numTILEGIAMGIAGIO_OnEditValueChanged(object sender, object value)
		{
            if (numTILEGIAMGIAGIO.Focused)
            {
                _giamGiaGioTheoTien = 0;
                SetDonHangField("GIAMGIAGIOTHEOTIEN", 0);
            }
		}


		public void numTIENGIAMGIAGIO_OnEditValueChanged(object sender, object value)
		{
            if (numTIENGIAMGIAGIO.Focused)
            {
                _giamGiaGioTheoTien = 30;
                SetDonHangField("GIAMGIAGIOTHEOTIEN", 30);
            }
		}


		public void numTILEGIAMGIATONG_OnEditValueChanged(object sender, object value)
		{
            if (numTILEGIAMGIATONG.Focused)
            {
                _giamTongTheoTien = 0;
                SetDonHangField("GIAMTONGTHEOTIEN", 0);
            }
		}


		public void numTIENGIAMGIATONG_OnEditValueChanged(object sender, object value)
		{
            if (numTIENGIAMGIATONG.Focused)
            {
                _giamTongTheoTien = 30;
                SetDonHangField("GIAMTONGTHEOTIEN", 30);
            }
		}


		public void numTILEPHIDICHVU_OnEditValueChanged(object sender, object value)
		{
            if (numTILEPHIDICHVU.Focused)
            {
                _phiDichVuTheoTien = 0;
                SetDonHangField("PHIDICHVUTHEOTIEN", 0);
            }
		}


		public void numPHIDICHVU_OnEditValueChanged(object sender, object value)
		{
            if (numPHIDICHVU.Focused)
            {
                _phiDichVuTheoTien = 30;
                SetDonHangField("PHIDICHVUTHEOTIEN", 30);
            }
		}

        public event OnNoteChangedHandler OnNoteChanged;
		public void txtNOTE_TextChanged(object sender, EventArgs e)
		{
            if (txtNOTE.Focused && SystemConfig.HienThiGhiChuTrenGiaoDienBan == 30)
            {
                if (OnNoteChanged != null) OnNoteChanged(DBANID, txtNOTE.Text);
            }
		}

        internal void MoBanTuDatPhong(string banID)
        {            
            //lựa chọn đặt phòng
            TimKiemDatTruoc form = (TimKiemDatTruoc)Config.CreateForm(Forms.TimKiemDatTruoc);
            form.SetData(banID);
            if (form.No1Form1.ShowDialog() == DialogResult.OK)
            {
                //set customer
                TDATHANGRow dhRow = new TDATHANGRow(form.TDATHANGID);
                TaoMoiHoaDon(dhRow);
            }           
        }


		public void tvCat_CustomLoadData(object sender, CustomLoadDataArgs e)
		{
            e.Where += " AND (DLOAIDOID IS NULL OR DLOAIDOID <> '4')";
		}

		public void dtBATDAUPHONGCUOI_OnEditValueChanged(object sender, object value)
		{
            if (!dtBATDAUPHONGCUOI.IsEmpty)
            {
                if ((GioHatTable?.Rows.Count ?? 0) == 0)
                    SetDonHangField("BATDAU", dtBATDAUPHONGCUOI.DateTime);
                if (sender == dtKETTHUC)
                    SetDonHangField("TUTHAYDOIGIO", 30);

                UpdateTongThoiGian();
            }
		}


		public void lueDBANGGIAID_CustomLoadData(object sender, CustomLoadDataArgs e)
		{
            CachTinhGiaGio cachTinh = (CachTinhGiaGio)GetDonHangInt("CACHTINHGIA", 0);
            //không tải dữ liệu nếu cách tính giá theo giờ
            if (cachTinh == CachTinhGiaGio.THEOGIO)
            {
                e.Where = "0=1";
            }
            else
            {
                DBANRow banRow = new DBANRow(DBANID);
                cachTinh = (CachTinhGiaGio)banRow.CACHTINHGIO;
                //kiểm tra bảng giá theo khu vực hay trực tiếp vào phòng?
                if (e.Where.Length > 0) e.Where += " AND ";
                if (cachTinh == CachTinhGiaGio.THEOKHUVUC)
                {
                    e.Where += "(ID = '" + banRow.DBANGGIAID + "' OR ID IN (SELECT DBANGGIAID FROM DBANGGIATHEOKHUVUC WHERE DKHUVUCID = (SELECT DKHUVUCID FROM DBAN WHERE ID = '" + DBANID + "')))";
                }
                else
                {
                    e.Where += "(ID = '" + banRow.DBANGGIAID + "' OR ID IN (SELECT DBANGGIAID FROM DBANGGIATHEOBAN WHERE DBANID = '" + DBANID + "'))";
                }
            }
		}


		public void lueDBANGGIAID_OnEditValueChanged(object sender, object value)
		{
			//khi thay đổi thì cập nhật lại đơn giá
            UpdateGio();
		}

        public void tmrAutoPrint_Tick(object sender, EventArgs e)
        {
            SoGiay--;
            prAutoPrint.Value = Math.Max(0, SoGiay * 100 / SoGiayTuDongInPhaChe);
            if (SoGiay <= 0)
            {
                ThucHienInCheBien(true);
            }
        }

        public static void GetTiLeGiamTheoKM(Database Db, DateTime now, out decimal giamGiaTienHang, out decimal giamGiaTienGio, out decimal giamGiaTong, out int soPhutKm, out decimal tiLeKmPhutDau)
        {
            giamGiaTienHang = 0;            
            giamGiaTienGio = 0;
            giamGiaTong = 0;
            soPhutKm = 0;
            tiLeKmPhutDau = 0;
            DataTable dtKM = GetKhuyenMaiDangSuDung(Db, now, LOAIHINHKHUYENMAI.GIAMGIATONGBILL);
            foreach (DataRow r in dtKM.Rows)
            {                
                DDOTKHUYENMAIRow kmRow = new DDOTKHUYENMAIRow(r);
                if (kmRow.TILEGIAMGIA > 0 && kmRow.TILEGIAMGIA >= giamGiaTienHang)
                {
                    giamGiaTienHang = kmRow.TILEGIAMGIA;
                }
                if (kmRow.TILEGIAMGIATONG > 0 && kmRow.TILEGIAMGIATONG >= giamGiaTong)
                {
                    giamGiaTong = kmRow.TILEGIAMGIATONG;
                }
                if (kmRow.TILEGIAMGIATIENGIO > 0 && kmRow.TILEGIAMGIATIENGIO >= giamGiaTienGio)
                {
                    giamGiaTienGio = kmRow.TILEGIAMGIATIENGIO;
                }
                if (kmRow.KHUYENMAIGIOHAT > soPhutKm)
                {
                    soPhutKm = kmRow.KHUYENMAIGIOHAT;
                    tiLeKmPhutDau = kmRow.TILEGIAMGIAGIODAU;
                }
            }

            bool gopChung = SystemConfig.GopChungGiamGiaTienGioVaTienHangLamMot == 30;
            if (gopChung && Shared.CoTienGio)
            {               
                if (giamGiaTong == 0)
                {
                    //nếu không có khuyến mại
                    giamGiaTong = Math.Min(SystemConfig.MacDinhGiamGiaTienGio, SystemConfig.MacDinhGiamGia);
                }

                giamGiaTienGio = giamGiaTong;
                giamGiaTienHang = giamGiaTong;
            }
            else
            {
                giamGiaTienGio = Math.Max(giamGiaTienGio, SystemConfig.MacDinhGiamGiaTienGio);
                giamGiaTienHang = Math.Max(giamGiaTienHang, SystemConfig.MacDinhGiamGia);
            }
        }

        private void CapNhatGiamGia(string DKHACHHANGID)
        {
            //lấy tỉ lệ giảm giá theo khuyến mại tự động
            decimal giamGiaTienHang = 0;
            decimal giamGiaTienGio = 0;
            decimal giamGiaTong = 0;
            int soPhutKm = 0;
            decimal tiLeKmPhutDau = 0;
            GetTiLeGiamTheoKM(Config.Db, GetDonHangDateTime("BATDAU", DateTime.Now), out giamGiaTienHang, out giamGiaTienGio, out giamGiaTong, out soPhutKm, out tiLeKmPhutDau);

            if (!string.IsNullOrEmpty(DKHACHHANGID))
            {
                DKHACHHANGRow row = new DKHACHHANGRow(DKHACHHANGID);
                if (row.Row != null && !string.IsNullOrEmpty(row.DNHOMKHACHHANGID))
                {
                    DNHOMKHACHHANGRow nhomRow = new DNHOMKHACHHANGRow(row.DNHOMKHACHHANGID);
                    if (nhomRow.Row != null)
                    {
                        //Cập nhật giảm theo nhóm
                        SetGiamGiaTheoNhom(nhomRow.TILEGIAMDOAN, nhomRow.TILEGIAMDOUONG, nhomRow.TILEGIAMDOKHAC, nhomRow.TILEGIAMDICHVU);
                        if (SystemConfig.GopChungGiamGiaTienGioVaTienHangLamMot == 30)
                        {
                            //Cập nhật giảm giá tổng                    
                            giamGiaTong = Math.Max(giamGiaTong, nhomRow.TILEGIAMGIA);
                        }
                        else
                        {
                            //Cập nhật giảm giá hàng nếu lớn hơn hiện tại                    
                            giamGiaTienHang = Math.Max(giamGiaTienHang, nhomRow.TILEGIAMGIATIENHANG);
                            //Cập nhật giảm giá giờ nếu lớn hơn hiện tại                    
                            giamGiaTienGio = Math.Max(giamGiaTienGio, nhomRow.TILEGIAMGIATIENGIO);
                        }
                    }
                    else
                    {
                        SetGiamGiaTheoNhom(0, 0, 0, 0);
                    }
                }
                else
                {
                    SetGiamGiaTheoNhom(0, 0, 0, 0);
                }
            }
            else
            {
                SetGiamGiaTheoNhom(0, 0, 0, 0);                
            }
            
            if (SystemConfig.GopChungGiamGiaTienGioVaTienHangLamMot == 30)
            {
                numTILEGIAMGIATONG.LockEvent = true;
                numTILEGIAMGIATONG.Value = giamGiaTong;
                numTILEGIAMGIATONG.LockEvent = false;
            }
            else
            {
                numTILEGIAMGIA.LockEvent = true;
                numTILEGIAMGIA.Value = giamGiaTienHang;
                numTILEGIAMGIA.LockEvent = false;
                numTILEGIAMGIAGIO.LockEvent = true;
                numTILEGIAMGIAGIO.Value = giamGiaTienGio;
                numTILEGIAMGIAGIO.LockEvent = false;
            }            
        }

		public void lueDKHACHHANGID_OnEditValueChanged(object sender, object value)
		{
            if (_isLoading) return;
            string khId = lueDKHACHHANGID.StringValue;
            SetDonHangField("DKHACHHANGID", string.IsNullOrEmpty(khId) ? (object)DBNull.Value : khId);
            CapNhatGiamGia(khId);
		}


		public void grMatHang_CustomLoadData(object sender, CustomLoadDataArgs e)
		{
            if (Shared.SapXepTheoMa())
            {
                e.OrderBy = "CODE";
            }            
		}

        private void WriteToCustomerDisplay(string line1, string line2)
        {
            if (!coManHienThi || congSuDung.Length == 0) return;

            SerialPort sp = new SerialPort(congSuDung, 9600, Parity.None, 8, StopBits.One);
            try
            {
                sp.Open();
                // to clear the display
                sp.Write(Convert.ToString((char)12));

                // first line goes here
                string koDau = LoaiBoDauTiengViet(line1).ToUpper();
                if (koDau.Length > 19) koDau = koDau.Substring(0, 19);
                sp.WriteLine(koDau);

                // 2nd line goes here
                sp.WriteLine((char)13 + line2);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (sp.IsOpen)
                    sp.Close();
                sp.Dispose();
            }
            sp = null;
        }

        public static string LoaiBoDauTiengViet(string ip_str_change)
        {
            Regex v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string v_str_FormD = ip_str_change.Normalize(NormalizationForm.FormD);
            return v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToLower();
        }


		public void tsbTraLai_Click(object sender, EventArgs e)
		{
            TraDo form = (TraDo)Config.CreateForm(Forms.TraDo);
            form.BeforeSave += new CancelEventHandler(form_BeforeSave);
            form.SetData(mapper.ID);
            if (form.form.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = form.grTraLai.DataSource as DataTable;
                if (KhongDuocXoaSauKhiInPhaChe())
                {
                    //lấy ra danh sách tên mặt hàng và số lượng
                    Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
                    foreach (DataRow r in dt.Rows)
                    {                        
                        string TenHang = r["TENHANG"].ToString();
                        decimal slTra = ConvertTo.Decimal(r["SLTRALAI"]);
                        if (dic.ContainsKey(TenHang)) dic[TenHang] += slTra;
                        else dic.Add(TenHang, slTra);

                        //TODO: kiểm tra xem đã in chưa?
                    }
                }

                foreach (DataRow r in dt.Rows)
                {                    
                    decimal slTra = ConvertTo.Decimal(r["SLTRALAI"]);
                    if (slTra > 0)
                    {
                        string DMATHANGID = r["DMATHANGID"].ToString();
                        decimal donGia = ConvertTo.Decimal(r["DONGIA"]);
                        decimal tiLeGiam = ConvertTo.Decimal(r["TILEGIAMGIA"]);
                        DMATHANGRow spRow = new DMATHANGRow(DMATHANGID);
                        spRow.NAME = r["TENHANG"].ToString();
                        string DDONVITINHID = r["DDONVITINHID"].ToString();

                        Track(LoaiLuuVet.TraDo, string.Format("Trả lại '{0}', số lượng: {1} đơn giá: {2}", spRow.NAME, slTra, donGia.ToString("n0")), slTra, spRow.GIABAN, spRow.GIABAN * slTra * (1 - tiLeGiam / 100), spRow.NAME);
                        AddItemToGridDirect(spRow, -slTra, donGia, tiLeGiam, "", DDONVITINHID);
                    }
                }
                mapper.RaiseOnCalculation();
            }
		}

        void form_BeforeSave(object sender, CancelEventArgs e)
        {
            DataTable dt = sender as DataTable;
        }


		public void tmrAutoUpdateTime_Tick(object sender, EventArgs e)
		{
            if (btnThanhToan.Visible && btnThanhToan.Enabled && mapper.ID.Length > 0 && !thanhToanShowing)
            {
                UpdateGio();
            }            
		}

        internal void Close()
        {            
            tmrAutoPrint.Enabled = false;
            tmrAutoUpdateTime.Enabled = false;
        }		


		public void btnTamUng_Click(object sender, EventArgs e)
		{
            if (DaThanhToan(true)) return;

            if (mapper.ID.Length > 0)
            {
                TamUngDonHang form = (TamUngDonHang)Config.CreateForm(Forms.TamUngDonHang);
                form.LoadData(mapper.ID, GetDonHangString("TDATHANGID", ""), lblBan.Text);
                form.No1Form1.ShowDialog();
            }
		}


		public void mapper_BeforeSave(object sender, SaveCancelEventArgs e)
		{
            Msg.ShowWarning("Bạn không thể thực hiện chức năng này");
            e.Cancel = true;
		}

        internal static void XuatVatTu(string TDONHANGID, string DKHOHANGID)
        {
            string sql = @"SELECT DVATTUID, MH.GIAVON, 
                            MH.DLOAIMATHANGID,
                            MH.DDONVITINHID, MH.NAME AS TENHANG,
                            SUM(TDONHANGCHITIET.SLXUATCHUAQUYDOI * DDINHLUONG.SOLUONG) AS SOLUONG FROM TDONHANGCHITIET 
                            INNER JOIN DDINHLUONG ON DDINHLUONG.DMATHANGID = TDONHANGCHITIET.DMATHANGID 
                            INNER JOIN DMATHANG ON DMATHANG.ID = TDONHANGCHITIET.DMATHANGID 
                            INNER JOIN DMATHANG MH ON MH.ID = DDINHLUONG.DVATTUID
                            WHERE DMATHANG.DLOAIMATHANGID = '1' AND TDONHANGID = '{0}'
                            GROUP BY DVATTUID, MH.GIAVON, MH.DDONVITINHID, MH.NAME, MH.DLOAIMATHANGID
                            HAVING SUM(TDONHANGCHITIET.SLXUATCHUAQUYDOI * DDINHLUONG.SOLUONG) <> 0";
            sql = string.Format(sql, TDONHANGID);
            //(GUID.Length == 0 ? (" AND TDONHANGID = '" + tDonHangID + "' ") : ("AND TDONHANGID IN (SELECT ID FROM TDONHANG WHERE NHOMGUID = '" + GUID + "') ")) +
            DataTable dtVatTu = Config.Db.GetTable(sql);
            DataRow[] rows = dtVatTu.Select("DLOAIMATHANGID = '1'");
            InsertVatTu(rows, dtVatTu);

            foreach (DataRow r in dtVatTu.Rows)
            {
                //bỏ qua các mặt hàng định lượng
                if (r["DLOAIMATHANGID"].ToString() == "1") continue;
                //cap nhat so luong vao  bang DMATHANG
                TDONHANGCHITIETRow xRow = new TDONHANGCHITIETRow();
                xRow.TDONHANGID = TDONHANGID;
                xRow.XUATVATTU = 30;
                string DVATTUID = r["DVATTUID"].ToString();
                xRow.DMATHANGID = DVATTUID;
                decimal soLuong = ConvertTo.Decimal(r["SOLUONG"]);
                xRow.SLXUATCHUAQUYDOI = soLuong;
                xRow.SLXUAT = soLuong;
                xRow.GIAVON = ConvertTo.Decimal(r["GIAVON"]);
                xRow.DKHOHANGID = DKHOHANGID;
                xRow.DDONVITINHID = r["DDONVITINHID"].ToString();
                xRow.TENHANG = r["TENHANG"].ToString();
                xRow.Update();
            }
        }


		public void tsbDieuChinhGio_Click(object sender, EventArgs e)
		{
			
		}


		public void tsbRefresh_Click(object sender, EventArgs e)
		{
            LoadTrangThaiDichVuTheoGio();
		}

		public void tsbVaoPhong_Click(object sender, EventArgs e)
		{
            if (grNhanVien.SelectedRows.Count > 0)
            {
                DMATHANGRow mhRow = new DMATHANGRow(grNhanVien.SelectedID);
                DoAddItemToGrid(mhRow, 1, false);
            }
            else
            {
                Msg.ShowWarning("Mời bạn chọn dịch vụ trong danh sách trước");
            }
		}

		public void grNhanVien_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                tsbVaoPhong.PerformClick();
            }
		}


		public void tabTongCong_SelectedPageChanged(object sender, EventArgs e)
		{
            if (tabTongCong.SelectedPage == pageNhanVien)
            {
                LoadTrangThaiDichVuTheoGio();
            }
		}

        /// <summary>
        /// Tải lại trạng thái của các mặt hàng dịch vụ theo giờ
        /// </summary>
        private void LoadTrangThaiDichVuTheoGio()
        {
            string sql = @"SELECT ID, NAME, 
                (SELECT FIRST 1 DBAN.NAME FROM DBAN INNER JOIN TDONHANGCHITIET ON DBAN.TDONHANGID = TDONHANGCHITIET.TDONHANGID
AND DMATHANGID = DMATHANG.ID) AS PHONG,
                (SELECT COUNT(DISTINCT TDONHANG.ID) FROM TDONHANG 
                INNER JOIN TDONHANGCHITIET ON TDONHANG.ID = TDONHANGCHITIET.TDONHANGID
                WHERE DMATHANGID = DMATHANG.ID
                AND NGAY = @NGAY
                ) AS SOLAN
FROM DMATHANG
WHERE STATUS = 30
AND DLOAIMATHANGID = '7'
ORDER BY NAME";
            FbCommand cmd = Config.Db.GetCommand(sql);
            cmd.Parameters.Add("@NGAY", FbDbType.Date).Value = Shared.GetNgayGiaoDich(Config.Db);
            DataTable dt = Config.Db.GetTable(cmd);
            grNhanVien.DataSource = dt;

            tsbVaoPhong.Enabled = grNhanVien.SelectedRows.Count > 0 && btnThanhToan.Enabled;
        }


		public void grNhanVien_SelectionChanged(object sender, EventArgs e)
		{
            UpdateButtonVaoPhong();
		}

        private void UpdateButtonVaoPhong()
        {
            tsbVaoPhong.Enabled = grNhanVien.SelectedRows.Count > 0 && btnThanhToan.Enabled;
        }

		public void grNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
            try
            {
                DataRow r = (grNhanVien.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                string Phong = r["PHONG"].ToString();
                if (Phong.Length > 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionBackColor = Color.Red;
                }
            }
            catch
            {
            }
		}
    }
}
