
using Microsoft.AspNetCore.Mvc;
using IReadBusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ProductsReadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Basic")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsReadService _brandReadService;

        public BrandsController(IBrandsReadService brandReadService)
        {
            _brandReadService = brandReadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var claims = User.Claims.ToList();
            var resultado = await _brandReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }

        [HttpGet("GetClaims")]
        public async Task<IActionResult> GetClaims()
        {
            var claims = User.Claims.ToList();
            return Ok(claims.Last().Value);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resultado = await _brandReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }

        [HttpGet]
        [Route("GetIncluded")]
        public async Task<IActionResult> GetIncluded()
        {
            var resultado = await _brandReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }


        [HttpGet]
        [Route("GetIncluded/{id}")]
        public async Task<IActionResult> GetIncluded(Guid id)
        {
            var resultado = await _brandReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }



    }
}
