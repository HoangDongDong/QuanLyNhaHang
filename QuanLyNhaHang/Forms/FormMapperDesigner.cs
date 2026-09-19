using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.Forms
{
    public class MappingItem
    {
        public string FieldName { get; set; }
        public string Caption { get; set; }
        public string ControlName { get; set; }
        public bool AllowEmpty { get; set; } = true;
        public bool AllowDuplicate { get; set; } = true;
    }

    public partial class FormMapperDesigner : Form
    {
        private readonly FormModel _model;
        private readonly Form _hostedForm;
        private DataGridView _dgv;
        private List<MappingItem> _mappingList = new List<MappingItem>();

        public FormMapperDesigner(FormModel model, Form hostedForm = null)
        {
            _model = model;
            _hostedForm = hostedForm;
            InitializeComponent();
            LoadMappingData();
        }

        private void InitializeComponent()
        {
            this.Text = "Mapper Designer";
            this.Size = new Size(760, 520);
            this.MinimumSize = new Size(650, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowIcon = false;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Top Header
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 38,
                BackColor = Color.White,
                Padding = new Padding(12, 8, 12, 6)
            };
            Label lblTitle = new Label
            {
                Text = "Thiết kế các ánh xạ control vào trường trên cơ sở dữ liệu",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlHeader.Controls.Add(lblTitle);

            // Bottom Bar
            Panel pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 48,
                BackColor = Color.FromArgb(238, 240, 244),
                Padding = new Padding(10, 8, 10, 8)
            };

            Button btnGenerateControls = new Button
            {
                Text = "Sinh control",
                Size = new Size(95, 28),
                Location = new Point(10, 10),
                FlatStyle = FlatStyle.System
            };
            btnGenerateControls.Click += BtnGenerateControls_Click;

            Button btnDelete = new Button
            {
                Text = "Xóa",
                Size = new Size(80, 28),
                Location = new Point(112, 10),
                FlatStyle = FlatStyle.System
            };
            btnDelete.Click += BtnDelete_Click;

            Button btnSelectField = new Button
            {
                Text = "Chọn field",
                Size = new Size(95, 28),
                Location = new Point(199, 10),
                FlatStyle = FlatStyle.System
            };
            btnSelectField.Click += BtnSelectField_Click;

            Button btnCancel = new Button
            {
                Text = "Thoát",
                Size = new Size(85, 28),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(pnlBottom.Width - 95, 10),
                FlatStyle = FlatStyle.System,
                DialogResult = DialogResult.Cancel
            };
            btnCancel.Click += (s, e) => this.Close();

            Button btnAccept = new Button
            {
                Text = "Chấp nhận",
                Size = new Size(95, 28),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(pnlBottom.Width - 198, 10),
                FlatStyle = FlatStyle.System
            };
            btnAccept.Click += BtnAccept_Click;

            pnlBottom.Controls.Add(btnGenerateControls);
            pnlBottom.Controls.Add(btnDelete);
            pnlBottom.Controls.Add(btnSelectField);
            pnlBottom.Controls.Add(btnAccept);
            pnlBottom.Controls.Add(btnCancel);

            // Grid
            _dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = true,
                AllowUserToDeleteRows = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersWidth = 24,
                BackgroundColor = Color.White,
                GridColor = Color.FromArgb(220, 224, 230),
                BorderStyle = BorderStyle.None
            };
            _dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);

            DataGridViewTextBoxColumn colField = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FieldName",
                HeaderText = "Trường dữ liệu",
                Width = 160
            };
            DataGridViewTextBoxColumn colCap = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Caption",
                HeaderText = "Tiêu đề",
                Width = 140
            };
            DataGridViewTextBoxColumn colCtrl = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ControlName",
                HeaderText = "Control",
                Width = 180
            };
            DataGridViewCheckBoxColumn colEmp = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "AllowEmpty",
                HeaderText = "Trống",
                Width = 60
            };
            DataGridViewCheckBoxColumn colDup = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "AllowDuplicate",
                HeaderText = "Trùng",
                Width = 60
            };

            _dgv.Columns.AddRange(new DataGridViewColumn[] { colField, colCap, colCtrl, colEmp, colDup });

            this.Controls.Add(_dgv);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlBottom);
        }

        private void LoadMappingData()
        {
            _mappingList.Clear();
            string tableId = string.IsNullOrEmpty(_model?.STableDescId) ? "TDONHANG" : _model.STableDescId;

            Dictionary<string, string> captionMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();

                    // 1. Fetch captions from SCOLUMN for tableId
                    string sqlCol = @"SELECT S.NAME, S.CAPTION 
                                     FROM SCOLUMN S 
                                     WHERE UPPER(TRIM(S.STABLEDESCID)) = UPPER(TRIM(@tid))
                                        OR UPPER(TRIM(S.STABLEDESCID)) IN (SELECT UPPER(TRIM(T.ID)) FROM STABLEDESC T WHERE UPPER(TRIM(T.NAME)) = UPPER(TRIM(@tid)))";
                    using (FbCommand cmd = new FbCommand(sqlCol, conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", tableId);
                        using (FbDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string fname = r["NAME"]?.ToString()?.Trim();
                                string cap = r["CAPTION"]?.ToString()?.Trim();
                                if (!string.IsNullOrEmpty(fname) && !captionMap.ContainsKey(fname))
                                {
                                    captionMap[fname] = cap ?? "";
                                }
                            }
                        }
                    }

                    // 2. Fetch ALL database columns from Firebird RDB$RELATION_FIELDS
                    string sqlRdb = @"SELECT TRIM(RDB$FIELD_NAME) AS FIELD_NAME
                                      FROM RDB$RELATION_FIELDS
                                      WHERE UPPER(TRIM(RDB$RELATION_NAME)) = UPPER(TRIM(@tid))
                                      ORDER BY RDB$FIELD_POSITION ASC";
                    using (FbCommand cmdRdb = new FbCommand(sqlRdb, conn))
                    {
                        cmdRdb.Parameters.AddWithValue("@tid", tableId);
                        using (FbDataReader rRdb = cmdRdb.ExecuteReader())
                        {
                            while (rRdb.Read())
                            {
                                string fname = rRdb["FIELD_NAME"]?.ToString()?.Trim();
                                if (!string.IsNullOrEmpty(fname) && !_mappingList.Any(x => x.FieldName.Equals(fname, StringComparison.OrdinalIgnoreCase)))
                                {
                                    captionMap.TryGetValue(fname, out string cap);
                                    _mappingList.Add(new MappingItem
                                    {
                                        FieldName = fname,
                                        Caption = cap ?? GetKnownCaption(fname),
                                        ControlName = FindMatchingControlName(fname),
                                        AllowEmpty = !fname.Equals("NGAY", StringComparison.OrdinalIgnoreCase) && !fname.EndsWith("ID", StringComparison.OrdinalIgnoreCase),
                                        AllowDuplicate = true
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load SCOLUMN/RDB error: " + ex.Message);
            }

            // Fallback list of full TDONHANG / default fields if DB query returned 0 rows
            if (_mappingList.Count == 0)
            {
                var fullTemplate = new (string fname, string cap)[]
                {
                    ("NAME", "Số HĐ"),
                    ("NGAY", "Ngày"),
                    ("DKHACHHANGID", "K. hàng (F6)"),
                    ("GIAMTHEOTIEN", ""),
                    ("LOAI", ""),
                    ("TONGCONG", "Tổng cộng"),
                    ("PHIVANCHUYEN", "Phí vận chuyển"),
                    ("TIENGIAMGIA", "%"),
                    ("TILEGIAMGIA", "Giảm giá"),
                    ("TIENTHUE", "%"),
                    ("TILETHUE", "Tỉ lệ thuế"),
                    ("TIENHANG", "Tiền hàng"),
                    ("DKHOXUATID", "Kho xuất"),
                    ("DNHANVIENXUATID", "Nhân viên"),
                    ("DIENGIAI", "Diễn giải"),
                    ("LOAIGIA", ""),
                    ("GIAOHANG", "Đc giao hàng"),
                    ("NOTE", "Ghi chú"),
                    ("DOITRA", "Đổi trả"),
                    ("TDATHANGID", ""),
                    ("DNHANVIENGIAOID", ""),
                    ("TRICHNHANVIEN", "Trích nhân viên"),
                    ("DCUAHANGID", ""),
                    ("USERCREATEDID", ""),
                    ("USERMODIFIEDID", ""),
                    ("STATUS", ""),
                    ("AUTOID", ""),
                    ("TIMECREATED", ""),
                    ("TIMEMODIFIED", "")
                };

                foreach (var t in fullTemplate)
                {
                    _mappingList.Add(new MappingItem
                    {
                        FieldName = t.fname,
                        Caption = t.cap,
                        ControlName = FindMatchingControlName(t.fname),
                        AllowEmpty = !t.fname.Equals("NGAY", StringComparison.OrdinalIgnoreCase) && !t.fname.EndsWith("ID", StringComparison.OrdinalIgnoreCase),
                        AllowDuplicate = true
                    });
                }
            }

            BindingSource bs = new BindingSource { DataSource = _mappingList };
            _dgv.DataSource = bs;
        }

        private string GetKnownCaption(string fname)
        {
            if (string.IsNullOrEmpty(fname)) return "";
            string upper = fname.ToUpper();
            switch (upper)
            {
                case "NAME": return "Số HĐ";
                case "NGAY": return "Ngày";
                case "DKHACHHANGID": return "K. hàng (F6)";
                case "TONGCONG": return "Tổng cộng";
                case "PHIVANCHUYEN": return "Phí vận chuyển";
                case "TIENGIAMGIA": return "%";
                case "TILEGIAMGIA": return "Giảm giá";
                case "TIENTHUE": return "%";
                case "TILETHUE": return "Tỉ lệ thuế";
                case "TIENHANG": return "Tiền hàng";
                case "DKHOXUATID": return "Kho xuất";
                case "DNHANVIENXUATID": return "Nhân viên";
                case "DIENGIAI": return "Diễn giải";
                case "GIAOHANG": return "Đc giao hàng";
                case "NOTE": return "Ghi chú";
                case "DOITRA": return "Đổi trả";
                case "TRICHNHANVIEN": return "Trích nhân viên";
                default: return "";
            }
        }

        private string FindMatchingControlName(string fieldName)
        {
            if (_hostedForm == null || string.IsNullOrEmpty(fieldName)) return AutoGenerateControlName(fieldName);

            string upperField = fieldName.ToUpper();
            foreach (Control c in GetAllControls(_hostedForm))
            {
                if (string.IsNullOrEmpty(c.Name)) continue;
                string cUpper = c.Name.ToUpper();
                if (cUpper.EndsWith(upperField) || cUpper.Contains(upperField))
                {
                    return c.Name;
                }
            }
            return AutoGenerateControlName(fieldName);
        }

        private string AutoGenerateControlName(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) return "";
            string upper = fieldName.ToUpper();
            if (upper == "GIAMTHEOTIEN" || upper == "LOAI" || upper == "LOAIGIA" || upper == "TDATHANGID" ||
                upper == "DCUAHANGID" || upper.StartsWith("USER") || upper.StartsWith("TIME") || upper == "STATUS" || upper == "AUTOID")
                return "";

            if (upper.Contains("NGAY") || upper.Contains("DATE")) return "dt" + fieldName;
            if (upper.EndsWith("ID")) return "lue" + fieldName;
            if (upper.Contains("TONG") || upper.Contains("TIEN") || upper.Contains("PHI") || upper.Contains("LE") || upper.Contains("GIAM") || upper.Contains("THUE") || upper.Contains("DOITRA") || upper.Contains("TRICH")) return "num" + fieldName;
            return "txt" + fieldName;
        }

        private string DeriveFieldNameFromControl(string cName)
        {
            if (cName.StartsWith("txt") || cName.StartsWith("lue") || cName.StartsWith("num")) return cName.Substring(3);
            if (cName.StartsWith("dt")) return cName.Substring(2);
            return cName;
        }

        private IEnumerable<Control> GetAllControls(Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                Control current = stack.Pop();
                yield return current;
                foreach (Control child in current.Controls)
                {
                    stack.Push(child);
                }
            }
        }

        private void BtnGenerateControls_Click(object sender, EventArgs e)
        {
            var targetItems = _mappingList.Where(x => string.IsNullOrEmpty(x.ControlName)).ToList();
            if (targetItems.Count == 0)
            {
                targetItems = _mappingList;
            }

            var genItems = FormGenerateControls.ShowDialog(this, targetItems);
            if (genItems != null && genItems.Count > 0)
            {
                int startY = 40;
                if (_hostedForm != null)
                {
                    foreach (Control c in _hostedForm.Controls)
                    {
                        if (c.Bottom > startY && c.Height < 100) startY = c.Bottom + 6;
                    }
                }

                foreach (var g in genItems)
                {
                    var match = _mappingList.FirstOrDefault(x => x.FieldName.Equals(g.FieldName, StringComparison.OrdinalIgnoreCase));
                    if (match != null)
                    {
                        if (!string.IsNullOrEmpty(g.Caption)) match.Caption = g.Caption;

                        string prefix = "txt";
                        if (g.ControlType == "No1DatePicker") prefix = "dt";
                        else if (g.ControlType == "No1NumericUpDown") prefix = "num";
                        else if (g.ControlType == "No1LookupEdit" || g.ControlType == "No1GridLookup") prefix = "lue";
                        else if (g.ControlType == "No1CheckBox") prefix = "chk";

                        match.ControlName = prefix + match.FieldName;

                        if (_hostedForm != null && _hostedForm.Controls.Find(match.ControlName, true).Length == 0)
                        {
                            Label lbl = new Label
                            {
                                Name = "lbl" + match.FieldName,
                                Text = string.IsNullOrEmpty(match.Caption) ? match.FieldName : match.Caption,
                                Location = new Point(20, startY + 3),
                                AutoSize = true,
                                Font = new Font("Segoe UI", 9F)
                            };

                            Control ctrl;
                            if (g.ControlType == "No1DatePicker")
                            {
                                ctrl = new DateTimePicker { Name = match.ControlName, Format = DateTimePickerFormat.Short, Location = new Point(130, startY), Width = 140, Font = new Font("Segoe UI", 9F) };
                            }
                            else if (g.ControlType == "No1NumericUpDown")
                            {
                                ctrl = new NumericUpDown { Name = match.ControlName, Location = new Point(130, startY), Width = 140, Font = new Font("Segoe UI", 9F) };
                            }
                            else if (g.ControlType == "No1LookupEdit" || g.ControlType == "No1GridLookup" || g.ControlType == "No1ComboBox")
                            {
                                ctrl = new ComboBox { Name = match.ControlName, Location = new Point(130, startY), Width = 160, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };
                            }
                            else if (g.ControlType == "No1CheckBox")
                            {
                                ctrl = new CheckBox { Name = match.ControlName, Text = match.Caption, Location = new Point(130, startY), AutoSize = true, Font = new Font("Segoe UI", 9F) };
                            }
                            else
                            {
                                ctrl = new TextBox { Name = match.ControlName, Location = new Point(130, startY), Width = 180, Font = new Font("Segoe UI", 9F) };
                            }

                            _hostedForm.Controls.Add(lbl);
                            _hostedForm.Controls.Add(ctrl);
                            startY += 30;
                        }
                    }
                }
                _dgv.Refresh();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in _dgv.SelectedRows)
                {
                    if (row.DataBoundItem is MappingItem item)
                    {
                        item.ControlName = "";
                    }
                }
                _dgv.Refresh();
            }
        }

        private void BtnSelectField_Click(object sender, EventArgs e)
        {
            string input = ShowInputDialog("Nhập tên trường dữ liệu mới:", "Thêm trường dữ liệu", "NEW_FIELD");
            if (!string.IsNullOrWhiteSpace(input))
            {
                _mappingList.Add(new MappingItem
                {
                    FieldName = input.Trim().ToUpper(),
                    Caption = input.Trim(),
                    ControlName = AutoGenerateControlName(input.Trim().ToUpper()),
                    AllowEmpty = true,
                    AllowDuplicate = true
                });
                BindingSource bs = new BindingSource { DataSource = _mappingList };
                _dgv.DataSource = bs;
            }
        }

        private string ShowInputDialog(string prompt, string title, string defaultValue)
        {
            Form promptForm = new Form
            {
                Width = 360,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 9F)
            };
            Label lbl = new Label { Left = 16, Top = 16, Text = prompt, AutoSize = true };
            TextBox txt = new TextBox { Left = 16, Top = 40, Width = 312, Text = defaultValue };
            Button btnOk = new Button { Text = "OK", Left = 168, Width = 75, Top = 75, DialogResult = DialogResult.OK, FlatStyle = FlatStyle.System };
            Button btnCancel = new Button { Text = "Hủy", Left = 253, Width = 75, Top = 75, DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.System };
            promptForm.Controls.Add(lbl);
            promptForm.Controls.Add(txt);
            promptForm.Controls.Add(btnOk);
            promptForm.Controls.Add(btnCancel);
            promptForm.AcceptButton = btnOk;
            promptForm.CancelButton = btnCancel;

            return promptForm.ShowDialog() == DialogResult.OK ? txt.Text : null;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static void ShowDialog(FormModel model, Form hostedForm = null)
        {
            using (FormMapperDesigner form = new FormMapperDesigner(model, hostedForm))
            {
                form.ShowDialog();
            }
        }
    }
}
