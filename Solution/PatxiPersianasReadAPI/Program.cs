using DBContext;
using DTOs.Mappers;
using Infrastructure;
using Infrastructure.Auth;
using Infrastructure.Exceptions;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//REGISTER DBCONTEXT
builder.Services.AddDbContext<ProductMSReadAPIContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataContext") ?? throw new InvalidOperationException("Connection string 'DataContext' not found."))
    );

//REGISTER EXCEPTION POLICIES
builder.Services.RegisterExceptionPolicies();

// REGISTER VALIDATORS, REPOSITORIES AND SERVICES.
builder.Services.RegisterValidators().RegisterRepositories().RegisterServices();

////REGISTER LOGGING
builder.Logging.RegisterLogging(builder.Configuration);

//Automapper
builder.Services.AddAutoMapper(typeof(BrandsMapperProfile));

//Memory Cache
builder.Services.AddMemoryCache();

builder.Services.AddControllers();

//var authority = builder.Configuration.GetSection("Authority:ClientId").Value;
builder.Services.RegisterAuthentication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwagger();

builder.Services.RegisterAuthorization();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
