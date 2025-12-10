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
    public class ImagesController : ControllerBase
    {
        private readonly IImagesWriteService _imagesWriteService;

        public ImagesController(IImagesWriteService imagesWriteService)
        {
            _imagesWriteService = imagesWriteService;
        }

        [HttpPost]
        public async Task<ActionResult<ImageRequestDTO>> Create(ImageRequestDTO imageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _imagesWriteService.Create(imageDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut]
        public async Task<ActionResult<ImageRequestDTO>> Update(ImageRequestDTO imageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _imagesWriteService.Update(imageDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }

        [HttpPut("SoftDelete")]
        public async Task<ActionResult<ImageRequestDTO>> SoftDelete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de Model State");
            }
            var result = await _imagesWriteService.SoftDelete(id);
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
            var result = await _imagesWriteService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessages);
        }
    }
}
