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
using QuanLyNhaHang.Forms;
using Forms = QuanLyNhaHang.Forms.Forms;
using Tables = QuanLyNhaHang.Forms.Tables;
using Functions = QuanLyNhaHang.Forms.Functions;
using Menus = QuanLyNhaHang.Forms.Menus;
using Shared = QuanLyNhaHang.Forms.Shared;
using SystemConfig = QuanLyNhaHang.Services.SystemConfig;
using Config = No1Run.Config;

namespace No1Run
{
    public partial class KiemSoatOrder : No1Lib.Sys.No1UserControl, IRefreshable
    {
        public No1Lib.Sys.No1UserControl No1UserControl1 { get { return this; } }
        private bool _isInitialized = false;

        public KiemSoatOrder()
        {
            try
            {
                TDONHANG0Ae.EnsureNo1LibInitialized();
            }
            catch { }

            InitializeComponent();
            EnsureViewConfigs();
        }

        private void EnsureViewConfigs()
        {
            try
            {
                if (grMain != null && (grMain.ViewConfig == null || grMain.ViewConfig.Length == 0))
                {
                    ((System.ComponentModel.ISupportInitialize)(grMain)).BeginInit();
                    grMain.ViewConfig = Convert.FromBase64String(VIEWCONFIG_MAIN);
                    ((System.ComponentModel.ISupportInitialize)(grMain)).EndInit();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureViewConfigs error: " + ex.Message);
            }
        }

        public void grMain_CustomLoadData(object sender, CustomLoadDataArgs e)
        {
            if (dtNgay.FromDate != null)
            {
                e.And("NGAY >= @FROMDATE");
                e.Command.Parameters.Add("@FROMDATE", FbDbType.Date).Value = dtNgay.FromDate;
            }
            if (dtNgay.ToDate != null)
            {
                e.And("NGAY <= @TODATE");
                e.Command.Parameters.Add("@TODATE", FbDbType.Date).Value = dtNgay.ToDate;
            }
        }

        public void btnTai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void dtNgay_OnEditValueChanged(object sender, object value)
        {
            LoadData();
        }

        public void No1UserControl1_OnInit(object sender, EventArgs e)
        {
            if (_isInitialized) return;
            _isInitialized = true;

            dtNgay.FromDate = Config.Db.DbDate;
            dtNgay.ToDate = dtNgay.FromDate;

            LoadData();
        }

        #region IRefreshable Members

        public new void DoRefresh()
        {
            LoadData();
        }

        #endregion

        private void LoadData()
        {
            grMain.LoadData();

            Dictionary<int, string> dic = new Dictionary<int, string>();
            DataTable dtLoi = new DataTable();
            dtLoi.Columns.Add("THONGKE", typeof(string));
            List<int> list = new List<int>();
            List<int> lstTrung = new List<int>();

            DataTable dtCo = new DataTable();
            dtCo.Columns.Add("THONGKE", typeof(string));

            DataTable dt = grMain.DataTable;
            if (dt != null)
            {
                //add vào dic
                foreach (DataRow r in dt.Rows)
                {
                    string orders = r.Table.Columns.Contains("SOORDER") && r["SOORDER"] != null ? r["SOORDER"].ToString() : "";
                    string soBill = "";
                    if (r.Table.Columns.Contains("NGAY") && r["NGAY"] != null && r["NGAY"] != DBNull.Value)
                    {
                        soBill += ((DateTime)r["NGAY"]).ToString("dd/MM/yyyy") + "-";
                    }
                    if (r.Table.Columns.Contains("NAME") && r["NAME"] != null)
                    {
                        soBill += r["NAME"].ToString();
                    }

                    string[] codes = orders.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string code in codes)
                    {
                        int result;
                        if (int.TryParse(code.Trim(), out result))
                        {
                            if (dic.ContainsKey(result))
                            {
                                dic[result] = dic[result] + ", " + soBill;
                                if (!lstTrung.Contains(result)) lstTrung.Add(result);
                            }
                            else
                            {
                                list.Add(result);
                                dic.Add(result, soBill);
                            }
                        }
                        else
                        {
                            AddRow("Lỗi số order '" + code + "' ở bill '" + soBill + "'", dtLoi);
                        }
                    }
                }
            }

            //tìm ra các dải thiếu
            if (list.Count > 0)
            {
                list.Sort();
                int i = 0;
                int stop = 0;
                while (i < list.Count)
                {
                    int start = list[i];
                    if (i > 0)
                    {
                        int stop_miss = start - 1;
                        int start_miss = stop + 1;
                        if (start_miss == stop_miss)
                        {
                            AddRow("Thiếu order " + start_miss.ToString(), dtLoi);
                        }
                        else if (start_miss < stop_miss)
                        {
                            AddRow("Thiếu order " + start_miss.ToString() + "-" + stop_miss.ToString(), dtLoi);
                        }
                    }
                    int j = i + 1;
                    while (j < list.Count && list[j] - start == j - i)
                    {
                        j++;
                    }
                    stop = list[j - 1];
                    //chỉ có 1 order
                    if (start == stop)
                    {
                        AddRow(start.ToString(), dtCo);
                    }
                    else
                    {
                        AddRow(start.ToString() + "-" + stop.ToString(), dtCo);
                    }
                    i = j;
                }
            }

            //trùng
            foreach (int trung in lstTrung)
            {
                AddRow("Trùng số order " + trung.ToString("n0") + ", các bill: " + dic[trung], dtLoi);
            }

            grTonTai.DataSource = dtCo;
            grThieu.DataSource = dtLoi;

            lblLonNhat.Text = "Số order lớn nhất: " + (list.Count > 0 ? list[list.Count - 1].ToString("n0") : "");
            lblNhoNhat.Text = "Số order nhỏ nhất: " + (list.Count > 0 ? list[0].ToString("n0") : "");
            lblTongOrder.Text = "Tổng order: " + list.Count.ToString("n0");
            lblTrung.Text = "Số order trùng: " + lstTrung.Count.ToString("n0");
        }

        private void AddRow(string data, DataTable dt)
        {
            DataRow r = dt.NewRow();
            r["THONGKE"] = data;
            dt.Rows.Add(r);
        }
    }
}

namespace QuanLyNhaHang.Forms
{
    public class KiemSoatOrder : No1Run.KiemSoatOrder
    {
    }
}
