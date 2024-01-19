using Infrastructure.Exceptions.Policies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Policies
{
    public class DoNotSanitizeExceptionPolicy : IExceptionPolicy
    {
        public Exception ApplyPolicy(Exception sourceException)
        {
            throw sourceException;
        }
    }
}
