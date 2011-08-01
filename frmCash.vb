Imports System.IO

Public Class frmCash
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Public Order_Id As Integer
    Public Order_billno As String
#Region "Function"
    Sub Print_Receipt()
        Try
            Dim FILE_NAME As String = "C:\Temp\cash.txt"
            Dim i As Integer = 1
            Dim aryText(4) As String



            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            Strsql = "Select * from app_settings"
            Dim DT_AppSetting As New DataTable
            DT_AppSetting = _mysql.GetMYSQLDataTable(Strsql, "app_setting")
            objWriter.WriteLine(DT_AppSetting.Rows(0).Item("cafeteria_name").ToString)
            objWriter.WriteLine("Tel. " & DT_AppSetting.Rows(0).Item("cafeteria_tel").ToString & "  Fax. " & DT_AppSetting.Rows(0).Item("cafeteria_fax").ToString)
            objWriter.WriteLine("RECIEPT")
            objWriter.WriteLine("DATE : " & Now())
            objWriter.WriteLine("RECIEPT NO : " & Order_billno)

            'order_billno
            'objWriter.WriteLine("N")
            Strsql = "SELECT * FROM food_order left Join food_order_detail ON  food_order.order_id = food_order_detail.order_food_id  left Join menu ON food_order_detail.order_detail_menu_id =  menu.menu_id  where order_id = " & Order_Id
            Dim DT_FDetail As New DataTable
            DT_FDetail = _mysql.GetMYSQLDataTable(Strsql, "food_order_detail")
            objWriter.WriteLine("โต๊ะที่ " & DT_FDetail.Rows(0).Item("zone_id").ToString & (DT_FDetail.Rows(i).Item("table_id").ToString))
            objWriter.WriteLine("-----------------------------")

            For i = 0 To DT_FDetail.Rows.Count - 1
                Dim StrMenu As String = DT_FDetail.Rows(i).Item("menu_name").ToString
                For j = 1 To (30 - Len(DT_FDetail.Rows(i).Item("menu_name").ToString))
                    StrMenu = StrMenu & " "
                Next
                StrMenu = StrMenu & DT_FDetail.Rows(0).Item("order_detail_qty").ToString & "     " & DT_FDetail.Rows(0).Item("menu_price").ToString()

                objWriter.WriteLine(StrMenu)
            Next
            objWriter.WriteLine("-----------------------------")
            objWriter.WriteLine("CASH         " & Me.TxtReceive.Text)
            objWriter.WriteLine("CHANGE       " & Me.TxtTorn.Text)
            objWriter.Close()
            '     Thread.Sleep(1000)

            ' Shell("cmd /b COPY 'C:\Temp\test.txt' LPT1", AppWinStyle.Hide)

            File.Copy("C:\Temp\cash.txt", "LPT1")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub LabelControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelControl1.Click

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Dispose()
    End Sub

    Private Sub frmCash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtReceive.Focus()
    End Sub

    Private Sub TxtReceive_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtReceive.EditValueChanged
        Me.TxtTorn.Text = Val(Me.TxtReceive.EditValue) - Val(Me.TxtPrice.EditValue)
    End Sub


    Private Sub BtnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCash.Click
        Dim Billno As Integer
        If Val(Me.TxtReceive.EditValue) = 0 Then
            MsgBox("กรุณาใส่จำนวนเงิน", MsgBoxStyle.Exclamation, "ไม่สามารถทำรายการชำระเงินได้")
            Exit Sub
        End If
        If Val(Me.TxtReceive.EditValue) < Val(Me.TxtPrice.EditValue) Then
            MsgBox("จำนวนเงินที่รับมาน้อยกว่ายอดที่ต้องชำระ", MsgBoxStyle.Exclamation, "ไม่สามารถทำรายการชำระเงินได้")
            Exit Sub
        End If
        If MsgBox("คุณต้องการยืนยีนการชำระเงินใช่หรือไม่", vbQuestion + vbYesNo, "ยืนยันการชำระเงิน") = vbNo Then
            Exit Sub
        Else
            If My.Settings.UserCashDrawer = "Y" Then

                Try
                    With SerialPort1
                        .PortName = "COM1"
                        .BaudRate = 9600
                        .DataBits = 8
                        .Parity = IO.Ports.Parity.None
                        .StopBits = IO.Ports.StopBits.One
                        .Open()
                        .Write("1234")
                        .Close()
                    End With
                Catch ex As Exception
                    If Err.Number = 57 Then
                        MsgBox("ไม่พบลิ้นชักเก็บเงินที่ Port COM1", MsgBoxStyle.Critical, "พบข้อผิดพลาด")
                    Else
                        MsgBox(Err.Number & " : " & ex.Message)
                    End If
                End Try
            End If
            Try
                MsgBox("เงินทอน " & Me.TxtTorn.EditValue & " บาท", MsgBoxStyle.Information, "เงินทอน")
                Strsql = "Update food_order set order_status = 2,billing_datetime = now() where order_id = " & Order_Id
                _mysql.MySQLExecute(Strsql)

                Strsql = "Update table_settings set table_status = 1 where table_zone = '" & My.Settings.CurrentZone & "' and table_name = '" & My.Settings.CurrentTable & "'"
                _mysql.MySQLExecute(Strsql)

                MsgBox("บันทึกขัอมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการบันทึกข้อมูล")
                Me.Dispose()




                'Update Serial
                Try
                    Strsql = "Select food_order_serial from food_order_serial where food_order_date = '" & Pn_Framework.MysqlDateTimeFormat(Now, False) & "'"
                    Dim DT_SerialNO As New DataTable
                    DT_SerialNO = _mysql.GetMYSQLDataTable(Strsql, "food_order_serial")
                    If DT_SerialNO.Rows.Count > 0 Then
                        Order_billno = DT_SerialNO.Rows(0).Item("food_order_serial") + 1
                        Strsql = "Update food_order_serial set food_order_serial = " & Order_billno
                        _mysql.MySQLExecute(Strsql)
                    Else
                        Order_billno = 1
                        Strsql = "Insert into food_order_serial (food_order_serial,food_order_date) values (1,now())"
                        _mysql.MySQLExecute(Strsql)
                    End If
                Catch ex As Exception
                    With frmDebug
                        .lblFormName.Text = Me.Name
                        .lblFunctionName.Text = "BtnCash_Click"
                        .MemoErr_Description.Text = ex.Message
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
                End Try


                ''Get Billno
                'Try
                '    Strsql = "Select food_order_serial from food_order_serial where food_order_date = '" & Pn_Framework.MysqlDateTimeFormat(Now, False) & "'"
                '    Billno = _mysql.MySQLExecuteScalar(Strsql)

                'Catch ex As Exception
                '    With frmDebug
                '        .lblFormName.Text = Me.Name
                '        .lblFunctionName.Text = "BtnCash_Click"
                '        .MemoErr_Description.Text = ex.Message
                '        .MemoSQL.Text = Strsql
                '        .ShowDialog()
                '    End With
                'End Try


                Try
                    Strsql = "Update food_order set order_billno = '" & Pn_Framework.MysqlDateTimeFormat(Now, False) & "/" & Order_billno & "' where order_id = " & Order_Id
                    _mysql.MySQLExecute(Strsql)
                Catch ex As Exception
                    With frmDebug
                        .lblFormName.Text = Me.Name
                        .lblFunctionName.Text = "BtnCash_Click"
                        .MemoErr_Description.Text = ex.Message
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
                End Try

                Me.Order_billno = Pn_Framework.MysqlDateTimeFormat(Now, False) & "/" & Order_billno

                Print_Receipt()

                frmNewOrder.Dispose()


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End If
    End Sub

    Private Sub TxtReceive_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtReceive.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                BtnCash_Click(sender, e)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnPrintReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class