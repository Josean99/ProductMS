using DTOs;
using DTOs.RequestDTOs;
using EntityService.Validators;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Unit.ValidatorTest.DTOs
{
    public class ImageRequestDTOValidatorTests
    {
        private readonly ImageRequestDTOValidator _validator;

        public ImageRequestDTOValidatorTests()
        {
            _validator = new ImageRequestDTOValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenPathIsEmpty()
        {
            // Arrange
            var image = new ImageRequestDTO { Path = string.Empty, AlternativeText = "Sample alt text" };

            // Act
            var result = _validator.TestValidate(image);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Path)
                .WithErrorMessage("Path is required.");
        }

        [Fact]
        public void ShouldFailValidationWhenAlternativeTextIsEmpty()
        {
            // Arrange
            var image = new ImageRequestDTO { Path = "image.jpg", AlternativeText = string.Empty };

            // Act
            var result = _validator.TestValidate(image);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.AlternativeText)
                .WithErrorMessage("Alternative text is required.");
        }

        [Fact]
        public void ShouldFailValidationWhenAlternativeTextExceedsMaximumLength()
        {
            // Arrange
            var image = new ImageRequestDTO { Path = "image.jpg", AlternativeText = new string('A', 101) };

            // Act
            var result = _validator.TestValidate(image);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.AlternativeText)
                .WithErrorMessage("Alternative text must not exceed 100 characters.");
        }

        [Fact]
        public void ShouldPassValidationWhenImageDTOIsValid()
        {
            // Arrange
            var image = new ImageRequestDTO { Path = "image.jpg", AlternativeText = "Sample alt text" };

            // Act
            var result = _validator.TestValidate(image);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
