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
    public class ProductMappingTest
    {
        private readonly IMapper _mapper;

        public ProductMappingTest()
        {
            var mapperConfiguration = AutoMapperConfiguration.Configure();
            _mapper = mapperConfiguration.CreateMapper();
        }

        #region Response
            [Fact]
            public void ProductToProductDTO()
            {
                var source = ProductFake.GenerateFakeProduct();

                var destination = _mapper.Map<ProductResponseDTO>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Name, source.Name);
                Assert.Equal(destination.Description, source.Description);
                Assert.Equal(destination.IdCategory, source.IdCategory);
                Assert.Equal(destination.IdBrand, source.IdBrand);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion

        #region Request
            [Fact]
            public void ProductDTOToProduct()
            {
                var source = ProductDTOFake.GenerateFakeProductRequestDTO();

                var destination = _mapper.Map<Product>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Name, source.Name);
                Assert.Equal(destination.Description, source.Description);
                Assert.Equal(destination.IdCategory, source.IdCategory);
                Assert.Equal(destination.IdBrand, source.IdBrand);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion

    }
}
