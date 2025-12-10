using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using IReadBusinessLayer;
using Microsoft.AspNetCore.Authorization;

namespace ProductsReadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesReadService _categoriesReadService;

        public CategoriesController(IMapper mapper, ICategoriesReadService categoriesReadService)
        {
            _mapper = mapper;
            _categoriesReadService = categoriesReadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await _categoriesReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resultado = await _categoriesReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }

        [HttpGet]
        [Route("GetBreadcrumb/{id}")]
        public async Task<IActionResult> GetBreadcrumb(Guid id)
        {
            var resultado = await _categoriesReadService.GetBreadCrumb(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }

        [HttpGet]
        [Route("GetIncluded")]
        public async Task<IActionResult> GetIncluded()
        {
            var resultado = await _categoriesReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }


        [HttpGet]
        [Route("GetIncluded/{id}")]
        public async Task<IActionResult> GetIncluded(Guid id)
        {
            var resultado = await _categoriesReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }
    }
}
