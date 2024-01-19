using AutoMapper;
using DTOs.ResponseDTOs;
using EntityService.Model;
using IReadBusinessLayer;
using IReadRepositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ReadBusinessLayer
{
    public class TextsReadService : ITextsReadService
    {
        private readonly IBaseReadRepository _baseRepository;
        private readonly IMapper _mapper;

        public TextsReadService(IBaseReadRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<TextResponseDTO> Get(Guid id)
        {            
            var result = await _baseRepository.GetFirstByCondition<Text>(t => t.Id == id);
            var resultDTO = _mapper.Map<Text, TextResponseDTO>(result);
            return resultDTO;
        }

        public async Task<List<TextResponseDTO>> GetAll()
        {
            var result = await _baseRepository.GetAll<Text>();
            var resultDTO = _mapper.Map<List<Text>, List<TextResponseDTO>>(result.ToList());
            return resultDTO;
        }

    }
}