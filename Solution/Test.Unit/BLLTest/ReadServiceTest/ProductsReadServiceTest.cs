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
    public class ProductReadServiceTest
    {
        private readonly ProductsReadService _productReadService;
        private readonly Mock<IBaseReadRepository> _baseReadRepositoryMock;

        public ProductReadServiceTest()
        {
            _baseReadRepositoryMock = new Mock<IBaseReadRepository>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            _productReadService = new ProductsReadService(
                _baseReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
                );
        }

        [Fact]
        public void WhenGetByIdThenOk()
        {
            Product fakeReturn = ProductFake.GenerateFakeProduct();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Product, bool>>>())).Returns(Task.FromResult(fakeReturn));

            //Act
            ProductResponseDTO result = _productReadService.Get(fakeReturn.Id).Result;

            //Assert
            Assert.NotNull(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
        }

        [Fact]
        public void WhenGetAllThenOk()
        {
            IQueryable<Product> fakeReturn = new List<Product>() { ProductFake.GenerateFakeProduct() }.AsQueryable();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetAll<Product>()).Returns(Task.FromResult(fakeReturn));

            //Act
            List<ProductResponseDTO> result = _productReadService.GetAll().Result;

            //Assert
            Assert.NotEmpty(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetAll<Product>(), Times.Once);
        }

        [Fact]
        public void WhenGetIncludedThenOk()
        {
            Product fakeReturn = ProductFake.GenerateFakeProduct();
            fakeReturn.Brand = BrandFake.GenerateFakeBrand();
            fakeReturn.Category = CategoryFake.GenerateFakeCategory();

            //Arrange
            //_baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Product, bool>>>(),It.IsAny<Expression<Func<Product, object>>[]>())).Returns(Task.FromResult(fakeReturn));
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Product, bool>>>(), e => e.Brand, e => e.Category, e => e.ProductImages)).Returns(Task.FromResult(fakeReturn));

            //Act
            ProductResponseDTO result = _productReadService.GetIncluded(fakeReturn.Id).Result;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Brand);
            Assert.NotNull(result.Category);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Product, bool>>>(), e => e.Brand, e => e.Category, e => e.ProductImages), Times.Once);
        }

        [Fact]
        public void WhenGetAllIncludedThenOk()
        {
            var product1 = ProductFake.GenerateFakeProduct();
            product1.Brand = BrandFake.GenerateFakeBrand();
            product1.Category = CategoryFake.GenerateFakeCategory();

            IQueryable<Product> fakeReturn = new List<Product>() { product1 }.AsQueryable();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetAll<Product>(e => e.Brand, e => e.Category, e => e.ProductImages)).Returns(Task.FromResult(fakeReturn));

            //Act
            List<ProductResponseDTO> result = _productReadService.GetAllIncluded().Result;

            //Assert
            Assert.NotEmpty(result);
            Assert.All(result, e => Assert.NotNull(e.Brand));
            Assert.All(result, e => Assert.NotNull(e.Category));

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetAll<Product>(e => e.Brand, e => e.Category, e => e.ProductImages), Times.Once);
        }
    }
}
