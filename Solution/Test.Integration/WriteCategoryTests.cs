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
            var newEntity = CategoryDTOFake.GenerateFakeCategoryRequestDTO();

            //Act
            var inserted = await _categoriesController.Create(newEntity);

            inserted.Should().BeOfType<ActionResult<CategoryRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var brand = inserted.Value;

            brand.Name = "New Name";
            var updated = await _categoriesController.Update(brand);

            updated.Should().BeOfType<ActionResult<CategoryRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            Assert.True(updated.Value.Name == "New Name");

            var softDeleted = await _categoriesController.SoftDelete(brand.Id.Value);

            softDeleted.Should().BeOfType<ActionResult<CategoryRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var deleted = await _categoriesController.Delete(brand.Id.Value);

            deleted.Should().BeOfType<ActionResult<CategoryRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}