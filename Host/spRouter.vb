Imports HostCommonLibrary
Imports DataAccessLayer
Imports System
Imports System.Xml
Imports System.Collections
Imports System.Configuration
'Imports System.EnterpriseServices
Imports Microsoft.Practices.EnterpriseLibrary.Caching
Imports System.Data
Public Class spRouter
    'TruongLD comment when convert
    'Inherits ServicedComponent
    Inherits TxScope

#Region " Definition "

    'TruongLD comment when convert
    'Private spmGroupManager As SharedPropertyGroupManager
    'Private spmGroup As SharedPropertyGroup
    'Private spmProperty As SharedProperty

    'TruongLD add when convert
    Private Const cache_manager As String = "Host_Cache_Manager"
    Private ReadOnly _HostParameterCache As ICacheManager = CacheFactory.GetCacheManager(cache_manager)
    'End TruongLD

    Private bExist As Boolean

    Private mv_arrTLTX As ArrayList
    Private mv_arrICCFTX As ArrayList
    Private mv_strTLTXCD As String
    Private mv_strSECURITIES_INFO As String
    Private mv_strSBCURRENCY As String
    Private mv_strGLREF As String
    Private mv_strGLREFCOM As String
    Private mv_strSYSVAR As String
    Private mv_strFLDMASTER_XSD As String
    Private mv_strPOSTMAP_IBT_XSD As String
    Private mv_strAPPMAP_XSD As String
    Private mv_strAPPCHK_XSD As String
    Private mv_strAPPTYPE_XSD As String
    Private mv_strSECURITIES_INFO_XSD As String
    Private mv_strSBCURRENCY_XSD As String
    Private mv_strGLREF_XSD As String
    Private mv_strGLREFCOM_XSD As String
    Private mv_strICCFTX_XSD As String
    Private mv_strSYSVAR_XSD As String

    Public Property ATTR_SBCURRENCY() As String
        Get
            Return mv_strSBCURRENCY
        End Get
        Set(ByVal Value As String)
            mv_strSBCURRENCY = Value
        End Set
    End Property

    Public Property ATTR_GLREF() As String
        Get
            Return mv_strGLREF
        End Get
        Set(ByVal Value As String)
            mv_strGLREF = Value
        End Set
    End Property

    Public Property ATTR_GLREFCOM() As String
        Get
            Return mv_strGLREFCOM
        End Get
        Set(ByVal Value As String)
            mv_strGLREFCOM = Value
        End Set
    End Property

    Public Property ATTR_TLTXCD() As String
        Get
            Return mv_strTLTXCD
        End Get
        Set(ByVal Value As String)
            mv_strTLTXCD = Value
        End Set
    End Property

    Private Structure TLTX_OFFSET
        Public TLTXCD As String
        Public ACCTFLDCD As String
        Public IBT As String
        Public TXTYPE As String
        Public XML_FLDMASTER As String
        Public XML_POSTMAP_IBT_0 As String
        Public XML_POSTMAP_IBT_1 As String
        Public XML_POSTMAP_IBT_2 As String
        Public XML_POSTMAP_IBT_3 As String
        Public XML_APPTYPE As String
        Public XML_APPMAP As String
        Public XML_APPCHK As String
        Public XML_TXMESSAGE As String
    End Structure

    Private Structure TLTX_SEGMENT
        Public TXCODE As String
        Public MODECODE As String
        Public mv_arrTLTXOffset() As TLTX_OFFSET
    End Structure

    Private Structure ICCFTX_SEGMENT
        Public ICCFTX_MODCODE As String
        Public ICCFTX_EVENTCODE As String
        Public ICCFTX_DATA As String
    End Structure

    Private mv_XMLBuffer As XmlDocumentEx
    Private Const gc_HOSTGRP = "HOSTGRP"
    Private Const gc_HOSTGRP_FLAG = "HOSTGRP_FLAG"
    Private Const gc_SHARED_TLTX = "SHARED_TLTXCD"
    Private Const gc_SHARED_SBCURRENCY = "SHARED_SBCURRENCY"
    Private Const gc_SHARED_GLREF = "SHARED_GLREF"
    Private Const gc_SHARED_GLREFCOM = "SHARED_GLREFCOM"

    Private Const DEF_ACCTFLDCD = "ACCTFLDCD"
    Private Const DEF_IBT = "IBT"
    Private Const DEF_TXTYPE = "TXTYPE"
    Private Const DEF_POSTMAP = "POSTMAP"
    Private Const DEF_APPTYPE = "XML_APPTYPE"
    Private Const DEF_APPMAP = "XML_APPMAP"
    Private Const DEF_APPCHK = "XML_APPCHK"
    Private Const DEF_SECURITIES_INFO = "XML_SECURITIES_INFO"
    Private Const DEF_SBCURRENCY = "XML_SBCURRENCY"
    Private Const DEF_GLREF = "XML_GLREF"
    Private Const DEF_GLREFCOM = "XML_GLREFCOM"
    Private Const DEF_SCHEMA_BUFFER = "<ObjectBuffer>" & _
                       "<ACCTFLDCD></ACCTFLDCD>" & _
                       "<IBT></IBT>" & _
                       "<TXTYPE></TXTYPE>" & _
                       "<FLDMASTER_XSD></FLDMASTER_XSD>" & _
                       "<POSTMAP_IBT_XSD></POSTMAP_IBT_XSD>" & _
                       "<APPTYPE_XSD></APPTYPE_XSD>" & _
                       "<APPMAP_XSD></APPMAP_XSD>" & _
                       "<APPCHK_XSD></APPCHK_XSD>" & _
                       "<SECURITIES_INFO_XSD></SECURITIES_INFO_XSD>" & _
                       "<SBCURRENCY_XSD></SBCURRENCY_XSD>" & _
                       "<GLREF_XSD></GLREF_XSD>" & _
                       "<GLREFCOM_XSD></GLREFCOM_XSD>" & _
                       "<FLDMASTER></FLDMASTER>" & _
                       "<POSTMAP_IBT_0></POSTMAP_IBT_0>" & _
                       "<POSTMAP_IBT_1></POSTMAP_IBT_1>" & _
                       "<POSTMAP_IBT_2></POSTMAP_IBT_2>" & _
                       "<POSTMAP_IBT_3></POSTMAP_IBT_3>" & _
                       "<APPTYPE></APPTYPE>" & _
                       "<APPMAP></APPMAP>" & _
                       "<APPCHK></APPCHK>" & _
                       "<TXMESSAGE></TXMESSAGE>" & _
                       "<SECURITIES_INFO></SECURITIES_INFO>" & _
                       "<SBCURRENCY></SBCURRENCY>" & _
                       "<GLREF></GLREF>" & _
                       "<GLREFCOM></GLREFCOM>" & _
                       "</ObjectBuffer>"
    Private Const DEF_SCHEMA_POSTMAP = "<?xml version='1.0' encoding='utf-16'?>" & _
                                        "<xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata' xmlns:msprop='urn:schemas-microsoft-com:xml-msprop'>" & _
                                        "<xs:element name='NewDataSet' msdata:IsDataSet='true'>" & _
                                            "<xs:complexType>" & _
                                            "<xs:choice maxOccurs='unbounded'>" & _
                                                "<xs:element name='Table' msprop:BaseTable.0='MAP'>" & _
                                                "<xs:complexType>" & _
                                                    "<xs:sequence>" & _
                                                    "<xs:element name='TLTXCD' msprop:OraDbType='126' msprop:BaseColumn='TLTXCD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='IBT' msprop:OraDbType='126' msprop:BaseColumn='IBT' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='DORC' msprop:OraDbType='126' msprop:BaseColumn='DORC' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDTYPE' msprop:OraDbType='126' msprop:BaseColumn='FLDTYPE' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='BRID' msprop:OraDbType='126' msprop:BaseColumn='BRID' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='ACNAME' msprop:OraDbType='126' msprop:BaseColumn='ACNAME' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='AMTEXP' msprop:OraDbType='126' msprop:BaseColumn='AMTEXP' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDCCY' msprop:OraDbType='126' msprop:BaseColumn='FLDCCY' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='ACFLD' msprop:OraDbType='126' msprop:BaseColumn='ACFLD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='SUBTXNO' msprop:OraDbType='126' msprop:BaseColumn='SUBTXNO' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='REFFLD' msprop:OraDbType='126' msprop:BaseColumn='REFFLD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='NEGATIVECD' msprop:OraDbType='126' msprop:BaseColumn='NEGATIVECD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDCUSTID' msprop:OraDbType='126' msprop:BaseColumn='FLDCUSTID' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDCUSTNAME' msprop:OraDbType='126' msprop:BaseColumn='FLDCUSTNAME' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDTASKCD' msprop:OraDbType='126' msprop:BaseColumn='FLDTASKCD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDDEPTCD' msprop:OraDbType='126' msprop:BaseColumn='FLDDEPTCD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDMICD' msprop:OraDbType='126' msprop:BaseColumn='FLDMICD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='ACCTNO' msprop:OraDbType='126' msprop:BaseColumn='ACCTNO' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FEECD' msprop:OraDbType='126' msprop:BaseColumn='FEECD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='ISRUN' msprop:OraDbType='126' msprop:BaseColumn='ISRUN' type='xs:string' minOccurs='0' />" & _
                                                    "</xs:sequence>" & _
                                                "</xs:complexType>" & _
                                                "</xs:element>" & _
                                            "</xs:choice>" & _
                                            "</xs:complexType>" & _
                                        "</xs:element>" & _
                                        "</xs:schema>"
    Private Const DEF_SCHEMA_APPMAP = "<?xml version='1.0' encoding='utf-16'?>" & _
                                        "<xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata' xmlns:msprop='urn:schemas-microsoft-com:xml-msprop'>" & _
                                        "<xs:element name='NewDataSet' msdata:IsDataSet='true'>" & _
                                            "<xs:complexType>" & _
                                            "<xs:choice maxOccurs='unbounded'>" & _
                                                "<xs:element name='Table' msprop:BaseTable.0='APP'>" & _
                                                "<xs:complexType>" & _
                                                    "<xs:sequence>" & _
                                                    "<xs:element name='TLTXCD' msprop:OraDbType='126' msprop:BaseColumn='TLTXCD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='APPTYPE' msprop:OraDbType='126' msprop:BaseColumn='APPTYPE' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='TBLNAME' msprop:OraDbType='126' msprop:BaseColumn='TBLNAME' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='APPTXCD' msprop:OraDbType='126' msprop:BaseColumn='APPTXCD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='ACFLD' msprop:OraDbType='126' msprop:BaseColumn='ACFLD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='AMTEXP' msprop:OraDbType='126' msprop:BaseColumn='AMTEXP' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDKEY' msprop:OraDbType='126' msprop:BaseColumn='FLDKEY' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='COND' msprop:OraDbType='126' msprop:BaseColumn='COND' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='ACFLDREF' msprop:OraDbType='126' msprop:BaseColumn='ACFLDREF' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='TXTYPE' msprop:OraDbType='126' msprop:BaseColumn='TXTYPE' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FIELD' msprop:OraDbType='126' msprop:BaseColumn='FIELD' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDTYPE' msprop:OraDbType='126' msprop:BaseColumn='FLDTYPE' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='TRANF' msprop:OraDbType='126' msprop:BaseColumn='TRANF' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='OFILE' msprop:OraDbType='126' msprop:BaseColumn='OFILE' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='OFILEACT' msprop:OraDbType='126' msprop:BaseColumn='OFILEACT' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='ISRUN' msprop:OraDbType='126' msprop:BaseColumn='ISRUN' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='FLDRND' msprop:OraDbType='126' msprop:BaseColumn='FLDRND' type='xs:string' minOccurs='0' />" & _
                                                    "<xs:element name='TRDESC' msprop:OraDbType='126' msprop:BaseColumn='TRDESC' type='xs:string' minOccurs='0' />" & _
                                                    "</xs:sequence>" & _
                                                "</xs:complexType>" & _
                                                "</xs:element>" & _
                                            "</xs:choice>" & _
                                            "</xs:complexType>" & _
                                        "</xs:element>" & _
                                        "</xs:schema>"
    'Private Const DEF_SCHEMA_APPCHK = "<?xml version='1.0' encoding='utf-16'?>" & _
    '                                    "<xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata' xmlns:msprop='urn:schemas-microsoft-com:xml-msprop'>" & _
    '                                    "<xs:element name='NewDataSet' msdata:IsDataSet='true'>" & _
    '                                        "<xs:complexType>" & _
    '                                        "<xs:choice maxOccurs='unbounded'>" & _
    '                                            "<xs:element name='Table' msprop:BaseTable.0='APP'>" & _
    '                                            "<xs:complexType>" & _
    '                                                "<xs:sequence>" & _
    '                                                    "<xs:element name='TLTXCD' msprop:OraDbType='126' msprop:BaseColumn='TLTXCD' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='APPTYPE' msprop:OraDbType='126' msprop:BaseColumn='APPTYPE' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='RULECD' msprop:OraDbType='126' msprop:BaseColumn='RULECD' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='ACFLD' msprop:OraDbType='126' msprop:BaseColumn='ACFLD' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='AMTEXP' msprop:OraDbType='126' msprop:BaseColumn='AMTEXP' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='FIELD' msprop:OraDbType='126' msprop:BaseColumn='FIELD' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='OPERAND' msprop:OraDbType='126' msprop:BaseColumn='OPERAND' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='ERRNUM' msprop:OraDbType='126' msprop:BaseColumn='ERRNUM' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='ERRMSG' msprop:OraDbType='126' msprop:BaseColumn='ERRMSG' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='TBLNAME' msprop:OraDbType='126' msprop:BaseColumn='TBLNAME' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='FLDKEY' msprop:OraDbType='126' msprop:BaseColumn='FLDKEY' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='REFID' msprop:OraDbType='126' msprop:BaseColumn='REFID' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='ISRUN' msprop:OraDbType='126' msprop:BaseColumn='ISRUN' type='xs:string' minOccurs='0' />" & _
    '                                                    "<xs:element name='FLDRND' msprop:OraDbType='126' msprop:BaseColumn='FLDRND' type='xs:string' minOccurs='0' />" & _
    '                                                "</xs:sequence>" & _
    '                                            "</xs:complexType>" & _
    '                                            "</xs:element>" & _
    '                                        "</xs:choice>" & _
    '                                        "</xs:complexType>" & _
    '                                    "</xs:element>" & _
    '                                    "</xs:schema>"
    Private Const DEF_SCHEMA_APPCHK = "<?xml version='1.0' encoding='utf-16'?>" & _
                                        "<xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata' xmlns:msprop='urn:schemas-microsoft-com:xml-msprop'>" & _
                                        "<xs:element name='NewDataSet' msdata:IsDataSet='true'>" & _
                                            "<xs:complexType>" & _
                                            "<xs:choice maxOccurs='unbounded'>" & _
                                                "<xs:element name='Table' msprop:BaseTable.0='APP'>" & _
                                                "<xs:complexType>" & _
                                                    "<xs:sequence>" & _
                                                        "<xs:element name='TLTXCD' msprop:OraDbType='126' msprop:BaseColumn='TLTXCD' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='APPTYPE' msprop:OraDbType='126' msprop:BaseColumn='APPTYPE' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='RULECD' msprop:OraDbType='126' msprop:BaseColumn='RULECD' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='ACFLD' msprop:OraDbType='126' msprop:BaseColumn='ACFLD' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='AMTEXP' msprop:OraDbType='126' msprop:BaseColumn='AMTEXP' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='FIELD' msprop:OraDbType='126' msprop:BaseColumn='FIELD' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='OPERAND' msprop:OraDbType='126' msprop:BaseColumn='OPERAND' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='ERRNUM' msprop:OraDbType='126' msprop:BaseColumn='ERRNUM' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='ERRMSG' msprop:OraDbType='126' msprop:BaseColumn='ERRMSG' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='TBLNAME' msprop:OraDbType='126' msprop:BaseColumn='TBLNAME' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='FLDKEY' msprop:OraDbType='126' msprop:BaseColumn='FLDKEY' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='REFID' msprop:OraDbType='126' msprop:BaseColumn='REFID' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='ISRUN' msprop:OraDbType='126' msprop:BaseColumn='ISRUN' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='FLDRND' msprop:OraDbType='126' msprop:BaseColumn='FLDRND' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='CHKLEV' msprop:OraDbType='126' msprop:BaseColumn='CHKLEV' type='xs:string' minOccurs='0' />" & _
                                                    "</xs:sequence>" & _
                                                "</xs:complexType>" & _
                                                "</xs:element>" & _
                                            "</xs:choice>" & _
                                            "</xs:complexType>" & _
                                        "</xs:element>" & _
                                        "</xs:schema>"

    Private Const DEF_SCHEMA_APPTYPE = "<?xml version='1.0' encoding='utf-16'?>" & _
                                        "<xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata' xmlns:msprop='urn:schemas-microsoft-com:xml-msprop'>" & _
                                        "<xs:element name='NewDataSet' msdata:IsDataSet='true'>" & _
                                            "<xs:complexType>" & _
                                            "<xs:choice maxOccurs='unbounded'>" & _
                                                "<xs:element name='Table' msprop:BaseTable.0='V'>" & _
                                                "<xs:complexType>" & _
                                                    "<xs:sequence>" & _
                                                        "<xs:element name='APPTYPE' msprop:OraDbType='126' msprop:BaseColumn='APPTYPE' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='TBLNAME' msprop:OraDbType='126' msprop:BaseColumn='TBLNAME' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='FLDKEY' msprop:OraDbType='126' msprop:BaseColumn='FLDKEY' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='ACFLD' msprop:OraDbType='126' msprop:BaseColumn='ACFLD' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='ISRUN' msprop:OraDbType='126' msprop:BaseColumn='ISRUN' type='xs:string' minOccurs='0' />" & _
                                                    "</xs:sequence>" & _
                                                "</xs:complexType>" & _
                                                "</xs:element>" & _
                                            "</xs:choice>" & _
                                            "</xs:complexType>" & _
                                        "</xs:element>" & _
                                        "</xs:schema>"
    Private Const DEF_SCHEMA_FLDMASTER = "<?xml version='1.0' encoding='utf-16'?>" & _
                                        "<xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata' xmlns:msprop='urn:schemas-microsoft-com:xml-msprop'>" & _
                                        "<xs:element name='NewDataSet' msdata:IsDataSet='true'>" & _
                                            "<xs:complexType>" & _
                                            "<xs:choice maxOccurs='unbounded'>" & _
                                                "<xs:element name='Table' msprop:BaseTable.0='TLTX'>" & _
                                                "<xs:complexType>" & _
                                                    "<xs:sequence>" & _
                                                        "<xs:element name='FLDNAME' msprop:OraDbType='126' msprop:BaseColumn='FLDNAME' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='FLDTYPE' msprop:OraDbType='126' msprop:BaseColumn='FLDTYPE' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='DEFNAME' msprop:OraDbType='126' msprop:BaseColumn='DEFNAME' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='TLTXDESC' msprop:OraDbType='126' msprop:BaseColumn='TLTXDESC' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='MSG_ACCT' msprop:OraDbType='126' msprop:BaseColumn='MSG_ACCT' type='xs:string' minOccurs='0' />" & _
                                                    "</xs:sequence>" & _
                                                "</xs:complexType>" & _
                                                "</xs:element>" & _
                                            "</xs:choice>" & _
                                            "</xs:complexType>" & _
                                        "</xs:element>" & _
                                        "</xs:schema>"
    Private Const DEF_SCHEMA_SBCURRENCY = "<?xml version='1.0' encoding='utf-16'?>" & _
                                        "<xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata' xmlns:msprop='urn:schemas-microsoft-com:xml-msprop'>" & _
                                        "<xs:element name='NewDataSet' msdata:IsDataSet='true'>" & _
                                            "<xs:complexType>" & _
                                            "<xs:choice maxOccurs='unbounded'>" & _
                                                "<xs:element name='Table' msprop:BaseTable.0='SBCURRENCY'>" & _
                                                "<xs:complexType>" & _
                                                    "<xs:sequence>" & _
                                                        "<xs:element name='CCYCD' msprop:OraDbType='126' msprop:BaseColumn='CCYCD' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='CCYDECIMAL' msprop:OraDbType='126' msprop:BaseColumn='CCYDECIMAL' type='xs:string' minOccurs='0' />" & _
                                                    "</xs:sequence>" & _
                                                "</xs:complexType>" & _
                                                "</xs:element>" & _
                                            "</xs:choice>" & _
                                            "</xs:complexType>" & _
                                        "</xs:element>" & _
                                        "</xs:schema>"
    Private Const DEF_SCHEMA_GLREF = "<?xml version='1.0' encoding='utf-16'?>" & _
                                        "<xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata' xmlns:msprop='urn:schemas-microsoft-com:xml-msprop'>" & _
                                        "<xs:element name='NewDataSet' msdata:IsDataSet='true'>" & _
                                            "<xs:complexType>" & _
                                            "<xs:choice maxOccurs='unbounded'>" & _
                                                "<xs:element name='Table' msprop:BaseTable.0='GLREF'>" & _
                                                "<xs:complexType>" & _
                                                    "<xs:sequence>" & _
                                                        "<xs:element name='APPTYPE' msprop:OraDbType='126' msprop:BaseColumn='APPTYPE' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='GLGRP' msprop:OraDbType='126' msprop:BaseColumn='GLGRP' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='ACNAME' msprop:OraDbType='126' msprop:BaseColumn='ACNAME' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='ACCTNO' msprop:OraDbType='126' msprop:BaseColumn='ACCTNO' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='REFKEY' msprop:OraDbType='126' msprop:BaseColumn='REFKEY' type='xs:string' minOccurs='0' />" & _
                                                    "</xs:sequence>" & _
                                                "</xs:complexType>" & _
                                                "</xs:element>" & _
                                            "</xs:choice>" & _
                                            "</xs:complexType>" & _
                                        "</xs:element>" & _
                                        "</xs:schema>"
    Private Const DEF_SCHEMA_GLREFCOM = "<?xml version='1.0' encoding='utf-16'?>" & _
                                        "<xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata' xmlns:msprop='urn:schemas-microsoft-com:xml-msprop'>" & _
                                        "<xs:element name='NewDataSet' msdata:IsDataSet='true'>" & _
                                            "<xs:complexType>" & _
                                            "<xs:choice maxOccurs='unbounded'>" & _
                                                "<xs:element name='Table' msprop:BaseTable.0='GLREFCOM'>" & _
                                                "<xs:complexType>" & _
                                                    "<xs:sequence>" & _
                                                        "<xs:element name='ACNAME' msprop:OraDbType='126' msprop:BaseColumn='ACNAME' type='xs:string' minOccurs='0' />" & _
                                                        "<xs:element name='ACCTNO' msprop:OraDbType='126' msprop:BaseColumn='ACCTNO' type='xs:string' minOccurs='0' />" & _
                                                    "</xs:sequence>" & _
                                                "</xs:complexType>" & _
                                                "</xs:element>" & _
                                            "</xs:choice>" & _
                                            "</xs:complexType>" & _
                                        "</xs:element>" & _
                                        "</xs:schema>"
