using ExternalServices.Implementation;
using ExternalServices.Interfaces;
using Jwt.Services.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace Infrastructure.auth
{
    public class AccessHandler : AuthorizationHandler<AccessRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;

        public AccessHandler(IHttpContextAccessor httpContextAccessor, IJwtService jwtService, IConfiguration configuration)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _jwtService = jwtService;
            _configuration = configuration;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessRequirement requirement)
        {
            Claim? methodClaim = context.User.Claims.FirstOrDefault(c => c.Type == "AllowedMethods");
            Claim? rolesClaim = null;
            List<string> methods;
            if (methodClaim is null)
            {
                rolesClaim = context.User.Claims.FirstOrDefault(c => c.Type == "Roles");
                if (rolesClaim == null)
                {
                    context.Fail();
                    return Task.CompletedTask;
                }
                else
                {
                    List<Guid> roles = JsonConvert.DeserializeObject<List<Guid>>(rolesClaim.Value);
                    GetAllowedMethodsDto dto = new GetAllowedMethodsDto()
                    {
                        idMicroservice = Guid.Parse(_configuration.GetSection("Authority:MicroserviceId").Value),
                        token = this.httpContextAccessor.HttpContext.GetTokenAsync("Authorization").Result
                    };
                    methods = _jwtService.GetAllowedMethods(dto);
                    string methodsJson = String.Join(',', methods);
                    Claim claim = new Claim("AllowedMethods", methodsJson);
                    context.User.Claims.Append(claim);
                }
            }
            methods = JsonConvert.DeserializeObject<List<string>>(methodClaim.Value);
            string? controllerName = httpContextAccessor.HttpContext?.Request.RouteValues["controller"]?.ToString();
            string? actionName = httpContextAccessor.HttpContext?.Request.RouteValues["action"]?.ToString();

            if (controllerName != null && actionName != null)
            {
                var path = $"/api/{controllerName}/{actionName}";
                if (methods.Contains(path))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }

            return Task.CompletedTask;
        }
    }

    public class AccessRequirement : IAuthorizationRequirement
    {
        //public List<Method> Methods { get; }

        public AccessRequirement()
        {
            //Methods = methods;
        }
    }
}
