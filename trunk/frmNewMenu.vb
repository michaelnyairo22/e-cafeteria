Imports System.IO
Public Class frmNewMenu
    Dim MyMenu As New ClsMenu
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
#Region "Function"
    Sub Copy_Image2Server()
        Dim StrFilename As String = ""
        Try

            StrFilename = My.Settings.imagepart & "\" & Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & Now.Hour & Now.Minute & Now.Second & ".jpg"

            File.Copy(Me.TxtImgPart.Text, StrFilename, True)
            Dim bm As New Bitmap(Me.TxtImgPart.Text)
            Me.PicEmp.Image = bm
            Me.TxtImgPart.Text = StrFilename
        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "Copy_Image2Server"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = "StrFilename = " & StrFilename
                .ShowDialog()
            End With
        End Try

    End Sub
    Function Validate_Data() As Boolean

        Try
            Validate_Data = False
            If Me.TxtMenuID.Text = "" Or Me.TxtMenuName.Text = "" Then
                MsgBox("กรุณากรอกข้อมูลให้ครบถ้วน", MsgBoxStyle.Exclamation)
                Exit Function
            End If

            Strsql = "Select * from menu where menu_id = '" & Me.TxtMenuID.Text & "'"

            Dim DT_Menu As New DataTable
            DT_Menu = _mysql.GetMYSQLDataTable(Strsql, "menu")

            If DT_Menu.Rows.Count <> 0 Then
                MsgBox("ขออภัยเลขที่ Menu นี้มีอยู่แล้ว", MsgBoxStyle.Exclamation, "คำเตือน")
                Exit Function
            Else
                Strsql = "Select * from menu where menu_name = '" & Me.TxtMenuName.Text & "'"

                DT_Menu = _mysql.GetMYSQLDataTable(Strsql, "menu")

                If DT_Menu.Rows.Count <> 0 Then
                    MsgBox("ขออภัยชื่อ Menu นี้มีอยู่แล้ว", MsgBoxStyle.Exclamation, "คำเตือน")
                    Exit Function
                  
                End If

            End If


            Validate_Data = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
#End Region
    Private Sub frmNewMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With CboGroup
            Dim DT_Menu As DataTable = MyMenu.Get_GroupDataTable

            .DataSource = DT_Menu
            .DisplayMember = "group_name"
            .ValueMember = "group_id"

        End With

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Validate_Data() = False Then Exit Sub
        If MsgBox("คุณต้องการยืนยันการเพิ่มข้อมูลใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการเพิ่มข้อมูล") = MsgBoxResult.No Then Exit Sub
        If Me.TxtImgPart.Text <> "" Then Copy_Image2Server()

        Try
            MyMenu.Insert_Data(Me.TxtMenuID.Text, Me.TxtMenuName.Text, Me.TxtPrice.EditValue, TxtDiscout.EditValue, Me.TxtComittion.EditValue, Me.CboGroup.SelectedValue, IIf(ChkFavmenu.Checked = True, "Y", "N"), Me.TxtImgPart.Text, IIf(Me.ChkAutoMenu.Checked = True, "Y", "N"))

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      
    End Sub




    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        With OpenFileDialog1
            .Title = "Open"
            .FileName = ""
            .Filter = "JPEG Files (*.jpg)|*.jpg"
            If .ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

            Me.TxtImgPart.Text = .FileName
            Me.PicEmp.LoadAsync(.FileName)
        End With
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        PicEmp.Image = Nothing
        Me.TxtImgPart.Text = ""
    End Sub

    Private Sub BtnZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnZoom.Click
        FrmFullSize.PictureEdit1.Image = Me.PicEmp.Image
        FrmFullSize.Show()
    End Sub
End Class