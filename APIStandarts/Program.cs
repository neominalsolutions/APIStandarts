using APIStandarts.Application.Features.Articles.Create;
using APIStandarts.Application.Features.Articles.Update;
using APIStandarts.DIServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<TransientService>();
// Validations, Sessions, AspNet Action Filter Handlers ,Factory Class Transient, 

builder.Services.AddScoped<ScopeService>();
// Request Driven i�lemler, API to API,  Data ��lemleri, IO i�lemleri Scoped (UnManagement Resources)

builder.Services.AddSingleton<SingletonService>();


//builder.Services.AddScoped<ArticleCreateService>();
//builder.Services.AddScoped<ArticleUpdateService>();
// Redis Singleton, Logger Service ELK Serilog Singleton, Elastic Search


// MediaTR service registeration i�lemliyap�yoruz
// Reflection ile Program dosyas�n�n bulundu�u dizindeki t�m mediator servislerini register.
builder.Services.AddMediatR(config =>
{
  config.RegisterServicesFromAssemblyContaining<Program>();
});



var app = builder.Build(); // buradan sonraki k�s�m middleware

// DI i�lemlerini hep yukar�da tan�mlayal�m.
//builder.Services.AddControllers();

// ortam de�i�kenleri ve configuration interface app ba�lanm�� oldu.
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

app.MapControllers();  //    app.UseRouting(); k�sm�n� yerine MapControllers geldi.

/*
 * 
 *  app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

 ortadan kalkt�
 * 
 */

app.Run();
