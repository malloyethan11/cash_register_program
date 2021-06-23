Public Class clsUser

    Private m_strUsername As String
    Private m_blnCheckout As Boolean
    Private m_blnReturns As Boolean
    Private m_blnAddItems As Boolean
    Private m_blnEditItems As Boolean
    Private m_blnDeleteItems As Boolean
    Private m_blnMassPricing As Boolean
    Private m_blnAddVendors As Boolean
    Private m_blnEditVendors As Boolean

    Public Property Username() As String
        Get
            Return m_strUsername
        End Get
        Set(ByVal value As String)
            m_strUsername = value
        End Set
    End Property

    Public Property CanCheckout() As Boolean
        Get
            Return m_blnCheckout
        End Get
        Set(ByVal value As Boolean)
            m_blnCheckout = value
        End Set
    End Property

    Public Property CanReturn() As Boolean
        Get
            Return m_blnReturns
        End Get
        Set(ByVal value As Boolean)
            m_blnReturns = value
        End Set
    End Property

    Public Property CanAddItems() As Boolean
        Get
            Return m_blnAddItems
        End Get
        Set(ByVal value As Boolean)
            m_blnAddItems = value
        End Set
    End Property

    Public Property CanEditItems() As Boolean
        Get
            Return m_blnEditItems
        End Get
        Set(ByVal value As Boolean)
            m_blnEditItems = value
        End Set
    End Property

    Public Property CanDeleteItems() As Boolean
        Get
            Return m_blnDeleteItems
        End Get
        Set(ByVal value As Boolean)
            m_blnDeleteItems = value
        End Set
    End Property

    Public Property CanAdjustPricing() As Boolean
        Get
            Return m_blnMassPricing
        End Get
        Set(ByVal value As Boolean)
            m_blnMassPricing = value
        End Set
    End Property

    Public Property CanAddVendors() As Boolean
        Get
            Return m_blnAddVendors
        End Get
        Set(ByVal value As Boolean)
            m_blnAddVendors = value
        End Set
    End Property

    Public Property CanEditVendors() As Boolean
        Get
            Return m_blnEditVendors
        End Get
        Set(ByVal value As Boolean)
            m_blnEditVendors = value
        End Set
    End Property

End Class
