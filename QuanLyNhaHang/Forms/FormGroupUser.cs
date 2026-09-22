using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.Forms
{
    public partial class FormGroupUser : Form
    {
        private string _groupId;
        private bool _isEditMode;

        public FormGroupUser(string groupId = null)
        {
            InitializeComponent();
            _groupId = groupId;
            _isEditMode = !string.IsNullOrEmpty(groupId);
        }

        private string _selectedImageId = "";
        private ToolStripDropDown _imageDropDown;

        private void FormGroupUser_Load(object sender, EventArgs e)
        {
            btnImagePicker.Click += BtnImagePicker_Click;
            if (_isEditMode)
            {
                LoadData();
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
            btnImagePicker.Text = name;
            pictureBoxIcon.Image = img;
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

            Label lblNone = new Label { Text = "<Không>", ForeColor = System.Drawing.Color.Navy, Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular), AutoSize = true, Margin = new Padding(5), Cursor = Cursors.Hand };
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



        private void LoadData()
        {
            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    string sql = "SELECT NAME, NOTE, SIMAGEID FROM SGROUPUSER WHERE ID = @id";
                    using (FbCommand cmd = new FbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _groupId);
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["NAME"].ToString();
                                txtNote.Text = reader["NOTE"].ToString();
                                _selectedImageId = reader["SIMAGEID"].ToString();
                                if (!string.IsNullOrEmpty(_selectedImageId))
                                {
                                    using (FbCommand cmdImg = new FbCommand("SELECT NAME, IMAGE FROM SIMAGE WHERE ID = @imgId", conn))
                                    {
                                        cmdImg.Parameters.AddWithValue("@imgId", _selectedImageId);
                                        using (FbDataReader rImg = cmdImg.ExecuteReader())
                                        {
                                            if (rImg.Read())
                                            {
                                                SetSelectedImage(_selectedImageId, rImg["NAME"].ToString(), GetImageFromBlob(rImg["IMAGE"]));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên nhóm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                using (FbConnection conn = new FbConnection(DbFormService.GetConnectionString()))
                {
                    conn.Open();
                    if (_isEditMode)
                    {
                        string sql = "UPDATE SGROUPUSER SET NAME = @name, NOTE = @note, SIMAGEID = @image WHERE ID = @id";
                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@note", txtNote.Text);
                            cmd.Parameters.AddWithValue("@image", _selectedImageId);
                            cmd.Parameters.AddWithValue("@id", _groupId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        _groupId = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
                        string userId = string.IsNullOrEmpty(Program.CurrentUserId) ? Guid.Empty.ToString() : Program.CurrentUserId;
                        string sql = "INSERT INTO SGROUPUSER (ID, NAME, NOTE, SIMAGEID, STATUS, ITEMTYPE, USERCREATEDID) VALUES (@id, @name, @note, @image, 30, 0, @userId)";
                        using (FbCommand cmd = new FbCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", _groupId);
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@note", txtNote.Text);
                            cmd.Parameters.AddWithValue("@image", _selectedImageId);
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
