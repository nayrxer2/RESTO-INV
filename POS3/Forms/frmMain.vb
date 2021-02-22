Imports System.Data.SqlClient
Public Class frmMain
    Private _ucTitle As New ucTitle
    Private _ucInventoryPage As New ucInventoryPage

    'Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    Me.WindowState = FormWindowState.Maximized
    '    frmMain.Controls.Add(_ucTitle)
    '    _ucTitle.Dock = DockStyle.Top
    '    'scForm.Panel2.Controls.Add(_ucInventoryPage)
    '    '_ucInventoryPage.Dock = DockStyle.Fill

    '    MyPCName = System.Net.Dns.GetHostName

    '    modInventory.getStoreSettings()
    'End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Controls.Add(_ucTitle)
        _ucTitle.Dock = DockStyle.Top
        _ucTitle.lblTitle.Text = "Coffeebreak Intl Inventory System"

        _ucInventoryPage.Dock = DockStyle.Fill
        'scForm.Panel2.Controls.Add(_ucInventoryPage)
        '_ucInventoryPage.Dock = DockStyle.Fill

        MyPCName = System.Net.Dns.GetHostName

        modInventory.getStoreSettings()
    End Sub
End Class
