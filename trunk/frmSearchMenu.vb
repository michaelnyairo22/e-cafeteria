Imports DevExpress.XtraGrid.Views.Grid
Public Class frmSearchMenu
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Public My_Food_Order_id As String
    Public Primary_Key As String
    Public Detail_Key As Integer = -1
    Dim DT_Menu As New DataTable
#Region "Function"
    Sub Load_Emp()
        Try
            Strsql = "select emp_id,concat(employee.emp_firstname,employee.emp_lname) as fullname from employee left join sex on employee.emp_sex= sex.sex_id left join emp_status on employee.emp_status= emp_status.emp_status_id"
            Dim DT_Emp As New DataTable
            DT_Emp = _mysql.GetMYSQLDataTable(Strsql, "employee")
            With CboEmp
                .DataSource = DT_Emp
                .DisplayMember = "fullname"
                .ValueMember = "emp_id"
            End With
        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "Load_Emp"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try
       
    End Sub
    Sub Load_Food_Order()
        Try
            Strsql = "select * from food_order_status"

            Dim DT_food_Order_Status As New DataTable
            DT_food_Order_Status = _mysql.GetMYSQLDataTable(Strsql, "food_order_status")
            With CboFoodOrderStatus
                .DataSource = DT_food_Order_Status
                .DisplayMember = "food_order_status_name"
                .ValueMember = "food_order_status_id"
            End With
            If Detail_Key <> -1 Then
                Strsql = "Select *  from food_order_detail  where order_food_detail_id = " & Detail_Key
                Dim DT_Detail As DataTable
                DT_Detail = _mysql.GetMYSQLDataTable(Strsql, "food_order_detail")
                Me.CboFoodOrderStatus.SelectedValue = DT_Detail.Rows(0).Item("order_detail_status")
            End If
            '  
        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "Load_Food_Order"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try
    End Sub
    Sub Load_Data()
        Try
            Strsql = "SELECT menu.menu_id, menu.menu_name, menu.menu_price, menu.menu_discount, menu.menu_committion, menu.menu_group, menu.menu_favoriate, menugroup.group_id,"
            Strsql = Strsql & " menugroup.group_name FROM menu left Join menugroup ON menu.menu_group = menugroup.group_id "
            If Me.TxtSearch.Text <> "" Then
                Select Case RadioGroup1.EditValue
                    Case 0
                        Strsql = Strsql & " where menu_id like '" & Me.TxtSearch.Text & "%'"
                    Case 1
                        Strsql = Strsql & " where menu_name like '" & Me.TxtSearch.Text & "%'"
                End Select
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

            DT_Menu = _mysql.GetMYSQLDataTable(Strsql, "Menu")
            GridMenu.DataSource = DT_Menu

            If DT_Menu.Rows.Count <> 0 Then
                Me.Primary_Key = DT_Menu.Rows(0).Item("menu_id")
                Me.TxtCode.Text = DT_Menu.Rows(0).Item("menu_id")
                Me.TxtName.Text = DT_Menu.Rows(0).Item("menu_name")
                Me.TxtPrice.Text = DT_Menu.Rows(0).Item("menu_price")
                Me.txtDiscount.Text = DT_Menu.Rows(0).Item("menu_discount")
                Me.TxtQty.Text = 1
                Me.TxtTotalprice.Text = (Val(Me.TxtPrice.Text) - Val(Me.txtDiscount.Text)) * Val(Me.TxtQty.Text)

            End If

        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = "frmSearchMenu"
                .lblFunctionName.Text = "Load_Data"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql

            End With
        End Try
    End Sub
