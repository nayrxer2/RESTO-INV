Imports System.Data.SqlClient
Public Class ucLogin
    Public _ucNav As New ucNav
    'Public _ucTitle As New ucTitle

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim uname As String = txtUsername.Text
        Dim pwd As String = txtPassword.Text

        If modGeneral.authentication(uname, pwd) = True Then
            '----3/24/2021
            Dim cls As New clsAuthLogs With {
                .FLDStoreID = "",
                .FLDDateID = "",
                .FLDShiftID = "",
                .FLDTerminal = "",
                .FLDInvoiceNumber = "",
                .FLDALDateTime = "",
                .FLDUsername = "",
                .FLDALAction = "",
                .FLDALReason = ""
            }

            modGeneral.authLog()
            '----3/24/2021
            frmPopup.DialogResult = DialogResult.OK
            frmPopup.Close()
            For Each a In Me.Controls
                If TypeOf a Is TextBox Then
                    a.text = Nothing
                End If
            Next
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
        End If
    End Sub

    Public Function getUserList(tb As TextBox)
        Try
            Dim list = (From user In arrUser Select user.FLDUserName).ToArray
            tb.AutoCompleteCustomSource.AddRange(list)

        Catch ex As Exception
            MessageBox.Show("Something went wrong" + ex.Message)
        End Try
    End Function

    Private Sub ucLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        getUserList(txtUsername)

        Dim uc As New ucTitle
        uc.Dock = DockStyle.Top
        uc.lblTitle.Text = ""
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        frmPopup.DialogResult = DialogResult.Cancel
        frmPopup.Close()
    End Sub
End Class
