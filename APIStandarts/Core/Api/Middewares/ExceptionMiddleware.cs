using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace APIStandarts.Core.Api.Middewares
{

 

  public class ExceptionMiddleware : IMiddleware
  {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

      try
      {
        await next(context);
      }
      catch (Exception ex)
      {
        var errorResponse = new
        {
          Message = ex.Message,
          StatusCode = StatusCodes.Status500InternalServerError
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));


      }
    }
  }
}
