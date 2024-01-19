using DBContext;
using EntityService.Model;
using FluentValidation;
using IWriteRepository;
using Microsoft.EntityFrameworkCore;
using WriteRepository.Base;

namespace WriteRepository
{
    public class CategoriesWriteRepository : BaseWriteRepository<Category>, ICategoriesWriteRepository
    {
        public CategoriesWriteRepository(PatxiPersianasWriteAPIContext dbContext, IValidator<Category> validator) : base(dbContext, validator)
        {

        }

    }
}