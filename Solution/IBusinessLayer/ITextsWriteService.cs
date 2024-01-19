using DTOs.RequestDTOs;
using EntityService.Model;
using Infrastructure.WebApiServices.Results;

namespace IWriteBusinessLayer
{
    public interface ITextsWriteService
    {
        Task<Result<TextRequestDTO>> Create(TextRequestDTO dto);
        Task<Result<TextRequestDTO>> Update(TextRequestDTO dto);
        Task<Result<TextRequestDTO>> SoftDelete(Guid id);
        Task<Result<Guid>> Delete(Guid id);
    }
}