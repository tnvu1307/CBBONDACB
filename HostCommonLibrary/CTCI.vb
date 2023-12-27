


'-------------------------------------------------------------------
'------------------------CTCI Class --------------------------------
'-------------------------------------------------------------------
Public Class RespondMsg
#Region " Declaration "
    Private v_strCode As String
    Private v_strMessage As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCode = String.Empty
        v_strMessage = String.Empty
    End Sub
    Public Overloads Sub Dispose()
        v_strCode = String.Empty
        v_strMessage = String.Empty
    End Sub
#End Region
#Region " Properties "
    Public Property Code() As String
        Get
            Return v_strCode
        End Get
        Set(ByVal Value As String)
            v_strCode = Value
        End Set
    End Property
    Public Property Message() As String
        Get
            Return v_strMessage
        End Get
        Set(ByVal Value As String)
            v_strMessage = Value
        End Set
    End Property
#End Region
End Class
Public Class CTCI_1C
#Region " Declaration "
    Private v_strFIRM As String
    Private v_strORDER_ENTRY_DATE As String
    Private v_strORDER_NUMBER As String
#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty
    End Sub
    Public Overloads Sub Dispose()
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty
    End Sub
#End Region
#Region " Properties "
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORDER_ENTRY_DATE() As String
        Get
            Return v_strORDER_ENTRY_DATE
        End Get
        Set(ByVal Value As String)
            v_strORDER_ENTRY_DATE = Value
        End Set
    End Property
    Public Property ORDER_NUMBER() As String
        Get
            Return v_strORDER_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strORDER_NUMBER = Value
        End Set
    End Property
#End Region
#Region " Private message "
    Private Function Get_Message(ByVal v_xmlMessage As Xml.XmlDocument) As Long
        Me.FIRM = v_xmlMessage.DocumentElement.ChildNodes(2).FirstChild.Attributes("Firm").Value
        Me.ORDER_NUMBER = v_xmlMessage.DocumentElement.ChildNodes(2).FirstChild.Attributes("Order Number").Value
        Me.ORDER_ENTRY_DATE = v_xmlMessage.DocumentElement.ChildNodes(2).FirstChild.Attributes("Order Entry Date").Value
    End Function
    Public Function Gen_Message() As String
        Try
            'Start here
            Dim v_strOODMessage As String = String.Empty
            v_strOODMessage &= "<placementMessages>"
            v_strOODMessage &= "<group />"
            v_strOODMessage &= "<type>1C</type>"
            v_strOODMessage &= "<contents>"
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>firm</key>"
            v_strOODMessage &= "<value>" & Me.FIRM & "</value>"
            v_strOODMessage &= "</entry>"
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>order_entry_date</key>"
            v_strOODMessage &= "<value>" & Me.ORDER_ENTRY_DATE & "</value>"
            v_strOODMessage &= "</entry>"
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>order_number</key>"
            v_strOODMessage &= "<value>" & Me.ORDER_NUMBER & "</value>"
            v_strOODMessage &= "</entry>"
            v_strOODMessage &= "</contents>"
            v_strOODMessage &= "</placementMessages>"
            Return v_strOODMessage
        Catch ex As Exception
            'On exception
            Throw ex
        End Try
    End Function
#End Region
End Class

Public Class CTCI_1D
#Region " Declaration "
    Private v_strCLIENT_ID_ALPH As String
    Private v_strFILLER As String
    Private v_strFIRM As String
    Private v_strORDER_ENTRY_DATE As String
    Private v_strORDER_NUMBER As String
#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCLIENT_ID_ALPH = String.Empty
        v_strFILLER = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty
    End Sub
    Public Overloads Sub Dispose()
        v_strCLIENT_ID_ALPH = String.Empty
        v_strFILLER = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty
    End Sub
#End Region
#Region " Properties "
    Public Property CLIENT_ID_ALPH() As String
        Get
            Return v_strCLIENT_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCLIENT_ID_ALPH = Value
        End Set
    End Property
    Public Property FILLER() As String
        Get
            Return v_strFILLER
        End Get
        Set(ByVal Value As String)
            v_strFILLER = Value
        End Set
    End Property
    Public Property ORDER_ENTRY_DATE() As String
        Get
            Return v_strORDER_ENTRY_DATE
        End Get
        Set(ByVal Value As String)
            v_strORDER_ENTRY_DATE = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORDER_NUMBER() As String
        Get
            Return v_strORDER_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strORDER_NUMBER = Value
        End Set
    End Property
#End Region
End Class
Public Class CTCI_1E
#Region " Declaration "
    Dim v_strADD_CANCEL_FLAG_ALPH As String
    Dim v_strBOARD_ALPH As String
    Dim v_strCONTACT_ALPH As String
    Dim v_strFIRM As String
    Dim v_strPRICE As String
    Dim v_strSECURITY_SYMBOL_ALPH As String
    Dim v_strSIDE_ALPH As String
    Dim v_strTIME As String
    Dim v_strTRADER_ID_ALPH As String
    Dim v_strVOLUME As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strADD_CANCEL_FLAG_ALPH = String.Empty
        v_strBOARD_ALPH = String.Empty
        v_strCONTACT_ALPH = String.Empty
        v_strFIRM = String.Empty
        v_strPRICE = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strTIME = String.Empty
        v_strTRADER_ID_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strADD_CANCEL_FLAG_ALPH = String.Empty
        v_strBOARD_ALPH = String.Empty
        v_strCONTACT_ALPH = String.Empty
        v_strFIRM = String.Empty
        v_strPRICE = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strTIME = String.Empty
        v_strTRADER_ID_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property ADD_CANCEL_FLAG_ALPH() As String
        Get
            Return v_strADD_CANCEL_FLAG_ALPH
        End Get
        Set(ByVal Value As String)
            v_strADD_CANCEL_FLAG_ALPH = Value
        End Set
    End Property
    Public Property BOARD_ALPH() As String
        Get
            Return v_strBOARD_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBOARD_ALPH = Value
        End Set
    End Property
    Public Property CONTACT_ALPH() As String
        Get
            Return v_strCONTACT_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCONTACT_ALPH = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property SECURITY_SYMBOL_ALPH() As String
        Get
            Return v_strSECURITY_SYMBOL_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_SYMBOL_ALPH = Value
        End Set
    End Property
    Public Property SIDE_ALPH() As String
        Get
            Return v_strSIDE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_ALPH = Value
        End Set
    End Property
    Public Property TIME() As String
        Get
            Return v_strTIME
        End Get
        Set(ByVal Value As String)
            v_strTIME = Value
        End Set
    End Property
    Public Property TRADER_ID_ALPH() As String
        Get
            Return v_strTRADER_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_ALPH = Value
        End Set
    End Property
    Public Property VOLUME() As String
        Get
            Return v_strVOLUME
        End Get
        Set(ByVal Value As String)
            v_strVOLUME = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_1F
#Region " Declaration "
    Dim v_strBOARD_ALPH As String
    Dim v_strBROKER_CLIENT_VOLUME_BUYER As String
    Dim v_strBROKER_CLIENT_VOLUME_SELLER As String
    Dim v_strBROKER_FOREIGN_VOLUME_BUYER As String
    Dim v_strBROKER_FOREIGN_VOLUME_SELLER As String
    Dim v_strBROKER_PORTFOLIO_VOLUME_BUYER As String
    Dim v_strBROKER_PORTFOLIO_VOLUME_SELLER As String
    Dim v_strCLIENT_ID_BUYER_ALPH As String
    Dim v_strCLIENT_ID_SELLER_ALPH As String
    Dim v_strDEAL_ID_ALPH As String
    Dim v_strFILLER_1 As String
    Dim v_strFILLER_2 As String
    Dim v_strFILLER_3 As String
    Dim v_strFIRM As String
    Dim v_strMUTUAL_FUND_VOLUME_BUYER As String
    Dim v_strMUTUAL_FUND_VOLUME_SELLER As String
    Dim v_strPRICE As String
    Dim v_strSECURITY_SYMBOL_ALPH As String
    Dim v_strTRADER_ID_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strBOARD_ALPH = String.Empty
        v_strBROKER_CLIENT_VOLUME_BUYER = String.Empty
        v_strBROKER_CLIENT_VOLUME_SELLER = String.Empty
        v_strBROKER_FOREIGN_VOLUME_BUYER = String.Empty
        v_strBROKER_FOREIGN_VOLUME_SELLER = String.Empty
        v_strBROKER_PORTFOLIO_VOLUME_BUYER = String.Empty
        v_strBROKER_PORTFOLIO_VOLUME_SELLER = String.Empty
        v_strCLIENT_ID_BUYER_ALPH = String.Empty
        v_strCLIENT_ID_SELLER_ALPH = String.Empty
        v_strDEAL_ID_ALPH = String.Empty
        v_strFILLER_1 = String.Empty
        v_strFILLER_2 = String.Empty
        v_strFILLER_3 = String.Empty
        v_strFIRM = String.Empty
        v_strMUTUAL_FUND_VOLUME_BUYER = String.Empty
        v_strMUTUAL_FUND_VOLUME_SELLER = String.Empty
        v_strPRICE = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strTRADER_ID_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strBOARD_ALPH = String.Empty
        v_strBROKER_CLIENT_VOLUME_BUYER = String.Empty
        v_strBROKER_CLIENT_VOLUME_SELLER = String.Empty
        v_strBROKER_FOREIGN_VOLUME_BUYER = String.Empty
        v_strBROKER_FOREIGN_VOLUME_SELLER = String.Empty
        v_strBROKER_PORTFOLIO_VOLUME_BUYER = String.Empty
        v_strBROKER_PORTFOLIO_VOLUME_SELLER = String.Empty
        v_strCLIENT_ID_BUYER_ALPH = String.Empty
        v_strCLIENT_ID_SELLER_ALPH = String.Empty
        v_strDEAL_ID_ALPH = String.Empty
        v_strFILLER_1 = String.Empty
        v_strFILLER_2 = String.Empty
        v_strFILLER_3 = String.Empty
        v_strFIRM = String.Empty
        v_strMUTUAL_FUND_VOLUME_BUYER = String.Empty
        v_strMUTUAL_FUND_VOLUME_SELLER = String.Empty
        v_strPRICE = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strTRADER_ID_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property BOARD_ALPH() As String
        Get
            Return v_strBOARD_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBOARD_ALPH = Value
        End Set
    End Property
    Public Property BROKER_CLIENT_VOLUME_BUYER() As String
        Get
            Return v_strBROKER_CLIENT_VOLUME_BUYER
        End Get
        Set(ByVal Value As String)
            v_strBROKER_CLIENT_VOLUME_BUYER = Value
        End Set
    End Property
    Public Property BROKER_CLIENT_VOLUME_SELLER() As String
        Get
            Return v_strBROKER_CLIENT_VOLUME_SELLER
        End Get
        Set(ByVal Value As String)
            v_strBROKER_CLIENT_VOLUME_SELLER = Value
        End Set
    End Property
    Public Property BROKER_FOREIGN_VOLUME_BUYER() As String
        Get
            Return v_strBROKER_FOREIGN_VOLUME_BUYER
        End Get
        Set(ByVal Value As String)
            v_strBROKER_FOREIGN_VOLUME_BUYER = Value
        End Set
    End Property
    Public Property BROKER_FOREIGN_VOLUME_SELLER() As String
        Get
            Return v_strBROKER_FOREIGN_VOLUME_SELLER
        End Get
        Set(ByVal Value As String)
            v_strBROKER_FOREIGN_VOLUME_SELLER = Value
        End Set
    End Property
    Public Property BROKER_PORTFOLIO_VOLUME_BUYER() As String
        Get
            Return v_strBROKER_PORTFOLIO_VOLUME_BUYER
        End Get
        Set(ByVal Value As String)
            v_strBROKER_PORTFOLIO_VOLUME_BUYER = Value
        End Set
    End Property
    Public Property BROKER_PORTFOLIO_VOLUME_SELLER() As String
        Get
            Return v_strBROKER_PORTFOLIO_VOLUME_SELLER
        End Get
        Set(ByVal Value As String)
            v_strBROKER_PORTFOLIO_VOLUME_SELLER = Value
        End Set
    End Property
    Public Property CLIENT_ID_BUYER_ALPH() As String
        Get
            Return v_strCLIENT_ID_BUYER_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCLIENT_ID_BUYER_ALPH = Value
        End Set
    End Property
    Public Property CLIENT_ID_SELLER_ALPH() As String
        Get
            Return v_strCLIENT_ID_SELLER_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCLIENT_ID_SELLER_ALPH = Value
        End Set
    End Property
    Public Property DEAL_ID_ALPH() As String
        Get
            Return v_strDEAL_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strDEAL_ID_ALPH = Value
        End Set
    End Property
    Public Property FILLER_1() As String
        Get
            Return v_strFILLER_1
        End Get
        Set(ByVal Value As String)
            v_strFILLER_1 = Value
        End Set
    End Property
    Public Property FILLER_2() As String
        Get
            Return v_strFILLER_2
        End Get
        Set(ByVal Value As String)
            v_strFILLER_2 = Value
        End Set
    End Property
    Public Property FILLER_3() As String
        Get
            Return v_strFILLER_3
        End Get
        Set(ByVal Value As String)
            v_strFILLER_3 = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property MUTUAL_FUND_VOLUME_BUYER() As String
        Get
            Return v_strMUTUAL_FUND_VOLUME_BUYER
        End Get
        Set(ByVal Value As String)
            v_strMUTUAL_FUND_VOLUME_BUYER = Value
        End Set
    End Property
    Public Property MUTUAL_FUND_VOLUME_SELLER() As String
        Get
            Return v_strMUTUAL_FUND_VOLUME_SELLER
        End Get
        Set(ByVal Value As String)
            v_strMUTUAL_FUND_VOLUME_SELLER = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property SECURITY_SYMBOL_ALPH() As String
        Get
            Return v_strSECURITY_SYMBOL_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_SYMBOL_ALPH = Value
        End Set
    End Property
    Public Property TRADER_ID_ALPH() As String
        Get
            Return v_strTRADER_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_ALPH = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_1G
