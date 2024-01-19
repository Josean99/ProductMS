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
    public class ImageReadServiceTest
    {
        private readonly ImagesReadService _imageReadService;
        private readonly Mock<IBaseReadRepository> _baseReadRepositoryMock;

        public ImageReadServiceTest()
        {
            _baseReadRepositoryMock = new Mock<IBaseReadRepository>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            _imageReadService = new ImagesReadService(
                _baseReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
                );
        }

        [Fact]
        public void WhenGetByIdThenOk()
        {
            Image fakeReturn = ImageFake.GenerateFakeImage();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Image, bool>>>())).Returns(Task.FromResult(fakeReturn));

            //Act
            ImageResponseDTO result = _imageReadService.Get(fakeReturn.Id).Result;

            //Assert
            Assert.NotNull(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Image, bool>>>()), Times.Once);
        }

        [Fact]
        public void WhenGetAllThenOk()
        {
            IQueryable<Image> fakeReturn = new List<Image>() { ImageFake.GenerateFakeImage() }.AsQueryable();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetAll<Image>()).Returns(Task.FromResult(fakeReturn));

            //Act
            List<ImageResponseDTO> result = _imageReadService.GetAll().Result;

            //Assert
            Assert.NotEmpty(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetAll<Image>(), Times.Once);
        }
    }
}
