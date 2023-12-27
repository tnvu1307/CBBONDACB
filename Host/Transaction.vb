Imports HostCommonLibrary
Imports CoreBusiness
Imports DataAccessLayer
'Imports System.EnterpriseServices

'TruongLD comment when convert
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.RequiresNew), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class Transaction
    'TruongLD comment when convert
    'Inherits ServicedComponent
    Inherits TxScope
    Public Function Transact(ByRef pv_xmlDocument As Xml.XmlDocument) As Long
        Dim v_obj As New txRouter
        Dim v_lngErr As Long
        v_lngErr = v_obj.Transact(pv_xmlDocument)
        Return v_lngErr
    End Function
End Class
