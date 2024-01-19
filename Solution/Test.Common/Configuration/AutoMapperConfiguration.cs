using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTOs.Mappers;

namespace Test.Common.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            var mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BrandsMapperProfile());
                mc.AddProfile(new CategoriesMapperProfile());
                mc.AddProfile(new ImagesMapperProfile());
                mc.AddProfile(new ProductsMapperProfile());
                mc.AddProfile(new ProductsImagesMapperProfile());
                mc.AddProfile(new TextsMapperProfile());
            });

            return mapperConfiguration;
        }
    }
}
