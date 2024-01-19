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
    public class ImagesMapperProfile : Profile
    {
        public ImagesMapperProfile()
        {
            CreateMap<ImageResponseDTO, Image>().ReverseMap();
            CreateMap<ImageRequestDTO, Image>().ReverseMap();
        }
    }
}
