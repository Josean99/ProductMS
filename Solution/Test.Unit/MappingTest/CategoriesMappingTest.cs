using AutoMapper;
using DTOs.ResponseDTOs;
using EntityService.Model;
using Test.Common.Configuration;
using Test.Common.Fakes.DTOs;
using Test.Common.Fakes.Entities;

namespace Test.Unit.MappingTest
{
    [Trait("Category", "Mapping")]
    public class CategoriesMappingTest
    {
        private readonly IMapper _mapper;

        public CategoriesMappingTest()
        {
            var mapperConfiguration = AutoMapperConfiguration.Configure();
            _mapper = mapperConfiguration.CreateMapper();
        }

        #region Response
            [Fact]
            public void CategoryToCategoryDTO()
            {
                var source = CategoryFake.GenerateFakeCategory();

                var destination = _mapper.Map<CategoryResponseDTO>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Name, source.Name);
                Assert.Equal(destination.Icon, source.Icon);
                Assert.Equal(destination.IdImage, source.IdImage);
                Assert.Equal(destination.IdFatherCategory, source.IdFatherCategory);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion

        #region Request
            [Fact]
            public void CategoryRequestDTOToCategory()
            {
                var source = CategoryDTOFake.GenerateFakeCategoryRequestDTO();

                var destination = _mapper.Map<Category>(source);

                Assert.NotNull(destination);
                Assert.Equal(destination.Id, source.Id);
                Assert.Equal(destination.Name, source.Name);
                Assert.Equal(destination.Icon, source.Icon);
                Assert.Equal(destination.IdImage, source.IdImage);
                Assert.Equal(destination.IdFatherCategory, source.IdFatherCategory);
                Assert.Equal(destination.FechaBaja, source.FechaBaja);
            }
        #endregion


    }
}
