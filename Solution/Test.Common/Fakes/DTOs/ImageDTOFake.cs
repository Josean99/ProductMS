using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.DTOs
{
    public static class ImageDTOFake
    {
        #region Response
            public static ImageResponseDTO GenerateFakeImageResponseDTO()
            {
                var fakeImageDTO = new ImageResponseDTO
                {
                    Id = Guid.NewGuid(),
                    Path = "path/to/image.jpg",
                    AlternativeText = "Fake Image",
                    FechaBaja = null
                };

                return fakeImageDTO;
            }
        #endregion

        #region Request
        public static ImageRequestDTO GenerateFakeImageRequestDTO()
        {
            var fakeImageDTO = new ImageRequestDTO
            {
                Id = Guid.NewGuid(),
                Path = "path/to/image.jpg",
                AlternativeText = "Fake Image",
                FechaBaja = null
            };

            return fakeImageDTO;
        }

        #endregion
    }
}
