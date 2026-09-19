namespace QuanLyNhaHang
{
    partial class FormNhaplydo
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(446, 172);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Size = new System.Drawing.Size(446, 36);
            this.lblTitle.Text = "Mời bạn nhập lý do hủy";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(350, 127);
            this.btnCancel.Size = new System.Drawing.Size(84, 33);
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 2;
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(260, 127);
            this.btnOK.Size = new System.Drawing.Size(84, 33);
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            // lblLyDo
            // 
            this.lblLyDo.Location = new System.Drawing.Point(24, 62);
            this.lblLyDo.Size = new System.Drawing.Size(36, 13);
            this.lblLyDo.Text = "Lý do:";
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.TabIndex = 3;
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(66, 59);
            this.txtLyDo.Size = new System.Drawing.Size(363, 20);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.TabIndex = 0;
            // 
            // FormNhaplydo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 172);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblLyDo);
            this.Controls.Add(this.txtLyDo);
            this.Name = "FormNhaplydo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập lý do";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label lblLyDo;
        public System.Windows.Forms.TextBox txtLyDo;
    }
}