using DBContext;
using IReadRepositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadRepositories.Base
{
    public class BaseReadRepository<T> : IBaseReadReposiory<T> where T : class
    {
        private readonly PatxiPersianasWriteAPIContext _dbContext;
        public BaseReadRepository(PatxiPersianasWriteAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> expression) 
        {
            return _dbContext.Set<T>().AsNoTracking().Where(expression);
        }

        public async Task<T> GetFirstByCondition(Expression<Func<T, bool>> expression) 
        {
            return _dbContext.Set<T>().AsNoTracking().First(expression);
        }

        public async Task<IQueryable<T>> GetAll() 
        {
            return _dbContext.Set<T>().AsNoTracking();
        }
    }
}
