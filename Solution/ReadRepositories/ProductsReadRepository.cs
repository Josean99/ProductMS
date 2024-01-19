using DBContext;
using EntityService.Model;
using IReadRepositories;
using Microsoft.EntityFrameworkCore;
using ReadRepositories.Base;

namespace ReadRepositories
{
    public class ProductsReadRepository : BaseReadRepository<Product>, IProductsReadRepository
    {
        private readonly PatxiPersianasWriteAPIContext _dbContext;
        public ProductsReadRepository(PatxiPersianasWriteAPIContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}