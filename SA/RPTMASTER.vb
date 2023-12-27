Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class RPTMASTER
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "RPTMASTER"
    End Sub

#Region " Overrides functions "

    Public Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument
        v_xmlDocument.LoadXml(v_strMessage)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strMODCODE, v_strOBJNAME, v_strSYNCMD, v_strBRID As String
        'QuÃ©t danh sÃ¡ch cÃ¡c báº£ng cáº§n Ä‘á»“ng bá»™ dá»¯ liá»‡u
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes

            v_strBRID = v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString()
            v_strFuncName = v_xmlDocument.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value.ToString()
            If v_strFuncName = gc_ActionEdit Then
                v_lngErrCode = OnChangeFeeRPT(v_xmlDocument)
            End If

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Function OnChangeFeeRPT(ByVal pv_xmlDocument As Xml.XmlDocument)
        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strParentId As String
            Dim v_strRPTID As String = String.Empty
            Dim v_strFEERPT As String = String.Empty

            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            Dim v_strCLAUSE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "RPTID"
                            v_strRPTID = Trim(v_strVALUE)
                        Case "FEERPT"
                            v_strFEERPT = Trim(v_strVALUE)
                    End Select

                End With
            Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            v_strSQL = "select RPTID from RPTMASTER_FEE where " & v_strCLAUSE
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strOldFee As String
            If v_ds.Tables.Count > 0 AndAlso v_ds.Tables(0).Rows.Count > 0 Then
                v_strOldFee = "Y"
            Else
                v_strOldFee = "N"
            End If

            If v_strOldFee = "Y" And v_strFEERPT = "N" Then
                v_strSQL = "BEGIN INSERT INTO rptmaster_fee_delt(autoid, rptid, tlid, createtime) SELECT * FROM rptmaster_fee; " _
                    & " DELETE RPTMASTER_FEE WHERE " & v_strCLAUSE & "; END;"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ElseIf v_strOldFee = "N" And v_strFEERPT = "Y" Then
                v_strSQL = "INSERT INTO rptmaster_fee (autoid, rptid, tlid) VALUES(seq_rptmaster_fee.nextval, '" & v_strRPTID & "', '" & v_strTLID & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If
        End Try
    End Function

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)


        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strParentId As String
            Dim v_strRPTID As String = String.Empty
            Dim v_strMODCODE As String = String.Empty

            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            Return ERR_SYSTEM_START

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "RPTID"
                            v_strRPTID = Trim(v_strVALUE)
                        Case "MODCODE"
                            v_strMODCODE = Trim(v_strVALUE)
                    End Select

                End With
            Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiểm tra RPTID không được trùng
            v_strSQL = "SELECT COUNT(RPTID) FROM " & ATTR_TABLE & " WHERE RPTID = '" & v_strRPTID & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) > 0 Then
                    Return ERR_SA_RPTID_DUPLICATED
                End If
            End If

            'Kiểm tra xem trường RPTID có tồn tại ở bảng cha không 
            'Bảng cha là bảng CMDAUTH 
            'Điều kiện là : RPTID = CMDCODE và CMDTYPE='R'
            v_strSQL = "SELECT COUNT(CMDCODE) FROM CMDAUTH WHERE CMDCODE = '" & v_strRPTID & "'" & " AND CMDTYPE='R'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_SA_CMDCODE_NOTFOUND
                End If
            End If

            'Kiểm tra xem trường mã phân hệ có đúng hay không
            v_strSQL = "SELECT COUNT(MODCODE) FROM APPMODULES WHERE MODCODE = '" & v_strMODCODE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_SA_MODCODE_NOTFOUND
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strParentId As String
            Dim v_strRPTID As String = String.Empty
            Dim v_strMODCODE As String = String.Empty

            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE As String
            Dim v_strSQL As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If

            v_nodeList = pv_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                With v_nodeList.Item(0).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strVALUE = .InnerText.ToString()

                    Select Case Trim(v_strFLDNAME)
                        Case "RPTID"
                            v_strRPTID = Trim(v_strVALUE)
                        Case "MODCODE"
                            v_strMODCODE = Trim(v_strVALUE)
                    End Select

                End With
            Next

            Dim v_obj As DataAccess
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Kiểm tra xem trường mã phân hệ có đúng hay không
            v_strSQL = "SELECT COUNT(MODCODE) FROM APPMODULES WHERE MODCODE = '" & v_strMODCODE & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) = 0 Then
                    Return ERR_SA_MODCODE_NOTFOUND
                End If
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
#End Region

End Class
