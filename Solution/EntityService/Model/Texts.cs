using EntityService.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityService.Model
{
    public class Text : BaseEntity
    {
        public string Code { get; set; } = "";
        public string Value { get; set; } = "";
    }
}
