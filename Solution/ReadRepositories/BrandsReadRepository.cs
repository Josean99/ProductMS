using DBContext;
using EntityService.Model;
using IReadRepositories;
using Microsoft.EntityFrameworkCore;
using ReadRepositories.Base;

namespace ReadRepositories
{
    public class BrandsReadRepository : BaseReadRepository<Brand>, IBrandsReadRepository
    {
        public BrandsReadRepository(PatxiPersianasWriteAPIContext dbContext) : base(dbContext)
        {

        }
    }
}