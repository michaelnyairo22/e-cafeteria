Imports DevExpress.XtraGrid.Views.Grid
Public Class frmNewOrder
    Dim Strsql As String = ""
    Dim _mysql As New ClsSQLhelper
    Dim DT_Food_Order As New DataTable
    Dim Primary_Key As Integer = -1
    Dim Menu_Select As Integer
    Dim Menu_Qty As Integer
    Dim Menu_Discount As Integer
    Dim Menu_Name As String
    Dim Menu_Price As Integer
    Dim Menu_total_Price As Integer
    Dim Menu_Waiter As String
    Dim Menu_Food_status As String

#Region "Functions"
    Sub load_data()
        Try

            Strsql = "select food_order_detail.*, menu.menu_name,concat(employee.emp_firstname,employee.emp_lname) as fullname,food_order_status.food_order_status_name  from food_order_detail "
            Strsql = Strsql & " left join menu on food_order_detail.order_detail_menu_id= menu.menu_id "
            Strsql = Strsql & " left join employee on food_order_detail.order_detail_waiter= employee.emp_id "
            Strsql = Strsql & " Left Join food_order_status ON food_order_status.food_order_status_id = food_order_detail.order_detail_status"
            Strsql = Strsql & " where food_order_detail.order_food_id = " & Me.TxtOrderNo.Text
            DT_Food_Order = _mysql.GetMYSQLDataTable(Strsql, "food_order_detail")
            GridControl1.DataSource = DT_Food_Order

            Me.GridColumn1.FieldName = "order_detail_menu_id"
            Me.GridColumn1.Caption = "รหัส"
            Me.GridColumn1.OptionsColumn.ReadOnly = True

            Me.GridColumn2.FieldName = "menu_name"
            Me.GridColumn2.Caption = "ชื่ออาหาร"
            Me.GridColumn2.OptionsColumn.ReadOnly = True

            Me.GridColumn3.FieldName = "order_detail_price"
            Me.GridColumn3.Caption = "ราคา"
            Me.GridColumn3.OptionsColumn.ReadOnly = True

            Me.GridColumn4.FieldName = "order_detail_qty"
            Me.GridColumn4.Caption = "จำนวน"
            Me.GridColumn4.OptionsColumn.ReadOnly = True

            Me.GridColumn5.FieldName = "order_detail_discount"
            Me.GridColumn5.Caption = "ส่วนลด"
            Me.GridColumn5.OptionsColumn.ReadOnly = True

            Me.GridColumn6.FieldName = "order_detail_total_price"
            Me.GridColumn6.Caption = "คิดเป็นเงิน"
            Me.GridColumn6.OptionsColumn.ReadOnly = True

            Me.GridColumn7.FieldName = "fullname"
            Me.GridColumn7.Caption = "ผู้ให้บริการ"
            Me.GridColumn7.OptionsColumn.ReadOnly = True

            Me.GridColumn8.FieldName = "order_datetime"
            Me.GridColumn8.Caption = "วันเวลาที่สั่ง"
            Me.GridColumn8.OptionsColumn.ReadOnly = True
            Me.GridColumn8.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"

            Me.GridColumn9.FieldName = "food_order_status_name"
            Me.GridColumn9.Caption = "สถานะ"
            Me.GridColumn9.OptionsColumn.ReadOnly = True

            Me.GridColumn10.FieldName = "order_food_detail_id"
            Me.GridColumn10.Caption = "Code"
            Me.GridColumn10.OptionsColumn.ReadOnly = True
            '
            Primary_Key = DT_Food_Order.Rows(0).Item("order_food_detail_id")

            Update_Price()

        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = "frmSearchMenu"
                .lblFunctionName.Text = "Load_Data"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql

            End With
        End Try
    End Sub
    Sub Update_Price()
        Try
            Dim CurrentPrice As Double = 0
            Dim CurrentDiscount As Double = 0
            Try
                Strsql = "Select Sum(order_detail_total_price) as price , sum(order_detail_discount) as discount from food_order_detail where order_food_id  = " & Me.TxtOrderNo.Text
                Dim DT_Summary As New DataTable
                DT_Summary = _mysql.GetMYSQLDataTable(Strsql, "food_order_detail")
                If DT_Summary.Rows.Count <> 0 Then
                    CurrentPrice = Val(DT_Summary.Rows(0).Item("price"))
                    CurrentDiscount = Val(DT_Summary.Rows(0).Item("discount"))
                End If

            Catch ex As Exception
                With frmDebug
                    .lblFormName.Text = Me.Name
                    .lblFunctionName.Text = "Update_Price"
                    .MemoErr_Description.Text = ex.Message
                    .MemoSQL.Text = Strsql
                    .ShowDialog()
                End With
            End Try

            'Update Total Price and Total Discount
            Try
                Strsql = "Update food_order set price = " & CurrentPrice & " ,discount = " & CurrentDiscount & " where order_id = " & Me.TxtOrderNo.Text
                _mysql.MySQLExecute(Strsql)
            Catch ex As Exception
                With frmDebug
                    .lblFormName.Text = Me.Name
                    .lblFunctionName.Text = "Update_Price"
                    .MemoErr_Description.Text = ex.Message
                    .MemoSQL.Text = Strsql
                    .ShowDialog()
                End With
            End Try

            Me.TxtTotalPrice.Text = CurrentPrice - CurrentDiscount
        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = "Update_Price"
                .lblFunctionName.Text = "Load_Data"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql

            End With
        End Try

    End Sub
