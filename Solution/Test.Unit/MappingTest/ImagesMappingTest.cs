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
    public class ImagesMappingTest
    {
        private readonly IMapper _mapper;

        public ImagesMappingTest()
        {
            var mapperConfiguration = AutoMapperConfiguration.Configure();
            _mapper = mapperConfiguration.CreateMapper();
        }

        #region Response
            [Fact]
            public void ImageToImageDTO()
            {
                var source = ImageFake.GenerateFakeImage();

                var destination = _mapper.Map<ImageResponseDTO>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Path, source.Path);
                Assert.Equal(destination.AlternativeText, source.AlternativeText);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion

        #region Request
            [Fact]
            public void ImageRequestDTOToImage()
            {
                var source = ImageDTOFake.GenerateFakeImageRequestDTO();

                var destination = _mapper.Map<Image>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Path, source.Path);
                Assert.Equal(destination.AlternativeText, source.AlternativeText);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion

    }
}
