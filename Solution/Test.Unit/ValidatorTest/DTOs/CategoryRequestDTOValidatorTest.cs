using DTOs;
using DTOs.RequestDTOs;
using EntityService.Validators;
using FluentValidation.TestHelper;

namespace Test.Unit.ValidatorTest.DTOs
{    public class CategoryRequestDTOValidatorTests
    {
        private readonly CategoryRequestDTOValidator _validator;

        public CategoryRequestDTOValidatorTests()
        {
            _validator = new CategoryRequestDTOValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenNameIsEmpty()
        {
            // Arrange
            var category = new CategoryRequestDTO { Name = string.Empty, Icon = "icon.png", IdFatherCategory = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(category);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("Name is required.");
        }

        [Fact]
        public void ShouldFailValidationWhenIconIsEmpty()
        {
            // Arrange
            var category = new CategoryRequestDTO { Name = "Sample name", Icon = string.Empty, IdFatherCategory = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(category);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Icon)
                .WithErrorMessage("Icon is required.");
        }

        [Fact]
        public void ShouldPassValidationWhenCategoryDTOIsValid()
        {
            // Arrange
            var category = new CategoryRequestDTO { Name = "Sample name", Icon = "icon.png", IdFatherCategory = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(category);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }

}
