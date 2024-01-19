using EntityService.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityService.Model
{
    public class Image : BaseEntity
    {
        public string Path { get; set; } = "";
        public string AlternativeText { get; set; } = "";

        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
