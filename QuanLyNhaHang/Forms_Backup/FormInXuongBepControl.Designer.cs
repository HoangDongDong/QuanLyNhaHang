namespace QuanLyNhaHang
{
    partial class FormInxuongbepcontrol
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.grMain = new System.Windows.Forms.DataGridView();
            this.colNam = new System.Windows.Forms.TextBox();
            this.colDVT = new System.Windows.Forms.TextBox();
            this.colGhiChu = new System.Windows.Forms.TextBox();
            this.colSoLuong = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(520, 476);
            this.No1UserControl1.Name = "No1UserControl1";
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Size = new System.Drawing.Size(520, 35);
            this.panel3.Name = "panel3";
            this.panel3.TabIndex = 5;
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(14, 10);
            this.lblCaption.Size = new System.Drawing.Size(410, 13);
            this.lblCaption.Text = "Máy in:";
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.TabIndex = 3;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 35);
            this.grMain.Size = new System.Drawing.Size(520, 441);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 6;
            this.grMain.ReadOnly = true;
            // colNam
            // 
            this.colNam.Name = "colNam";
            this.colNam.ReadOnly = true;
            // colDVT
            // 
            this.colDVT.Name = "colDVT";
            this.colDVT.ReadOnly = true;
            // colGhiChu
            // 
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            // colSoLuong
            // 
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // FormInxuongbepcontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.colNam);
            this.Controls.Add(this.colDVT);
            this.Controls.Add(this.colGhiChu);
            this.Controls.Add(this.colSoLuong);
            this.Name = "FormInxuongbepcontrol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In xuống bếp control";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label lblCaption;
        public System.Windows.Forms.DataGridView grMain;
        public System.Windows.Forms.TextBox colNam;
        public System.Windows.Forms.TextBox colDVT;
        public System.Windows.Forms.TextBox colGhiChu;
        public System.Windows.Forms.DataGridView colSoLuong;
    }
}