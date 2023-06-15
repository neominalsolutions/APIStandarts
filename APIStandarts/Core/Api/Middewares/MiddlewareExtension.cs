namespace APIStandarts.Core.Api.Middewares
{
  public static class MiddlewareExtension
  {
    public static IApplicationBuilder UseCustomException(this IApplicationBuilder applicationBuilder)
    {
      return applicationBuilder.UseMiddleware<ExceptionMiddleware>();
    }

    public static IApplicationBuilder UseClientCredentials(this IApplicationBuilder applicationBuilder)
    {
      return applicationBuilder.UseMiddleware<ClientCredentialsMiddleware>();
    }
  }
}
