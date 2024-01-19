using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Manager
{
    public interface IExceptionManager
    {
        Task<Exception> HandleException(HttpContext context, Exception ex);
    }
}
