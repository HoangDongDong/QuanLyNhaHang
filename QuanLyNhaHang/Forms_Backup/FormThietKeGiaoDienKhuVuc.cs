using ComponentFactory.Krypton.Toolkit;
using FirebirdSql.Data.FirebirdClient;
using No1Lib.Db;
using No1Lib.Sys.Ts;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Thiết kế giao diện khu vực (ID: e58e61ee-9790-4daf-85ea-8835d6b89b76)
    /// </summary>
    public partial class FormThietkegiaodienkhuvuc : Form
    {
        public string SFormId { get; } = "e58e61ee-9790-4daf-85ea-8835d6b89b76";
        public string SFormTitle { get; } = "Thiết kế giao diện khu vực";

        public FormThietkegiaodienkhuvuc()
        {
            InitializeComponent();
        }

                        NotifyUpdate(SelecteDBAN);
                        UpdateParent();

                private void UpdateParent()
                    //nếu không có thì đặt lại parent = this
                    if (SelecteDBAN.Parent != No1UserControl1)
                        Control pr = SelecteDBAN.Parent;
                        if (pr != null)
                            SelecteDBAN.Parent = No1UserControl1;
                            SelecteDBAN.Left += pr.Left;
                            SelecteDBAN.Top += pr.Top;

                Direction directionScr;

                private bool enableScreenSize = false;
                [Browsable(false)]
                [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public bool ScreenLocked
                    get
                        return screenLocked;
                    set { screenLocked = value; }

                private bool screenLocked = false;

                [Browsable(false)]
                [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public bool EnableScreenSize
                    get { return enableScreenSize; }
                    set {
                        enableScreenSize = value; 
                        No1UserControl1.Invalidate();
                        if (enableScreenSize) tmrLoad.Enabled = false;

                private Size SnapSize(int x, int y)
                    if (gridSize == 0) return new Size(x, y);
                    x = ((int)(x / gridSize)) * gridSize;
                    y = ((int)(y / gridSize)) * gridSize;
                    return new Size(x, y);

                private Point SnapLocation(int x, int y)
                    if (gridSize == 0) return new Point(Math.Min(No1UserControl1.Width - gridSize, Math.Max(0, x)), Math.Min(No1UserControl1.Height - gridSize, Math.Max(0, y)));
                    return new Point(Math.Min(No1UserControl1.Width - gridSize, Math.Max(0, ((int)(x / gridSize)) * gridSize)), Math.Min(No1UserControl1.Height - gridSize, Math.Max(0, ((int)(y / gridSize)) * gridSize)));

                private Point SnapLocationWithNegative(int x, int y)
                    if (gridSize == 0) return new Point(Math.Min(No1UserControl1.Width - gridSize, x), Math.Min(No1UserControl1.Height - gridSize, y));
                    return new Point(Math.Min(No1UserControl1.Width - gridSize, ((int)(x / gridSize) * gridSize)), Math.Min(No1UserControl1.Height - gridSize, ((int)(y / gridSize)) * gridSize));

                public void No1UserControl1_MouseUp(object sender, MouseEventArgs e)
                    if (screenLocked) return;
                    if (SelecteDBAN != null)
                        DrawControlBorder(SelecteDBAN);
                    if (!enableScreenSize) tmrLoad.Start();

                public void tmrLoad_Tick(object sender, EventArgs e)
                    if (enableScreenSize)
                        tmrLoad.Enabled = false;
                        return;
                    #region Get the direction and display correct cursor
                    if (SelecteDBAN != null && SelecteDBAN.Parent != null)
                        Point pos = SelecteDBAN.Parent.PointToClient(Control.MousePosition);
                        //check if the mouse cursor is within the drag handle
                        if ((pos.X >= SelecteDBAN.Location.X - DRAG_HANDLE_SIZE &&
                            pos.X <= SelecteDBAN.Location.X) &&
                            (pos.Y >= SelecteDBAN.Location.Y - DRAG_HANDLE_SIZE &&
                            pos.Y <= SelecteDBAN.Location.Y))
                            direction = Direction.NW;
                            No1UserControl1.Cursor = Cursors.SizeNWSE;
                        else if ((pos.X >= SelecteDBAN.Location.X + SelecteDBAN.Width &&
                            pos.X <= SelecteDBAN.Location.X + SelecteDBAN.Width + DRAG_HANDLE_SIZE &&
                            pos.Y >= SelecteDBAN.Location.Y + SelecteDBAN.Height &&
                            pos.Y <= SelecteDBAN.Location.Y + SelecteDBAN.Height + DRAG_HANDLE_SIZE))
                            direction = Direction.SE;
                            No1UserControl1.Cursor = Cursors.SizeNWSE;
                        else if ((pos.X >= SelecteDBAN.Location.X + SelecteDBAN.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                            pos.X <= SelecteDBAN.Location.X + SelecteDBAN.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                            pos.Y >= SelecteDBAN.Location.Y - DRAG_HANDLE_SIZE &&
                            pos.Y <= SelecteDBAN.Location.Y)
                            direction = Direction.N;
                            No1UserControl1.Cursor = Cursors.SizeNS;
                        else if ((pos.X >= SelecteDBAN.Location.X + SelecteDBAN.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                            pos.X <= SelecteDBAN.Location.X + SelecteDBAN.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                            pos.Y >= SelecteDBAN.Location.Y + SelecteDBAN.Height &&
                            pos.Y <= SelecteDBAN.Location.Y + SelecteDBAN.Height + DRAG_HANDLE_SIZE)
                            direction = Direction.S;
                            No1UserControl1.Cursor = Cursors.SizeNS;
                        else if ((pos.X >= SelecteDBAN.Location.X - DRAG_HANDLE_SIZE &&
                            pos.X <= SelecteDBAN.Location.X &&
                            pos.Y >= SelecteDBAN.Location.Y + SelecteDBAN.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                            pos.Y <= SelecteDBAN.Location.Y + SelecteDBAN.Height / 2 + DRAG_HANDLE_SIZE / 2))
                            direction = Direction.W;
                            No1UserControl1.Cursor = Cursors.SizeWE;
                        else if ((pos.X >= SelecteDBAN.Location.X + SelecteDBAN.Width &&
                            pos.X <= SelecteDBAN.Location.X + SelecteDBAN.Width + DRAG_HANDLE_SIZE &&
                            pos.Y >= SelecteDBAN.Location.Y + SelecteDBAN.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                            pos.Y <= SelecteDBAN.Location.Y + SelecteDBAN.Height / 2 + DRAG_HANDLE_SIZE / 2))
                            direction = Direction.E;
                            No1UserControl1.Cursor = Cursors.SizeWE;
                        else if ((pos.X >= SelecteDBAN.Location.X + SelecteDBAN.Width &&
                            pos.X <= SelecteDBAN.Location.X + SelecteDBAN.Width + DRAG_HANDLE_SIZE) &&
                            (pos.Y >= SelecteDBAN.Location.Y - DRAG_HANDLE_SIZE &&
                            pos.Y <= SelecteDBAN.Location.Y))
                            direction = Direction.NE;
                            No1UserControl1.Cursor = Cursors.SizeNESW;
                        else if ((pos.X >= SelecteDBAN.Location.X - DRAG_HANDLE_SIZE &&
                            pos.X <= SelecteDBAN.Location.X + DRAG_HANDLE_SIZE) &&
                            (pos.Y >= SelecteDBAN.Location.Y + SelecteDBAN.Height - DRAG_HANDLE_SIZE &&
                            pos.Y <= SelecteDBAN.Location.Y + SelecteDBAN.Height + DRAG_HANDLE_SIZE))
                            direction = Direction.SW;
                            No1UserControl1.Cursor = Cursors.SizeNESW;
                        else
                            No1UserControl1.Cursor = Cursors.Default;
                            direction = Direction.None;
                    else
                        direction = Direction.None;
                        No1UserControl1.Cursor = Cursors.Default;
                    #endregion

                internal Dictionary<Control, TSObject> lstControls;
                internal Dictionary<string, Control> dicControls;

                internal void AddTabPageEvent(TabPage page)
                    page.MouseDown += No1UserControl1_MouseDown;
                    page.MouseMove += No1UserControl1_MouseMove;
                    page.MouseUp += No1UserControl1_MouseUp;

                internal Control AddButton(ControlType type)
                    Control control = null;
                    switch (type)
                        case ControlType.BUTTON:
                        case ControlType.IMAGE:
                            TSButton button = new TSButton();                    
                            control = button;
                            button.ImageMode = type == ControlType.IMAGE;                    
                            button.Text = type == ControlType.BUTTON ? "BUTTON" : "IMAGE";
                            control.Width = 136;
                            control.Height = 72;
                            break;                
                    control.MouseEnter += new EventHandler(control_MouseEnter);
                    control.MouseLeave += new EventHandler(control_MouseLeave);
                    control.MouseDown += new MouseEventHandler(control_MouseDown);
                    control.MouseMove += new MouseEventHandler(control_MouseMove);
                    control.MouseDoubleClick += new MouseEventHandler(control_MouseDoubleClick);
                    control.MouseUp += new MouseEventHandler(control_MouseUp);
                    control.KeyDown += new KeyEventHandler(control_KeyDown);
                    control.Enter += button_Enter;
                    control.Name = "a" + Guid.NewGuid().ToString().Replace("-", "");
                    No1UserControl1.Controls.Add(control);
                    SelecteDBAN = control;
                    control.BringToFront();

                    TSObject obj = new TSObject();
                    obj.Changed = true;
                    obj.Control = control;
                    DataTable dt = No1Lib.Sys.Config.Db.GetTable("SELECT * FROM DBAN WHERE 0 = 1");
                    obj.Row = new DBANRow(dt.NewRow());
                    dt.Rows.Add(obj.Row.Row);
                    lstControls.Add(control, obj);

                    return control;

                void control_MouseDoubleClick(object sender, MouseEventArgs e)
                    if (MouseDoubleClick != null) MouseDoubleClick(sender, e);

                void control_KeyDown(object sender, KeyEventArgs e)
                    Control c = sender as Control;
                    if (e.KeyCode == Keys.Delete)
                        //xoa control                
                        c.Parent.Controls.Remove(c);
                    else if (e.KeyCode == Keys.Left)
                        //move to left
                        if (e.Shift)
                            c.Width = Math.Max(4 * GridSize, c.Width - 1);
                        else         
                            c.Left = Math.Max(0, c.Left - (e.Control ? gridSize : 1));
                    else if (e.KeyCode == Keys.Right)
                        if (e.Shift)
                            c.Width = Math.Max(GridSize, c.Width + 1);
                        else
                            c.Left = Math.Max(0, c.Left + (e.Control ? gridSize : 1));
                    else if (e.KeyCode == Keys.Up)
                        if (e.Shift)
                            c.Height = Math.Max(GridSize, c.Height - 1);
                        else
                            c.Left = Math.Max(0, c.Top - (e.Control ? gridSize : 1));
                    else if (e.KeyCode == Keys.Down)
                        if (e.Shift)
                            c.Width = Math.Max(GridSize, c.Height + 1);
                        else
                            c.Left = Math.Max(0, c.Top + (e.Control ? gridSize : 1));

                private Image backgroundPic;
                [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Image BackgroundPic
                    get { return backgroundPic; }
                    set 
                        backgroundPic = value;
                        uRow.BACKGROUNDIMAGE = imageToByteArray(value);
                        No1UserControl1.Invalidate();

                internal void NotifyUpdate(Control c)
                    if (lstControls.ContainsKey(c))
                        lstControls[c].Changed = true;

                public byte[] imageToByteArray(System.Drawing.Image imageIn)
                    if (imageIn == null) return new byte[] { };
                    MemoryStream ms = new MemoryStream();
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();

                private void UpdateInfo(Control c, DBANRow r, Hashtable hst)
                    r.WIDTH = c.Width;
                    r.HEIGHT = c.Height;
                    r.POSLEFT = c.Left;
                    r.POSTOP = c.Top;            
                    r.CONTROLNAME = c.Name;            
                    r.PARENTCONTROLNAME = c.Parent == No1UserControl1 ? "" : c.Parent.Name;
                    int val = (int) hst[c];
                    r.CONTROLLEVEL = val / 1000;
                    r.ZINDEX = val % 1000;
                    r.VISIBLE = 30;            

                    if (c is TSButton)
                        TSButton bt = c as TSButton;
                        r.NAME = bt.Text;
                        r.TEXTALIGN = (int)bt.TextAlign;
                        r.FONTNAME = bt.Font.FontFamily.Name;
                        r.FONTSIZE = (decimal) bt.Font.Size;
                        r.FONTCOLOR = bt.ForeColor.ToArgb();
                        r.BOLD = bt.Font.Bold ? 30 : 0;
                        r.ITALIC = bt.Font.Italic ? 30 : 0;
                        r.HASBORDER = bt.HasBorder ? 30 : 0;
                        r.FLAT = bt.Flat ? 30 : 0;
                        r.TRANSPARENT = bt.TransParent ? 30 : 0;
                        if (bt.Image != null)
                            r.ANH = imageToByteArray(bt.Image);
                        else
                            r.ANH = null;
                        if (bt.Icon != null)
                            r.ICON = imageToByteArray(bt.Icon);
                        else
                            r.ICON = null;
                        r.UNDERLINE = bt.Font.Underline ? 30 : 0;
                        r.CONTROLTYPE = (int)(bt.ImageMode ? ControlType.IMAGE : ControlType.BUTTON);
                        r.BUTTONSHAPE = (int)bt.Shape;
                        r.ROTATE = (int)bt.Rotate;
                        r.NUMCHAIRS = (int) bt.ChairNum;

                    r.BACKCOLOR = c.BackColor.ToArgb();

                private void UpdateInfo(Control c, DANHRow r, Hashtable hst)
                    r.WIDTH = c.Width;
                    r.HEIGHT = c.Height;
                    r.POSLEFT = c.Left;
                    r.POSTOP = c.Top;
                    r.VISIBLE = 30;
                    r.CONTROLNAME = c.Name;
                    r.PARENTCONTROLNAME = c.Parent == No1UserControl1 ? "" : c.Parent.Name;
                    int val = (int)hst[c];
                    r.CONTROLLEVEL = val / 1000;
                    r.ZINDEX = val % 1000;

                    if (c is TSButton)
                        TSButton bt = c as TSButton;
                        r.NAME = bt.Text;
                        r.TEXTALIGN = (int)bt.TextAlign;
                        r.FONTNAME = bt.Font.FontFamily.Name;
                        r.FONTSIZE = (decimal)bt.Font.Size;
                        r.FONTCOLOR = bt.ForeColor.ToArgb();
                        r.BOLD = bt.Font.Bold ? 30 : 0;
                        r.ITALIC = bt.Font.Italic ? 30 : 0;
                        r.HASBORDER = bt.HasBorder ? 30 : 0;
                        r.FLAT = bt.Flat ? 30 : 0;
                        r.TRANSPARENT = bt.TransParent ? 30 : 0;
                        if (bt.Image != null)
                            r.ANH = imageToByteArray(bt.Image);
                        else
                            r.ANH = null;
                        if (bt.Icon != null)
                            r.ICON = imageToByteArray(bt.Icon);
                        else
                            r.ICON = null;
                        r.UNDERLINE = bt.Font.Underline ? 30 : 0;                
                        r.CONTROLTYPE = (int)(bt.ImageMode ? ControlType.IMAGE : ControlType.BUTTON);
                        r.BUTTONSHAPE = (int)bt.Shape;
                        r.ROTATE = (int)bt.Rotate;
                        r.NUMCHAIRS = (int) bt.ChairNum;

                    r.BACKCOLOR = c.BackColor.ToArgb();

                internal bool Save()
                    //cập nhật màn hình
                    uRow.Update();
                    //cập nhật các control
                    Dictionary<Control, TSObject> newLstControls = new Dictionary<Control, TSObject>();            

                    Hashtable hst = new Hashtable();
                    GetControls(No1UserControl1, hst, 1);
                    //kiem tra xem co 2 ban trung caption nhau khong?
                    Hashtable hstTest = new Hashtable();
                    foreach (Control c in hst.Keys)
                        if (c is TSButton)
                            TSButton btn = c as TSButton;
                            if (!btn.ImageMode)
                                if (btn.Text.Trim().Length == 0)
                                    Msg.ShowWarning("Tên bàn không được phép trống, mời bạn chọn bàn và đặt lại tên!");
                                    return false;
                                string tblName = btn.Text.Trim().ToLower();
                                if (hstTest.ContainsKey(tblName))
                                    Msg.ShowWarning("Tên bàn không được phép trùng '" + btn.Text.Trim() + "', mời bạn đặt lại tên bàn!");
                                    return false;
                                else
                                    hstTest.Add(tblName, null);

                    //insert/update
                    foreach (Control c in hst.Keys)
                        //kiem tra xem da co trong lstControls chua
                        if (!lstControls.ContainsKey(c)) continue;
                        TSObject obj = lstControls[c];
                        if (obj.Row.Row == null) continue;
                        if (obj.Row.Row.RowState == DataRowState.Unchanged && !obj.Changed)
                            newLstControls.Add(c, lstControls[c]);
                            continue;
                        if (obj.Row.Row.RowState == DataRowState.Modified || (obj.Row.Row.RowState != DataRowState.Added && obj.Changed))
                            //update
                            TSObject objCheck = lstControls[c];
                            if (objCheck.Changed)
                                if (c is TSButton)
                                    if (!(c as TSButton).ImageMode)
                                        DBANRow updateRow = new DBANRow(objCheck.Row.ID);
                                        UpdateInfo(c, updateRow, hst);
                                        updateRow.Update();
                                    else
                                        DANHRow updateRow = new DANHRow(objCheck.Row.ID);
                                        UpdateInfo(c, updateRow, hst);
                                        updateRow.Update();
                            newLstControls.Add(c, obj);
                        else
                            //insert
                            DANHRow row = new DANHRow();
                            UpdateInfo(c, row, hst);
                            row.DKHUVUCID = uRow.ID;
                            row.Update();

                            TSObject tsObj = new TSObject();
                            tsObj.Row = new DBANRow(row.ID);
                            tsObj.Control = c;

                            newLstControls.Add(c, tsObj);

                    //remove
                    foreach (Control c in lstControls.Keys)
                        if (!hst.ContainsKey(c))
                            if (c is TSButton)
                                if (!(c as TSButton).ImageMode)
                                    //xoa trong CSDL                    
                                    DBANRow delRow = new DBANRow(lstControls[c].Row.ID);
                                    delRow.VISIBLE = 0;
                                    delRow.Update();
                                else
                                    //xoa trong CSDL                    
                                    DANHRow delRow = new DANHRow(lstControls[c].Row.ID);
                                    delRow.Delete();

                    lstControls = newLstControls;
                    return true;

                private void GetControls(Control p, Hashtable hst, int level)
                    int i = 0;
                    foreach (Control c in p.Controls)
                        i++;
                        hst.Add(c, level * 1000 + i);               

                private void DrawControlBorder(Graphics g, Rectangle Rect)
                    //define the border to be drawn, it will be offset by DRAG_HANDLE_SIZE / 2
                    //around the control, so when the drag handles are drawn they will be seem
                    //connected in the middle.
                    Rectangle Border = new Rectangle(
                        new Point(Rect.X + DRAG_HANDLE_SIZE / 2, Rect.Y + DRAG_HANDLE_SIZE / 2),
                        new Size(Rect.Width - DRAG_HANDLE_SIZE + 1, Rect.Height - DRAG_HANDLE_SIZE + 1));
                    //define the 8 drag handles, that has the size of DRAG_HANDLE_SIZE
                    Rectangle NW = new Rectangle(Rect.Location, new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                    Rectangle N = new Rectangle(new Point(Rect.Left + Rect.Width / 2 - DRAG_HANDLE_SIZE / 2, Rect.Top),
                        new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                    Rectangle NE = new Rectangle(new Point(Rect.X + Rect.Width - DRAG_HANDLE_SIZE, Rect.Top),
                        new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                    Rectangle W = new Rectangle(new Point(Rect.Left, Rect.Y + Rect.Height / 2 - DRAG_HANDLE_SIZE / 2),
                        new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                    Rectangle E = new Rectangle(
                        new Point(Rect.Left + Rect.Width - DRAG_HANDLE_SIZE, Rect.Y + Rect.Height / 2 - DRAG_HANDLE_SIZE / 2),
                        new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                    Rectangle SW = new Rectangle(
                        new Point(Rect.Left, Rect.Y + Rect.Height - DRAG_HANDLE_SIZE),
                        new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                    Rectangle S = new Rectangle(
                        new Point(Rect.X + Rect.Width / 2 - DRAG_HANDLE_SIZE / 2, Rect.Y + Rect.Height - DRAG_HANDLE_SIZE),
                        new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                    Rectangle SE = new Rectangle(
                        new Point(Rect.X + Rect.Width - DRAG_HANDLE_SIZE,
                            Rect.Y + Rect.Height - DRAG_HANDLE_SIZE),
                        new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));

                    //draw the border and drag handles
                    if (enableScreenSize)
                        Color b = Color.Fuchsia;
                        int BORDER_SIZE = 2;
                        ButtonBorderStyle Style = ButtonBorderStyle.Solid;
                        ControlPaint.DrawBorder(g, Border, b, BORDER_SIZE, Style, b, BORDER_SIZE, Style, b, BORDER_SIZE, Style
                        , b, BORDER_SIZE, Style);
                        ControlPaint.DrawGrabHandle(g, NW, true, true);
                        ControlPaint.DrawGrabHandle(g, N, true, true);
                        ControlPaint.DrawGrabHandle(g, NE, true, true);
                        ControlPaint.DrawGrabHandle(g, E, true, true);
                        ControlPaint.DrawGrabHandle(g, SW, true, true);
                        ControlPaint.DrawGrabHandle(g, S, true, true);
                        ControlPaint.DrawGrabHandle(g, W, true, true);
                        ControlPaint.DrawGrabHandle(g, SE, true, true);
                    else
                        ControlPaint.DrawBorder(g, Border, Color.Blue, ButtonBorderStyle.Solid);

                public void No1UserControl1_Paint(object sender, PaintEventArgs e)
                    int l = ScreenWidth - 140 - (backgrounDBAN == null ? 0 : backgrounDBAN.Width);
                    Graphics g = e.Graphics;
                    //draw background if has
                    if (backgroundPic != null)
                        g.DrawImage(backgroundPic, new Rectangle(0, 0, l, screenHeight));
                    if (gridSize > 0)
                        Pen p = new Pen(Color.FromArgb(192, 192, 192));                    
                        for (int i = 0; i < No1UserControl1.Height; i = i + gridSize)
                            g.DrawLine(p, 0, i, No1UserControl1.Width, i);
                        for (int x = 0; x < No1UserControl1.Width; x = x + gridSize)
                            g.DrawLine(p, x, 0, x, No1UserControl1.Height);
                    //draw a vertical line
                    using (Pen p2 = new Pen(Color.Red, 1))
                        p2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;                    
                        g.DrawLine(p2, l, 0, l, ScreenHeight);
                        if (IsEmbeded)
                            e.Graphics.DrawRectangle(new Pen(Brushes.Orange, 2), new Rectangle(No1UserControl1.ClientRectangle.X + 1, No1UserControl1.ClientRectangle.Y + 1, No1UserControl1.ClientRectangle.Width - 2, No1UserControl1.ClientRectangle.Height - 2));

                        //draw a horizontal line
                        g.DrawLine(p2, 0, ScreenHeight, l, ScreenHeight);

                private bool isPreview = false;

                private void ClearScreen()
                    for (int i = No1UserControl1.Controls.Count - 1; i >= 0; i--)
                        No1UserControl1.Controls.RemoveAt(i);

                public bool Preview
                    get { return isPreview; }
                    set 
                        if (isPreview != value)
                            if (value)
                                isPreview = value; Init(ID, true);
                            else
                                isPreview = value;
                                ClearScreen();

                private void ScreenDesigner_KeyPress(object sender, KeyPressEventArgs e)


                private void ScreenDesigner_KeyDown(object sender, KeyEventArgs e)
                    if (e.KeyCode == Keys.V && e.Control)
                        PasteFromClipboard();

                internal void DeleteSelected()
                    if (SelecteDBAN != null)
                        SelecteDBAN.Parent.Controls.Remove(SelecteDBAN);
                        SelecteDBAN = null;
                        No1UserControl1.Refresh();

                private void ScreenDesigner_Resize(object sender, EventArgs e)



                private Point clickedPt;
                private Size oldSize;
                private Point oldLocation;
                private bool IsUpdate = false;

                public void No1UserControl1_MouseDown(object sender, MouseEventArgs e)
                    if (screenLocked) return;
                    Control c = sender as Control;
                    clickedPt = c.PointToClient(Control.MousePosition);
                    oldSize = scrSize;
                    oldLocation = scrLoc;

                private string embededID = "";
                [Browsable(false)]
                [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public string EmbededID
                    set
                        embededID = value;
                        scRow = new DKHUVUCRow(value);
                        gridSize = scRow.GRIDSIZE;
                        No1UserControl1.BackColor = Color.FromArgb(scRow.BACKCOLOR);
                        ScreenWidth = scRow.WIDTH;
                        ScreenHeight = scRow.HEIGHT;

                    get
                        return embededID;

                internal void CopySelecteDBANToClipBoard()
                    if (SelecteDBAN != null)
                        CopiedObj = SelecteDBAN;

                internal Control CopiedObj;

                internal void PasteFromClipBoard()
                    try
                        if (CopiedObj == null || CopiedObj.IsDisposed) return;

                        if (CopiedObj is TSButton)
                            TSButton btn = CopiedObj as TSButton;
                            //add new button
                            TSButton newButton = (TSButton) AddButton(ControlType.BUTTON);
                            newButton.Text = btn.Text;
                            newButton.ImageMode = btn.ImageMode;
                            newButton.BackColor = btn.BackColor;
                            newButton.Font = btn.Font;
                            newButton.Image = btn.Image;
                            newButton.Width = btn.Width;
                            newButton.Height = btn.Height;
                            newButton.Icon = btn.Icon;
                            newButton.TextAlign = btn.TextAlign;
                            newButton.IconAlign = btn.IconAlign;
                            newButton.ForeColor = btn.ForeColor;
                            newButton.Flat = btn.Flat;
                            newButton.HasBorder = btn.HasBorder;
                            newButton.TransParent = btn.TransParent;
                            Control parent = (SelecteDBAN != null ? SelecteDBAN.Parent : No1UserControl1);
                            newButton.Parent = parent;
                    catch

                string ChonBan()
                    //get all current buttons            
                    Hashtable hst = new Hashtable();
                    GetControls(No1UserControl1, hst, 1);            
                    string ID = "''";
                    foreach (Control c in hst.Keys)
                        if (c is TSButton)
                            TSObject obj = lstControls[c];                    
                            ID += ",'" + obj.Row.ID + "'"; 

                    DataTable dtBan = No1Lib.Sys.Config.Db.GetTable("SELECT ID, NAME FROM DBAN WHERE DKHUVUCID = '" + DKHUVUCID + "' AND STATUS = 30 AND ID NOT IN (" + ID + ")");

                    //chọn bàn từ danh sách
                    ThemBanVaoGiaoDien form = (ThemBanVaoGiaoDien)Config.CreateForm(Forms.ThemBanVaoGiaoDien);
                    form.SetData(dtBan);
                    if (form.No1Form1.ShowDialog() == DialogResult.OK)
                        return form.DBANID;
                    return "";

                internal void AddBan()
                    string DBANID = ChonBan();
                    if (DBANID.Length == 0) return;

                    TSButton button = (TSButton) AddButton(ControlType.BUTTON);
                    TSObject obj = lstControls[button];
                    DBANRow row = new DBANRow(No1Lib.Sys.Config.Db.GetFirstRow("SELECT * FROM DBAN WHERE ID = '" + DBANID + "'"));
                    obj.Row = row;
                    obj.Changed = false;

                    FontStyle style = FontStyle.Regular;
                    if (row.BOLD == 30)
                        style = style | FontStyle.Bold;
                    if (row.ITALIC == 30)
                        style = style | FontStyle.Italic;
                    if (row.UNDERLINE == 30)
                        style = style | FontStyle.Underline;

                    if (row.FONTNAME.Length > 0)
                        button.Font = new Font(new FontFamily(row.FONTNAME), (float)row.FONTSIZE, style);

                    if (row.CONTROLNAME.Length > 0)
                        button.Name = row.CONTROLNAME;
                    button.Text = row.NAME;
                    button.Flat = row.FLAT == 30;
                    //button.HasBorder = row.HASBORDER == 30;
                    button.TransParent = row.TRANSPARENT == 30;
                    if (row.FONTCOLOR != 0)
                        button.ForeColor = Color.FromArgb(row.FONTCOLOR);
                    if (row.BACKCOLOR != 0)
                        button.BackColor = Color.FromArgb(row.BACKCOLOR);
                    button.IconAlign = (ContentAlignment)row.ICONALIGN;

                    if (row.ANH != null && row.ANH.Length > 0)
                        button.Image = byteArrayToImage(row.ANH);

                    if (row.ICON != null && row.ICON.Length > 0)
                        button.Icon = byteArrayToImage(row.ICON);

                    button.TextAlign = (ContentAlignment)row.TEXTALIGN;
                    button.MouseDoubleClick += control_MouseDoubleClick;            

                public void No1UserControl1_DragEnter(object sender, DragEventArgs e)
                    e.Effect = DragDropEffects.Copy;            

                public void No1UserControl1_DragDrop(object sender, DragEventArgs e)
                    TSButton btn = ((TSButton)e.Data.GetData(typeof(TSButton)));
                    if (btn == null) return;
                    //show chọn bàn
                    string DBANID = ChonBan();
                    if (DBANID.Length > 0)
                        TSButton button = (TSButton) AddButton(ControlType.BUTTON);

                        Point pt = No1UserControl1.PointToClient(new Point(e.X, e.Y));

                        button.Left = pt.X;
                        button.Top = pt.Y;


                        TSObject obj = lstControls[button];
                        DBANRow row = new DBANRow(No1Lib.Sys.Config.Db.GetFirstRow("SELECT * FROM DBAN WHERE ID = '" + DBANID + "'"));
                        obj.Row = row;
                        obj.Changed = true;

                        FontStyle style = FontStyle.Regular;                
                        button.Font = new Font(button.Font.FontFamily, 18, FontStyle.Regular);                

                        if (row.CONTROLNAME.Length > 0)
                            button.Name = row.CONTROLNAME;
                        button.Text = row.NAME;
                        button.ForeColor = Color.Orange;                
                        button.BackColor = Color.Black;
                        button.Shape = btn.Shape;
                        button.ChairNum = btn.ChairNum;
                        button.Rotate = btn.Rotate;
                        button.Invalidate();
                        button.MouseDoubleClick += control_MouseDoubleClick;   




        		public void No1UserControl1_Load(object sender, EventArgs e)
        			tmrLoad.Start();  


        		public void No1UserControl1_KeyDown(object sender, KeyEventArgs e)
                    if (e.KeyCode == Keys.Delete)
                        DeleteSelected();
        #endregion
    }
}