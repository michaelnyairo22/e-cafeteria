<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZoneSettings
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
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LsvZone = New DevExpress.XtraEditors.ListBoxControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.VGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.SPETableNo = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ChkStatus = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.VColZone = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.VColZoneName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.VColTable = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.VColActive = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.BtnDefaultUnActiveColor = New System.Windows.Forms.Button()
        Me.BtnDefaultActiveColor = New System.Windows.Forms.Button()
        Me.ColorUnActiveEdit2 = New DevExpress.XtraEditors.ColorEdit()
        Me.ColorActiveEdit1 = New DevExpress.XtraEditors.ColorEdit()
        Me.BtnChangeUnActiveColor = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnChangeActiveColor = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.BtnDefaultFullColor = New System.Windows.Forms.Button()
        Me.ColorFullEdit = New DevExpress.XtraEditors.ColorEdit()
        Me.BtnChangeFullColor = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.LsvZone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPETableNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorUnActiveEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorActiveEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.ColorFullEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(2, 22)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LsvZone)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.BtnCancel)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.BtnSave)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.VGridControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1005, 425)
        Me.SplitContainerControl1.SplitterPosition = 168
        Me.SplitContainerControl1.TabIndex = 3
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LsvZone
        '
        Me.LsvZone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvZone.Location = New System.Drawing.Point(0, 0)
        Me.LsvZone.Name = "LsvZone"
        Me.LsvZone.Size = New System.Drawing.Size(168, 425)
        Me.LsvZone.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(119, 88)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(85, 27)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "ยกเลิก"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(28, 88)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(85, 27)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "บันทึก"
        '
        'VGridControl1
        '
        Me.VGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VGridControl1.Location = New System.Drawing.Point(0, 0)
        Me.VGridControl1.Name = "VGridControl1"
        Me.VGridControl1.RecordWidth = 162
        Me.VGridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SPETableNo, Me.ChkStatus})
        Me.VGridControl1.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.VColZone, Me.VColZoneName, Me.VColTable, Me.VColActive})
        Me.VGridControl1.Size = New System.Drawing.Size(832, 425)
        Me.VGridControl1.TabIndex = 0
        '
        'SPETableNo
        '
        Me.SPETableNo.AutoHeight = False
        Me.SPETableNo.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SPETableNo.Name = "SPETableNo"
        '
        'ChkStatus
        '
        Me.ChkStatus.AutoHeight = False
        Me.ChkStatus.Name = "ChkStatus"
        '
        'VColZone
        '
        Me.VColZone.Name = "VColZone"
        Me.VColZone.Properties.Caption = "Zone"
        Me.VColZone.Properties.ReadOnly = True
        Me.VColZone.Properties.Value = "A"
        '
        'VColZoneName
        '
        Me.VColZoneName.Name = "VColZoneName"
        Me.VColZoneName.Properties.Caption = "ชื่อ Zone"
        '
        'VColTable
        '
        Me.VColTable.Name = "VColTable"
        Me.VColTable.Properties.Caption = "จำนวนโต๊ะ"
        Me.VColTable.Properties.RowEdit = Me.SPETableNo
        Me.VColTable.Properties.Value = 0
        '
        'VColActive
        '
        Me.VColActive.Name = "VColActive"
        Me.VColActive.Properties.Caption = "เปิดบริการ"
        Me.VColActive.Properties.RowEdit = Me.ChkStatus
        Me.VColActive.Properties.Value = True
        '
        'BtnDefaultUnActiveColor
        '
        Me.BtnDefaultUnActiveColor.Location = New System.Drawing.Point(346, 64)
        Me.BtnDefaultUnActiveColor.Name = "BtnDefaultUnActiveColor"
        Me.BtnDefaultUnActiveColor.Size = New System.Drawing.Size(53, 23)
        Me.BtnDefaultUnActiveColor.TabIndex = 9
        Me.BtnDefaultUnActiveColor.Text = "คืนค่า"
        Me.BtnDefaultUnActiveColor.UseVisualStyleBackColor = True
        '
        'BtnDefaultActiveColor
        '
        Me.BtnDefaultActiveColor.Location = New System.Drawing.Point(346, 35)
        Me.BtnDefaultActiveColor.Name = "BtnDefaultActiveColor"
        Me.BtnDefaultActiveColor.Size = New System.Drawing.Size(53, 23)
        Me.BtnDefaultActiveColor.TabIndex = 8
        Me.BtnDefaultActiveColor.Text = "คืนค่า"
        Me.BtnDefaultActiveColor.UseVisualStyleBackColor = True
        '
        'ColorUnActiveEdit2
        '
        Me.ColorUnActiveEdit2.EditValue = System.Drawing.Color.Gainsboro
        Me.ColorUnActiveEdit2.Location = New System.Drawing.Point(170, 66)
        Me.ColorUnActiveEdit2.Name = "ColorUnActiveEdit2"
        Me.ColorUnActiveEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ColorUnActiveEdit2.Size = New System.Drawing.Size(111, 20)
        Me.ColorUnActiveEdit2.TabIndex = 7
        '
        'ColorActiveEdit1
        '
        Me.ColorActiveEdit1.EditValue = System.Drawing.Color.Chartreuse
        Me.ColorActiveEdit1.Location = New System.Drawing.Point(170, 37)
        Me.ColorActiveEdit1.Name = "ColorActiveEdit1"
        Me.ColorActiveEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ColorActiveEdit1.Size = New System.Drawing.Size(111, 20)
        Me.ColorActiveEdit1.TabIndex = 6
        '
        'BtnChangeUnActiveColor
        '
        Me.BtnChangeUnActiveColor.Location = New System.Drawing.Point(287, 64)
        Me.BtnChangeUnActiveColor.Name = "BtnChangeUnActiveColor"
        Me.BtnChangeUnActiveColor.Size = New System.Drawing.Size(53, 23)
        Me.BtnChangeUnActiveColor.TabIndex = 5
        Me.BtnChangeUnActiveColor.Text = "ปรับปรุง"
        Me.BtnChangeUnActiveColor.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "สถานะปิดใช้งาน  ให้แสดงสี"
        '
        'BtnChangeActiveColor
        '
        Me.BtnChangeActiveColor.Location = New System.Drawing.Point(287, 35)
        Me.BtnChangeActiveColor.Name = "BtnChangeActiveColor"
        Me.BtnChangeActiveColor.Size = New System.Drawing.Size(53, 23)
        Me.BtnChangeActiveColor.TabIndex = 2
        Me.BtnChangeActiveColor.Text = "ปรับปรุง"
        Me.BtnChangeActiveColor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "สถานะเปิดใช้งาน ให้แสดงสี"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1015, 475)
        Me.XtraTabControl1.TabIndex = 4
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GroupControl2)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1009, 449)
        Me.XtraTabPage1.Text = "Display"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.SplitContainerControl1)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1009, 449)
        Me.GroupControl2.TabIndex = 0
        Me.GroupControl2.Text = "รายละเอียด"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GroupControl3)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1009, 449)
        Me.XtraTabPage2.Text = "Status"
        '
        'GroupControl3
        '
        Me.GroupControl3.Appearance.BackColor = System.Drawing.Color.White
        Me.GroupControl3.Appearance.Options.UseBackColor = True
        Me.GroupControl3.Controls.Add(Me.BtnDefaultFullColor)
        Me.GroupControl3.Controls.Add(Me.ColorFullEdit)
        Me.GroupControl3.Controls.Add(Me.BtnChangeFullColor)
        Me.GroupControl3.Controls.Add(Me.Label3)
        Me.GroupControl3.Controls.Add(Me.BtnDefaultUnActiveColor)
        Me.GroupControl3.Controls.Add(Me.ColorUnActiveEdit2)
        Me.GroupControl3.Controls.Add(Me.BtnChangeUnActiveColor)
        Me.GroupControl3.Controls.Add(Me.BtnDefaultActiveColor)
        Me.GroupControl3.Controls.Add(Me.Label2)
        Me.GroupControl3.Controls.Add(Me.Label1)
        Me.GroupControl3.Controls.Add(Me.BtnChangeActiveColor)
        Me.GroupControl3.Controls.Add(Me.ColorActiveEdit1)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(1009, 449)
        Me.GroupControl3.TabIndex = 0
        Me.GroupControl3.Text = "รายละเอียด"
        '
        'BtnDefaultFullColor
        '
        Me.BtnDefaultFullColor.Location = New System.Drawing.Point(346, 90)
        Me.BtnDefaultFullColor.Name = "BtnDefaultFullColor"
        Me.BtnDefaultFullColor.Size = New System.Drawing.Size(53, 23)
        Me.BtnDefaultFullColor.TabIndex = 13
        Me.BtnDefaultFullColor.Text = "คืนค่า"
        Me.BtnDefaultFullColor.UseVisualStyleBackColor = True
        '
        'ColorFullEdit
        '
        Me.ColorFullEdit.EditValue = System.Drawing.Color.IndianRed
        Me.ColorFullEdit.Location = New System.Drawing.Point(170, 92)
        Me.ColorFullEdit.Name = "ColorFullEdit"
        Me.ColorFullEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ColorFullEdit.Size = New System.Drawing.Size(111, 20)
        Me.ColorFullEdit.TabIndex = 12
        '
        'BtnChangeFullColor
        '
        Me.BtnChangeFullColor.Location = New System.Drawing.Point(287, 90)
        Me.BtnChangeFullColor.Name = "BtnChangeFullColor"
        Me.BtnChangeFullColor.Size = New System.Drawing.Size(53, 23)
        Me.BtnChangeFullColor.TabIndex = 11
        Me.BtnChangeFullColor.Text = "ปรับปรุง"
        Me.BtnChangeFullColor.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "สถานะเต็ม           ให้แสดงสี"
        '
        'frmZoneSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 475)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "frmZoneSettings"
        Me.Text = "Zone Setting"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.LsvZone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPETableNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorUnActiveEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorActiveEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.ColorFullEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LsvZone As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents VGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents SPETableNo As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ChkStatus As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents VColZone As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents VColZoneName As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents VColTable As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents VColActive As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnChangeActiveColor As System.Windows.Forms.Button
    Friend WithEvents BtnChangeUnActiveColor As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ColorActiveEdit1 As DevExpress.XtraEditors.ColorEdit
    Friend WithEvents ColorUnActiveEdit2 As DevExpress.XtraEditors.ColorEdit
    Friend WithEvents BtnDefaultUnActiveColor As System.Windows.Forms.Button
    Friend WithEvents BtnDefaultActiveColor As System.Windows.Forms.Button
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnDefaultFullColor As System.Windows.Forms.Button
    Friend WithEvents ColorFullEdit As DevExpress.XtraEditors.ColorEdit
    Friend WithEvents BtnChangeFullColor As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
