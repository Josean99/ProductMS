using DBContext;
using EntityService.Model;
using FluentValidation;
using IWriteRepository;
using Microsoft.EntityFrameworkCore;
using WriteRepository.Base;

namespace WriteRepository
{
    public class ProductsImagesWriteRepository : BaseWriteRepository<ProductImage>, IProductsImagesWriteRepository
    {

        public ProductsImagesWriteRepository(PatxiPersianasWriteAPIContext dbContext, IValidator<Image> validator) : base(dbContext, validator)
        {

        }

    }
}