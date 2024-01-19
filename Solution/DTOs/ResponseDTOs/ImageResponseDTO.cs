using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.ResponseDTOs
{
    public class ImageResponseDTO
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = "";
        public string AlternativeText { get; set; } = "";
        public DateTime? FechaBaja { get; set; }
    }
}