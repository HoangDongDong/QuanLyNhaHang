using System;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form CSDL Firebird (SFORM): AS SO
    /// ID: 
    /// </summary>
    public partial class FormASSO : Form
    {
        public string SFormId { get; } = "";
        public string SFormTitle { get; } = "AS SO";
        public string SFormClassName { get; } = "FormASSO";

        public FormASSO()
        {
            InitializeComponent();
        }
    }
}
