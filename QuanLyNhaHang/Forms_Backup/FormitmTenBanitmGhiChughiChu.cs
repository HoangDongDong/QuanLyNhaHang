using System;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form CSDL Firebird (SFORM): != itm.TenBan || itm.GhiChu != ghiChu ||
    /// ID: 
    /// </summary>
    public partial class FormitmTenBanitmGhiChughiChu : Form
    {
        public string SFormId { get; } = "";
        public string SFormTitle { get; } = "!= itm.TenBan || itm.GhiChu != ghiChu ||";
        public string SFormClassName { get; } = "FormitmTenBanitmGhiChughiChu";

        public FormitmTenBanitmGhiChughiChu()
        {
            InitializeComponent();
        }
    }
}
