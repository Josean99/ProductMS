using EntityService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IReadBusinessLayer.Base
{
    public interface IBaseReadService
    {
        Task<T> Get<T>(Guid id) where T : BaseEntity;
        Task<IQueryable<T>> GetAll<T>() where T : class;
    }
}
