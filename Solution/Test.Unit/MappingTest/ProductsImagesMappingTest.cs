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
    public class ProductImageMappingTest
    {
        private readonly IMapper _mapper;

        public ProductImageMappingTest()
        {
            var mapperConfiguration = AutoMapperConfiguration.Configure();
            _mapper = mapperConfiguration.CreateMapper();
        }
        #region Response
            [Fact]
            public void ProductImageToProductImageDTO()
            {
                var source = ProductImageFake.GenerateFakeProductImage();

                var destination = _mapper.Map<ProductImageResponseDTO>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Priority, source.Priority);
                Assert.Equal(destination.IdProduct, source.IdProduct);
                Assert.Equal(destination.IdImage, source.IdImage);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion

        #region Request
            [Fact]
            public void ProductImageDTOToProductImage()
            {
                var source = ProductImageDTOFake.GenerateFakeProductImagesRequestDTO().First();

                var destination = _mapper.Map<ProductImage>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Priority, source.Priority);
                Assert.Equal(destination.IdProduct, source.IdProduct);
                Assert.Equal(destination.IdImage, source.IdImage);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion

    }

}
