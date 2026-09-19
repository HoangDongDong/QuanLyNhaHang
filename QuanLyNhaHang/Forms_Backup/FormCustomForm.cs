using System;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form CSDL Firebird (SFORM): : \"\");
    /// ID: 
    /// </summary>
    public partial class FormCustomForm : Form
    {
        public string SFormId { get; } = "";
        public string SFormTitle { get; } = ": \"\");";
        public string SFormClassName { get; } = "FormCustomForm";

        public FormCustomForm()
        {
            InitializeComponent();
        }
    }
}
