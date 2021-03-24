Imports System.Data.SqlClient

Public Class ucMenuItemBtn
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub


    'Public Sub Button1_Click(sender As Object, e As EventArgs)
    '    Dim uc As UserControl = Nothing
    '    Dim dgvInventory = New DataGridView
    '    For Each ctrl As Control In Me.Controls
    '        If ctrl.GetType Is GetType(Button) Then
    '            Dim ctr = DirectCast(sender, Button)
    '            Select Case ctr.Text
    '                Case "Return"
    '                    MsgBox(ctr.Text)
    '                Case "Delivery"
    '                    MsgBox(ctr.Text)
    '                Case "Ordering"
    '                    MsgBox(ctr.Text)
    '                Case "Receive"
    '                    MsgBox(ctr.Text)
    '                Case "Transfer"
    '                    uc = New ucItemDetails
    '                Case "Inventory"
    '                    uc = New ucInventory
    '            End Select
    '        End If
    '        If uc Is Nothing Then Exit Sub

    '        uc.Dock = DockStyle.Fill
    '        frmMain.Panel2.Controls.Clear()
    '        frmMain.Panel2.Controls.Add(uc)

    '    Next
    'End Sub

    'Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
    '    Me.OnClick(e)
    'End Sub
End Class
