Imports System
Imports System.IO

Public Class Form1
    Dim path As String
    Dim pathL As Short

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("http://dns.mage-tech.org/")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        setfilepath()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Debug() 'commit out to turn off debug
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MCFilePath()
    End Sub
    Declare Function GetUserName Lib "advapi32.dll" Alias _
 "GetUserNameA" (ByVal lpBuffer As String, _
 ByRef nSize As Integer) As Integer

    Sub MCFilePath()
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        path = path.Remove(0, 6)
        pathL = path.Length()
        path = "C:\Users\" + GetUserName + "\AppData\Roaming\.minecraft"
    End Sub

    Sub setfilepath()
        MineCraftFileLocation.SelectedPath = path
        MineCraftFileLocation.ShowDialog()
        path = MineCraftFileLocation.SelectedPath.ToString
    End Sub

    Public Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Chr(0)))
    End Function

    Sub Debug()
        MessageBox.Show(path)
        MessageBox.Show(pathL)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        download()
    End Sub

    Sub download()
        Dim downloadlist As String
        Dim location As String
        Dim name As String
        downloadlist = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        downloadlist = downloadlist.Remove(0, 6)
        downloadlist = downloadlist & "\mage.txt"
        If System.IO.File.Exists(downloadlist) = True Then
            Dim objReader As New System.IO.StreamReader(downloadlist)
            Do While objReader.Peek() <> -1
                location = objReader.ReadLine() & vbNewLine
                name = objReader.ReadLine() & vbNewLine
                MsgBox(location)
                MsgBox(name)

                My.Computer.Network.DownloadFile(location, "/" + name)
            Loop
        Else
            MsgBox("File Does Not Exist    " & downloadlist)
        End If



    End Sub



End Class




