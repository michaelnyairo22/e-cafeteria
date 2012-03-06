Imports System.Windows.Forms

Public Class DlgEditGroup
    Public Primarykey As Integer
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Try
            Strsql = "Select count(*) as cc from menugroup where group_name  = '" & Me.TextBox1.Text & "' and group_id <> " & Primarykey
            If _mysql.MySQLExecuteScalar(Strsql) > 0 Then
                MsgBox("ชื่อกลุ่มนี้มีอยู่แล้ว กรุณาตรวจสอบ", MsgBoxStyle.Exclamation, "ไม่สามารถเพิ่มได้")
                Exit Sub
            Else
                Strsql = "Update menugroup set group_name = '" & TextBox1.Text & "' where  group_id = " & Primarykey
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        MsgBox("ขอภัยไม่สามารถลบได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug
                            .lblFormName.Text = "ClsMenu"
                            .lblFunctionName.Text = "Delete_Menu"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            End If
        Catch ex As Exception
            With frmDebug

                .lblFormName.Text = "DlgEditGroup"
                .lblFunctionName.Text = "OK_Button_Click"
                .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgEditGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Strsql = "Select group_name from  menugroup where group_id = " & Primarykey
        Me.TextBox1.Text = _mysql.MySQLExecuteScalar(Strsql)
    End Sub
End Class
