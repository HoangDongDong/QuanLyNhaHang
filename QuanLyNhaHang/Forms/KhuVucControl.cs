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
using System.Drawing.Imaging;
using QuanLyNhaHang.Services;
using GiaMatHang = No1Run.GiaMatHang;

namespace QuanLyNhaHang.Forms
{
    public partial class KhuVucControl : No1Lib.Sys.No1UserControl
    {
        public delegate void OnThayDoiBanHandler(KhuVucControl control, string banID);
        public delegate string OnThayDoiBanExHandler(KhuVucControl control, string banID);
        public event OnThayDoiBanExHandler OnThayDoiBan;
        public event OnThayDoiBanHandler OnForceThayDoiBan;
        public event OnThayDoiBanHandler OnRequireStartByBooking;
        public event OnThayDoiBanHandler OnRequireStart;
        public event OnThayDoiBanHandler OnChuyenBanRequest;
        public event OnThayDoiBanHandler OnGopBanRequest;
        public event OnThayDoiBanHandler OnNgatGioRequest;
        public event EventHandler OnThanhToanRequire;

        public Control No1UserControl1 => this;

        bool showMinute = false;

        public KhuVucControl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            lst.View = View.LargeIcon;

            mởBànToolStripMenuItem.Text = mởBànToolStripMenuItem.Text.Replace("phòng", Shared.GetTenPhongBan(true));
            mởBànTừĐặtToolStripMenuItem.Text = mởBànTừĐặtToolStripMenuItem.Text.Replace("phòng", Shared.GetTenPhongBan(true));

            ImageList iList = new ImageList();

            int kichThuoc = SystemConfig.KichThuocHienThiOGiaoDienDichVu;
            int W = kichThuoc == 1 ? 48 : (kichThuoc == 2 ? 32 : (kichThuoc == 3 ? 24 : 64));
            if (kichThuoc >= 2)
            {
                lst.Font = new Font(lst.Font.FontFamily, 9, FontStyle.Bold);
            }
            showMinute = W == 64;

            iList.ImageSize = new Size(W, W);
            iList.ColorDepth = ColorDepth.Depth32Bit;

            lst.LargeImageList = iList;

            if (!Shared.CoTienGio)
            {
                chuyểnBànToolStripMenuItem.Text = "Chuyển " + Shared.GetTenPhongBan(true);
                gộpBànToolStripMenuItem.Text = "Gộp " + Shared.GetTenPhongBan(true);
            }

            if (!Shared.CoNgatGio)
            {
                ngắtGiờToolStripMenuItem.Visible = false;
            }

            No1UserControl1.Tag = this;
        }

        internal bool SelectTable(string DBANID)
        {
            foreach (BanItem itm in lst.Items)
            {
                string ID = itm.ID;
                if (ID == DBANID)
                {
                    lst.SelectedItems.Clear();
                    lst.Select();
                    itm.Selected = true;
                    lst.FocusedItem = itm;
                    lst.EnsureVisible(itm.Index);
                    if (OnThayDoiBan != null) OnThayDoiBan(this, DBANID);
                    return true;
                }
            }
            return false;
        }

        public void SetChuyenBan()
        {
            lst.ContextMenuStrip = null;
        }

