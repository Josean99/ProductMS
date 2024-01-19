using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.DTOs
{
    public static class BrandDTOFake
    {
        #region Response
            public static BrandResponseDTO GenerateFakeBrandResponseDTO()
            {
                var fakeBrandDTO = new BrandResponseDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "Fake Brand",
                    Description = "This is a fake brand",
                    IdImage = Guid.NewGuid(),
                    FechaBaja = DateTime.Now
                };

                return fakeBrandDTO;
            }

            public static BrandResponseDTO FakeBrandResponseDTO_1()
            {
                var fakeBrandDTO = new BrandResponseDTO
                {
                    Id = Guid.Parse("a60c220d-b614-4b7d-8c10-8d702387acba"),
                    Name = "Fake Brand",
                    Description = "This is a fake brand",
                    IdImage = Guid.Parse("22f391ac-f958-4c66-b2fd-5a76199acbd7"),
                    FechaBaja = DateTime.Today
                };

                return fakeBrandDTO;
            }
        #endregion

        #region Request
        public static BrandRequestDTO GenerateFakeBrandRequestDTO()
        {
            var fakeBrandDTO = new BrandRequestDTO
            {
                Id = Guid.NewGuid(),
                Name = "Fake Brand",
                Description = "This is a fake brand",
                IdImage = Guid.NewGuid(),
                FechaBaja = DateTime.Now
            };

            return fakeBrandDTO;
        }

        public static BrandRequestDTO FakeBrandRequestDTO_1()
        {
            var fakeBrandDTO = new BrandRequestDTO
            {
                Id = Guid.Parse("a60c220d-b614-4b7d-8c10-8d702387acba"),
                Name = "Fake Brand",
                Description = "This is a fake brand",
                IdImage = Guid.Parse("22f391ac-f958-4c66-b2fd-5a76199acbd7"),
                FechaBaja = DateTime.Today
            };

            return fakeBrandDTO;
        }

        public static BrandRequestDTO InsBrandRequestDTO_1()
        {
            var fakeBrandDTO = new BrandRequestDTO
            {
                Id = null,
                Name = "Fake Brand",
                Description = "This is a fake brand",
                IdImage = Guid.Parse("05245c24-6e1c-4d62-97e8-0d377b5579e7"),
                FechaBaja = null
            };

            return fakeBrandDTO;
        }
        #endregion
    }
}
