using System.Collections.Generic;
using SnipCodeAPI.Models;
using SnipCodeAPI.Repositories.Interfaces;

using System.Linq;

namespace SnipCodeAPI.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly IDataGateway _dataGateway;
    public UserRepository(IDataGateway dataGateway) => _dataGateway = dataGateway;
    public void DeleteUser(int id) => _dataGateway.RemoveUser(id);
    public User GetUserById(int userId) => _dataGateway.GetUserById(userId);
    public IEnumerable<User> GetUsers() => _dataGateway.GetAllUsers() ?? new List<User>();
    public void InsertUser(User user) => _dataGateway.InsertUser(user);
    public bool UpdateUser(User user) => _dataGateway.UpdateUser(user);
  }
}