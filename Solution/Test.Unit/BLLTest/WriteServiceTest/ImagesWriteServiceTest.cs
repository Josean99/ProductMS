using AutoMapper;
using DTOs.Mappers;
using DTOs.RequestDTOs;
using EntityService.Model;
using Infrastructure.WebApiServices.Results;
using IReadRepositories.Base;
using IWriteRepository.Base;
using Moq;
using ReadBusinessLayer;
using System.Linq.Expressions;
using Test.Common.Configuration;
using Test.Common.Fakes.DTOs;
using Test.Common.Fakes.Entities;
using WriteBusinessLayer;
using Xunit;

namespace Test.Unit.BLLTest.WriteServiceTest
{
    [Trait("Category", "BLL")]
    public class ImagesWriteServiceTest
    {
        private readonly ImagesWriteService _imagesWriteService;
        private readonly Mock<IBaseWriteRepository<Image>> _imageWriteRepositoryMock;
        private readonly Mock<IBaseReadRepository> _imageReadRepositoryMock;

        public ImagesWriteServiceTest()
        {
            _imageWriteRepositoryMock = new Mock<IBaseWriteRepository<Image>>();
            _imageReadRepositoryMock = new Mock<IBaseReadRepository>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            _imagesWriteService = new ImagesWriteService(
                _imageWriteRepositoryMock.Object,
                _imageReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
            );
        }

        [Fact]
        public void WhenCreateThenOk()
        {
            Image fakeEntity = ImageFake.GenerateFakeImage();
            ImageRequestDTO fakeDTO = ImageDTOFake.GenerateFakeImageRequestDTO();

            //Arrange
            _imageWriteRepositoryMock.Setup(s => s.Create(It.IsAny<Image>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<ImageRequestDTO> result = _imagesWriteService.Create(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _imageWriteRepositoryMock.Verify(s => s.Create(It.IsAny<Image>()), Times.Once);
        }

        [Fact]
        public void WhenUpdateThen()
        {
            Image fakeEntity = ImageFake.GenerateFakeImage();
            ImageRequestDTO fakeDTO = ImageDTOFake.GenerateFakeImageRequestDTO();

            //Arrange
            _imageWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Image>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<ImageRequestDTO> result = _imagesWriteService.Update(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _imageWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Image>()), Times.Once);
        }

        [Fact]
        public void WhenSoftDeleteThen()
        {
            Image fakeEntity = ImageFake.GenerateFakeImage();
            ImageRequestDTO fakeDTO = ImageDTOFake.GenerateFakeImageRequestDTO();

            //Arrange
            _imageReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Image, bool>>>())).Returns(Task.FromResult(fakeEntity));
            _imageWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Image>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<ImageRequestDTO> result = _imagesWriteService.SoftDelete(fakeDTO.Id.Value).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _imageWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Image>()), Times.Once);
        }

        [Fact]
        public void WhenDeleteThen()
        {
            Image fakeEntity = ImageFake.GenerateFakeImage();
            ImageRequestDTO fakeDTO = ImageDTOFake.GenerateFakeImageRequestDTO();

            //Arrange
            _imageWriteRepositoryMock.Setup(s => s.Delete(It.IsAny<Image>()));

            //Act
            Task task = _imagesWriteService.Delete(Guid.NewGuid());

            //Assert
            Assert.True(task.IsCompletedSuccessfully);

            //Verify
            _imageWriteRepositoryMock.Verify(s => s.Delete(It.IsAny<Image>()), Times.Once);
        }
    }
}
