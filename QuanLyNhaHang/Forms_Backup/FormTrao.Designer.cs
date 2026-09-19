namespace QuanLyNhaHang
{
    partial class FormTrao
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
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grTraLai = new System.Windows.Forms.DataGridView();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.TextBox();
            this.colDonGia = new System.Windows.Forms.DataGridView();
            this.colTiLeGiam = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridView();
            this.colTRALAI = new System.Windows.Forms.DataGridView();
            this.colSLSUDUNG = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(619, 41);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Size = new System.Drawing.Size(619, 41);
            this.Label1.Text = "KIỂM TRA && NHẬP SỐ HÀNG TRẢ LẠI";
            this.Label1.Name = "Label1";
            this.Label1.TabIndex = 0;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(529, 7);
            this.btnCancel.Size = new System.Drawing.Size(82, 26);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 1;
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(443, 7);
            this.btnOk.Size = new System.Drawing.Size(80, 26);
            this.btnOk.Text = "Thực hiện";
            this.btnOk.Name = "btnOk";
            this.btnOk.TabIndex = 2;
            // grTraLai
            // 
            this.grTraLai.Location = new System.Drawing.Point(0, 41);
            this.grTraLai.Size = new System.Drawing.Size(619, 415);
            this.grTraLai.Name = "grTraLai";
            this.grTraLai.TabIndex = 3;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 456);
            this.KryptonPanel2.Size = new System.Drawing.Size(619, 42);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 1;
            // Column1
            // 
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // colDonGia
            // 
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // colTiLeGiam
            // 
            this.colTiLeGiam.Name = "colTiLeGiam";
            this.colTiLeGiam.ReadOnly = true;
            // Column2
            // 
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // colTRALAI
            // 
            this.colTRALAI.Name = "colTRALAI";
            // colSLSUDUNG
            // 
            this.colSLSUDUNG.Name = "colSLSUDUNG";
            // 
            // FormTrao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 498);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grTraLai);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.Column1);
            this.Controls.Add(this.colDonGia);
            this.Controls.Add(this.colTiLeGiam);
            this.Controls.Add(this.Column2);
            this.Controls.Add(this.colTRALAI);
            this.Controls.Add(this.colSLSUDUNG);
            this.Name = "FormTrao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trả đồ";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.DataGridView grTraLai;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.TextBox Column1;
        public System.Windows.Forms.DataGridView colDonGia;
        public System.Windows.Forms.DataGridView colTiLeGiam;
        public System.Windows.Forms.DataGridView Column2;
        public System.Windows.Forms.DataGridView colTRALAI;
        public System.Windows.Forms.DataGridView colSLSUDUNG;
    }
}