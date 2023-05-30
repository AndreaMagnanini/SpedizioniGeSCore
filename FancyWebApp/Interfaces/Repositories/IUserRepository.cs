using FancyWebApp.Models;

namespace FancyWebApp.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByUserName(string userName);
    Task Register(User user);
}