using EntityService.Model;
using EntityService.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Exceptions.Policies;
using Infrastructure.Exceptions.Policies.Interfaces;
using IReadBusinessLayer;
using IReadRepositories;
using IReadRepositories.Base;
using IWriteBusinessLayer;
using IWriteRepository.Base;
using Microsoft.Extensions.DependencyInjection;
using ReadBusinessLayer;
using ReadRepositories;
using ReadRepositories.Base;
using WriteBusinessLayer;
using WriteRepository.Base;
using DBContext;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.Logging;
using Infrastructure.Exceptions;
using DTOs.Mappers;
//using Infrastructure.auth;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication;
using Infrastructure.Auth;
using ExternalServices.Interfaces;
using ExternalServices.Implementation;
using Infrastructure.auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class RegisterExtension
    {

        public static IServiceCollection RegisterExceptionPolicies(this IServiceCollection services)
        {
            services.AddSingleton<IExceptionPolicy, SanitizeNotCustomExceptionPolicy>();
            //services.AddScoped<IExceptionPolicy, DoNotSanitizeExceptionPolicy>();
            //services.AddScoped<IExceptionPolicy, SanitizeAllExceptionPolicy>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseWriteRepository<>), typeof(BaseWriteRepository<>));
            services.AddScoped<IBaseReadRepository, BaseReadRepository>();
            services.AddScoped<ICategoriesReadRepository, CategoriesReadRepository>();

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBrandsWriteService, BrandsWriteService>();
            services.AddScoped<ICategoriesWriteService, CategoriesWriteService>();
            services.AddScoped<IImagesWriteService, ImagesWriteService>();
            services.AddScoped<IProductsWriteService, ProductsWriteService>();
            services.AddScoped<ITextsWriteService, TextsWriteService>();

            services.AddScoped<IBrandsReadService, BrandsReadService>();
            services.AddScoped<ICategoriesReadService, CategoriesReadService>();
            services.AddScoped<IImagesReadService, ImagesReadService>();
            services.AddScoped<IProductsReadService, ProductsReadService>();
            services.AddScoped<ITextsReadService, TextsReadService>();

            services.AddScoped<IJwtService, JwtService>();

            return services;
        }

        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddScoped<IValidator<Brand>, BrandValidator>();
            services.AddScoped<IValidator<Category>, CategoryValidator>();
            services.AddScoped<IValidator<Image>, ImageValidator>();
            services.AddScoped<IValidator<Product>, ProductValidator>();
            services.AddScoped<IValidator<ProductImage>, ProductImageValidator>();
            services.AddScoped<IValidator<Text>, TextValidator>();

            return services;
        }

        public static IServiceCollection RegisterMappers(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddScoped<IValidator<Brand>, BrandValidator>();
            services.AddScoped<IValidator<Category>, CategoryValidator>();
            services.AddScoped<IValidator<Image>, ImageValidator>();
            services.AddScoped<IValidator<Product>, ProductValidator>();
            services.AddScoped<IValidator<ProductImage>, ProductImageValidator>();
            services.AddScoped<IValidator<Text>, TextValidator>();

            return services;
        }

        public static IServiceCollection RegisterAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.Requirements.Add(new AccessRequirement());
                });
                options.DefaultPolicy = options.GetPolicy("Admin");
            });

            services.AddScoped<IAuthorizationHandler, AccessHandler>();

            return services;
        }

        public static IServiceCollection RegisterAuthentication(this IServiceCollection services)
        {
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.SaveToken = true;
            //        options.TokenValidationParameters = new TokenValidationParameters()
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            //ValidAudience = builder.Configuration["Jwt:Audience"],
            //            //ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clientId))
            //        };
            //    });


            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddAuthentication("Bearer")
                .AddScheme<AuthenticationSchemeOptions, JwtAuthenticationHandler>("Bearer", null);

            return services;
        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new[] { "DemoSwaggerDifferentAuthScheme" }
                    }
                });

            });

            return services;
        }


    }
}
