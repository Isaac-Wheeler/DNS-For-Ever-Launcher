Imports System
Imports System.IO
Imports Ionic.Zip
Imports System.Net
Public Class Form1
#Region "dims"
    Dim mcpath As String
    Dim pathL As Short
    Dim tempFiles As String = "C:\DNS-Temp\"
    Dim WithEvents WC As New WebClient
    Declare Function GetUserName Lib "advapi32.dll" Alias _
 "GetUserNameA" (ByVal lpBuffer As String, _
 ByRef nSize As Integer) As Integer
    Dim curentLocation As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
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
        Tasklbl.Text = ("")
        MCFilePath()
        tempfilecrate()
    End Sub
    Private Sub InstallBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallBtn.Click
        Tasklbl.Text = "download started"
        download()
        MainPrB.Value = 1
        Tasklbl.Text = "adding Files to minecraft.jar"
        addToMc()
        MainPrB.Value = 2
        Tasklbl.Text = "adding other files"
        install()
        MainPrB.Value = 3
        MsgBox("installed")
    End Sub
    Private Sub ShowLogBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLogBtn.Click
        log.Show()
    End Sub
#End Region
#Region "subs/functions"
    Sub MCFilePath()
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
        Try
            Dim downloadlist As String = tempFiles & "mage.txt"
            Dim location As String
            Dim name As String
            Dim zipYN As String
            Dim ziploc As String
            Dim zipsave As String
            Dim saveloc As String
            Dim adfly As String
            If IO.File.Exists(tempFiles & "mage.txt") = False Then
                My.Computer.Network.DownloadFile("http://mage-tech.org/pack/mage.txt", "C:\DNS-Temp\mage.txt")
            Else
                IO.File.Delete(tempFiles & "mage.txt")
                My.Computer.Network.DownloadFile("http://mage-tech.org/pack/mage.txt", tempFiles & "mage.txt")
            End If
            If System.IO.File.Exists(downloadlist) = True Then
                Dim objReader As New System.IO.StreamReader(downloadlist)
                Do While objReader.Peek() <> -1
                    location = objReader.ReadLine()
                    name = objReader.ReadLine()
                    zipYN = objReader.ReadLine()
                    saveloc = objReader.ReadLine()
                    adfly = objReader.ReadLine()
                    adfly.Trim()
                    zipYN.Trim()
                    saveloc.Trim()
                    zipsave = tempFiles & saveloc & name
                    Tasklbl.Text = "donwloading: " & name
                    If adfly = "no" Then
                        If zipYN = "no" Then
                            WC.DownloadFile(New Uri(location), zipsave)
                        ElseIf zipYN = "yes" Then
                            WC.DownloadFile(New Uri(location), zipsave)
                            ziploc = tempFiles & saveloc & name
                            If unzip(ziploc, tempFiles & saveloc) Then
                                If IO.File.Exists(ziploc) Then
                                    IO.File.Delete(ziploc)
                                End If
                            Else
                                log.Log1.Items.Add("Error in Unziping file " & ziploc)
                                MsgBox("Could not unZip " & name)
                            End If
                        End If
                    Else
                        Dim rel As Boolean
                        While rel = True
                            Dim run As Short
                            Dim msgboxText As String = "Need to Download: " & name & vbNewLine _
                                                       & "Click OK to download Cancel to abort install" & vbNewLine _
                                                       & "please save in the downloads folder at " & curentLocation & vbNewLine _
                                                       & "this will show up " & run & " more times"
                            Dim msgboxResult As MsgBoxResult
                            msgboxResult = MsgBox(msgboxText, MsgBoxStyle.OkCancel, "file download")
                            If msgboxResult = Microsoft.VisualBasic.MsgBoxResult.Ok Then
                                System.Diagnostics.Process.Start(location)
                                If IO.File.Exists(curentLocation & "/Downloads/" & name) Then
                                    IO.File.Move(curentLocation & "/Downloads/" & name, zipsave)
                                    If zipYN = "no" Then
                                        rel = False
                                    ElseIf zipYN = "yes" Then
                                        ziploc = tempFiles & saveloc & name
                                        If unzip(ziploc, tempFiles & saveloc) Then
                                            If IO.File.Exists(ziploc) Then
                                                IO.File.Delete(ziploc)
                                            End If
                                        Else
                                            log.Log1.Items.Add("Error in Unziping file " & ziploc)
                                            MsgBox("Could not unZip " & name)
                                        End If
                                        rel = False
                                    End If

                                End If
                                Else
                                    If run < 4 Then
                                        run += 1
                                    Else
                                        Me.Close()
                                    End If
                                End If
                        End While
                    End If
                Loop
                objReader.Dispose()
                WC.Dispose()
            Else
                log.Log1.Items.Add("Download List missing: " & downloadlist)
            End If
        Catch ex As Exception
            log.Log1.Items.Add("Exception: " & ex.ToString)
        End Try
    End Sub
    Sub tempfilecrate()
        Try
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
            If IO.Directory.Exists(curentLocation.ToString & "Downloads") = False Then
                IO.Directory.CreateDirectory(curentLocation.ToString & "Downloads")
            End If
        Catch ex As Exception
            log.Log1.Items.Add("error in makeing TempDirectorys: " & ex.ToString)
        End Try

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
    Sub addToMc()
        Try
            Using zip As ZipFile = ZipFile.Read(mcpath & "\bin\minecraft.jar")
                zip.AddDirectory(tempFiles & "toJar")
                zip.Save(mcpath & "\bin\minecraft.jar")
            End Using
            IO.Directory.Delete(tempFiles & "toJar")
        Catch ex As Exception
            log.Log1.Items.Add("Exception in Adding files to minecraft: " & ex.ToString)
        End Try
    End Sub
    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        SubPgB.Value = e.ProgressPercentage
    End Sub
#End Region
End Class