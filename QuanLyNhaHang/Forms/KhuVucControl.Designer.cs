namespace QuanLyNhaHang.Forms
{
    partial class KhuVucControl
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
            this.components = new System.ComponentModel.Container();
            this.lst = new No1Lib.Sys.DoublebufferedListView();
            this.mnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mởBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởBànTừĐặtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.chuyểnBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngắtGiờToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gộpBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hủyHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.AllowDrop = true;
            this.lst.ContextMenuStrip = this.mnu;
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.OwnerDraw = true;
            this.lst.Size = new System.Drawing.Size(663, 519);
            this.lst.TabIndex = 0;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lst_DrawItem);
            this.lst.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lst_ItemDrag);
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            this.lst.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.lst.DragOver += new System.Windows.Forms.DragEventHandler(this.lst_DragOver);
            this.lst.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDoubleClick);
            // 
            // mnu
            // 
            this.mnu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mởBànToolStripMenuItem,
            this.mởBànTừĐặtToolStripMenuItem,
            this.thanhToánToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.chuyểnBànToolStripMenuItem,
            this.ngắtGiờToolStripMenuItem,
            this.gộpBànToolStripMenuItem,
            this.toolStripSeparator2,
            this.hủyHóaĐơnToolStripMenuItem});
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(196, 214);
            this.mnu.Opening += new System.ComponentModel.CancelEventHandler(this.mnu_Opening);
            // 
            // mởBànToolStripMenuItem
            // 
            this.mởBànToolStripMenuItem.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAABR0lEQVQ4T6WTzSsEcRzG99+SkGjzkpdWu9lcpOxBUciVkoPTlJSDcnDYg+RgS4hk4iAlSVpFKTOzm+Rlv9bY9bKP3zMHpm2m/HL49PT0/T7Pb5rfTARA5D+EhhP7lqEQH0bQQaEF8T1LZu+AUQug0msV9OxYMuNUMHJTAZVeqyC2ZcvU7ReGrj5Bpdcq6N6wZUKFUxcfoNKHFnSs24ZCqhk8K6P/tAxq0Jw57yW2r9kyfF5C35H7Z7jPnFfQsuLIeLaE1In7w8Cxi+ThK+Jm0VN6/5z7zHkF0bQj0/l3TFq/jF2qJzooomtbPKX3z7nPnFfQtOwYCqmm13xBa+YZ1KA5c6EfUuNSTmK7BTSvPoBKr3WNDYs5adt8Qn36HlR6rYK6hZx0mgVEM4+g0msV1M7nJXn9hkRW3YZSeq2Cmrm8oRAfgX/jN8RN+lsotzS0AAAAAElFTkSuQmCC")));
            this.mởBànToolStripMenuItem.Name = "mởBànToolStripMenuItem";
            this.mởBànToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.mởBànToolStripMenuItem.Text = "Mở phòng";
            this.mởBànToolStripMenuItem.Click += new System.EventHandler(this.mởBànToolStripMenuItem_Click);
            // 
            // mởBànTừĐặtToolStripMenuItem
            // 
            this.mởBànTừĐặtToolStripMenuItem.Name = "mởBànTừĐặtToolStripMenuItem";
            this.mởBànTừĐặtToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.mởBànTừĐặtToolStripMenuItem.Text = "Mở phòng từ đặt trước";
            this.mởBànTừĐặtToolStripMenuItem.Click += new System.EventHandler(this.mởBànTừĐặtToolStripMenuItem_Click);
            // 
            // thanhToánToolStripMenuItem
            // 
            this.thanhToánToolStripMenuItem.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAAAZUlEQVQ4T2P4//8/AyWYIs0gi2lvwIRM1T4g/oSE+5C9TNAFII3/Xy39/+7KpP9Xt5X/B/ORwo0YA4aiC9AC7t/BRXH4wwBLSP9EC7h/eGMBS0j/RNIwIlyAnhsJJV+SUiKhrA4AqAG/d+aCdwoAAAAASUVORK5CYII=")));
            this.thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            this.thanhToánToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.thanhToánToolStripMenuItem.Text = "Thanh toán";
            this.thanhToánToolStripMenuItem.Click += new System.EventHandler(this.thanhToánToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAGySURBVDhPY2AgAoh4HQ8A4vVEKEVVIupz3EHM9wQIzxfzO/Ff3P9kAEFDRLyOOYh4H98v6nPiP0iThP/J/5KBp/5LBp36LxV8+r1M6BkBnIYAnZkg6n38P9BGiEagJung0/+Bmv7Lhp39LxcOxBHnsHsFaKsD0Mn/xf1O3pcIONUP1BwgHXqmQC7i7Hn5qHP/FaLP/1eKvfBfKe7Cf+W4iwoYrgA6eb2434kCdAmgpvXK8Rf/qyRe+q+aeGk+EGNqBmkCOhurhGrS5ftqyZcb1FMu4/Y7wZAlR4FWxjUBrcxrpNuqlnRZQSP1ynztzGvvtbOuYxhg0/jIwKbxMaZ3gaFsAAys+UD//gfa/l8398Z5dJfbtz0tcGh7iiEOVgc04D0opDXSrv7Xybn+37Dw1n2zinsNVnUPG+yaH/c7tj+779z9/L9LzwvsqREYtwVg2zOv/dfPv/nfuPTOf4vq+/+Bzv3v2PHsv2vvi//uE14l4A1PoN/362Rf/29QeOu/acW9/1b1D/8Dnf3fpfvFeqBmB4KRAfS7gm7OjfeGRbdJz3kw04HOLzAsuoWRInHZDgDhl8lx1y3KjgAAAABJRU5ErkJggg==")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // chuyểnBànToolStripMenuItem
            // 
            this.chuyểnBànToolStripMenuItem.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAABK0lEQVQ4T5WRv0sDQRCF7+8SLFJYWFgIwUrwB2gVgpWNha1NBsTCys4ulZWNRbqkCSKC2ChiLneQciAxiR7PeeIet0luSYqPmbubfcztFwGIHDutnhjKWnwf6vPD1YeeGNoYAKwrBWzfx2LoyVuGs48M7JcO2LqLxdDayxSHTxOw8jmA93vRZrOvF/EU9ecxdtsjHHVHOH+foJF+z3E5+AHni9tFG7d9MfTUDu11hn/wOYC/AdMqN4kYevz6hf3HIdgvfQducP06EUMPPsdgnQ0oU5xr5IG1q1QMZZ0NKCqmcvfdCwitTbVUTNXsqZ7zXoBTWqZwgWrxAqiIqhYppFoqpmoqp3rOewFOaZlCp5nK/2f8DUJ3QLVUTNXsqX7uDkIBRcVUvrKFMsW/AILxZfBrg5sAAAAASUVORK5CYII=")));
            this.chuyểnBànToolStripMenuItem.Name = "chuyểnBànToolStripMenuItem";
            this.chuyểnBànToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.chuyểnBànToolStripMenuItem.Text = "Chuyển phòng";
            this.chuyểnBànToolStripMenuItem.Click += new System.EventHandler(this.chuyểnBànToolStripMenuItem_Click);
            // 
            // ngắtGiờToolStripMenuItem
            // 
            this.ngắtGiờToolStripMenuItem.Name = "ngắtGiờToolStripMenuItem";
            this.ngắtGiờToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ngắtGiờToolStripMenuItem.Text = "Ngắt giờ";
            this.ngắtGiờToolStripMenuItem.Click += new System.EventHandler(this.ngắtGiờToolStripMenuItem_Click);
            // 
            // gộpBànToolStripMenuItem
            // 
            this.gộpBànToolStripMenuItem.Name = "gộpBànToolStripMenuItem";
            this.gộpBànToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.gộpBànToolStripMenuItem.Text = "Gộp phòng";
            this.gộpBànToolStripMenuItem.Click += new System.EventHandler(this.gộpBànToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // hủyHóaĐơnToolStripMenuItem
            // 
            this.hủyHóaĐơnToolStripMenuItem.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAZdEVYdFNvZnR3YXJlAEFkb2JlIEltYWdlUmVhZHlxyWU8AAACFElEQVQ4T6WTT0iTcRjHn3D65nJbr+2dZo3Ci0KE6EC9rpNEl52yS4HFhKyItJIKCwnBlVYUFh0a2b95yYJRHdYunYJJZBZEeogxhJAuecnSt88zt5cF0WWDz37P832e5/v7A6/Yti3lUNawbpw3SIjIlEgXZArcfII2CXfhHjwE+nZRH4JnEHUMtAiZ3wMD9nJf39pMe3tO8/slBg9ERhNVVe/QXz8S2QsbHIM4jRBlp8zbjo7ct54eO9vdvTIdCHziBKEprzeebm5eoJ6kb4duiEH+9Pk/NdBj3qF5QiQGmZlw+PvnSGT1ZVNTNt3SkkV7jlm99v7PQK7TMIbROCap1tYfqVBo5XZ19Ry5XANdlb9OcAmhyLCINcIjJRoaFpONjT/HDWM27vd/HausnKUmF2CwgHOFonCewpDIjceWlUsHg6sxw5i7KHIY7ektt3ue9cW5fxmcRFROi/ROeDzzmbo6e9Lny51FYkh06AzGMZfrI+tIP/mp0kc8RnKc1z3Bvd9b1q83prlMnMTUVGM9oQ6gDcMresM641whSgJX4253bqG21h6sqPjQy0NG0Iu/ToKj632XYfSIiMsxqKdwiN2/mObadE3NEvGVrSXDpWHbem9/l0ibY4C2ncLBA5jsF0kFRPag7QRC8YEHNoMF24IinbtF9pUaeCn4QTdWdFAHNsFGMAqr5tprwhbHoJzP+Q95lHpGrVHH8wAAAABJRU5ErkJggg==")));
            this.hủyHóaĐơnToolStripMenuItem.Name = "hủyHóaĐơnToolStripMenuItem";
            this.hủyHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.hủyHóaĐơnToolStripMenuItem.Text = "Hủy hóa đơn";
            this.hủyHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.hủyHóaĐơnToolStripMenuItem_Click);
            // 
            // KhuVucControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lst);
            this.Name = "KhuVucControl";
            this.Size = new System.Drawing.Size(663, 519);
            this.mnu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public No1Lib.Sys.DoublebufferedListView lst;
        public System.Windows.Forms.ContextMenuStrip mnu;
        public System.Windows.Forms.ToolStripMenuItem mởBànToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem mởBànTừĐặtToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem thanhToánToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem chuyểnBànToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ngắtGiờToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem gộpBànToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem hủyHóaĐơnToolStripMenuItem;
    }
}
