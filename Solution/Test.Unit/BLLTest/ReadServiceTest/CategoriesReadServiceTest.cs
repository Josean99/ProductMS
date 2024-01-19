using AutoMapper;
using DTOs.Mappers;
using DTOs.ResponseDTOs;
using EntityService.Model;
using IReadRepositories;
using IReadRepositories.Base;
using Moq;
using ReadBusinessLayer;
using System.Linq.Expressions;
using Test.Common.Configuration;
using Test.Common.Fakes.DTOs;
using Test.Common.Fakes.Entities;
using Xunit;

namespace Test.Unit.BLLTest.ReadServiceTest
{
    [Trait("Category", "BLL")]
    public class CategoryReadServiceTest
    {
        private readonly CategoriesReadService _categoryReadService;
        private readonly Mock<IBaseReadRepository> _baseReadRepositoryMock;
        private readonly Mock<ICategoriesReadRepository> _categoriesReadRepositoryMock;

        public CategoryReadServiceTest()
        {
            _baseReadRepositoryMock = new Mock<IBaseReadRepository>();
            _categoriesReadRepositoryMock = new Mock<ICategoriesReadRepository>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            _categoryReadService = new CategoriesReadService(
                _baseReadRepositoryMock.Object,
                _categoriesReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
                );
        }

        [Fact]
        public void WhenGetByIdThenOk()
        {
            Category fakeReturn = CategoryFake.GenerateFakeCategory();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Category, bool>>>())).Returns(Task.FromResult(fakeReturn));

            //Act
            CategoryResponseDTO result = _categoryReadService.Get(fakeReturn.Id).Result;

            //Assert
            Assert.NotNull(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Category, bool>>>()), Times.Once);
        }

        [Fact]
        public void WhenGetAllThenOk()
        {
            IQueryable<Category> fakeReturn = new List<Category>() { CategoryFake.GenerateFakeCategory() }.AsQueryable();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetAll<Category>()).Returns(Task.FromResult(fakeReturn));

            //Act
            List<CategoryResponseDTO> result = _categoryReadService.GetAll().Result;

            //Assert
            Assert.NotEmpty(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetAll<Category>(), Times.Once);
        }

        [Fact]
        public void WhenGetIncludedThenOk()
        {
            Category fakeReturn = CategoryFake.GenerateFakeCategory();
            fakeReturn.Image = ImageFake.GenerateFakeImage();

            //Arrange
            //_baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Category, bool>>>(),It.IsAny<Expression<Func<Category, object>>[]>())).Returns(Task.FromResult(fakeReturn));
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Category, bool>>>(), e => e.Image)).Returns(Task.FromResult(fakeReturn));

            //Act
            CategoryResponseDTO result = _categoryReadService.GetIncluded(fakeReturn.Id).Result;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Image);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Category, bool>>>(), e => e.Image), Times.Once);
        }

        [Fact]
        public void WhenGetAllIncludedThenOk()
        {
            var category1 = CategoryFake.GenerateFakeCategory();
            category1.Image = ImageFake.GenerateFakeImage();

            IQueryable<Category> fakeReturn = new List<Category>() { category1 }.AsQueryable();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetAll<Category>(e => e.Image)).Returns(Task.FromResult(fakeReturn));

            //Act
            List<CategoryResponseDTO> result = _categoryReadService.GetAllIncluded().Result;

            //Assert
            Assert.NotEmpty(result);
            Assert.All(result, e => Assert.NotNull(e.Image));

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetAll<Category>(e => e.Image), Times.Once);
        }
    }
}
