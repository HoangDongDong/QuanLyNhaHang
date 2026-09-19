namespace QuanLyNhaHang
{
    partial class FormThembanvaogiaodien
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
            this.grMain = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colBan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(395, 426);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(3, 3);
            this.grMain.Size = new System.Drawing.Size(389, 388);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 0;
            this.grMain.ReadOnly = true;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(236, 393);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 4;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(317, 393);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 5;
            // colBan
            // 
            this.colBan.Name = "colBan";
            this.colBan.ReadOnly = true;
            // 
            // FormThembanvaogiaodien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 426);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.colBan);
            this.Name = "FormThembanvaogiaodien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm bàn vào giao diện";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox colBan;
    }
}