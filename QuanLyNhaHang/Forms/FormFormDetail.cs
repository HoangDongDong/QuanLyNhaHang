using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.Forms
{
    public partial class FormFormDetail : Form
    {
        private FormModel _model;
        private bool _isCreateMode;
        private byte[] _currentImageBytes;

        public FormFormDetail(FormModel model = null, bool isCreateMode = true)
        {
            InitializeComponent();
            _model = model;
            _isCreateMode = isCreateMode;
            SetupFormCustomStyles();
            LoadFormData();
        }

        private void SetupFormCustomStyles()
        {
            this.BackColor = Color.FromArgb(198, 215, 235);
            
            cboFormType.SelectedIndexChanged += cboFormType_SelectedIndexChanged;

            // Populate FormType dropdown dynamically from DB
            cboFormType.Items.Clear();
            var formTypes = DbFormService.LoadFormTypeItems();
            foreach (var ft in formTypes)
            {
                cboFormType.Items.Add(ft);
            }

            // Populate Table dropdown dynamically from Firebird DB STABLEDESC table
            cboTable.Items.Clear();
            cboTable.Items.Add(new DbFormService.DbTableItem { Id = null, Name = "-- Không chọn --" });
            try
            {
                var tables = DbFormService.LoadTableDescItems();
                foreach (var t in tables)
                {
                    cboTable.Items.Add(t);
                }
            }
            catch { }

            // Populate Perm (Quyền) dropdown dynamically from Firebird DB SFUNCTION table
            cboPerm.Items.Clear();
            cboPerm.Items.Add(new DbFormService.DbFunctionItem { Id = null, Name = "-- Không chọn --" });
            try
            {
                var funcs = DbFormService.LoadFunctionItems();
                foreach (var f in funcs)
                {
                    cboPerm.Items.Add(f);
                }
            }
            catch { }
        }

        private void LoadFormData()
        {
            if (_isCreateMode || _model == null)
            {
                txtName.Text = "";
                txtLoai.Text = "0";
                txtNoun.Text = "";
                txtVerb.Text = "";
                txtBillCode.Text = "";
                txtClassName.Text = "";
                if (cboFormType.Items.Count > 0) cboFormType.SelectedIndex = 0;
                if (cboTable.Items.Count > 0) cboTable.SelectedIndex = 0;
                if (cboPerm.Items.Count > 0) cboPerm.SelectedIndex = 0;
                _currentImageBytes = null;
                picImg.Image = null;
            }
            else
            {
                txtName.Text = _model.Name ?? "";
                txtClassName.Text = _model.ClassName ?? "";
                txtLoai.Text = _model.Loai.ToString();
                txtBillCode.Text = _model.BillCode ?? "";
                txtNoun.Text = _model.Noun ?? "";
                txtVerb.Text = _model.Verb ?? "";
                _currentImageBytes = _model.ImageBytes;
                if (_currentImageBytes != null && _currentImageBytes.Length > 0)
                {
                    picImg.Image = ByteArrayToImage(_currentImageBytes);
                }

                SelectFormType(_model.FormType);
                SelectTableItem(_model.STableDescId);
                SelectPermItem(_model.SFunctionId);
            }
        }

        private void SelectFormType(int formType)
        {
            foreach (var item in cboFormType.Items)
            {
                if (item is DbFormService.DbFormTypeItem ft && ft.Id == formType)
                {
                    cboFormType.SelectedItem = ft;
                    return;
                }
            }
            if (cboFormType.Items.Count > 0) cboFormType.SelectedIndex = 0;
        }

        private void SelectTableItem(string tableDescId)
        {
            if (string.IsNullOrEmpty(tableDescId))
            {
                if (cboTable.Items.Count > 0) cboTable.SelectedIndex = 0;
                return;
            }
            foreach (var item in cboTable.Items)
            {
                if (item is DbFormService.DbTableItem t)
                {
                    if (string.Equals(t.Id, tableDescId, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(t.Name, tableDescId, StringComparison.OrdinalIgnoreCase))
                    {
                        cboTable.SelectedItem = t;
                        return;
                    }
                }
            }
            if (cboTable.Items.Count > 0) cboTable.SelectedIndex = 0;
        }

        private void SelectPermItem(string permId)
        {
            if (string.IsNullOrEmpty(permId))
            {
                if (cboPerm.Items.Count > 0) cboPerm.SelectedIndex = 0;
                return;
            }
            foreach (var item in cboPerm.Items)
            {
                if (item is DbFormService.DbFunctionItem f)
                {
                    if (string.Equals(f.Id, permId, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(f.Name, permId, StringComparison.OrdinalIgnoreCase))
                    {
                        cboPerm.SelectedItem = f;
                        return;
                    }
                }
            }
            if (cboPerm.Items.Count > 0) cboPerm.SelectedIndex = 0;
        }

        private Image ByteArrayToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch { return null; }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (_isCreateMode && (string.IsNullOrWhiteSpace(txtClassName.Text) || txtClassName.Text == txtName.Text))
            {
                txtClassName.Text = System.Text.RegularExpressions.Regex.Replace(txtName.Text, @"[^\w]", "");
            }
        }

        private void btnPasteImg_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                Image img = Clipboard.GetImage();
                picImg.Image = img;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    _currentImageBytes = ms.ToArray();
                }
            }
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Image Files|*.png;*.jpg;*.bmp;*.ico" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentImageBytes = File.ReadAllBytes(ofd.FileName);
                    picImg.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnClearImg_Click(object sender, EventArgs e)
        {
            picImg.Image = null;
            _currentImageBytes = null;
        }

        private void cboFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormType.SelectedItem is DbFormService.DbFormTypeItem ft)
            {
                UpdateControlStatesByFormType(ft.Id);
            }
        }

        private void UpdateControlStatesByFormType(int formType)
        {
            // 1. Tên đối tượng (danh tử) & (động từ): Chỉ mở (Enabled) duy nhất cho FormType 1 (Quản trị)
            bool enableNounVerb = (formType == 1);
            txtNoun.Enabled = enableNounVerb;
            txtVerb.Enabled = enableNounVerb;

            // 2. Bảng: Mở cho FormType 0 (Thêm sửa), 1 (Quản trị), 2 (Công nợ trừ đuôi), 3 (Công nợ theo đơn), 8 (Thêm sửa không theo loại)
            bool enableTable = (formType == 0 || formType == 1 || formType == 2 || formType == 3 || formType == 8);
            cboTable.Enabled = enableTable;

            // 3. Quyền: Mở cho FormType 1 (Quản trị), 2 (Công nợ trừ đuôi), 3 (Công nợ theo đơn), 8 (Thêm sửa không theo loại)
            bool enablePerm = (formType == 1 || formType == 2 || formType == 3 || formType == 8);
            cboPerm.Enabled = enablePerm;

            // 4. Mã hóa đơn: Khóa cho tất cả (hoặc chỉ mở khi cần)
            txtBillCode.Enabled = false;

            // 5. Tên class: Khóa cho FormType 0 (Thêm sửa), 5 (Custom Control), 6 (Custom Form)
            bool enableClassName = !(formType == 0 || formType == 5 || formType == 6);
            txtClassName.Enabled = enableClassName;
            if (enableClassName)
            {
                txtClassName.BackColor = Color.FromArgb(255, 255, 215); // Vàng nhạt
            }
            else
            {
                txtClassName.BackColor = SystemColors.Control;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên form.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formName = txtName.Text.Trim();
            int formType = (cboFormType.SelectedItem is DbFormService.DbFormTypeItem ft) ? ft.Id : 0;
            int.TryParse(txtLoai.Text, out int loaiVal);

            string className = (txtClassName.Enabled && !string.IsNullOrWhiteSpace(txtClassName.Text))
                ? txtClassName.Text.Trim()
                : ((formType == 2 || formType == 3)
                    ? ((loaiVal == 1) ? "CongNo1Handler" : "CongNo0Handler")
                    : System.Text.RegularExpressions.Regex.Replace(formName, @"[^\w]", ""));

            string tableId = (cboTable.Enabled && cboTable.SelectedItem is DbFormService.DbTableItem t && !string.IsNullOrEmpty(t.Id)) ? t.Id : null;
            string permId = (cboPerm.Enabled && cboPerm.SelectedItem is DbFormService.DbFunctionItem f && !string.IsNullOrEmpty(f.Id)) ? f.Id : null;
            string billCode = txtBillCode.Enabled ? txtBillCode.Text.Trim() : "";
            string noun = txtNoun.Enabled ? txtNoun.Text.Trim() : "";
            string verb = txtVerb.Enabled ? txtVerb.Text.Trim() : "";

            if (_isCreateMode || _model == null)
            {
                string initCode = null;
                if (formType == 2 || formType == 3)
                {
                    initCode = FormDesignerCongNoService.GenerateDefaultCongNoHandlerCode(className);
                }
                else if (formType != 1)
                {
                    initCode = "using System;\nusing System.Drawing;\nusing System.Data;\nusing System.Text;\nusing System.Windows.Forms;\nusing No1Lib.Sys;\nusing No1Lib.Db;\nusing No1Lib.Utils;\nusing FirebirdSql.Data.FirebirdClient;\nusing System.ComponentModel;\nusing System.Collections.Generic;\n\nnamespace No1Run\n{\n    public partial class 0Ae\n    {\n    }\n}\n";
                }

                FormModel newForm = new FormModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = formName,
                    ClassName = className,
                    FormType = formType,
                    Loai = loaiVal,
                    STableDescId = tableId,
                    SFunctionId = permId,
                    BillCode = billCode,
                    Noun = noun,
                    Verb = verb,
                    Code = initCode,
                    DesignCode = (formType == 1 || formType == 2 || formType == 3) ? null : "\tpublic No1Lib.Sys.No1UserControl No1UserControl1;\n\tpublic ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;\n\tpublic ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;\n",
                    AeLayout = (formType == 1 || formType == 2 || formType == 3) ? null : "<Object type=\"No1Lib.Sys.No1UserControl, No1Lib.Sys, Version=1.0.0.0, Culture=neutral, PublicKeyToken=870be39b125434d2\" name=\"No1UserControl1\" children=\"Controls\">\n  <Reference name=\"KryptonPanel1\" />\n  <Property name=\"Size\">400, 300</Property>\n  <Property name=\"DataBindings\">\n    <Property name=\"DefaultDataSourceUpdateMode\">OnValidation</Property>\n  </Property>\n  <Property name=\"Name\">No1UserControl1</Property>\n</Object>\n<Object type=\"ComponentFactory.Krypton.Toolkit.KryptonPanel, ComponentFactory.Krypton.Toolkit, Version=4.1.6.0, Culture=neutral, PublicKeyToken=5fd520d36328f741\" name=\"KryptonPanel1\" children=\"Controls\">\n  <Reference name=\"KryptonPanel2\" />\n  <Property name=\"Dock\">Fill</Property>\n  <Property name=\"Size\">400, 300</Property>\n  <Property name=\"TabIndex\">0</Property>\n  <Property name=\"Location\">0, 0</Property>\n  <Property name=\"DataBindings\">\n    <Property name=\"DefaultDataSourceUpdateMode\">OnValidation</Property>\n  </Property>\n  <Property name=\"Name\">KryptonPanel1</Property>\n</Object>\n<Object type=\"ComponentFactory.Krypton.Toolkit.KryptonPanel, ComponentFactory.Krypton.Toolkit, Version=4.1.6.0, Culture=neutral, PublicKeyToken=5fd520d36328f741\" name=\"KryptonPanel2\" children=\"Controls\">\n  <Property name=\"Size\">100, 100</Property>\n  <Property name=\"TabIndex\">0</Property>\n  <Property name=\"Location\">156, 119</Property>\n  <Property name=\"DataBindings\">\n    <Property name=\"DefaultDataSourceUpdateMode\">OnValidation</Property>\n  </Property>\n  <Property name=\"Name\">KryptonPanel2</Property>\n</Object>",
                    ImageBytes = _currentImageBytes
                };

                bool ok = DbFormService.SaveFormModelFull(newForm, true);
                if (ok)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi ghi dữ liệu Form vào CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _model.Name = formName;
                _model.ClassName = className;
                _model.FormType = formType;
                _model.Loai = loaiVal;
                _model.STableDescId = tableId;
                _model.SFunctionId = permId;
                _model.BillCode = billCode;
                _model.Noun = noun;
                _model.Verb = verb;
                _model.ImageBytes = _currentImageBytes;

                bool ok = DbFormService.SaveFormModelFull(_model, false);
                if (ok)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật Form vào CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
