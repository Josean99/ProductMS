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
    public class CustomException : AbstractCustomException
    {
        public override Priority Priority { 
            get 
            {
                return Priority.Medium;
            } 
        }

        public CustomException()
            : base()
        {

        }

        public CustomException(string message)
            : base(message)
        {

        }

        public CustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }


}
