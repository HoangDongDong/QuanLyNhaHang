namespace QuanLyNhaHang
{
    partial class FormThayoikhoanggio
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
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.ToolStrip1 = new System.Windows.Forms.Control();
            this.ToolStripButton1 = new System.Windows.Forms.Button();
            this.ToolStripButton2 = new System.Windows.Forms.Button();
            this.colPhong = new System.Windows.Forms.TextBox();
            this.colCachTinh = new System.Windows.Forms.TextBox();
            this.colTuGio = new System.Windows.Forms.Control();
            this.colDenGio = new System.Windows.Forms.Control();
            this.colDienGiai = new System.Windows.Forms.TextBox();
            this.colThanhTien = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 300);
            this.KryptonPanel1.Size = new System.Drawing.Size(672, 38);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(502, 3);
            this.Button1.Size = new System.Drawing.Size(80, 31);
            this.Button1.Text = "Chấp nhận";
            this.Button1.Name = "Button1";
            this.Button1.TabIndex = 0;
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(588, 3);
            this.Button2.Size = new System.Drawing.Size(80, 31);
            this.Button2.Text = "Hủy bỏ";
            this.Button2.Name = "Button2";
            this.Button2.TabIndex = 1;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 25);
            this.grMain.Size = new System.Drawing.Size(672, 275);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 1;
            // ToolStrip1
            // 
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Size = new System.Drawing.Size(672, 25);
            this.ToolStrip1.Text = "ToolStrip1";
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.TabIndex = 2;
            // ToolStripButton1
            // 
            this.ToolStripButton1.Size = new System.Drawing.Size(58, 22);
            this.ToolStripButton1.Text = "Thêm";
            this.ToolStripButton1.Name = "ToolStripButton1";
            // ToolStripButton2
            // 
            this.ToolStripButton2.Size = new System.Drawing.Size(47, 22);
            this.ToolStripButton2.Text = "Xóa";
            this.ToolStripButton2.Name = "ToolStripButton2";
            // colPhong
            // 
            this.colPhong.Name = "colPhong";
            // colCachTinh
            // 
            this.colCachTinh.Name = "colCachTinh";
            // colTuGio
            // 
            this.colTuGio.Name = "colTuGio";
            // colDenGio
            // 
            this.colDenGio.Name = "colDenGio";
            // colDienGiai
            // 
            this.colDienGiai.Name = "colDienGiai";
            // colThanhTien
            // 
            this.colThanhTien.Name = "colThanhTien";
            // 
            // FormThayoikhoanggio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 338);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.ToolStripButton1);
            this.Controls.Add(this.ToolStripButton2);
            this.Controls.Add(this.colPhong);
            this.Controls.Add(this.colCachTinh);
            this.Controls.Add(this.colTuGio);
            this.Controls.Add(this.colDenGio);
            this.Controls.Add(this.colDienGiai);
            this.Controls.Add(this.colThanhTien);
            this.Name = "FormThayoikhoanggio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi khoảng giờ";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button Button1;
        public System.Windows.Forms.Button Button2;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Control ToolStrip1;
        public System.Windows.Forms.Button ToolStripButton1;
        public System.Windows.Forms.Button ToolStripButton2;
        public System.Windows.Forms.TextBox colPhong;
        public System.Windows.Forms.TextBox colCachTinh;
        public System.Windows.Forms.Control colTuGio;
        public System.Windows.Forms.Control colDenGio;
        public System.Windows.Forms.TextBox colDienGiai;
        public System.Windows.Forms.DataGridView colThanhTien;
    }
}