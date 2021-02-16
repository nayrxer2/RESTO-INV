Imports System.Data.SqlClient
Module modGeneral


#Region "PC/Server"
    Public MyPCName As String
    Public DBName As String
    Public DBServer As String

    Public selectedDB As String
    Public selectedTABLE As String
#End Region

#Region "Get Connection"
    Public Function DBconnection()
        Return "data source = localhost, 1433; uid=sa; pwd=weak; Initial Catalog = CBPOSPredep"
    End Function
#End Region

    'Public Enum strQuery
    '    [Return]
    '    Delivery
    '    Ordering
    '    Receive
    '    Transfer
    '    Inventory
    'End Enum

    'Public Sub setSquery(sQuery As strQuery)
    '    Select Case sQuery
    '        Case strQuery.Return
    '            sQuery = ""
    '        Case strQuery.Delivery
    '            sQuery = ""
    '        Case strQuery.Ordering
    '            sQuery = ""
    '        Case strQuery.Receive
    '            sQuery = ""
    '        Case strQuery.Transfer
    '            sQuery = ""
    '        Case strQuery.Inventory
    '            sQuery = "Select * FROM [CBPOSPredep].[dbo].[TBLInvDetail]"
    '    End Select
    'End Sub
#Region "Array Classes"
    Public arrUser As List(Of clsUser) = fetchUSer()
#End Region

#Region "SQL"
    Public Function fetchUSer() As List(Of clsUser)
        Dim list As List(Of clsUser) = New List(Of clsUser)
        Dim sQuery As String = "SELECT * FROM TBLUser"
        Using oConnection As New SqlConnection(DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    Dim oReader As SqlDataReader = oCommand.ExecuteReader
                    While oReader.Read
                        Dim _clsUser = New clsUser
                        With _clsUser
                            .FLDUID = oReader("FLDUID")
                            .FLDUserName = oReader("FLDUserName")
                            .FLDUPassword = oReader("FLDUPassword")
                            .FLDUGroup = oReader("FLDUGroup")
                            .FLDULevel = oReader("FLDULevel")
                            .FLDUFirstName = oReader("FLDUFirstName")
                            .FLDUMiddleName = oReader("FLDUMiddleName")
                            .FLDULastName = oReader("FLDULastName")
                            .FLDTerminal = oReader("FLDTerminal")
                            .FLDUStatus = oReader("FLDUStatus")
                            .FLDUDTR = oReader("FLDUDTR")

                            list.Add(_clsUser)
                        End With
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message + " " + "Users")
            End Try
        End Using
        Return list
    End Function
#End Region

End Module
