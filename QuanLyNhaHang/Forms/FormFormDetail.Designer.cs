namespace QuanLyNhaHang.Forms
{
    partial class FormFormDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblFormType = new System.Windows.Forms.Label();
            this.cboFormType = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.lblNoun = new System.Windows.Forms.Label();
            this.txtNoun = new System.Windows.Forms.TextBox();
            this.lblVerb = new System.Windows.Forms.Label();
            this.txtVerb = new System.Windows.Forms.TextBox();
            this.lblBillCode = new System.Windows.Forms.Label();
            this.txtBillCode = new System.Windows.Forms.TextBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblPerm = new System.Windows.Forms.Label();
            this.cboPerm = new System.Windows.Forms.ComboBox();
            this.lblImg = new System.Windows.Forms.Label();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.btnPasteImg = new System.Windows.Forms.Button();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.btnClearImg = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(514, 40);
            this.pnlHeader.TabIndex = 0;

            // lblHeader
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(14, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(94, 19);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Chi tiết form";

            // lblName & txtName
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblName.Location = new System.Drawing.Point(14, 55);
            this.lblName.Text = "Tên form:";
            this.txtName.BackColor = System.Drawing.Color.FromArgb(235, 250, 255);
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(125, 52);
            this.txtName.Size = new System.Drawing.Size(230, 23);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);

            // lblFormType & cboFormType
            this.lblFormType.AutoSize = true;
            this.lblFormType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFormType.Location = new System.Drawing.Point(14, 87);
            this.lblFormType.Text = "Loại form:";
            this.cboFormType.BackColor = System.Drawing.Color.FromArgb(255, 255, 208);
            this.cboFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFormType.Location = new System.Drawing.Point(125, 84);
            this.cboFormType.Size = new System.Drawing.Size(230, 23);

            // lblLoai & txtLoai
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoai.Location = new System.Drawing.Point(14, 119);
            this.lblLoai.Text = "Loại:";
            this.txtLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLoai.Location = new System.Drawing.Point(125, 116);
            this.txtLoai.Size = new System.Drawing.Size(60, 23);

            // lblNoun & txtNoun
            this.lblNoun.AutoSize = true;
            this.lblNoun.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNoun.Location = new System.Drawing.Point(14, 151);
            this.lblNoun.Text = "Tên đối tượng (danh từ): vd: phiếu nhập";
            this.txtNoun.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNoun.Location = new System.Drawing.Point(235, 148);
            this.txtNoun.Size = new System.Drawing.Size(120, 23);

            // lblVerb & txtVerb
            this.lblVerb.AutoSize = true;
            this.lblVerb.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVerb.Location = new System.Drawing.Point(14, 183);
            this.lblVerb.Text = "Tên đối tượng (động từ): vd: nhập";
            this.txtVerb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVerb.Location = new System.Drawing.Point(235, 180);
            this.txtVerb.Size = new System.Drawing.Size(120, 23);

            // lblBillCode & txtBillCode
            this.lblBillCode.AutoSize = true;
            this.lblBillCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBillCode.Location = new System.Drawing.Point(14, 215);
            this.lblBillCode.Text = "Mã hóa đơn:";
            this.txtBillCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBillCode.Location = new System.Drawing.Point(125, 212);
            this.txtBillCode.Size = new System.Drawing.Size(230, 23);

            // lblTable & cboTable
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTable.Location = new System.Drawing.Point(14, 247);
            this.lblTable.Text = "Bảng:";
            this.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTable.Location = new System.Drawing.Point(125, 244);
            this.cboTable.Size = new System.Drawing.Size(230, 23);

            // lblClassName & txtClassName
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClassName.Location = new System.Drawing.Point(14, 279);
            this.lblClassName.Text = "Tên class:";
            this.txtClassName.BackColor = System.Drawing.Color.FromArgb(255, 255, 215);
            this.txtClassName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClassName.Location = new System.Drawing.Point(125, 276);
            this.txtClassName.Size = new System.Drawing.Size(230, 23);

            // lblPerm & cboPerm
            this.lblPerm.AutoSize = true;
            this.lblPerm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPerm.Location = new System.Drawing.Point(14, 311);
            this.lblPerm.Text = "Quyền:";
            this.cboPerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPerm.Location = new System.Drawing.Point(125, 308);
            this.cboPerm.Size = new System.Drawing.Size(230, 23);

            // Picture Box & Image Buttons
            this.lblImg.AutoSize = true;
            this.lblImg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImg.Location = new System.Drawing.Point(370, 32);
            this.lblImg.Text = "Ảnh:";

            this.picImg.BackColor = System.Drawing.Color.FromArgb(180, 195, 220);
            this.picImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImg.Location = new System.Drawing.Point(400, 52);
            this.picImg.Size = new System.Drawing.Size(95, 115);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnPasteImg.BackColor = System.Drawing.Color.White;
            this.btnPasteImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasteImg.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPasteImg.Location = new System.Drawing.Point(370, 52);
            this.btnPasteImg.Size = new System.Drawing.Size(26, 26);
            this.btnPasteImg.Text = "📋";
            this.btnPasteImg.Click += new System.EventHandler(this.btnPasteImg_Click);

            this.btnLoadImg.BackColor = System.Drawing.Color.White;
            this.btnLoadImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadImg.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnLoadImg.Location = new System.Drawing.Point(370, 82);
            this.btnLoadImg.Size = new System.Drawing.Size(26, 26);
            this.btnLoadImg.Text = "📁";
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);

            this.btnClearImg.BackColor = System.Drawing.Color.White;
            this.btnClearImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearImg.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnClearImg.Location = new System.Drawing.Point(370, 112);
            this.btnClearImg.Size = new System.Drawing.Size(26, 26);
            this.btnClearImg.Text = "❌";
            this.btnClearImg.Click += new System.EventHandler(this.btnClearImg_Click);

            // Bottom Action Buttons
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(300, 375);
            this.btnSave.Size = new System.Drawing.Size(95, 30);
            this.btnSave.Text = "Ghi dữ liệu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(405, 375);
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 425);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblName); this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblFormType); this.Controls.Add(this.cboFormType);
            this.Controls.Add(this.lblLoai); this.Controls.Add(this.txtLoai);
            this.Controls.Add(this.lblNoun); this.Controls.Add(this.txtNoun);
            this.Controls.Add(this.lblVerb); this.Controls.Add(this.txtVerb);
            this.Controls.Add(this.lblBillCode); this.Controls.Add(this.txtBillCode);
            this.Controls.Add(this.lblTable); this.Controls.Add(this.cboTable);
            this.Controls.Add(this.lblClassName); this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.lblPerm); this.Controls.Add(this.cboPerm);
            this.Controls.Add(this.lblImg); this.Controls.Add(this.picImg);
            this.Controls.Add(this.btnPasteImg); this.Controls.Add(this.btnLoadImg); this.Controls.Add(this.btnClearImg);
            this.Controls.Add(this.btnSave); this.Controls.Add(this.btnCancel);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFormDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FORM";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblFormType;
        private System.Windows.Forms.ComboBox cboFormType;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.Label lblNoun;
        private System.Windows.Forms.TextBox txtNoun;
        private System.Windows.Forms.Label lblVerb;
        private System.Windows.Forms.TextBox txtVerb;
        private System.Windows.Forms.Label lblBillCode;
        private System.Windows.Forms.TextBox txtBillCode;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label lblPerm;
        private System.Windows.Forms.ComboBox cboPerm;
        private System.Windows.Forms.Label lblImg;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Button btnPasteImg;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button btnClearImg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
