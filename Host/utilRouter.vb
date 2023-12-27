Imports HostCommonLibrary
Imports CoreBusiness
Imports DataAccessLayer
'Imports System.EnterpriseServices
Imports System.Configuration
Imports System.Data

'TruongLD comment when convert
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Required), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class utilRouter
    'TruongLD comment when convert
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Public Function ChangeBOPassword(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New Xml.XmlDocument
            Dim v_strSQL As String
            Dim v_strTellerID, v_strOldPass, v_strNewPass As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            Dim v_lngErr As Long = ERR_SYSTEM_OK

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            Dim v_arrParam As String() = Trim(v_strClause).Split("|".ToCharArray())

            If v_arrParam.GetLength(0) = 3 Then
                v_strTellerID = v_arrParam(0)
                v_strOldPass = v_arrParam(1)
                v_strNewPass = v_arrParam(2)
                v_obj.NewDBInstance(gc_MODULE_HOST)

                v_strSQL = "SELECT * FROM TLPROFILES WHERE TLID='" & v_strTellerID & "' AND PIN=GENENCRYPTPASSWORD('" & v_strOldPass & "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds Is Nothing Then
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSQL = "UPDATE TLPROFILES SET PIN=GENENCRYPTPASSWORD('" & v_strNewPass & "') WHERE TLID='" & v_strTellerID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        Return v_lngErr
                    Else
                        Return ERR_SA_CHANGEPASS_OLDPASSINVALID
                    End If
                Else
                    Return ERR_SA_CHANGEPASS_OLDPASSINVALID
                End If
            Else
                Return ERR_SA_CHANGEPASS_INPUTINCORRECT
            End If

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CheckCorrectionOrderStatus(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.CheckOrderStatus", v_strErrorMessage As String
        Dim v_strSQL, v_strSQL2 As String, v_DataAccess As New DataAccess, v_ds As DataSet, v_ds2 As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)

            v_strSQL = "SELECT OODSTATUS FROM OOD WHERE ORGORDERID = '" & v_strClause & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strSQL2 = "SELECT ORGORDERID FROM ODQUEUE WHERE ORGORDERID = '" & v_strClause & "'"
            v_ds2 = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL2)
            'If v_ds.Tables(0).Rows(0)(0) = "B" And gf_CorrectStringField(v_ds.Tables(0).Rows(0)(1)) <> v_strTellerID Then
            If v_ds.Tables(0).Rows(0)(0) = "B" Then
                v_lngErrCode = ERR_OOD_STATUS_IS_BLOCKED
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            ElseIf v_ds.Tables(0).Rows(0)(0) = "S" Then
                v_lngErrCode = ERR_OOD_STATUS_IS_SENT
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                'If v_ds2.Tables(0).Rows.Count > 0 And gf_CorrectStringField(v_ds.Tables(0).Rows(0)(1)) <> v_strTellerID Then
                If v_ds2.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_OOD_STATUS_IS_BLOCKED
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                Else
                    v_strSQL = "UPDATE OOD SET OODSTATUS = 'D', TLIDSENT='" & v_strTellerID & "', TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS') ,IPADDRESS = '" & v_strIPADDRESS & "' WHERE ORGORDERID = '" & v_strClause & "'"
                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    'v_strSQL2 = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE ORGORDERID = '" & v_strClause & "'  and OODSTATUS <> 'B' and TLIDSENT <> '" & v_strTellerID & "'"
                    v_strSQL2 = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE ORGORDERID = '" & v_strClause & "'"
                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL2)

                End If

            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function CheckOrderStatus(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.CheckOrderStatus", v_strErrorMessage As String
        Dim v_strSQL, v_strSQL2, v_strSQL3 As String, v_DataAccess As New DataAccess, v_ds As DataSet, v_ds2 As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            v_strSQL = "SELECT * FROM ODMAST WHERE ORDERID = '" & v_strClause & "' AND ORSTATUS='3'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_OD_ORDER_CANCELLED
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            v_strSQL = "SELECT OODSTATUS FROM OOD WHERE ORGORDERID = '" & v_strClause & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strSQL2 = "SELECT ORGORDERID FROM ODQUEUE WHERE ORGORDERID = '" & v_strClause & "'"
            v_ds2 = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL2)
            'If v_ds.Tables(0).Rows(0)(0) = "B" And gf_CorrectStringField(v_ds.Tables(0).Rows(0)(1)) <> v_strTellerID Then
            If v_ds.Tables(0).Rows(0)(0) = "B" Then
                v_lngErrCode = ERR_OOD_STATUS_IS_BLOCKED
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            ElseIf v_ds.Tables(0).Rows(0)(0) = "S" Then
                v_lngErrCode = ERR_OOD_STATUS_IS_SENT
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            ElseIf v_ds.Tables(0).Rows(0)(0) = "D" Or v_ds.Tables(0).Rows(0)(0) = "E" Then
                v_lngErrCode = ERR_OD_ORDER_CANCELLED
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                'If v_ds2.Tables(0).Rows.Count > 0 And gf_CorrectStringField(v_ds.Tables(0).Rows(0)(1)) <> v_strTellerID Then
                If v_ds2.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_OOD_STATUS_IS_BLOCKED
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                Else

                    v_strSQL = "UPDATE OOD SET OODSTATUS = 'B', TLIDSENT='" & v_strTellerID & "' , TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS') ,IPADDRESS = '" & v_strIPADDRESS & "' WHERE ORGORDERID = '" & v_strClause & "'"
                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    'v_strSQL2 = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE ORGORDERID = '" & v_strClause & "'  and OODSTATUS <> 'B' and NVL(TLIDSENT,'0') <> '" & v_strTellerID & "'"
                    v_strSQL2 = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE ORGORDERID = '" & v_strClause & "' and BORS IN ('B','S')"
                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL2)

                    v_strSQL3 = "INSERT INTO ODCANCEL SELECT * FROM OOD WHERE ORGORDERID = '" & v_strClause & "'and BORS NOT IN ('B','S') "
                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL3)

                    'Nh?ng l?nh view lên s? luu vào dây
                    v_strSQL2 = "INSERT INTO ODQUEUELOG SELECT * FROM OOD WHERE ORGORDERID = '" & v_strClause & "'"
                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL2)
                End If
            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Public Function UpdateOrderStatus(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.UpdateOrderStatus", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            'Fix update upcom contra order - TungNT modified
            Dim v_strPutType, v_strEXECTYPE, v_strContrafirm2, v_strContraOrd As String

            v_strSQL = "SELECT NVL(PUTTYPE,'') PUTTYPE,NVL(EXECTYPE,'') EXECTYPE,NVL(CONTRAFRM,'') CONTRAFRM,NVL(CONTRAORDERID,'') CONTRAORDERID FROM ODMAST WHERE ORDERID='" & v_strClause & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds Is Nothing Then
                If v_ds.Tables(0).Rows(0)("PUTTYPE") Is DBNull.Value Then
                    v_strPutType = ""
                Else
                    v_strPutType = v_ds.Tables(0).Rows(0)("PUTTYPE")
                End If

                If v_ds.Tables(0).Rows(0)("EXECTYPE") Is DBNull.Value Then
                    v_strEXECTYPE = ""
                Else
                    v_strEXECTYPE = v_ds.Tables(0).Rows(0)("EXECTYPE")
                End If

                If v_ds.Tables(0).Rows(0)("CONTRAFRM") Is DBNull.Value Then
                    v_strContrafirm2 = ""
                Else
                    v_strContrafirm2 = CStr(v_ds.Tables(0).Rows(0)("CONTRAFRM")).Replace(".", "")
                End If

                If v_ds.Tables(0).Rows(0)("CONTRAORDERID") Is DBNull.Value Then
                    v_strContraOrd = ""
                Else
                    v_strContraOrd = CStr(v_ds.Tables(0).Rows(0)("CONTRAORDERID")).Replace(".", "")
                End If

                'Neu la lenh mua thoa thuan Upcom thi phai update lenh ban tuong ung
                If v_strPutType = "N" And "NB,BC".IndexOf(v_strEXECTYPE) >= 0 Then
                    Dim v_strCompanyFirm As String = ""
                    v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "COMPANYCD", v_strCompanyFirm)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Return v_lngErrCode
                    End If
                    If (v_strContrafirm2 = v_strCompanyFirm Or v_strContrafirm2 = "") Then
                        v_strContrafirm2 = v_strCompanyFirm
                        v_strSQL = "UPDATE OOD SET OODSTATUS = 'S', TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS'), TLIDSENT = '" & v_strTellerID & "' ,IPADDRESS = '" & v_strIPADDRESS & "' WHERE ORGORDERID = '" & v_strContraOrd & "'"
                        v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

                        v_strSQL = "UPDATE ODMAST SET ORSTATUS = '2' WHERE ORDERID = '" & v_strContraOrd & "' AND ORSTATUS = '8'"
                        v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    End If
                End If
            End If

            'End

            v_strSQL = "UPDATE OOD SET OODSTATUS = 'S', TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS'), TLIDSENT = '" & v_strTellerID & "' ,IPADDRESS = '" & v_strIPADDRESS & "' WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "UPDATE ODMAST SET ORSTATUS = '2' WHERE ORDERID = '" & v_strClause & "' AND ORSTATUS = '8'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function CreateOrderCustodyChange(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.CreateOrderCustodyChange", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)

            v_strSQL = v_strClause
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Public Function PutthroughReject(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.UtilRouter.PutthroughReject", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBrid As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Dim v_arrString() As String
            Dim v_strTable, v_strConfirmNumber, v_strOrderNumber As String
            v_arrString = v_strClause.Split("|")
            v_strTable = v_arrString(0)
            v_strConfirmNumber = v_arrString(1)
            v_strOrderNumber = v_arrString(2)
            If v_strTable = "ORDERPTACK" Then
                'Chap nhan lenh thoa thuan
                v_strSQL = "UPDATE ORDERPTACK SET status = 'C', TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS'), TLID = '" & v_strTellerID & "' ,IPADDRESS = '" & v_strIPADDRESS & "',BRID = '" & v_strBrid & "',ORDERNUMBER = '" & v_strOrderNumber & "' WHERE trim(confirmnumber) = trim('" & v_strConfirmNumber & "')"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE ODMAST SET CONFIRM_NO =  '" & v_strConfirmNumber & "' WHERE ORDERID = '" & v_strOrderNumber & "'"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ElseIf v_strTable = "CANCELORDERPTACK" Then
                'Tu choi lenh huy thoa thuan 3D code C
                v_strSQL = "UPDATE CANCELORDERPTACK SET status = 'C', TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS'), TLID = '" & v_strTellerID & "' ,IPADDRESS = '" & v_strIPADDRESS & "',BRID = '" & v_strBrid & "',ORDERNUMBER = '" & v_strOrderNumber & "' WHERE trim(confirmnumber) = trim('" & v_strConfirmNumber & "')"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'TAO MESSAGE 3D DOI DAY XAC NHAN LEN HE THONG
                v_strSQL = "INSERT INTO CANCELORDERPTACK (SORR,TIMESTAMP, MESSAGETYPE, FIRM, CONTRAFIRM, TRADEID," _
                                    & " SIDE, SECURITYSYMBOL, CONFIRMNUMBER, STATUS, ISCONFIRM,ORDERNUMBER, BRID, TLID, TXTIME, IPADDRESS,TRADING_DATE)" _
                                    & " SELECT 'S',TO_CHAR(SYSDATE,'HH24MISS'),'3D',SYS1.SYSVALUE FIRM, OD.CONTRAFIRM,SYS2.SYSVALUE," _
                                    & " IOD.BORS,IOD.SYMBOL,IOD.CONFIRM_NO,'N','N',OD.ORDERID,'" & v_strBrid & "','" & v_strTellerID & "',TO_CHAR(SYSDATE,'HH24MISS'),'" & v_strIPADDRESS & "',IOD.TXDATE" _
                                    & " FROM IOD,ODMAST OD,ORDERSYS SYS1,ORDERSYS SYS2 WHERE SYS1.SYSNAME='FIRM'" _
                                    & " AND SYS2.SYSNAME='BROKERID' AND IOD.ORGORDERID=OD.ORDERID AND OD.confirm_no='" & v_strOrderNumber & "'"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            ElseIf v_strTable = "ORDERPTDEAL" Then
                'Huy lenh thoa thuan
                v_strSQL = "INSERT INTO CANCELORDERPTACK (SORR,TIMESTAMP, MESSAGETYPE, FIRM, CONTRAFIRM, TRADEID," _
                    & " SIDE, SECURITYSYMBOL, CONFIRMNUMBER, STATUS, ISCONFIRM,ORDERNUMBER, BRID, TLID, TXTIME, IPADDRESS,TRADING_DATE)" _
                    & " SELECT 'S',TO_CHAR(SYSDATE,'HH24MISS'),'3C',SYS1.SYSVALUE FIRM, OD.CONTRAFIRM,SYS2.SYSVALUE," _
                    & " IOD.BORS,IOD.SYMBOL,IOD.CONFIRM_NO,'N','N',OD.ORDERID,'" & v_strBrid & "','" & v_strTellerID & "',TO_CHAR(SYSDATE,'HH24MISS'),'" & v_strIPADDRESS & "',IOD.TXDATE" _
                    & " FROM IOD,ODMAST OD,ORDERSYS SYS1,ORDERSYS SYS2 WHERE SYS1.SYSNAME='FIRM'" _
                    & " AND SYS2.SYSNAME='BROKERID' AND IOD.ORGORDERID=OD.ORDERID AND OD.ORDERID='" & v_strOrderNumber & "'"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function PutthroughConfirm(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.UtilRouter.PutthroughConfirm", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBrid As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Dim v_arrString() As String
            Dim v_strTable, v_strConfirmNumber, v_strOrderNumber As String
            v_arrString = v_strClause.Split("|")
            v_strTable = v_arrString(0)
            v_strConfirmNumber = v_arrString(1)
            v_strOrderNumber = v_arrString(2)
            If v_strTable = "ORDERPTACK" Then
                'Check xem lenh tuong ung co phu hop voi msg khong
                v_strSQL = "SELECT * FROM ODMAST A,ORDERPTACK B,OOD WHERE A.ORDERID=OOD.ORGORDERID AND A.ORDERID='" & v_strOrderNumber & "' AND B.CONFIRMNUMBER='" & v_strConfirmNumber & "' AND A.ORDERQTTY=B.VOLUME AND A.MATCHTYPE='P' AND OOD.BORS=B.SIDE"
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    v_lngErrCode = ERR_OD_ORDERID_NOTDOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
                'Chap nhan lenh thoa thuan
                v_strSQL = "UPDATE ORDERPTACK SET status = 'A', TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS'), TLID = '" & v_strTellerID & "' ,IPADDRESS = '" & v_strIPADDRESS & "',BRID = '" & v_strBrid & "',ORDERNUMBER = '" & v_strOrderNumber & "' WHERE trim(confirmnumber) = trim('" & v_strConfirmNumber & "')"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

                v_strSQL = "UPDATE ODMAST SET CONFIRM_NO =  '" & v_strConfirmNumber & "' WHERE ORDERID = '" & v_strOrderNumber & "'"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            ElseIf v_strTable = "CANCELORDERPTACK" Then
                'Chap nhan lenh huy thoa thuan (3D code A)
                v_strSQL = "UPDATE CANCELORDERPTACK SET status = 'A', TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS'), TLID = '" & v_strTellerID & "' ,IPADDRESS = '" & v_strIPADDRESS & "',BRID = '" & v_strBrid & "',ORDERNUMBER = '" & v_strOrderNumber & "' WHERE trim(confirmnumber) = trim('" & v_strConfirmNumber & "')"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'TAO MESSAGE 3D DOI DAY XAC NHAN LEN HE THONG
                v_strSQL = "INSERT INTO CANCELORDERPTACK (SORR,TIMESTAMP, MESSAGETYPE, FIRM, CONTRAFIRM, TRADEID," _
                                    & " SIDE, SECURITYSYMBOL, CONFIRMNUMBER, STATUS, ISCONFIRM,ORDERNUMBER, BRID, TLID, TXTIME, IPADDRESS,TRADING_DATE)" _
                                    & " SELECT 'S',TO_CHAR(SYSDATE,'HH24MISS'),'3D',SYS1.SYSVALUE FIRM, OD.CONTRAFIRM,SYS2.SYSVALUE," _
                                    & " IOD.BORS,IOD.SYMBOL,IOD.CONFIRM_NO,'N','N',OD.ORDERID,'" & v_strBrid & "','" & v_strTellerID & "',TO_CHAR(SYSDATE,'HH24MISS'),'" & v_strIPADDRESS & "',IOD.TXDATE" _
                                    & " FROM IOD,ODMAST OD,ORDERSYS SYS1,ORDERSYS SYS2 WHERE SYS1.SYSNAME='FIRM'" _
                                    & " AND SYS2.SYSNAME='BROKERID' AND IOD.ORGORDERID=OD.ORDERID AND OD.confirm_no='" & v_strOrderNumber & "'"
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function PutthroughAdvAdd(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.UtilRouter.PutthroughReject", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strSectype, v_strTradePlace As String
        Dim v_PriceCeil, v_PriceFloor As Double

        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBrid As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Dim v_arrString() As String
            Dim v_strSymbol, v_strSide, v_strBoard, v_strVolume, v_strPrice, v_strContact, v_strToCompID, v_strActive As String
            v_arrString = v_strClause.Split("|")
            v_strSymbol = v_arrString(0)
            v_strSide = v_arrString(1)
            v_strBoard = v_arrString(2)
            v_strVolume = v_arrString(3)
            v_strPrice = v_arrString(4)
            v_strToCompID = v_arrString(5)
            v_strContact = v_arrString(6)
            v_strActive = v_arrString(7)

            v_strSQL = "	SELECT SYSVALUE FROM ORDERSYS WHERE SYSNAME='FIRM'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strFirm = v_ds.Tables(0).Rows(0)("SYSVALUE")
            v_strSQL = "	SELECT SYSVALUE FROM ORDERSYS WHERE SYSNAME='BROKERID'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strTraderID = v_ds.Tables(0).Rows(0)("SYSVALUE")

            'INSERT VAO CSDL
            v_strSQL = "INSERT INTO orderptadv(autoid, timestamp, messagetype, firm, tradeid,securitysymbol,side, volume, price,board, " _
                        & " sendtime,status,ToCompID,contact, offset, issend, isactive, deleted,refid, brid, tlid, ipaddress, advdate) " _
                        & " VALUES " _
                        & "(seq_ordermap.NEXTVAL,TO_CHAR(SYSDATE,'HH24MISS'),'1E','" & v_strFirm & "','" & v_strTraderID & "','" & v_strSymbol & "','" & v_strSide & "','" & v_strVolume & "','" & v_strPrice & "','" & v_strBoard & "'," _
                        & "'','A','" & v_strToCompID & "','" & v_strContact & "','','N','" & v_strActive & "','N',0,'" & v_strBrid & "','" & v_strTellerID & "','" & v_strIPADDRESS & "',TRUNC(SYSDATE))"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function PutthroughAdvCancel(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.UtilRouter.PutthroughReject", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBrid As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Dim v_arrString() As String
            Dim v_strSymbol, v_strSide, v_strBoard, v_strVolume, v_strPrice, v_strContact, v_strActive, v_strTradeplace As String
            Dim v_strDelete, v_strisSend, v_strAutoid, v_strTime As String
            v_arrString = v_strClause.Split("|")
            v_strSymbol = v_arrString(0)
            v_strSide = v_arrString(1)
            v_strBoard = v_arrString(2)
            v_strVolume = v_arrString(3)
            v_strPrice = v_arrString(4)
            v_strContact = v_arrString(5)
            v_strActive = v_arrString(6)
            v_strDelete = v_arrString(7)
            v_strisSend = v_arrString(8)
            v_strAutoid = v_arrString(9)
            v_strTime = v_arrString(10)
            v_strSQL = "	SELECT SYSVALUE FROM ORDERSYS WHERE SYSNAME='FIRM'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strFirm = v_ds.Tables(0).Rows(0)("SYSVALUE")
            v_strSQL = "	SELECT SYSVALUE FROM ORDERSYS WHERE SYSNAME='BROKERID'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strTraderID = v_ds.Tables(0).Rows(0)("SYSVALUE")
            v_strSQL = "	SELECT * FROM orderptadv WHERE AUTOID=" & CDbl(v_strAutoid)
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_OD_ERROR_ADV_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            Else
                v_strDelete = v_ds.Tables(0).Rows(0)("DELETED")
                If v_strDelete = "Y" Then
                    v_lngErrCode = ERR_OD_ERROR_ADV_CANCELED
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            'Kiem tra cho san HA: Neu ADVTRANS <> 'N' thi khong cho xoa
            v_strSQL = "select TRADEPLACE from sbsecurities where Symbol = '" & v_strSymbol & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strTradeplace = v_ds.Tables(0).Rows(0)("TRADEPLACE")
                If v_strTradeplace = "002" Then 'San HA
                    v_strSQL = "	SELECT * FROM ORDERPTADV O, ORDERMAP_HA OM, HAPUT_AD H " _
                             & "	WHERE TO_CHAR(O.AUTOID) =OM.CTCI_ORDER  AND OM.ORDER_NUMBER =H.ADVID " _
                             & "	AND H.ADVTRANSTYPE ='N'  AND AUTOID=" & CDbl(v_strAutoid)
                    v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If Not v_ds.Tables(0).Rows.Count > 0 Then
                        v_lngErrCode = ERR_OD_ERROR_ADV_CANCELED
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Return v_lngErrCode
                    End If
                End If
            End If
            'INSERT VAO CSDL
            v_strSQL = "INSERT INTO orderptadv(autoid, timestamp, messagetype, firm, tradeid,securitysymbol,side, volume, price,board, " _
                        & " sendtime,status,contact, offset, issend, isactive, deleted,refid, brid, tlid, ipaddress, advdate) " _
                        & " VALUES " _
                        & "(seq_ORDERPTADV.NEXTVAL,'" & v_strTime & "','1E','" & v_strFirm & "','" & v_strTraderID & "','" & v_strSymbol & "','" & v_strSide & "','" & v_strVolume & "','" & v_strPrice & "','" & v_strBoard & "'," _
                        & "'','C','" & v_strContact & "','','N','" & v_strActive & "','N'," & CDbl(v_strAutoid) & ",'" & v_strBrid & "','" & v_strTellerID & "','" & v_strIPADDRESS & "',TRUNC(SYSDATE))"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "UPDATE orderptadv SET DELETED='Y' WHERE AUTOID=" & CDbl(v_strAutoid)
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function PutthroughAdvActive(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.UtilRouter.PutthroughReject", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBrid As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Dim v_arrString() As String
            Dim v_strSymbol, v_strSide, v_strBoard, v_strVolume, v_strPrice, v_strContact, v_strActive As String
            Dim v_strDelete, v_strisSend, v_strAutoid As String
            v_arrString = v_strClause.Split("|")
            v_strSymbol = v_arrString(0)
            v_strSide = v_arrString(1)
            v_strBoard = v_arrString(2)
            v_strVolume = v_arrString(3)
            v_strPrice = v_arrString(4)
            v_strContact = v_arrString(5)
            v_strActive = v_arrString(6)
            v_strDelete = v_arrString(7)
            v_strisSend = v_arrString(8)
            v_strAutoid = v_arrString(9)
            v_strSQL = "	SELECT SYSVALUE FROM ORDERSYS WHERE SYSNAME='FIRM'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strFirm = v_ds.Tables(0).Rows(0)("SYSVALUE")
            v_strSQL = "	SELECT SYSVALUE FROM ORDERSYS WHERE SYSNAME='BROKERID'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strTraderID = v_ds.Tables(0).Rows(0)("SYSVALUE")
            v_strSQL = "	SELECT * FROM orderptadv WHERE AUTOID=" & CDbl(v_strAutoid)
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_OD_ERROR_ADV_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            Else
                v_strActive = v_ds.Tables(0).Rows(0)("ISACTIVE")
                If v_strActive = "Y" Then
                    v_lngErrCode = ERR_OD_ERROR_ADV_ACTIVED
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            'INSERT VAO CSDL
            v_strSQL = "UPDATE orderptadv SET ISACTIVE='Y' WHERE AUTOID=" & CDbl(v_strAutoid)
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function PutthroughAdvDelete(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.UtilRouter.PutthroughReject", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBrid As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Dim v_arrString() As String
            Dim v_strSymbol, v_strSide, v_strBoard, v_strVolume, v_strPrice, v_strContact, v_strActive As String
            Dim v_strDelete, v_strisSend, v_strAutoid As String
            v_arrString = v_strClause.Split("|")
            v_strSymbol = v_arrString(0)
            v_strSide = v_arrString(1)
            v_strBoard = v_arrString(2)
            v_strVolume = v_arrString(3)
            v_strPrice = v_arrString(4)
            v_strContact = v_arrString(5)
            v_strActive = v_arrString(6)
            v_strDelete = v_arrString(7)
            v_strisSend = v_arrString(8)
            v_strAutoid = v_arrString(9)
            v_strSQL = "	SELECT SYSVALUE FROM ORDERSYS WHERE SYSNAME='FIRM'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strFirm = v_ds.Tables(0).Rows(0)("SYSVALUE")
            v_strSQL = "	SELECT SYSVALUE FROM ORDERSYS WHERE SYSNAME='BROKERID'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strTraderID = v_ds.Tables(0).Rows(0)("SYSVALUE")
            v_strSQL = "	SELECT * FROM orderptadv WHERE AUTOID=" & CDbl(v_strAutoid)
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_OD_ERROR_ADV_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            Else
                v_strDelete = v_ds.Tables(0).Rows(0)("ISACTIVE")
                If v_strDelete = "Y" Then
                    v_lngErrCode = ERR_OD_ERROR_ADV_DELETED
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrCode
                End If
            End If
            'INSERT VAO CSDL
            v_strSQL = "UPDATE orderptadv SET DELETED='Y' WHERE AUTOID=" & CDbl(v_strAutoid)
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Public Function PutthroughRejectNotConfirm(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.UtilRouter.PutthroughReject", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strBrid As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)
            Dim v_arrString() As String
            Dim v_strSymbol, v_strSide, v_strBoard, v_strVolume, v_strPrice, v_strContact, v_strActive As String
            Dim v_strDelete, v_strisSend, v_strAutoid, v_strConfirmNumber As String
            v_arrString = v_strClause.Split("|")
            v_strSymbol = v_arrString(0)
            v_strConfirmNumber = v_arrString(1)

            'Kiem tra status cua lenh la 'N', neu khong thong bao loi

            v_strSQL = " SELECT * FROM ORDERPTACK WHERE status = 'N' And  trim(confirmnumber) = trim('" & v_strConfirmNumber & "')"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                v_lngErrCode = ERR_OOD_STATUS_INVALID
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If
            v_strSQL = "UPDATE ORDERPTACK SET status = 'C', TXTIME = TO_CHAR(SYSDATE,'HH24:MI:SS') WHERE trim(confirmnumber) = trim('" & v_strConfirmNumber & "')"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "UPDATE ORDERMAP_HA SET Rejectcode = 'N' WHERE trim(order_number) = trim('" & v_strConfirmNumber & "')"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)


            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function RefuseCorrectionOrder(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.UpdateOrderStatus", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)

            v_strSQL = "UPDATE OOD SET OODSTATUS = 'E' WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "UPDATE ODMAST SET ORSTATUS = '0' WHERE ORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function CancelOrderCorrectionSending(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.CancelOrderSending", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)

            v_strSQL = "UPDATE OOD SET OODSTATUS = 'N', TLIDSENT='', IPADDRESS='' WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "DELETE FROM ODQUEUE WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function CancelOrderSending(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.CancelOrderSending", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTellerID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strIPADDRESS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeRESERVER), Xml.XmlAttribute).Value)

            'Nh?ng l?nh view lên mà không d?c di s? luu vào dây
            v_strSQL = "INSERT INTO odqueueback SELECT * FROM OOD WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "UPDATE OOD SET OODSTATUS = 'N', TLIDSENT='', IPADDRESS='' WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            v_strSQL = "DELETE FROM ODQUEUE WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            v_strSQL = "DELETE FROM ODCANCEL WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function InsertOrderQueue(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.InsertOrderQueue", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            'Kienvt sua ham trim
            'v_strSQL = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE TRIM(ORGORDERID) = '" & v_strClause & "'"
            v_strSQL = "INSERT INTO ODQUEUE SELECT * FROM OOD WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
    Public Function DeleteOrderQueue(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.SystemAdmin.DeleteOrderQueue", v_strErrorMessage As String
        Dim v_strSQL As String, v_DataAccess As New DataAccess, v_ds As DataSet
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Kienvt sua ham trim
            'v_strSQL = "DELETE FROM ODQUEUE WHERE TRIM(ORGORDERID) = '" & v_strClause & "'"
            v_strSQL = "DELETE FROM ODQUEUE WHERE ORGORDERID = '" & v_strClause & "'"
            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class
