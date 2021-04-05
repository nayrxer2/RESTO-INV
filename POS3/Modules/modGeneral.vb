Imports System.Data.SqlClient
Module modGeneral


#Region "PC/Server"
    Public MyPCName As String
    Public DBName As String
    Public DBServer As String
    Public count As Integer
    Public storeID As Integer

    Public selectedDB As String
    Public selectedTABLE As String
#End Region

#Region "Get Connection"
    Public Function testConnection()
        Return "data source = 192.168.9.102, 1433; uid=sa; pwd=weak;"
    End Function

    Public Function countDB() As Boolean
        Dim sQuery As String = Nothing

        sQuery = "SELECT count(name) AS dbcount
                  FROM master.sys.databases 
                  WHERE name LIKE 'GFC%' OR name LIKE 'FBBQ%' OR name LIKE 'CB%'"

        Using oConnection As New SqlConnection(testConnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    Dim oReader As SqlDataReader = oCommand.ExecuteReader
                    oReader.Read()
                    count = oReader("dbcount")
                    Return True
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message + " db checker")
            End Try
        End Using
        Return False
    End Function

    Public Function returnConnection()

        Dim sQuery As String = "SELECT TOP 1 name AS dbname 
                                  FROM master.sys.databases 
                                  WHERE name LIKE 'GFC%' OR name LIKE 'FBBQ%' OR name LIKE 'CB%'"

        Using oConnection As New SqlConnection(testConnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    Dim oReader As SqlDataReader = oCommand.ExecuteReader
                    oReader.Read()
                    'If count > 1 Then
                    '    MessageBox.Show("You dont have exact database to proceed, please contact MIS for help")
                    'ElseIf count = 1 Then
                    DBName = oReader("dbname")
                    'End If
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message + "@returnConnection")
            End Try
        End Using
        Return False
    End Function

    Public Function DBconnection()
        countDB()
        returnConnection()
        If count > 1 Then
            MessageBox.Show("You dont have exact database to proceed, please contact MIS for help")
            End
        Else
            Return "data source = localhost, 1433; uid=sa; pwd=weak; Initial Catalog =" & DBName

            Using oConnection As New SqlConnection(DBconnection())
                Dim squery As String = "SELECT * FROM TBLSettings"
                Try
                    oConnection.Open()
                    Using oCommand As New SqlCommand(squery, oConnection)
                        Dim oReader As SqlDataReader = oCommand.ExecuteReader
                        oReader.Read()
                        storeID = oReader("FLDStoreID")
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message + " store id")
                End Try
            End Using
        End If
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
    Public arrUserlog As List(Of clsUserLogin) = fetchUserLogin()
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

    Public Function fetchUserLogin() As List(Of clsUserLogin)
        Dim list As List(Of clsUserLogin) = New List(Of clsUserLogin)
        Dim sQuery As String = "SELECT * FROM TBLUserLogin"
        Using oConnection As New SqlConnection(DBconnection())
            Try
                oConnection.Open()
                Using oCommand As New SqlCommand(sQuery, oConnection)
                    Dim oReader As SqlDataReader = oCommand.ExecuteReader
                    While oReader.Read
                        Dim listUser = New clsUserLogin
                        With listUser
                            .FLDUserName = oReader("FLDUserName")
                            .FLDDateID = oReader("FLDDateID")
                            .FLDShiftID = oReader("FLDShiftID")
                            .FLDTerminal = oReader("FLDTerminal")
                            .FLDULStart = oReader("FLDULStart")
                            .FLDULEnd = oReader("FLDULEnd")
                            list.Add(listUser)
                        End With
                    End While
                End Using
            Catch ex As Exception
                MsgBox(ex.Message + " " + "arrUserLogin")
            End Try
        End Using
        Return list
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
                    MessageBox.Show("Your username Or password Is incorrect")
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
