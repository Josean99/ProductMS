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
    public class TextValidatorTest
    {
        private readonly TextValidator _validator;

        public TextValidatorTest()
        {
            _validator = new TextValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenCodeIsEmpty()
        {
            // Arrange
            var text = new Text { Code = string.Empty, Value = "Sample text" };

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
            var text = new Text { Code = "123", Value = string.Empty };

            // Act
            var result = _validator.TestValidate(text);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Value)
                .WithErrorMessage("Text is required.");
        }

        [Fact]
        public void ShouldPassValidationWhenTextIsValid()
        {
            // Arrange
            var text = new Text { Code = "123", Value = "Sample text" };

            // Act
            var result = _validator.TestValidate(text);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
