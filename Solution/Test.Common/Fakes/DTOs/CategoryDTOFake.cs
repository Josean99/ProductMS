using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.DTOs
{
    public static class CategoryDTOFake
    {
        #region Response
            public static CategoryResponseDTO GenerateFakeCategoryResponseDTO()
            {
                var fakeCategoryDTO = new CategoryResponseDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "Fake Category",
                    Icon = "fa fa-folder",
                    IdImage = Guid.NewGuid(),
                    IdFatherCategory = Guid.NewGuid(),
                    FechaBaja = null
                };

                return fakeCategoryDTO;
            }
        #endregion

        #region Request
        public static CategoryRequestDTO GenerateFakeCategoryRequestDTO()
        {
            var fakeCategoryDTO = new CategoryRequestDTO
            {
                Id = Guid.NewGuid(),
                Name = "Fake Category",
                Icon = "fa fa-folder",
                IdImage = Guid.NewGuid(),
                IdFatherCategory = Guid.NewGuid(),
                FechaBaja = null
            };

            return fakeCategoryDTO;
        }

        public static CategoryRequestDTO InsCategoryRequestDTO_1()
        {
            var fakeCategoryDTO = new CategoryRequestDTO
            {
                Id = null,
                Name = "Fake Category",
                Icon = "fa fa-folder",
                IdImage = Guid.Parse("05245c24-6e1c-4d62-97e8-0d377b5579e7"),
                IdFatherCategory = Guid.Parse("1e27e0aa-b85d-47bb-b4c0-bf1a4f0e9754"),
                FechaBaja = null
            };

            return fakeCategoryDTO;
        }
        #endregion

    }
}
