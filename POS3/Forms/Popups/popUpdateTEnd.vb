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
    Dim EndX As Integer
    Dim itemCode As String
    Dim EndT As Decimal
    Dim unitRatio As Decimal

    Dim RatioW = 0
    Dim RatioF = 0
    Dim RatioX = 0

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        itemCode = lblItemCodeNum.Text

        EndW = txtEndW.Text
        EndF = txtEndF.Text
        EndX = txtEndX.Text

        getUnitRatio(itemCode)

        EndT = (EndW * RatioW) + (EndF * RatioF) + (EndX * RatioX)

        txtEndT.Text = EndT

        'Dim unitRatioW = getUnitRatio("101238", "W")
        'If computeTotalEnding(EndW, EndF, EndE) Then

        '    Dim cls As New clsInvDetails With {
        '    .FLDInvEndW = EndW,
        '    .FLDInvEndF = EndF,
        '    .FLDInvEndE = EndE,
        '    .FLDInvEndT = EndT
        '    }

        '    MessageBox.Show("YES BITCH")
        '    'modInventory.loadInvDet(_ucInventory.dgvInventory, _ucInventory.tslblInvNumberText.Text, _ucInventory.tscbGName.Text)
        '    MessageBox.Show(EndT)
        '    Me.Close()
        'End If

        'If cls.updateInvDetails() = True Then
        '    Me.Close()
        '    modInventory.loadInvDet(_ucInventory.dgvInventory, _ucInventory.tslblInvNumberText.Text, _ucInventory.tscbGName.Text)
        'End If
    End Sub

    Public Sub getUnitRatio(ItemCode As String)
        Dim arrItemUnit = getItemUnit()
        Dim unitRatio

        '---retrieve applicable unit assign
        Dim arrUnitAssign = (From u In arrItemUnit
                             Where u.FLDItemCode = ItemCode
                             Select u)

        '---query each unit assign and store values respectively
        For Each i In arrUnitAssign
            Select Case i.FLDUnitAssign
                Case "W"
                    unitRatio = (From u In arrItemUnit
                                 Where u.FLDItemCode = ItemCode And u.FLDUnitAssign = "W"
                                 Select u.FLDUnitRatio).Single
                    RatioW = unitRatio

                Case "F"
                    unitRatio = (From u In arrItemUnit
                                 Where u.FLDItemCode = ItemCode And u.FLDUnitAssign = "F"
                                 Select u.FLDUnitRatio).Single
                    RatioF = unitRatio
                Case "X"
                    unitRatio = (From u In arrItemUnit
                                 Where u.FLDItemCode = ItemCode And u.FLDUnitAssign = "X"
                                 Select u.FLDUnitRatio).Single
                    RatioX = unitRatio
            End Select
        Next


    End Sub
End Class