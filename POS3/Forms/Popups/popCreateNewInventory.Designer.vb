<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class popCreateNewInventory
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
        Me.txtInvNumber = New System.Windows.Forms.TextBox()
        Me.txtInvRefNum = New System.Windows.Forms.TextBox()
        Me.txtDelRefNum = New System.Windows.Forms.TextBox()
        Me.txtTransRefNum = New System.Windows.Forms.TextBox()
        Me.txtRetRefNum = New System.Windows.Forms.TextBox()
        Me.txtDateIDStart = New System.Windows.Forms.TextBox()
        Me.txtDateIDEnd = New System.Windows.Forms.TextBox()
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblInvNum = New System.Windows.Forms.Label()
        Me.lblInvRefNum = New System.Windows.Forms.Label()
        Me.lblDelRefNum = New System.Windows.Forms.Label()
        Me.lblTransRefNum = New System.Windows.Forms.Label()
        Me.lblRetRefNum = New System.Windows.Forms.Label()
        Me.lblDateStart = New System.Windows.Forms.Label()
        Me.lblDateEnd = New System.Windows.Forms.Label()
        Me.lblDateIDStart = New System.Windows.Forms.Label()
        Me.lblDateIDEnd = New System.Windows.Forms.Label()
        Me.pnlCreateInv = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCreateInv.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtInvNumber
        '
        Me.txtInvNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvNumber.Location = New System.Drawing.Point(166, 58)
        Me.txtInvNumber.Name = "txtInvNumber"
        Me.txtInvNumber.Size = New System.Drawing.Size(134, 21)
        Me.txtInvNumber.TabIndex = 0
        '
        'txtInvRefNum
        '
        Me.txtInvRefNum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvRefNum.Location = New System.Drawing.Point(166, 84)
        Me.txtInvRefNum.Name = "txtInvRefNum"
        Me.txtInvRefNum.Size = New System.Drawing.Size(134, 21)
        Me.txtInvRefNum.TabIndex = 1
        '
        'txtDelRefNum
        '
        Me.txtDelRefNum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelRefNum.Location = New System.Drawing.Point(166, 110)
        Me.txtDelRefNum.Name = "txtDelRefNum"
        Me.txtDelRefNum.Size = New System.Drawing.Size(134, 21)
        Me.txtDelRefNum.TabIndex = 2
        '
        'txtTransRefNum
        '
        Me.txtTransRefNum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransRefNum.Location = New System.Drawing.Point(166, 136)
        Me.txtTransRefNum.Name = "txtTransRefNum"
        Me.txtTransRefNum.Size = New System.Drawing.Size(134, 21)
        Me.txtTransRefNum.TabIndex = 3
        '
        'txtRetRefNum
        '
        Me.txtRetRefNum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetRefNum.Location = New System.Drawing.Point(166, 162)
        Me.txtRetRefNum.Name = "txtRetRefNum"
        Me.txtRetRefNum.Size = New System.Drawing.Size(134, 21)
        Me.txtRetRefNum.TabIndex = 4
        '
        'txtDateIDStart
        '
        Me.txtDateIDStart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateIDStart.Location = New System.Drawing.Point(166, 267)
        Me.txtDateIDStart.Name = "txtDateIDStart"
        Me.txtDateIDStart.Size = New System.Drawing.Size(134, 21)
        Me.txtDateIDStart.TabIndex = 5
        '
        'txtDateIDEnd
        '
        Me.txtDateIDEnd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateIDEnd.Location = New System.Drawing.Point(166, 293)
        Me.txtDateIDEnd.Name = "txtDateIDEnd"
        Me.txtDateIDEnd.Size = New System.Drawing.Size(134, 21)
        Me.txtDateIDEnd.TabIndex = 6
        '
        'dtpDateStart
        '
        Me.dtpDateStart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateStart.Location = New System.Drawing.Point(105, 201)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.Size = New System.Drawing.Size(195, 21)
        Me.dtpDateStart.TabIndex = 7
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateEnd.Location = New System.Drawing.Point(105, 227)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.Size = New System.Drawing.Size(195, 21)
        Me.dtpDateEnd.TabIndex = 8
        '
        'lblInvNum
        '
        Me.lblInvNum.AutoSize = True
        Me.lblInvNum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvNum.Location = New System.Drawing.Point(17, 61)
        Me.lblInvNum.Name = "lblInvNum"
        Me.lblInvNum.Size = New System.Drawing.Size(92, 13)
        Me.lblInvNum.TabIndex = 9
        Me.lblInvNum.Text = "INVENTORY #:"
        '
        'lblInvRefNum
        '
        Me.lblInvRefNum.AutoSize = True
        Me.lblInvRefNum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvRefNum.Location = New System.Drawing.Point(17, 87)
        Me.lblInvRefNum.Name = "lblInvRefNum"
        Me.lblInvRefNum.Size = New System.Drawing.Size(117, 13)
        Me.lblInvRefNum.TabIndex = 10
        Me.lblInvRefNum.Text = "INVENTORY REF #:"
        '
        'lblDelRefNum
        '
        Me.lblDelRefNum.AutoSize = True
        Me.lblDelRefNum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelRefNum.Location = New System.Drawing.Point(17, 113)
        Me.lblDelRefNum.Name = "lblDelRefNum"
        Me.lblDelRefNum.Size = New System.Drawing.Size(107, 13)
        Me.lblDelRefNum.TabIndex = 11
        Me.lblDelRefNum.Text = "DELIVERY REF #:"
        '
        'lblTransRefNum
        '
        Me.lblTransRefNum.AutoSize = True
        Me.lblTransRefNum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransRefNum.Location = New System.Drawing.Point(17, 139)
        Me.lblTransRefNum.Name = "lblTransRefNum"
        Me.lblTransRefNum.Size = New System.Drawing.Size(110, 13)
        Me.lblTransRefNum.TabIndex = 12
        Me.lblTransRefNum.Text = "TRANSFER REF #:"
        '
        'lblRetRefNum
        '
        Me.lblRetRefNum.AutoSize = True
        Me.lblRetRefNum.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetRefNum.Location = New System.Drawing.Point(17, 165)
        Me.lblRetRefNum.Name = "lblRetRefNum"
        Me.lblRetRefNum.Size = New System.Drawing.Size(104, 13)
        Me.lblRetRefNum.TabIndex = 13
        Me.lblRetRefNum.Text = "RETURNS REF #:"
        '
        'lblDateStart
        '
        Me.lblDateStart.AutoSize = True
        Me.lblDateStart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateStart.Location = New System.Drawing.Point(17, 207)
        Me.lblDateStart.Name = "lblDateStart"
        Me.lblDateStart.Size = New System.Drawing.Size(82, 13)
        Me.lblDateStart.TabIndex = 14
        Me.lblDateStart.Text = "DATE START:"
        '
        'lblDateEnd
        '
        Me.lblDateEnd.AutoSize = True
        Me.lblDateEnd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateEnd.Location = New System.Drawing.Point(17, 233)
        Me.lblDateEnd.Name = "lblDateEnd"
        Me.lblDateEnd.Size = New System.Drawing.Size(70, 13)
        Me.lblDateEnd.TabIndex = 15
        Me.lblDateEnd.Text = "DATE END:"
        '
        'lblDateIDStart
        '
        Me.lblDateIDStart.AutoSize = True
        Me.lblDateIDStart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateIDStart.Location = New System.Drawing.Point(17, 270)
        Me.lblDateIDStart.Name = "lblDateIDStart"
        Me.lblDateIDStart.Size = New System.Drawing.Size(100, 13)
        Me.lblDateIDStart.TabIndex = 16
        Me.lblDateIDStart.Text = "DATE ID START:"
        '
        'lblDateIDEnd
        '
        Me.lblDateIDEnd.AutoSize = True
        Me.lblDateIDEnd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateIDEnd.Location = New System.Drawing.Point(17, 296)
        Me.lblDateIDEnd.Name = "lblDateIDEnd"
        Me.lblDateIDEnd.Size = New System.Drawing.Size(88, 13)
        Me.lblDateIDEnd.TabIndex = 17
        Me.lblDateIDEnd.Text = "DATE ID END:"
        '
        'pnlCreateInv
        '
        Me.pnlCreateInv.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlCreateInv.Controls.Add(Me.Label1)
        Me.pnlCreateInv.Controls.Add(Me.btnCancel)
        Me.pnlCreateInv.Controls.Add(Me.btnCreate)
        Me.pnlCreateInv.Controls.Add(Me.txtInvNumber)
        Me.pnlCreateInv.Controls.Add(Me.lblDateIDEnd)
        Me.pnlCreateInv.Controls.Add(Me.txtInvRefNum)
        Me.pnlCreateInv.Controls.Add(Me.lblDateIDStart)
        Me.pnlCreateInv.Controls.Add(Me.txtDelRefNum)
        Me.pnlCreateInv.Controls.Add(Me.lblDateEnd)
        Me.pnlCreateInv.Controls.Add(Me.txtTransRefNum)
        Me.pnlCreateInv.Controls.Add(Me.lblDateStart)
        Me.pnlCreateInv.Controls.Add(Me.txtRetRefNum)
        Me.pnlCreateInv.Controls.Add(Me.lblRetRefNum)
        Me.pnlCreateInv.Controls.Add(Me.txtDateIDStart)
        Me.pnlCreateInv.Controls.Add(Me.lblTransRefNum)
        Me.pnlCreateInv.Controls.Add(Me.txtDateIDEnd)
        Me.pnlCreateInv.Controls.Add(Me.lblDelRefNum)
        Me.pnlCreateInv.Controls.Add(Me.dtpDateStart)
        Me.pnlCreateInv.Controls.Add(Me.lblInvRefNum)
        Me.pnlCreateInv.Controls.Add(Me.dtpDateEnd)
        Me.pnlCreateInv.Controls.Add(Me.lblInvNum)
        Me.pnlCreateInv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCreateInv.Location = New System.Drawing.Point(3, 2)
        Me.pnlCreateInv.Name = "pnlCreateInv"
        Me.pnlCreateInv.Size = New System.Drawing.Size(319, 372)
        Me.pnlCreateInv.TabIndex = 18
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(225, 325)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 28)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.Location = New System.Drawing.Point(144, 325)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 28)
        Me.btnCreate.TabIndex = 18
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Create New Inventory"
        '
        'popCreateNewInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(324, 377)
        Me.Controls.Add(Me.pnlCreateInv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "popCreateNewInventory"
        Me.Text = "popCreateNewInventory"
        Me.pnlCreateInv.ResumeLayout(False)
        Me.pnlCreateInv.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtInvNumber As TextBox
    Friend WithEvents txtInvRefNum As TextBox
    Friend WithEvents txtDelRefNum As TextBox
    Friend WithEvents txtTransRefNum As TextBox
    Friend WithEvents txtRetRefNum As TextBox
    Friend WithEvents txtDateIDStart As TextBox
    Friend WithEvents txtDateIDEnd As TextBox
    Friend WithEvents dtpDateStart As DateTimePicker
    Friend WithEvents dtpDateEnd As DateTimePicker
    Friend WithEvents lblInvNum As Label
    Friend WithEvents lblInvRefNum As Label
    Friend WithEvents lblDelRefNum As Label
    Friend WithEvents lblTransRefNum As Label
    Friend WithEvents lblRetRefNum As Label
    Friend WithEvents lblDateStart As Label
    Friend WithEvents lblDateEnd As Label
    Friend WithEvents lblDateIDStart As Label
    Friend WithEvents lblDateIDEnd As Label
    Friend WithEvents pnlCreateInv As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents Label1 As Label
End Class
