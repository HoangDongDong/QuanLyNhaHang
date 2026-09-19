using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Lưu vết hoạt động (ID: ac206bb6-0236-48a6-b558-b674e015c21c)
    /// </summary>
    public partial class FormLuuvethoatong : Form
    {
        public string SFormId { get; } = "ac206bb6-0236-48a6-b558-b674e015c21c";
        public string SFormTitle { get; } = "Lưu vết hoạt động";

        public FormLuuvethoatong()
        {
            InitializeComponent();
        }


                #region IRefreshable Members

                public void DoRefresh()
                    LoadData();

                #endregion


        		public void txtLoc_TextChanged(object sender, EventArgs e)
                    grMain.GridView.Filter = txtLoc.Text;

        		public void grHoaDon_SelectionChanged(object sender, EventArgs e)
                    grMain.LoadData();


        		public void grHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
                    try
                        DataRow r = (grHoaDon.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                        int loai = ConvertTo.Int(r["LOAI"]);
                        if (loai == 1)
                            e.CellStyle.ForeColor = Color.Red;
                        else if (loai == 2)
                            e.CellStyle.ForeColor = Color.Blue;
                    catch


        		public void dtNgay_OnEditValueChanged(object sender, object value)
                    LoadData();

                public void lueNhanVien_OnEditValueChanged(object sender, object value)
                    LoadData();


        		public void No1UserControl1_OnAddedToTab(object sender, EventArgs e)
                    DateTime today = Config.Db.DbDate;           
                    dtNgay.FromDate = today;
                    dtNgay.ToDate = today;
                    lueNhanVien.LoadData(Tables.SUSER);
                    btnXoaLuuVet.Visible = DbConfig.IsAdmin && (Control.ModifierKeys == (Keys.Shift | Keys.Control));
                    grMain.GridView.CellFormatting += new DataGridViewCellFormattingEventHandler(GridView_CellFormatting);
                    grMain.GridView.OnCustomFilter += new MiscDataGridView.OnCustomFilterHandler(GridView_OnCustomFilter);
                    LoadData();

                    grMain.LoadData();
                    (grMain.GridView.Columns["GIO"] as CalendarColumn).Format = "HH:mm:ss";

                    foreach (DataGridViewColumn col in grMain.GridView.Columns) col.SortMode = DataGridViewColumnSortMode.NotSortable;


        		public void txtSoHoaDon_KeyDown(object sender, KeyEventArgs e)
                    if (e.KeyCode == Keys.Enter) btnRefresh.PerformClick();
        #endregion
    }
}