        public void mởBànTừĐặtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnRequireStartByBooking != null) OnRequireStartByBooking(this, BanID);
        }

        /// <summary>
        /// Lấy danh sách bàn kèm trạng thái
        /// </summary>
        /// <param name="db">Kết nối sử dụng để lấy dữ liệu</param>
        /// <returns></returns>
        internal static DataTable LayDanhSachBan(Database db, string ID)
        {
            string sql = @"SELECT DBAN.ID, DBAN.NAME,
                        TDONHANG.BATDAU, TRANGTHAI, TDONHANG.KETTHUC,                        
                        (SELECT COUNT(*) FROM TSUACHUA WHERE DASUAXONG = 0 AND DBANID = DBAN.ID) AS SUACHUA,
                        (SELECT NAME FROM DNHOMHIENTHI WHERE ID = DNHOMHIENTHIID) AS NHOM,
                        CASE WHEN EXISTS (SELECT * FROM TDATHANG WHERE DBANID = DBAN.ID AND TUNGAY = CURRENT_DATE) THEN 1 ELSE 0 END AS DATHANG,
                        TDONHANG.NOTE AS NOTE, CASE WHEN TDONHANG.ID IS NULL THEN 0 ELSE 1 END AS DANGSUDUNG, 
                        COALESCE(SOLANINTAMTINH, 0) AS SOLANINTAMTINH
                        FROM DBAN INNER JOIN DKHUVUC ON DKHUVUC.ID = '{0}' AND DKHUVUC.ID = DBAN.DKHUVUCID 
                        AND DBAN.STATUS = 30 
                        AND DKHUVUC.STATUS = 30 
                        LEFT OUTER JOIN TDONHANG ON DBAN.TDONHANGID = TDONHANG.ID AND DATHANHTOAN = 0
                        ORDER BY DBAN.NAME";
            sql = string.Format(sql, ID);
            return db.GetTable(sql);
        }

        BackgroundWorker bw;
        DataTable dtRefresh;
        internal void RefreshStatus()
        {
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dtRefresh == null) return;
            //tải lại dữ liệu lên bàn
            loading = true;

            try
            {
                bool hienThiGhiChu = SystemConfig.HienThiGhiChuTrenGiaoDienBan == 30;
                try
                {
                    bool hasChanged = false;
                    foreach (BanItem itm in lst.Items)
                    {
                        DataRow[] rows = dtRefresh.Select("ID='" + itm.ID + "'");
                        if (rows.Length > 0)
                        {
                            DataRow r = rows[0];
                            if (SetItemInfo(new DBANRow(rows[0]), itm, hienThiGhiChu))
                            {
                                hasChanged = true;
                            }
                        }
                    }

                    if (hasChanged)
                        lst.Invalidate();
                }
                catch
                {
                }
            }
            catch
            {
            }
            bw.Dispose();

            loading = false;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtRefresh = null;
                Database db = Config.Db.Copy();
                if (db.TryConnect())
                {
                    dtRefresh = LayDanhSachBan(db, ID);
                }
                db.Disconnect();
            }
            catch { }
        }

        internal void ClearSelection()
        {
            lst.lockChanged = true;
            if (lst.FocusedItem != null) lst.FocusedItem.Focused = false;
            lst.SelectedItems.Clear();
            lst.lockChanged = false;
        }

        bool loading = false;
        public void RefreshData()
        {
            loading = true;
            lst.BeginUpdate();
            string selectedBanId = this.BanID;
            BanItem focusedItem = lst.FocusedItem as BanItem;
            bool hienThiGhiChu = SystemConfig.HienThiGhiChuTrenGiaoDienBan == 30;
            try
            {
                lst.Items.Clear();
                lst.Groups.Clear();

                Dictionary<string, ListViewGroup> dic = new Dictionary<string, ListViewGroup>();
                DataTable dt = LayDanhSachBan(Config.Db, ID);

                foreach (DataRow r in dt.Rows)
                {
                    DBANRow banRow = new DBANRow(r);
                    BanItem itm = new BanItem(banRow.ID, Icon, IconGray);

                    SetItemInfo(banRow, itm, hienThiGhiChu);

                    ListViewGroup group;
                    string groupName = r["NHOM"].ToString().Trim();
                    if (groupName.Length > 0)
                    {
                        if (dic.ContainsKey(groupName.ToLower()))
                        {
                            group = dic[groupName.ToLower()];
                        }
                        else
                        {
                            group = new ListViewGroup(groupName);
                            lst.Groups.Add(group);
                            dic.Add(groupName.ToLower(), group);
                        }
                        itm.Group = group;
                    }

                    lst.Items.Add(itm);

                    if ((!string.IsNullOrEmpty(selectedBanId) && selectedBanId == banRow.ID) ||
                        (focusedItem != null && focusedItem.ID == banRow.ID))
                    {
                        itm.Focused = true;
                        itm.Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.ShowError("Lỗi khi tải dữ liệu, " + ex.Message);
            }

            lst.EndUpdate();
            loading = false;
        }

        internal bool SetItemInfo(DBANRow banRow, BanItem itm, bool hienThiGhiChu)
        {
            //tính toán trạng thái phòng
            TrangThaiBan trangThai;

            bool CoSuaChua = ConvertTo.Int(banRow["SUACHUA"]) > 0;
            int TrangThai = ConvertTo.Int(banRow["TRANGTHAI"]);
            bool DaInTamTinh = ConvertTo.Int(banRow["SOLANINTAMTINH"]) > 0;
            bool DangSuDung = ConvertTo.Int(banRow["DANGSUDUNG"]) > 0;

            if (DangSuDung)
            {
                trangThai = DaInTamTinh ? TrangThaiBan.INTAMTINH : TrangThaiBan.SUDUNG;
            }
            else
            {
                if (TrangThai == 1) trangThai = TrangThaiBan.BAODON;
                else if (TrangThai == 2) trangThai = TrangThaiBan.DONDEP;
                else if (CoSuaChua) trangThai = TrangThaiBan.SUACHUA;
                else trangThai = TrangThaiBan.TRONG;
            }

            DateTime batDau = ConvertTo.Date(banRow["BATDAU"]);
            DateTime ketThuc = ConvertTo.Date(banRow["KETTHUC"]);
            if (ketThuc < DateTime.Now) ketThuc = DateTime.Now;
            string ghiChu = hienThiGhiChu ? banRow.NOTE : "";

            if (banRow.NAME != itm.TenBan || itm.GhiChu != ghiChu ||
                itm.BatDau != batDau || (itm.KetThuc != ketThuc && showMinute) || itm.TrangThai != trangThai)
            {
                itm.TenBan = banRow.NAME;
                itm.GhiChu = ghiChu;
                itm.BatDau = batDau;
                itm.KetThuc = ketThuc;
                itm.Text = banRow.NAME;
                itm.TrangThai = trangThai;
                return true;
            }
            return false;
        }

        public Image Icon;
        public Image IconGray;

        public string ID;
        public GiaMatHang GiaMatHang;
        public void SetData(DKHUVUCRow r)
        {
            this.ID = r.ID;
            this.GiaMatHang = (GiaMatHang)ConvertTo.Int(r.DGIAMATHANGID);
            object ImageArray = r["BIEUTUONG"];
            if (ImageArray is byte[])
            {
                byte[] Array = ImageArray as byte[];
                Icon = ConvertTo.Image(Array);
                IconGray = MakeGrayscale3(Icon);
            }
        }

        public static Bitmap MakeGrayscale3(Image original)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBitmap);

            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            g.Dispose();
            return newBitmap;
        }

        public void lst_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            (e.Item as BanItem).DrawItem(e);
        }

        public void mởBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BanID.Length > 0)
            {
                if (OnRequireStart != null)
                {
                    OnRequireStart(this, BanID);
                }
            }
        }

        public void chuyểnBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnChuyenBanRequest != null) OnChuyenBanRequest(this, DONHANGID);
        }

        public void lst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem itm = lst.GetItemAt(e.X, e.Y);
            if (itm != null && OnRequireStart != null)
            {
                OnRequireStart(this, BanID);
            }
        }

        private string DONHANGID
        {
            get
            {
                return No1Run.TDONHANG0Ae.GetHoaDonTrenBan(BanID);
            }
        }

        public void hủyHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //kiểm tra quyền xem có được hủy không?
            if (!DbUtils.CanLogin(Functions.HuyHoaDon))
            {
                return;
            }

            string ID = DONHANGID;
            if (ID.Length == 0)
            {
                Msg.ShowWarning("Dữ liệu đã thay đổi!");
                RefreshData();
            }
            else
            {
                //kiểm tra xem đã quá thời gian chưa
                if (!CoTheHuyHoaDon(ID)) return;

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
                    if (Msg.ShowYesNo(string.Format("Bạn có muỗn hủy hóa đơn trên {0} '", Shared.GetTenPhongBan(true)) + new DBANRow(BanID).NAME + "' không?") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                QuanLyBanHang.HuyBill(ID, LyDo);
                RefreshData();
                if (OnThayDoiBan != null) OnThayDoiBan(this, "");
            }
        }

        internal static bool CoTheHuyHoaDon(string ID)
        {
            TDONHANGRow row = new TDONHANGRow(ID);

            DateTime now = Config.Db.DbDateTime;
            TimeSpan sp = now - row.BATDAU;

            if (row.DATHANHTOAN == 30)
            {
                Msg.ShowWarning("Hóa đơn này đã thanh toán, không thể hủy");
                return false;
            }

            if (Math.Abs(sp.TotalMinutes) > SystemConfig.ThoiGianChoPhepHuyBill)
            {
                Msg.ShowWarning("Không được phép hủy hóa đơn có thời gian lớn hơn " + SystemConfig.ThoiGianChoPhepHuyBill.ToString() + " phút");
                return false;
            }

            //kiem tra xem co chuyen phong chua
            if (row.NHOMGUID.Length > 0)
            {
                Msg.ShowWarning("Không thể hủy hóa đơn này");
                return false;
            }
            return true;
        }

        public void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnThanhToanRequire != null) OnThanhToanRequire(this, e);
        }

        public void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void ngắtGiờToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnNgatGioRequest != null)
            {
                OnNgatGioRequest(this, BanID);
            }
        }

        public void gộpBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnGopBanRequest != null) OnGopBanRequest(this, DONHANGID);
        }

        public string BanID
        {
            get
            {
                if (lst.SelectedItems.Count > 0)
                    return (lst.SelectedItems[0] as BanItem)?.ID ?? "";
                return lst.FocusedItem == null ? "" : (lst.FocusedItem as BanItem).ID;
            }
        }

        public void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            string banId = BanID;
            if (string.IsNullOrEmpty(banId)) return;
            if (OnThayDoiBan != null)
            {
                string TDONHANGID = OnThayDoiBan(this, banId);
                BanItem itm = (lst.SelectedItems.Count > 0 ? lst.SelectedItems[0] as BanItem : null) ?? (lst.FocusedItem as BanItem);
                if (itm != null)
                {
                    TrangThaiBan newStatus = TDONHANGID.Length > 0 ? TrangThaiBan.SUDUNG : TrangThaiBan.TRONG;
                    if (itm.TrangThai != newStatus)
                    {
                        itm.TrangThai = newStatus;
                        lst.Invalidate();
                    }
                }
            }
        }

        public void mnu_Opening(object sender, CancelEventArgs e)
        {
            //cập nhật trạng thái lên menu
            bool selected = lst.SelectedItems.Count > 0;

            bool enable = CoTheThanhToan();
            hủyHóaĐơnToolStripMenuItem.Enabled = enable;
            gộpBànToolStripMenuItem.Enabled = enable;
            thanhToánToolStripMenuItem.Enabled = enable;
            chuyểnBànToolStripMenuItem.Enabled = enable;
            ngắtGiờToolStripMenuItem.Enabled = enable;

            bool coTheMoBan = CoTheMoBan();
            mởBànToolStripMenuItem.Enabled = coTheMoBan;
            mởBànTừĐặtToolStripMenuItem.Enabled = coTheMoBan;
        }

        private bool CoTheThanhToan()
        {
            if (lst.FocusedItem == null) return false;
            BanItem item = lst.FocusedItem as BanItem;
            return item.TrangThai == TrangThaiBan.SUDUNG || item.TrangThai == TrangThaiBan.INTAMTINH;
        }

        private bool CoTheMoBan()
        {
            if (lst.FocusedItem == null) return false;
            BanItem item = lst.FocusedItem as BanItem;
            return item.TrangThai != TrangThaiBan.INTAMTINH && item.TrangThai != TrangThaiBan.SUDUNG;
        }

        public void lst_ItemDrag(object sender, ItemDragEventArgs e)
        {
            string donhang = DONHANGID;
            if (e.Button == MouseButtons.Left && donhang.Length > 0)
            {
                DragInfo data = new DragInfo();
                data.DBANID = (e.Item as BanItem).ID;
                data.Source = this;
                data.TDONHANGID = donhang;
                data.TENBAN = (e.Item as BanItem).TenBan;
                lst.DoDragDrop(data, DragDropEffects.Move);
            }
        }

        public void lst_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = lst.PointToClient(new Point(e.X, e.Y));
            BanItem itm = lst.GetItemAt(pt.X, pt.Y) as BanItem;
            if (itm == null) return;

            object data = e.Data.GetData(typeof(DragInfo));
            if (data != null)
            {
                DragInfo info = data as DragInfo;

                TDONHANGRow dhRow = new TDONHANGRow(info.TDONHANGID);
                if (dhRow.DATHANHTOAN == 30) return;

                string DBANID = itm.ID;

                try
                {
                    if (No1Run.ChuyenBan.ChuyenGopBan(info.TDONHANGID, DBANID))
                    {
                        this.RefreshData();
                        info.Source.RefreshData();
                        if (OnForceThayDoiBan != null) OnForceThayDoiBan(this, DBANID);
                    }
                }
                catch (Exception ex)
                {
                    Msg.ShowError("Có lỗi xảy ra trong quá trình chuyển " + Shared.GetTenPhongBan(true) + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }
        }

        public void lst_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            Point pt = lst.PointToClient(new Point(e.X, e.Y));
            BanItem itm = lst.GetItemAt(pt.X, pt.Y) as BanItem;
            if (itm == null) return;

            object data = e.Data.GetData(typeof(DragInfo));
            if (data != null)
            {
                DragInfo info = data as DragInfo;
                if (info.DBANID != itm.ID)
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        class DragInfo
        {
            public KhuVucControl Source;
            public string TDONHANGID;
            public string DBANID;
            public string TENBAN;
        }

        internal void SetNote(string Note)
        {
            if (lst.FocusedItem == null) return;
            (lst.FocusedItem as BanItem).GhiChu = Note;
            lst.Invalidate();
        }
    }

    public class BanItem : ListViewItem
    {
        public string ID { get; set; }
        public string TenBan { get; set; }
        public string GhiChu { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public TrangThaiBan TrangThai { get; set; }
        public Image Icon { get; set; }
        public Image IconGray { get; set; }

        public BanItem(string id, Image icon, Image iconGray)
        {
            this.ID = id;
            this.Icon = icon;
            this.IconGray = iconGray;
            this.Text = "";
        }

        public void DrawItem(DrawListViewItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = e.Bounds;

            Color backColor;
            Color borderColor;
            Color textColor = Color.Black;

            switch (TrangThai)
            {
                case TrangThaiBan.SUDUNG:
                    backColor = Color.FromArgb(255, 238, 204);
                    borderColor = Color.FromArgb(245, 130, 32);
                    break;
                case TrangThaiBan.INTAMTINH:
                    backColor = Color.FromArgb(255, 224, 224);
                    borderColor = Color.FromArgb(237, 28, 36);
                    break;
                case TrangThaiBan.BAODON:
                case TrangThaiBan.DONDEP:
                    backColor = Color.FromArgb(225, 240, 255);
                    borderColor = Color.FromArgb(0, 162, 232);
                    break;
                case TrangThaiBan.SUACHUA:
                    backColor = Color.FromArgb(238, 238, 238);
                    borderColor = Color.FromArgb(140, 140, 140);
                    break;
                default:
                    backColor = Color.FromArgb(250, 250, 250);
                    borderColor = Color.FromArgb(215, 220, 228);
                    break;
            }

            if (e.Item.Selected)
            {
                borderColor = Color.FromArgb(0, 120, 215);
                backColor = Color.FromArgb(204, 232, 255);
            }

            using (SolidBrush bgBrush = new SolidBrush(backColor))
            {
                g.FillRectangle(bgBrush, bounds);
            }

            using (Pen pen = new Pen(borderColor, e.Item.Selected ? 2 : 1))
            {
                Rectangle rectBorder = new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width - 4, bounds.Height - 4);
                g.DrawRectangle(pen, rectBorder);
            }

            Image imgToDraw = (TrangThai == TrangThaiBan.TRONG || TrangThai == TrangThaiBan.SUACHUA) ? (IconGray ?? Icon) : (Icon ?? IconGray);
            int imgSize = 48;
            if (imgToDraw != null)
            {
                imgSize = Math.Min(Math.Min(imgToDraw.Width, bounds.Width - 16), 48);
                int imgX = bounds.X + (bounds.Width - imgSize) / 2;
                int imgY = bounds.Y + 8;
                g.DrawImage(imgToDraw, new Rectangle(imgX, imgY, imgSize, imgSize));
            }

            string name = string.IsNullOrEmpty(TenBan) ? this.Text : TenBan;
            using (Font font = new Font(e.Item.ListView.Font.FontFamily, 9.5f, FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Near,
                    Trimming = StringTrimming.EllipsisCharacter
                };

                int textY = bounds.Y + imgSize + 10;
                Rectangle textRect = new Rectangle(bounds.X + 4, textY, bounds.Width - 8, 20);
                g.DrawString(name, font, textBrush, textRect, sf);

                if (!string.IsNullOrEmpty(GhiChu))
                {
                    using (Font noteFont = new Font(e.Item.ListView.Font.FontFamily, 7.5f, FontStyle.Italic))
                    using (SolidBrush noteBrush = new SolidBrush(Color.FromArgb(100, 100, 100)))
                    {
                        Rectangle noteRect = new Rectangle(bounds.X + 4, textY + 20, bounds.Width - 8, 16);
                        g.DrawString(GhiChu, noteFont, noteBrush, noteRect, sf);
                    }
                }
                else if (TrangThai == TrangThaiBan.SUDUNG || TrangThai == TrangThaiBan.INTAMTINH)
                {
                    TimeSpan sp = (KetThuc > BatDau) ? (KetThuc - BatDau) : (DateTime.Now - BatDau);
                    string timeStr = string.Format("{0:00}:{1:00}", (int)sp.TotalHours, sp.Minutes);
                    using (Font timeFont = new Font(e.Item.ListView.Font.FontFamily, 8f, FontStyle.Regular))
                    using (SolidBrush timeBrush = new SolidBrush(Color.FromArgb(200, 50, 50)))
                    {
                        Rectangle timeRect = new Rectangle(bounds.X + 4, textY + 20, bounds.Width - 8, 16);
                        g.DrawString(timeStr, timeFont, timeBrush, timeRect, sf);
                    }
                }
            }

            if (e.Item.Focused)
            {
                ControlPaint.DrawFocusRectangle(g, bounds);
            }
        }
    }

    public enum TrangThaiBan
    {
        TRONG = 0,
        SUDUNG = 1,
        INTAMTINH = 2,
        BAODON = 3,
        DONDEP = 4,
        SUACHUA = 5
    }



    public static class Shared
    {
        public static string GetTenPhongBan(bool lower = false) => SystemConfig.TenPhongBan;
        public static bool CoTienGio => SystemConfig.CoTienGio;
        public static bool CoNgatGio => SystemConfig.CoNgatGio;

        public static bool DuLieuHoaDonOk(Database db, string tdonhangid, bool checkChiTiet, ref string thongBao)
        {
            thongBao = "";
            return true;
        }

        public static DateTime GetNgayGiaoDich(Database db = null)
        {
            return DateTime.Today;
        }

        public static bool SapXepTheoMa() => false;

        public static decimal TinhGia(No1Run.CachTinhGiaGio cachTinh, string dbangGiaId, decimal donGia, DateTime tuGio, DateTime denGio, DateTime gioBatDauBill, int phutKm, decimal tiLeKm, List<No1Run.ChiTietTinhGiaGio> lst, decimal tienMoBan) => 0;
        public static No1Run.SoHoaDonQuayVong SoHDQuayVong => (No1Run.SoHoaDonQuayVong)SystemConfig.SoHoaDonQuayVong;
        public static No1Run.NgayGiaoDichMode NgayGiaoDich => No1Run.NgayGiaoDichMode.TheoNgayHienTai;
        public static void BatDen(string banId) { }
        public static void TatDen(string banId) { }
        public static string DCUAHANGID => "";
        public static No1Run.UngDung UngDung => No1Run.UngDung.NhaHang;
    }

    public static class Functions
    {
        public const string HuyHoaDon = "HuyHoaDon";
        public const string ChuyenBan = "ChuyenBan";
        public const string GopBan = "GopBan";
        public const string ThanhToan = "ThanhToan";
        public const string InTamTinh = "InTamTinh";
        public const string ChuyenMatHangSangHoaDonKhac = "ChuyenMatHangSangHoaDonKhac";
        public const string DuocGiamDoSauKhiInTamTinh = "DuocGiamDoSauKhiInTamTinh";
        public const string GiamGiaMatHang = "GiamGiaMatHang";
        public const string InLaiBill = "InLaiBill";
        public const string QuanLyBanHang = "QuanLyBanHang";
        public const string SuaDonGia = "SuaDonGia";
        public const string ThayDoiGiamGiaTongHoaDon = "ThayDoiGiamGiaTongHoaDon";
        public const string ThayDoiKhachHangTrongDieuChinhHoaDon = "ThayDoiKhachHangTrongDieuChinhHoaDon";
        public const string ThayDoiPhiDichVu = "ThayDoiPhiDichVu";
        public const string ThongKeTrongSuDungDichVu = "ThongKeTrongSuDungDichVu";
        public const string XemThongKeCuaCacCaiKhoanKhac = "XemThongKeCuaCacCaiKhoanKhac";
        public const string XemThongKeCuaCacTaiKhoanKhac = "XemThongKeCuaCacTaiKhoanKhac";
        public const string XemDonGiaTrongHoaDonBanHang = "XemDonGiaTrongHoaDonBanHang";
        public const string XoaGiamMonSauKhiInCheBien = "XoaGiamMonSauKhiInCheBien";
        public const string XemGiaNhap = "XemGiaNhap";
        public const string DieuChinhGioTinhLuongDichVuTheoGio = "DieuChinhGioTinhLuongDichVuTheoGio";
        public const string KhachHangThanThiet = "KhachHangThanThiet";
    }

    public static class Forms
    {
        public const string NhapLyDo = "f188b753-918a-489a-b52b-808f4386d3cb";
        public const string NhapSoLuongNhaHang = "d84739f1-cd1b-4f07-b9a5-03a89876d97e";
        public const string XacNhanThanhToan = "96f6da47-1d5f-48b3-bf07-35bfbece457a";
        public const string NhapCoupon = "b631d7c1-7df3-40ac-8eaa-e8d6ca6615b9";
        public const string NhapTheTraTruoc = "abaada83-8045-4b4f-88c0-c3d530ee4c13";
        public const string TruTichLuy = "1b396df2-db94-44e2-bd70-86dbf39544f0";
        public const string InXuongBepControl = "d4139d75-c418-4c2c-9d3b-676979b56390";
        public const string InCheBien = "c4a05471-cc31-42ad-91a8-473d9917735f";
        public const string ChonMayIn = "fb0cc7b1-c404-4ad5-811b-a0c3aa4a9f7c";
        public const string DoiGiaBan = "9ee7c4ee-4d45-447a-bbfb-c957eb59ab1e";
        public const string DatGhiChu = "14e3d5ea-0ed0-44da-85ae-da6e4ff74be5";
        public const string DatGiamGia = "eb4a9813-cf3d-4c30-b899-f4b128a960a8";
        public const string ThemMatHangMo = "9e1a9bc5-c827-4c3b-86c8-18011b54310c";
        public const string TraDo = "2b21d0a9-d69b-4d0b-a926-2848ef10a3aa";
        public const string ChonBan = "c7d23a41-1122-3344-5566-778899aabbcc";
        public const string ChonKhachHangQuaThe = "d8e34b52-2233-4455-6677-8899aabbccdd";
        public const string ChonLoaiGia = "e9f45c63-3344-5566-7788-99aabbcceedd";
        public const string ChuyenBan = "fa056d74-4455-6677-8899-aabbccddeeff";
        public const string DatGioChoMatHang = "ab167e85-5566-7788-99aa-bbccddeeff00";
        public const string DatSoLuong = "bc278f96-6677-8899-aabb-ccddeeff0011";
        public const string GiamGiaTheoNhom = "cd3890a7-7788-99aa-bbcc-ddeeff001122";
        public const string NhapMatKhauGiamDo = "de4901b8-8899-aabb-ccdd-eeff00112233";
        public const string TamUngDonHang = "064236d2-8fcc-415b-80cb-420e69f19c0c";
        public const string ThayDoiGioVao = "f06123da-aabb-ccdd-eeff-001122334455";
        public const string ThongKe = "1f516fe7-3b71-4cbf-a3e8-61ad116bfa79";
        public const string TimKiemDatTruoc = "128345fc-ccdd-eeff-0011-223344556677";
        public const string ChiTietCombo = "2394560d-ddee-ff00-1122-334455667788";
        public const string HoaDonBanHang = "HoaDonBanHang";
        public const string TDONHANG0Ae = "f3f7bb77-f4ba-4111-9066-014f52be79a0";
        public const string KhuVucControl = "f842ff6f-80e3-46ab-bf04-7dda627513d1";
        public const string SuDungDichVu = "141ca9a1-6819-49e2-b8a6-c1ac806ef0a9";
        public const string QuanLyBanHangNhaHang = "417e6d1d-ed16-4847-b752-65c3cefbe341";
        public const string QuanLyBanHang = "417e6d1d-ed16-4847-b752-65c3cefbe341";
        public const string ThongKeDoanhThu = "d913c8d9-4395-476c-9612-8ca7f35b6268";
        public const string TheoDoiDatPhong = "11f4bf28-9dd4-4a22-8c5c-e912a637576a";
        public const string ThongKeMatHangBan = "67500401-1f1e-4c18-a0fc-f487c43f4b0c";
        public const string ChiTietBanHangTheoMatHang = "5645abce-8395-4c94-ac64-f2e0e55007d8";
        public const string LuuVetHoatDong = "ac206bb6-0236-48a6-b558-b674e015c21c";
        public const string XacNhanXoaLuuVet = "c73a5edd-3c2c-452e-83de-48f6790bb32e";
        public const string KiemSoatOrder = "8cb6cbb8-5303-4425-a086-7e8280a4cb3e";
        public const string DanhSachBillHuy = "a52478cf-2d23-4ff0-8b63-e098e5ce6829";
        public const string KhachHangThanThiet = "10e06969-754e-404a-9ea4-1f0d4574ddb7";
        public const string KhoHang = "aad0140d-3805-490a-9698-6a947b1f8af5";
    }

    public static class Menus
    {
        public const string DieuChinhHoaDon = "a6bfe97d-7e61-4c79-a6a3-e8437da57e5d";
        public const string QuanLyBanHang = "65d26e6c-682f-40cf-84d3-ba02343c6223";
        public const string DanhMucKhoHang = "aad0140d-3805-490a-9698-6a947b1f8af5";
    }

    public static class Tables
    {
        public const string DKHOHANG = "DKHOHANG";
        public const string DTAIKHOANNGANHANG = "DTAIKHOANNGANHANG";
        public const string DDONVITINH = "DDONVITINH";
        public const string DMATHANG = "DMATHANG";
        public const string TTHUCHI = "TTHUCHI";
        public const string DBAN = "DBAN";
        public const string DKHUVUC = "DKHUVUC";
        public const string DNHANVIEN = "DNHANVIEN";
        public const string TDONHANG = "TDONHANG";
        public const string SUSER = "SUSER";
        public const string DNHOMMATHANG = "DNHOMMATHANG";
        public const string DBANGGIA = "DBANGGIA";
        public const string DCUAHANG = "DCUAHANG";
        public const string DLOAIPHONG = "DLOAIPHONG";
        public const string TDATHANG = "TDATHANG";
        public const string TDATHANGCHITIET = "TDATHANGCHITIET";
        public const string DMUCDICHDAT = "DMUCDICHDAT";
    }

    public class DMATHANGRow
    {
        public DataRow Row { get; set; }
        public bool IsNull => Row == null;
        public string ID { get => Row != null && Row.Table.Columns.Contains("ID") ? Row["ID"].ToString() : ""; set => this["ID"] = value; }
        public string NAME { get => Row != null && Row.Table.Columns.Contains("NAME") ? Row["NAME"].ToString() : ""; set => this["NAME"] = value; }
        public decimal GIABAN { get => Row != null && Row.Table.Columns.Contains("GIABAN") ? ConvertTo.Decimal(Row["GIABAN"]) : 0; set => this["GIABAN"] = value; }
        public decimal GIABAN2 { get => Row != null && Row.Table.Columns.Contains("GIABAN2") ? ConvertTo.Decimal(Row["GIABAN2"]) : 0; set => this["GIABAN2"] = value; }
        public decimal GIABAN3 { get => Row != null && Row.Table.Columns.Contains("GIABAN3") ? ConvertTo.Decimal(Row["GIABAN3"]) : 0; set => this["GIABAN3"] = value; }
        public decimal GIABAN4 { get => Row != null && Row.Table.Columns.Contains("GIABAN4") ? ConvertTo.Decimal(Row["GIABAN4"]) : 0; set => this["GIABAN4"] = value; }
        public decimal GIAVON { get => Row != null && Row.Table.Columns.Contains("GIAVON") ? ConvertTo.Decimal(Row["GIAVON"]) : 0; set => this["GIAVON"] = value; }
        public int GIATHEOTHOIGIA { get => Row != null && Row.Table.Columns.Contains("GIATHEOTHOIGIA") ? ConvertTo.Int(Row["GIATHEOTHOIGIA"]) : 0; set => this["GIATHEOTHOIGIA"] = value; }
        public int THEOCAN { get => Row != null && Row.Table.Columns.Contains("THEOCAN") ? ConvertTo.Int(Row["THEOCAN"]) : 0; set => this["THEOCAN"] = value; }
        public int TAMKHOA { get => Row != null && Row.Table.Columns.Contains("TAMKHOA") ? ConvertTo.Int(Row["TAMKHOA"]) : 0; set => this["TAMKHOA"] = value; }
        public string DLOAIMATHANGID { get => Row != null && Row.Table.Columns.Contains("DLOAIMATHANGID") ? Row["DLOAIMATHANGID"].ToString() : ""; set => this["DLOAIMATHANGID"] = value; }
        public string DDONVITINHID { get => Row != null && Row.Table.Columns.Contains("DDONVITINHID") ? Row["DDONVITINHID"].ToString() : ""; set => this["DDONVITINHID"] = value; }
        public string DLOAIDOID { get => Row != null && Row.Table.Columns.Contains("DLOAIDOID") ? Row["DLOAIDOID"].ToString() : ""; set => this["DLOAIDOID"] = value; }
        public DMATHANGRow() { }
        public DMATHANGRow(DataRow r) { this.Row = r; }
        public DMATHANGRow(string id)
        {
            try { this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM DMATHANG WHERE ID = '{0}'", id)); } catch { }
        }
        public object this[string col]
        {
            get => Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value;
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public enum LoaiLuuVet
    {
        None = 0,
        InCheBien = 1,
        HuyHoaDon = 2,
        HuyBill = 2,
        ChuyenBan = 3,
        GopBan = 4,
        ThanhToan = 5,
        DatGiamGiaMatHang = 6,
        DatSoLuong = 7,
        DoiGiaBan = 8,
        DongBan = 9,
        GiamMon = 10,
        InBill = 11,
        Khac = 12,
        MoBan = 13,
        TangMon = 14,
        ThemMon = 15,
        TraDo = 16,
        XoaMon = 17,
        ChuyenMatHang = 18
    }

    public enum HoaDonMode
    {
        None = 0,
        SuDungDichVu = 1,
        BanHang = 2,
        QuanLyBanHang = 3,
        DieuChinhHoaDon = 4
    }

    public class DKHACHHANGRow
    {
        public DataRow Row { get; set; }
        public string ID => Row != null && Row.Table.Columns.Contains("ID") ? Row["ID"].ToString() : "";
        public string NAME => Row != null && Row.Table.Columns.Contains("NAME") ? Row["NAME"].ToString() : "";
        public string DTHETRATRUOCID => Row != null && Row.Table.Columns.Contains("DTHETRATRUOCID") ? Row["DTHETRATRUOCID"].ToString() : "";
        public string DNHOMKHACHHANGID { get => Row != null && Row.Table.Columns.Contains("DNHOMKHACHHANGID") ? Row["DNHOMKHACHHANGID"].ToString() : ""; set => this["DNHOMKHACHHANGID"] = value; }
        public DKHACHHANGRow() { }
        public DKHACHHANGRow(DataRow r) { this.Row = r; }
        public DKHACHHANGRow(string id)
        {
            try { this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM DKHACHHANG WHERE ID = '{0}'", id)); } catch { }
        }
        public void Update(Database db = null) { try { (db ?? Config.Db).UpdateDataRow(this.Row, "DKHACHHANG"); } catch { } }
        public object this[string col]
        {
            get => Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value;
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public class DBANRow
    {
        public DataRow Row { get; set; }
        public string ID => Row != null && Row.Table.Columns.Contains("ID") ? Row["ID"].ToString() : "";
        public string NAME => Row != null && Row.Table.Columns.Contains("NAME") ? Row["NAME"].ToString() : "";
        public string NOTE => Row != null && Row.Table.Columns.Contains("NOTE") ? Row["NOTE"].ToString() : "";
        public string DKHUVUCID { get => Row != null && Row.Table.Columns.Contains("DKHUVUCID") ? Row["DKHUVUCID"].ToString() : ""; set => this["DKHUVUCID"] = value; }
        public string DBANGGIAID { get => Row != null && Row.Table.Columns.Contains("DBANGGIAID") ? Row["DBANGGIAID"].ToString() : ""; set => this["DBANGGIAID"] = value; }
        public int CACHTINHGIO { get => Row != null && Row.Table.Columns.Contains("CACHTINHGIO") ? ConvertTo.Int(Row["CACHTINHGIO"]) : 0; set => this["CACHTINHGIO"] = value; }
        public decimal TIENMOBAN { get => Row != null && Row.Table.Columns.Contains("TIENMOBAN") ? ConvertTo.Decimal(Row["TIENMOBAN"]) : 0; set => this["TIENMOBAN"] = value; }
        public decimal DONGIA { get => Row != null && Row.Table.Columns.Contains("DONGIA") ? ConvertTo.Decimal(Row["DONGIA"]) : 0; set => this["DONGIA"] = value; }
        public string TAIKHOANGIU { get => Row != null && Row.Table.Columns.Contains("TAIKHOANGIU") ? Row["TAIKHOANGIU"].ToString() : ""; set => this["TAIKHOANGIU"] = value; }
        public string TDONHANGID { get => Row != null && Row.Table.Columns.Contains("TDONHANGID") ? Row["TDONHANGID"].ToString() : ""; set => this["TDONHANGID"] = value; }
        public DBANRow() { }
        public DBANRow(DataRow r) { this.Row = r; }
        public DBANRow(string id)
        {
            try
            {
                this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM DBAN WHERE ID = '{0}'", id));
            }
            catch { }
        }
        public object this[string col]
        {
            get => Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value;
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public class DKHUVUCRow
    {
        public DataRow Row { get; set; }
        public string ID => Row != null && Row.Table.Columns.Contains("ID") ? Row["ID"].ToString() : "";
        public string NAME => Row != null && Row.Table.Columns.Contains("NAME") ? Row["NAME"].ToString() : "";
        public object DGIAMATHANGID => Row != null && Row.Table.Columns.Contains("DGIAMATHANGID") ? Row["DGIAMATHANGID"] : 0;
        public int CACHTINHGIO { get => Row != null && Row.Table.Columns.Contains("CACHTINHGIO") ? ConvertTo.Int(Row["CACHTINHGIO"]) : 0; set => this["CACHTINHGIO"] = value; }
        public DateTime TUGIO { get => Row != null && Row.Table.Columns.Contains("TUGIO") ? ConvertTo.Date(Row["TUGIO"]) : DateTime.MinValue; set => this["TUGIO"] = value; }
        public DateTime DENGIO { get => Row != null && Row.Table.Columns.Contains("DENGIO") ? ConvertTo.Date(Row["DENGIO"]) : DateTime.MinValue; set => this["DENGIO"] = value; }
        public string DGIATHEOGIOID { get => Row != null && Row.Table.Columns.Contains("DGIATHEOGIOID") ? Row["DGIATHEOGIOID"].ToString() : ""; set => this["DGIATHEOGIOID"] = value; }
        public string DBANGGIAID { get => Row != null && Row.Table.Columns.Contains("DBANGGIAID") ? Row["DBANGGIAID"].ToString() : ""; set => this["DBANGGIAID"] = value; }
        public decimal DONGIA { get => Row != null && Row.Table.Columns.Contains("DONGIA") ? ConvertTo.Decimal(Row["DONGIA"]) : 0; set => this["DONGIA"] = value; }
        public DKHUVUCRow() { }
        public DKHUVUCRow(DataRow r) { this.Row = r; }
        public DKHUVUCRow(string id)
        {
            try
            {
                this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM DKHUVUC WHERE ID = '{0}'", id));
            }
            catch { }
        }
        public object this[string col]
        {
            get => Row != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value;
            set { if (Row != null && Row.Table.Columns.Contains(col)) Row[col] = value; }
        }
    }

    public class TDONHANGRow
    {
        public DataRow Row { get; set; }
        public bool IsNull => Row == null;
        public string ID { get => this["ID"]?.ToString() ?? ""; set => this["ID"] = value; }
        public string NAME { get => this["NAME"]?.ToString() ?? ""; set => this["NAME"] = value; }
        public int SOHD { get => ConvertTo.Int(this["SOHD"]); set => this["SOHD"] = value; }
        public int SOTT { get => ConvertTo.Int(this["SOTT"]); set => this["SOTT"] = value; }
        public int LOAI { get => ConvertTo.Int(this["LOAI"]); set => this["LOAI"] = value; }
        public DateTime NGAY { get => ConvertTo.Date(this["NGAY"]); set => this["NGAY"] = value; }
        public DateTime BATDAU { get => ConvertTo.Date(this["BATDAU"]); set => this["BATDAU"] = value; }
        public DateTime KETTHUC { get => ConvertTo.Date(this["KETTHUC"]); set => this["KETTHUC"] = value; }
        public int DATHANHTOAN { get => ConvertTo.Int(this["DATHANHTOAN"]); set => this["DATHANHTOAN"] = value; }
        public decimal TIENBAN { get => ConvertTo.Decimal(this["TIENBAN"]); set => this["TIENBAN"] = value; }
        public string NHOMGUID { get => this["NHOMGUID"]?.ToString() ?? ""; set => this["NHOMGUID"] = value; }
        public int SOLANINTAMTINH { get => ConvertTo.Int(this["SOLANINTAMTINH"]); set => this["SOLANINTAMTINH"] = value; }
        public DateTime INTAMTINHLUC { get => ConvertTo.Date(this["INTAMTINHLUC"]); set => this["INTAMTINHLUC"] = value; }
        public string DBANID { get => this["DBANID"]?.ToString() ?? ""; set => this["DBANID"] = value; }
        public decimal THETRATRUOC { get => ConvertTo.Decimal(this["THETRATRUOC"]); set => this["THETRATRUOC"] = value; }
        public decimal TRUTICHLUY { get => ConvertTo.Decimal(this["TRUTICHLUY"]); set => this["TRUTICHLUY"] = value; }
        public decimal DATTRUOC { get => ConvertTo.Decimal(this["DATTRUOC"]); set => this["DATTRUOC"] = value; }
        public decimal NOCU { get => ConvertTo.Decimal(this["NOCU"]); set => this["NOCU"] = value; }
        public decimal VOUCHER { get => ConvertTo.Decimal(this["VOUCHER"]); set => this["VOUCHER"] = value; }
        public decimal THE { get => ConvertTo.Decimal(this["THE"]); set => this["THE"] = value; }
        public decimal CHUYENKHOAN { get => ConvertTo.Decimal(this["CHUYENKHOAN"]); set => this["CHUYENKHOAN"] = value; }
        public string DTAIKHOANNGANHANGID { get => this["DTAIKHOANNGANHANGID"]?.ToString() ?? ""; set => this["DTAIKHOANNGANHANGID"] = value; }
        public string DTHETRATRUOCID { get => this["DTHETRATRUOCID"]?.ToString() ?? ""; set => this["DTHETRATRUOCID"] = value; }
        public string DVOUCHERID { get => this["DVOUCHERID"]?.ToString() ?? ""; set => this["DVOUCHERID"] = value; }
        public string DKHACHHANGID { get => this["DKHACHHANGID"]?.ToString() ?? ""; set => this["DKHACHHANGID"] = value; }
        public string DBANGGIAID { get => this["DBANGGIAID"]?.ToString() ?? ""; set => this["DBANGGIAID"] = value; }
        public decimal DONGIA { get => ConvertTo.Decimal(this["DONGIA"]); set => this["DONGIA"] = value; }
        public int CACHTINHGIA { get => ConvertTo.Int(this["CACHTINHGIA"]); set => this["CACHTINHGIA"] = value; }
        public decimal TILETHUE { get => ConvertTo.Decimal(this["TILETHUE"]); set => this["TILETHUE"] = value; }
        public decimal TIENTHUE { get => ConvertTo.Decimal(this["TIENTHUE"]); set => this["TIENTHUE"] = value; }
        public decimal TILEPHIDICHVU { get => ConvertTo.Decimal(this["TILEPHIDICHVU"]); set => this["TILEPHIDICHVU"] = value; }
        public decimal PHIDICHVU { get => ConvertTo.Decimal(this["PHIDICHVU"]); set => this["PHIDICHVU"] = value; }
        public decimal TILEGIAMGIA { get => ConvertTo.Decimal(this["TILEGIAMGIA"]); set => this["TILEGIAMGIA"] = value; }
        public decimal TIENGIAMGIA { get => ConvertTo.Decimal(this["TIENGIAMGIA"]); set => this["TIENGIAMGIA"] = value; }
        public decimal TILEGIAMGIAGIO { get => ConvertTo.Decimal(this["TILEGIAMGIAGIO"]); set => this["TILEGIAMGIAGIO"] = value; }
        public decimal TIENGIAMGIAGIO { get => ConvertTo.Decimal(this["TIENGIAMGIAGIO"]); set => this["TIENGIAMGIAGIO"] = value; }
        public decimal TILEGIAMGIATONG { get => ConvertTo.Decimal(this["TILEGIAMGIATONG"]); set => this["TILEGIAMGIATONG"] = value; }
        public decimal TIENGIAMGIATONG { get => ConvertTo.Decimal(this["TIENGIAMGIATONG"]); set => this["TIENGIAMGIATONG"] = value; }
        public int SOKHACH { get => ConvertTo.Int(this["SOKHACH"]); set => this["SOKHACH"] = value; }
        public int LANINHOADON { get => ConvertTo.Int(this["LANINHOADON"]); set => this["LANINHOADON"] = value; }
        public decimal TIENGIO { get => ConvertTo.Decimal(this["TIENGIO"]); set => this["TIENGIO"] = value; }
        public decimal TIENHANG { get => ConvertTo.Decimal(this["TIENHANG"]); set => this["TIENHANG"] = value; }
        public decimal TONGCONG { get => ConvertTo.Decimal(this["TONGCONG"]); set => this["TONGCONG"] = value; }
        public decimal TIENTHANHTOAN { get => ConvertTo.Decimal(this["TIENTHANHTOAN"]); set => this["TIENTHANHTOAN"] = value; }
        public decimal TIENMAT { get => ConvertTo.Decimal(this["TIENMAT"]); set => this["TIENMAT"] = value; }
        public decimal CONGNO { get => ConvertTo.Decimal(this["CONGNO"]); set => this["CONGNO"] = value; }
        public decimal CONNO { get => ConvertTo.Decimal(this["CONNO"]); set => this["CONNO"] = value; }
        public decimal CONLAI { get => ConvertTo.Decimal(this["CONLAI"]); set => this["CONLAI"] = value; }
        public decimal KHACHDUA { get => ConvertTo.Decimal(this["KHACHDUA"]); set => this["KHACHDUA"] = value; }
        public decimal TRALAI { get => ConvertTo.Decimal(this["TRALAI"]); set => this["TRALAI"] = value; }
        public decimal DIEM { get => ConvertTo.Decimal(this["DIEM"]); set => this["DIEM"] = value; }
        public decimal DIEMGIAM { get => ConvertTo.Decimal(this["DIEMGIAM"]); set => this["DIEMGIAM"] = value; }
        public string PASSWIFI { get => this["PASSWIFI"]?.ToString() ?? ""; set => this["PASSWIFI"] = value; }
        public string DCUAHANGID { get => this["DCUAHANGID"]?.ToString() ?? ""; set => this["DCUAHANGID"] = value; }
        public decimal TIENMOBAN { get => ConvertTo.Decimal(this["TIENMOBAN"]); set => this["TIENMOBAN"] = value; }
        public DateTime BATDAUPHONGCUOI { get => ConvertTo.Date(this["BATDAUPHONGCUOI"]); set => this["BATDAUPHONGCUOI"] = value; }
        public string TDATHANGID { get => this["TDATHANGID"]?.ToString() ?? ""; set => this["TDATHANGID"] = value; }
        public DateTime GIOTHANHTOAN { get => ConvertTo.Date(this["GIOTHANHTOAN"]); set => this["GIOTHANHTOAN"] = value; }
        public int LOAITHANHTOAN { get => ConvertTo.Int(this["LOAITHANHTOAN"]); set => this["LOAITHANHTOAN"] = value; }
        public string USERTHANHTOANID { get => this["USERTHANHTOANID"]?.ToString() ?? ""; set => this["USERTHANHTOANID"] = value; }
        public int PHUTKHUYENMAI { get => ConvertTo.Int(this["PHUTKHUYENMAI"]); set => this["PHUTKHUYENMAI"] = value; }
        public decimal TILEKHUYENMAIPHUTDAU { get => ConvertTo.Decimal(this["TILEKHUYENMAIPHUTDAU"]); set => this["TILEKHUYENMAIPHUTDAU"] = value; }
        public int TUTHAYDOIGIO { get => ConvertTo.Int(this["TUTHAYDOIGIO"]); set => this["TUTHAYDOIGIO"] = value; }
        public TDONHANGRow()
        {
            try
            {
                DataTable dt = Config.Db.GetTable("SELECT FIRST 0 * FROM TDONHANG");
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
        public TDONHANGRow(DataRow r) { this.Row = r; }
        public TDONHANGRow(string id)
        {
            try
            {
                this.Row = Config.Db.GetFirstRow(string.Format("SELECT * FROM TDONHANG WHERE ID = '{0}'", id));
            }
            catch { }
        }
        public void Update(Database db = null, string userId = null)
        {
            try
            {
                if (Row != null && Row.Table != null)
                {
                    (db ?? Config.Db).UpdateDataRow(this.Row, "TDONHANG");
                }
            }
            catch { }
        }
        public void Delete(Database db = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.ID))
                {
                    (db ?? Config.Db).ExecSql(string.Format("DELETE FROM TDONHANG WHERE ID = '{0}'", this.ID));
                }
            }
            catch { }
        }
        public object this[string col]
        {
            get => Row != null && Row.Table != null && Row.Table.Columns.Contains(col) ? Row[col] : DBNull.Value;
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

    public static class QuanLyBanHang
    {
        public static void HuyBill(string id, string lyDo)
        {
            try
            {
                Config.Db.ExecSql(string.Format("UPDATE TDONHANG SET STATUS = 40, NOTE = '{1}' WHERE ID = '{0}'", id, (lyDo ?? "").Replace("'", "''")));
                Config.Db.ExecSql(string.Format("UPDATE DBAN SET TDONHANGID = NULL WHERE TDONHANGID = '{0}'", id));
            }
            catch { }
        }

        public static void Track(string action, LoaiLuuVet loai, string note, string id, string ban)
        {
            try
            {
                No1Run.TLUUVETRow row = new No1Run.TLUUVETRow();
                DateTime now = Config.Db.DbDateTime;
                row.GIO = now;
                row.PHANLOAI = (int)loai;
                row.BAN = ban ?? "";
                row.SODONHANG = id ?? "";
                row.TAIKHOAN = DbConfig.UserName;
                row.THIETBI = Environment.MachineName;
                row.NGAY = now.Date;
                row.NOTE = note ?? "";
                row.CHUCNANG = action ?? "";
                row.Update();
            }
            catch { }
        }

        public static string GetTenBanTuHoaDon(string donHangId)
        {
            try
            {
                return Config.Db.GetFirstFieldString("SELECT DBAN.NAME FROM TDONHANG INNER JOIN DBAN ON TDONHANG.DBANID = DBAN.ID WHERE TDONHANG.ID = '" + donHangId + "'");
            }
            catch { return ""; }
        }

        public static void LuuBillHuy(Database db, string userId, TDONHANGRow donHang, string note)
        {
            try
            {
                string sql = string.Format("INSERT INTO TBILLHUY (ID, TDONHANGID, LYDO, USERCREATEDID, TIMECREATED) VALUES ('{0}', '{1}', '{2}', '{3}', CURRENT_TIMESTAMP)",
                    Guid.NewGuid().ToString(), donHang.ID, (note ?? "").Replace("'", "''"), userId ?? "admin");
                (db ?? Config.Db).ExecSql(sql);
            }
            catch { }
        }
    }


}


