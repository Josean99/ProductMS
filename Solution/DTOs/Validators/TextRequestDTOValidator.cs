using DTOs.RequestDTOs;
using FluentValidation;

namespace EntityService.Validators
{
    public class TextRequestDTOValidator : AbstractValidator<TextRequestDTO>
    {
        public TextRequestDTOValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.");

            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Text is required.");
        }
    }
}
