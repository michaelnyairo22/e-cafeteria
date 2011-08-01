<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintReceive
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintReceive))
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.Report1 = New FastReport.Report()
        CType(Me.Report1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(0, 0)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(918, 408)
        Me.PreviewControl1.TabIndex = 0
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        'Report1
        '
        Me.Report1.ReportResourceString = resources.GetString("Report1.ReportResourceString")
        '
        'frmPrintReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 408)
        Me.Controls.Add(Me.PreviewControl1)
        Me.Name = "frmPrintReceive"
        Me.Text = "ภาพก่อนพิมพ์"
        CType(Me.Report1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents Report1 As FastReport.Report
End Class
