using DBContext;
using EntityService.Model;
using FluentValidation;
using IWriteRepository;
using Microsoft.EntityFrameworkCore;
using WriteRepository.Base;

namespace WriteRepository
{
    public class ImagesWriteRepository : BaseWriteRepository<Image>, IImagesWriteRepository
    {

        public ImagesWriteRepository(PatxiPersianasWriteAPIContext dbContext, IValidator<Image> validator) : base(dbContext, validator)
        {

        }

    }
}