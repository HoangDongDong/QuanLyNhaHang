namespace QuanLyNhaHang
{
    partial class FormChonhoaontam
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
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grMaster = new System.Windows.Forms.Control();
            this.grDetail = new System.Windows.Forms.Control();
            this.KryptonPanel1 = new System.Windows.Forms.Panel();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.Label2147483646 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 66);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(746, 417);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(746, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 23;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.Text = "CHỌN LẠI HÓA ĐƠN LƯU TẠM";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 483);
            this.KryptonPanel2.Size = new System.Drawing.Size(746, 38);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 24;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(587, 3);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(668, 3);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            // grMaster
            // 
            this.grMaster.Location = new System.Drawing.Point(0, 0);
            this.grMaster.Size = new System.Drawing.Size(746, 150);
            this.grMaster.Name = "grMaster";
            this.grMaster.TabIndex = 0;
            this.grMaster.ReadOnly = true;
            // grDetail
            // 
            this.grDetail.Location = new System.Drawing.Point(0, 0);
            this.grDetail.Size = new System.Drawing.Size(746, 262);
            this.grDetail.Name = "grDetail";
            this.grDetail.TabIndex = 0;
            this.grDetail.ReadOnly = true;
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 39);
            this.KryptonPanel1.Size = new System.Drawing.Size(746, 27);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(77, 4);
            this.txtLoc.Size = new System.Drawing.Size(100, 20);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.TabIndex = 0;
            // Label2147483646
            // 
            this.Label2147483646.Location = new System.Drawing.Point(8, 7);
            this.Label2147483646.Size = new System.Drawing.Size(62, 13);
            this.Label2147483646.Text = "Lọc dữ liệu:";
            this.Label2147483646.Name = "Label2147483646";
            this.Label2147483646.TabIndex = 1;
            // 
            // FormChonhoaontam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 521);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grMaster);
            this.Controls.Add(this.grDetail);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.Label2147483646);
            this.Name = "FormChonhoaontam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn hóa đơn tạm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Control grMaster;
        public System.Windows.Forms.Control grDetail;
        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.TextBox txtLoc;
        public System.Windows.Forms.Label Label2147483646;
    }
}