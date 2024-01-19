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
    public class TextsWriteServiceTest
    {
        private readonly TextsWriteService _textsWriteService;
        private readonly Mock<IBaseWriteRepository<Text>> _textWriteRepositoryMock;
        private readonly Mock<IBaseReadRepository> _textReadRepositoryMock;

        public TextsWriteServiceTest()
        {
            _textWriteRepositoryMock = new Mock<IBaseWriteRepository<Text>>();
            _textReadRepositoryMock = new Mock<IBaseReadRepository>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            _textsWriteService = new TextsWriteService(
                _textWriteRepositoryMock.Object,
                _textReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
            );
        }

        [Fact]
        public void WhenCreateThenOk()
        {
            Text fakeEntity = TextFake.GenerateFakeText();
            TextRequestDTO fakeDTO = TextDTOFake.GenerateFakeTextRequestDTO();

            //Arrange
            _textWriteRepositoryMock.Setup(s => s.Create(It.IsAny<Text>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<TextRequestDTO> result = _textsWriteService.Create(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _textWriteRepositoryMock.Verify(s => s.Create(It.IsAny<Text>()), Times.Once);
        }

        [Fact]
        public void WhenUpdateThen()
        {
            Text fakeEntity = TextFake.GenerateFakeText();
            TextRequestDTO fakeDTO = TextDTOFake.GenerateFakeTextRequestDTO();

            //Arrange
            _textWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Text>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<TextRequestDTO> result = _textsWriteService.Update(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _textWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Text>()), Times.Once);
        }

        [Fact]
        public void WhenSoftDeleteThen()
        {
            Text fakeEntity = TextFake.GenerateFakeText();
            TextRequestDTO fakeDTO = TextDTOFake.GenerateFakeTextRequestDTO();

            //Arrange
            _textReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Text, bool>>>())).Returns(Task.FromResult(fakeEntity));
            _textWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Text>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<TextRequestDTO> result = _textsWriteService.SoftDelete(fakeDTO.Id.Value).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _textWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Text>()), Times.Once);
        }

        [Fact]
        public void WhenDeleteThen()
        {
            Text fakeEntity = TextFake.GenerateFakeText();
            TextRequestDTO fakeDTO = TextDTOFake.GenerateFakeTextRequestDTO();

            //Arrange
            _textWriteRepositoryMock.Setup(s => s.Delete(It.IsAny<Text>()));

            //Act
            Task task = _textsWriteService.Delete(Guid.NewGuid());

            //Assert
            Assert.True(task.IsCompletedSuccessfully);

            //Verify
            _textWriteRepositoryMock.Verify(s => s.Delete(It.IsAny<Text>()), Times.Once);
        }
    }
}
