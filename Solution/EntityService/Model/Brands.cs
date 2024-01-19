using EntityService.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityService.Model
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Guid IdImage { get; set; }

        public Image Image { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        
    }
}
