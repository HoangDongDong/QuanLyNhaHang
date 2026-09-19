using System;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form CSDL Firebird (SFORM): AS MATHANG, (SELECT NAME FROM DMATHANG C WHERE
    /// ID: 
    /// </summary>
    public partial class FormASMATHANGSELECTNAMEFROMDMATHANGCWHERE : Form
    {
        public string SFormId { get; } = "";
        public string SFormTitle { get; } = "AS MATHANG, (SELECT NAME FROM DMATHANG C WHERE";
        public string SFormClassName { get; } = "FormASMATHANGSELECTNAMEFROMDMATHANGCWHERE";

        public FormASMATHANGSELECTNAMEFROMDMATHANGCWHERE()
        {
            InitializeComponent();
        }
    }
}
