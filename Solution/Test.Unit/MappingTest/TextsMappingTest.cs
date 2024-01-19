using AutoMapper;
using DTOs.ResponseDTOs;
using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Configuration;
using Test.Common.Fakes.DTOs;
using Test.Common.Fakes.Entities;

namespace Test.Unit.MappingTest
{
    [Trait("Category", "Mapping")]
    public class TextDTOMappingTest
    {
        private readonly IMapper _mapper;

        public TextDTOMappingTest()
        {
            var mapperConfiguration = AutoMapperConfiguration.Configure();
            _mapper = mapperConfiguration.CreateMapper();
        }

        #region Response
            [Fact]
            public void TextToTextDTO()
            {
                var source = TextFake.GenerateFakeText();

                var destination = _mapper.Map<TextResponseDTO>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Code, source.Code);
                Assert.Equal(destination.Value, source.Value);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }

        #endregion

        #region Request
            [Fact]
            public void TextDTOToText()
            {
                var source = TextDTOFake.GenerateFakeTextRequestDTO();

                var destination = _mapper.Map<Text>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Code, source.Code);
                Assert.Equal(destination.Value, source.Value);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion



    }
}
