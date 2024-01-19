using Infrastructure.Exceptions.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Entities
{
    [Serializable]
    public abstract class AbstractCustomException : Exception
    {
        public abstract Priority Priority { get; }
        protected AbstractCustomException()
        {

        }

        public AbstractCustomException(string message)
            : base(message)
        {

        }
        
        public AbstractCustomException(Exception exception)
            : base(exception.Message, exception)
        {

        }
        
        public AbstractCustomException(SerializationInfo info, StreamingContext context)
            : base(info,context)
        {

        }
    }
}
