using EntityService.Model;
using EntityService.Validators;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Unit.ValidatorTest.Entities
{
    public class ProductValidatorTest
    {
        private readonly ProductValidator _validator;

        public ProductValidatorTest()
        {
            _validator = new ProductValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenNameIsEmpty()
        {
            // Arrange
            var product = new Product { Name = string.Empty, Description = "Sample description", IdCategory = Guid.NewGuid(), IdBrand = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("Name is required.");
        }

        [Fact]
        public void ShouldFailValidationWhenDescriptionIsEmpty()
        {
            // Arrange
            var product = new Product { Name = "Sample name", Description = string.Empty, IdCategory = Guid.NewGuid(), IdBrand = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorMessage("Description is required.");
        }

        [Fact]
        public void ShouldPassValidationWhenProductIsValid()
        {
            // Arrange
            var product = new Product { Name = "Sample name", Description = "Sample description", IdCategory = Guid.NewGuid(), IdBrand = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
