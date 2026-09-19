using System;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form CSDL Firebird (SFORM): AS NHANVIEN, \" +
    /// ID: 
    /// </summary>
    public partial class FormASNHANVIEN : Form
    {
        public string SFormId { get; } = "";
        public string SFormTitle { get; } = "AS NHANVIEN, \" +";
        public string SFormClassName { get; } = "FormASNHANVIEN";

        public FormASNHANVIEN()
        {
            InitializeComponent();
        }
    }
}
