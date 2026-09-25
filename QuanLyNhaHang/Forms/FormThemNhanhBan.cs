using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using SysConfig = No1Lib.Sys.Config;

namespace QuanLyNhaHang.Forms
{
    public class FormThemNhanhBan : KryptonForm
    {
        private Panel pnlHeader;
        private Label lblGhiChu;
        private DataGridView grMain;
        private Label lblChieuDai;
        private NumericUpDown numChieuDai;
        private KryptonButton btnThucHien;
        private KryptonButton btnThoat;
        private DataTable dtKhuVuc;

        public FormThemNhanhBan()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "THÊM NHANH BÀN VÀ KHU VỰC";
            this.ClientSize = new Size(530, 480);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.BackColor = Color.FromArgb(245, 248, 252);

            // 1. Header description panel
            pnlHeader = new Panel
            {
                Location = new Point(12, 10),
                Size = new Size(506, 130),
                BackColor = Color.FromArgb(235, 243, 252),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblGhiChu = new Label
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(8, 6, 8, 6),
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(30, 40, 60),
                Text = "Chức năng này cho phép bạn thêm nhiều bàn vào hệ thống một lúc.\n" +
                       "Để sử dụng, bạn chọn các khu vực dưới đây rồi nhập tiền tố, từ số và đến số:\n" +
                       "  • Ví dụ 1: Tầng 1: Từ 1 đến 9, bắt đầu bằng B  (Chiều dài vùng số = 2) -> B01...B09\n" +
                       "  • Ví dụ 2: Tầng 2: Từ 10 đến 29, bắt đầu bằng B (Chiều dài vùng số = 2) -> B10...B29\n" +
                       "  • Ví dụ 3: Tầng 3: Từ 29 đến 99, bắt đầu bằng B (Chiều dài vùng số = 2) -> B29...B99\n" +
                       "Hệ thống sẽ tự động sinh và kiểm tra trùng tên bàn trước khi lưu."
            };
            pnlHeader.Controls.Add(lblGhiChu);
            this.Controls.Add(pnlHeader);

            // 2. DataGridView
            grMain = new DataGridView
            {
                Location = new Point(12, 150),
                Size = new Size(506, 230),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                MultiSelect = false,
                AutoGenerateColumns = false,
                Font = new Font("Segoe UI", 9f),
                RowTemplate = { Height = 26 },
                EnableHeadersVisualStyles = false
            };

            grMain.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 234, 248);
            grMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(20, 40, 70);
            grMain.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            grMain.ColumnHeadersHeight = 28;

            var colKhuVuc = new DataGridViewTextBoxColumn
            {
                Name = "KHUVUC",
                DataPropertyName = "KHUVUC",
                HeaderText = "Khu vực",
                Width = 115,
                ReadOnly = true
            };
            colKhuVuc.DefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            var colBatDau = new DataGridViewTextBoxColumn
            {
                Name = "BATDAU",
                DataPropertyName = "BATDAU",
                HeaderText = "Bắt đầu bằng",
                Width = 95
            };

            var colTuSo = new DataGridViewTextBoxColumn
            {
                Name = "TUSO",
                DataPropertyName = "TUSO",
                HeaderText = "Từ số",
                Width = 65
            };
            colTuSo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var colDenSo = new DataGridViewTextBoxColumn
            {
                Name = "DENSO",
                DataPropertyName = "DENSO",
                HeaderText = "Đến số",
                Width = 65
            };
            colDenSo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var colDuLieu = new DataGridViewTextBoxColumn
            {
                Name = "DULIEU",
                DataPropertyName = "DULIEU",
                HeaderText = "Dữ liệu sinh",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            };
            colDuLieu.DefaultCellStyle.ForeColor = Color.FromArgb(0, 100, 0);

            grMain.Columns.AddRange(colKhuVuc, colBatDau, colTuSo, colDenSo, colDuLieu);
            grMain.CellValueChanged += GrMain_CellValueChanged;
            grMain.CellEndEdit += (s, e) => UpdateViDu();

            this.Controls.Add(grMain);

