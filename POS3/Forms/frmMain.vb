﻿Imports System.ComponentModel
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
        'Me.Hide()

        'Using frm As New frmPopup
        Dim uc As New ucLogin
        uc.Dock = DockStyle.Fill
        frmPopup.Controls.Add(uc)

        If frmPopup.ShowDialog() = DialogResult.OK Then
            MessageBox.Show("mae Sakto")
            Me.WindowState = FormWindowState.Maximized

            Me.Controls.Add(_ucInventoryPage)
            _ucInventoryPage.Dock = DockStyle.Fill

            Me.Controls.Add(_ucTitle)
            _ucTitle.lblTitle.Text = "Coffeebreak Intl Inventory System"
            _ucTitle.pbTitleImage.ImageLocation = "D:\Projects\RESTO-INV\POS3\Assets\logo.png"

            MyPCName = System.Net.Dns.GetHostName

            modInventory.getStoreSettings()
        ElseIf frmPopup.DialogResult = DialogResult.Cancel Then
            Me.Dispose()
        Else
            MessageBox.Show("There's an error before loading inventory sheet")
        End If
        'End Using
    End Sub

End Class
