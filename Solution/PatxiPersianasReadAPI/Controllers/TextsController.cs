using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using IReadBusinessLayer;

namespace ProductsReadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITextsReadService _textsReadService;

        public TextsController(IMapper mapper, ITextsReadService textsReadService)
        {
            _mapper = mapper;
            _textsReadService = textsReadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await _textsReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resultado = await _textsReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }

        [HttpGet]
        [Route("GetIncluded")]
        public async Task<IActionResult> GetIncluded()
        {
            var resultado = await _textsReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }


        [HttpGet]
        [Route("GetIncluded/{id}")]
        public async Task<IActionResult> GetIncluded(Guid id)
        {
            var resultado = await _textsReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }
    }
}
