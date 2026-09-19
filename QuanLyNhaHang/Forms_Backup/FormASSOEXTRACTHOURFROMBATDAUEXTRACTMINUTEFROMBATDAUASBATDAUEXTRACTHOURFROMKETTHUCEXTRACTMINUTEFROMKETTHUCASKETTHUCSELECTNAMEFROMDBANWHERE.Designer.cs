namespace QuanLyNhaHang
{
    partial class FormASSOEXTRACTHOURFROMBATDAUEXTRACTMINUTEFROMBATDAUASBATDAUEXTRACTHOURFROMKETTHUCEXTRACTMINUTEFROMKETTHUCASKETTHUCSELECTNAMEFROMDBANWHERE
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormASSOEXTRACTHOURFROMBATDAUEXTRACTMINUTEFROMBATDAUASBATDAUEXTRACTHOURFROMKETTHUCEXTRACTMINUTEFROMKETTHUCASKETTHUCSELECTNAMEFROMDBANWHERE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FormASSOEXTRACTHOURFROMBATDAUEXTRACTMINUTEFROMBATDAUASBATDAUEXTRACTHOURFROMKETTHUCEXTRACTMINUTEFROMKETTHUCASKETTHUCSELECTNAMEFROMDBANWHERE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AS SO, EXTRACT(HOUR FROM BATDAU) || ':' || EXTRACT(MINUTE FROM BATDAU) AS BATDAU, EXTRACT(HOUR FROM KETTHUC) || ':' || EXTRACT(MINUTE FROM KETTHUC) AS KETTHUC, (SELECT NAME FROM DBAN WHERE";
            this.ResumeLayout(false);
        }
    }
}
