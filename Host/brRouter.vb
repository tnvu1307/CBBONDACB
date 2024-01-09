Imports HostCommonLibrary
Imports CoreBusiness
Imports DataAccessLayer
Imports System.Configuration
Imports System.Xml
Imports System.Transactions
Imports System.Data

Public Class brRouter
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Private BranchID As String = HOST_BRID

#Region " Transact "
    Private Function BuildAMTEXP(ByVal pv_xmlDocument As Xml.XmlDocument, ByVal strAMTEXP As String) As String
        Try
            Dim v_strEvaluator, v_strElemenent As String
            Dim v_lngIndex As Long
            Dim v_nodetxData As Xml.XmlNode
            Dim v_strFEEAMT As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeFEEAMT).Value.ToString
            Dim v_strVATAMT As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeVATAMT).Value.ToString

            v_strFEEAMT = IIf(v_strFEEAMT.Length = 0, "0", v_strFEEAMT)
            v_strVATAMT = IIf(v_strVATAMT.Length = 0, "0", v_strVATAMT)

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
                    Case Else
                        'Operator
                        v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strElemenent & "']")
                        v_strEvaluator = v_strEvaluator & v_nodetxData.InnerText
                End Select
                v_lngIndex = v_lngIndex + 2
            End While
            Complete() 'ContextUtil.SetComplete()
            Return v_strEvaluator
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function txTransact(ByRef pv_strTxMsg As String) As Long
        Dim v_strErrorSource As String = "Host.brRouter.txTransact", v_strErrorMessage As String
        Dim v_xmlDocumentMessage As XmlDocument = New XmlDocumentEx()
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_lngErrLog As Long = ERR_SYSTEM_OK
        Try
            v_xmlDocumentMessage.LoadXml(pv_strTxMsg)
            ''Get header message.
            Dim v_attrColl = v_xmlDocumentMessage.DocumentElement.Attributes
            Dim v_strMSGTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeMSGTYPE).Value

            Select Case v_strMSGTYPE
                Case modCommond.gc_MsgTypeTranS
                    Dim v_strTXTYPE = v_attrColl.GetNamedItem(modCommond.gc_AtributeTXTYPE).Value
                    If v_strTXTYPE.Trim() = "I" Then
                        v_lngErrCode = (New Host.miscRouter()).Transact(v_xmlDocumentMessage)
                    Else
                        Using trs As New TransactionScope(TransactionScopeOption.RequiresNew, New TimeSpan(0, 0, 0, Convert.ToInt32(ConfigurationManager.AppSettings("TransactionScopeTimeOut"))))
                            Try
                                v_lngErrCode = (New Host.txRouter()).Transact(v_xmlDocumentMessage)
                                If Not (v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR) Then
                                    trs.Complete()
                                End If
                            Catch ex As Exception
                                trs.Dispose()
                                LogError.WriteException(ex)
                                Return HostCommonLibrary.ERR_SYSTEM_START
                            End Try
                        End Using
                    End If
            End Select

            pv_strTxMsg = v_xmlDocumentMessage.InnerXml

            If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                Rollback()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function txTransfer(ByRef pv_strTxMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_lngErrLog As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Branch.Branch.txTransfer", v_strErrorMessage As String

        Dim v_xmlDocument As New Xml.XmlDocument ', v_ws As HOSTDelivery.HOSTDelivery, 
        Dim v_objDataAcess As New DataAccess
        Dim v_nodeList As Xml.XmlNodeList, v_xmlObjDocument As New Xml.XmlDocument, v_objMessageLog As New MessageLog
        Dim v_strObjMsg As String, v_strValue As String, v_strFLDNAME As String
        Dim v_strGRNAME As String, v_strVARNAME As String, v_strVARVALUE As String, v_blnApproval As Boolean = False
        Dim v_strBRID As String, v_strTXDATE As String, v_strTXTIME As String, v_strLOCAL As String
        Dim v_strREFOBJ As String = String.Empty
        Dim v_strREFKEYFLD As String = String.Empty
        Dim v_strRefKeyVal As String = String.Empty
        Dim v_strApproveRequire As String = String.Empty
        Dim v_objTranfer As New objRouter
        Try
            Dim v_strSYSVAR As String, v_DataAccess As New DataAccess
            Dim v_strSQL As String
            Dim v_strLog4DR As String
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "LOG4DR", v_strLog4DR)

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strSYSVAR = OPERATION_INACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_BDS_OPERATION_ISINACTIVE
            End If
            v_xmlDocument.LoadXml(pv_strTxMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_strTXNUM As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Dim v_strOVRRQD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            Dim v_strOFFID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            Dim v_strCHKID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            Dim v_intSTATUS As Integer = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            Dim v_strDELTD As String = Trim(CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value))
            Dim v_strTXTYPE As String = Trim(CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXTYPE), Xml.XmlAttribute).Value))
            Dim v_strNOSUBMIT As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeNOSUBMIT), Xml.XmlAttribute).Value)
            Dim v_strLATE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLATE), Xml.XmlAttribute).Value)
            Dim v_strGLGP As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeGLGP), Xml.XmlAttribute).Value)
            Dim v_strTLID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            '---------------------------------------------------------------------------------------------------------------------
            'Sơ đồ luồng xử lý điện giao dịch như sau:
            'Bộ các tham số ảnh hưởng đến luồng xử lý giao dịch gồm:
            'STATUS, TXTYPE, NOSUBMIT, DELTD, OVRRQS, CHKID, OFFID
            'Nếu OVRRQS chứa giá trị @00 tức là cần OFFID duyệt (checker 2)
            'Nếu OVRRQS chứa giá trị khác ngoài @00 tức cần CHKID duyệt (checker 1)
            'Nội dung của OVRRQS được tạo tại Branch.VerifyRule và txCheck của các phân hệ nghiệp vụ.
            'Giao dịch được xem là đã duyệt nếu như trư?ng CHKID, OFFID có giá trị
            'Các nguyên nhận duyệt tại Branch gồm: Vượt hạn mức, IBT, xoá giao dịch và giao dịch được định nghĩa phải duyệt.
            '?ịnh nghĩa phải duyệt của giao dịch tức là cần OFFID duyệt, các trư?ng hợp khác là dành cho CHKID.
            'Thứ tự chuyển trạng thái của các loại giao dịch như sau:
            ' Loại I/M/T: New-Pending to approve/Approval/Rejected-Completed/Error
            ' Loại D: New-Pending to approve/Approval/Rejected-Cashier-Completed/Error
            ' Loại W: New-Pending to approve/Approval/Rejected-Cashier-Completed/Error
            '?ối với loại W, trạng thái Cashier là phải ghi nhận trên HOST, các loại khác chỉ ghi nhận khi đã là Completed
            'Trư?ng hợp NOSUBMIT=1 sẽ xử lý ngay. NOSUBMIT=2 thì lần đầu chỉ lấy PRINTINFO và POSTMAP lần sau xử lý giống NOSUBMIT=1
            'Trư?ng hợp xoá giao dịch chỉ thực hiện trên HOST nếu trạng thái là Completed và Cashier (trong trư?ng h�ợp giao dịch là W)
            '---------------------------------------------------------------------------------------------------------------------

            If Len(v_strTXNUM) = 0 Then 'Submit lần đầu tiên
                'Lấy tham số của phần giao dịch
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , "upper(TLTXCD) = '" & v_strTLTXCD & "'")

                'TruongLD Add 13/03/2014
                'objTransfer(v_strObjMsg)
                v_objTranfer.Transfer(v_strObjMsg)
                'End TruongLD

                v_xmlObjDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlObjDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "TXTYPE"
                                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTYPE).InnerXml = v_strValue
                                    v_strTXTYPE = v_strValue
                                Case "NOSUBMIT"
                                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeNOSUBMIT).InnerXml = v_strValue
                                    v_strNOSUBMIT = v_strValue
                                Case "OVRRQD"
                                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).InnerXml = v_strValue
                                    v_strOVRRQD = v_strValue
                                    v_strApproveRequire = v_strValue
                                Case "LOCAL"
                                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeLOCAL).InnerXml = v_strValue
                                    v_strLOCAL = v_strValue
                                Case "LATE"
                                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeLATE).InnerXml = v_strValue
                                    v_strLATE = v_strValue
                                Case "GLGP"
                                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeGLGP).InnerXml = v_strValue
                                    v_strGLGP = v_strValue
                                Case "REFOBJ"
                                    v_strREFOBJ = v_strValue
                                Case "REFKEYFLD"
                                    v_strREFKEYFLD = v_strValue
                            End Select
                        End With
                    Next
                Next

                'Get KeyRefValue de ghi log TLLOGEXT
                If v_strREFOBJ.Length > 0 And v_strREFKEYFLD.Length > 0 Then
                    v_strRefKeyVal = GetKeyFldVal(pv_strTxMsg, v_strREFKEYFLD)
                End If

                'v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "BRID", v_strBRID)

                'locpt 20141209 do bỏ BDS nên sẽ lấy BRID từ dưới client truyền lên
                ' v_strBRID = BranchID
                ' neu BRID = '' thi se gan mac dinh la BRID của HOST
                If (v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).InnerXml = "") Then
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).InnerXml = BranchID
                End If
                ' gan lai strBRID de build txnum theo chi nhanh
                v_strBRID = v_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).InnerXml
                'end locpt 20141209
                v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "CURRDATE", v_strTXDATE)
                v_strTXTIME = DateTime.Now.ToString("HH:mm:ss") '"00:00:00"
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).InnerXml = v_strTXDATE
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTIME).InnerXml = v_strTXTIME
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeLOCAL).InnerXml = v_strLOCAL
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).InnerXml = v_strOVRRQD

                If v_strOFFID.Length > 0 Then
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFTIME).InnerXml = v_strTXTIME
                End If


                'Kiểm tra các yếu tố rủi ro tại BDS (hạn mức giao dịch)
                v_lngErrCode = VerifyTxRules(v_xmlDocument)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    'Trả ve mã lỗi: Chuyển tiếp xử lý cho Client
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

                'Tạo TXNUM
                v_strTXNUM = v_strBRID & Right(gc_FORMAT_TXNUm & CStr(v_objDataAcess.GetIDValue("TXNUM")), Len(gc_FORMAT_TXNUm))
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).InnerXml = v_strTXNUM

                'Ghi nhận giao dịch tại BDS
                v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Logged

                If String.Compare(v_strLATE, "0") <> 0 Then
                    'Giao dich o che do asynchronous
                    'Log lai giao dich va dua vao Queue request

                    Dim v_strQUEUEID As String = Right(gc_FORMAT_QUEUEID & CStr(v_objDataAcess.GetIDValue("MSGQUEUE")), Len(gc_FORMAT_QUEUEID))
                    v_strSQL = "INSERT INTO MSGQUEUE (QUEUEID, MSGID, ITIME, MSGTYPE, MSGBODY, ERRDESC) " & ControlChars.CrLf _
                        & "VALUES ('" & v_strQUEUEID & "','" & v_strTXDATE & v_strTXNUM & "',SYSDATE,'TX',' ', ' ')"
                    v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                    pv_strTxMsg = v_xmlDocument.InnerXml
                End If

                If Not v_strNOSUBMIT = "2" And String.Compare(v_strLATE, "0") = 0 Then
                    v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)
                    If v_lngErrCode = ERR_SYSTEM_OK Then
                        'Ghi Log
                        If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                            Dim v_strMsgCheck As String
                            v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "I", )
                            'LocalDB TruongLD Add
                            'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                            v_lngErrLog = txTransact(v_strMsgCheck)
                            'End TruongLD
                        End If
                    End If

                End If
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    'Cập nhật trạng thái lỗi của giao dịch
                    v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.ErrorOccured
                    v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                    'Trả v? mã lỗi: Chuyển tiếp xử lý cho Client
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                End If

                'Xử lý giao dịch
                If v_strLOCAL = gc_TLTX_HOST And String.Compare(v_strLATE, "0") = 0 Then
                    If v_strNOSUBMIT = "2" Then
                        'Nếu là giao dịch lần đầu, có 2 lần submit thì chỉ lấy POSTMAP và PRINTINFO
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributePRETRAN).InnerXml = "Y"
                    Else
                        'Giao dịch 01 lần Submit thì xử lý luôn
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributePRETRAN).InnerXml = "N"
                    End If
                    'Dẩy lên HOST để xử lý

                    pv_strTxMsg = v_xmlDocument.InnerXml
                    'LocalDB TruongLD Add
                    'v_lngErrCode = SendMessage2Host(pv_strTxMsg)
                    v_lngErrCode = txTransact(pv_strTxMsg)
                    'End TruongLD

                    'Lấy lại dữ liệu trên HOST trả v?
                    v_xmlDocument.LoadXml(pv_strTxMsg)
                    If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR And v_lngErrCode <> ERR_SA_VSD_STATUS Then
                        'Cập nhật trạng thái lỗi của giao dịch
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.ErrorOccured
                        v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                        'Ghi Log
                        If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                            Dim v_strMsgCheck As String
                            v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )

                            'LocalDB TruongLD Add
                            'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                            v_lngErrLog = txTransact(pv_strTxMsg)
                            'End TruongLD
                        End If

                        'Voi cac giao dich T,D,M thuc hien ghi log len HOST de cho giai phap Direct Recovery
                        'Cac giao dich o trang thai cho duyet hien khong duoc ghi len HOST
                        If v_strNOSUBMIT <> "2" And v_strLog4DR = "Y" And (v_strTXTYPE = "T" Or v_strTXTYPE = "M" Or v_strTXTYPE = "D") And v_strApproveRequire = "Y" Then
                            Dim v_strMsgCheck As String
                            v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransLog4DR")
                            'LocalDB TruongLD Add
                            'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                            v_lngErrLog = txTransact(v_strMsgCheck)
                            'End TruongLD
                        End If

                        'Trả v? mã lỗi: Chuyển tiếp xử lý cho Client
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                        ' Thoai.tran add
                        ' Them ERR_SA_VSD_STATUS
                    ElseIf v_lngErrCode = ERR_SA_CHECKER1_OVR Or v_lngErrCode = ERR_SA_CHECKER2_OVR Or v_lngErrCode = ERR_SA_VSD_STATUS Then
                        'Cập nhật thông tin v? duyệt giao dịch (trư?ng OVRRQS)
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Pending
                        v_objMessageLog.TransUpdateStatus(v_xmlDocument)

                        'Voi cac giao dich T,D,M thuc hien ghi log len HOST de cho giai phap Direct Recovery
                        'Cac giao dich o trang thai cho duyet hien khong duoc ghi len HOST
                        If v_strNOSUBMIT <> "2" And v_strLog4DR = "Y" And (v_strTXTYPE = "T" Or v_strTXTYPE = "M" Or v_strTXTYPE = "D") And v_strApproveRequire = "Y" Then
                            Dim v_strMsgCheck As String
                            v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransLog4DR")
                            'LocalDB TruongLD Add
                            'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                            v_lngErrLog = txTransact(v_strMsgCheck)
                            'End TruongLD
                        End If

                        'Ghi nhận bút toán hạch toán kế toán trả v? nếu có
                        SaveGLTrans(v_xmlDocument)
                        'Xác định nguyên nhân duyệt và thông báo lại cho Client
                        BuildCheckerReason(v_xmlDocument)
                        pv_strTxMsg = v_xmlDocument.InnerXml
                        'Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    Else
                        If v_strNOSUBMIT = "1" Then
                            'Nếu giao dịch có 02 lần Submit thì trả v? lu�ôn không xử lý gì
                            'Nếu giao dịch chỉ có 01 lần Submit thì cập nhật lại trạng thái của giao dịch.
                            'Lúc này tất cả các loại giao dịch đ?u x�ử lý như nhau
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed
                            v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                            'Ghi Log
                            If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                                Dim v_strMsgCheck As String
                                v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                                'LocalDB TruongLD Add
                                'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                                v_lngErrLog = txTransact(v_strMsgCheck)
                                'End TruongLD
                            End If
                        End If
                        'Ghi nhận bút toán kế toán
                        SaveGLTrans(v_xmlDocument)
                        pv_strTxMsg = v_xmlDocument.InnerXml
                    End If
                End If

            Else 'Submit lần thứ hai
                'Lay thong tin giao dich de thuc hien ghi log va TLLOGEXT
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , "upper(TLTXCD) = '" & v_strTLTXCD & "'")
                'TruongLD Add 13/03/2014
                'objTransfer(v_strObjMsg)
                v_objTranfer.Transfer(v_strObjMsg)
                'End TruongLD
                v_xmlObjDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlObjDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "REFOBJ"
                                    v_strREFOBJ = v_strValue
                                Case "REFKEYFLD"
                                    v_strREFKEYFLD = v_strValue
                                Case "OVRRQD"
                                    v_strApproveRequire = v_strValue
                            End Select
                        End With
                    Next
                Next

                If v_strREFOBJ.Length > 0 And v_strREFKEYFLD.Length > 0 Then
                    v_strRefKeyVal = GetKeyFldVal(pv_strTxMsg, v_strREFKEYFLD)
                End If

                v_strLOCAL = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
                If String.Compare(v_strLATE, "0") <> 0 And v_intSTATUS = TransactStatus.Logged Then
                    'Xu ly lan 2 doi voi giao dich LATE=1: Goi lai cac buoc xu ly giao dich tuong tu lan dau
                    v_strTXDATE = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
                    If v_strLOCAL = gc_TLTX_HOST And String.Compare(v_strLATE, "0") <> 0 Then
                        If v_strNOSUBMIT = "2" Then
                            'Nếu là giao dịch lần đầu, có 2 lần submit thì chỉ lấy POSTMAP và PRINTINFO
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributePRETRAN).InnerXml = "Y"
                        Else
                            'Giao dịch 01 lần Submit thì xử lý luôn
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributePRETRAN).InnerXml = "N"
                        End If
                        'Dẩy lên HOST để xử lý

                        pv_strTxMsg = v_xmlDocument.InnerXml
                        'LocalDB TruongLD Add
                        'v_lngErrCode = SendMessage2Host(pv_strTxMsg)
                        v_lngErrCode = txTransact(pv_strTxMsg)
                        'End TruongLD

                        'Lấy lại dữ liệu trên HOST trả v?
                        v_xmlDocument.LoadXml(pv_strTxMsg)
                        If v_lngErrCode <> ERR_SYSTEM_OK And v_lngErrCode <> ERR_SA_CHECKER1_OVR And v_lngErrCode <> ERR_SA_CHECKER2_OVR Then
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.ErrorOccured
                            v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                            'Ghi Log
                            If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                                Dim v_strMsgCheck As String
                                v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                                'LocalDB TruongLD Add
                                'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                                v_lngErrLog = txTransact(v_strMsgCheck)
                                'End TruongLD
                            End If
                            'Cập nhật trạng thái lỗi của giao dịch
                            v_strSQL = "UPDATE MSGQUEUE SET OTIME=SYSDATE, MSGSTS='E', ERRDESC='" & v_DataAccess.GetErrorMessage(v_lngErrCode) & "' " & ControlChars.CrLf _
                                & "WHERE MSGTYPE='TX' AND MSGID='" & v_strTXDATE & v_strTXNUM & "'"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)

                            'Trả v? mã lỗi: Chuyển tiếp xử lý cho Client
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        ElseIf v_lngErrCode = ERR_SA_CHECKER1_OVR Or v_lngErrCode = ERR_SA_CHECKER2_OVR Then
                            'Cập nhật thông tin v? duyệt giao dịch (trư?ng OVRRQS)
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Pending
                            v_objMessageLog.TransUpdateStatus(v_xmlDocument)

                            'Ghi Log
                            If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                                Dim v_strMsgCheck As String
                                v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                                'LocalDB TruongLD Add
                                'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                                v_lngErrLog = txTransact(v_strMsgCheck)
                                'End TruongLD
                            End If
                            'Ghi nhận bút toán hạch toán kế toán trả v? nếu có
                            SaveGLTrans(v_xmlDocument)
                            'Xác định nguyên nhân duyệt và thông báo lại cho Client
                            BuildCheckerReason(v_xmlDocument)

                            'Cập nhật nguyen nhan duyet
                            v_strSQL = "UPDATE MSGQUEUE SET OTIME=SYSDATE, MSGSTS='C', ERRDESC='" & v_DataAccess.GetErrorMessage(v_lngErrCode) & "' " & ControlChars.CrLf _
                                & "WHERE MSGTYPE='TX' AND MSGID='" & v_strTXDATE & v_strTXNUM & "'"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        Else
                            If v_strNOSUBMIT = "1" Then
                                'Nếu giao dịch có 02 lần Submit thì trả v? lu�ôn không xử lý gì
                                'Nếu giao dịch chỉ có 01 lần Submit thì cập nhật lại trạng thái của giao dịch.
                                'Lúc này tất cả các loại giao dịch đ?u x�ử lý như nhau
                                v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed
                                v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                                'Ghi Log
                                If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                                    Dim v_strMsgCheck As String
                                    v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                                    'LocalDB TruongLD Add
                                    'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                                    v_lngErrLog = txTransact(v_strMsgCheck)
                                    'End TruongLD
                                End If
                            End If
                            'Ghi nhận bút toán kế toán
                            SaveGLTrans(v_xmlDocument)
                            'Cap nhat trang thai xu ly
                            v_strSQL = "UPDATE MSGQUEUE SET OTIME=SYSDATE, MSGSTS='C', ERRDESC='DONE' " & ControlChars.CrLf _
                                & "WHERE MSGTYPE='TX' AND MSGID='" & v_strTXDATE & v_strTXNUM & "'"
                            v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    End If
                Else
                    'Xu ly lan 2 doi voi giao dich LATE=0
                    If v_strNOSUBMIT = "2" Then
                        v_lngErrCode = v_objMessageLog.TransLog(v_xmlDocument)

                        'Ghi Log
                        If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                            Dim v_strMsgCheck As String
                            v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                            'LocalDB TruongLD Add
                            'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                            v_lngErrLog = txTransact(v_strMsgCheck)
                            'End TruongLD
                        End If

                        'Voi cac giao dich T,D,M thuc hien ghi log len HOST de cho giai phap Direct Recovery
                        'Cac giao dich o trang thai cho duyet hien khong duoc ghi len HOST
                        If v_strLog4DR = "Y" And (v_strTXTYPE = "T" Or v_strTXTYPE = "M" Or v_strTXTYPE = "D") And v_strApproveRequire = "Y" Then
                            Dim v_strMsgCheck As String
                            v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransLog4DR")
                            'LocalDB TruongLD Add
                            'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                            v_lngErrLog = txTransact(v_strMsgCheck)
                            'End TruongLD
                        End If

                    End If
                End If


                If v_strLOCAL = gc_TLTX_HOST And v_strNOSUBMIT = "2" Then
                    'Kiểm tra giao dịch đã đủ đi?u ki�ện mới đẩy tiếp lên HOST. 
                    'Giao dịch I, M, T chỉ đẩy tiếp lên HOST nếu STATUS = Logged và đã được duyệt
                    'Giao dịch D chỉ đẩy tiếp lên HOST nếu STATUS = Cashier và đã được duyệt
                    'Giao dịch D sẽ cập nhật trạng thái ở BDS nếu STATUS = Logged và đã được duyệt
                    'Giao dịch W chỉ đẩy tiếp lên HOST nếu STATUS = New or STATUS = Cashier đã được duỵệt

                    'Giao dịch không có yêu cầu duyệt
                    If Len(v_strOVRRQD) = 0 Then v_blnApproval = True
                    'Giao dịch yêu cầu checker 2 duyệt
                    If InStr(v_strOVRRQD, gc_OFFID_OVRRQS) > 0 And Len(v_strOFFID) > 0 Then v_blnApproval = True
                    'Giao dịch yêu cầu checker 1 duyệt
                    If Len(Replace(v_strOVRRQD, gc_OFFID_OVRRQS, vbNullString)) > 0 And Len(v_strCHKID) > 0 Then v_blnApproval = True

                    If (v_strTXTYPE = "I" And v_intSTATUS = TransactStatus.Logged And v_blnApproval) _
                        Or (v_strTXTYPE = "M" And v_intSTATUS = TransactStatus.Logged And v_blnApproval) _
                        Or (v_strTXTYPE = "T" And v_intSTATUS = TransactStatus.Logged And v_blnApproval) _
                        Or (v_strTXTYPE = "D" And v_intSTATUS = TransactStatus.Cashier And v_blnApproval) _
                        Or (v_strTXTYPE = "W" Or v_strTXTYPE = "R" Or v_strTXTYPE = "O" Or v_strTXTYPE = "A") Then

                        v_xmlDocument.DocumentElement.Attributes(gc_AtributePRETRAN).InnerXml = "N"
                        pv_strTxMsg = v_xmlDocument.InnerXml

                        'LocalDB TruongLD Add
                        'v_lngErrCode = SendMessage2Host(pv_strTxMsg)
                        v_lngErrCode = txTransact(pv_strTxMsg)
                        'End TruongLD
                        v_xmlDocument.LoadXml(pv_strTxMsg)
                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            'Cập nhật trạng thái lỗi của giao dịch
                            v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.ErrorOccured
                            v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                            'Ghi Log
                            If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                                Dim v_strMsgCheck As String
                                v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )

                                'LocalDB TruongLD Add
                                'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                                v_lngErrCode = txTransact(v_strMsgCheck)
                                'End TruongLD
                            End If
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        Else
                            'Cập nhật lại trạng thái của giao dịch
                            v_xmlDocument.LoadXml(pv_strTxMsg)
                            v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                            'Ghi Log
                            If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                                Dim v_strMsgCheck As String
                                v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                                'LocalDB TruongLD Add
                                'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                                v_lngErrCode = txTransact(v_strMsgCheck)
                                'End TruongLD
                            End If
                        End If
                    ElseIf (v_strTXTYPE = "D" And v_intSTATUS = TransactStatus.Logged And v_blnApproval) Then
                        v_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Cashier
                        v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                        'Ghi Log
                        If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                            Dim v_strMsgCheck As String
                            v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                            'LocalDB TruongLD Add
                            'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                            v_lngErrCode = txTransact(v_strMsgCheck)
                            'End TruongLD
                        End If
                    End If
                    'Trả v? message
                    pv_strTxMsg = v_xmlDocument.InnerXml
                End If
            End If

            'Complete transaction
            Complete() 'ContextUtil.SetComplete()

            Return v_lngErrCode
        Catch ex As Exception
            'Abort transaction
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            BuildXMLErrorException(v_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            Throw ex
        End Try
    End Function

    Public Function VerifyTxRules(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.VerifyTxRules", v_strErrorMessage As String
        Dim v_strCheckerApproveRequest As String = String.Empty
        Dim v_ds As DataSet, v_db As New DataAccess
        Dim v_objEval As New Evaluator
        Try
            Dim v_nodeList As Xml.XmlNodeList
            'Lấy mã giao dịch
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).InnerXml
            Dim v_strTLID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLID).InnerXml
            Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).InnerXml
            Dim v_strCCYUSAGE As String = BASED_CCYCD
            Dim v_strBRID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBRID).InnerXml
            Dim v_strBUSDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).InnerXml
            Dim v_strTxDate As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).InnerXml
            Dim v_strTXTYPE As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTYPE).Value.ToString)
            'Check date
            Dim v_strSQLDATE, v_strDate As String
            v_strSQLDATE = "SELECT VARVALUE TXDATE FROM SYSVAR WHERE VARNAME = 'CURRDATE' AND GRNAME = 'SYSTEM'"
            'Dim v_objDate As New DataAccess
            Dim v_dsDate As DataSet
            v_dsDate = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLDATE)
            If v_dsDate.Tables(0).Rows.Count > 0 Then
                v_strDate = CStr(IIf(v_dsDate.Tables(0).Rows(0)("TXDATE") Is DBNull.Value, "", v_dsDate.Tables(0).Rows(0)("TXDATE"))).Trim
            End If
            'And v_strTLTXCD <> gc_GL_NORMAL
            If v_strTxDate <> String.Empty Then
                If Trim(CStr(v_strTxDate)) <> Trim(v_strDate) Then
                    Return ERR_SA_BUSDATE_DIF_TXDATE
                End If
            End If


            'pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).InnerXml = ""
            'Dim v_objDATX As New DataAccess
            Dim v_dsDATX As DataSet, v_nodetxData As Xml.XmlNode
            Dim v_strSQLDATX, v_strACCTFLDCD, v_strACCTNO, v_strIBT As String
            'Xác định giao dịch có phải là IBT không
            'Căn cứ vào MSGACCT & BRID để kiểm tra có phải giao dịch IBT không
            v_strSQLDATX = "SELECT MSG_ACCT ACCTFLDCD, IBT FROM TLTX WHERE TLTXCD = '" & v_strTLTXCD & "'"
            v_dsDATX = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQLDATX)
            If v_dsDATX.Tables(0).Rows.Count > 0 Then
                v_strACCTFLDCD = CStr(IIf(v_dsDATX.Tables(0).Rows(0)("ACCTFLDCD") Is DBNull.Value, "", v_dsDATX.Tables(0).Rows(0)("ACCTFLDCD"))).Trim
                v_strIBT = CStr(IIf(v_dsDATX.Tables(0).Rows(0)("IBT") Is DBNull.Value, "N", v_dsDATX.Tables(0).Rows(0)("IBT"))).Trim
                v_nodetxData = pv_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='" & v_strACCTFLDCD & "']")
                If v_nodetxData IsNot Nothing Then
                    v_strACCTNO = v_nodetxData.InnerText.Trim
                End If

            End If


            'Làm tròn cho các trư?ng s�ố để đảm bảo hiển thị 
            'Làm tròn ngay khi ghi nhận vào TLLOGFLD theo tam số qui định trong FLDMASTER 
            Dim v_strSQL, v_strFLDRND, v_strDATATYPE, v_strFLDNAME, v_strValue As String, v_intNode, v_intItem As Integer
            v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields")
            If v_nodeList.Count > 0 Then
                For v_intNode = 0 To v_nodeList.Count - 1
                    For v_intItem = 0 To v_nodeList.Item(v_intNode).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intNode).ChildNodes.Item(v_intItem)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strValue = .InnerText.ToString
                            'Lấy qui định làm tròn
                            v_strSQL = "SELECT FLDRND FROM FLDMASTER WHERE DATATYPE='N' AND OBJNAME='" & v_strTLTXCD & "' AND FLDNAME='" & v_strFLDNAME.Trim & "'"
                            v_ds = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_ds.Tables(0).Rows.Count > 0 Then
                                v_strFLDRND = IIf(IsDBNull(v_ds.Tables(0).Rows(0)("FLDRND")), vbNullString, v_ds.Tables(0).Rows(0)("FLDRND"))
                                .InnerText = gf_RoundNumber(v_strValue, v_strFLDRND)
                            End If
                        End With
                    Next
                Next
            End If

            'Nếu là Admin thì không cần kiểm tra.
            If v_strTLID <> ADMIN_ID Then
                'Check right of transaction
                v_lngErrCode = CheckTransAllow(pv_xmlDocument)

                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Return v_lngErrCode
                End If

                'Get MSG_AMT of transaction
                v_strSQL = "SELECT MSG_AMT FROM TLTX WHERE TLTXCD = '" & v_strTLTXCD & "'"
                Dim v_dsAmt As DataSet
                v_dsAmt = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strMSG_AMT As String
                If v_dsAmt.Tables(0).Rows.Count > 0 Then
                    v_strMSG_AMT = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("MSG_AMT") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("MSG_AMT"))).Trim
                End If

                'Get LIMIT of user
                Dim v_strTltxSQL As String
                v_strTltxSQL = "SELECT A.TLLIMIT TLLIMIT " _
                                & "FROM TLTX M, TLAUTH A " _
                                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strTLID & "' AND A.TLTYPE = 'T' AND A.AUTHTYPE = 'U' AND A.CODEID = '" & v_strCCYUSAGE & "'"
                Dim v_dsTltx As DataSet
                Dim v_strUsrLIMIT As String
                v_dsTltx = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strTltxSQL)
                If v_dsTltx.Tables(0).Rows.Count > 0 Then
                    v_strUsrLIMIT = CStr(IIf(v_dsTltx.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsTltx.Tables(0).Rows(0)("TLLIMIT"))).Trim
                End If

                'Get the groups that user is in
                Dim v_strGrpSQL As String
                'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTLID & "' AND A.ACTIVE = 'Y'"
                v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTLID & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
                Dim v_dsGrp As DataSet
                v_dsGrp = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
                Dim v_dblGrpLIMIT As Double = 0
                Dim v_intNumGrp As Integer
                If v_dsGrp.Tables(0).Rows.Count > 0 Then
                    v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                    Dim v_strGrpId As String
                    'Get Largest Limit of groups
                    For i As Integer = 0 To v_intNumGrp - 1
                        v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                        'Get Limit of each group.
                        v_strSQL = "SELECT A.TLLIMIT TLLIMIT " _
                                & "FROM TLTX M, TLAUTH A " _
                                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strGrpId & "' AND A.TLTYPE = 'T' AND A.AUTHTYPE = 'G' AND A.CODEID = '" & v_strCCYUSAGE & "'"

                        Dim v_dsGrpRight As DataSet
                        v_dsGrpRight = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        'Get Limit of group
                        Dim v_strLIMIT As String
                        If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                            v_strLIMIT = CStr(IIf(v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT"))).Trim
                            If (v_strLIMIT <> String.Empty) And (IsNumeric(v_strLIMIT)) Then
                                If CDbl(v_strLIMIT) > v_dblGrpLIMIT Then
                                    v_dblGrpLIMIT = CDbl(v_strLIMIT)
                                End If
                            End If
                        End If
                    Next
                End If

                'Get value of transaction
                Dim v_strTransLimit As String
                v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/fields")
                If v_nodeList.Count > 0 Then
                    If InStr("8874/8875/8876/8877", Trim(v_strTLTXCD)) > 0 Then
                        Dim v_strPrice, v_strQuantity, v_strRatio, v_strTradeUnit, v_strHundred As String
                        For i As Integer = 0 To v_nodeList.Count - 1
                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                With v_nodeList.Item(i).ChildNodes.Item(j)
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strValue = .InnerText.ToString
                                    Select Case Trim(v_strFLDNAME)
                                        Case "11" 'Price
                                            v_strPrice = Trim(v_strValue)
                                        Case "12" 'Quantity
                                            v_strQuantity = Trim(v_strValue)
                                        Case "13" 'Ratio
                                            v_strRatio = Trim(v_strValue)
                                        Case "98" 'Trade unit
                                            v_strTradeUnit = Trim(v_strValue)
                                        Case "99" 'Hundred
                                            v_strHundred = Trim(v_strValue)
                                    End Select
                                End With
                            Next
                        Next
                        If IsNumeric(v_strPrice) And IsNumeric(v_strQuantity) And IsNumeric(v_strRatio) And IsNumeric(v_strTradeUnit) Then
                            v_strTransLimit = CStr(CDbl(v_strPrice) * CDbl(v_strQuantity) * CDbl(v_strRatio) * CDbl(v_strTradeUnit) / CDbl("100"))
                        End If
                    Else
                        'For i As Integer = 0 To v_nodeList.Count - 1
                        '    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        '        With v_nodeList.Item(i).ChildNodes.Item(j)
                        '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        '            v_strValue = .InnerText.ToString
                        '            'Xác định trư?ng s�ố của giao dịch
                        '            Select Case Trim(v_strFLDNAME)
                        '                Case v_strMSG_AMT
                        '                    v_strTransLimit = Trim(v_strValue)
                        '                    Exit For
                        '            End Select
                        '        End With
                        '    Next
                        'Next
                        'GianhVG sua lai phan lay Messagme Amount trong tllog
                        If Trim(v_strMSG_AMT).Length >= 2 Then
                            If v_strTLTXCD = gc_GL_NORMAL Then
                                v_strTransLimit = 0
                            Else
                                v_strMSG_AMT = BuildAMTEXP(pv_xmlDocument, v_strMSG_AMT)
                                v_strTransLimit = CDbl(v_objEval.Eval(v_strMSG_AMT).ToString)
                                'Mặc định làm tròn đến hàng đơn vị
                                v_strTransLimit = gf_RoundNumber(v_strTransLimit, "0")
                            End If
                        End If
                    End If
                End If

                If (v_strTransLimit <> String.Empty) And (IsNumeric(v_strTransLimit)) Then
                    If (v_strUsrLIMIT <> String.Empty) And (IsNumeric(v_strUsrLIMIT)) Then
                        If CDbl(v_strUsrLIMIT) = 0 Then
                            If (v_dblGrpLIMIT > 0) Then
                                'If this user hasn't got his own right with this transaction
                                If CDbl(v_strTransLimit) > v_dblGrpLIMIT Then
                                    v_strCheckerApproveRequest = OVRRQS_TRANSACTIONLIMIT
                                End If
                            ElseIf (v_dblGrpLIMIT = 0) Then
                                Return ERR_SA_TRANSACT_TELLERLIMIT_NOTDEFINED
                            End If
                        Else
                            If CDbl(v_strTransLimit) > CDbl(v_strUsrLIMIT) Then
                                v_strCheckerApproveRequest = OVRRQS_TRANSACTIONLIMIT
                            End If
                        End If
                    ElseIf (v_dblGrpLIMIT > 0) Then
                        'If this user hasn't got his own right with this transaction
                        If CDbl(v_strTransLimit) > v_dblGrpLIMIT Then
                            v_strCheckerApproveRequest = OVRRQS_TRANSACTIONLIMIT
                        End If
                    ElseIf (v_dblGrpLIMIT = 0) Then
                        Return ERR_SA_TRANSACT_TELLERLIMIT_NOTDEFINED
                    End If
                Else
                    'Return ERR_SA_TRANSACT_MAKE_ERR
                End If
            End If

            If pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).InnerXml = "Y" Then
                'Cần checker 2 duyệt: Control check
                pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).InnerXml = OVRRQS_CHECKER_CONTROL & v_strCheckerApproveRequest
            Else
                pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).InnerXml = v_strCheckerApproveRequest
            End If


            'Xác định giao dịch có phải là IBT không

            'Xác định có phải giao dịch bị xoá không

            'Complete transaction
            Complete() 'ContextUtil.SetComplete()

            Return v_lngErrCode
        Catch ex As Exception
            'Abort transaction
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            Throw ex
        Finally
            v_db = Nothing
        End Try
    End Function

    Public Function SaveGLTrans(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.SaveGLTrans", v_strErrorMessage As String

        Try
            'Kiểm tra có bộ định khoản kế toán không
            Dim v_nodeData As Xml.XmlNode
            v_nodeData = pv_xmlDocument.SelectSingleNode("/TransactMessage/postmap")

            If Not v_nodeData Is Nothing Then
                Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
                Dim v_nodeList As Xml.XmlNodeList, v_strOldSUBTXNO As String, v_strOldCCYCD As String, v_dblDrAmt As Double, v_dblCrAmt As Double
                Dim v_strSUBTXNO, v_strDORC, v_strCCYCD, v_strACCTNO As String, v_dblAMT As Double, i, v_intCount As Integer
                Dim v_strTXDATE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString
                Dim v_strTXNUM As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXNUM).Value.ToString
                Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
                Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)

                'Ghi nhận bộ định khoản kế toán
                v_nodeList = pv_xmlDocument.SelectNodes("/TransactMessage/postmap/entry")
                If v_nodeList.Count > 0 Then
                    For i = 0 To v_nodeList.Count - 1 Step 1
                        'Lấy tham số hạch toán
                        With v_nodeList.Item(i)
                            v_strSUBTXNO = CStr(CType(.Attributes.GetNamedItem("subtxno"), Xml.XmlAttribute).Value)
                            v_strDORC = CStr(CType(.Attributes.GetNamedItem("dorc"), Xml.XmlAttribute).Value)
                            v_strCCYCD = CStr(CType(.Attributes.GetNamedItem("ccycd"), Xml.XmlAttribute).Value)
                            v_strACCTNO = CStr(CType(.Attributes.GetNamedItem("acctno"), Xml.XmlAttribute).Value)
                            v_dblAMT = CDbl(.InnerXml)
                        End With
                        If v_blnReversal Then 'Nếu là xoá giao dịch
                            'Xoá GLTRAN
                            v_strSQL = "UPDATE GLTRAN SET DELTD='Y' WHERE TXNUM='" & v_strTXNUM & "' AND " _
                                & " TXDATE=TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "')"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        Else 'Nếu là giao dịch bình thư?ng
                            'T�ạo GLTRAN
                            v_strSQL = "INSERT INTO GLTRAN (ACCTNO, TXDATE, TXNUM, BKDATE, CCYCD, DORC, SUBTXNO, AMT, DELTD) " _
                                & "VALUES ('" & v_strACCTNO & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                                & v_strTXNUM & "',TO_DATE('" & v_strTXDATE & "', '" & gc_FORMAT_DATE & "'),'" _
                                & v_strCCYCD & "','" & v_strDORC & "','" & v_strSUBTXNO & "'," & v_dblAMT & ",'N')"
                            v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        End If
                    Next
                End If
            End If

            'Complete transaction
            Complete() 'ContextUtil.SetComplete()

            Return v_lngErrCode
        Catch ex As Exception
            'Abort transaction
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            Throw ex
        End Try
    End Function

    Public Function BuildCheckerReason(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.BuildCheckerReason", v_strErrorMessage As String

        Try
            'Kiểm tra đã có nguyên nhân duyệt chưa
            Dim v_nodeData As Xml.XmlNode
            v_nodeData = pv_xmlDocument.SelectSingleNode("/TransactMessage/checker")

            If v_nodeData Is Nothing Then
                Dim v_checkerElement As Xml.XmlElement, v_entryNode As Xml.XmlNode, v_strCDVAL, v_strCDCONTENT As String
                Dim i As Integer, v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
                Dim v_strOVRRQD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString

                'Xác định các nguyên nhân cần duyệt
                v_strSQL = "SELECT CDVAL, CDCONTENT, LSTODR FROM ALLCODE WHERE CDTYPE='SY' AND CDNAME='OVRRQS' AND INSTR('" _
                    & v_strOVRRQD & "',CDVAL)>0 ORDER BY LSTODR"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_checkerElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "checker", "")

                    For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        v_strCDVAL = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CDVAL")))
                        v_strCDCONTENT = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(i)("CDCONTENT")))
                        'Create appmap entry
                        v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                        Dim v_attrCDVAL As Xml.XmlAttribute = pv_xmlDocument.CreateAttribute("cdval")
                        v_attrCDVAL.Value = v_strCDVAL
                        v_entryNode.Attributes.Append(v_attrCDVAL)
                        v_entryNode.InnerText = v_strCDCONTENT
                        v_checkerElement.AppendChild(v_entryNode)
                    Next
                    pv_xmlDocument.DocumentElement.AppendChild(v_checkerElement)
                End If
            End If

            'Complete transaction
            Complete() 'ContextUtil.SetComplete()

            Return v_lngErrCode
        Catch ex As Exception
            'Abort transaction
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            BuildXMLErrorException(pv_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            Throw ex
        End Try
    End Function

    Public Function GetMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.GetMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            'Trả v? k�ết quả
            pv_strObjMsg = v_xmlDocument.InnerXml
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            BuildXMLErrorException(v_xmlDocument, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
            Throw ex
        End Try
    End Function

    Public Function CashMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.CashMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)

            'Lấy mã TellerID nhân viên quỹ để kiểm tra có phải là nhân viên quỹ thực sự không
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strTlType As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Lấy thông tin chi tiết v? giao d�ịch
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            v_attrColl = v_xmlDocument.DocumentElement.Attributes
            CType(v_attrColl.GetNamedItem(gc_AtributeCHID), Xml.XmlAttribute).Value = v_strCHID
            CType(v_attrColl.GetNamedItem(gc_AtributePRETRAN), Xml.XmlAttribute).Value = "N"
            Dim v_strCHKID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            Dim v_strOFFID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            Dim v_strOVRRQS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            Dim v_strTXTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXTYPE), Xml.XmlAttribute).Value)
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_intSTATUS As String = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            Dim v_strCCYUSAGE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCCYUSAGE), Xml.XmlAttribute).Value)
            v_strCCYUSAGE = "00"
            'Kiểm tra chỉ cho phép duyệt nếu trạng thái là Pending và không bị xoá
            Dim v_strSQL As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess

            Dim v_strTXNUM As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Dim v_strTXDATE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)

            'Kiem tra xem chi nhanh co hoat dong hay khong 
            Dim v_strBranchStatus As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "HOSTATUS", v_strBranchStatus)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strBranchStatus = OPERATION_INACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            v_strSQL = "SELECT * FROM TLLOG WHERE DELTD='N' AND TXSTATUS='" & TransactStatus.Cashier & "' AND TXNUM='" & v_strTXNUM _
                & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Trạng thái không hợp lệ
                v_lngErrCode = ERR_SA_TLLOG_INVALID_STATUS
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Kiểm tra TLID có được phép duyệt giao dịch không. Nếu không báo lỗi
            'Nếu là Admin thì không cần kiểm tra.
            If v_strCHID <> ADMIN_ID Then
                Dim v_intNumGrp As Integer
                'Check right of current user
                Dim v_strCashier As String
                If v_strTlType <> String.Empty Then
                    v_strCashier = Mid(v_strTlType, 2, 1)
                End If

                'If current user is not a cashier
                If v_strCashier <> "Y" Then
                    Return ERR_SA_CRTUSR_NOTCASHIER
                End If

                v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='U' " &
                                "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strCHID & "'"
                Dim v_strCMDALLOW As String
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Lấy quy?n �được gán
                    v_strCMDALLOW = CStr(v_ds.Tables(0).Rows(0)("CMDALLOW")).Trim
                    If v_strCMDALLOW <> "Y" Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                Else
                    'Check right of groups
                    v_strSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHID & "' AND A.ACTIVE = 'Y'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    Dim v_blnAllow As Boolean = False
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_intNumGrp = v_ds.Tables(0).Rows.Count
                        Dim v_strGrpId, v_strGrpAllow As String
                        'Get name of groups
                        For i As Integer = 0 To v_intNumGrp - 1
                            v_strGrpId = CStr(v_ds.Tables(0).Rows(i)("GRPID")).Trim
                            'Get access right of each group and add rights to hash table
                            v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='G' " &
                                       "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strGrpId & "'"

                            Dim v_dsGrpRight As DataSet
                            Dim v_objGrpRight As New DataAccess
                            v_dsGrpRight = v_objGrpRight.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsGrpRight.Tables(0).Rows.Count = 1 Then
                                v_strGrpAllow = IIf(v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW"))
                            End If
                            If Trim(v_strGrpAllow) = "Y" Then
                                v_blnAllow = True
                                Exit For
                            End If
                        Next
                    End If
                    If v_blnAllow = False Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                End If

                'Get MSG_AMT of transaction
                v_strSQL = "SELECT MSG_AMT FROM TLTX WHERE TLTXCD = '" & v_strTLTXCD & "'"
                Dim v_dsAmt As DataSet
                v_dsAmt = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strMSG_AMT As String
                If v_dsAmt.Tables(0).Rows.Count > 0 Then
                    v_strMSG_AMT = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("MSG_AMT") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("MSG_AMT"))).Trim
                End If

                'Get LIMIT of user
                Dim v_strTltxSQL As String
                v_strTltxSQL = "SELECT A.TLLIMIT TLLIMIT " _
                                & "FROM TLTX M, TLAUTH A " _
                                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strCHID & "' AND A.TLTYPE = 'C' AND A.AUTHTYPE = 'U' AND A.CODEID = '" & v_strCCYUSAGE & "'"
                Dim v_dsTltx As DataSet
                Dim v_strUsrLIMIT As String
                v_dsTltx = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strTltxSQL)
                If v_dsTltx.Tables(0).Rows.Count > 0 Then
                    v_strUsrLIMIT = CStr(IIf(v_dsTltx.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsTltx.Tables(0).Rows(0)("TLLIMIT"))).Trim
                End If

                'Get the groups that user is in
                Dim v_strGrpSQL As String
                v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHID & "' AND A.ACTIVE = 'Y'"
                Dim v_dsGrp As DataSet
                v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
                Dim v_dblGrpLIMIT As Double = 0

                If v_dsGrp.Tables(0).Rows.Count > 0 Then
                    v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                    Dim v_strGrpId As String
                    'Get Largest Limit of groups
                    For i As Integer = 0 To v_intNumGrp - 1
                        v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                        'Get Limit of each group.
                        v_strSQL = "SELECT A.TLLIMIT TLLIMIT " _
                                & "FROM TLTX M, TLAUTH A " _
                                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strGrpId & "' AND A.TLTYPE = 'C' AND A.AUTHTYPE = 'G' AND A.CODEID = '" & v_strCCYUSAGE & "'"

                        Dim v_dsGrpRight As DataSet
                        v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        'Get Limit of group
                        Dim v_strLIMIT As String
                        If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                            v_strLIMIT = CStr(IIf(v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT"))).Trim
                            If (v_strLIMIT <> String.Empty) And (IsNumeric(v_strLIMIT)) Then
                                If CDbl(v_strLIMIT) > v_dblGrpLIMIT Then
                                    v_dblGrpLIMIT = CDbl(v_strLIMIT)
                                End If
                            End If
                        End If
                    Next
                End If

                'Get value of transaction
                Dim v_nodeList As Xml.XmlNodeList
                v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/fields")
                Dim v_strFLDNAME, v_strValue, v_strTransLimit As String
                If v_nodeList.Count > 0 Then
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes.Item(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                                Select Case Trim(v_strFLDNAME)
                                    Case v_strMSG_AMT
                                        v_strTransLimit = Trim(v_strValue)
                                        Exit For
                                End Select
                            End With
                        Next
                    Next
                End If

                'Compare value of transaction with limit
                If (v_strTransLimit <> String.Empty) And (IsNumeric(v_strTransLimit)) Then
                    If (v_strUsrLIMIT <> String.Empty) And (IsNumeric(v_strUsrLIMIT)) Then
                        If CDbl(v_strTransLimit) > CDbl(v_strUsrLIMIT) Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CASHOVRLIMIT
                        End If
                    ElseIf v_dblGrpLIMIT > 0 Then
                        'If this user hasn't got his own right with this transaction
                        If CDbl(v_strTransLimit) > v_dblGrpLIMIT Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CASHOVRLIMIT
                        End If
                    ElseIf (CDbl(v_strUsrLIMIT) = 0) And (v_dblGrpLIMIT = 0) Then
                        Return ERR_SA_TRANSACT_CASHIERLIMIT_NOTDEFINED
                    End If
                Else

                End If

            End If

            'Kh�ông cho phép thực hiện giao dịch W, D nếu chưa thực hiện duyệt
            If ((v_strTXTYPE = "W" Or v_strTXTYPE = "D") _
                And ((Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0))) Then
                v_lngErrCode = ERR_SA_SHOULDAPPROVE_BEFORECASHIER
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Kiểm tra các đi?u ki�ện duyệt trước khi đẩy lên HOST
            If Not ((Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0)) Then
                'Ghi nhận vào bảng kê quỹ

                '?�ẩy tiếp giao dịch lên HOST 
                'Dim v_ws As New HOSTDelivery.HOSTDelivery
                'v_ws.Url = GetHostDeliveryUrl()
                'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT

                'Không cần đổi trạng thái giao dịch vì trạng thái sẽ được đổi từ Cashier sang Completed
                pv_strObjMsg = v_xmlDocument.InnerXml
                'v_lngErrCode = v_ws.Message(pv_strObjMsg)
                'v_lngErrCode = SendMessage2Host(pv_strObjMsg)
                v_lngErrCode = txTransact(pv_strObjMsg)
                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                    Rollback() 'ContextUtil.SetAbort()
                    Return v_lngErrCode
                Else
                    v_xmlDocument.LoadXml(pv_strObjMsg)
                End If

                'Trả v? k�ết quả
                'v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                pv_strObjMsg = v_xmlDocument.InnerXml
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ApproveMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_lngErrLog As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.ApproveMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)

            'Lấy mã TellerID nhân viên quỹ để kiểm tra checker có quy?n duy�ệt không
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHECKERID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strTlType As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Lấy thông tin chi tiết v? giao d�ịch
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            v_attrColl = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHKID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            Dim v_strOFFID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            Dim v_strOVRRQS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            Dim v_strTXTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXTYPE), Xml.XmlAttribute).Value)
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_strDELTD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            Dim v_intSTATUS As String = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            Dim v_strCCYUSAGE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCCYUSAGE), Xml.XmlAttribute).Value)
            v_strCCYUSAGE = "00"
            'Kiểm tra chỉ cho phép duyệt nếu trạng thái là Pending và không bị xoá
            Dim v_strSQL As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            Dim v_strFLDNAME, v_strValue, v_strTransLimit As String
            Dim v_strRefKeyVal As String = String.Empty

            Dim v_strTXNUM As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Dim v_strTXDATE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Dim v_dblMsgAMT As Double = 0
            'Kiem tra xem chi nhanh co hoat dong hay khong 
            Dim v_strBranchStatus As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "HOSTATUS", v_strBranchStatus)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strBranchStatus = OPERATION_INACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            v_strSQL = "SELECT * FROM TLLOG WHERE DELTD='N' AND TXSTATUS='" & TransactStatus.Pending & "' AND TXNUM='" & v_strTXNUM _
                & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            v_strTransLimit = "0"
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Trạng thái không hợp lệ
                v_lngErrCode = ERR_SA_TLLOG_INVALID_STATUS
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                v_strTransLimit = IIf(v_ds.Tables(0).Rows(0)("MSGAMT") Is DBNull.Value, "", v_ds.Tables(0).Rows(0)("MSGAMT"))
                If IsNumeric(v_strTransLimit) Then
                    v_dblMsgAMT = CDbl(v_strTransLimit)
                Else
                    v_dblMsgAMT = 0
                End If
            End If

            If v_strDELTD = MSGTRANS_DELETED Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Get thong tin giao giao dich
            v_strSQL = "SELECT MSG_AMT,REFOBJ, REFKEYFLD FROM TLTX WHERE TLTXCD = '" & v_strTLTXCD & "'"
            Dim v_dsAmt As DataSet
            v_dsAmt = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strMSG_AMT, v_strREFOBJ, v_strREFKEYFLD As String
            If v_dsAmt.Tables(0).Rows.Count > 0 Then
                v_strMSG_AMT = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("MSG_AMT") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("MSG_AMT"))).Trim
                v_strREFOBJ = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("REFOBJ") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("REFOBJ"))).Trim
                v_strREFKEYFLD = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("REFKEYFLD") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("REFKEYFLD"))).Trim
            End If

            If v_strREFOBJ.Length > 0 And v_strREFKEYFLD.Length > 0 Then
                v_strRefKeyVal = GetKeyFldVal(v_xmlDocument.InnerXml, v_strREFKEYFLD)
            End If


            'Xác định quy?n h�ạn của NSD hiện tại
            Dim v_strOfficer, v_strChecker As String
            If v_strTlType <> String.Empty Then
                v_strOfficer = Mid(v_strTlType, 3, 1)
                v_strChecker = Mid(v_strTlType, 4, 1)
            End If

            'Xác định checker 1 duyệt hay checker 2 duyệt. Nếu phải duyệt ưu tiên checker 1 duyệt trước
            If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(Trim(v_strCHKID)) = 0) Then
                'Nếu là checker 1 (checker) duyệt
                ''=======================================================================
                'Kiểm tra NDS hiện tại có được phép duyệt rủi ro với giao dịch không. Nếu không báo lỗi
                'Nếu là Admin thì không cần kiểm tra.
                If v_strCHECKERID <> ADMIN_ID Then
                    Dim v_intNumGrp As Integer
                    'If current user is not a checker
                    If v_strChecker <> "Y" Then
                        Return ERR_SA_CRTUSR_NOTCHECKER
                    End If

                    v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='U' " &
                                                    "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strCHECKERID & "'"
                    Dim v_strUsrCMDALLOW As String
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        'Lấy quy?n �được gán
                        v_strUsrCMDALLOW = CStr(v_ds.Tables(0).Rows(0)("CMDALLOW")).Trim
                        If v_strUsrCMDALLOW <> "Y" Then
                            'Chưa được phân quy?n
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CMDALLOW
                        End If
                    Else
                        'Check right of groups
                        v_strSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHECKERID & "' AND A.ACTIVE = 'Y'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        Dim v_blnAllow As Boolean = False
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            v_intNumGrp = v_ds.Tables(0).Rows.Count
                            Dim v_strGrpId, v_strGrpAllow As String
                            'Get name of groups
                            For i As Integer = 0 To v_intNumGrp - 1
                                v_strGrpId = CStr(v_ds.Tables(0).Rows(i)("GRPID")).Trim
                                'Get access right of each group and add rights to hash table
                                v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='G' " &
                                           "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strGrpId & "'"

                                Dim v_dsGrpRight As DataSet
                                Dim v_objGrpRight As New DataAccess
                                v_dsGrpRight = v_objGrpRight.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsGrpRight.Tables(0).Rows.Count = 1 Then
                                    v_strGrpAllow = IIf(v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW"))
                                End If
                                If Trim(v_strGrpAllow) = "Y" Then
                                    v_blnAllow = True
                                    Exit For
                                End If
                            Next
                        End If
                        If v_blnAllow = False Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CMDALLOW
                        End If
                    End If

                    'Get LIMIT of user
                    Dim v_strTltxSQL As String
                    v_strTltxSQL = "SELECT A.TLLIMIT TLLIMIT " _
                                    & "FROM TLTX M, TLAUTH A " _
                                    & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strCHECKERID & "' AND A.TLTYPE = 'R' AND A.AUTHTYPE = 'U' AND A.CODEID = '" & v_strCCYUSAGE & "'"
                    Dim v_dsTltx As DataSet
                    Dim v_strUsrLIMIT As String
                    v_dsTltx = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strTltxSQL)
                    If v_dsTltx.Tables(0).Rows.Count > 0 Then
                        v_strUsrLIMIT = CStr(IIf(v_dsTltx.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsTltx.Tables(0).Rows(0)("TLLIMIT"))).Trim
                    End If

                    'Get the groups that user is in
                    Dim v_strGrpSQL As String
                    v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHECKERID & "' AND A.ACTIVE = 'Y'"
                    Dim v_dsGrp As DataSet
                    v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
                    Dim v_dblGrpLIMIT As Double = 0
                    If v_dsGrp.Tables(0).Rows.Count > 0 Then
                        v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                        Dim v_strGrpId As String
                        'Get Largest Limit of groups
                        For i As Integer = 0 To v_intNumGrp - 1
                            v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                            'Get Limit of each group.
                            v_strSQL = "SELECT A.TLLIMIT TLLIMIT " _
                                    & "FROM TLTX M, TLAUTH A " _
                                    & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strGrpId & "' AND A.TLTYPE = 'R' AND A.AUTHTYPE = 'G' AND A.CODEID = '" & v_strCCYUSAGE & "'"

                            Dim v_dsGrpRight As DataSet
                            v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            'Get Limit of group
                            Dim v_strLIMIT As String
                            If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                                v_strLIMIT = CStr(IIf(v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT"))).Trim
                                If (v_strLIMIT <> String.Empty) And (IsNumeric(v_strLIMIT)) Then
                                    If CDbl(v_strLIMIT) > v_dblGrpLIMIT Then
                                        v_dblGrpLIMIT = CDbl(v_strLIMIT)
                                    End If
                                End If
                            End If
                        Next
                    End If

                    'Compare value of transaction with limit
                    If (v_strTransLimit <> String.Empty) And (IsNumeric(v_strTransLimit)) Then
                        If IsNumeric(v_strUsrLIMIT) Then
                            'Kiem tra quyen USER: v_strUsrLIMIT=0 tuc la khong co quyen
                            If CDbl(v_strTransLimit) > CDbl(v_strUsrLIMIT) And CDbl(v_strUsrLIMIT) <> 0 Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return ERR_SA_TRANSACT_APPROVRLIMIT
                            Else
                                'Check quyen cua nhom
                                If CDbl(v_strTransLimit) > v_dblGrpLIMIT Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    Return ERR_SA_TRANSACT_APPROVRLIMIT
                                End If
                            End If
                        Else
                            'Kiem tra quyen cua nhom
                            If v_dblGrpLIMIT > 0 Then
                                If CDbl(v_strTransLimit) > v_dblGrpLIMIT Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    Return ERR_SA_TRANSACT_APPROVRLIMIT
                                End If
                            Else
                                'Chua duoc phan quyen
                                Rollback() 'ContextUtil.SetAbort()
                                Return ERR_SA_TRANSACT_OFFICERLIMIT_NOTDEFINED
                            End If
                        End If


                    Else

                    End If
                End If
                'End of check right
                ''==============================================================

                CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value = v_strCHECKERID
                'Ki�ểm tra nếu không cần checker 2 duyệt sẽ chuyển lên HOST luôn. Nếu không chỉ cập nhật lại mã checker 1
                If (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(Trim(v_strOFFID)) = 0) Then
                    'Cập nhật checker 1
                    v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                    pv_strObjMsg = v_xmlDocument.InnerXml
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                    Else
                        Complete() 'ContextUtil.SetComplete()
                    End If
                    Return v_lngErrCode
                Else
                    '?�ưa lên host nếu không phải là giao dịch loại D. Với giao dịch loại D, phải thực hiện Cashier mới lên HOST
                    If Trim(v_strTXTYPE) <> "D" Then
                        'CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value = TransactStatus.Logged
                        CType(v_attrColl.GetNamedItem(gc_AtributePRETRAN), Xml.XmlAttribute).Value = "N"
                        pv_strObjMsg = v_xmlDocument.InnerXml
                        'v_lngErrCode = v_ws.Message(pv_strObjMsg)

                        'v_lngErrCode =  SendMessage2Host(pv_strObjMsg)
                        v_lngErrCode = txTransact(pv_strObjMsg)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        Else
                            v_xmlDocument.LoadXml(pv_strObjMsg)
                        End If
                    ElseIf Trim(v_strTXTYPE) = "D" Then
                        '?�ổi trạng thái giao dịch là ch? thanh to�án ở quỹ
                        CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value = TransactStatus.Cashier
                        v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                    End If
                    'v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                    pv_strObjMsg = v_xmlDocument.InnerXml
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                    Else
                        Complete() 'ContextUtil.SetComplete()
                    End If
                    Return v_lngErrCode
                End If
            Else
                'Nếu là checker 2 (Officer) duyệt
                ''=================================================================
                'Kiểm tra NDS hiện tại có được phép duyệt rủi ro với giao dịch không. Nếu không báo lỗi
                'Nếu là Admin thì không cần kiểm tra.
                If v_strCHECKERID <> ADMIN_ID Then
                    Dim v_intNumGrp As Integer
                    'If current user is not a checker
                    If v_strOfficer <> "Y" Then
                        Return ERR_SA_CRTUSR_NOTOFFICER
                    End If

                    v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='U' " &
                                                    "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strCHECKERID & "'"
                    Dim v_strUsrCMDALLOW As String
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        'Lấy quy?n �được gán
                        v_strUsrCMDALLOW = CStr(v_ds.Tables(0).Rows(0)("CMDALLOW")).Trim
                        If v_strUsrCMDALLOW <> "Y" Then
                            'Chưa được phân quy?n
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CMDALLOW
                        End If
                    Else
                        'Check right of groups
                        v_strSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHECKERID & "' AND A.ACTIVE = 'Y'"
                        v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        Dim v_blnAllow As Boolean = False
                        If v_ds.Tables(0).Rows.Count > 0 Then
                            v_intNumGrp = v_ds.Tables(0).Rows.Count
                            Dim v_strGrpId, v_strGrpAllow As String
                            'Get name of groups
                            For i As Integer = 0 To v_intNumGrp - 1
                                v_strGrpId = CStr(v_ds.Tables(0).Rows(i)("GRPID")).Trim
                                'Get access right of each group and add rights to hash table
                                v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='G' " &
                                           "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strGrpId & "'"

                                Dim v_dsGrpRight As DataSet
                                Dim v_objGrpRight As New DataAccess
                                v_dsGrpRight = v_objGrpRight.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                If v_dsGrpRight.Tables(0).Rows.Count = 1 Then
                                    v_strGrpAllow = IIf(v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW"))
                                End If
                                If Trim(v_strGrpAllow) = "Y" Then
                                    v_blnAllow = True
                                    Exit For
                                End If
                            Next
                        End If
                        If v_blnAllow = False Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CMDALLOW
                        End If
                    End If

                    'Get LIMIT of user
                    Dim v_strTltxSQL As String
                    v_strTltxSQL = "SELECT A.TLLIMIT TLLIMIT " _
                                    & "FROM TLTX M, TLAUTH A " _
                                    & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strCHECKERID & "' AND A.TLTYPE = 'A' AND A.AUTHTYPE = 'U' AND A.CODEID = '" & v_strCCYUSAGE & "'"
                    Dim v_dsTltx As DataSet
                    Dim v_strUsrLIMIT As String
                    v_dsTltx = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strTltxSQL)
                    If v_dsTltx.Tables(0).Rows.Count > 0 Then
                        v_strUsrLIMIT = CStr(IIf(v_dsTltx.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsTltx.Tables(0).Rows(0)("TLLIMIT"))).Trim
                    End If

                    'Get the groups that user is in
                    Dim v_strGrpSQL As String
                    v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHECKERID & "' AND A.ACTIVE = 'Y'"
                    Dim v_dsGrp As DataSet
                    v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
                    Dim v_dblGrpLIMIT As Double = 0
                    If v_dsGrp.Tables(0).Rows.Count > 0 Then
                        v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                        Dim v_strGrpId As String
                        'Get Largest Limit of groups
                        For i As Integer = 0 To v_intNumGrp - 1
                            v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                            'Get Limit of each group.
                            v_strSQL = "SELECT A.TLLIMIT TLLIMIT " _
                                    & "FROM TLTX M, TLAUTH A " _
                                    & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strGrpId & "' AND A.TLTYPE = 'A' AND A.AUTHTYPE = 'G' AND A.CODEID = '" & v_strCCYUSAGE & "'"

                            Dim v_dsGrpRight As DataSet
                            v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            'Get Limit of group
                            Dim v_strLIMIT As String = "0"
                            If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                                v_strLIMIT = CStr(IIf(v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT"))).Trim
                                If (v_strLIMIT <> String.Empty) And (IsNumeric(v_strLIMIT)) Then
                                    If CDbl(v_strLIMIT) > v_dblGrpLIMIT Then
                                        v_dblGrpLIMIT = CDbl(v_strLIMIT)
                                    End If
                                End If
                            End If
                        Next
                    End If

                    'Compare value of transaction with limit
                    If (v_strTransLimit <> String.Empty) And (IsNumeric(v_strTransLimit)) Then
                        If IsNumeric(v_strUsrLIMIT) Then
                            'Kiem tra quyen USER: v_strUsrLIMIT=0 tuc la khong co quyen
                            If CDbl(v_strTransLimit) > CDbl(v_strUsrLIMIT) And CDbl(v_strUsrLIMIT) <> 0 Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return ERR_SA_TRANSACT_APPROVRLIMIT
                            Else
                                'Check quyen cua nhom
                                If CDbl(v_strTransLimit) > IIf(CDbl(v_strUsrLIMIT) > v_dblGrpLIMIT, CDbl(v_strUsrLIMIT), v_dblGrpLIMIT) Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    Return ERR_SA_TRANSACT_APPROVRLIMIT
                                End If
                            End If
                        Else
                            'Kiem tra quyen cua nhom
                            If v_dblGrpLIMIT > 0 Then
                                If CDbl(v_strTransLimit) > v_dblGrpLIMIT Then
                                    Rollback() 'ContextUtil.SetAbort()
                                    Return ERR_SA_TRANSACT_APPROVRLIMIT
                                End If
                            Else
                                'Chua duoc phan quyen
                                Rollback() 'ContextUtil.SetAbort()
                                Return ERR_SA_TRANSACT_OFFICERLIMIT_NOTDEFINED
                            End If
                        End If
                    Else

                    End If
                End If
                'End of check right
                ''======================================================

                If (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(Trim(v_strOFFID)) = 0) Then
                    CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value = v_strCHECKERID

                    '�?�ưa lên host nếu không phải là giao dịch loại D. Với giao dịch loại D, phải thực hiện Cashier mới lên HOST
                    If Trim(v_strTXTYPE) <> "D" Then
                        CType(v_attrColl.GetNamedItem(gc_AtributePRETRAN), Xml.XmlAttribute).Value = "N"
                        pv_strObjMsg = v_xmlDocument.InnerXml
                        'v_lngErrCode = SendMessage2Host(pv_strObjMsg)
                        v_lngErrCode = txTransact(pv_strObjMsg)

                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                         & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                         & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                            Rollback() 'ContextUtil.SetAbort()
                            Return v_lngErrCode
                        Else
                            v_xmlDocument.LoadXml(pv_strObjMsg)
                        End If
                    ElseIf Trim(v_strTXTYPE) = "D" Then
                        '?�ổi trạng thái giao dịch là ch? thanh to�án ở quỹ
                        CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value = TransactStatus.Cashier
                        v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                    End If

                    'v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)

                    pv_strObjMsg = v_xmlDocument.InnerXml
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                    Else
                        'Ghi Log
                        If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                            Dim v_strMsgCheck As String
                            v_strMsgCheck = BuildXMLObjMsg(, HO_BRID, , v_strCHKID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                            'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                            v_lngErrCode = txTransact(pv_strObjMsg)
                        End If

                        Complete() 'ContextUtil.SetComplete()
                    End If
                    Return v_lngErrCode
                End If
            End If
            Complete() 'ContextUtil.SetComplete()
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function ApproveDeleteMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_lngErrLog As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.ApproveDeleteMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)

            'Lấy mã TLID duyệt giao dịch
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strOFFICERID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strTlRight As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Get right of current teller
            Dim v_strOfficer, v_strChecker As String
            If v_strTlRight <> String.Empty Then
                v_strOfficer = Mid(v_strTlRight, 3, 1)
                v_strChecker = Mid(v_strTlRight, 4, 1)
            End If

            'Lấy thông tin chi tiết ve giao dich dang xoa
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            v_attrColl = v_xmlDocument.DocumentElement.Attributes
            Dim v_strTLID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strCHKID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            Dim v_strOFFID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            Dim v_strOVRRQS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            Dim v_strTXTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXTYPE), Xml.XmlAttribute).Value)
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_strDELTD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            Dim v_intSTATUS As String = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)

            If v_strDELTD = MSGTRANS_DELETED Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            Dim v_strSQL As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess


            'Kiem tra xem chi nhanh co hoat dong hay khong 
            Dim v_strBranchStatus As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "HOSTATUS", v_strBranchStatus)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strBranchStatus = OPERATION_INACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_HOST_OPERATION_ISINACTIVE
            End If

            'Check right of current teller
            If v_strTLID <> ADMIN_ID Then
                'If current teller is not a officer
                If v_strOfficer <> "Y" Then
                    Return ERR_SA_CRTUSR_NOTOFFICER
                End If
                'Check CMDALLOW of this transaction
                v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='U' " &
                                                    "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strTLID & "'"
                Dim v_strCMDALLOW As String
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Get right
                    v_strCMDALLOW = CStr(v_ds.Tables(0).Rows(0)("CMDALLOW")).Trim
                    If v_strCMDALLOW <> "Y" Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                Else
                    'Check right of groups
                    'v_strSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTLID & "' AND A.ACTIVE = 'Y'"
                    v_strSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTLID & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    Dim v_blnAllow As Boolean = False
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        Dim v_intNumGrp As Int16 = v_ds.Tables(0).Rows.Count
                        Dim v_strGrpId, v_strGrpAllow As String
                        'Get name of groups
                        For i As Integer = 0 To v_intNumGrp - 1
                            v_strGrpId = CStr(v_ds.Tables(0).Rows(i)("GRPID")).Trim
                            'Get access right of each group and add rights to hash table
                            v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='G' " &
                                       "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strGrpId & "'"

                            Dim v_dsGrpRight As DataSet
                            Dim v_objGrpRight As New DataAccess
                            v_dsGrpRight = v_objGrpRight.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsGrpRight.Tables(0).Rows.Count = 1 Then
                                v_strGrpAllow = IIf(v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW"))
                            End If
                            If Trim(v_strGrpAllow) = "Y" Then
                                v_blnAllow = True
                                Exit For
                            End If
                        Next
                    End If
                    If v_blnAllow = False Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                    ''If teller were not assigned
                    'Rollback() 'ContextUtil.SetAbort()
                    'Return ERR_SA_TRANSACT_CMDALLOW
                End If
            End If
            'End of check right
            ''========================================

            'Check to sure this transaction is allowed to delete
            Dim v_strREFOBJ, v_strREFKEYFLD As String
            Dim v_strRefKeyVal As String = String.Empty
            v_strSQL = "SELECT * FROM TLTX WHERE TLTXCD='" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Dim v_strDELALLOW As String = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DELALLOW")))
                v_strREFOBJ = CStr(IIf(v_ds.Tables(0).Rows(0)("REFOBJ") Is DBNull.Value, "", v_ds.Tables(0).Rows(0)("REFOBJ"))).Trim
                v_strREFKEYFLD = CStr(IIf(v_ds.Tables(0).Rows(0)("REFKEYFLD") Is DBNull.Value, "", v_ds.Tables(0).Rows(0)("REFKEYFLD"))).Trim
                If v_strREFOBJ.Length > 0 And v_strREFKEYFLD.Length > 0 Then
                    v_strRefKeyVal = GetKeyFldVal(v_xmlDocument.InnerXml, v_strREFKEYFLD)
                End If
                'Chi xoa nhung giap dich dang o trang thai Pending to Delete
                If Trim(v_strDELTD) <> MSGTRANS_DELETED And v_intSTATUS = TransactStatus.Deleting And v_strDELALLOW = "Y" Then
                    'Kiểm tra quyen xoa giao dịch của OFFICER
                    CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value = v_strOFFICERID
                    CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value = "Y"
                    'CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value = TransactStatus.Deleted
                    'Update status


                    'v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                    pv_strObjMsg = v_xmlDocument.InnerXml
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                    'Reverse lại giao dịch trên HOST
                    'v_lngErrCode = SendMessage2Host(pv_strObjMsg)
                    v_lngErrCode = txTransact(pv_strObjMsg)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                    v_xmlDocument.LoadXml(pv_strObjMsg)
                    'Xoá giao dịch ở BDS
                    v_lngErrCode = v_objMessageLog.TransDelete(v_xmlDocument)
                    pv_strObjMsg = v_xmlDocument.InnerXml
                Else
                    v_lngErrCode = ERR_SA_CANNOT_DELETETRANSACTION
                End If
            Else
                v_lngErrCode = ERR_SA_TLTXCD_NOTFOUND
            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                'Ghi Log
                If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                    Dim v_strMsgCheck As String
                    v_strMsgCheck = BuildXMLObjMsg(, HO_BRID, , v_strCHKID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "D", )
                    'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                    v_lngErrCode = txTransact(pv_strObjMsg)
                End If
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function DeleteMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.DeleteMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)

            'Lấy mã TellerID nhân viên quỹ để kiểm tra có phải là nhân viên quỹ thực sự không
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHECKERID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            'Lấy thông tin chi tiết v? giao d�ịch
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            v_attrColl = v_xmlDocument.DocumentElement.Attributes
            Dim v_strTLID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strBRID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strCHKID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            Dim v_strOFFID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            Dim v_strOVRRQS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            Dim v_strTXTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXTYPE), Xml.XmlAttribute).Value)
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_strDELTD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            Dim v_intSTATUS As String = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            If v_strDELTD = MSGTRANS_DELETED Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Kiểm tra giao dịch có được phép xoá hay không
            Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess

            'Kiem tra xem chi nhanh co hoat dong hay khong 
            Dim v_strBranchStatus As String
            v_lngErrCode = v_obj.GetSysVar("SYSTEM", "HOSTATUS", v_strBranchStatus)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            If v_strBranchStatus = OPERATION_INACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_BDS_OPERATION_ISINACTIVE
            End If

            v_strSQL = "SELECT * FROM TLTX WHERE TLTXCD='" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Dim v_strDELALLOW As String = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DELALLOW")))
                'Chỉ được phép xoá những giao dịch chưa bị xoá, không có lỗi hay bị reject. Ai làm giao dịch ngư?i �đó mới được xoá
                If Trim(v_strDELTD) <> MSGTRANS_DELETED And v_intSTATUS <> TransactStatus.Refuse _
                    And v_intSTATUS <> TransactStatus.ErrorOccured And v_intSTATUS <> TransactStatus.Completed And v_strCHECKERID = v_strTLID And v_strDELALLOW = "Y" Then
                    CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value = "Y"
                    'NEU GIAO DICH W/R/O MA BI REJECT THI KHI XOA KHONG REVERT NUA
                    If v_intSTATUS <> TransactStatus.Rejected Then
                        If (v_strTXTYPE = "W" Or v_strTXTYPE = "R" Or v_strTXTYPE = "O") Then
                            'Nếu giao dịch đã bị đẩy lên HOST rồi thì phải Reverse lại
                            pv_strObjMsg = v_xmlDocument.InnerXml
                            'v_lngErrCode = SendMessage2Host(pv_strObjMsg)
                            v_lngErrCode = txTransact(pv_strObjMsg)
                            If v_lngErrCode <> ERR_SYSTEM_OK Then
                                Rollback() 'ContextUtil.SetAbort()
                                Return v_lngErrCode
                            End If
                            v_xmlDocument.LoadXml(pv_strObjMsg)
                        End If
                    End If

                    'Ghi nhận vào bảng kê quỹ: 
                    'Không cần ghi nhận vì khi khởi tạo lại BDS sẽ tính lại số dư quỹ đầu ngày

                    'Trả v? k�ết quả
                    v_lngErrCode = v_objMessageLog.TransDelete(v_xmlDocument)
                    pv_strObjMsg = v_xmlDocument.InnerXml

                    'Voi cac giao dich T,D,M thuc hien ghi log len HOST de cho giai phap Direct Recovery
                    'Cac giao dich o trang thai cho duyet hien khong duoc ghi len HOST
                    Dim v_strLog4DR As String
                    v_lngErrCode = v_obj.GetSysVar("SYSTEM", "LOG4DR", v_strLog4DR)

                    If v_strLog4DR = "Y" And (v_strTXTYPE = "T" Or v_strTXTYPE = "M" Or v_strTXTYPE = "D") Then
                        Dim v_strMsgCheck As String
                        v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransDelete4DR")
                        'v_lngErrCode = SendMessage2Host(v_strMsgCheck)
                        v_lngErrCode = txTransact(pv_strObjMsg)
                    End If

                Else
                    v_lngErrCode = ERR_SA_CANNOT_DELETETRANSACTION
                End If
            Else
                v_lngErrCode = ERR_SA_TLTXCD_NOTFOUND
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    'Chi nhung giao dich o trnag thai Complete thi moi chuyen ve trang thai Pending to delete
    Public Function DeletingMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.DeleteMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)

            'Lấy mã TellerID nhân viên quỹ để kiểm tra có phải là nhân viên quỹ thực sự không
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHECKERID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            'Lấy thông tin chi tiết ve giao dich
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            v_attrColl = v_xmlDocument.DocumentElement.Attributes
            Dim v_strTLID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strCHKID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            Dim v_strOFFID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            Dim v_strOVRRQS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            Dim v_strTXTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXTYPE), Xml.XmlAttribute).Value)
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_strDELTD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            Dim v_intSTATUS As String = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            If v_strDELTD = MSGTRANS_DELETED Or v_intSTATUS = TransactStatus.Deleting Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Kiểm tra giao dịch có được phép xoá hay không
            Dim v_strSQL As String, v_ds As DataSet, v_obj As New DataAccess
            v_strSQL = "SELECT * FROM TLTX WHERE TLTXCD='" & v_strTLTXCD & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                Dim v_strDELALLOW As String = Trim(gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DELALLOW")))
                'Chỉ được phép xoá những giao dịch chưa bị xoá, không có lỗi hay bị reject. Ai làm giao dịch ngư?i �đó mới được xoá
                If Trim(v_strDELTD) <> MSGTRANS_DELETED And v_intSTATUS = TransactStatus.Completed And v_strCHECKERID = v_strTLID And v_strDELALLOW = "Y" Then
                    CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value = "N"
                    CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value = TransactStatus.Deleting
                    v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)
                    pv_strObjMsg = v_xmlDocument.InnerXml
                    'v_lngErrCode = SendMessage2Host(pv_strObjMsg)
                    v_lngErrCode = txTransact(pv_strObjMsg)
                    'Xác định nguyên nhân duyệt và thông báo lại cho Client
                    If v_lngErrCode = ERR_SA_CHECKER1_OVR Or v_lngErrCode = ERR_SA_CHECKER2_OVR Then
                        v_xmlDocument.LoadXml(pv_strObjMsg)
                        BuildCheckerReason(v_xmlDocument)
                        pv_strObjMsg = v_xmlDocument.InnerXml
                    End If

                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If
                Else
                    v_lngErrCode = ERR_SA_CANNOT_DELETETRANSACTION
                End If
            Else
                v_lngErrCode = ERR_SA_TLTXCD_NOTFOUND
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function RejectMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_lngErrLog As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.RejectMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)
            'Lấy mã TellerID nhân viên quỹ để kiểm tra checker có quy?n duy�ệt không
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHECKERID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strREFERENCE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

            'Lấy thông tin chi tiết v? giao d�ịch
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            v_attrColl = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHKID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            Dim v_strOFFID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            Dim v_strOVRRQS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            Dim v_strTXTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXTYPE), Xml.XmlAttribute).Value)
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_intSTATUS As String = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            Dim v_strDELTD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            Dim v_strCCYUSAGE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCCYUSAGE), Xml.XmlAttribute).Value)
            Dim v_strBRID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            v_strCCYUSAGE = "00"
            'Kiểm tra chỉ cho phép duyệt nếu trạng thái là Pending và không bị xoá
            Dim v_strSQL As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess

            Dim v_strTXNUM As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Dim v_strTXDATE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Dim v_strTLID
            v_strSQL = "SELECT * FROM TLLOG WHERE DELTD='N' AND TXSTATUS='" & TransactStatus.Pending & "' AND TXNUM='" & v_strTXNUM _
                & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Trạng thái không hợp lệ
                v_lngErrCode = ERR_SA_TLLOG_INVALID_STATUS
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                v_strTLID = v_ds.Tables(0).Rows(0).Item("TLID")
            End If

            If v_strDELTD = MSGTRANS_DELETED Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            'Get MSG_AMT of transaction
            v_strSQL = "SELECT MSG_AMT,REFOBJ, REFKEYFLD FROM TLTX WHERE TLTXCD = '" & v_strTLTXCD & "'"
            Dim v_dsAmt As DataSet
            v_dsAmt = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strMSG_AMT, v_strREFOBJ, v_strREFKEYFLD As String
            If v_dsAmt.Tables(0).Rows.Count > 0 Then
                v_strMSG_AMT = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("MSG_AMT") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("MSG_AMT"))).Trim
                v_strREFOBJ = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("REFOBJ") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("REFOBJ"))).Trim
                v_strREFKEYFLD = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("REFKEYFLD") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("REFKEYFLD"))).Trim
            End If

            Dim v_strRefKeyVal As String = String.Empty
            If v_strREFOBJ.Length > 0 And v_strREFKEYFLD.Length > 0 Then
                v_strRefKeyVal = GetKeyFldVal(v_xmlDocument.InnerXml, v_strREFKEYFLD)
            End If

            'Kiểm tra NDS hiện tại có được reject ha ko
            'Nếu là Admin, maker cua giao dich thì không cần kiểm tra.
            If v_strCHECKERID <> ADMIN_ID And v_strCHECKERID <> v_strTLID Then
                Dim v_intNumGrp As Integer

                v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='U' " &
                                                "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strCHECKERID & "'"
                Dim v_strUsrCMDALLOW As String
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Lấy quy?n �được gán
                    v_strUsrCMDALLOW = CStr(v_ds.Tables(0).Rows(0)("CMDALLOW")).Trim
                    If v_strUsrCMDALLOW <> "Y" Then
                        'Chưa được phân quy?n
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                Else
                    'Check right of groups
                    'v_strSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHECKERID & "' AND A.ACTIVE = 'Y'"
                    v_strSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHECKERID & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    Dim v_blnAllow As Boolean = False
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_intNumGrp = v_ds.Tables(0).Rows.Count
                        Dim v_strGrpId, v_strGrpAllow As String
                        'Get name of groups
                        For i As Integer = 0 To v_intNumGrp - 1
                            v_strGrpId = CStr(v_ds.Tables(0).Rows(i)("GRPID")).Trim
                            'Get access right of each group and add rights to hash table
                            v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='G' " &
                                       "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strGrpId & "'"

                            Dim v_dsGrpRight As DataSet
                            Dim v_objGrpRight As New DataAccess
                            v_dsGrpRight = v_objGrpRight.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsGrpRight.Tables(0).Rows.Count = 1 Then
                                v_strGrpAllow = IIf(v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW"))
                            End If
                            If Trim(v_strGrpAllow) = "Y" Then
                                v_blnAllow = True
                                Exit For
                            End If
                        Next
                    End If
                    If v_blnAllow = False Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                End If

                'Get LIMIT of user
                Dim v_strTltxSQL As String
                v_strTltxSQL = "SELECT Max(A.TLLIMIT) TLLIMIT " _
                                & "FROM TLTX M, TLAUTH A " _
                                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strCHECKERID & "' AND A.TLTYPE <> 'T' AND A.AUTHTYPE = 'U' AND A.CODEID = '" & v_strCCYUSAGE & "'"
                Dim v_dsTltx As DataSet
                Dim v_strUsrLIMIT As String
                v_dsTltx = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strTltxSQL)
                If v_dsTltx.Tables(0).Rows.Count > 0 Then
                    v_strUsrLIMIT = CStr(IIf(v_dsTltx.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsTltx.Tables(0).Rows(0)("TLLIMIT"))).Trim
                End If

                'Get the groups that user is in
                Dim v_strGrpSQL As String
                v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHECKERID & "' AND A.ACTIVE = 'Y'"
                Dim v_dsGrp As DataSet
                v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
                Dim v_dblGrpLIMIT As Double = 0
                If v_dsGrp.Tables(0).Rows.Count > 0 Then
                    v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                    Dim v_strGrpId As String
                    'Get Largest Limit of groups
                    For i As Integer = 0 To v_intNumGrp - 1
                        v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                        'Get Limit of each group.
                        v_strSQL = "SELECT Max(A.TLLIMIT) TLLIMIT " _
                                & "FROM TLTX M, TLAUTH A " _
                                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strGrpId & "' AND A.TLTYPE <> 'T' AND A.AUTHTYPE = 'G' AND A.CODEID = '" & v_strCCYUSAGE & "'"

                        Dim v_dsGrpRight As DataSet
                        v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        'Get Limit of group
                        Dim v_strLIMIT As String
                        If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                            v_strLIMIT = CStr(IIf(v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT"))).Trim
                            If (v_strLIMIT <> String.Empty) And (IsNumeric(v_strLIMIT)) Then
                                If CDbl(v_strLIMIT) > v_dblGrpLIMIT Then
                                    v_dblGrpLIMIT = CDbl(v_strLIMIT)
                                End If
                            End If
                        End If
                    Next
                End If

                'Get value of transaction
                Dim v_nodeList As Xml.XmlNodeList
                v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/fields")
                Dim v_strFLDNAME, v_strValue, v_strTransLimit As String
                If v_nodeList.Count > 0 Then
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes.Item(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                                Select Case Trim(v_strFLDNAME)
                                    Case v_strMSG_AMT
                                        v_strTransLimit = Trim(v_strValue)
                                        Exit For
                                End Select
                            End With
                        Next
                    Next
                End If

                'Compare value of transaction with limit
                If (v_strTransLimit <> String.Empty) And (IsNumeric(v_strTransLimit)) Then
                    If (v_strUsrLIMIT <> String.Empty) And (IsNumeric(v_strUsrLIMIT)) Then
                        If CDbl(v_strTransLimit) > CDbl(v_strUsrLIMIT) Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CMDALLOW
                        End If
                    ElseIf v_dblGrpLIMIT > 0 Then
                        'If this user hasn't got his own right with this transaction
                        If CDbl(v_strTransLimit) > v_dblGrpLIMIT Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CMDALLOW
                        End If
                    ElseIf (CDbl(IIf(v_strUsrLIMIT = "", 0, v_strUsrLIMIT)) = 0) And (v_dblGrpLIMIT = 0) Then
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                Else

                End If
            End If
            'End of check right


            'Chỉ cho phép Reject đối với các giao dịch đang ch? duy�ệt. Vì đang ch? duy�ệt nên chỉ xử lý ở BDS
            If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(Trim(v_strCHKID)) = 0) _
                Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(Trim(v_strOFFID)) = 0) Then
                'Mặc định ngư?i Reject bao gi�? c�ũng là Checker 2. 
                '?�ối với giao dịch bị Reject khi Maker sửa giao dịch nhập lại sẽ thực hiện xoá luôn giao dịch cũ
                CType(v_attrColl.GetNamedItem(gc_AtributeTXDESC), Xml.XmlAttribute).Value = v_strREFERENCE
                CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value = TransactStatus.Rejected
                CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value = v_strCHECKERID

                '?�ối với giao dịch loại W/R/O thì phải gửi lên HOST để Reverse (xoá luôn)
                If Trim(v_strTXTYPE) = "W" Or Trim(v_strTXTYPE) = "R" Or Trim(v_strTXTYPE) = "O" Then
                    CType(v_attrColl.GetNamedItem(gc_AtributePRETRAN), Xml.XmlAttribute).Value = "N"
                    CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value = MSGTRANS_DELETED
                    pv_strObjMsg = v_xmlDocument.InnerXml

                    'v_lngErrCode = SendMessage2Host(pv_strObjMsg)
                    v_lngErrCode = txTransact(pv_strObjMsg)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    Else
                        v_xmlDocument.LoadXml(pv_strObjMsg)
                    End If
                End If

                'Goi ham xu ly dac biet cho GD 8800 
                If v_strTLTXCD = "8800" Then
                    Dim v_strStoredName, v_strMessage As String
                    v_strStoredName = "txpks_#" + v_strTLTXCD + "ex.fn_txAppReject"
                    Dim v_objParam As New StoreParameter
                    Dim v_arrPara(3) As StoreParameter

                    v_objParam.ParamName = "return"
                    v_objParam.ParamDirection = ParameterDirection.ReturnValue
                    v_objParam.ParamValue = 0
                    v_objParam.ParamSize = 100
                    v_objParam.ParamType = GetType(Double).Name
                    v_arrPara(0) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_txdate"
                    v_objParam.ParamValue = v_strTXDATE
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamSize = 32000
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(1) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_txnum"
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamValue = v_strTXNUM
                    v_objParam.ParamSize = 100
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(2) = v_objParam

                    v_objParam = New StoreParameter
                    v_objParam.ParamName = "p_tlid"
                    v_objParam.ParamDirection = ParameterDirection.Input
                    v_objParam.ParamValue = v_strCHECKERID
                    v_objParam.ParamSize = 500
                    v_objParam.ParamType = GetType(System.String).Name
                    v_arrPara(3) = v_objParam

                    v_lngErrCode = v_obj.ExecuteOracleStored(v_strStoredName, v_arrPara, 0)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                 & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                 & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    End If


                End If

                v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)

                'Voi cac giao dich T,D,M thuc hien ghi log len HOST de cho giai phap Direct Recovery
                'Cac giao dich o trang thai cho duyet hien khong duoc ghi len HOST
                Dim v_strLog4DR As String
                v_lngErrCode = v_obj.GetSysVar("SYSTEM", "LOG4DR", v_strLog4DR)

                If v_strLog4DR = "Y" And (v_strTXTYPE = "T" Or v_strTXTYPE = "M" Or v_strTXTYPE = "D") Then
                    Dim v_strMsgCheck As String
                    v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransUpdate4DR")

                    'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                    v_lngErrCode = txTransact(pv_strObjMsg)
                End If

                If v_lngErrCode <> ERR_SYSTEM_OK Then
                    Rollback() 'ContextUtil.SetAbort()
                Else
                    'Cập nhật lại trư?ng Desccription
                    v_strSQL = "UPDATE TLLOG " & ControlChars.CrLf _
                                & "SET TXDESC='" & Replace(v_strREFERENCE, "'", "''") & "' " & ControlChars.CrLf _
                                & "WHERE TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                    v_strSQL = "UPDATE TLLOGFLD SET CVALUE='" & Replace(v_strREFERENCE, "'", "''") & "'" & ControlChars.CrLf _
                                    & "WHERE FLDCD='30' AND TXDATE = TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "') AND TXNUM = '" & v_strTXNUM & "'"
                    v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

                    pv_strObjMsg = v_xmlDocument.InnerXml
                End If
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                'Ghi Log
                If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                    Dim v_strMsgCheck As String
                    v_strMsgCheck = BuildXMLObjMsg(, HO_BRID, , v_strCHKID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                    'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                    v_lngErrCode = txTransact(pv_strObjMsg)
                End If
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function RefuseMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_lngErrLog As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.RefuseMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)

            'Lấy mã TellerID nhân viên quỹ để kiểm tra checker có quy?n duyệt không
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHECKERID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            'Lấy thông tin chi tiết v? giao dịch
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            v_attrColl = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHKID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            Dim v_strOFFID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            Dim v_strOVRRQS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            Dim v_strTXTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXTYPE), Xml.XmlAttribute).Value)
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_intSTATUS As String = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            Dim v_strDELTD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            Dim v_strCCYUSAGE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCCYUSAGE), Xml.XmlAttribute).Value)
            Dim v_strBRID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            v_strCCYUSAGE = "00"
            'Kiểm tra chỉ cho phép duyệt nếu trạng thái là Pending và không bị xoá
            Dim v_strSQL As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess

            Dim v_strTXNUM As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Dim v_strTXDATE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            Dim v_strTLID As String
            v_strSQL = "SELECT * FROM TLLOG WHERE DELTD='N' AND TXSTATUS='" & TransactStatus.Pending & "' AND TXNUM='" & v_strTXNUM _
                & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Trạng thái không hợp lệ
                v_lngErrCode = ERR_SA_TLLOG_INVALID_STATUS
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                v_strTLID = v_ds.Tables(0).Rows(0).Item("TLID")
            End If

            If v_strDELTD = MSGTRANS_DELETED Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Get MSG_AMT of transaction
            v_strSQL = "SELECT MSG_AMT,REFOBJ, REFKEYFLD FROM TLTX WHERE TLTXCD = '" & v_strTLTXCD & "'"
            Dim v_dsAmt As DataSet
            v_dsAmt = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_strMSG_AMT, v_strREFOBJ, v_strREFKEYFLD As String
            If v_dsAmt.Tables(0).Rows.Count > 0 Then
                v_strMSG_AMT = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("MSG_AMT") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("MSG_AMT"))).Trim
                v_strREFOBJ = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("REFOBJ") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("REFOBJ"))).Trim
                v_strREFKEYFLD = CStr(IIf(v_dsAmt.Tables(0).Rows(0)("REFKEYFLD") Is DBNull.Value, "", v_dsAmt.Tables(0).Rows(0)("REFKEYFLD"))).Trim
            End If
            Dim v_strRefKeyVal As String = String.Empty
            If v_strREFOBJ.Length > 0 And v_strREFKEYFLD.Length > 0 Then
                v_strRefKeyVal = GetKeyFldVal(v_xmlDocument.InnerXml, v_strREFKEYFLD)
            End If

            'Kiểm tra NDS hiện tại có được reject hay ko
            'Nếu là Admin, maker cua giao dich thì không cần kiểm tra.
            If v_strCHECKERID <> ADMIN_ID And v_strCHECKERID <> v_strTLID Then
                Dim v_intNumGrp As Integer

                v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='U' " &
                                                "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strCHECKERID & "'"
                Dim v_strUsrCMDALLOW As String
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    'Lấy quy?n �được gán
                    v_strUsrCMDALLOW = CStr(v_ds.Tables(0).Rows(0)("CMDALLOW")).Trim
                    If v_strUsrCMDALLOW <> "Y" Then
                        'Chưa được phân quy?n
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                Else
                    'Check right of groups
                    v_strSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHECKERID & "' AND A.ACTIVE = 'Y'"
                    v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    Dim v_blnAllow As Boolean = False
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_intNumGrp = v_ds.Tables(0).Rows.Count
                        Dim v_strGrpId, v_strGrpAllow As String
                        'Get name of groups
                        For i As Integer = 0 To v_intNumGrp - 1
                            v_strGrpId = CStr(v_ds.Tables(0).Rows(i)("GRPID")).Trim
                            'Get access right of each group and add rights to hash table
                            v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='G' " &
                                       "AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strGrpId & "'"

                            Dim v_dsGrpRight As DataSet
                            Dim v_objGrpRight As New DataAccess
                            v_dsGrpRight = v_objGrpRight.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            If v_dsGrpRight.Tables(0).Rows.Count = 1 Then
                                v_strGrpAllow = IIf(v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW"))
                            End If
                            If Trim(v_strGrpAllow) = "Y" Then
                                v_blnAllow = True
                                Exit For
                            End If
                        Next
                    End If
                    If v_blnAllow = False Then
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                End If

                'Get LIMIT of user
                Dim v_strTltxSQL As String
                v_strTltxSQL = "SELECT Max(A.TLLIMIT) TLLIMIT " _
                                & "FROM TLTX M, TLAUTH A " _
                                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strCHECKERID & "' AND A.TLTYPE <> 'T' AND A.AUTHTYPE = 'U' AND A.CODEID = '" & v_strCCYUSAGE & "'"
                Dim v_dsTltx As DataSet
                Dim v_strUsrLIMIT As String
                v_dsTltx = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strTltxSQL)
                If v_dsTltx.Tables(0).Rows.Count > 0 Then
                    v_strUsrLIMIT = CStr(IIf(v_dsTltx.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsTltx.Tables(0).Rows(0)("TLLIMIT"))).Trim
                End If

                'Get the groups that user is in
                Dim v_strGrpSQL As String
                v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strCHECKERID & "' AND A.ACTIVE = 'Y'"
                Dim v_dsGrp As DataSet
                v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
                Dim v_dblGrpLIMIT As Double = 0
                If v_dsGrp.Tables(0).Rows.Count > 0 Then
                    v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                    Dim v_strGrpId As String
                    'Get Largest Limit of groups
                    For i As Integer = 0 To v_intNumGrp - 1
                        v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                        'Get Limit of each group.
                        v_strSQL = "SELECT Max(A.TLLIMIT) TLLIMIT " _
                                & "FROM TLTX M, TLAUTH A " _
                                & "WHERE M.TLTXCD = '" & v_strTLTXCD & "' AND M.TLTXCD = A.TLTXCD AND A.AUTHID = '" & v_strGrpId & "' AND A.TLTYPE <> 'T' AND A.AUTHTYPE = 'G' AND A.CODEID = '" & v_strCCYUSAGE & "'"

                        Dim v_dsGrpRight As DataSet
                        v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        'Get Limit of group
                        Dim v_strLIMIT As String
                        If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                            v_strLIMIT = CStr(IIf(v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("TLLIMIT"))).Trim
                            If (v_strLIMIT <> String.Empty) And (IsNumeric(v_strLIMIT)) Then
                                If CDbl(v_strLIMIT) > v_dblGrpLIMIT Then
                                    v_dblGrpLIMIT = CDbl(v_strLIMIT)
                                End If
                            End If
                        End If
                    Next
                End If

                'Get value of transaction
                Dim v_nodeList As Xml.XmlNodeList
                v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/fields")
                Dim v_strFLDNAME, v_strValue, v_strTransLimit As String
                If v_nodeList.Count > 0 Then
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes.Item(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                                Select Case Trim(v_strFLDNAME)
                                    Case v_strMSG_AMT
                                        v_strTransLimit = Trim(v_strValue)
                                        Exit For
                                End Select
                            End With
                        Next
                    Next
                End If

                'Compare value of transaction with limit
                If (v_strTransLimit <> String.Empty) And (IsNumeric(v_strTransLimit)) Then
                    If (v_strUsrLIMIT <> String.Empty) And (IsNumeric(v_strUsrLIMIT)) Then
                        If CDbl(v_strTransLimit) > CDbl(v_strUsrLIMIT) Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CMDALLOW
                        End If
                    ElseIf v_dblGrpLIMIT > 0 Then
                        'If this user hasn't got his own right with this transaction
                        If CDbl(v_strTransLimit) > v_dblGrpLIMIT Then
                            Rollback() 'ContextUtil.SetAbort()
                            Return ERR_SA_TRANSACT_CMDALLOW
                        End If
                    ElseIf (CDbl(IIf(v_strUsrLIMIT = "", 0, v_strUsrLIMIT)) = 0) And (v_dblGrpLIMIT = 0) Then
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                Else

                End If
            End If
            'End of check right

            'Chỉ cho phép Refuse đối với các giao dịch đang ch? duyệt. Vì đang ch? duyệt nên chỉ xử lý ở BDS
            If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(Trim(v_strCHKID)) = 0) _
                Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(Trim(v_strOFFID)) = 0) Then
                'Mặc định ngư?i Refuse bao gi? cũng là Checker 2
                CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value = TransactStatus.Refuse
                CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value = v_strCHECKERID

                '?ối với giao dịch loại W/R/O thì phải gửi lên HOST để Reverse (xoá luôn)
                If Trim(v_strTXTYPE) = "W" Or Trim(v_strTXTYPE) = "R" Or Trim(v_strTXTYPE) = "O" Then
                    CType(v_attrColl.GetNamedItem(gc_AtributePRETRAN), Xml.XmlAttribute).Value = "N"
                    CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value = MSGTRANS_DELETED
                    pv_strObjMsg = v_xmlDocument.InnerXml

                    'v_lngErrCode = SendMessage2Host(pv_strObjMsg)
                    v_lngErrCode = txTransact(pv_strObjMsg)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                                     & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                                     & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                        Rollback() 'ContextUtil.SetAbort()
                        Return v_lngErrCode
                    Else
                        v_xmlDocument.LoadXml(pv_strObjMsg)
                    End If
                End If

                'Cập nhật lại dưới BDS
                v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)

                'Voi cac giao dich T,D,M thuc hien ghi log len HOST de cho giai phap Direct Recovery
                'Cac giao dich o trang thai cho duyet hien khong duoc ghi len HOST
                Dim v_strLog4DR As String
                v_lngErrCode = v_obj.GetSysVar("SYSTEM", "LOG4DR", v_strLog4DR)

                If v_strLog4DR = "Y" And (v_strTXTYPE = "T" Or v_strTXTYPE = "M" Or v_strTXTYPE = "D") Then
                    Dim v_strMsgCheck As String
                    v_strMsgCheck = BuildXMLObjMsg(, v_strBRID, , v_strTLID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransUpdate4DR")
                    'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                    v_lngErrCode = txTransact(pv_strObjMsg)
                End If

                pv_strObjMsg = v_xmlDocument.InnerXml
            End If
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                'Ghi Log
                If v_strREFOBJ.Length > 0 And v_strRefKeyVal.Length > 0 Then
                    Dim v_strMsgCheck As String
                    v_strMsgCheck = BuildXMLObjMsg(, HO_BRID, , v_strCHKID, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_xmlDocument.InnerXml, "TransTLLOGEXT", v_strRefKeyVal, v_strREFOBJ, "U", )
                    'v_lngErrLog = SendMessage2Host(v_strMsgCheck)
                    v_lngErrCode = txTransact(pv_strObjMsg)
                End If
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function RefuseDeletingMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.RefuseDeletingMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try

            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)

            'Lấy mã TellerID nhân viên quỹ để kiểm tra checker có quy?n duyệt không
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHECKERID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            'Lấy thông tin chi tiết v? giao dịch
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            v_attrColl = v_xmlDocument.DocumentElement.Attributes
            Dim v_strCHKID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            Dim v_strOFFID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            Dim v_strOVRRQS As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            Dim v_strTXTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXTYPE), Xml.XmlAttribute).Value)
            Dim v_strTLTXCD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            Dim v_intSTATUS As String = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            Dim v_strDELTD As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)

            'Kiểm tra chỉ cho phép duyệt nếu trạng thái là Pending và không bị xoá
            Dim v_strSQL As String
            Dim v_ds As DataSet
            Dim v_obj As New DataAccess

            Dim v_strTXNUM As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXNUM), Xml.XmlAttribute).Value)
            Dim v_strTXDATE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
            v_strSQL = "SELECT * FROM TLLOG WHERE DELTD='N' AND TXSTATUS='" & TransactStatus.Deleting & "' AND TXNUM='" & v_strTXNUM _
                & "' AND TXDATE=TO_DATE('" & v_strTXDATE & "','" & gc_FORMAT_DATE & "')"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Trạng thái không hợp lệ
                v_lngErrCode = ERR_SA_TLLOG_INVALID_STATUS
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            If v_strDELTD = MSGTRANS_DELETED Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            'Chỉ cho phép Refuse đối với các giao dịch đang cho xoa.

            CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value = TransactStatus.Completed
            CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value = v_strCHECKERID
            CType(v_attrColl.GetNamedItem(gc_AtributePRETRAN), Xml.XmlAttribute).Value = "N"
            CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value = MSGTRANS_DELETED
            pv_strObjMsg = v_xmlDocument.InnerXml
            'v_lngErrCode = SendMessage2Host(pv_strObjMsg)
            v_lngErrCode = txTransact(pv_strObjMsg)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                v_xmlDocument.LoadXml(pv_strObjMsg)
            End If

            'Cập nhật lại dưới BDS
            v_lngErrCode = v_objMessageLog.TransUpdateStatus(v_xmlDocument)
            pv_strObjMsg = v_xmlDocument.InnerXml

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function DeleteAutoGV(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.ApproveDeleteMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)

            'Lấy mã TLID duyệt giao dịch
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strOFFICERID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strTlRight As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Get right of current teller
            Dim v_strOfficer, v_strChecker As String
            If v_strTlRight <> String.Empty Then
                v_strOfficer = Mid(v_strTlRight, 3, 1)
                v_strChecker = Mid(v_strTlRight, 4, 1)
            End If


            'Reverse lại giao dịch trên HOST
            'v_lngErrCode = SendMessage2Host(pv_strObjMsg)
            v_lngErrCode = txTransact(pv_strObjMsg)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If
            v_xmlDocument.LoadXml(pv_strObjMsg)

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function txFeedbackInformation(ByVal pv_strMessage As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Branch.Branch.txFeedbackInformation", v_strErrorMessage As String
        Try
            Return v_lngErrCode
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AsynchronousProcessing(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Branch.Branch.AsynchronousProcessing", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess, v_ds As DataSet, v_objMessageLog As New MessageLog, v_xmlDocument As New Xml.XmlDocument

        Try
            'Kiểm tra chỉ cho phép chạy Batch nếu BDS đã InActive
            Dim v_strSYSVAR, v_strSQL, v_strTXDATE, v_strTXNUM, v_strMSGID, v_strTxMsg As String
            v_lngErrCode = v_DataAccess.GetSysVar("SYSTEM", "HOSTATUS", v_strSYSVAR)
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            End If

            If Not v_strSYSVAR = OPERATION_ACTIVE Then
                Rollback() 'ContextUtil.SetAbort()
                Return ERR_SA_BDS_OPERATION_STILLACTIVE
            Else
                v_strSQL = "SELECT QUEUEID, MSGID FROM MSGQUEUE WHERE MSGTYPE='TX' AND MSGSTS='P'"
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                        If Not IsDBNull(v_ds.Tables(0).Rows(i)("MSGID")) Then
                            'Lay giao dich dang pending de xu ly
                            v_strMSGID = v_ds.Tables(0).Rows(i)("MSGID")
                            v_strTXDATE = Left(v_strMSGID, 10)
                            v_strTXNUM = Right(v_strMSGID, 10)
                            v_strTxMsg = BuildXMLObjMsg(v_strTXDATE, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
                            v_xmlDocument.LoadXml(v_strTxMsg)
                            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
                            v_strTxMsg = v_xmlDocument.InnerXml
                            'Submit xu ly
                            v_lngErrCode = txTransfer(v_strTxMsg)
                            'Forward information to PUBLIC INFO SERVER
                            v_lngErrCode = txFeedbackInformation(v_strTxMsg)
                        End If
                    Next
                End If
                v_ds.Dispose()
            End If

            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        Finally
            v_DataAccess = Nothing
            v_objMessageLog = Nothing
        End Try
    End Function

    Public Function CheckSETickSize(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Branch.Branch.CheckSETickzise", v_strErrorMessage As String

        Try
            Dim XMLDocument As New Xml.XmlDocument
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim i As Integer

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strSQL As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY), Xml.XmlAttribute).Value)

            'Kiểm tra xem có ticksize đã tồn tại chưa             
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)

            If v_ds.Tables(0).Rows.Count = 0 Then
                'Không đúng với TICKSIZE
                v_lngErrCode = ERR_OD_TICKSIZE_INCOMPLIANT
                LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
                             & "Error code: " & v_lngErrCode.ToString() & vbNewLine _
                             & "Error message: " & v_strErrorMessage, "EventLogEntryType.Error")
                Return v_lngErrCode
            End If

            'Trả v? k�ết quả
            pv_strObjMsg = XMLDocument.InnerXml
            Complete() 'ContextUtil.SetComplete()

            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

