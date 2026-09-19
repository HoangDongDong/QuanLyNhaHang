namespace QuanLyNhaHang
{
    partial class FormThayoigiovao
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
            this.numSoPhutVeSau = new System.Windows.Forms.NumericUpDown();
            this.lblVeSau = new System.Windows.Forms.Label();
            this.numSoPhut = new System.Windows.Forms.NumericUpDown();
            this.lblVeTruoc = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(341, 216);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // numSoPhutVeSau
            // 
            this.numSoPhutVeSau.Location = new System.Drawing.Point(181, 117);
            this.numSoPhutVeSau.Size = new System.Drawing.Size(75, 29);
            this.numSoPhutVeSau.Name = "numSoPhutVeSau";
            this.numSoPhutVeSau.TabIndex = 14;
            // lblVeSau
            // 
            this.lblVeSau.Location = new System.Drawing.Point(12, 94);
            this.lblVeSau.Size = new System.Drawing.Size(195, 20);
            this.lblVeSau.Text = "Số phút điều chỉnh về sau:";
            this.lblVeSau.Name = "lblVeSau";
            this.lblVeSau.TabIndex = 15;
            // numSoPhut
            // 
            this.numSoPhut.Location = new System.Drawing.Point(181, 62);
            this.numSoPhut.Size = new System.Drawing.Size(75, 29);
            this.numSoPhut.Name = "numSoPhut";
            this.numSoPhut.TabIndex = 9;
            // lblVeTruoc
            // 
            this.lblVeTruoc.Location = new System.Drawing.Point(12, 39);
            this.lblVeTruoc.Size = new System.Drawing.Size(205, 20);
            this.lblVeTruoc.Text = "Số phút điều chỉnh về trước:";
            this.lblVeTruoc.Name = "lblVeTruoc";
            this.lblVeTruoc.TabIndex = 13;
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(12, 9);
            this.lblTime.Size = new System.Drawing.Size(121, 20);
            this.lblTime.Text = "Mở hóa đơn lúc:";
            this.lblTime.Name = "lblTime";
            this.lblTime.TabIndex = 12;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(173, 173);
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 10;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(254, 173);
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 11;
            // 
            // FormThayoigiovao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 216);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.numSoPhutVeSau);
            this.Controls.Add(this.lblVeSau);
            this.Controls.Add(this.numSoPhut);
            this.Controls.Add(this.lblVeTruoc);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormThayoigiovao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi giờ vào";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.NumericUpDown numSoPhutVeSau;
        public System.Windows.Forms.Label lblVeSau;
        public System.Windows.Forms.NumericUpDown numSoPhut;
        public System.Windows.Forms.Label lblVeTruoc;
        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
    }
}