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

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim uc As New ucInventoryPage

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
                MessageBox.Show("Successfully created!")

                'frmMain.loadInvInfo()
                Me.Close()
            Else
                MessageBox.Show("")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        uc.loadInvInfo()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class