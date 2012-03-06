Imports DevExpress.XtraGrid.Views.Grid
Public Class frmOrderlist
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Dim Primary_Key As Integer = -1
    Dim DT_Order As New DataTable
#Region "Function"
    Sub Load_Data(ByVal ShowAllOpenOrder As Boolean)

        Me.GridColumn1.FieldName = "order_id"
        Me.GridColumn1.Caption = "รหัส"
        'Me.GridColumn1.OptionsColumn.ReadOnly = True

        Me.GridColumn2.FieldName = "order_billno"
        Me.GridColumn2.Caption = "เลขที่ใบเสร็จ"
        'Me.GridColumn2.OptionsColumn.ReadOnly = True

        Me.GridColumn3.FieldName = "order_date"
        Me.GridColumn3.Caption = "วันและเวลา"
        ' Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"

        Me.GridColumn4.FieldName = "zone_id"
        Me.GridColumn4.Caption = "โซน"
        ' Me.GridColumn4.OptionsColumn.ReadOnly = True

        Me.GridColumn5.FieldName = "table_id"
        Me.GridColumn5.Caption = "โต๊ะ"
        ' Me.GridColumn5.OptionsColumn.ReadOnly = True

        Me.GridColumn6.FieldName = "price"
        Me.GridColumn6.Caption = "ราคา"
        ' Me.GridColumn6.OptionsColumn.ReadOnly = True

        Me.GridColumn7.FieldName = "discount"
        Me.GridColumn7.Caption = "ส่วนลด"
        ' Me.GridColumn7.OptionsColumn.ReadOnly = True

        Me.GridColumn8.FieldName = "order_status_name"
        Me.GridColumn8.Caption = "สถานะ"
        '  Me.GridColumn8.OptionsColumn.ReadOnly = True

        Me.GridColumn9.FieldName = "billing_datetime"
        Me.GridColumn9.Caption = "วันและเวลาที่เช็คบิล"
        ' Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"

        Me.GridColumn10.FieldName = "remark"
        Me.GridColumn10.Caption = "หมายเหตุ"
        ' Me.GridColumn10.OptionsColumn.ReadOnly = True

        Try
            Strsql = "select food_order.*,order_status.order_status_name from food_order left join order_status on food_order.order_status = order_status.order_status_id where "

            If ShowAllOpenOrder = False Then
                Strsql = Strsql & " date(order_date) = '" & Pn_Framework.MysqlDateTimeFormat(DTPOrderDate.DateTime, False) & "'"
                If Me.ChkShowAll.Checked = False Then Strsql = Strsql & " and order_status = 1"
                
                Me.ChkShowAll.Enabled = True
                Me.DTPOrderDate.Enabled = True
            Else
                Me.ChkShowAll.Enabled = False
                Me.DTPOrderDate.Enabled = False
                Strsql = Strsql & "  order_status = 2"
            End If
            


            DT_Order = _mysql.GetMYSQLDataTable(Strsql, "food_order")
            With GridControl1
                .DataSource = DT_Order
            End With
            If DT_Order.Rows.Count <> 0 Then
                Primary_Key = DT_Order.Rows(0).Item("order_id")
                My.Settings.CurrentZone = DT_Order.Rows(0).Item("zone_id")
                My.Settings.CurrentTable = DT_Order.Rows(0).Item("table_id")
            End If


        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "Load_Data"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try

        Try
            Strsql = "Select sum(price) as price,sum(discount) as discount from food_order where date(order_date) = '" & Pn_Framework.MysqlDateTimeFormat(DTPOrderDate.DateTime, False) & "'"
            If Me.ChkShowAll.Checked = False Then Strsql = Strsql & " and order_status = 1"
            Dim DT_Order_Summary As New DataTable
            DT_Order_Summary = _mysql.GetMYSQLDataTable(Strsql, "food_order")
            Me.TxtTotalValues.Text = Val(DT_Order_Summary.Rows(0).Item("price").ToString) - Val(DT_Order_Summary.Rows(0).Item("discount").ToString)

        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "Load_Data"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = Strsql
                .ShowDialog()
            End With
        End Try
    End Sub
   
