using APIStandarts.Domain.Repositories;
using APIStandarts.Infrastructure.EF.Repositories;

namespace APIStandarts.ServiceRegistrations
{
  public static class DomainModule
  {

    public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
    {
      services.AddScoped<IArticleRepository, EFArticleRepository>();

      return services;
    }

  }
}
