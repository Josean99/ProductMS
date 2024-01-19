using DBContext;
using EntityService.Model;
using IReadRepositories;
using Microsoft.EntityFrameworkCore;
using ReadRepositories.Base;

namespace ReadRepositories
{
    public class ProductsImagesReadRepository : BaseReadRepository<ProductImage>, IProductsImagesReadRepository
    {
        private readonly PatxiPersianasWriteAPIContext _dbContext;
        public ProductsImagesReadRepository(PatxiPersianasWriteAPIContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}