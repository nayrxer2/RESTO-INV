Imports System.Data.SqlClient
Public Class popCreateNewInventory

    Public _ucTitle As New ucTitle
    Public _ucInventory As ucInventory
    Public _ucIp As New ucInventoryPage
    Public _ucLogin As New ucLogin

    Private Sub popCreateNewInventory_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToParent()
        Dim _arrInvInfo = (From linvInfo
                               In arrInvInfo Order By linvInfo.FLDInvID Descending
                               Select linvInfo.FLDInvRef).First + 1

            txtInvNumber.Text = CStr(_arrInvInfo)

            Dim dateId = (From l In arrInvInfo
                          Order By l.FLDInvID Descending
                          Select l.FLDDateIDEnd).First + 1

            txtDateIDStart.Text = dateId
        txtDateIDEnd.Text = dateId
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
                        .FLDDateIDStart = txtDateIDStart.Text,
                        .FLDDateIDEnd = txtDateIDEnd.Text,
                        .FLDStoreID = storeID
                    }   '.FLDDtTmStart = Date.Now,.FLDDtTmEnd = CStr(dtpDateEnd.Value.Date),


            If _clsInvInfo.createInventory() Then
                DialogResult = Windows.Forms.DialogResult.OK
                MessageBox.Show("Successfully created!")
                Me.Close()
            Else
                MessageBox.Show("Error while creating new inventory")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class