#Region " Declaration "
    Dim v_strBOARD_ALPH As String
    Dim v_strBROKER_CLIENT_VOLUME_SELLER As String
    Dim v_strBROKER_FOREIGN_VOLUME_SELLER As String
    Dim v_strBROKER_PORTFOLIO_VOLUME_SELLER As String
    Dim v_strCLIENT_ID_SELLER_ALPH As String
    Dim v_strCONTRA_FIRM_BUYER As String
    Dim v_strDEAL_ID As String
    Dim v_strFILLER_1 As String
    Dim v_strFILLER_2 As String
    Dim v_strFIRM_SELLER As String
    Dim v_strMUTUAL_FUND_VOLUME_SELLER As String
    Dim v_strPRICE As String
    Dim v_strSECURITY_SYMBOL_ALPH As String
    Dim v_strTRADER_ID_BUYER_ALPH As String
    Dim v_strTRADER_ID_SELLER_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strBOARD_ALPH = String.Empty
        v_strBROKER_CLIENT_VOLUME_SELLER = String.Empty
        v_strBROKER_FOREIGN_VOLUME_SELLER = String.Empty
        v_strBROKER_PORTFOLIO_VOLUME_SELLER = String.Empty
        v_strCLIENT_ID_SELLER_ALPH = String.Empty
        v_strCONTRA_FIRM_BUYER = String.Empty
        v_strDEAL_ID = String.Empty
        v_strFILLER_1 = String.Empty
        v_strFILLER_2 = String.Empty
        v_strFIRM_SELLER = String.Empty
        v_strMUTUAL_FUND_VOLUME_SELLER = String.Empty
        v_strPRICE = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strTRADER_ID_BUYER_ALPH = String.Empty
        v_strTRADER_ID_SELLER_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strBOARD_ALPH = String.Empty
        v_strBROKER_CLIENT_VOLUME_SELLER = String.Empty
        v_strBROKER_FOREIGN_VOLUME_SELLER = String.Empty
        v_strBROKER_PORTFOLIO_VOLUME_SELLER = String.Empty
        v_strCLIENT_ID_SELLER_ALPH = String.Empty
        v_strCONTRA_FIRM_BUYER = String.Empty
        v_strDEAL_ID = String.Empty
        v_strFILLER_1 = String.Empty
        v_strFILLER_2 = String.Empty
        v_strFIRM_SELLER = String.Empty
        v_strMUTUAL_FUND_VOLUME_SELLER = String.Empty
        v_strPRICE = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strTRADER_ID_BUYER_ALPH = String.Empty
        v_strTRADER_ID_SELLER_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property BOARD_ALPH() As String
        Get
            Return v_strBOARD_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBOARD_ALPH = Value
        End Set
    End Property
    Public Property BROKER_CLIENT_VOLUME_SELLER() As String
        Get
            Return v_strBROKER_CLIENT_VOLUME_SELLER
        End Get
        Set(ByVal Value As String)
            v_strBROKER_CLIENT_VOLUME_SELLER = Value
        End Set
    End Property
    Public Property BROKER_FOREIGN_VOLUME_SELLER() As String
        Get
            Return v_strBROKER_FOREIGN_VOLUME_SELLER
        End Get
        Set(ByVal Value As String)
            v_strBROKER_FOREIGN_VOLUME_SELLER = Value
        End Set
    End Property
    Public Property BROKER_PORTFOLIO_VOLUME_SELLER() As String
        Get
            Return v_strBROKER_PORTFOLIO_VOLUME_SELLER
        End Get
        Set(ByVal Value As String)
            v_strBROKER_PORTFOLIO_VOLUME_SELLER = Value
        End Set
    End Property
    Public Property CLIENT_ID_SELLER_ALPH() As String
        Get
            Return v_strCLIENT_ID_SELLER_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCLIENT_ID_SELLER_ALPH = Value
        End Set
    End Property
    Public Property CONTRA_FIRM_BUYER() As String
        Get
            Return v_strCONTRA_FIRM_BUYER
        End Get
        Set(ByVal Value As String)
            v_strCONTRA_FIRM_BUYER = Value
        End Set
    End Property
    Public Property DEAL_ID() As String
        Get
            Return v_strDEAL_ID
        End Get
        Set(ByVal Value As String)
            v_strDEAL_ID = Value
        End Set
    End Property
    Public Property FILLER_1() As String
        Get
            Return v_strFILLER_1
        End Get
        Set(ByVal Value As String)
            v_strFILLER_1 = Value
        End Set
    End Property
    Public Property FILLER_2() As String
        Get
            Return v_strFILLER_2
        End Get
        Set(ByVal Value As String)
            v_strFILLER_2 = Value
        End Set
    End Property
    Public Property FIRM_SELLER() As String
        Get
            Return v_strFIRM_SELLER
        End Get
        Set(ByVal Value As String)
            v_strFIRM_SELLER = Value
        End Set
    End Property
    Public Property MUTUAL_FUND_VOLUME_SELLER() As String
        Get
            Return v_strMUTUAL_FUND_VOLUME_SELLER
        End Get
        Set(ByVal Value As String)
            v_strMUTUAL_FUND_VOLUME_SELLER = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property SECURITY_SYMBOL_ALPH() As String
        Get
            Return v_strSECURITY_SYMBOL_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_SYMBOL_ALPH = Value
        End Set
    End Property
    Public Property TRADER_ID_BUYER_ALPH() As String
        Get
            Return v_strTRADER_ID_BUYER_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_BUYER_ALPH = Value
        End Set
    End Property
    Public Property TRADER_ID_SELLER_ALPH() As String
        Get
            Return v_strTRADER_ID_SELLER_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_SELLER_ALPH = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_1I
#Region " Declaration "
    Dim v_strBOARD_ALPH As String
    Dim v_strCLIENT_ID_ALPH As String
    Dim v_strFILLER_1 As String
    Dim v_strFILLER_2 As String
    Dim v_strFIRM As String
    Dim v_strORDER_NUMBER As String
    Dim v_strPORT_CLIENT_FLAG_ALPH As String
    Dim v_strPRICE As String
    Dim v_strPUBLISHED_VOLUME As String
    Dim v_strSECURITY_SYMBOL_ALPH As String
    Dim v_strSIDE_ALPH As String
    Dim v_strTRADER_ID_ALPH As String
    Dim v_strVOLUME As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strBOARD_ALPH = String.Empty
        v_strCLIENT_ID_ALPH = String.Empty
        v_strFILLER_1 = String.Empty
        v_strFILLER_2 = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_NUMBER = String.Empty
        v_strPORT_CLIENT_FLAG_ALPH = String.Empty
        v_strPRICE = String.Empty
        v_strPUBLISHED_VOLUME = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strTRADER_ID_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strBOARD_ALPH = String.Empty
        v_strCLIENT_ID_ALPH = String.Empty
        v_strFILLER_1 = String.Empty
        v_strFILLER_2 = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_NUMBER = String.Empty
        v_strPORT_CLIENT_FLAG_ALPH = String.Empty
        v_strPRICE = String.Empty
        v_strPUBLISHED_VOLUME = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strTRADER_ID_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property BOARD_ALPH() As String
        Get
            Return v_strBOARD_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBOARD_ALPH = Value
        End Set
    End Property
    Public Property CLIENT_ID_ALPH() As String
        Get
            Return v_strCLIENT_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCLIENT_ID_ALPH = Value
        End Set
    End Property
    Public Property FILLER_1() As String
        Get
            Return v_strFILLER_1
        End Get
        Set(ByVal Value As String)
            v_strFILLER_1 = Value
        End Set
    End Property
    Public Property FILLER_2() As String
        Get
            Return v_strFILLER_2
        End Get
        Set(ByVal Value As String)
            v_strFILLER_2 = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORDER_NUMBER() As String
        Get
            Return v_strORDER_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strORDER_NUMBER = Value
        End Set
    End Property
    Public Property PORT_CLIENT_FLAG_ALPH() As String
        Get
            Return v_strPORT_CLIENT_FLAG_ALPH
        End Get
        Set(ByVal Value As String)
            v_strPORT_CLIENT_FLAG_ALPH = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property PUBLISHED_VOLUME() As String
        Get
            Return v_strPUBLISHED_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strPUBLISHED_VOLUME = Value
        End Set
    End Property
    Public Property SECURITY_SYMBOL_ALPH() As String
        Get
            Return v_strSECURITY_SYMBOL_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_SYMBOL_ALPH = Value
        End Set
    End Property
    Public Property SIDE_ALPH() As String
        Get
            Return v_strSIDE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_ALPH = Value
        End Set
    End Property
    Public Property TRADER_ID_ALPH() As String
        Get
            Return v_strTRADER_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_ALPH = Value
        End Set
    End Property
    Public Property VOLUME() As String
        Get
            Return v_strVOLUME
        End Get
        Set(ByVal Value As String)
            v_strVOLUME = Value
        End Set
    End Property

#End Region
#Region " Private message "
    Private Function Get_Message(ByVal v_xmlMessage As Xml.XmlDocument) As Long
    
    End Function
    Public Function Gen_Message() As String
        Try
            'Start here
            Dim v_strOODMessage As String = String.Empty
            v_strOODMessage &= "<placementMessages>"
            v_strOODMessage &= "<group />"
            v_strOODMessage &= "<type>1C</type>"
            v_strOODMessage &= "<contents>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>firm</key>"
            v_strOODMessage &= "<value>" & Me.FIRM & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>trader_id_alph</key>"
            v_strOODMessage &= "<value>" & Me.TRADER_ID_ALPH & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>order_number</key>"
            v_strOODMessage &= "<value>" & Me.ORDER_NUMBER & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>client_id_alph</key>"
            v_strOODMessage &= "<value>" & Me.CLIENT_ID_ALPH & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>security_symbol_alph</key>"
            v_strOODMessage &= "<value>" & Me.SECURITY_SYMBOL_ALPH & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>side_alph</key>"
            v_strOODMessage &= "<value>" & Me.SIDE_ALPH & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>volume</key>"
            v_strOODMessage &= "<value>" & Me.VOLUME & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>published_volume</key>"
            v_strOODMessage &= "<value>" & Me.PUBLISHED_VOLUME & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>price</key>"
            v_strOODMessage &= "<value>" & Me.PRICE & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>order_number</key>"
            v_strOODMessage &= "<value>" & Me.ORDER_NUMBER & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>board_alph</key>"
            v_strOODMessage &= "<value>" & Me.BOARD_ALPH & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>filler_1</key>"
            v_strOODMessage &= "<value>" & Me.FILLER_1 & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>port_client_flag_alph</key>"
            v_strOODMessage &= "<value>" & Me.PORT_CLIENT_FLAG_ALPH & "</value>"
            v_strOODMessage &= "</entry>"
            'Add entry
            v_strOODMessage &= "<entry>"
            v_strOODMessage &= "<key>filler_2</key>"
            v_strOODMessage &= "<value>" & Me.FILLER_2 & "</value>"
            v_strOODMessage &= "</entry>"

            v_strOODMessage &= "</contents>"
            v_strOODMessage &= "</placementMessages>"
            Return v_strOODMessage
        Catch ex As Exception
            'On exception
            Throw ex
        End Try
    End Function
