using APIStandarts.Core.Data;
using APIStandarts.Infrastructure.EF.Repositories;
using APIStandarts.Persistance.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace APIStandarts.ServiceRegistrations
{
  public static class DataModule
  {
    public static IServiceCollection RegisterDataServices(this IServiceCollection services, WebApplicationBuilder webApplicationBuilder)
    {

      services.AddScoped<IUnitOfWork<ArticleDbContext>, ArticleDbContextUnitOfWork>();

      services.AddDbContext<ArticleDbContext>(opt =>
      {
        opt.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("ArticleConn"));
      });

      return services;
    }
  }
}
