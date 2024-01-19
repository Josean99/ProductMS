using DBContext;
using EntityService.Model;
using FluentValidation;
using IWriteRepository;
using Microsoft.EntityFrameworkCore;
using WriteRepository.Base;

namespace WriteRepository
{
    public class ProductsWriteRepository : BaseWriteRepository<Product>, IProductsWriteRepository
    {

        public ProductsWriteRepository(PatxiPersianasWriteAPIContext dbContext, IValidator<Product> validator) : base(dbContext, validator)
        {

        }

    }
}