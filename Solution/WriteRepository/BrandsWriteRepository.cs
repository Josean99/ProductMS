using DBContext;
using EntityService.Model;
using FluentValidation;
using IWriteRepository;
using IWriteRepository.Base;
using Microsoft.EntityFrameworkCore;
using WriteRepository.Base;

namespace WriteRepository
{
    public class BrandsWriteRepository : BaseWriteRepository<Brand>, IBrandsWriteRepository
    {

        public BrandsWriteRepository(PatxiPersianasWriteAPIContext dbContext, IValidator<Brand> validator) : base(dbContext, validator)
        {

        }

    }
}