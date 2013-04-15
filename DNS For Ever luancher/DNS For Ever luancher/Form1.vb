Imports System
Imports System.IO
Imports Ionic.Zip

Public Class Form1
#Region "dims"
    Dim path As String
    Dim pathL As Short
    Dim tempFiles As String = "C:\DNS-Temp\"
    Declare Function GetUserName Lib "advapi32.dll" Alias _
 "GetUserNameA" (ByVal lpBuffer As String, _
 ByRef nSize As Integer) As Integer
#End Region
#Region "does stuff"
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("http://dns.mage-tech.org/")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        setfilepath()
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        tempfiledelete()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MCFilePath()
        tempfilecrate()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        download()
    End Sub
#End Region
#Region "subs/functions"
    Sub MCFilePath()
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        path = path.Remove(0, 6)
        pathL = path.Length()
        path = "C:\Users\" + GetUserName + "\AppData\Roaming\.minecraft"
    End Sub
    Sub setfilepath()
        MineCraftFileLocation.SelectedPath = path
        'MineCraftFileLocation.ShowDialog()
        If MineCraftFileLocation.ShowDialog = Windows.Forms.DialogResult.OK Then
            path = MineCraftFileLocation.SelectedPath.ToString
        End If
    End Sub
    Public Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Chr(0)))
    End Function
    Sub download()
        Dim downloadlist As String = tempFiles & "mage.txt"
        Dim location As String
        Dim name As String
        Dim zipYN As String
        Dim ziplocation As String
        If IO.File.Exists(tempFiles & "mage.txt") = False Then
            My.Computer.Network.DownloadFile("http://mage-tech.org/mage.txt", "C:\DNS-Temp\mage.txt")
        Else
            Try
                IO.File.Delete(tempFiles & "mage.txt")
                My.Computer.Network.DownloadFile("http://mage-tech.org/mage.txt", tempFiles & "mage.txt")
            Catch ex As Exception
                log.Log1.Items.Add("Exception: " & ex.ToString)
            End Try
        End If
        If System.IO.File.Exists(downloadlist) = True Then
            Dim objReader As New System.IO.StreamReader(downloadlist)
            Do While objReader.Peek() <> -1
                location = objReader.ReadLine() & vbNewLine
                name = objReader.ReadLine() & vbNewLine
                zipYN = objReader.ReadLine() & vbNewLine
                zipYN = zipYN.Trim
                If zipYN = "no" Then
                    Try
                        My.Computer.Network.DownloadFile(location, tempFiles & name)
                        MsgBox("file downloaded")
                    Catch ex As Exception
                        log.Log1.Items.Add("Exception: " & ex.ToString)
                    End Try
                ElseIf zipYN = "yes" Then
                    Try
                        My.Computer.Network.DownloadFile(location, tempFiles & name)
                        ziplocation = tempFiles & name
                        unzip(ziplocation, ziplocation)
                        If IO.File.Exists(ziplocation) Then
                            IO.Directory.Delete(ziplocation)
                        End If
                        MsgBox("file downloaded and unziped")
                    Catch ex As Exception
                        log.Log1.Items.Add("Exception: " & ex.ToString)
                    End Try

                End If
            Loop
        Else
            log.Log1.Items.Add("Download List missing: " & downloadlist)
        End If
    End Sub
    Sub tempfilecrate()
        If IO.Directory.Exists("C:\DNS-Temp") = False Then
            IO.Directory.CreateDirectory("C:\DNS-Temp")
            Select Case IO.Directory.Exists(tempFiles & "mods")
                Case Is = False
                    IO.Directory.CreateDirectory(tempFiles & "mods")
                    IO.Directory.CreateDirectory(tempFiles & "config")
                    IO.Directory.CreateDirectory(tempFiles & "coremods")
                    IO.Directory.CreateDirectory(tempFiles & "toJar")
            End Select
        End If
    End Sub
    Sub tempfiledelete()
        If IO.Directory.Exists("C:\DNS-Temp") Then
            Try
                IO.Directory.Delete("C:\DNS-Temp", True)
            Catch ex As Exception
                MsgBox("Exception: " & ex.ToString)
            End Try
        End If
    End Sub
    Sub unzip(ByVal ziplocation As String, ByVal endfile As String)
        Try
            Using zip As ZipFile = ZipFile.Read(ziplocation)
                Dim entry As ZipEntry
                For Each entry In zip
                    entry.Extract(endfile, ExtractExistingFileAction.OverwriteSilently)
                    '' Sleep a little because it's really fast
                    System.Threading.Thread.Sleep(20)
                Next
            End Using
        Catch ex1 As Exception
            log.Log1.Items.Add("Exception in unzip: " & ex1.ToString)
        End Try
    End Sub
#End Region

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        log.Show()
    End Sub
End Class