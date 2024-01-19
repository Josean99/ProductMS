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
    public class WriteTextTests
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TextsController _textsController;

        public WriteTextTests()
        {
            _serviceProvider = RegisterExtensionTesting.BuildDependencies();
            _textsController = _serviceProvider.GetRequiredService<TextsController>();
        }

        [Fact]
        public async Task CRUD_Test()
        {
            // Arrange
            var newText = TextDTOFake.GenerateFakeTextRequestDTO();

            // Act
            var inserted = await _textsController.Create(newText);

            inserted.Should().BeOfType<ActionResult<TextRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var insertedText = ((inserted.Result as OkObjectResult).Value as Result<TextRequestDTO>).Data;

            insertedText.Value = "New Content";
            var updated = await _textsController.Update(insertedText);

            updated.Should().BeOfType<ActionResult<TextRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var updatedText = ((updated.Result as OkObjectResult).Value as Result<TextRequestDTO>).Data;

            updatedText.Value.Should().Be("New Content"); // Use Should() for FluentAssertions

            var softDeleted = await _textsController.SoftDelete(insertedText.Id.Value);

            softDeleted.Should().BeOfType<ActionResult<TextRequestDTO>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var deleted = await _textsController.Delete(insertedText.Id.Value);

            deleted.Should().BeOfType<ActionResult<Guid>>()
                .Which.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }

}