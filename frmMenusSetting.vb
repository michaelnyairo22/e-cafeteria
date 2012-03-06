Imports DevExpress.XtraGrid.Views.Grid
Public Class frmMenusSetting
    Dim Primary_Key As String
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Dim MyMenu As New ClsMenu
#Region "Function"
    Sub Load_Data()
        Try
            Dim Gropname As String = "ทั้งหมด"
            Dim StrCreteria As String = ""

            If CboGroup.EditValue = "ทั้งหมด" Then
                Gropname = ""
            Else
                Gropname = CboGroup.EditValue
            End If
            If Me.TxtSearch.Text <> "" Then
                Select Case RadioGroup1.EditValue
                    Case 0
                        StrCreteria = " where menu_id like '" & Me.TxtSearch.Text & "%' and group_name like '" & Gropname & "%'"
                    Case 1
                        StrCreteria = " where menu_name like '" & Me.TxtSearch.Text & "%' and group_name like '" & Gropname & "%'"
                End Select
            Else
                StrCreteria = " where group_name like '" & Gropname & "%'"
            End If

            Me.GridColumn1.FieldName = "menu_id"
            Me.GridColumn1.Caption = "รหัส"
            Me.GridColumn1.OptionsColumn.ReadOnly = True

            Me.GridColumn2.FieldName = "menu_name"
            Me.GridColumn2.Caption = "ชื่อเมนู"
            Me.GridColumn2.OptionsColumn.ReadOnly = True

            Me.GridColumn3.FieldName = "menu_price"
            Me.GridColumn3.Caption = "ราคา (บาท)"
            Me.GridColumn3.OptionsColumn.ReadOnly = True

            Me.GridColumn4.FieldName = "group_name"
            Me.GridColumn4.Caption = "หมวด"
            Me.GridColumn4.OptionsColumn.ReadOnly = True

            Me.GridColumn5.FieldName = "menu_favoriate"
            Me.GridColumn5.Caption = "รายการแนะนำ"
            Me.GridColumn5.OptionsColumn.ReadOnly = True

            Me.GridColumn6.FieldName = "menu_discount"
            Me.GridColumn6.Caption = "ส่วนลด"
            Me.GridColumn6.OptionsColumn.ReadOnly = True

            Me.GridColumn7.FieldName = "menu_committion"
            Me.GridColumn7.Caption = "ค่าคอมมิทชั่น"
            Me.GridColumn7.OptionsColumn.ReadOnly = True

            Me.GridColumn8.FieldName = "menu_auto"
            Me.GridColumn8.Caption = "รายการอัตโนมัติ"
            Me.GridColumn8.OptionsColumn.ReadOnly = True

            Dim DT_Menu As New DataTable
            DT_Menu = _mysql.GetMYSQLDataTable(Strsql & StrCreteria & " order by menu.menu_id", "Menu")
            GridMenu.DataSource = DT_Menu


            'With LUEMenuName
            '    Dim DT_SelectMenu As DataTable
            '    Strsql = "SELECT  menu.menu_name,menu.menu_id FROM menu"
            '    DT_SelectMenu = _mysql.GetMYSQLDataTable(Strsql, "Menu")

            '    .Properties.DataSource = DT_SelectMenu
            '    .Properties.DisplayMember = "menu_name"
            '    .Properties.ValueMember = "menu_id"

            'End With
        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "OK_Button_Click"
                .MemoErr_Description.Text = "SQL Error กรุณาตรวจสอบคำสั่ง"
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try
    End Sub
#End Region
    Private Sub frmMenus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Strsql = "select group_name from menugroup "
            Dim DT_MenuGroup As New DataTable
            DT_MenuGroup = _mysql.GetMYSQLDataTable(Strsql, "Menu")
            RepositoryItemLookUpEdit1.DataSource = DT_MenuGroup
            RepositoryItemLookUpEdit1.DisplayMember = "group_name"
            RepositoryItemLookUpEdit1.ValueMember = "group_name"

            Strsql = "SELECT menu.menu_id, menu.menu_name, menu.menu_price, menu.menu_discount, menu.menu_committion, menu.menu_group, menu.menu_favoriate, menugroup.group_id,"
            Strsql = Strsql & " menugroup.group_name,menu_auto FROM menu left Join menugroup ON menu.menu_group = menugroup.group_id"

            Load_Data()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridView1_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEditForEditing
        Dim Gv As GridView = sender
        Primary_Key = Gv.GetRowCellValue(e.RowHandle, Gv.Columns("menu_id"))
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText

    End Sub

    Private Sub BtnDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnDelete.ItemClick
        If MsgBox("คุณต้องการยืนยันการลบใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการลบ") = MsgBoxResult.No Then Exit Sub
        Dim MyEmp As New ClsEmployee
        MyMenu.Delete_Menu(Primary_Key)
        Load_Data()
    End Sub

    Private Sub BtnEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnEdit.ItemClick
        If Primary_Key = Nothing Then Exit Sub
        frmEditMenu.primary_key = Primary_Key
        If frmEditMenu.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Load_Data()
        End If
    End Sub

    Private Sub BtnAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnAdd.ItemClick
        frmNewMenu.CustomGroupName = CboGroup.EditValue

        If frmNewMenu.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Load_Data()
        End If
    End Sub

    Private Sub GridMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridMenu.Click

    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Load_Data()

    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Me.TxtSearch.Text = ""
        Me.CboGroup.EditValue = "ทั้งหมด"
        Load_Data()

    End Sub

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Load_Data()
        End If
    End Sub

    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        Load_Data()
    End Sub

    Private Sub BtnClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnClose.ItemClick
        Me.Dispose()
    End Sub

    Private Sub BtnClearAllAutoMenu_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnClearAllAutoMenu.ItemClick
        Try
            If MsgBox("คุณแน่ใจว่าต้องการยกเลิกเมนูอัตโนมัติทั้งหมดใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยัน") = MsgBoxResult.No Then Exit Sub


            Strsql = "Update menu  set menu_auto = 'N'"

            Select Case _mysql.MySQLExecute(Strsql)
                Case 0
                    MsgBox("ขอภัยไม่สามารถเพิ่มได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                Case Is > 0
                    MsgBox("เพิ่มข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")
                Case -1
                    With frmDebug

                        .lblFormName.Text = "ClsMenu"
                        .lblFunctionName.Text = "Insert_Data"
                        .MemoErr_Description.Text = "ขอภัยไม่สามารถเพิ่มได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์ กรุณาตรวจสอบคำสั่ง SQL"
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
            End Select
            Load_Data()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub CboGroup_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboGroup.EditValueChanged
        Load_Data()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Load_Data()
    End Sub

    Private Sub BtnManageGroup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnManageGroup.ItemClick

        With FrmMenuGroupList
            .WindowState = FormWindowState.Maximized
            .MdiParent = frmMain
            .Show()
        End With
    End Sub

    Private Sub BtnExportExcel_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnExportExcel.ItemClick
        Me.TxtSearch.Text = ""
        Me.CboGroup.EditValue = "ทั้งหมด"
        Load_Data()
        GridMenu.ExportToXls("c:\MenuExport.xls")
        MsgBox("Export to c:\MenuExport.xls")

    End Sub
End Class