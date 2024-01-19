using EntityService.Model;
using EntityService.Validators;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Unit.ValidatorTest.Entities
{    public class CategoryValidatorTest
    {
        private readonly CategoryValidator _validator;

        public CategoryValidatorTest()
        {
            _validator = new CategoryValidator();
        }

        [Fact]
        public void ShouldFailValidationWhenNameIsEmpty()
        {
            // Arrange
            var category = new Category { Name = string.Empty, Icon = "icon.png", IdFatherCategory = Guid.NewGuid() };

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
            var category = new Category { Name = "Sample name", Icon = string.Empty, IdFatherCategory = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(category);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Icon)
                .WithErrorMessage("Icon is required.");
        }

        [Fact]
        public void ShouldPassValidationWhenCategoryIsValid()
        {
            // Arrange
            var category = new Category { Name = "Sample name", Icon = "icon.png", IdFatherCategory = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(category);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }

}
