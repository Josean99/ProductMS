using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.ResponseDTOs
{
    public class TextResponseDTO
    {
        public Guid Id { get; set; }

        public string Code { get; set; } = "";

        public string Value { get; set; } = "";

        public DateTime? FechaBaja { get; set; }
    }
}