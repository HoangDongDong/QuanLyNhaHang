using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace QuanLyNhaHang.Forms
{
    /// <summary>Form thêm / sửa nhân viên — lưu vào DNHANVIEN</summary>
    public class FormNhanVienEdit : Form
    {
        private readonly string _cs;
        private readonly string _editId;

        public bool   Saved   { get; private set; }
        public string SavedId { get; private set; }

        // Controls
        private TextBox  txtName, txtDiaChi, txtDienThoai, txtGhiChu, txtLuongCa, txtLuongThang;
        private RadioButton rdoLuongCa, rdoLuongThangCa, rdoLuongThangNgay;
        private CheckBox chkNghiThu7, chkNghiChuNhat;

        public FormNhanVienEdit(string connectionString, string editId = null)
        {
            _cs     = connectionString;
            _editId = editId;
            BuildUI();
            if (editId != null) LoadData(editId);
        }

        // ── Build UI ────────────────────────────────────────────────────────
        private void BuildUI()
        {
            Text            = _editId == null ? "NHÂN VIÊN - THÊM MỚI" : "NHÂN VIÊN - SỬA";
            Size            = new Size(540, 560);
            StartPosition   = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            BackColor       = Color.FromArgb(225, 232, 245);
            Font            = new Font("Segoe UI", 9f);

            // Header
            var hdr = new Panel { Dock = DockStyle.Top, Height = 58, BackColor = Color.FromArgb(212, 222, 238) };
            hdr.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                DrawDualPersonIcon(g, 12, 10, 36);
                using (var f = new Font("Segoe UI", 12f, FontStyle.Bold))
                g.DrawString("Nhân viên", f, Brushes.DimGray, 58, 16);
            };
            Controls.Add(hdr);

            // Body
            var body = new Panel { Location = new Point(0, 58), Size = new Size(540, 420), BackColor = Color.Transparent };
            Controls.Add(body);

            int lx = 12, rx = 170, y = 14, gap = 34;

            // ── Basic fields ─────────────────────────────────────────────
            body.Controls.Add(Lbl("Tên nhân viên", lx, y));
            txtName = Txt(rx, y, 270); body.Controls.Add(txtName);

            body.Controls.Add(Lbl("Địa chỉ", lx, y += gap));
            txtDiaChi = Txt(rx, y, 270); body.Controls.Add(txtDiaChi);

            body.Controls.Add(Lbl("Điện thoại", lx, y += gap));
            txtDienThoai = Txt(rx, y, 270); body.Controls.Add(txtDienThoai);

            // ── Salary section ───────────────────────────────────────────
            body.Controls.Add(new Label { Text = "Cách tính lương", Location = new Point(lx, y += gap + 8),
                AutoSize = true, Font = new Font("Segoe UI", 9f, FontStyle.Bold) });

            // Option 1
            rdoLuongCa = Rdo("Lương theo ca", lx + 10, y += 26); body.Controls.Add(rdoLuongCa);
            rdoLuongCa.Checked = true;
            body.Controls.Add(Lbl("Lương ca", 200, y));
            txtLuongCa = Txt(288, y, 120, "0"); body.Controls.Add(txtLuongCa);
            body.Controls.Add(SmallItalic("(Cách tính: Lương = Tổng ca làm việc × Lương ca)", lx + 20, y += 22));

            // Option 2
            rdoLuongThangCa = Rdo("Lương tháng theo ca", lx + 10, y += 20); body.Controls.Add(rdoLuongThangCa);
            body.Controls.Add(Lbl("Lương tháng", 200, y));
            txtLuongThang = Txt(288, y, 120, "0"); body.Controls.Add(txtLuongThang);
            body.Controls.Add(SmallItalic("(Cách tính: Lương = Tổng ca làm việc × Lương tháng / số ngày tháng)", lx + 20, y += 22));

            // Option 3
            rdoLuongThangNgay = Rdo("Lương tháng theo ngày", lx + 10, y += 20); body.Controls.Add(rdoLuongThangNgay);
            chkNghiThu7   = new CheckBox { Text = "Nghỉ thứ 7",   Location = new Point(lx + 26, y += 22), AutoSize = true, Enabled = false };
            chkNghiChuNhat = new CheckBox { Text = "Nghỉ chủ nhật", Location = new Point(lx + 140, y), AutoSize = true, Enabled = false };
            body.Controls.Add(chkNghiThu7);
            body.Controls.Add(chkNghiChuNhat);
            body.Controls.Add(SmallItalic("(Cách tính: Lương = Tổng ngày làm việc × Lương tháng / số ngày tháng)", lx + 20, y += 22));

            // Ghi chú
            body.Controls.Add(Lbl("Ghi chú", lx, y += 26));
            txtGhiChu = Txt(rx, y, 270); body.Controls.Add(txtGhiChu);

            // Wire radio change
            rdoLuongCa.CheckedChanged        += SyncSalaryControls;
            rdoLuongThangCa.CheckedChanged   += SyncSalaryControls;
            rdoLuongThangNgay.CheckedChanged += SyncSalaryControls;

            // ── Footer ───────────────────────────────────────────────────
            var footer = new Panel { Dock = DockStyle.Bottom, Height = 48, BackColor = Color.White };
            Controls.Add(footer);

            int bx = 110, by2 = 8, bh = 32;
            var btnLuu      = Btn("Lưu",           bx,        by2, 85,  bh); footer.Controls.Add(btnLuu);
            var btnLuuMoi   = Btn("Lưu & Mới",     bx += 90,  by2, 95,  bh); footer.Controls.Add(btnLuuMoi);
            var btnLuuThoat = Btn("Lưu & thoát",   bx += 100, by2, 95,  bh); footer.Controls.Add(btnLuuThoat);
            var btnThoat    = Btn("Thoát",         bx += 100, by2, 80,  bh); footer.Controls.Add(btnThoat);

            btnLuu.Click      += (s, e) => DoSave(false, false);
            btnLuuMoi.Click   += (s, e) => DoSave(false, true);
            btnLuuThoat.Click += (s, e) => DoSave(true,  false);
            btnThoat.Click    += (s, e) => Close();

            txtName.Focus();
        }

        private void SyncSalaryControls(object s, EventArgs e)
        {
            txtLuongCa.Enabled     = rdoLuongCa.Checked;
            txtLuongThang.Enabled  = rdoLuongThangCa.Checked || rdoLuongThangNgay.Checked;
            chkNghiThu7.Enabled    = rdoLuongThangNgay.Checked;
            chkNghiChuNhat.Enabled = rdoLuongThangNgay.Checked;
        }

        // ── Save ────────────────────────────────────────────────────────────
        private void DoSave(bool closeAfter, bool resetAfter)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return;
            }

            short cach = rdoLuongCa.Checked ? (short)0 : rdoLuongThangCa.Checked ? (short)1 : (short)2;
            decimal.TryParse(txtLuongCa.Text,    out decimal luongCa);
            decimal.TryParse(txtLuongThang.Text, out decimal luongThang);

            try
            {
                using (var conn = new FbConnection(_cs))
                {
                    conn.Open();

                    string id;
                    string sql;
                    if (_editId == null)
                    {
                        id  = Guid.NewGuid().ToString();
                        sql = @"INSERT INTO DNHANVIEN
                                  (ID, NAME, DIACHI, DIENTHOAI, NOTE,
                                   CACHTINHLUONG, LUONGCA, LUONGTHANG, LUONGTHEOCA,
                                   NGHITHU7, NGHICHUNHAT,
                                   TIMECREATED, TIMEMODIFIED, STATUS, SORTORDER, ITEMTYPE, USERCREATEDID)
                                VALUES
                                  (@id, @name, @dc, @dt, @note,
                                   @cach, @lca, @lth, @lca,
                                   @t7, @cn,
                                   CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1, @name, 0, '1')";
                    }
                    else
                    {
                        id  = _editId;
                        sql = @"UPDATE DNHANVIEN SET
                                  NAME=@name, DIACHI=@dc, DIENTHOAI=@dt, NOTE=@note,
                                  CACHTINHLUONG=@cach, LUONGCA=@lca, LUONGTHANG=@lth, LUONGTHEOCA=@lca,
                                  NGHITHU7=@t7, NGHICHUNHAT=@cn, TIMEMODIFIED=CURRENT_TIMESTAMP
                                WHERE ID=@id";
                    }

                    using (var cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id",   id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@dc",   txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@dt",   txtDienThoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@note", txtGhiChu.Text.Trim());
                        cmd.Parameters.AddWithValue("@cach", cach);
                        cmd.Parameters.AddWithValue("@lca",  luongCa);
                        cmd.Parameters.AddWithValue("@lth",  luongThang);
                        cmd.Parameters.AddWithValue("@t7",   (short)(chkNghiThu7.Checked   ? 1 : 0));
                        cmd.Parameters.AddWithValue("@cn",   (short)(chkNghiChuNhat.Checked ? 1 : 0));
                        cmd.ExecuteNonQuery();
                    }

                    SavedId = id;
                    Saved   = true;
                }

                if (closeAfter) { Close(); return; }
                if (resetAfter) { Reset(); return; }
                MessageBox.Show("Lưu thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData(string id)
        {
            try
            {
                using (var conn = new FbConnection(_cs))
                {
                    conn.Open();
                    using (var da = new FbDataAdapter("SELECT * FROM DNHANVIEN WHERE ID=@id", conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@id", id);
                        var dt = new DataTable(); da.Fill(dt);
                        if (dt.Rows.Count == 0) return;
                        var r = dt.Rows[0];
                        txtName.Text       = r["NAME"]?.ToString()      ?? "";
                        txtDiaChi.Text     = r["DIACHI"]?.ToString()    ?? "";
                        txtDienThoai.Text  = r["DIENTHOAI"]?.ToString() ?? "";
                        txtGhiChu.Text     = r["NOTE"]?.ToString()      ?? "";
                        txtLuongCa.Text    = r["LUONGCA"]?.ToString()   ?? "0";
                        txtLuongThang.Text = r["LUONGTHANG"]?.ToString()?? "0";
                        short cach = 0; short.TryParse(r["CACHTINHLUONG"]?.ToString(), out cach);
                        rdoLuongCa.Checked        = cach == 0;
                        rdoLuongThangCa.Checked   = cach == 1;
                        rdoLuongThangNgay.Checked = cach == 2;
                        chkNghiThu7.Checked    = r["NGHITHU7"]?.ToString()    == "1";
                        chkNghiChuNhat.Checked = r["NGHICHUNHAT"]?.ToString() == "1";
                    }
                }
            }
            catch { }
        }

        private void Reset()
        {
            txtName.Text = txtDiaChi.Text = txtDienThoai.Text = txtGhiChu.Text = "";
            txtLuongCa.Text = txtLuongThang.Text = "0";
            rdoLuongCa.Checked = true;
            chkNghiThu7.Checked = chkNghiChuNhat.Checked = false;
            Saved = false; txtName.Focus();
        }

        // ── Helpers ─────────────────────────────────────────────────────────
        private Label Lbl(string t, int x, int y) =>
            new Label { Text = t, Location = new Point(x, y + 4), AutoSize = true };

        private Label SmallItalic(string t, int x, int y) =>
            new Label { Text = t, Location = new Point(x, y), AutoSize = true,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Italic), ForeColor = Color.Gray };

        private RadioButton Rdo(string t, int x, int y) =>
            new RadioButton { Text = t, Location = new Point(x, y), AutoSize = true };

        private TextBox Txt(int x, int y, int w, string def = "") =>
            new TextBox { Location = new Point(x, y), Size = new Size(w, 22), Text = def, BorderStyle = BorderStyle.FixedSingle };

        private Button Btn(string t, int x, int y, int w, int h)
        {
            var b = new Button
            {
                Text = t, Location = new Point(x, y), Size = new Size(w, h),
                UseVisualStyleBackColor = true,
                Cursor = Cursors.Hand
            };
            return b;
        }

        private void DrawDualPersonIcon(Graphics g, int x, int y, int sz)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int h = sz / 3;
            using (var b = new SolidBrush(Color.FromArgb(80, 160, 60)))
            {
                g.FillEllipse(b, x + h, y, h, h);
                g.SetClip(new Region(new RectangleF(x + h / 2f, y + h, h * 2, h)), CombineMode.Replace);
                g.FillEllipse(b, x + 2, y + h, h * 3, h * 2);
                g.ResetClip();
            }
            using (var b = new SolidBrush(Color.FromArgb(210, 100, 40)))
            {
                g.FillEllipse(b, x + 2, y + h / 2, h, h);
                g.SetClip(new Region(new RectangleF(x, y + h + h / 2f, h * 2, h)), CombineMode.Replace);
                g.FillEllipse(b, x - 2, y + h + h / 2, h * 3, h * 2);
                g.ResetClip();
            }
        }
    }
}
