using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using EntityService.Model;
using Infrastructure.WebApiServices.Results;
using IReadBusinessLayer.Base;

namespace IWriteBusinessLayer
{
    public interface IBrandsWriteService
    {
        Task<Result<BrandRequestDTO>> Create(BrandRequestDTO dto);
        Task<Result<BrandRequestDTO>> Update(BrandRequestDTO dto);
        Task<Result<BrandRequestDTO>> SoftDelete(Guid id);
        Task<Result<Guid>> Delete(Guid id);
    }
}