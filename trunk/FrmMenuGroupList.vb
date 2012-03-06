Imports DevExpress.XtraGrid.Views.Grid
Public Class FrmMenuGroupList
    Dim Strsql As String
    Dim _Mysql As New ClsSQLhelper
    Dim Primary_Key As Integer
    Sub Load_data()
        Try
            Strsql = "Select * from menugroup"

            Me.GridColumn1.FieldName = "group_id"
            Me.GridColumn1.Caption = "รหัส"
            Me.GridColumn1.OptionsColumn.ReadOnly = True

            Me.GridColumn2.FieldName = "group_name"
            Me.GridColumn2.Caption = "ชื่อกลุ่ม"
            Me.GridColumn2.OptionsColumn.ReadOnly = True


            Dim DT As New DataTable
            DT = _Mysql.GetMYSQLDataTable(Strsql, "menugroup")
            GridMenu.DataSource = DT
        Catch ex As Exception
            With frmDebug

                .lblFormName.Text = "FrmMenuGroupList"
                .lblFunctionName.Text = "Load_data"
                .MemoErr_Description.Text = "กรุณาตรวจสอบคำสั่ง SQL"
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try
    End Sub
    Private Sub BtnClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnClose.ItemClick
        Me.Dispose()

    End Sub

    Private Sub FrmMenuGroupList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Load_data()
    End Sub

    Private Sub GridView1_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEditForEditing
        Dim Gv As GridView = sender
        Primary_Key = Gv.GetRowCellValue(e.RowHandle, Gv.Columns("group_id"))
    End Sub

    Private Sub BtnAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnAdd.ItemClick
        If DlgAddNewGroup.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Load_data()

        End If

    End Sub

    Private Sub BtnEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnEdit.ItemClick
        DlgEditGroup.Primarykey = Primary_Key
        If DlgEditGroup.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Load_data()

        End If

    End Sub

    Private Sub BtnDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnDelete.ItemClick
        If MsgBox("คุณต้องการยืนยันการลบใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการลบ") = MsgBoxResult.No Then Exit Sub

        Try
            Strsql = "Delete from menugroup where group_id = '" & Primary_Key & "'"
            Select Case _Mysql.MySQLExecute(Strsql)
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
        Load_Data()
    End Sub
End Class