using APIStandarts.Application.Services;
using APIStandarts.Core.Api.Middewares;
using APIStandarts.Core.JWT;
using APIStandarts.DIServices;
using APIStandarts.Domain.Repositories;
using APIStandarts.Infrastructure.EF.Repositories;
using APIStandarts.Infrastructure.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace APIStandarts.ServiceRegistrations
{
  public static class ApiModule
  {

    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {

      var key = Encoding.ASCII.GetBytes(JWTSettings.SecretKey);
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
                  .AddJwtBearer(x =>
                  {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true
                    };

                  });

      services.AddTransient<IJwtTokenService, JwtTokenService>();

      //var assemby = Assembly.GetExecutingAssembly();
      services.AddAutoMapper(typeof(Program));

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
