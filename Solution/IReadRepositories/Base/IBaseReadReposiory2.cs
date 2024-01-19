using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IReadRepositories.Base
{
    public interface IBaseReadReposiory<T> where T : class
    {
        Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetFirstByCondition(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetAll();
    }
}
