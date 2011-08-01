Public Class frmZoneSettings
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
    Public Zone As String
    Dim DT_Zone As New DataTable
    Dim MyZone As New ClsZone
    Dim On_Load As Boolean = True
#Region "Functjion"
   
    Sub Load_Detail()
        With LsvZone

            .DataSource = MyZone.get_Datatable
            .DisplayMember = "zone_name"
            .ValueMember = "zone_name"
        End With
    End Sub
    Sub Load_zone_Detail()
        Try
            Dim DRZone As DataRow
            DRZone = MyZone.get_DataRow(Me.LsvZone.Text)
            VColZone.Properties.Value = Me.LsvZone.Text
            VColZoneName.Properties.Value = DRZone.Item("zone_displaytext").ToString()
            VColTable.Properties.Value = DRZone.Item("zone_tables").ToString()
            VColActive.Properties.Value = IIf((DRZone.Item("zone_status")) = 1, True, False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub Load_Color()
        Try
            Me.ColorActiveEdit1.Color = MyZone.EnableColor
            Me.ColorUnActiveEdit2.Color = MyZone.DisableColor
            Me.ColorFullEdit.Color = MyZone.FullColor
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub frmZoneSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Load_Detail()
        Load_zone_Detail()
        Load_Color()
        On_Load = False
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub LsvZone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LsvZone.SelectedIndexChanged
        If On_Load = True Then Exit Sub
        Load_zone_Detail()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        MyZone.Update_ZoneSetting(Me.LsvZone.Text, VColZoneName.Properties.Value, VColActive.Properties.Value, VColTable.Properties.Value)
    End Sub

    Private Sub BtnChangeActiveColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeActiveColor.Click
        MyZone.EnableColor = Me.ColorActiveEdit1.Color
    End Sub

    Private Sub BtnDefaultActiveColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultActiveColor.Click
        ColorActiveEdit1.Color = MyZone.GetDefaultEnableColor
    End Sub

    Private Sub BtnDefaultUnActiveColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultUnActiveColor.Click
        ColorUnActiveEdit2.Color = MyZone.GetDefaultDisableColor
    End Sub

    Private Sub BtnChangeUnActiveColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeUnActiveColor.Click
        MyZone.DisableColor = Me.ColorUnActiveEdit2.Color
    End Sub

    Private Sub BtnDefaultFullColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefaultFullColor.Click
        Me.ColorFullEdit.Color = MyZone.GetDefaultFullColor
    End Sub

    Private Sub BtnChangeFullColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangeFullColor.Click
        MyZone.FullColor = Me.ColorFullEdit.Color
    End Sub

    Private Sub VGridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VGridControl1.Click

    End Sub
End Class