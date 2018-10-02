using SnipCodeAPI.Models;

namespace SnipCodeAPI.Services.Interfaces
{
    public interface IAuthService
    {
        User Authenticate(LoginViewModel login);
    }
}