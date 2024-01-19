using DTOs.ResponseDTOs;
using EntityService.Model;

namespace IReadBusinessLayer
{
    public interface IImagesReadService
    {
        Task<ImageResponseDTO> Get(Guid id);
        Task<List<ImageResponseDTO>> GetAll();
    }
}