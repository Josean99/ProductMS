using DTOs.ResponseDTOs;
using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReadBusinessLayer
{
    public interface ITextsReadService
    {
        Task<TextResponseDTO> Get(Guid id);
        Task<List<TextResponseDTO>> GetAll();
    }
}
