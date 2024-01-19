using DBContext;
using DBContext.Base;
using FluentValidation;
using IWriteRepository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteRepository.Base
{
    public class BaseWriteRepository2<T> : IBaseWriteRepository2<T> where T : class
    {
        protected PatxiPersianasWriteAPIContext _dbContext;

        public IValidator<T> _validator { get; }

        protected BaseWriteRepository2(PatxiPersianasWriteAPIContext dbContext, IValidator<T> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public async Task Create(T entity) 
        {
            if (Validate(entity).Result)
            {
                _dbContext.Set<T>().Add(entity);
            }
            else
            {
                throw new ApplicationException("Validation failure in " + typeof(T).Name);
            }
        }

        public async Task Update(T entity)
        {
            if (Validate(entity).Result)
            {
                _dbContext.Set<T>().Update(entity);
            }
            else
            {
                throw new ApplicationException("Validation failure in " + typeof(T).Name);
            }
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task Detached(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }

        public async Task<IUnitOfWork> GetUnitOfWork()
        {
            return _dbContext;
        }

        public async Task Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task<bool> Validate(T entity)
        {
            return _validator.Validate(entity).IsValid;
        }
    }
}
