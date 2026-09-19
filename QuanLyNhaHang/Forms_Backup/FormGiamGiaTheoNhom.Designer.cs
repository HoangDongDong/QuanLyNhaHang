namespace QuanLyNhaHang
{
    partial class FormGiamgiatheonhom
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
            this.KryptonPanel1 = new System.Windows.Forms.Panel();
            this.numDoKhac = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numDoUong = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numDoAn = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numDichVu = new System.Windows.Forms.NumericUpDown();
            this.Label2147483646 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(225, 193);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // numDoKhac
            // 
            this.numDoKhac.Location = new System.Drawing.Point(128, 114);
            this.numDoKhac.Size = new System.Drawing.Size(81, 26);
            this.numDoKhac.Name = "numDoKhac";
            this.numDoKhac.TabIndex = 3;
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.Text = "Đồ khác (%)";
            this.label3.Name = "label3";
            this.label3.TabIndex = 26;
            // numDoUong
            // 
            this.numDoUong.Location = new System.Drawing.Point(128, 50);
            this.numDoUong.Size = new System.Drawing.Size(81, 26);
            this.numDoUong.Name = "numDoUong";
            this.numDoUong.TabIndex = 1;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.Text = "Đồ uống (%)";
            this.label1.Name = "label1";
            this.label1.TabIndex = 25;
            // numDoAn
            // 
            this.numDoAn.Location = new System.Drawing.Point(128, 18);
            this.numDoAn.Size = new System.Drawing.Size(81, 26);
            this.numDoAn.Name = "numDoAn";
            this.numDoAn.TabIndex = 0;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.Text = "Đồ ăn (%)";
            this.label2.Name = "label2";
            this.label2.TabIndex = 24;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(57, 151);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 4;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(138, 151);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 5;
            // numDichVu
            // 
            this.numDichVu.Location = new System.Drawing.Point(128, 82);
            this.numDichVu.Size = new System.Drawing.Size(81, 26);
            this.numDichVu.Name = "numDichVu";
            this.numDichVu.TabIndex = 2;
            // Label2147483646
            // 
            this.Label2147483646.Location = new System.Drawing.Point(12, 84);
            this.Label2147483646.Size = new System.Drawing.Size(89, 20);
            this.Label2147483646.Text = "Dịch vụ (%)";
            this.Label2147483646.Name = "Label2147483646";
            this.Label2147483646.TabIndex = 28;
            // 
            // FormGiamgiatheonhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 193);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.numDoKhac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numDoUong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numDoAn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numDichVu);
            this.Controls.Add(this.Label2147483646);
            this.Name = "FormGiamgiatheonhom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giảm giá theo nhóm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.NumericUpDown numDoKhac;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown numDoUong;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numDoAn;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.NumericUpDown numDichVu;
        public System.Windows.Forms.Label Label2147483646;
    }
}