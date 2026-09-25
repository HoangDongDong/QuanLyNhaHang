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

namespace No1Run
{
    public partial class TheoDoiDatPhong : No1Lib.Sys.No1UserControl
    {
        public No1Lib.Sys.No1UserControl No1UserControl1 { get { return this; } }

        private bool resizeLeft = false;
        private bool resizeRight = false;
        private bool movingArea = false;
        private bool mouseDownArea = false;

        private Timer tmrLoad;
        
        private int StartCol = 2;
        private int StartRow = 2;
        private int NoOfDays = 7;
        private int ColWidth;
        private int lastX = 0;
        private int lastY = 0;
        private int lastWidth = 0;

        private Image endImage;
        private DataGridViewColumn colLoaiPhong;
        private DataGridViewColumn colTenPhong;
        private DataGridViewColumn colTong;
        private MergeCell clsMergeCell = new MergeCell();

        public TheoDoiDatPhong()
        {
            try
            {
                TDONHANG0Ae.EnsureNo1LibInitialized();
            }
            catch { }

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                No1UserControl1_OnInit(this, EventArgs.Empty);
                No1UserControl1_OnAddedToTab(this, EventArgs.Empty);
            }
        }

        private void No1UserControl1_Load(object sender, EventArgs e)
        {
            // Handled via OnLoad
        }

        public void lblSelectedArea_MouseEnter(object sender, EventArgs e)
        {
            lblSelectedArea.Cursor = Cursors.SizeAll;
        }