#End Region
End Class
Public Class CTCI_2B
#Region " Declaration "
    Dim v_strFIRM As String
    Dim v_strORDER_ENTRY_DATE As String
    Dim v_strORDER_NUMBER As String
#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty
    End Sub
    Public Overloads Sub Dispose()
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty
    End Sub
#End Region
#Region " Properties "
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORDER_ENTRY_DATE() As String
        Get
            Return v_strORDER_ENTRY_DATE
        End Get
        Set(ByVal Value As String)
            v_strORDER_ENTRY_DATE = Value
        End Set
    End Property
    Public Property ORDER_NUMBER() As String
        Get
            Return v_strORDER_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strORDER_NUMBER = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_2C
#Region " Declaration "
    Dim v_strCANCEL_SHARES As String
    Dim v_strFIRM As String
    Dim v_strORDER_CANCEL_STATUS_ALPH As String
    Dim v_strORDER_ENTRY_DATE As String
    Dim v_strORDER_NUMBER As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCANCEL_SHARES = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_CANCEL_STATUS_ALPH = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCANCEL_SHARES = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_CANCEL_STATUS_ALPH = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CANCEL_SHARES() As String
        Get
            Return v_strCANCEL_SHARES
        End Get
        Set(ByVal Value As String)
            v_strCANCEL_SHARES = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORDER_CANCEL_STATUS_ALPH() As String
        Get
            Return v_strORDER_CANCEL_STATUS_ALPH
        End Get
        Set(ByVal Value As String)
            v_strORDER_CANCEL_STATUS_ALPH = Value
        End Set
    End Property
    Public Property ORDER_ENTRY_DATE() As String
        Get
            Return v_strORDER_ENTRY_DATE
        End Get
        Set(ByVal Value As String)
            v_strORDER_ENTRY_DATE = Value
        End Set
    End Property
    Public Property ORDER_NUMBER() As String
        Get
            Return v_strORDER_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strORDER_NUMBER = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_2D
#Region " Declaration "
    Dim v_strCLIENTID_ALPH As String
    Dim v_strFILLER As String
    Dim v_strFIRM As String
    Dim v_strORDERENTRYDATE As String
    Dim v_strORDERNUMBER As String
    Dim v_strPORT_CLIENTFLAG_ALPH As String
    Dim v_strPRICE As String
    Dim v_strPUBLISHED_VOLUME As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCLIENTID_ALPH = String.Empty
        v_strFILLER = String.Empty
        v_strFIRM = String.Empty
        v_strORDERENTRYDATE = String.Empty
        v_strORDERNUMBER = String.Empty
        v_strPORT_CLIENTFLAG_ALPH = String.Empty
        v_strPRICE = String.Empty
        v_strPUBLISHED_VOLUME = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCLIENTID_ALPH = String.Empty
        v_strFILLER = String.Empty
        v_strFIRM = String.Empty
        v_strORDERENTRYDATE = String.Empty
        v_strORDERNUMBER = String.Empty
        v_strPORT_CLIENTFLAG_ALPH = String.Empty
        v_strPRICE = String.Empty
        v_strPUBLISHED_VOLUME = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CLIENTID_ALPH() As String
        Get
            Return v_strCLIENTID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCLIENTID_ALPH = Value
        End Set
    End Property
    Public Property FILLER() As String
        Get
            Return v_strFILLER
        End Get
        Set(ByVal Value As String)
            v_strFILLER = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORDERENTRYDATE() As String
        Get
            Return v_strORDERENTRYDATE
        End Get
        Set(ByVal Value As String)
            v_strORDERENTRYDATE = Value
        End Set
    End Property
    Public Property ORDERNUMBER() As String
        Get
            Return v_strORDERNUMBER
        End Get
        Set(ByVal Value As String)
            v_strORDERNUMBER = Value
        End Set
    End Property
    Public Property PORT_CLIENTFLAG_ALPH() As String
        Get
            Return v_strPORT_CLIENTFLAG_ALPH
        End Get
        Set(ByVal Value As String)
            v_strPORT_CLIENTFLAG_ALPH = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property PUBLISHED_VOLUME() As String
        Get
            Return v_strPUBLISHED_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strPUBLISHED_VOLUME = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_2E
#Region " Declaration "
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strFILLER As String
    Dim v_strFIRM As String
    Dim v_strORDER_ENTRY_DATE As String
    Dim v_strORDER_NUMBER As String
    Dim v_strPRICE As String
    Dim v_strSIDE_ALPH As String
    Dim v_strVOLUME As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCONFIRM_NUMBER = String.Empty
        v_strFILLER = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty
        v_strPRICE = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCONFIRM_NUMBER = String.Empty
        v_strFILLER = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE = String.Empty
        v_strORDER_NUMBER = String.Empty
        v_strPRICE = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property FILLER() As String
        Get
            Return v_strFILLER
        End Get
        Set(ByVal Value As String)
            v_strFILLER = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORDER_ENTRY_DATE() As String
        Get
            Return v_strORDER_ENTRY_DATE
        End Get
        Set(ByVal Value As String)
            v_strORDER_ENTRY_DATE = Value
        End Set
    End Property
    Public Property ORDER_NUMBER() As String
        Get
            Return v_strORDER_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strORDER_NUMBER = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property SIDE_ALPH() As String
        Get
            Return v_strSIDE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_ALPH = Value
        End Set
    End Property
    Public Property VOLUME() As String
        Get
            Return v_strVOLUME
        End Get
        Set(ByVal Value As String)
            v_strVOLUME = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_2F
#Region " Declaration "
    Dim v_strBOARD_ALPH As String
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strCONTRA_FIRM_SELL As String
    Dim v_strFIRM_BUY As String
    Dim v_strPRICE As String
    Dim v_strSECURITY_SYMBOL_ALPH As String
    Dim v_strSIDE_B_ALPH As String
    Dim v_strTRADER_ID_BUY_ALPH As String
    Dim v_strTRADER_ID_CONTRA_SIDE_SELL_ALPH As String
    Dim v_strVOLUME As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strBOARD_ALPH = String.Empty
        v_strCONFIRM_NUMBER = String.Empty
        v_strCONTRA_FIRM_SELL = String.Empty
        v_strFIRM_BUY = String.Empty
        v_strPRICE = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSIDE_B_ALPH = String.Empty
        v_strTRADER_ID_BUY_ALPH = String.Empty
        v_strTRADER_ID_CONTRA_SIDE_SELL_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strBOARD_ALPH = String.Empty
        v_strCONFIRM_NUMBER = String.Empty
        v_strCONTRA_FIRM_SELL = String.Empty
        v_strFIRM_BUY = String.Empty
        v_strPRICE = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSIDE_B_ALPH = String.Empty
        v_strTRADER_ID_BUY_ALPH = String.Empty
        v_strTRADER_ID_CONTRA_SIDE_SELL_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property BOARD_ALPH() As String
        Get
            Return v_strBOARD_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBOARD_ALPH = Value
        End Set
    End Property
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property CONTRA_FIRM_SELL() As String
        Get
            Return v_strCONTRA_FIRM_SELL
        End Get
        Set(ByVal Value As String)
            v_strCONTRA_FIRM_SELL = Value
        End Set
    End Property
    Public Property FIRM_BUY() As String
        Get
            Return v_strFIRM_BUY
        End Get
        Set(ByVal Value As String)
            v_strFIRM_BUY = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property SECURITY_SYMBOL_ALPH() As String
        Get
            Return v_strSECURITY_SYMBOL_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_SYMBOL_ALPH = Value
        End Set
    End Property
    Public Property SIDE_B_ALPH() As String
        Get
            Return v_strSIDE_B_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_B_ALPH = Value
        End Set
    End Property
    Public Property TRADER_ID_BUY_ALPH() As String
        Get
            Return v_strTRADER_ID_BUY_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_BUY_ALPH = Value
        End Set
    End Property
    Public Property TRADER_ID_CONTRA_SIDE_SELL_ALPH() As String
        Get
            Return v_strTRADER_ID_CONTRA_SIDE_SELL_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_CONTRA_SIDE_SELL_ALPH = Value
        End Set
    End Property
    Public Property VOLUME() As String
        Get
            Return v_strVOLUME
        End Get
        Set(ByVal Value As String)
            v_strVOLUME = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_2G
#Region " Declaration "
    Dim v_strFIRM As String
    Dim v_strORIGINAL_MESSAGE_TEXT As String
    Dim v_strREJECT_REASON_CODE As String
    Dim v_strMESSAGE_TYPE As String
    Dim v_strORIGINAL_FIRM As String


#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strFIRM = String.Empty
        v_strORIGINAL_MESSAGE_TEXT = String.Empty
        v_strREJECT_REASON_CODE = String.Empty
        v_strMESSAGE_TYPE = String.Empty
        v_strORIGINAL_FIRM = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strFIRM = String.Empty
        v_strORIGINAL_MESSAGE_TEXT = String.Empty
        v_strREJECT_REASON_CODE = String.Empty
        v_strMESSAGE_TYPE = String.Empty
        v_strORIGINAL_FIRM = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORIGINAL_MESSAGE_TEXT() As String
        Get
            Return v_strORIGINAL_MESSAGE_TEXT
        End Get
        Set(ByVal Value As String)
            v_strORIGINAL_MESSAGE_TEXT = Value
        End Set
    End Property
    Public Property REJECT_REASON_CODE() As String
        Get
            Return v_strREJECT_REASON_CODE
        End Get
        Set(ByVal Value As String)
            v_strREJECT_REASON_CODE = Value
        End Set
    End Property

    Public Property MESSAGE_TYPE() As String
        Get
            Return v_strMESSAGE_TYPE
        End Get
        Set(ByVal Value As String)
            v_strMESSAGE_TYPE = Value
        End Set
    End Property

    Public Property ORIGINAL_FIRM() As String
        Get
            Return v_strORIGINAL_FIRM
        End Get
        Set(ByVal Value As String)
            v_strORIGINAL_FIRM = Value
        End Set
    End Property
#End Region
End Class
Public Class CTCI_2I
#Region " Declaration "
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strFIRM As String
    Dim v_strORDER_ENTRY_DATE_BUY As String
    Dim v_strORDER_ENTRY_DATE_SELL As String
    Dim v_strORDER_NUMBER_BUY As String
    Dim v_strORDER_NUMBER_SELL As String
    Dim v_strPRICE As String
    Dim v_strVOLUME As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCONFIRM_NUMBER = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE_BUY = String.Empty
        v_strORDER_ENTRY_DATE_SELL = String.Empty
        v_strORDER_NUMBER_BUY = String.Empty
        v_strORDER_NUMBER_SELL = String.Empty
        v_strPRICE = String.Empty
        v_strVOLUME = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCONFIRM_NUMBER = String.Empty
        v_strFIRM = String.Empty
        v_strORDER_ENTRY_DATE_BUY = String.Empty
        v_strORDER_ENTRY_DATE_SELL = String.Empty
        v_strORDER_NUMBER_BUY = String.Empty
        v_strORDER_NUMBER_SELL = String.Empty
        v_strPRICE = String.Empty
        v_strVOLUME = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORDER_ENTRY_DATE_BUY() As String
        Get
            Return v_strORDER_ENTRY_DATE_BUY
        End Get
        Set(ByVal Value As String)
            v_strORDER_ENTRY_DATE_BUY = Value
        End Set
    End Property
    Public Property ORDER_ENTRY_DATE_SELL() As String
        Get
            Return v_strORDER_ENTRY_DATE_SELL
        End Get
        Set(ByVal Value As String)
            v_strORDER_ENTRY_DATE_SELL = Value
        End Set
    End Property
    Public Property ORDER_NUMBER_BUY() As String
        Get
            Return v_strORDER_NUMBER_BUY
        End Get
        Set(ByVal Value As String)
            v_strORDER_NUMBER_BUY = Value
        End Set
    End Property
    Public Property ORDER_NUMBER_SELL() As String
        Get
            Return v_strORDER_NUMBER_SELL
        End Get
        Set(ByVal Value As String)
            v_strORDER_NUMBER_SELL = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property VOLUME() As String
        Get
            Return v_strVOLUME
        End Get
        Set(ByVal Value As String)
            v_strVOLUME = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_2L
