
Public Class Frmcapture
    Dim _mysql As New ClsSQLhelper
    Dim Strsql As String
    Public MyCapturepart As String = ""
    Public StrItemName As String
    Public ImagePart As String
    ' Create constant using attend in function of DLL file.

    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Dim iDevice As Integer = 0  ' Normal device ID 
    Dim hHwnd As Integer  ' Handle value to preview window

    ' Declare function from AVI capture DLL.

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
         ByVal lParam As Object) As Integer

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWndParent As Integer, _
        ByVal nID As Integer) As Integer

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean

    ' Connect to the device.
    Private Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0
        Try

            ' Load name of all avialable devices into the lstDevices .

            Do
                '   Get Driver name and version
                bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
                ' If there was a device add device name to the list 
                ' If bReturn Then lstDevices.Items.Add(strName.Trim)
                x += 1
            Loop Until bReturn = False
            If bReturn = False Then
                '    MsgBox("กรุณาตรวจสอบ Webcam ของท่าน", MsgBoxStyle.Critical)
            End If
            OpenPreviewWindow()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' To display the output from a video capture device, you need to create a capture window.

    Private Sub OpenPreviewWindow()
        Try
            Dim iHeight As Integer = picCapture.Height
            Dim iWidth As Integer = picCapture.Width

            ' Open Preview window in picturebox .
            ' Create a child window with capCreateCaptureWindowA so you can display it in a picturebox.

            hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
                480, picCapture.Handle.ToInt32, 0)

            ' Connect to device
            If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then

                ' Set the preview scale
                SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

                ' Set the preview rate in milliseconds
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

                ' Start previewing the image from the camera 
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

                ' Resize window to fit in picturebox 
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height, _
                                       SWP_NOMOVE Or SWP_NOZORDER)
                BtnSave.Enabled = True
            Else
                ' Error connecting to device close window 
                DestroyWindow(hHwnd)
                BtnSave.Enabled = False
            End If
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub ClosePreviewWindow()
        ' Disconnect from device
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

        ' close window 
        DestroyWindow(hHwnd)
    End Sub
    Private Sub picCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCapture.Click

    End Sub

    Private Sub Frmcapture_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDeviceList()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim data As IDataObject
            Dim bmap As Image
            Dim imgJpeg As Image
            ' Copy image to clipboard 
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

            ' Get image from clipboard and convert it to a bitmap 
            data = Clipboard.GetDataObject()
            If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
                'bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
                imgJpeg = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
                'picCapture.Image = bmap
                picCapture.Image = imgJpeg
                ClosePreviewWindow()
                BtnSave.Enabled = False

                sfdImage.InitialDirectory = "My Documents"
                sfdImage.Title = "Save Image file File"
                sfdImage.Filter = "Jpeg Image|*.jpg"
                Dim StrFileName As String = My.Settings.imagepart & "\" & StrItemName & ".jpg"
                If sfdImage.ShowDialog = DialogResult.OK Then

                    ' bmap.Save(sfdImage.FileName, Imaging.ImageFormat.Bmp)
                    imgJpeg.Save(sfdImage.FileName, Imaging.ImageFormat.Jpeg)
                End If
                ImagePart = sfdImage.FileName
                'FrmEditItem.TxtImgpart.Text = sfdImage.FileName
                'Dim bm As New Bitmap(sfdImage.FileName)
                'FrmEditItem.PictureBox1.Image = bm
                Me.Hide()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Dispose(True)
        'FrmEditItem.TxtImgpart.Text = sfdImage.FileName
    End Sub
End Class