namespace QuanLyNhaHang
{
    partial class FormTimkiemattruoc
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
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grMain = new System.Windows.Forms.Control();
            this.dtNgayDat = new System.Windows.Forms.Control();
            this.dtNgayDen = new System.Windows.Forms.Control();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grDetail = new System.Windows.Forms.Control();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(896, 32);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 32);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(896, 385);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 1;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 417);
            this.KryptonPanel2.Size = new System.Drawing.Size(896, 44);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 2;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Size = new System.Drawing.Size(54, 13);
            this.Label1.Text = "Ngày đặt:";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 0;
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(360, 9);
            this.Label2.Size = new System.Drawing.Size(57, 13);
            this.Label2.Text = "Ngày đến:";
            this.Label2.Name = "Label2";
            this.Label2.TabIndex = 1;
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(723, 9);
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.Text = "Lọc:";
            this.label3.Name = "label3";
            this.label3.TabIndex = 9;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Size = new System.Drawing.Size(414, 385);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 0;
            this.grMain.ReadOnly = true;
            // dtNgayDat
            // 
            this.dtNgayDat.Location = new System.Drawing.Point(72, 4);
            this.dtNgayDat.Size = new System.Drawing.Size(271, 24);
            this.dtNgayDat.Name = "dtNgayDat";
            this.dtNgayDat.TabIndex = 11;
            // dtNgayDen
            // 
            this.dtNgayDen.Location = new System.Drawing.Point(423, 4);
            this.dtNgayDen.Size = new System.Drawing.Size(271, 24);
            this.dtNgayDen.Name = "dtNgayDen";
            this.dtNgayDen.TabIndex = 12;
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(797, 9);
            this.btnThoat.Size = new System.Drawing.Size(87, 27);
            this.btnThoat.Text = "Hủy bỏ";
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.TabIndex = 0;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(704, 9);
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            // grDetail
            // 
            this.grDetail.Location = new System.Drawing.Point(0, 0);
            this.grDetail.Size = new System.Drawing.Size(477, 385);
            this.grDetail.Name = "grDetail";
            this.grDetail.TabIndex = 0;
            this.grDetail.ReadOnly = true;
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(757, 6);
            this.txtLoc.Size = new System.Drawing.Size(113, 20);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.TabIndex = 13;
            // 
            // FormTimkiemattruoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 461);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.dtNgayDat);
            this.Controls.Add(this.dtNgayDen);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grDetail);
            this.Controls.Add(this.txtLoc);
            this.Name = "FormTimkiemattruoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm đặt trước";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Control grMain;
        public System.Windows.Forms.Control dtNgayDat;
        public System.Windows.Forms.Control dtNgayDen;
        public System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Control grDetail;
        public System.Windows.Forms.TextBox txtLoc;
    }
}