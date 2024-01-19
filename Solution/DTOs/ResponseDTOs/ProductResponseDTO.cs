using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.ResponseDTOs
{
    public class ProductResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Guid IdCategory { get; set; }
        public Guid IdBrand { get; set; }
        public DateTime? FechaBaja { get; set; }

        public List<ProductImageResponseDTO> ProductImages { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
    }
}