Public Class PessoaDAO



    Const DIR As String = "C:\Users\samuel.santos\Desktop\Samuel\Projetos\bd.txt"

    Public Function getAll() As List(Of Pessoa)
        Dim pessoas As ArrayList = New ArrayList

        Dim fluxoTexto As System.IO.StreamReader
        Dim linhaTexto As String

        If IO.File.Exists(DIR) Then
            fluxoTexto = New IO.StreamReader(DIR)

            linhaTexto = fluxoTexto.ReadLine

            While linhaTexto <> Nothing

                Dim palavras As String() = linhaTexto.Split(",")

                Dim novo As New Pessoa()

                novo.Codigo = CInt(palavras(0))
                novo.Nome = palavras(1)
                novo.Cpf = palavras(2)
                novo.Uf = palavras(3)
                novo.DataNas = Nothing

                pessoas.Add(novo)

                linhaTexto = fluxoTexto.ReadLine()
            End While
            fluxoTexto.Close()

            Return pessoas.Cast(Of Pessoa).ToList()
        Else
            Return Nothing
        End If
    End Function

    Public Function getId(ByRef id As Integer) As Pessoa
        Dim list = New List(Of Pessoa)

        list = Me.getAll()

        For Each element As Pessoa In list
            If element.Codigo = id Then
                Return element
            End If
        Next
        Return Nothing
    End Function


    Public Function getUf(ByRef uf As String) As List(Of Pessoa)
        Dim list = New List(Of Pessoa)

        list = Me.getAll()
        Dim lista = New ArrayList

        For Each element As Pessoa In list
            If element.Uf = uf Then
                lista.Add(element)
            End If

        Next
        Return lista.Cast(Of Pessoa).ToList()
    End Function

    Public Sub add(ByRef pessoa As Pessoa)

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(DIR, True)
        file.WriteLine(pessoa.Codigo & "," & pessoa.Nome & "," & pessoa.Cpf & "," & pessoa.Uf & "," & pessoa.DataNas)
        file.Close()

    End Sub

    Public Sub update(ByRef pessoa As Pessoa)
        Dim list = New List(Of Pessoa)

        list = Me.getAll()

        For Each element As Pessoa In list
            If element.Codigo = pessoa.Codigo Then
                element.Codigo = pessoa.Codigo
                element.Nome = pessoa.Nome
                element.Cpf = pessoa.Cpf
                element.Uf = pessoa.Uf
                element.DataNas = pessoa.DataNas

                Exit For
            End If
        Next
        escrever(list)
    End Sub

    Public Sub delete(ByRef id As Integer)
        Dim list = New List(Of Pessoa)

        list = Me.getAll()

        Dim lista = New ArrayList

        For Each element As Pessoa In list
            If Not element.Codigo = id Then
                lista.Add(element)
            End If

        Next

        escrever(lista.Cast(Of Pessoa).ToList())

    End Sub
    Private Sub escrever(ByRef lista As List(Of Pessoa))
        IO.File.WriteAllText(DIR, "")
        For Each element As Pessoa In lista
            Me.add(element)
        Next
    End Sub

    Public Function verifica(ByVal id As Integer) As Boolean
        Dim list = New List(Of Pessoa)

        list = Me.getAll()

        Dim lista = New ArrayList

        For Each element As Pessoa In list
            If element.Codigo = id Then
                Return True
            End If
        Next
        Return False
    End Function






End Class
