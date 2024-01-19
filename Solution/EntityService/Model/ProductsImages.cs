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
    public class ProductImage : BaseEntity
    {
        public int Priority { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdImage { get; set; }   

        public Product Product { get; set; }
        public Image Image { get; set; }

    }
}
