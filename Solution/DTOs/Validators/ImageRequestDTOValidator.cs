using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using FluentValidation;

namespace EntityService.Validators
{
    public class ImageRequestDTOValidator : AbstractValidator<ImageRequestDTO>
    {
        public ImageRequestDTOValidator()
        {
            RuleFor(x => x.Path)
                .NotEmpty().WithMessage("Path is required.");

            RuleFor(x => x.AlternativeText)
                .NotEmpty().WithMessage("Alternative text is required.")
                .MaximumLength(100).WithMessage("Alternative text must not exceed 100 characters.");
        }
    }
}