#End Region

#Region " Authorization "
    Public Function GetAuthorizationTicket(ByVal pv_strUserName As String, Optional ByVal pv_strPassword As String = "") As String

        Try
            Dim v_strRetval As String
            Dim v_strTellerId, v_strBranchId, v_strPIN As String
            Dim isLockAccount As String

            Dim v_bCmd As New BusinessCommand
            Dim v_strEncryPass As String
            v_bCmd.SQLCommand = "Select BRID, TLID,ACTIVE, PIN, SYSDATE , GENENCRYPTPASSWORD('" + pv_strPassword + "') ENCRYPASS from TLPROFILES where upper(TLNAME) = '" & UCase$(pv_strUserName) & "' AND ACTIVE <> 'N'"
            Dim v_dal As New DataAccess
            v_dal.NewDBInstance(gc_MODULE_HOST)

            v_dal.LogCommand = True
            Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)

            If v_ds.Tables(0).Rows.Count = 1 Then
                v_strBranchId = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BRID"))
                v_strTellerId = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLID"))
                v_strPIN = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PIN"))
                v_strEncryPass = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ENCRYPASS"))
                isLockAccount = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("ACTIVE"))
                If isLockAccount = "B" Then
                    v_strRetval = 6
                ElseIf v_strBranchId = String.Empty Or v_strTellerId = String.Empty Then
                    v_strRetval = Nothing
                Else
                    If (pv_strPassword.Length > 0) Then     'Lưu mật khẩu trong DB
                        'If (DataProtection.UnprotectData(pv_strPassword) <> DataProtection.UnprotectData(v_strPIN)) Then
                        'Ducnv kiem tra pass ma hoa
                        If v_strPIN <> v_strEncryPass Then
                            Try
                                Dim wrongPasswordStr = "Select * from ENTERWRONGPASS where TLID = '" & v_strTellerId & "'"
                                v_bCmd.ExecuteUser = "admin"
                                v_bCmd.SQLCommand = wrongPasswordStr
                                Dim result As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)

                                If result.Tables(0).Rows.Count = 1 Then
                                    Dim updateAmountStr = "UPDATE ENTERWRONGPASS SET AMOUNT = AMOUNT + 1 WHERE TLID ='" & v_strTellerId & "'"
                                    v_bCmd.ExecuteUser = "admin"
                                    v_bCmd.SQLCommand = updateAmountStr
                                    Dim amount As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
                                Else
                                    Dim insertAmountStr = "INSERT INTO ENTERWRONGPASS (TLID, AMOUNT, TLNAME, LOCKDATE) VALUES('" & v_strTellerId & "',1,'','')"
                                    v_bCmd.ExecuteUser = "admin"
                                    v_bCmd.SQLCommand = insertAmountStr
                                    v_dal.ExecuteSQLReturnDataset(v_bCmd)
                                End If
                                Dim checkAmountStr = "SELECT * FROM ENTERWRONGPASS WHERE TLID = '" & v_strTellerId & "' AND AMOUNT = 5"
                                v_bCmd.ExecuteUser = "admin"
                                v_bCmd.SQLCommand = checkAmountStr
                                Dim rs As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
                                If rs.Tables(0).Rows.Count = 1 Then
                                    Dim updateLockStr = "UPDATE TLPROFILES SET ACTIVE = 'B' WHERE TLID = '" & v_strTellerId & "'"
                                    v_bCmd.ExecuteUser = "admin"
                                    v_bCmd.SQLCommand = updateLockStr
                                    v_dal.ExecuteSQLReturnDataset(v_bCmd)
                                    v_strRetval = 6
                                End If
                            Catch ex As Exception
                                Throw ex
                            End Try
                            v_strRetval = Nothing
                        Else
                            v_strRetval = v_strBranchId & "|" & v_strTellerId & "|" & DataProtection.UnprotectData(v_strPIN)
                            Dim checkAmountWrong = "SELECT * FROM ENTERWRONGPASS WHERE TLID = '" & v_strTellerId & "' AND AMOUNT < 5"
                            v_bCmd.ExecuteUser = "admin"
                            v_bCmd.SQLCommand = checkAmountWrong
                            Dim resultQuery As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)
                            If resultQuery.Tables(0).Rows.Count = 1 Then
                                Dim delete = "DELETE FROM ENTERWRONGPASS  WHERE TLID = '" & v_strTellerId & "'"
                                v_bCmd.ExecuteUser = "admin"
                                v_bCmd.SQLCommand = delete
                                v_dal.ExecuteSQLReturnDataset(v_bCmd)
                            End If
                            Try
                                Dim currentTime As DateTime = DateTime.Now
                                Dim updateCurrentDateLogin As String = "UPDATE TLPROFILES Set LASTLOGINDATE = TO_TIMESTAMP('" & currentTime & "', 'DD/MM/YYYY hh:mi:ss AM') WHERE TLID ='" & v_strTellerId & "'"
                                v_bCmd.ExecuteUser = "admin"
                                v_bCmd.SQLCommand = updateCurrentDateLogin
                                v_dal.ExecuteSQLReturnDataset(v_bCmd)
                            Catch ex As Exception
                                Throw ex
                            End Try
                        End If
                    Else    'Sử dụng LDAP để lưu mật khẩu
                        v_strRetval = v_strBranchId & "|" & v_strTellerId
                    End If
                End If
            Else
                v_strRetval = Nothing
            End If

            Complete() 'ContextUtil.SetComplete()

            Return v_strRetval
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Public Function GetTellerProfile(ByVal BrachId As String, ByVal TellerId As String) As CTellerProfile
        Dim tlProfile As New CTellerProfile
        Dim v_strObjMsg As String
        Dim v_XmlDocument As New Xml.XmlDocument
        Dim v_strTLTYPE, v_strGRPTYPE, v_strMaxType As String

        Dim v_obj As New DataAccess
        v_obj.NewDBInstance(gc_MODULE_HOST)

        Dim v_strSQL As String = "Select P.BRID BDSID, P.TLID TLID, B.BRNAME BRNAME, P.DESCRIPTION DESCRIPTION, P.TLTYPE TLTYPE, " _
            & "P.TLGROUP TLGROUP, P.TLID TLID, P.TLLEV TLLEV, P.TLNAME TLNAME, P.TLPRN TLPRN, P.TLTITLE TLTITLE, P.TLFULLNAME TLFULLNAME, P.PIN PIN, " _
            & " (SELECT MAX(SUBSTR(GRPRIGHT,1,1)) || MAX(SUBSTR(GRPRIGHT,2,1)) || MAX(SUBSTR(GRPRIGHT,3,1)) || MAX(SUBSTR(GRPRIGHT,4,1)) GRPRIGHT " _
            & " FROM TLPROFILES TL, TLGROUPS GRP, TLGRPUSERS TLGRP " _
            & " WHERE  TL.TLID = TLGRP.TLID AND GRP.GRPID = TLGRP.GRPID  AND TL.TLID = '" & TellerId & "') GRPRIGHT " _
            & "from BRGRP B, TLPROFILES P " _
            & "where B.BRID = P.BRID and P.BRID = '" & BrachId & "' and P.TLID = '" & TellerId & "'"

        Dim v_bCmd As New BusinessCommand
        v_bCmd.ExecuteUser = "minhtk"
        v_bCmd.SQLCommand = v_strSQL

        Dim v_dal As New DataAccess
        v_dal.NewDBInstance(gc_MODULE_HOST)
        Dim v_strBUSDATE, v_strNEXTDATE, v_strINTERVAL, v_strSYSVAR, v_strTIMESEARCH, v_strCOMPANYCD, v_strCOMPANYNAME As String, v_lngError As Long
        v_lngError = v_dal.GetSysVar("SYSTEM", "CURRDATE", v_strBUSDATE)
        v_lngError = v_dal.GetSysVar("SYSTEM", "NEXTDATE", v_strNEXTDATE)
        v_lngError = v_dal.GetSysVar("SYSTEM", "TLLOGINTERVAL", v_strINTERVAL)
        v_lngError = v_dal.GetSysVar("SYSTEM", "TIMESEARCH", v_strTIMESEARCH)
        v_lngError = v_dal.GetSysVar("SYSTEM", "HEADOFFICE", v_strCOMPANYNAME)
        v_lngError = v_dal.GetSysVar("SYSTEM", "DEALINGCUSTODYCD", v_strCOMPANYCD)
        v_strCOMPANYCD = v_strCOMPANYCD.Replace("P", String.Empty)
        v_dal.LogCommand = True

        Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)

        'Dim v_ds As DataSet = OracleHelper.ExecuteDataset(mv_strConnectionString, CommandType.Text, v_strSQL)

        If v_ds.Tables(0).Rows.Count = 1 Then
            tlProfile.BranchId = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BDSID"))
            BranchID = tlProfile.BranchId
            tlProfile.BranchName = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("BRNAME"))
            tlProfile.Description = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("DESCRIPTION"))
            v_strGRPTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLTYPE"))
            v_strTLTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("GRPRIGHT"))
            v_strMaxType = ""
            If Trim(v_strGRPTYPE).Length >= 4 Then
                If Mid(v_strGRPTYPE, 1, 1) > Mid(v_strTLTYPE, 1, 1) Then
                    v_strMaxType &= Mid(v_strGRPTYPE, 1, 1)
                Else
                    v_strMaxType &= Mid(v_strTLTYPE, 1, 1)
                End If
                If Mid(v_strGRPTYPE, 2, 1) > Mid(v_strTLTYPE, 2, 1) Then
                    v_strMaxType &= Mid(v_strGRPTYPE, 2, 1)
                Else
                    v_strMaxType &= Mid(v_strTLTYPE, 2, 1)
                End If
                If Mid(v_strGRPTYPE, 3, 1) > Mid(v_strTLTYPE, 3, 1) Then
                    v_strMaxType &= Mid(v_strGRPTYPE, 3, 1)
                Else
                    v_strMaxType &= Mid(v_strTLTYPE, 3, 1)
                End If
                If Mid(v_strGRPTYPE, 4, 1) > Mid(v_strTLTYPE, 4, 1) Then
                    v_strMaxType &= Mid(v_strGRPTYPE, 4, 1)
                Else
                    v_strMaxType &= Mid(v_strTLTYPE, 4, 1)
                End If
                v_strMaxType &= Mid(v_strTLTYPE, 5)
            End If
            'tlProfile.TellerRight = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLTYPE"))
            tlProfile.TellerRight = v_strMaxType
            tlProfile.TellerGroup = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLGROUP"))
            tlProfile.TellerId = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLID"))
            tlProfile.TellerLevel = gf_CorrectNumericField(v_ds.Tables(0).Rows(0)("TLLEV"))
            tlProfile.TellerName = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLNAME"))
            tlProfile.TellerFullName = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLFULLNAME"))
            tlProfile.TellerPrinterName = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLPRN"))
            tlProfile.TellerTitle = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("TLTITLE"))
            tlProfile.Password = gf_CorrectStringField(v_ds.Tables(0).Rows(0)("PIN"))
            tlProfile.BusDate = v_strBUSDATE
            tlProfile.NextDate = v_strNEXTDATE
            tlProfile.Interval = v_strINTERVAL
            tlProfile.TimeSearch = v_strTIMESEARCH
            tlProfile.CompanyName = v_strCOMPANYNAME
            tlProfile.CompanyCode = v_strCOMPANYCD

        End If


        'Get system time form database HOST
        v_strObjMsg = modCommond.BuildXMLObjMsg(Now.Date, tlProfile.BranchId, Now.Date,
            tlProfile.TellerId, modCommond.gc_IsLocalMsg, modCommond.gc_MsgTypeObj,
            OBJNAME_SY_AUTHENTICATION, modCommond.gc_ActionInquiry, , tlProfile.TellerId, "GetSystemTime", , , "")

        v_XmlDocument.LoadXml(v_strObjMsg)

        Dim v_strLoginTime As String = Trim(v_XmlDocument.DocumentElement.Attributes(gc_AtributeCLAUSE).Value.ToString)
        tlProfile.LoginTime = v_strLoginTime


        Complete() 'ContextUtil.SetComplete()
        Return tlProfile
    End Function

    Public Function GetFunctionsByTellerId(ByVal TellerId As String) As DataSet
        Dim v_strSQL As String

        v_strSQL = "Select A.CMDCODE CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME " _
            & "from CMDMENU M, CMDAUTH A " _
            & "where M.CMDID = A.CMDCODE and A.CMDTYPE = 'M' and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
            & "and A.AUTHID = '" & TellerId & "' " _
            & "order by A.CMDCODE"

        Dim v_bCmd As New BusinessCommand
        v_bCmd.ExecuteUser = "minhtk"
        v_bCmd.SQLCommand = v_strSQL

        Dim v_dal As New DataAccess
        v_dal.NewDBInstance(gc_MODULE_HOST)
        v_dal.LogCommand = True

        Dim v_ds As DataSet = v_dal.ExecuteSQLReturnDataset(v_bCmd)

        Complete() 'ContextUtil.SetComplete()
        Return v_ds
    End Function

    Public Function GetUserParentMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strHashValue As String
        Dim hUsrFuncFilter As New Hashtable
        Dim hFuncFilter As New Hashtable
        Dim h_arrGrpFuncFilter() As Hashtable
        Dim v_strCMDCODE, v_strPRID, v_strCMDNAME, v_strEN_CMDNAME, v_strIMGINDEX, v_strMODCODE, v_strOBJNAME, v_strMENUTYPE As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_DataAccess As New DataAccess
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user
            v_strTellerId = Trim(v_strTellerId)
            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                                        & "from CMDMENU M " _
                                        & "where M.LEV = 1 " _
                                        & "order by M.CMDID"
            Else
                v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                                        & "from CMDMENU M, CMDAUTH A " _
                                        & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' " _
                                        & "and A.AUTHID = '" & v_strTellerId & "' and M.LEV = 1 " _
                                        & "order by M.CMDID"
            End If


            Dim v_dsUsr As DataSet
            'Dim v_objUsr As New DataAccess
            v_dsUsr = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("CMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDCODE"))
                    v_strPRID = IIf(v_dsUsr.Tables(0).Rows(i)("PRID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PRID"))
                    v_strCMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDNAME"))
                    v_strEN_CMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("IMGINDEX") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))
                    v_strMODCODE = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strOBJNAME = IIf(v_dsUsr.Tables(0).Rows(i)("OBJNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("OBJNAME"))
                    v_strMENUTYPE = IIf(v_dsUsr.Tables(0).Rows(i)("MENUTYPE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MENUTYPE"))
                    'Add new value to User hash table
                    v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE
                    If Not hUsrFuncFilter.ContainsKey(v_strCMDCODE) Then
                        hUsrFuncFilter.Add(v_strCMDCODE, v_strHashValue)
                    End If
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            'Dim v_objGrp As New DataAccess
            v_dsGrp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpFuncFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                                            & "from CMDMENU M, CMDAUTH A " _
                                            & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' " _
                                            & "and A.AUTHID = '" & v_strGrpId & "' and M.LEV = 1 " _
                                            & "order by M.CMDID"

                    Dim v_dsGrpRight As DataSet
                    'Dim v_objGrpRight As New DataAccess
                    v_dsGrpRight = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpFuncFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDCODE"))
                            v_strPRID = IIf(v_dsGrpRight.Tables(0).Rows(j)("PRID") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("PRID"))
                            v_strCMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDNAME"))
                            v_strEN_CMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            v_strMODCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strOBJNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("OBJNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("OBJNAME"))
                            v_strMENUTYPE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE"))
                            'Add new value to User hash table
                            v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE
                            If Not hGrpFilter.ContainsKey(v_strCMDCODE) Then
                                hGrpFilter.Add(v_strCMDCODE, v_strHashValue)
                            End If
                        Next
                    End If
                    h_arrGrpFuncFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT CMDID FROM CMDMENU WHERE LEV = '1' order by CMDID"
            Dim v_dsCmdid As DataSet
            'Dim v_objCmdid As New DataAccess
            v_dsCmdid = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrCMDID() As String
            If v_dsCmdid.Tables(0).Rows.Count > 0 Then
                v_intNumFunc = v_dsCmdid.Tables(0).Rows.Count
                ReDim v_arrCMDID(v_intNumFunc - 1)
                For i As Integer = 0 To v_intNumFunc - 1
                    v_arrCMDID(i) = IIf(v_dsCmdid.Tables(0).Rows(i)("CMDID") Is DBNull.Value, "", v_dsCmdid.Tables(0).Rows(i)("CMDID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("CMDCODE")
            v_dsFunc.Tables(0).Columns.Add("PRID")
            v_dsFunc.Tables(0).Columns.Add("CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("EN_CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("IMGINDEX")
            v_dsFunc.Tables(0).Columns.Add("MODCODE")
            v_dsFunc.Tables(0).Columns.Add("OBJNAME")
            v_dsFunc.Tables(0).Columns.Add("MENUTYPE")

            Dim v_arrFunc() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group

            For i As Integer = 0 To v_intNumFunc - 1
                If Not hUsrFuncFilter(v_arrCMDID(i)) Is Nothing Then
                    'Get data of row
                    v_arrFunc = CStr(hUsrFuncFilter(v_arrCMDID(i))).Split("|")
                    'Add right of user to dataset
                    v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                    'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                Else
                    'Check right of groups
                    If v_intNumGrp > 0 Then
                        For j As Integer = 0 To v_intNumGrp - 1
                            If Not h_arrGrpFuncFilter(j)(v_arrCMDID(i)) Is Nothing Then
                                'Get data of row
                                v_arrFunc = CStr(h_arrGrpFuncFilter(j)(v_arrCMDID(i))).Split("|")
                                'Add right of user to dataset
                                v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next

            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)
            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Public Function GetUserAdjustMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strHashValue As String
        Dim hUsrFuncFilter As New Hashtable
        Dim hFuncFilter As New Hashtable
        Dim h_arrGrpFuncFilter() As Hashtable
        Dim v_strCMDCODE, v_strPRID, v_strCMDNAME, v_strREFCMDCODE, v_strEN_CMDNAME, v_strIMGINDEX, v_strMODCODE, v_strOBJNAME, v_strMENUTYPE, v_strLAST, v_strAUTHCODE, v_strAUTH As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_DataAccess As New DataAccess
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user
            v_strTellerId = Trim(v_strTellerId)
            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "Select AM.CMDID CMDCODE, AM.PRID PRID,  " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME  " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description  " & ControlChars.CrLf _
                            & "            else AM.CMDNAME end CMDNAME,  " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME  " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description " & ControlChars.CrLf _
                            & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,   " & ControlChars.CrLf _
                            & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX, " & ControlChars.CrLf _
                            & "         case when AM.menutype = 'M' then M.modcode when AM.menutype = 'T' then T.modcode when AM.menutype ='G' then G.modcode when AM.menutype ='R' then R.modcode else M.MODCODE end MODCODE, M.OBJNAME OBJNAME,  " & ControlChars.CrLf _
                            & "         case when AM.menutype in ('T','G','R','P') then AM.menutype else M.MENUTYPE end MENUTYPE, " & ControlChars.CrLf _
                            & "         M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH,  " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid when AM.menutype = 'T' then T.TLTXCD when AM.menutype = 'R' then R.RPTID when AM.menutype = 'G' then G.RPTID else AM.cmdid end REFCMDCODE    " & ControlChars.CrLf _
                            & "     from ADJUSTMENU AM, CMDMENU M, (select appmodules.modcode, tltx.* from appmodules, tltx where appmodules.txcode = substr(tltx.tltxcd,1,2)) T,  " & ControlChars.CrLf _
                            & "            (select * from RPTMASTER where cmdtype = 'R' and visible = 'Y') R,  " & ControlChars.CrLf _
                            & "            (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*  " & ControlChars.CrLf _
                            & "                from RPTMASTER G, search s  " & ControlChars.CrLf _
                            & "                where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y') G " & ControlChars.CrLf _
                            & "     where AM.LEV = 1 " & ControlChars.CrLf _
                            & "        and AM.menucode = M.cmdid(+)  " & ControlChars.CrLf _
                            & "        and AM.menucode = T.tltxcd(+)  " & ControlChars.CrLf _
                            & "        and AM.menucode = g.gvid(+)  " & ControlChars.CrLf _
                            & "        and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                            & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                            & "            ) " & ControlChars.CrLf _
                            & "order by AM.cmdid "
            Else
                v_strSQL = "select AM.CMDID CMDCODE, AM.PRID PRID,  " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME  " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC    " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description   " & ControlChars.CrLf _
                            & "            else AM.CMDNAME end CMDNAME,   " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC    " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description  " & ControlChars.CrLf _
                            & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,    " & ControlChars.CrLf _
                            & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX,  " & ControlChars.CrLf _
                            & "         case when AM.menutype = 'M' then M.modcode when AM.menutype = 'T' then T.modcode when AM.menutype ='G' then G.modcode when AM.menutype ='R' then R.modcode else M.MODCODE end MODCODE, M.OBJNAME OBJNAME,  " & ControlChars.CrLf _
                            & "         case when AM.menutype in ('T','G','R','P') then AM.menutype else M.MENUTYPE end MENUTYPE,  " & ControlChars.CrLf _
                            & "         M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH,   " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid when AM.menutype = 'T' then T.TLTXCD when AM.menutype = 'R' then R.RPTID when AM.menutype = 'G' then G.RPTID else AM.cmdid end REFCMDCODE " & ControlChars.CrLf _
                            & "from ADJUSTMENU AM,  " & ControlChars.CrLf _
                            & "    (Select M.*  " & ControlChars.CrLf _
                            & "        from CMDMENU M, CMDAUTH A  " & ControlChars.CrLf _
                            & "        where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strTellerId & "') M, " & ControlChars.CrLf _
                            & "    (select appmodules.modcode,tl.cmdallow, tltx.*  " & ControlChars.CrLf _
                            & "        from appmodules, tltx, cmdauth tl  " & ControlChars.CrLf _
                            & "                where appmodules.txcode = substr(TLTX.tltxcd, 1, 2) " & ControlChars.CrLf _
                            & "         AND tltx.DIRECT='Y' and tltx.tltxcd = tl.cmdcode and tl.cmdtype = 'T' and tl.authtype = 'U' and tl.AUTHID = '" & v_strTellerId & "' AND tl.CMDALLOW = 'Y') T,   " & ControlChars.CrLf _
                            & "    (select R.*  " & ControlChars.CrLf _
                            & "        from RPTMASTER R, CMDAUTH A " & ControlChars.CrLf _
                            & "        where R.cmdtype = 'R' and R.visible = 'Y' " & ControlChars.CrLf _
                            & "        AND R.RPTID = A.cmdcode and A.cmdtype = 'R' " & ControlChars.CrLf _
                            & "        and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strTellerId & "') R,   " & ControlChars.CrLf _
                            & "    (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*   " & ControlChars.CrLf _
                            & "        from RPTMASTER G, search s, CMDAUTH A   " & ControlChars.CrLf _
                            & "        where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y' " & ControlChars.CrLf _
                            & "        AND G.RPTID = A.cmdcode and A.cmdtype = 'G' " & ControlChars.CrLf _
                            & "        and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strTellerId & "') G   " & ControlChars.CrLf _
                            & "where AM.LEV = 1  " & ControlChars.CrLf _
                            & "    and AM.menucode = M.cmdid(+)   " & ControlChars.CrLf _
                            & "    and AM.menucode = T.tltxcd(+)  " & ControlChars.CrLf _
                            & "    and AM.menucode = g.gvid(+)   " & ControlChars.CrLf _
                            & "    and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                            & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                            & "            ) " & ControlChars.CrLf _
                            & "order by AM.CMDID"
            End If


            Dim v_dsUsr As DataSet
            'Dim v_objUsr As New DataAccess
            'v_objUsr.NewDBInstance(gc_MODULE_HOST)
            v_dsUsr = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strREFCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("REFCMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("REFCMDCODE"))
                    v_strCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("CMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDCODE"))
                    v_strPRID = IIf(v_dsUsr.Tables(0).Rows(i)("PRID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PRID"))
                    v_strCMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDNAME"))
                    v_strEN_CMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("IMGINDEX") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))
                    v_strMODCODE = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strOBJNAME = IIf(v_dsUsr.Tables(0).Rows(i)("OBJNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("OBJNAME"))
                    v_strMENUTYPE = IIf(v_dsUsr.Tables(0).Rows(i)("MENUTYPE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MENUTYPE"))
                    v_strLAST = IIf(v_dsUsr.Tables(0).Rows(i)("LAST") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("LAST"))
                    v_strAUTHCODE = IIf(v_dsUsr.Tables(0).Rows(i)("AUTHCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AUTHCODE"))
                    v_strAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    'Add new value to User hash table
                    v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strREFCMDCODE & "|" & v_strLAST & "|" & v_strAUTHCODE & "|" & v_strAUTH
                    If Not hUsrFuncFilter.ContainsKey(v_strCMDCODE) Then
                        hUsrFuncFilter.Add(v_strCMDCODE, v_strHashValue)
                    End If
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            'Dim v_objGrp As New DataAccess
            'v_objGrp.NewDBInstance(gc_MODULE_HOST)
            v_dsGrp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpFuncFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    'v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, 0 IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE " _
                    '                        & "from CMDMENU M, CMDAUTH A " _
                    '                        & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' " _
                    '                        & "and A.AUTHID = '" & v_strGrpId & "' and M.LEV = 1 " _
                    '                        & "order by M.CMDID"
                    v_strSQL = "select AM.CMDID CMDCODE, AM.PRID PRID,  " & ControlChars.CrLf _
                                & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME  " & ControlChars.CrLf _
                                & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC    " & ControlChars.CrLf _
                                & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description   " & ControlChars.CrLf _
                                & "            else AM.CMDNAME end CMDNAME,   " & ControlChars.CrLf _
                                & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC    " & ControlChars.CrLf _
                                & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description  " & ControlChars.CrLf _
                                & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,    " & ControlChars.CrLf _
                                & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX,  " & ControlChars.CrLf _
                                & "         case when AM.menutype = 'M' then M.modcode when AM.menutype = 'T' then T.modcode when AM.menutype ='G' then G.modcode when AM.menutype ='R' then R.modcode else M.MODCODE end MODCODE, M.OBJNAME OBJNAME,  " & ControlChars.CrLf _
                                & "         case when AM.menutype in ('T','G','R','P') then AM.menutype else M.MENUTYPE end MENUTYPE,  " & ControlChars.CrLf _
                                & "         M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH,   " & ControlChars.CrLf _
                                & "            case when AM.menutype = 'M' then M.cmdid when AM.menutype = 'T' then T.TLTXCD when AM.menutype = 'R' then R.RPTID when AM.menutype = 'G' then G.RPTID else AM.cmdid end REFCMDCODE  " & ControlChars.CrLf _
                                & "from ADJUSTMENU AM,  " & ControlChars.CrLf _
                                & "    (Select M.*  " & ControlChars.CrLf _
                                & "        from CMDMENU M, CMDAUTH A  " & ControlChars.CrLf _
                                & "        where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strGrpId & "') M, " & ControlChars.CrLf _
                                & "    (select appmodules.modcode,tl.cmdallow, tltx.*  " & ControlChars.CrLf _
                                & "        from appmodules, tltx, cmdauth tl  " & ControlChars.CrLf _
                                & "                where appmodules.txcode = substr(TLTX.tltxcd, 1, 2) " & ControlChars.CrLf _
                                & "         AND tltx.DIRECT='Y' and tltx.tltxcd = tl.cmdcode and tl.cmdtype = 'T' and tl.authtype = 'G' and tl.AUTHID = '" & v_strGrpId & "' AND tl.CMDALLOW = 'Y') T,   " & ControlChars.CrLf _
                                & "    (select R.*  " & ControlChars.CrLf _
                                & "        from RPTMASTER R, CMDAUTH A " & ControlChars.CrLf _
                                & "        where R.cmdtype = 'R' and R.visible = 'Y' " & ControlChars.CrLf _
                                & "        AND R.RPTID = A.cmdcode and A.cmdtype = 'R' " & ControlChars.CrLf _
                                & "        and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strGrpId & "') R,   " & ControlChars.CrLf _
                                & "    (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*   " & ControlChars.CrLf _
                                & "        from RPTMASTER G, search s, CMDAUTH A   " & ControlChars.CrLf _
                                & "        where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y' " & ControlChars.CrLf _
                                & "        AND G.RPTID = A.cmdcode and A.cmdtype = 'G' " & ControlChars.CrLf _
                                & "        and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strGrpId & "') G   " & ControlChars.CrLf _
                                & "where AM.LEV = 1  " & ControlChars.CrLf _
                                & "    and AM.menucode = M.cmdid(+)   " & ControlChars.CrLf _
                                & "    and AM.menucode = T.tltxcd(+)  " & ControlChars.CrLf _
                                & "    and AM.menucode = g.gvid(+)   " & ControlChars.CrLf _
                                & "    and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                                & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                                & "            ) " & ControlChars.CrLf _
                                & "order by AM.CMDID"

                    Dim v_dsGrpRight As DataSet
                    'Dim v_objGrpRight As New DataAccess
                    'v_objGrpRight.NewDBInstance(gc_MODULE_HOST)
                    v_dsGrpRight = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpFuncFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strREFCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("REFCMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("REFCMDCODE"))
                            v_strCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDCODE"))
                            v_strPRID = IIf(v_dsGrpRight.Tables(0).Rows(j)("PRID") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("PRID"))
                            v_strCMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDNAME"))
                            v_strEN_CMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            v_strMODCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strOBJNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("OBJNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("OBJNAME"))
                            v_strMENUTYPE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE"))
                            v_strLAST = IIf(v_dsGrpRight.Tables(0).Rows(j)("LAST") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("LAST"))
                            v_strAUTHCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE"))
                            v_strAUTH = IIf(v_dsGrpRight.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("STRAUTH"))
                            'Add new value to User hash table
                            v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strREFCMDCODE & "|" & v_strLAST & "|" & v_strAUTHCODE & "|" & v_strAUTH
                            If Not hGrpFilter.ContainsKey(v_strCMDCODE) Then
                                hGrpFilter.Add(v_strCMDCODE, v_strHashValue)
                            End If
                        Next
                    End If
                    h_arrGrpFuncFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT CMDID FROM ADJUSTMENU WHERE LEV = '1' order by CMDID"
            Dim v_dsCmdid As DataSet
            'Dim v_objCmdid As New DataAccess
            'v_objCmdid.NewDBInstance(gc_MODULE_HOST)
            v_dsCmdid = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrCMDID() As String
            If v_dsCmdid.Tables(0).Rows.Count > 0 Then
                v_intNumFunc = v_dsCmdid.Tables(0).Rows.Count
                ReDim v_arrCMDID(v_intNumFunc - 1)
                For i As Integer = 0 To v_intNumFunc - 1
                    v_arrCMDID(i) = IIf(v_dsCmdid.Tables(0).Rows(i)("CMDID") Is DBNull.Value, "", v_dsCmdid.Tables(0).Rows(i)("CMDID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("CMDCODE")
            v_dsFunc.Tables(0).Columns.Add("PRID")
            v_dsFunc.Tables(0).Columns.Add("CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("EN_CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("IMGINDEX")
            v_dsFunc.Tables(0).Columns.Add("MODCODE")
            v_dsFunc.Tables(0).Columns.Add("OBJNAME")
            v_dsFunc.Tables(0).Columns.Add("MENUTYPE")
            v_dsFunc.Tables(0).Columns.Add("REFCMDCODE")
            v_dsFunc.Tables(0).Columns.Add("LAST")
            v_dsFunc.Tables(0).Columns.Add("AUTHCODE")
            v_dsFunc.Tables(0).Columns.Add("STRAUTH")

            Dim v_arrFunc() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group

            For i As Integer = 0 To v_intNumFunc - 1
                If Not hUsrFuncFilter(v_arrCMDID(i)) Is Nothing Then
                    'Get data of row
                    v_arrFunc = CStr(hUsrFuncFilter(v_arrCMDID(i))).Split("|")
                    'Add right of user to dataset
                    v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                    'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                Else
                    'Check right of groups
                    If v_intNumGrp > 0 Then
                        For j As Integer = 0 To v_intNumGrp - 1
                            If Not h_arrGrpFuncFilter(j)(v_arrCMDID(i)) Is Nothing Then
                                'Get data of row
                                v_arrFunc = CStr(h_arrGrpFuncFilter(j)(v_arrCMDID(i))).Split("|")
                                'Add right of user to dataset
                                v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next

            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)
            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Public Function GetAuthForLookup(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strArr(), v_strTellerId, v_strParentKey, v_strHashValue As String
        Dim hUsrFuncFilter As New Hashtable
        Dim hFuncFilter As New Hashtable
        Dim h_arrGrpFuncFilter() As Hashtable
        Dim v_strCMDCODE, v_strPRID, v_strCMDNAME, v_strEN_CMDNAME, v_strLAST, v_strIMGINDEX, v_strMODCODE, v_strOBJNAME, v_strMENUTYPE, v_strAUTHCODE, v_strAUTH As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_DataAccess As New DataAccess
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            v_strArr = v_strClause.Split("|")
            If v_strArr.Length = 2 Then
                v_strTellerId = Trim(v_strArr(0))
                v_strParentKey = Trim(v_strArr(1))
            End If

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user

            v_strSQL = "Select A.CMDCODE CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LAST LAST, " _
                & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                & "M.AUTHCODE AUTHCODE, A.STRAUTH STRAUTH " _
                & "from CMDMENU M, CMDAUTH A " _
                & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDTYPE = 'M' and A.CMDALLOW = 'Y' " _
                & "and A.AUTHID = '" & v_strTellerId & "' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                & "order by A.CMDCODE"

            Dim v_dsUsr As DataSet
            'Dim v_objUsr As New DataAccess
            'v_objUsr.NewDBInstance(gc_MODULE_HOST)
            v_dsUsr = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("CMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDCODE"))
                    v_strPRID = IIf(v_dsUsr.Tables(0).Rows(i)("PRID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PRID"))
                    v_strCMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDNAME"))
                    v_strEN_CMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME"))
                    v_strLAST = IIf(v_dsUsr.Tables(0).Rows(i)("LAST") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("LAST"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("IMGINDEX") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))
                    v_strMODCODE = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strOBJNAME = IIf(v_dsUsr.Tables(0).Rows(i)("OBJNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("OBJNAME"))
                    v_strMENUTYPE = IIf(v_dsUsr.Tables(0).Rows(i)("MENUTYPE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MENUTYPE"))
                    v_strAUTHCODE = IIf(v_dsUsr.Tables(0).Rows(i)("AUTHCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AUTHCODE"))
                    v_strAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    'Add new value to User hash table
                    v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strLAST & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strAUTHCODE & "|" & v_strAUTH
                    hUsrFuncFilter.Add(v_strCMDCODE, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            Dim v_dsGrp As DataSet
            'Dim v_objGrp As New DataAccess
            'v_objGrp.NewDBInstance(gc_MODULE_HOST)
            v_dsGrp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpFuncFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "Select A.CMDCODE CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LAST LAST, " _
                                & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                                & "M.AUTHCODE AUTHCODE, A.STRAUTH STRAUTH " _
                                & "from CMDMENU M, CMDAUTH A " _
                                & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDTYPE = 'M' and A.CMDALLOW = 'Y' " _
                                & "and A.AUTHID = '" & v_strGrpId & "' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                                & "order by A.CMDCODE"

                    Dim v_dsGrpRight As DataSet
                    'Dim v_objGrpRight As New DataAccess
                    v_dsGrpRight = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpFuncFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDCODE"))
                            v_strPRID = IIf(v_dsGrpRight.Tables(0).Rows(j)("PRID") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("PRID"))
                            v_strCMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDNAME"))
                            v_strEN_CMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME"))
                            v_strLAST = IIf(v_dsGrpRight.Tables(0).Rows(j)("LAST") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("LAST"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            v_strMODCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strOBJNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("OBJNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("OBJNAME"))
                            v_strMENUTYPE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE"))
                            v_strAUTHCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE"))
                            v_strAUTH = IIf(v_dsGrpRight.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("STRAUTH"))
                            'Add new value to User hash table
                            v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strLAST & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strAUTHCODE & "|" & v_strAUTH
                            hGrpFilter.Add(v_strCMDCODE, v_strHashValue)
                        Next
                    End If
                    h_arrGrpFuncFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT CMDID FROM CMDMENU WHERE PRID = '" & v_strParentKey & "'"
            Dim v_dsCmdid As DataSet
            'Dim v_objCmdid As New DataAccess
            'v_objCmdid.NewDBInstance(gc_MODULE_HOST)
            v_dsCmdid = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrCMDID() As String
            If v_dsCmdid.Tables(0).Rows.Count > 0 Then
                v_intNumFunc = v_dsCmdid.Tables(0).Rows.Count
                ReDim v_arrCMDID(v_intNumFunc - 1)
                For i As Integer = 0 To v_intNumFunc - 1
                    v_arrCMDID(i) = IIf(v_dsCmdid.Tables(0).Rows(i)("CMDID") Is DBNull.Value, "", v_dsCmdid.Tables(0).Rows(i)("CMDID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("CMDCODE")
            v_dsFunc.Tables(0).Columns.Add("PRID")
            v_dsFunc.Tables(0).Columns.Add("CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("EN_CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("LAST")
            v_dsFunc.Tables(0).Columns.Add("IMGINDEX")
            v_dsFunc.Tables(0).Columns.Add("MODCODE")
            v_dsFunc.Tables(0).Columns.Add("OBJNAME")
            v_dsFunc.Tables(0).Columns.Add("MENUTYPE")
            v_dsFunc.Tables(0).Columns.Add("AUTHCODE")
            v_dsFunc.Tables(0).Columns.Add("STRAUTH")

            Dim v_arrFunc() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group
            If v_intNumFunc > 0 Then
                For i As Integer = 0 To v_intNumFunc - 1
                    If Not hUsrFuncFilter(v_arrCMDID(i)) Is Nothing Then
                        'Get data of row
                        v_arrFunc = CStr(hUsrFuncFilter(v_arrCMDID(i))).Split("|")
                        'Add right of user to dataset
                        v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                        'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                    Else
                        'Check right of groups
                        If v_intNumGrp > 0 Then
                            Dim v_strAUTHSTR As String
                            Dim v_strInquiry, v_strAdd, v_strEdit, v_strDelete As String
                            Dim v_blnInquiry, v_blnAdd, v_blnEdit, v_blnDelete As Boolean
                            Dim v_blnPreInquiry, v_blnPreAdd, v_blnPreEdit, v_blnPreDelete As Boolean

                            v_blnPreInquiry = False
                            v_blnPreAdd = False
                            v_blnPreEdit = False
                            v_blnPreDelete = False

                            For j As Integer = 0 To v_intNumGrp - 1
                                If Not h_arrGrpFuncFilter(j)(v_arrCMDID(i)) Is Nothing Then
                                    'Get data of row
                                    v_arrFunc = CStr(h_arrGrpFuncFilter(j)(v_arrCMDID(i))).Split("|")
                                    v_strAUTHSTR = v_arrFunc(10)
                                    v_strInquiry = Mid(v_strAUTHSTR, 1, 1)
                                    v_strAdd = Mid(v_strAUTHSTR, 2, 1)
                                    v_strEdit = Mid(v_strAUTHSTR, 3, 1)
                                    v_strDelete = Mid(v_strAUTHSTR, 4, 1)

                                    v_blnInquiry = IIf(v_strInquiry = "Y", True, False)
                                    v_blnAdd = IIf(v_strAdd = "Y", True, False)
                                    v_blnEdit = IIf(v_strEdit = "Y", True, False)
                                    v_blnDelete = IIf(v_strDelete = "Y", True, False)

                                    'Combination right of groups
                                    v_blnInquiry = (v_blnInquiry Or v_blnPreInquiry)
                                    v_blnAdd = (v_blnAdd Or v_blnPreAdd)
                                    v_blnEdit = (v_blnEdit Or v_blnPreEdit)
                                    v_blnDelete = (v_blnDelete Or v_blnPreDelete)

                                    'Assign right to previous right
                                    v_blnPreInquiry = v_blnInquiry
                                    v_blnPreAdd = v_blnAdd
                                    v_blnPreEdit = v_blnEdit
                                    v_blnPreDelete = v_blnDelete
                                Else
                                    If Not v_arrFunc Is Nothing Then
                                        'v_arrFunc.s
                                        'ReDim v_arrFunc(0)
                                        v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                                    End If
                                End If
                            Next
                            'Get last right of groups
                            If Not v_arrFunc Is Nothing Then
                                If Not v_arrFunc.GetValue(0) Is Nothing Then
                                    v_strInquiry = IIf(v_blnInquiry = True, "Y", "N")
                                    v_strAdd = IIf(v_blnAdd = True, "Y", "N")
                                    v_strEdit = IIf(v_blnEdit = True, "Y", "N")
                                    v_strDelete = IIf(v_blnDelete = True, "Y", "N")
                                    v_strAUTHSTR = v_strInquiry & v_strAdd & v_strEdit & v_strDelete
                                    v_arrFunc(10) = v_strAUTHSTR

                                    'Add right of user to dataset
                                    v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                                End If
                            End If

                        End If
                    End If
                Next
            End If

            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Public Function GetUserChildMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strArr(), v_strTellerId, v_strParentKey, v_strHashValue As String
        Dim hUsrFuncFilter As New Hashtable
        Dim hFuncFilter As New Hashtable
        Dim h_arrGrpFuncFilter() As Hashtable
        Dim v_strCMDCODE, v_strPRID, v_strCMDNAME, v_strEN_CMDNAME, v_strLAST, v_strIMGINDEX, v_strMODCODE, v_strOBJNAME, v_strMENUTYPE, v_strAUTHCODE, v_strAUTH As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_DataAccess As New DataAccess
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)
        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            v_strArr = v_strClause.Split("|")
            If v_strArr.Length = 2 Then
                v_strTellerId = Trim(v_strArr(0))
                v_strParentKey = Trim(v_strArr(1))
            End If

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user

            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LAST LAST, " _
                                & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                                & "M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH " _
                                & "from CMDMENU M " _
                                & "where M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                                & "order by M.CMDID"
            Else
                v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LAST LAST, " _
                & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                & "M.AUTHCODE AUTHCODE, A.STRAUTH STRAUTH " _
                & "from CMDMENU M, CMDAUTH A " _
                & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDTYPE = 'M' and A.CMDALLOW = 'Y' " _
                & "and A.AUTHID = '" & v_strTellerId & "' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                & "order by M.CMDID"
            End If


            Dim v_dsUsr As DataSet
            'Dim v_objUsr As New DataAccess
            'v_objUsr.NewDBInstance(gc_MODULE_HOST)
            v_dsUsr = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("CMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDCODE"))
                    v_strPRID = IIf(v_dsUsr.Tables(0).Rows(i)("PRID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PRID"))
                    v_strCMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDNAME"))
                    v_strEN_CMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME"))
                    v_strLAST = IIf(v_dsUsr.Tables(0).Rows(i)("LAST") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("LAST"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("IMGINDEX") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))
                    v_strMODCODE = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strOBJNAME = IIf(v_dsUsr.Tables(0).Rows(i)("OBJNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("OBJNAME"))
                    v_strMENUTYPE = IIf(v_dsUsr.Tables(0).Rows(i)("MENUTYPE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MENUTYPE"))
                    v_strAUTHCODE = IIf(v_dsUsr.Tables(0).Rows(i)("AUTHCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AUTHCODE"))
                    v_strAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    'Add new value to User hash table
                    v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strLAST & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strAUTHCODE & "|" & v_strAUTH
                    hUsrFuncFilter.Add(v_strCMDCODE, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            'Dim v_objGrp As New DataAccess
            'v_objGrp.NewDBInstance(gc_MODULE_HOST)
            v_dsGrp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpFuncFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "Select M.CMDID CMDCODE, M.PRID PRID, M.CMDNAME CMDNAME, M.EN_CMDNAME EN_CMDNAME, M.LAST LAST, " _
                                & "decode(M.LAST, 'Y', 3, 'N', 0) IMGINDEX, M.MODCODE MODCODE, M.OBJNAME OBJNAME, M.MENUTYPE MENUTYPE, " _
                                & "M.AUTHCODE AUTHCODE, A.STRAUTH STRAUTH " _
                                & "from CMDMENU M, CMDAUTH A " _
                                & "where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDTYPE = 'M' and A.CMDALLOW = 'Y' " _
                                & "and A.AUTHID = '" & v_strGrpId & "' and M.LEV > 1 and M.PRID = '" & v_strParentKey & "' " _
                                & "order by M.CMDID"

                    Dim v_dsGrpRight As DataSet
                    'Dim v_objGrpRight As New DataAccess
                    v_dsGrpRight = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpFuncFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDCODE"))
                            v_strPRID = IIf(v_dsGrpRight.Tables(0).Rows(j)("PRID") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("PRID"))
                            v_strCMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDNAME"))
                            v_strEN_CMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME"))
                            v_strLAST = IIf(v_dsGrpRight.Tables(0).Rows(j)("LAST") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("LAST"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            v_strMODCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strOBJNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("OBJNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("OBJNAME"))
                            v_strMENUTYPE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE"))
                            v_strAUTHCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE"))
                            v_strAUTH = IIf(v_dsGrpRight.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("STRAUTH"))
                            'Add new value to User hash table
                            v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strLAST & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strAUTHCODE & "|" & v_strAUTH
                            hGrpFilter.Add(v_strCMDCODE, v_strHashValue)
                        Next
                    End If
                    h_arrGrpFuncFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT CMDID FROM CMDMENU WHERE PRID = '" & v_strParentKey & "' order by CMDID"
            Dim v_dsCmdid As DataSet
            'Dim v_objCmdid As New DataAccess
            'v_objCmdid.NewDBInstance(gc_MODULE_HOST)
            v_dsCmdid = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrCMDID() As String
            If v_dsCmdid.Tables(0).Rows.Count > 0 Then
                v_intNumFunc = v_dsCmdid.Tables(0).Rows.Count
                ReDim v_arrCMDID(v_intNumFunc - 1)
                For i As Integer = 0 To v_intNumFunc - 1
                    v_arrCMDID(i) = IIf(v_dsCmdid.Tables(0).Rows(i)("CMDID") Is DBNull.Value, "", v_dsCmdid.Tables(0).Rows(i)("CMDID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("CMDCODE")
            v_dsFunc.Tables(0).Columns.Add("PRID")
            v_dsFunc.Tables(0).Columns.Add("CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("EN_CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("LAST")
            v_dsFunc.Tables(0).Columns.Add("IMGINDEX")
            v_dsFunc.Tables(0).Columns.Add("MODCODE")
            v_dsFunc.Tables(0).Columns.Add("OBJNAME")
            v_dsFunc.Tables(0).Columns.Add("MENUTYPE")
            v_dsFunc.Tables(0).Columns.Add("AUTHCODE")
            v_dsFunc.Tables(0).Columns.Add("STRAUTH")

            Dim v_arrFunc() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group
            If v_intNumFunc > 0 Then
                For i As Integer = 0 To v_intNumFunc - 1
                    'If user has right of this function, do not check right of group
                    If Not hUsrFuncFilter(v_arrCMDID(i)) Is Nothing Then
                        'Get data of row
                        v_arrFunc = CStr(hUsrFuncFilter(v_arrCMDID(i))).Split("|")
                        'Add right of user to dataset
                        v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                        'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                    Else
                        'Check right of groups
                        If v_intNumGrp > 0 Then
                            Dim v_strAUTHSTR As String
                            Dim v_strInquiry, v_strAdd, v_strEdit, v_strDelete, v_strApprove As String
                            Dim v_blnInquiry, v_blnAdd, v_blnEdit, v_blnDelete, v_blnApprove As Boolean
                            Dim v_blnPreInquiry, v_blnPreAdd, v_blnPreEdit, v_blnPreDelete, v_blnPreApprove As Boolean

                            v_blnPreInquiry = False
                            v_blnPreAdd = False
                            v_blnPreEdit = False
                            v_blnPreDelete = False
                            v_blnPreApprove = False

                            If Not v_arrFunc Is Nothing Then
                                'v_arrFunc.s
                                'ReDim v_arrFunc(0)
                                v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                            End If

                            For j As Integer = 0 To v_intNumGrp - 1
                                If Not h_arrGrpFuncFilter(j)(v_arrCMDID(i)) Is Nothing Then
                                    'Get data of row
                                    v_arrFunc = CStr(h_arrGrpFuncFilter(j)(v_arrCMDID(i))).Split("|")
                                    v_strAUTHSTR = v_arrFunc(10)
                                    v_strInquiry = Mid(v_strAUTHSTR, 1, 1)
                                    v_strAdd = Mid(v_strAUTHSTR, 2, 1)
                                    v_strEdit = Mid(v_strAUTHSTR, 3, 1)
                                    v_strDelete = Mid(v_strAUTHSTR, 4, 1)
                                    v_strApprove = Mid(v_strAUTHSTR, 5, 1)

                                    v_blnInquiry = IIf(v_strInquiry = "Y", True, False)
                                    v_blnAdd = IIf(v_strAdd = "Y", True, False)
                                    v_blnEdit = IIf(v_strEdit = "Y", True, False)
                                    v_blnDelete = IIf(v_strDelete = "Y", True, False)
                                    v_blnApprove = IIf(v_strApprove = "Y", True, False)

                                    'Combination right of groups
                                    v_blnInquiry = (v_blnInquiry Or v_blnPreInquiry)
                                    v_blnAdd = (v_blnAdd Or v_blnPreAdd)
                                    v_blnEdit = (v_blnEdit Or v_blnPreEdit)
                                    v_blnDelete = (v_blnDelete Or v_blnPreDelete)
                                    v_blnApprove = (v_blnApprove Or v_blnPreApprove)

                                    'Assign right to previous right
                                    v_blnPreInquiry = v_blnInquiry
                                    v_blnPreAdd = v_blnAdd
                                    v_blnPreEdit = v_blnEdit
                                    v_blnPreDelete = v_blnDelete
                                    v_blnPreApprove = v_blnApprove
                                    'Else
                                    '    If Not v_arrFunc Is Nothing Then
                                    '        'v_arrFunc.s
                                    '        'ReDim v_arrFunc(0)
                                    '        v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                                    '    End If
                                End If
                            Next
                            'Get last right of groups
                            If Not v_arrFunc Is Nothing Then
                                If Not v_arrFunc.GetValue(0) Is Nothing Then
                                    v_strInquiry = IIf(v_blnInquiry = True, "Y", "N")
                                    v_strAdd = IIf(v_blnAdd = True, "Y", "N")
                                    v_strEdit = IIf(v_blnEdit = True, "Y", "N")
                                    v_strDelete = IIf(v_blnDelete = True, "Y", "N")
                                    v_strApprove = IIf(v_blnApprove = True, "Y", "N")
                                    v_strAUTHSTR = v_strInquiry & v_strAdd & v_strEdit & v_strDelete & v_strApprove
                                    v_arrFunc(10) = v_strAUTHSTR

                                    'Add right of user to dataset
                                    v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                                End If
                            End If

                        End If
                    End If
                Next
            End If


            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function GetUserChildAdjustMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_strArr(), v_strTellerId, v_strParentKey, v_strHashValue As String
        Dim hUsrFuncFilter As New Hashtable
        Dim hFuncFilter As New Hashtable
        Dim h_arrGrpFuncFilter() As Hashtable
        Dim v_strCMDCODE, v_strREFCMDCODE, v_strPRID, v_strCMDNAME, v_strEN_CMDNAME, v_strLAST, v_strIMGINDEX, v_strMODCODE, v_strOBJNAME, v_strMENUTYPE, v_strAUTHCODE, v_strAUTH As String
        Dim v_intNumGrp, v_intNumFunc As Integer
        Dim v_DataAccess As New DataAccess
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            v_strArr = v_strClause.Split("|")
            If v_strArr.Length = 2 Then
                v_strTellerId = Trim(v_strArr(0))
                v_strParentKey = Trim(v_strArr(1))
            End If

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user

            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "Select AM.CMDID CMDCODE, AM.PRID PRID,  " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME  " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description  " & ControlChars.CrLf _
                            & "            else AM.CMDNAME end CMDNAME,  " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME  " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description " & ControlChars.CrLf _
                            & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,   " & ControlChars.CrLf _
                            & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX, " & ControlChars.CrLf _
                            & "         case when AM.menutype = 'M' then M.modcode when AM.menutype = 'T' then T.modcode when AM.menutype ='G' then G.modcode when AM.menutype ='R' then R.modcode else M.MODCODE end MODCODE, M.OBJNAME OBJNAME,  " & ControlChars.CrLf _
                            & "         case when AM.menutype in ('T','G','R','P') then AM.menutype else M.MENUTYPE end MENUTYPE, " & ControlChars.CrLf _
                            & "         M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH,  " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid when AM.menutype = 'T' then T.TLTXCD when AM.menutype = 'R' then R.RPTID when AM.menutype = 'G' then G.RPTID else AM.cmdid end REFCMDCODE    " & ControlChars.CrLf _
                            & "     from ADJUSTMENU AM, CMDMENU M, (select appmodules.modcode, tltx.* from appmodules, tltx where appmodules.txcode = substr(tltx.tltxcd,1,2)) T,  " & ControlChars.CrLf _
                            & "            (select * from RPTMASTER where cmdtype = 'R' and visible = 'Y') R,  " & ControlChars.CrLf _
                            & "            (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*  " & ControlChars.CrLf _
                            & "                from RPTMASTER G, search s  " & ControlChars.CrLf _
                            & "                where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y') G " & ControlChars.CrLf _
                            & "     where AM.LEV > 1 and AM.PRID = '" & v_strParentKey & "'  " & ControlChars.CrLf _
                            & "        and AM.menucode = M.cmdid(+)  " & ControlChars.CrLf _
                            & "        and AM.menucode = T.tltxcd(+)  " & ControlChars.CrLf _
                            & "        and AM.menucode = g.gvid(+)  " & ControlChars.CrLf _
                            & "        and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                            & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                            & "            ) " & ControlChars.CrLf _
                            & "order by AM.cmdid "
            Else
                v_strSQL = "Select AM.CMDID CMDCODE, AM.PRID PRID,   " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC    " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description   " & ControlChars.CrLf _
                            & "            else AM.CMDNAME end CMDNAME,   " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC   " & ControlChars.CrLf _
                            & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description    " & ControlChars.CrLf _
                            & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description  " & ControlChars.CrLf _
                            & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,    " & ControlChars.CrLf _
                            & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX,  " & ControlChars.CrLf _
                            & "         case when AM.menutype = 'M' then M.modcode when AM.menutype = 'T' then T.modcode when AM.menutype ='G' then G.modcode when AM.menutype ='R' then R.modcode else M.MODCODE end MODCODE, M.OBJNAME OBJNAME,   " & ControlChars.CrLf _
                            & "         case when AM.menutype in ('T','G','R','P') then AM.menutype else M.MENUTYPE end MENUTYPE,  " & ControlChars.CrLf _
                            & "         M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH,   " & ControlChars.CrLf _
                            & "            case when AM.menutype = 'M' then M.cmdid when AM.menutype = 'T' then T.TLTXCD when AM.menutype = 'R' then R.RPTID when AM.menutype = 'G' then G.RPTID else AM.cmdid end REFCMDCODE    " & ControlChars.CrLf _
                            & "     from ADJUSTMENU AM,  " & ControlChars.CrLf _
                            & "            (Select M.*  " & ControlChars.CrLf _
                            & "                from CMDMENU M, CMDAUTH A  " & ControlChars.CrLf _
                            & "                where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strTellerId & "') M, " & ControlChars.CrLf _
                            & "            (select appmodules.modcode,tl.cmdallow, tltx.*  " & ControlChars.CrLf _
                            & "                from appmodules, tltx, cmdauth tl  " & ControlChars.CrLf _
                            & "                where appmodules.txcode = substr(TLTX.tltxcd, 1, 2) " & ControlChars.CrLf _
                            & "                AND tltx.DIRECT='Y' and tltx.tltxcd = tl.cmdcode and tl.cmdtype = 'T' and tl.authtype = 'U' and tl.AUTHID = '" & v_strTellerId & "' AND tl.CMDALLOW = 'Y') T,   " & ControlChars.CrLf _
                            & "            (select R.*  " & ControlChars.CrLf _
                            & "                from RPTMASTER R, CMDAUTH A " & ControlChars.CrLf _
                            & "                where R.cmdtype = 'R' and R.visible = 'Y' " & ControlChars.CrLf _
                            & "                AND R.RPTID = A.cmdcode and A.cmdtype = 'R' " & ControlChars.CrLf _
                            & "                and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strTellerId & "') R,   " & ControlChars.CrLf _
                            & "            (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*   " & ControlChars.CrLf _
                            & "                from RPTMASTER G, search s, CMDAUTH A   " & ControlChars.CrLf _
                            & "                where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y' " & ControlChars.CrLf _
                            & "                AND G.RPTID = A.cmdcode and A.cmdtype = 'G' " & ControlChars.CrLf _
                            & "                and A.AUTHTYPE = 'U' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strTellerId & "') G  " & ControlChars.CrLf _
                            & "     where AM.LEV > 1 and AM.PRID = '" & v_strParentKey & "'   " & ControlChars.CrLf _
                            & "        and AM.menucode = M.cmdid(+)   " & ControlChars.CrLf _
                            & "        and AM.menucode = T.tltxcd(+)   " & ControlChars.CrLf _
                            & "        and AM.menucode = g.gvid(+)   " & ControlChars.CrLf _
                            & "        and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                            & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                            & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                            & "            ) " & ControlChars.CrLf _
                            & "    order by AM.CMDID "
            End If


            Dim v_dsUsr As DataSet
            'Dim v_objUsr As New DataAccess
            'v_objUsr.NewDBInstance(gc_MODULE_HOST)
            v_dsUsr = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strREFCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("REFCMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("REFCMDCODE"))
                    v_strCMDCODE = IIf(v_dsUsr.Tables(0).Rows(i)("CMDCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDCODE"))
                    v_strPRID = IIf(v_dsUsr.Tables(0).Rows(i)("PRID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PRID"))
                    v_strCMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDNAME"))
                    v_strEN_CMDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_CMDNAME"))
                    v_strLAST = IIf(v_dsUsr.Tables(0).Rows(i)("LAST") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("LAST"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("IMGINDEX") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))
                    v_strMODCODE = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strOBJNAME = IIf(v_dsUsr.Tables(0).Rows(i)("OBJNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("OBJNAME"))
                    v_strMENUTYPE = IIf(v_dsUsr.Tables(0).Rows(i)("MENUTYPE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MENUTYPE"))
                    v_strAUTHCODE = IIf(v_dsUsr.Tables(0).Rows(i)("AUTHCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AUTHCODE"))
                    v_strAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    'Add new value to User hash table
                    v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strLAST & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strAUTHCODE & "|" & v_strAUTH & "|" & v_strREFCMDCODE
                    hUsrFuncFilter.Add(v_strCMDCODE, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            'Dim v_objGrp As New DataAccess
            'v_objGrp.NewDBInstance(gc_MODULE_HOST)
            v_dsGrp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpFuncFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "Select AM.CMDID CMDCODE, AM.PRID PRID,   " & ControlChars.CrLf _
                                & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.CMDNAME   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'T' then '[Giao dịch] ' ||T.TLTXCD || ': ' || T.TXDESC    " & ControlChars.CrLf _
                                & "                when AM.menutype = 'R' then '[Báo cáo] ' ||R.RPTID || ': ' || R.description   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'G' then '[Tra cứu] ' ||G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.description   " & ControlChars.CrLf _
                                & "            else AM.CMDNAME end CMDNAME,   " & ControlChars.CrLf _
                                & "            case when AM.menutype = 'M' then M.cmdid || ': ' || M.EN_CMDNAME   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'T' then '[Transaction] ' || T.TLTXCD || ': ' || T.EN_TXDESC   " & ControlChars.CrLf _
                                & "                when AM.menutype = 'R' then '[Report] ' || R.RPTID || ': ' || R.en_description    " & ControlChars.CrLf _
                                & "                when AM.menutype = 'G' then '[GeneralView] ' || G.RPTID || '-' ||  case when g.tltxcd is null then 'VIEW' else g.tltxcd end || ': ' || G.en_description  " & ControlChars.CrLf _
                                & "            else AM.EN_CMDNAME end EN_CMDNAME, AM.LEV LEV, AM.LAST LAST,    " & ControlChars.CrLf _
                                & "         decode(AM.LAST, 'Y', 3, 'N', 1) IMGINDEX,  " & ControlChars.CrLf _
                                & "         case when AM.menutype = 'M' then M.modcode when AM.menutype = 'T' then T.modcode when AM.menutype ='G' then G.modcode when AM.menutype ='R' then R.modcode else M.MODCODE end MODCODE, M.OBJNAME OBJNAME,   " & ControlChars.CrLf _
                                & "         case when AM.menutype in ('T','G','R','P') then AM.menutype else M.MENUTYPE end MENUTYPE,  " & ControlChars.CrLf _
                                & "         M.AUTHCODE AUTHCODE, 'YYYYY' STRAUTH,   " & ControlChars.CrLf _
                                & "            case when AM.menutype = 'M' then M.cmdid when AM.menutype = 'T' then T.TLTXCD when AM.menutype = 'R' then R.RPTID when AM.menutype = 'G' then G.RPTID else AM.cmdid end REFCMDCODE    " & ControlChars.CrLf _
                                & "     from ADJUSTMENU AM,  " & ControlChars.CrLf _
                                & "            (Select M.*  " & ControlChars.CrLf _
                                & "                from CMDMENU M, CMDAUTH A  " & ControlChars.CrLf _
                                & "                where M.CMDID = A.CMDCODE and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strGrpId & "') M, " & ControlChars.CrLf _
                                & "            (select appmodules.modcode,tl.cmdallow, tltx.*  " & ControlChars.CrLf _
                                & "                from appmodules, tltx, cmdauth tl  " & ControlChars.CrLf _
                                & "                where appmodules.txcode = substr(TLTX.tltxcd, 1, 2) " & ControlChars.CrLf _
                                & "                AND tltx.DIRECT='Y' and tltx.tltxcd = tl.cmdcode and tl.cmdtype = 'T' and tl.authtype = 'G' and tl.AUTHID = '" & v_strGrpId & "' AND tl.CMDALLOW = 'Y') T,   " & ControlChars.CrLf _
                                & "            (select R.*  " & ControlChars.CrLf _
                                & "                from RPTMASTER R, CMDAUTH A " & ControlChars.CrLf _
                                & "                where R.cmdtype = 'R' and R.visible = 'Y' " & ControlChars.CrLf _
                                & "                AND R.RPTID = A.cmdcode and A.cmdtype = 'R' " & ControlChars.CrLf _
                                & "                and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strGrpId & "') R,   " & ControlChars.CrLf _
                                & "            (select g.rptid || '^' || (case when s.tltxcd is null then 'VIEW' else s.tltxcd end) gvid, s.tltxcd, g.*   " & ControlChars.CrLf _
                                & "                from RPTMASTER G, search s, CMDAUTH A   " & ControlChars.CrLf _
                                & "                where G.rptid = s.searchcode and G.cmdtype = 'V' and visible = 'Y' " & ControlChars.CrLf _
                                & "                AND G.RPTID = A.cmdcode and A.cmdtype = 'G' " & ControlChars.CrLf _
                                & "                and A.AUTHTYPE = 'G' and A.CMDALLOW = 'Y' and A.AUTHID = '" & v_strGrpId & "') G  " & ControlChars.CrLf _
                                & "     where AM.LEV > 1 and AM.PRID = '" & v_strParentKey & "'   " & ControlChars.CrLf _
                                & "        and AM.menucode = M.cmdid(+)   " & ControlChars.CrLf _
                                & "        and AM.menucode = T.tltxcd(+)   " & ControlChars.CrLf _
                                & "        and AM.menucode = g.gvid(+)   " & ControlChars.CrLf _
                                & "        and AM.menucode = R.rptid(+) " & ControlChars.CrLf _
                                & "        and (AM.menutype = 'P'  " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'M' and AM.menucode = M.cmdid)   " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'T' and AM.menucode = T.tltxcd)   " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'G' and AM.menucode = g.gvid)   " & ControlChars.CrLf _
                                & "            or (AM.menutype = 'R' and AM.menucode = R.rptid) " & ControlChars.CrLf _
                                & "            ) " & ControlChars.CrLf _
                                & "    order by AM.CMDID "

                    Dim v_dsGrpRight As DataSet
                    'Dim v_objGrpRight As New DataAccess
                    'v_objGrpRight.NewDBInstance(gc_MODULE_HOST)
                    v_dsGrpRight = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpFuncFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strREFCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("REFCMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("REFCMDCODE"))
                            v_strCMDCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDCODE"))
                            v_strPRID = IIf(v_dsGrpRight.Tables(0).Rows(j)("PRID") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("PRID"))
                            v_strCMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDNAME"))
                            v_strEN_CMDNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_CMDNAME"))
                            v_strLAST = IIf(v_dsGrpRight.Tables(0).Rows(j)("LAST") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("LAST"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            v_strMODCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strOBJNAME = IIf(v_dsGrpRight.Tables(0).Rows(j)("OBJNAME") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("OBJNAME"))
                            v_strMENUTYPE = IIf(v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MENUTYPE"))
                            v_strAUTHCODE = IIf(v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("AUTHCODE"))
                            v_strAUTH = IIf(v_dsGrpRight.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("STRAUTH"))
                            'Add new value to User hash table
                            v_strHashValue = v_strCMDCODE & "|" & v_strPRID & "|" & v_strCMDNAME & "|" & v_strEN_CMDNAME & "|" & v_strLAST & "|" & v_strIMGINDEX & "|" & v_strMODCODE & "|" & v_strOBJNAME & "|" & v_strMENUTYPE & "|" & v_strAUTHCODE & "|" & v_strAUTH & "|" & v_strREFCMDCODE
                            hGrpFilter.Add(v_strCMDCODE, v_strHashValue)
                        Next
                    End If
                    h_arrGrpFuncFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT CMDID FROM ADJUSTMENU WHERE PRID = '" & v_strParentKey & "' order by CMDID"
            Dim v_dsCmdid As DataSet
            'Dim v_objCmdid As New DataAccess
            'v_objCmdid.NewDBInstance(gc_MODULE_HOST)
            v_dsCmdid = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrCMDID() As String
            If v_dsCmdid.Tables(0).Rows.Count > 0 Then
                v_intNumFunc = v_dsCmdid.Tables(0).Rows.Count
                ReDim v_arrCMDID(v_intNumFunc - 1)
                For i As Integer = 0 To v_intNumFunc - 1
                    v_arrCMDID(i) = IIf(v_dsCmdid.Tables(0).Rows(i)("CMDID") Is DBNull.Value, "", v_dsCmdid.Tables(0).Rows(i)("CMDID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("CMDCODE")
            v_dsFunc.Tables(0).Columns.Add("PRID")
            v_dsFunc.Tables(0).Columns.Add("CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("EN_CMDNAME")
            v_dsFunc.Tables(0).Columns.Add("LAST")
            v_dsFunc.Tables(0).Columns.Add("IMGINDEX")
            v_dsFunc.Tables(0).Columns.Add("MODCODE")
            v_dsFunc.Tables(0).Columns.Add("OBJNAME")
            v_dsFunc.Tables(0).Columns.Add("MENUTYPE")
            v_dsFunc.Tables(0).Columns.Add("AUTHCODE")
            v_dsFunc.Tables(0).Columns.Add("STRAUTH")
            v_dsFunc.Tables(0).Columns.Add("REFCMDCODE")

            Dim v_arrFunc() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group
            If v_intNumFunc > 0 Then
                For i As Integer = 0 To v_intNumFunc - 1
                    'If user has right of this function, do not check right of group
                    If Not hUsrFuncFilter(v_arrCMDID(i)) Is Nothing Then
                        'Get data of row
                        v_arrFunc = CStr(hUsrFuncFilter(v_arrCMDID(i))).Split("|")
                        'Add right of user to dataset
                        v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                        'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                    Else
                        'Check right of groups
                        If v_intNumGrp > 0 Then
                            Dim v_strAUTHSTR As String
                            Dim v_strInquiry, v_strAdd, v_strEdit, v_strDelete, v_strApprove As String
                            Dim v_blnInquiry, v_blnAdd, v_blnEdit, v_blnDelete, v_blnApprove As Boolean
                            Dim v_blnPreInquiry, v_blnPreAdd, v_blnPreEdit, v_blnPreDelete, v_blnPreApprove As Boolean

                            v_blnPreInquiry = False
                            v_blnPreAdd = False
                            v_blnPreEdit = False
                            v_blnPreDelete = False
                            v_blnPreApprove = False

                            If Not v_arrFunc Is Nothing Then
                                'v_arrFunc.s
                                'ReDim v_arrFunc(0)
                                v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                            End If

                            For j As Integer = 0 To v_intNumGrp - 1
                                If Not h_arrGrpFuncFilter(j)(v_arrCMDID(i)) Is Nothing Then
                                    'Get data of row
                                    v_arrFunc = CStr(h_arrGrpFuncFilter(j)(v_arrCMDID(i))).Split("|")
                                    v_strAUTHSTR = v_arrFunc(10)
                                    v_strInquiry = Mid(v_strAUTHSTR, 1, 1)
                                    v_strAdd = Mid(v_strAUTHSTR, 2, 1)
                                    v_strEdit = Mid(v_strAUTHSTR, 3, 1)
                                    v_strDelete = Mid(v_strAUTHSTR, 4, 1)
                                    v_strApprove = Mid(v_strAUTHSTR, 5, 1)

                                    v_blnInquiry = IIf(v_strInquiry = "Y", True, False)
                                    v_blnAdd = IIf(v_strAdd = "Y", True, False)
                                    v_blnEdit = IIf(v_strEdit = "Y", True, False)
                                    v_blnDelete = IIf(v_strDelete = "Y", True, False)
                                    v_blnApprove = IIf(v_strApprove = "Y", True, False)

                                    'Combination right of groups
                                    v_blnInquiry = (v_blnInquiry Or v_blnPreInquiry)
                                    v_blnAdd = (v_blnAdd Or v_blnPreAdd)
                                    v_blnEdit = (v_blnEdit Or v_blnPreEdit)
                                    v_blnDelete = (v_blnDelete Or v_blnPreDelete)
                                    v_blnApprove = (v_blnApprove Or v_blnPreApprove)

                                    'Assign right to previous right
                                    v_blnPreInquiry = v_blnInquiry
                                    v_blnPreAdd = v_blnAdd
                                    v_blnPreEdit = v_blnEdit
                                    v_blnPreDelete = v_blnDelete
                                    v_blnPreApprove = v_blnApprove
                                    'Else
                                    '    If Not v_arrFunc Is Nothing Then
                                    '        'v_arrFunc.s
                                    '        'ReDim v_arrFunc(0)
                                    '        v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                                    '    End If
                                End If
                            Next
                            'Get last right of groups
                            If Not v_arrFunc Is Nothing Then
                                If Not v_arrFunc.GetValue(0) Is Nothing Then
                                    v_strInquiry = IIf(v_blnInquiry = True, "Y", "N")
                                    v_strAdd = IIf(v_blnAdd = True, "Y", "N")
                                    v_strEdit = IIf(v_blnEdit = True, "Y", "N")
                                    v_strDelete = IIf(v_blnDelete = True, "Y", "N")
                                    v_strApprove = IIf(v_blnApprove = True, "Y", "N")
                                    v_strAUTHSTR = v_strInquiry & v_strAdd & v_strEdit & v_strDelete & v_strApprove
                                    v_arrFunc(10) = v_strAUTHSTR

                                    'Add right of user to dataset
                                    v_dsFunc.Tables(0).Rows.Add(v_arrFunc)
                                End If
                            End If

                        End If
                    End If
                Next
            End If


            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Public Function GetTransChildMenu(ByRef pv_strObjMsg As String) As Long
        Dim XMLDocument As New Xml.XmlDocument
        Dim v_strSQL, v_arrClause(), v_strTellerId, v_strHashValue, v_strModCode As String
        Dim v_strTLTXCD, v_strTXDESC, v_strEN_TXDESC, v_strMODCOD, v_strCMDALLOW, v_strIMGINDEX As String
        Dim v_intNumGrp, v_intNumTrans As Integer
        Dim hUsrTransFilter As New Hashtable
        Dim h_arrGrpTransFilter() As Hashtable
        Dim v_DataAccess As New DataAccess
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)

        Try
            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            v_arrClause = v_strClause.Split("|")
            If v_arrClause.Length = 2 Then
                v_strTellerId = Trim(v_arrClause(0))
                v_strModCode = Trim(v_arrClause(1))
            End If

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user
            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.MODCODE MODCODE, 'Y' CMDALLOW, 3 IMGINDEX " _
                                        & "FROM (SELECT N.TLTXCD, N.TXDESC, N.EN_TXDESC, B.TXCODE, B.MODCODE " _
                                            & "FROM TLTX N, APPMODULES B " _
                                            & "WHERE SUBSTR(N.TLTXCD, 0, 2) = B.TXCODE AND N.DIRECT='Y') M " _
                                        & "WHERE M.MODCODE = '" & v_strModCode & "' " _
                                        & "ORDER BY M.TLTXCD "
            Else
                v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.MODCODE MODCODE, A.CMDALLOW CMDALLOW, 3 IMGINDEX " _
                                        & "FROM (SELECT N.TLTXCD, N.TXDESC, N.EN_TXDESC, B.TXCODE, B.MODCODE " _
                                            & "FROM TLTX N, APPMODULES B " _
                                            & "WHERE SUBSTR(N.TLTXCD, 0, 2) = B.TXCODE AND N.DIRECT='Y') M, CMDAUTH A " _
                                        & "WHERE M.MODCODE = '" & v_strModCode & "' AND M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & v_strTellerId & "' " _
                                        & "AND A.AUTHTYPE = 'U' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
                                        & "ORDER BY M.TLTXCD "
            End If


            Dim v_dsUsr As DataSet
            'Dim v_objUsr As New DataAccess
            'v_objUsr.NewDBInstance(gc_MODULE_HOST)
            v_dsUsr = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strTLTXCD = IIf(v_dsUsr.Tables(0).Rows(i)("TLTXCD") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("TLTXCD"))
                    v_strTXDESC = IIf(v_dsUsr.Tables(0).Rows(i)("TXDESC") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("TXDESC"))
                    v_strEN_TXDESC = IIf(v_dsUsr.Tables(0).Rows(i)("EN_TXDESC") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("EN_TXDESC"))
                    v_strMODCOD = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("MODCODE"))
                    v_strCMDALLOW = IIf(v_dsUsr.Tables(0).Rows(i)("CMDALLOW") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("CMDALLOW"))
                    v_strIMGINDEX = IIf(v_dsUsr.Tables(0).Rows(i)("MODCODE") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("IMGINDEX"))

                    'Add new value to User hash table
                    v_strHashValue = v_strTLTXCD & "|" & v_strTXDESC & "|" & v_strEN_TXDESC & "|" & v_strMODCOD & "|" & v_strCMDALLOW & "|" & v_strIMGINDEX
                    hUsrTransFilter.Add(v_strTLTXCD, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            'Dim v_objGrp As New DataAccess
            'v_objGrp.NewDBInstance(gc_MODULE_HOST)
            v_dsGrp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpTransFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "SELECT M.TLTXCD TLTXCD, M.TXDESC TXDESC, M.EN_TXDESC EN_TXDESC, M.MODCODE MODCODE, A.CMDALLOW CMDALLOW, 3 IMGINDEX " _
                                & "FROM (SELECT N.TLTXCD, N.TXDESC, N.EN_TXDESC, B.TXCODE, B.MODCODE " _
                                    & "FROM TLTX N, APPMODULES B " _
                                & "WHERE SUBSTR(N.TLTXCD, 0, 2) = B.TXCODE AND N.DIRECT = 'Y') M, CMDAUTH A " _
                                & "WHERE M.MODCODE = '" & v_strModCode & "' AND M.TLTXCD = A.CMDCODE AND A.AUTHID = '" & v_strGrpId & "' " _
                                & "AND A.AUTHTYPE = 'G' AND A.CMDTYPE = 'T' AND A.CMDALLOW = 'Y' " _
                                & "ORDER BY M.TLTXCD "

                    Dim v_dsGrpRight As DataSet
                    'Dim v_objGrpRight As New DataAccess
                    v_dsGrpRight = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpTransFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRight.Tables(0).Rows.Count - 1
                            v_strTLTXCD = IIf(v_dsGrpRight.Tables(0).Rows(j)("TLTXCD") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("TLTXCD"))
                            v_strTXDESC = IIf(v_dsGrpRight.Tables(0).Rows(j)("TXDESC") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("TXDESC"))
                            v_strEN_TXDESC = IIf(v_dsGrpRight.Tables(0).Rows(j)("EN_TXDESC") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("EN_TXDESC"))
                            v_strMODCOD = IIf(v_dsGrpRight.Tables(0).Rows(j)("MODCODE") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("MODCODE"))
                            v_strCMDALLOW = IIf(v_dsGrpRight.Tables(0).Rows(j)("CMDALLOW") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("CMDALLOW"))
                            v_strIMGINDEX = IIf(v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(j)("IMGINDEX"))
                            'Add new value to User hash table
                            v_strHashValue = v_strTLTXCD & "|" & v_strTXDESC & "|" & v_strEN_TXDESC & "|" & v_strMODCOD & "|" & v_strCMDALLOW & "|" & v_strIMGINDEX
                            hGrpFilter.Add(v_strTLTXCD, v_strHashValue)
                        Next
                    End If
                    h_arrGrpTransFilter(i) = hGrpFilter
                Next
            End If

            'Get TLTCXD of all transaction
            v_strSQL = "SELECT M.TLTXCD TLTXCD FROM TLTX M, APPMODULES A " _
                        & "WHERE SUBSTR(M.TLTXCD, 0, 2) = A.TXCODE AND A.MODCODE = '" & v_strModCode & "' " _
                        & "ORDER BY M.TLTXCD "
            Dim v_dsTltxcd As DataSet
            'Dim v_objTltxcd As New DataAccess
            'v_objTltxcd.NewDBInstance(gc_MODULE_HOST)
            v_dsTltxcd = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrTLTXCD() As String
            If v_dsTltxcd.Tables(0).Rows.Count > 0 Then
                v_intNumTrans = v_dsTltxcd.Tables(0).Rows.Count
                ReDim v_arrTLTXCD(v_intNumTrans - 1)
                For i As Integer = 0 To v_intNumTrans - 1
                    v_arrTLTXCD(i) = IIf(v_dsTltxcd.Tables(0).Rows(i)("TLTXCD") Is DBNull.Value, "", v_dsTltxcd.Tables(0).Rows(i)("TLTXCD"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsTrans As New DataSet
            v_dsTrans.Tables.Add()
            v_dsTrans.Tables(0).Columns.Add("TLTXCD")
            v_dsTrans.Tables(0).Columns.Add("TXDESC")
            v_dsTrans.Tables(0).Columns.Add("EN_TXDESC")
            v_dsTrans.Tables(0).Columns.Add("MODCODE")
            v_dsTrans.Tables(0).Columns.Add("CMDALLOW")
            v_dsTrans.Tables(0).Columns.Add("IMGINDEX")

            Dim v_arrTrans() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group

            For i As Integer = 0 To v_intNumTrans - 1
                If Not hUsrTransFilter(v_arrTLTXCD(i)) Is Nothing Then
                    'Get data of row
                    v_arrTrans = CStr(hUsrTransFilter(v_arrTLTXCD(i))).Split("|")
                    'Add right of user to dataset
                    v_dsTrans.Tables(0).Rows.Add(v_arrTrans)
                    'hFuncFilter.Add(v_arrCMDID(i), hUsrFuncFilter(v_arrCMDID(i)))
                Else
                    'Check right of groups
                    If v_intNumGrp > 0 Then
                        For j As Integer = 0 To v_intNumGrp - 1
                            If Not h_arrGrpTransFilter(j)(v_arrTLTXCD(i)) Is Nothing Then
                                'Get data of row
                                v_arrTrans = CStr(h_arrGrpTransFilter(j)(v_arrTLTXCD(i))).Split("|")
                                'Add right of user to dataset
                                v_dsTrans.Tables(0).Rows.Add(v_arrTrans)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next

            'Build XML Data
            BuildXMLObjData(v_dsTrans, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function GetReportList(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New Xml.XmlDocument
            Dim v_strSQL, v_strArr(), v_strParentKey, v_strHashValue As String
            Dim hUsrRptFilter As New Hashtable
            Dim hRptFilter As New Hashtable
            Dim h_arrGrpRptFilter() As Hashtable
            Dim v_strRPTID, v_strRPTNAME, v_strPAPER, v_strORIENTATION, v_strSTOREDNAME, v_strISLOCAL, v_strSTRAUTH, v_strISCAREBY, v_strAREA, v_strSUBRPT, v_strISCMP, v_strAD_HOC As String
            Dim v_intNumGrp, v_intNumRpt As Integer
            Dim v_DataAccess As New DataAccess
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strBranchId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strModuleCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strAreaCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user

            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT M.AD_HOC, M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.AREA ,M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, 'YYA' STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP " _
                        & "FROM RPTMASTER M, ALLCODE A " _
                        & "WHERE M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                        & "ORDER BY M.RPTID"
            Else
                v_strSQL = "SELECT M.AD_HOC, M.RPTID RPTID, M.DESCRIPTION RPTNAME , M.AREA , M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, N.STRAUTH STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP  " _
                        & "FROM RPTMASTER M, ALLCODE A, CMDAUTH N " _
                        & "WHERE M.RPTID = N.CMDCODE AND N.AUTHID = '" & v_strTellerId & "' AND N.CMDALLOW = 'Y' AND N.AUTHTYPE = 'U' AND N.CMDTYPE = 'R' " _
                        & "AND M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                        & "AND 1 = (CASE WHEN '" & v_strAreaCode & "' = 'A' THEN 1 WHEN '" & v_strAreaCode & "' = 'B' AND M.AREA <> 'A' THEN 1 WHEN '" & v_strAreaCode & "' = 'S' AND M.AREA <> 'A' AND M.AREA <> 'B' THEN 1 ELSE 0 END ) " _
                        & "ORDER BY M.RPTID"
            End If

            Dim v_dsUsr As DataSet
            'Dim v_objUsr As New DataAccess
            'v_objUsr.NewDBInstance(gc_MODULE_HOST)
            v_dsUsr = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strRPTID = IIf(v_dsUsr.Tables(0).Rows(i)("RPTID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("RPTID"))
                    v_strRPTNAME = IIf(v_dsUsr.Tables(0).Rows(i)("RPTNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("RPTNAME"))
                    v_strPAPER = IIf(v_dsUsr.Tables(0).Rows(i)("PAPER") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PAPER"))
                    v_strORIENTATION = IIf(v_dsUsr.Tables(0).Rows(i)("ORIENTATION") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ORIENTATION"))
                    v_strSTOREDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("STOREDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STOREDNAME"))
                    v_strISLOCAL = IIf(v_dsUsr.Tables(0).Rows(i)("ISLOCAL") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISLOCAL"))
                    v_strSTRAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    v_strISCAREBY = IIf(v_dsUsr.Tables(0).Rows(i)("ISCAREBY") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISCAREBY"))
                    v_strAREA = IIf(v_dsUsr.Tables(0).Rows(i)("AREA") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AREA"))
                    v_strSUBRPT = IIf(v_dsUsr.Tables(0).Rows(i)("SUBRPT") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("SUBRPT"))
                    v_strISCMP = IIf(v_dsUsr.Tables(0).Rows(i)("ISCMP") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISCMP"))
                    v_strAD_HOC = IIf(v_dsUsr.Tables(0).Rows(i)("AD_HOC") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("AD_HOC"))
                    'Add new value to User hash table
                    v_strHashValue = v_strRPTID & "|" & v_strRPTNAME & "|" & v_strPAPER & "|" & v_strORIENTATION & "|" & v_strSTOREDNAME & "|" & v_strISLOCAL & "|" & v_strSTRAUTH & "|" & v_strISCAREBY & "|" & v_strAREA & "|" & v_strSUBRPT & "|" & v_strISCMP
                    hUsrRptFilter.Add(v_strRPTID, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            'v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y' AND A.GRPTYPE='1'"
            Dim v_dsGrp As DataSet
            'Dim v_objGrp As New DataAccess
            'v_objGrp.NewDBInstance(gc_MODULE_HOST)
            v_dsGrp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpRptFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "SELECT M.AD_HOC, M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.AREA, M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, N.STRAUTH STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP  " _
                            & "FROM RPTMASTER M, ALLCODE A, CMDAUTH N " _
                            & "WHERE M.RPTID = N.CMDCODE AND N.AUTHID = '" & v_strGrpId & "' AND N.CMDALLOW = 'Y' AND N.AUTHTYPE = 'G' AND N.CMDTYPE = 'R' " _
                            & "AND M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                            & "AND 1 = (CASE WHEN '" & v_strAreaCode & "' = 'A' THEN 1 WHEN '" & v_strAreaCode & "' = 'B' AND M.AREA <> 'A' THEN 1 WHEN '" & v_strAreaCode & "' = 'S' AND M.AREA <> 'A' AND M.AREA <> 'B' THEN 1 ELSE 0 END ) " _
                            & "ORDER BY M.RPTID"

                    Dim v_dsGrpRpt As DataSet
                    'Dim v_objGrpRpt As New DataAccess
                    'v_objGrpRpt.NewDBInstance(gc_MODULE_HOST)
                    v_dsGrpRpt = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpRptFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRpt.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRpt.Tables(0).Rows.Count - 1
                            v_strRPTID = IIf(v_dsGrpRpt.Tables(0).Rows(j)("RPTID") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("RPTID"))
                            v_strRPTNAME = IIf(v_dsGrpRpt.Tables(0).Rows(j)("RPTNAME") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("RPTNAME"))
                            v_strPAPER = IIf(v_dsGrpRpt.Tables(0).Rows(j)("PAPER") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("PAPER"))
                            v_strORIENTATION = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ORIENTATION") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ORIENTATION"))
                            v_strSTOREDNAME = IIf(v_dsGrpRpt.Tables(0).Rows(j)("STOREDNAME") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("STOREDNAME"))
                            v_strISLOCAL = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISLOCAL") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISLOCAL"))
                            v_strSTRAUTH = IIf(v_dsGrpRpt.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("STRAUTH"))
                            v_strISCAREBY = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISCAREBY") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISCAREBY"))
                            v_strAREA = IIf(v_dsGrpRpt.Tables(0).Rows(j)("AREA") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("AREA"))
                            v_strSUBRPT = IIf(v_dsGrpRpt.Tables(0).Rows(j)("SUBRPT") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("SUBRPT"))
                            v_strISCMP = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISCMP") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISCMP"))
                            v_strAD_HOC = IIf(v_dsGrpRpt.Tables(0).Rows(j)("AD_HOC") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("AD_HOC"))
                            'Add new value to User hash table
                            v_strHashValue = v_strRPTID & "|" & v_strRPTNAME & "|" & v_strPAPER & "|" & v_strORIENTATION & "|" & v_strSTOREDNAME & "|" & v_strISLOCAL & "|" & v_strSTRAUTH & "|" & v_strISCAREBY & "|" & v_strAREA & "|" & v_strSUBRPT & "|" & v_strISCMP
                            hGrpFilter.Add(v_strRPTID, v_strHashValue)
                        Next
                    End If
                    h_arrGrpRptFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT RPTID FROM RPTMASTER WHERE CMDTYPE='R' AND MODCODE = '" & v_strModuleCode & "' ORDER BY RPTID"
            Dim v_dsRptId As DataSet
            'Dim v_objRptId As New DataAccess
            'v_objRptId.NewDBInstance(gc_MODULE_HOST)
            v_dsRptId = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrRPTID() As String
            If v_dsRptId.Tables(0).Rows.Count > 0 Then
                v_intNumRpt = v_dsRptId.Tables(0).Rows.Count
                ReDim v_arrRPTID(v_intNumRpt - 1)
                For i As Integer = 0 To v_intNumRpt - 1
                    v_arrRPTID(i) = IIf(v_dsRptId.Tables(0).Rows(i)("RPTID") Is DBNull.Value, "", v_dsRptId.Tables(0).Rows(i)("RPTID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsRpt As New DataSet
            v_dsRpt.Tables.Add()
            v_dsRpt.Tables(0).Columns.Add("RPTID")
            v_dsRpt.Tables(0).Columns.Add("RPTNAME")
            v_dsRpt.Tables(0).Columns.Add("PAPER")
            v_dsRpt.Tables(0).Columns.Add("ORIENTATION")
            v_dsRpt.Tables(0).Columns.Add("STOREDNAME")
            v_dsRpt.Tables(0).Columns.Add("ISLOCAL")
            v_dsRpt.Tables(0).Columns.Add("STRAUTH")
            v_dsRpt.Tables(0).Columns.Add("ISCAREBY")
            v_dsRpt.Tables(0).Columns.Add("AREA")
            v_dsRpt.Tables(0).Columns.Add("SUBRPT")
            v_dsRpt.Tables(0).Columns.Add("ISCMP")
            v_dsRpt.Tables(0).Columns.Add("AD_HOC")
            Dim v_arrRpt() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group
            If v_intNumRpt > 0 Then
                For i As Integer = 0 To v_intNumRpt - 1
                    'If user has right of this function, do not check right of group
                    If Not hUsrRptFilter(v_arrRPTID(i)) Is Nothing Then
                        'Get data of row
                        v_arrRpt = CStr(hUsrRptFilter(v_arrRPTID(i))).Split("|")
                        'Add right of user to dataset
                        v_dsRpt.Tables(0).Rows.Add(v_arrRpt)
                        'hFuncFilter.Add(v_arrCMDID(i), hUsrRptFilter(v_arrCMDID(i)))
                    Else
                        'Check right of groups
                        If v_intNumGrp > 0 Then
                            Dim v_strAUTHSTR As String
                            Dim v_strPrint, v_strAdd, v_strAreaRight As String
                            Dim v_blnPrint, v_blnAdd As Boolean
                            Dim v_blnPrePrint, v_blnPreAdd As Boolean
                            Dim v_strPreAreaRight As String

                            v_blnPrePrint = False
                            v_blnPreAdd = False
                            v_strPreAreaRight = "S" 'Gan quyen pham vi nho nhat - phong giao dich

                            If Not v_arrRpt Is Nothing Then
                                'v_arrFunc.s
                                'ReDim v_arrFunc(0)
                                v_arrRpt.Clear(v_arrRpt, 0, v_arrRpt.Length)
                            End If

                            For j As Integer = 0 To v_intNumGrp - 1
                                If Not h_arrGrpRptFilter(j)(v_arrRPTID(i)) Is Nothing Then
                                    'Get data of row
                                    v_arrRpt = CStr(h_arrGrpRptFilter(j)(v_arrRPTID(i))).Split("|")
                                    v_strAUTHSTR = v_arrRpt(6)
                                    v_strPrint = Mid(v_strAUTHSTR, 1, 1)
                                    v_strAdd = Mid(v_strAUTHSTR, 2, 1)
                                    v_strAreaRight = Mid(v_strAUTHSTR, 3, 1)

                                    v_blnPrint = IIf(v_strPrint = "Y", True, False)
                                    v_blnAdd = IIf(v_strAdd = "Y", True, False)

                                    'Combination right of groups
                                    v_blnPrint = (v_blnPrint Or v_blnPrePrint)
                                    v_blnAdd = (v_blnAdd Or v_blnPreAdd)
                                    If v_strAreaRight = "S" And (v_strPreAreaRight = "A" Or v_strPreAreaRight = "B") Then
                                        v_strAreaRight = v_strPreAreaRight
                                    ElseIf v_strAreaRight = "B" And v_strPreAreaRight = "A" Then
                                        v_strAreaRight = v_strPreAreaRight
                                    End If

                                    'Assign right to previous right
                                    v_blnPrePrint = v_blnPrint
                                    v_blnPreAdd = v_blnAdd
                                    v_strPreAreaRight = v_strAreaRight
                                End If
                            Next
                            'Get last right of groups
                            If Not v_arrRpt Is Nothing Then
                                If Not v_arrRpt.GetValue(0) Is Nothing Then
                                    v_strPrint = IIf(v_blnPrint = True, "Y", "N")
                                    v_strAdd = IIf(v_blnAdd = True, "Y", "N")
                                    v_strAUTHSTR = v_strPrint & v_strAdd & v_strAreaRight
                                    v_arrRpt(6) = v_strAUTHSTR

                                    'Add right of user to dataset
                                    v_dsRpt.Tables(0).Rows.Add(v_arrRpt)
                                End If
                            End If
                        End If
                    End If
                Next
            End If


            'Build XML Data
            BuildXMLObjData(v_dsRpt, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Public Function GetReportBatch(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New Xml.XmlDocument
            Dim v_strSQL, v_strArr(), v_strParentKey, v_strHashValue As String
            Dim hUsrRptFilter As New Hashtable
            Dim hRptFilter As New Hashtable
            Dim h_arrGrpRptFilter() As Hashtable
            Dim v_strRPTID, v_strRPTNAME, v_strPAPER, v_strORIENTATION, v_strSTOREDNAME, v_strISLOCAL, v_strSTRAUTH, v_strISCAREBY, v_strSUBRPT, v_strISCMP As String
            Dim v_intNumGrp, v_intNumRpt As Integer
            Dim v_DataAccess As New DataAccess
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Dim v_strBranchId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Dim v_strModuleCode As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Check access right of user
            'If user has been in assignment list, do not check right of group
            'Get access right of user

            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, 'YY' STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP " _
                        & "FROM RPTMASTER M, ALLCODE A " _
                        & "WHERE M.CMDTYPE='R' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION  AND M.ISPUBLIC = 'Y' " _
                        & "ORDER BY M.RPTID"

            Else
                v_strSQL = "SELECT M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, N.STRAUTH STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP " _
                        & "FROM RPTMASTER M, ALLCODE A, CMDAUTH N " _
                        & "WHERE M.RPTID = N.CMDCODE AND N.AUTHID = '" & v_strTellerId & "' AND N.CMDALLOW = 'Y' AND N.AUTHTYPE = 'U' AND N.CMDTYPE = 'R' " _
                        & "AND M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                        & "ORDER BY M.RPTID"
            End If

            Dim v_dsUsr As DataSet
            'Dim v_objUsr As New DataAccess
            'v_objUsr.NewDBInstance(gc_MODULE_HOST)
            v_dsUsr = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            'Add access right of user to hash table
            If v_dsUsr.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_dsUsr.Tables(0).Rows.Count - 1
                    v_strRPTID = IIf(v_dsUsr.Tables(0).Rows(i)("RPTID") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("RPTID"))
                    v_strRPTNAME = IIf(v_dsUsr.Tables(0).Rows(i)("RPTNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("RPTNAME"))
                    v_strPAPER = IIf(v_dsUsr.Tables(0).Rows(i)("PAPER") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("PAPER"))
                    v_strORIENTATION = IIf(v_dsUsr.Tables(0).Rows(i)("ORIENTATION") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ORIENTATION"))
                    v_strSTOREDNAME = IIf(v_dsUsr.Tables(0).Rows(i)("STOREDNAME") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STOREDNAME"))
                    v_strISLOCAL = IIf(v_dsUsr.Tables(0).Rows(i)("ISLOCAL") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISLOCAL"))
                    v_strSTRAUTH = IIf(v_dsUsr.Tables(0).Rows(i)("STRAUTH") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("STRAUTH"))
                    v_strISCAREBY = IIf(v_dsUsr.Tables(0).Rows(i)("ISCAREBY") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISCAREBY"))
                    v_strSUBRPT = IIf(v_dsUsr.Tables(0).Rows(i)("SUBRPT") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("SUBRPT"))
                    v_strISCMP = IIf(v_dsUsr.Tables(0).Rows(i)("ISCMP") Is DBNull.Value, "", v_dsUsr.Tables(0).Rows(i)("ISCMP"))
                    'Add new value to User hash table
                    v_strHashValue = v_strRPTID & "|" & v_strRPTNAME & "|" & v_strPAPER & "|" & v_strORIENTATION & "|" & v_strSTOREDNAME & "|" & v_strISLOCAL & "|" & v_strSTRAUTH & "|" & v_strISCAREBY & "|" & v_strSUBRPT & "|" & v_strISCMP
                    hUsrRptFilter.Add(v_strRPTID, v_strHashValue)
                Next
            End If

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            Dim v_dsGrp As DataSet
            'Dim v_objGrp As New DataAccess
            'v_objGrp.NewDBInstance(gc_MODULE_HOST)
            v_dsGrp = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                ReDim h_arrGrpRptFilter(v_intNumGrp - 1)
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "SELECT M.RPTID RPTID, M.DESCRIPTION RPTNAME, M.PSIZE PAPER, A.CDCONTENT ORIENTATION, M.STOREDNAME STOREDNAME, M.ISLOCAL ISLOCAL, N.STRAUTH STRAUTH, M.ISCAREBY ISCAREBY, M.SUBRPT, M.ISCMP " _
                            & "FROM RPTMASTER M, ALLCODE A, CMDAUTH N " _
                            & "WHERE M.RPTID = N.CMDCODE AND N.AUTHID = '" & v_strGrpId & "' AND N.CMDALLOW = 'Y' AND N.AUTHTYPE = 'G' AND N.CMDTYPE = 'R' " _
                            & "AND M.CMDTYPE='R' AND M.MODCODE = '" & v_strModuleCode & "' AND M.VISIBLE = 'Y' AND A.CDTYPE = 'SY' AND A.CDNAME = 'ORIENTATION' AND A.CDVAL= M.ORIENTATION " _
                            & "ORDER BY M.RPTID"

                    Dim v_dsGrpRpt As DataSet
                    'Dim v_objGrpRpt As New DataAccess
                    v_dsGrpRpt = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve h_arrGrpRptFilter(v_intNumGrp - 1)
                    Dim hGrpFilter As New Hashtable

                    If v_dsGrpRpt.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To v_dsGrpRpt.Tables(0).Rows.Count - 1
                            v_strRPTID = IIf(v_dsGrpRpt.Tables(0).Rows(j)("RPTID") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("RPTID"))
                            v_strRPTNAME = IIf(v_dsGrpRpt.Tables(0).Rows(j)("RPTNAME") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("RPTNAME"))
                            v_strPAPER = IIf(v_dsGrpRpt.Tables(0).Rows(j)("PAPER") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("PAPER"))
                            v_strORIENTATION = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ORIENTATION") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ORIENTATION"))
                            v_strSTOREDNAME = IIf(v_dsGrpRpt.Tables(0).Rows(j)("STOREDNAME") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("STOREDNAME"))
                            v_strISLOCAL = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISLOCAL") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISLOCAL"))
                            v_strSTRAUTH = IIf(v_dsGrpRpt.Tables(0).Rows(j)("STRAUTH") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("STRAUTH"))
                            v_strISCAREBY = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISCAREBY") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISCAREBY"))
                            v_strSUBRPT = IIf(v_dsGrpRpt.Tables(0).Rows(j)("SUBRPT") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("SUBRPT"))
                            v_strISCMP = IIf(v_dsGrpRpt.Tables(0).Rows(j)("ISCMP") Is DBNull.Value, "", v_dsGrpRpt.Tables(0).Rows(j)("ISCMP"))
                            'Add new value to User hash table
                            v_strHashValue = v_strRPTID & "|" & v_strRPTNAME & "|" & v_strPAPER & "|" & v_strORIENTATION & "|" & v_strSTOREDNAME & "|" & v_strISLOCAL & "|" & v_strSTRAUTH & "|" & v_strISCAREBY & "|" & v_strSUBRPT & "|" & v_strISCMP
                            hGrpFilter.Add(v_strRPTID, v_strHashValue)
                        Next
                    End If
                    h_arrGrpRptFilter(i) = hGrpFilter
                Next
            End If

            'Get CMDCODE of all function
            v_strSQL = "SELECT RPTID FROM RPTMASTER WHERE CMDTYPE='R'  ORDER BY RPTID"
            Dim v_dsRptId As DataSet
            'Dim v_objRptId As New DataAccess
            'v_objRptId.NewDBInstance(gc_MODULE_HOST)
            v_dsRptId = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            Dim v_arrRPTID() As String
            If v_dsRptId.Tables(0).Rows.Count > 0 Then
                v_intNumRpt = v_dsRptId.Tables(0).Rows.Count
                ReDim v_arrRPTID(v_intNumRpt - 1)
                For i As Integer = 0 To v_intNumRpt - 1
                    v_arrRPTID(i) = IIf(v_dsRptId.Tables(0).Rows(i)("RPTID") Is DBNull.Value, "", v_dsRptId.Tables(0).Rows(i)("RPTID"))
                Next
            End If

            'Create dataset to contain access right data
            Dim v_dsRpt As New DataSet
            v_dsRpt.Tables.Add()
            v_dsRpt.Tables(0).Columns.Add("RPTID")
            v_dsRpt.Tables(0).Columns.Add("RPTNAME")
            v_dsRpt.Tables(0).Columns.Add("PAPER")
            v_dsRpt.Tables(0).Columns.Add("ORIENTATION")
            v_dsRpt.Tables(0).Columns.Add("STOREDNAME")
            v_dsRpt.Tables(0).Columns.Add("ISLOCAL")
            v_dsRpt.Tables(0).Columns.Add("STRAUTH")
            v_dsRpt.Tables(0).Columns.Add("ISCAREBY")
            v_dsRpt.Tables(0).Columns.Add("SUBRPT")
            v_dsRpt.Tables(0).Columns.Add("ISCMP")

            Dim v_arrRpt() As String

            'Check right of each function, 
            'If user has right of this function, do not check right of group
            If v_intNumRpt > 0 Then
                For i As Integer = 0 To v_intNumRpt - 1
                    'If user has right of this function, do not check right of group
                    If Not hUsrRptFilter(v_arrRPTID(i)) Is Nothing Then
                        'Get data of row
                        v_arrRpt = CStr(hUsrRptFilter(v_arrRPTID(i))).Split("|")
                        'Add right of user to dataset
                        v_dsRpt.Tables(0).Rows.Add(v_arrRpt)
                        'hFuncFilter.Add(v_arrCMDID(i), hUsrRptFilter(v_arrCMDID(i)))
                    Else
                        'Check right of groups
                        If v_intNumGrp > 0 Then
                            Dim v_strAUTHSTR As String
                            Dim v_strPrint, v_strAdd As String
                            Dim v_blnPrint, v_blnAdd As Boolean
                            Dim v_blnPrePrint, v_blnPreAdd As Boolean

                            v_blnPrePrint = False
                            v_blnPreAdd = False

                            If Not v_arrRpt Is Nothing Then
                                'v_arrFunc.s
                                'ReDim v_arrFunc(0)
                                v_arrRpt.Clear(v_arrRpt, 0, v_arrRpt.Length)
                            End If

                            For j As Integer = 0 To v_intNumGrp - 1
                                If Not h_arrGrpRptFilter(j)(v_arrRPTID(i)) Is Nothing Then
                                    'Get data of row
                                    v_arrRpt = CStr(h_arrGrpRptFilter(j)(v_arrRPTID(i))).Split("|")
                                    v_strAUTHSTR = v_arrRpt(6)
                                    v_strPrint = Mid(v_strAUTHSTR, 1, 1)
                                    v_strAdd = Mid(v_strAUTHSTR, 2, 1)

                                    v_blnPrint = IIf(v_strPrint = "Y", True, False)
                                    v_blnAdd = IIf(v_strAdd = "Y", True, False)

                                    'Combination right of groups
                                    v_blnPrint = (v_blnPrint Or v_blnPrePrint)
                                    v_blnAdd = (v_blnAdd Or v_blnPreAdd)

                                    'Assign right to previous right
                                    v_blnPrePrint = v_blnPrint
                                    v_blnPreAdd = v_blnAdd
                                End If
                            Next
                            'Get last right of groups
                            If Not v_arrRpt Is Nothing Then
                                If Not v_arrRpt.GetValue(0) Is Nothing Then
                                    v_strPrint = IIf(v_blnPrint = True, "Y", "N")
                                    v_strAdd = IIf(v_blnAdd = True, "Y", "N")
                                    v_strAUTHSTR = v_strPrint & v_strAdd
                                    v_arrRpt(6) = v_strAUTHSTR

                                    'Add right of user to dataset
                                    v_dsRpt.Tables(0).Rows.Add(v_arrRpt)
                                End If
                            End If
                        End If
                    End If
                Next
            End If


            'Build XML Data
            BuildXMLObjData(v_dsRpt, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Public Function GetInventory(ByRef pv_strObjMsg As String) As Long
        Try
            Dim v_strSQL As String, XMLDocument As New Xml.XmlDocument
            Dim v_DataAccess As New DataAccess, v_ds As DataSet

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            '?�ây là tên của Inventory
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            'Kiểm tra Sequence đã tồn tại chưa
            v_strSQL = "SELECT * FROM USER_OBJECTS WHERE OBJECT_NAME = '" & v_strClause & "'"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 0 Then
                'Tạo mới Sequence nếu chưa tồn tại
                v_strSQL = "CREATE SEQUENCE " & v_strClause
                v_DataAccess.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If

            'Lấy Inventory
            v_strSQL = "SELECT " & v_strClause & ".NEXTVAL FROM DUAL"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value = CStr(v_ds.Tables(0).Rows(0)(0))

            'Trả v? k�ết quả
            pv_strObjMsg = XMLDocument.InnerXml
            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function


    ''-------------------------------------------------------''
    ''-- Mục đích: Kiểm tra quy?n nh�ập GD của NSD hiện tại --''
    ''-- ?�ầu vào: pv_strTLTXCD: Mã GD                      --''
    ''-- ?�ầu ra: Mã lỗi trả v?                             --''
    ''-- T�ác giả: Nguyễn Nhân Thế                          --''
    ''-- Ghi chú: N/A                                      --''
    ''-------------------------------------------------------''
    Public Function CheckTransAllow(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.CheckTransAllow", v_strErrorMessage As String
        Dim v_DataAccess As New DataAccess
        Dim hUsrFilter As New Hashtable
        Dim h_arrGrpFilter() As Hashtable

        Try
            'Dim v_xmlDocument As New Xml.XmlDocument
            'v_xmlDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strTLID As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            'Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).InnerXml
            Dim v_strCMDALLOW As String
            Dim v_intNumGrp As Integer
            Dim v_arrClause(), v_strTlType As String

            'v_arrClause = v_strClause.Split("|")
            'v_strTlType = CStr(v_arrClause(0)).Trim
            'v_strTLTXCD = CStr(v_arrClause(1)).Trim

            'Dim v_strTeller As String
            'If v_strTlType <> String.Empty Then
            '    v_strTeller = Mid(v_strTlType, 1, 1)
            'End If

            If v_strTLID <> ADMIN_ID Then
                ''If current user is not a teller
                'If v_strTeller = "Y" Then

                'Else
                '    Return ERR_SA_CRTUSR_NOTTELLER
                'End If

                Dim v_strSQL As String
                Dim v_obj As New DataAccess

                'Get Modcode of transaction
                Dim v_strTXCODE, v_strMODCODE As String
                v_strTXCODE = v_strTLTXCD.Substring(0, 2)
                v_strSQL = "SELECT MODCODE FROM APPMODULES WHERE TXCODE='" & v_strTXCODE & "'"
                Dim v_dsModcode As DataSet
                v_dsModcode = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                'Get MODCODE of transaction
                If v_dsModcode.Tables(0).Rows.Count > 0 Then
                    v_strMODCODE = CStr(v_dsModcode.Tables(0).Rows(0)("MODCODE")).Trim
                End If

                'Get right of Modcode function of user
                v_strSQL = "SELECT A.CMDALLOW " _
                            & "FROM CMDMENU M, CMDAUTH A " _
                            & "WHERE M.CMDID = A.CMDCODE AND M.MODCODE = '" & v_strMODCODE & "' AND A.AUTHID = '" & v_strTLID & "' AND A.AUTHTYPE = 'U'" _
                            & "     AND CASE WHEN m.menutype = 'T' THEN 'T' WHEN M.MENUTYPE = 'A' AND instr(M.objname,'GENERALVIEW') >0 THEN 'T' ELSE m.menutype END = 'T'"
                Dim v_dsModRight As DataSet
                v_dsModRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                Dim v_strModCmdAllow As String
                If v_dsModRight.Tables(0).Rows.Count > 0 Then
                    v_strModCmdAllow = CStr(v_dsModRight.Tables(0).Rows(0)("CMDALLOW")).Trim
                    If v_strModCmdAllow = "Y" Then
                        v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE = 'T' AND AUTHTYPE='U' " &
                                    "   AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strTLID & "'"

                        Dim v_dsUsr As DataSet
                        v_dsUsr = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        'Get CMDALLOW of user
                        If v_dsUsr.Tables(0).Rows.Count > 0 Then
                            v_strCMDALLOW = CStr(v_dsUsr.Tables(0).Rows(0)("CMDALLOW")).Trim
                        End If

                    End If
                End If

                'Get the groups that user is in
                Dim v_strGrpSQL As String
                v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTLID & "' AND A.ACTIVE = 'Y'"
                Dim v_dsGrp As DataSet
                v_dsGrp = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
                Dim v_arrGrpCmdallow() As String
                If v_dsGrp.Tables(0).Rows.Count > 0 Then
                    v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                    Dim v_strGrpId As String
                    ReDim v_arrGrpCmdallow(v_intNumGrp - 1)
                    'Get name of groups
                    For i As Integer = 0 To v_intNumGrp - 1
                        v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                        'Get CMDAUTH of each group
                        'Get right of Modcode function of user
                        v_strSQL = "SELECT A.CMDALLOW " _
                                    & "FROM CMDMENU M, CMDAUTH A " _
                                    & "WHERE M.CMDID = A.CMDCODE AND M.MODCODE = '" & v_strMODCODE & "' AND A.AUTHID = '" & v_strGrpId & "' AND A.AUTHTYPE = 'G'" _
                                    & "     AND CASE WHEN m.menutype = 'T' THEN 'T' WHEN M.MENUTYPE = 'A' AND instr(M.objname,'GENERALVIEW') >0 THEN 'T' ELSE m.menutype END = 'T'"
                        Dim v_dsModGrpRight As DataSet
                        v_dsModGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                        Dim v_strModGrpCmdAllow As String
                        If v_dsModGrpRight.Tables(0).Rows.Count > 0 Then
                            v_strModCmdAllow = CStr(v_dsModGrpRight.Tables(0).Rows(0)("CMDALLOW")).Trim
                            If v_strModCmdAllow = "Y" Then
                                v_strSQL = "SELECT CMDALLOW FROM CMDAUTH WHERE CMDTYPE='T' AND AUTHTYPE='G' " &
                                            "   AND CMDCODE='" & v_strTLTXCD & "' AND AUTHID='" & v_strGrpId & "'"

                                Dim v_dsGrpRight As DataSet
                                v_dsGrpRight = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                                'Get CMDALLOW of group
                                If v_dsGrpRight.Tables(0).Rows.Count > 0 Then
                                    v_arrGrpCmdallow(i) = CStr(v_dsGrpRight.Tables(0).Rows(0)("CMDALLOW")).Trim
                                End If
                            End If
                        End If
                    Next
                End If

                'Check CMDALLOW of user and group
                'If user has right of this transaction, do not check right of group
                If v_strCMDALLOW = "Y" Then
                    Complete() 'ContextUtil.SetComplete()
                    Return ERR_SYSTEM_OK
                ElseIf v_strCMDALLOW = "N" Then
                    Rollback() 'ContextUtil.SetAbort()
                    Return ERR_SA_TRANSACT_CMDALLOW
                Else
                    'Check right of groups
                    Dim v_strGrpCmdallow As String = "N"
                    If v_intNumGrp > 0 Then
                        For i As Integer = 0 To v_intNumGrp - 1
                            If CStr(v_arrGrpCmdallow(i)) = "Y" Then
                                v_strGrpCmdallow = "Y"
                                Exit For
                            ElseIf CStr(v_arrGrpCmdallow(i)) = "N" Then
                                v_strGrpCmdallow = "N"
                            End If
                        Next
                    End If
                    If v_strGrpCmdallow = "Y" Then
                        Complete() 'ContextUtil.SetComplete()
                        Return ERR_SYSTEM_OK
                    Else
                        Rollback() 'ContextUtil.SetAbort()
                        Return ERR_SA_TRANSACT_CMDALLOW
                    End If
                End If
            End If
            Complete() 'ContextUtil.SetComplete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try

    End Function

    Public Function GetTellerRight(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New Xml.XmlDocument
            Dim v_strSQL, v_strArr(), v_strTellerId, v_strParentKey, v_strHashValue As String
            Dim v_arrGRPRIGHT() As String
            Dim v_intNumGrp, v_intNumFunc As Integer

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            v_strTellerId = Trim(v_strClause)

            'Get the groups that user is in
            Dim v_strGrpSQL As String
            v_strGrpSQL = "SELECT M.GRPID FROM TLGRPUSERS M, TLGROUPS A WHERE M.GRPID = A.GRPID AND M.TLID = '" & v_strTellerId & "' AND A.ACTIVE = 'Y'"
            Dim v_dsGrp As DataSet
            Dim v_objGrp As New DataAccess
            v_dsGrp = v_objGrp.ExecuteSQLReturnDataset(CommandType.Text, v_strGrpSQL)
            If v_dsGrp.Tables(0).Rows.Count > 0 Then
                v_intNumGrp = v_dsGrp.Tables(0).Rows.Count
                Dim v_strGrpId As String
                'Get name of groups
                For i As Integer = 0 To v_intNumGrp - 1
                    v_strGrpId = CStr(v_dsGrp.Tables(0).Rows(i)("GRPID")).Trim
                    'Get access right of each group and add rights to hash table
                    v_strSQL = "Select GRPRIGHT FROM TLGROUPS WHERE GRPID = '" & v_strGrpId & "'"

                    Dim v_dsGrpRight As DataSet
                    Dim v_objGrpRight As New DataAccess
                    v_dsGrpRight = v_objGrpRight.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'Add access right of user to hash table

                    ReDim Preserve v_arrGRPRIGHT(v_intNumGrp - 1)

                    If v_dsGrpRight.Tables(0).Rows.Count = 1 Then
                        v_arrGRPRIGHT(i) = IIf(v_dsGrpRight.Tables(0).Rows(0)("GRPRIGHT") Is DBNull.Value, "", v_dsGrpRight.Tables(0).Rows(0)("GRPRIGHT"))
                    End If

                    'h_arrGrpRptFilter(i) = hGrpFilter
                Next
            End If

            'Create dataset to contain right of teller
            Dim v_dsFunc As New DataSet
            v_dsFunc.Tables.Add()
            v_dsFunc.Tables(0).Columns.Add("GRPRIGHT")

            Dim v_arrFunc(0) As String

            'Check right of each function, 
            If v_intNumGrp > 0 Then
                Dim v_strGRPRIGHT As String
                Dim v_strMaker, v_strCashier, v_strOfficer, v_strChecker As String
                Dim v_blnMaker, v_blnCashier, v_blnOfficer, v_blnChecker As Boolean
                Dim v_blnPreMaker, v_blnPreCashier, v_blnPreOfficer, v_blnPreChecker As Boolean

                v_blnPreMaker = False
                v_blnPreCashier = False
                v_blnPreOfficer = False
                v_blnPreChecker = False

                If Not v_arrFunc Is Nothing Then
                    'v_arrFunc.s
                    'ReDim v_arrFunc(0)
                    v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                End If

                For i As Integer = 0 To v_intNumGrp - 1
                    If Not CStr(v_arrGRPRIGHT(i)) Is String.Empty Then
                        'Get data of row
                        v_strMaker = Mid(v_arrGRPRIGHT(i), 1, 1)
                        v_strCashier = Mid(v_arrGRPRIGHT(i), 2, 1)
                        v_strOfficer = Mid(v_arrGRPRIGHT(i), 3, 1)
                        v_strChecker = Mid(v_arrGRPRIGHT(i), 4, 1)

                        v_blnMaker = IIf(v_strMaker = "Y", True, False)
                        v_blnCashier = IIf(v_strCashier = "Y", True, False)
                        v_blnOfficer = IIf(v_strOfficer = "Y", True, False)
                        v_blnChecker = IIf(v_strChecker = "Y", True, False)

                        'Combination right of groups
                        v_blnMaker = (v_blnMaker Or v_blnPreMaker)
                        v_blnCashier = (v_blnCashier Or v_blnPreCashier)
                        v_blnOfficer = (v_blnOfficer Or v_blnPreOfficer)
                        v_blnChecker = (v_blnChecker Or v_blnPreChecker)

                        'Assign right to previous right
                        v_blnPreMaker = v_blnMaker
                        v_blnPreCashier = v_blnCashier
                        v_blnPreOfficer = v_blnOfficer
                        v_blnPreChecker = v_blnChecker
                        'Else
                        '    If Not v_arrFunc Is Nothing Then
                        '        'v_arrFunc.s
                        '        'ReDim v_arrFunc(0)
                        '        v_arrFunc.Clear(v_arrFunc, 0, v_arrFunc.Length)
                        '    End If
                    End If
                Next
                'Get last right of groups
                v_strMaker = IIf(v_blnMaker = True, "Y", "N")
                v_strCashier = IIf(v_blnCashier = True, "Y", "N")
                v_strOfficer = IIf(v_blnOfficer = True, "Y", "N")
                v_strChecker = IIf(v_blnChecker = True, "Y", "N")
                v_strGRPRIGHT = v_strMaker & v_strCashier & v_strOfficer & v_strChecker
                v_arrFunc(0) = v_strGRPRIGHT

                'Add right of user to dataset
                v_dsFunc.Tables(0).Rows.Add(v_arrFunc)

            End If

            'Build XML Data
            BuildXMLObjData(v_dsFunc, pv_strObjMsg)

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetGroupCareBy(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New Xml.XmlDocument
            Dim v_strSQL, v_strArr(), v_strParentKey, v_strHashValue As String
            Dim v_arrGRPRIGHT() As String
            Dim v_intNumGrp, v_intNumFunc As Integer

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            If v_strTellerId = ADMIN_ID Then
                'v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y' ORDER BY GRPID "
                v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y' ORDER BY (CASE WHEN GRPID =NVL((SELECT VARVALUE FROM SYSVAR WHERE GRNAME='DEFINED' AND VARNAME='DEFGRPCAREBY'),'0000')  THEN '0000' ELSE GRPID END) "
            Else
                'v_strSQL = "SELECT M.GRPID VALUE, N.GRPNAME DISPLAY FROM TLGRPUSERS M, TLGROUPS N WHERE M.TLID = '" & v_strTellerId & "' " _
                '                                        & " AND M.GRPID IN (SELECT GRPID FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y')" _
                '                                        & " AND M.GRPID = N.GRPID ORDER BY M.GRPID "
                v_strSQL = "SELECT M.GRPID VALUE, N.GRPNAME DISPLAY FROM TLGRPUSERS M, TLGROUPS N WHERE M.TLID = '" & v_strTellerId & "' " _
                                                        & " AND M.GRPID IN (SELECT GRPID FROM TLGROUPS WHERE GRPTYPE = '2' AND ACTIVE = 'Y')" _
                                                        & " AND M.GRPID = N.GRPID ORDER BY (CASE WHEN M.GRPID =NVL((SELECT VARVALUE FROM SYSVAR WHERE GRNAME='DEFINED' AND VARNAME='DEFGRPCAREBY'),'0000')  THEN '0000' ELSE M.GRPID END) "
            End If


            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetTellerGroup(ByRef pv_strObjMsg As String) As Long
        Try
            Dim XMLDocument As New Xml.XmlDocument
            Dim v_strSQL, v_strArr(), v_strParentKey, v_strHashValue As String
            Dim v_arrGRPRIGHT() As String
            Dim v_intNumGrp, v_intNumFunc As Integer

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            Dim v_strTellerId As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)

            If v_strTellerId = ADMIN_ID Then
                v_strSQL = "SELECT GRPID VALUE, GRPNAME DISPLAY FROM TLGROUPS WHERE ACTIVE = 'Y' ORDER BY GRPID "
            Else
                v_strSQL = "SELECT M.GRPID VALUE, N.GRPNAME DISPLAY FROM TLGRPUSERS M, TLGROUPS N WHERE M.TLID = '" & v_strTellerId & "' " _
                                                        & " AND M.GRPID IN (SELECT GRPID FROM TLGROUPS WHERE ACTIVE = 'Y')" _
                                                        & " AND M.GRPID = N.GRPID ORDER BY M.GRPID "
            End If


            Dim v_ds As DataSet
            Dim v_obj As New DataAccess
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            BuildXMLObjData(v_ds, pv_strObjMsg)

            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetKeyFldVal(ByVal pv_strTxMsg As String, ByVal pv_KeyFld As String) As String
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.brRouter.GetKeyFldVal", v_strErrorMessage As String
        Dim v_xmlDoc As New Xml.XmlDocument

        Try
            'Get KeyValue
            v_xmlDoc.LoadXml(pv_strTxMsg)
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strValue As String
            Dim v_strRefKeyVal As String = String.Empty
            v_nodeList = v_xmlDoc.SelectNodes("/TransactMessage/fields/entry")
            If pv_KeyFld.Length > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    With v_nodeList.Item(i)
                        v_strFLDNAME = .Attributes(gc_AtributeFLDNAME).Value.ToString
                        v_strValue = .InnerText
                        'Set RefkeyValue
                        If v_strFLDNAME = pv_KeyFld Then
                            v_strRefKeyVal = v_strValue
                            Exit For
                        End If
                    End With
                Next
            End If
            Return v_strRefKeyVal
        Catch ex As Exception
            Rollback()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

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

                v_strSQL = "SELECT * FROM TLPROFILES WHERE TLID='" & v_strTellerID & "' AND PIN=GENENCRYPTPASSWORD('" & v_strOldPass & "')"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If Not v_ds Is Nothing Then
                    If v_ds.Tables(0).Rows.Count > 0 Then
                        v_strSQL = "UPDATE TLPROFILES SET PIN=GENENCRYPTPASSWORD('" & v_strNewPass & "') WHERE TLID='" & v_strTellerID & "'"
                        v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
                        'v_lngErr = SendMessage2Host(pv_strObjMsg)
                        If v_lngErr <> ERR_SYSTEM_OK Then
                            Rollback()
                        Else
                            Complete()
                        End If
                        Return v_lngErr
                    Else
                        Rollback()
                        Return ERR_SA_CHANGEPASS_OLDPASSINVALID
                    End If
                Else
                    Rollback()
                    Return ERR_SA_CHANGEPASS_OLDPASSINVALID
                End If
            Else
                Rollback()
                Return ERR_SA_CHANGEPASS_INPUTINCORRECT
            End If

            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetErrorMessage(ByRef pv_strObjMsg As String) As Long
        Try
            Dim v_strSQL As String, XMLDocument As New Xml.XmlDocument
            Dim v_DataAccess As New DataAccess, v_ds As DataSet
            Dim v_strErrorMessage As String

            XMLDocument.LoadXml(pv_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = XMLDocument.DocumentElement.Attributes
            'Lay ma loi
            Dim v_strClause As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)

            v_strSQL = "SELECT ERRDESC, EN_ERRDESC FROM DEFERROR WHERE ERRNUM = " & v_strClause
            v_DataAccess.GetErrorMessage(v_strClause)
            CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value = CStr(v_ds.Tables(0).Rows(0)(0))

            'KQ Tra ve
            pv_strObjMsg = XMLDocument.InnerXml
            Complete() 'ContextUtil.SetComplete()
            Return 0
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            Throw ex
        End Try
    End Function

    Public Function PrintMessage(ByRef pv_strObjMsg As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Branch.Branch.PrintMessage", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument

        Try
            Dim v_objMessageLog As New MessageLog
            v_xmlDocument.LoadXml(pv_strObjMsg)

            'Lấy mã TellerID nhân viên quỹ để kiểm tra có phải là nhân viên quỹ thực sự không
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes

            'Lấy thông tin chi tiết v? giao d�ịch
            v_lngErrCode = v_objMessageLog.TransDetail(v_xmlDocument)
            v_attrColl = v_xmlDocument.DocumentElement.Attributes

            'Trả v? k�ết quả
            pv_strObjMsg = v_xmlDocument.InnerXml
            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function


#End Region
End Class
