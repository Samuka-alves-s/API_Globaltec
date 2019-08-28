Public Class Pessoa
    Dim codigoPessoa As Integer
    Dim nomePessoa As String
    Dim cpfPessoa As String
    Dim ufPessoa As String
    Dim dataNasPessoa As Date


    Public Sub New()
    End Sub
    Public Sub New(ByVal _codigoPessoa As Integer, ByVal _nomePessoa As String, ByVal _cpfPessoa As String, ByVal _ufPessoa As String, ByVal _dataNasPessoa As Date)
        Me.codigoPessoa = _codigoPessoa
        Me.nomePessoa = _nomePessoa
        Me.cpfPessoa = _cpfPessoa
        Me.ufPessoa = _ufPessoa
        Me.dataNasPessoa = _dataNasPessoa
    End Sub

    Public Property Codigo As Integer
        Get
            Return Me.codigoPessoa
        End Get
        Set(ByVal Value As Integer)
            Me.codigoPessoa = Value
        End Set
    End Property

    Public Property Nome As String
        Get
            Return Me.nomePessoa
        End Get
        Set(ByVal Value As String)
            Me.nomePessoa = Value
        End Set
    End Property

    Public Property Cpf As String
        Get
            Return Me.cpfPessoa
        End Get
        Set(ByVal Value As String)
            Me.cpfPessoa = Value
        End Set
    End Property

    Public Property Uf As String
        Get
            Return Me.ufPessoa
        End Get
        Set(ByVal Value As String)
            Me.ufPessoa = Value
        End Set
    End Property

    Public Property DataNas As Date
        Get
            Return Me.dataNasPessoa
        End Get
        Set(ByVal Value As Date)
            Me.dataNasPessoa = Value
        End Set
    End Property

End Class
