namespace QuanLyNhaHang.Forms
{
    partial class ChonMauNgauNhien
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rdTuDong = new System.Windows.Forms.RadioButton();
            this.rdThuCong = new System.Windows.Forms.RadioButton();
            this.cboMauSac = new No1Lib.Sys.No1ColorPicker();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rdTatCa = new System.Windows.Forms.RadioButton();
            this.rdNhomDangChon = new System.Windows.Forms.RadioButton();
            this.rdTatCaNhom = new System.Windows.Forms.RadioButton();
            this.rdTatCaKhuVuc = new System.Windows.Forms.RadioButton();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).BeginInit();
            this.KryptonPanel1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            
            // KryptonPanel1
            this.KryptonPanel1.Controls.Add(this.GroupBox2);
            this.KryptonPanel1.Controls.Add(this.GroupBox1);
            this.KryptonPanel1.Controls.Add(this.btnThucHien);
            this.KryptonPanel1.Controls.Add(this.btnHuyBo);
            this.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.Size = new System.Drawing.Size(823, 599);
            this.KryptonPanel1.TabIndex = 0;
            
            // GroupBox2
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.rdTuDong);
            this.GroupBox2.Controls.Add(this.rdThuCong);
            this.GroupBox2.Controls.Add(this.cboMauSac);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(12, 12);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(286, 91);
            this.GroupBox2.TabIndex = 24;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Thiết lập màu";
            
            // rdTuDong
            this.rdTuDong.AutoSize = true;
            this.rdTuDong.Checked = true;
            this.rdTuDong.Location = new System.Drawing.Point(18, 25);
            this.rdTuDong.Name = "rdTuDong";
            this.rdTuDong.Size = new System.Drawing.Size(85, 24);
            this.rdTuDong.TabIndex = 0;
            this.rdTuDong.TabStop = true;
            this.rdTuDong.Text = "Tự động";
            this.rdTuDong.UseVisualStyleBackColor = true;
            
            // rdThuCong
            this.rdThuCong.AutoSize = true;
            this.rdThuCong.Location = new System.Drawing.Point(18, 55);
            this.rdThuCong.Name = "rdThuCong";
            this.rdThuCong.Size = new System.Drawing.Size(93, 24);
            this.rdThuCong.TabIndex = 1;
            this.rdThuCong.Text = "Thủ công";
            this.rdThuCong.UseVisualStyleBackColor = true;
            
            // cboMauSac
            this.cboMauSac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboMauSac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMauSac.Location = new System.Drawing.Point(128, 56);
            this.cboMauSac.Name = "cboMauSac";
            this.cboMauSac.Size = new System.Drawing.Size(145, 23);
            this.cboMauSac.TabIndex = 2;
            
            // GroupBox1
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.rdTatCa);
            this.GroupBox1.Controls.Add(this.rdNhomDangChon);
            this.GroupBox1.Controls.Add(this.rdTatCaNhom);
            this.GroupBox1.Controls.Add(this.rdTatCaKhuVuc);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 109);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(286, 150);
            this.GroupBox1.TabIndex = 23;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Đối tượng áp dụng";
            
            // rdTatCa
            this.rdTatCa.AutoSize = true;
            this.rdTatCa.BackColor = System.Drawing.Color.Transparent;
            this.rdTatCa.Checked = true;
            this.rdTatCa.ForeColor = System.Drawing.Color.Black;
            this.rdTatCa.Location = new System.Drawing.Point(17, 25);
            this.rdTatCa.Name = "rdTatCa";
            this.rdTatCa.Size = new System.Drawing.Size(142, 24);
            this.rdTatCa.TabIndex = 20;
            this.rdTatCa.TabStop = true;
            this.rdTatCa.Text = "Tất cả mặt hàng";
            this.rdTatCa.UseVisualStyleBackColor = false;
            
            // rdNhomDangChon
            this.rdNhomDangChon.AutoSize = true;
            this.rdNhomDangChon.BackColor = System.Drawing.Color.Transparent;
            this.rdNhomDangChon.ForeColor = System.Drawing.Color.Black;
            this.rdNhomDangChon.Location = new System.Drawing.Point(17, 55);
            this.rdNhomDangChon.Name = "rdNhomDangChon";
            this.rdNhomDangChon.Size = new System.Drawing.Size(258, 24);
            this.rdNhomDangChon.TabIndex = 22;
            this.rdNhomDangChon.Text = "Mặt hàng trong nhóm đang chọn";
            this.rdNhomDangChon.UseVisualStyleBackColor = false;
            
            // rdTatCaNhom
            this.rdTatCaNhom.AutoSize = true;
            this.rdTatCaNhom.BackColor = System.Drawing.Color.Transparent;
            this.rdTatCaNhom.ForeColor = System.Drawing.Color.Black;
            this.rdTatCaNhom.Location = new System.Drawing.Point(17, 85);
            this.rdTatCaNhom.Name = "rdTatCaNhom";
            this.rdTatCaNhom.Size = new System.Drawing.Size(155, 24);
            this.rdTatCaNhom.TabIndex = 21;
            this.rdTatCaNhom.Text = "Tất cả nhóm hàng";
            this.rdTatCaNhom.UseVisualStyleBackColor = false;
            
            // rdTatCaKhuVuc
            this.rdTatCaKhuVuc.AutoSize = true;
            this.rdTatCaKhuVuc.Location = new System.Drawing.Point(18, 115);
            this.rdTatCaKhuVuc.Name = "rdTatCaKhuVuc";
            this.rdTatCaKhuVuc.Size = new System.Drawing.Size(129, 24);
            this.rdTatCaKhuVuc.TabIndex = 23;
            this.rdTatCaKhuVuc.Text = "Tất cả khu vực";
            this.rdTatCaKhuVuc.UseVisualStyleBackColor = true;
            
            // btnThucHien
            this.btnThucHien.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnThucHien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucHien.Location = new System.Drawing.Point(121, 269);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(87, 32);
            this.btnThucHien.TabIndex = 1;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            
            // btnHuyBo
            this.btnHuyBo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuyBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyBo.Location = new System.Drawing.Point(214, 269);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(84, 32);
            this.btnHuyBo.TabIndex = 0;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            
            // ChonMauNgauNhien
            this.AcceptButton = this.btnThucHien;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuyBo;
            this.ClientSize = new System.Drawing.Size(823, 599);
            this.Controls.Add(this.KryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChonMauNgauNhien";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THIẾT LẬP MÀU NHANH";
            
            ((System.ComponentModel.ISupportInitialize)(this.KryptonPanel1)).EndInit();
            this.KryptonPanel1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        public ComponentFactory.Krypton.Toolkit.KryptonPanel KryptonPanel1;
        public System.Windows.Forms.GroupBox GroupBox2;
        public System.Windows.Forms.RadioButton rdTuDong;
        public System.Windows.Forms.RadioButton rdThuCong;
        public No1Lib.Sys.No1ColorPicker cboMauSac;
        public System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.RadioButton rdTatCa;
        public System.Windows.Forms.RadioButton rdNhomDangChon;
        public System.Windows.Forms.RadioButton rdTatCaNhom;
        public System.Windows.Forms.RadioButton rdTatCaKhuVuc;
        public System.Windows.Forms.Button btnThucHien;
        public System.Windows.Forms.Button btnHuyBo;
    }
}

