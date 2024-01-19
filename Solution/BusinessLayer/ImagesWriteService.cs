using AutoMapper;
using EntityService.Model;
using IWriteBusinessLayer;
using IReadRepositories;
using IWriteRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using IWriteRepository.Base;
using IReadRepositories.Base;
using ReadRepositories.Base;
using DTOs.RequestDTOs;
using Infrastructure.WebApiServices.Results;

namespace WriteBusinessLayer
{
    public class ImagesWriteService : IImagesWriteService
    {
        private readonly IBaseWriteRepository<Image> _baseWriteRepository;
        private readonly IBaseReadRepository _baseReadRepository;
        private readonly IMapper _mapper;
        public ImagesWriteService(
                                IBaseWriteRepository<Image> baseWriteRepository,
                                IBaseReadRepository baseReadRepository,
                                IMapper mapper)
        {
            _baseWriteRepository = baseWriteRepository;
            _baseReadRepository = baseReadRepository;
            _mapper = mapper;
        }

        public async Task<Result<ImageRequestDTO>> Create(ImageRequestDTO dto)
        {
            Image entity = _mapper.Map<ImageRequestDTO, Image>(dto);
            await _baseWriteRepository.Create(entity);
            await _baseWriteRepository.Save();
            await _baseWriteRepository.Detached(entity);
            ImageRequestDTO result = _mapper.Map<Image, ImageRequestDTO>(entity);
            return new Result<ImageRequestDTO>().Ok(result);
        }

        public async Task<Result<ImageRequestDTO>> Update(ImageRequestDTO dto)
        {
            Image entity = _mapper.Map<ImageRequestDTO, Image>(dto);
            entity.FechaBaja = DateTime.Now;
            await _baseWriteRepository.Update(entity);
            await _baseWriteRepository.Save();
            await _baseWriteRepository.Detached(entity);
            ImageRequestDTO result = _mapper.Map<Image, ImageRequestDTO>(entity);
            return new Result<ImageRequestDTO>().Ok(result);
        }

        public async Task<Result<ImageRequestDTO>> SoftDelete(Guid id)
        {
            Image entity = await _baseReadRepository.GetFirstByCondition<Image>(p => p.Id == id);
            entity.FechaBaja = DateTime.Now;
            await _baseWriteRepository.Update(entity);
            await _baseWriteRepository.Save();
            await _baseWriteRepository.Detached(entity);
            ImageRequestDTO result = _mapper.Map<Image, ImageRequestDTO>(entity);
            return new Result<ImageRequestDTO>().Ok(result);
        }

        public async Task<Result<Guid>> Delete(Guid id)
        {
            Image entity = await _baseReadRepository.GetFirstByCondition<Image>(x => x.Id == id);
            await _baseWriteRepository.Delete(entity);
            await _baseWriteRepository.Save();
            await _baseWriteRepository.Detached(entity);
            return new Result<Guid>().Ok(id);
        }

    }
}