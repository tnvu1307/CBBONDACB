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
Friend Class frmApprove_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager(gc_RootNamespace & "." & "frmApprove-VN", GetType(frmApprove_VN).Assembly)
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
    '''  Looks up a localized string similar to Có lỗi khi duyệt dữ liệu!.
    '''</summary>
    Friend Shared ReadOnly Property ApprovalFailed() As String
        Get
            Return ResourceManager.GetString("ApprovalFailed", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Dữ liệu đã được duyệt thành công.
    '''</summary>
    Friend Shared ReadOnly Property ApproveSuccessful() As String
        Get
            Return ResourceManager.GetString("ApproveSuccessful", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã chi nhánh của tài khoản vàng và tài khoản tiền không khớp nhau!.
    '''</summary>
    Friend Shared ReadOnly Property BranchCodeErr() As String
        Get
            Return ResourceManager.GetString("BranchCodeErr", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Duyệt.
    '''</summary>
    Friend Shared ReadOnly Property btnApprove() As String
        Get
            Return ResourceManager.GetString("btnApprove", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thoát.
    '''</summary>
    Friend Shared ReadOnly Property btnCancel() As String
        Get
            Return ResourceManager.GetString("btnCancel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Từ chối.
    '''</summary>
    Friend Shared ReadOnly Property btnReject() As String
        Get
            Return ResourceManager.GetString("btnReject", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lịch sử thay đổi của dữ liệu:.
    '''</summary>
    Friend Shared ReadOnly Property Caption() As String
        Get
            Return ResourceManager.GetString("Caption", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Màn hình duyệt.
    '''</summary>
    Friend Shared ReadOnly Property formText() As String
        Get
            Return ResourceManager.GetString("formText", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Có lỗi khi map TK với ngân hàng!.
    '''</summary>
    Friend Shared ReadOnly Property GetBankAcctnoError() As String
        Get
            Return ResourceManager.GetString("GetBankAcctnoError", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Y/c duyệt.
    '''</summary>
    Friend Shared ReadOnly Property grid_APPROVE_RQD() As String
        Get
            Return ResourceManager.GetString("grid.APPROVE_RQD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thông tin sửa.
    '''</summary>
    Friend Shared ReadOnly Property grid_COLUMN_NAME() As String
        Get
            Return ResourceManager.GetString("grid.COLUMN_NAME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị cũ.
    '''</summary>
    Friend Shared ReadOnly Property grid_FROM_VALUE() As String
        Get
            Return ResourceManager.GetString("grid.FROM_VALUE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày sửa.
    '''</summary>
    Friend Shared ReadOnly Property grid_MAKER_DT() As String
        Get
            Return ResourceManager.GetString("grid.MAKER_DT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giờ sửa.
    '''</summary>
    Friend Shared ReadOnly Property grid_MAKER_TIME() As String
        Get
            Return ResourceManager.GetString("grid.MAKER_TIME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lần sửa.
    '''</summary>
    Friend Shared ReadOnly Property grid_MOD_NUM() As String
        Get
            Return ResourceManager.GetString("grid.MOD_NUM", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Người sửa.
    '''</summary>
    Friend Shared ReadOnly Property grid_TLNAME() As String
        Get
            Return ResourceManager.GetString("grid.TLNAME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị mới.
    '''</summary>
    Friend Shared ReadOnly Property grid_TO_VALUE() As String
        Get
            Return ResourceManager.GetString("grid.TO_VALUE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Duyệt không thành công! Không có thay đổi gì trên dữ liệu này..
    '''</summary>
    Friend Shared ReadOnly Property NothingToApprove() As String
        Get
            Return ResourceManager.GetString("NothingToApprove", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Từ chối không thành công! Không có thay đổi gì trên dữ liệu này..
    '''</summary>
    Friend Shared ReadOnly Property NothingToReject() As String
        Get
            Return ResourceManager.GetString("NothingToReject", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Dữ liệu đã được từ chối duyệt.
    '''</summary>
    Friend Shared ReadOnly Property RejectSuccessful() As String
        Get
            Return ResourceManager.GetString("RejectSuccessful", resourceCulture)
        End Get
    End Property
End Class
