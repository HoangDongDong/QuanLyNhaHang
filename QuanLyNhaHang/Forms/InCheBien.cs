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
using System.Drawing.Printing;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Forms;

namespace No1Run
{
    public partial class InCheBien : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;

        public InCheBien()
        {
            InitializeComponent();
        }

        private string TDONHANGID;
        private TDONHANG0Ae caller;
        public static List<string> lstPrinters;
        private string DKHUVUCID;
        private string TenBan;
        private string TenKhuVuc;
        private string SoHoaDon;

        internal void SetData(string TDONHANGID, TDONHANG0Ae caller, string DKHUVUCID, string TenBan, string TenKhuVuc, bool TuDongIn, string SoHoaDon)
        {
            this.TDONHANGID = TDONHANGID;
            this.DKHUVUCID = DKHUVUCID;
            this.TenBan = TenBan;
            this.TenKhuVuc = TenKhuVuc;
            this.SoHoaDon = SoHoaDon;
            this.caller = caller;
            RefreshPrinters();
            colMayIn.Items.Clear();
            foreach (string printer in lstPrinters)
            {
                colMayIn.Items.Add(printer);
            }
            Reload(TuDongIn);
        }

        internal static void RefreshPrinters()
        {
            if (lstPrinters != null) lstPrinters.Clear();            
            lstPrinters = new List<string>();
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                lstPrinters.Add(printerName);                
            }
        }

        public bool NoItemToPrint = false;

        Dictionary<InXuongBepControl, KryptonPage> dic;        
        public void btnIn_Click(object sender, EventArgs e)
        {
            ThucHienIn(false);            
        }

        private void ThucHienIn(bool TuDong)
        {
            if (dic == null)
            {
                Msg.ShowWarning("Mời bạn thiết lập máy in xuống bar/bếp trước");
                return;
            }

            if (dic.Count == 0 && !TuDong)
            {
                Msg.ShowWarning("Không còn mặt hàng nào để in");
                return;
            }

            if (caller != null)
            {
                caller.Track(LoaiLuuVet.InCheBien, TuDong ? "In pha chế tự động" : "In pha chế", 0, 0, 0, "");
            }

            // In che bien
            foreach (InXuongBepControl ctrl in dic.Keys)
            {
                KryptonPage page = dic[ctrl];

                // Activate it
                tabMain.SelectedPage = page;

                // Print
                try
                {
                    ctrl.DoPrint();
                }
                catch (Exception exPrint)
                {
                    Msg.ShowWarning("Lỗi khi thực hiện in: " + exPrint.Message);
                }
            }

            if (!TuDong)
            {                
                No1Form1.DialogResult = DialogResult.OK;
            }
        }

        private void Reload(bool TuDongIn)
        {
            tabMain.Pages.Clear();

            string mayInBep, mayInBar, mayInKhac, mayInDichVu;
            LayMayInTheoCauHinh(DKHUVUCID, out mayInBep, out mayInBar, out mayInKhac, out mayInDichVu);                        

            // Lấy danh sách máy in
            List<Item> lst = new List<Item>();
            if (SystemConfig.InDoAn == 30)
                lst.Add(new Item(mayInBep, "đồ ăn", "DLOAIDOID='0'"));
            if (SystemConfig.InDoUong == 30)
                lst.Add(new Item(mayInBar, "đồ uống", "DLOAIDOID='1'"));
            if (SystemConfig.InDoKhac == 30)
                lst.Add(new Item(mayInKhac, "đồ khác", "DLOAIDOID='3'"));
            if (SystemConfig.InDichVu == 30)
                lst.Add(new Item(mayInDichVu, "dịch vụ", "DLOAIDOID='2'"));

            bool inRieng = SystemConfig.InRiengDoAnUong == 30;
            bool chuaCaiDat = false;
            // Hòa nhập lại theo máy in
            Dictionary<string, Item> hst = new Dictionary<string, Item>();
            if (!inRieng)
            {
                foreach (Item itm in lst)
                {
                    if (hst.ContainsKey(itm.PrinterName.ToLower()))
                    {
                        Item oldItem = hst[itm.PrinterName.ToLower()];
                        oldItem.CaptionName += ", " + itm.CaptionName;
                        oldItem.WhereStr += " OR " + itm.WhereStr;
                    }
                    else
                    {
                        hst.Add(itm.PrinterName.ToLower(), itm);
                    }
                }
                chuaCaiDat = hst.Count == 0 || (hst.Count == 1 && hst.ContainsKey(""));
            }
            else
            {
                foreach (Item itm in lst)
                {
                    if (itm.PrinterName.Length == 0) chuaCaiDat = true;
                }
            }
            
            ThietLapTrangThaiSua(chuaCaiDat);
            if (chuaCaiDat)
            {
                LoadSetup(grSetup);
                tabMain.Pages.Add(pageChuaCaiDat);                
            }
            else
            {                               
                dic = new Dictionary<InXuongBepControl, KryptonPage>();

                List<Item> lstNew = new List<Item>();
                if (inRieng)
                {
                    lstNew = lst;
                }
                else
                {
                    foreach (Item itm in hst.Values)
                    {
                        lstNew.Add(itm);
                    }
                }

                string sql = InCheBienTs.GetSqlInCheBien(TDONHANGID);                
                DataTable dt = Config.Db.GetTable(sql);

                if (dt == null || dt.Rows.Count == 0)
                {
                    if (!TuDongIn)
                    {
                        Msg.ShowWarning("Không có mặt hàng nào để in");
                    }
                    NoItemToPrint = true;
                    return;
                }

                int count = 0;
                foreach (Item itm in lstNew)
                {
                    DataRow[] Rows = dt.Select(itm.WhereStr);

                    if (Rows.Length > 0)
                    {
                        DataTable dtClone = dt.Clone();
                        foreach (DataRow r in Rows)
                        {
                            dtClone.ImportRow(r);
                        }
                        
                        string caption = itm.CaptionName.Substring(0, 1).ToUpper() + itm.CaptionName.Substring(1);
                        KryptonPage page = new KryptonPage(caption);
                        
                        InXuongBepControl ctrl = null;
                        try { ctrl = Config.CreateForm(Forms.InXuongBepControl) as InXuongBepControl; } catch { }
                        if (ctrl == null) ctrl = new InXuongBepControl();

                        if (SystemConfig.LuuVetInCheBien == 30)
                        {
                            ctrl.TrackRequest += new InXuongBepControl.TrackCallBackHandler(ctrl_TrackRequest);
                        }
                        dic.Add(ctrl, page);
                        ctrl.No1UserControl1.Dock = DockStyle.Fill;
                        ctrl.TenMayIn = itm.PrinterName;
                        ctrl.TenKhuVuc = TenKhuVuc;
                        ctrl.TenBan = TenBan;
                        ctrl.LoaiDo = caption;
                        ctrl.SoHoaDon = SoHoaDon;
                        
                        ctrl.DataSource = dtClone;
                        ctrl.TDONHANGID = TDONHANGID;
                        page.Controls.Add(ctrl.No1UserControl1);
                        tabMain.Pages.Add(page);
                        count++;
                    }
                }

                if (count == 0)
                {
                    if (!TuDongIn)
                    {
                        Msg.ShowWarning("Không có mặt hàng nào để in");
                    }
                    NoItemToPrint = true;
                }
            }
        }

        void ctrl_TrackRequest(string NoiDung)
        {
            if (caller != null)
            {
                caller.Track(LoaiLuuVet.InCheBien, NoiDung, 0, 0, 0, "");
            }
        }
        
        internal static void LayMayInTheoCauHinh(string DKHUVUCID, out string mayInBep, out string mayInBar, out string mayInKhac, out string mayInDichVu)
        {
            if (SystemConfig.InPhaCheTheoKhuVuc == 30)
            {                
                mayInBep = LayMayIn(DKHUVUCID + "_AN");
                mayInBar = LayMayIn(DKHUVUCID  + "_UONG");
                mayInKhac = LayMayIn(DKHUVUCID + "_KHAC");
                mayInDichVu = LayMayIn(DKHUVUCID + "_DICHVU");
            }
            else
            {
                mayInBep = LayMayIn("MAY_IN_DO_AN");
                mayInBar = LayMayIn("MAY_IN_DO_UONG");
                mayInKhac = LayMayIn("MAY_IN_KHAC");
                mayInDichVu = LayMayIn("MAY_IN_DICH_VU");
            }
        }

        public static void SetConfigVal(string key, string value)
        {
            try
            {
                No1Lib.Sys.EasyReg.Key = Microsoft.Win32.Registry.CurrentUser;
                No1Lib.Sys.EasyReg.SetValue(key, value);
            }
            catch
            {
                try
                {
                    using (var regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\QuanLyNhaHang"))
                    {
                        if (regKey != null)
                        {
                            regKey.SetValue(key, value ?? "");
                        }
                    }
                }
                catch { }
            }
        }

        public static string GetConfigVal(string key)
        {
            try
            {
                No1Lib.Sys.EasyReg.Key = Microsoft.Win32.Registry.CurrentUser;
                string val = No1Lib.Sys.EasyReg.GetString(key);
                if (!string.IsNullOrEmpty(val)) return val;
            }
            catch { }

            try
            {
                using (var regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\QuanLyNhaHang"))
                {
                    if (regKey != null)
                    {
                        object obj = regKey.GetValue(key);
                        if (obj != null && !string.IsNullOrEmpty(obj.ToString())) return obj.ToString();
                    }
                }
            }
            catch { }

            try
            {
                using (var regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\QuanLyNhaHang"))
                {
                    if (regKey != null)
                    {
                        object obj = regKey.GetValue(key);
                        if (obj != null && !string.IsNullOrEmpty(obj.ToString())) return obj.ToString();
                    }
                }
            }
            catch { }

            return "";
        }

        public static string LayMayIn(string Key)
        {
            if (lstPrinters == null) RefreshPrinters();
            string MayIn = GetConfigVal(Key);
            if (lstPrinters.Contains(MayIn)) return MayIn;
            return "";
        }

        internal static void LoadSetup(MiscDataGridView grSetup)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("KHUVUC", typeof(string));
            dt.Columns.Add("LOAIDO", typeof(string));
            dt.Columns.Add("MAYIN", typeof(string));
            dt.Columns.Add("KEY", typeof(string));

            if (SystemConfig.InPhaCheTheoKhuVuc == 30)
            {
                // Lấy thiết lập máy in theo nhóm
                DataTable dtNhom = Config.Db.GetTable("SELECT ID, NAME FROM DKHUVUC WHERE STATUS = 30 ORDER BY SORTORDER");
                if (dtNhom != null)
                {
                    foreach (DataRow rNhom in dtNhom.Rows)
                    {
                        string TenNhom = rNhom["NAME"].ToString();
                        string ID = rNhom["ID"].ToString();
                        if (SystemConfig.InDoAn == 30)
                        {
                            AddRow(dt, TenNhom, "Đồ ăn", ID + "_AN");
                            TenNhom = "";
                        }
                        if (SystemConfig.InDoUong == 30)
                        {
                            AddRow(dt, TenNhom, "Đồ uống", ID + "_UONG");
                            TenNhom = "";
                        }
                        if (SystemConfig.InDoKhac == 30)
                        {
                            AddRow(dt, TenNhom, "Đồ khác", ID + "_KHAC");
                            TenNhom = "";
                        }
                        if (SystemConfig.InDichVu == 30)
                        {
                            AddRow(dt, TenNhom, "Dịch vụ", ID + "_DICHVU");
                        }
                    }
                }
            }
            else
            {
                if (grSetup.Columns.Contains("colKhuVuc"))
                {
                    grSetup.Columns["colKhuVuc"].Visible = false;
                }
                if (SystemConfig.InDoAn == 30)
                    AddRow(dt, "", "Đồ ăn", "MAY_IN_DO_AN");
                if (SystemConfig.InDoUong == 30)
                    AddRow(dt, "", "Đồ uống", "MAY_IN_DO_UONG");
                if (SystemConfig.InDoKhac == 30)
                    AddRow(dt, "", "Đồ khác", "MAY_IN_KHAC");
                if (SystemConfig.InDichVu == 30)
                    AddRow(dt, "", "Dịch vụ", "MAY_IN_DICH_VU");
            }

            grSetup.DataSource = dt;            
        }

        public void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            SaveData(grSetup);

            btnLuuThongTin.Visible = false;
            btnThietLap.Visible = true;
            btnIn.Visible = true;
            Reload(false);
        }

        internal static void SaveData(MiscDataGridView grSetup)
        {
            // Kiểm tra xem có nhập đủ máy in không
            foreach (DataGridViewRow r in grSetup.Rows)
            {
                DataRowView drv = r.DataBoundItem as DataRowView;
                if (drv == null) continue;
                DataRow row = drv.Row;
                string MayIn = row["MAYIN"].ToString();
                if (MayIn.Length == 0 || !lstPrinters.Contains(MayIn))
                {
                    Msg.ShowWarning("Mời bạn chọn máy in");
                    grSetup.ClearSelection();
                    r.Selected = true;
                    return;
                }
            }

            foreach (DataGridViewRow r in grSetup.Rows)
            {
                DataRowView drv = r.DataBoundItem as DataRowView;
                if (drv == null) continue;
                DataRow row = drv.Row;
                string MayIn = row["MAYIN"].ToString();
                string Key = row["KEY"].ToString();
                SetConfigVal(Key, MayIn);
            }
        }

        private static void AddRow(DataTable dt, string KhuVuc, string LoaiDo, string MayInKey)
        {
            DataRow r = dt.NewRow();
            r["KHUVUC"] = KhuVuc;
            r["LOAIDO"] = LoaiDo;
            r["KEY"] = MayInKey;
            string MayIn = GetConfigVal(MayInKey);
            if (lstPrinters != null && lstPrinters.Contains(MayIn))
            {
                r["MAYIN"] = MayIn;
            }
            dt.Rows.Add(r);
        }

        class Item
        {
            public string PrinterName;
            public string CaptionName;
            public string WhereStr;

            public Item(string printerName, string captionName, string whereStr)
            {
                this.PrinterName = printerName;
                this.CaptionName = captionName;
                this.WhereStr = whereStr;
            }
        }

        public void btnHuyBo_Click(object sender, EventArgs e)
        {            
            Reload(false);
        }

        public void btnThietLap_Click(object sender, EventArgs e)
        {
            ThietLap();
        }
        
        internal void ThietLap()
        {          
            ThietLapTrangThaiSua(true);
            LoadSetup(grSetup);

            tabMain.Pages.Clear();
            tabMain.Pages.Add(pageChuaCaiDat);
        }

        private void ThietLapTrangThaiSua(bool val)
        {
            btnHuyBo.Visible = val;
            btnLuuThongTin.Visible = val;
            btnThietLap.Visible = !val;
            btnIn.Visible = !val;
        }

        public void grSetup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (colKhuVuc != null && e.ColumnIndex == colKhuVuc.Index)
            {
                e.CellStyle.ForeColor = Color.Blue;
                e.CellStyle.Font = new Font(grSetup.Font, FontStyle.Bold);
            }
        }

        internal void ThucHienInTuDong()
        {
            ThucHienIn(true);
        }

        public void grSetup_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
    }

    public static class InCheBienTs
    {
        public static string GetSqlInCheBien(string TDONHANGID)
        {
            string sql = @"SELECT SUM(SOLUONG) AS SOLUONG, TENHANG, DLOAIDOID, NOTE, DVT, DDONVITINHID
FROM
(
SELECT COALESCE(TDONHANGCHITIET.NOTE, '') AS NOTE, SLXUATCHUAQUYDOI AS SOLUONG, TENHANG, COALESCE(DLOAIDOID, '1') AS DLOAIDOID,
TDONHANGCHITIET.DDONVITINHID,
(SELECT NAME FROM DDONVITINH WHERE ID = TDONHANGCHITIET.DDONVITINHID) AS DVT
FROM TDONHANGCHITIET INNER JOIN DMATHANG ON TDONHANGCHITIET.DMATHANGID = DMATHANG.ID AND TDONHANGID = '{0}'
AND COALESCE(DMATHANG.DLOAIMATHANGID, '') <> '4'
AND COALESCE(DMATHANG.DLOAIMATHANGID, '') <> '5'
AND COALESCE(DMATHANG.DLOAIMATHANGID, '') <> '7'
INNER JOIN DNHOMMATHANG ON DMATHANG.DNHOMMATHANGID = DNHOMMATHANG.ID
UNION ALL
SELECT COALESCE(NOTE, ''), -SOLUONG, TENHANG, DLOAIDOID,
DDONVITINHID,
(SELECT NAME FROM DDONVITINH WHERE ID = DDONVITINHID) AS DVT
FROM TINCHEBIEN
WHERE TDONHANGID = '{0}'
)
A
GROUP BY A.NOTE, A.TENHANG, A.DLOAIDOID, A.DVT, DDONVITINHID
HAVING SUM(SOLUONG) <> 0";
            return string.Format(sql, TDONHANGID);
        }
    }
}