#Region " Declaration "
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strCONTRA_FIRM As String
    Dim v_strDEAL_ID As String
    Dim v_strFIRM As String
    Dim v_strPRICE As String
    Dim v_strSIDE_ALPH As String
    Dim v_strVOLUME As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCONFIRM_NUMBER = String.Empty
        v_strCONTRA_FIRM = String.Empty
        v_strDEAL_ID = String.Empty
        v_strFIRM = String.Empty
        v_strPRICE = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCONFIRM_NUMBER = String.Empty
        v_strCONTRA_FIRM = String.Empty
        v_strDEAL_ID = String.Empty
        v_strFIRM = String.Empty
        v_strPRICE = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strVOLUME = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property CONTRA_FIRM() As String
        Get
            Return v_strCONTRA_FIRM
        End Get
        Set(ByVal Value As String)
            v_strCONTRA_FIRM = Value
        End Set
    End Property
    Public Property DEAL_ID() As String
        Get
            Return v_strDEAL_ID
        End Get
        Set(ByVal Value As String)
            v_strDEAL_ID = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property SIDE_ALPH() As String
        Get
            Return v_strSIDE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_ALPH = Value
        End Set
    End Property
    Public Property VOLUME() As String
        Get
            Return v_strVOLUME
        End Get
        Set(ByVal Value As String)
            v_strVOLUME = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_3A
#Region " Declaration "
    Dim v_strADMIN_MESSAGE_TEXT As String
    Dim v_strCONTRA_FIRM As String
    Dim v_strFIRM As String
    Dim v_strTRADER_ID_RECEIVER_ALPH As String
    Dim v_strTRADER_ID_SENDER_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strADMIN_MESSAGE_TEXT = String.Empty
        v_strCONTRA_FIRM = String.Empty
        v_strFIRM = String.Empty
        v_strTRADER_ID_RECEIVER_ALPH = String.Empty
        v_strTRADER_ID_SENDER_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strADMIN_MESSAGE_TEXT = String.Empty
        v_strCONTRA_FIRM = String.Empty
        v_strFIRM = String.Empty
        v_strTRADER_ID_RECEIVER_ALPH = String.Empty
        v_strTRADER_ID_SENDER_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property ADMIN_MESSAGE_TEXT() As String
        Get
            Return v_strADMIN_MESSAGE_TEXT
        End Get
        Set(ByVal Value As String)
            v_strADMIN_MESSAGE_TEXT = Value
        End Set
    End Property
    Public Property CONTRA_FIRM() As String
        Get
            Return v_strCONTRA_FIRM
        End Get
        Set(ByVal Value As String)
            v_strCONTRA_FIRM = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property TRADER_ID_RECEIVER_ALPH() As String
        Get
            Return v_strTRADER_ID_RECEIVER_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_RECEIVER_ALPH = Value
        End Set
    End Property
    Public Property TRADER_ID_SENDER_ALPH() As String
        Get
            Return v_strTRADER_ID_SENDER_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_SENDER_ALPH = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_3B
#Region " Declaration "
    Dim v_strBROKER_CLIENT_VOLUME As String
    Dim v_strBROKER_FOREIGN_VOLUME As String
    Dim v_strBROKER_MUTUAL_FUND_VOLUME As String
    Dim v_strBROKER_PORTFOLIO_VOLUME As String
    Dim v_strCLIENT_ID_BUYER_ALPH As String
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strDEAL_ID As String
    Dim v_strFILLER_1 As String
    Dim v_strFILLER_2 As String
    Dim v_strFIRM As String
    Dim v_strREPLY_CODE_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strBROKER_CLIENT_VOLUME = String.Empty
        v_strBROKER_FOREIGN_VOLUME = String.Empty
        v_strBROKER_MUTUAL_FUND_VOLUME = String.Empty
        v_strBROKER_PORTFOLIO_VOLUME = String.Empty
        v_strCLIENT_ID_BUYER_ALPH = String.Empty
        v_strCONFIRM_NUMBER = String.Empty
        v_strDEAL_ID = String.Empty
        v_strFILLER_1 = String.Empty
        v_strFILLER_2 = String.Empty
        v_strFIRM = String.Empty
        v_strREPLY_CODE_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strBROKER_CLIENT_VOLUME = String.Empty
        v_strBROKER_FOREIGN_VOLUME = String.Empty
        v_strBROKER_MUTUAL_FUND_VOLUME = String.Empty
        v_strBROKER_PORTFOLIO_VOLUME = String.Empty
        v_strCLIENT_ID_BUYER_ALPH = String.Empty
        v_strCONFIRM_NUMBER = String.Empty
        v_strDEAL_ID = String.Empty
        v_strFILLER_1 = String.Empty
        v_strFILLER_2 = String.Empty
        v_strFIRM = String.Empty
        v_strREPLY_CODE_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property BROKER_CLIENT_VOLUME() As String
        Get
            Return v_strBROKER_CLIENT_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strBROKER_CLIENT_VOLUME = Value
        End Set
    End Property
    Public Property BROKER_FOREIGN_VOLUME() As String
        Get
            Return v_strBROKER_FOREIGN_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strBROKER_FOREIGN_VOLUME = Value
        End Set
    End Property
    Public Property BROKER_MUTUAL_FUND_VOLUME() As String
        Get
            Return v_strBROKER_MUTUAL_FUND_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strBROKER_MUTUAL_FUND_VOLUME = Value
        End Set
    End Property
    Public Property BROKER_PORTFOLIO_VOLUME() As String
        Get
            Return v_strBROKER_PORTFOLIO_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strBROKER_PORTFOLIO_VOLUME = Value
        End Set
    End Property
    Public Property CLIENT_ID_BUYER_ALPH() As String
        Get
            Return v_strCLIENT_ID_BUYER_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCLIENT_ID_BUYER_ALPH = Value
        End Set
    End Property
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property DEAL_ID() As String
        Get
            Return v_strDEAL_ID
        End Get
        Set(ByVal Value As String)
            v_strDEAL_ID = Value
        End Set
    End Property
    Public Property FILLER_1() As String
        Get
            Return v_strFILLER_1
        End Get
        Set(ByVal Value As String)
            v_strFILLER_1 = Value
        End Set
    End Property
    Public Property FILLER_2() As String
        Get
            Return v_strFILLER_2
        End Get
        Set(ByVal Value As String)
            v_strFILLER_2 = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property REPLY_CODE_ALPH() As String
        Get
            Return v_strREPLY_CODE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strREPLY_CODE_ALPH = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_3C
#Region " Declaration "
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strCONTRA_FIRM As String
    Dim v_strFIRM As String
    Dim v_strSECURITY_SYMBOL_ALPH As String
    Dim v_strSIDE_ALPH As String
    Dim v_strTRADER_ID_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCONFIRM_NUMBER = String.Empty
        v_strCONTRA_FIRM = String.Empty
        v_strFIRM = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strTRADER_ID_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCONFIRM_NUMBER = String.Empty
        v_strCONTRA_FIRM = String.Empty
        v_strFIRM = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strTRADER_ID_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property CONTRA_FIRM() As String
        Get
            Return v_strCONTRA_FIRM
        End Get
        Set(ByVal Value As String)
            v_strCONTRA_FIRM = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property SECURITY_SYMBOL_ALPH() As String
        Get
            Return v_strSECURITY_SYMBOL_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_SYMBOL_ALPH = Value
        End Set
    End Property
    Public Property SIDE_ALPH() As String
        Get
            Return v_strSIDE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_ALPH = Value
        End Set
    End Property
    Public Property TRADER_ID_ALPH() As String
        Get
            Return v_strTRADER_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID_ALPH = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_3D
#Region " Declaration "
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strFIRM As String
    Dim v_strREPLY_CODE_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCONFIRM_NUMBER = String.Empty
        v_strFIRM = String.Empty
        v_strREPLY_CODE_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCONFIRM_NUMBER = String.Empty
        v_strFIRM = String.Empty
        v_strREPLY_CODE_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property REPLY_CODE_ALPH() As String
        Get
            Return v_strREPLY_CODE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strREPLY_CODE_ALPH = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_RN
#Region " Declaration "
    Dim v_strERROR_CODE_ALPH As String
    Dim v_strFIRM As String
    Dim v_strORIGINAL_MESSAGE_TEXT As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strERROR_CODE_ALPH = String.Empty
        v_strFIRM = String.Empty
        v_strORIGINAL_MESSAGE_TEXT = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strERROR_CODE_ALPH = String.Empty
        v_strFIRM = String.Empty
        v_strORIGINAL_MESSAGE_TEXT = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property ERROR_CODE_ALPH() As String
        Get
            Return v_strERROR_CODE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strERROR_CODE_ALPH = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property ORIGINAL_MESSAGE_TEXT() As String
        Get
            Return v_strORIGINAL_MESSAGE_TEXT
        End Get
        Set(ByVal Value As String)
            v_strORIGINAL_MESSAGE_TEXT = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_RP
#Region " Declaration "
    Dim v_strFIRM As String
    Dim v_strMARKET_ID_ALPH As String
    Dim v_strMESSAGE_COUNT As String
    Dim v_strORIGINAL_BROADCAST_MESSAGE As String
    Dim v_strPREVIOUS_SEQUENCE_NUMBER As String
    Dim v_strSEQUENCE_NUMBER As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strFIRM = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strMESSAGE_COUNT = String.Empty
        v_strORIGINAL_BROADCAST_MESSAGE = String.Empty
        v_strPREVIOUS_SEQUENCE_NUMBER = String.Empty
        v_strSEQUENCE_NUMBER = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strFIRM = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strMESSAGE_COUNT = String.Empty
        v_strORIGINAL_BROADCAST_MESSAGE = String.Empty
        v_strPREVIOUS_SEQUENCE_NUMBER = String.Empty
        v_strSEQUENCE_NUMBER = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property MARKET_ID_ALPH() As String
        Get
            Return v_strMARKET_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strMARKET_ID_ALPH = Value
        End Set
    End Property
    Public Property MESSAGE_COUNT() As String
        Get
            Return v_strMESSAGE_COUNT
        End Get
        Set(ByVal Value As String)
            v_strMESSAGE_COUNT = Value
        End Set
    End Property
    Public Property ORIGINAL_BROADCAST_MESSAGE() As String
        Get
            Return v_strORIGINAL_BROADCAST_MESSAGE
        End Get
        Set(ByVal Value As String)
            v_strORIGINAL_BROADCAST_MESSAGE = Value
        End Set
    End Property
    Public Property PREVIOUS_SEQUENCE_NUMBER() As String
        Get
            Return v_strPREVIOUS_SEQUENCE_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strPREVIOUS_SEQUENCE_NUMBER = Value
        End Set
    End Property
    Public Property SEQUENCE_NUMBER() As String
        Get
            Return v_strSEQUENCE_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSEQUENCE_NUMBER = Value
        End Set
    End Property

#End Region
End Class
Public Class CTCI_RQ
#Region " Declaration "
    Dim v_strFIRM As String
    Dim v_strMARKET_ID_ALPH As String
    Dim v_strRETRANSMISSION_END_SEQUENCE As String
    Dim v_strRETRANSMISSION_START_SEQUENCE As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strFIRM = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strRETRANSMISSION_END_SEQUENCE = String.Empty
        v_strRETRANSMISSION_START_SEQUENCE = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strFIRM = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strRETRANSMISSION_END_SEQUENCE = String.Empty
        v_strRETRANSMISSION_START_SEQUENCE = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property MARKET_ID_ALPH() As String
        Get
            Return v_strMARKET_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strMARKET_ID_ALPH = Value
        End Set
    End Property
    Public Property RETRANSMISSION_END_SEQUENCE() As String
        Get
            Return v_strRETRANSMISSION_END_SEQUENCE
        End Get
        Set(ByVal Value As String)
            v_strRETRANSMISSION_END_SEQUENCE = Value
        End Set
    End Property
    Public Property RETRANSMISSION_START_SEQUENCE() As String
        Get
            Return v_strRETRANSMISSION_START_SEQUENCE
        End Get
        Set(ByVal Value As String)
            v_strRETRANSMISSION_START_SEQUENCE = Value
        End Set
    End Property

#End Region
End Class


'-------------------------------------------------------------------
'------------------------End of CTCI Class -------------------------
'-------------------------------------------------------------------

'-------------------------------------------------------------------
'------------------------PRS Class --------------------------------
'-------------------------------------------------------------------

Public Class PRS_SC
#Region " Declaration "
    Private v_strSYSTEM_CONTROL_CODE_ALPH As String
    Private v_strTIMESTAMP As String
#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSYSTEM_CONTROL_CODE_ALPH = String.Empty
        v_strTIMESTAMP = String.Empty
    End Sub
    Public Overloads Sub Dispose()
        v_strSYSTEM_CONTROL_CODE_ALPH = String.Empty
        v_strTIMESTAMP = String.Empty
    End Sub
#End Region
#Region " Properties "
   
    Public Property SYSTEM_CONTROL_CODE_ALPH() As String
        Get
            Return v_strSYSTEM_CONTROL_CODE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSYSTEM_CONTROL_CODE_ALPH = Value
        End Set
    End Property
    Public Property TIMESTAMP() As String
        Get
            Return v_strTIMESTAMP
        End Get
        Set(ByVal Value As String)
            v_strTIMESTAMP = Value
        End Set
    End Property
