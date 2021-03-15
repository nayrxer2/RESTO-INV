Public Class popUpdateEnd
    Dim _ucTitle As New ucTitle
    Dim _ucInventory As New ucInventory
    Public itemCode As String

    Private Sub popCreateInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        _ucTitle.Dock = DockStyle.Top
        pnlUpdateEnd.Controls.Add(_ucTitle)
        txtEndW.Enabled = False
        txtEndF.Enabled = False
        txtEndX.Enabled = False
        itemCode = lblItemCodeNum.Text
        If txtStart.Text > "0" Then
            getUnitRatio(itemCode)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Dim EndW As Single
    Dim EndF As Single
    Dim EndX As Single
    Dim firstStart As Single
    Dim remarks As String
    Dim EndT As Single
    Dim unitRatio As Decimal

    Dim RatioW = 0
    Dim RatioF = 0
    Dim RatioX = 0
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim invID As Integer = Convert.ToInt32(lblInvNumberNum.Text)
        Try
            firstStart = Convert.ToSingle(txtStart.Text)
            EndW = Convert.ToSingle(txtEndW.Text)
            EndF = Convert.ToSingle(txtEndF.Text)
            EndX = Convert.ToSingle(txtEndX.Text)
            remarks = txtRemarks.Text
            getUnitRatio(itemCode)

            EndT = (EndW * RatioW) + (EndF * RatioF) + (EndX * RatioX)
            txtStart.Text = EndT

            Dim cls As New clsInvDetails
            cls.FLDInvEndW = EndW
            cls.FLDInvEndF = EndF
            cls.FLDInvEndE = EndX
            cls.FLDInvEndT = EndT
            cls.FLDStart = firstStart
            cls.FLDRemarks = remarks
            If cls.updateInvDetails(itemCode, invID) Then
                DialogResult = Windows.Forms.DialogResult.OK
                MessageBox.Show("You've updated ending sucessfully!")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message + "btn confirm")
        End Try
        'clsD.updateInvDetails(lblItemCodeNum.Text, lblInvNumberNum.Text)
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
                    txtEndW.Enabled = True
                Case "F"
                    unitRatio = (From u In arrItemUnit
                                 Where u.FLDItemCode = ItemCode And u.FLDUnitAssign = "F"
                                 Select u.FLDUnitRatio).Single
                    RatioF = unitRatio
                    txtEndF.Enabled = True
                Case "X"
                    unitRatio = (From u In arrItemUnit
                                 Where u.FLDItemCode = ItemCode And u.FLDUnitAssign = "X"
                                 Select u.FLDUnitRatio).Single
                    RatioX = unitRatio
                    txtEndX.Enabled = True
            End Select
        Next
    End Sub

    Private Sub txtStart_TextChanged(sender As Object, e As EventArgs) Handles txtStart.TextChanged
        If txtStart.Text > "0" Then
            getUnitRatio(itemCode)
        ElseIf txtStart.Text <= "0" Then
            txtEndX.Enabled = False
            txtEndW.Enabled = False
            txtEndF.Enabled = False
        End If
    End Sub
End Class