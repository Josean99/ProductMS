using DTOs.RequestDTOs;
using FluentValidation;

namespace EntityService.Validators
{
    public class ProductRequestDTOValidator : AbstractValidator<ProductRequestDTO>
    {
        public ProductRequestDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.IdCategory)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(x => x.IdBrand)
                .NotEmpty().WithMessage("Brand is required.");
        }
    }
}
