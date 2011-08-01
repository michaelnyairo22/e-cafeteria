
Public Class frmReceipt
#Region "Function"
    Public Sub open_cashdrawer()
        Dim intFileNo As Integer = FreeFile()
        FileOpen(1, "c:\escapes.txt", OpenMode.Output)
        PrintLine(1, Chr(27) & "p" & Chr(0) & Chr(25) & Chr(250))
        FileClose(1)
        Shell("print /d:lpt1 c:\escapes.txt", vbNormalFocus)
    End Sub
#End Region
    Private Sub BtnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCash.Click
        open_cashdrawer()
    End Sub
End Class