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
using Forms = QuanLyNhaHang.Forms.Forms;
using Tables = QuanLyNhaHang.Forms.Tables;
using Functions = QuanLyNhaHang.Forms.Functions;
using Menus = QuanLyNhaHang.Forms.Menus;
using Shared = QuanLyNhaHang.Forms.Shared;
using SystemConfig = QuanLyNhaHang.Services.SystemConfig;
using Config = No1Run.Config;
using QuanLyBanHang = QuanLyNhaHang.Forms.QuanLyBanHang;

namespace No1Run
{
    public partial class QuanLyBanHangNhaHang : No1Lib.Sys.No1UserControl, IRefreshable
    {
        public No1Lib.Sys.No1UserControl No1UserControl1 { get { return this; } }

        public QuanLyBanHangNhaHang()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Thông tin đơn hàng đang chọn
        /// </summary>
        public TDONHANG0Ae donHang;

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void dtNgay_OnEditValueChanged(object sender, object value)
        {
            LoadData();
        }

        public void grMain_CustomLoadData(object sender, CustomLoadDataArgs e)
        {
            e.And("TDONHANG.NGAY >= @FromDate AND TDONHANG.NGAY <= @ToDate");
            e.Command.Parameters.Add("@FromDate", FbDbType.Date).Value = dtNgay.TuNgay.Date;
            e.Command.Parameters.Add("@ToDate", FbDbType.Date).Value = dtNgay.DenNgay.Date;
            
            e.OrderBy = "NGAY, GIOTHANHTOAN";
        }

        public void grMain_SelectionChanged(object sender, EventArgs e)
        {
            tmrLoad.Enabled = false;
            tmrLoad.Enabled = true;

            btnHuyPhieu.Enabled = grMain.SelectedID.Length > 0;
        }

        public void tmrLoad_Tick(object sender, EventArgs e)
        {
            tmrLoad.Enabled = false;
            if (donHang != null)
            {
                donHang.Reload(grMain.SelectedID, "");
                donHang.No1UserControl1.Enabled = grMain.SelectedID.Length > 0;
            }
        }

        private bool userMovedSplitter = false;

        private void QuanLyBanHangNhaHang_Resize(object sender, EventArgs e)
        {
            if (!userMovedSplitter && this.Width > 200)
            {
                try
                {
                    KryptonSplitContainer1.SplitterDistance = this.Width / 2;
                }
                catch { }
            }
        }

        public void No1UserControl1_OnInit(object sender, EventArgs e)
        {
            TDONHANG0Ae.EnsureNo1LibInitialized();

            DateTime toDay = Shared.GetNgayGiaoDich(Config.Db);
            dtNgay.FromDate = toDay;
            dtNgay.ToDate = toDay;

            donHang = (TDONHANG0Ae)Config.CreateForm(Forms.TDONHANG0Ae);
            donHang.Mode = (No1UserControl1.CallerMenuID != null && No1UserControl1.CallerMenuID.ID == Menus.DieuChinhHoaDon) ? HoaDonMode.DieuChinhHoaDon : HoaDonMode.QuanLyBanHang;
            donHang.No1UserControl1.Dock = DockStyle.Fill;
            donHang.mapper_OnLoad(null, EventArgs.Empty);
            if (donHang.Mode == HoaDonMode.DieuChinhHoaDon)
            {
                btnHuyPhieu.Visible = false;
                dtNgay.Enabled = false;
            }
            KryptonSplitContainer1.Panel2.Controls.Add(donHang.No1UserControl1);

            if (this.Width > 200)
            {
                try { KryptonSplitContainer1.SplitterDistance = this.Width / 2; } catch { }
            }
            this.Resize += QuanLyBanHangNhaHang_Resize;
            this.KryptonSplitContainer1.SplitterMoved += (s, ev) => { userMovedSplitter = true; };

            LoadData();
        }

