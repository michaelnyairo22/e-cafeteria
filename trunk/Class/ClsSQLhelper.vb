Imports System
Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports Crypto
Imports System.Xml
Public Class ClsSQLhelper
    Public Shared Sub UpdateAppSettings(ByVal KeyName As String, ByVal KeyValue As String)
        Dim XmlDoc As New XmlDocument()
        'XmlDoc.Load(Application.StartupPath & "/HRManager.exe.config")
        XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        For Each xElement As XmlElement In XmlDoc.DocumentElement
            If xElement.Name = "appSettings" Then
                For Each xNode As XmlNode In xElement.ChildNodes
                    If xNode.Attributes(0).Value = KeyName Then
                        xNode.Attributes(1).Value = KeyValue
                    End If
                Next
            End If
        Next
        XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        'XmlDoc.Save(Application.StartupPath & "/HRManager.exe.config")
    End Sub
#Region "MySQL"
#Region "MySQl Config"
    Public Shared Property MySQLUser() As String
        Get
            MySQLUser = System.Configuration.ConfigurationSettings.AppSettings.Get("MyUser")
        End Get
        Set(ByVal value As String)
            UpdateAppSettings("MyUser", value)
        End Set
    End Property
    Public Shared Property MySQLPassword() As String
        Get
            MySQLPassword = System.Configuration.ConfigurationSettings.AppSettings.Get("MyPassword")

        End Get
        Set(ByVal value As String)
            UpdateAppSettings("MyPassword", value)
        End Set
    End Property
    Public Shared Property MySQLPort() As Int32
        Get
            MySQLPort = System.Configuration.ConfigurationSettings.AppSettings.Get("MyPort")
        End Get
        Set(ByVal value As Int32)
            UpdateAppSettings("MyPort", value)
        End Set
    End Property
    Public Shared Property MySQLDatabase() As String
        Get
            MySQLDatabase = System.Configuration.ConfigurationSettings.AppSettings.Get("MyDatabase")
        End Get
        Set(ByVal value As String)
            UpdateAppSettings("MyDatabase", value)
        End Set
    End Property
    Public Shared Property MySQLServer() As String
        Get
            MySQLServer = System.Configuration.ConfigurationSettings.AppSettings.Get("MyServer")
        End Get
        Set(ByVal value As String)
            UpdateAppSettings("MyServer", value)
        End Set
    End Property
