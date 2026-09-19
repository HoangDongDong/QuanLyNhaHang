namespace QuanLyNhaHang
{
    partial class FormThemmathangmo
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
            this.spPrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Label2147483646 = new System.Windows.Forms.Label();
            this.lueDVT = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(423, 216);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // spPrice
            // 
            this.spPrice.Location = new System.Drawing.Point(125, 87);
            this.spPrice.Size = new System.Drawing.Size(275, 22);
            this.spPrice.Name = "spPrice";
            this.spPrice.TabIndex = 1;
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 89);
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.Text = "Giá mặt hàng:";
            this.label4.Name = "label4";
            this.label4.TabIndex = 19;
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(125, 55);
            this.txtName.Size = new System.Drawing.Size(275, 22);
            this.txtName.Name = "txtName";
            this.txtName.TabIndex = 0;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 58);
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.Text = "Tên mặt hàng";
            this.label2.Name = "label2";
            this.label2.TabIndex = 18;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(423, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 20;
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabIndex = 2;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Size = new System.Drawing.Size(354, 13);
            this.label1.Text = "Mặt hàng mở là mặt hàng chưa có trong danh sách sản phẩm";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(227, 162);
            this.btnOK.Size = new System.Drawing.Size(88, 30);
            this.btnOK.Text = "Nhập";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(321, 162);
            this.btnCancel.Size = new System.Drawing.Size(79, 30);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            // Label2147483646
            // 
            this.Label2147483646.Location = new System.Drawing.Point(29, 120);
            this.Label2147483646.Size = new System.Drawing.Size(71, 16);
            this.Label2147483646.Text = "Đơn vị tính:";
            this.Label2147483646.Name = "Label2147483646";
            this.Label2147483646.TabIndex = 23;
            // lueDVT
            // 
            this.lueDVT.Location = new System.Drawing.Point(125, 117);
            this.lueDVT.Size = new System.Drawing.Size(275, 21);
            this.lueDVT.Name = "lueDVT";
            this.lueDVT.TabIndex = 2;
            // 
            // FormThemmathangmo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 216);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.spPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Label2147483646);
            this.Controls.Add(this.lueDVT);
            this.Name = "FormThemmathangmo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mặt hàng mở";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.NumericUpDown spPrice;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label Label2147483646;
        public System.Windows.Forms.Control lueDVT;
    }
}