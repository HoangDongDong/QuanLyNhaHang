using System;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form CSDL Firebird (SFORM): Hóa đơn bán hàng
    /// ID: 5f029a5b-8ec2-4229-bd1d-03fed9569db2
    /// </summary>
    public partial class FormHoaDonBanHang : Form
    {
        public string SFormId { get; } = "5f029a5b-8ec2-4229-bd1d-03fed9569db2";
        public string SFormTitle { get; } = "Hóa đơn bán hàng";
        public string SFormClassName { get; } = "FormHoaDonBanHang";

        public FormHoaDonBanHang()
        {
            InitializeComponent();
        }
    }
}
