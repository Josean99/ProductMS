using Infrastructure.Exceptions.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Entities
{
    [Serializable]
    public class GenericException : AbstractCustomException
    {
        public Guid Guid { get; set; }

        public GenericException(Exception exception) : base(exception)
        {
            Guid = Guid.NewGuid();
        }

        public override string Message
        {
            get
            {
                return String.Format("", Guid);
            }
        }

        public override Priority Priority
        {
            get
            {
                return Priority.Low;
            }
        }

        public override string ToString()
        {
            return "Exception GUID: " + Guid + Environment.NewLine + base.ToString();
        }
    }
}
