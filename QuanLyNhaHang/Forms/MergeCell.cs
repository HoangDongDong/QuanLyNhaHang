using System;
using System.Drawing;
using System.Windows.Forms;

namespace No1Run
{
    public class MergeCell : DataGridViewTextBoxCell
    {
        public int LeftColumn;
        public int RightColumn;
        public StringAlignment TextAllignment;
        public Color ForeColor;
        public Color BaclColor;
        public Image EndImage;
        public Image StartImage;
        public Image GroupImage;
        public Image ChifleyImage;
        public Image FillImage;
        public string TDATHANGID;
        public new bool Resizable;

        public MergeCell()
        {
            this.LeftColumn = 0;
            this.RightColumn = 0;
            this.TextAllignment = StringAlignment.Near;
            this.ForeColor = Color.Black;
            this.BaclColor = SystemColors.Control;
            this.EndImage = null;
            this.StartImage = null;
            this.FillImage = null;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            int num = this.ColumnIndex - this.LeftColumn;
            Pen pen = new Pen(Brushes.Black);
            if (FillImage == null)
            {
                graphics.FillRectangle(new SolidBrush(this.BaclColor), cellBounds);
            }
            else
            {
                TextureBrush brush = new TextureBrush(this.FillImage);
                graphics.FillRectangle(brush, cellBounds);
            }
            graphics.DrawLine(new Pen(new SolidBrush(SystemColors.ControlDark)), cellBounds.Left, cellBounds.Bottom - 1, cellBounds.Right, cellBounds.Bottom - 1);
            if (this.ColumnIndex == this.RightColumn)
            {
                graphics.DrawLine(new Pen(new SolidBrush(SystemColors.ControlDark)), cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom);
                if (this.EndImage != null)
                {
                    graphics.DrawImage(this.EndImage, cellBounds.Right - 22, cellBounds.Top, 21, 21);
                }
            }
            if (this.StartImage != null & this.ColumnIndex == this.LeftColumn)
            {
                graphics.DrawImage(this.StartImage, cellBounds.Left - 1 + 5, cellBounds.Top + 3, this.StartImage.Width + 2, 14);
            }

            if (this.ChifleyImage != null & this.ColumnIndex == this.LeftColumn)
            {
                graphics.DrawImage(this.ChifleyImage, cellBounds.Left - 1 + 12, cellBounds.Top + 3, this.ChifleyImage.Width + 2, 14);
            }

            if (this.GroupImage != null & this.ColumnIndex == this.LeftColumn)
            {
                graphics.DrawImage(this.GroupImage, cellBounds.Left - 1, cellBounds.Top, this.GroupImage.Width + 1, 21);
            }
            RectangleF empty = RectangleF.Empty;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = this.TextAllignment;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.Word;
            int num2 = 0;
            int arg_2AD_0 = this.LeftColumn;
            int num3 = this.RightColumn;
            int num4 = arg_2AD_0;
            while (true)
            {
                int arg_2E8_0 = num4;
                int num5 = num3;
                if (arg_2E8_0 > num5)
                {
                    break;
                }
                num2 += this.OwningRow.Cells[num4].Size.Width;
                num4++;
            }

            int num6 = 0;
            int arg_309_0 = this.LeftColumn;
            int num7 = this.ColumnIndex - 1;
            num4 = arg_309_0;
            while (true)
            {
                int arg_346_0 = num4;
                int num5 = num7;
                if (arg_346_0 > num5)
                {
                    break;
                }
                num6 += this.OwningRow.Cells[num4].Size.Width;
                num4++;
            }
            string s = this.OwningRow.Cells[this.LeftColumn].Value != null ? this.OwningRow.Cells[this.LeftColumn].Value.ToString() : "";
            SolidBrush brush2 = new SolidBrush(this.ForeColor);
            System.Drawing.Font font = new System.Drawing.Font("Arial", 8f, FontStyle.Regular);
            if (this.StartImage == null)
            {
                if (this.GroupImage == null)
                {
                    empty = new RectangleF((float)(cellBounds.Left - num6), (float)(unchecked((double)cellBounds.Top + (double)cellBounds.Height / 2.0 - (double)font.Height / 2.0)), (float)num2, (float)font.Height);
                }
                else
                {
                    empty = new RectangleF((float)(cellBounds.Left - num6 + 5), (float)(unchecked((double)cellBounds.Top + (double)cellBounds.Height / 2.0 - (double)font.Height / 2.0)), (float)num2, (float)font.Height);
                }
            }
            else
            {
                empty = new RectangleF((float)(cellBounds.Left - num6 + this.StartImage.Width + 5), (float)(unchecked((double)cellBounds.Top + (double)cellBounds.Height / 2.0 - (double)font.Height / 2.0)), (float)num2, (float)font.Height);
            }

            if (this.ChifleyImage != null)
            {
                if (this.StartImage == null)
                {
                    empty = RectangleF.Empty;
                    empty = new RectangleF((float)(cellBounds.Left - num6 + this.ChifleyImage.Width + 5), (float)(unchecked((double)cellBounds.Top + (double)cellBounds.Height / 2.0 - (double)font.Height / 2.0)), (float)num2, (float)font.Height);
                }
                else
                {
                    empty = new RectangleF((float)(cellBounds.Left - num6 + this.ChifleyImage.Width + 5), (float)(unchecked((double)cellBounds.Top + (double)cellBounds.Height / 2.0 - (double)font.Height / 2.0)), (float)num2, (float)font.Height);
                }
            }
            graphics.DrawString(s, font, brush2, empty, stringFormat);
        }

        public void MakeMerge(ref DataGridView dg, int intRowIndex, int intStartIndex, int intEndIndex, Color BackColor, Color ForeColor, string strDisplayData, string strTagString, Image img, string strToolTip, Image imgStart, Image imgFill, Image imgGroupImage, Image imgChifleyImage, string TDATHANGID, bool Resizable)
        {
            for (int i = intStartIndex; i <= intEndIndex; i++)
            {
                dg.Rows[intRowIndex].Cells[i] = new MergeCell();
                MergeCell clsMergeCell = (MergeCell)dg.Rows[intRowIndex].Cells[i];
                if (strDisplayData != null)
                {
                    dg.Rows[intRowIndex].Cells[i].Value = strDisplayData;
                }
                if (strTagString != null)
                {
                    dg.Rows[intRowIndex].Cells[i].Tag = strTagString;
                }
                clsMergeCell.LeftColumn = intStartIndex;
                clsMergeCell.RightColumn = intEndIndex;
                clsMergeCell.ForeColor = ForeColor;
                clsMergeCell.BaclColor = BackColor;
                clsMergeCell.FillImage = imgFill;
                clsMergeCell.TDATHANGID = TDATHANGID;
                clsMergeCell.Resizable = Resizable;
                if (img != null)
                {
                    clsMergeCell.EndImage = img;
                }
                clsMergeCell.ToolTipText = strToolTip;
                if (imgStart != null)
                {
                    clsMergeCell.StartImage = imgStart;
                }
                if (imgGroupImage != null)
                {
                    clsMergeCell.GroupImage = imgGroupImage;
                }
                if (imgChifleyImage != null)
                {
                    clsMergeCell.ChifleyImage = imgChifleyImage;
                }
            }
        }
    }
}
