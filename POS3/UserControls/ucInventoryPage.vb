Public Class ucInventoryPage
    Private _ucInventory As New ucInventory

    Private Sub ucInventoryPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadInvInfo()
        scMain.FixedPanel = FixedPanel.Panel1
        scMain.SplitterDistance = 190
        lvInvInfo.Sorting = SortOrder.Ascending
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
        '---opens an empty form
        Using frm As New popCreateNewInventory
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        loadInvInfo()
    End Sub

#Region "Functions"

    '---loads the Inventory Information to the listview
    Public Sub loadInvInfo()
        Try
            '---retrieves the inventory info from the Array and stores it in a List
            arrInvInfo = getInvInfo()
            Dim _arrInvInfo = (From i In arrInvInfo
                               Order By i.FLDInventoryNum Descending
                               Select i.FLDinvID, i.FLDInventoryNum, i.FLDInvRef, i.FLDDelRef,
                                      i.FLDTransRef, i.FLDRetRef, i.FLDDtTmStart,
                                      i.FLDDtTmEnd, i.FLDDateIDStart, i.FLDDateIDEnd
                                      ).ToList()

            '---displays each item from the Array List to the ListViewItem
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



#End Region


End Class
