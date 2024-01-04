Imports Microsoft.AspNetCore.Builder
Imports CoreWCF
Imports CoreWCF.Configuration
Imports CoreWCF.Description
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.AspNetCore.Hosting
Imports CoreWCF.Channels
Imports System.IO
Imports Microsoft.AspNetCore.Http
Imports Microsoft.Extensions.Logging
Imports System.Configuration

Public Class Program
    Public Shared Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        builder.Services.Configure(Of AppSettingsSection)(builder.Configuration.GetSection("AppSettings"))

        builder.Services.AddServiceModelServices()
        builder.Services.AddServiceModelMetadata()
        builder.Services.AddSingleton(Of IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior)()

        'builder.Services.AddSingleton(Of IHOAuthService, HOAuthService)()
        'builder.Services.AddSingleton(Of IHOSTService, HOSTService)()
        'builder.Services.AddSingleton(Of IHOSTRptService, IHOSTRptService)()

        'builder.Services.AddScoped(TypeOf (IRepository), TypeOf (Repository))

        builder.Logging.AddLog4Net()
        log4net.Config.XmlConfigurator.Configure(New FileInfo("log4net.config"))


        Dim app = builder.Build()

        app.UseServiceModel(Sub(ServiceBuilder)
                                ServiceBuilder.AddService(Of HOAuthService)()
                                ServiceBuilder.AddServiceEndpoint(Of HOAuthService, IHOAuthService)(New WSHttpBinding(BasicHttpSecurityMode.None), "/HOSTService/HOAuthService.svc")
                                ServiceBuilder.AddService(Of HOSTService)()
                                ServiceBuilder.AddServiceEndpoint(Of HOSTService, IHOSTService)(New WSHttpBinding(BasicHttpSecurityMode.None), "/HOSTService/HOSTService.svc")
                                ServiceBuilder.AddService(Of HOSTRptService)()
                                ServiceBuilder.AddServiceEndpoint(Of HOSTRptService, IHOSTRptService)(New WSHttpBinding(BasicHttpSecurityMode.None), "/HOSTService/HOSTRptService.svc")

                                Dim serviceMetadataBehavior = app.Services.GetRequiredService(Of ServiceMetadataBehavior)()
                                serviceMetadataBehavior.HttpGetEnabled = True
                                serviceMetadataBehavior.HttpsGetEnabled = False
                            End Sub)

        app.MapGet("/", Function() "Application running!")
        app.MapGet("/Deployment/Client/{filename}", Function(ByVal filename As String)
                                                        Try
                                                            Dim path As String = "./Deployment/Client/{0}"
                                                            Dim path_fileName As String = String.Format(path, filename)
                                                            Return Results.File(New FileStream(path_fileName, FileMode.Open, FileAccess.Read), "contentType: mimeType", filename)
                                                        Catch ex As Exception
                                                            Return "Could not find file " + filename
                                                        End Try
                                                    End Function)
        app.MapGet("/Deployment/Report/{filename}", Function(ByVal filename As String)
                                                        Try
                                                            Dim path As String = "./Deployment/Report/{0}"
                                                            Dim path_fileName As String = String.Format(path, filename)
                                                            Return Results.File(New FileStream(path_fileName, FileMode.Open, FileAccess.Read), "contentType: mimeType", filename)
                                                        Catch ex As Exception
                                                            Return "Could not find file " + filename
                                                        End Try

                                                    End Function)

        app.Run()
    End Sub

    'Private Shared Function GetCustomBinding(ByVal useHttps As Boolean) As Binding
    '    Dim bindingElements = New List(Of BindingElement)()
    '    Dim security = If(useHttps, SecurityMode.Transport, SecurityMode.None)
    '    Dim securityBindingElement = If(security = SecurityMode.Transport, CType(New TransportSecurityBindingElement(), BindingElement), New TransportSecurityBindingElement With {
    '        .CredentialType = HttpClientCredentialType.None
    '    })
    '    bindingElements.Add(securityBindingElement)
    '    Dim messageEncodingBindingElement = New TextMessageEncodingBindingElement With {
    '        .MessageVersion = MessageVersion.Soap12WSAddressing10
    '    }
    '    bindingElements.Add(messageEncodingBindingElement)
    '    Dim transportBindingElement = If(useHttps, CType(New HttpsTransportBindingElement(), BindingElement), New HttpTransportBindingElement())
    '    bindingElements.Add(transportBindingElement)
    '    Return New CustomBinding(bindingElements)
    'End Function
End Class
