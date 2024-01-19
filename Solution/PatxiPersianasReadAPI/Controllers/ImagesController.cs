using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using IReadBusinessLayer;

namespace ProductsReadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IImagesReadService _imagesReadService;

        public ImagesController(IMapper mapper, IImagesReadService imagesReadService)
        {
            _mapper = mapper;
            _imagesReadService = imagesReadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await _imagesReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resultado = await _imagesReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }

        [HttpGet]
        [Route("GetIncluded")]
        public async Task<IActionResult> GetIncluded()
        {
            var resultado = await _imagesReadService.GetAll();
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }


        [HttpGet]
        [Route("GetIncluded/{id}")]
        public async Task<IActionResult> GetIncluded(Guid id)
        {
            var resultado = await _imagesReadService.Get(id);
            return resultado is not null ? Ok(resultado) : (IActionResult)NoContent();
        }
    }
}
