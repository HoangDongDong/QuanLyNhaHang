using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using No1Lib.Sys;
using No1Lib.Db;
using No1Lib.Utils;
using FirebirdSql.Data.FirebirdClient;
using System.ComponentModel;
using System.Collections.Generic;

namespace No1Run
{
    public partial class TraDo : No1Lib.Sys.No1Form
    {
        public No1Lib.Sys.No1Form form => this;

        public TraDo()
        {
            InitializeComponent();
        }

        public event CancelEventHandler BeforeSave;

        public void SetData(string TDONHANGID)
        {
            string sql = @"SELECT DMATHANGID, DONGIA, TDONHANGCHITIET.DDONVITINHID, TILEGIAMGIA, TENHANG, SUM(SLXUATCHUAQUYDOI) AS SLORDER, 
CAST(0 AS DECIMAL(18,2)) AS SLTRALAI, SUM(SLXUATCHUAQUYDOI) AS SLSUDUNG 
FROM TDONHANGCHITIET INNER JOIN DMATHANG ON TDONHANGCHITIET.DMATHANGID = DMATHANG.ID
WHERE TDONHANGID='{0}' AND DMATHANGID <> 'KM'
AND COALESCE(XUATVATTU, 0) = 0
AND COALESCE(DLOAIMATHANGID, '') <> '7'
AND COALESCE(COMBOPARENTID, '') = ''
GROUP BY DMATHANGID, TENHANG, DONGIA, TILEGIAMGIA, DDONVITINHID
HAVING SUM(SLXUATCHUAQUYDOI)>0 ORDER BY TENHANG";
            grTraLai.DataSource = Config.Db.GetTable(string.Format(sql, TDONHANGID));
        }

        public void btnCancel_Click(object sender, EventArgs e)
        {
            form.DialogResult = DialogResult.Cancel;
            form.Close();
        }
        
        public void btnOk_Click(object sender, EventArgs e)
        {
            DataTable dt = grTraLai.DataSource as DataTable;
            CancelEventArgs ce = new CancelEventArgs();
            ce.Cancel = false;
            if (BeforeSave != null) BeforeSave(dt, ce);
            if (ce.Cancel) return;
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    decimal slOrder = ConvertTo.Decimal(r["SLORDER"]);
                    decimal slReturn = ConvertTo.Decimal(r["SLTRALAI"]);
                    if (slReturn > slOrder)
                    {
                        string msg = "Số lượng trả lại ({0}) vượt quá số lượng gọi ({1})";
                        Msg.ShowWarning(string.Format(msg, slReturn, slOrder));
                        return;
                    }
                }
            }
            
            form.DialogResult = DialogResult.OK;
            form.Close();
        }

        public void grTraLai_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (colSLSUDUNG == null || colTRALAI == null || e.RowIndex < 0) return;
            if (e.ColumnIndex == colSLSUDUNG.Index)
            {
                DataRow row = grTraLai.SelectedRow;
                if (row == null) return;
                decimal slSuDung = ConvertTo.Decimal(row["SLSUDUNG"]);
                decimal slOrder = ConvertTo.Decimal(row["SLORDER"]);
                if (slSuDung > slOrder)
                {
                    row["SLTRALAI"] = 0;
                    row["SLSUDUNG"] = 0;
                }
                else
                    row["SLTRALAI"] = slOrder - slSuDung;
                grTraLai.InvalidateRow(e.RowIndex);
            }
            else if (e.ColumnIndex == colTRALAI.Index)
            {
                DataRow row = grTraLai.SelectedRow;                
                if (row == null) return;
                decimal slOrder = ConvertTo.Decimal(row["SLORDER"]);
                decimal slReturn = ConvertTo.Decimal(row["SLTRALAI"]);
                if (slReturn > slOrder)
                {
                    row["SLTRALAI"] = 0;
                    row["SLSUDUNG"] = 0;
                }
                else
                    row["SLSUDUNG"] = slOrder - slReturn;
                grTraLai.InvalidateRow(e.RowIndex);
            }            
        }
    }
}
