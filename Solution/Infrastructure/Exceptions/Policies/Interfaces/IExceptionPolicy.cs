using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Policies.Interfaces
{
    public interface IExceptionPolicy
    {
        Exception ApplyPolicy(Exception sourceException);
    }
}
