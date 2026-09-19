using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.Forms
{
    public partial class FormDinhDang : Form
    {
        private DataGridView dgvColumns;
        private DataGridView dgvTables;
        private Button btnUpdate;
        private Button btnExit;
        private DataTable dtCols = new DataTable();
        private DataTable dtTables = new DataTable();

        public FormDinhDang()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "ĐỊNH DẠNG";
            this.Size = new Size(880, 540);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            SplitContainer split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 550,
                Padding = new Padding(4)
            };

            // Left Grid: SCOLUMN
            dgvColumns = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                RowHeadersVisible = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            dgvColumns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdx",
                HeaderText = "#",
                DataPropertyName = "#",
                ReadOnly = true,
                Width = 45,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvColumns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCaption",
                HeaderText = "Tiêu đề",
                DataPropertyName = "Tiêu đề",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 140
            });
            dgvColumns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Tên cột",
                DataPropertyName = "Tên cột",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 130
            });
            dgvColumns.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFormat",
                HeaderText = "Định dạng",
                DataPropertyName = "Định dạng",
                ReadOnly = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 100
            });

            // Right Grid: STABLEDESC
            dgvTables = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                RowHeadersVisible = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            dgvTables.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTableIdx",
                HeaderText = "#",
                DataPropertyName = "#",
                ReadOnly = true,
                Width = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvTables.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTableName",
                HeaderText = "Bảng",
                DataPropertyName = "Bảng",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 140
            });
            dgvTables.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTableFormat",
                HeaderText = "Định dạng",
                DataPropertyName = "Định dạng",
                ReadOnly = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 100
            });

            split.Panel1.Controls.Add(dgvColumns);
            split.Panel2.Controls.Add(dgvTables);

            // Bottom Panel
            Panel pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 45,
                BackColor = Color.FromArgb(245, 247, 250)
            };

            btnUpdate = new Button
            {
                Text = "Cập nhật",
                Location = new Point(650, 8),
                Size = new Size(90, 30),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                UseVisualStyleBackColor = true
            };
            btnUpdate.Click += BtnUpdate_Click;

            btnExit = new Button
            {
                Text = "Thoát",
                Location = new Point(755, 8),
                Size = new Size(90, 30),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                UseVisualStyleBackColor = true
            };
            btnExit.Click += (s, e) => this.Close();

            pnlBottom.Controls.Add(btnUpdate);
            pnlBottom.Controls.Add(btnExit);

            this.Controls.Add(split);
            this.Controls.Add(pnlBottom);
        }

        private void LoadData()
        {
            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();

                    // Left Table: Columns
                    dtCols = new DataTable();
                    dtCols.Columns.Add("#", typeof(string));
                    dtCols.Columns.Add("Tiêu đề", typeof(string));
                    dtCols.Columns.Add("Tên cột", typeof(string));
                    dtCols.Columns.Add("Định dạng", typeof(string));

                    string sqlCols = @"
                        SELECT NAME, MAX(CAPTION) AS CAPTION, MAX(FORMAT) AS FORMAT
                        FROM SCOLUMN
                        WHERE NAME IS NOT NULL AND NAME <> ''
                        GROUP BY NAME
                        ORDER BY MAX(CAPTION), NAME";

                    using (FbCommand cmd = new FbCommand(sqlCols, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        int idx = 1;
                        while (rdr.Read())
                        {
                            string colName = rdr["NAME"] != DBNull.Value ? rdr["NAME"]?.ToString()?.Trim() : "";
                            string caption = rdr["CAPTION"] != DBNull.Value ? rdr["CAPTION"]?.ToString()?.Trim() : colName;
                            string format = rdr["FORMAT"] != DBNull.Value ? rdr["FORMAT"]?.ToString()?.Trim() : "";

                            dtCols.Rows.Add(idx.ToString("D3"), caption, colName, format);
                            idx++;
                        }
                    }
                    dgvColumns.DataSource = dtCols;

                    // Right Table: Tables
                    dtTables = new DataTable();
                    dtTables.Columns.Add("#", typeof(int));
                    dtTables.Columns.Add("Bảng", typeof(string));
                    dtTables.Columns.Add("Định dạng", typeof(string));

                    string sqlTables = @"
                        SELECT TRIM(NAME) AS BANG, TRIM(FORMAT) AS DINHDANG
                        FROM STABLEDESC
                        WHERE FORMAT IS NOT NULL AND FORMAT <> ''
                        ORDER BY NAME";

                    using (FbCommand cmd = new FbCommand(sqlTables, conn))
                    using (FbDataReader rdr = cmd.ExecuteReader())
                    {
                        int idx = 1;
                        while (rdr.Read())
                        {
                            string bangName = rdr["BANG"] != DBNull.Value ? rdr["BANG"]?.ToString()?.Trim() : "";
                            string bangFmt = rdr["DINHDANG"] != DBNull.Value ? rdr["DINHDANG"]?.ToString()?.Trim() : "";
                            if (!string.IsNullOrEmpty(bangName))
                            {
                                dtTables.Rows.Add(idx++, bangName, bangFmt);
                            }
                        }
                    }

                    if (dtTables.Rows.Count == 0)
                    {
                        dtTables.Rows.Add(1, "TTHUCHI", "n0");
                    }

                    dgvTables.DataSource = dtTables;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp dữ liệu định dạng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtCols == null || dtTables == null) return;

                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();

                    // Update SCOLUMN formats
                    foreach (DataRow row in dtCols.Rows)
                    {
                        string colName = row["Tên cột"]?.ToString();
                        string format = row["Định dạng"]?.ToString();

                        if (!string.IsNullOrEmpty(colName))
                        {
                            string sqlUpd = "UPDATE SCOLUMN SET FORMAT = @fmt WHERE NAME = @name";
                            using (FbCommand cmd = new FbCommand(sqlUpd, conn))
                            {
                                cmd.Parameters.AddWithValue("@fmt", string.IsNullOrEmpty(format) ? (object)DBNull.Value : format);
                                cmd.Parameters.AddWithValue("@name", colName);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Update STABLEDESC formats
                    foreach (DataRow row in dtTables.Rows)
                    {
                        string tableName = row["Bảng"]?.ToString();
                        string format = row["Định dạng"]?.ToString();

                        if (!string.IsNullOrEmpty(tableName))
                        {
                            string sqlUpd = "UPDATE STABLEDESC SET FORMAT = @fmt WHERE NAME = @name";
                            using (FbCommand cmd = new FbCommand(sqlUpd, conn))
                            {
                                cmd.Parameters.AddWithValue("@fmt", string.IsNullOrEmpty(format) ? (object)DBNull.Value : format);
                                cmd.Parameters.AddWithValue("@name", tableName);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("Cập nhật định dạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật định dạng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
