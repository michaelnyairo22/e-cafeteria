<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCash
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
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPrice = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtReceive = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtTorn = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnCash = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtReceive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTorn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(455, 238)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(40, 25)
        Me.LabelControl9.TabIndex = 29
        Me.LabelControl9.Text = "บาท"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(12, 228)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(82, 25)
        Me.LabelControl10.TabIndex = 27
        Me.LabelControl10.Text = "รับเงินมา"
        '
        'TxtPrice
        '
        Me.TxtPrice.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtPrice.Location = New System.Drawing.Point(109, 169)
        Me.TxtPrice.Name = "TxtPrice"
        Me.TxtPrice.Properties.Appearance.BackColor = System.Drawing.Color.Black
        Me.TxtPrice.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrice.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.TxtPrice.Properties.Appearance.Options.UseBackColor = True
        Me.TxtPrice.Properties.Appearance.Options.UseFont = True
        Me.TxtPrice.Properties.Appearance.Options.UseForeColor = True
        Me.TxtPrice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtPrice.Properties.ReadOnly = True
        Me.TxtPrice.Size = New System.Drawing.Size(329, 45)
        Me.TxtPrice.TabIndex = 26
        Me.TxtPrice.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(12, 172)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(47, 25)
        Me.LabelControl5.TabIndex = 25
        Me.LabelControl5.Text = "ราคา"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(455, 183)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(40, 25)
        Me.LabelControl1.TabIndex = 30
        Me.LabelControl1.Text = "บาท"
        '
        'TxtReceive
        '
        Me.TxtReceive.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtReceive.Location = New System.Drawing.Point(109, 221)
        Me.TxtReceive.Name = "TxtReceive"
        Me.TxtReceive.Properties.Appearance.BackColor = System.Drawing.Color.Black
        Me.TxtReceive.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReceive.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.TxtReceive.Properties.Appearance.Options.UseBackColor = True
        Me.TxtReceive.Properties.Appearance.Options.UseFont = True
        Me.TxtReceive.Properties.Appearance.Options.UseForeColor = True
        Me.TxtReceive.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtReceive.Size = New System.Drawing.Size(329, 45)
        Me.TxtReceive.TabIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(455, 286)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(40, 25)
        Me.LabelControl2.TabIndex = 34
        Me.LabelControl2.Text = "บาท"
        '
        'TxtTorn
        '
        Me.TxtTorn.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtTorn.Location = New System.Drawing.Point(109, 272)
        Me.TxtTorn.Name = "TxtTorn"
        Me.TxtTorn.Properties.Appearance.BackColor = System.Drawing.Color.Black
        Me.TxtTorn.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTorn.Properties.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.TxtTorn.Properties.Appearance.Options.UseBackColor = True
        Me.TxtTorn.Properties.Appearance.Options.UseFont = True
        Me.TxtTorn.Properties.Appearance.Options.UseForeColor = True
        Me.TxtTorn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtTorn.Properties.ReadOnly = True
        Me.TxtTorn.Size = New System.Drawing.Size(329, 45)
        Me.TxtTorn.TabIndex = 33
        Me.TxtTorn.TabStop = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(12, 282)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 25)
        Me.LabelControl3.TabIndex = 32
        Me.LabelControl3.Text = "เงินทอน"
        '
        'BtnCash
        '
        Me.BtnCash.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCash.Appearance.Options.UseFont = True
        Me.BtnCash.Location = New System.Drawing.Point(155, 341)
        Me.BtnCash.Name = "BtnCash"
        Me.BtnCash.Size = New System.Drawing.Size(127, 34)
        Me.BtnCash.TabIndex = 1
        Me.BtnCash.Text = "ยืนยันการชำระเงิน"
        '
        'BtnClose
        '
        Me.BtnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Appearance.Options.UseFont = True
        Me.BtnClose.Location = New System.Drawing.Point(288, 341)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(127, 34)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "ยกเลิก"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = Global.Chaba.My.Resources.Resources.bonus_cash_game
        Me.PictureEdit1.Location = New System.Drawing.Point(12, 10)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.PictureEdit1.Size = New System.Drawing.Size(486, 146)
        Me.PictureEdit1.TabIndex = 0
        '
        'frmCash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 387)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnCash)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtTorn)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtReceive)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.TxtPrice)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.PictureEdit1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ชำระเงิน"
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtReceive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTorn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPrice As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtReceive As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtTorn As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnCash As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
