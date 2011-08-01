<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewOrder
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewOrder))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCompleteOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBooking = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMove = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtBill = New System.Windows.Forms.TextBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnDeleteOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEditOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtOrderNo = New System.Windows.Forms.TextBox()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCash = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDelOrder = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtTotalPrice = New System.Windows.Forms.TextBox()
        Me.Group1 = New DevExpress.XtraEditors.GroupControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnDelete = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.Group1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCompleteOrder)
        Me.PanelControl1.Controls.Add(Me.BtnBooking)
        Me.PanelControl1.Controls.Add(Me.BtnMove)
        Me.PanelControl1.Controls.Add(Me.TxtBill)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.BtnDeleteOrder)
        Me.PanelControl1.Controls.Add(Me.BtnEditOrder)
        Me.PanelControl1.Controls.Add(Me.TxtOrderNo)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnOrder)
        Me.PanelControl1.Controls.Add(Me.BtnCash)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1341, 51)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCompleteOrder
        '
        Me.BtnCompleteOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCompleteOrder.Image = Global.Chaba.My.Resources.Resources.preferences
        Me.BtnCompleteOrder.Location = New System.Drawing.Point(830, 10)
        Me.BtnCompleteOrder.Name = "BtnCompleteOrder"
        Me.BtnCompleteOrder.Size = New System.Drawing.Size(95, 33)
        Me.BtnCompleteOrder.TabIndex = 10
        Me.BtnCompleteOrder.Text = "อาหารครบ"
        '
        'BtnBooking
        '
        Me.BtnBooking.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBooking.Image = Global.Chaba.My.Resources.Resources.alarmclock2
        Me.BtnBooking.Location = New System.Drawing.Point(1133, 10)
        Me.BtnBooking.Name = "BtnBooking"
        Me.BtnBooking.Size = New System.Drawing.Size(95, 33)
        Me.BtnBooking.TabIndex = 9
        Me.BtnBooking.Text = "จองโต๊ะ"
        '
        'BtnMove
        '
        Me.BtnMove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMove.Image = Global.Chaba.My.Resources.Resources.element_next
        Me.BtnMove.Location = New System.Drawing.Point(1032, 10)
        Me.BtnMove.Name = "BtnMove"
        Me.BtnMove.Size = New System.Drawing.Size(95, 33)
        Me.BtnMove.TabIndex = 8
        Me.BtnMove.Text = "ย้ายโต๊ะ"
        '
        'TxtBill
        '
        Me.TxtBill.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBill.Location = New System.Drawing.Point(321, 7)
        Me.TxtBill.Name = "TxtBill"
        Me.TxtBill.ReadOnly = True
        Me.TxtBill.Size = New System.Drawing.Size(188, 33)
        Me.TxtBill.TabIndex = 7
        Me.TxtBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(245, 10)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(70, 25)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Bill NO"
        '
        'BtnDeleteOrder
        '
        Me.BtnDeleteOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDeleteOrder.Image = Global.Chaba.My.Resources.Resources.delete2
        Me.BtnDeleteOrder.Location = New System.Drawing.Point(729, 10)
        Me.BtnDeleteOrder.Name = "BtnDeleteOrder"
        Me.BtnDeleteOrder.Size = New System.Drawing.Size(95, 33)
        Me.BtnDeleteOrder.TabIndex = 5
        Me.BtnDeleteOrder.Text = "ลบรายการ"
        '
        'BtnEditOrder
        '
        Me.BtnEditOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditOrder.Image = Global.Chaba.My.Resources.Resources.contract
        Me.BtnEditOrder.Location = New System.Drawing.Point(628, 10)
        Me.BtnEditOrder.Name = "BtnEditOrder"
        Me.BtnEditOrder.Size = New System.Drawing.Size(95, 33)
        Me.BtnEditOrder.TabIndex = 4
        Me.BtnEditOrder.Text = "แก้ไขรายการ"
        '
        'TxtOrderNo
        '
        Me.TxtOrderNo.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrderNo.Location = New System.Drawing.Point(139, 7)
        Me.TxtOrderNo.Name = "TxtOrderNo"
        Me.TxtOrderNo.Size = New System.Drawing.Size(100, 33)
        Me.TxtOrderNo.TabIndex = 3
        Me.TxtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Image = Global.Chaba.My.Resources.Resources.delete
        Me.BtnCancel.Location = New System.Drawing.Point(1234, 10)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(95, 33)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "ปืด"
        '
        'BtnOrder
        '
        Me.BtnOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOrder.Image = Global.Chaba.My.Resources.Resources.add2
        Me.BtnOrder.Location = New System.Drawing.Point(527, 10)
        Me.BtnOrder.Name = "BtnOrder"
        Me.BtnOrder.Size = New System.Drawing.Size(95, 33)
        Me.BtnOrder.TabIndex = 2
        Me.BtnOrder.Text = "สั่งอาหาร"
        '
        'BtnCash
        '
        Me.BtnCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCash.Image = Global.Chaba.My.Resources.Resources.calculator
        Me.BtnCash.Location = New System.Drawing.Point(931, 10)
        Me.BtnCash.Name = "BtnCash"
        Me.BtnCash.Size = New System.Drawing.Size(95, 33)
        Me.BtnCash.TabIndex = 0
        Me.BtnCash.Text = "คิดเงิน"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(10, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(123, 25)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "เลขที่รายการ"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnDelOrder)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.TxtTotalPrice)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 436)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1341, 47)
        Me.PanelControl2.TabIndex = 1
        '
        'BtnDelOrder
        '
        Me.BtnDelOrder.Image = Global.Chaba.My.Resources.Resources.delete2
        Me.BtnDelOrder.Location = New System.Drawing.Point(10, 8)
        Me.BtnDelOrder.Name = "BtnDelOrder"
        Me.BtnDelOrder.Size = New System.Drawing.Size(95, 33)
        Me.BtnDelOrder.TabIndex = 9
        Me.BtnDelOrder.Text = "ลบ Order"
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(1293, 13)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(40, 25)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "บาท"
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(1098, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(83, 25)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "ราคารวม"
        '
        'TxtTotalPrice
        '
        Me.TxtTotalPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotalPrice.BackColor = System.Drawing.Color.Black
        Me.TxtTotalPrice.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalPrice.ForeColor = System.Drawing.Color.Lime
        Me.TxtTotalPrice.Location = New System.Drawing.Point(1187, 10)
        Me.TxtTotalPrice.Name = "TxtTotalPrice"
        Me.TxtTotalPrice.Size = New System.Drawing.Size(100, 33)
        Me.TxtTotalPrice.TabIndex = 4
        Me.TxtTotalPrice.Text = "0"
        Me.TxtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Group1
        '
        Me.Group1.Controls.Add(Me.GridControl1)
        Me.Group1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Group1.Location = New System.Drawing.Point(0, 51)
        Me.Group1.Name = "Group1"
        Me.Group1.Size = New System.Drawing.Size(1341, 385)
        Me.Group1.TabIndex = 2
        Me.Group1.Tag = ""
        Me.Group1.Text = "รายการอาหารที่สั่ง"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(2, 22)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1337, 361)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "GridColumn3"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "GridColumn4"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "GridColumn5"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "GridColumn6"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "GridColumn7"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "GridColumn8"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "GridColumn9"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "GridColumn10"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 9
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Images = Me.ImageCollection1
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BtnAdd, Me.BtnEdit, Me.BtnDelete})
        Me.BarManager1.MaxItemId = 3
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1341, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 483)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1341, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 483)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1341, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 483)
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "add2.png")
        Me.ImageCollection1.Images.SetKeyName(1, "document_edit.png")
        Me.ImageCollection1.Images.SetKeyName(2, "delete2.png")
        Me.ImageCollection1.Images.SetKeyName(3, "pencil.png")
        '
        'BtnAdd
        '
        Me.BtnAdd.Caption = "เพิ่ม"
        Me.BtnAdd.Id = 0
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.Name = "BtnAdd"
        '
        'BtnEdit
        '
        Me.BtnEdit.Caption = "แก้ไข"
        Me.BtnEdit.Id = 1
        Me.BtnEdit.ImageIndex = 3
        Me.BtnEdit.Name = "BtnEdit"
        '
        'BtnDelete
        '
        Me.BtnDelete.Caption = "ลบ"
        Me.BtnDelete.Id = 2
        Me.BtnDelete.ImageIndex = 2
        Me.BtnDelete.Name = "BtnDelete"
        '
        'frmNewOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1341, 506)
        Me.Controls.Add(Me.Group1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmNewOrder"
        Me.Text = "สั่งอาหาร"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.Group1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Group1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCash As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents BtnAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnDeleteOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEditOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtBill As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnMove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDelOrder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBooking As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCompleteOrder As DevExpress.XtraEditors.SimpleButton
End Class
