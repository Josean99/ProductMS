using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.ResponseDTOs
{
    public class ProductImageResponseDTO
    {
        public Guid Id { get; set; }

        public int Priority { get; set; }

        public Guid IdProduct { get; set; }

        public Guid IdImage { get; set; }

        public DateTime? FechaBaja { get; set; }

        public virtual ProductResponseDTO Product { get; set; }
        public virtual ImageResponseDTO Image { get; set; }
    }
}