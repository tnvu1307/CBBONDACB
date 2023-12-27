Imports HostCommonLibrary
Imports CoreBusiness
Imports DataAccessLayer
'Imports System.EnterpriseServices
Imports System.Configuration
Imports System.IO
Imports System.Globalization
Imports System.Data

'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Disabled), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class HOSTReport
    'Inherits ServicedComponent
    Inherits TxScope

    Dim LogError As LogError = New LogError()

    Public Function objTransfer(ByRef pv_strObjMsg As String) As Long
        Dim v_xmlDocument As New Xml.XmlDocument
        v_xmlDocument.LoadXml(pv_strObjMsg)
        Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
        Dim v_strMSGTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeMSGTYPE), Xml.XmlAttribute).Value)
        Try
            Select Case v_strMSGTYPE
                Case gc_MsgTypeRpt
                    'Lay danh sach bao cao
                    CoreInquiry(v_xmlDocument)
                Case gc_MsgTypeProc
                    'Lay du lieu bao cao
                    CoreRptInquiry(v_xmlDocument)
            End Select

            pv_strObjMsg = v_xmlDocument.InnerXml
            Complete() 'ContextUtil.SetComplete()
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
        End Try
    End Function

    Public Function CoreInquiry(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes


        Dim v_strLocal As String
        Dim v_strCmdInquiry As String
        Dim v_obj As DataAccess

        Try
            'TruongLD comment
            ''Lay ra cac tham so tu message
            'If Not (v_attrColl.GetNamedItem("LOCAL") Is Nothing) Then
            '    v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            'Else
            '    v_strLocal = String.Empty
            'End If

            'If Not (v_attrColl.GetNamedItem("VALUE2") Is Nothing) Then
            '    v_strCmdInquiry = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDINQUIRY), Xml.XmlAttribute).Value)
            'Else
            '    v_strCmdInquiry = String.Empty
            'End If

            'TruongLD add lai
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
            'End TruongLD


            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_ds As DataSet

            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strCmdInquiry)

            'Create data
            Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim i As Integer, j As Integer
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
        End Try
    End Function

    Public Function CoreRptInquiry(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
        Dim v_strClause As String
        Dim v_strLocal As String
        Dim v_strCmdInquiry As String
        Dim v_strObjMsg As String
        Dim v_strStoreProc As String
        Dim v_intNumOfParam As Integer
        Dim v_strName, v_strValue, v_strSize, v_strType As String
        Dim v_objRptParam As ReportParameters
        Dim v_arrRptPara() As ReportParameters
        Dim v_obj As DataAccess

        'Lay ra cac tham so tu message
        Dim v_strBRID, v_strTLID, v_strCMDID, v_strREFNUM, v_strACTIONFLAG, v_strAORS, v_strFUNCNAME, v_strIsDefaultDB As String
        'Create data
        Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
        Dim i As Integer, j As Integer
        Dim v_attrFLDNAME As Xml.XmlAttribute, v_attrFLDTYPE As Xml.XmlAttribute, v_attrLENGTH As Xml.XmlAttribute, v_attrOLDVAL As Xml.XmlAttribute
        Dim v_strDataXSD, v_strDataXML, v_strBuilder As String
        Dim v_arrXSDByteMessage(), v_arrXMLByteMessage() As Byte
        Dim v_Encoded As Char()
        'Doc file va nap lai vao pv_xmlDocument
        Dim v_strDirRptRequest, v_strDirRptDone As String
        If ConfigurationSettings.AppSettings("DIRRPTREQUEST") <> Nothing Then
            v_strDirRptRequest = ConfigurationSettings.AppSettings("DIRRPTREQUEST").ToString().Trim()
        Else
            v_strDirRptRequest = "C:\"
        End If
        If ConfigurationSettings.AppSettings("DIRRPTDONE") <> Nothing Then
            v_strDirRptDone = ConfigurationSettings.AppSettings("DIRRPTDONE").ToString().Trim()
        Else
            v_strDirRptDone = "C:\"
        End If

        Try
            If Not (v_attrColl.GetNamedItem(gc_AtributeACTFLAG) Is Nothing) Then
                v_strACTIONFLAG = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeACTFLAG), Xml.XmlAttribute).Value)
            Else
                v_strACTIONFLAG = "M"
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeFUNCNAME) Is Nothing) Then
                v_strFUNCNAME = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeFUNCNAME), Xml.XmlAttribute).Value)
            Else
                v_strFUNCNAME = "N" 'Normal function
            End If

            If v_strFUNCNAME = "GetPendingReport" Then
                'Lay danh sach cac yeu cau bao cao dang cho xu ly
                Dim v_dirInfo As New DirectoryInfo(v_strDirRptRequest)
                Dim v_arrReportFiles() As FileInfo = v_dirInfo.GetFiles("*_REQUEST_*.xml")
                Dim v_fileInfo As FileInfo

                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "RptFiles", "")
                For Each v_fileInfo In v_arrReportFiles
                    'Append entry to data node
                    v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                    v_entryNode.InnerText = v_fileInfo.Name
                    v_dataElement.AppendChild(v_entryNode)
                Next
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                'Thoat khoi ham xu ly luon
                Return ERR_SYSTEM_OK
            ElseIf v_strFUNCNAME = "GetReturnReport" Then
                'v_strREFNUM la ten file can download
                If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                    v_strREFNUM = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
                Else
                    v_strREFNUM = String.Empty
                End If

                If Dir(v_strDirRptDone & v_strREFNUM).Length > 0 And v_strREFNUM.Length > 0 Then
                    'Lay du lieu bao cao
                    Dim v_streamReader As New StreamReader(v_strDirRptDone & v_strREFNUM)
                    Dim v_strRptData As String = v_streamReader.ReadToEnd
                    v_streamReader.Close()
                    CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value = "DONE"
                    v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "RptFiles", "")
                    v_entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                    v_entryNode.InnerText = v_strRptData
                    v_dataElement.AppendChild(v_entryNode)
                    pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                Else
                    CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value = "PENDING"
                End If

                'Thoat khoi ham xu ly luon
                Return ERR_SYSTEM_OK
            ElseIf v_strFUNCNAME <> "N" Then
                'Function name chinh la ten file bao cao dang cho xu ly
                Dim v_streamReader As New StreamReader(v_strDirRptRequest & v_strFUNCNAME)
                pv_xmlDocument.LoadXml(v_streamReader.ReadToEnd)
                v_streamReader.Close()
                v_attrColl = pv_xmlDocument.DocumentElement.Attributes
                v_strACTIONFLAG = "A"   'Dat che do tao bao cao luon, cac thuoc tinh khac duoc doc tu file bao cao
            End If

            'Xu ly yeu cau bao cao
            '==================================================================================================================
            If Not (v_attrColl.GetNamedItem(gc_AtributeLOCAL) Is Nothing) Then
                v_strLocal = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            Else
                v_strLocal = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem("STOREPROC") Is Nothing) Then
                v_strStoreProc = CStr(CType(v_attrColl.GetNamedItem("STOREPROC"), Xml.XmlAttribute).Value)
            Else
                v_strStoreProc = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem("NUM_OF_PARAM") Is Nothing) Then
                v_intNumOfParam = CStr(CType(v_attrColl.GetNamedItem("NUM_OF_PARAM"), Xml.XmlAttribute).Value)
            Else
                v_intNumOfParam = String.Empty
            End If

            If Not (v_attrColl.GetNamedItem(gc_AtributeBRID) Is Nothing) Then
                v_strBRID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeBRID), Xml.XmlAttribute).Value)
            Else
                v_strBRID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeTLID) Is Nothing) Then
                v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            Else
                v_strTLID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeCMDID) Is Nothing) Then
                v_strCMDID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCMDID), Xml.XmlAttribute).Value)
            Else
                v_strCMDID = String.Empty
            End If
            If Not (v_attrColl.GetNamedItem(gc_AtributeREFERENCE) Is Nothing) Then
                v_strREFNUM = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)
            Else
                v_strREFNUM = String.Empty
            End If

            'Thiet lap tham so cho thu tuc lay du lieu
            Dim v_index As Integer
            Dim v_strInput As String
            ReDim v_arrRptPara(v_intNumOfParam - 1)
            For v_index = 0 To v_intNumOfParam - 1
                If Not (v_attrColl.GetNamedItem("PARAMNAME" & v_index.ToString) Is Nothing) Then
                    v_strName = CStr(CType(v_attrColl.GetNamedItem("PARAMNAME" & v_index.ToString), Xml.XmlAttribute).Value)
                Else
                    v_strName = String.Empty
                End If
                If Not (v_attrColl.GetNamedItem("PARAMVALUE" & v_index.ToString) Is Nothing) Then
                    v_strValue = CStr(CType(v_attrColl.GetNamedItem("PARAMVALUE" & v_index.ToString), Xml.XmlAttribute).Value)
                Else
                    v_strValue = String.Empty
                End If
                If Not (v_attrColl.GetNamedItem("PARAMSIZE" & v_index.ToString) Is Nothing) Then
                    v_strSize = CStr(CType(v_attrColl.GetNamedItem("PARAMSIZE" & v_index.ToString), Xml.XmlAttribute).Value)
                Else
                    v_strSize = String.Empty
                End If
                If Not (v_attrColl.GetNamedItem("PARAMTYPE" & v_index.ToString) Is Nothing) Then
                    v_strType = CStr(CType(v_attrColl.GetNamedItem("PARAMTYPE" & v_index.ToString), Xml.XmlAttribute).Value)
                Else
                    v_strType = String.Empty
                End If
                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = v_strName
                v_objRptParam.ParamValue = v_strValue
                If (v_index = v_intNumOfParam - 1) Then
                    v_strInput &= v_strName & ":" & v_strValue
                Else
                    v_strInput &= v_strName & ":" & v_strValue & "#"
                End If
                v_objRptParam.ParamSize = CInt(v_strSize)
                v_objRptParam.ParamType = v_strType
                v_arrRptPara(v_index) = v_objRptParam
            Next

            'Khoi tao ket noi
            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                v_obj = New DataAccess
                'If v_strIsDefaultDB = "N" Then
                '    v_obj.NewDBInstance(gc_MODULE_HOST)
                'Else
                '    v_obj.NewDBInstance(gc_MODULE_HOSTREPORT)
                'End If

                'v_obj.NewDBInstance(gc_MODULE_HOST)
                v_obj.NewDBInstance(gc_MODULE_HOST)
            End If

            Dim v_ds As DataSet
            Dim v_strSQL As String
            'Kiem tra neu la bao cao tu dong thi tao luon
            If v_strACTIONFLAG = "M" Then
                v_strSQL = "SELECT AORS,ISDEFAULTDB FROM RPTMASTER WHERE RPTID='" & v_strCMDID & "'"
                v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows.Count > 0 Then
                    v_strAORS = v_ds.Tables(0).Rows(0)("AORS")
                    v_strIsDefaultDB = v_ds.Tables(0).Rows(0)("ISDEFAULTDB")
                Else
                    v_strAORS = "S"
                End If
            Else
                v_strAORS = "S"
            End If

            If v_strLocal = "Y" Then
                v_obj = New DataAccess
            ElseIf v_strLocal = "N" Then
                If v_strIsDefaultDB = "N" Then
                    v_obj.NewDBInstance(gc_MODULE_HOST)
                Else
                    v_obj.NewDBInstance(gc_MODULE_HOSTREPORT)
                End If
            End If


            'Cach thuc xu ly dien bao cao
            'T07/2017 STP
            If v_strAORS = "M" Then
                v_strInput = ""
                ReDim v_arrRptPara(3)
                ' v_index = 2 bat dau tu 2 la vi 2 tham so dau tien la option, brid
                For v_index = 2 To v_intNumOfParam - 1
                    If Not (v_attrColl.GetNamedItem("PARAMNAME" & v_index.ToString) Is Nothing) Then
                        v_strName = CStr(CType(v_attrColl.GetNamedItem("PARAMNAME" & v_index.ToString), Xml.XmlAttribute).Value)
                    Else
                        v_strName = String.Empty
                    End If
                    If Not (v_attrColl.GetNamedItem("PARAMVALUE" & v_index.ToString) Is Nothing) Then
                        v_strValue = CStr(CType(v_attrColl.GetNamedItem("PARAMVALUE" & v_index.ToString), Xml.XmlAttribute).Value)
                    Else
                        v_strValue = String.Empty
                    End If
                    If Not (v_attrColl.GetNamedItem("PARAMTYPE" & v_index.ToString) Is Nothing) Then
                        v_strType = CStr(CType(v_attrColl.GetNamedItem("PARAMTYPE" & v_index.ToString), Xml.XmlAttribute).Value)
                    Else
                        v_strType = String.Empty
                    End If
                    If v_strType = "DateTime" Then
                        Try
                            v_strValue = (DateTime.ParseExact(v_strValue, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToString("yyyyMMdd", CultureInfo.InvariantCulture)
                        Catch
                        End Try
                    End If

                    If (v_index = v_intNumOfParam - 1) Then
                        v_strInput &= v_strName & ":" & v_strValue
                    Else
                        v_strInput &= v_strName & ":" & v_strValue & vbNewLine
                    End If
                Next

                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "PV_BRID"
                v_objRptParam.ParamValue = v_strBRID
                v_objRptParam.ParamType = String.Empty
                v_arrRptPara(0) = v_objRptParam

                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "PV_TLID"
                v_objRptParam.ParamValue = v_strTLID
                v_objRptParam.ParamType = String.Empty
                v_arrRptPara(1) = v_objRptParam

                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "PV_REPORTID"
                v_objRptParam.ParamValue = Mid(v_strCMDID, 1)
                v_objRptParam.ParamType = String.Empty
                v_arrRptPara(2) = v_objRptParam

                v_objRptParam = New ReportParameters
                v_objRptParam.ParamName = "PV_REPORTPARAM"
                v_objRptParam.ParamValue = v_strInput
                v_objRptParam.ParamType = String.Empty
                v_arrRptPara(3) = v_objRptParam

                v_ds = v_obj.ExecuteStoredReturnDataset(v_strStoreProc, v_arrRptPara)
                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "RptDataXSD", "")
                v_dataElement.InnerText = "PENDING"
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                'Data
                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "RptDataXML", "")
                v_dataElement.InnerText = v_strCMDID & ".xml"  'Pending
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                'Cach thuc xu ly bao cao
            ElseIf v_strAORS = "S" Then  'Synchronous report
                'If v_strAORS = "S" Then  'Synchronous report
                'End T07/2017 STP
                Dim v_strSQL_ID As String
                Dim v_ds_id As DataSet
                Dim v_report_id As Integer
                v_obj = New DataAccess
                v_obj.NewDBInstance(gc_MODULE_HOST)

                Dim mv_strWsName As String = System.Net.Dns.GetHostName
                Dim mv_strIpAddress As String = GetIPAddress()

                v_strSQL_ID = "SELECT SEQ_REPORTLOG.NEXTVAL ID FROM dual"
                v_ds_id = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL_ID)

                If v_ds_id.Tables(0).Rows.Count > 0 Then
                    v_report_id = v_ds_id.Tables(0).Rows(0)("ID")
                End If
                Dim v_strSQLLog As String = "INSERT INTO REPORTLOG(ID,BEGINDATE,ENDDATE,TLID,RPTID,WSNAME,IPADDRESS,RPTINPUT) " _
                                        & " VALUES(" & v_report_id & ",SYSDATE,NULL,'" & v_strTLID & "','" & v_strCMDID & "','" & mv_strWsName & "','" & mv_strIpAddress & "','" & v_strInput & "')"

                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLLog)
                'Lay ra dataset
                v_ds = v_obj.ExecuteStoredReturnDataset(v_strStoreProc, v_arrRptPara)

                v_strSQLLog = "UPDATE REPORTLOG SET ENDDATE = SYSDATE WHERE ID = " & v_report_id
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQLLog)

                If v_ds.Tables.Count > 0 AndAlso v_ds.Tables(0).Rows.Count > 0 Then
                    AdHocCheckRPTFEE(v_strCMDID, v_strStoreProc, v_strTLID, v_arrRptPara, v_obj)
                End If

                v_strDataXSD = v_ds.GetXmlSchema
                v_strDataXML = v_ds.GetXml
                v_arrXSDByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(v_strDataXSD)
                v_arrXMLByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(v_strDataXML)

                Dim v_XSD As New TestBase64.Base64Encoder(v_arrXSDByteMessage)
                v_Encoded = v_XSD.GetEncoded
                v_strDataXSD = v_Encoded

                Dim v_XML As New TestBase64.Base64Encoder(v_arrXMLByteMessage)
                v_Encoded = v_XML.GetEncoded
                v_strDataXML = v_Encoded

                'Schema
                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "RptDataXSD", "")
                v_dataElement.InnerText = v_strDataXSD
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                'Data
                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "RptDataXML", "")
                v_dataElement.InnerText = v_strDataXML
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)
            Else    'Asynchronous report
                'Dua yeu cau vao hang doi xu ly: Hang doi la file
                Dim v_strRefRPTID, v_strRequest As String
                v_strRefRPTID = "_REQUEST" & "_" & v_strBRID & "_" & v_strTLID & "_" & v_strCMDID & "_" & v_strREFNUM     'Name of the file
                'Neu file cu dang pending xu ly thi ghi de
                Dim v_dirFileInfo As New DirectoryInfo(v_strDirRptRequest)
                Dim v_arrReportPendingFiles() As FileInfo = v_dirFileInfo.GetFiles("*" & v_strRefRPTID & ".xml")
                Dim v_fileInfo As FileInfo
                For Each v_fileInfo In v_arrReportPendingFiles
                    File.Delete(v_fileInfo.Name)
                Next

                'Ghi nhan yeu cau xu ly bao cao moi
                Dim v_strRptNum As String = Right(gc_FORMAT_TXNUM & v_obj.GetIDValue("RPTASYN").ToString, Len(gc_FORMAT_TXNUM))
                v_strRefRPTID = v_strRptNum & v_strRefRPTID
                v_strRequest = pv_xmlDocument.InnerXml  'Request information

                'Tra ve noi dung rong de bao dang o trang thai cho xu ly
                'Schema
                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "RptDataXSD", "")
                v_dataElement.InnerText = "PENDING"
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                'Data
                v_dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "RptDataXML", "")
                v_dataElement.InnerText = v_strRefRPTID & ".xml"  'Pending
                pv_xmlDocument.DocumentElement.AppendChild(v_dataElement)

                'Keep the request by file
                Dim v_streamWriter As New StreamWriter(v_strDirRptRequest & v_strRefRPTID & ".xml")
                v_streamWriter.Write(v_strRequest)
                v_streamWriter.Flush()
                v_streamWriter.Close()
            End If

            If v_strFUNCNAME <> "N" And v_strFUNCNAME <> "GetPendingReport" Then
                'Neu la xu ly tao bao cao asynchronous: Ghi nhat ket qua 
                Dim v_streamRptWriter As New StreamWriter(v_strDirRptDone & v_strFUNCNAME)
                v_streamRptWriter.Write(pv_xmlDocument.InnerXml)
                v_streamRptWriter.Flush()
                v_streamRptWriter.Close()
                'Xoa file yeu cau xu ly bao cao
                File.Delete(v_strDirRptRequest & v_strFUNCNAME)
            End If

            v_ds.Dispose()
            Complete() 'ContextUtil.SetComplete()
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            Rollback() 'ContextUtil.SetAbort()
        End Try
    End Function
    Private Function GetIPAddress() As String
        Try
            Dim sHostName As String = System.Net.Dns.GetHostName()
            Dim ipE As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(sHostName)
            Dim IpA() As System.Net.IPAddress = ipE.AddressList
            Dim sAddr As String
            sAddr = IpA(0).ToString
            Return sAddr
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function AdHocCheckRPTFEE(ByVal pv_RptId As String, _
                                      ByVal pv_ProcName As String, _
                                      ByVal pv_strTLID As String, _
                                      ByVal pv_arrParam() As ReportParameters, _
                                      ByVal pv_obj As DataAccess) As Long
        Try
            Dim v_strSQL As String, v_ds As DataSet
            v_strSQL = "SELECT RPTID FROM RPTMASTER_FEE WHERE RPTID = '" & pv_RptId & "'"
            v_ds = pv_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables.Count > 0 AndAlso v_ds.Tables(0).Rows.Count > 0 Then
                'Check IsSubReport
                v_strSQL = "SELECT SUBRPT, STOREDNAME FROM RPTMASTER WHERE RPTID='" & pv_RptId & "'"
                v_ds = pv_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                If v_ds.Tables(0).Rows(0)("SUBRPT").ToString = "Y" Then
                    If v_ds.Tables(0).Rows(0)("STOREDNAME").ToString.Split("#")(0) <> pv_ProcName Then
                        Return ERR_SYSTEM_OK
                    End If
                End If

                Dim v_strCUSTODYCD As String = String.Empty
                For Each param As ReportParameters In pv_arrParam
                    If InStr(param.ParamName, "CUSTODYCD") > 0 Then
                        v_strCUSTODYCD = param.ParamValue
                        Exit For
                    End If
                Next
                v_strSQL = "INSERT INTO rptfeelog (autoid, createtime, rptid, tlid, custodycd) VALUES (seq_rptfeelog.nextval, sysdate, '" & pv_RptId & "', '" & pv_strTLID & "', '" & v_strCUSTODYCD & "') "
                pv_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)
            End If
        Catch ex As Exception
            LogError.WriteException(ex)
        End Try
        Return ERR_SYSTEM_OK
    End Function
End Class