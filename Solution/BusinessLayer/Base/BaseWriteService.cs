using AutoMapper;
using EntityService.Base;
using IReadBusinessLayer.Base;
using IReadRepositories.Base;
using IWriteRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadRepositories.Base
{
    //public class BaseWriteService 
    //{
    //    private readonly IBaseWriteRepository _repository;
    //    private readonly IMapper _mapper;

    //    public BaseWriteService(IBaseWriteRepository repository, IMapper mapper)
    //    {
    //        _repository = repository;
    //        this._mapper = mapper;
    //    }

    //    public async Task<TT> Create<T,TT>(TT dto) where T : class  where TT : class
    //    {
    //        T entity = _mapper.Map<TT, T>(dto);
    //        await _repository.Create(entity);
    //        await _repository.Save();
    //        return dto;
    //    }

    //    public async Task<TT> SoftDelete<T, TT>(TT dto) where T : class where TT : class
    //    {
    //        T entity = _mapper.Map<TT, T>(dto);
    //        await _repository.Update(entity);
    //        await _repository.Save();
    //        return dto;
    //    }

    //    public async Task<TT> Update<T, TT>(TT dto) where T : BaseEntity where TT : class
    //    {
    //        T entity = _mapper.Map<TT, T>(dto);
    //        entity.FechaBaja = DateTime.Now;
    //        await _repository.Update(entity);
    //        await _repository.Save();
    //        return dto;
    //    }

    //    public async Task<TT> Delete<T,TT>(TT dto) where T : BaseEntity where TT : class
    //    {
    //        T entity = _mapper.Map<TT, T>(dto);
    //        await _repository.Delete(entity);
    //        await _repository.Save();
    //        return dto;
    //    }
    //}
}
