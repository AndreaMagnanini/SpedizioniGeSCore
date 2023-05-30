using FancyWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace FancyWebApp.Interfaces.Services;

public interface IUserService
{
    Task<PasswordVerificationResult> Login(string userName, string password);
    Task<User> Register(User user);
}