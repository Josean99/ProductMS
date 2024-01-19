using ExternalServices.Interfaces;
using Jwt.Services.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ExternalServices.Implementation
{
    public class JwtService : IJwtService
    {
        public IConfiguration _configuration { get; }

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Login(LoginUserDto userLogin)
        {
            var jsonData = JsonConvert.SerializeObject(userLogin);
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_configuration.GetSection("Services:Jwt").Value);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(httpClient.BaseAddress + "api/Login", content).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public List<string> GetAllowedMethods(GetAllowedMethodsDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_configuration.GetSection("Services:Jwt").Value);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(httpClient.BaseAddress + "api/Login/GetAllowedMethods", content).Result;
                return JsonConvert.DeserializeObject<List<string>>(response.Content.ReadAsStringAsync().Result);
            }
        }

    }
}