Imports System
Imports System.IO
Imports Ionic.Zip
Public Class Form1
#Region "dims"
    Dim mcpath As String
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
    Private Sub SetFilePathBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetFilePathBtn.Click
        setfilepath()
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        tempfiledelete()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MCFilePath()
        tempfilecrate()
    End Sub
    Private Sub InstallBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallBtn.Click
        MsgBox("working please wait")
        openjar()
        download()
        'closejar()
        install()
        MsgBox("done")
    End Sub
    Private Sub ShowLogBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLogBtn.Click
        log.Show()
    End Sub
#End Region
#Region "subs/functions"
    Sub MCFilePath()
        mcpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        mcpath = mcpath.Remove(0, 6)
        pathL = mcpath.Length()
        mcpath = "C:\Users\" + GetUserName + "\AppData\Roaming\.minecraft"
    End Sub
    Sub setfilepath()
        MineCraftFileLocation.SelectedPath = mcpath
        If MineCraftFileLocation.ShowDialog = Windows.Forms.DialogResult.OK Then
            mcpath = MineCraftFileLocation.SelectedPath.ToString
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
        Dim ziploc As String
        Dim zipsave As String
        Dim saveloc As String
        If IO.File.Exists(tempFiles & "mage.txt") = False Then
            My.Computer.Network.DownloadFile("http://mage-tech.org/pack/mage.txt", "C:\DNS-Temp\mage.txt")
        Else
            Try
                IO.File.Delete(tempFiles & "mage.txt")
                My.Computer.Network.DownloadFile("http://mage-tech.org/pack/mage.txt", tempFiles & "mage.txt")
            Catch ex As Exception
                log.Log1.Items.Add("Exception: " & ex.ToString)
            End Try
        End If
        If System.IO.File.Exists(downloadlist) = True Then
            Dim objReader As New System.IO.StreamReader(downloadlist)
            Do While objReader.Peek() <> -1
                location = objReader.ReadLine()
                name = objReader.ReadLine()
                zipYN = objReader.ReadLine()
                saveloc = objReader.ReadLine()
                zipYN = zipYN.Trim
                saveloc.Trim()
                zipsave = tempFiles & saveloc & name
                If zipYN = "no" Then
                    Try
                        My.Computer.Network.DownloadFile(location, zipsave)
                        MsgBox("file downloaded")
                    Catch ex As Exception
                        log.Log1.Items.Add("Exception: " & ex.ToString)
                        MsgBox(ex.ToString)
                    End Try
                ElseIf zipYN = "yes" Then
                    Try
                        My.Computer.Network.DownloadFile(location, zipsave)
                        ziploc = tempFiles & saveloc & name
                        If unzip(ziploc, tempFiles & saveloc) Then
                            If IO.File.Exists(ziploc) Then
                                IO.File.Delete(ziploc)
                            End If
                            MsgBox("file downloaded and unziped")
                        Else
                            log.Log1.Items.Add("Error in Unziping file " & ziploc)
                            MsgBox("Could not unZip " & name)
                        End If
                    Catch ex As Exception
                        log.Log1.Items.Add("Exception: " & ex.ToString)
                        MsgBox(ex.ToString)
                    End Try
                End If
            Loop
            objReader.Dispose()
        Else
            log.Log1.Items.Add("Download List missing: " & downloadlist)
        End If
    End Sub
    Sub tempfilecrate()
        If IO.Directory.Exists("C:\DNS-Temp") = False Then
            IO.Directory.CreateDirectory("C:\DNS-Temp")
            Select Case IO.Directory.Exists(tempFiles & "mods") Or IO.Directory.Exists(tempFiles & "config") _
                Or IO.Directory.Exists(tempFiles & "coremods") Or IO.Directory.Exists(tempFiles & "toJar")
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
    Function unzip(ByVal ziplocation As String, ByVal endfile As String) As Boolean
        Try
            Using zip As ZipFile = ZipFile.Read(ziplocation)
                Dim entry As ZipEntry
                For Each entry In zip
                    entry.Extract(endfile, ExtractExistingFileAction.OverwriteSilently)
                    '' Sleep a little because it's really fast
                    System.Threading.Thread.Sleep(20)
                Next
            End Using
            Return True
        Catch ex1 As Exception
            log.Log1.Items.Add("Exception in unzip: " & ex1.ToString)
            Return False
        End Try
    End Function
    Sub install()
        IO.File.Delete(tempFiles & "mage.txt")
        CopyDirectory(tempFiles, mcpath)
    End Sub
    Sub CopyDirectory(ByVal SourcePath As String, ByVal DestPath As String, Optional ByVal Overwrite As Boolean = False)
        Dim SourceDir As DirectoryInfo = New DirectoryInfo(SourcePath)
        Dim DestDir As DirectoryInfo = New DirectoryInfo(DestPath)
        If SourceDir.Exists Then
            If Not DestDir.Parent.Exists Then
                log.Log1.Items.Add("Destination directory does not exist: " + DestDir.Parent.FullName)
            End If
            If Not DestDir.Exists Then
                DestDir.Create()
            End If
            Dim ChildFile As FileInfo
            For Each ChildFile In SourceDir.GetFiles()
                If Overwrite Then
                    ChildFile.CopyTo(Path.Combine(DestDir.FullName, ChildFile.Name), True)
                Else
                    If Not File.Exists(Path.Combine(DestDir.FullName, ChildFile.Name)) Then
                        ChildFile.CopyTo(Path.Combine(DestDir.FullName, ChildFile.Name), False)
                    End If
                End If
            Next
            Dim SubDir As DirectoryInfo
            For Each SubDir In SourceDir.GetDirectories()
                CopyDirectory(SubDir.FullName, Path.Combine(DestDir.FullName, _
                    SubDir.Name), Overwrite)
            Next
        Else
            log.Log1.Items.Add("Source directory does not exist: " + SourceDir.FullName)
        End If
    End Sub
    Sub openjar()
        IO.File.Move(mcpath & "\bin\minecraft.jar", tempFiles & "toJar/mc.zip")
        unzip(tempFiles & "toJar/mc.zip", tempFiles & "toJar")
        IO.Directory.Delete(tempFiles & "toJar/META-INF", True)
        MsgBox("minecraft unziped")
    End Sub
    Sub closejar()
        rezip(tempFiles & "toJar", "minecraft.jar")
        MsgBox("minecraft reziped")
    End Sub
    Sub rezip(ByVal zipDirectory As String, ByVal fileName As String)
        Using zip As ZipFile = New ZipFile
            zip.AddDirectory(zipDirectory)
            zip.Save(fileName)
        End Using
    End Sub
#End Region
End Class