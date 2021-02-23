Imports System.Data.SqlClient
Public Class ucInventory

    Public Sub dgvHeaderText()
        dgvInventory.DefaultCellStyle.ForeColor = Color.Black
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

        Using frm As New popUpdateEnd
            frm.txtItemName.Text = dgvInventory.CurrentRow.Cells("FLDItemName").Value.ToString
            frm.txtEndW.Text = dgvInventory.CurrentRow.Cells("FLDInvEndW").Value.ToString
            frm.txtEndF.Text = dgvInventory.CurrentRow.Cells("FLDInvEndF").Value.ToString
            frm.txtEndX.Text = dgvInventory.CurrentRow.Cells("FLDInvEndE").Value.ToString
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub tsbtnPost_Click(sender As Object, e As EventArgs) Handles tsbtnPost.Click

    End Sub
End Class
