Public Class log

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Log1.Items.Clear()
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK And SaveFileDialog1.CheckFileExists Then
                Dim myCoolWriter As New IO.StreamWriter(SaveFileDialog1.FileName)
                For Each coolItem In Log1.Items
                    myCoolWriter.WriteLine(coolItem)
                Next
                myCoolWriter.Close()
            End If
        Catch ex As Exception
            MsgBox("Exception: " & ex.ToString)
        End Try
    End Sub
End Class