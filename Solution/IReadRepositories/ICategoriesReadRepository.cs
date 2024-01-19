using EntityService.Model;
using IReadRepositories.Base;

namespace IReadRepositories
{
    public interface ICategoriesReadRepository : IBaseReadRepository
    {
        Task<Dictionary<int, Category>> GetBreadCrumb(Guid sonCategoryId);
    }
}