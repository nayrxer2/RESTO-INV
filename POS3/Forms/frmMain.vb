Imports System.Data.SqlClient
Public Class frmMain
    Private _ucNav As New ucNav
    Private _ucInventory As New ucInventory
    Public _ucTitle As New ucTitle

    Public Sub loadInvInfo()
        Try
            arrInvInfo = getInvInfo()

            Dim _arrInvInfo = (From i In arrInvInfo
                               Order By i.FLDInventoryNum Descending
                               Select i.FLDinvID, i.FLDInventoryNum, i.FLDInvRef, i.FLDDelRef,
                                      i.FLDTransRef, i.FLDRetRef, i.FLDDtTmStart,
                                      i.FLDDtTmEnd, i.FLDDateIDStart, i.FLDDateIDEnd
                                      ).ToList()

            lvInvInfo.BeginUpdate()
            lvInvInfo.Clear()
            For Each i In _arrInvInfo
                Dim oItem As New ListViewItem
                With oItem
                    .ImageKey = "MISIcon.png"
                    .Tag = i.FLDinvID
                    .Text = "Inv ID: " & i.FLDinvID
                    .SubItems.Add("Date : " & i.FLDDtTmStart.ToString("yyyy MMM dd"))
                    .SubItems.Add("Inv Ref #: " & i.FLDInvRef)
                    lvInvInfo.Items.Add(oItem)
                End With
            Next

            lvInvInfo.TileSize = New Size(150, 55)
            '--to add with property in listview
            'If lvInvInfo.Items.Count > 0 Then
            lvInvInfo.Columns.Add(250)
            lvInvInfo.Columns.Add(250)
            lvInvInfo.Columns.Add(250)
            'End If

            lvInvInfo.EndUpdate()
        Catch ex As Exception
            MsgBox(ex.Message + " " + "loadInvInfo")
        End Try
    End Sub

    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Controls.Add(_ucTitle)

        scMain.FixedPanel = FixedPanel.Panel1
        scMain.SplitterDistance = 190
        'scMain.Panel1.Controls.Add(_ucNav)

        lvInvInfo.Dock = DockStyle.Fill
        lvInvInfo.View = View.Tile
        lvInvInfo.FullRowSelect = True
        lvInvInfo.ForeColor = Color.Gray

        loadInvInfo()

        lvInvInfo.Sorting = SortOrder.Ascending

        MyPCName = System.Net.Dns.GetHostName

        modInventory.getStoreSettings()
    End Sub

    Private Sub lvInvInfo_DoubleClick(sender As Object, e As EventArgs) Handles lvInvInfo.DoubleClick
        _ucInventory.dgvInventory.Columns.Clear()
        _ucInventory.tslblInvNumberText.Text = lvInvInfo.FocusedItem.Tag
        _ucInventory.dgvInventory.Refresh()

        modInventory.loadInvDet(_ucInventory.dgvInventory, lvInvInfo.FocusedItem.Tag, _ucInventory.tscbGName.Text)

        _ucInventory.dgvHeaderText()

        scMain.Panel2.Controls.Add(_ucInventory)
    End Sub

    Private Sub CreateNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateNewToolStripMenuItem.Click
        Using frm As New popCreateNewInventory
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        loadInvInfo()
    End Sub
End Class
