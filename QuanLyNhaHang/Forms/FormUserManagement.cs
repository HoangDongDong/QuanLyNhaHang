using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.Forms
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            // Populate TreeView Groups
            TreeNode root = new TreeNode("Tất cả");
            root.ImageIndex = 0;
            root.Nodes.Add(new TreeNode("Thu ngân"));
            root.Nodes.Add(new TreeNode("Thủ kho"));
            root.Nodes.Add(new TreeNode("Kế toán"));
            root.Nodes.Add(new TreeNode("Quản lý"));
            root.Nodes.Add(new TreeNode("Phục vụ"));
            tvGroups.Nodes.Add(root);
            tvGroups.ExpandAll();

            // Populate DataGridView Users
            dgvUsers.Rows.Add(1, "phucvu1");
            dgvUsers.Rows.Add(2, "123456");
            dgvUsers.Rows.Add(3, "123");
            dgvUsers.Rows.Add(4, "tn");
            dgvUsers.Rows.Add(5, "tk");
            dgvUsers.Rows.Add(6, "kt");
            dgvUsers.Rows.Add(7, "ql");
            
            // Highlight the first row
            if(dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Rows[0].DefaultCellStyle.BackColor = Color.Orange;
                dgvUsers.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
