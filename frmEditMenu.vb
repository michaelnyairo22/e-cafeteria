Imports System.IO
Public Class frmEditMenu
    Public primary_key As String
    Dim MyMenu As New ClsMenu
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
#Region "Function"
    Sub Load_Data()
        Try

            Dim DR_Menu As DataRow
            DR_Menu = MyMenu.Get_DataRow(primary_key)
            Me.CboGroup.SelectedValue = DR_Menu("menu_group")

            Me.TxtMenuID.Text = DR_Menu("menu_id").ToString
            Me.TxtMenuName.Text = DR_Menu("menu_name").ToString
            Me.TxtComittion.EditValue = DR_Menu("menu_committion")
            Me.TxtDiscout.EditValue = DR_Menu("menu_discount")
            Me.TxtImgPart.Text = DR_Menu("menu_image").ToString
            Me.TxtPrice.EditValue = DR_Menu("menu_price")
            Me.ChkFavmenu.Checked = IIf(DR_Menu("menu_favoriate") = "Y", True, False)
            Me.ChkAutoMenu.Checked = IIf(DR_Menu("menu_auto") = "Y", True, False)
            If Me.TxtImgPart.Text <> "" Then
                Dim bm As New Bitmap(Me.TxtImgPart.Text)
                PicEmp.Image = bm
            End If

        Catch ex As Exception
            With frmDebug
                .lblFormName.Text = Me.Name
                .lblFunctionName.Text = "Load_Data"
                .MemoErr_Description.Text = ex.Message
                .MemoSQL.Text = ""

                ' .MemoCallStack.Text = "CboGroup.SelectedValue  = " & Me.TxtMenuID.Text & vbCrLf & _
                '"TxtMenuID.Text = " & TxtMenuID.Text & vbCrLf & _
                '"TxtMenuName.Text = " & TxtMenuName.Text & vbCrLf & _
                '"TxtComittion.EditValue = " & TxtComittion.EditValue & vbCrLf & _
                '"TxtDiscout.EditValue = " & TxtDiscout.EditValue & vbCrLf & _
                '"TxtPrice.EditValue = " & TxtPrice.EditValue & vbCrLf & _
                '"ChkFavmenu.Checked = " & Me.ChkFavmenu.Checked & vbCrLf
                .ShowDialog()
            End With
        End Try

    End Sub
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
            If Me.TxtMenuName.Text = "" Then
                MsgBox("กรุณากรอกข้อมูลให้ครบถ้วน", MsgBoxStyle.Exclamation)
                Exit Function
            End If
            Validate_Data = True
        Catch ex As Exception

        End Try

    End Function
#End Region

    Private Sub frmEditMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult <> Windows.Forms.DialogResult.OK Then
            If MsgBox("คุณต้องการออกโดยไม่บันทึกการแก้ไขใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub frmEditMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With CboGroup
            Dim DT_Emp As DataTable = MyMenu.Get_GroupDataTable
            .DataSource = DT_Emp
            .DisplayMember = "group_name"
            .ValueMember = "group_id"

        End With
        Load_Data()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If MsgBox("คุณต้องการยืนยันการปรับปรุงใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการปรับปรุง") = MsgBoxResult.No Then Exit Sub
        If Me.TxtImgPart.Text <> "" Then Copy_Image2Server()
        MyMenu.Update_Menu(Me.TxtMenuName.Text, Me.TxtPrice.EditValue, Me.TxtDiscout.EditValue, TxtComittion.EditValue, Me.CboGroup.SelectedValue, IIf(ChkFavmenu.Checked = True, "Y", "N"), Me.TxtImgPart.Text, primary_key, IIf(Me.ChkAutoMenu.Checked = True, "Y", "N"))
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        Try
            With OpenFileDialog1
                .Title = "Open"
                .FileName = ""
                .Filter = "JPEG Files (*.jpg)|*.jpg"
                If .ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

                Me.TxtImgPart.Text = .FileName
                Me.PicEmp.LoadAsync(.FileName)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub BtnCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Frmcapture.StrItemName = Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & Now.Hour & Now.Minute & Now.Second & ".jpg"
        Frmcapture.ShowDialog()
        If Frmcapture.ImagePart = "" Then Exit Sub
        'Me.TxtImgpart.Text = Frmcapture.MyCapturepart
        Me.TxtImgPart.Text = Frmcapture.sfdImage.FileName
        Dim bm As New Bitmap(Me.TxtImgPart.Text)
        PicEmp.Image = bm
        Frmcapture.Dispose()
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