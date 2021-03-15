Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Module modInventory
    Public _ucNav As New ucNav

    Public listOfInv As String() = {"Return", "Delivery", "Ordering", "Receive", "Transfer", "Inventory"}

    Public colorTextRed As Color = ColorTranslator.FromHtml("#F44336")
    Public colorTextGreen As Color = ColorTranslator.FromHtml("#43A047")
    Public colorTextGray As Color = ColorTranslator.FromHtml("#757575")
    Public colorTextDarkGray As Color = ColorTranslator.FromHtml("#333333")


    Dim oReader As SqlDataReader
    Dim sQuery As String

#Region "Array Classes"
    Public arrInvDetail As List(Of clsInvDetails) = getInvDetail()
    Public arrInvInfo As List(Of clsInvSheets) = getInvInfo()
    Public arrStoreSettings As List(Of clsStoreSettings) = getStoreSettings()
    Public arrItemUnit As List(Of clsItemUnit) = getItemUnit()
    Public arrGrpName As List(Of clsGrpName) = getGrpName()
#End Region

#Region "SQL to Classes"
    Public Function getInvDetail() As List(Of clsInvDetails)
        Dim list As List(Of clsInvDetails) = New List(Of clsInvDetails)
        'Dim _clsInvD As New clsInvDetails
        sQuery = "SELECT * FROM [TBLInvDetail]"

        Using oConnection As New SqlConnection(modGeneral.DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    oReader = oCommand.ExecuteReader
                    While oReader.Read
                        Dim _clsInvD = New clsInvDetails

                        With _clsInvD
                            '.FLDInvDetailID = oReader("FLDInvDetailID")
                            '.FLDCategory = oReader("FLDCategory")
                            '.FLDGroupCode = oReader("FLDGroupCode")


                            If IsDBNull(oReader("FLDItemName")) Then
                                .FLDItemName = ""
                            ElseIf IsDBNull(oReader("FLDGroupName")) Then
                                .FLDGroupName = ""
                                'ElseIf IsDBNull(oReader("FLDProdUsed")) Then
                                '    .FLDProdUsed = Nothing
                                'ElseIf IsDBNull(oReader("FLDProdMade")) Then
                                '    .FLDProdMade = Nothing
                                'ElseIf IsDBNull(oReader("FLDMealUsage")) Then
                                '    .FLDMealUsage = Nothing
                            ElseIf IsDBNull(oReader("FLDRemarks")) Then
                                .FLDRemarks = ""
                            ElseIf IsDBNull(oReader("FLDInvID")) Then
                                .FLDInvID = Nothing
                            ElseIf IsDBNull(oReader("FLDInventoryNum")) Then
                                .FLDInventoryNum = Nothing
                            ElseIf IsDBNull(oReader("FLDItemCode")) Then
                                .FLDItemCode = Nothing
                                'ElseIf IsDBNull(oReader("FLDStoreID")) Then
                                '    .FLDStoreID = Nothing
                            Else
                                .FLDItemName = oReader("FLDItemName")
                                .FLDGroupName = oReader("FLDGroupName")
                                '.FLDProdUsed = oReader("FLDProdUsed")
                                '.FLDProdMade = oReader("FLDProdMade")
                                '.FLDMealUsage = oReader("FLDMealUsage")
                                .FLDRemarks = oReader("FLDRemarks")
                                .FLDInvID = oReader("FLDInvID")
                                .FLDInventoryNum = oReader("FLDInventoryNum")
                                '.FLDStoreID = oReader("FLDStoreID")
                                .FLDItemCode = oReader("FLDItemCode")
                            End If
                            .FLDStart = oReader("FLDStart")
                            '.FLDDeliver = oReader("FLDDeliver")
                            '.FLDTransfer = oReader("FLDTransfer")
                            '.FLDReturn = oReader("FLDReturn")
                            ' .FLDAdjustment = oReader("FLDAdjustment")
                            .FLDInvEndW = oReader("FLDInvEndW")
                            .FLDInvEndF = oReader("FLDInvEndF")
                            .FLDInvEndE = oReader("FLDInvEndE")
                            .FLDInvEndT = oReader("FLDInvEndT")
                            '.FLDInvUsage = oReader("FLDInvUsage")
                            '.FLDPOSUsage = oReader("FLDPOSUsage")
                            '.FLDVariance = oReader("FLDVariance")
                            '.FLDUnitPrice = oReader("FLDUnitPrice")
                            list.Add(_clsInvD)
                        End With

                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message + " " + "Inventory Details")
            End Try
        End Using
        Return list
    End Function

    Public Function getInvInfo() As List(Of clsInvSheets)
        Dim list As List(Of clsInvSheets) = New List(Of clsInvSheets)
        sQuery = "SELECT * FROM TBLInvInfo"
        Using oConnection As New SqlConnection(modGeneral.DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    oReader = oCommand.ExecuteReader
                    While oReader.Read
                        Dim invSheet = New clsInvSheets
                        With invSheet
                            .FLDinvID = oReader("FLDinvID")
                            .FLDInventoryNum = oReader("FLDInventoryNum")
                            .FLDInvRef = oReader("FLDInvRef")
                            .FLDDelRef = oReader("FLDDelRef")
                            .FLDTransRef = oReader("FLDTransRef")
                            .FLDRetRef = oReader("FLDRetRef")
                            .FLDDtTmStart = oReader("FLDDtTmStart")
                            .FLDDtTmEnd = oReader("FLDDtTmEnd")
                            .FLDDateIDStart = oReader("FLDDateIDStart")
                            .FLDDateIDEnd = oReader("FLDDateIDEnd")
                            .FLDStoreID = oReader("FLDStoreID")
                            list.Add(invSheet)
                        End With
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message + " " + "Inventory Info")
            End Try
        End Using
        Return list
    End Function

    Public Function getStoreSettings() As List(Of clsStoreSettings)
        Dim list As List(Of clsStoreSettings) = New List(Of clsStoreSettings)
        sQuery = "SELECT * FROM [TBLSettings]"
        Using oConnection As New SqlConnection(modGeneral.DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    oReader = oCommand.ExecuteReader
                    Dim storeSettings = New clsStoreSettings
                    While oReader.Read
                        With storeSettings
                            .FLDStoreID = oReader("FLDStoreID")
                            .FLDBranch = oReader("FLDBranch")
                            .FLDSCMUser = oReader("FLDSCMUser")
                            .FLDSCMPassword = oReader("FLDSCMPassword")
                            .FLDSCMDatabase = oReader("FLDSCMPassword")

                            list.Add(storeSettings)
                        End With
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message + ": getStoreSettings")
            End Try
        End Using
        Return list
    End Function

    Public Function getItemUnit() As List(Of clsItemUnit)
        sQuery = "SELECT * FROM TBLItemUnit"
        'Dim sQuery As String = "SELECT * FROM TBLItemUnit where FLDItemCode =" & FLDItemCode
        Dim list As List(Of clsItemUnit) = New List(Of clsItemUnit)
        Dim cIU As clsItemUnit
        Using oConnection As New SqlConnection(modGeneral.DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    Dim oReader As SqlDataReader = oCommand.ExecuteReader
                    While oReader.Read
                        cIU = New clsItemUnit
                        With cIU
                            .FLDItemCode = oReader("FLDItemCode")
                            .FLDItemName = oReader("FLDItemName")
                            .FLDUnitCode = oReader("FLDUnitCode")
                            .FLDUnitName = oReader("FLDUnitName")
                            .FLDUnitRatio = oReader("FLDUnitRatio")
                            .FLDUnitAssign = oReader("FLDUnitAssign")
                            list.Add(cIU)
                        End With
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message + ":" + "Fetching unit ratio")
            End Try
        End Using
        Return list
    End Function
    'Public Function createInventory() As Boolean
    '    Dim list As List(Of clsInvInfo) = New List(Of clsInvInfo)
    '    'Dim sQuery As String = "INSERT INTO TBLInvInfo
    '    '                                    (FLDInvID, FLDInventoryNum, FLDInvRef, FLDDelRef, FLDTransRef, 
    '    '                                    FLDRetRef, FLDDtTmStart, FLDDtTmEnd, FLDDateIDStart, FLDDateIDEnd, FLDStoreID)
    '    '                        VALUES (((SELECT COUNT(*) FROM [TBLInvInfo])+1), @FLDInventoryNum, @FLDInvRef, @FLDDelRef,
    '    '                                    @FLDTransRef, @FLDRetRef, @FLDDtTmStart, @FLDDtTmEnd, @FLDDateIDStart, 
    '    '                                    @FLDDateIDEnd, @FLDStoreID)"
    '    Using oConnection As New SqlConnection(modGeneral.DBconnection())
    '        Try
    '            oConnection.Open()
    '            Using oCommand As New SqlCommand
    '                Dim _clsInvInfo As New clsInvInfo
    '                With oCommand
    '                    .Connection = oConnection
    '                    .CommandType = CommandType.StoredProcedure
    '                    .CommandText = "Inventory_Create"
    '                    .Parameters.AddWithValue("@FLDInventoryNum", _clsInvInfo.FLDInventoryNum)
    '                    .Parameters.AddWithValue("@FLDInvRef", _clsInvInfo.FLDInvRef)
    '                    .Parameters.AddWithValue("@FLDDelRef", _clsInvInfo.FLDDelRef)
    '                    .Parameters.AddWithValue("@FLDTransRef", _clsInvInfo.FLDTransRef)
    '                    .Parameters.AddWithValue("@FLDRetRef", _clsInvInfo.FLDRetRef)
    '                    .Parameters.AddWithValue("@FLDDtTmStart", _clsInvInfo.FLDDtTmStart)
    '                    .Parameters.AddWithValue("@FLDDtTmEnd", _clsInvInfo.FLDDtTmEnd)
    '                    .Parameters.AddWithValue("@FLDDateIDStart", _clsInvInfo.FLDDateIDStart)
    '                    .Parameters.AddWithValue("@FLDDateIDEnd", _clsInvInfo.FLDDateIDEnd)
    '                    .Parameters.AddWithValue("@FLDStoreID", _clsInvInfo.FLDStoreID)
    '                    .ExecuteNonQuery()
    '                    Return True
    '                End With
    '            End Using
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        End Try
    '        Return False
    '    End Using
    'End Function

    'Public Function createInventory() As Boolean
    '    Using oConnection
    '        Try
    '            oConnection.Open()

    '            Using oCommand As New SqlCommand
    '                With oCommand
    '                    .Connection = oConnection
    '                    .CommandType = CommandType.StoredProcedure
    '                    .CommandText = "Inventory_Create"
    '                    With oCommand.Parameters
    '                        .AddWithValue("@FLDInvID", invID).Direction = ParameterDirection.InputOutput
    '                        For Each list In arrInvInfo
    '                            .AddWithValue("@FLDInvRef", list.FLDInvRef)
    '                            .AddWithValue("@FLDInventoryNum", list.FLDInventoryNum)
    '                            .AddWithValue("@FLDDelRef", list.FLDDelRef)
    '                            .AddWithValue("@FLDTransRef", list.FLDTransRef)
    '                            .AddWithValue("@FLDRetRef", list.FLDRetRef)
    '                            .AddWithValue("@FLDDtTmStart", list.FLDDtTmStart)
    '                            .AddWithValue("@FLDDtTmEnd", list.FLDDtTmEnd)
    '                            .AddWithValue("@FLDDateIDStart", list.FLDDateIDStart)
    '                            .AddWithValue("@FLDDateIDEnd", list.FLDDateIDEnd)
    '                            .AddWithValue("@FLDStoreID", list.FLDStoreID)
    '                        Next
    '                    End With
    '                    .ExecuteNonQuery()
    '                    Return True
    '                End With
    '            End Using

    '        Catch ex As Exception
    '            MsgBox(ex.Message + ":  createInventory")
    '        End Try
    '    End Using
    '    Return False
    'End Function

    Public Function getGrpName() As List(Of clsGrpName)
        sQuery = "SELECT * FROM TBLGroup WHERE FLDGStatus = 1"
        Dim list As List(Of clsGrpName) = New List(Of clsGrpName)
        Dim GrpName As clsGrpName
        Using oConnection As New SqlConnection(modGeneral.DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    Dim oReader As SqlDataReader = oCommand.ExecuteReader
                    While oReader.Read
                        GrpName = New clsGrpName
                        With GrpName
                            .FLDGCode = oReader("FLDGCode")
                            .FLDGName = oReader("FLDGName")
                            .FLDGType = oReader("FLDGType")
                            list.Add(GrpName)
                        End With
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message + ":" + "GroupName")
            End Try
        End Using
        Return list
    End Function
