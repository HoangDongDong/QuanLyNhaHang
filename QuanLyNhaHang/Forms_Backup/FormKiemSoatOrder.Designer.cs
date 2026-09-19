namespace QuanLyNhaHang
{
    partial class FormKiemsoatorder
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
            this.KryptonPanel1 = new System.Windows.Forms.Panel();
            this.btnTai = new System.Windows.Forms.Button();
            this.dtNgay = new System.Windows.Forms.Control();
            this.KryptonPanel2 = new System.Windows.Forms.Panel();
            this.lblTongOrder = new System.Windows.Forms.Label();
            this.lblTrung = new System.Windows.Forms.Label();
            this.lblLonNhat = new System.Windows.Forms.Label();
            this.lblNhoNhat = new System.Windows.Forms.Label();
            this.KryptonSplitContainer1 = new System.Windows.Forms.Control();
            this.KryptonSplitContainer2 = new System.Windows.Forms.Control();
            this.grTonTai = new System.Windows.Forms.DataGridView();
            this.colThongKe = new System.Windows.Forms.TextBox();
            this.grThieu = new System.Windows.Forms.DataGridView();
            this.colOrderThieu = new System.Windows.Forms.TextBox();
            this.grMain = new System.Windows.Forms.Control();
            this.SuspendLayout();
            // 
            // No1UserControl1
            // 
            this.No1UserControl1.Size = new System.Drawing.Size(746, 538);
            this.No1UserControl1.Name = "No1UserControl1";
            // KryptonPanel1
            // 
            this.KryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonPanel1.Size = new System.Drawing.Size(746, 34);
            this.KryptonPanel1.Name = "KryptonPanel1";
            this.KryptonPanel1.TabIndex = 0;
            // btnTai
            // 
            this.btnTai.Location = new System.Drawing.Point(282, 4);
            this.btnTai.Size = new System.Drawing.Size(81, 26);
            this.btnTai.Text = "Tải dữ liệu";
            this.btnTai.Name = "btnTai";
            this.btnTai.TabIndex = 1;
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(5, 4);
            this.dtNgay.Size = new System.Drawing.Size(271, 24);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.TabIndex = 2;
            // KryptonPanel2
            // 
            this.KryptonPanel2.Location = new System.Drawing.Point(0, 505);
            this.KryptonPanel2.Size = new System.Drawing.Size(746, 33);
            this.KryptonPanel2.Name = "KryptonPanel2";
            this.KryptonPanel2.TabIndex = 1;
            // lblTongOrder
            // 
            this.lblTongOrder.Location = new System.Drawing.Point(519, 10);
            this.lblTongOrder.Size = new System.Drawing.Size(86, 13);
            this.lblTongOrder.Text = "Tổng số order";
            this.lblTongOrder.Name = "lblTongOrder";
            this.lblTongOrder.TabIndex = 10;
            // lblTrung
            // 
            this.lblTrung.Location = new System.Drawing.Point(360, 10);
            this.lblTrung.Size = new System.Drawing.Size(92, 13);
            this.lblTrung.Text = "Số order trùng:";
            this.lblTrung.Name = "lblTrung";
            this.lblTrung.TabIndex = 9;
            // lblLonNhat
            // 
            this.lblLonNhat.Location = new System.Drawing.Point(189, 10);
            this.lblLonNhat.Size = new System.Drawing.Size(109, 13);
            this.lblLonNhat.Text = "Số order lớn nhất:";
            this.lblLonNhat.Name = "lblLonNhat";
            this.lblLonNhat.TabIndex = 8;
            // lblNhoNhat
            // 
            this.lblNhoNhat.Location = new System.Drawing.Point(5, 10);
            this.lblNhoNhat.Size = new System.Drawing.Size(113, 13);
            this.lblNhoNhat.Text = "Số order nhỏ nhất:";
            this.lblNhoNhat.Name = "lblNhoNhat";
            this.lblNhoNhat.TabIndex = 7;
            // KryptonSplitContainer1
            // 
            this.KryptonSplitContainer1.Location = new System.Drawing.Point(0, 34);
            this.KryptonSplitContainer1.Size = new System.Drawing.Size(746, 471);
            this.KryptonSplitContainer1.Name = "KryptonSplitContainer1";
            this.KryptonSplitContainer1.TabIndex = 2;
            // KryptonSplitContainer2
            // 
            this.KryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.KryptonSplitContainer2.Size = new System.Drawing.Size(219, 471);
            this.KryptonSplitContainer2.Name = "KryptonSplitContainer2";
            this.KryptonSplitContainer2.TabIndex = 0;
            // grTonTai
            // 
            this.grTonTai.Location = new System.Drawing.Point(0, 0);
            this.grTonTai.Size = new System.Drawing.Size(219, 217);
            this.grTonTai.Name = "grTonTai";
            this.grTonTai.TabIndex = 0;
            this.grTonTai.ReadOnly = true;
            // colThongKe
            // 
            this.colThongKe.Name = "colThongKe";
            this.colThongKe.ReadOnly = true;
            // grThieu
            // 
            this.grThieu.Location = new System.Drawing.Point(0, 0);
            this.grThieu.Size = new System.Drawing.Size(219, 249);
            this.grThieu.Name = "grThieu";
            this.grThieu.TabIndex = 0;
            this.grThieu.ReadOnly = true;
            // colOrderThieu
            // 
            this.colOrderThieu.Name = "colOrderThieu";
            this.colOrderThieu.ReadOnly = true;
            // grMain
            // 
            this.grMain.Location = new System.Drawing.Point(0, 0);
            this.grMain.Size = new System.Drawing.Size(522, 471);
            this.grMain.Name = "grMain";
            this.grMain.TabIndex = 0;
            this.grMain.ReadOnly = true;
            // 
            // FormKiemsoatorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.No1UserControl1);
            this.Controls.Add(this.KryptonPanel1);
            this.Controls.Add(this.btnTai);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.KryptonPanel2);
            this.Controls.Add(this.lblTongOrder);
            this.Controls.Add(this.lblTrung);
            this.Controls.Add(this.lblLonNhat);
            this.Controls.Add(this.lblNhoNhat);
            this.Controls.Add(this.KryptonSplitContainer1);
            this.Controls.Add(this.KryptonSplitContainer2);
            this.Controls.Add(this.grTonTai);
            this.Controls.Add(this.colThongKe);
            this.Controls.Add(this.grThieu);
            this.Controls.Add(this.colOrderThieu);
            this.Controls.Add(this.grMain);
            this.Name = "FormKiemsoatorder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm soát order";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Control No1UserControl1;
        public System.Windows.Forms.Panel KryptonPanel1;
        public System.Windows.Forms.Button btnTai;
        public System.Windows.Forms.Control dtNgay;
        public System.Windows.Forms.Panel KryptonPanel2;
        public System.Windows.Forms.Label lblTongOrder;
        public System.Windows.Forms.Label lblTrung;
        public System.Windows.Forms.Label lblLonNhat;
        public System.Windows.Forms.Label lblNhoNhat;
        public System.Windows.Forms.Control KryptonSplitContainer1;
        public System.Windows.Forms.Control KryptonSplitContainer2;
        public System.Windows.Forms.DataGridView grTonTai;
        public System.Windows.Forms.TextBox colThongKe;
        public System.Windows.Forms.DataGridView grThieu;
        public System.Windows.Forms.TextBox colOrderThieu;
        public System.Windows.Forms.Control grMain;
    }
}