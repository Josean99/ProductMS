using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.RequestDTOs
{
    public class ProductRequestDTO
    {
        public Guid? Id { get; set; } = null;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Guid IdCategory { get; set; }
        public Guid IdBrand { get; set; }
        public DateTime? FechaBaja { get; set; }

    }
}