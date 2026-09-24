using System;
using System.Windows.Forms;
using No1Lib.Sys;

namespace QuanLyNhaHang.Forms
{
    public partial class FormTheKhachHang : No1Form
    {
        public FormTheKhachHang()
        {
            InitializeComponent();
            
            // Wire events
            this.Load += new EventHandler(form_Load);
            this.KeyPress += new KeyPressEventHandler(form_KeyPress);
            this.KeyDown += new KeyEventHandler(form_KeyDown);
        }

        private void form_Load(object sender, EventArgs e)
        {
            // Implement logic here
        }

        private void form_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Implement logic here
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            // Implement logic here
        }
    }
}
