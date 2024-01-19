using EntityService.Model;
using EntityService.Validators;
using FluentValidation.TestHelper;

namespace Test.Unit.ValidatorTest.Entities
{
    public class ProductImageValidatorTest
    {
        private readonly ProductImageValidator _validator;

        public ProductImageValidatorTest()
        {
            _validator = new ProductImageValidator();
        }

        [Fact]
        public void ShouldPassValidationWhenProductImageIsValid()
        {
            // Arrange
            var productImage = new ProductImage { Priority = 1, IdProduct = Guid.NewGuid(), IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(productImage);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
