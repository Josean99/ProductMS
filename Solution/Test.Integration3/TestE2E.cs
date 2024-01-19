using DTOs.RequestDTOs;
using System.Net;
using System.Net.Http.Json;
using System.Net.Http;
using Test.Integration.Utils;
using AutoMapper.Configuration.Annotations;

namespace Test.Integration
{
    public class BrandsControllerIntegrationTest
    {
        private readonly HttpClient _client;

        public BrandsControllerIntegrationTest()
        {
            _client = new() { BaseAddress = new Uri("https://localhost:7152") };
        }

        [Fact(Skip = "WIP")]
        public async Task CreateUpdateSoftDeleteDelete_Brand()
        {
            // Crea un objeto BrandRequestDTO para las pruebas
            var brand = new BrandRequestDTO
            {
                // Configura las propiedades del objeto BrandRequestDTO para las pruebas
            };

            // Realiza la prueba de creación
            var createResponse = await _client.PostAsJsonAsync("/api/brands", brand);
            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);
            var createdBrand = await createResponse.Content.ReadFromJsonAsync<BrandRequestDTO>();

            // Realiza la prueba de actualización
            createdBrand.Description = "New Description";
            var updateResponse = await _client.PutAsJsonAsync("/api/brands", createdBrand);
            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
            var updatedBrand = await updateResponse.Content.ReadFromJsonAsync<BrandRequestDTO>();
            Assert.Equal("New Description", updatedBrand.Description);

            // Realiza la prueba de eliminación suave (soft delete)
            var softDeleteResponse = await _client.PutAsync($"/api/brands/SoftDelete?id={updatedBrand.Id}", null);
            Assert.Equal(HttpStatusCode.OK, softDeleteResponse.StatusCode);

            // Realiza la prueba de eliminación
            var deleteResponse = await _client.DeleteAsync($"/api/brands/Delete?id={updatedBrand.Id}");
            Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
            var deletedBrandId = await deleteResponse.Content.ReadFromJsonAsync<Guid>();

            // Realiza aserciones adicionales según sea necesario
        }
    }
}