<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucInventoryPage
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lvInvInfo = New System.Windows.Forms.ListView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CreateNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvInvInfo
        '
        Me.lvInvInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvInvInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvInvInfo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvInvInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(117, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.lvInvInfo.FullRowSelect = True
        Me.lvInvInfo.HideSelection = False
        Me.lvInvInfo.Location = New System.Drawing.Point(0, 24)
        Me.lvInvInfo.Name = "lvInvInfo"
        Me.lvInvInfo.Size = New System.Drawing.Size(289, 511)
        Me.lvInvInfo.TabIndex = 4
        Me.lvInvInfo.UseCompatibleStateImageBehavior = False
        Me.lvInvInfo.View = System.Windows.Forms.View.Tile
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateNewToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(289, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CreateNewToolStripMenuItem
        '
        Me.CreateNewToolStripMenuItem.ForeColor = System.Drawing.Color.AliceBlue
        Me.CreateNewToolStripMenuItem.Name = "CreateNewToolStripMenuItem"
        Me.CreateNewToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.CreateNewToolStripMenuItem.Text = "Create New"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.LightGray
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 535)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(869, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'scMain
        '
        Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scMain.Location = New System.Drawing.Point(0, 0)
        Me.scMain.Name = "scMain"
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.Controls.Add(Me.lvInvInfo)
        Me.scMain.Panel1.Controls.Add(Me.MenuStrip1)
        Me.scMain.Size = New System.Drawing.Size(869, 535)
        Me.scMain.SplitterDistance = 289
        Me.scMain.TabIndex = 1
        '
        'ucInventoryPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.scMain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "ucInventoryPage"
        Me.Size = New System.Drawing.Size(869, 557)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel1.PerformLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CreateNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lvInvInfo As ListView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents scMain As SplitContainer
End Class
