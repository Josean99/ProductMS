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
    public class TextReadServiceTest
    {
        private readonly TextsReadService _textReadService;
        private readonly Mock<IBaseReadRepository> _baseReadRepositoryMock;

        public TextReadServiceTest()
        {
            _baseReadRepositoryMock = new Mock<IBaseReadRepository>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            _textReadService = new TextsReadService(
                _baseReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
                );
        }

        [Fact]
        public void WhenGetByIdThenOk()
        {
            Text fakeReturn = TextFake.GenerateFakeText();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Text, bool>>>())).Returns(Task.FromResult(fakeReturn));

            //Act
            TextResponseDTO result = _textReadService.Get(fakeReturn.Id).Result;

            //Assert
            Assert.NotNull(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Text, bool>>>()), Times.Once);
        }

        [Fact]
        public void WhenGetAllThenOk()
        {
            IQueryable<Text> fakeReturn = new List<Text>() { TextFake.GenerateFakeText() }.AsQueryable();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetAll<Text>()).Returns(Task.FromResult(fakeReturn));

            //Act
            List<TextResponseDTO> result = _textReadService.GetAll().Result;

            //Assert
            Assert.NotEmpty(result);

            //Verify
            _baseReadRepositoryMock.Verify(s => s.GetAll<Text>(), Times.Once);
        }
    }
}
