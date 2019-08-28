Imports Microsoft.Owin
Imports Microsoft.Owin.Cors
Imports Microsoft.Owin.Security.OAuth
Imports Owin
Imports System.Web.Http


<Assembly: OwinStartup(GetType(FuncionariosAPIService.Startup))>
Namespace FuncionariosAPIService
    Public Class Startup
        Public Sub Configuration(ByVal app As IAppBuilder)
            Dim config = New HttpConfiguration()
            config.MapHttpAttributeRoutes()
            config.Routes.MapHttpRoute(name:="DefaultApi", routeTemplate:="api/{controller}/{action}/{id}", defaults:=New With {Key .id = RouteParameter.[Optional]
            })
            app.UseCors(CorsOptions.AllowAll)
            AtivarGeracaoTokenAcesso(app)
            app.UseWebApi(config)
        End Sub
        Private Sub AtivarGeracaoTokenAcesso(ByVal app As IAppBuilder)
            Dim opcoesConfiguracaoToken = New OAuthAuthorizationServerOptions() With {
                .AllowInsecureHttp = True,
                .TokenEndpointPath = New PathString("/token"),
                .AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                .Provider = New ProviderDeTokensDeAcesso()
            }
            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken)
            app.UseOAuthBearerAuthentication(New OAuthBearerAuthenticationOptions())
        End Sub
    End Class
End Namespace
