Public Class frmZones

    Dim MyZone As New ClsZone
    Dim DTZone As New DataTable
#Region "Function"
    Function Load_Zone_Setting(ByVal Curr_Status As Integer, ByVal CurrBtn As Button)
        Select Case Curr_Status
            Case 1
                CurrBtn.Enabled = True
                CurrBtn.BackColor = MyZone.EnableColor


            Case 2
                CurrBtn.Enabled = False
                CurrBtn.BackColor = MyZone.DisableColor


            Case 3
                CurrBtn.Enabled = False
                CurrBtn.BackColor = MyZone.FullColor

        End Select
    End Function
    Sub Load_Zone_Caption()

        DTZone = MyZone.get_Datatable

        BtnZoneA.Text = DTZone.Rows(0).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(0).Item("zone_status"), BtnZoneA)

        BtnZoneB.Text = DTZone.Rows(1).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(1).Item("zone_status"), BtnZoneB)

        BtnZoneC.Text = DTZone.Rows(2).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(2).Item("zone_status"), BtnZoneC)

        BtnZoneD.Text = DTZone.Rows(3).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(3).Item("zone_status"), BtnZoneD)

        BtnZoneE.Text = DTZone.Rows(4).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(4).Item("zone_status"), BtnZoneE)

        BtnZoneF.Text = DTZone.Rows(5).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(5).Item("zone_status"), BtnZoneF)

        BtnZoneG.Text = DTZone.Rows(6).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(6).Item("zone_status"), BtnZoneG)

        BtnZoneH.Text = DTZone.Rows(7).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(7).Item("zone_status"), BtnZoneH)

        BtnZoneI.Text = DTZone.Rows(8).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(8).Item("zone_status"), BtnZoneI)

        BtnZoneJ.Text = DTZone.Rows(9).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(9).Item("zone_status"), BtnZoneJ)

        BtnZoneK.Text = DTZone.Rows(10).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(10).Item("zone_status"), BtnZoneK)

        BtnZoneL.Text = DTZone.Rows(11).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(11).Item("zone_status"), BtnZoneL)

        BtnZoneM.Text = DTZone.Rows(12).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(12).Item("zone_status"), BtnZoneM)

        BtnZoneN.Text = DTZone.Rows(13).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(13).Item("zone_status"), BtnZoneN)

        BtnZoneO.Text = DTZone.Rows(14).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(14).Item("zone_status"), BtnZoneO)

        BtnZoneP.Text = DTZone.Rows(15).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(15).Item("zone_status"), BtnZoneP)

        BtnZoneQ.Text = DTZone.Rows(16).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(16).Item("zone_status"), BtnZoneQ)

        BtnZoneR.Text = DTZone.Rows(17).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(17).Item("zone_status"), BtnZoneR)

        BtnZoneS.Text = DTZone.Rows(18).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(18).Item("zone_status"), BtnZoneS)

        BtnZoneT.Text = DTZone.Rows(19).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(19).Item("zone_status"), BtnZoneT)

        BtnZoneU.Text = DTZone.Rows(20).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(20).Item("zone_status"), BtnZoneU)

        BtnZoneV.Text = DTZone.Rows(21).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(21).Item("zone_status"), BtnZoneV)

        BtnZoneW.Text = DTZone.Rows(22).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(22).Item("zone_status"), BtnZoneW)

        BtnZoneX.Text = DTZone.Rows(23).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(23).Item("zone_status"), BtnZoneX)

        BtnZoneY.Text = DTZone.Rows(23).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(24).Item("zone_status"), BtnZoneY)

        BtnZoneZ.Text = DTZone.Rows(24).Item("zone_displaytext").ToString
        Load_Zone_Setting(DTZone.Rows(25).Item("zone_status"), BtnZoneZ)
    End Sub
#End Region
    Private Sub BtnZoneA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneA.Click
        My.Settings.CurrentZone = "A"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneB.Click
        My.Settings.CurrentZone = "B"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneC.Click
        My.Settings.CurrentZone = "C"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneD.Click
        My.Settings.CurrentZone = "D"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneE.Click
        My.Settings.CurrentZone = "E"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneF.Click

        My.Settings.CurrentZone = "F"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneG.Click
        My.Settings.CurrentZone = "G"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneH.Click
        My.Settings.CurrentZone = "H"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneI.Click
        My.Settings.CurrentZone = "I"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneJ.Click
        My.Settings.CurrentZone = "J"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneK.Click
        My.Settings.CurrentZone = "K"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneL.Click
        My.Settings.CurrentZone = "K"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneM.Click
        My.Settings.CurrentZone = "M"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub BtnZoneN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneN.Click
        My.Settings.CurrentZone = "N"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneO.Click
        My.Settings.CurrentZone = "O"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneP.Click
        My.Settings.CurrentZone = "P"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneQ.Click
        My.Settings.CurrentZone = "Q"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneR.Click
        My.Settings.CurrentZone = "R"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneS.Click
        My.Settings.CurrentZone = "S"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneT.Click
        My.Settings.CurrentZone = "T"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneU.Click
        My.Settings.CurrentZone = "U"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneV.Click
        My.Settings.CurrentZone = "V"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmZones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.CurrentZone = "None" Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub
    Private Sub frmZones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Zone_Caption()
        My.Settings.CurrentZone = "None"
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Dispose()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub BtnZoneW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneW.Click
        My.Settings.CurrentZone = "W"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneX.Click
        My.Settings.CurrentZone = "X"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneY.Click
        My.Settings.CurrentZone = "Y"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnZoneZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoneZ.Click
        My.Settings.CurrentZone = "Z"
        My.Settings.TotalZoneTable = MyZone.Get_ZoneTable(My.Settings.CurrentZone)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub GroupControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupControl1.Paint

    End Sub
End Class