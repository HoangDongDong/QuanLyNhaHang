namespace QuanLyNhaHang.Forms
{
    partial class FormDataEntryTemplate
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

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPhimTat = new System.Windows.Forms.ToolStripButton();
            this.tsbTruoc = new System.Windows.Forms.ToolStripButton();
            this.tsbSau = new System.Windows.Forms.ToolStripButton();
            this.tsbTaoMoi = new System.Windows.Forms.ToolStripButton();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuuThoat = new System.Windows.Forms.Button();
            this.btnLuuMoi = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.picIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 62);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(73, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(385, 28);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "TÀI KHOẢN NGƯỜI DÙNG - THÊM MỚI";
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(13, 12);
            this.picIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(43, 39);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPhimTat,
            this.tsbTruoc,
            this.tsbSau,
            this.tsbTaoMoi});
            this.toolStrip1.Location = new System.Drawing.Point(0, 62);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPhimTat
            // 
            this.tsbPhimTat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPhimTat.Name = "tsbPhimTat";
            this.tsbPhimTat.Size = new System.Drawing.Size(86, 28);
            this.tsbPhimTat.Text = "[ ] Phím tắt";
            // 
            // tsbTruoc
            // 
            this.tsbTruoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTruoc.Name = "tsbTruoc";
            this.tsbTruoc.Size = new System.Drawing.Size(107, 28);
            this.tsbTruoc.Text = "<- Trước (F10)";
            // 
            // tsbSau
            // 
            this.tsbSau.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSau.Name = "tsbSau";
            this.tsbSau.Size = new System.Drawing.Size(94, 28);
            this.tsbSau.Text = "Sau (F11) ->";
            // 
            // tsbTaoMoi
            // 
            this.tsbTaoMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTaoMoi.Name = "tsbTaoMoi";
            this.tsbTaoMoi.Size = new System.Drawing.Size(92, 28);
            this.tsbTaoMoi.Text = "[+] Tạo mới";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.Controls.Add(this.btnThoat);
            this.pnlFooter.Controls.Add(this.btnLuuThoat);
            this.pnlFooter.Controls.Add(this.btnLuuMoi);
            this.pnlFooter.Controls.Add(this.btnLuu);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 492);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 62);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(667, 12);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 37);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnLuuThoat
            // 
            this.btnLuuThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuThoat.Location = new System.Drawing.Point(533, 12);
            this.btnLuuThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuuThoat.Name = "btnLuuThoat";
            this.btnLuuThoat.Size = new System.Drawing.Size(120, 37);
            this.btnLuuThoat.TabIndex = 2;
            this.btnLuuThoat.Text = "Lưu && thoát";
            this.btnLuuThoat.UseVisualStyleBackColor = true;
            // 
            // btnLuuMoi
            // 
            this.btnLuuMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuMoi.Location = new System.Drawing.Point(400, 12);
            this.btnLuuMoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuuMoi.Name = "btnLuuMoi";
            this.btnLuuMoi.Size = new System.Drawing.Size(120, 37);
            this.btnLuuMoi.TabIndex = 1;
            this.btnLuuMoi.Text = "Lưu && Mới";
            this.btnLuuMoi.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(280, 12);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(107, 37);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 93);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 399);
            this.pnlContent.TabIndex = 3;
            // 
            // FormDataEntryTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormDataEntryTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormDataEntryTemplate";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tsbPhimTat;
        public System.Windows.Forms.ToolStripButton tsbTruoc;
        public System.Windows.Forms.ToolStripButton tsbSau;
        public System.Windows.Forms.ToolStripButton tsbTaoMoi;
        private System.Windows.Forms.Panel pnlFooter;
        public System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Button btnLuuThoat;
        public System.Windows.Forms.Button btnLuuMoi;
        public System.Windows.Forms.Button btnLuu;
        public System.Windows.Forms.Panel pnlContent;
    }
}
