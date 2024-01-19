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
    public class TextsMapperProfile : Profile
    {
        public TextsMapperProfile()
        {
            CreateMap<TextResponseDTO, Text>().ReverseMap();
            CreateMap<TextRequestDTO, Text>().ReverseMap();
        }
    }
}
