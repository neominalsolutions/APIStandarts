using APIStandarts.Application.Features.Articles.Create;
using APIStandarts.Application.Features.Articles.Update;
using APIStandarts.Application.Services;
using APIStandarts.Core.Api.Middewares;
using APIStandarts.Core.Data;
using APIStandarts.DIServices;
using APIStandarts.Domain.Repositories;
using APIStandarts.Infrastructure.EF.Repositories;
using APIStandarts.Persistance.EF.Contexts;
using APIStandarts.ServiceRegistrations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region APIServices

builder.Services.AddControllers().AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<Program>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region AppServices

builder.Services.RegisterDataServices(builder);
builder.Services.RegisterDomainServices();
builder.Services.RegisterApiServices();
builder.Services.RegisterApplicationServices();

#endregion


var app = builder.Build(); // buradan sonraki k�s�m middleware

// DI i�lemlerini hep yukar�da tan�mlayal�m.
//builder.Services.AddControllers();

// ortam de�i�kenleri ve configuration interface app ba�lanm�� oldu.
// app.Configuration Config instance
// app.Environment environment instance

// Configure the HTTP request pipeline.

#region Middlewares

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

app.UseCustomException();
app.UseClientCredentials();
app.Run();

#endregion


