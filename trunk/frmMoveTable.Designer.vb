<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoveTable
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
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboZone = New System.Windows.Forms.ComboBox()
        Me.CboTable = New System.Windows.Forms.ComboBox()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMove = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.Label1)
        Me.GroupControl2.Controls.Add(Me.BtnCancel)
        Me.GroupControl2.Controls.Add(Me.BtnMove)
        Me.GroupControl2.Controls.Add(Me.Label3)
        Me.GroupControl2.Controls.Add(Me.CboZone)
        Me.GroupControl2.Controls.Add(Me.CboTable)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(315, 115)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "ข้อมูลโต๊ะ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "โซน"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(160, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "โต๊ะ"
        '
        'CboZone
        '
        Me.CboZone.FormattingEnabled = True
        Me.CboZone.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"})
        Me.CboZone.Location = New System.Drawing.Point(51, 30)
        Me.CboZone.Name = "CboZone"
        Me.CboZone.Size = New System.Drawing.Size(83, 21)
        Me.CboZone.TabIndex = 0
        '
        'CboTable
        '
        Me.CboTable.FormattingEnabled = True
        Me.CboTable.Location = New System.Drawing.Point(197, 30)
        Me.CboTable.Name = "CboTable"
        Me.CboTable.Size = New System.Drawing.Size(83, 21)
        Me.CboTable.TabIndex = 1
        '
        'BtnCancel
        '
        Me.BtnCancel.Image = Global.Chaba.My.Resources.Resources.delete
        Me.BtnCancel.Location = New System.Drawing.Point(171, 66)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 37)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "ยกเลิก"
        '
        'BtnMove
        '
        Me.BtnMove.Image = Global.Chaba.My.Resources.Resources.element_next
        Me.BtnMove.Location = New System.Drawing.Point(81, 66)
        Me.BtnMove.Name = "BtnMove"
        Me.BtnMove.Size = New System.Drawing.Size(86, 37)
        Me.BtnMove.TabIndex = 3
        Me.BtnMove.Text = "ย้ายโต๊ะ"
        '
        'frmMoveTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 115)
        Me.Controls.Add(Me.GroupControl2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMoveTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ย้ายโต๊ะ"
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboTable As System.Windows.Forms.ComboBox
    Friend WithEvents BtnMove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboZone As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
End Class
