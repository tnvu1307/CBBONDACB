Imports HostCommonLibrary
Imports DataAccessLayer
Imports System.Data
Public Class SYSVAR
    Inherits CoreBusiness.Maintain

    Dim LogError As LogError = New LogError()

    Public Sub New()
        ATTR_TABLE = "SYSVAR"
    End Sub

#Region " Overrides functions "

    Overrides Function CheckBeforeEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strVARNAME, v_strGRNAME, v_strVARVALUE, v_strMAXDEBTDAYS, v_strMAXTOTALDEBTDAYS As String
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
                        Case "VARNAME"
                            v_strVARNAME = UCase(Trim(v_strVALUE))
                        Case "GRNAME"
                            v_strGRNAME = v_strVALUE
                        Case "VARVALUE"
                            v_strVARVALUE = v_strVALUE
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

            If v_strGRNAME.Equals("MARGIN") Then

                Select Case v_strVARNAME
                    Case "ROLLLIMIT", "MAXDEBT", "MAXDEBTCF", "MAXDEBTSE", "MAXDEBTDAYS", "MAXTOTALDEBTDAYS", "MAXDEBTQTTYRATE", "IRATIO", "MRATIO", "LRATIO", "MAXPERIODPENDING"
                        'Kiem tra co phai la so
                        If Not IsNumeric(v_strVARVALUE) Then
                            Return ERR_SA_VARVALUE_IS_NOT_NUMBER
                        End If

                        'Kiem tra so lon hon 0
                        If v_strVARVALUE < 0 Then
                            Return ERR_SA_VARVALUE_IS_SMALLER_THAN_ZERO
                        End If

                        'Kiem tra khong co phan thap phan
                        If Not v_strVARNAME.Equals("MAXDEBTQTTYRATE") Then
                            If IsDecimal(v_strVARVALUE) Then
                                Return ERR_SA_VARVALUE_IS_DECIMAL
                            End If
                        End If

                        'Kiem tra do dai so khong qua 14
                        If Trim(v_strVARVALUE).Length > 20 Then
                            Return ERR_SA_VARVALUE_LENGTH_OVER_14
                        End If

                        'Kiem tra khong co khoang trang
                        If v_strVARVALUE.Length <> Trim(v_strVARVALUE).Length Or v_strVARVALUE <> v_strVARVALUE.Replace(" ", "") Then
                            Return ERR_SA_VARVALUE_INCLUDE_WHITE_SPACE
                        End If

                        'Kiem tra khong co khoang cach phan nghin
                        If v_strVARVALUE.IndexOf(",") >= 0 Then
                            Return ERR_SA_VARVALUE_INCLUDE_COMMA
                        End If

                        'Kiem tra them danh cho MAXTOTALDEBTDAYS
                        If v_strVARNAME.Equals("MAXTOTALDEBTDAYS") Then
                            v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'MARGIN' AND VARNAME = 'MAXDEBTDAYS'"
                            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            v_strMAXDEBTDAYS = v_ds.Tables(0).Rows(0)("VARVALUE").ToString()
                            'Kiem tra MAXTOTALDEBTDAYS phai lon hon MAXDEBTDAYS
                            If (Integer.Parse(v_strVARVALUE) < Integer.Parse(v_strMAXDEBTDAYS)) Then
                                Return ERR_SA_MAXTOTALDEBTDAYS_SMALLER_THAN_MAXDEBTDAYS
                            End If
                        End If

                        'Kiem tra them danh cho MAXDEBTDAYS
                        If v_strVARNAME.Equals("MAXDEBTDAYS") Then
                            v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'MARGIN' AND VARNAME = 'MAXTOTALDEBTDAYS'"
                            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                            v_strMAXTOTALDEBTDAYS = v_ds.Tables(0).Rows(0)("VARVALUE").ToString()
                            'Kiem tra MAXTOTALDEBTDAYS phai lon hon MAXDEBTDAYS
                            If (Integer.Parse(v_strVARVALUE) > Integer.Parse(v_strMAXTOTALDEBTDAYS)) Then
                                Return ERR_SA_MAXTOTALDEBTDAYS_SMALLER_THAN_MAXDEBTDAYS
                            End If
                        End If

                        'Kiem tra them danh cho MAXDEBTQTTYRATE
                        If ("|IRATIO|MRATIO|LRATIO|ROLLLIMIT|MAXDEBTQTTYRATE|").IndexOf("|" & v_strVARNAME & "|") >= 0 Then
                            If v_strVARVALUE < 0 Or v_strVARVALUE > 100 Then
                                Return ERR_SA_VARVALUE_NUMBER_MUST_BETWEEN_0_100
                            End If
                        End If


                    Case "MARGINALLOW"
                        'Kiem tra khong co khoang trang
                        If v_strVARVALUE.Length <> Trim(v_strVARVALUE).Length Then
                            Return ERR_SA_VARVALUE_INCLUDE_WHITE_SPACE
                        End If

                        'Kiem tra chi duoc nhap ky tu Y hoac N
                        If Not (v_strVARVALUE.Equals("Y") Or v_strVARVALUE.Equals("N")) Then
                            Return ERR_SA_MARGINALLOW_IS_INVALID
                        End If
                End Select
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

    Overrides Function CheckBeforeAdd(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_ds As DataSet
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strVARNAME As String
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
                        Case "VARNAME"
                            v_strVARNAME = UCase(Trim(v_strVALUE))
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

            'Kiểm tra trường VARNAME Khong duoc trung
            v_strSQL = "SELECT COUNT(VARNAME) FROM SYSVAR WHERE TRIM(UPPER(VARNAME)) = '" & v_strVARNAME & "'"
            v_ds = v_obj.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count = 1 Then
                If v_ds.Tables(0).Rows(0)(0) <> 0 Then
                    Return ERR_SA_FEEMASTER_DUPLICATED
                End If
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

    Public Overrides Function ProcessAfterEdit(ByVal v_strMessage As String) As Long
        Dim pv_xmlDocument As XmlDocumentEx = gf_String2XMLDocumentEx(v_strMessage)

        Dim v_strObjMsg As String
        Dim v_nodeList As Xml.XmlNodeList

        Try
            Dim v_attrColl As Xml.XmlAttributeCollection = pv_xmlDocument.DocumentElement.Attributes
            Dim v_strLocal, v_strVARNAME As String
            Dim v_strFLDNAME, v_strFLDTYPE, v_strVALUE, v_strGRNAME, v_strVARVALUE As String
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
                        Case "GRNAME"
                            v_strGRNAME = UCase(Trim(v_strVALUE))
                        Case "VARNAME"
                            v_strVARNAME = UCase(Trim(v_strVALUE))
                        Case "VARVALUE"
                            v_strVARVALUE = UCase(Trim(v_strVALUE))
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

            If v_strGRNAME = "MARGIN" And v_strVARNAME = "MAXDEBT" Then
                v_strSQL = "UPDATE PRMASTER SET PRLIMIT = " & CDbl(v_strVARVALUE) & " WHERE PRCODE = '9999' AND PRTYP = 'P'"
                v_obj.ExecuteNonQuery(CommandType.Text, v_strSQL)

            End If
            Return ERR_SYSTEM_OK
        Catch ex As Exception
            LogError.WriteException(ex)
            Throw ex
        End Try
    End Function

End Class
