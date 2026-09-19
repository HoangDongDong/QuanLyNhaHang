namespace QuanLyNhaHang
{
    partial class FormCauhinhmayintheokhuvuc
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
            this.grMain = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.colKhuVuc = new System.Windows.Forms.TextBox();
            this.colMayIn = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(546, 36);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 36);
            this.grMain.Size = new System.Drawing.Size(546, 298);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 0;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 11);
            this.Label1.Size = new System.Drawing.Size(249, 13);
            this.Label1.Text = "Nếu bạn để trống, hệ thống sẽ lấy máy in mặc định";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 1;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 334);
            this.KryptonPanel2.Size = new System.Drawing.Size(546, 40);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 1;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(454, 6);
            this.btnCancel.Size = new System.Drawing.Size(85, 29);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 0;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(363, 6);
            this.btnOK.Size = new System.Drawing.Size(85, 29);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            // colKhuVuc
            // 
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;
            // colMayIn
            // 
            this.colMayIn.Name = "colMayIn";
            // 
            // FormCauhinhmayintheokhuvuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 374);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.colKhuVuc);
            this.Controls.Add(this.colMayIn);
            this.Name = "FormCauhinhmayintheokhuvuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình máy in theo khu vực";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox colKhuVuc;
        public System.Windows.Forms.ComboBox colMayIn;
    }
}