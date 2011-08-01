Public Class frmMain
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Dim DT_FoodOrder As New DataTable

    Public Order_food_id As Integer
#Region "Function"
    Sub Load_Data()
        Try
            Strsql = "select * from food_order where zone_id = '" & My.Settings.CurrentZone & "' and table_id = " & My.Settings.CurrentTable & " and order_status = 1)"
            DT_FoodOrder = _mysql.GetMYSQLDataTable(Strsql, "food_order")

        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub BtnDB_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnDB.ItemClick
        With frmDBSetting
            .MdiParent = Me
            .Show()
        End With
    End Sub



    Private Sub BtnCurrentSQL_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnCurrentSQL.ItemClick
        With frmDebug
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub BtnZone_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnZone.ItemClick
        With frmZoneSettings
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub BtnMenus_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnMenus.ItemClick
        With frmMenusSetting
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub BtnTables_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnTables.ItemClick
        With frmTablesSettings
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub BtnEmp_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnEmp.ItemClick
        With frmEmployeeSettings
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub BtnExit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnExit.ItemClick
        Me.Close()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("คุณต้องการออกจากระบบใช่หรือไม่", MsgBoxStyle.Question + vbYesNo, "ยืนยันการออกจากระบบ") = vbNo Then
            Exit Sub
        Else
            Me.Dispose()
        End If

    End Sub

    Private Sub BtnUser_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnUser.ItemClick
        With frmUserSettings
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub BtnCheckTable_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnCheckTable.ItemClick
        Try

            Dim TotalPrice As Long = 0
            Dim TotalDiscount As Long = 0
            Dim Last_InsertID As Integer
            BtnCheckTable.Enabled = False
            If frmZones.ShowDialog = DialogResult.OK Then

                If frmTables.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    frmTables.Dispose()
                    frmNewOrder.MdiParent = Me

       
                    Strsql = "Select order_id from food_order where zone_id = '" & My.Settings.CurrentZone & "' and table_id = '" & My.Settings.CurrentTable & "' and order_status = 1"
                    Dim DTOrderSelect As New DataTable
                    DTOrderSelect = _mysql.GetMYSQLDataTable(Strsql, "food_order")
                    If DTOrderSelect.Rows.Count > 0 Then
                        frmNewOrder.TxtOrderNo.Text = DTOrderSelect.Rows(0).Item("order_id")
                        frmNewOrder.Show()
                    Else
                        If MsgBox("คุณต้องการเปิด Order ใหม่ใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยัน") = MsgBoxResult.No Then
                            frmTables.Close()
                            BtnCheckTable.Enabled = True
                            Exit Sub
                        End If
                        'Update Table Status
                        Try
                            Strsql = "Update table_settings set table_status = 3 where table_zone = '" & My.Settings.CurrentZone & "' and table_name = '" & My.Settings.CurrentTable & "'"
                            _mysql.MySQLExecute(Strsql)
                        Catch ex As Exception
                            With frmDebug
                                .lblFormName.Text = Me.Name
                                .lblFunctionName.Text = "BtnCheckTable_ItemClick"
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
                                .lblFunctionName.Text = "BtnCheckTable_ItemClick"
                                .MemoErr_Description.Text = ex.Message
                                .MemoSQL.Text = Strsql
                                .ShowDialog()
                            End With
                        End Try

                        'Get Last Insert ID
                        Try
                            Strsql = "select last_insert_id() from food_order"
                            Last_InsertID = _mysql.MySQLExecuteScalar(Strsql)
                            frmNewOrder.TxtOrderNo.Text = Last_InsertID
                        Catch ex As Exception
                            With frmDebug
                                .lblFormName.Text = Me.Name
                                .lblFunctionName.Text = "BtnCheckTable_ItemClick"
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
                                .lblFunctionName.Text = "BtnCheckTable_ItemClick"
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
                                .lblFunctionName.Text = "BtnCheckTable_ItemClick"
                                .MemoErr_Description.Text = ex.Message
                                .MemoSQL.Text = Strsql
                                .ShowDialog()
                            End With
                        End Try


                        frmNewOrder.Show()
                    End If
                    BtnCheckTable.Enabled = True
                    Exit Sub
                End If
                BtnCheckTable.Enabled = True
                Exit Sub

            End If
            BtnCheckTable.Enabled = True
        Catch ex As Exception
            BtnCheckTable.Enabled = True
            MsgBox(ex.Message)
        End Try


    End Sub




    Private Sub BtnOrderList_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnOrderList.ItemClick
        With frmOrderlist
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
        End With
    End Sub
End Class