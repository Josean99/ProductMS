using AutoMapper;
using DTOs.Mappers;
using DTOs.RequestDTOs;
using DTOs.ResponseDTOs;
using EntityService.Model;
using IReadRepositories.Base;
using Moq;
using ReadBusinessLayer;
using System.Linq.Expressions;
using Test.Common.Configuration;
using Test.Common.Fakes.DTOs;
using Test.Common.Fakes.Entities;
using Xunit;

namespace Test.Unit.MappingTest
{
    [Trait("Category", "Mapping")]
    public class BrandsValidatorTest
    {
        private readonly IMapper _mapper;

        public BrandsValidatorTest()
        {            
            var mapperConfiguration = AutoMapperConfiguration.Configure();
            _mapper = mapperConfiguration.CreateMapper();
        }

        #region Response
            [Fact]
            public void BrandToBrandResponseDTO()
            {
                var source = BrandFake.GenerateFakeBrand();

                var destination = _mapper.Map<BrandResponseDTO>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Name, source.Name);
                Assert.Equal(destination.IdImage, source.IdImage);
                Assert.Equal(destination.Description, source.Description);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion

        #region Request
            [Fact]
            public void BrandRequestDTOToBrand()
            {
                var source = BrandDTOFake.GenerateFakeBrandRequestDTO();

                var destination = _mapper.Map<BrandRequestDTO>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Name, source.Name);
                Assert.Equal(destination.IdImage, source.IdImage);
                Assert.Equal(destination.Description, source.Description);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion


    }
}