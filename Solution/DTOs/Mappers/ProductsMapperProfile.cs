using AutoMapper;
using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers
{
    public class ProductsMapperProfile : Profile
    {
        public ProductsMapperProfile()
        {
            CreateMap<ProductResponseDTO, Product>().ReverseMap();

            CreateMap<ProductRequestDTO, Product>().ReverseMap();

            CreateMap<ProductWithImagesRequestDTO, Product>().ReverseMap();
        }
    }
}