#End Region

    Private Sub frmNewOrder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmNewOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.GridColumn1.FieldName = "order_detail_menu_id"
        Me.GridColumn1.Caption = "รหัส"
        Me.GridColumn1.OptionsColumn.ReadOnly = True

        Me.GridColumn2.FieldName = "menu_name"
        Me.GridColumn2.Caption = "ชื่ออาหาร"
        Me.GridColumn2.OptionsColumn.ReadOnly = True

        Me.GridColumn3.FieldName = "order_detail_price"
        Me.GridColumn3.Caption = "ราคา"
        Me.GridColumn3.OptionsColumn.ReadOnly = True

        Me.GridColumn4.FieldName = "order_detail_qty"
        Me.GridColumn4.Caption = "จำนวน"
        Me.GridColumn4.OptionsColumn.ReadOnly = True

        Me.GridColumn5.FieldName = "order_detail_discount"
        Me.GridColumn5.Caption = "ส่วนลด"
        Me.GridColumn5.OptionsColumn.ReadOnly = True

        Me.GridColumn6.FieldName = "order_detail_total_price"
        Me.GridColumn6.Caption = "คิดเป็นเงิน"
        Me.GridColumn6.OptionsColumn.ReadOnly = True

        Me.GridColumn7.FieldName = "fullname"
        Me.GridColumn7.Caption = "ผู้ให้บริการ"
        Me.GridColumn7.OptionsColumn.ReadOnly = True

        Me.GridColumn8.FieldName = "order_datetime"
        Me.GridColumn8.Caption = "วันเวลาที่สั่ง"
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"


        Me.GridColumn9.FieldName = "food_order_status_name"
        Me.GridColumn9.Caption = "สถานะ"
        Me.GridColumn9.OptionsColumn.ReadOnly = True

        Me.GridColumn10.FieldName = "order_food_detail_id"
        Me.GridColumn10.Caption = "Code"
        Me.GridColumn10.OptionsColumn.ReadOnly = True

        Strsql = "Select order_billno from food_order where order_id = " & Me.TxtOrderNo.Text
        Me.TxtBill.Text = _mysql.MySQLExecuteScalar(Strsql)


        load_data()
    End Sub

    Private Sub BtnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOrder.Click
        frmSearchMenu.My_Food_Order_id = Val(Me.TxtOrderNo.Text)
        If frmSearchMenu.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            frmSearchMenu.Dispose()
            Exit Sub
        Else
            Update_Price()
            frmSearchMenu.Dispose()
        End If

        load_data()

    End Sub



    Private Sub TextEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Update_Price()

        Me.Dispose()
    End Sub


    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridView1_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEditForEditing
        Try
            Dim gv As GridView
            gv = sender
            Primary_Key = gv.GetRowCellValue(e.RowHandle, gv.Columns("order_food_detail_id"))
            Menu_Select = gv.GetRowCellValue(e.RowHandle, gv.Columns("order_detail_menu_id"))
            Menu_Name = gv.GetRowCellValue(e.RowHandle, gv.Columns("menu_name"))
            Menu_Qty = gv.GetRowCellValue(e.RowHandle, gv.Columns("order_detail_qty"))
            Menu_Discount = gv.GetRowCellValue(e.RowHandle, gv.Columns("order_detail_discount"))
            Menu_Waiter = gv.GetRowCellValue(e.RowHandle, gv.Columns("fullname")).ToString
            Menu_Food_status = gv.GetRowCellValue(e.RowHandle, gv.Columns("food_order_status_name"))
            Menu_Price = gv.GetRowCellValue(e.RowHandle, gv.Columns("order_detail_price"))
            Menu_total_Price = gv.GetRowCellValue(e.RowHandle, gv.Columns("order_detail_total_price"))

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

       
    End Sub

    Private Sub BtnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCash.Click
        Try
            Strsql = "Select count(*) as cc from food_order_detail where order_food_id = " & Val(Me.TxtOrderNo.Text) & " and order_detail_status <> 2"
            Dim RCount As Integer = 0
            RCount = _mysql.MySQLExecuteScalar(Strsql)
            If RCount > 0 Then
                MsgBox("Order นี้มีรายการอาหารที่ยังไม่ได้รับ หากต้องการทำรายการต่อ " & vbCrLf & " กรุณาลบรายการที่ยังไม่รับออกก่อน", MsgBoxStyle.Exclamation, "ไม่สามารถทำรายการได้")
                Exit Sub
            End If
        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "BtnCash_Click"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try
        Try
            frmCash.Order_Id = Me.TxtOrderNo.Text
            frmCash.TxtPrice.Text = Me.TxtTotalPrice.Text
            frmCash.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub BtnDeleteOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteOrder.Click
        Try
            If MsgBox("คุณต้องการลบข้อมูลการสั่งอาหารในเมนูนี้ใช่หรือไม่", MsgBoxStyle.Question + vbYesNo, "ยืนยันการลบ") = vbNo Then Exit Sub


            Strsql = "Delete from food_order_detail where order_food_detail_id = " & Primary_Key
            _mysql.MySQLExecute(Strsql)
            MsgBox("ลบข้อมูลเรียบร้อย", MsgBoxStyle.Information)
            Update_Price()
            load_data()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnEditOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditOrder.Click
        Try
            If Primary_Key < 0 Then Exit Sub
            frmSearchMenu.Detail_Key = Primary_Key
            frmSearchMenu.My_Food_Order_id = Val(Me.TxtOrderNo.Text)
            frmSearchMenu.TxtSearch.Text = Menu_Select
            frmSearchMenu.TxtCode.Text = Menu_Select
            frmSearchMenu.TxtName.Text = Menu_Name
            frmSearchMenu.TxtQty.Text = Menu_Qty
            frmSearchMenu.txtDiscount.Text = Menu_Discount
            frmSearchMenu.CboEmp.SelectedText = Menu_Waiter
            frmSearchMenu.CboFoodOrderStatus.Text = Menu_Food_status
            frmSearchMenu.TxtPrice.Text = Menu_total_Price
            frmSearchMenu.TxtTotalprice.Text = Menu_Price
            If frmSearchMenu.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                frmSearchMenu.Dispose()
                Exit Sub
            Else
                frmSearchMenu.Dispose()
            End If
            Update_Price()
            load_data()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub BtnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMove.Click
        frmMoveTable.Curr_Order = Me.TxtOrderNo.Text
        frmMoveTable.ShowDialog()

    End Sub

    Private Sub BtnDelOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelOrder.Click
        Try
            If MsgBox("คุณต้องการลบ Order นี้ใช่หรือไม่", MsgBoxStyle.Question, "ยืนยันการลบข้อมูล") = vbNo Then Exit Sub
            'Delete Detail
            Strsql = "Delete from food_order_detail where order_food_id = " & Me.TxtOrderNo.Text
            _mysql.MySQLExecute(Strsql)

            'Delete order
            Strsql = "Delete from food_order where order_id = " & Me.TxtOrderNo.Text
            _mysql.MySQLExecute(Strsql)

            'Update Table Status
            Strsql = "Update table_settings set table_status = 1 where table_zone = '" & My.Settings.CurrentZone & "' and table_name = " & My.Settings.CurrentTable
            _mysql.MySQLExecute(Strsql)

            MsgBox("ลบข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการลบข้อมูล")

            Me.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBooking.Click
        With frmbooking
            .primary_key = Me.TxtOrderNo.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub BtnCompleteOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCompleteOrder.Click
        Try
            Strsql = "Update food_order_detail set order_detail_status = 2 where order_food_id = " & Me.TxtOrderNo.Text
            _mysql.MySQLExecute(Strsql)
            Select Case _mysql.MySQLExecute(Strsql)
                Case 0
                    MsgBox("ขอภัยไม่สามารถเพิ่มได้เนื่องจากไม่พบเงื่อนไขตามที่กำหนด", MsgBoxStyle.Exclamation, "ผลการปรับปรุง")
                Case Is > 0
                    MsgBox("ปรับปรุงข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการปรับปรุง")
                Case -1

                    With frmDebug

                        .lblFormName.Text = "ClsMenu"
                        .lblFunctionName.Text = "Insert_Data"
                        .MemoErr_Description.Text = "ขอภัยไม่สามารถเพิ่มได้เนื่องจากคำสั่ง sql หรือ ค่าที่รับมาไม่สมบูรณ์ กรุณาตรวจสอบคำสั่ง SQL"
                        .MemoSQL.Text = Strsql
                        .ShowDialog()
                    End With
            End Select
            load_data()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class