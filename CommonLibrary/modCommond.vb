﻿
Imports System.Reflection
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.ServiceModel
Imports System.Security
Imports System.Security.Cryptography
Imports System.Configuration
Imports System.Xml
Imports System.Configuration.ConfigurationSettings
Imports System.IO
Imports System.Xml.Serialization



<Serializable()> _
Public Class ValueDescriptionPair

    Private m_Value As Object
    Private m_Description As String

    Public ReadOnly Property Value() As Object
        Get
            Return m_Value
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return m_Description
        End Get
    End Property

    Public Sub New(ByVal NewValue As Object, ByVal NewDescription As String)
        m_Value = NewValue
        m_Description = NewDescription
    End Sub

    Public Overrides Function ToString() As String
        Return m_Description
    End Function

End Class

<Serializable()> _
Public Module modCommond

#Region " Language Constants"
    Public Const gc_LANG_VIETNAMESE = "VN"
    Public Const gc_LANG_ENGLISH = "EN"
    Public Const gc_ACTUALVERSION = "ACTUALVERSION"
    Public Const gc_AUTOUPDATE = "AUTOUPDATE"
#End Region

#Region " Authorization Mode constants "
    Public Const gc_AUTHORIZATION_MODE_LDAP = "LDAP"
    Public Const gc_AUTHORIZATION_MODE_DB = "DB"
    Public Const gc_AUTHORIZATION_MODE_NONE = "NONE"

#End Region

#Region " Common constants "

    Public Const gc_TRADELOG_REQUESTTYPE_LATEST As Integer = 1
    Public Const gc_TRADELOG_REQUESTTYPE_FROMIDX As Integer = 0

    Public Const gc_EXECUTE_ROWS = 100
    Public DEF_MR_RATE = 100000
    Public Const ADMIN_ID = "0001"
    Public Const HO_BRID = "0001"
    Public Const gc_COMPANY_CODE = "SHVF"
    Public Const HO_MBID = "1"

    Public Const gc_ApplicationTitle = "VSTP"

    'CÃ¡c háº±ng sá»‘ l
    Public Const gc_MODULE_BDS = "@VSTP_HOST"
    Public Const gc_MODULE_HOST = "@VSTP_HOST"
    Public Const gc_MODULE_PRS = "@VSTP_PRS"
    Public Const gc_MODULE_HOSTREPORT = "@VSTP_REPORT"
    Public Const gc_MODULE_HOSTSTANDBY = "@VSTP_STANDBY"
    Public Const gc_MODULE_QUEUE = "@VSTP_QUEUE"
    Public Const gc_MODULE_GXHOST = "@VSTP_GXHOST"
    Public Const gc_MODULE_SERVICE As String = "@VSTP_SERVICE"
    Public Const gc_MODULE_INFOSHOW5 As String = "@VSTP_INFOSHOW5"
    Public Const gc_AtributePAGENO = "PAGENO"
    Public Const ROWS_PER_PAGE = 25

    Public Const gc_AtributeHOSTTIME = "HOSTTIME"
    Public Const gc_AtributeLATE = "LATE"
    Public Const gc_AtributeGLGP = "GLGP"

    Public Const gc_FORMAT_QUEUEID = "0000000000"

    Public Const gc_WEB_SERVICE_TIMEOUT = 3600000
    Public Const DAILY_TRANSACTION = "DAY"
    Public Const MSGTRANS_DELETED = "Y"
    Public Const MSGTRANS_UNDELETE = "N"
    Public Const HOST_BRID = "0001"
    Public Const OPERATION_INACTIVE = "0"
    Public Const OPERATION_ACTIVE = "1"
    Public Const BRGRP_ACTIVE = "A"
    Public Const BRGRP_OFFLINE = "O"
    Public Const BRGRP_CLOSED = "C"
    Public Const BATCH_PREFIXED = "99"
    Public Const COREBANK_PREFIXED = "98"
    Public Const FO_PREFIXED = "80"
    Public Const GV_PREFIXED = "90"

    'Háº±ng sá»‘ nguyÃªn nhÃ¢n duyá»‡t giao dá»‹ch
    Public Const gc_OFFID_OVRRQS = "@00"
    Public Const OVRRQS_CHECKER_CONTROL = "@00"
    Public Const OVRRQS_TRANSACTIONLIMIT = "@01"
    Public Const OVRRQS_CASHIERLIMIT = "@02"
    Public Const OVRRQS_APPROVELIMIT = "@03"
    Public Const OVRRQS_CUSTOMERLIMIT = "@04"
    Public Const OVRRQS_INTERBRANCH = "@05"
    Public Const OVRRQS_DELETETRANSACTION = "@06"
    Public Const OVRRQS_CONTRACTLIMIT = "@07"
    Public Const OVRRQS_SECURERATIO = "@08"
    Public Const OVRRQS_SPECIAL = "@09"
    Public Const OVRRQS_OVERMARGINLIMIT = "@10"
    Public Const OVRRQS_ORDERTRADELIMIT = "@11"
    Public Const OVRRQS_ORDERSECURERATIO = "@12"
    Public Const OVRRQS_AFTRADELIMIT = "@13"
    Public Const OVRRQS_MARGINLIMIT = "@14"
    Public Const OVRRQS_TRADELIMIT = "@15"
    Public Const OVRRQS_ADVANCELIMIT = "@16"
    Public Const OVRRQS_REPOLIMIT = "@17"
    Public Const OVRRQS_DEPOSITLIMIT = "@18"
    Public Const OVRRQS_OVERDUE = "@19"

    Public Const OVRRQS_ISSUERCONTROLLIST = "@20"
    Public Const OVRRQS_OVERMONITORRATE = "@21"
    Public Const OVRRQS_TRAN_BACKDATE = "@22"

    'Hang so ma giao dich CoreBank
    Public Const TXCODE_HOLD = "HLD"
    Public Const TXCODE_UNHOLD = "UHD"
    Public Const TXCODE_TRANSFER = "TRF"
    Public Const TXCODE_INQUIRY = "INQ"

    'Attribute EATMessage
    Public Const gc_AtributeMSGID = "MSGID"
    Public Const gc_AtributeQUEUENAME = "QUEUENAME"
    Public Const gc_AtributeRECEIVETIME = "RECEIVETIME"
    Public Const gc_AtributeRECEIVEDATE = "RECEIVEDATE"
    Public Const gc_AtributeSENDTIME = "SENDTIME"
    Public Const gc_AtributeSENDDATE = "SENDDATE"
    Public Const gc_AtributeTXCODE = "TXCODE"
    Public Const gc_AtributeACCTNO = "ACCTNO"
    Public Const gc_AtributeACCTNO2 = "ACCTNO2"
    Public Const gc_AtributeBANKCODE = "BANKCODE"
    Public Const gc_AtributeBANKERRNUM = "BANKERRNUM"
    Public Const gc_AtributeBANKERRDESC = "BANKERRDESC"
    Public Const gc_AtributeBANKREF = "BANKREF"
    Public Const gc_AtributeERRNUM = "ERRNUM"

    'Atribute ObjectMessage & TransactMessage
    Public Const gc_AtributeTXDATE = "TXDATE"
    Public Const gc_AtributeTXTIME = "TXTIME"
    Public Const gc_AtributeBRDATE = "BRDATE"
    Public Const gc_AtributeBUSDATE = "BUSDATE"
    Public Const gc_AtributeTXNUM = "TXNUM"
    Public Const gc_AtributeLOCAL = "LOCAL"
    Public Const gc_AtributePRETRAN = "PRETRAN"
    Public Const gc_AtributeSTOREPROC = "STOREPROC"
    Public Const gc_AtributePARAM_NAME = "PARAMNAME"
    Public Const gc_AtributePARAM_VALUE = "PARAMVALUE"
    Public Const gc_AtributePARAM_SIZE = "PARAMSIZE"
    Public Const gc_AtributePARAM_TYPE = "PARAMTYPE"
    Public Const gc_AtributeNUM_OF_PARAM = "NUM_OF_PARAM"
    Public Const gc_AtributeTLID = "TLID"
    Public Const gc_AtributeCMDID = "CMDID"
    Public Const gc_AtributeGRPID = "GRPID"
    Public Const gc_AtributeBRID = "BRID"
    Public Const gc_AtributeCMDTYPE = "CMDTYPE"
    Public Const gc_AtributeWSNAME = "WSNAME"
    Public Const gc_AtributeOFFID = "OFFID"
    Public Const gc_AtributeCHKID = "CHKID"
    Public Const gc_AtributeCHID = "CHID"
    Public Const gc_AtributeTLID2 = "TLID2"
    Public Const gc_AtributeBRID2 = "BRID2"
    Public Const gc_AtributeIBT = "IBT"
    Public Const gc_AtributeMSGAMT = "MSGAMT"
    Public Const gc_AtributeMSGACCT = "MSGACCT"
    Public Const gc_AtributeCHKTIME = "CHKTIME"
    Public Const gc_AtributeOFFTIME = "OFFTIME"
    Public Const gc_AtributePARENTOBJNAME = "PARENTOBJNAME"
    Public Const gc_AtributePARENTCLAUSE = "PARENTCLAUSE"
    Public Const gc_AtributeUSERLANGUAGE = "USERLANGUAGE"   '03/10/2017 DieuNDA Song ngu


    Public Const gc_AtributeUPDATEMODE = "UPDATEMODE"
    Public Const gc_AtributeOVRRQS = "OVRRQD"
    Public Const gc_AtributeDELTD = "DELTD"
    Public Const gc_AtributeSTATUS = "STATUS"
    Public Const gc_AtributeBATCHNAME = "BATCHNAME"
    Public Const gc_AtributeTLTXCD = "TLTXCD"
    Public Const gc_AtributeNOSUBMIT = "NOSUBMIT"
    Public Const gc_AtributeDELALLOW = "DELALLOW"
    Public Const gc_AtributeTXTYPE = "TXTYPE"
    Public Const gc_AtributeCCYUSAGE = "CCYUSAGE"
    Public Const gc_AtributeOFFLINE = "OFFLINE"
    Public Const gc_AtributeMSGSTS = "MSGSTS"
    Public Const gc_AtributeOVRSTS = "OVRSTS"
    Public Const gc_AtributeFEEAMT = "FEEAMT"
    Public Const gc_AtributeVATAMT = "VATAMT"
    Public Const gc_AtributeVOUCHER = "VOUCHER"
    Public Const gc_AtributeTXDESC = "TXDESC"

    Public Const gc_AtributeMSGTYPE = "MSGTYPE"
    Public Const gc_AtributeTXACTION As String = "ACTIONFLAG" ' TIENPQ ADDED: 
    Public Const gc_AtributeOBJNAME = "OBJNAME"
    Public Const gc_AtributeFUNCNAME = "FUNCTIONNAME"
    Public Const gc_AtributeACTFLAG = "ACTIONFLAG"
    Public Const gc_AtributeCLAUSE = "CLAUSE"
    Public Const gc_AtributeCMDINQUIRY = "CMDINQUIRY"
    Public Const gc_AtributeAUTOID = "AUTOID"
    Public Const gc_AtributeREFERENCE = "REFERENCE"
    Public Const gc_AtributeRESERVER = "RESERVER"

    Public Const gc_AtributeFLDTXDESC = "30"
    Public Const gc_AtributeFLDNAME = "fldname"
    Public Const gc_AtributeFLDTYPE = "fldtype"
    Public Const gc_AtributeDEFNAME = "defname"

    Public Const gc_AtributeMODCODE = "MODCODE"
    Public Const gc_AtributeCAREBY = "CAREBY"

    'trung.luu
    'locpt TFLEX.SA0002
    Public Const gc_AtributeSESSIONID = "SESSIONID"
    Public Const gc_AtributeIPADDRESS = "IPADDRESS"
    Public Const gc_AtributeREQUESTID = "REQUESTID"

    'TungNT added - for batchmessage of bank
    Public Const gc_AtributeVERSION = "VERSION"
    Public Const gc_AtributeVERSIONLOCAL = "LOCALVERSION"
    Public Const gc_AtributeTRANSDATE = "TRANSDATE"
    Public Const gc_AtributeAFFECTDATE = "AFFECTDATE"
    Public Const gc_AtributeBATCHTYPE = "BATCHTYPE"
    Public Const gc_AtributeCORD = "CORD"
    Public Const gc_AtributeUNHOLD = "UNHOLD"
    'End

    'WARNING-ERROR
    Public Const gc_AtributeWARNING = "WARNING"

    Public Const gc_ERROR_MESSAGE = "0"
    Public Const gc_WARNING_MESSAGE = "1"
    Public Const gc_INFO_MESSAGE = "2"

    Public Const gc_RM_TCDTGWFUNCNAME_GETCREDITLIST = "TCDTGETCREDITLIST"
    Public Const gc_RM_TCDTGWFUNCNAME_REQUESTTRANSFER = "TCDTREQUESTTRANSFER"
    Public Const gc_RM_TCDTGWFUNCNAME_GETTRANSFERRESULT = "TCDTGETTRANSFERRESULT"
    Public Const gc_RM_TCDTGWFUNCNAME_GETBANKIDLIST = "TCDTGETBANKIDLIST"
    Public Const gc_RM_TCDTGWFUNCNAME_TRANSFERRECONCIDE = "TCDTTRANSFERRECONCIDE"
    Public Const gc_RM_TCDTGWFUNCNAME_SENDRECONCIDE = "TCDTSENDRECONCIDE"


    Public Const gc_RM_GWFUNCNAME_REGISTERACCOUNT = "REGISTERACCOUNT"
    Public Const gc_RM_GWFUNCNAME_DISABLEACCOUNT = "DISABLEACCOUNT"
    Public Const gc_RM_GWFUNCNAME_CHECKAUTHORIZE = "CHECKAUTHORIZE"

    Public Const gc_RM_GWFUNCNAME_CHECKBALANCE = "CHECKBALANCE"
    Public Const gc_RM_GWFUNCNAME_GETBALANCE = "GETBALANCE"
    Public Const gc_RM_GWFUNCNAME_HOLDBALANCE = "HOLDBALANCE"
    Public Const gc_RM_GWFUNCNAME_UNHOLDBALANCE = "UNHOLDBALANCE"
    Public Const gc_RM_GWFUNCNAME_TRFEODREPORT = "TRFEODREPORT"
    Public Const gc_RM_GWFUNCNAME_GETEODSTATUS = "GETEODSTATUS"
    Public Const gc_RM_GWFUNCNAME_GETTRANSLIST = "GETTRANSLIST"

    Public Const gc_RM_GWPARAM_CUSTODYCD = "CUSTODYCD"
    Public Const gc_RM_GWPARAM_IDCODE = "IDCODE"
    Public Const gc_RM_GWPARAM_AFACCTNO = "AFACCTNO"
    Public Const gc_RM_GWPARAM_CUSTBANKACCTNO = "CUSTBANKACCTNO"
    Public Const gc_RM_GWPARAM_CUSTBANKACCTNAME = "CUSTBANKACCTNAME"
    Public Const gc_RM_GWPARAM_BANKACCTNO = "BANKACCTNO"
    Public Const gc_RM_GWPARAM_BANKACCTNAME = "BANKACCTNAME"
    Public Const gc_RM_GWPARAM_AMOUNT = "AMOUNT"
    Public Const gc_RM_GWPARAM_DESCRIPTION = "DESCRIPTION"
    Public Const gc_RM_GWPARAM_VERSION = "VERSION"
    Public Const gc_RM_GWPARAM_LOCALVERSION = "LOCALVERSION"
    Public Const gc_RM_GWPARAM_TRFCODE = "TRFCODE"
    Public Const gc_RM_GWPARAM_TXDATE = "TXDATE"
    Public Const gc_RM_GWPARAM_CORD = "CORD"
    Public Const gc_RM_GWPARAM_UNHOLD = "UNHOLD"

    Public Const gc_CoreBank_BatchStatus_Pending = "P"
    Public Const gc_CoreBank_BatchStatus_Approval = "A"
    Public Const gc_CoreBank_BatchStatus_Sent = "S"
    Public Const gc_CoreBank_BatchStatus_Rejected = "R"
    Public Const gc_CoreBank_BatchStatus_Confirmed = "C"
    Public Const gc_CoreBank_BatchStatus_Error = "E"
    Public Const gc_CoreBank_BatchStatus_FullyComplete = "F"
    Public Const gc_CoreBank_BatchStatus_HalfComplete = "H"


    'MessagePrintInfo
    Public Const gc_PrintInfoCUSTNAME = "CUSTNAME"
    Public Const gc_PrintInfoADDRESS = "ADDRESS"
    Public Const gc_PrintInfoLICENSE = "LICENSE"
    Public Const gc_PrintInfoIDDATE = "IDDATE"
    Public Const gc_PrintInfoIDPLACE = "IDPLACE"
    Public Const gc_PrintInfoBANKACCT = "BANKACCT"
    Public Const gc_PrintInfoBANKNAME = "BANKNAME"
    Public Const gc_PrintInfoBANKQUE = "BANKQUE"
    Public Const gc_PrintInfoHOLDAMT = "HOLDAMT"

    'ActionFlag
    Public Const gc_ActionDelete = "DELETE"
    Public Const gc_ActionInquiry = "INQUIRY"
    Public Const gc_ActionEdit = "EDIT"
    Public Const gc_ActionAdd = "ADD"
    Public Const gc_ActionAdhoc = "ADHOC"
    Public Const gc_ActionExec = "EXEC"
    'AnhVT Added - Maintenance Approval Retro
    Public Const gc_ActionApprove As String = "APPROVE"
    Public Const gc_ActionReject As String = "REJECT"
    Public Const gc_ActionBatch As String = "BATCH"

    'Send notification via
    Public Const gc_SEND_VIA_EMAIL As String = "E"
    Public Const gc_SEND_VIA_SMS As String = "S"

    'MessageType
    Public Const gc_MsgTypeObj = "O"
    Public Const gc_MsgTypeTrans = "T"
    Public Const gc_MsgTypeRpt = "R"
    Public Const gc_MsgTypeProc = "P"

    'MessageLocation
    Public Const gc_IsLocalMsg = "Y"
    Public Const gc_IsNotLocalMsg = "N"
    Public Const gc_TLTX_BDS = "Y"
    Public Const gc_TLTX_HOST = "N"

    'Command type
    Public Const gc_CommandText = "T"
    Public Const gc_CommandProcedure = "P"

    'OrderStatus
    Public Const gc_ORDER_OPEN = "1"
    Public Const gc_ORDER_SENT = "2"
    Public Const gc_ORDER_CANCEL = "3"
    Public Const gc_ORDER_EXECUTED = "4"
    Public Const gc_ORDER_EXPIRED = "5"
    Public Const gc_ORDER_REJECTED = "6"
    Public Const gc_ORDER_COMPLETED = "7"
    Public Const gc_ORDER_PENDING = "8"

    'CF Link type
    Public Const gc_LINKTYPE_AUTHORIZE = "003"
    Public Const gc_LINKTYPE_OWNER = "001"
    Public Const gc_LINKTYPE_MEMBER = "004"
    Public Const gc_LINKTYPE_REPRESENTATIVE = "002"

    'Háº±ng sá»‘ qui Ä‘á»‹nh sá»­ dá»¥ng AUTOID
    Public Const gc_AutoIdUsed = "Y"
    Public Const gc_AutoIdUnused = "N"

    'Háº±ng sá»‘ qui Ä‘á»‹nh Ä‘á»™ dÃ i cá»§a tÃ i khoáº£n GL
    Public Const gc_GLACCOUNT_LEN = 15
    Public Const gc_SECURITIES_ISOTC_TRADEPLACE = "003"

    Public Const gc_SECURITIES_SECTYPE_BOND = "003"
    Public Const gc_SECURITIES_SECTYPE_CONVERTIBLEBOND = "006"

    'Háº±ng sá»‘ qui Ä‘á»‹nh sá»­ dá»¥ng AUTOID
    Public Const gc_TRADEPLACE_HCMCSTC = "001"
    Public Const gc_TRADEPLACE_HNCSTC = "002"
    Public Const gc_TRADEPLACE_OTC = "003"
    Public Const gc_TRADEPLACE_GX = "004"
    Public Const gc_TRADEPLACE_UPCOM = "005"
    'Háº±ng sá»‘ v? loï¿½áº¡i lá»‡nh thá»±c hiá»‡n lá»‡nh
    Public Const gc_CA_CATYPE_TENDER = "001"
    Public Const gc_CA_CATYPE_HALT = "002"
    Public Const gc_CA_CATYPE_DELISTED = "003"
    Public Const gc_CA_CATYPE_BUY_BACK = "004"
    Public Const gc_CA_CATYPE_MEETING = "005"
    Public Const gc_CA_CATYPE_POLL = "006"
    Public Const gc_CA_CATYPE_SELLTREAS = "007"
    Public Const gc_CA_CATYPE_UPDATE_INFORMATION = "008"
    Public Const gc_CA_CATYPE_KIND_DIVIDEND = "009"
    Public Const gc_CA_CATYPE_CASH_DIVIDEND = "010"
    Public Const gc_CA_CATYPE_STOCK_DIVIDEND = "011"
    Public Const gc_CA_CATYPE_STOCK_SPLIT = "012"
    Public Const gc_CA_CATYPE_STOCK_MERGE = "013"
    Public Const gc_CA_CATYPE_STOCK_RIGHTOFF = "014"
    Public Const gc_CA_CATYPE_BOND_PAY_INTEREST = "015"
    Public Const gc_CA_CATYPE_BOND_PAY_INTEREST_PRINCIPAL = "016"
    Public Const gc_CA_CATYPE_CONVERT_BOND_TO_SHARE = "017"
    Public Const gc_CA_CATYPE_CONVERT_RIGHT_TO_SHARE = "018"
    Public Const gc_CA_CATYPE_CHANGE_TRADING_PLACE_STOCK = "019"
    Public Const gc_CA_CATYPE_CONVERT_STOCK = "020"
    Public Const gc_CA_CATYPE_KIND_STOCK = "021"
    Public Const gc_CA_CATYPE_KIND_OTHER_STOCK = "022"
    Public Const gc_CA_CATYPE_FASTENERS_LIST_SHAREHOLDER = "023"
    Public Const gc_CA_CATYPE_PAYING_INTERREST_BOND = "024"
    Public Const gc_CA_CATYPE_PRINCIPLE_BOND = "025"
    Public Const gc_CA_WAITING_FOR_TRADE = "026"

    Public Const gc_RM_TRANSTYPE_TRFODBUY = "TRFODBUY"
    Public Const gc_RM_TRANSTYPE_TRFODSELL = "TRFODSELL"
    Public Const gc_RM_TRANSTYPE_TRFODBFEE = "TRFODBFEE"
    Public Const gc_RM_TRANSTYPE_TRFODSFEE = "TRFODSFEE"
    Public Const gc_RM_TRANSTYPE_TRFODBRK = "TRFODBRK"
    Public Const gc_RM_TRANSTYPE_TRFODTAX = "TRFODTAX"
    Public Const gc_RM_TRANSTYPE_SEODDLOT = "SEODDLOT"
    Public Const gc_RM_TRANSTYPE_SEODDLOC = "SEODDLOC"
    Public Const gc_RM_TRANSTYPE_TRFCAREG = "TRFCAREG"
    Public Const gc_RM_TRANSTYPE_TRFCAUNREG = "TRFCAUNREG"
    Public Const gc_RM_TRANSTYPE_TRFCACASH = "TRFCACASH"
    Public Const gc_RM_TRANSTYPE_TRFSEFEE = "TRFSEFEE"
    Public Const gc_RM_TRANSTYPE_TRFADADV = "TRFADADV"
    Public Const gc_RM_TRANSTYPE_TRFADPAID = "TRFADPAID"
    Public Const gc_RM_TRANSTYPE_TRFDFDRAWN = "TRFDFDRAWN"
    Public Const gc_RM_TRANSTYPE_TRFDFINT = "TRFDFINT"
    Public Const gc_RM_TRANSTYPE_TRFDFPRIN = "TRFDFPRIN"
    Public Const gc_RM_TRANSTYPE_TRFCATAX = "TRFCATAX"

    Public Const gc_CA_APPROVE_CA = "3374"
    Public Const gc_CA_RERECT_CA = "3372"
    Public Const gc_CA_REFUSE_CA = "3373"

    'Háº±ng sá»‘ mÃ£ giao dá»‹ch dá»‹ch
    Public Const gc_CF_REMAP_TOKEN = "0033"
    Public Const gc_CF_UNLOCK_TOKEN = "0034"
    Public Const gc_CF_CHKTLID = "0050" ' Dien comment 18/10/2010

    Public Const gc_CF_REFUSEPROFILE = "0068"
    Public Const gc_CF_REJECTPROFILE = "0069"

    Public Const gc_CF_OPENCONTRACT = "0070"
    Public Const gc_CF_CONTRACTINQUIRY = "0071"
    Public Const gc_CF_CONTRACTHISTORY = "0072"

    Public Const gc_CF_CHKLIMIT = "0074"
    Public Const gc_CF_CLOSECONTRACT = "0075"

    Public Const gc_CF_APPROVEPROFILE = "0076"

    Public Const gc_CF_CHANGE_OTC = "0078"
    Public Const gc_CF_ISSUE_CUSTODYCD = "0079"

    Public Const gc_CF_APPROVECONTRACT = "0080"
    Public Const gc_CF_REFUSECONTRACT = "0084"
    Public Const gc_CF_ACTIVECONTRACT = "0086"
    Public Const gc_CF_REJECTCONTRACT = "0087"
    Public Const gc_CF_CHANGE_AFTYPE = "0051"
    Public Const gc_CF_CLOSE_CUSTODYCD = "0059"
    Public Const gc_CF_CHANGE_AFTYPE_TO_COREBANK = "0064"
    Public Const gc_CF_REQUEST_CHANGE_AFTYPE_TO_COREBANK = "0063"
    Public Const gc_CF_CHANGE_AFTYPE_TO_COREBANK_TEMPORARY = "0099"

    Public Const gc_CF_CONFIRMCONTRACTTYPE = "0001"
    Public Const gc_CF_CHANGE_SYSTEM_BOUNDARY = "0002"
    Public Const gc_CF_CUSTOMIZE_ICCF = "0008"
    Public Const gc_CF_CHANGE_CUSTOMIZE_AMPLITUDE = "0003"
    Public Const gc_CF_MAP_BANKACCT = "0006"
    Public Const gc_CF_REMOVE_MAP_BANKACCT = "0007"
    Public Const gc_CF_CHANGE_IDCODE = "0082"
    Public Const gc_CF_CHANGE_AUTHORIZE = "0055"
    Public Const gc_CF_INSERT_AUTHORIZE = "0056"
    Public Const gc_CF_DELETE_AUTHORIZE = "0057"
    Public Const gc_CF_ACTIVE_CUSTODYCODE = "0067"
    Public Const gc_CF_USERLOGIN = "0090"
    Public Const gc_CF_USERLIMIT = "0098"
    Public Const gc_CF_T0USERLIMIT = "0015"
    Public Const gc_CF_USERAFLIMIT = "0099"
    Public Const gc_CF_RESET_TRADING_PASSWORD = "0089"
    Public Const gc_CF_CHANGE_TRADING_PASSWORD = "0079"
    Public Const gc_PR_CHK_PRCODE = "0100"
    Public Const gc_PR_CHK_PRAMT = "0101"

    Public Const gc_CF_RETRIEVE_MARGIN_LIMIT = "1814"
    Public Const gc_CF_ALLOCATE_MARGIN_LIMIT = "1813"

    Public Const gc_CF_CUSTINFO_INQ = "0020"
    Public Const gc_CI_DEPOSIT_CB = "1131"
    Public Const gc_CI_CASHDEPOSIT = "1140"
    Public Const gc_CI_GL_TRF_CI = "1141"
    Public Const gc_CI_RCV_BRROWED = "1142"
    Public Const gc_CI_OD_ADVANCED = "1143"
    Public Const gc_CI_BLOCK_AMOUNT = "1144"
    Public Const gc_CI_UNBLOCK_AMOUNT = "1145"
    Public Const gc_CI_DEALING_GL_TRF_CI = "1146"
    Public Const gc_CI_TRF_GLTOCI = "1147"
    Public Const gc_CI_TRF_OTC = "1148"
    Public Const gc_CI_DEVIDION_ALLOCATION = "1149"
    Public Const gc_CI_INT_TO_PRINCIPLE = "1150"
    Public Const gc_CI_TRANSFER2BANK = "1101"
    Public Const gc_CI_INTERNALTRANSFER = "1120"
    Public Const gc_CI_CASH_WITHDRAWN = "1100"
    Public Const gc_CI_TRANSFER2BANK_BY_RTT = "1108"
    Public Const gc_CI_TELE_TRANSFER2BANK = "1111"
    Public Const gc_CI_ONLINE_ASYN_TRANSFER_INTERNAL = "1118"
    Public Const gc_CI_ONLINE_ASYN_TRANSFER_2BANK = "1119"
    Public Const gc_CI_PAIDADVANCEDPAYMENT = "1103"
    Public Const gc_CI_ORDERADVANCEDPAYMENT = "1143"
    Public Const gc_CI_DAY_ORDERADVANCEDPAYMENT = "1153"
    Public Const gc_CI_COMPLETETRANSFER2BANK = "1104"
    Public Const gc_CI_REJECTTRANSFER2BANK = "1114"
    Public Const gc_CI_PAY_BORROW_MONEY = "1109"
    Public Const gc_CI_CRINTACR = "1160"
    Public Const gc_CI_ODINTACR = "1161"
    Public Const gc_CI_CRINTPRINCIPAL = "1162"
    Public Const gc_CI_ODINTPRINCIPAL = "1163"
    Public Const gc_CI_OPENACCOUNT = "1170"
    Public Const gc_CI_ACCOUNTINQUIRY = "1171"
    Public Const gc_CI_ACCOUNTHISTORY = "1172"
    Public Const gc_CI_GETINTTRANS = "1175"
    Public Const gc_CI_AVERAGE_BALANCE = "1177"
    Public Const gc_CI_ContractCloseRequest = "0088"
    Public Const gc_CI_MORTAGE_BLOCK = "1169"
    Public Const gc_CI_OTC_CASH_INQ = "1176"
    Public Const gc_CI_OVERDRAF_AMOUNT = "1165"
    Public Const gc_CI_COLLECT_FEEDEPOSIT_MATURITY = "1180"
    Public Const gc_CI_FEEDEPOSIT_MATURITY = "1181"
    Public Const gc_CI_FEEDEPOSIT_SEND2BANK = "1183"
    Public Const gc_CI_FEEDEPOSIT_BANKREJECT = "1184"
    Public Const gc_CI_FEEDEPOSIT_BANKCONFIRM = "1185"
    Public Const gc_CI_RESET_OTHERACCOUNT = "1187"
    Public Const gc_CI_DEPOSIT_OTHERACCOUNT = "1186"
    Public Const gc_CI_CASHDEPOSIT_FIX_MISTAKE = "1198"
    Public Const gc_BO_COMPLETE_BOND_BIDDING_BW = "1196"
    Public Const gc_BO_COMPLETE_BOND_BIDDING_NBW = "1197"
    Public Const gc_SE_OPENACCOUNT = "2270"
    Public Const gc_SE_ACCOUNTINQUIRY = "2271"
    Public Const gc_SE_ACCOUNTHISTORY = "2272"
    Public Const gc_SE_COSTPRICE_HISTORY = "2282"
    Public Const gc_SE_APPROVE_CAEVENT = "2275"
    Public Const gc_SE_REJECT_CAEVENT = "2276"
    Public Const gc_SE_SEND_CAEVENT = "2277"
    Public Const gc_SE_ADJUST_AFMAST_CAEVENT = "2278"
    Public Const gc_SE_EXECUTE_AFMAST_CAEVENT = "2279"
    Public Const gc_SE_AUTOEXECUTE_AFMAST_CAEVENT = "2269"
    Public Const gc_SE_WITHDRAW = "2200"
    Public Const gc_SE_SURELY_WITHDRAW = "2201"
    Public Const gc_SE_BLOCK = "2202"
    Public Const gc_SE_UNBLOCK = "2203"
    Public Const gc_SE_REVERT_DEPOSIT = "2230"
    Public Const gc_SE_REVERT_SEND_DEPOSIT = "2231"
    Public Const gc_SE_DEPOSIT = "2240"
    Public Const gc_SE_SEND_DEPOSIT = "2241"
    Public Const gc_SE_COMPLETE_DEPOSIT = "2246"
    Public Const gc_SE_ADJUST_COSTPRICE = "2222"
    Public Const gc_SE_RESEVERSE_MORTAGE_RELEASE = "2251"
    Public Const gc_SE_MORTAGE_RELEASE = "2252"
    Public Const gc_SE_MORTAGE_RELEASE_TOSELL = "2253"
    Public Const gc_SE_TRF_SE2SE = "2242"
    Public Const gc_SE_INWARD_SETRF = "2245"
    Public Const gc_SE_SEND_DTOCLOSE = "2247"
    Public Const gc_SE_COMPLATE_SDTOCLOSE = "2248"
    Public Const gc_SE_CONFIRM_WITHDRAW = "2292"
    Public Const gc_SE_REVERT_WITHDRAW = "2293"
    Public Const gc_SE_REVERT_2292 = "2294"
    Public Const gc_SE_CONFIRM_SENT_REVERSEMORTAGE = "2295"
    Public Const gc_SE_CONFIRM_SENT_RELEASEEMORTAGE = "2296"
    Public Const gc_SE_RESET_OTHERACCOUNT = "2287"
    Public Const gc_SE_DEPOSIT_OTHERACCOUNT = "2286"

    Public Const gc_SE_SEND_RETAIL = "8815"
    Public Const gc_SE_CANCEL_SEND_RETAIL = "8816"
    Public Const gc_SE_CANCEL_RETAIL = "8817"
    Public Const gc_SE_COMPLETE_TOCLOSE = "2249"
    Public Const gc_SE_OTCPRIVATE_TRANSFER = "2288"
    Public Const gc_CA_APPROVE_CAEVENT = "3375"
    Public Const gc_CA_REJECT_CAEVENT = "3376"
    Public Const gc_CA_SEND_CAEVENT = "3377"
    Public Const gc_CA_ADJUST_AFMAST_CAEVENT = "3378"
    Public Const gc_CA_EXECUTE_AFMAST_CAEVENT = "3379"
    Public Const gc_CA_EXECUTE_CI_CAEVENT = "3350"
    Public Const gc_CA_EXECUTE_CI_CAEVENT_NOTTAX = "3352"
    Public Const gc_CA_EXECUTE_CI_CAEVENT_PIT_AT_ISSUER = "3354"
    Public Const gc_CA_EXECUTE_SE_CAEVENT = "3351"
    Public Const gc_CA_SEND_AFMAST_CAEVENT = "3380"
    Public Const gc_CA_AUTO_EXECUTE_AFMAST_CAEVENT = "3360"
    Public Const gc_CA_AUTO_SEND_AFMAST_CAEVENT = "3361"
    Public Const gc_CA_AUTO_EXECUTE_CHANGE_TRADING_CAEVENT = "3363"
    Public Const gc_CA_AUTO_SEND_CHANGE_TRADING_CAEVENT = "3362"
    Public Const gc_CA_AUTO_EXE_BOND_TO_SHARE = "3364"
    Public Const gc_CA_AUTO_SEND_CAEVENT = "3367"
    Public Const gc_CA_AUTO_EXECUTE_CAEVENT = "3368"
    Public Const gc_CA_TRADE_RETAIL = "3381"
    Public Const gc_CA_TRANSFER = "3382"
    Public Const gc_CA_OUTWARD_TRANSFER = "3383"
    Public Const gc_CA_INWARD_TRANSFER = "3385"
    Public Const gc_CA_STOCK_RIGHTOFF = "3384"
    Public Const gc_CA_CANCEL_STOCK_RIGHTOFF = "3386"
    Public Const gc_CA_CUT_STOCK_EXCUTE = "3387"
    Public Const gc_CA_TELE_STOCK_RIGHTOFF = "3394"
    Public Const gc_CA_BEFORE_EXECUTE = "3390"
    Public Const gc_CA_COMPLETE = "3388"
    Public Const gc_CA_STOCK_RIGHTOFF_NOT_BLOCK_MONEY = "3391"
    Public Const gc_CA_CANCEL_STOCK_RIGHTOFF_NO_MONEY = "3393"

    Public Const gc_FO_CREATEORDER = "8070"
    Public Const gc_FO_ORDERINQUIRY = "8071"
    Public Const gc_FO_ORDERHISTORY = "8072"

    Public Const Thuat = "TEST"


    Public Const gc_OD_PLACEORDER = "8870"
    Public Const gc_OD_PLACENORMALBUYORDER = "8874"
    Public Const gc_OD_PLACENORMALSELLORDER = "8875"
    Public Const gc_OD_PLACENORMALBUYORDER_ADVANCED = "8876"
    Public Const gc_OD_PLACENORMALSELLORDER_ADVANCED = "8877"
    Public Const gc_OD_TRADE_LOT_RETAIL = "8878"
    Public Const gc_OD_MATCH_TRADE_LOT_RETAIL = "8879"
    Public Const gc_OD_SENDORDER2STC = "8880"


    Public Const gc_OD_PLACEORDER_BUY_TODAY_PRICE = "8830"
    Public Const gc_OD_PLACEORDER_BUY_TODAY_ATO = "8831"
    Public Const gc_OD_PLACEORDER_BUY_GOOD_TILL_CANCEL_PRICE = "8832"
    Public Const gc_OD_PLACEORDER_BUY_GOOD_TILL_CANCEL_ATO = "8833"
    Public Const gc_OD_PLACEORDER_BUY_STOP_TODAY_PRICE = "8834"
    Public Const gc_OD_PLACEORDER_BUY_STOP_TODAY_ATO = "8835"
    Public Const gc_OD_PLACEORDER_BUY_STOP_GOOD_TILL_CANCEL_PRICE = "8836"
    Public Const gc_OD_PLACEORDER_BUY_STOP_GOOD_TILL_CANCEL_ATO = "8837"

    'Public Const gc_OD_PLACEORDER_SALE_TODAY_PRICE = "8840"
    'Public Const gc_OD_PLACEORDER_SALE_TODAY_ATO = "8841"
    'Public Const gc_OD_PLACEORDER_SALE_GOOD_TILL_CANCEL_PRICE = "8842"
    'Public Const gc_OD_PLACEORDER_SALE_GOOD_TILL_CANCEL_ATO = "8843"
    'Public Const gc_OD_PLACEORDER_SALE_STOP_TODAY_PRICE = "8844"
    'Public Const gc_OD_PLACEORDER_SALE_STOP_TODAY_ATO = "8845"
    Public Const gc_OD_PLACEORDER_SALE_STOP_GOOD_TILL_CANCEL_PRICE = "8846"
    Public Const gc_OD_PLACEORDER_SALE_STOP_GOOD_TILL_CANCEL_ATO = "8847"

    Public Const gc_OD_PLACEORDER_SHORTSALE_TODAY_PRICE = "8850"
    Public Const gc_OD_PLACEORDER_SHORTSALE_TODAY_ATO = "8851"
    Public Const gc_OD_PLACEORDER_SHORTSALE_GOOD_TILL_CANCEL_PRICE = "8852"
    Public Const gc_OD_PLACEORDER_SHORTSALE_GOOD_TILL_CANCEL_ATO = "8853"
    Public Const gc_OD_PLACEORDER_SHORTSALE_STOP_TODAY_PRICE = "8854"
    Public Const gc_OD_PLACEORDER_SHORTSALE_STOP_TODAY_ATO = "8855"
    Public Const gc_OD_PLACEORDER_SHORTSALE_STOP_GOOD_TILL_CANCEL_PRICE = "8856"
    Public Const gc_OD_PLACEORDER_SHORTSALE_STOP_GOOD_TILL_CANCEL_ATO = "8857"

    Public Const gc_OD_PLACEORDER_BUYTOCOVER_TODAY_PRICE = "8860"
    Public Const gc_OD_PLACEORDER_BUYTOCOVER_TODAY_ATO = "8861"
    Public Const gc_OD_PLACEORDER_BUYTOCOVER_GOOD_TILL_CANCEL_PRICE = "8862"
    Public Const gc_OD_PLACEORDER_BUYTOCOVER_GOOD_TILL_CANCEL_ATO = "8863"
    Public Const gc_OD_PLACEORDER_BUYTOCOVER_STOP_TODAY_PRICE = "8864"
    Public Const gc_OD_PLACEORDER_BUYTOCOVER_STOP_TODAY_ATO = "8865"
    Public Const gc_OD_PLACEORDER_BUYTOCOVER_STOP_GOOD_TILL_CANCEL_PRICE = "8866"
    Public Const gc_OD_PLACEORDER_BUYTOCOVER_STOP_GOOD_TILL_CANCEL_ATO = "8867"

    Public Const gc_OD_ORDERINQUIRY = "8871"
    Public Const gc_OD_ORDERHISTORY = "8872"
    Public Const gc_OD_CLEARINGINQUIRY = "8873"
    Public Const gc_OD_SENDBUYORDER = "8800"
    Public Const gc_OD_SENDSELLORDER = "8801"
    Public Const gc_OD_CANCELBUYORDER = "8882" '"8802"
    Public Const gc_OD_CANCELSELLORDER = "8883" '"8803"
    Public Const gc_OD_APPROVE_EDITBUYORDER = "8890" '"8802"
    Public Const gc_OD_APPROVE_EDITSELLORDER = "8891" '"8803"
    Public Const gc_OD_IBT_SETTLEMENT = "8899"
    Public Const gc_OD_REFUSE_AMEND_ORDER = "8892"

    Public Const gc_OD_MOVE_BUY_DEAL = "8895"
    Public Const gc_OD_MOVE_SELL_DEAL = "8896"

    Public Const gc_OD_CORRECT_BUY_ORDER = "8897"
    Public Const gc_OD_CORRECT_SELL_ORDER = "8898"

    'Public Const gc_OD_CANCELBUYORDERSENDING = "8884"
    'Public Const gc_OD_CANCELSELLORDERSENDING = "8885"
    Public Const gc_OD_AMENDMENTBUYORDER = "8884"
    Public Const gc_OD_AMENDMENTSELLORDER = "8885"

    Public Const gc_OD_AMENDMENTELECTRICORDER = "8886"


    Public Const gc_OD_CLEARBUYORDER = "8808"
    Public Const gc_OD_CLEARSELLORDER = "8807"
    Public Const gc_OD_CLEARBUYSENDINGORDER = "8811"
    Public Const gc_OD_CLEARSELLSENDINGORDER = "8810"
    Public Const gc_OD_CISEND = "8821"
    Public Const gc_OD_CIRECEIVE = "8822"
    Public Const gc_OD_SESEND = "8823"
    Public Const gc_OD_SERECEIVE = "8824"
    Public Const gc_OD_SERECEIVE_T1T2 = "8828"
    Public Const gc_OD_OTC_BUY_SETTLEMENT = "8825"
    Public Const gc_OD_OTC_SELL_SETTLEMENT = "8826"
    Public Const gc_OD_BATCH_CISEND_FEE = "8855"
    Public Const gc_OD_BATCH_CIRECEIVE_FEE = "8856"
    Public Const gc_OD_RESEND_ORDER = "8859"
    Public Const gc_OD_BATCH_CISEND = "8865"
    Public Const gc_OD_BATCH_SUNRELY_CISEND = "8827"
    Public Const gc_OD_BATCH_CIRECEIVE = "8866"
    Public Const gc_OD_BATCH_SESEND = "8867"
    Public Const gc_OD_BATCH_SERECEIVE = "8868"
    Public Const gc_OD_BATCH_RLS_ADVANCED = "8861"
    Public Const gc_OD_BATCH_RLS_DAY_ADVANCED = "8851"
    Public Const gc_OD_MATCHORDER = "8804"
    Public Const gc_OD_ALLOCATE_TRADING = "8812"
    Public Const gc_OD_HASTC_ALLOCATE_TRADING = "8813"
    Public Const gc_OD_MANUAL_MATCHORDER = "8809"
    Public Const gc_OD_RELEASEBUYORDER = "8862"
    Public Const gc_OD_RELEASESELLORDER = "8863"
    Public Const gc_OD_FINISHORDER = "8864"
    Public Const gc_OD_BATCH_DEPOSIT = "8869"
    Public Const gc_OD_REFUSE_SENDING_ATO_BUY_ORDER = "8858"
    Public Const gc_OD_OTC_ALLOCATETRADE = "8830"
    Public Const gc_OD_OTC_TRANSFER = "8831"
    Public Const gc_OD_OTC_RECEIVE = "8832"

    Public Const gc_RP_REPO_OPENACCOUNT = "7700"
    Public Const gc_RP_REREPO_OPENACCOUNT = "7701"
    'Public Const gc_RP_SWAP_OPENACCOUNT = "7702"
    Public Const gc_RP_FORWARD_OPENACCOUNT = "7702"
    Public Const gc_RP_ACCOUNTINQUIRY = "7771"
    Public Const gc_RP_ACCOUNTHISTORY = "7772"

    Public Const gc_RM_COMPLETE_HOLD = "6660"
    Public Const gc_RM_COMPLETE_UNHOLD = "6661"
    Public Const gc_RM_HOLD = "6640"
    Public Const gc_RM_TRANSFER = "6641"
    Public Const gc_RM_TRANSFER_OTHER = "6642"
    Public Const gc_RM_TRANSFER_OTHER_2 = "6644"
    Public Const gc_RM_TRANSFER_2 = "6643"
    Public Const gc_RM_RCV_HOLD = "6660"
    Public Const gc_RM_UNHOLD = "6600"
    Public Const gc_RM_RCV_UNHOLD = "6661"
    Public Const gc_RM_RCV_TRANSFER = "6662"
    Public Const gc_RM_INQUIRY = "6671"
    Public Const gc_RM_INQUIRYAUTO = "6631"
    Public Const gc_RM_HISTORY = "6672"
    Public Const gc_RM_CHANGE_BANK_STATUS = "6680"
    'Dung hold va Unhold direct
    Public Const gc_RM_HOLD_DIRECT = "6690"
    Public Const gc_RM_UNHOLD_DIRECT = "6691"
    'End
    Public Const gc_RM_CHANGECRBTRFLOGSTATUS = "6611"


    Public Const gc_RM_REVERT_HOLD = "6620"
    Public Const gc_RM_REVERT_UNHOLD = "6621"

    Public Const gc_RM_REVERT_TRANSFER = "6622"

    Public Const gc_RM_BUY_AMOUNT_TRANSFER = "6663"
    Public Const gc_RM_BUY_FEE_TRANSFER = "6664"
    Public Const gc_RM_SALE_AMOUNT_TRANSFER = "6665"
    Public Const gc_RM_SALE_FEE_TRANSFER = "6666"

    Public Const gc_RM_RLS_OVRF_BUY_AMOUNT_TRANSFER = "6667"
    Public Const gc_RM_RLS_OVRF_BUY_FEE_TRANSFER = "6668"
    Public Const gc_RM_RLS_OVERDRAF_AMOUNT_TRANSFER = "6681"
    Public Const gc_RM_RLS_DUTY_AMOUNT_TRANSFER = "6682"

    Public Const gc_RM_PROCESS_COLLECT_DEPOFEE = "6613"


    Public Const gc_GL_NORMAL = "9900"
    Public Const gc_GL_CASHTRF = "9901"
    Public Const gc_GL_REVERSE9900 = "9902"
    Public Const gc_GL_CAST_IN = "9904"
    Public Const gc_GL_CAST_OUT = "9905"
    Public Const gc_GL_OPENACCOUNT = "9970"
    Public Const gc_GL_ACCOUNTINQUIRY = "9971"
    Public Const gc_GL_ACCOUNTHISTORY = "9972"
    Public Const gc_GL_ADJUSTMITRAN = "9973"

    Public Const gc_LM_ACCOUNTINQUIRY = "5171"
    Public Const gc_LM_ACCOUNTHISTORY = "5172"
    Public Const gc_LM_LNAPPL_GRANTLIMIT = "5106"
    Public Const gc_LM_LNAPPL_WITHDRAWLIMIT = "5109"
    Public Const gc_LM_SDMAST_GRANTLIMIT = "5116"
    Public Const gc_LM_SDMAST_WITHDRAWLIMIT = "5119"
    Public Const gc_LM_GRMAST_GRANTLIMIT = "5117"
    Public Const gc_LM_GRMAST_WITHDRAWLIMIT = "5118"
    Public Const gc_LM_LMMAST_RELEASELIMIT = "5105"
    Public Const gc_LM_LMMAST_UNBLOCK = "5108"
    Public Const gc_LM_LMMAST_REJECT = "5102"
    Public Const gc_LM_LMMAST_CLOSE = "5104"

    Public Const gc_CL_ACCOUNTINQUIRY = "5271"
    Public Const gc_CL_ACCOUNTHISTORY = "5272"
    Public Const gc_CL_MORTGAGE = "5240"
    Public Const gc_CL_UNMORTGAGE = "5200"
    Public Const gc_CL_VALUEASSET = "5215"
    Public Const gc_CL_ADJUST_VALUEUSING = "5214"
    Public Const gc_CL_ADJUST_SECUREDRATIO = "5213"

    Public Const gc_GR_ACCOUNTINQUIRY = "5071"
    Public Const gc_GR_ACCOUNTHISTORY = "5072"

    Public Const gc_LN_OVERDUEDATE = "5573"
    Public Const gc_LN_ACCOUNTINQUIRY = "5571"
    Public Const gc_LN_ACCOUNTHISTORY = "5572"
    Public Const gc_LN_APPLINQUIRY = "5581"
    Public Const gc_LN_APPLAPPROVE = "5583"
    Public Const gc_LN_APPLREJECT = "5584"
    Public Const gc_LN_INTDUESCHD = "5532"
    Public Const gc_LN_INTOVDSCHD = "5533"
    Public Const gc_LN_APPLCLOSE = "5585"
    Public Const gc_LN_BACKTO_INTDUESCHD = "5534"
    Public Const gc_LN_PRINOVDSCHD = "5523"
    Public Const gc_LN_BACKTO_PRINNMLSCHD = "5524"
    Public Const gc_LN_PAYMENT_ALLOCATE = "5540"
    Public Const gc_LN_PAYMENT_ALLOCATE_BY_CASH = "5541"
    Public Const gc_LN_PAYMENT_ALLOCATE_BY_GROUPACCOUNT = "5542"
    Public Const gc_GR_INTACR = "5060"
    Public Const gc_LN_DRAWNDOWN = "5500"
    Public Const gc_LN_DRAWNDOWN_BY_CASH = "5501"
    Public Const gc_LN_LNMASTAPPROVE = "5578"
    Public Const gc_LN_LNMASTREJECT = "5579"
    Public Const gc_LN_BATCH_INTNMLACR = "5560"
    Public Const gc_LN_BATCH_INTOVDACR = "5561"
    Public Const gc_LN_BATCH_INTDUE = "5562"
    Public Const gc_LN_BATCH_INTPREPAID = "5563"
    Public Const gc_LN_BATCH_PRINOVDSCHD = "5564"
    Public Const gc_LN_BATCH_INTOVDSCHD = "5565"
    Public Const gc_LN_BATCH_AUTO_DRAWNDOWN = "5566"
    Public Const gc_LN_BATCH_AUTO_PAYMENT_ALLOCATE = "5567"
    Public Const gc_LN_LNMASTCLOSE = "5576"
    Public Const gc_LN_TRANSFER_LIMIT = "5510"

    '--Phan he Margin
    Public Const gc_MR_ALLOCATE_CUSTOMER_MARGIN_LIMIT = "1802"
    Public Const gc_MR_ALLOCATE_GUARATEE_T0 = "1810"
    Public Const gc_MR_RELEASE_GUARATEE_T0 = "1811"
    Public Const gc_MR_ADJUST_MARGIN_RATE = "1820"
    Public Const gc_MR_ADJUST_SECURITIES_MARGIN_INFO = "1821"
    Public Const gc_MR_ADJUST_AFTYPE_MARGIN_INFO = "1822"
    Public Const gc_MR_ADD_SECBASKET_TOACTYPE = "1830"
    Public Const gc_MR_ADD_MEMBER_TO_GROUP = "1850"
    Public Const gc_MR_REMOVE_MEMBER_FROM_GROUP = "1851"

    '--Phan he Mortgage/Forrward
    Public Const gc_DF_ADD_BASKET_TO_DFTYPE = "2630"
    Public Const gc_DF_ADD_BASKET_TO_ML_AFTYPE = "2631"
    Public Const gc_DF_RELEASE_DEAL_QTTY = "2632"
    Public Const gc_DF_OPEN_DF_CONTRACT_FOR_GRP_RS = "2653"
    Public Const gc_DF_OPEN_DF_CONTRACT = "2670"
    Public Const gc_DF_REQUEST_OPEN_DF_CONTRACT = "2673"
    Public Const gc_DF_REJECT_OPEN_DF_CONTRACT = "2674"
    Public Const gc_DF_APPROVE_OPEN_DF_CONTRACT = "2675"

    Public Const gc_DF_PAYMENT_ALLOCATE = "2641"
    Public Const gc_DF_DEAL_PAYMENT_ALLOCATE = "2642"
    Public Const gc_DF_DEAL_RELEASE_SECU = "2647"
    Public Const gc_DF_DEAL_SENDVSD = "2681"
    Public Const gc_DF_DEAL_DRAWNDOWN = "2678"
    Public Const gc_DF_DEAL_REFUSE = "2682"
    Public Const gc_DF_LIQUID_RECREATE = "2685" 'Giao dich thanh ly tai ky.
    Public Const gc_DF_CREATE_OPTION_DEAL = "2686"  'Giao dich tao deal vay quyen mua
    Public Const gc_DF_MARGIN_TYPE = "L"

    Public Const gc_CI_PAYMENT_ORDER_LIST = "1104/1108/3387/3366/2248/3331/8879"
    Public Const gc_CI_MANUAL_ADVANCE = "1153/1178"
    Public Const gc_CA_POTYPE = "002"

    '--Phan he TermDeposit
    Public Const gc_TD_OPENACCOUNT = "1670"
    Public Const gc_TD_WITHDRAW = "1600"
    Public Const gc_TD_WITHDRAW_FLEX = "1620"
    Public Const gc_TD_RENEW = "1630"
    Public Const gc_TD_ACCOUNTINQUIRY = "1671"
    Public Const gc_TD_ACCOUNTHISTORY = "1672"
    Public Const gc_TD_MORTGAGE = "1677"
    Public Const gc_TD_UNMORTGAGE = "1678"

    '--Phan he Remiser
    Public Const ERR_SA_PRODUCT_INVALID_BRANCH = ERR_SA_START - 991
    Public Const ERR_SA_PRODUCT_INVALID_SUB_BRANCH = ERR_SA_START - 992
    Public Const ERR_SA_PRODUCT_INVALID_AFTYPE = ERR_SA_START - 993
    Public Const ERR_SA_PRODUCT_INVALID_USER = ERR_SA_START - 994
    Public Const ERR_SA_TLTX_TL_GRP_INVALID_BRANCH = ERR_SA_START - 995
    Public Const ERR_SA_TLTX_TL_GRP_DUPLICATE_BRANCH = ERR_SA_START - 996

    Public Const gc_RE_ACCOUNTINQUIRY = "0371"
    Public Const gc_RE_ACCOUNTHISTORY = "0372"
    Public Const gc_RE_ASSIGN_AFACCTNO2REMISER = "0380"
    Public Const gc_RE_MOVE_AFACCTNO_BETWEEN_REMISERS = "0381"
    Public Const gc_RE_ASSIGN_REMISER2GROUP = "0382"
    Public Const gc_RE_MOVE_REMISER_BETWEEN_GROUPS = "0383"
    Public Const gc_RE_REMOVE_AFACCTNO_FROM_REMISER = "0384"
    Public Const gc_RE_REMOVE_REMISER_FROM_GROUP = "0385"
    Public Const gc_RE_CLOSE_REMISER = "0390"


    Public Const ERR_RE_START = ERR_SYSTEM_OK - 560000

    Public Const ERR_DUPLICATE_REMISER = ERR_RE_START - 1001
    Public Const ERR_REMISER_HAS_ACCOUNT = ERR_RE_START - 1002
    Public Const ERR_REMISER_NOT_FOUND = ERR_RE_START - 1003
    Public Const ERR_DUPLICATE_REMISER_RETYPE = ERR_RE_START - 1004
    Public Const ERR_REMISER_RETYPE_HAS_ACCOUNT = ERR_RE_START - 1005
    Public Const ERR_REMISER_AFTYPE_ISINVALID = ERR_RE_START - 1006
    Public Const ERR_REMISER_ACCOUNT_INVALID_ACTYPE = ERR_RE_START - 1007
    Public Const ERR_REMISER_RETYPE_ISINVALID = ERR_RE_START - 1008
    Public Const ERR_ROOT_CANNOT_HAS_PARENT = ERR_RE_START - 1009
    Public Const ERR_SAME_GROUPID_AND_PARENTID = ERR_RE_START - 1010
    Public Const ERR_PARENTID_ISEMPTY = ERR_RE_START - 1011
    Public Const ERR_REAFLNK_DUPLICATE_RETYPE = ERR_RE_START - 1012
    Public Const ERR_REAFLNK_DUPLICATE_REMISER_REROLE = ERR_RE_START - 1013
    Public Const ERR_REAFLNK_REMISER_BELONG2ONCEGROUP = ERR_RE_START - 1014
    Public Const ERR_RE_REFEE_DUPLICATE = ERR_RE_START - 1015
    Public Const ERR_RE_RERFTYPE_DUPLICATE = ERR_RE_START - 1016
    Public Const ERR_REAFLNK_INVALID_CURR_RETYPE = ERR_RE_START - 1017
    Public Const ERR_REAFLNK_INVALID_FUTURE_RETYPE = ERR_RE_START - 1018
    Public Const ERR_RE_RETYPE_INUSED = ERR_RE_START - 1019
    Public Const ERR_REAFLNK_DUPLICATE_ROLE_DG = ERR_RE_START - 1020
    Public Const ERR_RE_GROUP_HAS_REMISER = ERR_RE_START - 1021
    Public Const ERR_RE_LEADER_HAS_COMMISION = ERR_RE_START - 1022
    Public Const ERR_RE_CUSTOMER_HAS_ONE_REMISER = ERR_RE_START - 1023
    Public Const ERR_RE_RECFDEF_DUPLICATE_EFFORD = ERR_RE_START - 1024
    Public Const ERR_RE_REFEE_DUPLICATE_PROPERTY = ERR_RE_START - 1025
    Public Const ERR_REMISERS_MUST_SAME_ROLE = ERR_RE_START - 1026
    Public Const ERR_INVALID_GROUP_RATE = ERR_RE_START - 1027
    Public Const ERR_REAFLNK_INVALID_TRANSFER_BETWEEN_2DG = ERR_RE_START - 1030
    Public Const ERR_RE_RETYPESALARY_RETYPESALARY_USED = ERR_RE_START - 1033

    'Phan he FN (28xx)
    Public Const gc_FN_SUB_ACCOUNT_LENGTH As Integer = 6
    Public Const gc_FN_PREFIX_TRANS As String = "28"
    Public Const gc_FN_OPEN_ACCOUNT As String = gc_FN_PREFIX_TRANS & "70"
    Public Const gc_FN_INQUERY_ACCOUNT As String = gc_FN_PREFIX_TRANS & "71"
    Public Const gc_FN_INQUERY_HISTORY As String = gc_FN_PREFIX_TRANS & "72"
    Public Const gc_FN_REGISTER_SECURITIES As String = gc_FN_PREFIX_TRANS & "85"
    Public Const gc_FN_UNREGISTER_SECURITIES As String = gc_FN_PREFIX_TRANS & "84"

    '</ Margin 74
    Public Const gc_LN_MARGIN_OVERDUEDATE = "5574"

    Public Const ERR_PRMASTER_DOUBLE_CODEID_ACTYPE = ERR_SA_START - 547

    Public Const ERR_CF_MARGIN_NOT_ALLOW = ERR_CF_START - 193 'Phuc add 09-2011
    Public Const ERR_CF_MARGIN_ACC_EXIST = ERR_CF_START - 194
    Public Const ERR_CF_NORMAL_ACC_NOT_EXIST = ERR_CF_START - 195
    Public Const ERR_CF_CAN_NOT_CHANGE_TO_SAME_ACTYPE = ERR_CF_START - 196
    Public Const ERR_AF_CHECK_CHKSYSCTRL = ERR_CF_START - 197
    Public Const ERR_AF_CAN_NOT_CREATE_MARGIN_ACCOUNT = ERR_CF_START - 198
    Public Const ERR_AF_CAN_NOT_EXTEND_MARGIN_DEAL = ERR_CF_START - 199

    Public Const ERR_LN_PRINFRQ_OVER_LIMIT = ERR_LN_START - 215
    Public Const ERR_LN_EXTEND_OVER_MAXDEBTDAYS = ERR_LN_START - 217
    Public Const ERR_LN_EXTEND_OVER_MAXTOTALDEBTDAYS = ERR_LN_START - 218
    Public Const ERR_LN_EXTENDDATE_SMALLER_THAN_OVDDATE = ERR_LN_START - 219
    Public Const ERR_LN_RRTYPE_B_CUSTBANK_MANDATORY = ERR_LN_START - 220

    Public Const ERR_MR_CAN_NOT_DO_FOR_MARGIN_ACCOUNT = ERR_MR_START - 39
    '/>

    Public Const Signature_PublicKey As String =
"-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAz4+TS+q0tlMh6obSGWDm
uZSfZNvjQ8SKklgczNJ2lrj+TQZR+m0odVRdBDoXymvvb9JBhOGAopLeVQp8mLd7
Myz+QEQdVKpZUKhG9hq8YoW66QPe00HwA4g98h59mUISvJu+bAjry3h3rg1mSD9R
+ViRKCUDFnlnxpAoO9uJAipVBRdHQVizoHOGPXcqtkdDMnKQDOcbdEAOZD5u7/ux
0uqxFacyJmSXYeZQ8fUwE5/XgPrWHO4CRH5yPW2GIGG5xxUV1fdDloclsxnspzJ7
JbLuGbxDlN2fL2XwN4PIvANKq0+/38t3xCAVWy0N0ganhBV0cWWO4NqM99BESfRu
oQIDAQAB
-----END PUBLIC KEY-----"

#End Region

#Region " Object name constants "
    Public Const OBJNAME_SY_START = "SY."
    Public Const OBJNAME_SY_AUTHENTICATION = OBJNAME_SY_START & "AUTH"
    Public Const OBJNAME_SY_BDSSYSTEM = OBJNAME_SY_START & "BDSSYSTEM"
    Public Const OBJNAME_SY_SEARCHFLD = OBJNAME_SY_START & "SEARCHFLD"
    Public Const OBJNAME_SY_DEFERROR = OBJNAME_SY_START & "DEFERROR"
    Public Const OBJNAME_SY_TLLOG = OBJNAME_SY_START & "TLLOG"
    Public Const OBJNAME_SY_USERLOGIN = OBJNAME_SY_START & "USERLOGIN"


    Public Const OBJNAME_SA_START = "SA."
    Public Const OBJNAME_SA_CRBTRFLOG = OBJNAME_SA_START & "CRBTRFLOG"
    Public Const OBJNAME_SA_CRBTRFLOGDTL = OBJNAME_SA_START & "CRBTRFLOGDTL"
    Public Const OBJNAME_SA_BRGRP = OBJNAME_SA_START & "BRGRP"
    Public Const OBJNAME_SA_BRGRPPARAM = OBJNAME_SA_START & "BRGRPPARAM"
    Public Const OBJNAME_SA_TLGRPAFTYPE = OBJNAME_SA_START & "TLGRPAFTYPE"
    Public Const OBJNAME_SA_TLPROFILES = OBJNAME_SA_START & "TLPROFILES"
    Public Const OBJNAME_SA_TLGROUPS = OBJNAME_SA_START & "TLGROUPS"
    Public Const OBJNAME_SA_FLDMASTER = OBJNAME_SA_START & "FLDMASTER"
    Public Const OBJNAME_SA_FLDVAL = OBJNAME_SA_START & "FLDVAL"
    Public Const OBJNAME_SA_APPMODULES = OBJNAME_SA_START & "APPMODULES"
    Public Const OBJNAME_SA_TLTX = OBJNAME_SA_START & "TLTX"
    Public Const OBJNAME_SA_SYSVAR = OBJNAME_SA_START & "SYSVAR"
    Public Const OBJNAME_SA_SYNCODE = OBJNAME_SA_START & "SYNCODE"
    Public Const OBJNAME_SA_BATCH = OBJNAME_SA_START & "SBBATCHCTL"
    Public Const OBJNAME_SA_SBBATCHSTS = OBJNAME_SA_START & "SBBATCHSTS"
    Public Const OBJNAME_SA_CLDR = OBJNAME_SA_START & "SBCLDR"
    Public Const OBJNAME_SA_SBFXRT = OBJNAME_SA_START & "SBFXRT"
    Public Const OBJNAME_SA_DEFERROR = OBJNAME_SA_START & "DEFERROR"
    Public Const OBJNAME_SA_RPTMASTER = OBJNAME_SA_START & "RPTMASTER"
    Public Const OBJNAME_SA_ALLCODE = OBJNAME_SA_START & "ALLCODE"
    Public Const OBJNAME_SA_LOOKUP = OBJNAME_SA_START & "LOOKUP"
    Public Const OBJNAME_SA_INVENTORY = OBJNAME_SA_START & "INVENTORY"
    Public Const OBJNAME_SA_IRRATE = OBJNAME_SA_START & "IRRATE"
    Public Const OBJNAME_SA_SECURITIES_TICKSIZE = OBJNAME_SA_START & "SECURITIES_TICKSIZE"
    Public Const OBJNAME_SA_SBCURRENCY = OBJNAME_SA_START & "SBCURRENCY"
    Public Const OBJNAME_SA_SBSECURITIES = OBJNAME_SA_START & "SBSECURITIES"
    Public Const OBJNAME_SA_RISK_ICCF = OBJNAME_SA_START & "RISK_ICCF"
    Public Const OBJNAME_SA_FEEMASTER = OBJNAME_SA_START & "FEEMASTER"
    Public Const OBJNAME_SA_FEEMAP = OBJNAME_SA_START & "FEEMAP"
    Public Const OBJNAME_SA_DEPOSIT_MEMBER = OBJNAME_SA_START & "DEPOSIT_MEMBER"

    Public Const OBJNAME_SA_SECURITIES_INFO = OBJNAME_SA_START & "SECURITIES_INFO"
    Public Const OBJNAME_SA_RISK_INFO = OBJNAME_SA_START & "SECURITIES_INFO"
    Public Const OBJNAME_SA_STCSE = OBJNAME_SA_START & "STCSE"
    Public Const OBJNAME_SA_STCTICKSIZE = OBJNAME_SA_START & "STCTICKSIZE"
    Public Const OBJNAME_SA_SECURITIES_RISK = OBJNAME_SA_START & "SECURITIES_RISK"


    Public Const OBJNAME_SA_FUNCASSIGN = OBJNAME_SA_START & "FUNCASSIGN"
    Public Const OBJNAME_SA_TRANSASSIGN = OBJNAME_SA_START & "TRANSASSIGN"
    Public Const OBJNAME_SA_RPTASSIGN = OBJNAME_SA_START & "RPTASSIGN"
    Public Const OBJNAME_SA_ISSUERS = OBJNAME_SA_START & "ISSUERS"
    Public Const OBJNAME_SA_ICCF = OBJNAME_SA_START & "ICCF"
    Public Const OBJNAME_SA_ICCFMAP = OBJNAME_SA_START & "ICCFMAP"
    Public Const OBJNAME_SA_ICCFRULES = OBJNAME_SA_START & "ICCFRULES"
    Public Const OBJNAME_SA_ICCFTX = OBJNAME_SA_START & "ICCFTX"
    Public Const OBJNAME_SA_ICCFTYPEDEF = OBJNAME_SA_START & "ICCFTYPEDEF"
    Public Const OBJNAME_SA_ICCFTIER = OBJNAME_SA_START & "ICCFTIER"
    Public Const OBJNAME_SA_TRADING_RESULT = OBJNAME_SA_START & "TRADING_RESULT"
    Public Const OBJNAME_SA_SEC_DAT = OBJNAME_SA_START & "SEC_DAT"
    Public Const OBJNAME_SA_CMDAUTH = OBJNAME_SA_START & "CMDAUTH"
    Public Const OBJNAME_SA_TLAUTH = OBJNAME_SA_START & "TLAUTH"
    Public Const OBJNAME_SA_TLGRPUSERS = OBJNAME_SA_START & "TLGRPUSERS"
    Public Const OBJNAME_SA_ISSUER_MEMBER = OBJNAME_SA_START & "ISSUER_MEMBER"
    Public Const OBJNAME_SA_CFOTHERACC = OBJNAME_SA_START & "CFOTHERACC"
    Public Const OBJNAME_SA_SEGROUPS = OBJNAME_SA_START & "SEGROUPS"
    Public Const OBJNAME_SA_SEGRPLIST = OBJNAME_SA_START & "SEGRPLIST"
    Public Const OBJNAME_SA_AFSEGRP = OBJNAME_SA_START & "AFSEGRP"
    Public Const OBJNAME_SA_USERVALIDRULE = OBJNAME_SA_START & "USERVALIDRULE"
    Public Const OBJNAME_SA_RIGHTCOPY = OBJNAME_SA_START & "RIGHTCOPY"
    Public Const OBJNAME_SA_FILEUPLOAD = OBJNAME_SA_START & "FILEUPLOAD"

    Public Const OBJNAME_CF_START = "CF."
    Public Const OBJNAME_CF_AFTYPE = OBJNAME_CF_START & "AFTYPE"
    Public Const OBJNAME_CF_AFMAST = OBJNAME_CF_START & "AFMAST"
    Public Const OBJNAME_CF_CFMAST = OBJNAME_CF_START & "CFMAST"
    Public Const OBJNAME_CF_CFCONTACT = OBJNAME_CF_START & "CFCONTACT"
    Public Const OBJNAME_CF_CFSIGN = OBJNAME_CF_START & "CFSIGN"
    Public Const OBJNAME_CF_CFLINK = OBJNAME_CF_START & "CFLINK"
    Public Const OBJNAME_CF_CFRELATION = OBJNAME_CF_START & "CFRELATION"
    Public Const OBJNAME_CF_CFAUTH = OBJNAME_CF_START & "CFAUTH"
    Public Const OBJNAME_CF_RPTAFMAST = OBJNAME_CF_START & "RPTAFMAST"
    Public Const OBJNAME_CF_REGTYPE = OBJNAME_CF_START & "REGTYPE"
    Public Const OBJNAME_CF_ICCFTYPEDEF = OBJNAME_CF_START & "ICCFTYPEDEF"
    Public Const OBJNAME_CF_ICCFTIER = OBJNAME_CF_START & "ICCFTIER"
    Public Const OBJNAME_CF_USERLIMIT = OBJNAME_CF_START & "USERLIMIT"
    Public Const OBJNAME_SA_AFOTHERAC = OBJNAME_CF_START & "AFOTHERAC"
    Public Const OBJNAME_CF_OTRIGHT = OBJNAME_CF_START & "OTRIGHT"

    Public Const OBJNAME_CA_START = "CA."
    Public Const OBJNAME_CA_CAMAST = OBJNAME_CA_START & "CAMAST"
    Public Const OBJNAME_CA_CASCHD = OBJNAME_CA_START & "CASCHD"

    Public Const OBJNAME_CI_START = "CI."
    Public Const OBJNAME_CI_CIMAST = OBJNAME_CI_START & "CIMAST"
    Public Const OBJNAME_CI_CITYPE = OBJNAME_CI_START & "CITYPE"
    Public Const OBJNAME_CI_ICCFTYPEDEF = OBJNAME_CI_START & "ICCFTYPEDEF"
    Public Const OBJNAME_CI_ICCFTIER = OBJNAME_CI_START & "ICCFTIER"

    Public Const OBJNAME_DD_START = "DD."
    Public Const OBJNAME_DD_DDMAST = OBJNAME_DD_START & "DDMAST"
    Public Const OBJNAME_DD_DDTYPE = OBJNAME_DD_START & "DDTYPE"
    Public Const OBJNAME_DD_ICCFTYPEDEF = OBJNAME_DD_START & "ICCFTYPEDEF"
    Public Const OBJNAME_DD_ICCFTIER = OBJNAME_DD_START & "ICCFTIER"

    Public Const OBJNAME_GL_START = "GL."
    Public Const OBJNAME_GL_GLMAST = OBJNAME_GL_START & "GLMAST"
    Public Const OBJNAME_GL_GLBANK = OBJNAME_GL_START & "GLBANK"
    Public Const OBJNAME_GL_FA = OBJNAME_GL_START & "FA"
    Public Const OBJNAME_GL_GLREF = OBJNAME_GL_START & "GLREF"

    Public Const OBJNAME_LN_START = "LN."
    Public Const OBJNAME_LN_LNTYPE = OBJNAME_LN_START & "LNTYPE"

    Public Const OBJNAME_LM_START = "LM."
    Public Const OBJNAME_LM_LMTYPE = OBJNAME_LM_START & "LMTYPE"
    Public Const OBJNAME_LM_LMMAST = OBJNAME_LM_START & "LMMAST"

    Public Const OBJNAME_CL_START = "CL."
    Public Const OBJNAME_CL_CLTYPE = OBJNAME_CL_START & "CLTYPE"
    Public Const OBJNAME_CL_CLMAST = OBJNAME_CL_START & "CLMAST"

    Public Const OBJNAME_GR_START = "GR."
    Public Const OBJNAME_GR_GRTYPE = OBJNAME_GR_START & "GRTYPE"
    Public Const OBJNAME_GR_GRMAST = OBJNAME_GR_START & "GRMAST"


    Public Const OBJNAME_FO_START = "FO."
    Public Const OBJNAME_FO_FOTYPE = OBJNAME_FO_START & "FOTYPE"
    Public Const OBJNAME_FO_FOMAST = OBJNAME_FO_START & "FOMAST"
    Public Const OBJNAME_FO_USERMKTWATCH = OBJNAME_FO_START & "USERMKTWATCH"
    Public Const OBJNAME_FO_USERLOGIN = OBJNAME_FO_START & "USERLOGIN"


    Public Const OBJNAME_OD_START = "OD."
    Public Const OBJNAME_OD_ORTYPE = OBJNAME_OD_START & "ODTYPE"
    Public Const OBJNAME_OD_OOD = OBJNAME_OD_START & "OOD"
    Public Const OBJNAME_OD_IOD = OBJNAME_OD_START & "IOD"
    Public Const OBJNAME_OD_ODTYPE = OBJNAME_OD_START & "ODTYPE"
    Public Const OBJNAME_OD_ODMAST = OBJNAME_OD_START & "ODMAST"
    Public Const OBJNAME_OD_ODCANCEL = OBJNAME_OD_START & "ODCANCEL"


    Public Const OBJNAME_OD_SECINFO = OBJNAME_OD_START & "SECURITIES_INFO"

    Public Const OBJNAME_OD_STSCHD = OBJNAME_OD_START & "STSCHD"
    Public Const OBJNAME_OD_ICCFTYPEDEF = OBJNAME_OD_START & "ICCFTYPEDEF"
    Public Const OBJNAME_OD_ICCFTIER = OBJNAME_OD_START & "ICCFTIER"
    Public Const OBJNAME_OD_SECTICKSIZE = OBJNAME_OD_START & "SECURITIES_TICKSIZE"

    Public Const OBJNAME_RP_START = "RP."
    Public Const OBJNAME_RP_RPTYPE = OBJNAME_RP_START & "RPTYPE"
    Public Const OBJNAME_RP_RPMAST = OBJNAME_RP_START & "RPMAST"
    Public Const OBJNAME_RP_ICCFTYPEDEF = OBJNAME_RP_START & "ICCFTYPEDEF"
    Public Const OBJNAME_RP_ICCFTIER = OBJNAME_RP_START & "ICCFTIER"


    Public Const OBJNAME_SE_START = "SE."
    Public Const OBJNAME_SE_CLMAST = OBJNAME_SE_START & "CLMAST"
    Public Const OBJNAME_SE_CLTYPE = OBJNAME_SE_START & "CLTYPE"
    Public Const OBJNAME_SE_SEMAST = OBJNAME_SE_START & "SEMAST"
    Public Const OBJNAME_SE_SETYPE = OBJNAME_SE_START & "SETYPE"
    Public Const OBJNAME_SE_SBSECURITIES = OBJNAME_SE_START & "SBSECURITIES"
    Public Const OBJNAME_SE_ICCFTYPEDEF = OBJNAME_SE_START & "ICCFTYPEDEF"
    Public Const OBJNAME_SE_ICCFTIER = OBJNAME_SE_START & "ICCFTIER"
    Public Const OBJNAME_SE_SELINK = OBJNAME_SE_START & "SELINK"

    Public Const OBJNAME_RM_START = "RM."
    Public Const OBJNAME_RM_GENERAL = OBJNAME_RM_START & "GENERAL"
    Public Const OBJNAME_RM_CRBDEFBANK = OBJNAME_RM_START & "CRBDEFBANK"

    Public Const OBJNAME_MR_SEARCH_LIQUIDITY_STATE_VIEW = "MR0003"

    Public Const OBJNAME_CA_EXECUTE_SECURITIES_SEARCH = "CA9998"
    Public Const OBJNAME_CA_EXECUTE_MONEY_SEARCH = "CA9999"
    Public Const OBJNAME_CA_CONFIRM_SEARCH = "CA9997"

    Public Const OBJNAME_FA_START = "FA."
    Public Const OBJNAME_FA_FAMEMBERS = OBJNAME_FA_START & "FABROKERAGE"
    Public Const OBJNAME_FA_SBACTIDTL = OBJNAME_FA_START & "SBACTIDTL"
    '
    Public Const gc_PinType As String = "1"
    Public Const gc_TokenType As String = "2"
    Public Const gc_MatrixType As String = "3"
    Public Const AUTH_GROUP_TOKEN = "bscEntrustTokenGroup"
    Public Const AUTH_GROUP_MATRIX = "bscGridCardGroup_noexpired"
#End Region

#Region " CÃ¡c háº±ng sá»‘ format dá»¯ liá»‡u "
    Public Const gc_FORMAT_DATE = "dd/MM/yyyy"
    Public Const gc_FORMAT_DATE_TIME = "dd/MM/yyyy hh:mm:ss"
    Public Const gc_FORMAT_DATE_DB = "DD/MM/RRRR"

    Public Const gc_FORMAT_TIME = "hh:mm:ss"
    Public Const gc_FORMAT_TXNUM = "000000"
    Public Const gc_FORMAT_BATCHTXNUM = "0000000000"
    Public Const gc_FORMAT_COREBANKTXNUM = "0000000000"
    Public Const gc_FORMAT_GENERALVIEWTXNUM = "0000000000"
    Public Const gc_FORMAT_NUMBER = "#,##0.0000"
    Public Const gc_FORMAT_NUMBER_2 = "#,##0.00"
    Public Const gc_FORMAT_NUMBER_0 = "#,##0"
    Public Const gc_FORMAT_GLACCTNO = "####.##.#####.####"
    Public Const gc_FORMAT_AFACCTNO = "0000000000"
    Public Const gc_FORMAT_ODDATE = "DDMMYYYY"
    Public Const gc_FORMAT_ODAUTOID = "000000"
    Public Const gc_FORMAT_RPAUTOID = "000000"
    Public Const MaxNumber = "100000000000000"
    Public Const gc_NULL_DATE = "01/01/1753"
    Public Const gc_FORMAT_SHORT_DATE = "ddMMyy"
#End Region

#Region " CÃ¡c háº±ng sá»‘ Ä‘á»‹nh nghÄ©a mÃ£ phÃ¢n há»‡ nghiá»‡p vá»¥ "
    Public Const SUB_SYSTEM_SA = "SA"
    Public Const SUB_SYSTEM_CF = "CF"
    Public Const SUB_SYSTEM_CA = "CA"
    Public Const SUB_SYSTEM_CI = "CI"
    Public Const SUB_SYSTEM_OD = "OD"
    Public Const SUB_SYSTEM_RP = "RP"
    Public Const SUB_SYSTEM_GL = "GL"
    Public Const SUB_SYSTEM_SE = "SE"
    Public Const SUB_SYSTEM_RM = "RM"
    Public Const SUB_SYSTEM_LN = "LN"
    Public Const SUB_SYSTEM_LM = "LM"
    Public Const SUB_SYSTEM_CL = "CL"
    Public Const SUB_SYSTEM_GR = "GR"
    Public Const SUB_SYSTEM_RE = "RE"
#End Region

#Region " Error code constants "

    Public Const ERR_SYSTEM_OK = 0
    Public Const ERR_SYSTEM_START = ERR_SYSTEM_OK - 1

    'AnhVT Added - Maintenance Approval Retro
    Public Const ERR_APPROVE_REQUIRED As Integer = ERR_SYSTEM_OK + 1
    Public Const ERR_MAINTAIN_LOG As Integer = ERR_SYSTEM_OK + 2

    '--Phan he SA
    Public Const ERR_SA_START = ERR_SYSTEM_OK - 100000
    Public Const ERR_SA_BRID_DUPLICATED = ERR_SA_START - 1
    Public Const ERR_SA_CANNOT_DEL_CURRENT_BRANCH = ERR_SA_START - 2
    Public Const ERR_SA_BRANCH_HAS_CHILD = ERR_SA_START - 3
    Public Const ERR_SA_BRANCH_HAS_TELLER = ERR_SA_START - 4
    Public Const ERR_SA_PRBRID_NOTFOUND = ERR_SA_START - 5
    Public Const ERR_SA_TLID_DUPLICATED = ERR_SA_START - 6
    Public Const ERR_SA_TL_HAS_CHILD = ERR_SA_START - 7
    Public Const ERR_SA_GRPID_DUPLICATED = ERR_SA_START - 8
    Public Const ERR_SA_GRP_HAS_CHILD = ERR_SA_START - 9
    Public Const ERR_SA_CHECKER1_OVR = ERR_SA_START - 10
    Public Const ERR_SA_CHECKER2_OVR = ERR_SA_START - 11
    Public Const ERR_SA_APPCHK_MISSING = ERR_SA_START - 12
    Public Const ERR_SA_APPCHK_ACCTNO_NOTFOUND = ERR_SA_START - 13
    Public Const ERR_SA_TRANSACTION_NOTFOUND = ERR_SA_START - 14
    Public Const ERR_SA_PRINTINFO_ACCTNOTFOUND = ERR_SA_START - 15
    Public Const ERR_SA_SHOULDAPPROVE_BEFORECASHIER = ERR_SA_START - 16
    Public Const ERR_SA_CANNOT_DELETETRANSACTION = ERR_SA_START - 17
    Public Const ERR_SA_TLTXCD_NOTFOUND = ERR_SA_START - 18
    Public Const ERR_SA_VARIABLE_NOTFOUND = ERR_SA_START - 19
    Public Const ERR_SA_BDS_OPERATION_STILLACTIVE = ERR_SA_START - 20
    Public Const ERR_SA_BDS_OPERATION_ISINACTIVE = ERR_SA_START - 21
    Public Const ERR_SA_HOST_OPERATION_STILLACTIVE = ERR_SA_START - 22
    Public Const ERR_SA_HOST_OPERATION_ISINACTIVE = ERR_SA_START - 23
    Public Const ERR_SA_ONLY_HEADOFFICE_RUNBATCH = ERR_SA_START - 24
    Public Const ERR_SA_INTERNAL_CODE_ISDUPLICATED = ERR_SA_START - 25
    Public Const ERR_SA_CCYCD_NOTFOUND = ERR_SA_START - 26
    Public Const ERR_SA_CODEID_HAS_CONSTRAINT = ERR_SA_START - 27
    Public Const ERR_SA_ISSUERID_NOTFOUND = ERR_SA_START - 28
    Public Const ERR_SA_STILLHAS_BRGRP_ACTIVE = ERR_SA_START - 29
    Public Const ERR_SA_CALENDAR_MISSING = ERR_SA_START - 30
    Public Const ERR_SA_SECTICKSIZE_DUPLICATE = ERR_SA_START - 31
    Public Const ERR_SA_CCYCD_DUPLICATE = ERR_SA_START - 32
    Public Const ERR_SA_ISSUERS_ISSUERID_DUPLICATED = ERR_SA_START - 33
    Public Const ERR_SA_ISSUERS_CUSTID_NOTFOUND = ERR_SA_START - 34
    Public Const ERR_SA_ISSUERS_HAS_RELATED_DATA = ERR_SA_START - 35
    Public Const ERR_SA_CCYCD_DUPLICATED = ERR_SA_START - 36
    Public Const ERR_SA_RPTID_DUPLICATED = ERR_SA_START - 37
    Public Const ERR_SA_CMDCODE_NOTFOUND = ERR_SA_START - 38
    Public Const ERR_SA_MODCODE_NOTFOUND = ERR_SA_START - 39
    Public Const gc_ERR_SA_BRID_NOTFOUND = ERR_SA_START - 40
    Public Const ERR_SA_RATENUM_NOTFOUND = ERR_SA_START - 41
    Public Const ERR_SA_CCYCD_CONSTRAINTS = ERR_SA_START - 42
    Public Const ERR_SA_TL_HAS_CMDAUTH = ERR_SA_START - 43
    Public Const ERR_SA_TL_HAS_TLAUTH = ERR_SA_START - 44
    Public Const ERR_SA_GRP_HAS_CMDAUTH = ERR_SA_START - 45
    Public Const ERR_SA_GRP_HAS_TLAUTH = ERR_SA_START - 46
    Public Const ERR_SA_TRANSACT_CMDALLOW = ERR_SA_START - 47
    Public Const ERR_SA_TL_IN_SYS = ERR_SA_START - 48
    Public Const ERR_SA_TLNAME_DUPLICATED = ERR_SA_START - 49
    Public Const ERR_SA_GRPNAME_DUPLICATED = ERR_SA_START - 50
    Public Const ERR_SA_TRANSACT_TRANSOVRLIMIT = ERR_SA_START - 51
    Public Const ERR_SA_TRANSACT_APPROVRLIMIT = ERR_SA_START - 52
    Public Const ERR_SA_TRANSACT_CASHOVRLIMIT = ERR_SA_START - 53
    Public Const ERR_SA_ISSUER_MEMBER_CUSTID_NOTFOUND = ERR_SA_START - 54
    Public Const ERR_SA_TRANSACT_APPR_CMDALLOW = ERR_SA_START - 55
    Public Const ERR_SA_TRANSACT_CASH_CMDALLOW = ERR_SA_START - 56
    Public Const ERR_SA_SYMBOL_DUPLICATED = ERR_SA_START - 57
    Public Const ERR_SA_SYMBOL_NOTFOUND = ERR_SA_START - 58
    Public Const ERR_SA_ICCFTYPEDEF_DUPLICATED = ERR_SA_START - 59
    Public Const ERR_SA_ICCFTIER_DUPLICATED = ERR_SA_START - 60
    Public Const ERR_SA_CCYCD_NOTACTIVE = ERR_SA_START - 61
    Public Const ERR_SA_SECTICKSIZE_CONSTRAINTS = ERR_SA_START - 62
    Public Const ERR_SA_ACCTNO_NOTFOUND = ERR_SA_START - 63
    Public Const ERR_SA_LICENSENO_ISNOT_EMPTY = ERR_SA_START - 64
    Public Const ERR_SA_CDVAL_DUPLICATED = ERR_SA_START - 65
    Public Const ERR_SA_CRTUSR_NOTTELLER = ERR_SA_START - 66
    Public Const ERR_SA_CRTUSR_NOTCASHIER = ERR_SA_START - 67
    Public Const ERR_SA_CRTUSR_NOTOFFICER = ERR_SA_START - 68
    Public Const ERR_SA_CRTUSR_NOTCHECKER = ERR_SA_START - 69
    Public Const ERR_SA_TRANSACT_TELLERLIMIT_NOTDEFINED = ERR_SA_START - 70
    Public Const ERR_SA_TRANSACT_CASHIERLIMIT_NOTDEFINED = ERR_SA_START - 71
    Public Const ERR_SA_TRANSACT_OFFICERLIMIT_NOTDEFINED = ERR_SA_START - 72
    Public Const ERR_SA_TRANSACT_CHECKERLIMIT_NOTDEFINED = ERR_SA_START - 73
    Public Const ERR_SA_TL_EDIT_CURRENT_USR = ERR_SA_START - 74
    Public Const ERR_SA_SECTICKSIZE_INVALID = ERR_SA_START - 75
    Public Const ERR_SA_READ_TRADING_RESULT_TWICE = ERR_SA_START - 76
    Public Const ERR_SA_ISSUERS_LEN_ISSUERID_EQUAL_10 = ERR_SA_START - 77
    Public Const ERR_SA_NO_DATAFOUND = ERR_SA_START - 78
    Public Const ERR_SA_TLLOG_INVALID_STATUS = ERR_SA_START - 79
    Public Const ERR_SA_ISSUER_HAS_ONE_NORMALSHARE = ERR_SA_START - 80
    Public Const ERRCODE_GL_GLBANK_NOTNOTFOUND = ERR_SA_START - 81
    Public Const ERRCODE_GL_GLACCOUNT_NOTFOUND = ERR_SA_START - 119
    Public Const ERR_SA_CURRDATE_SMALLER_THAN_EFFECTIVEDT = ERR_SA_START - 82
    Public Const ERR_SA_BUSDATE_BRANCHDATE_PLZLOGIN_OUT = ERR_SA_START - 83
    Public Const ERR_SA_TRADING_RESULT_INVALID_DATE = ERR_SA_START - 84
    Public Const ERR_SA_TRANSACT_MAKE_ERR = ERR_SA_START - 85
    Public Const ERR_SA_STCSE_DUPLICATED = ERR_SA_START - 86
    Public Const ERR_SA_VSD_STATUS = ERR_SA_START - 89
    Public Const ERR_SA_FEEMASTER_DUPLICATED = ERR_SA_START - 187
    Public Const ERR_SA_FEEMASTER_ALREADYMAP = ERR_SA_START - 188
    Public Const ERR_SA_ISSUES_ISSUECODE_DUPLICATED = ERR_SA_START - 190
    Public Const ERR_SA_FEEMASTER_SUBTYPEDUPLICATED = ERR_SA_START - 191
    Public Const ERR_SA_IBT_DOESNOTALLOW = ERR_SA_START - 89
    Public Const ERR_SA_NOT_RIGHT_MODIFY = ERR_SA_START - 90
    Public Const ERR_SA_FEEMAP_DUPLICATED = ERR_SA_START - 91
    Public Const ERR_SA_BUSDATE_DIF_TXDATE = ERR_SA_START - 92
    Public Const ERR_SA_DEPOSITID_DUPLICATED = ERR_SA_START - 93
    Public Const ERR_SA_CITAD_DUPLICATED = ERR_SA_START - 97
    Public Const ERR_SA_TLGROUPS_CAREBY = ERR_SA_START - 94
    Public Const ERR_SA_FAMT_TOAMT = ERR_SA_START - 95
    Public Const ERR_SA_FEEMASTER_ALREADYTIER = ERR_SA_START - 189
    Public Const ERR_SA_OVER_AVAILABLE_USER_LIMIT = ERR_SA_START - 611
    Public Const ERR_SA_OVER_AVAILABLE_USER_AFLIMIT = ERR_SA_START - 603
    Public Const ERR_SA_OVER_AVAILABLE_CUSTLIMIT = ERR_SA_START - 607
    Public Const ERR_SA_DUP_GROUPID = ERR_SA_START - 1000
    Public Const ERR_SA_DUP_ACCMEMBER = ERR_SA_START - 1001
    Public Const ERR_SA_NOT_ALLOW_DELETE_ACCLEADER = ERR_SA_START - 1002
    Public Const ERR_SA_CUSTODYCD_DUPLICATED = ERR_SA_START - 1003

    Public Const ERR_SA_ODPROBRKMST_HAS_CONTRAINT = ERR_SA_START - 96
    Public Const ERR_SA_ODPROBRKAF_DUPLICATED = ERR_SA_START - 97
    Public Const ERR_SA_ODPROBRKAF_CREATEDDATE_ERROR = ERR_SA_START - 153
    Public Const ERR_SA_ODPROBRKSCHM_DUPLICATED = ERR_SA_START - 98
    Public Const ERR_BATCH_PROCESS_FOLLOW_SEQUENCE = ERR_SA_START - 99

    Public Const ERR_SA_HOST_VOUCHER_DOESNOT_FOUND = ERR_SA_START - 100
    Public Const ERR_SA_FIELD_DUPLICATED = ERR_SA_START - 101
    Public Const ERR_SA_CIACCOUNT_NOTFOUND = ERR_SA_START - 102
    Public Const ERR_SA_BANKID_NOTFOUND = ERR_SA_START - 103
    Public Const ERR_SA_FLRATE_NOT_IN_SYSTEM_RATE_RANGE = ERR_SA_START - 104
    Public Const ERR_SA_CERATE_NOT_IN_SYSTEM_RATE_RANGE = ERR_SA_START - 105
    Public Const ERR_SA_ICRATE_NOT_IN_SYSTEM_RATE_RANGE = ERR_SA_START - 106
    Public Const ERR_SA_ICRATE_NOT_IN_PRODUCT_RATE_RANGE = ERR_SA_START - 107
    Public Const ERR_SA_LSTODR_DUPLICATED = ERR_SA_START - 108
    Public Const ERR_SA_GLACCTNO_NOTFOUND = ERR_SA_START - 109
    Public Const ERR_SA_EVENT_DOESNOT_EXITS = ERR_SA_START - 110
    Public Const ERR_SA_CANNOT_CHANGE_GLGRP = ERR_SA_START - 111
    Public Const ERR_SA_INVALID_TRADING_PASSWORD = ERR_SA_START - 112
    Public Const ERR_SA_INVALID_SECSSION = ERR_SA_START - 113
    Public Const ERR_SA_EXTREFDEF_CONTRAINT = ERR_SA_START - 114
    Public Const ERR_SA_CANNOT_CHANGE_MRTYPE = ERR_SA_START - 115
    Public Const ERR_SA_CANNOT_CHANGE_AFTYPE = ERR_SA_START - 116
    Public Const ERR_SA_CANNOT_CHANGE_LNTYPE = ERR_SA_START - 117
    Public Const ERR_SA_FEEMAP_FEECD_DOESNOT_EXISTS = ERR_SA_START - 118
    Public Const ERR_SA_TLTX_NOT_ALLOW_BY_ACCTNO = ERR_SA_START - 120
    Public Const ERR_SA_RUN_BEFORE_BATCH = ERR_SA_START - 119
    Public Const ERR_SA_ICCFSCHD_NESTED = ERR_SA_START - 130
    Public Const ERR_SA_CANNOT_DELETE_PENDING_TRANS = ERR_SA_START - 438
    Public Const ERR_SA_EXIT_DEFAULTACCT = ERR_SA_START - 439


    Public Const ERR_SA_SHORTNAME_DUPLICATED = ERR_SA_START - 121
    Public Const ERR_SA_LENGTH_SHORTNAME = ERR_SA_START - 122
    Public Const ERR_SA_DELETE_BANK = ERR_SA_START - 123
    Public Const ERR_SA_GLACCOUNT_NOTFOUND = ERR_SA_START - 124
    Public Const ERR_SA_CANNOT_CHANGE_COREBANK_TYPE = ERR_SA_START - 125
    Public Const ERR_SA_DUPLICATE_LOAN_SOURCE = ERR_SA_START - 126
    Public Const ERR_SA_TRFBUYEXT_TRFBUYRATE_NOT_ZERO = ERR_SA_START - 127
    Public Const ERR_SA_BANKTRANS_BANKNOSTRO_DUPLICATED = ERR_SA_START - 129	
    Public Const ERR_SA_FUNDID_NOT_FOUND = ERR_SA_START - 306
    Public Const ERR_SA_USERLOGIN_AMC_EXISTS = ERR_SA_START - 310
    Public Const ERR_SA_USERLOGIN_STC_NOT_FOUND = ERR_SA_START - 311
    Public Const ERR_SA_USERLOGIN_EMAIL_EXISTS = ERR_SA_START - 312

    Public Const ERR_SA_DUPLICATE_LNTYPE_SECBASKET = ERR_SA_START - 411
    Public Const ERR_SA_CANNOT_CHANGE_BANKNAME = ERR_SA_START - 412

    'ThangNV: Them phan Tu doanh-Chinh sach dau tu
    Public Const ERR_SA_DUPLICATE_TIME_VALIDITY = ERR_SA_START - 888

    'BEGIN - Vinh: Them cho phan quan ly ro chung khoan
    Public Const ERR_SA_BASKETID_DUPLICATED = ERR_SA_START - 400
    Public Const ERR_SA_BASKETID_HAS_CONTRAINT = ERR_SA_START - 401
    Public Const ERR_SA_SECBASKETID_SYMBOL_DUPLICATED = ERR_SA_START - 402
    Public Const ERR_SA_DFBASKETID_SYMBOL_DUPLICATED = ERR_SA_START - 403
    Public Const ERR_SA_AFSEBASKETID_ACTYPE_DUPLICATED = ERR_SA_START - 404
    Public Const ERR_SA_AFDFBASKETID_ACTYPE_DUPLICATED = ERR_SA_START - 405
    Public Const ERR_SA_BASKETID_DOESNOT_FOUND = ERR_SA_START - 406
    Public Const ERR_SA_DFBASKETID_SYMBOL_DOESNOT_FOUND = ERR_SA_START - 408
    Public Const ERR_SA_TYPE_IS_USED = ERR_SA_START - 881


    Public Const ERR_SA_FEEDEF_CI_DUPLICATE = ERR_SA_START - 420
    Public Const ERR_SA_FEEDEF_CI_INVALID_STATUS = ERR_SA_START - 421
    Public Const ERR_SA_FEEDEF_CI_IS_ACTIVE = ERR_SA_START - 422
    Public Const ERR_SA_OVER_BANK_CREDITLIMIT = ERR_SA_START - 423
    Public Const ERR_INVALID_AMT_DEPOFEE = ERR_SA_START - 430

    Public Const ERR_CRBTRFLOG_VERSION_DUPLICATE = ERR_SA_START - 431
    Public Const ERR_CRBTRFLOG_INVALID_STATUS = ERR_SA_START - 432
    Public Const ERR_CRBTRFLOG_CONTAINT_CRBTXREQ = ERR_SA_START - 433
    Public Const ERR_INVALID_STATUS_OF_LISTVOUCHER = ERR_SA_START - 434
    Public Const ERR_SA_LNRATE_GREATER_THAN_PPRATE = ERR_SA_START - 435
    Public Const ERR_SA_INVALID_SYMBOL_IMPORT_FROM_EXCEL = ERR_SA_START - 436
    Public Const ERR_TRADING_PLAN_HAS_CONSTRAINT = ERR_SA_START - 437
    Public Const ERR_CF_AFACCTNO_ALREADY_MAP2TRADER = ERR_SA_START - 438
    'END - Vinh: Them cho phan quan ly ro chung khoan

    Public Const ERR_SA_PRODUCT_ACTYPE_NOTFOUND = ERR_SA_START - 499
    Public Const ERR_SA_PRODUCT_ACTYPE_DUPLICATED = ERR_SA_START - 500
    Public Const ERR_SA_PRODUCT_CCYCD_NOTFOUND = ERR_SA_START - 501
    Public Const ERR_SA_PRODUCT_GLGRP_NOTEXITS = ERR_SA_START - 502
    Public Const ERR_SA_PRODUCT_GLBANK_NOTFOUND = ERR_SA_START - 503
    Public Const ERR_SA_PRODUCT_HAS_CONSTRAINT = ERR_SA_START - 504
    Public Const ERR_SA_USINGBRANCH_DUPLICATED = ERR_SA_START - 505
    Public Const ERR_SA_USINGSERVICE_DUPLICATED = ERR_SA_START - 506
    Public Const ERR_SA_SERVICE_ORDERNUM_DUPLICATED = ERR_SA_START - 511

    Public Const ERR_SA_ACCTNO_DUPLICATED = ERR_SA_START - 507
    Public Const ERR_SA_ACCTNO_MASTER_NOTFOUND = ERR_SA_START - 508
    Public Const ERR_SA_ACCTNO_MASTER_INVALID_STATUS = ERR_SA_START - 509
    Public Const ERR_SA_DFTYPE_NOT_APPROVED = ERR_SA_START - 510

    Public Const ERR_SA_IMPORT_FILE_INVALID = ERR_SA_START - 800
    Public Const ERR_SA_TXMAP_INVALID_EXPDATE = ERR_SA_START - 801
    Public Const ERR_SA_TXMAP_DUPPLICATE_TLTXCD = ERR_SA_START - 802
    Public Const ERR_SA_ODTYPE_DUPLICATE = ERR_SA_START - 803


    Public Const ERR_PRTYPE_DUPLICATED = ERR_SA_START - 515
    Public Const ERR_PRTYPE_NOT_FOUND = ERR_SA_START - 516
    Public Const ERR_PRDETAIL_DUPLICATED = ERR_SA_START - 517
    Public Const ERR_PRDETAIL_NOT_FOUND = ERR_SA_START - 518
    Public Const ERR_PRMASTER_DUPLICATED = ERR_SA_START - 519
    Public Const ERR_PRMASTER_NOT_FOUND = ERR_SA_START - 520
    Public Const ERR_PRMASTER_HAS_CONSTRAINT = ERR_SA_START - 521
    Public Const ERR_PRCHK_UNDEFINED = ERR_SA_START - 522
    Public Const ERR_PRCHK_OVER_TOTAL = ERR_SA_START - 523
    Public Const ERR_PRCHK_OVER_TYPE = ERR_SA_START - 524
    Public Const ERR_PRCHK_OVER_BRID = ERR_SA_START - 525
    Public Const ERR_PRCHK_OVER_GRPID = ERR_SA_START - 526
    Public Const ERR_PRGROUPS_DUPLICATED = ERR_SA_START - 527
    Public Const ERR_PRGROUPS_NOT_FOUND = ERR_SA_START - 528
    Public Const ERR_PRCHK_INUSED_TOTAL = ERR_SA_START - 529
    Public Const ERR_PRCHK_INUSED_TYPE = ERR_SA_START - 530
    Public Const ERR_PRCHK_INUSED_BRID = ERR_SA_START - 531
    Public Const ERR_PRCHK_INUSED_GRPID = ERR_SA_START - 532
    Public Const ERR_PRCHK_PRAMT = ERR_SA_START - 533
    Public Const ERR_PRCHK_PRCODE = ERR_SA_START - 534
    Public Const ERR_PRMASTER_DEL_ROOM_USED = ERR_SA_START - 552
    Public Const ERR_PRMASTER_DEL_ROOM_EXIST_SEC = ERR_SA_START - 553
    Public Const ERR_PRMASTER_DEL_ROOM_EXIST_AFMAST = ERR_SA_START - 554
    Public Const ERR_PRMASTER_CHECK_VALDATE = ERR_SA_START - 555
    Public Const ERR_PRMASTER_CHECK_EXPIREDDT = ERR_SA_START - 556
    Public Const ERR_PRMASTER_CHECK_EXPIREDDT2 = ERR_SA_START - 557

    Public Const ERR_SA_CUSTID_NOT_SAME = ERR_SA_START - 600
    Public Const ERR_SA_USERID_NOTFOUND = ERR_SA_START - 601
    Public Const ERR_SA_ALLOCATE_OVER_AVAILABLE_USER_LIMIT = ERR_SA_START - 602 ' cap vuot qua so margin con lai cua user
    Public Const ERR_SA_ALLOCATE_OVER_AVAILABLE_USER_LIMIT_TO_AF = ERR_SA_START - 603 ' so cap vuot qua so cua user co the cap cho 1 hop dong 
    Public Const ERR_SA_CAN_NOT_RETRIEVE = ERR_SA_START - 604 ' Khong the thu hoi khi chua cap 
    Public Const ERR_SA_RETRIEVE_OVER_ALLOCATE = ERR_SA_START - 605 ' Khong the thu hoi vuot khoan cap
    Public Const ERR_SA_ACCTNO_NOT_ACTIVE = ERR_SA_START - 606 ' ' acctno ko hoat dong
    Public Const ERR_SA_ALLOCATE_OVER_MRLOANLIMIT = ERR_SA_START - 607 ' tong so han muc + cap them > han muc cua khach hang 
    Public Const ERR_SA_ACCTNO_NOT_IN_MARGIN_TYPE = ERR_SA_START - 608

    Public Const ERR_SA_AF_HAVE_NOT_COMPLETE_PAYMENT = ERR_SA_START - 609 ' Hop dong chua tat toan
    Public Const ERR_SA_AF_IN_MARGIN_GROUP = ERR_SA_START - 700 'Hop dong van o nhom margin
    Public Const ERR_SA_NOT_RETRIEVE_ALL_MARGIN_LIMIT = ERR_SA_START - 701 'Chua thu hoi het han muc margin
    Public Const ERR_SA_NOT_RETRIEVE_ALL_MARGIN_LIMIT_To = ERR_SA_START - 702 'Chua thu hoi het han muc To
    Public Const ERR_SA_NOT_RETRIEVE_ALL_MRCRLIMIT_invalid = ERR_SA_START - 703
    Public Const ERR_SA_FILEID_DUPLICATED = ERR_SA_START - 704
    Public Const ERR_SA_DUPLICATE_BANKNAME = ERR_SA_START - 705

    '
    Public Const ERR_SA_CHANGEPASS_OLDPASSINVALID = ERR_SA_START - 706
    Public Const ERR_SA_CHANGEPASS_INPUTINCORRECT = ERR_SA_START - 707
    Public Const ERR_SA_INVALID_BACKDATE = ERR_SA_START - 708
    Public Const ERR_SA_FAMT_TOAMT_CONFLICT = ERR_SA_START - 720
    Public Const ERR_SA_CAN_NOT_DELELE = ERR_SA_START - 721
    Public Const ERR_SA_STILL_HAS_AF = ERR_SA_START - 222
    Public Const ERR_SA_ADTYPE_DUPLICATED = ERR_SA_START - 804
    Public Const ERR_SA_ACOUNT_IN_BROKERFEE_GROUP = ERR_SA_START - 807
    Public Const ERR_SA_ACOUNT_IN_CUSTODY_BROKERFEE = ERR_SA_START - 808
    Public Const ERR_SA_ACOUNT_IN_AFMRLIMIT_GROUP = ERR_SA_START - 850

    'Phuc add: validate MARGIN VARVALUE
    Public Const ERR_SA_VARVALUE_IS_NOT_NUMBER = ERR_SA_START - 809
    Public Const ERR_SA_VARVALUE_IS_SMALLER_THAN_ZERO = ERR_SA_START - 810
    Public Const ERR_SA_VARVALUE_IS_DECIMAL = ERR_SA_START - 811
    Public Const ERR_SA_VARVALUE_LENGTH_OVER_14 = ERR_SA_START - 812
    Public Const ERR_SA_VARVALUE_INCLUDE_WHITE_SPACE = ERR_SA_START - 813
    Public Const ERR_SA_VARVALUE_INCLUDE_COMMA = ERR_SA_START - 814
    Public Const ERR_SA_MAXTOTALDEBTDAYS_SMALLER_THAN_MAXDEBTDAYS = ERR_SA_START - 815
    Public Const ERR_SA_MAXDEBTQTTYRATE_IS_INVALID = ERR_SA_START - 816
    Public Const ERR_SA_MARGINALLOW_IS_INVALID = ERR_SA_START - 817
    Public Const ERR_SA_VARVALUE_NUMBER_MUST_BETWEEN_0_100 = ERR_SA_START - 818
    Public Const ERR_SA_PRMASTER_SYSTEM_POOL = ERR_SA_START - 846
    'End Phuc
    Public Const ERR_SA_SERATIOTIERS_WRONG_DATA = ERR_SA_START - 36
    Public Const ERR_SA_SERATIOTIERS_CANT_DELETE = ERR_SA_START - 87
    Public Const ERR_SA_SERATIOS_CHECK_DATE = ERR_SA_START - 92
    Public Const ERR_SA_SERATIOS_CANT_DELETE = ERR_SA_START - 91
    Public Const ERR_SA_SERATIOS_CHECK_TODATE = ERR_SA_START - 90
    Public Const ERR_SA_SERATIOS_CHECK_FRDATE = ERR_SA_START - 88
    Public Const ERR_SA_SERATIOTYP_CHECK_AFTYPE = ERR_SA_START - 97


    Public Const ERR_SA_REREVIEWTERM_CHECK_DATE = ERR_SA_START - 900
    Public Const ERR_SA_REREVIEWTERM_CHECK_TODATE = ERR_SA_START - 901
    Public Const ERR_SA_REREVIEWTERM_CHECK_FRDATE = ERR_SA_START - 902
    Public Const ERR_SA_REREVIEWTERM_CANT_DELETE = ERR_SA_START - 903

    Public Const ERR_SA_REREVIEWTERMTIERS_WRONG_DATA = ERR_SA_START - 904
    Public Const ERR_SA_REREVIEWTERMTIERS_CANT_DELETE = ERR_SA_START - 905
    Public Const ERR_SA_REPROMREVIEWTERMTIERS_DUPLICATE_POSITION = ERR_SA_START - 906
    Public Const ERR_SA_CFFCFFEEEXP_EXIT = ERR_SA_START - 907
    Public Const ERR_SA_CFFEEEXPTIER_ALREADYTIER = ERR_SA_START - 908
    Public Const ERR_SA_CFFCFFEEEXP_AUTOID_WRONG = ERR_SA_START - 909
    Public Const ERR_SA_CFFCFFEEEXP_AMCID_EXIST = ERR_SA_START - 910

    Public Const ERR_SA_EXIST_PRIORITIZE = ERR_SA_START - 998

    'PhÃ¢n há»‡ CF
    Public Const ERR_CF_START = ERR_SYSTEM_OK - 200000
    Public Const ERR_CF_ACTYPE_DUPLICATED = ERR_CF_START - 1
    Public Const ERR_CF_CUSTOMER_NOTFOUND = ERR_CF_START - 2
    Public Const ERR_CF_AFTYPE_NOTFOUND = ERR_CF_START - 3
    Public Const ERR_CF_AFMAST_ALREADY_EXIST = ERR_CF_START - 4
    Public Const ERR_CF_AFMAST_OVER_TRADELIMIT = ERR_CF_START - 5
    Public Const ERR_CF_AFMAST_OVER_MARGINLIMIT = ERR_CF_START - 6
    Public Const ERR_CF_AFMAST_OVER_ADVANCELIMIT = ERR_CF_START - 7
    Public Const ERR_CF_AFMAST_OVER_REPOLIMIT = ERR_CF_START - 8
    Public Const ERR_CF_AFMAST_OVER_DEPOSITLIMIT = ERR_CF_START - 9
    Public Const ERR_CF_AFMAST_STATUS_INVALID = ERR_CF_START - 10
    Public Const ERR_CF_CUSTOM_NOTFOUND = ERR_CF_START - 2
    Public Const ERR_CF_ACTYPE_HAS_CONTRACT = ERR_CF_START - 11
    Public Const ERR_CF_AFMAST_NOTFOUND = ERR_CF_START - 12
    Public Const ERR_CF_AFMAST_STATUS_INVALIDE = ERR_CF_START - 13
    Public Const ERR_CF_CONTRACT_HAS_TRANSACTION = ERR_CF_START - 14
    Public Const ERR_CF_ACTYPE_HAS_CONSTRAINTS = ERR_CF_START - 15
    Public Const ERR_CF_AFMAST_RISKOVER_AFTYPE = ERR_CF_START - 16
    Public Const ERR_CF_CAREBY_NOT_EXIT = ERR_CF_START - 17
    Public Const ERR_CF_CUSTID_CONSTRAINTS = ERR_CF_START - 18
    Public Const ERR_CF_CUSTODYCD_DUPLICATED = ERR_CF_START - 19
    Public Const ERR_CF_IDTYPE_DUPLICATED = ERR_CF_START - 20
    Public Const ERR_CF_SE_NOT_EXIT = ERR_CF_START - 21
    Public Const ERR_CF_CI_NOT_EXIT = ERR_CF_START - 22
    Public Const ERR_CF_CFLINK_CUSTID_NOTFOUND = ERR_CF_START - 23
    Public Const ERR_CF_CFAUTH_CUSTID_NOTFOUND = ERR_CF_START - 24
    Public Const ERR_CF_AFMAST_TRADERATE_OVER_AFTYPE = ERR_CF_START - 25
    Public Const ERR_CF_AFMAST_DEPORATE_OVER_AFTYPE = ERR_CF_START - 26
    Public Const ERR_CF_AFMAST_MISCRATE_OVER_AFTYPE = ERR_CF_START - 27
    Public Const ERR_CF_OVER_MARGINLIMIT = ERR_CF_START - 28
    Public Const ERR_CF_OVER_TRADELIMIT = ERR_CF_START - 29
    Public Const ERR_CF_OVER_ADVANCELIMIT = ERR_CF_START - 30
    Public Const ERR_CF_OVER_REPOLIMIT = ERR_CF_START - 31
    Public Const ERR_CF_OVER_DEPOSITLIMIT = ERR_CF_START - 32
    Public Const ERR_CF_CANNOT_CLOSE = ERR_CF_START - 33
    Public Const ERR_CF_RECUSTID_NOTFOUND = ERR_CF_START - 34
    Public Const ERR_CF_CUSTID_DUPLICATED = ERR_CF_START - 35
    Public Const ERR_CF_CUSTID_INVALID = ERR_CF_START - 36
    Public Const ERR_CF_INTERNATION_NOTEMPTY = ERR_CF_START - 37
    Public Const ERR_CF_TRADEPHONE_ISNOTEMPTY = ERR_CF_START - 38
    Public Const ERR_CF_CURRDATE_SMALLER_THAN_BIRTHDATE = ERR_CF_START - 39
    Public Const ERR_CF_IDEXPIRED_SMALLER_THAN_CURRDATE = ERR_CF_START - 40
    Public Const ERR_CF_OVER_TRADELINE = ERR_CF_START - 41
    Public Const ERR_CF_TAXCODE_ISNOT_NULL = ERR_CF_START - 42
    Public Const ERR_CF_CURRDATE_SMALLER_THAN_VALDATE = ERR_CF_START - 43
    Public Const ERR_CF_CURRDATE_SMALLER_THAN_EXPDATE = ERR_CF_START - 44
    Public Const ERR_INVALID_CFMAST_STATUS = ERR_CF_START - 45
    Public Const ERR_CF_PIN_ISNOT_NULL = ERR_CF_START - 46
    Public Const ERR_CF_ACCTNO_DUPLICATE = ERR_CF_START - 48
    Public Const ERR_CF_ACCTNO_INVALID = ERR_CF_START - 49
    Public Const ERR_CF_NOT_CAREBY = ERR_CF_START - 50
    Public Const ERR_CF_RPTID_CYCLE_DUPLICATE = ERR_CF_START - 51
    Public Const ERR_CF_RPTID_NOTFOUND = ERR_CF_START - 52
    Public Const ERR_CF_PIN_DIFFRENCE = ERR_CF_START - 53
    Public Const ERR_CF_REGTYPE_DUPLICATE = ERR_CF_START - 54
    Public Const ERR_CF_CANNOT_ACTIVE = ERR_CF_START - 55
    Public Const ERR_CF_CUSTOMER_NOTBANKING = ERR_CF_START - 56
    Public Const ERR_CF_REGTYPE_INVALID = ERR_CF_START - 57
    Public Const ERR_CF_RELATION_DUPLICATE = ERR_CF_START - 58
    Public Const ERR_CF_IDCOE_DUPLICATE = ERR_CF_START - 59
    Public Const ERR_CF_EXAFMAST_DUPLICATED = ERR_CF_START - 60
    Public Const ERR_CF_EXAFSCHD_DUPLICATED = ERR_CF_START - 61
    Public Const ERR_CF_EVENTCODE_INVALID = ERR_CF_START - 62
    Public Const ERR_CF_HAS_IN_STSCHD = ERR_CF_START - 63
    Public Const ERR_CF_SENDDEPOSIT = ERR_CF_START - 64
    Public Const ERR_CI_AFTYPE_IS_NOT_CORRCECT = ERR_CF_START - 65
    Public Const ERR_CF_USERNAME_DUPLICATE = ERR_CF_START - 66
    Public Const ERR_CF_CFAUTH_CUSTID_EXISTED = ERR_CF_START - 67
    Public Const ERR_CF_AFMAST_MRSTYPE_INVALID = ERR_CF_START - 68 'Margin type does not permit of this transaction.
    Public Const ERR_CF_CFMAST_STATUS_INVALID = ERR_CF_START - 69
    Public Const ERR_CF_ACCOUNT_MARGIN_TERM_HAS_DUE = ERR_CF_START - 70
    Public Const ERR_CF_ADVANCELINE_NOT_ENOUGHT = ERR_CF_START - 71
    Public Const ERR_CF_USER_LIMIT_GREATER_ZERO = ERR_CF_START - 72
    Public Const ERR_CF_USER_LIMIT_GREATER_USEDLIMIT = ERR_CF_START - 73
    Public Const ERR_CF_USER_NOT_ACTIVE = ERR_CF_START - 74
    Public Const ERR_CF_ACCOUNT_LIMIT_GREATER_USEDLIMIT = ERR_CF_START - 75
    Public Const ERR_CF_ACCOUNT_LIMIT_SMALLER_THAN_ZERO = ERR_CF_START - 76
    Public Const ERR_CF_USER_BD_ALREADY_ALLOCATE_LIMIT = ERR_CF_START - 77
    Public Const ERR_CF_USER_BO_ALREADY_ALLOCATE_LIMIT = ERR_CF_START - 78
    Public Const ERR_CF_T0_USER_LIMIT_GREATER_ZERO = ERR_CF_START - 79
    Public Const ERR_CF_T0_MAX_SMALLER_THAN_ZERO = ERR_CF_START - 80
    Public Const ERR_CF_CANNOT_DELETE_SIGN = ERR_CF_START - 81
    Public Const ERR_AF_ACCTNO_ISNUMBERIC = ERR_CF_START - 82
    Public Const ERR_AF_ACCTNO_NOTBELONGBRANCH = ERR_CF_START - 83
    Public Const ERR_AF_COMPANY_ACCTNO_NOTFOUND = ERR_CF_START - 84
    Public Const ERR_AF_CANNOT_DELETE_ACTIVE_CUSTID = ERR_CF_START - 87
    Public Const ERR_CF_CUSTID_NOT_LIKE_CUSTID = ERR_CF_START - 88
    Public Const ERR_CF_CFMAST_MOBILE_NOTFOUND = ERR_CF_START - 89
    Public Const ERR_CF_CFMAST_NOT_ENOUGH_AGE = ERR_CF_START - 90

    Public Const ERR_CF_USER_NOT_IN_CAREBY = ERR_CF_START - 90 'Dien 18-10-2010
    Public Const ERR_EXITS_USER = ERR_CF_START - 91 'Dien 18-10-2010 
    Public Const ERR_CF_SE_NOT_APPROVE = ERR_CF_START - 92
    Public Const ERR_CF_CI_NOT_APPROVE = ERR_CF_START - 93
    Public Const ERR_CF_MR_NOT_APPROVE = ERR_CF_START - 94
    Public Const ERR_CF_LN_NOT_APPROVE = ERR_CF_START - 95
    Public Const ERR_CF_DF_NOT_APPROVE = ERR_CF_START - 96
    Public Const ERR_CF_AD_NOT_APPROVE = ERR_CF_START - 101
    Public Const ERR_CF_AFTYPE_MISS_OTHERSTYPE = ERR_CF_START - 97
    Public Const ERR_CF_CFSIGN_DUPLICATE = ERR_CF_START - 98
    Public Const ERR_CF_AFMAST_NOTSIGNONLINE = ERR_CF_START - 99
    Public Const ERR_CF_ONLINENOTHAVERIGHT = ERR_CF_START - 102
    Public Const ERR_CF_USER_ALREADY_MASTER = ERR_CF_START - 103
    Public Const ERR_CF_CFMAST_STATUS_NOTVALID = ERR_CF_START - 104
    Public Const ERR_CF_MASTERSTATUS_NOTCHANGED = ERR_CF_START - 105
    Public Const ERR_CF_DO_NOT_DELETE_CFSIGNATURE = ERR_CF_START - 112


    Public Const ERR_CF_AFMAST_MRCRLIMIT_NOT_ENOUGH = ERR_CF_START - 200
    Public Const ERR_CF_ETS_DUPLICATED = ERR_CF_START - 201
    Public Const ERR_ACTYPE_NOT_APPROVED = ERR_CF_START - 202

    Public Const ERR_CF_CUSTODYCD_DUPLICATE = ERR_CF_START - 203
    Public Const ERR_ACTYPE_EXIST_MRTYPE = ERR_CF_START - 204
    Public Const ERR_CF_AFMAST_GROUPLEADER_NOTFOUNDED = ERR_CF_START - 204
    Public Const ERR_CF_AFMAST_GROUPLEADER_NOTMATCHED = ERR_CF_START - 205

    Public Const ERR_CF_CUSTODYCD_ALREADY_MAP2AFMAST = ERR_CF_START - 206
    Public Const ERR_CF_CUSTODYCD_REGISTERED_AFTYPSUBCD = ERR_CF_START - 207
    Public Const ERR_CF_CUSTODYCD_REGISTERED_TYPESUBCD = ERR_CF_START - 208
    Public Const ERR_CF_CUSTODYCD_REGISTERED = ERR_CF_START - 209
    Public Const ERR_CF_ALREADY_HAS_INUSED_AFMAST = ERR_CF_START - 210
    Public Const ERR_CF_AFTYPE_CANNOT_CHANGE = ERR_CF_START - 301
    Public Const ERR_CF_BANK_HASNOT_LIMIT = ERR_CF_START - 302
    Public Const ERR_CF_BANK_LMTYP_NOT_EXISTS = ERR_CF_START - 303
    Public Const ERR_CF_OTRIGHT_DUPLICATE = ERR_CF_START - 304
    Public Const ERR_CF_MARGIN_CL_AUTOADV_EQUAL_Y = ERR_CF_START - 305
    Public Const ERR_CF_OTRIGHT_ALL = ERR_CF_START - 307 '2.1.3.0|iss 1594
    Public Const ERR_CF_OTRIGHT_ALL_NOT_NumSig = ERR_CF_START - 308 '2.1.3.0|iss 1594
    Public Const ERR_CF_OTRIGHT_VIA_NOT_OTHER = ERR_CF_START - 309 '2.1.3.0|iss 1594
    Public Const ERR_CF_OTRIGHT_ONL_AUTHTYPE = ERR_CF_START - 310 '2.1.3.0|iss 1594
    Public Const ERR_CF_AFMAST_INVALID_STATUS = ERR_CF_START - 407
    Public Const ERR_CF_ONLINE_SERVICES_NOTFOUND = ERR_CF_START - 400
    Public Const ERR_CF_AFTYPE_ISTRFBUY_NOT_ALLOW = ERR_CF_START - 411
    Public Const ERR_CF_AFTYPE_ISTRFBUY_EXT_MUST_GREATERTHAN_ZERO = ERR_CF_START - 412
    Public Const ERR_CF_CFAFTRDLNK_AFACCTNO_DUPLICATED = ERR_CF_START - 417
    Public Const ERR_CF_DUPLICAT_REGISTTYPE = ERR_CF_START - 418


    'PhÃ¢n há»‡ CA
    Public Const ERR_CA_START = ERR_SYSTEM_OK - 300000
    Public Const ERR_CA_BDS_HAS_CHILD = ERR_CA_START - 1
    Public Const ERR_CA_CODEID_NOTFOUND = ERR_CA_START - 2
    Public Const ERR_CA_AUTOID_HAS_CONSTRAINT = ERR_CA_START - 3
    Public Const ERR_CA_CAMASTID_HAS_CONSTRAINT = ERR_CA_START - 4
    Public Const ERR_CA_CAMASTID_ALREADY_SEND_OR_COMPLETE = ERR_CA_START - 5
    Public Const ERR_CA_CAMASTID_DUPLICATE = ERR_CA_START - 6
    Public Const ERR_CA_CAMASTID_INVALIDSTATUS = ERR_CA_START - 10
    Public Const ERR_CA_CAMASTID_ALREADY_CREDITACCOUNT = ERR_CA_START - 11
    Public Const ERR_CA_CASCHD_ALREADY_EXECUTED = ERR_CA_START - 12
    Public Const ERR_CAMAST_STATUS_INVALID = ERR_CA_START - 13
    Public Const ERR_CASCHD_STATUS_INVALID = ERR_CA_START - 14
    Public Const ERR_REPORTDATE_INVALID = ERR_CA_START - 15
    Public Const ERR_ACTIONDATE_INVALID = ERR_CA_START - 16
    Public Const ERR_ACTIONDATE_IS_BUSDATE = ERR_CA_START - 17
    Public Const ERR_CA_TXDATE_INVALID = ERR_CA_START - 18
    Public Const ERR_CA_CANNOT_RETAIL = ERR_CA_START - 19
    Public Const ERR_CA_CANNOT_TRANSFER = ERR_CA_START - 20
    Public Const ERR_CA_QTTY_TRANSFER = ERR_CA_START - 21
    Public Const ERR_CF_AFMAST_NOTIN_CASCHD = ERR_CA_START - 22
    Public Const ERR_CA_NOTIN_STOCK_RIGHT_OFF = ERR_CA_START - 23
    Public Const ERR_CA_SEMAST_NOTFOUND = ERR_CA_START - 24
    Public Const ERR_OD_CODEID_HALT = ERR_CA_START - 25
    Public Const ERR_CA_CAQTTY_SMALLER = ERR_CA_START - 26
    Public Const ERR_CA_CODEID_CANNOT_EXECUTE = ERR_CA_START - 27
    Public Const ERR_CA_BOND_PAY_INTEREST_MUSTBE_FINISHED = ERR_CA_START - 28
    Public Const ERR_CA_DATE_CANNOT_EXECUTE = ERR_CA_START - 29
    Public Const ERR_CA_CASCHD_OVER_CANCELREGISTER_QTTY = ERR_CA_START - 30
    Public Const ERR_CA_DATE_OUTOF_REGISTER = ERR_CA_START - 31
    Public Const ERR_NumberNotIn_1_100 = ERR_CA_START - 32 ' Dien
    Public Const ERR_NotExchangePitrateWhenNotSC = ERR_CA_START - 33 'Dien
    Public Const ERR_CA_CANNOT_ENOUGH_QTTY_TO_ROLLBACK = ERR_CA_START - 34
    Public Const ERR_TRADEDATE_IS_BUSDATE = ERR_CA_START - 35
    Public Const ERR_TRADEDATE_CURRDATE = ERR_CA_START - 36
    Public Const ERR_CA_CHOOSE_DOUBLE_DEVIDENT_TYPE = ERR_CA_START - 37
    Public Const ERR_CA_INVALID_SPLITRATE = ERR_CA_START - 38
    Public Const ERR_CA_INVALID_SPLITRATE_2 = ERR_CA_START - 39
    Public Const ERR_SA_OPT_SYMBOL_DUPLICATED = ERR_CA_START - 40
    Public Const ERR_CA_VOTECODE_DUPLICATED = ERR_CA_START - 54
    Public Const ERR_CA_ISINCODE_INVALID = ERR_CA_START - 75 'Thoai
    'Nga khai them
    Public Const ERR_ACTIONDATERETAIL_IS_BUSDATE = ERR_CA_START - 18
    Public Const ERR_CA_CODEID_INVALID = ERR_CA_START - 41
    Public Const ERR_CA_MUST_CHOOSE_ONE_DEVIDENT_TYPE = ERR_CA_START - 42
    Public Const ERR_CA_REPORTDATE_MUSTBE_SMALLER_THAN_ACTIONDATE = ERR_CA_START - 60
    Public Const ERR_CA_TODATETRANSFER_CANT_GREATER_THAN_ACTIONDATE = ERR_CA_START - 61
    Public Const ERR_CA_DUEDATE_CANT_GREATER_THAN_ACTIONDATE = ERR_CA_START - 62
    Public Const ERR_CA_ONLY_APPRVID_CAN_DEL = ERR_CA_START - 69
    'PhÃ¢n há»‡ CI
    Public Const ERR_CI_START = ERR_SYSTEM_OK - 400000
    Public Const ERR_CI_AFTYPE_NOTFOUND = ERR_CI_START - 1
    Public Const ERR_CI_CIMAST_ALREADY_EXIST = ERR_CI_START - 2
    Public Const ERR_CI_CIMAST_NOTFOUND = ERR_CI_START - 3
    Public Const ERR_CI_CIMAST_STATUS_INVALID = ERR_CI_START - 4
    Public Const ERR_CI_CIMAST_BALANCE_NOTENOUGHT = ERR_CI_START - 5
    Public Const ERR_CI_CIMAST_CRINTACR_NOTENOUGHT = ERR_CI_START - 6
    Public Const ERR_CI_CIMAST_ODINTACR_NOTENOUGHT = ERR_CI_START - 7
    Public Const ERR_CI_CIMAST_RAMT_NOTENOUGHT = ERR_CI_START - 8
    Public Const ERR_CI_CITYPE_ACTYPE_DUPLICATED = ERR_CI_START - 9
    Public Const ERR_CI_CITYPE_CCYCD_NOTFOUND = ERR_CI_START - 10
    Public Const ERR_CI_CITYPE_GLGRP_NOTFOUND = ERR_CI_START - 11
    Public Const ERR_CI_CITYPE_ACTYPE_HAS_CONSTRAINT = ERR_CI_START - 12
    Public Const ERR_CI_ACCTNO_DUPLICATED = ERR_CI_START - 13
    Public Const ERR_CI_AFACCTNO_NOTFOUND = ERR_CI_START - 14
    Public Const ERR_CI_CIMAST_ACCTNO_HAS_CONSTRAINT = ERR_CI_START - 16
    Public Const ERR_CI_CITYPE_GLBANK_NOTFOUND = ERR_CI_START - 17
    Public Const ERR_CI_CIMAST_ACCTNO_DUPLICATED = ERR_CI_START - 18
    Public Const ERR_CI_CIMAST_ACTYPE_NOTFOUND = ERR_CI_START - 19
    Public Const ERR_CI_CIMAST_CCYCD_NOTFOUND = ERR_CI_START - 20
    Public Const ERR_CI_CIMAST_AFACCTNO_NOTFOUND = ERR_CI_START - 21
    Public Const ERR_CI_REMITTANCE_CLOSE = ERR_CI_START - 22
    Public Const ERR_CI_BALANCE_NEGATIVE = ERR_CI_START - 23
    Public Const ERR_CI_RM = ERR_CI_START - 24
    Public Const ERR_CI_RS = ERR_CI_START - 25
    Public Const ERR_CI_CASCHD = ERR_CI_START - 26
    Public Const ERR_CI_AAMT = ERR_CI_START - 27
    Public Const ERR_CI_RAMT = ERR_CI_START - 28
    Public Const ERR_CI_BAMT = ERR_CI_START - 29
    Public Const ERR_CI_NAMT = ERR_CI_START - 30
    Public Const ERR_CI_EMKAMT = ERR_CI_START - 31
    Public Const ERR_CI_MMARGINBAL = ERR_CI_START - 32
    Public Const ERR_CI_MARGINBAL = ERR_CI_START - 33
    Public Const ERR_CI_EXIST = ERR_CI_START - 34
    Public Const ERR_CI_MBLOCK = ERR_CI_START - 36
    Public Const gc_OD_CI_HAS_RECEIVE = ERR_CI_START - 37
    Public Const gc_OD_CI_1100_IS_NOT_COMPLETE = ERR_CI_START - 38
    Public Const ERR_CI_BALANCE = ERR_CI_START - 39
    Public Const ERR_CI_HOLDBALANCE = ERR_CI_START - 40
    Public Const ERR_CI_PENDINGHOLDBALANCE = ERR_CI_START - 41
    Public Const ERR_CI_PENDINGUNHOLDBALANCE = ERR_CI_START - 42
    Public Const ERR_CI_CRINTACR_REMAIN = ERR_CI_START - 43
    Public Const ERR_CI_ODINTACR_REMAIN = ERR_CI_START - 44
    Public Const ERR_CI_ODAMT_REMAIN = ERR_CI_START - 45
    Public Const ERR_CI_REFNUM_DUPLICATED = ERR_CI_START - 46
    Public Const ERR_CI_OTCACCOUNT_NOT_REGISTERED = ERR_CI_START - 100
    Public Const ERR_CI_OVER_ADVANCE_AMOUNT = ERR_CI_START - 101
    Public Const ERR_CI_BALDEFOVD_NOT_ENOUGH = ERR_CI_START - 110
    Public Const ERR_CI_PP_NOT_ENOUGH_TO_BUY = ERR_CI_START - 116
    Public Const ERR_CI_AVL_NOT_ENOUGH_TO_BUY = ERR_CI_START - 117
    Public Const ERR_CI_OVER_PAID_FOR_DEAL = ERR_CI_START - 120
    Public Const ERR_CI_INVALID_SELLDEAL = ERR_CI_START - 121
    Public Const ERR_CI_CASHTRANSFERACC_NOT_REGISTED = ERR_CI_START - 122

    'Phan he DD
    Public Const ERR_DD_START = ERR_SYSTEM_OK - 130000
    Public Const ERR_DD_DELETE_APPROVED_ACCOUNT = ERR_DD_START - 7
    Public Const ERR_DD_DDTYPE_ACTYPE_DUPLICATED = ERR_DD_START - 9
    Public Const ERR_DD_DDTYPE_CCYCD_NOTFOUND = ERR_DD_START - 10
    Public Const ERR_DD_DDTYPE_GLBANK_NOTFOUND = ERR_DD_START - 17
    Public Const ERR_DD_DDTYPE_ACTYPE_HAS_CONSTRAINT = ERR_DD_START - 12
    Public Const ERR_DD_DDTYPE_GLGRP_NOTEXITS = ERR_DD_START - 8
    Public Const ERR_DD_ACCBANK_DUPLICATE = ERR_DD_START - 11
    Public Const ERR_DD_ACCBANK_ISDEFAULT_DUPLICATE = ERR_DD_START - 13
    Public Const ERR_DD_ACCBANK_ISDEFAULT_CHANGE = ERR_DD_START - 14


    'phan he GL
    Public Const ERR_GL_START = ERR_SYSTEM_OK - 500000
    Public Const gc_ERRCODE_GL_ACCTNO_DUPLICATED = ERR_GL_START - 1
    Public Const gc_ERRCODE_GL_BDS_HAS_CHILD = ERR_GL_START - 2
    Public Const gc_ERRCODE_GL_GLBANK_DUPLICATED = ERR_GL_START - 3
    Public Const gc_ERRCODE_GL_ACCTNO_DOESNOTEXIST = ERR_GL_START - 4
    Public Const gc_ERRCODE_GL_ACCTENTRY_DOESNOTBALANCE = ERR_GL_START - 5
    Public Const gc_ERRCODE_GL_ACCTENTRY_OFFBALANCESHEET = ERR_GL_START - 6
    Public Const gc_ERRCODE_GL_ACCTENTRY_NOTSAMECCYCD = ERR_GL_START - 7
    Public Const ERR_GL_GLBANK_CONSTRAINTS = ERR_GL_START - 8
    Public Const gc_ERRCODE_GL_INVALID_BALANCETYPE = ERR_GL_START - 9
    Public Const gc_ERRCODE_GL_DRGLEXP_ACCTNO_DOESNOTEXIST = ERR_GL_START - 10
    Public Const gc_ERRCODE_GL_CRGLDEPR_ACCTNO_DOESNOTEXIST = ERR_GL_START - 11
    Public Const ERR_GL_BKDATE_IN_HOLIDAY = ERR_GL_START - 12
    Public Const gc_ERRCODE_GL_ACCTENTRY_NOTSAME_BRID = ERR_GL_START - 13
    Public Const gc_ERRCODE_GL_GLBANK_LENGTH = ERR_GL_START - 14
    Public Const gc_ERRCODE_GL_SUBCD2_LENGTH = ERR_GL_START - 15
    Public Const gc_ERRCODE_GL_ACCTNO_DUPLICATE = ERR_GL_START - 16

    '''PhÃ¢n há»‡ LN
    'Public Const ERR_LN_START = ERR_SYSTEM_OK - 600000
    'Public Const ERR_LN_IRRATEID_DUPLICATED = ERR_LN_START - 1
    'Public Const ERR_LN_CCYCD_NOTFOUND = ERR_LN_START - 3
    'Public Const ERR_LN_RATEID_CONSTRAINTS = ERR_LN_START - 4
    'Public Const ERR_LN_ACTYPE_DUPLICATED = ERR_LN_START - 5
    'Public Const ERR_LN_GLGRP_NOTFOUND = ERR_LN_START - 6
    'Public Const ERR_LN_GLBANK_NOTFOUND = ERR_LN_START - 7
    'Public Const ERR_LN_ACTYPE_CONSTRAINTS = ERR_LN_START - 8


    '=================================================================================================================
    'Tin dung
    Public Const ERR_LM_START = ERR_SYSTEM_OK - 520000  'Reserved first 100 error code for APPCHK
    Public Const ERR_LM_OVER_APPROVALLIMIT = ERR_LM_START - 101
    Public Const ERR_LM_OVER_GRANTEDLIMIT = ERR_LM_START - 102
    Public Const ERR_LM_SECURE_NOT_ENOUGH = ERR_LM_START - 2
    Public Const ERR_LM_DELTA_INVALID = ERR_LM_START - 7
    Public Const ERR_LM_LMACCTNO_BE_USED = ERR_LM_START - 8

    Public Const ERR_CL_START = ERR_SYSTEM_OK - 530000
    Public Const ERR_CL_NOT_ENOUGH_SECUREDAMT = ERR_CL_START - 3
    Public Const ERR_CL_SECUREDAMT_OVER_CLAMT = ERR_CL_START - 8
    Public Const ERR_CL_OVER_MORTAGED_AMT = ERR_CL_START - 9

    Public Const ERR_LN_START = ERR_SYSTEM_OK - 540000
    Public Const ERR_LN_IRRATEID_DUPLICATED = ERR_LN_START - 101
    Public Const ERR_LN_CCYCD_NOTFOUND = ERR_LN_START - 103
    Public Const ERR_LN_RATEID_CONSTRAINTS = ERR_LN_START - 104
    Public Const ERR_LN_ACTYPE_DUPLICATED = ERR_LN_START - 105
    Public Const ERR_LN_GLGRP_NOTFOUND = ERR_LN_START - 106
    Public Const ERR_LN_GLBANK_NOTFOUND = ERR_LN_START - 107
    Public Const ERR_LN_ACTYPE_CONSTRAINTS = ERR_LN_START - 108
    Public Const ERR_LN_APPLICATION_NOTFOUND = ERR_LN_START - 109
    Public Const ERR_LN_APPL_OVERLIMIT = ERR_LN_START - 110
    Public Const ERR_LN_RATEID_EMPTY = ERR_LN_START - 111
    Public Const ERR_LN_TRFACCTNO_EMPTY = ERR_LN_START - 112
    Public Const ERR_LN_PRINFRQCD_LESS_INTFRQCD = ERR_LN_START - 113
    Public Const ERR_LN_INTFRQCD_INVALID = ERR_LN_START - 114
    Public Const ERR_LN_MUST_AUTOPAY = ERR_LN_START - 115
    Public Const ERR_LN_CUSTID_NOT_SAME = ERR_LN_START - 116
    Public Const ERR_LN_LNMAST_LNTYPE_NOT_SAME = ERR_LN_START - 117
    Public Const ERR_LN_LNMAST_OVER_ALLOWED_NUMBER_LNMAST = ERR_LN_START - 118
    Public Const ERR_LN_LNSCHD_DUEDATE_DUPLICATED = ERR_LN_START - 119
    Public Const ERR_LN_LNSCHD_DUEDATE_INVALID = ERR_LN_START - 200
    Public Const ERR_LN_LNMAST_NOT_FIXLOAN = ERR_LN_START - 201
    Public Const ERR_LN_LNSCHD_DUEDATE_HOLIDAY = ERR_LN_START - 202
    Public Const ERR_LN_LNSCHD_CANNOT_DELETE = ERR_LN_START - 203
    Public Const ERR_LN_LNMAST_OVER_EXPDT_LNAPPL = ERR_LN_START - 204
    Public Const ERR_LN_INTFRQCD_NOT_IMMEDIATELY = ERR_LN_START - 205
    Public Const ERR_LN_LNMAST_FIRSTDT_OVER_EXPDT_LNAPPL = ERR_LN_START - 206
    Public Const ERR_LN_LNMAST_FIRSTDT_OVER_ENDDATE_LNMAST = ERR_LN_START - 207
    Public Const ERR_LN_LNMAST_REMAINING_DEBT = ERR_LN_START - 208
    Public Const ERR_LN_LNMAST_NOT_FOUND = ERR_LN_START - 209
    Public Const ERR_LN_OVER_AVAILABLE_LIMIT = ERR_LN_START - 210
    Public Const ERR_LN_ACTYPE_NOT_FOUND = ERR_LN_START - 211
    Public Const ERR_LN_CHECKWORKINGDATE = ERR_LN_START - 212
    Public Const ERR_TXDATE_LN_NULL = ERR_LN_START - 213
    Public Const ERR_LN_OVERDUEDATE = ERR_LN_START - 214
    Public Const ERR_LN_ACCOUNT_NOT_IN_SAME_MRGROUP = ERR_LN_START - 215
    Public Const ERR_LN_ACCOUNT_NOT_IN_MRGROUP = ERR_LN_START - 216
    Public Const ERR_DF_EXIST_DFDEAL_OPTION = ERR_LN_START - 222
    Public Const ERR_LN_NOT_ALLOW_CHANGE_RRTYPE = ERR_LN_START - 223
    Public Const ERR_LN_LNTYPE_RRTYPE_B_CUSTBANK_NOT_ALLOW_CHANGE = ERR_LN_START - 224



    Public Const ERR_GR_START = ERR_SYSTEM_OK - 580000
    Public Const ERR_LA_START = ERR_SYSTEM_OK - 550000
    Public Const ERR_SD_START = ERR_SYSTEM_OK - 560000
    Public Const ERR_TD_START = ERR_SYSTEM_OK - 570000
    Public Const ERR_TD_SERIENO_DUPLICATE = ERR_TD_START - 101
    Public Const ERR_TD_SERIENO_ALREAY_COLLECTED = ERR_TD_START - 102
    Public Const ERR_TD_TDBOOK_DUPLICATE = ERR_TD_START - 103
    'Phan he TD
    Public Const ERR_TD_SCHEMA_DUPLICATED = ERR_TD_START - 1
    Public Const ERR_TD_ACTYPE_NOTFOUND = ERR_TD_START - 2
    Public Const ERR_TD_UNDER_MINIMUM_AMOUNT = ERR_TD_START - 3
    Public Const ERR_TD_OVER_MORTGAGE_BYAFACCTNO = ERR_TD_START - 7
    Public Const ERR_TD_OVER_MORTGAGE_AVAILABLE = ERR_TD_START - 10
    Public Const ERR_TD_CURRENT_TERM_LESS_THAN_MIN_BREAKTERM = ERR_TD_START - 11
    Public Const ERR_TD_CANT_CHANGE_BUYINGPOWER_TO_YES = ERR_TD_START - 13
    '=================================================================================================================



    'PhÃ¢n há»‡ OD
    Public Const ERR_OD_START = ERR_SYSTEM_OK - 700000
    Public Const ERR_OD_ODTYPE_NOTFOUND = ERR_OD_START - 3
    Public Const ERR_OD_SEND_ALREADY = ERR_OD_START - 4
    Public Const ERR_OD_BUYSELL_SAMESECURITIES = ERR_OD_START - 5
    Public Const ERR_OD_SENT_DOESNOTEXIST = ERR_OD_START - 6
    Public Const ERR_OD_ODTYPE_ACTYPE_DUPLICATED = ERR_OD_START - 7
    Public Const ERR_OD_ODTYPE_GLGRP_NOTFOUND = ERR_OD_START - 8
    Public Const ERR_OD_ODTYPE_ACTYPE_HAS_CONSTRAINT = ERR_OD_START - 9
    Public Const ERR_OD_SECURITIES_INFO_UNDEFINED = ERR_OD_START - 10
    Public Const ERR_OD_QTTY_TRADELOT_INCORRECT = ERR_OD_START - 11
    Public Const ERR_OD_LO_PRICE_ISNOT_FLOOR_CEILLING = ERR_OD_START - 12
    Public Const ERR_OD_TICKSIZE_UNDEFINED = ERR_OD_START - 13
    Public Const ERR_OD_TICKSIZE_INCOMPLIANT = ERR_OD_START - 14
    Public Const ERR_OD_BUYSELL_SAME_SECURITIES = ERR_OD_START - 15
    Public Const ERR_OD_STSCHD_ADVANCED_PAYMENT_ALREADY = ERR_OD_START - 16
    Public Const ERR_OD_STSCHD_IS_CLOSED = ERR_OD_START - 17
    Public Const ERR_OD_INVALID_CANCELQTTY = ERR_OD_START - 18
    Public Const ERR_OD_INVALID_CANCELAMT = ERR_OD_START - 19
    Public Const ERR_OD_STSCHD_NOTFOUND = ERR_OD_START - 20
    Public Const ERR_OD_STSCHD_STATUSINVALID = ERR_OD_START - 21
    Public Const ERR_OD_ODMAST_CANNOT_DELETE = ERR_OD_START - 22
    Public Const ERR_OD_LISTED_NEEDCUSTODYCD = ERR_OD_START - 23
    Public Const ERR_OD_ORDERID_NOTDOUND = ERR_OD_START - 24
    Public Const ERR_OOD_STATUS_INVALID = ERR_OD_START - 25
    Public Const ERR_OOD_STATUS_IS_BLOCKED = ERR_OD_START - 26
    Public Const ERR_OOD_STATUS_IS_SENT = ERR_OD_START - 27
    Public Const ERR_OD_INVALID_QTTY = ERR_OD_START - 28
    Public Const ERR_OD_INVALID_FEEAMT = ERR_OD_START - 29
    Public Const ERR_OD_ORDER_SENDING = ERR_OD_START - 30
    Public Const ERR_OD_ORDER_CANCELLED = ERR_OD_START - 31
    Public Const ERR_OD_ATO_ORDER_IN_LISTTING_DATE = ERR_OD_START - 35
    Public Const ERR_OD_ORDER_OVER_NUMBER_CORRECTION = ERR_OD_START - 36
    Public Const ERR_OD_ORDER_NOT_FOUND = ERR_OD_START - 37
    Public Const ERR_OD_ERROR_OVER_QTTY = ERR_OD_START - 38
    Public Const ERR_OD_ERROR_ADV_CANCELED = ERR_OD_START - 39
    Public Const ERR_OD_ERROR_ADV_ACTIVED = ERR_OD_START - 40
    Public Const ERR_OD_ERROR_ADV_NOTFOUND = ERR_OD_START - 41
    Public Const ERR_OD_ERROR_ADV_DELETED = ERR_OD_START - 42
    Public Const ERR_OD_ERROR_ORDER_MATCHED = ERR_OD_START - 43
    Public Const ERR_OD_CANCELAMT_NOT_ENOUGHT = ERR_OD_START - 44
    Public Const ERR_OD_CANCELQTTY_NOT_ENOUGHT = ERR_OD_START - 45
    Public Const ERR_OD_ADVANCELINE_OVER_LIMIT = ERR_OD_START - 46
    Public Const ERR_OD_CANNOT_DELETE = ERR_OD_START - 47
    Public Const ERR_OD_TRADERID_NOT_INVALID = ERR_OD_START - 48
    Public Const ERROR_OD_INCORRECT_VOLUME = ERR_OD_START - 49
    Public Const ERROR_OD_INCORRECT_PRICE = ERR_OD_START - 50
    Public Const ERROR_SA_INVALID_DATA = ERR_OD_START - 500
    Public Const ERR_OD_ROOM_NOT_ENOUGH = ERR_OD_START - 51
    Public Const ERR_OD_TRADEPLACE_HOSE_NOT_AMEND = ERR_OD_START - 52
    Public Const ERR_OD_GTC_SL_NOT_AMEND = ERR_OD_START - 53
    Public Const ERR_OD_ORDER_UNDER_MIN_AMOUNT = ERR_OD_START - 55
    Public Const ERR_OD_STSCHD_ALLOCATED = ERR_OD_START - 56
    Public Const ERR_OD_CONTRA_ORDER_NOT_FOUND = ERR_OD_START - 57
    Public Const ERR_OD_ERROR_ORDER_BLOCKED = ERR_OD_START - 58 'Lenh dang duoc sent len san hoac lenh khong ton tai trong he thong
    Public Const ERR_OD_ERROR_UPCOM_CANNOT_AMEND = ERR_OD_START - 59 'Lenh Upcom thoa thuan khong cho phep huy
    Public Const ERR_OD_ERROR_UPCOM_CANCEL_BUY_FIRST = ERR_OD_START - 60 'Phai huy lenh mua Upcom truoc



    'Phan he FO
    Public Const ERR_FO_START = ERR_SYSTEM_OK - 800000
    Public Const gc_ERRCODE_FO_FOMAST_NOTFOUND = ERR_FO_START - 1
    Public Const gc_ERRCODE_FO_INVALID_STATUS = ERR_FO_START - 2
    Public Const gc_ERRCODE_FO_OVER_ORIGINAL_QTTY = ERR_FO_START - 3
    Public Const gc_ERRCODE_FO_ACTYPE_DUPLICATED = ERR_FO_START - 4
    Public Const gc_ERRCODE_FO_ACTYPE_CONTRAINTS = ERR_FO_START - 5

    'PhÃ¢n há»‡ RP
    Public Const ERR_RP_START = ERR_SYSTEM_OK - 800000
    Public Const ERR_RP_ACTYPE_DUPLICATED = ERR_RP_START - 1
    Public Const ERR_RP_ACTYPE_HAS_CONTRAINT = ERR_RP_START - 2
    Public Const ERR_RP_MAST_HAS_TRANSACTION = ERR_RP_START - 3
    Public Const ERR_RP_ACTYPE_NOTFOUND = ERR_RP_START - 4
    Public Const ERR_RP_MAST_DUPLICATED = ERR_RP_START - 5
    Public Const ERR_RP_MAST_OVERLIMIT = ERR_RP_START - 6
    Public Const ERR_RP_RPMAST_STATUS_INVALID = ERR_RP_START - 7

    'PhÃ¢n há»‡ SE
    Public Const ERR_SE_START = ERR_SYSTEM_OK - 900000
    Public Const ERR_SE_ACCTNO_DUPLICATED = ERR_SE_START - 1
    Public Const ERR_SE_ACTYPE_NOTFOUND = ERR_SE_START - 2
    Public Const ERR_SE_CCYCD_NOTFOUND = ERR_SE_START - 3
    Public Const ERR_SE_AFACCTNO_NOTFOUND = ERR_SE_START - 4
    Public Const ERR_SE_CLTYPE_NOTFOUND = ERR_SE_START - 5
    Public Const ERR_SE_CODEID_NOTFOUND = ERR_SE_START - 6
    Public Const ERR_SE_ACCTNO_CONSTRAINTS = ERR_SE_START - 7
    Public Const ERR_SE_ACTYPE_DUPLICATED = ERR_SE_START - 8
    Public Const ERR_SE_ACTYPE_CONSTRAINTS = ERR_SE_START - 9
    Public Const ERR_SE_SYMBOL_NOTFOUND = ERR_SE_START - 10
    Public Const ERR_SE_TXDATE_HAS_CONSTRAINTS = ERR_SE_START - 11
    Public Const ERR_SE_CODEID_DUPLICATE = ERR_SE_START - 12
    Public Const ERR_SE_GLGRP_NOTFOUND = ERR_SE_START - 13
    Public Const ERR_SE_SEMASTDTL_NOT_ENOUGTH = ERR_SE_START - 14
    Public Const ERR_SE_OUTRANGE_COSTPRICE_ADJUST = ERR_SE_START - 15
    Public Const ERR_SE_CANNOT_ADJUST_COSTPRICE = ERR_SE_START - 16
    Public Const ERR_SE_TRADE_NOT_ENOUGHT = ERR_SE_START - 17
    Public Const ERR_SE_CIBALANCE = ERR_SE_START - 18
    Public Const ERR_SE_STATUS = ERR_SE_START - 19
    '''
    Public Const ERR_SE_MORTAGE = ERR_SE_START - 20
    Public Const ERR_SE_MARGIN = ERR_SE_START - 21
    Public Const ERR_SE_NETTING = ERR_SE_START - 22
    Public Const ERR_SE_STANDING = ERR_SE_START - 23
    Public Const ERR_SE_SECURED = ERR_SE_START - 24
    Public Const ERR_SE_RECEIVING = ERR_SE_START - 25
    Public Const ERR_SE_WITHDRAW = ERR_SE_START - 26
    Public Const ERR_SE_DEPOSIT = ERR_SE_START - 27
    Public Const ERR_SE_LOAN = ERR_SE_START - 28
    Public Const ERR_SE_BLOCKED = ERR_SE_START - 29
    Public Const ERR_SE_REPO = ERR_SE_START - 30
    Public Const ERR_SE_PENDING = ERR_SE_START - 31
    Public Const ERR_SE_TRANSFER = ERR_SE_START - 32
    Public Const ERR_SE_SENDDEPOSIT = ERR_SE_START - 33
    Public Const ERR_SE_CONSTRAINT_2247 = ERR_SE_START - 36
    Public Const ERR_SE_EXSIT = ERR_SE_START - 38

    Public Const ERR_SE_INVALID_STATUS_SEWITHDRAWDTL = ERR_SE_START - 43
    Public Const ERR_SE_CONFIRMED_WITHDRAW = ERR_SE_START - 44
    Public Const ERR_SE_INVALID_2201_SEWITHDRAWDTL = ERR_SE_START - 45
    Public Const ERR_SE_DULICATED_STATUS_SEWITHDRAWDTL = ERR_SE_START - 46
    Public Const ERR_SE_CANNOT_DELETE_2292 = ERR_SE_START - 47
    Public Const ERR_SE_CANNOT_DELETE_2294 = ERR_SE_START - 48
    Public Const ERR_SE_CANNOT_DELETE_2251 = ERR_SE_START - 51
    Public Const ERR_SE_CANNOT_DELETE_2253 = ERR_SE_START - 52
    Public Const ERR_SE_SEMASTDTL_UNBLOCK_NOT_MATCH = ERR_SE_START - 55

    Public Const ERR_SE_SEGROUPS_AFSEGRP_CONSTRAINT = ERR_SE_START - 200
    Public Const ERR_SE_SEGROUPS_SELINK_CONSTRAINT = ERR_SE_START - 201
    Public Const ERR_SE_IS_CAWAITING = ERR_SE_START - 97
    Public Const ERR_SE_1104_REMAIN = ERR_SE_START - 98
    Public Const ERR_SE_SYMBOL_DUPLICATE = ERR_SE_START - 203
    Public Const ERR_SE_OVER_AFLIMIT = ERR_SE_START - 204

    'Phan he DF
    Public Const ERR_DF_START = ERR_SYSTEM_OK - 260000
    Public Const ERR_DF_ACTYPE_NOTFOUND = ERR_DF_START - 1
    Public Const ERR_DF_CANNOT_DRAWNDOWN = ERR_DF_START - 2
    Public Const ERR_DF_CANNOT_OPENLOAN_ACCOUNT = ERR_DF_START - 3
    Public Const ERR_DF_CANNOT_BLOCK_RECEIVE_SEC = ERR_DF_START - 4
    Public Const ERR_DF_PAID_OVER_FORDEAL = ERR_DF_START - 5
    Public Const ERR_DF_RCVQTTY_NOT_ENOUGHT = ERR_DF_START - 6
    Public Const ERR_DF_CARCVQTTY_NOT_ENOUGHT = ERR_DF_START - 7
    Public Const ERR_DF_BLOCKQTTY_NOT_ENOUGHT = ERR_DF_START - 8
    Public Const ERR_DF_STSCHD_NOT_FOUND = ERR_DF_START - 9
    Public Const ERR_DF_CASCHD_NOT_FOUND = ERR_DF_START - 10
    Public Const ERR_DF_SEMASTDTL_NOT_FOUND = ERR_DF_START - 11
    Public Const ERR_DF_NOT_ENOUGH_BAL = ERR_DF_START - 12
    Public Const ERR_DF_NOT_ENOUGH_LIMIT = ERR_DF_START - 13
    Public Const ERR_DF_NOT_ENOUGH_TOTALQTTY = ERR_DF_START - 14
    Public Const ERR_DF_DRAWNDOWN_MUSTBE_DELETE = ERR_DF_START - 15
    Public Const ERR_DF_DRAWNDOWN_CANNOT_FOUND = ERR_DF_START - 16
    Public Const ERR_DF_ACCTNO_DOESNOT_EXISTS = ERR_DF_START - 17
    Public Const ERR_DF_ACCTNO_SENTEMAIL_TRIGGER = ERR_DF_START - 19
    Public Const ERR_DF_ISDEFAULT_ONLY = ERR_DF_START - 24
    Public Const ERR_DF_LNTYPE_MUST_DRAWNDOWN_FROM_BANK = ERR_DF_START - 23

    'PhÃ¢n há»‡ SA
    Public Const gc_ERRCODE_SA_BRID_DUPLICATE = -100001
    Public Const gc_ERRCODE_SA_CANNOT_DEL_CURRENT_BDS = -100002
    Public Const gc_ERRCODE_SA_BDS_HAS_CHILD = -100003
    Public Const gc_ERRCODE_SA_BDS_HAS_TELLER = -100004
    Public Const gc_ERRCODE_SA_BDSID_DUPLICATED = -100005
    Public Const gc_ERRCODE_SA_PRBRID_NOTFOUND = -100006
    '--SA -frmDEFERROR Kienvt
    Public Const gc_ERRCODE_SA_ERRNUM_DUPLICATED = ERR_SA_START - 10
    Public Const gc_ERRCODE_SA_CCYCD_DUPLICATED = ERR_SA_START - 11
    Public Const gc_ERRCODE_SA_CMDID_DUPLICATED = ERR_SA_START - 12






    Public Const gc_ERRCODE_CF_ACTYPE_DUPLICATED = -200001
    Public Const gc_ERRCODE_CF_ACTYPE_HAS_CONTRACT = -200002

    '------Phan he OD
    Public Const gc_ERRCODE_OD_ACTYPE_DUPLICATED = ERR_OD_START - 1
    Public Const gc_ERRCODE_OD_GLGRP_NOTFOUND = ERR_OD_START - 2
    Public Const gc_ERRCODE_OD_ACTYPE_HAS_CONSTRAINT = ERR_CI_START - 3



    '------Phan he LN
    Public Const gc_ERRCODE_LN_RATEID_DUPLICATED = -300001

    '------Phan he SE
    Public Const gc_ERRCODE_SE_CODEID_DUPLICATED = -900008
    Public Const gc_ERRCODE_SE_ISSUERID_NOTFOUND = -900009
    'Public Const gc_ERRCODE_SE_ACTYPE_DUPLICATED = -900010

    '------Phan he CI
    Public Const gc_ERRCODE_CI_ACTYPE_DUPLICATED = ERR_CI_START - 2
    Public Const gc_ERRCODE_CI_CCYCD_NOTFOUND = ERR_CI_START - 3
    Public Const gc_ERRCODE_CI_GLGRP_NOTFOUND = ERR_CI_START - 4
    Public Const gc_ERRCODE_CI_ACTYPE_HAS_CONSTRAINT = ERR_CI_START - 5
    Public Const gc_ERRCODE_CI_ACCTNO_DUPLICATED = ERR_CI_START - 6
    Public Const gc_ERRCODE_CI_AFACCTNO_NOTFOUND = ERR_CI_START - 7
    Public Const gc_ERRCODE_CI_ACTYPE_NOTFOUND = ERR_CI_START - 8
    Public Const gc_ERRCODE_CI_ACCTNO_HAS_CONSTRAINT = ERR_CI_START - 9
    Public Const gc_ERRCODE_CI_GLBANK_NOTFOUND = ERR_CI_START - 10

    '--------Phan he RM
    Public Const ERR_RM_START = ERR_SYSTEM_OK - 660000
    Public Const gc_ERRCODE_RM_BANK_STATUS_INVALID = ERR_RM_START - 1
    Public Const gc_ERRCODE_RM_ACCTNO_BANK_NOTCONNECT = ERR_RM_START - 2
    Public Const gc_ERRCODE_RM_BANK_CANNOT_CONNECT = ERR_RM_START - 3
    Public Const gc_ERRCODE_RM_REVERT_STATUS = ERR_RM_START - 4
    Public Const gc_ERRCODE_RM_OFFLINEBANKACCTNO_NOT_FOUND = ERR_RM_START - 5
    Public Const gc_ERRCODE_RM_BALANCE_NOTENOUGH_TO_HOLD = ERR_RM_START - 6
    Public Const gc_ERRCODE_RM_HOLDBALANCE_NOTENOUGH_TO_UNHOLD = ERR_RM_START - 7
    Public Const gc_ERRCODE_RM_AMOUNT_NOT_NUMERIC = ERR_RM_START - 8
    Public Const gc_ERRCODE_RM_FROMDATE_INVALID = ERR_RM_START - 9
    Public Const gc_ERRCODE_RM_TODATE_INVALID = ERR_RM_START - 10
    Public Const gc_ERRCODE_RM_OFFLINEBALANCE_NOTENOUGH = ERR_RM_START - 11
    Public Const gc_ERRCODE_RM_BANKCODE_NOTFOUNDED = ERR_RM_START - 12
    Public Const gc_ERRCODE_RM_BANKSTATUS_DUPLICATE = ERR_RM_START - 13

    Public Const ERR_RM_BS_START = ERR_SYSTEM_OK - 670000
    Public Const gc_ERR_RM_BS_TRANSACTIONSUCCESS = ERR_RM_BS_START - 100 'Giao dich thanh cong
    Public Const gc_ERR_RM_BS_ACCTNO_INVALID_PERMISSION = ERR_RM_BS_START - 110 'TK khong duoc phep truy cap
    Public Const gc_ERR_RM_BS_ACCTNO_NOT_FOUNDED = ERR_RM_BS_START - 120 'Tài khoản không tồn tại
    Public Const gc_ERR_RM_BS_ACCTNO_CANNOT_HOLD1 = ERR_RM_BS_START - 121 'Tài khoản không phong t?a �được (2 entry hold)
    Public Const gc_ERR_RM_BS_ACCTNO_CANNOT_HOLD2 = ERR_RM_BS_START - 122 'Tài khoản không phong t?a �được (2 entry hold)
    Public Const gc_ERR_RM_BS_GATEWAY_TIMEOUT = ERR_RM_BS_START - 130 'Gateway timeout
    Public Const gc_ERR_RM_BS_ACCTNO_BALANCE_NOT_ENOUGH = ERR_RM_BS_START - 150 'Số dư khả dụng không đủ
    Public Const gc_ERR_RM_BS_ACCTNO_HOLDAMOUNT_NOT_ENOUGH = ERR_RM_BS_START - 160 'Số ti?n gi�ải phong t?a l�ớn hơn số ti?n phong to�ả
    Public Const gc_ERR_RM_BS_TRANSTIME_END = ERR_RM_BS_START - 170 'Hết gi? giao d�ịch (cut off time)
    Public Const gc_ERR_RM_BS_INVALID_USERPASS = ERR_RM_BS_START - 180 'User/Pass sai
    Public Const gc_ERR_RM_BS_INVALID_SCID = ERR_RM_BS_START - 190 'Sai mã CTCK
    Public Const gc_ERR_RM_BS_INVALID_DATETIME_FORMAT = ERR_RM_BS_START - 211 'Ngày tháng sai định dạng DD-MM-YYYY
    Public Const gc_ERR_RM_BS_INVALID_AMOUNT = ERR_RM_BS_START - 212 'Số ti?n �âm, sai định dạng số ti?n
    Public Const gc_ERR_RM_BS_INVALID_CHARACTER = ERR_RM_BS_START - 215 'C�ó ký tự lạ, tiếng việt có dấu
    Public Const gc_ERR_RM_BS_INVALID_CCYCD = ERR_RM_BS_START - 216 'Sai định dạng ti?n t�ệ (mặc định là VND)
    Public Const gc_ERR_RM_BS_INVALID_NOTHAVETRANSPAPER = ERR_RM_BS_START - 220 'Chưa có bảng kê đối chiếu
    Public Const gc_ERR_RM_BS_TRANSFER_PAPER_SUCCESS = ERR_RM_BS_START - 230 'Truy?n b�ảng kê thành công
    Public Const gc_ERR_RM_BS_DUPLICATE_REF = ERR_RM_BS_START - 240 'Trùng ref
    Public Const gc_ERR_RM_BS_INVALID_NEWPASS = ERR_RM_BS_START - 250 'Mật khẩu mới không hợp lệ
    Public Const gc_ERR_RM_BS_DUPLICATE_PASS = ERR_RM_BS_START - 251 'Mật khẩu mới trùng mật khẩu cũ
    Public Const gc_ERR_RM_BS_INVALID_XML_FORMAT = ERR_RM_BS_START - 999 'Sai định dạng XML
    Public Const gc_ERR_RM_BS_BATCH_WAITFORPROCCESS = ERR_RM_BS_START - 300 'Lô giao dịch ch? x�ử lý 
    Public Const gc_ERR_RM_BS_BATCH_DECRYPTED = ERR_RM_BS_START - 301 'Lô giao dịch đã giải mã
    Public Const gc_ERR_RM_BS_BATCH_PROCESSED = ERR_RM_BS_START - 310 'Lô giao dịch đã xử lý
    Public Const gc_ERR_RM_BS_BATCH_CORRECTED = ERR_RM_BS_START - 320 'Lô giao dịch đã sửa lỗi
    Public Const gc_ERR_RM_BS_BATCH_CANCELED = ERR_RM_BS_START - 330 'Lô giao dịch bị hủy
    Public Const gc_ERR_RM_BS_BATCH_ERROR = ERR_RM_BS_START - 331 'Lô giao dịch bị lỗi dữ liệu
    Public Const gc_ERR_RM_BS_BATCH_INVALID_SIGN = ERR_RM_BS_START - 332 'Lô sai chữ ký điện tử
    Public Const gc_ERR_RM_BS_BATCH_INVALID_XMLFORMAT = ERR_RM_BS_START - 333 'Lô sai định dạng XML
    Public Const gc_ERR_RM_BS_BATCH_INVALID_FORMAT = ERR_RM_BS_START - 334 'Lô sai định dạng dữ liệu
    Public Const gc_ERR_RM_BS_BATCH_DUPLICATE_BATCHID = ERR_RM_BS_START - 335 'Lô có BatchID trùng
    Public Const gc_ERR_RM_BS_BATCH_TRANSTYPE_NOT_EXISTED = ERR_RM_BS_START - 336 'Lô có loại giao dịch không tồn tại
    Public Const gc_ERR_RM_BS_BATCH_NOT_EXISTED = ERR_RM_BS_START - 337 'Lô giao dịch không tồn tại
    Public Const gc_ERR_RM_BS_BATCH_MSGID_NOTEXISTED = ERR_RM_BS_START - 338 'Lô sai dữ liệu messageid
    Public Const gc_ERR_RM_BS_BATCH_INVALID_MSGID = ERR_RM_BS_START - 339 'Lô sai scid
    Public Const gc_ERR_RM_BS_BATCH_BATCHDATE_NOT_PRESENT = ERR_RM_BS_START - 340 'Lô có ngày Batchdate không phải ngày hiện tại
    Public Const gc_ERR_RM_BS_BATCH_EFDATE_LESS_CURRDATE = ERR_RM_BS_START - 341 'Lô có ngày hiệu lực nh? h�ơn ngày hiện tại
    Public Const gc_ERR_RM_BS_BATCH_ACCTNO_NOTIN_SCID = ERR_RM_BS_START - 342 'Lô có tài khoản không thuộc CTCK
    Public Const gc_ERR_RM_BS_BATCH_TRANSCODE_DUPLICATE = ERR_RM_BS_START - 343 'Lô trùng transactioncode
    Public Const gc_ERR_RM_BS_BATCH_AMOUNT_INVALID = ERR_RM_BS_START - 344 'Lô có số ti?n �âm, hoặc sai định dạng số ti?n
    Public Const gc_ERR_RM_BS_BATCH_BATCHID_INVALID_FORMAT = ERR_RM_BS_START - 345 'L�ô có BatchID không đúng khuôn dạng
    Public Const gc_ERR_RM_BS_BATCH_CANNOT_UNZIP = ERR_RM_BS_START - 346 'Lô không giải nén được
    Public Const gc_ERR_RM_BS_BATCH_SIGNER_NOT_REGISTER = ERR_RM_BS_START - 347 'Lô có ngư?i k�ý chưa đăng ký

    Public Const ERR_CR_START = ERR_SYSTEM_OK - 670000
    Public Const ERR_CR_TRANSFER_WAITING = ERR_CR_START - 1
    Public Const ERR_CR_TRANSFER_CONFIRMING = ERR_CR_START - 2
    Public Const ERR_CR_TRANSFER_DECRYPTED = ERR_CR_START - 3
    Public Const ERR_CR_TRANSFER_CONFIRMED = ERR_CR_START - 4
    Public Const ERR_CR_TRANSFER_CORRECTED = ERR_CR_START - 5
    Public Const ERR_CR_TRANSFER_CANCELED = ERR_CR_START - 6
    Public Const ERR_CR_TRANSFER_ERROR = ERR_CR_START - 7
    Public Const ERR_CR_TRANSFER_FILENOTFOUND = ERR_CR_START - 8
    Public Const ERR_CR_TRANSFER_INVALIDSIGN = ERR_CR_START - 9
    Public Const ERR_CR_TRANSFER_INVALIDXMLFORMAT = ERR_CR_START - 10
    Public Const ERR_CR_TRANSFER_INVALIDFORMAT = ERR_CR_START - 11
    Public Const ERR_CR_TRANSFER_DUPLICATEBATCHID = ERR_CR_START - 12
    Public Const ERR_CR_TRANSFER_TRANSTYPENOTEXISTED = ERR_CR_START - 13
    Public Const ERR_CR_TRANSFER_BATCHNOTEXISTED = ERR_CR_START - 14
    Public Const ERR_CR_TRANSFER_MSGIDNOTEXISTED = ERR_CR_START - 15
    Public Const ERR_CR_TRANSFER_INVALIDMSGID = ERR_CR_START - 16
    Public Const ERR_CR_TRANSFER_BATCHDATENOTPRESENT = ERR_CR_START - 17
    Public Const ERR_CR_TRANSFER_EFDATELESSCURRDATE = ERR_CR_START - 18
    Public Const ERR_CR_TRANSFER_ACCTNONOTINSCID = ERR_CR_START - 19
    Public Const ERR_CR_TRANSFER_TRANSCODEDUPLICATE = ERR_CR_START - 20
    Public Const ERR_CR_TRANSFER_AMOUNTINVALID = ERR_CR_START - 21
    Public Const ERR_CR_TRANSFER_BATCHIDINVALIDFORMAT = ERR_CR_START - 22
    Public Const ERR_CR_TRANSFER_CANNOTUNZIP = ERR_CR_START - 23
    Public Const ERR_CR_TRANSFER_SIGNERNOTREGISTER = ERR_CR_START - 24
    Public Const ERR_CR_BANKSERVICE_NOTSUPPORT = ERR_CR_START - 25
    Public Const ERR_CR_PARAMINVALID = ERR_CR_START - 26
    Public Const ERR_CR_HOLDBALANCENOTCHANGE = ERR_CR_START - 27
    Public Const ERR_CR_HOLDIDLOCKED = ERR_CR_START - 28
    Public Const ERR_CR_HOLDIDDELETED = ERR_CR_START - 29
    Public Const ERR_CR_HOLDDATENOTCURRDATE = ERR_CR_START - 30
    Public Const ERR_CR_ACCOUNTPERMISSIONDENEINED = ERR_CR_START - 31
    Public Const ERR_CR_ACCOUNTINVALID = ERR_CR_START - 32
    Public Const ERR_CR_ACCOUNTDOESNEXIST = ERR_CR_START - 33
    Public Const ERR_CR_ACCOUNTBLOCKED = ERR_CR_START - 34
    Public Const ERR_CR_ACCOUNTCLOSED = ERR_CR_START - 35
    Public Const ERR_CR_ACCOUNTCANNOTHOLD = ERR_CR_START - 36
    Public Const ERR_CR_ACCOUNTCANNOTUNHOLD = ERR_CR_START - 37
    Public Const ERR_CR_GATEWAYTIMEOUT = ERR_CR_START - 38
    Public Const ERR_CR_SIGNINVALID = ERR_CR_START - 39
    Public Const ERR_CR_AVAILBALANCENOTENOUGHTOHOLD = ERR_CR_START - 40
    Public Const ERR_CR_AVAILBALANCENOTENOUGHTOPROCESS = ERR_CR_START - 41
    Public Const ERR_CR_UNHOLDBALANCEGEATERTHANHOLDBALANCE = ERR_CR_START - 42
    Public Const ERR_CR_OUTOFTRANSACTIONTIME = ERR_CR_START - 43
    Public Const ERR_CR_INVALIDUSERPASS = ERR_CR_START - 44
    Public Const ERR_CR_INVALIDSCCODE = ERR_CR_START - 45
    Public Const ERR_CR_INVALIDDATETIMEFORMAT = ERR_CR_START - 46
    Public Const ERR_CR_INVALIDBALANCE = ERR_CR_START - 47
    Public Const ERR_CR_INVALIDCHARACTERINXML = ERR_CR_START - 48
    Public Const ERR_CR_INVALIDCURRCODE = ERR_CR_START - 49
    Public Const ERR_CR_RCREPORTNOTFOUND = ERR_CR_START - 50
    Public Const ERR_CR_REFDUPLICATE = ERR_CR_START - 51
    Public Const ERR_CR_REFNOTFOUND = ERR_CR_START - 52
    Public Const ERR_CR_NEWPASSINVALID = ERR_CR_START - 53
    Public Const ERR_CR_NEWPASSAMEOLDPASS = ERR_CR_START - 54
    Public Const ERR_CR_INVALIDXMLFORMAT = ERR_CR_START - 55
    Public Const ERR_CR_FILEALREADYSENT = ERR_CR_START - 56
    Public Const ERR_CR_FILECANNOTPROCESSED = ERR_CR_START - 57
    Public Const ERR_CR_SYSTEMINBATCH = ERR_CR_START - 58
    Public Const ERR_CR_TRANSACTIONCANCELED = ERR_CR_START - 59
    Public Const ERR_CR_TRANSACTIONNOTFOUND = ERR_CR_START - 60
    Public Const ERR_CR_INTERNAL_ERROR = ERR_CR_START - 61
    Public Const ERR_CR_BANK_NOTCONNECTED = ERR_CR_START - 62
    Public Const ERR_CR_HOLDID_CANNOT_SPLIT = ERR_CR_START - 63
    Public Const ERR_CR_HOLDBALANCE_NOT_ENOUGH = ERR_CR_START - 64
    Public Const ERR_CR_HOLDBALANCE_ZERO = ERR_CR_START - 65
    Public Const ERR_CR_CANNOT_GET_SIGN = ERR_CR_START - 66
    Public Const ERR_CR_INVALIDSYSDATE = ERR_CR_START - 67
    Public Const ERR_CR_ACCT_ALREADY_REGISTER_OTHER_SID = ERR_CR_START - 68
    Public Const ERR_CR_PARAM_INVALID = ERR_CR_START - 69
    Public Const ERR_CR_CANNOT_DISABLE_ACCOUNT = ERR_CR_START - 70
    Public Const ERR_CR_ACCOUNT_NOTAUTHORIZE = ERR_CR_START - 71
    Public Const ERR_CR_ACCOUNT_NOTREGISTER = ERR_CR_START - 72
    Public Const ERR_CR_ERROR_UNMAP = ERR_CR_START - 73
    Public Const ERR_CR_TRANSFER_NOTEXECUTE = ERR_CR_START - 74
    Public Const ERR_CR_TRANSFER_DUPLICATE_EXC = ERR_CR_START - 75
    Public Const ERR_CR_TRANSFER_VERSION_NOT_EXISTED = ERR_CR_START - 76
    Public Const ERR_CR_TRANSFER_DETAIL_NOTFOUNDED = ERR_CR_START - 77
    Public Const ERR_CR_TRANSFER_STATUS_NOT_SAME = ERR_CR_START - 78

    '----------Phan he MR
    Public Const ERR_MR_START = ERR_SYSTEM_OK - 180000
    Public Const ERR_MR_ACTYPE_DUPLICATE = ERR_MR_START - 1
    Public Const ERR_MR_MRIRATELINE_INVALID = ERR_MR_START - 2
    Public Const ERR_MR_MRMRATELINE_INVALID = ERR_MR_START - 3
    Public Const ERR_MR_MRLRATELINE_INVALID = ERR_MR_START - 4
    Public Const ERR_MR_MRMRATE_INVALID = ERR_MR_START - 5
    Public Const ERR_MR_MRLRATE_INVALID = ERR_MR_START - 6
    Public Const ERR_MR_MRRATIORATE_INVALID = ERR_MR_START - 7
    Public Const ERR_MR_MRRATIOLOAN_INVALID = ERR_MR_START - 8
    Public Const ERR_MR_ACCTNO_NOT_MARGIN_TYPE = ERR_MR_START - 9
    Public Const ERR_MR_MRIRATE_OVER_SYSTEM_IRATE = ERR_MR_START - 10
    Public Const ERR_MR_MRMRATE_OVER_SYSTEM_MRATE = ERR_MR_START - 11
    Public Const ERR_MR_MRLRATE_OVER_SYSTEM_LRATE = ERR_MR_START - 12
    Public Const ERR_MR_SYS_MRRATIORATE_UNDER_TYPE_MRRATIORATE = ERR_MR_START - 13
    Public Const ERR_MR_SYS_MRRATIOLOAN_UNDER_TYPE_MRRATIOLOAN = ERR_MR_START - 14
    Public Const ERR_MR_SYS_MRPRICERATE_UNDER_TYPE_MRPRICERATE = ERR_MR_START - 15
    Public Const ERR_MR_SYS_MRPRICELOAN_UNDER_TYPE_MRPRICELOAN = ERR_MR_START - 16
    Public Const ERR_MR_ACCOUNT_MARGINRATE_UNDER_INITRATE = ERR_MR_START - 17
    Public Const ERR_MR_OVER_SYSTEM_LONG_POSSITION = ERR_MR_START - 18
    Public Const ERR_MR_MRPRICERATE_INVALID = ERR_MR_START - 19
    Public Const ERR_MR_MRPRICELOAN_INVALID = ERR_MR_START - 20
    Public Const ERR_EA_ESCROWID_DUPLICATED = ERR_MR_START - 21 'ERR_MR_CUSTMRLIMIT_UNDER_CONTRACTMRLIMIT
    Public Const ERR_EA_STATUS_INVALID = ERR_MR_START - 22
    Public Const ERR_MR_LEADER_IS_MEMBER_OTHER_CLASS = ERR_MR_START - 23
    Public Const ERR_MR_MRTYPE_INUSED = ERR_MR_START - 24
    Public Const ERR_MR_ACCTNO_INVALID_MARGIN_TYPE = ERR_MR_START - 25
    Public Const ERR_MR_ACCTNO_OVERDUE = ERR_MR_START - 26
    Public Const ERR_MR_MRTYPE_NOT_CUSTOMIZE = ERR_MR_START - 27
    Public Const ERR_MR_ACCOUNT_OVERLIMIT = ERR_MR_START - 28
    Public Const ERR_MR_GROUP_OVERLIMIT = ERR_MR_START - 29
    Public Const ERR_MR_USER_T0_NOT_DEFINE = ERR_MR_START - 30
    Public Const ERR_MR_USER_T0_NOT_ENOUGHT = ERR_MR_START - 31
    Public Const ERR_MR_OVER_USER_T0MAX = ERR_MR_START - 32
    Public Const ERR_MR_ACCTNO_T0_NOT_ENOUGHT = ERR_MR_START - 33
    Public Const ERR_EA_ESCROW_CHECK_DDACCOUNT_IICA = ERR_MR_START - 34
    Public Const ERR_MR_OVER_USER_T0_ALLOCATE = ERR_MR_START - 35
    Public Const ERR_MR_MRTYPE_NOT_FOUND = ERR_MR_START - 36
    Public Const ERR_MR_CANNOT_CHANGE_MARGIN_ACCOUNT = ERR_MR_START - 37
    Public Const ERR_MR_OVER_MARGINLIMIT = ERR_MR_START - 38
    Public Const ERR_MR_MRIRATIO_INVALID = ERR_MR_START - 42
    Public Const ERR_MR_MRMRATIO_INVALID = ERR_MR_START - 43
    Public Const ERR_MR_MRLRATIO_INVALID = ERR_MR_START - 44
    Public Const ERR_MR_AFTYPE_HAS_BEEN_USED = ERR_MR_START - 45
    Public Const ERR_MR_AFTYPE_T0LNTYPE_NOT_CHKSYSCTRL = ERR_MR_START - 46
    Public Const ERR_MR_AFTYPE_LNTYPE_CANNOT_NULL = ERR_MR_START - 47
    Public Const ERR_MR_AFTYPE_COREBANK_VALUE_YES = ERR_MR_START - 48
    Public Const ERR_MR_AFTYPE_COREBANK_VALUE_NO_WITH_CITYPE = ERR_MR_START - 65
    Public Const ERR_MR_AFTYPE_NORMAL1 = ERR_MR_START - 68
    Public Const ERR_MR_AFTYPE_NORMAL2 = ERR_MR_START - 69

    '</TruongLD Add 26/11/2011 Margin 74
    '-- Phan he Pool/Room
    Public Const gc_PR_AFTYPE_ALL = "AAAA"
    Public Const gc_PR_DFTYPE_ALL = "DDDD"
    Public Const gc_PR_ACTYPE_ALL = "AADD"
    Public Const gc_PR_TYPEGR_ALL = "ALLTYPE"

    Public Const ERR_PRCHK_DOUBLE_ACTYPE_PRCODE = ERR_SA_START - 535
    Public Const ERR_PRCHK_DOUBLE_ACTYPE_POOL = ERR_SA_START - 536
    Public Const ERR_PRCHK_CONF_ACTYPEPR = ERR_SA_START - 537
    Public Const ERR_PR_CONF_CODEID = ERR_SA_START - 538
    Public Const ERR_PRMASTER_DOUBLE_PRTYPE = ERR_SA_START - 541
    Public Const ERR_DUEDATE_IS_BUSDATE = ERR_CA_START - 37

    'End TruongLD/>

    'Phan he FA
    Public Const ERR_FA_BRID_CUSTODYCD_IS_DUPLICATED = ERR_SA_START - 307
    Public Const CUSTODYCD_PREFIX_MUST_BE_COMPANY_STANDARD = ERR_CA_START - 308
    Public Const ERR_RPTGENCFG_EXISTS = ERR_CA_START - 309
    Public Const ERR_FA_FABROKERAGE_FAMEMBERSEXTRA_IS_DUPLICATED = ERR_SA_START - 340
    'END Phan he FA

    'Phan he BA'
    Public Const ERR_BA_EXIT_PAYMENT_PERIOD = ERR_SYSTEM_OK - 910000
    Public Const ERR_BA_EXIST_BONDCODE_ISSUES = ERR_SYSTEM_OK - 910001
    Public Const ERR_BA_EXIST_TICKER_ISSUES_BONDTYPE = ERR_SYSTEM_OK - 910002
    'END phan he BA'
	
	'Phan he AP'
    Public Const ERR_AP_SYMBOL_CRPHYSAGREE = ERR_SYSTEM_OK - 911000
    Public Const ERR_AP_PAYSTATUS_CRPHYSAGREE = ERR_AP_SYMBOL_CRPHYSAGREE - 1
    Public Const ERR_AP_CRPHYSAGREE_EXIT_APPENDIX = ERR_AP_SYMBOL_CRPHYSAGREE - 2
    'END phan he BA'
#End Region

#Region " Define constants for currency "
    Public Const BASED_CCYCD = "00"
    Public Const POS_CCYCD = 4
    Public Const BASED_CCYCD_DECIMAL = "2"
#End Region

#Region " Constants for report "
    'Háº±ng sá»‘ quy Æ°á»›c pháº¡m vi táº¡o bÃ¡o cÃ¡o
    Public Const gc_REPORT_AREA_ALL = "A"           'BÃ¡o cÃ¡o toÃ n cÃ´ng ty
    Public Const gc_REPORT_AREA_BRANCH = "B"        'BÃ¡o cÃ¡o chi nhÃ¡nh
    Public Const gc_REPORT_AREA_AGENT = "S"         'BÃ¡o cÃ¡o Ä‘áº¡i lÃ½ nháº­n lá»‡nh

    'Constants for report formular name
    Public Const gc_RPT_FORMULAR_START = "F_"
    Public Const gc_RPT_FORMULAR_COMPANY_NAME = gc_RPT_FORMULAR_START & "COMPANY_NAME"
    Public Const gc_RPT_FORMULAR_COMPANY_NAME_EN = gc_RPT_FORMULAR_START & "COMPANY_NAME_EN"
    Public Const gc_RPT_FORMULAR_COMPANY_SHORTNAME = gc_RPT_FORMULAR_START & "COMPANY_SHORTNAME"
    Public Const gc_RPT_FORMULAR_HEADOFFICE = gc_RPT_FORMULAR_START & "HEADOFFICE"
    Public Const gc_RPT_FORMULAR_HEADOFFICE_EN = gc_RPT_FORMULAR_START & "HEADOFFICE_EN"
    Public Const gc_RPT_FORMULAR_BRID = gc_RPT_FORMULAR_START & "BRID"
    Public Const gc_RPT_FORMULAR_ADDRESS = gc_RPT_FORMULAR_START & "ADDRESS"
    Public Const gc_RPT_FORMULAR_ADDRESS_EN = gc_RPT_FORMULAR_START & "ADDRESS_EN"
    Public Const gc_RPT_FORMULAR_CITYADDRESS = gc_RPT_FORMULAR_START & "CITYADDRESS"
    Public Const gc_RPT_FORMULAR_CITYADDRESS_EN = gc_RPT_FORMULAR_START & "CITYADDRESS_EN"
    Public Const gc_FORMULAR_DEALINGCUSTODYCD = gc_RPT_FORMULAR_START & "DEALINGCUSTODYCD"
    Public Const gc_RPT_FORMULAR_COMPANYCD = gc_RPT_FORMULAR_START & "COMPANYCD"
    Public Const gc_RPT_FORMULAR_PHONE_FAX = gc_RPT_FORMULAR_START & "PHONE_FAX"
    Public Const gc_RPT_FORMULAR_PHONE_FAX_EN = gc_RPT_FORMULAR_START & "PHONE_FAX_EN"
    Public Const gc_RPT_FORMULAR_REPORT_TITLE = gc_RPT_FORMULAR_START & "REPORT_TITLE"
    Public Const gc_RPT_FORMULAR_CREATED_DATE = gc_RPT_FORMULAR_START & "CREATED_DATE"
    Public Const gc_RPT_FORMULAR_CREATED_DATE_VN_EN = gc_RPT_FORMULAR_START & "CREATED_DATE_VN_EN"
    Public Const gc_RPT_FORMULAR_CREATED_DATE_EN = gc_RPT_FORMULAR_START & "CREATED_DATE_EN"
    Public Const gc_RPT_FORMULAR_CREATED_BY = gc_RPT_FORMULAR_START & "CREATED_BY"

    Public Const gc_RPT_FORMULAR_FROM_DATE = gc_RPT_FORMULAR_START & "FROM_DATE"
    Public Const gc_RPT_FORMULAR_TO_DATE = gc_RPT_FORMULAR_START & "TO_DATE"
    Public Const gc_RPT_FORMULAR_REPORT_CRITERIAS = gc_RPT_FORMULAR_START & "REPORT_CRITERIAS"
    Public Const gc_RPT_FORMULAR_REPORT_CMDID = gc_RPT_FORMULAR_START & "CMDID"
    Public Const gc_RPT_FORMULAR_DEPOSITID = gc_RPT_FORMULAR_START & "DEPOSITID"


#End Region

#Region " Common functions & variables "
    'trung.luu
    Dim v_sessionID As String = ""
    Public Function gen_req_key() As String
        Return DateTime.Now.ToString("yyyyMMddhhmmssmmm")
    End Function
    Public Function CharCount(ByVal OrigString As String, _
      ByVal Chars As String, Optional ByVal CaseSensitive As Boolean = False) _
      As Long

        '**********************************************
        'PURPOSE: Returns Number of occurrences of a character or
        'or a character sequencence within a string

        'PARAMETERS:
        'OrigString: String to Search in
        'Chars: Character(s) to search for
        'CaseSensitive (Optional): Do a case sensitive search
        'Defaults to false

        'RETURNS:
        'Number of Occurrences of Chars in OrigString

        'EXAMPLES:
        'Debug.Print CharCount("FreeVBCode.com", "E") -- returns 3
        'Debug.Print CharCount("FreeVBCode.com", "E", True) -- returns 0
        'Debug.Print CharCount("FreeVBCode.com", "co") -- returns 2
        ''**********************************************

        Dim lLen As Long
        Dim lCharLen As Long
        Dim lAns As Long
        Dim sInput As String
        Dim sChar As String
        Dim lCtr As Long
        Dim lEndOfLoop As Long
        Dim bytCompareType As Byte

        sInput = OrigString
        If sInput = "" Then Exit Function
        lLen = Len(sInput)
        lCharLen = Len(Chars)
        lEndOfLoop = (lLen - lCharLen) + 1
        bytCompareType = IIf(CaseSensitive, vbBinaryCompare, _
           vbTextCompare)

        For lCtr = 1 To lEndOfLoop
            sChar = Mid(sInput, lCtr, lCharLen)
            If StrComp(sChar, Chars, bytCompareType) = 0 Then _
                lAns = lAns + 1
        Next

        CharCount = lAns

    End Function

    'locpt TFLEX.SA0002
    Public Property SessionID() As String
        Get
            Return v_sessionID
        End Get
        Set(ByVal value As String)
            v_sessionID = value
        End Set
    End Property
    Public Function CutMark(ByVal strVietNamese As String) As String
        Dim FindText As String = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ"
        Dim ReplText As String = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY"
        Dim v_strTemp As String = ""
        Dim v_arrF As Char() = FindText.ToCharArray()
        Dim v_arrR As Char() = ReplText.ToCharArray()
        Dim v_strRet As String = strVietNamese

        For i As Integer = 0 To v_strRet.Length - 1
            v_strTemp = v_strRet.Substring(i, 1)
            If FindText.IndexOf(v_strTemp) >= 0 Then
                v_strRet = v_strRet.Replace(v_strTemp, v_arrR(FindText.IndexOf(v_strTemp)))
            End If
        Next

        v_strRet = v_strRet.Replace(",", "").Replace("%", "").Replace("'", "").Replace("^", "").Replace("&", "").Replace(">", "").Replace("<", "").Replace("-", "").Replace(".", "")

        Return v_strRet
    End Function


    Function YYYYMMDD_FormatDate(ByVal pv_Date As String) As String
        Try
            Dim v_temp As String = DDMMYYYY_SystemDate(pv_Date)
            Dim iDay As String = CStr(pv_Date).Substring(0, 2)
            Dim iMonth As String = CStr(pv_Date).Substring(3, 2)
            Dim iYear As String = CStr(pv_Date).Substring(6, 4)
            v_temp = iYear & iMonth & iDay
            Return v_temp
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Function gf_Cdate(ByVal pv_strDate As String) As Date
        Try
            Return DateTime.ParseExact(pv_strDate, gc_FORMAT_DATE, System.Globalization.CultureInfo.InvariantCulture)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function XmlToDataTable(ByVal pv_NodeList As XmlNodeList) As DataTable
        Dim v_dt As DataTable = Nothing
        If Not pv_NodeList Is Nothing Then
            If pv_NodeList.Count > 0 Then
                v_dt = New DataTable(pv_NodeList(0).Name)
                For i As Integer = 0 To pv_NodeList.Count - 1
                    'Tao cau truc bang
                    If i = 0 Then
                        Dim v_fchild As XmlNodeList = pv_NodeList(i).ChildNodes
                        If Not v_fchild Is Nothing Then
                            For j As Integer = 0 To v_fchild.Count - 1
                                If Not v_dt.Columns.Contains(v_fchild(j).Attributes("fldname").Value) Then
                                    v_dt.Columns.Add(v_fchild(j).Attributes("fldname").Value, Type.GetType(v_fchild(j).Attributes("fldtype").Value))
                                End If
                            Next
                        End If
                    End If
                    'End
                    Dim v_dr As DataRow = v_dt.NewRow()

                    Dim v_child As XmlNodeList = pv_NodeList(i).ChildNodes
                    If Not v_child Is Nothing Then
                        For j As Integer = 0 To v_child.Count - 1
                            If v_child(j).Attributes("fldtype").Value = "System.DateTime" Then
                                If v_child(j).InnerXml.Length > 0 Then
                                    v_dr(v_child(j).Attributes("fldname").Value) = DateTime.ParseExact(v_child(j).InnerXml, "dd/MM/yyyy", Nothing)
                                Else
                                    v_dr(v_child(j).Attributes("fldname").Value) = DBNull.Value
                                End If
                            Else
                                v_dr(v_child(j).Attributes("fldname").Value) = v_child(j).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "")
                            End If
                        Next
                    End If

                    v_dt.Rows.Add(v_dr)
                Next
            End If
        End If
        Return v_dt
    End Function


    Public Function GetValueFromComboExArray(ByVal pv_strDATA As String, ByVal pv_arrHash As Hashtable) As String
        Dim v_strReturn As String = String.Empty
        If Not pv_arrHash Is Nothing Then
            If pv_arrHash.Keys.Count > 0 Then
                v_strReturn = pv_arrHash.Item(pv_strDATA.ToUpper)
            End If
        End If
        Return v_strReturn
    End Function

    Public Sub FillComboExArray(ByVal pv_strObjMsg As String, ByRef pv_arrHashData As Hashtable, Optional ByVal pv_FilterID As String = "")
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue, v_strCboValue, v_strCboDisplay, v_strCboFilterID As String
        Dim v_int, i, j As Integer
        Try
            If pv_arrHashData Is Nothing Then
                pv_arrHashData = New Hashtable
            End If

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_int = 0
            For i = 0 To v_nodeList.Count - 1
                v_strCboValue = String.Empty
                v_strCboDisplay = String.Empty
                v_strCboFilterID = String.Empty
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_strCboValue = Trim(v_strValue)
                            Case "DISPLAY"
                                v_strCboDisplay = Trim(v_strValue)
                            Case "FILTERID"
                                v_strCboFilterID = Trim(v_strValue)
                        End Select
                    End With
                Next

                If pv_FilterID.Length = 0 Then
                    'Do not have filter
                    v_int += 1
                    pv_arrHashData.Add(v_strCboValue, v_strCboDisplay)
                ElseIf v_strCboFilterID.Length > 0 Then
                    If String.Compare(v_strCboFilterID, pv_FilterID) = 0 Then
                        v_int += 1
                        pv_arrHashData.Add(v_strCboValue, v_strCboDisplay)
                    End If
                End If
            Next

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Public Function gf_CorrectStringFieldNew(ByVal data As Object) As String
        Try
            Dim v_strReturn As String = String.Empty
            If IsNothing(data) Then
                v_strReturn = String.Empty
            Else
                v_strReturn = IIf(IsDBNull(data), String.Empty, data)
            End If

            Return v_strReturn
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function gf_RoundNumber(ByVal v_strVALUE As String, ByVal v_strRND As String) As String
        Dim v_strRETURN, v_strFORMAT As String, v_intDecimal As Integer
        v_strRETURN = v_strVALUE
        If v_strRND.Trim.Length > 0 Then
            If IsNumeric(v_strRND) And IsNumeric(v_strVALUE) Then
                v_intDecimal = CInt(v_strRND)
                If v_intDecimal > 0 Then
                    'Làm tròn sau dấy phẩy
                    v_strRETURN = FormatNumber(v_strVALUE, v_intDecimal, , , False)
                Else
                    'Làm tròn trước dấu phẩy: nếu giá trị 
                    v_strFORMAT = New String("0", v_intDecimal * -1)
                    v_strFORMAT = "1" & v_strFORMAT
                    'Chia ra làm tròn rồi nhân lại
                    v_strRETURN = CDbl(FormatNumber(CDbl(v_strVALUE) / CDbl(v_strFORMAT), 0)).ToString
                    v_strRETURN = FormatNumber(v_strRETURN, 0, , , False)   'làm tròn đến hàng đơn vị
                    v_strRETURN = CDbl(FormatNumber(CDbl(v_strRETURN) * CDbl(v_strFORMAT), 0)).ToString
                End If
            End If
        End If
        Return v_strRETURN
    End Function

    Public Function isQueryCommand(ByVal v_strSQL As String) As Boolean
        v_strSQL = v_strSQL.Trim()
        If String.Compare(v_strSQL.Substring(0, 6).ToUpper, "SELECT") = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TripleDesEncryptData(ByVal v_Data As String) As String
        Return v_Data
        Dim ct As System.Security.Cryptography.ICryptoTransform
        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim des As New System.Security.Cryptography.TripleDESCryptoServiceProvider
        Try
            Dim v_strKey1, v_strKey2, v_strKey3, v_strKey4, v_strKey5 As String
            v_strKey1 = "VND"
            v_strKey2 = "SBnG"
            v_strKey3 = "USD"
            v_strKey4 = "EUR"
            v_strKey5 = "F31"
            Dim m_iv() As Byte = {1, 1, 2, 8, 2, 9, 2, 9}
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(v_strKey1 & v_strKey2 & v_strKey3 & v_strKey4 & v_strKey5))

            des.IV = m_iv
            ct = des.CreateEncryptor()

            Dim input() As Byte = Encoding.Unicode.GetBytes(v_Data)
            Dim output() As Byte = ct.TransformFinalBlock(input, 0, input.Length)

            Return Convert.ToBase64String(output)
        Catch ex As Exception
            Throw ex
        Finally
            md5 = Nothing
            des = Nothing
        End Try
    End Function

    Public Function TripleDesDecryptData(ByVal v_Data As String) As String
        Return v_Data
        Dim ct As System.Security.Cryptography.ICryptoTransform
        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim des As New System.Security.Cryptography.TripleDESCryptoServiceProvider
        Try
            Dim v_strKey1, v_strKey2, v_strKey3, v_strKey4, v_strKey5 As String
            v_strKey1 = "VND"
            v_strKey2 = "SBnG"
            v_strKey3 = "USD"
            v_strKey4 = "EUR"
            v_strKey5 = "F31"
            Dim m_iv() As Byte = {1, 1, 2, 8, 2, 9, 2, 9}
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(v_strKey1 & v_strKey2 & v_strKey3 & v_strKey4 & v_strKey5))
            des.IV = m_iv
            ct = des.CreateDecryptor()

            Dim input() As Byte = Convert.FromBase64String(v_Data)
            Dim output() As Byte = ct.TransformFinalBlock(input, 0, input.Length)

            Return Encoding.Unicode.GetString(output)
        Catch ex As Exception
            Throw ex
        Finally
            md5 = Nothing
            des = Nothing
        End Try
    End Function

    Public Function FormatGLACCTNO(ByVal v_strACCTNO As String) As String
        Dim v_strRETURN, v_strFORMAT As String
        v_strFORMAT = "0000.00.000.0000000.000.0000.000"
        If v_strACCTNO.Length = v_strFORMAT.Replace(".", String.Empty).Length Then
            v_strRETURN = v_strACCTNO.Substring(0, 4) & "."  'BRID
            v_strRETURN = v_strRETURN & v_strACCTNO.Substring(4, 2) & "."
            v_strRETURN = v_strRETURN & v_strACCTNO.Substring(6, 3) & "."
            v_strRETURN = v_strRETURN & v_strACCTNO.Substring(9, 7) & "."
            v_strRETURN = v_strRETURN & v_strACCTNO.Substring(16, 3) & "."
            v_strRETURN = v_strRETURN & v_strACCTNO.Substring(19, 4) & "."
            v_strRETURN = v_strRETURN & v_strACCTNO.Substring(23, 3)
        Else
            v_strRETURN = v_strACCTNO
        End If
        Return v_strRETURN
    End Function

    Public Function SetCultureInfo(ByVal v_strCultureName As String) As String
        Dim oldCI As Globalization.CultureInfo
        Dim v_strOldCultureName As String = String.Empty
        Dim v_strDecimal_Number, v_strGroup_Number As String

        v_strOldCultureName = System.Threading.Thread.CurrentThread.CurrentCulture.Name

        v_strDecimal_Number = ConfigurationSettings.AppSettings("NumberDecimalSeparator")
        v_strGroup_Number = ConfigurationSettings.AppSettings("NumberGroupSeparator")

        If v_strOldCultureName <> v_strCultureName Then
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(v_strCultureName)
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = v_strDecimal_Number
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = v_strGroup_Number
        End If

        Return v_strOldCultureName

    End Function


    Public Sub FillDataToTable(ByVal pv_strObjMsg As String, ByRef pv_table As DataTable)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue, v_strCboValue, v_strCboDisplay, v_strCboFilterID As String
        Dim v_arrValue(), v_arrDisplay() As String
        Dim v_int As Integer
        Try
            v_int = 0
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim v_arrValue(v_nodeList.Count)
            ReDim v_arrDisplay(v_nodeList.Count)
            v_int = 0
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strCboValue = String.Empty
                v_strCboDisplay = String.Empty
                v_strCboFilterID = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_strCboValue = Trim(v_strValue)
                            Case "DISPLAY"
                                v_strCboDisplay = Trim(v_strValue)
                        End Select
                    End With
                Next
                v_int += 1
                v_arrValue(v_int) = v_strCboValue
                v_arrDisplay(v_int) = v_strCboDisplay
            Next

            Dim v_dr As System.Data.DataRow
            pv_table.TableName = "COMBOBOX"
            pv_table.Columns.Add("DISPLAY")
            pv_table.Columns.Add("VALUE")
            For i As Integer = 1 To v_int
                'pv_cbo.AddItems(v_arrDisplay(i), v_arrValue(i))
                v_dr = pv_table.NewRow
                pv_table.Rows.Add(v_dr)
                v_dr("DISPLAY") = v_arrDisplay(i)
                v_dr("VALUE") = v_arrValue(i).ToString
            Next
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub
    Public Sub CopyProperties(ByRef dst As Object, ByRef src As Object)

        Dim srcProperties() As PropertyInfo = src.GetType.GetProperties()
        Dim detProperties() As PropertyInfo = dst.GetType.GetProperties()
        Dim dstType = dst.GetType

        Try

            If srcProperties Is Nothing Or dstType.GetProperties Is Nothing Then
                Return
            End If

            For Each srcProperty As PropertyInfo In srcProperties
                Dim dstProperty As PropertyInfo = dstType.GetProperty(srcProperty.Name)

                If Not (dstProperty Is Nothing) Then
                    If dstProperty.PropertyType.IsAssignableFrom(srcProperty.PropertyType) = True Then
                        dstProperty.SetValue(dst, srcProperty.GetValue(src, Nothing), Nothing)
                    End If
                End If
            Next

            'For Each detProperty As PropertyInfo In detProperties
            '    Dim srcProperty As PropertyInfo = dstType.GetProperty(detProperty.Name)

            '    If Not (srcProperty Is Nothing) Then
            '        If detProperty.PropertyType.IsAssignableFrom(detProperty.PropertyType) = True Then
            '            detProperty.SetValue(dst, srcProperty.GetValue(src, Nothing), Nothing)
            '        End If
            '    End If
            'Next

        Catch ex As Exception

        End Try
    End Sub

    'CÃ¡c kiá»ƒu tÃ¡c Ä‘á»™ng tá»›i CSDL cá»§a form
    Public Enum ExecuteFlag
        View = 0
        AddNew = 1
        Edit = 2
        Delete = 3
        Execute = 4
        Stoped = 5
        Returned = 6
        Executed = 7
        SendSMS = 8
        Approve = 9
        Email = 10
    End Enum

    Public Enum TransactStatus
        Logged = 0              'Logged
        Completed = 1           'Completed
        ErrorOccured = 2        'Error
        Cashier = 3             'Unsetted
        Pending = 4             'Pending to approve
        Rejected = 5            'Rejected
        MsgRequired = 6         'SWIFT missing
        Deleting = 7            'Pending to delete
        Refuse = 8             'Refuse
        Deleted = 9            'Deleted
        Remittance = 10          'Remittance

    End Enum

    Public Enum ProcessType
        BatchProcess = 0
        ReportProcess = 1
        ExportProcess = 2
        SendEmailProcess = 3
        Processing = 4
    End Enum

    <DllImport("iphlpapi.dll", ExactSpelling:=True)> _
    Public Function SendARP(ByVal DestIP As Integer, ByVal SrcIP As Integer, ByVal pMacAddr() As Byte, ByRef PhyAddrLen As Integer) As Integer

    End Function
    Public Function gf_Numberic(ByVal v_str As String) As Boolean
        If IsNumeric(v_str) Then
            Return True
        Else
            Dim v_strLeft, v_strRight As String
            v_strLeft = v_str
            v_strRight = "0"
            For i As Integer = 0 To v_str.Length - 1
                If v_str.Chars(i) = "/" Then
                    v_strLeft = v_str.Substring(0, i)
                    v_strRight = v_str.Substring(i + 1, v_str.Length - i - 1)
                    Exit For
                End If
            Next
            If IsNumeric(Trim(v_strLeft)) And Not IsDecimal(Trim(v_strLeft)) And IsNumeric(Trim(v_strRight)) And Not IsDecimal(Trim(v_strRight)) And Trim(v_strRight) <> "0" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Function gf_FormatNumberToSring(ByVal v_str As String, ByVal v_int As Integer) As String
        Dim v_strLeft, v_strRight As String
        v_strLeft = String.Empty
        v_strRight = String.Empty
        If Len(v_str) > 0 Then
            If IsNumeric(v_str) Then
                v_strLeft = v_str
                v_strRight = "1"
            Else
                If gf_Numberic(v_str) Then
                    For i As Integer = 0 To v_str.Length - 1
                        If v_str.Chars(i) = "/" Then
                            v_strLeft = v_str.Substring(0, i)
                            v_strRight = v_str.Substring(i + 1, v_str.Length - i - 1)
                            Exit For
                        End If
                    Next
                End If
            End If
        End If
        If v_int = 0 Then
            Return v_strLeft
        Else
            Return v_strRight
        End If
    End Function
    Public Function IsDecimal(ByVal v_str As String) As Boolean
        Dim t As String
        For i As Integer = 0 To v_str.Length - 1
            t = v_str.Substring(i, 1)
            If t = "." Then Return True
        Next
        Return False
    End Function

    Public Function gf_String2XMLDocumentEx(ByVal v_str As String) As XmlDocumentEx
        Dim v_strXMLDocument As New XmlDocumentEx
        v_strXMLDocument.LoadXml(v_str)
        Return v_strXMLDocument
    End Function

    Public Function UnicodeAnsi(ByVal strVietNamese As String) As String
        Dim FindText As String = "ÐáàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ"
        Dim ReplText As String = "DaaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY"
        Dim v_strTemp As String = ""
        Dim v_arrF As Char() = FindText.ToCharArray()
        Dim v_arrR As Char() = ReplText.ToCharArray()
        Dim v_strRet As String = strVietNamese

        For i As Integer = 0 To v_strRet.Length - 1
            v_strTemp = v_strRet.Substring(i, 1)
            If FindText.IndexOf(v_strTemp) >= 0 Then
                v_strRet = v_strRet.Replace(v_strTemp, v_arrR(FindText.IndexOf(v_strTemp)))
            End If
        Next
        Return v_strRet
    End Function

    Public Function gf_String2XMLDocument(ByVal v_str As String) As Xml.XmlDocument
        Dim v_strXMLDocument As New Xml.XmlDocument
        v_strXMLDocument.LoadXml(v_str)
        Return v_strXMLDocument
    End Function

    Public Function gf_Cdbl(ByVal v_str As String) As Double
        If IsNumeric(v_str) Then
            Return CDbl(v_str)
        Else
            Dim i As Integer
            Dim v_strLeft, v_strRight As String
            v_strLeft = v_str
            v_strRight = "0"
            For i = 0 To v_str.Length - 1
                If v_str.Chars(i) = "/" Then
                    v_strLeft = v_str.Substring(0, i)
                    v_strRight = v_str.Substring(i + 1, v_str.Length - i - 1)
                    Exit For
                End If
            Next
            If IsNumeric(Trim(v_strLeft)) And IsNumeric(Trim(v_strRight)) And Trim(v_strRight) <> "0" Then
                Return CDbl(CDbl(Trim(v_strLeft)) / CDbl(Trim(v_strRight)))
            End If
        End If
    End Function
    Public Function gf_GeneratePIN() As String
        Try
            Dim v_strPIN As String
            v_strPIN = CType(Rnd(), String).ToString
            If Len(v_strPIN) > 50 Then v_strPIN = Left(v_strPIN, 50)
            Return v_strPIN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function gf_CorrectStringField(ByVal data As Object) As String
        Try
            Return IIf(IsDBNull(data), String.Empty, data)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function gf_CorrectNumericField(ByVal data As Object) As Decimal
        Try
            Return IIf(IsDBNull(data), 0, data)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function gf_IsInt(ByVal data As Object) As Boolean
        Try
            Convert.ToInt32(data)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function gf_IsNumeric(ByVal data As Object) As Boolean
        Try
            Convert.ToDecimal(data)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function gf_CorrectDateField(ByVal data As Object) As Date
        Try

            Return IIf(IsDBNull(data), Now.Date, data)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function gf_CorrectBooleanField(ByVal data As Object) As Boolean
        Try
            Return IIf(IsDBNull(data), False, data)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LogXmlMessage(ByVal v_strXmlMsg As String, ByVal v_strPathFileName As String) As Boolean
        Try
            Dim writer As Xml.XmlTextWriter = New Xml.XmlTextWriter(v_strPathFileName, Nothing)
            Dim v_xmlLogMessage As New Xml.XmlDocument
            writer.Formatting = Xml.Formatting.Indented
            v_xmlLogMessage.LoadXml(v_strXmlMsg)
            v_xmlLogMessage.Save(writer)
            writer.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuildXMLBPSData(ByVal xmlData As String, _
                                    ByRef pv_strObjectMessage As String) As Long
        Dim v_XmlDocument As New Xml.XmlDocument
        Dim dataElement As Xml.XmlElement
        Dim entryNode As Xml.XmlNode

        v_XmlDocument.LoadXml(pv_strObjectMessage)
        Try
            If Not xmlData.Equals(String.Empty) Then
                Dim v_strXMLBuilder As New StringBuilder
                Dim v_xmlBuilder As New Xml.XmlDocument
                Dim nodeItem As Xml.XmlNode, nodeList As Xml.XmlNodeList

                v_strXMLBuilder.Append("<BPSData><![CDATA[")
                v_strXMLBuilder.Append(xmlData)
                v_strXMLBuilder.Append("]]></BPSData>")

                v_xmlBuilder.LoadXml(v_strXMLBuilder.ToString)
                nodeItem = v_XmlDocument.ImportNode(v_xmlBuilder.SelectSingleNode("/BPSData"), True)
                v_XmlDocument.DocumentElement.AppendChild(nodeItem)
                v_strXMLBuilder.Remove(0, v_strXMLBuilder.Length)
            End If

            pv_strObjectMessage = v_XmlDocument.InnerXml
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuildXMLEAIMsg(Optional ByVal pv_strMSGID As String = "", _
                                           Optional ByVal pv_strQUEUENAME As String = "", _
                                           Optional ByVal pv_strRECEIVETIME As String = "", _
                                           Optional ByVal pv_strRECEIVEDATE As String = "", _
                                           Optional ByVal pv_strSENDTIME As String = "", _
                                           Optional ByVal pv_strSENDDATE As String = "", _
                                           Optional ByVal pv_strTXNUM As String = "", _
                                           Optional ByVal pv_strTXDATE As String = "", _
                                           Optional ByVal pv_strTXTIME As String = "0", _
                                           Optional ByVal pv_strBRID As String = "N", _
                                           Optional ByVal pv_strTLID As String = "N", _
                                           Optional ByVal pv_strOFFID As String = "N", _
                                           Optional ByVal pv_strCHID As String = "N", _
                                           Optional ByVal pv_strCHKID As String = "N", _
                                           Optional ByVal pv_strTLTXCD As String = "N", _
                                           Optional ByVal pv_strBRDATE As String = "N", _
                                           Optional ByVal pv_strBUSDATE As String = "N", _
                                           Optional ByVal pv_strTXCODE As String = "N", _
                                           Optional ByVal pv_strACCTNO As String = "N", _
                                           Optional ByVal pv_strACCTNO2 As String = "N", _
                                           Optional ByVal pv_strBANKCODE As String = "", _
                                           Optional ByVal pv_strBANKERRNUM As String = "0", _
                                           Optional ByVal pv_strBANKERRDESC As String = "", _
                                           Optional ByVal pv_strBANKREF As String = "", _
                                           Optional ByVal pv_strERRNUM As String = "") As String
        Try
            Dim XMLDocumentMessage As New Xml.XmlDocument
            Dim dataElement As Xml.XmlElement
            Dim v_attrMSGID, v_attrQUEUENAME, v_attrRECEIVEDATE, v_attrRECEIVETIME, v_attrSENDTIME, v_attrSENDDATE, _
                v_attrTXNUM, v_attrTXDATE, v_attrTXTIME, v_attrBRID, v_attrTLID, v_attrOFFID, v_attrCHID, v_attrCHKID As Xml.XmlAttribute
            Dim v_attrTLTXCD, v_attrBRDATE, v_attrBUSDATE, v_attrTXCODE, v_attrACCTNO, v_attrACCTNO2, v_attrBANKCODE As Xml.XmlAttribute
            Dim v_attrBANKERRNUM, v_attrBANKERRDESC, v_attrBANKREF, v_attrERRNUM As Xml.XmlAttribute
            dataElement = XMLDocumentMessage.CreateElement("EAIMessage")
            'Create MsgID
            v_attrMSGID = XMLDocumentMessage.CreateAttribute(gc_AtributeMSGID)
            v_attrMSGID.Value = pv_strMSGID
            dataElement.Attributes.Append(v_attrMSGID)
            'Create QUEUENAME
            v_attrQUEUENAME = XMLDocumentMessage.CreateAttribute(gc_AtributeQUEUENAME)
            v_attrQUEUENAME.Value = pv_strQUEUENAME
            dataElement.Attributes.Append(v_attrQUEUENAME)
            'Create RECEIVETIME
            v_attrRECEIVETIME = XMLDocumentMessage.CreateAttribute(gc_AtributeRECEIVETIME)
            v_attrRECEIVETIME.Value = pv_strRECEIVETIME
            dataElement.Attributes.Append(v_attrRECEIVETIME)
            'Create RECEIVEDATE
            v_attrRECEIVEDATE = XMLDocumentMessage.CreateAttribute(gc_AtributeRECEIVEDATE)
            v_attrRECEIVEDATE.Value = pv_strRECEIVEDATE
            dataElement.Attributes.Append(v_attrRECEIVEDATE)
            'Create SENDTIME
            v_attrSENDTIME = XMLDocumentMessage.CreateAttribute(gc_AtributeSENDTIME)
            v_attrSENDTIME.Value = pv_strSENDTIME
            dataElement.Attributes.Append(v_attrSENDTIME)
            'Create SENDDATE
            v_attrSENDDATE = XMLDocumentMessage.CreateAttribute(gc_AtributeSENDDATE)
            v_attrSENDDATE.Value = pv_strSENDDATE
            dataElement.Attributes.Append(v_attrSENDDATE)
            'Create TXNUM
            v_attrTXNUM = XMLDocumentMessage.CreateAttribute(gc_AtributeTXNUM)
            v_attrTXNUM.Value = pv_strTXNUM
            dataElement.Attributes.Append(v_attrTXNUM)
            'Create TXDATE
            v_attrTXDATE = XMLDocumentMessage.CreateAttribute(gc_AtributeTXDATE)
            v_attrTXDATE.Value = pv_strTXDATE
            dataElement.Attributes.Append(v_attrTXDATE)
            'Create TXTIME
            v_attrTXTIME = XMLDocumentMessage.CreateAttribute(gc_AtributeTXTIME)
            v_attrTXTIME.Value = pv_strTXTIME
            dataElement.Attributes.Append(v_attrTXTIME)
            'Create BRID
            v_attrBRID = XMLDocumentMessage.CreateAttribute(gc_AtributeBRID)
            v_attrBRID.Value = pv_strBRID
            dataElement.Attributes.Append(v_attrBRID)
            'Create TLID
            v_attrTLID = XMLDocumentMessage.CreateAttribute(gc_AtributeTLID)
            v_attrTLID.Value = pv_strTLID
            dataElement.Attributes.Append(v_attrTLID)
            'Create OFFID
            v_attrOFFID = XMLDocumentMessage.CreateAttribute(gc_AtributeOFFID)
            v_attrOFFID.Value = pv_strOFFID
            dataElement.Attributes.Append(v_attrOFFID)
            'Create CHID
            v_attrCHID = XMLDocumentMessage.CreateAttribute(gc_AtributeCHID)
            v_attrCHID.Value = pv_strCHID
            dataElement.Attributes.Append(v_attrCHID)
            'Create CHKID
            v_attrCHKID = XMLDocumentMessage.CreateAttribute(gc_AtributeCHKID)
            v_attrCHKID.Value = pv_strCHKID
            dataElement.Attributes.Append(v_attrCHKID)
            'Create TLTXCD
            v_attrTLTXCD = XMLDocumentMessage.CreateAttribute(gc_AtributeTLTXCD)
            v_attrTLTXCD.Value = pv_strTLTXCD
            dataElement.Attributes.Append(v_attrTLTXCD)
            'Create BRDATE
            v_attrBRDATE = XMLDocumentMessage.CreateAttribute(gc_AtributeBRDATE)
            v_attrBRDATE.Value = pv_strBRDATE
            dataElement.Attributes.Append(v_attrBRDATE)
            'Create BUSDATE
            v_attrBUSDATE = XMLDocumentMessage.CreateAttribute(gc_AtributeBUSDATE)
            v_attrBUSDATE.Value = pv_strBUSDATE
            dataElement.Attributes.Append(v_attrBUSDATE)
            'Create TXCODE
            v_attrTXCODE = XMLDocumentMessage.CreateAttribute(gc_AtributeTXCODE)
            v_attrTXCODE.Value = pv_strTXCODE
            dataElement.Attributes.Append(v_attrTXCODE)
            'Create ACCTNO
            v_attrACCTNO = XMLDocumentMessage.CreateAttribute(gc_AtributeACCTNO)
            v_attrACCTNO.Value = pv_strACCTNO
            dataElement.Attributes.Append(v_attrACCTNO)
            'Create ACCTNO2
            v_attrACCTNO2 = XMLDocumentMessage.CreateAttribute(gc_AtributeACCTNO2)
            v_attrACCTNO2.Value = pv_strACCTNO2
            dataElement.Attributes.Append(v_attrACCTNO2)
            'Create BANKCODE
            v_attrBANKCODE = XMLDocumentMessage.CreateAttribute(gc_AtributeBANKCODE)
            v_attrBANKCODE.Value = pv_strBANKCODE
            dataElement.Attributes.Append(v_attrBANKCODE)
            'Create BANKERRNUM
            v_attrBANKERRNUM = XMLDocumentMessage.CreateAttribute(gc_AtributeBANKERRNUM)
            v_attrBANKERRNUM.Value = pv_strBANKERRNUM
            dataElement.Attributes.Append(v_attrBANKERRNUM)
            'Create BANKERRDESC
            v_attrBANKERRDESC = XMLDocumentMessage.CreateAttribute(gc_AtributeBANKERRDESC)
            v_attrBANKERRDESC.Value = pv_strBANKERRDESC
            dataElement.Attributes.Append(v_attrBANKERRDESC)
            'Create BANKREF
            v_attrBANKREF = XMLDocumentMessage.CreateAttribute(gc_AtributeBANKREF)
            v_attrBANKREF.Value = pv_strBANKREF
            dataElement.Attributes.Append(v_attrBANKREF)
            'Create ERRNUM
            v_attrERRNUM = XMLDocumentMessage.CreateAttribute(gc_AtributeERRNUM)
            v_attrERRNUM.Value = pv_strERRNUM
            dataElement.Attributes.Append(v_attrERRNUM)

            XMLDocumentMessage.AppendChild(dataElement)
            Return XMLDocumentMessage.InnerXml
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuildXMLTxMsg(Optional ByVal pv_strMSGTYPE As String = "T", _
                                    Optional ByVal pv_strLOCAL As String = "", _
                                    Optional ByVal pv_strTLTXCD As String = "", _
                                    Optional ByVal pv_strBRID As String = "", _
                                    Optional ByVal pv_strTLID As String = "", _
                                    Optional ByVal pv_strIPADDRESS As String = "", _
                                    Optional ByVal pv_strWSNAME As String = "", _
                                    Optional ByVal pv_strTXTYPE As String = "", _
                                    Optional ByVal pv_strNOSUBMIT As String = "", _
                                    Optional ByVal pv_strSTATUS As String = "0", _
                                    Optional ByVal pv_strDELTD As String = "N", _
                                    Optional ByVal pv_strOVRRQS As String = "", _
                                    Optional ByVal pv_strUPDATEMODE As String = "", _
                                    Optional ByVal pv_strOFFID As String = "", _
                                    Optional ByVal pv_strCHKID As String = "", _
                                    Optional ByVal pv_strCHID As String = "", _
                                    Optional ByVal pv_strIBT As String = "", _
                                    Optional ByVal pv_strBRID2 As String = "", _
                                    Optional ByVal pv_strTLID2 As String = "", _
                                    Optional ByVal pv_strTXDATE As String = "", _
                                    Optional ByVal pv_strTXTIME As String = "", _
                                    Optional ByVal pv_strTXNUM As String = "", _
                                    Optional ByVal pv_strBRDATE As String = "", _
                                    Optional ByVal pv_strBUSDATE As String = "", _
                                    Optional ByVal pv_strCCYUSAGE As String = "00", _
                                    Optional ByVal pv_strOFFLINE As String = "N", _
                                    Optional ByVal pv_strMSGSTS As String = "0", _
                                    Optional ByVal pv_strOVRSTS As String = "0", _
                                    Optional ByVal pv_strPRETRAN As String = "Y", _
                                    Optional ByVal pv_strDELALLOW As String = "Y", _
                                    Optional ByVal pv_strTXDESC As String = "", _
                                    Optional ByVal pv_strBATCHNAME As String = DAILY_TRANSACTION) As String
        Dim XMLDocumentMessage As New Xml.XmlDocument
        Try
            XMLDocumentMessage.LoadXml(gc_SCHEMA_TXMESSAGE_HEADER)
            Dim XMLNodeMessage As Xml.XmlNode = XMLDocumentMessage.SelectSingleNode(gc_SCHEMA_TXMESSAGE_ROOT)
            With XMLNodeMessage
                .Attributes(gc_AtributeMSGTYPE).Value = pv_strMSGTYPE
                'TIENPQ ADDED: Upgrade core
                .Attributes(gc_AtributeTXACTION).Value = "TXN"
                .Attributes(gc_AtributeTLTXCD).Value = pv_strTLTXCD
                .Attributes(gc_AtributeBRID).Value = pv_strBRID
                .Attributes(gc_AtributeTLID).Value = pv_strTLID
                .Attributes(gc_AtributeIPADDRESS).Value = pv_strIPADDRESS
                .Attributes(gc_AtributeWSNAME).Value = pv_strWSNAME
                .Attributes(gc_AtributeTXTYPE).Value = pv_strTXTYPE
                .Attributes(gc_AtributeNOSUBMIT).Value = pv_strNOSUBMIT
                .Attributes(gc_AtributeSTATUS).Value = pv_strSTATUS
                .Attributes(gc_AtributeDELTD).Value = pv_strDELTD
                .Attributes(gc_AtributeDELALLOW).Value = pv_strDELALLOW
                .Attributes(gc_AtributeOVRRQS).Value = pv_strOVRRQS
                .Attributes(gc_AtributeUPDATEMODE).Value = pv_strUPDATEMODE
                .Attributes(gc_AtributeLOCAL).Value = pv_strLOCAL
                .Attributes(gc_AtributeOFFID).Value = pv_strOFFID
                .Attributes(gc_AtributeCHKID).Value = pv_strCHKID
                .Attributes(gc_AtributeCHID).Value = pv_strCHID
                .Attributes(gc_AtributeIBT).Value = pv_strIBT
                .Attributes(gc_AtributeBRID2).Value = pv_strBRID2
                .Attributes(gc_AtributeTLID2).Value = pv_strTLID2
                .Attributes(gc_AtributeTXDATE).Value = pv_strTXDATE
                .Attributes(gc_AtributeTXTIME).Value = pv_strTXTIME
                .Attributes(gc_AtributeTXNUM).Value = pv_strTXNUM
                .Attributes(gc_AtributeBRDATE).Value = pv_strBRDATE
                .Attributes(gc_AtributeBUSDATE).Value = pv_strBUSDATE
                .Attributes(gc_AtributeCCYUSAGE).Value = pv_strCCYUSAGE
                .Attributes(gc_AtributeOFFLINE).Value = pv_strOFFLINE
                .Attributes(gc_AtributeMSGSTS).Value = pv_strMSGSTS
                .Attributes(gc_AtributeOVRSTS).Value = pv_strOVRSTS
                .Attributes(gc_AtributePRETRAN).Value = pv_strPRETRAN
                .Attributes(gc_AtributeBATCHNAME).Value = pv_strBATCHNAME
                .Attributes(gc_AtributeTXDESC).Value = pv_strTXDESC
                .Attributes(gc_AtributeCAREBY).Value = String.Empty
                'WARNING-ERROR
                .Attributes(gc_AtributeWARNING).Value = "Y"
                'locpt TFLEX.SA0002
                .Attributes(gc_AtributeSESSIONID).Value = SessionID
                .Attributes(gc_AtributeIPADDRESS).Value = GetIPAddress().ToString()
                .Attributes(gc_AtributeREQUESTID).Value = Guid.NewGuid().ToString()
            End With

            Return XMLDocumentMessage.InnerXml
        Catch ex As Exception
            Throw ex
        Finally
            XMLDocumentMessage = Nothing
        End Try
    End Function
    'trung.luu : ghep source tu FA qua
    'Public Function BuildXMLTxMsg(Optional ByVal pv_strMSGTYPE As String = "T", _
    '                                Optional ByVal pv_strLOCAL As String = "", _
    '                                Optional ByVal pv_strTLTXCD As String = "", _
    '                                Optional ByVal pv_strBRID As String = "", _
    '                                Optional ByVal pv_strTLID As String = "", _
    '                                Optional ByVal pv_strIPADDRESS As String = "", _
    '                                Optional ByVal pv_strWSNAME As String = "", _
    '                                Optional ByVal pv_strTXTYPE As String = "", _
    '                                Optional ByVal pv_strNOSUBMIT As String = "", _
    '                                Optional ByVal pv_strSTATUS As String = "0", _
    '                                Optional ByVal pv_strDELTD As String = "N", _
    '                                Optional ByVal pv_strOVRRQS As String = "", _
    '                                Optional ByVal pv_strUPDATEMODE As String = "", _
    '                                Optional ByVal pv_strOFFID As String = "", _
    '                                Optional ByVal pv_strCHKID As String = "", _
    '                                Optional ByVal pv_strCHID As String = "", _
    '                                Optional ByVal pv_strIBT As String = "", _
    '                                Optional ByVal pv_strBRID2 As String = "", _
    '                                Optional ByVal pv_strTLID2 As String = "", _
    '                                Optional ByVal pv_strTXDATE As String = "", _
    '                                Optional ByVal pv_strTXTIME As String = "", _
    '                                Optional ByVal pv_strTXNUM As String = "", _
    '                                Optional ByVal pv_strBRDATE As String = "", _
    '                                Optional ByVal pv_strBUSDATE As String = "", _
    '                                Optional ByVal pv_strCCYUSAGE As String = "00", _
    '                                Optional ByVal pv_strOFFLINE As String = "N", _
    '                                Optional ByVal pv_strMSGSTS As String = "0", _
    '                                Optional ByVal pv_strOVRSTS As String = "0", _
    '                                Optional ByVal pv_strPRETRAN As String = "Y", _
    '                                Optional ByVal pv_strDELALLOW As String = "Y", _
    '                                Optional ByVal pv_strTXDESC As String = "", _
    '                                Optional ByVal pv_strBATCHNAME As String = DAILY_TRANSACTION,
    '                                Optional ByVal pv_strTellerName As String = ""
    '                                                                           ) As String
    '    Dim XMLDocumentMessage As New Xml.XmlDocument
    '    Dim v_dataElement As Xml.XmlElement
    '    Try
    '        XMLDocumentMessage.LoadXml(gc_SCHEMA_TXMESSAGE_HEADER)
    '        Dim XMLNodeMessage As Xml.XmlNode = XMLDocumentMessage.SelectSingleNode(gc_SCHEMA_TXMESSAGE_ROOT)
    '        With XMLNodeMessage
    '            .Attributes(gc_AtributeMSGTYPE).Value = pv_strMSGTYPE
    '            'TIENPQ ADDED: Upgrade core
    '            .Attributes(gc_AtributeTXACTION).Value = "TXN"
    '            .Attributes(gc_AtributeTLTXCD).Value = pv_strTLTXCD
    '            .Attributes(gc_AtributeBRID).Value = pv_strBRID
    '            .Attributes(gc_AtributeTLID).Value = pv_strTLID
    '            .Attributes(gc_AtributeIPADDRESS).Value = pv_strIPADDRESS
    '            .Attributes(gc_AtributeWSNAME).Value = pv_strWSNAME
    '            .Attributes(gc_AtributeTXTYPE).Value = pv_strTXTYPE
    '            .Attributes(gc_AtributeNOSUBMIT).Value = pv_strNOSUBMIT
    '            .Attributes(gc_AtributeSTATUS).Value = pv_strSTATUS
    '            .Attributes(gc_AtributeDELTD).Value = pv_strDELTD
    '            .Attributes(gc_AtributeDELALLOW).Value = pv_strDELALLOW
    '            .Attributes(gc_AtributeOVRRQS).Value = pv_strOVRRQS
    '            .Attributes(gc_AtributeUPDATEMODE).Value = pv_strUPDATEMODE
    '            .Attributes(gc_AtributeLOCAL).Value = pv_strLOCAL
    '            .Attributes(gc_AtributeOFFID).Value = pv_strOFFID
    '            .Attributes(gc_AtributeCHKID).Value = pv_strCHKID
    '            .Attributes(gc_AtributeCHID).Value = pv_strCHID
    '            .Attributes(gc_AtributeIBT).Value = pv_strIBT
    '            .Attributes(gc_AtributeBRID2).Value = pv_strBRID2
    '            .Attributes(gc_AtributeTLID2).Value = pv_strTLID2
    '            .Attributes(gc_AtributeTXDATE).Value = pv_strTXDATE
    '            .Attributes(gc_AtributeTXTIME).Value = pv_strTXTIME
    '            .Attributes(gc_AtributeTXNUM).Value = pv_strTXNUM
    '            .Attributes(gc_AtributeBRDATE).Value = pv_strBRDATE
    '            .Attributes(gc_AtributeBUSDATE).Value = pv_strBUSDATE
    '            .Attributes(gc_AtributeCCYUSAGE).Value = pv_strCCYUSAGE
    '            .Attributes(gc_AtributeOFFLINE).Value = pv_strOFFLINE
    '            .Attributes(gc_AtributeMSGSTS).Value = pv_strMSGSTS
    '            .Attributes(gc_AtributeOVRSTS).Value = pv_strOVRSTS
    '            .Attributes(gc_AtributePRETRAN).Value = pv_strPRETRAN
    '            .Attributes(gc_AtributeBATCHNAME).Value = pv_strBATCHNAME
    '            .Attributes(gc_AtributeTXDESC).Value = pv_strTXDESC
    '            .Attributes(gc_AtributeCAREBY).Value = String.Empty
    '            'WARNING-ERROR
    '            .Attributes(gc_AtributeWARNING).Value = ""
    '            'locpt TFLEX.SA0002
    '            .Attributes(gc_AtributeSESSIONID).Value = SessionID
    '            .Attributes(gc_AtributeIPADDRESS).Value = GetIPAddress().ToString()
    '            .Attributes(gc_AtributeREQUESTID).Value = Guid.NewGuid().ToString()

    '        End With
    '        If Len(pv_strTellerName) > 0 Then
    '            v_dataElement = XMLDocumentMessage.CreateElement(Xml.XmlNodeType.Element, "username", "")
    '            v_dataElement.InnerText = pv_strTellerName
    '            XMLDocumentMessage.DocumentElement.AppendChild(v_dataElement)
    '        End If

    '        Return XMLDocumentMessage.InnerXml
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        XMLDocumentMessage = Nothing
    '    End Try
    'End Function
    Public Function BuildXMLRptMsg(Optional ByVal pv_strLocal As String = "", _
                                      Optional ByVal pv_strStoreProc As String = "", _
                                      Optional ByVal pv_strMsgType As String = "", _
                                      Optional ByVal pv_arrRptParam() As ReportParameters = Nothing, _
                                      Optional ByVal pv_intNumOfParam As Integer = 0) As String

        Try
            Dim XMLDocumentMessage As New XmlDocumentEx
            Dim dataElement As Xml.XmlElement
            Dim v_attrLocal As Xml.XmlAttribute, v_attrStoreProc As Xml.XmlAttribute
            Dim v_attrBRID, v_attrTLID, v_attrCMDID, v_attrREFNUM, v_attrACTIONFLAG, v_attrFUNCNAME As Xml.XmlAttribute
            Dim v_attrName As Xml.XmlAttribute, v_attrSize As Xml.XmlAttribute, v_attrType As Xml.XmlAttribute, v_attrValue As Xml.XmlAttribute
            Dim v_attrNumOfParam As Xml.XmlAttribute, v_attrMsgType As Xml.XmlAttribute

            dataElement = XMLDocumentMessage.CreateElement("ObjectMessage")

            If Len(pv_strLocal) > 0 Then
                v_attrLocal = XMLDocumentMessage.CreateAttribute(gc_AtributeLOCAL)
                v_attrLocal.Value = pv_strLocal
                dataElement.Attributes.Append(v_attrLocal)
            End If
            If Len(pv_strStoreProc) > 0 Then
                v_attrStoreProc = XMLDocumentMessage.CreateAttribute(gc_AtributeSTOREPROC)
                v_attrStoreProc.Value = pv_strStoreProc
                dataElement.Attributes.Append(v_attrStoreProc)
            End If
            If Len(pv_strMsgType) > 0 Then
                v_attrMsgType = XMLDocumentMessage.CreateAttribute(gc_AtributeMSGTYPE)
                v_attrMsgType.Value = pv_strMsgType
                dataElement.Attributes.Append(v_attrMsgType)
            End If

            'Create attributes for asynchronous report
            v_attrBRID = XMLDocumentMessage.CreateAttribute(gc_AtributeBRID)
            v_attrBRID.Value = String.Empty
            dataElement.Attributes.Append(v_attrBRID)
            v_attrTLID = XMLDocumentMessage.CreateAttribute(gc_AtributeTLID)
            v_attrTLID.Value = String.Empty
            dataElement.Attributes.Append(v_attrTLID)
            v_attrCMDID = XMLDocumentMessage.CreateAttribute(gc_AtributeCMDID)
            v_attrCMDID.Value = String.Empty
            dataElement.Attributes.Append(v_attrCMDID)
            v_attrREFNUM = XMLDocumentMessage.CreateAttribute(gc_AtributeREFERENCE)
            v_attrREFNUM.Value = String.Empty
            dataElement.Attributes.Append(v_attrREFNUM)
            v_attrACTIONFLAG = XMLDocumentMessage.CreateAttribute(gc_AtributeACTFLAG)
            v_attrACTIONFLAG.Value = String.Empty
            dataElement.Attributes.Append(v_attrACTIONFLAG)
            v_attrFUNCNAME = XMLDocumentMessage.CreateAttribute(gc_AtributeFUNCNAME)
            v_attrFUNCNAME.Value = String.Empty
            dataElement.Attributes.Append(v_attrFUNCNAME)

            If pv_intNumOfParam > 0 Then
                Dim i As Integer
                For i = 0 To pv_arrRptParam.Length - 1
                    If Len(pv_arrRptParam(i).ParamName) > 0 Then
                        v_attrName = XMLDocumentMessage.CreateAttribute(gc_AtributePARAM_NAME & i.ToString)
                        v_attrName.Value = pv_arrRptParam(i).ParamName
                        dataElement.Attributes.Append(v_attrName)
                    End If
                    If Len(pv_arrRptParam(i).ParamValue) > 0 Then
                        v_attrValue = XMLDocumentMessage.CreateAttribute(gc_AtributePARAM_VALUE & i.ToString)
                        v_attrValue.Value = pv_arrRptParam(i).ParamValue
                        dataElement.Attributes.Append(v_attrValue)
                    End If
                    If Len(pv_arrRptParam(i).ParamSize) > 0 Then
                        v_attrSize = XMLDocumentMessage.CreateAttribute(gc_AtributePARAM_SIZE & i.ToString)
                        v_attrSize.Value = pv_arrRptParam(i).ParamSize
                        dataElement.Attributes.Append(v_attrSize)
                    End If
                    If Len(pv_arrRptParam(i).ParamType) > 0 Then
                        v_attrType = XMLDocumentMessage.CreateAttribute(gc_AtributePARAM_TYPE & i.ToString)
                        v_attrType.Value = pv_arrRptParam(i).ParamType
                        dataElement.Attributes.Append(v_attrType)
                    End If
                Next

                v_attrNumOfParam = XMLDocumentMessage.CreateAttribute(gc_AtributeNUM_OF_PARAM)
                v_attrNumOfParam.Value = pv_intNumOfParam
                dataElement.Attributes.Append(v_attrNumOfParam)
            End If

            XMLDocumentMessage.AppendChild(dataElement)
            Return XMLDocumentMessage.InnerXml
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Function BuildXMLRptMsg(Optional ByVal pv_strLocal As String = "", _
    '                               Optional ByVal pv_strStoreProc As String = "", _
    '                               Optional ByVal pv_strMsgType As String = "", _
    '                               Optional ByVal pv_arrRptParam() As ReportParameters = Nothing, _
    '                               Optional ByVal pv_intNumOfParam As Integer = 0) As String

    '    Try
    '        Dim XMLDocumentMessage As New XmlDocumentEx
    '        Dim dataElement As Xml.XmlElement
    '        Dim v_attrLocal As Xml.XmlAttribute, v_attrStoreProc As Xml.XmlAttribute
    '        Dim v_attrName As Xml.XmlAttribute, v_attrSize As Xml.XmlAttribute, v_attrType As Xml.XmlAttribute, v_attrValue As Xml.XmlAttribute
    '        Dim v_attrNumOfParam As Xml.XmlAttribute, v_attrMsgType As Xml.XmlAttribute

    '        dataElement = XMLDocumentMessage.CreateElement("ObjectMessage")

    '        If Len(pv_strLocal) > 0 Then
    '            v_attrLocal = XMLDocumentMessage.CreateAttribute(gc_AtributeLOCAL)
    '            v_attrLocal.Value = pv_strLocal
    '            dataElement.Attributes.Append(v_attrLocal)
    '        End If
    '        If Len(pv_strStoreProc) > 0 Then
    '            v_attrStoreProc = XMLDocumentMessage.CreateAttribute(gc_AtributeSTOREPROC)
    '            v_attrStoreProc.Value = pv_strStoreProc
    '            dataElement.Attributes.Append(v_attrStoreProc)
    '        End If
    '        If Len(pv_strMsgType) > 0 Then
    '            v_attrMsgType = XMLDocumentMessage.CreateAttribute(gc_AtributeMSGTYPE)
    '            v_attrMsgType.Value = pv_strMsgType
    '            dataElement.Attributes.Append(v_attrMsgType)
    '        End If
    '        Dim i As Integer
    '        For i = 0 To pv_arrRptParam.Length - 1
    '            If Len(pv_arrRptParam(i).ParamName) > 0 Then
    '                v_attrName = XMLDocumentMessage.CreateAttribute(gc_AtributePARAM_NAME & i.ToString)
    '                v_attrName.Value = pv_arrRptParam(i).ParamName
    '                dataElement.Attributes.Append(v_attrName)
    '            End If
    '            If Len(pv_arrRptParam(i).ParamValue) > 0 Then
    '                v_attrValue = XMLDocumentMessage.CreateAttribute(gc_AtributePARAM_VALUE & i.ToString)
    '                v_attrValue.Value = pv_arrRptParam(i).ParamValue
    '                dataElement.Attributes.Append(v_attrValue)
    '            End If
    '            If Len(pv_arrRptParam(i).ParamSize) > 0 Then
    '                v_attrSize = XMLDocumentMessage.CreateAttribute(gc_AtributePARAM_SIZE & i.ToString)
    '                v_attrSize.Value = pv_arrRptParam(i).ParamSize
    '                dataElement.Attributes.Append(v_attrSize)
    '            End If
    '            If Len(pv_arrRptParam(i).ParamType) > 0 Then
    '                v_attrType = XMLDocumentMessage.CreateAttribute(gc_AtributePARAM_TYPE & i.ToString)
    '                v_attrType.Value = pv_arrRptParam(i).ParamType
    '                dataElement.Attributes.Append(v_attrType)
    '            End If
    '        Next

    '        If Len(pv_intNumOfParam) > 0 Then
    '            v_attrNumOfParam = XMLDocumentMessage.CreateAttribute(gc_AtributeNUM_OF_PARAM)
    '            v_attrNumOfParam.Value = pv_intNumOfParam
    '            dataElement.Attributes.Append(v_attrNumOfParam)
    '        End If

    '        XMLDocumentMessage.AppendChild(dataElement)
    '        Return XMLDocumentMessage.InnerXml
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function BuildXMLObjMsg(Optional ByVal pv_strTxDate As String = "", _
    '                                 Optional ByVal pv_strBranchId As String = "", _
    '                                 Optional ByVal pv_strTxTime As String = "", _
    '                                 Optional ByVal pv_strTellerId As String = "", _
    '                                 Optional ByVal pv_strLocal As String = "", _
    '                                 Optional ByVal pv_strMsgType As String = "", _
    '                                 Optional ByVal pv_strObjName As String = "", _
    '                                 Optional ByVal pv_strActionFlag As String = "", _
    '                                 Optional ByVal pv_strCmdInquiry As String = "", _
    '                                 Optional ByVal pv_strClause As String = "", _
    '                                 Optional ByVal pv_strFuncName As String = "", _
    '                                 Optional ByVal pv_strAutoId As String = "", _
    '                                 Optional ByVal pv_strTxNum As String = "", _
    '                                 Optional ByVal pv_strReference As String = "", _
    '                                 Optional ByVal pv_strReserver As String = "") As String
    '    Try
    '        Dim XMLDocumentMessage As New Xml.XmlDocument
    '        Dim dataElement As Xml.XmlElement
    '        Dim v_attrTxDate As Xml.XmlAttribute, v_attrTxTime As Xml.XmlAttribute, v_attrTLID As Xml.XmlAttribute, v_attrBRID As Xml.XmlAttribute
    '        Dim v_attrLocal As Xml.XmlAttribute, v_attrMsgType As Xml.XmlAttribute, v_attrObjName As Xml.XmlAttribute, v_attrActFlag As Xml.XmlAttribute
    '        Dim v_attrCmdInquiry As Xml.XmlAttribute, v_attrClause As Xml.XmlAttribute, v_attrFuncName As Xml.XmlAttribute, v_attrTxNum As Xml.XmlAttribute
    '        Dim v_attrAutoId As Xml.XmlAttribute, v_attrReference, v_attrReserver As Xml.XmlAttribute

    '        dataElement = XMLDocumentMessage.CreateElement("ObjectMessage")

    '        If Len(pv_strTxDate) > 0 Then
    '            v_attrTxDate = XMLDocumentMessage.CreateAttribute(gc_AtributeTXDATE)
    '            v_attrTxDate.Value = pv_strTxDate
    '            dataElement.Attributes.Append(v_attrTxDate)
    '        End If

    '        If Len(pv_strTxNum) > 0 Then
    '            v_attrTxNum = XMLDocumentMessage.CreateAttribute(gc_AtributeTXNUM)
    '            v_attrTxNum.Value = pv_strTxNum
    '            dataElement.Attributes.Append(v_attrTxNum)
    '        End If

    '        If Len(pv_strTxTime) > 0 Then
    '            v_attrTxTime = XMLDocumentMessage.CreateAttribute(gc_AtributeTXTIME)
    '            v_attrTxTime.Value = pv_strTxTime
    '            dataElement.Attributes.Append(v_attrTxTime)
    '        End If

    '        If Len(pv_strTellerId) > 0 Then
    '            v_attrTLID = XMLDocumentMessage.CreateAttribute(gc_AtributeTLID)
    '            v_attrTLID.Value = pv_strTellerId
    '            dataElement.Attributes.Append(v_attrTLID)
    '        End If

    '        If Len(pv_strBranchId) > 0 Then
    '            v_attrBRID = XMLDocumentMessage.CreateAttribute(gc_AtributeBRID)
    '            v_attrBRID.Value = pv_strBranchId
    '            dataElement.Attributes.Append(v_attrBRID)
    '        End If

    '        If Len(pv_strLocal) > 0 Then
    '            v_attrLocal = XMLDocumentMessage.CreateAttribute(gc_AtributeLOCAL)
    '            v_attrLocal.Value = pv_strLocal
    '            dataElement.Attributes.Append(v_attrLocal)
    '        End If

    '        If Len(pv_strMsgType) > 0 Then
    '            v_attrMsgType = XMLDocumentMessage.CreateAttribute(gc_AtributeMSGTYPE)
    '            v_attrMsgType.Value = pv_strMsgType
    '            dataElement.Attributes.Append(v_attrMsgType)
    '        End If

    '        If Len(pv_strObjName) > 0 Then
    '            v_attrObjName = XMLDocumentMessage.CreateAttribute(gc_AtributeOBJNAME)
    '            v_attrObjName.Value = pv_strObjName
    '            dataElement.Attributes.Append(v_attrObjName)
    '        End If

    '        If Len(pv_strActionFlag) > 0 Then
    '            v_attrActFlag = XMLDocumentMessage.CreateAttribute(gc_AtributeACTFLAG)
    '            v_attrActFlag.Value = pv_strActionFlag
    '            dataElement.Attributes.Append(v_attrActFlag)
    '        End If

    '        If Len(pv_strCmdInquiry) > 0 Then
    '            v_attrCmdInquiry = XMLDocumentMessage.CreateAttribute(gc_AtributeCMDINQUIRY)
    '            v_attrCmdInquiry.Value = pv_strCmdInquiry
    '            dataElement.Attributes.Append(v_attrCmdInquiry)
    '        End If

    '        If Len(pv_strClause) > 0 Then
    '            v_attrClause = XMLDocumentMessage.CreateAttribute(gc_AtributeCLAUSE)
    '            v_attrClause.Value = pv_strClause
    '            dataElement.Attributes.Append(v_attrClause)
    '        End If

    '        If Len(pv_strFuncName) > 0 Then
    '            v_attrFuncName = XMLDocumentMessage.CreateAttribute(gc_AtributeFUNCNAME)
    '            v_attrFuncName.Value = pv_strFuncName
    '            dataElement.Attributes.Append(v_attrFuncName)
    '        End If

    '        If Len(pv_strAutoId) > 0 Then
    '            v_attrAutoId = XMLDocumentMessage.CreateAttribute(gc_AtributeAUTOID)
    '            v_attrAutoId.Value = pv_strAutoId
    '            dataElement.Attributes.Append(v_attrAutoId)
    '        End If

    '        If Len(pv_strReference) > 0 Then
    '            v_attrReference = XMLDocumentMessage.CreateAttribute(gc_AtributeREFERENCE)
    '            v_attrReference.Value = pv_strReference
    '            dataElement.Attributes.Append(v_attrReference)
    '        End If

    '        If Len(pv_strReserver) > 0 Then
    '            v_attrReserver = XMLDocumentMessage.CreateAttribute(gc_AtributeRESERVER)
    '            v_attrReserver.Value = pv_strReserver
    '            dataElement.Attributes.Append(v_attrReserver)
    '        End If

    '        XMLDocumentMessage.AppendChild(dataElement)
    '        Return XMLDocumentMessage.InnerXml
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function BuildXMLObjMsg(Optional ByVal pv_strTxDate As String = "", _
                                   Optional ByVal pv_strBranchId As String = "", _
                                   Optional ByVal pv_strTxTime As String = "", _
                                   Optional ByVal pv_strTellerId As String = "", _
                                   Optional ByVal pv_strLocal As String = "", _
                                   Optional ByVal pv_strMsgType As String = "", _
                                   Optional ByVal pv_strObjName As String = "", _
                                   Optional ByVal pv_strActionFlag As String = "", _
                                   Optional ByVal pv_strCmdInquiry As String = "", _
                                   Optional ByVal pv_strClause As String = "", _
                                   Optional ByVal pv_strFuncName As String = "", _
                                   Optional ByVal pv_strAutoId As String = "", _
                                   Optional ByVal pv_strTxNum As String = "", _
                                   Optional ByVal pv_strReference As String = "", _
                                   Optional ByVal pv_strReserver As String = "", _
                                   Optional ByVal pv_strIPAddress As String = "", _
                                   Optional ByVal pv_strCmdType As String = "T", _
                                   Optional ByVal pv_strPrarentObjName As String = "", _
                                   Optional ByVal pv_strParentClause As String = "", _
                                   Optional ByVal pv_strUserLanguage As String = "VN") As String
        Dim XMLDocumentMessage As New Xml.XmlDocument
        Try
            XMLDocumentMessage.LoadXml(gc_SCHEMA_OBJMESSAGE_HEADER)
            Dim XmlNodeMessage As Xml.XmlNode = XMLDocumentMessage.SelectSingleNode(gc_SCHEMA_OBJMESSAGE_ROOT)
            With XmlNodeMessage
                .Attributes(gc_AtributeTXDATE).Value = pv_strTxDate
                .Attributes(gc_AtributeTXNUM).Value = pv_strTxNum
                .Attributes(gc_AtributeTXTIME).Value = pv_strTxTime
                .Attributes(gc_AtributeTLID).Value = pv_strTellerId
                .Attributes(gc_AtributeBRID).Value = pv_strBranchId
                .Attributes(gc_AtributeLOCAL).Value = pv_strLocal
                .Attributes(gc_AtributeMSGTYPE).Value = pv_strMsgType
                .Attributes(gc_AtributeOBJNAME).Value = pv_strObjName
                .Attributes(gc_AtributeACTFLAG).Value = pv_strActionFlag
                .Attributes(gc_AtributeCMDINQUIRY).Value = pv_strCmdInquiry
                .Attributes(gc_AtributeCLAUSE).Value = pv_strClause
                .Attributes(gc_AtributeFUNCNAME).Value = pv_strFuncName
                .Attributes(gc_AtributeAUTOID).Value = pv_strAutoId
                .Attributes(gc_AtributeREFERENCE).Value = pv_strReference
                .Attributes(gc_AtributeRESERVER).Value = pv_strReserver
                .Attributes(gc_AtributeIPADDRESS).Value = pv_strIPAddress
                .Attributes(gc_AtributeCMDTYPE).Value = pv_strCmdType
                .Attributes(gc_AtributePARENTOBJNAME).Value = pv_strPrarentObjName
                .Attributes(gc_AtributePARENTCLAUSE).Value = pv_strParentClause
                .Attributes(gc_AtributeUSERLANGUAGE).Value = pv_strUserLanguage    '03/10/2017 DieuNDA Song ngu
            End With

            Return XMLDocumentMessage.InnerXml
        Catch ex As Exception
            Throw ex
        Finally
            XMLDocumentMessage = Nothing
        End Try
    End Function

    'Public Function BuildXMLObjData(ByVal pv_ds As DataSet, _
    '                                ByRef pv_strObjectMessage As String, _
    '                                Optional ByVal pv_dsOldInput As DataSet = Nothing, _
    '                                Optional ByVal pv_intFlag As Integer = 1) As Long
    '    Dim v_XmlDocument As New Xml.XmlDocument
    '    Dim dataElement As Xml.XmlElement
    '    Dim entryNode As Xml.XmlNode
    '    Dim v_attrFLDNAME, v_attrFLDTYPE, v_attrOLDVAL As Xml.XmlAttribute


    '    v_XmlDocument.LoadXml(pv_strObjectMessage)

    '    Try
    '        If pv_intFlag = ExecuteFlag.AddNew Then
    '            If pv_ds.Tables(0).Rows.Count > 0 Then
    '                For v_int As Integer = 0 To pv_ds.Tables(0).Rows.Count - 1
    '                    dataElement = v_XmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

    '                    For v_intColumn As Integer = 0 To pv_ds.Tables(0).Columns.Count - 1
    '                        entryNode = v_XmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")

    '                        'Add field name
    '                        v_attrFLDNAME = v_XmlDocument.CreateAttribute("fldname")
    '                        v_attrFLDNAME.Value = pv_ds.Tables(0).Columns(v_intColumn).ColumnName
    '                        entryNode.Attributes.Append(v_attrFLDNAME)

    '                        'Add field type
    '                        v_attrFLDTYPE = v_XmlDocument.CreateAttribute("fldtype")
    '                        v_attrFLDTYPE.Value = pv_ds.Tables(0).Columns(v_intColumn).DataType.ToString
    '                        entryNode.Attributes.Append(v_attrFLDTYPE)

    '                        'Add current value
    '                        v_attrOLDVAL = v_XmlDocument.CreateAttribute("oldval")
    '                        If Not IsDBNull(pv_ds.Tables(0).Rows(v_int)(v_intColumn)) Then
    '                            If pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.name = GetType(System.DateTime).Name Then
    '                                v_attrOLDVAL.Value = Format(pv_ds.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE)
    '                            Else
    '                                v_attrOLDVAL.Value = CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
    '                            End If
    '                        End If
    '                        entryNode.Attributes.Append(v_attrOLDVAL)

    '                        'Set value
    '                        If Not IsDBNull(pv_ds.Tables(0).Rows(v_int)(v_intColumn)) Then
    '                            If pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name = GetType(System.DateTime).Name Then
    '                                entryNode.InnerText = Format(pv_ds.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE)
    '                            Else
    '                                entryNode.InnerText = CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
    '                            End If
    '                        End If

    '                        dataElement.AppendChild(entryNode)
    '                    Next v_intColumn

    '                    v_XmlDocument.DocumentElement.AppendChild(dataElement)
    '                Next v_int
    '            End If
    '        ElseIf pv_intFlag = ExecuteFlag.Edit Then
    '            If pv_dsOldInput.Tables(0).Rows.Count > 0 Then
    '                For v_int As Integer = 0 To pv_dsOldInput.Tables(0).Rows.Count - 1
    '                    dataElement = v_XmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

    '                    For v_intColumn As Integer = 0 To pv_dsOldInput.Tables(0).Columns.Count - 1
    '                        entryNode = v_XmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")

    '                        'Add field name
    '                        v_attrFLDNAME = v_XmlDocument.CreateAttribute("fldname")
    '                        v_attrFLDNAME.Value = pv_dsOldInput.Tables(0).Columns(v_intColumn).ColumnName
    '                        entryNode.Attributes.Append(v_attrFLDNAME)

    '                        'Add field type
    '                        v_attrFLDTYPE = v_XmlDocument.CreateAttribute("fldtype")
    '                        v_attrFLDTYPE.Value = pv_dsOldInput.Tables(0).Columns(v_intColumn).DataType.ToString
    '                        entryNode.Attributes.Append(v_attrFLDTYPE)

    '                        'Add current value
    '                        v_attrOLDVAL = v_XmlDocument.CreateAttribute("oldval")
    '                        If Not IsDBNull(pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn)) Then
    '                            v_attrOLDVAL.Value = CStr(pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn))
    '                        End If
    '                        entryNode.Attributes.Append(v_attrOLDVAL)

    '                        'Set value
    '                        If Not IsDBNull(pv_ds.Tables(0).Rows(v_int)(v_intColumn)) Then
    '                            entryNode.InnerText = CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
    '                        End If

    '                        dataElement.AppendChild(entryNode)
    '                    Next v_intColumn

    '                    v_XmlDocument.DocumentElement.AppendChild(dataElement)
    '                Next v_int
    '            End If
    '        Else
    '            If pv_ds.Tables(0).Rows.Count > 0 Then
    '                For v_intRow As Integer = 0 To pv_ds.Tables(0).Rows.Count - 1
    '                    dataElement = v_XmlDocument.CreateElement(Xml.XmlNodeType.Element, "ObjData", "")

    '                    For v_intColumn As Integer = 0 To pv_ds.Tables(0).Columns.Count - 1
    '                        entryNode = v_XmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")

    '                        'Add field name
    '                        v_attrFLDNAME = v_XmlDocument.CreateAttribute("fldname")
    '                        v_attrFLDNAME.Value = pv_ds.Tables(0).Columns(v_intColumn).ColumnName
    '                        entryNode.Attributes.Append(v_attrFLDNAME)

    '                        'Add field type
    '                        v_attrFLDTYPE = v_XmlDocument.CreateAttribute("fldtype")
    '                        v_attrFLDTYPE.Value = pv_ds.Tables(0).Columns(v_intColumn).DataType.ToString
    '                        entryNode.Attributes.Append(v_attrFLDTYPE)

    '                        'Add current value
    '                        v_attrOLDVAL = v_XmlDocument.CreateAttribute("oldval")
    '                        If Not IsDBNull(pv_ds.Tables(0).Rows(v_intRow)(v_intColumn)) Then
    '                            v_attrOLDVAL.Value = CStr(pv_ds.Tables(0).Rows(v_intRow)(v_intColumn))
    '                        End If
    '                        entryNode.Attributes.Append(v_attrOLDVAL)

    '                        'Set value
    '                        If Not IsDBNull(pv_ds.Tables(0).Rows(v_intRow)(v_intColumn)) Then
    '                            entryNode.InnerText = CStr(pv_ds.Tables(0).Rows(v_intRow)(v_intColumn))
    '                        End If

    '                        dataElement.AppendChild(entryNode)
    '                    Next

    '                    v_XmlDocument.DocumentElement.AppendChild(dataElement)
    '                Next v_intRow
    '            End If
    '        End If

    '        pv_strObjectMessage = v_XmlDocument.InnerXml
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function BuildXMLObjData(ByVal pv_ds As DataSet, _
                                  ByRef pv_strObjectMessage As String, _
                                  Optional ByVal pv_dsOldInput As DataSet = Nothing, _
                                  Optional ByVal pv_intFlag As Integer = 1, _
                                    Optional ByVal pv_intFromRow As Integer = 1, _
                                   Optional ByVal pv_intToRow As Integer = 9999999) As Long
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
                                    v_strXMLBuilder.Append(Format(pv_ds.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE))
                                Else
                                    If InStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name, GetType(System.Byte).Name) > 0 Then
                                        'Code o day ty nua
                                        v_strValue = Convert.ToBase64String(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
                                    Else
                                        'Code o day ty nua
                                        v_strValue = CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
                                        v_strValue = v_strValue.Replace("&", "&amp;")
                                        v_strValue = v_strValue.Replace("'", "&apos;")
                                        v_strValue = v_strValue.Replace("""", "&quot;")
                                        v_strValue = v_strValue.Replace("<", "&lt;")
                                        v_strValue = v_strValue.Replace(">", "&gt;")
                                    End If
                                    v_strXMLBuilder.Append(v_strValue)
                                    'v_strXMLBuilder.Append(CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn)))
                                End If
                            End If
                            v_strXMLBuilder.Append("'>")
                            If Not IsDBNull(pv_ds.Tables(0).Rows(v_int)(v_intColumn)) Then
                                If pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name = GetType(System.DateTime).Name _
                                    And pv_intFlag = ExecuteFlag.AddNew Then
                                    v_strXMLBuilder.Append(Format(pv_ds.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE))
                                Else
                                    If InStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name, GetType(System.Byte).Name) > 0 Then
                                        'Code o day ty nua
                                        v_strValue = Convert.ToBase64String(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
                                    Else
                                        'Code o day ty nua
                                        v_strValue = CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
                                        v_strValue = v_strValue.Replace("&", "&amp;")
                                        v_strValue = v_strValue.Replace("'", "&apos;")
                                        v_strValue = v_strValue.Replace("""", "&quot;")
                                        v_strValue = v_strValue.Replace("<", "&lt;")
                                        v_strValue = v_strValue.Replace(">", "&gt;")
                                    End If
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
                                    And pv_intFlag = ExecuteFlag.Edit Then
                                    v_strXMLBuilder.Append(Format(pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE))
                                Else
                                    If InStr(pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn).GetType.Name, GetType(System.Byte).Name) > 0 Then
                                        'Code o day ty nua
                                        'v_strValue = Convert.ToBase64String(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
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
                            End If
                            v_strXMLBuilder.Append("'>")
                            If Not IsDBNull(pv_ds.Tables(0).Rows(v_int)(v_intColumn)) Then
                                If pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name = GetType(System.DateTime).Name _
                                    And pv_intFlag = ExecuteFlag.Edit Then
                                    v_strXMLBuilder.Append(Format(pv_ds.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE))
                                Else
                                    If InStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name, GetType(System.Byte).Name) > 0 Then
                                        'Code o day ty nua
                                        v_strValue = Convert.ToBase64String(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
                                    Else
                                        'Code o day ty nua
                                        v_strValue = CStr(pv_ds.Tables(0).Rows(v_int)(v_intColumn))
                                        v_strValue = v_strValue.Replace("&", "&amp;")
                                        v_strValue = v_strValue.Replace("'", "&apos;")
                                        v_strValue = v_strValue.Replace("""", "&quot;")
                                        v_strValue = v_strValue.Replace("<", "&lt;")
                                        v_strValue = v_strValue.Replace(">", "&gt;")
                                    End If
                                    v_strXMLBuilder.Append(v_strValue)
                                End If
                            Else
                                'Lay lai gia tri cu
                                If pv_ds.Tables(0).Rows(v_int)(v_intColumn).GetType.Name = GetType(System.DateTime).Name _
                                    And pv_intFlag = ExecuteFlag.Edit Then
                                    v_strXMLBuilder.Append(Format(pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn), gc_FORMAT_DATE))
                                Else
                                    If Not IsDBNull((pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn))) Then
                                        If InStr(pv_dsOldInput.Tables(0).Rows(v_int)(v_intColumn).GetType.Name, GetType(System.Byte).Name) > 0 Then
                                            'Code o day ty nua
                                            v_strValue = Nothing
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

    Public Function SerializeObject(ByVal obj As Object) As String
        Dim serializer = New XmlSerializer(obj.[GetType]())

        Using writer = New StringWriter()
            serializer.Serialize(writer, obj)

            Return writer.ToString()
        End Using
    End Function
    Public Function BuildXMLErrorException(ByRef pv_xmlDocument As Xml.XmlDocument, _
                                           ByVal pv_strErrorSource As String, _
                                           ByVal pv_lngErrorCode As Long, _
                                           ByVal pv_strErrorMessage As String) As Long
        Dim dataElement As Xml.XmlElement
        Dim entryNode As Xml.XmlNode
        Dim v_attrFLDNAME, v_attrFLDTYPE, v_attrOLDVAL As Xml.XmlAttribute

        Try
            If pv_strErrorSource Is Nothing Then pv_strErrorSource = String.Empty
            If pv_strErrorMessage Is Nothing Then pv_strErrorMessage = String.Empty
            Dim v_nodeGenChecking As Xml.XmlNode
            'Xoa Exception node neu tao Exception node moi
            v_nodeGenChecking = pv_xmlDocument.SelectSingleNode("/TransactMessage/ErrorException")
            If Not v_nodeGenChecking Is Nothing Then
                'Return ERR_SYSTEM_OK
                pv_xmlDocument.DocumentElement.RemoveChild(v_nodeGenChecking)
            End If
            dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ErrorException", "")

            entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            'Add field name
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "ERRSOURCE"
            entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrFLDTYPE = pv_xmlDocument.CreateAttribute("fldtype")
            v_attrFLDTYPE.Value = pv_strErrorSource.GetType().ToString()
            entryNode.Attributes.Append(v_attrFLDTYPE)
            'Add current value
            v_attrOLDVAL = pv_xmlDocument.CreateAttribute("oldval")
            If pv_strErrorSource.Length > 0 Then
                v_attrOLDVAL.Value = pv_strErrorSource
            End If
            entryNode.Attributes.Append(v_attrOLDVAL)
            'Set value
            If pv_strErrorSource.Length > 0 Then
                entryNode.InnerText = pv_strErrorSource
            End If
            dataElement.AppendChild(entryNode)

            entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            'Add field name
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "ERRCODE"
            entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrFLDTYPE = pv_xmlDocument.CreateAttribute("fldtype")
            v_attrFLDTYPE.Value = pv_lngErrorCode.GetType().ToString()
            entryNode.Attributes.Append(v_attrFLDTYPE)
            'Add current value
            v_attrOLDVAL = pv_xmlDocument.CreateAttribute("oldval")
            If pv_lngErrorCode <> 0 Then
                v_attrOLDVAL.Value = pv_lngErrorCode.ToString()
            End If
            entryNode.Attributes.Append(v_attrOLDVAL)
            'Set value
            If pv_lngErrorCode <> 0 Then
                entryNode.InnerText = pv_lngErrorCode.ToString()
            End If
            dataElement.AppendChild(entryNode)

            entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            'Add field name
            v_attrFLDNAME = pv_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "ERRMSG"
            entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrFLDTYPE = pv_xmlDocument.CreateAttribute("fldtype")
            v_attrFLDTYPE.Value = pv_strErrorMessage.GetType().ToString()
            entryNode.Attributes.Append(v_attrFLDTYPE)
            'Add current value
            v_attrOLDVAL = pv_xmlDocument.CreateAttribute("oldval")
            If pv_strErrorMessage.Length > 0 Then
                v_attrOLDVAL.Value = pv_strErrorMessage
            End If
            entryNode.Attributes.Append(v_attrOLDVAL)
            'Set value
            If pv_strErrorMessage.Length > 0 Then
                entryNode.InnerText = pv_strErrorMessage
            End If
            dataElement.AppendChild(entryNode)

            pv_xmlDocument.DocumentElement.AppendChild(dataElement)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReplaceXMLErrorException(ByRef pv_strMessage As String, _
                                             ByVal pv_strErrorSource As String, _
                                             ByVal pv_lngErrorCode As Long, _
                                             ByVal pv_strErrorMessage As String) As Long
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_oldElement, dataElement As Xml.XmlElement
        Dim entryNode As Xml.XmlNode
        Dim v_attrFLDNAME, v_attrFLDTYPE, v_attrOLDVAL As Xml.XmlAttribute

        Try
            If pv_strErrorSource Is Nothing Then pv_strErrorSource = String.Empty
            If pv_strErrorMessage Is Nothing Then pv_strErrorMessage = String.Empty

            v_xmlDocument.LoadXml(pv_strMessage)
            v_oldElement = v_xmlDocument.DocumentElement.GetElementsByTagName("ErrorException").Item(0)
            If v_oldElement Is Nothing Then
                'Táº¡o má»›i node ErrorExeption
                v_oldElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ErrorException", "")
                v_xmlDocument.DocumentElement.AppendChild(v_oldElement)
            End If

            dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "ErrorException", "")

            entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            'Add field name
            v_attrFLDNAME = v_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "ERRSOURCE"
            entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrFLDTYPE = v_xmlDocument.CreateAttribute("fldtype")
            v_attrFLDTYPE.Value = pv_strErrorSource.GetType().ToString()
            entryNode.Attributes.Append(v_attrFLDTYPE)
            'Add current value
            v_attrOLDVAL = v_xmlDocument.CreateAttribute("oldval")
            If pv_strErrorSource.Length > 0 Then
                v_attrOLDVAL.Value = pv_strErrorSource
            End If
            entryNode.Attributes.Append(v_attrOLDVAL)
            'Set value
            If pv_strErrorSource.Length > 0 Then
                entryNode.InnerText = pv_strErrorSource
            End If
            dataElement.AppendChild(entryNode)

            entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            'Add field name
            v_attrFLDNAME = v_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "ERRCODE"
            entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrFLDTYPE = v_xmlDocument.CreateAttribute("fldtype")
            v_attrFLDTYPE.Value = pv_lngErrorCode.GetType().ToString()
            entryNode.Attributes.Append(v_attrFLDTYPE)
            'Add current value
            v_attrOLDVAL = v_xmlDocument.CreateAttribute("oldval")
            If pv_lngErrorCode <> 0 Then
                v_attrOLDVAL.Value = pv_lngErrorCode.ToString()
            End If
            entryNode.Attributes.Append(v_attrOLDVAL)
            'Set value
            If pv_lngErrorCode <> 0 Then
                entryNode.InnerText = pv_lngErrorCode.ToString()
            End If
            dataElement.AppendChild(entryNode)

            entryNode = v_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
            'Add field name
            v_attrFLDNAME = v_xmlDocument.CreateAttribute("fldname")
            v_attrFLDNAME.Value = "ERRMSG"
            entryNode.Attributes.Append(v_attrFLDNAME)
            'Add field type
            v_attrFLDTYPE = v_xmlDocument.CreateAttribute("fldtype")
            v_attrFLDTYPE.Value = pv_strErrorMessage.GetType().ToString()
            entryNode.Attributes.Append(v_attrFLDTYPE)
            'Add current value
            v_attrOLDVAL = v_xmlDocument.CreateAttribute("oldval")
            If pv_strErrorMessage.Length > 0 Then
                v_attrOLDVAL.Value = pv_strErrorMessage
            End If
            entryNode.Attributes.Append(v_attrOLDVAL)
            'Set value
            If pv_strErrorMessage.Length > 0 Then
                entryNode.InnerText = pv_strErrorMessage
            End If
            dataElement.AppendChild(entryNode)

            'Thay node ErrorExeption cÅ©
            v_xmlDocument.DocumentElement.ReplaceChild(dataElement, v_oldElement)

            pv_strMessage = v_xmlDocument.InnerXml
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '----------------------------------------------------------------------------------------------
    'Kiểm tra tính hợp lệ của CustodyCode
    'v_blnDORF=TRUE nhà đầu tư nước ngoài, FALSE là trong nước
    'v_blnIOC=TRUE nhà đầu tư cá nhân, FALSE là tổ chức
    '----------------------------------------------------------------------------------------------
    Public Function VerifyCustodyCode(ByVal v_strCustodyCode As String, _
        ByVal v_blnDORF As Boolean, ByVal v_blnIOC As Boolean, ByVal v_strCustAtCom As String, Optional ByVal v_strPrefix As String = "OTC", Optional ByVal v_intExeFlag As Integer = ExecuteFlag.Edit) As String
        Dim v_strErrorMessage As String = String.Empty
        Dim v_strPREFIXED, v_strPCFLAG, v_strRUNNINGNUMBER, v_strIORC, v_strPrefixedStandard As String
        '?�ộ dài phải là 10 ký tự
        If v_strCustodyCode.Length <> 10 Then
            v_strErrorMessage = "CUSTODYCD_INVALID_LENGTH"
            Return v_strErrorMessage
        End If
        'Chỉ kiểm tra tính hợp lệ nếu 03 ký tự đầu là 017
        v_strPREFIXED = v_strCustodyCode.Substring(0, 3)
        v_strPrefixedStandard = AppSettings.Get("PrefixedCustodyCode")
        v_strPCFLAG = v_strCustodyCode.Substring(3, 1)
        ' PhuongHT comment
        ' If String.Compare(v_strPREFIXED, v_strPrefix) = 0 Then
        ' end of PhuongHT comment
        ' neu la luu ky tai SHV
        If String.Compare(v_strCustAtCom, "Y") = 0 Then
            '  3 ki tu dau phai la ma thanh vien luu ky cua cong ty chung khoan
            'If (String.Compare(v_strPREFIXED, v_strPrefixedStandard) <> 0) Then
            '    v_strErrorMessage = "CUSTODYCD_PREFIX_MUST_BE_COMPANY_STANDARD"
            '    Return v_strErrorMessage
            'End If
            'PCFLAG phải lấy 1 trong 4 giá trị sau: A, B, E, F. PCFLAG là ký tự thứ 4

            If Not (String.Compare(v_strPCFLAG, "A") = 0 Or String.Compare(v_strPCFLAG, "B") = 0 Or String.Compare(v_strPCFLAG, "C") = 0 _
                Or String.Compare(v_strPCFLAG, "E") = 0 Or String.Compare(v_strPCFLAG, "F") = 0) Then
                v_strErrorMessage = "CUSTODYCD_INVALID_PCFLAG"
                Return v_strErrorMessage
            Else
                'Nếu là nước ngoài thì PCFLAG phải là F. PCFLAG là ký tự thứ 4
                If v_blnDORF Then
                    If String.Compare(v_strPCFLAG, "F") <> 0 Then
                        v_strErrorMessage = "CUSTODYCD_COMPANY_PCFLAG_EQUAL_F"
                        Return v_strErrorMessage
                    Else
                        'Ki tu thu 5 phai la 1 ki tu chu
                        v_strIORC = v_strCustodyCode.Substring(4, 2)
                        v_strRUNNINGNUMBER = v_strCustodyCode.Substring(6, 4)
                        If Not ((String.Compare(v_strIORC.Substring(0, 1), "I") OrElse String.Compare(v_strIORC.Substring(0, 1), "C")) AndAlso Char.IsLetter(v_strIORC, 1)) Then
                            If v_intExeFlag = ExecuteFlag.AddNew Then
                                v_strErrorMessage = "CUSTODYCD_FOREIGN_CHARACTER"
                                Return v_strErrorMessage
                            End If
                            'Else
                            '    If Not IsNumeric(v_strRUNNINGNUMBER) Then
                            '        v_strErrorMessage = "CUSTODYCD_RUNNINGNUMBER_INVALID"
                            '        Return v_strErrorMessage
                            '    End If
                        End If
                    End If
                Else
                    If String.Compare(v_strPCFLAG, "F") = 0 Then
                        'Nhà đầu tư trong nước thì không thể có PCFLAG là F
                        v_strErrorMessage = "CUSTODYCD_COMPANY_PCFLAG_NOT_EQUAL_F"
                        Return v_strErrorMessage
                        'Else
                        '    v_strRUNNINGNUMBER = v_strCustodyCode.Substring(4, 6)
                        '    If Not IsNumeric(v_strRUNNINGNUMBER) Then
                        '        v_strErrorMessage = "CUSTODYCD_6RUNNINGNUMBER_INVALID"
                        '        Return v_strErrorMessage
                        '    End If
                    End If
                End If
            End If
        Else
            ' neu la luu ky tai noi khac
            ' neu la standard va khong co flag la F bao loi
            If (String.Compare(v_strPREFIXED, v_strPrefixedStandard) = 0 And String.Compare(v_strPCFLAG, "F") <> 0) Then
                v_strErrorMessage = "CUSTODYCD_PREFIX_MUST_BE_DIFF_COMPANY_STANDARD"
                Return v_strErrorMessage
            End If
        End If
    End Function


    '----------------------------------------------------------------------------------------------
    ' + Má»¥c Ä‘Ã­ch:   Láº¥y thÃ´ng tin lá»—i tá»« message tráº£ v?
    ' + ï¿½?ï¿½áº§u vÃ o:    
    '       - pv_strMessage:        Message tráº£ v?
    ' + ï¿½?ï¿½áº§u ra:
    '       - pv_strErrorSource:    Nguá»“n phÃ¡t sinh lá»—i, = "" náº¿u khÃ´ng cÃ³ lá»—i
    '       - pv_lngErrorCode:      MÃ£ lá»—i, = 0 náº¿u khÃ´ng cÃ³ lá»—i
    '       - pv_strErrorMessage:   ThÃ´ng bÃ¡o lá»—i, = "" náº¿u khÃ´ng cÃ³ lá»—i
    ' + Tráº£ v?:     NA
    ' + Tï¿½Ã¡c giáº£:    Tráº§n Ki?u Minh
    ' + Ghi chï¿½Ãº:    N/A
    '----------------------------------------------------------------------------------------------
    Public Function GetErrorFromMessage(ByVal pv_strMessage As String, _
                                        ByRef pv_strErrorSource As String, _
                                        ByRef pv_lngErrorCode As Long, _
                                        ByRef pv_strErrorMessage As String, _
                                        Optional ByVal pv_strLanguage As String = CommonLibrary.gc_LANG_ENGLISH) As Long
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_orginalErrorcode As Long = pv_lngErrorCode

        Try
            pv_strErrorSource = String.Empty
            pv_strErrorMessage = String.Empty
            v_xmlDocument.LoadXml(pv_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strMSGTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeMSGTYPE), Xml.XmlAttribute).Value)

            'XÃ¡c Ä‘á»‹nh loáº¡i message
            If (v_strMSGTYPE = gc_MsgTypeObj) Or (v_strMSGTYPE = gc_MsgTypeRpt) Or (v_strMSGTYPE = gc_MsgTypeProc) Then
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ErrorException")
            ElseIf v_strMSGTYPE = gc_MsgTypeTrans Then
                v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/ErrorException")
            End If

            'Láº¥y thÃ´ng tin lá»—i
            If Not v_nodeList Is Nothing Then
                If v_nodeList.Count > 0 Then 'CÃ³ thÃ´ng tin lá»—i
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString

                                Select Case Trim(v_strFLDNAME)
                                    Case "ERRSOURCE"
                                        pv_strErrorSource = Trim(v_strValue)
                                    Case "ERRCODE"
                                        pv_lngErrorCode = CLng(Trim(v_strValue))
                                    Case "ERRMSG"
                                        'pv_strErrorMessage = Trim(v_strValue)
                                        Dim v_strError() As String = v_strValue.Split(ControlChars.NewLine)

                                        If v_strError.Length > 1 Then
                                            pv_strErrorMessage = IIf(pv_strLanguage = CommonLibrary.gc_LANG_ENGLISH, v_strError(1), v_strError(0))
                                        Else
                                            pv_strErrorMessage = v_strValue
                                        End If
                                End Select
                            End With
                        Next
                    Next
                Else
                    pv_strErrorSource = String.Empty
                    pv_strErrorMessage = String.Empty
                End If
            End If

            'NamLP them doan nay de trong truong hop chuoi XML truyen vao co thong tin phai duyet lan 2, nhung khi bam chap nhan thi co loi, 
            'Doan code nay se khong cho loi duyet lan 2 de mat loi thuc te khi Chap nhan.
            If v_orginalErrorcode <> 0 AndAlso Len(v_orginalErrorcode) > 0 AndAlso pv_lngErrorCode <> v_orginalErrorcode Then
                pv_strErrorSource = String.Empty
                pv_strErrorMessage = String.Empty
                pv_lngErrorCode = v_orginalErrorcode
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '----------------------------------------------------------------------------------------------
    ' + Má»¥c Ä‘Ã­ch:   Láº¥y nguyÃªn nhÃ¢n duyá»‡t tá»« message tráº£ v?
    ' + ï¿½?ï¿½áº§u vÃ o:    
    '       - pv_strMessage:        Message tráº£ v?
    ' + ï¿½?ï¿½áº§u ra:
    '       - pv_strErrorMessage:   ThÃ´ng bÃ¡o lá»—i, = "" náº¿u khÃ´ng cÃ³ lá»—i
    ' + Tráº£ v?:     NA
    ' + Tï¿½Ã¡c giáº£:    Tráº§n Ki?u Minh
    ' + Ghi chï¿½Ãº:    N/A
    '----------------------------------------------------------------------------------------------
    Public Function GetReasonFromMessage(ByVal pv_strMessage As String, _
                                        ByRef pv_strErrorMessage As String, _
                                        Optional ByVal pv_strLanguage As String = CommonLibrary.gc_LANG_VIETNAMESE) As Long
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String

        Try
            v_xmlDocument.LoadXml(pv_strMessage)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            Dim v_strMSGTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeMSGTYPE), Xml.XmlAttribute).Value)

            'XÃ¡c Ä‘á»‹nh loáº¡i message
            If v_strMSGTYPE = gc_MsgTypeObj Then
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/checker")
            ElseIf v_strMSGTYPE = gc_MsgTypeTrans Then
                v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/checker")
            End If

            ''Láº¥y thÃ´ng tin nguyÃªn nhÃ¢n duyá»‡t
            'If v_nodeList.Count > 0 Then 'CÃ³ nguyÃªn nhÃ¢n duyá»‡t Ä‘i kÃ¨m
            '    For i As Integer = 0 To v_nodeList.Count - 1
            '        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
            '            pv_strErrorMessage = pv_strErrorMessage & ControlChars.CrLf & v_nodeList.Item(i).ChildNodes(j).InnerXml
            '        Next
            '    Next
            'End If
            '------------------------------------
            'Lay thong tin nguyen nhan duyet
            '------------------------------------
            If v_nodeList.Count > 0 Then 'CÃ³ nguyÃªn nhÃ¢n duyá»‡t Ä‘i kÃ¨m
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        'pv_strErrorMessage = pv_strErrorMessage & ControlChars.CrLf & v_nodeList.Item(i).ChildNodes(j).InnerXml
                        Dim v_strRequest() As String = v_nodeList.Item(i).ChildNodes(j).InnerXml.Split(ControlChars.NewLine)
                        If v_strRequest.Length > 1 Then
                            pv_strErrorMessage = pv_strErrorMessage & ControlChars.CrLf & IIf(pv_strLanguage = gc_LANG_ENGLISH, v_strRequest(1).Replace(ControlChars.NewLine, ""), v_strRequest(0))
                        Else
                            pv_strErrorMessage = pv_strErrorMessage & ControlChars.CrLf & v_nodeList.Item(i).ChildNodes(j).InnerXml
                        End If
                    Next
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function chkAddTier(ByVal pv_ds As DataSet, ByVal v_numFAMT As Decimal, ByVal v_numTOAMT As Decimal) As Long

        Try

            Dim v_numMin, v_numMax, v_numMaxFr As Decimal
            Dim v_blnCheckFr, v_blnCheckTo As Boolean



            If (v_numTOAMT <> -1 And v_numFAMT <> -1) And v_numFAMT >= v_numTOAMT Then
                Return ERR_SA_FAMT_TOAMT_CONFLICT
            End If


            v_blnCheckFr = False
            v_blnCheckTo = False
            v_numMin = 0
            v_numMax = 0
            v_numMaxFr = 0

            If pv_ds.Tables(0).Rows.Count > 0 Then

                'Fix so tien nho nhat = -1
                If v_numFAMT <= -1 Then
                    Return ERR_SA_FAMT_TOAMT_CONFLICT
                End If

                For i As Integer = 0 To pv_ds.Tables(0).Rows.Count - 1
                    If CDbl(pv_ds.Tables(0).Rows(i)("TOAMT")) = v_numFAMT Then
                        v_blnCheckFr = True
                        'Exit For
                    End If
                    If CDbl(pv_ds.Tables(0).Rows(i)("FRAMT")) = v_numFAMT Then
                        Return ERR_SA_FAMT_TOAMT_CONFLICT
                    End If
                Next

                For i As Integer = 0 To pv_ds.Tables(0).Rows.Count - 1

                    If CDbl(pv_ds.Tables(0).Rows(i)("TOAMT")) = v_numTOAMT Then
                        Return ERR_SA_FAMT_TOAMT_CONFLICT
                    End If
                    If CDbl(pv_ds.Tables(0).Rows(i)("FRAMT")) = v_numTOAMT Then
                        v_blnCheckTo = True
                    End If

                    If CDbl(pv_ds.Tables(0).Rows(i)("TOAMT")) > v_numMax Then
                        v_numMin = v_numMax
                        v_numMax = CDbl(pv_ds.Tables(0).Rows(i)("TOAMT"))
                    End If

                    If CDbl(pv_ds.Tables(0).Rows(i)("FRAMT")) > v_numMaxFr Then
                        v_numMaxFr = CDbl(pv_ds.Tables(0).Rows(i)("FRAMT"))
                    End If

                Next

                'And (v_numFAMT > v_numMax) 
                If (v_numMin <= v_numMaxFr) And (v_numMaxFr < v_numTOAMT) Then
                    v_blnCheckTo = True
                End If

                If v_blnCheckFr = False Or v_blnCheckTo = False Then
                    Return ERR_SA_FAMT_TOAMT_CONFLICT
                End If
            Else
                'Fix so tien nho nhat = -1
                If v_numFAMT <> -1 Then
                    Return ERR_SA_FAMT_TOAMT_CONFLICT
                End If
            End If

            Return ERR_SYSTEM_OK

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function chkEditTier(ByVal pv_ds As DataSet, ByVal v_numFAMT As Decimal, ByVal v_numTOAMT As Decimal) As Long

        Try

            Dim v_numMin, v_numMax, v_numMaxFr As Decimal
            Dim v_blnCheckFr, v_blnCheckTo As Boolean



            If (v_numTOAMT <> -1 And v_numFAMT <> -1) And v_numFAMT >= v_numTOAMT Then
                Return ERR_SA_FAMT_TOAMT_CONFLICT
            End If


            v_blnCheckFr = False
            v_blnCheckTo = False
            v_numMin = 0
            v_numMax = 0
            v_numMaxFr = 0

            If pv_ds.Tables(0).Rows.Count > 0 Then

                ''Fix so tien nho nhat = -1
                'If v_numFAMT <= -1 Then
                '    Return ERR_SA_FAMT_TOAMT_CONFLICT
                'End If

                For i As Integer = 0 To pv_ds.Tables(0).Rows.Count - 1
                    If CDbl(pv_ds.Tables(0).Rows(i)("TOAMT")) = v_numFAMT Then
                        v_blnCheckFr = True
                        'Exit For
                    End If

                Next
                v_numMin = 0
                v_numMax = 0
                For i As Integer = 0 To pv_ds.Tables(0).Rows.Count - 1

                    If CDbl(pv_ds.Tables(0).Rows(i)("FRAMT")) = v_numTOAMT Then
                        v_blnCheckTo = True
                    End If

                    If CDbl(pv_ds.Tables(0).Rows(i)("TOAMT")) > v_numMax Then
                        v_numMin = v_numMax
                        v_numMax = CDbl(pv_ds.Tables(0).Rows(i)("TOAMT"))
                    End If

                    If CDbl(pv_ds.Tables(0).Rows(i)("FRAMT")) > v_numMaxFr Then
                        v_numMaxFr = CDbl(pv_ds.Tables(0).Rows(i)("FRAMT"))
                    End If

                Next

                If (v_numMin = v_numFAMT) And (v_numTOAMT > v_numMin) Then
                    v_blnCheckTo = True
                End If

                If v_numFAMT = -1 And v_blnCheckTo = True Then
                    v_blnCheckFr = True
                End If
                If v_blnCheckFr = False Or v_blnCheckTo = False Then
                    Return ERR_SA_FAMT_TOAMT_CONFLICT
                End If

            Else
                'Fix so tien nho nhat = -1
                If v_numFAMT <> -1 Then
                    Return ERR_SA_FAMT_TOAMT_CONFLICT
                End If
            End If

            Return ERR_SYSTEM_OK

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function chkDeleteTier(ByVal pv_ds As DataSet, ByVal v_numFAMT As Decimal, ByVal v_numTOAMT As Decimal) As Long

        Try

            Dim v_numMin, v_numMax, v_numMaxFr As Decimal
            Dim v_blnCheckFr, v_blnCheckTo As Boolean

            If pv_ds.Tables(0).Rows.Count > 0 Then

                v_numMin = 0
                v_numMax = 0
                For i As Integer = 0 To pv_ds.Tables(0).Rows.Count - 1
                    If CDbl(pv_ds.Tables(0).Rows(i)("TOAMT")) > v_numMax Then
                        v_numMax = CDbl(pv_ds.Tables(0).Rows(i)("TOAMT"))
                    End If
                Next


                If v_numTOAMT <> v_numMax Then
                    Return ERR_SA_CAN_NOT_DELELE
                End If

            End If

            Return ERR_SYSTEM_OK

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetConfigValue(ByVal configName As String, ByVal defVal As String) As String
        Dim v_strKeyVal As String = String.Empty

        Try
            v_strKeyVal = ConfigurationSettings.AppSettings(configName)
        Catch ex As Exception
            v_strKeyVal = defVal
        End Try

        If v_strKeyVal = String.Empty Then
            v_strKeyVal = defVal
        End If

        Return v_strKeyVal
    End Function

    Public Function RenderTableToXml(ByVal pv_dt As DataTable, ByVal pv_strTableName As String) As String
        Dim v_strRet As New StringBuilder()
        Dim v_strVal As String = ""
        If Not pv_dt Is Nothing Then
            For i As Integer = 0 To pv_dt.Rows.Count - 1
                v_strRet.Append("<" & pv_strTableName & ">")
                For j As Integer = 0 To pv_dt.Columns.Count - 1
                    If Not pv_dt.Rows(i)(j) Is DBNull.Value Then
                        If pv_dt.Columns(j).DataType.FullName = "System.DateTime" Or pv_dt.Columns(j).DataType.FullName = "System.Date" Then
                            v_strVal = CType(pv_dt.Rows(i)(j), DateTime).ToString("dd/MM/yyyy")
                        Else
                            v_strVal = pv_dt.Rows(i)(j).ToString()
                        End If
                        If v_strVal.IndexOf("%") >= 0 Or v_strVal.IndexOf(">") >= 0 Or v_strVal.IndexOf("<") >= 0 Then
                            v_strVal = "<![CDATA[" & v_strVal & "]]>"
                        End If
                    Else
                        v_strVal = ""
                    End If
                    v_strRet.Append("<field name=""" & pv_dt.Columns(j).ColumnName.ToUpper() & """ type=""" & pv_dt.Columns(j).DataType.FullName & """ >" & v_strVal & "</field>")
                Next
                v_strRet.Append("</" & pv_strTableName & ">")
            Next
        End If

        Return v_strRet.ToString()
    End Function

    Public Function XmlToTable(ByVal pv_NodeList As XmlNodeList) As DataTable
        Dim v_dt As DataTable = Nothing
        If Not pv_NodeList Is Nothing Then
            If pv_NodeList.Count > 0 Then
                v_dt = New DataTable(pv_NodeList(0).Name)
                For i As Integer = 0 To pv_NodeList.Count - 1
                    'Tao cau truc bang
                    If i = 0 Then
                        Dim v_fchild As XmlNodeList = pv_NodeList(i).ChildNodes
                        If Not v_fchild Is Nothing Then
                            For j As Integer = 0 To v_fchild.Count - 1
                                If Not v_dt.Columns.Contains(v_fchild(j).Attributes("name").Value) Then
                                    v_dt.Columns.Add(v_fchild(j).Attributes("name").Value, Type.GetType(v_fchild(j).Attributes("type").Value))
                                End If
                            Next
                        End If
                    End If
                    'End
                    Dim v_dr As DataRow = v_dt.NewRow()

                    Dim v_child As XmlNodeList = pv_NodeList(i).ChildNodes
                    If Not v_child Is Nothing Then
                        For j As Integer = 0 To v_child.Count - 1
                            If v_child(j).Attributes("type").Value = "System.DateTime" Then
                                If v_child(j).InnerXml.Length > 0 Then
                                    v_dr(v_child(j).Attributes("name").Value) = DateTime.ParseExact(v_child(j).InnerXml, "dd/MM/yyyy", Nothing)
                                Else
                                    v_dr(v_child(j).Attributes("name").Value) = DBNull.Value
                                End If
                            Else
                                v_dr(v_child(j).Attributes("name").Value) = v_child(j).InnerXml.Replace("<![CDATA[", "").Replace("]]>", "")
                            End If
                        Next
                    End If

                    v_dt.Rows.Add(v_dr)
                Next
            End If
        End If
        Return v_dt
    End Function

    Public Function ZipString(ByVal pv_strIn As String) As String
        Dim v_btIn() As Byte = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strIn)
        Dim v_strRet As String = ""
        If Not v_btIn Is Nothing Then
            v_strRet = Convert.ToBase64String(v_btIn)
        End If
        Return v_strRet
    End Function
    Public Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function 'GetMd5Hash
    Public Function UnzipString(ByVal pv_strIn As String) As String
        Dim v_btIn() As Byte = Convert.FromBase64String(pv_strIn)
        Dim v_strRet As String = ""
        If Not v_btIn Is Nothing Then
            v_strRet = ZetaCompressionLibrary.CompressionHelper.DecompressString(v_btIn)
        End If
        Return v_strRet
    End Function

    '----------------------------------------------------------------------------------------------
    ' + Má»¥c Ä‘Ã­ch:   Láº¥y thÃ´ng tin lá»—i tá»« message tráº£ v?
    ' + ï¿½?ï¿½áº§u vÃ o:    
    '       - pv_strMessage:        Message tráº£ v?
    ' + ï¿½?ï¿½áº§u ra:
    '       - pv_strErrorSource:    Nguá»“n phÃ¡t sinh lá»—i, = "" náº¿u khÃ´ng cÃ³ lá»—i
    '       - pv_lngErrorCode:      MÃ£ lá»—i, = 0 náº¿u khÃ´ng cÃ³ lá»—i
    '       - pv_strErrorMessage:   ThÃ´ng bÃ¡o lá»—i, = "" náº¿u khÃ´ng cÃ³ lá»—i
    ' + Tráº£ v?:     NA
    ' + Tï¿½Ã¡c giáº£:    Tráº§n Ki?u Minh
    ' + Ghi chï¿½Ãº:    N/A
    '----------------------------------------------------------------------------------------------
    Public Function GetWarningFromMessage(ByVal pv_strMessage As String, _
                                        ByRef pv_strWarningMessage As String, _
                                        ByRef pv_strInfoMessage As String) As Long
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strERRNUM, v_strERRLEV, v_strValue As String

        Try
            pv_strWarningMessage = String.Empty
            pv_strInfoMessage = String.Empty
            v_xmlDocument.LoadXml(pv_strMessage)

            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes

            Dim v_strMSGTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeMSGTYPE), Xml.XmlAttribute).Value)
            Dim v_node As XmlNode = v_attrColl.GetNamedItem(gc_AtributeWARNING)
            If v_node Is Nothing Then
                Return 0
            End If
            Dim v_strWARNING As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeWARNING), Xml.XmlAttribute).Value)
            If v_strWARNING = "Y" Then
                'XÃ¡c Ä‘á»‹nh loáº¡i message
                If (v_strMSGTYPE = gc_MsgTypeObj) Or (v_strMSGTYPE = gc_MsgTypeRpt) Or (v_strMSGTYPE = gc_MsgTypeProc) Then
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/WarningException")
                ElseIf v_strMSGTYPE = gc_MsgTypeTrans Then
                    v_nodeList = v_xmlDocument.SelectNodes("/TransactMessage/WarningException")
                End If

                'Láº¥y thÃ´ng tin lá»—i

                If v_nodeList.Count > 0 Then 'CÃ³ thÃ´ng tin lá»—i
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strERRNUM = CStr(CType(.Attributes.GetNamedItem("errnum"), Xml.XmlAttribute).Value)
                                v_strERRLEV = CStr(CType(.Attributes.GetNamedItem("errlev"), Xml.XmlAttribute).Value)
                                v_strValue = .InnerText.ToString
                                If v_strERRLEV = gc_WARNING_MESSAGE Then
                                    If v_strValue.Length > 0 Then
                                        pv_strWarningMessage = pv_strWarningMessage & Trim(v_strValue) & ControlChars.CrLf
                                    Else
                                        pv_strWarningMessage = pv_strWarningMessage & " Undefined error!" & ControlChars.CrLf
                                    End If
                                ElseIf v_strERRLEV = gc_INFO_MESSAGE Then
                                    If v_strValue.Length > 0 Then
                                        pv_strInfoMessage = pv_strInfoMessage & Trim(v_strValue) & ControlChars.CrLf
                                    Else
                                        pv_strInfoMessage = pv_strInfoMessage & " Undefined error!" & ControlChars.CrLf
                                    End If
                                End If
                            End With
                        Next
                    Next
                Else
                    pv_strWarningMessage = String.Empty
                    pv_strInfoMessage = String.Empty
                End If
                v_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeWARNING).Value = "N"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function DDMMYYYY_SystemDate(ByVal v_strDate As String) As Date
        Try
            Dim v_dtREFDATE As Date
            If v_strDate.Length = 0 Or v_strDate Is Nothing Then
                v_dtREFDATE = CDate("01/01/1900")
            Else
                v_dtREFDATE = CDate("01/01/" & GetDateValue(v_strDate, "Y")) 'Láº¥y nÄƒm hiá»‡n táº¡i
                v_dtREFDATE = DateAdd(DateInterval.Month, GetDateValue(v_strDate, "M") - 1, v_dtREFDATE) 'Láº¥y thÃ¡ng hiá»‡n táº¡i
                v_dtREFDATE = DateAdd(DateInterval.Day, GetDateValue(v_strDate, "D") - 1, v_dtREFDATE)  'Láº¥y ngÃ y hiá»‡n táº¡i
            End If

            Return v_dtREFDATE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function GetDateValue(ByVal v_strDate As String, ByVal v_strType As String) As Integer
        'Format lÃ  DD/MM/YYYY
        Dim i, j As Integer
        i = InStr(1, v_strDate, "/")
        If i > 0 Then j = InStr(i + 1, v_strDate, "/")
        If i > 0 And j > 0 Then
            Select Case Trim(v_strType)
                Case "D"
                    Return CInt(Mid(v_strDate, 1, i - 1))
                Case "M"
                    Return CInt(Mid(v_strDate, i + 1, j - i - 1))
                Case "Y"
                    Return CInt(Mid(v_strDate, j + 1, 4))
            End Select
        End If
    End Function

    Function IsDateValue(ByVal v_strDate As String) As Boolean
        Try
            'Format lÃ  DD/MM/YYYY
            Dim intDay, intMonth, intYear As Integer, v_dtValue As Date = Now
            intDay = GetDateValue(v_strDate, "D")
            intMonth = GetDateValue(v_strDate, "M")
            intYear = GetDateValue(v_strDate, "Y")

            'Kiá»ƒm tra giÃ¡ trá»‹ nÄƒm vÃ  thÃ¡ng pháº£i há»£p lá»‡
            If intYear < 1900 And intYear > 2099 Then
                Return False
            End If
            If intMonth < 1 And intMonth > 12 Then
                Return False
            End If

            'Kiá»ƒm tra giÃ¡ trá»‹ ngÃ y pháº£i há»£p lá»‡
            If intDay < 1 Or intDay > v_dtValue.DaysInMonth(intYear, intMonth) Then
                Return False
            End If
            Return True
        Catch
            Return False
        End Try
    End Function

    Function GetMinPositive(ByVal v_dblNumber1 As Double, ByVal v_dblNumber2 As Double) As Double
        'If v_dblNumber1 < 0 Then
        '    Return v_dblNumber2
        'Else
        '    Return IIf(v_dblNumber1 < v_dblNumber2, v_dblNumber1, v_dblNumber2)
        'End If
        Dim v_dblResult As Double
        v_dblResult = IIf(v_dblNumber1 < v_dblNumber2, v_dblNumber1, v_dblNumber2)
        If v_dblResult < 0 Then
            v_dblResult = 0
        End If
        Return v_dblResult
    End Function

    Function GetMax(ByVal v_dblNumber1 As Double, ByVal v_dblNumber2 As Double) As Double
        Return IIf(v_dblNumber1 > v_dblNumber2, v_dblNumber1, v_dblNumber2)
    End Function

    Function FRound(ByVal v_dblNumber As Double, Optional ByVal v_intDecimal As Integer = 0) As Double
        If v_dblNumber * Math.Pow(10, v_intDecimal) = (Math.Ceiling(v_dblNumber * Math.Pow(10, v_intDecimal)) + Math.Floor(v_dblNumber * Math.Pow(10, v_intDecimal))) / 2 Then
            Return Math.Round(v_dblNumber + Math.Pow(10, 0 - v_intDecimal - 1), v_intDecimal)
        Else
            Return Math.Round(v_dblNumber, v_intDecimal)
        End If
    End Function

    Function GetMin(ByVal v_dblNumber1 As Double, ByVal v_dblNumber2 As Double) As Double
        Return IIf(v_dblNumber1 > v_dblNumber2, v_dblNumber2, v_dblNumber1)
    End Function

    Function getValueParseXml(ByVal pv_Value As String) As String
        Dim v_strValue As String = pv_Value
        v_strValue = v_strValue.Replace("&", "&amp;")
        v_strValue = v_strValue.Replace("'", "&apos;")
        v_strValue = v_strValue.Replace("""", "&quot;")
        v_strValue = v_strValue.Replace("<", "&lt;")
        v_strValue = v_strValue.Replace(">", "&gt;")
        Return v_strValue
    End Function

    Private Function GetIPAddress() As IPAddress
        Try
            Dim sHostName As String = System.Net.Dns.GetHostName()
            Dim ipE As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(sHostName)
            Dim IpA() As System.Net.IPAddress = ipE.AddressList

            Return IpA(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'HÃ m sá»­ dá»¥ng Ä‘á»ƒ láº¥y Ä‘á»‹a chá»‰ MAC cá»§a card máº¡ng
    Public Function GetMACAddress() As String
        Try
            'Dim tempAddress As IPAddress = GetIPAddress()

            'Dim ab() As Byte
            'ReDim ab(5)
            'Dim len As Int32 = ab.Length()
            ''Dim i As Long = tempAddress.Address
            'Dim r As Integer = SendARP(Integer.Parse(tempAddress.Address), 0, ab, len)
            'Dim mac As String = BitConverter.ToString(ab, 0, 6)

            'Return mac
            Return "FPT Software Solutions"
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Gen_OOD_QueueMessage(ByVal broker_order_id As String, _
                                        ByVal exchange_order_id As String, _
                                        ByVal reference_order_id As String, _
                                        ByVal stock_id As String, _
                                        ByVal stock_symbol As String, _
                                        ByVal custody_code As String, _
                                        ByVal type As String, _
                                        ByVal order_matching_type As String, _
                                        ByVal order_price_type As String, _
                                        ByVal price As String, _
                                        ByVal quantity As String, _
                                        ByVal order_status As String, _
                                        ByVal transaction_time As String, _
                                        ByVal branch_id As String, _
                                        ByVal teller_id As String _
                                        ) As String
        Try
            'Start here
            Dim v_strOODMessage As String = String.Empty
            v_strOODMessage &= "<?xml version=""1.0"" encoding=""UTF-8"" ?> "
            v_strOODMessage &= "<order-ood xmlns=""http://ood.schemas.fss.ipa.com"">"
            v_strOODMessage &= "<broker-order-id>" & broker_order_id & "</broker-order-id> "
            v_strOODMessage &= "<exchange-order-id>" & exchange_order_id & "</exchange-order-id>"
            v_strOODMessage &= "<reference-order-id>" & reference_order_id & "</reference-order-id> "
            v_strOODMessage &= "<stock-id>" & stock_id & "</stock-id> "
            v_strOODMessage &= "<stock-symbol>" & stock_symbol & "</stock-symbol> "
            v_strOODMessage &= "<custody-code>" & custody_code & "</custody-code>"
            v_strOODMessage &= " <order-transaction-type>" & type & "</order-transaction-type> "
            v_strOODMessage &= "<order-matching-type>" & order_matching_type & "</order-matching-type> "
            v_strOODMessage &= " <order-price-type>" & order_price_type & "</order-price-type> "
            v_strOODMessage &= "<price>" & price & "</price>"
            v_strOODMessage &= "<quantity>" & quantity & "</quantity> "
            v_strOODMessage &= "<order-status>" & order_status & "</order-status> "
            v_strOODMessage &= "<transaction-time>" & transaction_time & "</transaction-time> "
            v_strOODMessage &= "<branch-id>" & branch_id & "</branch-id> "
            v_strOODMessage &= " <teller-id>" & teller_id & "</teller-id> "
            v_strOODMessage &= " </order-ood>"
            Return v_strOODMessage
        Catch ex As Exception
            'On exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Chuyển số thành chữ
    ''' </summary>
    ''' <param name="p_strNumber">Số cần chuyển</param>
    ''' <returns></returns>
    ''' <remarks>ThongPM chuyển code từ CR sang VB 02/11/2011</remarks>
    Function NumberToText(ByVal p_strNumber As String)
        Dim strNum As String
        Dim strNumber As String
        Dim decNum As Decimal
        Dim blnFull As Boolean
        Dim lngSayNum As Double
        Dim Num(10) As String
        Dim strCur As String
        Dim strSubCur As String
        Dim strSplit As String
        Dim Unit(5) As String
        Dim strTemp As String
        Dim strSay As String
        Dim bytUnit As Double
        Dim strFirst As String
        Dim strSign As String
        Dim strFix As String
        Dim strNumFix As String

        Dim DS As Char = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim GS As Char = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator

        Try
            'Hang so
            Num(1) = "không"
            Num(2) = "một"
            Num(3) = "hai"
            Num(4) = "ba"
            Num(5) = "bốn"
            Num(6) = "năm"
            Num(7) = "sáu"
            Num(8) = "bảy"
            Num(9) = "tám"
            Num(10) = "chín"

            strSplit = "phảy"
            Unit(1) = ""
            Unit(2) = "ngàn"
            Unit(3) = "triệu"
            Unit(4) = "tỷ"
            '
            ''ThongPM sua ngay 02/11/2011
            'strNumber = {@P_AMT}
            strNum = Replace(p_strNumber, GS, "")
            decNum = Convert.ToDecimal(strNum)
            '
            'If UCase ((Trim({@P_CCY}))) = "VND" THEN
            If decNum <> 0 Then
                If decNum < 0 Then
                    strSign = "¢m "
                Else
                    strSign = ""
                End If

                decNum = Math.Abs(decNum)

                'Lay dinh dang so
                strNum = String.Format("{0:n2}", decNum)
                strNum = Replace(strNum, GS, "")

                strFix = Mid(strNum, InStr(1, strNum, DS) + 1)

                strNum = Left(strNum, InStr(1, strNum, DS) - 1)

                strNum = Trim(strNum)
                bytUnit = 0
                While Len(strNum) > 3
                    blnFull = True
                    lngSayNum = Val(Right(strNum, 3))
                    strTemp = ""
                    If lngSayNum = 0 Then
                        strTemp = ""
                    Else
                        If lngSayNum Mod 10 <> 0 Then
                            strTemp = Num(lngSayNum Mod 10 + 1)
                        End If
                        lngSayNum = Int(lngSayNum / 10)
                        If Not blnFull And lngSayNum = 0 Then
                            strTemp = Trim(strTemp)
                        Else
                            If lngSayNum Mod 10 <> 0 Then
                                If strTemp = "Năm" Then strTemp = "lăm"
                                If lngSayNum Mod 10 <> 1 Then
                                    strTemp = Num(lngSayNum Mod 10 + 1) + " mươi " + strTemp
                                ElseIf strTemp = "" Then
                                    strTemp = "mươi"
                                Else
                                    strTemp = "mươi " + strTemp
                                End If
                            ElseIf strTemp <> "" Then
                                strTemp = "linh " + strTemp
                            End If
                            lngSayNum = Int(lngSayNum / 10)
                            If lngSayNum = 0 And Not blnFull Then
                                strTemp = Trim(strTemp)
                            Else
                                strTemp = Trim(Num(1 + lngSayNum) + " trăm " + strTemp)
                            End If
                        End If
                    End If
                    If strTemp <> "" Then
                        strSay = strTemp + " " + Unit(bytUnit + 1) + " " + strSay
                    End If
                    bytUnit = bytUnit + 1
                    strNum = Left(strNum, Len(strNum) - 3)
                    If bytUnit = 5 Then
                        bytUnit = 1
                    End If
                End While
                blnFull = False
                lngSayNum = Val(Right(strNum, 3))
                strTemp = ""
                If lngSayNum = 0 Then
                    strTemp = ""
                Else
                    If lngSayNum Mod 10 <> 0 Then
                        strTemp = Num(lngSayNum Mod 10 + 1)
                    End If
                    lngSayNum = Int(lngSayNum / 10)
                    If Not blnFull And lngSayNum = 0 Then
                        strTemp = Trim(strTemp)
                    Else
                        If lngSayNum Mod 10 <> 0 Then
                            If strTemp = "năm" Then strTemp = "lăm"
                            If lngSayNum Mod 10 <> 1 Then
                                strTemp = Num(lngSayNum Mod 10 + 1) + " mươi " + strTemp
                            ElseIf strTemp = "" Then
                                strTemp = "mươi"
                            Else
                                strTemp = "mươi " + strTemp
                            End If
                        ElseIf strTemp <> "" Then
                            strTemp = "linh " + strTemp
                        End If
                        lngSayNum = Int(lngSayNum / 10)
                        If lngSayNum = 0 And Not blnFull Then
                            strTemp = Trim(strTemp)
                        Else
                            strTemp = Trim(Num(lngSayNum Mod 10 + 1) + " trăm " + strTemp)
                        End If
                    End If
                End If
                strSay = strTemp + IIf(Unit(bytUnit + 1) = "", "", " ") + Unit(bytUnit + 1) + " " + strSay
                strSay = Replace(strSay, "mư?i m�ột", "mư?i m�ột")
                strSay = Replace(strSay, "mư?i b�ốn", "mư?i t�ư")

                'Xu ly phan sau dau thap phan
                While Right(strFix, 1) = "0"
                    strFix = Left(strFix, Len(strFix) - 1)
                End While

                While Len(strFix) > 0
                    strNumFix = strNumFix + Num(Asc(Left(strFix, 1)) - Asc("0") + 1) + " "
                    strFix = Mid(strFix, 2)
                End While
                'begin them moi
                If Len(strNumFix) > 0 Then
                    If strNumFix = "không không " Then strNumFix = ""
                    If Right(strNumFix, Len("  không ")) = " không " Then
                        strNumFix = Left(strNumFix, Len(strNumFix) - Len(" không ")) + " mư?i "
                    End If

                    If Left(strNumFix, Len("kh�ông ")) = "không " Then
                        strNumFix = Trim(Mid(strNumFix, InStr(strNumFix, " "), Len(strNumFix)))
                    ElseIf Right(strNumFix, Len(" không ")) <> " không " Then
                        strNumFix = Left(strNumFix, InStr(strNumFix, " ")) + "mư?i " + Trim(Mid(strNumFix, InStr(strNumFix, " ") + 1, Len(strNumFix)))
                    End If
                    strNumFix = Replace(strNumFix, "m�ư?i m�ột", "mư?i m�ột")
                    strNumFix = Replace(strNumFix, "mư?i b�ốn", "mư?i b�ốn")
                End If
                'end them moi
                If Len(strNumFix) > 0 Then
                    strNumFix = " và " + strNumFix + "đồng"
                End If
                'them ten laoi tien
                If Len(strNumFix) > 0 Then
                    strSay = strSay + "đồng"
                Else
                    strSay = strSay + "đồng" + " chẵn"
                End If
                strSay = UCase(Left(strSay, 1)) + Right(strSay, Len(strSay) - 1)
            Else
                strSay = ""
            End If

        Catch ex As Exception

        End Try

        Return strSay
    End Function

    'Local=False: Mien nam
    'Local=true: Mien bac
    Function Num2Text(ByVal s As String, Optional ByVal Local As Boolean = False) As String
        Dim DS As Char = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim GS As Char = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator
        Dim fDS As Boolean = False
        Dim fDecAdd As Boolean = False
        Dim so() As String = {"không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"}
        Dim hang() As String = {"", "ngàn", "triệu", "tỷ"}
        If Local Then
            hang(1) = "nghìn"
        End If
        Dim i, j, cntDS, donvi, chuc, tram As Integer
        Dim str As String
        str = ""
        s = s.Replace(GS, "")
        If s.Substring(s.Length - 1, 1) = DS Then s = s.Substring(0, s.Length - 1)

        i = s.Length
        While s.Substring(0, 1) = "0"
            s = s.Substring(1, s.Length - 1)
        End While
        If s.Substring(0, 1) = DS Then s = "0" & s
        cntDS = 0
        If InStr(s, DS) Then
            For i = 0 To s.Length - 1 Step 1
                If s.Substring(i, 1) = DS Then
                    cntDS += 1
                End If
            Next
        End If
        If cntDS > 1 Then Return ""
        If cntDS > 0 Then
            While s.Substring(s.Length - 1, 1) = "0"
                s = s.Substring(0, s.Length - 1)
            End While
        End If
        If s.Substring(s.Length - 1, 1) = DS Then s = s.Substring(0, s.Length - 1)

        i = s.Length - 1
        If i = 0 Then
            str = ""
        Else
            j = 0
            Do While i >= 0
                If s.Substring(i, 1) = DS Then
                    fDS = True
                    i -= 1
                    GoTo DecimalAdd
                Else
                    donvi = Int(s.Substring(i, 1))
                    i -= 1
                End If

                If i > -1 Then
                    If s.Substring(i, 1) = DS Then
                        i -= 1
                        chuc = -1
                        tram = -1
                        fDS = True
                        GoTo NumberRead
                    Else
                        chuc = Int(s.Substring(i, 1))
                    End If
                Else
                    chuc = -1
                End If
                i -= 1

                If i > -1 Then
                    If s.Substring(i, 1) = DS Then
                        i -= 1
                        tram = -1
                        fDS = True
                        GoTo NumberRead
                    Else
                        tram = Int(s.Substring(i, 1))
                    End If
                Else
                    tram = -1
                End If
                i -= 1
NumberRead:
                If donvi > 0 Or chuc > 0 Or tram > 0 Or j = 3 Then str = hang(j) & " " & str
                j += 1

                If j > 3 Then j = 1

                If donvi = 1 And chuc > 1 Then
                    str = "mốt" & " " & str
                ElseIf donvi = 4 And chuc > 1 Then
                    If Local Then
                        str = "tư" & " " & str
                    Else
                        str = so(donvi) & " " & str
                    End If
                ElseIf donvi = 5 Then
                    If chuc > 0 Then
                        str = "lăm" & " " & str
                    Else
                        str = so(donvi) & " " & str
                    End If
                Else
                    If donvi <> 0 Then str = so(donvi) & " " & str
                End If

                If chuc < 0 Then
                    If Not fDS Then Exit Do
                Else
                    If chuc = 0 And donvi > 0 Then
                        str = "lẻ" & " " & str
                    ElseIf chuc = 1 Then
                        str = "mười" & " " & str
                    ElseIf chuc > 1 Then
                        str = so(chuc) & " " & "mươi" & " " & str
                    End If
                End If
                If tram < 0 Then
                    If Not fDS Then Exit Do
                Else
                    If tram > 0 Or chuc > 0 Or donvi > 0 Then
                        str = so(tram) & " " & "trăm" & " " & str
                    End If
                End If
DecimalAdd:
                If fDS Then
                    str = "phảy " & str
                    j = 0
                    fDS = False
                    fDecAdd = True
                End If
            Loop
        End If

        If str.Length > 0 Then
            str = str.Trim
            str = str.Replace("  ", " ")
            str = UCase(str.Substring(0, 1)) & str.Substring(1, str.Length - 1)
            Return str
        Else
            Return ""
        End If
    End Function

    Public Function BuildXMLWarningException(ByRef pv_xmlDocument As Xml.XmlDocument, _
                                           ByVal pv_strErrorSource As String, _
                                           ByVal pv_lngErrorCode As Long, _
                                           ByVal pv_strErrorMessage As String, _
                                           ByVal pv_strErrorLevel As String) As Long
        Dim dataElement As Xml.XmlElement
        Dim entryNode As Xml.XmlNode
        Dim v_attrERRNUM, v_attrERRLEV As Xml.XmlAttribute

        Try
            If pv_strErrorSource Is Nothing Then pv_strErrorSource = String.Empty
            If pv_strErrorMessage Is Nothing Then pv_strErrorMessage = String.Empty

            If pv_xmlDocument.DocumentElement("WarningException") Is Nothing Then
                dataElement = pv_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "WarningException", "")

                entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
                'Add field name
                v_attrERRNUM = pv_xmlDocument.CreateAttribute("errnum")
                v_attrERRNUM.Value = pv_lngErrorCode
                entryNode.Attributes.Append(v_attrERRNUM)

                'Add error level
                v_attrERRLEV = pv_xmlDocument.CreateAttribute("errlev")
                v_attrERRLEV.Value = pv_strErrorLevel
                entryNode.Attributes.Append(v_attrERRLEV)

                'Set value
                If pv_lngErrorCode <> 0 Then
                    entryNode.InnerText = pv_strErrorMessage
                End If
                dataElement.AppendChild(entryNode)

                pv_xmlDocument.DocumentElement.AppendChild(dataElement)
            Else
                entryNode = pv_xmlDocument.CreateNode(Xml.XmlNodeType.Element, "Entry", "")
                'Add field name
                v_attrERRNUM = pv_xmlDocument.CreateAttribute("errnum")
                v_attrERRNUM.Value = pv_lngErrorCode
                entryNode.Attributes.Append(v_attrERRNUM)

                'Add error level
                v_attrERRLEV = pv_xmlDocument.CreateAttribute("errlev")
                v_attrERRLEV.Value = pv_strErrorLevel
                entryNode.Attributes.Append(v_attrERRLEV)

                'Set value
                If pv_lngErrorCode <> 0 Then
                    entryNode.InnerText = pv_strErrorMessage
                End If
                pv_xmlDocument.DocumentElement("WarningException").AppendChild(entryNode)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub LogMessage(ByVal pv_strMsgType As String, ByVal pv_strMsgSource As String, ByVal pv_strMessage As String)
        Dim v_strPath As String = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\Debug\", "").Replace("bin\Release\", "") & "\MessageLog\"
        Dim v_strFileName As String = "Log_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

        Try
            If Not Directory.Exists(v_strPath) Then
                Directory.CreateDirectory(v_strPath)
            End If

            Dim fs As New FileStream(v_strPath & v_strFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            If Not fs Is Nothing Then
                Dim sw As New StreamWriter(fs)
                Dim v_strMessage As String = "[" & DateTime.Now.ToString("dd/MM/yyyy") & " - " & DateTime.Now.ToString("HH:mm:ss") & "] - [ Message Type : " & pv_strMsgType & "] - [Source : " & pv_strMsgSource & "] - " & pv_strMessage
                sw.WriteLine(v_strMessage)
                sw.Flush()
                sw.Close()
                fs.Close()
            End If
        Catch ex As Exception
            LogError.Write("Error source: ModCommon.LogMessage" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

#End Region

#Region " Message Schema "
    Public Const gc_SCHEMA_TXMESSAGE_ROOT = "/TransactMessage"
    'Public Const gc_SCHEMA_TXMESSAGE_HEADER = "<TransactMessage MSGTYPE='T' TLTXCD='' BRID='' TLID='' IPADDRESS='' WSNAME='' TXTYPE='' NOSUBMIT='' STATUS='0' DELTD='N' DELALLOW='Y' OVRRQD='' UPDATEMODE='' LOCAL='N' OFFID='' CHKID='' CHID='' IBT='' BRID2='' TLID2='' TXDATE='' TXTIME='' TXNUM='' BRDATE='' BUSDATE='' CCYUSAGE='00' OFFLINE='N' MSGSTS='0' OVRSTS='0' PRETRAN='Y' BATCHNAME='DAY' MSGAMT='' MSGACCT='' CHKTIME='' OFFTIME='' TXDESC='' FEEAMT='0' VATAMT='' VOUCHER='' PAGENO='1' TOTALPAGE='1' LATE='0' GLGP='' HOSTTIME=''></TransactMessage>"
    'Public Const gc_SCHEMA_TXMESSAGE_HEADER = "<TransactMessage MSGTYPE='T' TLTXCD='' BRID='' TLID='' IPADDRESS='' WSNAME='' TXTYPE='' NOSUBMIT='' STATUS='0' DELTD='N' DELALLOW='Y' OVRRQD='' UPDATEMODE='' LOCAL='N' OFFID='' CHKID='' CHID='' IBT='' BRID2='' TLID2='' TXDATE='' TXTIME='' TXNUM='' BRDATE='' BUSDATE='' CCYUSAGE='00' OFFLINE='N' MSGSTS='0' OVRSTS='0' PRETRAN='Y' BATCHNAME='DAY' MSGAMT='' MSGACCT='' CHKTIME='' OFFTIME='' TXDESC='' FEEAMT='0' VATAMT='' VOUCHER='' PAGENO='1' TOTALPAGE='1' LATE='0' GLGP='' HOSTTIME='' CAREBY=''></TransactMessage>"
    'Public Const gc_SCHEMA_TXMESSAGE_HEADER = "<TransactMessage MSGTYPE='T' TLTXCD='' BRID='' TLID='' IPADDRESS='' WSNAME='' TXTYPE='' NOSUBMIT='' STATUS='0' DELTD='N' DELALLOW='Y' OVRRQD='' UPDATEMODE='' LOCAL='N' OFFID='' CHKID='' CHID='' IBT='' BRID2='' TLID2='' TXDATE='' TXTIME='' TXNUM='' BRDATE='' BUSDATE='' CCYUSAGE='00' OFFLINE='N' MSGSTS='0' OVRSTS='0' PRETRAN='Y' BATCHNAME='DAY' MSGAMT='' MSGACCT='' CHKTIME='' OFFTIME='' TXDESC='' FEEAMT='0' VATAMT='' VOUCHER='' PAGENO='1' TOTALPAGE='1' LATE='0' GLGP='' HOSTTIME='' CAREBY='' REFERENCE=''></TransactMessage>"
    'Public Const gc_SCHEMA_TXMESSAGE_HEADER = "<TransactMessage MSGTYPE='T' ACTIONFLAG='TXN' TLTXCD='' BRID='' TLID='' IPADDRESS='' WSNAME='' TXTYPE='' NOSUBMIT='' STATUS='0' DELTD='N' DELALLOW='Y' OVRRQD='' UPDATEMODE='' LOCAL='N' OFFID='' CHKID='' CHID='' IBT='' BRID2='' TLID2='' TXDATE='' TXTIME='' TXNUM='' BRDATE='' BUSDATE='' CCYUSAGE='00' OFFLINE='N' MSGSTS='0' OVRSTS='0' PRETRAN='Y' BATCHNAME='DAY' MSGAMT='' MSGACCT='' CHKTIME='' OFFTIME='' TXDESC='' FEEAMT='0' VATAMT='' VOUCHER='' PAGENO='1' TOTALPAGE='1' LATE='0' GLGP='' HOSTTIME='' CAREBY='' REFERENCE=''></TransactMessage>"
    Public Const gc_SCHEMA_TXMESSAGE_HEADER = "<TransactMessage MSGTYPE='T' ACTIONFLAG='TXN' TLTXCD='' BRID='' TLID='' IPADDRESS='' WSNAME='' TXTYPE='' NOSUBMIT='' STATUS='0' DELTD='N' DELALLOW='Y' OVRRQD='' UPDATEMODE='' LOCAL='N' OFFID='' CHKID='' CHID='' IBT='' BRID2='' TLID2='' TXDATE='' TXTIME='' TXNUM='' BRDATE='' BUSDATE='' CCYUSAGE='00' OFFLINE='N' MSGSTS='0' OVRSTS='0' PRETRAN='Y' BATCHNAME='DAY' MSGAMT='' MSGACCT='' CHKTIME='' OFFTIME='' TXDESC='' FEEAMT='0' VATAMT='' VOUCHER='' PAGENO='1' TOTALPAGE='1' LATE='0' GLGP='' HOSTTIME='' CAREBY='' REFERENCE='' WARNING='' SESSIONID='' REQUESTID=''></TransactMessage>"
    Public Const gc_SCHEMA_OBJMESSAGE_ROOT = "/ObjectMessage"
    'AnhVT Added - Maintenance Approval Retro
    'Public Const gc_SCHEMA_OBJMESSAGE_HEADER = "<ObjectMessage TXDATE='' TXNUM='' TXTIME='' TLID='' BRID='' LOCAL='' MSGTYPE='' OBJNAME='' ACTIONFLAG='' CMDINQUIRY='' CLAUSE='' FUNCTIONNAME='' AUTOID='' REFERENCE='' RESERVER='' IPADDRESS='' CMDTYPE='' PARENTOBJNAME='' PARENTCLAUSE=''></ObjectMessage>"
    Public Const gc_SCHEMA_OBJMESSAGE_HEADER As String = "<ObjectMessage TXDATE='' TXNUM='' TXTIME='' TLID='' BRID='' LOCAL='' MSGTYPE='' OBJNAME='' ACTIONFLAG='' CMDINQUIRY='' CLAUSE='' FUNCTIONNAME='' AUTOID='' REFERENCE='' RESERVER='' IPADDRESS='' CMDTYPE='' PARENTOBJNAME='' PARENTCLAUSE='' WARNING='' SESSIONID='' REQUESTID='' USERLANGUAGE='VN'></ObjectMessage>"    '03/10/2017 DieuNDA Song ngu
    'TungNT added - for build message to BankGW
    Public Const gc_SCHEMA_BANKRQS_HEADER As String = _
                "<ObjectMessage>" & vbCrLf & _
                 "  <Function FUNCTIONNAME='' BANKCODE='' WSNAME='' IPADDRESS='' TXDATE='' TXTIME='' TRNREF='' />" & vbCrLf & _
                 "  <Input>" & vbCrLf & _
                 "  </Input>" & vbCrLf & _
                 "</ObjectMessage>"

    Public Const gc_SCHEMA_BANKTRF_HEADER As String = _
               "<ObjectMessage>" & vbCrLf & _
                "  <Function FUNCTIONNAME='TRFEODREPORT' BANKCODE='' WSNAME='' IPADDRESS='' TXDATE='' TXTIME='' />" & vbCrLf & _
                "  <BatchInfo VERSION='' LOCALVERSION='' TRANSDATE='' AFFECTDATE='' BATCHTYPE='' CORD='' UNHOLD='' STATUS='' >" & vbCrLf & _
                "  </BatchInfo>" & vbCrLf & _
                "</ObjectMessage>"
#End Region

#Region " CTCI constants "

    'Add/Cancel Flag
    Public Const ADD_FLAG = "A"
    Public Const CANCEL_FLAG = "C"
    'Benefit
    Public Const EX_DIVIDEND_AND_EX_RIGHTS = "A"
    Public Const EX_DIVIDEND = "D"
    Public Const EX_RIGHTS = "R"
    'Board
    Public Const BIG_LOT_BOARD = "B"
    Public Const MAIN_BOARD = "M"
    Public Const OFF_HOUR_BOARD = "O"
    'ClientID
    Public Const BROKER_NO_P = "P"
    Public Const BROKER_NO_C = "C"
    Public Const LOCAL_CUSTODIAN_SYMBOL = "A"
    Public Const CUSTODIAN_SYMBOL = "B"
    Public Const CUSTODIAN_SYMBOL_OR_BROKER = "F"
    Public Const FOREIGN_CUSTODIAN_SYMBOL = "E"
    'Client ID Required
    Public Const CLIENT_ID_NOT_REQUIRED = ""
    Public Const CLIENT_ID_REQUIRED = "Y"
    'Delist
    Public Const DELIST = "Y"
    Public Const NOT_DELIST = ""
    'Halt / Resume Flag
    Public Const HALT_FLAG = "H"
    Public Const RESUME_FLAG = "R"
    'Market ID
    Public Const MARKET_ID_SET = "A"
    'Meeting
    Public Const EX_MEETING = "M"
    Public Const NOT_EX_MEETING = ""
    'Notice
    Public Const NOT_NOTICE = ""
    Public Const NOTICE_PENDING = "P"
    Public Const NOTICE_RECEIVED = "R"
    'Order Cancel Status
    Public Const CANCELLED_BY_BROKER = "R"
    Public Const CANCELLED_BY_SET = "R"
    'Port/Client Flag
    Public Const BROKER_CLIENT = "C"
    Public Const BROKER_FOREIGN = "F"
    Public Const MUTUAL_FUND = "M"
    Public Const BROKER_PORTFOLIO = "P"
    'Price
    Public Const PRICE_ATO = "ATO"
    Public Const PRICE_ATC = "ATC"
    Public Const PRICE_MP = "MP"
    'Reject Reason Code
    Public Const REJECT_REASON_CODE_00 = "MP order without contra-side"
    Public Const REJECT_REASON_CODE_01 = ""
    Public Const REJECT_REASON_CODE_02 = ""
    Public Const REJECT_REASON_CODE_03 = ""
    Public Const REJECT_REASON_CODE_04 = ""
    Public Const REJECT_REASON_CODE_05 = ""
    Public Const REJECT_REASON_CODE_06 = ""
    'Reply Code
    Public Const APPROVAL = "A"
    Public Const CONTRA_BROKER_DISAPPROVAL = "C"
    Public Const SET_DISAPPROVAL = "S"
    'SDC Flag
    Public Const SECURITY_IN_SDC = "Y"
    Public Const SECURITY_NOT_IN_SDC = "N"
    'Security Type
    Public Const DEBENTURE = "D"
    Public Const COMMON_STOCK = "S"
    Public Const UNIT_TRUST = "U"
    'Side
    Public Const BOTH_BUYER_AND_SELLER_SIDE = "X"
    Public Const BUYER_SIDE = "B"
    Public Const SELLER_SIDE = "S"
    'Split
    Public Const SPLIT = "S"
    Public Const NOT_SPLIT = ""
    'Suspension
    Public Const SUSPENSION = "S"
    Public Const NOT_SUSPENSION = ""
    'System Control Code
    Public Const START_OF_CALL_MARKET = "A"
    Public Const BEGIN_RUNOFF_PERIOD = "C"
    Public Const FINISH_INTERMISSION_PERIOD = "F"
    Public Const BEGIN_EOD_SECURITY_UPDATE_TRANSMISSION = "G"
    Public Const HALT_ALL_TRADING = "H"
    Public Const BEGIN_INTERMISSION_PERIOD = "I"
    Public Const END_EOD_SECURITY_UPDATE_TRANSMISSION = "J"
    Public Const END_RUNOFF_PERIOD = "K"
    Public Const NORMAL_TRADING_RESUMED_FOR_A_SPECIFIED_SECURITY = "N"
    Public Const MARKET_OPEN = "O"
    Public Const START_OF_PREOPEN_PERIOD_FOR_ENTIRE_MARKET = "P"
    Public Const RESUME_ALL_TRADING = "R"
    Public Const ORDERS_ARE_NOT_BEING_ACCEPTED_FOR_SPECIFIED_SECURITY = "X"

#End Region

#Region " PRS constants "
    Public Const gc_PRS_MSG_RECEIVE_NORMAL = "PRS_MSG_RECEIVE_NORMAL"
#End Region

#Region "Call Generic Service - TruongLD Add when convert"
    Public Function UseServiceClient(Of T1, T2)(ByVal func As Func(Of T1, T2)) As T2
        Dim factory As New ChannelFactory(Of T1)("*")
        Dim client As T1 = factory.CreateChannel()
        Dim returnValue As T2
        Try
            returnValue = func(client)
        Catch ex As Exception
            CType(client, IClientChannel).Abort()
            factory.Abort()
            LogError.Write("Error source: " & ex.Source & vbNewLine _
             & "Error code: UseServiceClient!" & vbNewLine _
             & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw
        Finally
            CType(client, IClientChannel).Close()
            CType(client, IClientChannel).Dispose()
            factory.Close()
        End Try
        Return returnValue
    End Function
#End Region

End Module
