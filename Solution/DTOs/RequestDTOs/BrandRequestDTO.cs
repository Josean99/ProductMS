using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.RequestDTOs
{
    public class BrandRequestDTO
    {
        public Guid? Id { get; set; } = null;

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public Guid IdImage { get; set; }

        public DateTime? FechaBaja { get; set; }
    }
}