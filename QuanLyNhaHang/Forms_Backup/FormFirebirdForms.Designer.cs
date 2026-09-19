namespace QuanLyNhaHang
{
    partial class FormFirebirdForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvForms = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDetails = new System.Windows.Forms.TabControl();
            this.tabCode = new System.Windows.Forms.TabPage();
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.tabDesignCode = new System.Windows.Forms.TabPage();
            this.txtDesignCode = new System.Windows.Forms.RichTextBox();
            this.tabLayout = new System.Windows.Forms.TabPage();
            this.txtAeLayout = new System.Windows.Forms.RichTextBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForms)).BeginInit();
            this.tabDetails.SuspendLayout();
            this.tabCode.SuspendLayout();
            this.tabDesignCode.SuspendLayout();
            this.tabLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnReload);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(834, 45);
            this.pnlTop.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(12, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(121, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm tên Form:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(139, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 24);
            this.txtSearch.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblCount.Location = new System.Drawing.Point(415, 14);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(115, 15);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Tổng số Form: 0 form";
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.BackColor = System.Drawing.Color.White;
            this.btnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(720, 8);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(102, 28);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "🔄 Nạp từ CSDL";
            this.btnReload.UseVisualStyleBackColor = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 45);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvForms);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabDetails);
            this.splitContainer.Size = new System.Drawing.Size(834, 466);
            this.splitContainer.SplitterDistance = 380;
            this.splitContainer.TabIndex = 1;
            // 
            // dgvForms
            // 
            this.dgvForms.AllowUserToAddRows = false;
            this.dgvForms.AllowUserToDeleteRows = false;
            this.dgvForms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvForms.BackgroundColor = System.Drawing.Color.White;
            this.dgvForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colClassName,
            this.colFormType});
            this.dgvForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvForms.Location = new System.Drawing.Point(0, 0);
            this.dgvForms.MultiSelect = false;
            this.dgvForms.Name = "dgvForms";
            this.dgvForms.ReadOnly = true;
            this.dgvForms.RowHeadersVisible = false;
            this.dgvForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvForms.Size = new System.Drawing.Size(380, 466);
            this.dgvForms.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.HeaderText = "Tên Form (NAME)";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colClassName
            // 
            this.colClassName.HeaderText = "Mã Class (CLASSNAME)";
            this.colClassName.Name = "colClassName";
            this.colClassName.ReadOnly = true;
            // 
            // colFormType
            // 
            this.colFormType.FillWeight = 40F;
            this.colFormType.HeaderText = "Loại";
            this.colFormType.Name = "colFormType";
            this.colFormType.ReadOnly = true;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.tabCode);
            this.tabDetails.Controls.Add(this.tabDesignCode);
            this.tabDetails.Controls.Add(this.tabLayout);
            this.tabDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDetails.Location = new System.Drawing.Point(0, 0);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.SelectedIndex = 0;
            this.tabDetails.Size = new System.Drawing.Size(450, 466);
            this.tabDetails.TabIndex = 0;
            // 
            // tabCode
            // 
            this.tabCode.Controls.Add(this.txtCode);
            this.tabCode.Location = new System.Drawing.Point(4, 24);
            this.tabCode.Name = "tabCode";
            this.tabCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabCode.Size = new System.Drawing.Size(442, 438);
            this.tabCode.TabIndex = 0;
            this.tabCode.Text = "C# Code (CODE)";
            this.tabCode.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtCode.Location = new System.Drawing.Point(3, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(436, 432);
            this.txtCode.TabIndex = 0;
            this.txtCode.Text = "";
            // 
            // tabDesignCode
            // 
            this.tabDesignCode.Controls.Add(this.txtDesignCode);
            this.tabDesignCode.Location = new System.Drawing.Point(4, 24);
            this.tabDesignCode.Name = "tabDesignCode";
            this.tabDesignCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesignCode.Size = new System.Drawing.Size(442, 438);
            this.tabDesignCode.TabIndex = 1;
            this.tabDesignCode.Text = "Design Code (DESIGNCODE)";
            this.tabDesignCode.UseVisualStyleBackColor = true;
            // 
            // txtDesignCode
            // 
            this.txtDesignCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtDesignCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesignCode.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesignCode.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtDesignCode.Location = new System.Drawing.Point(3, 3);
            this.txtDesignCode.Name = "txtDesignCode";
            this.txtDesignCode.ReadOnly = true;
            this.txtDesignCode.Size = new System.Drawing.Size(436, 432);
            this.txtDesignCode.TabIndex = 0;
            this.txtDesignCode.Text = "";
            // 
            // tabLayout
            // 
            this.tabLayout.Controls.Add(this.txtAeLayout);
            this.tabLayout.Location = new System.Drawing.Point(4, 24);
            this.tabLayout.Name = "tabLayout";
            this.tabLayout.Padding = new System.Windows.Forms.Padding(3);
            this.tabLayout.Size = new System.Drawing.Size(442, 438);
            this.tabLayout.TabIndex = 2;
            this.tabLayout.Text = "Layout (AELAYOUT)";
            this.tabLayout.UseVisualStyleBackColor = true;
            // 
            // txtAeLayout
            // 
            this.txtAeLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtAeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAeLayout.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAeLayout.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtAeLayout.Location = new System.Drawing.Point(3, 3);
            this.txtAeLayout.Name = "txtAeLayout";
            this.txtAeLayout.ReadOnly = true;
            this.txtAeLayout.Size = new System.Drawing.Size(436, 432);
            this.txtAeLayout.TabIndex = 0;
            this.txtAeLayout.Text = "";
            // 
            // FormFirebirdForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 511);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlTop);
            this.Name = "FormFirebirdForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách Form trong CSDL Firebird (Bảng sForm)";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForms)).EndInit();
            this.tabDetails.ResumeLayout(false);
            this.tabCode.ResumeLayout(false);
            this.tabDesignCode.ResumeLayout(false);
            this.tabLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvForms;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormType;
        private System.Windows.Forms.TabControl tabDetails;
        private System.Windows.Forms.TabPage tabCode;
        private System.Windows.Forms.RichTextBox txtCode;
        private System.Windows.Forms.TabPage tabDesignCode;
        private System.Windows.Forms.RichTextBox txtDesignCode;
        private System.Windows.Forms.TabPage tabLayout;
        private System.Windows.Forms.RichTextBox txtAeLayout;
    }
}
