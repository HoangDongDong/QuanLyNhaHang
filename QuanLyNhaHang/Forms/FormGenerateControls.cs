using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.Forms
{
    public class GenerateControlItem
    {
        public string FieldName { get; set; }
        public string Caption { get; set; }
        public string ControlType { get; set; } = "No1TextBox";
        public bool IsSelected { get; set; } = true;
        public int Index { get; set; }
    }

    public partial class FormGenerateControls : Form
    {
        private DataGridView _dgv;
        private CheckBox _chkSelectAll;
        private List<GenerateControlItem> _itemList = new List<GenerateControlItem>();

        public List<GenerateControlItem> SelectedItems => _itemList.Where(x => x.IsSelected).ToList();

        public FormGenerateControls(List<MappingItem> mappingItems)
        {
            InitializeComponent();
            LoadData(mappingItems);
        }

        private void InitializeComponent()
        {
            this.Text = "Sinh control";
            this.Size = new Size(680, 420);
            this.MinimumSize = new Size(580, 340);
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowIcon = false;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Top Header Panel
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 42,
                BackColor = Color.White,
                Padding = new Padding(12, 10, 12, 8)
            };

            Label lblTitle = new Label
            {
                Text = "Sinh control cho form sửa/nhập",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(12, 11),
                AutoSize = true
            };

            _chkSelectAll = new CheckBox
            {
                Text = "Chọn hết/Không chọn",
                Checked = true,
                AutoSize = true,
                Location = new Point(480, 11),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Font = new Font("Segoe UI", 9F)
            };
            _chkSelectAll.CheckedChanged += ChkSelectAll_CheckedChanged;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(_chkSelectAll);

            // Bottom Bar
            Panel pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 48,
                BackColor = Color.FromArgb(238, 240, 244),
                Padding = new Padding(10, 8, 10, 8)
            };

            Button btnCancel = new Button
            {
                Text = "Hủy bỏ",
                Size = new Size(90, 28),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(pnlBottom.Width - 100, 10),
                FlatStyle = FlatStyle.System,
                DialogResult = DialogResult.Cancel
            };
            btnCancel.Click += (s, e) => this.Close();

            Button btnOk = new Button
            {
                Text = "Sinh control",
                Size = new Size(110, 28),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(pnlBottom.Width - 218, 10),
                FlatStyle = FlatStyle.System,
                DialogResult = DialogResult.OK
            };
            btnOk.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };

            pnlBottom.Controls.Add(btnOk);
            pnlBottom.Controls.Add(btnCancel);

            // Grid
            _dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                GridColor = Color.FromArgb(220, 224, 230),
                BorderStyle = BorderStyle.None
            };
            _dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);

            DataGridViewTextBoxColumn colField = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FieldName",
                HeaderText = "Trường dữ liệu",
                Width = 150,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn colCap = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Caption",
                HeaderText = "Tiêu đề",
                Width = 150
            };

            DataGridViewComboBoxColumn colType = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "ControlType",
                HeaderText = "Loại control",
                Width = 180,
                FlatStyle = FlatStyle.Flat
            };
            colType.Items.AddRange(new string[]
            {
                "No1TextBox", "No1NumericUpDown", "No1LookupEdit", "No1GridLookup",
                "No1DatePicker", "No1ComboBox", "No1CheckBox", "No1RichEdit"
            });

            DataGridViewCheckBoxColumn colGen = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsSelected",
                HeaderText = "Sinh control",
                Width = 90
            };

            DataGridViewTextBoxColumn colIdx = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Index",
                HeaderText = "Index",
                Width = 80
            };

            _dgv.Columns.AddRange(new DataGridViewColumn[] { colField, colCap, colType, colGen, colIdx });

            this.Controls.Add(_dgv);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlBottom);
        }

        private void LoadData(List<MappingItem> items)
        {
            _itemList.Clear();
            int idx = 1;

            if (items != null)
            {
                foreach (var item in items)
                {
                    string fname = item.FieldName;
                    string ctype = DeduceControlType(fname);

                    _itemList.Add(new GenerateControlItem
                    {
                        FieldName = fname,
                        Caption = string.IsNullOrEmpty(item.Caption) ? DeduceCaption(fname) : item.Caption,
                        ControlType = ctype,
                        IsSelected = true,
                        Index = idx++
                    });
                }
            }

            BindingSource bs = new BindingSource { DataSource = _itemList };
            _dgv.DataSource = bs;
        }

        private string DeduceControlType(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) return "No1TextBox";
            string upper = fieldName.ToUpper();
            if (upper.Contains("NGAY") || upper.Contains("DATE")) return "No1DatePicker";
            if (upper == "LOAIGIA" || upper.Contains("TONG") || upper.Contains("TIEN") || upper.Contains("PHI") || upper.Contains("LE") || upper.Contains("GIAM") || upper.Contains("THUE")) return "No1NumericUpDown";
            if (upper == "TDATHANGID") return "No1GridLookup";
            if (upper.EndsWith("ID")) return "No1LookupEdit";
            return "No1TextBox";
        }

        private string DeduceCaption(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) return "";
            string upper = fieldName.ToUpper();
            switch (upper)
            {
                case "GIAMTHEOTIEN": return "Giảm theo tiền";
                case "LOAI": return "Loại";
                case "LOAIGIA": return "Loại giá";
                case "TDATHANGID": return "Đặt hàng";
                case "DCUAHANGID": return "Cửa hàng";
                case "DKHACHHANGID": return "Khách hàng";
                case "DNHANVIENXUATID": return "Nhân viên";
                case "DKHOXUATID": return "Kho xuất";
                default: return fieldName;
            }
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool check = _chkSelectAll.Checked;
            foreach (var item in _itemList)
            {
                item.IsSelected = check;
            }
            _dgv.Refresh();
        }

        public static List<GenerateControlItem> ShowDialog(IWin32Window owner, List<MappingItem> items)
        {
            using (FormGenerateControls dlg = new FormGenerateControls(items))
            {
                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    return dlg.SelectedItems;
                }
            }
            return null;
        }
    }
}
