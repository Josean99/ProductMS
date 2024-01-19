using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.Entities
{
    public static class BrandFake
    {
        public static Brand GenerateFakeBrand()
        {
            var fakeBrand = new Brand
            {
                Id = Guid.NewGuid(),
                Name = "Fake Brand",
                Description = "This is a fake brand",
                IdImage = Guid.NewGuid()
            };

            return fakeBrand;
        }

        public static Brand FakeBrand_1()
        {
            var fakeBrandDTO = new Brand
            {
                Id = Guid.Parse("a60c220d-b614-4b7d-8c10-8d702387acba"),
                Name = "Fake Brand",
                Description = "This is a fake brand",
                IdImage = Guid.Parse("22f391ac-f958-4c66-b2fd-5a76199acbd7"),
                FechaBaja = DateTime.Today
            };

            return fakeBrandDTO;
        }
    }

}
