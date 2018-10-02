using SnipCodeAPI.Models;
using SnipCodeAPI.Repositories.Interfaces;
using SnipCodeAPI.Services.Interfaces;

namespace SnipCodeAPI.Services
{
  public class SeedService : ISeedService
  {
    public void Seed(IUserRepository userRepository)
    {
      //Get all users
      var users = userRepository.GetUsers();
      foreach(var user in users)
      {
        userRepository.DeleteUser(user.ID);
      }

      //Create new User for testing purpose
      userRepository.InsertUser(new User()
      {
        Email = "Admin",
        Password = "admin"
      });

    }
  }
}