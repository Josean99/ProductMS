using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using EntityService.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityService.Validators
{
    public class ProductImageRequestDTOValidator : AbstractValidator<ProductImageRequestDTO>
    {
        public ProductImageRequestDTOValidator()
        {
            RuleFor(x => x.Priority)
                .NotEmpty().WithMessage("Priority is required.");

            //RuleFor(x => x.IdProduct)
            //    .NotEmpty().WithMessage("Product ID is required.");

            //RuleFor(x => x.IdImage)
            //    .NotEmpty().WithMessage("Image ID is required.");
        }
    }
}
