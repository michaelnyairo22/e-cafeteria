﻿Imports System.Windows.Forms

Public Class DlgCurrentSQL

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgCurrentSQL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MemoCurrentSQL.Text = ClsSQLhelper.CurrMySql


    End Sub
End Class
