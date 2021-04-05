Imports System.Data.SqlClient
Public Class ucLogin
    Public _ucNav As New ucNav
    'Public _ucTitle As New ucTitle

    Public Property ucheader As String
        Get
            Return lblHeading.Text
        End Get
        Set(value As String)
            lblHeading.Text = value
        End Set
    End Property
    Public Property ucsubheader As String
        Get
            Return lblSubheading.Text
        End Get
        Set(value As String)
            lblSubheading.Text = value
        End Set
    End Property
    Public _ucAction As String
    Property ucAction As String
        Get
            Return _ucAction
        End Get
        Set(value As String)
            _ucAction = value
        End Set
    End Property
    Private Sub ucLogin_Load(sender As Object, e As EventArgs) Handles Me.Load

        getUserList(txtUsername)

            Dim uc As New ucTitle
            uc.Dock = DockStyle.Top
            uc.lblTitle.Text = ""
            lblHeading.Tag = ucAction
        lblSubheading.Text = ucsubheader
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim uname As String = txtUsername.Text
        Dim pwd As String = txtPassword.Text

        If modGeneral.authentication(uname, pwd) = True Then
            Dim logAction As String = Nothing
            Select Case _ucAction
                Case "Login"
                    'uc = New ucLogin
                    If authentication(uname, pwd) = True Then
                        logAction = "Loging in inventory"
                    Else
                        logAction = "Trying to login in inventory"
                    End If
                Case "Create"
                    'uc = New ucLogin
                    If authentication(uname, pwd) = True Then
                        logAction = "Created new inventory sheet"
                    Else
                        logAction = "Trying to create inventory sheet"
                    End If
                Case "Post"
                    'uc = New ucLogin
                    If authentication(uname, pwd) = True Then
                        logAction = "Posted inventory sheet"
                    Else
                        logAction = "Trying to post inventory sheet"
                    End If
            End Select

            '----3/24/2021
            Dim cls As New clsAuthLogs
            cls.FLDStoreID = storeID
            cls.FLDDateID = 0
            cls.FLDShiftID = 0
            cls.FLDTerminal = 0
            cls.FLDInvoiceNumber = 0
            cls.FLDUsername = txtUsername.Text
            cls.FLDALAction = logAction
            cls.FLDALReason = "N/A"
            cls.FLDALCMeal = 0
            'cls.authLog()
            '----3/24/2021
            If cls.authLog = True Then
                frmPopup.DialogResult = DialogResult.OK
                frmPopup.Close()
            End If
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        frmPopup.DialogResult = DialogResult.Cancel
        frmPopup.Close()
        For Each a In Me.Controls
            If TypeOf a Is TextBox Then
                a.text = Nothing
            End If
        Next
    End Sub
End Class
