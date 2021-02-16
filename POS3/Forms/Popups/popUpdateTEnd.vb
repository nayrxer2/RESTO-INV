Public Class popUpdateEnd
    Dim _ucTitle As New ucTitle
    Dim _ucInventory As ucInventory
    Private Sub popCreateInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        _ucTitle.Dock = DockStyle.Top
        pnlUpdateEnd.Controls.Add(_ucTitle)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim cls As New clsInvDetails With {
            .FLDInvEndW = txtEndW.Text,
            .FLDInvEndF = txtEndF.Text,
            .FLDInvEndE = txtEndX.Text,
            .FLDInvEndT = txtEndT.Text
            }

        If cls.updateInvDetails() = True Then
            Me.Close()
            modInventory.loadInvDet(_ucInventory.dgvInventory, _ucInventory.tslblInvNumberText.Text, _ucInventory.tscbGName.Text)
        End If
    End Sub
End Class