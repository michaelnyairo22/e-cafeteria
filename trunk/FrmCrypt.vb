
Public Class FrmCrypt

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TextBox2.Text = Crypto.Crypto.Encrypt(Me.TextBox1.Text, "sys11266")
    End Sub
End Class