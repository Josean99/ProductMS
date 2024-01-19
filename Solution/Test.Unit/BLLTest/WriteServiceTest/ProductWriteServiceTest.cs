using AutoMapper;
using DBContext.Base;
using DTOs.Mappers;
using DTOs.RequestDTOs;
using EntityService.Model;
using Infrastructure.WebApiServices.Results;
using IReadRepositories.Base;
using IWriteRepository.Base;
using Microsoft.EntityFrameworkCore.Storage;
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
    public class ProductsWriteServiceTest
    {
        private readonly ProductsWriteService _productsWriteService;
        private readonly Mock<IBaseWriteRepository<Product>> _productWriteRepositoryMock;
        private readonly Mock<IBaseWriteRepository<ProductImage>> _productImageWriteRepositoryMock;
        private readonly Mock<IBaseWriteRepository<Image>> _imageWriteRepositoryMock;
        private readonly Mock<IBaseReadRepository> _baseReadRepositoryMock;
        private readonly Mock<IDbContextTransaction> _unitOfWorkMock;
        private readonly IMapper _mapper;

        public ProductsWriteServiceTest()
        {
            _productWriteRepositoryMock = new Mock<IBaseWriteRepository<Product>>();
            _productImageWriteRepositoryMock = new Mock<IBaseWriteRepository<ProductImage>>();
            _imageWriteRepositoryMock = new Mock<IBaseWriteRepository<Image>>();
            _baseReadRepositoryMock = new Mock<IBaseReadRepository>();
            _unitOfWorkMock = new Mock<IDbContextTransaction>();

            var mapperConfiguration = AutoMapperConfiguration.Configure();
            
            _productsWriteService = new ProductsWriteService(
                _productWriteRepositoryMock.Object,
                _productImageWriteRepositoryMock.Object,
                _imageWriteRepositoryMock.Object,
                _baseReadRepositoryMock.Object,
                mapperConfiguration.CreateMapper()
            );

            _mapper = mapperConfiguration.CreateMapper();

            //var a = mapperConfiguration.CreateMapper().Map<ProductWithImagesRequestDTO, Product>( new ProductWithImagesRequestDTO());
        }

        [Fact]
        public void WhenCreateWithImagesThenOk()
        {
            Product fakeEntity = ProductFake.GenerateFakeProduct();
            fakeEntity.ProductImages = new List<ProductImage>(ProductImageFake.GenerateFakeProductImages());
            fakeEntity.ProductImages.ToList().ForEach(pi => pi.Image = ImageFake.GenerateFakeImage());
            ProductWithImagesRequestDTO fakeDTO = ProductDTOFake.GenerateFakeProductWithImagesRequestDTO();

            //Arrange
            _productWriteRepositoryMock.Setup(repo => repo.GetUnitOfWork().Result.GetTransaction()).Returns(_unitOfWorkMock.Object);
            _productWriteRepositoryMock.Setup(s => s.Create(It.IsAny<Product>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<ProductWithImagesRequestDTO> result = _productsWriteService.CreateProductWithImages(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _productWriteRepositoryMock.Verify(s => s.Create(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void WhenCreateThenOk()
        {
            Product fakeEntity = ProductFake.GenerateFakeProduct();
            ProductRequestDTO fakeDTO = ProductDTOFake.GenerateFakeProductRequestDTO();

            //Arrange
            _productWriteRepositoryMock.Setup(s => s.Create(It.IsAny<Product>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<ProductRequestDTO> result = _productsWriteService.Create(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _productWriteRepositoryMock.Verify(s => s.Create(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void WhenUpdateThen()
        {
            Product fakeEntity = ProductFake.GenerateFakeProduct();
            ProductRequestDTO fakeDTO = ProductDTOFake.GenerateFakeProductRequestDTO();

            //Arrange
            _productWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Product>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<ProductRequestDTO> result = _productsWriteService.Update(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _productWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void WhenUpdateWithImagesThen()
        {
            ProductWithImagesRequestDTO fakeDTO = ProductDTOFake.GenerateFakeProductWithImagesRequestDTO();
            fakeDTO.ProductImages.ToList().ForEach(pi => pi.Image = ImageDTOFake.GenerateFakeImageRequestDTO());

            Product fakeEntityInitialState = _mapper.Map<ProductWithImagesRequestDTO, Product>(fakeDTO);

            // Set first one to Down
            fakeDTO.ProductImages.Skip(0).Take(1).First().FechaBaja = DateTime.Now;
            // Set second one to Up
            fakeDTO.ProductImages.Skip(1).Take(1).First().FechaBaja = null;
            // ProductImage to Create
            fakeDTO.ProductImages.Add(
                new ProductImageRequestDTO
                {
                    Id = null,
                    Priority = 3,
                    IdProduct = Guid.NewGuid(),
                    IdImage = Guid.NewGuid(),
                    FechaBaja = null,
                });

            //Arrange
            _productWriteRepositoryMock.Setup(repo => repo.GetUnitOfWork().Result.GetTransaction()).Returns(_unitOfWorkMock.Object);
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<Expression<Func<Product, object>>[]>())).Returns(Task.FromResult(fakeEntityInitialState));
            _baseReadRepositoryMock.Setup(s => s.GetByCondition<ProductImage>(It.IsAny<Expression<Func<ProductImage, bool>>>())).Returns(Task.FromResult(fakeEntityInitialState.ProductImages.AsQueryable()));                        
            //_baseReadRepositoryMock.Setup(s => s.GetByCondition<ProductImage>(It.IsAny<Expression<Func<ProductImage, bool>>>())).Returns(Task.FromResult(It.IsAny<IQueryable<ProductImage>>()));                        
            _productImageWriteRepositoryMock.Setup(s => s.Update(It.IsAny<ProductImage>())).Returns(Task.FromResult(It.IsAny<ProductImage>()));
            _productImageWriteRepositoryMock.Setup(s => s.Create(It.IsAny<ProductImage>())).Returns(Task.FromResult(It.IsAny<ProductImage>()));
            _productWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Product>())).Returns(Task.FromResult(It.IsAny<Product>()));

            //Act
            Result<ProductWithImagesRequestDTO> result = _productsWriteService.UpdateProductWithImages(fakeDTO).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _productWriteRepositoryMock.Verify(s => s.GetUnitOfWork(), Times.Once);
            _baseReadRepositoryMock.Verify(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<Expression<Func<Product, object>>[]>()), Times.Once);
            _baseReadRepositoryMock.Verify(s => s.GetByCondition<ProductImage>(It.IsAny<Expression<Func<ProductImage, bool>>>()), Times.Once);
            _productImageWriteRepositoryMock.Verify(s => s.Update(It.IsAny<ProductImage>()), Times.Exactly(2));
            _productImageWriteRepositoryMock.Verify(s => s.Create(It.IsAny<ProductImage>()), Times.Once);
            _productWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void WhenSoftDeleteThen()
        {
            Product fakeEntity = ProductFake.GenerateFakeProduct();
            ProductRequestDTO fakeDTO = ProductDTOFake.GenerateFakeProductRequestDTO();

            //Arrange
            _baseReadRepositoryMock.Setup(s => s.GetFirstByCondition(It.IsAny<Expression<Func<Product, bool>>>())).Returns(Task.FromResult(fakeEntity));
            _productWriteRepositoryMock.Setup(s => s.Update(It.IsAny<Product>())).Returns(Task.FromResult(fakeEntity));

            //Act
            Result<ProductRequestDTO> result = _productsWriteService.SoftDelete(fakeDTO.Id.Value).Result;

            //Assert
            Assert.True(result.Success);

            //Verify
            _productWriteRepositoryMock.Verify(s => s.Update(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void WhenDeleteThen()
        {
            Product fakeEntity = ProductFake.GenerateFakeProduct();
            ProductRequestDTO fakeDTO = ProductDTOFake.GenerateFakeProductRequestDTO();

            //Arrange
            _productWriteRepositoryMock.Setup(s => s.Delete(It.IsAny<Product>()));

            //Act
            Task task = _productsWriteService.Delete(Guid.NewGuid());

            //Assert
            Assert.True(task.IsCompletedSuccessfully);

            //Verify
            _productWriteRepositoryMock.Verify(s => s.Delete(It.IsAny<Product>()), Times.Once);
        }
    }
}
