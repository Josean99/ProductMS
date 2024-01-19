using DTOs.ResponseDTOs;
using EntityService.Model;

namespace IReadBusinessLayer
{
    public interface IProductsReadService
    {
        Task<ProductResponseDTO> Get(Guid id);
        Task<List<ProductResponseDTO>> GetAll();
        Task<ProductResponseDTO> GetIncluded(Guid id);
        Task<List<ProductResponseDTO>> GetAllIncluded();
    }
}