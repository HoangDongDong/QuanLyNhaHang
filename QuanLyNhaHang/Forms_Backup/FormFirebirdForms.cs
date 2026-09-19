using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang
{
    public partial class FormFirebirdForms : Form
    {
        private List<FormModel> _allForms = new List<FormModel>();

        public FormFirebirdForms()
        {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            this.Load += (s, e) => ReloadData();

            btnReload.Click += (s, e) => ReloadData();

            txtSearch.TextChanged += (s, e) => FilterData();

            dgvForms.SelectionChanged += (s, e) => ShowSelectedDetails();
        }

        private void ReloadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _allForms = DbFormService.LoadAllForms();
                FilterData();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FilterData()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            dgvForms.Rows.Clear();

            var filtered = _allForms.Where(f =>
                string.IsNullOrEmpty(keyword) ||
                (f.Name != null && f.Name.ToLower().Contains(keyword)) ||
                (f.ClassName != null && f.ClassName.ToLower().Contains(keyword))
            ).ToList();

            foreach (var item in filtered)
            {
                int rowIndex = dgvForms.Rows.Add(item.Name, item.ClassName, item.FormType);
                dgvForms.Rows[rowIndex].Tag = item;
            }

            lblCount.Text = $"Tổng số Form: {filtered.Count} / {_allForms.Count} form";

            if (dgvForms.Rows.Count > 0)
            {
                dgvForms.Rows[0].Selected = true;
                ShowSelectedDetails();
            }
            else
            {
                ClearDetails();
            }
        }

        private void ShowSelectedDetails()
        {
            if (dgvForms.SelectedRows.Count > 0 && dgvForms.SelectedRows[0].Tag is FormModel model)
            {
                txtCode.Text = string.IsNullOrEmpty(model.Code) ? "// (Không có mã nguồn CODE trong CSDL)" : model.Code;
                txtDesignCode.Text = string.IsNullOrEmpty(model.DesignCode) ? "// (Không có mã thiết kế DESIGNCODE trong CSDL)" : model.DesignCode;
                txtAeLayout.Text = string.IsNullOrEmpty(model.AeLayout) ? "// (Không có thông tin AELAYOUT trong CSDL)" : model.AeLayout;
            }
            else
            {
                ClearDetails();
            }
        }

        private void ClearDetails()
        {
            txtCode.Text = string.Empty;
            txtDesignCode.Text = string.Empty;
            txtAeLayout.Text = string.Empty;
        }
    }
}