#End Region

#Region "LINQ & Functions"
    '-----display inventory details onto datagridview
    Public Sub loadInvDet(dgvInventory As DataGridView, invID As Integer, invGName As String)
        Try
            arrInvDetail = getInvDetail()
            Dim _arrInvDetail = (From l In arrInvDetail
                                 Where l.FLDInvID = invID And l.FLDGroupName = invGName
                                 Order By l.FLDItemName Ascending
                                 Select New With {l.FLDItemCode, l.FLDItemName, l.FLDStart, l.FLDInvEndW,
                                        l.FLDInvEndF, l.FLDInvEndE, l.FLDInvEndT,
                                        l.FLDRemarks}).ToList()

            'l.FLDDeliver,l.FLDTransfer, l.FLDReturn, l.FLDProdUsed, l.FLDProdMade,  l.FLDInvUsage, l.FLDPOSUsage, l.FLDMealUsage, l.FLDVariance, l.FLDUnitPrice,
            dgvInventory.DataSource = _arrInvDetail
            dgvInventory.Columns("FLDItemName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvInventory.Columns("FLDItemCode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Catch ex As Exception
            MessageBox.Show(ex.Message + " " + "loadInvDet")
        End Try
    End Sub
#End Region

#Region "Logs"
    'to try

    'Public Function showMessageBox(message As String,
    '                          Optional icon As MessageBoxIcon = MessageBoxIcon.Information,
    '                          Optional caption As String = Nothing) As DialogResult
    '    If caption = Nothing Then caption = My.Application.Info.Title

    '    Using fMessage As New frmMessageBox(message, icon, caption)
    '        Return fMessage.ShowDialog()
    '    End Using
    'End Function
    'Public Sub logError(caption As String, message As String, Optional show As Boolean = True)
    '    If show Then showMessageBox(message, MessageBoxIcon.Error, "Error: " & caption)
    '    If Directory.Exists(sDirectory) = False OrElse File.Exists(sFileError) = False Then
    '        Exit Sub
    '    End If
    '    Try
    '        Using oWriter As New StreamWriter(sFileError, True)
    '            oWriter.WriteLine("[" & Date.Now.ToString("yyyy-MMM-dd hh:mm tt") & "] " & caption & ": " & message)
    '            oWriter.Close()
    '        End Using
    '    Catch
    '    End Try
    'End Sub
#End Region

End Module
