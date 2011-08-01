Public Class frmbooking 
    Public primary_key As Integer
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Private Sub frmbooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.CboZone.Text = My.Settings.CurrentZone
            With CboTable
                For i = 1 To 80
                    .Items.Add(i)

                Next
                .Text = My.Settings.CurrentTable
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub BtnBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBook.Click
        If MsgBox("คุณต้องการบันทึกข้อมูลการจองใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยีน") = MsgBoxResult.Yes Then
            Try
                Strsql = "Update food_order set order_status  = 3  where order_id = " & primary_key
                _mysql.MySQLExecute(Strsql)
                MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", vbInformation, "ผลการบันทึกข้อมูล")

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
        End If
    End Sub
End Class