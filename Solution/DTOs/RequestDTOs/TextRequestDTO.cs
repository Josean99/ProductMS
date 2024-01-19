using EntityService.Model;
using System.ComponentModel.DataAnnotations;

namespace DTOs.RequestDTOs
{
    public class TextRequestDTO
    {
        public Guid? Id { get; set; } = null;

        public string Code { get; set; } = "";

        public string Value { get; set; } = "";

        public DateTime? FechaBaja { get; set; }
    }
}