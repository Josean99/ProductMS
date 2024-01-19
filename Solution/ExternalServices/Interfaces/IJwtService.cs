using Jwt.Services.DTOs;

namespace ExternalServices.Interfaces
{
    public interface IJwtService
    {
        List<string> GetAllowedMethods(GetAllowedMethodsDto dto);
        string Login(LoginUserDto userLogin);
    }
}