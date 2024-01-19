using DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Unit.DALTest
{
    [Trait("Category", "BLL")]
    public class BaseWriteRepositoryTest
    {
        private readonly ProductsAPIContext _context;

        public BaseWriteRepositoryTest()
        {
            //DbContextOptionsBuilder dbOptions = new DbContextOptionsBuilder()
            //    .UseInMemoryDatabase();
        }

        
    }
}
