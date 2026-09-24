namespace QuanLyNhaHang.Forms
{
    partial class CanhBaoKhuyenMai
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.KryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.grMain = new No1Lib.Sys.DataSearch();
            this.grGiamTheoNhom = new No1Lib.Sys.MiscDataGridView();
            this.colNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaTri = new No1Lib.Sys.NumericDataGridViewColumn();
            this.grMua1Tang1 = new No1Lib.Sys.MiscDataGridView();
            this.colMuaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new No1Lib.Sys.NumericDataGridViewColumn();
            this.colTangMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongTang = new No1Lib.Sys.NumericDataGridViewColumn();
            this.grMatHangDongGia = new No1Lib.Sys.MiscDataGridView();
            this.colMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new No1Lib.Sys.NumericDataGridViewColumn();
            this.grGiamTheoMatHang = new No1Lib.Sys.MiscDataGridView();
            this.colMatHang2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiLeGiamGia = new No1Lib.Sys.NumericDataGridViewColumn();
            this.txtNote = new No1Lib.Sys.No1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).BeginInit();
            this.KryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).BeginInit();
            this.KryptonSplitContainer1.Panel2.SuspendLayout();
            this.KryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grGiamTheoNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMua1Tang1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMatHangDongGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGiamTheoMatHang)).BeginInit();
            this.SuspendLayout();
            // 
            // KryptonPanel1
            // 
            this.KryptonPanel1.Controls.Add(this.btnThoat);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 419);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(846, 45);
            this.KryptonPanel1.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(749, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(89, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            // 
            // KryptonSplitContainer1.Panel1
            // 
            this.KryptonSplitContainer1.Panel1.Controls.Add(this.grMain);
            // 
            // KryptonSplitContainer1.Panel2
            // 
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.grGiamTheoNhom);
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.grMua1Tang1);
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.grMatHangDongGia);
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.grGiamTheoMatHang);
            this.KryptonSplitContainer1.Panel2.Controls.Add(this.txtNote);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(846, 419);
            this.KryptonSplitContainer1.SplitterDistance = 435;
            this.KryptonSplitContainer1.TabIndex = 0;
            // 
            // grMain
            // 
            this.grMain.BackgroundColor = System.Drawing.Color.White;
            this.grMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Name = "grMain";
            this.grMain.Size = new System.Drawing.Size(435, 419);
            this.grMain.TabIndex = 0;
            // 
            // grGiamTheoNhom
            // 
            this.grGiamTheoNhom.AllowUserToAddRows = false;
            this.grGiamTheoNhom.AllowUserToDeleteRows = false;
            this.grGiamTheoNhom.AllowUserToOrderColumns = true;
            this.grGiamTheoNhom.AllowUserToResizeRows = false;
            this.grGiamTheoNhom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grGiamTheoNhom.BackgroundColor = System.Drawing.Color.White;
            this.grGiamTheoNhom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grGiamTheoNhom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grGiamTheoNhom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grGiamTheoNhom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoiDung,
            this.colGiaTri});
            this.grGiamTheoNhom.Location = new System.Drawing.Point(0, 0);
            this.grGiamTheoNhom.Name = "grGiamTheoNhom";
            this.grGiamTheoNhom.ReadOnly = true;
            this.grGiamTheoNhom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grGiamTheoNhom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grGiamTheoNhom.ShowCellToolTips = false;
            this.grGiamTheoNhom.Size = new System.Drawing.Size(406, 89);
            this.grGiamTheoNhom.TabIndex = 0;
            // 
            // colNoiDung
            // 
            this.colNoiDung.DataPropertyName = "NHOMHANG";
            this.colNoiDung.FillWeight = 200F;
            this.colNoiDung.HeaderText = "Nhóm hàng";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.ReadOnly = true;
            // 
            // colGiaTri
            // 
            this.colGiaTri.DataPropertyName = "TILEGIAMGIA";
            this.colGiaTri.DecimalLength = 2;
            this.colGiaTri.HeaderText = "Tỉ lệ giảm";
            this.colGiaTri.Name = "colGiaTri";
            this.colGiaTri.ReadOnly = true;
            // 
            // grMua1Tang1
            // 
            this.grMua1Tang1.AllowUserToAddRows = false;
            this.grMua1Tang1.AllowUserToDeleteRows = false;
            this.grMua1Tang1.AllowUserToOrderColumns = true;
            this.grMua1Tang1.AllowUserToResizeRows = false;
            this.grMua1Tang1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grMua1Tang1.BackgroundColor = System.Drawing.Color.White;
            this.grMua1Tang1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMua1Tang1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grMua1Tang1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMua1Tang1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMuaHang,
            this.colSoLuong,
            this.colTangMatHang,
            this.colSoLuongTang});
            this.grMua1Tang1.Location = new System.Drawing.Point(0, 95);
            this.grMua1Tang1.Name = "grMua1Tang1";
            this.grMua1Tang1.ReadOnly = true;
            this.grMua1Tang1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grMua1Tang1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMua1Tang1.ShowCellToolTips = false;
            this.grMua1Tang1.Size = new System.Drawing.Size(406, 70);
            this.grMua1Tang1.TabIndex = 2;
            // 
            // colMuaHang
            // 
            this.colMuaHang.DataPropertyName = "MATHANGMUA";
            this.colMuaHang.HeaderText = "Mua mặt hàng";
            this.colMuaHang.Name = "colMuaHang";
            this.colMuaHang.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SOLUONGMUA";
            this.colSoLuong.DecimalLength = 2;
            this.colSoLuong.HeaderText = "Số lượng mua";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colTangMatHang
            // 
            this.colTangMatHang.DataPropertyName = "MATHANGTANG";
            this.colTangMatHang.HeaderText = "Tặng mặt hàng";
            this.colTangMatHang.Name = "colTangMatHang";
            this.colTangMatHang.ReadOnly = true;
            // 
            // colSoLuongTang
            // 
            this.colSoLuongTang.DataPropertyName = "SOLUONGTANG";
            this.colSoLuongTang.DecimalLength = 2;
            this.colSoLuongTang.HeaderText = "Số lượng tặng";
            this.colSoLuongTang.Name = "colSoLuongTang";
            this.colSoLuongTang.ReadOnly = true;
            // 
            // grMatHangDongGia
            // 
            this.grMatHangDongGia.AllowUserToAddRows = false;
            this.grMatHangDongGia.AllowUserToDeleteRows = false;
            this.grMatHangDongGia.AllowUserToOrderColumns = true;
            this.grMatHangDongGia.AllowUserToResizeRows = false;
            this.grMatHangDongGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grMatHangDongGia.BackgroundColor = System.Drawing.Color.White;
            this.grMatHangDongGia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grMatHangDongGia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grMatHangDongGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grMatHangDongGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatHang,
            this.colGiaBan});
            this.grMatHangDongGia.Location = new System.Drawing.Point(1, 171);
            this.grMatHangDongGia.Name = "grMatHangDongGia";
            this.grMatHangDongGia.ReadOnly = true;
            this.grMatHangDongGia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grMatHangDongGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grMatHangDongGia.ShowCellToolTips = false;
            this.grMatHangDongGia.Size = new System.Drawing.Size(402, 61);
            this.grMatHangDongGia.TabIndex = 3;
            // 
            // colMatHang
            // 
            this.colMatHang.DataPropertyName = "MATHANG";
            this.colMatHang.FillWeight = 200F;
            this.colMatHang.HeaderText = "Mặt hàng";
            this.colMatHang.Name = "colMatHang";
            this.colMatHang.ReadOnly = true;
            // 
            // colGiaBan
            // 
            this.colGiaBan.DataPropertyName = "GIABAN";
            this.colGiaBan.DecimalLength = 2;
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // grGiamTheoMatHang
            // 
            this.grGiamTheoMatHang.AllowUserToAddRows = false;
            this.grGiamTheoMatHang.AllowUserToDeleteRows = false;
            this.grGiamTheoMatHang.AllowUserToOrderColumns = true;
            this.grGiamTheoMatHang.AllowUserToResizeRows = false;
            this.grGiamTheoMatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grGiamTheoMatHang.BackgroundColor = System.Drawing.Color.White;
            this.grGiamTheoMatHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grGiamTheoMatHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.grGiamTheoMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grGiamTheoMatHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatHang2,
            this.colTiLeGiamGia});
            this.grGiamTheoMatHang.Location = new System.Drawing.Point(4, 250);
            this.grGiamTheoMatHang.Name = "grGiamTheoMatHang";
            this.grGiamTheoMatHang.ReadOnly = true;
            this.grGiamTheoMatHang.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grGiamTheoMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grGiamTheoMatHang.ShowCellToolTips = false;
            this.grGiamTheoMatHang.Size = new System.Drawing.Size(399, 57);
            this.grGiamTheoMatHang.TabIndex = 4;
            // 
            // colMatHang2
            // 
            this.colMatHang2.DataPropertyName = "MATHANG";
            this.colMatHang2.FillWeight = 200F;
            this.colMatHang2.HeaderText = "Mặt hàng";
            this.colMatHang2.Name = "colMatHang2";
            this.colMatHang2.ReadOnly = true;
            // 
            // colTiLeGiamGia
            // 
            this.colTiLeGiamGia.DataPropertyName = "TILEGIAMGIA";
            this.colTiLeGiamGia.DecimalLength = 2;
            this.colTiLeGiamGia.HeaderText = "Tỉ lệ giảm (%)";
            this.colTiLeGiamGia.Name = "colTiLeGiamGia";
            this.colTiLeGiamGia.ReadOnly = true;
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(4, 334);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(399, 57);
            this.txtNote.TabIndex = 1;
            this.txtNote.Visible = false;
            // 
            // CanhBaoKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(846, 464);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CanhBaoKhuyenMai";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CÁC CHƯƠNG TRÌNH KHUYẾN MẠI ĐANG ÁP DỤNG";
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel1)).EndInit();
            this.KryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1.Panel2)).EndInit();
            this.KryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.KryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonSplitContainer1)).EndInit();
            this.KryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grGiamTheoNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMua1Tang1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grMatHangDongGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGiamTheoMatHang)).EndInit();
            this.ResumeLayout(false);

        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.Button btnThoat;
        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer KryptonSplitContainer1;
        public No1Lib.Sys.DataSearch grMain;
        public No1Lib.Sys.MiscDataGridView grGiamTheoNhom;
        public System.Windows.Forms.DataGridViewTextBoxColumn colNoiDung;
        public No1Lib.Sys.NumericDataGridViewColumn colGiaTri;
        public No1Lib.Sys.MiscDataGridView grMua1Tang1;
        public System.Windows.Forms.DataGridViewTextBoxColumn colMuaHang;
        public No1Lib.Sys.NumericDataGridViewColumn colSoLuong;
        public System.Windows.Forms.DataGridViewTextBoxColumn colTangMatHang;
        public No1Lib.Sys.NumericDataGridViewColumn colSoLuongTang;
        public No1Lib.Sys.MiscDataGridView grMatHangDongGia;
        public System.Windows.Forms.DataGridViewTextBoxColumn colMatHang;
        public No1Lib.Sys.NumericDataGridViewColumn colGiaBan;
        public No1Lib.Sys.MiscDataGridView grGiamTheoMatHang;
        public System.Windows.Forms.DataGridViewTextBoxColumn colMatHang2;
        public No1Lib.Sys.NumericDataGridViewColumn colTiLeGiamGia;
        public No1Lib.Sys.No1TextBox txtNote;
    }
}



