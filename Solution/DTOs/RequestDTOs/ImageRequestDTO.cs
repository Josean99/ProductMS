using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.RequestDTOs
{
    public class ImageRequestDTO
    {
        public Guid? Id { get; set; } = null;
        public string Path { get; set; } = "";
        public string AlternativeText { get; set; } = "";
        public DateTime? FechaBaja { get; set; }
    }
}