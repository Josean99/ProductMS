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
    public class ImageValidatorTest
    {
        private readonly ImageValidator _validator;

        public ImageValidatorTest()
        {
            _validator = new ImageValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenPathIsEmpty()
        {
            // Arrange
            var image = new Image { Path = string.Empty, AlternativeText = "Sample alt text" };

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
            var image = new Image { Path = "image.jpg", AlternativeText = string.Empty };

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
            var image = new Image { Path = "image.jpg", AlternativeText = new string('A', 101) };

            // Act
            var result = _validator.TestValidate(image);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.AlternativeText)
                .WithErrorMessage("Alternative text must not exceed 100 characters.");
        }

        [Fact]
        public void ShouldPassValidationWhenImageIsValid()
        {
            // Arrange
            var image = new Image { Path = "image.jpg", AlternativeText = "Sample alt text" };

            // Act
            var result = _validator.TestValidate(image);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
