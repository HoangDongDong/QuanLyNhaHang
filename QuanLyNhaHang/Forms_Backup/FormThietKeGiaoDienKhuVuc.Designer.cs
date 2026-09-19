namespace QuanLyNhaHang
{
    partial class FormThietkegiaodienkhuvuc
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
            this.No1UserControl1 = new System.Windows.Forms.Control();
            this.tmrLoad = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(400, 300);
            this.No1UserControl1.Name = "No1UserControl1";
            // tmrLoad
            // 
            this.tmrLoad.Name = "tmrLoad";
            // 
            // FormThietkegiaodienkhuvuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.tmrLoad);
            this.Name = "FormThietkegiaodienkhuvuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết kế giao diện khu vực";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.Control tmrLoad;
    }
}