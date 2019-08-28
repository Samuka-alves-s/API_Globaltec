Imports Microsoft.Owin.Security.OAuth
Imports System.Security.Claims
Imports System.Threading.Tasks

Namespace FuncionariosAPIService
    Public Class ProviderDeTokensDeAcesso
        Inherits OAuthAuthorizationServerProvider

        Public Overrides Async Function ValidateClientAuthentication(ByVal context As OAuthValidateClientAuthenticationContext) As Task
            context.Validated()
        End Function

        Public Overrides Async Function GrantResourceOwnerCredentials(ByVal context As OAuthGrantResourceOwnerCredentialsContext) As Task
            If context.UserName = "admin" And context.Password = "admin" Then
                Dim identity = New ClaimsIdentity(context.Options.AuthenticationType)
                identity.AddClaim(New Claim("sub", context.UserName))
                identity.AddClaim(New Claim("role", "user"))
                context.Validated(identity)
            Else
                context.SetError("acesso inválido", "As credenciais do usuário não conferem....")
                Return
            End If
        End Function
    End Class
End Namespace