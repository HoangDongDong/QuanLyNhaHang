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
    public class TableItemInfo
    {
        public string ObjectName { get; set; }
        public string TableName { get; set; }
    }

    public partial class FormSelectTable : Form
    {
        private DataGridView _dgv;
        private TextBox _txtSearch;
        private List<TableItemInfo> _allTables = new List<TableItemInfo>();
        public string SelectedTableName { get; private set; }

        public FormSelectTable(string currentTable = "")
        {
            SelectedTableName = currentTable;
            InitializeComponent();
            LoadTableData();
        }

        private void InitializeComponent()
        {
            this.Text = "Chọn bảng/trường dữ liệu";
            this.Size = new Size(460, 480);
            this.MinimumSize = new Size(400, 380);
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowIcon = false;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Top Header Panel with Subheader label and Search Textbox
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 42,
                BackColor = Color.White,
                Padding = new Padding(10, 8, 10, 8)
            };

            Label lblSubHeader = new Label
            {
                Text = "Danh sách bảng dữ liệu",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(10, 11),
                AutoSize = true
            };

            _txtSearch = new TextBox
            {
                Size = new Size(160, 23),
                Location = new Point(270, 9),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Font = new Font("Segoe UI", 9F)
            };
            _txtSearch.TextChanged += TxtSearch_TextChanged;

            pnlHeader.Controls.Add(lblSubHeader);
            pnlHeader.Controls.Add(_txtSearch);

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

            Button btnSelect = new Button
            {
                Text = "Chọn",
                Size = new Size(95, 28),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(pnlBottom.Width - 202, 10),
                FlatStyle = FlatStyle.System
            };
            btnSelect.Click += BtnSelect_Click;

            pnlBottom.Controls.Add(btnSelect);
            pnlBottom.Controls.Add(btnCancel);

            // DataGridView
            _dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                GridColor = Color.FromArgb(220, 224, 230),
                BorderStyle = BorderStyle.None
            };
            _dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 252);
            _dgv.DoubleClick += (s, e) => BtnSelect_Click(s, e);

            DataGridViewTextBoxColumn colObj = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ObjectName",
                HeaderText = "Tên đối tượng",
                Width = 200
            };
            DataGridViewTextBoxColumn colTable = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TableName",
                HeaderText = "Bảng dữ liệu",
                Width = 220
            };

            _dgv.Columns.AddRange(new DataGridViewColumn[] { colObj, colTable });

            this.Controls.Add(_dgv);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlBottom);
        }

        private void LoadTableData()
        {
            _allTables.Clear();
            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT NAME, DESCRIPTION FROM STABLEDESC ORDER BY COALESCE(NULLIF(DESCRIPTION, ''), NAME) ASC";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        using (FbDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string tname = r["NAME"]?.ToString()?.Trim();
                                string desc = r["DESCRIPTION"]?.ToString()?.Trim();
                                if (!string.IsNullOrEmpty(tname))
                                {
                                    _allTables.Add(new TableItemInfo
                                    {
                                        TableName = tname,
                                        ObjectName = string.IsNullOrEmpty(desc) ? tname : desc
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load STABLEDESC error: " + ex.Message);
            }

            if (_allTables.Count == 0)
            {
                _allTables = new List<TableItemInfo>
                {
                    new TableItemInfo { ObjectName = "Ảnh", TableName = "DANH" },
                    new TableItemInfo { ObjectName = "Bàn", TableName = "DBAN" },
                    new TableItemInfo { ObjectName = "Bảng giá", TableName = "DBANGGIA" },
                    new TableItemInfo { ObjectName = "Bảng giá chi tiết", TableName = "DBANGGIACHITIET" },
                    new TableItemInfo { ObjectName = "Bảng giá theo bàn", TableName = "DBANGGIATHEOBAN" },
                    new TableItemInfo { ObjectName = "Bảng giá theo khu...", TableName = "DBANGGIATHEOKHU" },
                    new TableItemInfo { ObjectName = "Bản quyền", TableName = "DBANQUYEN" },
                    new TableItemInfo { ObjectName = "Biểu tượng", TableName = "DBIEUTUONG" },
                    new TableItemInfo { ObjectName = "Ca làm việc", TableName = "DCALAMVIEC" },
                    new TableItemInfo { ObjectName = "Chỉ tiêu chi tiết", TableName = "DCHITIEUCHITIET" },
                    new TableItemInfo { ObjectName = "Chỉ tiêu doanh thu", TableName = "DCHITIEUDOANHTHU" },
                    new TableItemInfo { ObjectName = "Đơn hàng", TableName = "TDONHANG" },
                    new TableItemInfo { ObjectName = "Tài khoản người dùng", TableName = "SUSER" },
                    new TableItemInfo { ObjectName = "Tồn kho", TableName = "DKHOHANG" },
                    new TableItemInfo { ObjectName = "Mặt hàng", TableName = "DMATHANG" },
                    new TableItemInfo { ObjectName = "Khách hàng", TableName = "DKHACHHANG" },
                    new TableItemInfo { ObjectName = "Nhân viên", TableName = "DNHANVIEN" }
                };
            }

            ApplyFilter();

            if (!string.IsNullOrEmpty(SelectedTableName))
            {
                foreach (DataGridViewRow r in _dgv.Rows)
                {
                    if (r.DataBoundItem is TableItemInfo item && item.TableName.Equals(SelectedTableName, StringComparison.OrdinalIgnoreCase))
                    {
                        r.Selected = true;
                        _dgv.FirstDisplayedScrollingRowIndex = r.Index;
                        break;
                    }
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string keyword = (_txtSearch.Text ?? "").Trim().ToLower();
            List<TableItemInfo> filtered;
            if (string.IsNullOrEmpty(keyword))
            {
                filtered = _allTables;
            }
            else
            {
                filtered = _allTables.Where(t => t.TableName.ToLower().Contains(keyword) || t.ObjectName.ToLower().Contains(keyword)).ToList();
            }

            BindingSource bs = new BindingSource { DataSource = filtered };
            _dgv.DataSource = bs;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (_dgv.SelectedRows.Count > 0 && _dgv.SelectedRows[0].DataBoundItem is TableItemInfo item)
            {
                SelectedTableName = item.TableName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public static string SelectTable(IWin32Window owner, string currentTable)
        {
            using (FormSelectTable dlg = new FormSelectTable(currentTable))
            {
                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    return dlg.SelectedTableName;
                }
            }
            return null;
        }
    }
}
