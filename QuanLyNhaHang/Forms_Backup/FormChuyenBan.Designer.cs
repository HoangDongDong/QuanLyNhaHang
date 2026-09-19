namespace QuanLyNhaHang
{
    partial class FormChuyenban
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
            this.lblTenBan = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.splitKhuVuc = new System.Windows.Forms.Control();
            this.tabKhuVuc = new System.Windows.Forms.Control();
            this.tabKhuVuc2 = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 567);
            this.KryptonPanel1.Size = new System.Drawing.Size(755, 37);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(755, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 5;
            // lblTenBan
            // 
            this.lblTenBan.Location = new System.Drawing.Point(144, 9);
            this.lblTenBan.Size = new System.Drawing.Size(124, 20);
            this.lblTenBan.Text = "Chuyển phòng";
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.TabIndex = 3;
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabIndex = 2;
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(46, 12);
            this.lblTitle.Size = new System.Drawing.Size(88, 13);
            this.lblTitle.Text = "Chuyển phòng";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 1;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(579, 4);
            this.btnOK.Size = new System.Drawing.Size(88, 28);
            this.btnOK.Text = "Thực hiện";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 10;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(673, 4);
            this.btnCancel.Size = new System.Drawing.Size(79, 30);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 11;
            // splitKhuVuc
            // 
            this.splitKhuVuc.Location = new System.Drawing.Point(0, 39);
            this.splitKhuVuc.Size = new System.Drawing.Size(755, 528);
            this.splitKhuVuc.Name = "splitKhuVuc";
            this.splitKhuVuc.TabIndex = 6;
            // tabKhuVuc
            // 
            this.tabKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.tabKhuVuc.Size = new System.Drawing.Size(755, 255);
            this.tabKhuVuc.Text = "KryptonNavigator1";
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.TabIndex = 0;
            // tabKhuVuc2
            // 
            this.tabKhuVuc2.Location = new System.Drawing.Point(0, 0);
            this.tabKhuVuc2.Size = new System.Drawing.Size(755, 268);
            this.tabKhuVuc2.Text = "KryptonNavigator2147483646";
            this.tabKhuVuc2.Name = "tabKhuVuc2";
            this.tabKhuVuc2.TabIndex = 0;
            // 
            // FormChuyenban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 604);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTenBan);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.splitKhuVuc);
            this.Controls.Add(this.tabKhuVuc);
            this.Controls.Add(this.tabKhuVuc2);
            this.Name = "FormChuyenban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển bàn";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblTenBan;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Control splitKhuVuc;
        public System.Windows.Forms.Control tabKhuVuc;
        public System.Windows.Forms.Control tabKhuVuc2;
    }
}