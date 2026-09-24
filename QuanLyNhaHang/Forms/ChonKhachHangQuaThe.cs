using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class ChonKhachHangQuaThe : No1Form
    {
        public ChonKhachHangQuaThe()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(form_KeyPress);
            this.Load += new EventHandler(form_Load);
            this.KeyDown += new KeyEventHandler(form_KeyDown);
        }

        private void form_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xử lý sự kiện KeyPress
        }

        private void form_Load(object sender, EventArgs e)
        {
            // Xử lý khi load
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            // Xử lý sự kiện KeyDown
        }
    }
}
