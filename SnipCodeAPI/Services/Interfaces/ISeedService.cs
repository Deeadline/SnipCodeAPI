using SnipCodeAPI.Repositories.Interfaces;

namespace SnipCodeAPI.Services.Interfaces
{
  public interface ISeedService
  {
      void Seed(IUserRepository userRepository);
  }
}