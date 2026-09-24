namespace QuanLyNhaHang.Forms
{
    partial class ChonKichThuocNhapKho
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
            this.KryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblKichThuoc = new System.Windows.Forms.Label();
            this.txtKichThuoc = new No1Lib.Sys.No1TextBox();
            this.grKichThuoc = new No1Lib.Sys.MiscDataGridView();
            this.colKichThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grKichThuoc)).BeginInit();
            this.SuspendLayout();
            
            // KryptonPanel1
            this.KryptonPanel1.Controls.Add(this.lblItem);
            this.KryptonPanel1.Controls.Add(this.lblKichThuoc);
            this.KryptonPanel1.Controls.Add(this.txtKichThuoc);
            this.KryptonPanel1.Controls.Add(this.grKichThuoc);
            this.KryptonPanel1.Controls.Add(this.btnOK);
            this.KryptonPanel1.Controls.Add(this.btnCancel);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(384, 425);
            this.KryptonPanel1.TabIndex = 0;
            
            // lblItem
            this.lblItem.BackColor = System.Drawing.Color.Transparent;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.Navy;
            this.lblItem.Location = new System.Drawing.Point(8, 9);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(367, 49);
            this.lblItem.TabIndex = 19;
            this.lblItem.Text = "Mặt hàng:";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            // lblKichThuoc
            this.lblKichThuoc.AutoSize = true;
            this.lblKichThuoc.BackColor = System.Drawing.Color.Transparent;
            this.lblKichThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKichThuoc.Location = new System.Drawing.Point(13, 68);
            this.lblKichThuoc.Name = "lblKichThuoc";
            this.lblKichThuoc.Size = new System.Drawing.Size(87, 20);
            this.lblKichThuoc.TabIndex = 22;
            this.lblKichThuoc.Text = "Kích thước:";
            
            // txtKichThuoc
            this.txtKichThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKichThuoc.Location = new System.Drawing.Point(133, 65);
            this.txtKichThuoc.Name = "txtKichThuoc";
            this.txtKichThuoc.Size = new System.Drawing.Size(239, 26);
            this.txtKichThuoc.TabIndex = 0;
            
            // grKichThuoc
            this.grKichThuoc.AllowUserToAddRows = false;
            this.grKichThuoc.AllowUserToDeleteRows = false;
            this.grKichThuoc.AllowUserToOrderColumns = true;
            this.grKichThuoc.AllowUserToResizeRows = false;
            System.Windows.Forms.DataGridViewCellStyle alternatingRowsStyle = new System.Windows.Forms.DataGridViewCellStyle();
            alternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.grKichThuoc.AlternatingRowsDefaultCellStyle = alternatingRowsStyle;
            this.grKichThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grKichThuoc.BackgroundColor = System.Drawing.Color.White;
            this.grKichThuoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grKichThuoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            System.Windows.Forms.DataGridViewCellStyle colHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            colHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            colHeaderStyle.BackColor = System.Drawing.SystemColors.Control;
            colHeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            colHeaderStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            colHeaderStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            colHeaderStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            colHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grKichThuoc.ColumnHeadersDefaultCellStyle = colHeaderStyle;
            this.grKichThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grKichThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKichThuoc});
            System.Windows.Forms.DataGridViewCellStyle defaultStyle = new System.Windows.Forms.DataGridViewCellStyle();
            defaultStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            defaultStyle.BackColor = System.Drawing.SystemColors.Window;
            defaultStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            defaultStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            defaultStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            defaultStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            defaultStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grKichThuoc.DefaultCellStyle = defaultStyle;
            this.grKichThuoc.DeleteButton = null;
            this.grKichThuoc.EditButton = null;
            this.grKichThuoc.GUID = "3c702543-63e7-4133-964d-8f2e3f266b66";
            this.grKichThuoc.Location = new System.Drawing.Point(8, 97);
            this.grKichThuoc.Name = "grKichThuoc";
            this.grKichThuoc.ReadOnly = true;
            this.grKichThuoc.RowHeadersVisible = false;
            this.grKichThuoc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            System.Windows.Forms.DataGridViewCellStyle rowsStyle = new System.Windows.Forms.DataGridViewCellStyle();
            rowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grKichThuoc.RowsDefaultCellStyle = rowsStyle;
            this.grKichThuoc.SearchTextBox = this.txtKichThuoc;
            this.grKichThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grKichThuoc.ShowCellToolTips = false;
            this.grKichThuoc.Size = new System.Drawing.Size(367, 280);
            this.grKichThuoc.TabIndex = 1;
            
            // colKichThuoc
            this.colKichThuoc.DataPropertyName = "KICHTHUOC";
            this.colKichThuoc.HeaderText = "Kích thước";
            this.colKichThuoc.Name = "colKichThuoc";
            this.colKichThuoc.ReadOnly = true;
            
            // btnOK
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(170, 383);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            
            // btnCancel
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(297, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            
            // ChonKichThuocNhapKho
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 425);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChonKichThuocNhapKho";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập kích thước";
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grKichThuoc)).EndInit();
            this.ResumeLayout(false);
        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Label lblItem;
        public System.Windows.Forms.Label lblKichThuoc;
        public No1Lib.Sys.No1TextBox txtKichThuoc;
        public No1Lib.Sys.MiscDataGridView grKichThuoc;
        public System.Windows.Forms.DataGridViewTextBoxColumn colKichThuoc;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
    }
}

