using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext.Base
{
    public interface IUnitOfWork
    {
        void Save();

        IDbContextTransaction GetTransaction();
    }
}
