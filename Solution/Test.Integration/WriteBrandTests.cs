using AutoMapper;
using DBContext;
using DTOs.Mappers;
using DTOs.RequestDTOs;
using FluentAssertions;
using Infrastructure;
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
    public class WriteBrandTests
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly BrandsController _brandController;

        public WriteBrandTests()
        {
            _serviceProvider = RegisterExtensionTesting.BuildDependencies();
            _brandController = _serviceProvider.GetRequiredService<BrandsController>();
        }

        [Fact]
        public async Task CRUD_Test()
        {
            //Arrange
            var newBrand = BrandDTOFake.InsBrandRequestDTO_1();

            //Act
            var inserted = await _brandController.Create(newBrand);

            inserted.Should().BeOfType<ActionResult<BrandRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var brand = inserted.Value;

            brand.Description = "New Description";
            var updated = await _brandController.Update(brand);

            updated.Should().BeOfType<ActionResult<BrandRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            Assert.True(updated.Value.Description == "New Description");

            var softDeleted = await _brandController.SoftDelete(brand.Id.Value);

            softDeleted.Should().BeOfType<ActionResult<BrandRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var deleted = await _brandController.Delete(brand.Id.Value);

            deleted.Should().BeOfType<ActionResult<BrandRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}