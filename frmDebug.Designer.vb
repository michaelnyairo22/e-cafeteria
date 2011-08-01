<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDebug
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDebug))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.lblFunctionName = New DevExpress.XtraEditors.LabelControl()
        Me.lblFormName = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.MemoErr_Description = New DevExpress.XtraEditors.MemoEdit()
        Me.MemoSQL = New DevExpress.XtraEditors.MemoEdit()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.MemoCallStack = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.MemoErr_Description.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoSQL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.MemoCallStack.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.lblFunctionName)
        Me.PanelControl1.Controls.Add(Me.lblFormName)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(692, 69)
        Me.PanelControl1.TabIndex = 75
        '
        'lblFunctionName
        '
        Me.lblFunctionName.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFunctionName.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblFunctionName.Location = New System.Drawing.Point(109, 31)
        Me.lblFunctionName.Name = "lblFunctionName"
        Me.lblFunctionName.Size = New System.Drawing.Size(32, 13)
        Me.lblFunctionName.TabIndex = 10
        Me.lblFunctionName.Text = "ไม่ระบุ"
        '
        'lblFormName
        '
        Me.lblFormName.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormName.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblFormName.Location = New System.Drawing.Point(62, 12)
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(32, 13)
        Me.lblFormName.TabIndex = 9
        Me.lblFormName.Text = "ไม่ระบุ"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(13, 31)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Function / Sub : "
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(13, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Form : "
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.LabelControl1.Location = New System.Drawing.Point(12, 50)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(95, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "Error Description"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnCancel)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 394)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(692, 46)
        Me.PanelControl2.TabIndex = 89
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(602, 11)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 34
        Me.BtnCancel.Text = "ปิด"
        '
        'MemoErr_Description
        '
        Me.MemoErr_Description.Dock = System.Windows.Forms.DockStyle.Top
        Me.MemoErr_Description.Location = New System.Drawing.Point(0, 69)
        Me.MemoErr_Description.Name = "MemoErr_Description"
        Me.MemoErr_Description.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MemoErr_Description.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.MemoErr_Description.Properties.Appearance.Options.UseFont = True
        Me.MemoErr_Description.Properties.Appearance.Options.UseForeColor = True
        Me.MemoErr_Description.Properties.ReadOnly = True
        Me.MemoErr_Description.Size = New System.Drawing.Size(692, 69)
        Me.MemoErr_Description.TabIndex = 90
        '
        'MemoSQL
        '
        Me.MemoSQL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MemoSQL.EditValue = ""
        Me.MemoSQL.Location = New System.Drawing.Point(0, 0)
        Me.MemoSQL.Name = "MemoSQL"
        Me.MemoSQL.Properties.ReadOnly = True
        Me.MemoSQL.Size = New System.Drawing.Size(686, 230)
        Me.MemoSQL.TabIndex = 92
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 138)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(692, 256)
        Me.XtraTabControl1.TabIndex = 93
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.MemoSQL)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(686, 230)
        Me.XtraTabPage1.Text = "SQL Comand"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.MemoCallStack)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(686, 230)
        Me.XtraTabPage2.Text = "Call Stack"
        '
        'MemoCallStack
        '
        Me.MemoCallStack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MemoCallStack.EditValue = ""
        Me.MemoCallStack.Location = New System.Drawing.Point(0, 0)
        Me.MemoCallStack.Name = "MemoCallStack"
        Me.MemoCallStack.Properties.ReadOnly = True
        Me.MemoCallStack.Size = New System.Drawing.Size(686, 230)
        Me.MemoCallStack.TabIndex = 93
        '
        'frmDebug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 440)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.MemoErr_Description)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDebug"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Debug"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.MemoErr_Description.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoSQL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.MemoCallStack.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MemoErr_Description As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents MemoSQL As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblFunctionName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblFormName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents MemoCallStack As DevExpress.XtraEditors.MemoEdit
End Class
