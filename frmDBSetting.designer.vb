<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBSetting
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDBSetting))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TxtDatabase = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPassword = New System.Windows.Forms.TextBox
        Me.TxtUser = New System.Windows.Forms.TextBox
        Me.TxtPort = New System.Windows.Forms.TextBox
        Me.TxtHost = New System.Windows.Forms.TextBox
        Me.lblPort = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblHost = New System.Windows.Forms.Label
        Me.BtnOK = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnTest = New System.Windows.Forms.Button
        Me.MySQLLogo = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.MySQLLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.TxtDatabase)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtPassword)
        Me.GroupBox1.Controls.Add(Me.TxtUser)
        Me.GroupBox1.Controls.Add(Me.TxtPort)
        Me.GroupBox1.Controls.Add(Me.TxtHost)
        Me.GroupBox1.Controls.Add(Me.lblPort)
        Me.GroupBox1.Controls.Add(Me.lblPassword)
        Me.GroupBox1.Controls.Add(Me.lblUser)
        Me.GroupBox1.Controls.Add(Me.lblHost)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(334, 158)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connect to MySQL Server"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(37, 133)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(209, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "ไม่ต้องแสดงหน้านี้ตอนเริ่มโปรแกรมอีก"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TxtDatabase
        '
        Me.TxtDatabase.Location = New System.Drawing.Point(104, 107)
        Me.TxtDatabase.Name = "TxtDatabase"
        Me.TxtDatabase.Size = New System.Drawing.Size(126, 20)
        Me.TxtDatabase.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Database:"
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(103, 81)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(126, 20)
        Me.TxtPassword.TabIndex = 4
        Me.TxtPassword.UseSystemPasswordChar = True
        '
        'TxtUser
        '
        Me.TxtUser.Location = New System.Drawing.Point(103, 55)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(127, 20)
        Me.TxtUser.TabIndex = 3
        '
        'TxtPort
        '
        Me.TxtPort.Location = New System.Drawing.Point(275, 29)
        Me.TxtPort.Name = "TxtPort"
        Me.TxtPort.Size = New System.Drawing.Size(46, 20)
        Me.TxtPort.TabIndex = 2
        '
        'TxtHost
        '
        Me.TxtHost.Location = New System.Drawing.Point(103, 29)
        Me.TxtHost.Name = "TxtHost"
        Me.TxtHost.Size = New System.Drawing.Size(127, 20)
        Me.TxtHost.TabIndex = 1
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(240, 32)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(29, 13)
        Me.lblPort.TabIndex = 3
        Me.lblPort.Text = "Port:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(33, 84)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password:"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(31, 55)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(58, 13)
        Me.lblUser.TabIndex = 1
        Me.lblUser.Text = "Username:"
        '
        'lblHost
        '
        Me.lblHost.AutoSize = True
        Me.lblHost.Location = New System.Drawing.Point(31, 32)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(66, 13)
        Me.lblHost.TabIndex = 0
        Me.lblHost.Text = "Server Host:"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(195, 242)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(70, 25)
        Me.BtnOK.TabIndex = 7
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(271, 242)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(70, 25)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "Close"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnTest
        '
        Me.BtnTest.Location = New System.Drawing.Point(117, 243)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(72, 24)
        Me.BtnTest.TabIndex = 6
        Me.BtnTest.Text = "Test"
        Me.BtnTest.UseVisualStyleBackColor = True
        '
        'MySQLLogo
        '
        Me.MySQLLogo.Image = CType(resources.GetObject("MySQLLogo.Image"), System.Drawing.Image)
        Me.MySQLLogo.Location = New System.Drawing.Point(-5, 0)
        Me.MySQLLogo.Name = "MySQLLogo"
        Me.MySQLLogo.Size = New System.Drawing.Size(355, 72)
        Me.MySQLLogo.TabIndex = 6
        Me.MySQLLogo.TabStop = False
        '
        'frmDBSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 274)
        Me.Controls.Add(Me.BtnTest)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.MySQLLogo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDBSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ตั้งค่า connection"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.MySQLLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents TxtPort As System.Windows.Forms.TextBox
    Friend WithEvents TxtHost As System.Windows.Forms.TextBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblHost As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents MySQLLogo As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnTest As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
