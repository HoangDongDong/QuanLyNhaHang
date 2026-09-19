using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class FormDatabase : Form
    {
        public string SelectedDbName { get; private set; } = "DEMO";

        public FormDatabase()
        {
            InitializeComponent();
            LoadSampleData();
            RegisterEvents();
        }

        private void LoadSampleData()
        {
            lstDatabases.Items.Clear();

            var data = new[]
            {
                new { Name = "DEMO", Path = @"C:\Program Files (x86)\TAN AN PHAT\POS\v6.0\Database" },
                new { Name = "DEMO", Path = @"D:\taifirebird" },
                new { Name = "p", Path = @"C:\Users\acer\Desktop\DB" },
                new { Name = "QuanLyBar", Path = @"localhost" },
                new { Name = "new", Path = @"D:\taifirebird" },
                new { Name = "TEMPLATE", Path = @"C:\Program Files (x86)\TAN AN PHAT\POS\v6.0\Data" },
                new { Name = "DEMO", Path = @"D:\taifirebird" },
                new { Name = "SS", Path = @"C:\Users\acer\Desktop\DB" },
                new { Name = "DEMO", Path = @"C:\Users\acer\Desktop\DB" },
                new { Name = "moi", Path = @"C:\Users\acer\Downloads" },
                new { Name = "HIHI", Path = @"D:\saoluu" }
            };

            foreach (var item in data)
            {
                ListViewItem lvi = new ListViewItem(item.Name);
                lvi.SubItems.Add(item.Path);
                lstDatabases.Items.Add(lvi);
            }

            if (lstDatabases.Items.Count > 0)
            {
                lstDatabases.Items[0].Selected = true;
            }
        }

        private void RegisterEvents()
        {
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            btnSelect.Click += (s, e) => SelectCurrentItem();

            lstDatabases.DoubleClick += (s, e) => SelectCurrentItem();

            lblOpenFile.Click += (s, e) => OpenConnectDbForm();
            lblEdit.Click += (s, e) => OpenConnectDbForm();
            lblDelete.Click += (s, e) =>
            {
                using (FormFirebirdForms frmFb = new FormFirebirdForms())
                {
                    frmFb.ShowDialog(this);
                }
            };
        }

        private void OpenConnectDbForm()
        {
            using (FormConnectDb frmConnect = new FormConnectDb())
            {
                if (frmConnect.ShowDialog(this) == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frmConnect.DatabasePath))
                    {
                        SelectedDbName = System.IO.Path.GetFileNameWithoutExtension(frmConnect.DatabasePath);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void SelectCurrentItem()
        {
            if (lstDatabases.SelectedItems.Count > 0)
            {
                SelectedDbName = lstDatabases.SelectedItems[0].Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
