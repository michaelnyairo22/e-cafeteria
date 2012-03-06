Public Class frmAddOrderPrice 
    Dim FirstClick As Boolean = False
    Private Sub TxtQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty.EditValueChanged

    End Sub

    Private Sub TxtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub BtnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnter.Click
        Me.DialogResult = vbOK
        Me.Close()
    End Sub



    Private Sub frmAddOrderPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If IsNumeric(e.KeyCode) = False Then

        Else
            TxtQty.Text = e.KeyCode
        End If
    End Sub



    Private Sub frmAddOrderPrice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TxtQty.TabIndex = 0
        Me.TxtQty.Focus()
    End Sub

    Private Sub BtnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDown.Click
        If FirstClick = False Then
            TxtQty.Text = -1
            FirstClick = True
        Else
            TxtQty.Text = Val(TxtQty.Text) - 1
        End If
    End Sub

    Private Sub BtnNo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNo1.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNo1.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNo1.Text
        End If
    End Sub

    Private Sub BtnNO2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO2.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNO2.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNO2.Text
        End If
    End Sub

    Private Sub BtnNO3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO3.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNO3.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNO3.Text
        End If
    End Sub

    Private Sub BtnNO4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO4.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNO4.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNO4.Text
        End If

    End Sub

    Private Sub BtnNO5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO5.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNO5.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNO5.Text
        End If
    End Sub

    Private Sub BtnNO6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO6.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNO6.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNO6.Text
        End If

    End Sub

    Private Sub BtnNO7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO7.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNO7.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNO7.Text
        End If
    End Sub

    Private Sub BtnNO8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO8.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNO8.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNO8.Text
        End If

    End Sub

    Private Sub BtnNO9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO9.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNO9.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNO9.Text
        End If
    End Sub

    Private Sub BtnNO10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO10.Click
        If FirstClick = False Then
            TxtQty.Text = BtnNO10.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnNO10.Text
        End If
    End Sub

    Private Sub BtnDot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDot.Click
        If FirstClick = False Then
            TxtQty.Text = BtnDot.Text
            FirstClick = True
        Else
            TxtQty.Text = TxtQty.Text & BtnDot.Text
        End If
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        TxtQty.Text = BtnClear.Text
    End Sub

    Private Sub BtnUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUP.Click
        If FirstClick = False Then
            TxtQty.Text = 1
            FirstClick = True
        Else
            TxtQty.Text = Val(TxtQty.Text) + 1
        End If
    End Sub
End Class