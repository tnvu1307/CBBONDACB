Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class RIGHTCOPY
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "RIGHTCOPY"
    End Sub

    Overrides Function Adhoc(ByRef v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strFuncName As String
        Dim v_strObjMsg As String

        Try

            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            v_strFuncName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)

            v_strObjMsg = pv_xmlDocument.InnerXml
            Select Case Trim(v_strFuncName)
                Case "RightCopy"
                    v_lngErrCode = RightCopy(pv_xmlDocument)
            End Select
            v_strMessage = pv_xmlDocument.InnerXml

            'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " Private methods "
    
    Private Function RightCopy(ByRef pv_xmlDocument As XmlDocumentEx) As Long
        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strClause, v_strBranchId, v_strTellerId As String
            Dim v_strLocal As String
            Dim v_strAutoId As String

            If Not (v_attrColl.GetNamedItem(gc_AtributeCLAUSE) Is Nothing) Then
                v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Else
                v_strClause = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBranchId = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTellerId = String.Empty
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

            Dim v_arrClause() As String
            Dim v_strGroupId, v_strSrcGroupID As String

            v_arrClause = v_strClause.Split("|")

            v_strGroupId = v_arrClause(0)
            v_strSrcGroupID = v_arrClause(1)

            'Xoa quyen cua nhom muon copy quyen
            Dim v_strCmdDelSQL As String
            'Xoa CMDAUTH
            v_strCmdDelSQL = "DELETE FROM CMDAUTH WHERE AUTHTYPE = 'G' AND AUTHID = '" & v_strGroupId & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)
            'Xoa TLAUTH
            v_strCmdDelSQL = "DELETE FROM TLAUTH WHERE AUTHTYPE = 'G' AND AUTHID = '" & v_strGroupId & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdDelSQL)

            'Copy quyen
            Dim v_strCmdInsertSQL As String
            'CMDAUTH
            v_strCmdInsertSQL = "INSERT INTO cmdauth (AUTOID,AUTHTYPE,AUTHID,CMDTYPE,CMDCODE,CMDALLOW,STRAUTH) " _
                                & "SELECT SEQ_CMDAUTH.NEXTVAL, C.AUTHTYPE,'" & v_strGroupId & "',C.CMDTYPE,C.CMDCODE,C.CMDALLOW,C.STRAUTH" & ControlChars.CrLf _
                                & "FROM CMDAUTH C" & ControlChars.CrLf _
                                & "WHERE AUTHTYPE = 'G' AND AUTHID = '" & v_strSrcGroupID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)
            'TLAUTH
            v_strCmdInsertSQL = "INSERT INTO TLAUTH (AUTOID,AUTHTYPE,AUTHID,CODETYPE,CODEID,TLTXCD,TLTYPE,TLLIMIT) " _
                                & "SELECT SEQ_TLAUTH.NEXTVAL, C.AUTHTYPE,'" & v_strGroupId & "',C.CODETYPE,C.CODEID,C.TLTXCD,C.TLTYPE,C.TLLIMIT" & ControlChars.CrLf _
                                & "FROM TLAUTH C" & ControlChars.CrLf _
                                & "WHERE AUTHTYPE = 'G' AND AUTHID = '" & v_strSrcGroupID & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strCmdInsertSQL)

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

