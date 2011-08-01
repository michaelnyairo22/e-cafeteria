Public Class frmTables 
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Dim DT_Table As New DataTable
    Dim MyTable As New ClsTable
    Public Zone As String
#Region "Functjion"

    Sub Change_TableStatus(ByVal MyButton As Button)
        MsgBox("โต๊ะนี้มีลูกค้าใช้บริการอยู่คุณต้องการ")
        If MyButton.TextAlign = ContentAlignment.TopCenter Then
            MyButton.TextAlign = ContentAlignment.MiddleCenter
            MyButton.Image = Nothing
        Else
            MyButton.TextAlign = ContentAlignment.TopCenter
            '  MyButton.Image = E_Cafeteria.My.Resources.Resources.cus24X24
            MyButton.ImageAlign = ContentAlignment.BottomCenter
        End If

    End Sub
    Sub Load_Setting()
        Try
            Strsql = "Select * from table_settings  where  table_zone = '" & My.Settings.CurrentZone & "'"
            DT_Table = _mysql.GetMYSQLDataTable(Strsql, "tablesettings")
        Catch ex As Exception
            With frmDebug

                .lblFormName.Text = "frmTables"
                .lblFunctionName.Text = "Load_Setting"
                .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try


    End Sub
    Sub Seting_Status(ByVal Curr_Status As Integer, ByVal CurrBtn As Button)
        Select Case Curr_Status
            Case 1
                CurrBtn.Enabled = True
                CurrBtn.BackColor = MyTable.EnableColor


            Case 2
                CurrBtn.Enabled = False
                CurrBtn.BackColor = MyTable.BookingColor


            Case 3
                CurrBtn.Enabled = False
                CurrBtn.BackColor = MyTable.BusyColor

            Case 4
                CurrBtn.Enabled = False
                CurrBtn.BackColor = MyTable.WaitCheckBillColor

            Case 5
                CurrBtn.Enabled = False
                CurrBtn.BackColor = MyTable.WaitFoodColor

            Case 6
                CurrBtn.Enabled = False
                CurrBtn.BackColor = MyTable.DisableColor

        End Select
    End Sub
    Sub ShowDetail(ByVal TableNo As String)
        'Me.VGridTableNo.Properties.Value = TableNo
        'Strsql = "Select ifnull(tableno,'') as tableno,ifnull(bookingname,'') as bookingname,ifnull(order_no,'') as order_no,"
        'Strsql = Strsql & " ifnull(totalcustomer,0) as totalcustomer,ifnull(totalprice,0) as totalprice,table_status_name"
        'Strsql = Strsql & " ,ifnull(table_status,'') as table_status from table_info left join table_status on table_info.table_status = table_status.table_status_id "
        'Strsql = Strsql & "  where tableno = '" & TableNo & "' and zone_no = '" & Zone & "'"
        'Dim DT_Tableinfo As New DataTable
        'DT_Tableinfo = _mysql.GetMYSQLDataTable(Strsql, "Table_info")
        'Select Case DT_Tableinfo.Rows.Count
        '    Case Is > 0
        '        DT_Tableinfo = _mysql.GetMYSQLDataTable(Strsql, "tableno")
        '        VGridBookingName.Properties.Value = DT_Tableinfo.Rows(0).Item("bookingname").ToString
        '        VGridOrderNo.Properties.Value = DT_Tableinfo.Rows(0).Item("order_no").ToString
        '        VGridTotalCustomer.Properties.Value = Val(DT_Tableinfo.Rows(0).Item("totalcustomer"))
        '        VGridTotalPrice.Properties.Value = Val(DT_Tableinfo.Rows(0).Item("totalprice"))
        '        VGridStatus.Properties.Value = DT_Tableinfo.Rows(0).Item("table_status_name").ToString
        '    Case 0
        '        If (MsgBox("ยืนยันการเปิดโต๊ะ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "กรุณายืนยันการเปิดโต๊ะ")) = MsgBoxResult.No Then Exit Sub
        '        Strsql = "Insert into table_info (zone_no,tableno) value ('" & Zone & "','" & TableNo & "')"
        '        _mysql.MySQLExecute(Strsql)
        '        ShowDetail(TableNo)
        '    Case Is > 0

        'End Select

    End Sub
