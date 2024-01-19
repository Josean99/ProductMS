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
    public class BrandsWriteServiceTest
    {
        private readonly BrandsWriteService _brandsWriteService;
        private readonly Mock<IBaseWriteRepository<Brand>> _brandWriteRepositoryMock;
        private readonly Mock<IBaseReadRepository> _brandReadRepositoryMock;

        public BrandsWriteServiceTest()
        {
            _brandWriteRepositoryMock = new Mock<IBaseWriteRepository<Brand>>();
            _brandReadRepositoryMock = new Mock<IBaseReadRepository>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();

            _brandsWriteService = new BrandsWriteService(
                _brandWriteRepositoryMock.Object,
                _brandReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
                );
        }

        [Fact]
        public void WhenCreateThenOk()
        {
            Brand fakeEntity = BrandFake.GenerateFakeBrand();
            BrandRequestDTO fakeDTO = BrandDTOFake.GenerateFakeBrandRequestDTO();

            //Arrange
            _brandWriteRepositoryMock.Setup(s => s.Create(It.IsAny<Brand>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<BrandRequestDTO> result = _brandsWriteService.Create(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _brandWriteRepositoryMock.Verify(s => s.Create(It.IsAny<Brand>()), Times.Once);
        }

        [Fact]
        public void WhenUpdateThen()
        {
            Brand fakeEntity = BrandFake.GenerateFakeBrand();
            BrandRequestDTO fakeDTO = BrandDTOFake.GenerateFakeBrandRequestDTO();

            //Arrange
            _brandWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Brand>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<BrandRequestDTO> result = _brandsWriteService.Update(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _brandWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Brand>()), Times.Once);
        }

        [Fact]
        public void WhenSoftDeleteThen()
        {
            Brand fakeEntity = BrandFake.GenerateFakeBrand();
            BrandRequestDTO fakeDTO = BrandDTOFake.GenerateFakeBrandRequestDTO();

            //Arrange
            _brandReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Brand, bool>>>())).Returns(Task.FromResult(fakeEntity));
            _brandWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Brand>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<BrandRequestDTO> result = _brandsWriteService.SoftDelete(fakeDTO.Id.Value).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _brandWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Brand>()), Times.Once);
        }

        [Fact]
        public void WhenDeleteThen()
        {
            Brand fakeEntity = BrandFake.GenerateFakeBrand();
            BrandRequestDTO fakeDTO = BrandDTOFake.GenerateFakeBrandRequestDTO();

            //Arrange
            _brandWriteRepositoryMock.Setup(s => s.Delete(It.IsAny<Brand>()));

            //Act
            Task task = _brandsWriteService.Delete(Guid.NewGuid());

            //Assert
            Assert.True(task.IsCompletedSuccessfully);

            //Verify
            _brandWriteRepositoryMock.Verify(s => s.Delete(It.IsAny<Brand>()), Times.Once);
        }


    }
}