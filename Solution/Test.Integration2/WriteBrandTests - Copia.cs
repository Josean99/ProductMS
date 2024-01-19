using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using DTOs.RequestDTOs;
using Test.Integration.Utils;

namespace Test.Integration
{
    
    public class BrandsControllerIntegrationTest 
    {
        

        private readonly IHttpClientFactory _serviceProvider;
        private readonly HttpClient _client;

        public BrandsControllerIntegrationTest()
        {
            _client = _serviceProvider.CreateClient();
        }

        [Test]
        public async Task CreateUpdateSoftDeleteDelete_Brand()
        {
            // Crea un objeto BrandRequestDTO para las pruebas
            var brand = new BrandRequestDTO
            {
                // Configura las propiedades del objeto BrandRequestDTO para las pruebas
            };

            // Realiza la prueba de creación
            var createResponse = await _client.PostAsJsonAsync("/api/brands", brand);
            Assert.AreEqual(HttpStatusCode.OK, createResponse.StatusCode);
            var createdBrand = await createResponse.Content.ReadFromJsonAsync<BrandRequestDTO>();

            // Realiza la prueba de actualización
            createdBrand.Description = "New Description";
            var updateResponse = await _client.PutAsJsonAsync("/api/brands", createdBrand);
            Assert.AreEqual(HttpStatusCode.OK, updateResponse.StatusCode);
            var updatedBrand = await updateResponse.Content.ReadFromJsonAsync<BrandRequestDTO>();
            Assert.AreEqual("New Description", updatedBrand.Description);

            // Realiza la prueba de eliminación suave (soft delete)
            var softDeleteResponse = await _client.PutAsync($"/api/brands/SoftDelete?id={updatedBrand.Id}", null);
            Assert.AreEqual(HttpStatusCode.OK, softDeleteResponse.StatusCode);

            // Realiza la prueba de eliminación
            var deleteResponse = await _client.DeleteAsync($"/api/brands/Delete?id={updatedBrand.Id}");
            Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);
            var deletedBrandId = await deleteResponse.Content.ReadFromJsonAsync<Guid>();

            // Realiza aserciones adicionales según sea necesario
        }
    }
}
