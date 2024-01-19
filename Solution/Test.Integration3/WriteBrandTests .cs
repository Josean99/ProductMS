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
    public class WriteBrandTests
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly BrandsController _brandsController;

        public WriteBrandTests()
        {
            _serviceProvider = RegisterExtensionTesting.BuildDependencies();
            _brandsController = _serviceProvider.GetRequiredService<BrandsController>();
        }

        [Fact]
        public async Task CRUD_Test()
        {
            // Arrange
            var newBrand = BrandDTOFake.InsBrandRequestDTO_1();

            // Act
            var inserted = await _brandsController.Create(newBrand);

            inserted.Should().BeOfType<ActionResult<BrandRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var insertedBrand = ((inserted.Result as OkObjectResult).Value as Result<BrandRequestDTO>).Data;

            insertedBrand.Name = "New Name";
            var updated = await _brandsController.Update(insertedBrand);

            updated.Should().BeOfType<ActionResult<BrandRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var updatedBrand = ((updated.Result as OkObjectResult).Value as Result<BrandRequestDTO>).Data;

            updatedBrand.Name.Should().Be("New Name"); // Use Should() for FluentAssertions

            var softDeleted = await _brandsController.SoftDelete(insertedBrand.Id.Value);

            softDeleted.Should().BeOfType<ActionResult<BrandRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var deleted = await _brandsController.Delete(insertedBrand.Id.Value);

            deleted.Should().BeOfType<ActionResult<Guid>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }

}