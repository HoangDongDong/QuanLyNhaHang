namespace QuanLyNhaHang.Forms
{
    partial class CauHinhMayInTheoKhuVuc
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
            this.Label1 = new System.Windows.Forms.Label();
            this.grMain = new No1Lib.Sys.MiscDataGridView();
            this.colKhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMayIn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.KryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).BeginInit();
            this.KryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.Label1);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(546, 36);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(12, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(249, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Nếu bạn để trống, hệ thống sẽ lấy máy in mặc định";
            // 
            // grMain
            // 
            this.grMain.AllowUserToAddRows = false;
            this.grMain.AllowUserToDeleteRows = false;
            this.grMain.AllowUserToOrderColumns = true;
            this.grMain.AllowUserToResizeRows = false;
            this.grMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grMain.BackgroundColor = System.Drawing.Color.White;
            this.grMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKhuVuc,
            this.colMayIn});
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 36);
            this.grMain.Name = "grMain";
            this.grMain.RowHeadersVisible = false;
            this.grMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMain.ShowCellToolTips = false;
            this.grMain.Size = new System.Drawing.Size(546, 298);
            this.grMain.TabIndex = 0;
            // 
            // colKhuVuc
            // 
            this.colKhuVuc.DataPropertyName = "NAME";
            this.colKhuVuc.HeaderText = "Khu vực";
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;
            // 
            // colMayIn
            // 
            this.colMayIn.DataPropertyName = "MAYIN";
            this.colMayIn.FillWeight = 350F;
            this.colMayIn.HeaderText = "Máy in hóa đơn";
            this.colMayIn.Name = "colMayIn";
            // 
            // KryptonPanel2
            // 
            this.KryptonPanel2.Controls.Add(this.btnOK);
            this.KryptonPanel2.Controls.Add(this.btnCancel);
            this.KryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 334);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.Size = new System.Drawing.Size(546, 40);
            this.KryptonPanel2.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(363, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(454, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 29);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormCauHinhMayIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(546, 374);
            this.Controls.Add(this.grMain);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CauHinhMayInTheoKhuVuc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẤU HÌNH MÁY IN THEO KHU VỰC";
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.KryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel2)).EndInit();
            this.KryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Label Label1;
        public No1Lib.Sys.MiscDataGridView grMain;
        public System.Windows.Forms.DataGridViewTextBoxColumn colKhuVuc;
        public System.Windows.Forms.DataGridViewComboBoxColumn colMayIn;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel2;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
    }
}


