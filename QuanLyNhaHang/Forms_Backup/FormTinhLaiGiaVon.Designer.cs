namespace QuanLyNhaHang
{
    partial class FormTinhlaigiavon
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prMain = new System.Windows.Forms.Control();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblMatHang = new System.Windows.Forms.Label();
            this.Label2147483646 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(379, 204);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(379, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 12;
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabIndex = 2;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.Text = "Tính lại giá vốn hàng bán";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Size = new System.Drawing.Size(354, 29);
            this.label3.Text = "Chức năng này sử dụng để đánh giá lại hàng giá trị tồn kho của bạn và cho bạn biết một cách tương đối thực tế nhất lợi nhuận của mình.";
            this.label3.Name = "label3";
            this.label3.TabIndex = 27;
            // prMain
            // 
            this.prMain.Location = new System.Drawing.Point(12, 94);
            this.prMain.Size = new System.Drawing.Size(354, 19);
            this.prMain.Name = "prMain";
            this.prMain.TabIndex = 30;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(288, 164);
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 29;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(207, 164);
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.Text = "Thực hiện";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 28;
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(12, 116);
            this.lblTrangThai.Size = new System.Drawing.Size(355, 17);
            this.lblTrangThai.Text = "Trạng thái:";
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.TabIndex = 31;
            // lblMatHang
            // 
            this.lblMatHang.Location = new System.Drawing.Point(12, 141);
            this.lblMatHang.Size = new System.Drawing.Size(355, 17);
            this.lblMatHang.Text = "Mặt hàng:";
            this.lblMatHang.Name = "lblMatHang";
            this.lblMatHang.TabIndex = 32;
            // Label2147483646
            // 
            this.Label2147483646.Location = new System.Drawing.Point(12, 79);
            this.Label2147483646.Size = new System.Drawing.Size(355, 17);
            this.Label2147483646.Text = "Phương pháp tính: BÌNH QUÂN CUỐI KỲ THEO THÁNG";
            this.Label2147483646.Name = "Label2147483646";
            this.Label2147483646.TabIndex = 33;
            // 
            // FormTinhlaigiavon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 204);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblMatHang);
            this.Controls.Add(this.Label2147483646);
            this.Name = "FormTinhlaigiavon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính lại giá vốn";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Control prMain;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label lblTrangThai;
        public System.Windows.Forms.Label lblMatHang;
        public System.Windows.Forms.Label Label2147483646;
    }
}