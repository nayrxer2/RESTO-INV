<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucInventory
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucInventory))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tscbGName = New System.Windows.Forms.ToolStripComboBox()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.msInventory = New System.Windows.Forms.MenuStrip()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tcInventory = New System.Windows.Forms.TabControl()
        Me.tsMenuInventory = New System.Windows.Forms.ToolStrip()
        Me.tslblInvNumber = New System.Windows.Forms.ToolStripLabel()
        Me.tsbtnPost = New System.Windows.Forms.ToolStripButton()
        Me.tslblInvNumberText = New System.Windows.Forms.ToolStripLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msInventory.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tcInventory.SuspendLayout()
        Me.tsMenuInventory.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "MISIcon.png")
        '
        'GroupToolStripMenuItem
        '
        Me.GroupToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupToolStripMenuItem.Name = "GroupToolStripMenuItem"
        Me.GroupToolStripMenuItem.Size = New System.Drawing.Size(58, 23)
        Me.GroupToolStripMenuItem.Text = "Group :"
        '
        'tscbGName
        '
        Me.tscbGName.Name = "tscbGName"
        Me.tscbGName.Size = New System.Drawing.Size(181, 23)
        '
        'dgvInventory
        '
        Me.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInventory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInventory.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInventory.GridColor = System.Drawing.SystemColors.ControlLight
        Me.dgvInventory.Location = New System.Drawing.Point(3, 30)
        Me.dgvInventory.MultiSelect = False
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventory.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvInventory.Size = New System.Drawing.Size(1300, 526)
        Me.dgvInventory.TabIndex = 3
        '
        'msInventory
        '
        Me.msInventory.BackColor = System.Drawing.Color.WhiteSmoke
        Me.msInventory.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GroupToolStripMenuItem, Me.tscbGName})
        Me.msInventory.Location = New System.Drawing.Point(3, 3)
        Me.msInventory.Name = "msInventory"
        Me.msInventory.Size = New System.Drawing.Size(1300, 27)
        Me.msInventory.TabIndex = 0
        Me.msInventory.Text = "MenuStrip1"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvInventory)
        Me.TabPage1.Controls.Add(Me.msInventory)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1306, 559)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tcInventory
        '
        Me.tcInventory.Controls.Add(Me.TabPage1)
        Me.tcInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcInventory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcInventory.Location = New System.Drawing.Point(0, 0)
        Me.tcInventory.Name = "tcInventory"
        Me.tcInventory.SelectedIndex = 0
        Me.tcInventory.Size = New System.Drawing.Size(1314, 585)
        Me.tcInventory.TabIndex = 5
        '
        'tsMenuInventory
        '
        Me.tsMenuInventory.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.tsMenuInventory.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblInvNumber, Me.tsbtnPost, Me.tslblInvNumberText})
        Me.tsMenuInventory.Location = New System.Drawing.Point(0, 0)
        Me.tsMenuInventory.Name = "tsMenuInventory"
        Me.tsMenuInventory.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.tsMenuInventory.Size = New System.Drawing.Size(1314, 25)
        Me.tsMenuInventory.TabIndex = 6
        Me.tsMenuInventory.Text = "ToolStrip1"
        '
        'tslblInvNumber
        '
        Me.tslblInvNumber.BackColor = System.Drawing.Color.White
        Me.tslblInvNumber.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblInvNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.tslblInvNumber.LinkColor = System.Drawing.Color.White
        Me.tslblInvNumber.Name = "tslblInvNumber"
        Me.tslblInvNumber.Size = New System.Drawing.Size(94, 22)
        Me.tslblInvNumber.Text = "Inventory No:"
        '
        'tsbtnPost
        '
        Me.tsbtnPost.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnPost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnPost.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnPost.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.tsbtnPost.Image = CType(resources.GetObject("tsbtnPost.Image"), System.Drawing.Image)
        Me.tsbtnPost.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnPost.Name = "tsbtnPost"
        Me.tsbtnPost.Size = New System.Drawing.Size(44, 22)
        Me.tsbtnPost.Text = "POST"
        '
        'tslblInvNumberText
        '
        Me.tslblInvNumberText.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblInvNumberText.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.tslblInvNumberText.Name = "tslblInvNumberText"
        Me.tslblInvNumberText.Size = New System.Drawing.Size(39, 22)
        Me.tslblInvNumberText.Text = "0000"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'ucInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Controls.Add(Me.tsMenuInventory)
        Me.Controls.Add(Me.tcInventory)
        Me.Name = "ucInventory"
        Me.Size = New System.Drawing.Size(1314, 585)
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msInventory.ResumeLayout(False)
        Me.msInventory.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.tcInventory.ResumeLayout(False)
        Me.tsMenuInventory.ResumeLayout(False)
        Me.tsMenuInventory.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents GroupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tscbGName As ToolStripComboBox
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents msInventory As MenuStrip
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents tcInventory As TabControl
    Friend WithEvents tsMenuInventory As ToolStrip
    Friend WithEvents tslblInvNumber As ToolStripLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents tsbtnPost As ToolStripButton
    Friend WithEvents tslblInvNumberText As ToolStripLabel
End Class
