using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.Entities
{
    public static class CategoryFake
    {
        public static Category GenerateFakeCategory()
        {
            var fakeCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Fake Category",
                Icon = "fa fa-folder",
                IdImage = Guid.NewGuid(),
                IdFatherCategory = Guid.NewGuid(),
            };

            return fakeCategory;
        }
    }

}
