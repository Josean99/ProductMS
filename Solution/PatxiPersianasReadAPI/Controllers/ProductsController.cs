using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using IReadBusinessLayer;

namespace ProductsReadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductsReadService _productsReadService;

        public ProductsController(IMapper mapper, IProductsReadService productsReadService)
        {
            _mapper = mapper;
            _productsReadService = productsReadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await _productsReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resultado = await _productsReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }

        [HttpGet]
        [Route("GetIncluded")]
        public async Task<IActionResult> GetIncluded()
        {
            var resultado = await _productsReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }


        [HttpGet]
        [Route("GetIncluded/{id}")]
        public async Task<IActionResult> GetIncluded(Guid id)
        {
            var resultado = await _productsReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }
    }
}
