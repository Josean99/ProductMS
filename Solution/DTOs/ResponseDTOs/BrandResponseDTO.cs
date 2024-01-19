using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.ResponseDTOs
{
    public class BrandResponseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public Guid IdImage { get; set; }

        public DateTime? FechaBaja { get; set; }

        public ImageResponseDTO Image { get; set; }
    }
}