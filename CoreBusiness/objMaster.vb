Imports DataAccessLayer
Imports HostCommonLibrary
Imports System.Data

Public Interface IMaster
    Function Add(ByRef pv_xmlDocument As XmlDocumentEx) As Long
    Function Edit(ByRef pv_xmlDocument As XmlDocumentEx) As Long
    Function Delete(ByRef pv_xmlDocument As XmlDocumentEx) As Long
    Function Inquiry(ByRef pv_xmlDocument As XmlDocumentEx) As Long
    Function Adhoc(ByRef pv_xmlDocument As XmlDocumentEx) As Long
End Interface

'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Supported), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class objMaster
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Dim mv_sTABLE As String

#Region "Property"
    Public Property ATTR_TABLE() As String
        Get
            Return mv_sTABLE
        End Get
        Set(ByVal Value As String)
            mv_sTABLE = Value
        End Set
    End Property
#End Region

#Region "Core Functions"
    Public Function CoreAdd(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
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

        v_lngErrorCode = CheckBeforeAdd(pv_xmlDocument)

        If v_lngErrorCode <> 0 Then
            Rollback() 'ContextUtil.SetAbort()
            Return v_lngErrorCode
            Exit Function
        End If

        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strClause As String
        Dim v_strLocal As String
        Dim v_strAutoId As String

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

        'Inquiry data
        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_ds As DataSet

        Dim v_strSQL As String = "INSERT INTO " & ATTR_TABLE
        Dim v_strListOfFields As String = vbNullString
        Dim v_strListOfValues As String = vbNullString
        Dim v_strSignature As String = String.Empty
        Dim v_strCustID As String = String.Empty


        Dim v_decID As Decimal
        If (v_strAutoId = gc_AutoIdUsed) Then
            v_decID = v_obj.GetIDValue(ATTR_TABLE)
        End If

        'Cập nhật vào CSDL
        Dim v_nodeList As Xml.XmlNodeList, i As Integer
        Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

        v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            With v_nodeList.Item(0).ChildNodes(i)
                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                If v_strFLDNAME = "AUTOID" Then
                    v_strNewValue = v_decID
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
                            Case Else
                                v_strListOfValues = "(" & v_strNewValue
                        End Select
                    Else
                        v_strListOfFields = v_strListOfFields & "," & v_strFLDNAME
                        Select Case v_strFLDTYPE
                            Case "System.String"
                                v_strListOfValues = v_strListOfValues & ",'" & v_strNewValue.Replace("'", "''") & "'"
                            Case "System.DateTime"
                                v_strListOfValues = v_strListOfValues & ",TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
                            Case GetType(Double).Name
                                v_strListOfValues = v_strListOfValues & "," & Replace(v_strNewValue, ",", "")
                            Case Else
                                v_strListOfValues = v_strListOfValues & "," & v_strNewValue
                        End Select
                    End If
                End If
            End With
        Next

        If Len(v_strListOfFields) <> 0 Then
            v_strListOfFields = v_strListOfFields & ")"
            v_strListOfValues = v_strListOfValues & ")"
            v_strSQL = v_strSQL & " " & v_strListOfFields & " VALUES " & v_strListOfValues
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        End If
        Complete() 'ContextUtil.SetComplete()
        Return 0
    End Function

    Public Function CoreEdit(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
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

        v_lngErrorCode = CheckBeforeEdit(pv_xmlDocument)
        If v_lngErrorCode <> 0 Then
            Rollback() 'ContextUtil.SetAbort()
            Return v_lngErrorCode
            Exit Function
        End If

        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strClause As String
        Dim v_strLocal As String

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

        'Update data
        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_ds As DataSet
        Dim v_strSQL As String = "UPDATE " & ATTR_TABLE & " SET ", v_strUPD As String = vbNullString, v_strUPDTMP As String = vbNullString

        Dim v_nodeList As Xml.XmlNodeList, i As Integer
        Dim v_strNewValue As String, v_strOldValue As String, v_strFLDNAME As String, v_strFLDTYPE As String

        v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
            With v_nodeList.Item(0).ChildNodes(i)
                v_strOldValue = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                v_strNewValue = .InnerText.ToString
                If Trim(v_strOldValue) <> Trim(v_strNewValue) Then
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                    Select Case v_strFLDTYPE
                        Case "System.String"
                            v_strUPDTMP = v_strFLDNAME & " = '" & v_strNewValue.Replace("'", "''") & "'"
                        Case "System.DateTime"
                            v_strUPDTMP = v_strFLDNAME & " = TO_DATE('" & v_strNewValue & "', '" & gc_FORMAT_DATE & "')"
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
                Else
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                End If
            End With
        Next

        If Len(v_strUPD) <> 0 Then
            v_strSQL = v_strSQL & v_strUPD & " WHERE 0=0 AND " & v_strClause
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        End If
        Complete() 'ContextUtil.SetComplete()
        Return 0
    End Function

    Public Function CoreDelete(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_lngErrorCode As Long
        Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
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

        v_lngErrorCode = CheckBeforeDelete(pv_xmlDocument)
        If v_lngErrorCode <> 0 Then
            Rollback() 'ContextUtil.SetAbort()
            Return v_lngErrorCode
            Exit Function
        End If

        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strClause As String
        Dim v_strLocal As String

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

        'Delete data
        Dim v_obj As DataAccess
        If v_strLocal = "Y" Then
            v_obj = New DataAccess
        ElseIf v_strLocal = "N" Then
            v_obj = New DataAccess
            v_obj.NewDBInstance(gc_MODULE_HOST)
        End If

        Dim v_strSQL As String = "DELETE FROM " & ATTR_TABLE & " WHERE 0=0 AND " & v_strClause

        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
        Complete() 'ContextUtil.SetComplete()
        Return 0
    End Function

    Public Function CoreInquiry(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes

        Dim v_strClause As String
        Dim v_strLocal As String
        Dim v_strCmdInquiry As String
        Dim v_strCmdType As String
        Dim v_obj As DataAccess
        Dim i As Integer, j As Integer
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

            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            If v_strCmdType = gc_CommandProcedure Then
                'Cau truy van truyen vao dang CommandProcedure, khong truyen tham so dau vao
                Dim v_arrStrClause() As String
                Dim v_objRptParam As ReportParameters
                Dim v_arrRptPara() As ReportParameters
                v_arrStrClause = v_strClause.Split("^")
                ReDim v_arrRptPara(v_arrStrClause.GetLength(0) - 1)
                For i = 0 To v_arrStrClause.GetLength(0) - 1
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

            'Create data
            Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_attrFLDNAME As Xml.XmlAttribute, v_attrFLDTYPE As Xml.XmlAttribute, v_attrLENGTH As Xml.XmlAttribute, v_attrOLDVAL As Xml.XmlAttribute

            For i = 0 To v_ds.Tables(0).Rows.Count - 1
                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")
                For j = 0 To v_ds.Tables(0).Columns.Count - 1
                    'Append entry to data node
                    v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                    'Add field name
                    v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
                    v_attrFLDNAME.Value = v_ds.Tables(0).Columns(j).ColumnName
                    v_entryNode.Attributes.Append(v_attrFLDNAME)

                    'Add field type
                    v_attrFLDTYPE = pv_xmlDocument.CreateAttribute("fldtype")
                    v_attrFLDTYPE.Value = v_ds.Tables(0).Columns(j).DataType.ToString
                    v_entryNode.Attributes.Append(v_attrFLDTYPE)

                    'Add current value
                    v_attrOLDVAL = pv_xmlDocument.CreateAttribute("oldval")
                    If IsDBNull((v_ds.Tables(0).Rows(i)(j))) Then
                        If v_ds.Tables(0).Rows(i)(j).GetType.Name = GetType(System.DateTime).Name _
                            Or v_ds.Tables(0).Rows(i)(j).GetType.Name = GetType(System.String).Name Then
                            v_attrOLDVAL.Value = ""
                        Else
                            v_attrOLDVAL.Value = "0"
                        End If

                    Else
                        If v_ds.Tables(0).Rows(i)(j).GetType.Name = GetType(System.DateTime).Name Then
                            v_attrOLDVAL.Value = Format(v_ds.Tables(0).Rows(i)(j), gc_FORMAT_DATE)
                        Else
                            v_attrOLDVAL.Value = CStr(v_ds.Tables(0).Rows(i)(j))
                        End If
                    End If
                    v_entryNode.Attributes.Append(v_attrOLDVAL)

                    'Set value
                    If IsDBNull((v_ds.Tables(0).Rows(i)(j))) Then
                        v_entryNode.InnerText = ""
                    Else
                        If v_ds.Tables(0).Rows(i)(j).GetType.Name = GetType(System.DateTime).Name Then
                            v_entryNode.InnerText = Format(v_ds.Tables(0).Rows(i)(j), gc_FORMAT_DATE)
                        Else
                            v_entryNode.InnerText = CStr(v_ds.Tables(0).Rows(i)(j))
                        End If
                    End If

                    v_dataElement.AppendChild(v_entryNode)
                Next
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)
            Next

            v_ds.Dispose()
            Complete() 'ContextUtil.SetComplete()
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

#Region " Implement functions - Must override "
    Overridable Function CheckBeforeAdd(ByVal pv_xmlDocument As XmlDocumentEx) As Long
        Complete() 'ContextUtil.SetComplete()
        Return 0
    End Function

    Overridable Function CheckBeforeEdit(ByVal pv_xmlDocument As XmlDocumentEx) As Long
        Complete() 'ContextUtil.SetComplete()
        Return 0
    End Function

    Overridable Function CheckBeforeDelete(ByVal pv_xmlDocument As XmlDocumentEx) As Long
        Complete() 'ContextUtil.SetComplete()
        Return 0
    End Function
#End Region

End Class