#End Region

    Private Sub InitializeSharedProperties()
        Dim v_ds, v_ds_cache As DataSet, i, j, k As Integer, v_strTEMP As String
        Dim v_TLTXCD As TLTX_OFFSET, v_strRETURN As String
        Try
            '*****************************************************************************************
            'Load parameters from database, the ORDER BY clause is very important. It cannot change  *
            '*****************************************************************************************
            Dim v_db As New DataAccess
            v_db.NewDBInstance(gc_MODULE_HOST)
            Dim v_strSQL, v_strTLTXCD As String

            'Cache SBCURRENCY
            v_strSQL = "SELECT CCYCD, CCYDECIMAL FROM SBCURRENCY ORDER BY CCYCD"
            v_ds = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            ATTR_SBCURRENCY = v_ds.GetXml

            'Cache GLREF
            v_strSQL = "SELECT APPTYPE, GLGRP, ACNAME, ACCTNO, APPTYPE || GLGRP || ACNAME REFKEY FROM GLREF ORDER BY APPTYPE, GLGRP, ACNAME"
            v_ds = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            ATTR_GLREF = v_ds.GetXml

            'Cache GLREFCOM
            v_strSQL = "SELECT ACNAME, ACCTNO FROM GLREFCOM ORDER BY ACNAME"
            v_ds = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            ATTR_GLREFCOM = v_ds.GetXml

            '*****************************************************************************************
            'Create shared properties for TLTXCD                                                     *
            '*****************************************************************************************
            'Create the GroupManager
            'TruongLD comment when convert
            'spmGroupManager = New SharedPropertyGroupManager
            'spmGroup = spmGroupManager.CreatePropertyGroup(gc_HOSTGRP, _
            '    PropertyLockMode.Method, PropertyReleaseMode.Process, bExist)

            'Dim spmPropertyCURRENCY As SharedProperty = spmGroup.CreateProperty(gc_SHARED_SBCURRENCY, bExist)
            'spmPropertyCURRENCY.Value = ATTR_SBCURRENCY
            'Dim spmPropertyGLREF As SharedProperty = spmGroup.CreateProperty(gc_SHARED_GLREF, bExist)
            'spmPropertyGLREF.Value = ATTR_GLREF
            'Dim spmPropertyGLREFCOM As SharedProperty = spmGroup.CreateProperty(gc_SHARED_GLREFCOM, bExist)
            'spmPropertyGLREFCOM.Value = ATTR_GLREFCOM

            'TruongLD Add when convert
            _HostParameterCache.Flush()
            _HostParameterCache.Add(gc_SHARED_SBCURRENCY, ATTR_SBCURRENCY)

            _HostParameterCache.Add(gc_SHARED_GLREF, ATTR_GLREF)

            _HostParameterCache.Add(gc_SHARED_GLREFCOM, ATTR_GLREFCOM)
            'End TruongLD

            'Build original transaction message
            Dim v_strOrgTxMsg As String = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsNotLocalMsg, , "0000", "0000", "HOST", "HOST")
            Dim v_xmlDocumentOrgTxMsg As New Xml.XmlDocument
            Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode

            'Get list of business module
            v_strSQL = "SELECT TX.TLTXCD, TX.MSG_ACCT ACCTFLDCD, TX.IBT, TX.TXTYPE, APP.TXCODE, APP.MODCODE FROM TLTX TX, APPMODULES APP " _
                    & "WHERE TX.TXTYPE<>'I' AND SUBSTR(TX.TLTXCD,1, 2)=APP.TXCODE ORDER BY TX.TLTXCD"
            v_ds = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
            If v_ds.Tables(0).Rows.Count > 0 Then
                mv_XMLBuffer = New XmlDocumentEx
                mv_XMLBuffer.LoadXml(DEF_SCHEMA_BUFFER)
                Dim v_objTLTX_OFFSET As TLTX_OFFSET
                Dim v_strVALEXP, v_strFLDVALUE, v_strFLDNAME, v_strDEFNAME, v_strFLDTYPE As String, v_intFLDMASTER As Integer
                Dim v_attrDEFNAME, v_attrFLDNAME, v_attrDATATYPE As Xml.XmlAttribute


                For i = 0 To v_ds.Tables(0).Rows.Count - 1 Step 1
                    v_strTLTXCD = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TLTXCD")).Trim
                    v_objTLTX_OFFSET.TLTXCD = v_strTLTXCD
                    v_objTLTX_OFFSET.ACCTFLDCD = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("ACCTFLDCD")).Trim
                    v_objTLTX_OFFSET.IBT = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("IBT")).Trim
                    v_objTLTX_OFFSET.TXTYPE = gf_CorrectStringField(v_ds.Tables(0).Rows(i)("TXTYPE")).Trim

                    v_strSQL = "SELECT FLDMASTER.FLDNAME, FLDMASTER.FLDTYPE, FLDMASTER.DEFNAME, TLTX.EN_TXDESC TLTXDESC, TLTX.MSG_ACCT  " & ControlChars.CrLf _
                        & "FROM FLDMASTER, TLTX WHERE TLTX.TLTXCD=OBJNAME AND OBJNAME='" & v_strTLTXCD & "' ORDER BY ODRNUM"
                    v_ds_cache = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds_cache.Tables(0).Rows.Count > 0 Then
                        v_objTLTX_OFFSET.XML_FLDMASTER = v_ds_cache.GetXml
                        'Build default transaction message schema
                        v_xmlDocumentOrgTxMsg.LoadXml(v_strOrgTxMsg)
                        v_dataElement = v_xmlDocumentOrgTxMsg.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                        'Create Transaction contents
                        For v_intFLDMASTER = 0 To v_ds_cache.Tables(0).Rows.Count - 1 Step 1
                            v_strDEFNAME = Trim(gf_CorrectStringField(v_ds_cache.Tables(0).Rows(v_intFLDMASTER)("DEFNAME")))
                            v_strFLDNAME = Trim(gf_CorrectStringField(v_ds_cache.Tables(0).Rows(v_intFLDMASTER)("FLDNAME")))
                            v_strFLDTYPE = Trim(gf_CorrectStringField(v_ds_cache.Tables(0).Rows(v_intFLDMASTER)("FLDTYPE")))

                            v_entryNode = v_xmlDocumentOrgTxMsg.CreateNode(Xml.XmlNodeType.Element, "entry", "")
                            'Add default field name
                            v_attrDEFNAME = v_xmlDocumentOrgTxMsg.CreateAttribute(gc_AtributeDEFNAME)
                            v_attrDEFNAME.Value = v_strDEFNAME
                            v_entryNode.Attributes.Append(v_attrDEFNAME)

                            'Add field name
                            v_attrFLDNAME = v_xmlDocumentOrgTxMsg.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlDocumentOrgTxMsg.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Set default value
                            If v_strFLDTYPE = "N" Then
                                v_strFLDVALUE = "0"
                            ElseIf v_strFLDTYPE = "C" Then
                                v_strFLDVALUE = String.Empty
                            ElseIf v_strFLDTYPE = "D" Then
                                v_strFLDVALUE = "01/01/2008"
                            End If
                            v_entryNode.InnerText = v_strFLDVALUE
                            v_dataElement.AppendChild(v_entryNode)
                        Next
                        v_xmlDocumentOrgTxMsg.DocumentElement.AppendChild(v_dataElement)
                        v_objTLTX_OFFSET.XML_TXMESSAGE = v_xmlDocumentOrgTxMsg.InnerXml
                    Else
                        v_objTLTX_OFFSET.XML_FLDMASTER = String.Empty
                    End If

                    v_strSQL = "SELECT DISTINCT APPTYPE, TBLNAME, FLDKEY, ACFLD, ISRUN " _
                        & "FROM V_APPCHK_BY_TLTXCD V WHERE V.TLTXCD = '" & v_strTLTXCD & "'"
                    v_ds_cache = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds_cache.Tables(0).Rows.Count > 0 Then
                        v_objTLTX_OFFSET.XML_APPTYPE = v_ds_cache.GetXml
                    Else
                        v_objTLTX_OFFSET.XML_APPTYPE = String.Empty
                    End If

                    'v_strSQL = "SELECT TLTXCD, APPTYPE, RULECD, ACFLD, AMTEXP, FIELD, OPERAND, ERRNUM, ERRMSG, TBLNAME, FLDKEY, REFID, ISRUN, FLDRND " _
                    '    & "FROM V_APPCHK_BY_TLTXCD APP WHERE APP.TLTXCD = '" & v_strTLTXCD & "' " _
                    '    & "ORDER BY APPTYPE, TBLNAME, FLDKEY, FIELD, RULECD"
                    v_strSQL = "SELECT TLTXCD, APPTYPE, RULECD, ACFLD, AMTEXP, FIELD, OPERAND, ERRNUM, ERRMSG, TBLNAME, FLDKEY, REFID, ISRUN, FLDRND, CHKLEV " _
                        & "FROM V_APPCHK_BY_TLTXCD APP WHERE APP.TLTXCD = '" & v_strTLTXCD & "' " _
                        & "ORDER BY CHKLEV DESC, APPTYPE, TBLNAME, FLDKEY, FIELD, RULECD"

                    v_ds_cache = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds_cache.Tables(0).Rows.Count > 0 Then
                        v_objTLTX_OFFSET.XML_APPCHK = v_ds_cache.GetXml
                    Else
                        v_objTLTX_OFFSET.XML_APPCHK = String.Empty
                    End If


                    v_strSQL = "SELECT TLTXCD, APPTYPE, TBLNAME, APPTXCD, NVL(ACFLD, ' ') ACFLD, NVL(AMTEXP, ' ') AMTEXP, " _
                        & "NVL(FLDKEY, ' ') FLDKEY, NVL(COND, ' ') COND, NVL(ACFLDREF, ' ') ACFLDREF, NVL(TXTYPE, ' ') TXTYPE, " _
                        & "NVL(FIELD, ' ') FIELD, NVL(FLDTYPE, ' ') FLDTYPE, NVL(TRANF, ' ') TRANF, NVL(OFILE, ' ') OFILE, NVL(OFILEACT, ' ') OFILEACT, NVL(ISRUN,'@1') ISRUN, NVL(FLDRND, ' ') FLDRND,APP.TRDESC " _
                        & "FROM V_APPMAP_BY_TLTXCD APP WHERE APP.TLTXCD = '" & v_strTLTXCD & "' " _
                        & " ORDER BY APPTYPE, ACFLD, TBLNAME, FIELD, FLDKEY, APPTXCD"
                    v_ds_cache = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    If v_ds_cache.Tables(0).Rows.Count > 0 Then
                        v_objTLTX_OFFSET.XML_APPMAP = v_ds_cache.GetXml
                    Else
                        v_objTLTX_OFFSET.XML_APPMAP = String.Empty
                    End If


                    'v_strSQL = "SELECT * FROM " _
                    '     & "(SELECT POSTMAP.*, REF.GLACCTNO ACCTNO, REF.FEECD FROM POSTMAP, FEEMASTER REF, FEEMAP WHERE POSTMAP.ACNAME='FEEMAST' " _
                    '     & " AND POSTMAP.TLTXCD=FEEMAP.TLTXCD AND FEEMAP.FEECD=REF.FEECD " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '0' AND POSTMAP.FLDTYPE = 'F' " _
                    '     & " UNION ALL " _
                    '     & " SELECT POSTMAP.*, REF.ACCTNO, NULL FEECD FROM POSTMAP, GLREFCOM REF WHERE POSTMAP.ACNAME = REF.ACNAME AND POSTMAP.ACNAME<>'FEEMAST' " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '0' AND POSTMAP.FLDTYPE = 'F' " _
                    '     & " UNION ALL " _
                    '     & " SELECT POSTMAP.*, NULL ACCTNO, NULL FEECD FROM POSTMAP WHERE 0=0 " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '0' AND POSTMAP.FLDTYPE = 'V') MAP " _
                    '     & " ORDER BY SUBTXNO, DORC DESC"
                    'v_ds_cache = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'If v_ds_cache.Tables(0).Rows.Count > 0 Then
                    '    v_objTLTX_OFFSET.XML_POSTMAP_IBT_0 = v_ds_cache.GetXml
                    'Else
                    '    v_objTLTX_OFFSET.XML_POSTMAP_IBT_0 = String.Empty
                    'End If
                    v_objTLTX_OFFSET.XML_POSTMAP_IBT_0 = String.Empty



                    'v_strSQL = "SELECT * FROM " _
                    '     & "(SELECT POSTMAP.*, REF.GLACCTNO ACCTNO, REF.FEECD FROM POSTMAP, FEEMASTER REF, FEEMAP WHERE POSTMAP.ACNAME='FEEMAST' " _
                    '     & " AND POSTMAP.TLTXCD=FEEMAP.TLTXCD AND FEEMAP.FEECD=REF.FEECD " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '1' AND POSTMAP.FLDTYPE = 'F' " _
                    '     & " UNION ALL " _
                    '     & " SELECT POSTMAP.*, REF.ACCTNO, NULL FEECD FROM POSTMAP, GLREFCOM REF WHERE POSTMAP.ACNAME = REF.ACNAME AND POSTMAP.ACNAME<>'FEEMAST' " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '1' AND POSTMAP.FLDTYPE = 'F' " _
                    '     & " UNION ALL " _
                    '     & " SELECT POSTMAP.*, NULL ACCTNO, NULL FEECD FROM POSTMAP WHERE 0=0 " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '1' AND POSTMAP.FLDTYPE = 'V') MAP " _
                    '     & " ORDER BY SUBTXNO, DORC DESC"
                    'v_ds_cache = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'If v_ds_cache.Tables(0).Rows.Count > 0 Then
                    '    v_objTLTX_OFFSET.XML_POSTMAP_IBT_1 = v_ds_cache.GetXml
                    'Else
                    '    v_objTLTX_OFFSET.XML_POSTMAP_IBT_1 = String.Empty
                    'End If
                    v_objTLTX_OFFSET.XML_POSTMAP_IBT_1 = String.Empty

                    'v_strSQL = "SELECT * FROM " _
                    '     & "(SELECT POSTMAP.*, REF.GLACCTNO ACCTNO, REF.FEECD FROM POSTMAP, FEEMASTER REF, FEEMAP WHERE POSTMAP.ACNAME='FEEMAST' " _
                    '     & " AND POSTMAP.TLTXCD=FEEMAP.TLTXCD AND FEEMAP.FEECD=REF.FEECD " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '2' AND POSTMAP.FLDTYPE = 'F' " _
                    '     & " UNION ALL " _
                    '     & " SELECT POSTMAP.*, REF.ACCTNO, NULL FEECD FROM POSTMAP, GLREFCOM REF WHERE POSTMAP.ACNAME = REF.ACNAME AND POSTMAP.ACNAME<>'FEEMAST' " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '2' AND POSTMAP.FLDTYPE = 'F' " _
                    '     & " UNION ALL " _
                    '     & " SELECT POSTMAP.*, NULL ACCTNO, NULL FEECD FROM POSTMAP WHERE 0=0 " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '2' AND POSTMAP.FLDTYPE = 'V') MAP " _
                    '     & " ORDER BY SUBTXNO, DORC DESC"
                    'v_ds_cache = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'If v_ds_cache.Tables(0).Rows.Count > 0 Then
                    '    v_objTLTX_OFFSET.XML_POSTMAP_IBT_2 = v_ds_cache.GetXml
                    'Else
                    '    v_objTLTX_OFFSET.XML_POSTMAP_IBT_2 = String.Empty
                    'End If
                    v_objTLTX_OFFSET.XML_POSTMAP_IBT_2 = String.Empty

                    'v_strSQL = "SELECT * FROM " _
                    '     & "(SELECT POSTMAP.*, REF.GLACCTNO ACCTNO, REF.FEECD FROM POSTMAP, FEEMASTER REF, FEEMAP WHERE POSTMAP.ACNAME='FEEMAST' " _
                    '     & " AND POSTMAP.TLTXCD=FEEMAP.TLTXCD AND FEEMAP.FEECD=REF.FEECD " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '3' AND POSTMAP.FLDTYPE = 'F' " _
                    '     & " UNION ALL " _
                    '     & " SELECT POSTMAP.*, REF.ACCTNO, NULL FEECD FROM POSTMAP, GLREFCOM REF WHERE POSTMAP.ACNAME = REF.ACNAME AND POSTMAP.ACNAME<>'FEEMAST' " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '3' AND POSTMAP.FLDTYPE = 'F' " _
                    '     & " UNION ALL " _
                    '     & " SELECT POSTMAP.*, NULL ACCTNO, NULL FEECD FROM POSTMAP WHERE 0=0 " _
                    '     & " AND POSTMAP.TLTXCD = '" & v_strTLTXCD & "' AND POSTMAP.IBT = '3' AND POSTMAP.FLDTYPE = 'V') MAP " _
                    '     & " ORDER BY SUBTXNO, DORC DESC"
                    'v_ds_cache = v_db.ExecuteSQLReturnDataset(CommandType.Text, v_strSQL)
                    'If v_ds_cache.Tables(0).Rows.Count > 0 Then
                    '    v_objTLTX_OFFSET.XML_POSTMAP_IBT_3 = v_ds_cache.GetXml
                    'Else
                    '    v_objTLTX_OFFSET.XML_POSTMAP_IBT_3 = String.Empty
                    'End If
                    v_objTLTX_OFFSET.XML_POSTMAP_IBT_3 = String.Empty

                    'Store information for TLTXCD
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/ACCTFLDCD").InnerText = v_objTLTX_OFFSET.ACCTFLDCD
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/IBT").InnerText = v_objTLTX_OFFSET.IBT
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/TXTYPE").InnerText = v_objTLTX_OFFSET.TXTYPE
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/FLDMASTER").InnerText = v_objTLTX_OFFSET.XML_FLDMASTER
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_0").InnerText = v_objTLTX_OFFSET.XML_POSTMAP_IBT_0
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_1").InnerText = v_objTLTX_OFFSET.XML_POSTMAP_IBT_1
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_2").InnerText = v_objTLTX_OFFSET.XML_POSTMAP_IBT_2
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_3").InnerText = v_objTLTX_OFFSET.XML_POSTMAP_IBT_3
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPTYPE").InnerText = v_objTLTX_OFFSET.XML_APPTYPE
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPMAP").InnerText = v_objTLTX_OFFSET.XML_APPMAP
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPCHK").InnerText = v_objTLTX_OFFSET.XML_APPCHK
                    mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/TXMESSAGE").InnerText = v_objTLTX_OFFSET.XML_TXMESSAGE

                    'TruongLD comment when convert
                    ''Duyet tuan tu cac ma giao dich de dua vao cache trong bo nho
                    'Dim spmPropertyTLTX As SharedProperty = spmGroup.CreateProperty(gc_SHARED_TLTX & "_" & v_strTLTXCD, bExist)
                    'spmPropertyTLTX.Value = mv_XMLBuffer.InnerXml

                    'TruongLD Add when convert
                    _HostParameterCache.Add(gc_SHARED_TLTX & "_" & v_strTLTXCD, mv_XMLBuffer.InnerXml)
                    'End TruongLD
                Next
            End If

            'TruongLD comment when convert
            'spmProperty = spmGroup.CreateProperty(gc_HOSTGRP_FLAG, bExist)
            'spmProperty.Value = "Y"

            'TruongLD Add when convert
            _HostParameterCache.Add(gc_HOSTGRP_FLAG, "Y")
            'End TruongLD
        Catch ex As Exception
            Throw ex
        Finally
            If Not v_ds Is Nothing Then
                v_ds.Dispose()
            End If
            If Not v_ds_cache Is Nothing Then
                v_ds_cache.Dispose()
            End If
        End Try
    End Sub


    Public Function ResetCache() As String
        Try
            InitializeSharedProperties()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TLTXGetPropertyValue(ByVal v_strTLTXCD As String) As String
        Dim i As Integer, v_TLTXCD As TLTX_OFFSET, v_strRETURN, v_strISCACHE As String
        If (Not ConfigurationSettings.AppSettings("HOSTSRV.Cache") Is Nothing) Then
            v_strISCACHE = ConfigurationSettings.AppSettings("HOSTSRV.Cache")
        End If
        If v_strISCACHE = "Y" Then

            'TruongLD comment when convert  
            'Try
            '    spmGroupManager = New SharedPropertyGroupManager
            '    v_strRETURN = CType(spmGroupManager.Group(gc_HOSTGRP).Property(gc_HOSTGRP_FLAG).Value, String)
            'Catch ex As Exception
            '    'Initialize the cache if the property not found
            '    InitializeSharedProperties()
            'End Try

            'TruongLD add new when convert
            If Not _HostParameterCache.Contains(gc_SHARED_TLTX & "_" & v_strTLTXCD) Then
                InitializeSharedProperties()
            End If
            'End TruongLD

            '#If DEBUG Then
            '            InitializeSharedProperties()
            '#End If
            v_strRETURN = String.Empty
            'TruongLD comment when convert
            'ATTR_SBCURRENCY = CType(spmGroupManager.Group(gc_HOSTGRP).Property(gc_SHARED_SBCURRENCY).Value, String)
            'ATTR_GLREF = CType(spmGroupManager.Group(gc_HOSTGRP).Property(gc_SHARED_GLREF).Value, String)
            'ATTR_GLREFCOM = CType(spmGroupManager.Group(gc_HOSTGRP).Property(gc_SHARED_GLREFCOM).Value, String)
            'ATTR_TLTXCD = CType(spmGroupManager.Group(gc_HOSTGRP).Property(gc_SHARED_TLTX & "_" & v_strTLTXCD).Value, String)

            'TruongLD add when convert
            ATTR_SBCURRENCY = CType(_HostParameterCache.GetData(gc_SHARED_SBCURRENCY), String)
            ATTR_GLREF = CType(_HostParameterCache.GetData(gc_SHARED_GLREF), String)
            ATTR_GLREFCOM = CType(_HostParameterCache.GetData(gc_SHARED_GLREFCOM), String)
            ATTR_TLTXCD = CType(_HostParameterCache.GetData(gc_SHARED_TLTX & "_" & v_strTLTXCD), String)
            'End TruongLD

            mv_XMLBuffer = New XmlDocumentEx
            mv_XMLBuffer.LoadXml(ATTR_TLTXCD)
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/SECURITIES_INFO").InnerText = String.Empty
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/SBCURRENCY").InnerText = ATTR_SBCURRENCY
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/GLREF").InnerText = ATTR_GLREF
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/GLREFCOM").InnerText = ATTR_GLREFCOM

            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/FLDMASTER_XSD").InnerText = DEF_SCHEMA_FLDMASTER
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/POSTMAP_IBT_XSD").InnerText = DEF_SCHEMA_POSTMAP
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPTYPE_XSD").InnerText = DEF_SCHEMA_APPTYPE
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPMAP_XSD").InnerText = DEF_SCHEMA_APPMAP
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/APPCHK_XSD").InnerText = DEF_SCHEMA_APPCHK
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/SECURITIES_INFO_XSD").InnerText = String.Empty
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/SBCURRENCY_XSD").InnerText = DEF_SCHEMA_SBCURRENCY
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/GLREF_XSD").InnerText = DEF_SCHEMA_GLREF
            mv_XMLBuffer.SelectSingleNode("/ObjectBuffer/GLREFCOM_XSD").InnerText = DEF_SCHEMA_GLREFCOM
            v_strRETURN = mv_XMLBuffer.InnerXml
        End If
        Return v_strRETURN
    End Function
End Class