        public void lblSelectedArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (((!movingArea || (e.Button != MouseButtons.Left)) ? 0 : 1) != 0)
            {
                //thay đổi thông tin ở đây
                //kiểm tra xem có kéo ra khỏi vùng cho phép không?        
                int rowIndex = grMain.HitTest(lblSelectedArea.Location.X, lblSelectedArea.Location.Y).RowIndex;
                int startIndex = grMain.HitTest(lblSelectedArea.Location.X, lblSelectedArea.Location.Y).ColumnIndex;
                int endIndex = grMain.HitTest(lblSelectedArea.Location.X + lblSelectedArea.Size.Width - 10, lblSelectedArea.Location.Y).ColumnIndex;
                bool bAllow = true;
                if (rowIndex <= 1 || startIndex < StartCol || endIndex < StartCol || endIndex >= grMain.Columns.Count - 1 || startIndex >= grMain.Columns.Count - 1)
                {                 
                    bAllow = false;
                }

                //kiểm tra xem dòng có phải là phòng không?
                if (bAllow && grMain.Rows[rowIndex].Tag == null)
                {
                    bAllow = false;
                }

                if (bAllow && (grMain.Columns[startIndex].Tag == null || grMain.Columns[endIndex].Tag == null))
                {
                    bAllow = false;
                }

                if (!bAllow)
                {
                    ShowResizer();
                }
                resizeLeft = false;
                resizeRight = false;
                mouseDownArea = false;
                movingArea = false;

                if (bAllow)
                {
                    //hiển thị xác nhận
                    string TDATHANGID = editingCell != null ? editingCell.TDATHANGID : "";
                    TDATHANGRow dhRow = new TDATHANGRow(TDATHANGID);
                    if (dhRow.IsNull)
                    {
                        CreateGrid(true);
                        return;
                    }

                    DateTime TuNgay = ConvertTo.Date(grMain.Columns[startIndex].Tag);
                    DateTime DenNgay = ConvertTo.Date(grMain.Columns[endIndex].Tag);
                    string DBANID = ConvertTo.String(grMain.Rows[rowIndex].Tag);

                    StringBuilder builder = new StringBuilder();
                    TDATHANGRow upRow = new TDATHANGRow(TDATHANGID);
                    if (TuNgay != dhRow.TUNGAY)
                    {
                        upRow.TUNGAY = TuNgay;
                        builder.AppendLine("Từ ngày: " + dhRow.TUNGAY.ToString("dd/MM/yyyy") + " --> " + TuNgay.ToString("dd/MM/yyyy"));
                    }

                    if (DenNgay != dhRow.DENNGAY)
                    {
                        upRow.DENNGAY = DenNgay;
                        builder.AppendLine("Đến ngày: " + dhRow.DENNGAY.ToString("dd/MM/yyyy") + " --> " + DenNgay.ToString("dd/MM/yyyy"));
                    }

                    if (DBANID != dhRow.DBANID)
                    {
                        upRow.DBANID = DBANID;
                        builder.AppendLine("Phòng: " + new DBANRow(dhRow.DBANID).NAME + " --> " + new DBANRow(DBANID).NAME);
                    }

                    if (builder.Length > 0)
                    {
                        if (Msg.ShowYesNo("Bạn có muốn cập nhật thay đổi phiếu đặt phòng của '" + dhRow.TENKHACH + "'" + Environment.NewLine + builder.ToString()) == DialogResult.Yes)
                        {
                            upRow.Update();                           
                            //cập nhật các phòng theo đoàn nếu có
                            string sql = "UPDATE TDATHANG SET TUNGAY = @TUNGAY, DENNGAY = @DENNGAY WHERE GUID = '" + dhRow.GUID + "' AND ID <> '" + dhRow.ID + "'";
                            FbCommand cmd = Config.Db.GetCommand(sql);
                            cmd.Parameters.Add("@TUNGAY", FbDbType.TimeStamp).Value = TuNgay;
                            cmd.Parameters.Add("@DENNGAY", FbDbType.TimeStamp).Value = DenNgay;                            
                            Config.Db.ExecSql(cmd);

                            //tạo lại grid
                            CreateGrid(true);
                        }
                        else
                        {
                            HideResizer();
                        }
                    }
                }
            }
            else
            {
                resizeLeft = false;
                resizeRight = false;
                mouseDownArea = false;
                movingArea = false;
            }
        }
        
        public static string MonthName(int Month)
        {
            return "Tháng " + Month.ToString();
        }

        public void lblSelectedArea_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownArea = true;
            lastX = e.X;
            lastY = e.Y;
            lastWidth = lblSelectedArea.Size.Width;
            lblSelectedArea.Cursor = Cursors.SizeAll;
        }

        public void lblSelectedArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownArea)
            {
                movingArea = true;                
                int newX = lblSelectedArea.Location.X + e.X - lastX;                
                DataGridView.HitTestInfo hitTestInfo = grMain.HitTest(newX, lblSelectedArea.Location.Y + e.Y - lastY);
                lblSelectedArea.Location = new Point(hitTestInfo.ColumnX, hitTestInfo.RowY);                
                Point location3 = new Point(lblSelectedArea.Location.X + lblSelectedArea.Size.Width,
                    (int)Math.Round(lblSelectedArea.Location.Y + lblSelectedArea.Size.Height / 2.0 - lblRight.Size.Height / 2.0));
                lblRight.Location = location3;
                location3 = lblSelectedArea.Location;
                lblLeft.Location = new Point(location3.X - lblLeft.Size.Width, (int)Math.Round(lblSelectedArea.Location.Y + lblSelectedArea.Size.Height / 2.0 - lblLeft.Size.Height / 2.0));
            }   
        }

        public void lblSelectedArea_DoubleClick(object sender, EventArgs e)
        {
            //sửa
            DoEdit();
        }

        public void lblRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                resizeRight = true;
            }
            
            lblSelectedArea_MouseDown(sender, e);
        }

        public void lblLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                resizeLeft = true;
            }
            
            lblSelectedArea_MouseDown(sender, e);
        }

        public void lblRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (resizeRight)
            {
                movingArea = true;                
                Point location = lblRight.Location;
                DataGridView.HitTestInfo hitTestInfo = grMain.HitTest(location.X - ColWidth + e.X, (int)Math.Round(lblSelectedArea.Location.Y / 2.0));
                int diffX = hitTestInfo.ColumnX - lblRight.Width;
                int offsetX = diffX - lblLeft.Location.X;
                if (offsetX >= 0)
                {
                    lblRight.Location = new Point(diffX + ColWidth + lblRight.Width, lblRight.Location.Y);                    
                    lblSelectedArea.Width = offsetX + ColWidth;
                }
            }   
        }

        public void lblLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (resizeLeft)
            {
                movingArea = true;                
                Point location = lblLeft.Location;
                DataGridView.HitTestInfo hitTestInfo = grMain.HitTest(location.X + e.X, lblLeft.Location.Y + e.Y);
                if (hitTestInfo.ColumnIndex >= StartCol)
                {
                    int columnX = hitTestInfo.ColumnX;
                    int num = lblRight.Location.X - columnX;
                    if (ColWidth <= num)
                    {
                        lblLeft.Location = new Point(columnX - lblLeft.Width, lblLeft.Location.Y);
                        lblSelectedArea.Location = new Point(columnX, lblSelectedArea.Location.Y);                       
                        lblSelectedArea.Width = num;
                    }
                }
            }    
        }

        public void btnChia4_Click(object sender, EventArgs e)
        {
            int val = (int)Math.Round(NoOfDays / 4.0);
            NoOfDays = Math.Max(val, 7);
            CreateGrid(false);
        }

        public void btnChia2_Click(object sender, EventArgs e)
        {
            int val = (int)Math.Round(NoOfDays / 2.0);
            NoOfDays = Math.Max(val, 7);
            CreateGrid(false);
        }

        public void btnNhan2_Click(object sender, EventArgs e)
        {
            int val = NoOfDays * 2;
            NoOfDays = Math.Min(val, 90);
            CreateGrid(false);
        }

        public void btnNhan4_Click(object sender, EventArgs e)
        {
            int val = NoOfDays * 4;
            NoOfDays = Math.Min(val, 90);
            CreateGrid(false);
        }
        
        private void setupEditorPos(int row, int startCell, int endCell)
        {
            lblSelectedArea.Location = grMain.GetCellDisplayRectangle(startCell, row, true).Location;
            lblSelectedArea.Height = grMain.RowTemplate.Height;
            lblSelectedArea.Width = ColWidth * (endCell - startCell + 1);
            Point location = lblSelectedArea.Location;
            lblRight.Location = new Point(location.X + lblSelectedArea.Size.Width, (int)Math.Round(lblSelectedArea.Location.Y + lblSelectedArea.Size.Height / 2.0 - lblRight.Size.Height / 2.0));
            Point location2 = lblSelectedArea.Location;
            lblLeft.Location = new Point(location2.X - lblLeft.Size.Width, (int)Math.Round(lblSelectedArea.Location.Y + lblSelectedArea.Size.Height / 2.0 - lblLeft.Size.Height / 2.0));                
        }
        
        private void HideResizer()
        {
            lblSelectedArea.Width = 0;
            lblSelectedArea.Text = "";            
            lblSelectedArea.Visible = false;
            lblLeft.Visible = false;
            lblRight.Visible = false;
            resizeLeft = false;
            resizeRight = false;
            mouseDownArea = false;
            movingArea = false;
        }

        int COL_TONG_W = 40;
        DataGridViewCellStyle chuNhatStyle;
        DataGridViewCellStyle ngayThuongStyle;
        public void CreateGrid(bool keepCol)
        {                        
            HideResizer();

            int firstDisplayedScrollingRowIndex = grMain.FirstDisplayedScrollingRowIndex;
            int firstDisplayedScrollingColIndex = grMain.FirstDisplayedScrollingColumnIndex;

            grMain.SuspendLayout();

            grMain.Rows.Clear();
            grMain.Columns.Clear();

            colLoaiPhong = AddColumn("LoaiPhong", "", 90, true, true, ngayThuongStyle, DataGridViewContentAlignment.MiddleCenter);
            colTenPhong = AddColumn("TenPhong", "Room", 109, true, true, ngayThuongStyle, DataGridViewContentAlignment.MiddleCenter);
            
            DataGridViewRow rowThang = AddRow();            
            DataGridViewRow rowNgay = AddRow();

            CalculateColumnWidths();

            DateTime toDay = Config.Db != null ? Config.Db.DbDate : DateTime.Today;
            DateTime ngay = dtNgay.DateTime;
            if (ngay == DateTime.MinValue) ngay = toDay;
            DateTime ngayHomQua = ngay;
            int intStartIndex = StartCol;
            //tạo các cột
            for (int i = 0; i < NoOfDays; i++)
            {
                DataGridViewColumn colNgay = AddColumn("objcol" + i.ToString(),
                                                        ngay.Day.ToString("00") + "." + GetNgay(ngay),
                                                        ColWidth, false, true,
                                                        null, DataGridViewContentAlignment.MiddleCenter);
                colNgay.Tag = ngay;

                colNgay.HeaderCell.Style = ngay.DayOfWeek == DayOfWeek.Sunday ? chuNhatStyle : ngayThuongStyle;

                int colIndex = colNgay.Index;                
                if (ngay == toDay)
                {
                    colNgay.DefaultCellStyle.BackColor = Color.LightGray;
                }
                ngayHomQua = ngay;
                ngay = ngay.AddDays(1.0);
                if (ngayHomQua.Month != ngay.Month || i == NoOfDays - 1)
                {
                    clsMergeCell.MakeMerge(ref grMain, 0, intStartIndex, colIndex, Color.SlateGray, Color.White, string.Format("{0} - {1}", MonthName(ngayHomQua.Month), ngayHomQua.Year.ToString()), null, endImage, "", null, null, null, null, "", false);
                    intStartIndex = colIndex + 1;
                }
                grMain.Rows[rowNgay.Index].Cells[colIndex].Value = grMain.Columns[colIndex].HeaderText.ToString();
                grMain.Rows[rowNgay.Index].Cells[colIndex].Style = grMain.Columns[colIndex].HeaderCell.Style;                
            }

            //thêm cột tổng
            colTong = AddColumn("colTong", "Tổng", COL_TONG_W, false, true, null, DataGridViewContentAlignment.MiddleCenter);
            colTong.DefaultCellStyle.BackColor = Color.LightYellow;
            colTong.DefaultCellStyle.ForeColor = Color.Red;
            colTong.DefaultCellStyle.Font = new Font(grMain.Font, FontStyle.Bold);
            rowThang.Cells[colTong.Index].Value = "Tổng";                        

            string sql = "SELECT ID, NAME, MAUCHU, MAUNEN FROM DLOAIPHONG WHERE STATUS = 30";
            if (lueLoaiPhong.StringValue != null && lueLoaiPhong.StringValue.Length > 0)
            {
                sql += " AND ID = '" + lueLoaiPhong.StringValue + "'";
            }
            sql += " ORDER BY SORTORDER";
            DataTable dtLoaiPhong = Config.Db != null ? Config.Db.GetTable(sql) : new DataTable();
            sql = "SELECT ID, NAME, DLOAIPHONGID FROM DBAN WHERE STATUS = 30";
            DataTable dtPhong = Config.Db != null ? Config.Db.GetTable(sql) : new DataTable();

            //lấy ra đặt phòng trong khoảng thời gian
            DataTable dtDat = new DataTable();
            if (Config.Db != null)
            {
                try
                {
                    sql = @"SELECT ID, TUNGAY, DENNGAY, TUGIO, DENGIO, MAUSAC, DBANID, TENKHACH, NOTE, 
(SELECT NAME FROM DMUCDICHDAT WHERE ID = DMUCDICHDATID) AS MUCDICH 
FROM TDATHANG WHERE TUNGAY BETWEEN @FromDate AND @ToDate OR DENNGAY BETWEEN @FromDate AND @ToDate";
                    FbCommand cmd = Config.Db.GetCommand(sql);
                    cmd.Parameters.Add("@FromDate", FbDbType.TimeStamp).Value = dtNgay.DateTime;
                    cmd.Parameters.Add("@ToDate", FbDbType.TimeStamp).Value = dtNgay.DateTime.AddDays(NoOfDays - 1);
                    dtDat = Config.Db.GetTable(cmd);
                }
                catch { }
            }

            Dictionary<DateTime, int> dicTong = new Dictionary<DateTime, int>();

            foreach (DataRow rLoaiPhong in dtLoaiPhong.Rows)
            {
                DLOAIPHONGRow loaiPhong = new DLOAIPHONGRow(rLoaiPhong);
                //tạo group row
                DataGridViewRow rowGroup = new DataGridViewRow();
                rowGroup.CreateCells(grMain);
                rowGroup.Cells[0].Value = loaiPhong.NAME;
                rowGroup.Cells[1].Value = "Phòng";
                Dictionary<DateTime, int> dicTongTheoLoai = new Dictionary<DateTime, int>();
                foreach (DataGridViewCell cell in rowGroup.Cells)
                {
                    cell.Style.BackColor = Color.DimGray;
                    cell.Style.ForeColor = Color.White;
                    cell.Style.Font = new Font(grMain.Font, FontStyle.Bold);
                }
                grMain.Rows.Add(rowGroup);
                //tạo các phòng
                DataRow[] rowsPhong = dtPhong.Select("DLOAIPHONGID='" + loaiPhong.ID + "'", "NAME");
                foreach(DataRow rPhong in rowsPhong)
                {
                    DataGridViewRow rowPhong = new DataGridViewRow();
                    rowPhong.CreateCells(grMain);
                    rowPhong.Cells[0].Value = loaiPhong.NAME;
                    if (loaiPhong.MAUNEN != 0) rowPhong.Cells[0].Style.BackColor = Color.FromArgb(loaiPhong.MAUNEN);
                    if (loaiPhong.MAUCHU != 0) rowPhong.Cells[0].Style.ForeColor = Color.FromArgb(loaiPhong.MAUCHU);
                    rowPhong.Cells[1].Value = rPhong["NAME"].ToString();
                    rowPhong.Cells[1].Style.BackColor = Color.FromArgb(0, 128, 255);
                    rowPhong.Tag = rPhong["ID"].ToString();
                    grMain.Rows.Add(rowPhong);

                    //tạo ra các phiếu đặt hàng
                    DataRow[] rowsDat = dtDat.Select("DBANID = '" + rPhong["ID"].ToString() + "'");
                    bool first = true;
                    decimal TongDong = 0;
                    foreach (DataRow rDat in rowsDat)
                    {
                        TDATHANGRow rowDat = new TDATHANGRow(rDat);
                        string toolTip = rowDat.TENKHACH + Environment.NewLine +
                                         "Từ ngày: " + rowDat.TUNGAY.ToString("dd/MM/yyyy") + Environment.NewLine +
                                         "Đến ngày: " + rowDat.DENNGAY.ToString("dd/MM/yyyy") + Environment.NewLine +
                                         "Mục đích: " + (rowDat.Row.Table.Columns.Contains("MUCDICH") ? rowDat["MUCDICH"].ToString() : "") + Environment.NewLine +
                                         "Yêu cầu khác: " + rowDat.NOTE;

                        int startIndex = StartCol + (int) ((TimeSpan)(rowDat.TUNGAY - dtNgay.DateTime)).TotalDays; 
                        int endIndex = StartCol + (int)((TimeSpan)(rowDat.DENNGAY - dtNgay.DateTime)).TotalDays;

                        int beginCol = Math.Max(StartCol, startIndex);
                        int endCol = Math.Min(StartCol + NoOfDays - 1, endIndex);

                        Color itemColor = rowDat.MAUSAC != 0 ? Color.FromArgb(rowDat.MAUSAC) : Color.DarkGreen;
                        clsMergeCell.MakeMerge(ref grMain, rowPhong.Index, beginCol, endCol, itemColor, Color.White, rowDat.TENKHACH, "", (StartCol + NoOfDays <= endIndex ? null : endImage), toolTip, null, null, null, null, rowDat.ID, startIndex >= StartCol && endIndex < StartCol + NoOfDays);
                        if (first)
                        {
                            rowPhong.Cells[1].Style.BackColor = itemColor;
                            first = false;
                        }

                        TongDong +=  endCol - beginCol;

                        for (int col = beginCol; col <= endCol; col++)
                        {
                            DateTime ngayVal = ConvertTo.Date(grMain.Columns[col].Tag);
                            if (dicTongTheoLoai.ContainsKey(ngayVal))
                            {
                                dicTongTheoLoai[ngayVal] = dicTongTheoLoai[ngayVal] + 1;
                            }
                            else
                            {
                                dicTongTheoLoai.Add(ngayVal, 1);
                            }

                            if (dicTong.ContainsKey(ngayVal))
                            {
                                dicTong[ngayVal] = dicTong[ngayVal] + 1;
                            }
                            else
                            {
                                dicTong.Add(ngayVal, 1);
                            }
                        }
                    }
                    
                    rowPhong.Cells[colTong.Index].Value = TongDong == 0 ? "-" : TongDong.ToString();
                }
                //đặt giá trị tổng theo nhóm
                for (int col = StartCol; col < StartCol + NoOfDays; col++)
                {
                    DateTime ngayVal = ConvertTo.Date(grMain.Columns[col].Tag);
                    int tongGroup = dicTongTheoLoai.ContainsKey(ngayVal) ? dicTongTheoLoai[ngayVal] : 0;
                    rowGroup.Cells[col].Value = tongGroup == 0 ? "-" : tongGroup.ToString();
                }
            }

            //thêm dòng cuối cùng là dòng tổng
            for (int i = 0; i < 4; i++)
            {
                decimal tongCongDaBan = 0;
                decimal tongCongConLai = 0;
                DataGridViewRow rowTotal = new DataGridViewRow();
                rowTotal.CreateCells(grMain);

                //đặt giá trị tổng theo nhóm
                for (int col = StartCol; col < StartCol + NoOfDays; col++)
                {
                    DateTime ngayVal = ConvertTo.Date(grMain.Columns[col].Tag);
                    int tongDaBan = dicTong.ContainsKey(ngayVal) ? dicTong[ngayVal] : 0;                    
                    int conLai = dtPhong.Rows.Count - tongDaBan;
                    tongCongDaBan += tongDaBan;
                    tongCongConLai += conLai;
                    if (i == 0)
                    {
                        rowTotal.Cells[col].Value = tongDaBan == 0 ? "-" : tongDaBan.ToString();
                    }
                    else if (i == 1)
                    {
                        rowTotal.Cells[col].Value = conLai == 0 ? "-" : conLai.ToString();
                    }
                    else if (i == 2)
                    {
                        rowTotal.Cells[col].Value = dtPhong.Rows.Count == 0 ? "-" : dtPhong.Rows.Count.ToString();
                    }
                    else
                    {
                        rowTotal.Cells[col].Value = (tongDaBan == 0 || dtPhong.Rows.Count == 0) ? "-" : Math.Round(((((decimal)(100 * tongDaBan))) / (decimal)dtPhong.Rows.Count), 1).ToString("n1") + "%";
                    }
                }
                
                if (i == 0)
                {
                    rowTotal.Cells[1].Value = "Đã bán";
                    rowTotal.Cells[colTong.Index].Value = tongCongDaBan == 0 ? "-" : tongCongDaBan.ToString();
                }
                else if (i == 1)
                {
                    rowTotal.Cells[1].Value = "Còn lại";
                    rowTotal.Cells[colTong.Index].Value = tongCongConLai == 0 ? "-" : tongCongConLai.ToString();
                }
                else if (i == 2)
                {
                    rowTotal.Cells[1].Value = "Tổng cộng";
                    decimal tongCong = tongCongDaBan + tongCongConLai;
                    rowTotal.Cells[colTong.Index].Value = tongCong == 0 ? "-" : tongCong.ToString();
                }
                else if (i == 3)
                {
                    rowTotal.Cells[1].Value = "Công suất";
                    decimal tongCong = tongCongDaBan + tongCongConLai;
                    rowTotal.Cells[colTong.Index].Value = tongCong == 0 ? "-" : Math.Round((decimal) (100 * tongCongDaBan) / (decimal) (tongCong == 0 ? 1 : tongCong), 1).ToString("n1") + "%";
                }                

                rowTotal.DefaultCellStyle.BackColor = Color.LightYellow;
                rowTotal.DefaultCellStyle.ForeColor = Color.Red;
                rowTotal.DefaultCellStyle.Font = new Font(grMain.Font, FontStyle.Bold);
                grMain.Rows.Add(rowTotal);
            }

            if (grMain.Rows.Count > 2 && firstDisplayedScrollingRowIndex > 0)
            {
                try
                {
                    grMain.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                    if (keepCol && firstDisplayedScrollingColIndex < grMain.ColumnCount)
                    {
                        grMain.FirstDisplayedScrollingColumnIndex = firstDisplayedScrollingColIndex;
                    }
                }
                catch { }
            }

            grMain.PerformLayout();
        }

        private DataGridViewRow AddRow()
        {
            int rowIndex = grMain.Rows.Add();
            DataGridViewRow rowThang = grMain.Rows[rowIndex];
            rowThang.Frozen = true;
            rowThang.ReadOnly = true;
            rowThang.Resizable = DataGridViewTriState.False;
            rowThang.Cells[0].Tag = 0;
            rowThang.Cells[0].Value = "";
            rowThang.Cells[1].Tag = 0;
            rowThang.Cells[1].Value = "Room";
            rowThang.DefaultCellStyle = ngayThuongStyle;
            return rowThang;
        }

        private DataGridViewColumn AddColumn(string colName, string headerText, int colWidth, bool frozen, bool readOnly, DataGridViewCellStyle cellStyle, DataGridViewContentAlignment cellAlignment)
        {
            int colIndex = grMain.Columns.Add(colName, headerText);
            DataGridViewColumn col = grMain.Columns[colIndex];
            col.Width = colWidth;
            col.Frozen = frozen;
            col.ReadOnly = readOnly;
            col.DefaultCellStyle = cellStyle;
            col.DefaultCellStyle.Alignment = cellAlignment;
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            return col;
        }

        private void CalculateColumnWidths()
        {
            ColWidth = 40;

            if (ColWidth * NoOfDays + colLoaiPhong.Width + colTenPhong.Width + 25 + COL_TONG_W < grMain.Width)
            {
                ColWidth = (int)Math.Round((double)(grMain.Width - colLoaiPhong.Width - colTenPhong.Width - 25 - COL_TONG_W) / (double)NoOfDays);
            }
        }

        private string GetNgay(DateTime ngay)
        {
            switch (ngay.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "T2";
                case DayOfWeek.Tuesday:
                    return "T3";
                case DayOfWeek.Thursday:
                    return "T4";
                case DayOfWeek.Wednesday:
                    return "T5";
                case DayOfWeek.Friday:
                    return "T6";
                case DayOfWeek.Saturday:
                    return "T7";
                default:
                    return "CN";
            }
        }

        public void grMain_Scroll(object sender, ScrollEventArgs e)
        {
            HideResizer();
            grMain.Invalidate();
        }

        private MergeCell editingCell;
        public void grMain_MouseDown(object sender, MouseEventArgs e)
        {
            HideResizer();
            if (e.Button == MouseButtons.Left)
            {
                int columnIndex = grMain.HitTest(e.X, e.Y).ColumnIndex;
                int rowIndex = grMain.HitTest(e.X, e.Y).RowIndex;
                if (columnIndex >= StartCol)
                {
                    if (rowIndex >= StartRow)
                    {
                        DataGridViewCell cell = grMain.Rows[rowIndex].Cells[columnIndex];
                        if (cell is MergeCell)
                        {
                            //kiểm tra xem cell này có ngoài vùng phủ sóng không?
                            if ((cell as MergeCell).Resizable)
                            {
                                editingCell = cell as MergeCell;
                                ShowResizer();
                            }
                            else
                            {
                                if (Msg.ShowYesNo("Đặt phòng đang chọn có khoảng thời gian vượt khỏi vùng hiển thị không thể thay đổi bằng cách kéo thả." + Environment.NewLine +
                                                "Bạn có muốn mở cửa sổ để thay đổi khoảng ngày không?") == DialogResult.Yes)
                                {
                                    DoEdit((cell as MergeCell).TDATHANGID);
                                }
                            }
                        }
                    }
                }
            }  
        }

        private void ShowResizer()
        {
            if (editingCell == null) return;
            lblSelectedArea.BringToFront();
            lblRight.BringToFront();
            lblLeft.BringToFront();
            lblSelectedArea.Visible = true;
            lblSelectedArea.Tag = editingCell.TDATHANGID;
            lblSelectedArea.BorderStyle = BorderStyle.FixedSingle;
            lblSelectedArea.Text = editingCell.Value != null ? editingCell.Value.ToString() : "";
            lblSelectedArea.TextAlign = ContentAlignment.MiddleLeft;
            lblSelectedArea.AutoEllipsis = true;
            lblSelectedArea.UseCompatibleTextRendering = true;
            setupEditorPos(editingCell.RowIndex, editingCell.LeftColumn, editingCell.RightColumn);
            lblRight.Visible = true;
            lblLeft.Visible = true;
        }

        public void No1UserControl1_OnInit(object sender, EventArgs e)
        {
            try
            {
                No1System.SetDoubleBuffered(grMain);
            }
            catch { }

            try
            {
                lueLoaiPhong.LoadData(Tables.DLOAIPHONG);
            }
            catch { }

            try
            {
                dtNgay.EditValue = Config.Db != null ? Config.Db.DbDate : DateTime.Today;
            }
            catch
            {
                dtNgay.EditValue = DateTime.Today;
            }

            if (endImage == null)
            {
                string base64 = "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";
                endImage = UiUtils.GetImageFromBase64(base64);
            }

            try
            {
                TạoĐặtPhòngToolStripMenuItem.Image = UiUtils.GetImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAABw0lEQVQ4T6WQy08TYRTFb4opwUihLTW1QCQFQxBIxK6wKAFMkEcReSRIggF2LFzo3rhxI6+FC5NBrQmkBJCw0bhGeQW4JrowwZ1L+CuO936FTmcY3fglv8ntOfecfjMEgP4HE775PEm0GnGyFrFoLcKnWOf8VJHJZh8LQaL3IaKVsnx44uQpxo+fQHR2eLorGWfBGylJi5GRkiw88nsKis45XXd017NAjXeysBhW+MGvSfQfTUBno6mnO/8sUPOtLKZD3PVjFPe+P4TORjsLexRYciV203E4hLb9AXh5oln2N3hdyqmfj3CXh6Gh9oNBE7z1tQfNX7pxZ/c+bu/0oWU7heRWr5lJMnbBqxLWq7bu9Rs0oMHrH5OoWm0ylGcaEFuqR0WmEfEPCZBk7IL5gEVzAXZTsdGI2Ho9vDySjF0wFyCazWNG5pfFHP1ch8ufaqEzqZa/IxnvgmlZfHFJ4bLNawhv1kBno6l3VuIo6Cyk3KkqIHp2UeHQt2oEOQ6djaZe3rFv4JDlR6WP6LGfg0dxKDobzXXcBRfELxduCAnq9C3TmI8NOqtG1CRcFfza5S7Qv5CXpKgQ+wtXRC8VzLtowR9Ui2bclFnmlwAAAABJRU5ErkJggg==");
                MởĐặtPhòngToolStripMenuItem.Image = UiUtils.GetImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAF0SURBVDhPY/j//z8DJRismVgwnYGBfzYDw/mFDAz/lzMwzAfrI9aAqTNn808Bar5ZZ/f//+7Q/ydtRP+vBRlCjAEgzZOmzTi/vKvo//91Hv+/5wj9/98i938d0H6CBsA0Hzpy7H//pCn/F6Z7/v9ZLPr/nisryIDzeA2YncbAP6NA+Xxff/f/XXv3/T924tT/4rKK/93B1qAwOL8GGCY4DQBpnpnKcP7gTJP/h5YG/S8tLfg/Y9ac/81tHf99/APPe3j78uMMRGTNl9a6/T8wzeD/giqN/zFRYaiascUCNs3r6iX/98az/E/2EELYDIt75FjApznbjeF8hivQz+gAZgBZmpG9MCOFIX5ds9b/W3uSwX6GORunzehemJTAcP7MutT/L69M/n9knhvYzwQ1w1xgbGwsn+CjCtZ8dFXq/4l5KsRphhkQGeLZn5aW9j/CXfV/kTfD+Vx3hnisAYYt14ECMdjP5X9ubsb/9q4e4rMm1DAAhHY3OsGP7/4AAAAASUVORK5CYII=");
                XóaĐặtPhòngToolStripMenuItem.Image = UiUtils.GetImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAACFElEQVQ4T6WTT0iTcRjHn3D65nJbr+2dZo3Ci0KE6EC9rpNEl52yS4HFhKyItJIKCwnBlVYUFh0a2b95yYJRHdYunYJJZBZEeogxhJAuecnSt88zt5cF0WWDz37P832e5/v7A6/Yti3lUNawbpw3SIjIlEgXZArcfII2CXfhHjwE+nZRH4JnEHUMtAiZ3wMD9nJf39pMe3tO8/slBg9ERhNVVe/QXz8S2QsbHIM4jRBlp8zbjo7ct54eO9vdvTIdCHziBKEprzeebm5eoJ6kb4duiEH+9Pk/NdBj3qF5QiQGmZlw+PvnSGT1ZVNTNt3SkkV7jlm99v7PQK7TMIbROCap1tYfqVBo5XZ19Ry5XANdlb9OcAmhyLCINcIjJRoaFpONjT/HDWM27vd/HausnKUmF2CwgHOFonCewpDIjceWlUsHg6sxw5i7KHIY7ektt3ue9cW5fxmcRFROi/ROeDzzmbo6e9Lny51FYkh06AzGMZfrI+tIP/mp0kc8RnKc1z3Bvd9b1q83prlMnMTUVGM9oQ6gDcMresM641whSgJX4253bqG21h6sqPjQy0NG0Iu/ToKj632XYfSIiMsxqKdwiN2/mObadE3NEvGVrSXDpWHbem9/l0ibY4C2ncLBA5jsF0kFRPag7QRC8YEHNoMF24IinbtF9pUaeCn4QTdWdFAHNsFGMAqr5tprwhbHoJzP+Q95lHpGrVHH8wAAAABJRU5ErkJggg==");
                RefreshToolStripMenuItem.Image = UiUtils.GetImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAGySURBVDhPY2AgAoh4HQ8A4vVEKEVVIupz3EHM9wQIzxfzO/Ff3P9kAEFDRLyOOYh4H98v6nPiP0iThP/J/5KBp/5LBp36LxV8+r1M6BkBnIYAnZkg6n38P9BGiEagJung0/+Bmv7Lhp39LxcOxBHnsHsFaKsD0Mn/xf1O3pcIONUP1BwgHXqmQC7i7Hn5qHP/FaLP/1eKvfBfKe7Cf+W4iwoYrgA6eb2434kCdAmgpvXK8Rf/qyRe+q+aeGk+EGNqBmkCOhurhGrS5ftqyZcb1FMu4/Y7wZAlR4FWxjUBrcxrpNuqlnRZQSP1ynztzGvvtbOuYxhg0/jIwKbxMaZ3gaFsAAys+UD//gfa/l8398Z5dJfbtz0tcGh7iiEOVgc04D0opDXSrv7Xybn+37Dw1n2zinsNVnUPG+yaH/c7tj+779z9/L9LzwvsqREYtwVg2zOv/dfPv/nfuPTOf4vq+/+Bzv3v2PHsv2vvi//uE14l4A1PoN/362Rf/29QeOu/acW9/1b1D/8Dnf3fpfvFeqBmB4KRAfS7gm7OjfeGRbdJz3kw04HOLzAsuoWRInHZDgDhl8lx1y3KjgAAAABJRU5ErkJggg==");
                XuấtExcelToolStripMenuItem.Image = UiUtils.GetImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAABzElEQVQ4T5XTz2vTYBwG8Pev8eBhl4DUrrVM6GaspVGq1sk6pG6TilIctEwbzEbdIAyMuOZQWKWI4MEdhieP/ie99PdvPHkoj3nekhcsss7AQyDf5/0keUMEAMHUajXXCxbE9fv+WS5mqtUqptPphWHHy1+IAiqVilzcbrfRarVkms0mGo2GDGe9Xg/seVGIAsrlsix1Oh2JzEOcESLCrheJiOfnMVwmBOr1ukIcx4EXV+x80z3o4oOdf+2PbdsQmS9RmM4hHr97gpXiipJul+IIFJaRyN8BO/OvRrBUKkFsnM4Wnfz4gPjxKsK7Qeh7UVzLa7hhBeWMnW63K0OIIWCaJsSDjyF11/LP99g8XEfkWQgxc1Ve/41fYIebx/gQgUKhAGHYAQXoRzrM7wd45GwiZIWx9XkbB18tsDMYDNDv9xVEIJfLQeiWJoHIXhhaUUPw7XUUz95go7oO7cVsxs5wOJSIDxHIZrMQN/NLeLq7DeN1ArodxS1zDfetJF59yuHufgIPzXtgZzQaScSHCGQyGYjQy6uLviLYGY/HEvEhAul0GiKwcwWXyWQykYgPEUilUrMfiUkmk/JJFv1Q/pxdrlGAYRiuF/xn3D+1KAkDRG7PHAAAAABJRU5ErkJggg==");
                NhậpSốNgàyXemToolStripMenuItem.Image = UiUtils.GetImageFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAABuElEQVQ4T42TTUsCYRSFJwMJQWoXCFKEtAhqE/4EN4E7V+nGELUsAyUcUdC9W8Ef4cKtG3+BuJGgtQiCX/iFIn7d7rk5Mg4JCg/nfe8958yIqKiqqiSTyT3S6bSSyWQcTBCKu9GDHBEpyoEChEJsICjjOFiQSCRuuOSZCenZbDa0Xq8JatzBj5y8QTwe97Zare/VakV6lsslaRh38CMnBdFo9HWxWNB8Pj8a+JGTgnA4/IbwdDqlUqlEhUJBznoqlYrMoZjDj5wU+P3+yGw2o/F4LORyud3ZONN28CMnBV6v930ymdBgMBBSqZRovV7fnYvFopy1HfzISYHH4/kYjUbU6/WESCSyO2szaLVapVgsJjv4kZMCt9sdxRPb7TZls1ny+XyiuGvk83kKBAJULpdlBj9yUuByuT77/T7xT3M08CMnBU6n86VWq/10u13qdDo7ms0maejn8MGPnBTY7fZbm80WZL70DIdDajQaBDXu4EdOCviiWCyWPcxm8x2j4rtCcTd6rFbr359p+zGxnjNXzD3zaDKZnhgVijvzwFwzF8wpcvqCE76fbZeXrLZ/wBxh+PBAKfgFcqFa2BgtJlQAAAAASUVORK5CYII=");
            }
            catch { }

            chuNhatStyle = new DataGridViewCellStyle();
            chuNhatStyle.ForeColor = Color.Yellow;
            chuNhatStyle.BackColor = Color.SlateGray;
            ngayThuongStyle = new DataGridViewCellStyle();
            ngayThuongStyle.BackColor = Color.SlateGray;
            ngayThuongStyle.ForeColor = Color.White;
        }
        
        public void No1UserControl1_OnAddedToTab(object sender, EventArgs e)
        {
            tmrLoad = new Timer();
            tmrLoad.Tick += new EventHandler(tmrLoad_Tick);
            tmrLoad.Interval = 10;
            tmrLoad.Enabled = true;
        }

        void tmrLoad_Tick(object sender, EventArgs e)
        {
            tmrLoad.Enabled = false;
            tmrLoad.Dispose();
            CreateGrid(false);
        }

        public void lueLoaiPhong_OnEditValueChanged(object sender, object value)
        {
            CreateGrid(false);
        }

        public void dtNgay_OnEditValueChanged(object sender, object value)
        {
            CreateGrid(false);
        }

        public void NgàyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NoOfDays = 7;
            CreateGrid(false);
        }

        public void NgàyToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            NoOfDays = 15;
            CreateGrid(false);
        }

        public void NgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoOfDays = 30;
            CreateGrid(false);
        }

        public void NgàyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NoOfDays = 60;
            CreateGrid(false);
        }

        public void NgàyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NoOfDays = 90;
            CreateGrid(false);
        }

        public void TạoĐặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicAeForm form = (DynamicAeForm)Config.CreateAeForm(Tables.TDATHANG, 0, "");
            if (form == null) return;
            form.ReLoad("");
            TDATHANGAe codeRunner = form.CodeRunner as TDATHANGAe;
            //tải thông tin phòng và ngày            
            List<string> lst = new List<string>();
            DateTime MinDate = DateTime.MaxValue;
            DateTime MaxDate = DateTime.MinValue;
            foreach (DataGridViewCell cell in grMain.SelectedCells)
            {
                if (cell.ColumnIndex >= StartCol && cell.ColumnIndex < grMain.Columns.Count - 1 && cell.RowIndex >= StartRow && cell.RowIndex < grMain.Rows.Count - 4)
                {
                    DataGridViewRow row = grMain.Rows[cell.RowIndex];
                    if (row.Tag != null)
                    {
                        string DBANID = row.Tag.ToString();
                        if (!lst.Contains(DBANID))
                        {
                            lst.Add(DBANID);
                        }
                    }

                    DataGridViewColumn col = grMain.Columns[cell.ColumnIndex];
                    if (col.Tag != null)
                    {
                        DateTime date = ConvertTo.Date(col.Tag);
                        if (MinDate > date) MinDate = date;
                        if (MaxDate < date) MaxDate = date;
                    }
                }
            }

            if (lst.Count == 0)
            {
                Msg.ShowWarning("Mời bạn chọn vùng có chứa phòng và ngày trước");
                return;
            }

            if (codeRunner != null)
            {
                codeRunner.LoadData(lst, MinDate, MaxDate);
            }
            else if (form.CodeRunner != null)
            {
                try
                {
                    form.CodeRunner.GetType().GetMethod("LoadData", new Type[] { typeof(List<string>), typeof(DateTime), typeof(DateTime) })
                        ?.Invoke(form.CodeRunner, new object[] { lst, MinDate, MaxDate });
                }
                catch { }
            }

            form.ShowDialog();
            if (form.IsDataSaved())
            {
                CreateGrid(true);
            }
        }

        public void MởĐặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoEdit();
        }

        private void DoEdit()
        {
            if (!lblSelectedArea.Visible) return;

            string ID = ConvertTo.String(lblSelectedArea.Tag);
            DoEdit(ID);
        }

        private void DoEdit(string ID)
        {
            if (ID.Length > 0)
            {
                DynamicAeForm form = (DynamicAeForm)Config.CreateAeForm(Tables.TDATHANG, 0, ID);
                if (form == null) return;
                form.ReLoad(ID);
                form.ShowDialog();
                if (form.IsDataSaved())
                {
                    CreateGrid(true);
                }
            }
        }

        public void XóaĐặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoDelete();
        }

        private void DoDelete()
        {
            if (!lblSelectedArea.Visible) return;

            string TDATHANGID = ConvertTo.String(lblSelectedArea.Tag);
            if (TDATHANGID.Length > 0)
            {
                //trường hợp đặt theo đoàn sẽ xóa cả đoàn      
                TDATHANGRow dhRow = new TDATHANGRow(TDATHANGID);
                string sql = "SELECT ID FROM TDATHANG WHERE GUID = '" + dhRow.GUID + "'";
                DataTable dt = Config.Db.GetTable(sql);
                string IDs = "";
                string ChiTietIDs = "";
                foreach (DataRow r in dt.Rows)
                {
                    string ID = r["ID"].ToString();

                    //kiểm tra xem có liên kết nào không?
                    if (DbUtils.CountRef(Tables.TDATHANG, ID) > 0)
                    {
                        Msg.ShowWarning("Bạn không thể xóa đặt phòng này vì đã đặt tiền hoặc đã tạo hóa đơn");
                        return;
                    }
                    if (IDs.Length > 0)
                    {
                        IDs += " OR ";
                        ChiTietIDs += " OR ";
                    }

                    IDs += "ID = '" + ID + "'";
                    ChiTietIDs += "TDATHANGID = '" + ID + "'";
                }

                if (IDs.Length == 0) return;
                if (Msg.ShowYesNo("Bạn có muốn thực hiện xóa đặt phòng đang chọn không?") == DialogResult.Yes)
                {
                    Config.Db.ExecSql("DELETE FROM TDATHANG WHERE " + IDs);
                    Config.Db.ExecSql("DELETE FROM TDATHANGCHITIET WHERE " + ChiTietIDs);
                    CreateGrid(true);
                }
            }
        }

        public void mnuPopUp_Opening(object sender, CancelEventArgs e)
        {
            //kiểm tra xem vùng chọn có chứa ngày nào có thể thực hiện không?
            bool selNgay = false;
            foreach (DataGridViewCell cell in grMain.SelectedCells)
            {
                if (cell.ColumnIndex >= StartCol && cell.ColumnIndex < grMain.Columns.Count - 1 && cell.RowIndex >= StartRow && cell.RowIndex < grMain.Rows.Count - 4)
                {
                    DataGridViewRow row = grMain.Rows[cell.RowIndex];
                    if (row.Tag != null)
                    {
                        selNgay = true;
                        break;
                    }
                }
            }

            TạoĐặtPhòngToolStripMenuItem.Enabled = selNgay && !lblSelectedArea.Visible;
            MởĐặtPhòngToolStripMenuItem.Enabled = lblSelectedArea.Visible;
            XóaĐặtPhòngToolStripMenuItem.Enabled = lblSelectedArea.Visible;
        }

        public void ThángNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime date = Config.Db != null ? Config.Db.DbDate : DateTime.Today;
            date = date.AddDays(1 - date.Day);
            dtNgay.DateTime = date;
            NoOfDays = date.AddMonths(1).AddDays(-1).Day;
            CreateGrid(false);
        }

        public void ThángTrướcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime date = Config.Db != null ? Config.Db.DbDate : DateTime.Today;
            date = date.AddDays(1 - date.Day).AddMonths(-1);
            dtNgay.DateTime = date;
            NoOfDays = date.AddMonths(1).AddDays(-1).Day;
            CreateGrid(false);
        }

        public void ThángSauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime date = Config.Db != null ? Config.Db.DbDate : DateTime.Today;
            date = date.AddDays(1 - date.Day).AddMonths(1);
            dtNgay.DateTime = date;
            NoOfDays = date.AddMonths(1).AddDays(-1).Day;
            CreateGrid(false);
        }

        public void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid(true);
        }

        public void XuấtExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        public void No1UserControl1_KeyDownEx(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                CreateGrid(true);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                TạoĐặtPhòngToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DoDelete();
            }
            else if (e.KeyCode == Keys.F4)
            {
                DoEdit();
            }
        }
    }
}
