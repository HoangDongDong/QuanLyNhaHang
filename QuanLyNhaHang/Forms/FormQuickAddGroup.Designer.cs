using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaHang.Forms
{
    partial class FormQuickAddGroup
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImagePicker = new System.Windows.Forms.Button();
            this.txtGroups = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mời bạn điền danh sách nhóm người dùng vào ô phía dưới,\r\nmỗi dòng một nhóm người dùng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ảnh:";
            // 
            // btnImagePicker
            // 
            this.btnImagePicker.Location = new System.Drawing.Point(295, 47);
            this.btnImagePicker.Name = "btnImagePicker";
            this.btnImagePicker.Size = new System.Drawing.Size(65, 23);
            this.btnImagePicker.TabIndex = 3;
            this.btnImagePicker.Text = "Chọn ▾";
            this.btnImagePicker.UseVisualStyleBackColor = true;
            // 
            // txtGroups
            // 
            this.txtGroups.Location = new System.Drawing.Point(12, 76);
            this.txtGroups.Multiline = true;
            this.txtGroups.Name = "txtGroups";
            this.txtGroups.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGroups.Size = new System.Drawing.Size(350, 220);
            this.txtGroups.TabIndex = 4;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(206, 305);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 28);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Chấp nhận";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(287, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormQuickAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 345);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtGroups);
            this.Controls.Add(this.btnImagePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuickAddGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm nhanh";
            this.Load += new System.EventHandler(this.FormQuickAddGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImagePicker;
        private System.Windows.Forms.TextBox txtGroups;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}
