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
    public class TextsController : ControllerBase
    {
        private readonly ITextsWriteService _textWriteService;

        public TextsController(ITextsWriteService textWriteService)
        {
            _textWriteService = textWriteService;
        }

        [HttpPost]
        public async Task<ActionResult<TextRequestDTO>> Create(TextRequestDTO textDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _textWriteService.Create(textDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut]
        public async Task<ActionResult<TextRequestDTO>> Update(TextRequestDTO textDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _textWriteService.Update(textDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut("SoftDelete")]
        public async Task<ActionResult<TextRequestDTO>> SoftDelete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _textWriteService.SoftDelete(id);
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
            var result = await _textWriteService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }
    }
}