#End Region
    Public Shared Function MySQLConnectionStr() As String
        Dim Crypto As New Crypto.Crypto
        Try
            MySQLConnectionStr = "server=" & MySQLServer & ";user=" & MySQLUser & ";database=" & MySQLDatabase & ";port=" & MySQLPort & ";password=" & Crypto.Decrypt(MySQLPassword, "sys11266") & ";"
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Shared ReadOnly Property ConnMysql() As String
        Get
            ConnMysql = MySQLConnectionStr()
        End Get
    End Property

    Function GetMYSQLDataset(ByVal Strsql As String, _
           Optional ByVal DatasetName As String = "Dataset1", _
           Optional ByVal TableName As String = "Table") As DataSet
        Dim MyConnq As New MySqlConnection
        MyConnq.ConnectionString = ConnMysql
        Dim DA As New MySqlDataAdapter(Strsql, MyConnq)
        Dim DS As New DataSet(DatasetName)
        Try
            DA.Fill(DS, TableName)
        Catch x1 As Exception
            Err.Raise(60002, , x1.Message)
            MsgBox(x1.Message.ToString)
        End Try
        Return DS
    End Function
    Function GetMYSQLDataset(ByVal Strsql As String, ByVal DatasetName As DataSet, _
          Optional ByVal TableName As String = "Table") As DataSet
        Dim MyConnq As New MySqlConnection
        MyConnq.ConnectionString = ConnMysql
        Dim DA As New MySqlDataAdapter(Strsql, MyConnq)
        Try
            System.Diagnostics.EventLog.WriteEntry(Application.ProductName, Strsql, EventLogEntryType.Information)
            DA.Fill(DatasetName, TableName)
        Catch x1 As Exception
            Err.Raise(60002, , x1.Message)
            MsgBox(x1.Message.ToString)
        End Try
        Return DatasetName
    End Function
    Sub FillDataset(ByVal Strsql As String, ByVal DatasetName As DataSet, ByVal TableName As String)
        Dim MyConnq As New MySqlConnection
        MyConnq.ConnectionString = ConnMysql
        Dim DA As New MySqlDataAdapter(Strsql, MyConnq)
        Try
            System.Diagnostics.EventLog.WriteEntry(Application.ProductName, Strsql, EventLogEntryType.Information)
            DA.Fill(DatasetName, TableName)
        Catch x1 As Exception
            Err.Raise(60002, , x1.Message)
            MsgBox(x1.Message.ToString)
        End Try
    End Sub


    Function GetMYSQLDataTable(ByVal Strsql As String, _
    Optional ByVal TableName As String = "Table") As DataTable
        Dim MyConnq As New MySqlConnection
        MyConnq.ConnectionString = ConnMysql
        Dim DA As New MySqlDataAdapter(Strsql, MyConnq)
        Dim DT As New DataTable(TableName)
        Try

            DA.Fill(DT)
        Catch x1 As Exception
            Err.Raise(60002, , x1.Message)
            MsgBox(x1.Message.ToString, MsgBoxStyle.Critical, "SQL Exception")
        End Try
        Return DT
    End Function

    Function MySQLExecute(ByRef CmdStr As String, ByVal Conn As MySqlConnection) As Integer
        Dim Cmd As New MySqlCommand
        Cmd.CommandText = CmdStr
        Cmd.Connection = Conn
        Dim X As Integer
        Try
            Conn.Open()
            X = Cmd.ExecuteNonQuery()
        Catch
            X = -1
        Finally
            Conn.Close()
        End Try
        Return X
    End Function
    Function MySQLExecute(ByRef CmdStr As String) As Integer
        Dim MyConnq As New MySqlConnection
        MyConnq.ConnectionString = ConnMysql
        Dim Cmd As New MySqlCommand
        Cmd.CommandText = CmdStr
        Cmd.Connection = MyConnq
        Dim X As Integer
        Try
            MyConnq.Open()
            X = Cmd.ExecuteNonQuery()
        Catch
            X = -1
        Finally
            MyConnq.Close()
        End Try
        Return X
    End Function

    Function MySQLExecuteScalar(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As MySqlParameter()) As Object
        Dim cmd As MySqlCommand = New MySqlCommand
        Dim conn As MySqlConnection = New MySqlConnection(connString)
        Try
            MySQLPrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim val As Object = cmd.ExecuteScalar()

            cmd.Parameters.Clear()

            Return val
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateScalar", exx)
        Finally
            conn.Close()
            conn = Nothing
            cmd = Nothing
        End Try
    End Function
    Function MySQLExecuteScalar(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As MySqlParameter()) As Object
        Dim MyConnq As New MySqlConnection
        MyConnq.ConnectionString = ConnMysql
        Dim cmd As MySqlCommand = New MySqlCommand
        Try
            MySQLPrepareCommand(cmd, MyConnq, cmdType, cmdText, cmdParms)
            Dim val As Object = cmd.ExecuteScalar()
            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateScalar", exx)
        Finally
            cmd.Connection.Close()
            cmd = Nothing
        End Try
    End Function
    Function MySQLExecuteScalar(ByVal cmdText As String) As Object
        Dim MyConnq As New MySqlConnection
        Dim FlgConError As Boolean = False
        MyConnq.ConnectionString = ConnMysql
        Dim cmd As MySqlCommand = New MySqlCommand
        Try
            If Not MyConnq.State = ConnectionState.Open Then
                'MsgBox("Connection open")
                MyConnq.Open()
            End If
            cmd.Connection = MyConnq
            cmd.CommandText = cmdText
            Dim val As Object = cmd.ExecuteScalar()
            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception

            If exx.Message = "Unable to connect to any of the specified MySQL hosts." Then
                frmDatabaseConnError.ShowDialog()
                FlgConError = True
                frmDBSetting.ShowDialog()
                Exit Try


            Else
                MsgBox(exx.Message)
            End If

            Throw New Exception("ExeculateScalar", exx)
        Finally
            If FlgConError = False Then
                cmd.Connection.Close()
                cmd = Nothing
            End If

        End Try
    End Function

    Public Function MySQLPrepareCommand(ByRef cmd As MySqlCommand, ByRef conn As MySqlConnection, ByRef cmdType As CommandType, ByRef cmdText As String, ByRef cmdParms As MySqlParameter()) As Boolean
        If Not conn.State = ConnectionState.Open Then
            'MsgBox("Connection open")
            conn.Open()
        End If
        Try
            cmd.Connection = conn
            cmd.CommandText = cmdText
            cmd.Parameters.Clear()
            '  cmd.ParameterCheck = True
            cmd.CommandType = cmdType
            If Not (IsNothing(cmdParms)) Then
                Dim parm As MySqlParameter
                For Each parm In cmdParms
                    cmd.Parameters.Add(parm)
                Next
            End If
        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("PrepareCommand : ", exx)
        End Try
    End Function
    Public Sub MYSQLCreateParam(ByRef Cmd As MySqlCommand, ByVal StrType As String)
        'T:Text, M:Memo, Y:Currency, D:Datetime, I:Integer, S:Single, B:Boolean, P: Picture
        Dim i As Integer
        Dim j As String
        For i = 1 To Len(StrType)
            j = UCase(Mid(StrType, i, 1))
            Dim P1 As New MySqlParameter
            P1.ParameterName = "@P" & i
            Select Case j
                Case "T"
                    P1.MySqlDbType = MySqlDbType.VarChar
                Case "M"
                    P1.MySqlDbType = MySqlDbType.Text
                Case "Y"
                    P1.MySqlDbType = MySqlDbType.Decimal
                Case "D"
                    P1.MySqlDbType = MySqlDbType.DateTime
                Case "I"
                    P1.MySqlDbType = MySqlDbType.Int64
                Case "S"
                    P1.MySqlDbType = MySqlDbType.Decimal
                Case "B"
                    P1.MySqlDbType = MySqlDbType.Bit
                Case "P"
                    P1.MySqlDbType = MySqlDbType.Binary
            End Select
            Cmd.Parameters.Add(P1)
        Next
    End Sub
    Public Function MYSQLCreateCommand(ByVal Strsql As String) As MySqlCommand
        Dim cmd As New MySqlCommand(Strsql)
        Return cmd
    End Function
    Public Shared Function MYSQLExecQuery(ByVal ProcedureName As String, ByVal Parms As MySqlParameter(), ByVal sqlconn As MySqlConnection, Optional ByVal DatasetName As String = "Dataset1") As DataSet
        Dim dsDataSet As New DataSet(DatasetName)
        ' Configure the MySqlCommand object
        Dim _cmdSqlCommand As MySqlCommand = New MySqlCommand()

        With _cmdSqlCommand
            .CommandType = CommandType.StoredProcedure      'Set type to StoredProcedure
            .CommandText = ProcedureName                    'Specify stored procedure to run
            .Connection = sqlconn

            ' Clear any previous parameters from the Command object
            Call .Parameters.Clear()

            ' Loop through parmameter collection adding parameters to the command object
            If Not (Parms Is Nothing) Then
                For Each sqlParm As MySqlParameter In Parms
                    _cmdSqlCommand.Parameters.Add(sqlParm)
                Next
            End If
        End With

        Dim _adpAdapter As MySqlDataAdapter = New MySqlDataAdapter()
        ' Configure Adapter to use newly created command object and fill the dataset.
        _adpAdapter.SelectCommand = _cmdSqlCommand
        _adpAdapter.Fill(dsDataSet)

        Return dsDataSet
    End Function
