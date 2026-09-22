namespace QuanLyNhaHang.Forms
{
    partial class FormGroupUser
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnImagePicker = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(50, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(206, 17);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Chỉnh sửa nhóm người dùng";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(12, 10);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxIcon.TabIndex = 9;
            this.pictureBoxIcon.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(102, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Tên nhóm người dùng";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(350, 60);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(29, 13);
            this.lblImage.TabIndex = 2;
            this.lblImage.Text = "Ảnh:";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(12, 90);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(47, 13);
            this.lblNote.TabIndex = 3;
            this.lblNote.Text = "Ghi chú:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 4;
            // 
            // btnImagePicker
            // 
            this.btnImagePicker.Location = new System.Drawing.Point(385, 57);
            this.btnImagePicker.Name = "btnImagePicker";
            this.btnImagePicker.Size = new System.Drawing.Size(65, 21);
            this.btnImagePicker.TabIndex = 5;
            this.btnImagePicker.Text = "Chọn ▾";
            this.btnImagePicker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImagePicker.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(130, 90);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(320, 100);
            this.txtNote.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(294, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Ghi dữ liệu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(375, 205);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormGroupUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 245);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnImagePicker);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGroupUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhóm người dùng";
            this.Load += new System.EventHandler(this.FormGroupUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnImagePicker;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
    }
}
