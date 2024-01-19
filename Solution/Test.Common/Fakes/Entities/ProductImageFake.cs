using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.Entities
{
    public static class ProductImageFake
    {
        public static ProductImage GenerateFakeProductImage()
        {
            var fakeProductImage = new ProductImage
            {
                Id = Guid.NewGuid(),
                Priority = 1,
                IdProduct = Guid.NewGuid(),
                IdImage = Guid.NewGuid()
            };

            return fakeProductImage;
        }

        public static List<ProductImage> GenerateFakeProductImages()
        {
            var fakeProductImagesDTO = new List<ProductImage>
            {
                new ProductImage
                {
                    Id = Guid.NewGuid(),
                    Priority = 1,
                    IdProduct = Guid.NewGuid(),
                    IdImage = Guid.NewGuid(),
                    FechaBaja = null,
                },
                new ProductImage
                {
                    Id = Guid.NewGuid(),
                    Priority = 2,
                    IdProduct = Guid.NewGuid(),
                    IdImage = Guid.NewGuid(),
                    FechaBaja = DateTime.Now,
                }
            };

            return fakeProductImagesDTO;
        }
    }

}
