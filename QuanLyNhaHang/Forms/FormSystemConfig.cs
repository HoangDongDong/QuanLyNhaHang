using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang
{
    public class NoScrollPanel : Panel
    {
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
    }

    public class FormSystemConfig : Form
    {
        private ListBox lbNav;
        private NoScrollPanel pnlRightContent;
        private TextBox txtSearch;
        private Button btnSave;
        private Button btnClose;

        // Configuration Panels
        private Dictionary<int, Panel> configPanels = new Dictionary<int, Panel>();

        // Controls Map for DB Saving/Loading - KEY = SCONFIG.NAME in Firebird DB
        private Dictionary<string, Control> dbControls = new Dictionary<string, Control>();

        // Template combo keys (CONTROLTYPE=8 with SFORMID in OTHERCONFIG)
        private HashSet<string> templateComboKeys = new HashSet<string> { "MauHoaDon", "MauInCheBien", "MauInChuyenBan" };

        public FormSystemConfig()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.Text = "CẤU HÌNH TOÀN HỆ THỐNG";
            this.Size = new Size(760, 540);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 243, 246);

            // 1. Header Panel
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 44,
                BackColor = Color.White,
                Padding = new Padding(12, 8, 12, 8)
            };

            PictureBox picHeaderIcon = new PictureBox
            {
                Size = new Size(24, 24),
                Location = new Point(12, 10),
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            Bitmap bmpWrench = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage(bmpWrench))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.FromArgb(80, 90, 100), 2.5f))
                {
                    g.DrawEllipse(p, 3, 3, 10, 10);
                    g.DrawLine(p, 11, 11, 20, 20);
                }
            }
            picHeaderIcon.Image = bmpWrench;

            Label lblHeaderTitle = new Label
            {
                Text = "Thông tin cấu hình toàn bộ hệ thống",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 40, 50),
                Location = new Point(42, 11),
                AutoSize = true
            };
            pnlHeader.Controls.Add(picHeaderIcon);
            pnlHeader.Controls.Add(lblHeaderTitle);
            
            Panel pnlHeaderBorder = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 1,
                BackColor = Color.FromArgb(220, 225, 230)
            };
            pnlHeader.Controls.Add(pnlHeaderBorder);

            // 2. Bottom Action Panel
            Panel pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 44,
                BackColor = Color.FromArgb(238, 242, 246)
            };
            Panel pnlBottomBorder = new Panel
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = Color.FromArgb(215, 220, 225)
            };
            pnlBottom.Controls.Add(pnlBottomBorder);

            Panel pnlButtons = new Panel
            {
                Dock = DockStyle.Right,
                Width = 200,
                Padding = new Padding(0, 8, 12, 8)
            };

            btnClose = new Button
            {
                Text = "Thoát",
                Width = 80,
                Dock = DockStyle.Right,
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(180, 190, 200);
            btnClose.Click += (s, e) => this.Close();

            btnSave = new Button
            {
                Text = "Ghi dữ liệu",
                Width = 90,
                Dock = DockStyle.Right,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = Color.FromArgb(245, 247, 250),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(180, 190, 200);
            btnSave.Click += BtnSave_Click;

            Label lblSpacer = new Label { Width = 10, Dock = DockStyle.Right };

            pnlButtons.Controls.Add(btnClose);
            pnlButtons.Controls.Add(lblSpacer);
            pnlButtons.Controls.Add(btnSave);
            pnlBottom.Controls.Add(pnlButtons);

            // 3. Center Container (Dock Fill between Top Header & Bottom Action Panel)
            Panel pnlMainContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Left Navigation Panel (FIXED 175px width)
            Panel pnlLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 175,
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(6, 6, 6, 6)
            };

            lbNav = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                ItemHeight = 22,
                IntegralHeight = false,
                BorderStyle = BorderStyle.FixedSingle,
                DrawMode = DrawMode.OwnerDrawFixed,
                BackColor = Color.White
            };
            lbNav.DrawItem += LbNav_DrawItem;

            string[] navItems = new string[]
            {
                "Thông tin chung",
                "In HĐ và in chế biến",
                "Mẫu hóa đơn",
                "Số phiếu",
                "Bán hàng",
                "Thanh toán",
                "Tích điểm",
                "Kho hàng",
                "Mặt hàng",
                "Thiết bị khác",
                "Cảnh báo",
                "Quản trị",
                "Cảm ứng",
                "Tùy chọn khác"
            };
            lbNav.Items.AddRange(navItems);
            lbNav.SelectedIndexChanged += LbNav_SelectedIndexChanged;

            Panel pnlSearch = new Panel { Dock = DockStyle.Bottom, Height = 28, Padding = new Padding(0, 4, 0, 0) };
            txtSearch = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 8.5F), Text = "Tìm kiếm (Ctrl + F)" };
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == "Tìm kiếm (Ctrl + F)") { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Tìm kiếm (Ctrl + F)"; txtSearch.ForeColor = Color.Gray; } };

            pnlSearch.Controls.Add(txtSearch);
            pnlLeft.Controls.Add(pnlSearch); // Bottom dock first
            pnlLeft.Controls.Add(lbNav);    // Fill dock second

            // Vertical Splitter Line
            Panel pnlVerticalLine = new Panel
            {
                Dock = DockStyle.Left,
                Width = 1,
                BackColor = Color.FromArgb(215, 220, 225)
            };

            // Right Content Area
            pnlRightContent = new NoScrollPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(12),
                AutoScroll = true
            };

            pnlMainContent.Controls.Add(pnlRightContent);
            pnlMainContent.Controls.Add(pnlVerticalLine);
            pnlMainContent.Controls.Add(pnlLeft);

            // WinForms docking order: Add Fill FIRST so Top & Bottom dock outside of it!
            this.Controls.Add(pnlMainContent);
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlHeader);

            // Build all panels
            BuildAllConfigPanels();

            // Default Select first item
            if (lbNav.Items.Count > 0)
            {
                lbNav.TopIndex = 0;
                lbNav.SelectedIndex = 0;
            }

            this.Load += FormSystemConfig_Load;
            this.Shown += FormSystemConfig_Shown;
        }

        private void LbNav_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lbNav.Items.Count) return;
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color backColor = isSelected ? Color.FromArgb(0, 120, 215) : Color.White;
            Color textColor = isSelected ? Color.White : Color.FromArgb(30, 30, 30);
            Color iconColor = isSelected ? Color.White : Color.FromArgb(0, 120, 215);

            using (SolidBrush bgBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            // Draw Icon
            DrawMenuIcon(e.Graphics, e.Index, new Point(e.Bounds.X + 4, e.Bounds.Y + 3), iconColor);

            // Draw Text
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                string text = lbNav.Items[e.Index].ToString();
                using (Font font = new Font("Segoe UI", 8.75F, isSelected ? FontStyle.Bold : FontStyle.Regular))
                {
                    e.Graphics.DrawString(text, font, textBrush, e.Bounds.X + 24, e.Bounds.Y + 2);
                }
            }
        }

        private void DrawMenuIcon(Graphics g, int index, Point loc, Color color)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int x = loc.X;
            int y = loc.Y;

            using (Pen pen = new Pen(color, 1.4f))
            using (SolidBrush brush = new SolidBrush(color))
            {
                switch (index)
                {
                    case 0: // Thông tin chung (House)
                        g.DrawPolygon(pen, new Point[] { new Point(x + 7, y + 1), new Point(x + 1, y + 7), new Point(x + 13, y + 7) });
                        g.DrawRectangle(pen, x + 3, y + 7, 8, 7);
                        break;
                    case 1: // In HĐ (Printer)
                        g.DrawRectangle(pen, x + 2, y + 4, 10, 6);
                        g.DrawRectangle(pen, x + 4, y + 1, 6, 3);
                        g.DrawRectangle(pen, x + 4, y + 10, 6, 4);
                        break;
                    case 2: // Mẫu hóa đơn (Document)
                        g.DrawRectangle(pen, x + 3, y + 1, 8, 12);
                        g.DrawLine(pen, x + 5, y + 4, x + 9, y + 4);
                        g.DrawLine(pen, x + 5, y + 7, x + 9, y + 7);
                        g.DrawLine(pen, x + 5, y + 10, x + 9, y + 10);
                        break;
                    case 3: // Số phiếu (#)
                        g.DrawLine(pen, x + 5, y + 2, x + 4, y + 12);
                        g.DrawLine(pen, x + 10, y + 2, x + 9, y + 12);
                        g.DrawLine(pen, x + 2, y + 5, x + 12, y + 5);
                        g.DrawLine(pen, x + 2, y + 9, x + 12, y + 9);
                        break;
                    case 4: // Bán hàng (Shopping Cart)
                        g.DrawLine(pen, x + 1, y + 2, x + 4, y + 2);
                        g.DrawLine(pen, x + 4, y + 2, x + 6, y + 9);
                        g.DrawLine(pen, x + 6, y + 9, x + 12, y + 9);
                        g.DrawLine(pen, x + 12, y + 9, x + 13, y + 4);
                        g.DrawLine(pen, x + 13, y + 4, x + 4, y + 4);
                        g.FillEllipse(brush, x + 5, y + 11, 3, 3);
                        g.FillEllipse(brush, x + 10, y + 11, 3, 3);
                        break;
                    case 5: // Thanh toán (Card)
                        g.DrawRectangle(pen, x + 1, y + 3, 13, 9);
                        g.FillRectangle(brush, x + 1, y + 5, 13, 3);
                        break;
                    case 6: // Tích điểm (Star)
                        PointF[] star = new PointF[] {
                            new PointF(x + 7, y + 1), new PointF(x + 9, y + 5),
                            new PointF(x + 13, y + 5), new PointF(x + 10, y + 8),
                            new PointF(x + 11, y + 13), new PointF(x + 7, y + 10),
                            new PointF(x + 3, y + 13), new PointF(x + 4, y + 8),
                            new PointF(x + 1, y + 5), new PointF(x + 5, y + 5)
                        };
                        g.FillPolygon(brush, star);
                        break;
                    case 7: // Kho hàng (Box)
                        g.DrawRectangle(pen, x + 2, y + 3, 11, 10);
                        g.DrawLine(pen, x + 2, y + 3, x + 7, y + 7);
                        g.DrawLine(pen, x + 13, y + 3, x + 7, y + 7);
                        g.DrawLine(pen, x + 7, y + 7, x + 7, y + 13);
                        break;
                    case 8: // Mặt hàng (Grid)
                        g.DrawRectangle(pen, x + 2, y + 2, 4, 4);
                        g.DrawRectangle(pen, x + 8, y + 2, 4, 4);
                        g.DrawRectangle(pen, x + 2, y + 8, 4, 4);
                        g.DrawRectangle(pen, x + 8, y + 8, 4, 4);
                        break;
                    case 9: // Thiết bị khác (Monitor)
                        g.DrawRectangle(pen, x + 1, y + 2, 13, 8);
                        g.DrawLine(pen, x + 4, y + 13, x + 11, y + 13);
                        g.DrawLine(pen, x + 7, y + 10, x + 7, y + 13);
                        break;
                    case 10: // Cảnh báo (Warning Triangle)
                        g.DrawPolygon(pen, new Point[] { new Point(x + 7, y + 1), new Point(x + 1, y + 13), new Point(x + 13, y + 13) });
                        g.DrawLine(pen, x + 7, y + 5, x + 7, y + 9);
                        g.FillRectangle(brush, x + 6, y + 11, 2, 2);
                        break;
                    case 11: // Quản trị (User)
                        g.DrawEllipse(pen, x + 4, y + 1, 6, 6);
                        g.DrawArc(pen, x + 1, y + 8, 12, 7, 180, 180);
                        break;
                    case 12: // Cảm ứng (Touch)
                        g.DrawRectangle(pen, x + 3, y + 1, 9, 13);
                        g.FillEllipse(brush, x + 6, y + 11, 3, 3);
                        break;
                    case 13: // Tùy chọn khác (Gear)
                        g.DrawEllipse(pen, x + 4, y + 4, 6, 6);
                        g.DrawLine(pen, x + 7, y + 1, x + 7, y + 13);
                        g.DrawLine(pen, x + 1, y + 7, x + 13, y + 7);
                        g.DrawLine(pen, x + 3, y + 3, x + 11, y + 11);
                        g.DrawLine(pen, x + 11, y + 3, x + 3, y + 11);
                        break;
                    default:
                        g.DrawRectangle(pen, x + 2, y + 2, 10, 10);
                        break;
                }
            }
        }

        private void LbNav_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = lbNav.SelectedIndex;
            pnlRightContent.Controls.Clear();
            if (configPanels.TryGetValue(idx, out Panel targetPanel))
            {
                targetPanel.Dock = DockStyle.Fill;
                pnlRightContent.Controls.Add(targetPanel);
                pnlRightContent.AutoScrollPosition = new Point(0, 0);
            }
        }

        private void BuildAllConfigPanels()
        {
            configPanels[0] = BuildPanel0_ThongTinChung();
            configPanels[1] = BuildPanel1_InHDVaCheBien();
            configPanels[2] = BuildPanel2_MauHoaDon();
            configPanels[3] = BuildPanel3_SoPhieu();
            configPanels[4] = BuildPanel4_BanHang();
            configPanels[5] = BuildPanel5_ThanhToan();
            configPanels[6] = BuildPanel6_TichDiem();
            configPanels[7] = BuildPanel7_KhoHang();
            configPanels[8] = BuildPanel8_MatHang();
            configPanels[9] = BuildPanel9_ThietBiKhac();
            configPanels[10] = BuildPanel10_CanhBao();
            configPanels[11] = BuildPanel11_QuanTri();
            configPanels[12] = BuildPanel12_CamUng();
            configPanels[13] = BuildPanel13_TuyChonKhac();
        }

        // =====================================================================
        // PANEL 0: Thông tin chung (DB Group: Thông tin chung)
        // =====================================================================
        private Panel BuildPanel0_ThongTinChung()
        {
            Panel p = CreateContentPanel();

            AddRow(p, 10, "Tên công ty:", CreateTextBox("CompanyName", ""));
            AddRow(p, 40, "", new Label { Text = "(Tên công ty sẽ hiển thị dưới báo cáo)", Font = new Font("Segoe UI", 8F, FontStyle.Italic), ForeColor = Color.Gray, AutoSize = true });
            
            TextBox txtAddr = CreateTextBox("CompanyAddress", "");
            txtAddr.Multiline = true;
            txtAddr.Height = 60;
            AddRow(p, 65, "Địa chỉ:", txtAddr);

            AddRow(p, 135, "Số điện thoại:", CreateTextBox("CompanyPhone", ""));
            AddRow(p, 165, "Email:", CreateTextBox("CompanyEmail", ""));
            AddRow(p, 195, "Lời cảm ơn:", CreateTextBox("LoiCamOn", ""));
            AddRow(p, 225, "Fax:", CreateTextBox("CompanyFax", ""));

            // Logo
            Label lblLogo = new Label { Text = "Logo:", Location = new Point(410, 65), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            PictureBox picLogo = new PictureBox { Location = new Point(450, 65), Size = new Size(70, 70), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            Button btnSelectLogo = new Button { Text = "Chọn", Location = new Point(450, 140), Size = new Size(70, 26), Font = new Font("Segoe UI", 8.5F) };

            p.Controls.Add(lblLogo);
            p.Controls.Add(picLogo);
            p.Controls.Add(btnSelectLogo);

            return p;
        }

        // =====================================================================
        // PANEL 1: In HĐ và in chế biến (DB Group: In HĐ và in chế biến)
        // =====================================================================
        private Panel BuildPanel1_InHDVaCheBien()
        {
            Panel p = CreateContentPanel();

            AddCheckBox(p, 10, 10, "Lựa chọn mẫu khi in", "LuaChonMauKhiIn");
            AddCheckBox(p, 220, 10, "Hiển thị trước khi in", "HienThiTruocKhiIn");

            AddLabel(p, 10, 40, "Mẫu hóa đơn");
            AddComboBox(p, 100, 36, 130, "MauHoaDon", new string[0]);
            AddLabel(p, 240, 40, "Số lần in");
            AddTextBox(p, 310, 36, 60, "SoLanIn", "1");

            AddCheckBox(p, 10, 70, "Sử dụng chức năng in xuống bếp", "SuDungChucNangInXuongBep");
            AddCheckBox(p, 30, 95, "In đồ ăn", "InDoAn");
            AddCheckBox(p, 120, 95, "In đồ uống", "InDoUong");
            AddCheckBox(p, 210, 95, "In dịch vụ", "InDichVu");
            AddCheckBox(p, 300, 95, "In đồ khác", "InDoKhac");

            AddLabel(p, 10, 130, "Mẫu in chế biến");
            AddComboBox(p, 110, 126, 130, "MauInCheBien", new string[0]);
            AddLabel(p, 240, 130, "Số liên in chế biến");
            AddTextBox(p, 350, 126, 60, "SoLienInCheBien", "1");

            AddCheckBox(p, 10, 160, "In thêm 1 liên tại quầy (ra máy in mặc định)", "InThem1LienTaiQuay");
            AddCheckBox(p, 10, 185, "In mỗi đồ ra 1 tờ (In xong từng món cắt giấy ngay)", "InMoiDoRa1To");
            AddCheckBox(p, 10, 210, "In riêng đồ ăn/đồ uống/đồ khác nếu chung máy in", "InRiengDoAnUong");
            AddCheckBox(p, 10, 235, "Tự động in pha chế sau khi gọi món", "TuDongInPhaCheSauKhiGoiMon");
            AddLabel(p, 260, 237, "Thời gian chờ tự động in (giây)");
            AddTextBox(p, 420, 234, 50, "ThoiGianTuDongIn", "10");

            AddCheckBox(p, 10, 260, "In pha chế theo khu vực", "InPhaCheTheoKhuVuc");
            AddCheckBox(p, 10, 285, "In thông báo khi chuyển bàn", "InThongBaoKhiChuyenBan");

            AddLabel(p, 10, 315, "Mẫu in chuyển bàn");
            AddComboBox(p, 140, 312, 180, "MauInChuyenBan", new string[0]);
            AddLabel(p, 10, 345, "In hóa đơn theo khu vực");
            AddComboBox(p, 140, 342, 280, "InHoaDonTheoKhuVuc", new string[0]);
            AddCheckBox(p, 10, 375, "In mật khẩu wifi trên bill", "InMatKhauWifiTrenBill");

            return p;
        }

        // =====================================================================
        // PANEL 2: Mẫu hóa đơn (DB Group: Mẫu hóa đơn) - Developer locked
        // =====================================================================
        private Panel BuildPanel2_MauHoaDon()
        {
            Panel p = CreateContentPanel();
            AddLabel(p, 10, 10, "Phần này dành cho nhà phát triển, mời bạn nhập mật khẩu:");
            TextBox txtPass = AddTextBox(p, 10, 35, 120, "DevTemplatePass", "");
            txtPass.PasswordChar = '*';
            Button btnUnlock = new Button { Text = "Mở khóa", Location = new Point(140, 33), Size = new Size(75, 26), Font = new Font("Segoe UI", 9F) };
            p.Controls.Add(btnUnlock);
            return p;
        }

        // =====================================================================
        // PANEL 3: Số phiếu (DB: FORMAT_T* records in no-group)
        // =====================================================================
        private Panel BuildPanel3_SoPhieu()
        {
            Panel p = CreateContentPanel();
            int y = 10;

            // Each row maps: Label text → DB NAME key
            string[,] fields = new string[,]
            {
                { "Báo giá", "FORMAT_TBAOGIA" },
                { "Hóa đơn nhà hàng", "FORMAT_TSOHOADON" },
                { "Phiếu nhập kho", "FORMAT_TPHIEUNHAPKHO" },
                { "Phiếu xuất kho", "FORMAT_TPHIEUXUATKHO" },
                { "Phiếu chuyển kho", "FORMAT_TPHIEUCHUYENKHO" },
                { "Phiếu kiểm kê", "FORMAT_TPHIEUKIEMKE" },
                { "Đặt hàng", "FORMAT_TDATHANG" },
                { "Phiếu thu", "FORMAT_TPHIEUTHU" },
                { "Phiếu chi", "FORMAT_TPHIEUCHI" },
                { "Phiếu thu công nợ", "FORMAT_TPHIEUTHUCONGNO" },
                { "Bảng lương", "FORMAT_TBANGLUONG" }
            };

            for (int i = 0; i < fields.GetLength(0); i++)
            {
                string label = fields[i, 0];
                string dbKey = fields[i, 1];
                AddLabel(p, 10, y + 4, label);
                TextBox txt = AddTextBox(p, 140, y, 220, dbKey, "");
                Button btnDots = new Button { Text = "...", Location = new Point(365, y), Size = new Size(25, 24), Font = new Font("Segoe UI", 8F) };
                btnDots.Click += (s, e) => ShowFormatConfigDialog(label, txt);
                p.Controls.Add(btnDots);
                y += 30;
            }
            return p;
        }

        /// <summary>
        /// Opens a dialog to configure the ticket number format pattern.
        /// Shows help text for wildcards: (*), (yy), (yyyy), (MM), (dd).
        /// </summary>
        private void ShowFormatConfigDialog(string label, TextBox targetTextBox)
        {
            Form dlg = new Form
            {
                Text = "Cấu hình cách sinh " + label,
                Size = new Size(500, 380),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(235, 240, 248)
            };

            // Header
            Panel pnlDlgHeader = new Panel { Dock = DockStyle.Top, Height = 46, BackColor = Color.FromArgb(210, 220, 235) };
            Label lblDlgTitle = new Label
            {
                Text = "    Thiết lập cách sinh " + label,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 40, 70),
                Location = new Point(10, 12),
                AutoSize = true
            };
            pnlDlgHeader.Controls.Add(lblDlgTitle);

            // Buttons panel
            Panel pnlDlgButtons = new Panel { Dock = DockStyle.Bottom, Height = 42, Padding = new Padding(8, 6, 8, 8) };
            Button btnDlgClose = new Button
            {
                Text = "Thoát",
                Width = 70,
                Dock = DockStyle.Right,
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDlgClose.FlatAppearance.BorderColor = Color.FromArgb(180, 190, 200);
            Button btnDlgSave = new Button
            {
                Text = "Ghi dữ liệu",
                Width = 90,
                Dock = DockStyle.Right,
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDlgSave.FlatAppearance.BorderColor = Color.FromArgb(180, 190, 200);
            Label lblBtnSpacer = new Label { Width = 10, Dock = DockStyle.Right };
            pnlDlgButtons.Controls.Add(btnDlgSave);
            pnlDlgButtons.Controls.Add(lblBtnSpacer);
            pnlDlgButtons.Controls.Add(btnDlgClose);

            // Content Panel
            Panel pnlDlgContent = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12) };

            // Mẫu row
            Label lblMau = new Label { Text = "Mẫu:", Location = new Point(8, 14), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            TextBox txtMau = new TextBox
            {
                Location = new Point(55, 11),
                Width = 180,
                Height = 24,
                Font = new Font("Segoe UI", 10F),
                Text = targetTextBox.Text,
                BackColor = Color.FromArgb(0, 80, 160),
                ForeColor = Color.White
            };

            // Range description
            Label lblRange = new Label
            {
                Location = new Point(245, 14),
                AutoSize = true,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(50, 50, 50)
            };

            Action updateRange = () =>
            {
                string pattern = txtMau.Text.Trim();
                int starCount = 0;
                foreach (char c in pattern) if (c == '*') starCount++;
                if (starCount > 0)
                {
                    string maxNum = new string('9', starCount);
                    string minNum = new string('0', starCount - 1) + "1";
                    string prefix = pattern.Replace("(" + new string('*', starCount) + ")", "");
                    lblRange.Text = $"Có {maxNum} chuỗi từ {prefix}{minNum} đến {prefix}{maxNum}";
                }
                else lblRange.Text = "";
            };
            updateRange();
            txtMau.TextChanged += (s, e) => updateRange();

            // Help text
            string helpText =
                "Sử dụng (*) dành cho phần số tự động tăng do hệ thống sinh ra, độ dài do số lượng dấu sao quy\r\n" +
                "định, tối đa là 9.\r\n" +
                "Ví dụ:\r\n" +
                "HD(**) gồm 99 số chạy từ HD01, HD02 đến HD99\r\n" +
                "HD(***) gồm 999 số chạy từ HD001, HD002 đến HD999\r\n\r\n" +
                "Sử dụng (MM) để lấy tháng hiện tại\r\n" +
                "Sử dụng (yy) để lấy năm hiện tại (2 số cuối của năm)\r\n" +
                "Sử dụng (yyyy) để lấy năm hiện tại (cả 4 số)\r\n" +
                "Sử dụng (dd) để lấy ngày hiện tại\r\n\r\n" +
                "Nếu số có chứa năm, (*) sẽ chạy lại từ 01 ở đầu năm mới\r\n" +
                "Nếu số có chứa tháng, (*) sẽ chạy lại từ 01 ở đầu tháng mới\r\n" +
                "Nếu số có chứa ngày, (*) sẽ chạy lại từ 01 ở đầu ngày mới";

            Label lblHelp = new Label
            {
                Text = helpText,
                Location = new Point(8, 48),
                Size = new Size(440, 210),
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(40, 40, 40)
            };

            pnlDlgContent.Controls.Add(lblMau);
            pnlDlgContent.Controls.Add(txtMau);
            pnlDlgContent.Controls.Add(lblRange);
            pnlDlgContent.Controls.Add(lblHelp);

            btnDlgSave.Click += (s, e) =>
            {
                targetTextBox.Text = txtMau.Text.Trim();
                dlg.Close();
            };
            btnDlgClose.Click += (s, e) => dlg.Close();

            // WinForms dock order: Fill first, then Bottom, then Top
            dlg.Controls.Add(pnlDlgContent);
            dlg.Controls.Add(pnlDlgButtons);
            dlg.Controls.Add(pnlDlgHeader);

            dlg.ShowDialog(this);
        }

        // =====================================================================
        // PANEL 4: Bán hàng (DB Group: Bán hàng)
        // =====================================================================
        private Panel BuildPanel4_BanHang()
        {
            Panel p = CreateContentPanel();

            AddCheckBox(p, 10, 10, "Cho phép nhập giảm giá", "ChoPhepNhapGiamGia");
            AddLabel(p, 30, 38, "Mặc định giảm giá đồ ăn (%)");
            AddTextBox(p, 190, 35, 50, "MacDinhGiamGia", "0");
            AddLabel(p, 255, 38, "Mặc định giảm giá tiền giờ (%)");
            AddTextBox(p, 420, 35, 50, "MacDinhGiamGiaTienGio", "0");

            AddCheckBox(p, 10, 65, "Có thuế suất", "CoThueSuat");
            AddLabel(p, 255, 68, "Mặc định thuế suất (%)");
            AddTextBox(p, 420, 65, 50, "MacDinhThueSuat", "10");

            AddCheckBox(p, 10, 95, "Có phí dịch vụ", "CoPhiDichVu");
            AddLabel(p, 255, 98, "Mặc định phí dịch vụ (%)");
            AddTextBox(p, 420, 95, 50, "MacDinhPhiDichVu", "10");

            AddCheckBox(p, 10, 125, "Nhập số lượng sau khi chọn", "HienThiCuaSoNhapSoLuongKhiQuetMaVach");
            AddCheckBox(p, 255, 125, "Cho phép thay đổi ngày trên hóa đơn", "ChoPhepThayDoiNgayTrenHoaDon");

            AddCheckBox(p, 10, 150, "Bắt buộc nhập nhân viên bán hàng", "BatBuocNhapNhanVienBanHang");
            AddCheckBox(p, 255, 150, "Cho phép in tạm tính", "ChoPhepInTamTinh");

            AddCheckBox(p, 10, 175, "Kích hoạt khuyến mại tự động", "KichHoatKhuyenMaiTuDong");
            AddCheckBox(p, 255, 175, "Cho phép trùng tên khách hàng", "ChoPhepTrungTenKhachHang");

            AddCheckBox(p, 10, 200, "Hiển thị 3 nhóm ở giao diện bán hàng", "HienThi3NhomOGiaoDienBanHang");
            AddCheckBox(p, 255, 200, "Tối ưu dùng bàn phím", "ToiUuDungBanPhim");

            AddCheckBox(p, 10, 225, "Sử dụng mặt hàng mặc định", "SuDungMatHangMacDinh");
            AddCheckBox(p, 255, 225, "Hiển thị ghi chú trên giao diện bàn", "HienThiGhiChuTrenGiaoDienBan");

            AddCheckBox(p, 10, 250, "Mặt hàng giá theo giờ theo khu vực", "SuDungGiaTheoGio");
            AddLabel(p, 255, 253, "Cách chọn giờ tính giá");
            AddComboBox(p, 380, 250, 110, "CachChonGioTinhGia", new string[0]);

            AddLabel(p, 10, 280, "Cách chọn khách hàng");
            AddComboBox(p, 180, 277, 200, "CachChonKhachHang", new string[0]);

            AddLabel(p, 10, 310, "Cách chọn ngày giao dịch");
            AddComboBox(p, 180, 307, 200, "CachChonNgayGiaoDich", new string[0]);
            AddLabel(p, 200, 340, "Trước giờ tính vào ngày hôm trước");
            AddTextBox(p, 390, 337, 50, "TruocGioTinhVaoNgayHomTruoc", "0");

            AddLabel(p, 10, 370, "Kích thước hiển thị ở giao diện dịch vụ");
            AddComboBox(p, 220, 367, 120, "KichThuocHienThiOGiaoDienDichVu", new string[0]);

            AddCheckBox(p, 10, 400, "In hóa đơn cộng gộp mặt hàng", "InHoaDonCongGopMatHang");

            return p;
        }

        // =====================================================================
        // PANEL 5: Thanh toán (DB Group: Thanh toán)
        // =====================================================================
        private Panel BuildPanel5_ThanhToan()
        {
            Panel p = CreateContentPanel();

            AddCheckBox(p, 10, 10, "Cho phép khách nợ", "ChoPhepKhachNo");
            AddCheckBox(p, 10, 35, "Có thanh toán voucher", "CoThanhToanVoucher");
            AddCheckBox(p, 30, 60, "Lựa chọn voucher từ danh sách", "LuaChonVoucherTuDanhSach");
            AddCheckBox(p, 10, 85, "Sử dụng thẻ trả trước", "SuDungTheTraTruoc");
            AddCheckBox(p, 10, 110, "Sử dụng điểm tích lũy để thanh toán", "SuDungDiemTichLuyDeThanhToan");
            AddLabel(p, 30, 138, "Quy đổi 1 điểm sang tiền");
            AddTextBox(p, 180, 135, 70, "QuyDoi1DiemSangTien", "1000");

            AddCheckBox(p, 10, 165, "Có thanh toán thẻ", "CoThanhToanThe");
            AddCheckBox(p, 10, 190, "Có thanh toán chuyển khoản", "CoThanhToanChuyenKhoan");

            AddLabel(p, 10, 223, "Làm tròn tiền");
            AddTextBox(p, 110, 220, 70, "LamTronTien", "1000");

            AddCheckBox(p, 10, 250, "Bắt buộc in khi thanh toán", "BatBuocInKhiThanhToan");
            AddCheckBox(p, 10, 275, "Sử dụng chức năng tạm ứng trong đơn hàng", "SuDungChucNangTamUngTrongDonHang");

            return p;
        }

        // =====================================================================
        // PANEL 6: Tích điểm (DB Group: Tích điểm)
        // =====================================================================
        private Panel BuildPanel6_TichDiem()
        {
            Panel p = CreateContentPanel();
            AddLabel(p, 10, 13, "Doanh số tương ứng với 1 điểm");
            AddTextBox(p, 190, 10, 80, "DoanhSoTuongUngVoi1Diem", "20000");

            AddLabel(p, 10, 43, "Cách tính điểm");
            AddComboBox(p, 190, 40, 200, "CachTinhDiem", new string[0]);

            AddCheckBox(p, 200, 70, "Tự động nâng cấp thành viên khi đạt hạn mức", "TuDongNangCapThanhVienKhiDatHanMuc");
            AddCheckBox(p, 200, 95, "Hiển thị điểm của khách hàng trên hóa đơn", "HienThiDiemCuaKhachHangTrenHoaDon");

            return p;
        }

        // =====================================================================
        // PANEL 7: Kho hàng (DB Group: Kho hàng)
        // =====================================================================
        private Panel BuildPanel7_KhoHang()
        {
            Panel p = CreateContentPanel();
            AddCheckBox(p, 10, 10, "Cho phép nhập một mặt hàng nhiều lần trong phiếu", "NhapMotMatHangNhieuLanTrongPhieu");
            AddCheckBox(p, 10, 35, "Bắt buộc chọn nhân viên trong nhập kho", "BatBuocChonNhanVienTrongNhapKho");
            AddCheckBox(p, 10, 60, "Bắt buộc chọn nhà cung cấp trong nhập kho", "BatBuocChonNhaCungCapTrongNhapKho");
            AddCheckBox(p, 10, 85, "Sử dụng 2 đơn vị tính", "SuDung2DonViTinh");
            AddCheckBox(p, 10, 110, "Tự động tính giá vốn", "TuDongTinhGiaVon");
            AddCheckBox(p, 10, 135, "Nhập kho bằng đầu đọc mã vạch", "NhapKhoBangDauDocMaVach");
            AddCheckBox(p, 10, 160, "Sử dụng nhiều kho", "SuDungNhieuKho");
            AddCheckBox(p, 10, 185, "Tự động cập nhật giá nhập của mặt hàng định lượng", "TuDongCapNhatGiaNhapCuaMatHangDinhLuong");
            AddCheckBox(p, 10, 210, "Tự động cập nhật giá vốn của mặt hàng định lượng", "TuDongCapNhatGiaVonCuaMatHangDinhLuong");

            return p;
        }

        // =====================================================================
        // PANEL 8: Mặt hàng (DB Group: Mặt hàng)
        // =====================================================================
        private Panel BuildPanel8_MatHang()
        {
            Panel p = CreateContentPanel();
            AddCheckBox(p, 10, 10, "Sử dụng mã hàng", "SuDungMaHang");
            AddLabel(p, 10, 38, "Tìm theo");
            AddComboBox(p, 160, 35, 150, "TimTheo", new string[0]);
            AddLabel(p, 320, 38, "Cách tìm");
            AddComboBox(p, 370, 35, 100, "CachTim", new string[0]);

            AddLabel(p, 10, 68, "Cấu hình sử dụng nhiều giá bán trên mặt hàng hay không");

            AddCheckBox(p, 10, 90, "Sử dụng giá 2", "SuDungGia2");
            AddLabel(p, 230, 93, "Diễn giải giá 2");
            AddTextBox(p, 310, 90, 120, "DienGiaiGia2", "Giá 2");

            AddCheckBox(p, 10, 118, "Sử dụng giá 3", "SuDungGia3");
            AddLabel(p, 230, 121, "Diễn giải giá 3");
            AddTextBox(p, 310, 118, 120, "DienGiaiGia3", "Giá 3");

            AddCheckBox(p, 10, 146, "Sử dụng giá 4", "SuDungGia4");
            AddLabel(p, 230, 149, "Diễn giải giá 4");
            AddTextBox(p, 310, 146, 120, "DienGiaiGia4", "Giá 4");

            AddLabel(p, 10, 180, "Sắp xếp thứ tự theo");
            AddComboBox(p, 160, 177, 150, "SapXepThuTuTheo", new string[0]);
            AddCheckBox(p, 10, 210, "Sử dụng tên tiếng anh", "SuDungTenTiengAnh");
            AddCheckBox(p, 10, 235, "Giá bán lẻ (USD)", "GiaBanLeUsd");

            AddLabel(p, 10, 268, "Làm tròn mặt hàng theo giờ (phút)");
            AddTextBox(p, 210, 265, 40, "LamTronMatHangDichVuTheoGio", "0");
            AddLabel(p, 260, 268, "Cách làm tròn");
            AddComboBox(p, 340, 265, 120, "CachLamTronDichVuTheoGio", new string[0]);
            AddLabel(p, 10, 295, "(0 = không làm tròn)").Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            p.Controls[p.Controls.Count - 1].ForeColor = Color.Gray;

            return p;
        }

        // =====================================================================
        // PANEL 9: Thiết bị khác (DB Group: Thiết bị khác)
        // =====================================================================
        private Panel BuildPanel9_ThietBiKhac()
        {
            Panel p = CreateContentPanel();
            AddLabel(p, 10, 10, "Cây hiển thị giá").Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AddCheckBox(p, 10, 30, "Có cây hiển thị giá", "CoCayHienThiGia");
            AddLabel(p, 220, 33, "Cổng sử dụng");
            AddTextBox(p, 300, 30, 80, "CongSuDung", "0");

            AddLabel(p, 10, 60, "Cân điện tử").Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AddCheckBox(p, 10, 80, "Kích hoạt sử dụng cân điện tử", "KichHoatSuDungCanDienTu");

            AddLabel(p, 10, 113, "Cổng com (Ví dụ COM4)");
            AddTextBox(p, 160, 110, 180, "CongCom", "COM4");
            AddLabel(p, 10, 143, "Baud rate");
            AddComboBox(p, 160, 140, 180, "BaudRate", new string[0]);

            AddLabel(p, 10, 173, "Databit (8)");
            AddTextBox(p, 160, 170, 40, "Databit", "8");
            AddLabel(p, 10, 203, "Parity");
            AddComboBox(p, 160, 200, 180, "Parity", new string[0]);

            AddLabel(p, 10, 233, "Stop bits");
            AddComboBox(p, 160, 230, 180, "StopBits", new string[0]);

            AddLabel(p, 10, 263, "Timeout");
            AddTextBox(p, 160, 260, 50, "Timeout", "1000");

            AddLabel(p, 10, 293, "Vị trí");
            AddTextBox(p, 160, 290, 50, "ViTri", "6");
            AddLabel(p, 10, 323, "Độ dài");
            AddTextBox(p, 160, 320, 50, "DoDai", "9");

            AddCheckBox(p, 10, 350, "Có sử dụng công tắc điện tử", "CoSuDungCongTacDienTu");
            AddLabel(p, 10, 383, "IP máy chấm công");
            AddTextBox(p, 160, 380, 180, "IpMayChamCong", "0");

            return p;
        }

        // =====================================================================
        // PANEL 10: Cảnh báo (DB Group: Cảnh báo)
        // =====================================================================
        private Panel BuildPanel10_CanhBao()
        {
            Panel p = CreateContentPanel();
            AddCheckBox(p, 10, 10, "Hiển thị cảnh báo", "HienThiCanhBao");
            AddCheckBox(p, 10, 35, "Thông báo hàng dưới mức an toàn", "ThongBaoHangDuoiMuocAnToan");
            AddCheckBox(p, 10, 60, "Thông báo khách đến ngày sinh nhật", "ThongBaoKhachDenNgaySinhNhat");
            AddCheckBox(p, 10, 85, "Thông báo chương trình khuyến mại", "CanhBaoChuongTrinhKhuyenMai");

            return p;
        }

        // =====================================================================
        // PANEL 11: Quản trị (DB Group: Quản trị)
        // =====================================================================
        private Panel BuildPanel11_QuanTri()
        {
            Panel p = CreateContentPanel();
            AddCheckBox(p, 10, 10, "Giảm đồ, xóa đồ nhập mật khẩu", "NhapMatKhauGiamDo");
            AddLabel(p, 30, 38, "Mật khẩu");
            TextBox txtP = AddTextBox(p, 90, 35, 200, "PasswordGiamDo", "");
            txtP.PasswordChar = '*';

            AddCheckBox(p, 10, 65, "Kích hoạt lưu vết hoạt động", "KichHoatLuuVetHoatDong");
            AddLabel(p, 30, 93, "Lưu vết trong (ngày)");
            AddTextBox(p, 160, 90, 50, "LuuVetTrong", "20");

            AddCheckBox(p, 10, 120, "Không được giảm đồ sau khi in pha chế", "KhongDuocGiamDoSauKhiInPhaChe");
            AddCheckBox(p, 10, 145, "Lưu vết in chế biến", "LuuVetInCheBien");
            AddCheckBox(p, 10, 170, "Hệ thống chạy nhiều máy trạm", "HeThongChayNhieuMayTram");

            AddLabel(p, 10, 203, "Số lần in tối đa");
            AddTextBox(p, 150, 200, 40, "SoLanInToiDa", "0");
            AddLabel(p, 210, 203, "Số lần in tạm tính tối đa");
            AddTextBox(p, 360, 200, 40, "SoLanInTamTinhToiDa", "0");

            AddLabel(p, 10, 233, "Thời gian cho phép hủy bill (phút)");
            AddTextBox(p, 200, 230, 40, "ThoiGianChoPhepHuyBill", "50");

            AddCheckBox(p, 10, 260, "Bật chức năng kiểm soát order", "BatChucNangKiemSoatOrder");
            AddCheckBox(p, 10, 285, "Phân quyền truy cập theo khu vực", "PhanQuyenTruyCapTheoKhuVuc");

            AddLabel(p, 10, 318, "Số hóa đơn quay vòng theo");
            AddComboBox(p, 190, 315, 150, "SoHoaDonQuayVongTheo", new string[0]);

            AddCheckBox(p, 10, 345, "Kích hoạt chức năng kiểm đồ", "KichHoatChucNangKiemDo");
            AddCheckBox(p, 10, 370, "Nhập lý do khi hủy hóa đơn", "NhapLyDoKhiHuyHoaDon");
            AddCheckBox(p, 10, 395, "Nhập lý do khi xóa món", "NhapLyDoKhiXoaMon");

            return p;
        }

        // =====================================================================
        // PANEL 12: Cảm ứng (DB Group: Cảm ứng)
        // =====================================================================
        private Panel BuildPanel12_CamUng()
        {
            Panel p = CreateContentPanel();
            AddCheckBox(p, 10, 10, "Sử dụng giao diện thiết kế", "SuDungGiaoDienThietKe");
            AddCheckBox(p, 10, 35, "Nhập số lượng khi chọn mặt hàng", "NhapSoLuongKhiChonMatHang");
            AddCheckBox(p, 10, 60, "Nhập số khách khi mở hóa đơn", "NhapSoKhachKhiMoHoaDon");
            AddCheckBox(p, 10, 85, "Có màn hình phụ", "CoManHinhPhu");

            AddLabel(p, 10, 115, "Logo màn hình phụ");
            PictureBox picSec = new PictureBox { Location = new Point(40, 135), Size = new Size(60, 60), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            Button btnSecSelect = new Button { Text = "Chọn", Location = new Point(40, 200), Size = new Size(60, 25), Font = new Font("Segoe UI", 8.5F) };

            p.Controls.Add(picSec);
            p.Controls.Add(btnSecSelect);

            return p;
        }

        // =====================================================================
        // PANEL 13: Tùy chọn khác (DB Group: Tùy chọn khác)
        // =====================================================================
        private Panel BuildPanel13_TuyChonKhac()
        {
            Panel p = CreateContentPanel();
            AddCheckBox(p, 10, 10, "Phiếu gần nhất nằm phía dưới", "PhieuGanNhatODuoi");
            AddLabel(p, 10, 38, "Phím nhập liệu trên lưới");
            AddComboBox(p, 160, 35, 200, "PhimNhapLieuTrenLuoi", new string[0]);

            AddLabel(p, 10, 68, "Thiết lập tùy chọn tự động sao lưu dữ liệu để đảm bảo an toàn trong tình huống xấu nhất").Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);

            AddCheckBox(p, 10, 90, "Tự động sao lưu dữ liệu", "TuDongSaoLuuDuLieu");
            AddLabel(p, 30, 118, "Đường dẫn sao lưu");
            AddTextBox(p, 160, 115, 100, "DuongDanSaoLuu", "0");
            AddLabel(p, 270, 118, "Số ngày");
            AddTextBox(p, 320, 115, 40, "SoNgaySaoLuu", "1");

            AddLabel(p, 10, 148, "Chức năng mặc định");
            AddComboBox(p, 160, 145, 200, "ChucNangMacDinh", new string[0]);

            AddCheckBox(p, 10, 178, "Lọc dữ liệu bỏ khoảng trống", "LocDuLieuBoKhoangTrong");
            var lblNote1 = AddLabel(p, 10, 200, "(Ví dụ bạn tìm \"cafe da\" sẽ ra cả \"cafe đá\" và \"cafeda\")");
            lblNote1.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblNote1.ForeColor = Color.Gray;

            AddCheckBox(p, 10, 222, "Hiển thị xuống dòng nếu độ rộng cột nhỏ", "HienThiXuongDongNeuDoRongCotNho");
            var lblNote2 = AddLabel(p, 10, 244, "(Tùy chọn này sẽ làm chương trình chạy chậm hơn một chút)");
            lblNote2.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblNote2.ForeColor = Color.Gray;

            AddLabel(p, 10, 270, "Độ to chữ hiển thị");
            AddComboBox(p, 160, 267, 150, "DoToChuHienThi", new string[0]);
            var lblNote3 = AddLabel(p, 320, 270, "(Bạn cần thoát chương trình ra vào lại để áp dụng)");
            lblNote3.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblNote3.ForeColor = Color.Gray;

            AddLabel(p, 10, 300, "Giao diện chương trình");
            AddComboBox(p, 160, 297, 200, "GiaoDienChuongTrinh", new string[0]);

            AddCheckBox(p, 10, 330, "Tự động tải lại dữ liệu khi chuyển tab ở giao diện chính", "TuDongTaiLai");

            return p;
        }

        // =====================================================================
        // HELPER METHODS
        // =====================================================================
        private Panel CreateContentPanel()
        {
            return new NoScrollPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };
        }

        private void FormSystemConfig_Shown(object sender, EventArgs e)
        {
            if (lbNav.Items.Count > 0)
            {
                lbNav.TopIndex = 0;
                lbNav.SelectedIndex = 0;
            }
            pnlRightContent.AutoScrollPosition = new Point(0, 0);
            this.ActiveControl = lbNav;
        }

        private void AddRow(Panel p, int y, string labelText, Control inputCtrl)
        {
            if (!string.IsNullOrEmpty(labelText))
            {
                Label lbl = new Label
                {
                    Text = labelText,
                    Location = new Point(10, y + 4),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F)
                };
                p.Controls.Add(lbl);
            }

            inputCtrl.Location = new Point(110, y);
            p.Controls.Add(inputCtrl);
        }

        private Label AddLabel(Panel p, int x, int y, string text)
        {
            Label lbl = new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F)
            };
            p.Controls.Add(lbl);
            return lbl;
        }

        private TextBox CreateTextBox(string name, string defaultText)
        {
            TextBox txt = new TextBox
            {
                Font = new Font("Segoe UI", 9F),
                Width = 280,
                Text = defaultText
            };
            dbControls[name] = txt;
            return txt;
        }

        private TextBox AddTextBox(Panel p, int x, int y, int width, string name, string defaultText)
        {
            TextBox txt = new TextBox
            {
                Location = new Point(x, y),
                Width = width,
                Font = new Font("Segoe UI", 9F),
                Text = defaultText
            };
            p.Controls.Add(txt);
            dbControls[name] = txt;
            return txt;
        }

        private CheckBox AddCheckBox(Panel p, int x, int y, string text, string name, bool isChecked = false)
        {
            CheckBox chk = new CheckBox
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                Checked = isChecked
            };
            p.Controls.Add(chk);
            dbControls[name] = chk;
            return chk;
        }

        private ComboBox AddComboBox(Panel p, int x, int y, int width, string name, string[] items)
        {
            ComboBox cb = new ComboBox
            {
                Location = new Point(x, y),
                Width = width,
                Font = new Font("Segoe UI", 9F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cb.Items.AddRange(items);
            if (cb.Items.Count > 0) cb.SelectedIndex = 0;
            p.Controls.Add(cb);
            dbControls[name] = cb;
            return cb;
        }

        // =====================================================================
        // DATABASE OPERATIONS
        // =====================================================================
        private void FormSystemConfig_Load(object sender, EventArgs e)
        {
            if (lbNav.Items.Count > 0 && lbNav.SelectedIndex < 0)
            {
                lbNav.TopIndex = 0;
                lbNav.SelectedIndex = 0;
            }
            pnlRightContent.AutoScrollPosition = new Point(0, 0);
            this.ActiveControl = lbNav;
            LoadConfigFromDb();
        }

        public class TemplateItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name ?? "";
        }

        /// <summary>
        /// Loads template combos (CONTROLTYPE=8) from STEMPLATE table
        /// for MauHoaDon, MauInCheBien, MauInChuyenBan
        /// </summary>
        private void PopulateTemplateCombosFromDb()
        {
            try
            {
                string connStr = DbFormService.GetConnectionString(Program.CurrentDatabasePath);
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();

                    // Read OTHERCONFIG from SCONFIG to get SFORMID for each template combo
                    var templateFormIds = new Dictionary<string, string>();
                    string sqlOther = "SELECT NAME, OTHERCONFIG FROM SCONFIG WHERE NAME IN ('MauHoaDon','MauInCheBien','MauInChuyenBan') AND STATUS = 30";
                    using (FbCommand cmdOther = new FbCommand(sqlOther, conn))
                    using (FbDataReader rOther = cmdOther.ExecuteReader())
                    {
                        while (rOther.Read())
                        {
                            string name = rOther["NAME"]?.ToString()?.Trim();
                            string oc = rOther["OTHERCONFIG"]?.ToString()?.Trim();
                            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(oc))
                            {
                                // OTHERCONFIG format: "SFORMID = 'guid-value'"
                                int startIdx = oc.IndexOf("'");
                                int endIdx = oc.LastIndexOf("'");
                                if (startIdx >= 0 && endIdx > startIdx)
                                {
                                    string sFormId = oc.Substring(startIdx + 1, endIdx - startIdx - 1);
                                    templateFormIds[name] = sFormId;
                                }
                            }
                        }
                    }

                    // Load templates for each combo key
                    foreach (var kvp in templateFormIds)
                    {
                        string comboKey = kvp.Key;
                        string sFormId = kvp.Value;

                        if (!dbControls.TryGetValue(comboKey, out Control ctrl) || !(ctrl is ComboBox cb))
                            continue;

                        List<TemplateItem> templates = new List<TemplateItem>();
                        string sqlTpl = "SELECT ID, NAME FROM STEMPLATE WHERE STATUS = 30 AND SFORMID = @FormId ORDER BY NAME";
                        using (FbCommand cmd = new FbCommand(sqlTpl, conn))
                        {
                            cmd.Parameters.AddWithValue("@FormId", sFormId);
                            using (FbDataReader r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    string id = r["ID"]?.ToString()?.Trim();
                                    string name = r["NAME"]?.ToString()?.Trim();
                                    if (!string.IsNullOrEmpty(name))
                                        templates.Add(new TemplateItem { Id = id, Name = name });
                                }
                            }
                        }

                        cb.Items.Clear();
                        cb.Items.AddRange(templates.ToArray());
                        if (cb.Items.Count > 0) cb.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi load STEMPLATE từ CSDL: " + ex.Message);
            }
        }

        /// <summary>
        /// Loads all SCONFIG values from database.
        /// - ComboBox (CONTROLTYPE=10): populates items from OTHERCONFIG, selects by TEXTVALUE
        /// - CheckBox (CONTROLTYPE=9): sets checked from TEXTVALUE ("1" = true)
        /// - TextBox: sets text from TEXTVALUE
        /// - Template ComboBox (CONTROLTYPE=8): selects by TEXTVALUE (ID or Name)
        /// </summary>
        private void LoadConfigFromDb()
        {
            try
            {
                PopulateTemplateCombosFromDb();

                string connStr = DbFormService.GetConnectionString(Program.CurrentDatabasePath);
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT NAME, TEXTVALUE, INTVALUE, DECIMALVALUE, DATETIMEVALUE, CONTROLTYPE, DATATYPE, OTHERCONFIG FROM SCONFIG WHERE STATUS = 30";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        using (FbDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                              try
                              {
                                string key = r["NAME"]?.ToString()?.Trim();
                                string valText = r["TEXTVALUE"]?.ToString()?.Trim();
                                string intText = r["INTVALUE"]?.ToString()?.Trim();
                                string decText = r["DECIMALVALUE"]?.ToString()?.Trim();
                                string dtText = r["DATETIMEVALUE"]?.ToString()?.Trim();
                                string dataType = r["DATATYPE"]?.ToString()?.Trim();
                                string otherConfig = r["OTHERCONFIG"]?.ToString();
                                int controlType = 0;
                                if (r["CONTROLTYPE"] != DBNull.Value)
                                    int.TryParse(r["CONTROLTYPE"].ToString(), out controlType);

                                if (string.IsNullOrEmpty(key) || !dbControls.TryGetValue(key, out Control ctrl))
                                    continue;

                                if (ctrl is ComboBox cb)
                                {
                                    if (templateComboKeys.Contains(key))
                                    {
                                        // Template lookup (CONTROLTYPE=8): match by ID or Name
                                        bool matched = false;
                                        if (!string.IsNullOrEmpty(valText))
                                        {
                                            foreach (var item in cb.Items)
                                            {
                                                if (item is TemplateItem tItem && (tItem.Id == valText || tItem.Name == valText))
                                                {
                                                    cb.SelectedItem = tItem;
                                                    matched = true;
                                                    break;
                                                }
                                            }
                                            if (!matched)
                                            {
                                                for (int i = 0; i < cb.Items.Count; i++)
                                                {
                                                    if (cb.Items[i].ToString() == valText)
                                                    {
                                                        cb.SelectedIndex = i;
                                                        matched = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (controlType == 10 && !string.IsNullOrEmpty(otherConfig))
                                    {
                                        // ComboBox with options from OTHERCONFIG
                                        string[] options = otherConfig.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                                        cb.Items.Clear();
                                        foreach (var opt in options)
                                        {
                                            string trimmed = opt.Trim();
                                            if (!string.IsNullOrEmpty(trimmed))
                                                cb.Items.Add(trimmed);
                                        }

                                        // Select matching TEXTVALUE
                                        if (!string.IsNullOrEmpty(valText))
                                        {
                                            int idx = -1;
                                            for (int i = 0; i < cb.Items.Count; i++)
                                            {
                                                if (cb.Items[i].ToString() == valText)
                                                {
                                                    idx = i;
                                                    break;
                                                }
                                            }
                                            if (idx >= 0)
                                                cb.SelectedIndex = idx;
                                            else if (cb.Items.Count > 0)
                                                cb.SelectedIndex = 0;
                                        }
                                        else if (cb.Items.Count > 0)
                                        {
                                            cb.SelectedIndex = 0;
                                        }
                                    }
                                    else if (controlType == 8)
                                    {
                                        // Non-template lookup combo (e.g. ChucNangMacDinh)
                                        // Just try to set text
                                        if (!string.IsNullOrEmpty(valText))
                                        {
                                            bool found = false;
                                            for (int i = 0; i < cb.Items.Count; i++)
                                            {
                                                if (cb.Items[i].ToString() == valText)
                                                {
                                                    cb.SelectedIndex = i;
                                                    found = true;
                                                    break;
                                                }
                                            }
                                            if (!found)
                                            {
                                                // Add the value as an item so user can see it
                                                cb.Items.Add(valText);
                                                cb.SelectedIndex = cb.Items.Count - 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // Fallback: try to match by text
                                        if (!string.IsNullOrEmpty(valText))
                                        {
                                            for (int i = 0; i < cb.Items.Count; i++)
                                            {
                                                if (cb.Items[i].ToString() == valText)
                                                {
                                                    cb.SelectedIndex = i;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (ctrl is CheckBox chk)
                                {
                                    // CheckBox uses INTVALUE: 30 = checked, 0 = unchecked
                                    int intVal = 0;
                                    if (r["INTVALUE"] != DBNull.Value)
                                        int.TryParse(r["INTVALUE"].ToString(), out intVal);
                                    chk.Checked = (intVal == 30);
                                }
                                else if (ctrl is TextBox txt)
                                {
                                    if (!string.IsNullOrEmpty(valText))
                                        txt.Text = valText;
                                    else if (!string.IsNullOrEmpty(dtText))
                                        txt.Text = dtText;
                                    else if (dataType == "3" || dataType == "2")
                                    {
                                        // Explicitly numeric type, so "0" is a valid value.
                                        // Prioritize INTVALUE first, then DECIMALVALUE.
                                        if (!string.IsNullOrEmpty(intText) && intText != "0")
                                            txt.Text = intText;
                                        else if (!string.IsNullOrEmpty(decText) && decText != "0" && decText != "0.0000" && decText != "0.00")
                                            txt.Text = decText;
                                        else
                                            txt.Text = "0";
                                    }
                                    else
                                    {
                                        // Not explicitly numeric type. Only fallback to INT/DEC if they are non-zero
                                        if (!string.IsNullOrEmpty(intText) && intText != "0")
                                            txt.Text = intText;
                                        else if (!string.IsNullOrEmpty(decText) && decText != "0" && decText != "0.0000" && decText != "0.00")
                                            txt.Text = decText;
                                        else
                                        {
                                            // Don't overwrite with empty if it's already got a default value, 
                                            // UNLESS it's explicitly datatype 1 (string) and the DB value is literally empty/null
                                            if (dataType == "1")
                                                txt.Text = "";
                                            // else leave the default value from AddTextBox alone!
                                        }
                                    }
                                }
                              }
                              catch (Exception exRow)
                              {
                                  System.Diagnostics.Debug.WriteLine("Lỗi load row SCONFIG: " + exRow.Message);
                                  continue;
                              }
                            }
                        }
                    }
                    
                    // Load format records from SFORM and STABLEDESC (bypassing SCONFIG)
                    LoadFormatConfigsFromDb(conn);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi load SCONFIG từ CSDL: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves all config values back to SCONFIG table.
        /// Updates TEXTVALUE for each control. Inserts if row doesn't exist.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = DbFormService.GetConnectionString(Program.CurrentDatabasePath);
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    using (FbTransaction trans = conn.BeginTransaction())
                    {
                        foreach (var kv in dbControls)
                        {
                            string key = kv.Key;
                            string valText = "";
                            int intVal = 0;
                            bool isCheckBox = false;

                            // Skip non-DB controls (e.g. developer template password)
                            if (key == "DevTemplatePass") continue;

                            // Skip format keys for SCONFIG save
                            if (key.StartsWith("FORMAT_")) continue;

                            if (kv.Value is TextBox txt)
                            {
                                valText = txt.Text;
                            }
                            else if (kv.Value is CheckBox chk)
                            {
                                isCheckBox = true;
                                valText = chk.Checked ? "1" : "0";
                                intVal = chk.Checked ? 30 : 0;
                            }
                            else if (kv.Value is ComboBox cb)
                            {
                                if (templateComboKeys.Contains(key) && cb.SelectedItem is TemplateItem tItem)
                                {
                                    valText = tItem.Id;
                                }
                                else
                                {
                                    valText = cb.Text;
                                }
                            }

                            string updateSql = isCheckBox
                                ? "UPDATE SCONFIG SET TEXTVALUE = @Val, INTVALUE = @IntVal WHERE NAME = @Name"
                                : "UPDATE SCONFIG SET TEXTVALUE = @Val, INTVALUE = @IntVal, DECIMALVALUE = @DecVal WHERE NAME = @Name";
                            using (FbCommand cmd = new FbCommand(updateSql, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@Val", valText ?? "");
                                cmd.Parameters.AddWithValue("@Name", key);
                                if (isCheckBox)
                                {
                                    cmd.Parameters.AddWithValue("@IntVal", intVal);
                                }
                                else
                                {
                                    int parsedInt;
                                    if (int.TryParse(valText, out parsedInt))
                                        cmd.Parameters.AddWithValue("@IntVal", parsedInt);
                                    else
                                        cmd.Parameters.AddWithValue("@IntVal", DBNull.Value);
                                    
                                    decimal parsedDec;
                                    if (decimal.TryParse(valText, out parsedDec))
                                        cmd.Parameters.AddWithValue("@DecVal", parsedDec);
                                    else
                                        cmd.Parameters.AddWithValue("@DecVal", DBNull.Value);
                                }
                                int rows = cmd.ExecuteNonQuery();
                                if (rows == 0)
                                {
                                    string insertSql = isCheckBox
                                        ? "INSERT INTO SCONFIG (ID, NAME, TEXTVALUE, INTVALUE, TIMECREATED, STATUS, USERCREATEDID) VALUES (@Id, @Name, @Val, @IntVal2, CURRENT_TIMESTAMP, 30, '1')"
                                        : "INSERT INTO SCONFIG (ID, NAME, TEXTVALUE, INTVALUE, DECIMALVALUE, TIMECREATED, STATUS, USERCREATEDID) VALUES (@Id, @Name, @Val, @IntVal2, @DecVal, CURRENT_TIMESTAMP, 30, '1')";
                                    using (FbCommand insCmd = new FbCommand(insertSql, conn, trans))
                                    {
                                        insCmd.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString());
                                        insCmd.Parameters.AddWithValue("@Name", key);
                                        insCmd.Parameters.AddWithValue("@Val", valText ?? "");
                                        if (isCheckBox)
                                        {
                                            insCmd.Parameters.AddWithValue("@IntVal2", intVal);
                                        }
                                        else
                                        {
                                            int parsedInt;
                                            if (int.TryParse(valText, out parsedInt))
                                                insCmd.Parameters.AddWithValue("@IntVal2", parsedInt);
                                            else
                                                insCmd.Parameters.AddWithValue("@IntVal2", DBNull.Value);
                                            
                                            decimal parsedDec;
                                            if (decimal.TryParse(valText, out parsedDec))
                                                insCmd.Parameters.AddWithValue("@DecVal", parsedDec);
                                            else
                                                insCmd.Parameters.AddWithValue("@DecVal", DBNull.Value);
                                        }
                                        insCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        
                        // Save format strings to SFORM and STABLEDESC
                        SaveFormatConfigsToDb(conn, trans);
                        
                        trans.Commit();
                    }
                }

                MessageBox.Show("Đã ghi thành công thông tin cấu hình hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi dữ liệu cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFormatConfigsFromDb(FbConnection conn)
        {
            var sformMappings = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Hóa đơn nhà hàng", "FORMAT_TSOHOADON" },
                { "Phiếu nhập kho", "FORMAT_TPHIEUNHAPKHO" },
                { "Phiếu xuất kho", "FORMAT_TPHIEUXUATKHO" },
                { "Phiếu chuyển kho", "FORMAT_TPHIEUCHUYENKHO" },
                { "Phiếu kiểm kê", "FORMAT_TPHIEUKIEMKE" },
                { "Phiếu thu", "FORMAT_TPHIEUTHU" },
                { "Phiếu chi", "FORMAT_TPHIEUCHI" },
                { "Phiếu thu công nợ", "FORMAT_TPHIEUTHUCONGNO" }
            };

            var stableDescMappings = new System.Collections.Generic.Dictionary<string, string>
            {
                { "TBAOGIA", "FORMAT_TBAOGIA" },
                { "TDATHANG", "FORMAT_TDATHANG" },
                { "TBANGLUONG", "FORMAT_TBANGLUONG" }
            };

            try
            {
                // Load from SFORM
                using (var cmd = new FbCommand("SELECT NAME, NOTEMPLATE FROM SFORM WHERE NOTEMPLATE IS NOT NULL", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        string name = r["NAME"]?.ToString()?.Trim();
                        string tmpl = r["NOTEMPLATE"]?.ToString()?.Trim();
                        if (!string.IsNullOrEmpty(name) && sformMappings.TryGetValue(name, out string key))
                        {
                            if (dbControls.TryGetValue(key, out Control ctrl) && ctrl is TextBox txt)
                                txt.Text = tmpl ?? "";
                        }
                    }
                }

                // Load from STABLEDESC
                using (var cmd = new FbCommand("SELECT NAME, NOTEMPLATE FROM STABLEDESC WHERE NOTEMPLATE IS NOT NULL", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        string name = r["NAME"]?.ToString()?.Trim();
                        string tmpl = r["NOTEMPLATE"]?.ToString()?.Trim();
                        if (!string.IsNullOrEmpty(name) && stableDescMappings.TryGetValue(name, out string key))
                        {
                            if (dbControls.TryGetValue(key, out Control ctrl) && ctrl is TextBox txt)
                                txt.Text = tmpl ?? "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi load NOTEMPLATE: " + ex.Message);
            }
        }

        private void SaveFormatConfigsToDb(FbConnection conn, FbTransaction trans)
        {
            var sformMappings = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Hóa đơn nhà hàng", "FORMAT_TSOHOADON" },
                { "Phiếu nhập kho", "FORMAT_TPHIEUNHAPKHO" },
                { "Phiếu xuất kho", "FORMAT_TPHIEUXUATKHO" },
                { "Phiếu chuyển kho", "FORMAT_TPHIEUCHUYENKHO" },
                { "Phiếu kiểm kê", "FORMAT_TPHIEUKIEMKE" },
                { "Phiếu thu", "FORMAT_TPHIEUTHU" },
                { "Phiếu chi", "FORMAT_TPHIEUCHI" },
                { "Phiếu thu công nợ", "FORMAT_TPHIEUTHUCONGNO" }
            };

            var stableDescMappings = new System.Collections.Generic.Dictionary<string, string>
            {
                { "TBAOGIA", "FORMAT_TBAOGIA" },
                { "TDATHANG", "FORMAT_TDATHANG" },
                { "TBANGLUONG", "FORMAT_TBANGLUONG" }
            };

            try
            {
                // Save to SFORM
                foreach (var kv in sformMappings)
                {
                    if (dbControls.TryGetValue(kv.Value, out Control ctrl) && ctrl is TextBox txt)
                    {
                        string tmpl = txt.Text.Trim();
                        using (var cmd = new FbCommand("UPDATE SFORM SET NOTEMPLATE = @tmpl WHERE NAME = @name", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@tmpl", tmpl);
                            cmd.Parameters.AddWithValue("@name", kv.Key);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // Save to STABLEDESC
                foreach (var kv in stableDescMappings)
                {
                    if (dbControls.TryGetValue(kv.Value, out Control ctrl) && ctrl is TextBox txt)
                    {
                        string tmpl = txt.Text.Trim();
                        using (var cmd = new FbCommand("UPDATE STABLEDESC SET NOTEMPLATE = @tmpl WHERE NAME = @name", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@tmpl", tmpl);
                            cmd.Parameters.AddWithValue("@name", kv.Key);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi save NOTEMPLATE: " + ex.Message);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormSystemConfig
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "FormSystemConfig";
            this.ResumeLayout(false);

        }
    }
}
