Imports System.Data.SqlClient
Public Class ucInventory

    Public Sub dgvHeaderText()
        dgvInventory.DefaultCellStyle.ForeColor = Color.Black
        dgvInventory.Columns("FLDItemCode").HeaderText = "ItemCode"
        dgvInventory.Columns("FLDItemName").HeaderText = "Item"
        dgvInventory.Columns("FLDStart").HeaderText = "Start"
        'dgvInventory.Columns("FLDDeliver").HeaderText = "Del"
        'dgvInventory.Columns("FLDTransfer").HeaderText = "InOut"
        'dgvInventory.Columns("FLDReturn").HeaderText = "Ret"
        'dgvInventory.Columns("FLDProdUsed").HeaderText = "P Used"
        'dgvInventory.Columns("FLDProdMade").HeaderText = "P Made"
        ' dgvInventory.Columns("FLDAdjustment").HeaderText = "Adj"
        dgvInventory.Columns("FLDInvEndW").HeaderText = "End W"
        dgvInventory.Columns("FLDInvEndF").HeaderText = "End F"
        dgvInventory.Columns("FLDInvEndE").HeaderText = "End X"
        dgvInventory.Columns("FLDInvEndT").HeaderText = "T End"
        'dgvInventory.Columns("FLDInvUsage").HeaderText = "I Usage"
        'dgvInventory.Columns("FLDPOSUsage").HeaderText = "P Usage"
        'dgvInventory.Columns("FLDMealUsage").HeaderText = "Meals"
        'dgvInventory.Columns("FLDVariance").HeaderText = "Short"
        'dgvInventory.Columns("FLDUnitPrice").HeaderText = "Amount"
        dgvInventory.Columns("FLDRemarks").HeaderText = "Remarks"
        dgvInventory.Columns("FLDInvEndT").DefaultCellStyle.BackColor = Color.LightGray

        dgvInventory.RowHeadersVisible = True
    End Sub

    Private Sub ucInventory_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dock = DockStyle.Fill

        dgvInventory.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
        dgvInventory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvInventory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvInventory.RowHeadersVisible = False
        loadGName()

        tcInventory.TabPages(0).Text = "Inventory Sheet"
        '----insert function here to disable cell content click
    End Sub

    '-----get groupname to combobox
    Public Sub loadGName()
        Try
            Dim _arrGName = (From l In arrInvDetail
                             Order By l.FLDGroupName Ascending
                             Select l.FLDGroupName
                             Distinct).ToList
            tscbGName.Items.Clear()
            For Each i In _arrGName
                If i = "" Then
                    i = Nothing
                Else
                    tscbGName.Items.Add(i)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message + " " + "loadGName")
        End Try
    End Sub

    Private Sub tscbGName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscbGName.SelectedIndexChanged
        '-----display inventory details onto datagridview
        modInventory.loadInvDet(dgvInventory, tslblInvNumberText.Text, tscbGName.Text)
    End Sub

    Private Sub dgvInventory_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvInventory.CellFormatting
        'If dgvInventory.Rows(e.RowIndex).Cells("FLDVariance").Value >= 0 Then
        '    dgvInventory.Rows(e.RowIndex).Cells("FLDVariance").Style.ForeColor = modInventory.colorTextGreen
        'Else
        '    dgvInventory.Rows(e.RowIndex).Cells("FLDVariance").Style.ForeColor = modInventory.colorTextRed
        'End If
    End Sub

    '---->start for editing Endings
    Private Sub dgvInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellContentClick

        If e.RowIndex < 0 Then Exit Sub
        If dgvInventory.Columns(e.ColumnIndex).Name <> "FLDInvEndT" Then Exit Sub '"FLDInvEndW" Or "FLDInvEndF" Or "FLDInvEndX" Or 

        Dim _ucPage As New ucInventoryPage
        Dim cls As New clsInvInfo
        Dim arrcls As List(Of clsInvInfo) = cls.checkStatus()

        Dim _arrcls = (From l In arrcls
                       Where l.FLDInvID = tslblInvNumberText.Text
                       Select l.FLDStatus).SingleOrDefault

        If _arrcls <> "POSTED" Then
            Using frm As New popUpdateEnd
                If dgvInventory.CurrentRow.Cells("FLDStart").Value.ToString <> "0" Then
                    frm.txtStart.Enabled = False
                Else
                    frm.txtStart.Enabled = True
                    frm.txtEndW.Enabled = False
                    frm.txtEndF.Enabled = False
                    frm.txtEndX.Enabled = False
                End If
                frm.txtStart.Text = dgvInventory.CurrentRow.Cells("FLDStart").Value.ToString
                frm.txtItemName.Text = dgvInventory.CurrentRow.Cells("FLDItemName").Value.ToString
                frm.txtEndW.Text = dgvInventory.CurrentRow.Cells("FLDInvEndW").Value.ToString
                frm.txtEndF.Text = dgvInventory.CurrentRow.Cells("FLDInvEndF").Value.ToString
                frm.txtEndX.Text = dgvInventory.CurrentRow.Cells("FLDInvEndE").Value.ToString
                frm.lblItemCodeNum.Text = dgvInventory.CurrentRow.Cells("FLDItemCode").Value.ToString
                frm.itemCode = dgvInventory.CurrentRow.Cells("FLDItemCode").Value.ToString
                frm.txtRemarks.Text = dgvInventory.CurrentRow.Cells("FLDRemarks").Value.ToString
                frm.lblItemCodeNum.Tag = tscbGName.Text
                frm.lblInvNumberNum.Text = tslblInvNumberText.Text

                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    modInventory.loadInvDet(dgvInventory, tslblInvNumberText.Text, tscbGName.Text)
                End If
            End Using
        ElseIf _arrcls = "POSTED" Then
            MessageBox.Show("This sheet is already posted")
        End If
    End Sub

    Private Sub tsbtnPost_Click(sender As Object, e As EventArgs) Handles tsbtnPost.Click
        'If sQuery <> 0 Then

        '---opens an empty form
        Dim cls As New clsInvInfo
        Dim uc As New ucInventoryPage

        Dim squery As String = "UPDATE TBLInvInfo SET FLDDtTmEnd = CURRENT_TIMESTAMP WHERE FLDInvID =" & tslblInvNumberText.Text

        If MsgBox("This action is cannot be undone, are you sure?", vbOKCancel) = MsgBoxResult.Ok Then

            Dim ucl As New ucLogin
            ucl.Dock = DockStyle.Fill
            ucl.ucheader = "Authentication!"
            ucl.ucsubheader = "Please enter your credentials"
            ucl.ucAction = "Post"
            ucl.Dock = DockStyle.Fill
            frmPopup.Controls.Add(ucl)
            If frmPopup.ShowDialog() = DialogResult.OK Then
                frmPopup.Close()

                '----updates tblinvinfo timeEnd
                Using oConnection As New SqlConnection(modGeneral.DBconnection())
                    Try
                        oConnection.Open()
                        Using oCommand As New SqlCommand(squery, oConnection)
                            With oCommand
                                .ExecuteNonQuery()
                            End With
                        End Using
                    Catch ex As Exception
                        MessageBox.Show(ex.Message + "Wrong timeformat")
                    End Try
                End Using

                cls.FLDInvID = tslblInvNumberText.Text
                cls.FLDStatus = "POSTED"
                tsbtnPost.Enabled = False
                If cls.updateInvStatus() = True Then
                    uc.loadInvInfo()
                    MsgBox("This inventory sheet #" + tslblInvNumberText.Text + " is posted!", vbOKOnly)
                End If
            End If
        ElseIf MsgBoxResult.Cancel Then
            MsgBox("Process has been canceled!", vbOKOnly)
        End If
    End Sub
End Class
