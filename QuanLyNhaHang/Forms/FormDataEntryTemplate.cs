using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaHang.Forms
{
    public partial class FormDataEntryTemplate : Form
    {
        public Form DynamicForm { get; private set; }

        public FormDataEntryTemplate()
        {
            InitializeComponent();
        }

        public void EmbedDynamicForm(Form dynamicForm, string title)
        {
            this.DynamicForm = dynamicForm;
            this.Text = title;
            this.lblTitle.Text = title.ToUpper();
            
            // Adjust size based on dynamic form
            this.Size = new Size(dynamicForm.Width + 20, dynamicForm.Height + this.pnlHeader.Height + this.toolStrip1.Height + this.pnlFooter.Height + 40);
            
            dynamicForm.TopLevel = false;
            dynamicForm.FormBorderStyle = FormBorderStyle.None;
            dynamicForm.Dock = DockStyle.Fill;
            dynamicForm.Visible = true;
            
            this.pnlContent.Controls.Add(dynamicForm);
        }
    }
}
