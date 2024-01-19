using DBContext.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWriteRepository.Base
{
    public interface IBaseWriteRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IUnitOfWork> GetUnitOfWork();
        Task Detached(T entity);
        Task Save();
    }
}
