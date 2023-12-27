Imports HostCommonLibrary
'Imports System.EnterpriseServices
Imports System.Reflection
Imports CoreBusiness
Imports System.Configuration
Imports System.Text
Imports System.Collections.Generic
Imports DataAccessLayer
Imports System.Xml
Imports System.Data

'TruongLD comment when convert
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Disabled), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class objRouter
    'TruongLD comment when convert
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Public Function Transfer(ByRef pv_strObjMessage As String) As Long
        Dim v_lngErrorCode As Long
        Dim v_xmlDocument As New XmlDocumentEx

        Try
            'Read object message 
            v_xmlDocument.LoadXml(pv_strObjMessage)

            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strObjectName As String
            Dim v_strActionFlag As String
            Dim v_strCmdInquiry As String
            Dim v_strSYSVAR As String, v_DataAccess As New DataAccess, v_ds As DataSet
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)

            If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
                v_strObjectName = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOBJNAME), Xml.XmlAttribute).Value)
            Else
                v_strObjectName = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeACTFLAG) Is Nothing) Then
                v_strActionFlag = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeACTFLAG), Xml.XmlAttribute).Value)
            Else
                v_strActionFlag = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY) Is Nothing) Then
                v_strCmdInquiry = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY), Xml.XmlAttribute).Value)
            Else
                v_strCmdInquiry = String.Empty
            End If
            If Trim(v_strObjectName) = OBJNAME_SY_AUTHENTICATION Then
                Dim v_objSystemAdmin As New SystemAdmin
                Dim v_objUtilObj As New utilRouter
                Dim v_objbrObj As New brRouter
                'Xử lý đặc biệt
                Dim v_strFuncName As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)
                Select Case Trim(v_strActionFlag)
                    Case gc_ActionInquiry
                        Select Case Trim(v_strFuncName)
                            'Begin Of VinhLD: Xử lý lấy thông tin phân quyền tập trung
                            Case "GetTreeMenuAll"
                                v_lngErrorCode = v_objSystemAdmin.GetTreeMenuAll(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetTreeMenuByUser"
                                v_lngErrorCode = v_objSystemAdmin.GetTreeMenuByUser(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetAuthorizationTicket"
                                v_lngErrorCode = v_objSystemAdmin.GetAuthorizationTicket(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetTellerProfile"
                                v_lngErrorCode = v_objSystemAdmin.GetTellerProfile(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetFunctionsByTellerId"
                                v_lngErrorCode = v_objSystemAdmin.GetFunctionsByTellerId(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetUserParentMenu"
                                v_lngErrorCode = v_objSystemAdmin.GetUserParentMenu(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetUserAdjustMenu"
                                v_lngErrorCode = v_objSystemAdmin.GetUserAdjustMenu(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetUserChildMenu"
                                v_lngErrorCode = v_objSystemAdmin.GetUserChildMenu(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetTransChildMenu"
                                v_lngErrorCode = v_objSystemAdmin.GetTransChildMenu(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetTellerRight"
                                v_lngErrorCode = v_objSystemAdmin.GetTellerRight(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "ChangeBOPassword"
                                v_lngErrorCode = v_objSystemAdmin.ChangeBOPassword(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetGroupCareBy"
                                v_lngErrorCode = v_objSystemAdmin.GetGroupCareBy(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetTellerGroup"
                                v_lngErrorCode = v_objSystemAdmin.GetTellerGroup(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetReportList"
                                v_lngErrorCode = v_objSystemAdmin.GetReportList(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode
                            Case "GetReportBatch"
                                v_lngErrorCode = v_objSystemAdmin.GetReportBatch(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback()
                                Else
                                    Complete()
                                End If
                                Return v_lngErrorCode

                            Case "GetMessage"
                                v_lngErrorCode = v_objbrObj.GetMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "CashMessage"
                                v_lngErrorCode = v_objbrObj.CashMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ApproveMessage"
                                v_lngErrorCode = v_objbrObj.ApproveMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "RejectMessage"
                                v_lngErrorCode = v_objbrObj.RejectMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "RefuseDeletingMessage"
                                v_lngErrorCode = v_objbrObj.RefuseDeletingMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "RefuseMessage"
                                v_lngErrorCode = v_objbrObj.RefuseMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "DeleteMessage"
                                v_lngErrorCode = v_objbrObj.DeleteMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "DeleteAutoGV"
                                v_lngErrorCode = v_objbrObj.DeleteAutoGV(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "DeletingMessage"
                                v_lngErrorCode = v_objbrObj.DeletingMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ApproveDeleteMessage"
                                v_lngErrorCode = v_objbrObj.ApproveDeleteMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "PrintMessage"
                                v_lngErrorCode = v_objbrObj.PrintMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "AsynchronousProcessing"
                                v_lngErrorCode = v_objbrObj.AsynchronousProcessing(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "CheckSETickSize"
                                v_lngErrorCode = v_objbrObj.CheckSETickSize(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                                'End Of VinhLD: Xử lý lấy thông tin phân quyền tập trung	

                            Case "GetHostData"
                                v_lngErrorCode = v_objSystemAdmin.GetHostData(pv_strObjMessage)
                            Case "ExecDBFunction"
                                'Execute database function
                                v_lngErrorCode = v_objSystemAdmin.ExecDBFunction(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetBankBalance"
                                'Execute database function
                                v_lngErrorCode = v_objSystemAdmin.CoreBankGetBalance(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "MapExchangeOrderBook"
                                'Map exchange order book
                                v_lngErrorCode = v_objSystemAdmin.MapExchangeOrderBook(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TransTLLOGEXT"
                                'Trans Log to TLLOGT for General view
                                v_lngErrorCode = v_objSystemAdmin.TransTLLOGEXT(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TransLog4DR"
                                'Trans Log to TLLOGT for General view
                                Dim v_objMessageLog As New MessageLog
                                v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
                                Dim v_XmlTranMsg As New Xml.XmlDocument
                                Dim v_strTranMsg As String
                                v_strTranMsg = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
                                v_XmlTranMsg.LoadXml(v_strTranMsg)

                                v_lngErrorCode = v_objMessageLog.TransLog4DR(v_XmlTranMsg)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TransUpdate4DR"
                                'Trans Log to TLLOGT for General view
                                Dim v_objMessageLog As New MessageLog
                                v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
                                Dim v_XmlTranMsg As New Xml.XmlDocument
                                Dim v_strTranMsg As String
                                v_strTranMsg = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
                                v_XmlTranMsg.LoadXml(v_strTranMsg)

                                v_lngErrorCode = v_objMessageLog.TransUpdate4DR(v_XmlTranMsg)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TransDelete4DR"
                                'Trans Log to TLLOGT for General view
                                Dim v_objMessageLog As New MessageLog
                                v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
                                Dim v_XmlTranMsg As New Xml.XmlDocument
                                Dim v_strTranMsg As String
                                v_strTranMsg = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
                                v_XmlTranMsg.LoadXml(v_strTranMsg)

                                v_lngErrorCode = v_objMessageLog.TransDelete4DR(v_XmlTranMsg)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "MapExchangeTradeBook"
                                'Map exchange order book
                                v_lngErrorCode = v_objSystemAdmin.MapExchangeTradeBook(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "MapExchangeStockTicker"
                                'Map exchange order book
                                v_lngErrorCode = v_objSystemAdmin.MapExchangeStockTicker(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BankHoldDirect"
                                'Xu li ket qua tra ve tu corebank
                                v_lngErrorCode = v_objSystemAdmin.CoreBankDirectHold(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BankFOHoldDirect"
                                'Xu li ket qua tra ve tu corebank
                                v_lngErrorCode = v_objSystemAdmin.CoreBankDirectFOHold(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BankHoldQueueExecute"
                                'Xu li ket qua tra ve tu corebank
                                v_lngErrorCode = v_objSystemAdmin.CoreBankHoldQueueExecute(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BankTrfReport"
                                'Xu ly gui bang ke
                                v_lngErrorCode = v_objSystemAdmin.CoreBankTransferReport(pv_strObjMessage)
                                Complete()
                                Return v_lngErrorCode
                            Case "ApproveTrfReport"
                                'Xu ly gui bang ke
                                v_lngErrorCode = v_objSystemAdmin.CoreBankTransferEODPreport(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BankGetReportSts"
                                v_lngErrorCode = v_objSystemAdmin.CoreBankGetReportSts(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BankGetTransList"
                                v_lngErrorCode = v_objSystemAdmin.CoreBankGetTransList(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TCDTGetBankList"
                                v_lngErrorCode = v_objSystemAdmin.CoreBankTCDTGetBankList(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TCDTTransferReconcide"
                                v_lngErrorCode = v_objSystemAdmin.CoreBankTCDTTransferReconcide(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TCDTSendReconcide"
                                v_lngErrorCode = v_objSystemAdmin.CoreBankTCDTSendReconcide(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TCDTSendBankRequest"
                                v_lngErrorCode = v_objSystemAdmin.CoreBankTCDTRequestTransfer(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TCDTReceiveBankRequest"
                                v_lngErrorCode = v_objSystemAdmin.CoreBankTCDTGetCreditList(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "TCDTGetTransferResult"
                                v_lngErrorCode = v_objSystemAdmin.CoreBankTCDTGetTransferResult(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ExecuteExternalJobs"
                                'Xu li ket qua tra ve tu corebank
                                v_lngErrorCode = v_objSystemAdmin.ExecuteExternalJobs(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BranchDeActive"
                                'Cập nhật trạng thái của Branch là DeActive
                                v_lngErrorCode = v_objSystemAdmin.BranchDeActive(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ResetCacheProcessing"
                                'Cập nhật trạng thái của Branch là DeActive
                                v_lngErrorCode = v_objSystemAdmin.ResetCacheProcessing(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ProcessGatewayMessage"
                                'Map exchange order book
                                v_lngErrorCode = v_objSystemAdmin.ProcessGatewayMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "SendOrderToCompany"
                                'Cập nhật trạng thái của Branch là DeActive
                                v_lngErrorCode = v_objSystemAdmin.SendOrderToCompany(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "SendGTCOrderToCompany"
                                'Cập nhật trạng thái của Branch là DeActive
                                v_lngErrorCode = v_objSystemAdmin.SendGTCOrderToCompany(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "SendOTCOrderToExchange"
                                'Cập nhật trạng thái của Branch là DeActive
                                v_lngErrorCode = v_objSystemAdmin.SendOTCOrderToExchange(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "ReceiveGXTrade"
                                v_lngErrorCode = v_objSystemAdmin.ReceiveGXTrade(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "AutoRunGeneralView"
                                'Cập nhật trạng thái của Branch là DeActive
                                v_lngErrorCode = v_objSystemAdmin.AutoRunGeneralView(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "AutoRunOTCGeneralView"
                                'Cập nhật trạng thái của Branch là DeActive
                                v_lngErrorCode = v_objSystemAdmin.AutoRunOTCGeneralView(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "DeleteAutoGV"
                                'Cập nhật trạng thái của Branch là DeActive
                                v_lngErrorCode = v_objSystemAdmin.DeleteAutoGV(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BranchActive"
                                'Cập nhật trạng thái của Branch là Active
                                v_lngErrorCode = v_objSystemAdmin.BranchActive(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "HostDeActive"
                                'Kiểm tra còn chi nhánh nào đang Active thì thông báo lại để confirm
                                v_lngErrorCode = v_objSystemAdmin.HostDeActive(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "HostActive"
                                'Ŀặt tham số Host là Active
                                v_lngErrorCode = v_objSystemAdmin.HostActive(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetInventory"
                                'Lấy mã khách hàng/số hợp đồng/số tài khoản lưu ký
                                v_lngErrorCode = v_objSystemAdmin.GetInventory(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ChangeBOPassword"
                                v_lngErrorCode = v_objUtilObj.ChangeBOPassword(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "CheckCorrectionOrderStatus"
                                v_lngErrorCode = v_objUtilObj.CheckCorrectionOrderStatus(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "CheckOrderStatus"
                                ''Kiem tra trang thai lenh doc di
                                'v_lngErrorCode = v_objSystemAdmin.CheckOrderStatus(pv_strObjMessage)
                                'If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                '    Rollback() 'ContextUtil.SetAbort()
                                'Else
                                '    Complete() 'ContextUtil.SetComplete()
                                'End If
                                'Return v_lngErrorCode
                                'Kiem tra trang thai lenh doc di
                                v_lngErrorCode = v_objUtilObj.CheckOrderStatus(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "RefuseCorrectionOrder"
                                v_lngErrorCode = v_objUtilObj.RefuseCorrectionOrder(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "InsertOrderQueue"
                                ''Kiem tra trang thai lenh doc di
                                'v_lngErrorCode = v_objSystemAdmin.InsertOrderQueue(pv_strObjMessage)
                                'If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                '    Rollback() 'ContextUtil.SetAbort()
                                'Else
                                '    Complete() 'ContextUtil.SetComplete()
                                'End If
                                'Return v_lngErrorCode
                                'Kiem tra trang thai lenh doc di
                                v_lngErrorCode = v_objUtilObj.InsertOrderQueue(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "CancelOrderSending"
                                v_lngErrorCode = v_objUtilObj.CancelOrderSending(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "CancelOrderCorrectionSending"
                                v_lngErrorCode = v_objUtilObj.CancelOrderCorrectionSending(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "UpdateOrderStatus"
                                ''Kiem tra trang thai lenh doc di
                                'v_lngErrorCode = v_objSystemAdmin.UpdateOrderStatus(pv_strObjMessage)
                                'If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                '    Rollback() 'ContextUtil.SetAbort()
                                'Else
                                '    Complete() 'ContextUtil.SetComplete()
                                'End If
                                'Return v_lngErrorCode
                                'Kiem tra trang thai lenh doc di
                                v_lngErrorCode = v_objUtilObj.UpdateOrderStatus(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "PutthroughReject"
                                v_lngErrorCode = v_objUtilObj.PutthroughReject(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "PutthroughReject"
                                v_lngErrorCode = v_objUtilObj.PutthroughReject(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "PutthroughConfirm"
                                v_lngErrorCode = v_objUtilObj.PutthroughConfirm(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode


                            Case "PutthroughAdvActive"
                                v_lngErrorCode = v_objUtilObj.PutthroughAdvActive(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "PutthroughAdvAdd"
                                v_lngErrorCode = v_objUtilObj.PutthroughAdvAdd(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "PutthroughAdvCancel"
                                v_lngErrorCode = v_objUtilObj.PutthroughAdvCancel(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "PutthroughAdvDelete"
                                v_lngErrorCode = v_objUtilObj.PutthroughAdvDelete(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "PutthroughRejectNotConfirm"
                                v_lngErrorCode = v_objUtilObj.PutthroughRejectNotConfirm(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode


                            Case "CreateOrderCustodyChange"
                                v_lngErrorCode = v_objUtilObj.CreateOrderCustodyChange(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetSystemTime"
                                'Kiem tra trang thai lenh doc di
                                v_lngErrorCode = v_objSystemAdmin.GetSystemTime(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "CheckTradeBuySell"
                                v_lngErrorCode = v_objSystemAdmin.CheckTradeBuySell(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BuyFeeTransfer"
                                v_lngErrorCode = v_objSystemAdmin.BuyFeeTransfer(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ExecuteCA3384"
                                v_lngErrorCode = v_objSystemAdmin.ExecuteCA3384(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ExecuteCA3386"
                                v_lngErrorCode = v_objSystemAdmin.ExecuteCA3386(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ExecuteCA3350"
                                v_lngErrorCode = v_objSystemAdmin.ExecuteCA3350(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ExecuteCA3350DF"
                                v_lngErrorCode = v_objSystemAdmin.ExecuteCA3350DF(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ProcessClearOrder"
                                v_lngErrorCode = v_objSystemAdmin.ProcessClearOrder(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ProcessFeeCalculate"
                                v_lngErrorCode = v_objSystemAdmin.ProcessFeeCalculate(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ExecuteRM8879"
                                v_lngErrorCode = v_objSystemAdmin.ExecuteRM8879(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ExecuteRM8879DF"
                                v_lngErrorCode = v_objSystemAdmin.ExecuteRM8879DF(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "GetUserParentMenu"
                                v_lngErrorCode = v_objbrObj.GetUserParentMenu(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetUserAdjustMenu"
                                v_lngErrorCode = v_objbrObj.GetUserAdjustMenu(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetUserChildMenu"
                                v_lngErrorCode = v_objbrObj.GetUserChildMenu(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetTransChildMenu"
                                v_lngErrorCode = v_objbrObj.GetTransChildMenu(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetTellerRight"
                                v_lngErrorCode = v_objbrObj.GetTellerRight(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ChangeBOPassword"
                                v_lngErrorCode = v_objbrObj.ChangeBOPassword(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetGroupCareBy"
                                v_lngErrorCode = v_objbrObj.GetGroupCareBy(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetTellerGroup"
                                v_lngErrorCode = v_objbrObj.GetTellerGroup(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetInventory"
                                v_lngErrorCode = v_objbrObj.GetInventory(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetMessage"
                                v_lngErrorCode = v_objbrObj.GetMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "CashMessage"
                                v_lngErrorCode = v_objbrObj.CashMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ApproveMessage"
                                v_lngErrorCode = v_objbrObj.ApproveMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "RejectMessage"
                                v_lngErrorCode = v_objbrObj.RejectMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "RefuseDeletingMessage"
                                v_lngErrorCode = v_objbrObj.RefuseDeletingMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "RefuseMessage"
                                v_lngErrorCode = v_objbrObj.RefuseMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "DeleteMessage"
                                v_lngErrorCode = v_objbrObj.DeleteMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "DeleteAutoGV"
                                v_lngErrorCode = v_objbrObj.DeleteAutoGV(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "DeletingMessage"
                                v_lngErrorCode = v_objbrObj.DeletingMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ApproveDeleteMessage"
                                v_lngErrorCode = v_objbrObj.ApproveDeleteMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "PrintMessage"
                                v_lngErrorCode = v_objbrObj.PrintMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "AutoRunGeneralView"
                                v_lngErrorCode = v_objSystemAdmin.AutoRunGeneralView(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "AutoRunOTCGeneralView"
                                v_lngErrorCode = v_objSystemAdmin.AutoRunOTCGeneralView(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "ProcessGatewayMessage"
                                v_lngErrorCode = v_objSystemAdmin.ProcessGatewayMessage(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "AsynchronousProcessing"
                                v_lngErrorCode = v_objbrObj.AsynchronousProcessing(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "SendOrderToCompany"
                                v_lngErrorCode = v_objSystemAdmin.SendOrderToCompany(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "SendGTCOrderToCompany"
                                v_lngErrorCode = v_objSystemAdmin.SendGTCOrderToCompany(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "SendOTCOrderToExchange"
                                v_lngErrorCode = v_objSystemAdmin.SendOTCOrderToExchange(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "ResetCacheProcessing"
                                v_lngErrorCode = v_objSystemAdmin.ResetCacheProcessing(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode

                            Case "BranchDeActive"
                                v_lngErrorCode = v_objSystemAdmin.BranchDeActive(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "BranchActive"
                                v_lngErrorCode = v_objSystemAdmin.BranchActive(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "CheckSETickSize"
                                v_lngErrorCode = v_objbrObj.CheckSETickSize(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "CreateOrderCustodyChange"
                                v_lngErrorCode = v_objUtilObj.CreateOrderCustodyChange(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "InsertOrderQueue"
                                v_lngErrorCode = v_objUtilObj.CreateOrderCustodyChange(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetReportList"
                                v_lngErrorCode = v_objbrObj.GetReportList(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                            Case "GetReportBatch"
                                v_lngErrorCode = v_objbrObj.GetReportBatch(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                                'End TruongLD
                        End Select
                    Case gc_ActionAdd

                    Case gc_ActionEdit

                    Case gc_ActionDelete
                    Case gc_ActionExec
                        v_lngErrorCode = v_objSystemAdmin.CoreExec(v_xmlDocument)
                        If v_lngErrorCode <> ERR_SYSTEM_OK Then
                            Rollback() 'ContextUtil.SetAbort()
                        Else
                            Complete() 'ContextUtil.SetComplete()
                        End If
                        Return v_lngErrorCode
                    Case gc_ActionBatch
                        Select Case v_strFuncName
                            Case "BatchExecute"
                                'Kích hoạt chức năng chạy Batch
                                v_lngErrorCode = v_objSystemAdmin.BranchExecute(pv_strObjMessage)
                                If v_lngErrorCode <> ERR_SYSTEM_OK Then
                                    Rollback() 'ContextUtil.SetAbort()
                                Else
                                    Complete() 'ContextUtil.SetComplete()
                                End If
                                Return v_lngErrorCode
                        End Select

                End Select
            Else
                'Dim v_objMaintain As CoreBusiness.IMaster
                ''Xử lý chung cho các Object kế thừa từ objMaster

                Select Case v_strObjectName
                    Case OBJNAME_SA_BRGRPPARAM
                        v_strObjectName = "SA.BRGRPPARAM"
                    Case OBJNAME_SA_TLGRPAFTYPE
                        v_strObjectName = "SA.TLGRPAFTYPE"
                    Case OBJNAME_SA_BRGRP
                        v_strObjectName = "SA.BRGRP"
                    Case OBJNAME_SA_SBFXRT
                        v_strObjectName = "SA.SBFXRT"
                    Case OBJNAME_SA_DEFERROR
                        v_strObjectName = "SA.DEFERROR"
                    Case OBJNAME_SA_RPTMASTER
                        v_strObjectName = "SA.RPTMASTER"
                    Case OBJNAME_SA_ALLCODE
                        v_strObjectName = "SA.ALLCODE"
                    Case OBJNAME_SA_FEEMASTER
                        v_strObjectName = "SA.FEEMASTER"
                    Case OBJNAME_SA_FEEMAP
                        v_strObjectName = "SA.FEEMAP"
                    Case OBJNAME_SA_TLPROFILES
                        v_strObjectName = "SA.TLPROFILES"
                    Case OBJNAME_SA_TLGROUPS
                        v_strObjectName = "SA.TLGROUPS"
                    Case OBJNAME_SA_SBSECURITIES
                        v_strObjectName = "SA.SBSECURITIES"
                    Case OBJNAME_SA_BATCH
                        v_strObjectName = "SA.SBBATCHCTL"
                    Case OBJNAME_SA_CLDR
                        v_strObjectName = "SA.SBCLDR"
                    Case OBJNAME_SA_ICCF
                        v_strObjectName = "SA.ICCF"
                    Case OBJNAME_SA_ICCFTYPEDEF
                        v_strObjectName = "SA.ICCFTYPEDEF"
                    Case OBJNAME_SA_ICCFTIER
                        v_strObjectName = "SA.ICCFTIER"
                    Case OBJNAME_SA_ICCFRULES
                        v_strObjectName = "SA.ICCFRULES"
                    Case OBJNAME_SA_ICCFMAP
                        v_strObjectName = "SA.ICCFMAP"
                    Case OBJNAME_SA_ICCFTX
                        v_strObjectName = "SA.ICCFTX"
                    Case OBJNAME_SA_RISK_ICCF
                        v_strObjectName = "SA.RISK_ICCF"
                    Case OBJNAME_SA_CMDAUTH
                        v_strObjectName = "SA.CMDAUTH"
                    Case OBJNAME_SA_TLAUTH
                        v_strObjectName = "SA.TLAUTH"
                    Case OBJNAME_SA_TLGRPUSERS
                        v_strObjectName = "SA.TLGRPUSERS"
                    Case OBJNAME_SA_ISSUER_MEMBER
                        v_strObjectName = "SA.ISSUER_MEMBER"
                    Case OBJNAME_CF_CFRELATION
                        v_strObjectName = "CF.CFRELATION"
                    Case OBJNAME_SA_SECURITIES_INFO
                        v_strObjectName = "SA.SECURITIES_INFO"
                    Case OBJNAME_CF_USERLIMIT
                        v_strObjectName = "CF.USERLIMIT"
                    Case OBJNAME_CF_CFMAST
                        v_strObjectName = "CF.CFMAST"
                    Case OBJNAME_CF_CFLINK
                        v_strObjectName = "CF.CFLINK"
                    Case OBJNAME_CF_CFAUTH
                        v_strObjectName = "CF.CFAUTH"
                    Case OBJNAME_CF_CFCONTACT
                        v_strObjectName = "CF.CFCONTACT"
                    Case OBJNAME_CF_AFTYPE
                        v_strObjectName = "CF.AFTYPE"
                    Case OBJNAME_CF_AFMAST
                        v_strObjectName = "CF.AFMAST"
                    Case OBJNAME_CA_CAMAST
                        v_strObjectName = "CA.CAMAST"
                    Case OBJNAME_CA_CASCHD
                        v_strObjectName = "CA.CASCHD"
                    Case OBJNAME_CI_CIMAST
                        v_strObjectName = "CI.CIMAST"
                    Case OBJNAME_CI_CITYPE
                        v_strObjectName = "CI.CITYPE"
                    Case OBJNAME_SA_ISSUERS
                        v_strObjectName = "SA.ISSUERS"
                    Case OBJNAME_GL_GLMAST
                        v_strObjectName = "GL.GLMAST"
                    Case OBJNAME_GL_GLBANK
                        v_strObjectName = "GL.GLBANK"
                    Case OBJNAME_GL_FA
                        v_strObjectName = "GL.FA"
                    Case OBJNAME_GL_GLREF
                        v_strObjectName = "GL.GLREF"
                    Case OBJNAME_SA_IRRATE
                        v_strObjectName = "SA.IRRATE"
                    Case OBJNAME_LN_LNTYPE
                        v_strObjectName = "LN.LNTYPE"
                    Case OBJNAME_SA_SBCURRENCY
                        v_strObjectName = "SA.SBCURRENCY"
                    Case OBJNAME_OD_OOD
                        v_strObjectName = "OD.OOD"
                    Case OBJNAME_OD_IOD
                        v_strObjectName = "OD.IOD"
                    Case OBJNAME_OD_ODTYPE
                        v_strObjectName = "OD.ODTYPE"
                    Case OBJNAME_OD_ODMAST
                        v_strObjectName = "OD.ODMAST"
                    Case OBJNAME_OD_SECINFO
                        v_strObjectName = "OD.SECINFO"
                    Case OBJNAME_SA_SECURITIES_TICKSIZE
                        v_strObjectName = "SA.SECURITIES_TICKSIZE"
                    Case OBJNAME_SE_CLMAST
                        v_strObjectName = "SE.CLMAST"
                    Case OBJNAME_SE_CLTYPE
                        v_strObjectName = "SE.CLTYPE"
                    Case OBJNAME_SE_SBSECURITIES
                        v_strObjectName = "SA.SBSECURITIES"
                    Case OBJNAME_SE_SETYPE
                        v_strObjectName = "SE.SETYPE"
                    Case OBJNAME_SA_STCSE
                        v_strObjectName = "SA.STCSE"
                    Case OBJNAME_SA_STCTICKSIZE
                        v_strObjectName = "SA.STCTICKSIZE"
                    Case OBJNAME_SE_SEMAST
                        v_strObjectName = "SE.SEMAST"
                    Case OBJNAME_RP_RPTYPE
                        v_strObjectName = "RP.RPTYPE"
                    Case OBJNAME_RP_RPMAST
                        v_strObjectName = "RP.RPMAST"
                    Case OBJNAME_SA_TRADING_RESULT
                        v_strObjectName = "SA.TRADING_RESULT"
                    Case OBJNAME_OD_STSCHD
                        v_strObjectName = "OD.STSCHD"
                    Case OBJNAME_CF_CFSIGN
                        v_strObjectName = "CF.CFSIGN"
                    Case OBJNAME_CI_ICCFTYPEDEF
                        v_strObjectName = "SA.ICCFTYPEDEF"
                    Case OBJNAME_CI_ICCFTIER
                        v_strObjectName = "SA.ICCFTIER"
                    Case OBJNAME_SE_ICCFTYPEDEF
                        v_strObjectName = "SA.ICCFTYPEDEF"
                    Case OBJNAME_SE_ICCFTIER
                        v_strObjectName = "SA.ICCFTIER"
                    Case OBJNAME_RP_ICCFTYPEDEF
                        v_strObjectName = "SA.ICCFTYPEDEF"
                    Case OBJNAME_RP_ICCFTIER
                        v_strObjectName = "SA.ICCFTIER"
                    Case OBJNAME_OD_ICCFTYPEDEF
                        v_strObjectName = "SA.ICCFTYPEDEF"
                    Case OBJNAME_OD_ICCFTIER
                        v_strObjectName = "SA.ICCFTIER"
                    Case OBJNAME_SA_RISK_INFO
                        v_strObjectName = "SA.RISK"
                    Case OBJNAME_SA_SYSVAR
                        v_strObjectName = "SA.SYSVAR"
                    Case OBJNAME_SA_DEPOSIT_MEMBER
                        v_strObjectName = "SA.DEPOSIT_MEMBER"
                    Case OBJNAME_CF_RPTAFMAST
                        v_strObjectName = "CF.RPTAFMAST"
                    Case OBJNAME_RM_GENERAL
                        v_strObjectName = "SA.SYSVAR"
                    Case OBJNAME_CF_REGTYPE
                        v_strObjectName = "CF.REGTYPE"
                    Case OBJNAME_SA_CFOTHERACC
                        v_strObjectName = "SA.CFOTHERACC"
                    Case OBJNAME_CF_ICCFTYPEDEF
                        v_strObjectName = "SA.ICCFTYPEDEF"
                    Case OBJNAME_CF_ICCFTIER
                        v_strObjectName = "SA.ICCFTIER"
                    Case OBJNAME_LM_LMTYPE
                        v_strObjectName = "LM.LMTYPE"
                    Case OBJNAME_LM_LMMAST
                        v_strObjectName = "LM.LMMAST"
                    Case OBJNAME_CL_CLTYPE
                        v_strObjectName = "CL.CLTYPE"
                    Case OBJNAME_CL_CLMAST
                        v_strObjectName = "CL.CLMAST"
                    Case OBJNAME_GR_GRTYPE
                        v_strObjectName = "GR.GRTYPE"
                    Case OBJNAME_GR_GRMAST
                        v_strObjectName = "GR.GRMAST"
                    Case OBJNAME_SE_SELINK
                        v_strObjectName = "SE.SELINK"
                    Case OBJNAME_SA_SEGROUPS
                        v_strObjectName = "SA.SEGROUPS"
                    Case OBJNAME_SA_SEGRPLIST
                        v_strObjectName = "SA.SEGRPLIST"
                    Case OBJNAME_SA_AFSEGRP
                        v_strObjectName = "SA.AFSEGRP"
                    Case OBJNAME_SA_LOOKUP
                        v_strObjectName = "SA.LOOKUP"
                    Case OBJNAME_FO_FOMAST
                        v_strObjectName = "FO.FOMAST"
                    Case OBJNAME_FO_USERLOGIN
                        v_strObjectName = "FO.USERLOGIN"
                    Case OBJNAME_SY_SEARCHFLD
                        v_strObjectName = "SA.SEARCHFLD"
                    Case OBJNAME_CF_OTRIGHT
                        v_strObjectName = "CF.OTRIGHT"
                    Case OBJNAME_SA_USERVALIDRULE
                        v_strObjectName = "SA.USERVALIDRULE"
                    Case OBJNAME_SA_RIGHTCOPY
                        v_strObjectName = "SA.RIGHTCOPY"
                    Case OBJNAME_DD_DDMAST
                        v_strObjectName = "DD.DDMAST"
                    Case OBJNAME_SA_FILEUPLOAD
                        v_strObjectName = "SA.FILEUPLOAD"
                    Case OBJNAME_SA_FLDMASTER
                        v_strObjectName = "SA.FLDMASTER"
                    Case OBJNAME_FA_SBACTIDTL
                        v_strObjectName = "FA.SBACTIDTL"
                    Case OBJNAME_SY_USERLOGIN
                        v_strObjectName = "SY.USERLOGIN"
                End Select


                ''Thực hiện các bước xử lý
                'If Not (v_objMaintain Is Nothing) Then
                '    Select Case v_strActionFlag
                '        Case gc_ActionAdd
                '            v_lngErrorCode = v_objMaintain.Add(v_xmlDocument)
                '        Case gc_ActionEdit
                '            v_lngErrorCode = v_objMaintain.Edit(v_xmlDocument)
                '        Case gc_ActionDelete
                '            v_lngErrorCode = v_objMaintain.Delete(v_xmlDocument)
                '        Case gc_ActionInquiry
                '            v_lngErrorCode = v_objMaintain.Inquiry(v_xmlDocument)
                '        Case gc_ActionAdhoc
                '            v_lngErrorCode = v_objMaintain.Adhoc(v_xmlDocument)
                '    End Select
                '    pv_strObjMessage = v_xmlDocument.InnerXml
                'End If
                'Kiem tra objname xem dung mode nao
                Dim v_strSQL, v_strRUNMOD, v_strPCKNAME As String
                v_strSQL = "SELECT OBJNAME  FROM OBJMASTER WHERE RUNMOD='DB' AND OBJNAME = '" & v_strObjectName & "'"
                v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strRUNMOD = "DB"
                Else
                    v_strRUNMOD = "NET"
                End If


                'If v_strRUNMOD = "DB" And v_strActionFlag <> "INQUIRY" Then
                '    'Sua lai luong approve thuc hien tuan tu cho tung foem con
                '    If v_strActionFlag = "APPROVE" Then
                '        v_lngErrorCode = DB_ObjTranfer_APPROVE(pv_strObjMessage, v_strObjectName)
                '    Else
                '        'Upload file type Blob
                '        'tiennv
                '        Dim dicParamBlob As Dictionary(Of String, String) = New Dictionary(Of String, String)()
                '        Dim autoId As String = Nothing
                '        ProcessDataBlob(pv_strObjMessage, dicParamBlob, autoId)
                '        v_lngErrorCode = DB_ObjTranfer(pv_strObjMessage, v_strObjectName) 'old

                '        If (v_strActionFlag = "ADD" Or v_strActionFlag = "EDIT") And v_lngErrorCode = 0 Then
                '            v_DataAccess.UpdateBlobData(dicParamBlob, autoId, v_strObjectName)
                '        End If

                '    End If
                'Else

                Dim v_strDLL As String = v_strObjectName.Substring(0, v_strObjectName.IndexOf("."))
                v_strDLL = v_strObjectName.Substring(0, v_strObjectName.IndexOf("."))
                Dim oAssembly As System.Reflection.Assembly = System.Reflection.Assembly.Load(v_strDLL)
                Dim aType As System.Type = oAssembly.GetType(v_strObjectName)
                'aType = Type.GetTypeFromProgID(v_strObjectName)
                If Not aType Is Nothing Then
                    Dim obj, retval As Object
                    obj = Activator.CreateInstance(aType)
                    'Dim args() As Object = {v_xmlDocument}
                    Dim args() As Object = {pv_strObjMessage}

                    Select Case v_strActionFlag
                        Case gc_ActionAdd
                            retval = aType.InvokeMember("Add", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                        Case gc_ActionEdit
                            retval = aType.InvokeMember("Edit", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                        Case gc_ActionDelete
                            retval = aType.InvokeMember("Delete", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                        Case gc_ActionInquiry
                            retval = aType.InvokeMember("Inquiry", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                        Case gc_ActionAdhoc
                            retval = aType.InvokeMember("Adhoc", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                            'AnhVT Retro Maintenance Approval
                        Case gc_ActionApprove
                            retval = aType.InvokeMember("Approve", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)
                            'TungNT added , xu ly truong hop duyet bang ke, tien hanh day di luon
                            If CType(retval, Long) = ERR_SYSTEM_OK Then
                                If v_strObjectName.Trim().ToUpper() = "SA.CRBTRFLOG" Then
                                    Dim v_objSystemAdmin As New SystemAdmin
                                    retval = v_objSystemAdmin.CoreBankTransferEODPreport(pv_strObjMessage)
                                End If
                            End If
                            'End
                        Case gc_ActionReject
                            retval = aType.InvokeMember("Reject", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)
                    End Select
                    v_lngErrorCode = CType(retval, Long)
                    'pv_strObjMessage = CType(args(0), XmlDocumentEx).InnerXml
                    pv_strObjMessage = CType(args(0), String)
                Else
                    'If v_strActionFlag = gc_ActionInquiry Then
                    '    Dim obj, retval As Object
                    '    Dim args() As Object = {pv_strObjMessage}
                    '    oAssembly = System.Reflection.Assembly.Load("SA")
                    '    aType = oAssembly.GetType("SA.SYSVAR")
                    '    obj = Activator.CreateInstance(aType)
                    '    retval = aType.InvokeMember("Inquiry", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)
                    '    v_lngErrorCode = CType(retval, Long)
                    '    pv_strObjMessage = CType(args(0), String)
                    'Else
                    'Exception Table without Class
                    Dim retval As Object
                    Dim obj As New Maintain()
                    obj.ATTR_TABLE = v_strObjectName.Substring(v_strObjectName.IndexOf(".") + 1, v_strObjectName.Length - (v_strObjectName.IndexOf(".") + 1))
                    aType = GetType(CoreBusiness.Maintain)

                    Dim dicParamBlob As Dictionary(Of String, String) = New Dictionary(Of String, String)()
                    Dim autoId As String = Nothing
                    ProcessDataBlob(pv_strObjMessage, dicParamBlob, autoId)

                    Dim args() As Object = {pv_strObjMessage}

                    Select Case v_strActionFlag
                        Case gc_ActionAdd
                            retval = aType.InvokeMember("Add", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                            
                        Case gc_ActionEdit
                            retval = aType.InvokeMember("Edit", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                        Case gc_ActionDelete
                            retval = aType.InvokeMember("Delete", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                        Case gc_ActionInquiry
                            retval = aType.InvokeMember("Inquiry", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                        Case gc_ActionAdhoc
                            retval = aType.InvokeMember("Adhoc", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                            'AnhVT Retro Maintenance Approval
                        Case gc_ActionApprove
                            retval = aType.InvokeMember("Approve", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)

                        Case gc_ActionReject
                            retval = aType.InvokeMember("Reject", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)
                    End Select

                    If (v_strActionFlag = "ADD" Or v_strActionFlag = "EDIT") And v_lngErrorCode = 0 Then
                        v_DataAccess.UpdateBlobData(dicParamBlob, autoId, v_strObjectName)
                    End If

                    v_lngErrorCode = CType(retval, Long)
                    'pv_strObjMessage = CType(args(0), XmlDocumentEx).InnerXml
                    pv_strObjMessage = CType(args(0), String)
                End If
            End If
            'End If
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
            Else
                Complete() 'ContextUtil.SetComplete()
            End If
            Return v_lngErrorCode
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Public Function BuildXMLMarketData(ByVal pv_ds As DataSet,
                                   ByRef pv_strObjectMessage As String,
                                   Optional ByVal pv_dsOldInput As DataSet = Nothing,
                                   Optional ByVal pv_intFlag As Integer = 1) As Long
        Dim v_XmlDocument As New Xml.XmlDocument
        Dim dataElement As Xml.XmlElement
        Dim entryNode As Xml.XmlNode
        Dim v_attrFLDNAME, v_attrFLDTYPE, v_attrOLDVAL As Xml.XmlAttribute
        Dim v_strValue As String

        v_XmlDocument.LoadXml(pv_strObjectMessage)
        Try
            If pv_intFlag <> ExecuteFlag.Edit Then
                '1. Addnew
                If pv_ds.Tables(0).Rows.Count > 0 Then
                    'Dim v_strXMLBuilder As New StringBuilder("<DataBuilder>")
                    Dim v_strXMLBuilder As New StringBuilder
                    Dim v_xmlBuilder As New Xml.XmlDocument
                    Dim nodeItem As Xml.XmlNode, nodeList As Xml.XmlNodeList

                    For v_int As Integer = 0 To pv_ds.Tables(0).Rows.Count - 1
                        v_strXMLBuilder.Append("<ObjData>")
                        For v_intColumn As Integer = 0 To pv_ds.Tables(0).Columns.Count - 1
                            v_strXMLBuilder.Append("<Entry fldname='")
                            v_strXMLBuilder.Append(pv_ds.Tables(0).Columns(v_intColumn).ColumnName)
                            v_strXMLBuilder.Append("' fldtype='")
                            v_strXMLBuilder.Append(pv_ds.Tables(0).Columns(v_intColumn).DataType.ToString)
                            v_strXMLBuilder.Append("' oldval='")
                            If Not IsDBNull(pv_ds.Tables(0).Rows(v_int)(v_intColumn)) Then
                                If pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name = GetType(System.DateTime).Name _
                                    And pv_intFlag = ExecuteFlag.AddNew Then
                                    v_strXMLBuilder.Append(Format(pv_ds.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE_TIME))
                                Else
                                    v_strValue = CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
                                    v_strValue = v_strValue.Replace("&", "&amp;")
                                    v_strValue = v_strValue.Replace("'", "&apos;")
                                    v_strValue = v_strValue.Replace("""", "&quot;")
                                    v_strValue = v_strValue.Replace("<", "&lt;")
                                    v_strValue = v_strValue.Replace(">", "&gt;")
                                    v_strXMLBuilder.Append(v_strValue)
                                    'v_strXMLBuilder.Append(CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn)))
                                End If
                            End If
                            v_strXMLBuilder.Append("'>")
                            If Not IsDBNull(pv_ds.Tables(0).Rows(v_int)(v_intColumn)) Then
                                If pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name = GetType(System.DateTime).Name _
                                    And pv_intFlag = ExecuteFlag.AddNew Then
                                    v_strXMLBuilder.Append(Format(pv_ds.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE_TIME))
                                Else
                                    v_strValue = CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
                                    v_strValue = v_strValue.Replace("&", "&amp;")
                                    v_strValue = v_strValue.Replace("'", "&apos;")
                                    v_strValue = v_strValue.Replace("""", "&quot;")
                                    v_strValue = v_strValue.Replace("<", "&lt;")
                                    v_strValue = v_strValue.Replace(">", "&gt;")
                                    v_strXMLBuilder.Append(v_strValue)
                                    'v_strXMLBuilder.Append(CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn)))
                                End If
                            End If
                            v_strXMLBuilder.Append("</Entry>")
                        Next
                        v_strXMLBuilder.Append("</ObjData>")

                        v_xmlBuilder.LoadXml(v_strXMLBuilder.ToString)
                        nodeItem = v_XmlDocument.ImportNode(v_xmlBuilder.SelectSingleNode("/ObjData"), True)
                        v_XmlDocument.DocumentElement.AppendChild(nodeItem)
                        v_strXMLBuilder.Remove(0, v_strXMLBuilder.Length)
                    Next
                    'v_strXMLBuilder.Append("</DataBuilder>")
                    'v_xmlBuilder.LoadXml(v_strXMLBuilder.ToString)
                    'nodeList = v_xmlBuilder.SelectNodes("/DataBuilder/ObjData")
                    'For i As Integer = 0 To nodeList.Count - 1
                    '    nodeItem = v_XmlDocument.ImportNode(nodeList.Item(i), False)
                    '    v_XmlDocument.DocumentElement.AppendChild(nodeItem)
                    'Next
                    v_xmlBuilder = Nothing
                End If
            Else
                If pv_ds.Tables(0).Rows.Count > 0 Then
                    'Dim v_strXMLBuilder As New StringBuilder("<DataBuilder>")
                    Dim v_strXMLBuilder As New StringBuilder
                    Dim v_xmlBuilder As New Xml.XmlDocument
                    Dim nodeItem As Xml.XmlNode, nodeList As Xml.XmlNodeList

                    For v_int As Integer = 0 To pv_ds.Tables(0).Rows.Count - 1
                        v_strXMLBuilder.Append("<ObjData>")
                        For v_intColumn As Integer = 0 To pv_ds.Tables(0).Columns.Count - 1
                            v_strXMLBuilder.Append("<Entry fldname='")
                            v_strXMLBuilder.Append(pv_ds.Tables(0).Columns(v_intColumn).ColumnName)
                            v_strXMLBuilder.Append("' fldtype='")
                            v_strXMLBuilder.Append(pv_ds.Tables(0).Columns(v_intColumn).DataType.ToString)
                            v_strXMLBuilder.Append("' oldval='")
                            If Not IsDBNull(pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn)) Then
                                If pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn).GetType.Name = GetType(System.DateTime).Name _
                                    And pv_intFlag = ExecuteFlag.AddNew Then
                                    v_strXMLBuilder.Append(Format(pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE_TIME))
                                Else
                                    v_strValue = CStr(pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn))
                                    v_strValue = v_strValue.Replace("&", "&amp;")
                                    v_strValue = v_strValue.Replace("'", "&apos;")
                                    v_strValue = v_strValue.Replace("""", "&quot;")
                                    v_strValue = v_strValue.Replace("<", "&lt;")
                                    v_strValue = v_strValue.Replace(">", "&gt;")
                                    v_strXMLBuilder.Append(v_strValue)
                                    'v_strXMLBuilder.Append(CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn)))
                                End If
                            End If
                            v_strXMLBuilder.Append("'>")
                            If Not IsDBNull(pv_ds.Tables(0).Rows(v_int)(v_intColumn)) Then
                                If pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name = GetType(System.DateTime).Name _
                                    And pv_intFlag = ExecuteFlag.AddNew Then
                                    v_strXMLBuilder.Append(Format(pv_ds.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE_TIME))
                                Else
                                    v_strValue = CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
                                    v_strValue = v_strValue.Replace("&", "&amp;")
                                    v_strValue = v_strValue.Replace("'", "&apos;")
                                    v_strValue = v_strValue.Replace("""", "&quot;")
                                    v_strValue = v_strValue.Replace("<", "&lt;")
                                    v_strValue = v_strValue.Replace(">", "&gt;")
                                    v_strXMLBuilder.Append(v_strValue)
                                    'v_strXMLBuilder.Append(CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn)))
                                End If
                            End If
                            v_strXMLBuilder.Append("</Entry>")
                        Next
                        v_strXMLBuilder.Append("</ObjData>")

                        v_xmlBuilder.LoadXml(v_strXMLBuilder.ToString)
                        nodeItem = v_XmlDocument.ImportNode(v_xmlBuilder.SelectSingleNode("/ObjData"), True)
                        v_XmlDocument.DocumentElement.AppendChild(nodeItem)
                        v_strXMLBuilder.Remove(0, v_strXMLBuilder.Length)
                    Next
                    'v_strXMLBuilder.Append("</DataBuilder>")
                    'v_xmlBuilder.LoadXml(v_strXMLBuilder.ToString)
                    'nodeList = v_xmlBuilder.SelectNodes("/DataBuilder/ObjData")
                    'For i As Integer = 0 To nodeList.Count - 1
                    '    nodeItem = v_XmlDocument.ImportNode(nodeList.Item(i), False)
                    '    v_XmlDocument.DocumentElement.AppendChild(nodeItem)
                    'Next
                    v_xmlBuilder = Nothing
                End If
            End If


            pv_strObjectMessage = v_XmlDocument.InnerXml
        Catch ex As Exception
            Throw ex
        Finally
            v_XmlDocument = Nothing
        End Try
    End Function

    Public Function DB_ObjTranfer_APPROVE(ByRef pv_strObjMessage As String, ByVal pv_strObjname As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.objRouter.DB_ObjTranfer_APPROVE"
        Dim v_strStoredName, v_strSQL, l_refobjid, v_strClause, v_strRefObjMsg As String
        Dim v_strTellerId, v_strBranchId, v_strBusDate, v_strRefObjname, v_strRefMODULCODE, v_strPCKNAME As String
        Dim v_xmlDocument As New XmlDocumentEx
        v_xmlDocument.LoadXml(pv_strObjMessage)
        Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
        Dim v_DataAccess As New DataAccess, v_ds As DataSet
        v_DataAccess.NewDBInstance(gc_MODULE_HOST)

        If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
            v_strClause = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCLAUSE), Xml.XmlAttribute).Value)
        Else
            v_strClause = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
            v_strTellerId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
        Else
            v_strTellerId = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
            v_strBranchId = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
        Else
            v_strBranchId = String.Empty
        End If
        If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
            v_strBusDate = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTXDATE), Xml.XmlAttribute).Value)
        Else
            v_strBusDate = String.Empty
        End If

        Try
            'Lay danh sach cac obj can duyet
            v_strSQL = "SELECT * FROM objlog WHERE (AUTOID = " & v_strClause & "  OR PAUTOID = " & v_strClause & ") AND (TXSTATUS = '4' or txstatus = '7')"
            v_ds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To v_ds.Tables(0).Rows.Count - 1
                    Dim v_strRefSQL As String
                    Dim v_Refds As DataSet
                    v_strRefSQL = "SELECT actionflag,childvalue,childkey,chiltable,MODULCODE, nvl(PCKNAME,CHILTABLE) PCKNAME FROM objlog WHERE AUTOID = " & v_ds.Tables(0).Rows(i)("AUTOID")
                    v_Refds = v_DataAccess.ExecuteSQLReturnDataset(CommandType.Text, v_strRefSQL)
                    If v_Refds.Tables(0).Rows.Count > 0 Then
                        l_refobjid = v_ds.Tables(0).Rows(i)("AUTOID")
                        v_strRefObjname = v_Refds.Tables(0).Rows(0)("CHILTABLE")
                        v_strRefMODULCODE = v_Refds.Tables(0).Rows(0)("MODULCODE")
                        v_strPCKNAME = v_Refds.Tables(0).Rows(0)("PCKNAME")
                        'Lay thong tin pckname


                        'build msg
                        v_strRefObjMsg = BuildXMLObjMsg(v_strBusDate, v_strBranchId, , v_strTellerId, "N", gc_MsgTypeObj, v_strRefObjname, gc_ActionApprove, , l_refobjid)
                        'call
                        v_strStoredName = "txpks_#" + v_strRefMODULCODE + "_" + v_strPCKNAME + ".fn_Transfer"

                        Dim v_objParam As New StoreParameter
                        Dim v_arrPara(3) As StoreParameter

                        v_objParam.ParamName = "return"
                        v_objParam.ParamDirection = ParameterDirection.ReturnValue
                        v_objParam.ParamValue = 0
                        v_objParam.ParamSize = 100
                        v_objParam.ParamType = GetType(Double).Name
                        v_arrPara(0) = v_objParam

                        v_objParam = New StoreParameter
                        v_objParam.ParamName = "p_xmlmsg"
                        v_objParam.ParamValue = v_strRefObjMsg
                        v_objParam.ParamDirection = ParameterDirection.InputOutput
                        v_objParam.ParamSize = 32000
                        v_objParam.ParamType = GetType(System.String).Name
                        v_arrPara(1) = v_objParam

                        v_objParam = New StoreParameter
                        v_objParam.ParamName = "p_err_code"
                        v_objParam.ParamDirection = ParameterDirection.InputOutput
                        v_objParam.ParamValue = ""
                        v_objParam.ParamSize = 100
                        v_objParam.ParamType = GetType(System.String).Name
                        v_arrPara(2) = v_objParam

                        v_objParam = New StoreParameter
                        v_objParam.ParamName = "p_err_param"
                        v_objParam.ParamDirection = ParameterDirection.Output
                        v_objParam.ParamValue = ""
                        v_objParam.ParamSize = 500
                        v_objParam.ParamType = GetType(System.String).Name
                        v_arrPara(3) = v_objParam

                        v_strRefObjMsg = v_DataAccess.ExecuteOracleStored(v_strStoredName, v_arrPara, 1)

                        If Not IsNumeric(v_arrPara(2).ParamValue) Then
                            v_lngErrCode = 0
                        Else
                            v_lngErrCode = CDec(v_arrPara(2).ParamValue)
                        End If

                        If v_lngErrCode <> ERR_SYSTEM_OK Then
                            Rollback()
                            Return v_lngErrCode
                        End If
                    End If
                Next
            End If
            Complete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

    Private Sub ProcessDataBlob(ByRef xmlStr As String, ByRef dicParamBlob As Dictionary(Of String, String), ByRef autoId As String)
        Dim xml As XmlDocument = New XmlDocument()
        xml.LoadXml(xmlStr)
        Dim objDataNode As XmlNode = GetNodeByName("ObjData", xml)
        Dim listNodeBlob As List(Of XmlNode) = New List(Of XmlNode)()

        If objDataNode IsNot Nothing Then
            For Each node As XmlNode In objDataNode.ChildNodes
                If node.Attributes("fldname") IsNot Nothing And node.Attributes("fldname").Value = "AUTOID" Then
                    If node.FirstChild IsNot Nothing Then
                        autoId = node.FirstChild.Value
                    Else
                        autoId = Nothing
                    End If
                End If

                If node.Attributes("fldtype") IsNot Nothing And node.Attributes("fldtype").Value = "System.Byte[]" Then
                    If node.FirstChild IsNot Nothing Then
                        dicParamBlob(node.Attributes("fldname").Value) = node.FirstChild.Value
                    Else
                        dicParamBlob(node.Attributes("fldname").Value) = Nothing
                    End If
                    listNodeBlob.Add(node)
                End If
            Next

            If (listNodeBlob IsNot Nothing And listNodeBlob.Count > 0) Then
                For Each node As XmlNode In listNodeBlob
                    objDataNode.RemoveChild(node)
                Next
            End If
        End If


        xmlStr = xml.OuterXml
    End Sub

    Private Function GetNodeByName(ByVal nodeName As String, ByVal parentNode As XmlNode) As XmlNode
        Dim result As XmlNode = Nothing
        Try
            If parentNode IsNot Nothing Then
                If parentNode.Name.Equals(nodeName) Then
                    Return parentNode
                End If
                If parentNode.ChildNodes IsNot Nothing Then
                    For Each node As XmlNode In parentNode.ChildNodes
                        result = IIf(result Is Nothing, GetNodeByName(nodeName, node), result)
                    Next
                End If
            End If
        Catch ex As Exception
            result = Nothing
        End Try
        Return result
    End Function

    Public Function DB_ObjTranfer(ByRef pv_strObjMessage As String, ByVal pv_strObjname As String) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "Host.objRouter.DB_ObjTranfer"
        Dim v_strStoredName As String

        Try


            Dim v_DataAccess As New DataAccess
            v_DataAccess.NewDBInstance(gc_MODULE_HOST)
            v_strStoredName = "txpks_#" + pv_strObjname.Substring(0, InStr(pv_strObjname, ".") - 1) + "_" + pv_strObjname.Substring(InStr(pv_strObjname, ".")) + ".fn_Transfer"

            Dim v_objParam As New StoreParameter
            Dim v_arrPara(3) As StoreParameter

            v_objParam.ParamName = "return"
            v_objParam.ParamDirection = ParameterDirection.ReturnValue
            v_objParam.ParamValue = 0
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(Double).Name
            v_arrPara(0) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_xmlmsg"
            v_objParam.ParamValue = pv_strObjMessage
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_objParam.ParamSize = 32000
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(1) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_code"
            v_objParam.ParamDirection = ParameterDirection.InputOutput
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 100
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(2) = v_objParam

            v_objParam = New StoreParameter
            v_objParam.ParamName = "p_err_param"
            v_objParam.ParamDirection = ParameterDirection.Output
            v_objParam.ParamValue = ""
            v_objParam.ParamSize = 500
            v_objParam.ParamType = GetType(System.String).Name
            v_arrPara(3) = v_objParam

            pv_strObjMessage = v_DataAccess.ExecuteOracleStored(v_strStoredName, v_arrPara, 1)

            If Not IsNumeric(v_arrPara(2).ParamValue) Then
                v_lngErrCode = 0
            Else
                v_lngErrCode = CDec(v_arrPara(2).ParamValue)
            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback()
                Return v_lngErrCode
            End If
            Complete()
            Return v_lngErrCode
        Catch ex As Exception
            Rollback()
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function
End Class
