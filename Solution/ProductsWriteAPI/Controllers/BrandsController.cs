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
using Infrastructure.WebApiServices.Results;

namespace ProductsWriteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsWriteService _brandWriteService;

        public BrandsController(IBrandsWriteService brandWriteService)
        {
            _brandWriteService = brandWriteService;
        }

        [HttpPost]
        public async Task<ActionResult<BrandRequestDTO>> Create(BrandRequestDTO brandDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _brandWriteService.Create(brandDTO);
            if (result.Success)
            {
                return Ok(result);
            }            
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut]
        public async Task<ActionResult<BrandRequestDTO>> Update(BrandRequestDTO brandDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _brandWriteService.Update(brandDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut("SoftDelete")]
        public async Task<ActionResult<BrandRequestDTO>> SoftDelete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _brandWriteService.SoftDelete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _brandWriteService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }
    }
}
