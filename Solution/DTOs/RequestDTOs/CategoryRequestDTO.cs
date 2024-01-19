using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.RequestDTOs
{
    public class CategoryRequestDTO
    {
        public Guid? Id { get; set; } = null;

        public string Name { get; set; } = "";

        public string Icon { get; set; } = "";

        public Guid IdImage { get; set; }

        public Guid? IdFatherCategory { get; set; } = null;

        public DateTime? FechaBaja { get; set; } = null;
    }

}