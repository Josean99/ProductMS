using DBContext;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.Logging;
using Infrastructure.Exceptions;
using DTOs.Mappers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//REGISTER DBCONTEXT
builder.Services.AddDbContext<ProductMSWriteAPIContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataContext") ?? throw new InvalidOperationException("Connection string 'DataContext' not found."))
    );

//REGISTER EXCEPTION POLICIES
builder.Services.RegisterExceptionPolicies();

// REGISTER VALIDATORS, REPOSITORIES AND SERVICES.
builder.Services.RegisterValidators().RegisterRepositories().RegisterServices();

//REGISTER LOGGING
builder.Logging.RegisterLogging(builder.Configuration);

//Automapper
builder.Services.AddAutoMapper(typeof(BrandsMapperProfile));

//Memory Cache
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.RegisterSwagger();

//builder.Services.RegisterAuthorization();

//var authority = builder.Configuration.GetSection("Authority:ServerURL").Value;
//var audience = builder.Configuration.GetSection("Authority:ClientId").Value;
//builder.Services.RegisterAuthentication(authority,audience);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Configura la URL de inicio de sesión personalizada
        //c.OAuthAdditionalQueryStringParams(new Dictionary<string, string>
        //{
        //    { "redirect_uri", "http://localhost:5000/Login" } // Reemplaza con tu URL de inicio de sesión
        //});
    });
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
