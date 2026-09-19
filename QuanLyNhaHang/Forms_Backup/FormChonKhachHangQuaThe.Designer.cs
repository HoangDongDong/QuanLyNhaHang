namespace QuanLyNhaHang
{
    partial class FormChonkhachhangquathe
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
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(405, 287);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(0, 46);
            this.PictureBox1.Size = new System.Drawing.Size(405, 241);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.TabIndex = 1;
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Size = new System.Drawing.Size(405, 46);
            this.Label2.Text = "VUI LÒNG QUẸT THẺ KHÁCH HÀNG THÂN THIẾT";
            this.Label2.Name = "Label2";
            this.Label2.TabIndex = 2;
            // 
            // FormChonkhachhangquathe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 287);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label2);
            this.Name = "FormChonkhachhangquathe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn khách hàng qua thẻ";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.PictureBox PictureBox1;
        public System.Windows.Forms.Label Label2;
    }
}