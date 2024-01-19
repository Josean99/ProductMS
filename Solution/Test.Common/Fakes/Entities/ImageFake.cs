using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.Entities
{
    public static class ImageFake
    {
        public static Image GenerateFakeImage()
        {
            var fakeImage = new Image
            {
                Id = Guid.NewGuid(),
                Path = "path/to/image.jpg",
                AlternativeText = "Fake Image"
            };

            return fakeImage;
        }
    }

}
