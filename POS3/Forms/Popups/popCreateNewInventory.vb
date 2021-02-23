Imports System.Data.SqlClient
Public Class popCreateNewInventory

    Public _ucTitle As New ucTitle
    Public _ucInventory As ucInventory

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
                MessageBox.Show("YES you made it!")
                'frmMain.loadInvInfo()
                Me.Close()
            Else
                MessageBox.Show("sala ubra mo")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class