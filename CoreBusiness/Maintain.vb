Imports DataAccessLayer
Imports HostCommonLibrary
Imports System.Data

'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Supported), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class Maintain
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Dim mv_sTABLE As String
    Public mv_autoidCFAuth As String = String.Empty
    Public mv_autoidDdmast As String = String.Empty

#Region " Property "
    Public Property ATTR_TABLE() As String
        Get
            Return mv_sTABLE
        End Get
        Set(ByVal Value As String)
            mv_sTABLE = Value
        End Set
    End Property
    Public Property autoidCFAuth() As String
        Get
            Return mv_autoidCFAuth
        End Get
        Set(ByVal Value As String)
            mv_autoidCFAuth = Value
        End Set
    End Property
    Public Property autoidDdmast() As String
        Get
            Return mv_autoidDdmast
        End Get
        Set(ByVal Value As String)
            mv_autoidDdmast = Value
        End Set
    End Property
#End Region

#Region " Core Functions - Cannot override "
    Private Function CoreAdd(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_strErrorSource As String = ATTR_TABLE & ".CoreAdd"
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
        Dim v_strSQL1 As String
        Dim v_strSQL As String = "INSERT INTO " & ATTR_TABLE
        Dim v_strListOfFields As String = vbNullString
        Dim v_strListOfValues As String = vbNullString
        Dim v_strSignature As String = String.Empty
        Dim v_strCustID As String = String.Empty
        Try
            'Check HOST Active
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrorCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            'Verify memo table
            v_lngErrorCode = VerifyMemoTable()
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
            v_lngErrorCode = CheckBeforeAdd(v_strSystemProcessMsg)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If
            v_lngErrorCode = SystemProcessBeforeAdd(v_strSystemProcessMsg)

            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
            End If

            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strAutoId, v_strParentObjName, v_strParentClause As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
                v_strAutoId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
            Else
                v_strAutoId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME) Is Nothing) Then
                v_strParentObjName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME), Xml.XmlAttribute).Value)
            Else
                v_strParentObjName = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE) Is Nothing) Then
                v_strParentClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strParentClause = String.Empty
            End If

            'Inquiry data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_ds As DataSet
            Dim v_decID As Decimal
            If (v_strAutoId = gc_AutoIdUsed) Then
                v_decID = v_obj.GetIDValue(ATTR_TABLE)
            End If

            'Cập nhật vào CSDL
            Dim v_nodeList As Xml.XmlNodeList, i As Integer
            Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
            Dim v_strObjname As String

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")


            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    Dim xmlMsg As Xml.XmlElement = pv_xmlDocument.SelectSingleNode("ObjectMessage")
                    v_strObjname = xmlMsg.GetAttribute(gc_AtributeOBJNAME)
                    'If v_strFLDNAME = "AUTOID" And v_strObjname <> "FA.FABROKERAGEXTRA" Then       'thangpv
                    If v_strFLDNAME = "AUTOID" Then

                        If (v_strAutoId = gc_AutoIdUsed) Then
                            v_strNewValue = v_decID
                        Else
                            v_strNewValue = .InnerText.ToString
                        End If
                        'AnhVT Added for approval                        

                        'v_strObjname = xmlMsg.GetAttribute(gc_AtributeOBJNAME)
                        If (v_strAutoId = gc_AutoIdUsed) Then
                            xmlMsg.SetAttribute(gc_AtributeREFERENCE, "'" + v_strNewValue + "'")
                        End If
                        If (v_strObjname <> "CA.CAMAST") Then
                            xmlMsg.SetAttribute(gc_AtributeCLAUSE, v_strFLDNAME + " = '" + v_strNewValue + "'")
                        End If
                    Else
                        v_strNewValue = .InnerText.ToString
                    End If

                    If Len(v_strNewValue) > 0 Then
                        If Len(v_strListOfFields) = 0 Then
                            v_strListOfFields = "(" & v_strFLDNAME
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_strListOfValues = "('" & v_strNewValue.Replace("'", "''") & "'"
                                Case "System.Date"
                                    v_strListOfValues = "('" & v_strNewValue & "'"
                                Case "System.DateTime"
                                    If v_strNewValue = "01/01/1900" Then
                                        v_strListOfValues = "null"
                                    Else
                                        v_strListOfValues = "(" & "TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                                    End If

                                Case Else
                                    v_strListOfValues = "(" & v_strNewValue
                            End Select
                        Else
                            v_strListOfFields = v_strListOfFields & "," & v_strFLDNAME
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_strListOfValues = v_strListOfValues & ",'" & v_strNewValue.Replace("'", "''") & "'"
                                Case "System.DateTime"
                                    If v_strNewValue = "01/01/1900" Then
                                        v_strListOfValues = v_strListOfValues & ",null"
                                    Else
                                        v_strListOfValues = v_strListOfValues & ",TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                                    End If
                                Case GetType(Double).Name
                                    v_strListOfValues = v_strListOfValues & "," & Replace(v_strNewValue, ",", "")
                                Case Else
                                    v_strListOfValues = v_strListOfValues & "," & v_strNewValue
                            End Select
                        End If
                    End If
                End With
            Next


            If v_strParentObjName = "CFMAST" Or v_strParentObjName = "CF.CFMAST" And v_strParentClause <> String.Empty Then
                v_strSQL1 = "SELECT COUNT(*) FROM CFMAST WHERE " & v_strParentClause & " AND STATUS NOT IN ('B','C','N') "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL1)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_CF_CFMAST_STATUS_NOTVALID
                    End If
                End If
            End If


            If Len(v_strListOfFields) <> 0 Then
                v_strListOfFields = v_strListOfFields & ")"
                v_strListOfValues = v_strListOfValues & ")"
                v_strSQL = v_strSQL & " " & v_strListOfFields & " VALUES " & v_strListOfValues
                Dim v_strSQLMEMO As String = "INSERT INTO " & ATTR_TABLE & "MEMO"
                v_strSQLMEMO = v_strSQLMEMO & " " & v_strListOfFields & " VALUES " & v_strListOfValues
                'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionAdd, v_strSQL, CommandType.Text, v_strSQLMEMO)
                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrorCode
                    Exit Function
                End If
            End If


            v_strSystemProcessMsg = pv_xmlDocument.InnerXml
            v_lngErrorCode = ProcessAfterAdd(v_strSystemProcessMsg)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If
            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            'AnhVT Added - Maintenance Approval Retro
            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionAdd)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If
            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
        End Try
    End Function

    Private Function CoreEdit(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR, v_strSQLTmp As String, v_DataAccess As New DataAccess
        Try
            'Check HOST Active
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrorCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            'Verify memo table
            v_lngErrorCode = VerifyMemoTable()
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
            v_lngErrorCode = CheckBeforeEdit(v_strSystemProcessMsg)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If
            v_lngErrorCode = SystemProcessBeforeEdit(v_strSystemProcessMsg)

            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Return v_lngErrorCode
            End If

            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal, v_strParentObjName, v_strParentClause As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME) Is Nothing) Then
                v_strParentObjName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME), Xml.XmlAttribute).Value)
            Else
                v_strParentObjName = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE) Is Nothing) Then
                v_strParentClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strParentClause = String.Empty
            End If

            'Update data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_ds As DataSet
            Dim v_nodeList As Xml.XmlNodeList, i As Integer
            Dim v_strSQL As String

            If v_strParentObjName = "CFMAST" Or v_strParentObjName = "CF.CFMAST" And v_strParentClause <> String.Empty Then
                v_strSQL = "SELECT COUNT(*) FROM CFMAST WHERE " & v_strParentClause & " AND STATUS NOT IN ('B','C','N') "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_CF_CFMAST_STATUS_NOTVALID
                    End If
                End If
            ElseIf ATTR_TABLE = "CFMAST" And v_strClause <> String.Empty Then
                v_strSQL = "SELECT COUNT(*) FROM CFMAST WHERE " & v_strClause & " AND STATUS NOT IN ('B','C','N') "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_CF_CFMAST_STATUS_NOTVALID
                    End If
                End If
            End If

            'AnhVT Added - Maintenance Approval Retro
            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionEdiT)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If

            v_strSQL = "UPDATE " & ATTR_TABLE & " SET "

            Dim v_strUPD As String = vbNullString, v_strUPDTMP As String = vbNullString, v_strSQL2 As String = vbNullString


            Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strOldValue = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    v_strNewValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                    'If (Trim(v_strOldValue) <> Trim(v_strNewValue) And Not (v_strOldValue = "0" And v_strNewValue = String.Empty) And Not (ATTR_TABLE = "CFSIGN" And v_strFLDNAME = "SIGNATURE")) Then
                    If (Trim(v_strOldValue) <> Trim(v_strNewValue) And Not (v_strOldValue = "0" And v_strNewValue = String.Empty)) Then 'And Not (ATTR_TABLE = "CFAUTH" And v_strFLDNAME = "SIGNATURE")) Then

                        Select Case v_strFLDTYPE
                            Case "System.String"
                                v_strUPDTMP = v_strFLDNAME & " = '" & v_strNewValue.Replace("'", "''") & "'"
                            Case "System.DateTime"
                                If v_strNewValue = "01/01/1900" Then
                                    v_strUPDTMP = v_strFLDNAME & " = null"
                                Else
                                    v_strUPDTMP = v_strFLDNAME & " = TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                                End If
                            Case GetType(Double).Name
                                v_strUPDTMP = v_strFLDNAME & "=" & Replace(v_strNewValue, ",", "")
                            Case Else
                                v_strUPDTMP = v_strFLDNAME & "=" & v_strNewValue
                        End Select

                        If Len(v_strUPD) = 0 Then
                            v_strUPD = v_strUPDTMP
                        Else
                            v_strUPD = v_strUPD & ", " & v_strUPDTMP
                        End If

                        ' HaiLT them
                        ' Neu thay doi loai hinh tieu khoan ma chua duyet thi cap nhap truong CHGACTYPE = 'Y'
                        ' De phuc vu cho viec kiem tra khong cho phep lam giao dich khi chua duyet thay doi loai hinh (CHGTYPEALLOW trong bang TLTX (N kiem tra))
                        If ATTR_TABLE = "AFMAST" And v_strFLDNAME = "ACTYPE" Then
                            v_strSQLTmp = "UPDATE AFMAST SET CHGACTYPE = 'Y' WHERE 0=0 AND " & v_strClause & "; "
                        End If
                        ' End of HaiLT them
                    End If

                End With
            Next

            If Len(v_strUPD) <> 0 Then
                v_strSQL = v_strSQL & v_strUPD & " WHERE 0=0 AND " & v_strClause
                Dim v_strSQLMEMO As String = "UPDATE " & ATTR_TABLE & "MEMO SET "
                v_strSQLMEMO = "BEGIN " & v_strSQLTmp & ControlChars.CrLf _
                        & " INSERT INTO " & ATTR_TABLE & "MEMO SELECT * FROM " & ATTR_TABLE & " WHERE 0=0 AND " & v_strClause & "; " & ControlChars.CrLf _
                        & v_strSQLMEMO & v_strUPD & " WHERE 0=0 AND " & v_strClause & "; END;"
                If ATTR_TABLE = "PRMASTER" Then
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If
                v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionEdiT, v_strSQL, CommandType.Text, v_strSQLMEMO)
                'v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionAdd, v_strSQL, CommandType.Text, v_strSQLMEMO)
                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrorCode
                    Exit Function
                End If
            End If

            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL2)
            v_strSystemProcessMsg = pv_xmlDocument.InnerXml
            v_lngErrorCode = ProcessAfterEdit(v_strSystemProcessMsg)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If
            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
        End Try
    End Function

    Private Function CoreDelete(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
        Try
            'Check HOST Active
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrorCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            'Verify memo table
            v_lngErrorCode = VerifyMemoTable()
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrorCode
            End If

            Dim v_strSystemProcessMsg As String = pv_xmlDocument.InnerXml
            v_lngErrorCode = CheckBeforeDelete(v_strSystemProcessMsg)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If
            v_lngErrorCode = SystemProcessBeforeDelete(v_strSystemProcessMsg)

            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Return v_lngErrorCode
            End If

            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal, v_strParentObjName, v_strParentClause As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME) Is Nothing) Then
                v_strParentObjName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME), Xml.XmlAttribute).Value)
            Else
                v_strParentObjName = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE) Is Nothing) Then
                v_strParentClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strParentClause = String.Empty
            End If

            'Delete data
            Dim v_obj As DataAccess
            Dim v_strSQL As String
            Dim v_ds As DataSet

            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            If v_strParentObjName = "CFMAST" Or v_strParentObjName = "CF.CFMAST" And v_strParentClause <> String.Empty Then
                v_strSQL = "SELECT COUNT(*) FROM CFMAST WHERE " & v_strParentClause & " AND STATUS NOT IN ('B','C','N') "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count >= 1 Then
                    If v_ds.Tables(0).Rows(0)(0) = 0 Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_CF_CFMAST_STATUS_NOTVALID
                    End If
                End If
            End If

            If ATTR_TABLE = "CFAUTH" Or ATTR_TABLE = "CAMAST" Then
                v_strSQL = "UPDATE " & ATTR_TABLE & " SET DELTD='Y' WHERE 0=0 AND " & v_strClause
            Else
                v_strSQL = "DELETE FROM " & ATTR_TABLE & " WHERE 0=0 AND " & v_strClause
            End If

            'locpt 20151007   xu ly log lai cac record delete , hien tai dang delete truc tiep duoi DB 
            '  --> them code tu dong tao bang va log lai cac record delete cho tat ca cac bang hien hanh

            Try
                Dim v_objParamAd As New StoreParameter
                Dim v_arrParaAd(2) As StoreParameter
                Dim v_strFeedBackMsg As String

                v_objParamAd.ParamName = "ATTR_TABLE"
                v_objParamAd.ParamDirection = ParameterDirection.Input
                v_objParamAd.ParamValue = ATTR_TABLE
                v_objParamAd.ParamSize = 100
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(0) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "STRCLAUSE"
                v_objParamAd.ParamDirection = ParameterDirection.Input
                v_objParamAd.ParamValue = v_strClause
                v_objParamAd.ParamSize = 100
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(1) = v_objParamAd

                v_objParamAd = New StoreParameter
                v_objParamAd.ParamName = "p_err_param"
                v_objParamAd.ParamDirection = ParameterDirection.Output
                v_objParamAd.ParamValue = ""
                v_objParamAd.ParamSize = 100
                v_objParamAd.ParamType = GetType(System.String).Name
                v_arrParaAd(2) = v_objParamAd

                v_strFeedBackMsg = v_obj.ExecuteOracleStored("cspks_saproc.pr_GenDeletedTable", v_arrParaAd, 2)

            Catch ex As Exception
                LogError.WriteException(ex)

            End Try

            ' end locpt 20151007


            'Copy láº¡i báº£n ghi cÅ©
            Dim v_strSQLMEMO As String = "INSERT INTO " & ATTR_TABLE & "MEMO SELECT * FROM " & ATTR_TABLE & " WHERE 0=0 AND " & v_strClause
            'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_lngErrorCode = RunApprExecSql(pv_xmlDocument, gc_ActionDeletE, v_strSQL, CommandType.Text, v_strSQLMEMO)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If

            Dim result As Long
            result = Me.MaintainLog(pv_xmlDocument, gc_ActionDeletE)
            If Not (result = ERR_APPROVE_REQUIRED Or result = ERR_SYSTEM_OK) Then
                Return result
            End If


            v_strSystemProcessMsg = pv_xmlDocument.InnerXml
            v_lngErrorCode = ProcessAfterDelete(v_strSystemProcessMsg)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If
            pv_xmlDocument.LoadXml(v_strSystemProcessMsg)

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
        End Try
    End Function

    Private Function CoreInquiry(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes

        Dim v_strClause As String
        Dim v_strLocal As String
        Dim v_strCmdInquiry As String
        Dim v_strCmdType As String
        Dim v_strReference As String
        Dim v_obj As DataAccess

        Dim v_ds As DataSet
        Dim v_strSQL As String

        Try
            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY) Is Nothing) Then
                v_strCmdInquiry = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY), Xml.XmlAttribute).Value)
            Else
                v_strCmdInquiry = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCMDTYPE) Is Nothing) Then
                v_strCmdType = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDTYPE), Xml.XmlAttribute).Value)
            Else
                v_strCmdType = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strReference = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strReference = String.Empty
            End If
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If
            If v_strCmdType = gc_CommandProcedurE Then
                'Cau truy van truyen vao dang CommandProcedure, khong truyen tham so dau vao
                Dim v_arrStrClause() As String
                Dim v_objRptParam As ReportParameters
                Dim v_arrRptPara() As ReportParameters
                v_arrStrClause = v_strClause.Split("^")
                ReDim v_arrRptPara(v_arrStrClause.GetLength(0) - 1)
                For i As Integer = 0 To v_arrStrClause.GetLength(0) - 1
                    Dim v_arrStrParam() As String = v_arrStrClause(i).Split("!")
                    v_objRptParam = New ReportParameters
                    v_objRptParam.ParamName = IIf(v_arrStrParam(0) Is Nothing, "", v_arrStrParam(0))
                    v_objRptParam.ParamValue = IIf(v_arrStrParam(1) Is Nothing, "", v_arrStrParam(1))
                    v_objRptParam.ParamSize = IIf(v_arrStrParam(3) Is Nothing, 0, v_arrStrParam(3))
                    v_objRptParam.ParamType = IIf(v_arrStrParam(2) Is Nothing, "", v_arrStrParam(2))
                    v_arrRptPara(i) = v_objRptParam
                Next
                ReDim Preserve v_arrRptPara(v_arrStrClause.GetLength(0) - 1)
                v_strSQL = v_strCmdInquiry
                v_ds = v_obj.ExecuteStoredReturnDataset(v_strSQL, v_arrRptPara)
            Else
                'Cau truy can truyen vao la dang CommandText
                If Len(Trim(v_strCmdInquiry)) > 0 Then
                    v_strSQL = v_strCmdInquiry
                Else
                    v_strSQL = "SELECT * FROM " & ATTR_TABLE & " WHERE 0=0"
                End If

                If Len(Trim(v_strClause)) > 0 Then
                    v_strSQL &= " AND " & v_strClause
                End If

                If isQueryCommand(v_strSQL) Then
                    'Chỉ cho phép thực hiện với command là lệnh SELECT
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                End If
            End If

            If v_strReference = "L" Then
                Dim v_strDataXSD, v_strDataXML As String
                Dim v_arrXSDByteMessage(), v_arrXMLByteMessage() As Byte
                Dim v_Encoded As Char()
                Dim v_dataElement As Xml.XmlElement


                v_strDataXSD = v_ds.GetXmlSchema
                v_strDataXML = v_ds.GetXml
                v_ds.Dispose()
                v_arrXSDByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(v_strDataXSD)
                v_arrXMLByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(v_strDataXML)
                v_strDataXSD = ""
                v_strDataXML = ""
                Dim v_XSD As New TestBase64.Base64Encoder(v_arrXSDByteMessage)
                v_Encoded = v_XSD.GetEncoded
                v_strDataXSD = v_Encoded
                v_arrXSDByteMessage = Nothing

                Dim v_XML As New TestBase64.Base64Encoder(v_arrXMLByteMessage)
                v_Encoded = v_XML.GetEncoded
                v_strDataXML = v_Encoded
                v_arrXMLByteMessage = Nothing
                'Schema
                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjDataXSD", "")
                v_dataElement.InnerText = v_strDataXSD
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                'Data
                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjDataXML", "")
                v_dataElement.InnerText = v_strDataXML
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                v_strDataXSD = ""
                v_strDataXML = ""
                'v_dataElement.RemoveAll()

            Else
                Dim v_strDataMessage As String = pv_xmlDocument.InnerXml
                BuildXMLObjData(v_ds, v_strDataMessage)
                pv_xmlDocument.LoadXml(v_strDataMessage)
            End If

            v_ds.Dispose()
            Complete() 'ContextUtil.SetComplete()
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'AnhVT Added - Maintenance Approval Retro
    Private Function CoreReject(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String = String.Empty, v_DataAccess As New DataAccess()
        Try
            'Check HOST Active
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrorCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_logSQL As String
            Dim v_strLocal, v_strTXDATE As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            Dim apprvId As String = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            'Reject data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess()
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_strSQL As String

            'DungNH them phan Reject lay tu maintain_log
            Dim v_objParam As StoreParameter
            Dim v_arrParam(3) As StoreParameter
            Dim v_lngErrCode As Long = ERR_SYSTEM_OK

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_tlid"
            v_objParam.ParamValue = apprvId
            v_objParam.ParamSize = 30
            v_objParam.ParamType = GetType(System.String).Name
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_ATTR_TABLE"
            v_objParam.ParamValue = ATTR_TABLE
            v_objParam.ParamSize = 30
            v_objParam.ParamType = GetType(System.String).Name
            v_objParam.ParamDirection = ParameterDirection.Input
            v_arrParam(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_strClause"
            v_objParam.ParamValue = v_strClause
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_arrParam(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_arrParam(3) = v_objParam

            v_obj.ExecuteOracleStored("pr_ProcessAfterReject", v_arrParam, 3)

            'Xu ly rieng theo yeu cau cua a Tu dv cac bang type
            'If ATTR_TABLE.IndexOf("TYPE") <> -1 Then
            '    v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || APPRV_STS, APPRV_STS = 'E' WHERE 0=0 AND " & v_strClause
            'Else
            '    v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || STATUS, STATUS = 'E' WHERE 0=0 AND " & v_strClause
            'End If

            If ATTR_TABLE.IndexOf("TYPE") <> -1 Then
                'Xu ly rieng theo yeu cau cua a Tu dv cac bang type
                v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || APPRV_STS, APPRV_STS = 'A' WHERE 0=0 AND " & v_strClause
            ElseIf ATTR_TABLE = "CRBTRFLOG" Then
                'Xá»­ lÃ½ náº¿u tá»« chá»‘i phÃª duyá»‡t báº£ng kÃª thÃ¬ pháº£i Ä‘Ã¡nh dáº¥u láº¡i CRBTXREQ
                v_strSQL = "UPDATE CRBTXREQ SET STATUS='P' WHERE STATUS='A' AND REQID IN (" & vbCrLf &
                            "    SELECT DTL.REFREQID FROM CRBTRFLOG MST, CRBTRFLOGDTL DTL" & vbCrLf &
                            "    WHERE MST.VERSION=DTL.VERSION AND MST.TXDATE=DTL.TXDATE" & vbCrLf &
                            "    AND MST.TRFCODE=DTL.TRFCODE AND MST." & v_strClause & vbCrLf &
                            ")"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE CRBTRFLOGDTL SET STATUS='E' WHERE AUTOID IN (" & vbCrLf &
                            "    SELECT DTL.AUTOID FROM CRBTRFLOG MST, CRBTRFLOGDTL DTL" & vbCrLf &
                            "    WHERE MST.VERSION=DTL.VERSION AND MST.TXDATE=DTL.TXDATE" & vbCrLf &
                            "    AND MST.TRFCODE=DTL.TRFCODE AND MST." & v_strClause & vbCrLf &
                            ")"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || STATUS, STATUS = 'E', APPRV_STS = 'E' WHERE STATUS='P' AND " & v_strClause
            ElseIf ATTR_TABLE = "CFMAST" Then
                ' Khi tu choi duyet thi de lai trang thai ACTIVE doi voi KH bi tu choi va xoa thong tin tu choi duyet trong MAINTAIN_LOG
                Dim modNum As Int16
                Dim v_ds As DataSet

                'v_strSQL = "SELECT * FROM MAINTAIN_LOG WHERE APPROVE_RQD = 'Y' AND CHILD_TABLE_NAME = 'AFMAST' AND COLUMN_NAME = 'ACTYPE' AND  (TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') AND APPROVE_ID IS NULL"
                'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                'If v_ds.Tables(0).Rows.Count > 0 Then
                '    For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                '        v_logSQL = "UPDATE AFMAST SET CHGACTYPE = 'N' WHERE 0 = 0 AND " & v_ds.Tables(0).Rows(i)("CHILD_RECORD_KEY")
                '        v_obj.ExecuteNonQuery(CommandType.Text, v_logSQL)
                '    Next
                'End If



                v_strSQL = "UPDATE AFMAST SET CHGACTYPE = 'N' WHERE 'ACCTNO = ''' || ACCTNO || '''' IN (SELECT CHILD_RECORD_KEY FROM MAINTAIN_LOG WHERE APPROVE_RQD = 'Y' AND CHILD_TABLE_NAME = 'AFMAST' AND COLUMN_NAME = 'ACTYPE' AND  (TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') AND APPROVE_ID IS NULL)"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                'Cap nhap lai STATUS = A doi voi cac tieu khoan trong AFMAST khi bi tu choi duyet
                v_strSQL = "UPDATE AFMAST SET STATUS = 'A' WHERE 'ACCTNO = ''' || ACCTNO || '''' IN (SELECT CHILD_RECORD_KEY FROM MAINTAIN_LOG WHERE APPROVE_RQD = 'Y' AND CHILD_TABLE_NAME = 'AFMAST' AND ACTION_FLAG = 'EDIT' AND TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "'  AND APPROVE_ID IS NULL)"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)


                v_strSQL = "SELECT NVL(MIN(MOD_NUM),0) FROM MAINTAIN_LOG WHERE APPROVE_RQD = 'Y' AND ((TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') or (TABLE_NAME = 'AFMAST' AND RECORD_KEY in (select 'ACCTNO = '''|| ACCTNO ||'''' from AFMAST where " & v_strClause & "))) AND APPROVE_ID IS NULL"

                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    modNum = 0
                Else
                    modNum = v_ds.Tables(0).Rows(0)(0)
                End If

                'xoa reaflnk lien quan
                v_strSQL = "UPDATE REAFLNK set STATUS='C', CLSTXDATE = GETCURRDATE WHERE STATUS ='P' and " & Replace(v_strClause, "CUSTID", "AFACCTNO") & "  and exists(SELECT CHILD_RECORD_KEY FROM MAINTAIN_LOG WHERE APPROVE_RQD = 'Y' AND CHILD_TABLE_NAME = 'REAFLNK' AND ACTION_FLAG = 'ADD' AND TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "'  AND APPROVE_ID IS NULL)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)



                v_logSQL = "UPDATE MAINTAIN_LOG SET APPROVE_DT = TO_DATE('" & v_strTXDATE & "', 'dd/MM/yyyy'), APPROVE_ID = '" & apprvId & "' ,approve_time = to_char(SYSDATE,'hh24:mi:ss') WHERE ((TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') or (TABLE_NAME = 'AFMAST' AND RECORD_KEY in (select 'ACCTNO = '''|| ACCTNO ||'''' from AFMAST where " & v_strClause & "))) AND APPROVE_ID IS NULL AND MOD_NUM >= " & modNum
                v_obj.ExecuteNonQuery(CommandType.Text, v_logSQL)




                v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || STATUS, STATUS = 'A' WHERE STATUS='P' AND " & v_strClause
            ElseIf ATTR_TABLE = "CAMAST" Then
                v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || STATUS, STATUS = SUBSTR(PSTATUS,LENGTH(PSTATUS),1) WHERE STATUS='P' AND " & v_strClause
            Else
                v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || STATUS, STATUS = 'A' WHERE STATUS='P' AND " & v_strClause
            End If

            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)





            'XÃ³a log
            If ATTR_TABLE = "CFMAST" Then
                v_strSQL = "UPDATE APPRVEXEC set STATUS='C' WHERE ((TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') or  (TABLE_NAME = 'AFMAST' AND RECORD_KEY in (select 'ACCTNO = '''|| ACCTNO ||'''' from AFMAST where " & v_strClause & ")))  AND STATUS ='N'"
            Else
                v_strSQL = "UPDATE APPRVEXEC set STATUS='C' WHERE TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "' AND STATUS ='N'"
            End If
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Xá»­ lÃ½ náº¿u báº£ng cÃ³ thÃ´ng tin memo
            v_strSQL = "SELECT table_name FROM user_tables where table_name = '" & ATTR_TABLE.ToUpper & "MEMO'"
            Dim v_dsMEMO As DataSet
            v_dsMEMO = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsMEMO.Tables(0).Rows.Count > 0 Then
                v_strSQL = "DELETE FROM " & ATTR_TABLE & "MEMO WHERE " & v_strClause
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
        End Try
    End Function


    Private Function CoreApprove(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String = String.Empty, v_DataAccess As New DataAccess()
        Try
            'Check HOST Active
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_lngErrorCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
            End If
            If v_strSYSVAR <> OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            v_lngErrorCode = CheckBeforeApprove(pv_xmlDocument.InnerXml)
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrorCode
                Exit Function
            End If

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String
            Dim v_strLocal As String
            Dim v_strTXDATE, v_strParentObjName, v_strParentClause As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTXDATE) Is Nothing) Then
                v_strTXDATE = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Else
                v_strTXDATE = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME) Is Nothing) Then
                v_strParentObjName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME), Xml.XmlAttribute).Value)
            Else
                v_strParentObjName = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE) Is Nothing) Then
                v_strParentClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strParentClause = String.Empty
            End If



            Dim apprvId As String = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            'Approve data
            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess()
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_strSQL As String
            If ATTR_TABLE = "CFMAST" Then
                v_strSQL = "SELECT NVL(MIN(MOD_NUM),0) FROM MAINTAIN_LOG WHERE APPROVE_RQD = 'Y' AND ((TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') or (TABLE_NAME = 'AFMAST' AND RECORD_KEY in (select 'ACCTNO = '''|| ACCTNO ||'''' from AFMAST where " & v_strClause & "))) AND APPROVE_ID IS NULL"
            Else
                v_strSQL = "SELECT NVL(MIN(MOD_NUM),0) FROM MAINTAIN_LOG WHERE APPROVE_RQD = 'Y' AND TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "' AND APPROVE_ID IS NULL"
            End If


            Dim v_ds As DataSet
            Dim modNum As Int16
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                modNum = 0
            Else
                modNum = v_ds.Tables(0).Rows(0)(0)
            End If

            'trung.luu: 16/06/2020 neu sửa custodycd thi update lại custodycd mới cho ddmast
            Dim v_strSQL_ddmast, v_from_value, v_to_value, v_updateSQL As String
            v_strSQL_ddmast = "SELECT FROM_VALUE,TO_VALUE FROM MAINTAIN_LOG WHERE APPROVE_RQD = 'Y' AND TABLE_NAME = 'CFMAST' and column_name ='CUSTODYCD' and action_flag = 'EDIT' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "' AND APPROVE_ID IS NULL and  MOD_NUM >= " & modNum
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL_ddmast)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_from_value = If(IsDBNull(v_ds.Tables(0).Rows(0)("FROM_VALUE")), "", v_ds.Tables(0).Rows(0)("FROM_VALUE"))
                v_to_value = If(IsDBNull(v_ds.Tables(0).Rows(0)("TO_VALUE")), "", v_ds.Tables(0).Rows(0)("TO_VALUE"))
            End If
            If v_from_value <> v_to_value Then
                v_updateSQL = " update DDMAST set custodycd  = '" & v_to_value & "' where custodycd = '" & v_from_value & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_updateSQL)

                v_updateSQL = " update FABROKERAGE set custodycd  = '" & v_to_value & "' where custodycd = '" & v_from_value & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_updateSQL)

                'trung.luu: 19-04-2021 SHBVNEX-2215
                v_updateSQL = " update FEETRAN set custodycd  = '" & v_to_value & "' where custodycd = '" & v_from_value & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_updateSQL)
                v_updateSQL = " update FEETRANA set custodycd  = '" & v_to_value & "' where custodycd = '" & v_from_value & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_updateSQL)

                v_updateSQL = " update CFFEEEXP set custodycd  = '" & v_to_value & "' where custodycd = '" & v_from_value & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_updateSQL)

                v_updateSQL = " update log_1203_by_month set custodycd  = '" & v_to_value & "' where custodycd = '" & v_from_value & "' "
                v_obj.ExecuteNonQuery(CommandType.Text, v_updateSQL)
            End If


            'Xu ly rieng theo yeu cau cua a Tu dv cac bang type
            If ATTR_TABLE.IndexOf("TYPE") <> -1 Then
                v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || APPRV_STS, APPRV_STS = 'A' WHERE 0=0 AND " & v_strClause
            Else
                If ATTR_TABLE = "CRBTRFLOG" Then
                    v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || STATUS, STATUS = 'A' WHERE STATUS='P' AND " & v_strClause
                ElseIf ATTR_TABLE = "PRMASTER" Then
                    v_strSQL = "UPDATE " & ATTR_TABLE & " SET PPRSTATUS = PPRSTATUS || PRSTATUS, PRSTATUS = 'A' WHERE 0=0 AND " & v_strClause
                ElseIf ATTR_TABLE <> "CAMAST" Then
                    v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || STATUS, STATUS = 'A' WHERE 0=0 AND " & v_strClause
                Else
                    v_strSQL = "UPDATE " & ATTR_TABLE & " SET PSTATUS = PSTATUS || STATUS, STATUS = 'N',APPRVID = '" & apprvId & "' WHERE 0=0 AND " & v_strClause
                End If
            End If

            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'If ATTR_TABLE = "CAMAST" Then
            '    v_strSQL = "Begin ca_autocall3312('" & Replace(v_strClause, "CAMASTID = '", "") & "); end;"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            '    '3375:
            '    v_strSQL = "Begin ca_autocall3375('" & Replace(v_strClause, "CAMASTID = '", "") & "); end;"
            '    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            'End If

            Dim v_logSQL As String
            If ATTR_TABLE = "CFMAST" Then
                v_logSQL = "UPDATE MAINTAIN_LOG SET APPROVE_DT = TO_DATE('" & v_strTXDATE & "', 'dd/MM/yyyy'), APPROVE_ID = '" & apprvId & "' ,approve_time = to_char(SYSDATE,'hh24:mi:ss') WHERE ((TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') or (TABLE_NAME = 'AFMAST' AND RECORD_KEY in (select 'ACCTNO = '''|| ACCTNO ||'''' from AFMAST where " & v_strClause & "))) AND APPROVE_ID IS NULL AND MOD_NUM >= " & modNum
            Else
                v_logSQL = "UPDATE MAINTAIN_LOG SET APPROVE_DT = TO_DATE('" & v_strTXDATE & "', 'dd/MM/yyyy'), APPROVE_ID = '" & apprvId & "' WHERE TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "' AND APPROVE_ID IS NULL AND MOD_NUM >= " & modNum
            End If
            v_obj.ExecuteNonQuery(CommandType.Text, v_logSQL)

            'Dim RunAtApprove As String = "N"
            'Dim RunChildAtApprove As String = "N"
            'v_strSQL = "SELECT ADDATAPPR, EDITATAPPR, DELATAPPR, ADDCHILDATAPPR FROM APPRVRQD WHERE OBJNAME = '" & ATTR_TABLE & "'"
            'v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'If v_ds.Tables(0).Rows.Count > 0 Then
            '    RunAtApprove = v_ds.Tables(0).Rows(0)("ADDATAPPR")
            '    RunChildAtApprove = v_ds.Tables(0).Rows(0)("ADDCHILDATAPPR")
            'End If

            'Chay cac cau lenh SQL cho duyet trong apprvexec
            If ATTR_TABLE = "CFMAST" Then
                v_logSQL = "SELECT * FROM APPRVEXEC WHERE ((TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') or  (TABLE_NAME = 'AFMAST' AND RECORD_KEY in (select 'ACCTNO = '''|| ACCTNO ||'''' from AFMAST where " & v_strClause & ")))  AND STATUS ='N' ORDER BY AUTOID"
            Else
                v_logSQL = "SELECT * FROM APPRVEXEC WHERE TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "' AND STATUS ='N' ORDER BY AUTOID"
            End If
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_logSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                    'If (v_ds.Tables(0).Rows(i)("ACTION_FLAG") <> "ADD") then 'Or (v_ds.Tables(0).Rows(i)("ACTION_FLAG") = "ADD" And RunChildAtApprove = "N" And v_strParentObjName.Length = 0) Then
                    v_strSQL = v_ds.Tables(0).Rows(i)("SQLCMD")
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'End If
                Next
            End If

            If ATTR_TABLE = "CFMAST" Then
                v_strSQL = "UPDATE APPRVEXEC set STATUS='C' WHERE ((TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "') or  (TABLE_NAME = 'AFMAST' AND RECORD_KEY in (select 'ACCTNO = '''|| ACCTNO ||'''' from AFMAST where " & v_strClause & ")))  AND STATUS ='N'"
            Else
                v_strSQL = "UPDATE APPRVEXEC set STATUS='C' WHERE TABLE_NAME = '" & ATTR_TABLE & "' AND RECORD_KEY = '" & Replace(v_strClause, "'", "''") & "' AND STATUS ='N'"
            End If
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            'Xá»­ lÃ½ náº¿u báº£ng cÃ³ thÃ´ng tin memo
            v_strSQL = "SELECT table_name FROM user_tables where table_name = '" & ATTR_TABLE.ToUpper & "MEMO'"
            Dim v_dsMEMO As DataSet
            v_dsMEMO = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_dsMEMO.Tables(0).Rows.Count > 0 Then
                v_strSQL = "DELETE FROM " & ATTR_TABLE & "MEMO WHERE " & v_strClause
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'Kiem tra doi voi duyet moi mo TK AFMAST thi kiem tra de mo moi TK CIMAST
            If ATTR_TABLE = "CFMAST" Or ATTR_TABLE = "USERLOGIN" Then
                v_lngErrorCode = ProcessAfterApprove(pv_xmlDocument.InnerXml)
            End If

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        Finally
        End Try
    End Function
    'ANHVT Ended

    Overridable Function CheckBeforeApprove(ByVal v_strMessage As String) As Long
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function Approve(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreApprove(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Approve"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function Reject(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreReject(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Reject"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Core Functions - Seriabliable "
    Public Function _CoreAdd(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrorCode As Long = CoreAdd(pv_xmlDocument)
        v_strMessage = pv_xmlDocument.InnerXml
        Return v_lngErrorCode
    End Function
    Public Function _CoreEdit(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrorCode As Long = CoreEdit(pv_xmlDocument)
        v_strMessage = pv_xmlDocument.InnerXml
        Return v_lngErrorCode
    End Function
    Public Function _CoreDelete(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrorCode As Long = CoreDelete(pv_xmlDocument)
        v_strMessage = pv_xmlDocument.InnerXml
        Return v_lngErrorCode
    End Function
    Public Function _CoreInquiry(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrorCode As Long = CoreInquiry(pv_xmlDocument)
        v_strMessage = pv_xmlDocument.InnerXml
        Return v_lngErrorCode
    End Function
#End Region

#Region " Implement functions - Can override if needed "
    Public Function SetATTRTABLE(ByVal v_strTABLE As String) As Long
        ATTR_TABLE = v_strTABLE
    End Function

    Public Function MaintainLog(ByRef pv_xmlDocument As XmlDocumentEx, ByVal ActionFlag As String) As Long
        Dim v_lngErrorCode As Long, v_strErrorSource As String, v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strChildClause, v_strChildObjName As String
        Dim v_strLocal As String
        Dim v_strCurrTime As String
        Dim v_strAutoId, v_strParentObjName, v_strParentClause, v_strObjName, v_strClause, v_strTXDATE As String
        Dim v_strSQL As String

        If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
            v_strChildClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
        Else
            v_strChildClause = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
            v_strLocal = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
        Else
            v_strLocal = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
            v_strAutoId = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
        Else
            v_strAutoId = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME) Is Nothing) Then
            v_strParentObjName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME), Xml.XmlAttribute).Value)
        Else
            v_strParentObjName = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE) Is Nothing) Then
            v_strParentClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE), Xml.XmlAttribute).Value)
        Else
            v_strParentClause = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
            v_strObjName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeOBJNAME), Xml.XmlAttribute).Value)
        Else
            v_strObjName = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
            v_strClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
        Else
            v_strClause = String.Empty
        End If

        If (v_strParentClause = "") Then
            'Neu la parent tab
            v_strParentClause = v_strChildClause
            v_strChildClause = ""
            v_strParentObjName = ATTR_TABLE
            v_strChildObjName = ""
        Else
            'Neu la child tab
            v_strParentObjName = Mid(v_strParentObjName, 4)
            v_strChildObjName = ATTR_TABLE
        End If

        'Inquiry data
        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess()
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_ds As DataSet
        Dim v_strSQLUpdate As String

        Dim makerId As String = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

        If ATTR_TABLE = "CFAUTH" And ActionFlag = gc_ActionAdd Then
            v_strChildClause = "AUTOID = " & autoidCFAuth & ""
        End If

        If ATTR_TABLE = "DDMAST" And ActionFlag = gc_ActionAdd Then
            v_strChildClause = "AUTOID = " & autoidDdmast & ""
        End If
        'Kiem tra du lieu duoc thay doi co nam trong dach sach yeu cau duyet ko
        Dim rqdString As String
        Dim apprvRequired As Char = "Y"
        'Dim oldStatus As String
        Dim modNum As String
        Dim updateStatus As Boolean = False
        Dim v_logSQL As String

        'TruongLD Add 07/10/2011/>
        v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME ='CURRDATE'"
        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count = 0 Then
            v_strTXDATE = String.Empty
        Else
            v_strTXDATE = v_ds.Tables(0).Rows(0)(0)
        End If
        'TruongLD/>

        v_strSQL = "SELECT RQDSTRING FROM APPRVRQD WHERE OBJNAME = '" & ATTR_TABLE & "'"

        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count = 0 Then
            rqdString = String.Empty
        Else
            rqdString = v_ds.Tables(0).Rows(0)(0)
        End If

        v_strSQL = "SELECT NVL(MAX(MOD_NUM),0) FROM MAINTAIN_LOG WHERE TABLE_NAME = '" & v_strParentObjName & "' AND RECORD_KEY = '" & Replace(v_strParentClause, "'", "''") & "'"

        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count = 0 Then
            v_lngErrorCode = -323243
            Return v_lngErrorCode
        Else
            modNum = v_ds.Tables(0).Rows(0)(0)
        End If

        Dim v_nodeList As Xml.XmlNodeList, i As Integer
        Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String
        apprvRequired = "Y"
        v_logSQL = "BEGIN null; "
        If ActionFlag <> gc_ActionDeletE Then
            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strOldValue = Convert.ToString(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    v_strOldValue = v_strOldValue.Replace("'", "''")
                    v_strNewValue = .InnerText.ToString
                    v_strNewValue = v_strNewValue.Replace("'", "''")
                    v_strFLDNAME = Convert.ToString(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = Convert.ToString(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    If v_strFLDTYPE = "System.DateTime" And v_strOldValue = "01/01/1900" Then
                        v_strOldValue = ""
                    End If
                    If v_strFLDTYPE = "System.DateTime" And v_strNewValue = "01/01/1900" Then
                        v_strNewValue = ""
                    End If
                    'Them doan nay de lay AUTOID cua CFAUTH
                    If ATTR_TABLE = "CFAUTH" And v_strFLDNAME = "AUTOID" And ActionFlag = gc_ActionAdd Then
                        v_strNewValue = mv_autoidCFAuth
                    End If
                    If ATTR_TABLE = "DDMAST" And v_strFLDNAME = "AUTOID" And ActionFlag = gc_ActionAdd Then
                        v_strNewValue = mv_autoidDdmast
                    End If
                    If ActionFlag = gc_ActionEdiT Then
                        apprvRequired = "N"
                        If Trim(v_strOldValue) <> Trim(v_strNewValue) And Mid(v_strOldValue, 1, 3) <> "txt" Then
                            'Kiem tra du lieu duoc thay doi co nam trong dach sach yeu cau duyet ko                        
                            If InStr("_" & rqdString & "_", v_strFLDNAME) <> 0 Then
                                apprvRequired = "Y"
                                updateStatus = True
                            ElseIf rqdString = "ALL" Then
                                apprvRequired = "Y"
                                updateStatus = True
                            End If
                            If v_strFLDNAME <> "SIGNATURE" Then
                                v_logSQL = v_logSQL & " INSERT INTO MAINTAIN_LOG(TABLE_NAME, RECORD_KEY, MAKER_ID, MAKER_DT, APPROVE_RQD, COLUMN_NAME, FROM_VALUE, TO_VALUE, MOD_NUM, ACTION_FLAG, CHILD_TABLE_NAME, CHILD_RECORD_KEY, MAKER_TIME) VALUES"
                                v_logSQL = v_logSQL & "('" & v_strParentObjName & "','" & Replace(v_strParentClause, "'", "''") & "','" & makerId & "', To_Date('" & v_strTXDATE & "','DD/MM/RRRR'), '" & apprvRequired
                                v_logSQL = v_logSQL & "','" & v_strFLDNAME & "','" & v_strOldValue & "','" & v_strNewValue & "'," & modNum + 1 & ", '" & gc_ActionEdiT & "','" & v_strChildObjName & "', '" & Replace(v_strChildClause, "'", "''") & "', TO_CHAR(SYSDATE, 'HH24:MI:SS'));"
                            Else
                                v_logSQL = v_logSQL & " INSERT INTO MAINTAIN_LOG(TABLE_NAME, RECORD_KEY, MAKER_ID, MAKER_DT, APPROVE_RQD, COLUMN_NAME, FROM_VALUE, TO_VALUE, MOD_NUM, ACTION_FLAG, CHILD_TABLE_NAME, CHILD_RECORD_KEY, MAKER_TIME) VALUES"
                                v_logSQL = v_logSQL & "('" & v_strParentObjName & "','" & Replace(v_strParentClause, "'", "''") & "','" & makerId & "', To_Date('" & v_strTXDATE & "','DD/MM/RRRR'), '" & apprvRequired
                                v_logSQL = v_logSQL & "','" & v_strFLDNAME & "','" & "" & "','" & "Sửa chữ ký" & "'," & modNum + 1 & ", '" & gc_ActionEdiT & "','" & v_strChildObjName & "', '" & Replace(v_strChildClause, "'", "''") & "', TO_CHAR(SYSDATE, 'HH24:MI:SS'));"
                            End If

                        End If
                    ElseIf ActionFlag = gc_ActionAdd Then
                        If (rqdString <> String.Empty) Then
                            updateStatus = True
                            apprvRequired = "Y"
                        Else
                            updateStatus = False
                            apprvRequired = "N"
                        End If
                        If v_strNewValue <> "" Then
                            If v_strFLDNAME <> "SIGNATURE" Then
                                v_logSQL = v_logSQL & " INSERT INTO MAINTAIN_LOG(TABLE_NAME, RECORD_KEY, MAKER_ID, MAKER_DT, APPROVE_RQD, COLUMN_NAME, FROM_VALUE, TO_VALUE, MOD_NUM, ACTION_FLAG, CHILD_TABLE_NAME, CHILD_RECORD_KEY, MAKER_TIME) VALUES"
                                v_logSQL = v_logSQL & "('" & v_strParentObjName & "','" & Replace(v_strParentClause, "'", "''") & "','" & makerId & "', To_Date('" & v_strTXDATE & "','DD/MM/RRRR'), '" & apprvRequired
                                v_logSQL = v_logSQL & "','" & v_strFLDNAME & "','','" & v_strNewValue & "'," & IIf(modNum = 0, 0, modNum + 1) & ", '" & gc_ActionAdd & "','" & v_strChildObjName & "', '" & Replace(v_strChildClause, "'", "''") & "', TO_CHAR(SYSDATE, 'HH24:MI:SS'));"
                            Else
                                v_logSQL = v_logSQL & " INSERT INTO MAINTAIN_LOG(TABLE_NAME, RECORD_KEY, MAKER_ID, MAKER_DT, APPROVE_RQD, COLUMN_NAME, FROM_VALUE, TO_VALUE, MOD_NUM, ACTION_FLAG, CHILD_TABLE_NAME, CHILD_RECORD_KEY, MAKER_TIME) VALUES"
                                v_logSQL = v_logSQL & "('" & v_strParentObjName & "','" & Replace(v_strParentClause, "'", "''") & "','" & makerId & "', To_Date('" & v_strTXDATE & "','DD/MM/RRRR'), '" & apprvRequired
                                v_logSQL = v_logSQL & "','" & v_strFLDNAME & "','','" & "Thêm mới chữ ký" & "'," & IIf(modNum = 0, 0, modNum + 1) & ", '" & gc_ActionAdd & "','" & v_strChildObjName & "', '" & Replace(v_strChildClause, "'", "''") & "', TO_CHAR(SYSDATE, 'HH24:MI:SS'));"
                            End If
                        End If
                    End If
                End With
            Next
        Else 'Delete action
            'Neu xoa du lieu cua bang con thi bang cha can phai duyet
            If Not v_strChildObjName Is Nothing Then
                If rqdString = String.Empty Then
                    apprvRequired = "N"
                    updateStatus = False
                Else
                    apprvRequired = "Y"
                    updateStatus = True
                End If
            End If
            'Delete Action Maintain_log
            v_logSQL = v_logSQL & " INSERT INTO MAINTAIN_LOG(TABLE_NAME, RECORD_KEY, MAKER_ID, MAKER_DT, APPROVE_RQD, COLUMN_NAME, FROM_VALUE, TO_VALUE, MOD_NUM, ACTION_FLAG, CHILD_TABLE_NAME, CHILD_RECORD_KEY, MAKER_TIME) VALUES"
            v_logSQL = v_logSQL & "('" & v_strParentObjName & "','" & Replace(v_strParentClause, "'", "''") & "','" & makerId & "',To_Date('" & v_strTXDATE & "','DD/MM/RRRR'), '" & apprvRequired & "'"
            v_logSQL = v_logSQL & ",'','',''," & IIf(modNum = 0, 0, modNum + 1) & ", '" & gc_ActionDeletE & "','" & v_strChildObjName & "', '" & Replace(v_strChildClause, "'", "''") & "', TO_CHAR(SYSDATE, 'HH24:MI:SS'));"
        End If


        v_logSQL = v_logSQL & " END;"
        If Len(v_logSQL) <> 0 Then
            'Dim i As Integer
            v_obj.ExecuteNonQuery(CommandType.Text, v_logSQL)
            If (i = -1) Then
                'Tra ve ma loi ko maintain duoc Maintain_Log
                v_lngErrorCode = ERR_MAINTAIN_LOG
                v_strErrorSource = Me.ATTR_TABLE + ".MaintainLog"
                v_strErrorMessage = String.Empty
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrorCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrorCode
            End If
        End If
        'PhuongHT add: log cho CAMAST
        If (v_strParentObjName = "CAMAST") Then
            v_strSQLUpdate = "UPDATE CAMAST SET MAKERID = '" & makerId & "' WHERE CAMASTID='" & v_strParentClause.Substring(12, 16) & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLUpdate)
        End If
        ' end of PhuongHT add

        If updateStatus Then
            'If updateStatus And ActionFlag = gc_ActionEdit Then
            'Sua theo y/c cua a Tu, xu ly rieng doi voi cac bang type
            If v_strParentObjName.IndexOf("TYPE") <> -1 Then
                v_strSQL = " UPDATE " & v_strParentObjName & " SET PSTATUS = PSTATUS || APPRV_STS, APPRV_STS = 'P' WHERE 0=0 AND " & v_strParentClause
            ElseIf v_strParentObjName.Equals("PRMASTER") Then
                'v_strSQL = " UPDATE " & v_strParentObjName & " SET PPRSTATUS = PPRSTATUS || PRSTATUS, PRSTATUS = 'P' WHERE 0=0 AND " & v_strParentClause
                v_strSQL = " UPDATE " & v_strParentObjName & " SET PPRSTATUS = PPRSTATUS || PRSTATUS, PRSTATUS = 'P' WHERE 0=0 AND " & v_strParentClause
            Else
                v_strSQL = " UPDATE " & v_strParentObjName & " SET PSTATUS = PSTATUS || STATUS, STATUS = 'P' WHERE 0=0 AND " & v_strParentClause
            End If
            If Len(v_strSQL) <> 0 Then
                'Dim i As Integer
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                If (i = -1) Then
                    'Tra ve ma loi ko maintain duoc Maintain_Log
                    v_lngErrorCode = ERR_MAINTAIN_LOG
                    v_strErrorSource = Me.ATTR_TABLE + ".MaintainLog"
                    v_strErrorMessage = String.Empty
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrorCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrorCode
                End If
            End If
            v_strSQL = String.Empty
            'ADHOC cho CFMAST, khi sua AFMAST thi thay doi luon trang thai AFMAST.
            'Sua Thong tin con cua AFMAST thi cap nhat luon CFMAST trang thai cho duyet.
            If v_strParentObjName.Equals("CFMAST") AndAlso (v_strChildObjName.Equals("AFMAST") OrElse v_strChildObjName.Equals("REAFLNK")) Then
                v_strSQL = " UPDATE " & v_strChildObjName & " SET PSTATUS = PSTATUS || STATUS, STATUS = 'P' WHERE 0=0 AND " & v_strChildClause
            ElseIf v_strParentObjName.Equals("AFMAST") Then
                v_strSQL = " UPDATE CFMAST SET PSTATUS = PSTATUS || STATUS, STATUS = 'P' WHERE 0=0 AND exists (select 1 from AFMAST where AFMAST.CUSTID = CFMAST.CUSTID and AFMAST." & v_strParentClause & ")"
            End If
            If Len(v_strSQL) <> 0 Then
                'Dim i As Integer
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                If (i = -1) Then
                    'Tra ve ma loi ko maintain duoc Maintain_Log
                    v_lngErrorCode = ERR_MAINTAIN_LOG
                    v_strErrorSource = Me.ATTR_TABLE + ".MaintainLog"
                    v_strErrorMessage = String.Empty
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrorCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrorCode
                End If
            End If
        End If

        Return IIf(updateStatus = True, ERR_APPROVE_REQUIRED, ERR_SYSTEM_OK)

    End Function


    Public Function VerifyMemoTable() As Long
        Dim v_strSQL As String
        Dim v_ds As DataSet
        Dim v_obj As DataAccess = New DataAccess()
        v_obj.NewDBInstance(gc_MODULE_HOST)

        v_strSQL = "SELECT ADDATAPPR, EDITATAPPR, DELATAPPR FROM APPRVRQD WHERE OBJNAME = '" & ATTR_TABLE & "' AND (ADDATAPPR='Y' OR EDITATAPPR='Y' OR DELATAPPR='Y')"
        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count = 0 Then
            'Khong dinh nghia yeu cau duyet
            Return ERR_SYSTEM_OK
        Else
            If ATTR_TABLE.ToUpper = "CFSIGN" Then
                Return ERR_SYSTEM_OK
            End If
            v_strSQL = "SELECT table_name FROM user_tables WHERE table_name = '" & ATTR_TABLE.ToUpper & "MEMO'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Check bang MEMO va bang goc phai cung cau truc
                v_strSQL = "CREATE TABLE " & ATTR_TABLE.ToUpper & "MEMO AS (SELECT * FROM " & ATTR_TABLE.ToUpper & " WHERE 0=1)"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Return ERR_SYSTEM_OK
            Else
                'Kiem tra tuong thich giua hai bang
                v_strSQL = "select column_name, data_type, data_length from user_tab_cols where table_name='" & ATTR_TABLE.ToUpper & "' and data_type <> 'RAW'" & ControlChars.CrLf &
                           "MINUS select column_name, data_type, data_length from user_tab_cols where table_name='" & ATTR_TABLE.ToUpper & "MEMO' and data_type <> 'RAW'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count = 0 Then
                    LogError.Write("Error source: VerifyMemoTable." & Me.ATTR_TABLE & vbNewLine _
                                 & "Error code: -2!" & vbNewLine _
                                 & "Error message: " & Me.ATTR_TABLE & " has some fields not in MEMO", "EventLogEntryType.Error")
                    Return -2
                Else
                    v_strSQL = "select column_name, data_type, data_length from user_tab_cols where table_name='" & ATTR_TABLE.ToUpper & "MEMO' and data_type <> 'RAW'" & ControlChars.CrLf &
                               "MINUS select column_name, data_type, data_length from user_tab_cols where table_name='" & ATTR_TABLE.ToUpper & "' and data_type <> 'RAW'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If Not v_ds.Tables(0).Rows.Count = 0 Then
                        LogError.Write("Error source: VerifyMemoTable." & Me.ATTR_TABLE & vbNewLine _
                                     & "Error code: -2!" & vbNewLine _
                                     & "Error message: " & Me.ATTR_TABLE & "MEMO has some fields not in master", "EventLogEntryType.Error")
                        Return -2
                    End If
                End If
            End If
        End If
        Return ERR_SYSTEM_OK
    End Function


    Public Function VerifyMemoTable(ByVal v_arrTABLE() As String) As Long
        Dim v_strSQL As String
        Dim v_ds As DataSet
        Dim v_obj As DataAccess = New DataAccess()
        v_obj.NewDBInstance(gc_MODULE_HOST)

        For i As Integer = 0 To v_arrTABLE.GetLength(0) - 1

            v_strSQL = "SELECT ADDATAPPR, EDITATAPPR, DELATAPPR FROM APPRVRQD WHERE OBJNAME = '" & v_arrTABLE(i) & "' AND (ADDATAPPR='Y' OR EDITATAPPR='Y' OR DELATAPPR='Y')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Khong dinh nghia yeu cau duyet
                'Return ERR_SYSTEM_OK
            Else
                v_strSQL = "SELECT table_name FROM user_tables WHERE table_name = '" & v_arrTABLE(i).ToUpper & "MEMO'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count = 0 Then
                    'Check bang MEMO va bang goc phai cung cau truc
                    v_strSQL = "CREATE TABLE " & v_arrTABLE(i).ToUpper & "MEMO AS (SELECT * FROM " & v_arrTABLE(i).ToUpper & " WHERE 0=1)"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'Return ERR_SYSTEM_OK
                Else
                    'Kiem tra tuong thich giua hai bang
                    v_strSQL = "select column_name, data_type, data_length from user_tab_cols where table_name='" & ATTR_TABLE.ToUpper & "' and data_type <> 'RAW'" & ControlChars.CrLf &
                               "MINUS select column_name, data_type, data_length from user_tab_cols where table_name='" & ATTR_TABLE.ToUpper & "MEMO' and data_type <> 'RAW'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If Not v_ds.Tables(0).Rows.Count = 0 Then
                        LogError.Write("Error source: VerifyMemoTable." & Me.ATTR_TABLE & vbNewLine _
                                     & "Error code: -2!" & vbNewLine _
                                     & "Error message: " & Me.ATTR_TABLE & " has some fields not in MEMO", "EventLogEntryType.Error")
                        Return -2
                    Else
                        v_strSQL = "select column_name, data_type, data_length from user_tab_cols where table_name='" & ATTR_TABLE.ToUpper & "MEMO' and data_type <> 'RAW'" & ControlChars.CrLf &
                                   "MINUS select column_name, data_type, data_length from user_tab_cols where table_name='" & ATTR_TABLE.ToUpper & "' and data_type <> 'RAW'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        If Not v_ds.Tables(0).Rows.Count = 0 Then
                            LogError.Write("Error source: VerifyMemoTable." & Me.ATTR_TABLE & vbNewLine _
                                         & "Error code: -2!" & vbNewLine _
                                         & "Error message: " & Me.ATTR_TABLE & "MEMO has some fields not in master", "EventLogEntryType.Error")
                            Return -2
                        End If
                    End If
                End If
            End If
        Next

        Return ERR_SYSTEM_OK
    End Function


    Public Function RunApprExecSql(ByRef pv_xmlDocument As XmlDocumentEx, ByVal pv_ActionFlag As String, ByVal pv_SqlCommand As String, ByVal pv_SqlCommandType As String, ByVal pv_SqlCommandMemo As String) As Long

        Dim v_lngErrorCode As Long, v_strErrorSource As String, v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strChildClause, v_strChildObjName As String
        Dim v_strLocal As String
        Dim v_strCurrTime As String
        Dim v_strAutoId, v_strParentObjName, v_strParentClause, v_strObjName, v_strClause, v_strTXDATE As String
        Dim v_strSQL As String
        Dim v_arrParamValues As Object()
        Dim v_arrParamNames As Object()
        Dim v_arrParamTypes As Object()


        If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
            v_strLocal = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
        Else
            v_strLocal = "N"
        End If

        ' Neu cau lenh chi duoc thuc hien khi Approve thi thuc hien ghi log toan bo cac cau lenh ExecuteNonQuery
        If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
            v_strChildClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
        Else
            v_strChildClause = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributeAUTOID) Is Nothing) Then
            v_strAutoId = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeAUTOID), Xml.XmlAttribute).Value)
        Else
            v_strAutoId = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME) Is Nothing) Then
            v_strParentObjName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTOBJNAME), Xml.XmlAttribute).Value)
        Else
            v_strParentObjName = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE) Is Nothing) Then
            v_strParentClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributePARENTCLAUSE), Xml.XmlAttribute).Value)
        Else
            v_strParentClause = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
            v_strObjName = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeOBJNAME), Xml.XmlAttribute).Value)
        Else
            v_strObjName = String.Empty
        End If

        If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
            v_strClause = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
        Else
            v_strClause = String.Empty
        End If

        'Inquiry data
        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess()
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        If (v_strParentClause = "") Then
            'Neu la parent tab
            v_strParentClause = v_strChildClause
            v_strChildClause = ""
            v_strParentObjName = ATTR_TABLE
            v_strChildObjName = ""
        Else
            'Neu la child tab
            v_strParentObjName = Mid(v_strParentObjName, 4)
            v_strChildObjName = ATTR_TABLE
        End If

        Dim v_ds As DataSet
        Dim v_strSQLUpdate As String
        Dim RunAtApprove As String = "N"
        Dim RunChildAtApprove As String = "N"
        v_strSQL = "SELECT ADDATAPPR, EDITATAPPR, DELATAPPR, ADDCHILDATAPPR FROM APPRVRQD WHERE OBJNAME = '" & ATTR_TABLE & "'"

        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count = 0 Then
            RunAtApprove = "N"
        Else
            If pv_ActionFlag = "ADD" Then
                RunAtApprove = v_ds.Tables(0).Rows(0)("ADDATAPPR")
            ElseIf pv_ActionFlag = "EDIT" Then
                RunAtApprove = v_ds.Tables(0).Rows(0)("EDITATAPPR")
            ElseIf pv_ActionFlag = "DELETE" Then
                RunAtApprove = v_ds.Tables(0).Rows(0)("DELATAPPR")
            End If
            RunChildAtApprove = v_ds.Tables(0).Rows(0)("ADDCHILDATAPPR")
        End If


        If (v_strChildObjName = "CFSIGN" Or v_strChildObjName = "CFAUTH" Or v_strChildObjName = "DDMAST" Or v_strChildObjName = "CFRELATION") And pv_ActionFlag <> "DELETE" Then

            Dim v_nodeList As Xml.XmlNodeList, i As Integer
            Dim v_strFLDNAME As String, v_strFLDTYPE As String
            Dim v_strAUTOIDs, v_strCUSTID, v_strSIGNATURE, v_strVALDATE, v_strEXPDATE, v_strDESC, v_HOLDING, v_EMAIL As String
            Dim v_LINKAUTH, v_FULLNAME, v_ADDRESS, v_TELEPHONE, v_LICENSENO, v_BANKNAME, v_LNPLACE, v_LNIDDATE As String
            Dim v_ACDATE, v_RETYPE, v_RECUSTID, v_ACTIVES, v_DESCRIPTION, v_TITLECFRELATION As String

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            If v_strChildObjName = "CFSIGN" Then

                For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                        Select Case v_strFLDNAME
                            Case "AUTOID"
                                v_strAUTOIDs = .InnerText.ToString
                            Case "CUSTID"
                                v_strCUSTID = .InnerText.ToString
                            Case "SIGNATURE"
                                v_strSIGNATURE = .InnerText.ToString
                            Case "VALDATE"
                                v_strVALDATE = .InnerText.ToString
                            Case "EXPDATE"
                                v_strEXPDATE = .InnerText.ToString
                            Case "DESCRIPTION"
                                v_strDESC = .InnerText.ToString
                        End Select
                    End With
                Next
                ReDim v_arrParamValues(5)
                ReDim v_arrParamNames(5)
                ReDim v_arrParamTypes(5)

                v_arrParamValues(0) = v_strCUSTID
                v_arrParamValues(1) = v_strSIGNATURE
                v_arrParamValues(2) = v_strVALDATE
                v_arrParamValues(3) = v_strEXPDATE
                v_arrParamValues(4) = IIf(pv_ActionFlag = "ADD", CDbl(Replace(Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value), "'", "")), v_strAUTOIDs)
                v_arrParamValues(5) = v_strDESC

                v_arrParamNames(0) = "CUSTID"
                v_arrParamNames(1) = "SIGNATURE"
                v_arrParamNames(2) = "VALDATE"
                v_arrParamNames(3) = "EXPDATE"
                v_arrParamNames(4) = "AUTOID"
                v_arrParamNames(5) = "DESCRIPTION"

                v_arrParamTypes(0) = "OracleDbType.Varchar2"
                v_arrParamTypes(1) = "OracleDbType.Varchar2"
                v_arrParamTypes(2) = "OracleDbType.Varchar2"
                v_arrParamTypes(3) = "OracleDbType.Varchar2"
                v_arrParamTypes(4) = "OracleDbType.Number"
                v_arrParamTypes(5) = "OracleDbType.Varchar2"
            ElseIf v_strChildObjName = "DDMAST" Then
                Dim v_strAFACCTNO, v_strACCOUNTTYPE As String
                Dim v_strCUSTODYCD, v_strACCTNO, v_strCCYCD, v_strREFCASAACCT, v_strOPNDATE As String
                For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                        Select Case v_strFLDNAME
                            Case "AUTOID"
                                v_strAUTOIDs = .InnerText.ToString
                            Case "CUSTID"
                                v_strCUSTID = .InnerText.ToString
                            Case "AFACCTNO"
                                v_strAFACCTNO = .InnerText.ToString
                            Case "CUSTODYCD"
                                v_strCUSTODYCD = .InnerText.ToString
                            Case "ACCTNO"
                                v_strACCTNO = .InnerText.ToString
                            Case "CCYCD"
                                v_strCCYCD = .InnerText.ToString
                            Case "REFCASAACCT"
                                v_strREFCASAACCT = .InnerText.ToString
                            Case "OPNDATE"
                                v_strOPNDATE = .InnerText.ToString
                            Case "ACCOUNTTYPE"
                                v_strACCOUNTTYPE = .InnerText.ToString
                        End Select
                    End With
                Next
                ReDim v_arrParamValues(8)
                ReDim v_arrParamNames(8)
                ReDim v_arrParamTypes(8)

                v_arrParamValues(0) = v_strCUSTID
                v_arrParamValues(1) = v_strAFACCTNO
                v_arrParamValues(2) = v_strCUSTODYCD
                v_arrParamValues(3) = v_strACCTNO
                v_arrParamValues(4) = IIf(pv_ActionFlag = "ADD", CDbl(Replace(Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value), "'", "")), v_strAUTOIDs)
                v_arrParamValues(5) = v_strCCYCD
                v_arrParamValues(6) = v_strREFCASAACCT
                v_arrParamValues(7) = v_strOPNDATE
                v_arrParamValues(8) = v_strACCOUNTTYPE

                v_arrParamNames(0) = "CUSTID"
                v_arrParamNames(1) = "AFACCTNO"
                v_arrParamNames(2) = "CUSTODYCD"
                v_arrParamNames(3) = "ACCTNO"
                v_arrParamNames(4) = "AUTOID"
                v_arrParamNames(5) = "CCYCD"
                v_arrParamNames(6) = "REFCASAACCT"
                v_arrParamNames(7) = "OPNDATE"
                v_arrParamNames(8) = "ACCOUNTTYPE"

                v_arrParamTypes(0) = "OracleDbType.Varchar2"
                v_arrParamTypes(1) = "OracleDbType.Varchar2"
                v_arrParamTypes(2) = "OracleDbType.Varchar2"
                v_arrParamTypes(3) = "OracleDbType.Varchar2"
                v_arrParamTypes(4) = "OracleDbType.Number"
                v_arrParamTypes(5) = "OracleDbType.Varchar2"
                v_arrParamTypes(6) = "OracleDbType.Varchar2"
                v_arrParamTypes(7) = "OracleDbType.date"
                v_arrParamTypes(8) = "OracleDbType.Varchar"
            ElseIf v_strChildObjName = "CFAUTH" Then

                For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                        Select Case v_strFLDNAME
                            Case "AUTOID"
                                v_strAUTOIDs = .InnerText.ToString
                            Case "CFCUSTID"
                                v_strCUSTID = .InnerText.ToString
                            Case "SIGNATURE"
                                v_strSIGNATURE = .InnerText.ToString
                            Case "VALDATE"
                                v_strVALDATE = .InnerText.ToString
                            Case "EXPDATE"
                                v_strEXPDATE = .InnerText.ToString
                            Case "LINKAUTH"
                                v_LINKAUTH = .InnerText.ToString
                            Case "FULLNAME"
                                v_FULLNAME = .InnerText.ToString
                            Case "ADDRESS"
                                v_ADDRESS = .InnerText.ToString
                            Case "TELEPHONE"
                                v_TELEPHONE = .InnerText.ToString
                            Case "LICENSENO"
                                v_LICENSENO = .InnerText.ToString
                            Case "BANKNAME"
                                v_BANKNAME = .InnerText.ToString
                            Case "LNPLACE"
                                v_LNPLACE = .InnerText.ToString
                            Case "LNIDDATE"
                                v_LNIDDATE = .InnerText.ToString
                        End Select
                    End With
                Next

                ReDim v_arrParamValues(12)
                ReDim v_arrParamNames(12)
                ReDim v_arrParamTypes(12)

                v_arrParamValues(0) = v_strCUSTID
                v_arrParamValues(1) = v_strSIGNATURE
                v_arrParamValues(2) = v_strVALDATE
                v_arrParamValues(3) = v_strEXPDATE
                v_arrParamValues(4) = IIf(pv_ActionFlag = "ADD", CDbl(Replace(Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value), "'", "")), v_strAUTOIDs)
                v_arrParamValues(5) = v_LINKAUTH
                v_arrParamValues(6) = v_FULLNAME
                v_arrParamValues(7) = v_ADDRESS
                v_arrParamValues(8) = v_TELEPHONE
                v_arrParamValues(9) = v_LICENSENO
                v_arrParamValues(10) = v_BANKNAME
                v_arrParamValues(11) = v_LNPLACE
                v_arrParamValues(12) = v_LNIDDATE


                v_arrParamNames(0) = "CFCUSTID"
                v_arrParamNames(1) = "SIGNATURE"
                v_arrParamNames(2) = "VALDATE"
                v_arrParamNames(3) = "EXPDATE"
                v_arrParamNames(4) = "AUTOID"
                v_arrParamNames(5) = "LINKAUTH"
                v_arrParamNames(6) = "FULLNAME"
                v_arrParamNames(7) = "ADDRESS"
                v_arrParamNames(8) = "TELEPHONE"
                v_arrParamNames(9) = "LICENSENO"
                v_arrParamNames(10) = "BANKNAME"
                v_arrParamNames(11) = "LNPLACE"
                v_arrParamNames(12) = "LNIDDATE"



                v_arrParamTypes(0) = "OracleDbType.Varchar2"
                v_arrParamTypes(1) = "OracleDbType.Varchar2"
                v_arrParamTypes(2) = "OracleDbType.Varchar2"
                v_arrParamTypes(3) = "OracleDbType.Varchar2"
                v_arrParamTypes(4) = "OracleDbType.Number"
                v_arrParamTypes(5) = "OracleDbType.Varchar2"
                v_arrParamTypes(6) = "OracleDbType.Varchar2"
                v_arrParamTypes(7) = "OracleDbType.Varchar2"
                v_arrParamTypes(8) = "OracleDbType.Varchar2"
                v_arrParamTypes(9) = "OracleDbType.Varchar2"
                v_arrParamTypes(10) = "OracleDbType.Varchar2"
                v_arrParamTypes(11) = "OracleDbType.Varchar2"
                v_arrParamTypes(12) = "OracleDbType.Varchar2"


            ElseIf v_strChildObjName = "CFRELATION" Then
                For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(i)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                        Select Case v_strFLDNAME
                            Case "AUTOID"
                                v_strAUTOIDs = .InnerText.ToString
                            Case "CUSTID"
                                v_strCUSTID = .InnerText.ToString
                            Case "SIGNATURE"
                                v_strSIGNATURE = .InnerText.ToString
                            Case "ACDATE"
                                v_ACDATE = .InnerText.ToString
                            Case "FULLNAME"
                                v_FULLNAME = .InnerText.ToString
                            Case "ADDRESS"
                                v_ADDRESS = .InnerText.ToString
                            Case "TELEPHONE"
                                v_TELEPHONE = .InnerText.ToString
                            Case "LICENSENO"
                                v_LICENSENO = .InnerText.ToString
                            Case "HOLDING"
                                v_HOLDING = .InnerText.ToString
                            Case "EMAIL"
                                v_EMAIL = .InnerText.ToString
                            Case "BANKNAME"
                                v_BANKNAME = .InnerText.ToString
                            Case "LNPLACE"
                                v_LNPLACE = .InnerText.ToString
                            Case "LNIDDATE"
                                v_LNIDDATE = .InnerText.ToString
                            Case "RETYPE"
                                v_RETYPE = .InnerText.ToString
                            Case "RECUSTID"
                                v_RECUSTID = .InnerText.ToString
                            Case "ACTIVES"
                                v_ACTIVES = .InnerText.ToString
                            Case "DESCRIPTION"
                                v_DESCRIPTION = .InnerText.ToString
                            Case "TITLECFRELATION"
                                v_TITLECFRELATION = .InnerText.ToString
                        End Select
                    End With
                Next

                ReDim v_arrParamValues(16)
                ReDim v_arrParamNames(16)
                ReDim v_arrParamTypes(16)

                v_arrParamValues(0) = v_strCUSTID
                v_arrParamValues(1) = v_strSIGNATURE
                v_arrParamValues(2) = v_ACDATE
                v_arrParamValues(3) = IIf(pv_ActionFlag = "ADD", CDbl(Replace(Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value), "'", "")), v_strAUTOIDs)
                v_arrParamValues(4) = v_FULLNAME
                v_arrParamValues(5) = v_ADDRESS
                v_arrParamValues(6) = v_TELEPHONE
                v_arrParamValues(7) = v_LICENSENO
                v_arrParamValues(8) = v_LNPLACE
                v_arrParamValues(9) = v_LNIDDATE
                v_arrParamValues(10) = v_RETYPE
                v_arrParamValues(11) = v_RECUSTID
                v_arrParamValues(12) = v_ACTIVES
                v_arrParamValues(13) = v_DESCRIPTION
                v_arrParamValues(14) = v_HOLDING
                v_arrParamValues(15) = v_EMAIL
                v_arrParamValues(16) = v_TITLECFRELATION


                v_arrParamNames(0) = "CUSTID"
                v_arrParamNames(1) = "SIGNATURE"
                v_arrParamNames(2) = "ACDATE"
                v_arrParamNames(3) = "AUTOID"
                v_arrParamNames(4) = "FULLNAME"
                v_arrParamNames(5) = "ADDRESS"
                v_arrParamNames(6) = "TELEPHONE"
                v_arrParamNames(7) = "LICENSENO"
                v_arrParamNames(8) = "LNPLACE"
                v_arrParamNames(9) = "LNIDDATE"
                v_arrParamNames(10) = "RETYPE"
                v_arrParamNames(11) = "RECUSTID"
                v_arrParamNames(12) = "ACTIVES"
                v_arrParamNames(13) = "DESCRIPTION"
                v_arrParamNames(14) = "HOLDING"
                v_arrParamNames(15) = "EMAIL"
                v_arrParamNames(16) = "TITLECFRELATION"


                v_arrParamTypes(0) = "OracleDbType.Varchar2"
                v_arrParamTypes(1) = "OracleDbType.Varchar2"
                v_arrParamTypes(2) = "OracleDbType.Varchar2"
                v_arrParamTypes(3) = "OracleDbType.Number"
                v_arrParamTypes(4) = "OracleDbType.Varchar2"
                v_arrParamTypes(5) = "OracleDbType.Varchar2"
                v_arrParamTypes(6) = "OracleDbType.Varchar2"
                v_arrParamTypes(7) = "OracleDbType.Varchar2"
                v_arrParamTypes(8) = "OracleDbType.Varchar2"
                v_arrParamTypes(9) = "OracleDbType.Varchar2"
                v_arrParamTypes(10) = "OracleDbType.Varchar2"
                v_arrParamTypes(11) = "OracleDbType.Varchar2"
                v_arrParamTypes(12) = "OracleDbType.Varchar2"
                v_arrParamTypes(13) = "OracleDbType.Varchar2"
                v_arrParamTypes(14) = "OracleDbType.Varchar2"
                v_arrParamTypes(15) = "OracleDbType.Varchar2"
                v_arrParamTypes(16) = "OracleDbType.Varchar2"

            End If
        End If


        If RunAtApprove = "N" Then
            If pv_ActionFlag = "ADD" And v_strChildObjName = "CFSIGN" Then
                v_obj.ExecuteNonQuery("INSERT_CFSIGN", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "ADD" And v_strChildObjName = "CFAUTH" Then
                v_obj.ExecuteNonQuery("INSERT_CFAUTH", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "ADD" And v_strChildObjName = "CFRELATION" Then
                v_obj.ExecuteNonQuery("INSERT_CFRELATION", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "EDIT" And v_strChildObjName = "CFSIGN" Then
                v_obj.ExecuteNonQuery("UPDATE_CFSIGN", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "EDIT" And v_strChildObjName = "CFAUTH" Then
                v_obj.ExecuteNonQuery("UPDATE_CFAUTH", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "EDIT" And v_strChildObjName = "CFRELATION" Then
                v_obj.ExecuteNonQuery("UPDATE_CFRELATION", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            Else
                v_obj.ExecuteNonQuery(CommandType.Text, pv_SqlCommand)
            End If

            Return ERR_SYSTEM_OK
        Else
            ' Đã sửa lại cách lấy số Tự tăng của AFMAST
            ''Check voi truong hop khi ChildObject them moi van coi nhu la duyet, phai kiem tra de tranh' trung`
            'If pv_ActionFlag = "ADD" And RunChildAtApprove = "Y" Then
            '    If ATTR_TABLE = "AFMAST" Then
            '        v_strSQL = "SELECT count(*) COUNT FROM apprvexec WHERE CHILD_RECORD_KEY = '" & Replace(v_strChildClause, "'", "''") & "' AND STATUS ='N' AND ACTION_FLAG = 'ADD'"
            '    Else
            '        v_strSQL = "SELECT count(*) COUNT FROM apprvexec WHERE RECORD_KEY = '" & Replace(v_strParentClause, "'", "''") & "' AND NVL(CHILD_RECORD_KEY,' ') = '" & IIf(Trim(Replace(v_strChildClause, "'", "''")).Length = 0, " ", Replace(v_strChildClause, "'", "''")) & "' AND STATUS ='N' AND ACTION_FLAG = 'ADD'"
            '    End If

            '    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            '    If CDbl(v_ds.Tables(0).Rows(0)("COUNT")) > 0 Then
            '        Return ERROR_SA_INVALID_DATA
            '        Exit Function
            '    End If
            'End If
            If pv_ActionFlag = "ADD" And v_strChildObjName = "CFSIGN" Then
                v_obj.ExecuteNonQuery("INSERT_CFSIGNMEMO", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "ADD" And v_strChildObjName = "CFAUTH" Then
                v_obj.ExecuteNonQuery("INSERT_CFAUTH", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "ADD" And v_strChildObjName = "CFRELATION" Then
                v_obj.ExecuteNonQuery("INSERT_CFRELATION", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "EDIT" And v_strChildObjName = "CFSIGN" Then
                v_obj.ExecuteNonQuery("UPDATE_CFSIGNMEMO", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "EDIT" And v_strChildObjName = "CFAUTH" Then
                v_obj.ExecuteNonQuery("UPDATE_CFAUTH", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            ElseIf pv_ActionFlag = "EDIT" And v_strChildObjName = "CFRELATION" Then
                v_obj.ExecuteNonQuery("UPDATE_CFRELATION", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
            Else
                'Ghi nhan du lieu vao bang MEMO
                v_obj.ExecuteNonQuery(CommandType.Text, pv_SqlCommandMemo)
            End If


            'Náº¿u lÃ  Add thÃ¬ váº«n cho lÆ°u vÃ o báº£ng master (nhÆ°ng lÃºc nÃ y tráº¡ng thÃ¡i lÃ  pending Ä‘á»ƒ khÃ´ng pháº£i sá»­a nhá»¯ng chá»— check trÃ¹ng)
            If pv_ActionFlag = "ADD" And RunChildAtApprove = "N" Then 'And v_strParentObjName.Length = 0 Then
                If v_strChildObjName = "CFSIGN" Then
                    v_obj.ExecuteNonQuery("INSERT_CFSIGN", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
                ElseIf v_strChildObjName = "CFAUTH" Then
                    v_obj.ExecuteNonQuery("INSERT_CFAUTH", v_arrParamNames, v_arrParamValues, v_arrParamTypes)
                Else
                    v_obj.ExecuteNonQuery(CommandType.Text, pv_SqlCommand)
                End If
            End If
        End If


        Dim makerId As String = Convert.ToString(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

        If ATTR_TABLE = "CFAUTH" And pv_ActionFlag = gc_ActionAdd Then
            v_strChildClause = "AUTOID = " & autoidCFAuth & ""
        End If
        'Kiem tra du lieu duoc thay doi co nam trong dach sach yeu cau duyet ko
        Dim rqdString As String
        Dim apprvRequired As Char = "Y"
        'Dim oldStatus As String
        Dim modNum As String
        Dim updateStatus As Boolean = False
        Dim v_logSQL As String

        'TruongLD Add 07/10/2011/>
        v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE VARNAME ='CURRDATE'"
        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count = 0 Then
            v_strTXDATE = String.Empty
        Else
            v_strTXDATE = v_ds.Tables(0).Rows(0)(0)
        End If
        'TruongLD/>
        If pv_ActionFlag = "ADD" And RunChildAtApprove = "N" Then
        Else
            If (pv_ActionFlag = "ADD" Or pv_ActionFlag = "EDIT") And (v_strChildObjName = "CFSIGN" Or v_strChildObjName = "CFAUTH") Then


                ReDim v_arrParamValues(8)
                ReDim v_arrParamNames(8)
                ReDim v_arrParamTypes(8)

                v_arrParamValues(0) = v_strParentObjName
                v_arrParamValues(1) = v_strParentClause
                v_arrParamValues(2) = v_strChildObjName
                v_arrParamValues(3) = v_strChildClause
                v_arrParamValues(4) = pv_ActionFlag
                v_arrParamValues(5) = pv_SqlCommand
                v_arrParamValues(6) = pv_SqlCommandType
                v_arrParamValues(7) = "N"
                v_arrParamValues(8) = v_strTXDATE

                v_arrParamNames(0) = "PARENTOBJNAME"
                v_arrParamNames(1) = "PARENTCLAUSE"
                v_arrParamNames(2) = "CHILDOBJNAME"
                v_arrParamNames(3) = "CHILDCLAUSE"
                v_arrParamNames(4) = "ACTIONFLAG"
                v_arrParamNames(5) = "SQLCOMMAND"
                v_arrParamNames(6) = "SQLCOMMANDTYPE"
                v_arrParamNames(7) = "STATUS"
                v_arrParamNames(8) = "TXDATE"

                v_arrParamTypes(0) = "OracleDbType.Varchar2"
                v_arrParamTypes(1) = "OracleDbType.Varchar2"
                v_arrParamTypes(2) = "OracleDbType.Varchar2"
                v_arrParamTypes(3) = "OracleDbType.Varchar2"
                v_arrParamTypes(4) = "OracleDbType.Varchar2"
                v_arrParamTypes(5) = "OracleDbType.Varchar2"
                v_arrParamTypes(6) = "OracleDbType.Varchar2"
                v_arrParamTypes(7) = "OracleDbType.Varchar2"
                v_arrParamTypes(8) = "OracleDbType.Varchar2"

                v_obj.ExecuteNonQuery("INSERT_APPRVEXEC", v_arrParamNames, v_arrParamValues, v_arrParamTypes)

            Else

                v_logSQL = "Insert into apprvexec (autoid,table_name,record_key,child_table_name,child_record_key,action_flag,sqlcmd,sqlcmdtype,status,make_dt,maketime) values " &
                       "(seq_apprvexec.nextval,'" & v_strParentObjName & "','" & Replace(v_strParentClause, "'", "''") & "', '" & v_strChildObjName & "', '" & Replace(v_strChildClause, "'", "''") & "','" & pv_ActionFlag & "','" & Replace(pv_SqlCommand, "'", "''") & "','" & pv_SqlCommandType & "','N',To_Date('" & v_strTXDATE & "','DD/MM/RRRR'), SYSTIMESTAMP)"

                v_obj.ExecuteNonQuery(CommandType.Text, v_logSQL)

            End If

        End If
        Return ERR_SYSTEM_OK

    End Function


    Public Function GetErrorDefine() As String
        Dim v_strSQL As String
        Dim v_ds As DataSet
        Dim v_obj As DataAccess = New DataAccess()
        v_obj.NewDBInstance(gc_MODULE_HOST)

        v_strSQL = "SELECT ERRNUM, ERRDESC, EN_ERRDESC FROM DEFERROR  "
        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
        If v_ds.Tables(0).Rows.Count = 0 Then
            'Khong dinh nghia yeu cau duyet
            Return ""
        Else
            Return v_ds.GetXml
        End If
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function SystemProcessBeforeAdd(ByRef v_strMessage As String) As Long
        Complete() 'ContextUtil.SetComplete()
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function SystemProcessBeforeEdit(ByRef v_strMessage As String) As Long
        Complete() 'ContextUtil.SetComplete()
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function SystemProcessBeforeDelete(ByRef v_strMessage As String) As Long
        Complete() 'ContextUtil.SetComplete()
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function CheckBeforeDelete(ByVal v_strMessage As String) As Long
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function ProcessAfterAdd(ByVal v_strMessage As String) As Long
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function ProcessAfterEdit(ByVal v_strMessage As String) As Long
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function ProcessAfterDelete(ByVal v_strMessage As String) As Long
        Return ERR_SYSTEM_OK
    End Function

    Overridable Function ProcessAfterApprove(ByVal v_strMessage As String) As Long
        Return ERR_SYSTEM_OK
    End Function

    'TruongLD Add Bo BDS
    Overridable Function ProcessAfterInquiry(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Return ERR_SYSTEM_OK
    End Function
    'End TruongLD

    Overridable Function Add(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreAdd(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Add"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function Edit(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreEdit(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Edit"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function Delete(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreDelete(pv_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Delete"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function Inquiry(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Try
            v_lngErrCode = CoreInquiry(pv_xmlDocument)
            'TruongLD Add bo BDS
            v_lngErrCode = ProcessAfterInquiry(pv_xmlDocument)
            'End TruongLD

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Dim v_strErrorSource, v_strErrorMessage As String
                v_strErrorSource = Me.ATTR_TABLE + ".Inquiry"
                v_strErrorMessage = String.Empty

                LogError.Write("Error source: " + v_strErrorSource + vbNewLine _
                             + "Error code: " + v_lngErrCode.ToString() + vbNewLine _
                             + "Error message: " + v_strErrorMessage, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            End If
            v_strMessage = pv_xmlDocument.InnerXml
            Return v_lngErrCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overridable Function Adhoc(ByRef v_strMessage As String) As Long
        Return ERR_SYSTEM_OK
    End Function
#End Region

End Class
