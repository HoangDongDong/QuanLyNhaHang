namespace No1Run
{
    partial class GiamGiaTheoNhom
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
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.numDoAn = new No1Lib.Sys.No1NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numDoUong = new No1Lib.Sys.No1NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numDichVu = new No1Lib.Sys.No1NumericUpDown();
            this.Label2147483646 = new System.Windows.Forms.Label();
            this.numDoKhac = new No1Lib.Sys.No1NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDoAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoUong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoKhac)).BeginInit();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.btnCancel);
            this.KryptonPanel1.Controls.Add(this.btnOK);
            this.KryptonPanel1.Controls.Add(this.numDoKhac);
            this.KryptonPanel1.Controls.Add(this.label3);
            this.KryptonPanel1.Controls.Add(this.numDichVu);
            this.KryptonPanel1.Controls.Add(this.Label2147483646);
            this.KryptonPanel1.Controls.Add(this.numDoUong);
            this.KryptonPanel1.Controls.Add(this.label1);
            this.KryptonPanel1.Controls.Add(this.numDoAn);
            this.KryptonPanel1.Controls.Add(this.label2);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(235, 205);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Đồ ăn (%)";
            // 
            // numDoAn
            // 
            this.numDoAn.DecimalPlaces = 2;
            this.numDoAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDoAn.Location = new System.Drawing.Point(125, 17);
            this.numDoAn.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numDoAn.Name = "numDoAn";
            this.numDoAn.Size = new System.Drawing.Size(95, 26);
            this.numDoAn.TabIndex = 0;
            this.numDoAn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDoAn.ThousandsSeparator = true;
            this.numDoAn.Enter += new System.EventHandler(this.num_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Đồ uống (%)";
            // 
            // numDoUong
            // 
            this.numDoUong.DecimalPlaces = 2;
            this.numDoUong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDoUong.Location = new System.Drawing.Point(125, 51);
            this.numDoUong.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numDoUong.Name = "numDoUong";
            this.numDoUong.Size = new System.Drawing.Size(95, 26);
            this.numDoUong.TabIndex = 1;
            this.numDoUong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDoUong.ThousandsSeparator = true;
            this.numDoUong.Enter += new System.EventHandler(this.num_Enter);
            // 
            // Label2147483646
            // 
            this.Label2147483646.AutoSize = true;
            this.Label2147483646.BackColor = System.Drawing.Color.Transparent;
            this.Label2147483646.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2147483646.Location = new System.Drawing.Point(16, 88);
            this.Label2147483646.Name = "Label2147483646";
            this.Label2147483646.Size = new System.Drawing.Size(86, 18);
            this.Label2147483646.TabIndex = 28;
            this.Label2147483646.Text = "Dịch vụ (%)";
            // 
            // numDichVu
            // 
            this.numDichVu.DecimalPlaces = 2;
            this.numDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDichVu.Location = new System.Drawing.Point(125, 85);
            this.numDichVu.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numDichVu.Name = "numDichVu";
            this.numDichVu.Size = new System.Drawing.Size(95, 26);
            this.numDichVu.TabIndex = 2;
            this.numDichVu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDichVu.ThousandsSeparator = true;
            this.numDichVu.Enter += new System.EventHandler(this.num_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Đồ khác (%)";
            // 
            // numDoKhac
            // 
            this.numDoKhac.DecimalPlaces = 2;
            this.numDoKhac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDoKhac.Location = new System.Drawing.Point(125, 119);
            this.numDoKhac.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numDoKhac.Name = "numDoKhac";
            this.numDoKhac.Size = new System.Drawing.Size(95, 26);
            this.numDoKhac.TabIndex = 3;
            this.numDoKhac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDoKhac.ThousandsSeparator = true;
            this.numDoKhac.Enter += new System.EventHandler(this.num_Enter);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(55, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(140, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GiamGiaTheoNhom
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(235, 205);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GiamGiaTheoNhom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giảm giá theo nhóm";
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDoAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoUong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoKhac)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Label label2;
        public No1Lib.Sys.No1NumericUpDown numDoAn;
        public System.Windows.Forms.Label label1;
        public No1Lib.Sys.No1NumericUpDown numDoUong;
        public System.Windows.Forms.Label Label2147483646;
        public No1Lib.Sys.No1NumericUpDown numDichVu;
        public System.Windows.Forms.Label label3;
        public No1Lib.Sys.No1NumericUpDown numDoKhac;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
    }
}