#End Region

    Private Sub frmOrderlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DTPOrderDate.DateTime = Now
        Load_Data(False)
    End Sub

    Private Sub DTPOrderDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPOrderDate.EditValueChanged
        Load_Data(False)
    End Sub

    Private Sub ChkShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkShowAll.CheckedChanged
        Load_Data(False)
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub BtnNewOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewOrder.Click
        Try
            Dim Billno As Integer
            Dim TotalPrice As Long = 0
            Dim TotalDiscount As Long = 0
            Dim Order_billno As Integer
            Dim Last_InsertID As Integer

            frmMain.BtnCheckTable.Enabled = False
            If frmZones.ShowDialog = DialogResult.OK Then

                If frmTables.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    frmTables.Dispose()
                    frmNewOrder.MdiParent = frmMain
                    Strsql = "Select order_id from food_order where zone_id = '" & My.Settings.CurrentZone & "' and table_id = '" & My.Settings.CurrentTable & "' and order_status = 1"
                    Dim DTOrderSelect As New DataTable
                    DTOrderSelect = _mysql.GetMYSQLDataTable(Strsql, "food_order")
                    If DTOrderSelect.Rows.Count > 0 Then
                        frmNewOrder.TxtOrderNo.Text = DTOrderSelect.Rows(0).Item("order_id")
                        frmNewOrder.Show()
                    Else
                        If MsgBox("คุณต้องการเปิด Order ใหม่ใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยัน") = MsgBoxResult.No Then
                            frmTables.Close()
                            frmMain.BtnCheckTable.Enabled = True
                            Load_Data(False)
                            Exit Sub
                        End If
                        'Update Table Status
                        Try
                            Strsql = "Update table_settings set table_status = 3 where table_zone = '" & My.Settings.CurrentZone & "' and table_name = '" & My.Settings.CurrentTable & "'"
                            _mysql.MySQLExecute(Strsql)
                        Catch ex As Exception
                            With frmDebug
                                .lblFormName.Text = Me.Name
                                .lblFunctionName.Text = "BtnNewOrder_Click"
                                .MemoErr_Description.Text = ex.Message
                                .MemoSQL.Text = Strsql
                                .ShowDialog()
                            End With
                        End Try


                      


                      

                        'Insert Order Info
                        Try
                            Strsql = "Insert into food_order (zone_id,table_id,order_status,order_date,order_billno) values ('" & My.Settings.CurrentZone & "', '" & My.Settings.CurrentTable & "',1,now(),'')"
                            _mysql.MySQLExecute(Strsql)
                        Catch ex As Exception
                            With frmDebug
                                .lblFormName.Text = Me.Name
                                .lblFunctionName.Text = "BtnNewOrder_Click"
                                .MemoErr_Description.Text = ex.Message
                                .MemoSQL.Text = Strsql
                                .ShowDialog()
                            End With
                        End Try


                        Try
                            Strsql = "select last_insert_id() from food_order"
                            Last_InsertID = _mysql.MySQLExecuteScalar(Strsql)
                            frmNewOrder.TxtOrderNo.Text = Last_InsertID
                        Catch ex As Exception
                            With frmDebug
                                .lblFormName.Text = Me.Name
                                .lblFunctionName.Text = "BtnNewOrder_Click"
                                .MemoErr_Description.Text = ex.Message
                                .MemoSQL.Text = Strsql
                                .ShowDialog()
                            End With
                        End Try




                        'Load Auto Menu
                        Try
                            Strsql = "Select menu_id,menu_price,menu_discount from menu where menu_auto = 'Y'"
                            Dim DT_AutoMenu As New DataTable
                            DT_AutoMenu = _mysql.GetMYSQLDataTable(Strsql, "menu")

                            If DT_AutoMenu.Rows.Count <> 0 Then
                                For i = 0 To DT_AutoMenu.Rows.Count - 1
                                    Strsql = "Insert into food_order_detail (order_food_id,order_detail_menu_id,order_detail_price,order_detail_qty,order_detail_discount,order_detail_total_price,order_detail_waiter,order_datetime) "
                                    Strsql = Strsql & " Values (" & Last_InsertID & ",'" & DT_AutoMenu.Rows(i).Item("menu_id") & "'," & DT_AutoMenu.Rows(i).Item("menu_price") & ",1," & DT_AutoMenu.Rows(i).Item("menu_discount") & "," & Val(DT_AutoMenu.Rows(i).Item("menu_price")) - Val(DT_AutoMenu.Rows(i).Item("menu_discount")) & ",0,now())"
                                    _mysql.MySQLExecute(Strsql)
                                    TotalPrice = TotalPrice + Val(DT_AutoMenu.Rows(i).Item("menu_price").ToString)
                                    TotalDiscount = TotalDiscount + Val(DT_AutoMenu.Rows(i).Item("menu_discount"))

                                Next


                            End If
                        Catch ex As Exception
                            With frmDebug
                                .lblFormName.Text = Me.Name
                                .lblFunctionName.Text = "BtnNewOrder_Click"
                                .MemoErr_Description.Text = ex.Message
                                .MemoSQL.Text = Strsql
                                .ShowDialog()
                            End With
                        End Try


                        'Update Total Price and Total Discount
                        Try
                            Strsql = "Update food_order set price = " & TotalPrice & " ,discount = " & TotalDiscount & " where order_id = " & Last_InsertID
                            _mysql.MySQLExecute(Strsql)
                        Catch ex As Exception
                            With frmDebug
                                .lblFormName.Text = Me.Name
                                .lblFunctionName.Text = "BtnNewOrder_Click"
                                .MemoErr_Description.Text = ex.Message
                                .MemoSQL.Text = Strsql
                                .ShowDialog()
                            End With
                        End Try


                        frmNewOrder.Show()
                    End If
                    frmMain.BtnCheckTable.Enabled = True
                    Load_Data(False)
                    Exit Sub
                End If
            frmMain.BtnCheckTable.Enabled = True
                Load_Data(False)
                Exit Sub

            End If
            frmMain.BtnCheckTable.Enabled = True
            Load_Data(False)
        Catch ex As Exception
            frmMain.BtnCheckTable.Enabled = True
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnDelOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelOrder.Click
        Try
            If DT_Order.Rows.Count = 0 Then
                MsgBox("ไม่พบรายการ", MsgBoxStyle.Critical, "ขออภัยไม่สามารถดำเนินการได้")
                Exit Sub
            End If


            If MsgBox("คุณต้องการลบ Order นี้ใช่หรือไม่", MsgBoxStyle.Question, "ยืนยันการลบข้อมูล") = vbNo Then Exit Sub
            'Delete Detail
            Strsql = "Delete from food_order_detail where order_food_id = " & Primary_Key
            _mysql.MySQLExecute(Strsql)

            'Delete order
            Strsql = "Delete from food_order where order_id = " & Primary_Key
            _mysql.MySQLExecute(Strsql)

            'Update Table Status
            Strsql = "Update table_settings set table_status = 1 where table_zone = '" & My.Settings.CurrentZone & "' and table_name = " & My.Settings.CurrentTable
            _mysql.MySQLExecute(Strsql)

            MsgBox("ลบข้อมูลเรียบร้อยแล้ว", MsgBoxStyle.Information, "ผลการลบข้อมูล")
            Load_Data(False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnEditOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditOrder.Click
        Try
            If DT_Order.Rows.Count = 0 Then
                MsgBox("ไม่พบรายการ", MsgBoxStyle.Critical, "ขออภัยไม่สามารถดำเนินการได้")
                Exit Sub
            End If
            frmNewOrder.TxtOrderNo.Text = Primary_Key
            frmNewOrder.ShowDialog()
            Load_Data(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If DT_Order.Rows.Count = 0 Then
            MsgBox("ไม่พบรายการ", MsgBoxStyle.Critical, "ขออภัยไม่สามารถดำเนินการได้")
            Exit Sub
        End If
    End Sub



    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub GridView1_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEditForEditing
    '    Dim gv As GridView
    '    gv = sender
    '    Primary_Key = gv.GetRowCellValue(e.RowHandle, gv.Columns("order_id"))
    'End Sub


    Private Sub GridView1_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEditForEditing
        Dim gv As GridView
        gv = sender
        Primary_Key = gv.GetRowCellValue(e.RowHandle, gv.Columns("order_id"))
    End Sub

    Private Sub BtnShowAllOpenOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowAllOpenOrder.Click
        Load_Data(True)
    End Sub

    Private Sub GridControl1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click

    End Sub
End Class