Imports System.Data.SqlClient
Public Class ucLogin
    Public _ucNav As New ucNav
    Public _ucTitle As New ucTitle

    Dim uname As String
    Dim upwd As String
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        uname = txtUsername.Text
        upwd = txtPassword.Text

        If authentication() = True Then
            frmPopup.Hide()
            frmMain.Show()
        Else
            MessageBox.Show("Incorrect User")
        End If
    End Sub

    Public Function authentication() As Boolean
        Dim userList = (From user In arrUser
                        Where user.FLDUserName = uname And user.FLDUPassword = upwd
                        Select user.FLDUID).ToList.Count
        If userList > 0 Then
            Return True
        End If
    End Function

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
    End Sub
End Class
