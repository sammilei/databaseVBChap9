Public Class Vendor
    Private m_VendorID As Integer
    Private m_Name As String
    Private m_Address1 As String
    Private m_Address2 As String
    Private m_City As String
    Private m_State As String
    Private m_ZipCode As String
    Private m_Phone As String
    Private m_ContactLName As String
    Private m_ContactFName As String
    Private m_DefaultTermsID As Integer
    Private m_DefaultAccountNo As Integer

    Public Sub New()

    End Sub

    Public Property VendorID() As Integer
        Get
            Return m_VendorID
        End Get
        Set(ByVal value As Integer)
            m_VendorID = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property

    Public Property Address1() As String
        Get
            Return m_Address1
        End Get
        Set(ByVal value As String)
            m_Address1 = value
        End Set
    End Property

    Public Property Address2() As String
        Get
            Return m_Address2
        End Get
        Set(ByVal value As String)
            m_Address2 = value
        End Set
    End Property

    Public Property City() As String
        Get
            Return m_City
        End Get
        Set(ByVal value As String)
            m_City = value
        End Set
    End Property

    Public Property State() As String
        Get
            Return m_State
        End Get
        Set(ByVal value As String)
            m_State = value
        End Set
    End Property

    Public Property ZipCode() As String
        Get
            Return m_ZipCode
        End Get
        Set(ByVal value As String)
            m_ZipCode = value
        End Set
    End Property

    Public Property Phone() As String
        Get
            Return m_Phone
        End Get
        Set(ByVal value As String)
            m_Phone = value
        End Set
    End Property

    Public Property ContactLName() As String
        Get
            Return m_ContactLName
        End Get
        Set(ByVal value As String)
            m_ContactLName = value
        End Set
    End Property

    Public Property ContactFName() As String
        Get
            Return m_ContactFName
        End Get
        Set(ByVal value As String)
            m_ContactFName = value
        End Set
    End Property

    Public Property DefaultTermsID() As Integer
        Get
            Return m_DefaultTermsID
        End Get
        Set(ByVal value As Integer)
            m_DefaultTermsID = value
        End Set
    End Property

    Public Property DefaultAccountNo() As Integer
        Get
            Return m_DefaultAccountNo
        End Get
        Set(ByVal value As Integer)
            m_DefaultAccountNo = value
        End Set
    End Property

End Class
