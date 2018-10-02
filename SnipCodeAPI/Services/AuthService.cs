using SnipCodeAPI.Models;
using SnipCodeAPI.Repositories.Interfaces;
using SnipCodeAPI.Services.Interfaces;

namespace SnipCodeAPI.Services
{
  public class AuthService : IAuthService
  {
    private IUserRepository userRepository;
    public AuthService(IUserRepository userRepositoryParam, ISeedService seedService)
    {
      this.userRepository = userRepositoryParam;
      seedService.Seed(userRepository);
    }
    public User Authenticate(LoginViewModel login)
    {
      foreach(var user in userRepository.GetUsers())
      {
        if(user.Email == login.Email && user.Password == login.Password)
        {
          return user;
        }
      }
      return null;
    }
  }
}