#End Region

    Private Sub frmSearchMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Primary_Key = "" Then DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub
    Private Sub frmSearchMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        Load_Emp()
        Load_Food_Order()


        If Detail_Key <> -1 Then
            Me.BtnOK.Image = My.Resources.disk_blue
            BtnOK.Text = "บันทึก"
        Else
            Me.BtnOK.Image = My.Resources.add2
            Me.BtnOK.Text = "เพิ่ม"
            
        End If
    End Sub



    Private Sub PanelControl2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelControl2.Paint

    End Sub

    Private Sub GridMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridMenu.Click

    End Sub



    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
       
        Try
            If DT_Menu.Rows.Count < 1 Then
                MsgBox("ไม่มีรายการที่เลือก", MsgBoxStyle.Critical, "ไม่สามารถทำรายการได้")
                Exit Sub
            End If

            Select Case Detail_Key
                Case -1
                    If Primary_Key = Nothing And GridView1.RowCount = 0 Then
                        MsgBox("กรุณาเลือกรายการ", MsgBoxStyle.Exclamation, "ไม่สามารถทำรายการได้")
                    Else
                        Strsql = "Insert into food_order_detail (order_food_id,order_detail_menu_id,order_detail_price,order_detail_qty,order_detail_discount,order_detail_total_price,order_detail_waiter,order_detail_status,order_datetime) values "
                        Strsql = Strsql & "(" & Me.My_Food_Order_id & ",'" & Me.TxtCode.Text & "'," & Me.TxtPrice.Text & "," & Me.TxtQty.Text & "," & Me.txtDiscount.Text & "," & Me.TxtTotalprice.Text & "," & Me.CboEmp.SelectedValue & "," & Me.CboFoodOrderStatus.SelectedValue & ",now())"
                        _mysql.MySQLExecute(Strsql)
                       
                    End If
                Case Else
                    Strsql = "Update food_order_detail set order_detail_menu_id = '" & Me.TxtCode.Text & "' , order_detail_price = " & Me.TxtPrice.Text
                    Strsql = Strsql & "  ,order_detail_qty = " & Me.TxtQty.Text & " ,order_detail_discount =" & Me.txtDiscount.Text
                    Strsql = Strsql & "  ,order_detail_waiter = " & Me.CboEmp.SelectedValue & " ,order_detail_total_price = " & Me.TxtTotalprice.Text
                    Strsql = Strsql & "  , order_datetime=now(),order_detail_status = " & Me.CboFoodOrderStatus.SelectedValue
                    Strsql = Strsql & "   where  order_food_id  = '" & My_Food_Order_id & "' and order_food_detail_id  = " & Detail_Key
                    _mysql.MySQLExecute(Strsql)
                  
            End Select

        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "BtnOK_Click"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try


        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub GridView1_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEditForEditing
        Try
            Dim gv As GridView = sender
            Primary_Key = gv.GetRowCellValue(e.RowHandle, gv.Columns("menu_id"))
            Me.TxtCode.Text = Primary_Key
            Me.TxtName.Text = gv.GetRowCellValue(e.RowHandle, gv.Columns("menu_name"))
            Me.TxtPrice.Text = gv.GetRowCellValue(e.RowHandle, gv.Columns("menu_price"))
            Me.txtDiscount.Text = gv.GetRowCellValue(e.RowHandle, gv.Columns("menu_discount"))
            Me.TxtQty.Text = 1
            Me.TxtTotalprice.Text = (Val(Me.TxtPrice.Text) - Val(Me.txtDiscount.Text)) * Val(Me.TxtQty.Text)
        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "GridView1_CustomRowCellEditForEditing"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try
     
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        TxtSearch.Text = ""
    End Sub


    Private Sub BtnNo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNo1.Click
        TxtSearch.Text = TxtSearch.Text & "1"
    End Sub

    Private Sub BtnNO2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO2.Click
        TxtSearch.Text = TxtSearch.Text & "2"
    End Sub

    Private Sub BtnNO3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO3.Click
        TxtSearch.Text = TxtSearch.Text & "3"
    End Sub

    Private Sub BtnNO4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO4.Click
        TxtSearch.Text = TxtSearch.Text & "4"
    End Sub

    Private Sub BtnNO5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO5.Click
        TxtSearch.Text = TxtSearch.Text & "5"
    End Sub

    Private Sub BtnNO6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO6.Click
        TxtSearch.Text = TxtSearch.Text & "6"
    End Sub

    Private Sub BtnNO7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO7.Click
        TxtSearch.Text = TxtSearch.Text & "7"
    End Sub

    Private Sub BtnNO8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO8.Click
        TxtSearch.Text = TxtSearch.Text & "8"
    End Sub

    Private Sub BtnNO9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO9.Click
        TxtSearch.Text = TxtSearch.Text & "9"
    End Sub

    Private Sub BtnNO10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO10.Click
        TxtSearch.Text = TxtSearch.Text & "0"
    End Sub

    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        Load_Data()
    End Sub


    Private Sub TxtQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty.EditValueChanged
        Me.TxtTotalprice.Text = (Val(Me.TxtPrice.Text) - Val(Me.txtDiscount.Text)) * Val(Me.TxtQty.Text)
    End Sub
End Class