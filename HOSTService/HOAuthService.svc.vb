Imports System
Imports System.Configuration
Imports System.DirectoryServices
Imports HostCommonLibrary
Imports System.Xml
Imports System.ServiceModel
Imports log4net

' NOTE: If you change the class name "AuthService" here, you must also update the reference to "AuthService" in Web.config and in the associated .svc file.

Public Class HOAuthService
    Implements IHOAuthService

    Dim LogError As LogError = New LogError()

    Private AuthObject As New Host.brRouter

    Public Sub DoWork() Implements IHOAuthService.DoWork
    End Sub

    Public Function GetAuthorizationTicket(ByVal pv_strUserName As String, ByVal pv_strPassword As String) As String Implements IHOAuthService.GetAuthorizationTicket
        Dim v_strUserId As String
        Dim configurationAppSettings As AppSettingsReader = New AppSettingsReader
        Dim v_obj As New Host.brRouter

        Dim v_strAuthorizationMode As String = configurationAppSettings.GetValue("AuthorizationMode", GetType(String))
        Dim v_strAuthenticationDomain As String = configurationAppSettings.GetValue("AuthenticationDomain", GetType(String))
        If pv_strUserName.ToUpper = "ADMIN" Then
            v_strAuthorizationMode = gc_AUTHORIZATION_MODE_DB
        End If

        LogError.Write("::GetAuthorizationTicket:: [BEGIN]: " & pv_strUserName & " v_strAuthorizationMode: " & v_strAuthorizationMode)

        Select Case v_strAuthorizationMode
            Case gc_AUTHORIZATION_MODE_LDAP     'Sử dụng LDAP (Active Directory) để quản lý mật khẩu của NSD

                LogError.Write("::GetAuthorizationTicket:: " & "LDAP://" & v_strAuthenticationDomain & "|" & pv_strUserName & "|")

                Dim v_deNode As New DirectoryEntry("LDAP://" & v_strAuthenticationDomain, pv_strUserName, pv_strPassword, AuthenticationTypes.Secure)
                Dim search As New DirectorySearcher(v_deNode)

                Try
                    Dim result As SearchResult
                    LogError.Write("::GetAuthorizationTicket:: Inside LDAP: Begin find user/password")

                    result = search.FindOne()

                    LogError.Write("::GetAuthorizationTicket:: Findall finish")

                    If result Is Nothing Then
                        LogError.Write("::GetAuthorizationTicket:: ERRCODE: " & v_strAuthenticationDomain & " ERRMSG: ", "EventLogEntryType.Error")

                        v_deNode.Close()
                        v_strUserId = Nothing
                        Return Nothing
                    Else
                        LogError.Write("::GetAuthorizationTicket:: Inside LDAP: Successful! Authenticated.")
                    End If
                Catch ex As Exception
                    LogError.WriteException(ex)
                    'NSD hoặc mật khẩu không đúng
                    v_deNode.Close()
                    v_strUserId = Nothing
                    Return Nothing
                End Try


                Try
                    v_strUserId = v_obj.GetAuthorizationTicket(pv_strUserName)
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try

                If Not (v_strUserId Is Nothing) Then
                    'v_strUserId &= "|" & DataProtection.UnprotectData(pv_strPassword)
                    v_strUserId &= "|" & pv_strPassword
                End If
            Case gc_AUTHORIZATION_MODE_NONE

                Try
                    v_strUserId = v_obj.GetAuthorizationTicket(pv_strUserName, String.Empty)

                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try

                If Not (v_strUserId Is Nothing) Then
                    'v_strUserId &= "|" & DataProtection.UnprotectData(pv_strPassword)
                    v_strUserId &= "|" & pv_strPassword
                End If

            Case gc_AUTHORIZATION_MODE_DB       'Quản lý mật khẩu của NSD trong CSDL
                'Lấy thông tin về NSD trong CSDL
                Try
                    v_strUserId = v_obj.GetAuthorizationTicket(pv_strUserName, pv_strPassword)
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
        End Select

        If v_strUserId Is Nothing Then
            'NSD hoặc mật khẩu không đúng
            Return Nothing
        End If

        'create the ticket
        'Dim ticket As New FormsAuthenticationTicket(v_strUserId, False, 1)
        'Dim encryptedTicket As String = FormsAuthentication.Encrypt(ticket)

        Dim encryptedTicket = Util.EncryptString(v_strUserId)

        'get the ticket timeout in minutes
        Dim timeout As Integer = CInt(configurationAppSettings.GetValue("AuthenticationTicket.Timeout", GetType(Integer)))

        'cache the ticket
        'Context.Cache.Insert(encryptedTicket, v_strUserId, Nothing, DateTime.Now.AddMinutes(timeout), TimeSpan.Zero)

        Return encryptedTicket
    End Function

    Public Function GetTellerProfile(ByVal ticket As String) As HostCommonLibrary.CTellerProfile Implements IHOAuthService.GetTellerProfile
        Try
            Dim v_strBranchId As String = String.Empty
            Dim v_strTellerId As String = String.Empty

            If Not IsTicketValid(ticket, False) Then Return Nothing

            'Dim v_str As String = FormsAuthentication.Decrypt(ticket).Name
            Dim v_str As String = Util.DecryptString(ticket)

            Dim v_strArray() As String = v_str.Split("|")

            If v_strArray.Length = 3 Then
                v_strBranchId = v_strArray(0)
                v_strTellerId = v_strArray(1)
            End If

            LogError.Write("::GetTellerProfile:: " & ticket)

            Dim v_obj As New Host.brRouter
            Dim tlProfile As CTellerProfile = v_obj.GetTellerProfile(v_strBranchId, v_strTellerId)

            Return tlProfile
        Catch ex As Exception
            LogError.WriteException(ex)
            Return Nothing
        End Try
    End Function

    Private Function IsTicketValid(ByVal ticket As String, ByVal IsAdminCall As Boolean) As Boolean
        Return True
    End Function

    Public Function GetLeftMenu(ByVal message As String) As Byte() Implements IHOAuthService.GetLeftMenu
        Dim doc As New XmlDocument()
        Try

            Dim input As String = message
            authObject.GetUserParentMenu(message)

            doc.LoadXml(message)

            Dim xmlNodeList As Xml.XmlNodeList = doc.SelectNodes("/ObjectMessage")
            If xmlNodeList Is Nothing Then
                Return ZetaCompressionLibrary.CompressionHelper.CompressXmlDocument(doc)
            End If
            For i As Integer = 0 To xmlNodeList.Count - 1
                AddChildNode(doc, xmlNodeList.Item(i), input)
            Next i
            'message = doc.InnerXml;
            Return ZetaCompressionLibrary.CompressionHelper.CompressXmlDocument(doc)
        Catch ex As Exception
            LogError.WriteException(ex)
            Return ZetaCompressionLibrary.CompressionHelper.CompressXmlDocument(doc)
        End Try
    End Function

    Public Function GetLeftAdjustMenu(ByVal message As String) As Byte() Implements IHOAuthService.GetLeftAdjustMenu
        Dim doc As New XmlDocument()
        Try

            Dim input As String = message
            authObject.GetUserAdjustMenu(message)

            doc.LoadXml(message)

            Dim xmlNodeList As Xml.XmlNodeList = doc.SelectNodes("/ObjectMessage")
            If xmlNodeList Is Nothing Then
                Return ZetaCompressionLibrary.CompressionHelper.CompressXmlDocument(doc)
            End If
            For i As Integer = 0 To xmlNodeList.Count - 1
                AddChildAdjustNode(doc, xmlNodeList.Item(i), input)
            Next i
            'message = doc.InnerXml;
            Return ZetaCompressionLibrary.CompressionHelper.CompressXmlDocument(doc)
        Catch ex As Exception
            LogError.WriteException(ex)
            Return ZetaCompressionLibrary.CompressionHelper.CompressXmlDocument(doc)
        End Try
    End Function

    Private Sub AddChildNode(ByVal document As XmlDocument, ByVal currentNode As XmlNode, ByVal parenMessage As String)
        If currentNode.Name = "ObjectMessage" Then
            Dim child As XmlDocument
            For Each node As XmlNode In currentNode.ChildNodes
                If node.Name = "ObjData" Then
                    For Each grand As Xml.XmlNode In node.ChildNodes
                        If grand.Attributes.GetNamedItem("fldname") Is Nothing Then
                            Return
                        End If
                        If grand.Attributes.GetNamedItem("fldname").Value = "CMDCODE" Then
                            child = New XmlDocument()
                            Dim objMessage As String

                            Dim modeCode As String
                            If CheckNodeIsTransaction(node, modeCode) Then
                                objMessage = BuildTransChildMenuMessage(parenMessage, modeCode)
                                authObject.GetTransChildMenu(objMessage)
                            Else
                                objMessage = BuildChildMenuMessage(parenMessage, grand.InnerText)
                                authObject.GetUserChildMenu(objMessage)
                            End If

                            child.LoadXml(objMessage)
                            Dim childNode As Xml.XmlNode = document.ImportNode(child.ChildNodes(0), True)
                            grand.AppendChild(childNode)
                            If childNode.HasChildNodes Then
                                If childNode.FirstChild.HasChildNodes Then
                                    AddChildNode(document, childNode, parenMessage)
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub AddChildAdjustNode(ByVal document As XmlDocument, ByVal currentNode As XmlNode, ByVal parenMessage As String)
        If currentNode.Name = "ObjectMessage" Then
            Dim child As XmlDocument
            For Each node As XmlNode In currentNode.ChildNodes
                If node.Name = "ObjData" Then
                    For Each grand As Xml.XmlNode In node.ChildNodes
                        If grand.Attributes.GetNamedItem("fldname") Is Nothing Then
                            Return
                        End If
                        If grand.Attributes.GetNamedItem("fldname").Value = "CMDCODE" Then
                            child = New XmlDocument()
                            Dim objMessage As String

                            objMessage = BuildChildAdjustMenuMessage(parenMessage, grand.InnerText)
                            authObject.GetUserChildAdjustMenu(objMessage)

                            child.LoadXml(objMessage)
                            Dim childNode As Xml.XmlNode = document.ImportNode(child.ChildNodes(0), True)
                            grand.AppendChild(childNode)
                            If childNode.HasChildNodes Then
                                If childNode.FirstChild.HasChildNodes Then
                                    AddChildAdjustNode(document, childNode, parenMessage)
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Private Shared Function CheckNodeIsTransaction(ByVal node As Xml.XmlNode, ByRef modCode As String) As Boolean
        modCode = String.Empty
        Dim result As Boolean = False
        For Each child As Xml.XmlNode In node.ChildNodes
            If child.Attributes.GetNamedItem("fldname") Is Nothing Then
                Continue For
            End If

            If child.Attributes.GetNamedItem("fldname").Value = "MENUTYPE" Then
                If child.InnerText = "T" Then
                    result = True
                End If
            End If
            If child.Attributes.GetNamedItem("fldname").Value = "MODCODE" Then
                modCode = child.InnerText
            End If
        Next
        Return result
    End Function

    Private Shared Function BuildTransChildMenuMessage(ByVal message As String, ByVal modCode As String) As String
        Dim xmlInput As New XmlDocument()
        xmlInput.LoadXml(message)

        Dim clauseNode As XmlNode = xmlInput.ChildNodes(0).Attributes.GetNamedItem("CLAUSE")
        Dim tellerId As String = clauseNode.Value
        clauseNode.Value = tellerId + "|" + modCode

        Dim functionNameNode As XmlNode = xmlInput.ChildNodes(0).Attributes.GetNamedItem("FUNCTIONNAME")
        functionNameNode.Value = "GetTransChildMenu"

        Return xmlInput.InnerXml
    End Function

    Private Shared Function BuildChildMenuMessage(ByVal message As String, ByVal parentKey As String) As String
        Dim xmlInput As New XmlDocument()
        xmlInput.LoadXml(message)

        Dim clauseNode As XmlNode = xmlInput.ChildNodes(0).Attributes.GetNamedItem("CLAUSE")
        Dim tellerId As String = clauseNode.Value
        clauseNode.Value = tellerId + "|" + parentKey

        Dim functionNameNode As XmlNode = xmlInput.ChildNodes(0).Attributes.GetNamedItem("FUNCTIONNAME")
        functionNameNode.Value = "GetUserChildMenu"

        Return xmlInput.InnerXml
    End Function

    Private Shared Function BuildChildAdjustMenuMessage(ByVal message As String, ByVal parentKey As String) As String
        Dim xmlInput As New XmlDocument()
        xmlInput.LoadXml(message)

        Dim clauseNode As XmlNode = xmlInput.ChildNodes(0).Attributes.GetNamedItem("CLAUSE")
        Dim tellerId As String = clauseNode.Value
        clauseNode.Value = tellerId + "|" + parentKey

        Dim functionNameNode As XmlNode = xmlInput.ChildNodes(0).Attributes.GetNamedItem("FUNCTIONNAME")
        functionNameNode.Value = "GetUserChildAdjustMenu"

        Return xmlInput.InnerXml
    End Function

End Class
