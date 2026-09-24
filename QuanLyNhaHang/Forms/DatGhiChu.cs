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
    public partial class DatGhiChu : No1Lib.Sys.No1Form
    {
        public DatGhiChu()
        {
            InitializeComponent();
        }

        public No1Lib.Sys.No1Form No1Form1 => this;
        public string GhiChu => txtNote.Text;

        public void SetData(string ghiChu)
        {
            txtNote.Text = ghiChu;

            if (tvGhiChu != null && tvGhiChu.tvMain != null)
            {
                tvGhiChu.tvMain.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tvMain_NodeMouseDoubleClick);
            }
            txtNote.SelectAll();
        }

        void tvMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;

            txtNote.Text = e.Node.Text;
            btnOK.PerformClick();
        }  

        public void tvGhiChu_OnFocusedNodeChanged(TreeNode node, DataRow r, string ID, TreeItemType type)
        {
            if (node != null)
            {
                txtNote.Text = node.Text;
            }
        }
    }
}
