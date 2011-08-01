<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BtnDB = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCurrentSQL = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnZone = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnTables = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnMenus = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnEmp = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnCheckTable = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnExit = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnUser = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnOrderList = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage3 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BtnNewCustomer = New DevExpress.XtraBars.BarButtonItem()
        Me.NewCus = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ApplicationButtonText = Nothing
        '
        '
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.ExpandCollapseItem.Name = ""
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.BtnDB, Me.BtnCurrentSQL, Me.BtnZone, Me.BtnTables, Me.BtnMenus, Me.BtnEmp, Me.BtnCheckTable, Me.BtnExit, Me.BtnUser, Me.BtnOrderList})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 18
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1, Me.RibbonPage2, Me.RibbonPage3})
        Me.RibbonControl.SelectedPage = Me.RibbonPage1
        Me.RibbonControl.Size = New System.Drawing.Size(1004, 145)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BtnDB
        '
        Me.BtnDB.Caption = "ตั้งค่าฐานข้อมูล"
        Me.BtnDB.Id = 6
        Me.BtnDB.LargeGlyph = Global.Chaba.My.Resources.Resources.data_gear
        Me.BtnDB.Name = "BtnDB"
        '
        'BtnCurrentSQL
        '
        Me.BtnCurrentSQL.Caption = "Current SQL"
        Me.BtnCurrentSQL.Id = 7
        Me.BtnCurrentSQL.LargeGlyph = Global.Chaba.My.Resources.Resources.text_marked
        Me.BtnCurrentSQL.Name = "BtnCurrentSQL"
        '
        'BtnZone
        '
        Me.BtnZone.Caption = "ตั้งค่า Zone"
        Me.BtnZone.Id = 9
        Me.BtnZone.LargeGlyph = Global.Chaba.My.Resources.Resources.window
        Me.BtnZone.Name = "BtnZone"
        '
        'BtnTables
        '
        Me.BtnTables.Caption = "ตั้งค่าโต๊ะ"
        Me.BtnTables.Id = 10
        Me.BtnTables.LargeGlyph = Global.Chaba.My.Resources.Resources.table
        Me.BtnTables.Name = "BtnTables"
        '
        'BtnMenus
        '
        Me.BtnMenus.Caption = "ตั้งค่า เมนูอาหาร"
        Me.BtnMenus.Id = 11
        Me.BtnMenus.LargeGlyph = Global.Chaba.My.Resources.Resources.text_tree
        Me.BtnMenus.Name = "BtnMenus"
        '
        'BtnEmp
        '
        Me.BtnEmp.Caption = "ตั้งค่าพนักงาน"
        Me.BtnEmp.Id = 12
        Me.BtnEmp.LargeGlyph = Global.Chaba.My.Resources.Resources.users3
        Me.BtnEmp.Name = "BtnEmp"
        '
        'BtnCheckTable
        '
        Me.BtnCheckTable.Caption = "จัดการโต๊ะ"
        Me.BtnCheckTable.Id = 13
        Me.BtnCheckTable.LargeGlyph = Global.Chaba.My.Resources.Resources.table_view
        Me.BtnCheckTable.Name = "BtnCheckTable"
        '
        'BtnExit
        '
        Me.BtnExit.Caption = "จบการทำงาน"
        Me.BtnExit.Id = 14
        Me.BtnExit.LargeGlyph = Global.Chaba.My.Resources.Resources._stop
        Me.BtnExit.Name = "BtnExit"
        '
        'BtnUser
        '
        Me.BtnUser.Caption = "ตั้งค่าผู้ใช้งาน"
        Me.BtnUser.Id = 15
        Me.BtnUser.LargeGlyph = Global.Chaba.My.Resources.Resources.users4
        Me.BtnUser.Name = "BtnUser"
        '
        'BtnOrderList
        '
        Me.BtnOrderList.Caption = "Order"
        Me.BtnOrderList.Id = 17
        Me.BtnOrderList.LargeGlyph = Global.Chaba.My.Resources.Resources.address_book2
        Me.BtnOrderList.Name = "BtnOrderList"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup3})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "หน้าร้าน"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BtnCheckTable)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BtnOrderList)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BtnExit)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "ทั่วไป"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup5, Me.RibbonPageGroup2})
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "การตั้งค่า"
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BtnZone)
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BtnTables)
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BtnMenus)
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BtnEmp)
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BtnUser)
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        Me.RibbonPageGroup5.Text = "ร้านอาหาร"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BtnDB)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "ฐานข้อมูล"
        '
        'RibbonPage3
        '
        Me.RibbonPage3.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup4})
        Me.RibbonPage3.Name = "RibbonPage3"
        Me.RibbonPage3.Text = "Debug"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BtnCurrentSQL)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "การ Debuging"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 484)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1004, 31)
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "ลูกค้า"
        '
        'BtnNewCustomer
        '
        Me.BtnNewCustomer.Caption = "เพิ่มลูกค้า"
        Me.BtnNewCustomer.Glyph = Global.Chaba.My.Resources.Resources.user1_add
        Me.BtnNewCustomer.Id = 1
        Me.BtnNewCustomer.LargeGlyph = Global.Chaba.My.Resources.Resources.user1_add
        Me.BtnNewCustomer.Name = "BtnNewCustomer"
        '
        'NewCus
        '
        Me.NewCus.Caption = "เพิ่มลูกค้า"
        Me.NewCus.Id = 5
        Me.NewCus.LargeGlyph = Global.Chaba.My.Resources.Resources.user1_add
        Me.NewCus.Name = "NewCus"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 515)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "ร้านชบา"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnNewCustomer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnDB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage3 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents BtnCurrentSQL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnZone As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BtnTables As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnMenus As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnEmp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnCheckTable As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnExit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NewCus As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnOrderList As DevExpress.XtraBars.BarButtonItem


End Class