#End Region
#Region " Private message "
#End Region
End Class


Public Class PRS_TS
#Region " Declaration "
    Private v_strTIMESTAMP As String
#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strTIMESTAMP = String.Empty
    End Sub
    Public Overloads Sub Dispose()
        v_strTIMESTAMP = String.Empty
    End Sub
#End Region
#Region " Properties "
    Public Property TIMESTAMP() As String
        Get
            Return v_strTIMESTAMP
        End Get
        Set(ByVal Value As String)
            v_strTIMESTAMP = Value
        End Set
    End Property
#End Region
#Region " Private message "
#End Region
End Class


Public Class PRS_AA
#Region " Declaration "
    Dim v_strSECURITY_NUMBER As String
    Dim v_strVOLUME As String
    Dim v_strPRICE As String
    Dim v_strFIRM As String
    Dim v_strTRADER As String
    Dim v_strSIDE_ALPH As String
    Dim v_strBOARD_ALPH As String
    Dim v_strTIME As String
    Dim v_strADD_CANCEL_FLAG_ALPH As String
    Dim v_strCONTACT_ALPH As String
#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSECURITY_NUMBER = String.Empty
        v_strVOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strFIRM = String.Empty
        v_strTRADER = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strBOARD_ALPH = String.Empty
        v_strTIME = String.Empty
        v_strADD_CANCEL_FLAG_ALPH = String.Empty
        v_strCONTACT_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strSECURITY_NUMBER = String.Empty
        v_strVOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strFIRM = String.Empty
        v_strTRADER = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strBOARD_ALPH = String.Empty
        v_strTIME = String.Empty
        v_strADD_CANCEL_FLAG_ALPH = String.Empty
        v_strCONTACT_ALPH = String.Empty
    End Sub
#End Region
#Region " Properties "
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property VOLUME() As String
        Get
            Return v_strVOLUME
        End Get
        Set(ByVal Value As String)
            v_strVOLUME = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property TRADER() As String
        Get
            Return v_strTRADER
        End Get
        Set(ByVal Value As String)
            v_strTRADER = Value
        End Set
    End Property
    Public Property SIDE_ALPH() As String
        Get
            Return v_strSIDE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_ALPH = Value
        End Set
    End Property
    Public Property BOARD_ALPH() As String
        Get
            Return v_strBOARD_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBOARD_ALPH = Value
        End Set
    End Property
    Public Property TIME() As String
        Get
            Return v_strTIME
        End Get
        Set(ByVal Value As String)
            v_strTIME = Value
        End Set
    End Property
    Public Property ADD_CANCEL_FLAG_ALPH() As String
        Get
            Return v_strADD_CANCEL_FLAG_ALPH
        End Get
        Set(ByVal Value As String)
            v_strADD_CANCEL_FLAG_ALPH = Value
        End Set
    End Property
    Public Property CONTACT_ALPH() As String
        Get
            Return v_strCONTACT_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCONTACT_ALPH = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class

Public Class PRS_BR
#Region " Declaration "
    Dim v_strFIRM As String
    Dim v_strMARKET_ID_ALPH As String
    Dim v_strVOLUME_SOLD As String
    Dim v_strVALUE_SOLD As String
    Dim v_strVOLUME_BOUGHT As String
    Dim v_strVALUE_BOUGHT As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strFIRM = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strVOLUME_SOLD = String.Empty
        v_strVALUE_SOLD = String.Empty
        v_strVOLUME_BOUGHT = String.Empty
        v_strVALUE_BOUGHT = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strFIRM = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strVOLUME_SOLD = String.Empty
        v_strVALUE_SOLD = String.Empty
        v_strVOLUME_BOUGHT = String.Empty
        v_strVALUE_BOUGHT = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property MARKET_ID_ALPH() As String
        Get
            Return v_strMARKET_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strMARKET_ID_ALPH = Value
        End Set
    End Property
    Public Property VOLUME_SOLD() As String
        Get
            Return v_strVOLUME_SOLD
        End Get
        Set(ByVal Value As String)
            v_strVOLUME_SOLD = Value
        End Set
    End Property
    Public Property VALUE_SOLD() As String
        Get
            Return v_strVALUE_SOLD
        End Get
        Set(ByVal Value As String)
            v_strVALUE_SOLD = Value
        End Set
    End Property
    Public Property VOLUME_BOUGHT() As String
        Get
            Return v_strVOLUME_BOUGHT
        End Get
        Set(ByVal Value As String)
            v_strVOLUME_BOUGHT = Value
        End Set
    End Property
    Public Property VALUE_BOUGHT() As String
        Get
            Return v_strVALUE_BOUGHT
        End Get
        Set(ByVal Value As String)
            v_strVALUE_BOUGHT = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_BS
#Region " Declaration "
    Dim v_strFIRM As String
    Dim v_strAUTOMATCH_HALT_FLAG_ALPH As String
    Dim v_strPUT_THROUGH_HALT_FLAG_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strFIRM = String.Empty
        v_strAUTOMATCH_HALT_FLAG_ALPH = String.Empty
        v_strPUT_THROUGH_HALT_FLAG_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strFIRM = String.Empty
        v_strAUTOMATCH_HALT_FLAG_ALPH = String.Empty
        v_strPUT_THROUGH_HALT_FLAG_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property AUTOMATCH_HALT_FLAG_ALPH() As String
        Get
            Return v_strAUTOMATCH_HALT_FLAG_ALPH
        End Get
        Set(ByVal Value As String)
            v_strAUTOMATCH_HALT_FLAG_ALPH = Value
        End Set
    End Property
    Public Property PUT_THROUGH_HALT_FLAG_ALPH() As String
        Get
            Return v_strPUT_THROUGH_HALT_FLAG_ALPH
        End Get
        Set(ByVal Value As String)
            v_strPUT_THROUGH_HALT_FLAG_ALPH = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_CO
#Region " Declaration "
    Dim v_strREFERENCE_NUMBER As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strREFERENCE_NUMBER = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strREFERENCE_NUMBER = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property REFERENCE_NUMBER() As String
        Get
            Return v_strREFERENCE_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strREFERENCE_NUMBER = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_DC
#Region " Declaration "
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strSECURITY_NUMBER As String
    Dim v_strVOLUME As String
    Dim v_strPRICE As String
    Dim v_strBOARD_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCONFIRM_NUMBER = String.Empty
        v_strSECURITY_NUMBER = String.Empty
        v_strVOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strBOARD_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCONFIRM_NUMBER = String.Empty
        v_strSECURITY_NUMBER = String.Empty
        v_strVOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strBOARD_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property VOLUME() As String
        Get
            Return v_strVOLUME
        End Get
        Set(ByVal Value As String)
            v_strVOLUME = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property BOARD_ALPH() As String
        Get
            Return v_strBOARD_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBOARD_ALPH = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_GA
#Region " Declaration "
    Dim v_strADMIN_MESSAGE_LENGTH As String
    Dim v_strADMIN_MESSAGE_TEXT As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strADMIN_MESSAGE_LENGTH = String.Empty
        v_strADMIN_MESSAGE_TEXT = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strADMIN_MESSAGE_LENGTH = String.Empty
        v_strADMIN_MESSAGE_TEXT = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property ADMIN_MESSAGE_LENGTH() As String
        Get
            Return v_strADMIN_MESSAGE_LENGTH
        End Get
        Set(ByVal Value As String)
            v_strADMIN_MESSAGE_LENGTH = Value
        End Set
    End Property
    Public Property ADMIN_MESSAGE_TEXT() As String
        Get
            Return v_strADMIN_MESSAGE_TEXT
        End Get
        Set(ByVal Value As String)
            v_strADMIN_MESSAGE_TEXT = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_IU
#Region " Declaration "
    Dim v_strINDEX_HOSE As String
    Dim v_strTOTAL_TRADES As String
    Dim v_strTOTAL_SHARES_TRADED As String
    Dim v_strTOTAL_VALUES_TRADED As String
    Dim v_strUP_VOLUME As String
    Dim v_strDOWN_VOLUME As String
    Dim v_strNO_CHANGE_VOLUME As String
    Dim v_strADVANCES_NO_OF_STOCKS As String
    Dim v_strDECLINES_NO_OF_STOCKS As String
    Dim v_strNO_CHANGE_NO_OF_STOCKS As String
    Dim v_strFILLER_1 As String
    Dim v_strMARKET_ID_ALPH As String
    Dim v_strFILLER_2 As String
    Dim v_strINDEX_TIME As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strINDEX_HOSE = String.Empty
        v_strTOTAL_TRADES = String.Empty
        v_strTOTAL_SHARES_TRADED = String.Empty
        v_strTOTAL_VALUES_TRADED = String.Empty
        v_strUP_VOLUME = String.Empty
        v_strDOWN_VOLUME = String.Empty
        v_strNO_CHANGE_VOLUME = String.Empty
        v_strADVANCES_NO_OF_STOCKS = String.Empty
        v_strDECLINES_NO_OF_STOCKS = String.Empty
        v_strNO_CHANGE_NO_OF_STOCKS = String.Empty
        v_strFILLER_1 = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strFILLER_2 = String.Empty
        v_strINDEX_TIME = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strINDEX_HOSE = String.Empty
        v_strTOTAL_TRADES = String.Empty
        v_strTOTAL_SHARES_TRADED = String.Empty
        v_strTOTAL_VALUES_TRADED = String.Empty
        v_strUP_VOLUME = String.Empty
        v_strDOWN_VOLUME = String.Empty
        v_strNO_CHANGE_VOLUME = String.Empty
        v_strADVANCES_NO_OF_STOCKS = String.Empty
        v_strDECLINES_NO_OF_STOCKS = String.Empty
        v_strNO_CHANGE_NO_OF_STOCKS = String.Empty
        v_strFILLER_1 = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strFILLER_2 = String.Empty
        v_strINDEX_TIME = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property INDEX_HOSE() As String
        Get
            Return v_strINDEX_HOSE
        End Get
        Set(ByVal Value As String)
            v_strINDEX_HOSE = Value
        End Set
    End Property
    Public Property TOTAL_TRADES() As String
        Get
            Return v_strTOTAL_TRADES
        End Get
        Set(ByVal Value As String)
            v_strTOTAL_TRADES = Value
        End Set
    End Property
    Public Property TOTAL_SHARES_TRADED() As String
        Get
            Return v_strTOTAL_SHARES_TRADED
        End Get
        Set(ByVal Value As String)
            v_strTOTAL_SHARES_TRADED = Value
        End Set
    End Property
    Public Property TOTAL_VALUES_TRADED() As String
        Get
            Return v_strTOTAL_VALUES_TRADED
        End Get
        Set(ByVal Value As String)
            v_strTOTAL_VALUES_TRADED = Value
        End Set
    End Property
    Public Property UP_VOLUME() As String
        Get
            Return v_strUP_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strUP_VOLUME = Value
        End Set
    End Property
    Public Property DOWN_VOLUME() As String
        Get
            Return v_strDOWN_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strDOWN_VOLUME = Value
        End Set
    End Property
    Public Property NO_CHANGE_VOLUME() As String
        Get
            Return v_strNO_CHANGE_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strNO_CHANGE_VOLUME = Value
        End Set
    End Property
    Public Property ADVANCES_NO_OF_STOCKS() As String
        Get
            Return v_strADVANCES_NO_OF_STOCKS
        End Get
        Set(ByVal Value As String)
            v_strADVANCES_NO_OF_STOCKS = Value
        End Set
    End Property
    Public Property DECLINES_NO_OF_STOCKS() As String
        Get
            Return v_strDECLINES_NO_OF_STOCKS
        End Get
        Set(ByVal Value As String)
            v_strDECLINES_NO_OF_STOCKS = Value
        End Set
    End Property
    Public Property NO_CHANGE_NO_OF_STOCKS() As String
        Get
            Return v_strNO_CHANGE_NO_OF_STOCKS
        End Get
        Set(ByVal Value As String)
            v_strNO_CHANGE_NO_OF_STOCKS = Value
        End Set
    End Property
    Public Property FILLER_1() As String
        Get
            Return v_strFILLER_1
        End Get
        Set(ByVal Value As String)
            v_strFILLER_1 = Value
        End Set
    End Property
    Public Property MARKET_ID_ALPH() As String
        Get
            Return v_strMARKET_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strMARKET_ID_ALPH = Value
        End Set
    End Property
    Public Property FILLER_2() As String
        Get
            Return v_strFILLER_2
        End Get
        Set(ByVal Value As String)
            v_strFILLER_2 = Value
        End Set
    End Property
    Public Property INDEX_TIME() As String
        Get
            Return v_strINDEX_TIME
        End Get
        Set(ByVal Value As String)
            v_strINDEX_TIME = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_LO
