using Infrastructure.Exceptions.Entities;
using Infrastructure.Exceptions.Policies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Policies
{
    public class SanitizeAllExceptionPolicy : IExceptionPolicy
    {
        public Exception ApplyPolicy(Exception sourceException)
        {
            throw new GenericException(sourceException);
        }
    }
}
