using DTOs.RequestDTOs;
using FluentValidation;

namespace EntityService.Validators
{
    public class CategoryRequestDTOValidator : AbstractValidator<CategoryRequestDTO>
    {
        public CategoryRequestDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon is required.");

            RuleFor(x => x.IdFatherCategory)
                .NotEmpty().WithMessage("Father category ID is required.");
        }
    }
}
