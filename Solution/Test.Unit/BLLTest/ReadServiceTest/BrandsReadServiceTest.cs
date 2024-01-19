using AutoMapper;
using DTOs.Mappers;
using DTOs.ResponseDTOs;
using EntityService.Model;
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
    public class BrandsReadServiceTest
    {
        private readonly BrandsReadService _brandsReadService;
        private readonly Mock<IBaseReadRepository> _baseReadRepositoryMock;

        public BrandsReadServiceTest()
        {
            _baseReadRepositoryMock = new Mock<IBaseReadRepository>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            _brandsReadService = new BrandsReadService(
                _baseReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
                );
        }

        [Fact]
        public void WhenGetByIdThenOk()
        {
            Brand fakeReturn = BrandFake.GenerateFakeBrand();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Brand, bool>>>())).Returns(Task.FromResult(fakeReturn));

            //Act
            BrandResponseDTO result = _brandsReadService.Get(fakeReturn.Id).Result;

            //Assert
            Assert.NotNull(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Brand, bool>>>()), Times.Once);
        }

        [Fact]
        public void WhenGetAllThenOk()
        {
            IQueryable<Brand> fakeReturn = new List<Brand>() { BrandFake.GenerateFakeBrand() }.AsQueryable();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetAll<Brand>()).Returns(Task.FromResult(fakeReturn));

            //Act
            List<BrandResponseDTO> result = _brandsReadService.GetAll().Result;

            //Assert
            Assert.NotEmpty(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetAll<Brand>(), Times.Once);
        }

        [Fact]
        public void WhenGetIncludedThenOk()
        {
            Brand fakeReturn = BrandFake.GenerateFakeBrand();
            fakeReturn.Image = ImageFake.GenerateFakeImage();

            //Arrange
            //_baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Brand, bool>>>(),It.IsAny<Expression<Func<Brand, object>>[]>())).Returns(Task.FromResult(fakeReturn));
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Brand, bool>>>(), e => e.Image)).Returns(Task.FromResult(fakeReturn));

            //Act
            BrandResponseDTO result = _brandsReadService.GetIncluded(fakeReturn.Id).Result;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Image);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Brand, bool>>>(), e => e.Image), Times.Once);
        }

        [Fact]
        public void WhenGetAllIncludedThenOk()
        {
            var brand1 = BrandFake.GenerateFakeBrand();
            brand1.Image = ImageFake.GenerateFakeImage();

            IQueryable<Brand> fakeReturn = new List<Brand>() { brand1 }.AsQueryable();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetAll<Brand>(e => e.Image)).Returns(Task.FromResult(fakeReturn));

            //Act
            List<BrandResponseDTO> result = _brandsReadService.GetAllIncluded().Result;

            //Assert
            Assert.NotEmpty(result);
            Assert.All(result, e => Assert.NotNull(e.Image));

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetAll<Brand>(e => e.Image), Times.Once);
        }
    }
}