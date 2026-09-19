namespace QuanLyNhaHang
{
    partial class FormChitietcombo
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
            this.grChiTiet = new System.Windows.Forms.DataGridView();
            this.lblItem = new System.Windows.Forms.Label();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colMatHang = new System.Windows.Forms.TextBox();
            this.colSoLuong = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 351);
            this.KryptonPanel1.Size = new System.Drawing.Size(511, 47);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // grChiTiet
            // 
            this.grChiTiet.Location = new System.Drawing.Point(0, 62);
            this.grChiTiet.Size = new System.Drawing.Size(511, 289);
            this.grChiTiet.Name = "grChiTiet";
            this.grChiTiet.TabIndex = 0;
            this.grChiTiet.ReadOnly = true;
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(9, 6);
            this.lblItem.Size = new System.Drawing.Size(494, 50);
            this.lblItem.Text = "Mặt hàng: ";
            this.lblItem.Name = "lblItem";
            this.lblItem.TabIndex = 21;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel2.Size = new System.Drawing.Size(511, 62);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 22;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(424, 7);
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.Text = "Đóng";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 23;
            // colMatHang
            // 
            this.colMatHang.Name = "colMatHang";
            this.colMatHang.ReadOnly = true;
            // colSoLuong
            // 
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // FormChitietcombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 398);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.grChiTiet);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.colMatHang);
            this.Controls.Add(this.colSoLuong);
            this.Name = "FormChitietcombo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết combo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.DataGridView grChiTiet;
        public System.Windows.Forms.Label lblItem;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox colMatHang;
        public System.Windows.Forms.DataGridView colSoLuong;
    }
}