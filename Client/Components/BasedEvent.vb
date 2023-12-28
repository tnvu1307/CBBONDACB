Public Class objNotify
    Private mv_strObjName As String
    Public mv_objEvent As BasedEvent

    Public Sub New(ByVal v_strObjName As String)
        mv_strObjName = v_strObjName
    End Sub

    Public Property Name() As String
        Get
            Name = mv_strObjName
        End Get
        Set(ByVal Value As String)
            mv_strObjName = Value
        End Set
    End Property

    Public Event onChange()

    Public Sub SetData(ByVal v_objData As BasedEvent)
        mv_objEvent = v_objData
        RaiseEvent onChange()
    End Sub
End Class

Public Class BasedEvent
    Private mv_strObjName As String
    Private mv_strCacheNewOrChange As String

    Private mv_strListOfAttr As String
    Private mv_arrAData As New Hashtable    'Phần từ 0 bao giờ cũng là KEY. Đại diện cho một bản ghi dữ liệu
    'Khởi tạo đối tượng
    Public Sub New(ByVal pv_strObjName As String)
        mv_strObjName = pv_strObjName
    End Sub

    'Tên đối tượng
    Public ReadOnly Property OBJNAME() As String
        Get
            OBJNAME = mv_strObjName
        End Get
    End Property

    'Số lượng thuộc tính
    Public ReadOnly Property COUNT() As Integer
        Get
            COUNT = mv_arrAData.Count
        End Get
    End Property

    Public Property NewOrChange() As String
        Get
            NewOrChange = mv_strCacheNewOrChange
        End Get
        Set(ByVal Value As String)
            mv_strCacheNewOrChange = Value
        End Set
    End Property


    'Tạo danh sách các thuộc tính theo string truyền vào. Các trường được phân cách nhau bởi ký tự |
    'Ký tự đầu tiên bao giờ cũng là REFKEY
    'Ví dụ: SYMBOL|RFPRICE|CEPRICE|FLPRICE, AFACCTNO|AVLTRADE
    Public Sub FireObjectData(ByVal pv_strAttrNames As String, ByVal pv_strAttrValues As String)
        mv_arrAData.Clear()
        mv_strListOfAttr = pv_strAttrNames

        ' Split string based on | character
        Dim attrNames As String() = pv_strAttrNames.Split(New Char() {"|"c})
        Dim attrValues As String() = pv_strAttrValues.Split(New Char() {"|"c})

        ' Map to array of attribues
        Dim v_lngIdx, v_lngCount As Long
        v_lngCount = attrNames.Length
        If v_lngCount > 0 Then
            For v_lngIdx = 0 To v_lngCount - 1 Step 1
                mv_arrAData.Add(attrNames(v_lngIdx), attrValues(v_lngIdx))
            Next
        End If
    End Sub

    'Trả về giá trị của thuộc tính theo tên thuộc tính
    Public Function GetAttrValueByName(ByVal pv_strName As String) As String
        Try
            GetAttrValueByName = mv_arrAData(pv_strName)
        Catch ex As Exception
            GetAttrValueByName = String.Empty
        End Try
    End Function

    'Trả về giá trị của thuộc tính theo thứ tự thuộc tính
    Public Function GetAttrValueByIndex(ByVal pv_lngIdx As Long) As String
        Dim v_strName As String
        Try
            If COUNT > pv_lngIdx + 1 Then
                Dim attrNames As String() = mv_strListOfAttr.Split(New Char() {"|"c})
                v_strName = attrNames(pv_lngIdx)
                GetAttrValueByIndex = mv_arrAData(v_strName)
            Else
                GetAttrValueByIndex = String.Empty
            End If
        Catch ex As Exception
            GetAttrValueByIndex = String.Empty
        End Try
    End Function
End Class
