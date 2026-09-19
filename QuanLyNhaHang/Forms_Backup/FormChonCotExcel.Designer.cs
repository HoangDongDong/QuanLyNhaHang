namespace QuanLyNhaHang
{
    partial class FormChoncotexcel
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grConfig = new System.Windows.Forms.DataGridView();
            this.colExcel = new System.Windows.Forms.TextBox();
            this.btnTuDongChon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(433, 439);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 405);
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 5;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(274, 405);
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.Text = "OK";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 4;
            // grConfig
            // 
            this.grConfig.Location = new System.Drawing.Point(1, 3);
            this.grConfig.Size = new System.Drawing.Size(429, 396);
            this.grConfig.Name = "grConfig";
            this.grConfig.TabIndex = 3;
            // colExcel
            // 
            this.colExcel.Name = "colExcel";
            this.colExcel.ReadOnly = true;
            // btnTuDongChon
            // 
            this.btnTuDongChon.Location = new System.Drawing.Point(4, 405);
            this.btnTuDongChon.Size = new System.Drawing.Size(127, 28);
            this.btnTuDongChon.Text = "Tự động chọn cột";
            this.btnTuDongChon.Name = "btnTuDongChon";
            this.btnTuDongChon.TabIndex = 6;
            // 
            // FormChoncotexcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 439);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grConfig);
            this.Controls.Add(this.colExcel);
            this.Controls.Add(this.btnTuDongChon);
            this.Name = "FormChoncotexcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn cột excel";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.DataGridView grConfig;
        public System.Windows.Forms.TextBox colExcel;
        public System.Windows.Forms.Button btnTuDongChon;
    }
}