using APIStandarts.Application.Services;
using APIStandarts.Core.Api.Middewares;
using APIStandarts.DIServices;
using APIStandarts.Domain.Repositories;
using APIStandarts.Infrastructure.EF.Repositories;

namespace APIStandarts.ServiceRegistrations
{
  public static class ApiModule
  {

    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {

      services.AddTransient<TransientService>();
      // Validations, Sessions, AspNet Action Filter Handlers ,Factory Class Transient, 

      services.AddScoped<ScopeService>();
      // Request Driven işlemler, API to API,  Data İşlemleri, IO işlemleri Scoped (UnManagement Resources)

      services.AddSingleton<SingletonService>();

      services.AddTransient<ExceptionMiddleware>(); // Middlware yapılar request bazlı çalıştığı için transient olarak tercih edilir.
      services.AddTransient<ClientCredentialsMiddleware>();
      services.AddScoped<ClientCredentialCheckService>();

      return services;
    }
  }
}
