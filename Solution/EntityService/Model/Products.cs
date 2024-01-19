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
    public class Product : BaseEntity
    {
        public string Name { get; set; } = "";        
        public string Description { get; set; } = "";
        public Guid IdCategory { get; set; }
        public Guid IdBrand { get; set; }

        public Brand Brand { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }

    }
}
