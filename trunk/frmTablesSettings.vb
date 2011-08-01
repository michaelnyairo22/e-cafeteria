Public Class frmTablesSettings
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Dim Primary_key As Integer
    Dim myTable As New ClsTable
    Dim On_Load As Boolean = True
#Region "Function"
    Sub Load_Data()
        Dim DT_Tabe As DataTable = myTable.Get_DataTable(Me.CboZone.Text)
        With LsvTable
            .DataSource = Nothing

            .DataSource = DT_Tabe
            .DisplayMember = "table_name"
            .ValueMember = "table_name"
            If DT_Tabe.Rows.Count = 0 Then
                VGridControl1.Visible = False
                Me.BtnCancel.Visible = False
                Me.BtnDelete.Visible = False
                Me.BtnSave.Visible = False
            Else
                VGridControl1.Visible = True
                Me.BtnCancel.Visible = True
                Me.BtnDelete.Visible = True
                Me.BtnSave.Visible = True
            End If

        End With
        Me.TxtTotalTable.EditValue = myTable.Total_Table(Me.CboZone.Text)
    End Sub
    Sub Load_table_Detail()
        Try

            Dim DRTable As DataRow

            DRTable = myTable.Get_DataRow(Me.CboZone.Text, Val(Me.LsvTable.Text))
            VColTable.Properties.Value = Me.LsvTable.Text
            VColTableName.Properties.Value = DRTable.Item("table_displaytext").ToString()
            VColTable.Properties.Value = DRTable.Item("table_Name").ToString()
            VColActive.Properties.Value = IIf((DRTable.Item("table_status")) = 1, True, False)

        Catch ex As Exception
            MsgBox("Load_table_Detail : " & ex.Message)
        End Try

    End Sub
    Sub Load_Color()
        Try
            Me.ColorActiveEdit1.Color = myTable.EnableColor
            Me.ColorBookingEdit.Color = myTable.BookingColor
            Me.ColorBusyEdit.Color = myTable.BusyColor
            Me.ColorUnActiveEdit2.Color = myTable.DisableColor
            Me.ColorWaitCheckOutEdit.Color = myTable.WaitCheckBillColor
            Me.ColorWaitFoodEdit.Color = myTable.WaitFoodColor

            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub BtnReCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReCreate.Click
        myTable.Create_Table(Me.CboZone.Text, Me.TxtTotalTable.Text)
        On_Load = True
        Load_Data()
        On_Load = False
    End Sub

    Private Sub frmTablesSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Data()
        Load_Color()
        On_Load = False
    End Sub

    Private Sub BtnDeleteAllTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteAllTable.Click
        myTable.Clear_AllTable(Me.CboZone.Text)
        Load_Data()
        Me.TxtTotalTable.EditValue = 0
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการบันทึก") = MsgBoxResult.No Then Exit Sub
        myTable.Update_Table(Me.CboZone.Text, Me.LsvTable.Text, VColActive.Properties.Value, Me.VColTableName.Properties.Value)

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Load_Data()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Load_Data()
    End Sub

    Private Sub LsvTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LsvTable.SelectedIndexChanged
        If On_Load = True Then Exit Sub
        Load_table_Detail()
    End Sub

    Private Sub BtnChangeActiveColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeActiveColor.Click
        myTable.EnableColor = Me.ColorActiveEdit1.Color
    End Sub

    Private Sub BtnChangeUnActiveColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeUnActiveColor.Click
        myTable.DisableColor = Me.ColorUnActiveEdit2.Color
    End Sub

    Private Sub BtnDefaultActiveColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultActiveColor.Click
        Me.ColorActiveEdit1.Color = myTable.GetDefaultEnableColor
    End Sub

    Private Sub BtnDefaultUnActiveColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultUnActiveColor.Click
        Me.ColorUnActiveEdit2.Color = myTable.GetDefaultDisableColor
    End Sub



    Private Sub BtnChangeBusyColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeBusyColor.Click

        myTable.BusyColor = Me.ColorBusyEdit.Color
    End Sub

    Private Sub BtnDefaultBusyColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultBusyColor.Click
        Me.ColorBusyEdit.Color = (myTable.GetDefaultBusyColor)
    End Sub

    Private Sub BtnChangeWaitFoodColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeWaitFoodColor.Click
        myTable.WaitFoodColor = ColorWaitFoodEdit.Color

    End Sub

    Private Sub BtnDefaultWaitFoodColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultWaitFoodColor.Click
        ColorWaitFoodEdit.Color = myTable.GetDefaultWaitFoodColor
    End Sub

    Private Sub BtnChangeBookingColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeBookingColor.Click
        myTable.WaitFoodColor = ColorBookingEdit.Color
    End Sub

    Private Sub BtnDefaultBookingColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultBookingColor.Click
        ColorBookingEdit.Color = myTable.GetDefaultBookingColor
    End Sub

    Private Sub BtnChangeWaitCheckOutColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeWaitCheckOutColor.Click
        myTable.WaitCheckBillColor = Me.ColorWaitCheckOutEdit.Color
    End Sub

    Private Sub BtnDefaultWaitCheckOutColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultWaitCheckOutColor.Click
        Me.ColorWaitCheckOutEdit.Color = myTable.GetDefaultWaitCheckBillColor

    End Sub
End Class