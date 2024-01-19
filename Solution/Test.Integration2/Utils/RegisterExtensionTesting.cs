using AutoMapper;
using DBContext;
using DTOs.Mappers;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductsWriteAPI.Controllers;

namespace Test.Integration.Utils
{
    internal class RegisterExtensionTesting
    {
        public static IServiceProvider BuildDependencies()
        {
            IServiceCollection services = new ServiceCollection();

            //BBDD
            services.AddDbContext<ProductsAPIContext>(options =>
                options.UseNpgsql("Server=localhost;Port=6432;Database=TestDB; User Id=test;password=test" ?? throw new InvalidOperationException("Connection string 'DataContext' not found."))
                );

            //Services and Validators
            services
                .RegisterValidators()
                .RegisterRepositories()
                .RegisterServices();

            //Mapper
            services
                .AddTransient<IMapper, Mapper>()
                .AddTransient(provider => new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(typeof(BrandsMapperProfile));
                }).CreateMapper());

            //MemoryCache
            services.AddMemoryCache();

            services
                .AddTransient<BrandsController>()
                .AddTransient<CategoriesController>()
                .AddTransient<ImagesController>()
                .AddTransient<ProductsController>()
                .AddTransient<TextsController>();

            return services.BuildServiceProvider();
        }
    }
}
