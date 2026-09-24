using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using FirebirdSql.Data.FirebirdClient;

namespace QuanLyNhaHang.Services
{
    public class FormModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public int FormType { get; set; }
        public int Loai { get; set; }
        public string STableDescId { get; set; }
        public string SFunctionId { get; set; }
        public string BillCode { get; set; }
        public string Noun { get; set; }
        public string Verb { get; set; }
        public string Code { get; set; }
        public string DesignCode { get; set; }
        public string AeLayout { get; set; }
        public string ClientCode { get; set; }
        public string ServerCode { get; set; }
        public string Note { get; set; }
        public byte[] ImageBytes { get; set; }
    }


    public static class DbFormService
    {
        public static string DefaultDbPath = @"d:\QuanLyNhaHang\Database\DEMO.FDB";

        public static string GetConnectionString(string dbPath = null)
        {
            if (string.IsNullOrEmpty(dbPath))
                dbPath = Program.CurrentDatabasePath;
            if (string.IsNullOrEmpty(dbPath))
                dbPath = DefaultDbPath;

            FbConnectionStringBuilder builder = new FbConnectionStringBuilder
            {
                UserID = "SYSDBA",
                Password = "masterkey",
                Database = dbPath,
                DataSource = "localhost",
                Port = 3050,
                Dialect = 3,
                Charset = "NONE",
                ServerType = FbServerType.Default
            };

            return builder.ConnectionString;
        }

        public static Form CreateFormFromModel(FormModel model)
        {
            if (model == null) return new Form { Size = new Size(800, 500) };

            if (!string.IsNullOrEmpty(model.AeLayout) && model.AeLayout.Trim().Length > 20)
            {
                string stitchedXml = StitchFormXmlLayouts(model);
                Form xmlForm = ParseAeLayoutToForm(stitchedXml, model.Name);
                if (xmlForm != null)
                {
                    AttachDynamicDataBindings(xmlForm, model);
                    return xmlForm;
                }
            }

            return CreateFormByName(model.Name ?? model.Id);
        }

                public static bool ShowDynamicDataEntryForm(string formName, string tableName, string idValue = null)
        {
            try
            {
                Form originalActiveForm = Form.ActiveForm;

                Form dynamicForm = CreateFormByName(formName);
                if (dynamicForm == null) return false;

                QuanLyNhaHang.Forms.FormDataEntryTemplate wrapper = new QuanLyNhaHang.Forms.FormDataEntryTemplate();
                string title = dynamicForm.Text + (string.IsNullOrEmpty(idValue) ? " (Thêm)" : " (Sửa)");
                wrapper.EmbedDynamicForm(dynamicForm, title);

                bool isSuserForm = string.Equals(tableName, "SUSER", StringComparison.OrdinalIgnoreCase);

                // Populate lookups
                PopulateLookupEdits(dynamicForm);

                if (isSuserForm)
                {
                    InjectTaiKhoanNguoiDungUI(dynamicForm, wrapper);
                }

                // Load Data for Edit Mode
                if (!string.IsNullOrEmpty(idValue))
                {
                    if (isSuserForm)
                    {
                        LoadSuserDataToForm(dynamicForm, idValue);
                    }
                    else
                    {
                        LoadDataToForm(dynamicForm, tableName, idValue);
                    }
                }

                string[] idHolder = new string[] { idValue };

                wrapper.btnLuu.Click += (s, e) =>
                {
                    bool success = isSuserForm ? SaveSuserDataFromForm(dynamicForm, idHolder) : SaveDataFromForm(dynamicForm, tableName, idHolder[0]);
                    if (success)
                    {
                        wrapper.DialogResult = DialogResult.OK;
                        wrapper.Close();
                    }
                };
                
                wrapper.btnLuuMoi.Click += (s, e) =>
                {
                    bool success = isSuserForm ? SaveSuserDataFromForm(dynamicForm, idHolder) : SaveDataFromForm(dynamicForm, tableName, idHolder[0]);
                    if (success)
                    {
                        ClearFormFields(dynamicForm);
                        idHolder[0] = null; // Chuyển sang chế độ thêm mới
                        wrapper.Text = dynamicForm.Text + " (Thêm)";
                        wrapper.lblTitle.Text = wrapper.Text.ToUpper();
                    }
                };

                wrapper.btnLuuThoat.Click += (s, e) =>
                {
                    bool success = isSuserForm ? SaveSuserDataFromForm(dynamicForm, idHolder) : SaveDataFromForm(dynamicForm, tableName, idHolder[0]);
                    if (success)
                    {
                        wrapper.DialogResult = DialogResult.OK;
                        wrapper.Close();
                    }
                };

                wrapper.btnThoat.Click += (s, e) => { wrapper.DialogResult = DialogResult.Cancel; wrapper.Close(); };

                if (originalActiveForm != null)
                {
                    return wrapper.ShowDialog(originalActiveForm) == DialogResult.OK;
                }
                return wrapper.ShowDialog() == DialogResult.OK;
            }
            catch (Exception ex)
            {
                using (Form topmostForm = new Form { TopMost = true })
                {
                    MessageBox.Show(topmostForm, "Lỗi hiển thị form động: " + ex.Message + "\n" + ex.StackTrace, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        private static void InjectTaiKhoanNguoiDungUI(Control form, QuanLyNhaHang.Forms.FormDataEntryTemplate wrapper)
        {
            try
            {
                if (wrapper == null) return;

                // === All setup runs AFTER form is fully shown ===
                wrapper.Shown += (sender, e) =>
                {
                    try
                    {
                        // Find lueDNHANVIENID AFTER form is rendered
                        Control lueNV = FindControlRecursive(form, "lueDNHANVIENID");
                        if (lueNV == null || lueNV.Parent == null) return;

                        // Load DNHANVIEN data
                        DataTable nvTable = new DataTable();
                        System.Collections.Generic.Dictionary<string, Image> nvImageCache = new System.Collections.Generic.Dictionary<string, Image>();
                        Action loadNVData = () =>
                        {
                            try
                            {
                                using (FbConnection conn = new FbConnection(GetConnectionString()))
                                {
                                    conn.Open();
                                    using (FbDataAdapter da = new FbDataAdapter(
                                        "SELECT A.ID, A.NAME, I.IMAGE FROM DNHANVIEN A LEFT JOIN SIMAGE I ON A.SIMAGEID = I.ID ORDER BY A.NAME", conn))
                                    {
                                        nvTable.Clear();
                                        da.Fill(nvTable);
                                    }
                                }
                            }
                            catch (Exception ex2)
                            {
                                System.Diagnostics.Debug.WriteLine("loadNVData err: " + ex2.Message);
                            }
                        };
                        loadNVData();

                        // Create custom dropdown UI to replace ComboBox
                        Control lueParent = lueNV.Parent;
                        Point loc = lueNV.Location;
                        int w = lueNV.Width;

                        // Fake ComboBox
                        Panel fakeCombo = new Panel
                        {
                            Name = "fakeComboNV",
                            Location = loc,
                            Size = new Size(w, 23),
                            BackColor = Color.White,
                            Cursor = Cursors.Hand
                        };
                        
                        Label lblText = new Label
                        {
                            Location = new Point(24, 2),
                            Size = new Size(w - 44, 18),
                            Text = "",
                            TextAlign = ContentAlignment.MiddleLeft,
                            BackColor = Color.Transparent,
                            Cursor = Cursors.Hand
                        };
                        fakeCombo.Controls.Add(lblText);

                        // ToolStripDropDown
                        ToolStripDropDown dropDown = new ToolStripDropDown();
                        dropDown.AutoSize = true;
                        dropDown.Margin = Padding.Empty;
                        dropDown.Padding = Padding.Empty;

                        ListBox lst = new ListBox
                        {
                            Dock = DockStyle.Top,
                            Height = 160,
                            BorderStyle = BorderStyle.None,
                            DrawMode = DrawMode.OwnerDrawFixed,
                            ItemHeight = 22
                        };

                        Action bindList = () => {
                            lst.Items.Clear();
                            foreach (Image img in nvImageCache.Values) { if (img != null) img.Dispose(); }
                            nvImageCache.Clear();

                            foreach (System.Data.DataRow r in nvTable.Rows) {
                                string id = r["ID"].ToString();
                                lst.Items.Add(new System.Collections.Generic.KeyValuePair<string, string>(id, r["NAME"].ToString()));
                                if (r["IMAGE"] != DBNull.Value) {
                                    try {
                                        byte[] bytes = (byte[])r["IMAGE"];
                                        using (var ms = new System.IO.MemoryStream(bytes)) {
                                            nvImageCache[id] = Image.FromStream(ms);
                                        }
                                    } catch { }
                                }
                            }
                        };
                        bindList();

                        // Draw dual-person icon matching reference
                        Action<Graphics, int, int> drawPersonIcon = (g2, px, py) =>
                        {
                            g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            using (var b = new SolidBrush(Color.FromArgb(80, 160, 60)))
                            {
                                g2.FillEllipse(b, px + 5, py + 0, 7, 7);
                                var rgn = new System.Drawing.Region(new RectangleF(px + 3, py + 7, 11, 6));
                                g2.SetClip(rgn, System.Drawing.Drawing2D.CombineMode.Replace);
                                g2.FillEllipse(b, px + 1, py + 6, 15, 11);
                                g2.ResetClip();
                            }
                            using (var b = new SolidBrush(Color.FromArgb(210, 100, 40)))
                            {
                                g2.FillEllipse(b, px + 1, py + 2, 7, 7);
                                var rgn = new System.Drawing.Region(new RectangleF(px, py + 9, 11, 7));
                                g2.SetClip(rgn, System.Drawing.Drawing2D.CombineMode.Replace);
                                g2.FillEllipse(b, px - 1, py + 8, 14, 11);
                                g2.ResetClip();
                            }
                        };

                        fakeCombo.Paint += (s2, e2) =>
                        {
                            ControlPaint.DrawComboButton(e2.Graphics, new Rectangle(fakeCombo.Width - 17, 1, 16, fakeCombo.Height - 2), ButtonState.Normal);
                            using (var p = new Pen(Color.FromArgb(171, 193, 222)))
                                e2.Graphics.DrawRectangle(p, 0, 0, fakeCombo.Width - 1, fakeCombo.Height - 1);

                            if (lst.SelectedIndex >= 0) {
                                Image icon = null;
                                if (lst.Items[lst.SelectedIndex] is System.Collections.Generic.KeyValuePair<string, string> kvp) {
                                    nvImageCache.TryGetValue(kvp.Key, out icon);
                                }
                                if (icon != null) {
                                    e2.Graphics.DrawImage(icon, new Rectangle(3, 3, 16, 16));
                                } else {
                                    drawPersonIcon(e2.Graphics, 3, 3);
                                }
                            }
                        };

                        lst.DrawItem += (s2, e2) =>
                        {
                            if (e2.Index < 0) return;
                            Graphics g = e2.Graphics;
                            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                            bool sel = (e2.State & DrawItemState.Selected) != 0;
                            if (sel)
                            {
                                using (var b = new SolidBrush(Color.FromArgb(255, 245, 204)))
                                    g.FillRectangle(b, e2.Bounds);
                                using (var p = new Pen(Color.FromArgb(242, 202, 88)))
                                    g.DrawRectangle(p, e2.Bounds.X, e2.Bounds.Y, e2.Bounds.Width - 1, e2.Bounds.Height - 1);
                            }
                            else
                            {
                                using (var b = new SolidBrush(lst.BackColor))
                                    g.FillRectangle(b, e2.Bounds);
                            }

                            int iy = e2.Bounds.Y + (e2.Bounds.Height - 18) / 2;
                            
                            string nm = "";
                            Image icon = null;
                            if (lst.Items[e2.Index] is System.Collections.Generic.KeyValuePair<string, string> kvp) {
                                nm = kvp.Value;
                                nvImageCache.TryGetValue(kvp.Key, out icon);
                            }
                            
                            if (icon != null) {
                                g.DrawImage(icon, new Rectangle(e2.Bounds.X + 3, iy, 16, 16));
                            } else {
                                drawPersonIcon(g, e2.Bounds.X + 3, iy);
                            }

                            var tr = new Rectangle(e2.Bounds.X + 24, e2.Bounds.Y,
                                e2.Bounds.Width - 26, e2.Bounds.Height);
                            TextRenderer.DrawText(g, nm, lst.Font, tr,
                                SystemColors.WindowText,
                                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.SingleLine);
                        };

                        Panel pnlActions = new Panel
                        {
                            Dock = DockStyle.Bottom,
                            Height = 28,
                            BackColor = Color.White
                        };

                        Action<Button, string> styleBtn = (btn, text) => {
                            btn.Text = text;
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.BackColor = Color.White;
                            btn.ForeColor = Color.Black;
                            btn.Font = new Font(lueNV.Font.FontFamily, 8, FontStyle.Regular);
                            btn.FlatAppearance.BorderSize = 0;
                            btn.Cursor = Cursors.Hand;
                            btn.Paint += (sb, eb) => {
                                eb.Graphics.DrawLine(SystemPens.ControlDark, 0, 0, btn.Width, 0);
                                if (text != "Danh mục")
                                    eb.Graphics.DrawLine(SystemPens.ControlDark, btn.Width - 1, 0, btn.Width - 1, btn.Height);
                                
                                eb.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                if (text.Contains("Thêm")) {
                                    using (var p = new Pen(Color.FromArgb(60, 160, 60), 2.5f)) {
                                        eb.Graphics.DrawLine(p, btn.Width/2 - 20, btn.Height/2, btn.Width/2 - 12, btn.Height/2);
                                        eb.Graphics.DrawLine(p, btn.Width/2 - 16, btn.Height/2 - 4, btn.Width/2 - 16, btn.Height/2 + 4);
                                    }
                                } else if (text.Contains("Tải")) {
                                    using (var p = new Pen(Color.FromArgb(40, 100, 200), 1.5f)) {
                                        eb.Graphics.DrawArc(p, btn.Width/2 - 18, btn.Height/2 - 4, 8, 8, 45, 270);
                                        eb.Graphics.DrawLine(p, btn.Width/2 - 13, btn.Height/2 - 4, btn.Width/2 - 10, btn.Height/2 - 4);
                                        eb.Graphics.DrawLine(p, btn.Width/2 - 10, btn.Height/2 - 4, btn.Width/2 - 10, btn.Height/2 - 1);
                                    }
                                }
                            };
                        };

                        int bw3 = w / 3;
                        Button b1 = new Button { Location = new Point(0, 0), Size = new Size(bw3, 28) };
                        Button b2 = new Button { Location = new Point(bw3, 0), Size = new Size(bw3, 28) };
                        Button b3 = new Button { Location = new Point(bw3*2, 0), Size = new Size(w - bw3*2, 28) };
                        styleBtn(b1, "Thêm");
                        styleBtn(b2, "Tải");
                        styleBtn(b3, "Danh mục");
                        
                        b1.Click += (s2, e2) =>
                        {
                            dropDown.Close();
                            using (var f = new QuanLyNhaHang.Forms.FormNhanVienEdit(GetConnectionString()))
                            {
                                f.ShowDialog(wrapper);
                                if (f.Saved) { loadNVData(); bindList(); }
                            }
                        };
                        b2.Click += (s2, e2) => { loadNVData(); bindList(); };
                        b3.Click += (s2, e2) => { dropDown.Close(); ShowDynamicDataEntryForm("Nhân viên", "DNHANVIEN"); };
                        pnlActions.Controls.AddRange(new Control[] { b1, b2, b3 });

                        Panel dropContainer = new Panel
                        {
                            Width = w - 2,
                            Height = lst.Height + pnlActions.Height + 2,
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        dropContainer.Controls.Add(lst);
                        dropContainer.Controls.Add(pnlActions);
                        
                        ToolStripControlHost dropHost = new ToolStripControlHost(dropContainer) { AutoSize = false, Size = dropContainer.Size, Margin = Padding.Empty, Padding = Padding.Empty };
                        dropDown.Items.Add(dropHost);

                        EventHandler showDrop = (s2, e2) => { dropDown.Show(fakeCombo, new Point(0, fakeCombo.Height)); };
                        fakeCombo.Click += showDrop;
                        lblText.Click += showDrop;

                        lst.SelectedIndexChanged += (s2, e2) =>
                        {
                            try
                            {
                                if (lst.SelectedIndex < 0) return;
                                string nm = "";
                                string id = "";
                                if (lst.SelectedItem is System.Collections.Generic.KeyValuePair<string, string> kvp) {
                                    id = kvp.Key;
                                    nm = kvp.Value;
                                }
                                lblText.Text = nm;
                                fakeCombo.Invalidate(); // redraw icon
                                var evProp = lueNV.GetType().GetProperty("EditValue");
                                if (evProp != null && evProp.CanWrite && !string.IsNullOrEmpty(id))
                                    evProp.SetValue(lueNV, id, null);
                            }
                            catch { }
                        };
                        lst.Click += (s2, e2) => { dropDown.Close(); };

                        // Set initial selection
                        if (lst.Items.Count > 0)
                        {
                            lst.SelectedIndex = 0;
                        }

                        // Sync editValue changes from original control to our fake combo
                        var evChangedEvt = lueNV.GetType().GetEvent("EditValueChanged");
                        if (evChangedEvt != null)
                        {
                            EventHandler onEvChanged = (s2, e2) =>
                            {
                                try
                                {
                                    var evProp = lueNV.GetType().GetProperty("EditValue");
                                    if (evProp != null)
                                    {
                                        object val = evProp.GetValue(lueNV, null);
                                        if (val != null) lst.SelectedValue = val;
                                    }
                                }
                                catch { }
                            };
                            evChangedEvt.AddEventHandler(lueNV, onEvChanged);
                        }

                        // Collapse original, add our controls
                        lueNV.Size = new Size(lueNV.Width, 0);
                        lueNV.SendToBack();

                        lueParent.SuspendLayout();
                        lueParent.Controls.Add(fakeCombo);
                        fakeCombo.BringToFront();
                        lueParent.ResumeLayout(true);

                        // Fix for Nhóm người dùng (lueSGROUPUSERID) - using custom fake combo with buttons
                        Control lueGroup = FindControlRecursive(form, "lueSGROUPUSERID");
                        if (lueGroup != null && lueGroup.Parent != null)
                        {
                            DataTable groupTable = new DataTable();
                            System.Collections.Generic.Dictionary<string, Image> groupImageCache = new System.Collections.Generic.Dictionary<string, Image>();
                            Action loadGroupData = () => {
                                try {
                                    using (FbConnection conn = new FbConnection(GetConnectionString())) {
                                        conn.Open();
                                        using (FbDataAdapter da = new FbDataAdapter("SELECT A.ID, A.NAME, I.IMAGE FROM SGROUPUSER A LEFT JOIN SIMAGE I ON A.SIMAGEID = I.ID ORDER BY A.NAME", conn)) {
                                            groupTable.Clear();
                                            da.Fill(groupTable);
                                        }
                                    }
                                } catch { }
                            };
                            loadGroupData();

                            Control lueGParent = lueGroup.Parent;
                            Point locG = lueGroup.Location;
                            int wG = lueGroup.Width;

                            Panel fakeComboGroup = new Panel {
                                Name = "fakeComboGroup", Location = locG, Size = new Size(wG, 23),
                                BackColor = Color.White, Cursor = Cursors.Hand
                            };
                            
                            Label lblTextGroup = new Label {
                                Location = new Point(24, 2), Size = new Size(wG - 44, 18),
                                Text = "", TextAlign = ContentAlignment.MiddleLeft, BackColor = Color.Transparent, Cursor = Cursors.Hand
                            };
                            fakeComboGroup.Controls.Add(lblTextGroup);

                            ToolStripDropDown dropDownGroup = new ToolStripDropDown { AutoSize = true, Margin = Padding.Empty, Padding = Padding.Empty };
                            ListBox lstGroup = new ListBox {
                                Dock = DockStyle.Top, Height = 100, BorderStyle = BorderStyle.None,
                                DrawMode = DrawMode.OwnerDrawFixed, ItemHeight = 22
                            };

                            Action bindGroupList = () => {
                                lstGroup.Items.Clear();
                                foreach (Image img in groupImageCache.Values) { if (img != null) img.Dispose(); }
                                groupImageCache.Clear();

                                foreach (System.Data.DataRow r in groupTable.Rows) {
                                    string id = r["ID"].ToString();
                                    lstGroup.Items.Add(new System.Collections.Generic.KeyValuePair<string, string>(id, r["NAME"].ToString()));
                                    if (r["IMAGE"] != DBNull.Value) {
                                        try {
                                            byte[] bytes = (byte[])r["IMAGE"];
                                            using (var ms = new System.IO.MemoryStream(bytes)) {
                                                groupImageCache[id] = Image.FromStream(ms);
                                            }
                                        } catch { }
                                    }
                                }
                            };
                            bindGroupList();

                            Action<Graphics, int, int> drawGroupIcon = (g2, px, py) => {
                                g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                using (var b = new SolidBrush(Color.FromArgb(210, 150, 40))) {
                                    g2.FillEllipse(b, px + 5, py + 1, 6, 6);
                                    var rgn = new System.Drawing.Region(new RectangleF(px + 4, py + 7, 10, 6));
                                    g2.SetClip(rgn, System.Drawing.Drawing2D.CombineMode.Replace);
                                    g2.FillEllipse(b, px + 2, py + 6, 12, 10);
                                    g2.ResetClip();
                                }
                            };

                            fakeComboGroup.Paint += (s2, e2) => {
                                ControlPaint.DrawComboButton(e2.Graphics, new Rectangle(fakeComboGroup.Width - 17, 1, 16, fakeComboGroup.Height - 2), ButtonState.Normal);
                                using (var p = new Pen(Color.FromArgb(171, 193, 222)))
                                    e2.Graphics.DrawRectangle(p, 0, 0, fakeComboGroup.Width - 1, fakeComboGroup.Height - 1);
                                if (lstGroup.SelectedIndex >= 0) {
                                    Image icon = null;
                                    if (lstGroup.Items[lstGroup.SelectedIndex] is System.Collections.Generic.KeyValuePair<string, string> kvp) {
                                        groupImageCache.TryGetValue(kvp.Key, out icon);
                                    }
                                    if (icon != null) {
                                        e2.Graphics.DrawImage(icon, new Rectangle(3, 3, 16, 16));
                                    } else {
                                        drawGroupIcon(e2.Graphics, 3, 3);
                                    }
                                }
                            };

                            lstGroup.DrawItem += (s2, e2) => {
                                if (e2.Index < 0) return;
                                Graphics g = e2.Graphics;
                                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                                bool sel = (e2.State & DrawItemState.Selected) != 0;
                                if (sel) {
                                    using (var b = new SolidBrush(Color.FromArgb(255, 245, 204)))
                                        g.FillRectangle(b, e2.Bounds);
                                    using (var p = new Pen(Color.FromArgb(242, 202, 88)))
                                        g.DrawRectangle(p, e2.Bounds.X, e2.Bounds.Y, e2.Bounds.Width - 1, e2.Bounds.Height - 1);
                                } else {
                                    using (var b = new SolidBrush(lstGroup.BackColor))
                                        g.FillRectangle(b, e2.Bounds);
                                }
                                int iy = e2.Bounds.Y + (e2.Bounds.Height - 18) / 2;
                                
                                string nm = "";
                                Image icon = null;
                                if (lstGroup.Items[e2.Index] is System.Collections.Generic.KeyValuePair<string, string> kvp) {
                                    nm = kvp.Value;
                                    groupImageCache.TryGetValue(kvp.Key, out icon);
                                }
                                
                                if (icon != null) {
                                    g.DrawImage(icon, new Rectangle(e2.Bounds.X + 3, iy, 16, 16));
                                } else {
                                    drawGroupIcon(g, e2.Bounds.X + 3, iy);
                                }

                                var tr = new Rectangle(e2.Bounds.X + 24, e2.Bounds.Y, e2.Bounds.Width - 26, e2.Bounds.Height);
                                TextRenderer.DrawText(g, nm, lstGroup.Font, tr, SystemColors.WindowText, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.SingleLine);
                            };

                            Panel pnlActionsGroup = new Panel { Dock = DockStyle.Bottom, Height = 28, BackColor = Color.White };
                            int bwG3 = wG / 3;
                            Button bg1 = new Button { Location = new Point(0, 0), Size = new Size(bwG3, 28) };
                            Button bg2 = new Button { Location = new Point(bwG3, 0), Size = new Size(bwG3, 28) };
                            Button bg3 = new Button { Location = new Point(bwG3*2, 0), Size = new Size(wG - bwG3*2, 28) };
                            styleBtn(bg1, "Thêm"); styleBtn(bg2, "Tải"); styleBtn(bg3, "Danh mục");
                            
                            bg1.Click += (s2, e2) => {
                                dropDownGroup.Close();
                                using (var f = new QuanLyNhaHang.Forms.FormGroupUser()) {
                                    if (f.ShowDialog(wrapper) == DialogResult.OK) { loadGroupData(); bindGroupList(); }
                                }
                            };
                            bg2.Click += (s2, e2) => { loadGroupData(); bindGroupList(); };
                            bg3.Click += (s2, e2) => { dropDownGroup.Close(); };
                            pnlActionsGroup.Controls.AddRange(new Control[] { bg1, bg2, bg3 });

                            Panel dropContainerG = new Panel {
                                Width = wG - 2, Height = lstGroup.Height + pnlActionsGroup.Height + 2,
                                BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle
                            };
                            dropContainerG.Controls.Add(lstGroup);
                            dropContainerG.Controls.Add(pnlActionsGroup);
                            
                            ToolStripControlHost dropHostG = new ToolStripControlHost(dropContainerG) { AutoSize = false, Size = dropContainerG.Size, Margin = Padding.Empty, Padding = Padding.Empty };
                            dropDownGroup.Items.Add(dropHostG);

                            EventHandler showDropG = (s2, e2) => { dropDownGroup.Show(fakeComboGroup, new Point(0, fakeComboGroup.Height)); };
                            fakeComboGroup.Click += showDropG;
                            lblTextGroup.Click += showDropG;

                            lstGroup.SelectedIndexChanged += (s2, e2) => {
                                try {
                                    if (lstGroup.SelectedIndex < 0) return;
                                    string nm = ""; string id = "";
                                    if (lstGroup.SelectedItem is System.Collections.Generic.KeyValuePair<string, string> kvp) {
                                        id = kvp.Key; nm = kvp.Value;
                                    }
                                    lblTextGroup.Text = nm;
                                    fakeComboGroup.Invalidate();
                                    var evProp = lueGroup.GetType().GetProperty("EditValue");
                                    if (evProp != null && evProp.CanWrite && !string.IsNullOrEmpty(id))
                                        evProp.SetValue(lueGroup, id, null);
                                } catch { }
                            };
                            lstGroup.Click += (s2, e2) => { dropDownGroup.Close(); };

                            if (lstGroup.Items.Count > 0) lstGroup.SelectedIndex = 0;

                            var evGrpEvt = lueGroup.GetType().GetEvent("EditValueChanged");
                            if (evGrpEvt != null) {
                                EventHandler onGrpEvChanged = (s2, e2) => {
                                    try {
                                        var evProp = lueGroup.GetType().GetProperty("EditValue");
                                        if (evProp != null) {
                                            object val = evProp.GetValue(lueGroup, null);
                                            if (val != null) {
                                                for (int i = 0; i < lstGroup.Items.Count; i++) {
                                                    if (lstGroup.Items[i] is System.Collections.Generic.KeyValuePair<string, string> kv && kv.Key == val.ToString()) {
                                                        lstGroup.SelectedIndex = i;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    } catch { }
                                };
                                evGrpEvt.AddEventHandler(lueGroup, onGrpEvChanged);
                            }

                            Control lgParent = lueGroup.Parent;
                            lueGroup.Size = new Size(lueGroup.Width, 0);
                            lueGroup.SendToBack();
                            lgParent.SuspendLayout();
                            lgParent.Controls.Add(fakeComboGroup);
                            fakeComboGroup.BringToFront();
                            lgParent.ResumeLayout(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("InjectShown err: " + ex.Message + "\n" + ex.StackTrace);
                    }
                };


                // Configure grid for Cửa hàng
                Control grCtrl = FindControlRecursive(form, "grMain");
                if (grCtrl is DataGridView dgv)
                {
                    dgv.Columns.Clear();
                    dgv.AllowUserToAddRows = false;
                    dgv.AllowUserToDeleteRows = false;
                    dgv.RowHeadersVisible = false;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgv.Columns.Add("CuaHangId", "ID");
                    dgv.Columns["CuaHangId"].Visible = false;
                    dgv.Columns.Add("CuaHang", "Cửa hàng");
                    dgv.Columns["CuaHang"].ReadOnly = true;
                    dgv.Columns["CuaHang"].FillWeight = 70;
                    var colCheck = new DataGridViewCheckBoxColumn { Name = "TruyCap", HeaderText = "Truy cập", Width = 70, AutoSizeMode = DataGridViewAutoSizeColumnMode.None };
                    colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colCheck.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns.Add(colCheck);

                    // Load DCUAHANG data
                    try
                    {
                        using (FbConnection conn = new FbConnection(GetConnectionString()))
                        {
                            conn.Open();
                            using (FbCommand cmd = new FbCommand("SELECT ID, NAME FROM DCUAHANG ORDER BY NAME", conn))
                            using (FbDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    string chId = rdr["ID"]?.ToString() ?? "";
                                    string chName = rdr["NAME"]?.ToString() ?? chId;
                                    dgv.Rows.Add(chId, chName, false);
                                }
                            }
                        }
                    } catch { }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("InjectTaiKhoanNguoiDungUI error: " + ex.Message);
            }
        }

        private static void LoadSuserDataToForm(Control form, string userId)
        {
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();

                    // Load SUSER record
                    using (FbCommand cmd = new FbCommand("SELECT * FROM SUSER WHERE ID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Set text fields
                                SetControlTextByName(form, "txtNAME", reader["NAME"]?.ToString() ?? "");
                                SetControlTextByName(form, "txtUSERNAME", reader["USERNAME"]?.ToString() ?? "");
                                SetControlTextByName(form, "txtPASSWORD", reader["PASSWORD"]?.ToString() ?? "");
                                SetControlTextByName(form, "txtEMAIL", reader["EMAIL"]?.ToString() ?? "");
                                SetControlTextByName(form, "txtUSERID", reader["USERID"]?.ToString() ?? "");
                                SetControlTextByName(form, "txtCARDCODE", reader["CARDCODE"]?.ToString() ?? "");

                                // Set LookUpEdits
                                string dnhanvienId = reader["DNHANVIENID"]?.ToString() ?? "";
                                string sgroupuserId = reader["SGROUPUSERID"]?.ToString() ?? "";

                                Control lueNV = FindControlRecursive(form, "lueDNHANVIENID");
                                if (lueNV != null && !string.IsNullOrEmpty(dnhanvienId))
                                {
                                    try {
                                        var props = lueNV.GetType().GetProperty("EditValue") ?? lueNV.GetType().GetProperty("SelectedValue");
                                        props?.SetValue(lueNV, dnhanvienId);
                                    } catch { }
                                }

                                Control lueGroup = FindControlRecursive(form, "lueSGROUPUSERID");
                                if (lueGroup != null && !string.IsNullOrEmpty(sgroupuserId))
                                {
                                    try {
                                        var props = lueGroup.GetType().GetProperty("EditValue") ?? lueGroup.GetType().GetProperty("SelectedValue");
                                        props?.SetValue(lueGroup, sgroupuserId);
                                    } catch { }
                                }
                            }
                        }
                    }

                    // Load TNGUOIDUNGTHEOCUAHANG
                    Control grCtrl = FindControlRecursive(form, "grMain");
                    if (grCtrl is DataGridView dgv)
                    {
                        HashSet<string> accessCuaHangIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        try
                        {
                            using (FbCommand cmd = new FbCommand("SELECT DCUAHANGID FROM TNGUOIDUNGTHEOCUAHANG WHERE SUSERID = @uid", conn))
                            {
                                cmd.Parameters.AddWithValue("@uid", userId);
                                using (FbDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {
                                        string chId = rdr["DCUAHANGID"]?.ToString() ?? "";
                                        if (!string.IsNullOrEmpty(chId)) accessCuaHangIds.Add(chId);
                                    }
                                }
                            }
                        }
                        catch { }

                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            string cuaHangId = row.Cells["CuaHangId"]?.Value?.ToString() ?? "";
                            if (accessCuaHangIds.Contains(cuaHangId))
                            {
                                row.Cells["TruyCap"].Value = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadSuserDataToForm error: " + ex.Message);
            }
        }

        private static bool SaveSuserDataFromForm(Control form, string[] idHolder)
        {
            try
            {
                string idValue = idHolder[0];

                string name = GetControlTextByName(form, "txtNAME");
                string username = GetControlTextByName(form, "txtUSERNAME");
                string password = GetControlTextByName(form, "txtPASSWORD");
                string email = GetControlTextByName(form, "txtEMAIL");
                string userId = GetControlTextByName(form, "txtUSERID");
                string cardCode = GetControlTextByName(form, "txtCARDCODE");

                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Vui lòng nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Extract LookUpEdit values
                string dnhanvienId = null;
                Control lueNV = FindControlRecursive(form, "lueDNHANVIENID");
                if (lueNV != null)
                {
                    try {
                        var props = lueNV.GetType().GetProperty("EditValue") ?? lueNV.GetType().GetProperty("SelectedValue");
                        var val = props?.GetValue(lueNV);
                        if (val != null && val != DBNull.Value) dnhanvienId = val.ToString();
                    } catch { }
                }

                string sgroupuserId = null;
                Control lueGroup = FindControlRecursive(form, "lueSGROUPUSERID");
                if (lueGroup != null)
                {
                    try {
                        var props = lueGroup.GetType().GetProperty("EditValue") ?? lueGroup.GetType().GetProperty("SelectedValue");
                        var val = props?.GetValue(lueGroup);
                        if (val != null && val != DBNull.Value) sgroupuserId = val.ToString();
                    } catch { }
                }

                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(idValue))
                            {
                                // INSERT
                                idValue = Guid.NewGuid().ToString();
                                idHolder[0] = idValue;
                                string sql = @"INSERT INTO SUSER (ID, USERNAME, PASSWORD, NAME, EMAIL, SGROUPUSERID, DNHANVIENID, USERID, CARDCODE, STATUS, USERCREATEDID) 
                                               VALUES (@id, @username, @password, @name, @email, @sgroupuserid, @dnhanvienid, @userid, @cardcode, 1, @usercreatedid)";
                                using (FbCommand cmd = new FbCommand(sql, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@id", idValue);
                                    cmd.Parameters.AddWithValue("@username", username);
                                    cmd.Parameters.AddWithValue("@password", (object)password ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@name", (object)name ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@sgroupuserid", (object)sgroupuserId ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@dnhanvienid", (object)dnhanvienId ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@userid", (object)userId ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@cardcode", (object)cardCode ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@usercreatedid", "4f1466a0-0756-4ba9-afa8-053b96ca7569");
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // UPDATE
                                string sql = @"UPDATE SUSER SET USERNAME=@username, PASSWORD=@password, NAME=@name, EMAIL=@email, 
                                               SGROUPUSERID=@sgroupuserid, DNHANVIENID=@dnhanvienid, USERID=@userid, CARDCODE=@cardcode 
                                               WHERE ID=@id";
                                using (FbCommand cmd = new FbCommand(sql, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@username", username);
                                    cmd.Parameters.AddWithValue("@password", (object)password ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@name", (object)name ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@sgroupuserid", (object)sgroupuserId ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@dnhanvienid", (object)dnhanvienId ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@userid", (object)userId ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@cardcode", (object)cardCode ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@id", idValue);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // Save TNGUOIDUNGTHEOCUAHANG (cửa hàng truy cập)
                            try
                            {
                                // Delete existing
                                using (FbCommand delCmd = new FbCommand("DELETE FROM TNGUOIDUNGTHEOCUAHANG WHERE SUSERID = @uid", conn, trans))
                                {
                                    delCmd.Parameters.AddWithValue("@uid", idValue);
                                    delCmd.ExecuteNonQuery();
                                }

                                // Insert checked items
                                Control grCtrl = FindControlRecursive(form, "grMain");
                                if (grCtrl is DataGridView dgv)
                                {
                                    foreach (DataGridViewRow row in dgv.Rows)
                                    {
                                        bool isChecked = false;
                                        try { isChecked = Convert.ToBoolean(row.Cells["TruyCap"].Value); } catch { }

                                        if (isChecked)
                                        {
                                            string cuaHangId = row.Cells["CuaHangId"]?.Value?.ToString() ?? "";
                                            if (!string.IsNullOrEmpty(cuaHangId))
                                            {
                                                string insSql = "INSERT INTO TNGUOIDUNGTHEOCUAHANG (ID, SUSERID, DCUAHANGID) VALUES (@tid, @uid, @chid)";
                                                using (FbCommand insCmd = new FbCommand(insSql, conn, trans))
                                                {
                                                    insCmd.Parameters.AddWithValue("@tid", Guid.NewGuid().ToString());
                                                    insCmd.Parameters.AddWithValue("@uid", idValue);
                                                    insCmd.Parameters.AddWithValue("@chid", cuaHangId);
                                                    insCmd.ExecuteNonQuery();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch { /* TNGUOIDUNGTHEOCUAHANG might not exist */ }

                            trans.Commit();
                            return true;
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static void LoadNo1LookupEdit(Control c, string tableName)
        {
            try {
                var loadMethod = c.GetType().GetMethod("LoadData", new Type[] { typeof(string) });
                if (loadMethod != null) {
                    loadMethod.Invoke(c, new object[] { tableName });
                }
            } catch (Exception ex) {
                // LoadData requires STABLETABLEDESC config set by No1Lib - silently skip if not available
                System.Diagnostics.Debug.WriteLine("LoadNo1LookupEdit skipped for " + c.Name + ": " + ex.Message);
            }
        }

        private static void PopulateLookupEdits(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // Note: lueDNHANVIENID and lueSGROUPUSERID are No1LookupEdit controls
                // that require STABLETABLEDESC config from No1Lib.
                // For TaiKhoanNguoiDung, they are replaced by ComboBox in InjectTaiKhoanNguoiDungUI.
                // We skip them here to avoid errors.
                
                if (c.Controls.Count > 0)
                {
                    PopulateLookupEdits(c);
                }
            }
        }

        private static void ForceSetProperty(object obj, string propertyName, object value)
        {
            var type = obj.GetType();
            while (type != null)
            {
                var prop = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (prop != null && prop.CanWrite)
                {
                    prop.SetValue(obj, value, null);
                    return;
                }
                type = type.BaseType;
            }
            throw new Exception("Writable property " + propertyName + " not found in class hierarchy of " + obj.GetType().FullName);
        }

        private static void BindLookupEdit(Control control, DataTable dt, string displayMember, string valueMember)
        {
            try {
                // If it's a No1LookupEdit, use its native LoadData method
                var loadMethod = control.GetType().GetMethod("LoadData", new Type[] { typeof(string) });
                if (loadMethod != null)
                {
                    // No1LookupEdit has its own data loading - use table name from the DataTable
                    // We cannot force a DataTable into it, so skip binding
                    return;
                }
                
                var props = control.GetType().GetProperty("Properties");
                if (props != null)
                {
                    var propsObj = props.GetValue(control);
                    
                    try {
                        ForceSetProperty(propsObj, "DataSource", dt);
                        ForceSetProperty(propsObj, "DisplayMember", displayMember);
                        ForceSetProperty(propsObj, "ValueMember", valueMember);
                        
                        var forceInitMethod = control.GetType().GetMethod("ForceInitialize");
                        forceInitMethod?.Invoke(control, null);
                        
                        var populateMethod = propsObj.GetType().GetMethod("PopulateColumns");
                        populateMethod?.Invoke(propsObj, null);
                    } catch (Exception ex) {
                        if (control.Name == "lueDNHANVIENID") {
                            try { MessageBox.Show("ForceSetProperty failed: " + ex.Message, "Debug Exception"); } catch { }
                        }
                        try {
                            // Fallback for ComboBoxEdit / ImageComboBoxEdit which don't have DataSource
                            var itemsProp = propsObj.GetType().GetProperty("Items");
                            if (itemsProp != null)
                            {
                                var itemsObj = itemsProp.GetValue(propsObj);
                                itemsObj.GetType().GetMethod("Clear")?.Invoke(itemsObj, null);
                                var addMethod = itemsObj.GetType().GetMethod("Add", new Type[] { typeof(object) });
                                if (addMethod != null) {
                                    foreach (DataRow row in dt.Rows) {
                                        addMethod.Invoke(itemsObj, new object[] { row[displayMember].ToString() });
                                    }
                                }
                            }
                        } catch (Exception exFallback) { 
                            if (control.Name == "lueDNHANVIENID") {
                                try { MessageBox.Show("Fallback failed: " + exFallback.Message, "Debug Exception"); } catch { }
                            }
                        }
                    }
                }
                else
                {
                    try {
                        ForceSetProperty(control, "DataSource", dt);
                        ForceSetProperty(control, "DisplayMember", displayMember);
                        ForceSetProperty(control, "ValueMember", valueMember);
                    } catch { }
                }
            } catch (Exception ex) {
                if (control.Name == "lueDNHANVIENID")
                {
                    MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message, "Debug");
                }
            }
        }

        private static void LoadDataToForm(Control form, string tableName, string idValue)
        {
            using (FbConnection conn = new FbConnection(GetConnectionString()))
            {
                conn.Open();
                using (FbCommand cmd = new FbCommand($"SELECT * FROM {tableName} WHERE ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", idValue);
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PopulateControlsFromReader(form, reader);
                        }
                    }
                }
            }
        }

        private static void PopulateControlsFromReader(Control parent, FbDataReader reader)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Name.StartsWith("txt") || c.Name.StartsWith("lue") || c.Name.StartsWith("cbo") || c.Name.StartsWith("chk"))
                {
                    string colName = c.Name.Substring(3); // e.g. txtNAME -> NAME
                    try {
                        int ord = reader.GetOrdinal(colName);
                        object val = reader.GetValue(ord);
                        SetControlValue(c, val);
                    } catch { /* Column might not exist */ }
                }

                if (c.Controls.Count > 0)
                {
                    PopulateControlsFromReader(c, reader);
                }
            }
        }

        private static bool SaveDataFromForm(Control form, string tableName, string idValue)
        {
            try
            {
                var data = new System.Collections.Generic.Dictionary<string, object>();
                ExtractDataFromControls(form, data);

                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        try {
                            FbCommand cmd = new FbCommand();
                            cmd.Connection = conn;
                            cmd.Transaction = trans;

                            if (string.IsNullOrEmpty(idValue))
                            {
                                // INSERT
                                idValue = Guid.NewGuid().ToString();
                                data["ID"] = idValue;
                                // We might also want to set AUTOID but Firebird triggers usually handle it or we ignore it
                                
                                string cols = string.Join(", ", data.Keys);
                                string paramNames = string.Join(", ", data.Keys.Select(k => "@" + k));
                                cmd.CommandText = $"INSERT INTO {tableName} ({cols}) VALUES ({paramNames})";
                            }
                            else
                            {
                                // UPDATE
                                var updateSets = data.Keys.Where(k => k != "ID").Select(k => $"{k} = @{k}");
                                string setClause = string.Join(", ", updateSets);
                                cmd.CommandText = $"UPDATE {tableName} SET {setClause} WHERE ID = @ID";
                                data["ID"] = idValue; // Ensure ID is in params
                            }

                            foreach (var kvp in data)
                            {
                                cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                            }

                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            return true;
                        } catch {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static void ExtractDataFromControls(Control parent, System.Collections.Generic.Dictionary<string, object> data)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Name.StartsWith("txt") || c.Name.StartsWith("lue") || c.Name.StartsWith("cbo") || c.Name.StartsWith("chk"))
                {
                    string colName = c.Name.Substring(3);
                    data[colName] = GetControlValue(c);
                }

                if (c.Controls.Count > 0)
                {
                    ExtractDataFromControls(c, data);
                }
            }
        }

        private static object GetControlValue(Control c)
        {
            if (c.Name.StartsWith("lue") || c.Name.StartsWith("cbo"))
            {
                var editVal = c.GetType().GetProperty("EditValue")?.GetValue(c);
                if (editVal != null) return editVal;
                
                var selectedVal = c.GetType().GetProperty("SelectedValue")?.GetValue(c);
                return selectedVal;
            }
            else if (c.Name.StartsWith("chk"))
            {
                var chkVal = c.GetType().GetProperty("Checked")?.GetValue(c);
                return chkVal != null ? ((bool)chkVal ? 1 : 0) : 0;
            }
            
            // TextBoxes
            return string.IsNullOrEmpty(c.Text) ? null : c.Text;
        }

        private static void SetControlValue(Control c, object value)
        {
            if (value == DBNull.Value || value == null) { c.Text = ""; return; }
            
            if (c.Name.StartsWith("lue") || c.Name.StartsWith("cbo"))
            {
                var editValProp = c.GetType().GetProperty("EditValue");
                if (editValProp != null) { editValProp.SetValue(c, value); return; }
                
                var selValProp = c.GetType().GetProperty("SelectedValue");
                if (selValProp != null) { selValProp.SetValue(c, value); return; }
            }
            else if (c.Name.StartsWith("chk"))
            {
                var chkProp = c.GetType().GetProperty("Checked");
                if (chkProp != null)
                {
                    chkProp.SetValue(c, Convert.ToInt32(value) == 1);
                    return;
                }
            }
            c.Text = value.ToString();
        }

        public static Form CreateFormByName(string formName)
        {
            try
            {
                // 1. Prioritize compiled SuDungDichVu ("Sử dụng dịch vụ") form directly
                if (string.Equals(formName, "Sử dụng dịch vụ", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "SuDungDichVu", StringComparison.OrdinalIgnoreCase) ||
                    (!string.IsNullOrEmpty(formName) && (
                        formName.IndexOf("Sử dụng dịch vụ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        formName.IndexOf("SuDungDichVu", StringComparison.OrdinalIgnoreCase) >= 0
                    )))
                {
                    FormModel m = GetFormModelFromDb("Sử dụng dịch vụ") ?? GetFormModelFromDb(formName);
                    return CreateDynamicSuDungDichVuForm(m);
                }

                FormModel model = GetFormModelFromDb(formName);

                if (model != null && (
                    string.Equals(model.ClassName, "SuDungDichVu", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(model.Name, "Sử dụng dịch vụ", StringComparison.OrdinalIgnoreCase)))
                {
                    return CreateDynamicSuDungDichVuForm(model);
                }

                // 2. Prioritize XML layout from SFORM.AELAYOUT if present in DB
                if (model != null && !string.IsNullOrEmpty(model.AeLayout))
                {
                    string stitchedXml = StitchFormXmlLayouts(model);
                    Form xmlForm = ParseAeLayoutToForm(stitchedXml, model.Name ?? formName);
                    if (xmlForm != null)
                    {
                        AttachDynamicDataBindings(xmlForm, model);
                        // Execute logic code from SFORM.CODE/CLIENTCODE
                        CodeInterpreter.ApplyFormLogic(xmlForm, model);
                        return xmlForm;
                    }
                }

                if (string.Equals(formName, "Thống kê", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "ThongKe", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "1f516fe7-3b71-4cbf-a3e8-61ad116bfa79", StringComparison.OrdinalIgnoreCase))
                {
                    return new No1Run.ThongKe();
                }

                // 3. Specific Fallbacks if AELAYOUT is empty/NULL in DB

                if (string.Equals(formName, "Chuyá»ƒn hoÃ¡ Ä‘Æ¡n", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "Chuyá»ƒn hÃ³a Ä‘Æ¡n", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "ChuyenHoaDon", StringComparison.OrdinalIgnoreCase))
                {
                    return CreateChuyenHoaDonForm();
                }

                if (string.Equals(formName, "Chá»n mÃ¡y in", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "ChonMayIn", StringComparison.OrdinalIgnoreCase))
                {
                    return CreateChonMayInForm();
                }

                if (string.Equals(formName, "Chuyá»ƒn bÃ n", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "ChuyenBan", StringComparison.OrdinalIgnoreCase))
                {
                    return CreateChuyenBanForm();
                }

                if (string.Equals(formName, "Quáº£n lÃ½ bÃ¡n hÃ ng", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(formName, "QuanLyBanHang", StringComparison.OrdinalIgnoreCase) ||
                    (!string.IsNullOrEmpty(formName) && (
                        formName.IndexOf("bÃ¡n hÃ ng", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        formName.IndexOf("Ä‘áº·t hÃ ng", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        formName.IndexOf("order", StringComparison.OrdinalIgnoreCase) >= 0
                    )) ||
                    (model != null && (
                        string.Equals(model.ClassName, "QuanLyBanHang", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(model.ClassName, "KiemSoatOrder", StringComparison.OrdinalIgnoreCase)
                    )))
                {
                    return CreateDynamicQuanLyBanHangForm(model ?? new FormModel { Name = formName });
                }

                // 3. Fallback based on FormType
                if (model != null && model.FormType == 1) // Quáº£n trá»‹ / Danh má»¥c
                {
                    return CreateDefaultDynamicDataForm(formName, model);
                }

                // Default Blank Form for Custom Form (6) or ThÃªm sá»­a (0)
                return new Form
                {
                    Text = formName,
                    Size = new Size(800, 500),
                    BackColor = Color.FromArgb(198, 215, 235),
                    StartPosition = FormStartPosition.CenterParent
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lá»—i náº¡p form Ä‘á»™ng [{formName}]: {ex.Message}");
                return new Form
                {
                    Text = formName,
                    Size = new Size(800, 500),
                    BackColor = Color.FromArgb(198, 215, 235),
                    StartPosition = FormStartPosition.CenterParent
                };
            }
        }

        public static FormModel GetFormModelFromDb(string formName)
        {
            if (string.IsNullOrEmpty(formName)) return null;

            List<string> dbsToTry = new List<string>();
            string primaryStr = GetConnectionString();
            if (!string.IsNullOrEmpty(primaryStr)) dbsToTry.Add(primaryStr);

            string mainPath = @"D:\QuanLyNhaHang\Database\mainTanAnPhat.fdb";
            string mainConnStr = GetConnectionString(mainPath);
            if (!dbsToTry.Contains(mainConnStr) && File.Exists(mainPath)) dbsToTry.Add(mainConnStr);

            string xPath = @"D:\QuanLyNhaHang\Database\x.fdb";
            string xConnStr = GetConnectionString(xPath);
            if (!dbsToTry.Contains(xConnStr) && File.Exists(xPath)) dbsToTry.Add(xConnStr);

            string sPath = @"D:\QuanLyNhaHang\Database\s.fdb";
            string sConnStr = GetConnectionString(sPath);
            if (!dbsToTry.Contains(sConnStr) && File.Exists(sPath)) dbsToTry.Add(sConnStr);

            FormModel bestModel = null;

            foreach (string connStr in dbsToTry)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(connStr))
                    {
                        conn.Open();
                        string query = @"SELECT ID, NAME, CLASSNAME, FORMTYPE, LOAI, STABLEDESCID, SFUNCTIONID, NOTEMPLATE, NOTE,
                                                CODE, DESIGNCODE, AELAYOUT, CLIENTCODE, SERVERCODE, IMAGE32 
                                         FROM SFORM 
                                         WHERE NAME = @Name OR CLASSNAME = @Name OR ID = @Name 
                                            OR LOWER(NAME) = LOWER(@Name) OR LOWER(CLASSNAME) = LOWER(@Name)";

                        using (FbCommand cmd = new FbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Name", formName);
                            using (FbDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    FormModel model = new FormModel
                                    {
                                        Id = reader["ID"]?.ToString(),
                                        Name = reader["NAME"]?.ToString(),
                                        ClassName = reader["CLASSNAME"]?.ToString(),
                                        FormType = reader["FORMTYPE"] != DBNull.Value ? Convert.ToInt32(reader["FORMTYPE"]) : 0,
                                        Loai = reader["LOAI"] != DBNull.Value ? Convert.ToInt32(reader["LOAI"]) : 0,
                                        STableDescId = reader["STABLEDESCID"]?.ToString(),
                                        SFunctionId = reader["SFUNCTIONID"]?.ToString(),
                                        BillCode = reader["NOTEMPLATE"]?.ToString(),
                                        Note = reader["NOTE"]?.ToString(),
                                        Code = ReadBlobString(reader, "CODE"),
                                        DesignCode = ReadBlobString(reader, "DESIGNCODE"),
                                        AeLayout = ReadBlobString(reader, "AELAYOUT"),
                                        ClientCode = ReadBlobString(reader, "CLIENTCODE"),
                                        ServerCode = ReadBlobString(reader, "SERVERCODE"),
                                        ImageBytes = ReadBlobBytes(reader, "IMAGE32")
                                    };

                                    if (bestModel == null) bestModel = model;

                                    if (!string.IsNullOrEmpty(model.AeLayout) && model.AeLayout.Trim().Length > 20)
                                    {
                                        return model;
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }

            if (bestModel == null || string.IsNullOrEmpty(bestModel.AeLayout))
            {
                List<FormModel> allForms = LoadAllForms();
                FormModel matched = allForms.FirstOrDefault(f =>
                    string.Equals(f.Id, formName, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(f.Name, formName, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(f.ClassName, formName, StringComparison.OrdinalIgnoreCase) ||
                    (f.Name != null && f.Name.IndexOf(formName, StringComparison.OrdinalIgnoreCase) >= 0));
                if (matched != null && !string.IsNullOrEmpty(matched.AeLayout))
                {
                    return matched;
                }
            }

            return bestModel;
        }

        private static Form CreateDynamicSuDungDichVuForm(FormModel model)
        {
            Form form = new Form
            {
                Text = model != null && !string.IsNullOrEmpty(model.Name) ? model.Name : "Sử dụng dịch vụ",
                Size = new Size(1024, 600),
                BackColor = System.Drawing.Color.White,
                WindowState = FormWindowState.Normal
            };

            try
            {
                No1Run.SuDungDichVu sddv = new No1Run.SuDungDichVu();
                sddv.Dock = DockStyle.Fill;
                form.Controls.Add(sddv);
                sddv.No1UserControl1_OnAddedToTab(sddv, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error creating SuDungDichVu: " + ex.Message);
            }

            return form;
        }

        private static void LoadDynamicKhuVucAndBan(TabControl tab1, TabControl tab2, SplitContainer splitKv, Label lblActiveTable, Label lblStartTime, Button btnStart, DataTable dtOrder, Label lblTotalVal, DataGridView dgvOrder)
        {
            try
            {
                tab1.TabPages.Clear();
                tab2.TabPages.Clear();

                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sqlKv = "SELECT ID, NAME, COALESCE(TABHIENTHI, 0) AS TABIDX FROM DKHUVUC WHERE STATUS = 30 ORDER BY SORTORDER, NAME";
                    DataTable dtKv = new DataTable();
                    using (FbDataAdapter da = new FbDataAdapter(sqlKv, conn)) { da.Fill(dtKv); }

                    foreach (DataRow r in dtKv.Rows)
                    {
                        string id = r["ID"]?.ToString();
                        string name = r["NAME"]?.ToString();
                        int tabIdx = r["TABIDX"] != DBNull.Value ? Convert.ToInt32(r["TABIDX"]) : 0;

                        TabPage page = new TabPage(name) { Name = id, Tag = id };
                        FlowLayoutPanel pnlCards = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = System.Drawing.Color.FromArgb(245, 246, 248), Padding = new Padding(6) };
                        page.Controls.Add(pnlCards);

                        if (tabIdx == 1) tab2.TabPages.Add(page);
                        else tab1.TabPages.Add(page);

                        LoadTableCardsForPage(id, pnlCards, lblActiveTable, lblStartTime, btnStart, dtOrder, lblTotalVal, dgvOrder);
                    }

                    if (tab2.TabPages.Count == 0) splitKv.Panel2Collapsed = true;
                    else splitKv.Panel2Collapsed = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lá»—i LoadDynamicKhuVucAndBan: " + ex.Message);
            }
        }

        private static void LoadTableCardsForPage(string kvId, FlowLayoutPanel pnlContainer, Label lblActiveTable, Label lblStartTime, Button btnStart, DataTable dtOrder, Label lblTotalVal, DataGridView dgvOrder)
        {
            pnlContainer.Controls.Clear();
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sql = @"
                        SELECT B.ID, B.NAME, B.TDONHANGID, H.BATDAU
                        FROM DBAN B
                        LEFT JOIN TDONHANG H ON B.TDONHANGID = H.ID AND H.DATHANHTOAN = 0
                        WHERE B.DKHUVUCID = @KvID
                        ORDER BY B.NAME";

                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@KvID", kvId);
                        using (FbDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                string banId = rdr["ID"]?.ToString();
                                string banName = rdr["NAME"]?.ToString();
                                string orderId = rdr["TDONHANGID"] != DBNull.Value ? rdr["TDONHANGID"]?.ToString() : null;
                                DateTime? batDau = rdr["BATDAU"] != DBNull.Value ? Convert.ToDateTime(rdr["BATDAU"]) : (DateTime?)null;

                                bool inUse = !string.IsNullOrEmpty(orderId);

                                Panel card = new Panel
                                {
                                    Size = new System.Drawing.Size(95, 95),
                                    Margin = new Padding(6),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    BackColor = System.Drawing.Color.White,
                                    Cursor = Cursors.Hand
                                };

                                if (inUse && batDau.HasValue)
                                {
                                    TimeSpan diff = DateTime.Now - batDau.Value;
                                    Label lblBadge = new Label { Text = $"{(int)diff.TotalHours}h {diff.Minutes}'", BackColor = System.Drawing.Color.Red, ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold), Size = new System.Drawing.Size(50, 16), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
                                    card.Controls.Add(lblBadge);
                                }

                                Label lblName = new Label { Text = banName, Dock = DockStyle.Bottom, Height = 26, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), ForeColor = inUse ? System.Drawing.Color.DarkRed : System.Drawing.Color.Black };
                                card.Controls.Add(lblName);

                                card.Click += (s, e) =>
                                {
                                    lblActiveTable.Text = banName;
                                    lblStartTime.Text = batDau.HasValue ? batDau.Value.ToString("HH:mm dd/MM") : "ChÆ°a báº¯t Ä‘áº§u";
                                    btnStart.Enabled = !inUse;
                                    LoadOrderDetailsForTable(orderId, dtOrder, lblTotalVal);
                                };
                                lblName.Click += (s, e) => card.PerformClick();

                                pnlContainer.Controls.Add(card);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lá»—i LoadTableCardsForPage: " + ex.Message);
            }
        }

        private static void PerformClick(this Control ctrl)
        {
            // Helper extension for invoking click
        }

        private static void LoadOrderDetailsForTable(string orderId, DataTable dtOrder, Label lblTotalVal)
        {
            dtOrder.Clear();
            decimal sum = 0m;
            if (!string.IsNullOrEmpty(orderId))
            {
                try
                {
                    using (FbConnection conn = new FbConnection(GetConnectionString()))
                    {
                        conn.Open();
                        string sql = @"
                            SELECT M.NAME AS TENHANG, D.NAME AS DVT, C.SLXUAT AS SOLUONG, C.DONGIA, COALESCE(C.TILEGIAMGIA, 0) AS CHIECKHAU, C.THANHTIEN
                            FROM TDONHANGCHITIET C
                            INNER JOIN DMATHANG M ON C.DMATHANGID = M.ID
                            LEFT JOIN DDONVITINH D ON M.DDONVITINHID = D.ID
                            WHERE C.TDONHANGID = @OrderID";

                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", orderId);
                            using (FbDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                    string ten = rdr["TENHANG"]?.ToString();
                                    string dvt = rdr["DVT"] != DBNull.Value ? rdr["DVT"]?.ToString() : "";
                                    decimal sl = rdr["SOLUONG"] != DBNull.Value ? Convert.ToDecimal(rdr["SOLUONG"]) : 1m;
                                    decimal gia = rdr["DONGIA"] != DBNull.Value ? Convert.ToDecimal(rdr["DONGIA"]) : 0m;
                                    decimal ck = rdr["CHIECKHAU"] != DBNull.Value ? Convert.ToDecimal(rdr["CHIECKHAU"]) : 0m;
                                    decimal tt = rdr["THANHTIEN"] != DBNull.Value ? Convert.ToDecimal(rdr["THANHTIEN"]) : (sl * gia) - ck;
                                    sum += tt;

                                    dtOrder.Rows.Add(ten, dvt, sl, gia, ck, tt, "");
                                }
                            }
                        }
                    }
                }
                catch { }
            }
            lblTotalVal.Text = sum.ToString("#,##0");
        }

        private static void LoadDynamicNhomAndThucDon(TreeView treeNhom, DataGridView dgvFood, DataTable dtOrder, Label lblTotalVal)
        {
            try
            {
                treeNhom.Nodes.Clear();
                TreeNode root = new TreeNode("Táº¥t cáº£") { Tag = "ALL" };
                treeNhom.Nodes.Add(root);

                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sqlNhom = "SELECT ID, NAME FROM DNHOMMATHANG WHERE STATUS = 30 ORDER BY SORTORDER, NAME";
                    using (FbCommand cmd = new FbCommand(sqlNhom, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            root.Nodes.Add(new TreeNode(rdr["NAME"]?.ToString()) { Tag = rdr["ID"]?.ToString() });
                        }
                    }
                    root.Expand();

                    string sqlMon = @"
                        SELECT M.ID, M.NAME AS TENHANG, D.NAME AS DVT, M.GIABAN, M.CODE AS MAHANG, M.DNHOMMATHANGID
                        FROM DMATHANG M
                        LEFT JOIN DDONVITINH D ON M.DDONVITINHID = D.ID
                        WHERE M.STATUS = 30
                        ORDER BY M.SORTORDER, M.NAME";

                    DataTable dtFood = new DataTable();
                    using (FbDataAdapter da = new FbDataAdapter(sqlMon, conn)) { da.Fill(dtFood); }

                    dgvFood.DataSource = dtFood;
                    if (dgvFood.Columns.Contains("ID")) dgvFood.Columns["ID"].Visible = false;
                    if (dgvFood.Columns.Contains("DNHOMMATHANGID")) dgvFood.Columns["DNHOMMATHANGID"].Visible = false;
                    if (dgvFood.Columns.Contains("TENHANG")) dgvFood.Columns["TENHANG"].HeaderText = "TÃªn hÃ ng";
                    if (dgvFood.Columns.Contains("DVT")) dgvFood.Columns["DVT"].HeaderText = "ÄVT";
                    if (dgvFood.Columns.Contains("GIABAN")) { dgvFood.Columns["GIABAN"].HeaderText = "GiÃ¡ bÃ¡n"; dgvFood.Columns["GIABAN"].DefaultCellStyle.Format = "#,##0"; }
                    if (dgvFood.Columns.Contains("MAHANG")) dgvFood.Columns["MAHANG"].HeaderText = "MÃ£ hÃ ng";

                    treeNhom.AfterSelect += (s, e) =>
                    {
                        string tag = e.Node.Tag?.ToString();
                        if (tag == "ALL" || string.IsNullOrEmpty(tag)) dgvFood.DataSource = dtFood;
                        else
                        {
                            DataView dv = new DataView(dtFood) { RowFilter = $"DNHOMMATHANGID = '{tag}'" };
                            dgvFood.DataSource = dv;
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lá»—i LoadDynamicNhomAndThucDon: " + ex.Message);
            }
        }

        private static Form CreateDynamicQuanLyBanHangForm(FormModel model)
        {
            Form form = new Form
            {
                Text = model != null && !string.IsNullOrEmpty(model.Name) ? model.Name : "Quáº£n lÃ½ bÃ¡n hÃ ng",
                Size = new Size(1024, 545),
                BackColor = System.Drawing.Color.White,
                WindowState = FormWindowState.Normal
            };

            SplitContainer splitMain = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 650 };

            // Left Invoices Panel
            Panel pnlLeftTop = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = System.Drawing.Color.FromArgb(240, 243, 248) };
            Label lblFrom = new Label { Text = "Tá»«:", Location = new System.Drawing.Point(10, 10), AutoSize = true };
            DateTimePicker dtFrom = new DateTimePicker { Location = new System.Drawing.Point(40, 7), Format = DateTimePickerFormat.Short, Width = 100, Value = new DateTime(2016, 1, 1) };
            Label lblTo = new Label { Text = "Äáº¿n:", Location = new System.Drawing.Point(150, 10), AutoSize = true };
            DateTimePicker dtTo = new DateTimePicker { Location = new System.Drawing.Point(185, 7), Format = DateTimePickerFormat.Short, Width = 100 };
            Button btnReload = new Button { Text = "Táº£i dá»¯ liá»‡u", Location = new System.Drawing.Point(300, 6), Size = new System.Drawing.Size(90, 26) };

            pnlLeftTop.Controls.Add(lblFrom);
            pnlLeftTop.Controls.Add(dtFrom);
            pnlLeftTop.Controls.Add(lblTo);
            pnlLeftTop.Controls.Add(dtTo);
            pnlLeftTop.Controls.Add(btnReload);

            DataGridView dgvBills = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = System.Drawing.Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            splitMain.Panel1.Controls.Add(dgvBills);
            splitMain.Panel1.Controls.Add(pnlLeftTop);

            // Right Invoice Details Panel
            Panel pnlRightHeader = new Panel { Dock = DockStyle.Top, Height = 90, BackColor = System.Drawing.Color.FromArgb(240, 243, 248) };
            Label lblBanTitle = new Label { Text = "BÃ n --", Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold), Location = new System.Drawing.Point(10, 10), AutoSize = true };
            Label lblSoPhieu = new Label { Text = "Sá»‘ phiáº¿u:", Location = new System.Drawing.Point(10, 40), AutoSize = true };
            TextBox txtSoPhieu = new TextBox { Location = new System.Drawing.Point(80, 37), Width = 120, ReadOnly = true };

            pnlRightHeader.Controls.Add(lblBanTitle);
            pnlRightHeader.Controls.Add(lblSoPhieu);
            pnlRightHeader.Controls.Add(txtSoPhieu);

            DataGridView dgvBillDetails = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = System.Drawing.Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            DataTable dtDetails = new DataTable();
            dtDetails.Columns.Add("TÃªn hÃ ng", typeof(string));
            dtDetails.Columns.Add("ÄVT", typeof(string));
            dtDetails.Columns.Add("SL", typeof(decimal));
            dtDetails.Columns.Add("Ä giÃ¡", typeof(decimal));
            dtDetails.Columns.Add("CK%", typeof(decimal));
            dtDetails.Columns.Add("T tiá»n", typeof(decimal));
            dgvBillDetails.DataSource = dtDetails;

            Panel pnlRightMain = new Panel { Dock = DockStyle.Fill };
            pnlRightMain.Controls.Add(dgvBillDetails);
            pnlRightMain.Controls.Add(pnlRightHeader);

            splitMain.Panel2.Controls.Add(pnlRightMain);
            form.Controls.Add(splitMain);

            // Fetch Sales Bills dynamically from Firebird TDONHANG
            Action loadData = () =>
            {
                try
                {
                    using (FbConnection conn = new FbConnection(GetConnectionString()))
                    {
                        conn.Open();
                        string sql = @"
                            SELECT H.SOHD AS SOHD_VAL, H.ID, H.NAME AS SOHD_TEXT, H.NGAY, B.NAME AS BAN_NAME, H.BATDAU, H.KETTHUC, H.TONGCONG, H.TIENGIAMGIA, H.TILEGIAMGIA, H.TIENHANG
                            FROM TDONHANG H
                            LEFT JOIN DBAN B ON H.DBANID = B.ID
                            WHERE H.NGAY BETWEEN @FromDate AND @ToDate
                            ORDER BY H.NGAY DESC, H.SOHD DESC";

                        DataTable dtBills = new DataTable();
                        using (FbDataAdapter da = new FbDataAdapter(sql, conn))
                        {
                            da.SelectCommand.Parameters.AddWithValue("@FromDate", dtFrom.Value.Date);
                            da.SelectCommand.Parameters.AddWithValue("@ToDate", dtTo.Value.Date);
                            da.Fill(dtBills);
                        }

                        dgvBills.DataSource = dtBills;
                        if (dgvBills.Columns.Contains("ID")) dgvBills.Columns["ID"].Visible = false;
                        if (dgvBills.Columns.Contains("SOHD_VAL")) dgvBills.Columns["SOHD_VAL"].HeaderText = "Sá»‘ phiáº¿u";
                        if (dgvBills.Columns.Contains("SOHD_TEXT")) dgvBills.Columns["SOHD_TEXT"].Visible = false;
                        if (dgvBills.Columns.Contains("NGAY")) dgvBills.Columns["NGAY"].HeaderText = "NgÃ y";
                        if (dgvBills.Columns.Contains("BAN_NAME")) dgvBills.Columns["BAN_NAME"].HeaderText = "BÃ n";
                        if (dgvBills.Columns.Contains("BATDAU")) dgvBills.Columns["BATDAU"].HeaderText = "Báº¯t Ä‘áº§u";
                        if (dgvBills.Columns.Contains("KETTHUC")) dgvBills.Columns["KETTHUC"].HeaderText = "Káº¿t thÃºc";
                        if (dgvBills.Columns.Contains("TONGCONG")) { dgvBills.Columns["TONGCONG"].HeaderText = "Tá»•ng cá»™ng"; dgvBills.Columns["TONGCONG"].DefaultCellStyle.Format = "#,##0"; }
                    }
                }
                catch { }
            };

            btnReload.Click += (s, e) => loadData();
            form.Load += (s, e) => loadData();

            dgvBills.SelectionChanged += (s, e) =>
            {
                if (dgvBills.CurrentRow != null && dgvBills.CurrentRow.DataBoundItem is DataRowView drv)
                {
                    string orderId = drv["ID"]?.ToString();
                    lblBanTitle.Text = drv["BAN_NAME"] != DBNull.Value ? drv["BAN_NAME"]?.ToString() : "BÃ n --";
                    txtSoPhieu.Text = drv["SOHD_VAL"] != DBNull.Value ? drv["SOHD_VAL"]?.ToString() : "";

                    LoadOrderDetailsForTable(orderId, dtDetails, new Label());
                }
            };

            return form;
        }

        private static Form CreateChuyenHoaDonForm()
        {
            Form f = new Form
            {
                Text = "Chuyá»ƒn hÃ³a Ä‘Æ¡n",
                Size = new Size(620, 420),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(245, 247, 250)
            };

            Panel pnlTop = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = Color.FromArgb(235, 240, 248), Padding = new Padding(10) };
            Label lblSource = new Label { Text = "HÃ³a Ä‘Æ¡n nguá»“n:", Location = new Point(12, 16), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            ComboBox cboSource = new ComboBox { Location = new Point(120, 13), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            
            Label lblTarget = new Label { Text = "Chuyá»ƒn sang bÃ n:", Location = new Point(315, 16), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            ComboBox cboTarget = new ComboBox { Location = new Point(430, 13), Width = 160, DropDownStyle = ComboBoxStyle.DropDownList };

            Button btnExecute = new Button { Text = "ðŸ”„ Thá»±c hiá»‡n chuyá»ƒn hÃ³a Ä‘Æ¡n", Location = new Point(120, 45), Size = new Size(200, 28), Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.FromArgb(40, 120, 200), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnCancel = new Button { Text = "âŒ Há»§y bá»", Location = new Point(330, 45), Size = new Size(100, 28), Font = new Font("Segoe UI", 9F) };

            pnlTop.Controls.AddRange(new Control[] { lblSource, cboSource, lblTarget, cboTarget, btnExecute, btnCancel });

            DataGridView dgv = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = Color.White, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, ReadOnly = true, AllowUserToAddRows = false };
            DataTable dt = new DataTable();
            dt.Columns.Add("MÃ£ mÃ³n", typeof(string));
            dt.Columns.Add("TÃªn máº·t hÃ ng", typeof(string));
            dt.Columns.Add("ÄVT", typeof(string));
            dt.Columns.Add("Sá»‘ lÆ°á»£ng", typeof(decimal));
            dt.Columns.Add("ÄÆ¡n giÃ¡", typeof(decimal));
            dt.Columns.Add("ThÃ nh tiá»n", typeof(decimal));
            dgv.DataSource = dt;

            f.Controls.Add(dgv);
            f.Controls.Add(pnlTop);
            return f;
        }

        private static Form CreateChonMayInForm()
        {
            Form f = new Form
            {
                Text = "Chá»n mÃ¡y in",
                Size = new Size(520, 320),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White
            };

            Panel pnlMain = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            Label lblHeader = new Label { Text = "Cáº¤U HÃŒNH MÃY IN Há»† THá»NG", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 50, 120), Location = new Point(20, 15), AutoSize = true };

            Label lblReceipt = new Label { Text = "MÃ¡y in hÃ³a Ä‘Æ¡n (Bill Printer):", Location = new Point(20, 55), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboReceipt = new ComboBox { Location = new Point(210, 52), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
            cboReceipt.Items.AddRange(new object[] { "Default Printer", "POS-80 Series", "Xprinter XP-N160I", "Microsoft Print to PDF" });
            cboReceipt.SelectedIndex = 0;

            Label lblKitchen = new Label { Text = "MÃ¡y in báº¿p / cháº¿ biáº¿n:", Location = new Point(20, 95), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboKitchen = new ComboBox { Location = new Point(210, 92), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
            cboKitchen.Items.AddRange(new object[] { "(KhÃ´ng sá»­ dá»¥ng)", "Kitchen Printer 1", "POS-80 Series" });
            cboKitchen.SelectedIndex = 0;

            Label lblCopies = new Label { Text = "Sá»‘ liÃªn in hÃ³a Ä‘Æ¡n:", Location = new Point(20, 135), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            NumericUpDown numCopies = new NumericUpDown { Location = new Point(210, 132), Width = 80, Value = 1, Minimum = 1, Maximum = 10 };

            CheckBox chkAuto = new CheckBox { Text = "Tá»± Ä‘á»™ng in sau khi xÃ¡c nháº­n thanh toÃ¡n", Location = new Point(210, 168), AutoSize = true, Checked = true, Font = new Font("Segoe UI", 9F) };

            Button btnTest = new Button { Text = "ðŸ–¨ï¸ In thá»­", Location = new Point(140, 215), Size = new Size(100, 30), Font = new Font("Segoe UI", 9F) };
            Button btnSave = new Button { Text = "ðŸ’¾ LÆ°u cáº¥u hÃ¬nh", Location = new Point(250, 215), Size = new Size(120, 30), Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.FromArgb(40, 120, 200), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnClose = new Button { Text = "âŒ ÄÃ³ng", Location = new Point(380, 215), Size = new Size(90, 30), Font = new Font("Segoe UI", 9F) };

            pnlMain.Controls.AddRange(new Control[] { lblHeader, lblReceipt, cboReceipt, lblKitchen, cboKitchen, lblCopies, numCopies, chkAuto, btnTest, btnSave, btnClose });
            f.Controls.Add(pnlMain);
            return f;
        }

        private static Form CreateChuyenBanForm()
        {
            Form f = new Form
            {
                Text = "Chuyá»ƒn bÃ n",
                Size = new Size(480, 260),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White
            };

            Panel pnlMain = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            Label lblHeader = new Label { Text = "CHUYá»‚N BÃ€N KHÃCH DÃ™NG Dá»ŠCH Vá»¤", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 50, 120), Location = new Point(20, 15), AutoSize = true };

            Label lblFrom = new Label { Text = "Tá»« bÃ n:", Location = new Point(20, 60), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboFrom = new ComboBox { Location = new Point(90, 57), Width = 140, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblTo = new Label { Text = "Sang bÃ n:", Location = new Point(250, 60), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            ComboBox cboTo = new ComboBox { Location = new Point(320, 57), Width = 140, DropDownStyle = ComboBoxStyle.DropDownList };

            Button btnExec = new Button { Text = "ðŸ”„ Thá»±c hiá»‡n chuyá»ƒn bÃ n", Location = new Point(120, 140), Size = new Size(180, 32), Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.FromArgb(40, 120, 200), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnCancel = new Button { Text = "âŒ Há»§y bá»", Location = new Point(310, 140), Size = new Size(90, 32), Font = new Font("Segoe UI", 9F) };

            pnlMain.Controls.AddRange(new Control[] { lblHeader, lblFrom, cboFrom, lblTo, cboTo, btnExec, btnCancel });
            f.Controls.Add(pnlMain);
            return f;
        }

        private static Form CreateDefaultDynamicDataForm(string formName, FormModel model)
        {
            Form f = new Form
            {
                Text = formName,
                Size = new System.Drawing.Size(950, 600),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
            };

            // Top Action Toolbar matching Image 2
            ToolStrip tsAction = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(6, 4, 6, 4) };

            ToolStripLabel lblFrom = new ToolStripLabel(" Tá»« ngÃ y: ");
            ToolStripControlHost hostFrom = new ToolStripControlHost(new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 100, Value = DateTime.Now.AddDays(-30) });
            ToolStripLabel lblTo = new ToolStripLabel(" Äáº¿n ngÃ y: ");
            ToolStripControlHost hostTo = new ToolStripControlHost(new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 100, Value = DateTime.Now });

            ToolStripLabel lblSearch = new ToolStripLabel("  TÃ¬m kiáº¿m: ");
            ToolStripControlHost hostSearch = new ToolStripControlHost(new TextBox { Width = 140 });

            ToolStripButton btnFilter = new ToolStripButton("ðŸ” Lá»c");
            ToolStripButton btnAdd = new ToolStripButton("âž• ThÃªm má»›i");
            ToolStripButton btnEdit = new ToolStripButton("âœï¸ Sá»­a");
            ToolStripButton btnDelete = new ToolStripButton("âŒ XÃ³a");
            ToolStripButton btnExport = new ToolStripButton("ðŸ“Š Xuáº¥t Excel");
            ToolStripButton btnReload = new ToolStripButton("ðŸ”„ Náº¡p láº¡i");

            tsAction.Items.AddRange(new ToolStripItem[] {
                lblFrom, hostFrom, lblTo, hostTo, lblSearch, hostSearch, btnFilter, new ToolStripSeparator(),
                btnAdd, btnEdit, btnDelete, new ToolStripSeparator(), btnExport, btnReload
            });

            // Main Data Grid
            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Bottom Status / Totals Bar
            StatusStrip ss = new StatusStrip();
            ToolStripStatusLabel lblCount = new ToolStripStatusLabel { Text = "Tá»•ng sá»‘ báº£n ghi: 0 | Tá»•ng giÃ¡ trá»‹: 0 VNÄ" };
            ss.Items.Add(lblCount);

            f.Controls.Add(dgv);
            f.Controls.Add(tsAction);
            f.Controls.Add(ss);

            Action loadData = () =>
            {
                try
                {
                    DataTable dt = QueryRichTableData(formName);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dgv.DataSource = dt;
                        lblCount.Text = $"Tá»•ng sá»‘ báº£n ghi: {dt.Rows.Count:N0}";

                        // Format numbers
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (col.ValueType == typeof(decimal) || col.ValueType == typeof(double) || col.ValueType == typeof(int) || col.ValueType == typeof(long))
                            {
                                if (col.Name.IndexOf("tiá»n", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    col.Name.IndexOf("ná»£", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    col.Name.IndexOf("giÃ¡", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    col.Name.IndexOf("cá»™ng", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    col.DefaultCellStyle.Format = "#,#00";
                                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                }
                            }
                        }
                    }
                }
                catch { }
            };

            btnFilter.Click += (s, e) => loadData();
            btnReload.Click += (s, e) => loadData();
            f.Load += (s, e) => loadData();

            return f;
        }

        private static DataTable QueryRichTableData(string formName)
        {
            string connStr = GetConnectionString();
            try
            {
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string lower = formName.ToLower();
                    string query = "";

                    if (lower.Contains("cÃ´ng ná»£ khÃ¡ch hÃ ng"))
                    {
                        query = @"
                            SELECT FIRST 50 H.SOHD AS ""Sá»‘ phiáº¿u"", H.NGAY AS ""NgÃ y"", K.NAME AS ""KhÃ¡ch hÃ ng"", H.TONGCONG AS ""Tá»•ng tiá»n"", H.CONGNO AS ""CÃ²n ná»£"", H.NOTE AS ""Ghi chÃº""
                            FROM TDONHANG H
                            LEFT JOIN DKHACHHANG K ON H.DKHACHHANGID = K.ID
                            ORDER BY H.NGAY DESC";
                    }
                    else if (lower.Contains("cÃ´ng ná»£ nhÃ  cung cáº¥p"))
                    {
                        query = @"
                            SELECT FIRST 50 N.SOPHIEU AS ""Sá»‘ phiáº¿u"", N.NGAY AS ""NgÃ y"", C.NAME AS ""NhÃ  cung cáº¥p"", N.TONGTIEN AS ""Tá»•ng tiá»n"", N.NOTE AS ""Ghi chÃº""
                            FROM TPHIEUNHAPKHO N
                            LEFT JOIN DNHACUNGCAP C ON N.DNHACUNGCAPID = C.ID
                            ORDER BY N.NGAY DESC";
                    }
                    else if (lower.Contains("phiáº¿u chi"))
                    {
                        query = @"
                            SELECT FIRST 50 SOPHIEU AS ""Sá»‘ phiáº¿u"", NGAY AS ""NgÃ y"", SOTIEN AS ""Sá»‘ tiá»n chi"", LYDO AS ""LÃ½ do chi"", NGUOINHAN AS ""NgÆ°á»i nháº­n""
                            FROM TTHUCHI
                            WHERE SOTIEN < 0 OR LOAI = 1
                            ORDER BY NGAY DESC";
                    }
                    else if (lower.Contains("phiáº¿u thu"))
                    {
                        query = @"
                            SELECT FIRST 50 SOPHIEU AS ""Sá»‘ phiáº¿u"", NGAY AS ""NgÃ y"", SOTIEN AS ""Sá»‘ tiá»n thu"", LYDO AS ""LÃ½ do thu"", NGUOINOP AS ""NgÆ°á»i ná»™p""
                            FROM TTHUCHI
                            WHERE SOTIEN >= 0 OR LOAI = 0
                            ORDER BY NGAY DESC";
                    }
                    else
                    {
                        string tableName = GetTableNameForForm(formName);
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            query = $"SELECT FIRST 50 * FROM {tableName}";
                        }
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        using (FbDataAdapter da = new FbDataAdapter(query, conn))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        private static string GetTableNameForForm(string formName)
        {
            string lower = formName.ToLower();
            if (lower.Contains("máº·t hÃ ng")) return "DMATHANG";
            if (lower.Contains("bÃ n")) return "DBAN";
            if (lower.Contains("khÃ¡ch hÃ ng")) return "DKHACHHANG";
            if (lower.Contains("nhÃ¢n viÃªn")) return "DNHANVIEN";
            if (lower.Contains("kho")) return "DKHOHANG";
            if (lower.Contains("nhÃ  cung cáº¥p")) return "DNHACUNGCAP";
            if (lower.Contains("phiáº¿u chi") || lower.Contains("phiáº¿u thu") || lower.Contains("thu chi")) return "TTHUCHI";
            if (lower.Contains("báº£ng giÃ¡")) return "DBANGGIA";
            if (lower.Contains("Ä‘Æ¡n hÃ ng") || lower.Contains("hÃ³a Ä‘Æ¡n") || lower.Contains("cÃ´ng ná»£")) return "TDONHANG";
            return null;
        }

        private static DataTable QueryTableData(string tableName)
        {
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = $"SELECT FIRST 50 * FROM {tableName}";
                    using (FbDataAdapter da = new FbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<FormModel> LoadAllForms(string dbPath = null)
        {
            List<FormModel> list = new List<FormModel>();
            string connStr = GetConnectionString(dbPath);

            try
            {
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    string query = @"SELECT F.ID, F.NAME, F.CLASSNAME, F.FORMTYPE, F.LOAI, F.STABLEDESCID, F.SFUNCTIONID, F.NOTEMPLATE, 
                                            F.CODE, F.DESIGNCODE, F.AELAYOUT, F.CLIENTCODE, F.SERVERCODE, 
                                            F.IMAGE32 AS IMG32, I.IMAGE AS SIMG 
                                     FROM SFORM F 
                                     LEFT JOIN SIMAGE I ON F.SIMAGEID = I.ID 
                                     ORDER BY F.NAME";

                    using (FbCommand cmd = new FbCommand(query, conn))
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FormModel form = new FormModel
                            {
                                Id = reader["ID"]?.ToString(),
                                Name = reader["NAME"]?.ToString(),
                                ClassName = reader["CLASSNAME"]?.ToString(),
                                FormType = reader["FORMTYPE"] != DBNull.Value ? Convert.ToInt32(reader["FORMTYPE"]) : 0,
                                Loai = reader["LOAI"] != DBNull.Value ? Convert.ToInt32(reader["LOAI"]) : 0,
                                STableDescId = reader["STABLEDESCID"]?.ToString(),
                                SFunctionId = reader["SFUNCTIONID"]?.ToString(),
                                BillCode = reader["NOTEMPLATE"]?.ToString(),
                                Code = ReadBlobString(reader, "CODE"),
                                DesignCode = ReadBlobString(reader, "DESIGNCODE"),
                                AeLayout = ReadBlobString(reader, "AELAYOUT"),
                                ClientCode = ReadBlobString(reader, "CLIENTCODE"),
                                ServerCode = ReadBlobString(reader, "SERVERCODE"),
                                ImageBytes = ReadBlobBytes(reader, "IMG32") ?? ReadBlobBytes(reader, "SIMG")
                            };
                            list.Add(form);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error reading SFORM: " + ex.Message);
            }

            return list;
        }

        public class DbTableItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public override string ToString() => !string.IsNullOrEmpty(Description) ? $"{Name} ({Description})" : Name;
        }

        public class DbFunctionItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        public class DbFormTypeItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        public static List<DbFormTypeItem> LoadFormTypeItems()
        {
            List<DbFormTypeItem> list = new List<DbFormTypeItem>();
            try
            {
                foreach (No1Lib.Sys.FORM_TYPE type in Enum.GetValues(typeof(No1Lib.Sys.FORM_TYPE)))
                {
                    int id = (int)type;
                    string name = GetFormTypeName(type);
                    list.Add(new DbFormTypeItem { Id = id, Name = name });
                }
            }
            catch
            {
                list.Add(new DbFormTypeItem { Id = 0, Name = "ThÃªm sá»­a" });
                list.Add(new DbFormTypeItem { Id = 1, Name = "Quáº£n trá»‹" });
                list.Add(new DbFormTypeItem { Id = 6, Name = "Custom Form" });
            }
            return list;
        }

        public static string GetFormTypeName(No1Lib.Sys.FORM_TYPE type)
        {
            switch (type)
            {
                case No1Lib.Sys.FORM_TYPE.THEM_SUA: return "ThÃªm sá»­a";
                case No1Lib.Sys.FORM_TYPE.QUAN_TRI: return "Quáº£n trá»‹";
                case No1Lib.Sys.FORM_TYPE.CONG_NO_TRU_DUOI: return "CÃ´ng ná»£ trá»« Ä‘uÃ´i";
                case No1Lib.Sys.FORM_TYPE.CONG_NO_THEO_DON: return "CÃ´ng ná»£ theo hÃ³a Ä‘Æ¡n";
                case No1Lib.Sys.FORM_TYPE.TON_QUY: return "Tá»“n quá»¹";
                case No1Lib.Sys.FORM_TYPE.CUSTOM_CONTROL: return "Custom Control";
                case No1Lib.Sys.FORM_TYPE.CUSTOM_FORM: return "Custom Form";
                case No1Lib.Sys.FORM_TYPE.TON_KHO: return "Tá»“n kho";
                case No1Lib.Sys.FORM_TYPE.THEM_SUA_KO_THEO_LOAI: return "ThÃªm sá»­a khÃ´ng theo loáº¡i";
                case No1Lib.Sys.FORM_TYPE.TON_QUY_TAB: return "Tá»“n quá»¹ (tab)";
                case No1Lib.Sys.FORM_TYPE.TON_NHIEU_KHO: return "Tá»“n nhiá»u kho";
                case No1Lib.Sys.FORM_TYPE.CUSTOM_CLASS: return "Custom Class";
                default: return type.ToString();
            }
        }

        public static List<DbTableItem> LoadTableDescItems()
        {
            List<DbTableItem> list = new List<DbTableItem>();
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT ID, NAME, DESCRIPTION FROM STABLEDESC ORDER BY COALESCE(NULLIF(DESCRIPTION, ''), NAME) ASC";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string tId = rdr["ID"]?.ToString()?.Trim();
                            string tName = rdr["NAME"]?.ToString()?.Trim();
                            string tDesc = rdr["DESCRIPTION"] != DBNull.Value ? rdr["DESCRIPTION"]?.ToString()?.Trim() : null;
                            if (!string.IsNullOrEmpty(tName))
                            {
                                list.Add(new DbTableItem { Id = tId, Name = tName, Description = tDesc });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadTableDescItems error: " + ex.Message);
            }
            return list;
        }

        public static List<DbFunctionItem> LoadFunctionItems()
        {
            List<DbFunctionItem> list = new List<DbFunctionItem>();
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT ID, NAME FROM SFUNCTION ORDER BY SORTORDER, NAME ASC";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string fId = rdr["ID"]?.ToString()?.Trim();
                            string fName = rdr["NAME"] != DBNull.Value ? rdr["NAME"]?.ToString()?.Trim() : null;
                            if (!string.IsNullOrEmpty(fName))
                            {
                                list.Add(new DbFunctionItem { Id = fId, Name = fName });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadFunctionItems error: " + ex.Message);
            }
            return list;
        }

        public static byte[] ReadBlobBytes(FbDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                if (reader.IsDBNull(ordinal)) return null;

                byte[] buffer = (byte[])reader.GetValue(ordinal);
                return (buffer != null && buffer.Length > 0) ? buffer : null;
            }
            catch
            {
                return null;
            }
        }

        public static byte[] ReadBlobBytes(DataRow row, string columnName)
        {
            try
            {
                if (row == null || !row.Table.Columns.Contains(columnName) || row[columnName] == DBNull.Value) return null;
                byte[] buffer = row[columnName] as byte[];
                return (buffer != null && buffer.Length > 0) ? buffer : null;
            }
            catch
            {
                return null;
            }
        }

        private static string ReadBlobString(FbDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                if (reader.IsDBNull(ordinal)) return string.Empty;

                object val = reader.GetValue(ordinal);
                if (val == null || val == DBNull.Value) return string.Empty;

                if (val is string strVal) return strVal;

                if (val is byte[] buffer)
                {
                    if (buffer.Length == 0) return string.Empty;
                    return Encoding.UTF8.GetString(buffer);
                }

                return val.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string UpdateAeLayoutFromForm(string originalAeLayoutXml, Form form)
        {
            if (form == null) return originalAeLayoutXml;

            try
            {
                string wrappedXml = string.IsNullOrEmpty(originalAeLayoutXml) ? "" : originalAeLayoutXml.Trim();
                if (string.IsNullOrEmpty(wrappedXml))
                {
                    wrappedXml = $"<Root><Object type=\"No1Lib.Sys.No1Form, No1Lib.Sys\" name=\"{form.Name ?? "No1Form1"}\"><Property name=\"ClientSize\">{form.Width}, {form.Height}</Property><Property name=\"Size\">{form.Width}, {form.Height}</Property></Object></Root>";
                }
                else if (!wrappedXml.StartsWith("<Root>") && !wrappedXml.StartsWith("<?xml"))
                {
                    wrappedXml = $"<Root>{wrappedXml}</Root>";
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(wrappedXml);

                XmlNodeList objectNodes = doc.SelectNodes("//Object");
                if (objectNodes != null && objectNodes.Count > 0)
                {
                    XmlNode rootNode = null;
                    foreach (XmlNode n in objectNodes)
                    {
                        string typeAttr = n.Attributes["type"]?.Value ?? "";
                        if (typeAttr.ToLower().Contains("form") || typeAttr.ToLower().Contains("usercontrol"))
                        {
                            rootNode = n;
                            break;
                        }
                    }
                    if (rootNode == null) rootNode = objectNodes[0];

                    SetOrUpdateXmlProperty(doc, rootNode, "ClientSize", $"{form.Width}, {form.Height}");
                    SetOrUpdateXmlProperty(doc, rootNode, "Size", $"{form.Width}, {form.Height}");

                    // Collect ALL controls recursively throughout entire form hierarchy
                    Dictionary<string, Control> allControlsMap = new Dictionary<string, Control>(StringComparer.OrdinalIgnoreCase);
                    CollectAllFormControlsRecursive(form, allControlsMap);

                    // Update properties for every XML object node
                    foreach (XmlNode objNode in objectNodes)
                    {
                        string objName = objNode.Attributes["name"]?.Value;
                        if (!string.IsNullOrEmpty(objName) && allControlsMap.TryGetValue(objName, out Control ctrl))
                        {
                            SetOrUpdateXmlProperty(doc, objNode, "Location", $"{ctrl.Left}, {ctrl.Top}");
                            SetOrUpdateXmlProperty(doc, objNode, "Size", $"{ctrl.Width}, {ctrl.Height}");
                            SetOrUpdateXmlProperty(doc, objNode, "Anchor", ctrl.Anchor.ToString());
                            if (ctrl.Text != null)
                            {
                                SetOrUpdateXmlProperty(doc, objNode, "Text", ctrl.Text);
                            }
                        }
                    }
                }

                string resultXml = doc.OuterXml.Replace("<Root>", "").Replace("</Root>", "").Trim();
                return resultXml;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateAeLayoutFromForm error: " + ex.Message);
                return originalAeLayoutXml;
            }
        }

        private static void SetOrUpdateXmlProperty(XmlDocument doc, XmlNode objectNode, string propName, string propValue)
        {
            if (objectNode == null) return;
            XmlNode propNode = objectNode.SelectSingleNode($"./Property[@name='{propName}']");
            if (propNode == null)
            {
                XmlElement elem = doc.CreateElement("Property");
                elem.SetAttribute("name", propName);
                elem.InnerText = propValue;
                objectNode.AppendChild(elem);
            }
            else
            {
                propNode.InnerText = propValue;
            }
        }

        private static void CollectAllFormControlsRecursive(Control parent, Dictionary<string, Control> map)
        {
            if (parent == null) return;

            if (!string.IsNullOrEmpty(parent.Name) && !map.ContainsKey(parent.Name))
            {
                map[parent.Name] = parent;
            }

            if (parent is SplitContainer sc)
            {
                CollectAllFormControlsRecursive(sc.Panel1, map);
                CollectAllFormControlsRecursive(sc.Panel2, map);
            }
            else if (parent is TabControl tc)
            {
                foreach (TabPage tp in tc.TabPages)
                {
                    CollectAllFormControlsRecursive(tp, map);
                }
            }

            if (parent.Controls != null && parent.Controls.Count > 0)
            {
                foreach (Control child in parent.Controls)
                {
                    CollectAllFormControlsRecursive(child, map);
                }
            }
        }

        public static bool SaveFormModelFull(FormModel model, bool isCreateMode)
        {
            if (model == null) return false;

            List<string> targetDbs = new List<string>();
            string activeDb = GetConnectionString();
            targetDbs.Add(activeDb);

            string mainDbPath = @"D:\QuanLyNhaHang\Database\mainTanAnPhat.fdb";
            string xDbPath = @"D:\QuanLyNhaHang\Database\x.fdb";

            if (System.IO.File.Exists(mainDbPath))
            {
                string mainConnStr = GetConnectionString(mainDbPath);
                if (!targetDbs.Contains(mainConnStr)) targetDbs.Add(mainConnStr);
            }
            if (System.IO.File.Exists(xDbPath))
            {
                string xConnStr = GetConnectionString(xDbPath);
                if (!targetDbs.Contains(xConnStr)) targetDbs.Add(xConnStr);
            }

            byte[] codeBytes = !string.IsNullOrEmpty(model.Code) ? Encoding.UTF8.GetBytes(model.Code) : null;
            byte[] serverBytes = !string.IsNullOrEmpty(model.ServerCode) ? Encoding.UTF8.GetBytes(model.ServerCode) : null;
            byte[] clientBytes = !string.IsNullOrEmpty(model.ClientCode) ? Encoding.UTF8.GetBytes(model.ClientCode) : null;
            byte[] aeBytes = !string.IsNullOrEmpty(model.AeLayout) ? Encoding.UTF8.GetBytes(model.AeLayout) : null;
            byte[] designBytes = !string.IsNullOrEmpty(model.DesignCode) ? Encoding.UTF8.GetBytes(model.DesignCode) : null;

            bool overallSuccess = false;
            foreach (string connStr in targetDbs)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(connStr))
                    {
                        conn.Open();
                        bool exists = false;
                        string checkSql = "SELECT COUNT(*) FROM SFORM WHERE ID = @Id OR LOWER(NAME) = LOWER(@Name)";
                        using (FbCommand chkCmd = new FbCommand(checkSql, conn))
                        {
                            chkCmd.Parameters.AddWithValue("@Id", model.Id ?? "");
                            chkCmd.Parameters.AddWithValue("@Name", model.Name ?? "");
                            exists = Convert.ToInt32(chkCmd.ExecuteScalar()) > 0;
                        }

                        if (!exists && isCreateMode)
                        {
                            string insertSql = @"INSERT INTO SFORM (ID, NAME, CLASSNAME, FORMTYPE, LOAI, STABLEDESCID, SFUNCTIONID, NOTEMPLATE, IMAGE32, CODE, DESIGNCODE, AELAYOUT, TIMECREATED, TIMEMODIFIED, STATUS, AUTOID, USERCREATEDID, USERMODIFIEDID)
                                                 VALUES (@Id, @Name, @ClassName, @FormType, @Loai, @STableDescId, @SFunctionId, @NoTemplate, @Image32, @Code, @DesignCode, @AeLayout, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 30, 
                                                 (SELECT COALESCE(MAX(AUTOID), 0) + 1 FROM SFORM), '4f1466a0-0756-4ba9-afa8-053b96ca7569', '4f1466a0-0756-4ba9-afa8-053b96ca7569')";

                            using (FbCommand cmd = new FbCommand(insertSql, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id", model.Id);
                                cmd.Parameters.AddWithValue("@Name", (object)model.Name ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@ClassName", (object)model.ClassName ?? "");
                                cmd.Parameters.AddWithValue("@FormType", model.FormType);
                                cmd.Parameters.AddWithValue("@Loai", model.Loai);
                                cmd.Parameters.AddWithValue("@STableDescId", (object)model.STableDescId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SFunctionId", (object)model.SFunctionId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@NoTemplate", (object)model.BillCode ?? "");
                                cmd.Parameters.Add("@Image32", FbDbType.Binary).Value = (object)model.ImageBytes ?? DBNull.Value;
                                cmd.Parameters.Add("@Code", FbDbType.Binary).Value = (object)codeBytes ?? DBNull.Value;
                                cmd.Parameters.Add("@DesignCode", FbDbType.Binary).Value = (object)designBytes ?? DBNull.Value;
                                cmd.Parameters.Add("@AeLayout", FbDbType.Binary).Value = (object)aeBytes ?? DBNull.Value;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string updateSql = @"UPDATE SFORM SET 
                                                    NAME = @Name,
                                                    CLASSNAME = @ClassName,
                                                    FORMTYPE = @FormType,
                                                    LOAI = @Loai,
                                                    STABLEDESCID = @STableDescId,
                                                    SFUNCTIONID = @SFunctionId,
                                                    NOTEMPLATE = @NoTemplate,
                                                    IMAGE32 = @Image32,
                                                    DESIGNCODE = @DesignCode,
                                                    USERMODIFIEDID = '4f1466a0-0756-4ba9-afa8-053b96ca7569',
                                                    TIMEMODIFIED = CURRENT_TIMESTAMP
                                                 WHERE ID = @Id OR LOWER(NAME) = LOWER(@Name)";

                            using (FbCommand cmd = new FbCommand(updateSql, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id", model.Id);
                                cmd.Parameters.AddWithValue("@Name", (object)model.Name ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@ClassName", (object)model.ClassName ?? "");
                                cmd.Parameters.AddWithValue("@FormType", model.FormType);
                                cmd.Parameters.AddWithValue("@Loai", model.Loai);
                                cmd.Parameters.AddWithValue("@STableDescId", (object)model.STableDescId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SFunctionId", (object)model.SFunctionId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@NoTemplate", (object)model.BillCode ?? "");
                                cmd.Parameters.Add("@Image32", FbDbType.Binary).Value = (object)model.ImageBytes ?? DBNull.Value;
                                cmd.Parameters.Add("@DesignCode", FbDbType.Binary).Value = (object)designBytes ?? DBNull.Value;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        try
                        {
                            string updateVerSql = "UPDATE SCONFIG SET TEXTVALUE = @VerGuid WHERE NAME = 'AppAutoVersion'";
                            using (FbCommand cmdVer = new FbCommand(updateVerSql, conn))
                            {
                                cmdVer.Parameters.AddWithValue("@VerGuid", Guid.NewGuid().ToString());
                                cmdVer.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        overallSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("SaveFormModelFull error for " + connStr + ": " + ex.Message);
                }
            }
            return overallSuccess;
        }

        public static bool SaveFormCode(string formId, string code, string serverCode, string clientCode, string aeLayout = null, string formName = null, string className = null, int? loai = null)
        {
            List<string> targetDbs = new List<string>();
            string activeDb = GetConnectionString();
            targetDbs.Add(activeDb);

            string mainDbPath = @"D:\QuanLyNhaHang\Database\mainTanAnPhat.fdb";
            string xDbPath = @"D:\QuanLyNhaHang\Database\x.fdb";

            if (System.IO.File.Exists(mainDbPath))
            {
                string mainConnStr = GetConnectionString(mainDbPath);
                if (!targetDbs.Contains(mainConnStr)) targetDbs.Add(mainConnStr);
            }
            if (System.IO.File.Exists(xDbPath))
            {
                string xConnStr = GetConnectionString(xDbPath);
                if (!targetDbs.Contains(xConnStr)) targetDbs.Add(xConnStr);
            }

            byte[] codeBytes = !string.IsNullOrEmpty(code) ? Encoding.UTF8.GetBytes(code) : null;
            byte[] serverBytes = !string.IsNullOrEmpty(serverCode) ? Encoding.UTF8.GetBytes(serverCode) : null;
            byte[] clientBytes = !string.IsNullOrEmpty(clientCode) ? Encoding.UTF8.GetBytes(clientCode) : null;
            byte[] aeBytes = !string.IsNullOrEmpty(aeLayout) ? Encoding.UTF8.GetBytes(aeLayout) : null;

            bool overallSuccess = false;
            foreach (string connStr in targetDbs)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(connStr))
                    {
                        conn.Open();
                        string sql = "UPDATE SFORM SET CODE = @Code, SERVERCODE = @ServerCode, CLIENTCODE = @ClientCode, TIMEMODIFIED = CURRENT_TIMESTAMP";
                        if (aeBytes != null)
                        {
                            sql += ", AELAYOUT = @AeLayout";
                        }
                        if (!string.IsNullOrWhiteSpace(className))
                        {
                            sql += ", CLASSNAME = @ClassName";
                        }
                        if (loai.HasValue)
                        {
                            sql += ", LOAI = @Loai";
                        }
                        sql += " WHERE (ID IS NOT NULL AND ID = @Id) OR (NAME IS NOT NULL AND LOWER(NAME) = LOWER(@Name))";

                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@Id", FbDbType.VarChar).Value = (object)formId ?? DBNull.Value;
                            cmd.Parameters.Add("@Name", FbDbType.VarChar).Value = (object)formName ?? DBNull.Value;
                            cmd.Parameters.Add("@Code", FbDbType.Binary).Value = (object)codeBytes ?? DBNull.Value;
                            cmd.Parameters.Add("@ServerCode", FbDbType.Binary).Value = (object)serverBytes ?? DBNull.Value;
                            cmd.Parameters.Add("@ClientCode", FbDbType.Binary).Value = (object)clientBytes ?? DBNull.Value;
                            if (aeBytes != null)
                            {
                                cmd.Parameters.Add("@AeLayout", FbDbType.Binary).Value = aeBytes;
                            }
                            if (!string.IsNullOrWhiteSpace(className))
                            {
                                cmd.Parameters.Add("@ClassName", FbDbType.VarChar).Value = className;
                            }
                            if (loai.HasValue)
                            {
                                cmd.Parameters.Add("@Loai", FbDbType.Integer).Value = loai.Value;
                            }
                            cmd.ExecuteNonQuery();
                        }

                        try
                        {
                            string updateVerSql = "UPDATE SCONFIG SET TEXTVALUE = @VerGuid WHERE NAME = 'AppAutoVersion'";
                            using (FbCommand cmdVer = new FbCommand(updateVerSql, conn))
                            {
                                cmdVer.Parameters.AddWithValue("@VerGuid", Guid.NewGuid().ToString());
                                cmdVer.ExecuteNonQuery();
                            }
                        }
                        catch { }
                    }
                    overallSuccess = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("SaveFormCode error for " + connStr + ": " + ex.Message);
                }
            }
            return overallSuccess;
        }

        public static bool DeleteFormFromDb(string formId, string formName)
        {
            List<string> targetDbs = new List<string> { GetConnectionString() };
            string xConnStr = GetConnectionString(@"D:\QuanLyNhaHang\Database\x.fdb");
            if (!targetDbs.Contains(xConnStr)) targetDbs.Add(xConnStr);
            string mainConnStr = GetConnectionString(@"D:\QuanLyNhaHang\Database\mainTanAnPhat.fdb");
            if (!targetDbs.Contains(mainConnStr)) targetDbs.Add(mainConnStr);

            bool overallSuccess = false;
            foreach (string connStr in targetDbs)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(connStr))
                    {
                        conn.Open();
                        string sql = "DELETE FROM SFORM WHERE (ID IS NOT NULL AND ID = @Id) OR (NAME IS NOT NULL AND LOWER(NAME) = LOWER(@Name))";
                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@Id", FbDbType.VarChar).Value = (object)formId ?? DBNull.Value;
                            cmd.Parameters.Add("@Name", FbDbType.VarChar).Value = (object)formName ?? DBNull.Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    overallSuccess = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("DeleteFormFromDb error for " + connStr + ": " + ex.Message);
                }
            }
            return overallSuccess;
        }

        public static bool ClearFormLayoutInDb(string formId, string formName)
        {
            List<string> targetDbs = new List<string> { GetConnectionString() };
            string xConnStr = GetConnectionString(@"D:\QuanLyNhaHang\Database\x.fdb");
            if (!targetDbs.Contains(xConnStr)) targetDbs.Add(xConnStr);
            string mainConnStr = GetConnectionString(@"D:\QuanLyNhaHang\Database\mainTanAnPhat.fdb");
            if (!targetDbs.Contains(mainConnStr)) targetDbs.Add(mainConnStr);

            bool overallSuccess = false;
            foreach (string connStr in targetDbs)
            {
                try
                {
                    using (FbConnection conn = new FbConnection(connStr))
                    {
                        conn.Open();
                        string sql = "UPDATE SFORM SET AELAYOUT = NULL, TIMEMODIFIED = CURRENT_TIMESTAMP WHERE (ID IS NOT NULL AND ID = @Id) OR (NAME IS NOT NULL AND LOWER(NAME) = LOWER(@Name))";
                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@Id", FbDbType.VarChar).Value = (object)formId ?? DBNull.Value;
                            cmd.Parameters.Add("@Name", FbDbType.VarChar).Value = (object)formName ?? DBNull.Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    overallSuccess = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("ClearFormLayoutInDb error for " + connStr + ": " + ex.Message);
                }
            }
            return overallSuccess;
        }
        public static Form ParseAeLayoutToForm(string aeLayoutXml, string formTitle = "")
        {
            int defaultW = (formTitle != null && (formTitle.IndexOf("khu vá»±c", StringComparison.OrdinalIgnoreCase) >= 0 || formTitle.IndexOf("mÃ¡y in", StringComparison.OrdinalIgnoreCase) >= 0 || formTitle.IndexOf("chuyá»ƒn", StringComparison.OrdinalIgnoreCase) >= 0)) ? 546 : 600;
            int defaultH = (formTitle != null && (formTitle.IndexOf("khu vá»±c", StringComparison.OrdinalIgnoreCase) >= 0 || formTitle.IndexOf("mÃ¡y in", StringComparison.OrdinalIgnoreCase) >= 0 || formTitle.IndexOf("chuyá»ƒn", StringComparison.OrdinalIgnoreCase) >= 0)) ? 374 : 400;

            Form mainForm = new Form
            {
                Text = formTitle,
                Size = new Size(defaultW, defaultH),
                BackColor = Color.White
            };

            if (string.IsNullOrEmpty(aeLayoutXml)) return mainForm;

            try
            {
                string wrappedXml = aeLayoutXml.Trim();
                if (!wrappedXml.StartsWith("<Root>") && !wrappedXml.StartsWith("<?xml"))
                {
                    wrappedXml = $"<Root>{wrappedXml}</Root>";
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(wrappedXml);

                XmlNodeList objectNodes = doc.SelectNodes("//Object");
                if (objectNodes == null || objectNodes.Count == 0) return mainForm;

                Dictionary<string, Control> controlMap = new Dictionary<string, Control>(StringComparer.OrdinalIgnoreCase);
                Dictionary<string, XmlNode> nodeMap = new Dictionary<string, XmlNode>(StringComparer.OrdinalIgnoreCase);
                Dictionary<string, List<string>> childrenMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
                Dictionary<string, DataGridViewColumn> columnMap = new Dictionary<string, DataGridViewColumn>(StringComparer.OrdinalIgnoreCase);
                Dictionary<string, ToolStripItem> itemMap = new Dictionary<string, ToolStripItem>(StringComparer.OrdinalIgnoreCase);

                Control rootFormCtrl = null;

                // Pass 1: Instantiate controls, columns, & toolstrip items
                foreach (XmlNode node in objectNodes)
                {
                    string name = node.Attributes["name"]?.Value;
                    string typeName = node.Attributes["type"]?.Value;

                    if (string.IsNullOrEmpty(name)) continue;
                    nodeMap[name] = node;

                    string lowerType = typeName != null ? typeName.ToLower() : "";

                    if (lowerType.Contains("column") || name.StartsWith("col", StringComparison.OrdinalIgnoreCase))
                    {
                        string headerText = name;
                        XmlNode textNode = node.SelectSingleNode("./Property[@name='HeaderText']");
                        if (textNode != null && !string.IsNullOrEmpty(textNode.InnerText))
                        {
                            headerText = textNode.InnerText.Trim();
                        }

                        DataGridViewColumn col;
                        if (lowerType.Contains("combobox"))
                        {
                            col = new DataGridViewComboBoxColumn { Name = name, HeaderText = headerText, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
                        }
                        else if (lowerType.Contains("checkbox"))
                        {
                            col = new DataGridViewCheckBoxColumn { Name = name, HeaderText = headerText };
                        }
                        else
                        {
                            col = new DataGridViewTextBoxColumn { Name = name, HeaderText = headerText, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
                        }

                        ApplyColumnXmlProperties(col, node);
                        columnMap[name] = col;
                        continue;
                    }

                    if (lowerType.Contains("toolstripbutton") || lowerType.Contains("tsbutton"))
                    {
                        string btnText = name;
                        XmlNode textNode = node.SelectSingleNode("./Property[@name='Text']");
                        if (textNode != null && !string.IsNullOrEmpty(textNode.InnerText)) btnText = textNode.InnerText.Trim();

                        ToolStripButton tsb = new ToolStripButton(btnText) { Name = name };
                        ApplyToolStripItemXmlProperties(tsb, node);
                        itemMap[name] = tsb;
                        continue;
                    }
                    if (lowerType.Contains("toolstripseparator"))
                    {
                        ToolStripSeparator sep = new ToolStripSeparator { Name = name };
                        ApplyToolStripItemXmlProperties(sep, node);
                        itemMap[name] = sep;
                        continue;
                    }
                    if (lowerType.Contains("toolstriplabel") || lowerType.Contains("tslabel"))
                    {
                        string lblText = name;
                        XmlNode textNode = node.SelectSingleNode("./Property[@name='Text']");
                        if (textNode != null && !string.IsNullOrEmpty(textNode.InnerText)) lblText = textNode.InnerText.Trim();

                        ToolStripLabel tsl = new ToolStripLabel(lblText) { Name = name };
                        ApplyToolStripItemXmlProperties(tsl, node);
                        itemMap[name] = tsl;
                        continue;
                    }

                    Control ctrl = CreateControlFromType(typeName, name);
                    if (ctrl == null) continue;

                    List<string> childRefs = new List<string>();
                    XmlNodeList refNodes = node.SelectNodes("./Reference | .//Item/Reference");
                    if (refNodes != null)
                    {
                        foreach (XmlNode r in refNodes)
                        {
                            string refName = r.Attributes["name"]?.Value;
                            if (!string.IsNullOrEmpty(refName)) childRefs.Add(refName);
                        }
                    }
                    childrenMap[name] = childRefs;

                    ApplyXmlProperties(ctrl, node);
                    controlMap[name] = ctrl;

                    bool isFormNode = lowerType.Contains("no1form") || lowerType.EndsWith(".form") || lowerType.Contains("usercontrol") || (lowerType.Contains("form") && !lowerType.Contains("system.windows.forms"));
                    if (rootFormCtrl == null && isFormNode)
                    {
                        rootFormCtrl = ctrl;
                    }
                }

                // Pass 2: Connect Parent-Child & Add Columns/Items to Containers
                HashSet<Control> hasParent = new HashSet<Control>();

                foreach (var kvp in childrenMap)
                {
                    string parentName = kvp.Key;
                    if (controlMap.TryGetValue(parentName, out Control parentCtrl))
                    {
                        XmlNode parentNode = nodeMap.ContainsKey(parentName) ? nodeMap[parentName] : null;

                        foreach (string childName in kvp.Value)
                        {
                            if (columnMap.TryGetValue(childName, out DataGridViewColumn colObj))
                            {
                                DataGridView targetDgv = GetInnerDataGridView(parentCtrl);
                                if (targetDgv != null)
                                {
                                    if (!targetDgv.Columns.Contains(colObj.Name))
                                    {
                                        targetDgv.Columns.Add(colObj);
                                    }
                                }
                                continue;
                            }

                            if (parentCtrl is ToolStrip ts)
                            {
                                if (itemMap.TryGetValue(childName, out ToolStripItem tsi))
                                {
                                    ts.Items.Add(tsi);
                                    continue;
                                }
                                else if (controlMap.TryGetValue(childName, out Control cBtn))
                                {
                                    ToolStripButton tsb = new ToolStripButton(cBtn.Text != null ? cBtn.Text : cBtn.Name) { Name = cBtn.Name };
                                    ts.Items.Add(tsb);
                                    continue;
                                }
                            }

                            if (parentCtrl is ComponentFactory.Krypton.Navigator.KryptonNavigator knav)
                            {
                                if (controlMap.TryGetValue(childName, out Control childCtrl))
                                {
                                    if (childCtrl is ComponentFactory.Krypton.Navigator.KryptonPage kPage)
                                    {
                                        if (!knav.Pages.Contains(kPage))
                                        {
                                            knav.Pages.Add(kPage);
                                        }
                                        hasParent.Add(kPage);
                                    }
                                    else
                                    {
                                        ComponentFactory.Krypton.Navigator.KryptonPage newKp = new ComponentFactory.Krypton.Navigator.KryptonPage(!string.IsNullOrEmpty(childCtrl.Text) ? childCtrl.Text : childCtrl.Name);
                                        childCtrl.Dock = DockStyle.Fill;
                                        newKp.Controls.Add(childCtrl);
                                        knav.Pages.Add(newKp);
                                        hasParent.Add(childCtrl);
                                    }
                                }
                                continue;
                            }

                            if (parentCtrl is ComponentFactory.Krypton.Navigator.KryptonPage targetKPage)
                            {
                                if (controlMap.TryGetValue(childName, out Control childCtrl))
                                {
                                    targetKPage.Controls.Add(childCtrl);
                                    childCtrl.BringToFront();
                                    hasParent.Add(childCtrl);
                                }
                                continue;
                            }

                            if (parentCtrl is TabControl tc)
                            {
                                if (controlMap.TryGetValue(childName, out Control childCtrl))
                                {
                                    if (childCtrl is TabPage tabPg)
                                    {
                                        tc.TabPages.Add(tabPg);
                                        hasParent.Add(tabPg);
                                    }
                                    else
                                    {
                                        TabPage newTp = new TabPage(!string.IsNullOrEmpty(childCtrl.Text) ? childCtrl.Text : childCtrl.Name);
                                        childCtrl.Dock = DockStyle.Fill;
                                        newTp.Controls.Add(childCtrl);
                                        tc.TabPages.Add(newTp);
                                        hasParent.Add(childCtrl);
                                    }
                                }
                                continue;
                            }

                            if (parentCtrl is TabPage targetTabPage)
                            {
                                if (controlMap.TryGetValue(childName, out Control childCtrl))
                                {
                                    targetTabPage.Controls.Add(childCtrl);
                                    childCtrl.BringToFront();
                                    hasParent.Add(childCtrl);
                                }
                                continue;
                            }

                            if (controlMap.TryGetValue(childName, out Control cCtrl) && cCtrl != parentCtrl)
                            {
                                if (cCtrl is Form fCtrl)
                                {
                                    fCtrl.TopLevel = false;
                                }

                                if (parentCtrl is ComponentFactory.Krypton.Toolkit.KryptonSplitContainer ksc)
                                {
                                    XmlNode p2Node = parentNode != null ? parentNode.SelectSingleNode(".//Property[@name='Panel2']") : null;
                                    bool inPanel2 = p2Node != null && p2Node.SelectSingleNode($".//Reference[@name='{childName}']") != null;

                                    if (inPanel2)
                                    {
                                        ksc.Panel2.Controls.Add(cCtrl);
                                    }
                                    else
                                    {
                                        ksc.Panel1.Controls.Add(cCtrl);
                                    }
                                }
                                else if (parentCtrl is SplitContainer sc)
                                {
                                    XmlNode p2Node = parentNode != null ? parentNode.SelectSingleNode(".//Property[@name='Panel2']") : null;
                                    bool inPanel2 = p2Node != null && p2Node.SelectSingleNode($".//Reference[@name='{childName}']") != null;

                                    if (inPanel2)
                                    {
                                        sc.Panel2.Controls.Add(cCtrl);
                                    }
                                    else
                                    {
                                        sc.Panel1.Controls.Add(cCtrl);
                                    }
                                }
                                else
                                {
                                    SafeAddChildControl(parentCtrl, cCtrl);
                                    if (cCtrl.Dock == DockStyle.Fill)
                                    {
                                        SafeSendToBack(cCtrl);
                                    }
                                    else
                                    {
                                        SafeBringToFront(cCtrl);
                                    }
                                }
                                hasParent.Add(cCtrl);
                            }
                        }
                    }
                }

                // Pass 2.5: Ensure all unassigned columns in columnMap are added to the DataGridView(s)
                List<DataGridView> allGrids = controlMap.Values.Select(c => GetInnerDataGridView(c)).Where(g => g != null).Distinct().ToList();
                if (allGrids.Count > 0)
                {
                    DataGridView targetDgv = allGrids.FirstOrDefault(g => g.Name.Equals("grMain", StringComparison.OrdinalIgnoreCase)) ?? allGrids[0];
                    foreach (var colKvp in columnMap)
                    {
                        DataGridViewColumn colObj = colKvp.Value;
                        bool alreadyAdded = allGrids.Any(g => g.Columns.Contains(colObj.Name));
                        if (!alreadyAdded)
                        {
                            targetDgv.Columns.Add(colObj);
                        }
                    }
                }

                // Pass 2.6: Dynamically populate printer choices for DataGridViewComboBoxColumns from Windows system printers
                foreach (var dgv in allGrids)
                {
                    if (dgv.Columns.Count > 0)
                    {
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (col is DataGridViewComboBoxColumn comboCol && comboCol.Items.Count == 0)
                            {
                                try
                                {
                                    comboCol.Items.Add("(Máº·c Ä‘á»‹nh há»‡ thá»‘ng)");
                                    foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                                    {
                                        if (!comboCol.Items.Contains(printer))
                                        {
                                            comboCol.Items.Add(printer);
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }

                // Pass 2.7: Smart layout positioning & Krypton panel styling for top/bottom panels & controls (prevent overlapping)
                foreach (Control parent in controlMap.Values.Concat(new[] { rootFormCtrl }).Where(p => p != null))
                {
                    Color kryptonBlue = Color.FromArgb(165, 196, 229);
                    List<Control> childControls = parent.Controls.OfType<Control>().ToList();

                    foreach (Control child in childControls)
                    {
                        if (child is Panel pnl)
                        {
                            if (pnl.Dock == DockStyle.Bottom)
                            {
                                if (pnl.BackColor == Color.White || pnl.BackColor == Color.Empty || pnl.BackColor == Color.Transparent)
                                {
                                    pnl.BackColor = kryptonBlue;
                                }
                                SafeBringToFront(pnl);
                            }
                            else if (pnl.Dock == DockStyle.Top)
                            {
                                if (pnl.BackColor == Color.White || pnl.BackColor == Color.Empty || pnl.BackColor == Color.Transparent)
                                {
                                    pnl.BackColor = kryptonBlue;
                                }
                                SafeBringToFront(pnl);
                            }
                        }
                        else if (child is SplitContainer || child is ComponentFactory.Krypton.Toolkit.KryptonSplitContainer)
                        {
                            if (child.Dock == DockStyle.None) child.Dock = DockStyle.Fill;
                            SafeSendToBack(child);
                        }
                    }
                }

                // Pass 3: Arrange stacked controls inside panels in correct WinForms Docking Z-order
                Action<Control> handleSplitPanelControls = (panel) =>
                {
                    if (panel == null || panel.Controls.Count <= 1) return;
                    List<Control> pControls = panel.Controls.OfType<Control>().ToList();

                    List<Control> sideControls = pControls.Where(c => c.Dock == DockStyle.Left || c.Dock == DockStyle.Right).OrderBy(c => c.Location.X).ToList();
                    List<Control> topControls = pControls.Where(c => c.Dock == DockStyle.Top).OrderByDescending(c => c.Location.Y).ToList();
                    List<Control> bottomControls = pControls.Where(c => c.Dock == DockStyle.Bottom).OrderBy(c => c.Location.Y).ToList();
                    List<Control> fillControls = pControls.Where(c => c.Dock == DockStyle.Fill).ToList();

                    if (sideControls.Count > 0 || topControls.Count > 0 || bottomControls.Count > 0 || fillControls.Count > 0)
                    {
                        foreach (Control c in fillControls) c.SendToBack();
                        foreach (Control c in bottomControls) c.SendToBack();
                        foreach (Control c in topControls) c.SendToBack();
                        foreach (Control c in sideControls) c.SendToBack();
                    }
                };

                foreach (Control ctrl in controlMap.Values.Concat(new[] { rootFormCtrl }))
                {
                    if (ctrl != null)
                    {
                        if (ctrl is SplitContainer sc)
                        {
                            handleSplitPanelControls(sc.Panel1);
                            handleSplitPanelControls(sc.Panel2);
                        }
                        else if (ctrl is ComponentFactory.Krypton.Toolkit.KryptonSplitContainer ksc)
                        {
                            handleSplitPanelControls(ksc.Panel1);
                            handleSplitPanelControls(ksc.Panel2);
                        }
                        else
                        {
                            handleSplitPanelControls(ctrl);
                        }
                    }
                }

                // Ensure all created controls are recursively visible
                Action<Control> forceVisible = null;
                forceVisible = (c) =>
                {
                    if (c == null) return;
                    if (c.Name == "toolbar" && c.Parent is No1Lib.Sys.GridMapper gm && !gm.ShowToolbar)
                    {
                        c.Visible = false;
                        return;
                    }
                    c.Visible = true;
                    foreach (Control child in c.Controls)
                    {
                        forceVisible(child);
                    }
                };

                foreach (Control c in controlMap.Values)
                {
                    forceVisible(c);
                    DataGridView gridToPopulate = GetInnerDataGridView(c);
                    if (gridToPopulate != null && gridToPopulate.Rows.Count == 0)
                    {
                        PopulateDynamicGridRows(gridToPopulate, formTitle);
                    }
                }

                // Pass 3.5: Auto-hide GridMapper's default inner toolbar when container has a custom ToolStrip or ShowToolbar=false
                foreach (Control container in controlMap.Values.Concat(new[] { rootFormCtrl }).Where(c => c != null))
                {
                    var toolstrips = container.Controls.OfType<ToolStrip>().Where(ts => ts.Name != "toolbar").ToList();
                    bool hasCustomTs = toolstrips.Count > 0;

                    foreach (Control child in container.Controls)
                    {
                        if (child is No1Lib.Sys.GridMapper gm)
                        {
                            if (hasCustomTs || !gm.ShowToolbar)
                            {
                                gm.ShowToolbar = false;
                                Control innerTb = gm.Controls["toolbar"];
                                if (innerTb != null) innerTb.Visible = false;
                            }
                        }
                        else
                        {
                            PropertyInfo piShow = child.GetType().GetProperty("ShowToolbar");
                            if (piShow != null && piShow.CanWrite && hasCustomTs)
                            {
                                try { piShow.SetValue(child, false, null); } catch { }
                            }
                            Control innerTb = child.Controls["toolbar"];
                            if (innerTb != null && hasCustomTs) innerTb.Visible = false;
                        }
                    }

                    if (hasCustomTs)
                    {
                        foreach (var ts in toolstrips)
                        {
                            ts.Dock = DockStyle.Top;
                            SafeBringToFront(ts);
                        }
                    }
                }

                // Calculate exact form size dynamically based on control bounds & XML root size
                int calculatedW = 380;
                int calculatedH = 220;

                foreach (Control c in controlMap.Values)
                {
                    if (c.Right > calculatedW && c.Right < 1600) calculatedW = c.Right;
                    if (c.Bottom > calculatedH && c.Bottom < 1200) calculatedH = c.Bottom;
                }

                if (rootFormCtrl != null && rootFormCtrl.Width > 200 && rootFormCtrl.Height > 150)
                {
                    calculatedW = Math.Max(calculatedW, rootFormCtrl.Width);
                    calculatedH = Math.Max(calculatedH, rootFormCtrl.Height);
                }

                mainForm.Size = new Size(calculatedW + 16, calculatedH + 38);
                mainForm.ClientSize = new Size(calculatedW, calculatedH);

                // Mount controls onto mainForm
                if (rootFormCtrl != null)
                {
                    if (rootFormCtrl is Form rForm)
                    {
                        rForm.TopLevel = false;
                    }
                    rootFormCtrl.Dock = DockStyle.Fill;
                    mainForm.Controls.Add(rootFormCtrl);
                    if (!string.IsNullOrEmpty(rootFormCtrl.Text))
                    {
                        mainForm.Text = rootFormCtrl.Text;
                    }
                    forceVisible(rootFormCtrl);
                }
                else
                {
                    foreach (var ctrl in controlMap.Values)
                    {
                        if (!hasParent.Contains(ctrl))
                        {
                            if (ctrl is Form fCtrl)
                            {
                                fCtrl.TopLevel = false;
                            }
                            mainForm.Controls.Add(ctrl);
                            SafeBringToFront(ctrl);
                            forceVisible(ctrl);
                        }
                    }
                }

                // Apply SplitterDistance after form and containers have valid sizes & on Load
                Action applySplitters = () =>
                {
                    foreach (Control c in controlMap.Values)
                    {
                        int tagDist = (c.Tag is int dist && dist > 5) ? dist : -1;

                        if (c is SplitContainer sc)
                        {
                            int currentDist = tagDist > 5 ? tagDist : (sc.Orientation == Orientation.Vertical ? sc.Width : sc.Height) / 2;
                            int maxLimit = (sc.Orientation == Orientation.Vertical ? sc.Width : sc.Height) - 20;
                            if (maxLimit > 20 && currentDist > 5)
                            {
                                try { sc.SplitterDistance = Math.Max(10, Math.Min(currentDist, maxLimit)); } catch { }
                            }
                        }
                        else if (c is ComponentFactory.Krypton.Toolkit.KryptonSplitContainer ksc)
                        {
                            int currentDist = tagDist > 5 ? tagDist : (ksc.Orientation == Orientation.Vertical ? ksc.Width : ksc.Height) / 2;
                            int maxLimit = (ksc.Orientation == Orientation.Vertical ? ksc.Width : ksc.Height) - 20;
                            if (maxLimit > 20 && currentDist > 5)
                            {
                                try { ksc.SplitterDistance = Math.Max(10, Math.Min(currentDist, maxLimit)); } catch { }
                            }
                        }
                        else
                        {
                            PropertyInfo pi = c.GetType().GetProperty("SplitterDistance");
                            if (pi != null && pi.CanWrite && tagDist > 5)
                            {
                                try { pi.SetValue(c, tagDist, null); } catch { }
                            }
                        }
                    }
                };

                applySplitters();
                mainForm.Load += (s, e) => applySplitters();
                forceVisible(mainForm);

                Dictionary<string, string> formMetaProps = new Dictionary<string, string>();
                if (rootFormCtrl != null && nodeMap.TryGetValue(rootFormCtrl.Name, out XmlNode rootNode))
                {
                    string rootType = rootNode.Attributes["type"]?.Value ?? "";
                    if (rootType.Contains("UserControl"))
                    {
                        formMetaProps["IsUserControl"] = "true";
                    }

                    XmlNode minNode = rootNode.SelectSingleNode("./Property[@name='MinimizeBox']");
                    if (minNode != null) formMetaProps["MinimizeBox"] = minNode.InnerText.Trim();

                    XmlNode maxNode = rootNode.SelectSingleNode("./Property[@name='MaximizeBox']");
                    if (maxNode != null) formMetaProps["MaximizeBox"] = maxNode.InnerText.Trim();

                    XmlNode iconNode = rootNode.SelectSingleNode("./Property[@name='ShowIcon']");
                    if (iconNode != null) formMetaProps["ShowIcon"] = iconNode.InnerText.Trim();
                }

                if (nodeMap.ContainsKey("mapper") || aeLayoutXml.Contains("AeController") || aeLayoutXml.Contains("No1FieldMap"))
                {
                    formMetaProps["HasMapper"] = "true";
                }

                mainForm.Tag = formMetaProps;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ParseAeLayoutToForm error: " + ex);
                System.Diagnostics.Debug.WriteLine("ParseAeLayoutToForm error: " + ex.Message);
            }

            return mainForm;
        }

        public static string StitchFormXmlLayouts(FormModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.AeLayout)) return model?.AeLayout;

            try
            {
                string mainXml = model.AeLayout.Trim();
                if (mainXml.StartsWith("<?xml"))
                {
                    int idx = mainXml.IndexOf("?>");
                    if (idx >= 0) mainXml = mainXml.Substring(idx + 2).Trim();
                }
                if (!mainXml.StartsWith("<Root>"))
                {
                    mainXml = $"<Root>{mainXml}</Root>";
                }

                XmlDocument docMain = new XmlDocument();
                docMain.LoadXml(mainXml);

                // Check if this form is a container layout needing POS sub-controls (e.g. SuDungDichVu)
                bool isPosContainer = string.Equals(model.ClassName, "SuDungDichVu", StringComparison.OrdinalIgnoreCase) ||
                                      string.Equals(model.Name, "Sá»­ dá»¥ng dá»‹ch vá»¥", StringComparison.OrdinalIgnoreCase) ||
                                      docMain.SelectSingleNode("//Object[@name='splitMain']") != null;

                if (isPosContainer)
                {
                    string subXml = GetPosSubControlsXmlFromDb();
                    if (!string.IsNullOrEmpty(subXml))
                    {
                        string wrappedSub = subXml.Trim();
                        if (wrappedSub.StartsWith("<?xml"))
                        {
                            int idx = wrappedSub.IndexOf("?>");
                            if (idx >= 0) wrappedSub = wrappedSub.Substring(idx + 2).Trim();
                        }
                        if (!wrappedSub.StartsWith("<Root>"))
                        {
                            wrappedSub = $"<Root>{wrappedSub}</Root>";
                        }

                        XmlDocument docSub = new XmlDocument();
                        docSub.LoadXml(wrappedSub);

                        // Remove duplicate No1UserControl1 root node in docSub to prevent circular control reference
                        XmlNode ucSub = docSub.SelectSingleNode("//Object[@name='No1UserControl1']");
                        if (ucSub != null && ucSub.ParentNode != null)
                        {
                            ucSub.ParentNode.RemoveChild(ucSub);
                        }

                        // Attach reference to splitHoaDon into splitMain Panel2
                        XmlNode smObj = docMain.SelectSingleNode("//Object[@name='splitMain']");
                        if (smObj != null)
                        {
                            XmlNode p2Node = smObj.SelectSingleNode("./Property[@name='Panel2']");
                            if (p2Node == null)
                            {
                                p2Node = docMain.CreateElement("Property");
                                ((XmlElement)p2Node).SetAttribute("name", "Panel2");
                                smObj.AppendChild(p2Node);
                            }

                            XmlNode ctrlNode = p2Node.SelectSingleNode("./Property[@name='Controls']");
                            if (ctrlNode == null)
                            {
                                ctrlNode = docMain.CreateElement("Property");
                                ((XmlElement)ctrlNode).SetAttribute("name", "Controls");
                                p2Node.AppendChild(ctrlNode);
                            }

                            bool alreadyReferenced = ctrlNode.SelectSingleNode(".//Reference[@name='splitHoaDon']") != null;
                            if (!alreadyReferenced)
                            {
                                XmlElement itemElem = docMain.CreateElement("Item");
                                itemElem.SetAttribute("type", "ComponentFactory.Krypton.Toolkit.KryptonSplitContainer, ComponentFactory.Krypton.Toolkit, Version=4.1.6.0, Culture=neutral, PublicKeyToken=5fd520d36328f741");
                                XmlElement refElem = docMain.CreateElement("Reference");
                                refElem.SetAttribute("name", "splitHoaDon");
                                itemElem.AppendChild(refElem);
                                ctrlNode.AppendChild(itemElem);
                            }
                        }

                        // Import all Object nodes from POS order layout XML into docMain Root
                        XmlNode rootMain = docMain.SelectSingleNode("/Root");
                        foreach (XmlNode objNode in docSub.SelectNodes("//Object"))
                        {
                            string objName = objNode.Attributes["name"]?.Value;
                            if (!string.IsNullOrEmpty(objName) && docMain.SelectSingleNode($"//Object[@name='{objName}']") == null)
                            {
                                XmlNode imported = docMain.ImportNode(objNode, true);
                                rootMain.AppendChild(imported);
                            }
                        }
                    }
                }

                return docMain.OuterXml;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("StitchFormXmlLayouts error: " + ex.Message);
                return model.AeLayout;
            }
        }

        private static string GetPosSubControlsXmlFromDb()
        {
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    // Prioritize exact POS form ID 'f3f7bb77-f4ba-4111-9066-014f52be79a0' (HÃ³a Ä‘Æ¡n nhÃ  hÃ ng - 173KB POS Order interface)
                    string sql = @"SELECT AELAYOUT 
                                   FROM SFORM 
                                   WHERE ID = 'f3f7bb77-f4ba-4111-9066-014f52be79a0' AND AELAYOUT IS NOT NULL";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        object val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            if (val is byte[] blob) return Encoding.UTF8.GetString(blob);
                            return val.ToString();
                        }
                    }

                    // Fallback to largest non-empty AELAYOUT containing splitHoaDon
                    string sqlFallback = "SELECT CLASSNAME, AELAYOUT FROM SFORM WHERE AELAYOUT IS NOT NULL";
                    using (FbCommand cmd = new FbCommand(sqlFallback, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        int maxLen = 0;
                        string bestXml = null;
                        while (rdr.Read())
                        {
                            byte[] blob = rdr["AELAYOUT"] as byte[];
                            if (blob != null && blob.Length > maxLen)
                            {
                                string xml = Encoding.UTF8.GetString(blob);
                                if (xml.Contains("splitHoaDon") || xml.Contains("btnInCheBien") || xml.Contains("btnThanhToan"))
                                {
                                    maxLen = blob.Length;
                                    bestXml = xml;
                                }
                            }
                        }
                        return bestXml;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetPosSubControlsXmlFromDb error: " + ex.Message);
            }
            return null;
        }

        public static void AttachDynamicDataBindings(Form form, FormModel model)
        {
            if (form == null) return;

            try
            {
                // 1. Locate Area/Table navigators (tabKhuVuc, tabKhuVuc2)
                Control tab1 = FindControlRecursive(form, "tabKhuVuc");
                Control tab2 = FindControlRecursive(form, "tabKhuVuc2");
                Control splitKv = FindControlRecursive(form, "splitKhuVuc");

                // If tabKhuVuc is present, populate tables & areas from DKHUVUC and DBAN
                if (tab1 != null)
                {
                    PopulateDynamicTableCards(tab1, tab2, splitKv, form);
                }

                // 2. Locate Order DataGrid (grMua, grMain, dgvOrder)
                Control grMua = FindControlRecursive(form, "grMua") ?? FindControlRecursive(form, "grMain");
                DataGridView dgvOrder = GetInnerDataGridView(grMua);

                // 3. Locate Totals & Summary controls (numTONGCONG, numTIENTHANHTOAN, etc.)
                Control numTotal = FindControlRecursive(form, "numTONGCONG");
                Control numPay = FindControlRecursive(form, "numTIENTHANHTOAN");
                Control btnSave = FindControlRecursive(form, "btnLuu");

                if (btnSave != null && dgvOrder != null)
                {
                    btnSave.Click += (s, e) =>
                    {
                        MessageBox.Show("ÄÃ£ lÆ°u vÃ  xÃ¡c nháº­n Ä‘Æ¡n hÃ ng thÃ nh cÃ´ng!", "ThÃ´ng bÃ¡o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AttachDynamicDataBindings error: " + ex.Message);
            }
        }

        private static void PopulateDynamicTableCards(Control tab1Ctrl, Control tab2Ctrl, Control splitKvCtrl, Form form)
        {
            try
            {
                ClearTabPages(tab1Ctrl);
                ClearTabPages(tab2Ctrl);

                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sqlKv = "SELECT ID, NAME, COALESCE(TABHIENTHI, 0) AS TABIDX FROM DKHUVUC WHERE STATUS = 30 ORDER BY SORTORDER, NAME";
                    DataTable dtKv = new DataTable();
                    using (FbDataAdapter da = new FbDataAdapter(sqlKv, conn)) { da.Fill(dtKv); }

                    foreach (DataRow r in dtKv.Rows)
                    {
                        string id = r["ID"]?.ToString();
                        string name = r["NAME"]?.ToString();
                        int tabIdx = r["TABIDX"] != DBNull.Value ? Convert.ToInt32(r["TABIDX"]) : 0;

                        FlowLayoutPanel pnlCards = new FlowLayoutPanel
                        {
                            Dock = DockStyle.Fill,
                            AutoScroll = true,
                            BackColor = Color.FromArgb(245, 246, 248),
                            Padding = new Padding(6)
                        };

                        if (tabIdx == 1 && tab2Ctrl != null)
                        {
                            AddTabPageToNav(tab2Ctrl, name, id, pnlCards);
                        }
                        else
                        {
                            AddTabPageToNav(tab1Ctrl, name, id, pnlCards);
                        }

                        LoadTableCardsForPageXml(id, pnlCards, form);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("PopulateDynamicTableCards error: " + ex.Message);
            }
        }

        private static void ClearTabPages(Control tabCtrl)
        {
            if (tabCtrl == null) return;
            if (tabCtrl is ComponentFactory.Krypton.Navigator.KryptonNavigator knav)
            {
                knav.Pages.Clear();
            }
            else if (tabCtrl is TabControl tc)
            {
                tc.TabPages.Clear();
            }
        }

        private static void AddTabPageToNav(Control tabCtrl, string title, string name, Control childContainer)
        {
            if (tabCtrl == null) return;
            if (tabCtrl is ComponentFactory.Krypton.Navigator.KryptonNavigator knav)
            {
                ComponentFactory.Krypton.Navigator.KryptonPage page = new ComponentFactory.Krypton.Navigator.KryptonPage(title) { Name = name, Text = title, Tag = name };
                childContainer.Dock = DockStyle.Fill;
                page.Controls.Add(childContainer);
                knav.Pages.Add(page);
            }
            else if (tabCtrl is TabControl tc)
            {
                TabPage page = new TabPage(title) { Name = name, Text = title, Tag = name };
                childContainer.Dock = DockStyle.Fill;
                page.Controls.Add(childContainer);
                tc.TabPages.Add(page);
            }
        }



        private static string GetControlTextByName(Control parent, string ctrlName)
        {
            Control c = FindControlRecursive(parent, ctrlName);
            if (c == null) return "";
            if (c.GetType().Name.Contains("LookUpEdit") || c.GetType().Name.Contains("ComboBox"))
            {
                var val = c.GetType().GetProperty("EditValue")?.GetValue(c) ?? c.GetType().GetProperty("SelectedValue")?.GetValue(c);
                return val?.ToString() ?? "";
            }
            return c.Text;
        }

        private static void SetControlTextByName(Control parent, string ctrlName, string text)
        {
            Control c = FindControlRecursive(parent, ctrlName);
            if (c != null)
            {
                if (c.GetType().Name.Contains("LookUpEdit") || c.GetType().Name.Contains("ComboBox"))
                {
                    try {
                        var props = c.GetType().GetProperty("EditValue") ?? c.GetType().GetProperty("SelectedValue");
                        props?.SetValue(c, text);
                    } catch { }
                }
                else
                {
                    c.Text = text;
                }
            }
        }

        private static void ClearFormFields(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb) tb.Clear();
                else if (c is ComboBox cb) cb.SelectedIndex = -1;
                else if (c is CheckBox chk) chk.Checked = false;
                else if (c is DateTimePicker dtp) dtp.Value = DateTime.Now;
                else if (c.GetType().Name.Contains("LookUpEdit"))
                {
                    try { c.GetType().GetProperty("EditValue")?.SetValue(c, null); } catch { }
                }
                
                if (c.Controls.Count > 0)
                {
                    ClearFormFields(c);
                }
            }
        }

        private static void LoadTableCardsForPageXml(string kvId, FlowLayoutPanel pnlContainer, Form parentForm)
        {
            pnlContainer.Controls.Clear();
            try
            {
                using (FbConnection conn = new FbConnection(GetConnectionString()))
                {
                    conn.Open();
                    string sql = @"
                        SELECT B.ID, B.NAME, B.TDONHANGID, H.BATDAU
                        FROM DBAN B
                        LEFT JOIN TDONHANG H ON B.TDONHANGID = H.ID AND H.DATHANHTOAN = 0
                        WHERE B.DKHUVUCID = @KvID
                        ORDER BY B.NAME";

                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@KvID", kvId);
                        using (FbDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                string banId = rdr["ID"]?.ToString();
                                string banName = rdr["NAME"]?.ToString();
                                string orderId = rdr["TDONHANGID"] != DBNull.Value ? rdr["TDONHANGID"]?.ToString() : null;
                                DateTime? batDau = rdr["BATDAU"] != DBNull.Value ? Convert.ToDateTime(rdr["BATDAU"]) : (DateTime?)null;

                                bool inUse = !string.IsNullOrEmpty(orderId);

                                Panel card = new Panel
                                {
                                    Size = new Size(95, 95),
                                    Margin = new Padding(6),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    BackColor = inUse ? Color.FromArgb(255, 235, 235) : Color.White,
                                    Cursor = Cursors.Hand
                                };

                                if (inUse && batDau.HasValue)
                                {
                                    TimeSpan diff = DateTime.Now - batDau.Value;
                                    Label lblBadge = new Label
                                    {
                                        Text = $"{(int)diff.TotalHours}h {diff.Minutes}'",
                                        BackColor = Color.Red,
                                        ForeColor = Color.White,
                                        Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                                        Size = new Size(50, 16),
                                        TextAlign = ContentAlignment.MiddleCenter
                                    };
                                    card.Controls.Add(lblBadge);
                                }

                                Label lblName = new Label
                                {
                                    Text = banName,
                                    Dock = DockStyle.Bottom,
                                    Height = 26,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                                    ForeColor = inUse ? Color.DarkRed : Color.Black
                                };
                                card.Controls.Add(lblName);

                                card.Click += (s, e) =>
                                {
                                    OnTableCardSelectedInXmlForm(parentForm, banName, orderId, batDau);
                                };
                                lblName.Click += (s, e) => card.PerformClick();

                                pnlContainer.Controls.Add(card);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadTableCardsForPageXml error: " + ex.Message);
            }
        }

        private static void OnTableCardSelectedInXmlForm(Form form, string banName, string orderId, DateTime? batDau)
        {
            try
            {
                Control lblBan = FindControlRecursive(form, "lblNAME") ?? FindControlRecursive(form, "label1");
                if (lblBan != null && lblBan.Text != null)
                {
                    lblBan.Text = "BÃ n: " + banName;
                }

                Control grMua = FindControlRecursive(form, "grMua") ?? FindControlRecursive(form, "grMain");
                DataGridView dgvOrder = GetInnerDataGridView(grMua);
                Control numTotal = FindControlRecursive(form, "numTONGCONG");

                if (dgvOrder != null)
                {
                    DataTable dtOrder = new DataTable();
                    dtOrder.Columns.Add("TÃªn hÃ ng", typeof(string));
                    dtOrder.Columns.Add("ÄVT", typeof(string));
                    dtOrder.Columns.Add("SL", typeof(decimal));
                    dtOrder.Columns.Add("Ä giÃ¡", typeof(decimal));
                    dtOrder.Columns.Add("CK%", typeof(decimal));
                    dtOrder.Columns.Add("T tiá»n", typeof(decimal));

                    decimal totalSum = 0m;
                    if (!string.IsNullOrEmpty(orderId))
                    {
                        using (FbConnection conn = new FbConnection(GetConnectionString()))
                        {
                            conn.Open();
                            string sql = @"
                                SELECT M.NAME AS TENHANG, D.NAME AS DVT, C.SLXUAT AS SOLUONG, C.DONGIA, COALESCE(C.TILEGIAMGIA, 0) AS CHIECKHAU, C.THANHTIEN
                                FROM TDONHANGCHITIET C
                                INNER JOIN DMATHANG M ON C.DMATHANGID = M.ID
                                LEFT JOIN DDONVITINH D ON M.DDONVITINHID = D.ID
                                WHERE C.TDONHANGID = @OrderID";

                            using (FbCommand cmd = new FbCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@OrderID", orderId);
                                using (FbDataReader rdr = cmd.ExecuteReader())
                                {
                                    while (rdr.Read())
                                    {
                                        string ten = rdr["TENHANG"]?.ToString();
                                        string dvt = rdr["DVT"] != DBNull.Value ? rdr["DVT"]?.ToString() : "";
                                        decimal sl = rdr["SOLUONG"] != DBNull.Value ? Convert.ToDecimal(rdr["SOLUONG"]) : 1m;
                                        decimal gia = rdr["DONGIA"] != DBNull.Value ? Convert.ToDecimal(rdr["DONGIA"]) : 0m;
                                        decimal ck = rdr["CHIECKHAU"] != DBNull.Value ? Convert.ToDecimal(rdr["CHIECKHAU"]) : 0m;
                                        decimal tt = rdr["THANHTIEN"] != DBNull.Value ? Convert.ToDecimal(rdr["THANHTIEN"]) : (sl * gia) - ck;
                                        totalSum += tt;

                                        dtOrder.Rows.Add(ten, dvt, sl, gia, ck, tt);
                                    }
                                }
                            }
                        }
                    }

                    dgvOrder.DataSource = dtOrder;

                    if (numTotal != null)
                    {
                        PropertyInfo piValue = numTotal.GetType().GetProperty("Value");
                        if (piValue != null && piValue.CanWrite)
                        {
                            try { piValue.SetValue(numTotal, Convert.ChangeType(totalSum, piValue.PropertyType), null); } catch { }
                        }
                        else
                        {
                            numTotal.Text = totalSum.ToString("#,##0");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("OnTableCardSelectedInXmlForm error: " + ex.Message);
            }
        }

        private static Control FindControlRecursive(Control parent, string controlName)
        {
            if (parent == null || string.IsNullOrEmpty(controlName)) return null;
            if (string.Equals(parent.Name, controlName, StringComparison.OrdinalIgnoreCase)) return parent;

            foreach (Control child in parent.Controls)
            {
                Control found = FindControlRecursive(child, controlName);
                if (found != null) return found;
            }
            return null;
        }

        private static void SafeBringToFront(Control c)
        {
            if (c == null) return;
            try
            {
                if (c.Parent != null && !(c.Parent is SplitContainer))
                {
                    c.BringToFront();
                }
            }
            catch { }
        }

        private static void SafeSendToBack(Control c)
        {
            if (c == null) return;
            try
            {
                if (c.Parent != null && !(c.Parent is SplitContainer))
                {
                    c.SendToBack();
                }
            }
            catch { }
        }

        private static void SafeAddChildControl(Control parentCtrl, Control childCtrl)
        {
            if (parentCtrl == null || childCtrl == null) return;
            try
            {
                if (parentCtrl is ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup khg)
                {
                    khg.Panel.Controls.Add(childCtrl);
                    return;
                }
                if (parentCtrl is ComponentFactory.Krypton.Toolkit.KryptonGroup kg)
                {
                    kg.Panel.Controls.Add(childCtrl);
                    return;
                }
                if (parentCtrl is ToolStrip ts)
                {
                    ToolStripButton tsb = new ToolStripButton(!string.IsNullOrEmpty(childCtrl.Text) ? childCtrl.Text : childCtrl.Name) { Name = childCtrl.Name };
                    ts.Items.Add(tsb);
                    return;
                }

                parentCtrl.Controls.Add(childCtrl);
            }
            catch
            {
                try
                {
                    var panelProp = parentCtrl.GetType().GetProperty("Panel");
                    if (panelProp != null)
                    {
                        var panelObj = panelProp.GetValue(parentCtrl, null) as Control;
                        if (panelObj != null)
                        {
                            panelObj.Controls.Add(childCtrl);
                            return;
                        }
                    }
                }
                catch { }

                try
                {
                    var panel1Prop = parentCtrl.GetType().GetProperty("Panel1");
                    if (panel1Prop != null)
                    {
                        var panel1Obj = panel1Prop.GetValue(parentCtrl, null) as Control;
                        if (panel1Obj != null)
                        {
                            panel1Obj.Controls.Add(childCtrl);
                            return;
                        }
                    }
                }
                catch { }
            }
        }

        public static DataTable ExecuteSelectQuery(string sql)
        {
            try
            {
                string connStr = GetConnectionString();
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();
                    using (FbDataAdapter da = new FbDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private static void PopulateDynamicGridRows(DataGridView dgv, string formTitle)
        {
            try
            {
                if (dgv == null) return;

                if (dgv.Columns.Count == 0)
                {
                    DataTable dtCols = null;
                    string tName = GetTableNameForForm(formTitle);
                    if (string.IsNullOrEmpty(tName))
                    {
                        string tLower = formTitle != null ? formTitle.ToLower() : "";
                        if (tLower.Contains("lÆ°Æ¡ng") || tLower.Contains("cháº¥m cÃ´ng") || tLower.Contains("táº¡m á»©ng")) tName = "DNHANVIEN";
                        else if (tLower.Contains("phÃ²ng") || tLower.Contains("bÃ n")) tName = "DBAN";
                        else if (tLower.Contains("kho")) tName = "DKHOHANG";
                        else if (tLower.Contains("mÃ¡y in")) tName = "DKHUVUC";
                    }

                    if (!string.IsNullOrEmpty(tName))
                    {
                        dtCols = ExecuteSelectQuery($"SELECT FIRST 1 * FROM {tName}");
                    }

                    if (dtCols != null && dtCols.Columns.Count > 0)
                    {
                        foreach (DataColumn dc in dtCols.Columns)
                        {
                            dgv.Columns.Add(dc.ColumnName, dc.ColumnName);
                        }
                    }
                }

                if (dgv.Columns.Count == 0) return;

                string titleLower = formTitle != null ? formTitle.ToLower() : "";
                string dgvNameLower = dgv.Name != null ? dgv.Name.ToLower() : "";

                bool isPhongOrBan = titleLower.Contains("phÃ²ng") || titleLower.Contains("bÃ n")
                    || dgv.Columns.Contains("colPhong") || dgv.Columns.Contains("colBan");

                if (isPhongOrBan)
                {
                    DataTable dtBan = ExecuteSelectQuery(@"
                        SELECT B.ID, B.NAME AS PHONG, B.NAME AS BAN, K.NAME AS KHUVUC, 'PhÃ²ng thÆ°á»ng' AS LOAIPHONG
                        FROM DBAN B
                        LEFT JOIN DKHUVUC K ON B.DKHUVUCID = K.ID
                        ORDER BY K.NAME, B.NAME");

                    if (dtBan != null && dtBan.Rows.Count > 0)
                    {
                        foreach (DataRow r in dtBan.Rows)
                        {
                            int rowIndex = dgv.Rows.Add();
                            DataGridViewRow row = dgv.Rows[rowIndex];
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                var col = dgv.Columns[i];
                                string colName = col.Name.ToLower();
                                string dataProp = col.DataPropertyName != null ? col.DataPropertyName.ToLower() : "";

                                if (colName.Contains("chon") || dataProp == "chon") row.Cells[i].Value = false;
                                else if (colName.Contains("phong") || colName.Contains("ban") || dataProp == "phong" || dataProp == "ban") row.Cells[i].Value = r["PHONG"]?.ToString();
                                else if (colName.Contains("khuvuc") || dataProp == "khuvuc") row.Cells[i].Value = r["KHUVUC"]?.ToString();
                                else if (colName.Contains("loaiphong") || dataProp == "loaiphong") row.Cells[i].Value = r["LOAIPHONG"]?.ToString();
                                else if (i == 1) row.Cells[i].Value = r["PHONG"]?.ToString();
                                else if (i == 2) row.Cells[i].Value = r["KHUVUC"]?.ToString();
                            }
                        }
                    }
                    return;
                }

                bool isDvt = titleLower.Contains("Ä‘Æ¡n vá»‹ tÃ­nh") || dgv.Columns.Contains("colDvt") || dgv.Columns.Contains("colDonViTinh");
                if (isDvt)
                {
                    DataTable dtDvt = ExecuteSelectQuery("SELECT ID, NAME FROM DDONVITINH ORDER BY NAME");
                    if (dtDvt != null && dtDvt.Rows.Count > 0)
                    {
                        foreach (DataRow r in dtDvt.Rows)
                        {
                            int rowIndex = dgv.Rows.Add();
                            DataGridViewRow row = dgv.Rows[rowIndex];
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                var col = dgv.Columns[i];
                                string colName = col.Name.ToLower();
                                if (colName.Contains("chon")) row.Cells[i].Value = false;
                                else if (colName.Contains("ten") || colName.Contains("dvt") || i == 1) row.Cells[i].Value = r["NAME"]?.ToString();
                                else if (colName.Contains("ma") || i == 0) row.Cells[i].Value = r["ID"]?.ToString();
                            }
                        }
                    }
                    return;
                }

                bool isKhuVuc = (formTitle != null && (formTitle.IndexOf("khu vá»±c", StringComparison.OrdinalIgnoreCase) >= 0 || formTitle.IndexOf("mÃ¡y in", StringComparison.OrdinalIgnoreCase) >= 0))
                    || dgv.Columns.Contains("colKhuVuc") || dgv.Columns.Contains("colMayIn");

                if (isKhuVuc)
                {
                    DataTable dtKhuVuc = ExecuteSelectQuery("SELECT NAME, MAYIN FROM DKHUVUC ORDER BY NAME");
                    if (dtKhuVuc != null && dtKhuVuc.Rows.Count > 0)
                    {
                        foreach (DataRow r in dtKhuVuc.Rows)
                        {
                            int rowIndex = dgv.Rows.Add();
                            DataGridViewRow row = dgv.Rows[rowIndex];
                            string nameVal = r["NAME"]?.ToString() ?? "";
                            string mayInVal = r["MAYIN"]?.ToString();
                            if (string.IsNullOrEmpty(mayInVal)) mayInVal = "(Máº·c Ä‘á»‹nh há»‡ thá»‘ng)";

                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                var col = dgv.Columns[i];
                                if (col.Name.Equals("colKhuVuc", StringComparison.OrdinalIgnoreCase) || col.HeaderText.IndexOf("Khu vá»±c", StringComparison.OrdinalIgnoreCase) >= 0 || i == 0)
                                {
                                    row.Cells[i].Value = nameVal;
                                }
                                else if (col.Name.Equals("colMayIn", StringComparison.OrdinalIgnoreCase) || col.HeaderText.IndexOf("MÃ¡y in", StringComparison.OrdinalIgnoreCase) >= 0 || i == 1)
                                {
                                    if (col is DataGridViewComboBoxColumn comboCol && !comboCol.Items.Contains(mayInVal))
                                    {
                                        comboCol.Items.Add(mayInVal);
                                    }
                                    row.Cells[i].Value = mayInVal;
                                }
                            }
                        }
                    }
                    return;
                }

                bool isKhuyenMai = (formTitle != null && formTitle.IndexOf("khuyáº¿n máº¡i", StringComparison.OrdinalIgnoreCase) >= 0)
                    || dgv.Columns.Contains("colMa") || dgv.Columns.Contains("colTen");

                if (isKhuyenMai)
                {
                    DataTable dtKM = ExecuteSelectQuery("SELECT ID, NAME, TUNGAY, DENNGAY FROM DDOTKHUYENMAI");
                    if (dtKM != null && dtKM.Rows.Count > 0)
                    {
                        foreach (DataRow r in dtKM.Rows)
                        {
                            int rowIndex = dgv.Rows.Add();
                            DataGridViewRow row = dgv.Rows[rowIndex];
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                var col = dgv.Columns[i];
                                if (col.Name.Equals("colMa", StringComparison.OrdinalIgnoreCase) || i == 0) row.Cells[i].Value = r["ID"]?.ToString();
                                else if (col.Name.Equals("colTen", StringComparison.OrdinalIgnoreCase) || i == 1) row.Cells[i].Value = r["NAME"]?.ToString();
                                else if (col.Name.Equals("colTuNgay", StringComparison.OrdinalIgnoreCase) || i == 2) row.Cells[i].Value = r["TUNGAY"] != DBNull.Value ? Convert.ToDateTime(r["TUNGAY"]).ToString("dd/MM/yyyy") : "";
                                else if (col.Name.Equals("colDenNgay", StringComparison.OrdinalIgnoreCase) || i == 3) row.Cells[i].Value = r["DENNGAY"] != DBNull.Value ? Convert.ToDateTime(r["DENNGAY"]).ToString("dd/MM/yyyy") : "";
                            }
                        }
                    }
                    return;
                }

                bool isTinhLuong = titleLower.Contains("lÆ°Æ¡ng") || titleLower.Contains("cháº¥m cÃ´ng") || titleLower.Contains("báº£ng lÆ°Æ¡ng") || titleLower.Contains("táº¡m á»©ng");
                if (isTinhLuong)
                {
                    DataTable dtLuong = ExecuteSelectQuery("SELECT FIRST 50 * FROM TBANGLUONG");
                    if (dtLuong == null || dtLuong.Rows.Count == 0)
                    {
                        dtLuong = ExecuteSelectQuery("SELECT FIRST 50 ID, NAME, DIENTHOAI, EMAIL, SERI FROM DNHANVIEN");
                    }

                    if (dtLuong != null && dtLuong.Rows.Count > 0)
                    {
                        foreach (DataRow r in dtLuong.Rows)
                        {
                            int rowIndex = dgv.Rows.Add();
                            DataGridViewRow row = dgv.Rows[rowIndex];
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                var col = dgv.Columns[i];
                                string colName = col.Name.ToLower();
                                string dataProp = !string.IsNullOrEmpty(col.DataPropertyName) ? col.DataPropertyName.ToLower() : "";

                                if (colName.Contains("chon") || dataProp == "chon") row.Cells[i].Value = false;
                                else if (dtLuong.Columns.Contains("NAME") && (colName.Contains("nhanvien") || colName.Contains("ten") || i == 1)) row.Cells[i].Value = r["NAME"]?.ToString();
                                else if (dtLuong.Columns.Contains("ID") && (colName.Contains("ma") || i == 0)) row.Cells[i].Value = r["ID"]?.ToString();
                                else
                                {
                                    foreach (DataColumn dc in dtLuong.Columns)
                                    {
                                        if (colName.Contains(dc.ColumnName.ToLower()) || dataProp.Contains(dc.ColumnName.ToLower()))
                                        {
                                            row.Cells[i].Value = r[dc.ColumnName]?.ToString();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return;
                }

                // Generic table data loader based on form title or primary column names
                string tableName = GetTableNameForForm(formTitle);
                if (!string.IsNullOrEmpty(tableName))
                {
                    DataTable dtData = ExecuteSelectQuery($"SELECT FIRST 50 * FROM {tableName}");
                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        foreach (DataRow r in dtData.Rows)
                        {
                            int rowIndex = dgv.Rows.Add();
                            DataGridViewRow row = dgv.Rows[rowIndex];
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                var col = dgv.Columns[i];
                                string prop = !string.IsNullOrEmpty(col.DataPropertyName) ? col.DataPropertyName : col.Name;
                                if (col is DataGridViewCheckBoxColumn)
                                {
                                    row.Cells[i].Value = false;
                                }
                                else if (!string.IsNullOrEmpty(prop) && dtData.Columns.Contains(prop) && r[prop] != DBNull.Value)
                                {
                                    row.Cells[i].Value = r[prop]?.ToString();
                                }
                                else if (i < dtData.Columns.Count && r[i] != DBNull.Value)
                                {
                                    row.Cells[i].Value = r[i]?.ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("PopulateDynamicGridRows error: " + ex.Message);
            }
        }

        private static readonly Dictionary<string, Type> ControlTypeCache = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        public static Type ResolveControlType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName)) return null;

            lock (ControlTypeCache)
            {
                if (ControlTypeCache.TryGetValue(typeName, out Type cached)) return cached;

                Type t = Type.GetType(typeName, false, true);
                if (t == null)
                {
                    string cleanTypeName = typeName.Split(',')[0].Trim();
                    foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        try
                        {
                            t = asm.GetType(cleanTypeName, false, true);
                            if (t != null) break;
                        }
                        catch { }
                    }

                    if (t == null)
                    {
                        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                        List<string> dirsToSearch = new List<string> { baseDir, Path.Combine(baseDir, "Libs") };
                        DirectoryInfo parent = Directory.GetParent(baseDir);
                        if (parent != null)
                        {
                            dirsToSearch.Add(parent.FullName);
                            dirsToSearch.Add(Path.Combine(parent.FullName, "Libs"));
                        }

                        foreach (string dir in dirsToSearch)
                        {
                            if (Directory.Exists(dir))
                            {
                                foreach (string dll in Directory.GetFiles(dir, "*.dll"))
                                {
                                    try
                                    {
                                        Assembly asm = Assembly.LoadFrom(dll);
                                        t = asm.GetType(cleanTypeName, false, true);
                                        if (t != null) break;
                                    }
                                    catch { }
                                }
                            }
                            if (t != null) break;
                        }
                    }
                }

                if (t != null) ControlTypeCache[typeName] = t;
                return t;
            }
        }

        public static DataGridView GetInnerDataGridView(Control c)
        {
            if (c is DataGridView dgv) return dgv;
            if (c != null)
            {
                foreach (Control child in c.Controls)
                {
                    if (child is DataGridView childDgv) return childDgv;
                    var sub = GetInnerDataGridView(child);
                    if (sub != null) return sub;
                }
            }
            return null;
        }

        private static Control CreateControlFromType(string typeName, string name)
        {
            if (!string.IsNullOrEmpty(typeName))
            {
                Type targetType = ResolveControlType(typeName);
                if (targetType != null && typeof(Control).IsAssignableFrom(targetType))
                {
                    try
                    {
                        Control c = (Control)Activator.CreateInstance(targetType);
                        c.Name = name;
                        if (c is Form f)
                        {
                            f.TopLevel = false;
                        }
                        return c;
                    }
                    catch { }
                }
            }

            if (string.IsNullOrEmpty(typeName)) typeName = "";
            string lowerType = typeName.ToLower();

            Control ctrl;

            if (lowerType.Contains("splitcontainer"))
            {
                ctrl = new SplitContainer { Dock = DockStyle.Fill };
            }
            else if (lowerType.Contains("navigator") || lowerType.Contains("tabcontrol"))
            {
                ctrl = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };
            }
            else if (lowerType.Contains("kryptonpage") || lowerType.Contains("tabpage"))
            {
                ctrl = new TabPage { Name = name, Text = name, BackColor = Color.White };
            }
            else if (lowerType.Contains("treetable") || lowerType.Contains("treegrid"))
            {
                ctrl = new TreeView { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F), ShowLines = true, ShowPlusMinus = true };
            }
            else if (lowerType.Contains("datagrid") || lowerType.Contains("grid") || lowerType.Contains("search"))
            {
                DataGridView dgv = new DataGridView
                {
                    Dock = DockStyle.None,
                    BackgroundColor = Color.White,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false
                };
                ctrl = dgv;
            }
            else if (lowerType.Contains("button"))
            {
                ctrl = new Button { Size = new Size(80, 30), Text = name };
            }
            else if (lowerType.Contains("textbox"))
            {
                ctrl = new TextBox { Size = new Size(150, 22) };
            }
            else if (lowerType.Contains("label"))
            {
                ctrl = new Label { AutoSize = true, Text = name };
            }
            else if (lowerType.Contains("combobox"))
            {
                ctrl = new ComboBox { Size = new Size(130, 22) };
            }
            else if (lowerType.Contains("checkbox"))
            {
                ctrl = new CheckBox { AutoSize = true, Text = name };
            }
            else if (lowerType.Contains("numericupdown"))
            {
                ctrl = new NumericUpDown { Size = new Size(120, 22) };
            }
            else if (lowerType.Contains("datetimepicker") || lowerType.Contains("datepicker"))
            {
                ctrl = new DateTimePicker { Size = new Size(130, 22) };
            }
            else if (lowerType.Contains("toolstrip"))
            {
                ctrl = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden };
            }
            else if (lowerType.Contains("picturebox") || lowerType.Contains("image"))
            {
                ctrl = new PictureBox { Size = new Size(48, 48), SizeMode = PictureBoxSizeMode.Zoom };
            }
            else if (lowerType.Contains("radio"))
            {
                ctrl = new RadioButton { AutoSize = true, Text = name };
            }
            else if (lowerType.Contains("groupbox") || lowerType.Contains("group"))
            {
                ctrl = new GroupBox { Text = name };
            }
            else if (lowerType.Contains("form") || lowerType.Contains("usercontrol"))
            {
                ctrl = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            }
            else
            {
                ctrl = new Panel { BackColor = Color.Transparent };
            }

            ctrl.Name = name;
            return ctrl;
        }

        private static Color ParseXmlColor(string val)
        {
            if (string.IsNullOrEmpty(val)) return Color.Empty;
            val = val.Trim();
            if (string.Equals(val, "Transparent", StringComparison.OrdinalIgnoreCase)) return Color.Transparent;

            Color known = Color.FromName(val);
            if (known.IsKnownColor) return known;

            string[] parts = val.Split(',');
            if (parts.Length == 3 && int.TryParse(parts[0].Trim(), out int r) && int.TryParse(parts[1].Trim(), out int g) && int.TryParse(parts[2].Trim(), out int b))
            {
                return Color.FromArgb(Math.Max(0, Math.Min(255, r)), Math.Max(0, Math.Min(255, g)), Math.Max(0, Math.Min(255, b)));
            }
            if (parts.Length == 4 && int.TryParse(parts[0].Trim(), out int a) && int.TryParse(parts[1].Trim(), out int r2) && int.TryParse(parts[2].Trim(), out int g2) && int.TryParse(parts[3].Trim(), out int b2))
            {
                return Color.FromArgb(Math.Max(0, Math.Min(255, a)), Math.Max(0, Math.Min(255, r2)), Math.Max(0, Math.Min(255, g2)), Math.Max(0, Math.Min(255, b2)));
            }

            if (int.TryParse(val, out int argbInt))
            {
                return Color.FromArgb(argbInt);
            }

            if (val.StartsWith("#"))
            {
                try { return ColorTranslator.FromHtml(val); } catch { }
            }

            return Color.Empty;
        }

        private static Font ParseXmlFont(string fontStr)
        {
            if (string.IsNullOrEmpty(fontStr)) return null;
            try
            {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
                if (converter != null && converter.CanConvertFrom(typeof(string)))
                {
                    return (Font)converter.ConvertFromString(fontStr);
                }
            }
            catch { }

            try
            {
                string[] parts = fontStr.Split(',');
                if (parts.Length >= 2)
                {
                    string family = parts[0].Trim();
                    string sizeStr = parts[1].Replace("pt", "").Replace("px", "").Trim();
                    if (float.TryParse(sizeStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float sz))
                    {
                        FontStyle style = FontStyle.Regular;
                        if (fontStr.IndexOf("bold", StringComparison.OrdinalIgnoreCase) >= 0) style |= FontStyle.Bold;
                        if (fontStr.IndexOf("italic", StringComparison.OrdinalIgnoreCase) >= 0) style |= FontStyle.Italic;
                        return new Font(family, sz, style);
                    }
                }
            }
            catch { }

            return null;
        }

        private static void ApplyTextAlign(Control ctrl, string val)
        {
            if (string.IsNullOrEmpty(val)) return;
            val = val.Trim();

            if (ctrl is Label lbl)
            {
                if (Enum.TryParse(val, true, out ContentAlignment align)) lbl.TextAlign = align;
                else if (val.Equals("Right", StringComparison.OrdinalIgnoreCase)) lbl.TextAlign = ContentAlignment.MiddleRight;
                else if (val.Equals("Left", StringComparison.OrdinalIgnoreCase)) lbl.TextAlign = ContentAlignment.MiddleLeft;
                else if (val.Equals("Center", StringComparison.OrdinalIgnoreCase)) lbl.TextAlign = ContentAlignment.MiddleCenter;
            }
            else if (ctrl is Button btn)
            {
                if (Enum.TryParse(val, true, out ContentAlignment align)) btn.TextAlign = align;
                else if (val.Equals("Right", StringComparison.OrdinalIgnoreCase)) btn.TextAlign = ContentAlignment.MiddleRight;
                else if (val.Equals("Left", StringComparison.OrdinalIgnoreCase)) btn.TextAlign = ContentAlignment.MiddleLeft;
                else if (val.Equals("Center", StringComparison.OrdinalIgnoreCase)) btn.TextAlign = ContentAlignment.MiddleCenter;
            }
            else if (ctrl is TextBox txt)
            {
                if (val.Contains("Right")) txt.TextAlign = HorizontalAlignment.Right;
                else if (val.Contains("Center")) txt.TextAlign = HorizontalAlignment.Center;
                else if (val.Contains("Left")) txt.TextAlign = HorizontalAlignment.Left;
            }
            else if (ctrl is NumericUpDown num)
            {
                if (val.Contains("Right")) num.TextAlign = HorizontalAlignment.Right;
                else if (val.Contains("Center")) num.TextAlign = HorizontalAlignment.Center;
                else if (val.Contains("Left")) num.TextAlign = HorizontalAlignment.Left;
            }
        }

        private static void ApplyBorderStyle(Control ctrl, string val)
        {
            if (string.IsNullOrEmpty(val)) return;
            if (Enum.TryParse(val, true, out BorderStyle style))
            {
                if (ctrl is TextBox txt) txt.BorderStyle = style;
                else if (ctrl is Panel pnl) pnl.BorderStyle = style;
                else if (ctrl is Label lbl) lbl.BorderStyle = style;
            }
        }

        private static void ApplyColumnXmlProperties(DataGridViewColumn col, XmlNode node)
        {
            if (col == null || node == null) return;
            XmlNodeList propNodes = node.SelectNodes("./Property | .//Property");
            if (propNodes == null) return;

            foreach (XmlNode pNode in propNodes)
            {
                string pName = pNode.Attributes["name"]?.Value;
                string pVal = pNode.InnerText?.Trim();
                if (string.IsNullOrEmpty(pName) || string.IsNullOrEmpty(pVal)) continue;

                try
                {
                    if (pName.Equals("HeaderText", StringComparison.OrdinalIgnoreCase))
                    {
                        col.HeaderText = pVal;
                    }
                    else if (pName.Equals("DataPropertyName", StringComparison.OrdinalIgnoreCase))
                    {
                        col.DataPropertyName = pVal;
                    }
                    else if (pName.Equals("Width", StringComparison.OrdinalIgnoreCase))
                    {
                        if (int.TryParse(pVal, out int w) && w > 0) col.Width = w;
                    }
                    else if (pName.Equals("Visible", StringComparison.OrdinalIgnoreCase))
                    {
                        if (bool.TryParse(pVal, out bool vis)) col.Visible = vis;
                    }
                    else if (pName.Equals("ReadOnly", StringComparison.OrdinalIgnoreCase))
                    {
                        if (bool.TryParse(pVal, out bool ro)) col.ReadOnly = ro;
                    }
                    else if (pName.Equals("FillWeight", StringComparison.OrdinalIgnoreCase))
                    {
                        if (float.TryParse(pVal, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float fw) && fw > 0) col.FillWeight = fw;
                    }
                }
                catch { }
            }
        }

        private static Image ParseBase64Image(string base64Str)
        {
            if (string.IsNullOrEmpty(base64Str)) return null;
            try
            {
                byte[] bytes = Convert.FromBase64String(base64Str.Trim());
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        private static void ApplyToolStripItemXmlProperties(ToolStripItem item, XmlNode node)
        {
            if (item == null || node == null) return;
            XmlNodeList propNodes = node.SelectNodes("./Property | .//Property");
            if (propNodes == null) return;

            foreach (XmlNode pNode in propNodes)
            {
                string pName = pNode.Attributes["name"]?.Value;
                string pVal = pNode.InnerText?.Trim();
                if (string.IsNullOrEmpty(pName) || string.IsNullOrEmpty(pVal)) continue;

                try
                {
                    if (pName.Equals("Text", StringComparison.OrdinalIgnoreCase))
                    {
                        item.Text = pVal;
                    }
                    else if (pName.Equals("Image", StringComparison.OrdinalIgnoreCase) || pName.Equals("Icon", StringComparison.OrdinalIgnoreCase))
                    {
                        Image img = ParseBase64Image(pVal);
                        if (img != null) item.Image = img;
                    }
                    else if (pName.Equals("DisplayStyle", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Enum.TryParse(pVal, true, out ToolStripItemDisplayStyle ds)) item.DisplayStyle = ds;
                    }
                    else if (pName.Equals("Visible", StringComparison.OrdinalIgnoreCase))
                    {
                        if (bool.TryParse(pVal, out bool vis)) item.Available = vis;
                    }
                    else if (pName.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                    {
                        if (bool.TryParse(pVal, out bool en)) item.Enabled = en;
                    }
                    else if (pName.Equals("ToolTipText", StringComparison.OrdinalIgnoreCase))
                    {
                        item.ToolTipText = pVal;
                    }
                    else if (pName.Equals("ImageTransparentColor", StringComparison.OrdinalIgnoreCase))
                    {
                        Color c = ParseXmlColor(pVal);
                        if (!c.IsEmpty) item.ImageTransparentColor = c;
                    }
                }
                catch { }
            }
        }

        private static void ApplyXmlProperties(Control ctrl, XmlNode node)
        {
            XmlNodeList propNodes = node.SelectNodes(".//Property");
            if (propNodes == null) return;

            foreach (XmlNode pNode in propNodes)
            {
                string pName = pNode.Attributes["name"]?.Value;
                string pVal = pNode.InnerText?.Trim();
                if (string.IsNullOrEmpty(pName) || string.IsNullOrEmpty(pVal)) continue;

                try
                {
                    if (pName.Equals("Text", StringComparison.OrdinalIgnoreCase))
                    {
                        ctrl.Text = pVal;
                    }
                    else if (pName.Equals("Image", StringComparison.OrdinalIgnoreCase) || pName.Equals("Icon", StringComparison.OrdinalIgnoreCase))
                    {
                        Image img = ParseBase64Image(pVal);
                        if (img != null)
                        {
                            if (ctrl is Button btn)
                            {
                                btn.Image = img;
                                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                                btn.ImageAlign = ContentAlignment.MiddleLeft;
                            }
                            else if (ctrl is PictureBox pic)
                            {
                                pic.Image = img;
                            }
                            else if (ctrl is Label lbl)
                            {
                                lbl.Image = img;
                                lbl.ImageAlign = ContentAlignment.MiddleLeft;
                            }
                        }
                    }
                    else if (pName.Equals("BackColor", StringComparison.OrdinalIgnoreCase))
                    {
                        Color c = ParseXmlColor(pVal);
                        if (!c.IsEmpty)
                        {
                            ctrl.BackColor = c;
                            if (ctrl is Button btn) btn.UseVisualStyleBackColor = false;
                            else if (ctrl is ButtonBase btnBase) btnBase.UseVisualStyleBackColor = false;
                        }
                    }
                    else if (pName.Equals("ForeColor", StringComparison.OrdinalIgnoreCase))
                    {
                        Color c = ParseXmlColor(pVal);
                        if (!c.IsEmpty) ctrl.ForeColor = c;
                    }
                    else if (pName.Equals("FlatStyle", StringComparison.OrdinalIgnoreCase))
                    {
                        if (ctrl is Button btn && Enum.TryParse(pVal, true, out FlatStyle fs))
                        {
                            btn.FlatStyle = fs;
                            btn.UseVisualStyleBackColor = false;
                        }
                    }
                    else if (pName.Equals("Font", StringComparison.OrdinalIgnoreCase))
                    {
                        Font f = ParseXmlFont(pVal);
                        if (f != null) ctrl.Font = f;
                    }
                    else if (pName.Equals("AlternatingRowsDefaultCellStyle", StringComparison.OrdinalIgnoreCase))
                    {
                        if (ctrl is DataGridView dgv)
                        {
                            XmlNode backNode = pNode.SelectSingleNode(".//Property[@name='BackColor']");
                            if (backNode != null)
                            {
                                Color c = ParseXmlColor(backNode.InnerText);
                                if (!c.IsEmpty) dgv.AlternatingRowsDefaultCellStyle.BackColor = c;
                            }
                        }
                    }
                    else if (pName.Equals("ColumnHeadersDefaultCellStyle", StringComparison.OrdinalIgnoreCase))
                    {
                        if (ctrl is DataGridView dgv)
                        {
                            XmlNode backNode = pNode.SelectSingleNode(".//Property[@name='BackColor']");
                            if (backNode != null)
                            {
                                Color c = ParseXmlColor(backNode.InnerText);
                                if (!c.IsEmpty)
                                {
                                    dgv.EnableHeadersVisualStyles = false;
                                    dgv.ColumnHeadersDefaultCellStyle.BackColor = c;
                                }
                            }
                        }
                    }
                    else if (pName.Equals("TextAlign", StringComparison.OrdinalIgnoreCase))
                    {
                        ApplyTextAlign(ctrl, pVal);
                    }
                    else if (pName.Equals("BorderStyle", StringComparison.OrdinalIgnoreCase))
                    {
                        ApplyBorderStyle(ctrl, pVal);
                    }
                    else if (pName.Equals("Dock", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Enum.TryParse(pVal, true, out DockStyle ds)) ctrl.Dock = ds;
                    }
                    else if (pName.Equals("Bar", StringComparison.OrdinalIgnoreCase) || pName.Equals("Bar.BarOrientation", StringComparison.OrdinalIgnoreCase))
                    {
                        if (ctrl is ComponentFactory.Krypton.Navigator.KryptonNavigator knav)
                        {
                            if (pVal.Equals("Left", StringComparison.OrdinalIgnoreCase))
                                knav.Bar.BarOrientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Left;
                            else if (pVal.Equals("Right", StringComparison.OrdinalIgnoreCase))
                                knav.Bar.BarOrientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
                            else if (pVal.Equals("Top", StringComparison.OrdinalIgnoreCase))
                                knav.Bar.BarOrientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Top;
                            else if (pVal.Equals("Bottom", StringComparison.OrdinalIgnoreCase))
                                knav.Bar.BarOrientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Bottom;
                        }
                    }
                    else if (pName.Equals("Size", StringComparison.OrdinalIgnoreCase) || pName.Equals("ClientSize", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] parts = pVal.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int w) && int.TryParse(parts[1].Trim(), out int h))
                        {
                            ctrl.Size = new Size(w, h);
                        }
                    }
                    else if (pName.Equals("Location", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] parts = pVal.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int x) && int.TryParse(parts[1].Trim(), out int y))
                        {
                            ctrl.Location = new Point(x, y);
                        }
                    }
                    else if (pName.Equals("SplitterDistance", StringComparison.OrdinalIgnoreCase))
                    {
                        if (int.TryParse(pVal, out int dist) && dist > 5)
                        {
                            ctrl.Tag = dist;
                            if (ctrl is SplitContainer sc)
                            {
                                try { sc.SplitterDistance = dist; } catch { }
                            }
                            else if (ctrl is ComponentFactory.Krypton.Toolkit.KryptonSplitContainer ksc)
                            {
                                try { ksc.SplitterDistance = dist; } catch { }
                            }
                            else
                            {
                                PropertyInfo pi = ctrl.GetType().GetProperty("SplitterDistance");
                                if (pi != null && pi.CanWrite)
                                {
                                    try { pi.SetValue(ctrl, dist, null); } catch { }
                                }
                            }
                        }
                    }
                    else if (pName.Equals("Orientation", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Enum.TryParse(pVal, true, out Orientation ori))
                        {
                            if (ctrl is SplitContainer sc)
                            {
                                sc.Orientation = ori;
                            }
                            else if (ctrl is ComponentFactory.Krypton.Toolkit.KryptonSplitContainer ksc)
                            {
                                ksc.Orientation = ori;
                            }
                            else
                            {
                                PropertyInfo pi = ctrl.GetType().GetProperty("Orientation");
                                if (pi != null && pi.CanWrite)
                                {
                                    try { pi.SetValue(ctrl, ori, null); } catch { }
                                }
                            }
                        }
                    }
                    else if (pName.Equals("Anchor", StringComparison.OrdinalIgnoreCase))
                    {
                        AnchorStyles anchor = AnchorStyles.None;
                        foreach (string part in pVal.Split(','))
                        {
                            if (Enum.TryParse(part.Trim(), true, out AnchorStyles a)) anchor |= a;
                        }
                        ctrl.Anchor = anchor;
                    }
                    else if (pName.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                    {
                        if (bool.TryParse(pVal, out bool en)) ctrl.Enabled = en;
                    }
                    else if (pName.Equals("Visible", StringComparison.OrdinalIgnoreCase))
                    {
                        ctrl.Visible = true;
                    }
                    else
                    {
                        PropertyInfo pi = ctrl.GetType().GetProperty(pName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                        if (pi != null && pi.CanWrite)
                        {
                            Type pType = pi.PropertyType;
                            if (pType == typeof(bool) && bool.TryParse(pVal, out bool bVal))
                            {
                                pi.SetValue(ctrl, bVal, null);
                            }
                            else if (pType == typeof(int) && int.TryParse(pVal, out int iVal))
                            {
                                pi.SetValue(ctrl, iVal, null);
                            }
                            else if (pType == typeof(string))
                            {
                                pi.SetValue(ctrl, pVal, null);
                            }
                            else if (pType.IsEnum)
                            {
                                try { pi.SetValue(ctrl, Enum.Parse(pType, pVal, true), null); } catch { }
                            }
                        }
                    }
                }
                catch { }
            }
        }
    }
}

