Public Class ClsMenu
    Dim DT_Menu As New DataTable
    Dim DR_Menu As DataRow
    Dim DT_Menu_Group As New DataTable
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper

    Public ReadOnly Property Get_DataTable As DataTable
        Get
            Return DT_Menu
        End Get
    End Property
    Public ReadOnly Property Get_GroupDataTable As DataTable
        Get
            Return DT_Menu_Group
        End Get
    End Property
    Public ReadOnly Property Get_DataRow(ByVal menu_id As String) As DataRow
        Get

            Try
                For Each DR_Menu In DT_Menu.Select("menu_id='" & menu_id & "'")
                    'DRZone("zone_name").ToString()
                    'DRZone("zone_displaytext").ToString()
                    'DRZone("zone_status").ToString()
                    'DRZone("zone_tables").ToString()
                    Exit For
                Next
                Return DR_Menu
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Get
    End Property
    Function Insert_Data(ByVal menu_id As String, ByVal MenuName As String, ByVal MenuPrice As Integer, ByVal menu_discount As Integer, ByVal menu_committion As Integer, ByVal menu_group As Integer, ByVal menu_favoriate As String, ByVal Imgpart As String, ByVal AutoMenu As String)
        Try
            Strsql = "Insert into menu (menu_id,menu_name,menu_price,menu_discount,menu_committion,menu_group,menu_favoriate,menu_image,menu_auto) values "
            Strsql = Strsql & "('" & menu_id & "','" & MenuName & "'," & MenuPrice & "," & menu_discount & "," & menu_committion & "," & menu_group & ",'" & menu_favoriate & "'"
            If Imgpart = "" Then
                Strsql = Strsql & ",''"
            Else
                Strsql = Strsql & ",'" & Replace(Imgpart, "\", "\\") & "'"
            End If
            Strsql = Strsql & ",'" & AutoMenu & "')"


            Select Case _mysql.MySQLExecute(Strsql)
                Case 0
                    MsgBox("ขอภัยไม่สามารถเพิ่มได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการเพิ่มเนู")
                Case Is > 0
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการเพิ่มพนักงาน")
                Case -1
                    With frmDebug

                        .lblFormName.Text = "ClsMenu"
                        .lblFunctionName.Text = "Insert_Data"
                        .MemoErr_Description.Text = "ขอภัยไม่สามารถเพิ่มได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์ กรุณาตรวจสอบคำสั่ง SQL"
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Function Update_Menu(ByVal MenuName As String, ByVal MenuPrice As Integer, ByVal menu_discount As Integer, ByVal menu_committion As Integer, ByVal menu_group As Integer, ByVal menu_favoriate As String, ByVal Imgpart As String, ByVal menu_id As Integer, ByVal AutoMenu As String)
        Try
            Strsql = "Update menu set menu_name = '" & MenuName & "',menu_price=" & MenuPrice & ",menu_discount=" & menu_discount & ",menu_committion=" & menu_committion & ",menu_group=" & menu_group & ",menu_image='" & Replace(Imgpart, "\", "\\") & "',menu_favoriate='" & menu_favoriate & "' ,menu_auto = '" & AutoMenu & "'"
            Strsql = Strsql & " where menu_id = " & menu_id


            Select Case _mysql.MySQLExecute(Strsql)
                Case 0

                    MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                Case Is > 0
                    MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")
                Case -1
                    MsgBox("ขอภัยไม่สามารถปรับปรุงได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์", MsgBoxStyle.Critical, "ผลการปรับปรุง")
                    With frmDebug

                        .lblFormName.Text = "ClsMenu"
                        .lblFunctionName.Text = "Update_Menu"
                        .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
            End Select
            DR_Menu.AcceptChanges()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Function Delete_Menu(ByVal menu_id As Integer)
        Try
            Strsql = "Delete from menu where menu_id = " & menu_id
            Select Case _mysql.MySQLExecute(Strsql)
                Case 0

                    MsgBox("ขอภัยไม่สามารถลบได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการลบ")
                Case Is > 0
                    MsgBox("ลบข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการลบ")
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub New()
        Strsql = "Select * from menu"
        DT_Menu = _mysql.GetMYSQLDataTable(Strsql, "menu")
        Strsql = "select * from menugroup"
        DT_Menu_Group = _mysql.GetMYSQLDataTable(Strsql, "menugroup")
    End Sub
End Class
