using AutoMapper;
using DTOs.ResponseDTOs;
using EntityService.Model;
using IReadBusinessLayer;
using IReadBusinessLayer.Base;
using IReadRepositories;
using IReadRepositories.Base;
using Microsoft.EntityFrameworkCore;
using ReadRepositories.Base;

namespace ReadBusinessLayer
{
    public class ImagesReadService : IImagesReadService
    {
        private readonly IBaseReadRepository _baseRepository;
        private readonly IMapper _mapper;

        public ImagesReadService(IBaseReadRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ImageResponseDTO> Get(Guid id)
        {
            var result = await _baseRepository.GetFirstByCondition<Image>(t => t.Id == id);
            var resultDTO = _mapper.Map<Image, ImageResponseDTO>(result);
            return resultDTO;
        }

        public async Task<List<ImageResponseDTO>> GetAll()
        {
            var result = await _baseRepository.GetAll<Image>();
            var resultDTO = _mapper.Map<List<Image>, List<ImageResponseDTO>>(result.ToList());
            return resultDTO;
        }

    }
}