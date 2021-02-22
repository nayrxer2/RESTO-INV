Public Class frmPopup
    Private _ucTitle As New ucTitle
    Private _ucLogin As New ucLogin

    Private _ucInventory As New ucInventory
    Private Sub frmPopup_Load(sender As Object, e As EventArgs) Handles Me.Load
        '_ucTitle.Dock = DockStyle.Top
        _ucLogin.Dock = DockStyle.Fill

        'Me.Controls.Add(_ucTitle)
        Me.Controls.Add(_ucLogin)

        Me.CenterToParent()
    End Sub
End Class