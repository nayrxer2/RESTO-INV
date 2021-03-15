Public Class ucInventoryPage
    Private _ucInventory As New ucInventory

    Private Sub ucInventoryPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadInvInfo()

        '----fixed size for splitcontainer
        scMain.FixedPanel = FixedPanel.Panel1
        scMain.SplitterDistance = 190
        lvInvInfo.Sorting = SortOrder.Ascending
    End Sub

    Private Sub lvInvInfo_DoubleClick(sender As Object, e As EventArgs) Handles lvInvInfo.DoubleClick
        _ucInventory.dgvInventory.Columns.Clear()

        _ucInventory.tslblInvNumberText.Text = lvInvInfo.FocusedItem.Tag
        _ucInventory.dgvInventory.Refresh()
        '----load inventory sheet detail to datagridview
        modInventory.loadInvDet(_ucInventory.dgvInventory, lvInvInfo.FocusedItem.Tag, _ucInventory.tscbGName.Text)

        _ucInventory.dgvHeaderText()

        scMain.Panel2.Controls.Add(_ucInventory)
    End Sub

    Private Sub CreateNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateNewToolStripMenuItem.Click
        Dim arr = getInvInfo()

        Dim list = (From l In arr
                    Order By l.FLDinvID Descending
                    Select l).First

        Dim invIDstatus As Integer = list.FLDinvID

        Dim cls As New clsInvInfo
        Dim arrcls As List(Of clsInvInfo) = cls.checkStatus()

        Dim sQuery = (From i In arrcls
                      Where i.FLDInvID = invIDstatus
                      Select i.FLDInvID).Count

        'If sQuery <> 0 Then
        '---opens an empty form
        Using frm As New popCreateNewInventory
            frm.ShowDialog()
        End Using
        ' Else
        'MessageBox.Show("There's still an open inventory sheet, you cannot proceed!")
        'End If

    End Sub


#Region "Functions"

    '---loads the Inventory Information to the listview
    Public Sub loadInvInfo()
        lvInvInfo.BeginUpdate()
        lvInvInfo.Clear()
        '---> insert query to check invstatus posted/not
        Try
            '---retrieves the inventory info from the Array and stores it in a List.
            Dim arrInvInfo = getInvInfo()
            Dim _arrInvInfo = (From i In arrInvInfo
                               Order By i.FLDDateIDStart Descending
                               Select i)

            '---displays each item from the Array List to the ListViewItem
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
            '----manipulating size of listview
            lvInvInfo.TileSize = New Size(150, 55)
            lvInvInfo.Columns.Add(250)
            lvInvInfo.Columns.Add(250)
            lvInvInfo.Columns.Add(250)
        Catch ex As Exception
            MsgBox(ex.Message + " " + "loadInvInfo")
        End Try
        lvInvInfo.EndUpdate()
    End Sub
#End Region
End Class
