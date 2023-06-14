using APIStandarts.Application.Features.Articles.Create;
using APIStandarts.Application.Features.Articles.Update;
using APIStandarts.DIServices;
using APIStandarts.Domain.Repositories;
using APIStandarts.Infrastructure.Contracts;
using APIStandarts.Infrastructure.EF.Repositories;
using APIStandarts.Persistance.EF.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<TransientService>();
// Validations, Sessions, AspNet Action Filter Handlers ,Factory Class Transient, 

builder.Services.AddScoped<ScopeService>();
// Request Driven iþlemler, API to API,  Data Ýþlemleri, IO iþlemleri Scoped (UnManagement Resources)

builder.Services.AddSingleton<SingletonService>();

builder.Services.AddDbContext<ArticleDbContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("ArticleConn"));
});

builder.Services.AddScoped<IUnitOfWork<ArticleDbContext>, ArticleDbContextUnitOfWork>();
builder.Services.AddScoped<IArticleRepository, EFArticleRepository>();

//builder.Services.AddScoped<ArticleCreateService>();
//builder.Services.AddScoped<ArticleUpdateService>();
// Redis Singleton, Logger Service ELK Serilog Singleton, Elastic Search


// MediaTR service registeration iþlemliyapýyoruz
// Reflection ile Program dosyasýnýn bulunduðu dizindeki tüm mediator servislerini register.
builder.Services.AddMediatR(config =>
{
  config.RegisterServicesFromAssemblyContaining<Program>();
});



var app = builder.Build(); // buradan sonraki kýsým middleware

// DI iþlemlerini hep yukarýda tanýmlayalým.
//builder.Services.AddControllers();

// ortam deðiþkenleri ve configuration interface app baðlanmýþ oldu.
// app.Configuration Config instance
// app.Environment environment instance

// Configure the HTTP request pipeline.
if (app.Environment.IsStaging() || app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();  //    app.UseRouting(); kýsmýný yerine MapControllers geldi.

/*
 * 
 *  app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

 ortadan kalktý
 * 
 */

app.Run();
