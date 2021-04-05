Public Class ucInventoryPage
    Private _ucInventory As New ucInventory

    Private Sub ucInventoryPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadInvInfo()
        '----fixed size for splitcontainer
        scMain.FixedPanel = FixedPanel.Panel1
        scMain.SplitterDistance = 190

    End Sub

    Private Sub lvInvInfo_DoubleClick(sender As Object, e As EventArgs) Handles lvInvInfo.DoubleClick
        _ucInventory.dgvInventory.Columns.Clear()

        _ucInventory.tslblInvNumberText.Text = lvInvInfo.FocusedItem.Tag
        _ucInventory.dgvInventory.Refresh()
        '----load inventory sheet detail to datagridview
        modInventory.loadInvDet(_ucInventory.dgvInventory, lvInvInfo.FocusedItem.Tag, _ucInventory.tscbGName.Text)

        _ucInventory.dgvHeaderText()


        Dim cls As New clsInvInfo
        Dim arrcls As List(Of clsInvInfo) = cls.checkStatus()
        Dim _arrcls = (From l In arrcls
                       Where l.FLDInvID = lvInvInfo.FocusedItem.Tag
                       Select l.FLDStatus).SingleOrDefault

        If _arrcls <> "POSTED" Then
            _ucInventory.tsbtnPost.Enabled = True
        ElseIf _arrcls = "POSTED" Then
            _ucInventory.tsbtnPost.Enabled = False
        End If


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


        'Using frmAuth As New frmPopup
        'If sQuery <> 0 Then

        'Dim uc As New ucLogin
        'uc.ucheader = "Authentication!"
        'uc.ucsubheader = "Please enter your credentials"
        'uc.ucAction = "Create"
        'uc.Dock = DockStyle.Fill
        'frmPopup.Controls.Add(uc)

        'If frmPopup.ShowDialog() = DialogResult.OK Then
        'frmPopup.Close()
        '---opens an empty form
        Using frm As New popCreateNewInventory
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                loadInvInfo()
                'frmAuth.Close()
            End If
        End Using
        'End If
        ' End Using

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
            arrInvInfo = getInvInfo()
            Dim _arrInvInfo = (From i In arrInvInfo
                               Order By i.FLDInvID Descending
                               Select i)

            '---displays each item from the Array List to the ListViewItem
            For Each i In _arrInvInfo
                Dim oItem As New ListViewItem
                With oItem
                    .ImageKey = "MISIcon.png"
                    .Tag = i.FLDInvID
                    .Text = "Inv ID: " & i.FLDInvID
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

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        loadInvInfo()
    End Sub
#End Region
End Class
