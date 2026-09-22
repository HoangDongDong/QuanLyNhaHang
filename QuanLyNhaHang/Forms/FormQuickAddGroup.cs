using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.Forms
{
    public partial class FormQuickAddGroup : Form
    {
        private string _selectedImageId = "";
        private ToolStripDropDown _imageDropDown;

        public FormQuickAddGroup()
        {
            InitializeComponent();
        }

        private void FormQuickAddGroup_Load(object sender, EventArgs e)
        {
            btnImagePicker.Click += BtnImagePicker_Click;
            btnCancel.Click += (s, ev) => this.Close();
            btnAccept.Click += BtnAccept_Click;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGroups.Text))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một tên nhóm người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] groups = txtGroups.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (groups.Length == 0) return;

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string userId = string.IsNullOrEmpty(Program.CurrentUserId) ? Guid.Empty.ToString() : Program.CurrentUserId;
                    
                    using (FbTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            string sql = "INSERT INTO SGROUPUSER (ID, NAME, NOTE, SIMAGEID, STATUS, ITEMTYPE, USERCREATEDID) VALUES (@id, @name, @note, @image, 30, 0, @userId)";
                            foreach (string grp in groups)
                            {
                                string name = grp.Trim();
                                if (string.IsNullOrEmpty(name)) continue;

                                using (FbCommand cmd = new FbCommand(sql, conn, trans))
                                {
                                    string newId = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
                                    cmd.Parameters.AddWithValue("@id", newId);
                                    cmd.Parameters.AddWithValue("@name", name);
                                    cmd.Parameters.AddWithValue("@note", ""); // quick add usually leaves note blank
                                    cmd.Parameters.AddWithValue("@image", _selectedImageId);
                                    cmd.Parameters.AddWithValue("@userId", userId);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            trans.Commit();
                            MessageBox.Show($"Đã thêm thành công {groups.Length} nhóm người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private System.Drawing.Image GetImageFromBlob(object blobValue)
        {
            if (blobValue == DBNull.Value || blobValue == null) return null;
            byte[] imgBytes = (byte[])blobValue;
            using (var ms = new System.IO.MemoryStream(imgBytes))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void SetSelectedImage(string id, string name, System.Drawing.Image img)
        {
            _selectedImageId = id;
            if (img != null)
            {
                btnImagePicker.Text = "";
                btnImagePicker.Image = img;
            }
            else
            {
                btnImagePicker.Text = "Chọn ▾";
                btnImagePicker.Image = null;
            }
        }

        private void BtnImagePicker_Click(object sender, EventArgs e)
        {
            if (_imageDropDown == null)
            {
                BuildImageDropDown();
            }
            _imageDropDown.Show(btnImagePicker, new System.Drawing.Point(0, btnImagePicker.Height));
        }

        private void BuildImageDropDown()
        {
            _imageDropDown = new ToolStripDropDown();
            _imageDropDown.Margin = Padding.Empty;
            _imageDropDown.Padding = Padding.Empty;
            
            Panel pnl = new Panel();
            pnl.BackColor = System.Drawing.Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Size = new System.Drawing.Size(260, 250);
            
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Fill;
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.LeftToRight;
            pnl.Controls.Add(flp);

            Label lblNone = new Label();
            lblNone.Text = "<Không>";
            lblNone.AutoSize = true;
            lblNone.ForeColor = System.Drawing.Color.Blue;
            lblNone.Cursor = Cursors.Hand;
            lblNone.Margin = new Padding(10, 10, 10, 10);
            lblNone.Click += (s, e) => { SetSelectedImage("", "Chọn ▾", null); _imageDropDown.Close(); };
            flp.Controls.Add(lblNone);
            flp.SetFlowBreak(lblNone, true);

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT ID, NAME, NOTE, IMAGE FROM SIMAGE ORDER BY SORTORDER, NOTE, NAME";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        string currentNote = null;
                        while (reader.Read())
                        {
                            string id = reader["ID"].ToString();
                            string name = reader["NAME"].ToString();
                            string note = reader["NOTE"].ToString();
                            object blob = reader["IMAGE"];

                            if (note != currentNote)
                            {
                                currentNote = note;
                                Panel pnlGroup = new Panel { Width = 230, Height = 20, Margin = new Padding(5, 5, 5, 0) };
                                Label lblNote = new Label { Text = string.IsNullOrEmpty(note) ? "Khác" : note, ForeColor = System.Drawing.Color.Blue, Dock = DockStyle.Left, AutoSize = true };
                                Label lblLine = new Label { Height = 1, BackColor = System.Drawing.Color.LightBlue, Dock = DockStyle.Fill };
                                lblLine.Margin = new Padding(0, 10, 0, 0);
                                pnlGroup.Controls.Add(lblLine);
                                pnlGroup.Controls.Add(lblNote);
                                lblLine.BringToFront();
                                flp.Controls.Add(pnlGroup);
                                flp.SetFlowBreak(pnlGroup, true);
                            }

                            System.Drawing.Image img = GetImageFromBlob(blob);
                            Panel pnlIconWrap = new Panel { Width = 70, Height = 35, Margin = new Padding(3) };
                            PictureBox pb = new PictureBox { Width = 24, Height = 24, SizeMode = PictureBoxSizeMode.Zoom, Cursor = Cursors.Hand };
                            pb.Location = new System.Drawing.Point((pnlIconWrap.Width - pb.Width) / 2, (pnlIconWrap.Height - pb.Height) / 2);
                            if (img != null) pb.Image = img;
                            pb.Tag = new { Id = id, Name = name };
                            ToolTip tt = new ToolTip();
                            tt.SetToolTip(pb, name);
                            
                            pb.Click += (s, ev) => 
                            { 
                                var tag = (dynamic)((PictureBox)s).Tag;
                                SetSelectedImage(tag.Id, tag.Name, ((PictureBox)s).Image); 
                                _imageDropDown.Close(); 
                            };
                            pnlIconWrap.Controls.Add(pb);
                            flp.Controls.Add(pnlIconWrap);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            ToolStripControlHost host = new ToolStripControlHost(pnl);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.AutoSize = false;
            host.Size = pnl.Size;
            _imageDropDown.Items.Add(host);
        }
    }
}
