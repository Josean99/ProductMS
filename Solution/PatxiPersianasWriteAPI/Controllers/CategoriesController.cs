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
using Microsoft.AspNetCore.Authorization;

namespace ProductsWriteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesWriteService _categoriesWriteService;

        public CategoriesController(ICategoriesWriteService categoriesWriteService)
        {
            _categoriesWriteService = categoriesWriteService;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryRequestDTO>> Create(CategoryRequestDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _categoriesWriteService.Create(categoryDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryRequestDTO>> Update(CategoryRequestDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _categoriesWriteService.Update(categoryDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut("SoftDelete")]
        public async Task<ActionResult<CategoryRequestDTO>> SoftDelete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _categoriesWriteService.SoftDelete(id);
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
            var result = await _categoriesWriteService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }
    }
}
