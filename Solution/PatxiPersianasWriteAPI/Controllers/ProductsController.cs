using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityService.Model;
using IWriteBusinessLayer;
using AutoMapper;
using IReadBusinessLayer.Base;
using DTOs.RequestDTOs;
using WriteBusinessLayer;

namespace ProductsWriteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsWriteService _productsWriteService;

        public ProductsController(IProductsWriteService productsWriteService)
        {
            _productsWriteService = productsWriteService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductRequestDTO>> Create(ProductRequestDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _productsWriteService.Create(productDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPost("CreateProductWithImages")]
        public async Task<ActionResult<ProductWithImagesRequestDTO>> CreateProductWithImages(ProductWithImagesRequestDTO productWithImagesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _productsWriteService.CreateProductWithImages(productWithImagesDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut]
        public async Task<ActionResult<ProductRequestDTO>> Update(ProductRequestDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _productsWriteService.Update(productDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut("UpdateProductWithImages")]
        public async Task<ActionResult<ProductWithImagesRequestDTO>> UpdateProductWithImages(ProductWithImagesRequestDTO productWithImagesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _productsWriteService.UpdateProductWithImages(productWithImagesDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut("SoftDelete")]
        public async Task<ActionResult<ProductRequestDTO>> SoftDelete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _productsWriteService.SoftDelete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut("SoftDeleteWithImages")]
        public async Task<ActionResult<Guid>> SoftDeleteWithImages(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _productsWriteService.SoftDeleteWithImages(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

    }
}
