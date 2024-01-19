using AutoMapper;
using DTOs.Mappers;
using EntityService.Model;
using IWriteRepository.Base;
using Moq;
using WriteBusinessLayer;
using System;
using System.Threading.Tasks;
using Test.Common.Configuration;
using Test.Common.Fakes.DTOs;
using Test.Common.Fakes.Entities;
using Xunit;
using DTOs.RequestDTOs;
using Infrastructure.WebApiServices.Results;
using IReadRepositories;
using System.Linq.Expressions;

namespace Test.Unit.BLLTest.WriteServiceTest
{
    [Trait("Category", "BLL")]
    public class CategoriesWriteServiceTest
    {
        private readonly CategoriesWriteService _categoryWriteService;
        private readonly Mock<IBaseWriteRepository<Category>> _categoryWriteRepositoryMock;
        private readonly Mock<ICategoriesReadRepository> _categoryReadRepositoryMock;

        public CategoriesWriteServiceTest()
        {
            _categoryWriteRepositoryMock = new Mock<IBaseWriteRepository<Category>>();
            _categoryReadRepositoryMock = new Mock<ICategoriesReadRepository>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            _categoryWriteService = new CategoriesWriteService(
                _categoryWriteRepositoryMock.Object,
                _categoryReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
            );
        }

        [Fact]
        public void WhenCreateThenOk()
        {
            Category fakeEntity = CategoryFake.GenerateFakeCategory();
            CategoryRequestDTO fakeDTO = CategoryDTOFake.GenerateFakeCategoryRequestDTO();

            // Arrange
            _categoryWriteRepositoryMock.Setup(s => s.Create(It.IsAny<Category>())).Returns(Task.FromResult(fakeEntity));

            // Act
            Result<CategoryRequestDTO> result = _categoryWriteService.Create(fakeDTO).Result;

            // Assert
            Assert.True(result.Success);

            // Verify
            _categoryWriteRepositoryMock.Verify(s => s.Create(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public void WhenUpdateThenOk()
        {
            Category fakeEntity = CategoryFake.GenerateFakeCategory();
            CategoryRequestDTO fakeDTO = CategoryDTOFake.GenerateFakeCategoryRequestDTO();

            // Arrange
            _categoryWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Category>())).Returns(Task.FromResult(fakeEntity));

            // Act
            Result<CategoryRequestDTO> result = _categoryWriteService.Update(fakeDTO).Result;

            // Assert
            Assert.True(result.Success);

            // Verify
            _categoryWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public void WhenSoftDeleteThenOk()
        {
            Category fakeEntity = CategoryFake.GenerateFakeCategory();
            CategoryRequestDTO fakeDTO = CategoryDTOFake.GenerateFakeCategoryRequestDTO();

            // Arrange
            _categoryReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Category, bool>>>())).Returns(Task.FromResult(fakeEntity));
            _categoryWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Category>())).Returns(Task.FromResult(fakeEntity));

            // Act
            Result<CategoryRequestDTO> result = _categoryWriteService.SoftDelete(fakeDTO.Id.Value).Result;

            // Assert
            Assert.True(result.Success);

            // Verify
            _categoryWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public void WhenDeleteThenOk()
        {
            Category fakeEntity = CategoryFake.GenerateFakeCategory();
            CategoryRequestDTO fakeDTO = CategoryDTOFake.GenerateFakeCategoryRequestDTO();

            // Arrange
            _categoryWriteRepositoryMock.Setup(s => s.Delete(It.IsAny<Category>()));

            // Act
            Task task = _categoryWriteService.Delete(Guid.NewGuid());

            // Assert
            Assert.True(task.IsCompletedSuccessfully);

            // Verify
            _categoryWriteRepositoryMock.Verify(s => s.Delete(It.IsAny<Category>()), Times.Once);
        }
    }
}
