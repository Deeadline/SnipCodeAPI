using SnipCodeAPI.Models;
using System.Collections.Generic;

namespace SnipCodeAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
        void InsertUser(User user);
        void DeleteUser(int id);
        bool UpdateUser(User user);
    }
}