#Region " Declaration "
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strSECURITY_NUMBER As String
    Dim v_strODD_LOT_VOLUME As String
    Dim v_strPRICE As String
    Dim v_strREFERENCE_NUMBER As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCONFIRM_NUMBER = String.Empty
        v_strSECURITY_NUMBER = String.Empty
        v_strODD_LOT_VOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strREFERENCE_NUMBER = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCONFIRM_NUMBER = String.Empty
        v_strSECURITY_NUMBER = String.Empty
        v_strODD_LOT_VOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strREFERENCE_NUMBER = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property ODD_LOT_VOLUME() As String
        Get
            Return v_strODD_LOT_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strODD_LOT_VOLUME = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property REFERENCE_NUMBER() As String
        Get
            Return v_strREFERENCE_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strREFERENCE_NUMBER = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_LS
#Region " Declaration "
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strSECURITY_NUMBER As String
    Dim v_strLOT_VOLUME As String
    Dim v_strPRICE As String
    Dim v_strSIDE_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCONFIRM_NUMBER = String.Empty
        v_strSECURITY_NUMBER = String.Empty
        v_strLOT_VOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strSIDE_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCONFIRM_NUMBER = String.Empty
        v_strSECURITY_NUMBER = String.Empty
        v_strLOT_VOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strSIDE_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property LOT_VOLUME() As String
        Get
            Return v_strLOT_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strLOT_VOLUME = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property SIDE_ALPH() As String
        Get
            Return v_strSIDE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_ALPH = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_NH
#Region " Declaration "
    Dim v_strNEWS_NUMBER As String
    Dim v_strSECURITY_SYMBOL_ALPH As String
    Dim v_strNEWS_HEADLINE_LENGTH As String
    Dim v_strTOTAL_NEWS_STORY_PAGES As String
    Dim v_strNEWS_HEADLINE_TEXT As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strNEWS_NUMBER = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strNEWS_HEADLINE_LENGTH = String.Empty
        v_strTOTAL_NEWS_STORY_PAGES = String.Empty
        v_strNEWS_HEADLINE_TEXT = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strNEWS_NUMBER = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strNEWS_HEADLINE_LENGTH = String.Empty
        v_strTOTAL_NEWS_STORY_PAGES = String.Empty
        v_strNEWS_HEADLINE_TEXT = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property NEWS_NUMBER() As String
        Get
            Return v_strNEWS_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strNEWS_NUMBER = Value
        End Set
    End Property
    Public Property SECURITY_SYMBOL_ALPH() As String
        Get
            Return v_strSECURITY_SYMBOL_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_SYMBOL_ALPH = Value
        End Set
    End Property
    Public Property NEWS_HEADLINE_LENGTH() As String
        Get
            Return v_strNEWS_HEADLINE_LENGTH
        End Get
        Set(ByVal Value As String)
            v_strNEWS_HEADLINE_LENGTH = Value
        End Set
    End Property
    Public Property TOTAL_NEWS_STORY_PAGES() As String
        Get
            Return v_strTOTAL_NEWS_STORY_PAGES
        End Get
        Set(ByVal Value As String)
            v_strTOTAL_NEWS_STORY_PAGES = Value
        End Set
    End Property
    Public Property NEWS_HEADLINE_TEXT() As String
        Get
            Return v_strNEWS_HEADLINE_TEXT
        End Get
        Set(ByVal Value As String)
            v_strNEWS_HEADLINE_TEXT = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_NS
#Region " Declaration "
    Dim v_strNEWS_NUMBER As String
    Dim v_strNEWS_PAGE_NUMBER As String
    Dim v_strNEWS_TEXT_LENGTH As String
    Dim v_strNEWS_TEXT As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strNEWS_NUMBER = String.Empty
        v_strNEWS_PAGE_NUMBER = String.Empty
        v_strNEWS_TEXT_LENGTH = String.Empty
        v_strNEWS_TEXT = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strNEWS_NUMBER = String.Empty
        v_strNEWS_PAGE_NUMBER = String.Empty
        v_strNEWS_TEXT_LENGTH = String.Empty
        v_strNEWS_TEXT = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property NEWS_NUMBER() As String
        Get
            Return v_strNEWS_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strNEWS_NUMBER = Value
        End Set
    End Property
    Public Property NEWS_PAGE_NUMBER() As String
        Get
            Return v_strNEWS_PAGE_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strNEWS_PAGE_NUMBER = Value
        End Set
    End Property
    Public Property NEWS_TEXT_LENGTH() As String
        Get
            Return v_strNEWS_TEXT_LENGTH
        End Get
        Set(ByVal Value As String)
            v_strNEWS_TEXT_LENGTH = Value
        End Set
    End Property
    Public Property NEWS_TEXT() As String
        Get
            Return v_strNEWS_TEXT
        End Get
        Set(ByVal Value As String)
            v_strNEWS_TEXT = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_OL
#Region " Declaration "
    Dim v_strSECURITY_NUMBER As String
    Dim v_strODD_LOT_VOLUME As String
    Dim v_strPRICE As String
    Dim v_strSIDE_ALPH As String
    Dim v_strREFERENCE_NUMBER As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSECURITY_NUMBER = String.Empty
        v_strODD_LOT_VOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strREFERENCE_NUMBER = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strSECURITY_NUMBER = String.Empty
        v_strODD_LOT_VOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strREFERENCE_NUMBER = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property ODD_LOT_VOLUME() As String
        Get
            Return v_strODD_LOT_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strODD_LOT_VOLUME = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property SIDE_ALPH() As String
        Get
            Return v_strSIDE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_ALPH = Value
        End Set
    End Property
    Public Property REFERENCE_NUMBER() As String
        Get
            Return v_strREFERENCE_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strREFERENCE_NUMBER = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_OS
#Region " Declaration "
    Dim v_strSECURITY_NUMBER As String
    Dim v_strPRICE As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSECURITY_NUMBER = String.Empty
        v_strPRICE = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strSECURITY_NUMBER = String.Empty
        v_strPRICE = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_PD
#Region " Declaration "
    Dim v_strCONFIRM_NUMBER As String
    Dim v_strSECURITY_NUMBER As String
    Dim v_strVOLUME As String
    Dim v_strPRICE As String
    Dim v_strBOARD_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strCONFIRM_NUMBER = String.Empty
        v_strSECURITY_NUMBER = String.Empty
        v_strVOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strBOARD_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strCONFIRM_NUMBER = String.Empty
        v_strSECURITY_NUMBER = String.Empty
        v_strVOLUME = String.Empty
        v_strPRICE = String.Empty
        v_strBOARD_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property CONFIRM_NUMBER() As String
        Get
            Return v_strCONFIRM_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strCONFIRM_NUMBER = Value
        End Set
    End Property
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property VOLUME() As String
        Get
            Return v_strVOLUME
        End Get
        Set(ByVal Value As String)
            v_strVOLUME = Value
        End Set
    End Property
    Public Property PRICE() As String
        Get
            Return v_strPRICE
        End Get
        Set(ByVal Value As String)
            v_strPRICE = Value
        End Set
    End Property
    Public Property BOARD_ALPH() As String
        Get
            Return v_strBOARD_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBOARD_ALPH = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class
Public Class PRS_PO
#Region " Declaration "
    Dim v_strSECURITY_NUMBER As String
    Dim v_strPROJECTED_OPEN_PRICE As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSECURITY_NUMBER = String.Empty
        v_strPROJECTED_OPEN_PRICE = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strSECURITY_NUMBER = String.Empty
        v_strPROJECTED_OPEN_PRICE = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property PROJECTED_OPEN_PRICE() As String
        Get
            Return v_strPROJECTED_OPEN_PRICE
        End Get
        Set(ByVal Value As String)
            v_strPROJECTED_OPEN_PRICE = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class


Public Class PRS_SI
#Region " Declaration "
    Dim v_strINDEX_SECTORAL As String
    Dim v_strFILLER As String
    Dim v_strINDEX_TIME As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strINDEX_SECTORAL = String.Empty
        v_strFILLER = String.Empty
        v_strINDEX_TIME = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strINDEX_SECTORAL = String.Empty
        v_strFILLER = String.Empty
        v_strINDEX_TIME = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property INDEX_SECTORAL() As String
        Get
            Return v_strINDEX_SECTORAL
        End Get
        Set(ByVal Value As String)
            v_strINDEX_SECTORAL = Value
        End Set
    End Property
    Public Property FILLER() As String
        Get
            Return v_strFILLER
        End Get
        Set(ByVal Value As String)
            v_strFILLER = Value
        End Set
    End Property
    Public Property INDEX_TIME() As String
        Get
            Return v_strINDEX_TIME
        End Get
        Set(ByVal Value As String)
            v_strINDEX_TIME = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class

Public Class PRS_SR
#Region " Declaration "
    Dim v_strSECURITY_NUMBER As String
    Dim v_strMAIN_OR_FOREIGN_DEAL As String
    Dim v_strMAIN_OR_FOREIGN_ACC_VOLUME As String
    Dim v_strMAIN_OR_FOREIGN_ACC_VALUE_IN_1000 As String
    Dim v_strDEALS_IN_BIG_LOT_BOARD As String
    Dim v_strBIG_LOT_ACC_VOLUME As String
    Dim v_strBIG_LOT_ACC_VALUE_IN_1000 As String
    Dim v_strDEALS_IN_ODD_LOT_BOARD As String
    Dim v_strODD_LOT_ACC_VOLUME As String
    Dim v_strODD_LOT_ACC_VALUE As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSECURITY_NUMBER = String.Empty
        v_strMAIN_OR_FOREIGN_DEAL = String.Empty
        v_strMAIN_OR_FOREIGN_ACC_VOLUME = String.Empty
        v_strMAIN_OR_FOREIGN_ACC_VALUE_IN_1000 = String.Empty
        v_strDEALS_IN_BIG_LOT_BOARD = String.Empty
        v_strBIG_LOT_ACC_VOLUME = String.Empty
        v_strBIG_LOT_ACC_VALUE_IN_1000 = String.Empty
        v_strDEALS_IN_ODD_LOT_BOARD = String.Empty
        v_strODD_LOT_ACC_VOLUME = String.Empty
        v_strODD_LOT_ACC_VALUE = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strSECURITY_NUMBER = String.Empty
        v_strMAIN_OR_FOREIGN_DEAL = String.Empty
        v_strMAIN_OR_FOREIGN_ACC_VOLUME = String.Empty
        v_strMAIN_OR_FOREIGN_ACC_VALUE_IN_1000 = String.Empty
        v_strDEALS_IN_BIG_LOT_BOARD = String.Empty
        v_strBIG_LOT_ACC_VOLUME = String.Empty
        v_strBIG_LOT_ACC_VALUE_IN_1000 = String.Empty
        v_strDEALS_IN_ODD_LOT_BOARD = String.Empty
        v_strODD_LOT_ACC_VOLUME = String.Empty
        v_strODD_LOT_ACC_VALUE = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property MAIN_OR_FOREIGN_DEAL() As String
        Get
            Return v_strMAIN_OR_FOREIGN_DEAL
        End Get
        Set(ByVal Value As String)
            v_strMAIN_OR_FOREIGN_DEAL = Value
        End Set
    End Property
    Public Property MAIN_OR_FOREIGN_ACC_VOLUME() As String
        Get
            Return v_strMAIN_OR_FOREIGN_ACC_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strMAIN_OR_FOREIGN_ACC_VOLUME = Value
        End Set
    End Property
    Public Property MAIN_OR_FOREIGN_ACC_VALUE_IN_1000() As String
        Get
            Return v_strMAIN_OR_FOREIGN_ACC_VALUE_IN_1000
        End Get
        Set(ByVal Value As String)
            v_strMAIN_OR_FOREIGN_ACC_VALUE_IN_1000 = Value
        End Set
    End Property
    Public Property DEALS_IN_BIG_LOT_BOARD() As String
        Get
            Return v_strDEALS_IN_BIG_LOT_BOARD
        End Get
        Set(ByVal Value As String)
            v_strDEALS_IN_BIG_LOT_BOARD = Value
        End Set
    End Property
    Public Property BIG_LOT_ACC_VOLUME() As String
        Get
            Return v_strBIG_LOT_ACC_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strBIG_LOT_ACC_VOLUME = Value
        End Set
    End Property
    Public Property BIG_LOT_ACC_VALUE_IN_1000() As String
        Get
            Return v_strBIG_LOT_ACC_VALUE_IN_1000
        End Get
        Set(ByVal Value As String)
            v_strBIG_LOT_ACC_VALUE_IN_1000 = Value
        End Set
    End Property
    Public Property DEALS_IN_ODD_LOT_BOARD() As String
        Get
            Return v_strDEALS_IN_ODD_LOT_BOARD
        End Get
        Set(ByVal Value As String)
            v_strDEALS_IN_ODD_LOT_BOARD = Value
        End Set
    End Property
    Public Property ODD_LOT_ACC_VOLUME() As String
        Get
            Return v_strODD_LOT_ACC_VOLUME
        End Get
        Set(ByVal Value As String)
            v_strODD_LOT_ACC_VOLUME = Value
        End Set
    End Property
    Public Property ODD_LOT_ACC_VALUE() As String
        Get
            Return v_strODD_LOT_ACC_VALUE
        End Get
        Set(ByVal Value As String)
            v_strODD_LOT_ACC_VALUE = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class

