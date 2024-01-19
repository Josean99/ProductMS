using EntityService.Base;
using IReadBusinessLayer.Base;
using IReadRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadRepositories.Base
{
    public class BaseReadService 
    {
        private readonly IBaseReadRepository _repository;
        public BaseReadService(IBaseReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<T> Get<T>(Guid id) where T : BaseEntity
        {
            return await _repository.GetFirstByCondition<T>(t=>t.Id == id);
        }

        public async Task<IQueryable<T>> GetAll<T>() where T : class
        {
            return await _repository.GetAll<T>();
        }
    }
}
