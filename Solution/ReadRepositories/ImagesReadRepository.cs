using DBContext;
using EntityService.Model;
using IReadRepositories;
using Microsoft.EntityFrameworkCore;
using ReadRepositories.Base;

namespace ReadRepositories
{
    public class ImagesReadRepository : BaseReadRepository<Image>, IImagesReadRepository
    {
        private readonly PatxiPersianasWriteAPIContext _dbContext;

        public ImagesReadRepository(PatxiPersianasWriteAPIContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<List<Image>> GetByGuids(List<Guid> guids)
        //{
        //    return await _dbContext.Images.Where(b => guids.Contains(b.Id)).ToListAsync();
        //}

    }
}