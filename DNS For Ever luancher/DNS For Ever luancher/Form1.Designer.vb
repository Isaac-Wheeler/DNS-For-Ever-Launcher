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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SetFilePathBtn = New System.Windows.Forms.Button()
        Me.MineCraftFileLocation = New System.Windows.Forms.FolderBrowserDialog()
        Me.InstallBtn = New System.Windows.Forms.Button()
        Me.ShowLogBtn = New System.Windows.Forms.Button()
        Me.MainPrB = New System.Windows.Forms.ProgressBar()
        Me.MainPrglbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tasklbl = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Sublbl = New System.Windows.Forms.Label()
        Me.SubPgB = New System.Windows.Forms.ProgressBar()
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
        'ShowLogBtn
        '
        Me.ShowLogBtn.Location = New System.Drawing.Point(79, 344)
        Me.ShowLogBtn.Name = "ShowLogBtn"
        Me.ShowLogBtn.Size = New System.Drawing.Size(61, 41)
        Me.ShowLogBtn.TabIndex = 3
        Me.ShowLogBtn.Text = "Show Log"
        Me.ShowLogBtn.UseVisualStyleBackColor = True
        '
        'MainPrB
        '
        Me.MainPrB.Location = New System.Drawing.Point(237, 349)
        Me.MainPrB.Maximum = 3
        Me.MainPrB.Name = "MainPrB"
        Me.MainPrB.Size = New System.Drawing.Size(311, 20)
        Me.MainPrB.TabIndex = 4
        '
        'MainPrglbl
        '
        Me.MainPrglbl.AutoSize = True
        Me.MainPrglbl.Location = New System.Drawing.Point(154, 351)
        Me.MainPrglbl.Name = "MainPrglbl"
        Me.MainPrglbl.Size = New System.Drawing.Size(77, 13)
        Me.MainPrglbl.TabIndex = 5
        Me.MainPrglbl.Text = "Main Progress:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(155, 400)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Task:"
        '
        'Tasklbl
        '
        Me.Tasklbl.AutoSize = True
        Me.Tasklbl.Location = New System.Drawing.Point(195, 400)
        Me.Tasklbl.Name = "Tasklbl"
        Me.Tasklbl.Size = New System.Drawing.Size(39, 13)
        Me.Tasklbl.TabIndex = 9
        Me.Tasklbl.Text = "Label2"
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
        'Sublbl
        '
        Me.Sublbl.AutoSize = True
        Me.Sublbl.Location = New System.Drawing.Point(155, 376)
        Me.Sublbl.Name = "Sublbl"
        Me.Sublbl.Size = New System.Drawing.Size(70, 13)
        Me.Sublbl.TabIndex = 7
        Me.Sublbl.Text = "Sub Progress"
        '
        'SubPgB
        '
        Me.SubPgB.Location = New System.Drawing.Point(237, 375)
        Me.SubPgB.Name = "SubPgB"
        Me.SubPgB.Size = New System.Drawing.Size(310, 20)
        Me.SubPgB.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 431)
        Me.Controls.Add(Me.Tasklbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Sublbl)
        Me.Controls.Add(Me.SubPgB)
        Me.Controls.Add(Me.MainPrglbl)
        Me.Controls.Add(Me.MainPrB)
        Me.Controls.Add(Me.ShowLogBtn)
        Me.Controls.Add(Me.InstallBtn)
        Me.Controls.Add(Me.SetFilePathBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "DNS Tech Pack Luancher"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SetFilePathBtn As System.Windows.Forms.Button
    Friend WithEvents MineCraftFileLocation As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents InstallBtn As System.Windows.Forms.Button
    Friend WithEvents ShowLogBtn As System.Windows.Forms.Button
    Friend WithEvents MainPrB As System.Windows.Forms.ProgressBar
    Friend WithEvents MainPrglbl As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tasklbl As System.Windows.Forms.Label
    Friend WithEvents Sublbl As System.Windows.Forms.Label
    Friend WithEvents SubPgB As System.Windows.Forms.ProgressBar

End Class