        int lastRefresh;
        /// <summary>
        /// Tải dữ liệu lên lưới
        /// </summary>
        private void LoadData()
        {
            lastRefresh = Environment.TickCount;
            grMain.LoadData();

            FormatTimeColumn(grMain, "BATDAU");
            FormatTimeColumn(grMain, "KETTHUC");
            FormatTimeColumn(grMain, "GIOTHANHTOAN");
            ConfigureColumnsOrder();

            if (grMain.SelectedID.Length == 0)
            {
                if (donHang != null && donHang.No1UserControl1 != null)
                {
                    donHang.No1UserControl1.Enabled = false;
                }
                btnHuyPhieu.Enabled = false;
            }
            else
            {
                if (donHang != null && donHang.No1UserControl1 != null)
                {
                    donHang.Reload(grMain.SelectedID, "");
                    donHang.No1UserControl1.Enabled = true;
                }
                btnHuyPhieu.Enabled = true;
            }
        }

        private void ConfigureColumnsOrder()
        {
            string[] cols = new string[] {
                "NAME",             // Số phiếu
                "NGAY",             // Ngày
                "DBAN_NAME",        // Bàn
                "BATDAU",           // Bắt đầu
                "KETTHUC",          // Kết thúc
                "GIOTHANHTOAN",     // Giờ thanh toán
                "TONGCONG",         // Tổng cộng
                "DKHACHHANG_NAME",  // Khách hàng
                "TIENGIAMGIA",      // Tiền giảm giá
                "TILEGIAMGIA",      // Tỉ lệ giảm giá
                "TIENHANG"          // Tiền hàng
            };

            int[] widths = new int[] {
                75,  // Số phiếu
                75,  // Ngày
                60,  // Bàn
                50,  // Bắt đầu
                50,  // Kết thúc
                65,  // Giờ thanh toán
                75,  // Tổng cộng
                85,  // Khách hàng
                55,  // Tiền giảm giá
                50,  // Tỉ lệ giảm giá
                75   // Tiền hàng
            };

            for (int i = 0; i < cols.Length; i++)
            {
                string colName = cols[i];
                if (grMain.Columns.Contains(colName))
                {
                    grMain.Columns[colName].DisplayIndex = i;
                    if (widths[i] > 0)
                    {
                        grMain.Columns[colName].Width = widths[i];
                    }
                }
            }

            if (grMain.Columns.Contains("NGAY"))
                grMain.Columns["NGAY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (grMain.Columns.Contains("BATDAU"))
                grMain.Columns["BATDAU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (grMain.Columns.Contains("KETTHUC"))
                grMain.Columns["KETTHUC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (grMain.Columns.Contains("GIOTHANHTOAN"))
                grMain.Columns["GIOTHANHTOAN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (grMain.Columns.Contains("TONGCONG"))
                grMain.Columns["TONGCONG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (grMain.Columns.Contains("TIENGIAMGIA"))
                grMain.Columns["TIENGIAMGIA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (grMain.Columns.Contains("TILEGIAMGIA"))
                grMain.Columns["TILEGIAMGIA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (grMain.Columns.Contains("TIENHANG"))
                grMain.Columns["TIENHANG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        internal static void FormatTimeColumn(DataGridView grMain, string colName)
        {
            CalendarColumn col = grMain.Columns[colName] as CalendarColumn;
            if (col == null) return;
            col.Format = "HH:mm";
        }

        public void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            //kiểm tra quyền xem có được hủy không?
            if (!DbUtils.CanLogin(Functions.HuyHoaDon))
            {
                return;
            }

            string ID = grMain.SelectedID;

            string LyDo = "";
            //nhập lý do hủy
            if (SystemConfig.NhapLyDoKhiHuyHoaDon == 30)
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
                LyDo = "Hủy hóa đơn";
                if (Msg.ShowYesNo("Bạn có muỗn hủy hóa đơn số '" + new TDONHANGRow(ID).NAME + "' không?") != DialogResult.Yes)
                {
                    return;
                }
            }
            QuanLyBanHang.HuyBill(ID, LyDo);

            LoadData();
        }

        #region IRefreshable Members

        public new void DoRefresh()
        {
            if (Config.NeedRefresh(Tables.TDONHANG, lastRefresh))
            {
                LoadData();
            }
        }

        #endregion
    }
}

namespace QuanLyNhaHang.Forms
{
    public class QuanLyBanHangNhaHang : No1Run.QuanLyBanHangNhaHang
    {
    }
}
