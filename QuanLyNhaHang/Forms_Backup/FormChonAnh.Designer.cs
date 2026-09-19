namespace QuanLyNhaHang
{
    partial class FormChonanh
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.ptImage = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(505, 460);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(505, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 5;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.Text = "Chọn ảnh";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(414, 45);
            this.btnSelect.Size = new System.Drawing.Size(83, 30);
            this.btnSelect.Text = "Chọn ảnh";
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.TabIndex = 8;
            // ptImage
            // 
            this.ptImage.Location = new System.Drawing.Point(7, 81);
            this.ptImage.Size = new System.Drawing.Size(490, 331);
            this.ptImage.Name = "ptImage";
            this.ptImage.TabIndex = 12;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(341, 418);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 9;
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(7, 418);
            this.btnRemove.Size = new System.Drawing.Size(75, 30);
            this.btnRemove.Text = "Xóa ảnh";
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.TabIndex = 11;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(422, 418);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 10;
            // 
            // FormChonanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 460);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.ptImage);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormChonanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn ảnh";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnSelect;
        public System.Windows.Forms.PictureBox ptImage;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.Button btnCancel;
    }
}