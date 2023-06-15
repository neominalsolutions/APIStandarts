using APIStandarts.Application.Services;
using APIStandarts.Core.Api.Middewares;

namespace APIStandarts.ServiceRegistrations
{
  public static class ApplicationModule
  {
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {

      //builder.Services.AddScoped<ArticleCreateService>();
      //builder.Services.AddScoped<ArticleUpdateService>();
      // Redis Singleton, Logger Service ELK Serilog Singleton, Elastic Search


      // MediaTR service registeration işlemliyapıyoruz
      // Reflection ile Program dosyasının bulunduğu dizindeki tüm mediator servislerini register.


      services.AddMediatR(config =>
      {
        config.RegisterServicesFromAssemblyContaining<Program>();
      });

      return services;
    }
  }



}
