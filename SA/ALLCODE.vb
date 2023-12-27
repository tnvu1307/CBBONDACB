Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class ALLCODE
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "ALLCODE"
    End Sub

#Region " Overrides functions "
    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strBdsId, v_strParentId As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strCDTYPE, v_strCDNAME, v_strCDVAL, v_strLSTODR, v_strVALUE As String
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
                        Case "CDTYPE"
                            v_strCDTYPE = Trim(v_strVALUE)
                        Case "CDNAME"
                            v_strCDNAME = Trim(v_strVALUE)
                        Case "CDVAL"
                            v_strCDVAL = Trim(v_strVALUE)
                        Case "LSTODR"
                            v_strLSTODR = Trim(v_strVALUE)
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

            v_strSQL = "SELECT CDNAME CDVAL FROM ALLCODE WHERE CDNAME ='" & v_strCDNAME & "'" _
                                                & " AND CDTYPE ='" & v_strCDTYPE & "'" _
                                                & " AND CDVAL ='" & v_strCDVAL & "'"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_SA_CDVAL_DUPLICATED
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            v_strSQL = "SELECT CDNAME CDVAL FROM ALLCODE WHERE CDNAME ='" & v_strCDNAME & "'" _
                                                & " AND CDTYPE ='" & v_strCDTYPE & "'" _
                                                & " AND LSTODR ='" & v_strLSTODR & "'"

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return ERR_SA_LSTODR_DUPLICATED
            End If

            If Not (v_ds Is Nothing) Then
                v_ds.Dispose()
            End If

            Return 0
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
