using Infrastructure.Exceptions.Entities;
using Infrastructure.Exceptions.Policies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Policies
{
    public class SanitizeNotCustomExceptionPolicy : IExceptionPolicy
    {
        public Exception ApplyPolicy(Exception sourceException)
        {
            if (!(sourceException is CustomException))
            {
                return new GenericException(sourceException);
            }
            else
            {
                return sourceException;
            }
        }
    }
}
