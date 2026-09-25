using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using QuanLyNhaHang.Forms;

namespace No1Run
{
    public partial class TamUngDonHang : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form No1Form1 => this;

        private string _tdonhangId = "";
        private string _tdathangId = "";
        private string _tenBan = "";

        public TamUngDonHang()
        {
            InitializeComponent();
        }

        public void LoadData(string tdonhangId, string tdathangId, string tenBan)
        {
            _tdonhangId = tdonhangId ?? "";
            _tdathangId = tdathangId ?? "";
            _tenBan = tenBan ?? "";

            lblTitle.Text = "BÀN TẠM ỨNG: " + _tenBan.ToUpper();
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                if (string.IsNullOrEmpty(_tdonhangId) && string.IsNullOrEmpty(_tdathangId))
                {
                    dgvTamUng.Rows.Clear();
                    lblTongTien.Text = "Tổng tạm ứng: 0 đ";
                    UpdateButtonsState();
                    return;
                }

                string sql = "SELECT ID, NAME, NGAY, DIENGIAI, THU FROM TTHUCHI WHERE 1=1 ";
                if (!string.IsNullOrEmpty(_tdonhangId) && !string.IsNullOrEmpty(_tdathangId))
                {
                    sql += "AND (TDONHANGID = '" + _tdonhangId + "' OR TDATHANGID = '" + _tdathangId + "') ";
                }
                else if (!string.IsNullOrEmpty(_tdonhangId))
                {
                    sql += "AND TDONHANGID = '" + _tdonhangId + "' ";
                }
                else
                {
                    sql += "AND TDATHANGID = '" + _tdathangId + "' ";
                }
                sql += "ORDER BY NGAY DESC, TIMECREATED DESC";

                DataTable dt = Config.Db.GetTable(sql);
                dgvTamUng.Rows.Clear();
                decimal tongTien = 0;

                if (dt != null && dt.Rows.Count > 0)
                {
                    int stt = 1;
                    foreach (DataRow r in dt.Rows)
                    {
                        string id = r["ID"] != DBNull.Value ? r["ID"].ToString() : "";
                        string name = r["NAME"] != DBNull.Value ? r["NAME"].ToString() : "";
                        DateTime ngay = r["NGAY"] != DBNull.Value ? Convert.ToDateTime(r["NGAY"]) : DateTime.Now;
                        string diengiai = r["DIENGIAI"] != DBNull.Value ? r["DIENGIAI"].ToString() : "";
                        decimal thu = r["THU"] != DBNull.Value ? Convert.ToDecimal(r["THU"]) : 0;
                        tongTien += thu;

                        int rowIndex = dgvTamUng.Rows.Add(stt++, name, ngay.ToString("dd/MM/yyyy HH:mm"), diengiai, thu.ToString("#,##0") + " đ", id);
                        dgvTamUng.Rows[rowIndex].Tag = r;
                    }
                }

                lblTongTien.Text = string.Format("Tổng tạm ứng: {0:N0} đ", tongTien);
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tạm ứng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateButtonsState()
        {
            bool hasRows = dgvTamUng.SelectedRows.Count > 0;
            tsbSua.Enabled = hasRows;
            tsbXoa.Enabled = hasRows;
        }

        private void tsbThem_Click(object sender, EventArgs e)
        {
            ThemTamUng();
        }

        private void ThemTamUng()
        {
            if (string.IsNullOrEmpty(_tdonhangId) && string.IsNullOrEmpty(_tdathangId))
            {
                MessageBox.Show("Hóa đơn chưa được lưu, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool aeSuccess = false;
            try
            {
                object formObj = Config.CreateAeForm("TTHUCHI", 0, "");
                if (formObj is DynamicAeForm aeForm)
                {
                    aeForm.ReLoad("");
                    if (aeForm.CodeRunner != null)
                    {
                        MethodInfo mi = aeForm.CodeRunner.GetType().GetMethod("SetTamUng", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        if (mi != null)
                        {
                            mi.Invoke(aeForm.CodeRunner, new object[] { _tdonhangId });
                        }
                    }
                    aeForm.ShowDialog();
                    aeSuccess = true;
                    LoadGrid();
                    return;
                }
            }
            catch
            {
                aeSuccess = false;
            }

            if (!aeSuccess)
            {
                // Fallback: Dialog nhập tạm ứng nhanh gọn
                using (var dlg = new FormThemTamUngNhanh(_tdonhangId, _tdathangId, _tenBan))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadGrid();
                    }
                }
            }
        }

        private void tsbSua_Click(object sender, EventArgs e)
        {
            SuaTamUng();
        }

        private void SuaTamUng()
        {
            if (dgvTamUng.SelectedRows.Count == 0) return;
            string id = dgvTamUng.SelectedRows[0].Cells["colID"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;

            bool aeSuccess = false;
            try
            {
                object formObj = Config.CreateAeForm("TTHUCHI", 0, id);
                if (formObj is DynamicAeForm aeForm)
                {
                    aeForm.ReLoad(id);
                    aeForm.ShowDialog();
                    aeSuccess = true;
                    LoadGrid();
                    return;
                }
            }
            catch
            {
                aeSuccess = false;
            }

            if (!aeSuccess)
            {
                using (var dlg = new FormSuaTamUngNhanh(id))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadGrid();
                    }
                }
            }
        }

        private void tsbXoa_Click(object sender, EventArgs e)
        {
            XoaTamUng();
        }

        private void XoaTamUng()
        {
            if (dgvTamUng.SelectedRows.Count == 0) return;
            string id = dgvTamUng.SelectedRows[0].Cells["colID"].Value?.ToString();
            string name = dgvTamUng.SelectedRows[0].Cells["colNAME"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu tạm ứng '" + name + "' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Config.Db.ExecSql("DELETE FROM TTHUCHI WHERE ID = '" + id + "'");
                    LoadGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa phiếu tạm ứng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbLamMoi_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTamUng_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SuaTamUng();
            }
        }

        private void dgvTamUng_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void dgvTamUng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                XoaTamUng();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Insert)
            {
                ThemTamUng();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SuaTamUng();
                e.Handled = true;
            }
        }

        private void TamUngDonHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                ThemTamUng();
            }
            else if (e.KeyCode == Keys.F5)
            {
                LoadGrid();
            }
        }

        #region Helper Dialogs: Nhập/Sửa tạm ứng nhanh

        private class FormThemTamUngNhanh : Form
        {
            private string _tdonhangId;
            private string _tdathangId;
            private string _tenBan;

            private NumericUpDown numSoTien;
            private TextBox txtDienGiai;
            private ComboBox cboHinhThuc;
            private Button btnLuu;
            private Button btnHuy;

            public FormThemTamUngNhanh(string tdonhangId, string tdathangId, string tenBan)
            {
                _tdonhangId = tdonhangId;
                _tdathangId = tdathangId;
                _tenBan = tenBan;
                BuildUI();
            }

            private void BuildUI()
            {
                this.Text = "Thêm tạm ứng đơn hàng";
                this.Size = new Size(460, 290);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Font = new Font("Segoe UI", 9.5F);

                Label lblHeader = new Label
                {
                    Text = "TẠM ỨNG CHO " + _tenBan.ToUpper(),
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(21, 101, 192),
                    Dock = DockStyle.Top,
                    Height = 35,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(15, 0, 0, 0)
                };

                Label lblTien = new Label { Text = "Số tiền tạm ứng (*):", Location = new Point(20, 50), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                numSoTien = new NumericUpDown
                {
                    Location = new Point(170, 48),
                    Size = new Size(250, 27),
                    Maximum = 1000000000M,
                    ThousandsSeparator = true,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(21, 101, 192)
                };

                // Quick money buttons
                FlowLayoutPanel pnlQuick = new FlowLayoutPanel
                {
                    Location = new Point(170, 80),
                    Size = new Size(260, 32)
                };
                int[] quickVals = { 100000, 200000, 500000, 1000000 };
                foreach (int val in quickVals)
                {
                    Button btnQ = new Button
                    {
                        Text = string.Format("{0:N0}k", val / 1000),
                        Size = new Size(58, 26),
                        Font = new Font("Segoe UI", 8F),
                        Tag = val
                    };
                    btnQ.Click += (s, e) => { numSoTien.Value = Convert.ToDecimal(((Button)s).Tag); };
                    pnlQuick.Controls.Add(btnQ);
                }

                Label lblHT = new Label { Text = "Hình thức:", Location = new Point(20, 122), AutoSize = true };
                cboHinhThuc = new ComboBox
                {
                    Location = new Point(170, 119),
                    Size = new Size(250, 25),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cboHinhThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản" });
                cboHinhThuc.SelectedIndex = 0;

                Label lblDG = new Label { Text = "Diễn giải:", Location = new Point(20, 158), AutoSize = true };
                txtDienGiai = new TextBox
                {
                    Location = new Point(170, 155),
                    Size = new Size(250, 25),
                    Text = "Tạm ứng cho " + _tenBan
                };

                btnLuu = new Button
                {
                    Text = "Lưu tạm ứng",
                    DialogResult = DialogResult.None,
                    Location = new Point(200, 205),
                    Size = new Size(115, 34),
                    BackColor = Color.FromArgb(21, 101, 192),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat
                };
                btnLuu.Click += BtnLuu_Click;

                btnHuy = new Button
                {
                    Text = "Hủy bỏ",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(325, 205),
                    Size = new Size(95, 34)
                };

                this.Controls.AddRange(new Control[] {
                    lblHeader, lblTien, numSoTien, pnlQuick, lblHT, cboHinhThuc, lblDG, txtDienGiai, btnLuu, btnHuy
                });

                this.AcceptButton = btnLuu;
                this.CancelButton = btnHuy;
            }

            private void BtnLuu_Click(object sender, EventArgs e)
            {
                if (numSoTien.Value <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số tiền tạm ứng lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numSoTien.Focus();
                    return;
                }

                try
                {
                    string id = Guid.NewGuid().ToString();
                    string name = "TU" + DateTime.Now.ToString("yyMMddHHmmss");
                    DateTime ngay = DateTime.Now;
                    string lyDoId = "";

                    try
                    {
                        lyDoId = Config.Db.GetFirstFieldString("SELECT FIRST 1 DLYDOTHUCHIID FROM TTHUCHI WHERE TDONHANGID IS NOT NULL ORDER BY TIMECREATED DESC");
                        if (string.IsNullOrEmpty(lyDoId))
                        {
                            lyDoId = Config.Db.GetFirstFieldString("SELECT ID FROM DLYDOTHUCHI WHERE NAME LIKE '%tạm ứng%' OR NAME LIKE '%Tam ung%'");
                        }
                    }
                    catch { }

                    string sql = @"INSERT INTO TTHUCHI (
                        ID, NAME, NGAY, TENDOITUONG, DIACHI, LOAI, LOAIDOITUONG, 
                        DLYDOTHUCHIID, DIENGIAI, THU, CHI, STATUS, TIMECREATED, 
                        LATAMUNG, TDONHANGID, TDATHANGID, DCUAHANGID, KHONGTHAYDOICONGNO, CHUYENKHOAN
                    ) VALUES (
                        @ID, @NAME, @NGAY, @TENDOITUONG, '', 0, 0, 
                        @DLYDOTHUCHIID, @DIENGIAI, @THU, 0, 1, @TIMECREATED, 
                        1, @TDONHANGID, @TDATHANGID, @DCUAHANGID, 1, @CHUYENKHOAN
                    )";

                    FbCommand cmd = Config.Db.GetCommand(sql);
                    cmd.Parameters.Add("@ID", FbDbType.VarChar).Value = id;
                    cmd.Parameters.Add("@NAME", FbDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@NGAY", FbDbType.TimeStamp).Value = ngay;
                    cmd.Parameters.Add("@TENDOITUONG", FbDbType.VarChar).Value = "Khách hàng " + _tenBan;
                    cmd.Parameters.Add("@DLYDOTHUCHIID", FbDbType.VarChar).Value = string.IsNullOrEmpty(lyDoId) ? (object)DBNull.Value : lyDoId;
                    cmd.Parameters.Add("@DIENGIAI", FbDbType.VarChar).Value = txtDienGiai.Text.Trim();
                    cmd.Parameters.Add("@THU", FbDbType.Decimal).Value = numSoTien.Value;
                    cmd.Parameters.Add("@TIMECREATED", FbDbType.TimeStamp).Value = ngay;
                    cmd.Parameters.Add("@TDONHANGID", FbDbType.VarChar).Value = string.IsNullOrEmpty(_tdonhangId) ? (object)DBNull.Value : _tdonhangId;
                    cmd.Parameters.Add("@TDATHANGID", FbDbType.VarChar).Value = string.IsNullOrEmpty(_tdathangId) ? (object)DBNull.Value : _tdathangId;
                    cmd.Parameters.Add("@DCUAHANGID", FbDbType.VarChar).Value = Shared.DCUAHANGID ?? "";
                    cmd.Parameters.Add("@CHUYENKHOAN", FbDbType.SmallInt).Value = cboHinhThuc.SelectedIndex == 1 ? 1 : 0;

                    Config.Db.ExecSql(cmd);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu phiếu tạm ứng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private class FormSuaTamUngNhanh : Form
        {
            private string _id;
            private NumericUpDown numSoTien;
            private TextBox txtDienGiai;
            private ComboBox cboHinhThuc;
            private Button btnLuu;
            private Button btnHuy;

            public FormSuaTamUngNhanh(string id)
            {
                _id = id;
                BuildUI();
                LoadData();
            }

            private void BuildUI()
            {
                this.Text = "Sửa phiếu tạm ứng";
                this.Size = new Size(460, 250);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Font = new Font("Segoe UI", 9.5F);

                Label lblTien = new Label { Text = "Số tiền tạm ứng (*):", Location = new Point(20, 25), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                numSoTien = new NumericUpDown
                {
                    Location = new Point(170, 23),
                    Size = new Size(250, 27),
                    Maximum = 1000000000M,
                    ThousandsSeparator = true,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(21, 101, 192)
                };

                Label lblHT = new Label { Text = "Hình thức:", Location = new Point(20, 68), AutoSize = true };
                cboHinhThuc = new ComboBox
                {
                    Location = new Point(170, 65),
                    Size = new Size(250, 25),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cboHinhThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản" });
                cboHinhThuc.SelectedIndex = 0;

                Label lblDG = new Label { Text = "Diễn giải:", Location = new Point(20, 108), AutoSize = true };
                txtDienGiai = new TextBox
                {
                    Location = new Point(170, 105),
                    Size = new Size(250, 25)
                };

                btnLuu = new Button
                {
                    Text = "Cập nhật",
                    DialogResult = DialogResult.None,
                    Location = new Point(200, 155),
                    Size = new Size(115, 34),
                    BackColor = Color.FromArgb(21, 101, 192),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat
                };
                btnLuu.Click += BtnLuu_Click;

                btnHuy = new Button
                {
                    Text = "Hủy bỏ",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(325, 155),
                    Size = new Size(95, 34)
                };

                this.Controls.AddRange(new Control[] {
                    lblTien, numSoTien, lblHT, cboHinhThuc, lblDG, txtDienGiai, btnLuu, btnHuy
                });

                this.AcceptButton = btnLuu;
                this.CancelButton = btnHuy;
            }

            private void LoadData()
            {
                try
                {
                    DataTable dt = Config.Db.GetTable("SELECT THU, DIENGIAI, CHUYENKHOAN FROM TTHUCHI WHERE ID = '" + _id + "'");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[0];
                        numSoTien.Value = r["THU"] != DBNull.Value ? Convert.ToDecimal(r["THU"]) : 0;
                        txtDienGiai.Text = r["DIENGIAI"] != DBNull.Value ? r["DIENGIAI"].ToString() : "";
                        int ck = r["CHUYENKHOAN"] != DBNull.Value ? Convert.ToInt32(r["CHUYENKHOAN"]) : 0;
                        cboHinhThuc.SelectedIndex = ck == 1 ? 1 : 0;
                    }
                }
                catch { }
            }

            private void BtnLuu_Click(object sender, EventArgs e)
            {
                if (numSoTien.Value <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số tiền tạm ứng lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numSoTien.Focus();
                    return;
                }

                try
                {
                    string sql = @"UPDATE TTHUCHI SET 
                        THU = @THU, 
                        DIENGIAI = @DIENGIAI, 
                        CHUYENKHOAN = @CHUYENKHOAN,
                        TIMEMODIFIED = @TIMEMODIFIED
                        WHERE ID = @ID";

                    FbCommand cmd = Config.Db.GetCommand(sql);
                    cmd.Parameters.Add("@THU", FbDbType.Decimal).Value = numSoTien.Value;
                    cmd.Parameters.Add("@DIENGIAI", FbDbType.VarChar).Value = txtDienGiai.Text.Trim();
                    cmd.Parameters.Add("@CHUYENKHOAN", FbDbType.SmallInt).Value = cboHinhThuc.SelectedIndex == 1 ? 1 : 0;
                    cmd.Parameters.Add("@TIMEMODIFIED", FbDbType.TimeStamp).Value = DateTime.Now;
                    cmd.Parameters.Add("@ID", FbDbType.VarChar).Value = _id;

                    Config.Db.ExecSql(cmd);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật phiếu tạm ứng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}
