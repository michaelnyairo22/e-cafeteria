Imports MySql.Data.MySqlClient
Public Class frmDBSetting
    Private MyClsConn As ClsSQLhelper

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Dispose()
    End Sub
    Private Sub frmDBSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If My.Settings.ChkDB = True Then Me.CheckBox1.Checked = False Else Me.CheckBox1.Checked = True
            LoadDefaultConfig()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Try


            Dim Crypto As New Crypto.Crypto
            If MsgBox("�س��ͧ�����䢤�� connection ���������", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If Me.TxtDatabase.Text.Trim.Equals("") Then
                MsgBox("��س������Ͱҹ������", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If Me.TxtUser.Text.Trim.Equals("") Then
                MsgBox("��س������ͼ����", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If Me.TxtPassword.Text.Trim.Equals("") Then
                MsgBox("��س�������ʼ�ҹ", MsgBoxStyle.Exclamation)
            End If

            If Me.TxtPort.Text = "" Then
                MsgBox("��س�����͵", MsgBoxStyle.Exclamation)
            ElseIf IsNumeric(Me.TxtPort.Text) = False Then
                MsgBox("��س�����繵���Ţ��ҹ��", MsgBoxStyle.Exclamation)
            End If

            If Me.TxtHost.Text.Trim.Equals("") Then
                MsgBox("��س������� Server", MsgBoxStyle.Exclamation)
            End If
            '(LoadDefaultConfig())
            If TestConnectionResult() = False Then
                MsgBox("��ҷ�����������ö�Դ��Ͱҹ�������� ��سҡ�͡�����������ա����", MsgBoxStyle.Information, "�������ö��Ѻ��ا��õ�駤����")
                Exit Sub
            Else
                'If (ClsSQLhelper.MySQLDatabase = Me.TxtDatabase.Text) And (ClsSQLhelper.MySQLUser = Me.TxtUser.Text) And (ClsSQLhelper.MySQLPassword = Me.TxtPassword.Text) And (ClsSQLhelper.MySQLPort = Me.TxtPort.Text) And (ClsSQLhelper.MySQLServer = Me.TxtHost.Text) Then
                '    MsgBox("�ѹ�֡��������", MsgBoxStyle.Information)
                'Else

                'End If
                ClsSQLhelper.MySQLDatabase = Me.TxtDatabase.Text
                ClsSQLhelper.MySQLUser = Me.TxtUser.Text
                ClsSQLhelper.MySQLPassword = Crypto.Encrypt(Me.TxtPassword.Text, "sys11266")
                ClsSQLhelper.MySQLPort = Me.TxtPort.Text
                ClsSQLhelper.MySQLServer = Me.TxtHost.Text
                If Me.CheckBox1.Checked = True Then My.Settings.ChkDB = False Else My.Settings.ChkDB = True

                MsgBox("�ѹ�֡�������� ��سһԴ�����Դ������������������������ҷ��������", MsgBoxStyle.Information)
            End If

            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Sub LoadDefaultConfig()
        Try
            Dim Crypto As New Crypto.Crypto
            Me.TxtDatabase.Text = ClsSQLhelper.MySQLDatabase
            Me.TxtUser.Text = ClsSQLhelper.MySQLUser
            ' If Me.TxtPassword.Text <> "" Then
            Me.TxtPassword.Text = Crypto.Decrypt(ClsSQLhelper.MySQLPassword, "sys11266")
            'End If
            Me.TxtPort.Text = ClsSQLhelper.MySQLPort
            Me.TxtHost.Text = ClsSQLhelper.MySQLServer
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click

        TestConnectionResult()

    End Sub

    Private Sub TxtHost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHost.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                TestConnectionResult()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                TestConnectionResult()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub TxtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassword.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                TestConnectionResult()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub TxtDatabase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDatabase.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                TestConnectionResult()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub TxtPort_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPort.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                TestConnectionResult()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Function TestConnectionResult() As Boolean

        Try
            ' MyClsConn.TestConnectionResult()
            TestConnectionResult = False
            Dim TestConnstr As String = "server=" & TxtHost.Text & ";user=" & TxtUser.Text & ";database=" & TxtDatabase.Text & ";port=" & TxtPort.Text & ";password=" & TxtPassword.Text & ";"
            Dim TestConn As New MySqlConnection
            Try
                TestConn.ConnectionString = TestConnstr
                TestConn.Open()

                MessageBox.Show("�Դ��Ͱҹ�����������")
                TestConnectionResult = True
                TestConn.Close()
            Catch myerror As MySqlException
                TestConnectionResult = False
                MsgBox(Err.Number & " : " & myerror.Message, MsgBoxStyle.Critical, "�������ö�Դ��Ͱҹ��������")
            Finally
                TestConn.Dispose()
            End Try
        Catch ex As Exception
            MsgBox(Err.Number & " : " & ex.Message.ToString)
        End Try
    End Function
End Class