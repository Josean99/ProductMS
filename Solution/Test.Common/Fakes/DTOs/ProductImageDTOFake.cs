using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;

namespace Test.Common.Fakes.DTOs
{
    public static class ProductImageDTOFake
    {
        #region Response
            public static List<ProductImageResponseDTO> GenerateFakeProductImagesResponseDTO()
            {
                var fakeProductImagesDTO = new List<ProductImageResponseDTO>
                {
                    new ProductImageResponseDTO
                    {
                        Id = Guid.NewGuid(),
                        Priority = 1,
                        IdProduct = Guid.NewGuid(),
                        IdImage = Guid.NewGuid(),
                        FechaBaja = null,
                    },
                    new ProductImageResponseDTO
                    {
                        Id = Guid.NewGuid(),
                        Priority = 2,
                        IdProduct = Guid.NewGuid(),
                        IdImage = Guid.NewGuid(),
                        FechaBaja = null,
                    }
                };

                return fakeProductImagesDTO;
            }
        #endregion

        #region Request
        public static List<ProductImageRequestDTO> GenerateFakeProductImagesRequestDTO()
        {
            var fakeProductImagesDTO = new List<ProductImageRequestDTO>
                {
                    new ProductImageRequestDTO
                    {
                        Id = Guid.NewGuid(),
                        Priority = 1,
                        IdProduct = Guid.NewGuid(),
                        IdImage = Guid.NewGuid(),
                        FechaBaja = null,
                    },
                    new ProductImageRequestDTO
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

        public static List<ProductImageRequestDTO> InsProductImagesRequestDTO_1()
        {
            var fakeProductImagesDTO = new List<ProductImageRequestDTO>
                {
                    new ProductImageRequestDTO
                    {
                        Id = null,
                        Priority = 1,
                        IdProduct = null,
                        IdImage = Guid.Parse("05245c24-6e1c-4d62-97e8-0d377b5579e7"),
                        FechaBaja = null,
                    },
                    new ProductImageRequestDTO
                    {
                        Id = null,
                        Priority = 2,
                        IdProduct = null,
                        IdImage = Guid.Parse("42236d70-4bb8-4d60-b636-df3e9504b346"),
                        FechaBaja = DateTime.Now,
                    }
                };

            return fakeProductImagesDTO;
        }

        public static List<ProductImageRequestDTO> InsProductImagesRequestDTO_2()
        {
            var fakeProductImagesDTO = new List<ProductImageRequestDTO>
                {
                    new ProductImageRequestDTO
                    {
                        Id = null,
                        Priority = 1,
                        IdProduct = null,
                        IdImage = Guid.Parse("6c4c227d-5911-4b43-8d8a-6dbd97e0ab71"),
                        FechaBaja = null,
                    },
                    new ProductImageRequestDTO
                    {
                        Id = null,
                        Priority = 2,
                        IdProduct = null,
                        IdImage = Guid.Parse("7ee532aa-bbd9-419f-89a9-52d8336e4c35"),
                        FechaBaja = DateTime.Now,
                    }
                };

            return fakeProductImagesDTO;
        }
        #endregion
    }
}