            // 3. Bottom controls
            lblChieuDai = new Label
            {
                Location = new Point(12, 395),
                Size = new Size(115, 22),
                Text = "Chiều dài vùng số:",
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9f, FontStyle.Regular)
            };
            this.Controls.Add(lblChieuDai);

            numChieuDai = new NumericUpDown
            {
                Location = new Point(130, 395),
                Size = new Size(55, 22),
                Minimum = 0,
                Maximum = 10,
                Value = 0,
                Font = new Font("Segoe UI", 9f)
            };
            numChieuDai.ValueChanged += (s, e) => UpdateViDu();
            this.Controls.Add(numChieuDai);

            btnThucHien = new KryptonButton
            {
                Location = new Point(328, 432),
                Size = new Size(95, 32),
                Text = "Thực hiện",
                Cursor = Cursors.Hand
            };
            btnThucHien.StateCommon.Border.Rounding = 3;
            btnThucHien.Click += BtnThucHien_Click;
            this.Controls.Add(btnThucHien);

            btnThoat = new KryptonButton
            {
                Location = new Point(430, 432),
                Size = new Size(88, 32),
                Text = "Thoát",
                Cursor = Cursors.Hand
            };
            btnThoat.StateCommon.Border.Rounding = 3;
            btnThoat.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnThoat);

            this.AcceptButton = btnThucHien;
            this.CancelButton = btnThoat;
        }

        private void LoadData()
        {
            try
            {
                Database db = SysConfig.Db;
                if (db == null)
                {
                    db = new Database("localhost", "SYSDBA", "masterkey", Program.CurrentDatabasePath ?? @"d:\QuanLyNhaHang\Database\DEMO.FDB");
                    db.ReConnect();
                    SysConfig.Db = db;
                }

                string sql = "SELECT ID, NAME AS KHUVUC, '' AS BATDAU, '' AS DULIEU FROM DKHUVUC WHERE (STATUS <> 0 OR STATUS IS NULL) ORDER BY SORTORDER, NAME";
                dtKhuVuc = db.GetTable(sql);
                if (dtKhuVuc != null)
                {
                    if (!dtKhuVuc.Columns.Contains("TUSO"))
                    {
                        dtKhuVuc.Columns.Add("TUSO", typeof(int));
                    }
                    if (!dtKhuVuc.Columns.Contains("DENSO"))
                    {
                        dtKhuVuc.Columns.Add("DENSO", typeof(int));
                    }
                    grMain.DataSource = dtKhuVuc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khu vực: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GrMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdateViDu();
                grMain.InvalidateRow(e.RowIndex);
            }
        }

        private void UpdateViDu()
        {
            if (dtKhuVuc == null) return;

            try
            {
                int max = 0;
                foreach (DataRow r in dtKhuVuc.Rows)
                {
                    if (r["DENSO"] != DBNull.Value && int.TryParse(r["DENSO"].ToString(), out int denVal))
                    {
                        max = Math.Max(max, denVal);
                    }
                }

                if (max > 0 && numChieuDai.Value == 0)
                {
                    numChieuDai.Value = Math.Max(2, max.ToString().Length);
                }

                int chieuDai = (int)numChieuDai.Value;
                string temp = chieuDai > 0 ? new string('0', chieuDai) : "";

                foreach (DataRow r in dtKhuVuc.Rows)
                {
                    string batDau = r["BATDAU"] != DBNull.Value ? r["BATDAU"].ToString().Trim() : "";
                    int tuSo = (r["TUSO"] != DBNull.Value && int.TryParse(r["TUSO"].ToString(), out int tuVal)) ? tuVal : 0;
                    int denSo = (r["DENSO"] != DBNull.Value && int.TryParse(r["DENSO"].ToString(), out int denVal2)) ? denVal2 : 0;

                    if (tuSo > 0 && denSo >= tuSo)
                    {
                        string sTu = temp.Length > 0 ? tuSo.ToString(temp) : tuSo.ToString();
                        string sDen = temp.Length > 0 ? denSo.ToString(temp) : denSo.ToString();
                        r["DULIEU"] = batDau + sTu + " ... " + batDau + sDen;
                    }
                    else
                    {
                        r["DULIEU"] = "";
                    }
                }
            }
            catch { }
        }

        private void BtnThucHien_Click(object sender, EventArgs e)
        {
            if (dtKhuVuc == null) return;

            try
            {
                Database db = SysConfig.Db;
                if (db == null)
                {
                    db = new Database("localhost", "SYSDBA", "masterkey", Program.CurrentDatabasePath ?? @"d:\QuanLyNhaHang\Database\DEMO.FDB");
                    db.ReConnect();
                    SysConfig.Db = db;
                }

                // Collect existing table names from DBAN
                DataTable dtBanCu = db.GetTable("SELECT NAME FROM DBAN WHERE STATUS <> 0 OR STATUS IS NULL");
                HashSet<string> lstBanCu = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                if (dtBanCu != null)
                {
                    foreach (DataRow r in dtBanCu.Rows)
                    {
                        string n = r["NAME"] != null ? r["NAME"].ToString().Trim() : "";
                        if (!string.IsNullOrEmpty(n)) lstBanCu.Add(n);
                    }
                }

                int chieuDai = (int)numChieuDai.Value;
                string temp = chieuDai > 0 ? new string('0', chieuDai) : "";

                // List of new tables to add: (TenBan, KhuVucId)
                List<KeyValuePair<string, string>> lstBanMoi = new List<KeyValuePair<string, string>>();
                HashSet<string> setBanMoi = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach (DataRow r in dtKhuVuc.Rows)
                {
                    string batDau = r["BATDAU"] != DBNull.Value ? r["BATDAU"].ToString().Trim() : "";
                    int tuSo = (r["TUSO"] != DBNull.Value && int.TryParse(r["TUSO"].ToString(), out int tuVal)) ? tuVal : 0;
                    int denSo = (r["DENSO"] != DBNull.Value && int.TryParse(r["DENSO"].ToString(), out int denVal)) ? denVal : 0;
                    string khuvucId = r["ID"] != null ? r["ID"].ToString() : "";

                    if (tuSo > 0 && denSo >= tuSo)
                    {
                        for (int i = tuSo; i <= denSo; i++)
                        {
                            string sNum = temp.Length > 0 ? i.ToString(temp) : i.ToString();
                            string tenBan = (batDau + sNum).Trim();

                            if (lstBanCu.Contains(tenBan))
                            {
                                MessageBox.Show(string.Format("Bàn '{0}' đã tồn tại trong dữ liệu!", tenBan), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (setBanMoi.Contains(tenBan))
                            {
                                MessageBox.Show(string.Format("Bàn '{0}' bị trùng lặp trong danh sách thêm!", tenBan), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            setBanMoi.Add(tenBan);
                            lstBanMoi.Add(new KeyValuePair<string, string>(tenBan, khuvucId));
                        }
                    }
                }

                if (lstBanMoi.Count == 0)
                {
                    MessageBox.Show("Chưa có bàn nào được cấu hình để thêm!\nVui lòng nhập từ số và đến số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Batch insert into DBAN
                DateTime now = DateTime.Now;
                int countAdded = 0;

                foreach (var item in lstBanMoi)
                {
                    string newId = Guid.NewGuid().ToString();
                    string tenBan = item.Key.Replace("'", "''");
                    string khuvucId = item.Value.Replace("'", "''");

                    string sqlInsert = string.Format(
                        "INSERT INTO DBAN (ID, NAME, DKHUVUCID, CACHTINHGIO, DONGIA, TIENMOBAN, STATUS, TIMECREATED, TIMEMODIFIED) " +
                        "VALUES ('{0}', '{1}', '{2}', 0, 0, 0, 30, '{3:yyyy-MM-dd HH:mm:ss}', '{3:yyyy-MM-dd HH:mm:ss}')",
                        newId, tenBan, khuvucId, now);

                    db.ExecSql(sqlInsert);
                    countAdded++;
                }

                try
                {
                    SysConfig.SetLastUpdate(Tables.DBAN);
                }
                catch { }

                MessageBox.Show(string.Format("Đã thêm thành công {0} bàn mới vào hệ thống!", countAdded), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
