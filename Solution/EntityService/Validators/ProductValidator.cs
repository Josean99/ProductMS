using EntityService.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityService.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
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
