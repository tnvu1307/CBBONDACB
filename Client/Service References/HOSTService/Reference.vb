﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace HOSTService
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="HOSTService.IHOSTService")>  _
    Public Interface IHOSTService
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/DoWork", ReplyAction:="http://tempuri.org/IHOSTService/DoWorkResponse")>  _
        Function DoWork(ByVal request As HOSTService.DoWorkRequest) As HOSTService.DoWorkResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/DoWork", ReplyAction:="http://tempuri.org/IHOSTService/DoWorkResponse")>  _
        Function DoWorkAsync(ByVal request As HOSTService.DoWorkRequest) As System.Threading.Tasks.Task(Of HOSTService.DoWorkResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/MessageByte", ReplyAction:="http://tempuri.org/IHOSTService/MessageByteResponse")>  _
        Function MessageByte(ByVal request As HOSTService.MessageByteRequest) As HOSTService.MessageByteResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/MessageByte", ReplyAction:="http://tempuri.org/IHOSTService/MessageByteResponse")>  _
        Function MessageByteAsync(ByVal request As HOSTService.MessageByteRequest) As System.Threading.Tasks.Task(Of HOSTService.MessageByteResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/GetVersion", ReplyAction:="http://tempuri.org/IHOSTService/GetVersionResponse")>  _
        Function GetVersion(ByVal request As HOSTService.GetVersionRequest) As HOSTService.GetVersionResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/GetVersion", ReplyAction:="http://tempuri.org/IHOSTService/GetVersionResponse")>  _
        Function GetVersionAsync(ByVal request As HOSTService.GetVersionRequest) As System.Threading.Tasks.Task(Of HOSTService.GetVersionResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/MessageString", ReplyAction:="http://tempuri.org/IHOSTService/MessageStringResponse")>  _
        Function MessageString(ByVal request As HOSTService.MessageStringRequest) As HOSTService.MessageStringResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/MessageString", ReplyAction:="http://tempuri.org/IHOSTService/MessageStringResponse")>  _
        Function MessageStringAsync(ByVal request As HOSTService.MessageStringRequest) As System.Threading.Tasks.Task(Of HOSTService.MessageStringResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/OMessageByte", ReplyAction:="http://tempuri.org/IHOSTService/OMessageByteResponse"),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(Object()))>  _
        Function OMessageByte(ByVal request As HOSTService.OMessageByteRequest) As HOSTService.OMessageByteResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/OMessageByte", ReplyAction:="http://tempuri.org/IHOSTService/OMessageByteResponse")>  _
        Function OMessageByteAsync(ByVal request As HOSTService.OMessageByteRequest) As System.Threading.Tasks.Task(Of HOSTService.OMessageByteResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/OMessageString", ReplyAction:="http://tempuri.org/IHOSTService/OMessageStringResponse"),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(Object()))>  _
        Function OMessageString(ByVal request As HOSTService.OMessageStringRequest) As HOSTService.OMessageStringResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/OMessageString", ReplyAction:="http://tempuri.org/IHOSTService/OMessageStringResponse")>  _
        Function OMessageStringAsync(ByVal request As HOSTService.OMessageStringRequest) As System.Threading.Tasks.Task(Of HOSTService.OMessageStringResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/GetFlagSignature", ReplyAction:="http://tempuri.org/IHOSTService/GetFlagSignatureResponse")>  _
        Function GetFlagSignature(ByVal request As HOSTService.GetFlagSignatureRequest) As HOSTService.GetFlagSignatureResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/GetFlagSignature", ReplyAction:="http://tempuri.org/IHOSTService/GetFlagSignatureResponse")>  _
        Function GetFlagSignatureAsync(ByVal request As HOSTService.GetFlagSignatureRequest) As System.Threading.Tasks.Task(Of HOSTService.GetFlagSignatureResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/GetTicketAccount", ReplyAction:="http://tempuri.org/IHOSTService/GetTicketAccountResponse")>  _
        Function GetTicketAccount(ByVal request As HOSTService.GetTicketAccountRequest) As HOSTService.GetTicketAccountResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/GetTicketAccount", ReplyAction:="http://tempuri.org/IHOSTService/GetTicketAccountResponse")>  _
        Function GetTicketAccountAsync(ByVal request As HOSTService.GetTicketAccountRequest) As System.Threading.Tasks.Task(Of HOSTService.GetTicketAccountResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/GetInfoAuthorMicrosoft", ReplyAction:="http://tempuri.org/IHOSTService/GetInfoAuthorMicrosoftResponse")>  _
        Function GetInfoAuthorMicrosoft(ByVal request As HOSTService.GetInfoAuthorMicrosoftRequest) As HOSTService.GetInfoAuthorMicrosoftResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTService/GetInfoAuthorMicrosoft", ReplyAction:="http://tempuri.org/IHOSTService/GetInfoAuthorMicrosoftResponse")>  _
        Function GetInfoAuthorMicrosoftAsync(ByVal request As HOSTService.GetInfoAuthorMicrosoftRequest) As System.Threading.Tasks.Task(Of HOSTService.GetInfoAuthorMicrosoftResponse)
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="DoWork", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class DoWorkRequest
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="DoWorkResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class DoWorkResponse
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="MessageByte", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class MessageByteRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="MessageByteResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class MessageByteResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public MessageByteResult As Long
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=1)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal MessageByteResult As Long, ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.MessageByteResult = MessageByteResult
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetVersion", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetVersionRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetVersionResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetVersionResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public GetVersionResult As Long
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=1)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetVersionResult As Long, ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.GetVersionResult = GetVersionResult
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="MessageString", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class MessageStringRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_strMessage As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_strMessage As String)
            MyBase.New
            Me.pv_strMessage = pv_strMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="MessageStringResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class MessageStringResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public MessageStringResult As Long
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=1)>  _
        Public pv_strMessage As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal MessageStringResult As Long, ByVal pv_strMessage As String)
            MyBase.New
            Me.MessageStringResult = MessageStringResult
            Me.pv_strMessage = pv_strMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="OMessageByte", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class OMessageByteRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="OMessageByteResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class OMessageByteResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public OMessageByteResult() As Object
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal OMessageByteResult() As Object)
            MyBase.New
            Me.OMessageByteResult = OMessageByteResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="OMessageString", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class OMessageStringRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_strMessage As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_strMessage As String)
            MyBase.New
            Me.pv_strMessage = pv_strMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="OMessageStringResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class OMessageStringResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public OMessageStringResult() As Object
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal OMessageStringResult() As Object)
            MyBase.New
            Me.OMessageStringResult = OMessageStringResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetFlagSignature", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetFlagSignatureRequest
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetFlagSignatureResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetFlagSignatureResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public GetFlagSignatureResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetFlagSignatureResult As String)
            MyBase.New
            Me.GetFlagSignatureResult = GetFlagSignatureResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetTicketAccount", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetTicketAccountRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetTicketAccountResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetTicketAccountResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public GetTicketAccountResult As Long
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=1)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetTicketAccountResult As Long, ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.GetTicketAccountResult = GetTicketAccountResult
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetInfoAuthorMicrosoft", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetInfoAuthorMicrosoftRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetInfoAuthorMicrosoftResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetInfoAuthorMicrosoftResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public GetInfoAuthorMicrosoftResult As Long
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=1)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetInfoAuthorMicrosoftResult As Long, ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.GetInfoAuthorMicrosoftResult = GetInfoAuthorMicrosoftResult
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IHOSTServiceChannel
        Inherits HOSTService.IHOSTService, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class HOSTServiceClient
        Inherits System.ServiceModel.ClientBase(Of HOSTService.IHOSTService)
        Implements HOSTService.IHOSTService
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function DoWork(ByVal request As HOSTService.DoWorkRequest) As HOSTService.DoWorkResponse Implements HOSTService.IHOSTService.DoWork
            Return MyBase.Channel.DoWork(request)
        End Function
        
        Public Function DoWorkAsync(ByVal request As HOSTService.DoWorkRequest) As System.Threading.Tasks.Task(Of HOSTService.DoWorkResponse) Implements HOSTService.IHOSTService.DoWorkAsync
            Return MyBase.Channel.DoWorkAsync(request)
        End Function
        
        Public Function MessageByte(ByVal request As HOSTService.MessageByteRequest) As HOSTService.MessageByteResponse Implements HOSTService.IHOSTService.MessageByte
            Return MyBase.Channel.MessageByte(request)
        End Function
        
        Public Function MessageByteAsync(ByVal request As HOSTService.MessageByteRequest) As System.Threading.Tasks.Task(Of HOSTService.MessageByteResponse) Implements HOSTService.IHOSTService.MessageByteAsync
            Return MyBase.Channel.MessageByteAsync(request)
        End Function
        
        Public Function GetVersion(ByVal request As HOSTService.GetVersionRequest) As HOSTService.GetVersionResponse Implements HOSTService.IHOSTService.GetVersion
            Return MyBase.Channel.GetVersion(request)
        End Function
        
        Public Function GetVersionAsync(ByVal request As HOSTService.GetVersionRequest) As System.Threading.Tasks.Task(Of HOSTService.GetVersionResponse) Implements HOSTService.IHOSTService.GetVersionAsync
            Return MyBase.Channel.GetVersionAsync(request)
        End Function
        
        Public Function MessageString(ByVal request As HOSTService.MessageStringRequest) As HOSTService.MessageStringResponse Implements HOSTService.IHOSTService.MessageString
            Return MyBase.Channel.MessageString(request)
        End Function
        
        Public Function MessageStringAsync(ByVal request As HOSTService.MessageStringRequest) As System.Threading.Tasks.Task(Of HOSTService.MessageStringResponse) Implements HOSTService.IHOSTService.MessageStringAsync
            Return MyBase.Channel.MessageStringAsync(request)
        End Function
        
        Public Function OMessageByte(ByVal request As HOSTService.OMessageByteRequest) As HOSTService.OMessageByteResponse Implements HOSTService.IHOSTService.OMessageByte
            Return MyBase.Channel.OMessageByte(request)
        End Function
        
        Public Function OMessageByteAsync(ByVal request As HOSTService.OMessageByteRequest) As System.Threading.Tasks.Task(Of HOSTService.OMessageByteResponse) Implements HOSTService.IHOSTService.OMessageByteAsync
            Return MyBase.Channel.OMessageByteAsync(request)
        End Function
        
        Public Function OMessageString(ByVal request As HOSTService.OMessageStringRequest) As HOSTService.OMessageStringResponse Implements HOSTService.IHOSTService.OMessageString
            Return MyBase.Channel.OMessageString(request)
        End Function
        
        Public Function OMessageStringAsync(ByVal request As HOSTService.OMessageStringRequest) As System.Threading.Tasks.Task(Of HOSTService.OMessageStringResponse) Implements HOSTService.IHOSTService.OMessageStringAsync
            Return MyBase.Channel.OMessageStringAsync(request)
        End Function
        
        Public Function GetFlagSignature(ByVal request As HOSTService.GetFlagSignatureRequest) As HOSTService.GetFlagSignatureResponse Implements HOSTService.IHOSTService.GetFlagSignature
            Return MyBase.Channel.GetFlagSignature(request)
        End Function
        
        Public Function GetFlagSignatureAsync(ByVal request As HOSTService.GetFlagSignatureRequest) As System.Threading.Tasks.Task(Of HOSTService.GetFlagSignatureResponse) Implements HOSTService.IHOSTService.GetFlagSignatureAsync
            Return MyBase.Channel.GetFlagSignatureAsync(request)
        End Function
        
        Public Function GetTicketAccount(ByVal request As HOSTService.GetTicketAccountRequest) As HOSTService.GetTicketAccountResponse Implements HOSTService.IHOSTService.GetTicketAccount
            Return MyBase.Channel.GetTicketAccount(request)
        End Function
        
        Public Function GetTicketAccountAsync(ByVal request As HOSTService.GetTicketAccountRequest) As System.Threading.Tasks.Task(Of HOSTService.GetTicketAccountResponse) Implements HOSTService.IHOSTService.GetTicketAccountAsync
            Return MyBase.Channel.GetTicketAccountAsync(request)
        End Function
        
        Public Function GetInfoAuthorMicrosoft(ByVal request As HOSTService.GetInfoAuthorMicrosoftRequest) As HOSTService.GetInfoAuthorMicrosoftResponse Implements HOSTService.IHOSTService.GetInfoAuthorMicrosoft
            Return MyBase.Channel.GetInfoAuthorMicrosoft(request)
        End Function
        
        Public Function GetInfoAuthorMicrosoftAsync(ByVal request As HOSTService.GetInfoAuthorMicrosoftRequest) As System.Threading.Tasks.Task(Of HOSTService.GetInfoAuthorMicrosoftResponse) Implements HOSTService.IHOSTService.GetInfoAuthorMicrosoftAsync
            Return MyBase.Channel.GetInfoAuthorMicrosoftAsync(request)
        End Function
    End Class
End Namespace
