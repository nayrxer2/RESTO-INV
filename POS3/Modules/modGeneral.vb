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
        Return "data source = 192.168.9.102, 1433; uid=sa; pwd=weak; Initial Catalog = CBPOSPredep"
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


    '----3/24/2021
    Public Function authLog()
        Dim list As List(Of clsAuthLogs) = New List(Of clsAuthLogs)
        Dim sQuery As String = "INSERT INTO TBLAuthorizationLog(FLDStoreID, FLDDateID, FLDShiftID, 
                                        FLDTerminal, FLDInvoiceNumber, FLDALDateTime, FLDUsername, FLDALAction, FLDALReason, FLDALCMeal)                                       
                                VALUES(@FLDStoreID, @FLDDateID, @FLDShiftID, @FLDTerminal, @FLDInvoiceNumber, 
                                        @FLDALDateTime, @FLDUsername, @FLDALAction, @FLDALReason, @FLDALCMeal)"

        Using oConnection As New SqlConnection(DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    Dim cls As New clsAuthLogs
                    With oCommand
                        .Parameters.AddWithValue("@FLDStoreID", cls.FLDStoreID)
                        .Parameters.AddWithValue("@FLDDateID", cls.FLDDateID)
                        .Parameters.AddWithValue("@FLDStoreID", cls.FLDStoreID)
                        .Parameters.AddWithValue("@FLDShiftID", cls.FLDShiftID)
                        .Parameters.AddWithValue("@FLDTerminal", cls.FLDTerminal)
                        .Parameters.AddWithValue("@FLDInvoiceNumber", cls.FLDInvoiceNumber)
                        .Parameters.AddWithValue("@FLDALDateTime", cls.FLDALDateTime)
                        .Parameters.AddWithValue("@FLDUsername", cls.FLDUsername)
                        .Parameters.AddWithValue("@FLDALAction", cls.FLDALAction)
                        .Parameters.AddWithValue("@FLDALReason", cls.FLDALReason)
                        .ExecuteNonQuery()
                        Return True
                    End With
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Return False
        End Using
    End Function
    '----3/24/2021
    Public Function authentication(uname As String, upwd As String) As Boolean
        Try
            Dim userlvl = (From user In arrUser
                           Where user.FLDUserName = uname
                           Select user.FLDULevel).SingleOrDefault

            If userlvl <= 3 Then
                Dim userList = (From user In arrUser
                                Where user.FLDUserName = uname And user.FLDUPassword = upwd
                                Select user.FLDUID).Count
                If userList <> 0 Then
                    Return True
                    Dim authLog = (From a In arrUser
                                   Where a.FLDUserName = uname
                                   Select a).ToList

                Else
                    MessageBox.Show("Your username or password is incorrect")
                End If
            Else
                MessageBox.Show("You don't have permission to this application")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
#End Region

End Module
