using System;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form CSDL Firebird (SFORM): AS NHANVIEN, DCALAMVIEC.NAME AS CA,
    /// ID: 
    /// </summary>
    public partial class FormASNHANVIENDCALAMVIECNAMEASCA : Form
    {
        public string SFormId { get; } = "";
        public string SFormTitle { get; } = "AS NHANVIEN, DCALAMVIEC.NAME AS CA,";
        public string SFormClassName { get; } = "FormASNHANVIENDCALAMVIECNAMEASCA";

        public FormASNHANVIENDCALAMVIECNAMEASCA()
        {
            InitializeComponent();
        }
    }
}
