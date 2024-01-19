using DBContext;
using EntityService.Model;
using IReadRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ReadRepositories.Base;

namespace ReadRepositories
{
    public class CategoriesReadRepository : BaseReadRepository, ICategoriesReadRepository
    {
        public ProductMSReadAPIContext _dbContext { get; }
        public CategoriesReadRepository(ProductMSReadAPIContext dbContext, IMemoryCache cache) : base(dbContext, cache)
        {
            _dbContext = dbContext;
        }

        public async Task<Dictionary<int, Category>> GetBreadCrumb(Guid sonCategoryId)
        {
            var result = new Dictionary<int, Category>();

            var categories = await _dbContext.Categories.Include(c => c.FatherCategory).ToListAsync();
            var sonCategory = new Category();

            var cont = 0;
            do
            {
                sonCategory = categories.First(c => c.Id == sonCategoryId);
                result.Add(cont, sonCategory);
                if (sonCategory.IdFatherCategory.HasValue)
                {
                    sonCategoryId = sonCategory.IdFatherCategory.Value;
                }
                cont++;
            } while (sonCategory.IdFatherCategory.HasValue);

            return result;
        }

        //public async Task<Dictionary<int, Category>> GetBreadCrumb(Guid sonCategoryId)
        //{
        //    var result = new Dictionary<int, Category>();
        //    var listaResultados = new List<Category>();

        //    var categories = _dbContext.Categories;

        //    var sonCategory = categories.First(c => c.Id == sonCategoryId);            

        //    do
        //    {
        //        listaResultados.Add(sonCategory);
        //        sonCategory = categories.First(c => c.Id == sonCategory.IdFatherCategory);
        //    } while (sonCategory.IdFatherCategory.HasValue);

        //    listaResultados.Reverse();

        //    var cont = 0;
        //    foreach (var item in listaResultados)
        //    {
        //        result.Add(cont, item);
        //        cont++;
        //    }

        //    return result;
        //}
    }
}