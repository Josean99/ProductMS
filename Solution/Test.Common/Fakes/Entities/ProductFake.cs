using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.Entities
{
    public static class ProductFake
    {
        public static Product GenerateFakeProduct()
        {
            var fakeProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Fake Product",
                Description = "This is a fake product",
                IdCategory = Guid.NewGuid(),
                IdBrand = Guid.NewGuid()
            };

            return fakeProduct;
        }
    }

}
