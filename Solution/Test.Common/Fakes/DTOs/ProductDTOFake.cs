using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.DTOs
{
    public static class ProductDTOFake
    {
        #region Response
        public static ProductResponseDTO GenerateFakeProductResponseDTO()
        {
            var fakeProductDTO = new ProductResponseDTO
            {
                Id = Guid.NewGuid(),
                Name = "Fake Product",
                Description = "This is a fake product",
                IdCategory = Guid.NewGuid(),
                IdBrand = Guid.NewGuid(),
                FechaBaja = DateTime.Now
            };

            return fakeProductDTO;
        }
        #endregion

        #region Request
        public static ProductRequestDTO GenerateFakeProductRequestDTO()
            {
                var fakeProductDTO = new ProductRequestDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "Fake Product",
                    Description = "This is a fake product",
                    IdCategory = Guid.NewGuid(),
                    IdBrand = Guid.NewGuid(),
                    FechaBaja = DateTime.Now
                };

                return fakeProductDTO;
            }

        public static ProductWithImagesRequestDTO GenerateFakeProductWithImagesRequestDTO()
        {
            var fakeProductDTO = new ProductWithImagesRequestDTO
            {
                Id = Guid.NewGuid(),
                Name = "Fake Product",
                Description = "This is a fake product",
                IdCategory = Guid.NewGuid(),
                IdBrand = Guid.NewGuid(),
                FechaBaja = DateTime.Now,

                ProductImages = ProductImageDTOFake.GenerateFakeProductImagesRequestDTO()
            };

            return fakeProductDTO;
        }

        public static ProductRequestDTO InsProductRequestDTO_1()
        {
            var fakeProductDTO = new ProductRequestDTO
            {
                Id = Guid.NewGuid(),
                Name = "Fake Product",
                Description = "This is a fake product",
                IdCategory = Guid.Parse("1e27e0aa-b85d-47bb-b4c0-bf1a4f0e9754"),
                IdBrand = Guid.Parse("6ac1a388-3c9a-41c1-b550-4ea479ab2788"),
                FechaBaja = DateTime.Now
            };

            return fakeProductDTO;
        }

        public static ProductWithImagesRequestDTO InsProductRequestWithImagesDTO_1()
        {
            var fakeProductDTO = new ProductWithImagesRequestDTO
            {
                Id = null,
                Name = "Fake Product",
                Description = "This is a fake product",
                IdCategory = Guid.Parse("1e27e0aa-b85d-47bb-b4c0-bf1a4f0e9754"),
                IdBrand = Guid.Parse("6ac1a388-3c9a-41c1-b550-4ea479ab2788"),
                FechaBaja = DateTime.Now,

                ProductImages = ProductImageDTOFake.InsProductImagesRequestDTO_1()
            };

            return fakeProductDTO;
        }
        #endregion

    }
}
