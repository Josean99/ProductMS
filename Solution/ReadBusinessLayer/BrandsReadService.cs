using AutoMapper;
using DTOs.ResponseDTOs;
using EntityService.Model;
using IReadBusinessLayer;
using IReadRepositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ReadBusinessLayer
{
    public class BrandsReadService : IBrandsReadService
    {
        private readonly IBaseReadRepository _baseRepository;
        private readonly IMapper _mapper;

        public BrandsReadService(IBaseReadRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<BrandResponseDTO> Get(Guid id)
        {            
            var result = await _baseRepository.GetFirstByCondition<Brand>(t => t.Id == id);
            var resultDTO = _mapper.Map<Brand, BrandResponseDTO>(result);
            return resultDTO;
        }

        public async Task<List<BrandResponseDTO>> GetAll()
        {
            var result = await _baseRepository.GetAll<Brand>();
            var resultDTO = _mapper.Map<List<Brand>, List<BrandResponseDTO>>(result.ToList());
            return resultDTO;
        }

        public async Task<BrandResponseDTO> GetIncluded(Guid id)
        {
            var result = await _baseRepository.GetFirstByCondition<Brand>(b => b.Id == id, b => b.Image);
            var resultDTO = _mapper.Map<Brand, BrandResponseDTO>(result);
            return resultDTO;
        }

        public async Task<List<BrandResponseDTO>> GetAllIncluded()
        {
            var result = await _baseRepository.GetAll<Brand>(b => b.Image);
            var resultDTO = _mapper.Map<List<Brand>, List<BrandResponseDTO>>(result.ToList());
            return resultDTO;
        }

    }
}