Public Class PRS_SS
#Region " Declaration "
    Dim v_strSECURITY_NUMBER As String
    Dim v_strFILLER_1 As String
    Dim v_strSECTOR_NUMBER As String
    Dim v_strFILLER_2 As String
    Dim v_strHALT_RESUME_FLAG_ALPH As String
    Dim v_strSYSTEM_CONTROL_CODE_ALPH As String
    Dim v_strFILLER_3 As String
    Dim v_strSUSPENSION_ALPH As String
    Dim v_strDELIST_ALPH As String
    Dim v_strFILLER_4 As String
    Dim v_strCEILING As String
    Dim v_strFLOOR_PRICE As String
    Dim v_strSECURITY_TYPE_ALPH As String
    Dim v_strPRIOR_CLOSE_PRICE As String
    Dim v_strFILLER_5 As String
    Dim v_strSPLIT_ALPH As String
    Dim v_strBENEFIT_ALPH As String
    Dim v_strMEETING_ALPH As String
    Dim v_strNOTICE_ALPH As String
    Dim v_strBOARD_LOT As String
    Dim v_strFILLER_6 As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSECURITY_NUMBER = String.Empty
        v_strFILLER_1 = String.Empty
        v_strSECTOR_NUMBER = String.Empty
        v_strFILLER_2 = String.Empty
        v_strHALT_RESUME_FLAG_ALPH = String.Empty
        v_strSYSTEM_CONTROL_CODE_ALPH = String.Empty
        v_strFILLER_3 = String.Empty
        v_strSUSPENSION_ALPH = String.Empty
        v_strDELIST_ALPH = String.Empty
        v_strFILLER_4 = String.Empty
        v_strCEILING = String.Empty
        v_strFLOOR_PRICE = String.Empty
        v_strSECURITY_TYPE_ALPH = String.Empty
        v_strPRIOR_CLOSE_PRICE = String.Empty
        v_strFILLER_5 = String.Empty
        v_strSPLIT_ALPH = String.Empty
        v_strBENEFIT_ALPH = String.Empty
        v_strMEETING_ALPH = String.Empty
        v_strNOTICE_ALPH = String.Empty
        v_strBOARD_LOT = String.Empty
        v_strFILLER_6 = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strSECURITY_NUMBER = String.Empty
        v_strFILLER_1 = String.Empty
        v_strSECTOR_NUMBER = String.Empty
        v_strFILLER_2 = String.Empty
        v_strHALT_RESUME_FLAG_ALPH = String.Empty
        v_strSYSTEM_CONTROL_CODE_ALPH = String.Empty
        v_strFILLER_3 = String.Empty
        v_strSUSPENSION_ALPH = String.Empty
        v_strDELIST_ALPH = String.Empty
        v_strFILLER_4 = String.Empty
        v_strCEILING = String.Empty
        v_strFLOOR_PRICE = String.Empty
        v_strSECURITY_TYPE_ALPH = String.Empty
        v_strPRIOR_CLOSE_PRICE = String.Empty
        v_strFILLER_5 = String.Empty
        v_strSPLIT_ALPH = String.Empty
        v_strBENEFIT_ALPH = String.Empty
        v_strMEETING_ALPH = String.Empty
        v_strNOTICE_ALPH = String.Empty
        v_strBOARD_LOT = String.Empty
        v_strFILLER_6 = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property FILLER_1() As String
        Get
            Return v_strFILLER_1
        End Get
        Set(ByVal Value As String)
            v_strFILLER_1 = Value
        End Set
    End Property
    Public Property SECTOR_NUMBER() As String
        Get
            Return v_strSECTOR_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECTOR_NUMBER = Value
        End Set
    End Property
    Public Property FILLER_2() As String
        Get
            Return v_strFILLER_2
        End Get
        Set(ByVal Value As String)
            v_strFILLER_2 = Value
        End Set
    End Property
    Public Property HALT_RESUME_FLAG_ALPH() As String
        Get
            Return v_strHALT_RESUME_FLAG_ALPH
        End Get
        Set(ByVal Value As String)
            v_strHALT_RESUME_FLAG_ALPH = Value
        End Set
    End Property
    Public Property SYSTEM_CONTROL_CODE_ALPH() As String
        Get
            Return v_strSYSTEM_CONTROL_CODE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSYSTEM_CONTROL_CODE_ALPH = Value
        End Set
    End Property
    Public Property FILLER_3() As String
        Get
            Return v_strFILLER_3
        End Get
        Set(ByVal Value As String)
            v_strFILLER_3 = Value
        End Set
    End Property
    Public Property SUSPENSION_ALPH() As String
        Get
            Return v_strSUSPENSION_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSUSPENSION_ALPH = Value
        End Set
    End Property
    Public Property DELIST_ALPH() As String
        Get
            Return v_strDELIST_ALPH
        End Get
        Set(ByVal Value As String)
            v_strDELIST_ALPH = Value
        End Set
    End Property
    Public Property FILLER_4() As String
        Get
            Return v_strFILLER_4
        End Get
        Set(ByVal Value As String)
            v_strFILLER_4 = Value
        End Set
    End Property
    Public Property CEILING() As String
        Get
            Return v_strCEILING
        End Get
        Set(ByVal Value As String)
            v_strCEILING = Value
        End Set
    End Property
    Public Property FLOOR_PRICE() As String
        Get
            Return v_strFLOOR_PRICE
        End Get
        Set(ByVal Value As String)
            v_strFLOOR_PRICE = Value
        End Set
    End Property
    Public Property SECURITY_TYPE_ALPH() As String
        Get
            Return v_strSECURITY_TYPE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_TYPE_ALPH = Value
        End Set
    End Property
    Public Property PRIOR_CLOSE_PRICE() As String
        Get
            Return v_strPRIOR_CLOSE_PRICE
        End Get
        Set(ByVal Value As String)
            v_strPRIOR_CLOSE_PRICE = Value
        End Set
    End Property
    Public Property FILLER_5() As String
        Get
            Return v_strFILLER_5
        End Get
        Set(ByVal Value As String)
            v_strFILLER_5 = Value
        End Set
    End Property
    Public Property SPLIT_ALPH() As String
        Get
            Return v_strSPLIT_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSPLIT_ALPH = Value
        End Set
    End Property
    Public Property BENEFIT_ALPH() As String
        Get
            Return v_strBENEFIT_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBENEFIT_ALPH = Value
        End Set
    End Property
    Public Property MEETING_ALPH() As String
        Get
            Return v_strMEETING_ALPH
        End Get
        Set(ByVal Value As String)
            v_strMEETING_ALPH = Value
        End Set
    End Property
    Public Property NOTICE_ALPH() As String
        Get
            Return v_strNOTICE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strNOTICE_ALPH = Value
        End Set
    End Property
    Public Property BOARD_LOT() As String
        Get
            Return v_strBOARD_LOT
        End Get
        Set(ByVal Value As String)
            v_strBOARD_LOT = Value
        End Set
    End Property
    Public Property FILLER_6() As String
        Get
            Return v_strFILLER_6
        End Get
        Set(ByVal Value As String)
            v_strFILLER_6 = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class

Public Class PRS_SU
#Region " Declaration "
    Dim v_strSECURITY_NUMBER_OLD As String
    Dim v_strSECURITY_NUMBER_NEW As String
    Dim v_strFILLER_1 As String
    Dim v_strSECTOR_NUMBER As String
    Dim v_strFILLER_2 As String
    Dim v_strSECURITY_SYMBOL_ALPH As String
    Dim v_strSECURITY_TYPE_ALPH As String
    Dim v_strCEILING_PRICE As String
    Dim v_strFLOOR_PRICE As String
    Dim v_strLAST_SALE_PRICE As String
    Dim v_strMARKET_ID_ALPH As String
    Dim v_strFILLER_3 As String
    Dim v_strSECURITY_NAME_ALPH As String
    Dim v_strFILLER_4 As String
    Dim v_strSUSPENSION_ALPH As String
    Dim v_strDELIST_ALPH As String
    Dim v_strHALT_RESUME_FLAG_ALPH As String
    Dim v_strSPLIT_ALPH As String
    Dim v_strBENEFIT_ALPH As String
    Dim v_strMEETING_ALPH As String
    Dim v_strNOTICE_ALPH As String
    Dim v_strCLIENT_ID_REQUIRED_ALPH As String
    Dim v_strPAR_VALUE As String
    Dim v_strSDC_FLAG_ALPH As String
    Dim v_strPRIOR_CLOSE_PRICE As String
    Dim v_strPRIOR_CLOSE_DATE As String
    Dim v_strOPEN_PRICE As String
    Dim v_strHIGHEST_PRICE As String
    Dim v_strLOWEST_PRICE As String
    Dim v_strTOTAL_SHARES_TRADED As String
    Dim v_strTOTAL_VALUES_TRADED As String
    Dim v_strBOARD_LOT As String
    Dim v_strFILLER_5 As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSECURITY_NUMBER_OLD = String.Empty
        v_strSECURITY_NUMBER_NEW = String.Empty
        v_strFILLER_1 = String.Empty
        v_strSECTOR_NUMBER = String.Empty
        v_strFILLER_2 = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSECURITY_TYPE_ALPH = String.Empty
        v_strCEILING_PRICE = String.Empty
        v_strFLOOR_PRICE = String.Empty
        v_strLAST_SALE_PRICE = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strFILLER_3 = String.Empty
        v_strSECURITY_NAME_ALPH = String.Empty
        v_strFILLER_4 = String.Empty
        v_strSUSPENSION_ALPH = String.Empty
        v_strDELIST_ALPH = String.Empty
        v_strHALT_RESUME_FLAG_ALPH = String.Empty
        v_strSPLIT_ALPH = String.Empty
        v_strBENEFIT_ALPH = String.Empty
        v_strMEETING_ALPH = String.Empty
        v_strNOTICE_ALPH = String.Empty
        v_strCLIENT_ID_REQUIRED_ALPH = String.Empty
        v_strPAR_VALUE = String.Empty
        v_strSDC_FLAG_ALPH = String.Empty
        v_strPRIOR_CLOSE_PRICE = String.Empty
        v_strPRIOR_CLOSE_DATE = String.Empty
        v_strOPEN_PRICE = String.Empty
        v_strHIGHEST_PRICE = String.Empty
        v_strLOWEST_PRICE = String.Empty
        v_strTOTAL_SHARES_TRADED = String.Empty
        v_strTOTAL_VALUES_TRADED = String.Empty
        v_strBOARD_LOT = String.Empty
        v_strFILLER_5 = String.Empty
        


    End Sub
    Public Overloads Sub Dispose()
        v_strSECURITY_NUMBER_OLD = String.Empty
        v_strSECURITY_NUMBER_NEW = String.Empty
        v_strFILLER_1 = String.Empty
        v_strSECTOR_NUMBER = String.Empty
        v_strFILLER_2 = String.Empty
        v_strSECURITY_SYMBOL_ALPH = String.Empty
        v_strSECURITY_TYPE_ALPH = String.Empty
        v_strCEILING_PRICE = String.Empty
        v_strFLOOR_PRICE = String.Empty
        v_strLAST_SALE_PRICE = String.Empty
        v_strMARKET_ID_ALPH = String.Empty
        v_strFILLER_3 = String.Empty
        v_strSECURITY_NAME_ALPH = String.Empty
        v_strFILLER_4 = String.Empty
        v_strSUSPENSION_ALPH = String.Empty
        v_strDELIST_ALPH = String.Empty
        v_strHALT_RESUME_FLAG_ALPH = String.Empty
        v_strSPLIT_ALPH = String.Empty
        v_strBENEFIT_ALPH = String.Empty
        v_strMEETING_ALPH = String.Empty
        v_strNOTICE_ALPH = String.Empty
        v_strCLIENT_ID_REQUIRED_ALPH = String.Empty
        v_strPAR_VALUE = String.Empty
        v_strSDC_FLAG_ALPH = String.Empty
        v_strPRIOR_CLOSE_PRICE = String.Empty
        v_strPRIOR_CLOSE_DATE = String.Empty
        v_strOPEN_PRICE = String.Empty
        v_strHIGHEST_PRICE = String.Empty
        v_strLOWEST_PRICE = String.Empty
        v_strTOTAL_SHARES_TRADED = String.Empty
        v_strTOTAL_VALUES_TRADED = String.Empty
        v_strBOARD_LOT = String.Empty
        v_strFILLER_5 = String.Empty
        


    End Sub
