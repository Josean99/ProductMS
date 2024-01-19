using EntityService.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityService.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Brand name cannot be empty.")
                .MaximumLength(100).WithMessage("Brand name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Brand description cannot be empty.")
                .MaximumLength(1000).WithMessage("Brand description cannot exceed 1000 characters.");

            RuleFor(x => x.IdImage)
                .NotEmpty().WithMessage("Brand image ID cannot be empty.");
        }
    }
}
