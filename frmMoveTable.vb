Public Class frmMoveTable 

    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Public Curr_Zone As String
    Public Curr_Talbe As Integer
    Public Curr_Order As Integer
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMove.Click
        If MsgBox("คุณต้องการย้ายโต๊ะใช่หรือไม่", vbQuestion + vbYesNo, "กรุณายืนยันการย้ายโต๊ะ") = vbNo Then Exit Sub
        Try
            'Update Current Table = 1
            Strsql = "Update table_settings set table_status = 1 where table_zone = '" & My.Settings.CurrentZone & "' and table_name = " & My.Settings.CurrentTable
            _mysql.MySQLExecute(Strsql)

            'Update New Table = 3
            Strsql = "Update table_settings set table_status = 3 where table_zone = '" & Me.CboZone.Text & "' and table_name = " & Me.CboTable.Text
            _mysql.MySQLExecute(Strsql)

            'Update Order Zone and Table Information
            Strsql = "Update food_order set zone_id = '" & Me.CboZone.Text & "' , table_id = " & Me.CboTable.Text & "  where order_id = " & Curr_Order
            _mysql.MySQLExecute(Strsql)

            My.Settings.CurrentZone = Me.CboZone.Text
            My.Settings.CurrentTable = Me.CboTable.Text
            MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการบันทึกข้อมูล")
            Me.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub frmMoveTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub GroupControl2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupControl2.Paint

    End Sub
End Class