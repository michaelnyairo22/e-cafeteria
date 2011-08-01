
Public Class ClsEmployee
    Dim DT_Employee As New DataTable
    Dim DR_Employee As DataRow
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Dim DT_Title As New DataTable

   
    Public ReadOnly Property Get_DataTable As DataTable
        Get
         
            Return DT_Employee
        End Get
    End Property
    Public ReadOnly Property Get_DataRow(ByVal Emp_ID As Integer) As DataRow
        Get

            Try
                For Each DR_Employee In DT_Employee.Select("emp_id=" & Emp_ID)
                    'DRZone("zone_name").ToString()
                    'DRZone("zone_displaytext").ToString()
                    'DRZone("zone_status").ToString()
                    'DRZone("zone_tables").ToString()
                    Exit For
                Next
                Return DR_Employee
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Get
    End Property
    ReadOnly Property Get_Title_Table As DataTable
        Get
           
            Return DT_Title
        End Get
    End Property
    Function Insert_Data(ByVal Title As String, ByVal fname As String, ByVal lname As String, ByVal sex As Integer, ByVal birthday As DateTime, ByVal hiredate As DateTime, ByVal Emp_Position As String, ByVal Emp_Satatus As Integer, ByVal Imgpart As String, ByVal nickname As String, ByVal EmpPosition As String)
        Try
            Strsql = "Insert into employee (emp_title,emp_firstname,emp_lname,emp_sex,emp_status,nickname,emp_birthday,emp_hiredate,emp_image,emp_position) values "
            Strsql = Strsql & "('" & Title & "','" & fname & "','" & lname & "'," & sex & "," & Emp_Satatus & ",'" & nickname & "','" & Pn_Framework.MysqlDateTimeFormat(birthday, False) & "','" & Pn_Framework.MysqlDateTimeFormat(hiredate, False) & "'"
            If Imgpart = "" Then
                Strsql = Strsql & ",''"
            Else
                Strsql = Strsql & ",'" & Replace(Imgpart, "\", "\\") & "'"
            End If
            Strsql = Strsql & ",'" & EmpPosition & "' )"


            Select Case _mysql.MySQLExecute(Strsql)
                Case 0
                    MsgBox("ขอภัยไม่สามารถเพิ่มได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการเพิ่มพนักงาน")
                Case Is > 0
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการเพิ่มพนักงาน")
                Case -1
                    MsgBox("ขอภัยไม่สามารถเพิ่มได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการเพิ่มพนักงาน")
                    With frmDebug

                        .lblFormName.Text = "ClsEmployee"
                        .lblFunctionName.Text = "Insert_Data"
                        .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Function Update_Employee(ByVal emp_id As Integer, ByVal Title As String, ByVal fname As String, ByVal lname As String, ByVal sex As Integer, ByVal birthday As DateTime, ByVal hiredate As DateTime, ByVal Emp_Position As String, ByVal Emp_Satatus As Integer, ByVal Imgpart As String, ByVal nickname As String, ByVal EmpPosition As String)
        Try
            Strsql = "Update employee set emp_title = '" & Title & "',emp_firstname='" & fname & "',emp_lname='" & lname & "',emp_sex=" & sex & ",emp_status=" & Emp_Satatus & ",emp_image='" & Replace(Imgpart, "\", "\\") & "',emp_birthday='" & Pn_Framework.MysqlDateTimeFormat(birthday, False) & "',emp_hiredate='" & Pn_Framework.MysqlDateTimeFormat(hiredate, False) & "'"
            Strsql = Strsql & ",emp_position = '" & EmpPosition & "',nickname = '" & nickname & "'"
            Strsql = Strsql & " where emp_id = " & emp_id


            Select Case _mysql.MySQLExecute(Strsql)
                Case 0

                    MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                Case Is > 0
                    MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")
                Case -1
                    MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                    With frmDebug

                        .lblFormName.Text = "ClsEmployee"
                        .lblFunctionName.Text = "Update_Employee"
                        .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
            End Select
            DR_Employee.AcceptChanges()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Function Delete_Employee(ByVal Emp_id As Integer)
        Try
            Strsql = "Delete from employee where emp_id = " & Emp_id
            Select Case _mysql.MySQLExecute(Strsql)
                Case 0

                    MsgBox("ขอภัยไม่สามารถลบได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการลบ")
                Case Is > 0
                    MsgBox("ลบข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการลบ")
                Case -1
                    MsgBox("ขอภัยไม่สามารถลบได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการลบ")
                    With frmDebug

                        .lblFormName.Text = "ClsEmployee"
                        .lblFunctionName.Text = "Delete_Employee"
                        .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub New()
        Strsql = "Select * from employee"
        DT_Employee = _mysql.GetMYSQLDataTable(Strsql, "employee")
        Strsql = "select * from pname"
        DT_Title = _mysql.GetMYSQLDataTable(Strsql, "pname")
    End Sub
End Class
