using DTOs;
using DTOs.RequestDTOs;
using EntityService.Validators;
using FluentValidation.TestHelper;

namespace Test.Unit.ValidatorTest.Entities
{
    public class TextRequestDTOValidatorTests
    {
        private readonly TextRequestDTOValidator _validator;

        public TextRequestDTOValidatorTests()
        {
            _validator = new TextRequestDTOValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenCodeIsEmpty()
        {
            // Arrange
            var text = new TextRequestDTO { Code = string.Empty, Value = "Sample text" };

            // Act
            var result = _validator.TestValidate(text);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Code)
                .WithErrorMessage("Code is required.");
        }

        [Fact]
        public void ShouldFailValidationWhenValueIsEmpty()
        {
            // Arrange
            var text = new TextRequestDTO { Code = "123", Value = string.Empty };

            // Act
            var result = _validator.TestValidate(text);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Value)
                .WithErrorMessage("Text is required.");
        }

        [Fact]
        public void ShouldPassValidationWhenTextDTOIsValid()
        {
            // Arrange
            var text = new TextRequestDTO { Code = "123", Value = "Sample text" };

            // Act
            var result = _validator.TestValidate(text);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
