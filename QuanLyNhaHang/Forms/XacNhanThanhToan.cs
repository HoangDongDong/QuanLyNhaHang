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
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.Forms
{
    public partial class XacNhanThanhToan : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form form => this;
        public No1Lib.Sys.No1Form No1Form1 => this;

        private decimal TONGTIEN;
        private string DKHACHHANGID;
        private string TDONHANGID;

        private HoaDonMode mode;

        public XacNhanThanhToan()
        {
            InitializeComponent();
        }

        public void SetData(HoaDonMode mode, decimal TONGTIEN, decimal datTruoc, decimal NoCu, string DKHACHHANGID, string TDONHANGID)
        {
            this.mode = mode;
            this.DKHACHHANGID = DKHACHHANGID;
            this.TDONHANGID = TDONHANGID;

            numNoCu.Value = NoCu;
            numDatTruoc.DecimalPlaces = 0;
            numDatTruoc.Value = datTruoc;
            this.TONGTIEN = TONGTIEN + NoCu - datTruoc;
            numTienHoaDon.Value = TONGTIEN;

            lueDTAIKHOAN.LoadData(Tables.DTAIKHOANNGANHANG);

            numTongTien.Value = this.TONGTIEN;
            numKhachDua_OnEditValueChanged(null, null);

            int soLe = SystemConfig.GiaBanLeUsd == 30 ? 2 : 0;

            numNoCu.DecimalPlaces = soLe;
            numTienHoaDon.DecimalPlaces = soLe;
            numTongTien.DecimalPlaces = soLe;
            numKhachDua.DecimalPlaces = soLe;
            numTraLai.DecimalPlaces = soLe;

            List<ArrangeItem> lst = new List<ArrangeItem>();
            lst.Add(new ArrangeItem(numDatTruoc.Value != 0, lblDatTruoc, numDatTruoc));
            lst.Add(new ArrangeItem(numNoCu.Value != 0, lblNoCu, numNoCu));
            lst.Add(new ArrangeItem(numDatTruoc.Value != 0 || numNoCu.Value != 0, lblTienHoaDon, numTienHoaDon));
            lst.Add(new ArrangeItem(true, lblTongTien, numTongTien));
            lst.Add(new ArrangeItem(true, lblKhachDua, numKhachDua));
            lst.Add(new ArrangeItem(SystemConfig.CoThanhToanThe == 30, lblTheATM, numATM));
            lst.Add(new ArrangeItem(SystemConfig.CoThanhToanChuyenKhoan == 30, lblChuyenKhoan, numChuyenKhoan));
            lst.Add(new ArrangeItem(SystemConfig.CoThanhToanChuyenKhoan == 30, lblTaiKhoan, lueDTAIKHOAN));
            lst.Add(new ArrangeItem(SystemConfig.CoThanhToanVoucher == 30, lblCoupon, numCoupon));
            lst.Add(new ArrangeItem(SystemConfig.SuDungTheTraTruoc == 30, lblTheTraTruoc, numTheTraTruoc));
            lst.Add(new ArrangeItem(SystemConfig.SuDungDiemTichLuyDeThanhToan == 30, lblTruTichLuy, numTichLuy));
            lst.Add(new ArrangeItem(true, lblTraLai, numTraLai));

            int oldVal = numTraLai.Top - numDatTruoc.Top;
            int h = UiUtils.ArrangeControl(lst, 5, numDatTruoc.Top);

            int newVal = numTraLai.Top - numDatTruoc.Top;
            this.form.Height -= oldVal - newVal;

            btnInThuBill.Visible = SystemConfig.ChoPhepInTamTinh == 30 && mode == HoaDonMode.SuDungDichVu;

            UpdateKhachDua();

            if (SystemConfig.LuaChonVoucherTuDanhSach == 30)
            {
                numCoupon.ReadOnly = true;
                lblCoupon.Font = new Font(lblCoupon.Font, FontStyle.Bold | FontStyle.Underline);
                lblCoupon.Cursor = Cursors.Hand;
                lblCoupon.Click += new EventHandler(lblCoupon_Click);
            }

            if (mode != HoaDonMode.SuDungDichVu)
            {
                TDONHANGRow dhRow = new TDONHANGRow(TDONHANGID);
                numTheTraTruoc.Value = dhRow.THETRATRUOC;
                numTichLuy.Value = dhRow.TRUTICHLUY;
                numDatTruoc.Value = dhRow.DATTRUOC;
                numNoCu.Value = dhRow.NOCU;
                numCoupon.Value = dhRow.VOUCHER;
                numATM.Value = dhRow.THE;
                numChuyenKhoan.Value = dhRow.CHUYENKHOAN;
                if (dhRow.DTAIKHOANNGANHANGID.Length > 0) lueDTAIKHOAN.EditValue = dhRow.DTAIKHOANNGANHANGID;

                DTHETRATRUOCID = dhRow.DTHETRATRUOCID;
                if (DTHETRATRUOCID.Length > 0) SoTienConLai = NhapTheTraTruoc.GetSoTienConLai(DTHETRATRUOCID, TDONHANGID);
                DVOUCHERID = dhRow.DVOUCHERID;

                UpdateKhachDua();
            }

            numKhachDua.Select();
            numKhachDua.Select(0, numKhachDua.Text.Length);
            if (numTongTien.Value < 0) numKhachDua.Enabled = false;
            btnOK.Enabled = true;
            btnDongBillKhongIn.Enabled = true;
        }

        public string DVOUCHERID = "";
        void lblCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                NhapCoupon formCoupon = (NhapCoupon)Config.CreateForm(Forms.NhapCoupon);
                if (formCoupon.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    DVOUCHERID = formCoupon.VoucherID;
                    numCoupon.Value = formCoupon.GiaTriVoucher;
                    UpdateTraLai();
                }
            }
            catch { }
        }

        public void btnOK_Click(Object sender, EventArgs e)
        {
            string thongBao = "";
            if (mode == HoaDonMode.SuDungDichVu)
            {
                if (!Shared.DuLieuHoaDonOk(Config.Db, TDONHANGID, false, ref thongBao)) return;
            }
            CheckAndClose(DialogResult.OK);
        }

        public decimal KhachDua
        {
            get { return numKhachDua.Value; }
        }

        public decimal Voucher
        {
            get { return numCoupon.Value; }
        }

        public decimal DatTruoc
        {
            get { return numDatTruoc.Value; }
        }

        public decimal TienNo
        {
            get
            {
                if (numTongTien.Value < 0) return 0;
                return numTongTien.Value - (TienThanhToan - numDatTruoc.Value) - numNoCu.Value;
            }
        }

        public decimal TienThanhToan
        {
            get
            {
                if (numTongTien.Value < 0)
                {
                    return numTongTien.Value;
                }
                else
                {
                    return numDatTruoc.Value + Math.Max(0, Math.Min(TienTra, TONGTIEN));
                }
            }
        }

        public int LoaiThanhToan
        {
            get { return 0; }
        }

        public decimal TraLai
        {
            get { return numTraLai.Value; }
        }

        public decimal TheTraTruoc
        {
            get { return numTheTraTruoc.Value; }
        }

        public decimal TruTichLuy
        {
            get { return numTichLuy.Value; }
        }

        public decimal TienMat
        {
            get { return Math.Max(0, numKhachDua.Value - numTraLai.Value); }
        }

        public decimal ChuyenKhoan
        {
            get { return numChuyenKhoan.Value; }
        }

        public decimal TienThe
        {
            get { return numATM.Value; }
        }

        public decimal TienTra
        {
            get
            {
                return KhachDua + Voucher + TheTraTruoc + TruTichLuy + TienThe + ChuyenKhoan;
            }
        }

        private void CheckAndClose(DialogResult result)
        {
            if (!DbUtils.CanLogin(Functions.ThanhToan))
            {
                return;
            }

            if (numTongTien.Value > TienTra)
            {
                if (SystemConfig.ChoPhepKhachNo != 30)
                {
                    Msg.ShowWarning("Chức năng này hiện tại chưa được kích hoạt. Bạn có thể kích hoạt trong menu 'Quản trị'|'Cấu hình toàn hệ thống'");
                    return;
                }

                if (DKHACHHANGID.Length == 0)
                {
                    Msg.ShowWarning("Bạn chưa chọn khách hàng, mời bạn chọn khách hàng trước!");
                    return;
                }

                if (Msg.ShowYesNo("Bạn có muốn cho khách hàng '" + new DKHACHHANGRow(DKHACHHANGID).NAME + "' nợ số tiền '" + (numTongTien.Value - TienTra).ToString("n0") + "' không?") != DialogResult.Yes)
                {
                    return;
                }
            }

            if (numTheTraTruoc.Value > 0 && numTheTraTruoc.Value > SoTienConLai)
            {
                Msg.ShowWarning("Thẻ trả trước chỉ còn " + SoTienConLai.ToString("n0") + ", không thể trả quá số tiền còn lại");
                return;
            }

            if (numChuyenKhoan.Value != 0 && lueDTAIKHOAN.StringValue.Length == 0)
            {
                Msg.ShowWarning("Mời bạn chọn tài khoản");
                lueDTAIKHOAN.showDropDown();
                return;
            }

            form.DialogResult = result;
        }

        public void btnDongBillKhongIn_Click(Object sender, EventArgs e)
        {
            string thongBao = "";
            if (mode == HoaDonMode.SuDungDichVu)
            {
                if (!Shared.DuLieuHoaDonOk(Config.Db, TDONHANGID, false, ref thongBao)) return;
            }
            CheckAndClose(DialogResult.Retry);
        }

        public void chkKhachNo_CheckedChanged(Object sender, EventArgs e)
        {
            if (chkKhachNo.Checked)
            {
                numKhachDua.Value = 0;
                numKhachDua.Enabled = false;
            }
            else
            {
                numKhachDua.Enabled = true;
            }
        }

        public void numKhachDua_OnEditValueChanged(Object sender, Object value)
        {
            UpdateTraLai();
        }

        private void UpdateTraLai()
        {
            if (numNoCu.Value < 0)
            {
                numTraLai.Value = 0;
            }
            else
            {
                if (numCoupon.Value > TONGTIEN)
                {
                    numTraLai.Value = numKhachDua.Value;
                }
                else
                {
                    decimal val = numKhachDua.Value + numCoupon.Value + numATM.Value + numChuyenKhoan.Value + numTheTraTruoc.Value + numTichLuy.Value - TONGTIEN;
                    numTraLai.Value = Math.Max(0, val);
                }
            }
        }

        public void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8) btnInThuBill.PerformClick();
            else if (e.KeyCode == Keys.F9) btnDongBillKhongIn.PerformClick();
        }

        public string DTHETRATRUOCID = "";
        private decimal SoTienConLai = 0;
        public void lblTheTraTruoc_Click(object sender, EventArgs e)
        {
            TDONHANGRow dhRow = new TDONHANGRow(TDONHANGID);
            if (dhRow.DKHACHHANGID.Length > 0)
            {
                DKHACHHANGRow khRow = new DKHACHHANGRow(dhRow.DKHACHHANGID);
                if (khRow.DTHETRATRUOCID.Length > 0)
                {
                    decimal soTienConLai = NhapTheTraTruoc.GetSoTienConLai(khRow.DTHETRATRUOCID, TDONHANGID);
                    if (soTienConLai > 0)
                    {
                        LoadTheTraTruoc(khRow.DTHETRATRUOCID, soTienConLai);
                        return;
                    }
                }
            }

            try
            {
                NhapTheTraTruoc formThe = (NhapTheTraTruoc)Config.CreateForm(Forms.NhapTheTraTruoc);
                formThe.TDONHANGID = TDONHANGID;
                if (formThe.No1Form1.ShowDialog() == DialogResult.OK)
                {
                    LoadTheTraTruoc(formThe.TheTraTruocID, formThe.SoTienConLai);
                }
            }
            catch { }
        }

        private void LoadTheTraTruoc(string TheID, decimal ConLai)
        {
            DTHETRATRUOCID = TheID;
            numTheTraTruoc.ReadOnly = false;

            SoTienConLai = ConLai;
            decimal SuDung = Math.Min(SoTienConLai, TONGTIEN);
            numTheTraTruoc.Value = SuDung;
            UpdateKhachDua();
        }

        private void UpdateKhachDua()
        {
            numKhachDua.Value = Math.Max(0, TONGTIEN - numTichLuy.Value - numTheTraTruoc.Value - numATM.Value - numChuyenKhoan.Value - numCoupon.Value);
            UpdateTraLai();
        }

        public void lblTruTichLuy_Click(object sender, EventArgs e)
        {
            if (DKHACHHANGID.Length == 0)
            {
                Msg.ShowWarning("Vui lòng chọn khách hàng trước");
            }
            else
            {
                try
                {
                    TruTichLuy formTichLuy = (TruTichLuy)Config.CreateForm(Forms.TruTichLuy);
                    formTichLuy.LoadData(DKHACHHANGID, TDONHANGID);
                    if (formTichLuy.No1Form1.ShowDialog() == DialogResult.OK)
                    {
                        numTichLuy.Value = Math.Min(formTichLuy.numGiaTri.Value, TONGTIEN);
                        UpdateKhachDua();
                    }
                }
                catch { }
            }
        }

        public void numATM_OnEditValueChanged(object sender, object value)
        {
            UpdateKhachDua();
        }

        public void numCoupon_KeyDown(object sender, KeyEventArgs e)
        {
            if (numCoupon.ReadOnly && numCoupon.Value > 0 && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                numCoupon.Value = 0;
                DVOUCHERID = "";
            }
        }

        public void btnInThuBill_Click(object sender, EventArgs e)
        {
            if (!DbUtils.CanLogin(Functions.InTamTinh))
            {
                return;
            }
            form.DialogResult = DialogResult.Ignore;
        }

        public void numTichLuy_KeyDown(object sender, KeyEventArgs e)
        {
            if (numTichLuy.ReadOnly && numTichLuy.Value > 0 && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                numTichLuy.Value = 0;
            }
        }
    }

    public class NhapCoupon : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public string VoucherID { get; set; } = "";
        public decimal GiaTriVoucher { get; set; } = 0;
    }

    public class NhapTheTraTruoc : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public string TDONHANGID { get; set; } = "";
        public string TheTraTruocID { get; set; } = "";
        public decimal SoTienConLai { get; set; } = 0;
        public static decimal GetSoTienConLai(string theId, string donHangId) => 0;
    }

    public class TruTichLuy : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;
        public No1Lib.Sys.No1NumericUpDown numGiaTri { get; set; } = new No1Lib.Sys.No1NumericUpDown();
        public void LoadData(string khachHangId, string donHangId) { }
    }
}

namespace No1Run
{
    public class XacNhanThanhToan : QuanLyNhaHang.Forms.XacNhanThanhToan
    {
    }
}
