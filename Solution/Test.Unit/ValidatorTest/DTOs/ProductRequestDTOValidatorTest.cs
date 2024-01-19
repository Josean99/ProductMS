using DTOs;
using DTOs.RequestDTOs;
using EntityService.Validators;
using FluentValidation.TestHelper;

namespace Test.Unit.ValidatorTest.Entities
{
    public class ProductRequestDTOValidatorTests
    {
        private readonly ProductRequestDTOValidator _validator;

        public ProductRequestDTOValidatorTests()
        {
            _validator = new ProductRequestDTOValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenNameIsEmpty()
        {
            // Arrange
            var product = new ProductRequestDTO { Name = string.Empty, Description = "Sample description", IdCategory = Guid.NewGuid(), IdBrand = Guid.NewGuid() };

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
            var product = new ProductRequestDTO { Name = "Sample name", Description = string.Empty, IdCategory = Guid.NewGuid(), IdBrand = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorMessage("Description is required.");
        }

        [Fact]
        public void ShouldPassValidationWhenProductDTOIsValid()
        {
            // Arrange
            var product = new ProductRequestDTO { Name = "Sample name", Description = "Sample description", IdCategory = Guid.NewGuid(), IdBrand = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
