Public Class Form1
    Dim path As String
    Dim pathL As Short

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("http://dns.mage-tech.org/")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MCFilePath()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Debug() 'commit out to turn off debug
    End Sub

    Declare Function GetUserName Lib "advapi32.dll" Alias _
 "GetUserNameA" (ByVal lpBuffer As String, _
 ByRef nSize As Integer) As Integer

    Sub MCFilePath()
        path = System.IO.Path.GetDirectoryName( _
        System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        path = path.Remove(0, 6)
        pathL = path.Length()
        path = "C:\Users\" + GetUserName + "\AppData\Roaming\.minecraft"
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

End Class



