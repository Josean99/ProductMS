using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.RequestDTOs
{
    public class ProductImageRequestDTO
    {
        public Guid? Id { get; set; } = null;

        public int Priority { get; set; }

        public Guid? IdProduct { get; set; }

        public Guid? IdImage { get; set; }

        public DateTime? FechaBaja { get; set; }

        public ImageRequestDTO? Image { get; set; } = null;
    }
}