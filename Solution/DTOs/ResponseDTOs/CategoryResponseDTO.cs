using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.ResponseDTOs
{
    public class CategoryResponseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public string Icon { get; set; } = "";

        public Guid IdImage { get; set; }

        public Guid? IdFatherCategory { get; set; } = null;

        public DateTime? FechaBaja { get; set; } = null;

        public Image Image { get; set; }
    }

}