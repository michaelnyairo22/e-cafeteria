Imports System.IO
Imports System.Threading
Public Class ClsLPT
    Sub Print_Barcode(ByVal Barcode As String, Optional ByVal TotalPage As Integer = 1)
        Dim FILE_NAME As String = "C:\Temp\test.txt"
        Dim i As Integer = 1
        Dim aryText(4) As String



        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        objWriter.WriteLine("N")
        For i = 1 To TotalPage
            objWriter.WriteLine("B120,20,0,3,1,2,100,B,""" & Barcode & """")
            objWriter.WriteLine("P1")
        Next

        objWriter.Close()
        '     Thread.Sleep(1000)

        ' Shell("cmd /b COPY 'C:\Temp\test.txt' LPT1", AppWinStyle.Hide)

        File.Copy("C:\Temp\test.txt", "LPT1")
    End Sub
  
End Class
