Imports System.IO
Public Class frmEditEmp
    Dim MyEmployee As New ClsEmployee
    Public primary_key As Integer
    Dim Strsql As String
    Dim _mysql As New ClsSQLhelper
#Region "Function"
    Sub Load_Data()
        Try

            Dim DR_Emp As DataRow
            DR_Emp = MyEmployee.Get_DataRow(primary_key)
            Me.CboTitle.SelectedValue = DR_Emp("emp_title")

            Me.TxtName.Text = DR_Emp("emp_firstname").ToString

            Me.TxtLname.Text = DR_Emp("emp_lname").ToString
            Me.TxtNickName.Text = DR_Emp("nickname").ToString
            Me.TxtImgPart.Text = DR_Emp("emp_image").ToString
            Me.DtpBirthDate.DateTime = DR_Emp("emp_birthday")
            Me.DtpHireDate.DateTime = DR_Emp("emp_hiredate")
            Me.ChSex.EditValue = DR_Emp("emp_sex")
            Me.ChStatus.EditValue = DR_Emp("emp_status")
        Catch ex As Exception
            MsgBox(ex.Message)
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
            If Me.TxtName.Text = "" And Me.TxtLname.Text = "" And Me.TxtNickName.Text = "" Then
                MsgBox("กรุณากรอกข้อมูลให้ครบถ้วน", MsgBoxStyle.Exclamation)
                Exit Function
            End If
            Validate_Data = True
        Catch ex As Exception

        End Try

    End Function
#End Region
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If MsgBox("คุณต้องการยืนยันการปรับปรุงใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ยืนยันการปรับปรุง") = MsgBoxResult.No Then Exit Sub
        If Me.TxtImgPart.Text <> "" Then Copy_Image2Server()
        MyEmployee.Update_Employee(primary_key, Me.CboTitle.Text, Me.TxtName.Text, Me.TxtLname.Text, ChSex.EditValue, Me.DtpBirthDate.DateTime, Me.DtpHireDate.DateTime, Me.TxtPosition.Text, ChStatus.EditValue, Me.TxtImgPart.Text, Me.TxtNickName.Text, Me.TxtPosition.Text)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmEditEmp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult <> Windows.Forms.DialogResult.OK Then
            If MsgBox("คุณต้องการออกโดยไม่บันทึกการแก้ไขใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmEditEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With CboTitle
            Dim DT_Emp As DataTable = MyEmployee.Get_Title_Table
            .DataSource = DT_Emp
            .DisplayMember = "pname"
            .ValueMember = "pname"

        End With
        Load_Data()
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
End Class