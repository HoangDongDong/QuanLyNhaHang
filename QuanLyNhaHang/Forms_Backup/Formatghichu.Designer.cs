namespace QuanLyNhaHang
{
    partial class Formatghichu
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tvGhiChu = new System.Windows.Forms.Control();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.No1FieldMapper1 = new System.Windows.Forms.Control();
            this.lblItem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(386, 389);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Size = new System.Drawing.Size(386, 39);
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 11;
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Size = new System.Drawing.Size(280, 13);
            this.label1.Text = "Đặt ghi chú cho mặt hàng (sẽ in xuống bar/bếp)";
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Size = new System.Drawing.Size(337, 13);
            this.label3.Text = "Hoặc lựa chọn từ danh mục (nháy phải để thêm/xóa các ghi chú sẵn)";
            this.label3.Name = "label3";
            this.label3.TabIndex = 19;
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.Text = "Nhập ghi chú:";
            this.label2.Name = "label2";
            this.label2.TabIndex = 18;
            // tvGhiChu
            // 
            this.tvGhiChu.Location = new System.Drawing.Point(12, 166);
            this.tvGhiChu.Size = new System.Drawing.Size(362, 174);
            this.tvGhiChu.Name = "tvGhiChu";
            this.tvGhiChu.TabIndex = 1;
            this.tvGhiChu.ReadOnly = false;
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(12, 125);
            this.txtNote.Size = new System.Drawing.Size(362, 20);
            this.txtNote.Name = "txtNote";
            this.txtNote.TabIndex = 0;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(218, 347);
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.Text = "Ghi dữ liệu";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 2;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(299, 347);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 3;
            // No1FieldMapper1
            // 
            this.No1FieldMapper1.Name = "No1FieldMapper1";
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(12, 47);
            this.lblItem.Size = new System.Drawing.Size(362, 50);
            this.lblItem.Text = "Mặt hàng:";
            this.lblItem.Name = "lblItem";
            this.lblItem.TabIndex = 20;
            // 
            // Formatghichu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 389);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tvGhiChu);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.No1FieldMapper1);
            this.Controls.Add(this.lblItem);
            this.Name = "Formatghichu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt ghi chú";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Control tvGhiChu;
        public System.Windows.Forms.TextBox txtNote;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Control No1FieldMapper1;
        public System.Windows.Forms.Label lblItem;
    }
}