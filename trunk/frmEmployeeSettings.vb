Imports DevExpress.XtraGrid.Views.Grid
Public Class frmEmployeeSettings
    Dim Primary_Key As Integer
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
#Region "Function"
    Sub Load_Data()

        Strsql = "select * from employee left join sex on employee.emp_sex= sex.sex_id left join emp_status on employee.emp_status= emp_status.emp_status_id"

        If Me.TxtSearch.Text <> "" Then
            Select Case RadioGroup1.EditValue
                Case 0
                    Strsql = Strsql & " where emp_id = " & Me.TxtSearch.Text
                Case 1
                    Strsql = Strsql & " where emp_firstname like '" & Me.TxtSearch.Text & "%'"
            End Select
        End If

        Dim DT_Emp As New DataTable
        DT_Emp = _mysql.GetMYSQLDataTable(Strsql, "employee")
        GridControl1.DataSource = DT_Emp
    End Sub
#End Region
    Private Sub BtnNewEmployee_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnNewEmployee.ItemClick
        If frmNewEmp.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Load_Data()
        End If
    End Sub

    Private Sub GridMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridView1_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEditForEditing
        Dim Gv As GridView = sender
        Primary_Key = Gv.GetRowCellValue(e.RowHandle, Gv.Columns("emp_id"))
    End Sub

    Private Sub frmEmployeeSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
    End Sub



    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Me.TxtSearch.Text = ""
        Load_Data()
    End Sub


    Private Sub BtnEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnEdit.ItemClick
        Try
            Strsql = "select readonly from employee where emp_id = " & Primary_Key
            If _mysql.MySQLExecuteScalar(Strsql) = 1 Then
                MsgBox("ไม่สามารถลบรายการที่เป็นของระบบได้", MsgBoxStyle.Exclamation, "ขออภัยไม่สามารถทำรายการได้")
                Exit Sub
            End If

            frmEditEmp.primary_key = Primary_Key
            If frmEditEmp.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Load_Data()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Load_Data()
    End Sub

    Private Sub BtnDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnDelete.ItemClick
        If MsgBox("คุณต้องการยืนยันการลบใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการลบ") = MsgBoxResult.No Then Exit Sub
        Dim MyEmp As New ClsEmployee
        MyEmp.Delete_Employee(Primary_Key)
        Load_Data()
    End Sub
End Class