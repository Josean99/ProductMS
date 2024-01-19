using EntityService.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityService.Validators
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Path)
                .NotEmpty().WithMessage("Path is required.");

            RuleFor(x => x.AlternativeText)
                .NotEmpty().WithMessage("Alternative text is required.")
                .MaximumLength(100).WithMessage("Alternative text must not exceed 100 characters.");
        }
    }
}
