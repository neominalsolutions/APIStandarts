using APIStandarts.Application.Services;
using System.ComponentModel.DataAnnotations;

namespace APIStandarts.Core.Api.Middewares
{
  // 3.1 version Middlewares
  public class ClientCredentialsMiddleware2
  {
    private readonly RequestDelegate next;

    public ClientCredentialsMiddleware2(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, ClientCredentialCheckService clientCredentialCheckService)
    {
      await next(context);
    }
  }

  public class ClientCredentialsMiddleware : IMiddleware
  {
    private readonly ClientCredentialCheckService clientCredentialCheckService;

    public ClientCredentialsMiddleware(ClientCredentialCheckService clientCredentialCheckService)
    {
      this.clientCredentialCheckService = clientCredentialCheckService;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

      string clientId = context.Request.Headers["client_id"];
      var clientSecret = context.Request.Headers["client_secret"];

      if(string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
      {
        throw new Exception("ClientId veya ClientSecret headerda tanımlı değil");
      }
      else
      {
        if (!this.clientCredentialCheckService.CheckClientCredentials(clientId, clientSecret))
        {
          
          throw new Exception("ClientId veya ClientSecret değeri sistemde tanımlı değil");
       
        }
      }

      await next(context);

    }
  }
}
