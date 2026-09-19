using System;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form CSDL Firebird (SFORM): Tạm ứng đơn hàng
    /// ID: 064236d2-8fcc-415b-80cb-420e69f19c0c
    /// </summary>
    public partial class FormTamUngDonHang : Form
    {
        public string SFormId { get; } = "064236d2-8fcc-415b-80cb-420e69f19c0c";
        public string SFormTitle { get; } = "Tạm ứng đơn hàng";
        public string SFormClassName { get; } = "FormTamUngDonHang";

        public FormTamUngDonHang()
        {
            InitializeComponent();
        }
    }
}
