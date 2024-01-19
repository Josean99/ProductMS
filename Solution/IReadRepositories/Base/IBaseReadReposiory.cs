using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IReadRepositories.Base
{
    public interface IBaseReadRepository
    {
        Task<IQueryable<T>> GetByCondition<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : class;
        Task<IList<T>> GetByConditionCache<T>(string cacheKey, Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : class;

        Task<T> GetFirstByCondition<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : class;
        Task<T> GetFirstByConditionCache<T>(string cacheKey, Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : class;

        Task<IQueryable<T>> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : class;
        Task<IList<T>> GetAllCache<T>(params Expression<Func<T, object>>[] includes) where T : class;
    }
}
