using DTOs;
using DTOs.RequestDTOs;
using EntityService.Validators;
using FluentValidation.TestHelper;

namespace Test.Unit.ValidatorTest.Entities
{
    public class ProductImageDTOValidatorTests
    {
        private readonly ProductImageRequestDTOValidator _validator;

        public ProductImageDTOValidatorTests()
        {
            _validator = new ProductImageRequestDTOValidator();
        }

        [Fact]
        public void ShouldPassValidationWhenProductImageDTOIsValid()
        {
            // Arrange
            var productImage = new ProductImageRequestDTO { Priority = 1, IdProduct = Guid.NewGuid(), IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(productImage);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
