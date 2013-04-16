<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SetFilePathBtn = New System.Windows.Forms.Button()
        Me.MineCraftFileLocation = New System.Windows.Forms.FolderBrowserDialog()
        Me.InstallBtn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ShowLogBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SetFilePathBtn
        '
        Me.SetFilePathBtn.Location = New System.Drawing.Point(554, 5)
        Me.SetFilePathBtn.Name = "SetFilePathBtn"
        Me.SetFilePathBtn.Size = New System.Drawing.Size(61, 40)
        Me.SetFilePathBtn.TabIndex = 1
        Me.SetFilePathBtn.Text = "set file path"
        Me.SetFilePathBtn.UseVisualStyleBackColor = True
        '
        'InstallBtn
        '
        Me.InstallBtn.Location = New System.Drawing.Point(12, 349)
        Me.InstallBtn.Name = "InstallBtn"
        Me.InstallBtn.Size = New System.Drawing.Size(61, 30)
        Me.InstallBtn.TabIndex = 2
        Me.InstallBtn.Text = "Install"
        Me.InstallBtn.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.DNS_For_Ever_luancher.My.Resources.Resources.DNS_For_Ever
        Me.PictureBox1.Location = New System.Drawing.Point(7, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(541, 333)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ShowLogBtn
        '
        Me.ShowLogBtn.Location = New System.Drawing.Point(79, 344)
        Me.ShowLogBtn.Name = "ShowLogBtn"
        Me.ShowLogBtn.Size = New System.Drawing.Size(61, 41)
        Me.ShowLogBtn.TabIndex = 3
        Me.ShowLogBtn.Text = "Show Log"
        Me.ShowLogBtn.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(175, 374)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 408)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ShowLogBtn)
        Me.Controls.Add(Me.InstallBtn)
        Me.Controls.Add(Me.SetFilePathBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SetFilePathBtn As System.Windows.Forms.Button
    Friend WithEvents MineCraftFileLocation As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents InstallBtn As System.Windows.Forms.Button
    Friend WithEvents ShowLogBtn As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
