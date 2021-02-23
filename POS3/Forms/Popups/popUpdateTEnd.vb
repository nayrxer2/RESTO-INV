Public Class popUpdateEnd
    Dim _ucTitle As New ucTitle
    Dim _ucInventory As New ucInventory
    Private Sub popCreateInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        _ucTitle.Dock = DockStyle.Top
        pnlUpdateEnd.Controls.Add(_ucTitle)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Dim EndW As Integer
    Dim EndF As Integer
    Dim EndE As Integer

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        EndW = txtEndW.Text
        EndF = txtEndF.Text
        EndE = txtEndX.Text

        Dim cls As New clsInvDetails With {
            .FLDInvEndW = EndW,
            .FLDInvEndF = EndF,
            .FLDInvEndE = EndE
            }

        If computeTotalEnding(EndW, EndF, EndE) Then
            MessageBox.Show("YES BITCH")
            modInventory.loadInvDet(_ucInventory.dgvInventory, _ucInventory.tslblInvNumberText.Text, _ucInventory.tscbGName.Text)
            Me.Close()
        End If

        If cls.updateInvDetails() = True Then
            Me.Close()
            modInventory.loadInvDet(_ucInventory.dgvInventory, _ucInventory.tslblInvNumberText.Text, _ucInventory.tscbGName.Text)
        End If
    End Sub

    Public Function computeTotalEnding(EndW, EndF, EndE)
        Dim EndT As Decimal

        EndT = EndW + EndF + EndE

        Return EndT

    End Function
End Class