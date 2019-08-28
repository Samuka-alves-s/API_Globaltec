
Imports System.Web.Http

Namespace Controllers
    
    Public Class Pessoas1Controller
        Inherits ApiController
        Dim dao = New PessoaDAO()
        ' GET: api/Pessoas1
        <Authorize>
        Public Function GetValues() As IHttpActionResult
            Return Ok(dao.getAll)
        End Function

        ' GET: api/Pessoas1/5
        <Authorize>
        Public Function GetValue(ByVal id As Integer) As IHttpActionResult
            If id = 0 Then
                Return BadRequest("O valor do parâmetro não pode ser zero (0)")
            End If
            Return Ok(dao.getId(id))
        End Function

        ' GET: api/Pessoas1/uf
        <Authorize>
        Public Function GetValueUf(ByVal Uf As String) As IHttpActionResult
            Return Ok(dao.getUf(Uf))
        End Function

        ' POST: api/Pessoas1
        <Authorize>
        Public Function PostValue(<FromBody()> ByVal value As Pessoa) As IHttpActionResult

            If (value.Codigo = 0 Or IsNothing(value.Cpf) Or IsNothing(value.Nome) Or IsNothing(value.Uf)) Then
                Return BadRequest("Os campos (Código, CPF, UF e NOME) são Obrigatórios!")
            End If

            Try
                Ok(dao.add(value))
            Catch ex As Exception
            End Try

            Return Ok(value)

        End Function

        ' PUT: api/Pessoas1/5
        <Authorize>
        Public Function PutValue(<FromBody()> ByVal value As Pessoa) As IHttpActionResult
            If (value.Codigo = 0 Or IsNothing(value.Cpf) Or IsNothing(value.Nome) Or IsNothing(value.Uf)) Then
                Return BadRequest("Os campos (Código, CPF, UF e NOME) são Obrigatórios!")
            End If
            Try
                If dao.verifica(value.Codigo) Then
                    Ok(dao.update(value))
                Else
                    Return BadRequest("Dados não encontrados!")
                End If
            Catch ex As Exception

            End Try

            Return Ok(value)

        End Function

        ' DELETE: api/Pessoas1/5
        <Authorize>
        Public Function DeleteValue(ByVal id As Integer) As IHttpActionResult
            Try
                If dao.verifica(id) Then
                    Ok(dao.delete(id))
                Else
                    Return BadRequest("Dados não encontrados!")
                End If
            Catch ex As Exception
            End Try
            Return Ok(True)
        End Function
    End Class
End Namespace