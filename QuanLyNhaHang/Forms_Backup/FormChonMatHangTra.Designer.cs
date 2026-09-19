namespace QuanLyNhaHang
{
    partial class FormChonmathangtra
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.tblNhom = new System.Windows.Forms.Control();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.lblTim = new System.Windows.Forms.Label();
            this.grDetail = new System.Windows.Forms.Control();
            this.grDonHang = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(810, 460);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(651, 427);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Chọn";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(732, 427);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(3, 35);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(804, 382);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 19;
            // tblNhom
            // 
            this.tblNhom.Location = new System.Drawing.Point(0, 0);
            this.tblNhom.Size = new System.Drawing.Size(201, 382);
            this.tblNhom.Name = "tblNhom";
            this.tblNhom.TabIndex = 0;
            this.tblNhom.ReadOnly = true;
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.Location = new System.Drawing.Point(12, 9);
            this.lblSoHoaDon.Size = new System.Drawing.Size(66, 13);
            this.lblSoHoaDon.Text = "Số hóa đơn:";
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.TabIndex = 20;
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(84, 6);
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 20);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.TabIndex = 0;
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(190, 4);
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.Text = "Hiển thị";
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.TabIndex = 1;
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(334, 6);
            this.txtTim.Size = new System.Drawing.Size(100, 20);
            this.txtTim.Name = "txtTim";
            this.txtTim.TabIndex = 2;
            // lblTim
            // 
            this.lblTim.Location = new System.Drawing.Point(279, 9);
            this.lblTim.Size = new System.Drawing.Size(49, 13);
            this.lblTim.Text = "Tìm kiếm";
            this.lblTim.Name = "lblTim";
            this.lblTim.TabIndex = 23;
            // grDetail
            // 
            this.grDetail.Location = new System.Drawing.Point(0, 0);
            this.grDetail.Size = new System.Drawing.Size(598, 382);
            this.grDetail.Name = "grDetail";
            this.grDetail.TabIndex = 0;
            this.grDetail.ReadOnly = true;
            // grDonHang
            // 
            this.grDonHang.Location = new System.Drawing.Point(63, 41);
            this.grDonHang.Size = new System.Drawing.Size(297, 244);
            this.grDonHang.Name = "grDonHang";
            this.grDonHang.TabIndex = 1;
            this.grDonHang.ReadOnly = true;
            // 
            // FormChonmathangtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 460);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.tblNhom);
            this.Controls.Add(this.lblSoHoaDon);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.lblTim);
            this.Controls.Add(this.grDetail);
            this.Controls.Add(this.grDonHang);
            this.Name = "FormChonmathangtra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn mặt hàng trả";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Control tblNhom;
        public System.Windows.Forms.Label lblSoHoaDon;
        public System.Windows.Forms.TextBox txtSoHoaDon;
        public System.Windows.Forms.Button btnLoc;
        public System.Windows.Forms.TextBox txtTim;
        public System.Windows.Forms.Label lblTim;
        public System.Windows.Forms.Control grDetail;
        public System.Windows.Forms.Control grDonHang;
    }
}