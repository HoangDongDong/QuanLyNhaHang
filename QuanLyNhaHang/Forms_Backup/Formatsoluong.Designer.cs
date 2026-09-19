namespace QuanLyNhaHang
{
    partial class Formatsoluong
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
            this.spSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblItem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(377, 233);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(377, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 8;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.Text = "Đặt số lượng cho mặt hàng";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // spSoLuong
            // 
            this.spSoLuong.Location = new System.Drawing.Point(94, 107);
            this.spSoLuong.Size = new System.Drawing.Size(120, 26);
            this.spSoLuong.Name = "spSoLuong";
            this.spSoLuong.TabIndex = 9;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.Text = "Số lượng:";
            this.label2.Name = "label2";
            this.label2.TabIndex = 12;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(209, 191);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Ghi dữ liệu";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 10;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 191);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 11;
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(7, 44);
            this.lblItem.Size = new System.Drawing.Size(362, 50);
            this.lblItem.Text = "Mặt hàng: ";
            this.lblItem.Name = "lblItem";
            this.lblItem.TabIndex = 19;
            // 
            // Formatsoluong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 233);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spSoLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblItem);
            this.Name = "Formatsoluong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt số lượng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown spSoLuong;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblItem;
    }
}