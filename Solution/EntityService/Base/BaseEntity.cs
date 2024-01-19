using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityService.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
