
using APIStandarts.Core.Api.Middewares;
using APIStandarts.ServiceRegistrations;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region APIServices

builder.Services.AddControllers().AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<Program>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(opt =>
{

  var securityScheme = new OpenApiSecurityScheme()
  {
    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT" // Optional
  };

  var securityRequirement = new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "bearerAuth"
            }
        },
        new string[] {}
    }
};

  opt.AddSecurityDefinition("bearerAuth", securityScheme);
  opt.AddSecurityRequirement(securityRequirement);
});


#endregion

#region AppServices

builder.Services.RegisterDataServices(builder);
builder.Services.RegisterDomainServices();
builder.Services.RegisterApiServices();
builder.Services.RegisterApplicationServices();

#endregion


var app = builder.Build(); // buradan sonraki kýsým middleware

// DI iþlemlerini hep yukarýda tanýmlayalým.
//builder.Services.AddControllers();

// ortam deðiþkenleri ve configuration interface app baðlanmýþ oldu.
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
app.UseAuthentication(); // bu middleware ekleriz.
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

app.UseCustomException();
//app.UseClientCredentials();
app.Run();

#endregion


