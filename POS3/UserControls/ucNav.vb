
Imports System.IO
Imports System.Drawing
Public Class ucNav
    Dim _ucInventory As New ucInventory

    Private Sub ucNav_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''--location of each button
        'Dim intLeft As Integer = 0
        'Dim intTop As Integer = 0
        ''--size of each button
        'Dim intWidth As Integer = 100
        'Dim intHeight As Integer = 50
        ''--loop 
        'For Each liInv In listOfInv
        '    '--to right width
        '    If intLeft >= Me.Width - intWidth Then
        '        '--new line
        '        intLeft = 0
        '        intTop += 45
        '    End If

        '    Dim _ucMenuItemBtn As New ucMenuItemBtn
        '    _ucMenuItemBtn.Left = intLeft
        '    _ucMenuItemBtn.Top = intTop

        '    _ucMenuItemBtn.Button1.Text = liInv
        '    _ucMenuItemBtn.Button1.Name = "btn"

        '    Me.Controls.Add(_ucMenuItemBtn)
        '    '--move to next button to right
        '    intLeft += intWidth + 5
        '    For Each btn In _ucMenuItemBtn.Controls.OfType(Of Button)
        '        AddHandler _ucMenuItemBtn.Button1.Click, AddressOf _ucMenuItemBtn.Button1_Click
        '    Next
        'Next

        'Dim imgList As New System.Windows.Forms.ImageList()
        'imgList.ImageSize = New Size(24, 24)
        'Dim imgIndex(1) As Image


        'Dim imgPath = System.Drawing.Image.FromFile("F:\Gimotea\MISIcon.png")
        'imgList.Images.Add(imgIndex(1))

        'lvInvInfo.Dock = DockStyle.Fill
        'lvInvInfo.View = View.Tile
        'lvInvInfo.FullRowSelect = True
        'lvInvInfo.ForeColor = Color.Gray
        'modInventory.loadInvInfo(lvInvInfo)
        'lvInvInfo.Sorting = SortOrder.Ascending

    End Sub

    Private Sub lvInvInfo_DoubleClick(sender As Object, e As EventArgs)
        Dim uc As UserControl = Nothing
        Dim dgvInventory = New DataGridView
        uc = New ucInventory
        uc.Dock = DockStyle.Fill
        frmMain.scMain.Panel2.Controls.Clear()
        frmMain.scMain.Panel2.Controls.Add(uc)
    End Sub
End Class