#End Region
    Private Sub PanelControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelControl1.Paint

    End Sub

    Private Sub BtnTable01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable01.Click
        My.Settings.CurrentTable = 1
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub frmTables_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.CurrentTable = -1 Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If


    End Sub

    Private Sub frmTables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'BtnTable01
        My.Settings.CurrentTable = -1
        Load_Setting()
        Dim TableName As String
        Try
            For Each btn As Control In Me.PanelControl1.Controls
                If TypeOf btn Is Button Then
                    TableName = Mid(CType(btn, Button).Name, 9, 2).ToString
                    For Each DRTableStatus In DT_Table.Select("table_name = " & Val(Mid(CType(btn, Button).Name, 9, 2).ToString))
                        CType(btn, Button).Enabled = True
                        CType(btn, Button).BackColor = Color.FromName(MyTable.Get_Color_Status(DRTableStatus("table_status")))
                        CType(btn, Button).Text = DRTableStatus("table_displaytext").ToString

                        Exit For
                    Next

                End If
            Next

        Catch ex As Exception
            MsgBox("frmTables_Load : " & "table_name = " & TableName & " : " & ex.Message)
        End Try
    End Sub

    Private Sub GroupControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub BtnTable02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable02.Click
        My.Settings.CurrentTable = 2
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable03.Click
        My.Settings.CurrentTable = 3
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable04.Click
        My.Settings.CurrentTable = 4
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable05.Click
        My.Settings.CurrentTable = 5
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable06.Click
        My.Settings.CurrentTable = 6
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable07.Click
        My.Settings.CurrentTable = 7
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable08.Click
        My.Settings.CurrentTable = 8
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable09.Click
        My.Settings.CurrentTable = 9
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable10.Click
        My.Settings.CurrentTable = 10
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable11.Click
        My.Settings.CurrentTable = 11
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable12.Click
        My.Settings.CurrentTable = 12
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable13.Click
        My.Settings.CurrentTable = 13
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable14.Click
        My.Settings.CurrentTable = 14
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable15.Click
        My.Settings.CurrentTable = 15
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable16.Click
        My.Settings.CurrentTable = 16
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable17.Click
        My.Settings.CurrentTable = 17
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable18.Click
        My.Settings.CurrentTable = 18
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable19.Click
        My.Settings.CurrentTable = 19
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable20.Click
        My.Settings.CurrentTable = 20
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable21.Click
        My.Settings.CurrentTable = 21
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable22.Click
        My.Settings.CurrentTable = 22
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable23.Click
        My.Settings.CurrentTable = 23
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable24.Click
        My.Settings.CurrentTable = 24
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable25.Click
        My.Settings.CurrentTable = 25
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable26.Click
        My.Settings.CurrentTable = 26
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable27.Click
        My.Settings.CurrentTable = 27
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable28.Click
        My.Settings.CurrentTable = 28
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable29.Click
        My.Settings.CurrentTable = 29
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable30.Click
        My.Settings.CurrentTable = 30
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable31.Click
        My.Settings.CurrentTable = 31
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable32.Click
        My.Settings.CurrentTable = 32
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable33.Click
        My.Settings.CurrentTable = 33
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable34.Click
        My.Settings.CurrentTable = 34
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable35.Click
        My.Settings.CurrentTable = 35
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable36.Click
        My.Settings.CurrentTable = 36
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable37.Click
        My.Settings.CurrentTable = 37
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable38.Click
        My.Settings.CurrentTable = 38
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable39.Click
        My.Settings.CurrentTable = 39
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnTable40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTable40.Click
        My.Settings.CurrentTable = 40
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable41.Click
        My.Settings.CurrentTable = 41
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable42.Click
        My.Settings.CurrentTable = 42
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable43.Click
        My.Settings.CurrentTable = 43
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable44.Click
        My.Settings.CurrentTable = 44
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable45.Click
        My.Settings.CurrentTable = 45
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable46.Click
        My.Settings.CurrentTable = 46
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable47.Click
        My.Settings.CurrentTable = 47
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable48.Click
        My.Settings.CurrentTable = 48
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable49.Click
        My.Settings.CurrentTable = 49
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable50.Click
        My.Settings.CurrentTable = 50
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable51.Click
        My.Settings.CurrentTable = 51
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable52.Click
        My.Settings.CurrentTable = 52
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable53.Click
        My.Settings.CurrentTable = 53
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable54.Click
        My.Settings.CurrentTable = 54
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable55.Click
        My.Settings.CurrentTable = 55
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable56.Click
        My.Settings.CurrentTable = 56
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable57.Click
        My.Settings.CurrentTable = 57
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable58.Click
        My.Settings.CurrentTable = 58
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable59_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable59.Click
        My.Settings.CurrentTable = 59
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable60.Click
        My.Settings.CurrentTable = 60
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable61.Click
        My.Settings.CurrentTable = 61
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable62.Click
        My.Settings.CurrentTable = 62
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable63.Click
        My.Settings.CurrentTable = 63
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable64.Click
        My.Settings.CurrentTable = 64
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable65.Click
        My.Settings.CurrentTable = 65
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable66.Click
        My.Settings.CurrentTable = 66
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable67.Click
        My.Settings.CurrentTable = 67
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable68_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable68.Click
        My.Settings.CurrentTable = 68
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable69_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable69.Click
        My.Settings.CurrentTable = 69
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable70_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable70.Click
        My.Settings.CurrentTable = 70
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable71.Click
        My.Settings.CurrentTable = 71
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable72.Click
        My.Settings.CurrentTable = 72
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable73.Click
        My.Settings.CurrentTable = 73
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable74_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable74.Click
        My.Settings.CurrentTable = 74
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable75.Click
        My.Settings.CurrentTable = 75
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable76_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable76.Click
        My.Settings.CurrentTable = 76
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable77_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable77.Click
        My.Settings.CurrentTable = 77
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable78_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable78.Click
        My.Settings.CurrentTable = 78
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable79_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable79.Click
        My.Settings.CurrentTable = 79
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub btnTable80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTable80.Click
        My.Settings.CurrentTable = 80
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub
End Class