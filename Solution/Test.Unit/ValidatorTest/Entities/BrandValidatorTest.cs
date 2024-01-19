using Xunit;
using FluentValidation;
using FluentValidation.TestHelper;
using EntityService.Validators;
using EntityService.Model;

namespace Test.Unit.ValidatorTest.Entities
{
    public class BrandValidatorTest
    {
        private readonly BrandValidator _validator;

        public BrandValidatorTest()
        {
            _validator = new BrandValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenNameIsEmpty()
        {
            // Arrange
            var brand = new Brand { Name = string.Empty, Description = "Sample description", IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("Brand name cannot be empty.");
        }

        [Fact]
        public void ShouldFailValidationWhenNameExceedsMaximumLength()
        {
            // Arrange
            var brand = new Brand { Name = new string('A', 101), Description = "Sample description", IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("Brand name cannot exceed 100 characters.");
        }

        [Fact]
        public void ShouldFailValidationWhenDescriptionIsEmpty()
        {
            // Arrange
            var brand = new Brand { Name = "Sample name", Description = string.Empty, IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorMessage("Brand description cannot be empty.");
        }

        [Fact]
        public void ShouldFailValidationWhenDescriptionExceedsMaximumLength()
        {
            // Arrange
            var brand = new Brand { Name = "Sample name", Description = new string('A', 1001), IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorMessage("Brand description cannot exceed 1000 characters.");
        }

        [Fact]
        public void ShouldPassValidationWhenBrandIsValid()
        {
            // Arrange
            var brand = new Brand { Name = "Sample name", Description = "Sample description", IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}