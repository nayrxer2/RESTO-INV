Imports System.Data.SqlClient
Public Class popCreateNewInventory

    Public _ucTitle As New ucTitle
    Public _ucInventory As ucInventory
    Public _ucIp As New ucInventoryPage

    Private Sub popCreateNewInventory_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtpDateStart.CustomFormat = "MM-dd-yyyy hh:mm:ss tt"
        dtpDateEnd.CustomFormat = "MM-dd-yyyy hh:mm:ss tt"
        'dtpDateStart.Value = Date.Now

        Me.CenterToParent()

        Dim _arrInvInfo = (From linvInfo
                           In arrInvInfo Order By linvInfo.FLDinvID Descending
                           Select linvInfo.FLDInvRef).First + 1

        'txtInvNumber.Text = CStr(_arrInvInfo)
        txtInvRefNum.Text = CStr(_arrInvInfo)


        'Dim arr = getInvInfo()

        'Dim list = (From l In arr
        '            Order By l.FLDinvID Descending
        '            Select l).First

        'Dim invIDstatus = list

        'Dim cls As New clsInvInfo
        'Dim arrcls As List(Of clsInvInfo) = cls.checkStatus()

        'Dim sQuery = From i In arrcls
        '             Where i.FLDInvID = CInt(invIDstatus)
        '             Select i.FLDStatus

    End Sub


    Public Sub loadInvInfo(lvInvInfo As ListView)
        lvInvInfo.BeginUpdate()
        lvInvInfo.Clear()
        '---> insert query to check invstatus posted/not
        Try
            '---retrieves the inventory info from the Array and stores it in a List.
            arrInvInfo = getInvInfo()
            Dim _arrInvInfo = (From i In arrInvInfo
                               Order By i.FLDInventoryNum Descending
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

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Try
            Dim _firstStoreID = (From sSet
                                 In arrStoreSettings
                                 Select sSet.FLDStoreID).First

            Dim storeID As Integer = _firstStoreID

            Dim _clsInvInfo As New clsInvInfo With {
                .FLDInventoryNum = txtInvNumber.Text,
                .FLDInvRef = txtInvRefNum.Text,
                .FLDDelRef = txtDelRefNum.Text,
                .FLDTransRef = txtTransRefNum.Text,
                .FLDRetRef = txtRetRefNum.Text,
                .FLDDtTmStart = CStr(dtpDateStart.Value.Date),
                .FLDDtTmEnd = CStr(dtpDateEnd.Value.Date),
                .FLDDateIDStart = txtDateIDStart.Text,
                .FLDDateIDEnd = txtDateIDEnd.Text,
                .FLDStoreID = storeID
            }

            If _clsInvInfo.createInventory() Then
                DialogResult = Windows.Forms.DialogResult.OK
                MessageBox.Show("Successfully created!")
                Me.Close()
            Else
                MessageBox.Show("")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class