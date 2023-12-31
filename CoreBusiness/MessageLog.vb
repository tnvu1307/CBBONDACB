Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data

'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Supported), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class MessageLog
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

#Region " Khai bÃ¡o háº±ng, biáº¿n "
    Private mv_strAttrRegion As String = gc_MODULE_BDS
#End Region

#Region " Constructor "
    Public Sub New()
    End Sub
#End Region

#Region " Thuá»™c tÃ­nh cá»§a lá»›p "

    Public Sub NewDBInstance(ByVal pv_strModule As String)
        mv_strAttrRegion = pv_strModule
    End Sub

    Public Property ATTR_REGION() As String
        Get
            Return mv_strAttrRegion
        End Get
        Set(ByVal Value As String)
            mv_strAttrRegion = Value
        End Set
    End Property
#End Region

#Region " Public methods "
    Public Function TransDelete(ByRef pv_xmlMessage As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "MessageLog.TransDelete", v_strErrorMessage As String = String.Empty
        Try

            Dim v_obj As DataAccess
            If ATTR_REGION = gc_MODULE_BDS Then
                v_obj = New DataAccess
            ElseIf ATTR_REGION = gc_MODULE_HOST Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            'Update TLLOG: by set DELTD field
            Dim v_strTXNUM As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            Dim v_strTXDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            Dim v_strTXSTATUS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
            Dim v_strOFFID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            Dim v_strDELTD As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)
            'Kiem tra neu khong co chung tu tren Host thi khong cho phep xoa giso dich tren Host
            Dim v_strSQL As String
            If ATTR_REGION = gc_MODULE_HOST Then
                Dim v_ds As DataSet
                v_strSQL = "SELECT * FROM TLLOG WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds.Tables(0).Rows.Count > 0 Then
                    'khÃ´ng co lich nay
                    v_lngErrorCode = ERR_SA_HOST_VOUCHER_DOESNOT_FOUND
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngErrorCode.ToString() & vbNewLine _
                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrorCode
                End If

                'Trang thai Cho duyet khong duoc Xoa
                v_strSQL = "SELECT * FROM TLLOG WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "' AND TXSTATUS = '4'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'khÃ´ng co lich nay
                    v_lngErrorCode = ERR_SA_CANNOT_DELETE_PENDING_TRANS
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                         & "Error code: " & v_lngErrorCode.ToString() & vbNewLine _
                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Return v_lngErrorCode
                End If
            End If

            'THuc hien xoa giao dich
            v_strSQL = "UPDATE TLLOG SET DELTD='" & v_strDELTD & "',TXSTATUS='" & v_strTXSTATUS & "',OFFID='" & v_strOFFID & "' " _
                                    & ", PTXSTATUS = PTXSTATUS ||'" & v_strTXSTATUS & "' " & ControlChars.CrLf _
                & "WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            If v_blnReversal Then
                'Xoa cac giao dich thu phi da nhap tuong ung voi giao dich
                v_strSQL = "UPDATE FEETRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Xoa cac hoa don VAT da nhap tuong ung voi giao dich
                v_strSQL = "UPDATE VATTRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                'Xoa cac tai san co dinh tuong ung voi giao dich
                v_strSQL = "UPDATE MITRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function TransDelete4DR(ByRef pv_xmlMessage As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "MessageLog.TransDelete", v_strErrorMessage As String = String.Empty
        Try

            Dim v_obj As DataAccess
            If ATTR_REGION = gc_MODULE_BDS Then
                v_obj = New DataAccess
            ElseIf ATTR_REGION = gc_MODULE_HOST Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If


            'Update TLLOG: by set DELTD field
            Dim v_strTXNUM As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            Dim v_strTXDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            Dim v_strTXSTATUS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
            Dim v_strOFFID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            Dim v_strDELTD As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)
            'Kiem tra neu khong co chung tu tren Host thi khong cho phep xoa giso dich tren Host
            Dim v_strSQL As String

            'THuc hien xoa giao dich
            v_strSQL = "UPDATE TLLOG4DR SET DELTD='" & v_strDELTD & "',TXSTATUS='" & v_strTXSTATUS & "',OFFID='" & v_strOFFID & "' " _
                                        & ",PTXSTATUS = PTXSTATUS ||'" & v_strTXSTATUS & "'," & ControlChars.CrLf _
                & "WHERE TXDATE = TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function TransDetail(ByRef pv_xmlMessage As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "MessageLog.TransDetail", v_strErrorMessage As String = String.Empty
        Dim v_obj As DataAccess
        Dim v_strTxMsg As String, v_strFLDNAME, v_strDEFNAME, v_strDATATYPE, v_strFLDVALUE As String
        Dim EntrySUBTXNO, EntryDORC, EntryCCYCD, EntryACCTNO, EntryAMOUNT As String
        Dim v_strVOUCHERNO, v_strVOUCHERTYPE, v_strSERIENO, v_strVOUCHERDATE, v_strCUSTID, v_strTAXCODE, v_strCUSTNAME, v_strADDRESS, v_strCONTENTS, v_strDESCRIPTION As String, v_dblQTTY, v_dblPRICE, v_dblVATRATE As Double
        Dim v_dblMISUBTXNO As Double, v_strMIDORC, v_strMIACCTNO, v_strMICUSTID, v_strMICUSTNAME, v_strMITASKCD, v_strMIDEPTCD, v_strMIMICD, v_strMIDESCRIPTION As String
        Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim v_attrFLDNAME, v_attrDEFNAME, v_attrDATATYPE As Xml.XmlAttribute
        Dim v_strSQL As String, v_ds As DataSet, i As Integer
        Dim v_dblAMT, v_dblVATAMT As Double

        Try

            If ATTR_REGION = gc_MODULE_BDS Then
                v_obj = New DataAccess
            ElseIf ATTR_REGION = gc_MODULE_HOST Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Táº¡o message
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlMessage.DocumentElement.Attributes
            Dim v_strTXNUM As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Dim v_strTXDATE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)

            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTranS, gc_IsLocalMsg)
            pv_xmlMessage.LoadXml(v_strTxMsg)
            'v_strSQL = "SELECT LG.*, TX.TXDESC TLTXDESC, TX.LOCAL, TX.TXTYPE, TX.NOSUBMIT, TX.DELALLOW FROM TLLOG LG, TLTX TX " & ControlChars.CrLf _
            '    & "WHERE TX.TLTXCD=LG.TLTXCD AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') "
            v_strSQL = "SELECT LG.*, TX.TXDESC TLTXDESC, TX.LOCAL, TX.TXTYPE, TX.NOSUBMIT, TX.DELALLOW, TX.LATE ,TX.GLGP FROM TLLOG LG, TLTX TX " & ControlChars.CrLf _
                & "WHERE TX.TLTXCD=LG.TLTXCD AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') "
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strErrorMessage = "Láº¥y pháº§n header"
                'Láº¥y pháº§n header
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TXNUM")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value = Format(gf_CorrectDateField(v_ds.Tables(0).Rows(0)("TXDATE")), gc_FORMAT_DATE)
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXTIME).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TXTIME")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BRID")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLID")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OFFID")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OVRRQS")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHID).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CHID")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKID).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CHKID")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLTXCD).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLTXCD")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeIBT).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("IBT")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRID2).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BRID2")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLID2).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLID2")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCCYUSAGE).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CCYUSAGE")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TXSTATUS")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFLINE).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OFF_LINE")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeDELTD).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DELTD")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRDATE).Value = Format(gf_CorrectDateField(v_ds.Tables(0).Rows(0)("BRDATE")), gc_FORMAT_DATE)
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBUSDATE).Value = Format(gf_CorrectDateField(v_ds.Tables(0).Rows(0)("BUSDATE")), gc_FORMAT_DATE)
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeMSGSTS).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("MSGSTS")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRSTS).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OVRSTS")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeIPADDRESS).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("IPADDRESS")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeWSNAME).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("WSNAME")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BATCHNAME")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDESC).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TXDESC")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeLOCAL).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LOCAL")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXTYPE).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TXTYPE")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeNOSUBMIT).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("NOSUBMIT")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeMSGAMT).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("MSGAMT")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeMSGACCT).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("MSGACCT")))

                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKTIME).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("CHKTIME")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFTIME).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("OFFTIME")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeDELALLOW).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DELALLOW")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeLATE).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("LATE")))
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeGLGP).Value = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("GLGP")))
                'Láº¥y pháº§n ná»™i dung giao dá»‹ch
                v_strSQL = "SELECT FLD.*,LGFLD.NVALUE, LGFLD.CVALUE " & ControlChars.CrLf _
                        & "FROM FLDMASTER FLD, TLLOGFLD LGFLD, TLLOG LG " & ControlChars.CrLf _
                        & "WHERE FLD.OBJNAME = LG.TLTXCD And LG.TXNUM = LGFLD.TXNUM And LG.TXDATE = LGFLD.TXDATE AND FLD.FLDNAME=LGFLD.FLDCD " & ControlChars.CrLf _
                        & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                        & "ORDER BY ODRNUM"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                v_strErrorMessage = "Láº¥y pháº§n ná»™i dung giao dá»‹ch"
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dataElement = pv_xmlMessage.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        'XÃ¡c Ä‘á»‹nh cÃ¡c trÆ°á»?ng dá»¯ liá»‡u
                        v_strFLDNAME = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FLDNAME"))
                        v_strDEFNAME = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DEFNAME"))
                        v_strDATATYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DATATYPE"))
                        If v_strDATATYPE = "N" Then
                            v_strFLDVALUE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("NVALUE"))
                        Else
                            v_strFLDVALUE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CVALUE"))
                            v_strFLDVALUE = Replace(v_strFLDVALUE, "'", "''")
                        End If

                        'Táº¡o cÃ¡c trÆ°á»?ng dá»¯ liá»‡u
                        v_entryNode = pv_xmlMessage.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                        v_attrFLDNAME = pv_xmlMessage.CreateAttribute(gc_AtributeFLDNAME)
                        v_attrFLDNAME.Value = v_strFLDNAME
                        v_entryNode.Attributes.Append(v_attrFLDNAME)
                        v_attrDEFNAME = pv_xmlMessage.CreateAttribute(gc_AtributeDEFNAME)
                        v_attrDEFNAME.Value = v_strDEFNAME
                        v_entryNode.Attributes.Append(v_attrDEFNAME)
                        v_attrDATATYPE = pv_xmlMessage.CreateAttribute(gc_AtributeFLDTYPE)
                        v_attrDATATYPE.Value = v_strDATATYPE
                        v_entryNode.Attributes.Append(v_attrDATATYPE)
                        v_entryNode.InnerText = v_strFLDVALUE

                        v_dataElement.AppendChild(v_entryNode)
                    Next
                    pv_xmlMessage.DocumentElement.AppendChild(v_dataElement)
                End If

                'Láº¥y pháº§n háº¡ch toÃ¡n
                v_strErrorMessage = "Láº¥y pháº§n háº¡ch toÃ¡n"
                v_strSQL = "SELECT GL.* FROM TLLOG LG, GLTRAN GL " & ControlChars.CrLf _
                        & "WHERE LG.TXNUM=GL.TXNUM AND LG.TXDATE=GL.TXDATE " & ControlChars.CrLf _
                        & "AND LG.TXNUM='" & v_strTXNUM & "' AND LG.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') " & ControlChars.CrLf _
                        & "ORDER BY GL.SUBTXNO, GL.DORC DESC"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dataElement = pv_xmlMessage.CreateElement(Xml.XmlNodeType.Element, "postmap", "")
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        'XÃ¡c Ä‘á»‹nh cÃ¡c bÃºt toÃ¡n
                        EntrySUBTXNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SUBTXNO"))
                        EntryDORC = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DORC"))
                        EntryCCYCD = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CCYCD"))
                        EntryACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACCTNO"))
                        EntryAMOUNT = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AMT"))
                        'ThÃªm bÃºt toÃ¡n
                        v_entryNode = pv_xmlMessage.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                        Dim v_attrSUBTXNO As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("subtxno")
                        v_attrSUBTXNO.Value = EntrySUBTXNO
                        v_entryNode.Attributes.Append(v_attrSUBTXNO)
                        Dim v_attrDORC As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("dorc")
                        v_attrDORC.Value = EntryDORC
                        v_entryNode.Attributes.Append(v_attrDORC)
                        Dim v_attrCCYCD As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("ccycd")
                        v_attrCCYCD.Value = EntryCCYCD
                        v_entryNode.Attributes.Append(v_attrCCYCD)
                        Dim v_attrACCTNO As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("acctno")
                        v_attrACCTNO.Value = EntryACCTNO
                        v_entryNode.Attributes.Append(v_attrACCTNO)
                        v_entryNode.InnerText = EntryAMOUNT
                        v_dataElement.AppendChild(v_entryNode)
                    Next
                    pv_xmlMessage.DocumentElement.AppendChild(v_dataElement)
                End If
                'Láº¥y pháº§n hoÃ¡ Ä‘Æ¡n VAT
                v_strErrorMessage = "Láº¥y pháº§n hoÃ¡ Ä‘Æ¡n VAT"
                v_strSQL = "SELECT * FROM VATTRAN VAT WHERE VAT.TXNUM='" & v_strTXNUM & "' AND VAT.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') ORDER BY VAT.VOUCHERNO"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dataElement = pv_xmlMessage.CreateElement(Xml.XmlNodeType.Element, "vatvoucher", "")
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        'XÃ¡c Ä‘á»‹nh cÃ¡c bÃºt toÃ¡n
                        v_strVOUCHERNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("VOUCHERNO"))
                        v_strVOUCHERTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("VOUCHERTYPE"))
                        v_strSERIENO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SERIENO"))
                        v_strVOUCHERDATE = Format(gf_CorrectDateField(v_ds.Tables(0).Rows(i)("VOUCHERDATE")), gc_FORMAT_DATE)
                        v_strCUSTID = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CUSTID"))
                        v_strTAXCODE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TAXCODE"))
                        v_strCUSTNAME = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CUSTNAME"))
                        v_strADDRESS = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ADDRESS"))
                        v_strCONTENTS = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CONTENTS"))
                        v_strDESCRIPTION = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DESCRIPTION"))
                        v_dblQTTY = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("QTTY"))
                        v_dblPRICE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("PRICE"))
                        v_dblAMT = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("AMT"))
                        v_dblVATRATE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("VATRATE"))
                        v_dblVATAMT = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("VATAMT"))

                        'ThÃªm bÃºt toÃ¡n
                        v_entryNode = pv_xmlMessage.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                        Dim v_attrVOUCHERNO As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("voucherno")
                        v_attrVOUCHERNO.Value = v_strVOUCHERNO
                        v_entryNode.Attributes.Append(v_attrVOUCHERNO)

                        Dim v_attrVOUCHERTYPE As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("vouchertype")
                        v_attrVOUCHERTYPE.Value = v_strVOUCHERTYPE
                        v_entryNode.Attributes.Append(v_attrVOUCHERTYPE)

                        Dim v_attrSERIENO As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("serieno")
                        v_attrSERIENO.Value = v_strSERIENO
                        v_entryNode.Attributes.Append(v_attrSERIENO)

                        Dim v_attrVOUCHERDATE As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("voucherdate")
                        v_attrVOUCHERDATE.Value = v_strVOUCHERDATE
                        v_entryNode.Attributes.Append(v_attrVOUCHERDATE)

                        Dim v_attrCUSTID As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("custid")
                        v_attrCUSTID.Value = v_strCUSTID
                        v_entryNode.Attributes.Append(v_attrCUSTID)

                        Dim v_attrTAXCODE As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("taxcode")
                        v_attrTAXCODE.Value = v_strTAXCODE
                        v_entryNode.Attributes.Append(v_attrTAXCODE)

                        Dim v_attrCUSTNAME As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("custname")
                        v_attrCUSTNAME.Value = v_strCUSTNAME
                        v_entryNode.Attributes.Append(v_attrCUSTNAME)

                        Dim v_attrADDRESS As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("address")
                        v_attrADDRESS.Value = v_strADDRESS
                        v_entryNode.Attributes.Append(v_attrADDRESS)

                        Dim v_attrCONTENTS As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("contents")
                        v_attrCONTENTS.Value = v_strCONTENTS
                        v_entryNode.Attributes.Append(v_attrCONTENTS)

                        Dim v_attrDESCRIPTION As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("description")
                        v_attrDESCRIPTION.Value = v_strDESCRIPTION
                        v_entryNode.Attributes.Append(v_attrDESCRIPTION)

                        Dim v_attrQTTY As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("qtty")
                        v_attrQTTY.Value = v_dblQTTY
                        v_entryNode.Attributes.Append(v_attrQTTY)

                        Dim v_attrPRICE As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("price")
                        v_attrPRICE.Value = v_dblPRICE
                        v_entryNode.Attributes.Append(v_attrPRICE)

                        Dim v_attrAMT As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("amt")
                        v_attrAMT.Value = v_dblAMT
                        v_entryNode.Attributes.Append(v_attrAMT)

                        Dim v_attrVATRATE As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("vatrate")
                        v_attrVATRATE.Value = v_dblVATRATE
                        v_entryNode.Attributes.Append(v_attrVATRATE)

                        Dim v_attrVATAMT As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("vatamt")
                        v_attrVATAMT.Value = v_dblVATAMT
                        v_entryNode.Attributes.Append(v_attrVATAMT)

                        v_entryNode.InnerText = v_dblVATRATE
                        v_dataElement.AppendChild(v_entryNode)
                    Next
                    pv_xmlMessage.DocumentElement.AppendChild(v_dataElement)
                End If

                'Láº¥y pháº§n MITRAN
                v_strErrorMessage = "Láº¥y pháº§n MITRAN"
                v_strSQL = "SELECT * FROM MITRAN MST WHERE MST.TXNUM='" & v_strTXNUM & "' AND MST.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') ORDER BY MST.ACCTNO"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dataElement = pv_xmlMessage.CreateElement(Xml.XmlNodeType.Element, "mitran", "")
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        'XÃ¡c Ä‘á»‹nh cÃ¡c bÃºt toÃ¡n
                        v_dblMISUBTXNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("SUBTXNO"))
                        v_strMIDORC = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DORC"))
                        v_strMIACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACCTNO"))
                        v_strMICUSTID = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CUSTID"))
                        v_strMICUSTNAME = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CUSTNAME"))
                        v_strMITASKCD = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TASKCD"))
                        v_strMIDEPTCD = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DEPTCD"))
                        v_strMIMICD = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("MICD"))
                        v_strMIDESCRIPTION = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("DESCRIPTION"))

                        'Táº¡o bÃºt toÃ¡n Ä‘á»‹nh khoáº£n
                        v_entryNode = pv_xmlMessage.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                        Dim v_attrSUBTXNO As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("subtxno")
                        v_attrSUBTXNO.Value = v_dblMISUBTXNO
                        v_entryNode.Attributes.Append(v_attrSUBTXNO)

                        Dim v_attrDORC As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("dorc")
                        v_attrDORC.Value = v_strMIDORC
                        v_entryNode.Attributes.Append(v_attrDORC)

                        Dim v_attrACCTNO As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("acctno")
                        v_attrACCTNO.Value = v_strMIACCTNO
                        v_entryNode.Attributes.Append(v_attrACCTNO)

                        Dim v_attrCUSTID As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("custid")
                        v_attrCUSTID.Value = v_strMICUSTID
                        v_entryNode.Attributes.Append(v_attrCUSTID)

                        Dim v_attrCUSTNAME As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("custname")
                        v_attrCUSTNAME.Value = v_strMICUSTNAME
                        v_entryNode.Attributes.Append(v_attrCUSTNAME)

                        Dim v_attrTASKCD As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("taskcd")
                        v_attrTASKCD.Value = v_strMITASKCD
                        v_entryNode.Attributes.Append(v_attrTASKCD)

                        Dim v_attrDEPTCD As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("deptcd")
                        v_attrDEPTCD.Value = v_strMIDEPTCD
                        v_entryNode.Attributes.Append(v_attrDEPTCD)

                        Dim v_attrMICD As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("micd")
                        v_attrMICD.Value = v_strMIMICD
                        v_entryNode.Attributes.Append(v_attrMICD)

                        Dim v_attrDESCRIPTION As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("description")
                        v_attrDESCRIPTION.Value = v_strMIDESCRIPTION
                        v_entryNode.Attributes.Append(v_attrDESCRIPTION)

                        v_entryNode.InnerText = "MITRAN"
                        v_dataElement.AppendChild(v_entryNode)
                    Next
                    pv_xmlMessage.DocumentElement.AppendChild(v_dataElement)
                End If

                'Láº¥y pháº§n FeeTrans
                Dim v_strFEECD, v_strGLACCTNO As String
                Dim v_dblFLATAMT, v_dblFEEAMT, v_dblTXAMT, v_dblFEERATE, v_dblTOTALFEEAMT, v_dblTOTALVATAMT As Double
                v_dblTOTALFEEAMT = 0
                v_dblTOTALVATAMT = 0

                v_strErrorMessage = "Láº¥y pháº§n FEETRAN"
                v_strSQL = "SELECT * FROM FEETRAN MST WHERE MST.TXNUM='" & v_strTXNUM & "' AND MST.TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "') "
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_dataElement = pv_xmlMessage.CreateElement(Xml.XmlNodeType.Element, "feemap", "")
                    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        'XÃ¡c Ä‘á»‹nh cÃ¡c giao dá»‹ch thu phÃ­
                        v_strFEECD = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FEECD"))
                        v_strGLACCTNO = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("GLACCTNO"))
                        v_dblFEEAMT = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FEEAMT"))
                        v_dblVATAMT = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("VATAMT"))
                        v_dblVATRATE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("VATRATE"))
                        v_dblTXAMT = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TXAMT"))
                        v_dblFEERATE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("FEERATE"))
                        v_dblTOTALFEEAMT = v_dblTOTALFEEAMT + v_dblFEEAMT
                        v_dblTOTALVATAMT = v_dblTOTALVATAMT + v_dblVATAMT

                        'Táº¡o entry vá»? phÃ­
                        v_entryNode = pv_xmlMessage.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                        Dim v_attrFEECD As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("feecd")
                        v_attrFEECD.Value = v_strFEECD
                        v_entryNode.Attributes.Append(v_attrFEECD)

                        Dim v_attrGLACCTNO As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("glacctno")
                        v_attrGLACCTNO.Value = v_strGLACCTNO
                        v_entryNode.Attributes.Append(v_attrGLACCTNO)

                        Dim v_attrFEEAMT As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("feeamt")
                        v_attrFEEAMT.Value = v_dblFEEAMT
                        v_entryNode.Attributes.Append(v_attrFEEAMT)

                        Dim v_attrVATAMT As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("vatamt")
                        v_attrVATAMT.Value = v_dblVATAMT
                        v_entryNode.Attributes.Append(v_attrVATAMT)

                        Dim v_attrVATRATE As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("vatrate")
                        v_attrVATRATE.Value = v_dblVATRATE
                        v_entryNode.Attributes.Append(v_attrVATRATE)

                        Dim v_attrTXAMT As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("txamt")
                        v_attrTXAMT.Value = v_dblTXAMT
                        v_entryNode.Attributes.Append(v_attrTXAMT)

                        Dim v_attFEERATE As Xml.XmlAttribute = pv_xmlMessage.CreateAttribute("feerate")
                        v_attFEERATE.Value = v_dblFEERATE
                        v_entryNode.Attributes.Append(v_attFEERATE)

                        v_entryNode.InnerText = v_dblFEEAMT
                        v_dataElement.AppendChild(v_entryNode)
                    Next
                    pv_xmlMessage.DocumentElement.AppendChild(v_dataElement)
                End If
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeFEEAMT).Value = v_dblTOTALFEEAMT.ToString
                pv_xmlMessage.DocumentElement.Attributes(gc_AtributeVATAMT).Value = v_dblTOTALVATAMT.ToString

            Else
                v_lngErrCode = ERR_SA_TRANSACTION_NOTFOUND
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_strErrorMessage & vbNewLine _
                             & "Error message: " & v_strSQL, "EventLogEntryType.Error")
                BuildXMLErrorException(pv_xmlMessage, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
                Return v_lngErrCode
            End If
            'TruongLD Comment when convert
            'If Not v_obj Is Nothing Then v_obj.Dispose()
            Return v_lngErrCode
        Catch ex As Exception
            'TruongLD Comment when convert
            'If Not v_obj Is Nothing Then v_obj.Dispose()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function TransList(ByRef pv_xmlMessage As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK

        Try

            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function BuildAMTEXP(ByVal pv_xmlDocument As Xml.XmlDocument, ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent As String
            Dim v_lngIndex As Long
            Dim v_nodetxData As Xml.XmlNode
            Dim v_strFEEAMT As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeFEEAMT).Value.ToString
            Dim v_strVATAMT As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeVATAMT).Value.ToString

            v_strEvaluator = vbNullString
            v_lngIndex = 1

            While v_lngIndex < Len(strAMTEXP)
                'Get 02 charatacters in AMTEXP
                v_strElemenent = Mid$(strAMTEXP, v_lngIndex, 2)
                Select Case v_strElemenent
                    Case "FF"
                        'Fee amount
                        v_strEvaluator = v_strEvaluator & v_strFEEAMT
                    Case "VV"
                        'VAT amount
                        v_strEvaluator = v_strEvaluator & v_strVATAMT
                    Case "++", "--", "**", "//", "((", "))"
                        'Operand
                        v_strEvaluator = v_strEvaluator & Left$(v_strElemenent, 1)
                    Case "@1"
                        'Operand
                        v_strEvaluator = v_strEvaluator & "1"
                    Case "@0"
                        'Operand
                        v_strEvaluator = v_strEvaluator & "0"
                    Case Else
                        'Operator
                        v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strElemenent & "']")
                        v_strEvaluator = v_strEvaluator & v_nodetxData.InnerText
                End Select
                v_lngIndex = v_lngIndex + 2
            End While
            Return v_strEvaluator
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function TransLog(ByRef pv_xmlMessage As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty
        Dim v_strFLDCD, v_strFLDTYPE, v_strFLDRND, v_strDATATYPE, v_strVALUE As String, v_dblVALUE As Double
        Dim v_objEval As New Evaluator
        Try
            Dim v_blnBEGINEND As Boolean = False
            Dim v_obj As DataAccess
            If ATTR_REGION = gc_MODULE_BDS Then
                v_obj = New DataAccess
            ElseIf ATTR_REGION = gc_MODULE_HOST Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Insert into TLLOG
            Dim v_strTXNUM As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            Dim v_strTXDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            Dim v_strTXTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXTIME).Value.ToString
            Dim v_strBRID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
            Dim v_strTLID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLID).Value.ToString
            Dim v_strOFFID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            Dim v_strOVRRQS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
            Dim v_strCHID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHID).Value.ToString
            Dim v_strCHKID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKID).Value.ToString
            Dim v_strTLTXCD As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Dim v_strIBT As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeIBT).Value.ToString
            Dim v_strBRID2 As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRID2).Value.ToString
            Dim v_strTLID2 As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLID2).Value.ToString
            Dim v_strCCYUSAGE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCCYUSAGE).Value.ToString
            Dim v_strSTATUS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
            Dim v_strOFFLINE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFLINE).Value.ToString
            Dim v_strDELTD As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            Dim v_strBRDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRDATE).Value.ToString
            Dim v_strBUSDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBUSDATE).Value.ToString
            Dim v_strMSGSTS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeMSGSTS).Value.ToString
            Dim v_strOVRSTS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRSTS).Value.ToString
            Dim v_strIPADDRESS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeIPADDRESS).Value.ToString
            Dim v_strWSNAME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeWSNAME).Value.ToString
            Dim v_strCHKTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKTIME).Value.ToString
            Dim v_strOFFTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFTIME).Value.ToString
            Dim v_strTXDESC As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDESC).Value.ToString
            Dim v_strGLGP As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeGLGP).Value.ToString
            Dim v_strBATCHNAME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value.ToString
            Dim v_strCAREBY As String = gf_CorrectStringField(pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCAREBY).Value)
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)
            If Len(v_strBRDATE) = 0 Then v_strBRDATE = v_strTXDATE
            If Len(v_strBUSDATE) = 0 Then v_strBUSDATE = v_strTXDATE

            Dim v_ds As DataSet, v_strFLDCD_AMT, v_strFLDCD_ACCT, v_strFLDCD_CUST, v_strFLDCD_NAME As String
            Dim v_dblLOGAMT As Double = 0, v_strLOGACCT As String = String.Empty

            'get fldrnd
            Dim v_fldrnd As Integer
            v_strSQL = "SELECT F.FLDRND FROM TLTX T, FLDMASTER F WHERE T.TLTXCD  = F.OBJNAME AND T.MSG_AMT = FLDNAME and T.TLTXCD='" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_fldrnd = CDbl(IIf(IsDBNull(v_ds.Tables(0).Rows(0)("FLDRND")), vbNullString, v_ds.Tables(0).Rows(0)("FLDRND")))
            End If

            'Get Define MSGAMT, MSGACCT
            v_strSQL = "SELECT * FROM TLTX WHERE TLTXCD='" & v_strTLTXCD & "'"

            'Begin GianhVG add custody code for tllog
            Dim v_strCUSTODYCD, v_strFULLNAME As String
            v_strCUSTODYCD = ""
            v_strFULLNAME = ""

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                'Khong co dinh nghia giao dich
                v_lngErrorCode = ERR_SA_TLTXCD_NOTFOUND
                Return v_lngErrorCode
            Else
                v_strFLDCD_AMT = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("MSG_AMT")), vbNullString, v_ds.Tables(0).Rows(0)("MSG_AMT"))
                v_strFLDCD_ACCT = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("MSG_ACCT")), vbNullString, v_ds.Tables(0).Rows(0)("MSG_ACCT"))
                v_strFLDCD_CUST = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CFCUSTODYCD")), vbNullString, v_ds.Tables(0).Rows(0)("CFCUSTODYCD"))
                v_strFLDCD_NAME = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("CFFULLNAME")), vbNullString, v_ds.Tables(0).Rows(0)("CFFULLNAME"))
            End If
            If Trim(v_strFLDCD_AMT).Length >= 2 Then
                If v_strTLTXCD = gc_GL_NORMAL Then
                    v_dblLOGAMT = 0
                Else
                    v_strFLDCD_AMT = BuildAMTEXP(pv_xmlMessage, v_strFLDCD_AMT)
                    v_dblLOGAMT = CDbl(v_objEval.Eval(v_strFLDCD_AMT).ToString)
                    'Mặc định làm tròn đến hàng đơn vị
                    v_dblLOGAMT = gf_RoundNumber(v_dblLOGAMT, v_fldrnd)
                End If
            End If


            Try
                If v_strFLDCD_CUST = "##" Or v_strFLDCD_NAME = "##" Then
                    Dim v_nodePrininfo As Xml.XmlNode
                    v_nodePrininfo = pv_xmlMessage.SelectSingleNode("TransactMessage/printinfo/entry[@fldname='" & v_strFLDCD_ACCT & "']")
                    If Not v_nodePrininfo Is Nothing Then
                        If v_strFLDCD_CUST = "##" Then
                            v_strCUSTODYCD = v_nodePrininfo.Attributes("custody").Value
                        End If
                        If v_strFLDCD_NAME = "##" Then
                            v_strFULLNAME = v_nodePrininfo.Attributes("custname").Value
                        End If
                    End If
                End If
            Catch ex As Exception
                v_strCUSTODYCD = ""
                v_strFULLNAME = ""
            End Try
            'End GianhVG add custody code for tllog

            'LocalDB TruongLD Add
            'Check truoc khi Insert --> Neu co thi ko thuc hien Inser nua --> Return luon
            v_strSQL = "SELECT * FROM TLLOG WHERE TXNUM='" & v_strTXNUM & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Return v_lngErrorCode
            End If
            'End TruongLD

            'Insert into TLLOGFLD
            v_nodeList = pv_xmlMessage.SelectNodes("/TransactMessage/fields/entry")
            For i As Integer = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDRND = String.Empty
                    v_strDATATYPE = String.Empty
                    v_strFLDCD = .Attributes(gc_AtributeFLDNAME).Value.ToString
                    v_strFLDTYPE = .Attributes(gc_AtributeFLDTYPE).Value.ToString
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), .InnerText, 0)
                    Else
                        v_strVALUE = .InnerText
                        v_dblVALUE = 0
                    End If

                    If v_strFLDCD = gc_AtributeFLDTXDESC Then
                        v_strTXDESC = .InnerText
                    End If

                    If v_strFLDCD_ACCT.Length > 0 And v_strFLDCD_ACCT.Trim = v_strFLDCD.Trim Then v_strLOGACCT = v_strVALUE
                    If v_strFLDCD_CUST.Length > 0 And v_strFLDCD_CUST.Trim = v_strFLDCD.Trim Then v_strCUSTODYCD = v_strVALUE
                    If v_strFLDCD_NAME.Length > 0 And v_strFLDCD_NAME.Trim = v_strFLDCD.Trim Then v_strFULLNAME = v_strVALUE

                    'Ghi nhận vào TLLOGFLD
                    v_strSQL = "INSERT INTO TLLOGFLD (AUTOID, TXNUM, TXDATE, FLDCD, CVALUE, NVALUE) " _
                        & "VALUES (SEQ_TLLOGFLD.NEXTVAL,'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strFLDCD & "','" & v_strVALUE & "'," & v_dblVALUE & ") "
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End With
            Next

            v_strSQL = "INSERT INTO TLLOG (AUTOID, TXNUM, TXDATE, TXTIME, BRID, " _
                            & "TLID, OFFID, OVRRQS, CHID, CHKID, TLTXCD, " _
                            & "IBT, BRID2, TLID2, CCYUSAGE, TXSTATUS, MSGACCT, MSGAMT, CHKTIME, OFFTIME," _
                            & "OFF_LINE, DELTD, BRDATE, BUSDATE, MSGSTS, OVRSTS, IPADDRESS, WSNAME, BATCHNAME, CAREBYGRP, TXDESC,CFCUSTODYCD, CFFULLNAME) VALUES (SEQ_TLLOG.NEXTVAL,'" _
                            & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "','" & v_strBRID & "','" _
                            & v_strTLID & "','" & v_strOFFID & "','" & v_strOVRRQS & "','" & v_strCHID & "','" & v_strCHKID & "','" & v_strTLTXCD & "','" _
                            & v_strIBT & "','" & v_strBRID2 & "','" & v_strTLID2 & "','" & v_strCCYUSAGE & "','" & v_strSTATUS & "','" & v_strLOGACCT & "'," & v_dblLOGAMT & ",'" & v_strCHKTIME & "','" & v_strOFFTIME & "','" _
                            & v_strOFFLINE & "','" & v_strDELTD & "',TO_DATE('" & v_strBRDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strBUSDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                            & v_strMSGSTS & "','" & v_strOVRSTS & "','" & v_strIPADDRESS & "','" & v_strWSNAME & "','" & v_strBATCHNAME & "','" & v_strCAREBY & "','" & v_strTXDESC & "','" & v_strCUSTODYCD & "','" & v_strFULLNAME & "') "
            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            If v_strCHKID.Length > 0 Then
                'Nếu là Checker duyệt thì ghi nhận lại thời gian duyệt
                'v_strSQL = "UPDATE TLLOG " & ControlChars.CrLf _
                '                & "SET CHKTIME=TO_CHAR(SYSDATE,'HH:MI:SS')" & ControlChars.CrLf _
                '                & "WHERE TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                v_strSQL = "UPDATE TLLOG " & ControlChars.CrLf _
                                & "SET CHKTIME=TO_CHAR(SYSDATE,'HH:MI:SS')" & ControlChars.CrLf _
                                & "WHERE TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            If v_strOFFID.Length > 0 Then
                'Nếu là Officer duyệt thì ghi nhận lại thời gian duyệt
                v_strSQL = "UPDATE TLLOG " & ControlChars.CrLf _
                                & "SET OFFTIME=TO_CHAR(SYSDATE,'HH:MI:SS')" & ControlChars.CrLf _
                                & "WHERE TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'Scan VAT voucher, neu co thi tao hoa don, insert vao trong bang VATTRAN
            If v_blnReversal Then
                'Xoa cac hoa don VAT da nhap tuong ung voi giao dich
                v_strSQL = "UPDATE VATTRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Them cac hoa don VAT
                Dim v_nodeData As Xml.XmlNodeList
                Dim v_strVOUCHERNO, v_strVOUCHERTYPE, v_strSERIENO, v_strCUSTID, v_strTAXCODE, v_strCUSTNAME, v_strADDRESS, v_strCONTENTS, v_strDESCRIPTION As String
                Dim v_dblQTTY, v_dblPRICE, v_dblVATRATE, v_dblAMT, v_dblVATAMT As Double
                Dim v_strVOUCHERDATE As String
                v_nodeData = pv_xmlMessage.SelectNodes("/TransactMessage/vatvoucher/entry")
                If Not v_nodeData Is Nothing Then
                    For i As Integer = 0 To v_nodeData.Count - 1
                        v_strVOUCHERNO = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("voucherno"), Xml.XmlAttribute).Value)
                        v_strVOUCHERTYPE = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("vouchertype"), Xml.XmlAttribute).Value)
                        v_strSERIENO = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("serieno"), Xml.XmlAttribute).Value)
                        v_strVOUCHERDATE = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("voucherdate"), Xml.XmlAttribute).Value)
                        v_strCUSTID = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("custid"), Xml.XmlAttribute).Value)
                        v_strTAXCODE = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("taxcode"), Xml.XmlAttribute).Value)
                        v_strCUSTNAME = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("custname"), Xml.XmlAttribute).Value)
                        v_strADDRESS = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("address"), Xml.XmlAttribute).Value)
                        v_strCONTENTS = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("contents"), Xml.XmlAttribute).Value)
                        v_dblQTTY = CDbl(CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("qtty"), Xml.XmlAttribute).Value))
                        v_dblPRICE = CDbl(CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("price"), Xml.XmlAttribute).Value))
                        v_dblAMT = CDbl(CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("amt"), Xml.XmlAttribute).Value))
                        v_dblVATRATE = CDbl(CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("vatrate"), Xml.XmlAttribute).Value))
                        v_dblVATAMT = CDbl(CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("vatamt"), Xml.XmlAttribute).Value))
                        v_strDESCRIPTION = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("description"), Xml.XmlAttribute).Value)
                        v_strSQL = "INSERT INTO VATTRAN " _
                                   & "(AUTOID,TXNUM,TXDATE,VOUCHERNO,VOUCHERTYPE, " _
                                   & "SERIENO,VOUCHERDATE,CUSTID,TAXCODE, " _
                                   & "CUSTNAME,ADDRESS,CONTENTS,QTTY, " _
                                   & "PRICE,AMT,VATRATE,VATAMT,DESCRIPTION,DELTD) " _
                                   & "VALUES " _
                                   & "(SEQ_VATTRAN.NEXTVAL,'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strVOUCHERNO & "','" & v_strVOUCHERTYPE & "'," _
                                   & "'" & v_strSERIENO & "',TO_DATE('" & v_strVOUCHERDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strCUSTID & "','" & v_strTAXCODE & "', " _
                                   & "'" & v_strCUSTNAME & "','" & v_strADDRESS & "','" & v_strCONTENTS & "'," & v_dblQTTY & "," _
                                   & "" & v_dblPRICE & "," & v_dblAMT & "," & v_dblVATRATE & "," & v_dblVATAMT & ",'" & v_strDESCRIPTION & "','N')"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If

            'Scan Mitran, neu co thi tao du lieu, insert vao trong bang MITRAN
            If v_blnReversal Then
                'Xoa cac hoa don VAT da nhap tuong ung voi giao dich
                v_strSQL = "UPDATE MITRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Them Fixed assest
                Dim v_nodeData As Xml.XmlNodeList
                Dim v_dblMISUBTXNO As Double, v_strMIDORC, v_strMIACCTNO, v_strMICUSTID, v_strMICUSTNAME, v_strMITASKCD, v_strMIDEPTCD, v_strMIMICD, v_strMIDESCRIPTION As String
                v_nodeData = pv_xmlMessage.SelectNodes("/TransactMessage/mitran/entry")
                If Not v_nodeData Is Nothing Then
                    For i As Integer = 0 To v_nodeData.Count - 1
                        v_dblMISUBTXNO = CDbl(CType(v_nodeData.Item(i).Attributes.GetNamedItem("subtxno"), Xml.XmlAttribute).Value)
                        v_strMIDORC = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("dorc"), Xml.XmlAttribute).Value)
                        v_strMIACCTNO = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("acctno"), Xml.XmlAttribute).Value)
                        v_strMICUSTID = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("custid"), Xml.XmlAttribute).Value)
                        v_strMICUSTNAME = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("custname"), Xml.XmlAttribute).Value)
                        v_strMITASKCD = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("taskcd"), Xml.XmlAttribute).Value)
                        v_strMIDEPTCD = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("deptcd"), Xml.XmlAttribute).Value)
                        v_strMIMICD = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("micd"), Xml.XmlAttribute).Value)
                        v_strMIDESCRIPTION = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("description"), Xml.XmlAttribute).Value)

                        If v_strGLGP = "Y" Then
                            v_strSQL = " INSERT INTO MITRANDTL " _
                                       & " (AUTOID,TXDATE,TXNUM,SUBTXNO,DORC,ACCTNO,CUSTID,CUSTNAME,TASKCD,DEPTCD,MICD,DESCRIPTION,DELTD) " _
                                       & " VALUES " _
                                       & " (SEQ_MITRAN.NEXTVAL,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'," & v_dblMISUBTXNO & ",'" & v_strMIDORC & "','" & v_strMIACCTNO & "','" & v_strMICUSTID & "','" & v_strMICUSTNAME & "','" & v_strMITASKCD & "','" & v_strMIDEPTCD & "','" & v_strMIMICD & "','" & v_strMIDESCRIPTION & "','N') "
                        Else
                            v_strSQL = " INSERT INTO MITRAN " _
                                        & " (AUTOID,TXDATE,TXNUM,SUBTXNO,DORC,ACCTNO,CUSTID,CUSTNAME,TASKCD,DEPTCD,MICD,DESCRIPTION,DELTD) " _
                                        & " VALUES " _
                                        & " (SEQ_MITRAN.NEXTVAL,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'," & v_dblMISUBTXNO & ",'" & v_strMIDORC & "','" & v_strMIACCTNO & "','" & v_strMICUSTID & "','" & v_strMICUSTNAME & "','" & v_strMITASKCD & "','" & v_strMIDEPTCD & "','" & v_strMIMICD & "','" & v_strMIDESCRIPTION & "','N') "
                        End If

                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    Next
                End If
            End If

            'Scan feemap, neu co thi tao du lieu, insert vao trong bang FEETRAN
            If v_blnReversal Then
                'Xoa cac hoa don VAT da nhap tuong ung voi giao dich
                v_strSQL = "UPDATE FEETRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Them Feetran
                Dim v_nodeData As Xml.XmlNodeList
                Dim v_dblFEEAMT, v_dblVATAMT, v_dblTXAMT, v_dblFEERATE, v_dblVATRATE As Double, v_strFEECD, v_strGLACCTNO As String
                v_nodeData = pv_xmlMessage.SelectNodes("/TransactMessage/feemap/entry")
                If Not v_nodeData Is Nothing Then
                    For i As Integer = 0 To v_nodeData.Count - 1
                        v_dblFEEAMT = CDbl(CType(v_nodeData.Item(i).Attributes.GetNamedItem("feeamt"), Xml.XmlAttribute).Value)
                        v_dblVATAMT = CDbl(CType(v_nodeData.Item(i).Attributes.GetNamedItem("vatamt"), Xml.XmlAttribute).Value)
                        v_dblTXAMT = CDbl(CType(v_nodeData.Item(i).Attributes.GetNamedItem("txamt"), Xml.XmlAttribute).Value)
                        v_dblFEERATE = CDbl(CType(v_nodeData.Item(i).Attributes.GetNamedItem("feerate"), Xml.XmlAttribute).Value)
                        v_dblVATRATE = CDbl(CType(v_nodeData.Item(i).Attributes.GetNamedItem("vatrate"), Xml.XmlAttribute).Value)
                        v_strGLACCTNO = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("glacctno"), Xml.XmlAttribute).Value)
                        v_strFEECD = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("feecd"), Xml.XmlAttribute).Value)

                        v_strSQL = " INSERT INTO FEETRAN " _
                                    & " (AUTOID,TXDATE,TXNUM,DELTD,FEECD,GLACCTNO,FEEAMT,VATAMT,TXAMT,FEERATE,VATRATE) " _
                                    & " VALUES " _
                                    & " (SEQ_FEETRAN.NEXTVAL,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "','N','" & v_strFEECD & "','" & v_strGLACCTNO & "'," & v_dblFEEAMT & "," & v_dblVATAMT & "," & v_dblTXAMT & "," & v_dblFEERATE & "," & v_dblVATRATE & ") "
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    Next
                End If
            End If

            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Public Function TransLog4DR(ByRef pv_xmlMessage As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty, v_strRunSQL As String = String.Empty
        Dim v_strFLDCD, v_strFLDTYPE, v_strFLDRND, v_strDATATYPE, v_strVALUE As String, v_dblVALUE As Double
        Dim v_objEval As New Evaluator
        Try
            Dim v_blnBEGINEND As Boolean = False
            Dim v_obj As DataAccess
            If ATTR_REGION = gc_MODULE_BDS Then
                v_obj = New DataAccess
            ElseIf ATTR_REGION = gc_MODULE_HOST Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Insert into TLLOG
            Dim v_strTXNUM As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            Dim v_strTXDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            Dim v_strTXTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXTIME).Value.ToString
            Dim v_strBRID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
            Dim v_strTLID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLID).Value.ToString
            Dim v_strOFFID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            Dim v_strOVRRQS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
            Dim v_strCHID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHID).Value.ToString
            Dim v_strCHKID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKID).Value.ToString
            Dim v_strTLTXCD As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Dim v_strIBT As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeIBT).Value.ToString
            Dim v_strBRID2 As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRID2).Value.ToString
            Dim v_strTLID2 As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLID2).Value.ToString
            Dim v_strCCYUSAGE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCCYUSAGE).Value.ToString
            Dim v_strSTATUS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
            Dim v_strOFFLINE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFLINE).Value.ToString
            Dim v_strDELTD As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            Dim v_strBRDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRDATE).Value.ToString
            Dim v_strBUSDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBUSDATE).Value.ToString
            Dim v_strMSGSTS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeMSGSTS).Value.ToString
            Dim v_strOVRSTS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRSTS).Value.ToString
            Dim v_strIPADDRESS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeIPADDRESS).Value.ToString
            Dim v_strWSNAME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeWSNAME).Value.ToString
            Dim v_strCHKTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKTIME).Value.ToString
            Dim v_strOFFTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFTIME).Value.ToString
            Dim v_strTXDESC As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDESC).Value.ToString
            Dim v_strGLGP As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeGLGP).Value.ToString
            Dim v_strBATCHNAME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value.ToString
            Dim v_strCAREBY As String = gf_CorrectStringField(pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCAREBY).Value)
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)
            If Len(v_strBRDATE) = 0 Then v_strBRDATE = v_strTXDATE
            If Len(v_strBUSDATE) = 0 Then v_strBUSDATE = v_strTXDATE

            'Get Define MSGAMT, MSGACCT
            v_strSQL = "SELECT * FROM TLTX WHERE TLTXCD='" & v_strTLTXCD & "'"
            Dim v_ds As DataSet, v_strFLDCD_AMT, v_strFLDCD_ACCT As String
            Dim v_dblLOGAMT As Double = 0, v_strLOGACCT As String = String.Empty
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If Not v_ds.Tables(0).Rows.Count > 0 Then
                'Khong co dinh nghia giao dich
                v_lngErrorCode = ERR_SA_TLTXCD_NOTFOUND
                Return v_lngErrorCode
            Else
                v_strFLDCD_AMT = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("MSG_AMT")), vbNullString, v_ds.Tables(0).Rows(0)("MSG_AMT"))
                v_strFLDCD_ACCT = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("MSG_ACCT")), vbNullString, v_ds.Tables(0).Rows(0)("MSG_ACCT"))
            End If
            If Trim(v_strFLDCD_AMT).Length >= 2 Then
                If v_strTLTXCD = gc_GL_NORMAL Then
                    v_dblLOGAMT = 0
                Else
                    v_strFLDCD_AMT = BuildAMTEXP(pv_xmlMessage, v_strFLDCD_AMT)
                    v_dblLOGAMT = CDbl(v_objEval.Eval(v_strFLDCD_AMT).ToString)
                    'Mặc định làm tròn đến hàng đơn vị
                    v_dblLOGAMT = gf_RoundNumber(v_dblLOGAMT, "0")
                End If
            End If

            'Begin GianhVG add custody code for tllog
            Dim v_strCUSTODYCD, v_strFULLNAME As String
            v_strCUSTODYCD = ""
            v_strFULLNAME = ""
            Try
                Dim v_nodePrininfo As Xml.XmlNode
                v_nodePrininfo = pv_xmlMessage.SelectSingleNode("TransactMessage/printinfo/entry[@fldname='" & v_strFLDCD_ACCT & "']")
                If Not v_nodePrininfo Is Nothing Then
                    v_strCUSTODYCD = v_nodePrininfo.Attributes("custody").Value
                    v_strFULLNAME = v_nodePrininfo.Attributes("custname").Value
                End If
            Catch ex As Exception
                v_strCUSTODYCD = ""
                v_strFULLNAME = ""
            End Try
            'End GianhVG add custody code for tllog


            v_strRunSQL = "Begin " & ControlChars.CrLf
            'Insert into TLLOGFLD
            v_nodeList = pv_xmlMessage.SelectNodes("/TransactMessage/fields/entry")
            For i As Integer = 0 To v_nodeList.Count - 1
                With v_nodeList.Item(i)
                    v_strFLDRND = String.Empty
                    v_strDATATYPE = String.Empty
                    v_strFLDCD = .Attributes(gc_AtributeFLDNAME).Value.ToString
                    v_strFLDTYPE = .Attributes(gc_AtributeFLDTYPE).Value.ToString
                    If v_strFLDTYPE = "N" Then
                        v_strVALUE = vbNullString
                        v_dblVALUE = IIf(IsNumeric(.InnerText), .InnerText, 0)
                    Else
                        v_strVALUE = .InnerText
                        v_dblVALUE = 0
                    End If

                    If v_strFLDCD = gc_AtributeFLDTXDESC Then
                        v_strTXDESC = .InnerText
                    End If

                    If v_strFLDCD_ACCT.Length > 0 And v_strFLDCD_ACCT.Trim = v_strFLDCD.Trim Then v_strLOGACCT = v_strVALUE
                    'Ghi nhận vào TLLOGFLD
                    v_strSQL = "INSERT INTO TLLOGFLD4DR (AUTOID, TXNUM, TXDATE, FLDCD, CVALUE, NVALUE) " _
                        & "VALUES (SEQ_TLLOGFLD4DR.NEXTVAL,'" & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strFLDCD & "','" & v_strVALUE & "'," & v_dblVALUE & "); "
                    'v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strRunSQL = v_strRunSQL & v_strSQL & ControlChars.CrLf
                End With
            Next

            v_strSQL = "INSERT INTO TLLOG4DR (AUTOID, TXNUM, TXDATE, TXTIME, BRID, " _
                            & "TLID, OFFID, OVRRQS, CHID, CHKID, TLTXCD, " _
                            & "IBT, BRID2, TLID2, CCYUSAGE, TXSTATUS, MSGACCT, MSGAMT, CHKTIME, OFFTIME," _
                            & "OFF_LINE, DELTD, BRDATE, BUSDATE, MSGSTS, OVRSTS, IPADDRESS, WSNAME, BATCHNAME, CAREBYGRP, TXDESC,CFCUSTODYCD, CFFULLNAME) VALUES (SEQ_TLLOG4DR.NEXTVAL,'" _
                            & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXTIME & "','" & v_strBRID & "','" _
                            & v_strTLID & "','" & v_strOFFID & "','" & v_strOVRRQS & "','" & v_strCHID & "','" & v_strCHKID & "','" & v_strTLTXCD & "','" _
                            & v_strIBT & "','" & v_strBRID2 & "','" & v_strTLID2 & "','" & v_strCCYUSAGE & "','" & v_strSTATUS & "','" & v_strLOGACCT & "'," & v_dblLOGAMT & ",'" & v_strCHKTIME & "','" & v_strOFFTIME & "','" _
                            & v_strOFFLINE & "','" & v_strDELTD & "',TO_DATE('" & v_strBRDATE & "', '" & gc_FORMAT_DATE & "'),TO_DATE('" & v_strBUSDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                            & v_strMSGSTS & "','" & v_strOVRSTS & "','" & v_strIPADDRESS & "','" & v_strWSNAME & "','" & v_strBATCHNAME & "','" & v_strCAREBY & "','" & v_strTXDESC & "','" & v_strCUSTODYCD & "','" & v_strFULLNAME & "'); "
            v_strRunSQL = v_strRunSQL & v_strSQL & ControlChars.CrLf
            v_strRunSQL = v_strRunSQL & "End;"
            v_obj.ExecuteNonQuery(CommandType.Text, v_strRunSQL)
            v_strRunSQL = String.Empty
            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


    Public Function MitranLog(ByRef pv_xmlMessage As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQLTmp As String = String.Empty, v_strSQL As String = String.Empty
        Dim v_strFLDCD As String, v_strFLDTYPE As String, v_strVALUE As String, v_dblVALUE As Double
        Dim v_objEval As New Evaluator
        Try
            Dim v_blnBEGINEND As Boolean = False
            Dim v_obj As DataAccess
            If ATTR_REGION = gc_MODULE_BDS Then
                v_obj = New DataAccess
            ElseIf ATTR_REGION = gc_MODULE_HOST Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Insert into TLLOG
            Dim v_strTXNUM As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            Dim v_strTXDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            Dim v_strTXTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXTIME).Value.ToString
            Dim v_strBRID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRID).Value.ToString
            Dim v_strTLID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLID).Value.ToString
            Dim v_strOFFID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            Dim v_strOVRRQS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
            Dim v_strCHID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHID).Value.ToString
            Dim v_strCHKID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKID).Value.ToString
            Dim v_strTLTXCD As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Dim v_strIBT As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeIBT).Value.ToString
            Dim v_strBRID2 As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRID2).Value.ToString
            Dim v_strTLID2 As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTLID2).Value.ToString
            Dim v_strCCYUSAGE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCCYUSAGE).Value.ToString
            Dim v_strSTATUS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
            Dim v_strOFFLINE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFLINE).Value.ToString
            Dim v_strDELTD As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            Dim v_strBRDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBRDATE).Value.ToString
            Dim v_strBUSDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBUSDATE).Value.ToString
            Dim v_strMSGSTS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeMSGSTS).Value.ToString
            Dim v_strOVRSTS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRSTS).Value.ToString
            Dim v_strIPADDRESS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeIPADDRESS).Value.ToString
            Dim v_strWSNAME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeWSNAME).Value.ToString
            Dim v_strCHKTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKTIME).Value.ToString
            Dim v_strOFFTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFTIME).Value.ToString
            Dim v_strTXDESC As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDESC).Value.ToString
            Dim v_strGLGP As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeGLGP).Value.ToString
            Dim v_strBATCHNAME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeBATCHNAME).Value.ToString
            Dim v_strCAREBY As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCAREBY).Value.ToString
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)
            If Len(v_strBRDATE) = 0 Then v_strBRDATE = v_strTXDATE
            If Len(v_strBUSDATE) = 0 Then v_strBUSDATE = v_strTXDATE


            'Scan Mitran, neu co thi tao du lieu, insert vao trong bang MITRAN
            If v_blnReversal Then
                'Xoa cac hoa don VAT da nhap tuong ung voi giao dich
                v_strSQL = "UPDATE MITRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            Else
                'Them Fixed assest
                Dim v_nodeData As Xml.XmlNodeList
                Dim v_dblMISUBTXNO As Double, v_strMIDORC, v_strMIACCTNO, v_strMICUSTID, v_strMICUSTNAME, v_strMITASKCD, v_strMIDEPTCD, v_strMIMICD, v_strMIDESCRIPTION As String
                v_nodeData = pv_xmlMessage.SelectNodes("/TransactMessage/mitran/entry")
                If Not v_nodeData Is Nothing Then
                    For i As Integer = 0 To v_nodeData.Count - 1
                        v_dblMISUBTXNO = CDbl(CType(v_nodeData.Item(i).Attributes.GetNamedItem("subtxno"), Xml.XmlAttribute).Value)
                        v_strMIDORC = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("dorc"), Xml.XmlAttribute).Value)
                        v_strMIACCTNO = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("acctno"), Xml.XmlAttribute).Value)
                        v_strMICUSTID = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("custid"), Xml.XmlAttribute).Value)
                        v_strMICUSTNAME = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("custname"), Xml.XmlAttribute).Value)
                        v_strMITASKCD = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("taskcd"), Xml.XmlAttribute).Value)
                        v_strMIDEPTCD = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("deptcd"), Xml.XmlAttribute).Value)
                        v_strMIMICD = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("micd"), Xml.XmlAttribute).Value)
                        v_strMIDESCRIPTION = CStr(CType(v_nodeData.Item(i).Attributes.GetNamedItem("description"), Xml.XmlAttribute).Value)

                        If v_strGLGP = "Y" Then
                            v_strSQL = " INSERT INTO MITRANDTL " _
                                       & " (AUTOID,TXDATE,TXNUM,SUBTXNO,DORC,ACCTNO,CUSTID,CUSTNAME,TASKCD,DEPTCD,MICD,DESCRIPTION,DELTD) " _
                                       & " VALUES " _
                                       & " (SEQ_MITRAN.NEXTVAL,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'," & v_dblMISUBTXNO & ",'" & v_strMIDORC & "','" & v_strMIACCTNO & "','" & v_strMICUSTID & "','" & v_strMICUSTNAME & "','" & v_strMITASKCD & "','" & v_strMIDEPTCD & "','" & v_strMIMICD & "','" & v_strMIDESCRIPTION & "','N') "
                        Else
                            v_strSQL = " INSERT INTO MITRAN " _
                                        & " (AUTOID,TXDATE,TXNUM,SUBTXNO,DORC,ACCTNO,CUSTID,CUSTNAME,TASKCD,DEPTCD,MICD,DESCRIPTION,DELTD) " _
                                        & " VALUES " _
                                        & " (SEQ_MITRAN.NEXTVAL,TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" & v_strTXNUM & "'," & v_dblMISUBTXNO & ",'" & v_strMIDORC & "','" & v_strMIACCTNO & "','" & v_strMICUSTID & "','" & v_strMICUSTNAME & "','" & v_strMITASKCD & "','" & v_strMIDEPTCD & "','" & v_strMIMICD & "','" & v_strMIDESCRIPTION & "','N') "
                        End If

                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    Next
                End If
            End If
            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function TransUpdateStatus(ByRef pv_xmlMessage As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK

        Try
            Dim v_obj As DataAccess
            If ATTR_REGION = gc_MODULE_BDS Then
                v_obj = New DataAccess
            ElseIf ATTR_REGION = gc_MODULE_HOST Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Update TLLOG: by set STATUS field
            Dim v_strTXNUM As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            Dim v_strTXDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            Dim v_strSTATUS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
            Dim v_strOVRRQS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
            Dim v_strOFFID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            Dim v_strCHKID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKID).Value.ToString
            Dim v_strCHID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHID).Value.ToString
            Dim v_strTXDESC As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDESC).Value.ToString
            Dim v_strOFFTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFTIME).Value.ToString
            Dim v_strSQL As String

            'Kienvt sua : Lay gio o server
            If v_strCHKID.Length > 0 Then
                v_strSQL = "UPDATE TLLOG " & ControlChars.CrLf _
                                & "SET CHKTIME=TO_CHAR(SYSDATE,'HH24:MI:SS')" & ControlChars.CrLf _
                                & "WHERE CHKID IS NULL AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            If v_strOFFID.Length > 0 Then
                If v_strOFFTIME.Length > 0 Then
                    v_strSQL = "UPDATE TLLOG " & ControlChars.CrLf _
                              & "SET OFFTIME='" & v_strOFFTIME & "'" & ControlChars.CrLf _
                              & "WHERE OFFID IS NULL AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_strSQL = "UPDATE TLLOG " & ControlChars.CrLf _
                                & "SET OFFTIME=TO_CHAR(SYSDATE,'HH24:MI:SS')" & ControlChars.CrLf _
                                & "WHERE OFFID IS NULL AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

            End If

            v_strSQL = "UPDATE TLLOG " & ControlChars.CrLf _
                            & "SET TXSTATUS='" & v_strSTATUS & "', OVRRQS='" & v_strOVRRQS & "'," & ControlChars.CrLf _
                            & "OFFID='" & v_strOFFID & "', CHKID='" & v_strCHKID & "', CHID='" & v_strCHID & "' " & ControlChars.CrLf _
                            & ", PTXSTATUS = PTXSTATUS ||'" & v_strSTATUS & "'" & ControlChars.CrLf _
                            & "WHERE TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"


            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function TransUpdate4DR(ByRef pv_xmlMessage As Xml.XmlDocument) As Long
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK

        Try
            Dim v_obj As DataAccess
            If ATTR_REGION = gc_MODULE_BDS Then
                v_obj = New DataAccess
            ElseIf ATTR_REGION = gc_MODULE_HOST Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            'Update TLLOG: by set STATUS field
            Dim v_strTXNUM As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
            Dim v_strTXDATE As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
            Dim v_strSTATUS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString
            Dim v_strOVRRQS As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
            Dim v_strOFFID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            Dim v_strCHKID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHKID).Value.ToString
            Dim v_strCHID As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeCHID).Value.ToString
            Dim v_strTXDESC As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeTXDESC).Value.ToString
            Dim v_strOFFTIME As String = pv_xmlMessage.DocumentElement.Attributes(gc_AtributeOFFTIME).Value.ToString
            Dim v_strSQL As String

            'Kienvt sua : Lay gio o server
            If v_strCHKID.Length > 0 Then
                v_strSQL = "UPDATE TLLOG4DR " & ControlChars.CrLf _
                                & "SET CHKTIME=TO_CHAR(SYSDATE,'HH24:MI:SS')" & ControlChars.CrLf _
                                & "WHERE CHKID IS NULL AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            If v_strOFFID.Length > 0 Then
                If v_strOFFTIME.Length > 0 Then
                    v_strSQL = "UPDATE TLLOG4DR " & ControlChars.CrLf _
                              & "SET OFFTIME='" & v_strOFFTIME & "'" & ControlChars.CrLf _
                              & "WHERE OFFID IS NULL AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                Else
                    v_strSQL = "UPDATE TLLOG4DR " & ControlChars.CrLf _
                                & "SET OFFTIME=TO_CHAR(SYSDATE,'HH24:MI:SS')" & ControlChars.CrLf _
                                & "WHERE OFFID IS NULL AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                End If

            End If

            v_strSQL = "UPDATE TLLOG4DR " & ControlChars.CrLf _
                            & "SET TXSTATUS='" & v_strSTATUS & "', OVRRQS='" & v_strOVRRQS & "'," & ControlChars.CrLf _
                            & "OFFID='" & v_strOFFID & "', CHKID='" & v_strCHKID & "', CHID='" & v_strCHID & "' " & ControlChars.CrLf _
                            & "WHERE TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"


            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            Return v_lngErrorCode
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

End Class
