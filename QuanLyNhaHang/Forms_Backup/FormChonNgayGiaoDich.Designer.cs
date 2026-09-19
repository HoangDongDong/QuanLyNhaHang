namespace QuanLyNhaHang
{
    partial class FormChonngaygiaodich
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
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(347, 128);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(159, 7);
            this.dtNgay.Size = new System.Drawing.Size(146, 29);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.TabIndex = 13;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(260, 86);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 12;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.Text = "Ngày làm việc";
            this.label1.Name = "label1";
            this.label1.TabIndex = 11;
            // 
            // FormChonngaygiaodich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 128);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Name = "FormChonngaygiaodich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn ngày giao dịch";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.DateTimePicker dtNgay;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label label1;
    }
}