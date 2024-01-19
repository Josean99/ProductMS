using DTOs.RequestDTOs;
using FluentValidation;

namespace DTOs.Validators
{
    public class BrandRequestDTOValidator : AbstractValidator<BrandRequestDTO>
    {
        public BrandRequestDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("BrandDTO name cannot be empty.")
                .MaximumLength(100).WithMessage("BrandDTO name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("BrandDTO description cannot be empty.")
                .MaximumLength(1000).WithMessage("BrandDTO description cannot exceed 1000 characters.");

            RuleFor(x => x.IdImage)
                .NotEmpty().WithMessage("BrandDTO image ID cannot be empty.");
        }
    }
}
