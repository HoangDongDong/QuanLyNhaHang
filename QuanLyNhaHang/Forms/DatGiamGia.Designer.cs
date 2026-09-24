namespace No1Run
{
    partial class DatGiamGia
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
            this.lblItem = new System.Windows.Forms.Label();
            this.Label2147483644 = new System.Windows.Forms.Label();
            this.numGiaSauGiam = new No1Lib.Sys.No1NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Label2147483645 = new System.Windows.Forms.Label();
            this.Label2147483646 = new System.Windows.Forms.Label();
            this.numTien = new No1Lib.Sys.No1NumericUpDown();
            this.numTiLe = new No1Lib.Sys.No1NumericUpDown();
            this.numGiaGoc = new No1Lib.Sys.No1NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaSauGiam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaGoc)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.lblItem);
            this.KryptonPanel1.Controls.Add(this.Label2147483644);
            this.KryptonPanel1.Controls.Add(this.numGiaSauGiam);
            this.KryptonPanel1.Controls.Add(this.btnOK);
            this.KryptonPanel1.Controls.Add(this.btnCancel);
            this.KryptonPanel1.Controls.Add(this.Label2147483645);
            this.KryptonPanel1.Controls.Add(this.Label2147483646);
            this.KryptonPanel1.Controls.Add(this.numTien);
            this.KryptonPanel1.Controls.Add(this.numTiLe);
            this.KryptonPanel1.Controls.Add(this.numGiaGoc);
            this.KryptonPanel1.Controls.Add(this.label2);
            this.KryptonPanel1.Controls.Add(this.panel1);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(387, 299);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // lblItem
            // 
            this.lblItem.BackColor = System.Drawing.Color.Transparent;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblItem.ForeColor = System.Drawing.Color.Navy;
            this.lblItem.Location = new System.Drawing.Point(9, 46);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(362, 50);
            this.lblItem.TabIndex = 20;
            this.lblItem.Text = "Mặt hàng:";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2147483644
            // 
            this.Label2147483644.AutoSize = true;
            this.Label2147483644.BackColor = System.Drawing.Color.Transparent;
            this.Label2147483644.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label2147483644.Location = new System.Drawing.Point(37, 211);
            this.Label2147483644.Name = "Label2147483644";
            this.Label2147483644.Size = new System.Drawing.Size(132, 20);
            this.Label2147483644.TabIndex = 18;
            this.Label2147483644.Text = "Đơn giá sau giảm";
            // 
            // numGiaSauGiam
            // 
            this.numGiaSauGiam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numGiaSauGiam.DecimalPlaces = 2;
            this.numGiaSauGiam.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numGiaSauGiam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numGiaSauGiam.Location = new System.Drawing.Point(251, 206);
            this.numGiaSauGiam.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numGiaSauGiam.Minimum = new decimal(new int[] {
            1874919424,
            23283064,
            0,
            -2147483648});
            this.numGiaSauGiam.Name = "numGiaSauGiam";
            this.numGiaSauGiam.ReadOnly = true;
            this.numGiaSauGiam.Size = new System.Drawing.Size(120, 26);
            this.numGiaSauGiam.TabIndex = 5;
            this.numGiaSauGiam.TabStop = false;
            this.numGiaSauGiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGiaSauGiam.ThousandsSeparator = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(215, 257);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Ghi dữ liệu";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(296, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // Label2147483645
            // 
            this.Label2147483645.AutoSize = true;
            this.Label2147483645.BackColor = System.Drawing.Color.Transparent;
            this.Label2147483645.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label2147483645.Location = new System.Drawing.Point(36, 179);
            this.Label2147483645.Name = "Label2147483645";
            this.Label2147483645.Size = new System.Drawing.Size(113, 20);
            this.Label2147483645.TabIndex = 16;
            this.Label2147483645.Text = "Giảm theo tiền";
            // 
            // Label2147483646
            // 
            this.Label2147483646.AutoSize = true;
            this.Label2147483646.BackColor = System.Drawing.Color.Transparent;
            this.Label2147483646.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label2147483646.Location = new System.Drawing.Point(36, 147);
            this.Label2147483646.Name = "Label2147483646";
            this.Label2147483646.Size = new System.Drawing.Size(101, 20);
            this.Label2147483646.TabIndex = 15;
            this.Label2147483646.Text = "Giảm theo %";
            // 
            // numTien
            // 
            this.numTien.DecimalPlaces = 2;
            this.numTien.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numTien.Location = new System.Drawing.Point(251, 175);
            this.numTien.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numTien.Minimum = new decimal(new int[] {
            1874919424,
            23283064,
            0,
            -2147483648});
            this.numTien.Name = "numTien";
            this.numTien.Size = new System.Drawing.Size(120, 26);
            this.numTien.TabIndex = 1;
            this.numTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTien.ThousandsSeparator = true;
            this.numTien.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.numTien_OnEditValueChanged);
            // 
            // numTiLe
            // 
            this.numTiLe.DecimalPlaces = 2;
            this.numTiLe.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numTiLe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numTiLe.Location = new System.Drawing.Point(251, 143);
            this.numTiLe.Name = "numTiLe";
            this.numTiLe.Size = new System.Drawing.Size(120, 26);
            this.numTiLe.TabIndex = 0;
            this.numTiLe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTiLe.ThousandsSeparator = true;
            this.numTiLe.OnEditValueChanged += new No1Lib.Sys.No1ControlChangedHandler(this.numTiLe_OnEditValueChanged);
            // 
            // numGiaGoc
            // 
            this.numGiaGoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numGiaGoc.DecimalPlaces = 2;
            this.numGiaGoc.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGiaGoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numGiaGoc.Location = new System.Drawing.Point(251, 111);
            this.numGiaGoc.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numGiaGoc.Minimum = new decimal(new int[] {
            1874919424,
            23283064,
            0,
            -2147483648});
            this.numGiaGoc.Name = "numGiaGoc";
            this.numGiaGoc.ReadOnly = true;
            this.numGiaGoc.Size = new System.Drawing.Size(120, 26);
            this.numGiaGoc.TabIndex = 4;
            this.numGiaGoc.TabStop = false;
            this.numGiaGoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGiaGoc.ThousandsSeparator = true;
            this.numGiaGoc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(36, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Đơn giá gốc";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 39);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đặt giảm giá cho mặt hàng";
            // 
            // DatGiamGia
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(387, 299);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatGiamGia";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt giảm giá";
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaSauGiam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiLe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaGoc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Label lblItem;
        public System.Windows.Forms.Label Label2147483644;
        public No1Lib.Sys.No1NumericUpDown numGiaSauGiam;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label Label2147483645;
        public System.Windows.Forms.Label Label2147483646;
        public No1Lib.Sys.No1NumericUpDown numTien;
        public No1Lib.Sys.No1NumericUpDown numTiLe;
        public No1Lib.Sys.No1NumericUpDown numGiaGoc;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
    }
}
