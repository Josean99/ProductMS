using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.RequestDTOs
{
    public record ProductWithImagesRequestDTO
    {
        public Guid? Id { get; set; } = null;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Guid IdCategory { get; set; }
        public Guid IdBrand { get; set; }
        public DateTime? FechaBaja { get; set; }

        public List<ProductImageRequestDTO> ProductImages { get; set; }
    }
}
