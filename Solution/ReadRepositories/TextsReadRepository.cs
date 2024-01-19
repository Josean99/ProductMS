using DBContext;
using EntityService.Model;
using IReadRepositories;
using Microsoft.EntityFrameworkCore;
using ReadRepositories.Base;

namespace ReadRepositories
{
    public class TextsReadRepository : BaseReadRepository<Text>, ITextsReadRepository
    {

        public TextsReadRepository(PatxiPersianasWriteAPIContext dbContext) : base(dbContext)
        {

        }

    }
}