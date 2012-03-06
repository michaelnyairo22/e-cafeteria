Imports System.Windows.Forms

Public Class DlgAddNewGroup
    Public Primarykey As Integer
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Strsql = "Select count(*) as cc from menugroup where group_name  = '" & Me.TextBox1.Text & "'"
            If _mysql.MySQLExecuteScalar(Strsql) > 0 Then
                MsgBox("ชื่อกลุ่มนี้มีอยู่แล้ว กรุณาตรวจสอบ", MsgBoxStyle.Exclamation, "ไม่สามารถเพิ่มได้")
                Exit Sub
            Else
                Strsql = "Insert into menugroup (group_name) values ('" & TextBox1.Text & "')"
                 Select _mysql.MySQLExecute(Strsql)
                    Case 0
                        MsgBox("ขอภัยไม่สามารถเพิ่มได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการเพิ่ม")
                    Case Is > 0
                        MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการเพิ่")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    Case -1
                        MsgBox("ขอภัยไม่สามารถลบได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการลบ")
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

                .lblFormName.Text = "DlgAddNewGroup"
                .lblFunctionName.Text = "OK_Button_Click"
                .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
