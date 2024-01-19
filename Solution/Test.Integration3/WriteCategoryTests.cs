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
    public class WriteCategoryTests
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly CategoriesController _categoriesController;

        public WriteCategoryTests()
        {
            _serviceProvider = RegisterExtensionTesting.BuildDependencies();
            _categoriesController = _serviceProvider.GetRequiredService<CategoriesController>();
        }

        [Fact]
        public async Task CRUD_Test()
        {
            //Arrange
            var newEntity = CategoryDTOFake.InsCategoryRequestDTO_1();

            //Act
            var inserted = await _categoriesController.Create(newEntity);

            inserted.Should().BeOfType<ActionResult<CategoryRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK)                ;

            var insertedBrand = ((inserted.Result as OkObjectResult).Value as Result<CategoryRequestDTO>).Data;

            insertedBrand.Name = "New Name";
            var updated = await _categoriesController.Update(insertedBrand);

            updated.Should().BeOfType<ActionResult<CategoryRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var updatedBrand = ((inserted.Result as OkObjectResult).Value as Result<CategoryRequestDTO>).Data;

            Assert.True(updatedBrand.Name == "New Name");

            var softDeleted = await _categoriesController.SoftDelete(insertedBrand.Id.Value);

            softDeleted.Should().BeOfType<ActionResult<CategoryRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var deleted = await _categoriesController.Delete(insertedBrand.Id.Value);

            deleted.Should().BeOfType<ActionResult<Guid>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}