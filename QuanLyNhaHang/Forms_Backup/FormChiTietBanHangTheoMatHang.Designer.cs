namespace QuanLyNhaHang
{
    partial class FormChitietbanhangtheomathang
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.grMain = new System.Windows.Forms.Control();
            this.grDetail = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 468);
            this.KryptonPanel1.Size = new System.Drawing.Size(951, 43);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(861, 6);
            this.btnThoat.Size = new System.Drawing.Size(83, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.TabIndex = 0;
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(951, 468);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 1;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Size = new System.Drawing.Size(372, 468);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 2;
            this.grMain.ReadOnly = true;
            // grDetail
            // 
            this.grDetail.Location = new System.Drawing.Point(0, 0);
            this.grDetail.Size = new System.Drawing.Size(574, 468);
            this.grDetail.Name = "grDetail";
            this.grDetail.TabIndex = 2;
            this.grDetail.ReadOnly = true;
            // 
            // FormChitietbanhangtheomathang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 511);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.grDetail);
            this.Name = "FormChitietbanhangtheomathang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết bán hàng theo mặt hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Control grMain;
        public System.Windows.Forms.Control grDetail;
    }
}