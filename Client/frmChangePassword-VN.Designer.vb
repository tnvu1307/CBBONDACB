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

Imports System


'This class was auto-generated by the StronglyTypedResourceBuilder
'class via a tool like ResGen or Visual Studio.
'To add or remove a member, edit your .ResX file then rerun ResGen
'with the /str option, or rebuild your VS project.
'''<summary>
'''  A strongly-typed resource class, for looking up localized strings, etc.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
Friend Class frmChangePassword_VN
    
    Private Shared resourceMan As Global.System.Resources.ResourceManager
    
    Private Shared resourceCulture As Global.System.Globalization.CultureInfo
    
    <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
    Friend Sub New()
        MyBase.New
    End Sub
    
    '''<summary>
    '''  Returns the cached ResourceManager instance used by this class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
        Get
            If Object.ReferenceEquals(resourceMan, Nothing) Then
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager(gc_RootNamespace & "." & "frmChangePassword-VN", GetType(frmChangePassword_VN).Assembly)
                resourceMan = temp
            End If
            Return resourceMan
        End Get
    End Property
    
    '''<summary>
    '''  Overrides the current thread's CurrentUICulture property for all
    '''  resource lookups using this strongly typed resource class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
        Get
            Return resourceCulture
        End Get
        Set
            resourceCulture = value
        End Set
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thay đổi mật khẩu.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword() As String
        Get
            Return ResourceManager.GetString("frmChangePassword", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Hủy bỏ.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_btnCancel() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.btnCancel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Chấp nhận.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_btnOK() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.btnOK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thông tin thay đổi.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_grbInfo() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.grbInfo", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thay đổi mật khẩu của NSD: .
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_lblCaption() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.lblCaption", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Xác nhận MK mới:.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_lblCOFPASS() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.lblCOFPASS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mật khẩu cũ:.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_lblOLDPASS() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.lblOLDPASS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mật khẩu mới:.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_lblPASS() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.lblPASS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mật khẩu không được để rỗng!.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_PasswordEmptyMsg() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.PasswordEmptyMsg", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mật khẩu không khớp!.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_PasswordNotMatch() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.PasswordNotMatch", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thay đổi mật khẩu không thành công!.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_SavingFailed() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.SavingFailed", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thay đổi mật khẩu thành công!.
    '''</summary>
    Friend Shared ReadOnly Property frmChangePassword_SavingSuccess() As String
        Get
            Return ResourceManager.GetString("frmChangePassword.SavingSuccess", resourceCulture)
        End Get
    End Property
End Class
