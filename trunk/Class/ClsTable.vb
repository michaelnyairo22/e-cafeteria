Public Class ClsTable
    Dim Table_Start_Sit_Time As DateTime = Now
    Dim Table_Stop_Sit_Time As DateTime = Now
    Dim DT_Table As New DataTable
    Dim DT_TableStatus As New DataTable
    Dim DR_Table As DataRow
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Dim Enable_Color As Color
    Dim Disable_Color As Color
    Dim Full_Color As Color
    Dim DefaultEnable_Color As Color = Color.Chartreuse
    Dim DefaultDisable_Color As Color = Color.Gainsboro
    Dim DefaultFull_Color As Color = Color.Red
    Dim DefaultBooking_Color As Color = Color.Khaki
    Dim DefaultBusy_Color As Color = Color.Red
    Dim DefaultWaitFood_Color As Color = Color.Yellow
    Dim DefaultWaitCheckBill_Color As Color = Color.DarkOrange

    Public ReadOnly Property Get_StartTime
        Get
            Return Table_Start_Sit_Time
        End Get
    End Property
    Public ReadOnly Property Get_StopTime
        Get
            Return Table_Stop_Sit_Time
        End Get
    End Property
    Public ReadOnly Property Get_DataTable(ByVal Zone As String) As DataTable
        Get
            Strsql = "Select * from table_settings where table_zone = '" & Zone & "' order by table_Name"
            DT_Table = _mysql.GetMYSQLDataTable(Strsql, "table_settings")

            Return DT_Table

        End Get
    End Property
    Public ReadOnly Property Get_DataRow(ByVal Zone As String, ByVal TableNo As String) As DataRow
        Get


            Try

                For Each DR_Table In DT_Table.Select("table_zone='" & Zone & "' and table_Name = '" & TableNo & "'")
                    'DRZone("zone_name").ToString()
                    'DRZone("zone_displaytext").ToString()
                    'DRZone("zone_status").ToString()
                    'DRZone("zone_tables").ToString()
                    Exit For
                Next
                Return DR_Table
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Get
    End Property
    Public Property Total_Table(ByVal Zone As String) As Integer

        Get
            Dim TotalTables As Integer
            Strsql = "Select zone_tables from zone_settings where zone_name = '" & Zone & "'"
            TotalTables = _mysql.MySQLExecuteScalar(Strsql)

            Return TotalTables

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property
    Function Create_Table(ByVal Zone As String, ByVal TotalTable As Integer)
    
        Try
            Dim Curr_Table As Integer
            Strsql = "Select count(*) from table_settings where table_zone = '" & Zone & "'"
            Curr_Table = _mysql.MySQLExecuteScalar(Strsql)
            ' If Curr_Table > 0 Then
            'If MsgBox("Zone นี้มีการตั้งค่าโต๊ะไว้อยู่แล้ว คุณต้องการยืนยันการปรับปรุงหรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการทำรายการ") = MsgBoxResult.No Then Exit Function
            If TotalTable < Curr_Table Then
                Strsql = "Delete from table_settings where table_zone = '" & Zone & "' and table_name > " & TotalTable
                _mysql.MySQLExecute(Strsql)
            Else
                Curr_Table = Curr_Table + 1

                For i = Curr_Table To TotalTable
                    Strsql = "Insert into  table_settings (table_zone,table_Name,table_displaytext,table_status) values "
                    Strsql = Strsql & "('" & Zone & "'," & i & ",'โต๊ะที่ " & i & "',1)"
                    _mysql.MySQLExecute(Strsql)

                Next
            End If


            MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Strsql = "Update zone_settings  set  zone_tables = " & TotalTable & " where  zone_name = '" & Zone & "'"
            _mysql.MySQLExecute(Strsql)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            Strsql = "Select * from table_settings where table_zone = '" & Zone & "' order by table_Name"
            DT_Table = _mysql.GetMYSQLDataTable(Strsql, "table_settings")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Sub Clear_AllTable(ByVal Zone As String)
        Try
            If MsgBox("คุณต้องการยืนยันการลบโต๊ะทั้งหมดหรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการทำรายการ") = MsgBoxResult.No Then Exit Sub
            Strsql = "Delete from table_settings where  table_zone = '" & Zone & "'"
            _mysql.MySQLExecute(Strsql)
            MsgBox("ลบข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Strsql = "Update zone_settings  set  zone_tables = 0 where  zone_name = '" & Zone & "'"
            _mysql.MySQLExecute(Strsql)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            Strsql = "Select * from table_settings where table_zone = '" & Zone & "' order by table_Name"
            DT_Table = _mysql.GetMYSQLDataTable(Strsql, "table_settings")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Delete_Table(ByVal Zone As String, ByVal Table_ID As Integer)
        If MsgBox("คุณต้องการยืนยันการลบโต๊ะหรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการทำรายการ") = MsgBoxResult.No Then Exit Sub
        Strsql = "Delete from table_settings where  table_zone = '" & Zone & "' and table_Name = " & Table_ID
        _mysql.MySQLExecute(Strsql)
        MsgBox("ลบข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information)
    End Sub
    Sub Update_Table(ByVal Zone As String, ByVal Table_ID As Integer, ByVal table_status As Integer, ByVal displaytext As String)
        Strsql = "Update  table_settings set table_displaytext = '" & displaytext & "',table_status = " & table_status & " where  table_zone = '" & Zone & "' and table_Name = " & Table_ID

        Select Case _mysql.MySQLExecute(Strsql)
            Case 0
                MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
            Case Is > 0

                For Each DRZone In DT_Table.Select("table_zone='" & Zone & "' and table_Name = '" & Table_ID & "'")
                    DRZone.BeginEdit()

                    DRZone("table_displaytext") = displaytext
                    DRZone("table_status") = table_status

                    DRZone.AcceptChanges()
                    Exit For
                Next
                MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")
            Case -1
                MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                With frmDebug

                    .lblFormName.Text = "ClsTable"
                    .lblFunctionName.Text = "Update_Table"
                    .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                    .MemoSQL.Text = Strsql
                    .ShowDialog()
                End With
        End Select

       
    End Sub
    Public Property EnableColor As Color
        Get
            For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=1")
                Enable_Color = Color.FromName(DRZoneStatus("table_status_color").ToString)
                Exit For
            Next

            Return Enable_Color
        End Get
        Set(ByVal value As Color)
            Try
                Strsql = "Update table_status  set table_status_color = '" & value.Name & "'  where table_status_id = 1"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0

                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=1")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = value.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassZone"
                            .lblFunctionName.Text = "EnableColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Set
    End Property
    Public Property DisableColor As Color
        Get
            For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=6")
                Disable_Color = Color.FromName(DRZoneStatus("table_status_color").ToString)
                Exit For
            Next
            Return Disable_Color
        End Get
        Set(ByVal value As Color)
            Try
                Strsql = "Update table_status  set table_status_color = '" & value.Name.ToString & "'  where table_status_id = 6"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=6")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = value.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassZone"
                            .lblFunctionName.Text = "DisableColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Set
    End Property
    Public Property BusyColor As Color
        Get
            For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=3")
                BusyColor = Color.FromName(DRZoneStatus("table_status_color").ToString)
                Exit For
            Next
            Return BusyColor
        End Get
        Set(ByVal value As Color)
            Try
                Strsql = "Update table_status set table_status_color = '" & value.Name.ToString & "'  where table_status_id = 3"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=3")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = value.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassTable"
                            .lblFunctionName.Text = "BusyColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Set
    End Property
    Public Property BookingColor As Color
        Get
            For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=2")
                BookingColor = Color.FromName(DRZoneStatus("table_status_color").ToString)
                Exit For
            Next
            Return BookingColor
        End Get
        Set(ByVal value As Color)
            Try
                Strsql = "Update table_status set table_status_color = '" & value.Name.ToString & "'  where table_status_id = 2"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=2")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = value.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassTable"
                            .lblFunctionName.Text = "BookingColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Set
    End Property
    Public Property WaitCheckBillColor As Color
        Get
            For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=4")
                WaitCheckBillColor = Color.FromName(DRZoneStatus("table_status_color").ToString)
                Exit For
            Next
            Return WaitCheckBillColor
        End Get
        Set(ByVal value As Color)
            Try
                Strsql = "Update table_status set table_status_color = '" & value.Name.ToString & "'  where table_status_id = 4"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=4")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = value.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassTable"
                            .lblFunctionName.Text = "WaitCheckOutColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Set
    End Property
    Public Property WaitFoodColor As Color
        Get
            For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=5")
                WaitFoodColor = Color.FromName(DRZoneStatus("table_status_color").ToString)
                Exit For
            Next
            Return WaitFoodColor
        End Get
        Set(ByVal value As Color)
            Try
                Strsql = "Update table_status set table_status_color = '" & value.Name.ToString & "'  where table_status_id = 5"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=5")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = value.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassTable"
                            .lblFunctionName.Text = "WaitCheckOutColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Set
    End Property
    Public ReadOnly Property GetDefaultEnableColor As Color
        Get
            Try
                Strsql = "Update table_status  set table_status_color = '" & Color.Chartreuse.Name.ToString & "'  where table_status_id = 1"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0

                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=1")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = Color.Chartreuse.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassZone"
                            .lblFunctionName.Text = "GetDefaultEnableColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return DefaultEnable_Color
        End Get
    End Property
    Public ReadOnly Property GetDefaultDisableColor As Color
        Get
            Try
                Strsql = "Update table_status  set table_status_color = '" & Color.Gainsboro.Name.ToString & "'  where table_status_id = 6"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0

                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=6")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = Color.Gainsboro.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassZone"
                            .lblFunctionName.Text = "GetDefaultDisableColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return DefaultDisable_Color
        End Get
    End Property
    Public ReadOnly Property GetDefaultBookingColor As Color
        Get
            Try
                Strsql = "Update table_status  set table_status_color = '" & Color.Khaki.Name.ToString & "'  where table_status_id = 2"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0

                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=2")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = Color.Khaki.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassTable"
                            .lblFunctionName.Text = "GetDefaultBookingColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return DefaultBooking_Color
        End Get
    End Property
    Public ReadOnly Property GetDefaultBusyColor As Color
        Get
            Try
                Strsql = "Update table_status  set table_status_color = '" & Color.Red.Name.ToString & "'  where table_status_id = 3"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0

                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=3")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = Color.Red.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassTable"
                            .lblFunctionName.Text = "GetDefaultBusyColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return DefaultBusy_Color
        End Get
    End Property
    Public ReadOnly Property GetDefaultWaitCheckBillColor As Color
        Get
            Try
                Strsql = "Update table_status  set table_status_color = '" & Color.DarkOrange.Name.ToString & "'  where table_status_id = 4"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0

                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=4")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = Color.DarkOrange.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassTable"
                            .lblFunctionName.Text = "GetDefaultWaitCheckOutColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return DefaultWaitCheckBill_Color
        End Get
    End Property
    Public ReadOnly Property GetDefaultWaitFoodColor As Color
        Get
            Try
                Strsql = "Update table_status  set table_status_color = '" & Color.Yellow.Name.ToString & "'  where table_status_id = 5"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0

                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        For Each DRZoneStatus In DT_TableStatus.Select("table_status_id=5")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("table_status_color") = Color.Yellow.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassTable"
                            .lblFunctionName.Text = "GetDefaultWaitFoodColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return DefaultWaitFood_Color
        End Get
    End Property
    Public Sub New()
        Strsql = "Select table_status_id,table_status_name,table_status_color from table_status"
        DT_TableStatus = _mysql.GetMYSQLDataTable(Strsql, "table_status")
    End Sub
    Public Function Get_Color_Status(ByVal Status_ID As Integer) As String
        Try
            Strsql = "Select table_status_color from  table_status where table_status_id = " & Status_ID
            Get_Color_Status = _mysql.MySQLExecuteScalar(Strsql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
End Class
