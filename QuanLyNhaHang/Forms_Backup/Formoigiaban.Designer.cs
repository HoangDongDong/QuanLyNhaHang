namespace QuanLyNhaHang
{
    partial class Formoigiaban
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblItem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(390, 232);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(390, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 8;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.Text = "Đổi giá bán mặt hàng";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // numDonGia
            // 
            this.numDonGia.Location = new System.Drawing.Point(122, 119);
            this.numDonGia.Size = new System.Drawing.Size(120, 26);
            this.numDonGia.Name = "numDonGia";
            this.numDonGia.TabIndex = 0;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 121);
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.Text = "Đơn giá:";
            this.label2.Name = "label2";
            this.label2.TabIndex = 12;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(222, 190);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Ghi dữ liệu";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(303, 190);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 2;
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(12, 53);
            this.lblItem.Size = new System.Drawing.Size(362, 50);
            this.lblItem.Text = "Mặt hàng: ";
            this.lblItem.Name = "lblItem";
            this.lblItem.TabIndex = 20;
            // 
            // Formoigiaban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 232);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numDonGia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblItem);
            this.Name = "Formoigiaban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi giá bán";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numDonGia;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblItem;
    }
}