#End Region
#Region "MSSQL"
    Public Function GetMSSQLDataset(ByVal Strsql As String, ByVal sqlconn As SqlConnection, _
           Optional ByVal DatasetName As String = "Dataset1", _
           Optional ByVal TableName As String = "Table") As DataSet
        Dim DA As New SqlDataAdapter(Strsql, sqlconn)
        Dim DS As New DataSet(DatasetName)
        Try
            DA.Fill(DS, TableName)
        Catch x1 As Exception
            Err.Raise(60002, , x1.Message)
        End Try
        Return DS
    End Function
    Public Function GetMSSQLDataTable(ByVal Strsql As String, ByVal sqlconn As SqlConnection, _
        Optional ByVal TableName As String = "Table") As DataTable
        Dim DA As New SqlDataAdapter(Strsql, sqlconn)
        Dim DT As New DataTable(TableName)
        Try
            DA.Fill(DT)
        Catch x1 As Exception
            Err.Raise(60002, , x1.Message)
        End Try
        Return DT
    End Function
    Public Function CreateCommand(ByVal Strsql As String) As SqlCommand
        Dim cmd As New SqlCommand(Strsql)
        Return cmd
    End Function
    Public Function Execute(ByVal Strsql As String) As Integer
        Dim cmd As New SqlCommand(Strsql)
        Dim X As Integer = Me.Execute(Strsql)
        Return X
    End Function
    Public Function Execute(ByRef Cmd As SqlCommand, ByVal sqlconn As SqlConnection) As Integer
        Cmd.Connection = sqlconn
        Dim X As Integer
        Try
            sqlconn.Open()
            X = Cmd.ExecuteNonQuery()
        Catch
            X = -1
        Finally
            sqlconn.Close()
        End Try
        Return X
    End Function
    Public Sub CreateParam(ByRef Cmd As SqlCommand, ByVal StrType As String)
        'T:Text, M:Memo, Y:Currency, D:Datetime, I:Integer, S:Single, B:Boolean, P: Picture
        Dim i As Integer
        Dim j As String
        For i = 1 To Len(StrType)
            j = UCase(Mid(StrType, i, 1))
            Dim P1 As New SqlParameter
            P1.ParameterName = "@P" & i
            Select Case j
                Case "T"
                    P1.SqlDbType = SqlDbType.VarChar
                Case "M"
                    P1.SqlDbType = SqlDbType.Text
                Case "Y"
                    P1.SqlDbType = SqlDbType.Money
                Case "D"
                    P1.SqlDbType = SqlDbType.DateTime
                Case "I"
                    P1.SqlDbType = SqlDbType.Int
                Case "S"
                    P1.SqlDbType = SqlDbType.Decimal
                Case "B"
                    P1.SqlDbType = SqlDbType.Bit
                Case "P"
                    P1.SqlDbType = SqlDbType.Image
            End Select
            Cmd.Parameters.Add(P1)
        Next
    End Sub
    Public Function ExecQuery(ByVal ProcedureName As String, ByVal Parms As SqlParameter(), ByVal sqlconn As SqlConnection, Optional ByVal DatasetName As String = "Dataset1") As DataSet
        '****************************************************************************************
        ' ExecQuery
        ' ABSTRACT: Executes a stored procedure against the Eisemann database and returns
        '   a NEW Dataset with the selected data.
        '
        ' INPUT PARMS:  ProcedureName   Name of Stored Procedure to execute
        '               Parms           Array of SqlParameter objects that will be passed into the
        '                               stored procedure.
        '
        ' RETURNS:      DataSet populated with results from stored procedure execution.
        '
        '****************************************************************************************
        Dim dsDataSet As New DataSet(DatasetName)
        ' Configure the SqlCommand object
        Dim _cmdSqlCommand As SqlCommand = New SqlCommand()

        With _cmdSqlCommand
            .CommandType = CommandType.StoredProcedure      'Set type to StoredProcedure
            .CommandText = ProcedureName                    'Specify stored procedure to run
            .Connection = sqlconn

            ' Clear any previous parameters from the Command object
            Call .Parameters.Clear()

            ' Loop through parmameter collection adding parameters to the command object
            If Not (Parms Is Nothing) Then
                For Each sqlParm As SqlParameter In Parms
                    _cmdSqlCommand.Parameters.Add(sqlParm)
                Next
            End If
        End With

        Dim _adpAdapter As SqlDataAdapter = New SqlDataAdapter()
        ' Configure Adapter to use newly created command object and fill the dataset.
        _adpAdapter.SelectCommand = _cmdSqlCommand
        _adpAdapter.Fill(dsDataSet)

        Return dsDataSet
    End Function
#End Region
End Class
