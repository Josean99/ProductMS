using ExternalServices.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Infrastructure.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IJwtService jwtService,
            IConfiguration configuration
            ) : base(options, logger, encoder, clock)
        {
            _jwtService = jwtService;
            _configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                string user = credentials[0];
                string password = credentials[1];
                string jwtToken = _jwtService.Login(new Jwt.Services.DTOs.LoginUserDto() { UserName = user, Password = password });
                Response.Headers.Add("BearerToken", jwtToken);

                List<string> methods = _jwtService.GetAllowedMethods(new Jwt.Services.DTOs.GetAllowedMethodsDto() { token = jwtToken, idMicroservice = Guid.Parse(_configuration.GetSection("Authority:MicroserviceId").Value) });
                string methodsJson = JsonConvert.SerializeObject(methods);
                var claims = new[] {
                    new Claim("AllowedMethods", methodsJson)
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);                

                return AuthenticateResult.Success(ticket);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 401;
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
            }
            
            
        }
    }
}
