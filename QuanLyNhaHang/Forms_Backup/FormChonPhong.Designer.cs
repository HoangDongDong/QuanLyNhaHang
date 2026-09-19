namespace QuanLyNhaHang
{
    partial class FormChonphong
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.colChon = new System.Windows.Forms.DataGridView();
            this.colPhong = new System.Windows.Forms.TextBox();
            this.colKhuVuc = new System.Windows.Forms.TextBox();
            this.colLoaiPhong = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 438);
            this.KryptonPanel1.Size = new System.Drawing.Size(600, 36);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(499, 3);
            this.btnCancel.Size = new System.Drawing.Size(97, 30);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 0;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(396, 4);
            this.btnOK.Size = new System.Drawing.Size(97, 30);
            this.btnOK.Text = "OK";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 32);
            this.grMain.Size = new System.Drawing.Size(600, 406);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 2;
            this.grMain.ReadOnly = true;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel2.Size = new System.Drawing.Size(600, 32);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 3;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(10, 9);
            this.Label1.Size = new System.Drawing.Size(28, 13);
            this.Label1.Text = "Lọc:";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 0;
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(45, 5);
            this.txtLoc.Size = new System.Drawing.Size(100, 20);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.TabIndex = 1;
            // colChon
            // 
            this.colChon.Name = "colChon";
            this.colChon.ReadOnly = true;
            // colPhong
            // 
            this.colPhong.Name = "colPhong";
            this.colPhong.ReadOnly = true;
            // colKhuVuc
            // 
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;
            // colLoaiPhong
            // 
            this.colLoaiPhong.Name = "colLoaiPhong";
            this.colLoaiPhong.ReadOnly = true;
            // 
            // FormChonphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 474);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.colChon);
            this.Controls.Add(this.colPhong);
            this.Controls.Add(this.colKhuVuc);
            this.Controls.Add(this.colLoaiPhong);
            this.Name = "FormChonphong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn phòng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox txtLoc;
        public System.Windows.Forms.DataGridView colChon;
        public System.Windows.Forms.TextBox colPhong;
        public System.Windows.Forms.TextBox colKhuVuc;
        public System.Windows.Forms.TextBox colLoaiPhong;
    }
}