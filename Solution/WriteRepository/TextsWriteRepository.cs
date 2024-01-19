using DBContext;
using EntityService.Model;
using FluentValidation;
using IWriteRepository;
using Microsoft.EntityFrameworkCore;
using WriteRepository.Base;

namespace WriteRepository
{
    public class TextsWriteRepository : BaseWriteRepository<Text>, ITextsWriteRepository
    {

        public TextsWriteRepository(PatxiPersianasWriteAPIContext dbContext, IValidator<Text> validator) : base(dbContext, validator)
        {

        }

    }
}