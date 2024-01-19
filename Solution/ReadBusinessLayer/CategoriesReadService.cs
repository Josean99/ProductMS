using AutoMapper;
using DTOs.ResponseDTOs;
using EntityService.Model;
using IReadBusinessLayer;
using IReadRepositories;
using IReadRepositories.Base;
using Microsoft.EntityFrameworkCore;
using ReadRepositories.Base;

namespace ReadBusinessLayer
{
    public class CategoriesReadService : ICategoriesReadService
    {
        private readonly IBaseReadRepository _baseRepository;
        private readonly ICategoriesReadRepository _categoriesReadRepository;
        private readonly IMapper _mapper;

        public CategoriesReadService(IBaseReadRepository baseRepository,ICategoriesReadRepository categoriesReadRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _categoriesReadRepository = categoriesReadRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDTO> Get(Guid id)
        {
            var result = await _baseRepository.GetFirstByCondition<Category>(t => t.Id == id);
            var resultDTO = _mapper.Map<Category, CategoryResponseDTO>(result);
            return resultDTO;
        }

        public async Task<List<CategoryResponseDTO>> GetAll()
        {
            var result = await _baseRepository.GetAll<Category>();
            var resultDTO = _mapper.Map<List<Category>, List<CategoryResponseDTO>>(result.ToList());
            return resultDTO;
        }

        public async Task<CategoryResponseDTO> GetIncluded(Guid id)
        {
            var result = await _baseRepository.GetFirstByCondition<Category>(b => b.Id == id, b => b.Image);
            var resultDTO = _mapper.Map<Category, CategoryResponseDTO>(result);
            return resultDTO;
        }

        public async Task<List<CategoryResponseDTO>> GetAllIncluded()
        {
            var result = await _baseRepository.GetAll<Category>(b => b.Image);
            var resultDTO = _mapper.Map<List<Category>, List<CategoryResponseDTO>>(result.ToList());
            return resultDTO;
        }

        public async Task<Dictionary<int, CategoryResponseDTO>> GetBreadCrumb(Guid id)
        {
            var result = await _categoriesReadRepository.GetBreadCrumb(id);
            var resultDTO = _mapper.Map<Dictionary<int, Category>, Dictionary<int, CategoryResponseDTO>>(result);
            return resultDTO;
        }

    }
}