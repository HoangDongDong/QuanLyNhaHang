namespace QuanLyNhaHang
{
    partial class FormChonkichthuocnhapkho
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
            this.lblItem = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblKichThuoc = new System.Windows.Forms.Label();
            this.txtKichThuoc = new System.Windows.Forms.TextBox();
            this.grKichThuoc = new System.Windows.Forms.DataGridView();
            this.colKichThuoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(384, 425);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(8, 9);
            this.lblItem.Size = new System.Drawing.Size(367, 49);
            this.lblItem.Text = "Mặt hàng:";
            this.lblItem.Name = "lblItem";
            this.lblItem.TabIndex = 19;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(170, 383);
            this.btnOK.Size = new System.Drawing.Size(121, 30);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 2;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(297, 383);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 3;
            // lblKichThuoc
            // 
            this.lblKichThuoc.Location = new System.Drawing.Point(13, 68);
            this.lblKichThuoc.Size = new System.Drawing.Size(87, 20);
            this.lblKichThuoc.Text = "Kích thước:";
            this.lblKichThuoc.Name = "lblKichThuoc";
            this.lblKichThuoc.TabIndex = 22;
            // txtKichThuoc
            // 
            this.txtKichThuoc.Location = new System.Drawing.Point(133, 65);
            this.txtKichThuoc.Size = new System.Drawing.Size(239, 26);
            this.txtKichThuoc.Name = "txtKichThuoc";
            this.txtKichThuoc.TabIndex = 0;
            // grKichThuoc
            // 
            this.grKichThuoc.Location = new System.Drawing.Point(8, 97);
            this.grKichThuoc.Size = new System.Drawing.Size(367, 280);
            this.grKichThuoc.Name = "grKichThuoc";
            this.grKichThuoc.TabIndex = 1;
            this.grKichThuoc.ReadOnly = true;
            // colKichThuoc
            // 
            this.colKichThuoc.Name = "colKichThuoc";
            this.colKichThuoc.ReadOnly = true;
            // 
            // FormChonkichthuocnhapkho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 425);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblKichThuoc);
            this.Controls.Add(this.txtKichThuoc);
            this.Controls.Add(this.grKichThuoc);
            this.Controls.Add(this.colKichThuoc);
            this.Name = "FormChonkichthuocnhapkho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn kích thước nhập kho";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Label lblItem;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblKichThuoc;
        public System.Windows.Forms.TextBox txtKichThuoc;
        public System.Windows.Forms.DataGridView grKichThuoc;
        public System.Windows.Forms.TextBox colKichThuoc;
    }
}