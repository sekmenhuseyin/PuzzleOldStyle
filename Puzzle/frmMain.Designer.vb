<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsmiRotate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiLevel5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiLevel4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiShowHint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHowtoPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAboutMe = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.fdOpen = New System.Windows.Forms.OpenFileDialog()
        Me.tsmiLevel3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiLevel2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmiLevel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiLevel1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PboxSelected = New System.Windows.Forms.PictureBox()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PboxSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 338)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(455, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'tsmiRotate
        '
        Me.tsmiRotate.Name = "tsmiRotate"
        Me.tsmiRotate.Size = New System.Drawing.Size(110, 22)
        Me.tsmiRotate.Text = "Rotate"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(107, 6)
        '
        'tsmiLevel5
        '
        Me.tsmiLevel5.Name = "tsmiLevel5"
        Me.tsmiLevel5.Size = New System.Drawing.Size(110, 22)
        Me.tsmiLevel5.Text = "Level 5"
        '
        'tsmiLevel4
        '
        Me.tsmiLevel4.Name = "tsmiLevel4"
        Me.tsmiLevel4.Size = New System.Drawing.Size(110, 22)
        Me.tsmiLevel4.Text = "Level 4"
        '
        'tsmiShowHint
        '
        Me.tsmiShowHint.Name = "tsmiShowHint"
        Me.tsmiShowHint.Size = New System.Drawing.Size(74, 20)
        Me.tsmiShowHint.Text = "Show Hint"
        '
        'tsmiHelp
        '
        Me.tsmiHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiHowtoPlay, Me.tsmiAboutMe})
        Me.tsmiHelp.Name = "tsmiHelp"
        Me.tsmiHelp.Size = New System.Drawing.Size(44, 20)
        Me.tsmiHelp.Text = "Help"
        '
        'tsmiHowtoPlay
        '
        Me.tsmiHowtoPlay.Name = "tsmiHowtoPlay"
        Me.tsmiHowtoPlay.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.tsmiHowtoPlay.Size = New System.Drawing.Size(157, 22)
        Me.tsmiHowtoPlay.Text = "How to play"
        '
        'tsmiAboutMe
        '
        Me.tsmiAboutMe.Name = "tsmiAboutMe"
        Me.tsmiAboutMe.Size = New System.Drawing.Size(157, 22)
        Me.tsmiAboutMe.Text = "About Puzzle"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'fdOpen
        '
        Me.fdOpen.Title = "Please select a picture"
        '
        'tsmiLevel3
        '
        Me.tsmiLevel3.Name = "tsmiLevel3"
        Me.tsmiLevel3.Size = New System.Drawing.Size(110, 22)
        Me.tsmiLevel3.Text = "Level 3"
        '
        'tsmiLevel2
        '
        Me.tsmiLevel2.Name = "tsmiLevel2"
        Me.tsmiLevel2.Size = New System.Drawing.Size(110, 22)
        Me.tsmiLevel2.Text = "Level 2"
        '
        'tsmiNew
        '
        Me.tsmiNew.Name = "tsmiNew"
        Me.tsmiNew.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.tsmiNew.Size = New System.Drawing.Size(152, 22)
        Me.tsmiNew.Text = "New"
        '
        'tsmiFile
        '
        Me.tsmiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiNew, Me.ToolStripMenuItem1, Me.tsmiExit})
        Me.tsmiFile.Name = "tsmiFile"
        Me.tsmiFile.Size = New System.Drawing.Size(37, 20)
        Me.tsmiFile.Text = "File"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'tsmiExit
        '
        Me.tsmiExit.Name = "tsmiExit"
        Me.tsmiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.tsmiExit.Size = New System.Drawing.Size(152, 22)
        Me.tsmiExit.Text = "Exit"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiFile, Me.tsmiLevel, Me.tsmiShowHint, Me.tsmiHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(455, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmiLevel
        '
        Me.tsmiLevel.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiLevel1, Me.tsmiLevel2, Me.tsmiLevel3, Me.tsmiLevel4, Me.tsmiLevel5, Me.ToolStripMenuItem2, Me.tsmiRotate})
        Me.tsmiLevel.Name = "tsmiLevel"
        Me.tsmiLevel.Size = New System.Drawing.Size(46, 20)
        Me.tsmiLevel.Text = "Level"
        '
        'tsmiLevel1
        '
        Me.tsmiLevel1.Checked = True
        Me.tsmiLevel1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmiLevel1.Name = "tsmiLevel1"
        Me.tsmiLevel1.Size = New System.Drawing.Size(110, 22)
        Me.tsmiLevel1.Text = "Level 1"
        '
        'PboxSelected
        '
        Me.PboxSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PboxSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PboxSelected.Location = New System.Drawing.Point(12, 49)
        Me.PboxSelected.Name = "PboxSelected"
        Me.PboxSelected.Size = New System.Drawing.Size(100, 50)
        Me.PboxSelected.TabIndex = 5
        Me.PboxSelected.TabStop = False
        Me.PboxSelected.Visible = False
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "white.png")
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(455, 360)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PboxSelected)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.ShowIcon = False
        Me.Text = "Puzzle 2"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PboxSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsmiRotate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiLevel5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLevel4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiShowHint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHowtoPlay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAboutMe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents fdOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tsmiLevel3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLevel2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmiLevel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLevel1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PboxSelected As System.Windows.Forms.PictureBox
    Friend WithEvents imageList1 As System.Windows.Forms.ImageList

End Class
