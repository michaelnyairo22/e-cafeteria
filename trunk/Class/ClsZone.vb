
Public Class ClsZone
    Dim DT_Zone As New DataTable
    Dim DT_ZoneStatus As New DataTable
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Dim DRZone As DataRow
    Dim DRZoneStatus As DataRow
    Dim Enable_Color As Color
    Dim Disable_Color As Color
    Dim Full_Color As Color
    Dim DefaultEnable_Color As Color = Color.Chartreuse
    Dim DefaultDisable_Color As Color = Color.Gainsboro
    Dim DefaultFull_Color As Color = Color.Red
    Dim ZoneTable As Integer = 0
    Public Sub New()
        Try
            Strsql = "Select zone_name,zone_displaytext,zone_status,zone_tables from zone_settings order by zone_name"
            DT_Zone = _mysql.GetMYSQLDataTable(Strsql, "zone_settings")
            Strsql = "Select zone_status_id,zone_status_name,zone_status_color from zone_status"
            DT_ZoneStatus = _mysql.GetMYSQLDataTable(Strsql, "zone_status")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public ReadOnly Property Get_ZoneTable(ByVal Zone As String) As Integer
        Get
            For Each DRZone In DT_Zone.Select("zone_name='" & Zone & "'")

                'DRZone("zone_name").ToString()
                'DRZone("zone_displaytext").ToString()
                'DRZone("zone_status").ToString()
                ZoneTable = DRZone("zone_tables").ToString()
                Exit For
            Next
            Return ZoneTable
        End Get
    End Property


    Public ReadOnly Property Load_Detail As DataTable
        Get
            Return DT_Zone
        End Get
    End Property
    Public ReadOnly Property Get_DataRow(ByVal Zone As String) As DataRow
        Get
            Try

                For Each DRZone In DT_Zone.Select("zone_name='" & Zone & "'")
                    'DRZone("zone_name").ToString()
                    'DRZone("zone_displaytext").ToString()
                    'DRZone("zone_status").ToString()
                    'DRZone("zone_tables").ToString()
                    Exit For
                Next
                Return DRZone
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Get
    End Property
    Public ReadOnly Property Get_Datatable As DataTable
        Get
            Return DT_Zone
        End Get
    End Property
    Sub Update_ZoneSetting(ByVal Zone As String, ByVal StrDisplay As String, ByVal IntTstatus As Int32, ByVal IntTables As Int32)
        Try
            Strsql = "Update zone_settings set zone_displaytext =  '" & StrDisplay & "' ,zone_status= " & IntTstatus + 2 & ",zone_tables= " & IntTables & " where zone_name = '" & Zone & "'"
            Select Case _mysql.MySQLExecute(Strsql)
                Case 0
                    MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                Case Is > 0

                    For Each DRZone In DT_Zone.Select("zone_name='" & Zone & "'")
                        DRZone.BeginEdit()

                        DRZone("zone_displaytext") = StrDisplay
                        DRZone("zone_status") = IntTstatus + 2
                        DRZone("zone_tables") = IntTables
                        DRZone.AcceptChanges()
                        Exit For
                    Next
                    MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")
                Case -1
                    MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                    With frmDebug

                        .lblFormName.Text = "ClassZone"
                        .lblFunctionName.Text = "Update_ZoneSetting"
                        .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Property EnableColor As Color
        Get
            For Each DRZoneStatus In DT_ZoneStatus.Select("zone_status_id=1")
                Enable_Color = Color.FromName(DRZoneStatus("zone_status_color").ToString)
                Exit For
            Next

            Return Enable_Color
        End Get
        Set(ByVal value As Color)
            Try
                Strsql = "Update zone_status  set zone_status_color = '" & value.Name & "'  where zone_status_id = 1"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0

                        For Each DRZoneStatus In DT_ZoneStatus.Select("zone_status_id=1")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("zone_status_color") = value.Name.ToString
                           
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
            For Each DRZoneStatus In DT_ZoneStatus.Select("zone_status_id=2")
                Disable_Color = Color.FromName(DRZoneStatus("zone_status_color").ToString)
                Exit For
            Next
            Return Disable_Color
        End Get
        Set(ByVal value As Color)
            Try
                Strsql = "Update zone_status  set zone_status_color = '" & value.Name.ToString & "'  where zone_status_id = 2"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        For Each DRZoneStatus In DT_ZoneStatus.Select("zone_status_id=2")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("zone_status_color") = value.Name.ToString

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
    Public Property FullColor As Color
        Get
            For Each DRZoneStatus In DT_ZoneStatus.Select("zone_status_id=3")
                FullColor = Color.FromName(DRZoneStatus("zone_status_color").ToString)
                Exit For
            Next
            Return FullColor
        End Get
        Set(ByVal value As Color)
            Try
                Strsql = "Update zone_status  set zone_status_color = '" & value.Name.ToString & "'  where zone_status_id = 3"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0
                        For Each DRZoneStatus In DT_ZoneStatus.Select("zone_status_id=3")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("zone_status_color") = value.Name.ToString

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
                            .lblFunctionName.Text = "FullColor"
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
                Strsql = "Update zone_status  set zone_status_color = '" & Color.Chartreuse.Name.ToString & "'  where zone_status_id = 1"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0

                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        For Each DRZoneStatus In DT_ZoneStatus.Select("zone_status_id=1")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("zone_status_color") = Color.Chartreuse.Name.ToString

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
                Strsql = "Update zone_status  set zone_status_color = '" & Color.Gainsboro.Name.ToString & "'  where zone_status_id = 2"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0

                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        For Each DRZoneStatus In DT_ZoneStatus.Select("zone_status_id=2")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("zone_status_color") = Color.Gainsboro.Name.ToString

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
    Public ReadOnly Property GetDefaultFullColor As Color
        Get
            Try
                Strsql = "Update zone_status  set zone_status_color = '" & Color.Red.Name.ToString & "'  where zone_status_id = 3"
                Select Case _mysql.MySQLExecute(Strsql)
                    Case 0

                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                    Case Is > 0
                        For Each DRZoneStatus In DT_ZoneStatus.Select("zone_status_id=3")
                            DRZoneStatus.BeginEdit()

                            DRZoneStatus("zone_status_color") = Color.Gainsboro.Name.ToString

                            DRZoneStatus.AcceptChanges()
                            Exit For
                        Next
                        MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")

                    Case -1
                        MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                        With frmDebug

                            .lblFormName.Text = "ClassZone"
                            .lblFunctionName.Text = "GetDefaultFullColor"
                            .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                            .MemoSQL.Text = Strsql
                            .ShowDialog()
                        End With
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return DefaultFull_Color
        End Get
    End Property

End Class
