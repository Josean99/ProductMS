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
    public class WriteImageTests
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ImagesController _imagesController;

        public WriteImageTests()
        {
            _serviceProvider = RegisterExtensionTesting.BuildDependencies();
            _imagesController = _serviceProvider.GetRequiredService<ImagesController>();
        }

        [Fact]
        public async Task CRUD_Test()
        {
            // Arrange
            var newImage = ImageDTOFake.GenerateFakeImageRequestDTO();

            // Act
            var inserted = await _imagesController.Create(newImage);

            inserted.Should().BeOfType<ActionResult<ImageRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var insertedImage = ((inserted.Result as OkObjectResult).Value as Result<ImageRequestDTO>).Data;

            insertedImage.Path = "New Path";
            var updated = await _imagesController.Update(insertedImage);

            updated.Should().BeOfType<ActionResult<ImageRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var updatedImage = ((updated.Result as OkObjectResult).Value as Result<ImageRequestDTO>).Data;

            updatedImage.Path.Should().Be("New Path"); 

            var softDeleted = await _imagesController.SoftDelete(insertedImage.Id.Value);

            softDeleted.Should().BeOfType<ActionResult<ImageRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var deleted = await _imagesController.Delete(insertedImage.Id.Value);

            deleted.Should().BeOfType<ActionResult<Guid>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }


}