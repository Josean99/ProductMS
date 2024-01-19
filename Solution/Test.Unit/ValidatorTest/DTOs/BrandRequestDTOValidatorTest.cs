using Xunit;
using FluentValidation;
using FluentValidation.TestHelper;
using DTOs;
using DTOs.Validators;
using DTOs.RequestDTOs;

namespace Test.Unit.ValidatorTest.DTOs
{
    public class BrandRequestDTOValidatorTests
    {
        private readonly BrandRequestDTOValidator _validator;

        public BrandRequestDTOValidatorTests()
        {
            _validator = new BrandRequestDTOValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenNameIsEmpty()
        {
            // Arrange
            var brand = new BrandRequestDTO { Name = string.Empty, Description = "Sample description", IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("BrandDTO name cannot be empty.");
        }

        [Fact]
        public void ShouldFailValidationWhenNameExceedsMaximumLength()
        {
            // Arrange
            var brand = new BrandRequestDTO { Name = new string('A', 101), Description = "Sample description", IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("BrandDTO name cannot exceed 100 characters.");
        }

        [Fact]
        public void ShouldFailValidationWhenDescriptionIsEmpty()
        {
            // Arrange
            var brand = new BrandRequestDTO { Name = "Sample name", Description = string.Empty, IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorMessage("BrandDTO description cannot be empty.");
        }

        [Fact]
        public void ShouldFailValidationWhenDescriptionExceedsMaximumLength()
        {
            // Arrange
            var brand = new BrandRequestDTO { Name = "Sample name", Description = new string('A', 1001), IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorMessage("BrandDTO description cannot exceed 1000 characters.");
        }

        [Fact]
        public void ShouldPassValidationWhenBrandDTOIsValid()
        {
            // Arrange
            var brand = new BrandRequestDTO { Name = "Sample name", Description = "Sample description", IdImage = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(brand);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}