#End Region
#Region " Properties "
    Public Property SECURITY_NUMBER_OLD() As String
        Get
            Return v_strSECURITY_NUMBER_OLD
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER_OLD = Value
        End Set
    End Property
    Public Property SECURITY_NUMBER_NEW() As String
        Get
            Return v_strSECURITY_NUMBER_NEW
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER_NEW = Value
        End Set
    End Property
    Public Property FILLER_1() As String
        Get
            Return v_strFILLER_1
        End Get
        Set(ByVal Value As String)
            v_strFILLER_1 = Value
        End Set
    End Property
    Public Property SECTOR_NUMBER() As String
        Get
            Return v_strSECTOR_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECTOR_NUMBER = Value
        End Set
    End Property
    Public Property FILLER_2() As String
        Get
            Return v_strFILLER_2
        End Get
        Set(ByVal Value As String)
            v_strFILLER_2 = Value
        End Set
    End Property
    Public Property SECURITY_SYMBOL_ALPH() As String
        Get
            Return v_strSECURITY_SYMBOL_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_SYMBOL_ALPH = Value
        End Set
    End Property
    Public Property SECURITY_TYPE_ALPH() As String
        Get
            Return v_strSECURITY_TYPE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_TYPE_ALPH = Value
        End Set
    End Property
    Public Property CEILING_PRICE() As String
        Get
            Return v_strCEILING_PRICE
        End Get
        Set(ByVal Value As String)
            v_strCEILING_PRICE = Value
        End Set
    End Property
    Public Property FLOOR_PRICE() As String
        Get
            Return v_strFLOOR_PRICE
        End Get
        Set(ByVal Value As String)
            v_strFLOOR_PRICE = Value
        End Set
    End Property
    Public Property LAST_SALE_PRICE() As String
        Get
            Return v_strLAST_SALE_PRICE
        End Get
        Set(ByVal Value As String)
            v_strLAST_SALE_PRICE = Value
        End Set
    End Property
    Public Property MARKET_ID_ALPH() As String
        Get
            Return v_strMARKET_ID_ALPH
        End Get
        Set(ByVal Value As String)
            v_strMARKET_ID_ALPH = Value
        End Set
    End Property
    Public Property FILLER_3() As String
        Get
            Return v_strFILLER_3
        End Get
        Set(ByVal Value As String)
            v_strFILLER_3 = Value
        End Set
    End Property
    Public Property SECURITY_NAME_ALPH() As String
        Get
            Return v_strSECURITY_NAME_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NAME_ALPH = Value
        End Set
    End Property
    Public Property FILLER_4() As String
        Get
            Return v_strFILLER_4
        End Get
        Set(ByVal Value As String)
            v_strFILLER_4 = Value
        End Set
    End Property
    Public Property SUSPENSION_ALPH() As String
        Get
            Return v_strSUSPENSION_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSUSPENSION_ALPH = Value
        End Set
    End Property
    Public Property DELIST_ALPH() As String
        Get
            Return v_strDELIST_ALPH
        End Get
        Set(ByVal Value As String)
            v_strDELIST_ALPH = Value
        End Set
    End Property
    Public Property HALT_RESUME_FLAG_ALPH() As String
        Get
            Return v_strHALT_RESUME_FLAG_ALPH
        End Get
        Set(ByVal Value As String)
            v_strHALT_RESUME_FLAG_ALPH = Value
        End Set
    End Property
    Public Property SPLIT_ALPH() As String
        Get
            Return v_strSPLIT_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSPLIT_ALPH = Value
        End Set
    End Property
    Public Property BENEFIT_ALPH() As String
        Get
            Return v_strBENEFIT_ALPH
        End Get
        Set(ByVal Value As String)
            v_strBENEFIT_ALPH = Value
        End Set
    End Property
    Public Property MEETING_ALPH() As String
        Get
            Return v_strMEETING_ALPH
        End Get
        Set(ByVal Value As String)
            v_strMEETING_ALPH = Value
        End Set
    End Property
    Public Property NOTICE_ALPH() As String
        Get
            Return v_strNOTICE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strNOTICE_ALPH = Value
        End Set
    End Property
    Public Property CLIENT_ID_REQUIRED_ALPH() As String
        Get
            Return v_strCLIENT_ID_REQUIRED_ALPH
        End Get
        Set(ByVal Value As String)
            v_strCLIENT_ID_REQUIRED_ALPH = Value
        End Set
    End Property
    Public Property PAR_VALUE() As String
        Get
            Return v_strPAR_VALUE
        End Get
        Set(ByVal Value As String)
            v_strPAR_VALUE = Value
        End Set
    End Property
    Public Property SDC_FLAG_ALPH() As String
        Get
            Return v_strSDC_FLAG_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSDC_FLAG_ALPH = Value
        End Set
    End Property
    Public Property PRIOR_CLOSE_PRICE() As String
        Get
            Return v_strPRIOR_CLOSE_PRICE
        End Get
        Set(ByVal Value As String)
            v_strPRIOR_CLOSE_PRICE = Value
        End Set
    End Property
    Public Property PRIOR_CLOSE_DATE() As String
        Get
            Return v_strPRIOR_CLOSE_DATE
        End Get
        Set(ByVal Value As String)
            v_strPRIOR_CLOSE_DATE = Value
        End Set
    End Property
    Public Property OPEN_PRICE() As String
        Get
            Return v_strOPEN_PRICE
        End Get
        Set(ByVal Value As String)
            v_strOPEN_PRICE = Value
        End Set
    End Property
    Public Property HIGHEST_PRICE() As String
        Get
            Return v_strHIGHEST_PRICE
        End Get
        Set(ByVal Value As String)
            v_strHIGHEST_PRICE = Value
        End Set
    End Property
    Public Property LOWEST_PRICE() As String
        Get
            Return v_strLOWEST_PRICE
        End Get
        Set(ByVal Value As String)
            v_strLOWEST_PRICE = Value
        End Set
    End Property
    Public Property TOTAL_SHARES_TRADED() As String
        Get
            Return v_strTOTAL_SHARES_TRADED
        End Get
        Set(ByVal Value As String)
            v_strTOTAL_SHARES_TRADED = Value
        End Set
    End Property
    Public Property TOTAL_VALUES_TRADED() As String
        Get
            Return v_strTOTAL_VALUES_TRADED
        End Get
        Set(ByVal Value As String)
            v_strTOTAL_VALUES_TRADED = Value
        End Set
    End Property
    Public Property BOARD_LOT() As String
        Get
            Return v_strBOARD_LOT
        End Get
        Set(ByVal Value As String)
            v_strBOARD_LOT = Value
        End Set
    End Property
    Public Property FILLER_5() As String
        Get
            Return v_strFILLER_5
        End Get
        Set(ByVal Value As String)
            v_strFILLER_5 = Value
        End Set
    End Property
    

#End Region
#Region " Private message "
#End Region
End Class

Public Class PRS_TC
#Region " Declaration "
    Dim v_strFIRM As String
    Dim v_strTRADER_ID As String
    Dim v_strTRADER_STATUS_ALPH As String

#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strFIRM = String.Empty
        v_strTRADER_ID = String.Empty
        v_strTRADER_STATUS_ALPH = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strFIRM = String.Empty
        v_strTRADER_ID = String.Empty
        v_strTRADER_STATUS_ALPH = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property FIRM() As String
        Get
            Return v_strFIRM
        End Get
        Set(ByVal Value As String)
            v_strFIRM = Value
        End Set
    End Property
    Public Property TRADER_ID() As String
        Get
            Return v_strTRADER_ID
        End Get
        Set(ByVal Value As String)
            v_strTRADER_ID = Value
        End Set
    End Property
    Public Property TRADER_STATUS_ALPH() As String
        Get
            Return v_strTRADER_STATUS_ALPH
        End Get
        Set(ByVal Value As String)
            v_strTRADER_STATUS_ALPH = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region

End Class

Public Class PRS_TP
#Region " Declaration "
    Dim v_strSECURITY_NUMBER As String
    Dim v_strSIDE_ALPH As String
    Dim v_strPRICE_1_BEST As String
    Dim v_strLOT_VOLUME_1 As String
    Dim v_strPRICE_2_BEST As String
    Dim v_strLOT_VOLUME_2 As String
    Dim v_strPRICE_3_BEST As String
    Dim v_strLOT_VOLUME_3 As String



#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSECURITY_NUMBER = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strPRICE_1_BEST = String.Empty
        v_strLOT_VOLUME_1 = String.Empty
        v_strPRICE_2_BEST = String.Empty
        v_strLOT_VOLUME_2 = String.Empty
        v_strPRICE_3_BEST = String.Empty
        v_strLOT_VOLUME_3 = String.Empty

    End Sub
    Public Overloads Sub Dispose()
        v_strSECURITY_NUMBER = String.Empty
        v_strSIDE_ALPH = String.Empty
        v_strPRICE_1_BEST = String.Empty
        v_strLOT_VOLUME_1 = String.Empty
        v_strPRICE_2_BEST = String.Empty
        v_strLOT_VOLUME_2 = String.Empty
        v_strPRICE_3_BEST = String.Empty
        v_strLOT_VOLUME_3 = String.Empty

    End Sub
#End Region
#Region " Properties "
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property SIDE_ALPH() As String
        Get
            Return v_strSIDE_ALPH
        End Get
        Set(ByVal Value As String)
            v_strSIDE_ALPH = Value
        End Set
    End Property
    Public Property PRICE_1_BEST() As String
        Get
            Return v_strPRICE_1_BEST
        End Get
        Set(ByVal Value As String)
            v_strPRICE_1_BEST = Value
        End Set
    End Property
    Public Property LOT_VOLUME_1() As String
        Get
            Return v_strLOT_VOLUME_1
        End Get
        Set(ByVal Value As String)
            v_strLOT_VOLUME_1 = Value
        End Set
    End Property
    Public Property PRICE_2_BEST() As String
        Get
            Return v_strPRICE_2_BEST
        End Get
        Set(ByVal Value As String)
            v_strPRICE_2_BEST = Value
        End Set
    End Property
    Public Property LOT_VOLUME_2() As String
        Get
            Return v_strLOT_VOLUME_2
        End Get
        Set(ByVal Value As String)
            v_strLOT_VOLUME_2 = Value
        End Set
    End Property
    Public Property PRICE_3_BEST() As String
        Get
            Return v_strPRICE_3_BEST
        End Get
        Set(ByVal Value As String)
            v_strPRICE_3_BEST = Value
        End Set
    End Property
    Public Property LOT_VOLUME_3() As String
        Get
            Return v_strLOT_VOLUME_3
        End Get
        Set(ByVal Value As String)
            v_strLOT_VOLUME_3 = Value
        End Set
    End Property

#End Region
#Region " Private message "
#End Region
End Class


Public Class PRS_TR
#Region " Declaration "
    Dim v_strSECURITY_NUMBER As String
    Dim v_strTOTAL_ROOM As String
    Dim v_strCURRENT_ROOM As String


#End Region
#Region " Constructors and deconstructors "
    Public Sub New()
        v_strSECURITY_NUMBER = String.Empty
        v_strTOTAL_ROOM = String.Empty
        v_strCURRENT_ROOM = String.Empty


    End Sub
    Public Overloads Sub Dispose()
        v_strSECURITY_NUMBER = String.Empty
        v_strTOTAL_ROOM = String.Empty
        v_strCURRENT_ROOM = String.Empty


    End Sub
#End Region
#Region " Properties "
    Public Property SECURITY_NUMBER() As String
        Get
            Return v_strSECURITY_NUMBER
        End Get
        Set(ByVal Value As String)
            v_strSECURITY_NUMBER = Value
        End Set
    End Property
    Public Property TOTAL_ROOM() As String
        Get
            Return v_strTOTAL_ROOM
        End Get
        Set(ByVal Value As String)
            v_strTOTAL_ROOM = Value
        End Set
    End Property
    Public Property CURRENT_ROOM() As String
        Get
            Return v_strCURRENT_ROOM
        End Get
        Set(ByVal Value As String)
            v_strCURRENT_ROOM = Value
        End Set
    End Property


#End Region
#Region " Private message "
#End Region

End Class

'-------------------------------------------------------------------
'------------------------End of PRS Class -------------------------
'-------------------------------------------------------------------
