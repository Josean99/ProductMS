using AutoMapper;
using DBContext;
using DTOs.Mappers;
using DTOs.RequestDTOs;
using FluentAssertions;
using Infrastructure;
using Infrastructure.WebApiServices.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductsWriteAPI.Controllers;
using System.Data.Common;
using System.Net;
using Test.Common.Fakes.DTOs;
using Test.Integration.Utils;
using Assert = Xunit.Assert;

namespace Test.Integration
{
    public class WriteProductTests
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ProductsController _productsController;

        public WriteProductTests()
        {
            _serviceProvider = RegisterExtensionTesting.BuildDependencies();
            _productsController = _serviceProvider.GetRequiredService<ProductsController>();
        }

        [Fact]
        public async Task CRUD_Test()
        {
            // Arrange
            var newProduct = ProductDTOFake.InsProductRequestDTO_1();

            // Act
            var inserted = await _productsController.Create(newProduct);

            inserted.Should().BeOfType<ActionResult<ProductRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var insertedProduct = ((inserted.Result as OkObjectResult).Value as Result<ProductRequestDTO>).Data;

            insertedProduct.Name = "New Name";
            var updated = await _productsController.Update(insertedProduct);

            updated.Should().BeOfType<ActionResult<ProductRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var updatedProduct = ((updated.Result as OkObjectResult).Value as Result<ProductRequestDTO>).Data;

            updatedProduct.Name.Should().Be("New Name"); // Use Should() for FluentAssertions

            var softDeleted = await _productsController.SoftDelete(insertedProduct.Id.Value);

            softDeleted.Should().BeOfType<ActionResult<ProductRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

        }

        [Fact]
        public async Task CRUDWithImages_Test()
        {
            // Arrange
            var newProduct = ProductDTOFake.InsProductRequestWithImagesDTO_1();

            // Act
            var inserted = await _productsController.CreateProductWithImages(newProduct);

            inserted.Should().BeOfType<ActionResult<ProductWithImagesRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var insertedProduct = ((inserted.Result as OkObjectResult).Value as Result<ProductWithImagesRequestDTO>).Data;

            insertedProduct.Name = "New Name";
            insertedProduct.ProductImages.First().FechaBaja = DateTime.Now;
            insertedProduct.ProductImages.Last().FechaBaja = null;
            var newProductImage = ProductImageDTOFake.InsProductImagesRequestDTO_2().First();
            newProductImage.IdProduct = insertedProduct.Id;
            insertedProduct.ProductImages.Add(newProductImage);
            

            var updated = await _productsController.UpdateProductWithImages(insertedProduct);

            updated.Should().BeOfType<ActionResult<ProductWithImagesRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var updatedProduct = ((updated.Result as OkObjectResult).Value as Result<ProductWithImagesRequestDTO>).Data;

            updatedProduct.Name.Should().Be("New Name"); 
            updatedProduct.ProductImages.Where(x => x.FechaBaja == null).Count().Should().Be(2);
            updatedProduct.ProductImages.Where(x => x.FechaBaja != null).Count().Should().Be(1);
            updatedProduct.ProductImages.Count.Should().Be(3);


        }
    }

}