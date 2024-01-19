using DTOs.ResponseDTOs;
using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReadBusinessLayer
{
    public interface ICategoriesReadService
    {
        Task<CategoryResponseDTO> Get(Guid id);
        Task<List<CategoryResponseDTO>> GetAll();
        Task<CategoryResponseDTO> GetIncluded(Guid id);
        Task<List<CategoryResponseDTO>> GetAllIncluded();
        Task<Dictionary<int, CategoryResponseDTO>> GetBreadCrumb(Guid id);
    }
}
