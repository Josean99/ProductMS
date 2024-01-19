using DTOs.ResponseDTOs;
using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReadBusinessLayer
{
    public interface IBrandsReadService
    {
        Task<BrandResponseDTO> Get(Guid id);
        Task<List<BrandResponseDTO>> GetAll();
        Task<BrandResponseDTO> GetIncluded(Guid id);
        Task<List<BrandResponseDTO>> GetAllIncluded();
    }
}
