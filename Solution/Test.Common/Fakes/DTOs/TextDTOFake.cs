using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.DTOs
{
    public static class TextDTOFake
    {
        #region Response
            public static TextResponseDTO GenerateFakeTextResponseDTO()
            {
                var fakeTextDTO = new TextResponseDTO
                {
                    Id = Guid.NewGuid(),
                    Code = "FakeCode",
                    Value = "Fake Text",
                    FechaBaja = null
                };

                return fakeTextDTO;
            }
        #endregion

        #region Request
            public static TextRequestDTO GenerateFakeTextRequestDTO()
            {
                var fakeTextDTO = new TextRequestDTO
                {
                    Id = Guid.NewGuid(),
                    Code = "FakeCode",
                    Value = "Fake Text",
                    FechaBaja = null
                };

                return fakeTextDTO;
            }
        #endregion
    }
}
