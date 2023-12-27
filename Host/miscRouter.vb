Imports HostCommonLibrary
Imports CoreBusiness
Imports DataAccessLayer
Imports System.Data
'Imports System.EnterpriseServices

'TruongLD comment when convert
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Disabled), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class miscRouter
    'TruongLD comment when convert
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Public Function Transact(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK

        Try
            'Get message header
            Dim v_strBUSDATE As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeBUSDATE).Value.ToString)
            Dim v_strTXDATE As String = Trim(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXDATE).Value.ToString)
            Dim v_strTXTYPE As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTXTYPE).Value.ToString
            Dim v_byteNOSUBMIT As Byte = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeNOSUBMIT).Value.ToString
            Dim v_strTLTXCD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeTLTXCD).Value.ToString
            Dim v_intSTATUS As Integer = CInt(pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).Value.ToString)
            Dim v_strDELTD As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeDELTD).Value.ToString
            Dim v_strOVRRQS As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOVRRQS).Value.ToString
            Dim v_strOFFID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeOFFID).Value.ToString
            Dim v_strCHKID As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeCHKID).Value.ToString
            Dim v_strUpdateMode As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeUPDATEMODE).Value.ToString
            Dim v_strLOCAL As String = pv_xmlDocument.DocumentElement.Attributes(gc_AtributeLOCAL).Value.ToString
            Dim v_blnReversal As Boolean = IIf(v_strDELTD = "Y", True, False)

            'Xác định mã phân hệ xử lý giao dịch
            Dim v_obj As New DataAccess, v_ds As DataSet
            v_obj.NewDBInstance(gc_MODULE_HOST)
            Dim v_strSQL As String, i As Integer, v_strCLASSNAME
            v_strSQL = "SELECT * FROM APPMODULES WHERE TXCODE='" & Left(v_strTLTXCD, 2) & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                v_strCLASSNAME = Trim(v_ds.Tables(0).Rows(0)("CLASSNAME"))
            End If

            'Gọi Class tương ứng để xử lý
            'Dim v_objTransact As txMaster
            'Select Case v_strCLASSNAME
            '    Case SUB_SYSTEM_CF
            '        v_objTransact = New CF.Trans
            '    Case SUB_SYSTEM_CI
            '        v_objTransact = New CI.Trans
            '    Case SUB_SYSTEM_SE
            '        v_objTransact = New SE.Trans
            '    Case SUB_SYSTEM_GL
            '        v_objTransact = New GL.Trans
            '    Case SUB_SYSTEM_OD
            '        v_objTransact = New OD.Trans
            '    Case SUB_SYSTEM_RP
            '        v_objTransact = New RP.Trans
            '    Case SUB_SYSTEM_CA
            '        v_objTransact = New CA.Trans
            '    Case SUB_SYSTEM_RM
            '        v_objTransact = New RM.Trans
            'End Select
            'v_lngErrCode = v_objTransact.txMisc(pv_xmlDocument)
            Dim oAssembly As System.Reflection.Assembly = System.Reflection.Assembly.Load(v_strCLASSNAME)
            Dim aType As System.Type = oAssembly.GetType(v_strCLASSNAME & ".Trans")
            If Not aType Is Nothing Then
                Dim obj, retval As Object
                obj = Activator.CreateInstance(aType)
                Dim args() As Object = {pv_xmlDocument}
                retval = aType.InvokeMember("txMisc", Reflection.BindingFlags.InvokeMethod, Nothing, obj, args)
                v_lngErrCode = CType(retval, Long)
                Dim pv_strDataMessage As String = CType(args(0), Xml.XmlDocument).InnerXml
                pv_xmlDocument.LoadXml(pv_strDataMessage)
            End If

            If v_lngErrCode <> ERR_SYSTEM_OK Then
                Rollback() 'ContextUtil.SetAbort()
                Return v_lngErrCode
            Else
                'Ghi nhận giao dịch. Giao dịch MISC thì đưa về trạng thái Completed ngay
                Dim v_objMessageLog As New MessageLog
                v_objMessageLog.NewDBInstance(gc_MODULE_HOST)
                If v_strDELTD <> MSGTRANS_DELETED Then
                    pv_xmlDocument.DocumentElement.Attributes(gc_AtributeSTATUS).InnerXml = TransactStatus.Completed
                    v_lngErrCode = v_objMessageLog.TransLog(pv_xmlDocument)
                Else
                    v_lngErrCode = v_objMessageLog.TransDelete(pv_xmlDocument)
                End If
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
End Class
