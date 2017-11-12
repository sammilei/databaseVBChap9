Public Class Invoice
    Private m_InvoiceID As Integer
    Private m_VendorID As Integer
    Private m_InvoiceNumber As String
    Private m_InvoiceDate As Date
    Private m_InvoiceTotal As Decimal
    Private m_PaymentTotal As Decimal
    Private m_CreditTotal As Decimal
    Private m_TermsID As Integer
    Private m_DueDate As Date
    Private m_PaymentDate As Nullable(Of Date)

    Public Sub New()

    End Sub

    Public Property InvoiceID() As Integer
        Get
            Return m_InvoiceID
        End Get
        Set(ByVal value As Integer)
            m_InvoiceID = value
        End Set
    End Property

    Public Property VendorID() As Integer
        Get
            Return m_VendorID
        End Get
        Set(ByVal value As Integer)
            m_VendorID = value
        End Set
    End Property

    Public Property InvoiceNumber() As String
        Get
            Return m_InvoiceNumber
        End Get
        Set(ByVal value As String)
            m_InvoiceNumber = value
        End Set
    End Property

    Public Property InvoiceDate() As Date
        Get
            Return m_InvoiceDate
        End Get
        Set(ByVal value As Date)
            m_InvoiceDate = value
        End Set
    End Property

    Public Property InvoiceTotal() As Decimal
        Get
            Return m_InvoiceTotal
        End Get
        Set(ByVal value As Decimal)
            m_InvoiceTotal = value
        End Set
    End Property

    Public Property PaymentTotal() As Decimal
        Get
            Return m_PaymentTotal
        End Get
        Set(ByVal value As Decimal)
            m_PaymentTotal = value
        End Set
    End Property

    Public Property CreditTotal() As Decimal
        Get
            Return m_CreditTotal
        End Get
        Set(ByVal value As Decimal)
            m_CreditTotal = value
        End Set
    End Property

    Public Property TermsID() As Integer
        Get
            Return m_TermsID
        End Get
        Set(ByVal value As Integer)
            m_TermsID = value
        End Set
    End Property

    Public Property DueDate() As Date
        Get
            Return m_DueDate
        End Get
        Set(ByVal value As Date)
            m_DueDate = value
        End Set
    End Property

    Public Property PaymentDate() As Nullable(Of Date)
        Get
            If m_PaymentDate.HasValue Then
                Return CDate(m_PaymentDate)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As Nullable(Of Date))
            m_PaymentDate = value
        End Set
    End Property

    Public ReadOnly Property BalanceDue() As Decimal
        Get
            Return m_InvoiceTotal - m_PaymentTotal - m_CreditTotal
        End Get
    End Property

End Class
