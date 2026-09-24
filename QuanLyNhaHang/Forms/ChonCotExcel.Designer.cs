namespace QuanLyNhaHang.Forms
{
    partial class ChonCotExcel
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
            this.btnTuDongChon = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grConfig = new System.Windows.Forms.DataGridView();
            this.colExcel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grConfig)).BeginInit();
            this.SuspendLayout();
            
            // KryptonPanel1
            this.KryptonPanel1.Controls.Add(this.btnTuDongChon);
            this.KryptonPanel1.Controls.Add(this.btnCancel);
            this.KryptonPanel1.Controls.Add(this.btnOK);
            this.KryptonPanel1.Controls.Add(this.grConfig);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(433, 439);
            this.KryptonPanel1.TabIndex = 0;
            
            // btnTuDongChon
            this.btnTuDongChon.Location = new System.Drawing.Point(4, 405);
            this.btnTuDongChon.Name = "btnTuDongChon";
            this.btnTuDongChon.Size = new System.Drawing.Size(127, 28);
            this.btnTuDongChon.TabIndex = 6;
            this.btnTuDongChon.Text = "Tự động chọn cột";
            this.btnTuDongChon.UseVisualStyleBackColor = true;
            this.btnTuDongChon.Click += new System.EventHandler(this.btnTuDongChon_Click);
            
            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(355, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            
            // btnOK
            this.btnOK.Location = new System.Drawing.Point(274, 405);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            
            // grConfig
            this.grConfig.AllowUserToAddRows = false;
            this.grConfig.AllowUserToDeleteRows = false;
            this.grConfig.AllowUserToResizeRows = false;
            this.grConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grConfig.BackgroundColor = System.Drawing.Color.White;
            this.grConfig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExcel});
            this.grConfig.Location = new System.Drawing.Point(1, 3);
            this.grConfig.Name = "grConfig";
            this.grConfig.RowHeadersVisible = false;
            this.grConfig.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grConfig.Size = new System.Drawing.Size(429, 396);
            this.grConfig.TabIndex = 3;
            
            // colExcel
            this.colExcel.DataPropertyName = "EXCEL";
            this.colExcel.HeaderText = "Cột excel";
            this.colExcel.Name = "colExcel";
            this.colExcel.ReadOnly = true;
            
            // ChonCotExcel
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(433, 439);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChonCotExcel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm từ excel";
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grConfig)).EndInit();
            this.ResumeLayout(false);
        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Button btnTuDongChon;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.DataGridView grConfig;
        public System.Windows.Forms.DataGridViewTextBoxColumn colExcel;
    }
}

