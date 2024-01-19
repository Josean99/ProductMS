using DBContext;
using IReadRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadRepositories.Base
{
    public class BaseReadRepository : IBaseReadRepository 
    {
        private readonly ProductMSReadAPIContext _dbContext;
        private readonly IMemoryCache _cache;

        public BaseReadRepository(ProductMSReadAPIContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<IQueryable<T>> GetByCondition<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : class
        {
            var query = _dbContext.Set<T>().AsNoTracking();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query.Where(expression);
        }

        public async Task<IList<T>> GetByConditionCache<T>(string cacheKey, Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (_cache.TryGetValue(cacheKey, out IList<T> query))
            {
                return query;
            }

            query = (await GetByCondition<T>(expression, includes)).ToList();
            _cache.Set(cacheKey, query);
            return query.ToList();
        }

        public async Task<T> GetFirstByCondition<T>(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : class
        {
            var query = _dbContext.Set<T>().AsNoTracking();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query.First(expression);
        }

        public async Task<T> GetFirstByConditionCache<T>(string cacheKey, Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (_cache.TryGetValue(cacheKey, out T query))
            {
                return query;
            }

            query = (await GetFirstByCondition<T>(expression, includes));
            _cache.Set(cacheKey, query);
            return query;
        }

        public async Task<IQueryable<T>> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            var query = _dbContext.Set<T>().AsNoTracking();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public async Task<IList<T>> GetAllCache<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            var cacheKey = CacheKeys.FindAll<T>();

            if (_cache.TryGetValue(cacheKey, out IList<T> query))
            {
                return query;
            }

            query = (await GetAll<T>()).ToList();
            _cache.Set(cacheKey, query);
            return query.ToList();
        }
    }
}
