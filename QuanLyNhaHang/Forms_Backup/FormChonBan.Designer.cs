namespace QuanLyNhaHang
{
    partial class FormChonban
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
            this.label1 = new System.Windows.Forms.Label();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.img = new System.Windows.Forms.Control();
            this.colBan = new System.Windows.Forms.TextBox();
            this.colKhuVuc = new System.Windows.Forms.TextBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(565, 40);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(406, 3);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Chọn";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 14;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(487, 3);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 15;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.Text = "Tìm:";
            this.label1.Name = "label1";
            this.label1.TabIndex = 13;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 40);
            this.grMain.Size = new System.Drawing.Size(565, 429);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 16;
            this.grMain.ReadOnly = true;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 469);
            this.KryptonPanel2.Size = new System.Drawing.Size(565, 36);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 17;
            // img
            // 
            this.img.Name = "img";
            // colBan
            // 
            this.colBan.Name = "colBan";
            this.colBan.ReadOnly = true;
            // colKhuVuc
            // 
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(44, 10);
            this.txtTim.Size = new System.Drawing.Size(253, 20);
            this.txtTim.Name = "txtTim";
            this.txtTim.TabIndex = 14;
            // 
            // FormChonban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 505);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.img);
            this.Controls.Add(this.colBan);
            this.Controls.Add(this.colKhuVuc);
            this.Controls.Add(this.txtTim);
            this.Name = "FormChonban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn bàn";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.Control img;
        public System.Windows.Forms.TextBox colBan;
        public System.Windows.Forms.TextBox colKhuVuc;
        public System.Windows.Forms.TextBox txtTim;
    }
}