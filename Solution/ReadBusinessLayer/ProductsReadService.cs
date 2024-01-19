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
    public class ProductsReadService : IProductsReadService
    {
        private readonly IBaseReadRepository _baseRepository;
        private readonly IMapper _mapper;

        public ProductsReadService(IBaseReadRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponseDTO> Get(Guid id)
        {
            var result = await _baseRepository.GetFirstByCondition<Product>(t => t.Id == id);
            var resultDTO = _mapper.Map<Product, ProductResponseDTO>(result);
            return resultDTO;
        }

        public async Task<List<ProductResponseDTO>> GetAll()
        {
            var result = await _baseRepository.GetAll<Product>();
            var resultDTO = _mapper.Map<List<Product>, List<ProductResponseDTO>>(result.ToList());
            return resultDTO;
        }

        public async Task<ProductResponseDTO> GetIncluded(Guid id)
        {
            var result = await _baseRepository.GetFirstByCondition<Product>(b => b.Id == id, b => b.Brand, b=>b.Category, b=>b.ProductImages);
            var resultDTO = _mapper.Map<Product, ProductResponseDTO>(result);
            return resultDTO;
        }

        public async Task<List<ProductResponseDTO>> GetAllIncluded()
        {
            var result = await _baseRepository.GetAll<Product>(b => b.Brand, b => b.Category, b => b.ProductImages);
            var resultDTO = _mapper.Map<List<Product>, List<ProductResponseDTO>>(result.ToList());
            return resultDTO;
        }

    }
}